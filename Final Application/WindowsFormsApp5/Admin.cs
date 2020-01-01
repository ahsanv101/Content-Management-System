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
using System.Data.Common;

namespace WindowsFormsApp5
{
    public partial class Addnew : Form
    {
        SqlConnection con;
        public Addnew()
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = " Data Source = AHSANPC; Initial Catalog = A8; Integrated Security = True";
            con.Open();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (type_box.SelectedItem.ToString() == "Movies")
                {
                    try
                    {
                        if (Title_box.Text != "" && plot_text.Text != "" && Duration.Text != "" && Part_text.Text != "")
                        {

                            string qry = "Insert into MovieSeries(Genre_idGenre,Name,Plot,Dubbed) values((select idGenre from Genre where type_2= @categ ), @title  ,@plot    ,@dubbed  );";
                            SqlCommand cmd = new SqlCommand(qry, con);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@categ", cat_box.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@title", Title_box.Text.ToString());
                            cmd.Parameters.AddWithValue("@plot", plot_text.Text.ToString());
                            cmd.Parameters.AddWithValue("@dubbed", dubbed_check.Checked);
                            cmd.ExecuteNonQuery();

                            string qry2 = "insert into Part(Movieseries_idmovies,number,duration) values( (select idmovies from MovieSeries where MovieSeries.Name = @title), @part, @dur)";
                            SqlCommand cmd2 = new SqlCommand(qry2, con);
                            cmd2.CommandType = CommandType.Text;
                            cmd2.Parameters.AddWithValue("@title", Title_box.Text.ToString());
                            cmd2.Parameters.AddWithValue("@part", Part_text.Text.ToString());
                            cmd2.Parameters.AddWithValue("@dur", Duration.Text.ToString());
                            cmd2.ExecuteNonQuery();
                            MessageBox.Show("Added Successfully!!");

                        }
                        else
                        {
                            MessageBox.Show("Please enter all the required fields");
                        }

                        }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Please enter all the required fields");

                    }
                }
                else if (type_box.SelectedItem.ToString() == "Series")
                {
                    try
                    {
                        if (Title_box.Text != "" && plot_text.Text != "" && Episode_text.Text != "" && Numberofseasons_text.Text != "")
                        {

                            string qry = "Insert into Series(Genre_idGenre,Studio_idStudio,Name,Plot,Status_2,Dubbed,NumberOfEpisodes,NumberOfSeasons,SeasnTime) values((select idGenre from Genre where type_2=@categ ),(select idStudio from Studio where Name=@studio ),@title, @plot,@status, @dubbed, @noe,@nos,@season);";
                            SqlCommand cmd = new SqlCommand(qry, con);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@categ", cat_box.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@title", Title_box.Text.ToString());
                            cmd.Parameters.AddWithValue("@plot", plot_text.Text.ToString());
                            cmd.Parameters.AddWithValue("@dubbed", dubbed_check.Checked);
                            cmd.Parameters.AddWithValue("@studio", studio_box.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@status", ongoing_check.Checked);
                            cmd.Parameters.AddWithValue("@noe", Episode_text.Text.ToString());
                            cmd.Parameters.AddWithValue("@nos", Numberofseasons_text.Text.ToString());
                            cmd.Parameters.AddWithValue("@season", season_box.SelectedItem.ToString());
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Added Successfully!!");
                        }
                        else {
                          MessageBox.Show("Please enter all the required fields");

                        
                    }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Please enter all the required fields");

                    }
                }
            }
            catch { MessageBox.Show("Please enter all the required fields"); }
        }
        private void type_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (type_box.SelectedItem.ToString() == "Movies")
            {
                studio_box.Text = "";
                Episode_text.Text = "";
                season_box.Text = "";
                Numberofseasons_text.Text = "";

                ongoing_check.Enabled = false;
                Part_text.Enabled = true;
                Duration.Enabled = true;

                studio_box.Enabled = false;
                Episode_text.Enabled = false;
                season_box.Enabled = false;
                Numberofseasons_text.Enabled = false;

                Episode_text.Text = "";
                season_box.Text = "";
                Numberofseasons_text.Text = "";

            }
            if (type_box.SelectedItem.ToString() == "Series")
            {
                studio_box.Enabled = true;
                Episode_text.Enabled = true;
                season_box.Enabled = true;
                Numberofseasons_text.Enabled = true;

                ongoing_check.Enabled = true;

                Part_text.Text = "";
                


                Part_text.Enabled = false;
                Duration.Enabled = false;
                

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void season_box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Numberofseasons_text_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MainScreen f =new  MainScreen();
            f.Show();
        }

        private void Time_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Part_text_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
