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
/// EqumentManage 的摘要说明
/// </summary>
public class EqumentManage
{
    public EqumentManage()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    DataBase data = new DataBase();

    #region 定义设备信息--数据结构
    private string equcode = "";
    private string equname = "";
    private string type = "";
    private string author = "";
    private string translator = "";
    private string pubname = "";
    private decimal price = 0;
    private string bcase = "";
    private int storage = 0;
    private DateTime intime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
    private string oper = "";
    private int borrownum = 0;

    /// <summary>
    /// 条形码
    /// </summary>
    public string EquCode
    {
        get { return equcode; }
        set { equcode = value; }
    }
    /// <summary>
    /// 设备名
    /// </summary>
    public string EquName
    {
        get { return equname; }
        set { equname = value; }
    }
    /// <summary>
    /// 类型编号
    /// </summary>
    public string Type
    {
        get { return type; }
        set { type = value; }
    }
    /// <summary>
    /// 管理老师
    /// </summary>
    public string Author
    {
        get { return author; }
        set { author = value; }
    }
    /// <summary>
    /// 购买员
    /// </summary>
    public string Translator
    {
        get { return translator; }
        set { translator = value; }
    }
    /// <summary>
    /// 所属实验室
    /// </summary>
    public string PubName
    {
        get { return pubname; }
        set { pubname = value; }
    }
    /// <summary>
    /// 价格
    /// </summary>
    public decimal Price
    {
        get { return price; }
        set { price = value; }
    }

    /// <summary>
    /// 所属
    /// </summary>
    public string Bcase
    {
        get { return bcase; }
        set { bcase = value; }
    }
    /// <summary>
    /// 库存量
    /// </summary>
    public int Storage
    {
        get { return storage; }
        set { storage = value; }
    }
    /// <summary>
    /// 录入时间
    /// </summary>
    public DateTime InTime
    {
        get { return intime; }
        set { intime = value; }
    }
    /// <summary>
    /// 操作员
    /// </summary>
    public string Oper
    {
        get { return oper; }
        set { oper = value; }
    }
    /// <summary>
    /// 借出次数
    /// </summary>
    public int BorrowNum
    {
        get { return borrownum; }
        set { borrownum = value; }
    }
    #endregion

