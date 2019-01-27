using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.Model.tables
{
    public partial class TblLehreinheiten
    {
        public TblLehreinheiten()
        {
            TblKlassenLehrfaecher = new HashSet<TblKlassenLehrfaecher>();
        }

        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public int? StundenTabelleId { get; set; }
        public byte? Tag { get; set; }
        public byte? StundeStart { get; set; }
        public byte? AnzahlStunden { get; set; }

        public virtual TblStundenTabellen StundenTabelle { get; set; }
        public virtual ICollection<TblKlassenLehrfaecher> TblKlassenLehrfaecher { get; set; }
    }
}
