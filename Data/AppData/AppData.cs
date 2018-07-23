namespace MVCTemplate.Data.AppData
{
    using MVCTemplate.Data.Common.Models;
    using MVCTemplate.Data.Models;
    using MVCTemplate.Data.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class AppData : IAppData
    {
        private readonly DbContext context;
        private Dictionary<Type, object> repositories;

        public AppData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Role> Roles
        {
            get
            {
                return this.GetRepository<Role>();
            }
        }

        private IRepository<T> GetRepository<T>() where T : class, IAuditInfo, IDeletableEntity
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(Repository<T>), this.context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}