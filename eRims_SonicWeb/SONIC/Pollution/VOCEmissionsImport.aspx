<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="VOCEmissionsImport.aspx.cs" Inherits="SONIC_Exposures_VOCEmissionsImport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>

    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%" class="ghc" colspan="2">VOC Emissions .CSV Import
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td width="10%"></td>
                        <td align="left" width="10%">Location&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                        </td>
                        <td width="4%" align="center">:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLocation" Width="175px" runat="server" SkinID="dropGen"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="10%"></td>
                        <td align="left" width="10%">Month&nbsp;<span id="Span2" style="color: Red;" runat="server">*</span>
                        </td>
                        <td width="4%" align="center">:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMonth" Width="175px" runat="server" SkinID="dropGen"></asp:DropDownList>
                            <asp:RequiredFieldValidator ControlToValidate="ddlMonth" ID="rfvMonth" Display="None"
                                ValidationGroup="vsErrorGroup" ErrorMessage="Please select Month" InitialValue="0" runat="server">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="10%"></td>
                        <td align="left" width="10%">Year&nbsp;<span id="Span3" style="color: Red;" runat="server">*</span>
                        </td>
                        <td width="4%" align="center">:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlYear" Width="175px" runat="server" SkinID="dropGen"></asp:DropDownList>
                            <asp:RequiredFieldValidator ControlToValidate="ddlYear" ID="rfvYear" Display="None"
                                ValidationGroup="vsErrorGroup" ErrorMessage="Please select Year" InitialValue="0" runat="server"> </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="10%"></td>
                        <td width="10%" align="left">File to Import&nbsp;<span id="Span4" style="color: Red;" runat="server">*</span>
                        </td>
                        <td width="4%" align="center">:
                        </td>
                        <td>
                            <asp:FileUpload ID="fpFile" runat="server" />
                            <asp:RequiredFieldValidator ControlToValidate="fpFile" ID="rfvFPFile" Display="None"
                                ValidationGroup="vsErrorGroup" ErrorMessage="Please select File to Import" runat="server"> </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td style="padding-left: 250px;">
                <asp:Button ID="btnSubmit" runat="server" CausesValidation="true" ValidationGroup="vsErrorGroup" Text="Submit" OnClick="btnSubmit_Click" />&nbsp;&nbsp;
                 <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <div runat="server" id="divVOCData" visible="false">
            <tr>
                <td colspan="3" class="bandHeaderRow" width="85%">VOC Emissions
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;
                    <asp:Label runat="server" ID="lblDuplicateEntries" Font-Bold="true" CssClass="heading"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;                    
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="gvVOCEmission" runat="server" EmptyDataText="No Other VOC Records Found"
                        AutoGenerateColumns="false" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Paint Category">
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label runat="server"><%#Eval("Paint Category")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Item Number">
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <%#Eval("Part Number")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Units">
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <%# Eval("Unit")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <%#Eval("Qty")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Gallons">
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <%#Eval("Gallons")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="VOC Emissions">
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <%#Eval("VOC Total")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </div>
    </table>
</asp:Content>

