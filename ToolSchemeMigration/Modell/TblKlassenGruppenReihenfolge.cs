using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.ToolSchemeMigration.Modell
{
    public partial class TblKlassenGruppenReihenfolge
    {
        public int KlasseId { get; set; }
        public byte Gruppe { get; set; }
        public int? Turnus { get; set; }

        public virtual TblKlassen Klasse { get; set; }
    }
}
