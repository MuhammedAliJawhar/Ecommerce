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
    public partial class Product_Details : System.Web.UI.Page
    {
        ConCls obj = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sel = "select * from Product where Product_Id="+Session["pid"]+"";
            SqlDataReader dr = obj.Fn_DataReader(sel);
            while (dr.Read())
            {
                Image1.ImageUrl = dr["Product_Image"].ToString();
                Label1.Text = dr["Product_Name"].ToString();
                Label2.Text = dr["Product_Price"].ToString();
                Label3.Text = dr["Product_Description"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select max(Cart_Id) from Cart";
            string cartid = obj.Fn_Scalar(sel);
            int Cart_Id = 0;
            if(cartid=="")
            {
                Cart_Id = 1;
            }
            else
            {
                int newcartid = Convert.ToInt32(cartid);
                Cart_Id = newcartid + 1;
            }
            string str1 = "select Product_Price from Product where Product_Id=" + Session["pid"] + "";
            string str2 = obj.Fn_Scalar(str1).ToString();

            int total = (Convert.ToInt32(str2))*(Convert.ToInt32(TextBox1.Text));
            string total_price = Convert.ToString(total);

            string str3 = "insert into Cart values("+Cart_Id+",'" + Session["userid"] + "','"+Session["pid"]+"','" + TextBox1.Text + "',"+total+")";
            int i = obj.Fn_NonQuery(str3);
            if (i != 0)
            {
                Label5.Text = "inserted";

            }
        }
    }
}