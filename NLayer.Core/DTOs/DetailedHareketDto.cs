﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class DetailedHareketDto
    {
        public int BankaId { get; set; }
        public string BankaAdi { get; set; }
        public int SubeId { get; set; }
        public string SubeAdi { get; set; }
        public int SubeTipiId { get; set; }
        public string SubeTipiAdi { get; set; }
        public int HesapId { get; set; }
        public string HesapKodu { get; set; }
        public List<HesapTipiDto> HesapTipleri { get; set; }
        public int HesapTipiId { get; set; }
        public string HesapTipiAdi { get; set; }
        public int DovizTipiId { get; set; }
        public string DovizTipiAdi { get; set; }
        public int MusteriId { get; set; }
        public string MusteriAdi { get; set; }
        public int LokasyonId { get; set; }
        public string LokasyonAdi { get; set; }
        public int HareketId { get; set; }
        public int HareketTipId { get; set; }
        public string HareketTipAdi { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
        public DateTime HareketTarihi { get; set; }
        public decimal Bakiye { get; set; }
    }
}
