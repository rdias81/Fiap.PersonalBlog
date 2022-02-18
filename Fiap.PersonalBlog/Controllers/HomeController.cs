using Fiap.PersonalBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fiap.PersonalBlog.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult LatestBlogPost()
        {
            var posts = new List<BlogPost>() 
            { 
                new BlogPost() { PostId = 1, Title = "post A", ShortDescription = "short for A"},
                new BlogPost() { PostId = 2, Title = "post B", ShortDescription = "short for B"},
                new BlogPost() { PostId = 3, Title = "post C", ShortDescription = "short for C"},
                new BlogPost() { PostId = 4, Title = "post D", ShortDescription = "short for D"},
                new BlogPost() { PostId = 5, Title = "post E", ShortDescription = "short for E"}

            };

            return Json(posts);
        }
    }
}
