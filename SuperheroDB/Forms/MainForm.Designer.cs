using System.Windows.Forms;

namespace SuperheroDB.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblPower = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();

            this.txtId = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtPower = new System.Windows.Forms.TextBox();
            this.txtScore = new System.Windows.Forms.TextBox();

            this.btnAdd = new System.Windows.Forms.Button();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSummary = new System.Windows.Forms.Button();

            this.dgvHeroes = new System.Windows.Forms.DataGridView();
            this.grpSummary = new System.Windows.Forms.GroupBox();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelAvgAge = new System.Windows.Forms.Label();
            this.labelAvgScore = new System.Windows.Forms.Label();
            this.labelC = new System.Windows.Forms.Label();
            this.labelB = new System.Windows.Forms.Label();
            this.labelA = new System.Windows.Forms.Label();
            this.labelS = new System.Windows.Forms.Label();

            this.lblTotal = new System.Windows.Forms.Label();
            this.lblAvgAge = new System.Windows.Forms.Label();
            this.lblAvgScore = new System.Windows.Forms.Label();
            this.lblC = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();
            this.lblS = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvHeroes)).BeginInit();
            this.grpSummary.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.Text = "Superhero Database (PRG2782)";
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Title
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Text = "Superhero Database System";

            // Labels for inputs
            int leftLabel = 20;
            int leftInput = 160;
            int top = 60;
            int vgap = 32;

            // ID
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(leftLabel, top);
            this.lblId.Text = "Hero ID:";

            this.txtId.Location = new System.Drawing.Point(leftInput, top - 3);
            this.txtId.Size = new System.Drawing.Size(220, 27);

            // Name
            top += vgap;
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(leftLabel, top);
            this.lblName.Text = "Name:";

            this.txtName.Location = new System.Drawing.Point(leftInput, top - 3);
            this.txtName.Size = new System.Drawing.Size(220, 27);

            // Age
            top += vgap;
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(leftLabel, top);
            this.lblAge.Text = "Age:";

            this.txtAge.Location = new System.Drawing.Point(leftInput, top - 3);
            this.txtAge.Size = new System.Drawing.Size(220, 27);

            // Power
            top += vgap;
            this.lblPower.AutoSize = true;
            this.lblPower.Location = new System.Drawing.Point(leftLabel, top);
            this.lblPower.Text = "Superpower:";

            this.txtPower.Location = new System.Drawing.Point(leftInput, top - 3);
            this.txtPower.Size = new System.Drawing.Size(220, 27);

            // Score
            top += vgap;
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(leftLabel, top);
            this.lblScore.Text = "Exam Score (0-100):";

            this.txtScore.Location = new System.Drawing.Point(leftInput, top - 3);
            this.txtScore.Size = new System.Drawing.Size(220, 27);

            // Buttons
            top += vgap + 8;
            int btnWidth = 110;
            int gap = 12;
            int btnLeft = leftInput;
            int btnTop = top;

            this.btnAdd.Location = new System.Drawing.Point(btnLeft, btnTop);
            this.btnAdd.Size = new System.Drawing.Size(btnWidth, 32);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnViewAll.Location = new System.Drawing.Point(btnLeft + (btnWidth + gap)*1, btnTop);
            this.btnViewAll.Size = new System.Drawing.Size(btnWidth, 32);
            this.btnViewAll.Text = "View All";
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);

            this.btnUpdate.Location = new System.Drawing.Point(btnLeft + (btnWidth + gap)*2, btnTop);
            this.btnUpdate.Size = new System.Drawing.Size(btnWidth, 32);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location = new System.Drawing.Point(btnLeft + (btnWidth + gap)*3, btnTop);
            this.btnDelete.Size = new System.Drawing.Size(btnWidth, 32);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnSummary.Location = new System.Drawing.Point(btnLeft + (btnWidth + gap)*4, btnTop);
            this.btnSummary.Size = new System.Drawing.Size(btnWidth + 20, 32);
            this.btnSummary.Text = "Generate Summary";
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click);

            // DataGridView
            this.dgvHeroes.Location = new System.Drawing.Point(420, 60);
            this.dgvHeroes.Size = new System.Drawing.Size(560, 400);
            this.dgvHeroes.ReadOnly = true;
            this.dgvHeroes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvHeroes.MultiSelect = false;
            this.dgvHeroes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHeroes.SelectionChanged += new System.EventHandler(this.dgvHeroes_SelectionChanged);

            // Summary Group
            this.grpSummary.Text = "Summary";
            this.grpSummary.Location = new System.Drawing.Point(20, 330);
            this.grpSummary.Size = new System.Drawing.Size(360, 230);

            // Static labels
            int sl = 20; // inside group left
            int st = 30;
            int sv = 28;
            this.labelTotal.Location = new System.Drawing.Point(sl, st);
            this.labelTotal.AutoSize = true;
            this.labelTotal.Text = "Total Heroes:";

            this.lblTotal.Location = new System.Drawing.Point(200, st);
            this.lblTotal.AutoSize = true;
            this.lblTotal.Text = "0";

            st += sv;
            this.labelAvgAge.Location = new System.Drawing.Point(sl, st);
            this.labelAvgAge.AutoSize = true;
            this.labelAvgAge.Text = "Average Age:";

            this.lblAvgAge.Location = new System.Drawing.Point(200, st);
            this.lblAvgAge.AutoSize = true;
            this.lblAvgAge.Text = "0";

            st += sv;
            this.labelAvgScore.Location = new System.Drawing.Point(sl, st);
            this.labelAvgScore.AutoSize = true;
            this.labelAvgScore.Text = "Average Score:";

            this.lblAvgScore.Location = new System.Drawing.Point(200, st);
            this.lblAvgScore.AutoSize = true;
            this.lblAvgScore.Text = "0";

            st += sv;
            this.labelC.Location = new System.Drawing.Point(sl, st);
            this.labelC.AutoSize = true;
            this.labelC.Text = "C-Rank Count:";

            this.lblC.Location = new System.Drawing.Point(200, st);
            this.lblC.AutoSize = true;
            this.lblC.Text = "0";

            st += sv;
            this.labelB.Location = new System.Drawing.Point(sl, st);
            this.labelB.AutoSize = true;
            this.labelB.Text = "B-Rank Count:";

            this.lblB.Location = new System.Drawing.Point(200, st);
            this.lblB.AutoSize = true;
            this.lblB.Text = "0";

            st += sv;
            this.labelA.Location = new System.Drawing.Point(sl, st);
            this.labelA.AutoSize = true;
            this.labelA.Text = "A-Rank Count:";

            this.lblA.Location = new System.Drawing.Point(200, st);
            this.lblA.AutoSize = true;
            this.lblA.Text = "0";

            st += sv;
            this.labelS.Location = new System.Drawing.Point(sl, st);
            this.labelS.AutoSize = true;
            this.labelS.Text = "S-Rank Count:";

            this.lblS.Location = new System.Drawing.Point(200, st);
            this.lblS.AutoSize = true;
            this.lblS.Text = "0";

            // Add controls to group
            this.grpSummary.Controls.Add(this.labelTotal);
            this.grpSummary.Controls.Add(this.lblTotal);
            this.grpSummary.Controls.Add(this.labelAvgAge);
            this.grpSummary.Controls.Add(this.lblAvgAge);
            this.grpSummary.Controls.Add(this.labelAvgScore);
            this.grpSummary.Controls.Add(this.lblAvgScore);
            this.grpSummary.Controls.Add(this.labelC);
            this.grpSummary.Controls.Add(this.lblC);
            this.grpSummary.Controls.Add(this.labelB);
            this.grpSummary.Controls.Add(this.lblB);
            this.grpSummary.Controls.Add(this.labelA);
            this.grpSummary.Controls.Add(this.lblA);
            this.grpSummary.Controls.Add(this.labelS);
            this.grpSummary.Controls.Add(this.lblS);

            // Add controls to form
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblPower);
            this.Controls.Add(this.lblScore);

            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtPower);
            this.Controls.Add(this.txtScore);

            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnViewAll);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSummary);

            this.Controls.Add(this.dgvHeroes);
            this.Controls.Add(this.grpSummary);

            ((System.ComponentModel.ISupportInitialize)(this.dgvHeroes)).EndInit();
            this.grpSummary.ResumeLayout(false);
            this.grpSummary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Controls
        private Label lblTitle;
        private Label lblId;
        private Label lblName;
        private Label lblAge;
        private Label lblPower;
        private Label lblScore;

        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtAge;
        private TextBox txtPower;
        private TextBox txtScore;

        private Button btnAdd;
        private Button btnViewAll;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnSummary;

        private DataGridView dgvHeroes;
        private GroupBox grpSummary;

        private Label labelTotal;
        private Label labelAvgAge;
        private Label labelAvgScore;
        private Label labelC;
        private Label labelB;
        private Label labelA;
        private Label labelS;

        private Label lblTotal;
        private Label lblAvgAge;
        private Label lblAvgScore;
        private Label lblC;
        private Label lblB;
        private Label lblA;
        private Label lblS;
    }
}
