using System;
using System.Collections.Generic;

namespace benefit.Models
{
    public partial class CaraBayar
    {
        public CaraBayar()
        {
            this.InfoSettingBUs = new List<InfoSettingBU>();
        }

        public int CaraBayarID { get; set; }
        public string CaraBayarName { get; set; }
        public virtual ICollection<InfoSettingBU> InfoSettingBUs { get; set; }
    }
}
