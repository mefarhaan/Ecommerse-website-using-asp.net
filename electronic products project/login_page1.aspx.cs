using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace electronic_products_project
{
    public partial class login_page1 : System.Web.UI.Page
    {
        Connectioncls obj = new Connectioncls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str1 = "select count(Reg_id) from Login_table_electro where username ='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";

            string cid = obj.Fn_scalar(str1);
            int cid1 = Convert.ToInt32(cid);
            if (cid1 == 1)
            {
                string str2 = "select Reg_id from Login_table_electro where username ='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
                string regid = obj.Fn_scalar(str2);
                Session["UserId"] = regid;
                string str3 = "select Login_type from Login_table_electro where username='" + TextBox1.Text + "' and password = '" + TextBox2.Text + "'";
                string logtype1 = obj.Fn_scalar(str3);
                if (logtype1 == "user")
                {
                    Response.Redirect("userviewpage.aspx");
                }
                else if (logtype1 == "Admin")
                {
                    Response.Redirect("Admin_home_page.aspx");
                }
            }
            else
            {
                Label3.Text = "can't enter the site....";
            }
        }
    }
}