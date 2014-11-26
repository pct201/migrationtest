<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Adjuster.aspx.cs"
    Inherits="Liability_Adjuster" Title="Risk Management Insurance System" Theme="Default" %>

<%@ Register Src="~/Controls/ExcecutiveRiskInfo/ExecutiveRiskInfo.ascx" TagName="ctrlExecRisk"
    TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="false"
            ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
    </div>
    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>
    <link href="../App_Themes/Default/stylecal.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript">

        function MinMax(name) {
            if (name == "note") {
                if (document.getElementById("ctl00_ContentPlaceHolder1_fvAdjustorDetail_txtNote").style.height == "") {
                    document.getElementById("ctl00_ContentPlaceHolder1_fvAdjustorDetail_ibtnNote").src = "../Images/minus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvAdjustorDetail_txtNote").style.height = "100px";
                    document.getElementById("pnlNote").style.display = "block";
                }
                else if (document.getElementById("ctl00_ContentPlaceHolder1_fvAdjustorDetail_txtNote").style.height == "100px") {
                    document.getElementById("ctl00_ContentPlaceHolder1_fvAdjustorDetail_ibtnNote").src = "../Images/plus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvAdjustorDetail_txtNote").style.height = "";
                    document.getElementById("pnlNote").style.display = "none";
                }
            }
            if (name == "attachment") {
                if (document.getElementById("ctl00_ContentPlaceHolder1_fvAdjustorDetail_txtDescription").style.height == "") {
                    document.getElementById("ctl00_ContentPlaceHolder1_fvAdjustorDetail_ibtnAttach").src = "../Images/minus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvAdjustorDetail_txtDescription").style.height = "100px";
                    document.getElementById("pnlAttach").style.display = "block";
                }
                else if (document.getElementById("ctl00_ContentPlaceHolder1_fvAdjustorDetail_txtDescription").style.height == "100px") {
                    document.getElementById("ctl00_ContentPlaceHolder1_fvAdjustorDetail_ibtnAttach").src = "../Images/plus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvAdjustorDetail_txtDescription").style.height = "";
                    document.getElementById("pnlAttach").style.display = "none";
                }
            }
            return false;
        }
        function ValAttach() {
            document.getElementById("ctl00_ContentPlaceHolder1_fvAdjustorDetail_rfvAttachType").enabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_fvAdjustorDetail_rfvUpload").enabled = true;
            return true;
        }
        function ValSave() {
            document.getElementById("ctl00_ContentPlaceHolder1_fvAdjustorDetail_rfvAttachType").enabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_fvAdjustorDetail_rfvUpload").enabled = false;
            return true;
        }
        function displayDetail() {
            document.getElementById("ctl00_ContentPlaceHolder1_divfirst").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_divSearch").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_divthird").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_divbtn").style.display = "none";

            return false;
        }
        function openWindow(strURL) {
            debugger;
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
        function validate() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_fvAdjustorDetail_dwNoteType").value == "0") {
                alert("Please Select Note Type.");
                return false;
            }
            else {
                return true;
            }
        }
        function ValidAttachment() {
            if (validate()) {
                var strError = "";
                if (document.getElementById("ctl00_ContentPlaceHolder1_fvAdjustorDetail_ddlAttachType").value == "--Select Attachment Type--") {
                    strError += "Please Select Attachment Type.\n";
                }
                if (document.getElementById("ctl00_ContentPlaceHolder1_fvAdjustorDetail_uplCommon").value == "") {
                    strError += "Please Select File To Upload.\n";
                }
                if (strError.length > 0) {
                    alert(strError);
                    return false;
                }
                return true;
            }
            else {
                return false;
            }
        }
        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_Adjuster.aspx?id=" + '<%=Session["AdjustorID"]%>' + '&Table_Name=Adjustor_Notes', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
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
    <%-- <asp:UpdatePanel ID="pnlBankDetail" runat="server">
        <contenttemplate>--%>
    <div id="contmain" runat="server" style="width: 100%;">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="Spacer" style="height: 15px;" colspan="2">
                </td>
            </tr>
            <tr>
                <td width="100%" colspan="2">
                    <uc:ctrlExecRisk ID="ExecutiveRiskInfo" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 15px;" colspan="2">
                </td>
            </tr>
            <tr>
                <td id="leftDiv" runat="server" style="width: 203px; font-family: verdana; vertical-align: top;
                    border: solid 1px black;">
                    <table border="0" cellpadding="5" cellspacing="0" width="203px">
                        <tr>
                            <td class="Spacer" style="height: 10px;" colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 15%">
                                &nbsp;
                            </td>
                            <td style="width: 85%" runat="server" id="temp">
                                <asp:LinkButton ID="first" runat="server" CssClass="left_menu_active" OnClick="first_Click"
                                    Text="Claim Details"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:LinkButton ID="second" runat="server" CssClass="left_menu" OnClick="second_Click"
                                    Text="Adjustor Notes"></asp:LinkButton>
                                &nbsp;<span id="MenuAsterisk2" runat="server" style="color: Red; display: none">*</span>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="100%">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td width="5px">
                                &nbsp;
                            </td>
                            <td class="dvContainer">
                                <div id="mainContent" runat="server">
                                    <div id="divfirst" style="width: 100%; display: block;" runat="server">
                                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                            <tr>
                                                <td colspan="6" class="ghc">
                                                    Claim Details
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblMClaimNumber">Claim Number</asp:Label>
                                                </td>
                                                <td width="5%" align="Center" class="lc">
                                                    :
                                                </td>
                                                <td width="25%" align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblClaimNum"></asp:Label>
                                                </td>
                                                <td width="20%" align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblMDOIncident">Date of Incident</asp:Label>
                                                </td>
                                                <td width="5%" align="Center" class="lc">
                                                    :
                                                </td>
                                                <td width="25%" align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblDateIncident"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblMLastName">Name</asp:Label>
                                                </td>
                                                <td width="5%" align="Center" class="lc">
                                                    :
                                                </td>
                                                <td width="25%" align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblLName"></asp:Label>&nbsp;
                                                    <asp:Label runat="server" ID="lblMName"></asp:Label>&nbsp;
                                                    <asp:Label runat="server" ID="lblFName"></asp:Label>
                                                </td>
                                                <td width="20%" align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblMEmployee">Employee</asp:Label>
                                                </td>
                                                <td width="5%" align="Center" class="lc">
                                                    :
                                                </td>
                                                <td width="25%" align="left" class="ic">
                                                    <asp:RadioButtonList ID="rbtnEmployee" runat="server" Enabled="false" RepeatDirection="Horizontal">
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>                                               
                                        </table>
                                    </div>
                                    <div id="divSearch" runat="server" style="display: none;">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 80%;" align="right">
                                                    <table style="width: 60%;">
                                                        <tr>
                                                            <td class="lc">
                                                                Search
                                                            </td>
                                                            <td class="ic">
                                                                <asp:DropDownList ID="ddlSearch" runat="server" SkinID="dropGen">
                                                                    <asp:ListItem Text="Note Type" Value="Note_Type"></asp:ListItem>
                                                                    <asp:ListItem Text="Update By" Value="Update_By"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="ic">
                                                                <asp:TextBox ID="txtSearch" runat="server" MaxLength="20"></asp:TextBox>
                                                            </td>
                                                            <td class="ic">
                                                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 20%;" align="left" class="lc">
                                                    <asp:Label ID="lblBankDetailsTotal" runat="server"></asp:Label>
                                                </td>
                                                <td style="width: 80%;" align="right">
                                                    <table width="75%">
                                                        <tr>
                                                            <td class="lc">
                                                                No. of Records per page :
                                                                <asp:DropDownList ID="ddlPage" SkinID="dropGen" runat="server" DataSourceID="xdsPaging"
                                                                    DataTextField="Text" DataValueField="Value" AutoPostBack="True" OnSelectedIndexChanged="ddlPage_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:XmlDataSource ID="xdsPaging" runat="server" DataFile="~/App_Data/PagingTable.xml">
                                                                </asp:XmlDataSource>
                                                            </td>
                                                            <td class="ic">
                                                                <asp:Button ID="btnPrev" runat="server" OnClick="btnPrev_Click" Text=" < " SkinID="btnGen" />
                                                            </td>
                                                            <td class="lc">
                                                                <asp:Label ID="lblPageInfo" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="ic">
                                                                <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text=" > " SkinID="btnGen" />
                                                            </td>
                                                            <td class="lc">
                                                                Go to Page:
                                                            </td>
                                                            <td class="ic">
                                                                <asp:Panel runat="server" ID="pnl" DefaultButton="btnGo">
                                                                    <asp:TextBox ID="txtPageNo" runat="server" MaxLength="3" Width="20px" onkeypress="return numberOnly(event);"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revPageNumber" runat="server" ErrorMessage="*"
                                                                        ControlToValidate="txtPageNo" Display="dynamic" ValidationExpression="^([0-9]*|\d*\d{1}?\d*)$"
                                                                        ValidationGroup="Paging"></asp:RegularExpressionValidator>
                                                                </asp:Panel>
                                                            </td>
                                                            <td class="ic">
                                                                <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" ValidationGroup="Paging"
                                                                    CausesValidation="true" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="divthird" style="width: 100%; display: none;" runat="server">
                                        <table cellpadding="4" cellspacing="0" style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <asp:MultiView ID="mvAdjustorDetails" runat="server">
                                                        <asp:View ID="vwAdjustorList" runat="server">
                                                            <table style="width: 100%;">
                                                                <tr>
                                                                    <td>
                                                                        <table style="text-align: right; width: 100%;">
                                                                            <tr>
                                                                                <td class="ic">
                                                                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Click here to delete Diary Details"
                                                                                        OnClick="btnDelete_Click" />
                                                                                    <asp:Button ID="btnAddNew" runat="server" Text="Add New" ToolTip="Add new Diary Details"
                                                                                        OnClick="btnAddNew_Click" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left;">
                                                                                    <asp:GridView ID="gvAdjustorDetails" runat="server" AutoGenerateColumns="false" OnRowCommand="gvAdjustorDetails_RowCommand"
                                                                                        DataKeyNames="PK_Adjustor_Notes_ID" Width="100%" OnPageIndexChanging="gvAdjustorDetails_PageIndexChanging"
                                                                                        AllowPaging="True" AllowSorting="True" OnSorting="gvAdjustorDetails_Sorting"
                                                                                        OnRowCreated="gvAdjustorDetails_RowCreated" OnRowDataBound="gvAdjustorDetails_RowDataBound">
                                                                                        <Columns>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <input name="chkItem" type="checkbox" value='<%# Eval("PK_Adjustor_Notes_ID")%>'
                                                                                                        onclick="javascript:UnCheckHeader('gvAdjustorDetails')" />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle Width="10px" />
                                                                                                <HeaderTemplate>
                                                                                                    <input type="checkbox" name="chkHeader" id="chkHeader" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                                                                                </HeaderTemplate>
                                                                                                <HeaderStyle Width="10px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Activity Date" SortExpression="Activity_Date">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Activity_Date", "{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Date Of Note" SortExpression="Date_Of_Note">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblDiary_Date" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Date_Of_Note", "{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField DataField="Author_Of_Note" HeaderText="Author Of Note" SortExpression="Author_Of_Note">
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField HeaderText="Note Type" DataField="Note_Type" SortExpression="Note_Type" />
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_Adjustor_Notes_ID")%>'
                                                                                                        runat="server" Text="Edit" ToolTip="Edit the Adjustor Details" />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("PK_Adjustor_Notes_ID")%>'
                                                                                                        ToolTip="View the Adjustor Details" />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                                        <EmptyDataTemplate>
                                                                                            Currently there is no Adjustor Notes for the following claim.<br />
                                                                                            Please add one or more Adjustor Notes.
                                                                                        </EmptyDataTemplate>
                                                                                        <PagerSettings Visible="False" />
                                                                                    </asp:GridView>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:View>
                                                        <asp:View ID="vwDiaryDetaial" runat="server">
                                                            <table style="width: 100%;">
                                                                <tr>
                                                                    <td>
                                                                        <div>
                                                                            <table cellpadding="2" cellspacing="2" style="width: 100%;">
                                                                                <tr>
                                                                                    <td align="left" colspan="6" class="ghc">
                                                                                        Claim Details
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="20%" align="left" class="lc">
                                                                                        <asp:Label runat="server" ID="lblFClaimNumber">Claim Number</asp:Label>
                                                                                    </td>
                                                                                    <td width="5%" align="Center" class="lc">
                                                                                        :
                                                                                    </td>
                                                                                    <td width="25%" align="left" class="ic">
                                                                                        <asp:Label runat="server" ID="lblClaimNo"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="lc">
                                                                                        <asp:Label runat="server" ID="lblFDOIncident">Date of Incident</asp:Label>
                                                                                    </td>
                                                                                    <td align="Center" class="lc">
                                                                                        :
                                                                                    </td>
                                                                                    <td align="left" class="ic">
                                                                                        <asp:Label runat="server" ID="lblDOIncident"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" class="lc">
                                                                                        <asp:Label runat="server" ID="lblFLastName">Name</asp:Label>
                                                                                    </td>
                                                                                    <td align="Center" class="lc">
                                                                                        :
                                                                                    </td>
                                                                                    <td align="left" class="ic">
                                                                                        <asp:Label runat="server" ID="lblLastName"></asp:Label>&nbsp;
                                                                                        <asp:Label runat="server" ID="lblMiddleName"></asp:Label>&nbsp;
                                                                                        <asp:Label runat="server" ID="lblFirstName"></asp:Label>
                                                                                    </td>
                                                                                    <td width="20%" align="left" class="lc">
                                                                                        <asp:Label runat="server" ID="lblFEmployee">Employee</asp:Label>
                                                                                    </td>
                                                                                    <td width="5%" align="Center" class="lc">
                                                                                        :
                                                                                    </td>
                                                                                    <td width="25%" align="left" class="ic">
                                                                                        <asp:Label runat="server" ID="lblEmployee"></asp:Label>
                                                                                    </td>                                                                                    
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:FormView ID="fvAdjustorDetail" runat="server" OnDataBound="fvAdjustorDetail_DataBound"
                                                                            Width="100%">
                                                                            <ItemTemplate>
                                                                                <div>
                                                                                    <table cellpadding="2" cellspacing="2" width="100%">
                                                                                        <tr>
                                                                                            <td align="left" colspan="6" class="ghc">
                                                                                                Adjustor Note Information
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 20%;" align="left" class="lc">
                                                                                                <asp:Label runat="server" ID="lblDateOfActivity"> Date of Activity</asp:Label>
                                                                                            </td>
                                                                                            <td width="5%" align="Center" class="lc">
                                                                                                :
                                                                                            </td>
                                                                                            <td width="25%" align="left" class="ic">
                                                                                                <asp:Label runat="server" ID="lblDoActivity" Text='<%# DataBinder.Eval(Container.DataItem,"Activity_Date","{0:MM/dd/yyyy}") %>'></asp:Label>
                                                                                            </td>
                                                                                            <td width="20%" align="left" class="lc">
                                                                                                <asp:Label runat="server" ID="lablDate">Date</asp:Label>
                                                                                            </td>
                                                                                            <td width="5%" align="Center" class="lc">
                                                                                                :
                                                                                            </td>
                                                                                            <td width="25%" align="left" class="ic">
                                                                                                <asp:Label runat="server" ID="lblDate" Text='<%# DataBinder.Eval(Container.DataItem,"Date_Of_Note","{0:MM/dd/yyyy}") %>'></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" class="lc">
                                                                                                <asp:Label runat="server" ID="lablAuthor">Author</asp:Label>
                                                                                            </td>
                                                                                            <td align="Center" class="lc">
                                                                                                :
                                                                                            </td>
                                                                                            <td align="left" class="ic">
                                                                                                <asp:Label runat="server" ID="lblAuthor" Text='<%#Eval("Author_Of_Note") %>'></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" class="lc">
                                                                                                <asp:Label runat="server" ID="lablNoteType">Note Type</asp:Label>
                                                                                            </td>
                                                                                            <td align="Center" class="lc">
                                                                                                :
                                                                                            </td>
                                                                                            <td align="left" class="ic">
                                                                                                <asp:Label runat="server" ID="lblNoteType" Text='<%#Eval("Note_Type") %>'></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" class="lc">
                                                                                                <asp:Label runat="server" ID="lablLastUpdate">Last Updated By</asp:Label>
                                                                                            </td>
                                                                                            <td align="Center" class="lc">
                                                                                                :
                                                                                            </td>
                                                                                            <td align="left" class="ic" colspan="4">
                                                                                                <asp:Label runat="server" ID="lblUpdateBy" Text='<%#Eval("Update_By") %>'></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" class="lc">
                                                                                                <asp:Label runat="server" ID="lablNotes">Notes</asp:Label>
                                                                                            </td>
                                                                                            <td align="Center" class="lc">
                                                                                                :
                                                                                            </td>
                                                                                            <td align="left" class="ic" colspan="4">
                                                                                                <asp:Label runat="server" ID="lblNote" Text='<%#Eval("Notes") %>'></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6" align="center">
                                                                                                <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click"
                                                                                                    Enabled="false" />
                                                                                                <asp:Button ID="btnBack" runat="server" Text="Cancel" OnClick="btnBack_Click" CausesValidation="false" />
                                                                                                <asp:Button ID="btnViewAudit" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <div>
                                                                                    <table cellpadding="2" cellspacing="2" width="100%">
                                                                                        <tr>
                                                                                            <td align="left" colspan="6" class="ghc">
                                                                                                Adjustor Note Information
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style="display: none;">
                                                                                            <td>
                                                                                                <asp:Label runat="server" ID="lblAdjustorID" Visible="false" Text='<%#Eval("PK_Adjustor_Notes_ID") %>'></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 20%;" align="left" class="lc">
                                                                                                <asp:Label runat="server" ID="lblDateOfActivity"> Date of Activity</asp:Label>
                                                                                                &nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td width="5%" align="Center" class="lc">
                                                                                                :
                                                                                            </td>
                                                                                            <td width="25%" align="left" class="ic">
                                                                                                <asp:TextBox runat="server" ID="txtDOActivity" Text='<%#DataBinder.Eval(Container.DataItem,"Activity_Date","{0:MM/dd/yyyy}") %>'></asp:TextBox>
                                                                                                <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvAdjustorDetail_txtDOActivity', 'mm/dd/y');"
                                                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                                                    align="absmiddle" /><br />
                                                                                                <cc1:MaskedEditExtender ID="mskDOActivity" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                                                    Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtDOActivity" CultureName="en-US"
                                                                                                    AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                                                </cc1:MaskedEditExtender>
                                                                                                <cc1:MaskedEditValidator ID="mskValDtStart" runat="server" ControlExtender="mskDOActivity"
                                                                                                    ControlToValidate="txtDOActivity" Display="none" IsValidEmpty="True" MaximumValue=""
                                                                                                    InvalidValueMessage="Ivalid Date" MaximumValueMessage="" MinimumValueMessage=""
                                                                                                    TooltipMessage="" MinimumValue="">
                                                                                                </cc1:MaskedEditValidator>
                                                                                                <asp:RegularExpressionValidator ID="revDOActivity" runat="server" ControlToValidate="txtDOActivity"
                                                                                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                                                    ErrorMessage="[Adjustor Notes]/Date of Activity is Not Valid." Display="none"
                                                                                                    ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                            <td width="20%" align="left" class="lc">
                                                                                                <asp:Label runat="server" ID="lablDate">Date</asp:Label>&nbsp; <span id="Span2" style="color: Red;
                                                                                                    display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td width="5%" align="Center" class="lc">
                                                                                                :
                                                                                            </td>
                                                                                            <td width="25%" align="left" class="ic">
                                                                                                <asp:TextBox runat="server" ID="txtDate" Text='<%#DataBinder.Eval(Container.DataItem,"Date_Of_Note","{0:MM/dd/yyyy}") %>'></asp:TextBox>
                                                                                                <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvAdjustorDetail_txtDate', 'mm/dd/y');"
                                                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                                                    align="absmiddle" /><br />
                                                                                                <cc1:MaskedEditExtender ID="mskDate" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                                                    Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtDate" CultureName="en-US"
                                                                                                    AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                                                </cc1:MaskedEditExtender>
                                                                                                <cc1:MaskedEditValidator ID="mskVDate" runat="server" ControlExtender="mskDate" ControlToValidate="txtDate"
                                                                                                    Display="none" IsValidEmpty="True" MaximumValue="" InvalidValueMessage="Invalid Date"
                                                                                                    MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                                                                                                </cc1:MaskedEditValidator>
                                                                                                <asp:RegularExpressionValidator ID="revDate" runat="server" ControlToValidate="txtDate"
                                                                                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                                                    ErrorMessage="[Adjustor Notes]/Date Not Valid." Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" class="lc">
                                                                                                <asp:Label runat="server" ID="lablAuthor">Author</asp:Label>
                                                                                                &nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="Center" class="lc">
                                                                                                :
                                                                                            </td>
                                                                                            <td align="left" class="ic">
                                                                                                <asp:TextBox MaxLength="30" runat="server" ID="txtAuthor" Text='<%#Eval("Author_Of_Note") %>'></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAuthor"
                                                                                                    Display="none" Text="*" ErrorMessage="Please Enter [Adjustor Notes]/Author."
                                                                                                    ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                                                            </td>
                                                                                            <td align="left" class="lc">
                                                                                                <asp:Label runat="server" ID="lablNoteType">Note Type</asp:Label>
                                                                                                &nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="Center" class="lc">
                                                                                                :
                                                                                            </td>
                                                                                            <td align="left" class="ic">
                                                                                                <asp:DropDownList ID="dwNoteType" runat="server">
                                                                                                    <%--<asp:ListItem Selected="True" Value="0" Text="--Select Note Type--"></asp:ListItem>
                                                                                        <asp:ListItem Value="1" Text="Action Plan"></asp:ListItem>
                                                                                        <asp:ListItem Value="2" Text="Claims Administrator"></asp:ListItem>
                                                                                        <asp:ListItem Value="3" Text="Legal"></asp:ListItem>--%>
                                                                                                </asp:DropDownList>
                                                                                                <%--<asp:RequiredFieldValidator ID="rfvNoteType" runat="server" ControlToValidate="dwNoteType"
                                                                                        InitialValue="--Select Note Type--" Display="none" Text="*" ErrorMessage="Please Select [Adjustor Notes]/Note Type."
                                                                                        ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>--%>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" class="lc">
                                                                                                <asp:Label runat="server" ID="lablLastUpdate">Last Updated By</asp:Label>
                                                                                                &nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="Center" class="lc">
                                                                                                :
                                                                                            </td>
                                                                                            <td align="left" class="ic" colspan="4">
                                                                                                <asp:TextBox runat="server" ID="txtLastUpdateBy" MaxLength="30" Text='<%#Eval("Update_By") %>'></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" class="lc" valign="top">
                                                                                                <asp:Label runat="server" ID="lablNotes">Notes</asp:Label>
                                                                                                &nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="Center" class="lc" valign="top">
                                                                                                :
                                                                                            </td>
                                                                                            <td align="left" class="ic" colspan="4" valign="top">
                                                                                                <asp:ImageButton ID="ibtnNote" ImageUrl="~/Images/Minus.jpg" runat="server" OnClientClick="javascript:return MinMax('note');" />
                                                                                                <div id="pnlNote" style="display: block;">
                                                                                                    <asp:TextBox runat="server" ID="txtNote" MaxLength="2000" Height="100px" TextMode="MultiLine"
                                                                                                        Width="93.5%" Text='<%#Eval("Notes") %>'></asp:TextBox>
                                                                                                </div>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                                <div style="width: 100%;" id="divAttachment">
                                                                                    <table cellpadding="2" cellspacing="2" class="stylesheet" width="100%">
                                                                                        <tr>
                                                                                            <td class="ghc" colspan="6">
                                                                                                Attachment
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style="display: none;">
                                                                                            <td class="lc" style="width: 20%" valign="top">
                                                                                                Attachment Type
                                                                                            </td>
                                                                                            <td align="center" valign="top" class="lc">
                                                                                                :
                                                                                            </td>
                                                                                            <td class="ic" colspan="4" valign="top">
                                                                                                <asp:DropDownList runat="server" SkinID="dropGen" ID="ddlAttachType">
                                                                                                </asp:DropDownList>
                                                                                                <asp:RequiredFieldValidator ID="rfvAttachType" ControlToValidate="ddlAttachType"
                                                                                                    runat="server" InitialValue="--Select Attachment Type--" ValidationGroup="vsErrorGroup"
                                                                                                    ErrorMessage="Please Select the Attachment Type." Display="none" Text="*"></asp:RequiredFieldValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="lc" valign="top" style="width: 20%">
                                                                                                Attachment Description
                                                                                            </td>
                                                                                            <td align="center" class="lc" valign="top">
                                                                                                :
                                                                                            </td>
                                                                                            <td colspan="4" class="ic" valign="top" style="width: 80%">
                                                                                                <asp:ImageButton ID="ibtnAttach" ImageUrl="~/Images/Minus.jpg" runat="server" OnClientClick="javascript:return MinMax('attachment');" />
                                                                                                <div id="pnlAttach" style="display: block;">
                                                                                                    <asp:TextBox ID="txtDescription" runat="server" MaxLength="2000" Height="100px" TextMode="MultiLine"
                                                                                                        Width="93.5%"></asp:TextBox>
                                                                                                </div>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="lc" valign="top">
                                                                                                Select File
                                                                                            </td>
                                                                                            <td class="lc" align="center" valign="top">
                                                                                                :
                                                                                            </td>
                                                                                            <td colspan="4" class="ic" valign="top">
                                                                                                <asp:FileUpload runat="server" ID="uplCommon" />
                                                                                                <asp:RequiredFieldValidator ID="rfvUpload" runat="server" ControlToValidate="uplCommon"
                                                                                                    InitialValue="" Display="none" Text="*" ErrorMessage="Please Select [Adjustor Notes]/File to Upload."
                                                                                                    ValidationGroup="vsErrorGroup">                                                                        
                                                                                                </asp:RequiredFieldValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="ic">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                            <td>
                                                                                                &nbsp;
                                                                                            </td>
                                                                                            <td colspan="4">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td class="ic" align="center">
                                                                                                <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" OnClientClick="javascript:ValAttach();"
                                                                                                    OnClick="btnAddAttachment_Click" ValidationGroup="vsErrorGroup" />
                                                                                                <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click"
                                                                                                    OnClientClick="javascript:ValSave();" ValidationGroup="vsErrorGroup" />
                                                                                                <asp:Button ID="btnBack" runat="server" Text="Cancel" OnClick="btnBack_Click" CausesValidation="false" />
                                                                                                <asp:Button ID="btnViewAudit" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </EditItemTemplate>
                                                                            <InsertItemTemplate>
                                                                                <div>
                                                                                    <table cellpadding="2" cellspacing="2" width="100%">
                                                                                        <tr>
                                                                                            <td align="left" colspan="6" class="ghc">
                                                                                                Adjustor Note Information
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 20%;" align="left" class="lc">
                                                                                                <asp:Label runat="server" ID="lblDateOfActivity"> Date of Activity</asp:Label>
                                                                                                &nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td width="5%" align="Center" class="lc">
                                                                                                :
                                                                                            </td>
                                                                                            <td width="25%" align="left" class="ic">
                                                                                                <asp:TextBox runat="server" ID="txtDOActivity"></asp:TextBox>
                                                                                                <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvAdjustorDetail_txtDOActivity', 'mm/dd/y');"
                                                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                                                    align="absmiddle" /><br />
                                                                                                <cc1:MaskedEditExtender ID="mskEDOActivity" runat="server" AcceptNegative="Left"
                                                                                                    DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                                                    OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDOActivity"
                                                                                                    CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                                                </cc1:MaskedEditExtender>
                                                                                                <cc1:MaskedEditValidator ID="mskVEDOActivity" runat="server" ControlExtender="mskEDOActivity"
                                                                                                    ControlToValidate="txtDOActivity" Display="none" IsValidEmpty="True" MaximumValue=""
                                                                                                    InvalidValueMessage="Date is invalid" MaximumValueMessage="" MinimumValueMessage=""
                                                                                                    TooltipMessage="" MinimumValue="">
                                                                                                </cc1:MaskedEditValidator>
                                                                                                <asp:RegularExpressionValidator ID="revDOActivity" runat="server" ControlToValidate="txtDOActivity"
                                                                                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                                                    ErrorMessage="[Adjustor Notes]/Date of Activity is Not Valid." Display="none"
                                                                                                    ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                            <td width="20%" align="left" class="lc">
                                                                                                <asp:Label runat="server" ID="lablDate">Date</asp:Label>
                                                                                                &nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td width="5%" align="Center" class="lc">
                                                                                                :
                                                                                            </td>
                                                                                            <td width="25%" align="left" class="ic">
                                                                                                <asp:TextBox runat="server" ID="txtDate"></asp:TextBox>
                                                                                                <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvAdjustorDetail_txtDate', 'mm/dd/y');"
                                                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                                                    align="absmiddle" /><br />
                                                                                                <cc1:MaskedEditExtender ID="mskEDate" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                                                    Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtDate" CultureName="en-US"
                                                                                                    AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                                                </cc1:MaskedEditExtender>
                                                                                                <cc1:MaskedEditValidator ID="mskVDate" runat="server" ControlExtender="mskEDate"
                                                                                                    ControlToValidate="txtDate" Display="none" IsValidEmpty="True" MaximumValue=""
                                                                                                    InvalidValueMessage="Date is invalid" MaximumValueMessage="" MinimumValueMessage=""
                                                                                                    TooltipMessage="" MinimumValue="">
                                                                                                </cc1:MaskedEditValidator>
                                                                                                <asp:RegularExpressionValidator ID="revDate" runat="server" ControlToValidate="txtDate"
                                                                                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                                                    ErrorMessage="[Adjustor Notes]/Date Not Valid." Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" class="lc">
                                                                                                <asp:Label runat="server" ID="lablAuthor">Author</asp:Label>
                                                                                                &nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="Center" class="lc">
                                                                                                :
                                                                                            </td>
                                                                                            <td align="left" class="ic">
                                                                                                <asp:TextBox runat="server" MaxLength="30" ID="txtAuthor"></asp:TextBox>
                                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAuthor"
                                                                                         Display="none" Text="*" ErrorMessage="Please Enter Author"
                                                                                        ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>--%>
                                                                                            </td>
                                                                                            <td align="left" class="lc">
                                                                                                <asp:Label runat="server" ID="lablNoteType">Note Type</asp:Label>
                                                                                                &nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="Center" class="lc">
                                                                                                :
                                                                                            </td>
                                                                                            <td align="left" class="ic">
                                                                                                <asp:DropDownList ID="dwNoteType" runat="server">
                                                                                                    <%-- <asp:ListItem Selected="True" Value="0" Text="--Select Note Type--"></asp:ListItem>
                                                                                        <asp:ListItem Value="1" Text="Action Plan"></asp:ListItem>
                                                                                        <asp:ListItem Value="2" Text="Claims Administrator"></asp:ListItem>
                                                                                        <asp:ListItem Value="3" Text="Legal"></asp:ListItem>--%>
                                                                                                </asp:DropDownList>
                                                                                                <%--<asp:RequiredFieldValidator ID="rfvNoteType" runat="server" ControlToValidate="dwNoteType"
                                                                                        InitialValue="--Select Note Type--" Display="none" Text="*" ErrorMessage="Please Select Note Type"
                                                                                        ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>--%>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" class="lc">
                                                                                                <asp:Label runat="server" ID="lablLastUpdate">Last Updated By</asp:Label>
                                                                                                &nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="Center" class="lc">
                                                                                                :
                                                                                            </td>
                                                                                            <td align="left" class="ic" colspan="4">
                                                                                                <asp:TextBox runat="server" MaxLength="30" ID="txtLastUpdateBy"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" class="lc" valign="top">
                                                                                                <asp:Label runat="server" ID="lablNotes">Notes</asp:Label>
                                                                                                &nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                                                            </td>
                                                                                            <td align="Center" class="lc" valign="top">
                                                                                                :
                                                                                            </td>
                                                                                            <td align="left" class="ic" colspan="4" valign="top">
                                                                                                <asp:ImageButton ID="ibtnNote" ImageUrl="~/Images/Minus.jpg" runat="server" OnClientClick="javascript:return MinMax('note');" />
                                                                                                <div id="pnlNote" style="display: block;">
                                                                                                    <asp:TextBox runat="server" ID="txtNote" MaxLength="2000" TextMode="MultiLine" Height="100px"
                                                                                                        Width="93.5%"></asp:TextBox>
                                                                                                </div>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                                <div style="width: 100%;" id="divAttachment">
                                                                                    <table cellpadding="2" cellspacing="0" class="stylesheet" width="100%">
                                                                                        <tr>
                                                                                            <td class="ghc" colspan="6">
                                                                                                Attachment
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style="display: none;">
                                                                                            <td class="lc" style="width: 20%;" valign="top">
                                                                                                Attachment Type
                                                                                            </td>
                                                                                            <td align="center" valign="top" class="lc">
                                                                                                :
                                                                                            </td>
                                                                                            <td class="ic" colspan="4" valign="top">
                                                                                                <asp:DropDownList runat="server" SkinID="dropGen" ID="ddlAttachType" ValidationGroup="vsErrorGroup">
                                                                                                </asp:DropDownList>
                                                                                                <asp:RequiredFieldValidator ID="rfvAttachType" ControlToValidate="ddlAttachType"
                                                                                                    runat="server" InitialValue="--Select Attachment Type--" ValidationGroup="vsErrorGroup"
                                                                                                    ErrorMessage="Please Select the Attachment Type." Display="none" Text="*"></asp:RequiredFieldValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="lc" valign="top" style="width: 22%">
                                                                                                Attachment Description
                                                                                            </td>
                                                                                            <td align="center" valign="top" class="lc">
                                                                                                :
                                                                                            </td>
                                                                                            <td colspan="4" class="ic" valign="top" style="width: 78%">
                                                                                                <asp:ImageButton ID="ibtnAttach" ImageUrl="~/Images/Minus.jpg" runat="server" OnClientClick="javascript:return MinMax('attachment');" />
                                                                                                <div id="pnlAttach" style="display: block;">
                                                                                                    <asp:TextBox ID="txtDescription" runat="server" Height="100px" MaxLength="4000" TextMode="MultiLine"
                                                                                                        Width="93.5%"></asp:TextBox>
                                                                                                </div>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="lc">
                                                                                                Select File
                                                                                            </td>
                                                                                            <td class="lc" align="center">
                                                                                                :
                                                                                            </td>
                                                                                            <td colspan="4" class="ic">
                                                                                                <asp:FileUpload runat="server" ID="uplCommon" ValidationGroup="vsErrorGroup" />
                                                                                                <asp:RequiredFieldValidator ID="rfvUpload" runat="server" ControlToValidate="uplCommon"
                                                                                                    InitialValue="" Display="none" Text="*" ErrorMessage="Please Select File to Upload."
                                                                                                    ValidationGroup="vsErrorGroup">                                                                        
                                                                                                </asp:RequiredFieldValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="ic">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                            <td>
                                                                                                &nbsp;
                                                                                            </td>
                                                                                            <td colspan="4">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td class="ic" align="center">
                                                                                                <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" ValidationGroup="vsErrorGroup"
                                                                                                    OnClientClick="javascript:ValAttach();" OnClick="btnAddAttachment_Click" />
                                                                                                <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click"
                                                                                                    ValidationGroup="vsErrorGroup" OnClientClick="javascript:ValSave();" />
                                                                                                <asp:Button ID="btnBack" runat="server" Text="Cancel" OnClick="btnBack_Click" CausesValidation="false" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </InsertItemTemplate>
                                                                        </asp:FormView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div id="dvAttachDetails" runat="server" style="display: none;">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                                                                            <tr>
                                                                                                <td class="ghc">
                                                                                                    Attachment Details
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <asp:GridView ID="gvAttachmentDetails" runat="server" AutoGenerateColumns="false"
                                                                                            DataKeyNames="PK_Attachment_ID" Width="100%" AllowPaging="True" AllowSorting="True"
                                                                                            OnRowDataBound="gvAttachmentDetails_RowDataBound">
                                                                                            <Columns>
                                                                                                <asp:TemplateField>
                                                                                                    <ItemTemplate>
                                                                                                        <input name="chkItem" type="checkbox" value='<%# Eval("PK_Attachment_ID")%>' onclick="javascript:UnCheckHeader('gvAttachmentDetails')" />
                                                                                                    </ItemTemplate>
                                                                                                    <ItemStyle Width="10px" />
                                                                                                    <HeaderTemplate>
                                                                                                        <input type="checkbox" name="chkHeader" id="chkHeader" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                                                                                    </HeaderTemplate>
                                                                                                    <HeaderStyle Width="10px" />
                                                                                                </asp:TemplateField>
                                                                                                <asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" Visible="false">
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description">
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="Attachment_Name1" HeaderText="File Name"></asp:BoundField>
                                                                                                <asp:TemplateField HeaderText="View">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:ImageButton ID="imgbtnDwnld" CommandName="Download" CommandArgument='<%# Eval("Attachment_Name")%>'
                                                                                                            runat="server" ImageAlign="Left" ImageUrl="~/Images/download.gif" />
                                                                                                    </ItemTemplate>
                                                                                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                                                </asp:TemplateField>
                                                                                                <%-- <asp:TemplateField HeaderText="Mail">
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="imgbtnMail" CommandName="Mail" CommandArgument='<%# Eval("Attachment_Name")%>'
                                                                                                runat="server" ImageUrl="~/Images/emailicon.gif" ImageAlign="Left" />
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                                    </asp:TemplateField>--%>
                                                                                            </Columns>
                                                                                            <EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
                                                                                            <EmptyDataTemplate>
                                                                                                Currently there is no Attachment.<br />
                                                                                                Please Add one or more.
                                                                                            </EmptyDataTemplate>
                                                                                            <PagerSettings Visible="False" />
                                                                                            <PagerSettings Visible="False" />
                                                                                        </asp:GridView>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />
                                                                                        <asp:Button ID="btnMail" runat="server" Text="Mail" OnClientClick="javascript:return OpenWMail('gvAttachmentDetails','Liability_Adjustor_Notes');" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:View>
                                                    </asp:MultiView>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div id="divbtn" runat="server">
        <table style="width: 100%;">
            <tr>
                <td align="center" class="ic">
                    <asp:Button runat="server" ID="btnViewAll" EnableTheming="false" SkinID="btnGen"
                        Text="View All" OnClick="btnViewAll_Click" />
                    <asp:Button runat="server" ID="btnNextStep" SkinID="btnGen" EnableTheming="false"
                        Visible="true" Text="Next Step" OnClick="btnNextStep_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div id="divView" runat="server" style="display: none;">
        <table cellpadding="4" cellspacing="2" border="0" style="width: 100%;">
            <tr>
                <td align="left" colspan="6" class="ghc">
                    Claim ID
                </td>
            </tr>
            <tr>
                <td width="20%" align="left" class="lc">
                    <asp:Label runat="server" ID="lblDClaimNo">Claim Number</asp:Label>
                </td>
                <td width="5%" align="Center" class="lc">
                    :
                </td>
                <td width="25%" align="left" class="ic">
                    <asp:Label runat="server" ID="lblVClaimNo"></asp:Label>
                </td>
                <td align="left" class="lc">
                    <asp:Label runat="server" ID="lblDDOIncident">Date of Incident</asp:Label>
                </td>
                <td align="Center" class="lc">
                    :
                </td>
                <td align="left" class="ic">
                    <asp:Label runat="server" ID="lblVDOInci"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" class="lc">
                    <asp:Label runat="server" ID="lblDLastName">Name</asp:Label>
                </td>
                <td align="Center" class="lc">
                    :
                </td>
                <td align="left" class="ic">
                    <asp:Label runat="server" ID="lblVLastName"></asp:Label>&nbsp;
                    <asp:Label runat="server" ID="lblVMiddleMName"></asp:Label>&nbsp;
                    <asp:Label runat="server" ID="lblVFirstName"></asp:Label>
                </td>
                <td width="20%" align="left" class="lc">
                    <asp:Label runat="server" ID="lblDEmployee">Employee</asp:Label>
                </td>
                <td width="5%" align="Center" class="lc">
                    :
                </td>
                <td width="25%" align="left" class="ic">
                    <asp:Label runat="server" ID="lblVEmployee"></asp:Label>
                </td>
                <tr>
                    <td class="lc">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:GridView runat="server" ID="gvViewAll" AutoGenerateColumns="false" Width="100%"
                            OnRowDataBound="gvViewAll_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table cellpadding="4" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="left" colspan="6" class="ghc">
                                                    Adjustor Note Information
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" ID="lblAdjustorID" Visible="false" Text='<%#Eval("PK_Adjustor_Notes_ID") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 20%;" align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblVLDOActivity">Date of Activity</asp:Label>
                                                </td>
                                                <td width="5%" align="Center" class="lc">
                                                    :
                                                </td>
                                                <td width="25%" align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblVDoActivity" Text='<%# DataBinder.Eval(Container.DataItem,"Activity_Date","{0:MM/dd/yyyy}") %>'></asp:Label>
                                                </td>
                                                <td width="20%" align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblVLDate">Date</asp:Label>
                                                </td>
                                                <td width="5%" align="Center" class="lc">
                                                    :
                                                </td>
                                                <td width="25%" align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblVDate" Text='<%# DataBinder.Eval(Container.DataItem,"Date_Of_Note","{0:MM/dd/yyyy}") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblVLAuthor">Author</asp:Label>
                                                </td>
                                                <td align="Center" class="lc">
                                                    :
                                                </td>
                                                <td align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblVAuthor" Text='<%#Eval("Author_Of_Note") %>'></asp:Label>
                                                </td>
                                                <td align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblVLNoteType">Note Type</asp:Label>
                                                </td>
                                                <td align="Center" class="lc">
                                                    :
                                                </td>
                                                <td align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblVNoteType" Text='<%#Eval("Note_Type") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblVLUpdateBy"> Last Updated By</asp:Label>
                                                </td>
                                                <td align="Center" class="lc">
                                                    :
                                                </td>
                                                <td align="left" class="ic" colspan="4">
                                                    <asp:Label runat="server" ID="lblVUpdateBy" Text='<%#Eval("Update_By") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblVLNotes"> Notes</asp:Label>
                                                </td>
                                                <td align="Center" class="lc">
                                                    :
                                                </td>
                                                <td align="left" class="ic" colspan="4">
                                                    <asp:Label runat="server" ID="lblVNote" Text='<%#Eval("Notes") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings Visible="false" />
                            <EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                <table style="width: 100%;" border="0" cellpadding="2" cellspacing="4">
                                    <tr>
                                        <td align="center">
                                            Currently there is no Adjustor Note for the following claim.
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <table width="100%">
                            <tr>
                                <td colspan="2">
                                    <table cellspacing="0" width="100%" style="background-color: #7f7f7f; color: White;
                                        font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                        <tr>
                                            <td class="ghc">
                                                Attachment Details
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gvViewAttachment" runat="server" AutoGenerateColumns="false" DataKeyNames="PK_Attachment_ID"
                                        Width="100%" AllowPaging="True" AllowSorting="True" OnRowDataBound="gvAttachmentDetails_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <input name="chkItem" type="checkbox" value='<%# Eval("PK_Attachment_ID")%>' onclick="javascript:UnCheckHeader('gvViewAttachment')" />
                                                </ItemTemplate>
                                                <ItemStyle Width="10px" />
                                                <HeaderTemplate>
                                                    <input type="checkbox" id="chkHeader" runat="Server" name="chkHeader" onclick="javascript:SelectAllCheckboxes(this)" />
                                                </HeaderTemplate>
                                                <HeaderStyle Width="10px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" Visible="false">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Attachment_Name" HeaderText="File Name"></asp:BoundField>
                                            <asp:TemplateField HeaderText="View">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtnDwnld" CommandName="Download" CommandArgument='<%# Eval("Attachment_Name")%>'
                                                        runat="server" ImageAlign="Left" ImageUrl="~/Images/download.gif" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                            </asp:TemplateField>
                                            <%-- <asp:TemplateField HeaderText="Mail">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnMail" CommandName="Mail" CommandArgument='<%# Eval("Attachment_Name")%>'
                                                    runat="server" ImageUrl="~/Images/emailicon.gif" ImageAlign="Left" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                        </asp:TemplateField>--%>
                                        </Columns>
                                        <EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
                                        <EmptyDataTemplate>
                                            Currently there is no attachement.
                                        </EmptyDataTemplate>
                                        <PagerSettings Visible="False" />
                                        <PagerSettings Visible="False" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="6">
                        <asp:Button runat="server" ID="btnViewBack" Text="Back" OnClick="btnViewBack_Click" />
                        <asp:Button runat="server" ID="btnViewNext" Text="Next Step" OnClick="btnViewNext_Click"
                            Visible="false" />
                    </td>
                </tr>
        </table>
    </div>
    <%--</contenttemplate>
    </asp:UpdatePanel>--%>
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
