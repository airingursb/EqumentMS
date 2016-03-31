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

public partial class SysSet_AdminManage : System.Web.UI.Page
{
    AdminManage adminmanage = new AdminManage();
    PurviewManage purviewmanage = new PurviewManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "管理员管理页面";
        if (!IsPostBack)
            gvBind();
    }
    protected void gvAdminPurview_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAdminPurview.PageIndex = e.NewPageIndex;
        gvBind();
    }
    protected void gvAdminPurview_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAdminPurview.EditIndex = e.NewEditIndex;
        gvBind();
    }
    protected void gvAdminPurview_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        adminmanage.Name = gvAdminPurview.DataKeys[e.RowIndex].Value.ToString();
        if (adminmanage.Name.ToLower() == "tsoft")
        {
            Response.Write("<script>alert('该用户为超级用户，权限不能修改!')</script>");
        }
        else
        {
            DataSet ds = adminmanage.GetAllAdminByName(adminmanage, "tb_admin");
            string strAdminID = ds.Tables[0].Rows[0][0].ToString();
            purviewmanage.ID = strAdminID;
            purviewmanage.SysSet = ((CheckBox)(gvAdminPurview.Rows[e.RowIndex].Cells[1].Controls[0])).Checked;
            purviewmanage.ReadSet = ((CheckBox)(gvAdminPurview.Rows[e.RowIndex].Cells[2].Controls[0])).Checked;
            purviewmanage.BookSet = ((CheckBox)(gvAdminPurview.Rows[e.RowIndex].Cells[3].Controls[0])).Checked;
            purviewmanage.BorrowBack = ((CheckBox)(gvAdminPurview.Rows[e.RowIndex].Cells[4].Controls[0])).Checked;
            purviewmanage.SysQuery = ((CheckBox)(gvAdminPurview.Rows[e.RowIndex].Cells[5].Controls[0])).Checked;
            purviewmanage.UpdatePurview(purviewmanage);
        }
        gvAdminPurview.EditIndex = -1;
        gvBind();
    }
    protected void gvAdminPurview_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAdminPurview.EditIndex = -1;
        gvBind();
    }
    protected void gvAdminPurview_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        adminmanage.Name = gvAdminPurview.DataKeys[e.RowIndex].Value.ToString();
        if (adminmanage.Name.ToLower() == "tsoft")
        {
            Response.Write("<script>alert('该用户为超级用户，您不能删除!')</script>");
        }
        else
        {
            DataSet ds = adminmanage.GetAllAdminByName(adminmanage, "tb_admin");
            string strAdminID = ds.Tables[0].Rows[0][0].ToString();
            adminmanage.DeleteAdmin(adminmanage);
            purviewmanage.ID = strAdminID;
            purviewmanage.DeletePurview(purviewmanage);
            Response.Write("<script>alert('管理员删除成功')</script>");
        }
        gvBind();
    }
    private void gvBind()
    {
        DataSet ds = purviewmanage.GetAllPurviewByName("view_AdminPurview");
        gvAdminPurview.DataSource = ds;
        gvAdminPurview.DataKeyNames = new string[] { "name" };
        gvAdminPurview.DataBind();
    }
}
