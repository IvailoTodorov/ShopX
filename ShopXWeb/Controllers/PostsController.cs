namespace ShopXWeb.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ShopXWeb.Models.Posts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PostsController : Controller
    {
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(AddPostFormModel post)
        {

            return View();
        }
    }
}
