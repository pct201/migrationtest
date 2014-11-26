<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="SubrogationDetail.aspx.cs"
    Inherits="WorkerCompensation_SubrogationDetail" Title="Risk Management Insurance System" %>
    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="cntSubrogation" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="false"
            ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
    </div>
    <asp:ScriptManager runat="server" ID="scManager">
    </asp:ScriptManager>
    
    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>

    <link href="../App_Themes/Default/stylecal.css" type="text/css" rel="Stylesheet" />
    <link href="../App_Themes/Default/Default.skin" type="text/css" rel="Skin" />

    <script language="javascript" type="text/javascript">  
      
      function MinMax()
    {
        if(document.getElementById("ctl00_ContentPlaceHolder1_txtDescription").style.height == "")
        {
            document.getElementById("ctl00_ContentPlaceHolder1_ibtnDisplay").src = "../Images/minus.jpg";
            document.getElementById("ctl00_ContentPlaceHolder1_txtDescription").style.height = "200px";
            document.getElementById("pnlTemp").style.display = "block";
        }
        else if(document.getElementById("ctl00_ContentPlaceHolder1_txtDescription").style.height == "200px")
        {
             document.getElementById("ctl00_ContentPlaceHolder1_ibtnDisplay").src = "../Images/plus.jpg";
            document.getElementById("ctl00_ContentPlaceHolder1_txtDescription").style.height="";
            document.getElementById("pnlTemp").style.display = "none";
        }
        return false;
    }
     function ValAttach()
    {        
        document.getElementById("ctl00_ContentPlaceHolder1_rfvAttachType").enabled =true;
        document.getElementById("ctl00_ContentPlaceHolder1_rfvUpload").enabled =true;
        if(document.getElementById("ctl00_ContentPlaceHolder1_txt3TelNo").value=="___-___-____")
        {
            document.getElementById("ctl00_ContentPlaceHolder1_txt3TelNo").value="";
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_txt3AdminTel").value=="___-___-____")
        {
            document.getElementById("ctl00_ContentPlaceHolder1_txt3AdminTel").value="";
        }
        return true;
    }
    function ValSave()
    {            
        document.getElementById("ctl00_ContentPlaceHolder1_rfvAttachType").enabled =false;
        document.getElementById("ctl00_ContentPlaceHolder1_rfvUpload").enabled =false;
        if(document.getElementById("ctl00_ContentPlaceHolder1_txt3TelNo").value=="___-___-____")
        {
            document.getElementById("ctl00_ContentPlaceHolder1_txt3TelNo").value="";
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_txt3AdminTel").value=="___-___-____")
        {
            document.getElementById("ctl00_ContentPlaceHolder1_txt3AdminTel").value="";
        }
        return true;
    }
      
    function getfirst()
    {
        clearfocus();
        document.getElementById("first").className="left_menu_active";
        document.getElementById("ctl00_ContentPlaceHolder1_divClaimDetail").style.display ="block";
    }
    function getsecond()
    {
        clearfocus();
        document.getElementById("second").className="left_menu_active";
        document.getElementById("ctl00_ContentPlaceHolder1_divInsurance").style.display ="block";
        document.getElementById("spnMandetory").style.display="none";
    }
    function getthird()
    {
        clearfocus();
        document.getElementById("third").className="left_menu_active"; 
        document.getElementById("ctl00_ContentPlaceHolder1_divAttachment").style.display ="block";
        document.getElementById("ctl00_ContentPlaceHolder1_dvAttachDetails").style.display ="block";
    }
    
    function clearfocus()
    { 
        document.getElementById("first").className="left_menu";     
        document.getElementById("second").className="left_menu";     
        document.getElementById("third").className="left_menu";     
        
        document.getElementById("ctl00_ContentPlaceHolder1_divClaimDetail").style.display ="none"; 
        document.getElementById("ctl00_ContentPlaceHolder1_divInsurance").style.display ="none";  
        document.getElementById("ctl00_ContentPlaceHolder1_divAttachment").style.display ="none";   
        document.getElementById("ctl00_ContentPlaceHolder1_dvAttachDetails").style.display ="none";               
    }
    
    function chkValidation(type)
    {
        var strError ='';
        if(document.getElementById("ctl00_ContentPlaceHolder1_txtAppInsPolCompName").value =="")
        {
            strError += "Please Insert Applicable Insurance Policy Company's Name.\n" ;
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_txtAppInsuPolicy").value =="")
        {
            strError += "Please Insert Applicable Insurance Policy.\n";
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_txtAdjusterOnClaim").value =="")
        {
            strError += "Please Insert Adjuster on Claim";
        }
        if(strError.length > 0)
        {
            document.getElementById("spnMandetory").style.display="";
            if(type=='show')                
                alert(strError);
            else
                alert("Please First Enter the Subrogation Detail Information");
                
            return false;
        }
        else
        {
            document.getElementById("spnMandetory").style.display="none";
            return true;
        }
    }
    
    function chkAttachment()
    {
        var strError = "";
        if(chkValidation('hide'))
        {
            if(document.getElementById("ctl00_ContentPlaceHolder1_ddlAttachType").value == "--Select Attachment Type--")
            {
                 strError += "Please Select Attachment Type.\n";
            }
            if(document.getElementById("ctl00_ContentPlaceHolder1_uplCommon").value == "")
            {
                 strError += "Please Select File To Upload.\n";
            }
            if(strError.length > 0)
            {
                alert(strError);
                return false;               
            }
        }
        else
        {
            return false;
        }
    }
    
     function openWindow(strURL)
    {
        oWnd=window.open(strURL,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
        oWnd.moveTo(260,180);
        return false;
        
    }
    function openMailWindow(strURL)
    {
        //oWnd=window.open("Mail.aspx?AttName="+ strURL,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=0,toolbar=0,width=500,height=280");
        oWnd=window.open(strURL,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=0,toolbar=0,width=500,height=280");
        oWnd.moveTo(260,180);
        return false;
        
    }
    
    </script>

    <div id="contmain" runat="server" style="width: 100%;">
        <br />
        <div id="Div1" runat="server" style="width: 100%; text-align: center">
            <table border="0" cellpadding="1" cellspacing="0" width="99%">
                <tr>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="WorkersCompensation.aspx">Worker's Compensation</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="WorkerCompensationReserve.aspx">Reserve Worksheets</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="Carrier.aspx">Carrier Data</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="subrogation.aspx">Subrogation</a></td>
                    <td align="center" class="active_tab" style="background-image: url('../images/active_btn.jpg')"
                        valign="middle">
                        Subrogation Detail</td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="CheckRegister.aspx">Check Register</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="MainDiary.aspx">Diary</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="MainAdjuster.aspx">Adjustor Notes</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="Settlement.aspx">Settlement</a></td>
                </tr>
            </table>
        </div>
        <div id="leftdiv" runat="server" style="width: 18%; height: 350px; float: left; border: solid 1px #7F7F7F;
            margin: 1px 1px 1px 4px;">
            <table border="0" cellpadding="2" cellspacing="0" width="90%">
                <tr>
                    <td style="width: 5">
                        &nbsp;</td>
                    <td style="width: 95%">
                        <a class="left_menu_active" id="first" href="#" onclick="javascript:getfirst();">Claim
                            Details</a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" href="#" id="second" onclick="javascript:getsecond();">Insurance
                            Information<span class="mf">*</span></a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" href="#" id="third" onclick="javascript:getthird();">Attachment</a></td>
                </tr>
            </table>
        </div>
        <div id="mainContent" runat="server" style="border: solid 1px #7F7F7F; width: 79%;
            float: right; margin: 1px 5px 1px 1px; padding: 5px 5px 5px 5px">
            <div id="divClaimDetail" runat="server" style="display: block;">
                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                    <tr>
                        <td colspan="6" class="ghc">
                            Claim Details</td>
                    </tr>
                    <tr>
                        <td style="width: 25%;" align="left" class="lc">
                            <asp:Label runat="server" ID="lblMClaimNumber">Claim Number</asp:Label> 
                        </td>
                        <td  align="Center" class="lc">
                            :
                        </td>
                        <td style="width: 25%;" align="left" class="ic">
                            <asp:Label runat="server" ID="lblClaimNum"></asp:Label>
                        </td>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblMDOIncident">Date of Incident</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblDateIncident"></asp:Label>
                        </td>
                        
                        
                        
                        
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblMLastName">Name</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblLName"></asp:Label>&nbsp;
                            <asp:Label runat="server" ID="lblMName"></asp:Label>&nbsp;
                            <asp:Label runat="server" ID="lblFName"></asp:Label>
                        </td>
                        <td style="width: 25%;" align="left" class="lc">
                            <asp:Label runat="server" ID="lblMEmployee">Employee</asp:Label>
                        </td>
                        <td  align="Center" class="lc">
                            :
                        </td>
                        <td style="width: 25%;" align="left" class="ic">
                            <asp:RadioButtonList ID="rbtnEmployee" runat="server" Enabled="false" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <%--<td align="left" class="lc">
                            <asp:Label runat="server" ID="lblMFirstName"> First Name</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblFName"></asp:Label>
                        </td>--%>
                    </tr>
                    <%--<tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblMMiddleName">Middle Name</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblMName"></asp:Label>
                        </td>
                        
                    </tr>--%>
                </table>
            </div>
            <div id="divInsurance" runat="server" style="display: none;">
                <table width="100%" border="0" cellpadding="2" cellspacing="2" class="lc">
                    <tr>
                        <td colspan="6" class="ghc">
                            Insurance Information</td>
                    </tr>
                    
                    <tr>
                        <td style="width: 25%" class="ic">
                            <asp:Label runat="server" ID="lblAppInsPolCompName">Applicable Insurance Policy Company's Name </asp:Label>
                            <span class="mf">*</span>
                        </td>
                        <td  class="lc">
                            :</td>
                        <td style="width: 25%" class="ic">
                            <asp:TextBox ID="txtAppInsPolCompName" runat="server" MaxLength="75" ValidationGroup="vsErrorGroup"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAppInsPolCompName" runat="server" ControlToValidate="txtAppInsPolCompName" ValidationGroup="vsErrorGroup"
                            ErrorMessage="Please Enter [Insurance Information]/Applicable Insurance Policy Company's Name" InitialValue="" Text="*" Display="none"></asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 25%" class="ic">
                            <asp:Label runat="server" ID="lblAppInsuPolicy">Applicable Insurance Policy</asp:Label>
                            <span class="mf">*</span>
                        </td>
                        <td class="lc">
                            :</td>
                        <td style="width: 25%" class="ic">
                            <asp:TextBox ID="txtAppInsuPolicy" runat="server" MaxLength="50" ValidationGroup="vsErrorGroup"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAppInsuPolicy" runat="server" ControlToValidate="txtAppInsuPolicy" Text="*"
                            ErrorMessage="Please Enter [Insurance Information]/Applicable Insurance Policy" ValidationGroup="vsErrorGroup" InitialValue="" Display="none"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="ic">
                            <asp:Label runat="server" ID="lblAdjusterOnClaim">Adjuster on Claim</asp:Label>
                            <span class="mf">*</span>
                            
                        </td>
                        <td class="lc">
                            :</td>
                        <td class="ic">
                            <asp:TextBox ID="txtAdjusterOnClaim" runat="server" MaxLength="50" ValidationGroup="vsErrorGroup"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAdjusterOnClaim" runat="server" ControlToValidate="txtAdjusterOnClaim"
                            ErrorMessage="Please Enter [Insurance Information]/Adjustor On Claim" ValidationGroup="vsErrorGroup" InitialValue="" Text="*" Display="none"></asp:RequiredFieldValidator>
                        </td>
                        <td class="ic">
                            <asp:Label runat="server" ID="lbl3Name">Third Party Name</asp:Label>
                        </td>
                        <td class="lc">
                            :</td>
                        <td class="ic">
                            <asp:TextBox ID="txt3Name" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="ic">
                            <asp:Label runat="server" ID="lbl3Add1">Third Party Address (1)</asp:Label>
                        </td>
                        <td class="lc">
                            :</td>
                        <td class="ic">
                            <asp:TextBox ID="txt3Add1" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                        <td class="ic">
                            <asp:Label runat="server" ID="lbl3Add2">Third Party Address (2)</asp:Label>
                        </td>
                        <td class="lc">
                            :</td>
                        <td class="ic">
                            <asp:TextBox ID="txt3Add2" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="ic">
                            <asp:Label runat="server" ID="lbl3City">Third Party City</asp:Label>
                        </td>
                        <td class="lc">
                            :</td>
                        <td class="ic">
                            <asp:TextBox ID="txt3City" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                        <td class="ic">
                            <asp:Label runat="server" ID="lbl3State">Third Party State</asp:Label>
                        </td>
                        <td class="lc">
                            :</td>
                        <td class="ic">
                            <asp:DropDownList runat="server" ID="dwThirdState">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="ic">
                            <asp:Label runat="server" ID="lbl3Zip">Third Party Zip Code</asp:Label>
                        </td>
                        <td class="lc">
                            :</td>
                        <td>
                            <asp:TextBox ID="txt3Zip" runat="server" MaxLength="5" onkeypress="return numberOnly(event);"></asp:TextBox>
                        </td>
                        <td class="ic">
                            <asp:Label runat="server" ID="lbl3TelNo">Third Party Telephone<br />(XXX-XXX-XXXX)</asp:Label>
                        </td>
                        <td class="lc">
                            :</td>
                        <td class="ic">
                            <asp:TextBox ID="txt3TelNo" runat="server" MaxLength="12"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="msk3TelNo" runat="server" TargetControlID="txt3TelNo" Mask="999-999-9999" MaskType="Number"  AutoComplete="False" ClearMaskOnLostFocus="false"></cc1:MaskedEditExtender>
                            <%--<cc1:MaskedEditValidator ID="mskVTelNo" runat="server" IsValidEmpty="false" InvalidValueMessage="Invalid Telephone." ControlExtender="msk3TelNo" ControlToValidate="txt3TelNo" ></cc1:MaskedEditValidator>--%>
                            <asp:RegularExpressionValidator ID="rev3TelNo" ControlToValidate="txt3TelNo" runat="server"
                            ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Insurance Information]/Telephone In xxx-xxx-xxxx Format"
                            Display="none" ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="ic">
                            <asp:Label runat="server" ID="lbl3InsuranceComp">Third Party Insurance Company</asp:Label>
                        </td>
                        <td class="lc">
                            :</td>
                        <td class="ic">
                            <asp:TextBox ID="txt3InsuranceComp" runat="server" MaxLength="75"></asp:TextBox>
                        </td>
                        <td class="ic">
                            <asp:Label runat="server" ID="lbl3InsuranceNo">Third Party Insurance Number</asp:Label>
                        </td>
                        <td class="lc">
                            :</td>
                        <td class="ic">
                            <asp:TextBox ID="txt3InsuranceNo" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="ic">
                            <asp:Label runat="server" ID="lblDONotice">Date of Notice</asp:Label>
                        </td>
                        <td class="lc">
                            :</td>
                        <td>
                            <asp:TextBox ID="txtDONotice" runat="server" SkinID="txtDate"></asp:TextBox>
                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDONotice', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                align="absmiddle" /><br />
                            <cc1:MaskedEditExtender ID="mskDONotice" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" TargetControlID="txtDONotice" CultureName="en-US"
                                AutoComplete="true" AutoCompleteValue="05/23/1964" >
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="mskValDtStart" runat="server" ControlExtender="mskDONotice"
                                ControlToValidate="txtDONotice" Display="dynamic" IsValidEmpty="true" MaximumValue=""
                                EmptyValueMessage="" InvalidValueMessage="Date is invalid"
                                MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue="" >
                            </cc1:MaskedEditValidator>
                            <asp:RegularExpressionValidator id="revDONotice" runat="server" ControlToValidate="txtDONotice"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="[Insurance Information]/Date Of Notice Is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                    <td class="ic">
                            <asp:Label runat="server" ID="lbl3Admin">Third Party Administrator</asp:Label>
                        </td>
                        <td class="lc">
                            :</td>
                        <td class="ic">
                            <asp:TextBox ID="txt3Admin" runat="server" MaxLength="75" ValidationGroup="vsErrorGroup"></asp:TextBox>
                        </td>
                        <td class="ic">
                            <asp:Label runat="server" ID="lbl3AdminContact">Third Party Administrator Contact</asp:Label>
                        </td>
                        <td class="lc">
                            :</td>
                        <td class="ic">
                            <asp:TextBox ID="txt3AdminContact" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                    
                    </tr>
                    <tr>
                        
                        <td class="ic">
                            <asp:Label runat="server" ID="lbl3AdminAdd1">Third Party Administrator<br /> Address (1)</asp:Label>
                        </td>
                        <td class="lc">
                            :</td>
                        <td class="ic">
                            <asp:TextBox ID="txt3AdminAdd1" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                        <td class="ic">
                            <asp:Label runat="server" ID="lbl3AdminAdd2">Third Party Administrator<br /> Address (2)</asp:Label>
                        </td>
                        <td class="lc">
                            :</td>
                        <td class="ic">
                            <asp:TextBox ID="txt3AdminAdd2" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        
                        <td class="ic">
                            <asp:Label runat="server" ID="lbl3AdminCity">Third Party Administrator City</asp:Label>
                        </td>
                        <td class="lc">
                            :</td>
                        <td class="ic">
                            <asp:TextBox ID="txt3AdminCity" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                        <td class="ic">
                            <asp:Label runat="server" ID="lbl3AdminState">Third Party Administrator State</asp:Label>
                        </td>
                        <td class="lc">
                            :</td>
                        <td class="ic">
                            <asp:DropDownList runat="server" ID="dwThirdAdmnState">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        
                        <td class="ic">
                            <asp:Label runat="server" ID="lbl3AdminZip">Third Party Administrator<br /> Zip Code</asp:Label>
                        </td>
                        <td class="lc">
                            :</td>
                        <td class="ic">
                            <asp:TextBox ID="txt3AdminZip" onkeypress="return numberOnly(event);" runat="server" MaxLength="5"></asp:TextBox>
                        </td>
                        <td class="ic">
                            <asp:Label runat="server" ID="lbl3AdminTel">Third Party Administrator<br /> Telephone
                            (XXX-XXX-XXXX)</asp:Label>
                        </td>
                        <td class="lc">
                            :</td>
                        <td class="ic">
                            <asp:TextBox ID="txt3AdminTel" runat="server" MaxLength="12"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="msk3AdminTel" runat="server" TargetControlID="txt3AdminTel" Mask="999-999-9999" MaskType="Number"  
                            AutoComplete="False" ClearMaskOnLostFocus="false">
                            </cc1:MaskedEditExtender>
                            <asp:RegularExpressionValidator ID="rev3AdminTel" ControlToValidate="txt3AdminTel" runat="server"
                            ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Insurance Information]/Telephone In xxx-xxx-xxxx Format"
                            Display="none" ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        
                        <td class="ic">
                            <asp:Label runat="server" ID="lblAmtOfRecovery">Amount of Recovery<br /> Expected </asp:Label>
                        </td>
                        <td class="lc">
                            :</td>
                        <td class="ic">
                            $<asp:TextBox ID="txtAmtOfRecovery" SkinID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event))" runat="server" MaxLength="11"></asp:TextBox>
                        </td>
                        <td class="ic">
                            <asp:Label runat="server" ID="lblAmtReceive">Amount Received </asp:Label>
                        </td>
                        <td class="lc">
                            :</td>
                        <td class="ic">
                            $<asp:TextBox ID="txtAmtReceive" runat="server" SkinID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                    </tr>
                    
                </table>
            </div>           
            <div id="divAttachment" runat="server" style="display: none;">
                <table cellpadding="2" cellspacing="2" class="stylesheet" width="100%">
                    <tr>
                        <td class="ghc" colspan="6">
                            Attachment
                        </td>
                    </tr>
                    
                    <tr style="display:none;">
                        <td class="ic" style="width: 25%" valign="top">
                            <asp:Label runat="server" ID="lblAttachType">Attachment Type </asp:Label>
                        </td>
                        <td style="width: 5%;" class="lc" valign="top">
                            :
                        </td>
                        <td class="ic" colspan="4" style="width:75%;" valign="top">
                            <asp:DropDownList runat="server" SkinID="dropGen" ID="ddlAttachType" ValidationGroup="vsErrorGroup">
                            </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="rfvAttachType" ControlToValidate="ddlAttachType"
                                runat="server" InitialValue="--Select Attachment Type--" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select the Attachment Type."
                                Display="none" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" style="width: 25%" valign="top">
                            <asp:Label runat="server" ID="lblAttachDesc">Attachment Description</asp:Label>
                        </td>
                        <td style="width: 5%;" valign="top" class="lc">
                            :
                        </td>
                        <td colspan="4" class="ic" valign="top"> 
                            <asp:ImageButton ID="ibtnDisplay" ImageUrl="~/Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMax();" />
                                <div id="pnlTemp" style="display:block;">                         
                                    <asp:TextBox ID="txtDescription" AutoPostBack="false" Height="200px" runat="server" MaxLength="4000" TextMode="MultiLine" Width="93%"></asp:TextBox>
                               </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" style="width: 25%" valign="top">
                            <asp:Label runat="server" ID="lblSelectFile">Select File</asp:Label>
                        </td>
                        <td class="lc" valign="top">
                            :
                        </td>
                        <td colspan="4" class="ic" valign="top" style="width: 75%">
                            <asp:FileUpload runat="server" ID="uplCommon" ValidationGroup="vsErrorGroup"/>
                             <asp:RequiredFieldValidator ID="rfvUpload" runat="server" ControlToValidate="uplCommon" InitialValue="" 
                                Display="none" Text="*" ErrorMessage="Please Select [Attachment]/File to Upload"  ValidationGroup="vsErrorGroup">                                                                        
                                </asp:RequiredFieldValidator >
                        </td>
                    </tr>
                    
                    <tr>
                        <td colspan="6" align="center" class="ic">
                            <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" ValidationGroup="vsErrorGroup" OnClientClick="javascript:ValAttach();"
                                OnClick="btnAddAttachment_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="dvAttachDetails" runat="server" style="display: none;">
                <table width="100%">
                    <tr>
                        <td colspan="2">
                            <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                <tr>
                                    <td class="ghc">
                                        Attachment Details
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="gvAttachmentDetails" runat="server" AutoGenerateColumns="false"
                                DataKeyNames="PK_Attachment_ID" Width="100%" AllowPaging="True" AllowSorting="False"
                                OnRowDataBound="gvAttachmentDetails_RowDataBound">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <input name="chkItem" type="checkbox" value='<%# Eval("PK_Attachment_ID")%>' onclick="javascript:UnCheckHeader('gvAttachmentDetails')" />
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" />
                                        <HeaderTemplate>
                                            <input type="checkbox" name="chkHeader" id="chkHeader" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                        </HeaderTemplate>
                                        <HeaderStyle Width="10px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" Visible="false">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description"></asp:BoundField>
                                    <asp:BoundField DataField="Attachment_Name1" HeaderText="File Name">
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="View">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnDwnld" CommandName="Download" CommandArgument='<%# Eval("Attachment_Name")%>'
                                                runat="server" ImageAlign="Left" ImageUrl="~/Images/download.gif" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Mail">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnMail" CommandName="Mail" CommandArgument='<%# Eval("Attachment_Name")%>'
                                                runat="server" ImageUrl="~/Images/emailicon.gif" ImageAlign="Left" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                    </asp:TemplateField>--%>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    Currently there is no Attachment.<br />
                                    Please add one or more Attachment.
                                </EmptyDataTemplate>
                                <PagerSettings Visible="False" />
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />
                            <asp:Button ID="btnMail" runat="server" Text="Mail" OnClientClick="javascript:return OpenWMail('gvAttachmentDetails','Worker_Comp_Subrogation_Detail');" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="divbtn" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td align="center" class="ic">
                        <asp:Button runat="server" ID="btnSaveView" Text="Save & View" OnClick="btnSaveView_Click"
                            ValidationGroup="vsErrorGroup" OnClientClick="javascript:ValSave();" />
                        <asp:Button ID="btnNextStep" runat="server" Text="Next Step" OnClientClick="javascript:ValSave();" OnClick="btnNextStep_Click" ValidationGroup="vsErrorGroup"
                           />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <br />
    <div id="divSaveView" runat="server" style="width: 100%;display: none;" >
        <div id="div2">
            <table cellpadding="2" cellspacing="4" border="0" width="100%">
                <tr>
                    <td colspan="6" class="ghc">
                        Claim Details</td>
                </tr>
                <tr>
                    <td style="width: 20%;" align="left" class="lc">
                        <asp:Label runat="server" ID="lblDClaimNo">Claim Number</asp:Label>
                    </td>
                    <td style="width: 5%;" align="left" class="lc">
                        :
                    </td>
                    <td style="width: 25%;" align="left" class="ic">
                        <asp:Label runat="server" ID="lblClaim_No"></asp:Label>
                    </td>
                    <td align="left" class="lc">
                        <asp:Label runat="server" ID="lblDDOIncident">Date of Incident</asp:Label>
                    </td>
                    <td align="left" class="lc">
                        :
                    </td>
                    <td align="left" class="ic">
                        <asp:Label runat="server" ID="lblDOIncident"></asp:Label>
                    </td>
                    
                    
                    
                </tr>
                <tr>
                    <td align="left" class="lc">
                        <asp:Label runat="server" ID="lblDLastName">Name</asp:Label>
                    </td>
                    <td align="left" class="lc">
                        :
                    </td>
                    <td align="left" class="ic">
                        <asp:Label runat="server" ID="lblLastName"></asp:Label>&nbsp;
                        <asp:Label runat="server" ID="lblMiddleName"></asp:Label>&nbsp;
                        <asp:Label runat="server" ID="lblFirName"></asp:Label>
                    </td>
                    <td style="width: 20%;" align="left" class="lc">
                        <asp:Label runat="server" ID="lblDEmployee">Employee</asp:Label>
                    </td>
                    <td style="width: 5%;" align="left" class="lc">
                        :
                    </td>
                    <td style="width: 25%;" align="left" class="ic">
                        <asp:Label runat="server" ID="lblEmp"></asp:Label>
                    </td>
                    <%--<td align="left" class="lc">
                        <asp:Label runat="server" ID="lblDFirstName"> First Name</asp:Label>
                    </td>
                    <td align="left" class="lc">
                        :
                    </td>
                    <td align="left" class="ic">
                        <asp:Label runat="server" ID="lblFirName"></asp:Label>
                    </td>--%>
                </tr>
                <%--<tr>
                    <td align="left" class="lc">
                        <asp:Label runat="server" ID="lblDMiddleName">Middle Name</asp:Label>
                    </td>
                    <td align="left" class="lc">
                        :
                    </td>
                    <td align="left" class="ic">
                        <asp:Label runat="server" ID="lblMiddleName"></asp:Label>
                    </td>
                    
                </tr>
                <tr><td colspan="6">&nbsp;</td></tr>--%>
            </table>
        </div>
        <div id="div3">
            <table style="width:100%;" border="0" cellpadding="4" cellspacing="2" class="lc">
                <tr>
                    <td colspan="6" class="ghc">
                        Insurance Information</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 20%" class="ic">
                        <asp:Label runat="server" ID="lblVAppInsPolCompName">Applicable Insurance Policy Company's Name </asp:Label>
                        
                    </td>
                    <td style="width: 5%" class="lc">
                        :</td>
                    <td style="width: 25%" class="ic">
                        <asp:Label runat="server" ID="lblVDAppInsPolCompName"></asp:Label>
                    </td>
                    <td style="width: 20%" class="ic">
                        <asp:Label runat="server" ID="lblVAppInsuPolicy">Applicable Insurance Policy</asp:Label>
                        
                    </td>
                    <td style="width: 5%" class="lc">
                        :</td>
                    <td style="width: 25%" class="ic">
                        <asp:Label runat="server" ID="lblVDAppInsuPolicy"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVAdjusterOnClaim">Adjuster on Claim</asp:Label>
                        
                    </td>
                    <td class="lc">
                        :</td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVDAdjusterOnClaim"></asp:Label>
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblV3Name">Third Party Name</asp:Label>
                    </td>
                    <td class="lc">
                        :</td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVD3Name"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblV3Add1">Third Party Address (1)</asp:Label>
                    </td>
                    <td class="lc">
                        :</td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVD3Add1"></asp:Label>
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblV3Add2">Third Party Address (2)</asp:Label>
                    </td>
                    <td class="lc">
                        :</td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVD3Add2"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblV3City">Third Party City</asp:Label>
                    </td>
                    <td class="lc">
                        :</td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVD3City"></asp:Label>
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblV3State">Third Party State</asp:Label>
                    </td>
                    <td class="lc">
                        :</td>
                    <td class="ic">
                       <asp:Label runat="server" ID="lblVD3State"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblV3Zip">Third Party Zip Code</asp:Label>
                    </td>
                    <td class="lc">
                        :</td>
                    <td>
                        <asp:Label runat="server" ID="lblVD3Zip"></asp:Label>
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblV3TelNo">Third Party Telephone<br />(XXX-XXX-XXXX)</asp:Label>
                    </td>
                    <td class="lc">
                        :</td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVD3TelNo"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblV3InsuranceComp">Third Party Insurance Company</asp:Label>
                    </td>
                    <td class="lc">
                        :</td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVD3InsuranceComp"></asp:Label>
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblV3InsuranceNo">Third Party Insurance Number</asp:Label>
                    </td>
                    <td class="lc">
                        :</td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVD3InsuranceNo"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVDONotice">Date of Notice</asp:Label>
                    </td>
                    <td class="lc">
                        :</td>
                    <td>
                        <asp:Label runat="server" ID="lblVDDONotice"></asp:Label>
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblV3Admin">Third Party Administrator</asp:Label>
                    </td>
                    <td class="lc">
                        :</td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVD3Admin"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblV3AdminContact">Third Party Administrator Contact</asp:Label>
                    </td>
                    <td class="lc">
                        :</td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVD3AdminContact"></asp:Label>
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblV3AdminAdd1">Third Party Administrator<br /> Address (1)</asp:Label>
                    </td>
                    <td class="lc">
                        :</td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVD3AdminAdd1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblV3AdminAdd2">Third Party Administrator<br /> Address (2)</asp:Label>
                    </td>
                    <td class="lc">
                        :</td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVD3AdminAdd2"></asp:Label>
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblV3AdminCity">Third Party Administrator City</asp:Label>
                    </td>
                    <td class="lc">
                        :</td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVD3AdminCity"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblV3AdminState">Third Party Administrator State</asp:Label>
                    </td>
                    <td class="lc">
                        :</td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVD3AdminState"></asp:Label>
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblV3AdminZip">Third Party Administrator<br /> Zip Code</asp:Label>
                    </td>
                    <td class="lc">
                        :</td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVD3AdminZip"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblV3AdminTel">Third Party Administrator<br /> Telephone
                            (XXX-XXX-XXXX)</asp:Label>
                    </td>
                    <td class="lc">
                        :</td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVD3AdminTel"></asp:Label>
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVAmtOfRecovery">Amount of Recovery<br /> Expected $</asp:Label>
                    </td>
                    <td class="lc">
                        :</td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVDAmtOfRecovery"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVAmtReceive">Amount Received $</asp:Label>
                    </td>
                    <td class="lc">
                        :</td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVDAmtReceive"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr><td colspan="6">&nbsp;</td></tr>
            </table>
        </div>
        <div id="Div4">
                <table width="100%" border="0" cellpadding="4" cellspacing="2" class="lc">
                    <tr>
                        <td colspan="2">
                            <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                <tr>
                                    <td class="ghc">
                                        Attachment Details
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="gvAttachView" runat="server" AutoGenerateColumns="false" DataKeyNames="PK_Attachment_ID"
                            Width="100%" AllowPaging="True" AllowSorting="False" OnRowDataBound="gvAttachView_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <input name="chkItem" type="checkbox" value='<%# Eval("PK_Attachment_ID")%>' onclick="javascript:UnCheckHeader('gvAttachView')" />
                                    </ItemTemplate>
                                    <ItemStyle Width="10px" />
                                    <HeaderTemplate>
                                        <input type="checkbox" name="chkHeader" id="chkHeader" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                    </HeaderTemplate>
                                    <HeaderStyle Width="10px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" Visible="false">
                                </asp:BoundField>
                                <asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description"
                                    SortExpression="Attachment_Description"></asp:BoundField>
                                <asp:BoundField DataField="Attachment_Name1" HeaderText="File Name">
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="View">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnDwnld" CommandName="Download" CommandArgument='<%# Eval("Attachment_Name")%>'
                                            runat="server" ImageAlign="Left" ImageUrl="~/Images/download.gif" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                </asp:TemplateField>                               
                            </Columns>
                            <EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                Currently there is no Attachment.<br />                                
                            </EmptyDataTemplate>
                            <PagerSettings Visible="False" />
                            <PagerSettings Visible="False" />
                        </asp:GridView>
                        </td>
                    </tr>
                    <%--<tr>
                        <td>
                            <asp:Button ID="btnViewMail" runat="server" Text="Mail" OnClientClick="javascript:return OpenWMail('gvAttachView','Worker_Comp_Subrogation_Detail');" />
                        </td>
                    </tr>--%>
                </table>
            </div>
         <div>
            <table cellpadding="4" cellspacing="2" border="0" style="width:100%;">
                <tr>
                    <td align="center" class="ic">
                        <asp:Button runat="server" ID="btnBack" Text="Back" OnClick="btnBack_Click"/>
                        <asp:Button runat="server" ID="btnViewNext" Text="Next Step" OnClick="btnViewNext_Click" Visible="false"/>
                    </td>
                </tr>
            </table>
         </div>
    </div>
    <asp:HiddenField runat="server" ID="hdnTagName" />

    <script language="javascript" type="text/javascript">
        if(document.getElementById("ctl00_ContentPlaceHolder1_hdnTagName").value != "")
        {
            var TagName = document.getElementById("ctl00_ContentPlaceHolder1_hdnTagName").value;
            
            switch(TagName)
            {
                case "first":
                    getfirst();
                    break;
                case "second":
                    getsecond();
                    break;
                case "third":
                    getthird();    
                    break;
            } 
        }
    </script>

</asp:Content>
