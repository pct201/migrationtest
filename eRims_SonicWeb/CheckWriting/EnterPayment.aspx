<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EnterPayment.aspx.cs" Inherits="CheckWriting_EnterPayment"
    MaintainScrollPositionOnPostback="true" MasterPageFile="~/Default.master" Theme="Default"
      %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
    function OkayChkPrint()
    {
            var Out;   
            var elmnts = document.getElementsByName("ctl00$ContentPlaceHolder1$rdbLstPrintCheck");
            for (var m_intCounter=0; m_intCounter < elmnts.length; m_intCounter++)
            {
                if (elmnts[m_intCounter].checked)
                    {
                        Out = elmnts[m_intCounter].value;
                        break;
                    }
            }
            if(Out=="Y")
            {
                document.getElementById("ctl00_ContentPlaceHolder1_txtChkNo").readOnly=true;
            }
            else
            {
                document.getElementById("ctl00_ContentPlaceHolder1_txtChkNo").readOnly=false;
            }
    }
    
    //Use this If Not Recurring then Disable Recurring Controls.
    function recDisable()
    {
            var Out;   
            var elmnts = document.getElementsByName("ctl00$ContentPlaceHolder1$rdblstRecPayment");
            for (var m_intCounter=0; m_intCounter < elmnts.length; m_intCounter++)
            {
                if (elmnts[m_intCounter].checked)
                    {
                        Out = elmnts[m_intCounter].value;
                        break;
                    }
            }
            document.getElementById("ctl00_ContentPlaceHolder1_txtNoOfRecPayment").value="";
            document.getElementById("ctl00_ContentPlaceHolder1_txtReccPeriod").value="";
            document.getElementById("ctl00_ContentPlaceHolder1_txtDtRecBegin").value="";
            document.getElementById("ctl00_ContentPlaceHolder1_txtDtRecEnd").value="";
              
            if(Out=="Y")
            {
                document.getElementById("ctl00_ContentPlaceHolder1_txtNoOfRecPayment").readOnly=false;
                document.getElementById("ctl00_ContentPlaceHolder1_txtReccPeriod").readOnly=false;
                document.getElementById("ctl00_ContentPlaceHolder1_imgRecBegin").disabled=false;
                //document.getElementById("ctl00_ContentPlaceHolder1_imgRecEnd").disabled=false;
            
            }
            else
            {
                document.getElementById("ctl00_ContentPlaceHolder1_txtNoOfRecPayment").readOnly=true;
                document.getElementById("ctl00_ContentPlaceHolder1_txtReccPeriod").readOnly=true;
                document.getElementById("ctl00_ContentPlaceHolder1_imgRecBegin").disabled=true;
                //document.getElementById("ctl00_ContentPlaceHolder1_imgRecEnd").disabled=true;
            }

    }
    
    
    function checkPayment()
    {
        var enterAmt;
        var existAmt;
           
        enterAmt=(parseFloat(document.getElementById("ctl00_ContentPlaceHolder1_txtPayAmount").value.replace(",","").replace(",","")))*(parseFloat(document.getElementById("ctl00_ContentPlaceHolder1_txtNoOfRecPayment").value));
        if(document.getElementById("ctl00_ContentPlaceHolder1_ddlPayId").value=="Expense")
        {           
            existAmt=parseFloat(document.getElementById("ctl00_ContentPlaceHolder1_lblEOutStand").innerText);
        }
        else if(document.getElementById("ctl00_ContentPlaceHolder1_ddlPayId").value=="Property Damage")
        {
            existAmt=parseFloat(document.getElementById("ctl00_ContentPlaceHolder1_lblIOutStand").innerText);
        }
        else if(document.getElementById("ctl00_ContentPlaceHolder1_ddlPayId").value=="Bodily Injury")
        {
            existAmt=parseFloat(document.getElementById("ctl00_ContentPlaceHolder1_lblMOutStand").innerText);
        }
        else
        {
            //alert("Please Select Payment Type");
            //return false;
            existAmt=0;
        }
        
        //alert(enterAmt);
        //alert(existAmt);
        //alert(isNaN(enterAmt));
        if(isNaN(enterAmt)==true)
        {
           return true;
        }
        if(parseFloat(enterAmt)>parseFloat(existAmt))
        {
         if(document.getElementById("ctl00_ContentPlaceHolder1_txtNoOfRecPayment").value != "1" )
         {
           alert("Please enter (Pay Amount* No of Reccurring Payments) less than the outstanding amount for selected Payment Id.");
         }
         else
         {
            alert("Please enter Amount less than the outstanding amount for selected Payment Id.");
         }
           event.returnValue = false;
           //return false;
        }
        else
        {
            return true;
        }
    }
    function MadeReadOnly()
    {
        document.getElementById("ctl00_ContentPlaceHolder1_txtdtChkInput").readOnly=true;
        document.getElementById("ctl00_ContentPlaceHolder1_txtDtChkIssue").readOnly=true;
        document.getElementById("ctl00_ContentPlaceHolder1_txtDtRecBegin").readOnly=true;
        document.getElementById("ctl00_ContentPlaceHolder1_txtDtRecEnd").readOnly=true;
        
    }
    
    function onChangePayment()
    {
        //var PaymentType = document.getElementById("ctl00_ContentPlaceHolder1_ddlPaymentType");
        //if(PaymentType.options[PaymentType.selectedIndex].value==1)
        //debugger;
        /*txtdtChkInput;
        txtDtChkIssue;
        
        txtNoOfRecPayment;
        rdblstRecPayment;
        txtReccPeriod;
        txtDtRecBegin;
        imgRecBegin;
        txtDtRecEnd;
        imgRecEnd;
        rdbLstChkType;
        rdbLstPrintCheck;
        txtChkNo;*/
        
        document.getElementById("ctl00_ContentPlaceHolder1_txtdtChkInput").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtDtChkIssue").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtNoOfRecPayment").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtReccPeriod").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtDtRecBegin").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtDtRecEnd").value="";
        //document.getElementById("ctl00_ContentPlaceHolder1_txtChkNo").value="";
        
        
        if(document.getElementById("ctl00_ContentPlaceHolder1_ddlPaymentType").value==1)
        {
            //So Enable Control of Check.
            //if image button asp.net then use this to disable document.getElementById("ctl00_ContentPlaceHolder1_imgBtnDtChkInput").disabled=false;
            document.getElementById("ctl00_ContentPlaceHolder1_imgChkInput").disabled=false;
            document.getElementById("ctl00_ContentPlaceHolder1_imgChkIssue").disabled=false;
            //Recurring PaymentSection
            document.getElementById("ctl00_ContentPlaceHolder1_imgRecBegin").disabled=false;
            //document.getElementById("ctl00_ContentPlaceHolder1_imgRecEnd").disabled=false;
            
            document.getElementById("ctl00_ContentPlaceHolder1_txtNoOfRecPayment").readOnly=false;
            document.getElementById("ctl00_ContentPlaceHolder1_txtReccPeriod").readOnly=false;
            //document.getElementById("ctl00_ContentPlaceHolder1_txtChkNo").readOnly=false;
            
            document.getElementById("ctl00_ContentPlaceHolder1_rdblstRecPayment").disabled=false;
            document.getElementById("ctl00_ContentPlaceHolder1_rdbLstChkType").disabled=false;
            //document.getElementById("ctl00_ContentPlaceHolder1_rdbLstPrintCheck").disabled=false;
            
            document.getElementById("ctl00_ContentPlaceHolder1_txtdtChkInput").readOnly=false;
            document.getElementById("ctl00_ContentPlaceHolder1_txtDtChkIssue").readOnly=false;
            document.getElementById("ctl00_ContentPlaceHolder1_txtNoOfRecPayment").readOnly=false;
            document.getElementById("ctl00_ContentPlaceHolder1_txtReccPeriod").readOnly=false;
            document.getElementById("ctl00_ContentPlaceHolder1_txtDtRecBegin").readOnly=false;
            document.getElementById("ctl00_ContentPlaceHolder1_txtDtRecEnd").readOnly=false;
            
            document.getElementById("ctl00_ContentPlaceHolder1_rfvDtIssue").enabled =true;
            document.getElementById("ctl00_ContentPlaceHolder1_rfvDtInput").enabled =true;
        
            
        }
        else
        {
            //So Disable Control of Check.
            //if image button asp.net then use this to disable document.getElementById("ctl00_ContentPlaceHolder1_imgBtnDtChkInput").disabled=true;
            document.getElementById("ctl00_ContentPlaceHolder1_imgChkInput").disabled=true;
            document.getElementById("ctl00_ContentPlaceHolder1_imgChkIssue").disabled=true;
            //Recurring PaymentSection
            document.getElementById("ctl00_ContentPlaceHolder1_imgRecBegin").disabled=true;
            //document.getElementById("ctl00_ContentPlaceHolder1_imgRecEnd").disabled=true;
            
            document.getElementById("ctl00_ContentPlaceHolder1_txtNoOfRecPayment").readOnly=true;
            document.getElementById("ctl00_ContentPlaceHolder1_txtReccPeriod").readOnly=true;
            //document.getElementById("ctl00_ContentPlaceHolder1_txtChkNo").readOnly=true;
            
            document.getElementById("ctl00_ContentPlaceHolder1_rdblstRecPayment").disabled=true;
            document.getElementById("ctl00_ContentPlaceHolder1_rdbLstChkType").disabled=true;
            //document.getElementById("ctl00_ContentPlaceHolder1_rdbLstPrintCheck").disabled=true;
            
            document.getElementById("ctl00_ContentPlaceHolder1_txtdtChkInput").readOnly=true;
            document.getElementById("ctl00_ContentPlaceHolder1_txtDtChkIssue").readOnly=true;
            document.getElementById("ctl00_ContentPlaceHolder1_txtNoOfRecPayment").readOnly=true;
            document.getElementById("ctl00_ContentPlaceHolder1_txtReccPeriod").readOnly=true;
            document.getElementById("ctl00_ContentPlaceHolder1_txtDtRecBegin").readOnly=true;
            document.getElementById("ctl00_ContentPlaceHolder1_txtDtRecEnd").readOnly=true;
            
            document.getElementById("ctl00_ContentPlaceHolder1_rfvDtIssue").enabled =false;
            document.getElementById("ctl00_ContentPlaceHolder1_rfvDtInput").enabled =false;
 
        }
    }
    </script>

    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>

    <link href="../App_Themes/Default/stylecal.css" type="text/css" rel="Stylesheet" />

    <script type="text/javascript">
    function calculateEndDate()
    {

          var stDate=new Date();
          var edDate=new Date();
           var norecperiod;
           var noRecPayment;
          
           if(document.getElementById("ctl00_ContentPlaceHolder1_txtNoOfRecPayment").value=="")
           {
                noRecPayment=0;
           }
           else
           {
                noRecPayment=document.getElementById("ctl00_ContentPlaceHolder1_txtNoOfRecPayment").value;
           }
           if(document.getElementById("ctl00_ContentPlaceHolder1_txtReccPeriod").value=="")
           {
                noRecPeriod=0;
           }
           else
           {
                noRecPeriod=document.getElementById("ctl00_ContentPlaceHolder1_txtReccPeriod").value;
           }
           var myDate = new Date();
           myDate.setDate(myDate.getDate(stDate) + 1);
           alert(myDate);
           return true;
    }
    function btnClaimVendor()
    {
            var Out;   
            var elmnts = document.getElementsByName("ctl00$ContentPlaceHolder1$rdbLstPayee");
            document.getElementById("ctl00_ContentPlaceHolder1_txtPayTo").value="";
            for (var m_intCounter=0; m_intCounter < elmnts.length; m_intCounter++)
            {
                if (elmnts[m_intCounter].checked)
                    {
                        Out = elmnts[m_intCounter].value;
                        break;
                    }
            }
            //alert(document.getElementById("ctl00_ContentPlaceHolder1_lblFirstName").innerText);
            if(Out=="V")
            {
                document.getElementById("ctl00_ContentPlaceHolder1_btnPayTo").disabled=false;
            }
            else
            {
                document.getElementById("ctl00_ContentPlaceHolder1_btnPayTo").disabled=true;
                document.getElementById("ctl00_ContentPlaceHolder1_txtPayTo").value=document.getElementById("ctl00_ContentPlaceHolder1_lblFirstName").innerText+' '+document.getElementById("ctl00_ContentPlaceHolder1_lblLastName").innerText;
            }
    }
    function openWindow()
        {
            oWnd=window.open("Vendor.aspx","Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            oWnd.moveTo(260,180);
            return false;
            
        }
    </script>

    <asp:ScriptManager ID="smChekWriting" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="pnlChekWriting" runat="server">
        <ContentTemplate>
            <div>
                <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
                    HeaderText="" BorderWidth="1" BorderColor="DimGray"
                    ValidationGroup="vsErrorGroup" CssClass="errormessage" EnableClientScript="true">
                </asp:ValidationSummary>
                <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="true"
                    ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
            </div>
            <div id="dvSearch" runat="server">
                <table width="100%" style="font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                    <div align="center">
                        <asp:Label ID="lblSearchMsg" runat="server" SkinID="lblError"></asp:Label>
                    </div>
                    <tr>
                        <td class="lc">
                            <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                <tr>
                                    <td class="ghc">
                                        Enter Payments
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table width="45%" style="text-align: center;">
                                <tr valign="middle" style="height: 425px;">
                                    <td style="width: 50%" class="lc">
                                        Enter Claim Number (00-00000-00)
                                    </td>
                                    <td class="lc">
                                        :</td>
                                    <td class="ic" style="width: 40%;">
                                        <asp:TextBox ID="txtSearchClaimNo" runat="server" onkeypress="return numberOnly(event);"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="mskSearchClaimNo" runat="server" TargetControlID="txtSearchClaimNo"
                                            Mask="99-99999-99" MaskType="Number" AutoComplete="false" ClearMaskOnLostFocus="false">
                                        </cc1:MaskedEditExtender>
                                        <asp:RequiredFieldValidator ID="rfvSearchClaimNo" InitialValue="" ControlToValidate="txtSearchClaimNo"
                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Claim Number."
                                            Display="None">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td class="ic" style="width: 10%;" valign="middle">
                                        <asp:Button ID="btnSearch" Text="Search" runat="server" ValidationGroup="vsErrorGroup"
                                            OnClick="btnSearch_Click" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="dventerPayment" runat="server">
                <table width="100%">
                    <tr>
                        <td align="center" style="width: 95%; height: 21px;">
                            <div style="display: none;">
                                <asp:TextBox ID="txtVendorId" runat="server" Height="0px" Width="0px"></asp:TextBox>
                                <asp:TextBox ID="txtCompare" runat="server" Height="0px" Width="0px" Text="0.00"></asp:TextBox>
                                <asp:TextBox ID="txtCompare2" runat="server" Height="0px" Text="0" Width="0px"></asp:TextBox>
                            </div>
                            <table width="95%">
                                <table width="99%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                                    text-align: left;">
                                    <div align="center">
                                        <asp:Label ID="lblScript" runat="server" SkinID="lblError"></asp:Label>
                                    </div>
                                    <tr>
                                        <td class="lc">
                                            <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                                <tr>
                                                    <td class="ghc">
                                                        Claim Details
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="background-color: #FFFFFF;">
                                            <table width="100%" style="background-color: White;" cellspacing="2" cellpadding="2">
                                                <tr style="background-color: #EAEAEA; text-align: left;">
                                                    <td class="lc" style="width: 25%;">
                                                        Claim Number</td>
                                                    <td class="lc">
                                                        :</td>
                                                    <td class="ic" style="width: 25%;">
                                                        <asp:Label ID="lblClaimNo" runat="server" Text='<%# Eval("claim_number")%>'></asp:Label>
                                                        <asp:Label ID="lblEmployeeSSN" runat="server" Text='<%# Eval("EmployeeSSN")%>' Height="0px"
                                                            Width="0px" Visible="false"></asp:Label></td>
                                        </td>
                                        <td class="lc" style="width: 25%;">
                                            Employee</td>
                                        <td class="lc">
                                            :</td>
                                        <td class="ic" style="width: 25%;">
                                            <asp:Label ID="lblEmployee" runat="server" Text='<%# Eval("employee")%>'></asp:Label></td>
                                    </tr>
                                    <tr style="background-color: #EAEAEA; text-align: left;">
                                        <td class="lc">
                                            Last Name</td>
                                        <td class="lc">
                                            :</td>
                                        <td class="ic">
                                            <asp:Label ID="lblLastName" runat="server"></asp:Label></td>
                                        <td class="lc">
                                            First Name</td>
                                        <td class="lc">
                                            :</td>
                                        <td class="ic">
                                            <asp:Label ID="lblFirstName" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr style="background-color: #EAEAEA; text-align: left;">
                                        <td class="lc">
                                            Middle Name</td>
                                        <td class="lc">
                                            :</td>
                                        <td class="ic">
                                            <asp:Label ID="lblMiddleName" runat="server"></asp:Label></td>
                                        <td class="lc">
                                            Date of Incident</td>
                                        <td class="lc">
                                            :</td>
                                        <td class="ic">
                                            <asp:Label ID="lblDtOfIncident" runat="server"></asp:Label></td>
                                    </tr>
                                </table>
                                <tr>
                                    <td class="lc">
                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                            <tr>
                                                <td class="ghc">
                                                    Reserves
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border-color: #ffffff;">
                                        <table width="100%" cellspacing="2" cellpadding="2">
                                            <tr style="background-color: #EAEAEA; text-align: right;">
                                                <td style="width: 25%;" class="lc">
                                                    &nbsp;</td>
                                                <td style="width: 25%;" class="lc">
                                                    Inccured</td>
                                                <td style="width: 25%;" class="lc">
                                                    Paid</td>
                                                <td style="width: 25%;" class="lc">
                                                    Outstanding</td>
                                            </tr>
                                            <tr style="background-color: #EAEAEA;">
                                                <td class="lc" style="width: 25%;">
                                                    <asp:Label id="lblPropInd" runat="server" ></asp:Label> </td>
                                                <td class="ic" style="width: 25%; text-align: right;">
                                                    $<asp:Label ID="lblIInccured" runat="server"></asp:Label></td>
                                                <td class="ic" style="width: 25%; text-align: right;">
                                                    $<asp:Label ID="lblIPaid" runat="server"></asp:Label></td>
                                                <td class="lc" style="width: 25%; text-align: right;">
                                                    $<asp:Label ID="lblIOutStand" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr style="background-color: #EAEAEA;">
                                                <td class="lc" style="width: 25%;">
                                                    <asp:Label id="lblBodilyMed" runat="server" ></asp:Label></td>
                                                <td class="ic" style="width: 25%; text-align: right;">
                                                    $<asp:Label ID="lblMInccured" runat="server"></asp:Label></td>
                                                <td class="ic" style="width: 25%; text-align: right;">
                                                    $<asp:Label ID="lblMPaid" runat="server"></asp:Label></td>
                                                <td class="lc" style="width: 25%; text-align: right;">
                                                    $<asp:Label ID="lblMOutStand" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr style="background-color: #EAEAEA;">
                                                <td class="lc" style="width: 25%;">
                                                    Expenses</td>
                                                <td class="ic" style="width: 25%; text-align: right;">
                                                    $<asp:Label ID="lblEInccured" runat="server"></asp:Label></td>
                                                <td class="ic" style="width: 25%; text-align: right;">
                                                    $<asp:Label ID="lblEPaid" runat="server"></asp:Label></td>
                                                <td class="lc" style="width: 25%; text-align: right;">
                                                    $<asp:Label ID="lblEOutStand" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lc">
                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                            <tr>
                                                <td class="ghc">
                                                    Check Information
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 25%" style="display: none" class="lc">
                                                    Payment Type<span class="mf">*</span>
                                                </td>
                                                <td class="lc" style="display: none">
                                                    :</td>
                                                <td class="ic" style="width: 25%" style="display: none">
                                                    <asp:DropDownList ID="ddlPaymentType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPaymentType_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select Payment Type--" Value="0"></asp:ListItem>
                                                    </asp:DropDownList>
                                                   <%-- <asp:RequiredFieldValidator ID="rfvPaymentType" InitialValue="0" ControlToValidate="ddlPaymentType"
                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Payment Type."
                                                        Display="None">
                                                    </asp:RequiredFieldValidator>--%>
                                                </td>
                                                <td style="width: 25%" class="lc">
                                                    Check Input Date<span class="mf">*</span></td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    <asp:TextBox ID="txtdtChkInput" runat="server" SkinID="txtDate"></asp:TextBox>
                                                    <img runat="Server" id="imgChkInput" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtdtChkInput', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                        align="absmiddle" />
                                                    <cc1:MaskedEditExtender ID="mskExDtInput" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtdtChkInput" CultureName="en-US"
                                                        AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                    </cc1:MaskedEditExtender>
                                                    <asp:RequiredFieldValidator ID="rfvDtInput" InitialValue="" ControlToValidate="txtdtChkInput"
                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Check Input Date."
                                                        Display="None">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revChkInput" runat="server" ControlToValidate="txtdtChkInput"
                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                        ErrorMessage="Date Not Valid(Check Input Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="lc">
                                                    Check Issue Date<span class="mf">*</span></td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    <asp:TextBox ID="txtDtChkIssue" runat="server" SkinID="txtDate"></asp:TextBox>
                                                    <img runat="server" id="imgChkIssue" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtdtChkIssue', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                        align="absmiddle" />
                                                    <cc1:MaskedEditExtender ID="mskExDtIssu" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtDtChkIssue" CultureName="en-US"
                                                        AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                    </cc1:MaskedEditExtender>
                                                    <asp:RequiredFieldValidator ID="rfvDtIssue" InitialValue="" ControlToValidate="txtDtChkIssue"
                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Check Issue Date."
                                                        Display="None">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revDtChkIssue" runat="server" ControlToValidate="txtDtChkIssue"
                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                        ErrorMessage="Date Not Valid(Check Issue Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                </td>
                                                <td style="width: 25%" class="lc">
                                                    Payee
                                                </td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    <asp:RadioButtonList ID="rdbLstPayee" runat="server">
                                                        <asp:ListItem Text="Claimant" Value="C" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Vendor" Value="V"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="lc">
                                                    Payment Id <span class="mf">*</span>
                                                </td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    <asp:DropDownList ID="ddlPayId" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPayId_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvPayId" runat="server" ControlToValidate="ddlPayId"
                                                        InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Payment Id."
                                                        Display="None"></asp:RequiredFieldValidator>
                                                </td>
                                                <%--<td style="width: 25%" class="lc">
                                                    Paycode<span class="mf">*</span></td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    <asp:DropDownList ID="ddlPayCode" runat="server" Width="200px">
                                                        <asp:ListItem Text="--Select Paycode--" Value="0"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvPayCode" runat="server" ControlToValidate="ddlPayCode"
                                                        InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Paycode."
                                                        Display="None"></asp:RequiredFieldValidator>
                                                </td>--%>
                                                <td style="width: 25%" class="lc">
                                                    &nbsp;</td>
                                                <td class="lc">
                                                    &nbsp;</td>
                                                <td style="width: 25%" class="ic">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="lc">
                                                    Paycode<span class="mf">*</span></td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 75%" colspan="4">
                                                    <asp:DropDownList ID="ddlPayCode" runat="server" SkinID="dropGen" Width="680px">
                                                        <asp:ListItem Text="--Select Paycode--" Value="0"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvPayCode" runat="server" ControlToValidate="ddlPayCode"
                                                        InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Paycode."
                                                        Display="None"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="lc">
                                                    Document Date
                                                </td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    <asp:TextBox ID="txtDtDoc" runat="server" SkinID="txtDate"></asp:TextBox>
                                                    <img runat="server" id="imgDoc" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtdtDoc', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                        align="absmiddle" />
                                                    <cc1:MaskedEditExtender ID="mskExDtDocument" runat="server" AcceptNegative="Left"
                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDtDoc"
                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                    </cc1:MaskedEditExtender>
                                                    <asp:RegularExpressionValidator ID="revDtDoc" runat="server" ControlToValidate="txtDtDoc"
                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                        ErrorMessage="Date Not Valid(Document Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                </td>
                                                <td style="width: 25%" class="lc">
                                                    Supporting Document Type
                                                </td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    <asp:DropDownList ID="ddlPaySuppType" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="lc">
                                                    Document Number</td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    <asp:TextBox ID="txtDocNo" runat="server" MaxLength="25">
                                        
                                                    </asp:TextBox>
                                                </td>
                                                <td style="width: 25%" class="lc">
                                                    Invoice Number</td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    <asp:TextBox ID="txtInvoiceNo" runat="server" MaxLength="25">
                                                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="lc">
                                                    Pay Amount<span class="mf">*</span></td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    $<asp:TextBox ID="txtPayAmount" runat="server" MaxLength="12" SkinID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event))">
                                        
                                                    </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvAmount" InitialValue="" ControlToValidate="txtPayAmount"
                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Pay Amount."
                                                        Display="None">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="cvCompPayAmt" runat="server" ControlToValidate="txtPayAmount"
                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Pay Amount Greater Than $0.00."
                                                        Type="Currency" Operator="GreaterThan" ControlToCompare="txtCompare" Display="none">
                                                    </asp:CompareValidator>
                                                </td>
                                                <td style="width: 25%" class="lc">
                                                    Pay To The Order of<span class="mf">*</span>
                                                </td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    <asp:TextBox ID="txtPayTo" runat="server" onKeyDown="javascript:return disableDeleteBackSpace();">
                                                    </asp:TextBox>
                                                    <asp:Button ID="btnPayTo" runat="server" Text="V" SkinID="btnGen" />
                                                    <asp:RequiredFieldValidator ID="rfvPayto" InitialValue="" ControlToValidate="txtPayTo"
                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Pay To The Order of."
                                                        Display="None">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="lc">
                                                    Service Start Date<span class="mf">*</span>
                                                </td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    <asp:TextBox ID="txtDtSBegin" runat="server" SkinID="txtDate"></asp:TextBox>
                                                    <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDtSBegin', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                        align="absmiddle" />
                                                    <cc1:MaskedEditExtender ID="mskExDtSBegin" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtDtSBegin" CultureName="en-US"
                                                        AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                    </cc1:MaskedEditExtender>
                                                    <asp:RequiredFieldValidator ID="rfvDtSBegin" InitialValue="" ControlToValidate="txtDtSBegin"
                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Service Start Date."
                                                        Display="None">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="cvCompServiceDate" runat="server" ControlToValidate="txtDtSEnd"
                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Service End Date Must Be Greater Than Or Equal To Service Start Date."
                                                        Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtDtSBegin" Display="none">
                                                    </asp:CompareValidator>
                                                    <asp:RegularExpressionValidator ID="revDtSBegin" runat="server" ControlToValidate="txtDtSBegin"
                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                        ErrorMessage="Date Not Valid(Service Start Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                </td>
                                                <td style="width: 25%" class="lc">
                                                    Service End Date<span class="mf">*</span></td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    <asp:TextBox ID="txtDtSEnd" runat="server" SkinID="txtDate"></asp:TextBox>
                                                    <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDtSEnd', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                        align="absmiddle" />
                                                    <cc1:MaskedEditExtender ID="mskExDtSEnd" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtDtSEnd" CultureName="en-US"
                                                        AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                    </cc1:MaskedEditExtender>
                                                    <asp:RequiredFieldValidator ID="rfvDtSEnd" InitialValue="" ControlToValidate="txtDtSEnd"
                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Service End Date."
                                                        Display="None">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revDtSEnd" runat="server" ControlToValidate="txtDtSEnd"
                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                        ErrorMessage="Date Not Valid(Service End Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lc">
                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                            <tr>
                                                <td class="ghc">
                                                    Recurring Payments
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 25%" class="lc">
                                                    Recurring Payments</td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    <asp:RadioButtonList ID="rdblstRecPayment" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdblstRecPayment_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td style="width: 25%" class="lc">
                                                    Number of Recurring Payments</td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    <asp:TextBox ID="txtNoOfRecPayment" runat="server" onkeypress="return numberOnly(event);"
                                                        OnTextChanged="txtNoOfRecPayment_TextChanged" AutoPostBack="false" Text="1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvNoRecPayment" InitialValue="" ControlToValidate="txtNoOfRecPayment"
                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Number of Recurring Payments."
                                                        Display="None">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="cmpValReccPayment" runat="server" ControlToValidate="txtNoOfRecPayment"
                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Number of Recurring Payments Greater Than 0."
                                                        Type="Integer" Operator="GreaterThan" ControlToCompare="txtCompare2" Display="none">
                                                    </asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="lc">
                                                    Recurring Period (Days)</td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    <asp:TextBox ID="txtReccPeriod" runat="server" onkeypress="return numberOnly(event);"
                                                        OnTextChanged="txtReccPeriod_TextChanged" AutoPostBack="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvRecPeriod" InitialValue="" ControlToValidate="txtReccPeriod"
                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Recurring Period (Days)."
                                                        Display="None">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="cmpValRecPeriod" runat="server" ControlToValidate="txtReccPeriod"
                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Recurring Period (Days) Greater Than 0."
                                                        Type="Integer" Operator="GreaterThan" ControlToCompare="txtCompare2" Display="none">
                                                    </asp:CompareValidator>
                                                </td>
                                                <td style="width: 25%" class="lc">
                                                    Recurring Payment Start Date</td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    <asp:TextBox ID="txtDtRecBegin" runat="server" AutoPostBack="false" SkinID="txtDate"></asp:TextBox>
                                                    <img runat="server" id="imgRecBegin" onclick="javascript:return showCalendar('ctl00_ContentPlaceHolder1_txtdtRecBegin', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif" />
                                                    <cc1:MaskedEditExtender ID="mskExDtRecBegin" runat="server" AcceptNegative="Left"
                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDtRecBegin"
                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                    </cc1:MaskedEditExtender>
                                                    <asp:RegularExpressionValidator ID="revDtRecBegin" runat="server" ControlToValidate="txtDtRecBegin"
                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                        ErrorMessage="Date Not Valid(Recurring Payment Start Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="rfvDtRecBegin" InitialValue="" ControlToValidate="txtDtRecBegin"
                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Recurring Payment Start Date."
                                                        Display="None">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr >
                                                <td style="width: 25%" class="lc" >
                                                    <%--Recurring Payment End Date--%></td>
                                                <td class="lc" visible="False">
                                                    <%--:--%></td>
                                                <td class="ic" style="width: 25%" visible="false">
                                                    <asp:Label ID="lblDtRecEnd" runat="server" visible="false"></asp:Label>
                                                    <asp:TextBox ID="txtDtRecEnd" runat="server" visible="false" AutoPostBack="false" SkinID="txtDate" onKeyDown="javascript:return disableDeleteBackSpace();"></asp:TextBox>
                                                    <%--<img id="imgRecEnd" runat="server" onclick="popUpCalendar(this,ctl00_ContentPlaceHolder1_txtDtRecEnd,'mm/dd/yyyy');"
                                                        height="17" src="../Images/iconPicDate.gif" alt="Calendar" style="vertical-align: baseline;" />
                                                </td>--%>
                                                <td style="width: 25%" class="lc">
                                                    &nbsp;</td>
                                                <td class="lc">
                                                    &nbsp;</td>
                                                <td class="ic" style="width: 25%">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lc">
                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                            <tr>
                                                <td class="ghc">
                                                    Disposition
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 25%" class="lc">
                                                    Check Type</td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    <asp:RadioButtonList ID="rdbLstChkType" runat="server">
                                                        <asp:ListItem Text="Original" Value="O" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Recurring" Value="R"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td style="width: 25%" class="lc">
                                                    Okay To Print Check?</td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    <asp:RadioButtonList ID="rdbLstPrintCheck" runat="server">
                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td style="width: 25%" class="lc">
                                                    &nbsp;</td>
                                                <td class="lc">
                                                </td>
                                                <td class="ic" style="width: 25%">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="lc">
                                                    Was Check Printed?</td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    <asp:RadioButtonList ID="rdbLstChkPrinted" runat="server">
                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td style="width: 25%" class="lc">
                                                    Check Number</td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    <asp:TextBox ID="txtChkNo" runat="server">
                                                    </asp:TextBox>
                                                </td>
                                                <%-- /*This Part Was Comment When above commented*/--%>
                                                <%--/*********************************************/--%>
                                                <td style="width: 25%" class="lc">
                                                    &nbsp;</td>
                                                <td class="lc">
                                                </td>
                                                <td class="ic" style="width: 25%">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="lc" valign="top">
                                                    Comment</td>
                                                <td class="lc" valign="top">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Height="100px" Width="200px"
                                                        MaxLength="4000"></asp:TextBox>
                                                </td>
                                                <td style="width: 25%" class="lc">
                                                    &nbsp;</td>
                                                <td class="lc">
                                                    &nbsp;</td>
                                                <td class="ic" style="width: 25%">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="lc">
                                                    Select Bank<span class="mf">*</span></td>
                                                <td class="lc">
                                                    :</td>
                                                <td class="ic" style="width: 25%">
                                                    <%--<asp:TextBox ID="txtBank" runat="server"></asp:TextBox>
                                                        <asp:Button ID="btnBank" runat="server" Text="V" SkinID="btnGen" />--%>
                                                    <asp:DropDownList ID="ddlBank" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvBank" InitialValue="0" ControlToValidate="ddlBank"
                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Bank."
                                                        Display="None">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                                <td style="width: 25%" class="lc">
                                                    &nbsp;</td>
                                                <td class="lc">
                                                    &nbsp;</td>
                                                <td class="ic" style="width: 25%">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" align="center">
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="vsErrorGroup"
                                                        OnClientClick="javascript:checkPayment(event);" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="dvchkDetails" runat="server">
                <table width="99%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                    text-align: left;">
                    <tr>
                        <td class="lc" colspan="6">
                            <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                <tr>
                                    <td class="ghc">
                                        <asp:Label ID="lblHeader" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" style="width: 15%;">
                            Check Listing for Claim
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic" style="width: 15%">
                            <asp:Label ID="lblGrdClaimNo" runat="server"></asp:Label>
                        </td>
                        <td class="ic" style="width: 35%">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="ic" style="width: 35%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" style="width: 15%;">
                            Employee/Claimant
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic" style="width: 15%">
                            <asp:Label ID="lblGrdEmployee" runat="server"></asp:Label>
                        </td>
                        <td class="ic" style="width: 35%">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="ic" style="width: 35%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" style="width: 15%;">
                            Date of Incident
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic" style="width: 15%">
                            <asp:Label ID="lblGrdDtIncident" runat="server"></asp:Label>
                        </td>
                        <td class="ic" style="width: 35%">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="ic" style="width: 35%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="trRec" runat="server">
                        <td class="lc" style="width: 15%;">
                            Recurring Payment End Date
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic" style="width: 15%">
                            <asp:Label ID="lblDtShowRecEnd" runat="server"></asp:Label></td>
                        <td class="ic" style="width: 35%">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="ic" style="width: 35%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:GridView ID="grdAfterChkGenerated" runat="server" AllowPaging="false" AllowSorting="false"
                                AutoGenerateColumns="false" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="RecIssueDate" HeaderText="Issue Date" SortExpression="RecIssueDate"
                                        DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false"></asp:BoundField>
                                    <asp:BoundField DataField="Pk_check_no" HeaderText="Check Number" SortExpression="Pk_check_no">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AEPPaymentID" HeaderText="PaymentID" SortExpression="AEPPaymentID">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AEPDtServiceBegin" HeaderText="Start Date" SortExpression="AEPDtServiceBegin"
                                        DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false"></asp:BoundField>
                                    <asp:BoundField DataField="AEPDtServiceEnd" HeaderText="End Date" SortExpression="AEPDtServiceEnd"
                                        DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false"></asp:BoundField>
                                    <asp:BoundField DataField="AEPInvoiceNo" HeaderText="Invoice Number" SortExpression="AEPInvoiceNo">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Current_Recurring_Number" HeaderText="Current Recurring No"
                                        SortExpression="Current_Recurring_Number"></asp:BoundField>
                                    <asp:BoundField DataField="Check_Amount" HeaderText="Payment Amount" SortExpression="Check_Amount"
                                        DataFormatString="{0:C}" HtmlEncode="false"  ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <asp:GridView ID="grdOther" runat="server" AllowPaging="false" AllowSorting="false"
                                AutoGenerateColumns="false" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="" HeaderText="Check Number" SortExpression="" />
                                    <asp:BoundField DataField="AEPPaymentID" HeaderText="PaymentID" SortExpression="AEPPaymentID">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AEPDtServiceBegin" HeaderText="Start Date" SortExpression="AEPDtServiceBegin"
                                        DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false"></asp:BoundField>
                                    <asp:BoundField DataField="AEPDtServiceEnd" HeaderText="End Date" SortExpression="AEPDtServiceEnd"
                                        DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false"></asp:BoundField>
                                    <asp:BoundField DataField="AEPInvoiceNo" HeaderText="Invoice Number" SortExpression="AEPInvoiceNo">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Check_Amount" HeaderText="Payment Amount" SortExpression="Check_Amount"
                                        DataFormatString="{0:C}" HtmlEncode="false" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
