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
/// AdminManage 的摘要说明
/// </summary>
public class AdminManage
{
	public AdminManage()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
    }
    DataBase data = new DataBase();

    #region 定义管理员信息--数据结构
    private string id = "";
    private string name = "";
    private string pwd = "";
    /// <summary>
    /// 管理员编号
    /// </summary>
    public string ID
    {
        get { return id; }
        set { id = value; }
    }
    /// <summary>
    /// 管理员名称
    /// </summary>
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    /// <summary>
    /// 管理员密码
    /// </summary>
    public string Pwd
    {
        get { return pwd; }
        set { pwd = value; }
    }
    #endregion

    #region 自动生成管理员编号
    /// <summary>
    /// 自动生成管理员编号
    /// </summary>
    /// <returns></returns>
    public string GetAdminID()
    {
        DataSet ds = GetAllAdmin("tb_admin");
        string strAdminID = "";
        if (ds.Tables[0].Rows.Count == 0)
            strAdminID = "GLY1001";
        else
            strAdminID = "GLY" + (Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][0].ToString().Substring(3, 4)) + 1);
        return strAdminID;
    }
    #endregion

    #region 添加--管理员信息
    /// <summary>
    /// 添加--管理员信息
    /// </summary>
    /// <param name="adminmanage"></param>
    /// <returns></returns>
    public int AddAdmin(AdminManage adminmanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 50, adminmanage.ID),
            data.MakeInParam("@name",  SqlDbType.VarChar, 50,adminmanage.Name),
            data.MakeInParam("@pwd",  SqlDbType.VarChar, 30, adminmanage.Pwd),
			};
        return (data.RunProc("INSERT INTO tb_admin (id,name,pwd) VALUES(@id,@name,@pwd)", prams));
    }
    #endregion

    #region 修改--管理员信息
    /// <summary>
    /// 修改--管理员信息
    /// </summary>
    /// <param name="adminmanage"></param>
    /// <returns></returns>
    public int UpdateAdmin(AdminManage adminmanage)
    {
        SqlParameter[] prams = {
            data.MakeInParam("@name",  SqlDbType.VarChar, 50,adminmanage.Name),
            data.MakeInParam("@pwd",  SqlDbType.VarChar, 30, adminmanage.Pwd),
			};
        return (data.RunProc("update tb_admin set pwd=@pwd where name=@name", prams));
    }
    #endregion

    #region 删除--管理员信息
    /// <summary>
    /// 删除--管理员信息
    /// </summary>
    /// <param name="adminmanage"></param>
    /// <returns></returns>
    public int DeleteAdmin(AdminManage adminmanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@name",  SqlDbType.VarChar, 50,adminmanage.Name),
			};
        return (data.RunProc("delete from tb_admin where name=@name", prams));
    }
    #endregion

    #region 管理员登录
    /// <summary>
    /// 管理员登录
    /// </summary>
    /// <param name="adminmanage"></param>
    /// <returns></returns>
    public DataSet Login(AdminManage adminmanage)
    {
        SqlParameter[] prams = {
            data.MakeInParam("@name",  SqlDbType.VarChar, 50,adminmanage.Name),
            data.MakeInParam("@pwd",  SqlDbType.VarChar, 30, adminmanage.Pwd),
			};
        return (data.RunProcReturn("SELECT * FROM tb_admin WHERE (name = @name) AND (pwd = @pwd)", prams, "tb_admin"));
    }
    #endregion

    #region 查询--管理员信息
    /// <summary>
    /// 根据管理员名称得到--管理员信息
    /// </summary>
    /// <param name="adminmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllAdminByName(AdminManage adminmanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@name",  SqlDbType.VarChar, 50,adminmanage.Name +"%"),
			};
        return (data.RunProcReturn("select * from tb_admin where name like @name", prams, tbName));
    }
    /// <summary>
    /// 得到所有--管理员信息
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllAdmin(string tbName)
    {
        return (data.RunProcReturn("select * from tb_admin ORDER BY id", tbName));
    }
    #endregion
}
