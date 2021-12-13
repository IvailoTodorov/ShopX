﻿namespace ShopXWeb.Infrastructure
{
    using System.Linq;
    using ShopXWeb.Data;
    using ShopXWeb.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedService = app.ApplicationServices.CreateScope();

            var data = scopedService.ServiceProvider.GetService<ShopXDbContext>();

            data.Database.Migrate();

            SeedCategory(data);

            return app;
        } 

        private static void SeedCategory(ShopXDbContext data)
        {
            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category { Name = "Real Estate"},
                new Category { Name = "Cars, caravans, boats"},
                new Category { Name = "Electronics"},
                new Category { Name = "Sports, books, hobbies"},
                new Category { Name = "Animals"},
                new Category { Name = "Home and garden"},
                new Category { Name = "Fashion"},
                new Category { Name = "Baby and child"},
                new Category { Name = "Excursions, vacations"},
                new Category { Name = "Services"},
                new Category { Name = "Machines, tools, business equipment"},
                new Category { Name = "Work"},
                new Category { Name = "I\'m giving away"},
            });
        }
    }
}
