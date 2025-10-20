using System;

namespace SuperheroDB.Services
{
    public static class Ranking
    {
        /// <summary>
        /// Returns (Rank, ThreatLevel) based on the given exam score (0-100).
        /// S: 81-100 -> "Finals Week"
        /// A: 61-80  -> "Midterm Madness"
        /// B: 41-60  -> "Group Project Gone Wrong"
        /// C: 0-40   -> "Pop Quiz"
        /// </summary>
        public static (string rank, string threat) FromScore(int score)
        {
            if (score < 0 || score > 100)
                throw new ArgumentOutOfRangeException(nameof(score), "Score must be between 0 and 100.");

            if (score >= 81) return ("S", "Finals Week");
            if (score >= 61) return ("A", "Midterm Madness");
            if (score >= 41) return ("B", "Group Project Gone Wrong");
            return ("C", "Pop Quiz");
        }
    }
}
