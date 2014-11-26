<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostCheckRegister.aspx.cs"
    Inherits="CheckWriting_PostCheckRegister" MasterPageFile="~/Default.master" Theme="Default"
      %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>

    <link href="../App_Themes/Default/stylecal.css" type="text/css" rel="Stylesheet" />
    <asp:ScriptManager ID="smBankDetail" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="pnlBankDetail" runat="server">
        <contenttemplate>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" CssClass="errormessage" ValidationGroup="vsErrorGroup"
            EnableClientScript="true" BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
        <asp:CustomValidator ID="cvErrorMsg" runat="server" ValidationGroup="vsErrorGroup"
            EnableClientScript="true" Display="None" ErrorMessage=""></asp:CustomValidator>
    </div>
    <table width="100%">
        <tr>
            <td class="ghc">
                <asp:Label ID="lblHeader" runat="server" Text="Post-Check Register"></asp:Label>
            </td>
        </tr>
        <tr id="trSearch" runat="server">
            <td align="center">
                <table width="45%" style="text-align: center;">
                    <tr valign="middle" style="height: 425px;">
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td colspan="3" class="lc" align="left">
                                        <asp:Label ID="lblPage" runat="server" Text="Search Check Printed"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50%" class="lc" align="left">
                                        From&nbsp;<asp:TextBox ID="txtDtStart" runat="server" ValidationGroup="vsErrorGroup" ></asp:TextBox>
                                        <%--<img style="vertical-align: baseline" id="imgStartDate" onclick="popUpCalendar(this,ctl00$ContentPlaceHolder1$txtDtStart,'mm/dd/yyyy');"
                                            height="17" alt="Calendar" src="../Images/iconPicDate.gif" runat="server" />--%>
                                            <img runat="Server" id="imgStartDate" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDtStart', 'mm/dd/y');"
                                                      onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif" align="absmiddle" />
                                       
                                        <cc1:MaskedEditExtender ID="mskExDtStart" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                            Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                            OnInvalidCssClass="MaskedEditError" TargetControlID="txtDtStart" CultureName="en-US"
                                            AutoComplete="true" AutoCompleteValue="05/23/1964">
                                        </cc1:MaskedEditExtender>
                                    </td>
                                    <td class="lc" align="center">
                                        To&nbsp;
                                    </td>
                                    <td class="lc" style="width: 50%;" align="left">
                                        <asp:TextBox ID="txtDtEnd" runat="server" ></asp:TextBox>
                                        <%--<img style="vertical-align: baseline" id="imgEndDate" onclick="popUpCalendar(this,ctl00_ContentPlaceHolder1_txtDtEnd,'mm/dd/yyyy');"
                                            height="17" alt="Calendar" src="../Images/iconPicDate.gif" runat="server" />--%>
                                           <img runat="Server" id="imgEndDate" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDtEnd', 'mm/dd/y');"
                                                      onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif" align="absmiddle" />
                                        
                                        <cc1:MaskedEditExtender ID="mskExDtEnd" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                            Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                            OnInvalidCssClass="MaskedEditError" TargetControlID="txtDtEnd" CultureName="en-US"
                                            AutoComplete="true" AutoCompleteValue="05/23/1964">
                                        </cc1:MaskedEditExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50%" class="lc" align="left">
                                        <%--<cc1:MaskedEditValidator ID="mskValDtStart" runat="server" ControlExtender="mskExDtStart"
                                            ControlToValidate="txtDtStart" Display="none" IsValidEmpty="False" MaximumValue=""
                                            EmptyValueMessage="Enter Start Date." InvalidValueMessage="Date Not Valid(Start Date)"
                                            MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue=""
                                            ValidationGroup="vsErrorGroup"></cc1:MaskedEditValidator>--%>
                                            <asp:RegularExpressionValidator ID="revStartDt" runat="server" ControlToValidate="txtDtStart"
                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                ErrorMessage="Date Not Valid(Start Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="rfvStart" ControlToValidate="txtDtStart" runat="server" ErrorMessage="Enter Start Date." Display="none" ValidationGroup="vsErrorGroup">
                                            </asp:RequiredFieldValidator>   
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td style="width: 50%" class="lc" align="left">
                                        <%--<cc1:MaskedEditValidator ID="mskValDtEnd" runat="server" ControlExtender="mskExDtEnd"
                                            ControlToValidate="txtDtEnd" Display="none" IsValidEmpty="False" MaximumValue=""
                                            EmptyValueMessage="Enter End Date." InvalidValueMessage="Date Not Valid(End Date)"
                                            MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue=""
                                            ValidationGroup="vsErrorGroup"></cc1:MaskedEditValidator>--%>
                                            <asp:RegularExpressionValidator ID="revEndDt" runat="server" ControlToValidate="txtDtEnd"
                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                ErrorMessage="Date Not Valid(End Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="rfvEnd" ControlToValidate="txtDtEnd" runat="server" ErrorMessage="Enter End Date." Display="none" ValidationGroup="vsErrorGroup">
                                            </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ic" colspan="3" align="center">
                                        <asp:Button ID="btnSearch" Text="Search" runat="server" ValidationGroup="vsErrorGroup"
                                            OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="trDetails" runat="server">
            <td>
                <table width="100%">
                    <tr><td colspan="2" style="width: 80%;" align="right">
                    <table width="50%">
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
                            Go to Page:</td>
                        <td class="ic">
                            <asp:TextBox ID="txtPageNo" MaxLength="3" runat="server" Width="20px" onkeypress="return numberOnly(event);"></asp:TextBox>
                        </td>
                        <td class="ic">
                            <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" /></td>
                    </tr>
                    </table>
                    </td></tr>
                    <tr>
                        <td>
                        &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left;" colspan="2">
                            <asp:GridView ID="gvChkPostRegister" runat="server" Width="100%" AllowPaging="true"
                                AllowSorting="true" AutoGenerateColumns="false" OnSorting="gvChkPostRegister_Sorting" OnPageIndexChanging="gvChkPostRegister_PageIndexChanging" OnRowCreated="gvChkPostRegister_RowCreated">
                                <Columns>
                                    <%--<asp:TemplateField>
                                        <ItemTemplate>
                                            <input name="chkItem" type="checkbox" value='<%# Eval("Pk_check_no")%>' onclick="javascript:ErimsUnChekcHeader()" />
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" />
                                        <HeaderTemplate>
                                            <input id="chkHeader" name="chkHeader" type="checkbox"  runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                        </HeaderTemplate>
                                        <HeaderStyle Width="10px" />
                                    </asp:TemplateField>--%>
                                    <asp:BoundField DataField="CEDClaimNo" HeaderText="Claim Number" SortExpression="CEDClaimNo" />
                                    <asp:BoundField DataField="AEPPayer" HeaderText="Claimant/Employee" SortExpression="AEPPayer">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AEPPayee" HeaderText="Payee" SortExpression="AEPPayee"></asp:BoundField>
                                    <asp:BoundField DataField="CDCheckNumber" HeaderText="Check Number" SortExpression="CDCheckNumber">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RecIssueDate" HeaderText="Issue Date" SortExpression="RecIssueDate"
                                        DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false" />
                                    <asp:BoundField DataField="Check_Amount" HeaderText="Payment Amount" SortExpression="Check_Amount"
                                        DataFormatString="{0:C}" HtmlEncode="false" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"></asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    Currently There Is No Post Register Check.
                                </EmptyDataTemplate>
                                  <PagerSettings Visible="false" />
                                        <PagerStyle BackColor="#7F7F7F" BorderColor="#7F7F7F" HorizontalAlign="Left" VerticalAlign="Middle"  />
                                     
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%; color: Red; font-weight: bolder;" align="left" class="lc">
                            Total of all records</td>
                        <td style="width: 50%; padding-right: 5px;" align="right" class="lc">
                            <asp:Label ID="lblTotalAmount" runat="server"></asp:Label></td>
                    </tr>
                    <tr style="height:20px;">
                        <td align="center" colspan="2">
                            <asp:Button ID="btnBack" runat="server" Text="Back to Search" OnClick="btnBack_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
