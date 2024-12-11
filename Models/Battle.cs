using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CombatGame.Models
{
    public class Battle
    {
        public int Id { get; set; }

        [Required]
        public int Team1Id { get; set; }
        [ForeignKey("Team1Id")]
        public Team? Team1 { get; set; }

        [Required]
        public int Team2Id { get; set; }
        [ForeignKey("Team2Id")]
        public Team? Team2 { get; set; }

        [Required]
        public string? Winner { get; set; }

        public DateTime BattleDate { get; set; } = DateTime.Now;
    }
}