    #region 添加--设备信息
    /// <summary>
    /// 添加--设备信息
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <returns></returns>
    public int AddBook(EqumentManage bookmanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@equcode",  SqlDbType.VarChar, 30, bookmanage.EquCode),
            data.MakeInParam("@equname",  SqlDbType.VarChar, 50,bookmanage.EquName ),
            data.MakeInParam("@type",  SqlDbType.VarChar, 50, bookmanage.Type ),
            data.MakeInParam("@author",  SqlDbType.VarChar, 50, bookmanage.Author ),
            data.MakeInParam("@translator",  SqlDbType.VarChar, 50, bookmanage.Translator ),
            data.MakeInParam("@pubname",  SqlDbType.VarChar, 100, bookmanage.PubName ),
            data.MakeInParam("@price",  SqlDbType.Money, 8, bookmanage.Price ),
            data.MakeInParam("@bcase",  SqlDbType.VarChar, 50, bookmanage.Bcase ),
            data.MakeInParam("@storage",  SqlDbType.BigInt, 8, bookmanage.Storage ),
            data.MakeInParam("@inTime",  SqlDbType.DateTime, 8, bookmanage.InTime ),
            data.MakeInParam("@oper",  SqlDbType.VarChar, 30, bookmanage.Oper ),
			};
        return (data.RunProc("INSERT INTO tb_equinfo (equcode,equname,type,author,translator,pubname,price,bcase,storage,inTime,oper) "
            + "VALUES (@equcode,@equname,@type,@author,@translator,@pubname,@price,@bcase,@storage,@inTime,@oper)", prams));
    }
    #endregion

    #region 修改--设备信息
    /// <summary>
    /// 修改--设备信息
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <returns></returns>
    public int UpdateBook(EqumentManage bookmanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@equcode",  SqlDbType.VarChar, 30, bookmanage.EquCode),
            data.MakeInParam("@equname",  SqlDbType.VarChar, 50,bookmanage.EquName ),
            data.MakeInParam("@type",  SqlDbType.VarChar, 50, bookmanage.Type ),
            data.MakeInParam("@author",  SqlDbType.VarChar, 50, bookmanage.Author ),
            data.MakeInParam("@translator",  SqlDbType.VarChar, 50, bookmanage.Translator ),
            data.MakeInParam("@pubname",  SqlDbType.VarChar, 100, bookmanage.PubName),
            data.MakeInParam("@price",  SqlDbType.Money, 8, bookmanage.Price ),
            data.MakeInParam("@bcase",  SqlDbType.VarChar, 50, bookmanage.Bcase ),
            data.MakeInParam("@storage",  SqlDbType.BigInt, 8, bookmanage.Storage ),
            data.MakeInParam("@inTime",  SqlDbType.DateTime, 8, bookmanage.InTime ),
            data.MakeInParam("@oper",  SqlDbType.VarChar, 30, bookmanage.Oper),
			};
        return (data.RunProc("update tb_equinfo set equname=@equname,type=@type,author=@author,translator=@translator,pubname=@pubname,price=@price,"
            + "bcase=@bcase,storage=@storage,inTime=@inTime,oper=@oper where equcode=@equcode", prams));
    }
    /// <summary>
    /// 每借一次设备就将设备的所借次数加一
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <returns></returns>
    public int UpdateBorrowNum(EqumentManage bookmanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@equcode",  SqlDbType.VarChar, 30, bookmanage.EquCode),
            data.MakeInParam("@borrownum",  SqlDbType.Int, 4, bookmanage.BorrowNum),
			};
        return (data.RunProc("update tb_equinfo set borrownum=@borrownum where equcode=@equcode", prams));
    }
    #endregion

    #region 删除--设备信息
    /// <summary>
    /// 删除--设备信息
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <returns></returns>
    public int DeleteBook(EqumentManage bookmanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@equcode",  SqlDbType.VarChar, 30, bookmanage.EquCode),
			};
        return (data.RunProc("delete from tb_equinfo where equcode=@equcode", prams));
    }
    #endregion

    #region 查询--设备信息
    /// <summary>
    /// 根据--设备编号--得到设备信息
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBookByCode(EqumentManage bookmanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@equcode",  SqlDbType.VarChar, 30, bookmanage.EquCode+"%"),
			};
        return (data.RunProcReturn("select * from tb_equinfo where equcode like @equcode", prams, tbName));
    }
    /// <summary>
    /// 根据--设备名称--得到设备信息
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBookByName(EqumentManage bookmanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@equname",  SqlDbType.VarChar, 50,"%"+bookmanage.EquName+"%"),
			};
        return (data.RunProcReturn("select * from tb_equinfo where equname like @equname", prams, tbName));
    }
    /// <summary>
    /// 根据--设备类型--得到设备信息
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBookByType(EqumentManage bookmanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@type",  SqlDbType.VarChar, 50, "%"+bookmanage.Type+"%"),
			};
        return (data.RunProcReturn("select * from tb_equinfo where type like @type", prams, tbName));
    }
    /// <summary>
    /// 根据--设备管理老师--得到设备信息
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBookByAuthor(EqumentManage bookmanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@author",  SqlDbType.VarChar, 50, "%"+bookmanage.Author +"%"),
			};
        return (data.RunProcReturn("select * from tb_equinfo where author like @author", prams, tbName));
    }
    /// <summary>
    /// 根据--所属实验室--得到设备信息
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBookByPub(EqumentManage bookmanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@pubname",  SqlDbType.VarChar, 100, "%"+bookmanage.PubName +"%"),
			};
        return (data.RunProcReturn("select * from tb_equinfo where pubname like @pubname", prams, tbName));
    }
    /// <summary>
    /// 根据--所属--得到设备信息
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindBookByBCase(EqumentManage bookmanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@bcase",  SqlDbType.VarChar, 50, "%"+bookmanage.Bcase +"%"),
			};
        return (data.RunProcReturn("select * from tb_equinfo where bcase like @bcase", prams, tbName));
    }
    /// <summary>
    /// 得到所有--设备信息
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllBook(string tbName)
    {
        return (data.RunProcReturn("select * from tb_equinfo ORDER BY equcode", tbName));
    }
    /// <summary>
    /// 得到设备租借排行的前5名
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetBookSort(string tbName)
    {
        return (data.RunProcReturn("select top 5* from tb_equinfo where borrownum<>0 ORDER BY borrownum desc", tbName));
    }
    /// <summary>
    /// 得到所有设备租借排行
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllBookSort(string tbName)
    {
        return (data.RunProcReturn("select * from tb_equinfo where borrownum<>0 ORDER BY borrownum desc", tbName));
    }
    #endregion
}
