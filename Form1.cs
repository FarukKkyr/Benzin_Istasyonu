using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Benzin_İstasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        double d_benzin95 = 0, d_benzin97 = 0, d_dizel = 0, d_eurodizel = 0, d_lpg = 0; //depodaki yakıt
        double f_benzin95 = 0, f_benzin97 = 0, f_dizel = 0, f_eurodizel = 0, f_lpg = 0; //Eklenen yakıt
        double e_benzin95 = 0, e_benzin97= 0, e_dizel = 0, e_eurodizel = 0, e_lpg = 0;  // Yakıt fiyatları
        double s_benzin95 = 0, s_benzin97 = 0, s_dizel = 0, s_eurodizel = 0, s_lpg = 0; // Satılan yakıt fiyatı

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        string[] depo_bilgileri;
        string[] fiyat_bilgileri;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text=="Benzin(95)")
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "Benzin(97)")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "Dizel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }

            else if (comboBox1.Text == "Eurodizel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = true;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "Lpg")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = true;
            }
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;

            label29.Text = "________";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            s_benzin95 = double.Parse(numericUpDown1.Value.ToString());
            s_benzin97 = double.Parse(numericUpDown2.Value.ToString());
            s_dizel = double.Parse(numericUpDown3.Value.ToString());
            s_eurodizel = double.Parse(numericUpDown4.Value.ToString());
            s_lpg = double.Parse(numericUpDown5.Value.ToString());

            if(numericUpDown1.Enabled==true)
            {
                d_benzin95 = d_benzin95 - s_benzin95;
                label29.Text = Convert.ToString(s_benzin95 * f_benzin95);
            }
            else if (numericUpDown2.Enabled == true)
            {
                d_benzin97 = d_benzin97 - s_benzin97;
                label29.Text = Convert.ToString(s_benzin97 * f_benzin97);
            }
            else if (numericUpDown3.Enabled == true)
            {
                d_dizel = d_dizel - s_dizel;
                label29.Text = Convert.ToString(s_dizel * f_dizel);
            }
            else if (numericUpDown4.Enabled == true)
            {
                d_eurodizel = d_eurodizel - s_eurodizel;
                label29.Text = Convert.ToString(s_eurodizel * f_eurodizel);
            }
            else if (numericUpDown5.Enabled == true)
            {
                d_lpg = d_lpg - s_lpg;
                label29.Text = Convert.ToString(s_lpg * f_lpg);
            }

            depo_bilgileri[0] = Convert.ToString(d_benzin95);
            depo_bilgileri[1] = Convert.ToString(d_benzin97);
            depo_bilgileri[2] = Convert.ToString(d_dizel);
            depo_bilgileri[3] = Convert.ToString(d_eurodizel);
            depo_bilgileri[4] = Convert.ToString(d_lpg);

            System.IO.File.WriteAllLines(Application.StartupPath + "\\depo.txt", depo_bilgileri);
            txt_depo_oku();
            depo_yaz();
            progressBar_guncelle();
            numeric_value();

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                f_benzin95 = f_benzin95 + (f_benzin95 * Convert.ToDouble(textBox6.Text) / 100);
                fiyat_bilgileri[0] = Convert.ToString(f_benzin95);
            }
            catch (Exception)
            {
                textBox6.Text = "Hata!";
            }

            try
            {
                f_benzin97 = f_benzin97 + (f_benzin97 * Convert.ToDouble(textBox7.Text) / 100);
                fiyat_bilgileri[1] = Convert.ToString(f_benzin97);
            }
            catch (Exception)
            {
                textBox7.Text = "Hata!";
            }
            try
            {
                f_dizel = f_dizel + (f_dizel * Convert.ToDouble(textBox8.Text) / 100);
                fiyat_bilgileri[2] = Convert.ToString(f_dizel);
            }
            catch (Exception)
            {
                textBox8.Text = "Hata!";
            }

            try
            {
                f_eurodizel = f_eurodizel + (f_eurodizel * Convert.ToDouble(textBox9.Text) / 100);
                fiyat_bilgileri[3] = Convert.ToString(f_eurodizel);
            }
            catch (Exception)
            {
                textBox9.Text = "Hata!";
            }

            try
            {
                f_lpg = f_lpg + (f_lpg * Convert.ToDouble(textBox10.Text) / 100);
                fiyat_bilgileri[4] = Convert.ToString(f_lpg);
            }
            catch (Exception)
            {
                textBox10.Text = "Hata!";
            }

            System.IO.File.WriteAllLines(Application.StartupPath + "\\fiyat.txt", fiyat_bilgileri);
            fiyat_oku();
            fiyat_yaz();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                e_benzin95 = Convert.ToDouble(textBox1.Text);
                if (1000 < d_benzin95 + e_benzin95 || e_benzin95 <= 0)
                    textBox1.Text = "Hata!";
                else
                    depo_bilgileri[0] = Convert.ToString(d_benzin95 + e_benzin95);

            }
            catch (Exception)
            {

                textBox1.Text = "Hata!";
            }

            try
            {
                e_benzin97 = Convert.ToDouble(textBox2.Text);
                if (1000 < d_benzin97 + e_benzin97 || e_benzin97 <= 0)
                    textBox2.Text = "Hata!";
                else
                    depo_bilgileri[1] = Convert.ToString(d_benzin97 + e_benzin97);

            }
            catch (Exception)
            {

                textBox2.Text = "Hata!";
            }

            try
            {
                e_dizel = Convert.ToDouble(textBox3.Text);
                if (1000 < d_dizel + e_dizel || e_dizel <= 0)
                    textBox3.Text = "Hata!";
                else
                    depo_bilgileri[2] = Convert.ToString(d_dizel + e_dizel);

            }
            catch (Exception)
            {

                textBox3.Text = "Hata!";
            }

            try
            {
                e_eurodizel = Convert.ToDouble(textBox4.Text);
                if (1000 < d_eurodizel + e_eurodizel || e_eurodizel <= 0)
                    textBox4.Text = "Hata!";
                else
                    depo_bilgileri[3] = Convert.ToString(d_eurodizel + e_eurodizel);

            }
            catch (Exception)
            {

                textBox4.Text = "Hata!";
            }

            try
            {
                e_lpg = Convert.ToDouble(textBox5.Text);
                if (1000 < d_lpg + e_lpg || e_lpg <= 0)
                    textBox5.Text = "Hata!";
                else
                    depo_bilgileri[4] = Convert.ToString(d_lpg + e_lpg);

            }
            catch (Exception)
            {

                textBox5.Text = "Hata!";
            }

            System.IO.File.WriteAllLines(Application.StartupPath + "\\depo.txt", depo_bilgileri);
            txt_depo_oku();
            depo_yaz();
            progressBar_guncelle();
            numeric_value();
        }

      

        private void txt_depo_oku()
        {
            depo_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\depo.txt");
            d_benzin95 = Convert.ToDouble(depo_bilgileri[0]);
            d_benzin97 = Convert.ToDouble(depo_bilgileri[1]);
            d_dizel = Convert.ToDouble(depo_bilgileri[2]);
            d_eurodizel = Convert.ToDouble(depo_bilgileri[3]);
            d_lpg = Convert.ToDouble(depo_bilgileri[4]); 
        }
        private void depo_yaz()
        {
            label6.Text = d_benzin95.ToString("N");
            label7.Text = d_benzin97.ToString("N");
            label8.Text = d_dizel.ToString("N");
            label9.Text = d_eurodizel.ToString("N");
            label10.Text = d_lpg.ToString("N");
        }
        
        private void fiyat_oku()
        {
            fiyat_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\fiyat.txt");
            f_benzin95 = Convert.ToDouble(fiyat_bilgileri[0]);
            f_benzin97 = Convert.ToDouble(fiyat_bilgileri[1]);
            f_dizel = Convert.ToDouble(fiyat_bilgileri[2]);
            f_eurodizel = Convert.ToDouble(fiyat_bilgileri[3]);
            f_lpg = Convert.ToDouble(fiyat_bilgileri[4]);
        }
        private void fiyat_yaz()
        {
            label16.Text = f_benzin95.ToString("N");
            label17.Text = f_benzin97.ToString("N");
            label18.Text = f_dizel.ToString("N");
            label19.Text = f_eurodizel.ToString("N");
            label20.Text = f_lpg.ToString("N");
        }
        private void progressBar_guncelle()
        {
            progressBar1.Value = Convert.ToInt16(d_benzin95);
            progressBar2.Value = Convert.ToInt16(d_benzin97);
            progressBar3.Value = Convert.ToInt16(d_dizel);
            progressBar4.Value = Convert.ToInt16(d_eurodizel);
            progressBar5.Value = Convert.ToInt16(d_lpg);
        }

        private void numeric_value()
        {
            numericUpDown1.Maximum = decimal.Parse(d_benzin95.ToString());
            numericUpDown2.Maximum = decimal.Parse(d_benzin97.ToString());
            numericUpDown3.Maximum = decimal.Parse(d_dizel.ToString());
            numericUpDown4.Maximum = decimal.Parse(d_eurodizel.ToString());
            numericUpDown5.Maximum = decimal.Parse(d_lpg.ToString());
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 1000;
            progressBar2.Maximum = 1000;
            progressBar3.Maximum = 1000;
            progressBar4.Maximum = 1000;
            progressBar5.Maximum = 1000;
            txt_depo_oku();
            depo_yaz();
            fiyat_oku();
            fiyat_yaz();
            progressBar_guncelle();
            numeric_value();

            string[] yakit_türleri = { "Benzin(95)", "Benzin(97)", "Dizel", "Eurodizel", "Lpg" };
            comboBox1.Items.AddRange(yakit_türleri);

            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;

            numericUpDown1.DecimalPlaces = 2;
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown4.DecimalPlaces = 2;
            numericUpDown5.DecimalPlaces = 2;

            

            

        }
    }
}
