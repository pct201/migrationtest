<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="PolicySearchResult.aspx.cs" Inherits="Policy_PolicySearchResult" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../JavaScript/JFunctions.js" language="javascript"></script>

    <link href="../App_Themes/Default/Default.css" type="text/css" rel="Stylesheet" />

    <script language="javascript" type="text/javascript">
        function CheckNumericVal(Ctl) {
            if (Ctl.value == "" || isNaN(Number(Ctl.value.replace(/,/g, '')) * 1) == true)
                Ctl.innerText = "1";
        }
        function ChkLength() {
            var length;
            var strValue;
            strValue = document.getElementById("ctl00_ContentPlaceHolder1_txtPolicyYear").value;
            if (strValue.length != 0) {
                if (strValue.length > 4 || strValue.length < 4) {
                    alert("Please Insert 4 Digit Policy Year");
                    return false;
                }
            }
            return true;
        }
    </script>

    <div runat="server" id="dvSearchGrid" style="display: none; width: 98%;">
        <table cellpadding="0" cellspacing="2" style="width: 100%" border="0">
            <tr>
                <td align="center" class="lc" style="width: 30%" valign="left">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td align="left">
                                <span class="heading">&nbsp;Policy Search Grid</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                &nbsp;
                                <asp:Label ID="lblNoOfRecord" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 70%" align="right">
                    <table width="85%">
                        <tbody>
                            <tr>
                                <td class="lc" valign="middle">
                                    No. of Records per page :&nbsp;
                                    <asp:DropDownList ID="ddlPage" runat="server" SkinID="dropGen" CssClass="pagingfields"
                                        DataSourceID="xdsPaging" AutoPostBack="True" DataValueField="Value" OnSelectedIndexChanged="ddlPage_SelectedIndexChanged"
                                        DataTextField="Text">
                                    </asp:DropDownList>
                                    <asp:XmlDataSource ID="xdsPaging" runat="server" DataFile="~/App_Data/PagingTable.xml">
                                    </asp:XmlDataSource>
                                </td>
                                <td class="ic" valign="middle">
                                    <asp:Button ID="btnPrev" OnClick="btnPrev_Click" runat="server" Text=" < "></asp:Button>
                                </td>
                                <td class="lc" valign="middle">
                                    <asp:Label ID="lblPageInfo" Width="90px" runat="server"></asp:Label>
                                </td>
                                <td class="ic" valign="middle">
                                    <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text=" > "></asp:Button>
                                </td>
                                <td class="lc" valign="middle">
                                    Go to Page:
                                </td>
                                <td class="ic" valign="middle">
                                    <asp:Panel runat="server" ID="pnl" DefaultButton="btnGo">
                                        <asp:TextBox ID="txtPageNo" onkeypress="return numberOnly(event);" runat="server"
                                            MaxLength="4" Width="20px" OnBlur="CheckNumericVal(this);" Text="1"></asp:TextBox>
                                    </asp:Panel>
                                </td>
                                <td class="ic" valign="middle">
                                    <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click"></asp:Button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="Spacer" colspan="2" style="height: 10px;">
                </td>
            </tr>
            <tr>
                <td colspan="2" class="groupHeaderBar">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="Spacer" colspan="2" style="height: 20px;">
                </td>
            </tr>
            <tr>
                <td class="ic" align="left" colspan="2">
                    <asp:GridView runat="server" ID="gvSearch" AllowPaging="true" Width="100%" PagerSettings-Visible="false"
                        AllowSorting="true" AutoGenerateColumns="false" OnRowCommand="gvSearch_RowCommand"
                        OnRowCreated="gvSearch_RowCreated" OnSorting="gvSearch_Sorting" OnRowDataBound="gvSearch_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="PK_Policy_Id" Visible="false" />
                            <asp:BoundField HeaderText="Location" DataField="Location" SortExpression="Location"
                                ItemStyle-Width="15%" />
                            <asp:BoundField HeaderText="Program" DataField="Program" SortExpression="Program"
                                ItemStyle-Width="10%" />
                            <asp:BoundField HeaderText="Policy Type" DataField="Str_Policy_Type" SortExpression="Str_Policy_Type"
                                ItemStyle-Width="15%" />
                            <asp:BoundField HeaderText="Insurance Carrier" DataField="Carrier" SortExpression="Carrier"
                                ItemStyle-Width="17%" />
                            <asp:BoundField HeaderText="Policy Number" DataField="Policy_Number" SortExpression="Policy_Number"
                                ItemStyle-Width="15%" />
                            <asp:BoundField HeaderText="Policy Year" DataField="Policy_Year" SortExpression="Policy_Year"
                                ItemStyle-Width="8%" />
                            <asp:TemplateField HeaderText="Action" ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%# Eval("PK_Policy_Id") %>'
                                        ToolTip="View Policy" />
                                    <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%# Eval("PK_Policy_Id") %>'
                                        runat="server" Text="Edit" ToolTip="Edit Policy" />
                                    <asp:Button ID="btnDelete" CommandName="Delete Item" CommandArgument='<%# Eval("PK_Policy_Id") %>'
                                        runat="server" Text="Delete" ToolTip="Delete Policy" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
                        <EmptyDataTemplate>
                            No data found.<br />
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>           
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnAddNew" runat="server" Text="Add New" OnClick="btnAddNew_Click" />
                    <asp:Button ID="btnBack" runat="server" Text="Back To Search" OnClick="btnBack_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
