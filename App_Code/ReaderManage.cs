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
/// ReaderManage 的摘要说明
/// </summary>
public class ReaderManage
{
	public ReaderManage()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    DataBase data = new DataBase();

    #region 定义学生信息--数据结构
    private string id = "";
    private string name = "";
    private string sex = "";
    private string type = "";
    private DateTime birthday = Convert.ToDateTime(DateTime.Now.ToShortDateString());
    private string papertype = "";
    private string papernum = "";
    private string tel = "";
    private string email = "";
    private DateTime createdate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
    private string oper = "";
    private string remark = "";
    private int borrownum = 0;
    private int num = 0;

    /// <summary>
    /// 学生编号
    /// </summary>
    public string ID
    {
        get { return id; }
        set { id = value; }
    }
    /// <summary>
    /// 学生姓名
    /// </summary>
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    /// <summary>
    /// 性别
    /// </summary>
    public string Sex
    {
        get { return sex; }
        set { sex = value; }
    }
    /// <summary>
    /// 学生类型
    /// </summary>
    public string Type
    {
        get { return type; }
        set { type = value; }
    }
    /// <summary>
    /// 出生日期
    /// </summary>
    public DateTime Birthday
    {
        get { return birthday; }
        set { birthday = value; }
    }
    /// <summary>
    /// 有效证件
    /// </summary>
    public string PaperType
    {
        get { return papertype; }
        set { papertype = value; }
    }
    /// <summary>
    /// 证件号码
    /// </summary>
    public string PaperNum
    {
        get { return papernum; }
        set { papernum = value; }
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
    /// Email地址
    /// </summary>
    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    /// <summary>
    /// 等级日期
    /// </summary>
    public DateTime CreateDate
    {
        get { return createdate; }
        set { createdate = value; }
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
    ///备注
    /// </summary>
    public string Remark
    {
        get { return remark; }
        set { remark = value; }
    }
    /// <summary>
    /// 租借次数
    /// </summary>
    public int BorrowNum
    {
        get { return borrownum; }
        set { borrownum = value; }
    }
    /// <summary>
    /// 当前租借数量
    /// </summary>
    public int Num
    {
        get { return num; }
        set { num = value; }
    }
    #endregion

    #region 自动生成学生编号
    /// <summary>
    /// 自动生成学生编号
    /// </summary>
    /// <returns></returns>
    public string GetReaderID()
    {
        DataSet ds = GetAllReader("tb_reader");
        string strReaderID = "";
        if (ds.Tables[0].Rows.Count == 0)
            strReaderID = "DZ10001";
        else
            strReaderID = "DZ" + (Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][0].ToString().Substring(2, 5)) + 1);
        return strReaderID;
    }
    #endregion

