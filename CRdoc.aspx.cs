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
using CrystalDecisions.Shared;

namespace Interview01
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btncr_Click(object sender, EventArgs e)
        {
            try
            {
                // Connection details 
                string connectionString = ConfigurationManager.ConnectionStrings["coninterview01"].ConnectionString;
                string query = "SELECT * FROM personal_details";

                // Create a DataSet
                DataSet dataSet = new DataSet();

                // Connect to the database and fill the DataSet
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    dataAdapter.Fill(dataSet);
                }

                // Create an instance of the Crystal Report
                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load(Server.MapPath("~/CrystalReport5.rpt"));

                // Set the DataSet as the report source
                reportDocument.SetDataSource(dataSet.Tables["table"]);

                // Set the Crystal Report Viewer report source
                CrystalReportViewer1.ReportSource = reportDocument;
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat,Response,false,"Personal Information");
                CrystalReportViewer1.DataBind();

            }
            
            catch (Exception ex)
            {
                Response.Write("An error occurred: " + ex.Message );
            }
        }
    }
}



