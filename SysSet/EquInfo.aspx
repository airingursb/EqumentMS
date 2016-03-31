<%@ Page Language="C#" MasterPageFile="~/MasterPage/MainMasterPage.master" AutoEventWireup="true" CodeFile="EquInfo.aspx.cs" Inherits="SysSet_LibraryInfo" Title="Untitled Page" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="771" height="465" border="0" align="center" cellpadding="0" cellspacing="1" class="waikuang">
        <tr>
            <form name="form1" method="post" action="">
          <td valign="top"><table width="756" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="756" height="24" colspan="3" align="right">&nbsp;</td>
            </tr>
            <tr>
              <td height="45" colspan="3" background="../images/tushuguanxinxi.gif">&nbsp;</td>
            </tr>
            <tr>
              <td colspan="3" background="../images/qicaizujie pai hang2.gif"><table width="730" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                  <td colspan="4" align="center">&nbsp;</td>
                  </tr>
                <tr>
                  <td width="163" height="26" align="right" class="daohang1">&nbsp;</td>
                  <td width="74" align="center" class="daohang1">实验室名称：</td>
                  <td colspan="2"><label>
                    <asp:TextBox ID="txtLibName" runat="server"></asp:TextBox>
                  </label></td>
                  <td width="303" align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="28" align="right" class="daohang1">&nbsp;</td>
                  <td height="28" align="center" class="daohang1">负责老师：</td>
                  <td colspan="2"><asp:TextBox ID="txtCurator" runat="server"></asp:TextBox></td>
                  <td align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="25" align="right" class="daohang1">&nbsp;</td>
                  <td height="25" align="center" class="daohang1">电话：</td>
                  <td colspan="2"><asp:TextBox ID="txtTel" runat="server"></asp:TextBox></td>
                  <td align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="29" align="right" class="daohang1">&nbsp;</td>
                  <td height="29" align="center" class="daohang1">地址：</td>
                  <td colspan="2"><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
                  <td align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="29" align="right" class="daohang1">&nbsp;</td>
                  <td height="29" align="center" class="daohang1">E-mail:</td>
                  <td colspan="2"><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                  <td align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="25" align="right" class="daohang1">&nbsp;</td>
                  <td height="25" align="center" class="daohang1">网址：</td>
                  <td colspan="2"><asp:TextBox ID="txtUrl" runat="server"></asp:TextBox></td>
                  <td align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="27" align="right" class="daohang1">&nbsp;</td>
                  <td height="27" align="center" class="daohang1">成立时间：</td>
                  <td colspan="2" class="daohang1"><asp:TextBox ID="txtCDate" runat="server"></asp:TextBox></td>
                  <td align="center" style="text-align: left" class="daohang1">（格式为2007-01-01）&nbsp;</td>
                </tr>
                <tr>
                  <td height="88" align="right" class="daohang1">&nbsp;</td>
                  <td height="88" align="center" class="daohang1">简介：</td>
                  <td colspan="2"><label>
                      <asp:TextBox ID="txtIntroduce" runat="server" Height="85px" TextMode="MultiLine" Width="151px"></asp:TextBox>
                      <br>
                                </label></td>
                  <td align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="25" colspan="2" align="center">&nbsp;</td>
                    <td colspan="2">
                        <label>
                  </label><label>
                    <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
                      &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" CausesValidation="False" />
                  </label>
                    </td>
                  <td align="center">&nbsp;</td>
                </tr>
              </table>                
                <p>&nbsp;</p>
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

