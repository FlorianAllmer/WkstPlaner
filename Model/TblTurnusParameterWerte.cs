using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.Model
{
    public partial class TblTurnusParameterWerte
    {
        public TblTurnusParameterWerte()
        {
            TblTurnusParameterwertezuordnungen = new HashSet<TblTurnusParameterwertezuordnungen>();
        }

        public int Id { get; set; }
        public string Wert { get; set; }

        public virtual ICollection<TblTurnusParameterwertezuordnungen> TblTurnusParameterwertezuordnungen { get; set; }
    }
}
