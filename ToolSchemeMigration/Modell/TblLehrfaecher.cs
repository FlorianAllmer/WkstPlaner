using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.ToolSchemeMigration.Modell
{
    public partial class TblLehrfaecher
    {
        public TblLehrfaecher()
        {
            TblKlassenLehrfaecher = new HashSet<TblKlassenLehrfaecher>();
            TblLehrfachLehrkraft = new HashSet<TblLehrfachLehrkraft>();
            TblLehrfachgruppenFaecher = new HashSet<TblLehrfachgruppenFaecher>();
            TblRaumLehrfaecher = new HashSet<TblRaumLehrfaecher>();
        }

        public string Kurzbezeichnung { get; set; }
        public string Langbezeichnung { get; set; }
        public int WertigkeitId { get; set; }
        public string Kompetenzen { get; set; }
        public string Inhalt { get; set; }
        public int? Farbe { get; set; }

        public virtual TblLehrfachwertigkeiten Wertigkeit { get; set; }
        public virtual ICollection<TblKlassenLehrfaecher> TblKlassenLehrfaecher { get; set; }
        public virtual ICollection<TblLehrfachLehrkraft> TblLehrfachLehrkraft { get; set; }
        public virtual ICollection<TblLehrfachgruppenFaecher> TblLehrfachgruppenFaecher { get; set; }
        public virtual ICollection<TblRaumLehrfaecher> TblRaumLehrfaecher { get; set; }
    }
}
