using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.Model
{
    public partial class TblKlassenLehrfachgruppen
    {
        public TblKlassenLehrfachgruppen()
        {
            TblLehrfachgruppeSchuelerNoten = new HashSet<TblLehrfachgruppeSchuelerNoten>();
        }

        public int Id { get; set; }
        public int KlasseId { get; set; }
        public int LehrfachgrupppenId { get; set; }
        public string LehrerKurzzeichen { get; set; }

        public virtual TblKlassen Klasse { get; set; }
        public virtual TblLehrer LehrerKurzzeichenNavigation { get; set; }
        public virtual TblLehrfachgruppen Lehrfachgrupppen { get; set; }
        public virtual ICollection<TblLehrfachgruppeSchuelerNoten> TblLehrfachgruppeSchuelerNoten { get; set; }
    }
}
