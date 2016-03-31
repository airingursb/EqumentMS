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

public partial class SysSet_AddBCase : System.Web.UI.Page
{
    CaseManage bookcasemanage = new CaseManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "添加书架信息页面";
        txtBCaseID.Text = bookcasemanage.GetBcaseID();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtBCaseName.Text == "")
        {
            Response.Write("<script>alert('书架名称不能为空！');location='javascript:history.go(-1)';</script>");
        }
        else
        {
            bookcasemanage.ID = txtBCaseID.Text;
            bookcasemanage.Name = txtBCaseName.Text;
            if (bookcasemanage.FindBCaseByName(bookcasemanage, "tb_case").Tables[0].Rows.Count > 0)
            {
                Response.Write("<script>alert('该书架已经存在！')</script>");
                return;
            }
            bookcasemanage.AddBookcase(bookcasemanage);
            Response.Redirect("BCaseManage.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtBCaseName.Text = string.Empty;
    }
}
