<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManufacturerAddWindow.aspx.cs" Inherits="SONIC_Purchasing_ManufacturerAddWindow" Theme="Default"    %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Manufacturer Add Window</title>
    <%-- <script language="javascript" type="text/javascript">
     function OpenEntityPopUp()
    {
      
        ShowDialog("<%=AppConfig.SiteURL%>/SONIC/Purchasing/ManufacturerPopupWinodow.aspx");              
         return false;
    }
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
     <table cellspacing="0" cellpadding="0" class="tablebackground" width="95%">
            <tr>
                <td class="loc">
                    &nbsp;</td>
            </tr>
            <tr class="ghc">
                <td runat="server" id="tdMainTitle" >
                    Manufacturer Add Winodow</td>
            </tr>
            <tr>
                <td class="loc">
                    &nbsp;</td>
            </tr>            
            <tr>
                <td class="loc">
                    &nbsp;<asp:Label id="lblError" runat="server" SkinID="lblError" EnableViewState="false"></asp:Label></td>
            </tr>
            <tr>
                <td valign="middle" align="center">
                    <table width="98%">                    
                    
                        <tr>
                            <td class="lc" style="width:50%;" align="right">
                                Manufacturer</td>
                            <td class="ic" style="width:50%;" align="left">
                                <asp:TextBox ID="txtManufacture" runat="server"></asp:TextBox>    
                              
                            </td>
                        </tr>
                       
                        <tr>
                            <td class="loc" colspan="2">
                               &nbsp; </td>
                        </tr>
                        <tr>
                            <td width="80%" colspan="2" class="cc">                              
                                <asp:Button ID="btnSave" runat="server"  Text=    "Save" OnClick="btnSave_Click" />
                                 <asp:Button ID="btnCancel" runat="server"  Text="Cancel" OnClick="btnCancel_Click" />
                             </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblRegisterScript" runat="server"></asp:Label></td>
            </tr>
        </table>
    </form>
</body>
</html>
