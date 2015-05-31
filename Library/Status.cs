using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    [DataContract]
    public class Status
    {

        [DataMember]
        public int BookID { get; set; }

        [DataMember]
        public bool Stan { get; set; }

        [DataMember]
        public int UserId { get; set; }
    }
}
