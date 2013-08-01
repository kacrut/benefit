using System;
using System.Collections.Generic;

namespace benefit.Models
{
    public partial class FreqPeriode
    {
        public FreqPeriode()
        {
            this.InfoBenefitBUs = new List<InfoBenefitBU>();
        }

        public int FreqPeriodeID { get; set; }
        public string FreqPeriodeName { get; set; }
        public virtual ICollection<InfoBenefitBU> InfoBenefitBUs { get; set; }
    }
}
