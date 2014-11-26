<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="SONIC_Exposures_Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language='javascript'>
    var t;
    function doLoad() {
        t = setTimeout("window.close()", 3000);
    }
    function clockStop() {
        clearTimeout(t);
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>

</head>
<body >
    <form id="form1" runat="server">
    <div>
        <br /><br /><br /><br /><br />
        <asp:LinkButton ID="lnktest" runat="server" style="display:none" />
        <asp:LinkButton ID="lnkGenerateDoc" runat="server" OnClick="lnkGenerateDoc_Click" Font-Bold="true" OnClientClick="javascript:doLoad();" Text="Click Here to Generate Document" Font-Size="Small" />
    </div>
    </form>     
</body>
</html>
