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
    public partial class View_User_Payment_Status : System.Web.UI.Page
    {
        ConCls obj = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public void Bind_Grid()
        {
            string sel = "select * from Order_Tab";
            DataSet ds = obj.Fn_Dataset(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            int getoid = Convert.ToInt32(e.CommandArgument);
            string upt = "update Order_Tab set Order_Status='Deliverd' where Order_Id=" + getoid + "";
            int i = obj.Fn_NonQuery(upt);
            if(i!=0)
            {
                Label1.Text = "Order Status Updated Successfully";
                Bind_Grid();
            }
        }

        
    }
}