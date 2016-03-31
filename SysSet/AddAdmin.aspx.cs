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

public partial class SysSet_AddAdmin : System.Web.UI.Page
{
    AdminManage adminmanage = new AdminManage();
    PurviewManage purviewmanage = new PurviewManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "添加管理员页面";
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "")
        {
            Response.Write("<script>alert('管理员名称不能为空！');location='javascript:history.go(-1)';</script>");
        }
        else
        {
            adminmanage.ID = adminmanage.GetAdminID();
            adminmanage.Name = txtName.Text;
            adminmanage.Pwd = txtPwd.Text;
            if (adminmanage.GetAllAdminByName(adminmanage, "tb_admin").Tables[0].Rows.Count > 0)
            {
                Response.Write("<script>alert('该管理员已经存在！')</script>");
                return;
            }
            adminmanage.AddAdmin(adminmanage);
            purviewmanage.ID = adminmanage.ID;
            purviewmanage.AddPurview(purviewmanage);
            Response.Redirect("AdminManage.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtName.Text = txtPwd.Text = txtSPwd.Text = string.Empty;
    }
}
