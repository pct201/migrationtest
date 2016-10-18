<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DealershipDBA_Pupup.aspx.cs"
    Inherits="SONIC_RealEstate_DealershipDBA_Pupup" Title="Dealeship DBA Search" %>

<%@ Register Src="~/Controls/RealEstateTab/RealEstate.ascx" TagName="RealEstateTab"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/RealEstateInfo/RealEstateInfo.ascx" TagName="RealEstateInfo"
    TagPrefix="uc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            width: 66%;
        }
    </style>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
    <script type="text/javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script language="javascript" type="text/javascript">

     function CheckValidation() {

            if (Page_ClientValidate("vsErrorGrid")) {
            }
     }
        
     function scrolldown()
     {
         $("html, body").animate({ scrollTop: $(document).height() }, "slow");
     };
   
     function AuditPopUp()
     {
          var winHeight = window.screen.availHeight - 380;
            var winWidth = window.screen.availWidth - 390;

        
        var Lu_Location_ID=document.getElementById("hdLocationID").value;  
        obj= window.open("../RealEstate/AuditPopup_Lu_Location.aspx?id="+ Lu_Location_ID,'AuditPopUp','width=' + winWidth +',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');        
        obj.focus();
        return false;
     }

     function PayrollPopUp() {
         var winHeight = window.screen.availHeight - 480;
         var winWidth = window.screen.availWidth - 890;

         var Lu_Location_ID = document.getElementById("hdLocationID").value;
         obj = window.open("../RealEstate/PayrollCodesPopup.aspx?id=" + Lu_Location_ID, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
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
    <div runat="server" id="dvLocation">
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
                               <%-- <td align="left" width="18%">
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
                                </td>--%>
                            </tr> 
                             <tr>
                                <td align="left" style="padding-left: 5px;">
                                    Parent Company Legal Entity 
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtParentCompanyLegalEntity" runat="server" Width="170px" MaxLength="75"/>
                                </td>
                                <td align="left">
                                    Parent Company Legal Entity FEIN
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtParentCompanyLegalEntityFEIN" runat="server" Width="170px" MaxLength="50"/>
                                </td>
                            </tr>
                             <tr>
                                <td align="left" style="padding-left: 5px;">
                                   Legal Entity (Operations)
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtLegalEntityOperations" runat="server" Width="170px" MaxLength="75"/>
                                </td>
                                <td align="left">
                                    Legal Entity (Operations) FEIN
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtLegalEntityOperationsFEIN" runat="server" Width="170px" MaxLength="50"/>
                                </td>
                            </tr>
                             <tr>
                                <td align="left" style="padding-left: 5px;">
                                   Legal Entity (Properties)
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtLegalEntityProperties" runat="server" Width="170px" MaxLength="75"/>
                                </td>
                                <td align="left">
                                    Legal Entity (Properties) FEIN
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtLegalEntityPropertiesFEIN" runat="server" Width="170px" MaxLength="50"/>
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
                                <%--<td align="left">
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
                                </td>--%>
                                <td align="left">
                                    Payroll Codes <span style="color: Red">*</span>
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:ListBox ID="lstPayrollCodes" runat="server" Width="170px" SelectionMode="Multiple"></asp:ListBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please select Payroll code"
                                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="lstPayrollCodes"
                                        Display="None"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-left: 5px;">
                                    Market<span style="color: Red">*</span>
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">                                 
                                    <asp:DropDownList ID="drpLU_Market" Width="150px" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please Enter Market"
                                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" InitialValue="0"  ControlToValidate="drpLU_Market"
                                        Display="None"></asp:RequiredFieldValidator>
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
                                    Show On Dashboard
                                </td>
                                <td align="center">:</td>
                                <td align="left">
                                    <asp:RadioButtonList ID="rdoShowOnDashboard" runat="server" SkinID="YesNoType"></asp:RadioButtonList>
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
                                <td colspan="3">
                                    &nbsp;
                                </td>
                                <td align="left" style="padding-left: 5px;">
                                    Activation Date
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                     <asp:TextBox ID="txtActivation_Date" runat="server" Width="150px" SkinID="txtDate" />
                                     <img alt="Activation Date" onclick="scrolldown(); return showCalendar('txtActivation_Date', 'mm/dd/y'); "
                                     onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                     align="middle"/>
                                     <asp:RegularExpressionValidator ID="revActivation_Date" runat="server" ValidationGroup="vsErrorGroup"
                                     Display="none" ErrorMessage="Activation Date is not a valid date"
                                     SetFocusOnError="true" ControlToValidate="txtActivation_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" align="center" colspan="6">
                                    <asp:Button ID="btnSave" Text=" Save " CausesValidation="true" ValidationGroup="vsErrorGroup"
                                        runat="server" OnClick="btnSave_Click" />
                                    &nbsp;&nbsp;
                                    <asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClientClick="javascript:parent.parent.GB_hide();" />
                                    &nbsp;&nbsp;
                                    <asp:Button ID="btnViewAudit" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />
                                     &nbsp;&nbsp;
                                    <asp:Button ID="btnManage" runat="server" Text="Manage Location Codes" OnClick="btnManage_Click" />
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
                                <%--<td align="left" width="18%">
                                    Legal Entity <span style="color: Red">*</span>
                                </td>
                                <td align="center" width="2%">
                                    :
                                </td>
                                <td align="left" width="30%">
                                    <asp:Label ID="lblLegalEntity" runat="server" Text=""></asp:Label>
                                </td>--%>
                            </tr>
                            <tr>
                                <td align="left" width="18%" style="padding-left: 5px;">
                                   Parent Company Legal Entity 
                                </td>
                                <td align="center" width="2%">
                                    :
                                </td>
                                <td align="left" width="30%">
                                    <asp:Label ID="lblParentCompanyLegalEntity" runat="server" Style="word-wrap: normal; word-break: break-all"  Width="170px"></asp:Label>
                                </td>
                                <td align="left" width="18%">
                                    Parent Company Legal Entity FEIN 
                                </td>
                                <td align="center" width="2%">
                                    :
                                </td>
                                <td align="left" width="30%">
                                    <asp:Label ID="lblParentCompanyLegalEntityFEIN" runat="server"  Style="word-wrap: normal; word-break: break-all"  Width="170px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="18%" style="padding-left: 5px;">
                                   Legal Entity (Operations) 
                                </td>
                                <td align="center" width="2%">
                                    :
                                </td>
                                <td align="left" width="30%">
                                    <asp:Label ID="lblLegalEntityOperations" runat="server"  Style="word-wrap: normal; word-break: break-all"  Width="170px"></asp:Label>
                                </td>
                                <td align="left" width="18%">
                                    Legal Entity (Operations) FEIN 
                                </td>
                                <td align="center" width="2%">
                                    :
                                </td>
                                <td align="left" width="30%">
                                    <asp:Label ID="lblLegalEntityOperationsFEIN" runat="server"  Style="word-wrap: normal; word-break: break-all"  Width="170px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="18%" style="padding-left: 5px;">
                                   Legal Entity (Properties) 
                                </td>
                                <td align="center" width="2%">
                                    :
                                </td>
                                <td align="left" width="30%">
                                    <asp:Label ID="lblLegalEntityProperties" runat="server" Style="word-wrap: normal; word-break: break-all"  Width="170px"></asp:Label>
                                </td>
                                <td align="left" width="18%">
                                    Legal Entity (Properties) FEIN 
                                </td>
                                <td align="center" width="2%">
                                    :
                                </td>
                                <td align="left" width="30%">
                                    <asp:Label ID="lblLegalEntityPropertiesFEIN" runat="server" Style="word-wrap: normal; word-break: break-all"  Width="170px"></asp:Label>
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
                                    Market<span style="color: Red">*</span>
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblLU_Market" runat="server" Text=""></asp:Label>
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
                                    Location Description
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblLocationDescription" runat="server" Text=""></asp:Label>
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
                                    RLCM
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblRLCM" runat="server" Text=""></asp:Label>
                                </td>
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
                            <tr>
                                <td colspan="3">&nbsp;</td>
                                <td>Activation Date</td>
                                <td>:</td>
                                <td><asp:Label ID="lblActivation_Date" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    <div runat="server" id="dvPayroll">
        <table width="100%" cellpadding="2" cellspacing="1" border="0">
            <tr>
                <td align="left">
                    <div>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false" ShowMessageBox="true"
                        HeaderText="Verify the following fields :" BorderWidth="1" BorderColor="DimGray"
                        ValidationGroup="vsErrorGrid" CssClass="errormessage"></asp:ValidationSummary>
                     </div>
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
             <asp:UpdatePanel runat="server" ID="updStatus">
             <ContentTemplate>
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tbody>
                        <tr>
                            <td colspan="3">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="bandHeaderRow" align="left" colspan="3">Payroll Codes
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%">&nbsp;
                            </td>
                            <td align="center">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td align="left">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:GridView ID="gvPayrollCode" runat="server" Width="100%" AutoGenerateColumns="false"
                                                    PageSize="10" EnableViewState="true" AllowPaging="true" OnRowCommand="gvPayrollCode_RowCommand"
                                                    OnPageIndexChanging="gvPayrollCode_PageIndexChanging" >
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hdn" runat="server" Value='<%# Eval("PK_LU_Location_2_Organization_Id") %>' />
                                                                <asp:HiddenField ID="hdnPayrollCodes" runat="server" Value='<%# Eval("PK_PayrollCodes") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sonic Location Code" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <%#Eval("Sonic_Location_Code") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ADP DMS" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <%#Eval("ADP_DMS") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Organization Code" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <%#Eval("Organization_Code") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Organization Name" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle Width="40%" HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <%#Eval("Organization_Name") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" ID="lnkEdit" Text="Edit" CommandName="EditRecord" OnClientClick="scrolldown();"
                                                                    CommandArgument='<%#Eval("PK_PayrollCodes") %>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" ID="lnkDelete" Text="Delete" CommandName="DeleteRecord"
                                                                    CommandArgument='<%#Eval("PK_PayrollCodes") %>' OnClientClick="return confirm('Are you sure that you want to delete selected record(s)?');"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <table cellpadding="4" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                                    <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                            <td style="width: 20%;">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%" align="right">
                                &nbsp;
                            </td>
                            <td>
                                <div style=" float:left; display:inline;">
                                <asp:Button ID="btnBack"  runat="server" Text="Back" OnClick="btnBack_Click"/>
                                </div>
                                <div style="float:right;">
                                <asp:LinkButton Style="display: inline" ID="lnkAddNew" OnClick="lnkAddNew_Click"
                                    runat="server" Text="Add New" OnClientClick="scrolldown();"></asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton
                                        Style="display: none" ID="lnkCancel" OnClick="lnkCancel_Click" runat="server"
                                        Text="Cancel"></asp:LinkButton>
                                </div>
                            </td>
                            <td style="width: 20%">
                               &nbsp;
                            </td>
                        </tr>
                        <tr style="display: none" id="trStatusAdd" runat="server">
                            <td>&nbsp;
                            </td>
                            <td  align="center">
                                <table cellspacing="1" cellpadding="3" width="100%" border="0" align="center" style="margin-left:100px;">
                                    <tbody>
                                        <tr>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%" align="left">Sonic Location Code
                                            </td>
                                            <td style="width: 4%" align="center">:
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblSonicLocationCode" runat="server" MaxLength="50"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%" align="left">ADP DMS<span class="mf">*</span>
                                            </td>
                                            <td style="width: 4%" align="center">:
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtADP" runat="server" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ValidationGroup="vsErrorGrid"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter ADP DMS" Display="none"
                                                    ControlToValidate="txtADP"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%" align="left">Organization Code<span class="mf">*</span>
                                            </td>
                                            <td style="width: 4%" align="center">:
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtOrganization_Code" runat="server" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="vsErrorGrid"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Organization Code" Display="none"
                                                    ControlToValidate="txtOrganization_Code"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%" align="left">Organization Name<span class="mf">*</span>
                                            </td>
                                            <td style="width: 4%" align="center">:
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtOrganization_Name" runat="server" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ValidationGroup="vsErrorGrid"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Organization Name" Display="none"
                                                    ControlToValidate="txtOrganization_Name"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3">
                                                <asp:Label ID="lblError" runat="server" SkinID="lblError" EnableViewState="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%" align="left"></td>
                                            <td style="width: 4%" align="center"></td>
                                            <td align="left">
                                                <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" ValidationGroup="vsErrorGrid"
                                                    Text="Add" CausesValidation="false" OnClientClick="return CheckValidation();"></asp:Button>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                             <td style="width: 20%">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">&nbsp;
                            </td>
                        </tr>
                    </tbody>
                </table>
            </ContentTemplate>
                 <Triggers>
                     <asp:PostBackTrigger ControlID="btnBack" />
                 </Triggers>
        </asp:UpdatePanel>
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
