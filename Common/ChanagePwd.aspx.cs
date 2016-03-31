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

public partial class Common_ChanagePwd : System.Web.UI.Page
{
    AdminManage adminmanage = new AdminManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "更改口令页面";
        if (!IsPostBack)
        {
            txtName.Text = Session["Name"].ToString();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        adminmanage.Name = txtName.Text;
        DataSet ds = adminmanage.GetAllAdminByName(adminmanage, "tb_admin");
        if (txtYPwd.Text == ds.Tables[0].Rows[0][2].ToString())
        {
            adminmanage.Pwd = txtXPwd.Text;
            adminmanage.UpdateAdmin(adminmanage);
            Response.Write("<script>alert('密码修改成功！')</script>");
        }
        else
        {
            Response.Write("<script>alert('管理员原密码输入不正确！')</script>");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtYPwd.Text = txtXPwd.Text = txtSXPwd.Text = string.Empty;
    }
}
