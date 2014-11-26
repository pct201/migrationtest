<%@ Page Title="" Language="C#" MasterPageFile="~/OutlookAddIn/Default.master" AutoEventWireup="true"
    CodeFile="Search.aspx.cs" Inherits="OutlookAddIn_Search" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Validator.js"></script>
    <script language="javascript" type="text/javascript">


        function LogoffApp() {

            if (confirm('Do you want to close this window?'))
                window.location = "../Logoff.aspx?outlook=1";

        }

        function OpenAdjusterNotes() {//pk_claim, attachTable
            alert('Attachment(s) successfully uploaded to selected item.');
            //var Policy = '<=Request.QueryString["pol"] %>';
            //if (Policy != '' && Policy != null) {
            window.location = "../Logoff.aspx?outlook=1";
            //}
            //else
            //    window.location = 'AdjusterNote.aspx?id=' + pk_claim + '&tbl=' + attachTable;
        }

        function RedirectBack() {
            window.location = 'Claim_IncidentSearch.aspx';
        }

        function openWindow(strURL) {
            oWnd = window.open(strURL, "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            //oWnd.moveTo(260,180);
            return false;
        }

        document.body.onkeypress = function () { if (event.keyCode == 13) document.getElementById('<%=btnSearch.ClientID%>').click(); }

        function CheckDates() {
            if (Page_ClientValidate()) {
                var dtStartDate = document.getElementById('<%=txtStartRangeDate.ClientID%>').value;
                var dtEndDate = document.getElementById('<%=txtEndRangeDate.ClientID%>').value;
                if (compareDate(dtStartDate, dtEndDate) == -1) {
                    alert("Start Date must be less than End Date");
                    return false;
                }
                else {
                    return true;
                }
            }
        }

        function CheckUnCheckAll(bChecked) {
            var ctrls = document.getElementsByTagName('input');
            var i;
            var cnt = 0;
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkSelectSingle") > 0) {
                    ctrls[i].checked = bChecked;
                }
            }
        }

        function CheckUnCheckAllExposure(bChecked) {
            var ctrls = document.getElementsByTagName('input');
            var i;
            var cnt = 0;
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkSelectExposureSingle") > 0) {
                    ctrls[i].checked = bChecked;
                }
            }
        }

        function CheckValForFolder() {


            var counter = 0;
            $("#<%=gvAttachments.ClientID%> input[id*='chkSelectSingle']:checkbox").each(function (index) {
                if ($(this).is(':checked'))
                    counter++;
            });
            if (counter === 0) {
                alert('Please select atleast one document to attach.');
                return false;
            }

            var drpFolderEnable = false;
            var FolderNotSelected = false;
            $("#<%=gvAttachments.ClientID %> tr").each(function () {
                var checkBox = $(this).find("input[type='checkbox']");
                var drpFolder = $(this).find("select[id*='drpFolder']");
                if ($(checkBox).is(':checked')) {
                    drpFolderEnable = drpFolder.is(':enabled');
                    if (drpFolderEnable === true) {
                        if ($(drpFolder).val() === "0") {
                            alert("One or more attachments is missing folder to assign. Please select folder for all SELECTED attachments");
                            FolderNotSelected = true;
                            return false;
                        }
                    }
                }
            });


            var drpAttTypeEnable = false;
            var AttachTypeNotSelected = false;
            $("#<%=gvAttachments.ClientID %> tr").each(function () {
                var checkBox = $(this).find("input[type='checkbox']");
                var drpAttachType = $(this).find("select[id*='drpAttachType']");
                if ($(checkBox).is(':checked')) {
                    drpAttTypeEnable = drpAttachType.is(':enabled');
                    if (drpAttTypeEnable === true) {
                        if ($(drpAttachType).val() === "0") {
                            alert("One or more attachments is missing Attachment Type to assign. Please select Attachment Type for all SELECTED attachments");
                            AttachTypeNotSelected = true;
                            return false;
                        }
                    }
                }
            });

            if (IsDuplicateFileRename()) {
                alert("One or more selected attachment is assigned same file name in Rename box. Please provide different names.");
                return false;
            }
            if (FolderNotSelected === true || AttachTypeNotSelected === true)
                return false;
            else
                return true;
        }

        function CheckVal() {
            //            var Policy = '<%=Request.QueryString["pol"] %>';
            //            if (Policy != '' && Policy != null)
            //                return true;
            //            else {
            var grid = document.getElementById('<%= gvAttachments.ClientID %>');
            var ctrls = grid.getElementsByTagName('select');
            var cnt = 0;
            var cntAttType = 0;
            var bdrpFolderEnable = false;
            var bdrpAttTypeEnable = false;

            for (var i = 0; i < ctrls.length; i++) {
                if (ctrls[i].id.indexOf("drpFolder") > 0) {
                    if (ctrls[i].selectedIndex > 0)
                        cnt++;

                    if (ctrls[i].disabled == true)
                        bdrpFolderEnable = false;
                    else
                        bdrpFolderEnable = true;

                }

                if (ctrls[i].id.indexOf("drpAttachType") > 0) {
                    if (ctrls[i].selectedIndex > 0)
                        cntAttType++;

                    if (ctrls[i].disabled == true)
                        bdrpAttTypeEnable = false;
                    else
                        bdrpAttTypeEnable = true;
                }

            }

            var selected = GetSelectedCount();

            if (selected == 0) {
                alert('Please select atleast one document to attach.');
                return false;
            }
            else {
                if (selected > 0 && cnt < selected && bdrpFolderEnable) {
                    alert("One or more attachments is missing folder to assign. Please select folder for all SELECTED attachments");
                    return false;
                }
                else if (selected > 0 && cntAttType < selected && bdrpAttTypeEnable) {
                    alert("One or more attachments is missing Attachment Type to assign. Please select Attachment Type for all SELECTED attachments");
                    return false;
                }
                else {
                    if (IsDuplicateFileRename()) {
                        alert("One or more selected attachment is assigned same file name in Rename box. Please provide different names.");
                        return false;
                    }
                    else {
                        //alert("Your file(s) are being processed.  Please do not close this window until all files have been successfully uploaded.");
                        return true;
                    }
                }
            }
            //}
        }

        function CheckExposureVal() {
            var selected = GetSelectedExposureCount();
            var selected_previuosPage = $("#<%=hdnKeyData.ClientID%>").val();

            if (selected == 0 && selected_previuosPage == 0) {
                alert('Please select atleast one Exposure Data to attach.');
                return false;
            }
            else {
                return true;
            }
        }

        function IsDuplicateFileRename() {
            var grid = document.getElementById('<%=gvAttachments.ClientID%>');
            var ctrls = grid.getElementsByTagName('input');
            var i;
            var cnt = 0;
            var fileNames = new Array();
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkSelectSingle") > 0) {
                    if (ctrls[i].checked) {
                        var txtID = ctrls[i].id.replace("chkSelectSingle", "txtRename");
                        fileNames.push(document.getElementById(txtID).value);
                    }
                }
            }

            var bDuplicate = false;
            for (i = 0; i < fileNames.length; i++) {
                for (j = 0; j < fileNames.length; j++) {
                    if (fileNames[i] != "" && fileNames[i] == fileNames[j] && i != j) {
                        bDuplicate = true;
                        break;
                    }
                }
            }

            return bDuplicate;
        }

        function GetSelectedCount() {
            var ctrls = document.getElementsByTagName('input');
            var i;
            var cnt = 0;
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkSelectSingle") > 0) {
                    if (ctrls[i].checked)
                        cnt++;
                }
            }
            return cnt;
        }

        function GetSelectedExposureCount() {
            var ctrls = document.getElementsByTagName('input');
            var i;
            var cnt = 0;
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkSelectExposureSingle") > 0) {
                    if (ctrls[i].checked)
                        cnt++;
                }
            }
            return cnt;
        }

        function ValidateFileName(txt) {
            var textValue = txt.value;
            if (textValue.startsWith(".") || textValue.endsWith(".")) {
                alert('File name should not start or end with dot(.)');
                txt.focus();
            }
            else {
                if (!CheckInvlaidFileName(textValue)) {
                    txt.focus();
                }
            }
        }


        function CheckInvlaidFileName(textValue) {
            var InvalidArray = new Array("CON", "PRN", "AUX", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9");
            var fileNameText = textValue.substr(0, textValue.lastIndexOf('.'));
            var isValid;


            // declare which special chars to validate
            var illegalChars = ",*/|\":<>?\\";

            //alert(fileNameText);
            for (i = 0; i < InvalidArray.length; i++) {
                if (textValue.toUpperCase().indexOf(InvalidArray[i] + '.') == 0 || textValue.toUpperCase() == InvalidArray[i]) {
                    isValid = 'false';
                    break;
                }
                else {
                    isValid = 'true';
                }
            }

            if (isValid == 'true') {
                for (var i = 0; i < textValue.length; i++) {
                    if (illegalChars.indexOf(textValue.charAt(i)) != -1) {
                        alert("Your file name has one of the following special characters:\n, \\ / * \" : < > ? | \nThese are not allowed.\nPlease remove them and try again.");
                        return false;
                    }
                    else {
                        isValid = 'true';
                    }
                }
            }

            if (isValid == 'true') {
                return true;
            }
            else {
                alert('This file name is reserved for use by Windows. Choose another name and try again.');
                return false;
            }
        }

        function CheckUncheckedAttachments(gvID) {
            var ctrls = document.getElementsByTagName('input');
            var i;
            var cnt = 0;
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkSelectSingle") > 0) {
                    if (ctrls[i].checked)
                        cnt++;
                }
            }

            if (cnt == document.getElementById(gvID).rows.length - 1)
                document.getElementById('chkSelectAll').checked = true;
            else
                document.getElementById('chkSelectAll').checked = false;

        }

        //function CheckUncheckedExposure(gvID) {
        //    var ctrls = document.getElementsByTagName('input');
        //    var i;
        //    var cnt = 0;
        //    for (i = 0; i < ctrls.length; i++) {
        //        if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkSelectExposureSingle") > 0) {
        //            if (ctrls[i].checked)
        //                cnt++;
        //        }
        //    }

        //            if (cnt == document.getElementById(gvID).rows.length - 1)
        //                document.getElementById('chkSelectExposureAll').checked = true;
        //            else
        //                document.getElementById('chkSelectExposureAll').checked = false;

        //}
    </script>
    <div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>

    <asp:UpdatePanel runat="server" ID="UpdSearch">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <asp:Panel runat="server" ID="pnlSearch">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ghc">
                                        <b>Outlook Add-In - Initial Screen</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 20px;"></td>
                                </tr>
                            </table>
                            <br />
                            <br />
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td colspan="2" width="100%">&nbsp;&nbsp;<span class="heading">Exposures Search</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 10px;"></td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="width: 50px;"></td>
                                    <td>
                                        <table cellpadding="3" cellspacing="1" width="100%" border="0">
                                            <tr>
                                                <td align="left" style="width: 16%">Sonic Location Code
                                                </td>
                                                <td align="center" style="width: 4%">:
                                                </td>
                                                <td align="left" style="width: 36%">
                                                    <asp:DropDownList ID="ddlRMLocationNumber" AutoPostBack="true" SkinID="Default" Width="90%"
                                                        runat="server" OnSelectedIndexChanged="ddlRMLocationNumber_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 12%">Date Range Start
                                                </td>
                                                <td align="center" style="width: 4%">:
                                                </td>
                                                <td align="left" style="width: 28%">
                                                    <asp:TextBox ID="txtStartRangeDate" runat="server" SkinID="txtDate"></asp:TextBox>
                                                    <img alt="Range Start Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtStartRangeDate', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                        align="middle" />
                                                    <asp:RangeValidator ID="revStartRangeDate" ControlToValidate="txtStartRangeDate"
                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Range Start Date is not valid."
                                                        runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Legal Entity
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList runat="server" ID="ddlLegalEntity" AutoPostBack="true" SkinID="Default"
                                                        Width="90%" OnSelectedIndexChanged="ddlLegalEntity_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>Date Range End
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtEndRangeDate" runat="server" SkinID="txtDate"></asp:TextBox>
                                                    <img alt="Range End Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEndRangeDate', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                        align="middle" />
                                                    <asp:RangeValidator ID="revDate" ControlToValidate="txtEndRangeDate" MinimumValue="01/01/1753"
                                                        MaximumValue="12/31/9999" Type="Date" ErrorMessage="Range End Date is not valid."
                                                        runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Location d/b/a
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList runat="server" ID="ddlLocationdba" AutoPostBack="true" SkinID="Default"
                                                        Width="90%" OnSelectedIndexChanged="ddlLocationdba_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left">&nbsp;
                                                </td>
                                                <td align="center">&nbsp;
                                                </td>
                                                <td align="left">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Location f/k/a
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList runat="server" ID="ddlLocationfka" AutoPostBack="true" SkinID="Default"
                                                        Width="90%" OnSelectedIndexChanged="ddlLocationfka_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left">&nbsp;
                                                </td>
                                                <td align="center">&nbsp;
                                                </td>
                                                <td align="left">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Main Address
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtMainAddress" runat="server" Width="175px" MaxLength="50" />
                                                </td>
                                                <td align="left">Building Address
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtBuildingAddress" runat="server" Width="175px" MaxLength="50" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Main City
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtMainCity" runat="server" Width="175px" MaxLength="50" />
                                                </td>
                                                <td align="left">Building City
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtBuildingCity" runat="server" Width="175px" MaxLength="50" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Main State
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="drpMainState" runat="server" Width="180px" SkinID="dropGen" />
                                                </td>
                                                <td align="left">Building State
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="drpBuildingState" runat="server" Width="180px" SkinID="dropGen" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Main Zip
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtMainZip" runat="server" Width="175px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                </td>
                                                <td align="left">Building Zip
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtBuildingZip" runat="server" Width="175px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 20px;" colspan="6">&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td align="center" style="height: 24px">
                                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CausesValidation="true" ValidationGroup="vsErrorGroup"
                                                        ToolTip="Search" OnClick="btnSearch_Click" OnClientClick="return CheckDates();" />
                                                    &nbsp;&nbsp;
                                                        <asp:Button ID="btnClear" runat="server" Text="Clear" ToolTip="Search" OnClick="btnClear_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlSearchResult" Visible="false" runat="server">
                            <table cellpadding="0" cellspacing="0" width="98%" align="center">
                                <tr>
                                    <td width="100%" class="Spacer" style="height: 20px;"></td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td width="45%">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td align="left">
                                                                <span class="heading">Exposures Results Grid</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">&nbsp;
                                                                <asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;Found
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td valign="top" align="right">
                                                    <uc:ctrlPaging ID="ctrlPageExposure" runat="server" OnGetPage="GetPage" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 10px;"></td>
                                </tr>
                                <tr>
                                    <td class="groupHeaderBar">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 20px;"></td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="dvGrid" runat="server" style="width: 999px; overflow-x: scroll; overflow-y: hidden">
                                            <asp:HiddenField ID="hdnKeyData" runat="server" Value="0" />
                                            <asp:GridView ID="gvExposure" runat="server" AutoGenerateColumns="false" Width="999px"
                                                AllowSorting="True" GridLines="Both">
                                                <%--OnSorting="gvExposure_Sorting" OnRowCreated="gvExposure_RowCreated" OnRowDataBound="gvExposure_RowDataBound"--%>
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sonic Location Code">
                                                        <ItemStyle HorizontalAlign="Left" Width="50px" Font-Bold="true" />
                                                        <ItemTemplate>
                                                            <%# Eval("Sonic_Location_Code")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sonic Location d/b/a">
                                                        <ItemStyle HorizontalAlign="Left" Width="149px" Font-Bold="true" />
                                                        <ItemTemplate>
                                                            <%#Eval("dba")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Building Occupacy">
                                                        <ItemStyle HorizontalAlign="Left" Width="200px" Font-Bold="true" />
                                                        <ItemTemplate>
                                                            <%#Eval("Building_Occupacy")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Module">
                                                        <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblModule" runat="server" Text='<%#Eval("Module")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Screen">
                                                        <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblScreen" runat="server" Text='<%# Eval("Screen")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Key Data">
                                                        <ItemStyle HorizontalAlign="Left" Width="180px" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKey_Data" runat="server" ToolTip='<%# Eval("Key_Data_Tooltip")%>' Text='<%# Eval("Key_Data")%>'></asp:Label>
                                                            <input type="hidden" id="hdnFk_FldName" runat="server" value='<%#Eval("Fk_Field_Name")%>' />
                                                            <input type="hidden" id="hdnFk_FldValue" runat="server" value='<%#Eval("Fk_Field_Value")%>' />
                                                            <input type="hidden" id="hdnPK_Building_ID" runat="server" value='<%#Eval("PK_Building_ID")%>' />
                                                            <input type="hidden" id="hdn_RowID" runat="server" value='<%#Eval("ID")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderStyle-VerticalAlign="Top"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemStyle Width="20px" />
                                                        <HeaderTemplate>
                                                            <%--<asp:CheckBox ID="chkSelectAll" runat="server" Text="Select" onclick="CheckUnCheckAll(this.checked);" />  --%>
                                                            <%--<input id="chkSelectExposureAll" type="checkbox" onclick="CheckUnCheckAllExposure(this.checked);" />--%>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSelectExposureSingle" runat="server" />
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
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" class="Spacer" style="height: 20px;"></td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td width="100%" align="center">
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" OnClientClick="return CheckExposureVal();"
                                                        ToolTip="Add Location" />
                                                    &nbsp;&nbsp;
                                                    <asp:Button ID="btnSearchAgain" runat="server" Text="Search Again" OnClick="btnSearchAgain_Click"
                                                        ToolTip="Search Again" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 20px;"></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlAttachment" runat="server">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ghc">
                                        <b>Manage Environment Attachments</b>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table cellpadding="1" cellspacing="1" width="100%">
                                <tr>
                                    <td width="100%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <b>&nbsp;&nbsp;<asp:Label ID="lblClaimNumber" runat="server" /><%--Environment Number :--%>
                                        </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:GridView ID="gvAttachments" runat="server" Width="100%" AutoGenerateColumns="false"
                                            EmptyDataText="No Email/Attachment found" OnRowDataBound="gvAttachments_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="7%" HeaderStyle-HorizontalAlign="Left" HeaderStyle-VerticalAlign="Top"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <%--<asp:CheckBox ID="chkSelectAll" runat="server" Text="Select" onclick="CheckUnCheckAll(this.checked);" />--%>
                                                        <input id="chkSelectAll" type="checkbox" onclick="CheckUnCheckAll(this.checked);" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelectSingle" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Document Name" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemStyle HorizontalAlign="Left" Width="13%" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDocName" runat="server" Text='<%# Convert.ToString(Eval("Attachment_Description")) %>' />
                                                        <input type="hidden" id="hdnID" runat="server" value='<%#Eval("PK_Attachment")%>' />
                                                        <input type="hidden" id="hdnFileName" runat="server" value='<%#Eval("Attachment_Name") %>' />
                                                        <input type="hidden" id="hdnOldFolder" runat="server" value='<%#Eval("FK_Virtual_Folder") %>' />
                                                        <input type="hidden" id="hdnType" runat="server" value='<%#Eval("Type") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Attachment Description" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtAttachDesc" runat="server" Width="200px" MaxLength="250" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Rename Document" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtRename" runat="server" Width="200px" onblur="ValidateFileName(this);" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Type">
                                                    <ItemStyle Width="5%" />
                                                    <ItemTemplate>
                                                        <%# Convert.ToString(Eval("Attachment_Name")).Substring(Convert.ToString(Eval("Attachment_Name")).LastIndexOf(".")+ 1).ToUpper()%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Attachment Folder" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="drpFolder" runat="server" Width="155px" SkinID="dropGen" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Attachment Type" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="drpAttachType" runat="server" Width="155px" SkinID="dropGen" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnAttachmentSubmit" runat="server" Text="Submit" OnClick="btnAttachmentSubmit_Click"
                                            OnClientClick="return CheckValForFolder();" />&nbsp;
                                        <asp:Button ID="btnAttachmentCancel" runat="server" Text="Cancel" OnClick="btnAttachmentCancel_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td class="Spacer" style="height: 20px;"></td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
</asp:Content>
