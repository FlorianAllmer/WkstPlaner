using System.Runtime.Serialization;

namespace HtlWeiz.WkstPlaner.WkstPlanContext
{
    [DataContract]
    internal class PocoSetings
    {
        [DataMember]
        internal string ConnectionString;
    }
}
