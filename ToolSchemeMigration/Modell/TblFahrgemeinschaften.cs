using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.ToolSchemeMigration.Modell
{
    public partial class TblFahrgemeinschaften
    {
        public TblFahrgemeinschaften()
        {
            TblLehrer = new HashSet<TblLehrer>();
        }

        public int Id { get; set; }
        public string Bezeichnung { get; set; }

        public virtual ICollection<TblLehrer> TblLehrer { get; set; }
    }
}
