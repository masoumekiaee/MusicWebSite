namespace MusicWebSite.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MusicWebSite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MusicWebSite.Models.ApplicationDbContext context)
        {
            //#region Insert MusicCategory

            //context.MusicCategories.Add(new Models.MusicCategory()
            //{
            //    DisplayOrder = 1,
            //    EngName = "Ghadimi",
            //    FarsiName = "قدیمی"
            //});
            //context.MusicCategories.Add(new Models.MusicCategory()
            //{
            //    DisplayOrder = 2,
            //    EngName = "Sonnati",
            //    FarsiName = "سنتی"
            //});
            //context.MusicCategories.Add(new Models.MusicCategory()
            //{
            //    DisplayOrder = 3,
            //    EngName = "Shad",
            //    FarsiName = "شاد"
            //});
            //context.MusicCategories.Add(new Models.MusicCategory()
            //{
            //    DisplayOrder = 4,
            //    EngName = "Ghamgin",
            //    FarsiName = "غمگین"
            //});
            //context.MusicCategories.Add(new Models.MusicCategory()
            //{
            //    DisplayOrder = 5,
            //    EngName = "Remix",
            //    FarsiName = "ریمیکس"
            //});
            //context.MusicCategories.Add(new Models.MusicCategory()
            //{
            //    DisplayOrder = 6,
            //    EngName = "Tavallod",
            //    FarsiName = "تولد"
            //});
            //context.MusicCategories.Add(new Models.MusicCategory()
            //{
            //    DisplayOrder = 7,
            //    EngName = "Nohe",
            //    FarsiName = "نوحه"
            //});
            //context.MusicCategories.Add(new Models.MusicCategory()
            //{
            //    DisplayOrder = 8,
            //    EngName = "Bikalam",
            //    FarsiName = "بی‌کلام"
            //});

            //#endregion Insert MusicCategory

            //#region Insert Role
            //context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            //{
            //    Id = "100",
            //    Name = "Administrator"
            //});
            //context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            //{
            //    Id = "200",
            //    Name = "User"
            //});

            //#endregion Insert Role

        }
    }
}
