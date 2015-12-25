<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="RLCM_QA_QC.aspx.cs" Inherits="SONIC_Exposures_RLCM_QA_QC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../../JavaScript/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        <%--function SetFROIAllowedTab(FroiType) {

            alert(number[0]);
            if (number[0] === "WC") '<%=clsSession.AllowedTab %>' = "1";
        }--%>

        function SetFROIAllowedTab(Hyperlink) {

            if (Hyperlink) {
                var number = Hyperlink.split("&");
                //e.preventDefault();
                if (number.length > 0) {
                    var Jsondata = {};
                    if (Hyperlink.indexOf("FirstReport") > -1) {
                        Jsondata.WizardID = number[1].substring(number[1].indexOf("=") + 1);
                        Jsondata.Type = "FirstReport";
                        Jsondata.ClaimType = "";
                    }
                    else {
                        Jsondata.WizardID = number[0].substring(number[0].indexOf("=") + 1);
                        Jsondata.Type = "Claim";
                        Jsondata.ClaimType = number[0].substring(number[0].indexOf("/", 5) + 1, number[0].indexOf("?", 5));
                    }

                    $.ajax({

                        type: "POST",
                        url: "RLCM_QA_QC.aspx/SetSessionTab",
                        //data: '{ strWizardID: "' + WizardID + '" }',
                        //data: { "Hyperlink": Jsondata.WizardID, "Type": Jsondata.Type },
                        data: "{'Hyperlink':'" + Jsondata.WizardID + "', 'Type':'" + Jsondata.Type + "', 'ClaimType':'" + Jsondata.ClaimType + "'}",
                        contentType: "application/json; charset=utf-8",
                        async: false,
                        dataType: "json",
                        success: function (response) {
                            window.open(Hyperlink, "_blank");
                        },
                        failure: function (response) {

                        },
                        error: function (xhr, status, error) {
                            alert(xhr.responseText);
                        }
                    });
                }
            }
        }

        $(document).ready(function () {

            $('a').each(function () {

                if ($(this).text().trim() == 'N/A' || $(this).text().trim() == 'Monthly Review Complete' ) {
                    $(this).css('cursor', 'default').css('text-decoration', 'none').css('pointer-events', 'none').css('color', 'WindowText');
                    $(this).removeAttr("href");
                    $(this).on("onclick", function (e) {
                        e.preventDefault();
                    });
                }

            });
            
        });

        
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
                    <td class="PropertyInfoBG" style="padding-left: 20px;">RLCM Monthly QA/QC - Search Filter
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
                    <td align="left" class="lc">RLCM<span id="Span3" style="color: Red;" runat="server">*</span>
                    </td>
                    <td align="right" class="lc" valign="top">:
                    </td>
                    <td align="left" class="lc">
                        <asp:DropDownList ID="ddlRLCM" runat="server" Width="180px" SkinID="ddlSONIC">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvRLCM" Display="none" runat="server" ControlToValidate="ddlRLCM"
                            ErrorMessage="Please Select RLCM." Text="*" ValidationGroup="vsErrorGroup" InitialValue="0">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc">Month<span id="Span1" style="color: Red;" runat="server">*</span>
                    </td>
                    <td align="right" class="lc" valign="top">:
                    </td>
                    <td align="left" class="lc">
                        <asp:DropDownList ID="ddlMonth" runat="server" Width="180px" SkinID="ddlSONIC">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvMonth" Display="none" runat="server" ControlToValidate="ddlMonth"
                            ErrorMessage="Please Select Month." Text="*" ValidationGroup="vsErrorGroup" InitialValue="0">
                        </asp:RequiredFieldValidator>
                    </td>
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
                    <td class="PropertyInfoBG" align="left" style="padding-left: 20px;">RLCM Monthly QA/QC
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>

            </table>
            <table cellpadding="3" cellspacing="1" border="0" style="background-color: Black;" width="97%">
                <tr class="PropertyInfoBG">
                    <td align="left" style="width: 15%">
                        <asp:Label ID="lblHeaderRLCM" Text="RLCM" runat="server"></asp:Label>
                    </td>
                    <td align="left" style="width: 15%">
                        <asp:Label ID="lblHeaderMonth" Text="Month" runat="server"></asp:Label>
                    </td>
                    <td align="left" style="width: 15%">
                        <asp:Label ID="lblHeaderYear" Text="Year" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color: White;">
                    <td align="left">
                        <asp:Label ID="lblRLCM" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblMonth" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblYear" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="gvRLCM" runat="server" AutoGenerateColumns="false" Width="97%" EmptyDataText="No Record Found." OnRowDataBound="gvRLCM_RowDataBound" BorderWidth="1px" GridLines="Both">
                <Columns>
                    <asp:TemplateField HeaderText="Module" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                        <ItemStyle Width="10%" />
                        <ItemTemplate>
                            <asp:Label ID="lblModule" runat="server" Text='<%# Eval("Module")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="System" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                        <ItemStyle Width="10%" />
                        <ItemTemplate>
                            <asp:Label ID="lblSystem" runat="server" Text='<%# Eval("System") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Task" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                        <ItemStyle Width="40%" />
                        <ItemTemplate>
                            <asp:Label ID="lblTask" runat="server" Text='<%# Eval("Task")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Category" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                        <ItemStyle Width="10%" />
                        <ItemTemplate>
                            <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Category")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Identifier &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  Status" ItemStyle-HorizontalAlign="left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                        <ItemStyle Width="30%" />
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvChildGrid" dontUseScrolls="true" runat="server" AutoGenerateColumns="false" GridLines="Both" Width="100%" ShowHeader="False" OnRowDataBound="gvChildGrid_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Identifier" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="70%" />
                                                    <ItemTemplate>
                                                        <%--<asp:LinkButton ID="lblIdentifier_Link" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_RLCM_QA_QC") %>'
                                                            Text='<%# Eval("Number")%>'></asp:LinkButton> || --%>
                                                        <a href="#" onclick="javascript:SetFROIAllowedTab('<%# Eval("Hyperlink")%>')" id="lnkIdentifier"><%# Eval("Number")%></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="30%" />
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkStatus" runat="server" CssClass="checkbox"></asp:CheckBox>
                                                        <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Eval("PK_RLCM_QA_QC")%>'/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>                        
                    </asp:TemplateField>
                </Columns>


            </asp:GridView>
            <br />
            <table width="80%">
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="padding-right:35px" width="50%">
                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup" OnClick="btnSave_Click" />
                    </td>
                    <td align="left" style="padding-left:35px" width="50%">
                        <asp:Button ID="btnCancel" runat="server" Text="Canel" ValidationGroup="vsErrorGroup" OnClick="btnCancel_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </div>

</asp:Content>

