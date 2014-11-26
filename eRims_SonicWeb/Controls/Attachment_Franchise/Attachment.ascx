<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Attachment.ascx.cs" Inherits="Ctrl_Franchise_Attachment" %>
<script language="javascript" type="text/javascript">
//used to Upload file. from this funciton click event of btnHdn is fired.
function UpdloadFile(fileUploadID,btnHiddenID,txtTypeID)
{
    var fu = document.getElementById(fileUploadID);    
    if(document.getElementById(txtTypeID).value == '')
    {
        alert('Please Enter the Attachment File Type');        
        fu.value='';
    }
    else
    {
        //check fileupload control have a value and validate page by Related Validation group
        if(fu.value != "" ) //&& Page_ClientValidate("AddAttachment")
        {
            __doPostBack(document.getElementById(btnHiddenID).name,'');
        }
    }
}
//Used to Validate Attchment Type
function ValidateAttachmentType(obj,args)
{
    var drpType = document.getElementById('drpAttachType.ClientID');    
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
 
</script>
<div class="bandHeaderRow">Attachments</div>
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td>
            <asp:UpdatePanel ID="pnl1" runat="server" UpdateMode="conditional">
                <ContentTemplate>
            <table cellpadding="3" cellspacing="1" width="100%">
                <tr>
                    <td width="18%" align="left">
                        Attachment Type&nbsp;<span style="color:Red">*</span></td>
                    <td width="4%" align="center">
                        :</td>
                    <td align="left" runat="server" id="tdTypeTextBox" >
                        <asp:TextBox runat="server" ID="txtType" Width="170px" MaxLength="50"></asp:TextBox>
                    </td>                    
                </tr>
                <tr>
                    <td align="left">
                        Attachment File Name</td>
                    <td align="center">
                        :</td>
                    <td align="left">
                        <asp:FileUpload ID="fpFile" runat="server" onChange="UpdloadFile();" />                        
                        <asp:Button runat="server" ID="btnHdn" style="display:none;" OnClick="btnHdn_Click" CausesValidation="false" />
                    </td>                   
                </tr>                
            </table>
            </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnHdn" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
    </tr>
    
</table>
