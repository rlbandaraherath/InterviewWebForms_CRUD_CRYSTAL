using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interview01
{
    public partial class _Default : Page
    {
        //declear as global variables
        private string name;
        private string address;
        private string age;
        private string gender;
        private string nic;


        //set values to global variables
        protected void setvalues()
        {

            name = txtname.Text;
            address = txtaddress.Text;
            age = txtage.Text;
            gender = ddlgender.SelectedValue;
            nic = txtnic.Text;

        }
        string connectionString = ConfigurationManager.ConnectionStrings["coninterview01"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayGridView();


        }
        //search by nic button
        protected void btnnicsearch_Click(object sender, EventArgs e)
        {
            try
            {
                setvalues();


                string selectQuery = "SELECT * FROM personal_details WHERE NIC = @NIC";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        // Parameter to prevent SQL injection
                        command.Parameters.AddWithValue("@NIC", nic);


                        connection.Open();


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                txtname.Text = reader["Name"].ToString();
                                txtaddress.Text = reader["Address"].ToString();
                                txtage.Text = reader["Age"].ToString();
                                ddlgender.Text = reader["Gender"].ToString();
                                txtnic.Text = reader["NIC"].ToString();


                            }
                            else
                            {
                                Response.Write("No data found for the provided NIC");
                                resetall();
                               
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Response.Write("An error occurred: " + ex.Message);
            }
        }

        //insert button
        protected void btninsert_Click(object sender, EventArgs e)
        {
            try
            {
                setvalues();


                string insertQuery = "INSERT INTO personal_details  VALUES (@Name, @Address, @Age, @Gender, @NIC)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        //  prevent SQL injection using parameters
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Age", age);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@NIC", nic);


                        connection.Open();


                        command.ExecuteNonQuery();
                    }
                }
                DisplayGridView();
                resetall();
            }
            catch (Exception ex)
            {

                Response.Write("An error occurred: Enterred NIC already available in the Database " );

            }


        }
        //update buttom
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                setvalues();


                string insertQuery = "UPDATE  personal_details   SET Name = @Name , Address = @Address, Age = @Age, Gender = @Gender WHERE NIC = @NIC";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        //  prevent SQL injection using parameters
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Age", age);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@NIC", nic);


                        connection.Open();


                        // command.ExecuteNonQuery();

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Rows were affected, update successful
                            DisplayGridView();
                            resetall();
                        }
                        else
                        {
                            // No rows were affected, NIC not available
                            Response.Write("Error: NIC not available in our Database");
                        }
                    }
                }
                DisplayGridView();
                resetall();
            }
            catch (Exception ex)
            {

                Response.Write("An error occurred: " + ex.Message);

            }
        }
        //delete button
        protected void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                setvalues();


                string insertQuery = "DELETE FROM personal_details WHERE NIC = @NIC";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        //  prevent SQL injection using parameters
                        command.Parameters.AddWithValue("@NIC", nic);

                        connection.Open();


                        //   command.ExecuteNonQuery();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Rows were affected, update successful
                            DisplayGridView();
                            resetall();
                        }
                        else
                        {
                            // No rows were affected, NIC not available
                            Response.Write("Error: NIC not available in our Database");
                        }
                    }
                }
                DisplayGridView();
            }
            catch (Exception ex)
            {

                Response.Write("An error occurred " + ex.Message);

            }
        }


        //reset button
        protected void btnreset_Click(object sender, EventArgs e)
        {
            resetall();
        }


        //reset all fields
        protected void resetall()
        {
            txtname.Text = "";
            txtaddress.Text = "";
            txtage.Text = "";
            ddlgender.SelectedIndex = 0;
            txtnic.Text = "";


        }

        // display data  in a grid view
        protected void DisplayGridView()
        {
            try
            {

                DataTable dataTable = new DataTable();


                string selectallQuery = "SELECT * FROM personal_details";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(selectallQuery, connection))
                    {

                        connection.Open();


                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {

                            dataAdapter.Fill(dataTable);
                        }
                    }
                }


                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

                Response.Write("An error occurred: " + ex.Message);
            }
        }




    }
}