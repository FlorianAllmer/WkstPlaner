namespace HtlWeiz.WkstPlaner.Model.tables
{
    public partial class TblTurnusParameterwertezuordnungen
    {
        public int TurnuskonfigurationId { get; set; }
        public int TurnusparameterId { get; set; }
        public int WertId { get; set; }

        public virtual TblTurnuskonfigurationen Turnuskonfiguration { get; set; }
        public virtual TblTurnusParameter Turnusparameter { get; set; }
        public virtual TblTurnusParameterWerte Wert { get; set; }
    }
}
