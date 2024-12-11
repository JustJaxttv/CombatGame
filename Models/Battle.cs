using System;
using System.ComponentModel.DataAnnotations;

namespace CombatGame.Models
{
    public class Battle
    {
        public int Id { get; set; }

        [Required]
        public int Team1Id { get; set; }
        public Team Team1 { get; set; }

        [Required]
        public int Team2Id { get; set; }
        public Team Team2 { get; set; }

        public string Winner { get; set; }
        public DateTime BattleDate { get; set; } = DateTime.Now;
    }
}
