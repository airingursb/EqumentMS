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

public partial class SortManage_BookBorrowSort : System.Web.UI.Page
{
    EqumentManage bookmanage = new EqumentManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "设备租借排行页面";
        if (!IsPostBack)
        {
            gvBind();
        }
    }
    protected void gvBookSort_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBookSort.PageIndex = e.NewPageIndex;
        gvBind();
    }
    protected void gvBookSort_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int id = e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }
    protected void gvBind()
    {
        DataSet bookds = bookmanage.GetAllBookSort("tb_equinfo");
        gvBookSort.DataSource = bookds;
        gvBookSort.DataBind();
    }
}
