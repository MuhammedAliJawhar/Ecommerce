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
    public partial class Payment_Bridge : System.Web.UI.Page
    {
        ConCls obj= new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            string acd = "select Ac_Tab.AccoNo,Bill.Bill_Total from Ac_Tab join Bill on Ac_Tab.User_Id=Bill.User_Id";
            SqlDataReader dr = obj.Fn_DataReader(acd);
            while(dr.Read())
            {
                Label3.Text = dr["AccoNo"].ToString();
                Label4.Text = dr["Bill_Total"].ToString();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Bank_Payment.ServiceClient ob = new Bank_Payment.ServiceClient();
            string s = ob.BalanceCheck(Label3.Text);

            if(Convert.ToInt32(s)>Convert.ToInt32(Label4.Text))
            {
                int newbal = Convert.ToInt32(s) - Convert.ToInt32(Label4.Text);
                string success = ob.BalanceUpdate(Label3.Text, Convert.ToString(newbal));
                if(success=="1")
                {
                    Label5.Text = "payment successfull";
                    string str = "update Order_Tab set Order_Status='paid' where User_Id=" + Session["userid"] + "";
                    obj.Fn_NonQuery(str);

                    string str1 = "update Bill set Bill_Status='paid' where User_Id=" + Session["userid"] + "";
                    obj.Fn_NonQuery(str1);

                    string sel = "select Max(Cart_Id) from Order_Tab";
                    string maxcid = obj.Fn_Scalar(sel);
                    int maxid = Convert.ToInt32(maxcid);
                    for(int i=1;i<=maxid;i++)
                    {
                        int pid = 0, qty = 0, new_stk = 0;
                        string sel1 = "select Product_Id,Quantity from Order_Tab where Cart_Id=" + i + "";
                        SqlDataReader dr = obj.Fn_DataReader(sel1);
                        while(dr.Read())
                        {
                            pid = Convert.ToInt32(dr["Product_Id"].ToString());
                            qty = Convert.ToInt32(dr["Quantity"].ToString());
                        }
                        string sel2 = "select Product_Stock from Product where Product_Id=" + pid + "";
                        string stock = obj.Fn_Scalar(sel2);
                        int stk = Convert.ToInt32(stock);
                        new_stk = stk - qty;
                        string upt1 = "update Product set Product_Stock='" + Convert.ToString(new_stk) + "' where Product_Id=" + pid + "";
                        int j = obj.Fn_NonQuery(upt1);
                        string sel3 = "select Product_Stock from Product";
                        string upstk = obj.Fn_Scalar(sel3);
                        if(upstk=="0")
                        {
                            string upt2 = "update Product set Product_Stock='Out of Stock' and set Product_Status='Unavailable' where Product_Id=" + pid + "";
                            obj.Fn_NonQuery(upt2);
                        }
                    }
                }
            }
            else
            {
                Label5.Text = "Insufficient Balance";
            }
        }
    }
}