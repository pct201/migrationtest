<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="COIList.aspx.cs"
    Inherits="Admin_COIList" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script type="text/javascript">
        // Confirm Before Delete a record
        function ConfirmDelete(insured, issue_date) {
            //insured=insured.replace("singlequot","'");
            return confirm("Are you sure that you want to remove the data that was selected for deletion?");
        }

        function CheckSelected() {
            var ctrls = document.getElementsByTagName('input');
            var i = 0, cnt = 0;
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("Select") > 0) {
                    if (ctrls[i].checked)
                        cnt++;
                }
            }
            if (cnt > 0)
                return true;
            else {
                alert("Please select Insured");
                return false;
            }
        }
    </script>

    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td align="left">
                <table cellpadding="3" cellspacing="0" width="100%">
                    <tr>
                        <td width="45%">
                            &nbsp;<span class="heading">Certificate of Insurance Search Results</span><br />
                            &nbsp;<asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;COIs Found
                        </td>
                        <td valign="top" align="right">
                            <uc:ctrlPaging ID="ctrlPageCOI" runat="server" OnGetPage="GetPage" />
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
                            <asp:GridView ID="gvCOI" runat="server" Width="100%" OnRowCommand="gvCOI_RowCommand"
                                AllowSorting="true" OnRowDataBound="gvCOI_RowDataBound" OnRowCreated="gvCOI_RowCreated"
                                OnSorting="gvCOI_Sorting">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemStyle Width="4%" HorizontalAlign="Center" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                            <input type="hidden" id="hdnCOIID" runat="server" value='<%#Eval("PK_COIs")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Insured" SortExpression="Insured_Name">
                                        <ItemStyle Width="21%" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <%#Eval("Insured_Name")%></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Address" SortExpression="Address_1">
                                        <ItemStyle Width="21%" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <%# clsGeneral.FormatAddress(Eval("Address_1"),Eval("Address_2"),string.Empty,string.Empty,string.Empty)%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="City" SortExpression="City">
                                        <ItemStyle Width="16%" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <%#Eval("City")%></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="State" SortExpression="State">
                                        <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <%#Eval("State")%></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date Received" SortExpression="Issue_Date">
                                        <ItemStyle Width="14%" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Issue_Date"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Disposition ">
                                        <ItemStyle HorizontalAlign="Left" Width="17%" />
                                        <ItemTemplate>
                                            <table cellpadding="2" cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="left">
                                                        <asp:Button ID="lnkEdit" runat="server" Text=" Edit " CommandName="EditCOI" CommandArgument='<%#Eval("PK_COIs")%>' />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Button ID="lnkView" runat="server" Text="View" CommandName="ViewCOI" CommandArgument='<%#Eval("PK_COIs")%>' />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="lnkDelete" runat="server" Text="Delete" CommandName="DeleteCOI" CommandArgument='<%#Eval("PK_COIs")%>'
                                                            OnClientClick="return ConfirmDelete();" />
                                                    </td>
                                                </tr>
                                            </table>
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
                <asp:Button ID="btnSearch" runat="server" SkinID="Search" OnClick="btnSearch_Click" />&nbsp;&nbsp;
                &nbsp; &nbsp;
                <asp:Button ID="btnAddNew" runat="server" SkinID="AddNew" OnClick="btnAddNew_Click" />
                <asp:Button ID="btnGenerateCOI" runat="server" Text="Generate COI" CssClass="buttonGeneral"
                    OnClick="btnGenerateCOI_Click" OnClientClick="return CheckSelected();" />
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
    </table>
</asp:Content>
