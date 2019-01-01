namespace HtlWeiz.WkstPlaner.Model.tables
{
    public partial class TblLehrfachgruppeSchuelerNoten
    {
        public int KlassenLehrfachgruppeId { get; set; }
        public string Schuelerkennzahl { get; set; }
        public string Note { get; set; }

        public virtual TblKlassenLehrfachgruppen KlassenLehrfachgruppe { get; set; }
        public virtual TblSchueler SchuelerkennzahlNavigation { get; set; }
    }
}
