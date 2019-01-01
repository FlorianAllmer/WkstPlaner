using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.Model.tables
{
    public partial class TblLehrfachgruppen
    {
        public TblLehrfachgruppen()
        {
            TblKlassenLehrfachgruppen = new HashSet<TblKlassenLehrfachgruppen>();
            TblKlassenLehrfaecher = new HashSet<TblKlassenLehrfaecher>();
            TblLehrfachgruppenFaecher = new HashSet<TblLehrfachgruppenFaecher>();
        }

        public int Id { get; set; }
        public string Bezeichnung { get; set; }

        public virtual ICollection<TblKlassenLehrfachgruppen> TblKlassenLehrfachgruppen { get; set; }
        public virtual ICollection<TblKlassenLehrfaecher> TblKlassenLehrfaecher { get; set; }
        public virtual ICollection<TblLehrfachgruppenFaecher> TblLehrfachgruppenFaecher { get; set; }
    }
}
