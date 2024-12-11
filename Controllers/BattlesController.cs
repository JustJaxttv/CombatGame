using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using CombatGame.Models;
using CombatGame.Data;
using System.Linq;

namespace CombatGame.Controllers
{
    public class BattlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BattlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var teams = _context.Teams.ToList();
            return View(teams);
        }

        [HttpPost]
        public IActionResult Simulate(int team1Id, int team2Id)
        {
            var team1 = _context.Teams.Find(team1Id);
            var team2 = _context.Teams.Find(team2Id);

            if (team1 == null || team2 == null || team1Id == team2Id)
            {
                return RedirectToAction("Index");
            }

            // Simple simulation logic based on the number of characters
            string winner = team1.Characters.Count > team2.Characters.Count ? team1.TeamName : team2.TeamName;

            var battle = new Battle
            {
                Team1Id = team1Id,
                Team2Id = team2Id,
                Winner = winner
            };

            _context.Battles.Add(battle);
            _context.SaveChanges();

            return View("Result", battle);
        }
    }
}
