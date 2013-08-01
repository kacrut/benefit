using System;
using System.Collections.Generic;

namespace benefit.Models
{
    public partial class ManfaatInManfaatItem
    {
        public ManfaatInManfaatItem()
        {
            this.InfoBenefitBUs = new List<InfoBenefitBU>();
        }

        public int ManfaatInManfaatItemID { get; set; }
        public int ManfaatID { get; set; }
        public int ManfaatItemID { get; set; }
        public virtual ICollection<InfoBenefitBU> InfoBenefitBUs { get; set; }
        public virtual Manfaat Manfaat { get; set; }
        public virtual ManfaatItem ManfaatItem { get; set; }
    }
}
