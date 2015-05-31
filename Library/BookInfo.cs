using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    [DataContract]
    public class BookInfo
    {
        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Year { get; set; }
    }
}
