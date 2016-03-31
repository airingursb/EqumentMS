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
/// ReserveandOutManage 的摘要说明
/// </summary>
public class ReserveandOutManage
{
    public ReserveandOutManage()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    DataBase data = new DataBase();

    #region 定义设备借还信息--数据结构
    private string id = "";
    private string readid = "";
    private string equcode = "";
    private DateTime reservetime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
    private string reserver = "";
    private bool isout = false;

    private string equname = "";
    private string name = "";
    private DateTime fromtime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
    private DateTime totime = Convert.ToDateTime(DateTime.Now.ToShortDateString());

    /// <summary>
    /// 租借编号
    /// </summary>
    public string ID
    {
        get { return id; }
        set { id = value; }
    }
    /// <summary>
    /// 学生编号
    /// </summary>
    public string ReadID
    {
        get { return readid; }
        set { readid = value; }
    }
    /// <summary>
    /// 设备条形码
    /// </summary>
    public string EquCode
    {
        get { return equcode; }
        set { equcode = value; }
    }
    /// <summary>
    /// 预定时间
    /// </summary>
    public DateTime ReserveTime
    {
        get { return reservetime; }
        set { reservetime = value; }
    }

    /// <summary>
    /// 预定者
    /// </summary>
    public string Reserver
    {
        get { return reserver; }
        set { reserver = value; }
    }

    /// <summary>
    /// 是否租借
    /// </summary>
    public bool IsOut
    {
        get { return isout; }
        set { isout = value; }
    }

    /// <summary>
    /// 设备名称
    /// </summary>
    public string EquName
    {
        get { return equname; }
        set { equname = value; }
    }
    /// <summary>
    /// 学生名称
    /// </summary>
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    /// <summary>
    /// 开始时间
    /// </summary>
    public DateTime FromTime
    {
        get { return fromtime; }
        set { fromtime = value; }
    }
    /// <summary>
    /// 结束时间
    /// </summary>
    public DateTime ToTime
    {
        get { return totime; }
        set { totime = value; }
    }
    #endregion

