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
    public partial class ogretmen_giris : Form
    {
        public ogretmen_giris()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(maskedTextBox1.Text == "00000" && txtSifre.Text == "000")
            {
                frm_harita frm = new frm_harita();
                frm.Show();
                this.Hide();
            }
            
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {
            if (txtSifre.Text == "000" && maskedTextBox1.Text == "00000")
            {
                frm_harita frm = new frm_harita();
                frm.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
