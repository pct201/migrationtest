<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AbstractLetters.ascx.cs" Inherits="Controls_AbstractLetters_AbstractLetters" %>

<script type="text/javascript" src="<%=AppConfig.SiteURL %>JavaScript/Validator.js"></script>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script type="text/javascript">
    function CheckUnCheckAllLetters(bChecked) {
        var ctrls = document.getElementsByTagName('input');
        var i;
        var cnt = 0;
        for (i = 0; i < ctrls.length; i++) {
            if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkSelLetter") > 0) {
                ctrls[i].checked = bChecked;
            }
        }
    }
    function CheckAllUncheckedLetters(gvID) {
        var ctrls = document.getElementsByTagName('input');
        var i;
        var cnt = 0;
        for (i = 0; i < ctrls.length; i++) {
            if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkSelLetter") > 0) {
                if (ctrls[i].checked)
                    cnt++;
            }
        }

        if (cnt == document.getElementById(gvID).rows.length - 1)
            document.getElementById('chkLetterHeader').checked = true;
        else
            document.getElementById('chkLetterHeader').checked = false;

    }
    function ShowAbstractMailPage(letterType, pkClaim, claimType, DocType, bDiary, bTran, bAttach, Pk_Contact) {
        var width = 600;
        var height = 300;
        var updateGridBtnId = '<%=AttachmentGridUpdateButtonID%>';
        var navigateurl = '<%=AppConfig.SiteURL%>Event/AbstractLetterMail.aspx?claimID=' + pkClaim + '&docs=' + letterType + '&claimType=' + claimType + '&DocType=' + DocType + '&bDiary=' + bDiary + '&bTran=' + bTran + '&bAttach=' + bAttach + '&PK_Contact=' + Pk_Contact;
        ShowDialog(navigateurl, width, height);
        //'&btnID=' + updateGridBtnId + 
    }

    //This function is used to check that at least one row is selected before go for Remove records.
    function CheckSelectedLetters() {
        if (CheckClaimID()) {


            var ctrls = document.getElementsByTagName('input');
            var i;
            //cnt is used to count number of row are selected
            var cnt = 0;
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkSelLetter") > 0) {
                    if (ctrls[i].checked)
                        cnt++;
                }
            }
            //used if o rows are selected than give alert to user else go forward.
            if (cnt == 0) {
                alert("Please select letter(s)!");
                return false;
            }
            else {
                return CheckDocType();
            }
        }
        else
            return false;
    }

    function CheckDocType() {
        var gv = document.getElementById('<%=gvAbstractsLetters.ClientID %>');
        var IsDoc = false, IsPDF = false, TypeID, CheckId;

        var i = 0;
        for (i = 2; i < gv.rows.length + 1; i++) {
            if (i <= 9) {
                TypeID = '<%=gvAbstractsLetters.ClientID %>' + '_ctl0' + i + '_hdnDocType';
                CheckId = '<%=gvAbstractsLetters.ClientID %>' + '_ctl0' + i + '_chkSelLetter';
            }
            else {
                TypeID = '<%=gvAbstractsLetters.ClientID %>' + '_ctl' + i + '_hdnDocType';
                CheckId = '<%=gvAbstractsLetters.ClientID %>' + '_ctl' + i + '_chkSelLetter';
            }

            if (document.getElementById(TypeID).value == "Document" && document.getElementById(CheckId).checked)
                IsDoc = true;
            else if (document.getElementById(TypeID).value == "PDF" && document.getElementById(CheckId).checked)
                IsPDF = true;
        }

        if (IsDoc && IsPDF) {
            alert('Please select only Document Letter or only PDF Letter.');
            return false;
        }
        else
            return true;
    }

    function CheckClaimID() {
        var msg = "Please save Event record first! ";

        var PK = '<%=FK_Event%>';
        if (Number(PK) > 0)
            return true;
        else {
            alert(msg);
            return false;
        }
    }
    function OpenPopupContactabstract(ContactType, Driver_File) {
        var PK = '<%=FK_Event%>';
        if (Number(PK) > 0) {
            if (CheckSelectedLetters() == true) {
                ShowDialog('PopupContact.aspx?ClaimType=WC&ContactType=' + ContactType + '&df=' + Driver_File, PopupWidth_Contact, PopupHeight_Contact);
            }
            else
                return false;
        }
        else {
            alert("Please save record first!");
            return false;
        }

    }

    function openWindowAbstract(strURL) {
        //oWnd = window.open(strURL, "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
        ShowDialog(strURL, 450, 300);
        //oWnd.moveTo(260,180);
        return false;
    }

    function CheckAbstractForWC(id) {
        if (CheckSelectedLetters() == true) {
            var gv = document.getElementById('<%=gvAbstractsLetters.ClientID %>');
            var TypeID, CheckId, Doc_id, Doc_name;
            var i = 0;
            for (i = 2; i < gv.rows.length + 1; i++) {
                if (i <= 9) {
                    TypeID = '<%=gvAbstractsLetters.ClientID %>' + '_ctl0' + i + '_hdnDocType';
                    CheckId = '<%=gvAbstractsLetters.ClientID %>' + '_ctl0' + i + '_chkSelLetter';
                    Doc_id = '<%=gvAbstractsLetters.ClientID %>' + '_ctl0' + i + '_hdnDocumentName';
                }
                else {
                    TypeID = '<%=gvAbstractsLetters.ClientID %>' + '_ctl' + i + '_hdnDocType';
                    CheckId = '<%=gvAbstractsLetters.ClientID %>' + '_ctl' + i + '_chkSelLetter';
                    Doc_id = '<%=gvAbstractsLetters.ClientID %>' + '_ctl0' + i + '_hdnDocumentName';
                }

                if (document.getElementById(TypeID).value == "Document" && document.getElementById(CheckId).checked) {
                    Doc_name = document.getElementById(Doc_id).value;
                }
                else if (document.getElementById(TypeID).value == "PDF" && document.getElementById(CheckId).checked) {
                    Doc_name = document.getElementById(Doc_id).value;
                }

            }

        }
    }

