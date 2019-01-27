using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.Model.tables
{
    public partial class TblSchueler
    {
        public TblSchueler()
        {
            TblKlassenSchueler = new HashSet<TblKlassenSchueler>();
            TblLehrfachSchuelerNoten = new HashSet<TblLehrfachSchuelerNoten>();
            TblLehrfachgruppeSchuelerNoten = new HashSet<TblLehrfachgruppeSchuelerNoten>();
        }

        public string Kennzahl { get; set; }
        public int PersonId { get; set; }
        public int? AbgangszeitId { get; set; }

        public virtual TblSchuelerAbgangszeiten Abgangszeit { get; set; }
        public virtual TblPersonen Person { get; set; }
        public virtual ICollection<TblKlassenSchueler> TblKlassenSchueler { get; set; }
        public virtual ICollection<TblLehrfachSchuelerNoten> TblLehrfachSchuelerNoten { get; set; }
        public virtual ICollection<TblLehrfachgruppeSchuelerNoten> TblLehrfachgruppeSchuelerNoten { get; set; }
    }
}
