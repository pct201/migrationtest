<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_RE_Security_Deposit.aspx.cs" Inherits="SONIC_RealEstate_AuditPopup_RE_Security_Deposit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: RE_Security_Deposit Audit Trail</title>
</head>
<script language="javascript" type="text/javascript">
    function showAudit(divHeader,divGrid)
    {        
        var divheight,i;
       
        divHeader.style.width = window.screen.availWidth - 225 + "px";
        divGrid.style.width = window.screen.availWidth - 225 + "px";
        
        divheight = divGrid.style.height;        
        i = divheight.indexOf('px');        
        
        if(i > -1)        
            divheight = divheight.substring(0,i);
        if (divheight > (window.screen.availHeight - 350) && divGrid.style.height != "")
        {            
            divGrid.style.height = window.screen.availHeight - 350;
        }
    }
    
    function ChangeScrollBar(f,s)
    {
        s.scrollTop = f.scrollTop;
        s.scrollLeft = f.scrollLeft;
    }
</script>

<body>
    <form id="form1" runat="server">
    <table width="100%" align="left">
        <tr>
            <td align="left">
                <asp:Label ID="lbltable_Name" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td align="right">
                <a href="javascript:window.close();">Close Window</a>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="overflow: hidden; width: 650px;" id="dvHeader" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Audit_DateTime</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">PK_RE_Security_Deposit</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">FK_RE_Information</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:130px;">Amount</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Date of Security Deposit</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:130px;">Tender Type</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Received By</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Bank Name</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:130px;">Check Number</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Name Printed on Check</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:120px;">Account Number</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Security Deposit Held At</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Security Deposit Returned?</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:300px;">Date Security Deposit Returned</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Security Deposit Reduced?</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:300px;">Security_Deposit_Reduction_Reason</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:300px;">Interest_On_Security_Deposit</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Interest Amount</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:300px;">Amount_Security_Deposit_Returned</span>
                                </th>                                
                                <th class="cols">
                                    <span style="display: inline-block; width: 110px;">Updated_By</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 117px;">Updated_Date</span>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 600px; height: 425px;" id="dvGrid" runat="server">
                    <asp:GridView ID="gvRE_Security_Deposit" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                        <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <Columns>
                            <asp:TemplateField HeaderText="Audit_DateTime">
                                <ItemStyle CssClass="cols" Width="100px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PK_RE_Security_Deposit" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblPK_RE_Security_Deposit" runat="server" Text='<%#Eval("PK_RE_Security_Deposit")%>' Width="200px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_RE_Information" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblFK_RE_Information" runat="server" Text='<%#Eval("FK_RE_Information")%>' Width="150px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblAmount" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Amount"))%>' Width="130px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date_Of_Security_Deposit" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblDate_Of_Security_Deposit" runat="server" Text='<%#Eval("Date_Of_Security_Deposit") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Of_Security_Deposit"))) : ""%>' Width="200px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Tender_Type" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblFK_LU_Tender_Type" runat="server" Text='<%#Eval("FK_LU_Tender_Type")%>' Width="130px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Received_By" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblReceived_By" runat="server" Text='<%#Eval("Received_By")%>' Width="150px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bank_Name" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblBank_Name" runat="server" Text='<%#Eval("Bank_Name")%>' Width="150px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Check_Number" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblCheck_Number" runat="server" Text='<%#Eval("Check_Number")%>' Width="130px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name_On_Check" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblName_On_Check" runat="server" Text='<%#Eval("Name_On_Check")%>' Width="200px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Account_Number" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblAccount_Number" runat="server" Text='<%#Eval("Account_Number")%>' Width="120px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Security_Deposit_Held" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblFK_LU_Security_Deposit_Held" runat="server" Text='<%#Eval("FK_LU_Security_Deposit_Held")%>' Width="200px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Security_Deposit_Returned" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblSecurity_Deposit_Returned" runat="server" Text='<%#Eval("Security_Deposit_Returned").ToString() == "Y" ? "Yes" : "No" %>' Width="200px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date_Security_Deposit_Returned" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblDate_Security_Deposit_Returned" runat="server" Text='<%#Eval("Date_Security_Deposit_Returned") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Security_Deposit_Returned"))) : ""%>' Width="300px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Security_Deposit_Reduced" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblSecurity_Deposit_Reduced" runat="server" Text='<%#Eval("Security_Deposit_Reduced").ToString() == "Y" ? "Yes" : "No" %>' Width="200px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Security_Deposit_Reduction_Reason" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblSecurity_Deposit_Reduction_Reason" runat="server" Text='<%#Eval("Security_Deposit_Reduction_Reason")%>' Width="300px" CssClass="TextClip"></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Interest_On_Security_Deposit" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblInterest_On_Security_Deposit" runat="server" Text='<%#Eval("Interest_On_Security_Deposit").ToString() == "Y" ? "Yes" : "No" %>' Width="300px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Interest_Amount" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblInterest_Amount" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Interest_Amount"))%>' Width="150px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount_Security_Deposit_Returned" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblAmount_Security_Deposit_Returned" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Amount_Security_Deposit_Returned"))%>' Width="300px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_By">
                                <ItemStyle CssClass="cols" Width="110px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("user_Name")%>' Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_Date">
                                <ItemStyle CssClass="cols" Width="100px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_Date" runat="server" Text='<%#Eval("Update_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Update_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
