<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="PM_Hearing_Conservation.aspx.cs" Inherits="SONIC_Pollution_PM_Hearing_Conservation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attchment-Occupational/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Pollution/AttachmentDetails_Pollution.ascx"
    TagName="ctrlAttachmentDetails" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/EnviroExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script src="../../JavaScript/jquery-1.5.min.js"></script>
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
                if (index < 3) {
                    for (i = 1; i <= 2; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
                    }

                }
                else {
                    for (i = 1; i <= 2; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = "none";
                    }
                }
                if (index == 2)
                    document.getElementById('ctl00_ContentPlaceHolder1_Attachment_txtAttachDesc_txtNote').focus();
                else
                    document.getElementById('<%=txtDate_Of_Test.ClientID%>').focus();
            }
        }


        function ShowPanelView(index) {
            try {
                SetMenuStyle(index);
                document.getElementById('<%=dvView.ClientID%>').style.display = "block";
                var i;
                if (index < 3) {
                    for (i = 1; i <= 2; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = (i == index) ? "block" : "none";
                    }

                }
                else {
                    for (i = 1; i <= 2; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = "none";
                    }

                }
            }
            catch (e) { }
        }

        function ValSave() {
            if (Page_ClientValidate('vsErrorGroup'))
                return true;
            else
                return false;
        }

        function ValAttach() {
            //            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = true;
            //            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = true;
            if (Page_ClientValidate('vsErrorGroup'))
                return true;
            else
                return false;
        }

        function OpenAuditPopUp() {
            var winHeight = window.screen.availHeight - 400;
            var winWidth = window.screen.availWidth - 500;

            obj = window.open('AuditPopup_PM_Hearing_Conservation.aspx?id=<%=ViewState["PK_PM_Hearing_Conservation"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
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
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                    }
                    //if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
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

      

        $(document).ready(function () {         

                $('#<%= ddlFK_LU_Hearing_Conservation_Test_Type.ClientID%>').on('change', function () {                    
                    var selectedVal = $("#<%= ddlFK_LU_Hearing_Conservation_Test_Type.ClientID%> option:selected").text();                    
                    if (selectedVal == "Noise Level Monitoring")
                    {
                        $('#Location_Exceed_Noise_Level').show();
                        $('#STS_Shift').hide();
                        $('#Retest_Scheduled').hide();
                        $('#<%= txtRested_Date.ClientID%>').val('');
                    }
                    else if (selectedVal == "Audiometric Testing")
                    {
                        $('#Location_Exceed_Noise_Level').hide();
                        $('#STS_Shift').show();
                        $('#Retest_Scheduled').hide();
                        var selectedVal = $("#<%= rdlSTS_Shift.ClientID%>").find('input:checked').val();
                        if (selectedVal == "Y") {
                            $('#Retest_Scheduled').show();                            
                        }
                        else {
                            $('#Retest_Scheduled').hide();
                            $('#<%= txtRested_Date.ClientID%>').val('');
                        }                        
                    }
                    else
                    {
                        $('#Location_Exceed_Noise_Level').hide();
                        $('#STS_Shift').hide();
                        $('#Retest_Scheduled').hide();
                        $('#<%= txtRested_Date.ClientID%>').val('');
                    }
                });
                $('#<%= rdlSTS_Shift.ClientID%>').on('change', function () {
                    var selectedVal = $("#<%= rdlSTS_Shift.ClientID%>").find('input:checked').val();                    
                    if (selectedVal == "Y")
                    {
                        $('#Retest_Scheduled').show();
                    }
                    else
                    {
                        $('#Retest_Scheduled').hide();
                        $('#<%= txtRested_Date.ClientID%>').val('');
                    }                     
                    $('#<%= txtRested_Date.ClientID%>').val('');
                });

                    
            $('#<%= ddlVendorLookup.ClientID%>').on('change', function () {
                var selectedVal = $("#<%= ddlVendorLookup.ClientID%> option:selected").val();  
                if (selectedVal == -1)
                {
                    $('#<%= txtVendor.ClientID%>').val('');
                    $('#<%= txtVendorContactName.ClientID%>').val('');
                    $('#<%= txtVendor_Address.ClientID%>').val('');
                    $('#<%= txtVendor_Zip_Code.ClientID%>').val('');
                    $('#<%= txtVendor_Telephone.ClientID%>').val('');
                    $('#<%= txtVendor_City.ClientID%>').val('');
                    $("#<%= ddlFK_State.ClientID%>").val('0');
                }
                else
                {
                    arr = selectedVal.split('|');                    
                    $('#<%= txtVendor.ClientID%>').val(arr[0]);
                    $('#<%= txtVendorContactName.ClientID%>').val(arr[1]);
                    $('#<%= txtVendor_Address.ClientID%>').val(arr[2]);
                    $('#<%= txtVendor_Zip_Code.ClientID%>').val(arr[3]);
                    $('#<%= txtVendor_Telephone.ClientID%>').val(arr[4]);

                    if (arr[0] == "Examinetics") {
                        $('#<%= txtVendor_City.ClientID%>').val("Overland Park");
                        $("#<%= ddlFK_State.ClientID%>").val("17");
                    }
                    else
                    {
                        $('#<%= txtVendor_City.ClientID%>').val('');
                        $("#<%= ddlFK_State.ClientID%>").val('0');
                    }

                }
                //$('txtVendor').val(arr[0]);
            });

            if ($( '#<%= dvView.ClientID %>').is(':visible')) {
                var selectedVal = $('#<%= lblFK_LU_Hearing_Conservation_Test_Type.ClientID%>').text();                
                if (selectedVal == "Noise Level Monitoring") {
                    $('#trViewLocation_Exceed_Noise_Level').show();
                    $('#trViewSTS_Shift').hide();
                    $('#trViewRetest_Scheduled').hide();
                }
                else if (selectedVal == "Audiometric Testing") {
                    $('#trViewLocation_Exceed_Noise_Level').hide();
                    $('#trViewSTS_Shift').show();
                    $('#trViewRetest_Scheduled').hide();
                }
                else {
                    $('#trViewLocation_Exceed_Noise_Level').hide();
                    $('#trViewSTS_Shift').hide();
                    $('#trViewRetest_Scheduled').hide();
                }

            var selectedVal = $("#<%= lblSTS_Shift.ClientID%>").text();                       
            if (selectedVal == "Yes") {
                $('#trViewRetest_Scheduled').show();
            }
            else {
                $('#trViewRetest_Scheduled').hide();
            }

            }

            var selectedVal = $("#<%= ddlFK_LU_Hearing_Conservation_Test_Type.ClientID%> option:selected").text();
            if (selectedVal == "Noise Level Monitoring") {
                $('#Location_Exceed_Noise_Level').show();
                $('#STS_Shift').hide();
                $('#Retest_Scheduled').hide();
            }
            else if (selectedVal == "Audiometric Testing") {
                $('#Location_Exceed_Noise_Level').hide();
                $('#STS_Shift').show();
                $('#Retest_Scheduled').hide();
                var selectedVal = $("#<%= rdlSTS_Shift.ClientID%>").find('input:checked').val();
                if (selectedVal == "Y") {
                    $('#Retest_Scheduled').show();                    
                }
                else {
                    $('#Retest_Scheduled').hide();
                    $('#<%= txtRested_Date.ClientID%>').val('');
                }                                
            }
            else {
                $('#Location_Exceed_Noise_Level').hide();
                $('#STS_Shift').hide();
                $('#Retest_Scheduled').hide();
                $('#<%= txtRested_Date.ClientID%>').val('');
            }
          

            }           

        );

    </script>


    <asp:ValidationSummary ID="valSummary" runat="server" ValidationGroup="vsErrorGroup"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td class="Spacer" width="100%" style="height: 15px;"></td>
        </tr>
        <tr>
            <td width="100%">
                <uc:ctrlExposureInfo ID="ucCtrlExposureInfo" runat="server" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td class="ghc" align="left">Hearing Conservation
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
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Hearing Conservation</span>&nbsp;<span
                                            id="MenuAsterisk1" runat="server" style="color: Red; display: none">*</span>
                                    </td>
                                </tr>
                               <%-- <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Attachment</span>
                                    </td>
                                </tr>--%>
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
                                                    Hearing Conservation</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                     <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Date of Test&nbsp;<span id="spnDate_Of_Test" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                              <asp:TextBox ID="txtDate_Of_Test" Width="175px" runat="server" SkinID="txtDate">
                                                            </asp:TextBox>
                                                            <img alt="Date Tested" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Of_Test', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Hearing Conservation]/Date Tested is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_Of_Test" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>                                                            
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Associate&nbsp;<span id="spnFK_LU_Employee" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="ddlFK_LU_Employee" runat="server" InitialValue="" ErrorMessage="Please select atleast one city" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Event Type&nbsp;<span id="spnFK_LU_Hearing_Conservation_Test_Type" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="ddlFK_LU_Hearing_Conservation_Test_Type" runat="server" />                                                            
                                                        </td>                                    
                                                        <td colspan="3">&nbsp;
                                                        </td>                    
                                                    </tr>
                                                    <tr id="Location_Exceed_Noise_Level" style="display:none">                                                        
                                                        <td align="left" width="18%" valign="top">
                                                            Did the Location Exceed Noise Levels at the Time of the Test?&nbsp;<span id="spnLocation_Exceed_Noise_Level" style="color: Red; display: inline;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:RadioButtonList ID="rdlLocation_Exceed_Noise_Level" SkinID="YesNoType" runat="server" />
                                                        </td>                                                                                                                 
                                                    </tr>
                                                    <tr id="STS_Shift" style="display:none">
                                                        <td align="left" width="18%" valign="top">
                                                            Did the Test Results Show a Standard Threshold Shift?&nbsp;<span id="spnSTS_Shift" style="color: Red; display: inline;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:RadioButtonList ID="rdlSTS_Shift" SkinID="YesNoType" runat="server"/>
                                                        </td>                                                     
                                                    </tr>
                                                    <tr id="Retest_Scheduled" style="display:none">
                                                        <td align="left" width="18%" valign="top">
                                                            Has a Retest been Scheduled?&nbsp;<span id="spnRetest_Scheduled" style="color: Red; display: inline;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:RadioButtonList ID="rdlRetest_Scheduled" SkinID="YesNoType" runat="server" />
                                                        </td>            
                                                        <td align="left" width="18%" valign="top">
                                                            Date of Retest&nbsp;<span id="spnRested_Date" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>             
                                                        <td align="center" width="4%" valign="top">:</td>                            
                                                        <td align="left" width="28%" valign="top">                                                            
                                                              <asp:TextBox ID="txtRested_Date" Width="175px" runat="server" SkinID="txtDate">
                                                            </asp:TextBox>
                                                            <img alt="Rested Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtRested_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Hearing Conversation]/Rested Date is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtRested_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Notes&nbsp;<span id="spnNotes" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtNotes" runat="server" />
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td align="left" valign="top" width="20%">Building(s)&nbsp;<span id="spnBuilding" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:CheckBoxList ID="chkBuilding" runat="server"  RepeatDirection="Vertical" RepeatLayout="Flow" RepeatColumns="1">                                                                                                                       
                                                            </asp:CheckBoxList>                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Vendor Lookup&nbsp;<span id="spnVendorLookup" style="color: Red; display: none;" runat="server">*</span></td>
                                                        <td align="center" valign="top">:</td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:DropDownList ID="ddlVendorLookup" runat="server" />
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Vendor<span id="spnVendor" style="color: Red; display: none;" runat="server">*</span></td>
                                                        <td align="center" valign="top">:</td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtVendor" MaxLength="75" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Vendor Contact Name<span id="spnVendorContactName" style="color: Red; display: none;" runat="server">*</span></td>
                                                        <td align="center" valign="top">:</td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtVendorContactName" MaxLength="75" runat="server" />
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td align="left" valign="top">Vendor Address<span id="spnVendor_Address" style="color: Red; display: none;" runat="server">*</span></td>
                                                        <td align="center" valign="top">:</td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtVendor_Address" MaxLength="75" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Vendor City<span id="spnVendor_City" style="color: Red; display: none;" runat="server">*</span></td>
                                                        <td align="center" valign="top">:</td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtVendor_City" MaxLength="50" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        
                                                        <td align="left" valign="top">
                                                            State<span id="spnFK_State" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="ddlFK_State" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                         <td align="left" valign="top">
                                                            Zip Code (XXXXX-XXXX)&nbsp;<span id="spnVendor_Zip_Code" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtVendor_Zip_Code" runat="server" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revtxtZipCode" runat="server" ControlToValidate="txtVendor_Zip_Code"
                                                                ErrorMessage="Please Enter [Hearing Conversation]/Zip Code in (XXXXX-XXXX) format." SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup" ValidationExpression="\d{5}(-\d{4})?" Display="None"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>                                                    
                                                    <tr>                                                       
                                                        <td align="left" valign="top">
                                                            Vendor Telephone (XXX-XXX-XXXX)&nbsp;<span id="spnVendor_Telephone" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtVendor_Telephone" runat="server" MaxLength="12" SkinID="txtPhone"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revtxtTelephone" runat="server" ControlToValidate="txtVendor_Telephone"
                                                                ErrorMessage="Please Enter [Hazardous Waste Hauler]/Contact Telephone in (XXX-XXX-XXXX) format." SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"
                                                                Display="None"></asp:RegularExpressionValidator>
                                                        </td>
                                                         <td align="left" valign="top">
                                                            Email&nbsp;<span id="spnVendor_EMail" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtVendor_EMail" runat="server" Width="170px" MaxLength="255" />
                                                        </td>
                                                    </tr>     
                                                    <tr>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                    </tr>
                                                    <tr><td></td></tr>
                                                   <tr>
                                                        <td colspan="6">
                                                            <b>Hearing Conservation Documents</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                             <uc:ctrlAttachment ID="Attachments" runat="server" PanelNumber="1" AttachmentTable="PM_Hearing_Conservation_Attachments"/>
                                                        </td>
                                                    </tr>                                                                                                                                                                  
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2" runat="server" Style="display: none;">
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%">
                                                            <%--<uc:ctrlAttachment ID="Attachment" runat="Server" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 20px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div id="dvAttachment" runat="server" style="display: none;">
                                                                <%--<uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" />--%>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 20px;">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>

                                        <div id="dvView" runat="server" width="794px">
                                             <asp:Panel ID="pnl1View" runat="server" Style="display: none;">
                                                 <div class="bandHeaderRow">
                                                    Hazardous Waste Hauler</div>
                                               <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Date of Test
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                              <asp:Label ID="lblDate_Of_Test" Width="175px" runat="server" SkinID="txtDate">
                                                            </asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Associate
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblFK_LU_Employee" runat="server" />                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Event Type
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblFK_LU_Hearing_Conservation_Test_Type" runat="server" />                                                            
                                                        </td>                                    
                                                        <td colspan="3">&nbsp;
                                                        </td>                    
                                                    </tr>
                                                    <tr id="trViewLocation_Exceed_Noise_Level" style="display:none">                                                        
                                                        <td align="left" width="18%" valign="top">
                                                            Did the Location Exceed Noise Levels at the Time of the Test?
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblLocation_Exceed_Noise_Level" runat="server" />
                                                        </td>                                                                                                                 
                                                    </tr>
                                                    <tr id="trViewSTS_Shift" style="display:none">
                                                        <td align="left" width="18%" valign="top">
                                                            Did the Test Results Show a Standard Threshold Shift?
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblSTS_Shift" runat="server"/>
                                                        </td>                                                     
                                                    </tr>
                                                    <tr id="trViewRetest_Scheduled" style="display:none">
                                                        <td align="left" width="18%" valign="top">
                                                            Has a Retest been Scheduled?
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblRetest_Scheduled" runat="server" />
                                                        </td>            
                                                        <td align="left" width="18%" valign="top">
                                                            Date of Retest
                                                        </td>             
                                                        <td align="center" width="4%" valign="top">:</td>                            
                                                        <td align="left" width="28%" valign="top">                                                            
                                                            <asp:Label ID="lblRested_Date" Width="175px" runat="server" >
                                                            </asp:Label>                                                           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Notes
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblNotes" ControlType="Label" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Building(s)
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:CheckBoxList ID="chkBuildingView" runat="server" Enabled="false" RepeatDirection="Vertical" RepeatLayout="Flow" RepeatColumns="1">
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr style="display:none">
                                                        <td align="left" valign="top">Vendor Lookup</td>
                                                        <td align="center" valign="top">:</td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblVendorLookup" runat="server" />
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Vendor</td>
                                                        <td align="center" valign="top">:</td>
                                                        <td align="left">
                                                            <asp:Label ID="lblVendor" runat="server" Style="word-wrap: normal; word-break: break-all;" />
                                                        </td>
                                                        <td align="left" valign="top">Vendor Contact Name</td>
                                                        <td align="center" valign="top">:</td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblVendor_Representative" Style="word-wrap: normal; word-break: break-all;" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Vendor Address</td>
                                                        <td align="center" valign="top">:</td>
                                                        <td align="left">
                                                            <asp:Label ID="lblVendor_Address" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Vendor City</td>
                                                        <td align="center" valign="top">:</td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblVendor_City" Style="word-wrap: normal; word-break: break-all;" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        
                                                        <td align="left" valign="top">
                                                            State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_Vendor_State" Width="175px" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                         <td align="left" valign="top">
                                                            Zip Code (XXXXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblVendor_Zip_Code" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>                                                    
                                                    <tr>                                                       
                                                        <td align="left" valign="top">
                                                            Vendor Telephone (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblVendor_Telephone" runat="server" ></asp:Label>                                                            
                                                        </td>
                                                         <td align="left" valign="top">
                                                            Email
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblVendor_EMail" Style="word-wrap: normal; word-break: break-all;" runat="server" />
                                                        </td>
                                                    </tr>     
                                                    <tr>
                                                        <td colspan="6">
                                                            <b>Hearing Conservation Documents</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                             <uc:ctrlAttachment ID="AttachmentsView" runat="server"  PanelNumber="1" AttachmentTable="PM_Hearing_Conservation_Attachments"/>
                                                        </td>
                                                    </tr>                                                                                                                                                                   
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2View" runat="server" Style="display: none;">
                                                <div id="Div1" runat="server" style="display: inline;">
                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td width="100%">
                                                                <%--<uc:ctrlAttachmentDetails ID="AttachDetailsView" runat="Server" />--%>
                                                            </td>
                                                        </tr>                                                        
                                                    </table>
                                                </div>                                                
                                            </asp:Panel>
                                        </div>
                                    </td>                               
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td align="center">                           
                        </td>
                    </tr>
                       <tr>
                        <td>&nbsp;
                        </td>
                        <td align="center">
                            <div id="dvSave" runat="server">
                                <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td width="60%" align="right">                                           
                                            <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click"
                                                CausesValidation="true" ValidationGroup="vsErrorGroup" OnClientClick="return ValSave();" />
                                            <asp:Button ID="btnEdit" runat="server" Text=" Edit " OnClick="btnEdit_Click" />
                                            <asp:Button runat="server" ID="btnAuditTrail" Text="View Audit Trail" CausesValidation="false"
                                                Visible="true" OnClientClick="javascript:return OpenAuditPopUp();" />
                                            <asp:Button ID="btnBack" runat="server" Text=" Back " OnClick="btnBack_Click" />
                                        </td>
                                        <td align="left">&nbsp;
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
        <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                    Display="None" ValidationGroup="vsErrorGroup" />
                <input id="hdnControlIDs" runat="server" type="hidden" />
                <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>

