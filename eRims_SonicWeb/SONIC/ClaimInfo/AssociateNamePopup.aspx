<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AssociateNamePopup.aspx.cs" Inherits="SONIC_ClaimInfo_AssociateNamePopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">
        function ClosePopup(EmpName) {
            parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_txtAssociateName').value = EmpName;
            parent.parent.GB_hide();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="3" cellspacing="1" border="0">
                        <tr>
                            <td style="width: 18%">
                                Associate Name
                            </td>
                            <td style="width: 4%">
                                :
                            </td>
                            <td style="width: 28%">
                                <asp:TextBox ID="txtAssociateName" runat="server" Width="145px"></asp:TextBox>
                            </td>
                            
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr runat="server" id="trGrid" style="display: block;">
                <td align="center">
                    <asp:GridView ID="gvAssociateName" runat="server" AutoGenerateColumns="false" Width="80%"
                        AllowSorting="false" AllowPaging="true" PageSize="20" OnPageIndexChanging="gvAssociateName_PageIndexChanging"
                        OnRowDataBound="gvAssociateName_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Claimant Name">
                                <ItemStyle HorizontalAlign="left" Width="100%" />
                                <ItemTemplate>
                                    <a href="#" runat="server" id="AssociateNameName">
                                        <%#Eval("Employee_Name")%></a>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table cellpadding="4" cellspacing="0" width="100%">
                                <tr>
                                    <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                        <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <PagerSettings Mode="NumericFirstLast" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
