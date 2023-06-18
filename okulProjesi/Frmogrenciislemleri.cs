using DevExpress.Utils.Extensions;
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
    public partial class Frmogrenciislemleri : Form
    {
        public Frmogrenciislemleri()
        {
            InitializeComponent();
        }

        private void txtdersıd_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmogretmen frm = new frmogretmen();
            frm.Show();
           this.Hide();
        }
        DataSet1TableAdapters.DataTable1TableAdapter dt = new DataSet1TableAdapters.DataTable1TableAdapter();

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VIG2L97\SQLEXPRESS;Initial Catalog=Okulproje;Integrated Security=True");

        private void Frmogrenciislemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dt.ogrencilistele();
            baglanti.Open();
            SqlCommand komu1 = new SqlCommand("select  * from tbl_kulüpler",baglanti);
            SqlDataAdapter da= new SqlDataAdapter(komu1);
            DataTable dtt= new DataTable();
             da.Fill(dtt);
            cmbkulüp.DisplayMember = "KULUPAD";
            cmbkulüp.ValueMember = "KULUPID";
            cmbkulüp.DataSource= dtt;
            baglanti.Close();


        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
             txtogrıd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
             txtogradı.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
             txtogrsyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
             cmbkulüp.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
             c = dataGridView1.Rows[secilen].Cells[4].Value.ToString();

            if (c=="kız")
            {
              radioERKEK.Checked = false;
              radioKIZ.Checked = true;
            }
            if (c=="erkek")
            {
                radioERKEK.Checked = true;
                radioKIZ.Checked = false;    
            }


        }
        

        void temizle()
        {
            txtogrıd.Text = " ";
            txtogradı.Text= " ";
            txtogrsyad.Text= " ";
            txtogrıd.Text= " ";
            cmbkulüp.Text= " ";
            radioKIZ.Checked = false;
            radioERKEK.Checked = false;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        string c = " ";


        private void btnekle_Click(object sender, EventArgs e)
        {
            if (radioKIZ.Checked==true)
            {
                c = "kız";

            }
            if(radioERKEK.Checked==true)
            {
                c = "erkek";
            }
            
            dt.OGRENCİEKLE(txtogradı.Text, txtogrsyad.Text, byte.Parse(cmbkulüp.SelectedValue.ToString()), c);
            MessageBox.Show("Sisteme öğrenci eklenmiştir");
            dataGridView1.DataSource = dt.ogrencilistele();




        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            dt.OGRENCİSİL(int.Parse(txtogrıd.Text));
            dataGridView1.DataSource= dt.ogrencilistele();
            MessageBox.Show("Öğrenci silinmiştir");
           

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dt.ogrencilistele();
            temizle();



        }

        private void cmbkulüp_SelectedIndexChanged(object sender, EventArgs e)
        {

          //  txtogrıd.Text = cmbkulüp.SelectedValue.ToString();


        }

        private void txtogrıd_TextChanged(object sender, EventArgs e)
        {

        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {

            
            dt.OGRENCİGUNCELLEME(txtogradı.Text, txtogrsyad.Text, byte.Parse(cmbkulüp.SelectedValue.ToString()), c, int.Parse(txtogrıd.Text));

            dataGridView1.DataSource = dt.ogrencilistele();
            MessageBox.Show("öğrenci işlemi güncellenmiştir");
          
           

        }

        private void radioKIZ_CheckedChanged(object sender, EventArgs e)
        {
            if (radioKIZ.Checked == true)
            {
                c = "kız";

            }

        }

        private void radioERKEK_CheckedChanged(object sender, EventArgs e)
        {
            if (radioERKEK.Checked == true)
            {
                c = "erkek";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource= dt.OGRGETİR(txtara.Text);
        }
    }
}
