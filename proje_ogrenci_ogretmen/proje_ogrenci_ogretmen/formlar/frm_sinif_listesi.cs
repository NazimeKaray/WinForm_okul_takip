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

namespace proje_ogrenci_ogretmen.formlar
{
    public partial class frm_sinif_listesi : Form
    {
        public frm_sinif_listesi()
        {
            InitializeComponent();
        }
        ogrenci_sinavEntities db = new ogrenci_sinavEntities();
        private void frm_sinif_listesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.sinif
                           select new
                           {
                               x.sinifID,
                               x.sinif_adi
                           };
            dataGridView1.DataSource = degerler.ToList();
        }
    }
}
