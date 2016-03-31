<%@ Page Language="C#" MasterPageFile="~/MasterPage/MainMasterPage.master" AutoEventWireup="true" CodeFile="ChanagePwd.aspx.cs" Inherits="Common_ChanagePwd" Title="Untitled Page" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="771" height="465" border="0" align="center" cellpadding="0" cellspacing="1" class="waikuang">
        <tr>
          <form name="form1" method="post" action="">
          <td valign="top"><table width="756" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="756" height="24" colspan="3" align="right">&nbsp;</td>
            </tr>
            <tr>
              <td height="45" colspan="3" background="../images/tianjiaxiugaitushuxinxi.gif" style="background-image: url(../images/genggaimima.gif)">&nbsp;</td>
            </tr>
            <tr>
              <td colspan="3" background="../images/qicaizujie pai hang2.gif"><table width="730" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                  <td colspan="5" align="center">&nbsp;</td>
                  </tr>
                <tr>
                  <td width="175" height="26" align="right" class="daohang1">&nbsp;</td>
                  <td align="center" class="daohang1" style="width: 85px">管理员名称：</td>
                  <td colspan="3"><label>
                    <asp:TextBox ID="txtName" runat="server" ReadOnly="True"></asp:TextBox>
                  </label></td>
                  <td align="center" style="width: 294px">&nbsp;</td>
                </tr>
                <tr>
                  <td height="28" align="right" class="daohang1">&nbsp;</td>
                  <td height="28" align="center" class="daohang1" style="width: 85px">原密码：</td>
                  <td colspan="3"><asp:TextBox ID="txtYPwd" runat="server" TextMode="Password" Width="151px"></asp:TextBox></td>
                  <td align="center" style="width: 294px">&nbsp;</td>
                </tr>
                <tr>
                  <td height="25" align="right" class="daohang1">&nbsp;</td>
                  <td height="25" align="center" class="daohang1" style="width: 85px">新密码：</td>
                  <td colspan="3"><label>
                    <asp:TextBox ID="txtXPwd" runat="server" TextMode="Password" Width="151px"></asp:TextBox>
                  </label></td>
                  <td align="center" style="width: 294px">&nbsp;</td>
                </tr>
                <tr>
                  <td height="29" align="right" class="daohang1">&nbsp;</td>
                  <td height="29" align="center" class="daohang1" style="width: 85px">确认新密码：</td>
                  <td colspan="3"><asp:TextBox ID="txtSXPwd" runat="server" TextMode="Password" Width="151px"></asp:TextBox></td>
                  <td align="center" style="width: 294px; text-align: left"><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtXPwd"
                    ControlToValidate="txtSXPwd" ErrorMessage="密码输入不一致" Font-Size="9pt"></asp:CompareValidator></td>
                </tr>
                <tr>
                  <td height="25" colspan="2" align="center">&nbsp;</td>
                  <td colspan="3"><label>
                  </label>
                    <label>
                    </label>
                    <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
                      &nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="重置" OnClick="btnCancel_Click" CausesValidation="False" />
                    </td>
                  <td align="center" style="width: 294px">&nbsp;</td>
                </tr>
              </table>                
                <p>
                  <label></label>
                </p>
               </td>
              </tr>
            <tr>
              <td height="4" colspan="3" valign="top" background="../images/qicaizujie pai hang3.gif"></td>
            </tr>
            
          </table>
            </td></form>
        </tr>
      </table>
</asp:Content>

