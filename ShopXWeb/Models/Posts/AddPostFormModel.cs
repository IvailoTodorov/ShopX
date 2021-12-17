namespace ShopXWeb.Models.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AddPostFormModel
    {
        public string Title { get; init; }

        public string Image { get; init; }

        public double Price { get; init; }

        public string PriceType { get; init; }

        public string Description { get; init; }

        public int CategoryId { get; init; }
    }
}
