namespace HtlWeiz.WkstPlaner.Model.tables
{
    public partial class TblLehrfachLehrkraft
    {
        public string LehrfachKurzbezeichnung { get; set; }
        public string LehrerKurzzeichen { get; set; }

        public virtual TblLehrer LehrerKurzzeichenNavigation { get; set; }
        public virtual TblLehrfaecher LehrfachKurzbezeichnungNavigation { get; set; }
    }
}
