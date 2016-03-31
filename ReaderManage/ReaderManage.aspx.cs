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

public partial class ReaderManage_ReaderManage : System.Web.UI.Page
{
    ReaderManage readermanage = new ReaderManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "查看学生信息页面";
        if (!IsPostBack)
            gvBind();
    }
    protected void gvReaderInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvReaderInfo.PageIndex = e.NewPageIndex;
        gvBind();
    }
    protected void gvReaderInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        readermanage.ID = gvReaderInfo.DataKeys[e.RowIndex].Value.ToString();
        readermanage.DeleteReader(readermanage);
        Response.Write("<script>alert('学生信息删除成功')</script>");
        gvBind();
    }
    private void gvBind()
    {
        DataSet ds = readermanage.GetAllReader("tb_reader");
        gvReaderInfo.DataSource = ds;
        gvReaderInfo.DataKeyNames = new string[] { "id" };
        gvReaderInfo.DataBind();
    }
}
