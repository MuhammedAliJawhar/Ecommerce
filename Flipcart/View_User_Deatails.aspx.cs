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
    public partial class View_User_Deatails : System.Web.UI.Page
    {
        ConCls obj = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Bind_Grid();
        }
        public void Bind_Grid()
        {
            string s = "select * from User_Tab";
            DataSet ds = obj.Fn_Dataset(s);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        
        //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    GridView1.EditIndex = e.NewEditIndex;
        //    Bind_Grid();
        //}

        //protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    GridView1.EditIndex = -1;
        //    Bind_Grid();
        //}

        //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    int i = e.RowIndex;
        //    int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
        //    TextBox txtlogtyp = (TextBox)GridView1.Rows[i].Cells[11].Controls[0];
          
        //    string strup = "update User_Tab set User_Status='" + txtlogtyp.Text + "' where User_Id=" + getid + "";
        //    obj.Fn_NonQuery(strup);
        //    GridView1.EditIndex = -1;
        //    Bind_Grid();
        //}

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            int getuid = Convert.ToInt32(e.CommandArgument);
            string upt = "update User_Tab set User_Status='Blocked' where User_Id=" + getuid + "";
            int i = obj.Fn_NonQuery(upt);
            if(i!=0)
            {
                Label1.Text = "Successfully Blocked User";
                Bind_Grid();
            }
        }

        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
            int getuid = Convert.ToInt32(e.CommandArgument);
            string upt = "update User_Tab set User_Status='Active' where User_Id=" + getuid + "";
            int i = obj.Fn_NonQuery(upt);
            if (i != 0)
            {
                Label1.Text = "Successfully Unblocked User";
                Bind_Grid();
            }

        }
    }
}