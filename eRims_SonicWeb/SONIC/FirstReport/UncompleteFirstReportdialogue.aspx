<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UncompleteFirstReportdialogue.aspx.cs" Inherits="SONIC_UncompleteFirstReportdialogue" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">
    function ClosePopup()
    {
        parent.parent.document.getElementById('hdntext').value="true";
        parent.parent.GB_hide();
    }
    function OpenWizardPage()
    {
        parent.parent.document.getElementById('hdntext').value="false";
        parent.parent.GB_hide();
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr runat="server" id="trQuestion" style="display:block;">
        <td>
            <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height:50px">
            <tr>
                <td colspan="2">
                    You have an uncompleted First Report.<br />would you like to work on that now?
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="Server" ID="btnYes" Text="Yes" ToolTip="Yes" OnClick="btnYes_Click" />
                </td>
                <td>
                    <asp:Button runat="server" ID="btnNo" Text="No" ToolTip="No" OnClick="btnNo_Click" />
                </td>
            </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
    <tr runat="server" id="trGrid" style="display:block;">
        <td align="center">
            <asp:GridView ID="gvFirstReportWizardID" runat="server" DataKeyNames="PK_First_Report_Wizard_ID" AutoGenerateColumns="false" Width="50%" AllowSorting="false" AllowPaging="true" OnRowCommand="gvFirstReportWizardID_RowCommand" OnRowCreated="gvFirstReportWizardID_RowCreated" OnRowDataBound="gvFirstReportWizardID_RowDataBound" OnPageIndexChanging="gvFirstReportWizardID_PageIndexChanging">
           <Columns>
           <asp:TemplateField HeaderText="First Report Wizard ID" HeaderStyle-HorizontalAlign="center">
                <ItemStyle HorizontalAlign="Center" Width="15%" />
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lnkReportID" Text='<%#Eval("PK_First_Report_Wizard_ID")%>' CommandName="Redirect"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
    </table> 
    </form>
</body>

</html>
