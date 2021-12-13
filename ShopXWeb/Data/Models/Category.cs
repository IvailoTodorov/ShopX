namespace ShopXWeb.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Category
    {
        public int Id { get; init; }

        public string Name { get; set; }

        public IEnumerable<Post> Posts { get; init; } = new List<Post>();
    }
}
