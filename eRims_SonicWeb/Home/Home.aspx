<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home"
    MasterPageFile="~/Default.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>'+'greybox/';
    </script>

    <link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>

    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>

    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>

    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <input type="hidden" id="hdntext" name="hdntext" value="" />
                <asp:Button runat="server" ID="btnHdnSearchPage" Style="display: none;" OnClick="btnHdnSearchPage_Click" />
                <asp:Button runat="server" ID="btnHdnStatusPage" Style="display: none;" OnClick="btnHdnStatusPage_Click" />
            </td>
        </tr>
    </table>

    <script type="text/javascript">
    
    function OpenWizardPopup()
    {
        GB_showCenter('', '<%=AppConfig.SiteURL%>SONIC/FirstReport/UncompleteFirstReportdialogue.aspx',325,500,ReturnFunction);
    }
    function ReturnFunction()
    {
        if(document.getElementById('hdntext').value == "true")
        {
            __doPostBack(document.getElementById('<%=btnHdnSearchPage.ClientID%>').name,'');
        }
        if(document.getElementById('hdntext').value == "false")
        {
            __doPostBack(document.getElementById('<%=btnHdnStatusPage.ClientID%>').name,'');
        }
        
    }
     
    </script>

</asp:Content>
