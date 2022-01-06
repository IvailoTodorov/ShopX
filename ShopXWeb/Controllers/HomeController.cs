namespace ShopXWeb.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using ShopXWeb.Data;
    using ShopXWeb.Models;
    using ShopXWeb.Models.Posts;

    public class HomeController : Controller
    {
        private readonly ShopXDbContext data;

        public HomeController(
            ShopXDbContext data)
        {
            this.data = data;
        }
        public IActionResult Index()
        {
            var posts = this.data
                .Posts
                .OrderByDescending(x => x.Id)
                .Select(p => new PostListingViewModel
                {
                    Id = p.Id,
                    Image = p.Image,
                    Title = p.Title,
                    Price = p.Price,
                    CurrencyType = p.CurrencyType.Name
                })
                .Take(3)
                .ToList();


            return View(posts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() 
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });


        //private IEnumerable<PostCategoryViewModel> GetThreePostCategories()
        //   => this.data
        //   .Categories
        //   .Select(p => new PostCategoryViewModel
        //   {
        //       Id = p.Id,
        //       Name = p.Name
        //   })
        //    .Take(3)
        //   .ToList();
    }
}
