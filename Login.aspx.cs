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

public partial class Login : System.Web.UI.Page
{
    OperatorClass operatorclass = new OperatorClass();
    AdminManage adminmanage = new AdminManage();
    ReaderManage readermanage = new ReaderManage();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtAdmin.Text == string.Empty)
        {
            Response.Write("<script>alert('管理员名称不能为空！')</script>");
            return;
        }
        else
        {
            DataSet adminds = null;
            DataSet readerds = null;
            adminmanage.Name = txtAdmin.Text;
            adminmanage.Pwd = txtPwd.Text;
            adminds = adminmanage.Login(adminmanage);
            readermanage.ID=txtPwd.Text;
            readermanage.Name=txtAdmin.Text;
            readerds=readermanage.ReaderLogin(readermanage);
            if (adminds.Tables[0].Rows.Count > 0 && txtCode.Text == Request.Cookies["CheckCode"].Value)
            {
                Session["Name"] = txtAdmin.Text;
                Response.Redirect("Default.aspx");
            }
            else if (readerds.Tables[0].Rows.Count > 0 && txtCode.Text == Request.Cookies["CheckCode"].Value)
            {
                HttpCookie cookie = new HttpCookie("Info");
                DateTime dt = DateTime.Now;
                TimeSpan ts = new TimeSpan(1, 0, 0, 0);
                cookie.Expires = dt.Add(ts);
                cookie.Values.Add("id", txtAdmin.Text);
                Response.AppendCookie(cookie);
                Session["Name"] = txtAdmin.Text;
                Session["readid"] = txtPwd.Text;
                Session["role"] = "Reader";
                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Write("<script>alert('登录名或密码不正确！')</script>");
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtAdmin.Text = txtPwd.Text = txtCode.Text = string.Empty;
    }
}
