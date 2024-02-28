using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Flipcart
{
    public partial class Edit_Category : System.Web.UI.Page
    {
        ConCls obj = new ConCls();
        protected void Page_Load(object sender, EventArgs e)

        {
            if (!IsPostBack)
                Bind_Grid();
        }
        public void Bind_Grid()
        {
            string s= "select * from Category_Tab";
            DataSet ds = obj.Fn_Dataset(s);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Bind_Grid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Bind_Grid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txtname = (TextBox)GridView1.Rows[i].Cells[2].Controls[0];
            TextBox txtdes = (TextBox)GridView1.Rows[i].Cells[4].Controls[0];
            TextBox txtstz = (TextBox)GridView1.Rows[i].Cells[5].Controls[0];
            string strup = "update Category_Tab set Category_Name='" + txtname.Text + "',Category_Description='" + txtdes.Text + "',Category_Status='"+txtstz.Text+"' where Category_Id=" + getid + "";
            int j=obj.Fn_NonQuery(strup);
            GridView1.EditIndex = -1;
            Bind_Grid();
        }
    }
}