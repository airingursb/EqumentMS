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
/// BTypeManage 的摘要说明
/// </summary>
public class BTypeManage
{
	public BTypeManage()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    DataBase data = new DataBase();

    #region 定义设备类型信息--数据结构
    private int id = 0;
    private string typename= "";
    private int days = 0;
    
    /// <summary>
    /// 标识
    /// </summary>
    public int ID
    {
        get { return id; }
        set { id = value; }
    }
    /// <summary>
    /// 设备类型名称
    /// </summary>
    public string TypeName
    {
        get { return typename; }
        set { typename = value; }
    }
    /// <summary>
    /// 可借天数
    /// </summary>
    public int Days
    {
        get { return days; }
        set { days = value; }
    }
    #endregion

    #region 添加--设备类型信息
    /// <summary>
    /// 添加--设备类型信息
    /// </summary>
    /// <param name="btypemanage"></param>
    /// <returns></returns>
    public int AddBookType(BTypeManage btypemanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@typename",  SqlDbType.VarChar, 30, btypemanage.TypeName ),
            data.MakeInParam("@days",  SqlDbType.Int, 4,btypemanage.Days ),
			};
        return (data.RunProc("INSERT INTO tb_booktype (typename,days) VALUES(@typename,@days)", prams));
    }
    #endregion

    #region 修改--设备类型信息
    /// <summary>
    /// 修改--设备类型信息
    /// </summary>
    /// <param name="btypemanage"></param>
    /// <returns></returns>
    public int UpdateBookType(BTypeManage btypemanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.Int, 4, btypemanage.ID),						    
            data.MakeInParam("@typename",  SqlDbType.VarChar, 30, btypemanage.TypeName ),
            data.MakeInParam("@days",  SqlDbType.Int, 4,btypemanage.Days ),
			};
        return (data.RunProc("update tb_booktype set typename=@typename,days=@days where id=@id", prams));
    }
    #endregion

    #region 删除--设备类型信息
    /// <summary>
    /// 删除--设备类型信息
    /// </summary>
    /// <param name="btypemanage"></param>
    /// <returns></returns>
    public int DeleteBookType(BTypeManage btypemanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.Int, 4, btypemanage.ID),	
			};
        return (data.RunProc("delete from tb_booktype where id=@id", prams));
    }
    #endregion

    #region 查询--设备类型信息
    /// <summary>
    /// 根据--类型名称--得到设备类型信息
    /// </summary>
    /// <param name="btypemanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBTypeByName(BTypeManage btypemanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@typename",  SqlDbType.VarChar, 30, btypemanage.TypeName+"%"),
			};
        return (data.RunProcReturn("select * from tb_booktype where typename like @typename", prams, tbName));
    }
    /// <summary>
    /// 得到所有--设备类型信息
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllBType(string tbName)
    {
        return (data.RunProcReturn("select * from tb_booktype ORDER BY typename", tbName));
    }
    #endregion
}
