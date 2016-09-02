using System.ServiceModel;
using TaskManagerApiWCF.Models;

namespace TaskManagerApiWCF.Interfaces
{
    [ServiceContract]
    public interface ILogworkServices : IBaseServices<LogworkModel>
    {
    }
}