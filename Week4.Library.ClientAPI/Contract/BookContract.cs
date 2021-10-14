using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Week4.Library.ClientAPI.Contract
{
    public class BookContract
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Isbn { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Author { get; set; }
    }
}
