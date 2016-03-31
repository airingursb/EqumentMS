using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// OperatorClass 的摘要说明
/// </summary>
public class OperatorClass
{
	public OperatorClass()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    #region  判断星期几
    /// <summary>
    /// 判断星期几
    /// </summary>
    /// <returns></returns>
    public string getWeek()
    {
        string str = DateTime.Now.DayOfWeek.ToString();
        string strWeek = "";
        switch (str)
        {
            case "Monday":
                strWeek = "星期一";
                break;
            case "Tuesday":
                strWeek = "星期二";
                break;
            case "Wednesday":
                strWeek = "星期三";
                break;
            case "Thursday":
                strWeek = "星期四";
                break;
            case "Friday":
                strWeek = "星期五";
                break;
            case "Saturday":
                strWeek = "星期六";
                break;
            case "Sunday":
                strWeek = "星期日";
                break;
        }
        return strWeek;
    }
    #endregion
}
 