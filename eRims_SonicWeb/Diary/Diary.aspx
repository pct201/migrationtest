<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Diary.aspx.cs" Inherits="Diary_Diary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/JFunctions.js">
    </script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js">
    </script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript">
        function SetMenuStyle(index) {
        }

        function valSearch(searchCol) {
            ValidatorEnable(document.getElementById('<%=revSearchDateDiary.ClientID%>'), (searchCol == "Diary_Date"))
        }
        function MinMaxI() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtNote").style.height == "") {
                document.getElementById("ctl00_ContentPlaceHolder1_ibtnIDisplay").src = "../Images/minus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_txtNote").style.height = "100px";
                document.getElementById("pnlTemp").style.display = "block";
            }
            else if (document.getElementById("ctl00_ContentPlaceHolder1_txtNote").style.height == "100px") {
                document.getElementById("ctl00_ContentPlaceHolder1_ibtnIDisplay").src = "../Images/plus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_txtNote").style.height = "";
                document.getElementById("pnlTemp").style.display = "none";
            }
            return false;
        }
        function MinMax() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtNote").style.height == "") {
                document.getElementById("ctl00_ContentPlaceHolder1_ibtnDisplay").src = "../Images/minus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_txtNote").style.height = "100px";
                document.getElementById("pnlETemp").style.display = "block";
            }
            else if (document.getElementById("ctl00_ContentPlaceHolder1_txtNote").style.height == "100px") {
                document.getElementById("ctl00_ContentPlaceHolder1_ibtnDisplay").src = "../Images/plus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_txtNote").style.height = "";
                document.getElementById("pnlETemp").style.display = "none";
            }
            return false;
        }

        function displayDetail() {
            document.getElementById("ctl00_ContentPlaceHolder1_divfirst").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_divthird").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_divbtn").style.display = "none";
            return false;
        }

        function openPopUp(assignTo) {
            ShowDialog("LDiaryUser.aspx");
            //        oWnd=window.open("LDiaryUser.aspx","Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");	
            //        oWnd.moveTo(260,180);
            return false;
        }

    </script>
    <script language="javascript" type="text/javascript">
        function CheckTodayDate(sender, args) {
            args.IsValid = (CompareDateLessThanTodayNoAlert(args.Value));
            return args.IsValid;
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
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
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

        function ValidateFieldsUpdate(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlUpdateIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnUpdateErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlUpdateIDs.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
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

    </script>
    <div style="width: 100%;">
        <asp:ValidationSummary ID="vsErrorInsert" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroupInsert" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsErrorEdit" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroupEdit" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsErrorSearch" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroupSearch" CssClass="errormessage"></asp:ValidationSummary>
        <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="false"
            ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
        <asp:Label runat="server" Visible="false" ID="lblScript"></asp:Label>
    </div>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td width="5px">
                &nbsp;
            </td>
            <td align="center">
                <div id="mainContent" runat="server">
                    <div id="divSearch" runat="server" style="display: none;">
                        <table style="width: 100%;">
                            <tr>
                                <td width="35%">
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td align="left">
                                                <span class="heading">Diary Search Grid</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                &nbsp;
                                                <asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;Diary Found
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 65%; display: block;" align="right">
                                    <table style="width: 60%;">
                                        <tr>
                                            <td class="lc">
                                                Search
                                            </td>
                                            <td class="ic">
                                                <asp:DropDownList ID="ddlSearch" runat="server" SkinID="dropGen" onchange="valSearch(this.value);">
                                                    <asp:ListItem Text="Assign To" Value="Assigned_To"></asp:ListItem>
                                                    <asp:ListItem Text="Diary Date" Value="Diary_Date"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td class="ic">
                                                <asp:TextBox ID="txtSearch" runat="server" MaxLength="20"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="revSearchDateDiary" runat="server" ControlToValidate="txtSearch"
                                                    Enabled="false" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                    ErrorMessage="Please enter proper diary date to search" Display="none" ValidationGroup="vsErrorGroupSearch"></asp:RegularExpressionValidator>
                                            </td>
                                            <td class="ic">
                                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CausesValidation="true" ValidationGroup="vsErrorGroupSearch" />
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
                    <%-- <div>
                        <table width="100%">
                            <tr>
                                <td class="groupHeaderBar">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>--%>
                    <div id="divthird" style="width: 100%; display: none;" runat="server">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <table style="text-align: right; width: 100%;">
                                        <tr>
                                            <td class="ic">
                                                <asp:Button ID="btnClear" runat="server" Text="Clear" ToolTip="Clear Diary" OnClick="btnClear_Click"/> 
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Click here to delete Diary Details"
                                                    OnClick="btnDelete_Click" CausesValidation="false" />
                                                <asp:Button ID="btnAddNew" runat="server" Text="Add New" ToolTip="Add new Diary Details"
                                                    OnClick="btnAddNew_Click" CausesValidation="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left;">
                                                <asp:GridView ID="gvDiaryDetails" runat="server" AutoGenerateColumns="false" OnRowCommand="gvDiaryDetails_RowCommand"
                                                    DataKeyNames="PK_Diary_ID" Width="100%" 
                                                    AllowPaging="True" AllowSorting="True" OnSorting="gvDiaryDetails_Sorting" OnRowCreated="gvDiaryDetails_RowCreated">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <input name="chkItem" type="checkbox" value='<%# Eval("PK_Diary_ID")%>' onclick="javascript:UnCheckHeader('gvDiaryDetails')" />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="10px" />
                                                            <HeaderTemplate>
                                                                <input type="checkbox" name="chkHeader" id="chkHeader" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                                            </HeaderTemplate>
                                                            <HeaderStyle Width="10px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Module_Name" HeaderText="Module" SortExpression="Module_Name">
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Location" HeaderText="Location d/b/a" SortExpression="Location">
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region"></asp:BoundField>
                                                        <asp:TemplateField HeaderText="Identification" SortExpression="Identification_Field">
                                                            <ItemTemplate>
                                                            <%--<asp:Label ID="lblDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Identification_Field")%>'></asp:Label>--%>
                                                                <asp:HiddenField id="hdnidModule" runat="server" value='<%#DataBinder.Eval(Container.DataItem, "FK_Diary_Module")%>'/>
                                                                <asp:HiddenField ID="hdnidFkTable" runat="server"  value='<%#DataBinder.Eval(Container.DataItem, "FK_Table_Name")%>'/>
                                                                <asp:HiddenField ID="hdnFrWizardId" runat="server"  value='<%#DataBinder.Eval(Container.DataItem, "First_Report_Wizard_ID")%>'/>
                                                                <asp:LinkButton ID="lnkIdentificatoin" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Identification_Field")%>' CommandName="Redirect" CommandArgument='<%#Eval("FK_LU_Location_ID")%>' >
                                                                </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Assigned_To" HeaderText="Assigned To" SortExpression="Assigned_To">
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Diary_Date" SortExpression="Diary_Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDiary_Date" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Diary_Date", "{0:MM/dd/yyyy}")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Clear" HeaderText="Clear" SortExpression="Clear"></asp:BoundField>
                                                        <%-- <asp:BoundField DataField="Diary_Date" HeaderText="Diary Date" SortExpression="Diary_Date">
                                                              </asp:BoundField>--%>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_Diary_ID")%>'
                                                                    runat="server" Text="Edit" ToolTip="Edit the Diary Details" Visible='<%#Eval("IsEdit")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="center" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("PK_Diary_ID")%>'
                                                                    ToolTip="View the Diary Details" Visible='<%#Eval("IsView")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="center" Width="60px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="center" />
                                                    <EmptyDataTemplate>
                                                        No Diary found.
                                                    </EmptyDataTemplate>
                                                    <PagerSettings Visible="False" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="divForth" style="width: 100%; display: none;" runat="server">
                        <table cellpadding="2" cellspacing="2" border="0" style="width: 100%;">
                            <tr>
                                <td>
                                    <div>
                                        <table cellpadding="2" cellspacing="2" style="width: 100%;">
                                            <tr>
                                                <td align="left" colspan="6" class="ghc">
                                                    Diary Information
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%;" align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblDONEntry">Date of Note Entry&nbsp;<span id="Span8"
                                                        style="color: Red;" runat="server">*</span></asp:Label>
                                                </td>
                                                <td align="center" class="lc">
                                                    :
                                                </td>
                                                <td style="width: 25%;" align="left" class="ic">
                                                    <asp:TextBox runat="server" ID="txtIDONoteEntry" ValidationGroup="vsErrorGroupInsert"
                                                        Width="163px"></asp:TextBox>&nbsp;
                                                    <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtIDONoteEntry', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                        align="absmiddle" /><br />
                                                    <asp:RegularExpressionValidator ID="revIDONoteEntry" runat="server" ControlToValidate="txtIDONoteEntry"
                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                        ErrorMessage="[Diary Data]/Date of Note Entry is Not Valid." Display="none" ValidationGroup="vsErrorGroupInsert"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="rfvNoteEntry" runat="server" ControlToValidate="txtIDONoteEntry"
                                                        ErrorMessage="Please Enter DateofNote." Display="none" ValidationGroup="vsErrorGroupInsert">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                                <td style="width: 25%;" align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblDiaryDate">Diary Date&nbsp;<span id="Span1" style="color: Red;"
                                                        runat="server">*</span></asp:Label>
                                                </td>
                                                <td align="center" class="lc">
                                                    :
                                                </td>
                                                <td style="width: 25%;" align="left" class="ic">
                                                    <asp:TextBox runat="server" ID="txtDiaryDate" ValidationGroup="vsErrorGroupInsert"
                                                        Width="163px"></asp:TextBox>&nbsp;
                                                    <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDiaryDate', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                        align="absmiddle" />
                                                    <asp:RegularExpressionValidator ID="revIDiaryDate" runat="server" ControlToValidate="txtDiaryDate"
                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                        ErrorMessage="[Diary Data]/Diary Date is Not Valid." Display="none" ValidationGroup="vsErrorGroupInsert"></asp:RegularExpressionValidator>
                                                    <asp:CustomValidator ID="csmvtxtIDiaryDate" runat="server" ControlToValidate="txtDiaryDate"
                                                        ErrorMessage="[Diary Data]/Diary Date must not be greater than current date"
                                                        ClientValidationFunction="CheckTodayDate" Display="none" ValidationGroup="vsErrorGroupInsert"
                                                        Enabled="false">
                                                    </asp:CustomValidator>
                                                    <asp:RequiredFieldValidator ID="rfvDirayDate" runat="server" ControlToValidate="txtDiaryDate"
                                                        ErrorMessage="Please Enter Diarydate." Display="none" ValidationGroup="vsErrorGroupInsert">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%;" align="left" class="lc">
                                                    <asp:Label runat="server" ID="Label1">Module&nbsp;<span id="Span4" style="color: Red;"
                                                        runat="server">*</span></asp:Label>
                                                </td>
                                                <td align="center" class="lc">
                                                    :
                                                </td>
                                                <td style="width: 25%;" align="left" class="ic">
                                                    <asp:DropDownList ID="ddlModule" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged"
                                                        Width="195px">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvddlMoule" runat="server" ControlToValidate="ddlModule"
                                                        InitialValue="0" ErrorMessage="Please Select Module." Display="none" ValidationGroup="vsErrorGroupInsert">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                                <td style="width: 25%;" align="left" class="lc">
                                                    <asp:Label runat="server" ID="Label2">Location d/b/a&nbsp;<span id="Span5" style="color: Red;"
                                                        runat="server">*</span></asp:Label>
                                                </td>
                                                <td align="center" class="lc">
                                                    :
                                                </td>
                                                <td style="width: 25%;" align="left" class="ic">
                                                    <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged"
                                                        Width="195px">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvddlLocation" runat="server" ControlToValidate="ddlLocation"
                                                        InitialValue="0" ErrorMessage="Please Select Location." Display="none" ValidationGroup="vsErrorGroupInsert">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%;" align="left" class="lc">
                                                    <asp:Label runat="server" ID="Label3">Identification&nbsp;<span id="Span6" style="color: Red;"
                                                        runat="server">*</span></asp:Label>
                                                </td>
                                                <td align="center" class="lc">
                                                    :
                                                </td>
                                                <td style="width: 25%;" align="left" class="ic">
                                                    <asp:DropDownList ID="ddlIdentification" runat="server" Width="195px">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvddlidentifiction" runat="server" ControlToValidate="ddlIdentification"
                                                        InitialValue="0" ErrorMessage="Please Select Identificationfield." Display="none"
                                                        ValidationGroup="vsErrorGroupInsert">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                                <td style="width: 25%;" align="left" class="lc">
                                                    <asp:Label runat="server" ID="Label5">Task Type&nbsp;<span id="Span7" style="color: Red;"
                                                        runat="server">*</span></asp:Label>
                                                </td>
                                                <td align="center" class="lc">
                                                    :
                                                </td>
                                                <td style="width: 25%;" align="left" class="ic">
                                                    <asp:DropDownList ID="ddlTaskType" runat="server" Width="195px">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvDdlTaskType" runat="server" ControlToValidate="ddlTaskType"
                                                        InitialValue="0" ErrorMessage="Please Select TaskType." Display="none" ValidationGroup="vsErrorGroupInsert">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="lc" style="width: 25%;" valign="top">
                                                    <asp:Label runat="server" ID="lblNote">Note&nbsp;<span id="Span2" style="color: Red;
                                                        display: none;" runat="server">*</span></asp:Label>
                                                </td>
                                                <td align="center" class="lc" valign="top">
                                                    :
                                                </td>
                                                <td align="left" class="ic" colspan="4" valign="top" style="width: 75%;">
                                                    <asp:ImageButton ID="ibtnIDisplay" ImageUrl="~/Images/Minus.jpg" runat="server" OnClientClick="javascript:return MinMaxI();" />
                                                    <div id="pnlTemp" style="display: block;">
                                                        <asp:TextBox runat="server" ID="txtNote" MaxLength="4000" Height="100px" TextMode="MultiLine"
                                                            Width="93%"></asp:TextBox>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="lc" style="width: 25%;" valign="top">
                                                    <asp:Label runat="server" ID="lblClear"> Clear?</asp:Label>
                                                </td>
                                                <td align="center" class="lc" valign="top">
                                                    :
                                                </td>
                                                <td align="left" class="ic" style="width: 25%;" valign="top">
                                                    <asp:RadioButton runat="server" GroupName="Clear" ID="rbIClearYes" Text="Yes" />&nbsp;
                                                    <asp:RadioButton runat="server" GroupName="Clear" ID="rbIClearNo" Checked="true" Text="No" />
                                                </td>
                                                <td align="left" class="lc" style="width: 25%;" valign="top">
                                                    <asp:Label runat="server" ID="lblAssignTo">Assigned To&nbsp;<span id="Span3" style="color: Red;" runat="server">*</span></asp:Label>
                                                </td>
                                                <td align="center" class="lc" valign="top">
                                                    :
                                                </td>
                                                <td align="left" class="ic" style="width: 25%;" valign="top">
                                                    <asp:TextBox runat="server" ID="txtIAssignTo" ReadOnly="true" Width="70%"></asp:TextBox>&nbsp;
                                                    <asp:RequiredFieldValidator ID="rfvAssignto" runat="server" ControlToValidate="txtIAssignTo"
                                                         ErrorMessage="Please Enter Assign To." Display="none" ValidationGroup="vsErrorGroupInsert">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:Button ID="btnIAssignTO" Text="V" runat="server" CssClass="btn" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" style="display: none;">
                                                    <asp:TextBox runat="server" ID="txtIAssignToID"></asp:TextBox>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="ic" align="center" colspan="6">
                                                    <asp:Button runat="server" ID="btnISaveView" SkinID="btnGen" Text="Save & View" ValidationGroup="vsErrorGroupInsert"
                                                        OnClick="btnSaveView_Click" />
                                                    <asp:Button runat="server" ID="btnICancel" Text="Cancel" SkinID="btnGen" OnClick="btnCancel_Click"
                                                        CausesValidation="false" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="divfifth" style="width: 100%; display: none;" runat="server">
                        <table cellpadding="4" cellspacing="0" border="0" style="width: 100%;">
                            <tr>
                                <td>
                                    <div>
                                        <table cellpadding="2" cellspacing="2" style="width: 100%;">
                                            <tr>
                                                <td align="left" colspan="6" class="ghc">
                                                    Diary Information
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%;" align="left" class="lc">
                                                    <asp:Label runat="server" ID="Label4"> Date of Note Entry</asp:Label>
                                                </td>
                                                <td align="center" class="lc">
                                                    :
                                                </td>
                                                <td style="width: 25%;" align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblDONoteEntry_View"></asp:Label>
                                                </td>
                                                <td style="width: 25%;" align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblVDiaryDate"> Diary Date</asp:Label>
                                                </td>
                                                <td align="center" class="lc">
                                                    :
                                                </td>
                                                <td style="width: 25%;" align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblDiaryDate_View"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%;" align="left" class="lc">
                                                    <asp:Label runat="server" ID="Label9">Module</asp:Label>
                                                </td>
                                                <td align="center" class="lc">
                                                    :
                                                </td>
                                                <td style="width: 25%;" align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblModule_View"></asp:Label>
                                                </td>
                                                <td style="width: 25%;" align="left" class="lc">
                                                    <asp:Label runat="server" ID="Label11">Location d/b/a</asp:Label>
                                                </td>
                                                <td align="center" class="lc">
                                                    :
                                                </td>
                                                <td style="width: 25%;" align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblLocation_View"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%;" align="left" class="lc">
                                                    <asp:Label runat="server" ID="Label10">Identification</asp:Label>
                                                </td>
                                                <td align="center" class="lc">
                                                    :
                                                </td>
                                                <td style="width: 25%;" align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblIdentification_View"></asp:Label>
                                                </td>
                                                <td style="width: 25%;" align="left" class="lc">
                                                    <asp:Label runat="server" ID="Label6">Tasktype</asp:Label>
                                                </td>
                                                <td align="center" class="lc">
                                                    :
                                                </td>
                                                <td style="width: 25%;" align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblTaskType_View"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="lc" style="width: 25%;">
                                                    <asp:Label runat="server" ID="lblVNote">Note</asp:Label>
                                                </td>
                                                <td align="center" class="lc">
                                                    :
                                                </td>
                                                <td align="left" class="ic" colspan="4">
                                                    <asp:Label runat="server" ID="lblNote_View"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="lc" style="width: 25%;">
                                                    <asp:Label runat="server" ID="lbVlClear"> Clear?</asp:Label>
                                                </td>
                                                <td align="center" class="lc">
                                                    :
                                                </td>
                                                <td align="left" class="ic" style="width: 25%;">
                                                    <asp:Label runat="server" ID="lblClear_View"></asp:Label>
                                                </td>
                                                <td align="left" class="lc" style="width: 25%;">
                                                    <asp:Label runat="server" ID="lblVAssignTo">Assigned To</asp:Label>
                                                </td>
                                                <td align="center" class="lc">
                                                    :
                                                </td>
                                                <td align="left" class="ic" style="width: 25%;">
                                                    <asp:Label runat="server" ID="lblAssignTo_View"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="ic" align="center" colspan="6">                                                    
                                                    <asp:Button runat="server" ID="btnCancel" Text="Cancel" SkinID="btnGen" OnClick="btnCancel_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
            <td width="5px">
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroupInsert" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsUpdate"
        Display="None" ValidationGroup="vsErrorGroupEdit" />
    <input id="hdnControlUpdateIDs" runat="server" type="hidden" />
    <input id="hdnUpdateErrorMsgs" runat="server" type="hidden" />
</asp:Content>
