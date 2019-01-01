using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.Model.tables
{
    public partial class TblTurnusParameter
    {
        public TblTurnusParameter()
        {
            TblTurnusParameterwertezuordnungen = new HashSet<TblTurnusParameterwertezuordnungen>();
        }

        public int Id { get; set; }
        public string Bezeichnung { get; set; }

        public virtual ICollection<TblTurnusParameterwertezuordnungen> TblTurnusParameterwertezuordnungen { get; set; }
    }
}
