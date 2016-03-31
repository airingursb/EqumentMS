using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MasterPage_MainMasterPage : System.Web.UI.MasterPage
{
    OperatorClass operatorclass = new OperatorClass();
    AdminManage adminmanage = new AdminManage();
    PurviewManage purviewmanage = new PurviewManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == "Reader")
        {
            menuNav.Items[1].Enabled = false;
            menuNav.Items[2].Enabled = false;
            menuNav.Items[3].Enabled = false;
            menuNav.Items[5].Enabled = false;
        }
        else
        {
            labDate.Text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日";
            labXQ.Text = operatorclass.getWeek();
            labAdmin.Text = Session["Name"].ToString();

            adminmanage.Name = Session["Name"].ToString();
            DataSet adminds = adminmanage.GetAllAdminByName(adminmanage, "tb_admin");
            string strAdminID = adminds.Tables[0].Rows[0][0].ToString();
            purviewmanage.ID = strAdminID;
            DataSet pviewds = purviewmanage.FindPurviewByID(purviewmanage, "tb_purview");
            bool sysset = Convert.ToBoolean(pviewds.Tables[0].Rows[0][1].ToString());
            bool readset = Convert.ToBoolean(pviewds.Tables[0].Rows[0][2].ToString());
            bool bookset = Convert.ToBoolean(pviewds.Tables[0].Rows[0][3].ToString());
            bool borrowback = Convert.ToBoolean(pviewds.Tables[0].Rows[0][4].ToString());
            bool sysquery = Convert.ToBoolean(pviewds.Tables[0].Rows[0][5].ToString());

            if (sysset == true)
            {
                menuNav.Items[1].Enabled = true;
            }
            else
            {
                menuNav.Items[1].Enabled = false;
            }

            if (readset == true)
            {
                menuNav.Items[2].Enabled = true;
            }
            else
            {
                menuNav.Items[2].Enabled = false;
            }

            if (bookset == true)
            {
                menuNav.Items[3].Enabled = true;
            }
            else
            {
                menuNav.Items[3].Enabled = false;
            }

            if (borrowback == true)
            {
                menuNav.Items[4].Enabled = true;
            }
            else
            {
                menuNav.Items[4].Enabled = false;
            }

            if (sysquery == true)
            {
                menuNav.Items[5].Enabled = true;
            }
            else
            {
                menuNav.Items[5].Enabled = false;
            }
        }
    }
    protected void menuNav_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (menuNav.SelectedValue == "退出系统")
        {
            Response.Write("<script>window.close();</script>");
        }
    }
}
