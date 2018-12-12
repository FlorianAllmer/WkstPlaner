using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.Model
{
    public partial class TblFreieTage
    {
        public int SchuljahrId { get; set; }
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public DateTime Anfang { get; set; }
        public DateTime Ende { get; set; }

        public virtual TblSchuljahre Schuljahr { get; set; }
    }
}
