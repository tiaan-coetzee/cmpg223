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
using static System.Net.Mime.MediaTypeNames;


namespace Events_Form
{
    public partial class EventForm : Form
    {
        public EventForm()
        {
            InitializeComponent();
        }

        // Initialise variables
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8Q3DTNR\SQLEXPRESS;Initial Catalog=OnestopEvents;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        //SqlConnection con = new SqlConnection(@"Data Source=Tiaan;Initial Catalog=test;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader re;
        DataSet ds;
        DataTable dt;

        string eDescription;
        string eName;
        int eID;
        int vID;
        int cID;
        int pID;
        decimal ePrice;
        DateTime eDate;

        private void Events_Form_Load(object sender, EventArgs e)
        {
            BtnViewEvent.Visible = false;
            lblDispCost.Visible = false;
            btnBookEvent.Visible = false;
            btnUpdateEvent.Visible = false;
            btnDelete.Visible = false;
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Event_ID, Event_Name FROM EVENTS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                cbxUpdateEvent.DisplayMember = "Event_Name";
                cbxUpdateEvent.ValueMember = "Event_ID";
                cbxUpdateEvent.DataSource = dt;
                CB_Selected_Event.DisplayMember = "Event_Name";
                CB_Selected_Event.ValueMember = "Event_ID";
                CB_Selected_Event.DataSource = dt;

                cmd = new SqlCommand("SELECT Venue_ID, Venue_Name FROM VENUES", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxAddEventVenue.DisplayMember = "Venue_Name";
                cbxAddEventVenue.ValueMember = "Venue_ID";
                cbxAddEventVenue.DataSource = dt;
                cbxUpdateEvent_Venue.DisplayMember = "Venue_Name";
                cbxUpdateEvent_Venue.ValueMember = "Venue_ID";
                cbxUpdateEvent_Venue.DataSource = dt;

                cmd = new SqlCommand("SELECT Client_ID, (Client_FirstName + ' ' + Client_SurName) AS ClientFullName FROM CLIENTS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxClientSelectedBook.DisplayMember = "ClientFullName";
                cbxClientSelectedBook.ValueMember = "Client_ID";
                cbxClientSelectedBook.DataSource = dt;
                cbxClientSelectedUpdate.DisplayMember = "ClientFullName";
                cbxClientSelectedUpdate.ValueMember = "Client_ID";
                cbxClientSelectedUpdate.DataSource = dt;

                cmd = new SqlCommand("SELECT Partner_ID, (Partner_FirstName + ' ' + Partner_SurName) AS PartnerFullName FROM PARTNERS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxPartnerSelectedUpdate.DisplayMember = "PartnerFullName";
                cbxPartnerSelectedUpdate.ValueMember = "Profession_ID";
                cbxPartnerSelectedUpdate.DataSource = dt;
                cbxPartnerSelectedBook.DisplayMember = "PartnerFullName";
                cbxPartnerSelectedBook.ValueMember = "Profession_ID";
                cbxPartnerSelectedBook.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BtnViewEvent_Click(object sender, EventArgs e)
        {
            // VALIDATION FOR VIEW EVENT
            if (CB_Selected_Event.SelectedIndex == -1)
            {
                CB_Selected_Event.BackColor = Color.Red;
                MessageBox.Show("Please select an event to view.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                CB_Selected_Event.BackColor = Color.White;
            }
            //END OF VALIDATION

            dgvViewPartner.DataSource = null;
            eID = (int)CB_Selected_Event.SelectedValue;
            try
            {
                // Open the connection
                con.Open();

                // Create the SQL command to retrieve data from the EVENTS table
                cmd = new SqlCommand("SELECT * FROM EVENTS WHERE Event_ID = @Event_ID", con);
                cmd.Parameters.AddWithValue("@Event_ID", eID);

                // Create a DataAdapter to fill a DataSet with the retrieved data
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);

                // Set the DataGridView's DataSource to the DataTable in the DataSet
                dgvViewPartner.DataSource = ds.Tables[0];

                // Close the connection
                con.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Ensure the connection is closed, even if an exception occurs
                con.Close();
            }
        }

        private void btnBookEvent_Click(object sender, EventArgs e)
        {
            // VALIDATION TO BOOK EVENTS
            // Validate Venue Selection
            if (cbxAddEventVenue.SelectedIndex == -1)
            {
                cbxAddEventVenue.BackColor = Color.Red;
                MessageBox.Show("Please select a venue for the event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                cbxAddEventVenue.BackColor = Color.White;
            }

            //Ensure Client and Partner are selected
            if (cbxClientSelectedBook.SelectedIndex == -1 || cbxPartnerSelectedBook.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a client and a partner for the event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate Event Description
            eDescription = RTBEventDescription.Text.Trim();
            if (eDescription.Length == 0 || eDescription.Length > 255)
            {
                RTBEventDescription.BackColor = Color.Red;
                MessageBox.Show("Please provide a description for the event. No longer than 255 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                RTBEventDescription.BackColor = Color.White;
            }

            // Validate Event Date
            if (!DateTime.TryParse(monthCalendar1.Text, out eDate))
            {
                monthCalendar1.BackColor = Color.Red;
                MessageBox.Show("Please select a valid date for the event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                monthCalendar1.BackColor = Color.White;
            }

            //Validate Event name
            eName = txbEventNameBook.Text.Trim();
            if (eName.Length <= 1 || !System.Text.RegularExpressions.Regex.IsMatch(eName, @"^[a-zA-Z]+$"))
            {
                txbEventNameBook.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid event name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txbEventNameBook.BackColor = Color.White;
            }

            // Validate Event Cost
            /*
            if (!decimal.TryParse(txbEventCostBook.Text.Trim(), out ePrice) || ePrice <= 0)
            {
                txbEventCostBook.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid positive value for the event cost.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txbEventCostBook.BackColor = Color.White;
            }
            */
            // END OF VALIDATION

            // INSERT EVENT INTO DATABASE
            vID = (int)cbxAddEventVenue.SelectedValue;
            pID = (int)cbxPartnerSelectedBook.SelectedValue;
            cID = (int)cbxClientSelectedBook.SelectedValue;
            try
            {
                con.Open();

                cmd = new SqlCommand("INSERT INTO EVENTS (Event_Name, Venue_ID, Client_ID, Partner_ID, Event_Date, Event_Description, Event_Cost) VALUES (@Event_Name, @Venue_ID, @Client_ID, @Partner_ID, @Event_Date, @Event_Description, @Event_Cost)", con);
                cmd.Parameters.AddWithValue("@Event_Name", eName);
                cmd.Parameters.AddWithValue("@Venue_ID", vID);
                cmd.Parameters.AddWithValue("@Client_ID", cID);
                cmd.Parameters.AddWithValue("@Partner_ID", pID);
                cmd.Parameters.AddWithValue("@Event_Date", eDate);
                cmd.Parameters.AddWithValue("@Event_Description", eDescription);
                cmd.Parameters.AddWithValue("@Event_Cost", ePrice);

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Event booked successfully!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdateEvent_Click(object sender, EventArgs e)
        {
            // MODIFY BUTTON VALIDATION
            if (cbxUpdateEvent.SelectedIndex == -1)
            {
                cbxUpdateEvent.BackColor = Color.Red;
                MessageBox.Show("Please select an event to be updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                cbxUpdateEvent.BackColor = Color.White;
            }

            if (cbxUpdateEvent_Venue.SelectedIndex == -1)
            {
                cbxUpdateEvent_Venue.BackColor = Color.Red;
                MessageBox.Show("Please select an venue to be updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                cbxUpdateEvent_Venue.BackColor = Color.White;
            }

            eDescription = richTextBox2.Text.Trim();
            if (eDescription.Length == 0 || eDescription.Length > 255)
            {
                richTextBox2.BackColor = Color.Red;
                MessageBox.Show("Please give an updated description of your event. No longer than 255 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                richTextBox2.BackColor = Color.White;
            }

            // Validate Event Date
            if (!DateTime.TryParse(monthCalendar2.Text, out eDate))
            {
                monthCalendar2.BackColor = Color.Red;
                MessageBox.Show("Please select a valid date for the event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                monthCalendar2.BackColor = Color.White;
            }

            eName = txbEventNameUpdate.Text.Trim();
            if (eName.Length <= 1 || !System.Text.RegularExpressions.Regex.IsMatch(eName, @"^[a-zA-Z]+$"))
            {
                txbEventNameUpdate.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid event name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txbEventNameUpdate.BackColor = Color.White;
            }

            /*
            // Validate Event Cost
            if (!decimal.TryParse(txbEventCostUpdate.Text.Trim(), out ePrice) || ePrice <= 0)
            {
                txbEventCostUpdate.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid positive value for the event cost.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txbEventCostUpdate.BackColor = Color.White;
            }
            */
            // END OF VALIIDATION

            eID = (int)cbxUpdateEvent.SelectedValue;
            vID = (int)cbxUpdateEvent_Venue.SelectedValue;
            pID = (int)cbxPartnerSelectedUpdate.SelectedValue;
            cID = (int)cbxClientSelectedUpdate.SelectedValue;
            try
            {
                con.Open();

                cmd = new SqlCommand("UPDATE EVENTS SET Event_Name = @Event_Name, Venue_ID = @Venue_ID, Client_ID = @Client_ID, Partner_ID = @Partner_ID, Event_Date = @Event_Date, Event_Description = @Event_Description, Event_Cost = @Event_Cost WHERE Event_ID = @Event_ID ", con);
                cmd.Parameters.AddWithValue("@Event_Name", eName);
                cmd.Parameters.AddWithValue("@Venue_ID", vID);
                cmd.Parameters.AddWithValue("@Client_ID", cID);
                cmd.Parameters.AddWithValue("@Partner_ID", pID);
                cmd.Parameters.AddWithValue("@Event_Date", eDate);
                cmd.Parameters.AddWithValue("@Event_Description", eDescription);
                cmd.Parameters.AddWithValue("@Event_Cost", ePrice);
                cmd.Parameters.AddWithValue("@Event_ID", eID);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Event booked successfully!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //######Unhide buttons when certain criteria are met
        private void CB_Selected_Event_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Selected_Event.SelectedIndex != -1)
            {
                BtnViewEvent.Visible = true;
            }
        }

        private void cbxAddEventVenue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxAddEventVenue.SelectedIndex != -1)
            {
                btnBookEvent.Visible = true;
            }
        }

        private void cbxUpdateEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxUpdateEvent.SelectedIndex != -1 && cbxUpdateEvent_Venue.SelectedIndex != -1)
            {
                btnUpdateEvent.Visible = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDeleteEvent.SelectedIndex != -1)
            {
                btnDelete.Visible = true;
            }
        }
        //End of unhiding buttons code######

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
