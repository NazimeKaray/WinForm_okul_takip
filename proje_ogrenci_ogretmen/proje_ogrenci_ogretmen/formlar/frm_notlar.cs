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
using proje_ogrenci_ogretmen.entity;

namespace proje_ogrenci_ogretmen.formlar
{
    public partial class frm_notlar : Form
    {
        public frm_notlar()
        {
            InitializeComponent();
        }
        SqlConnection adres = new SqlConnection(@"Data Source=localhost;Initial Catalog=ogrenci_sinav;Integrated Security=True");
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            notlar t = new notlar();
            t.sinav1 = byte.Parse(txtSinav1.Text);
            t.sinav2 = byte.Parse(txtSinav2.Text);
            t.sozlu1 = byte.Parse(txtSozlu1.Text);
            t.sozlu2= byte.Parse(txtSozlu2.Text);
            t.proje= byte.Parse(txtProje.Text);
            t.ders = int.Parse(comboNot.SelectedValue.ToString());
            SqlCommand komut4 = new SqlCommand("select ogr_no from ogrenci", adres);
            SqlDataAdapter da4 = new SqlDataAdapter(komut4);
            DataTable dt = new DataTable();
            da4.Fill(dt);
            t.ogrenci = maskedTextBox1.Text==db.ogrenci.Where()
        }
        
        ogrenci_sinavEntities db=new ogrenci_sinavEntities();
        private void frm_notlar_Load(object sender, EventArgs e)
        {
            //not sistemi ders combobox'ı

            adres.Open();
            comboNot.ValueMember = "dersID";
            comboNot.DisplayMember = "ders_adi";
            comboNot.DataSource=db.ders.ToList();


            //arama combobox'ı

            comboArama.ValueMember = "dersID";
            comboArama.DisplayMember = "ders_adi";
            comboArama.DataSource = db.ders.ToList();
        }

        private void comboArama_SelectedIndexChanged(object sender, EventArgs e)
        {
            var degerler = from x in db.notlar
                           select new
                           {
                               x.sinav1,
                               x.sinav2,
                               x.sozlu1,
                               x.sozlu2,
                               x.proje,
                               x.donemSonuNotu,
                               x.ders1.ders_adi,
                               x.ders
                           };
            dataGridView1.DataSource = degerler.ToList();
            
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("select sinav1,sinav2,sozlu1,sozlu2,proje,ders,ogrenci from notlar", adres);
            SqlDataAdapter da3 = new SqlDataAdapter(komut3);
            DataTable dt = new DataTable();
            da3.Fill(dt);
            dataGridView1.DataSource = dt;
            //dataGridView1.DataSource = db.notlar();
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            float sinav1 = int.Parse(txtSinav1.Text), sinav2 = int.Parse(txtSinav2.Text), sozlu1 = int.Parse(txtSozlu1.Text),
                sozlu2 = int.Parse(txtSozlu2.Text), proje = int.Parse(txtProje.Text);
            txtSonuc.Text=((sinav1 + sinav2 + (sozlu1 * 40 / 100) + (sozlu2 * 40 / 100) + ((proje * 30) / 100)) / 5).ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSinav1.Text=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSozlu1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSozlu2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            comboArama.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            comboNot.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }
    }
}
