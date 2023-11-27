using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace electronic_products_project
{
    public partial class add_catagery_page : System.Web.UI.Page
    {
        Connectioncls obj = new Connectioncls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/photos/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            string str = "insert into catagary_table values('" + TextBox1.Text + "','" + p + "','" + TextBox2.Text + "','" + TextBox3.Text + "')";
            int i = obj.Fn_Nonquery(str);
            //if(i==1)
            //{
            //    Label1.Text = "inserted";
            //}

        }
        
    }
}