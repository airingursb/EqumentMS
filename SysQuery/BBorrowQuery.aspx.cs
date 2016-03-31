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

public partial class SysQuery_BBorrowQuery : System.Web.UI.Page
{
    BorrowandBackManage borrowandbackmanage = new BorrowandBackManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "设备租借查询页面";
        if (!IsPostBack)
        {
            gvBind();
        }
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        gvBind();
    }
    protected void gvBorrowInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBorrowInfo.PageIndex = e.NewPageIndex;
        gvBind();
    }
    protected void ddlCondition_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCondition.SelectedValue == "租借时间")
        {
            Label1.Visible = Label2.Visible = Label3.Visible = txtFTime.Visible = txtTTime.Visible = true;
            txtCondition.Visible = false;
        }
        else
        {
            Label1.Visible = Label2.Visible = Label3.Visible = txtFTime.Visible = txtTTime.Visible = false;
            txtCondition.Visible = true;
        }
    }
    protected void gvBind()
    {
        DataSet ds = null;
        int intCondition = ddlCondition.SelectedIndex;
        if (intCondition <= 3)
        {
            if (txtCondition.Text == "")
            {
                ds = borrowandbackmanage.GetAllBoBaBook("view_BookBRInfo");
            }
            else
            {
                switch (intCondition)
                {
                    case 0:
                        borrowandbackmanage.EquCode = txtCondition.Text;
                        ds = borrowandbackmanage.FindBoBaBookByBCode(borrowandbackmanage, "view_BookBRInfo");
                        break;
                    case 1:
                        borrowandbackmanage.EquName= txtCondition.Text;
                        ds = borrowandbackmanage.FindBoBaBookByBName(borrowandbackmanage, "view_BookBRInfo");
                        break;
                    case 2:
                        borrowandbackmanage.ReadID = txtCondition.Text;
                        ds = borrowandbackmanage.FindBoBaBookByReaderID(borrowandbackmanage, "view_BookBRInfo");
                        break;
                    case 3:
                        borrowandbackmanage.Name = txtCondition.Text;
                        ds = borrowandbackmanage.FindBoBaBookByReader(borrowandbackmanage, "view_BookBRInfo");
                        break;
                }
            }
        }
        else
        {
            if (txtFTime.Text == "" || txtTTime.Text == "")
            {
                Response.Write("<script>alert('请输入正确的租借时间')</script>");
            }
            else
            {
                borrowandbackmanage.FromTime = Convert.ToDateTime(txtFTime.Text);
                borrowandbackmanage.ToTime = Convert.ToDateTime(txtTTime.Text);
                ds = borrowandbackmanage.FindBoBaBookByBoTime(borrowandbackmanage, "view_BookBRInfo");
            }

        }
        gvBorrowInfo.DataSource = ds;
        gvBorrowInfo.DataBind();
    }
}
