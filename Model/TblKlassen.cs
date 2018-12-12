using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.Model
{
    public partial class TblKlassen
    {
        public TblKlassen()
        {
            TblKlassenGruppenReihenfolge = new HashSet<TblKlassenGruppenReihenfolge>();
            TblKlassenLehrfachgruppen = new HashSet<TblKlassenLehrfachgruppen>();
            TblKlassenLehrfaecher = new HashSet<TblKlassenLehrfaecher>();
            TblKlassenSchueler = new HashSet<TblKlassenSchueler>();
        }

        public int Id { get; set; }
        public int SchuljahrId { get; set; }
        public string Bezeichnung { get; set; }
        public string Fachbereich { get; set; }
        public byte? Jahrgang { get; set; }
        public string Klassenvorstand { get; set; }
        public string WkstKlassenlehrer { get; set; }
        public int? TurnusKonfigurationId { get; set; }
        public int Gruppen { get; set; }

        public virtual TblLehrer KlassenvorstandNavigation { get; set; }
        public virtual TblSchuljahre Schuljahr { get; set; }
        public virtual TblTurnuskonfigurationen TurnusKonfiguration { get; set; }
        public virtual TblLehrer WkstKlassenlehrerNavigation { get; set; }
        public virtual ICollection<TblKlassenGruppenReihenfolge> TblKlassenGruppenReihenfolge { get; set; }
        public virtual ICollection<TblKlassenLehrfachgruppen> TblKlassenLehrfachgruppen { get; set; }
        public virtual ICollection<TblKlassenLehrfaecher> TblKlassenLehrfaecher { get; set; }
        public virtual ICollection<TblKlassenSchueler> TblKlassenSchueler { get; set; }
    }
}
