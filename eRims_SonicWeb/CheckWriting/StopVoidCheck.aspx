<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StopVoidCheck.aspx.cs" Inherits="CheckWriting_StopVoidCheck"
    MasterPageFile="~/Default.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>

    <script type="text/javascript">
    function ConfirmStopVoid(m_strMsg)
    {
        
        var isChecked = false;
	    for(i=0;i<document.forms[0].elements.length;i++)
        {
            if((document.forms[0].elements[i].type=='checkbox') && (document.forms[0].elements[i].name !="chkHeader"))
            {
                if(document.forms[0].elements[i].checked  == true)
                       isChecked= true;
            }
        }   
	    if(!isChecked)
	    {
	        alert('Please select any check to '+m_strMsg);
	    	return false;
	    }
	    else
	    {
            return confirm('Are you sure you want to '+m_strMsg+' selected checks?');
        }
    }
    </script>
    
    <asp:ScriptManager ID="smStopChkDetail" EnablePageMethods="true" runat="server">
       
    </asp:ScriptManager>
    <div style="display:none;">
    <asp:Label ID="lblScript" runat="server"></asp:Label>
    </div>
    <%--<asp:UpdatePanel ID="pnlStopChkDetail" runat="server">
        <ContentTemplate>--%>
            <table width="100%">
                <tr>
                    <td>
                        <table style="border-right: #7f7f7f 1pt solid; border-top: #7f7f7f 1pt solid; border-left: #7f7f7f 1pt solid;
                            border-bottom: #7f7f7f 1pt solid; text-align: left" width="100%">
                            <tbody>
                                <tr>
                                    <td class="ghc" align="left" colspan="2">
                                        <asp:Label ID="lblHeader" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr><td colspan="2" style="width: 80%;" align="right">
                    <table width="50%">
                    <tr>
                        
                        <td class="lc">
                            No. of Records per page :
                            <asp:DropDownList ID="ddlPage" SkinID="dropGen" runat="server" DataSourceID="xdsPaging"
                                DataTextField="Text" DataValueField="Value" AutoPostBack="True" OnSelectedIndexChanged="ddlPage_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:XmlDataSource ID="xdsPaging" runat="server" DataFile="~/App_Data/PagingTable.xml">
                            </asp:XmlDataSource>
                        </td>
                        <td class="ic">
                            <asp:Button ID="btnPrev" runat="server" OnClick="btnPrev_Click" Text=" < " SkinID="btnGen" />
                        </td>
                        <td class="lc">
                            <asp:Label ID="lblPageInfo" runat="server"></asp:Label>
                        </td>
                        <td class="ic">
                            <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text=" > " SkinID="btnGen" />
                        </td>
                        <td class="lc">
                            Go to Page:</td>
                        <td class="ic">
                            <asp:TextBox ID="txtPageNo" MaxLength="3" runat="server" Width="20px" onkeypress="return numberOnly(event);"></asp:TextBox>
                        </td>
                        <td class="ic">
                            <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" /></td>
                    </tr>
                    </table>
                    </td></tr>
                                <tr>
                                    <td class="lc" align="right" colspan="2">
                                        <asp:LinkButton ID="lnkBtnExportExcel" runat="server" Text="Export To Excel" OnClick="lnkBtnExportExcel_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left" colspan="2">
                                        <asp:GridView ID="gvChkStopVoid" runat="server" Width="100%" AutoGenerateColumns="false" 
                                            AllowSorting="true" AllowPaging="true" OnSorting="gvChkStopVoid_Sorting" OnPageIndexChanging="gvChkStopVoid_PageIndexChanging"  OnRowCreated="gvChkStopVoid_RowCreated">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <input name="chkItem" type="checkbox" value='<%# Eval("Pk_check_no")%>' onclick="javascript:UnCheckHeader('gvChkStopVoid')" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="10px" />
                                                    <HeaderTemplate>
                                                        <input id="chkHeader" name="chkHeader" type="checkbox"  runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                                    </HeaderTemplate>
                                                    <HeaderStyle Width="10px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="RecIssueDate" HeaderText="Issue Date" SortExpression="RecIssueDate"
                                                    DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="False" />
                                                <asp:BoundField DataField="CDCheckNumber" HeaderText="Check Number" SortExpression="CDCheckNumber">
                                                </asp:BoundField>
                                                <%--<asp:BoundField DataField="AEPPaymentID" HeaderText="PaymentID" SortExpression="AEPPaymentID">
                                                </asp:BoundField>--%>
                                                <asp:BoundField DataField="AEPDtServiceBegin" HeaderText="Begin Date" SortExpression="AEPDtServiceBegin"
                                                    DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="False" />
                                                <asp:BoundField DataField="AEPDtServiceEnd" HeaderText="End Date" SortExpression="AEPDtServiceEnd"
                                                    DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="False" />
                                                <asp:BoundField DataField="AEPPayee" HeaderText="Payee" SortExpression="AEPPayee"></asp:BoundField>
                                                <asp:BoundField DataField="AEPInvoiceNo" HeaderText="Invoice Number" SortExpression="AEPInvoiceNo">
                                                </asp:BoundField>
                                                
                                                <asp:BoundField DataField="CEDClaimNo" HeaderText="Claim Number" SortExpression="CEDClaimNo" />
                                                <asp:BoundField DataField="Check_Amount" HeaderText="Payment Amount" SortExpression="Check_Amount"
                                                    DataFormatString="{0:C}" HtmlEncode="False" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"></asp:BoundField>
                                            </Columns>
                                            <EmptyDataRowStyle ForeColor="#7F7F7F" HorizontalAlign="Center" />
                                            <EmptyDataTemplate>
                                                Currently There Is No Check to Stop/Void.
                                            </EmptyDataTemplate>
                                            <PagerSettings Visible="false" />
                                        <PagerStyle BackColor="#7F7F7F" BorderColor="#7F7F7F" HorizontalAlign="Left" VerticalAlign="Middle"  />
                                       
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bolder; width: 50%; color: red" class="lc" align="left">
                                        Total of all records</td>
                                    <td style="padding-right: 5px; width: 50%" class="lc" align="right">
                                        <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Button ID="btnStopCheck" OnClick="btnStopCheck_Click" runat="server" Text="Stop Checks">
                                        </asp:Button>
                                        <asp:Button ID="btnVoidCheck" runat="server" Text="Void Checks" OnClick="btnVoidCheck_Click">
                                        </asp:Button>
                                    </td>
                                </tr>
                        </table>
                    </td>
                </tr>
            </table>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
