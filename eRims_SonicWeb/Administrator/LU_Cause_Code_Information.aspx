<%@ Page Title="eRIMS Sonic :: Cause Code Information" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" EnableTheming="false" CodeFile="LU_Cause_Code_Information.aspx.cs" Inherits="Administrator_LU_Cause_Code_Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../JavaScript/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../JavaScript/jquery-1.10.1.ui.min.js"></script>

    <script language="javascript" type="text/javascript">
       var jq = $.noConflict();
        function divExpandCollapse(divName) {
            var div, img;
            div = document.getElementById(divName);
            img = document.getElementById('img' + divName);
            if (div.style.display == "none") {
                div.style.display = "inline-block";
                img.src = "../Images/Collepse_Minus.png";
                jq("img").attr("title", "Collapse");
            } else {
                div.style.display = "none";
                img.src = "../Images/Expand_Plus.png";
                jq("img").attr("title", "Expand");

            }
        }

        jq(function () {
            jq('.gvChildGrid').each(function () {
                jq('#' + jq(this).attr('id').concat(' tbody')).sortable({
                    cursor: 'move',
                    scroll: false,
                    stop: function (ev, ui) {
                        jq('.gvChildGrid').each(function () {
                            jq(this).find('tr').each(function () { jq(this).removeClass('bkodd'); jq(this).removeAttr('style'); });
                            jq(this).find('tr:even').each(function () { jq(this).toggleClass('bkodd'); });
                        });
                    }
                });
                jq('#' + jq(this).attr('id').concat(' tbody')).disableSelection();
            });
        });

        function getData() {
            //gets table             
            var Ids = [];
            jq('.gvChildGrid').each(function () {
                var tempIds = jq(this).find('tr > td:first-child').next().map(function () {
                    return parseInt((jq(this).find('input:hidden')).val());
                }).get().join(',');
                Ids.push(tempIds);
            });
            jq('#ctl00_ContentPlaceHolder1_hdnSortOrder').val(Ids);

            var PKId = [];
            jq('.gvChildGrid').each(function () {

                var tempIds = jq(this).find('tr > td:first-child').map(function () {
                    return parseInt((jq(this).find('input:hidden')).val());
                }).get().join(',');
                PKId.push(tempIds);
            });
            jq('#<%=hdnPKId.ClientID %>').val(PKId);

        }
    </script>

    <style type="text/css">
        .bkeven
        {
            background-color: White;
            font-family: Tahoma;
            font-size: 8pt;
        }

        .bkodd
        {
            background-color: #EAEAEA !important;
            font-family: Tahoma !important;
            font-size: 8pt !important;
        }
    </style>
    <div id="divCauseCodeInfoGrid" style="display: block;" runat="Server">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="4">&nbsp;
                </td>
            </tr>
            <tr>
                <td class="bandHeaderRow" colspan="4" align="left">Administrator :: Cause Code Information
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 10%">&nbsp;
                </td>
                <td colspan="2" align="center">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr align="left">
                            <td>
                                <asp:LinkButton runat="server" ID="lnkAdd_New" Text="Add New" OnClick="lnkAddNew_Click"></asp:LinkButton>
                                <div style="margin-top: 20px; margin-left: 20px; float: right;">
                                    <asp:Button runat="server" ID="btnSortQuestions" Text="Sort Questions" OnClick="btnSortQuestions_Click"></asp:Button>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:GridView ID="gvCauseCodeInformation" AllowPaging="true" PageSize="20" runat="server" Width="100%" 
                                    AutoGenerateColumns="false" OnPageIndexChanging="gvCauseCodeInformation_PageIndexChanging"
                                    OnRowCreated="gvCauseCodeInformation_RowCreated" OnRowCommand="gvCauseCodeInformation_RowCommand" OnRowEditing="gvCauseCodeInformation_RowEditing">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Focus Area">
                                            <ItemStyle Width="15%" />
                                            <ItemTemplate>
                                                   <asp:Label ID="lblFocus_Area" runat="server" Text='<%# Eval("Focus_Area") %>' CssClass="TextClip"></asp:Label>
                                                <asp:HiddenField runat="Server" ID="hdnPK_LU_Cause_Code_Information" Value='<%# Eval("PK_LU_Cause_Code_Information") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sort Order">
                                            <ItemStyle Width="15%" />
                                            <ItemTemplate>
                                                <%#Eval("Sort_Order") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Question">
                                            <ItemStyle Width="30%"/>
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkView" Text='<%#Eval("Question") %>' CommandName="View" Width="175px"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Guidance">
                                            <ItemTemplate>
                                                 <asp:Label ID="lblGridGuidance" runat="server" Text=' <%#Eval("Guidance")%>' CssClass="TextClip" width="150px" ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reference">
                                            <ItemTemplate>
                                                 <asp:Label ID="lblGridRef" runat="server" Text=' <%#Eval("Reference")%>' CssClass="TextClip" width="150px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Active">
                                            <ItemStyle Width="45%" />
                                            <ItemTemplate>
                                                 <asp:Label runat="server" ID="lblGridActive" Text='<%#(Eval("Active").ToString() == "Y" ? "Yes" : "No") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkEdit" Text="Edit" CommandName="Edit"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <table cellpadding="4" cellspacing="0" width="100%">
                                            <tr>
                                                <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                    <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 10%">&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="divViewCauseCodeInformation" style="display: none;" runat="server">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="4">&nbsp;
                </td>
            </tr>
            <tr>
                <td class="bandHeaderRow" colspan="4" align="left">Administrator :: Cause Code Information
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;
                </td>
            </tr>
            <tr runat="server" id="tr1" style="display: block;">
                <td style="width: 20%">&nbsp;
                </td>
                <td colspan="2">
                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                        <tr>
                            <td style="width: 18%" align="left">Focus Area
                            </td>
                            <td style="width: 4%" align="center">:
                            </td>
                            <td colspan="4" align="left">
                                <asp:Label runat="server" ID="lblFocusArea"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">Question
                            </td>
                            <td valign="top" align="center">:
                            </td>
                            <td colspan="4" align="left">
                                <uc:ctrlMultiLineTextBox runat="server" ID="lblQuestion" ControlType="Label"
                                    Width="450" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">Guidance
                            </td>
                            <td valign="top" align="center">:
                            </td>
                            <td colspan="4" align="left">
                                <uc:ctrlMultiLineTextBox runat="server" ID="lblGuidance" ControlType="Label"
                                    Width="450" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">Reference
                            </td>
                            <td valign="top" align="center">:
                            </td>
                            <td colspan="4" align="left">
                                <uc:ctrlMultiLineTextBox runat="server" ID="lblReference" ControlType="Label"
                                    Width="450" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">Active
                            </td>
                            <td valign="top" align="center">:
                            </td>
                            <td colspan="4" align="left">
                                <asp:Label ID="lblActive" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 20%">&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="divAddCauseCodeInformation" style="display: none;" runat="server">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="4">&nbsp;
                </td>
            </tr>
            <tr>
                <td class="bandHeaderRow" colspan="4" align="left">Administrator :: Cause Code Information
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;
                </td>
            </tr>
            <tr runat="server" id="trGroupAdd" style="display: block;">
                <td style="width: 20%">&nbsp;
                </td>
                <td colspan="2">
                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                        <tr>
                            <td style="width: 18%" align="left">Focus Area<span style="color: Red;">*</span>
                            </td>
                            <td style="width: 4%" align="center">:
                            </td>
                            <td colspan="4" align="left">
                                <asp:DropDownList ID="ddlFocusArea" runat="server" Width="200px" SkinID="dropGen" AutoPostBack="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvFocusArea" ControlToValidate="ddlFocusArea" Display="None"
                                    runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Focus Area"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">Question <span style="color: Red;">*</span>
                            </td>
                            <td valign="top" align="center">:
                            </td>
                            <td colspan="4" align="left">
                                <uc:ctrlMultiLineTextBox runat="server" ID="txtQuestion" ControlType="TextBox"
                                    MaxLength="500" Width="450" IsRequired="true" ValidationGroup="vsErrorGroup"
                                    RequiredFieldMessage="Please Enter Question" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">Guidance<span style="color: Red;">*</span>
                            </td>
                            <td valign="top" align="center">:
                            </td>
                            <td colspan="4" align="left">
                                <uc:ctrlMultiLineTextBox runat="server" ID="txtGuidance" ControlType="TextBox"
                                    MaxLength="500" Width="450" IsRequired="true" ValidationGroup="vsErrorGroup"
                                    RequiredFieldMessage="Please Enter Guidance for the Question" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">Reference<span style="color: Red;">*</span>
                            </td>
                            <td valign="top" align="center">:
                            </td>
                            <td colspan="4" align="left">
                                <uc:ctrlMultiLineTextBox runat="server" ID="txtReference" ControlType="TextBox"
                                    MaxLength="500" Width="450" IsRequired="true" ValidationGroup="vsErrorGroup"
                                    RequiredFieldMessage="Please Enter Reference for the Question" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">Active
                            </td>
                            <td valign="top" align="center">:
                            </td>
                            <td colspan="4" align="left">
                                <asp:RadioButtonList ID="rdoActive" runat="server" SkinID="YesNoType" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 20%">&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;
                </td>
            </tr>
        </table>
    </div>
    <table cellpadding="5" cellspacing="5" border="0" width="100%">
        <tr>
            <td style="width: 25%">&nbsp;
            </td>
            <td align="right">
                <asp:Button ID="btnSave" runat="server" Text="Save" CausesValidation="true" ValidationGroup="vsErrorGroup" OnClick="btnSave_Click" />
            </td>
            <td style="width: 2%">&nbsp;
            </td>
            <td align="left">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" />
            </td>
            <td style="width: 25%">&nbsp;
            </td>
        </tr>
    </table>

    <div id="divCauseCodeInformation_Main" runat="server" style="display: block;">
        <div style="width: 850px; display: block;" runat="server" id="divMain">
            <div runat="server" id="divFocusArea" style="display: none; margin-left: 150px;">
                <asp:GridView ID="gvFocusArea" AllowPaging="true" PageSize="20" runat="server" Width="100%"
                    AutoGenerateColumns="false" OnRowDataBound="gvFocusArea_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <ItemStyle Width="2%" />
                            <ItemTemplate>
                                <a href="JavaScript:divExpandCollapse('div<%# Eval("Master_Order") %>');" title="This is a small Tooltip with the Classname 'Tooltip'">
                                    <img id='imgdiv<%# Eval("Master_Order") %>' width="10" height="10" border="0" src="../Images/Expand_Plus.png" alt="Expand" />
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Focus Area">
                            <ItemStyle Width="15%" />
                            <ItemTemplate>
                                <%# Eval("Focus_Area") %>
                                <asp:HiddenField runat="Server" ID="hdnMaster_Order" Value='<%# Eval("Master_Order") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemStyle Width="15%" />
                            <ItemTemplate>
                                <tr>
                                    <td colspan="100%">
                                        <div id='div<%# Eval("Master_Order") %>' style="display: none; position: relative; left: 15px; overflow: auto">
                                            <div style="width: 95%; background-color: rgb(127,127,127); color: white; font-weight: bold; height: 20px;" id="divTitle">
                                              <%--  <span style="margin-left: 70px;">
                                                    <asp:Label ID="lblSort_Order" runat="server" Text="Sort Order"></asp:Label></span>--%>
                                                <span style="margin-left: 70px;">
                                                    <asp:Label ID="lblQuestions" runat="server" Text="Questions"></asp:Label></span>
                                            </div>
                                            <asp:GridView ID="gvChildGrid" dontUseScrolls="true" CssClass="gvChildGrid" runat="server" AutoGenerateColumns="false" GridLines="None" Width="95%" ShowHeader="False">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemStyle Width="5%" />
                                                        <ItemTemplate>
                                                            <asp:HiddenField runat="server" Value='<%# Eval("PK_LU_Cause_Code_Information") %>' ID="hdnPK" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField>
                                                        <ItemStyle Width="5%" />
                                                        <ItemTemplate>
                                                            <asp:HiddenField runat="server" Value='<%# Eval("Sort_Order") %>' ID="hdnSort_Order" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:BoundField DataField="Sort_Order" HeaderStyle-HorizontalAlign="Left" />--%>
                                                    <asp:BoundField DataField="Question" HeaderStyle-HorizontalAlign="Left" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table cellpadding="4" cellspacing="0" width="100%">
                            <tr>
                                <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                    <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
        <table cellpadding="5" cellspacing="5" border="0" width="100%">
            <tr>
                <td style="width: 25%">&nbsp;
                </td>
                <td align="right">
                    <asp:Button ID="btnSaveReorderList" runat="server" Text="Save" OnClick="btnSaveReorderList_Click" OnClientClick="getData();" />
                    <asp:HiddenField ID="hdnSortOrder" runat="server" />
                    <asp:HiddenField ID="hdnPKId" runat="server" />
                </td>
                <td style="width: 2%">&nbsp;
                </td>
                <td align="left">
                    <asp:Button ID="btnCancelReorderList" runat="server" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" />
                </td>
                <td style="width: 25%">&nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

