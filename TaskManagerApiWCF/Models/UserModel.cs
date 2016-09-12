using System.Runtime.Serialization;

namespace TaskManagerApiWCF.Models
{
    [DataContract]
    public class UserModel : BaseModel
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public bool IsAdmin { get; set; }
    }
}