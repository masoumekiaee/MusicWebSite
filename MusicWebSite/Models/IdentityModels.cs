using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MusicWebSite.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Music> Musics { get; set; }
        public System.Data.Entity.DbSet<MusicCategory> MusicCategories { get; set; }
        public System.Data.Entity.DbSet<Singer> Singers { get; set; }
        public System.Data.Entity.DbSet<Comment> Comments { get; set; }
        public System.Data.Entity.DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new Music.Configuration());
            modelBuilder.Configurations.Add(new MusicCategory.Configuration());
            modelBuilder.Configurations.Add(new Singer.Configuration());
            modelBuilder.Configurations.Add(new Comment.Configuration());
            modelBuilder.Configurations.Add(new UserInfo.Configuration());
        }

    }
}