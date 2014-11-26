<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="SLT_Safety_Walk_Management_Monthly_Grid.aspx.cs" Inherits="SONIC_SLTSafetyWalk_SLT_Safety_Walk_Management_Monthly_Grid" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>' + 'greybox/';
        function OpenEditFocusArea() {
            var lblYear = document.getElementById('<%=lblYear.ClientID%>').innerText;
            var lblMonth = document.getElementById('<%=lblMonth.ClientID%>').innerText;
            GB_showCenter('Edit Focus Area', '<%=AppConfig.SiteURL%>SONIC/SLTSafetyWalk/EditFocusArea.aspx?Year=' + lblYear + '&Month=' + lblMonth + '&IsAnnual=false', 120, 350, '');
            return false;
        }

    </script>
    <link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>
    <table cellpadding="0" cellspacing="0" width="99%" align="center">
        <tr>
            <td width="100%" class="Spacer" style="height: 20px;"></td>
        </tr>
        <tr>
            <td align="left">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="45%">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td align="left"><span class="heading">SLT Safety Walk Question Management - Monthly</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">&nbsp;
										<asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;Monthly Question(s)
										Found </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" align="right">
                            <uc:ctrlPaging ID="ctrlPageMonthlyQue" runat="server" OnGetPage="GetPage" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;"></td>
        </tr>
        <tr>
            <td class="groupHeaderBar">&nbsp; </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;"></td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="100%" colspan="7" valign="top">
                            <table cellpadding="2" cellspacing="2" border="1px" width="100%">
                                <tr>
                                    <td style="width: 13%" align="left">Year</td>
                                    <td style="width: 4%" align="center">: </td>
                                    <td style="width: 35%" align="left">
                                        <asp:Label ID="lblYear" runat="server"></asp:Label>
                                    </td>
                                    <td style="width: 13%" align="left">Month</td>
                                    <td style="width: 4%" align="center">: </td>
                                    <td style="width: 33%" align="left">
                                        <asp:Label ID="lblMonth" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 20px;"></td>
        </tr>
        <tr>
            <td><a href="#" id="ahrefEditFocusArea" runat="server" onclick="OpenEditFocusArea();">Edit Focus Area</a></td>
             <asp:Button ID="btnhdnReload" runat="server" OnClick="btnhdnReload_Click" style="display:none;" />
        </tr>
        <tr>
            <td class="Spacer" style="height: 20px;"></td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="100%" colspan="7" valign="top">
                            <asp:GridView ID="gvMonthlyQuestions" runat="server" DataKeyNames="PK_LU_SLT_Safety_Walk_Focus_Area"
                                AutoGenerateColumns="false" Width="100%" AllowSorting="True" OnSorting="gvMonthlyQuestions_Sorting"
                                OnRowCommand="gvMonthlyQuestions_RowCommand" OnRowDataBound="gvMonthlyQuestions_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Focus Area" SortExpression="Focus_Area">
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkFocus_Area" runat="server" Text='<%#Eval("Focus_Area")%>'
                                                CommandName="Edit" CommandArgument='<%#Eval("PK_LU_SLT_Safety_Walk_Focus_Area") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sort Order" SortExpression="Sort_Order">
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSort_Order" runat="server" Text='<%#Eval("Sort_Order")%>'
                                                CommandName="Edit" CommandArgument='<%#Eval("PK_LU_SLT_Safety_Walk_Focus_Area") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sorter">
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgUp" ImageUrl="~/Images/arrow_up.png" CommandName="up"
                                                CommandArgument='<%# Eval("PK_LU_SLT_Safety_Walk_Focus_Area") %>' />
                                            <asp:ImageButton runat="server" ID="imgDown" ImageUrl="~/Images/arrow_down.png"
                                                CommandName="down" CommandArgument='<%# Eval("PK_LU_SLT_Safety_Walk_Focus_Area") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Question" SortExpression="Question">
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkQuestion" runat="server" Text='<%#Eval("Question")%>' CommandName="Edit"
                                                CommandArgument='<%#Eval("PK_LU_SLT_Safety_Walk_Focus_Area") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Guidance" SortExpression="Guidance">
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkGuidance" runat="server" Text='<%#Eval("Guidance")%>' CommandName="Edit"
                                                CommandArgument='<%#Eval("PK_LU_SLT_Safety_Walk_Focus_Area") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reference" SortExpression="Reference">
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkReference" runat="server" Text='<%#Eval("Reference")%>' CommandName="Edit"
                                                CommandArgument='<%#Eval("PK_LU_SLT_Safety_Walk_Focus_Area") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Active" SortExpression="Active">
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkActive" runat="server" Text='<%#Eval("Active")%>' CommandName="Edit"
                                                CommandArgument='<%#Eval("PK_LU_SLT_Safety_Walk_Focus_Area") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <table cellpadding="4" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
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
            <td width="100%" class="Spacer" style="height: 20px;"></td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnSearchAgain" runat="server" Text="Search Again" OnClick="btnSearchAgain_Click"
                                ToolTip="Search Again" />
                            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" ToolTip="Add" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 20px;"></td>
        </tr>
    </table>
</asp:Content>
