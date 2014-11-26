<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Attachement_DetailWithClaim.ascx.cs" Inherits="Controls_Attachment_Sedgwick_Attachement_DetailWithClaim" %>

<script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js">
</script>
<script type="text/javascript">
    function CheckSelected() {
        var ctrls = document.getElementsByTagName('input');
        var i;
        var cnt = 0;
        for (i = 0; i < ctrls.length; i++) {
            if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkSelect") > 0) {
                if (ctrls[i].checked)
                    cnt++;
            }
        }

        if (cnt == 0) {
            alert("Please select an attachment to remove");
            return false;
        }
        else {
            return confirm("Are you sure that you want to remove the data that was selected for deletion?");
        }
    }

    function openWindow(strURL) {
        oWnd = window.open(strURL, "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
        oWnd.moveTo(260, 180);
        return false;
    }


    function ShowMailPage(PK_Field_Name) {
        var gv = document.getElementById('<%=gvAttachment.ClientID%>');
        var ctrls = gv.getElementsByTagName('input');
        var i;
        var cnt = 0;
        var m_strAttIds = '';
        for (i = 0; i < ctrls.length; i++) {
            if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf("chkSelect") > 0) {
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

        if (cnt == 0) {
            alert("Please select any attachment to mail.");
            return false;
        }
        else {
            var oWnd = window.open('<%=AppConfig.SiteURL%>SONIC/Sedgwick/Attachment_SendMail.aspx?EmailType= <%=Convert.ToString((int)clsGeneral.EmailTYpe.Attachment)%>&AttachmentTable=Sedgwick_Attachments&PK_Field_Name=' + PK_Field_Name + '&AttachmentId=' + m_strAttIds, "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=600,height=300");
            oWnd.moveTo(450, 300);
            return false;
        }
    }
</script>
<table cellpadding="0" cellspacing="0" width="100%">
    <tr style="background-color: #606060; font-family: Tahoma; color: white; font-size: 10pt; font-weight: bold;padding:5px;">
        <td style="padding:5px;">Attachment Grid</td>
    </tr>
    <tr>
        <td align="left">
            <asp:GridView ID="gvAttachment" runat="server" AllowPaging="false" AutoGenerateColumns="false"
                Width="100%" OnRowDataBound="gvAttachment_RowDataBound" OnRowCreated="gvAttachment_RowCreated" AllowSorting="True"  OnSorting="gvAttachment_Sorting">
                <Columns>
                    <asp:TemplateField>
                        <ItemStyle Width="10%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                            <input type="hidden" id='hdnID<%#Container.DataItemIndex%>' value='<%#Eval("PK_Sedgwick_Attachments")%>' />
                            <input type="hidden" id="hdnID" runat="server" value='<%#Eval("PK_Sedgwick_Attachments")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Claim Number" SortExpression="Origin_Claim_Number">
                        <ItemStyle Width="20%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <asp:Label ID="lblClaimNumber" runat="server" Width="250px" Text='<%#Eval("Origin_Claim_Number")%>'
                                CssClass="textAttachment"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description" SortExpression="CAST(SA.Attachment_Description AS NVARCHAR(4000))">
                        <ItemStyle Width="20%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <asp:Label ID="lblDesc" runat="server" Width="250px" Text='<%#Eval("Attachment_Description")%>'
                                CssClass="textAttachment"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="File Name" SortExpression="Attachment_Path">
                        <ItemStyle Width="25%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <%#Eval("Attachment_Path")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="View">
                        <HeaderStyle HorizontalAlign="center" />
                        <ItemStyle Width="9%" HorizontalAlign="center" />
                        <ItemTemplate>
                            <input type="hidden" id="hdnFileName" runat="server" value='<%#Eval("Attachment_Path1") %>' />
                            <asp:ImageButton ID="imgDownloadDoc" runat="server" ImageUrl="~/Images/download.gif" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblMsg" runat="server" SkinID="Message" Text="Currently There Is No Attachment.<br />Please Add One Or More Attachment."></asp:Label>
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="Spacer" style="height: 5px;"></td>
    </tr>
    <tr>
        <td align="left">
            <asp:Button ID="btnRemoveAttachment" runat="server" Text="Remove" Visible="false"
                OnClick="btnRemoveAttachment_Click" OnClientClick="return CheckSelected();" />
            <asp:Button ID="btnMail" runat="server" Text="Mail" Visible="false" />
        </td>
    </tr>
</table>
