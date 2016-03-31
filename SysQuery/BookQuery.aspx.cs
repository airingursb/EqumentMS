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

public partial class SysQuery_BookQuery : System.Web.UI.Page
{
    EqumentManage bookmanage = new EqumentManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "设备档案查询页面";
        if (!IsPostBack)
        {
            gvBind();
        }
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        gvBind();
    }
    protected void gvBookInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBookInfo.PageIndex = e.NewPageIndex;
        gvBind();
    }
    protected void gvBind()
    {
        DataSet ds = null;
        int intCondition = ddlCondition.SelectedIndex;
        if (txtCondition.Text == "")
        {
            ds = bookmanage.GetAllBook("tb_equinfo");
        }
        else
        {
            switch (intCondition)
            {
                case 0:
                    bookmanage.EquCode = txtCondition.Text;
                    ds = bookmanage.FindBookByCode(bookmanage, "tb_equinfo");
                    break;
                case 1:
                    bookmanage.EquName = txtCondition.Text;
                    ds = bookmanage.FindBookByName(bookmanage, "tb_equinfo");
                    break;
                case 2:
                    bookmanage.Type = txtCondition.Text;
                    ds = bookmanage.FindBookByType(bookmanage, "tb_equinfo");
                    break;
                case 3:
                    bookmanage.Author = txtCondition.Text;
                    ds = bookmanage.FindBookByAuthor(bookmanage, "tb_equinfo");
                    break;
                case 4:
                    bookmanage.PubName = txtCondition.Text;
                    ds = bookmanage.FindBookByPub(bookmanage, "tb_equinfo");
                    break;
                case 5:
                    bookmanage.Bcase = txtCondition.Text;
                    ds = bookmanage.FindBookByBCase(bookmanage, "tb_equinfo");
                    break;
            }
        }
        gvBookInfo.DataSource = ds;
        gvBookInfo.DataBind();
    }
}
