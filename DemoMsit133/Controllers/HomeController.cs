using DemoMsit133.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMsit133.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Partial()
        {
            return PartialView();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult jQuery()
        {
            return View();
        }

        public IActionResult FirstAjax()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AjaxPost()
        {


            return View();
        }
        [HttpPost]
        public IActionResult AjaxPost(CUser user)
        {
            ViewBag.name = user.username;
            ViewBag.age = user.age;
       
            return View();
        }

        public IActionResult AjaxFormData(CUser user)
        {

            return View();

        }

        public IActionResult Address()
        {

            return View();

        }
        public IActionResult Promise()
        {

            return View();

        }

        public IActionResult Fetch()
        {

            return View();
        }
    }

   
}
