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
    public partial class Add_Product : System.Web.UI.Page
    {
        ConCls obj = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string str = "select Category_Id,Category_Name from Category_Tab";
                DataSet ds = obj.Fn_Dataset(str);
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "Category_Name";
                DropDownList1.DataValueField = "Category_Id";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "-Select-");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "~/Product_Image/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(s));

            string ins = "insert into Product values('"+DropDownList1.SelectedItem.Value+"','" + TextBox1.Text + "','" + s + "'," + TextBox2.Text + ",'" + TextBox3.Text + "','Available','"+TextBox4.Text+"')";
            int i = obj.Fn_NonQuery(ins);
            if (i != 0)

            {
                Label7.Text = "inserted";
            }
        }
    }
}