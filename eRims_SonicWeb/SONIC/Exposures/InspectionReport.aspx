<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="InspectionReport.aspx.cs" Inherits="SONIC_Exposures_InspectionReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:ValidationSummary ID="valInspection" runat="server" ValidationGroup="vsErrorGroup" ShowMessageBox="true" ShowSummary="false"
HeaderText="Verify the following fields" BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />

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
            <asp:Panel runat="server" ID="pnlSearch">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td colspan="2" width="100%">
                        &nbsp;&nbsp;<span class="heading">Inspection Report</span>
                    </td>                    
                </tr>
                <tr><td class="Spacer" style="height:10px;"></td></tr>
                <tr>
                    <td class="Spacer" style="width: 31px;">
                    </td>
                    <td>
                        <table cellpadding="3" cellspacing="1" width="100%" border="0">
                            <tr>
                                <td align="left" style="width:16%">
                                    Location
                                </td>
                                <td align="center" style="width:4%">
                                    :
                                </td>
                                <td align="left" style="width:36%">
                                    <asp:DropDownList ID="ddlLocation" SkinID="default"  Width="90%" runat="server" >
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvLocation" runat="server" ControlToValidate="ddlLocation" Display="None" ErrorMessage="Please select a Loaction" ValidationGroup="vsErrorGroup" SetFocusOnError="true" InitialValue="0" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>                            
                         </table>
                    </td>
                </tr>
                <tr><td class="Spacer" style="height:10px;"></td></tr>
                <tr>
                    <td colspan="2" align="center">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td align="center" style="height: 24px">
                                    <asp:Button ID="btnSearch" runat="server" Text="Show Report" CausesValidation="true" ValidationGroup="vsErrorGroup" ToolTip="Search" 
                                    OnClick="btnSearch_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            </asp:Panel>
        </td>
    </tr>
    <tr><td class="Spacer" style="height:10px;"></td></tr>
    <tr>
        <td align="center">
            <asp:GridView ID="gvInspections" runat="server" AutoGenerateColumns="false" Width="80%" EmptyDataText="No Inspection Record Found For Selected Location" AllowPaging="true" 
            OnRowCommand="gvInspections_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="">
                                        <ItemStyle Width="10%" HorizontalAlign="left"  />
                                        <ItemTemplate>
                                            <%# Eval("PK_Inspection_ID")%>
                                        </ItemTemplate>                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Inspection Date" HeaderStyle-HorizontalAlign="left">
                                        <ItemStyle Width="30%" HorizontalAlign="left" />
                                        <ItemTemplate>
                                            <%# Eval("date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("date"))) : string.Empty %>                                        
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Inspector Name" HeaderStyle-HorizontalAlign="left">
                                        <ItemStyle Width="50%" HorizontalAlign="left" />
                                        <ItemTemplate>
                                            <%# Eval("Inspector_Name")%>
                                        </ItemTemplate>                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="View">
                                        <ItemStyle Width="10%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("PK_Inspection_ID")%>' CommandName="ViewInspection" Text='View' />
                                        </ItemTemplate>                                        
                                    </asp:TemplateField>
                                </Columns>                                
                            </asp:GridView> 
        </td>
    </tr>
    <tr><td class="Spacer" style="height:30px;"></td></tr>
</table>
</asp:Content>

