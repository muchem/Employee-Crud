using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Employee_Crud
{
    public partial class WebForm1 : System.Web.UI.Page
    {

      
        SqlConnection Connection = new SqlConnection(@"Data Source = localhost;Database = CrudOperations; Integrated Security = SSPI");

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                Deletebnt.Enabled = false;
                 FillGrid();
            }
         
        }
        void FillGrid()
        {
            if(Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
                SqlDataAdapter sqladpt = new SqlDataAdapter("ViewEmployees",Connection);
                sqladpt.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTb = new DataTable();
                sqladpt.Fill(dataTb);
                Connection.Close();
                PersonView.DataSource = dataTb;
                PersonView.DataBind();
                
            }
        }
        protected void Savebnt_Click(object sender, EventArgs e)
        {

         
              if(Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                    SqlCommand com = new SqlCommand("InsertOrUpdate", Connection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@EmployeeID", (HFEmployeeID.Value == "" ? 0 : Convert.ToInt32(HFEmployeeID.Value)));
                    com.Parameters.AddWithValue("@FirstName", fnameTxt.Text.Trim());
                    com.Parameters.AddWithValue("@LastName", lnameTxt.Text.Trim());
                    com.Parameters.AddWithValue("@Email", emailTxt.Text.Trim());
                    com.ExecuteNonQuery();
                    Connection.Close();
                    Clear();
                    if(HFEmployeeID.Value == "")
                    {
                        SucessMessage.Text = "Success";
                        FillGrid();
                     }
                    else
                    {
                        SucessMessage.Text = "Update";
                        FillGrid();
                    }
                   
                }
        }

        protected void Deletebnt_Click(object sender, EventArgs e)
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
                SqlCommand com = new SqlCommand("DeleteEmployeeById", Connection);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EmployeeID",Convert.ToInt32(HFEmployeeID.Value));
                com.ExecuteNonQuery();
                Connection.Close();
                Clear();
                FillGrid();
                SucessMessage.Text = "Successfully Deleted";
            }
        }
        public void Clear()
        {
            HFEmployeeID.Value = "";
            fnameTxt.Text = "";
            lnameTxt.Text = "";
            emailTxt.Text = "";
            SucessMessage.Text = "";
            Deletebnt.Enabled = false;
            Savebnt.Text = "Save";

        }
        protected void Resetbnt_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void ViewBnt_Click(object sender, EventArgs e)
        {
            int employeeId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
                SqlDataAdapter sqladpt = new SqlDataAdapter("ViewEmployeeByID", Connection);
                sqladpt.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqladpt.SelectCommand.Parameters.AddWithValue("@EmployeeID", employeeId);
                DataTable dataTb = new DataTable();
                sqladpt.Fill(dataTb);
                Connection.Close();
                HFEmployeeID.Value = employeeId.ToString();
                fnameTxt.Text = dataTb.Rows[0]["FirstName"].ToString();
                lnameTxt.Text = dataTb.Rows[0]["LastName"].ToString(); 
                emailTxt.Text = dataTb.Rows[0]["Email"].ToString(); ;
                Savebnt.Text = "Update";
                Deletebnt.Enabled = true;
            }
        }
    }
}