<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Manually_Update_Training.aspx.cs" Inherits="SONIC_Exposures_Manually_Update_Training" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../../JavaScript/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../JavaScript/JSON-js-master/json2.js"></script>
    <script language="javascript" type="text/javascript">
        var waivedIds = [];
        var notwaivedIds = [];
        var count = 0;
        var newIds = [];
        var explicitCall = false;
        function change(row) {
            var id = row.id;
            //count = count + 1;
            //newIds.push(id);
            var dropdownID = id.replace("rblIs_Complete", "ddlTrainingStatus");
            var validatorID = id.replace("rblIs_Complete", "rfvStatus");
            $("#<%= hdnChangeIDs.ClientID %>").val(newIds);

            if ($('#' + id + ' input:checked').val() == "1" && $.inArray(id + "_" + $('#' + id + ' input:checked').val(), notwaivedIds) != -1) {

                $("#" + dropdownID).removeAttr('disabled');
                //ValidatorEnable($("#" + validatorID )[0], true);
                $("span[id*=" + validatorID + "]").each(function () {
                    ValidatorEnable(this, true);
                });
                //$("#" + dropdownID + " option[title='Not Completed']").remove();
                bindStatus(dropdownID, true);

            }
            else if ($('#' + id + ' input:checked').val() == "0" && $.inArray(id + "_" + $('#' + id + ' input:checked').val(), waivedIds) != -1) {
                $("#" + dropdownID).removeAttr('disabled');
                $("span[id*=" + validatorID + "]").each(function () {
                    ValidatorEnable(this, true);
                });

                bindStatus(dropdownID, false);
            }
            else {
                $("#" + dropdownID).val('-Select-');
                $("#" + dropdownID).attr('disabled', 'disabled');
                $("span[id*=" + validatorID + "]").each(function () {
                    ValidatorEnable(this, false);
                });
            }




        }


        function bindStatus(dropdownID, IS_Complete) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Manually_Update_Training.aspx/bindStatus",
                data: JSON.stringify({ 'IS_Complete': IS_Complete }),
                dataType: "json",
                success: function (data) {
                    $("#" + dropdownID).empty();
                    $.each(data, function (key, value) {
                        $("#" + dropdownID).append($("<option></option>").val(value.PK_LU_Sonic_Training_Status).html(value.Fld_Desc));
                    });
                },
                error: function (result) {
                    alert("Error");
                }
            });
        }

        function radioClick(row) {
            if (explicitCall != true)
                change(row);
        }
        function openPopUp(pkID) {
            if (pkID == 0) {
                if (Page_ClientValidate("vsErrorGroup")) {
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
            }
            else {
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
        }

        function ConfirmWaive() {
            var response;
            if (Page_ClientValidate("vsErrorGroup")) {
                $('input:radio').each(function () {
                    var $this = $(this),
                    id = $this.attr('id'),
                    url = $this.attr('datasrc');
                    if ($(this).prop('checked')) {
                        var selectedValue = $this.val();
                        if (selectedValue == "1") {
                            if ($.inArray(id, waivedIds) == -1) {
                                newIds.push(id);
                                count = count + 1;
                            }
                        }
                        if (selectedValue == "0") {
                            if ($.inArray(id, notwaivedIds) == -1) {
                                newIds.push(id);
                                count = count + 1;
                            }
                        }
                    }
                });
                if (count > 0) {
                    var response = confirm("Any course/class that is manually marked as completed or uncompleted will not be overridden by the auto update feature of eRIMS2 for setting course/class completions. Any changes to manually updated statuses will need to be performed manually.");
                    if (response == true) {
                        $("#<%= hdnChangeIDs.ClientID %>").val(newIds);
                        return true;
                    }
                    else {
                        explicitCall = true;
                        newIds.forEach(function (item) {
                            $("#" + item).prop('checked', false);
                            $("#" + item.replace("_0", "_1")).prop('checked', true)
                        });
                        explicitCall = false;
                        return false;
                    }
                }
                else {
                    alert("There was no change in data.");
                    return false;
                }
            }
            else {
                return false;
            }

        }

        $(document).ready(function () {
            $('input:radio').each(function () {
                var $this = $(this),
                    id = $this.attr('id');
                var selectedValue = $this.val();
                if (selectedValue == "1" && $(this).prop('checked')) {
                    waivedIds.push(id);
                }
                if (selectedValue == "0" && $(this).prop('checked')) {
                    notwaivedIds.push(id);
                }
            });

            $("span[id*=rfvStatus]").each(function () {
                ValidatorEnable(this, false);
            });
        });

    </script>
    <div>
        <asp:validationsummary id="vsError" runat="server" showsummary="false" showmessagebox="true"
            headertext="Verify the following fields:" borderwidth="1" bordercolor="DimGray"
            validationgroup="vsErrorGroup" cssclass="errormessage"></asp:validationsummary>
        <asp:hiddenfield id="hdnWaivedClasses" runat="server" value="0" />
    </div>
    <div align="center" style="width: 100%">
        <asp:panel id="pnlSearch" runat="server">
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
                <%-- <tr>
                    <td colspan="6" align="left">
                        <asp:Button ID="btnAdd" runat="server" Text="Add Training Courses for Associates" ValidationGroup="vsErrorGroup" CausesValidation="true" OnClick="btnAdd_Click" />
                        &nbsp;&nbsp;&nbsp;
                    </td>
                </tr>--%>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
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
            <table width="100%">
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td width="170">&nbsp;&nbsp;&nbsp;
                    </td>
                    <td align="center" width="250">
                        <asp:Button ID="btnAdd" runat="server" Width="240px" Text="Add Training Courses for Associates" ValidationGroup="vsErrorGroup" CausesValidation="true" OnClick="btnAdd_Click" />
                    </td>
                    <td width="80">&nbsp;&nbsp;&nbsp;
                    </td>
                    <td align="left">
                        <asp:Button ID="btnSubmit" runat="server" Text="Waive Training Class" ValidationGroup="vsErrorGroup" CausesValidation="true" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:panel>

        <asp:panel id="pnlGrid" runat="server" visible="false">
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
                    <td class="PropertyInfoBG" align="left" style="padding-left: 20px;">Safety Training Data
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
                                    <ItemStyle Width="20%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("NAME")%>'></asp:Label>
                                        <asp:HiddenField ID="hdnFK_Employee" runat="server" Value='<%# Eval("FK_Employee")%>' />
                                        <asp:HiddenField ID="hdnFK_LU_Location_ID" runat="server" Value='<%# Eval("FK_LU_Location_ID")%>' />
                                        <asp:HiddenField ID="hdnPK_Sonic_U_Associate_Training_Manual" runat="server" Value='<%# Eval("PK_Sonic_U_Associate_Training_Manual")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Class" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                    <ItemStyle Width="30%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblClass_Name" runat="server" Text='<%# Eval("Class_Name")%>'></asp:Label>
                                        <asp:HiddenField ID="hdnEmployee_ID" runat="server" Value='<%# Eval("Employee_Id")%>' />
                                        <asp:HiddenField ID="hdnCode" runat="server" Value='<%# Eval("Code")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Completed/Resolved" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                    <ItemStyle Width="20%" />
                                    <ItemTemplate>
                                        <asp:RadioButtonList ID="rblIs_Complete" runat="server" SkinID="YesNoTypeNullSelection" onclick="radioClick(this);" ></asp:RadioButtonList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Assigned Method" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                    <ItemStyle Width="15%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAssignMethod" runat="server" Text='<%# Eval("Assign")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Completed Method" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                    <ItemStyle Width="15%" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Method")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status <span style='color: #FF0000;'>*</span> " ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">

                                    <ItemStyle Width="35%" />
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlTrainingStatus" runat="server" Enabled="false"></asp:DropDownList>

                                        <asp:RequiredFieldValidator ID="rfvStatus" Enabled="true" Display="none" runat="server" ControlToValidate="ddlTrainingStatus"
                                            ErrorMessage="Please Select Status." Text="*" ValidationGroup="vsErrorGroup" InitialValue="0"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Disposition" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                    <ItemStyle Width="15%" />
                                    <ItemTemplate>
                                        
                                        <asp:LinkButton ID="lknEdit" runat="server" Text="Edit" CommandArgument='<%# Eval("PK_Sonic_U_Associate_Training_Manual")%>' CommandName="EditRecord" Visible="false"></asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="lnkDelete" Text="Delete" CommandName="Remove" OnClientClick="javascript:return confirm('Do you want to REMOVE the selected Manually Input Training from eRIMS2?')" CommandArgument='<%# Eval("PK_Sonic_U_Associate_Training_Manual")%>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
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
                        <%--<asp:Button ID="btnAdd" runat="server" Text="Add" ValidationGroup="vsErrorGroup" OnClick="btnAdd_Click" OnClientClick="return openPopUp(0);" />
                        &nbsp;&nbsp;&nbsp;--%>
                        <asp:HiddenField ID="hdnWaivedIDs" runat="server" Value="0" />
                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup" OnClientClick="javascript:return ConfirmWaive();" OnClick="btnSave_Click" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        <asp:Button ID="btnhdnReload" runat="server" OnClick="btnhdnReload_Click" Style="display: none;" />
                        <asp:HiddenField ID="hdnChangeIDs" runat="server" Value="0" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:panel>
    </div>
</asp:Content>

