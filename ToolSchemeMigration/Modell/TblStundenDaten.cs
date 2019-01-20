using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.ToolSchemeMigration.Modell
{
    public partial class TblStundenDaten
    {
        public TblStundenDaten()
        {
            TblStundenZuordnung = new HashSet<TblStundenZuordnung>();
        }

        public int Id { get; set; }
        public TimeSpan Start { get; set; }
        public int Dauer { get; set; }

        public virtual ICollection<TblStundenZuordnung> TblStundenZuordnung { get; set; }
    }
}
