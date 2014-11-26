<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PropertyAddCOI.aspx.cs" Inherits="SONIC_Exposures_PropertyAddCOI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>       
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
</head>
<body>
<script type="text/javascript">
        function SelectCOIFile(Filename,uploadedFileName)
        {
            if(Page_ClientValidate())
            {
//                var fullPath = document.getElementById('<%=fpFile.ClientID%>').value;
//                var fileName = fullPath.substring(fullPath.lastIndexOf('\\')+ 1);
                var dtDate = document.getElementById('<%=txtCOI_Date.ClientID%>').value;
                var lnk = '<%=Request.QueryString["lnk"]%>';
                var hdnDateID = lnk + "_Date";
                hdnDateID = hdnDateID.replace("lnk","hdn");
                parent.parent.document.getElementById('<%=Request.QueryString["lnk"]%>').innerHTML=Filename;
                parent.parent.document.getElementById('<%=Request.QueryString["hdn"]%>').value = uploadedFileName;
                parent.parent.document.getElementById('<%=Request.QueryString["chk"]%>').checked = true;
                parent.parent.document.getElementById('<%=Request.QueryString["dtID"]%>').innerHTML = dtDate;
                parent.parent.document.getElementById(hdnDateID).value = dtDate;
                parent.parent.GB_hide();
                return false;
            }
        }
    </script>    
    <form id="form1" runat="server">
    <div>
    <asp:ValidationSummary ID="valPropertyCOPE" runat="server" ValidationGroup="ValAttach" ShowMessageBox="true" ShowSummary="false"
    HeaderText="Verify the following fields" BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />

    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" class="Spacer" style="height:30px;" colspan="4">
            </td>
        </tr>
        <tr>
            <td width="15px">&nbsp;</td>
            <td width="30%" align="left" valign="top">
                 Attach Sub-Tenant Certificate of Insurance   
            </td>
            <td width="4%" align="center" valign="top">:</td>
            <td align="left" valign="top">                
                <asp:FileUpload ID="fpFile" runat="server" CssClass="txtBox" />
                <asp:RequiredFieldValidator ID="rvFile" ControlToValidate="fpFile" 
                ErrorMessage="Please select the File" runat="server" SetFocusOnError="true"  ValidationGroup="ValAttach" Display="none" />
            </td>            
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height:10px;" colspan="4">
            </td>
        </tr>        
        <tr>
            <td>&nbsp;</td>
            <td align="left">
                Specify Date
            </td>
            <td width="4%" align="center">:</td>
            <td align="left">
                <asp:TextBox runat="server" ID="txtCOI_Date" Width="130px" SkinID="txtDate"></asp:TextBox>
                <img alt="Expiration Date" onclick="return showCalendar('<%=txtCOI_Date.ClientID%>', 'mm/dd/y');"
                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                align="middle" />
                <asp:RangeValidator ID="regCOI_Date" ControlToValidate="txtCOI_Date" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" 
                ErrorMessage="Date is not valid." runat="server" SetFocusOnError="true"  ValidationGroup="ValAttach" Display="none" />
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height:10px;" colspan="4">
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">           
                <asp:Button ID="btnContinue" runat="server" Text="Continue" OnClick="btnContinue_Click" ValidationGroup="ValAttach" />
                <%--<input type="button" value="Continue" onclick="SelectCOIFile();" class="btn" />                --%>
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height:10px;" colspan="4">
            </td>
        </tr>
    </table>
    </div>
    </form>
    
    
</body>
</html>
