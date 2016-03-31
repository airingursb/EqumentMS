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

public partial class SysSet_BCaseManage : System.Web.UI.Page
{
    CaseManage bookcasemanage = new CaseManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "书架管理页面";
        if (!IsPostBack)
            gvBind();
    }
    protected void gvBCaseInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBCaseInfo.PageIndex = e.NewPageIndex;
        gvBind();
    }
    protected void gvBCaseInfo_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvBCaseInfo.EditIndex = e.NewEditIndex;
        gvBind();
    }
    protected void gvBCaseInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        bookcasemanage.ID= gvBCaseInfo.DataKeys[e.RowIndex].Value.ToString();
        bookcasemanage.Name = ((TextBox)(gvBCaseInfo.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
        bookcasemanage.UpdateBookcase(bookcasemanage);
        gvBCaseInfo.EditIndex = -1;
        gvBind();
    }
    protected void gvBCaseInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvBCaseInfo.EditIndex = -1;
        gvBind();
    }
    protected void gvBCaseInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        bookcasemanage.ID= gvBCaseInfo.DataKeys[e.RowIndex].Value.ToString();
        bookcasemanage.DeleteBookcase(bookcasemanage);
        Response.Write("<script>alert('书架信息删除成功')</script>");
        gvBind();
    }
    private void gvBind()
    {
        DataSet ds = bookcasemanage.GetAllBCase("tb_case");
        gvBCaseInfo.DataSource = ds;
        gvBCaseInfo.DataKeyNames = new string[] { "id" };
        gvBCaseInfo.DataBind();
    }
}
