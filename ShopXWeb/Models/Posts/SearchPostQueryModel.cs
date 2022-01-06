namespace ShopXWeb.Models.Posts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class SearchPostQueryModel
    {
        //public IEnumerable<string> Titles { get; init; }

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        [Display(Name = "Sort By")]
        public PostSorting Sorting { get; init; }

        public IEnumerable<PostListingViewModel> Posts { get; set; }
    }
}
