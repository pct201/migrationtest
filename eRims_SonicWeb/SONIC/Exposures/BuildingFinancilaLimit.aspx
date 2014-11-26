<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="BuildingFinancilaLimit.aspx.cs"
    Inherits="SONIC_Exposures_BuildingFinancilaLimit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/ExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
   
    <script type="text/javascript">
        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 1; i++) {
                var tb = document.getElementById("Menu" + i);
                if (i == index) {
                    tb.className = "LeftMenuSelected";
                    tb.onmouseover = function() { this.className = 'LeftMenuSelected'; }
                    tb.onmouseout = function() { this.className = 'LeftMenuSelected'; }
                }
                else {
                    tb.className = "LeftMenuStatic";
                    tb.onmouseover = function() { this.className = 'LeftMenuHover'; }
                    tb.onmouseout = function() { this.className = 'LeftMenuStatic'; }
                }
            }
        }

        function ShowPanel(index) {
            SetMenuStyle(index);
            ActiveTabIndex = index;
            var op = '<%=_StrOperation%>';
            if (op == "view") {
                ShowPanelView(index);
            }
            else {
                var i;
                for (i = 1; i <= 1; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
                }
            }
        }

        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            var i;
            for (i = 1; i <= 1; i++) {
                document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = (i == index) ? "block" : "none";
            }
        }

        function CalculateTotal() 
        {           
            var decbuildingLimit = document.getElementById('<%=txtBuildingLimit.ClientID%>').value;
            decbuildingLimit = RemoveCommas(decbuildingLimit);

            var decAssoLimit = document.getElementById('<%=txtAssociateToolsLimit.ClientID%>').value;
            decAssoLimit = RemoveCommas(decAssoLimit);

            var decContentLimit = document.getElementById('<%=txtContentsLimit.ClientID%>').value;
            decContentLimit = RemoveCommas(decContentLimit);

            var decPartsLimit = document.getElementById('<%=txtPartsLimit.ClientID%>').value;
            decPartsLimit = RemoveCommas(decPartsLimit);
            
            var decBusiInter = document.getElementById('<%=txtBusinessInterruption.ClientID%>').value;
            decBusiInter = RemoveCommas(decBusiInter);

            decbuildingLimit = (decbuildingLimit != '') ? Number(decbuildingLimit) : 0;
            decAssoLimit = (decAssoLimit != '') ? Number(decAssoLimit) : 0;
            decContentLimit = (decContentLimit != '') ? Number(decContentLimit) : 0;
            decPartsLimit = (decPartsLimit != '') ? Number(decPartsLimit) : 0;
            decBusiInter = (decBusiInter != '') ? Number(decBusiInter) : 0;

            var Total = decbuildingLimit + decAssoLimit + decContentLimit + decPartsLimit + decBusiInter;
            Total.toFixed(2);
            Total = CurrencyFormatted(Total);
            document.getElementById('<%=txtBuildingTotal.ClientID%>').value = InsertCommas(Total).replace(".00", "");
        }

        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_Building_FinancialLimits.aspx?id=" + '<%=_PK_Building_Financial_Limits%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        function ValidateFields(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDs.ClientID%>').value != "") {
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

        jQuery(function ($) {
            $("#<%=txtPropertyValuationDate.ClientID%>").mask("99/99/9999");
        });
    </script>

    <asp:ValidationSummary ID="valInspection" runat="server" ValidationGroup="vsErrorGroup"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="Spacer" style="height: 5px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 5px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <uc:ctrlExposureInfo ID="ucCtrlExposureInfo" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 5px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="ghc" align="left">
                Building Financial Limits Grid
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="5" cellspacing="0" width="100%">
                                <tr>
                                    <td style="height: 18px;" class="Spacer">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%" nowrap="nowrap">
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Financial Limits</span>&nbsp;
                                        <span id="MenuAsterisk1" runat="server" style="color: Red;display:none">*</span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td width="5px" class="Spacer">
                                        &nbsp;
                                    </td>
                                    <td class="dvContainer">
                                        <div id="dvEdit" runat="server" width="794px">
                                            <asp:Panel ID="pnl1" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Building Financial Limits
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td colspan="6" class="spacer" height="5px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Property Valuation Date&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtPropertyValuationDate" runat="server" Width="145px" SkinID="txtDate" />
                                                            <img alt="PV Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPropertyValuationDate', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                                 <asp:RegularExpressionValidator ID="revReport_Date" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="Property Valuation Date is not a valid date" SetFocusOnError="true"
                                                                ControlToValidate="txtPropertyValuationDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>                                          
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            RS Means Building Limit ($)&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtBuildingLimit" runat="server" Width="170px" onpaste="return false"
                                                                onkeypress="return FormatNumber(event,this.id,8,true);" onchange="CalculateTotal();"
                                                                onblur="CalculateTotal();" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Associate Tools Limit ($)&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtAssociateToolsLimit" runat="server" Width="170px" onpaste="return false"
                                                                onkeypress="return FormatNumber(event,this.id,8,true);" onchange="CalculateTotal();"
                                                                onblur="CalculateTotal();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Contents Limit ($)&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtContentsLimit" runat="server" Width="170px" onpaste="return false"
                                                                onkeypress="return FormatNumber(event,this.id,8,true);" onchange="CalculateTotal();"
                                                                onblur="CalculateTotal();" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Parts Limit ($)&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPartsLimit" runat="server" Width="170px" onpaste="return false"
                                                                onkeypress="return FormatNumber(event,this.id,8,true);" onchange="CalculateTotal();"
                                                                onblur="CalculateTotal();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Business Interruption ($)&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtBusinessInterruption" runat="server" Width="170px" onpaste="return false"
                                                                onkeypress="return FormatNumber(event,this.id,8,true);" onchange="CalculateTotal();"
                                                                onblur="CalculateTotal();" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Total ($)&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtBuildingTotal" runat="server" Width="170px" ReadOnly="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" class="spacer" height="5px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <div id="dvView" runat="server" width="794px">
                                            <asp:Panel ID="pnl1View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Building Financial Limits
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td colspan="6" class="spacer" height="5px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Property Valuation Date
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblPropertyValueDate" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            RS Means Building Limit ($)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblBuildingLimit" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Associate Tools Limit ($)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAssociatedLimits" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Contents Limit ($)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblContentLimit" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Parts Limit ($)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPartsLimits" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Business Interruption ($)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblBuildingInteruption" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Total ($)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" class="spacer" height="5px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <div id="dvSave" runat="server">
                                <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="50%" align="right">
                                            <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click"
                                                CausesValidation="true" ValidationGroup="vsErrorGroup" />
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnRevertReturn" runat="server" Text="Revert & Return" OnClick="btnRevertReturn_Click" />&nbsp;
                                            <asp:Button ID="btnViewAudit" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="dvBack" runat="server" style="display: none;">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" width="100%">
                                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />&nbsp;
                                            <asp:Button ID="btnViewAudit2" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <asp:CustomValidator ID="CustomValidatorBuild" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
