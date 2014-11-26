<%@ Page Title="Reconciliation Report" Language="C#" MasterPageFile="~/Default.master"
    AutoEventWireup="true" CodeFile="Reconciliation_Report.aspx.cs" Inherits="Claim_Reconciliation_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:"
            BorderWidth="1" BorderColor="DimGray" ValidationGroup="Save" CssClass="errormessage">
        </asp:ValidationSummary>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="ghc" colspan="2">
                <b>Reconciliation Report</b>
            </td>
        </tr>
        <tr>
            <td style="height: 50px;" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="10%">
                &nbsp;
            </td>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="18%" align="right">
                            Sedgwick/JURIS Spreadsheet
                        </td>
                        <td width="4%" align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:FileUpload ID="fpFile" runat="server" />
                            <asp:RequiredFieldValidator ID="ReqFile" runat="server" ErrorMessage="Please select file." ValidationGroup="Save"
                                ControlToValidate="fpFile" Display="none" SetFocusOnError="true"></asp:RequiredFieldValidator>                             
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Button ID="btnUpload" Text="Generate Report" runat="server" OnClick="btnUpload_click"
                                ValidationGroup="Save" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 50px;" colspan="2">
                &nbsp;
            </td>
        </tr>
    </table>
    <%--<table width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnExport" runat="server" Text="Export To Excel"/>
            </td>
        </tr>
    </table>--%>
    <table width="100%">
        <tr>
            <td>
                <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="false" Width="100%"
                    EmptyDataText="No Record Found.">
                    <Columns>
                        <asp:BoundField DataField="Policy_Inception_Date" HeaderText="Policy Inception Date "
                            SortExpression="Policy_Inception_Date" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Left"
                            HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                        <asp:BoundField DataField="Claim_File_Number" HeaderText="Claim File Number" SortExpression="Claim_File_Number"
                            HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                        </asp:BoundField>
                        <asp:BoundField DataField="JURIS_Client_Unit_Number" HeaderText="JURIS Client Unit Number"
                            SortExpression="JURIS_Client_Unit_Number" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Left"
                            HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                        <asp:BoundField DataField="Date_Document_Printed" HeaderText="Date Document Printed"
                            SortExpression="Date_Document_Printed" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Left"
                            HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                        <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" HeaderStyle-Width="200px"
                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                        <asp:BoundField DataField="Bucket" HeaderText="Bucket" SortExpression="Bucket" HeaderStyle-Width="200px"
                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                        <asp:BoundField DataField="Date_of_Loss" HeaderText="Date of Loss" SortExpression="Date_of_Loss"
                            HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                        </asp:BoundField>
                        <asp:BoundField DataField="Claim_Total_Incurred" HeaderText="Claim Total Incurred"
                            SortExpression="Claim_Total_Incurred" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Left"
                            HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                        <asp:BoundField DataField="Claim_Total_Paid" HeaderText="Claim Total Paid" SortExpression="Claim_Total_Paid"
                            HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="lblReport" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
