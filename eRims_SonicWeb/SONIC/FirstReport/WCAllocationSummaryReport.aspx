<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="WCAllocationSummaryReport.aspx.cs" Inherits="SONIC_FirstReport_WCAllocationSummaryReport" Title="eRIMS Sonic :: First Report :: WC Allocation Summary Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
    <td class="bandHeaderRow" colspan="4" align="left">WC Allocation Summary Report
    </td>
</tr>
<tr>
    <td colspan="4">&nbsp;</td>
</tr>
<tr>
    <td colspan="4">
        <table cellpadding="3" cellspacing="1" border="0" style="text-align: right;width:100%;">
        <tr>
            <td align="right" style="width:18%">Year</td>
            <td align="center" style="width:4%">:</td>
            <td align="left" style="width:28%"><asp:DropDownList runat="Server" ID="ddlYear" SkinID="ddlExposure"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvYear" ControlToValidate="ddlYear" Display="None" 
                    runat="server" InitialValue="0" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please select Year."></asp:RequiredFieldValidator>
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
<tr runat="server" id="trResult">
    <td colspan="4">
    <div style="overflow-y:scroll; width:995px;">
    <asp:GridView ID="gvworkers_comp_summary" runat="server" AutoGenerateColumns="true" Width="100%" OnRowCreated="gvworkers_comp_summary_RowCreated">
    <Columns>
        <asp:TemplateField HeaderText="Dealership">
            <ItemStyle HorizontalAlign="Left" />
            <ItemTemplate>
                <%#Eval("dba") %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Location Code">
        <ItemStyle HorizontalAlign="Left" />
            <ItemTemplate>
                <%#Eval("Sonic_Location_Code") %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="JAN">
        <HeaderStyle HorizontalAlign="right" />
        <ItemStyle HorizontalAlign="Right" />
            <ItemTemplate>
                <%# "$" + clsGeneral.GetStringValue(Eval("JAN"))%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="FEB">
        <HeaderStyle HorizontalAlign="right" />
        <ItemStyle HorizontalAlign="Right" />
            <ItemTemplate>
                <%# "$" + clsGeneral.GetStringValue(Eval("FEB"))%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="MAR">
        <HeaderStyle HorizontalAlign="right" />
        <ItemStyle HorizontalAlign="Right" />
            <ItemTemplate>
                <%# "$" + clsGeneral.GetStringValue(Eval("MAR"))%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="APR">
        <HeaderStyle HorizontalAlign="right" />
        <ItemStyle HorizontalAlign="Right" />
            <ItemTemplate>
                <%# "$" + clsGeneral.GetStringValue(Eval("APR"))%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="MAY">
        <HeaderStyle HorizontalAlign="right" />
        <ItemStyle HorizontalAlign="Right" />
            <ItemTemplate>
                <%# "$" + clsGeneral.GetStringValue(Eval("MAY"))%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="JUN">
        <HeaderStyle HorizontalAlign="right" />
        <ItemStyle HorizontalAlign="Right" />
            <ItemTemplate>
                <%# "$" + clsGeneral.GetStringValue(Eval("JUN"))%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="JUL">
        <HeaderStyle HorizontalAlign="right" />
        <ItemStyle HorizontalAlign="Right" />
            <ItemTemplate>
                <%# "$" + clsGeneral.GetStringValue(Eval("JUL"))%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="AUG">
        <HeaderStyle HorizontalAlign="right" />
        <ItemStyle HorizontalAlign="Right" />
            <ItemTemplate>
                <%# "$" + clsGeneral.GetStringValue(Eval("AUG"))%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SEP">
        <HeaderStyle HorizontalAlign="right" />
        <ItemStyle HorizontalAlign="Right" />
            <ItemTemplate>
                <%# "$" + clsGeneral.GetStringValue(Eval("SEP"))%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OCT">
        <HeaderStyle HorizontalAlign="right" />
        <ItemStyle HorizontalAlign="Right" />
            <ItemTemplate>
                <%# "$" + clsGeneral.GetStringValue(Eval("OCT"))%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="NOV">
        <HeaderStyle HorizontalAlign="right" />
        <ItemStyle HorizontalAlign="Right" />
            <ItemTemplate>
                <%# "$" + clsGeneral.GetStringValue(Eval("NOV"))%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DEC">
        <HeaderStyle HorizontalAlign="right" />
        <ItemStyle HorizontalAlign="Right" />
            <ItemTemplate>
                <%# "$" + clsGeneral.GetStringValue(Eval("DEC"))%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total Count">
        <HeaderStyle HorizontalAlign="right" />
        <ItemStyle HorizontalAlign="Right" />
            <ItemTemplate>
                <%# "$" + clsGeneral.GetStringValue(Eval("Total_Count"))%>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
    <EmptyDataTemplate>
        Currently there is No record found.
    </EmptyDataTemplate>
    </asp:GridView>
    </div>
    </td>
</tr>
</table>
</asp:Content>

