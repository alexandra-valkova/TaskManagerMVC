using DataAccess.Entities;
using ServiceLayer.Services;
using System.Web.Services;

namespace TaskManagerAPI.WebServices
{
    /// <summary>
    /// Summary description for UserServices
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserServices : BaseServices<User>
    {
        public override BaseService<User> CreateService()
        {
            return new UserService();
        }
    }
}