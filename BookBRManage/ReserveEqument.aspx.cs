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

public partial class EquREManage_ReserveEqu : System.Web.UI.Page
{
    ReaderManage readermanage = new ReaderManage();
    RTypeManage rtypemanage = new RTypeManage();
    EqumentManage bookmanage = new EqumentManage();
    BTypeManage btypemanage = new BTypeManage();
    ReserveandOutManage reserveandoutmanage = new ReserveandOutManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "设备预定页面";
        if (Request.Cookies["Info"] != null)
        {
            String temp = Convert.ToString(Request.Cookies["Info"].Values["id"]);
            if (temp == "")
            {
                Response.Write("null");
            }
            else
            {
                txtReaderID.Text = temp;
            }
        }
        else
        {
            Response.Write("error");
        }
        txtReaderID.Text = Session["Name"].ToString();
        if (!IsPostBack)
        {
            if (Session["role"] == "Reader")
            {
                txtReaderID.Text = Session["readid"].ToString();
            }
            gvBInfoBind();
        }
    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        if (txtReaderID.Text == "")
        {
            Response.Write("<script>alert('学号不能为空！')</script>");
        }
        else
        {
            readermanage.ID = txtReaderID.Text;
            DataSet readerds = readermanage.FindReaderByCode(readermanage, "tb_reader");
            if (readerds.Tables[0].Rows.Count > 0)
            {
                txtReader.Text = readerds.Tables[0].Rows[0][1].ToString();
                txtSex.Text = readerds.Tables[0].Rows[0][2].ToString();
                txtPaperType.Text = readerds.Tables[0].Rows[0][5].ToString();
                txtPaperNum.Text = readerds.Tables[0].Rows[0][6].ToString();
                txtRType.Text = readerds.Tables[0].Rows[0][3].ToString();
            }
            else
            {
                Response.Write("<script>alert('该学生不存在！')</script>");
                return;
            }

            rtypemanage.Name = txtRType.Text;
            DataSet rtypeds = rtypemanage.FindRTypeByName(rtypemanage, "tb_readertype");
            txtBNum.Text = rtypeds.Tables[0].Rows[0][2].ToString();

            gvBRBookBind();
            Session["readerid"] = txtReaderID.Text;
        }
    }

    protected void gvEquInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEquInfo.PageIndex = e.NewPageIndex;
        gvBInfoBind();
    }
    protected void gvReserveEqu_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvReserveEqu.PageIndex = e.NewPageIndex;
        gvBRBookBind();
    }
    protected void gvEquInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (Session["readerid"] == null)
        {
            Response.Write("<script>alert('请输入学号！')</script>");
        }
        else
        {
            readermanage.ID = Session["readerid"].ToString();
            DataSet readerds = readermanage.FindReaderByCode(readermanage, "tb_reader");
            if (Convert.ToInt32(readerds.Tables[0].Rows[0][13].ToString()) >= Convert.ToInt32(txtBNum.Text))
            {
                Response.Write("<script>alert('您最多可以借" + txtBNum.Text + "台设备！')</script>");
            }
            else
            {
                reserveandoutmanage.ID = reserveandoutmanage.GetBorrowBookID();
                reserveandoutmanage.ReadID = Session["readerid"].ToString();
                reserveandoutmanage.EquCode = gvEquInfo.DataKeys[e.RowIndex].Value.ToString();
                reserveandoutmanage.ReserveTime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                btypemanage.TypeName = gvEquInfo.Rows[e.RowIndex].Cells[2].Text;
               // int days = Convert.ToInt32(btypemanage.FindBTypeByName(btypemanage, "tb_booktype").Tables[0].Rows[0][2].ToString());
                //TimeSpan tspan = TimeSpan.FromDays((double)days);
                reserveandoutmanage.Reserver = Session["Name"].ToString();
                reserveandoutmanage.AddReserve(reserveandoutmanage);
                gvBRBookBind();

            }
        }
    }
    protected void gvBInfoBind()
    {
        DataSet bookds = bookmanage.GetAllBook("tb_equinfo");
        gvEquInfo.DataSource = bookds;
        gvEquInfo.DataKeyNames = new string[] { "equcode" };
        gvEquInfo.DataBind();
    }
    protected void gvBRBookBind()
    {
        reserveandoutmanage.ReadID = txtReaderID.Text;
        DataSet brinfods = reserveandoutmanage.FindReOuEquByRID(reserveandoutmanage, "view_EquROInfo");
        gvReserveEqu.DataSource = brinfods;
        gvReserveEqu.DataBind();
    }

}
