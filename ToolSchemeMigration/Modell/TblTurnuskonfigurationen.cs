using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.ToolSchemeMigration.Modell
{
    public partial class TblTurnuskonfigurationen
    {
        public TblTurnuskonfigurationen()
        {
            TblKlassen = new HashSet<TblKlassen>();
            TblTurnusParameterwertezuordnungen = new HashSet<TblTurnusParameterwertezuordnungen>();
        }

        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public string BerechnungsFunktion { get; set; }

        public virtual ICollection<TblKlassen> TblKlassen { get; set; }
        public virtual ICollection<TblTurnusParameterwertezuordnungen> TblTurnusParameterwertezuordnungen { get; set; }
    }
}
