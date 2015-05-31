using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    [DataContract]
    public class BookExceptions
    {
        [DataMember]
        public String Message { get; set; }
    }
}
