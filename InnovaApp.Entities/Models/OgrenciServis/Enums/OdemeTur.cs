using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace InnovaApp.Entities.Models.OgrenciServis.Enums
{
    public enum OdemeTur : byte
    {
        [Description("Peşin")]
        Nakit = 1,
        [Description("Kredi Kartı")]
        KrediKart = 2,
        [Description("Havale/EFT")]
        Havale = 3,
        [Description("Vadeli")]
        Vadeli = 4

    }
}
