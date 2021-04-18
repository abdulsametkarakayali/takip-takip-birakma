using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace instagramlogin
{
    public partial class Giris : Form
    {
        public string KullaniciId;
        public   string  XKullaniciAdi;

        public Giris()
        {
            InitializeComponent();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            XKullaniciAdi = txtKullaniciAdi.Text;
            string pass = txtParola.Text;

            bool sorgula = BAL.VeriErisim.Giris.GirisYap(XKullaniciAdi, pass);
           
            if (sorgula == true)
            {

                this.Visible  = false;
              Form1 form = new Form1();
              form.Show();
            
              
            

            }
            else
            {
                MessageBox.Show("Bir Hata İle Karşılaşıldı.");
            }
                 
                

            

        }

        private void btnGirisYap_Enter(object sender, EventArgs e)
        {
            XKullaniciAdi = txtKullaniciAdi.Text;
            string pass = txtParola.Text;

            bool sorgula = BAL.VeriErisim.Giris.GirisYap(XKullaniciAdi, pass);

            if (sorgula == true)
            {

                this.Visible = false;
                Form1 form = new Form1();
                form.Show();




            }
            else
            {
                MessageBox.Show("Bir Hata İle Karşılaşıldı.");
            }
                 
                
        }
    }
}
