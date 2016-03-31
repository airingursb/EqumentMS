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

public partial class ReaderManage_AddReader : System.Web.UI.Page
{
    ValidateClass validate = new ValidateClass();
    RTypeManage rtypemanage = new RTypeManage();
    ReaderManage readermanage = new ReaderManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "添加/修改学生信息页面";
        if (!IsPostBack)
        {
            if (Request["readerid"] == null)
            {
                btnAdd.Enabled = true;
                //txtReaderID.Text = readermanage.GetReaderID();
                txtBirthday.Text = txtDate.Text = DateTime.Now.ToShortDateString();
                txtDate.Text = txtDate.Text = DateTime.Now.ToShortDateString();
            }
            else
            {
                btnSave.Enabled = true;
                txtReaderID.Text = Request["readerid"].ToString();
                readermanage.ID = txtReaderID.Text;
                DataSet readerds = readermanage.FindReaderByCode(readermanage, "tb_reader");
                txtReader.Text = readerds.Tables[0].Rows[0][1].ToString();
                ddlSex.SelectedValue = readerds.Tables[0].Rows[0][2].ToString();
                ddlRType.SelectedValue = readerds.Tables[0].Rows[0][3].ToString();
                txtBirthday.Text = readerds.Tables[0].Rows[0][4].ToString();
                ddlPaperType.SelectedValue = readerds.Tables[0].Rows[0][5].ToString();
                txtPaperNum.Text = readerds.Tables[0].Rows[0][6].ToString();
                txtTel.Text = readerds.Tables[0].Rows[0][7].ToString();
                txtEmail.Text = readerds.Tables[0].Rows[0][8].ToString();
                txtDate.Text = readerds.Tables[0].Rows[0][9].ToString();
                txtOper.Text = readerds.Tables[0].Rows[0][10].ToString();
                txtRemark.Text = readerds.Tables[0].Rows[0][11].ToString();
            }
            DataSet typeds = rtypemanage.GetAllRType("tb_readertype");
            ddlRType.DataSource = typeds;
            ddlRType.DataTextField = "name";
            ddlRType.DataBind();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ValidateFun();
        readermanage.ID = txtReaderID.Text;
        readermanage.Name = txtReader.Text;
        if (readermanage.FindReaderByName(readermanage, "tb_reader").Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('该学生已经存在！')</script>");
            return;
        }
        readermanage.Sex = ddlSex.Text;
        readermanage.Type = ddlRType.Text;
        readermanage.Birthday = Convert.ToDateTime(txtBirthday.Text);
        readermanage.PaperType = ddlPaperType.Text;
        readermanage.PaperNum = txtPaperNum.Text;
        readermanage.Tel = txtTel.Text;
        readermanage.Email = txtEmail.Text;
        readermanage.CreateDate = Convert.ToDateTime(txtDate.Text);
        readermanage.Oper = txtOper.Text;
        readermanage.Remark = txtRemark.Text;
        readermanage.AddReader(readermanage);
        Response.Redirect("ReaderManage.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ValidateFun();
        readermanage.ID = txtReaderID.Text;
        readermanage.Name = txtReader.Text;
        readermanage.Sex = ddlSex.Text;
        readermanage.Type = ddlRType.Text;
        readermanage.Birthday = Convert.ToDateTime(txtBirthday.Text);
        readermanage.PaperType = ddlPaperType.Text;
        readermanage.PaperNum = txtPaperNum.Text;
        readermanage.Tel = txtTel.Text;
        readermanage.Email = txtEmail.Text;
        readermanage.CreateDate = Convert.ToDateTime(txtDate.Text);
        readermanage.Oper = txtOper.Text;
        readermanage.Remark = txtRemark.Text;
        readermanage.UpdateReader(readermanage);
        Response.Redirect("ReaderManage.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtBirthday.Text = txtDate.Text = DateTime.Now.ToShortDateString();
        txtDate.Text = txtDate.Text = DateTime.Now.ToShortDateString();
        txtReader.Text = txtPaperNum.Text = txtTel.Text = txtEmail.Text = txtOper.Text = txtRemark.Text = string.Empty;
    }
    protected void ValidateFun()
    {
        if (txtReader.Text == "")
        {
            Response.Write("<script>alert('学生名称不能为空！');location='javascript:history.go(-1)';</script>");
            return;
        }
        if (!validate.validateNum(txtPaperNum.Text))
        {
            Response.Write("<script>alert('证件号码输入有误！');location='javascript:history.go(-1)';</script>");
            return;
        }
        if (!validate.validatePhone(txtTel.Text))
        {
            Response.Write("<script>alert('电话号码输入有误！');location='javascript:history.go(-1)';</script>");
            return;
        }
        if (!validate.validateEmail(txtEmail.Text))
        {
            Response.Write("<script>alert('Email地址输入有误！');location='javascript:history.go(-1)';</script>");
            return;
        }
    }
}
