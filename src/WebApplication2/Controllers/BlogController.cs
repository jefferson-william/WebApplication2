using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class BlogController : Controller
    {
        private MyContext _context;

        public BlogController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Blog.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Blog.Add(blog);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blog);
        }

    }
}
