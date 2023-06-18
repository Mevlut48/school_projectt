using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace okulProjesi
{
    public partial class frmogretmen : Form
    {
        public frmogretmen()
        {
            InitializeComponent();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
          kulupislemleri frm = new kulupislemleri();
            frm.Show();
            this.Hide();
           
        }

        private void BtnDers_Click(object sender, EventArgs e)
        {
            FrmDersler fr =new FrmDersler();
            fr.Show();
            this.Hide();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Frmogrenciislemleri frm =new Frmogrenciislemleri();
            frm.Show();
            this.Hide();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frmsınavnolar fr = new frmsınavnolar();
            fr.Show();
            this.Hide();
        }

        private void frmogretmen_Load(object sender, EventArgs e)
        {

        }
    }
}
