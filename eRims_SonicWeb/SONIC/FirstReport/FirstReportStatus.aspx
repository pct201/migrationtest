<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="FirstReportStatus.aspx.cs" 
Inherits="SONIC_FirstReportStatus" Title="eRIMS Sonic :: First Report :: Report Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
</div>
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td class="groupHeaderBar" align="left">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="Spacer" style="height: 20px;">
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td style="width: 200px;" colspan="2" class="bandHeaderRow">
                        Add First Report Wizard
                    </td>
                </tr>
                 <tr>
                        <td class="Spacer" style="height: 10px;" colspan="2">
                        </td>
                    </tr>
                <tr>
                    <td>
                        &nbsp;&nbsp;Results
                    </td>
                    <td class="Spacer">
                    </td>
                </tr>
                 <tr>
                        <td class="Spacer" style="height: 10px;" colspan="2">
                        </td>
                    </tr>
                <tr>
                    <td>
                        &nbsp;&nbsp;The following First Reports are required : 
                    </td>
                    <td class="Spacer">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Repeater runat="Server" ID="RptReportStatus" OnItemDataBound="RptReportStatus_ItemDataBound"
                        OnItemCreated="RptReportStatus_ItemCreated" OnItemCommand="RptReportStatus_ItemCommand">
                        <HeaderTemplate>
                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                            <tr>
                                <td style="width:5%">&nbsp;</td>
                                <td style="width:55%">Report Type (Click to Complete)</td>
                                <td style="width:40%">Complete?</td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                            <td>&nbsp;</td>
                            <td><asp:LinkButton runat="server" ID="lnkbtn" CommandName="Link"><%#Eval("Title") %></asp:LinkButton>
                                <asp:HiddenField runat="server" ID="hdnURL" Value='<%#Eval("URL") %>' />
                                <asp:HiddenField runat="server" ID="hdnFK_First_Report_ID" Value='<%#Eval("FK_First_Report_ID") %>' />
                                <asp:HiddenField runat="server" ID="hdnFirst_Report_Table" Value='<%#Eval("First_Report_Table") %>' />
                                <asp:HiddenField runat="Server" ID="hdnComplete" Value='<%#Eval("Complete") %>' />
                                </td>
                            <td><asp:CheckBox runat="server" ID="chkComplate" Enabled="false" /></td>
                        </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td class="Spacer" colspan="2" style="height: 20px;">
                    </td>
                </tr>
                <tr>
                    <td align="center" class="Spacer" colspan="2" style="height: 20px;">
                        <b>Additional Reports : </b>
                    </td>
                </tr>
                <tr runat="server" id="trErrorMsg" style="display:none">
                    <td align="center">
                        No Additional Report found.
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Repeater runat="Server" ID="RptAdditionalRpt" OnItemDataBound="RptAdditionalRpt_ItemDataBound"
                        OnItemCreated="RptAdditionalRpt_ItemCreated" OnItemCommand="RptAdditionalRpt_ItemCommand">
                        <HeaderTemplate>
                            <table cellpadding="3" cellspacing="1" border="1" width="50%">
                            <tr>
                                <td style="width:55%" align="left">First Report Type-Number</td>
                                <td style="width:40%" align="left">Complete?</td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                            <td align="left">
                            <asp:LinkButton runat="server" ID="lnkbtn" CommandName="Link"><%# Eval("First_Report_Table").ToString().Replace("_FR","") %>-<%#Eval("FR_Number") %></asp:LinkButton>
                                <asp:HiddenField runat="server" ID="hdnURL" Value='<%#Eval("URL") %>' />
                                <asp:HiddenField runat="server" ID="hdnFK_First_Report_ID" Value='<%#Eval("FK_First_Report_ID") %>' />
                                <asp:HiddenField runat="server" ID="hdnFirst_Report_Table" Value='<%#Eval("First_Report_Table") %>' />
                                <asp:HiddenField runat="Server" ID="hdnComplete" Value='<%#Eval("Complete") %>' />
                            <td align="left"><asp:CheckBox runat="server" ID="chkComplate" Enabled="false" /></td>
                        </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td class="Spacer" colspan="2" style="height: 20px;">
                    </td>
                </tr>
            </table>
        </td>
   </tr>
</table>
</asp:Content>

