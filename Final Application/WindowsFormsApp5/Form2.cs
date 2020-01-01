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

namespace WindowsFormsApp5
{
    public partial class Form2 : Form
    {
        int userz;

        SqlConnection con;
        public Form2(int userid)
        {
            userz = userid;
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = " Data Source = AHSANPC; Initial Catalog = A8; Integrated Security = True";
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            
            string qry = "Insert into watchlist(user_2_iduser_2,watchlistname) values(@id,@text );";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", Int32.Parse(userz.ToString()));
            cmd.Parameters.AddWithValue("@text", textBox1.Text.ToString());
  
            cmd.ExecuteNonQuery();
            HomeScreen f = new HomeScreen(userz);
            // "insert into watchlist values " userz , textbox1.tostring() 
            // add watchlist to user having userid=userz and watchlist name as textbox
            f.Update();
            f.Show();
            this.Hide();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
