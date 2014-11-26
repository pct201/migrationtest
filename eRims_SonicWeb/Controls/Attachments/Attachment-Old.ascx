<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Attachment-Old.ascx.cs" Inherits="Controls_Attachments_Attachment_Old" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>

<script language="javascript" type="text/javascript">
//used to Upload file. from this funciton click event of btnHdn is fired.
function UpdloadFile()
{
    var fu = document.getElementById('<%=fpFile.ClientID %>');
    //check fileupload control have a value and validate page by Related Validation group
    if(fu.value != "" && Page_ClientValidate("AddAttachment"))
    {
        __doPostBack('<%=btnHdn.UniqueID %>','OnClick');
    }
    else
    {
        fu.outerHTML='<INPUT class=txtBox id=ctl00_ContentPlaceHolder1_CtrlAttachment_fpFile type=file value="" name=ctl00$ContentPlaceHolder1$CtrlAttachment$fpFile  onChange="UpdloadFile();">';
    }
}
//Used to Validate Attchment Type
function ValidateAttachmentType(obj,args)
{
    var drpType = document.getElementById('<%=drpAttachType.ClientID%>');    
    //check attchment type selected from dropdown
    if(drpType.options[drpType.selectedIndex].text == 'Image')
    { 
        var arrPath = args.Value.split("\\");
        var arrExt = arrPath[arrPath.length-1].split(".");        
        //check Length of Extension
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
 
//used to Expand Attchement Description Textbox
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

<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td class="Spacer" style="height: 20px;">
            <asp:Button runat="server" ID="btnHdn" Visible="false" OnClick="btnHdn_Click" />
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
                        <asp:DropDownList ID="drpAttachType" SkinID="Attachment" Width="170px" runat="server">
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
                        <uc:ctrlMultiLineTextBox ID="txtAttachDesc" runat="server" MaxLength="40" />                        
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Attachment File Name</td>
                    <td align="center">
                        :</td>
                    <td align="left">
                        <asp:FileUpload ID="fpFile" runat="server" CssClass="txtBox" onChange="UpdloadFile();" />
                        &nbsp;<asp:RequiredFieldValidator ID="reqFile" runat="server" ControlToValidate="fpFile"
                            Display="None" ErrorMessage="Please select the file" ValidationGroup="AddAttachment"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cstFile" runat="Server" ControlToValidate="fpFile" ErrorMessage="Invalid Attachment Type"
                            Display="None" ValidationGroup="AddAttachment" ClientValidationFunction="ValidateAttachmentType"></asp:CustomValidator>
                    </td>                   
                </tr>
            </table>
        </td>
    </tr>
</table>
