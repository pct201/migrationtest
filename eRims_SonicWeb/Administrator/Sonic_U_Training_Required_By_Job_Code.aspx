<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Sonic_U_Training_Required_By_Job_Code.aspx.cs" Inherits="Administrator_Sonic_U_Training_Required_By_Job_Code" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" >


        function CheckValidation()
        {
            var gvET = document.getElementById('<%=gvTrainingEdit.ClientID%>');
            var drpJobCode = document.getElementById('<%=drpJobCode.ClientID%>');
            var blnCheck = false;
            var rCount = gvET.rows.length;

            if (drpJobCode.selectedIndex > 0) {
                for (var rowIdx = 1; rowIdx <= rCount - 1; rowIdx++) {

                    var cell = gvET.rows[rowIdx].cells[1].getElementsByTagName("select")[0].value;

                    if (cell > 0) {
                        blnCheck = true;
                    }
                }

                if (!blnCheck) {
                    alert("Please Select any one Requirement Type");
                    return false;
                }
            }
            else
            {
                alert("Please Select Job Code");
                return false;
            }
           
        }

    </script>

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields :" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
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
                        <td class="bandHeaderRow" align="left" colspan="4">Administrator :: Safety Training Required Classes By Job Code
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
                                        <td colspan="2">&nbsp;</td>
                                    </tr>
                                    <tr id="trTraining" runat="server">
                                        <td align="left" colspan="2">
                                            <table>
                                                <tr>
                                                    <td align="right">Search By :
                                                    </td>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="rdoSearch" runat="server" RepeatColumns="1" RepeatDirection="Vertical"
                                                            OnSelectedIndexChanged="rdoSearch_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Value="JobCode" Selected="True">Job Code</asp:ListItem>
                                                            <asp:ListItem Value="Class">Training Class</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td>&nbsp;
                                                        <asp:DropDownList ID="drpJobCodeSearch" runat="server" Style="width: 200px;" OnSelectedIndexChanged="drpDown_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <div style="margin-left: 6px; margin-top: 2px; padding-top: 2px;">
                                                            <asp:DropDownList ID="drpTrainingClassSearch" runat="server" Style="width: 200px;" OnSelectedIndexChanged="drpDown_SelectedIndexChanged" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">&nbsp;</td>
                                                </tr>
                                            </table>
                                            <asp:GridView ID="gvTraining" runat="server" Width="100%" AutoGenerateColumns="false"
                                                PageSize="10" EnableViewState="true" AllowPaging="true" EmptyDataText="No Record Found" OnRowCommand="gvTraining_RowCommand"
                                                OnPageIndexChanging="gvTraining_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderText="Job Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Code")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="200px" HeaderText="Training Class">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblClass_Name" runat="server" Text=' <%#Eval("Class_Name")%>'> </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="200px" HeaderText="Requirement Type">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRequirement_Description" runat="server" Text='<%# Eval("Requirement_Description")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderText="Active">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblActive" runat="server" Text='<%# Eval("Active_Desc")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton runat="server" ID="lnkEdit" Text="Edit" CommandName="EditRecord" CommandArgument='<%#Eval("PK_Sonic_U_Training_Required_By_Job_Code")  + ":" + Eval("FK_lu_job_code") %>'></asp:LinkButton>
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
            <table id="trTrainingAdd" runat="server">
                <tbody>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td colspan="2">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td align="center" colspan="4">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%">&nbsp; </td>
                                        <td colspan="2">
                                            <div style="float:left;padding-left:175px;">Job Code <span id="spn" style="color:red;" runat="server">*</span> :</div>
                                            <div style="float:left;padding-left:10px;">
                                                <asp:DropDownList ID="drpJobCode" runat="server" Style="width: 200px;">
                                                </asp:DropDownList>
                                              <%--  <asp:RequiredFieldValidator ID="rfvJobcode" runat="server" ErrorMessage="Please Select Job Code"
                                                    ValidationGroup="vsErrorGroup" Display="None" ControlToValidate="drpJobCode" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                                <asp:Label ID="lblJobCode" runat="server" Style="width: 300px;margin-top:4px;" Visible="false"></asp:Label>
                                            </div>
                                        </td>
                                        <td width="20%"></td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="4">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%">&nbsp;</td>
                                        <td align="center" colspan="2">
                                            <asp:GridView ID="gvTrainingEdit" runat="server" Width="100%" AutoGenerateColumns="false"
                                                PageSize="10" EnableViewState="true" AllowPaging="true" OnRowDataBound="gvTrainingEdit_RowDataBound"
                                                OnPageIndexChanging="gvTrainingEdit_PageIndexChanging" >
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Width="400px" HeaderText="Training Class" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblClass_Name" runat="server" Text=' <%#Eval("Class_Name")%>'> </asp:Label>
                                                            <asp:Label ID="lblPK_Sonic_U_Training_Required_By_Job_Code" runat="server" Text='<%#Eval("PK_Sonic_U_Training_Required_By_Job_Code") %>' Visible="false"> </asp:Label>
                                                            <asp:Label ID="lblPK_Sonic_U_Training_Classes" runat="server" Text='<%#Eval("PK_Sonic_U_Training_Classes") %>' Visible="false"> </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="250px" HeaderText="Requirement Type" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRequirement_Type" Text=' <%#Eval("FK_LU_Training_Requirement_Type")%>' runat="server" Visible="false"></asp:Label>
                                                            <asp:DropDownList ID="drpRequirement_Type" runat="server" Style="width: 170px;" AutoPostBack="true" OnSelectedIndexChanged="drpRequirement_Type_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="250px" HeaderText="Active" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hdnActive" runat="server" Value='<%#Eval("Active")%>' />
                                                            <asp:RadioButtonList ID="rdoActive" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                            </asp:RadioButtonList>
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
                                        <td width="20%">&nbsp;</td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%">&nbsp;
                        </td>
                        <td colspan="2" align="center" style="padding-left: 30px;">
                            <asp:Button ID="btnSave" runat="server" Text="Update" OnClick="btnSave_Click" ValidationGroup="vsErrorGroup" CausesValidation="true" OnClientClick="javascript:return CheckValidation();"></asp:Button>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"></asp:Button>
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
            <asp:UpdateProgress runat="server" ID="upProgress">
                <ProgressTemplate>
                    <div class="UpdatePanelloading" id="divProgress" style="width: 100%;">
                        <table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;">
                            <tr align="center" valign="middle">
                                <td class="LoadingText" align="center" valign="middle">
                                    <img src="../Images/indicator.gif" alt="Loading" />&nbsp;&nbsp;&nbsp;Please Wait..
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

