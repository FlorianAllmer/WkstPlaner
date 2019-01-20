using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.ToolSchemeMigration.Modell
{
    public partial class TblKlassenSchueler
    {
        public int KlasseId { get; set; }
        public string Schuelerkennzahl { get; set; }
        public byte? Gruppe { get; set; }

        public virtual TblKlassen Klasse { get; set; }
        public virtual TblSchueler SchuelerkennzahlNavigation { get; set; }
    }
}
