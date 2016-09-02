using DataAccess.Entities;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ServiceLayer.Services
{
    public abstract class BaseService<T>
        where T : BaseEntity
    {
        private BaseRepository<T> Repository;

        public abstract BaseRepository<T> CreateRepo();

        public BaseService()
        {
            Repository = CreateRepo();
        }

        // Get All
        public virtual List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return Repository.GetAll(filter);
        }

        // Get First
        public virtual T GetFirst(Expression<Func<T, bool>> filter = null)
        {
            return Repository.GetFirst(filter);
        }

        // Get By ID
        public virtual T GetByID(int id)
        {
            return Repository.GetByID(id);
        }

        // Save
        public virtual void Save(T entity)
        {
            Repository.Save(entity);
        }

        // Delete
        public virtual void Delete(T entity)
        {
            Repository.Delete(entity);
        }
    }
}