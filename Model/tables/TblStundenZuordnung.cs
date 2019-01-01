namespace HtlWeiz.WkstPlaner.Model.tables
{
    public partial class TblStundenZuordnung
    {
        public int StundentabelleId { get; set; }
        public int StundenDatenId { get; set; }

        public virtual TblStundenDaten StundenDaten { get; set; }
        public virtual TblStundenTabellen Stundentabelle { get; set; }
    }
}
