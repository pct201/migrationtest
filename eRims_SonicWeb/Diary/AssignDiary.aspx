<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AssignDiary.aspx.cs" Inherits="Diary_AssignDiary"
    MasterPageFile="~/Default.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>
    <script type="text/javascript">
    function IsMultipleChecked()
    {
    
        var isChecked;
        var mulCheck=0;
        for(i=0;i<document.forms[0].elements.length;i++)
        {
            if((document.forms[0].elements[i].type=='checkbox') && (document.forms[0].elements[i].name !="chkHeader"))
            {
                if(document.forms[0].elements[i].checked  == true)
                       {
                            isChecked= true;
                            mulCheck=mulCheck+1;
                       }
            }
        }   
	    if(!isChecked)
	    {
	        alert('Please select any record.');
	        return false;
	    }
	    if(mulCheck>1)
	    {
	        alert('No Multiple Selection Allowed.');
	        return false;
	    }
		return true;
    } 
    function OpenAssignWindow(grdName)
    {
        if(IsMultipleChecked())
        {
            var i,flag=0;
            var m_strClaimNo="";  
            for(i=0;i<document.forms[0].elements.length;i++)
            {
                if((document.forms[0].elements[i].type=='checkbox'))
                {
                     if(document.forms[0].elements[i].name !="ctl00$ContentPlaceHolder1$"+grdName+"$ctl01$chkHeader")
                        {
                        
                        if(document.forms[0].elements[i].checked  == true)
                            {  
                                if(m_strClaimNo=="")
                                {
                                    m_strClaimNo=document.forms[0].elements[i].value;
                                }
                                else
                                {
                                   m_strClaimNo=m_strClaimNo+","+document.forms[0].elements[i].value; 
                                }
                            }
                        }
                }
                
            }
            //alert(m_strClaimNo); 
            oWnd=window.open("AssignPopUp.aspx?" + m_strClaimNo ,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=600,height=300");
            oWnd.moveTo(260,180);
            return false;
        }
        else
        {
            return false;
        }
        
        
    }
    </script>
    <table width="100%">
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td style="text-align: left;">
                <asp:GridView ID="gvClaimToAssign" runat="server" AutoGenerateColumns="false" 
                    DataKeyNames="Claim_Number" Width="100%" OnPageIndexChanging="gvClaimToAssign_PageIndexChanging"
                    AllowPaging="True"   PageSize="20">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <input name="chkItem" type="checkbox" value='<%# Eval("Claim_Number1")%>' onclick="javascript:UnCheckHeader('gvClaimToAssign')" />
                            </ItemTemplate>
                            <ItemStyle Width="10px" />
                            <%--<HeaderTemplate>
                                <input id="chkHeader" type="checkbox" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                            </HeaderTemplate>--%>
                            <HeaderStyle Width="10px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Claim_Number" HeaderText="Claim Number" SortExpression="Claim_Number">
                        </asp:BoundField>
                        <asp:BoundField DataField="ClaimType" HeaderText="Claim Type" SortExpression="ClaimType">
                        </asp:BoundField>
                        <asp:BoundField DataField="FK_Cost_Center" HeaderText="Entity" SortExpression="FK_Cost_Center">
                        </asp:BoundField>
                        <asp:BoundField DataField="Incident_Date" HeaderText="Date Of Loss" SortExpression="Incident_Date" DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false">
                        </asp:BoundField>
                        
                    </Columns>
                    <PagerSettings Visible="False" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
            <asp:Button ID="btnAssign" runat="server" Text="Assign Diary" OnClientClick="javascript:return OpenAssignWindow('gvClaimToAssign');"/>
            </td>
        </tr>
    </table>
</asp:Content>
