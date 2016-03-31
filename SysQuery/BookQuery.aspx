<%@ Page Language="C#" MasterPageFile="~/MasterPage/MainMasterPage.master" AutoEventWireup="true" CodeFile="BookQuery.aspx.cs" Inherits="SysQuery_BookQuery" Title="Untitled Page" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="771" height="465" border="0" align="center" cellpadding="0" cellspacing="1" class="waikuang">
        <tr><form name="form1" method="post" action="">
          <td valign="top"><table width="756" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="756" height="24" colspan="3" align="right">&nbsp;</td>
            </tr>
            <tr>
              <td height="45" colspan="3" background="../images/tushujieyuechaxun.gif" style="background-image: url(../images/tushudanganchaxun.gif)">&nbsp;</td>
            </tr>
            <tr>
              <td colspan="3" background="../images/qicaizujie pai hang2.gif">&nbsp;</td>
            </tr>
            <tr>
              <td colspan="3" valign="top" background="../images/qicaizujie pai hang2.gif" style="height: 246px">                
                <p><table width="745" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                  <td align="center"></td>
                  </tr>
                <tr>
                  <td height="5" colspan="2" style="width: 707px"><table width="720" height="30" border="1" align="center" cellpadding="0" cellspacing="0" bordercolorlight="#B7B6B6" bordercolordark="#FFFFFF">
                    <tr>
                      <td height="28" bgcolor="#DFF5F5" class="daohang1" style="width: 741px"><table height="23" border="0" align="center" cellpadding="0" cellspacing="0" style="width: 742px">
                        <tr>
                          <td width="46" align="right"><img src="../images/chaxun tubiao.gif" width="32" height="27"></td>
                          <td class="daohang1" style="width: 99px">请选择查询条件：</td>
                          <td style="width: 249px"><label>
                            <asp:DropDownList ID="ddlCondition" runat="server" Width="96px">
                    <asp:ListItem>条形码</asp:ListItem>
                    <asp:ListItem>设备名</asp:ListItem>
                    <asp:ListItem>类别</asp:ListItem>
                    <asp:ListItem>负责老师</asp:ListItem>
                    <asp:ListItem>所属实验室</asp:ListItem>
                    <asp:ListItem>所属</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtCondition" runat="server" Width="137px"></asp:TextBox>
                          </label></td>
                          <td style="width: 183px"><label>
                            <asp:Button ID="btnQuery" runat="server" OnClick="btnQuery_Click" Text="查询" />
                          </label></td>
                        </tr>
                      </table></td>
                      </tr>

                  </table>                    </td>
                </tr>
              </table>
                <asp:GridView ID="gvBookInfo" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333" PageSize="5" AutoGenerateColumns="False" Font-Size="9pt" OnPageIndexChanging="gvBookInfo_PageIndexChanging" Width="678px" HorizontalAlign="Center">
                    <HeaderStyle BackColor="#DFF5F5" Font-Bold="False" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField DataField="equcode" HeaderText="条形码" ReadOnly="True" />
                        <asp:BoundField DataField="equname" HeaderText="设备名称" />
                        <asp:BoundField DataField="type" HeaderText="设备类型" />
                        <asp:BoundField DataField="pubname" HeaderText="所属实验室" />
                        <asp:BoundField DataField="bcase" HeaderText="所属" />
                        <asp:BoundField DataField="storage" HeaderText="库存总数" />
                    </Columns>
                </asp:GridView></td>
              </tr>
            
            
            <tr>
              <td height="4" colspan="3" valign="top" background="../images/qicaizujie pai hang3.gif"></td>
            </tr>
            
          </table>
            </td></form>
        </tr>
      </table>
</asp:Content>

