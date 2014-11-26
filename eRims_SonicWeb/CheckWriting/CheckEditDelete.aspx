<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckEditDelete.aspx.cs"
    Inherits="CheckWriting_CheckEditDelete" MasterPageFile="~/Default.master" Theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery.maskedinput.js"></script>
    <link href="../App_Themes/Default/stylecal.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript">
        function ValSearch() {

            if (document.getElementById("ctl00_ContentPlaceHolder1_txtClaimNo").value == "__-_____-__")
                document.getElementById("ctl00_ContentPlaceHolder1_txtClaimNo").value = "";
            return true;

        }

        function MinMax(name) {
            if (name == "comment") {
                if (document.getElementById("ctl00_ContentPlaceHolder1_fvChkEditDel_txtComment").style.height == "") {
                    document.getElementById("ctl00_ContentPlaceHolder1_fvChkEditDel_ibtnComment").src = "../Images/minus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvChkEditDel_txtComment").style.height = "70px";
                    document.getElementById("pnlComment").style.display = "block";
                }
                else if (document.getElementById("ctl00_ContentPlaceHolder1_fvChkEditDel_txtComment").style.height == "70px") {
                    document.getElementById("ctl00_ContentPlaceHolder1_fvChkEditDel_ibtnComment").src = "../Images/plus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvChkEditDel_txtComment").style.height = "";
                    document.getElementById("pnlComment").style.display = "none";
                }
            }
            return false;
        }
        function Check() {
            if (parseInt(document.getElementById("ctl00_ContentPlaceHolder1_txtSChkNo").value) > 999999999999999999) {
                alert('Enter Valid Check Number');
                return false;
            }
            else if ((document.getElementById("ctl00_ContentPlaceHolder1_txtSChkNo").value) == "") {
                alert('Enter Valid Check Number');
                return false;
            }
            else {
                return true;
            }
        }
        function checkPayment() {
            if (parseFloat(document.getElementById("ctl00_ContentPlaceHolder1_fvChkEditDel_txtPayAmount").value.replace(",", "").replace(",", "")) <= 0) {
                alert("Enter Pay Amount Greater than $0.00");
                event.returnValue = false;
            }
            var enterAmt;
            var existAmt;
            var amt;
            enterAmt = (parseFloat(document.getElementById("ctl00_ContentPlaceHolder1_fvChkEditDel_txtPayAmount").value.replace(",", "").replace(",", "")));
            if (document.getElementById("ctl00_ContentPlaceHolder1_fvChkEditDel_ddlPaymentID").value == "Expense") {   //amt=document.getElementById("ctl00_ContentPlaceHolder1_lblEOutStand").innerText.replace(",","").replace(",","").substring(1,13);        
                //alert(amt);
                existAmt = parseFloat(document.getElementById("ctl00_ContentPlaceHolder1_fvChkEditDel_lblDEOutStand").innerText.replace(",", "").replace(",", "").substring(1, 13));
            }
            else if (document.getElementById("ctl00_ContentPlaceHolder1_fvChkEditDel_ddlPaymentID").value == "Property Damage") {
                existAmt = parseFloat(document.getElementById("ctl00_ContentPlaceHolder1_fvChkEditDel_lblDIOutStand").innerText.replace(",", "").replace(",", "").substring(1, 13));
            }
            else if (document.getElementById("ctl00_ContentPlaceHolder1_fvChkEditDel_ddlPaymentID").value == "Bodily Injury") {
                existAmt = parseFloat(document.getElementById("ctl00_ContentPlaceHolder1_fvChkEditDel_lblDMOutStand").innerText.replace(",", "").replace(",", "").substring(1, 13));
            }
            else {
                //alert("Please Select Payment Type");
                //return false;
                existAmt = 0;
            }

            //alert(enterAmt);
            //alert(existAmt);
            //alert(isNaN(enterAmt));
            if (isNaN(enterAmt) == true) {
                return true;
            }
            if (parseFloat(enterAmt) > parseFloat(existAmt)) {
                alert("Pay amount should be less than Outstanding amount.");
                event.returnValue = false;
                //return false;
            }
            else {
                return true;
            }
        }
        jQuery(function ($) {
            $("#<%=txtDtStart.ClientID%>").mask("99/99/9999");
            $("#<%=txtDtEnd.ClientID%>").mask("99/99/9999");
            $("#<%=txtFDtClose.ClientID%>").mask("99/99/9999");
            $("#<%=txtFDtCloseTo.ClientID%>").mask("99/99/9999");
            $("#<%=txtClaimNo.ClientID%>").mask("99-99999-99");
        });
    </script>
  <%--  <asp:ScriptManager ID="smBankDetail" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>--%>
    <asp:UpdatePanel ID="pnlBankDetail" runat="server">
        <ContentTemplate>
            <div>
                <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
                    HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
                    EnableClientScript="true" ValidationGroup="vsErrorGroup" CssClass="errormessage">
                </asp:ValidationSummary>
                <asp:CustomValidator ID="cvErrorMsg" runat="server" EnableClientScript="true" ValidationGroup="vsErrorGroup"
                    ErrorMessage="" Display="None"></asp:CustomValidator>
            </div>
            <table width="100%">
                <tbody>
                    <tr>
                        <td align="center">
                            <asp:MultiView ID="mvChkEditDel" runat="server">
                                <asp:View ID="vwChkNoEnter" runat="server">
                                    <table style="text-align: center" width="45%">
                                        <tbody>
                                            <tr style="height: 425px" valign="middle">
                                                <td style="width: 50%" class="lc">
                                                    Enter Check Number
                                                </td>
                                                <td class="lc">
                                                    :
                                                </td>
                                                <td style="width: 40%" class="ic">
                                                    <asp:TextBox ID="txtSChkNo" onkeypress="return numberOnly(event);" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvSearchChkNo" runat="server" ValidationGroup="vsErrorGroup"
                                                        ErrorMessage="Please Enter Check No." Display="None" ControlToValidate="txtSChkNo"
                                                        InitialValue="">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                                <td style="width: 10%" class="ic">
                                                    <asp:Button ID="btnSearch" OnClick="btnSearch_Click" OnClientClick="javascript:return Check();"
                                                        runat="server" ValidationGroup="vsErrorGroup" Text="Search"></asp:Button>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </asp:View>
                                <asp:View ID="vwChkDetails" runat="server">
                                    <table width="100%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Button ID="btnDelete" OnClick="btnDelete_Click" runat="server" Text="Delete">
                                                    </asp:Button>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left">
                                                    <asp:GridView ID="gvChkEditDel" runat="server" Width="100%" OnPageIndexChanging="gvChkEditDel_PageIndexChanging"
                                                        OnSorting="gvChkEditDel_Sorting" AutoGenerateColumns="false" AllowSorting="true"
                                                        AllowPaging="true" OnRowCommand="gvChkEditDel_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <input name="chkItem" type="checkbox" value='<%# Eval("pk_check_no")%>' onclick="javascript:UnCheckHeader('gvChkEditDel')" />
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10px" />
                                                                <HeaderTemplate>
                                                                    <input id="chkHeader" name="chkHeader" type="checkbox" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                                                </HeaderTemplate>
                                                                <HeaderStyle Width="10px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="CEDClaimNo" HeaderText="Claim Number" SortExpression="CEDClaimNo">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CDCheckNumber" HeaderText="Check Number" SortExpression="CDCheckNumber">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="RecIssueDate" HeaderText="Issue Date" SortExpression="RecIssueDate"
                                                                DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false"></asp:BoundField>
                                                            <asp:BoundField DataField="AEPPaymentID" HeaderText="PaymentID" SortExpression="AEPPaymentID">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="AEPDtServiceBegin" HeaderText="Begin Date" SortExpression="AEPDtServiceBegin"
                                                                DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false"></asp:BoundField>
                                                            <asp:BoundField DataField="AEPDtServiceEnd" HeaderText="End Date" SortExpression="AEPDtServiceEnd"
                                                                DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false"></asp:BoundField>
                                                            <asp:BoundField DataField="AEPInvoiceNo" HeaderText="Invoice Number" SortExpression="AEPInvoiceNo">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="AEPPayee" HeaderText="Payee Name" SortExpression="AEPPayee">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="check_Amount" HeaderText="Payment Amount" SortExpression="check_Amount"
                                                                DataFormatString="{0:C}" HtmlEncode="false" ItemStyle-HorizontalAlign="Right">
                                                            </asp:BoundField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnAdd" CommandName="AddItem" CommandArgument='<%# Eval("CEDClaimNo") %>'
                                                                        runat="server" Text="Add" ToolTip="Add the Check Details for this Claim" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%# Eval("CDCheckNumber") %>'
                                                                        runat="server" Text="Edit" ToolTip="Edit the Check Details" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%# Eval("CDCheckNumber") %>'
                                                                        ToolTip="View the Check Details" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                        <EmptyDataTemplate>
                                                            Currently There Is No Check for Searched Check No.
                                                        </EmptyDataTemplate>
                                                        <PagerSettings Visible="true" />
                                                        <PagerStyle BackColor="#7F7F7F" BorderColor="#7F7F7F" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr style="height: 20px">
                                                <td>
                                                    <asp:Button ID="btnBack" OnClick="btnBack_Click" runat="server" Text="Back to Search">
                                                    </asp:Button>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </asp:View>
                                <asp:View ID="vwChkEdit" runat="server">
                                    <asp:FormView ID="fvChkEditDel" runat="server" Width="100%" OnDataBound="fvChkEditDel_DataBound">
                                        <EditItemTemplate>
                                            <table width="100%" style="border-right: #7f7f7f 1pt solid; border-top: #7f7f7f 1pt solid;
                                                border-left: #7f7f7f 1pt solid; border-bottom: #7f7f7f 1pt solid; text-align: left">
                                                <tbody>
                                                    <tr>
                                                        <td style="font-weight: bold; font-size: 11pt; font-family: Tahoma" class="ghc" align="left"
                                                            colspan="3">
                                                            Check Writing
                                                            <asp:Label ID="lblPkId" runat="server" Width="0px" Text='<%#Eval("Pk_check_no") %>'
                                                                Visible="false" Height="0px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <table width="75%" style="text-align: left;">
                                                                <tbody>
                                                                    <tr>
                                                                        <td colspan="3">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 50%" class="lc">
                                                                            <asp:Label ID="lblchkNo" runat="server" Text="Check Number"></asp:Label>
                                                                        </td>
                                                                        <td class="lc">
                                                                            :
                                                                        </td>
                                                                        <td style="width: 50%" class="ic">
                                                                            <asp:Label ID="lblDchkNo" runat="server" Text='<%#Eval("Check_Number") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 50%" class="lc">
                                                                            <asp:Label ID="lblClaimNo" runat="server" Text="Claim Number"></asp:Label>
                                                                        </td>
                                                                        <td class="lc">
                                                                            :
                                                                        </td>
                                                                        <td style="width: 50%" class="ic">
                                                                            <asp:Label ID="lblDClaimNo" runat="server" Text='<%#Eval("Claim_Number") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 50%" class="lc">
                                                                            <asp:Label ID="lblDtIssue" runat="server" Text="Issue Date"></asp:Label>
                                                                            <span class="mf">*</span>
                                                                        </td>
                                                                        <td class="lc">
                                                                            :
                                                                        </td>
                                                                        <td style="width: 50%" class="ic">
                                                                            <asp:TextBox ID="txtIssueDate" runat="server" Width="90px" ValidationGroup="vsErrorGroup"
                                                                                Text='<%#DataBinder.Eval(Container.DataItem,"Issue_Date","{0:MM/dd/yyyy}") %>'></asp:TextBox>
                                                                            <img runat="Server" id="imgDtIssue" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvChkEditDel_txtIssueDate','mm/dd/y');"
                                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                                align="absmiddle" />
                                                                            <asp:RequiredFieldValidator ID="rfvDtIssue" InitialValue="" ControlToValidate="txtIssueDate"
                                                                                runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Issue Date."
                                                                                Display="None">
                                                                            </asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="revChkIssueDate" runat="server" ControlToValidate="txtIssueDate"
                                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                                ErrorMessage="Date Not Valid(Issue Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 50%" class="lc">
                                                                            <asp:Label ID="lblPaymentId" runat="server" Text="Payment ID"></asp:Label>
                                                                            <span class="mf">*</span>
                                                                        </td>
                                                                        <td class="lc">
                                                                            :
                                                                        </td>
                                                                        <td style="width: 50%" class="ic">
                                                                            <asp:DropDownList ID="ddlPaymentID" runat="server" SkinID="dropGen" OnSelectedIndexChanged="ddlPaymentID_SelectedIndexChanged"
                                                                                AutoPostBack="true">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="rfvPolType" InitialValue="0" ControlToValidate="ddlPaymentID"
                                                                                runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select PaymentID."
                                                                                Display="None">
                                                                            </asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 50%" class="lc">
                                                                            <asp:Label ID="lblPayCode" runat="server" Text="Paycode"></asp:Label>
                                                                            <span class="mf">*</span>
                                                                        </td>
                                                                        <td class="lc">
                                                                            :
                                                                        </td>
                                                                        <td style="width: 50%" class="ic">
                                                                            <asp:DropDownList ID="ddlPayCode" runat="server" SkinID="dropGen" Width="500px">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="rfvPaycode" InitialValue="0" ControlToValidate="ddlPayCode"
                                                                                runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Paycode."
                                                                                Display="None">
                                                                            </asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 50%" class="lc">
                                                                            <asp:Label ID="lblDtSBegin" runat="server" Text="Service Start Date"></asp:Label>
                                                                            <span class="mf">*</span>
                                                                        </td>
                                                                        <td class="lc">
                                                                            :
                                                                        </td>
                                                                        <td style="width: 50%" class="ic">
                                                                            <asp:TextBox ID="txtDtSBegin" runat="server" ValidationGroup="vsErrorGroup" Width="90px"
                                                                                Text='<%#DataBinder.Eval(Container.DataItem,"Service_Begin","{0:MM/dd/yyyy}") %>'></asp:TextBox>
                                                                            <img runat="Server" id="imgDtSBegin" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvChkEditDel_txtDtSBegin','mm/dd/y');"
                                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                                align="absmiddle" />
                                                                            <asp:RequiredFieldValidator ID="rfvDtSBegin" InitialValue="" ControlToValidate="txtDtSBegin"
                                                                                runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Service Start Date."
                                                                                Display="None">
                                                                            </asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="revDtSBegin" runat="server" ControlToValidate="txtDtSBegin"
                                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                                ErrorMessage="Date Not Valid(Service Start Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 50%" class="lc">
                                                                            <asp:Label ID="lblDtSEnd" runat="server" Text="Service End Date"></asp:Label>
                                                                            <span class="mf">*</span>
                                                                        </td>
                                                                        <td class="lc">
                                                                            :
                                                                        </td>
                                                                        <td style="width: 50%" class="ic">
                                                                            <asp:TextBox ID="txtDtSEnd" runat="server" Width="90px" Text='<%#DataBinder.Eval(Container.DataItem,"Service_End","{0:MM/dd/yyyy}") %>'></asp:TextBox>
                                                                            <img id="Img1" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvChkEditDel_txtDtSEnd', 'mm/dd/y');"
                                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                                runat="server" align="absmiddle" />
                                                                            <asp:RequiredFieldValidator ID="rfvDtSEnd" InitialValue="" ControlToValidate="txtDtSEnd"
                                                                                runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Service End Date."
                                                                                Display="None">
                                                                            </asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="revDtSEnd" runat="server" ControlToValidate="txtDtSEnd"
                                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                                ErrorMessage="Date Not Valid(Service End Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                            <asp:CompareValidator ID="cvCompServiceDate" runat="server" ControlToValidate="txtDtSEnd"
                                                                                ValidationGroup="vsErrorGroup" ErrorMessage="Service End Date Must Be Greater Than Service Start Date."
                                                                                Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtDtSBegin" Display="none">
                                                                            </asp:CompareValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 50%" class="lc">
                                                                            <asp:Label ID="lblPayTo" runat="server" Text="Pay To The Order of"></asp:Label>
                                                                        </td>
                                                                        <td class="lc">
                                                                            :
                                                                        </td>
                                                                        <td style="width: 50%" class="ic">
                                                                            <asp:Label ID="lblDPayTo" runat="server" Text='<%#Eval("Fk_Payee") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 50%" class="lc">
                                                                            <asp:Label ID="lblInvoiceNo" runat="server" Text="Invoice Number"></asp:Label>
                                                                        </td>
                                                                        <td class="lc">
                                                                            :
                                                                        </td>
                                                                        <td style="width: 50%" class="ic">
                                                                            <asp:TextBox ID="txtInvoiceNo" runat="server" Text='<%#Eval("Invoice_Number") %>'></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 50%" class="lc">
                                                                            <asp:Label ID="lblIOutStand" runat="server" Text="Property Damage"></asp:Label>
                                                                        </td>
                                                                        <td class="lc">
                                                                            :
                                                                        </td>
                                                                        <td style="width: 50%" class="ic">
                                                                            <asp:Label ID="lblDIOutStand" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Indemnity_outstanding","{0:C}") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 50%" class="lc">
                                                                            <asp:Label ID="lblMoutStand" runat="server" Text="Bodily Injury"></asp:Label>
                                                                        </td>
                                                                        <td class="lc">
                                                                            :
                                                                        </td>
                                                                        <td style="width: 50%" class="ic">
                                                                            <asp:Label ID="lblDMoutStand" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Medical_outstanding","{0:C}") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 50%" class="lc">
                                                                            <asp:Label ID="lblEOutStand" runat="server" Text="Expense"></asp:Label>
                                                                        </td>
                                                                        <td class="lc">
                                                                            :
                                                                        </td>
                                                                        <td style="width: 50%" class="ic">
                                                                            <asp:Label ID="lblDEOutStand" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Expense_outstanding","{0:C}") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 50%" class="lc">
                                                                            <asp:Label ID="lblPayAmount" runat="server" Text="Pay Amount"></asp:Label>
                                                                            <span class="mf">*</span>
                                                                        </td>
                                                                        <td class="lc">
                                                                            :
                                                                        </td>
                                                                        <td style="width: 50%" class="ic">
                                                                            $<asp:TextBox ID="txtPayAmount" runat="server" Text='<%#Eval("check_Amount") %>'
                                                                                SkinID="txtAmt"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="rfvPayAmount" InitialValue="" ControlToValidate="txtPayAmount"
                                                                                runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Pay Amount."
                                                                                Display="None">
                                                                            </asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 50%" class="lc" valign="top">
                                                                            <asp:Label ID="lblComment" runat="server" Text="Comment"></asp:Label>
                                                                        </td>
                                                                        <td class="lc" valign="top">
                                                                            :
                                                                        </td>
                                                                        <td style="width: 50%" class="ic">
                                                                            <asp:ImageButton ID="ibtnComment" ImageUrl="~/Images/plus.jpg" runat="server" OnClientClick="javascript:return MinMax('comment');" />
                                                                            <div id="pnlComment" style="display: none;">
                                                                                <asp:TextBox ID="txtComment" runat="server" Width="250px" Text='<%#Eval("Comments") %>'
                                                                                    MaxLength="4000" TextMode="MultiLine"></asp:TextBox>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding-bottom: 10px; padding-top: 10px" align="center" colspan="3">
                                                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="vsErrorGroup"
                                                                                OnClientClick="javascript:checkPayment(event);"></asp:Button>
                                                                            <asp:Button ID="btnCancel" OnClick="btnCancel_Click" runat="server" Text="Cancel">
                                                                            </asp:Button>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <table width="100%" style="border-right: #7f7f7f 1pt solid; border-top: #7f7f7f 1pt solid;
                                                border-left: #7f7f7f 1pt solid; border-bottom: #7f7f7f 1pt solid; text-align: left">
                                                <tr>
                                                    <td class="ghc" style="font-family: Tahoma; font-size: 11pt; font-weight: bold;"
                                                        align="left" colspan="3">
                                                        Check Writing
                                                        <asp:Label ID="lblPkId" runat="server" Height="0px" Width="0px" Visible="false" Text='<%#Eval("Pk_check_no") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <table width="45%" style="text-align: left;">
                                                            <tr>
                                                                <td colspan="3">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc" style="width: 50%;">
                                                                    <asp:Label ID="lblchkNo" runat="server" Text="Check Number"></asp:Label>
                                                                </td>
                                                                <td class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 50%;">
                                                                    <asp:Label ID="lblDchkNo" runat="server" Text='<%#Eval("Check_Number") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc" style="width: 50%;">
                                                                    <asp:Label ID="lblClaimNo" runat="server" Text="Claim Number"></asp:Label>
                                                                </td>
                                                                <td class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 50%;">
                                                                    <asp:Label ID="lblDClaimNo" runat="server" Text='<%#Eval("Claim_number") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc" style="width: 50%;">
                                                                    <asp:Label ID="lblDtIssue" runat="server" Text="Issue Date"></asp:Label>
                                                                </td>
                                                                <td class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 50%;">
                                                                    <asp:Label ID="lblDDtIssue" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Issue_Date","{0:MM/dd/yyyy}") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc" style="width: 50%;">
                                                                    <asp:Label ID="lblPaymentId" runat="server" Text="PaymentID"></asp:Label>
                                                                </td>
                                                                <td class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 50%;">
                                                                    <asp:Label ID="lblDPaymentId" runat="server" Text='<%#Eval("FLD_Desc") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc" style="width: 50%;">
                                                                    <asp:Label ID="lblPayCode" runat="server" Text="Paycode"></asp:Label>
                                                                </td>
                                                                <td class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 50%;">
                                                                    <asp:Label ID="lblDPayCode" runat="server" Text='<%#Eval("PayCode") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc" style="width: 50%;">
                                                                    <asp:Label ID="lblDtSBegin" runat="server" Text="Service Start Date"></asp:Label>
                                                                </td>
                                                                <td class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 50%;">
                                                                    <asp:Label ID="lblDDtSBegin" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Service_Begin","{0:MM/dd/yyyy}") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc" style="width: 50%;">
                                                                    <asp:Label ID="lblDtSEnd" runat="server" Text="Service End Date"></asp:Label>
                                                                </td>
                                                                <td class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 50%;">
                                                                    <asp:Label ID="lblDDtSEnd" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Service_End","{0:MM/dd/yyyy}") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc" style="width: 50%;">
                                                                    <asp:Label ID="lblPayTo" runat="server" Text="Pay To The Order of"></asp:Label>
                                                                </td>
                                                                <td class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 50%;">
                                                                    <asp:Label ID="lblDPayTo" runat="server" Text='<%#Eval("Fk_Payee") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc" style="width: 50%;">
                                                                    <asp:Label ID="lblInvoiceNo" runat="server" Text="Invoice Number"></asp:Label>
                                                                </td>
                                                                <td class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 50%;">
                                                                    <asp:Label ID="lblDInvoiceNo" runat="server" Text='<%#Eval("Invoice_Number") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc" style="width: 50%;">
                                                                    <asp:Label ID="lblIOutStand" runat="server" Text="Property Damage"></asp:Label>
                                                                </td>
                                                                <td class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 50%;">
                                                                    <asp:Label ID="lblDIOutStand" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Indemnity_outstanding","{0:C}") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc" style="width: 50%;">
                                                                    <asp:Label ID="lblMoutStand" runat="server" Text="Bodily Injury"></asp:Label>
                                                                </td>
                                                                <td class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 50%;">
                                                                    <asp:Label ID="lblDMoutStand" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Medical_outstanding","{0:C}") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc" style="width: 50%;">
                                                                    <asp:Label ID="lblEOutStand" runat="server" Text="Expense"></asp:Label>
                                                                </td>
                                                                <td class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 50%;">
                                                                    <asp:Label ID="lblDEOutStand" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Expense_outstanding","{0:C}") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc" style="width: 50%;">
                                                                    <asp:Label ID="lblPayAmount" runat="server" Text="Pay Amount"></asp:Label>
                                                                </td>
                                                                <td class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 50%;">
                                                                    <asp:Label ID="lblDPayAmount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"check_Amount","{0:C}") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc" style="width: 50%;" valign="top">
                                                                    <asp:Label ID="lblComment" runat="server" Text="Comment"></asp:Label>
                                                                </td>
                                                                <td class="lc" valign="top">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 50%;">
                                                                    <asp:ImageButton ID="ibtnComment" ImageUrl="~/Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMax('comment');" />
                                                                    <div id="pnlComment" style="display: block;">
                                                                        <asp:TextBox ID="txtComment" ReadOnly="true" runat="server" TextMode="MultiLine"
                                                                            Width="250px" Height="70px" Text='<%#Eval("Comments") %>'></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" align="center" style="padding-top: 10px; padding-bottom: 10px">
                                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <InsertItemTemplate>
                                        </InsertItemTemplate>
                                    </asp:FormView>
                                </asp:View>
                                <asp:View ID="vwChkSearch" runat="server">
                                    <div id="dvCheckSearch" runat="server">
                                        <table width="100%">
                                            <tbody>
                                                <tr>
                                                    <td align="center">
                                                        <table style="border-right: #7f7f7f 1pt solid; border-top: #7f7f7f 1pt solid; border-left: #7f7f7f 1pt solid;
                                                            border-bottom: #7f7f7f 1pt solid; text-align: left" width="99%">
                                                            <tbody>
                                                                <tr>
                                                                    <td class="ghc" colspan="6">
                                                                        <asp:Label ID="lblHeader" runat="server" Text="Search"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="80%">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 25%" class="lc" valign="top">
                                                                                        <asp:Label ID="lblLClaimType" runat="server" Text="Claim Type"></asp:Label>
                                                                                    </td>
                                                                                    <td class="lc" valign="top">
                                                                                        :
                                                                                    </td>
                                                                                    <td style="width: 25%" class="ic" valign="top">
                                                                                        <asp:CheckBoxList ID="chkLstClaimType" runat="server" RepeatDirection="vertical">
                                                                                            <asp:ListItem Text="Workers Compensation" Value="Workers_Comp"></asp:ListItem>
                                                                                            <asp:ListItem Text="Auto Liability" Value="Liability_Claim"></asp:ListItem>
                                                                                            <asp:ListItem Text="General Liability" Value="Liability_Claim"></asp:ListItem>
                                                                                            <asp:ListItem Text="Property Loss" Value="Liability_Claim"></asp:ListItem>
                                                                                        </asp:CheckBoxList>
                                                                                    </td>
                                                                                    <td style="width: 25%" class="lc">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td style="width: 25%" class="lc">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 25%" class="lc">
                                                                                        <asp:Label ID="lblLClaimNo" runat="server" Text="Claim Number"></asp:Label>
                                                                                    </td>
                                                                                    <td class="lc">
                                                                                        :
                                                                                    </td>
                                                                                    <td style="width: 25%" class="ic">
                                                                                        <asp:TextBox ID="txtClaimNo" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 25%" class="lc">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td style="width: 25%" class="lc">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 25%" class="lc" align="left">
                                                                                        <asp:Label ID="lblLClaimOpenFrom" runat="server" Text="Open Claims From"></asp:Label>
                                                                                    </td>
                                                                                    <td class="lc">
                                                                                        :
                                                                                    </td>
                                                                                    <td style="width: 25%" class="lc" align="left">
                                                                                        <asp:TextBox ID="txtDtStart" runat="server" SkinID="txtDate" ValidationGroup="vsErrorGroup"></asp:TextBox>
                                                                                        <img style="vertical-align: baseline" id="imgStartDate" onmouseover="javascript:this.style.cursor='hand';"
                                                                                            onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDtStart', 'mm/dd/y');"
                                                                                            src="../Images/iconPicDate.gif" align="absMiddle" runat="server" />
                                                                                        <asp:RegularExpressionValidator ID="RFVtxtDtStart" runat="server" ControlToValidate="txtDtStart"
                                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                                            ErrorMessage="Date Not Valid(Open Claims From Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                                    </td>
                                                                                    <td style="width: 25%" class="lc" align="left">
                                                                                        <asp:Label ID="lblLClaimsOpenTo" runat="server" Text="Open Claims To"></asp:Label>
                                                                                    </td>
                                                                                    <td class="lc">
                                                                                        :
                                                                                    </td>
                                                                                    <td style="width: 25%" class="lc" align="left">
                                                                                        <asp:TextBox ID="txtDtEnd" runat="server" SkinID="txtDate"></asp:TextBox>
                                                                                        <img style="vertical-align: baseline" id="imgEndDate" onmouseover="javascript:this.style.cursor='hand';"
                                                                                            onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDtEnd', 'mm/dd/y');"
                                                                                            src="../Images/iconPicDate.gif" align="absMiddle" runat="server" />
                                                                                        <asp:RegularExpressionValidator ID="revChkDtEnd" runat="server" ControlToValidate="txtDtEnd"
                                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                                            ErrorMessage="Date Not Valid(Open Claims To Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 25%" class="lc" align="left">
                                                                                        <asp:Label ID="lblLClaimCloseFrom" runat="server" Text="Closed Claims From"></asp:Label>
                                                                                    </td>
                                                                                    <td class="lc">
                                                                                        :
                                                                                    </td>
                                                                                    <td style="width: 25%" class="lc" align="left">
                                                                                        <asp:TextBox ID="txtFDtClose" runat="server" SkinID="txtDate" ValidationGroup="vsErrorGroup"></asp:TextBox>
                                                                                        <img style="vertical-align: baseline" id="imgDtClose" onmouseover="javascript:this.style.cursor='hand';"
                                                                                            onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtFDtClose', 'mm/dd/y');"
                                                                                            src="../Images/iconPicDate.gif" align="absMiddle" runat="server" />
                                                                                        <asp:RegularExpressionValidator ID="revFDtClose" runat="server" ControlToValidate="txtFDtClose"
                                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                                            ErrorMessage="Date Not Valid(Closed Claims From Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                                    </td>
                                                                                    <td style="width: 25%" class="lc" align="left">
                                                                                        <asp:Label ID="lblLClaimCloseTo" runat="server" Text="Closed Claims To"></asp:Label>
                                                                                    </td>
                                                                                    <td class="lc">
                                                                                        :
                                                                                    </td>
                                                                                    <td style="width: 25%" class="lc" align="left">
                                                                                        <asp:TextBox ID="txtFDtCloseTo" runat="server" SkinID="txtDate"></asp:TextBox>
                                                                                        <img style="vertical-align: baseline" id="imgDtCloseTo" onmouseover="javascript:this.style.cursor='hand';"
                                                                                            onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtFDtCloseTo', 'mm/dd/y');"
                                                                                            src="../Images/iconPicDate.gif" align="absMiddle" runat="server" />
                                                                                        <asp:RegularExpressionValidator ID="REVFDtCloseTo" runat="server" ControlToValidate="txtFDtCloseTo"
                                                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                                            ErrorMessage="Date Not Valid(Closed Claims To Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 25%" class="lc">
                                                                                        <asp:Label ID="lblLChkNo" runat="server" Text="Check Number"></asp:Label>
                                                                                    </td>
                                                                                    <td class="lc">
                                                                                        :
                                                                                    </td>
                                                                                    <td style="width: 25%" class="ic">
                                                                                        <asp:TextBox ID="txtChkNo" onkeypress="return numberOnly(event);" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 25%" class="lc">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td style="width: 25%" class="lc">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="6">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center">
                                                                        <asp:Button ID="btnChkSearch" OnClick="btnChkSearch_Click" runat="server" ValidationGroup="vsErrorGroup"
                                                                            Text="Search" OnClientClick="javascript:ValSearch();"></asp:Button>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </asp:View>
                            </asp:MultiView>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
