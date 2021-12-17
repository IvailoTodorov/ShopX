namespace ShopXWeb.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    using static DataConstants;

    public class Post
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(PostTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Image { get; set; } // can be collection of images

        [Required]
        [Range(PostPriceMinValue, PostPriceMaxValue)]
        public double Price { get; set; }

        [Required]
        public string PriceType { get; set; } // user can select between USD and BGN

        [Required]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; init; }

        // USER

        // (Add to favorite)
    }
}
