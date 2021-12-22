namespace ShopXWeb.Models.Posts
{
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class AddPostFormModel
    {
        [Required]
        [StringLength(
            PostTitleMaxLength,
            MinimumLength = PostTitleMinLength,
            ErrorMessage = "The field Title must be a text with a minimum length of {2} and a maximum length of {1}.")]
        public string Title { get; init; }

        [Required]
        public IFormFile Image { get; init; }

        [Range(PostPriceMinValue, PostPriceMaxValue)]
        public double Price { get; init; }

        [Required]
        [StringLength(
            PostDescriptionMaxLength,
            MinimumLength = PostDescriptionMinLength,
            ErrorMessage = "The field Description must be a text with a minimum length of '{2}'.")]
        public string Description { get; init; }

        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        public IEnumerable<PostCategoryViewModel> Categories { get; set; }

        [Display(Name = "Currency")]
        public int CurrencyTypeId { get; init; }

        public IEnumerable<PostCurrencyTypeViewModel> CurrencyTypes { get; set; }
    }
}
