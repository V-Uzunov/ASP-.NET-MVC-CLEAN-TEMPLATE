﻿namespace MVCTemplate.Data.Common.Repositories
{
    using MVCTemplate.Data.Common.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DeletableEntityRepository<T> : Repository<T>, IDeletableEntityRepository<T>
        where T : class, IDeletableEntity, new()
    {
        public DeletableEntityRepository(DbContext context)
            : base(context)
        {
        }

        public override IQueryable<T> All()
        {
            return base.All().Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return base.All();
        }

        public override void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;

            base.Update(entity);
        }

        public override void Delete(object id)
        {
            T entity = base.Find(id);
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;

            this.Update(entity);
        }

        public void HardDelete(T entity)
        {
            base.Delete(entity);
        }

        public void HardDelete(object id)
        {
            T entity = this.Find(id);
            base.Delete(entity);
        }
    }
}
