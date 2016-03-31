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
/// CaseManage 的摘要说明
/// </summary>
public class CaseManage
{
	public CaseManage()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    DataBase data = new DataBase();

    #region 定义所属信息--数据结构
    private string id = "";
    private string name = "";
    /// <summary>
    /// 所属编号
    /// </summary>
    public string ID
    {
        get { return id; }
        set { id = value; }
    }
    /// <summary>
    /// 所属名称
    /// </summary>
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    #endregion

    #region 自动生成所属编号
    /// <summary>
    /// 自动生成所属编号
    /// </summary>
    /// <returns></returns>
    public string GetBcaseID()
    {
        DataSet ds = GetAllBCase("tb_case");
        string strBcaseID = "";
        if (ds.Tables[0].Rows.Count == 0)
            strBcaseID = "SJ1001";
        else
            strBcaseID = "SJ" + (Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][0].ToString().Substring(2, 4)) + 1);
        return strBcaseID;
    }
    #endregion

    #region 添加--所属信息
    /// <summary>
    /// 添加--所属信息
    /// </summary>
    /// <param name="bookcasemanage"></param>
    /// <returns></returns>
    public int AddBookcase(CaseManage bookcasemanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 30, bookcasemanage.ID),
            data.MakeInParam("@name",  SqlDbType.VarChar, 50,bookcasemanage.Name),
			};
        return (data.RunProc("INSERT INTO tb_case (id,name) VALUES(@id,@name)", prams));
    }
    #endregion

    #region 修改--所属信息
    /// <summary>
    /// 修改--所属信息
    /// </summary>
    /// <param name="bookcasemanage"></param>
    /// <returns></returns>
    public int UpdateBookcase(CaseManage bookcasemanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 30, bookcasemanage.ID),
            data.MakeInParam("@name",  SqlDbType.VarChar, 50,bookcasemanage.Name),
			};
        return (data.RunProc("update tb_case set name=@name where id=@id", prams));
    }
    #endregion

    #region 删除--所属信息
    /// <summary>
    /// 删除--所属信息
    /// </summary>
    /// <param name="bookcasemanage"></param>
    /// <returns></returns>
    public int DeleteBookcase(CaseManage bookcasemanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 30, bookcasemanage.ID),
			};
        return (data.RunProc("delete from tb_case where id=@id", prams));
    }
    #endregion

    #region 查询--所属信息
    /// <summary>
    /// 根据--所属编号--得到所属信息
    /// </summary>
    /// <param name="bookcasemanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBCaseByID(CaseManage bookcasemanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 30, bookcasemanage.ID+"%"),
			};
        return (data.RunProcReturn("select * from tb_case where id like @id", prams, tbName));
    }
    /// <summary>
    /// 根据--所属名称--得到所属信息
    /// </summary>
    /// <param name="bookcasemanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBCaseByName(CaseManage bookcasemanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@name",  SqlDbType.VarChar, 50,bookcasemanage.Name+"%"),
			};
        return (data.RunProcReturn("select * from tb_case where name like @name", prams, tbName));
    }
    /// <summary>
    /// 得到所有--所属信息
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllBCase(string tbName)
    {
        return (data.RunProcReturn("select * from tb_case ORDER BY id", tbName));
    }
    #endregion
}
