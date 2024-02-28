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
    public partial class User_Home : System.Web.UI.Page
    {
        ConCls obj = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string str = "select * from Category_Tab where Category_Status='Available'";
                DataSet ds = obj.Fn_Dataset(str);
                DataList1.DataSource = ds;
                DataList1.DataBind();

            }
 
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            int caid = Convert.ToInt32(e.CommandArgument);
            Session["catid"] = caid;
            Response.Redirect("View_Product.aspx");
        }
    }
}