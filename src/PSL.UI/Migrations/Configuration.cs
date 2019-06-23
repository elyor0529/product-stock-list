using PSL.UI.Core.Data;
using PSL.UI.Core.Data.Entities;

namespace PSL.UI.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    ///  This method will be called after migrating to the latest version.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        /// <summary>
        /// You can use the DbSet<T>.AddOrUpdate() helper extension method   to avoid creating duplicate seed data.
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(ApplicationDbContext context)
        {

            //suppliers
            context.Suppliers.AddOrUpdate(a => a.Id, new Supplier
            {
                Name = "ABC Inc." 
            });

            //products
            var items = new Product[300];

            for (var i = 0; i < items.Length; i++)
            {
                items[i] = (i % 3 == 0) ? new Product
                    {
                        Name = "Postcard " + i,
                        Description = "The description for your product",
                        Inventory = 100,
                        Price = 16.90m
                    }
                    : (i % 3 == 1) ? new Product
                    {
                        Name = "Letter " + i,
                        Description = "The description for your product",
                        Inventory = 150,
                        Price = 7.90m
                    }
                    : new Product
                    {
                        Name = "Book " + i,
                        Description = "The description for your product",
                        Inventory = 200,
                        Price = 162.50m
                    };
            }

            context.Products.AddOrUpdate(a => a.Id, items);
        }
    }
}
