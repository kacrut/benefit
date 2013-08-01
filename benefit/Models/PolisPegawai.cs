using System;
using System.Collections.Generic;

namespace benefit.Models
{
    public partial class PolisPegawai
    {
        public PolisPegawai()
        {
            this.InfoSettingBUs = new List<InfoSettingBU>();
        }

        public int PolisPegawaiID { get; set; }
        public string PolisPegawaiName { get; set; }
        public virtual ICollection<InfoSettingBU> InfoSettingBUs { get; set; }
    }
}
