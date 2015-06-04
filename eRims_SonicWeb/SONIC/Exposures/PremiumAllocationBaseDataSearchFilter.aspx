<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="PremiumAllocationBaseDataSearchFilter.aspx.cs" Inherits="SONIC_Exposures_PremiumAllocationBaseDataSearchFilter" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript">
        function formatCurrencyOnBlur(ctrl) {
            if (ctrl.value != '') {
                var val = ctrl.value.replace(",", "").replace(",", "");
                ctrl.value = formatCurrency(val).replace("$", "");
            }
        }

        function yearValidation() {
            document.getElementById()
            if (year.length != 4) {
                alert("Year is not proper. Please check");
                return false;
            }
            return true;
        }

        function openPA_Values_ImportedPopup() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            var StatusFlag = '';

            if (document.getElementById('<%= btnHiddenView.ClientID %>')) {
                StatusFlag = document.getElementById('<%= btnHiddenView.ClientID%>').value;
            }

            obj = window.open("AuditPopup_PA_Values_Imported.aspx?id=" + StatusFlag, 'PopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }


    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsError" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <asp:UpdatePanel runat="server" ID="UpdSearch">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td class="groupHeaderBar" align="left">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="Spacer" style="height: 20px;"></td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <asp:Panel runat="server" ID="pnlSearch">
                                <table cellpadding="4" cellspacing="1" border="0" width="100%">
                                    <tr>
                                        <td class="headerrow">&nbsp;&nbsp;Premium Allocation Base Data Search Filter
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Spacer" style="height: 10px;"></td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <table cellpadding="3" cellspacing="1" width="95%" border="0">
                                                <tr>
                                                    <td align="left" style="width: 12%">Sonic Location Code
                                                    </td>
                                                    <td align="center" style="width: 4%">:
                                                    </td>
                                                    <td align="left" style="width: 36%">
                                                        <asp:DropDownList ID="ddlRMLocationNumber" AutoPostBack="true" SkinID="Default"
                                                            runat="server" OnSelectedIndexChanged="ddlRMLocationNumber_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left" style="width: 14%">Location d/b/a
                                                    </td>
                                                    <td align="center" style="width: 2%">:
                                                    </td>
                                                    <td align="left" style="width: 28%">
                                                        <asp:DropDownList runat="server" ID="ddlLocationdba" AutoPostBack="true" SkinID="Default"
                                                            OnSelectedIndexChanged="ddlLocationdba_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">Year
                                                    </td>
                                                    <td align="center">:
                                                    </td>
                                                    <td align="left" colspan="4">
                                                        <asp:TextBox ID="txtYear" runat="server" Width="180px" MaxLength="4" SkinID="txtYearWithRange" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="Spacer" style="height: 20px;" colspan="6">&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td align="center" style="height: 24px">
                                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CausesValidation="true" ValidationGroup="vsErrorGroup"
                                                            ToolTip="Search" OnClick="btnSearch_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                        <div>
                            <asp:Panel ID="pnlSearchResult" runat="server" Visible="false">
                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                    <tr>
                                        <td class="headerrow">&nbsp;&nbsp; Premium Allocation Base Data Search Filter
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Spacer" style="height: 10px;"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td width="45%">
                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                            <tr>
                                                                <td align="left">
                                                                    <span class="heading">Premium Allocation Results Grid</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">&nbsp;
                                                                    <asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top" align="right">
                                                        <uc:ctrlPaging ID="ctrlPageSonicNotes" runat="server" OnGetPage="ctrlPageSonicNotes_GetPage" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                    <tr>
                                        <td style="margin-left: 40px; width: 100%" align="left" colspan="3">
                                            <asp:GridView ID="gvNotes" runat="server" AutoGenerateColumns="false" Width="100%"
                                                OnRowCommand="gvNotes_RowCommand">
                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                <EmptyDataTemplate>
                                                    <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                        HeaderText="Sonic Location Code">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtSonicLocationCode" runat="server" Text='<%# Eval("Sonic_Location_Code") %>'
                                                                CommandName="EditRecord" CommandArgument='<%#Eval("PK_PA_Values_Imported") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                        HeaderText="Sonic Location DBA">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtdba" runat="server" Text='<%# Eval("dba") %>'
                                                                CommandName="EditRecord" CommandArgument='<%#Eval("PK_PA_Values_Imported") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                        HeaderText="Year">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtYear" runat="server" Text='<%# Eval("Year") %>' CommandName="EditRecord"
                                                                CommandArgument='<%#Eval("PK_PA_Values_Imported") %>' CssClass="TextClip"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                        HeaderText="Non-Texas Payroll">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtNon_Texas_Payroll" runat="server" Text='<%# clsGeneral.FormatCommaSeperatorCurrency(Eval("Non_Texas_Payroll")) %>' CommandName="EditRecord"
                                                                CommandArgument='<%#Eval("PK_PA_Values_Imported") %>' CssClass="TextClip"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                        HeaderText="Texas Payroll">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtTexas_Payroll" runat="server" Text='<%# clsGeneral.FormatCommaSeperatorCurrency(Eval("Texas_Payroll")) %>' CommandName="EditRecord"
                                                                CommandArgument='<%#Eval("PK_PA_Values_Imported") %>' CssClass="TextClip"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                        HeaderText="Total Headcount">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtNumber_Of_Employees" runat="server" Text='<%# Eval("Number_Of_Employees") %>' CommandName="EditRecord"
                                                                CommandArgument='<%#Eval("PK_PA_Values_Imported") %>' CssClass="TextClip"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                        HeaderText="Disposition">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lblView" runat="server" Text='<%# "View" %>' CommandName="ViewRecord"
                                                                CommandArgument='<%#Eval("PK_PA_Values_Imported") %>' CssClass="TextClip"></asp:LinkButton>&nbsp;&nbsp;
                                                            <asp:LinkButton ID="lblEdit" runat="server" Text='<%# "Edit" %>' CommandName="EditRecord"
                                                                CommandArgument='<%#Eval("PK_PA_Values_Imported") %>' CssClass="TextClip"></asp:LinkButton>
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
                                        <td colspan="3" align="center">
                                            <asp:Button ID="btnSearchAgain" runat="server" Text=" Search Again " OnClick="btnSearchAgain_Click" />&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                        <div>
                            <asp:Panel runat="server" ID="pnlEdit" Visible="false">
                                <table cellpadding="4" cellspacing="1" border="0" width="100%">
                                    <tr>
                                        <td class="headerrow">&nbsp;&nbsp;Premium Allocation Base Data
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Spacer" style="height: 10px;"></td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <table cellpadding="3" cellspacing="1" width="95%" border="0">
                                                <tr>
                                                    <td align="left" style="width: 21%">Sonic Location Code
                                                    </td>
                                                    <td align="center" style="width: 4%">:
                                                    </td>
                                                    <td align="left" style="width: 19%">
                                                        <asp:Label ID="lblSonicLocationCode" runat="server">
                                                        </asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 14%">Sonic Location DBA
                                                    </td>
                                                    <td align="center" style="width: 2%">:
                                                    </td>
                                                    <td align="left" style="width: 28%">
                                                        <asp:Label runat="server" ID="lblSonicLocationdba" SkinID="Default">
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">Year <span style="color: Red;">*</span>
                                                    </td>
                                                    <td align="center">:
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtYear1" runat="server" MaxLength="4" SkinID="txtYearWithRange" />
                                                        <asp:RequiredFieldValidator ID="revtxtYear" runat="server" Display="None" ErrorMessage="Please Enter Year."
                                                            ControlToValidate="txtYear1" SetFocusOnError="true" ValidationGroup="vsError"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="rvtxtYearBuilt" runat="server" ControlToValidate="txtYear1"
                                                            ValidationGroup="vsError" Type="Integer" MinimumValue="1"
                                                            MaximumValue="2100" ErrorMessage="Year is not valid."
                                                            Display="None"></asp:RangeValidator>
                                                    </td>
                                                    <td align="left">Total Headcount
                                                    </td>
                                                    <td align="center">:
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtTotalHeadcount" runat="server" MaxLength="4" SkinID="txtYearWithRange" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">Non-Texas Payroll
                                                    </td>
                                                    <td align="center">:
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtNonTexasPayroll" Width="146px" onkeypress="return FormatNumber(event,this.id,15,false,false);" onpaste="return false;" onblur="formatCurrencyOnBlur(this);" runat="server" MaxLength="15" />
                                                    </td>
                                                    <td align="left">Texas Payroll
                                                    </td>
                                                    <td align="center">:
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtTexasPayroll" runat="server" Width="146px" onkeypress="return FormatNumber(event,this.id,15,false,false);" onpaste="return false;" onblur="formatCurrencyOnBlur(this);" MaxLength="15" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        <table>
                                                            <tr>
                                                                <td align="left" style="width: 30%"></td>
                                                                <td align="center" colspan="2">
                                                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"
                                                                        CausesValidation="true" ValidationGroup="vsError" />&nbsp;
                                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />&nbsp;                                                                   
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td style="width: 21%">&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Spacer" style="height: 20px;" colspan="6">&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                        <div>
                            <asp:Panel runat="server" ID="pnlView" Visible="false">
                                <table cellpadding="4" cellspacing="1" border="0" width="100%">
                                    <tr>
                                        <td class="headerrow">&nbsp;&nbsp;Premium Allocation Base Data
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Spacer" style="height: 10px;"></td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <table cellpadding="3" cellspacing="1" width="95%" border="0">
                                                <tr>
                                                    <td align="left" style="width: 21%">Sonic Location Code
                                                    </td>
                                                    <td align="center" style="width: 4%">:
                                                    </td>
                                                    <td align="left" style="width: 19%">
                                                        <asp:Label ID="lblSonicLocationCodeView" SkinID="Default"
                                                            runat="server">
                                                        </asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 14%">Sonic Location DBA
                                                    </td>
                                                    <td align="center" style="width: 2%">:
                                                    </td>
                                                    <td align="left" style="width: 28%">
                                                        <asp:Label runat="server" ID="lblSonicLocationDBAView" SkinID="Default">
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 18%">Year
                                                    </td>
                                                    <td align="center">:
                                                    </td>
                                                    <td align="left" style="width: 13%">
                                                        <asp:Label ID="lblYearView" runat="server" />
                                                    </td>
                                                    <td align="left">Total Headcount
                                                    </td>
                                                    <td align="center">:
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblTotalHeadcountView" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 18%">Non-Texas Payroll
                                                    </td>
                                                    <td align="center">:
                                                    </td>
                                                    <td align="left" style="width: 13%">
                                                        <asp:Label ID="lblNonTexasPayrollView" runat="server" />
                                                    </td>
                                                    <td align="left">Texas Payroll
                                                    </td>
                                                    <td align="center">:
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblTexasPayrollView" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <tr>
                                                            <td>
                                                                <asp:HiddenField ID="btnHiddenView" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 18%">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        <table>
                                                            <tr>
                                                                <td align="left" style="width: 30%"></td>
                                                                <td align="center" colspan="2">
                                                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />&nbsp;
                                                                            <asp:Button ID="btnReturn" runat="server" Text="Cancel" OnClick="btnReturn_Click" />&nbsp;
                                                                             <asp:Button ID="btnViewAuditTrail" runat="server" Text="View Audit Trail" OnClick="btnViewAuditTrail_Click" OnClientClick="javascript:return openPA_Values_ImportedPopup();" />
                                                                    <%--<asp:Button ID="btnViewAuditView" runat="server" Text="View Audit Trail" OnClientClick="javascript:return openPA_Values_ImportedPopup();" />--%>
                                                                </td>
                                                                <td align="left" style="width: 13%"></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="Spacer" style="height: 20px;" colspan="6">&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="Spacer" style="height: 20px;"></td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">
    
    </script>

</asp:Content>
