using System;
using System.Runtime.Serialization;

namespace HtlWeiz.WkstPlaner.Model.context
{
    [DataContract]
    internal class PocoSetings
    {
        [DataMember]
        internal string ConnectionString;
    }
}
