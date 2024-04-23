using System;
using System.Windows.Forms;

namespace SayıTahminOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String kullaniciAdı = textBox1.Text;
            if(string.IsNullOrEmpty(textBox1.Text) )
            {
                MessageBox.Show("Lütfen bir kullanıcı adı girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String sayiAraligi = comboBox1.Text;
            int tahminHakki = Convert.ToInt32(comboBox2.Text);
            int tahminSuresi = Convert.ToInt32(comboBox3.Text);

            Form2 Form2 = new Form2(kullaniciAdı, sayiAraligi, tahminHakki, tahminSuresi);
            Form2.Show();

            textBox1.Clear();
            comboBox1.ResetText();
            comboBox2.ResetText();
            comboBox3.ResetText();

            this.Hide();
        }
    }
}
