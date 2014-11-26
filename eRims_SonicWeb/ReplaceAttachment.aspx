<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReplaceAttachment.aspx.cs" Inherits="ReplaceAttachment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Replace Attachment</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <div>
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3" class="ghc" align="left">
                    Replace Attachment
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="26%" align="left">
                    &nbsp;&nbsp;&nbsp;&nbsp;Select File
                </td>
                <td width="4%" align="center">
                    :                    
                </td>
                <td align="left">
                    <asp:FileUpload ID="fpFile" runat="server" CssClass="txtBox" Width="250px"  />
                    &nbsp;<asp:RequiredFieldValidator ID="reqFile" runat="server" ControlToValidate="fpFile" Display="None" 
                    ErrorMessage="Please select the file" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cstFile" runat="Server" ControlToValidate="fpFile" ErrorMessage="Invalid Attachment Type"
                            Display="None" ClientValidationFunction="ValidateAttachmentType" ValidationGroup="vsErrorGroup"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <%--<td colspan="2">&nbsp;
                </td>--%>
                <td align="center" colspan="3">
                    <asp:Button ID="btnReplace" runat="server" Text="Replace" CausesValidation="true" ValidationGroup="vsErrorGroup" OnClick="btnReplace_Click" /> 
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">
    function ValidateAttachmentType(obj,args)
    {
        var strType = '<%=Request.QueryString["type"]%>';    
        if(strType == 'Image')
        {         
            var arrExt = args.Value.split(".");        
            if(arrExt.length>0)
            {
                switch(arrExt[arrExt.length-1].toLowerCase())
                {
                    case 'jpg':
                    case 'gif':                
                    case 'bmp':
                    case 'jpeg':
                    case 'tif':
                    case 'png':                    
                        args.IsValid = true;
                        break;
                    default:
                        args.IsValid = false;                    
                }
            }    
            else
            {
                args.IsValid = false;
            }    
                    
        }
        else
        {
            args.IsValid = true;
        }   
        
     }
    </script>
    </form>
</body>
</html>
