<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="PolicyFeature.aspx.cs"
    Inherits="Policy_PolicyFeature" %>

<%@ Register Src="~/Controls/ClaimAttachment/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/ClaimAttachment/AttachmentDetails.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>
    <link href="../App_Themes/Default/stylecal.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript">

        function checkSelected() {
            var Check = false;
            var arrElements = document.getElementsByTagName('input');
            for (i = 0; i < arrElements.length; i++) {
                if ((arrElements[i].type == 'checkbox') && (arrElements[i].checked == true) && (arrElements[i].name.indexOf('chkItem') > -1)) {
                    Check = true;
                    break;
                }
            }
            if (Check == false) {
                alert('Please check at least one check box to Delete!');
                return false;
            }
            else {
                if (confirm('Are you sure to delete ?'))
                    return true;
                else
                    return false;
            }
        }

        function ValAttach() {
            return true;
        }

        function ValSave() {
            return true;
        }

        function openWindow(strURL) {
            oWnd = window.open(strURL, "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            oWnd.moveTo(260, 180);
            return false;

        }

        function openMailWindow(strURL) {
            //oWnd=window.open("Mail.aspx?AttName="+ strURL,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=0,toolbar=0,width=500,height=280");
            oWnd = window.open(strURL, "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=0,toolbar=0,width=500,height=280");
            oWnd.moveTo(260, 180);
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
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
                    sender.errormessage = msg;
                    args.IsValid = false;
                    document.getElementById(focusCtrlID).focus();
                }
                else
                    args.IsValid = true;
            }
            else {
                args.IsValid = true;
            }
        }
    </script>
    <script type="text/javascript">
        function ErimsUnCheckHeader() {
            var i, flag = 0;
            var chk;
            for (i = 0; i < document.forms[0].elements.length; i++) {
                if ((document.forms[0].elements[i].type == 'checkbox')) {
                    if (document.forms[0].elements[i].name != "ctl00$ContentPlaceHolder1$gvPolicyDetails$ctl01$chkHeader") {

                        if (document.forms[0].elements[i].checked == false)
                        { flag = 1; }
                    }
                }
            }
            for (i = 0; i < document.forms[0].elements.length; i++) {
                if (flag == 1) {
                    if ((document.forms[0].elements[i].type == 'checkbox')) {
                        if (document.forms[0].elements[i].name == "ctl00$ContentPlaceHolder1$gvPolicyDetails$ctl01$chkHeader") {
                            chk = document.forms[0].elements[i];
                            chk.checked = false;
                        }
                    }
                }
                else if (flag == 0) {
                    if ((document.forms[0].elements[i].type == 'checkbox'))
                        if (document.forms[0].elements[i].name == "ctl00$ContentPlaceHolder1$gvPolicyDetails$ctl01$chkHeader")
                            document.forms[0].elements[i].checked = true;
                }
            }
        }
        function MinMax(name) {
            if (name == "Description") {

                if (document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDesc").style.height == "") {
                    document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_ibtnComment").src = "../Images/minus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDesc").style.height = "60px";
                    document.getElementById("pnlComment").style.display = "block";
                }
                else if (document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDesc").style.height == "60px") {

                    document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_ibtnComment").src = "../Images/plus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDesc").style.height = "";
                    document.getElementById("pnlComment").style.display = "none";
                }
            }
            if (name == "Attach") {
                if (document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDescription").style.height == "") {
                    document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_ibtnAttach").src = "../Images/minus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDescription").style.height = "60px";
                    document.getElementById("pnlAttach").style.display = "block";
                }
                else if (document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDescription").style.height == "60px") {
                    document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_ibtnAttach").src = "../Images/plus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDescription").style.height = "";
                    document.getElementById("pnlAttach").style.display = "none";
                }
            }
            return false;


        }
        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("PolicyFeatureAuditPopup.aspx?id=" + '<%=Request.QueryString["PfID"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=0,menubar=0');
            obj.focus();
            return false;
        }
    </script>
    <div style="width: 100%;">
        <div>
            <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
                HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
                EnableClientScript="true" ValidationGroup="vsErrorGroup" CssClass="errormessage">
            </asp:ValidationSummary>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
                ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
                BorderColor="DimGray" EnableClientScript="true" ValidationGroup="AddAttachment"
                CssClass="errormessage"></asp:ValidationSummary>
            <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="true"
                ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
        </div>
        <div style="display: none;">
            <asp:Label ID="lblPolFId" runat="Server"></asp:Label>
        </div>
        <table width="100%">
            <tr>
                <td>
                    <asp:MultiView ID="mvPolicyDetails" runat="server">
                        <asp:View ID="vwVendorDetails" runat="server">
                            <table width="100%">
                                <tr>
                                    <td align="center">
                                        <asp:FormView ID="fvPolicyDetails" runat="server" Width="100%" OnDataBound="fvPolicyDetails_DataBound">
                                            <ItemTemplate>
                                                <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                                                    text-align: left;">
                                                    <tr>
                                                        <td colspan="2">
                                                            <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                                font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                                <tr>
                                                                    <td class="ghc">
                                                                        Policy
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <table width="100%" style="text-align: left;">
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Type
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblPolType" runat="server" Text='<%# Eval("PolicyType") %>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Number
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        <asp:Label ID="lblPolNo" runat="server" Text='<%# Eval("Policy_Number") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Insurance Carrier
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblCarrier" runat="server" Text='<%# Eval("Carrier") %>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Underwriter
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblUnderWriter" runat="server" Text='<%# Eval("Underwriter") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Effective Date
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblDtPolBegin" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Policy_Begin_Date", "{0:MM/dd/yyyy}")%>'>></asp:Label>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Expiration Date
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblDtPolExp" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Policy_Expiration_Date", "{0:MM/dd/yyyy}")%>'>></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Year
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        <asp:Label ID="lblPolYear" runat="server" Text='<%#Eval("Policy_Year")%>'></asp:Label>
                                                                    </td>
                                                                    <td colspan="3">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                                            <tr>
                                                                                <td class="ghc">
                                                                                    Policy Features
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Feature
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblFeature" runat="server" Text='<%#Eval("Feature")%>'>></asp:Label>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                    </td>
                                                                    <td class="lc">
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Limit
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        $<asp:Label ID="lblLimit" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Limit"))%>'>></asp:Label>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Deductible
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        $<asp:Label ID="lblDeductible" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Deductible"))%>'>></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                                            <tr>
                                                                                <td class="ghc">
                                                                                    Notes
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;" valign="top">
                                                                        Notes
                                                                    </td>
                                                                    <td class="lc" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        <asp:Label ID="lblNotes" runat="server" Text='<%#Eval("Notes")%>'></asp:Label>
                                                                    </td>
                                                                    <td colspan="3">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <uc:ctrlAttachmentDetails runat="server" ID="AttachmentDetails" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2">
                                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                                            <asp:Button ID="btnAuditView" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                Visible="true" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <InsertItemTemplate>
                                                <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                                                    text-align: left;">
                                                    <tr>
                                                        <td colspan="2">
                                                            <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                                font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                                <tr>
                                                                    <td class="ghc">
                                                                        Policy
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <table width="100%" style="text-align: left;">
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Type
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblPolType" runat="server" Text='<%# Eval("PolicyType") %>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Number
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        <asp:Label ID="lblPolNo" runat="server" Text='<%# Eval("Policy_Number") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Insurance Carrier
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblCarrier" runat="server" Text='<%# Eval("Carrier") %>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Underwriter
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblUnderWriter" runat="server" Text='<%# Eval("Underwriter") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Effective Date
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblDtPolBegin" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Policy_Begin_Date", "{0:MM/dd/yyyy}")%>'>></asp:Label>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Expiration Date
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblDtPolExp" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Policy_Expiration_Date", "{0:MM/dd/yyyy}")%>'>></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Year
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        <asp:Label ID="lblPolYear" runat="server" Text='<%#Eval("Policy_Year")%>'></asp:Label>
                                                                    </td>
                                                                    <td colspan="3">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                                            <tr>
                                                                                <td class="ghc">
                                                                                    Policy Features
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Feature&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtFeatures" runat="server" MaxLength="50"></asp:TextBox>
                                                                        <%--<asp:RequiredFieldValidator ID="rfvFeature" ControlToValidate="txtFeatures" runat="server"
                                                                            InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Feature."
                                                                            Display="none"></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                    </td>
                                                                    <td class="lc">
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Limit&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        $<asp:TextBox ID="txtLimit" runat="server" onKeyPress="return(currencyFormat(this,',','.',event));"
                                                                            SkinID="txtAmt"></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Deductible&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        $<asp:TextBox ID="txtDeductible" runat="server" SkinID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event));"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                                            <tr>
                                                                                <td class="ghc">
                                                                                    Notes
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;" valign="top">
                                                                        Notes&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td class="lc" style="width: 75%;" colspan="4">
                                                                        <asp:ImageButton ID="ibtnComment" ImageUrl="~/Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMax('Description');" />
                                                                        <div id="pnlComment" style="display: block;">
                                                                            <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Height="60px" Width="88%">  
                                                                            </asp:TextBox>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <uc:ctrlAttachment runat="server" ID="Attachment" OnbtnHandler="btnAddAttachment_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <uc:ctrlAttachmentDetails runat="server" ID="AttachmentDetails" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                                OnClientClick="javascript:ValSave();" OnClick="btnSave_Click" />
                                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </InsertItemTemplate>
                                            <EditItemTemplate>
                                                <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                                                    text-align: left;">
                                                    <tr>
                                                        <td colspan="2">
                                                            <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                                font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                                <tr>
                                                                    <td class="ghc">
                                                                        Policy
                                                                        <asp:Label ID="lblPolicyDetailsId" runat="server" Text='<%#Eval("Pk_Policy_Id")%>'
                                                                            Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <table width="100%" style="text-align: left;">
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Type
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblPolType" runat="server" Text='<%# Eval("PolicyType") %>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Number
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        <asp:Label ID="lblPolNo" runat="server" Text='<%# Eval("Policy_Number") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Insurance Carrier
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblCarrier" runat="server" Text='<%# Eval("Carrier") %>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Underwriter
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblUnderWriter" runat="server" Text='<%# Eval("Underwriter") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Effective Date
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblDtPolBegin" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Policy_Begin_Date", "{0:MM/dd/yyyy}")%>'>></asp:Label>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Expiration Date
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblDtPolExp" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Policy_Expiration_Date", "{0:MM/dd/yyyy}")%>'>></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Year
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        <asp:Label ID="lblPolYear" runat="server" Text='<%#Eval("Policy_Year")%>'></asp:Label>
                                                                    </td>
                                                                    <td colspan="3">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                                            <tr>
                                                                                <td class="ghc">
                                                                                    Policy Features
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Feature&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtFeatures" runat="server" Text='<%#Eval("Feature") %>' MaxLength="50"></asp:TextBox>
                                                                        <%--<asp:RequiredFieldValidator ID="rfvFeature" ControlToValidate="txtFeatures" runat="server"
                                                                            InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Feature."
                                                                            Display="none"></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                    </td>
                                                                    <td class="lc">
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Limit&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        $<asp:TextBox ID="txtLimit" runat="server" SkinID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event));"
                                                                            Text='<%#clsGeneral.GetStringValue(Eval("Limit")) %>'></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Deductible&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        $<asp:TextBox ID="txtDeductible" runat="server" SkinID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event));"
                                                                            Text='<%#clsGeneral.GetStringValue(Eval("Deductible")) %>'></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                                            <tr>
                                                                                <td class="ghc">
                                                                                    Notes
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;" valign="top">
                                                                        Notes&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td class="lc" style="width: 75%;" colspan="4">
                                                                        <asp:ImageButton ID="ibtnComment" ImageUrl="~/Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMax('Description');" />
                                                                        <div id="pnlComment" style="display: block;">
                                                                            <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Height="60px" Width="88%"
                                                                                Text='<%#Eval("Notes") %>'>  
                                                                            </asp:TextBox>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <uc:ctrlAttachment runat="server" ID="Attachment" OnbtnHandler="btnAddAttachment_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <uc:ctrlAttachmentDetails runat="server" ID="AttachmentDetails" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center" class="ic">
                                                            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                                OnClick="btnSave_Click" OnClientClick="javascript:ValSave();" />
                                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                                            <asp:Button ID="btnAuditView" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                Visible="true" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                        </asp:FormView>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                    </asp:MultiView>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="dvAttachDetails" runat="server">
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
