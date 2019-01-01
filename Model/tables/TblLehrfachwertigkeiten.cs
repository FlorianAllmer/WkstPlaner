using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.Model.tables
{
    public partial class TblLehrfachwertigkeiten
    {
        public TblLehrfachwertigkeiten()
        {
            TblLehrfaecher = new HashSet<TblLehrfaecher>();
        }

        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public double Werteinheit { get; set; }

        public virtual ICollection<TblLehrfaecher> TblLehrfaecher { get; set; }
    }
}
