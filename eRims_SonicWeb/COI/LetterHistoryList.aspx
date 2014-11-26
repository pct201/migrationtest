<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="LetterHistoryList.aspx.cs"
    Inherits="Admin_LetterHistoryList" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script type="text/javascript" src="../JavaScript/JFunctions.js">
    </script>

    <script language="javascript" type="text/javascript">
        function checkCondition() {
            if (Page_ClientValidate("valSelectSign"))
                return OMSCheckSelected1('chkItem', 'gvLetterHistory', '');
            else return false;
        }
    </script>

    <table cellpadding="0" cellspacing="0" width="100%" class="noPrint">
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-right: 5px">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="45%">
                            &nbsp; &nbsp;<span class="heading">Letter History Search Results</span><br />
                            &nbsp;&nbsp; &nbsp;<asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;Letter
                            Histories Found
                        </td>
                        <td valign="top" align="right">
                            <uc:ctrlPaging ID="ctrlPageLetterHistory" runat="server" OnGetPage="GetPage" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="text-align: center; font-size: 11pt; font-family: Times New Roman; color: Red"
            class="noPrint">
            <td colspan="3">
                <asp:Label Text="" EnableViewState="false" ID="lblMessage" runat="Server"></asp:Label>
            </td>
        </tr>
        <tr style="text-align: center; font-size: 11pt; font-family: Times New Roman" class="noPrint">
            <td colspan="3">
                <div style="text-align: center;">
                    <asp:LinkButton ID="lnkPrintLetters" runat="server" OnClick="lnkPrintLetters_Click">Print Letters</asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="lnkPrintEnvelopes" runat="server" OnClick="lnkPrintEnvelopes_Click">Print Envelopes</asp:LinkButton>
                </div>
            </td>
        </tr>
        <tr valign="top">
            <td colspan="3" align="right" valign="top" style="padding-right: 5px">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="10%" align="Right">
                            Select a Signature
                        </td>
                        <td width="4%" align="center">
                            :
                        </td>
                        <td align="left" width="30%">
                            <asp:DropDownList ID="drpSignature" runat="server" onchange="HidePrintLinks();" AutoPostBack="true"
                                onclick="Page_ClientValidate('dummy')" OnSelectedIndexChanged="drpSignature_SelectedIndexChanged" />
                        </td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="rfvSignature" runat="server" ErrorMessage="Please Select a Signature"
                                InitialValue="--Select--" ControlToValidate="drpSignature" SetFocusOnError="true"
                                ValidationGroup="valSelectSign" />
                        </td>
                        <td align="right">
                            <asp:LinkButton ID="lnkGenerateReports" runat="server" OnClick="lnkGenerateReports_Click"
                                OnClientClick="javascript:return checkCondition()" CausesValidation="true">Regenerate Letters</asp:LinkButton>
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
                            <asp:GridView ID="gvLetterHistory" runat="server" Width="100%" DataKeyNames="PK_COI_Letter_History,FK_COIs"
                                AllowSorting="true" OnRowDataBound="gvLetterHistory_RowDataBound" OnRowCreated="gvCOI_RowCreated"
                                OnSorting="gvCOI_Sorting" OnRowCommand="gvLetterHistory_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="">
                                        <ItemStyle Width="3%" HorizontalAlign="left" VerticalAlign="top" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Insured" SortExpression="CI.Insured_Name">
                                        <ItemStyle Width="14%" HorizontalAlign="left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <%#Eval("Insured_Name")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Address" SortExpression="CI.Address_1">
                                        <ItemStyle Width="20%" HorizontalAlign="left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <%# clsGeneral.FormatAddress(Eval("Address_1"), Eval("Address_2"), Eval("City"), Eval("FLD_abbreviation"), Eval("Zip_Code"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="City" SortExpression="CI.City">
                                        <ItemStyle Width="10%" HorizontalAlign="left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <%#Eval("City")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="State" SortExpression="S.FLD_abbreviation">
                                        <ItemStyle Width="9%" HorizontalAlign="left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <%#Eval("FLD_abbreviation")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Issue Date" SortExpression="C.Issue_Date">
                                        <ItemStyle Width="11%" HorizontalAlign="left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <%#Convert.ToDateTime(Eval("Issue_Date")).ToString(AppConfig.DisplayDateFormat)%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date Letter Sent" SortExpression="L.Date_Letter_Sent">
                                        <ItemStyle Width="13%" HorizontalAlign="left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <%#Convert.ToDateTime(Eval("Date_Letter_Sent")).ToString(AppConfig.DisplayDateFormat)%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Letter Level" SortExpression="Level">
                                        <ItemStyle Width="10%" HorizontalAlign="left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <%#Eval("Level")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Disposition" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Button ID="lnkView" runat="server" Text="View" CommandName="ViewLetters" CausesValidation="false"
                                                CommandArgument='<%#Eval("PK_COI_Letter_History")%>' />&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="lnkDelete" runat="server" Text="Delete" CommandName="DeleteLetters"
                                                CausesValidation="false" CommandArgument='<%#Eval("PK_COI_Letter_History")%>'
                                                OnClientClick="return confirm('Are you sure that you want to remove the data that was selected for deletion?');" />
                                            </a>
                                        </ItemTemplate>
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
            <td width="100%" class="Spacer" style="height: 20px;" align="center">
                <asp:Button ID="btnBack" SkinID="Back" runat="server" OnClick="btnBack_Click" />
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 5px;">
                &nbsp;
            </td>
        </tr>
    </table>
    <div style="display: none; color: Black" id="dvLetters">
        <asp:Literal ID="litLetter" runat="Server"></asp:Literal>
    </div>
    <div style="display: none; color: Black" id="dvEnvelopes">
        <asp:Literal ID="litEnvelopes" runat="Server"></asp:Literal>
    </div>
    <div style="text-align: left; font-size: 12pt; font-family: Times New Roman; color: Black"
        id="dvPrint" class="noScreen">
    </div>

    <script type="text/javascript">
        function PrintLetter() {
            objLetter = document.getElementById('dvLetters');
            objPrint = document.getElementById('dvPrint');
            objPrint.innerHTML = objLetter.innerHTML;
            document.title = '';
            window.print();
            objPrint.innerHTML = '';
            return false;
        }
        function PrintEnvelopes() {
            objEnv = document.getElementById('dvEnvelopes');
            objPrint = document.getElementById('dvPrint');
            objPrint.innerHTML = objEnv.innerHTML;
            document.title = '';
            window.print();
            objPrint.innerHTML = '';
            return false;
        }
        function HidePrintLinks() {
            document.getElementById('<%=lblMessage.ClientID%>').style.display = "none";
            if (document.getElementById('<%=lnkPrintLetters.ClientID%>') != null)
                document.getElementById('<%=lnkPrintLetters.ClientID%>').style.display = "none";

            if (document.getElementById('<%=lnkPrintEnvelopes.ClientID%>') != null)
                document.getElementById('<%=lnkPrintEnvelopes.ClientID%>').style.display = "none";
        }
    </script>

</asp:Content>
