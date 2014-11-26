<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error"
    Theme="Default"   Title="eRIMS Sonic :: Error Page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Error Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 50px;">
        &nbsp;
    </div>
    <h3 align="Center">
        <asp:Label ID="lblMsg" runat="server">Error</asp:Label>
        <br />
        <br />
        <a href="javascript:history.go(-1);">Back</a>
    </h3>
    <div style="height: 50px;">
        &nbsp;
    </div>
    <div style="height: 50px;" runat="server" id="dvErrorXML" align="Center">
        <a href="<%=AppConfig.SiteURL%>Error.xml" style="color: White;">Error.XML</a>
    </div>    
    </form>
</body>

</html>
