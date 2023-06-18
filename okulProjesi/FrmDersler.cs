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
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmogretmen fr = new frmogretmen();
            fr.Show();
            this.Hide();
        }
        DataSet1TableAdapters.tbl_derslerTableAdapter ds = new DataSet1TableAdapters.tbl_derslerTableAdapter();

        private void btnekle_Click(object sender, EventArgs e)
        {

            ds.dersekle(txtdersadı.Text);
            MessageBox.Show("Ders ekleme işlemi yapılmıştır");

        }

        private void FrmDersler_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Derslistesi();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Derslistesi();

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtdersıd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtdersadı.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.derssil(byte.Parse(txtdersıd.Text));
            dataGridView1.DataSource= ds.Derslistesi();
            MessageBox.Show("Ders sistemden silinmiştir");

        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            ds.DERSGUNCELLE(txtdersadı.Text, byte.Parse(txtdersıd.Text));
            dataGridView1.DataSource = ds.Derslistesi();
            MessageBox.Show("Ders güncelleme işlemi tamamlanmıştır");
        }
    }
}
