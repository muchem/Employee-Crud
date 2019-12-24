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

        String ConnectionStr = @"Data Source = localhost;Database = CrudOperations; Integrated Security = SSPI";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){

                Deletebnt.Enabled = false;

            }

            using (SqlConnection Connection = new SqlConnection(ConnectionStr))
            {
                Connection.Open();
                String sqlQuery = "SELECT * FROM Employees";
                SqlDataAdapter sqladpt = new SqlDataAdapter(sqlQuery, Connection);
                DataTable dataTb = new DataTable();
                sqladpt.Fill(dataTb);
                PersonView.DataSource = dataTb;
                PersonView.DataBind();
                Connection.Close();
            }

        }

        protected void Savebnt_Click(object sender, EventArgs e)
        {

        }

        protected void Deletebnt_Click(object sender, EventArgs e)
        {

        }
        public void Clear()
        {
            EmployeeID.Value = "";
            fnameTxt.Text = "";
            lnameTxt.Text = "";
            emailTxt.Text = "";
            Deletebnt.Enabled = false;
            Savebnt.Text = "Save";

        }
        protected void Resetbnt_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}