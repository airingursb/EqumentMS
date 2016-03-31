<%@ Page Language="C#" MasterPageFile="~/MasterPage/MainMasterPage.master" AutoEventWireup="true" CodeFile="RTypeManage.aspx.cs" Inherits="ReaderManage_RTypeManage" Title="Untitled Page" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="756" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="756" height="24" align="right" class="daohang1">&nbsp;</td>
            </tr>
            <tr>
              <td height="22" background="../images/qicaizujie pai hang2.gif">
<table width="756" height="77" border="0" align="right" cellpadding="0" cellspacing="0">
                <tr>
                  <td colspan="3" align="right" background="../images/shujiaxinxi.gif" style="height: 44px; background-image: url(../images/duzheleixingguanli.gif);">&nbsp;</td>
                  </tr>
                <tr>
                  <td width="626" height="32" align="right"><img src="../images/tianjia tubiao.gif" width="19" height="18"></td>
                  <td width="85" align="right" class="daohang1"><asp:HyperLink ID="hpLinkAddRType" runat="server" NavigateUrl="~/ReaderManage/AddRType.aspx" Width="102px" ForeColor="Black">添加学生类型信息</asp:HyperLink></td>
                  <td width="45">&nbsp;</td>
                </tr>
              </table></td>
            </tr>
            <tr>
              <td height="23" background="../images/qicaizujie pai hang2.gif"><asp:GridView ID="gvRTypeInfo" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333" PageSize="5" AutoGenerateColumns="False" Font-Size="9pt" OnPageIndexChanging="gvRTypeInfo_PageIndexChanging" OnRowCancelingEdit="gvRTypeInfo_RowCancelingEdit" OnRowDeleting="gvRTypeInfo_RowDeleting" OnRowEditing="gvRTypeInfo_RowEditing" OnRowUpdating="gvRTypeInfo_RowUpdating" Width="543px" HorizontalAlign="Center">
                    <HeaderStyle BackColor="#DFF5F5" Font-Bold="True" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="班级编号" ReadOnly="True" />
                        <asp:BoundField DataField="name" HeaderText="班级名称" />
                        <asp:BoundField DataField="number" HeaderText="可借数量" />
                        <asp:CommandField EditText="修改" HeaderText="修改" ShowEditButton="True" />
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
                <p>&nbsp;</p></td>
            </tr>
            <tr>
              <td height="4" valign="top" background="../images/qicaizujie pai hang3.gif"></td>
            </tr>
            
          </table>
</asp:Content>

