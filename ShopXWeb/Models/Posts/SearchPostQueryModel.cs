namespace ShopXWeb.Models.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SearchPostQueryModel
    {
        //public IEnumerable<string> Titles { get; init; }

        public const int PostsPerPage = 2;

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        [Display(Name = "Sort By")]
        public PostSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalPosts { get; set; }

        public IEnumerable<PostListingViewModel> Posts { get; set; }
    }
}
