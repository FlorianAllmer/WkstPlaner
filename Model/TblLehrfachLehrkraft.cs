using System;
using System.Collections.Generic;

namespace HtlWeiz.WkstPlaner.Model
{
    public partial class TblLehrfachLehrkraft
    {
        public string LehrfachKurzbezeichnung { get; set; }
        public string LehrerKurzzeichen { get; set; }

        public virtual TblLehrer LehrerKurzzeichenNavigation { get; set; }
        public virtual TblLehrfaecher LehrfachKurzbezeichnungNavigation { get; set; }
    }
}
