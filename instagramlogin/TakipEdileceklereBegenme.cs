using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace instagramlogin
{
    public partial class TakipEdileceklereBegenme : Form
    {
        public static readonly string url = "https://www.instagram.com/";
        public int Sure;
        public int Sayac;

        public TakipEdileceklereBegenme()
        {
            InitializeComponent();
        }

        private void btnBegen_Click(object sender, EventArgs e)
        {
        }

        private void TakipEdileceklereBegenme_Load(object sender, EventArgs e)
        {
            var KullaniciBilgileri = BAL.VeriErisim.Giris.KullaniciBilgileriniGetir();
            txtKullaniciBilgileri.Text = KullaniciBilgileri.Veri.IsimSoyIsim;
            lblGonderiSayisi.Text = KullaniciBilgileri.Veri.GonderiSayisi;
            lblTakipci.Text = KullaniciBilgileri.Veri.TakipciSayisi;
            lblTakipEdilen.Text = KullaniciBilgileri.Veri.TakipSayisi;
            profilResmi.ImageLocation = KullaniciBilgileri.Veri.Resim;

            this.Text = "Kullanıcıyı Takip Edenleri Takip Et :" + KullaniciBilgileri.Veri.IsimSoyIsim;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sonuclar = BAL.VeriErisim.Giris.TakipEdilecekBilgileri(txtTakipEdilecek.Text);
            imgKullaniciResim.ImageLocation = sonuclar.Veri.Resim;
            lblKullaniciTakipci.Text = sonuclar.Veri.TakipciSayisi;
            lblKullaniciTakip.Text = sonuclar.Veri.TakipSayisi;

            txtTakipEdilenId.Text = sonuclar.Veri.KullaniciId;
            lblKullaniciGonderi.Text = sonuclar.Veri.GonderiSayisi;
            lblKullaniciyiTakip.Text = BAL.VeriErisim.Giris.EvetHayir(sonuclar.Veri.KullaniciyiSizTakipEdiyormusunuz);
            lblKullaniciProfili.Text = BAL.VeriErisim.Giris.EvetHayir(sonuclar.Veri.KullaniciProfiliGizlimi);
            lblKullaniciSiziTakip.Text = BAL.VeriErisim.Giris.EvetHayir(sonuclar.Veri.KullaniciSiziTakipEdiyormu);
        }

        private void btnTakipBegen_Click(object sender, EventArgs e)
        {
          //  lstIslemler.Items.Add(DateTime.Now + "İnstagram Login Programı Başlatıldı.");
            

            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var sonuclar = BAL.VeriErisim.TakipIslemleri.TakipciListesiGetir(txtTakipEdilenId.Text, lblKullaniciTakipci.Text);
            if (sonuclar.Veri == null)
            {
                MessageBox.Show("Verileri Çekerken Bir Sorun Oluştu");
            }
            else
            {
                try
                {
                    foreach (var item in sonuclar.Veri)
                    {

                        var sonuclari = BAL.VeriErisim.YorumIsleri.YorumlariGetir(item.KullaniciId);
                        if (sonuclari.Veri.Count > 0 || sonuclar.Veri == null)
                        {
                            List<BAL.Nesne.Person> masterList = new List<BAL.Nesne.Person>();

                            for (int i = 0; i < 2; i++)
                            {
                                 
                                    Random rastgele = new Random();

                                    Sure = rastgele.Next(10000, 30000);
                                

                                System.Threading.Thread.Sleep(Sure);

                                string urlPost = "https://www.instagram.com/web/likes/" + sonuclari.Veri[i].MediaId + "/like/";
                                
                                string html = BAL.VeriErisim.Giris.http.Get(url).ToString();

                                string token = Regex.Match(html, "\"csrf_token\":\"(.*?)\"").Groups[1].Value;

                                BAL.VeriErisim.Giris.http.Referer = url;
                                BAL.VeriErisim.Giris.http.AddHeader("X-CSRFToken", token);

                                html = BAL.VeriErisim.Giris.http.Post(urlPost, "Content-Length: 0", "application/json").ToString();
                                if (html.Contains("status\": \"ok") && html.Contains("result\": \"following"))
                                {
                                    lstIslemler.Items.Add(DateTime.Now + " <--- Takip Ediliyor ---> " + item.KullaniciAdi);
                                    lstIslemler.Refresh();
                                    lstIslemler.SelectedIndex = lstIslemler.Items.Count - 1;
                                   
                                }
                                else if ((html.Contains("status\": \"ok") && html.Contains("result\": \"requested")))
                                {
                                    lstIslemler.Items.Add(DateTime.Now + "<--- Takip İsteği Gönderildi ---> " + item.KullaniciAdi);
                                    lstIslemler.Refresh();

                                    lstIslemler.SelectedIndex = lstIslemler.Items.Count - 1;
                                    
                                }
                                else
                                {
                                    lstIslemler.Items.Add(html.ToString() + " <--- Takip İşlemi Sorun Oluştu ---> " + DateTime.Now);
                                    lstIslemler.Refresh();
                                    lstIslemler.SelectedIndex = lstIslemler.Items.Count - 1;
                                    lstIslemler.SetSelected(lstIslemler.Items.Count - 1, false);
                                    Environment.Exit(0);
                                }
                            }
                        }
                    }
                    //

                    //lstIslemler.Items.Add(" <--- Takip İşlemi Tamamlandı. ---> " + DateTime.Now);
                    //lstIslemler.SelectedIndex = lstIslemler.Items.Count - 1;
                }
                catch (Exception hata)
                {
                    //lstIslemler.Items.Add("Bir Sorun Oluştu." + hata.Message);
                    //System.Threading.Thread.Sleep(60000);
                }
            }
        }
    }
}