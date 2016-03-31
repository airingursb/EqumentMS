<%@ Page Language="C#" MasterPageFile="~/MasterPage/MainMasterPage.master" AutoEventWireup="true" CodeFile="ReaderManage.aspx.cs" Inherits="ReaderManage_ReaderManage" Title="Untitled Page" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="771" height="465" border="0" align="center" cellpadding="0" cellspacing="1" class="waikuang">
        <tr>
          <td valign="top"><table width="756" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="756" height="24" align="right" class="daohang1">&nbsp;</td>
            </tr>
            <tr>
              <td height="22" background="../images/qicaizujie pai hang2.gif"><table width="756" height="77" border="0" align="right" cellpadding="0" cellspacing="0">
                <tr>
                  <td colspan="3" align="right" background="../images/danganguanli.gif" style="height: 44px; background-image: url(../images/duzhedanganguanli.gif);">&nbsp;</td>
                  </tr>
                <tr>
                  <td width="622" height="32" align="right"><img src="../images/tianjia tubiao.gif" width="19" height="18"></td>
                  <td width="89" align="right" class="daohang1"><asp:HyperLink ID="hpLinkAddReader" runat="server" NavigateUrl="~/ReaderManage/AddReader.aspx" ForeColor="Black">添加学生信息</asp:HyperLink></td>
                  <td width="45">&nbsp;</td>
                </tr>
              </table></td>
            </tr>
            <tr>
              <td height="23" background="../images/qicaizujie pai hang2.gif"><asp:GridView ID="gvReaderInfo" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333" PageSize="5" AutoGenerateColumns="False" Font-Size="9pt" OnPageIndexChanging="gvReaderInfo_PageIndexChanging" OnRowDeleting="gvReaderInfo_RowDeleting"  Width="678px" HorizontalAlign="Center">
                    <HeaderStyle BackColor="#DFF5F5" Font-Bold="False" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="学号" ReadOnly="True" />
                        <asp:BoundField DataField="name" HeaderText="姓名" />
                        <asp:BoundField DataField="type" HeaderText="班级" />
                        <asp:BoundField DataField="paperType" HeaderText="证件类型" />
                        <asp:BoundField DataField="paperNum" HeaderText="证件号码" />
                        <asp:BoundField DataField="tel" HeaderText="电话" />
                        <asp:BoundField DataField="email" HeaderText="Email" />
                        <asp:HyperLinkField DataNavigateUrlFormatString="AddReader.aspx?readerid={0}" HeaderText="详情"
                            Text="详情" DataNavigateUrlFields="id" >
                            <ControlStyle ForeColor="Black" />
                            <ItemStyle ForeColor="Black" />
                            <HeaderStyle ForeColor="Black" />
                        </asp:HyperLinkField>
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
                <p>&nbsp;</p></td>
            </tr>
            <tr>
              <td height="4" valign="top" background="../images/qicaizujie pai hang3.gif"></td>
            </tr>
            
          </table>
            </td>
        </tr>
      </table>
</asp:Content>

