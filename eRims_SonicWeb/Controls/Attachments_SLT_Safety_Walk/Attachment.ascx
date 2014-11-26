<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Attachment.ascx.cs" Inherits="Controls_Attachments_SLT_Safety_Walk_Attachment" %>

<script language="javascript" type="text/javascript">
    //used to Upload file. from this funciton click event of btnHdn is fired.
    function UpdloadFile(fileUploadID, btnHiddenID, txtTypeID) {
        var fu = document.getElementById(fileUploadID);
        if (document.getElementById(txtTypeID).value == '') {
            alert('Please Enter the Attachment Description');
            fu.value = '';
            document.getElementById(txtTypeID).focus();
        }
        else {
            //check fileupload control have a value and validate page by Related Validation group
            if (fu.value != "") //&& Page_ClientValidate("AddAttachment")
            {
                __doPostBack(document.getElementById(btnHiddenID).name, '');
            }
           
        }
    }
  
    function UpdloadFile_txt(fileUploadID, btnHiddenID, txtTypeID) {
        var fu = document.getElementById(fileUploadID);
        if (fu.value != "" && document.getElementById(txtTypeID).value == '') {
            alert('Please Enter the Attachment Description');
            
        }
        else {
            //check fileupload control have a value and validate page by Related Validation group
            if (fu.value != "") //&& Page_ClientValidate("AddAttachment")
            {
                __doPostBack(document.getElementById(btnHiddenID).name, '');
            }
          
        }
    }
</script>
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td>
            <asp:UpdatePanel ID="pnl1" runat="server" UpdateMode="conditional">
                <ContentTemplate>
                    <table cellpadding="3" cellspacing="1" width="100%">
                        <tr>
                            <td width="28%" align="left">Attachment Description</td>
                            <td width="4%" align="center">:</td>
                            <td align="left" runat="server" id="tdTypeTextBox">
                                <asp:TextBox runat="server" ID="txtType" TextMode="MultiLine" Rows="5" Columns="68" MaxLength="2000" onblur="UpdloadFile_txt();"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="28%" align="left">Attachment File Name</td>
                            <td width="4%" align="center">:</td>
                            <td align="left">
                                <asp:FileUpload ID="fpFile" runat="server" CssClass="txtBox" onChange="UpdloadFile();" />
                                &nbsp;<asp:RequiredFieldValidator ID="reqFile" runat="server" ControlToValidate="fpFile"
                                    Display="None" ErrorMessage="Please select the file" ValidationGroup="AddAttachment"></asp:RequiredFieldValidator>
                                <asp:Button runat="server" ID="btnHdn" Style="display: none;" OnClick="btnHdn_Click" CausesValidation="false" />
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
