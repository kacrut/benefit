using System;
using System.Collections.Generic;

namespace benefit.Models
{
    public partial class InfoBenefitBU
    {
        public int InfoBenefitBUID { get; set; }
        public string POLIS { get; set; }
        public string PKSKD { get; set; }
        public string KDPROD { get; set; }
        public int KDKLSRWT { get; set; }
        public int ManfaatInManfaatItemID { get; set; }
        public bool IsCaseLess { get; set; }
        public bool IsReimburse { get; set; }
        public decimal Amount { get; set; }
        public int ManfaatPISAID { get; set; }
        public int FreqCaseID { get; set; }
        public int FreqPeriodeID { get; set; }
        public int FreqCount { get; set; }
        public virtual FreqCase FreqCase { get; set; }
        public virtual FreqPeriode FreqPeriode { get; set; }
        public virtual ManfaatInManfaatItem ManfaatInManfaatItem { get; set; }
        public virtual ManfaatPISA ManfaatPISA { get; set; }
    }
}
