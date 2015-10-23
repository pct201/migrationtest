<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="ACI_Management_Attachment_Download.aspx.cs" Inherits="ACI_Management_Attachment_Download" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Date_Validation.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/jquery-1.5.min.js"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            TocheckUncheck('<%= gvFiles.ClientID%>', "chkAttachmentHeader", "chkAttachmentItem", '<%= hdnAttachmentRowNumber.ClientID %>');
        });

        //This function is used to check that at least one row is selected before go for Remove records.
        function CheckSelectedLetters() {
            if ($('#<%= hdnAttachmentRowNumber.ClientID %>').val() != '') {
                var rowNumbers = $.trim($('#<%= hdnAttachmentRowNumber.ClientID %>').val());
                rowNumbers = rowNumbers.replace(/--/g, ",").replace(/-/g, '');
                var arrRowNumbers = rowNumbers.split(',');
                if (arrRowNumbers.length == 0) {
                    alert("Please select letter(s)!");
                    return false;
                }
                else if (arrRowNumbers.length > 15) {
                    alert("Please select only 15 letters.");
                    return false;
                }
                return true;
            }
            else {
                alert("Please select letter(s)!");
                return false;
            }
        }
    </script>
    <asp:HiddenField ID="hdnAttachmentRowNumber" runat="server" Value="" />
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <table width="100%" cellpadding="0" cellspacing="2">
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;"></td>
        </tr>
        <tr>
            <td align="left" class="ghc">
                <asp:Label ID="lblHeading" runat="server" Text="Management Attachment Download"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;">&nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;">&nbsp;
            </td>
        </tr>
        <tr runat="server" id="trCriteria">
            <td align="center" width="100%">
                <table border="0" cellpadding="5" cellspacing="1" width="80%" align="center">
                    <tr>
                        <td align="left" valign="top">Invoice Date From
                        </td>
                        <td align="center" valign="top">:
                        </td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txtFrom_Date_Of_Invoice" runat="server" Width="160px" SkinID="txtDate"
                                MaxLength="10"></asp:TextBox>
                            <img onclick="return showCalendar('<%= txtFrom_Date_Of_Invoice.ClientID %>', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" alt="" src="../Images/iconPicDate.gif"
                                align="middle" id="img5" />
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtFrom_Date_Of_Invoice"
                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                ErrorMessage="Date of Invoice is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"
                                SetFocusOnError="true">
                            </asp:RegularExpressionValidator>
                        </td>
                        <td align="left" valign="top">To
                        </td>
                        <td align="center" valign="top">:
                        </td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txtTo_Date_Of_Invoice" runat="server" Width="160px" SkinID="txtDate"
                                MaxLength="10"></asp:TextBox>
                            <img onclick="return showCalendar('<%= txtTo_Date_Of_Invoice.ClientID %>', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" alt="" src="../Images/iconPicDate.gif"
                                align="middle" id="img6" />
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtTo_Date_Of_Invoice"
                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                ErrorMessage="To Date of Invoice is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"
                                SetFocusOnError="true">
                            </asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtTo_Date_Of_Invoice"
                                ControlToCompare="txtFrom_Date_Of_Invoice" ValidationGroup="vsErrorGroup" Display="None"
                                Type="Date" Operator="GreaterThanEqual" ErrorMessage="To Date of Invoice must be greater than or equal to from date" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center">
                            <asp:Button runat="server" ID="btnDownload" Text="Download Attachment" OnClick="btnDownload_Click"
                                CausesValidation="true" ValidationGroup="vsErrorGroup" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                OnClick="btnClearCriteria_Click" CausesValidation="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0" runat="server"
        id="tblReport" visible="false">
     
        <tr>
            <td width="100%" class="Spacer" style="height: 5px;"></td>
        </tr>
        <tr id="trGrid" runat="server">
            <td align="left">
                <table width="100%">
                    <tr>
                        <td style="width: 45%">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td class="Spacer" style="height: 10px;"></td>
                                </tr>
                                <tr>
                                    <td align="left">&nbsp;<span class="heading">Management Attachments Results</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">&nbsp; &nbsp;<asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;Attachments
                                            Found
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" align="right">
                            <uc:ctrlPaging ID="ctrlPageProperty" runat="server" OnGetPage="GetPage" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%" colspan="2">
                            <asp:GridView ID="gvFiles" runat="server" Width="100%" AutoGenerateColumns="false"
                                EmptyDataText="No Files Found For Invoice Folder" HeaderStyle-HorizontalAlign="Left"
                                AllowSorting="true" OnSorting="gvFiles_Sorting" OnRowCreated="gvFiles_RowCreated">
                                <%-- OnRowDataBound="gvFiles_RowDataBound" OnRowCommand="gvFiles_RowCommand"--%>
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                        <ItemStyle HorizontalAlign="Left" Width="5%" />
                                        <ItemTemplate>
                                            <%--<input name="chkAttachmentItem" type="checkbox" value='<%# Eval("PK_Attachment")%>' onclick="javascript: UnCheckAttachmentHeader('gvFiles'); AttachmentCheckRemember(this);" />--%>
                                            <input id="chkAttachmentItem" type="checkbox" value='<%# Eval("PK_Attachment")%>' />
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            <%--<input type="checkbox" name="chkAttachmentHeader" id="chkAttachmentHeader" runat="Server" onclick="javascript: SelectAllCheckboxes(this); AttachmentCheckRememberHeader(this)" />--%>
                                            <input type="checkbox" id="chkAttachmentHeader" runat="Server" />
                                        </HeaderTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reference Number" HeaderStyle-HorizontalAlign="Left" SortExpression="Reference_Number">
                                        <ItemStyle Width="12%" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <%# Eval("Reference_Number") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Location" HeaderStyle-HorizontalAlign="Left" SortExpression="dba">
                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <%# Eval("dba") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type" SortExpression="Extension">
                                        <ItemStyle Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblType" runat="server" Text='<%# Convert.ToString(Eval("Extension")) %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Documents from Invoice Folders" SortExpression="Attachment_Description">
                                        <ItemTemplate>
                                            <%# Convert.ToString(Eval("Attachment_Description")) %>
                                            <input type="hidden" id="hdnFileName" runat="server" value='<%#Eval("Attachment_Name") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pages" HeaderStyle-HorizontalAlign="Center" SortExpression="Page_Count">
                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%# Eval("Page_Count") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date Attached" SortExpression="Attach_Date">
                                        <ItemStyle Width="15%" />
                                        <ItemTemplate>
                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Attach_Date")) %>
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
                        <td align="left">
                            <asp:Button ID="btnDownloadAttachment" Text="Download Attachments" runat="server" CausesValidation="false" OnClick="btnDownloadAttachment_Click" 
                                OnClientClick="return CheckSelectedLetters();" />
                            <asp:Button ID="btnBack" Text="Back" runat="server" CausesValidation="false" OnClick="btnBack_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
