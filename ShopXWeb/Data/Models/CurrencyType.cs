namespace ShopXWeb.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CurrencyType
    {
        public int Id { get; init; }

        public string Name { get; set; }

        public IEnumerable<Post> Posts { get; init; } = new List<Post>();
    }
}
