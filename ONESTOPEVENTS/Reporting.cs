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

namespace ONESTOPEVENTS
{
    public partial class Reporting : Form
    {
        public Reporting()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8Q3DTNR\SQLEXPRESS;Initial Catalog=OnestopEvents;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader re;
        DataSet ds;
        DataTable dt;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            /*
            try
            {
                int cnt = 0;
               
                con.Open();

                adapter = new SqlDataAdapter();
                ds = new DataSet();
                string P = $"SELECT Partner_ID FROM tblPartners";
              string sql = $"SELECT Partner_ID, Partner_Name,Partner_Surname,Partner_Number,Partner_Email, MAX(Partner_Earnings) AS MaxEarnings\r\nFROM tblPartners\r\nGROUP BY  Partner_ID, Partner_Name,Partner_Surname,Partner_Number,Partner_Email\r\nORDER BY MaxEarnings DESC";
             while(cnt < 10)
                {
                    if (P == P)
                    {
                        cnt++;
                    }
                    else
                    {


                        cmd = new SqlCommand(sql, con);
                        adapter.SelectCommand = cmd;
                        adapter.Fill(ds, "ST");

                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = ("ST");
                        cnt++;
                    }

                }
                

                

                con.Close();


            }
            catch (SqlException error)
            {

                MessageBox.Show(error.Message);

            }
            */
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            {
                /*
                try
                {
                    // Initialize the SqlConnection
                 
                    
                        // Open the connection
                        con.Open();

                        // Define the SQL query to fetch the most popular venue
                        string sql = @"
                    SELECT TOP 1
                        p.Venue AS VenueName,
                        COUNT(e.EventId) AS EventCount
                    FROM
                        tblPartners p
                    LEFT JOIN
                        tblEvents e ON p.Venue = e.Venue
                    GROUP BY
                        p.Venue
                    ORDER BY
                        EventCount DESC;
                ";

                        // Initialize the SqlCommand
                        cmd = new SqlCommand(sql, con);

                        // Initialize the SqlDataAdapter
                        adapter = new SqlDataAdapter(cmd);

                        // Initialize the DataSet
                        ds = new DataSet();

                        // Fill the DataSet with the query result
                        adapter.Fill(ds, "MostPopularVenue");

                        // Check if there is data to display
                        if (ds.Tables["MostPopularVenue"].Rows.Count > 0)
                        {
                            // Bind the DataSet to the DataGridView
                            dataGridView1.DataSource = ds.Tables["MostPopularVenue"];
                        }
                        else
                        {
                            // Clear DataGridView if no data is found
                            dataGridView1.DataSource = null;
                            MessageBox.Show("No popular venue found.");
                        }
                    
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    // Ensure the connection is closed
                    if (con != null && con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                */
            }

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            /*
            try
            {
                // Initialize the SqlConnection
                
                    // Open the connection
                    con.Open();

                    // Define the SQL query to fetch the most popular event
                    string sql = @"
                    SELECT TOP 1
                        e.EventId,
                        e.EventName,
                        COUNT(e.EventId) AS EventCount
                    FROM
                        tblEvents e
                    GROUP BY
                        e.EventId, e.EventName
                    ORDER BY
                        EventCount DESC;
                ";

                    // Initialize the SqlCommand
                    cmd = new SqlCommand(sql, con);

                    // Initialize the SqlDataAdapter
                    adapter = new SqlDataAdapter(cmd);

                    // Initialize the DataSet
                    ds = new DataSet();

                    // Fill the DataSet with the query result
                    adapter.Fill(ds, "MostPopularEvent");

                    // Check if there is data to display
                    if (ds.Tables["MostPopularEvent"].Rows.Count > 0)
                    {
                        // Bind the DataSet to the DataGridView
                        dataGridView1.DataSource = ds.Tables["MostPopularEvent"];
                    }
                    else
                    {
                        // Clear DataGridView if no data is found
                        dataGridView1.DataSource = null;
                        MessageBox.Show("No popular event found.");
                    }
                
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Ensure the connection is closed
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            */
        }
 
    

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            {
                /*
                try
                {
                    // Initialize the SqlConnection
                  
                        // Open the connection
                        con.Open();

                        // Define the SQL query to fetch the most popular venue
                        string sql = @"
                    SELECT TOP 1
                        p.Venue AS VenueName,
                        COUNT(e.EventId) AS EventCount
                    FROM
                        tblPartners p
                    LEFT JOIN
                        tblEvents e ON p.Venue = e.Venue
                    GROUP BY
                        p.Venue
                    ORDER BY
                        EventCount DESC;
                ";

                        // Initialize the SqlCommand
                        cmd = new SqlCommand(sql, con);

                        // Initialize the SqlDataAdapter
                        adapter = new SqlDataAdapter(cmd);

                        // Initialize the DataSet
                        ds = new DataSet();

                        // Fill the DataSet with the query result
                        adapter.Fill(ds, "MostPopularVenue");

                        // Check if there is data to display
                        if (ds.Tables["MostPopularVenue"].Rows.Count > 0)
                        {
                            // Bind the DataSet to the DataGridView
                            dataGridView1.DataSource = ds.Tables["MostPopularVenue"];
                        }
                        else
                        {
                            // Clear DataGridView if no data is found
                            dataGridView1.DataSource = null;
                            MessageBox.Show("No popular venue found.");
                        }
                    
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    // Ensure the connection is closed
                    if (con != null && con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                */
            }

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            /* KYLE SQL
            try
            {
                
                con.Open();

                adapter = new SqlDataAdapter();
                ds = new DataSet();
                string sql = $"SELECT pID, pName,pSurname,pEmail,pNumber, MAX(pEarningsAmount) AS MaxEarnings\r\nFROM Earnings\r\nGROUP BY  pID, pName,pSurname,pEmail,pNumber\r\nORDER BY MaxEarnings DESC\r\nLIMIT 10;\r\n";

                cmd = new SqlCommand(sql, con);

                adapter.SelectCommand = cmd;
                adapter.Fill(ds, "ST");

                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = ("ST");

                con.Close();


            }
            catch (SqlException error)
            {

                MessageBox.Show(error.Message);

            }
            */
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8Q3DTNR\SQLEXPRESS;Initial Catalog=OnestopEvents;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;"))
                    {
                        con.Open();

                        string query = "SELECT Partner_FirstName, Partner_LastName, SUM(Event_Cost) AS TotalEarnings " +
                                       "FROM PARTNER " +
                                       "JOIN EVENT_PARTNER ON PARTNER.Partner_ID = EVENT_PARTNER.Partner_ID " +
                                       "JOIN EVENT ON EVENT_PARTNER.Event_ID = EVENT.Event_ID " +
                                       "GROUP BY Partner_FirstName, Partner_LastName " +
                                       "ORDER BY TotalEarnings DESC " +
                                       "LIMIT 1;";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                DataSet ds = new DataSet();
                                da.Fill(ds);

                                dataGridView1.DataSource = ds.Tables[0];
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);          
                }
            }

            if (radioButton2.Checked)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8Q3DTNR\SQLEXPRESS;Initial Catalog=OnestopEvents;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;"))
                    {
                        con.Open();

                        string query = "SELECT VENUE.Venue_ID, VENUE.Venue_Name, COUNT(EVENT.Event_ID) AS EventCount " +
                                       "FROM VENUE " +
                                       "JOIN EVENT ON VENUE.Venue_ID = EVENT.Venue_ID " +
                                       "GROUP BY VENUE.Venue_ID, VENUE.Venue_Name " +
                                       "ORDER BY EventCount DESC;";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                DataSet ds = new DataSet();
                                da.Fill(ds);

                                dataGridView1.DataSource = ds.Tables[0];
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);   
                }
            }

            if (radioButton3.Checked)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8Q3DTNR\SQLEXPRESS;Initial Catalog=OnestopEvents;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;"))
                    {
                        con.Open();

                        string query = "SELECT EVENT.Event_ID, EVENT.Event_Description, COUNT(EVENT_PARTNER.Partner_ID) AS Bookings " +
                                       "FROM EVENT " +
                                       "JOIN EVENT_PARTNER ON EVENT.Event_ID = EVENT_PARTNER.Event_ID " +
                                       "GROUP BY EVENT.Event_ID, EVENT.Event_Description " +
                                       "ORDER BY Bookings DESC;";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                DataSet ds = new DataSet();
                                da.Fill(ds);

                                dataGridView1.DataSource = ds.Tables[0];
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);   
            
                }
            }

            if (radioButton4.Checked)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8Q3DTNR\SQLEXPRESS;Initial Catalog=OnestopEvents;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;"))
                    {
                        con.Open();

                        string query = "SELECT CLIENT.Client_ID, CLIENT.Client_FirstName, CLIENT.Client_LastName, COUNT(EVENT.Event_ID) AS EventCount " +
                                       "FROM CLIENT " +
                                       "JOIN EVENT ON CLIENT.Client_ID = EVENT.Client_ID " +
                                       "GROUP BY CLIENT.Client_ID, CLIENT.Client_FirstName, CLIENT.Client_LastName " +
                                       "ORDER BY EventCount DESC " +
                                       "LIMIT 10;";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                DataSet ds = new DataSet();
                                da.Fill(ds);

                                dataGridView1.DataSource = ds.Tables[0];
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);   
                }
            }
        }

        private void Reporting_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
