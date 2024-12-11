using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using CombatGame.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CombatGame.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}