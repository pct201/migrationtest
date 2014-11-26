<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="WCAllocationLocationReport.aspx.cs" Inherits="SONIC_FirstReport_WCAllocationLocationReport" Title="First Report :: WC Allocation Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
    <td class="bandHeaderRow" colspan="4" align="left">WC Allocation Location Report
    </td>
</tr>
<tr>
    <td colspan="4">&nbsp;</td>
</tr>
<tr>
    <td colspan="4">
        <table cellpadding="3" cellspacing="1" border="0" style="text-align: right;width:100%;">
        <tr>
            <td align="left" style="width:18%">Year<span style="color: Red;">*</span></td>
            <td align="center" style="width:4%">:</td>
            <td align="left" style="width:28%"><asp:DropDownList runat="Server" ID="ddlYear" SkinID="ddlExposure"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvYear" ControlToValidate="ddlYear" Display="None" 
                    runat="server" InitialValue="0" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please select Year."></asp:RequiredFieldValidator>
            </td>
            <td align="left" style="width:18%">Month<span style="color: Red;">*</span></td>
            <td align="center" style="width:4%">:</td>
            <td align="left" style="width:28%">
                <asp:DropDownList runat="Server" ID="ddlMonth" SkinID="ddlExposure">
                <asp:ListItem Value="0" Text = "-- Select --"></asp:ListItem>
                <asp:ListItem Value="1" Text = "January"></asp:ListItem>
                <asp:ListItem Value="2" Text = "February"></asp:ListItem>
                <asp:ListItem Value="3" Text = "March"></asp:ListItem>
                <asp:ListItem Value="4" Text = "April"></asp:ListItem>
                <asp:ListItem Value="5" Text = "May"></asp:ListItem>
                <asp:ListItem Value="6" Text = "June"></asp:ListItem>
                <asp:ListItem Value="7" Text = "July"></asp:ListItem>
                <asp:ListItem Value="8" Text = "August"></asp:ListItem>
                <asp:ListItem Value="9" Text = "September"></asp:ListItem>
                <asp:ListItem Value="10" Text = "October"></asp:ListItem>
                <asp:ListItem Value="11" Text = "November"></asp:ListItem>
                <asp:ListItem Value="12" Text = "December"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvMonth" ControlToValidate="ddlMonth" Display="None" 
                    runat="server" InitialValue="0" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please select Month."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="left" style="width:18%">Location<span style="color: Red;">*</span></td>
            <td align="center" style="width:4%">:</td>
            <td align="left" style="width:28%" colspan="4"><asp:DropDownList runat="Server" ID="ddlLocation" SkinID="default" Width="30%"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="revLocation" ControlToValidate="ddlLocation" Display="None" 
            runat="server" InitialValue="0" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please select Location."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="6" align="center">
                <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click" ValidationGroup="vsErrorGroup" CausesValidation="true" />
            </td>
        </tr>
        <tr>
            <td colspan="6" align="right" style="padding-right:10px;">
                <asp:LinkButton runat="server" ID="lnkExportToExcel" OnClick="lnkExportToExcel_Click" Text="Export To Excel" CausesValidation="false" Visible="false"></asp:LinkButton>
            </td>
        </tr>
        </table>
    </td>
</tr>
<tr>
    <td colspan="4">
    <table cellpadding="0" cellspacing="0" border="0" width="100%" align="center">
    <tr>
        <td>
            <div style="overflow:auto;text-align:left;">
            <asp:GridView ID="gvworkers_comp_charges" runat="server" AutoGenerateColumns="false"  ShowHeader = "true"
            >
            <Columns>
                <asp:TemplateField HeaderText="Claim Number"> 
                    <ItemTemplate>
                        <asp:Label ID="Claim_Number" runat="server" Text='<%#Eval("Claim_Number")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Employee">
                    <ItemTemplate>
                        <asp:Label ID="Employee_Name" runat="server" Text='<%#Eval("Employee_Name")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cause of Incident">
                    <ItemTemplate>
                        <asp:Label ID="Cause_Injury_Body_Part_Description" runat="server" Text='<%#Eval("Cause_Injury_Body_Part_Description")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date of Loss">
                    <ItemTemplate>
                        <asp:Label ID="Date_of_Accident" runat="server" Text='<%# Eval("Date_of_Accident") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_of_Accident"))):""%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date Reported">
                    <ItemTemplate>
                        <asp:Label ID="Date_Reported_to_Insurer" runat="server" Text='<%# Eval("Date_Reported_to_Insurer") !=DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Reported_to_Insurer"))) : "" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Report Lag">
                    <ItemTemplate>
                        <asp:Label ID="Report_Lag" runat="server" Text='<%#Eval("Report_Lag")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date Claim Opened">
                    <ItemTemplate>
                        <asp:Label ID="Date_Entered" runat="server" Text='<%# Eval("Date_Entered") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Entered"))) : ""%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date Claim Closed">
                    <ItemTemplate>
                        <asp:Label ID="Date_Closed" runat="server" Text='<%# Eval("Date_Closed") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Closed"))):"" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date Claim Reopened">
                    <ItemTemplate>
                        <asp:Label ID="Date_claim_Reopened" runat="server" Text='<%# Eval("Date_claim_Reopened") != System.DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_claim_Reopened"))) : "" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Claim Charge">
                    <HeaderStyle HorizontalAlign="right" />
                    <ItemStyle HorizontalAlign="right" />
                    <ItemTemplate>
                        <asp:Label ID="Charge" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("Charge"))%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Penalty Charge">
                <HeaderStyle HorizontalAlign="right" />
                <ItemStyle HorizontalAlign="right" />
                    <ItemTemplate>
                        <asp:Label ID="Late_Penalty_Charge" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("Late_Penalty_Charge"))%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Performance Credit">
                <HeaderStyle HorizontalAlign="right" />
                <ItemStyle HorizontalAlign="right" />
                    <ItemTemplate>
                        <asp:Label ID="Early_Reporting_Performance_Credit" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("Early_Reporting_Performance_Credit"))%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Charge">
                <HeaderStyle HorizontalAlign="right" />
                <ItemStyle HorizontalAlign="right" />
                    <ItemTemplate>
                        <asp:Label ID="Total_Charge" runat="server" Text='<%# "$" + clsGeneral.GetStringValue(Eval("Total_Charge"))%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center"  />
            <EmptyDataTemplate>
                Currently there is No record found.
            </EmptyDataTemplate>
            </asp:GridView>
            </div>
        </td>
    </tr>
    </table>
    </td>
</tr>
</table>
</asp:Content>

