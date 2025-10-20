using SuperheroDB.Models;
using SuperheroDB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SuperheroDB.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            try
            {
                FileService.EnsureFiles();
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Startup error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshGrid()
        {
            try
            {
                var list = FileService.LoadAll();
                dgvHeroes.DataSource = null;
                dgvHeroes.AutoGenerateColumns = true;
                dgvHeroes.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load data: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtId.Clear();
            txtName.Clear();
            txtAge.Clear();
            txtPower.Clear();
            txtScore.Clear();
            txtId.Focus();
        }

        private bool TryBuildHeroFromInputs(out Hero hero, out string error)
        {
            hero = new Hero();
            error = "";

            if (string.IsNullOrWhiteSpace(txtId.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPower.Text) ||
                string.IsNullOrWhiteSpace(txtAge.Text) ||
                string.IsNullOrWhiteSpace(txtScore.Text))
            {
                error = "All fields are required.";
                return false;
            }

            if (!int.TryParse(txtAge.Text, out var age) || age <= 0)
            {
                error = "Age must be a positive number.";
                return false;
            }

            if (!int.TryParse(txtScore.Text, out var score) || score < 0 || score > 100)
            {
                error = "Exam Score must be a number between 0 and 100.";
                return false;
            }

            var (rank, threat) = Ranking.FromScore(score);

            hero = new Hero
            {
                HeroId = txtId.Text.Trim(),
                Name = txtName.Text.Trim(),
                Age = age,
                Superpower = txtPower.Text.Trim(),
                ExamScore = score,
                Rank = rank,
                ThreatLevel = threat
            };
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!TryBuildHeroFromInputs(out var hero, out var error))
            {
                MessageBox.Show(error, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var all = FileService.LoadAll();
                if (all.Any(h => h.HeroId.Equals(hero.HeroId, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Hero ID already exists.", "Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FileService.Append(hero);
                RefreshGrid();
                MessageBox.Show("Hero added.");
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Add failed: {ex.Message}", "Add Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!TryBuildHeroFromInputs(out var hero, out var error))
            {
                MessageBox.Show(error, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var ok = FileService.Update(hero);
                if (!ok)
                {
                    MessageBox.Show("Hero ID not found. Select a row or enter a valid existing ID.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                RefreshGrid();
                MessageBox.Show("Hero updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update failed: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtId.Text.Trim();
            if (string.IsNullOrWhiteSpace(id) && dgvHeroes.CurrentRow != null)
            {
                id = dgvHeroes.CurrentRow.Cells[nameof(Hero.HeroId)]?.Value?.ToString() ?? "";
            }

            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Select a row or enter a Hero ID to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show($"Delete hero with ID '{id}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var ok = FileService.Delete(id);
                if (!ok)
                {
                    MessageBox.Show("Hero ID not found.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                RefreshGrid();
                MessageBox.Show("Hero deleted.");
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Delete failed: {ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            try
            {
                var all = FileService.LoadAll();
                if (all.Count == 0)
                {
                    MessageBox.Show("No data to summarize.");
                    return;
                }

                int total = all.Count;
                double avgAge = all.Average(h => h.Age);
                double avgScore = all.Average(h => h.ExamScore);
                int countC = all.Count(h => h.Rank == "C");
                int countB = all.Count(h => h.Rank == "B");
                int countA = all.Count(h => h.Rank == "A");
                int countS = all.Count(h => h.Rank == "S");

                // Display
                lblTotal.Text = total.ToString();
                lblAvgAge.Text = avgAge.ToString("0.0");
                lblAvgScore.Text = avgScore.ToString("0.0");
                lblC.Text = countC.ToString();
                lblB.Text = countB.ToString();
                lblA.Text = countA.ToString();
                lblS.Text = countS.ToString();

                // Write file
                var lines = new List<string>
                {
                    $"Summary generated: {DateTime.Now}",
                    $"Total Heroes: {total}",
                    $"Average Age: {avgAge:0.00}",
                    $"Average Exam Score: {avgScore:0.00}",
                    $"Rank Counts: C={countC}, B={countB}, A={countA}, S={countS}"
                };
                FileService.WriteSummary(string.Join(Environment.NewLine, lines));

                MessageBox.Show("Summary generated and saved to summary.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Summary failed: {ex.Message}", "Summary Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHeroes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHeroes.CurrentRow == null) return;
            try
            {
                var row = dgvHeroes.CurrentRow;
                if (row == null) return;
                txtId.Text = row.Cells[nameof(Hero.HeroId)]?.Value?.ToString() ?? "";
                txtName.Text = row.Cells[nameof(Hero.Name)]?.Value?.ToString() ?? "";
                txtAge.Text = row.Cells[nameof(Hero.Age)]?.Value?.ToString() ?? "";
                txtPower.Text = row.Cells[nameof(Hero.Superpower)]?.Value?.ToString() ?? "";
                txtScore.Text = row.Cells[nameof(Hero.ExamScore)]?.Value?.ToString() ?? "";
            }
            catch
            {
                // ignore if columns are missing (e.g., no data yet)
            }
        }
    }
}
