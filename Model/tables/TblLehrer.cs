using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.Model.tables
{
    public partial class TblLehrer
    {
        public TblLehrer()
        {
            TblKlassenKlassenvorstandNavigation = new HashSet<TblKlassen>();
            TblKlassenLehrfachgruppen = new HashSet<TblKlassenLehrfachgruppen>();
            TblKlassenLehrfaecher = new HashSet<TblKlassenLehrfaecher>();
            TblKlassenWkstKlassenlehrerNavigation = new HashSet<TblKlassen>();
            TblLehrfachLehrkraft = new HashSet<TblLehrfachLehrkraft>();
            TblRaeumeKustos1Navigation = new HashSet<TblRaeume>();
            TblRaeumeKustos2Navigation = new HashSet<TblRaeume>();
        }

        public string Kurzzeichen { get; set; }
        public int PersonId { get; set; }
        public string Benutzername { get; set; }
        public string Ordner { get; set; }
        public int? FahrgemeinschaftId { get; set; }
        public int? Farbe { get; set; }

        public virtual TblFahrgemeinschaften Fahrgemeinschaft { get; set; }
        public virtual TblPersonen Person { get; set; }
        public virtual ICollection<TblKlassen> TblKlassenKlassenvorstandNavigation { get; set; }
        public virtual ICollection<TblKlassenLehrfachgruppen> TblKlassenLehrfachgruppen { get; set; }
        public virtual ICollection<TblKlassenLehrfaecher> TblKlassenLehrfaecher { get; set; }
        public virtual ICollection<TblKlassen> TblKlassenWkstKlassenlehrerNavigation { get; set; }
        public virtual ICollection<TblLehrfachLehrkraft> TblLehrfachLehrkraft { get; set; }
        public virtual ICollection<TblRaeume> TblRaeumeKustos1Navigation { get; set; }
        public virtual ICollection<TblRaeume> TblRaeumeKustos2Navigation { get; set; }
    }
}
