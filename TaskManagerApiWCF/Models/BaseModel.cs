using System.Runtime.Serialization;

namespace TaskManagerApiWCF.Models
{
    [DataContract]
    public abstract class BaseModel
    {
        [DataMember]
        public int ID { get; set; }
    }
}