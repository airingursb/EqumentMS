<%@ Page Language="C#" MasterPageFile="~/MasterPage/MainMasterPage.master" AutoEventWireup="true" CodeFile="BTypeManage.aspx.cs" Inherits="BookManage_BTypeManage" Title="Untitled Page" EnableEventValidation="false"%>
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
                  <td colspan="3" align="right" background="../images/danganguanli.gif" style="height: 45px; background-image: url(../images/tushuleixingguanli.gif);">&nbsp;</td>
                  </tr>
                <tr>
                  <td width="622" height="32" align="right"><img src="../images/tianjia tubiao.gif" width="19" height="18"></td>
                  <td width="89" align="right" class="daohang1"><asp:HyperLink ID="hpLinkAddBType" runat="server" NavigateUrl="~/BookManage/AddBType.aspx" Width="98px" ForeColor="Black">添加设备类型信息</asp:HyperLink></td>
                  <td width="45">&nbsp;</td>
                </tr>
              </table></td>
            </tr>
            <tr>
              <td height="23" background="../images/qicaizujie pai hang2.gif"><asp:GridView ID="gvBTypeInfo" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333" PageSize="5" AutoGenerateColumns="False" Font-Size="9pt" OnPageIndexChanging="gvBTypeInfo_PageIndexChanging" OnRowCancelingEdit="gvBTypeInfo_RowCancelingEdit" OnRowDeleting="gvBTypeInfo_RowDeleting" OnRowEditing="gvBTypeInfo_RowEditing" OnRowUpdating="gvBTypeInfo_RowUpdating" Width="543px" HorizontalAlign="Center" Height="221px">
                    <HeaderStyle BackColor="#DFF5F5" Font-Bold="False" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="设备类型编号" ReadOnly="True" />
                        <asp:BoundField DataField="typename" HeaderText="设备类型名称" />
                        <asp:BoundField DataField="days" HeaderText="可借天数" />
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
            </td>
        </tr>
      </table>
</asp:Content>

