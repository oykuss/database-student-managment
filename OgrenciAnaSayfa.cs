using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Otomasyon
{
    public partial class OgrenciAnaSayfa : Form
    {
        public OgrenciAnaSayfa()
        {
            InitializeComponent();
        }

        public void dersListele()
        {
            try
            {
                DateTime tarih = DateTime.Parse(comboBox2.Text);
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=OgrenciOtomasyondb;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("select [dersKodu], [dersAdi] ,[dersKredi] ,[akademisyenAd] from  OgrenciAkademisyenDers,Ders,Akademisyen  where  dersTarihi ='" + tarih + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }

        public void notListele()
        {
            try
            {
                DateTime tarih = DateTime.Parse(comboBox2.Text);
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=OgrenciOtomasyondb;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("select [dersAdi] ,[vize] ,[final], [but] from  OgrenciAkademisyenDers,Ders,Puan where  dersTarihi ='"+ tarih  + "'" , con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }

        public void Listeleme()
        {


            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=OgrenciOtomasyondb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from OgrenciAkademisyenDers", con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBox2.Items.Add(rd["dersTarihi"].ToString());
            }
            con.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            DersKayıtEkranı kayıt = new DersKayıtEkranı();
            kayıt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dersListele(); 

        }

        private void button3_Click(object sender, EventArgs e)
        {
            notListele();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void OgrenciAnaSayfa_Load(object sender, EventArgs e)
        {
            Listeleme();
        }
    }
}
