using SuperheroDB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SuperheroDB.Services
{
    public static class FileService
    {
        public const string DataPath = "superheroes.txt";
        public const string SummaryPath = "summary.txt";
        private const string Header = "HeroId,Name,Age,Superpower,ExamScore,Rank,ThreatLevel";

        public static void EnsureFiles()
        {
            try
            {
                if (!File.Exists(DataPath))
                {
                    File.WriteAllText(DataPath, Header + Environment.NewLine, Encoding.UTF8);
                }
            }
            catch (Exception ex)
            {
                throw new IOException("Failed to ensure data files exist.", ex);
            }
        }

        public static List<Hero> LoadAll()
        {
            EnsureFiles();
            try
            {
                var lines = File.ReadAllLines(DataPath, Encoding.UTF8).Skip(1); // skip header
                var list = new List<Hero>();
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    list.Add(Hero.FromCsv(line));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new IOException("Failed to load heroes from file.", ex);
            }
        }

        public static void ReplaceAll(IEnumerable<Hero> heroes)
        {
            try
            {
                var sb = new StringBuilder();
                sb.AppendLine(Header);
                foreach (var h in heroes)
                    sb.AppendLine(h.ToCsv());
                File.WriteAllText(DataPath, sb.ToString(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                throw new IOException("Failed to write heroes to file.", ex);
            }
        }

        public static void Append(Hero hero)
        {
            EnsureFiles();
            try
            {
                File.AppendAllText(DataPath, hero.ToCsv() + Environment.NewLine, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                throw new IOException("Failed to append hero to file.", ex);
            }
        }

        public static bool Update(Hero updated)
        {
            var list = LoadAll();
            var idx = list.FindIndex(h => h.HeroId.Equals(updated.HeroId, StringComparison.OrdinalIgnoreCase));
            if (idx < 0) return false;
            list[idx] = updated;
            ReplaceAll(list);
            return true;
        }

        public static bool Delete(string heroId)
        {
            var list = LoadAll();
            var removed = list.RemoveAll(h => h.HeroId.Equals(heroId, StringComparison.OrdinalIgnoreCase));
            if (removed > 0) ReplaceAll(list);
            return removed > 0;
        }

        public static void WriteSummary(string content)
        {
            try
            {
                File.WriteAllText(SummaryPath, content, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                throw new IOException("Failed to write summary file.", ex);
            }
        }
    }
}
