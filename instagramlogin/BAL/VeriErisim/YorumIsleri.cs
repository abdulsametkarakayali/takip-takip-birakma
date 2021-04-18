using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace instagramlogin.BAL.VeriErisim
{
   public class YorumIsleri
    {
       public static Nesne.NIslemSonuc<List<Nesne.MediaBilgileri>> YorumlariGetir(string KullaniciId)
       {
           try
           {
               string bilgiler = Giris.http.Get("https://www.instagram.com/graphql/query/?query_id=17888483320059182&variables={%22id%22:%22"+KullaniciId+"%22,%22first%22:299,%22after%22:%221%22}").ToString();

               dynamic HesapBilgileriParcalama = JObject.Parse(bilgiler.ToString());
              // int takipcisayisihesaplama = Int32.Parse(TakipciSayisi.ToString()) - 2;

               var x = HesapBilgileriParcalama.data.user.edge_owner_to_timeline_media.edges;

               var yorum = new List<Nesne.MediaBilgileri>();
               foreach (var item in x)
               {
                   if (item.node.edge_media_to_comment.count != "0")
                   {
                      
                       yorum.Add(new Nesne.MediaBilgileri()
                       {

                           MediaId = item.node.shortcode

                       });


                   }
               }
			  
                 
               

               return new Nesne.NIslemSonuc<List<Nesne.MediaBilgileri>>
               {
                   Basarilimi = true,
                   Veri = yorum
               };
           }
           catch (Exception hata)
           {
               return new Nesne.NIslemSonuc<List<Nesne.MediaBilgileri>>
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
