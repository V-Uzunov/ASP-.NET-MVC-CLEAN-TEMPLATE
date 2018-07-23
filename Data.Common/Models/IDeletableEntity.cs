namespace MVCTemplate.Data.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
