namespace MVCTemplate.Data.AppData
{
    using MVCTemplate.Data.Common.Models;
    using MVCTemplate.Data.Common.Repositories;
    using MVCTemplate.Data.Models;
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

        public IDeletableEntityRepository<User> Users
        {
            get
            {
                return this.GetDeletableEntityRepository<User>();
            }
        }

        private IRepository<T> GetRepository<T>()
            where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(Repository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>()
            where T : class, IDeletableEntity, new()
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}