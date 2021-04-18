using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using xNet;

namespace instagramlogin
{
    public partial class btnTakipBirak : Form
    {
        public static readonly string url = "https://www.instagram.com/";
        public int Sure;
        public int Say;

        public btnTakipBirak()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstTakipBirak.Items.Add(DateTime.Now + "İnstagram Login Programı Başlatıldı.");
            lstTakipBirak.Refresh();
            backgroundWorker1.RunWorkerAsync();
        }

        private void btnTakipBirak_Load(object sender, EventArgs e)
        {
            var KullaniciBilgileri = BAL.VeriErisim.Giris.KullaniciBilgileriniGetir();
            txtKullaniciBilgileri.Text = KullaniciBilgileri.Veri.IsimSoyIsim;
            lblGonderiSayisi.Text = KullaniciBilgileri.Veri.GonderiSayisi;
            lblTakipci.Text = KullaniciBilgileri.Veri.TakipciSayisi;
            lblTakipEdilen.Text = KullaniciBilgileri.Veri.TakipSayisi;
            profilResmi.ImageLocation = KullaniciBilgileri.Veri.Resim;
            lblId.Text = KullaniciBilgileri.Veri.KullaniciId;
        }





        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Takipbirakma:
            Takipdongu:
            string name;
            int i = 0;
            var bilgilerim = BAL.VeriErisim.Giris.KullaniciBilgileriniGetir();
            var kullanici = bilgilerim.Veri.KullaniciId;
            var sonuclar = BAL.VeriErisim.TakipIslemleri.TakipEttiklerimListesi(lblId.Text, "1000");
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
                        if (true)
                        {
                            
                            i++;

                            if (i % 50 == 0)
                            {
                                 Sure = 60*3;
                            }
                             
                            else
                            {
                                Random rastgele = new Random();
                                Sure = rastgele.Next(Convert.ToInt32(txtilksure.Text), Convert.ToInt32(txtsonsure.Text));
                            }
                            System.Threading.Thread.Sleep(Sure*1000);
                            this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate() { lbltakipcikan.Text = i.ToString(); });
                            string urlPost = "https://www.instagram.com/web/friendships/" + item.KullaniciId + "/unfollow/";
                          
                            string html = BAL.VeriErisim.Giris.http.Get(url).ToString();
                            string token = Regex.Match(html, "\"csrf_token\":\"(.*?)\"").Groups[1].Value;
                            BAL.VeriErisim.Giris.http.Referer = url;
                         
                            BAL.VeriErisim.Giris.http.AddHeader("X-CSRFToken", token);
                            BAL.VeriErisim.Giris.http.AddHeader("X-Requested-With", "XMLHttpRequest");
                            BAL.VeriErisim.Giris.http.AddHeader("X-Instagram-AJAX", "1");
                            html = BAL.VeriErisim.Giris.http.Post(urlPost, "Content-Length: 0", "application/x-www-form-urlencoded").ToString();
                            if (html.Contains("status\": \"ok"))
                            {
                               
                                this.Invoke(new MethodInvoker(delegate()
                                  {
                                      lstTakipBirak.Items.Add(DateTime.Now + " <--- Takipten çıkarıldı ---> " + item.KullaniciAdi);
                                      lstTakipBirak.Refresh();
                                  }));
                                //lstTakipBirak.Items.Add(DateTime.Now + " <--- Takipten çıkarıldı ---> " + item.KullaniciAdi);
                                //lstTakipBirak.Refresh();
                                //lstTakipBirak.SelectedIndex = lstTakipBirak.Items.Count - 1;
                                //lstTakipBirak.SetSelected(lstTakipBirak.Items.Count - 1, false);

                             
                            }
                            else
                            {
                                lstTakipBirak.Items.Add(html.ToString() + " <--- Takip İşlemi Sorun Oluştu ---> " + DateTime.Now);
                                lstTakipBirak.Refresh();
                                lstTakipBirak.SelectedIndex = lstTakipBirak.Items.Count - 1;
                                lstTakipBirak.SetSelected(lstTakipBirak.Items.Count - 1, false);
                                goto Takipbirakma;
                            }
                        }
                    }
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        lstTakipBirak.Items.Add(" <--- Takip İşlemi Tamamlandı. ---> " + DateTime.Now);
                        lstTakipBirak.Refresh();
                        lstTakipBirak.SelectedIndex = lstTakipBirak.Items.Count - 1;
                        lstTakipBirak.SetSelected(lstTakipBirak.Items.Count - 1, false);
                       
                    }));
                    goto Takipbirakma;
                }
                catch (Exception hata)
                { 
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        lstTakipBirak.Items.Add("Bir Sorun Oluştu." + hata.Message);
                        lstTakipBirak.Refresh();
                        lstTakipBirak.SelectedIndex = lstTakipBirak.Items.Count - 1;
                        lstTakipBirak.SetSelected(lstTakipBirak.Items.Count - 1, false);
                    }));
                }
            }
        }

         
    }
}