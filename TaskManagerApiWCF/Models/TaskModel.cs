using System;
using System.Runtime.Serialization;

namespace TaskManagerApiWCF.Models
{
    [DataContract]
    public class TaskModel : BaseModel
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int WorkingHours { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public DateTime LastEditDate { get; set; }

        [DataMember]
        public StatusEnum Status { get; set; }

        [DataMember]
        public int CreatorID { get; set; }

        [DataMember]
        public int ResponsibleID { get; set; }
    }

    [DataContract]
    public enum StatusEnum
    {
        [EnumMember]
        Pending,
        [EnumMember]
        Done
    }
}