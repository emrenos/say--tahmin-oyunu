using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SayıTahminOyunu
{
    public partial class Form2 : Form
    {
        private int randomSayi;
        private int kalanHak;
        private int kalanSure;
        public Form2(string kullaniciAdi, string sayiAraligi, int tahminHakki, int tahminSuresi)
        {
            InitializeComponent();
            label8.Text = sayiAraligi;
            Random random = new Random();
            if (sayiAraligi == "1-10")
            {
                randomSayi = random.Next(1, 10);
            }
            else if (sayiAraligi == "1-50")
            {
                randomSayi = random.Next(1, 50);
            }
            else if (sayiAraligi == "1-100")
            {
                randomSayi = random.Next(1, 100);
            }

            kalanHak = tahminHakki;
            kalanSure = tahminSuresi;

            label6.Text = kullaniciAdi;
            label2.Text = "" + kalanHak;
            label4.Text = "" + kalanSure;


            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (sender, e) =>
            {
                kalanSure--;
                label4.Text = "" + kalanSure;
                if (kalanSure == 0)
                {
                    timer.Stop();
                    MessageBox.Show("Süre bitti. Kaybettiniz. Tahmin edilen sayı: " + randomSayi);
                    DialogResult result = MessageBox.Show("Tekrar oynamak ister misiniz?", "Tekrar Oyna", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        button2_Click(sender, e);
                    }
                    else if (result == DialogResult.No)
                    {
                        this.Close();
                    }
                }
            };
            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kullaniciTahmini;
            try
            {
                kullaniciTahmini = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Geçersiz giriş! Lütfen bir sayı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            kalanHak--;
            label2.Text = "" + kalanHak;

            int fark=Math.Abs(randomSayi-kullaniciTahmini);

            if (kullaniciTahmini < randomSayi)
            {
                if (fark <= 5)
                    listBox1.Items.Add(kullaniciTahmini + " YUKARI - Çok Yakın");
                else if (fark <= 10)
                    listBox1.Items.Add(kullaniciTahmini + " YUKARI - Yakın");
                else
                    listBox1.Items.Add(kullaniciTahmini + " YUKARI - Uzak");
            }else if (kullaniciTahmini > randomSayi)
            {
                if (fark <= 5)
                    listBox1.Items.Add(kullaniciTahmini + " AŞAĞI - Çok Yakın");
                else if (fark <= 10)
                    listBox1.Items.Add(kullaniciTahmini + " AŞAĞI - Yakın");
                else
                    listBox1.Items.Add(kullaniciTahmini + " AŞAĞI - Uzak");
            }else if (fark == 0) {
                MessageBox.Show("Tebrikler doğru tahmin ettiniz! Tahmin edilen sayı: " + randomSayi);
                DialogResult result = MessageBox.Show("Tekrar oynamak ister misiniz?", "Tekrar Oyna", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    button2_Click(sender, e);
                }
                else if (result == DialogResult.No)
                {
                    this.Close();
                }
            }

            if (kalanHak == 0)
            {
                MessageBox.Show("Tahmin hakkınız kalmadı. Tahmin edilen sayı: " + randomSayi);
                DialogResult result = MessageBox.Show("Tekrar oynamak ister misiniz?", "Tekrar Oyna", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    button2_Click(sender, e);
                }
                else if (result == DialogResult.No)
                {
                    this.Close();
                }
            }

            textBox1.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Close();
        }
    }

}
