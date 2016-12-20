<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Manually_Update_Training.aspx.cs" Inherits="SONIC_Exposures_Manually_Update_Training" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../../JavaScript/jquery-1.10.2.min.js"></script>
    <script language="javascript" type="text/javascript">

        function openPopUp(pkID) {
            var w = 500, h = 300;

            if (document.all || document.layers) {
                w = screen.availWidth;
                h = screen.availHeight;
            }
            var leftPos, topPos;
            var popW = 530, popH = 300;
            if (document.all)
            { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
            else
            { leftPos = w / 2; topPos = h / 2; }

            window.open("ManualUpdateTrainingPopup.aspx?id=" + pkID, "popup", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
        }

    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <div align="center" style="width: 100%">
        <asp:Panel ID="pnlSearch" runat="server">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr style="height: 20px;" align="left">
                    <td class="PropertyInfoBG" style="padding-left: 20px;">Manually Update Training Data
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
            </table>
            <table border="0" cellpadding="2" cellspacing="2" width="80%">
                <tr>

                    <td align="left" class="lc">Year<span id="Span2" style="color: Red;" runat="server">*</span>
                    </td>
                    <td align="right" class="lc" valign="top">:
                    </td>
                    <td align="left" class="lc">
                        <asp:DropDownList ID="ddlYear" runat="server" Width="180px" SkinID="ddlSONIC">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvYear" Display="none" runat="server" ControlToValidate="ddlYear"
                            ErrorMessage="Please Select Year." Text="*" ValidationGroup="vsErrorGroup" InitialValue="0">
                        </asp:RequiredFieldValidator>
                    </td>
                    <td align="left" class="lc">Quarter <span id="Span1" style="color: Red;" runat="server">*</span>
                    </td>
                    <td align="right" class="lc" valign="top">:
                    </td>
                    <td align="left" class="lc">
                        <asp:DropDownList ID="ddlQuarter" runat="server" Width="180px" SkinID="ddlSONIC">
                            <asp:ListItem Value="0" Text="-- Select --">
                            </asp:ListItem>
                            <asp:ListItem Value="1" Text="1">
                            </asp:ListItem>
                            <asp:ListItem Value="2" Text="2">
                            </asp:ListItem>
                            <asp:ListItem Value="3" Text="3">
                            </asp:ListItem>
                            <asp:ListItem Value="4" Text="4">
                            </asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvMonth" Display="none" runat="server" ControlToValidate="ddlQuarter"
                            ErrorMessage="Please Select Quarter." Text="*" ValidationGroup="vsErrorGroup" InitialValue="0">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc">Location <span id="Span3" style="color: Red;" runat="server">*</span>
                    </td>
                    <td align="right" class="lc" valign="top">:
                    </td>
                    <td align="left" class="lc">
                        <asp:DropDownList ID="ddlLocation" runat="server" Width="180px" SkinID="ddlSONIC" AutoPostBack="true" OnSelectedIndexChanged="ddlddlLocation_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvRLCM" Display="none" runat="server" ControlToValidate="ddlLocation"
                            ErrorMessage="Please Select Location." Text="*" ValidationGroup="vsErrorGroup" InitialValue="0">
                        </asp:RequiredFieldValidator>
                    </td>

                    <td align="left" class="lc">Associate <%--<span id="Span4" style="color: Red;" runat="server">*</span>--%>
                    </td>
                    <td align="right" class="lc" valign="top">:
                    </td>
                    <td align="left" class="lc">
                        <asp:DropDownList ID="ddlAssociate" runat="server" Width="180px" SkinID="ddlSONIC">
                            <asp:ListItem Selected="True" Text="-- Select --" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                        <%-- <asp:RequiredFieldValidator ID="rfvAssociate" Display="none" runat="server" ControlToValidate="ddlAssociate"
                            ErrorMessage="Please Select Associate." Text="*" ValidationGroup="vsErrorGroup" InitialValue="0">
                        </asp:RequiredFieldValidator>--%>
                    </td>
                </tr>

            </table>
            <table>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="vsErrorGroup" CausesValidation="true" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>

        <asp:Panel ID="pnlGrid" runat="server" Visible="false">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr style="height: 20px;">
                    <td class="PropertyInfoBG" align="left" style="padding-left: 20px;">Sonic University Training Data
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>

            </table>
            <table cellpadding="3" cellspacing="1" border="0" width="96%">
                <tr>
                    <td align="left" valign="top">Location
                    </td>
                    <td align="center" valign="top">:
                    </td>
                    <td align="left" colspan="4" valign="top">
                        <asp:Label ID="lblLocation" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 18%" valign="top">Year
                    </td>
                    <td align="center" style="width: 2%" valign="top">:
                    </td>
                    <td align="left" style="width: 28%" valign="top">
                        <asp:Label ID="lblYear" runat="server"></asp:Label>
                    </td>
                    <td align="left" style="width: 20%" valign="top">Quarter
                    </td>
                    <td align="center" style="width: 2%" valign="top">:
                    </td>
                    <td align="left" style="width: 26%" valign="top">
                        <asp:Label ID="lblQuarter" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">&nbsp;</td>
                </tr>
                <tr>
                    <td align="left" valign="top">Training Grid
                    </td>
                    <td align="center" valign="top">:
                    </td>
                    <td align="left" colspan="4" valign="top">
                        <asp:GridView ID="gvTraining" runat="server" AutoGenerateColumns="false" Width="97%" EmptyDataText="No Record Found." OnRowDataBound="gvTraining_RowDataBound" BorderWidth="1px" GridLines="Both" OnRowCommand="gvTraining_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Associate Name" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                    <ItemStyle Width="30%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("NAME")%>'></asp:Label>
                                        <asp:HiddenField ID="hdnFK_Employee" runat="server" Value='<%# Eval("FK_Employee")%>' />
                                        <asp:HiddenField ID="hdnFK_LU_Location_ID" runat="server" Value='<%# Eval("FK_LU_Location_ID")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Class" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                    <ItemStyle Width="50%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblClass_Name" runat="server" Text='<%# Eval("Class_Name")%>'></asp:Label>
                                        <asp:HiddenField ID="hdnEmployee_ID" runat="server" Value='<%# Eval("Employee_Id")%>' />
                                        <asp:HiddenField ID="hdnCode" runat="server" Value='<%# Eval("Code")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Completed/Waived" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                    <ItemStyle Width="20%" />
                                    <ItemTemplate>
                                        <asp:RadioButtonList ID="rblIs_Complete" runat="server" SkinID="YesNoTypeNullSelection"></asp:RadioButtonList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Disposition" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                    <ItemStyle Width="20%" />
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnPK_Sonic_U_Associate_Training_Manual" runat="server" Value='<%# Eval("PK_Sonic_U_Associate_Training_Manual")%>' />
                                        <asp:LinkButton ID="lknEdit" runat="server" Text="Edit" CommandArgument='<%# Eval("PK_Sonic_U_Associate_Training_Manual")%>' CommandName="EditRecord"></asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="lnkDelete" Text="Delete" CommandName="Remove" OnClientClick="javascript:return confirm('Do you want to REMOVE the selected Manually Input Training from eRIMS2?')" CommandArgument='<%# Eval("PK_Sonic_U_Associate_Training_Manual")%>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <table width="80%">
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" style="padding-left: 35px" width="100%">
                        <asp:Button ID="btnAdd" runat="server" Text="Add" ValidationGroup="vsErrorGroup" OnClick="btnAdd_Click" OnClientClick="return openPopUp(0);" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup" OnClick="btnSave_Click" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" ValidationGroup="vsErrorGroup" OnClick="btnCancel_Click" />
                        <asp:Button ID="btnhdnReload" runat="server" OnClick="btnhdnReload_Click" Style="display: none;" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </div>

</asp:Content>

