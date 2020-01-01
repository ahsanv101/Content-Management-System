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
    public partial class HomeScreen : Form
    { int user;
        List<string> lst;
        SqlConnection con;
        public HomeScreen(int userz) {

            user = userz;
            // MessageBox.Show(user.ToString());
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = " Data Source = AHSANPC; Initial Catalog = A8; Integrated Security = True";
            con.Open();

            DBconnectioncs c = new DBconnectioncs();
            DataTable d = c.Select("Select * from watchlist");

            for (int i = 0; i < d.Rows.Count; i++)
            {
                if (d.Rows[i][1].ToString() == user.ToString())
                {
                    Watchlistbox.Items.Add(d.Rows[i][2]);
                }
            }
            //make watchlistbox populate with all the watch list names from user having user id userz
            //conn = new SqlConnection();
            //conn.ConnectionString = " Data Source = AHSANPC; Initial Catalog = A7; Integrated Security = True";
            //conn.Open();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ViewDetails f = new ViewDetails(listBox2.SelectedItem.ToString());// needs arguments from result box to be able to run
                f.Show();
            }
            catch { MessageBox.Show("Please select a series"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //this.Hide();
                Watchlsit f = new Watchlsit(user, Watchlistbox.SelectedItem.ToString());
                f.Show();
            }
            catch
            {
                MessageBox.Show("Please select WatchList");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form2 f = new Form2(user);
            f.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Do you really want to delete this Watchlist?", "Confirm", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes) {

                string qry = "delete from watchlist  where User_2_idUser_2 = @id and watchlistname = @text ;";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@text", Watchlistbox.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@id", user);


               // cmd.ExecuteNonQuery();


                Watchlistbox.Items.Remove(Watchlistbox.SelectedItem);

            };
        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            if (typebox.SelectedItem != null && typebox.SelectedItem.ToString() == "Movie")
            {
                if (catbox.SelectedItem == null || catbox.SelectedItem.ToString() == "")
                {
                    if (titletext.Text == "")
                    {
                        try
                        {
                            DBconnectioncs c = new DBconnectioncs();
                            listBox2.Items.Add("Title                   |                  genre                       || part");
                            
                            
                            DataTable d = c.Select("Select name,part.number,type_2 from part,MovieSeries,Genre where Genre_idgenre = idGenre and Movieseries_idmovies = idmovies");
                            gridviewz.DataSource = d;
                            for (int i = 0; i < d.Rows.Count; i++)
                            {

                                listBox2.Items.Add(d.Rows[i][0].ToString() + "," + d.Rows[i][2].ToString() + "," + d.Rows[i][1].ToString() + ",Movie");

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                        }
                    }
                    else
                    {
                        DBconnectioncs r = new DBconnectioncs();
                        DataTable f = r.Select("select * from part,movieseries,genre where idgenre = genre_idgenre and MovieSeries_idMovies = idmovies ");
                        listBox2.Items.Add("Title                   |                  genre                      | Episodes/Part");
                        for (int i = 0; i < f.Rows.Count; i++)
                        {
                            if (f.Rows[i][6].ToString().ToUpper().Contains(titletext.Text.ToString().ToUpper()))
                            {
                                gridviewz.DataSource = f;
                                //MessageBox.Show(f.Rows[i][3].ToString());
                                listBox2.Items.Add(f.Rows[i][6].ToString() + "," + f.Rows[i][10].ToString() + "," + f.Rows[i][2].ToString() + ",Movie");
                            }
                        }
                    }
                }
                else
                {
                    
                    DBconnectioncs r = new DBconnectioncs();
                    DataTable f = r.Select("select * from part,movieseries,genre where idgenre = genre_idgenre and MovieSeries_idMovies = idmovies ");
                    listBox2.Items.Add("Title                   |                  genre                      | Episodes/Part");
                    for (int i = 0; i < f.Rows.Count; i++)
                    {
                       // MessageBox.Show(f.Rows[i][10].ToString());
                        if (f.Rows[i][10].ToString().ToLower().Contains(catbox.SelectedItem.ToString().ToLower()))
                        {
                            gridviewz.DataSource = f;
                            listBox2.Items.Add(f.Rows[i][6].ToString() + "," + f.Rows[i][10].ToString() + "," + f.Rows[i][2].ToString() + ",Movie");
                        }
                    }
                }

            }
            else if (typebox.SelectedItem != null && typebox.SelectedItem.ToString() == "Series")
            {

                if (catbox.SelectedItem == null || catbox.SelectedItem.ToString()=="" )
                {
                    if (titletext.Text == "")
                    {
                        try
                        {
                            listBox2.Items.Add("Title                   |                  genre                       || Episodes");
                            DBconnectioncs c = new DBconnectioncs();
                            DataTable d = c.Select("Select name,numberofepisodes,type_2 from series,Genre where Genre_idgenre = idGenre");
                            for (int i = 0; i < d.Rows.Count; i++)
                            {
                                gridviewz.DataSource = d;
                                listBox2.Items.Add(d.Rows[i][0].ToString() + "," + d.Rows[i][2].ToString() + "," + d.Rows[i][1].ToString() + ",Series");

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                        }
                    }
                    else
                    {
                        DBconnectioncs c = new DBconnectioncs();
                        DataTable d = c.Select("Select * from Series,Genre where idgenre = Genre_idgenre");
                        listBox2.Items.Add("Title                   |                  genre                      | Episodes/Part");
                        for (int i = 0; i < d.Rows.Count; i++)
                        {
                            if (d.Rows[i][3].ToString().ToUpper().Contains(titletext.Text.ToString().ToUpper()))
                            {
                                //   MessageBox.Show(d.Rows[i][3].ToString());
                                gridviewz.DataSource = d;
                                listBox2.Items.Add(d.Rows[i][3].ToString() + "," + d.Rows[i][11].ToString() + "," + d.Rows[i][7].ToString() + ",Series");
                            }
                        }
                    }
                }
                else
                {
                    DBconnectioncs c = new DBconnectioncs();
                    DataTable d = c.Select("Select * from Series,Genre where idgenre = Genre_idgenre");
                    listBox2.Items.Add("Title                   |                  genre                      | Episodes/Part");
                    for (int i = 0; i < d.Rows.Count; i++)
                    {
                        if (d.Rows[i][11].ToString().ToUpper().Contains(catbox.SelectedItem.ToString().ToUpper()))
                        {
                            // MessageBox.Show(d.Rows[i][3].ToString());
                            gridviewz.DataSource = d;
                            listBox2.Items.Add(d.Rows[i][3].ToString() + "," + d.Rows[i][11].ToString() + "," + d.Rows[i][7].ToString() + ",Series");
                        }
                    }
                }


            }


            else
            {
                if (titletext.Text == "")
                {
                    if (catbox.SelectedItem == null || catbox.SelectedItem.ToString() == "")
                    {
                        try
                        {
                            DBconnectioncs c = new DBconnectioncs();
                            DataTable d = c.Select("Select name,numberofepisodes,type_2 from series,Genre where Genre_idgenre = idGenre");
                            listBox2.Items.Add("Title                   |                  genre                      | Episodes/Part");
                            for (int i = 0; i < d.Rows.Count; i++)
                            {
                                gridviewz.DataSource = d;
                                listBox2.Items.Add(d.Rows[i][0].ToString() + "," + d.Rows[i][2].ToString() + "," + d.Rows[i][1].ToString() + ",Series");

                            }
                            DBconnectioncs f = new DBconnectioncs();
                            DataTable g = f.Select("Select name,number,type_2 from part,MovieSeries,Genre where Genre_idgenre = idGenre and Movieseries_idmovies = idmovies");
                            for (int i = 0; i < g.Rows.Count; i++)
                            {
                                gridviewz.DataSource = d;
                                listBox2.Items.Add(g.Rows[i][0].ToString() + "," + g.Rows[i][2].ToString() + "," + g.Rows[i][1].ToString() + ",Movie");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                        }
                    }
                    else
                    {
                        DBconnectioncs c = new DBconnectioncs();
                        DataTable d = c.Select("Select * from Series,Genre where idgenre = Genre_idgenre");
                        listBox2.Items.Add("Title                   |                  genre                      | Episodes/Part");
                        for (int i = 0; i < d.Rows.Count; i++)
                        {
                            if (d.Rows[i][11].ToString().ToUpper().Contains(catbox.SelectedItem.ToString().ToUpper()))
                            {
                                //  MessageBox.Show(d.Rows[i][3].ToString());
                                gridviewz.DataSource = d;
                                listBox2.Items.Add(d.Rows[i][3].ToString() + "," + d.Rows[i][11].ToString() + "," + d.Rows[i][7].ToString() + ",Series");
                            }
                        }

                        DBconnectioncs r = new DBconnectioncs();
                        DataTable f = r.Select("select * from part,movieseries,genre where idgenre = genre_idgenre and MovieSeries_idMovies = idmovies ");
                       // listBox2.Items.Add("Title                   |                  genre                      | Episodes/Part");
                        for (int i = 0; i < f.Rows.Count; i++)
                        {
                            //MessageBox.Show(f.Rows[i][10].ToString());
                            if (f.Rows[i][10].ToString().ToLower().Contains(catbox.SelectedItem.ToString().ToLower()))
                            {
                                gridviewz.DataSource = f;
                                listBox2.Items.Add(f.Rows[i][6].ToString() + "," + f.Rows[i][10].ToString() + "," + f.Rows[i][2].ToString() + ",Movie");
                            }
                        }



                    }
                }
                else
                {

                    DBconnectioncs c = new DBconnectioncs();
                    DataTable d = c.Select("Select * from Series,Genre where idgenre = Genre_idgenre");
                    listBox2.Items.Add("Title                   |                  genre                      | Episodes/Part");
                    for (int i=0;i<d.Rows.Count;i++)
                    {
                        if (d.Rows[i][3].ToString().ToUpper().Contains(titletext.Text.ToString().ToUpper()))
                        {
                            // MessageBox.Show(d.Rows[i][3].ToString());
                            gridviewz.DataSource = d;
                            listBox2.Items.Add(d.Rows[i][3].ToString()+"," + d.Rows[i][11].ToString() + "," + d.Rows[i][7].ToString() + ",Series");
                        }
                    }


                    DBconnectioncs r = new DBconnectioncs();
                    DataTable f = r.Select("select * from part,movieseries,genre where idgenre = genre_idgenre and MovieSeries_idMovies = idmovies ");
                   // listBox2.Items.Add("Title                   |                  genre                      | Episodes/Part");
                    for (int i = 0; i < f.Rows.Count; i++)
                    {
                        if (f.Rows[i][6].ToString().ToUpper().Contains(titletext.Text.ToString().ToUpper()))
                        {
                            //MessageBox.Show(f.Rows[i][3].ToString());
                            gridviewz.DataSource = f;
                            listBox2.Items.Add(f.Rows[i][6].ToString() + "," + f.Rows[i][10].ToString() + "," + f.Rows[i][2].ToString() + ",Movie");
                        }
                    }
                }

            }


            //else if (typebox.SelectedItem.ToString() == "Series") {
            //    cmd.CommandText = "select * from Series where name like "+titletext.Text+"% and Genre_Genreid =(select idGenre from genre where type_2 ="+catbox.SelectedItem.ToString()+")";
            //    cmd.Connection = conn;
            //}
            //else {
            //    cmd.CommandText = "select * from Series,MovieSeries where MovieSeries.name like " + titletext.Text + "% and Series.Name like " + titletext.Text + "% and Genre_idGenre =(select idGenre from Genre where type_2=" + catbox.SelectedItem.ToString() + ") and Series.Genre_Genreid =" + titletext.Text + "% and Movieseries.Genre_idGenre =(select idGenre from Genre where type_2=" + catbox.SelectedItem.ToString() + ");";
            //    cmd.Connection = conn;
            //}
            //cmd.ExecuteNonQuery();
            // add a querry to iterate over results and add them to result box
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                lst = listBox2.SelectedItem.ToString().Split(',').ToList();
                if (lst[3] == "Series")
                {
                    try
                    {
                        DBconnectioncs c = new DBconnectioncs();
                        DataTable d = c.Select("Select * from series,Genre,studio where Genre_idgenre = idGenre and studio_idstudio=idstudio");
                        for (int i = 0; i < d.Rows.Count; i++)
                        {


                            if (d.Rows[i][3].ToString() == lst[0].ToString())
                            {

                                DBconnectioncs w = new DBconnectioncs();
                                DataTable wd = w.Select("select * from watchlist");
                                for (int j = 0; j < wd.Rows.Count; j++)
                                {

                                    if (wd.Rows[j][2].ToString() == Watchlistbox.SelectedItem.ToString() && wd.Rows[j][1].ToString() == user.ToString())
                                    {


                                        string qry = "insert into watchlist_has_anime values(@name ,@id)";
                                        SqlCommand cmd = new SqlCommand(qry, con);
                                        cmd.CommandType = CommandType.Text;
                                        cmd.Parameters.AddWithValue("@name", wd.Rows[j][0]);
                                        cmd.Parameters.AddWithValue("@id", d.Rows[i][0]);
                                        //  MessageBox.Show(wd.Rows[j][0].ToString());
                                        ///MessageBox.Show(d.Rows[i][0].ToString());
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("Item has bee added succesfully");

                                    }
                                }

                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The item is already in your watchlist");

                    }



                }
                else if (lst[3] == "Movie")
                {
                    try
                    {
                        DBconnectioncs c = new DBconnectioncs();
                        DataTable d = c.Select("Select * from part,movieseries,Genre,studio where Genre_idgenre = idGenre and movieseries_idmovies = idmovies and movieseries_idmovies= idmovies");

                        for (int i = 0; i < d.Rows.Count; i++)
                        {


                            if (d.Rows[i][6].ToString() == lst[0].ToString() && d.Rows[i][2].ToString() == lst[2].ToString())
                            {

                                DBconnectioncs w = new DBconnectioncs();
                                DataTable wd = w.Select("select * from watchlist");
                                for (int j = 0; j < wd.Rows.Count; j++)
                                {

                                    if (wd.Rows[j][2].ToString() == Watchlistbox.SelectedItem.ToString() && wd.Rows[j][1].ToString() == user.ToString())
                                    {


                                        string qry = "insert into watchlist_has_Part values(@id,@name)";
                                        SqlCommand cmd = new SqlCommand(qry, con);
                                        cmd.CommandType = CommandType.Text;

                                        // MessageBox.Show(wd.Rows[j][0].ToString());
                                        // MessageBox.Show(d.Rows[i][0].ToString());

                                        cmd.Parameters.AddWithValue("@id", d.Rows[i][0]);
                                        cmd.Parameters.AddWithValue("@name", wd.Rows[j][0]);
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("Item has been added succesfully");

                                    }
                                }

                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("This item is already in your watchlist");

                    }

                }
            }
            catch { MessageBox.Show("Please select item from result box"); }
        }
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            MainScreen f = new MainScreen();
            f.Show();

        }

        private void titletext_TextChanged(object sender, EventArgs e)
        {

        }

        private void catbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gridviewz_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
