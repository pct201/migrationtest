<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AttachmentDetails.ascx.cs"
    Inherits="Controls_AttachmentDetails_AttachmentDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script type="text/javascript">
  //This function is used to check that at least one row is selected before go for Remove records.
    function CheckSelected<%=this.ID%>()
    {        
        var GrdName = '<%=gvAttachment.ClientID %>';
        var ctrls = document.getElementsByTagName('input');
        var i;
        //cnt is used to count number of row are selected
        var cnt=0;
        for(i=0;i<ctrls.length;i++)
        {
            if(ctrls[i].type=="checkbox" && ctrls[i].id.indexOf("chkSelect") > 0 && ctrls[i].id.indexOf(GrdName) > -1)
            {
                if(ctrls[i].checked)
                    cnt++;
            }
        }   
        //used if o rows are selected than give alert to user else go forward.
        if (cnt==0)
        {
            alert("Please select an attachment to remove");
            return false;
        }
        else
        {
            return confirm("Are you sure to remove attachment(s)?");
        }
  }
  //Used to open a window to display attched document
  function openWindow(strURL)
  {
         window.open (strURL,"mywindow","location=0,status=0,scrollbars=1,width=500,height=300,menubar=0,resizable=1,toolbar=0");
        return false;
  }
 
 //Used to display Mail Page
  function ShowMailPage<%=this.ID%>(attTbl)
  {        
        var GrdName = '<%=gvAttachment.ClientID %>';
        var ctrls = document.getElementsByTagName('input');
        var i;
        //cnt is used to count number of row are selected
        var cnt=0;
        var m_strAttIds = '';

        for(i=0;i<ctrls.length;i++)
        {
            //check control type and selcted is true or not. 
            if(ctrls[i].type=="checkbox" && ctrls[i].id.indexOf("chkSelect") > 0 && ctrls[i].id.indexOf(GrdName) > -1)
            {
                //chcked is true than.
                if(ctrls[i].checked)
                {                          
                    var ctrlId = ctrls[i].id;
                    ctrlId =ctrlId.substring(ctrlId.lastIndexOf("_")- 2);                    
                    var index = ctrlId.replace("_chkSelect","");
                    var id = document.getElementById(GrdName + "_ctl" + index + "_hdnID").value;
                    
                    if(m_strAttIds == "")
                        m_strAttIds = id;
                    else
                    {
                        m_strAttIds = m_strAttIds + "," + id;
                    }   
                    cnt++;
                }
            }
        }   
        //used if o rows are selected than give alert to user else go forward.
        if (cnt==0)
        {
            alert("Please select any attachment to mail.");
            return false;
        }
        else
        {
            var oWnd=window.open("<%=AppConfig.SiteURL%>SONIC/Exposures/EmailAttachment.aspx?AttMod="+attTbl+"&AttIds=" + m_strAttIds ,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=600,height=300");
            oWnd.moveTo(260,180);
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
                    <asp:TemplateField>
                        <ItemStyle Width="5%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                            <input type="hidden" id='hdnID<%#Container.DataItemIndex%>' value='<%#Eval("PK_Enviro_Equipment_Attachments_ID")%>' />
                            <input type="hidden" id="hdnID" runat="server" value='<%#Eval("PK_Enviro_Equipment_Attachments_ID")%>' /></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Attachment Type">
                        <ItemStyle Width="15%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <%#Eval("Type")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Attachment Description">
                        <ItemStyle Width="35%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("description")%>' CssClass="textAttachment"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Folder">
                        <ItemStyle />
                        <ItemTemplate>
                            <asp:Label ID="lblFolderName" runat="server" Text='<%#Eval("Folder_Name")%>' CssClass="textAttachment"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="File Name">
                        <ItemStyle Width="25%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <%#Eval("Filename")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="View">
                        <HeaderStyle HorizontalAlign="center" />
                        <ItemStyle Width="9%" HorizontalAlign="center" />
                        <ItemTemplate>
                            <input type="hidden" id="hdnFileName" runat="server" value='<%#Eval("Filename") %>' />
                            <asp:ImageButton ID="imgDownloadDoc" runat="server" ImageUrl="~/Images/download.gif" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblMsg" runat="server" SkinID="MessageOrNote" Text="Currently There Is No Attachment.<br />Please Add One Or More Attachment."></asp:Label>
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
