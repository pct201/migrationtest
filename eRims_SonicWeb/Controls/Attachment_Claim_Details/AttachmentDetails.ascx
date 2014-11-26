<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AttachmentDetails.ascx.cs"
    Inherits="Controls_AttachmentDetails_AttachmentDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>    
<script type="text/javascript">
    function CheckSelected()
    {
        var ctrls = document.getElementsByTagName('input');
        var i;
        var cnt=0;
        for(i=0;i<ctrls.length;i++)
        {
            if(ctrls[i].type=="checkbox" && ctrls[i].id.indexOf("chkSelect") > 0)
            {
                if(ctrls[i].checked)
                    cnt++;
            }
        }   
        
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
  
  function openWindow(strURL)
  {
        oWnd=window.open(strURL,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
        oWnd.moveTo(260,180);
        return false;
  }
 
 
  function ShowMailPage(attTbl)
  {
        var gv = document.getElementById('<%=gvAttachment.ClientID%>');
        var ctrls = gv.getElementsByTagName('input');
        var i;
        var cnt=0;
        var m_strAttIds = '';
        for(i=0;i<ctrls.length;i++)
        {
            if(ctrls[i].type=="checkbox" && ctrls[i].id.indexOf("chkSelect") > 0)
            {
                if(ctrls[i].checked)
                {
                    var ctrlId = ctrls[i].id;
                    ctrlId =ctrlId.substring(ctrlId.lastIndexOf("_")- 2);                    
                    var index = ctrlId.replace("_chkSelect",""); 
                    index = Number(index)-2;
                    var id = document.getElementById("hdnIDClaim" + index).value;
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
        
        if (cnt==0)
        {
            alert("Please select any attachment to mail.");
            return false;
        }
        else
        {
            var oWnd=window.open("<%=AppConfig.SiteURL%>ErimsMail.aspx?AttMod="+attTbl+"&AttIds=" + m_strAttIds ,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=600,height=300");
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
    <tr class="bandHeaderRow">
        <td align="left" style="height: 22px;">
            Attachment Details</td>
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
                            <input type="hidden" id='hdnIDClaim<%#Container.DataItemIndex%>' value='<%#Eval("PK_Attachment_Id")%>'/>
                            <input type="hidden" id="hdnIDClaim" runat="server"
                                value='<%#Eval("PK_Attachment_Id")%>' /></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Attachment Type" Visible="false">
                        <ItemStyle Width="23%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <%#Eval("Attachment_Type")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Attachment Description">
                        <ItemStyle Width="38%" HorizontalAlign="left" />
                        <ItemTemplate>                        
                        <asp:Label ID="lblDesc" runat="server" Width="250px" Text='<%#Eval("Attachment_Description")%>' CssClass="textAttachment"></asp:Label>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="File Name">
                        <ItemStyle Width="25%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <%#Eval("Attachment_Name1")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="View">
                        <HeaderStyle HorizontalAlign="center" />
                        <ItemStyle Width="9%" HorizontalAlign="center" />
                        <ItemTemplate>
                            <input type="hidden" id="hdnFileName" runat="server" value='<%#Eval("Attachment_Name") %>' />
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
