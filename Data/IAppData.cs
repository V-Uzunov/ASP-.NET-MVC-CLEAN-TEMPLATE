namespace Data
{
    using Data.Models;
    using Data.Repositories;
    using Microsoft.AspNet.Identity.EntityFramework;

    public interface IAppData
    {
        IRepository<User> Users
        {
            get;
        }

        IRepository<IdentityRole> Roles
        {
            get;
        }
    }
}
