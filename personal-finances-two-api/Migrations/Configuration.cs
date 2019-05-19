namespace personal_finances_two_api.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    using personal_finances_two_api.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<personal_finances_two_api.Repositories.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Repositories.AppDbContext context)
        {
            //var creditCardSubcategory = new Subcategory
            //{
            //    Name = "Credit card",
            //    CanEdit = false,
            //    Enabled = true,
            //    Category = new Category
            //    {
            //        Type = "D",
            //        Name = "Payment",
            //        CanEdit = false,
            //        Enabled = true,
            //    }
            //};

            //context.Subcategories.Add(creditCardSubcategory);
            //context.SaveChanges();
        }
    }
}
