using System;

namespace SuperheroDB.Models
{
    public class Hero
    {
        public string HeroId { get; set; } = "";
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Superpower { get; set; } = "";
        public int ExamScore { get; set; }
        public string Rank { get; set; } = "";
        public string ThreatLevel { get; set; } = "";

        public string ToCsv()
        {
            // Simple CSV; commas in fields are not supported for simplicity (per project brief).
            return $"{HeroId},{Name},{Age},{Superpower},{ExamScore},{Rank},{ThreatLevel}";
        }

        public static Hero FromCsv(string line)
        {
            var parts = line.Split(',');
            if (parts.Length < 7) throw new FormatException("Invalid line in superheroes.txt");
            return new Hero
            {
                HeroId = parts[0],
                Name = parts[1],
                Age = int.Parse(parts[2]),
                Superpower = parts[3],
                ExamScore = int.Parse(parts[4]),
                Rank = parts[5],
                ThreatLevel = parts[6]
            };
        }
    }
}
