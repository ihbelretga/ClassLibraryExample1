using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Server1
{
    [DataContract]
     public class IndexOutOfRangeFault
    {
        [System.Runtime.Serialization.DataMember]
        public string Issue { get; set; }
    }
}
