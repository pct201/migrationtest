<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PropertyContactDetails.aspx.cs"
    Inherits="SONIC_Exposures_PropertyContactDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript">
        function CloseWindow() {            
            parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_btnUpdateContactGrids').click();
            parent.parent.GB_hide();
        }
        
        function CheckContactType(strVal,tr,valOtherType)
        {
            document.getElementById(tr).style.display = (strVal =='Other Contact') ? 'block' : 'none';
            
            ValidatorEnable(document.getElementById(valOtherType), strVal =='Other Contact' ? true : false);
        }

        function ValidateFieldsContact(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('hdnControlIDsContact').value.split(',');
            var Messages = document.getElementById('hdnErrorMsgsContact').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('hdnControlIDsContact').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text":
                            if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
                    //sender.errormessage = msg;
                    sender.errormessage = msg;
                    args.IsValid = false;
                }
                else
                    args.IsValid = true;
            }
            else {
                args.IsValid = true;
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ValidationSummary ID="valContact" runat="server" ValidationGroup="vsErrorContact" ShowMessageBox="true" ShowSummary="false"
    HeaderText="Verify the following fields" BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />

        <asp:ScriptManager ID="scriptmanager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <div>
            <table cellpadding="4" cellspacing="2" width="100%">
                <tr>
                    <td width="100%" class="Spacer" style="height: 30px;" colspan="4">
                    </td>
                </tr>
                <tr>
                    <td width="10px">
                        &nbsp;</td>
                    <td align="left">
                        <div id="dvEdit" runat="server" style="display: none;">
                            <asp:UpdatePanel ID="pnlUpdateInfo" runat="server">
                                <ContentTemplate>                                
                            <table cellpadding="4" cellspacing="2" width="100%">
                                <tr>
                                    <td width="30%" align="left">
                                        Type&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                    </td>
                                    <td width="4%" align="center">
                                        :</td>
                                    <td align="left">
                                        <asp:DropDownList ID="drpType" runat="server" SkinID="default" Width="170px">
                                            <asp:ListItem Text="--Select--" />
                                            <asp:ListItem Text="Local Police" />
                                            <asp:ListItem Text="Fire Department" />
                                            <asp:ListItem Text="County Sherriff" />
                                            <asp:ListItem Text="State Police" />
                                            <asp:ListItem Text="Local Hospital" />
                                            <asp:ListItem Text="Ambulance" />
                                            <asp:ListItem Text="HazMat" />
                                            <asp:ListItem Text="Other" />
                                            <asp:ListItem Text="Power" />
                                            <asp:ListItem Text="Water" />
                                            <asp:ListItem Text="Gas" />
                                            <asp:ListItem Text="Cleaning" />
                                            <asp:ListItem Text="Connectivity/Internet" />
                                            <asp:ListItem Text="Other Contact" />
                                        </asp:DropDownList>                                       
                                    </td>
                                </tr>
                                <tr id="trOtherContactType" runat="server" style="display: none;">
                                    <td width="30%" align="left">
                                        Type Name&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span></td>
                                    <td width="4%" align="center">
                                        :</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtType" runat="server" Width="170px"  MaxLength="50"/>
                                        <asp:RequiredFieldValidator ID="revOtherType" runat="server" ControlToValidate="txtType" Enabled="false"
                                        ValidationGroup="vsErrorContact" ErrorMessage="Please Enter Other Contact Type" Display="None" SetFocusOnError="true"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Organization&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span></td>
                                    <td align="center">
                                        :</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtOrganization" runat="server" Width="170px"  MaxLength="50"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Contact Name&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span></td>
                                    <td align="center">
                                        :</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtContactName" runat="server" Width="170px"  MaxLength="50"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Phone&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span></td>
                                    <td align="center">
                                        :</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtPhone" runat="server" Width="170px"  MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);"/>
                                        <asp:RegularExpressionValidator ID="regPhone" ControlToValidate="txtPhone" SetFocusOnError="true"
                                            runat="server" ValidationGroup="vsErrorContact" ErrorMessage="Please Enter Phone in xxx-xxx-xxxx format."
                                            Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Email&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span></td>
                                    <td align="center">
                                        :</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtEmail" runat="server" Width="170px"  MaxLength="50"/>
                                        <asp:RegularExpressionValidator ID="regEmail" runat="server" ErrorMessage="Invalid Email Address" ControlToValidate="txtEmail" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="none" SetFocusOnError="true" ValidationGroup="vsErrorContact"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorContact"
                                            OnClick="btnSave_Click" />
                                    </td>
                                </tr>
                            </table>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div id="dvView" runat="server" style="display:none">
                        <table cellpadding="4" cellspacing="2" width="100%">
                                <tr>
                                    <td width="30%" align="left">
                                        Type
                                    </td>
                                    <td width="4%" align="center">
                                        :</td>
                                    <td align="left">
                                        <asp:Label ID="lblType" runat="server" ></asp:Label>                                        
                                    </td>
                                </tr>                                
                                <tr>
                                    <td align="left">
                                        Organization</td>
                                    <td align="center">
                                        :</td>
                                    <td align="left">
                                        <asp:Label ID="lblOrganization" runat="server"   />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Contact Name</td>
                                    <td align="center">
                                        :</td>
                                    <td align="left">
                                        <asp:Label ID="lblContactName" runat="server"   />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Phone</td>
                                    <td align="center">
                                        :</td>
                                    <td align="left">
                                        <asp:Label ID="lblPhone" runat="server"   />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Email</td>
                                    <td align="center">
                                        :</td>
                                    <td align="left">
                                        <asp:Label ID="lblEmail" runat="server"   />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:Button ID="btnClose" runat="server" Text="Close" OnClientClick="parent.parent.GB_hide();return false;" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>                
            </table>
        </div>
             <asp:CustomValidator ID="CustomValidatorContact" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsContact"
        Display="None" ValidationGroup="vsErrorContact" />
    <input id="hdnControlIDsContact" runat="server" type="hidden" />
    <input id="hdnErrorMsgsContact" runat="server" type="hidden" />
    </form>  
</body>
</html>