    #region 自动生成领取编号
    /// <summary>
    /// 自动生成领取编号
    /// </summary>
    /// <returns></returns>
    public string GetBorrowBookID()
    {
        DataSet ds = GetAllReOuEqu("tb_reserveandout");
        string strReserveEquID = "";
        if (ds.Tables[0].Rows.Count == 0)
            strReserveEquID = "RE10001";
        else
            strReserveEquID = "RE" + (Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][0].ToString().Substring(2, 5)) + 1);
        return strReserveEquID;
    }
    #endregion

    #region 添加--预定信息
    /// <summary>
    /// 添加--预定信息
    /// </summary>
    /// <param name="reserveandoutmanage"></param>
    /// <returns></returns>
    public int AddReserve(ReserveandOutManage reserveandoutmanage)
    {
        SqlParameter[] prams = {
				data.MakeInParam("@id",  SqlDbType.VarChar, 30, reserveandoutmanage.ID ),
                data.MakeInParam("@readerid",  SqlDbType.VarChar, 20,reserveandoutmanage.ReadID ),
                data.MakeInParam("@equcode",  SqlDbType.VarChar, 30, reserveandoutmanage.EquCode ),
                data.MakeInParam("@reserveTime",  SqlDbType.DateTime, 8, reserveandoutmanage.ReserveTime ),
                data.MakeInParam("@reserver",  SqlDbType.VarChar, 30, reserveandoutmanage.Reserver ),
                data.MakeInParam("@isout",  SqlDbType.Bit, 1, reserveandoutmanage.IsOut ),
			};
        return (data.RunProc("INSERT INTO tb_reserveandout (id,readerid,equcode,reserveTime,reserver,isout) "
            + "VALUES (@id,@readerid,@equcode,@reserveTime,@reserver,@isout)", prams));
    }
    #endregion

    #region 修改--预定租借信息
    /// <summary>
    /// 修改--预定租借信息
    /// </summary>
    /// <param name="reserveandoutmanage"></param>
    /// <returns></returns>
    public int UpdateOutBook(ReserveandOutManage reserveandoutmanage)
    {
        SqlParameter[] prams = {
				data.MakeInParam("@id",  SqlDbType.VarChar, 30, reserveandoutmanage.ID ),
                data.MakeInParam("@isout",  SqlDbType.Bit, 1, reserveandoutmanage.IsOut ),
			};
        return (data.RunProc("update tb_reserveandout set isout=@isout where id=@id", prams));
    }
    #endregion

    #region 删除--预定租借信息
    /// <summary>
    /// 删除--预定租借信息
    /// </summary>
    /// <param name="reserveandoutmanage"></param>
    /// <returns></returns>
    public int DeleteReOuEqu(ReserveandOutManage reserveandoutmanage)
    {
        SqlParameter[] prams = {
				data.MakeInParam("@id",  SqlDbType.VarChar, 30, reserveandoutmanage.ID ),
			};
        return (data.RunProc("delete from tb_reserveandout where id=@id", prams));
    }
    #endregion

    #region 查询--预定租借信息
    /// <summary>
    /// 根据--预定编号--得到预定租借信息
    /// </summary>
    /// <param name="reserveandoutmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindReOuEquByID(ReserveandOutManage reserveandoutmanage, string tbName)
    {
        SqlParameter[] prams = {
				data.MakeInParam("@id",  SqlDbType.VarChar, 30, reserveandoutmanage.ID+"%"),
			};
        return (data.RunProcReturn("select * from view_EquROInfo where id like @id", prams, tbName));
    }
    /// <summary>
    /// 根据--学生编号--得到租借归还信息
    /// </summary>
    /// <param name="reserveandoutmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindReOuEquByReaderID(ReserveandOutManage reserveandoutmanage, string tbName)
    {
        SqlParameter[] prams = {
				data.MakeInParam("@readerid",  SqlDbType.VarChar, 20,reserveandoutmanage.ReadID+"%"),
			};
        return (data.RunProcReturn("select * from view_EquROInfo where readerid like @readerid", prams, tbName));
    }
    /// <summary>
    /// 根据--学生名称--得到租借归还信息
    /// </summary>
    /// <param name="reserveandoutmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindReOuEquByReader(ReserveandOutManage reserveandoutmanage, string tbName)
    {
        SqlParameter[] prams = {
				data.MakeInParam("@name",  SqlDbType.VarChar, 50,"%"+reserveandoutmanage.Name+"%"),
			};
        return (data.RunProcReturn("select * from view_EquROInfo where name like @name", prams, tbName));
    }
    /// <summary>
    /// 根据--设备条形码--得到租借归还信息
    /// </summary>
    /// <param name="reserveandoutmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindReOuEquByBCode(ReserveandOutManage reserveandoutmanage, string tbName)
    {
        SqlParameter[] prams = {
				data.MakeInParam("@equcode",  SqlDbType.VarChar, 30, reserveandoutmanage.EquCode+"%"),
			};
        return (data.RunProcReturn("select * from view_EquROInfo where equcode like @equcode", prams, tbName));
    }
    /// <summary>
    /// 根据--设备名称--得到租借归还信息
    /// </summary>
    /// <param name="reserveandoutmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindReOuEquByBName(ReserveandOutManage reserveandoutmanage, string tbName)
    {
        SqlParameter[] prams = {
				data.MakeInParam("@equname",  SqlDbType.VarChar, 50, "%"+reserveandoutmanage.EquCode+"%"),
			};
        return (data.RunProcReturn("select * from view_EquROInfo where equname like @equname", prams, tbName));
    }
    /// <summary>
    /// 根据--租借时间--得到租借归还信息
    /// </summary>
    /// <param name="reserveandoutmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindReOuEquByBoTime(ReserveandOutManage reserveandoutmanage, string tbName)
    {
        SqlParameter[] prams = {
				data.MakeInParam("@fromtime",  SqlDbType.DateTime, 8, reserveandoutmanage.FromTime),
                data.MakeInParam("@totime",  SqlDbType.DateTime, 8, reserveandoutmanage.ToTime),
			};
        return (data.RunProcReturn("select * from view_EquROInfo where reserveTime between @fromtime and @totime", prams, tbName));
    }
    /// <summary>
    /// 得到所有--租借归还信息
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllReOuEqu(string tbName)
    {
        return (data.RunProcReturn("select * from view_EquROInfo ORDER BY id", tbName));
    }
    /// <summary>
    /// 得到所有--租借归还详细信息
    /// </summary>
    /// <param name="reserveandoutmanages"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindReOuEquByRID(ReserveandOutManage reserveandoutmanage, string tbName)
    {
        SqlParameter[] prams = {
				data.MakeInParam("@readerid",  SqlDbType.VarChar, 20,reserveandoutmanage.ReadID +"%"),
			};
        return (data.RunProcReturn("select * from view_EquROInfo where readerid like @readerid and isout=0", prams, tbName));
    }
    #endregion
}
