using InnovaApp.DataAccess.Context;
using InnovaApp.Entities.Models;
using InnovaApp.Entities.Models.FideSiparis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace InnovaApp.DataAccess.Data.MotoServis
{
    public class MotoServisNetsisRepository : IDisposable
    {
        NetsisContext _context;
        UserRepository _userRepo;
        public MotoServisNetsisRepository()
        {
            _context = new NetsisContext();
            _userRepo = new UserRepository();
        }


        public List<DovizKur> DovizKurListe()
        {
            return _context.DovizKur.ToList();
        }

        public void PrBelgeKayitTeklif(string belgeNo, string cariKodu)
        {
            using (var context = new NetsisContext())
            {
                SqlParameter _belgeNo = new SqlParameter("@BelgeNo", belgeNo);
                SqlParameter _cariKodu = new SqlParameter("@CariKodu", cariKodu);
                context.Database.ExecuteSqlCommand("INN_PR_BELGE_KAYIT_TEKLIF @BelgeNo, @CariKodu, 'H', 'H'", _belgeNo, _cariKodu);
            }
        }

        public void PrBelgeKayitSiparis(string belgeNo, string cariKodu)
        {
            using (var context = new NetsisContext())
            {
                SqlParameter _belgeNo = new SqlParameter("@BelgeNo", belgeNo);
                SqlParameter _cariKodu = new SqlParameter("@CariKodu", cariKodu);
                context.Database.ExecuteSqlCommand("INN_PR_BELGE_KAYIT @BelgeNo, @CariKodu, '6', 'H'", _belgeNo, _cariKodu);
            }
        }

        public void PrBelgeKayitIrsaliye(string belgeNo, string cariKodu)
        {
            using (var context = new NetsisContext())
            {
                SqlParameter _belgeNo = new SqlParameter("@BelgeNo", belgeNo);
                SqlParameter _cariKodu = new SqlParameter("@CariKodu", cariKodu);
                context.Database.ExecuteSqlCommand("INN_PR_BELGE_KAYIT @BelgeNo, @CariKodu, '3', 'H'", _belgeNo, _cariKodu);
            }
        }
        


        public void PrTeklifOnayIptal(string belgeNo, char onayKodu)
        {
            using (var context = new NetsisContext())
            {
                SqlParameter _belgeNo = new SqlParameter("@fatirsNo", belgeNo);
                SqlParameter _onayKodu = new SqlParameter("@durum", onayKodu);
                context.Database.ExecuteSqlCommand("INN_PR_TEKLIF_ISLEM @fatirsNo, @durum", _belgeNo, _onayKodu);
            }
        }

        public List<TeklifBaslik> TeklifListe(DateTime tarih1, DateTime tarih2, string onayDurum,string cariKodu)
        {
            if (tarih1 == Convert.ToDateTime("01-01-0001 00:00:00"))
            {
                var val = _context.TeklifBaslik.Where(x => x.BelgeNo.Contains("W") && x.OnayDurum == "A" ).OrderByDescending(x => x.Tarih).ToList();
                var val1 = _context.TeklifBaslik.Where(x => x.BelgeNo.Contains("W") && x.OnayDurum != "A").Where(x => x.Tarih >= DateTime.Now.AddDays(-7) && x.Tarih <= DateTime.Now).OrderByDescending(x => x.Tarih).ToList();
                var val3 = val1.Union(val).ToList();
                return val3.ToList();
            }
            if (string.IsNullOrEmpty(onayDurum))
            {
                var val = _context.TeklifBaslik.Where(x => x.BelgeNo.Contains("W") && x.Tarih >= tarih1 && x.Tarih <= tarih2).OrderByDescending(x => x.Tarih);
                return val.ToList();
            }
            else
            {
                var val = _context.TeklifBaslik.Where(x => x.BelgeNo.Contains("W") && x.Tarih >= tarih1 && x.Tarih <= tarih2 && x.OnayDurum == onayDurum).OrderByDescending(x => x.Tarih);
                return val.ToList();
            }
        }

        public TeklifBaslik Teklif(string belgeNo)
        {
            var val = _context.TeklifBaslik.Where(x => x.BelgeNo == belgeNo).FirstOrDefault();
            return val;
            //return !string.IsNullOrEmpty(stokKodu)? _context.Stok.Where(x=>x.StokKodu== stokKodu).ToList(): _context.Stok.ToList();
        }

        public bool IrsaliyeSorgula(string irsaliyeNo)
        {
            var val = _context.Irsaliye.Where(x => x.BelgeNo == irsaliyeNo).FirstOrDefault();
            return val==null?false:true;
            //return !string.IsNullOrEmpty(stokKodu)? _context.Stok.Where(x=>x.StokKodu== stokKodu).ToList(): _context.Stok.ToList();
        }
        public List<TeklifDetay> TeklifDetayListe(string belgeNo)
        {
            var val = _context.TeklifDetay.Where(x => x.BelgeNo == belgeNo);
            return val.ToList();
            //return !string.IsNullOrEmpty(stokKodu)? _context.Stok.Where(x=>x.StokKodu== stokKodu).ToList(): _context.Stok.ToList();
        }

        public SiparisBaslik Siparis(string belgeNo)
        {
            var val = _context.SiparisBaslik.Where(x => x.BelgeNo == belgeNo).FirstOrDefault();
            return val;
            //return !string.IsNullOrEmpty(stokKodu)? _context.Stok.Where(x=>x.StokKodu== stokKodu).ToList(): _context.Stok.ToList();
        }

        public List<SiparisBaslik> SiparisListe(DateTime tarih1, DateTime tarih2, string onayDurum,string depo, string kullanici)
        {


            var sipDurumListe = SiparisDurumListe(tarih1, tarih2, onayDurum).OrderByDescending(x => x.Tarih).ToList();
            var sipDurumBelgeNoListe = sipDurumListe.Select(x => x.BelgeNo).ToList();

            

            var val = _context.SiparisBaslik.Where(x => sipDurumBelgeNoListe.Contains(x.BelgeNo)).OrderByDescending(x => x.Tarih).ToList();

            for (int i = 0; i < val.Count; i++)
            {
                val[i].OnayDurum = sipDurumListe[i].Durum.ToString();
            }

            if (depo == "000")
            {
                var users = _userRepo.UserList("");

                List<string> userList = new List<string>();




                foreach (var item in users)
                {
                    if (item.Depo.Length == 2 && item.Depo[1] != '0') continue;
                    else userList.Add(item.Kullanici);

                }

                return val.Where(x => userList.Contains(x.Plasiyer)).OrderByDescending(y => y.Tarih).OrderBy(x => x.OnayDurum).ToList();
            }
            else if (depo[0] == '0')
            {
                var users = _userRepo.UserList("");

                var userList1 = users.Where(x => x.Depo == (Convert.ToChar(depo[1]).ToString() + Convert.ToChar(depo[2]).ToString()));
                var userList2 = users.Where(x => x.Depo == depo);

                var userList3 = userList2.Union(userList1).Select(x => x.Kullanici).ToList();

                return val.Where(x => userList3.Contains(x.Plasiyer)).OrderByDescending(y => y.Tarih).OrderBy(x => x.OnayDurum).ToList();
            }
            else
            {
                return val.Where(x => x.Plasiyer == kullanici).OrderByDescending(y => y.Tarih).OrderBy(x => x.OnayDurum).ToList();
            }

        }

        public List<SiparisIrsaliyeDurum> SiparisDurumListe(DateTime tarih1, DateTime tarih2, string onayDurum)
        {

            if (tarih1 == Convert.ToDateTime("01-01-0001 00:00:00"))
            {
                var val = _context.SiparisIrsaliyeDurum.Where(x => x.Durum != Convert.ToChar("C")).OrderByDescending(x => x.Tarih).ToList();
                var val1 = _context.SiparisIrsaliyeDurum.Where(x => x.Durum == Convert.ToChar("C") && x.Tarih >= DateTime.Now.AddDays(-7) && x.Tarih <= DateTime.Now).OrderByDescending(x => x.Tarih).ToList();
                var val3 = val1.Union(val).ToList();
                return val3.ToList();
            }

            if (string.IsNullOrEmpty(onayDurum))
            {
                var val = _context.SiparisIrsaliyeDurum.Where(x => x.Tarih >= tarih1 && x.Tarih <= tarih2.AddDays(1)).OrderByDescending(x => x.Tarih);
                return val.ToList();
            }
            else
            {
                var val = _context.SiparisIrsaliyeDurum.Where(x => x.Tarih >= tarih1 && x.Tarih <= tarih2.AddDays(1) && x.Durum == Convert.ToChar(onayDurum)).OrderByDescending(x => x.Tarih);
                return val.ToList();
            }

            //return !string.IsNullOrEmpty(stokKodu)? _context.Stok.Where(x=>x.StokKodu== stokKodu).ToList(): _context.Stok.ToList();
        }

        public List<SiparisDetay> SiparisDetayListe(string belgeNo)
        {
            var val = _context.SiparisDetay.Where(x => x.BelgeNo == belgeNo);
            return val.ToList();
            //return !string.IsNullOrEmpty(stokKodu)? _context.Stok.Where(x=>x.StokKodu== stokKodu).ToList(): _context.Stok.ToList();
        }

        public Cari GetCariBilgi(string cKodu)
        {
            var val = _context.Cari.Where(x => x.CariKod == cKodu).FirstOrDefault();
            return val;
        }

        public IQueryable<BelgeKayit> GetTalepByBelgeNo(string belgeNo)
        {
            var context = new InnovaContext();
            var value = context.TalepKayit.Where(x => x.BelgeNo == belgeNo);

            return value;

        }

        public int SonBelgeId()
        {
            var context = new InnovaContext();
            var value = context.TalepKayit.LastOrDefault();

            return value != null ? value.Id : 0;

        }

        public void TalepKayit(BelgeKayit talepBelgesi)
        {
            using (var context = new InnovaContext())
            {
                context.Set<BelgeKayit>().Add(talepBelgesi);
                context.SaveChanges();
            }
        }
        public void TalepGuncelle(BelgeKayit talepBelgesi)
        {
            using (var context = new InnovaContext())
            {
                context.Entry(talepBelgesi).Property("Miktar").IsModified = true;
                context.Entry(talepBelgesi).Property("StokAdi").IsModified = true;
                context.Entry(talepBelgesi).Property("StokKodu").IsModified = true;
                context.Entry(talepBelgesi).Property("Birim").IsModified = true;


                context.SaveChanges();

                var tbl = GetTalepByBelgeNo(talepBelgesi.BelgeNo).ToList();
                foreach (var item in tbl)
                {
                    item.Aciklama = talepBelgesi.Aciklama;
                    context.Entry(item).Property("Aciklama").IsModified = true;
                }

                context.SaveChanges();

            }
        }
        public void TalepStokSil(int belgeId)
        {
            using (var context = new InnovaContext())
            {
                var belge = context.TalepKayit.Where(x => x.Id == belgeId).FirstOrDefault();
                context.Entry(belge).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            _userRepo.Dispose();
        }

        
    }
}
