<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SLT_SafetyWalk_Questions_Popup.aspx.cs" Inherits="SONIC_SLTSafetyWalk_SLT_SafetyWalk_Questions_Popup" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SLT Safety Walk Questions</title>
    <script language="javascript" type="text/javascript" src="../../JavaScript/Validator.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="smQuestionPopup" EnablePageMethods="true" runat="server">
        </asp:ScriptManager>
        <script type="text/javascript">

            Sys.UI.Point = function Sys$UI$Point(x, y) {

                x = Math.round(x);
                y = Math.round(y);

                var e = Function._validateParams(arguments, [
                    { name: "x", type: Number, integer: true },
                    { name: "y", type: Number, integer: true }
                ]);
                if (e) throw e;
                this.x = x;
                this.y = y;
            }

            function ShowAttachmentFA() {
                var pk = document.getElementById('<%= hdnPK_SLT_Safety_Walk_Responses.ClientID %>').value;

            pk = Number(pk);
            if (pk > 0) {
                document.getElementById('<%=trAttachmentFA.ClientID%>').style.display = "";
            }
            else {
                //document.getElementById('<%=trAttachmentFA.ClientID%>').style.display = "";
                alert("Please select/enter the Safety Walk Response details");
            }

        }

            function ShowAttachmentFA2() {

            var pk = document.getElementById('<%= hdnPK_SLT_Safety_Walk_Responses.ClientID %>').value;
            pk = Number(pk);
            if (pk > 0) {
                document.getElementById('<%=trAttachmentFA2.ClientID%>').style.display = "";
            }
            else {
                //document.getElementById('<%=trAttachmentFA2.ClientID%>').style.display = "";
                alert("Please select/enter the Safety Walk Response details");
            }

        }

        function SaveRecord() {
            window.opener.AskfForLogoff = false;
            window.opener.document.getElementById('ctl00_ContentPlaceHolder1_btnhdnReload').click();
            self.close();
            return false;
        }

        function ReloadParent() {
            window.opener.AskfForLogoff = false;
            window.opener.document.getElementById('ctl00_ContentPlaceHolder1_btnhdnReload').click();
            return false;
        }

        function DisableButton(btn) {
            
            document.getElementById('<%= btnSaveAndNext.ClientID %>').disabled = true; document.getElementById('<%= btnSaveAndNext.ClientID %>').value = 'Submitting...'; btn.disabled = true; btn.value = 'Submitting...';

        }
            
            function DisableButtonSaveandNext(btn) {

                document.getElementById('<%= btnSave.ClientID %>').disabled = true; document.getElementById('<%= btnSave.ClientID %>').value = 'Submitting...'; btn.disabled = true; btn.value = 'Submitting...';

            }
        </script>
        <%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
        <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
        <%@ Register Src="~/Controls/Attachments_SLT_Safety_Walk/Attachment.ascx" TagName="ctrlAttachment"
            TagPrefix="uc" %>
        <div style="text-align: center;">
            <asp:Panel ID="pnl" runat="server">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tbody>
                        <tr>
                            <td align="left">&nbsp; </td>
                        </tr>
                        <tr>
                            <td class="ghc">SLT Safety Walk Questions for
						<asp:Label ID="lblMonthYear" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                    <tr>
                                        <td width="100%" valign="top">
                                            <asp:DataList ID="gvSLT_Questions" runat="server" Width="100%" RepeatLayout="Table" RepeatDirection="Horizontal" BorderWidth="2" OnItemCommand="gvSLT_Questions_ItemCommand"
                                                OnItemDataBound="gvSLT_Questions_ItemDataBound">
                                                <ItemStyle Width="15%" />
                                                <ItemTemplate>
                                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                        <tr style="background-color: lightgray; font-family: Tahoma; color: #3366FF; font-size: 8pt; font-weight: bold;">
                                                            <td style="background-color: lightgray;">
                                                                <asp:LinkButton ID="lnkReference" runat="server" Text='<%#Eval("QuestionNumber")%>' CommandName="Edit"
                                                                    CommandArgument='<%#Eval("PK_LU_SLT_Safety_Walk_Focus_Area") %>' ForeColor="#3366FF" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <%#Eval("Complete_Status") %>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table cellpadding="2" cellspacing="2" border="0" width="100%" style="border: 2px solid black;">
                                    <tr>
                                        <td style="width: 13%" align="left">Focus Area</td>
                                        <td style="width: 4%" align="center">: </td>
                                        <td style="width: 35%" align="left">
                                            <asp:Label ID="lblFocusArea" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 13%" align="left" valign="top">Question
                                    <asp:Label ID="lblQuestionNumber" runat="server"></asp:Label></td>
                                        <td style="width: 4%" align="center" valign="top">: </td>
                                        <td style="width: 33%" align="left">
                                            <uc:ctrlMultiLineTextBox ID="txtQuestion" runat="server" MaxLength="2000" ControlType="Label" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 13%" align="left">a. Show Sonic Guidance?</td>
                                        <td style="width: 4%" align="center">: </td>
                                        <td style="width: 35%" align="left">
                                            <asp:RadioButtonList ID="rblGuidance" runat="server" OnSelectedIndexChanged="rblGuidance_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                <asp:ListItem Value="N" Text="No" Selected="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <asp:Panel ID="pnlGuidance" runat="server">
                                        <tr>
                                            <td style="width: 13%" align="left" valign="top">Guidance</td>
                                            <td style="width: 4%" align="center" valign="top">: </td>
                                            <td style="width: 33%" align="left" colspan="4">
                                                <uc:ctrlMultiLineTextBox ID="txtGuidance" runat="server" MaxLength="2000" ControlType="Label" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 13%" align="left" valign="top">Reference</td>
                                            <td style="width: 4%" align="center" valign="top">: </td>
                                            <td style="width: 33%" align="left" colspan="4">
                                                <uc:ctrlMultiLineTextBox ID="txtReference" runat="server" MaxLength="2000" ControlType="Label" />
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td style="width: 13%" align="left" valign="top">b. Departments Observed</td>
                                        <td style="width: 4%" align="center" valign="top">: </td>
                                        <td style="width: 33%" align="left">
                                            <asp:ListBox ID="lstDepartments" runat="server" Width="150" SelectionMode="Multiple"></asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 13%" align="left">c. Is the Observation Acceptable?</td>
                                        <td style="width: 4%" align="center">: </td>
                                        <td style="width: 35%" align="left">
                                            <asp:RadioButtonList ID="rblObservation" runat="server" OnSelectedIndexChanged="rblObservation_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                <asp:ListItem Value="N" Text="No" Selected="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <asp:Panel ID="pnlAddPicture" runat="server">
                                        <tr>
                                            <td style="width: 13%" align="left">Add a picture or document?</td>
                                            <td style="width: 4%" align="center">: </td>
                                            <td style="width: 35%" align="left" colspan="4">
                                                <asp:RadioButtonList ID="rblPictureDoc" runat="server" OnSelectedIndexChanged="rblPictureDoc_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                    <asp:ListItem Value="N" Text="No" Selected="True"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlAttachment" runat="server">
                                        <tr>
                                            <td align="left" colspan="6">
                                                <b>Attachments</b><br />
                                                <i>Click to view detail</i>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="left" colspan="6">
                                                <asp:GridView ID="gvFocusAreaAttachmentEdit" runat="server" Width="100%" OnRowDataBound="gvFocusAreaAttachement_RowDataBound"
                                                    OnRowCommand="gvFocusAreaAttachmentEdit_RowCommand" EmptyDataText="Currently there is no attachment<br/>Please add one or more attachment">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="File Name" HeaderStyle-HorizontalAlign="Left">
                                                            <ItemStyle Width="35%" />
                                                            <ItemTemplate>
                                                                <a id="lnkAttachFile" runat="server" href="#">
                                                                    <%# Eval("Attachment_Filename").ToString().Substring(12, (Eval("Attachment_Filename").ToString().Length-1) - 11)%>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Description" HeaderStyle-HorizontalAlign="Left">
                                                            <ItemStyle Width="35%" />
                                                            <ItemTemplate>
                                                                <%# Eval("Attachment_Description") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Left">
                                                            <ItemStyle Width="30%" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkRemoveAttachment" runat="server" Text="Remove" CommandArgument='<%#Eval("PK_SLT_Safety_Walk_Attachments") + ":" + Eval("Attachment_Filename") %>'
                                                                    CommandName="RemoveAttachment" OnClientClick="return confirm('Are you sure to remove this attachment?')" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="left" colspan="6">
                                                <asp:LinkButton ID="lnkAddNewFAAttach" runat="server" Text="--Add New--" OnClick="lnkAddNewFAAttach_Click"
                                                    CausesValidation="true" ValidationGroup="vsInspection"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr id="trAttachmentFA" runat="server" visible="false" >
                                            <td align="left" colspan="6">
                                                <uc:ctrlAttachment runat="server" ID="ucInspectionFocusAreaAttachment" OnFileSelection="UploadFocusArea_Attachment" />
                                            </td>
                                        </tr>

                                    </asp:Panel>
                                    <asp:HiddenField ID="hdnPK_SLT_Safety_Walk_Responses" runat="server" />
                                    <asp:Panel ID="pnlNeedtoBeDone" runat="server">
                                        <tr>
                                            <td style="width: 13%" align="left" valign="top">What Needs to be done?</td>
                                            <td style="width: 4%" align="center" valign="top">: </td>
                                            <td style="width: 33%" align="left" colspan="4">

                                                <uc:ctrlMultiLineTextBox ID="txtWhatNeeds" runat="server" MaxLength="2000" />
                                            </td>
                                        </tr>
                                        <asp:Panel ID="pnlAddPicture2" runat="server">
                                            <tr>
                                                <td style="width: 13%" align="left">Add a picture or document?</td>
                                                <td style="width: 4%" align="center">: </td>
                                                <td style="width: 35%" align="left" colspan="4">
                                                    <asp:RadioButtonList ID="rblPictureDoc2" runat="server" OnSelectedIndexChanged="rblPictureDoc2_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                        <asp:ListItem Value="N" Text="No" Selected="True"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlAttachment2" runat="server">
                                            <tr>
                                                <td align="left" colspan="6">
                                                    <b>Attachments</b><br />
                                                    <i>Click to view detail</i>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="left" colspan="6">
                                                    <asp:GridView ID="gvFocusAreaAttachmentEdit2" runat="server" Width="100%" OnRowDataBound="gvFocusAreaAttachmentEdit2_RowDataBound"
                                                        OnRowCommand="gvFocusAreaAttachmentEdit2_RowCommand" EmptyDataText="Currently there is no attachment<br/>Please add one or more attachment">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="File Name" HeaderStyle-HorizontalAlign="Left">
                                                                <ItemStyle Width="35%" />
                                                                <ItemTemplate>
                                                                    <a id="lnkAttachFile" runat="server" href="#">
                                                                        <%# Eval("Attachment_Filename").ToString().Substring(12, (Eval("Attachment_Filename").ToString().Length-1) - 11)%>
                                                                    </a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Description" HeaderStyle-HorizontalAlign="Left">
                                                                <ItemStyle Width="35%" />
                                                                <ItemTemplate>
                                                                    <%# Eval("Attachment_Description") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Left">
                                                                <ItemStyle Width="30%" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkRemoveAttachment" runat="server" Text="Remove" CommandArgument='<%#Eval("PK_SLT_Safety_Walk_Attachments") + ":" + Eval("Attachment_Filename") %>'
                                                                        CommandName="RemoveAttachment" OnClientClick="return confirm('Are you sure to remove this attachment?')" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="left" colspan="6">
                                                    <asp:LinkButton ID="lnkAddNewFAAttach2" runat="server" Text="--Add New--" OnClick="lnkAddNewFAAttach2_Click"
                                                        CausesValidation="true" ValidationGroup="vsInspection"></asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr id="trAttachmentFA2" runat="server" visible="false" >
                                                <td align="left" colspan="6">
                                                    <uc:ctrlAttachment runat="server" ID="ucInspectionFocusAreaAttachment2" OnFileSelection="UploadFocusArea2_Attachment"/>
                                                </td>
                                            </tr>

                                        </asp:Panel>
                                        <tr>
                                            <td style="width: 13%" align="left" valign="top">Assigned to SLT Member</td>
                                            <td style="width: 4%" align="center" valign="top">: </td>
                                            <td style="width: 33%" align="left" colspan="4">
                                                <asp:DropDownList ID="ddlSLTMember" runat="server" Style="width: 150px;"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 13%" align="left" valign="top">To Be Completed By</td>
                                            <td style="width: 4%" align="center" valign="top">: </td>
                                            <td style="width: 33%" align="left" colspan="4">
                                                <asp:TextBox ID="txtCompletedBy" runat="server" SkinID="txtDate"></asp:TextBox>
                                                <asp:ImageButton ID="imgbtnComptedby" runat="server" ImageUrl="../../Images/iconPicDate.gif" ImageAlign="Middle" OnClientClick="javascript:return false;" />
                                                <cc1:CalendarExtender ID="calCompletedBy" runat="server" TargetControlID="txtCompletedBy" PopupButtonID="imgbtnComptedby"></cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 13%" align="left" valign="top">Completion Date</td>
                                            <td style="width: 4%" align="center" valign="top">: </td>
                                            <td style="width: 33%" align="left" colspan="4">
                                                <asp:TextBox ID="txtCompletionDate" runat="server" SkinID="txtDate"></asp:TextBox>
                                                <asp:ImageButton ID="imgbtn" runat="server" ImageUrl="../../Images/iconPicDate.gif" ImageAlign="Middle" OnClientClick="javascript:return false;" />
                                                <cc1:CalendarExtender ID="CalCompletionDate" runat="server" TargetControlID="txtCompletionDate" PopupButtonID="imgbtn"></cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td class="Spacer" style="height: 5px;" colspan="3"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td class="Spacer" style="height: 5px;"></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 24px" align="center">
                                                <asp:HiddenField ID="hdnNextOpenQueID" runat="server" />
                                                <asp:Button ID="btnSave"  runat="server"  OnClientClick="DisableButton(this);" UseSubmitBehavior="false" OnClick="btnSave_Click" Text="Save" CausesValidation="true" ToolTip="Save"></asp:Button>&nbsp;&nbsp;&nbsp;<%--OnClientClick="javascript:return DisableButton(this);" --%>
                                                <asp:Button ID="btnSaveAndNext" OnClick="btnSaveAndNext_Click" runat="server" 
                                                    CausesValidation="true" Text="Save & Next" OnClientClick="DisableButtonSaveandNext(this);" UseSubmitBehavior="false"></asp:Button>&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnSaveAndReturn" OnClick="btnSaveAndNext_Click" runat="server"
                                                CausesValidation="true" Text="Save & Return" Visible="false" OnClientClick="this.disabled = true; this.value = 'Submitting...';" UseSubmitBehavior="false"></asp:Button>&nbsp;&nbsp;&nbsp;
									<asp:Button ID="btnCancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btnCancel_Click"></asp:Button>&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlView" runat="server">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tbody>
                        <tr>
                            <td align="left">&nbsp; </td>
                        </tr>
                        <tr>
                            <td class="ghc">SLT Safety Walk Questions for
						<asp:Label ID="lblMonthYearView" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                    <tr>
                                        <td width="100%" valign="top">
                                            <asp:DataList ID="gvSLT_QuestionsView" runat="server" Width="100%" RepeatLayout="Table" RepeatDirection="Horizontal" BorderWidth="2" OnItemCommand="gvSLT_Questions_ItemCommand"
                                                OnItemDataBound="gvSLT_Questions_ItemDataBound">
                                                <ItemStyle Width="15%" />
                                                <ItemTemplate>
                                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                        <tr style="background-color: #7f7f7f; font-family: Tahoma; color: white; font-size: 8pt; font-weight: bold;">
                                                            <td style="background-color: #7f7f7f;">
                                                                <asp:LinkButton ID="lnkReference" runat="server" Text='<%#Eval("QuestionNumber")%>' CommandName="Edit"
                                                                    CommandArgument='<%#Eval("PK_LU_SLT_Safety_Walk_Focus_Area") %>' ForeColor="White" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <%#Eval("Complete_Status") %>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table cellpadding="2" cellspacing="2" border="0" width="100%" style="border: 2px solid black;">
                                    <tr>
                                        <td style="width: 13%" align="left">Focus Area</td>
                                        <td style="width: 4%" align="center">: </td>
                                        <td style="width: 35%" align="left">
                                            <asp:Label ID="lblFocusAreaView" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 13%" align="left" valign="top">Question
                                    <asp:Label ID="lblQuestionNumberView" runat="server"></asp:Label></td>
                                        <td style="width: 4%" align="center" valign="top">: </td>
                                        <td style="width: 33%" align="left">
                                            <uc:ctrlMultiLineTextBox ID="txtQuestionView" runat="server" MaxLength="2000" ControlType="Label" />
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                    <td style="width: 13%" align="left">a. Show Sonic Guidance?</td>
                                    <td style="width: 4%" align="center">: </td>
                                    <td style="width: 35%" align="left" colspan="4">
                                        <asp:RadioButtonList ID="rblGuidanceView" runat="server" OnSelectedIndexChanged="rblGuidanceView_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                            <asp:ListItem Value="N" Text="No" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>--%>
                                    <asp:Panel ID="pnlrblGuidanceView" runat="server">
                                        <tr>
                                            <td style="width: 13%" align="left" valign="top">Guidance</td>
                                            <td style="width: 4%" align="center" valign="top">: </td>
                                            <td style="width: 33%" align="left" colspan="4">
                                                <uc:ctrlMultiLineTextBox ID="txtGuidanceView" runat="server" MaxLength="2000" ControlType="Label" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 13%" align="left" valign="top">Reference</td>
                                            <td style="width: 4%" align="center" valign="top">: </td>
                                            <td style="width: 33%" align="left" colspan="4">
                                                <uc:ctrlMultiLineTextBox ID="txtReferenceView" runat="server" MaxLength="2000" ControlType="Label" />
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td style="width: 13%" align="left" valign="top">b. Departments Observed</td>
                                        <td style="width: 4%" align="center" valign="top">: </td>
                                        <td style="width: 33%" align="left">
                                            <asp:ListBox ID="lstDepartmentsView" runat="server" Width="150" SelectionMode="Multiple" Enabled="false"></asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 13%" align="left">c. Is the Observation Acceptable?</td>
                                        <td style="width: 4%" align="center">: </td>
                                        <td style="width: 35%" align="left">
                                            <asp:RadioButtonList ID="rblObservationView" runat="server" Enabled="false">
                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                <asp:ListItem Value="N" Text="No" Selected="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <%-- <asp:Panel ID="pnlrblObservationView" runat="server">
                                    <tr>
                                        <td style="width: 13%" align="left">Add a picture or document?</td>
                                        <td style="width: 4%" align="center">: </td>
                                        <td style="width: 35%" align="left" colspan="4">
                                            <asp:RadioButtonList ID="rblPictureDocView" runat="server" OnSelectedIndexChanged="rblPictureDocView_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                <asp:ListItem Value="N" Text="No" Selected="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                </asp:Panel>--%>
                                    <asp:Panel ID="pnlrblPictureDocView" runat="server">
                                        <tr>
                                            <td align="left" colspan="6">
                                                <b>Attachments</b><br />
                                                <%-- <i>Click to view detail</i>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="6">
                                                <asp:GridView ID="gvFocusAreaAttachmentView" runat="server" Width="100%" OnRowDataBound="gvFocusAreaAttachement_RowDataBound"
                                                    OnRowCommand="gvFocusAreaAttachmentEdit_RowCommand" EmptyDataText="Currently there is no attachment<br/>Please add one or more attachment">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="File Name" HeaderStyle-HorizontalAlign="Left">
                                                            <ItemStyle Width="35%" />
                                                            <ItemTemplate>
                                                                <a id="lnkAttachFile" runat="server" href="#">
                                                                    <%# Eval("Attachment_Filename").ToString().Substring(12, (Eval("Attachment_Filename").ToString().Length-1) - 11)%>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Description" HeaderStyle-HorizontalAlign="Left">
                                                            <ItemStyle Width="35%" />
                                                            <ItemTemplate>
                                                                <%# Eval("Attachment_Description") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td style="width: 13%" align="left" valign="top">What Needs to be done?</td>
                                        <td style="width: 4%" align="center" valign="top">: </td>
                                        <td style="width: 33%" align="left">
                                            <asp:HiddenField ID="hdnPK_SLT_Safety_Walk_ResponsesView" runat="server" />
                                            <uc:ctrlMultiLineTextBox ID="txtWhatNeedsView" runat="server" MaxLength="2000" ControlType="Label" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 13%" align="left" valign="top">Assigned to SLT Member</td>
                                        <td style="width: 4%" align="center" valign="top">: </td>
                                        <td style="width: 33%" align="left">
                                            <asp:DropDownList ID="ddlSLTMemberView" runat="server" Style="width: 150px;" Enabled="false"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 13%" align="left" valign="top">To Be Completed By</td>
                                        <td style="width: 4%" align="center" valign="top">: </td>
                                        <td style="width: 33%" align="left">
                                            <asp:Label ID="txtCompletedByView" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 13%" align="left" valign="top">Completion Date</td>
                                        <td style="width: 4%" align="center" valign="top">: </td>
                                        <td style="width: 33%" align="left">
                                            <asp:Label ID="txtCompletionDateView" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
