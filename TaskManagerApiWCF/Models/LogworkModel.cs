using System;
using System.Runtime.Serialization;

namespace TaskManagerApiWCF.Models
{
    [DataContract]
    public class LogworkModel : BaseModel
    {
        [DataMember]
        public int WorkingHours { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public int TaskID { get; set; }

        [DataMember]
        public int UserID { get; set; }
    }
}