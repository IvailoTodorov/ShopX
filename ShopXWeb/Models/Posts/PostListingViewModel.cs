namespace ShopXWeb.Models.Posts
{
    using System.Collections.Generic;

    public class PostListingViewModel
    {
        public int Id { get; init; }

        public string Image { get; init; }

        public string Title { get; init; }

        public double Price { get; init; }

        public string CurrencyType { get; init; }


    }
}