    #region 添加--学生信息
    /// <summary>
    /// 添加--学生信息
    /// </summary>
    /// <param name="readermanage"></param>
    /// <returns></returns>
    public int AddReader(ReaderManage readermanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 30, readermanage.ID ),
            data.MakeInParam("@name",  SqlDbType.VarChar, 50,readermanage.Name ),
            data.MakeInParam("@sex",  SqlDbType.Char, 4, readermanage.Sex ),
            data.MakeInParam("@type",  SqlDbType.VarChar, 50, readermanage.Type ),
            data.MakeInParam("@birthday",  SqlDbType.DateTime, 8, readermanage.Birthday ),
            data.MakeInParam("@papertype",  SqlDbType.VarChar, 20, readermanage.PaperType ), 
            data.MakeInParam("@papernum",  SqlDbType.VarChar, 30, readermanage.PaperNum ),
            data.MakeInParam("@tel",  SqlDbType.VarChar, 20,readermanage.Tel ),
            data.MakeInParam("@email",  SqlDbType.VarChar, 50, readermanage.Email),
            data.MakeInParam("@createdate",  SqlDbType.DateTime, 8, readermanage.CreateDate ),
            data.MakeInParam("@oper",  SqlDbType.VarChar, 30, readermanage.Oper ),
            data.MakeInParam("@remark",  SqlDbType.VarChar, 4000, readermanage.Remark ),
			};
        return (data.RunProc("INSERT INTO tb_reader(id,name,sex,type,birthday,paperType,paperNum,tel,email,createDate,oper,remark) "
            + "VALUES (@id,@name,@sex,@type,@birthday,@papertype,@papernum,@tel,@email,@createdate,@oper,@remark)", prams));
    }
    #endregion

    #region 修改--学生信息
    /// <summary>
    /// 修改--学生信息
    /// </summary>
    /// <param name="readermanage"></param>
    /// <returns></returns>
    public int UpdateReader(ReaderManage readermanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 30, readermanage.ID ),
            data.MakeInParam("@name",  SqlDbType.VarChar, 50,readermanage.Name ),
            data.MakeInParam("@sex",  SqlDbType.Char, 4, readermanage.Sex ),
            data.MakeInParam("@type",  SqlDbType.VarChar, 50, readermanage.Type ),
            data.MakeInParam("@birthday",  SqlDbType.DateTime, 8, readermanage.Birthday ),
            data.MakeInParam("@papertype",  SqlDbType.VarChar, 20, readermanage.PaperType ), 
            data.MakeInParam("@papernum",  SqlDbType.VarChar, 30, readermanage.PaperNum ),
            data.MakeInParam("@tel",  SqlDbType.VarChar, 20,readermanage.Tel ),
            data.MakeInParam("@email",  SqlDbType.VarChar, 50, readermanage.Email),
            data.MakeInParam("@createdate",  SqlDbType.DateTime, 8, readermanage.CreateDate ),
            data.MakeInParam("@oper",  SqlDbType.VarChar, 30, readermanage.Oper ),
            data.MakeInParam("@remark",  SqlDbType.VarChar, 4000, readermanage.Remark ),
			};
        return (data.RunProc("update tb_reader set name=@name,sex=@sex,type=@type,birthday=@birthday,paperType=@papertype,paperNum=@papernum,"
            + "tel=@tel,email=@email,createDate=@createdate,oper=@oper,remark=@remark where id=@id", prams));
    }
    /// <summary>
    /// 每借一次设备就将学生的租借次数加一
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <returns></returns>
    public int UpdateBorrowNum(ReaderManage readermanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 30, readermanage.ID ),
            data.MakeInParam("@borrownum",  SqlDbType.Int, 4, readermanage.BorrowNum),
            data.MakeInParam("@num",  SqlDbType.Int, 4, readermanage.Num),
			};
        return (data.RunProc("update tb_reader set borrownum=@borrownum,num=@num where id=@id", prams));
    }
    #endregion

    #region 删除--学生信息
    /// <summary>
    /// 删除--学生信息
    /// </summary>
    /// <param name="readermanage"></param>
    /// <returns></returns>
    public int DeleteReader(ReaderManage readermanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 30, readermanage.ID ),
			};
        return (data.RunProc("delete from tb_reader where id=@id", prams));
    }
    #endregion

    #region 查询--学生信息
    /// <summary>
    /// 根据--学生编号--得到学生信息
    /// </summary>
    /// <param name="readermanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindReaderByCode(ReaderManage readermanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 30, readermanage.ID +"%"),
			};
        return (data.RunProcReturn("select * from tb_reader where id like @id", prams, tbName));
    }
    /// <summary>
    /// 根据--学生名称--得到学生信息
    /// </summary>
    /// <param name="readermanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindReaderByName(ReaderManage readermanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@name",  SqlDbType.VarChar, 50,readermanage.Name+"%"),
			};
        return (data.RunProcReturn("select * from tb_reader where name like @name", prams, tbName));
    }
    /// <summary>
    /// 根据--学生类型--得到学生信息
    /// </summary>
    /// <param name="readermanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindReaderByType(ReaderManage readermanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@type",  SqlDbType.VarChar, 50, readermanage.Type+"%"),
			};
        return (data.RunProcReturn("select * from tb_reader where type like @type", prams, tbName));
    }
    /// <summary>
    /// 得到所有--学生信息
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllReader(string tbName)
    {
        return (data.RunProcReturn("select * from tb_reader ORDER BY id", tbName));
    }
    /// <summary>
    /// 得到学生租借排行的前5名
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetReaderSort(string tbName)
    {
        return (data.RunProcReturn("select top 5* from tb_reader where borrownum<>0 ORDER BY borrownum desc", tbName));
    }
    /// <summary>
    /// 得到所有学生租借排行
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllReaderSort(string tbName)
    {
        return (data.RunProcReturn("select * from tb_reader where borrownum<>0 ORDER BY borrownum desc", tbName));
    }
    #endregion

    #region 学生登录
    /// <summary>
    /// 学生登录
    /// </summary>
    /// <param name="readermanage"></param>
    /// <returns></returns>
    public DataSet ReaderLogin(ReaderManage readermanage)
    {
        SqlParameter[] prams = {
            data.MakeInParam("@id",  SqlDbType.VarChar, 30, readermanage.ID ),
            data.MakeInParam("@name",  SqlDbType.VarChar, 50,readermanage.Name ),
			};
        return (data.RunProcReturn("SELECT * FROM tb_reader WHERE (id = @id) AND (name = @name)", prams, "tb_reader"));
    }
    #endregion
}