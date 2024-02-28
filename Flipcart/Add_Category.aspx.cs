using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Flipcart
{
    public partial class Add_Category : System.Web.UI.Page
    {
        ConCls obj = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            

            string s = "~/Category_image/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(s));

            string ins = "insert into Category_Tab values('" + TextBox1.Text + "','"+s+"','" + TextBox2.Text + "','"+TextBox3.Text+"')";
            int i = obj.Fn_NonQuery(ins);
            if(i!=0)

            {
                Label4.Text = "inserted";
            }
        }
    }
}