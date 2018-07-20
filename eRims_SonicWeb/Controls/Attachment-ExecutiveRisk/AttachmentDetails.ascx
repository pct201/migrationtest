<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AttachmentDetails.ascx.cs"
    Inherits="Controls_AttachmentDetails_AttachmentDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>    
<script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js">
    </script>
<script type="text/javascript">
    function CheckSelected(btnRemove)
    {
        var ctrls='';
        if (btnRemove.id.indexOf("AttachDetails_Lease") != -1)
        {
            ctrls = document.getElementById("ctl00_ContentPlaceHolder1_AttachDetails_Lease_gvAttachment").getElementsByTagName('input');
        }
        else if (btnRemove.id.indexOf("AttachDetails_Mortgage") != -1)
        {
            ctrls = document.getElementById("ctl00_ContentPlaceHolder1_AttachDetails_Mortgage_gvAttachment").getElementsByTagName('input');
        }
        else if (btnRemove.id.indexOf("AttachDetails_Appraisal") != -1)
        {
            ctrls = document.getElementById("ctl00_ContentPlaceHolder1_AttachDetails_Appraisal_gvAttachment").getElementsByTagName('input');
        }
        else
        {
            ctrls = document.getElementsByTagName('input');
        }
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
        //oWnd.moveTo(260,180);
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
                    var id = document.getElementById("hdnID" + index).value;
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
            ShowDialog("<%=AppConfig.SiteURL%>ErimsMail.aspx?AttMod="+attTbl+"&AttIds=" + m_strAttIds);
            //var oWnd=window.open("<%=AppConfig.SiteURL%>ErimsMail.aspx?AttMod="+attTbl+"&AttIds=" + m_strAttIds ,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=600,height=300");
            //oWnd.moveTo(260,180);
            return false;
        }
  }

    function ShowMailPage_ForLease(attTbl, attFor)
    {
        var client_id = '';
        if (attFor == 'Lease'){
            client_id = "ctl00_ContentPlaceHolder1_AttachDetails_Lease_gvAttachment";
        }
        else if (attFor == 'Mortgage'){
            client_id = "ctl00_ContentPlaceHolder1_AttachDetails_Mortgage_gvAttachment";
        }
        else if (attFor == 'Appraisal'){
            client_id = "ctl00_ContentPlaceHolder1_AttachDetails_Appraisal_gvAttachment";
        }

        var gv = document.getElementById(client_id);
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
                    //var id = gv.getElementById("hdnID" + index).value;

                    var id = $("#" + client_id).find("input[type=hidden][id*='hdnID"+index+"' ]").val();

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
            ShowDialog("<%=AppConfig.SiteURL%>ErimsMail.aspx?AttMod="+attTbl+"&AttIds=" + m_strAttIds);
            //var oWnd=window.open("<%=AppConfig.SiteURL%>ErimsMail.aspx?AttMod="+attTbl+"&AttIds=" + m_strAttIds ,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=600,height=300");
            //oWnd.moveTo(260,180);
            return false;
        }
    }
   
   function OpenPopupReplacement(pk,attachmentType,strFilePath, TableName)
   {
        var attPanel = '<%=IntAttachmentPanel%>';
        if(attPanel != '' || attPanel != null)
        {ShowPanel(attPanel);}
        var navigateurl = "<%=AppConfig.SiteURL%>ReplaceAttachment.aspx?pk=" + pk + "&type=" + attachmentType + "&filename=" + strFilePath + "&tbl=" + TableName + "&btnID=<%=btnUpdateGrid.ClientID%>";
        var w = 400, h = 250;
        
        
       if (document.all || document.layers)
       {
        w = screen.availWidth;
        h = screen.availHeight;
       }
       
        var leftPos,topPos;
        var popW = 400, popH = 200;
        if(document.all)    
        {leftPos = (w-popW)/2; topPos = (h-popH)/2;}
        else
        {leftPos = w/2; topPos = h/2;}
        
        window.open(navigateurl ,"popup","toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos +",left=" + leftPos);         

   }

    function OpenPopupReplacement(pk, attachmentType, strFilePath, TableName, attFor) {
        var attPanel = '';
        if (attFor == 'Lease') {
            attPanel = '13';
        }
        else if (attFor == 'Mortgage') {
            attPanel = '14';
        }
        else if (attFor == 'Appraisal') {
            attPanel = '15';
        }
        if (attPanel != '' || attPanel != null)
        { ShowPanel(attPanel); }
        var navigateurl = "<%=AppConfig.SiteURL%>ReplaceAttachment.aspx?pk=" + pk + "&type=" + attachmentType + "&filename=" + strFilePath + "&tbl=" + TableName + "&btnID=<%=btnUpdateGrid.ClientID%>";
        var w = 400, h = 250;


        if (document.all || document.layers) {
            w = screen.availWidth;
            h = screen.availHeight;
        }

        var leftPos, topPos;
        var popW = 400, popH = 200;
        if (document.all)
        { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
        else
        { leftPos = w / 2; topPos = h / 2; }

        window.open(navigateurl, "popup", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);

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
                Width="100%" OnRowDataBound="gvAttachment_RowDataBound" OnRowCommand="gvAttachment_RowCommand">
                <Columns>
                    <asp:TemplateField>
                        <ItemStyle Width="5%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" /> 
                            <input type="hidden" id='hdnID<%#Container.DataItemIndex%>' value='<%#Eval("PK_Attachment_Id")%>'/>
                            <input type="hidden" id="hdnID" runat="server"
                                value='<%#Eval("PK_Attachment_Id")%>' /></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Attachment Type">
                        <ItemStyle Width="23%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkAttachType" runat="server" Text='<%#Eval("Attachment_Type")%>' CommandArgument='<%#Eval("Attachment_Name1") + ":" + Eval("Attachment_Name") %>' CommandName="EditDocument" />                            
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
                         <asp:Label ID="lblAttachmentName" runat="server" Width="250px" Text='<%#Eval("Attachment_Name1")%>' CssClass="textAttachment"></asp:Label>
                       <%-- <asp:LinkButton ID="lnkAttachmentName" runat="server" Text='<%#Eval("Attachment_Name1")%>' CommandArgument='<%#Eval("Attachment_Name1") + ":" + Eval("Attachment_Name") %>' CommandName="EditDocument" /> --%>                         
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
                    <asp:TemplateField HeaderText="Replace">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkReplace" runat="server" Text="Replace" CommandArgument='<%#Eval("PK_Attachment_Id") + ":" + Eval("Attachment_Type") + ":" + Eval("Attachment_Name") %>' CommandName="ReplaceDoc" />                            
                        </ItemTemplate>
                    </asp:TemplateField>                    
                </Columns>
                <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text="Currently There Is No Attachment.<br />Please Add One Or More Attachment."></asp:Label>
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
                OnClick="btnRemoveAttachment_Click" OnClientClick="return CheckSelected(this);" />            
            <asp:Button ID="btnMail" runat="server" Text="Mail" Visible="false" />
            <asp:Button ID="btnUpdateGrid" runat="server" style="display:none" OnClick="btnUpdateGrid_Click" />
        </td>
    </tr>
</table>
