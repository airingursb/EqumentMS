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

public partial class _Default : System.Web.UI.Page
{
    EqumentManage bookmanage = new EqumentManage();
    ReaderManage readermanage = new ReaderManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "实验室管理系统主页";
        DataSet bookds = bookmanage.GetBookSort("tb_equinfo");
        gvBookSort.DataSource = bookds;
        gvBookSort.DataBind();

        DataSet readerds = readermanage.GetReaderSort("tb_reader");
        gvReaderSort.DataSource = readerds;
        gvReaderSort.DataBind();
    }
    protected void gvBookSort_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int id = e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }
    protected void gvReaderSort_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        gvBookSort_RowDataBound(sender, e);
    }
}
