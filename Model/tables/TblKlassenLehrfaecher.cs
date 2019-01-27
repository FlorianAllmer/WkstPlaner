using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.Model.tables
{
    public partial class TblKlassenLehrfaecher
    {
        public TblKlassenLehrfaecher()
        {
            TblLehrfachSchuelerNoten = new HashSet<TblLehrfachSchuelerNoten>();
        }

        public int Id { get; set; }
        public int KlasseId { get; set; }
        public string LehrfachKurzzeichen { get; set; }
        public int LehrfachgruppeId { get; set; }
        public int? LehreinheitId { get; set; }
        public string Raumnummer { get; set; }
        public string LehrerKurzzeichen { get; set; }

        public virtual TblKlassen Klasse { get; set; }
        public virtual TblLehreinheiten Lehreinheit { get; set; }
        public virtual TblLehrer LehrerKurzzeichenNavigation { get; set; }
        public virtual TblLehrfaecher LehrfachKurzzeichenNavigation { get; set; }
        public virtual TblLehrfachgruppen Lehrfachgruppe { get; set; }
        public virtual TblRaeume RaumnummerNavigation { get; set; }
        public virtual ICollection<TblLehrfachSchuelerNoten> TblLehrfachSchuelerNoten { get; set; }
    }
}
