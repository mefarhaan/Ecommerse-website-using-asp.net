using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace electronic_products_project
{
    public partial class Login_Page : System.Web.UI.Page
    {
        //SqlConnection con = new SqlConnection(@"server=LAPTOP-7EURCCIK\SQLEXPRESS;database=Electronic_project;integrated security=true");
        Connectioncls obj = new Connectioncls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str1 = "select Reg_id from login_project_table where username ='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
           
            string cid = obj.Fn_scalar(str1);
            int cid1 = Convert.ToInt32(cid);
            if (cid1 == 1)
            {
                string str2 = "select Reg_id from login_project_table where username ='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
                string regid = obj.Fn_scalar(str2);
                Session["UserId"] = regid;
                string str3 = "select Login_type from login_project_table where username='" + TextBox1.Text + "' and password = '" + TextBox2.Text + "'";
                string logtype1 = obj.Fn_scalar(str3);
                if (logtype1 == "user")
                {
                    Response.Redirect("user_home_page.aspx");
                }
                else if (logtype1 == "admin")
                {
                    Response.Redirect("admin_home_page.aspx");
                }
            }
            else
            {
                Label3.Text = "can't enter the site....";
            }




        }
    }
}