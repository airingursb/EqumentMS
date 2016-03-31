<%@ Page Language="C#" MasterPageFile="~/MasterPage/MainMasterPage.master" AutoEventWireup="true" CodeFile="AddBook.aspx.cs" Inherits="BookManage_AddBook" Title="Untitled Page" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="771" height="465" border="0" align="center" cellpadding="0" cellspacing="1" class="waikuang">
        <tr>
          <form name="form1" method="post" action="">
          <td valign="top"><table width="756" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="756" height="24" colspan="3" align="right">&nbsp;</td>
            </tr>
            <tr>
              <td height="45" colspan="3" background="../images/tianjiaxiugaitushuxinxi.gif">&nbsp;</td>
            </tr>
            <tr>
              <td colspan="3" background="../images/qicaizujie pai hang2.gif"><table width="730" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                  <td colspan="5" align="center">&nbsp;</td>
                  </tr>
                <tr>
                  <td width="175" height="26" align="right" class="daohang1">&nbsp;</td>
                  <td width="66" align="center" class="daohang1">条形码：</td>
                  <td colspan="3"><label>
                    <asp:TextBox ID="txtBCode" runat="server"></asp:TextBox>
                  </label></td>
                  <td width="306" align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="28" align="right" class="daohang1">&nbsp;</td>
                  <td height="28" align="center" class="daohang1">设备名称：</td>
                  <td colspan="3"><asp:TextBox ID="txtBName" runat="server"></asp:TextBox></td>
                  <td align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="25" align="right" class="daohang1">&nbsp;</td>
                  <td height="25" align="center" class="daohang1">设备类型：</td>
                  <td colspan="3"><label>
                    <asp:DropDownList ID="ddlBType" runat="server" Width="155px">
                </asp:DropDownList>
                  </label></td>
                  <td align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="29" align="right" class="daohang1">&nbsp;</td>
                  <td height="29" align="center" class="daohang1">负责老师：</td>
                  <td colspan="3"><asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox></td>
                  <td align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="25" align="right" class="daohang1">&nbsp;</td>
                  <td height="25" align="center" class="daohang1">购买员:</td>
                  <td colspan="3"><asp:TextBox ID="txtTranslator" runat="server"></asp:TextBox></td>
                  <td align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="25" align="right" class="daohang1">&nbsp;</td>
                  <td height="25" align="center" class="daohang1">所属实验室：</td>
                  <td colspan="3"><asp:TextBox ID="txtPub" runat="server"></asp:TextBox></td>
                  <td align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="27" align="right" class="daohang1">&nbsp;</td>
                  <td height="27" align="center" class="daohang1">价格：</td>
                  <td colspan="3"><asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></td>
                  <td align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="27" align="right" class="daohang1">&nbsp;</td>
                  <td height="27" align="center" class="daohang1">所属：</td>
                  <td colspan="3"><label>
                    <asp:DropDownList ID="ddlBCase" runat="server" Width="155px">
        </asp:DropDownList>
                  </label></td>
                  <td align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="28" align="right" class="daohang1">&nbsp;</td>
                  <td height="28" align="center" class="daohang1">库存数量：</td>
                  <td colspan="3"><asp:TextBox ID="txtStorage" runat="server"></asp:TextBox></td>
                  <td align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="25" align="right" class="daohang1">&nbsp;</td>
                  <td height="25" align="center" class="daohang1">购买时间：</td>
                  <td colspan="3"><asp:TextBox ID="txtInTime" runat="server"></asp:TextBox></td>
                  <td align="center" style="text-align: left" class="daohang1">（格式为2007-01-01）&nbsp;</td>
                </tr>
                <tr>
                  <td height="26" align="right" class="daohang1">&nbsp;</td>
                  <td height="26" align="center" class="daohang1">操作员：</td>
                  <td colspan="3"> <asp:TextBox ID="txtOper" runat="server"></asp:TextBox></td>
                  <td align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td height="25" colspan="2" align="center">&nbsp;</td>
                  <td colspan="3"><label>
                  </label>
                    <label>
                    </label>
                    <asp:Button ID="btnAdd" runat="server" Enabled="False" OnClick="btnAdd_Click" Text="添加" />
                      &nbsp;
                    <asp:Button ID="btnSave" runat="server" Text="修改" OnClick="btnSave_Click" Enabled="False" />
                      &nbsp;
                      <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" /></td>
                  <td align="center">&nbsp;</td>
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

