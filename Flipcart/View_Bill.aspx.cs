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
    public partial class View_Bill : System.Web.UI.Page
    {
        ConCls obj = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {
          if(!IsPostBack)
            {
                string sel = "select Product.Product_Image,Product.Product_Name,Product.Product_Price,Order_Tab.Total_Price,Order_Tab.Quantity from Product join Order_Tab on Order_Tab.Product_Id=Product.Product_Id";
                DataSet ds = obj.Fn_Dataset(sel);
                DataList1.DataSource = ds;
                DataList1.DataBind();

                string sel1 = "select Bill_Total from Bill where User_Id="+Session["userid"]+"";
                string btot = obj.Fn_Scalar(sel1).ToString();
                Label5.Text = btot;

                string sel2 = "select User_Name,User_Address from User_Tab where User_id="+Session["userid"]+"";
                SqlDataReader dr = obj.Fn_DataReader(sel2);
                while (dr.Read())
                {
                    Label6.Text = dr["User_Name"].ToString();
                    Label7.Text = dr["User_Address"].ToString();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "insert into Ac_Tab values('" + TextBox1.Text + "'," + Session["userid"] + ",'" + TextBox2.Text + "')";
            int i = obj.Fn_NonQuery(str);

            if (i != 0)
            {

                string sel = "select AccoNo from Ac_Tab where User_Id=" + Session["userid"] + "";
                string ano = obj.Fn_Scalar(sel);
                Session["accno"] = ano;
                Response.Redirect("Payment_Bridge.aspx");
            }
        }
    }
}