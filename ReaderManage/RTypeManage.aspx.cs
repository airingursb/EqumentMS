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

public partial class ReaderManage_RTypeManage : System.Web.UI.Page
{
    RTypeManage rtypemanage = new RTypeManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "查看学生类型页面";
        if (!IsPostBack)
            gvBind();
    }
    protected void gvRTypeInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRTypeInfo.PageIndex = e.NewPageIndex;
        gvBind();
    }
    protected void gvRTypeInfo_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvRTypeInfo.EditIndex = e.NewEditIndex;
        gvBind();
    }
    protected void gvRTypeInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        rtypemanage.ID = Convert.ToInt32(gvRTypeInfo.DataKeys[e.RowIndex].Value.ToString());
        rtypemanage.Name = ((TextBox)(gvRTypeInfo.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
        rtypemanage.Number = Convert.ToInt32(((TextBox)(gvRTypeInfo.Rows[e.RowIndex].Cells[2].Controls[0])).Text);
        rtypemanage.UpdateRType(rtypemanage);
        gvRTypeInfo.EditIndex = -1;
        gvBind();
    }
    protected void gvRTypeInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvRTypeInfo.EditIndex = -1;
        gvBind();
    }
    protected void gvRTypeInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        rtypemanage.ID = Convert.ToInt32(gvRTypeInfo.DataKeys[e.RowIndex].Value.ToString());
        rtypemanage.DeleteRType(rtypemanage);
        Response.Write("<script>alert('学生类型信息删除成功')</script>");
        gvBind();
    }
    private void gvBind()
    {
        DataSet ds = rtypemanage.GetAllRType("tb_readertype");
        gvRTypeInfo.DataSource = ds;
        gvRTypeInfo.DataKeyNames = new string[] { "id" };
        gvRTypeInfo.DataBind();
    }
}
