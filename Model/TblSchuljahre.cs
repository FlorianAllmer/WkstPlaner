using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.Model
{
    public partial class TblSchuljahre
    {
        public TblSchuljahre()
        {
            TblFreieTage = new HashSet<TblFreieTage>();
            TblKlassen = new HashSet<TblKlassen>();
        }

        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public DateTime Start { get; set; }
        public DateTime Ende { get; set; }
        public DateTime? StartFachschule { get; set; }
        public DateTime? EndeMatura { get; set; }

        public virtual ICollection<TblFreieTage> TblFreieTage { get; set; }
        public virtual ICollection<TblKlassen> TblKlassen { get; set; }
    }
}
