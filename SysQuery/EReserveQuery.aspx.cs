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

public partial class SysQuery_EReserveQuery : System.Web.UI.Page
{
    ReserveandOutManage reserveandoutmanage = new ReserveandOutManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "设备预定查询页面";
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
        if (ddlCondition.SelectedValue == "预定时间")
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
                ds = reserveandoutmanage.GetAllReOuEqu("view_EquROInfo");
            }
            else
            {
                switch (intCondition)
                {
                    case 0:
                        reserveandoutmanage.EquCode = txtCondition.Text;
                        ds = reserveandoutmanage.FindReOuEquByBCode(reserveandoutmanage, "view_EquROInfo");
                        break;
                    case 1:
                        reserveandoutmanage.EquName = txtCondition.Text;
                        ds = reserveandoutmanage.FindReOuEquByBName(reserveandoutmanage, "view_EquROInfo");
                        break;
                    case 2:
                        reserveandoutmanage.ReadID = txtCondition.Text;
                        ds = reserveandoutmanage.FindReOuEquByReaderID(reserveandoutmanage, "view_EquROInfo");
                        break;
                    case 3:
                        reserveandoutmanage.Name = txtCondition.Text;
                        ds = reserveandoutmanage.FindReOuEquByReader(reserveandoutmanage, "view_EquROInfo");
                        break;
                }
            }
        }
        else
        {
            if (txtFTime.Text == "" || txtTTime.Text == "")
            {
                Response.Write("<script>alert('请输入正确的预定时间')</script>");
            }
            else
            {
                reserveandoutmanage.FromTime = Convert.ToDateTime(txtFTime.Text);
                reserveandoutmanage.ToTime = Convert.ToDateTime(txtTTime.Text);
                ds = reserveandoutmanage.FindReOuEquByBoTime(reserveandoutmanage, "view_EquROInfo");
            }

        }
        gvBorrowInfo.DataSource = ds;
        gvBorrowInfo.DataBind();
    }

    protected void gvBorrowInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = null;
        reserveandoutmanage.IsOut = true;
        reserveandoutmanage.UpdateOutBook(reserveandoutmanage);
        ds = reserveandoutmanage.GetAllReOuEqu("view_EquROInfo");
        gvBorrowInfo.DataSource = ds;
        gvBorrowInfo.DataBind();
    }
}
