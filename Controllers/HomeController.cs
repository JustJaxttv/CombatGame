﻿using Microsoft.EntityFrameworkCore;
using CombatGame.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CombatGame.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}