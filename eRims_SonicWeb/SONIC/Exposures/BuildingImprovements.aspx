<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="BuildingImprovements.aspx.cs"
    Inherits="SONIC_Exposures_BuildingImprovements" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/ExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">

    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <script type="text/javascript">
        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 1; i++) {
                var tb = document.getElementById("Menu" + i);
                if (i == index) {
                    tb.className = "LeftMenuSelected";
                    tb.onmouseover = function () { this.className = 'LeftMenuSelected'; }
                    tb.onmouseout = function () { this.className = 'LeftMenuSelected'; }
                }
                else {
                    tb.className = "LeftMenuStatic";
                    tb.onmouseover = function () { this.className = 'LeftMenuHover'; }
                    tb.onmouseout = function () { this.className = 'LeftMenuStatic'; }
                }
            }
        }

        function ShowPanel(index) {
            SetMenuStyle(index);
            ActiveTabIndex = index;
            var op = '<%=StrOperation%>';
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


        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_Building_Improvements.aspx?id=" + '<%=PK_Building_Improvements%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        function OpenNotesPopup() {
            var winHeight = 300;
            var winWidth = 750;

            obj = window.open("Popup_BuildingImprovementsNotes.aspx?id=" + '<%=PK_Building_Improvements%>', 'NotesPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
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

        function CalculateTotalSquareFootage() {
            var txtSales = $("#<%=txtSales.ClientID%>").val();
            var txtServiceLane = $("#<%=txtServiceLane.ClientID%>").val();
            var txtPart = $("#<%=txtPart.ClientID%>").val();
            var txtServiceDepartment = $("#<%=txtServiceDepartment.ClientID%>").val();
            var txtOther = $("#<%=txtOther.ClientID%>").val();

            var total = (parseInt(txtSales.replace(/,/g, '')) || 0) +
                        (parseInt(txtServiceLane.replace(/,/g, '')) || 0) +
                        (parseInt(txtPart.replace(/,/g, '')) || 0) +
                        (parseInt(txtServiceDepartment.replace(/,/g, '')) || 0) +
                        (parseInt(txtOther.replace(/,/g, '')) || 0);

            total = InsertCommas(total)

            $("#<%=txtTotalSquareFootageRevised.ClientID%>").val(total)


        }

        function CalculateBugetSubTotal_1() {
            var txtConstruction = $("#<%=txtConstruction.ClientID%>").val();
            var txtLand = $("#<%=txtLand.ClientID%>").val();
            var txtMiscellaneous = $("#<%=txtMiscellaneous.ClientID%>").val();

            var SubTotal_2 = $("#<%=txtSubtotal2.ClientID%>").val();


            var SubTotal_1 = (parseFloat(txtConstruction.replace(/,/g, '')) || 0) +
                        (parseFloat(txtLand.replace(/,/g, '')) || 0) +
                        (parseFloat(txtMiscellaneous.replace(/,/g, '')) || 0);

            var Total = (parseFloat(SubTotal_1) || 0) +
                        (parseFloat(SubTotal_2.replace(/,/g, '')) || 0);

            SubTotal_1 = InsertCommas(SubTotal_1);
            Total = InsertCommas(Total);

            $("#<%=txtSubtotal1.ClientID%>").val(SubTotal_1)
            $("#<%=txtTotalCost.ClientID%>").val(Total)


        }

        function CalculateBugetSubTotal_2() {
            var txtInformationTechnology = $("#<%=txtInformationTechnology.ClientID%>").val();
            var txtFurniture = $("#<%=txtFurniture.ClientID%>").val();
            var txtEquipment = $("#<%=txtEquipment.ClientID%>").val();
            var txtSignage = $("#<%=txtSignage.ClientID%>").val();

            var SubTotal_1 = $("#<%=txtSubtotal1.ClientID%>").val();

            var SubTotal_2 = (parseFloat(txtInformationTechnology.replace(/,/g, '')) || 0) +
                        (parseFloat(txtFurniture.replace(/,/g, '')) || 0) +
                        (parseFloat(txtEquipment.replace(/,/g, '')) || 0) +
                        (parseFloat(txtSignage.replace(/,/g, '')) || 0);

            var Total = (parseFloat(SubTotal_2) || 0) +
                        (parseFloat(SubTotal_1.replace(/,/g, '')) || 0);

            SubTotal_2 = InsertCommas(SubTotal_2);
            Total = InsertCommas(Total)

            $("#<%=txtSubtotal2.ClientID%>").val(SubTotal_2)
            $("#<%=txtTotalCost.ClientID%>").val(Total)


        }

    </script>

    <asp:ValidationSummary ID="valInspection" runat="server" ValidationGroup="vsErrorGroup"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="Spacer" style="height: 5px">&nbsp;
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 5px">&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 5px">&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <uc:ctrlExposureInfo ID="ucCtrlExposureInfo" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 5px">&nbsp;
            </td>
        </tr>
        <tr>
            <td class="ghc" align="left">Building Improvements
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2"></td>
                    </tr>
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="5" cellspacing="0" width="100%">
                                <tr>
                                    <td style="height: 18px;" class="Spacer"></td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Building
                                            Improvements </span>&nbsp;<span id="MenuAsterisk1" runat="server" style="color: Red; display: none">*</span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td width="5px" class="Spacer">&nbsp;
                                    </td>
                                    <td class="dvContainer">
                                        <div id="dvEdit" runat="server" width="794px">
                                            <asp:Panel ID="pnl1" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Building Improvements
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Building Number&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="2%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4" width="78%">
                                                            <asp:ListBox ID="lstBuildingNumber" runat="server" SelectionMode="Multiple" Rows="6" Width="600px"></asp:ListBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Project Number&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtProject_Number" Width="170px" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Project Start Date &nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtProject_Start_Date" Width="170px" runat="server" SkinID="txtDate"></asp:TextBox>
                                                            <img alt="Project Start Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtProject_Start_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top"></td>
                                                        <td align="left" valign="top">Target Completion Date &nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtTarget_Completion_Date" Width="170px" runat="server" SkinID="txtDate"></asp:TextBox>
                                                            <img alt="Target Completion Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtTarget_Completion_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top"></td>
                                                        <td align="left" valign="top">Actual Completion Date &nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtActual_Completion_Date" Width="170px" runat="server" SkinID="txtDate"></asp:TextBox>
                                                            <img alt="Actual Completion Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtActual_Completion_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Project Improvement Description&nbsp;<span id="Span92" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ControlType="TextBox" ID="txtProjectImprovementDescription" runat="server" IsRequired="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Contact Name&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtContactName" Width="170px" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">New Build? &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList runat="server" ID="rdoNew_Build" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Project Status As Of</td>
                                                        <td align="center" valign="top">:</td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtProjectStatusAsOf" Width="170px" runat="server" SkinID="txtDate"></asp:TextBox>
                                                            <img alt="Project Status As Of Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtProjectStatusAsOf', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                        </td>
                                                        <td align="left" valign="top">Open? &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList runat="server" ID="rdoOpen" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Status&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_BI_Status" runat="server"></asp:DropDownList>
                                                        </td>
                                                        <td align="left" valign="top">Status Description, If Other &nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtStatusDescription" Width="170px" runat="server" SkinID="txtDate"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Revised Square Footage&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList runat="server" ID="rdlRevisedSquareFootage" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Add" Value="Add" />
                                                                <asp:ListItem Text="Reduce" Value="Reduce" />
                                                                <asp:ListItem Text="No Change" Value="No Change" Selected="True" />
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Sales&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtSales" runat="server" Width="170px" onblur="CalculateTotalSquareFootage();" onkeypress="return FormatNumber(event,this.id,10 ,true);" />
                                                        </td>
                                                        <td align="left" valign="top">Service Lane&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtServiceLane" runat="server" Width="170px" onblur="CalculateTotalSquareFootage();" onkeypress="return FormatNumber(event,this.id,10 ,true);" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Part&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPart" runat="server" Width="170px" onblur="CalculateTotalSquareFootage();" onkeypress="return FormatNumber(event,this.id,10 ,true);" />
                                                        </td>
                                                        <td align="left" valign="top">Service Department&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtServiceDepartment" runat="server" Width="170px" onblur="CalculateTotalSquareFootage();" onkeypress="return FormatNumber(event,this.id,10 ,true);" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Other&nbsp;<span id="Span22" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtOther" runat="server" Width="170px" onblur="CalculateTotalSquareFootage();" onkeypress="return FormatNumber(event,this.id,10 ,true);" />
                                                        </td>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top"></td>
                                                        <td align="left" valign="top">Total Square Footage Revised
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtTotalSquareFootageRevised" runat="server" Width="170px" ReadOnly="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="left">
                                                            <b>Budget Details</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Construction&nbsp;<span id="Span23" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtConstruction" runat="server" Width="170px" onpaste="return false"
                                                            onblur="CalculateBugetSubTotal_1();" onkeypress="return FormatNumber(event,this.id,10 ,false);" />
                                                        </td>
                                                        <td align="left" valign="top">Information Technology&nbsp;<span id="Span24" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtInformationTechnology" runat="server" Width="170px" onpaste="return false"
                                                            onblur="CalculateBugetSubTotal_2();" onkeypress="return FormatNumber(event,this.id,10 ,false);" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Land&nbsp;<span id="Span25" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtLand" runat="server" Width="170px" onpaste="return false"
                                                            onblur="CalculateBugetSubTotal_1();" onkeypress="return FormatNumber(event,this.id,10 ,false);" />
                                                        </td>
                                                        <td align="left" valign="top">Furniture&nbsp;<span id="Span26" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtFurniture" runat="server" Width="170px" onpaste="return false"
                                                            onblur="CalculateBugetSubTotal_2();" onkeypress="return FormatNumber(event,this.id,10 ,false);" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Miscellaneous&nbsp;<span id="Span27" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtMiscellaneous" runat="server" Width="170px" onpaste="return false"
                                                            onblur="CalculateBugetSubTotal_1();" onkeypress="return FormatNumber(event,this.id,10 ,false);" />
                                                        </td>
                                                        <td align="left" valign="top">Equipment&nbsp;<span id="Span28" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtEquipment" runat="server" Width="170px" onpaste="return false"
                                                            onblur="CalculateBugetSubTotal_2();" onkeypress="return FormatNumber(event,this.id,10 ,false);" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top"></td>
                                                        <td align="left" valign="top">Signage&nbsp;<span id="Span30" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtSignage" runat="server" Width="170px" onpaste="return false"
                                                            onblur="CalculateBugetSubTotal_2();" onkeypress="return FormatNumber(event,this.id,10 ,true);" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top">
                                                            <hr />
                                                        </td>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top">
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Sub-Total&nbsp;<span id="Span29" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtSubtotal1" runat="server" Width="170px" onpaste="return false"
                                                            ReadOnly="true" />
                                                        </td>
                                                        <td align="left" valign="top">Sub-Total&nbsp;<span id="Span31" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtSubtotal2" runat="server" Width="170px" onpaste="return false"
                                                            ReadOnly="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top"></td>
                                                        <td align="left" valign="top">Total Cost&nbsp;<span id="Span33" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtTotalCost" runat="server" Width="170px" onpaste="return false"
                                                            ReadOnly="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Project Notes Grid
                                                            <br />
                                                            <asp:LinkButton ID="lnkAddProjectNotesGrid" runat="server" Text="--Add--" OnClientClick="javascript:return OpenNotesPopup();"
                                                                ValidationGroup="vsErrorProject" CausesValidation="true"></asp:LinkButton>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvProjectNotes" runat="server" GridLines="None" CellPadding="4" CellSpacing="0"
                                                                AutoGenerateColumns="false" Width="100%" EnableTheming="false" AllowSorting="true">
                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <RowStyle BackColor="#EAEAEA" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EditRowStyle BackColor="#2461BF" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <PagerStyle BackColor="#7f7f7f" ForeColor="White" HorizontalAlign="Center" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <HeaderStyle BackColor="#7f7f7f" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" VerticalAlign="Bottom" />
                                                                <AlternatingRowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EmptyDataRowStyle CssClass="emptyrow" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Left" SortExpression="Note_Date">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnNoteDate" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_FE_PA_Notes") %>'> 
                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Note_Date"))%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Note Text" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lblNotes" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_FE_PA_Notes") %>' CssClass="TextClip" Width="410px">
                                                                                <%# Eval("Note")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnRemove" runat="server" Text="Remove" OnClientClick="return confirm('Are you Sure to delete this record?');"
                                                                                CommandName="Remove" CommandArgument='<%# Eval("PK_AP_FE_PA_Notes") %>'>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <b>No Record found</b>
                                                                </EmptyDataTemplate>
                                                                <PagerSettings Visible="False" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlNoteGridAdd" runat="server" Width="100%" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Notes Grid
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="21%" valign="top">Date&nbsp;<span id="Span130" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtNotesDate" runat="server" Width="170px" SkinID="txtDate"></asp:TextBox>
                                                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtNotesDate', 'mm/dd/y','','');"
                                                                onmouseover="javascript:this.style.cursor='hand';" alt="" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revtxtNotesDate" runat="server" ValidationGroup="vsErrorFraudEventsNotes"
                                                                Display="none" ErrorMessage="Date is not a valid" SetFocusOnError="true" ControlToValidate="txtNotesDate"
                                                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <%--<asp:RangeValidator ID="regtxtNotesDate" ControlToValidate="txtNotesDate"
                                                                            MinimumValue="01/01/1753" MaximumValue="12/31/2010" Type="Date" ErrorMessage="Date must be valid."
                                                                            runat="server" SetFocusOnError="true" ValidationGroup="vsErrorNotesAdd" Display="none" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Note Text&nbsp;<span id="Span125" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtNotesAdd" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" align="left" valign="top">
                                                            <table border="0" align="center" cellpadding="0" cellspacing="5">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnNotesGridAdd" runat="server" Text="Save" CausesValidation="true" Visible="false"
                                                                            ValidationGroup="vsErrorFraudEventsNotes" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnViewAuditNotesGrid" runat="server" Text="View Audit Trail" OnClientClick="return openAP_FE_Notes_AuditPopup();"
                                                                            CausesValidation="false" Visible="false" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnFraudNotesGridAdd" runat="server" Text="Save" CausesValidation="true" Visible="false"
                                                                            ValidationGroup="vsErrorFraudEventsNotes" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnViewFraudAuditNotesGrid" runat="server" Text="View Audit Trail" OnClientClick="return openAP_FE_PA_Notes_AuditPopup();"
                                                                            CausesValidation="false" Visible="false" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnBackFraudEvent" runat="server" Text="Back" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <div id="dvView" runat="server" width="794px">
                                            <asp:Panel ID="pnl1View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Building Improvements
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top">Building Number&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblBuildingNumber" runat="server" />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Project Number&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblProjectNumber" Width="170px" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Project Start Date &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblProjectStartDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top"></td>
                                                        <td align="left" valign="top">Target Completion Date &nbsp;<span id="Span36" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTargetCompletionDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top"></td>
                                                        <td align="left" valign="top">Actual Completion Date &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblActualCompletionDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Project Improvement Description&nbsp;<span id="Span38" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ControlType="Label" ID="CtrlMultiLineLabelProjectImprovementDescription" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Contact Name&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblContactName" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">New Build? &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButton runat="server" ID="rdbNewBuildView" SkinID="YesNoType" Enabled="false"></asp:RadioButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Project Status As Of</td>
                                                        <td align="center" valign="top">:</td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblProjectStatusAsOfDate" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Open? &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList runat="server" ID="rdbOpenView" Enabled="false" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Status&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblStatus" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Status Description, If Other &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblStatusDescription" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Revised Square Footage&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList runat="server" ID="rdbRevisedSquareFootageView" RepeatDirection="Horizontal" Enabled="false">
                                                                <asp:ListItem Text="Add" Value="Add" />
                                                                <asp:ListItem Text="Reduce" Value="Reduce" />
                                                                <asp:ListItem Text="No Change" Value="No Change" />
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Sales&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSales" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Service Lane&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblServiceLane" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Part&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPart" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Service Department&nbsp;<span id="Span46" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblServiceDepartment" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Other&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblOther" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top"></td>
                                                        <td align="left" valign="top">Total Square Footage Revised
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTotalSquareFootageRevised" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Improvement Description&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblImprovementDescription" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Service Capacity Increase&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblServiceCapacityIncrease" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="left">
                                                            <b>Budget Details</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Construction&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:Label ID="lblConstruction" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Information Technology&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:Label ID="lblInformationTechnology" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Land&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:Label ID="lblLand" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Furniture&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:Label ID="lblFurniture" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Miscellaneous&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:Label ID="lblMiscellaneous" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Equipment&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:Label ID="lblEquipment" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top"></td>
                                                        <td align="left" valign="top">Signage&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:Label ID="lblSignage" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top">
                                                            <hr />
                                                        </td>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top">
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Sub-Total&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:Label ID="lblSubtotal" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Subtotal&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:Label ID="lblSubTotal2" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top"></td>
                                                        <td align="left" valign="top">Total Cost&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:Label ID="lblTotalCost" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Project Notes Grid</td>
                                                        <td align="center" valign="top">:</td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvProjectNotesGridview" runat="server" />
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
                                        <td>&nbsp;
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
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="dvBack" runat="server" style="display: none;">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" width="100%">
                                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />&nbsp;
                                            <asp:Button ID="btnViewAudit2" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
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
