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
            $("#<%=pnlNoteGridAdd.ClientID%>").css("display", "");
            $("#<%=pnl1.ClientID%>").css("display", "none");
            $("#Menu1").text("Project Notes");
            $("#ghcHeader").text("Building Improvements - Project Notes");
            var today = new Date();
            var dd = today.getDate();
            var mm = today.getMonth() + 1; //January is 0!
            var yyyy = today.getFullYear();

            if (dd < 10) {
                dd = '0' + dd
            }

            if (mm < 10) {
                mm = '0' + mm
            }

            today = mm + '/' + dd + '/' + yyyy;
            $("#<%=txtNote_Date.ClientID%>").val(today);
            return false;
        }

        function OpenNotesPopupView() {
            $("#<%=pnlNoteGridView.ClientID%>").css("display", "");
            $("#<%=pnl1View.ClientID%>").css("display", "none");
            $("#Menu1").text("Project Notes");
            $("#ghcHeader").text("Building Improvements - Project Notes");
            var today = new Date();
            var dd = today.getDate();
            var mm = today.getMonth() + 1; //January is 0!
            var yyyy = today.getFullYear();

            if (dd < 10) {
                dd = '0' + dd
            }

            if (mm < 10) {
                mm = '0' + mm
            }

            today = mm + '/' + dd + '/' + yyyy;
            $("#<%=txtNote_Date.ClientID%>").val(today);
            return false;
        }

        function CloseNotesPopUp() {
            $("#<%=pnlNoteGridAdd.ClientID%>").css("display", "none");
            $("#<%=pnl1.ClientID%>").css("display", "");

            $("#<%=hdnPK_Building_Improvement_Notes.ClientID%>").val("0");
            $("#<%=txtProjectNotes.ClientID%>").val("");
            $("#<%=txtNote_Date.ClientID%>").val("");
            $("#<%=txtLast_Modified_date.ClientID%>").val("");

            $("#Menu1").text("Building Improvements");
            $("#ghcHeader").text("Building Improvements");
            return false;
        }

        function CloseNotesPopUpView() {
            $("#<%=pnlNoteGridView.ClientID%>").css("display", "none");
            $("#<%=pnl1View.ClientID%>").css("display", "");

            $("#<%=hdnPK_Building_Improvement_Notes.ClientID%>").val("0");
            $("#<%=lblProjectNotes.ClientID%>").val("");
            $("#<%=lblNote_Date.ClientID%>").val("");
            $("#<%=lblLast_Modified_date.ClientID%>").val("");

            $("#Menu1").text("Building Improvements");
            $("#ghcHeader").text("Building Improvements");
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

            SubTotal_1 = InsertCommas(CurrencyFormatted(SubTotal_1));
            Total = InsertCommas(CurrencyFormatted(Total));

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

            SubTotal_2 = InsertCommas(CurrencyFormatted(SubTotal_2));
            Total = InsertCommas(CurrencyFormatted(Total))

            $("#<%=txtSubtotal2.ClientID%>").val(SubTotal_2)
            $("#<%=txtTotalCost.ClientID%>").val(Total)


        }

        function funStatus(val) {
            //in val u get dropdown list selected value
            if (val == "Other - Describe") {
                $("#<%=txtStatusDescription.ClientID%>").attr("disabled", false);
                $("#<%=Span16.ClientID%>").css("display", "");

                var statusID = "<%=txtStatusDescription.ClientID%>";
                var hdnControlIDs = $("#<%=hdnControlIDs.ClientID%>").val() + "," + statusID;
                var hdnErrorMsgs = $("#<%=hdnErrorMsgs.ClientID%>").val() + ",Please enter Status Description - If Other";

                $("#<%=hdnControlIDs.ClientID%>").val(hdnControlIDs);
                $("#<%=hdnErrorMsgs.ClientID%>").val(hdnErrorMsgs);
                //.Value
            }
            else {
                $("#<%=txtStatusDescription.ClientID%>").attr("disabled", true);
                $("#<%=Span16.ClientID%>").css("display", "none");

                var statusID = ",<%=txtStatusDescription.ClientID%>";
                var hdnControlIDs = $("#<%=hdnControlIDs.ClientID%>").val();
                hdnControlIDs = hdnControlIDs.replace(statusID, "");
                var hdnErrorMsgs = $("#<%=hdnErrorMsgs.ClientID%>").val() + ",Please enter Status Description, If Other";
                hdnErrorMsgs = hdnErrorMsgs.replace(",Please enter Status Description - If Other", "");

                $("#<%=hdnControlIDs.ClientID%>").val(hdnControlIDs);
                $("#<%=hdnErrorMsgs.ClientID%>").val(hdnErrorMsgs);
            }
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
            <td class="ghc" align="left" id="ghcHeader">Building Improvements
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
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:TextBox ID="txtProject_Number" Width="170px" MaxLength="20" runat="server" />
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
                                                        <td align="left" valign="top">Project Status As Of<span id="Span1" style="color: Red; display: none;" runat="server">*</span></td>
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
                                                            <asp:DropDownList ID="drpFK_LU_BI_Status" runat="server" onchange="funStatus(this.options[this.selectedIndex].text);"></asp:DropDownList>
                                                        </td>
                                                        <td align="left" valign="top">Status Description, If Other &nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtStatusDescription" Width="170px" runat="server" disabled="disabled"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Revised Square Footage&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList runat="server" ID="rdlRevisedSquareFootage" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Add" Value="A" />
                                                                <asp:ListItem Text="Reduce" Value="R" />
                                                                <asp:ListItem Text="No Change" Value="N" Selected="True" />
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
                                                            <asp:TextBox ID="txtTotalSquareFootageRevised" runat="server" Width="170px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="left">
                                                            <b>Tax Information</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <span style="float:left">a.</span>
                                                            <div style="margin-left:40px">
                                                                <span>Does the project result in the replacement of an material major components(i.e. electrical panels, wiring, HVAC), or a substaintial strcutrual part of the property?</span><br />
                                                                <asp:TextBox runat="server" ID="txtItem_1" style="margin-top:3px;" MaxLength="250"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <span style="float:left">b.</span>
                                                            <div style="margin-left:40px">
                                                                <span>Any interior or exterior lightening upgrades? Describe.   </span><br />
                                                                <asp:TextBox runat="server" ID="txtItem_2" style="margin-top:3px;" MaxLength="250"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <span style="float:left">c.</span>
                                                            <div style="margin-left:40px">
                                                                <span>Environmental issues (asbestos, USTs, in-ground lifts)? Describe action taken</span><br />
                                                                <asp:TextBox runat="server" ID="txtItem_3" style="margin-top:3px;" MaxLength="250"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <span style="float:left">d.</span>
                                                            <div style="margin-left:40px">
                                                                <span>Any ADA improvements?</span><br />
                                                                <asp:TextBox runat="server" ID="txtItem_4" style="margin-top:3px;" MaxLength="250"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <span style="float:left">e.</span>
                                                            <div style="margin-left:40px">
                                                                <span>Any new HVAC units? Specify whether new adds or replacements?</span><br />
                                                                <asp:TextBox runat="server" ID="txtItem_5" style="margin-top:3px;" MaxLength="250"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <span style="float:left">f.</span>
                                                            <div style="margin-left:40px">
                                                                <span>What area does new or replacement HVAC unit(s) serve?</span><br />
                                                                <asp:TextBox runat="server" ID="txtItem_6" style="margin-top:3px;" MaxLength="250"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <span style="float:left">g.</span>
                                                            <div style="margin-left:40px">
                                                                <span>How many HVAC units served this area before imporovements?</span><br />
                                                                <asp:TextBox runat="server" ID="txtNumberOfHavacBeforeImprovements" MaxLength="10" onkeypress="return FormatInteger(event);" onpaste="return false;" style="margin-top:3px;"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <span style="float:left">h.</span>
                                                            <div style="margin-left:40px">
                                                                <span>How many HVAC units served this area after imporovements?</span><br />
                                                                <asp:TextBox runat="server" ID="txtNumberOfHavacAfterImprovements" MaxLength="10" onkeypress="return FormatInteger(event);" onpaste="return false;" style="margin-top:3px;"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <span style="float:left">i.</span>
                                                            <div style="margin-left:40px">
                                                                <span>Were roof improvements made? Specify wheather overlay or replacement and if partial or complete building was touched?</span><br />
                                                                <asp:TextBox runat="server" ID="txtRoofImprovementsDetails" style="margin-top:3px;"  MaxLength="250"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <span style="float:left">j.</span>
                                                            <div style="margin-left:40px">
                                                                <span>Any additions or replacements of OH/High Speed doors? Specify</span><br />
                                                                <asp:TextBox runat="server" ID="txtAdditionalReplace" style="margin-top:3px;" MaxLength="250"></asp:TextBox>
                                                            </div>
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
                                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtSubtotal1" runat="server" Width="170px" onpaste="return false" />
                                                        </td>
                                                        <td align="left" valign="top">Sub-Total&nbsp;<span id="Span31" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtSubtotal2" runat="server" Width="170px" onpaste="return false" />
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
                                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtTotalCost" runat="server" Width="170px" onpaste="return false" />
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
                                                                AutoGenerateColumns="false" Width="100%" EnableTheming="false" AllowSorting="true" OnRowCommand="gvProjectNotes_RowCommand">
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
                                                                            <asp:LinkButton ID="lnkbtnNoteDate" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_Building_Improvements_Notes") %>'> 
                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Of_Note"))%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Note Text" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lblNotes" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_Building_Improvements_Notes") %>' CssClass="TextClip" Width="410px">
                                                                                <%# Eval("Note")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnRemove" runat="server" Text="Remove" OnClientClick="return confirm('Are you Sure to delete this record?');"
                                                                                CommandName="Remove" CommandArgument='<%# Eval("PK_Building_Improvements_Notes") %>'>
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
                                                    Project Notes
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="20%" valign="top">Date of Note&nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="24%" valign="top">
                                                            <asp:TextBox ID="txtNote_Date" runat="server" Width="170px" SkinID="txtDate" MaxLength="10"></asp:TextBox>
                                                            <%--<img alt="Date of Note" src="../../Images/iconPicDate.gif" align="middle" id="img1" />--%>
                                                        </td>
                                                        <td align="left" width="20%" valign="top">Date Last Modified&nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="24%" valign="top">
                                                            <asp:TextBox ID="txtLast_Modified_date" runat="server" Width="170px" SkinID="txtDate" MaxLength="10"></asp:TextBox>
                                                            <%--<img alt="Date Last Modified" src="../../Images/iconPicDate.gif" align="middle" id="img2" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Notes&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtProjectNotes" ControlType="TextBox" runat="server" />
                                                            <asp:HiddenField ID="hdnPK_Building_Improvement_Notes" runat="server" Value="0" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="center">
                                                            <asp:Button ID="btnSaveNotes" runat="server" Text="Save" OnClick="btnSaveNotes_Click" CausesValidation="false" />
                                                            &nbsp;&nbsp;&nbsp;
                                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="javascript:return CloseNotesPopUp()" />
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
                                                        <td align="left" valign="top" width="20%">Building Number&nbsp;
                                                        </td>
                                                        <td align="center" valign="top" width="2%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4" width="78%">
                                                            <asp:ListBox ID="lstBuildingNumberView" runat="server" SelectionMode="Multiple" Rows="6" Width="600px"></asp:ListBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Project Number&nbsp;
                                                        </td>
                                                        <td align="center" valign="top" width="2%">:
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:Label ID="lblProjectNumber" Width="170px" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Project Start Date &nbsp;
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
                                                            <asp:Label ID="lblNewBuildView" runat="server"></asp:Label>
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
                                                            <asp:Label ID="lblOpenview" runat="server"></asp:Label>
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
                                                            <%--<asp:RadioButtonList runat="server" ID="rdbRevisedSquareFootageView" RepeatDirection="Horizontal" Enabled="false">
                                                                <asp:ListItem Text="Add" Value="Add" />
                                                                <asp:ListItem Text="Reduce" Value="Reduce" />
                                                                <asp:ListItem Text="No Change" Value="No Change" />
                                                            </asp:RadioButtonList>--%>
                                                            <asp:Label ID="lblRevisedSquareFootageView" runat="server"></asp:Label>
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
                                                        <td colspan="6" align="left">
                                                            <b>Tax Information</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <span style="float:left">a.</span>
                                                            <div style="margin-left:40px">
                                                                <span>Does the project result in the replacement of an material major components(i.e. electrical panels, wiring, HVAC), or a substaintial strcutrual part of the property?</span><br />
                                                                <asp:Label runat="server" ID="lblItem_1"></asp:Label>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <span style="float:left">b.</span>
                                                            <div style="margin-left:40px">
                                                                <span>Any interior or exterior lightening upgrades? Describe.   </span><br />
                                                                <asp:Label runat="server" ID="lblItem_2"></asp:Label>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <span style="float:left">c.</span>
                                                            <div style="margin-left:40px">
                                                                <span>Environmental issues (asbestos, USTs, in-ground lifts)? Describe action taken</span><br />
                                                                <asp:Label runat="server" ID="lblItem_3"></asp:Label>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <span style="float:left">d.</span>
                                                            <div style="margin-left:40px">
                                                                <span>Any ADA improvements?</span><br />
                                                                <asp:Label runat="server" ID="lblItem_4"></asp:Label>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <span style="float:left">e.</span>
                                                            <div style="margin-left:40px">
                                                                <span>Any new HVAC units? Specify whether new adds or replacements?</span><br />
                                                                <asp:Label runat="server" ID="lblItem_5"></asp:Label>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <span style="float:left">f.</span>
                                                            <div style="margin-left:40px">
                                                                <span>What area does new or replacement HVAC unit(s) serve?</span><br />
                                                                <asp:Label runat="server" ID="lblItem_6"></asp:Label>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <span style="float:left">g.</span>
                                                            <div style="margin-left:40px">
                                                                <span>How many HVAC units served this area before imporovements?</span><br />
                                                                <asp:Label runat="server" ID="lblNumberOfHavacBeforeImprovements"></asp:Label>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <span style="float:left">h.</span>
                                                            <div style="margin-left:40px">
                                                                <span>How many HVAC units served this area after imporovements?</span><br />
                                                                <asp:Label runat="server" ID="lblNumberOfHavacAfterImprovements"></asp:Label>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <span style="float:left">i.</span>
                                                            <div style="margin-left:40px">
                                                                <span>Were roof improvements made? Specify wheather overlay or replacement and if partial or complete building was touched?</span><br />
                                                                <asp:Label runat="server" ID="lblRoofImprovementDetails"></asp:Label>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <span style="float:left">j.</span>
                                                            <div style="margin-left:40px">
                                                                <span>Any additions or replacements of OH/High Speed doors? Specify</span><br />
                                                                <asp:Label runat="server" ID="lblAdditionalReplace"></asp:Label>
                                                                <asp:HiddenField runat="server" ID="hdnItem_7" />
                                                                <asp:HiddenField runat="server" ID="hdnOtherComments" />
                                                            </div>
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
                                                        <td align="left" valign="top">$&nbsp;<asp:Label ID="lblSubTotal_1" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Subtotal&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:Label ID="lblSubTotal_2" runat="server" />
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
                                                            <asp:GridView ID="gvProjectNotesview" runat="server" GridLines="None" CellPadding="4" CellSpacing="0"
                                                                AutoGenerateColumns="false" Width="100%" EnableTheming="false" AllowSorting="true" OnRowCommand="gvProjectNotesGridview_RowCommand">
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
                                                                            <asp:LinkButton ID="lnkbtnNoteDate" runat="server" CommandName="gvView" CausesValidation="false" CommandArgument='<%# Eval("PK_Building_Improvements_Notes") %>'>
                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Of_Note"))%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Note Text" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lblNotes" runat="server" CommandName="gvView" CausesValidation="false" CommandArgument='<%# Eval("PK_Building_Improvements_Notes") %>' CssClass="TextClip" Width="410px">
                                                                                <%# Eval("Note")%>
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
                                            <asp:Panel ID="pnlNoteGridView" runat="server" Width="100%" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Project Notes
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="20%" valign="top">Date of Note&nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="24%" valign="top">
                                                            <asp:Label ID="lblNote_Date" runat="server"></asp:Label>
                                                            <%--<img alt="Date of Note" src="../../Images/iconPicDate.gif" align="middle" id="img1" />--%>
                                                        </td>
                                                        <td align="left" width="20%" valign="top">Date Last Modified&nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="24%" valign="top">
                                                            <asp:Label ID="lblLast_Modified_date" runat="server"></asp:Label>
                                                            <%--<img alt="Date Last Modified" src="../../Images/iconPicDate.gif" align="middle" id="img2" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Notes&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblProjectNotes" ControlType="Label" runat="server" />
                                                            <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="center">
                                                            <asp:Button ID="btnCancelView" runat="server" Text="Back" OnClientClick="javascript:return CloseNotesPopUpView()" />
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
                                            <asp:Button ID="btnRevertReturn" runat="server" Text="Revert & Return" OnClick="btnRevertReturn_Click" CausesValidation="false" />&nbsp;
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
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CausesValidation="false" />&nbsp;
                                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CausesValidation="false" />&nbsp;
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
