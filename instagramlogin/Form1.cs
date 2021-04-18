using System;
using System.Windows.Forms;

namespace instagramlogin
{
    public partial class Form1 : Form
    {
        public string KullaniciId;
       

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var list = BAL.VeriErisim.Giris.KullaniciBilgileriniGetir();
            txtKullaniciAdi.Text = list.Veri.KullaniciAdi;

            txtKullaniciId.Text = list.Veri.KullaniciId;
            imgProfile.ImageLocation = list.Veri.Resim;
            txtIsim.Text = list.Veri.IsimSoyIsim;
        }

        private void takipçiİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KullaniciyiTakipEdenler form = new KullaniciyiTakipEdenler();
            form.Show();
        }

        

        private void takipBırakToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnTakipBirak takipbirak = new btnTakipBirak();
            takipbirak.Show();
        }

        private void yorumİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
       
        }

        private void kullaniciBegenileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            TakipEdileceklereBegenme begenme = new TakipEdileceklereBegenme();
            begenme.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}