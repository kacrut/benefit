using System;
using System.Collections.Generic;

namespace benefit.Models
{
    public partial class Manfaat
    {
        public Manfaat()
        {
            this.ManfaatInManfaatItems = new List<ManfaatInManfaatItem>();
        }

        public int ManfaatID { get; set; }
        public string NamaManfaat { get; set; }
        public virtual ICollection<ManfaatInManfaatItem> ManfaatInManfaatItems { get; set; }
    }
}
