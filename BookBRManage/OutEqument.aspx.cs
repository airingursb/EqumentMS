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

public partial class EqumentROManage_OutEqument : System.Web.UI.Page
{
    ReaderManage readermanage = new ReaderManage();
    RTypeManage rtypemanage = new RTypeManage();
    EqumentManage bookmanage = new EqumentManage();
    BTypeManage btypemanage = new BTypeManage();
    ReserveandOutManage reserveandoutmanage = new ReserveandOutManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "设备领取页面";
        if (!IsPostBack)
        {
            if (Session["role"] == "Reader")
            {
                txtReaderID.Text = Session["readid"].ToString();
            }
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

            gvROEquBind();
            Session["readerid"] = txtReaderID.Text;
        }
    }
    protected void gvOutBook_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOutBook.PageIndex = e.NewPageIndex;
        gvROEquBind();
    }
    protected void gvOutBook_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (Session["readerid"] == null)
        {
            Response.Write("<script>alert('请输入学号！')</script>");
        }
        else
        {
            reserveandoutmanage.ID = gvOutBook.DataKeys[e.RowIndex].Value.ToString();
            reserveandoutmanage.IsOut = true;
            reserveandoutmanage.UpdateOutBook(reserveandoutmanage);
            gvROEquBind();

  //          readermanage.ID = Session["readerid"].ToString();
  //          DataSet readerds = readermanage.FindReaderByCode(readermanage, "tb_reader");
   //         readermanage.BorrowNum = Convert.ToInt32(readerds.Tables[0].Rows[0][12].ToString());
   //         readermanage.Num = Convert.ToInt32(readerds.Tables[0].Rows[0][13].ToString()) - 1;
   //         readermanage.UpdateBorrowNum(readermanage);
        }
    }
    protected void gvROEquBind()
    {
        reserveandoutmanage.ReadID = txtReaderID.Text;
        DataSet brinfods = reserveandoutmanage.FindReOuEquByRID(reserveandoutmanage, "view_EquROInfo");
        gvOutBook.DataSource = brinfods;
        gvOutBook.DataKeyNames = new string[] { "id" };
        gvOutBook.DataBind();
    }
}
