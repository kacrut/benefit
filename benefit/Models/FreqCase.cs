using System;
using System.Collections.Generic;

namespace benefit.Models
{
    public partial class FreqCase
    {
        public FreqCase()
        {
            this.InfoBenefitBUs = new List<InfoBenefitBU>();
        }

        public int FreqCaseID { get; set; }
        public string FreqCaseName { get; set; }
        public virtual ICollection<InfoBenefitBU> InfoBenefitBUs { get; set; }
    }
}
