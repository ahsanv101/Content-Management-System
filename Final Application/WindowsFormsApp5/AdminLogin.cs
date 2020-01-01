using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class AdminLogin : Form
    {
        int user;
        public AdminLogin(int a)
        {
            InitializeComponent();
            user = a;
            
            try
            {
                //DBconnectioncs c = new DBconnectioncs();
                //DataTable d = c.Select("Select * from Genre");
                //for (int i = 0; i < 10; i++)
                //{
                //    MessageBox.Show(d.Rows[i][1].ToString());
                //}


                //dataGridView1.DataSource = d;
                //DbConnection c = new DBconnectioncs();
                //DataTable dt = c.Select("SELECT COUNT(*) FROM operator WHERE username = '" + UName.Text + "' AND pass = '" + PWord.Text + "'");




                // SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "Insert into MovieSeries(Genre_idGenre,Name,Plot,Dubbed) values((select idGenre from Genre where type_2=" + cat_box.SelectedItem + " )," + Title_box.Text + "," + plot_text.Text + " , " + dubbed_check.Checked + ");";
                //cmd.Connection = conn;
                //cmd.ExecuteNonQuery();
                //SqlCommand cmd2 = new SqlCommand();



                //MessageBox.Show("Record has been Added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            MessageBox.Show("Login Succesful");
            MessageBox.Show("Please fill in all required details");
            MessageBox.Show("Item has been added succesfully");
            MessageBox.Show("This item is already in your watchlist");
            MessageBox.Show("Item has been added to watchist");
            var confirmResult = MessageBox.Show("Do you really want to delete this Watchlist?", "Confirm", MessageBoxButtons.YesNo);
           

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool logged = false;
            //if (textBox1.Text == "1" && textBox2.Text == "123")
            //{
            //    Addnew f = new Addnew(Int32.Parse(textBox1.Text));
            //    f.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    HomeScreen f = new HomeScreen(Int32.Parse(textBox1.Text));
            //    f.Show();
            //    this.Hide();
            //}
            DBconnectioncs c = new DBconnectioncs();
            DataTable d = c.Select("Select * from User_2");
            
            for (int i = 0; i < d.Rows.Count; i++)
            {
                // MessageBox.Show(d.Rows[i][1].ToString());
                try
                {
                    if (d.Rows[i][1].ToString() == textBox1.Text.ToString())
                    {
                        try
                        {
                            if (d.Rows[i][2].ToString() == textBox2.Text.ToString())
                            {
                                if (user == 1)
                                {
                                    HomeScreen f = new HomeScreen(Int32.Parse(d.Rows[i][0].ToString()));
                                    f.Show();
                                    this.Hide();
                                    logged = true;
                                    return;
                                }
                                //For user
                                else if (user == 0)
                                {
                                    Addnew f = new Addnew();
                                    f.Show();
                                    this.Hide();
                                    logged = true;
                                    return;

                                }
                            }
                        }
                        catch { MessageBox.Show("Please enter your password"); }

                    }
                }
                catch { MessageBox.Show("Please enter your username"); }               

            }
            if (logged != true)
            {
                MessageBox.Show("Incorrect Login Credentials");

            }


            // MessageBox.Show(d.Rows[i][1].ToString());



        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            MainScreen f = new MainScreen();
            f.Show();

        }
    }
}
