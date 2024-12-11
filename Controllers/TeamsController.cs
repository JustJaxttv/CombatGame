using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using CombatGame.Models;
using CombatGame.Data;
using System.Linq;

namespace CombatGame.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var teams = _context.Teams.ToList();
            return View(teams);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Team team)
        {
            if (team.Characters.Count > team.MaxCharacters)
            {
                ModelState.AddModelError("", "A team can only have up to 5 characters.");
            }

            if (ModelState.IsValid)
            {
                _context.Teams.Add(team);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(team);
        }
    }
}
