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

public partial class SysSet_LibraryInfo : System.Web.UI.Page
{
    ValidateClass validate = new ValidateClass();
    LibraryManage librarymanage = new LibraryManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "实验室信息页面";
        if (!IsPostBack)
        {
            DataSet ds = librarymanage.GetAllLib("tb_library");
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtLibName.Text = ds.Tables[0].Rows[0][0].ToString();
                txtCurator.Text = ds.Tables[0].Rows[0][1].ToString();
                txtTel.Text = ds.Tables[0].Rows[0][2].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0][3].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][4].ToString();
                txtUrl.Text = ds.Tables[0].Rows[0][5].ToString();
                txtCDate.Text = ds.Tables[0].Rows[0][6].ToString();
                txtIntroduce.Text = ds.Tables[0].Rows[0][7].ToString();
                btnSave.Text = "保存";
            }
            else
            {
                btnSave.Text = "添加";
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtLibName.Text == "")
        {
            Response.Write("<script>alert('实验室名称不能为空！');location='javascript:history.go(-1)';</script>");
            return;
        }
        if (!validate.validateNum(txtTel.Text))
        {
            Response.Write("<script>alert('电话输入有误！');location='javascript:history.go(-1)';</script>");
            return;
        }
        if (!validate.validateEmail(txtEmail.Text))
        {
            Response.Write("<script>alert('Email地址输入有误！');location='javascript:history.go(-1)';</script>");
            return;
        }
        if (!validate.validateNAddress(txtUrl.Text))
        {
            Response.Write("<script>alert('网址格式输入有误！');location='javascript:history.go(-1)';</script>");
            return;
        }
        librarymanage.LibraryName = txtLibName.Text;
        librarymanage.Curator = txtCurator.Text;
        librarymanage.Tel = txtTel.Text;
        librarymanage.Address = txtAddress.Text;
        librarymanage.Email = txtEmail.Text;
        librarymanage.URL = txtUrl.Text;
        librarymanage.CreateDate = Convert.ToDateTime(Convert.ToDateTime(txtCDate.Text).ToShortDateString());
        librarymanage.Introduce = txtIntroduce.Text;
        if (btnSave.Text == "保存")
        {
            librarymanage.UpdateLib(librarymanage);
            Response.Write("<script language=javascript>alert('实验室信息保存成功！')</script>");
        }
        else if (btnSave.Text == "添加")
        {
            librarymanage.AddLib(librarymanage);
            Response.Write("<script language=javascript>alert('实验室信息添加成功！')</script>");
            btnSave.Text = "保存";
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtCDate.Text = DateTime.Now.ToShortDateString();
        txtCurator.Text = txtTel.Text = txtAddress.Text = txtEmail.Text = txtUrl.Text = txtIntroduce.Text = string.Empty;
    }
}
