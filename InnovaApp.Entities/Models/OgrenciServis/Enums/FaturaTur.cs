using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace InnovaApp.Entities.Models.OgrenciServis.Enums
{
    public enum FaturaTur : byte
    {
        [Description("Bireysel")]
        Bireysel = 1,
        [Description("Kurumsal")]
        Kurumsal = 2
        
    }
}
