﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ONESTOPEVENTS
{
    public partial class PartnerProfessionForm : Form
    {
        public PartnerProfessionForm()
        {
            InitializeComponent();
        }

        //Declaration of variables
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8Q3DTNR\SQLEXPRESS;Initial Catalog=OnestopEvents;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        //SqlConnection con = new SqlConnection(@"Data Source=Tiaan;Initial Catalog=test;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader re;
        DataSet ds;
        DataTable dt;

        string profName;
        decimal profCost;
        int profID;

        private void PartnerProfessionForm_Load(object sender, EventArgs e)
        {
            lblProfessionCost.Visible = false;
            lblProfessionName.Visible = false;
            btnProfessionUpdate.Visible = false;
            txtProfessionNameUpdate.Visible = false;
            txtProfessionCostUpdate.Visible = false;

            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Profession_ID, Partner_Profession FROM PARTNER_PROFESSIONS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBoxxes
                cbxPartnerUpdate.DisplayMember = "Partner_Profession";
                cbxPartnerUpdate.ValueMember = "Profession_ID";
                cbxPartnerUpdate.DataSource = dt;
                cbxProfessionDelete.DisplayMember = "Partner_Profession";
                cbxProfessionDelete.ValueMember = "Profession_ID";
                cbxProfessionDelete.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cbxPartnerUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPartnerUpdate.SelectedIndex != -1)
            {
                lblProfessionCost.Visible = true;
                lblProfessionName.Visible = true;
                btnProfessionUpdate.Visible = true;
                txtProfessionNameUpdate.Visible = true;
                txtProfessionCostUpdate.Visible = true;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            profName = txtProfessionName.Text.Trim();

            if (profName.Length <= 1 || !System.Text.RegularExpressions.Regex.IsMatch(profName, @"^[a-zA-Z]+$"))
            {
                txtProfessionName.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid profession name with only letters and more than 1 character.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtProfessionName.BackColor = Color.White;
            }

            if (!decimal.TryParse(txtProfessionCost.Text, out profCost) || profCost <= 0)
            {
                txtProfessionCost.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid positive decimal number for Profession Cost.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtProfessionCost.BackColor = Color.White;
            }

            try
            {
                con.Open();
                cmd = new SqlCommand("INSERT INTO PARTNER_PROFESSIONS (Partner_Profession, Partner_Cost) VALUES (@Partner_Profession, @Partner_Cost)", con);
                cmd.Parameters.AddWithValue("@Partner_Profession", profName);
                cmd.Parameters.AddWithValue("@Partner_Cost", profCost);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Profession added successfully");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnProfessionUpdate_Click(object sender, EventArgs e)
        {
            profName = txtProfessionNameUpdate.Text.Trim();

            if (profName.Length <= 1 || !System.Text.RegularExpressions.Regex.IsMatch(profName, @"^[a-zA-Z]+$"))
            {
                txtProfessionName.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid profession name with only letters and more than 1 character.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtProfessionNameUpdate.BackColor = Color.White;
            }

            if (!decimal.TryParse(txtProfessionCostUpdate.Text, out profCost) || profCost <= 0)
            {
                txtProfessionCostUpdate.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid positive decimal number for Profession Cost.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtProfessionCostUpdate.BackColor = Color.White;
            }

            try
            {
                con.Open();
                cmd = new SqlCommand("UPDATE PARTNER_PROFESSIONS SET Partner_Profession = @Partner_Profession, Partner_Cost = @Partner_Cost WHERE Profession_ID = @Profession_ID", con);
                cmd.Parameters.AddWithValue("@Partner_Profession", profName);
                cmd.Parameters.AddWithValue("@Partner_Cost", profCost);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Profession updated successfully");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDeleteProfession_Click(object sender, EventArgs e)
        {
            profID = (int)cbxProfessionDelete.SelectedValue;
            try
            {
                con.Open();
                cmd = new SqlCommand("DELETE FROM PARTNER_PROFESSIONS WHERE Profession_ID = @Profession_ID", con);
                cmd.Parameters.AddWithValue("@Profession_ID", profID);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Profession deleted successfully");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxPartnerUpdate_DropDown(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Profession_ID, Partner_Profession FROM PARTNER_PROFESSIONS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBoxxes
                cbxPartnerUpdate.DisplayMember = "Partner_Profession";
                cbxPartnerUpdate.ValueMember = "Profession_ID";
                cbxPartnerUpdate.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cbxProfessionDelete_DropDown(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Profession_ID, Partner_Profession FROM PARTNER_PROFESSIONS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBoxxes
                cbxProfessionDelete.DisplayMember = "Partner_Profession";
                cbxProfessionDelete.ValueMember = "Profession_ID";
                cbxProfessionDelete.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnProfessionDeteteCencel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
