using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using xNet;

namespace instagramlogin.BAL.VeriErisim
{
    public class TakipIslemleri
    {
        public static readonly HttpRequest http = new HttpRequest();
        public static readonly string url = "https://www.instagram.com/";
        public static string GKullaniciAdi;
        public static string userId;
        public static string sonraki;
        public static string takipettiklerimsonraki;
        public static Nesne.NIslemSonuc<List<Nesne.TakipciBilgileri>> TakipciListesiGetir(string KullaniciId, string TakipciSayisi)
        {
            try
            {
               
                if (sonraki != null)
                {
                    http.Cookies = new CookieDictionary();
                    string html = http.Get(url).ToString();
                    string token = Regex.Match(html, "\"csrf_token\":\"(.*?)\"").Groups[1].Value;

                    http.AddHeader("X-CSRFToken", token);
                    http.Referer = "https://www.instagram.com/";
                    http.UserAgent = " Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36";


                    var urlx = "https://www.instagram.com/graphql/query/?query_hash=37479f2b8209594dde7facb0d904896a&variables={%22id%22%3A%22" + KullaniciId + "%22%2C%22first%22:%2050,%20%22after%22:%20%22"+sonraki+"%22}";

                    var bilgiler = Giris.http.Get(urlx).ToString();




                    dynamic HesapBilgileriParcalama = JObject.Parse(bilgiler.ToString());
                    int takipcisayisihesaplama = Int32.Parse(TakipciSayisi.ToString()) - 2;
                    sonraki = HesapBilgileriParcalama.data.user.edge_followed_by.page_info.end_cursor;
                    var edges = HesapBilgileriParcalama.data.user.edge_followed_by.edges;

                    var kullanici = new List<Nesne.TakipciBilgileri>();
                    foreach (var item in edges)
                    {
                        if (item.node.followed_by_viewer == "false" && item.node.requested_by_viewer == "false")
                        {
                            kullanici.Add(new Nesne.TakipciBilgileri()
                            {
                                KullaniciId = item.node.id,
                                KullaniciAdi = item.node.username,
                                IsimSoyIsim = item.node.full_name,
                                Resim = item.node.Profile_pic_url,
                                KullaniciProfiliGizlimi = item.node.is_verified,
                                KullaniciSiziTakipEdiyormu = item.node.followed_by_viewer,
                                IstekGonderildimi = item.node.requested_by_viewer,
                            });
                           
                        }
                    }
                    return new Nesne.NIslemSonuc<List<Nesne.TakipciBilgileri>>
                    {
                        Basarilimi = true,
                        Veri = kullanici
                    };


                }
                else
                {
                    http.Cookies = new CookieDictionary();
                    string html = http.Get(url).ToString();
                    string token = Regex.Match(html, "\"csrf_token\":\"(.*?)\"").Groups[1].Value;

                    http.AddHeader("X-CSRFToken", token);
                    http.Referer = "https://www.instagram.com/";
                    http.UserAgent = " Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36";


                    var urlx = "https://www.instagram.com/graphql/query/?query_hash=37479f2b8209594dde7facb0d904896a&variables={%22id%22%3A%22" + KullaniciId + "%22%2C%22first%22%3A50}";

                    var bilgiler = Giris.http.Get(urlx).ToString();




                    dynamic HesapBilgileriParcalama = JObject.Parse(bilgiler.ToString());
                    int takipcisayisihesaplama = Int32.Parse(TakipciSayisi.ToString()) - 2;
                    sonraki = HesapBilgileriParcalama.data.user.edge_followed_by.page_info.end_cursor;
                    var edges = HesapBilgileriParcalama.data.user.edge_followed_by.edges;

                    var kullanici = new List<Nesne.TakipciBilgileri>();
                    foreach (var item in edges)
                    {
                        if (item.node.followed_by_viewer == "false" && item.node.requested_by_viewer == "false")
                        {
                            kullanici.Add(new Nesne.TakipciBilgileri()
                            {
                                KullaniciId = item.node.id,
                                KullaniciAdi = item.node.username,
                                IsimSoyIsim = item.node.full_name,
                                Resim = item.node.Profile_pic_url,
                                KullaniciProfiliGizlimi = item.node.is_verified,
                                KullaniciSiziTakipEdiyormu = item.node.followed_by_viewer,
                                IstekGonderildimi = item.node.requested_by_viewer,
                            });
                            

                        }
                       
                    }
                    return new Nesne.NIslemSonuc<List<Nesne.TakipciBilgileri>>
                    {
                        Basarilimi = true,
                        Veri = kullanici
                    };

                }
                
                
            }
            catch (Exception hata)
            {
                return new Nesne.NIslemSonuc<List<Nesne.TakipciBilgileri>>
                {
                    Basarilimi = false,
                    HataBilgi = new Nesne.NHata
                    {
                        Sinif = "KullaniciBilgileriniGetir",
                        Method = "Giris",
                        HataMesaj = "Giriste bir hata oluştu"
                    },
                    Mesaj = "Bir hata ile karşılaşıldı"
                };
            }
        }
        public static Nesne.NIslemSonuc<List<Nesne.TakipciBilgileri>> TakipEttiklerimListesi(string KullaniciId, string TakipciSayisi)
        {
            takipettiklerimsonraki = null;
            try
            {
                if (takipettiklerimsonraki !=null)
                {
                    string bilgiler = Giris.http.Get("https://www.instagram.com/graphql/query/?query_hash=58712303d941c6855d4e888c5f0cd22f&variables={%22id%22%3A%22" + KullaniciId + "%22%2C%22first%22%3A50%2C%22after%22%3A%22" + takipettiklerimsonraki + "%22%7D}").ToString();

                    dynamic HesapBilgileriParcalama = JObject.Parse(bilgiler.ToString());
                    int takipcisayisihesaplama = Int32.Parse(TakipciSayisi.ToString()) - 2;
                    takipettiklerimsonraki = HesapBilgileriParcalama.data.user.edge_follow.page_info.end_cursor;

                    var edges = HesapBilgileriParcalama.data.user.edge_follow.edges;

                    var kullanici = new List<Nesne.TakipciBilgileri>();
                    foreach (var item in edges)
                    {
                        if (item.node.followed_by_viewer == "true")
                        {

                            kullanici.Add(new Nesne.TakipciBilgileri()
                            {
                                KullaniciId = item.node.id,
                                KullaniciAdi = item.node.username,
                                IsimSoyIsim = item.node.full_name,
                                Resim = item.node.Profile_pic_url,
                                KullaniciProfiliGizlimi = item.node.is_verified,
                                KullaniciSiziTakipEdiyormu = item.node.followed_by_viewer,
                                IstekGonderildimi = item.node.requested_by_viewer,
                            });
                        }
                    }

                    return new Nesne.NIslemSonuc<List<Nesne.TakipciBilgileri>>
                    {
                        Basarilimi = true,
                        Veri = kullanici
                    };
                }
                else
                {
                    string bilgiler = Giris.http.Get("https://www.instagram.com/graphql/query/?query_hash=58712303d941c6855d4e888c5f0cd22f&variables={%22id%22%3A%22" + KullaniciId + "%22%2C%22first%22%3A50}").ToString();

                    dynamic HesapBilgileriParcalama = JObject.Parse(bilgiler.ToString());
                    int takipcisayisihesaplama = Int32.Parse(TakipciSayisi.ToString()) - 2;
                    takipettiklerimsonraki = HesapBilgileriParcalama.data.user.edge_follow.page_info.end_cursor;
                    var edges = HesapBilgileriParcalama.data.user.edge_follow.edges;

                    var kullanici = new List<Nesne.TakipciBilgileri>();
                    foreach (var item in edges)
                    {
                        if (item.node.followed_by_viewer == "true")
                        {

                            kullanici.Add(new Nesne.TakipciBilgileri()
                            {
                                KullaniciId = item.node.id,
                                KullaniciAdi = item.node.username,
                                IsimSoyIsim = item.node.full_name,
                                Resim = item.node.Profile_pic_url,
                                KullaniciProfiliGizlimi = item.node.is_verified,
                                KullaniciSiziTakipEdiyormu = item.node.followed_by_viewer,
                                IstekGonderildimi = item.node.requested_by_viewer,
                            });
                        }
                    }

                    return new Nesne.NIslemSonuc<List<Nesne.TakipciBilgileri>>
                    {
                        Basarilimi = true,
                        Veri = kullanici
                    };
                }
               
            }
            catch (Exception hata)
            {
                return new Nesne.NIslemSonuc<List<Nesne.TakipciBilgileri>>
                {
                    Basarilimi = false,
                    HataBilgi = new Nesne.NHata
                    {
                        Sinif = "KullaniciBilgileriniGetir",
                        Method = "Giris",
                        HataMesaj = "Giriste bir hata oluştu"
                    },
                    Mesaj = "Bir hata ile karşılaşıldı"
                };
            }
        }
    }
}