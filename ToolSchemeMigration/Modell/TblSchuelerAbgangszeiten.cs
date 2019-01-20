using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.ToolSchemeMigration.Modell
{
    public partial class TblSchuelerAbgangszeiten
    {
        public TblSchuelerAbgangszeiten()
        {
            TblSchueler = new HashSet<TblSchueler>();
        }

        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public TimeSpan Abgang { get; set; }

        public virtual ICollection<TblSchueler> TblSchueler { get; set; }
    }
}
