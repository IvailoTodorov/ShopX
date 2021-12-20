namespace ShopXWeb.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ShopXWeb.Data;
    using ShopXWeb.Models.Posts;
    using System.Collections.Generic;
    using System.Linq;

    public class PostsController : Controller
    {
        private readonly ShopXDbContext data;

        public PostsController(ShopXDbContext data)
        {
            this.data = data;
        }

        public IActionResult Create() => View(new AddPostFormModel
        {
            Categories = this.GetPostCategories(),
            CurrencyTypes = this.GetPostCurrencyTypes()
        });

        [HttpPost]
        public IActionResult Create(AddPostFormModel post)
        {

            return View();
        }

        private IEnumerable<PostCategoryViewModel> GetPostCategories()
            => this.data
            .Categories
            .Select(p => new PostCategoryViewModel
            {
                Id = p.Id,
                Name = p.Name
            })
            .ToList();

        private IEnumerable<PostCurrencyTypeViewModel> GetPostCurrencyTypes()
            => this.data
            .CurrencyTypes
            .Select(p => new PostCurrencyTypeViewModel
            {
                Id = p.Id,
                Name = p.Name
            })
            .ToList();
    }
}
