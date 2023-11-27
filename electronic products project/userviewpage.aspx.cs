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
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        Connectioncls obj = new Connectioncls();
        protected void Page_Load(object sender, EventArgs e)
        {
            
          
                if (!IsPostBack)
                {
                string sel = "select * from catagary_table";
                    DataSet ds = obj.fn_dataSet(sel);
                    DataList1.DataSource=ds;
                    DataList1.DataBind();


                }

            }


        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Session["id"] = id;
            Response.Redirect("Usercartview.aspx");
        }
    }
}