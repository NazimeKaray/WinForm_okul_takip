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
    public partial class frm_ogrenci_kayit : Form
    {
        ogrenci_sinavEntities ent =new ogrenci_sinavEntities();
        public frm_ogrenci_kayit()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //sql adresimiz = Data Source = localhost; Initial Catalog = ogrenci_sinav; Integrated Security = True
        SqlConnection adres = new SqlConnection(@"Data Source=localhost;Initial Catalog=ogrenci_sinav;Integrated Security=True");
        private void frm_ogrenci_kayit_Load(object sender, EventArgs e)
        {
            adres.Open();
            comboBox1.DataSource = ent.sinif.ToList();
            comboBox1.ValueMember = "sinifID";
            comboBox1.DisplayMember = "sinif_adi";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            ogrenci tbl = new ogrenci();
            if (txtSifre.Text == txtSifre2.Text && txtSifre.Text != "" && txtSifre2.Text != ""  )   
            {
                if(txtAd.Text != "" )
                {
                    errorProvider2.SetError(txtAd, "isim belirtiniz");
                }
                if (txtSoyad.Text != "")
                {
                    errorProvider3.SetError(txtSoyad, "soyisim belirtiniz");
                }
                else
                {
                    tbl.ogr_isim = txtAd.Text;
                    tbl.ogr_soyisim = txtSoyad.Text;
                    tbl.ogr_no = maskedTextBox1.Text;
                    tbl.ogr_sinif = int.Parse(comboBox1.SelectedValue.ToString());
                    tbl.ogr_mail = txtMail.Text;
                    tbl.ogr_sifre = txtSifre.Text;
                    ent.ogrenci.Add(tbl);
                    ent.SaveChanges();
                    MessageBox.Show("Öğrenci kaydetme işlemi başarılı bir biçimde gerçekleştirildi", "bilgi", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                //tbl.ogr_isim = txtAd.Text;
                //tbl.ogr_soyisim = txtSoyad.Text;
                //tbl.ogr_no = maskedTextBox1.Text;
                //tbl.ogr_sinif = int.Parse(comboBox1.SelectedValue.ToString());
                //tbl.ogr_mail = txtMail.Text;
                //tbl.ogr_sifre = txtSifre.Text;
                //ent.ogrenci.Add(tbl);
                //ent.SaveChanges();
                //MessageBox.Show("Öğrenci kaydetme işlemi başarılı bir biçimde gerçekleştirildi", "bilgi", MessageBoxButtons.OK,
                //    MessageBoxIcon.Information);
            }
            else if (txtSifre.Text == "" && txtSifre2.Text == "")
            {
                 errorProvider1.SetError(txtSifre, "Lütfen, şifre ve şifre tekrarı giriniz");
            }
            else
            {
                MessageBox.Show("Maalesef işlemini gerçekleştiremedik, lütfen girdiğin bilgileri kontrol et!", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
                
        }
    }
}
