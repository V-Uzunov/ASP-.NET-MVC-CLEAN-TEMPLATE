namespace Data
{
    using Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Linq;

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

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}