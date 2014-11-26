<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" MasterPageFile="~/Default.master"
    CodeFile="LocationsAddEdit.aspx.cs" Inherits="Admin_LocationsAddEdit" %>

<%@ Register Src="~/Controls/Calender/Calender.ascx" TagName="ctrlCalendar" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_COI/Attachment_COI.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlNotes" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_COI/AttachmentDetails_COI.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Date_Validation.js"></script>

    <script type="text/javascript">

        var currIndex = 1;

        function ShowPrevNext(index) {

            ShowPanel(parseInt(currIndex, 10) + parseInt(index, 10));
        }

        function SetMenuStyle(index) {

            var i;
            for (i = 1; i <= 2; i++) {

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
            var prev = document.getElementById('<%=btnPrev.ClientID%>');
            var next = document.getElementById('<%=btnNext.ClientID%>');
            if (index == 1) {
                prev.disabled = true;
                next.disabled = false;
            }
            else if (index == 2) {
                prev.disabled = false;
                next.disabled = true;
            }
            else {
                prev.disabled = false;
                next.disabled = false;
            }

        }

        function CheckForValidation() {
            if (Page_ClientValidate('vsErrorGroup') == false)
                return false;
            else return true;
        }

        function Navigate_URL(PageName) {
            var strOpr = '<%=Request.QueryString["op"]%>';
            if (strOpr != null && strOpr == "view")
                RedirectToPage(PageName);
            else {
                //var retValue = confirm("Do you want to save the changes?");

                //if (retValue)
                ValidatorEnable(document.getElementById('<%=Attachment.RequiredAttachTypeID%>'), false);
                ValidatorEnable(document.getElementById('<%=Attachment.RequiredAttachFileID%>'), false);
                Page_ClientValidate();
                if (Page_IsValid == true) {
                    __doPostBack('ctl00$ContentPlaceHolder1$btnSave', PageName);
                }
                //else
                //RedirectToPage(PageName);
            }
        }

        function RedirectToPage(PageName) {

            var strQuery = 'loc=<%=Encryption.Encrypt(PK_COI_Locations.ToString())%>&prop=<%=Encryption.Encrypt(FK_Table_Name.ToString())%>';
            var coi = 'coi=<%=Request.QueryString["coi"]%>';
            var op = 'op=<%=Request.QueryString["op"]%>';

            if (op != null && op != '') {
                strQuery = strQuery + '&' + op;
            }

            if (coi != null && coi != '') {
                strQuery = strQuery + '&' + coi;
            }

            if (PageName.indexOf("?") > 0)
                window.location.href = PageName + '&' + strQuery;
            else
                window.location.href = PageName + '?' + strQuery;

        }

        function ConfirmDelete() {
            return confirm("Are you sure that you want to remove the data that was selected for deletion?");
        }

        function EnableDisableGlassValue() {
            var rdoList = document.getElementById('<%=rdoGlassACV.ClientID%>');
            var rdoYes = document.getElementById(rdoList.id + "_0");
            var txt = document.getElementById('<%=txtGlassValue.ClientID%>');
            if (rdoYes.checked) {
                txt.value = "";
                txt.readOnly = true;
            }
            else
                txt.readOnly = false;
        }

        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 2; i++) {
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

            var prev = document.getElementById('<%=btnPrev.ClientID%>');
            var next = document.getElementById('<%=btnNext.ClientID%>');
            if (index == 1) {
                prev.disabled = true;
                next.disabled = false;
            }
            else if (index == 2) {
                prev.disabled = false;
                next.disabled = true;
            }
            else {
                prev.disabled = false;
                next.disabled = false;
            }
        }
        function ValSave() {
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = false;
        }

        function ValAttach() {
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = true;
        }

        function ShowPanel(index) {
            currIndex = index;
            SetMenuStyle(index);
            var i;

            var op = '<%=StrOperation%>';

            if (op == "view") {

                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                ShowPanelView(index);
            }
            else {
                document.getElementById('<%=dvEdit.ClientID%>').style.display = "block";
                document.getElementById('<%=dvSave.ClientID%>').style.display = "block";

                document.getElementById('<%=dvBack.ClientID%>').style.display = "none";
                if (index == 1) {
                    document.getElementById("ctl00_ContentPlaceHolder1_Panel1").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.display = "none";
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                    document.getElementById("<%=txtName.ClientID%>").focus();
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_Panel1").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.display = "block";
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_Attachment_drpAttachType').focus();
                }
            }
        }

        function ShowPanelView(index) {
            SetMenuStyle(index);

            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            document.getElementById('<%=dvSave.ClientID%>').style.display = "none";
            document.getElementById('<%=dvBack.ClientID%>').style.display = "block";
            if (index == 1) {
                document.getElementById("ctl00_ContentPlaceHolder1_Panel2").style.display = "block";
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
            }
            //            else if (index==2)
            //            {
            //                document.getElementById("ctl00_ContentPlaceHolder1_Panel2").style.display="block";
            //                document.getElementById("<%=dvAttachment.ClientID%>").style.display="none"; 
            //            }
            else {

                document.getElementById("ctl00_ContentPlaceHolder1_Panel2").style.display = "none";
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "block";
            }

        }
        function CheckDate() {
            var IsValid = CheckForDates('<%=txtOpenDate.TxtClientID%>', '<%=txtCloseDate.TxtClientID%>');
            alert('0');
            if (IsValid == false) {
                alert("Date Open must be less than the Date Closed");
                return false;
            }
        }
    </script>

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <div style="width: 100%" id="contmain">
        <table cellpadding="0" cellspacing="0" width="100%" align="left">
            <tr>
                <td style="height: 10px;" class="Spacer">
                </td>
            </tr>
            <tr>
                <td class="leftMenu" valign="top" style="padding-left: 10px">
                    <table cellpadding="3" cellspacing="0" width="175px">
                        <tr>
                            <td style="height: 10px;" class="Spacer">
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <span style="font-size: 9pt"><span id="Menu1" onclick="javascript:ShowPanel(1);"
                                    class="LeftMenuStatic">Location</span>&nbsp;<span style="color: Red;">*</span></span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Attachment</span>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 5px;" class="Spacer">
                    &nbsp;
                </td>
                <td valign="top" width="100%">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td class="dvContainer">
                                <div id="dvEdit" runat="server">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td class="tblGrid" align="left">
                                                <asp:Panel ID="Panel1" runat="server" Style="display: block; height: 100%">
                                                    <div class="bandHeaderRow">
                                                        Location</div>
                                                    <div id="dvGeneralEdit" runat="server" style="display: block;">
                                                        <table cellpadding="3" cellspacing="1" width="100%">
                                                            <tr id="lnkFind" runat="server">
                                                                <td colspan="7">
                                                                    <a href="javascript:ShowDialogCOI('Search.aspx?prop=<%=Encryption.Encrypt(FK_Table_Name.ToString())%>&tbl=<%=(int)clsGeneral.Tables.Location%>');">
                                                                        Find</a>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="18%" align="left">
                                                                    Location Name&nbsp;<span class="msg1">*</span>
                                                                </td>
                                                                <td width="2%" align="center">
                                                                    :
                                                                </td>
                                                                <td width="28%" align="left">
                                                                    <asp:TextBox Width="200px" ID="txtName" runat="server" MaxLength="254" TabIndex="1"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Please Enter [Locations]/Location Name"
                                                                        ValidationGroup="vsErrorGroup" ControlToValidate="txtName" Display="none" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td width="2%">
                                                                    &nbsp;
                                                                </td>
                                                                <td width="20%" align="left">
                                                                    Contact Last Name
                                                                </td>
                                                                <td align="center" width="2%">
                                                                    :
                                                                </td>
                                                                <td width="28%" align="left">
                                                                    <asp:TextBox Width="200px" ID="txtContactLastName" runat="server" MaxLength="50"
                                                                        TabIndex="35"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Address 1
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox Width="200px" ID="txtAddress1" runat="server" MaxLength="50" TabIndex="2"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Contact First Name
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox Width="200px" ID="txtContactFirstName" runat="server" MaxLength="50"
                                                                        TabIndex="36"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Address 2
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox Width="200px" ID="txtAddress2" runat="server" MaxLength="50" TabIndex="3"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Contact Title
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox Width="200px" ID="txtContactTitle" runat="server" MaxLength="50" TabIndex="37"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    City
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox Width="200px" ID="txtCity" runat="server" MaxLength="50" TabIndex="4"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Contact Phone
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox Width="200px" ID="txtContactPhone" runat="server" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);"
                                                                        TabIndex="38"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revContactPhone" runat="server" ErrorMessage="Please Enter Valid [Locations]/Contact Phone"
                                                                        ValidationGroup="vsErrorGroup" ControlToValidate="txtContactPhone" ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b"
                                                                        Display="None" SetFocusOnError="true" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    State
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="drpState" runat="server" Width="205px" SkinID="Default" CausesValidation="false"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="drpState_SelectedIndexChanged" TabIndex="5">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Contact Fax
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox Width="200px" ID="txtContactFax" runat="server" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);"
                                                                        TabIndex="39"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revContactFax" runat="server" ErrorMessage="Please Enter Valid [Locations]/Contact Fax"
                                                                        ValidationGroup="vsErrorGroup" Display="None" ControlToValidate="txtContactFax"
                                                                        ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" SetFocusOnError="true" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Zip Code
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox Width="200px" ID="txtZipCode" runat="server" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"
                                                                        TabIndex="6"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revZipCode" runat="server" ErrorMessage="Please Enter Valid [Locations]/Zip Code"
                                                                        ControlToValidate="txtZipCode" ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b"
                                                                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" Display="None" />
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Contact E-Mail
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox Width="200px" ID="txtContactEmail" runat="server" MaxLength="254" TabIndex="40"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please Enter Valid [Locations]/Contact E-Mail"
                                                                        ValidationGroup="vsErrorGroup" ControlToValidate="txtContactEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                        Display="None" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    County
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="drpCounty" runat="server" Width="205px" SkinID="Default" TabIndex="7">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Location Number
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox Width="200px" ID="txtLocationNumber" runat="server" MaxLength="25" TabIndex="41"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Square Footage
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox Width="200px" ID="txtSquareFootage" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,13,false);"
                                                                        TabIndex="8"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Assign Date
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <uc:ctrlCalendar ID="txtAssignDate" runat="server" ErrorMessage="Please Enter [Locations]/Assign Date"
                                                                        RegularExpressionMessage="Please Enter Valid [Locations]/Assign Date" TabIndex="42" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Service Consultant/District Manager
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox Width="200px" ID="txtServiceManager" runat="server" MaxLength="50" TabIndex="9"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Building Type
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox Width="200px" ID="txtBuildingType" runat="server" MaxLength="50" TabIndex="43"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Open Date
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <uc:ctrlCalendar TabIndex="10" ID="txtOpenDate" runat="server" ErrorMessage="Please Enter [Locations]/Open Date"
                                                                        RegularExpressionMessage="Please Enter Valid [Locations]/Open Date" />
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Close Date
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <uc:ctrlCalendar ID="txtCloseDate" runat="server" ErrorMessage="Please Enter [Locations]/Close Date"
                                                                        RegularExpressionMessage="Please Enter Valid [Locations]/Close Date" TabIndex="44" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Region
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="drpRegion" runat="server" Width="205px" SkinID="Default" TabIndex="11">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    District
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="drpDistrict" runat="server" Width="205px" SkinID="Default" TabIndex="45">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Division
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="drpDivision" runat="server" Width="205px" SkinID="Default" TabIndex="12">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Tier
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="drpTier" runat="server" Width="205px" SkinID="Default" TabIndex="46">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Building Value
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:TextBox Width="191px" ID="txtBuildingValue" runat="server" SkinID="DollarFieldBox"
                                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="13"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Equipment Value
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:TextBox Width="191px" ID="txtEquipmentValue" runat="server" SkinID="DollarFieldBox"
                                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="47"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="dvPPEdit" runat="server" style="display: block;">
                                                        <table cellpadding="3" cellspacing="1" width="100%">
                                                            <tr>
                                                                <td width="18%" align="left">
                                                                    Signage Value
                                                                </td>
                                                                <td width="2%" align="center">
                                                                    :
                                                                </td>
                                                                <td width="28%" align="left">
                                                                    $&nbsp;<asp:TextBox Width="191px" ID="txtSignageValue" runat="server" SkinID="DollarFieldBox"
                                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="14"></asp:TextBox>
                                                                </td>
                                                                <td width="2%">
                                                                    &nbsp;
                                                                </td>
                                                                <td width="20%" align="left">
                                                                    Glass - Actual Cash Value
                                                                </td>
                                                                <td align="center" width="2%">
                                                                    :
                                                                </td>
                                                                <td width="28%" align="left">
                                                                    <asp:RadioButtonList ID="rdoGlassACV" runat="server" SkinID="YesNoType" onclick="javascript:EnableDisableGlassValue();"
                                                                        TabIndex="48">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Deductible
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:TextBox Width="191px" ID="txtDeductible" runat="server" SkinID="DollarFieldBox"
                                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="15"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Glass Value
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:TextBox Width="191px" ID="txtGlassValue" runat="server" SkinID="DollarFieldBox"
                                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="49"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Loss of Income - ALS
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:RadioButtonList ID="rdoLossOfIncomeALS" runat="server" SkinID="YesNoType" TabIndex="16">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Loss of Income - Number of Months
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox Width="200px" ID="txtLossOfIncomeMonths" runat="server" MaxLength="4"
                                                                        TabIndex="50" />
                                                                    <asp:RegularExpressionValidator ID="revLossOfIncome" runat="server" ErrorMessage="Please Enter Valid [Locations]/Loss of Income"
                                                                        ValidationGroup="vsErrorGroup" ControlToValidate="txtLossOfIncomeMonths" ValidationExpression="^([0-9]*|\d*\d{1}?\d*)$"
                                                                        Display="None" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Co-Insurance Percentage
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox Width="200px" ID="txtPercentage" runat="server" TabIndex="17"></asp:TextBox>
                                                                    <asp:RangeValidator ID="rvPercentage" runat="server" ErrorMessage="Please Enter Valid [Locations]/Co-Insurance Percentage"
                                                                        ValidationGroup="vsErrorGroup" ControlToValidate="txtPercentage" MinimumValue="0"
                                                                        MaximumValue="100" Type="Double" Display="None" SetFocusOnError="true"></asp:RangeValidator>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Flood
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:TextBox Width="191px" ID="txtFlood" runat="server" SkinID="DollarFieldBox"
                                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="51"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Wind/Hail
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:TextBox Width="191px" ID="txtWindHail" runat="server" SkinID="DollarFieldBox"
                                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="18"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Earth Movement
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:TextBox Width="191px" ID="txtEachMovement" runat="server" SkinID="DollarFieldBox"
                                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="52"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Business Interruption – Each Occurrence
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    $&nbsp;<asp:TextBox Width="191px" ID="txtBIOccurrence" runat="server" SkinID="DollarFieldBox"
                                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="19"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Sign – Each Occurrence
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:TextBox Width="191px" ID="txtSignOccur" runat="server" SkinID="DollarFieldBox"
                                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="53"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Business Interruption – Aggregate
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:TextBox Width="191px" ID="txtBIAggregate" runat="server" SkinID="DollarFieldBox"
                                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="20"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Sign – Aggregate
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:TextBox Width="191px" ID="txtSignAggregate" runat="server" SkinID="DollarFieldBox"
                                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="54"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Building – Each Occurrence
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:TextBox Width="191px" ID="txtBuildingOccur" runat="server" SkinID="DollarFieldBox"
                                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="21"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Equipment – Each Occurrence
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:TextBox Width="191px" ID="txtEuipOccur" runat="server" SkinID="DollarFieldBox"
                                                                        onkeypress="javascript:return FormatNumber(event,this.id,13);" TabIndex="55"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Building – Aggregate
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:TextBox Width="191px" ID="txtBuildingAggregate" runat="server" SkinID="DollarFieldBox"
                                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="22"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Equipment – Aggregate
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:TextBox Width="191px" ID="txtEquipAggregate" runat="server" SkinID="DollarFieldBox"
                                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="56"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Building – Deductible
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:TextBox Width="191px" ID="txtBuildingDeductible" runat="server" SkinID="DollarFieldBox"
                                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="23"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Equipment – Deductible
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:TextBox Width="191px" ID="txtEquipmentDeductible" runat="server" SkinID="DollarFieldBox"
                                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="57"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Glass – Each Occurrence
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:TextBox Width="191px" ID="txtGlassOccur" runat="server" SkinID="DollarFieldBox"
                                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="24"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Glass – Aggregate
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:TextBox Width="191px" ID="txtGlassAggregate" runat="server" SkinID="DollarFieldBox"
                                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="58"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Ordinance or Law
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:RadioButtonList ID="rdoOrdinanceLaw" runat="server" SkinID="YesNoType" TabIndex="25">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Waiver of Subrogation
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:RadioButtonList ID="rdoSubrogationWaiver" runat="server" SkinID="YesNoType"
                                                                        TabIndex="59">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    100% Replacements Cost Values
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:RadioButtonList ID="rdoReplacementCosts" runat="server" SkinID="YesNoType" TabIndex="26">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Perils Insured Special Form
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:RadioButtonList ID="rdoPerilsInsuredForm" runat="server" SkinID="YesNoType"
                                                                        TabIndex="60">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Certificate Received
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:RadioButtonList ID="rdoCertificateReceived" runat="server" SkinID="YesNoType"
                                                                        TabIndex="27">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Evidence of Property on Acord 24, 27 or 28
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:RadioButtonList ID="rdoPropertyOnAcord" runat="server" SkinID="YesNoType" TabIndex="61">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Sprinkler
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:RadioButtonList ID="rdoSprinkler" runat="server" SkinID="YesNoType" TabIndex="28">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Alarm
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:RadioButtonList ID="rdoAlarm" runat="server" SkinID="YesNoType" TabIndex="62">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Earthquake Zone
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:RadioButtonList ID="rdoEarthquakeZone" runat="server" SkinID="YesNoType" TabIndex="29">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Business Interruption Included in Property Verification
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:RadioButtonList ID="rdoBIIncludedInVerification" runat="server" SkinID="YesNoType"
                                                                        TabIndex="63" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Lease Expiration Date - Tenant
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <uc:ctrlCalendar ID="txtLeaseExpirationTenant" runat="server" RegularExpressionMessage="Please Enter Valid [Locations]/Lease Expiration Date-Tenant"
                                                                        TabIndex="30" />
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Date Purchased
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <uc:ctrlCalendar ID="txtDatePurchased" runat="server" RegularExpressionMessage="Please Enter Valid [Locations]/Date Purchased"
                                                                        TabIndex="64" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Lease Expiration Date - SubTenant
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="5">
                                                                    <uc:ctrlCalendar ID="txtLeaseExpirationSubTenant" runat="server" RegularExpressionMessage="Please Enter Valid [Locations]/Lease Expiration Date - SubTenant"
                                                                        TabIndex="31" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Leased Property
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:RadioButtonList ID="rdoLeasedProperty" runat="server" SkinID="YesNoType" TabIndex="32" />
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Date Leased from Landlord
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <uc:ctrlCalendar ID="txtDateLeased" runat="server" RegularExpressionMessage="Please Enter Valid [Locations]/Date Leased from Landlord"
                                                                        TabIndex="65" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Property (Leased Only) Building Limit Accepted
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:RadioButtonList ID="rdoPropertyLimitAccepted" runat="server" SkinID="YesNoType"
                                                                        TabIndex="33" />
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Comments/Notes
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="5" valign="top">
                                                                    <uc:ctrlNotes ID="txtNotes" runat="server" TabIndex="34" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="Div1" runat="server" style="display: none;">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="100%">
                                                <uc:ctrlAttachment ID="Attachment" runat="server" ShowAttachmentType="true" OnbtnHandler="Attachment_btnHandler" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="dvView" runat="server" style="display: none;">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td class="tblGrid" align="left">
                                                <asp:Panel ID="Panel2" runat="server" Style="display: block; height: 100%">
                                                    <div class="bandHeaderRow">
                                                        Locations</div>
                                                    <div id="dvGeneralView" runat="server" style="display: block;">
                                                        <table cellpadding="3" cellspacing="1" width="100%">
                                                            <tr>
                                                                <td width="20%" align="left">
                                                                    Name
                                                                </td>
                                                                <td width="2%" align="center">
                                                                    :
                                                                </td>
                                                                <td width="26%" align="left">
                                                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                                                </td>
                                                                <td width="2%">
                                                                    &nbsp;
                                                                </td>
                                                                <td width="20%" align="left">
                                                                    Contact Last Name
                                                                </td>
                                                                <td width="2%" align="center">
                                                                    :
                                                                </td>
                                                                <td width="26%" align="left">
                                                                    <asp:Label ID="lblContactLastName" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Address 1
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblAddress1" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Contact First Name
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblContactFirstName" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Address 2
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblAddress2" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Contact Title
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblContactTitle" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    City
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblCity" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Contact Phone
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblContactPhone" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    State
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblState" runat="server" Width="205px"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Contact Fax
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblContactFax" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Zip Code
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblZipCode" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Contact E-Mail
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblContactEmail" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    County
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblCountry" runat="server" Width="205px"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Location Number
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblLocationNumber" runat="server" MaxLength="25"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Square Footage
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblSquareFootage" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Assign Date
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblAssignDate" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Service Consultant/District Manager
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblServiceManager" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Building Type
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblBuildingType" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Open Date
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblOpenDate" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Close Date
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblCloseDate" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Region
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblRegion" runat="server" Width="205px"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    District
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblDistrict" runat="server" Width="205px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Division
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblDivision" runat="server" Width="205px"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Tier
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblTier" runat="server" Width="205px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <%--<tr>
                                                            <td align="left" valign="top">Blanket Coverage</td>
                                                            <td align="center" valign="top">:</td>
                                                            <td align="left" colspan="5" valign="top">
                                                                <asp:Label ID="lblBlanketCoverage" runat="server" Width="35%"></asp:Label>
                                                            </td>                                                
                                                        </tr>--%>
                                                            <tr>
                                                                <td align="left">
                                                                    Building Value
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:Label ID="lblBuildingValue" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Equipment Value
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:Label ID="lblEquipmentValue" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="dvPPView" runat="server" style="display: block;">
                                                        <table cellpadding="3" cellspacing="1" width="100%">
                                                            <tr>
                                                                <td align="left">
                                                                    Signage Value
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:Label ID="lblSignageValue" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Glass - Actual Cash Value
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblGlassACV" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="height: 19px">
                                                                    Deductible
                                                                </td>
                                                                <td align="center" style="height: 19px">
                                                                    :
                                                                </td>
                                                                <td align="left" style="height: 19px">
                                                                    $&nbsp;<asp:Label ID="lblDeductible" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="height: 19px">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" style="height: 19px">
                                                                    Glass Value
                                                                </td>
                                                                <td align="center" style="height: 19px">
                                                                    :
                                                                </td>
                                                                <td align="left" style="height: 19px">
                                                                    $&nbsp;<asp:Label ID="lblGlassValue" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Loss of Income - ALS
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblLossOfIncomeALS" runat="server" Width="35%"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Loss of Income - Number of Months
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblLossOfIncomeMonths" runat="server" Width="35%"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Co-Insurance Percentage
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblPercentage" runat="server"></asp:Label>&nbsp%
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Flood
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:Label ID="lblFlood" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Wind/Hail
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:Label ID="lblWindHail" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td width="20%" align="left">
                                                                    Earth Movement
                                                                </td>
                                                                <td width="2%" align="center">
                                                                    :
                                                                </td>
                                                                <td width="26%" align="left">
                                                                    $&nbsp;<asp:Label ID="lblEachMovement" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Business Interruption – Each Occurrence
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    $&nbsp;<asp:Label ID="lblBIOccurrence" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Sign – Each Occurrence
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:Label ID="lblSignOccur" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Business Interruption – Aggregate
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:Label ID="lblBIAggregate" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Sign – Aggregate
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:Label ID="lblSignAggregate" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Building – Each Occurrence
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:Label ID="lblBuildingOccur" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Equipment – Each Occurrence
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:Label ID="lblEuipOccur" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Building – Aggregate
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:Label ID="lblBuildingAggregate" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Equipment – Aggregate
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:Label ID="lblEquipAggregate" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Building – Deductible
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:Label ID="lblBuildingDeductible" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Equipment – Deductible
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:Label ID="lblEquipmentDeductible" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Glass – Each Occurrence
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:Label ID="lblGlassOccur" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Glass – Aggregate
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $&nbsp;<asp:Label ID="lblGlassAggregate" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Ordinance or Law
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblOrdinanceLaw" runat="server" Width="35%"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Waiver of Subrogation
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblSubrogationWaiver" runat="server" Width="35%"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    100% Replacements Cost Values
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblReplacementCosts" runat="server" Width="35%"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Perils Insured Special Form
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblPerilsInsuredForm" runat="server" Width="35%"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Certificate Received
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblCertificateReceived" runat="server" Width="35%"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Evidence of Property on Acord 24, 27 or 28
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblPropertyOnAcord" runat="server" Width="35%"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Sprinkler
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblSprinkler" runat="server" Width="35%"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Alarm
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblAlarm" runat="server" Width="35%"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Earthquake Zone
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblEarthquakeZone" runat="server" Width="35%"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Business Interruption Included in Property Verification
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:Label ID="lblBIIncludedInVerification" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Lease Expiration Date - Tenant
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblLeaseExpirationTenant" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Date Purchased
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblDatePurchased" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Lease Expiration Date - SubTenant
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="5">
                                                                    <asp:Label ID="lblLeaseExpirationSubTenant" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Leased Property
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblLeasedProperty" runat="server" />
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Date Leased from Landlord
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblDateLeased" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Property (Leased Only) Building Limit Accepted
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblPropertyLimitAccepted" runat="server" />
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Comments/Notes
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="5" valign="top">
                                                                                      <uc:ctrlNotes ID="lblNotes" runat="server" ControlType="Label" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <asp:Panel ID="dvAttachment" runat="server" Style="display: none;">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="100%">
                                                <uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" ShowReplaceColumn="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Spacer" style="height: 100px;">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="width: 5px;" class="Spacer">
                    &nbsp;
                </td>
                <td width="100%" class="Spacer" style="height: 6px;">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="width: 5px;" class="Spacer">
                    &nbsp;
                </td>
                <td align="left">
                    <div id="dvSave" runat="server" style="display: none;">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblNote" runat="server" SkinID="MessageOrNote"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="Spacer" style="height: 10px;">
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <input id="btnPrev" runat="server" onclick="javascript:ShowPrevNext(-1);" type="button"
                                        value="Previous" tabindex="65" style="background-position: left top; height: 22px;
                                        background-repeat: no-repeat; border-style: outset; color: Navy; font-weight: bold;
                                        cursor: pointer;" />&nbsp; &nbsp;&nbsp;
                                    <asp:Button ID="btnSave" runat="server" SkinID="Save" CausesValidation="true" OnClick="btnSave_Click"
                                        OnClientClick="return CheckForValidation();" TabIndex="66" />&nbsp;
                                    <asp:Button ID="btnBackToProperty" runat="server" SkinID="revert&return" CausesValidation="false"
                                        OnClick="btnBackToProperty_Click" TabIndex="67" />&nbsp;
                                    <asp:Button ID="btnSaveReturn" runat="server" OnClick="btnSaveReturn_Click" SkinID="save&return"
                                        CausesValidation="true" TabIndex="68" OnClientClick="return CheckForValidation();" />
                                    &nbsp;
                                    <input onblur="javascript:document.getElementById('ctl00_ContentPlaceHolder1_txtName').focus()"
                                        id="btnNext" runat="server" onclick="javascript:ShowPrevNext(1);" type="button"
                                        style="background-position: left top; height: 22px; background-repeat: no-repeat;
                                        border-style: outset; color: Navy; font-weight: bold; cursor: pointer;" value="Next"
                                        tabindex="69" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="dvBack" runat="server" style="display: none;">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td class="Spacer" style="height: 20px;">
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnBack" runat="server" SkinID="Back" OnClick="btnBackToProperty_Click"
                                        CausesValidation="false" />
                                </td>
                            </tr>
                            <tr>
                                <td class="Spacer" style="height: 20px;">
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 25px;">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
