using System;
using System.Collections.Generic;

namespace benefit.Models
{
    public partial class InfoSettingBU
    {
        public int InfoSettingBUID { get; set; }
        public string POLIS { get; set; }
        public string PKSKD { get; set; }
        public int PolisPegawaiID { get; set; }
        public int PMaxAge { get; set; }
        public int PMinAge { get; set; }
        public int IMaxAge { get; set; }
        public int IMinAge { get; set; }
        public int SMaxAge { get; set; }
        public int SMinAge { get; set; }
        public int AMaxAge { get; set; }
        public int AMinAge { get; set; }
        public int MaxChild { get; set; }
        public int CaraBayarID { get; set; }
        public int Installment { get; set; }
        public virtual CaraBayar CaraBayar { get; set; }
        public virtual PolisPegawai PolisPegawai { get; set; }
    }
}
