using Microsoft.AspNetCore.Mvc;
using CombatGameWebApp.Models;
using CombatGame.Data;
using System.Linq;

namespace CombatGame.Controllers
{
    public class LeaderboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaderboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var leaderboard = _context.Battles
                .GroupBy(b => b.Winner)
                .Select(g => new { TeamName = g.Key, Wins = g.Count() })
                .OrderByDescending(g => g.Wins)
                .ToList();

            return View(leaderboard);
        }
    }
}
