using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;
namespace CombatGame.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        [Required]
        public string TeamName { get; set; } = string.Empty;

        public int UserId { get; set; }
        public User? User { get; set; }

        public List<Character> Characters { get; set; } = new List<Character>();

        [Range(1, 5, ErrorMessage = "A team can have a maximum of 5 characters.")]
        public int MaxCharacters => 5;
    }
}
