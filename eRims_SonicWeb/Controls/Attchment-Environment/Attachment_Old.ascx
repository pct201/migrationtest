<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Attachment_Old.ascx.cs"
    Inherits="Controls_Attchment_Environment_Attachment_Old" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script language="javascript" type="text/javascript" src="../../JavaScript/Validator.js"></script>

<script language="javascript" type="text/javascript">

   
// Function name is set dynamically as Per Validation group    
function UpdloadFile<%=UniqueControlID%>()
{
    var fu = document.getElementById('<%=fpFile.ClientID %>');
    
    //check fileupload control have a value and validate page by Related Validation group 
    if(trim(fu.value) != "" && Page_ClientValidate("<%=UniqueControlID%>"))
    {   
       
       // hidden button Server Postback
       document.getElementById('<%=btnHdn.UniqueID%>').click();
    }

}

// Function name is set dynamically as Per Validation group
function ValidateAttachmentType<%=UniqueControlID%>(obj,args)
{       
    var drpType = document.getElementById('<%=drpAttachType.ClientID%>');    
    
    //check attchment type selected from dropdown
    if(drpType.options[drpType.selectedIndex].text == 'Image')
    { 
        var arrPath = args.Value.split("\\");
        var arrExt = arrPath[arrPath.length-1].split(".");    
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

<div>
    <asp:ValidationSummary ID="valSummary" runat="server" ShowMessageBox="true" ShowSummary="false" />
    <asp:ValidationSummary ID="valSummaryFolder" runat="server" ShowMessageBox="true"
        ShowSummary="false" />
</div>
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td class="Spacer" style="height: 5px;">
            <asp:Button runat="server" ID="btnHdn" OnClick="btnHdn_Click" Style="display: none;" />
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="3" cellspacing="1" width="100%">
                <tr>
                    <td style="width: 18%" align="left">
                        Attachment Type
                    </td>
                    <td style="width: 4%" align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="drpAttachType" SkinID="Attachment" Width="170px" runat="server">
                        </asp:DropDownList>
                        &nbsp;<asp:RequiredFieldValidator ID="reqAttachType" runat="server" ControlToValidate="drpAttachType"
                            Display="None" ErrorMessage="Please select the attachment type" InitialValue="0"
                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 18%" align="left">
                        Folder
                    </td>
                    <td style="width: 4%" align="center">
                        :
                    </td>
                    <td align="left" width="250px">
                        <table>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="updFolderName" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="drpFolderName" runat="server" EnableTheming="false" Width="170px">
                                            </asp:DropDownList>
                                            &nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvFolder" runat="server" ControlToValidate="drpFolderName"
                                                Display="None" ErrorMessage="Please Select the Folder Name." InitialValue="0"
                                                SetFocusOnError="true">
                                            </asp:RequiredFieldValidator>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnSaveFolder" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lbtAddFolder" runat="server" Text="Add New"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        Attachment Description
                    </td>
                    <td align="center" valign="top">
                        :
                    </td>
                    <td align="left" valign="top">
                        <uc:ctrlMultiLineTextBox ID="txtAttachDesc" runat="server" MaxLength="4000" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Attachment Filename
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="fpFile" runat="server" CssClass="txtBox" onChange="UpdloadFile();" />
                        &nbsp;<asp:RequiredFieldValidator ID="reqFile" runat="server" ControlToValidate="drpAttachType"
                            SetFocusOnError="true" Display="None" ErrorMessage="Please select the file"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cstFile" runat="Server" ErrorMessage="Invalid Attachment Type"
                            ControlToValidate="fpFile" Display="None" SetFocusOnError="true"></asp:CustomValidator>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:ModalPopupExtender ID="mpeFolder" runat="server" TargetControlID="lbtAddFolder"
                BackgroundCssClass="modalBackground" PopupControlID="pnlAddFolder" CancelControlID="bntCancel">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlAddFolder" runat="server" Style="display: none;" CssClass="modalPopup">
                <asp:UpdatePanel ID="updAddFolder" runat="server" UpdateMode="Conditional" RenderMode="Block">
                    <ContentTemplate>
                        <table>
                            <tr align="center">
                                <td colspan="2">
                                    Add New Folder
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Folder Name<span class="mf">*</span> :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFolderName" runat="server" MaxLength="50">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvFolderName" runat="server" ControlToValidate="txtFolderName"
                                        SetFocusOnError="true" ErrorMessage="Folder Name must not be empty." Display="none">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSaveFolder" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnSaveFolder" runat="server" OnClick="btnSaveFolder_Click" Text="Save" />
                        </td>
                        <td>
                            <asp:Button ID="bntCancel" runat="server" Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
