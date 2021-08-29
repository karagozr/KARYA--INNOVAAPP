﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.FideSiparis.Innova
{
    [Table("TBLBELGE_KAYIT")]
    public class BelgeKayit
    {
        [Key]
        [Column("GUIDID")]
        public string Guid { get; set; }

        [Column("BELGE_NO")]
        public string BelgeNo { get; set; }

        [Column("SIPARIS_NO")]
        public string SiparisNo { get; set; }

        [Column("TARIH")]
        public DateTime Tarih { get; set; }

        [Column("SIRA")]
        public int Sira { get; set; }

        [Column("SIPARIS_SIRASI")]
        public int SiparisSira { get; set; }

        [Column("AKTARIM")]
        public int Aktarim { get; set; }

        [Column("FTIRSIP")]
        public string FtirSip { get; set; }

        [Column("CARI_KODU")]
        public string CariKodu { get; set; }

        [Column("CARI_ADI")]
        public string CariAdi { get; set; }

        [Column("SIPARIS_TARIHI")]
        public DateTime? SiparisTarih { get; set; }

        [Column("IRSALIYE_TARIHI")]
        public DateTime? IrsaliyeTarih { get; set; }

        [Column("UST_ACIKLAMA1")]
        public string Aciklama { get; set; }

        [Column("UST_ACIKLAMA2")]
        public string Aciklama2 { get; set; }

        [Column("UST_ACIKLAMA3")]
        public string Aciklama3 { get; set; }

        [Column("UST_ACIKLAMA4")]
        public string Aciklama4 { get; set; }

        [Column("UST_ACIKLAMA5")]
        public string Aciklama5 { get; set; }

        [Column("UST_ACIKLAMA6")]
        public string Aciklama6 { get; set; }

        [Column("UST_ACIKLAMA7")]
        public string Aciklama7 { get; set; }

        [Column("UST_ACIKLAMA8")]
        public string Aciklama8 { get; set; }

        [Column("UST_ACIKLAMA9")]
        public string Aciklama9 { get; set; }

        [Column("UST_ACIKLAMA10")]
        public string Aciklama10 { get; set; }

        [Column("UST_ACIKLAMA11")]
        public string Aciklama11 { get; set; }

        [Column("UST_ACIKLAMA12")]
        public string Aciklama12 { get; set; }

        [Column("UST_ACIKLAMA13")]
        public string Aciklama13 { get; set; }

        [Column("UST_ACIKLAMA14")]
        public string Aciklama14 { get; set; }

        [Column("UST_ACIKLAMA15")]
        public string Aciklama15 { get; set; }

        [Column("UST_ACIKLAMA16")]
        public string Aciklama16 { get; set; }

        [Column("STOK_KODU")]
        public string StokKodu { get; set; }

        [Column("STOK_ADI")]
        public string StokAdi { get; set; }

        [Column("BIRIM")]
        public string Birim { get; set; }

        [Column("MIKTAR")]
        public decimal Miktar { get; set; }

        [Column("DOVIZ_TIPI")]
        public string Doviz { get; set; }

        [Column("DOVIZ_KUR")]
        public decimal Kur { get; set; }

        [Column("KALEM_ACIKLAMA1")]
        public string  KalemAciklama { get; set; }

        [Column("FIYAT")]
        public decimal BirimTutar { get; set; }

        [Column("DOVIZ_FIYAT")]
        public decimal BirimTutarDoviz { get; set; }

        [Column("TUTAR")]
        public decimal ToplamTutar { get; set; }

        [Column("DOVIZ_TUTAR")]
        public decimal ToplamTutarDoviz { get; set; }

        [Column("KAYIT_KULLANICI")]
        public string KayitKullaniciAdi { get; set; }

        [Column("KAYIT_KULLANICI_ID")]
        public int KayitKullaniciId { get; set; }

        [Column("DEPO_KODU")]
        public int DepoKodu { get; set; }

    }
}
