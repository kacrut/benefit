using System;
using System.Collections.Generic;

namespace benefit.Models
{
    public partial class vwInfoSettingBU
    {
        public int InfoSettingBUID { get; set; }
        public string KDKC { get; set; }
        public string NMKC { get; set; }
        public string NOMOR { get; set; }
        public string PKSKD { get; set; }
        public string PKSNM { get; set; }
        public string PolisPegawaiName { get; set; }
        public int PMaxAge { get; set; }
        public int PMinAge { get; set; }
        public int IMaxAge { get; set; }
        public int IMinAge { get; set; }
        public int SMaxAge { get; set; }
        public int SMinAge { get; set; }
        public int AMaxAge { get; set; }
        public int AMinAge { get; set; }
        public int MaxChild { get; set; }
        public string CaraBayarName { get; set; }
        public int Installment { get; set; }
    }
}
