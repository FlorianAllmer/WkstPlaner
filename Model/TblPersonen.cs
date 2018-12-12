using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.Model
{
    public partial class TblPersonen
    {
        public TblPersonen()
        {
            TblLehrer = new HashSet<TblLehrer>();
            TblSchueler = new HashSet<TblSchueler>();
        }

        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Geschlecht { get; set; }

        public virtual ICollection<TblLehrer> TblLehrer { get; set; }
        public virtual ICollection<TblSchueler> TblSchueler { get; set; }
    }
}
