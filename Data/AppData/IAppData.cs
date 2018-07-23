namespace MVCTemplate.Data.AppData
{
    using MVCTemplate.Data.Models;
    using MVCTemplate.Data.Repositories;

    public interface IAppData
    {
        IRepository<User> Users
        {
            get;
        }

        IRepository<Role> Roles
        {
            get;
        }
    }
}
