<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="WallSearchByLocation.aspx.cs" Inherits="Administrator_WallSearchByLocation" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Date_Validation.js"></script>
    <script language="javascript" type="text/javascript">

        function CheckSelected1() {
            var ctrls = document.getElementsByTagName('input');
            var i;
            var cnt = 0;
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkItemID") > -1) {
                    if (ctrls[i].checked)
                        cnt++;
                }
            }

            if (cnt == 0) {
                alert("Please select an messages to remove.");
                return false;
            }
            else {
                return confirm("Are you sure to remove messages(s)?");
            }
        }

        function ConfirmDelete(CheckboxControlId) {
            var isChecked = false;
            var IsCount = false;
            for (i = 0; i < document.forms[0].elements.length; i++) {
                if ((document.forms[0].elements[i].type == 'checkbox') && (document.forms[0].elements[i].name != "chkHeader")) {
                    if (document.forms[0].elements[i].checked == true) {
                        isChecked = true;
                    }
                }
            }

            var grid = document.getElementById('ctl00_ContentPlaceHolder1_gvWallSearch');

            if (grid != null && grid.rows.length > 1) {
                for (i = 1; i < grid.rows.length; i++) {
                    if (document.getElementById(grid.rows[i].cells[0].firstChild.id).checked == true) {

                        var hdnField = document.getElementById("ctl00_ContentPlaceHolder1_gvWallSearch_ctl0" + (i + 1) + "_hdnCount");
                        if (hdnField != null) {
                            if (parseInt(hdnField.value) > 0) {
                                IsCount = true;
                                break;
                            }
                        }
                    }
                }
            }

            if (!isChecked) {
                alert('Please select at least one record to delete.');
                return false;
            }
            else {
                var chkheader = document.getElementById('ctl00_ContentPlaceHolder1_gvWallSearch_ctl01_chkHeader');
                if (chkheader.checked) {
                    if (IsCount == true)
                        if (grid.rows.length == 2)
                            return confirm('You have selected to delete all of the marked messages which have one or more comments associated with them. Continue?');
                        else
                            return confirm('You have selected to delete all of the marked messages which may have one or more comments associated with them. Continue?');
                    else
                        return confirm('You have selected to delete all of the marked messages. Continue?');
                }
                else {
                    if (IsCount == true)
                        return confirm('You have selected to delete all of the marked messages which may have one or more comments associated with them. Continue?');
                    else
                        return confirm('Are you sure that you want to remove the data that was selected for deletion?');
                }
            }

        }
    </script>
     <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <div id="dvSearch" runat="server">
        <table cellpadding="1" cellspacing="0" width="100%" align="center">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="ghc" align="center">
                    Wall Search By Location
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table cellpadding="5" cellspacing="0" border="0" width="70%">
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="15%">
                                Poster Last Name
                            </td>
                            <td align="center" width="5%">
                                :
                            </td>
                            <td align="left" colspan="4">
                                <asp:TextBox ID="txtPosterLastName" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Poster First Name
                            </td>
                            <td align="center" width="5%">
                                :
                            </td>
                            <td align="left" colspan="4">
                                <asp:TextBox ID="txtPosterFirstName" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="15%">
                                Date of Post From
                            </td>
                            <td align="center" width="5%">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDatePostFrom" runat="server" Width="180px" SkinID="txtDate"
                                    MaxLength="10"></asp:TextBox>
                                <img onclick="return showCalendar('<%= txtDatePostFrom.ClientID %>', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" alt="" src="../Images/iconPicDate.gif"
                                    align="middle" id="img2" />
                                <cc1:maskededitextender ID="MaskedEditExtender1" runat="server" AcceptNegative="Left"
                                    DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                    OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDatePostFrom"
                                    CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                </cc1:maskededitextender>
                                <br />
                                <asp:RegularExpressionValidator ID="revtxtDatePostFrom" runat="server" ControlToValidate="txtDatePostFrom"
                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                    ErrorMessage=" Date of Post From is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"
                                    SetFocusOnError="true">
                                </asp:RegularExpressionValidator>
                            </td>
                            <td align="left" width="14%">
                                Date of Post To
                            </td>
                            <td align="center" width="2%">
                                :
                            </td>
                            <td align="left">
                              
                                <asp:TextBox ID="txtDatePostTo" runat="server" Width="180px" SkinID="txtDate"
                                    MaxLength="10"></asp:TextBox>
                                <img onclick="return showCalendar('<%= txtDatePostTo.ClientID %>', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" alt="" src="../Images/iconPicDate.gif"
                                    align="middle" id="img1" />
                                <cc1:maskededitextender ID="MaskedEditExtender2" runat="server" AcceptNegative="Left"
                                    DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                    OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDatePostTo"
                                    CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                </cc1:maskededitextender>
                                <br />
                                <asp:RegularExpressionValidator ID="rfvtxtDatePostTo" runat="server" ControlToValidate="txtDatePostTo"
                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                    ErrorMessage="  Date of Post To is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"
                                    SetFocusOnError="true">
                                </asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="cvCompDate" runat="server" ControlToValidate="txtDatePostTo"
                                    ValidationGroup="vsErrorGroup" ErrorMessage="Date of Post From must be Less than or equal to Date of Post To"
                                    Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtDatePostFrom" Display="none">
                                </asp:CompareValidator>
                            </td>
                        </tr>
                         <tr>
                            <td align="left" valign="top">
                                Topic
                            </td>
                            <td align="center" width="5%" valign="top">
                                :
                            </td>
                            <td align="left" colspan="4">
                                <asp:TextBox ID="txtTopic" runat="server" MaxLength="250"
                                    Width="520px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Post Text
                            </td>
                            <td align="center" width="5%" valign="top">
                                :
                            </td>
                            <td align="left" colspan="4">
                                <asp:TextBox ID="txtPostText" TextMode="MultiLine" Rows="4" runat="server" MaxLength="4000"
                                    Width="520px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" class="Spacer" style="height: 15px;" colspan="6">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="6">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" SkinID="btnGen" OnClick="btnSearch_Click"
                                    CausesValidation="true" ValidationGroup="vsErrorGroup" />
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" class="Spacer" style="height: 15px;" colspan="6">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="100%" class="Spacer" style="height: 15px;">
                </td>
            </tr>
        </table>
    </div>
    <div id="dvSearchResult" runat="server" visible="false">
        <table cellpadding="1" cellspacing="1" width="100%">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="ghc" align="center">
                    Search Result
                </td>
            </tr>
            <tr>
                <td width="100%" class="Spacer" style="height: 10px;">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <table cellpadding="3" cellspacing="0" width="100%">
                        <tr>
                            <td width="45%">
                                &nbsp;<span>Post Found :</span>&nbsp;<asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>
                            </td>
                            <td valign="top" align="right">
                                <uc:ctrlPaging ID="ctrlPageWallPost" runat="server" OnGetPage="GetPage" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 10px;" colspan="3">
                </td>
            </tr>
            <tr>
                <td width="100%" class="dvContent">
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="left">
                                <asp:GridView ID="gvWallSearch" runat="server" Width="100%" OnRowCommand="gvWallSearch_RowCommand" AutoGenerateColumns="false"
                                    AllowSorting="true" OnRowCreated="gvWallSearch_RowCreated" DataKeyNames="PK_Wall_By_Location" OnRowDataBound="gvWallSearch_RowDataBound"
                                    OnSorting="gvWallSearch_Sorting" Style="word-wrap: normal; word-break: break-all;">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemStyle Width="6%" HorizontalAlign="Center" VerticalAlign="Top" />
                                            <HeaderStyle Width="6%" HorizontalAlign="Center" VerticalAlign="Top" />
                                            <HeaderTemplate>
                                                <input type="checkbox" name="chkHeader" id="chkHeader" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <input name="chkItem" id="chkItemID" type="checkbox" value='<%# Eval("PK_Wall_By_Location")%>' onclick="javascript:UnCheckHeader('gvWallSearch')" />
                                                <asp:HiddenField ID="hdnCount" Value='<%#Eval("CommentCount") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Poster Last Name" SortExpression="Last_Name">
                                            <ItemStyle Width="16%" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <%#Eval("Last_Name")%></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Poster First Name" SortExpression="First_Name">
                                            <ItemStyle Width="16%" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <%#Eval("First_Name")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Topic" SortExpression="Topic">
                                            <ItemStyle Width="34%" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <%#Eval("Topic")%></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date of Post" SortExpression="Update_Date">
                                            <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Update_Date"))%></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Type" SortExpression="Type">
                                            <ItemStyle Width="8%" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <%#Eval("Type")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Disposition ">
                                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEdit" runat="server" Text=" Edit " CommandName="EditWall"
                                                    CommandArgument='<%#Eval("PK_Wall_By_Location")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="lblMsg" runat="server" Text="No records found" SkinID="Message"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="100%" class="Spacer" style="height: 10px;">
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnSearchAgain" runat="server" SkinID="Search" OnClick="btnSearchAgain_Click" />&nbsp;&nbsp;
                    &nbsp; &nbsp;
                    <asp:Button ID="btnDelete" runat="server" Text=" Delete " SkinID="btnGen" OnClick="btnDelete_Click" OnClientClick="return CheckSelected1();"/>
                    &nbsp; &nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text=" Cancel " SkinID="btnGen" OnClick="btnCancel_Click" />
                </td>
            </tr>
            <tr>
                <td width="100%" class="Spacer" style="height: 10px;">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

