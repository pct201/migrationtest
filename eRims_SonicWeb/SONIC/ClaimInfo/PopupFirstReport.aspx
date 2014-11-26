<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopupFirstReport.aspx.cs"
    Inherits="SONIC_FirstReport_PopupFirstReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <div>
        <table cellpadding="1" cellspacing="0" width="100%">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    <asp:GridView ID="gvFirstReport" runat="server" AutoGenerateColumns="false" Width="100%"
                        DataKeyNames="PK_WC_FR_ID" EmptyDataText="No Record Found" AllowSorting="true" 
                        AllowPaging="true" PageSize="20" OnSorting="gvFirstReport_Sorting" OnRowCreated="gvFirstReport_RowCreated"
                        OnRowDataBound="gvFirstReport_RowDataBound" OnPageIndexChanging="gvFirstReport_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="First Report Number" SortExpression="WC_FR_NUMBER" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="25%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkWC_FR_NUMBER" runat="server" CommandArgument='<% #Eval("WC_FR_NUMBER") %>'
                                        Text='<% #Eval("WC_FR_NUMBER") %>' CssClass="acher"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Employee Name" SortExpression="NAME" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="25%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkNAME" runat="server" CommandArgument='<% #Eval("NAME") %>'
                                        Text='<% #Eval("NAME") %>' CssClass="acher"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Sonic Location d/b/a" SortExpression="DBA" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="25%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDBA" runat="server" CommandArgument='<% #Eval("DBA") %>'
                                        Text='<% #Eval("DBA") %>' CssClass="acher"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>

    <script type="text/javascript">
        function SelectValue(strPK_WC_FR_ID, strWC_FR_NUMBER,strName,strDBA) {
            window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdnid').value = strPK_WC_FR_ID;
            window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtAssociatedFirstReport').value = strWC_FR_NUMBER;
            window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtEmployeeName').value = strName;
            window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtSonicLocation').value = strDBA;
            self.close();
            return false;
        }
    </script>

    </form>
</body>
</html>
