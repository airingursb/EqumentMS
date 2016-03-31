<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>实验设备租借系统登录页面</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>
<link href="css.css" rel="stylesheet" type="text/css"/>
<style type="text/css">
<!--
body {
	background-color: #DDDDDD;
}
-->
</style>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
<div align="center">
  <table id="Table1" width="914" height="759" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td rowspan="5" bgcolor="#DDDDDD">&nbsp;</td>
	    <td height="253" valign="bottom" bgcolor="#65D7D4">&nbsp;</td>
	    <td rowspan="5" bgcolor="#DDDDDD">&nbsp;</td>
    </tr>
    <tr><form name="form1" method="post" action="" runat="server">
      <td height="249" valign="top" background="images/denglu.gif"><table width="777" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="421" height="103">&nbsp;</td>
          <td width="65">&nbsp;</td>
          <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
          <td height="26">&nbsp;</td>
          <td><span class="daohang1">用户登录：
            </span>
            <label></label></td>
          <td colspan="3"><label>
            <asp:TextBox ID="txtAdmin" runat="server"></asp:TextBox>
              &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
          </label></td>
        </tr>
        <tr>
          <td height="22">&nbsp;</td>
          <td class="daohang1">用户密码：</td>
          <td colspan="3"><label>
            <asp:TextBox ID="txtPwd" runat="server" Width="148px" TextMode="Password"></asp:TextBox>
              &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;</label></td>
        </tr>
        <tr>
          <td height="31">&nbsp;</td>
          <td><span class="daohang1">验证码：</span>
            <label></label></td>
          <td colspan="3"><label>
            <asp:TextBox ID="txtCode" runat="server" Width="96px"></asp:TextBox><asp:Image ID="Image1" runat="server" ImageUrl="~/Common/checkcode.aspx"/>
              &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
          </label></td></tr>
        <tr>
          <td height="27">&nbsp;</td>
          <td>&nbsp;</td>
          <td width="69"><label>
            <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" />
          </label></td>
          <td width="51"><label>
            <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
          </label></td>
          <td width="171"><label></label></td>
        </tr>
      </table></td>
    </form>
    </tr>
    <tr>
      <td width="777" height="272" bgcolor="#65D7D4">&nbsp;</td>
    </tr>
    <tr>
      <td height="66" background="images/index_14.gif">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="3" bgcolor="#DDDDDD">&nbsp;</td>
    </tr>
  </table>
</div>
</body>
</html>
