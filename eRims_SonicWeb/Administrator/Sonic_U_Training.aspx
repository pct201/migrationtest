<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Sonic_U_Training.aspx.cs" Inherits="Administrator_Sonic_U_Training_Required_Classes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">


        function CheckValidation() {
            if (Page_ClientValidate("vsError")) {
            }
        }

    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields :" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsError" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <asp:UpdatePanel runat="server" ID="updTraining">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" width="100%">
                <tbody>
                    <tr>
                        <td colspan="4">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="bandHeaderRow" align="left" colspan="4">Administrator :: Sonic U Training Required Classes
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%">&nbsp;
                        </td>
                        <td align="center" colspan="2">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td align="left">&nbsp;
                                        </td>
                                    </tr>
                                    <tr id="trTraining" runat="server">
                                        <td align="left">
                                            <asp:GridView ID="gvTraining" runat="server" Width="100%" AutoGenerateColumns="false"
                                                PageSize="10" EnableViewState="true" AllowPaging="true" OnRowCommand="gvTraining_RowCommand"
                                                OnPageIndexChanging="gvTraining_PageIndexChanging" EmptyDataText="No Record Found" OnRowDataBound="gvTraining_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderText="Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Code")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtCode" runat="server" Text='<%#Eval("Code")%>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderText="Associate Safety Certification">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAssociate_Safety_Certification" runat="server" Text=' <%#Eval("Associate_Safety_Certification")%>'> </asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtAssociate_Safety_Certification" runat="server" Text='<%# Eval("Associate_Safety_Certification")%>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderText="Vehicle Lift Safety">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblVehicle_Lift_Safety" runat="server" Text='<%# Eval("Vehicle_Lift_Safety")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtVehicle_Lift_Safety" runat="server" Text='<%# Eval("Vehicle_Lift_Safety")%>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderText="RCRA">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRCRA" runat="server" Text='<%# Eval("RCRA")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtRCRA" runat="server" Text='<%# Eval("RCRA")%>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderText="Hazardous Materials Transportation">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHazardous_Materials_Transportation" runat="server" Text='<%# Eval("Hazardous_Materials_Transportation")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtHazardous_Materials_Transportation" runat="server" Text='<%# Eval("Hazardous_Materials_Transportation")%>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderText="Powered Industrial Trucks">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPowered_Industrial_Trucks" runat="server" Text='<%# Eval("Powered_Industrial_Trucks")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtPowered_Industrial_Trucks" runat="server" Text='<%# Eval("Powered_Industrial_Trucks")%>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderText="Respiratory Training">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRespiratory_Training" runat="server" Text='<%# Eval("Respiratory_Training")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtRespiratory_Training" runat="server" Text='<%# Eval("Respiratory_Training")%>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderText="Stormwater Pollution">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStormwater_Pollution" runat="server" Text='<%# Eval("Stormwater_Pollution")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtStormwater_Pollution" runat="server" Text='<%# Eval("Stormwater_Pollution")%>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton runat="server" ID="lnkEdit" Text="Edit" CommandName="EditRecord" CommandArgument='<%#Eval("PK_Sonic_U_Training") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td style="width: 20%">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%">&nbsp;
                        </td>
                        <td colspan="2">
                            <asp:Button ID="btnAddNew" runat="server" Text="Add Training for New Job Codes" Width="250px" OnClick="btnAddNew_Click"></asp:Button>
                            &nbsp;&nbsp;&nbsp;
                            <asp:LinkButton Style="display: none" ID="lnkCancel" runat="server" Text="Cancel"></asp:LinkButton>
                        </td>
                        <td style="width: 20%">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">&nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
            <table>
                <tbody>
                    <tr id="trTrainingAdd" runat="server">
                        <td>&nbsp;
                        </td>
                        <td colspan="2">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td align="center">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:GridView ID="gvTrainingEdit" runat="server" Width="100%" AutoGenerateColumns="false"
                                                PageSize="10" EnableViewState="true" AllowPaging="true" OnRowCommand="gvTraining_RowCommand"
                                                OnPageIndexChanging="gvTrainingEdit_PageIndexChanging"  OnRowDataBound="gvTrainingEdit_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Width="40px" HeaderText="Code" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPK_Sonic_U_Training" runat="server" Text='<%#Eval("PK_Sonic_U_Training")%>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Code")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="90px" HeaderText="Associate Safety Certification" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAssociate_Safety_Certification_Edit" runat="server" Text=' <%#Eval("Associate_Safety_Certification")%>' Visible="false"> </asp:Label>
                                                            <asp:DropDownList ID="drpAssociate_Safety_Certification" runat="server" Width="90px">
                                                                <asp:ListItem Value="Annual">Annual</asp:ListItem>
                                                               <asp:ListItem Value="Blank" Text=" "></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="115px" HeaderText="Vehicle Lift Safety" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblVehicle_Lift_Safety_Edit" runat="server" Text='<%# Eval("Vehicle_Lift_Safety")%>' Visible="false"></asp:Label>
                                                            <asp:DropDownList ID="drpVehicle_Lift_Safety" runat="server">
                                                                <asp:ListItem Value="Annual">Annual</asp:ListItem>
                                                                <asp:ListItem Value="One time completion">One time completion</asp:ListItem>
                                                                <asp:ListItem Value="Blank" Text=" "></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="115px" HeaderText="RCRA" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRCRAEdit" runat="server" Text='<%# Eval("RCRA")%>' Visible="false"></asp:Label>
                                                            <asp:DropDownList ID="drpRCRA" runat="server">
                                                                <asp:ListItem Value="Annual">Annual</asp:ListItem>
                                                                <asp:ListItem Value="One time completion">One time completion</asp:ListItem>
                                                                <asp:ListItem Value="Blank" Text=" "></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="115px" HeaderText="Hazardous Materials Transportation" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHazardous_Materials_TransportationEdit" runat="server" Text='<%# Eval("Hazardous_Materials_Transportation")%>' Visible="false"></asp:Label>
                                                            <asp:DropDownList ID="drpHazardous_Materials_Transportation" runat="server">
                                                                <asp:ListItem Value="Every Three Years">Every Three Years</asp:ListItem>
                                                                <asp:ListItem Value="Blank" Text=" "></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="115px" HeaderText="Powered Industrial Trucks" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPowered_Industrial_TrucksEdit" runat="server" Text='<%# Eval("Powered_Industrial_Trucks")%>' Visible="false"></asp:Label>
                                                            <asp:DropDownList ID="drpPowered_Industrial_Trucks" runat="server">
                                                                <asp:ListItem Value="Every Three Years">Every Three Years</asp:ListItem>
                                                                <asp:ListItem Value="If / as needed">If / as needed</asp:ListItem>
                                                               <asp:ListItem Value="Blank" Text=" "></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="115px" HeaderText="Respiratory Training" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRespiratory_TrainingEdit" runat="server" Text='<%# Eval("Respiratory_Training")%>' Visible="false"></asp:Label>
                                                            <asp:DropDownList ID="drpRespiratory_Training" runat="server">
                                                                <asp:ListItem Value="Annual">Annual</asp:ListItem>
                                                                <asp:ListItem Value="One time completion">One time completion</asp:ListItem>
                                                                <asp:ListItem Value="Blank" Text=" "></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="115px" HeaderText="Stormwater Pollution" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStormwater_PollutionEdit" runat="server" Text='<%# Eval("Stormwater_Pollution")%>' Visible="false"></asp:Label>
                                                            <asp:DropDownList ID="drpStormwater_Pollution" runat="server">
                                                                <asp:ListItem Value="One time completion">One time completion</asp:ListItem>
                                                                <asp:ListItem Value="Blank" Text=" "></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <table cellpadding="4" cellspacing="0" width="100%" align="center">
                                                        <tr>
                                                            <td width="1000px" align="center" style="border: 1px solid #cccccc;">
                                                                <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%">&nbsp;
                        </td>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnSave" runat="server" Text="Update" OnClick="btnSave_Click" Visible="false"></asp:Button>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Visible="false"></asp:Button>
                        </td>
                        <td style="width: 5%">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">&nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

