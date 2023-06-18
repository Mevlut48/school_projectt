using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace okulProjesi
{
    public partial class frmsınavnolar : Form
    {
        public frmsınavnolar()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tbl_notlarTableAdapter ds =new DataSet1TableAdapters.tbl_notlarTableAdapter();
        private void btnara_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(txtogrıd.Text));
        }

        private void frmsınavnolar_Load(object sender, EventArgs e)
        {
            //baglanti.Open();
            //SqlCommand komu1 = new SqlCommand("select  * from tbl_dersler", baglanti);
            //SqlDataAdapter da = new SqlDataAdapter(komu1);
            //DataTable dtt = new DataTable();
            //da.Fill(dtt);
            //cmbders.DisplayMember = "dersad";
            //cmbders.ValueMember = "dersıd";
            //cmbders.DataSource = dtt;
            //baglanti.Close();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VIG2L97\SQLEXPRESS;Initial Catalog=Okulproje;Integrated Security=True");

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           frmogretmen fr = new frmogretmen();
            fr.Show();
            this.Hide();

        }

        
        private void btnhesapla_Click(object sender, EventArgs e)
        {
            int sınav1, sınav2, sınav3, prje;
            double ortalam;

            sınav1 = Convert.ToInt16(txtsınav1.Text);
            sınav2 = Convert.ToInt16(txtsınav2.Text);
            sınav3 = Convert.ToInt16(txtsınav3.Text);
            prje = Convert.ToInt16(txtproje.Text);

            ortalam = (sınav1 + sınav2 + sınav3 + prje) / 4;
            txtortalama.Text=ortalam.ToString();
            if (ortalam>=50)
            {
                txtdurum.Text = "True";
            }
            else
            {
                txtdurum.Text = "False";
            }

        }
        int notid;

        private void btnguncelle_Click(object sender, EventArgs e)
        {
          ds.notupdate(byte.Parse(txtsınav1.Text),byte.Parse(txtsınav2.Text),byte.Parse(txtsınav3.Text),byte.Parse(txtproje.Text),decimal.Parse(txtortalama.Text),bool.Parse(txtdurum.Text),notid);
            MessageBox.Show("guncelleme tamam");




        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            notid = int.Parse(dataGridView1.Rows[secilen].Cells[0].Value.ToString());
            txtogrıd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtsınav1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtsınav2.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtsınav3.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtproje.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            txtortalama.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            txtdurum.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
