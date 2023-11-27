using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace electronic_products_project
{
    public partial class Edit_caragery_page : System.Web.UI.Page
    {
        Connectioncls obj = new Connectioncls();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (IsPostBack)
            {
                grid_bind();
            }
        }

       public void grid_bind()
        {
            string str = "select * from catagary_table";
            DataSet ds = obj.fn_dataSet(str);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int id = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string del = "delete from catagary_table where catagary_Id=" + id + "";
            int j = obj.Fn_Nonquery(del);
            if(j==1)
            {
                Label1.Visible = true;
                Label1.Text = "Deleted...";
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            grid_bind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            grid_bind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int id = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txtname = (TextBox)GridView1.Rows[i].Cells[1].Controls[0];
            TextBox txtdesc = (TextBox)GridView1.Rows[i].Cells[2].Controls[0];
            TextBox txtstat = (TextBox)GridView1.Rows[i].Cells[3].Controls[0];
            string str = "update catagary_table set catagary_name=" + txtname.Text + ",Catagary_discription=" + txtdesc.Text + ",status=" + txtstat.Text + "where Id=" + id + "";
            int j = obj.Fn_Nonquery(str);
            GridView1.EditIndex = -1;
            grid_bind();
        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {

        }
    }
}