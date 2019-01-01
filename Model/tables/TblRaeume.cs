using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.Model.tables
{
    public partial class TblRaeume
    {
        public TblRaeume()
        {
            TblKlassenLehrfaecher = new HashSet<TblKlassenLehrfaecher>();
            TblRaumLehrfaecher = new HashSet<TblRaumLehrfaecher>();
        }

        public string Raumnummer { get; set; }
        public string BezeichnungKurz { get; set; }
        public string BezeichnungLang { get; set; }
        public string Kustos1 { get; set; }
        public string Kustos2 { get; set; }

        public virtual TblLehrer Kustos1Navigation { get; set; }
        public virtual TblLehrer Kustos2Navigation { get; set; }
        public virtual ICollection<TblKlassenLehrfaecher> TblKlassenLehrfaecher { get; set; }
        public virtual ICollection<TblRaumLehrfaecher> TblRaumLehrfaecher { get; set; }
    }
}
