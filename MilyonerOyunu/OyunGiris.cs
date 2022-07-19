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
    public partial class OyunGiris : Form
    {
        public OyunGiris()
        {
            InitializeComponent();
        }

      

        private void btnOyun_Click(object sender, EventArgs e)
        {
            Sorular sorular = new Sorular();
            this.Hide();
            sorular.Show();

        }

        private void btnGecmis_Click(object sender, EventArgs e)
        {
            Skorlar skorlar = new Skorlar();
            this.Hide();
            skorlar.Show();
        }

        
    }
}
