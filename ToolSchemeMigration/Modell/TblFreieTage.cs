using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.ToolSchemeMigration.Modell
{
    public partial class TblFreieTage
    {
        public int PeriodeId { get; set; }
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public DateTime Anfang { get; set; }
        public DateTime Ende { get; set; }

        public virtual TblPerioden Periode { get; set; }
    }
}
