﻿using NLayer.Core.Entities;

namespace NLayer.Core.DTOs
{
    public class HesapTipiDto : BankAppBaseDto
    {
        public string Adi { get; set; }
        public List<HesapHesapTipiDto> HesapTipleri { get; set; }
    }
}
