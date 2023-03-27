using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje_ogrenci_ogretmen.formlar
{
    public partial class frm_siniflar : Form
    {
        public frm_siniflar()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnKesfet_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtSinifAd, "Lütfen bir sınıf belirtiniz");
        }
    }
}
