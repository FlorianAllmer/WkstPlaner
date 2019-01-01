namespace HtlWeiz.WkstPlaner.Model.tables
{
    public partial class TblLehrfachgruppenFaecher
    {
        public int LehrfachgrupppenId { get; set; }
        public string LehrfachKurzzeichen { get; set; }

        public virtual TblLehrfaecher LehrfachKurzzeichenNavigation { get; set; }
        public virtual TblLehrfachgruppen Lehrfachgrupppen { get; set; }
    }
}
