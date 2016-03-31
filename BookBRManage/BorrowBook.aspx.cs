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

public partial class BookBRManage_BorrowBook : System.Web.UI.Page
{
    ReaderManage readermanage = new ReaderManage();
    RTypeManage rtypemanage = new RTypeManage();
    EqumentManage bookmanage = new EqumentManage();
    BTypeManage btypemanage = new BTypeManage();
    BorrowandBackManage borrowandbackmanage = new BorrowandBackManage();
    private int days = 0;

    public int Days
    {
        get { return days; }
        set { days = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "设备租借页面";
        if (!IsPostBack)
        {
            if (Session["role"] == "Reader")
            {
                txtDay.Text = "0";
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

    protected void gvBookInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBookInfo.PageIndex = e.NewPageIndex;
    }
    protected void gvBorrowBook_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBorrowBook.PageIndex = e.NewPageIndex;
        gvBRBookBind();
    }
    protected void gvBookInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
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
                borrowandbackmanage.ID = borrowandbackmanage.GetBorrowBookID();
                borrowandbackmanage.ReadID = Session["readerid"].ToString();
                borrowandbackmanage.EquCode = gvBookInfo.DataKeys[e.RowIndex].Value.ToString();
                borrowandbackmanage.BorrowTime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                btypemanage.TypeName = gvBookInfo.Rows[e.RowIndex].Cells[2].Text;
       
                int temp = int.Parse(Session["days"].ToString());
                TimeSpan tspan = TimeSpan.FromDays((double)temp);
                borrowandbackmanage.YGBackTime = borrowandbackmanage.BorrowTime + tspan;
                borrowandbackmanage.BorrowOper = Session["Name"].ToString();
                borrowandbackmanage.AddBorrow(borrowandbackmanage);
                gvBRBookBind();


                bookmanage.EquCode = gvBookInfo.DataKeys[e.RowIndex].Value.ToString();
                DataSet bookds = bookmanage.FindBookByCode(bookmanage, "tb_equinfo");
//                bookmanage.BorrowNum = Convert.ToInt32(bookds.Tables[0].Rows[0][12].ToString()) + 1;
                bookmanage.UpdateBorrowNum(bookmanage);

                readermanage.BorrowNum = Convert.ToInt32(readerds.Tables[0].Rows[0][12].ToString()) + 1;
                readermanage.Num = Convert.ToInt32(readerds.Tables[0].Rows[0][13].ToString()) + 1;
                readermanage.UpdateBorrowNum(readermanage);
            }
        }
    }
    protected void gvBInfoBind()
    {
        DataSet bookds = bookmanage.GetAllBook("tb_equinfo");
        gvBookInfo.DataSource = bookds;
        gvBookInfo.DataKeyNames = new string[] { "equcode" };
        gvBookInfo.DataBind();
    }
    protected void gvBRBookBind()
    {
        borrowandbackmanage.ReadID = txtReaderID.Text;
        DataSet brinfods = borrowandbackmanage.FindBoBaBookByRID(borrowandbackmanage, "view_BookBRInfo");
        gvBorrowBook.DataSource = brinfods;
        gvBorrowBook.DataBind();
    }

    protected void btnDay_Command(object sender, CommandEventArgs e)
    {
        days = int.Parse(txtDay.Text.ToString());
        Session["days"] = txtDay.Text;
    }
}
