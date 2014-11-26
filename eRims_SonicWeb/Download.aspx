<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Download.aspx.cs" Inherits="Download" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta name="robots" content="noindex"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel ID="pnlError" runat="server" Visible="false">
        <div style="height: 50px;">
            &nbsp;
        </div>
        <h3 align="Center">
            <asp:Label ID="lblMsg" runat="server">Error</asp:Label>
            <br />
            <br />
            <a href="javascript:this.close();">Close</a>
        </h3>
        <div style="height: 50px;">
            &nbsp;
        </div>
    </asp:Panel>
    <br /><br />
   <%-- <asp:LinkButton ID="lnkPrint" runat="server" Visible="false" Font-Bold="true" Font-Size="Medium" Text="Print Incident Form" OnClick="lnkPrint_Click" />--%>
</form>
</body>
</html>
