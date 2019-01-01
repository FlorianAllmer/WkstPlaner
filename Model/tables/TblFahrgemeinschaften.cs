using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.Model.tables
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
