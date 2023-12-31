﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebProje.Models;

namespace WebProje.Controllers
{
    [Authorize(Roles ="Doktor,Hasta")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
    

        public HomeController(ILogger<HomeController> logger )
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Data( )
        {
            
            return RedirectToAction("Privacy");
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}