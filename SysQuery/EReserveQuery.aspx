<%@ Page Language="C#" MasterPageFile="~/MasterPage/MainMasterPage.master" AutoEventWireup="true" CodeFile="EReserveQuery.aspx.cs" Inherits="SysQuery_EReserveQuery" Title="Untitled Page" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="771" height="465" border="0" align="center" cellpadding="0" cellspacing="1" class="waikuang">
        <tr><form name="form1" method="post" action="">
          <td valign="top"><table width="756" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="756" height="24" colspan="3" align="right">&nbsp;</td>
            </tr>
            <tr>
              <td height="45" colspan="3" background="../images/qicaiyudingchaxun.gif">&nbsp;</td>
            </tr>
            <tr>
              <td colspan="3" background="../images/tu shu pai hang2.gif">&nbsp;</td>
            </tr>
            <tr>
              <td colspan="3" valign="top" background="../images/tu shu pai hang2.gif" style="height: 246px">                
                <p><table width="745" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                  <td align="center"></td>
                  </tr>
                <tr>
                  <td height="5" colspan="2"><table width="720" height="30" border="1" align="center" cellpadding="0" cellspacing="0" bordercolorlight="#B7B6B6" bordercolordark="#FFFFFF">
                    <tr>
                      <td height="28" bgcolor="#DFF5F5" class="daohang1"><table width="740" height="23" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                          <td width="46" align="right"><img src="../images/chaxun tubiao.gif" width="32" height="27"></td>
                          <td width="104" class="daohang1">请选择查询条件：</td>
                          <td width="97"><label>
                            <asp:DropDownList ID="ddlCondition" runat="server" Width="96px" CausesValidation="True" OnSelectedIndexChanged="ddlCondition_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem>设备条形码</asp:ListItem>
                    <asp:ListItem>设备名称</asp:ListItem>
                    <asp:ListItem>设备编号</asp:ListItem>
                    <asp:ListItem>学生姓名</asp:ListItem>
                    <asp:ListItem>预定时间</asp:ListItem>
                </asp:DropDownList>&nbsp; 
                <asp:TextBox ID="txtCondition" runat="server" Width="118px"></asp:TextBox>
                          </label></td>
                          <td width="22" align="center" class="daohang1"><asp:Label ID="Label1" runat="server" Text="从" Visible="False"></asp:Label></td>
                          <td width="113"><label>
                            <asp:TextBox
                ID="txtFTime" runat="server" Visible="False" Width="101px"></asp:TextBox>
                          </label></td>
                          <td width="28" align="center" class="daohang1"><asp:Label ID="Label2" runat="server" Text="到" Visible="False"></asp:Label></td>
                          <td width="112"><asp:TextBox
                ID="txtTTime" runat="server" Visible="False" Width="101px"></asp:TextBox></td>
                          <td width="165" class="daohang1"><asp:Label ID="Label3" runat="server" Text="（日期格式为：2015-01-01）" Visible="False"></asp:Label></td>
                          <td width="53"><label>
                            <asp:Button ID="btnQuery" runat="server" OnClick="btnQuery_Click" Text="查询" />
                          </label></td>
                        </tr>
                      </table></td>
                      </tr>

                  </table>                    </td>
                </tr>
              </table>
                <asp:GridView ID="gvBorrowInfo" runat="server" AllowPaging="True" PageSize="20" AutoGenerateColumns="False" Font-Size="9pt"  
                    OnPageIndexChanging="gvBorrowInfo_PageIndexChanging" Width="678px" 
                    HorizontalAlign="Center" OnRowUpdating="gvBorrowInfo_RowUpdating">
                    <RowStyle HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#DFF5F5" />
                    <Columns>
                        <asp:BoundField DataField="equcode" HeaderText="设备条形码" ReadOnly="True" />
                        <asp:BoundField DataField="equname" HeaderText="设备名称" />
                        <asp:BoundField DataField="readerid" HeaderText="学号" />
                        <asp:BoundField DataField="name" HeaderText="姓名" />
                        <asp:BoundField DataField="reserveTime" HeaderText="预定时间" />
                        <asp:BoundField DataField="isout" HeaderText="是否租借" />

                    </Columns>
                </asp:GridView></td>
              </tr>
            
            
            <tr>
              <td height="4" colspan="3" valign="top" background="../images/tu shu pai hang3.gif"></td>
            </tr>
            
          </table>
            </td></form>
        </tr>
      </table>
</asp:Content>

