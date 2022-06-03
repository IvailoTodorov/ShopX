namespace ShopXWeb.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AboutController : Controller
    {
        public IActionResult Index() => this.View();
    }
}
