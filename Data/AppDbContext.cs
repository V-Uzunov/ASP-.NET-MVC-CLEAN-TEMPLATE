namespace MVCTemplate.Data
{
    using Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVCTemplate.Data.Common.Models;
    using System;
    using System.Data.Entity;
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
        
        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
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