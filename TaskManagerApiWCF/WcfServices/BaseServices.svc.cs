using DataAccess.Entities;
using ServiceLayer.Services;
using System.Collections.Generic;
using TaskManagerApiWCF.Interfaces;
using TaskManagerApiWCF.Models;

namespace TaskManagerApiWCF.WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BaseServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public abstract class BaseServices<T, M> : IBaseServices<M>
        where T : BaseEntity, new()
        where M : BaseModel, new()
    {
        private readonly BaseService<T> Service;

        public abstract BaseService<T> CreateService();

        public abstract M PopulateModel(T entity);

        public abstract T PopulateEntity(M model);

        public BaseServices()
        {
            Service = CreateService();
        }

        public List<M> GetAll()
        {
            List<M> list = new List<M>();
            foreach (var item in Service.GetAll())
            {
                list.Add(PopulateModel(item));
            }
            return list;
        }

        public M GetByID(int id)
        {
            return PopulateModel(Service.GetByID(id));
        }

        public void Save(M model)
        {
            Service.Save(PopulateEntity(model));
        }

        public void Delete(M model)
        {
            Service.Delete(PopulateEntity(model));
        }
    }
}