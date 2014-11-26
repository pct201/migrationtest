﻿<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="RE_InformationNotes.aspx.cs"
    Inherits="SONIC_RealEstate_RE_InformationNotes" Title="Real Estate : Notes" %>

<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="../../Controls/RealEstateInfo/RealEstateInfo.ascx" TagName="RealEstateInfo"
    TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>

    <script language="javascript" type="text/javascript">
        //OPen Audit Popup
        function AuditPopUp()
        {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj= window.open("AuditPopup_RE_Notes.aspx?id=" + '<%=ViewState["PK_RE_Notes"]%>','AuditPopUp','width=' + winWidth +',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');        
            obj.focus();
            return false;
        }
         function checkNotes()
         {
           if(Page_ClientValidate('vsErrorGroup'))
           {
            var txt=document.getElementById("ctl00_ContentPlaceHolder1_txtNote_txtNote");
            if(txt.value.length > 0)
            {
              return true;
            }
            else 
            {
              alert("Please Enter Note.");
              return false;
            }
           }
           else
            return false;
       }

       function ValidateFields(sender, args) {
           var msg = '';
           var ctrlIDs = document.getElementById('<%=hdnControlIDs.ClientID%>').value.split(',');
           var Messages = document.getElementById('<%=hdnErrorMsgs.ClientID%>').value.split(',');
           var focusCtrlID = "";
           if (document.getElementById('<%=hdnControlIDs.ClientID%>').value != "") {
               var i = 0;
               for (i = 0; i < ctrlIDs.length; i++) {
                   var bEmpty = false;
                   var ctrl = document.getElementById(ctrlIDs[i]);
                   switch (ctrl.type) {
                       case "textarea":
                       case "text": if (ctrl.value == '') bEmpty = true; break;
                       case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                   }
                   if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                   if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
               }
               if (msg.length > 0) {
                   sender.errormessage = msg;
                   args.IsValid = false;
               }
               else
                   args.IsValid = true;
           }
           else {
               args.IsValid = true;
           }
       }

       jQuery(function ($) {
           $("#<%=txtNoteDate.ClientID%>").mask("99/99/9999");
       });   
    </script>

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td class="Spacer" width="100%" style="height: 15px;" colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc2:RealEstateInfo ID="RealEstate_Info" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="height: 20px" class="Spacer" colspan="2">
            </td>
        </tr>
        <tr>
            <td class="leftMenu">
                <table cellpadding="0" cellspacing="0" width="203px">
                    <tr>
                        <td style="height: 10px;" class="Spacer">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="5" cellspacing="0" width="100%">
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Notes" class="LeftMenuSelected">Notes</span>&nbsp;<span id="MenuAsterisk1" runat="server" style="color: Red;display:none">*</span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px;" class="Spacer">
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" width="100%">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="5px">
                            &nbsp;
                        </td>
                        <td class="dvContainer">
                            <div id="dvEdit" runat="server" width="794px">
                                <asp:Panel ID="pnlServiceContract" runat="server" Style="display: block;">
                                    <div class="bandHeaderRow">
                                        Real Estate - Notes</div>
                                    <table width="100%" cellpadding="3" cellspacing="1" border="0">
                                        <tr>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trEditDate">
                                            <td width="16%" align="left" nowrap="nowrap" valign="top">
                                                Note Date <span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td width="4%" align="center">
                                                :
                                            </td>
                                            <td width="80%" align="left">
                                                <asp:TextBox ID="txtNoteDate" SkinID="txtDate" runat="server"></asp:TextBox>
                                                <img alt="Note Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtNoteDate', 'mm/dd/y');"
                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                    align="middle" />
                                                <asp:RegularExpressionValidator ID="rvFromDate" runat="server" ControlToValidate="txtNoteDate"
                                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                    ErrorMessage="Note Date Is Not Valid." Display="none" ValidationGroup="vsErrorGroup">
                                                </asp:RegularExpressionValidator> 
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trViewDate" visible="false">
                                            <td width="16%" align="left" nowrap="nowrap" valign="top">
                                                Note Date
                                            </td>
                                            <td width="4%" align="center">
                                                :
                                            </td>
                                            <td width="80%" align="left">
                                                <asp:Label ID="lblNoteDate" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="left" nowrap="nowrap" valign="top">
                                                Note<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td width="4%" align="center" valign="top">
                                                :
                                            </td>
                                            <td width="80%" align="left">
                                                <uc:ctrlMultiLineTextBox ID="txtNote" ControlType="TextBox" Width="600" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <%--<td>
                &nbsp;
            </td>--%>
            <td align="center" colspan="2">
                <div id="dvSave" runat="server">
                    <table cellpadding="5" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="50%" align="right">
                                <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSaveAndView_Click"
                                    ValidationGroup="vsErrorGroup" CausesValidation="true"  />
                            </td>
                            <td align="left">
                                <asp:Button ID="btnRevertandReturn" runat="server" Text="Revert & Return" CausesValidation="false"
                                    OnClick="btnRevertandReturn_Click" />&nbsp;
                                <asp:Button ID="btnViewAudit" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;" colspan="2">
            </td>
        </tr>
    </table>
     <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                    Display="None" ValidationGroup="vsErrorGroup" />
                <input id="hdnControlIDs" runat="server" type="hidden" />
                <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
