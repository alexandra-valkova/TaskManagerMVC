using System.Collections.Generic;
using System.ServiceModel;
using TaskManagerApiWCF.Models;

namespace TaskManagerApiWCF.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBaseService" in both code and config file together.
    [ServiceContract]
    public interface IBaseServices<T> where T : BaseModel
    {
        [OperationContract]
        List<T> GetAll();

        [OperationContract]
        T GetByID(int id);

        [OperationContract]
        void Save(T entity);

        [OperationContract]
        void Delete(T entity);
    }
}