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

namespace okulProjesi
{
    public partial class frmogrencinotlar : Form
    {
        public frmogrencinotlar()
        {
            InitializeComponent();
        }
        public string number;

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VIG2L97\SQLEXPRESS;Initial Catalog=Okulproje;Integrated Security=True");
        private void frmogrencinotlar_Load(object sender, EventArgs e)
        {
            
           

            SqlCommand komut = new SqlCommand("SELECT DERSAD,SINAV1,SINAV2,SINAV3,PROJE,ORTALAMA,DURUM FROM TBL_NOTLAR INNER JOIN TBL_DERSLER ON tbl_notlar.DERSID=tbl_dersler.DERSID WHERE  OGRID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1",number);
            //this.Text=number.ToString();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource= dt;
            baglanti.Close();




            //form isme ad soyad çekme 
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select ogrıd, ograd,ogrsyad from tbl_öğrenciler where OGRID=@p2", baglanti);
            komut2.Parameters.AddWithValue("@p2", number);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                this.Text = dr[0]+" " + dr[1]+ " " + dr[2].ToString();
            }
            baglanti.Close();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
