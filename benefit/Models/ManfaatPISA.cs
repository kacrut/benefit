using System;
using System.Collections.Generic;

namespace benefit.Models
{
    public partial class ManfaatPISA
    {
        public ManfaatPISA()
        {
            this.InfoBenefitBUs = new List<InfoBenefitBU>();
        }

        public int ManfaatPISAID { get; set; }
        public string ManfaatPISAName { get; set; }
        public virtual ICollection<InfoBenefitBU> InfoBenefitBUs { get; set; }
    }
}
