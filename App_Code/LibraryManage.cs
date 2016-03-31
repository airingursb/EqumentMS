using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// LibraryManage 的摘要说明
/// </summary>
public class LibraryManage
{
	public LibraryManage()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    DataBase data = new DataBase();

    #region 定义实验室信息--数据结构
    private string libraryname = "";
    private string curator = "";
    private string tel = "";
    private string address = "";
    private string email = "";
    private string url = "";
    private DateTime createdate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
    private string introduce = "";
    
    /// <summary>
    /// 实验室名称
    /// </summary>
    public string LibraryName
    {
        get { return libraryname; }
        set { libraryname = value; }
    }
    /// <summary>
    /// 馆长
    /// </summary>
    public string Curator
    {
        get { return curator; }
        set { curator = value; }
    }
    /// <summary>
    /// 联系电话
    /// </summary>
    public string Tel
    {
        get { return tel; }
        set { tel = value; }
    }
    /// <summary>
    /// 联系地址
    /// </summary>
    public string Address
    {
        get { return address; }
        set { address = value; }
    }
    /// <summary>
    /// 联系邮箱
    /// </summary>
    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    /// <summary>
    /// 网址
    /// </summary>
    public string URL
    {
        get { return url; }
        set { url = value; }
    }
    /// <summary>
    /// 建馆日期
    /// </summary>
    public DateTime CreateDate
    {
        get { return createdate; }
        set { createdate = value; }
    }
    /// <summary>
    /// 简介
    /// </summary>
    public string Introduce
    {
        get { return introduce; }
        set { introduce = value; }
    }
    #endregion

    #region 添加--实验室信息
    /// <summary>
    /// 添加--实验室信息
    /// </summary>
    /// <param name="librarymanage"></param>
    /// <returns></returns>
    public int AddLib(LibraryManage librarymanage)
    {
        SqlParameter[] prams = {
            data.MakeInParam("@libraryname",  SqlDbType.VarChar, 50,librarymanage.LibraryName ),
            data.MakeInParam("@curator",  SqlDbType.VarChar, 20, librarymanage.Curator ),
            data.MakeInParam("@tel",  SqlDbType.VarChar, 20, librarymanage.Tel ),
            data.MakeInParam("@address",  SqlDbType.VarChar,100, librarymanage.Address ),
            data.MakeInParam("@email",  SqlDbType.VarChar, 100, librarymanage.Email ),
            data.MakeInParam("@url",  SqlDbType.VarChar, 100, librarymanage.URL ),
            data.MakeInParam("@createdate",  SqlDbType.DateTime, 8, librarymanage.CreateDate ),
            data.MakeInParam("@introduce",  SqlDbType.Text, 4000, librarymanage.Introduce ),
			};
        return (data.RunProc("INSERT INTO tb_library (libraryname,curator,tel,address,email,url,createDate,introduce) "
            + "VALUES (@libraryname,@curator,@tel,@address,@email,@url,@createdate,@introduce)", prams));
    }
    #endregion 

    #region 修改--实验室信息
    /// <summary>
    /// 修改--实验室信息
    /// </summary>
    /// <param name="librarymanage"></param>
    /// <returns></returns>
    public int UpdateLib(LibraryManage librarymanage)
    {
        SqlParameter[] prams = {
            data.MakeInParam("@libraryname",  SqlDbType.VarChar, 50,librarymanage.LibraryName ),
            data.MakeInParam("@curator",  SqlDbType.VarChar, 20, librarymanage.Curator ),
            data.MakeInParam("@tel",  SqlDbType.VarChar, 20, librarymanage.Tel ),
            data.MakeInParam("@address",  SqlDbType.VarChar,100, librarymanage.Address ),
            data.MakeInParam("@email",  SqlDbType.VarChar, 100, librarymanage.Email ),
            data.MakeInParam("@url",  SqlDbType.VarChar, 100, librarymanage.URL ),
            data.MakeInParam("@createdate",  SqlDbType.DateTime, 8, librarymanage.CreateDate ),
            data.MakeInParam("@introduce",  SqlDbType.Text, 4000, librarymanage.Introduce ),
			};
        return (data.RunProc("update tb_library set libraryname=@libraryname,curator=@curator,tel=@tel,address=@address,"
            +"email=@email,url=@url,createDate=@createdate,introduce=@introduce", prams));
    }
    #endregion

    #region 查询--实验室信息
    /// <summary>
    /// 得到--实验室信息
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllLib(string tbName)
    {
        return (data.RunProcReturn("select * from tb_library", tbName));
    }
    #endregion
}
