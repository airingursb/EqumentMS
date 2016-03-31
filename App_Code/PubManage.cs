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
/// PubManage 的摘要说明
/// </summary>
public class PubManage
{
	public PubManage()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    DataBase data = new DataBase();

    #region 定义实验室信息--数据结构
    private string isbn = "";
    private string pubname = "";
    /// <summary>
    /// ISBN号
    /// </summary>
    public string ISBN
    {
        get { return isbn; }
        set { isbn = value; }
    }
    /// <summary>
    /// 实验室名称
    /// </summary>
    public string PubName
    {
        get { return pubname; }
        set { pubname = value; }
    }
    #endregion

    #region 添加--实验室信息
    /// <summary>
    /// 添加--实验室信息
    /// </summary>
    /// <param name="pubmanage"></param>
    /// <returns></returns>
    public int AddPub(PubManage pubmanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@isbn",  SqlDbType.VarChar, 30, pubmanage.ISBN),
            data.MakeInParam("@pubname",  SqlDbType.VarChar, 50,pubmanage.PubName),
			};
        return (data.RunProc("INSERT INTO tb_pubinfo (ISBN,pubname) VALUES(@isbn,@pubname)", prams));
    }
    #endregion

    #region 修改--实验室信息
    /// <summary>
    /// 修改--实验室信息
    /// </summary>
    /// <param name="pubmanage"></param>
    /// <returns></returns>
    public int UpdatePub(PubManage pubmanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@isbn",  SqlDbType.VarChar, 30, pubmanage.ISBN),
            data.MakeInParam("@pubname",  SqlDbType.VarChar, 50,pubmanage.PubName),
			};
        return (data.RunProc("update tb_pubinfo set pubname=@pubname where ISBN=@isbn", prams));
    }
    #endregion

    #region 删除--实验室信息
    /// <summary>
    /// 删除--实验室信息
    /// </summary>
    /// <param name="pubmanage"></param>
    /// <returns></returns>
    public int DeletePub(PubManage pubmanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@isbn",  SqlDbType.VarChar, 30, pubmanage.ISBN),
			};
        return (data.RunProc("delete from tb_pubinfo where ISBN=@isbn", prams));
    }
    #endregion

    #region 查询--实验室信息
    /// <summary>
    /// 根据--ISBN号--得到实验室信息
    /// </summary>
    /// <param name="pubmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindPubByISBN(PubManage pubmanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@isbn",  SqlDbType.VarChar, 30, pubmanage.ISBN+"%"),
			};
        return (data.RunProcReturn("select * from tb_pubinfo where ISBN like @isbn", prams, tbName));
    }
    /// <summary>
    /// 根据--实验室名称--得到实验室信息
    /// </summary>
    /// <param name="pubmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindPubByPName(PubManage pubmanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@pubname",  SqlDbType.VarChar, 50,pubmanage.PubName+"%"),
			};
        return (data.RunProcReturn("select * from tb_pubinfo where pubname like @pubname", prams, tbName));
    }
    /// <summary>
    /// 得到所有--实验室信息
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllPub(string tbName)
    {
        return (data.RunProcReturn("select * from tb_pubinfo ORDER BY ISBN", tbName));
    }
    #endregion
}
