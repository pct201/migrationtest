<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopupBuildingRelatedInformation.aspx.cs"
    Inherits="DashBoard_PopupBuildingRelatedInformation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Building Related Information</title>
</head>
<script type="text/javascript" language="javascript">
    function OpenPropertyData() {
        var Location = '<%= Encryption.Encrypt(ViewState["Pk_Location"].ToString())%>';
        var BuildingNum = '<%= Encryption.Encrypt(ViewState["Pk_Building"].ToString())%>';
        window.opener.parent.opener.parent.parent.location = "<%= AppConfig.SiteURL%>SONIC/Exposures/Property.aspx?loc=" + Location + "&build=" + BuildingNum;
        window.opener.close();
        window.close();
    }
</script>
<script type="text/javascript" language="javascript">
    function OpenEnvironmentalData() {
        var LocationID = '<%= Encryption.Encrypt(ViewState["Pk_Location"].ToString())%>';
        var SiteID = '<%= Encryption.Encrypt(ViewState["PK_PM_Site_Information"].ToString())%>';
        var BuildingNum = '<%= Encryption.Encrypt(ViewState["Pk_Building"].ToString())%>';
        window.opener.parent.opener.parent.parent.location = "<%= AppConfig.SiteURL%>SONIC/Pollution/Pollution.aspx?op=" + 'edit' + "&id=" + SiteID + "&loc=" + LocationID + "&Build=" + BuildingNum;
        window.opener.close();
        window.close();
    }
</script>
<script type="text/javascript" language="javascript">
    function ClosePopup() {
        window.close();
    }
</script>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="ghc" colspan="3" align="left">
                    Building Related Information
                </td>
            </tr>
            <tr>
                <td colspan="3" align="left" height="10px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnPropertyData" Text="Property Data" runat="server" OnClientClick="javascript:return OpenPropertyData();" />
                </td>
                <td>
                    <asp:Button ID="btnEnvironmentalData" Text="Environmental Data" runat="server" OnClientClick="javascript:return OpenEnvironmentalData();" />
                </td>
                <td>
                    <asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClientClick="javascript:return ClosePopup();" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
