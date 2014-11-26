<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Diary_Search"
    MasterPageFile="~/Default.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>
    <div>
        <table width="100%">
            <tr>
                <td>
                    <div id="dvSearch" runat="server">
                        <table width="100%">
                            <tr>
                                <td style="width: 50%;">
                                    &nbsp;
                                </td>
                                <td style="width: 50%;" align="right">
                                    <table width="80%">
                                        <tr>
                                            <td class="lc">
                                                Search by Assigned To:
                                            </td>
                                            <td class="ic">
                                            </td>
                                            <td class="ic">
                                                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox></td>
                                            <td class="ic">
                                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 20%;" align="left" class="lc">
                                    <asp:Label ID="lblBankDetailsTotal" runat="server"></asp:Label>
                                </td>
                                <td style="width: 80%;" align="right">
                                    <table width="100%">
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
                                                <asp:TextBox ID="txtPageNo" runat="server" Width="20px" onkeypress="return numberOnly(event);"></asp:TextBox>
                                            </td>
                                            <td class="ic">
                                                <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvUser" AllowPaging="true" AllowSorting="True" runat="server" AutoGenerateColumns="false"
                        DataKeyNames="Pk_Assign_Id" Width="100%" OnSorting="gvUser_Sorting">
                        <Columns>
                            <asp:BoundField DataField="AssignBy" HeaderText="Assigned By" SortExpression="AssignBy">
                            </asp:BoundField>
                            <asp:BoundField DataField="Diary_Date" HeaderText="Diary Date" SortExpression="Diary_Date"
                                DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false"></asp:BoundField>
                            <asp:BoundField DataField="ClaimNo" HeaderText="Claim Number" SortExpression="ClaimNo">
                            </asp:BoundField>
                            <asp:BoundField DataField="Note" HeaderText="Note" SortExpression="Note"></asp:BoundField>
                            <asp:TemplateField HeaderText="Clear">
                                <ItemTemplate>
                                    <input name="chkItem" type="radio"  value='<%# Eval("Pk_Assign_Id")%>' />
                                </ItemTemplate>
                                <ItemStyle Width="10px" />
                                <HeaderStyle Width="10px" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnClear" runat="Server" Text="Clear" OnClick="btnClear_Click"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
