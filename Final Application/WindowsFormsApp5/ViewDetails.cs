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
    public partial class ViewDetails : Form
    {
        SqlConnection con;
        List<string> lst;

        public ViewDetails(string detail)
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = " Data Source = AHSANPC; Initial Catalog = A8; Integrated Security = True";
            con.Open();
           
            lst = detail.Split(',').ToList();
            if (lst[3] == "Series") { 
                
            
                try
                {

                    DBconnectioncs c = new DBconnectioncs();
                    DataTable d = c.Select("Select * from series,Genre,studio where Genre_idgenre = idGenre and studio_idstudio=idstudio ");
                    
                    for (int i=0; i<d.Rows.Count;i++)
                    {
                        MessageBox.Show("1"+d.Rows[i][5].ToString());

                        if (d.Rows[i][3].ToString()==lst[0].ToString())
                        {
                            Title.Text = d.Rows[i][3].ToString();
                            plot.Items.Add(d.Rows[i][4].ToString());
                            season.Text = d.Rows[i][9].ToString();
                            numberepisodes.Text = d.Rows[i][7].ToString();
                            seasonnumber.Text = d.Rows[i][8].ToString();
                            Cat.Text = d.Rows[i][11].ToString();
                            studio.Text = d.Rows[i][13].ToString();
                            type.Text = "Series";
                            if (d.Rows[i][6].ToString() == "True")
                            {
                                dubbecheck.Checked = true;
                            }
                            else { dubbecheck.Checked = false; }
                            if (d.Rows[i][5].ToString() == "True") {
                                ongoingcheck.Checked = true;

                            }
                            else { ongoingcheck.Checked = false;
                            }
                            break;
                        
                        }
                    }
                      
                    //MessageBox.Show(d.Rows[0].ToString());

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
           else if (lst[3] == "Movie")
            {
              
                try
                {

                    DBconnectioncs c = new DBconnectioncs();
                    DataTable d = c.Select("Select * from part,movieseries,Genre,studio where Genre_idgenre = idGenre and movieseries_idmovies = idmovies");

                    for (int i = 0; i < d.Rows.Count; i++)
                    {
                      // MessageBox.Show(lst[2].ToString());

                        if (d.Rows[i][6].ToString() == lst[0].ToString() && d.Rows[i][2].ToString() == lst[2].ToString())
                        {
                            Title.Text = d.Rows[i][6].ToString();
                            plot.Items.Add(d.Rows[i][7].ToString());
                            part.Text = d.Rows[i][2].ToString();
                            duration.Text = d.Rows[i][3].ToString();
                           
                            Cat.Text = d.Rows[i][10].ToString();
                           
                            type.Text = "Movie";
                            if (d.Rows[i][8].ToString() == "True")
                            {
                                dubbecheck.Checked = true;
                            }
                            else { dubbecheck.Checked = false; }
                           
                            break;

                        }
                    }

                    //MessageBox.Show(d.Rows[0].ToString());


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }


            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ViewDetails_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
