using System;
using System.Collections.Generic;

namespace benefit.Models
{
    public partial class ManfaatItem
    {
        public ManfaatItem()
        {
            this.ManfaatInManfaatItems = new List<ManfaatInManfaatItem>();
        }

        public int ManfaatItemID { get; set; }
        public string ManfaatItemName { get; set; }
        public virtual ICollection<ManfaatInManfaatItem> ManfaatInManfaatItems { get; set; }
    }
}
