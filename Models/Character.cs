using System.ComponentModel.DataAnnotations;

namespace CombatGame.Models
{
    public class Character
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, 100)]
        public int Strength { get; set; }

        [Range(1, 100)]
        public int Defense { get; set; }

        [Range(1, 100)]
        public int Speed { get; set; }

        [Range(1, 100)]
        public int Intelligence { get; set; }

        [Range(1, 100)]
        public int TotalStats
        {
            get { return Strength + Defense + Speed + Intelligence; }
        }
    }
}
