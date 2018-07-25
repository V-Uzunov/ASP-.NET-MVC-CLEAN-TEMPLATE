namespace MVCTemplate.Data.AppData
{
    using MVCTemplate.Data.Common.Repositories;
    using MVCTemplate.Data.Models;

    public interface IAppData
    {
        IDeletableEntityRepository<User> Users
        {
            get;
        }
    }
}