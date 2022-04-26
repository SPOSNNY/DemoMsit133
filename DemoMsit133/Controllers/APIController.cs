using DemoMsit133.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMsit133.Controllers
{
    public class APIController : Controller
    {
        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _host;
        public APIController(DemoContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
        }


        public IActionResult Index(CUser user)
        {
            System.Threading.Thread.Sleep(1000);
            if (string.IsNullOrEmpty(user.username))
            {
                user.username = "中文";

            }
            return Content($"Hello {user.username } {user.age} ", "text/plain", System.Text.Encoding.UTF8);
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

        public IActionResult Register(Member member, IFormFile photo)
        {

            //上傳檔案儲存到uploads資料夾
            string uploadFolder = Path.Combine(_host.WebRootPath, "uploads", photo.FileName);

            using (var filestream = new FileStream(uploadFolder, FileMode.Create))
            {
                photo.CopyTo(filestream);
            }
            //將圖檔傳為二進位MemoryStream
            byte[] imgByte = null;
            using (MemoryStream stream = new MemoryStream())
            {
                photo.CopyTo(stream);
                imgByte = stream.ToArray();

            }
            //寫進資料庫
            member.FileName = photo.FileName;
            member.FileData = imgByte;

            _context.Members.Add(member);
            _context.SaveChanges();

            string info = $"{photo.FileName}-{photo.Length}-{photo.ContentType}";
            //string info = $"{_host.WebRootPath}-${_host.ContentRootPath})";
            //string info = uploadFolder;
            return Content(info, "text/plain", System.Text.Encoding.UTF8);
            // return Content($"名字 : {user.username} 信箱 : {user.email} 年紀 : {user.age}  ", "text/plain", System.Text.Encoding.UTF8);

        }


        public IActionResult City()
        {
            var cites = _context.Addresses.Select(c => new { c.City }).Distinct().OrderBy(c => c.City);
            return Json(cites);
        }

        public IActionResult Districts(string city)
        {
            var cites = _context.Addresses.Where(a => a.City == city).Select(c => new { c.SiteId }).Distinct().OrderBy(c => c.SiteId);
            return Json(cites);
        }

        public IActionResult Roads(string districts)
        {
            var roads = _context.Addresses.Where(a => a.SiteId == districts).Select(c => new { c.Road }).Distinct().OrderBy(c => c.Road);
            return Json(roads);
        }

        public IActionResult ByteToImg(int? id=1) 
        {
            Member member = _context.Members.Find(id);
            byte[] img = member.FileData;
            return File(img,"image/jpeg");
        }

        
    }
}
