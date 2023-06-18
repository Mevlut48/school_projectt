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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VIG2L97\SQLEXPRESS;Initial Catalog=Okulproje;Integrated Security=True");


        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
            frmogrencinotlar fr = new frmogrencinotlar();
            fr.number = textBox1.Text;
            fr.Show();
            this.Hide();
           

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

           
        
                frmogretmen fr = new frmogretmen();
                fr.Show();
                this.Hide();
         
          

          

         

        }
    }
}
