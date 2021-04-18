using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace instagramlogin
{
    public partial class KullaniciyiTakipEdenler : Form
    {
        public static readonly string url = "https://www.instagram.com/";
        public int Sure;
        public int Sayac;

        public KullaniciyiTakipEdenler()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void KullaniciyiTakipEdenler_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            var KullaniciBilgileri = BAL.VeriErisim.Giris.KullaniciBilgileriniGetir();
            txtKullaniciBilgileri.Text = KullaniciBilgileri.Veri.KullaniciAdi;
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

        private void button2_Click(object sender, EventArgs e)
        {
            lstIslemler.Items.Add(DateTime.Now + "İnstagram Login Programı Başlatıldı.");
            lstIslemler.Refresh();
            button2.Visible = false;
            btndurdur.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void btndurdur_Click(object sender, EventArgs e)
        {
            backgroundWorker1.WorkerSupportsCancellation = true;
            lstIslemler.Items.Add("<---- İşlem Tarafınızca Durduruldu ---->");
            button2.Visible = true;
            btndurdur.Visible = false;
        }
        int sayac;
        

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int TakipSayisi = 0;
            int IstekSayisi = 0;
                try
                {
                    Bastanbasla:
                      var sonuclar = BAL.VeriErisim.TakipIslemleri.TakipciListesiGetir(txtTakipEdilenId.Text, lblKullaniciTakipci.Text);
                    if (sonuclar.Veri == null)
                    {
                        MessageBox.Show("Verileri Çekerken Bir Sorun Oluştu");
                    }
                    else
                    {
                            foreach (var item in sonuclar.Veri)
                    {
                        if (item.IstekGonderildimi == false)
                        {
                            int i = 0;
                            i++;
                            if (i % 50 == 0)
                            {
                                Sure = 180000;
                            }
                            else
                            {
                                Random rastgele = new Random();

                                Sure = rastgele.Next(Convert.ToInt32(txtsurebas.Text)*1000, Convert.ToInt32(txtsureson.Text)*1000);
                                
                                lblSure.Text=Convert.ToString( Sure / 1000);
                            }

                            System.Threading.Thread.Sleep(Sure);

                            string urlPost = "https://www.instagram.com/web/friendships/" + item.KullaniciId + "/follow/";
                            BAL.VeriErisim.Giris.http.ConnectTimeout = 1000;
                            string html = BAL.VeriErisim.Giris.http.Get(url).ToString();

                            string token = Regex.Match(html, "\"csrf_token\":\"(.*?)\"").Groups[1].Value;

                            BAL.VeriErisim.Giris.http.Referer = url;
                            BAL.VeriErisim.Giris.http.AddHeader("X-CSRFToken", token);
                            BAL.VeriErisim.Giris.http.AddHeader("X-Requested-With", "XMLHttpRequest");
                            BAL.VeriErisim.Giris.http.AddHeader("X-Instagram-AJAX", "1");
                            html = BAL.VeriErisim.Giris.http.Post(urlPost, "Content-Length: 0", "application/json").ToString();
                            if (html.Contains("status\": \"ok") && html.Contains("result\": \"following"))
                            {
                                lstIslemler.Items.Add(DateTime.Now + " <--- Takip Ediliyor ---> " + item.KullaniciAdi);
                                lstIslemler.Refresh();
                                TakipSayisi = TakipSayisi + 1;
                                lblTakipSayisi.Text = TakipSayisi.ToString();
                                lstIslemler.SelectedIndex = lstIslemler.Items.Count - 1;
                                lstIslemler.SetSelected(lstIslemler.Items.Count - 1, false);
                            }
                            else if ((html.Contains("status\": \"ok") && html.Contains("result\": \"requested")))
                            {
                                lstIslemler.Items.Add(DateTime.Now + "<--- Takip İsteği Gönderildi ---> " + item.KullaniciAdi);
                                lstIslemler.Refresh();
                                IstekSayisi = IstekSayisi + 1;
                                lblIstekSayisi.Text = IstekSayisi.ToString();
                                lstIslemler.SelectedIndex = lstIslemler.Items.Count - 1;
                                lstIslemler.SetSelected(lstIslemler.Items.Count - 1, false);
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
                    lstIslemler.Items.Add(" <--- Takip İşlemi Tamamlandı. ---> " + DateTime.Now);
                    lstIslemler.SelectedIndex = lstIslemler.Items.Count - 1;
                    lstIslemler.SetSelected(lstIslemler.Items.Count - 1, false);
                    goto Bastanbasla;
                }}
                catch (Exception hata)
                {
                    lstIslemler.Items.Add("Bir Sorun Oluştu." + hata.Message);
                    System.Threading.Thread.Sleep(60000);
                }
            }
        }
}