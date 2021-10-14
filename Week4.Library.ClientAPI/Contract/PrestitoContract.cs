using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Week4.Library.ClientAPI.Contract
{
    public class PrestitoContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int IdLibro { get; set; }

        [DataMember]
        public string Utente { get; set; }

        [DataMember]
        public DateTime DataPrestito { get; set; }

        [DataMember]
        public DateTime? DataReso { get; set; }
    }
}
