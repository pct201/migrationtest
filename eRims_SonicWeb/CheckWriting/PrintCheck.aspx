<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintCheck.aspx.cs" Inherits="CheckWriting_PrintCheck"
    MasterPageFile="~/Default.master" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>

    <script type="text/javascript">
    function ConfirmPrint()
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
	        alert('Please select any check to Print.');
	    	return false;
	    }
	    else
	    {
            return confirm("Are you sure you want to Print selected checks?");
        }
        
    }
    </script>

    <script type="text/javascript">
    
    
    </script>

    <asp:ScriptManager ID="smPrintChkDetail" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <%--<asp:UpdatePanel ID="pnlPrintChkDetail" runat="server">
        <ContentTemplate>--%>
    <table width="100%">
        <tr>
            <td>
                <table width="100%" style="border-right: #7f7f7f 1pt solid; border-top: #7f7f7f 1pt solid;
                    border-left: #7f7f7f 1pt solid; border-bottom: #7f7f7f 1pt solid; text-align: left">
                    <tr>
                        <td class="ghc" align="left" colspan="2">
                            <asp:Label ID="lblHeader" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <div align="center">
                        <asp:Label ID="lblMessage" runat="server" SkinID="lblError"></asp:Label>
                    </div>
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
                        <td align="right" class="lc" colspan="2">
                            <asp:LinkButton ID="lnkBtnExportExcel" runat="server" Text="Export To Excel" OnClick="lnkBtnExportExcel_Click"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left;" colspan="2">
                            <asp:GridView ID="gvChkPrint" runat="server" Width="100%" AllowPaging="True" AllowSorting="true"
                                AutoGenerateColumns="false" OnSorting="gvChkPrint_Sorting" OnPageIndexChanging="gvChkPrint_PageIndexChanging" OnRowCreated="gvChkPrint_RowCreated">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <input name="chkItem" type="checkbox" value='<%# Eval("Pk_check_no")%>' onclick="javascript:UnCheckHeader('gvChkPrint')" />
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" />
                                        <HeaderTemplate>
                                            <input id="chkHeader" name="chkHeader" type="checkbox" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                        </HeaderTemplate>
                                        <HeaderStyle Width="10px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CEDClaimNo" HeaderText="Claim Number" SortExpression="CEDClaimNo" />
                                    <asp:BoundField DataField="AEPPayer" HeaderText="Claimant/Employee" SortExpression="AEPPayer">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AEPPayee" HeaderText="Payee" SortExpression="AEPPayee"></asp:BoundField>
                                    <asp:BoundField DataField="CDCheckNumber" HeaderText="Check Number" SortExpression="CDCheckNumber">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RecIssueDate" HeaderText="Issue Date" SortExpression="RecIssueDate"
                                        DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false" />
                                    <asp:BoundField DataField="Check_Amount" HeaderText="Payment Amount" SortExpression="Check_Amount"
                                        DataFormatString="{0:C}" HtmlEncode="false" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"></asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    Currently There Is No Check.
                                </EmptyDataTemplate>
                                <PagerSettings Visible="false" />
                                <PagerStyle BackColor="#7F7F7F" BorderColor="#7F7F7F" HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%; color: Red; font-weight: bolder;" align="left" class="lc">
                            Total of all records</td>
                        <td style="width: 50%; padding-right: 5px;" align="right" class="lc">
                            <asp:Label ID="lblTotalAmount" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Button ID="btnPrintCheck" runat="server" Text="Print Checks" OnClick="btnPrintCheck_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="80%">
        <tr>
            <td>
            &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                <div style="width:500px;display:block;">
                <table width="50%">
                    <tr>
                        <td>
                            <rsweb:ReportViewer ID="rptViewer" runat="server" Width="100%"  ShowFindControls="false" ShowExportControls="true"  
                                DocumentMapCollapsed="True" BackColor="White" SizeToReportContent="true" ShowBackButton="True" ShowToolBar="true"
                                ShowParameterPrompts="False" ShowPromptAreaButton="False" AsyncRendering="False"
                                EnableTheming="false" 
                                Height="100%" >
                            </rsweb:ReportViewer>
                            
                        </td>
                    </tr>
                </table>
                </div>
            </td>
        </tr>
    </table>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
