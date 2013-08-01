using System;
using System.Collections.Generic;

namespace benefit.Models
{
    public partial class vwInfoBenefit
    {
        public int infoBenefitBUID { get; set; }
        public string KDKC { get; set; }
        public string NMKC { get; set; }
        public string POLIS { get; set; }
        public string PKSKD { get; set; }
        public string PKSNM { get; set; }
        public string PKSTGLML { get; set; }
        public string PKSTGLAKH { get; set; }
        public string NMPROD { get; set; }
        public string NMKLSRWT { get; set; }
        public string MANFAAT { get; set; }
        public string NamaManfaat { get; set; }
        public string ManfaatItemName { get; set; }
        public string IsCaseLess { get; set; }
        public string IsReimburse { get; set; }
        public string Amount { get; set; }
        public string ManfaatPISAName { get; set; }
        public string FreqCaseName { get; set; }
        public string FreqPeriodeName { get; set; }
        public int FreqCount { get; set; }
    }
}
