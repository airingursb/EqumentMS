using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

/// <summary>
/// ValidateClass 的摘要说明
/// </summary>
public class ValidateClass
{
	public ValidateClass()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    #region  验证输入为数字
    /// <summary>
    /// 验证输入为数字
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public bool validateNum(string str)
    {
        return Regex.IsMatch(str, "^[0-9]*[1-9][0-9]*$");
    }
    #endregion

    #region  验证输入为邮编
    /// <summary>
    /// 验证输入为邮编
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public bool validatePCode(string str)
    {
        return Regex.IsMatch(str, @"\d{6}");
    }
    #endregion

    #region  验证输入为电话号码
    /// <summary>
    /// 验证输入为电话号码
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public bool validatePhone(string str)
    {
        return Regex.IsMatch(str, @"^(\d{3,4})-(\d{7,8})$");
    }
    #endregion

    #region  验证输入为Email
    /// <summary>
    /// 验证输入为Email
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public bool validateEmail(string str)
    {
        return Regex.IsMatch(str, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
    }
    #endregion

    #region  验证输入为网址
    /// <summary>
    /// 验证输入为网址
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public bool validateNAddress(string str)
    {
        return Regex.IsMatch(str, @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
    }
    #endregion
}
