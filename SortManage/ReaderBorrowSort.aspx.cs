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

public partial class SortManage_ReaderBorrowSort : System.Web.UI.Page
{
    ReaderManage readermanage = new ReaderManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "学生租借排行页面";
        if (!IsPostBack)
        {
            gvBind();
        }
    }
    protected void gvReaderSort_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvReaderSort.PageIndex = e.NewPageIndex;
        gvBind();
    }
    protected void gvReaderSort_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int id = e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }
    protected void gvBind()
    {
        DataSet readerds = readermanage.GetReaderSort("tb_reader");
        gvReaderSort.DataSource = readerds;
        gvReaderSort.DataBind();
    }
}
