using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Watchlsit : Form
    {
        int userz;
        string watchname;
        public Watchlsit(int userid, string watchlistname)
        {
            InitializeComponent();
            userz = userid;
            watchname = watchlistname;
            DBconnectioncs c = new DBconnectioncs();
            DBconnectioncs R = new DBconnectioncs();

            DataTable d = c.Select("select * from watchlist_has_Anime, watchlist,series where watchlist_idwatchlist = idwatchlist and series.idshow = series_idshow;");
          
            DataTable dw = R.Select("select * from watchlist_has_Part, watchlist,MovieSeries,Part where WatchList_idWatchList =idWatchList and MovieSeries.idMovies = MovieSeries_idMovies  and Part_idPart =idPart;");
           // gridviewz1.DataSource = d;
            for (int i = 0; i < d.Rows.Count; i++)
           
            {
                
                if (d.Rows[i][3].ToString() == userz.ToString() && d.Rows[i][4].ToString() == watchname)
                {
                    gridviewz1.DataSource = d;
                    Deets.Items.Add(d.Rows[i][8].ToString() + "  " + d.Rows[i][9].ToString() + "  " + "  " + checkDub(d.Rows[i][11].ToString()) + " " + checkGoing(d.Rows[i][10].ToString()) + "  " + d.Rows[i][12].ToString() + "  " + d.Rows[i][13].ToString() + "  " + d.Rows[i][14].ToString());
                    // Deets.Items.Add(dw.Rows[i][7].ToString() + "  " + dw.Rows[i][8].ToString() + "  " + checkGoing(dw.Rows[i][9].ToString()) + "  " + checkDub(dw.Rows[i][10].ToString()) + "  " + dw.Rows[i][11].ToString() + "  " + dw.Rows[i][12].ToString() + "  " + dw.Rows[i][13].ToString());

                }

            }
            for (int i = 0; i < dw.Rows.Count; i++)
            {

                if (dw.Rows[i][3].ToString() == userz.ToString() && dw.Rows[i][4].ToString() == watchname)
                {
                    // MessageBox.Show("yaa");

                    //Deets.Items.Add(d.Rows[i][8].ToString() + "  " + d.Rows[i][9].ToString() + "  " + checkGoing(d.Rows[i][10].ToString()) + "  " + checkDub(d.Rows[i][11].ToString()) + "  " + d.Rows[i][12].ToString() + "  " + d.Rows[i][13].ToString() + "  " + d.Rows[i][14].ToString());
                    gridviewz1.DataSource = dw;
                    Deets.Items.Add(dw.Rows[i][7].ToString() + "  " + dw.Rows[i][8].ToString() + "  " + checkDub(dw.Rows[i][9].ToString()) + "  " + dw.Rows[i][12].ToString()+ "  " + dw.Rows[i][13].ToString());
                }
             }
    
        
        }

        
    


    // run querry to show watchlist of user having userid = userz and the watchlist name as userz


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Do you really want to delete this Watchlist?", "Confirm", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                var confirmresult = MessageBox.Show("Are you sure you want to delete this?", "Confirm", MessageBoxButtons.YesNo);
                if (confirmresult == DialogResult.Yes)
                {
                    Deets.Items.Remove(Deets.SelectedItem.ToString());
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Watchlsit_Load(object sender, EventArgs e)
        {

        }

        public string checkGoing(string a)
        {
            if (a=="True")
            {
                return ("Ongoing");
            }
            else
            {
                return ("Finished");
            }
        }

        public string checkDub(string a)
        {
            if (a=="True")
            {
                return ("Dubbed");
            }
            else
            {
                return ("Not Dubbed");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
            //HomeScreen f = new HomeScreen(userz);
            //f.Show();

        }
    }
}
