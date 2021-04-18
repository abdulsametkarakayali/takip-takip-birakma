using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace instagramlogin.BAL.Nesne
{
  public class KullaniciBilgileri
    {
        public string KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string IsimSoyIsim { get; set; }
        public string Bioyografi { get; set; }
        public string Resim { get; set; }
        public string GonderiSayisi { get; set; }
        public string TakipciSayisi { get; set; }
        public string TakipSayisi { get; set; }
        public bool KullaniciSiziTakipEdiyormu { get; set; }
        public bool KullaniciyiSizTakipEdiyormusunuz { get; set; }
        public bool KullaniciProfiliGizlimi { get; set; }
    }
}
