using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilyonerOyunu
{
    public partial class Skorlar : Form
    {
        public Skorlar()
        {
            InitializeComponent();
        }
        public int para;
        public int Skor;
        KullaniciKod kullanici = new KullaniciKod();
        private void Skorlar_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = kullanici.GetAll();

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            kullanici.Add(new Kullanici
            {
                KullaniciAd=tbxAd.Text,
                KullaniciSoyad=TbxSoyad.Text,
                KullaniciPuan=Skor,
                KazanilanPara=para
            }
                
                             
                );
            dataGridView1.DataSource = kullanici.GetAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            OyunGiris oyun = new OyunGiris();
            oyun.Show();

        }
    }
}
