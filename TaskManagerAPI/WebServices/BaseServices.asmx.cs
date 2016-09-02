using DataAccess.Entities;
using ServiceLayer.Services;
using System.Collections.Generic;
using System.Web.Services;

namespace TaskManagerAPI.WebServices
{
    /// <summary>
    /// Summary description for BaseServices
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public abstract class BaseServices<T> : WebService
        where T : BaseEntity
    {
        private readonly BaseService<T> BaseService;

        public abstract BaseService<T> CreateService();

        public BaseServices()
        {
            BaseService = CreateService();
        }

        [WebMethod]
        public List<T> GetAll()
        {
            return BaseService.GetAll();
        }

        [WebMethod]
        public T GetFirst()
        {
            return BaseService.GetFirst();
        }

        [WebMethod]
        public T GetByID(int id)
        {
            return BaseService.GetByID(id);
        }

        [WebMethod]
        public void Save(T entity)
        {
            BaseService.Save(entity);
        }

        [WebMethod]
        public void Delete(T entity)
        {
            BaseService.Delete(entity);
        }
    }
}