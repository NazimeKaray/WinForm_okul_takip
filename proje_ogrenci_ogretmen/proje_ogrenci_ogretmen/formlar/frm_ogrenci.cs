using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proje_ogrenci_ogretmen.entity;
using System.Data.SqlClient;

namespace proje_ogrenci_ogretmen.formlar
{
    public partial class frm_ogrenci : Form
    {
        public frm_ogrenci()
        {
            InitializeComponent();
        }

        ogrenci_sinavEntities db =new ogrenci_sinavEntities();
        SqlConnection adres = new SqlConnection(@"Data Source=localhost;Initial Catalog=ogrenci_sinav;Integrated Security=True");
        void listele()
        {
            var degerler = from x in db.ogrenci
                           select new
                           {
                               x.ogrID,
                               x.ogr_isim,
                               x.ogr_soyisim,
                               x.ogr_no,
                               x.ogr_sifre,
                               x.sinif,
                               x.ogr_mail,
                               x.ogr_durum
                           };
            dataGridView1.DataSource = degerler.Where(x=>x.ogr_durum==true).ToList();
        }
        private void frm_ogrenci_Load(object sender, EventArgs e)
        {
            listele();
            dataGridView1.Columns["ogr_durum"].Visible=false;

            //formun combobox'ı

            SqlCommand komut1 = new SqlCommand("select sinif_adi from sinif", adres);
            SqlDataAdapter da1 = new SqlDataAdapter(komut1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            comboBox1.DisplayMember = "sinif_adi";
            comboBox1.ValueMember = "sinifID";
            comboBox1.DataSource = dt1;

            //formun combobox'ı


            //Form yüklendiğinde yapılan listeleme görünümü bu şekildede gerçekleştirilebilir.

            //adres.Open();
            //SqlCommand komut1=new SqlCommand("select ders_adi from ders",adres);
            //SqlDataAdapter da1=new SqlDataAdapter(komut1);
            //DataTable dt1=new DataTable();
            //da1.Fill(dt1);
            //comboBox1.ValueMember = "dersID";
            //comboBox1.DisplayMember = "ders_adi";
            //comboBox1.DataSource = dt1;

            //Form yğklendiğinde yapılan listeleme görünümü bu şekildede gerçekleştirilebilir.
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();    
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[6].Value !=null)
            {
                txtMail.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
        }

        private void btnPasiflestir_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var x = db.ogrenci.Find(id);
            x.ogr_durum = false;
            db.SaveChanges();
            MessageBox.Show("Öğrencinin durumu başarılı bir şekilde pasifleştirildi.", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var x = db.ogrenci.Find(id);
            x.ogr_isim = txtAd.Text;
            x.ogr_soyisim = txtSoyad.Text;
            x.ogr_no = maskedTextBox1.Text;
            x.ogr_mail = txtMail.Text;
            x.ogr_sifre=txtSifre.Text;
            x.ogr_sinif = int.Parse(comboBox1.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Öğrencinin bilgileri başarılı bir şekilde güncelleştirildi.", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
