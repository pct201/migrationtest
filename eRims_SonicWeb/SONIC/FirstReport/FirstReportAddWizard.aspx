<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="FirstReportAddWizard.aspx.cs" Inherits="SONIC_FirstReportAddWizard"
    Title="eRIMS Sonic :: First Report :: Report Add Wizard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
  <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
<script language="javascript" type="text/javascript">

    function CheckDummyVal() {
        Page_ClientValidate('11');
        return true;
    }

    // check atleast one Report type is selcted
    function CheckIsLeastOneReportSelected() {
        var ctl1 = document.getElementById('<%=rdoInjured_Employee.ClientID %>');
        var ctl2 = document.getElementById('<%=rdoInvolve_Vehicle.ClientID %>');
        var ctl3 = document.getElementById('<%=rdoGeneral_Claim.ClientID %>');
        var ctl4 = document.getElementById('<%=rdoProperty_Claim.ClientID %>');
        var rdo1 = document.getElementById(ctl1.id + "_0");
        var rdo2 = document.getElementById(ctl2.id + "_0");
        var rdo3 = document.getElementById(ctl3.id + "_0");
        var rdo4 = document.getElementById(ctl4.id + "_0");
        //Page Validate
        if (document.getElementById('<%=txtTelephoneNumber1.ClientID%>').value == "___-___-____")
            document.getElementById('<%=txtTelephoneNumber1.ClientID%>').value = "";
        if (document.getElementById('<%=txtTelephoneNumber2.ClientID%>').value == "___-___-____")
            document.getElementById('<%=txtTelephoneNumber2.ClientID%>').value = "";

        //        if(Page_ClientValidate())
        //        {
        if (rdo1.checked == true || rdo3.checked == true || rdo4.checked == true)
            return Page_ClientValidate();
        else {
            //check Radiobutton is checked or not
            if (rdo2.checked == true) {
                var chk1 = document.getElementById('<%=chkInventoried_Vehicle.ClientID %>');
                var chk2 = document.getElementById('<%=chkCustomer_Vehicle.ClientID %>');
                var chk3 = document.getElementById('<%=chkOther_Vehicle.ClientID %>');
                //alert(chk1.checked);
                if (chk1.checked == true || chk2.checked == true || chk3.checked == true) {
                    return Page_ClientValidate();
                }
                else {
                    alert('Please select at least one Report');
                    return false;
                }
            }
            else {
                alert('Please select at least one Report');
                return false;
            }
        }

        //        }
        //        else        
        //            return false;        
    }

    //Used to check Page Validation
    function ManageControlVal() {
        if (Page_ClientValidate())
            return true;
        else
            return false;
    }

    //Check values for Vehicle
    function ChangeVehicleValue() {
        var ctl = document.getElementById('<%=rdoInvolve_Vehicle.ClientID %>');
        var rdo = document.getElementById(ctl.id + "_0");
        if (rdo.checked == true)
            document.getElementById('DivIsVahicleInvolve').style.display = "block";
        else {
            var chk1 = document.getElementById('<%=chkInventoried_Vehicle.ClientID %>');
            var chk2 = document.getElementById('<%=chkCustomer_Vehicle.ClientID %>');
            var chk3 = document.getElementById('<%=chkOther_Vehicle.ClientID %>');
            //alert(chk1.checked);
            if (chk1.checked == true || chk2.checked == true || chk3.checked == true) {
                rdo.checked = true;
                alert('One or more of the sub-questions is still checked.');
            }
            else
                document.getElementById('DivIsVahicleInvolve').style.display = "none";
        }
    }

    jQuery(function ($) {
        $("#<%=txtTelephoneNumber1.ClientID%>").mask("999-999-9999");
        $("#<%=txtTelephoneNumber2.ClientID%>").mask("999-999-9999");
    });

