<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AttachmentDetails.ascx.cs"
    Inherits="Hudson_AttachmentDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script language="javascript" type="text/javascript" src="../../JavaScript/Validator.js"></script>

<script type="text/javascript">
    function CheckUnCheckAll(bChecked) {
        var ctrls = document.getElementsByTagName('input');
        var i;
        var cnt = 0;
        for (i = 0; i < ctrls.length; i++) {
            if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkSelect") > 0) {
                ctrls[i].checked = bChecked;
            }
        }
    }

    function CheckAllUnchecked(gvID) {
        var ctrls = document.getElementsByTagName('input');
        var i;
        var cnt = 0;
        for (i = 0; i < ctrls.length; i++) {
            if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkSelect") > 0) {
                if (ctrls[i].checked)
                    cnt++;
            }
        }


        if (cnt == document.getElementById(gvID).rows.length - 1)
            document.getElementById('chkHeader').checked = true;
        else
            document.getElementById('chkHeader').checked = false;

    }
    //This function is used to check that at least one row is selected before go for Remove records.
    function CheckSelected() {
        var ctrls = document.getElementsByTagName('input');
        var i;
        //cnt is used to count number of row are selected
        var cnt = 0;
        for (i = 0; i < ctrls.length; i++) {
            if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkSelect") > 0) {
                if (ctrls[i].checked)
                    cnt++;
            }
        }
        //used if o rows are selected than give alert to user else go forward.
        if (cnt == 0) {
            alert("Please select an attachment to remove");
            return false;
        }
        else {
            return confirm("Are you sure to remove attachment(s)?");
        }
    }
    function openWindow(strURL) {
        oWnd = window.open(strURL, "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");      
        return false;
    }

    //Used to display Mail Page
    function ShowMailPage(attTbl, gv) {

        var gv = document.getElementById(gv);
        var ctrls = gv.getElementsByTagName('input');
        var i;
        //cnt is used to count number of row are selected
        var cnt = 0;
        var m_strAttIds = '';
        for (i = 0; i < ctrls.length; i++) {
            //check control type and selcted is true or not. 
            if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkSelect") > 0) {
                //chcked is true than.
                if (ctrls[i].checked) {
                    var ctrlId = ctrls[i].id;
                    ctrlId = ctrlId.substring(ctrlId.lastIndexOf("_") - 2);
                    var index = ctrlId.replace("_chkSelect", "");
                    index = Number(index) - 2;
                    var id = document.getElementById("hdnID" + index).value;
                    if (m_strAttIds == "")
                        m_strAttIds = id;
                    else {
                        m_strAttIds = m_strAttIds + "," + id;
                    }
                    cnt++;
                }
            }
        }
        //used if o rows are selected than give alert to user else go forward.
        if (cnt == 0) {
            alert("Please select any attachment to mail");
            return false;
        }
        else {
            var oWnd = window.open("<%=AppConfig.SiteURL%>ErimsMail.aspx?AttMod=" + attTbl + "&AttIds=" + m_strAttIds + "&CRM=1", "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=600,height=300");
            oWnd.moveTo(260, 180);
            return false;
        }
    }
</script>

<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td class="Spacer" style="height: 5px;">
        </td>
    </tr>

    <tr>
        <td align="left">
            <asp:GridView ID="gvAttachment" runat="server" AllowPaging="false" AutoGenerateColumns="false"
                Width="100%" OnRowDataBound="gvAttachment_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" >
                        <ItemStyle Width="5%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                            <input type="hidden" id='hdnID<%#Container.DataItemIndex%>' value='<%#Eval("PK_CRM_Attachments")%>' />
                            <input type="hidden" id="hdnID" runat="server" value='<%#Eval("PK_CRM_Attachments")%>' /></ItemTemplate>
                        <HeaderTemplate>
                            <input id="chkHeader" type="checkbox" onclick="CheckUnCheckAll(this.checked)" />
                        </HeaderTemplate>
                    </asp:TemplateField>                 
                    <asp:TemplateField HeaderText="Attachment Description" HeaderStyle-HorizontalAlign="Left">
                        <ItemStyle Width="28%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <asp:Label ID="lblDesc" runat="server" Width="250px" Text='<%#Eval("Description")%>'
                                CssClass="textAttachment"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="File Name" HeaderStyle-HorizontalAlign="Left">
                        <ItemStyle Width="35%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <%# Convert.ToString(Eval("FileName")).Substring(12) %>
                            <br />
                            <asp:Label ID="lblFile" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="View">
                        <HeaderStyle HorizontalAlign="center" />
                        <ItemStyle Width="9%" HorizontalAlign="center" />
                        <ItemTemplate>
                            <input type="hidden" id="hdnFileName" runat="server" value='<%#Eval("FileName") %>' />
                            <asp:ImageButton ID="imgDownloadDoc" runat="server" ImageUrl="~/Images/download.gif" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblMsg" runat="server" SkinID="MessageOrNote"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="Spacer" style="height: 5px;">
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:Button ID="btnRemoveAttachment" runat="server" Text="Remove" Visible="false"
                OnClick="btnRemoveAttachment_Click" OnClientClick="return CheckSelected();" />
            <asp:Button ID="btnMail" runat="server" Text="Mail" Visible="false" />
        </td>
    </tr>
</table>
