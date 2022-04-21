using DemoMsit133.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMsit133.Controllers
{
    public class APIController : Controller
    {
        private readonly DemoContext _context;

        public APIController(DemoContext context)
        {
            _context = context;
        }


        public IActionResult Index(string userName, int age)
        {
            System.Threading.Thread.Sleep(4000);
            if (string.IsNullOrEmpty(userName))
            {
                userName = "中文";

            }
            return Content($"Hello {userName} {age} ", "text/plain", System.Text.Encoding.UTF8);
        }


        public IActionResult RegistrationCheck(string userName, string password)
        {
            string text = "";

            if (string.IsNullOrEmpty(userName))
                text = "帳號為必填欄位";

            if (!string.IsNullOrEmpty(userName))
            {

                if (_context.Members.Any(c => c.Name == userName))
                {
                    text = "帳號已重複";
                }
                else
                {
                    text = "帳號可使用";
                }


                //string[] dbName = _context.Members.Select(c => c.Name).ToArray();

                //if (dbName.Contains(userName))
                //{
                //    text = "帳號已重複";
                //}
                //else
                //{
                //    text = "帳號可使用";
                //}

            }

            return Content($" {userName}{text}  ", "text/plain", System.Text.Encoding.UTF8);
        }


    }
}
