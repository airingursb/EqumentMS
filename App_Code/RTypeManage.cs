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
/// RTypeManage 的摘要说明
/// </summary>
public class RTypeManage
{
	public RTypeManage()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    DataBase data = new DataBase();

    #region 定义学生类型--数据结构
    private int id = 0;
    private string name = "";
    private int number = 0;
    
    /// <summary>
    /// 类型标识
    /// </summary>
    public int ID
    {
        get { return id; }
        set { id = value; }
    }
    /// <summary>
    /// 学生类型
    /// </summary>
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    /// <summary>
    /// 可借数量
    /// </summary>
    public int Number
    {
        get { return number; }
        set { number = value; }
    }
    #endregion

    #region 添加--学生类型信息
    /// <summary>
    /// 添加--学生类型信息
    /// </summary>
    /// <param name="rtypemanage"></param>
    /// <returns></returns>
    public int AddRType(RTypeManage rtypemanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@name",  SqlDbType.VarChar, 50, rtypemanage.Name ),
            data.MakeInParam("@number",  SqlDbType.Int, 4,rtypemanage.Number ),
			};
        return (data.RunProc("INSERT INTO tb_readertype (name,number) VALUES(@name,@number)", prams));
    }
    #endregion

    #region 修改--学生类型信息
    /// <summary>
    /// 修改--学生类型信息
    /// </summary>
    /// <param name="rtypemanage"></param>
    /// <returns></returns>
    public int UpdateRType(RTypeManage rtypemanage)
    {
        SqlParameter[] prams = {
            data.MakeInParam("@id",  SqlDbType.Int, 4, rtypemanage.ID ),
			data.MakeInParam("@name",  SqlDbType.VarChar, 50, rtypemanage.Name ),
            data.MakeInParam("@number",  SqlDbType.Int, 4,rtypemanage.Number ),
			};
        return (data.RunProc("update tb_readertype set name=@name,number=@number where id=@id", prams));
    }
    #endregion

    #region 删除--学生类型信息
    /// <summary>
    /// 删除--学生类型信息
    /// </summary>
    /// <param name="rtypemanage"></param>
    /// <returns></returns>
    public int DeleteRType(RTypeManage rtypemanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.Int, 4, rtypemanage.ID ),
			};
        return (data.RunProc("delete from tb_readertype where id=@id", prams));
    }
    #endregion

    #region 查询--学生类型信息
    /// <summary>
    /// 根据--学生类型--得到学生类型信息
    /// </summary>
    /// <param name="rtypemanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindRTypeByName(RTypeManage rtypemanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@name",  SqlDbType.VarChar, 50, rtypemanage.Name+"%"),
			};
        return (data.RunProcReturn("select * from tb_readertype where name like @name", prams, tbName));
    }
    /// <summary>
    /// 得到所有--学生类型信息
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllRType(string tbName)
    {
        return (data.RunProcReturn("select * from tb_readertype ORDER BY id", tbName));
    }
    #endregion
}
