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
/// PurviewManage 的摘要说明
/// </summary>
public class PurviewManage
{
	public PurviewManage()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    DataBase data = new DataBase();

    #region 定义管理员权限--数据结构
    private string id = "";
    private bool sysset = false;
    private bool readset = false;
    private bool bookset = false;
    private bool borrowback = false;
    private bool sysquery = true;

    /// <summary>
    /// G管理员编号
    /// </summary>
    public string ID
    {
        get { return id; }
        set { id = value; }
    }
    /// <summary>
    /// 系统设置
    /// </summary>
    public bool SysSet
    {
        get { return sysset; }
        set { sysset = value; }
    }
    /// <summary>
    /// 学生管理
    /// </summary>
    public bool ReadSet
    {
        get { return readset; }
        set { readset = value; }
    }
    /// <summary>
    /// 设备管理
    /// </summary>
    public bool BookSet
    {
        get { return bookset; }
        set { bookset = value; }
    }
    /// <summary>
    /// 设备借还
    /// </summary>
    public bool BorrowBack
    {
        get { return borrowback; }
        set { borrowback = value; }
    }
    /// <summary>
    /// 系统查询
    /// </summary>
    public bool SysQuery
    {
        get { return sysquery; }
        set { sysquery = value; }
    }
    #endregion

    #region 添加--管理员权限
    /// <summary>
    /// 添加--管理员权限
    /// </summary>
    /// <param name="purviewmanage"></param>
    /// <returns></returns>
    public int AddPurview(PurviewManage purviewmanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 50, purviewmanage.ID ),
            data.MakeInParam("@sysset",  SqlDbType.Bit, 1,purviewmanage.SysSet ),
            data.MakeInParam("@readset",  SqlDbType.Bit, 1, purviewmanage.ReadSet ),
            data.MakeInParam("@bookset",  SqlDbType.Bit, 1, purviewmanage.BookSet ),
            data.MakeInParam("@borrowback",  SqlDbType.Bit, 1, purviewmanage.BorrowBack ),
            data.MakeInParam("@sysquery",  SqlDbType.Bit, 1, purviewmanage.SysQuery ),
			};
        return (data.RunProc("INSERT INTO tb_purview (id,sysset,readset,bookset,borrowback,sysquery) "
            + "VALUES (@id,@sysset,@readset,@bookset,@borrowback,@sysquery)", prams));
    }
    #endregion

    #region 修改--管理员权限
    /// <summary>
    /// 修改--管理员权限
    /// </summary>
    /// <param name="purviewmanage"></param>
    /// <returns></returns>
    public int UpdatePurview(PurviewManage purviewmanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 50, purviewmanage.ID ),
            data.MakeInParam("@sysset",  SqlDbType.Bit, 1,purviewmanage.SysSet ),
            data.MakeInParam("@readset",  SqlDbType.Bit, 1, purviewmanage.ReadSet ),
            data.MakeInParam("@bookset",  SqlDbType.Bit, 1, purviewmanage.BookSet ),
            data.MakeInParam("@borrowback",  SqlDbType.Bit, 1, purviewmanage.BorrowBack ),
            data.MakeInParam("@sysquery",  SqlDbType.Bit, 1, purviewmanage.SysQuery ),
			};
        return (data.RunProc("update tb_purview set sysset=@sysset,readset=@readset,bookset=@bookset,"
            +"borrowback=@borrowback,sysquery=@sysquery where id=@id", prams));
    }
    #endregion

    #region 删除--管理员权限
    /// <summary>
    /// 删除--管理员权限
    /// </summary>
    /// <param name="purviewmanage"></param>
    /// <returns></returns>
    public int DeletePurview(PurviewManage purviewmanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 50, purviewmanage.ID ),
			};
        return (data.RunProc("delete from tb_purview where id=@id", prams));
    }
    #endregion

    #region 查询--管理员权限
    /// <summary>
    /// 根据--管理员编号--得到管理员权限
    /// </summary>
    /// <param name="purviewmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindPurviewByID(PurviewManage purviewmanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 50, purviewmanage.ID +"%"),
			};
        return (data.RunProcReturn("select * from tb_purview where id like @id", prams, tbName));
    }
    /// <summary>
    /// 得到所有--管理员权限
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllPurview(string tbName)
    {
        return (data.RunProcReturn("select * from tb_purview ORDER BY id", tbName));
    }
    /// <summary>
    /// 得到所有--管理员权限(根据名字)
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllPurviewByName(string tbName)
    {
        return (data.RunProcReturn("select * from view_AdminPurview ORDER BY id", tbName));
    }
    #endregion
}
