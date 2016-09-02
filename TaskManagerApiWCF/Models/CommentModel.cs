using System;
using System.Runtime.Serialization;

namespace TaskManagerApiWCF.Models
{
    [DataContract]
    public class CommentModel : BaseModel
    {
        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public int TaskID { get; set; }

        [DataMember]
        public int UserID { get; set; }
    }
}