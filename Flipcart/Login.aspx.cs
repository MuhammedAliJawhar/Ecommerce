using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Flipcart
{
    public partial class Login : System.Web.UI.Page
    {
        ConCls ob = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count(Registration_Id) from Login where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
            string cid = ob.Fn_Scalar(str);
            int cid1 = Convert.ToInt32(cid);
            if (cid1 == 1)
            {
                string str1 = "select Registration_Id from Login where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
                string regid = ob.Fn_Scalar(str1);
                Session["userid"] = regid;
                string str2 = "select Login_Type from Login where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
                string logtype = ob.Fn_Scalar(str2);

                string str3 = "select  User_Status from User_Tab where User_Id=" + Session["userid"] + "";
                string logstz = ob.Fn_Scalar(str3);

                if (logtype == "admin")
                {
                    Label3.Text = "Admin";
                    Response.Redirect("Admin_Home.aspx");
                }
                else if (logtype == "user")
                {
                    if(logstz=="active")
                    {
                        Response.Redirect("User_Home.aspx");
                    }
                    else
                    {
                        Label3.Text = "User Blocked Error";
                    }
                    
                }
            }
        }
    }
}