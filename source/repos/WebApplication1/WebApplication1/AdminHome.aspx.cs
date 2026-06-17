using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data; // Needed for CommandType

namespace WebApplication1
{
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void viewEmployees(object sender, EventArgs e)
        {
            // 1. Get connection string (Video Style)
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();

            // 2. Create connection
            SqlConnection conn = new SqlConnection(connStr);

            // 3. Create command
            SqlCommand cmd = new SqlCommand("SELECT * FROM allEmployeeProfiles", conn);

            // 4. Open Connection
            conn.Open();

            // 5. Execute Reader and Bind to GridView
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            grid_data.DataSource = rdr;
            grid_data.DataBind();

            // Connection closes automatically due to CommandBehavior.CloseConnection
            // OR you can use manual conn.Close() after DataBind()
        }

        protected void viewDeptStats(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("SELECT * FROM NoEmployeeDept", conn);

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            grid_data.DataSource = rdr;
            grid_data.DataBind();
        }

        protected void viewRejected(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("SELECT * FROM allRejectedMedicals", conn);

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            grid_data.DataSource = rdr;
            grid_data.DataBind();
        }

        protected void removeDeductions(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("Remove_Deductions", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            // Video Style: Manual Execute and Close
            int count = cmd.ExecuteNonQuery();
            conn.Close();

            if (count > 0)
            {
                lbl_message.Text = count + " deductions were removed successfully.";
                lbl_message.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lbl_message.Text = "No deductions found for resigned employees.";
                lbl_message.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void updateAttendance(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("Update_Attendance", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Video Style: Explicit Parsing and new SqlParameter
            // Assuming ID is integer, we use int.Parse (or Int16.Parse if video demanded smallint)
            int empID = int.Parse(txt_empID.Text);
            string checkIn = txt_checkIn.Text;
            string checkOut = txt_checkOut.Text;

            cmd.Parameters.Add(new SqlParameter("@Employee_id", empID));
            cmd.Parameters.Add(new SqlParameter("@check_in_time", checkIn));
            cmd.Parameters.Add(new SqlParameter("@check_out_time", checkOut));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            lbl_msg_update.Text = "Attendance updated successfully!";
            lbl_msg_update.ForeColor = System.Drawing.Color.Green;
        }

        protected void addHoliday(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("Add_Holiday", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            string name = txt_holidayName.Text;
            string start = txt_holidayStart.Text;
            string end = txt_holidayEnd.Text;

            // Video Style: Adding parameters explicitly
            cmd.Parameters.Add(new SqlParameter("@holiday_name", name));
            cmd.Parameters.Add(new SqlParameter("@from_date", start));
            cmd.Parameters.Add(new SqlParameter("@to_date", end));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            lbl_msg_holiday.Text = "Holiday added successfully!";
            lbl_msg_holiday.ForeColor = System.Drawing.Color.Green;
        }

        protected void initiateAttendance(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("Initiate_Attendance", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            lbl_initMsg.Text = "Attendance sheets for today have been created successfully.";
            lbl_initMsg.ForeColor = System.Drawing.Color.Green;
        }
    }
}

