<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="MainDiary.aspx.cs"
    Inherits="WorkerCompensation_MainDiary" Title="eRIMS Sonic :: Diary" %>

<%@ Register Src="~/Controls/ExcecutiveRiskInfo/ExecutiveRiskInfo.ascx" TagName="ctrlExecRisk"
    TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/JFunctions.js">
    </script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js">
    </script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>
    <link href="../App_Themes/Default/stylecal.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript">

        function SetMenuStyle(index) {
        }

        function valSearch(searchCol) {
            ValidatorEnable(document.getElementById('<%=revSearchDateDiary.ClientID%>'), (searchCol == "Diary_Date"))
        }
        function MinMaxI() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtINote").style.height == "") {
                document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_ibtnIDisplay").src = "../Images/minus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtINote").style.height = "100px";
                document.getElementById("pnlTemp").style.display = "block";
            }
            else if (document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtINote").style.height == "100px") {
                document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_ibtnIDisplay").src = "../Images/plus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtINote").style.height = "";
                document.getElementById("pnlTemp").style.display = "none";
            }
            return false;
        }
        function MinMax() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtNote").style.height == "") {
                document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_ibtnDisplay").src = "../Images/minus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtNote").style.height = "100px";
                document.getElementById("pnlETemp").style.display = "block";
            }
            else if (document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtNote").style.height == "100px") {
                document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_ibtnDisplay").src = "../Images/plus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtNote").style.height = "";
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
            return false;
        }
        function CheckTodayDate(sender, args) {
            args.IsValid = (CompareDateLessThanTodayNoAlert(args.Value));
            return args.IsValid;
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
                                    Text="Diary Data"></asp:LinkButton>
                                    &nbsp;<span id="MenuAsterisk2" runat="server" style="color: Red;" visible="true">*</span>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="100%">
                    <asp:UpdatePanel ID="pnlBankDetail" runat="server">
                        <ContentTemplate>
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
                                                        <td style="width: 25%;" align="left" class="lc">
                                                            <asp:Label runat="server" ID="lblMClaimNumber">Claim Number</asp:Label>
                                                        </td>
                                                        <td align="Center" class="lc">
                                                            :
                                                        </td>
                                                        <td style="width: 25%;" align="left" class="ic">
                                                            <asp:Label runat="server" ID="lblClaimNum"></asp:Label>
                                                        </td>
                                                        <td style="width: 25%;" align="left" class="lc">
                                                            <asp:Label runat="server" ID="lblMDOIncident">Date of Incident</asp:Label>
                                                        </td>
                                                        <td align="Center" class="lc">
                                                            :
                                                        </td>
                                                        <td style="width: 25%;" align="left" class="ic">
                                                            <asp:Label runat="server" ID="lblDateIncident"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%;" align="left" class="lc">
                                                            <asp:Label runat="server" ID="lblMLastName">Name</asp:Label>
                                                        </td>
                                                        <td align="Center" class="lc">
                                                            :
                                                        </td>
                                                        <td style="width: 25%;" align="left" class="ic">
                                                            <asp:Label runat="server" ID="lblLName"></asp:Label>&nbsp;
                                                            <asp:Label runat="server" ID="lblMName"></asp:Label>&nbsp;
                                                            <asp:Label runat="server" ID="lblFName"></asp:Label>
                                                        </td>
                                                        <td style="width: 25%;" align="left" class="lc">
                                                            <asp:Label runat="server" ID="lblMEmployee">Employee</asp:Label>
                                                        </td>
                                                        <td align="Center" class="lc">
                                                            :
                                                        </td>
                                                        <td style="width: 25%;" align="left" class="ic">
                                                            <asp:RadioButtonList ID="rbtnEmployee" runat="server" Enabled="false" RepeatDirection="Horizontal">
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="divSearch" runat="server" style="display: none;">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td style="width: 80%; display: block;" align="right">
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
                                                                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                                                                            ValidationGroup="vsErrorGroupSearch" />
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
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td>
                                                            <asp:MultiView runat="server" ID="mvDiaryDetails">
                                                                <asp:View runat="server" ID="vwDiaryList">
                                                                    <table style="width: 100%;">
                                                                        <tr>
                                                                            <td>
                                                                                <table style="text-align: right; width: 100%;">
                                                                                    <tr>
                                                                                        <td class="ic">
                                                                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Click here to delete Diary Details"
                                                                                                OnClick="btnDelete_Click" CausesValidation="false" />
                                                                                            <asp:Button ID="btnAddNew" runat="server" Text="Add New" ToolTip="Add new Diary Details"
                                                                                                OnClick="btnAddNew_Click" CausesValidation="false" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="text-align: left;">
                                                                                            <asp:GridView ID="gvDiaryDetails" runat="server" AutoGenerateColumns="false" OnRowCommand="gvDiaryDetails_RowCommand"
                                                                                                DataKeyNames="PK_Diary_ID" Width="100%" OnPageIndexChanging="gvDiaryDetails_PageIndexChanging"
                                                                                                OnRowDataBound="gvDiaryDetails_RowDataBound" AllowPaging="True" AllowSorting="True"
                                                                                                OnSorting="gvDiaryDetails_Sorting" OnRowCreated="gvDiaryDetails_RowCreated">
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
                                                                                                    <asp:TemplateField HeaderText="Date Of Note Entry" SortExpression="DateOfNoteEntry">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "DateOfNoteEntry", "{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:BoundField DataField="Assigned_To" HeaderText="Assigned To" SortExpression="Assigned_To">
                                                                                                    </asp:BoundField>
                                                                                                    <asp:TemplateField HeaderText="Diary_Date" SortExpression="Diary_Date">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblDiary_Date" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Diary_Date", "{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_Diary_ID")%>'
                                                                                                                runat="server" Text="Edit" ToolTip="Edit the Diary Details" />
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("PK_Diary_ID")%>'
                                                                                                                ToolTip="View the Diary Details" />
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                                                <EmptyDataTemplate>
                                                                                                    No Diary found for the following claim.
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
                                                                <asp:View ID="vwDiaryDetails" runat="server">
                                                                    <table style="width: 100%;">
                                                                        <tr>
                                                                            <td>
                                                                                <div>
                                                                                    <table cellpadding="2" cellspacing="2" style="border: 1pt; border-color: #7f7f7f;
                                                                                        border-style: solid; text-align: left; width: 100%;">
                                                                                        <tr>
                                                                                            <td align="left" colspan="6" class="ghc">
                                                                                                Claim Details
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 25%;" align="left" class="lc">
                                                                                                <asp:Label runat="server" ID="lblFClaimNumber">Claim Number</asp:Label>
                                                                                            </td>
                                                                                            <td align="Center" class="lc">
                                                                                                :
                                                                                            </td>
                                                                                            <td style="width: 25%;" align="left" class="ic">
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
                                                                                            <td style="width: 25%;" align="left" class="lc">
                                                                                                <asp:Label runat="server" ID="lblFEmployee">Employee</asp:Label>
                                                                                            </td>
                                                                                            <td align="Center" class="lc">
                                                                                                :
                                                                                            </td>
                                                                                            <td style="width: 25%;" align="left" class="ic">
                                                                                                <asp:Label runat="server" ID="lblEmployee"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:FormView runat="server" ID="fvDiaryDetails" OnDataBound="fvDiaryDetails_DataBound"
                                                                                    Width="100%">
                                                                                    <InsertItemTemplate>
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
                                                                                                                    <asp:Label runat="server" ID="lblDONEntry"> Date of Note Entry</asp:Label>
                                                                                                                    &nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                                                                                </td>
                                                                                                                <td align="Center" class="lc">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td style="width: 25%;" align="left" class="ic">
                                                                                                                    <asp:TextBox runat="server" ID="txtIDONoteEntry" ValidationGroup="vsErrorGroupInsert"></asp:TextBox>&nbsp;
                                                                                                                    <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvDiaryDetails_txtIDONoteEntry', 'mm/dd/y');"
                                                                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                                                                        align="absmiddle" /><br />
                                                                                                                    <cc1:MaskedEditExtender ID="mskIDONoteEntry" runat="server" AcceptNegative="Left"
                                                                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtIDONoteEntry"
                                                                                                                        CultureName="en-US" AutoComplete="true">
                                                                                                                    </cc1:MaskedEditExtender>
                                                                                                                    <cc1:MaskedEditValidator ID="mskValDtStart" runat="server" ControlExtender="mskIDONoteEntry"
                                                                                                                        ControlToValidate="txtIDONoteEntry" Display="dynamic" IsValidEmpty="True" MaximumValue=""
                                                                                                                        EmptyValueMessage="" InvalidValueMessage="Invalid Date" MaximumValueMessage=""
                                                                                                                        MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                                                                                                                    </cc1:MaskedEditValidator>
                                                                                                                    <asp:RegularExpressionValidator ID="revIDONoteEntry" runat="server" ControlToValidate="txtIDONoteEntry"
                                                                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                                                                        ErrorMessage="[Diary Data]/Date of Note Entry is Not Valid." Display="none" ValidationGroup="vsErrorGroupInsert"></asp:RegularExpressionValidator>
                                                                                                                </td>
                                                                                                                <td style="width: 25%;" align="left" class="lc">
                                                                                                                    <asp:Label runat="server" ID="lblDiaryDate"> Diary Date</asp:Label>
                                                                                                                    &nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                                                                                </td>
                                                                                                                <td align="Center" class="lc">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td style="width: 25%;" align="left" class="ic">
                                                                                                                    <asp:TextBox runat="server" ID="txtIDiaryDate" ValidationGroup="vsErrorGroupInsert"></asp:TextBox>&nbsp;
                                                                                                                    <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvDiaryDetails_txtIDiaryDate', 'mm/dd/y');"
                                                                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                                                                        align="absmiddle" />
                                                                                                                    <cc1:MaskedEditExtender ID="mskIDiaryDate" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtIDiaryDate" CultureName="en-US"
                                                                                                                        AutoComplete="true">
                                                                                                                    </cc1:MaskedEditExtender>
                                                                                                                    <cc1:MaskedEditValidator ID="mskValDtStart1" runat="server" ControlExtender="mskIDiaryDate"
                                                                                                                        ControlToValidate="txtIDiaryDate" Display="dynamic" IsValidEmpty="True" MaximumValue=""
                                                                                                                        InvalidValueMessage="Date is invalid" EmptyValueMessage="Please Select [Diary Data]/Diary Date."
                                                                                                                        MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                                                                                                                    </cc1:MaskedEditValidator>
                                                                                                                    <%-- <asp:RequiredFieldValidator ID="rfvIDiaryDate" ControlToValidate="txtIDiaryDate"
                                                                                                                        Display="none" Text="*" runat="server" InitialValue="" ValidationGroup="vsErrorGroupInsert"
                                                                                                                        ErrorMessage="Please Select [Diary Data]/Diary Date."></asp:RequiredFieldValidator>--%>
                                                                                                                    <asp:RegularExpressionValidator ID="revIDiaryDate" runat="server" ControlToValidate="txtIDiaryDate"
                                                                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                                                                        ErrorMessage="[Diary Data]/Diary Date is Not Valid." Display="none" ValidationGroup="vsErrorGroupInsert"></asp:RegularExpressionValidator>
                                                                                                                    <asp:CustomValidator ID="csmvtxtIDiaryDate" runat="server" ControlToValidate="txtIDiaryDate"
                                                                                                                        ErrorMessage="[Diary Data]/Diary Date must not be greater than current date"
                                                                                                                        ClientValidationFunction="CheckTodayDate" Display="none" ValidationGroup="vsErrorGroupInsert"
                                                                                                                        Enabled="false">
                                                                                                                    </asp:CustomValidator>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left" class="lc" style="width: 25%;" valign="top">
                                                                                                                    <asp:Label runat="server" ID="lblNote">Note</asp:Label>
                                                                                                                    &nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                                                                                </td>
                                                                                                                <td align="Center" class="lc" valign="top">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td align="left" class="ic" colspan="4" valign="top" style="width: 75%;">
                                                                                                                    <asp:ImageButton ID="ibtnIDisplay" ImageUrl="~/Images/Minus.jpg" runat="server" OnClientClick="javascript:return MinMaxI();" />
                                                                                                                    <div id="pnlTemp" style="display: block;">
                                                                                                                        <asp:TextBox runat="server" ID="txtINote" MaxLength="4000" Height="100px" TextMode="MultiLine"
                                                                                                                            Width="93%"></asp:TextBox>
                                                                                                                    </div>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left" class="lc" style="width: 25%;" valign="top">
                                                                                                                    <asp:Label runat="server" ID="lblClear"> Clear?</asp:Label>
                                                                                                                </td>
                                                                                                                <td align="Center" class="lc" valign="top">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td align="left" class="ic" style="width: 25%;" valign="top">
                                                                                                                    <asp:RadioButton runat="server" GroupName="Clear" ID="rbIClearYes" Text="Yes" />&nbsp;
                                                                                                                    <asp:RadioButton runat="server" GroupName="Clear" ID="rbIClearNo" Checked="true"
                                                                                                                        Text="No" />
                                                                                                                </td>
                                                                                                                <td align="left" class="lc" style="width: 25%;" valign="top">
                                                                                                                    <asp:Label runat="server" ID="lblAssignTo">Assigned To</asp:Label>
                                                                                                                    &nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                                                                                </td>
                                                                                                                <td align="Center" class="lc" valign="top">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td align="left" class="ic" style="width: 25%;" valign="top">
                                                                                                                    <asp:TextBox runat="server" ID="txtIAssignTo" ReadOnly="true" Width="70%"></asp:TextBox>&nbsp;
                                                                                                                    <asp:Button ID="btnIAssignTO" Text="V" runat="server" CssClass="btn" />
                                                                                                                    <%-- <asp:RequiredFieldValidator ID="rfvIAssignTo" ControlToValidate="txtIAssignTo" runat="server"
                                                                                                                        InitialValue="" ValidationGroup="vsErrorGroupInsert" ErrorMessage="Please Select [Diary Data]/Assigned To."
                                                                                                                        Display="none" Text="*"></asp:RequiredFieldValidator>--%>
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
                                                                                                                    <asp:Button runat="server" ID="btnISaveView" CausesValidation="true" SkinID="btnGen"
                                                                                                                        Text="Save & View" ValidationGroup="vsErrorGroupInsert" OnClick="btnSaveView_Click" />
                                                                                                                    <asp:Button runat="server" ID="btnICancel" Text="Cancel" SkinID="btnGen" OnClick="btnCancel_Click"
                                                                                                                        CausesValidation="false" />
                                                                                                                    <input id="hdnControlIDsInsert" runat="server" type="hidden" />
                                                                                                                    <input id="hdnErrorMsgsInsert" runat="server" type="hidden" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </InsertItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <table cellpadding="3" cellspacing="0" border="0" style="width: 100%;">
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
                                                                                                                    <asp:Label runat="server" ID="lblDONEntry"> Date of Note Entry</asp:Label>
                                                                                                                    &nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                                                                                </td>
                                                                                                                <td align="Center" class="lc">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td style="width: 25%;" align="left" class="ic">
                                                                                                                    <asp:TextBox runat="server" ID="txtDONoteEntry" ValidationGroup="vsErrorGroupEdit"></asp:TextBox>&nbsp;
                                                                                                                    <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvDiaryDetails_txtDONoteEntry', 'mm/dd/y');"
                                                                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                                                                        align="absmiddle" /><br />
                                                                                                                    <cc1:MaskedEditExtender ID="mskDONoteEntry" runat="server" AcceptNegative="Left"
                                                                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDONoteEntry"
                                                                                                                        CultureName="en-US" AutoComplete="true">
                                                                                                                    </cc1:MaskedEditExtender>
                                                                                                                    <cc1:MaskedEditValidator ID="mskVDONoteEntry" runat="server" ControlExtender="mskDONoteEntry"
                                                                                                                        ControlToValidate="txtDONoteEntry" Display="dynamic" IsValidEmpty="True" MaximumValue=""
                                                                                                                        EmptyValueMessage="" InvalidValueMessage="Invalid Date" MaximumValueMessage=""
                                                                                                                        MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                                                                                                                    </cc1:MaskedEditValidator>
                                                                                                                    <asp:RegularExpressionValidator ID="revDONoteEntry" runat="server" ControlToValidate="txtDONoteEntry"
                                                                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                                                                        ErrorMessage="[Diary Data]/Date of Note Entry is Not Valid." Display="none" ValidationGroup="vsErrorGroupEdit"></asp:RegularExpressionValidator>
                                                                                                                </td>
                                                                                                                <td style="width: 25%;" align="left" class="lc">
                                                                                                                    <asp:Label runat="server" ID="lblDiaryDate"> Diary Date</asp:Label>
                                                                                                                    &nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                                                                                </td>
                                                                                                                <td align="Center" class="lc">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td style="width: 25%;" align="left" class="ic">
                                                                                                                    <asp:TextBox runat="server" ID="txtDiaryDate"></asp:TextBox>
                                                                                                                    <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvDiaryDetails_txtDiaryDate', 'mm/dd/y');"
                                                                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                                                                        align="absmiddle" />
                                                                                                                    <br />
                                                                                                                    <cc1:MaskedEditExtender ID="mskDiaryDate" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtDiaryDate" CultureName="en-US"
                                                                                                                        AutoComplete="true">
                                                                                                                    </cc1:MaskedEditExtender>
                                                                                                                    <%-- <asp:RequiredFieldValidator ID="rfvDiaryDate" ControlToValidate="txtDiaryDate" Display="none"
                                                                                                                        Text="*" runat="server" InitialValue="" ValidationGroup="vsErrorGroupEdit" ErrorMessage="Please Select [Diary Data]/Diary Date."></asp:RequiredFieldValidator>--%>
                                                                                                                    <asp:RegularExpressionValidator ID="revDiaryDate" runat="server" ControlToValidate="txtDiaryDate"
                                                                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                                                                        ErrorMessage="[Diary Data]/Diary Date is Not Valid." Display="none" ValidationGroup="vsErrorGroupEdit"></asp:RegularExpressionValidator>
                                                                                                                    <asp:CustomValidator ID="csmvtxtDiaryDate" runat="server" ControlToValidate="txtDiaryDate"
                                                                                                                        ErrorMessage="[Diary Data]/Diary Date must not be greater than current date"
                                                                                                                        ClientValidationFunction="CheckTodayDate" Display="none" ValidationGroup="vsErrorGroupEdit"
                                                                                                                        Enabled="false">
                                                                                                                    </asp:CustomValidator>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left" class="lc" style="width: 25%" valign="top">
                                                                                                                    <asp:Label runat="server" ID="lblNote">Note</asp:Label>
                                                                                                                    &nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                                                                                </td>
                                                                                                                <td align="Center" class="lc" valign="top">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td align="left" class="ic" colspan="4" style="width: 75%;" valign="top">
                                                                                                                    <asp:ImageButton ID="ibtnDisplay" ImageUrl="~/Images/Minus.jpg" runat="server" OnClientClick="javascript:return MinMax();" />
                                                                                                                    <div id="pnlETemp" style="display: block;">
                                                                                                                        <asp:TextBox runat="server" ID="txtNote" MaxLength="4000" Height="100px" TextMode="MultiLine"
                                                                                                                            Width="93%"></asp:TextBox>
                                                                                                                    </div>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left" class="lc" style="width: 25%" valign="top">
                                                                                                                    <asp:Label runat="server" ID="lblClear"> Clear?</asp:Label>
                                                                                                                </td>
                                                                                                                <td align="Center" class="lc" valign="top">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td align="left" class="ic" style="width: 25%" valign="top">
                                                                                                                    <asp:RadioButton runat="server" GroupName="Clear" ID="rbClearYes" Text="Yes" />&nbsp;
                                                                                                                    <asp:RadioButton runat="server" GroupName="Clear" ID="rbClearNo" Checked="true" Text="No" />
                                                                                                                </td>
                                                                                                                <td align="left" class="lc" style="width: 25%" valign="top">
                                                                                                                    <asp:Label runat="server" ID="lblAssignTo">Assigned To</asp:Label>
                                                                                                                    &nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                                                                                </td>
                                                                                                                <td align="Center" class="lc" valign="top">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td align="left" class="ic" style="width: 25%" valign="top">
                                                                                                                    <asp:TextBox runat="server" ID="txtAssignTo" Enabled="false" Width="70%"></asp:TextBox>&nbsp;
                                                                                                                    <asp:Button ID="btnAssignTO" Text="V" runat="server" CssClass="btn" />
                                                                                                                    <%-- <asp:RequiredFieldValidator ID="rfvAssignTo" ControlToValidate="txtAssignTo" runat="server"
                                                                                                                        InitialValue="" ValidationGroup="vsErrorGroupEdit" ErrorMessage="Please Select [Diary Data]/Assigned To."
                                                                                                                        Display="none" Text="*"></asp:RequiredFieldValidator>--%>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td colspan="6" style="display: none;" valign="top">
                                                                                                                    <asp:TextBox runat="server" ID="txtAssignToID"></asp:TextBox>&nbsp;
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td colspan="6">
                                                                                                                    &nbsp;
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="ic" align="center" colspan="6">
                                                                                                                    <asp:Button runat="server" ID="btnSaveView" CausesValidation="true" SkinID="btnGen"
                                                                                                                        Text="Save & View" ValidationGroup="vsErrorGroupEdit" OnClick="btnSaveView_Click" />
                                                                                                                    <asp:Button runat="server" ID="btnCancel" Text="Cancel" SkinID="btnGen" OnClick="btnCancel_Click"
                                                                                                                        CausesValidation="false" />
                                                                                                                    <asp:Button ID="btnViewAudit" runat="server" Text="View Audit Trail" SkinID="btnGen" />
                                                                                                                    <input id="hdnControlIDsEdit" runat="server" type="hidden" />
                                                                                                                    <input id="hdnErrorMsgsEdit" runat="server" type="hidden" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
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
                                                                                                                    <asp:Label runat="server" ID="lblDONEntry"> Date of Note Entry</asp:Label>
                                                                                                                </td>
                                                                                                                <td align="Center" class="lc">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td style="width: 25%;" align="left" class="ic">
                                                                                                                    <asp:Label runat="server" ID="lblDONoteEntry"></asp:Label>
                                                                                                                </td>
                                                                                                                <td style="width: 25%;" align="left" class="lc">
                                                                                                                    <asp:Label runat="server" ID="lblVDiaryDate"> Diary Date</asp:Label>
                                                                                                                </td>
                                                                                                                <td align="Center" class="lc">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td style="width: 25%;" align="left" class="ic">
                                                                                                                    <asp:Label runat="server" ID="lblDiaryDate"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left" class="lc" style="width: 25%;">
                                                                                                                    <asp:Label runat="server" ID="lblVNote">Note</asp:Label>
                                                                                                                </td>
                                                                                                                <td align="Center" class="lc">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td align="left" class="ic" colspan="4">
                                                                                                                    <asp:Label runat="server" ID="lblNote"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left" class="lc" style="width: 25%;">
                                                                                                                    <asp:Label runat="server" ID="lblVClear"> Clear?</asp:Label>
                                                                                                                </td>
                                                                                                                <td align="Center" class="lc">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td align="left" class="ic" style="width: 25%;">
                                                                                                                    <asp:Label runat="server" ID="lblClear"></asp:Label>
                                                                                                                </td>
                                                                                                                <td align="left" class="lc" style="width: 25%;">
                                                                                                                    <asp:Label runat="server" ID="lblVAssignTo">Assigned To</asp:Label>
                                                                                                                </td>
                                                                                                                <td align="Center" class="lc">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td align="left" class="ic" style="width: 25%;">
                                                                                                                    <asp:Label runat="server" ID="lblAssignTo"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td colspan="6">
                                                                                                                    &nbsp;
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="ic" align="center" colspan="6">
                                                                                                                    <asp:Button runat="server" ID="btnSaveView" SkinID="btnGen" Text="Save & View" Enabled="false"
                                                                                                                        OnClick="btnSaveView_Click" CausesValidation="false" />
                                                                                                                    <asp:Button runat="server" ID="btnCancel" Text="Cancel" SkinID="btnGen" OnClick="btnCancel_Click"
                                                                                                                        CausesValidation="false" />
                                                                                                                    <asp:Button ID="btnViewAudit" runat="server" Text="View Audit Trail" SkinID="btnGen" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </asp:FormView>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:View>
                                                            </asp:MultiView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
    <div id="divbtn" runat="server">
        <table style="width: 100%;" cellpadding="8">
            <tr>
                <td align="center" class="ic">
                    <asp:Label runat="server" ID="lbl" Text="df" Visible="false"></asp:Label>
                    <asp:Button runat="server" ID="btnNextStep" Text="Next Step" OnClick="btnNextStep_Click"
                        SkinID="btnGen" />
                </td>
            </tr>
        </table>
    </div>
    <div id="divView" runat="server" style="display: none;">
        <table cellpadding="4" cellspacing="2" border="0" style="width: 100%;">
            <tr>
                <td align="left" colspan="6" class="ghc">
                    Claim Details
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
            </tr>
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
                                                Diary Information
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="lblDiaryID" Visible="false" Text='<%#Eval("PK_Diary_ID") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%;" align="left" class="lc">
                                                <asp:Label runat="server" ID="lblVLDONoteEntry">Date of Note Entry</asp:Label>
                                            </td>
                                            <td width="5%" align="Center" class="lc">
                                                :
                                            </td>
                                            <td width="25%" align="left" class="ic">
                                                <asp:Label runat="server" ID="lblVDoActivity" Text='<%# DataBinder.Eval(Container.DataItem,"DateOfNoteEntry","{0:MM/dd/yyyy}") %>'></asp:Label>
                                            </td>
                                            <td width="20%" align="left" class="lc">
                                                <asp:Label runat="server" ID="lblVLDiaryDate">Diary Date</asp:Label>
                                            </td>
                                            <td width="5%" align="Center" class="lc">
                                                :
                                            </td>
                                            <td width="25%" align="left" class="ic">
                                                <asp:Label runat="server" ID="lblVDate" Text='<%# DataBinder.Eval(Container.DataItem,"Diary_Date","{0:MM/dd/yyyy}") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="lc">
                                                <asp:Label runat="server" ID="lblVLNote">Note</asp:Label>
                                            </td>
                                            <td align="Center" class="lc">
                                                :
                                            </td>
                                            <td align="left" class="ic">
                                                <asp:Label runat="server" ID="lblVAuthor" Text='<%#Eval("Note") %>'></asp:Label>
                                            </td>
                                            <td align="left" class="lc">
                                                <asp:Label runat="server" ID="lblVLClear">Clear</asp:Label>
                                            </td>
                                            <td align="Center" class="lc">
                                                :
                                            </td>
                                            <td align="left" class="ic">
                                                <asp:Label runat="server" ID="lblVNoteType" Text='<%#Eval("Clear") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="lc">
                                                <asp:Label runat="server" ID="lblVLAssignTo"> Assigned To </asp:Label>
                                            </td>
                                            <td align="Center" class="lc">
                                                :
                                            </td>
                                            <td align="left" class="ic" colspan="4">
                                                <asp:Label runat="server" ID="lblVUpdateBy" Text='<%#Eval("Assigned_To") %>'></asp:Label>
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
                            Currently there is no Diary for the following claim.
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="6">
                    <asp:Button runat="server" ID="btnViewNext" OnClick="btnViewNext_Click" Text="Next Step" />
                </td>
            </tr>
        </table>
    </div>
    <script language="javascript" type="text/javascript">
        function AuditPopUp(id) {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;
            obj = window.open("AuditPopup_Diary.aspx?id=" + id + '&Table_Name=Diary', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        function ValidateFieldsInsert(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('ctl00_ContentPlaceHolder1_fvDiaryDetails_hdnControlIDsInsert').value.split(',');
            var Messages = document.getElementById('ctl00_ContentPlaceHolder1_fvDiaryDetails_hdnErrorMsgsInsert').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('ctl00_ContentPlaceHolder1_fvDiaryDetails_hdnControlIDsInsert').value != "") {
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

        function ValidateFieldsEdit(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('ctl00_ContentPlaceHolder1_fvDiaryDetails_hdnControlIDsEdit').value.split(',');
            var Messages = document.getElementById('ctl00_ContentPlaceHolder1_fvDiaryDetails_hdnErrorMsgsEdit').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('ctl00_ContentPlaceHolder1_fvDiaryDetails_hdnControlIDsEdit').value != "") {
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
    <asp:CustomValidator ID="CustomValidatorInsert" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsInsert"
        Display="None" ValidationGroup="vsErrorGroupInsert" />
    <asp:CustomValidator ID="CustomValidatorEdit" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsEdit"
        Display="None" ValidationGroup="vsErrorGroupEdit" />
</asp:Content>
