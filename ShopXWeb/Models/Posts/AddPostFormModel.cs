namespace ShopXWeb.Models.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddPostFormModel
    {
        public string Title { get; init; }

        public string Image { get; init; }

        public double Price { get; init; }

        public string Description { get; init; }

        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        public IEnumerable<PostCategoryViewModel> Categories { get; set; }

        [Display(Name = "Currency")]
        public int CurrencyTypeId { get; init; }

        public IEnumerable<PostCurrencyTypeViewModel> CurrencyTypes { get; set; }
    }
}
