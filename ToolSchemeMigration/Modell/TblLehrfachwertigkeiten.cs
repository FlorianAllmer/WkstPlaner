using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.ToolSchemeMigration.Modell
{
    public partial class TblLehrfachwertigkeiten
    {
        public TblLehrfachwertigkeiten()
        {
            TblLehrfaecher = new HashSet<TblLehrfaecher>();
        }

        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public double Werteinheit { get; set; }

        public virtual ICollection<TblLehrfaecher> TblLehrfaecher { get; set; }
    }
}
