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

public partial class ReaderManage_AddRType : System.Web.UI.Page
{
    ValidateClass validate = new ValidateClass();
    RTypeManage rtypemanage = new RTypeManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "添加学生类型页面";
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ValidateFun();
        rtypemanage.Name = txtRType.Text;
        if (rtypemanage.FindRTypeByName(rtypemanage, "tb_readertype").Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('该学生类型已经存在！')</script>");
            return;
        }
        rtypemanage.Number = Convert.ToInt32(txtNumber.Text);
        rtypemanage.AddRType(rtypemanage);
        Response.Redirect("RTypeManage.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtRType.Text = txtNumber.Text = string.Empty;
    }
    protected void ValidateFun()
    {
        if (txtRType.Text == "")
        {
            Response.Write("<script>alert('学生类型名称不能为空！');location='javascript:history.go(-1)';</script>");
            return;
        }
        if (!validate.validateNum(txtNumber.Text))
        {
            Response.Write("<script>alert('可借数量输入有误！');location='javascript:history.go(-1)';</script>");
            return;
        }
    }
}
