namespace ShopXWeb.Controllers
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using ShopXWeb.Data;
    using ShopXWeb.Data.Models;
    using ShopXWeb.Models.Posts;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class PostsController : Controller
    {
        private readonly ShopXDbContext data;
        private readonly IWebHostEnvironment webHostEnvironment;

        public PostsController(
            ShopXDbContext data,
            IWebHostEnvironment webHostEnvironment)
        {
            this.data = data;
            this.webHostEnvironment = webHostEnvironment;

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

            string uniqueFileName = ProcessUploadedFile(post);

            var postData = new Post
            {
                Title = post.Title,
                Image = uniqueFileName,
                Price = post.Price,
                Description = post.Description,
                CategoryId = post.CategoryId,
                CurrencyTypeId = post.CurrencyTypeId
            };

            this.data.Posts.Add(postData);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));

        }

        public IActionResult All([FromQuery]SearchPostQueryModel query)
        {
            var postsQuery = this.data.Posts.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                postsQuery = postsQuery.Where(
                    p => p.Title.ToLower().Contains(query.SearchTerm.ToLower()) ||
                    p.Description.ToLower().Contains(query.SearchTerm.ToLower()));
            }

            postsQuery = query.Sorting switch
            {
                PostSorting.Title => postsQuery.OrderBy(p => p.Title),
                PostSorting.DateCreated or _ => postsQuery.OrderByDescending(p => p.Id)
            };

            var posts = postsQuery
                .Select(p => new PostListingViewModel
                {
                    Id = p.Id,
                    Image = p.Image,
                    Title = p.Title,
                    Price = p.Price,
                    CurrencyType = p.CurrencyType.Name
                })
                .ToList();

            ViewData["Categories"] = GetPostCategories();

            query.Posts = posts;

            return View(query);
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

        private string ProcessUploadedFile(AddPostFormModel model)
        {
            string uniqueFileName = null;

            if (model.Image != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