</script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="groupHeaderBar" align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdateProgress runat="server" ID="upProgress" DisplayAfter="10">
                    <progresstemplate>
                        <div class="UpdatePanelloading" id="divProgress">
                            <table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%;
                                height: 100%;">
                                <tr align="center" valign="middle">
                                    <td class="LoadingText" align="center" valign="middle">
                                        <img src="../../Images/indicator.gif" alt="Loading" />&nbsp;&nbsp;&nbsp;Please Wait..
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </progresstemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="width: 200px;" colspan="2" class="bandHeaderRow">
                            Add First Report Wizard
                        </td>
                    </tr>
                     <tr>
                        <td class="Spacer" style="height: 20px;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px;" valign="top">
                            &nbsp;&nbsp;Step 1: Please Complete the following
                        </td>
                        <td class="Spacer">
                            <asp:UpdatePanel runat="server" ID="updStep3" UpdateMode="Conditional">
                                <contenttemplate>
                                    <table cellpadding="3" cellspacing="1" width="100%" border="0">
                                        <tr>
                                            <td style="width: 80%">
                                                Does the incident involve a Sonic Automotive associate?</td>
                                            <td style="width: 20%">
                                                <asp:RadioButtonList runat="server" ID="rdoInjured_Employee" SkinID="YesNoType">
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Does the incident involve a vehicle?</td>
                                            <td>
                                                <asp:RadioButtonList runat="server" ID="rdoInvolve_Vehicle" SkinID="YesNoType">
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div id="DivIsVahicleInvolve" style="display: none">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td colspan="3">
                                                                Check all that apply:</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 25%">
                                                                &nbsp;</td>
                                                            <td style="width: 20%">
                                                                <asp:CheckBox runat="server" ID="chkInventoried_Vehicle" Enabled="true" /></td>
                                                            <td style="width: 55%">
                                                                Inventoried Vehicle</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                <asp:CheckBox runat="server" ID="chkCustomer_Vehicle" Enabled="true" /></td>
                                                            <td>
                                                                Customer Vehicle</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                <asp:CheckBox runat="server" ID="chkOther_Vehicle" Enabled="true" /></td>
                                                            <td>
                                                                Third Party Vehicle/Other Vehicle/Third Party Injury</td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Does the incident involve a customer/pedestrian claiming either damages or injuries
                                                while on our premises?</td>
                                            <td>
                                                <asp:RadioButtonList runat="server" ID="rdoGeneral_Claim" SkinID="YesNoType" Enabled="true">
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Does the incident involve damage to property (i.e. building, associate tools, contents,
                                                business interruption) owned, leased, or managed by Sonic Automotive?</td>
                                            <td>
                                                <asp:RadioButtonList runat="server" ID="rdoProperty_Claim" SkinID="YesNoType" Enabled="true">
                                                </asp:RadioButtonList></td>
                                        </tr>
                                    </table>
                                </contenttemplate>
                                <triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnContiune" EventName="Click" />
                                </triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px;" colspan="6" align="center">
                        </td>
                        </tr>
                     <tr>
                        <td class="Spacer" style="height: 10px;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px;">
                            &nbsp;&nbsp;Step 2: Enter Location Information
                        </td>
                        <td class="Spacer">
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer">
                        </td>
                        <td>
                            <asp:UpdatePanel runat="server" ID="updStep1" UpdateMode="Always">
                                <contenttemplate>
                                    <table cellpadding="3" cellspacing="1" width="100%" border="0">
                                        <tr>
                                            <td align="left" width="18%">
                                                Sonic Location Number
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="22%">
                                                <asp:DropDownList ID="ddlRMLocationNumber" SkinID="ddlSONIC" runat="server" OnSelectedIndexChanged="ddlRMLocationNumber_SelectedIndexChanged"
                                                    AutoPostBack="True" ValidationGroup="vsErrorGroup" onchange="CheckDummyVal();">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator runat="server" ID="rfvRMLocationNumber" ControlToValidate="ddlRMLocationNumber"
                                                    ErrorMessage="Please Select either Sonic Location Number or Location d/b/a or Legal Entity or Location f/k/a"
                                                    Display="none" ValidationGroup="vsErrorGroup" InitialValue="0">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td align="left" width="10%">
                                                Location d/b/a
                                            </td>
                                            <td align="center" width="1%">
                                                :
                                            </td>
                                            <td align="left" width="46%">
                                                <asp:DropDownList runat="server" ID="ddlLocationdba" Width="100%" OnSelectedIndexChanged="ddlLocationdba_SelectedIndexChanged"
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Legal Entity
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList runat="server" ID="ddlLegalEntity" SkinID="ddlSONIC" OnSelectedIndexChanged="ddlLegalEntity_SelectedIndexChanged"
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left">
                                                Location f/k/a
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList runat="server" ID="ddlLocationfka" SkinID="ddlSONIC">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Address 1
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:TextBox runat="server" ID="txtAddress1" Width="170px" Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Address 2
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:TextBox runat="server" ID="txtAddress2" Width="170px" Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                City
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:TextBox runat="server" ID="txtCity" Width="170px" Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                State
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:TextBox runat="server" ID="txtState" Width="170px" Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Zip Code
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:TextBox runat="server" ID="txtZipcode" Width="170px" Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </contenttemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 20px;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px;" valign="top">
                            &nbsp;&nbsp;Step 3: Enter Associate’s Supervisor’s<BR>&nbsp;&nbsp;&nbsp;&nbsp;Contact Information (This IS NOT<BR>&nbsp;&nbsp;&nbsp;&nbsp;the Injured Associate’s Contact<BR>&nbsp;&nbsp;&nbsp;&nbsp;Information)
                        </td>
                        <td class="Spacer">
                            <asp:UpdatePanel runat="server" ID="updStep2">
                                <contenttemplate>
                                    <table cellpadding="3" cellspacing="1" width="100%" border="0">
                                        <tr>
                                            <td align="left" style="width: 88px">
                                                Name
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:DropDownList runat="server" ID="ddlName" SkinID="ddlSONIC" OnSelectedIndexChanged="ddlName_SelectedIndexChanged"
                                                    AutoPostBack="True" onchange="CheckDummyVal();">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator runat="Server" ID="rfvName" ErrorMessage="Please Select Name"
                                                    Display="none" ControlToValidate="ddlName" ValidationGroup="vsErrorGroup" InitialValue="0"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="left" width="18%">
                                                &nbsp;
                                            </td>
                                            <td align="center" width="4%">
                                                &nbsp;
                                            </td>
                                            <td align="left" width="28%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 88px">
                                                Title
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:TextBox runat="server" ID="txtTitle" Width="170px" Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 88px">
                                                Telephone Number 1<br />
                                                (xxx-xxx-xxxx)
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:TextBox runat="server" ID="txtTelephoneNumber1" Width="170px" Enabled="true"
                                                    MaxLength="12"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtTelephoneNumber1"
                                                    runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Telephone Number 1 in xxx-xxx-xxxx format."
                                                    Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 88px">
                                                Telephone Number 2<br />
                                                (xxx-xxx-xxxx)
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:TextBox runat="server" ID="txtTelephoneNumber2" Width="170px" Enabled="true"
                                                    MaxLength="12"></asp:TextBox>
                                               <asp:RegularExpressionValidator ID="revtxtTelephoneNumber2" ControlToValidate="txtTelephoneNumber2"
                                                    runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Telephone Number 2 in xxx-xxx-xxxx format."
                                                    Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                <td align="left" style="width: 88px">
                                    Fax Number<br />(xxx-xxx-xxxx)
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td align="left" colspan="3">
                                    <asp:TextBox runat="server" ID="txtFaxNumber" Width="170px"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="mskFaxNumber" runat="server" TargetControlID="txtFaxNumber"
                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                    </cc1:MaskedEditExtender>
                                    <asp:RegularExpressionValidator ID="revFaxNumber" ControlToValidate="txtFaxNumber"
                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Fax Number in xxx-xxx-xxxx format."
                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>--%>
                                        <tr>
                                            <td align="left" style="width: 88px">
                                                Email Address
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:TextBox runat="server" ID="txtEmailAddress" Width="170px" Enabled="true" MaxLength="100"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="None" ControlToValidate="txtEmailAddress"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vsErrorGroup"
                                                    ErrorMessage="Email Address is not valid.">
                                                </asp:RegularExpressionValidator></td>
                                        </tr>
                                    </table>
                                </contenttemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                   
                    <tr>
                        <td colspan="6" align="center">
                            <asp:Button runat="server" ID="btnContiune" CausesValidation="false" Text="Continue"
                                OnClick="btnContiune_Click" ValidationGroup="vsErrorGroup" OnClientClick="return CheckIsLeastOneReportSelected();"
                                ToolTip="Continue" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 20px;">
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
        //used to get height of scrollbar and add to total screen height +  scollbar height
        function getScrollHeight() {
            var h = window.pageYOffset ||
           document.body.scrollTop ||
           document.documentElement.scrollTop;
            document.getElementById('divProgress').style.height = screen.height + h;
            document.getElementById('ProgressTable').style.height = screen.height + h;
        }
    </script>

    <script language="javascript" type="text/javascript">
        window.onscroll = getScrollHeight;
    </script>

</asp:Content>
