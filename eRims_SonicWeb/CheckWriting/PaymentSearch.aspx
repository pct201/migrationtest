<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentSearch.aspx.cs" Inherits="CheckWriting_PaymentSearch" MasterPageFile="~/Default.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:ScriptManager runat="server" id="scManager">
    </asp:ScriptManager>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="false"
            ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
    </div>
    
    <script type="text/javascript">
    
    function claimsearch()
    {
        if(document.getElementById("ctl00_ContentPlaceHolder1_ddlSearch").value=="Employee")
        {
            oWnd=window.open("../WorkerCompensation/Employee_Search_Popup.aspx?Page=ClaimSearch","Erims1","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            oWnd.moveTo(300,200);
            return false;
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_ddlSearch").value=="Claimant")
        {
            oWnd=window.open("../Liability/Claimant_search.aspx?Page=ClaimSearch","Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=600,height=300");
            oWnd.moveTo(300,200);
            return false;
        }
    }
     function Search()
    { 
        if(document.getElementById("ctl00_ContentPlaceHolder1_txtClaimNo").value=="__-_____-__")
        {
            document.getElementById("ctl00_ContentPlaceHolder1_txtClaimNo").value="";
        }   
        if(document.getElementById("ctl00_ContentPlaceHolder1_txtSSN").value=="___-__-____")
        {
            document.getElementById("ctl00_ContentPlaceHolder1_txtSSN").value="";
        }    
        return true;
    }
    
    </script>
    
    <link href="../App_Themes/Default/stylecal.css" type="text/css" rel="Stylesheet" />
    <div style="width: 100%;" runat="server" id="divSearch">
        <table border="1" cellpadding="0" cellspacing="2" style="width: 98%;" >
            <tr>
                <td class="ghc" >
                    Search
                </td>
            </tr>
            <tr>
                <td >
                    <table cellpadding="0" cellspacing="4" border="0" style="width: 80%;">
                        
                        <tr>
                            <td colspan="5">
                                <asp:TextBox runat="server" ID="txtEmpID" style="display:none;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="ic" style="width: 20%;" valign="top">
                                <asp:DropDownList runat="server" ID="ddlSearch" AutoPostBack="true" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged">                                    
                                    <asp:ListItem Value="Employee" Text="Employee"></asp:ListItem>
                                    <asp:ListItem Value="Claimant" Text="Claimant"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="lc" style="width: 5%;">
                                :
                            </td>
                            <td class="ic" style="width: 25%;">
                                 <asp:TextBox ReadOnly="true" runat="server" ID="txtLastName"></asp:TextBox>                               
                                <asp:Button runat="server" UseSubmitBehavior="false" ID="btnEmpSearch" Text=">>" OnClientClick="javascript:return claimsearch();" /><br />
                                 (Last Name)
                            </td>
                            <td class="ic" style="width: 25%;">
                                <asp:TextBox ReadOnly="true" runat="server" ID="txtMiddleName"></asp:TextBox><br />
                                (Middle Name)
                            </td>
                            <td class="ic" style="width: 25%;">
                                <asp:TextBox ReadOnly="true" runat="server" ID="txtFirstName"></asp:TextBox><br />
                                (First Name)
                            </td>
                        </tr>
                        <tr style="display:none;">
                            <td class="ic">ok
                                <asp:Label ID="lblSSN" runat="server">SSN</asp:Label>
                            </td>
                            <td class="lc">
                                :
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtSSN" runat="server"></asp:TextBox>
                                 <cc1:MaskedEditExtender ID="mskSSN" runat="server" TargetControlID="txtSSN"
                                 Mask="999-99-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                </cc1:MaskedEditExtender>
                                <asp:RegularExpressionValidator ID="revSSN" ControlToValidate="txtSSN" runat="server"
                                ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the SSN in xxx-xx-xxxx format."
                                Display="none" ValidationExpression="\d{3}-\d{2}-\d{4}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ic">
                                <asp:Label ID="lblDOIncident" runat="server">Date of Incident</asp:Label>
                            </td>
                            <td class="lc">
                                :
                            </td>
                            <td  class="ic">
                                <asp:TextBox ID="txtDOIncident" runat="server" SkinID="txtDate"></asp:TextBox>
                                <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDOIncident', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                    align="middle" /><br />
                                <cc1:MaskedEditExtender ID="mskDOIncident" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                    Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtDOIncident" CultureName="en-US"
                                    AutoComplete="true" AutoCompleteValue="05/23/1964">
                                </cc1:MaskedEditExtender>
                                <cc1:MaskedEditValidator ID="mskVDOIncident" runat="server" ControlExtender="mskDOIncident"
                                    ControlToValidate="txtDOIncident" Display="none" IsValidEmpty="true" MaximumValue=""
                                    InvalidValueMessage="Date is invalid." MaximumValueMessage="" MinimumValueMessage=""
                                    TooltipMessage="" MinimumValue="">
                                </cc1:MaskedEditValidator>
                                <asp:RegularExpressionValidator id="revDOInciden" runat="server" ControlToValidate="txtDOIncident"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="Date Not Valid(Date of Incident)." Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ic" valign="top">
                                <asp:Label ID="lblClaimType" runat="server">Claim Type</asp:Label>
                            </td>
                            <td class="ic" valign="top">
                                :
                            </td>
                            <td class="ic" colspan="3">
                                 <asp:CheckBoxList ID="chkLstClaimType" runat="server" RepeatDirection="vertical">
                                    <asp:ListItem Text="Workers Compensation" Value="Workers_Comp"></asp:ListItem>
                                    <asp:ListItem Text="Auto Liability" Value="Liability_Claim"></asp:ListItem>
                                    <asp:ListItem Text="General Liability" Value="Liability_Claim"></asp:ListItem>
                                    <asp:ListItem Text="Property Loss" Value="Liability_Claim"></asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td class="ic">
                                <asp:Label runat="server" ID="lblCliamNo">Claim Number</asp:Label>
                            </td>
                            <td class="ic">
                                :
                            </td>
                            <td class="ic" colspan="3">
                                <asp:TextBox runat="server" ID="txtClaimNo"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="mskClaimNo" runat="server" TargetControlID="txtClaimNo"
                                 Mask="99-99999-99" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                </cc1:MaskedEditExtender>
                                <asp:RegularExpressionValidator ID="rev3AdminTel" ControlToValidate="txtClaimNo" runat="server"
                                ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Claim Number in xx-xxxxx-xx format."
                                Display="none" ValidationExpression="\d{2}-\d{5}-\d{2}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <table cellpadding="0" cellspacing="2" border="0" width="100%">
                                    <tr>
                                        <td style="width: 20%" class="ic">
                                            <asp:Label runat="server" ID="lblOClFrom">Open Claims From</asp:Label>
                                        </td>
                                        <td style="width: 5%" class="ic">
                                            :
                                        </td>
                                        <td style="width: 25%;" class="ic">
                                            &nbsp;<asp:TextBox ID="txtOCFrom" runat="server" SkinID="txtDate"></asp:TextBox>
                                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtOCFrom', 'mm/dd/y');"
                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                align="middle" /><br />
                                            <cc1:MaskedEditExtender ID="mskeOCFrom" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                OnInvalidCssClass="MaskedEditError" TargetControlID="txtOCFrom" CultureName="en-US"
                                                AutoComplete="true" AutoCompleteValue="05/23/1964">
                                            </cc1:MaskedEditExtender>
                                            <cc1:MaskedEditValidator ID="mskvOCFrom" runat="server" ControlExtender="mskeOCFrom"
                                                ControlToValidate="txtOCFrom" Display="None" IsValidEmpty="true" MaximumValue=""
                                                InvalidValueMessage="Date is invalid" MaximumValueMessage="" MinimumValueMessage=""
                                                TooltipMessage="" MinimumValue="">
                                            </cc1:MaskedEditValidator>
                                            <asp:RegularExpressionValidator id="revOCFrom" runat="server" ControlToValidate="txtOCFrom"
                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                ErrorMessage="Date Not Valid(Open Claims From)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                        </td>
                                        <td style="width: 20%" class="ic">
                                            <asp:Label runat="server" ID="lblOCTo">Open Claims To</asp:Label>
                                        </td>
                                        <td style="width: 5%" class="ic">
                                            :
                                        </td>
                                        <td style="width: 25%;" class="ic">
                                            <asp:TextBox ID="txtOCTo" runat="server" SkinID="txtDate"></asp:TextBox>
                                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtOCTo', 'mm/dd/y');"
                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                align="middle" /><br />
                                            <cc1:MaskedEditExtender ID="mskeOCTo" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                OnInvalidCssClass="MaskedEditError" TargetControlID="txtOCTo" CultureName="en-US"
                                                AutoComplete="true" AutoCompleteValue="05/23/1964">
                                            </cc1:MaskedEditExtender>
                                            <cc1:MaskedEditValidator ID="mskeVOCTo" runat="server" ControlExtender="mskeOCTo"
                                                ControlToValidate="txtOCTo" Display="none" IsValidEmpty="true" MaximumValue=""
                                                InvalidValueMessage="Date is invalid" MaximumValueMessage="" MinimumValueMessage=""
                                                TooltipMessage="" MinimumValue="">
                                            </cc1:MaskedEditValidator>
                                            <asp:RegularExpressionValidator id="revOCTo" runat="server" ControlToValidate="txtOCTo"
                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                ErrorMessage="Date Not Valid(Open Claims To)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                            <asp:CompareValidator ID="cvCompOC" runat="server" ControlToValidate="txtOCTo"
                                                ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Open Claims To Greater Than Open Claims From."
                                                Type="Date" Operator="GreaterThan" ControlToCompare="txtOCFrom" Display="none">
                                            </asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="ic">
                                            <asp:Label runat="server" ID="Label1">Closed Claims From</asp:Label>
                                        </td>
                                        <td style="width: 5%" class="ic">
                                            :
                                        </td>
                                        <td style="width: 25%;" class="ic">
                                            &nbsp;<asp:TextBox ID="txtCCFrom" runat="server" SkinID="txtDate"></asp:TextBox>
                                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCCFrom', 'mm/dd/y');"
                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                align="middle" /><br />
                                            <cc1:MaskedEditExtender ID="mskeCCFrom" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                OnInvalidCssClass="MaskedEditError" TargetControlID="txtCCFrom" CultureName="en-US"
                                                AutoComplete="true" AutoCompleteValue="05/23/1964">
                                            </cc1:MaskedEditExtender>
                                            <cc1:MaskedEditValidator ID="mskeVCCFrom" runat="server" ControlExtender="mskeCCFrom"
                                                ControlToValidate="txtCCFrom" Display="none" IsValidEmpty="true" MaximumValue=""
                                                InvalidValueMessage="Date is invalid" MaximumValueMessage="" MinimumValueMessage=""
                                                TooltipMessage="" MinimumValue="" >
                                            </cc1:MaskedEditValidator>
                                            <asp:RegularExpressionValidator id="revCCFrom" runat="server" ControlToValidate="txtCCFrom"
                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                ErrorMessage="Date Not Valid(Closed Claims From)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                        </td>
                                        <td style="width: 20%" class="ic">
                                            <asp:Label runat="server" ID="Label2">Closed Claims To</asp:Label>
                                        </td>
                                        <td style="width: 5%" class="ic">
                                            :
                                        </td>
                                        <td style="width: 25%;" class="ic">
                                            <asp:TextBox ID="txtCCTo" runat="server" SkinID="txtDate"></asp:TextBox>
                                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCCTo', 'mm/dd/y');"
                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                align="middle" /><br />
                                            <cc1:MaskedEditExtender ID="mskeCCTo" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                OnInvalidCssClass="MaskedEditError" TargetControlID="txtCCTo" CultureName="en-US"
                                                AutoComplete="true" AutoCompleteValue="05/23/1964">
                                            </cc1:MaskedEditExtender>
                                            <cc1:MaskedEditValidator ID="mskeVCCTo" runat="server" ControlExtender="mskeCCTo"
                                                ControlToValidate="txtCCTo" Display="none" IsValidEmpty="true" MaximumValue=""
                                                InvalidValueMessage="Date is invalid" MaximumValueMessage="" MinimumValueMessage=""
                                                TooltipMessage="" MinimumValue="" >
                                            </cc1:MaskedEditValidator>
                                            <asp:RegularExpressionValidator id="revCCTo" runat="server" ControlToValidate="txtCCTo"
                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                ErrorMessage="Date Not Valid(Closed Claims To)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                            <asp:CompareValidator ID="cmCompCC" runat="server" ControlToValidate="txtCCTo"
                                                ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Closed Claims To Greater Than Closed Claims From."
                                                Type="Date" Operator="GreaterThan" ControlToCompare="txtCCFrom" Display="none">
                                            </asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="ic" align="center" colspan="5">
                                <asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" ValidationGroup="vsErrorGroup" OnClientClick="javascript:Search();" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div style="width: 100%;display:none;" runat="server" id="divGrid" >
        <table cellpadding="0" cellspacing="2" border="0" style="width: 99%;">
            <tr>
                <td>
                    <table cellpadding="2" cellspacing="4" border="0" style="width: 100%;">
                        <tr>
                            <td align="left" class="ghc">
                                Search Result
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <asp:GridView ID="gvSearch" runat="server" Width="100%" OnRowCommand="gvSearch_RowCommand"
                                    AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" OnSorting="gvSearch_Sorting"
                                    OnPageIndexChanging="gvSearch_PageIndexChanging" OnRowDataBound="gvSearch_RowDataBound" PageSize="20">
                                    <Columns>  
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblPrimaryID" Text='<%# Eval("PK_Employee_ID") %>' Visible="false"></asp:Label>
                                                <asp:Label runat="server" ID="lblTableName" Text='<%# Eval("TableName") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                     
                                        <asp:BoundField DataField="Claim_Number" HeaderText="Claim Number" SortExpression="Claim_Number">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Social_Security_Number" Visible="false" HeaderText="SSN" SortExpression="Social_Security_Number">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Last_Name" HeaderText="Last Name" SortExpression="Last_Name">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="First_Name" HeaderText="First Name" SortExpression="First_Name">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Middle_Name" HeaderText="Middle Name" SortExpression="Middle_Name">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Incident_Date" HeaderText="Date Of Incident" SortExpression="Incident_Date"
                                            DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false"></asp:BoundField>                                        
                                        <asp:BoundField DataField="Claim_Close_Date" HeaderText="Close Date" SortExpression="Claim_Close_Date"
                                            DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false">
                                        </asp:BoundField>                                        
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnAddPay" CommandName="Payment" 
                                                    runat="server" Text="Add Payment" ToolTip="Add Payment" CommandArgument='<%# Eval("Claim_Number") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%# Eval("PK_Employee_ID") %>'
                                                    ToolTip="View the Check Details" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                        </asp:TemplateField>--%>
                                    </Columns>
                                    <EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
                                    <EmptyDataTemplate>
                                        No data found.<br />
                                        <%--<br />
                                        <asp:Button ID="btnBack" runat="server" Text="Back To Search" OnClick="btnBack_Click" />--%>
                                    </EmptyDataTemplate>
                                    <PagerSettings Visible="true" />
                                    <PagerStyle BackColor="#7F7F7F" BorderColor="#7F7F7F" HorizontalAlign="Left" VerticalAlign="Middle" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnMainBack" runat="server" Text="Back To Search" OnClick="btnBack_Click" Visible="false" />
                </td>
            </tr>
        </table>
    </div>
    <br />
</asp:Content>
