<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Attachment_COI.ascx.cs" Inherits="Attachment_COI" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<script language="javascript" type="text/javascript">

function ValidateAttachmentType(obj,args)
{
    var drpType = document.getElementById('<%=drpAttachType.ClientID%>');    
    if(drpType.options[drpType.selectedIndex].text == 'Image')
    { 
        
        var arrExt = args.Value.split(".");        
        if(arrExt.length>0)
        {
            switch(arrExt[1].toLowerCase())
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
 
 
function ExpandAttachDesc(bExpand)
{
    if(bExpand)
    {
        document.getElementById('<%=txtAttachDesc.ClientID%>').style.display = "block";
        document.getElementById('imgMinus').style.display = "block";
        document.getElementById('imgPlus').style.display = "none";
    }
    else
    {
        document.getElementById('<%=txtAttachDesc.ClientID%>').style.display = "none";
        document.getElementById('imgMinus').style.display = "none";
        document.getElementById('imgPlus').style.display = "block";
    }
}
</script>
  <asp:ValidationSummary ID="valSummayAttachment" runat="server" ShowMessageBox="true"
        ValidationGroup="AddAttachment" ShowSummary="false" HeaderText="Verify the following field(s):" />
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr class="bandHeaderRow">
        <td>
            Attachment</td>
    </tr>
    <tr>
        <td class="Spacer" style="height: 20px;">
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="3" cellspacing="1" width="100%">
                <tr>
                    <td width="18%" align="left">
                        Attachment Type</td>
                    <td width="4%" align="center">
                        :</td>
                    <td align="left">
                        <asp:DropDownList ID="drpAttachType" SkinID="Attachment" Width="170px" runat="server" TabIndex="1">
                        </asp:DropDownList>
                        &nbsp;<asp:RequiredFieldValidator ID="reqAttachType" runat="server" ControlToValidate="drpAttachType"
                            Display="None" ErrorMessage="Please select the attachment type" ValidationGroup="AddAttachment"
                            InitialValue="0"></asp:RequiredFieldValidator>
                    </td>                    
                </tr>
                <tr>
                    <td align="left" valign="top">
                        Attachment Description</td>
                    <td align="center" valign="top">
                        :</td>
                    <td align="left" valign="top">
                        <uc:ctrlMultiLineTextBox ID="txtAttachDesc" runat="server" MaxLength="4000" TabIndex="2" />                        
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Attachment Filename</td>
                    <td align="center">
                        :</td>
                    <td align="left">
                        <asp:FileUpload ID="fpFile" runat="server" TabIndex="3" />
                        &nbsp;<asp:RequiredFieldValidator ID="reqFile" runat="server" ControlToValidate="fpFile"
                            Display="None" ErrorMessage="Please select the file" ValidationGroup="AddAttachment"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cstFile" runat="Server" ControlToValidate="fpFile" ErrorMessage="Invalid Attachment Type"
                            Display="None" ValidationGroup="AddAttachment" ClientValidationFunction="ValidateAttachmentType"></asp:CustomValidator>
                    </td>                   
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" CausesValidation="true"
                              OnClientClick="return Page_ClientValidate('AddAttachment')"  OnClick="btnAddAttachment_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>