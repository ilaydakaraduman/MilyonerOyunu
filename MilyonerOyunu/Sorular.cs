using MilyonerOyunu.SorularGenel;
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
    public partial class Sorular : Form
    {
        public Sorular()
        {
            InitializeComponent();
        }
        SorularKod soru = new SorularKod();
        List<CikanSoru> sorular = new List<CikanSoru>();
        int Joker1 = 1, Joker2 = 1, Joker3 = 1;
        int saniye = 30;
        int dakika = 2;
        int J = 0;
        int soruNumarasi = 1;
        string Cevap = "";
        int[] CikanSorular = new int[20];
        public int Para = 0;
        int Totalpuan = 0;
        int SoruPuan = 0;
        bool DogruKontrol = false;
        string cevabim = "";

        private void Sorular_Load(object sender, EventArgs e)
        {
            sorular = soru.GetAll();
            saniye = 30;
            dakika = 2;
            timer1.Start();
            HangiSoru(soruNumarasi);
            SoruDoldur();
            SorulariGetir();
            lblParam.Text = Para.ToString();

        }
        public void SoruDoldur()
        {
            int Sorum, i = 0;

            Random rastgele = new Random();
            while (i < 20)
            {
                Sorum = rastgele.Next(21);


                if (CikanSorular.Contains(Sorum))
                {
                    continue;
                }
                else
                {
                    CikanSorular[i] = Sorum;
                    i++;
                }

            }

        }
        public void SorulariGetir()
        {
            
           
            foreach (var item in sorular)
            {
                if (J<20)
                {

                    if (item.SoruNumarasi == CikanSorular[J])
                    {
                        tbxSoru.Text = item.Soru;
                        A.Text = item.CevapA;
                        B.Text = item.CevapB;
                        C.Text = item.CevapC;
                        D.Text = item.CevapD;
                        Cevap = item.DogruCevap;
                        SoruPuan = item.SoruPuani;
                        J++;
                    }

                }
                else
                {
                    MessageBox.Show("~~~~TEBRİKLER 500.000 TL KAZANDINIZ~~~~");
                }

            }

        }
        public bool Kontrol(string dogruCevap ,string cevabim)
        {
            if (dogruCevap==cevabim)
            {
                DogruKontrol = true;
            }


            return DogruKontrol;
        }
        public void DogruCheck()
        {
            if (DogruKontrol)
            {
                if (A.BackColor == Color.Green || B.BackColor == Color.Green || C.BackColor == Color.Green || D.BackColor == Color.Green)
                {


                    MessageBox.Show("Tebrikler Doğru Cevap Verdiniz ");
                    if (MessageBox.Show("Devam etmek mi istiyorsunz Çekilmek mi istiyorsunuz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MessageBox.Show("Güzel.Devam Etmek için sıradaki soru butonuna tıklayıp paranızı arttırmaya devam edebilirsiniz.");
                    }
                    else
                    {
                        MessageBox.Show("Bizimle Oynadığınız için teşekkür ederiz toplam kazancınız :" + Para + "Tl");
                        if (MessageBox.Show("Skorunu Kaydet ?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Skorlar skorlar = new Skorlar();
                            skorlar.para = Para;
                            skorlar.Skor = Totalpuan;
                            skorlar.Show();
                            this.Hide();
                        }
                    }
                }

            }
           



        }
      
        private void button8_Click(object sender, EventArgs e)
        {
           
            if (Joker1==1)
            {
                if (saniye>30)
                {
                    saniye =  60-saniye ;
                    dakika += 2;
                    btnSureArttir.BackColor = Color.White;
                }
                else
                {
                    saniye += 30;
                    dakika++;
                    btnSureArttir.BackColor = Color.White;
                }
               
                Joker1--;
            }
            else if (btnSureArttir.BackColor == Color.White && Joker1 != 1)
            {
                MessageBox.Show("Bu jokeri kullandınız oyuna devam edin.");    
            }
        }

        private void btnSoruDegistir_Click(object sender, EventArgs e)
        {
            lblParam.Text = Para.ToString();
            DogruKontrol = false;
             saniye = 30;
             dakika = 2;
            soruNumarasi++;
            lblSoru.Text = soruNumarasi.ToString();
            C.BackColor = Color.Transparent;
            B.BackColor = Color.Transparent;
            A.BackColor = Color.Transparent;
            D.BackColor = Color.Transparent;
            HangiSoru(soruNumarasi);
            timer1.Start();
            SorulariGetir();
            


        }

        private void C_Click(object sender, EventArgs e)
        {
            C.BackColor = Color.DarkGray;
            cevabim = "C";
            if (MessageBox.Show("Cevabinizdan Emin Misiniz ?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Kontrol(Cevap, cevabim))
                {
                    C.BackColor = Color.Green;
                    Totalpuan += SoruPuan;
                    switch (soruNumarasi)
                    {
                        case 1:
                            Para += 500;
                            break;
                        case 2:
                            Para += 1000;
                            break;
                        case 3:
                            Para += 2000;
                            break;
                        case 4:
                            Para += 5000;
                            break;
                        case 5:
                            Para += 10000;
                            break;
                        case 6:
                            Para += 35000;
                            break;
                        case 7:
                            Para += 70000;
                            break;
                        case 8:
                            Para += 150000;
                            break;
                        case 9:
                            Para += 300000;
                            break;
                        case 10:
                            Para += 500000;
                            break;
                        default:
                            break;
                    }

                    DogruCheck();

                    }
                else
                {
                    MessageBox.Show("Cevap Yanlış Oyun Bitti Kazancınız Malesef Yok");
                    if (MessageBox.Show("Cevap Yanlış Oyun Bitti Tekrar Başlamak İster Misiniz", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        OyunGiris giris = new OyunGiris();
                        this.Hide();
                        giris.Show();
                    }

                }
            }
            else
            {
                C.BackColor = Color.Transparent;
            }
           
            
        }

        private void D_Click(object sender, EventArgs e)
        {
            D.BackColor = Color.DarkGray;
            cevabim = "D";
            if (MessageBox.Show("Cevabinizdan Emin Misiniz ?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Kontrol(Cevap, cevabim))
                {
                    D.BackColor = Color.Green;
                    Totalpuan += SoruPuan;
                    switch (soruNumarasi)
                    {
                        case 1:
                            Para += 500;
                            break;
                        case 2:
                            Para += 1000;
                            break;
                        case 3:
                            Para += 2000;
                            break;
                        case 4:
                            Para += 5000;
                            break;
                        case 5:
                            Para += 10000;
                            break;
                        case 6:
                            Para += 35000;
                            break;
                        case 7:
                            Para += 70000;
                            break;
                        case 8:
                            Para += 150000;
                            break;
                        case 9:
                            Para += 300000;
                            break;
                        case 10:
                            Para += 500000;
                            break;
                        default:
                            break;
                    }

                    DogruCheck();

                }
                else
                {
                    D.BackColor = Color.Red;
                    MessageBox.Show("Cevap Yanlış Oyun Bitti Kazancınız Malesef Yok");
                    if (MessageBox.Show("Cevap Yanlış Oyun Bitti Tekrar Başlamak İster Misiniz", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        OyunGiris giris = new OyunGiris();
                        this.Hide();
                        giris.Show();
                    }

                }
            }
            else
            {
                C.BackColor = Color.Transparent;
            }




        }

        private void A_Click(object sender, EventArgs e)
        {
            A.BackColor = Color.DarkGray;
            cevabim = "A";
            if (MessageBox.Show("Cevabinizdan Emin Misiniz ?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Kontrol(Cevap, cevabim))
                {
                    A.BackColor = Color.Green;
                    Totalpuan += SoruPuan;
                    switch (soruNumarasi)
                    {
                        case 1:
                            Para += 500;
                            break;
                        case 2:
                            Para += 1000;
                            break;
                        case 3:
                            Para += 2000;
                            break;
                        case 4:
                            Para += 5000;
                            break;
                        case 5:
                            Para += 10000;
                            break;
                        case 6:
                            Para += 35000;
                            break;
                        case 7:
                            Para += 70000;
                            break;
                        case 8:
                            Para += 150000;
                            break;
                        case 9:
                            Para += 300000;
                            break;
                        case 10:
                            Para += 500000;
                            break;
                        default:
                            break;
                    }

                    DogruCheck();

                }
                else
                {
                    A.BackColor = Color.Red;
                    MessageBox.Show("Cevap Yanlış Oyun Bitti Kazancınız Malesef Yok");
                    if (MessageBox.Show("Cevap Yanlış Oyun Bitti Tekrar Başlamak İster Misiniz", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        OyunGiris giris = new OyunGiris();
                        this.Hide();
                        giris.Show();
                    }

                }
            }
            else
            {
                A.BackColor = Color.Transparent;
            }



        }

        private void B_Click(object sender, EventArgs e)
        {
            B.BackColor = Color.DarkGray;
            cevabim = "B";
            if (MessageBox.Show("Cevabinizdan Emin Misiniz ?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Kontrol(Cevap, cevabim))
                {
                    B.BackColor = Color.Green;
                    Totalpuan += SoruPuan;
                    switch (soruNumarasi)
                    {
                        case 1:
                            Para += 500;
                            break;
                        case 2:
                            Para += 1000;
                            break;
                        case 3:
                            Para += 2000;
                            break;
                        case 4:
                            Para += 5000;
                            break;
                        case 5:
                            Para += 10000;
                            break;
                        case 6:
                            Para += 35000;
                            break;
                        case 7:
                            Para += 70000;
                            break;
                        case 8:
                            Para += 150000;
                            break;
                        case 9:
                            Para += 300000;
                            break;
                        case 10:
                            Para += 500000;
                            break;
                        default:
                            break;
                    }

                    DogruCheck();

                }
                else
                {
                    B.BackColor = Color.Red;
                    MessageBox.Show("Cevap Yanlış Oyun Bitti Kazancınız Malesef Yok");
                    if (MessageBox.Show("Cevap Yanlış Oyun Bitti Tekrar Başlamak İster Misiniz", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        OyunGiris giris = new OyunGiris();
                        this.Hide();
                        giris.Show();
                    }

                }
            }
            else
            {
                B.BackColor = Color.Transparent;
            }




        }

        private void btnDogruCevap_Click(object sender, EventArgs e)
        {
            if (Joker2==1)
            {
                MessageBox.Show("Sorunun doğru Cevabını İstatiksel olarak halka sorduk. Verdikleri En Yüksek Oranda olan cevap :" + Cevap);
                 btnDogruCevap.BackColor = Color.White;
                Joker2--;
            }
            else if (btnSureArttir.BackColor == Color.White && Joker2 != 1)
            {
                MessageBox.Show("Bu jokeri kullandınız oyuna devam edin.");
            }
        }

        private void btnYariYariya_Click(object sender, EventArgs e)
        {
            if (Joker3==1)
            {
                if (Cevap == "A")
                {
                    D.BackColor = Color.Black;
                    C.BackColor = Color.Black;
                }
                if (Cevap == "B")
                {
                    A.BackColor = Color.Black;
                    D.BackColor = Color.Black;

                }
                if (Cevap == "C")
                {
                    A.BackColor = Color.Black;
                    B.BackColor = Color.Black;
                }
                if (Cevap == "D")
                {
                    C.BackColor = Color.Black;
                    B.BackColor = Color.Black;
                }
                btnYariYariya.BackColor = Color.White;
                Joker3--;
            }
            else if (btnYariYariya.BackColor == Color.White && Joker3 != 1)
            {
                MessageBox.Show("Bu jokeri kullandınız oyuna devam edin.");
            }

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        public void HangiSoru(int numara)
        {
            switch (numara)
            {
                case 1:
                    label1.ForeColor = Color.DarkOrange;
                    break;
                case 2:
                    label2.ForeColor = Color.DarkOrange;
                    break;
                case 3:
                    label3.ForeColor = Color.DarkOrange;
                    break;
                case 4:
                    label4.ForeColor = Color.DarkOrange;
                    break;
                case 5:
                    label5.ForeColor = Color.DarkOrange;
                    break;
                case 6:
                    label6.ForeColor = Color.DarkOrange;
                    break;
                case 7:
                    label7.ForeColor = Color.DarkOrange;
                    break;
                case 8:
                    label8.ForeColor = Color.DarkOrange;
                    break;
                case 9:
                    label9.ForeColor = Color.DarkOrange;
                    break;
                case 10:
                    label10.ForeColor = Color.DarkOrange;
                    break;
                default:
                    break;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            saniye -= 1;
            lblSaniye.Text = saniye.ToString();
            lblDakika.Text = (dakika - 1).ToString();
            if (saniye == 0 && dakika != 0)
            {
                saniye = 60;
                dakika--;
            }
           else if (saniye==0 && dakika==0 )
            {
                if (A.BackColor == Color.Green ||  B.BackColor == Color.Green || C.BackColor == Color.Green || D.BackColor == Color.Green)
                {
                    MessageBox.Show("Tebrikler Doğru Cevap Verdiniz ");
                    if (MessageBox.Show("Devam etmek mi istiyorsunz Çekilmek mi istiyorsunuz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MessageBox.Show("Güzel.Devam Etmek için sıradaki soru butonuna tıklayıp paranızı arttırmaya devam edebilirsiniz.");
                    }
                    else
                    {
                        MessageBox.Show("Bizimle Oynadığınız için teşekkür ederiz toplam kazancınız :" + Para + "tl");
                        Skorlar skor = new Skorlar();
                    }
                }
                
            }
        }
    }
}
