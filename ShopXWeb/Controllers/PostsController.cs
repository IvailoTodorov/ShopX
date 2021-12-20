namespace ShopXWeb.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ShopXWeb.Data;
    using ShopXWeb.Data.Models;
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
            if (!this.data.Categories.Any(c => c.Id == post.CategoryId))
            {
                this.ModelState.AddModelError(nameof(post.CategoryId), "Category does not exist.");
            }

            if (!this.data.CurrencyTypes.Any(c => c.Id == post.CurrencyTypeId))
            {
                this.ModelState.AddModelError(nameof(post.CurrencyTypeId), "Currency type does not exist.");
            }

            if (!ModelState.IsValid)
            {
                post.Categories = this.GetPostCategories();
                post.CurrencyTypes = this.GetPostCurrencyTypes();

                return View(post);
            }

            var postData = new Post
            {
                Title = post.Title,
                Image = post.Image,
                Price = post.Price,
                Description = post.Description,
                CategoryId = post.CategoryId,
                CurrencyTypeId = post.CurrencyTypeId
            };

            this.data.Posts.Add(postData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");

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
