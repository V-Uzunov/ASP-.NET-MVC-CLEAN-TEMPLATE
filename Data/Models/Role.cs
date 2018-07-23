namespace MVCTemplate.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVCTemplate.Data.Common.Models;

    public class Role : IdentityRole, IAuditInfo, IDeletableEntity
    {
        public Role()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
