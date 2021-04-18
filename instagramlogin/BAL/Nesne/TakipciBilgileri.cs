using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace instagramlogin.BAL.Nesne
{
    public class TakipciBilgileri
    {
        public string KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string IsimSoyIsim { get; set; }
        public string Resim { get; set; }
        public string KullaniciSiziTakipEdiyormu { get; set; }
        public string KullaniciyiSizTakipEdiyormusunuz { get; set; }
        public string KullaniciProfiliGizlimi { get; set; }
        public bool IstekGonderildimi { get; set; }
    }
}
