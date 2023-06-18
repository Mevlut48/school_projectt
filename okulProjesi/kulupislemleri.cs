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
using System.Xml.Serialization;

namespace okulProjesi
{
    public partial class kulupislemleri : Form
    {
        public kulupislemleri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VIG2L97\SQLEXPRESS;Initial Catalog=Okulproje;Integrated Security=True");


        void temizle()
        {
            txtkulupadı.Text = " ";
            txtkulupıd.Text= " ";
        }
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_kulüpler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void kulupislemleri_Load(object sender, EventArgs e)
        {
           listele();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("insert into tbl_kulüpler (kulupad) values (@p1) ", baglanti);
            komut1.Parameters.AddWithValue("@p1", txtkulupadı.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kulüp eklenmiştir");
            temizle();
            listele();
            
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("delete from tbl_kulüpler where kulupıd=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", txtkulupıd.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kulüp silinmiştir");
            temizle();
            listele();


        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtkulupıd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtkulupadı.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("update  tbl_kulüpler set kulupad=@p1 where kulupıd=@p2",baglanti);
            komut1.Parameters.AddWithValue("@p1", txtkulupadı.Text);
            komut1.Parameters.AddWithValue("@p2", txtkulupıd.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kulüp verisi güncellenmiştir");
            temizle();
            listele();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmogretmen frm = new frmogretmen();
            frm.Show();
            this.Hide();   
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtkulupadı_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtkulupıd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void oDataInstantFeedbackSource1_GetSource(object sender, DevExpress.Data.ODataLinq.GetSourceEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
