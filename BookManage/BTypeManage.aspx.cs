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

public partial class BookManage_BTypeManage : System.Web.UI.Page
{
    BTypeManage btypemanage = new BTypeManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "查看设备类型页面";
        if (!IsPostBack)
            gvBind();
    }
    protected void gvBTypeInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBTypeInfo.PageIndex = e.NewPageIndex;
        gvBind();
    }
    protected void gvBTypeInfo_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvBTypeInfo.EditIndex = e.NewEditIndex;
        gvBind();
    }
    protected void gvBTypeInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        btypemanage.ID = Convert.ToInt32(gvBTypeInfo.DataKeys[e.RowIndex].Value.ToString());
        btypemanage.TypeName = ((TextBox)(gvBTypeInfo.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
        btypemanage.Days = Convert.ToInt32(((TextBox)(gvBTypeInfo.Rows[e.RowIndex].Cells[2].Controls[0])).Text);
        btypemanage.UpdateBookType(btypemanage);
        gvBTypeInfo.EditIndex = -1;
        gvBind();
    }
    protected void gvBTypeInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvBTypeInfo.EditIndex = -1;
        gvBind();
    }
    protected void gvBTypeInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        btypemanage.ID = Convert.ToInt32(gvBTypeInfo.DataKeys[e.RowIndex].Value.ToString());
        btypemanage.DeleteBookType(btypemanage);
        Response.Write("<script>alert('设备类型信息删除成功')</script>");
        gvBind();
    }
    private void gvBind()
    {
        DataSet ds = btypemanage.GetAllBType("tb_booktype");
        gvBTypeInfo.DataSource = ds;
        gvBTypeInfo.DataKeyNames = new string[] { "id" };
        gvBTypeInfo.DataBind();
    }
}
