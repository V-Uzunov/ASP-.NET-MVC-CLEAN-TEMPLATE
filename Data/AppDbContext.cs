namespace Data
{
    using Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}