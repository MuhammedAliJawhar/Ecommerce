using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Flipcart
{
    public partial class User : System.Web.UI.Page
    {
        ConCls obj = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select max(Registration_Id) from Login ";
            string regid = obj.Fn_Scalar(sel);
            int registration_id = 0;
            if(regid== "")
            {
                registration_id = 1;
            }
            else
            {
                int newregid = Convert.ToInt32(regid);
                registration_id =newregid + 1;
            }
            string ins = "insert into User_Tab values(" + registration_id + ",'" + TextBox1.Text + "'," + TextBox2.Text + ",'" + TextBox3.Text + "'," + TextBox4.Text + ",'" + TextBox5.Text + "','"+RadioButtonList1.SelectedItem.Text+"','"+TextBox6.Text+"','"+DropDownList1.SelectedItem.Text+"','"+TextBox7.Text+ "','active')";
            int i = obj.Fn_NonQuery(ins);
            if(i !=0)
            {
                string inslog = "insert into Login values(" + registration_id + ",'" + TextBox8.Text + "','" + TextBox9.Text + "','user')";
                int j = obj.Fn_NonQuery(inslog);
            }
        }

        
    }
}