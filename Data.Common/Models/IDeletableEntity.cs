namespace MVCTemplate.Data.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public interface IDeletableEntity
    {
        [Index]
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
