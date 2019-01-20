using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.ToolSchemeMigration.Modell
{
    public partial class TblPerioden
    {
        public TblPerioden()
        {
            TblFreieTage = new HashSet<TblFreieTage>();
            TblSchuljahre = new HashSet<TblSchuljahre>();
        }

        public int Id { get; set; }
        public string Bezeichnung { get; set; }

        public virtual ICollection<TblFreieTage> TblFreieTage { get; set; }
        public virtual ICollection<TblSchuljahre> TblSchuljahre { get; set; }
    }
}
