<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DealershipDBA_Pupup.aspx.cs"
    Inherits="SONIC_RealEstate_DealershipDBA_Pupup" Title="Dealeship DBA Search" %>

<%@ Register Src="~/Controls/RealEstateTab/RealEstate.ascx" TagName="RealEstateTab"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/RealEstateInfo/RealEstateInfo.ascx" TagName="RealEstateInfo"
    TagPrefix="uc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            width: 66%;
        }
    </style>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>

    <script language="javascript" type="text/javascript">
     function AuditPopUp()
     {
          var winHeight = window.screen.availHeight - 380;
            var winWidth = window.screen.availWidth - 390;

        
        var Lu_Location_ID=document.getElementById("hdLocationID").value;  
        obj= window.open("../RealEstate/AuditPopup_Lu_Location.aspx?id="+ Lu_Location_ID,'AuditPopUp','width=' + winWidth +',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');        
        obj.focus();
        return false;
     }    
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <div>
        <table width="100%" cellpadding="2" cellspacing="1" border="0">
            <tr>
                <td align="left" class="ghc" colspan="2">
                    <asp:Label ID="lblHeader" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="left">
                    <asp:Panel ID="pnlEdit" runat="server">
                        <table width="100%" cellpadding="2" cellspacing="1" border="0">
                            <tr>
                                <td colspan="6">
                                    &nbsp;<asp:HiddenField ID="hdLocationID" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="18%" style="padding-left: 5px;">
                                    DBA <span style="color: Red">*</span>
                                </td>
                                <td align="center" width="2%">
                                    :
                                </td>
                                <td align="left" width="30%">
                                    <asp:TextBox ID="txtDba" runat="server" Width="170px" MaxLength="50" />
                                    <asp:RequiredFieldValidator ID="rfvDba" runat="server" ErrorMessage="Please Enter DBA"
                                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="txtDba"
                                        Display="None"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left" width="18%">
                                    Legal Entity <span style="color: Red">*</span>
                                </td>
                                <td align="center" width="2%">
                                    :
                                </td>
                                <td align="left" width="30%">
                                    <asp:TextBox ID="txtLegalEntity" runat="server" Width="170px" MaxLength="50" />
                                    <asp:RequiredFieldValidator ID="rfvLegalEntity" runat="server" ErrorMessage="Please Enter Legal Entity"
                                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="txtLegalEntity"
                                        Display="None"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-left: 5px;">
                                    Address 1 <span style="color: Red">*</span>
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtAddress1" runat="server" Width="170px" MaxLength="50" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Address1"
                                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="txtAddress1"
                                        Display="None"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left">
                                    Address 2
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtAddress2" runat="server" Width="170px" MaxLength="50" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-left: 5px;">
                                    City <span style="color: Red">*</span>
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCity" runat="server" Width="170px" MaxLength="50" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter City"
                                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="txtCity"
                                        Display="None"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left">
                                    State<span style="color: Red">*</span>
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="drpState" Width="150px" runat="server" OnSelectedIndexChanged="drpState_SelectedIndexChanged"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select State"
                                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="drpState"
                                        InitialValue="0" Display="None"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-left: 5px;">
                                    Zip Code(XXXXX-XXXX) <span style="color: Red">*</span>
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtZipCode" runat="server" Width="170px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" SetFocusOnError="true" runat="server"
                                        ErrorMessage="Please Enter Zip Code" ValidationGroup="vsErrorGroup" ControlToValidate="txtZipCode"
                                        Display="None"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revZipCode" runat="server" ErrorMessage="Zip Code is not valid"
                                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="txtZipCode"
                                        ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b" Display="none" />
                                </td>
                                <td align="left">
                                    County
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="drpCounty" Width="150px" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-left: 5px;">
                                    Dealership Telephone (XXX-XXX-XXXX)
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtTelePhone" runat="server" Width="170px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                    <asp:RegularExpressionValidator ID="revWorkTel" runat="server" ControlToValidate="txtTelePhone"
                                        ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" ErrorMessage="Please Enter Dealership Telephone in xxx-xxx-xxxx format."
                                        SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none"></asp:RegularExpressionValidator>
                                </td>
                                <td align="left">
                                    Year of Acquisition
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtYearofAquisition" runat="server" Width="170px" MaxLength="50" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-left: 5px;">
                                    Web Site Address
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtWebSite" runat="server" Width="170px" MaxLength="255" />
                                    <asp:RegularExpressionValidator ID="regWebSite" runat="server" Display="none" Enabled="true"
                                        ValidationExpression="(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?|(http(s)?://)([\w-]+\.)*[\w-]+(/[\w- ./?%&=]*)?"
                                        ControlToValidate="txtWebSite" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                        ErrorMessage="Web site URL is not valid" />
                                </td>
                                <td align="left">
                                    RM Location Number<span style="color: Red">*</span>
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtRIMNumber" runat="server" Width="170px" MaxLength="50" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter RMI Location Number"
                                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="txtRIMNumber"
                                        Display="None"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-left: 5px;">
                                    Region<span style="color: Red">*</span>
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">                                 
                                    <asp:DropDownList ID="drpRegion" Width="150px" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Enter Region"
                                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" InitialValue="0"  ControlToValidate="drpRegion"
                                        Display="None"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left">
                                    ADP DMS <span style="color: Red">*</span>
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtAdpDms" runat="server" Width="170px" MaxLength="10" onpaste="return false"
                                        onkeypress="return FormatNumber(event,this.id,10,false);" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Enter ADP DMS"
                                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="txtAdpDms"
                                        Display="None"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-left: 5px;">
                                    Location Description
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtLocationDesc" runat="server" Width="170px" MaxLength="50" />
                                </td>
                                <td align="left">
                                    Sonic Location Code<span style="color: Red">*</span>
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtSonicLocationCode" runat="server" Width="170px" MaxLength="4"
                                        onKeyPress="return FormatInteger(event);" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please Enter Sonic Location Code"
                                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="txtSonicLocationCode"
                                        Display="None"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-left: 5px;">RLCM<span style="color: Red">*</span></td>
                                <td align="center">:</td>
                                <td align="left">
                                    <asp:DropDownList ID="drpRLCM" runat="server" Width="170px" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please select RLCM Employee"
                                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="drpRLCM" InitialValue="0"
                                        Display="None"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left">
                                    Show On Dashboard
                                </td>
                                <td align="center">:</td>
                                <td align="left">
                                    <asp:RadioButtonList ID="rdoShowOnDashboard" runat="server" SkinID="YesNoType"></asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-left: 5px;">
                                    Active
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:RadioButtonList ID="rdbActive" runat="server" SkinID="YesNoType">
                                    </asp:RadioButtonList>
                                </td>
                                <td colspan="3">&nbsp;</td>
                            </tr>
                            <tr>
                                <td valign="top" align="center" colspan="6">
                                    <asp:Button ID="btnSave" Text=" Save " CausesValidation="true" ValidationGroup="vsErrorGroup"
                                        runat="server" OnClick="btnSave_Click" />
                                    &nbsp;&nbsp;
                                    <asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClientClick="javascript:parent.parent.GB_hide();" />
                                    &nbsp;&nbsp;
                                    <asp:Button ID="btnViewAudit" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="pnlView" runat="server" Visible="false">
                        <table width="100%" cellpadding="4" cellspacing="1" border="0">
                            <tr>
                                <td colspan="6">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="18%" style="padding-left: 5px;">
                                    DBA <span style="color: Red">*</span>
                                </td>
                                <td align="center" width="2%">
                                    :
                                </td>
                                <td align="left" width="30%">
                                    <asp:Label ID="lblDBA" runat="server" Text=""></asp:Label>
                                </td>
                                <td align="left" width="18%">
                                    Legal Entity <span style="color: Red">*</span>
                                </td>
                                <td align="center" width="2%">
                                    :
                                </td>
                                <td align="left" width="30%">
                                    <asp:Label ID="lblLegalEntity" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-left: 5px;">
                                    Address 1 <span style="color: Red">*</span>
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblAddress1" runat="server" Text=""></asp:Label>
                                </td>
                                <td align="left">
                                    Address 2
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblAddress2" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-left: 5px;">
                                    City <span style="color: Red">*</span>
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblCity" runat="server" Text=""></asp:Label>
                                </td>
                                <td align="left">
                                    State<span style="color: Red">*</span>
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblState" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-left: 5px;">
                                    Zip Code(XXXXX-XXXX) <span style="color: Red">*</span>
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblZipCode" runat="server" Text=""></asp:Label>
                                </td>
                                <td align="left">
                                    County
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblCounty" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-left: 5px;">
                                    Dealership Telephone (XXX-XXX-XXXX)
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblTelephone" runat="server" Text=""></asp:Label>
                                </td>
                                <td align="left">
                                    Year of Acquisition
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblYear" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-left: 5px;">
                                    Web Site Address
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblWebsite" runat="server" Text=""></asp:Label>
                                </td>
                                <td align="left">
                                    RMI Location Number<span style="color: Red">*</span>
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblRIMNumber" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-left: 5px;">
                                    Region<span style="color: Red">*</span>
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblRegion" runat="server" Text=""></asp:Label>
                                </td>
                                <td align="left">
                                    ADP DMS <span style="color: Red">*</span>
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblADPDMS" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-left: 5px;">
                                    Location Description
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblLocationDescription" runat="server" Text=""></asp:Label>
                                </td>
                                <td align="left">
                                    Sonic Location Code<span style="color: Red">*</span>
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblSonicCode" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-left: 5px;">
                                    RLCM
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblRLCM" runat="server" Text=""></asp:Label>
                                </td>
                                <td align="left">
                                    Show On Dashboard
                                </td>
                                <td align="center">:</td>
                                <td align="left">
                                    <asp:Label ID="lblShowOnDashboard" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" align="center" colspan="6">
                                    <asp:Button ID="btnCancelView" Text="Cancel" runat="server" OnClientClick="javascript:parent.parent.GB_hide();" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-left: 5px;">
                                    Active
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblActive" runat="server" Text=""></asp:Label>
                                </td>
                                <td colspan="3">&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    </form>

    <script type="text/javascript">
        function SetValues(PK)
        {
            var hdnID = '<%=Request.QueryString["hdnID"]%>';
            var btnID = '<%=Request.QueryString["btnID"]%>';
            
            var wOpen = window.opener;
            wOpen.document.getElementById(hdnID).value = PK;
            wOpen.document.getElementById(btnID).click();
            window.close();
        }
    </script>

</body>
</html>
