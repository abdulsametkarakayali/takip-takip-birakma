using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Text.RegularExpressions;
using xNet;

namespace instagramlogin.BAL.VeriErisim
{

    internal class Giris
    {
        public static readonly HttpRequest http = new HttpRequest();
        public static readonly string url = "https://www.instagram.com/";
        public static string GKullaniciAdi;
        public static string userId;

        public static bool GirisYap(string KullaniciAdi, string Parola)
        {
           
            try
            {
                http.Cookies = new CookieDictionary();
                string html = http.Get(url).ToString();
                string token = Regex.Match(html, "\"csrf_token\":\"(.*?)\"").Groups[1].Value;

                http.AddHeader("X-CSRFToken", token);
                http.Referer = url;
                http.UserAgent = " MOBILE_USER_AGENT = 'Mozilla/5.0 (iPhone; CPU iPhone OS 9_1 like Mac OS X) '\'AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13B143 Safari/601.1'";

                html = http.Post("https://www.instagram.com/accounts/login/ajax/", "username=" + KullaniciAdi + "&password=" + Parola + "&queryParams={}", "application/x-www-form-urlencoded").ToString();
                GKullaniciAdi = KullaniciAdi;
                
                dynamic user = JObject.Parse(html.ToString());
                userId = user.userId;
                if (html.Contains("authenticated\": true"))
                {
                  
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Nesne.NIslemSonuc<Nesne.KullaniciBilgileri> KullaniciBilgileriniGetir()
        {
            try
            {


                string bilgiler = Giris.http.Get("https://www.instagram.com/accounts/login/?next=/api/v1/users/" + userId + "/info/").ToString();

                var urls = ("https://www.instagram.com/" + GKullaniciAdi + "/?__a=1").ToString();
                var bilgilerim = Giris.http.Get(urls).ToString();
                //HtmlWeb web = new HtmlWeb();

                //var htmlDoc = web.Load(urls);

                //var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");

                //Console.WriteLine("Node Name: " + node.Name + "\n" + node.OuterHtml);



                BAL.Nesne.KullaniciBilgileri kullanici = new Nesne.KullaniciBilgileri();

                var jsonbilgi = JObject.Parse(bilgilerim.ToString());
                dynamic   HesapBilgileriParcalama =JObject.Parse(jsonbilgi["graphql"].ToString());

                kullanici.KullaniciId = userId;
               
                kullanici.KullaniciAdi = HesapBilgileriParcalama.user.username;
                kullanici.IsimSoyIsim = HesapBilgileriParcalama.user.full_name;
                kullanici.Bioyografi = HesapBilgileriParcalama.user.biography;
                kullanici.Resim = HesapBilgileriParcalama.user.profile_pic_url;
                kullanici.TakipciSayisi = HesapBilgileriParcalama.user.edge_followed_by.count;
                kullanici.TakipSayisi = HesapBilgileriParcalama.user.edge_follow.count;
                kullanici.GonderiSayisi = HesapBilgileriParcalama.user.edge_owner_to_timeline_media.count;


                return new Nesne.NIslemSonuc<Nesne.KullaniciBilgileri>
                {
                    Basarilimi=true,
                    Veri=new Nesne.KullaniciBilgileri
                    {
                        KullaniciAdi=kullanici.KullaniciAdi,
                        Bioyografi=kullanici.Bioyografi,
                        GonderiSayisi=kullanici.GonderiSayisi,
                        IsimSoyIsim=kullanici.IsimSoyIsim,
                        KullaniciId=kullanici.KullaniciId,
                        TakipciSayisi=kullanici.TakipciSayisi,
                        TakipSayisi=kullanici.TakipSayisi,
                        Resim=kullanici.Resim
                    }
                };
            }
            catch (Exception hata)
            {
                return new Nesne.NIslemSonuc<Nesne.KullaniciBilgileri>
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


        public static string EvetHayir(bool Sorgu) 
        {
            if (Sorgu ==true)
            {
                return "evet";
            }
            else
            {
                return "hayir";
            }
        
        }

        public static Nesne.NIslemSonuc<Nesne.KullaniciBilgileri> TakipEdilecekBilgileri(string TakipciAdi)
        {
            try
            {

                string urlx = Giris.http.Get("https://www.instagram.com/web/search/topsearch/?context=blended&query="+TakipciAdi+"&rank_token=0.8792736141066984").ToString();

                dynamic HesapBilgileriParcalamax = JObject.Parse(urlx.ToString());
                var id = HesapBilgileriParcalamax.users[0].user.pk;


                var bilgilerx = ("https://www.instagram.com/" + TakipciAdi + "/?__a=1").ToString();

                 string takipedilecek = Giris.http.Get(bilgilerx).ToString();
                // string bilgiler = Giris.http.Get("https://i.instagram.com/api/v1/users/" + id + "/info/").ToString();
                BAL.Nesne.KullaniciBilgileri kullanici = new Nesne.KullaniciBilgileri();
                var jsonbilgit = JObject.Parse(takipedilecek.ToString());
                dynamic HesapBilgileriParcalamatakiedilen = JObject.Parse(jsonbilgit["graphql"].ToString());
                
               // kullanici.KullaniciId = HesapBilgileriParcalama.user.pk;
                kullanici.KullaniciAdi = HesapBilgileriParcalamatakiedilen.user.username;
                kullanici.IsimSoyIsim = HesapBilgileriParcalamatakiedilen.user.full_name;
                kullanici.Bioyografi = HesapBilgileriParcalamatakiedilen.user.biography;
                kullanici.Resim = HesapBilgileriParcalamatakiedilen.user.profile_pic_url;
                kullanici.TakipciSayisi = HesapBilgileriParcalamatakiedilen.user.edge_followed_by.count;
                kullanici.TakipSayisi = HesapBilgileriParcalamatakiedilen.user.edge_follow.count;
                kullanici.GonderiSayisi = HesapBilgileriParcalamatakiedilen.user.edge_owner_to_timeline_media.count;
                kullanici.KullaniciId = HesapBilgileriParcalamatakiedilen.user.id;
                
                kullanici.KullaniciProfiliGizlimi = HesapBilgileriParcalamatakiedilen.user.is_private;
               // kullanici.KullaniciSiziTakipEdiyormu = HesapBilgileriParcalama.user.follows_viewer;
                //kullanici.KullaniciyiSizTakipEdiyormusunuz = HesapBilgileriParcalama.user.followed_by_viewer;
                


                return new Nesne.NIslemSonuc<Nesne.KullaniciBilgileri>
                {
                    Basarilimi = true,
                    Veri = new Nesne.KullaniciBilgileri
                    {
                        KullaniciAdi = kullanici.KullaniciAdi,
                        Bioyografi = kullanici.Bioyografi,
                        GonderiSayisi = kullanici.GonderiSayisi,
                        IsimSoyIsim = kullanici.IsimSoyIsim,
                        KullaniciId = kullanici.KullaniciId,
                        TakipciSayisi = kullanici.TakipciSayisi,
                        TakipSayisi = kullanici.TakipSayisi,
                        Resim = kullanici.Resim,
                        KullaniciProfiliGizlimi=kullanici.KullaniciProfiliGizlimi,
                        KullaniciSiziTakipEdiyormu=kullanici.KullaniciSiziTakipEdiyormu,
                        KullaniciyiSizTakipEdiyormusunuz=kullanici.KullaniciyiSizTakipEdiyormusunuz
                       
                    }
                };
            }
            catch (Exception hata)
            {
                return new Nesne.NIslemSonuc<Nesne.KullaniciBilgileri>
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