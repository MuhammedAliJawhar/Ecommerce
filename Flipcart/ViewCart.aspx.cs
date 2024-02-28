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
    public partial class ViewCart : System.Web.UI.Page
    {
        ConCls obj = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Bind_Grid();
        }
        public void Bind_Grid()
        {
            string s = "select * from Cart";
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

            TextBox txtprice = (TextBox)GridView1.Rows[i].Cells[5].Controls[0];
            TextBox txtqty = (TextBox)GridView1.Rows[i].Cells[4].Controls[0];
            TextBox txtpid = (TextBox)GridView1.Rows[i].Cells[3].Controls[0];

            string sel = "select Product_Price from Product where Product_Id=" + txtpid.Text + "";
            string pid = obj.Fn_Scalar(sel);
            int proid = Convert.ToInt32(pid);
            int qnty = Convert.ToInt32(txtqty.Text);
            int price_tot = proid * qnty;
            string strup = "update Cart set Quantity='" + txtqty.Text + "',Total_Price='" + price_tot + "'where Product_Id=" + Session["pid"] + "";
            obj.Fn_NonQuery(strup);

            GridView1.EditIndex = -1;
            Bind_Grid();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select Max(Cart_Id)from Cart";
            string maid = obj.Fn_Scalar(sel);
            int mid = Convert.ToInt32(maid);
            int cartid = 0, proid = 0, userid = 0, qty = 0;
            decimal tot = 0;
            for(int i=1;i<=mid;i++)
            {
                string sel1 = "select * from Cart where Cart_Id=" + i + "";
                SqlDataReader dr = obj.Fn_DataReader(sel1);
                while(dr.Read())
                {
                    cartid = Convert.ToInt32(dr["Cart_Id"].ToString());
                    userid = Convert.ToInt32(dr["User_Id"].ToString());
                    proid = Convert.ToInt32(dr["Product_Id"].ToString());
                    qty = Convert.ToInt32(dr["Quantity"].ToString());
                    tot = Convert.ToDecimal(dr["Total_Price"].ToString());
                }
                string ins = "insert into Order_Tab values("+i+","+userid+","+proid+",'"+qty+"',"+tot+ ",'pending','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
                int j = obj.Fn_NonQuery(ins);
                

                string del = "delete from cart where Cart_Id=" + i + "";
                obj.Fn_NonQuery(del);
                
            }
            string str = "select sum(Total_Price) from Order_Tab where User_Id=" + userid + "";
            string Gtot = obj.Fn_Scalar(str).ToString();
            decimal Gtotal = Convert.ToDecimal(Gtot);
            string ins1 = "insert into Bill values(" + userid + ",'"+DateTime.Now.ToString("yyyy-MM-dd")+"',"+Gtotal+",'pending')";
            obj.Fn_NonQuery(ins1);

            Response.Redirect("View_Bill.aspx");

        }
    }
}