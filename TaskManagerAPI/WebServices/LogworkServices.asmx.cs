using DataAccess.Entities;
using ServiceLayer.Services;
using System.Web.Services;

namespace TaskManagerAPI.WebServices
{
    /// <summary>
    /// Summary description for LogworkServices
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LogworkServices : BaseServices<Logwork>
    {
        public override BaseService<Logwork> CreateService()
        {
            return new LogworkService();
        }
    }
}