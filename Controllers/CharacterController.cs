using Microsoft.AspNetCore.Mvc;
using CombatGame.Models;
using CombatGame.Data;
using System.Linq;
using CombatGame.Models;

namespace CombatGame.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CharacterController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Character character)
        {
            if (character.TotalStats > 300)
            {
                ModelState.AddModelError("", "Total stats cannot exceed 300.");
            }

            if (ModelState.IsValid)
            {
                _context.Characters.Add(character);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(character);
        }
    }
}
