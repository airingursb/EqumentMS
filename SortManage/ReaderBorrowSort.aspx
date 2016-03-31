<%@ Page Language="C#" MasterPageFile="~/MasterPage/MainMasterPage.master" AutoEventWireup="true" CodeFile="ReaderBorrowSort.aspx.cs" Inherits="SortManage_ReaderBorrowSort" Title="Untitled Page" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table align="center" style="width: 628px; height: 91px">
        <tr>
      <td height="9" background="../images/index_08.gif"></td>
    </tr>
    <tr>
      <td width="777" height="472">
            <table width="756" border="0" align="center" cellpadding="0" cellspacing="0">
              <tr>
                <td height="4"></td>
              </tr>
              <tr>
                <td width="756" height="45" background="../images/qicaizujie pai hang.gif">&nbsp;</td>
              </tr>
              <tr>
                <td height="200" background="../images/qicaizujie pai hang2.gif"><asp:GridView ID="gvReaderSort" runat="server" AutoGenerateColumns="False"
                    CellPadding="4" Font-Size="9pt" ForeColor="#333333" HorizontalAlign="Center" Width="678px" OnRowDataBound="gvReaderSort_RowDataBound" AllowPaging="True" OnPageIndexChanging="gvReaderSort_PageIndexChanging">
                    <Columns>
                        <asp:BoundField HeaderText="排名" />
                        <asp:BoundField DataField="id" HeaderText="学号" />
                        <asp:BoundField DataField="name" HeaderText="姓名" />
                        <asp:BoundField DataField="type" HeaderText="班级" />
                        <asp:BoundField DataField="paperType" HeaderText="证件类型" />
                        <asp:BoundField DataField="paperNum" HeaderText="证件号码" />
                        <asp:BoundField DataField="tel" HeaderText="电话" />
                        <asp:BoundField DataField="sex" HeaderText="性别" />
                    </Columns>
                    <HeaderStyle BackColor="#DFF5F5" Font-Bold="False" ForeColor="Black" />
                </asp:GridView></td>
              </tr>
              <tr>
                <td height="4" background="../images/qicaizujie pai hang3.gif"></td>
              </tr>
            </table></td>
        </tr>
      </table>
</asp:Content>

