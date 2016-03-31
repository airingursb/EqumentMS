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

public partial class BookManage_AddBType : System.Web.UI.Page
{
    ValidateClass validate = new ValidateClass();
    BTypeManage btypemanage = new BTypeManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "添加设备类型页面";
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ValidateFun();
        btypemanage.TypeName = txtBType.Text;
        if (btypemanage.FindBTypeByName(btypemanage, "tb_booktype").Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('该设备类型已经存在！')</script>");
            return;
        }
        btypemanage.Days = Convert.ToInt32(txtDay.Text);
        btypemanage.AddBookType(btypemanage);
        Response.Redirect("BTypeManage.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtBType.Text = txtDay.Text = string.Empty;
    }
    protected void ValidateFun()
    {
        if (txtBType.Text == "")
        {
            Response.Write("<script>alert('设备类型名称不能为空！');location='javascript:history.go(-1)';</script>");
            return;
        }
        if (!validate.validateNum(txtDay.Text))
        {
            Response.Write("<script>alert('可借天数输入有误！');location='javascript:history.go(-1)';</script>");
            return;
        }
    }
}
