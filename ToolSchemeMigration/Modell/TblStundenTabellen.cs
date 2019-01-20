using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.ToolSchemeMigration.Modell
{
    public partial class TblStundenTabellen
    {
        public TblStundenTabellen()
        {
            TblLehreinheiten = new HashSet<TblLehreinheiten>();
            TblStundenZuordnung = new HashSet<TblStundenZuordnung>();
        }

        public int Id { get; set; }
        public string Bezeichnung { get; set; }

        public virtual ICollection<TblLehreinheiten> TblLehreinheiten { get; set; }
        public virtual ICollection<TblStundenZuordnung> TblStundenZuordnung { get; set; }
    }
}