</script>
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <asp:GridView ID="gvAbstractsLetters" runat="server" Width="100%" AutoGenerateColumns="false"
                OnRowCommand="gvAbstractsLetters_RowCommand">
                <Columns>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                        <HeaderTemplate>
                            <input id="chkLetterHeader" type="checkbox" onclick="CheckUnCheckAllLetters(this.checked)" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelLetter" runat="server" />
                            <asp:HiddenField ID="hdnDocumentName" runat="server" Value='<%#Eval("Document_Name")%>' />
                            <asp:HiddenField ID="hdnDocType" runat="server" Value='<%#Eval("Document_Type")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Document_Name" HeaderText="Document Description" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
                    <asp:BoundField DataField="Document_Type" HeaderText="Document Type" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
                    <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:ImageButton ID="ib_view" runat="server" ImageUrl="~/Images/download.gif" CommandName="ViewLetter" Visible='<%# !HideGenerateLetters %>'
                                CommandArgument='<%#Eval("Document_Name") + "," + Eval("Document_Type")%>' OnClientClick="return CheckClaimID();" />
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
    <tr>
        <td align="left">
            <asp:Button ID="btnAbstractletterPrint" runat="server" Text=" Print " CausesValidation="false"
                OnClick="btnAbstractletterPrint_Click" OnClientClick="return CheckSelectedLetters();" />
            <asp:Button ID="btnAbstractletterMail" runat="server" Text=" Mail " CausesValidation="false"
                OnClick="btnAbstractletterMail_Click" OnClientClick="return CheckSelectedLetters();" />
            <asp:HiddenField ID="hdnPK_Entity" runat="server" />
            <asp:HiddenField ID="hdnBeginDate" runat="server" />
            <asp:HiddenField ID="hdnEndDate" runat="server" />
            <asp:HiddenField ID="hdnAction" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
</table>
<asp:Button ID="btnHidden" runat="server" OnClientClick="return false;" Style="display: none" />

<script language="javascript" type="text/javascript">

    function UnCheckAllOption() {
        var ctrls = document.getElementsByTagName('input');
        var i;
        var cnt = 0;
        for (i = 0; i < ctrls.length; i++) {
            if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkOptions") > 0) {
                ctrls[i].checked = false;
            }
        }
    }
</script>







