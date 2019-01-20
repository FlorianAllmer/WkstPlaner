using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.ToolSchemeMigration.Modell
{
    public partial class TblSchuljahre
    {
        public TblSchuljahre()
        {
            TblKlassen = new HashSet<TblKlassen>();
        }

        public int Id { get; set; }
        public int? PeriodeId { get; set; }
        public string Bezeichnung { get; set; }
        public DateTime Start { get; set; }
        public DateTime Ende { get; set; }

        public virtual TblPerioden Periode { get; set; }
        public virtual ICollection<TblKlassen> TblKlassen { get; set; }
    }
}
