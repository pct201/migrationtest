<%@ Page Language="C#" MasterPageFile="~/Default.master"  
    Theme="Default" AutoEventWireup="true" CodeFile="Workers_ Compensation.aspx.cs"
    Inherits="Claim_Workers__Compensation" Title="Risk Insurance Management System" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>

    <script type="text/javascript">  
 
     function claimMeassage()
     {
        alert("Please Enter the Worker’s Compensation Claim Details.");
        return false;
     }  
 
 
        function ValAttach()
        {      
            document.getElementById("ctl00_ContentPlaceHolder1_ReqAtt11").enabled =true;
            document.getElementById("ctl00_ContentPlaceHolder1_Requupload").enabled =true;
            
            if(document.getElementById("ctl00_ContentPlaceHolder1_txtAttTelNo").value=="___-___-____")
               document.getElementById("ctl00_ContentPlaceHolder1_txtAttTelNo").value="";
               
            if(document.getElementById("ctl00_ContentPlaceHolder1_txtTelephone").value=="___-___-____")
               document.getElementById("ctl00_ContentPlaceHolder1_txtTelephone").value="";
               
            if(document.getElementById("ctl00_ContentPlaceHolder1_txttelotherparty").value=="___-___-____")
               document.getElementById("ctl00_ContentPlaceHolder1_txttelotherparty").value="";
        }
        
         function ValSave()
        {            
            document.getElementById("ctl00_ContentPlaceHolder1_ReqAtt11").enabled =false;
            document.getElementById("ctl00_ContentPlaceHolder1_Requupload").enabled =false;
            
            if(document.getElementById("ctl00_ContentPlaceHolder1_txtAttTelNo").value=="___-___-____")
               document.getElementById("ctl00_ContentPlaceHolder1_txtAttTelNo").value="";
               
            if(document.getElementById("ctl00_ContentPlaceHolder1_txtTelephone").value=="___-___-____")
               document.getElementById("ctl00_ContentPlaceHolder1_txtTelephone").value="";
               
            if(document.getElementById("ctl00_ContentPlaceHolder1_txttelotherparty").value=="___-___-____")
               document.getElementById("ctl00_ContentPlaceHolder1_txttelotherparty").value="";
        }
 
 
        function getfirst()
     { 
    
        clearfocus();
        document.getElementById("first").className="left_menu_active";
        document.getElementById("ctl00_ContentPlaceHolder1_divfirst").style.display ="block";
        document.getElementById("ctl00_ContentPlaceHolder1_dvAttachDetails").style.display ="none";
    }
    function getsecond()
    {
     
        clearfocus();
        document.getElementById("second").className="left_menu_active";
        document.getElementById("ctl00_ContentPlaceHolder1_divsecond").style.display ="block";
        document.getElementById("ctl00_ContentPlaceHolder1_dvAttachDetails").style.display ="none";
    }
    function getthird()
    {
        clearfocus();
        document.getElementById("third").className="left_menu_active"; 
        document.getElementById("ctl00_ContentPlaceHolder1_divthird").style.display ="block";
       document.getElementById("ctl00_ContentPlaceHolder1_dvAttachDetails").style.display ="none";
    }       
    
      function getfour()
    {
        clearfocus();
        document.getElementById("four").className="left_menu_active"; 
        document.getElementById("ctl00_ContentPlaceHolder1_divfour").style.display ="block";
        document.getElementById("ctl00_ContentPlaceHolder1_dvAttachDetails").style.display ="block";
    }
        
         function clearfocus()
    {
    

        document.getElementById("first").className="left_menu";   
        document.getElementById("second").className="left_menu"; 
        document.getElementById("third").className="left_menu";  
        document.getElementById("four").className="left_menu";     
                       
        document.getElementById("ctl00_ContentPlaceHolder1_divfirst").style.display ="none";  
        document.getElementById("ctl00_ContentPlaceHolder1_divsecond").style.display ="none";  
        document.getElementById("ctl00_ContentPlaceHolder1_divthird").style.display ="none";   
         document.getElementById("ctl00_ContentPlaceHolder1_divfour").style.display ="none";   
        document.getElementById("ctl00_ContentPlaceHolder1_dvAttachDetails").style.display ="none";   
     
    }
        
        
        
        
        
          function openPolicyPopup()
        {
          
            oWnd=window.open("../Claim/Policy_search_popup.aspx","Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=670,height=370");
            oWnd.moveTo(200,200);
            return false;
         
        }  
          function openClaimantPopup()
        {
            //oWnd=window.open("../Claim/Claimant_search.aspx?page=Auto","Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=610,height=350");
            oWnd=window.open("../Claim/EmployeePopup.aspx?page=WC","Erims1","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=700,height=450");
            oWnd.moveTo(250,200);
            self.close;
            return false;
        }
        
          function MinMax(name)
    {
       
       
        if(name == "attachment")
        {
            if(document.getElementById("ctl00_ContentPlaceHolder1_txtAttachDesc").style.height == "")
            {
                document.getElementById("ctl00_ContentPlaceHolder1_ibtnAttachment").src = "../Images/minus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_txtAttachDesc").style.height = "100px";
                document.getElementById("pnlAttach").style.display = "block";
            }
            else if(document.getElementById("ctl00_ContentPlaceHolder1_txtAttachDesc").style.height == "100px")
            {
                 document.getElementById("ctl00_ContentPlaceHolder1_ibtnAttachment").src = "../Images/plus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_txtAttachDesc").style.height="";
                document.getElementById("pnlAttach").style.display = "none";
            }
        }
        
         if(name == "DescOfAcc")
        {
            if(document.getElementById("ctl00_ContentPlaceHolder1_txtDescOfAcc").style.height == "")
            {
                document.getElementById("ctl00_ContentPlaceHolder1_imgDescOfAcc").src = "../Images/minus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_txtDescOfAcc").style.height = "100px";
                document.getElementById("pnlDescOfAcc").style.display = "block";
            }
            else if(document.getElementById("ctl00_ContentPlaceHolder1_txtDescOfAcc").style.height == "100px")
            {
                 document.getElementById("ctl00_ContentPlaceHolder1_imgDescOfAcc").src = "../Images/plus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_txtDescOfAcc").style.height="";
                document.getElementById("pnlDescOfAcc").style.display = "none";
            }
        }
        return false
        
        }
        
        		///Zip Code
		

	
//Function to verify numeric value in textbox
      function CheckNum(txtnum)
     {
        
        var txt = document.getElementById(txtnum);
        if((event.keyCode <= 47) || (event.keyCode > 58)|| (event.keyCode == 58))
        {
             if(event.keyCode != 46)
             {
                event.cancelBubble = true;
                event.returnValue = false;
             }
        }
   
     }


   function ZipMasking(e,str,textbox)
	{
	
		if(!((e.keyCode > 47 && e.keyCode < 58)||(e.keyCode > 95 && e.keyCode < 106)))
		{
			str = str.substring(0,str.length);
			textbox.value = str;
		}
		else
		{
			if(str.length ==1 && e.keyCode != 8)
			str= str;
			if(str.length == 5)
			{
				if(e.keyCode != 8)
				str = str+"-";
			}
			if(str.length == 10 && e.keyCode != 8)
			{	
				str = str;
			}

			if(str.charAt(5) != "-" && str.charAt(5) != "")
			{
				str = str.substring(0,5)+"-"+str.substring(5,str.length); 
			}

			str = str.substring(0,10);
		    textbox.value = str;

			
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
     
     
     	var pattern =/[0-9]/;
  
		function isValid(id) {
		    var keyCode = event.keyCode? event.keyCode : event.which;
			var key = String.fromCharCode(keyCode);
			if(!pattern.test(key))
			{
				event.keyCode="";
				return false;
			}
		} 
            
    </script>

    <asp:ScriptManager runat="server" ID="ScriptManager1">
    </asp:ScriptManager>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="false"
            ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
    </div>
    <div style="width: 100%" id="contmain">
        <br />
        <div id="dvDisable" runat="server" style="width: 100%; text-align: center">
            <table border="0" align="left" cellpadding="1" cellspacing="0" width="99%">
                <tr>
                    <td align="center" style="background-image: url('../images/active_btn.jpg')" class="active_tab"
                        valign="middle">
                        Worker’s Compensation
                    </td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="../Claim/ReserveWorksheetHistoryGrid.aspx" onclick="javascript:return claimMeassage();">
                            Reserve Worksheet</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="#" onclick="javascript:return claimMeassage();">Carrier Data</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="Subrogation.aspx" onclick="javascript:return claimMeassage();">
                            Subrogation</a>
                    </td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="#" onclick="javascript:return claimMeassage();">Subrogation
                            Detail</a>
                    </td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="../Claim/CheckRegister.aspx" onclick="javascript:return claimMeassage();">
                            Check Register</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="../Claim/Diary.aspx" onclick="javascript:return claimMeassage();">
                            Diary</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="../Claim/Adjuster.aspx" onclick="javascript:return claimMeassage();">
                            Adjustor Notes</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="#" onclick="javascript:return claimMeassage();">Settlement</a></td>
                </tr>
            </table>
        </div>
        <div id="Div1" runat="server" style="width: 100%; text-align: center">
            <table border="0" align="left" cellpadding="1" cellspacing="0" width="99%">
                <tr>
                    <td align="center" style="background-image: url('../images/active_btn.jpg')" class="active_tab"
                        valign="middle">
                        Worker’s Compensation
                    </td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="WorkerCompensationReserve.aspx">Reserve Worksheet</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="Carrier.aspx">Carrier Data</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="subrogation.aspx">Subrogation</a>
                    </td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="SubrogationDetail.aspx">Subrogation Detail</a>
                    </td>
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
        <div id="LeftDiv" runat="server" style="width: 20%; height: 350px; border: solid 1px;
            float: left;">
            <table border="0" cellpadding="4" cellspacing="4" width="100%">
                <tr>
                    <td style="height: 19px">
                        &nbsp;</td>
                    <td style="width: 90%; height: 19px">
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu_active" id="first" onclick="javascript:getfirst();" href="#">Claim
                            Identification <span class="mf">*</span></a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="second" onclick="javascript:getsecond();" href="#">Financial
                            Summary</a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td align="left">
                        <a class="left_menu" id="third" onclick="javascript:getthird();" href="#">Claim Representative
                            <span class="mf">*</span></a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="four" onclick="javascript:getfour();" href="#">Attachment</a></td>
                </tr>
            </table>
        </div>
        <div id="mainContent" runat="server" style="width: 79%; border: solid 1px; float: right;">
            <asp:UpdatePanel ID="pnlBankDetail" runat="server">
                <contenttemplate>
<DIV style="DISPLAY: block; WIDTH: 100%" id="divfirst" runat="server">
    <TABLE id="Table1" class="stylesheet" cellSpacing=2 cellPadding=2 width="100%" runat="server">
        <%--<TBODY>--%>
            <TR><TD class="ghc" colSpan=6><asp:Label id="lblClaimId" runat="server">Claim Identification 
                            </asp:Label> </TD></TR>
            <TR><TD style="WIDTH: 20%" id="claimno" class="lc" align=left>
                                <asp:Label id="lblClaimNumber" runat="server" Visible="false">Claim Number</asp:Label>

                                                       </TD><TD class="ic" align=center><asp:Label id="lblsep" runat="server" Visible="false">:</asp:Label> </TD>
                <TD style="WIDTH: 25%" class="ic" align=left><asp:Label id="lblclaimnoedit" runat="server">

                                                             </asp:Label>

                </TD><%--<td align="left" class="lc" style="width: 22%">
                            <asp:Label ID="lblReptoCarrier" runat="server">  Reported to Carrier</asp:Label>
                        </td>
                        <td align="center" class="ic">
                            :
                        </td>
                        <td align="left" class="lc" style="width: 25%">
                            <asp:RadioButtonList ID="rbtReptoCarrier" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>--%></TR><TR><TD style="WIDTH: 20%" class="lc" align=left>
                        <asp:Label id="lblStatus" runat="server">Status</asp:Label> </TD><TD class="lc" align=center>: </TD><TD style="WIDTH: 25%" class="lc" align=left><asp:RadioButtonList id="rbtStatus" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True">Open</asp:ListItem>
                                <asp:ListItem >Closed</asp:ListItem>
                                 <asp:ListItem >Reopened</asp:ListItem>
                            </asp:RadioButtonList> </TD><TD style="WIDTH: 20%" class="lc" align=left><asp:Label id="lblCarrierClaimNo" runat="server">Carrier Claim Number</asp:Label> </TD><TD class="lc" align=center>: </TD><TD><asp:TextBox id="txtCarrierClaimNo" runat="server" MaxLength="30"></asp:TextBox> </TD></TR><TR><TD class="lc" align=left>
                            <asp:Label id="lblLastName" runat="server">Employee Last Name</asp:Label>
                             <SPAN class="mf">*</SPAN> </TD>
                             <TD style="HEIGHT: 25px" class="lc" align=center>: </TD>
                             <TD class="ic" align=left runat="server">
                             <asp:TextBox onkeydown="javascript:return disableDeleteBackSpace();" id="txtLastName" runat="server"></asp:TextBox>
                              <asp:Button id="btnlastname" runat="server" Text="V" OnClientClick="javascript:return openClaimantPopup();"></asp:Button>
                               <asp:RequiredFieldValidator id="Req2" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="Please Enter [Claim Identification]/Last Name." Text="*" ControlToValidate="txtLastName"></asp:RequiredFieldValidator> </TD>
                               <TD style="WIDTH: 22%" class="lc" align=left><asp:Label id="lblDateReportedtoFair" runat="server">Date Reported to<br /> FairPoint </asp:Label> <SPAN class="mf">*</SPAN> </TD><TD class="ic" align=center>: </TD><TD style="WIDTH: 25%" class="lc" align=left><asp:TextBox id="txtDateReportedtoFair" runat="server"></asp:TextBox> <IMG onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateReportedtoFair', 'mm/dd/y');" src="../Images/iconPicDate.gif" align=absMiddle /> <cc1:MaskedEditExtender id="Mask" runat="server" AutoComplete="true" MaskType="Date" Mask="99/99/9999" TargetControlID="txtDateReportedtoFair" AcceptNegative="Left" DisplayMoney="Left" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" CultureName="en-US" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender> <cc1:MaskedEditValidator id="MaskedEditValidator1" runat="server" ValidationGroup="vsErrorGroup" Display="dynamic" ControlToValidate="txtDateReportedtoFair" ControlExtender="Mask" IsValidEmpty="true" MaximumValue="" InvalidValueMessage="Invalid Date" MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                            </cc1:MaskedEditValidator> <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Claim Identification]/Date Reported to FairPoint is Not Valid." ControlToValidate="txtDateReportedtoFair" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$">
                            </asp:RegularExpressionValidator> <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="Please Enter [Claim Identification]/ Date Reported to FairPoint." Text="*" ControlToValidate="txtDateReportedtoFair"></asp:RequiredFieldValidator> </TD></TR><TR><TD class="lc" align=left><asp:Label id="lblFirstName" runat="server">Employee First Name</asp:Label> </TD><TD style="HEIGHT: 25px" class="lc" align=center>: </TD><TD class="ic" align=left><asp:TextBox onkeydown="javascript:return disableDeleteBackSpace();" id="txtFirstName" runat="server"></asp:TextBox> </TD><TD class="lc" align=left><asp:Label id="lblDateClaimOpened" runat="server"> Date Claim Opened </asp:Label> </TD><TD class="lc" align=center>: </TD><TD class="ic" align=left><asp:TextBox id="txtDateClaimOpened" runat="server"></asp:TextBox> <IMG onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateClaimOpened', 'mm/dd/y');" src="../Images/iconPicDate.gif" align=absMiddle /> <cc1:MaskedEditExtender id="mask2" runat="server" AutoComplete="true" MaskType="Date" Mask="99/99/9999" TargetControlID="txtDateClaimOpened" AcceptNegative="Left" DisplayMoney="Left" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" CultureName="en-US" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender> <cc1:MaskedEditValidator id="MaskedEditValidator2" runat="server" ValidationGroup="vsErrorGroup" Display="dynamic" ControlToValidate="txtDateClaimOpened" ControlExtender="mask2" IsValidEmpty="true" MaximumValue="" InvalidValueMessage="Invalid Date" MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                            </cc1:MaskedEditValidator> <asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Claim Identification]/Date Claim Opened is Not Valid." ControlToValidate="txtDateClaimOpened" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$">
                            </asp:RegularExpressionValidator> <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDateReportedtoFair"
                                Display="none" Text="*" ErrorMessage="Please Enter [Claim Identification]/Date Claim Opened."
                                ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                      --%><asp:CompareValidator id="cvCompServiceDate" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Claim Identification]/Claim Closed Date Must Be Greater Than or Equal To [Claim Identification]/Claim Opened Date." ControlToValidate="txtDateClaimClosed" Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtDateClaimOpened">
                            </asp:CompareValidator> </TD></TR><TR><TD style="WIDTH: 20%" class="lc" align=left><asp:Label id="lblUnion" runat="server">Union Member?</asp:Label> </TD><TD class="lc" align=center>: </TD><TD style="WIDTH: 25%" class="lc" align=left><asp:RadioButtonList id="rbtnUnion" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="True">No</asp:ListItem>
                                 
                            </asp:RadioButtonList> </TD><TD class="lc" align=left><asp:Label id="lblDateClaimClosed" runat="server">Date Claim Closed</asp:Label> </TD><TD class="lc" align=center>: </TD><TD class="ic" align=left><asp:TextBox id="txtDateClaimClosed" runat="server"></asp:TextBox> <IMG onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateClaimClosed', 'mm/dd/y');" src="../Images/iconPicDate.gif" align=absMiddle /> <cc1:MaskedEditExtender id="Mask3" runat="server" AutoComplete="true" MaskType="Date" Mask="99/99/9999" TargetControlID="txtDateClaimClosed" AcceptNegative="Left" DisplayMoney="Left" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" CultureName="en-US" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender> <cc1:MaskedEditValidator id="MaskedEditValidator3" runat="server" ValidationGroup="vsErrorGroup" Display="dynamic" ControlToValidate="txtDateClaimClosed" ControlExtender="Mask3" IsValidEmpty="true" MaximumValue="" InvalidValueMessage="Invalid Date" MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                            </cc1:MaskedEditValidator> <asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Claim Identification]/Date Claim Closed is Not Valid." ControlToValidate="txtDateClaimClosed" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$">
                            </asp:RegularExpressionValidator> </TD></TR><TR><TD class="lc" align=left><asp:Label id="lblDateofLoss" runat="server">Date of Loss </asp:Label> <SPAN class="mf">*</SPAN> </TD><TD class="lc" align=center>: </TD><TD class="ic" align=left><asp:TextBox id="txtDateofLoss" runat="server"></asp:TextBox> <IMG onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateofLoss', 'mm/dd/y');" src="../Images/iconPicDate.gif" align=absMiddle /> <cc1:MaskedEditExtender id="Mask4" runat="server" AutoComplete="true" MaskType="Date" Mask="99/99/9999" TargetControlID="txtDateofLoss" AcceptNegative="Left" DisplayMoney="Left" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" CultureName="en-US" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender> <cc1:MaskedEditValidator id="MaskedEditValidator6" runat="server" ValidationGroup="vsErrorGroup" Display="dynamic" ControlToValidate="txtDateofLoss" ControlExtender="Mask4" IsValidEmpty="true" MaximumValue="" InvalidValueMessage="Invalid Date" MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                            </cc1:MaskedEditValidator> <asp:RegularExpressionValidator id="RegularExpressionValidator6" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Claim Identification]/Date of Lossd is Not Valid" ControlToValidate="txtDateofLoss" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$">
                            </asp:RegularExpressionValidator> <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="Please Enter [Claim Identification]/Date of Loss" Text="*" ControlToValidate="txtDateofLoss"></asp:RequiredFieldValidator> <asp:CompareValidator id="cvLossNReportedF" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Claim Identification]/Date Reported to Fairpoint Must Be Greater Than or Equal To Date Of Loss." ControlToValidate="txtDateReportedtoFair" Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtDateofLoss">
                            </asp:CompareValidator> <asp:CompareValidator id="cvLossNReportedC" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Claim Identification]/Date Reported to Carrier Must Be Greater Than or Equal To Date Of Loss." ControlToValidate="txtlblDateReportedtoCarrier" Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtDateofLoss">
                            </asp:CompareValidator> <asp:CompareValidator id="cvClaimOpnCls" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Claim Identification]/Date Opened Must Be Greater Than or Equal To Date of Loss." ControlToValidate="txtDateClaimOpened" Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtDateofLoss">
                            </asp:CompareValidator> </TD><TD class="lc" align=left><asp:Label id="lblDateClaimReopened" runat="server">Date Claim Reopened</asp:Label> </TD><TD class="lc" align=center>: </TD><TD class="ic" align=left><asp:TextBox id="txtDateClaimReopened" runat="server"></asp:TextBox> <IMG onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateClaimReopened', 'mm/dd/y');" src="../Images/iconPicDate.gif" align=absMiddle /> <cc1:MaskedEditExtender id="Mask5" runat="server" AutoComplete="true" MaskType="Date" Mask="99/99/9999" TargetControlID="txtDateClaimReopened" AcceptNegative="Left" DisplayMoney="Left" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" CultureName="en-US" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender> <cc1:MaskedEditValidator id="MaskedEditValidator4" runat="server" ValidationGroup="vsErrorGroup" Display="dynamic" ControlToValidate="txtDateClaimReopened" ControlExtender="Mask5" IsValidEmpty="true" MaximumValue="" InvalidValueMessage="Invalid Date" MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                            </cc1:MaskedEditValidator> <asp:RegularExpressionValidator id="RegularExpressionValidator4" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Claim Identification]/Date Claim Reopened is Not Valid" ControlToValidate="txtDateClaimReopened" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$">
                            </asp:RegularExpressionValidator> <asp:CompareValidator id="cvReopnNopen" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Claim Identification]/Claim Reopened Date Must Be Greater Than or Equal to Claim Opened Date." ControlToValidate="txtDateClaimReopened" Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtDateClaimOpened">
                            </asp:CompareValidator> <asp:CompareValidator id="cvReopnNclose" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Claim Identification]/Claim Reopened Date Must Be Greater Than or Equal to Claim Closed Date." ControlToValidate="txtDateClaimReopened" Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtDateClaimClosed">
                            </asp:CompareValidator> </TD></TR><TR><TD style="WIDTH: 25%" class="lc" align=left><asp:Label id="lblEntity" runat="server"> Entity  </asp:Label> <SPAN class="mf">*</SPAN> </TD><TD class="lc" align=center>: </TD><TD style="WIDTH: 75%" class="ic" align=left colSpan=5><asp:DropDownList id="dwEntity" runat="server" Width="552px" SkinID="dropGen">
                            </asp:DropDownList> <asp:RequiredFieldValidator id="Req4" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="Please Select [Claim Identification]/Entity" Text="*" ControlToValidate="dwEntity" InitialValue="0"></asp:RequiredFieldValidator> </TD></TR><TR><TD style="WIDTH: 25%" class="lc" align=left><asp:Label id="lblBenefitState" runat="server"> Benefit State  </asp:Label> </TD><TD class="ic" align=center>: </TD><TD class="ic" align=left><asp:DropDownList id="ddlBenefitState" runat="server">
                            </asp:DropDownList> </TD><TD class="lc" align=left><asp:Label id="lblDateReportedtoCarrier" runat="server"> Date Reported to Carrier </asp:Label> <%-- <span class="mf">*</span>--%></TD><TD class="lc" align=center>: </TD><TD class="ic" align=left><asp:TextBox id="txtlblDateReportedtoCarrier" runat="server"></asp:TextBox> <IMG onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtlblDateReportedtoCarrier', 'mm/dd/y');" src="../Images/iconPicDate.gif" align=absMiddle /> <cc1:MaskedEditExtender id="Mask6" runat="server" AutoComplete="true" MaskType="Date" Mask="99/99/9999" TargetControlID="txtlblDateReportedtoCarrier" AcceptNegative="Left" DisplayMoney="Left" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" CultureName="en-US" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender> <cc1:MaskedEditValidator id="MaskedEditValidator5" runat="server" ValidationGroup="vsErrorGroup" Display="dynamic" ControlToValidate="txtlblDateReportedtoCarrier" ControlExtender="Mask6" IsValidEmpty="true" MaximumValue="" InvalidValueMessage="Invalid Date" MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                            </cc1:MaskedEditValidator> <asp:RegularExpressionValidator id="RegularExpressionValidator5" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Claim Identification]/Date Reported to Carrier is Not Valid" ControlToValidate="txtlblDateReportedtoCarrier" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$">
                            </asp:RegularExpressionValidator> </TD></TR><TR><TD class="ic"><asp:Label id="lblCompRate" runat="server">Comp Rate</asp:Label> </TD><TD align=center>: </TD><TD class="ic"><asp:TextBox id="txtCompRate" runat="server" MaxLength="7"></asp:TextBox> </TD><TD class="lc" align=left><asp:Label id="lblCarrierName" runat="server">Carrier Name</asp:Label> </TD><TD class="lc" align=center>: </TD><TD class="ic" align=left><asp:TextBox onkeydown="javascript:return disableDeleteBackSpace();" id="txtCarrierName" runat="server"></asp:TextBox> <asp:Button id="Button1" runat="server" Text="V" OnClientClick="javascript:return openPolicyPopup();"></asp:Button> <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCarrierName"
                                Display="none" Text="*" ErrorMessage="Please Enter [Claim Identification]/Carrier Name."
                                ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>--%></TD></TR><TR><TD class="lc" align=left><asp:Label id="lblLastDate" runat="server">Last Date of Work</asp:Label> </TD><TD class="lc" align=center>: </TD><TD class="ic" align=left><asp:TextBox id="txtlastDate" runat="server"></asp:TextBox> <IMG onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtlastDate', 'mm/dd/y');" src="../Images/iconPicDate.gif" align=absMiddle /> <cc1:MaskedEditExtender id="Mask7" runat="server" AutoComplete="true" MaskType="Date" Mask="99/99/9999" TargetControlID="txtlastDate" AcceptNegative="Left" DisplayMoney="Left" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" CultureName="en-US" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender> <cc1:MaskedEditValidator id="MaskedEditValidator7" runat="server" ValidationGroup="vsErrorGroup" Display="dynamic" ControlToValidate="txtlastDate" ControlExtender="Mask7" IsValidEmpty="true" MaximumValue="" InvalidValueMessage="Invalid Date" MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                            </cc1:MaskedEditValidator> <asp:RegularExpressionValidator id="RegularExpressionValidator9" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Claim Identification]/Last Date of Work is Not Valid." ControlToValidate="txtlastDate" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$">
                            </asp:RegularExpressionValidator> </TD><TD class="lc"><asp:Label id="lblTPAName" runat="server">TPA Name</asp:Label> </TD><TD align=center>: </TD><TD class="ic"><asp:TextBox id="txtTPAName" runat="server" MaxLength="50"></asp:TextBox> </TD></TR><TR><TD class="lc" align=left><asp:Label id="lblDateRTW" runat="server">Date RTW</asp:Label> </TD><TD class="lc" align=center>: </TD><TD class="ic" align=left><asp:TextBox id="txtDateRTW" runat="server"></asp:TextBox> <IMG onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateRTW', 'mm/dd/y');" src="../Images/iconPicDate.gif" align=absMiddle /> <cc1:MaskedEditExtender id="Mask8" runat="server" AutoComplete="true" MaskType="Date" Mask="99/99/9999" TargetControlID="txtDateRTW" AcceptNegative="Left" DisplayMoney="Left" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" CultureName="en-US" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender> <cc1:MaskedEditValidator id="MaskedEditValidator8" runat="server" ValidationGroup="vsErrorGroup" Display="dynamic" ControlToValidate="txtDateRTW" ControlExtender="Mask8" IsValidEmpty="true" MaximumValue="" InvalidValueMessage="Invalid Date" MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                            </cc1:MaskedEditValidator> <asp:RegularExpressionValidator id="RegularExpressionValidator10" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Claim Identification]/Date RTW is Not Valid." ControlToValidate="txtDateRTW" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$">
                            </asp:RegularExpressionValidator> </TD><TD class="lc"><asp:Label id="lblPolicyNo" runat="server">Policy Number</asp:Label> </TD><TD class="ic" align=center>: </TD><TD class="ic"><asp:TextBox onkeydown="javascript:return disableDeleteBackSpace();" id="txtPolicyNo" runat="server"></asp:TextBox> </TD></TR><TR><TD class="lc"><asp:Label id="lblTimeofLoss" runat="server">Time of Loss (HH:MM)</asp:Label> </TD><TD align=center>: </TD><TD class="ic"><asp:TextBox id="txtTimeofLoss" runat="server" MaxLength="5"></asp:TextBox> <cc1:MaskedEditExtender id="Masketime1" runat="server" AutoComplete="true" MaskType="Time" Mask="99:99" TargetControlID="txtTimeofLoss" AcceptNegative="Left" DisplayMoney="Left" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" CultureName="en-US">
                            </cc1:MaskedEditExtender> <cc1:MaskedEditValidator id="MaskedEditValidator30" runat="server" ValidationGroup="vsErrorGroup" Display="None" ControlToValidate="txtTimeofLoss" ControlExtender="Masketime1" IsValidEmpty="true" MaximumValue="" InvalidValueMessage="[Claim Identification]/Time of Loss is invalid." MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                            </cc1:MaskedEditValidator> </TD><TD class="lc"><asp:Label id="lblPolicyEffecDate" runat="server">Policy Effective Date</asp:Label> </TD><TD class="ic" align=center>: </TD><TD class="ic"><asp:TextBox onkeydown="javascript:return disableDeleteBackSpace();" id="txtPolicyEffecDate" runat="server"></asp:TextBox> <asp:RegularExpressionValidator id="RegularExpressionValidator8" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Claim Identification]/Policy Effective Date is Not Valid." ControlToValidate="txtPolicyEffecDate" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$">
                            </asp:RegularExpressionValidator> </TD></TR><TR><TD class="lc" align=left><asp:Label id="lblTransitional" runat="server">Transitional Duty?</asp:Label> </TD><TD class="ic" align=center>: </TD><TD class="lc" align=left><asp:RadioButtonList id="rbtnTransitional" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList> </TD><TD class="lc"><asp:Label id="lblPolicyExpDate" runat="server">Policy Expiration Date</asp:Label> </TD><TD class="ic" align=center>: </TD><TD class="ic"><asp:TextBox onkeydown="javascript:return disableDeleteBackSpace();" id="txtPolicyExpDate" runat="server"></asp:TextBox> <asp:RegularExpressionValidator id="RegularExpressionValidator7" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Claim Identification]/Policy Expiration Date is Not Valid." ControlToValidate="txtPolicyExpDate" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$">
                            </asp:RegularExpressionValidator> </TD></TR><TR><TD class="lc" align=left><asp:Label id="lblTransDutyRefused" runat="server">Transitional Duty Refused?</asp:Label> </TD><TD class="ic" align=center>: </TD><TD class="lc" align=left><asp:RadioButtonList id="rbtnTransDutyRefused" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList> </TD><TD class="lc" align=left><asp:Label id="lblTypeofClaim" runat="server">Type of Claim</asp:Label> </TD><TD class="ic" align=center>: </TD><TD class="ic" align=left><asp:RadioButtonList id="rbtnTypeofClaim" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True">LT</asp:ListItem>
                                <asp:ListItem >MO</asp:ListItem>
                            </asp:RadioButtonList> </TD></TR><TR><TD class="lc" align=left><asp:Label id="lblinjuryCode" runat="server">Injury Code</asp:Label> </TD><TD class="ic" align=center>: </TD><TD class="ic" align=left colSpan=4><asp:DropDownList id="ddlinjuryCode" runat="server" Width="552px" SkinID="dropGen"></asp:DropDownList> </TD></TR><TR><TD class="lc" align=left><asp:Label id="lblCauseCode" runat="server">Cause Code</asp:Label> </TD><TD class="lc" align=center>: </TD><TD class="ic" align=left colSpan=4><asp:DropDownList id="ddlCauseCode" runat="server" Width="552px" SkinID="dropGen"></asp:DropDownList> </TD></TR><TR><TD class="lc" align=left><asp:Label id="lblBodyParts" runat="server">Body Parts</asp:Label> </TD><TD class="lc" align=center>: </TD><TD class="ic" align=left colSpan=4><asp:DropDownList id="ddlBodyParts" runat="server" Width="552px" SkinID="dropGen"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 20%" class="lc" vAlign=top align=left><asp:Label id="lblDescOfAcc" runat="server">Description of Accident 
                            <span class="mf">*</span>
                          
                            

                            </asp:Label> </TD><TD class="ic" vAlign=top align=center>: </TD><TD class="ic" colSpan=4><asp:ImageButton id="imgDescOfAcc" runat="server" OnClientClick="javascript:return MinMax('DescOfAcc');" ImageUrl="../Images/Minus.jpg"></asp:ImageButton> <DIV style="DISPLAY: block" id="pnlDescOfAcc"><asp:TextBox id="txtDescOfAcc" runat="server" Width="95%" MaxLength="4000" Height="100px" TextMode="MultiLine"></asp:TextBox> </DIV><asp:RequiredFieldValidator id="rvAccDesc" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="Please Enter [Claim Identification]/Description of Accident ." Text="*" ControlToValidate="txtDescOfAcc"></asp:RequiredFieldValidator> </TD></TR><TR><TD class="lc" align=left><asp:Label id="lblFatality" runat="server">Fatality?</asp:Label> </TD><TD class="ic" align=center>: </TD><TD class="ic" align=left><asp:RadioButtonList id="rbtnFatality" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem >Yes</asp:ListItem>
                                <asp:ListItem Selected="True" >No</asp:ListItem>
                            </asp:RadioButtonList> </TD><TD class="lc" align=left><asp:Label id="lblDOB" runat="server">Date of Birth</asp:Label> </TD><TD class="lc" align=center>: </TD><TD class="ic" align=left><asp:TextBox id="txtDOB" runat="server"></asp:TextBox> <IMG onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDOB', 'mm/dd/y');" src="../Images/iconPicDate.gif" align=absMiddle /> <cc1:MaskedEditExtender id="MskDOB" runat="server" AutoComplete="true" MaskType="Date" Mask="99/99/9999" TargetControlID="txtDOB" AcceptNegative="Left" DisplayMoney="Left" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" CultureName="en-US" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender> <cc1:MaskedEditValidator id="MaskedEditValidator9" runat="server" ValidationGroup="vsErrorGroup" Display="dynamic" ControlToValidate="txtDOB" ControlExtender="MskDOB" IsValidEmpty="true" MaximumValue="" InvalidValueMessage="Invalid Date" MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                            </cc1:MaskedEditValidator> <asp:RegularExpressionValidator id="RegularExpressionValidator11" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Claim Identification]/Date of Birth is Not Valid." ControlToValidate="txtDOB" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$">
                            </asp:RegularExpressionValidator> </TD></TR><TR><TD class="lc" align=left><asp:Label id="lblDOH" runat="server">Date of Hire</asp:Label> </TD><TD class="lc" align=center>: </TD><TD class="ic" align=left><asp:TextBox id="txtDOH" runat="server"></asp:TextBox> <IMG onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDOH', 'mm/dd/y');" src="../Images/iconPicDate.gif" align=absMiddle /> <cc1:MaskedEditExtender id="MskDOH" runat="server" AutoComplete="true" MaskType="Date" Mask="99/99/9999" TargetControlID="txtDOH" AcceptNegative="Left" DisplayMoney="Left" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" CultureName="en-US" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender> <cc1:MaskedEditValidator id="MaskedEditValidator10" runat="server" ValidationGroup="vsErrorGroup" Display="dynamic" ControlToValidate="txtDOH" ControlExtender="MskDOH" IsValidEmpty="true" MaximumValue="" InvalidValueMessage="Invalid Date" MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                            </cc1:MaskedEditValidator> <asp:RegularExpressionValidator id="RegularExpressionValidator12" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Claim Identification]/Date of Hire is Not Valid." ControlToValidate="txtDOH" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$">
                            </asp:RegularExpressionValidator> </TD><TD class="lc" align=left><asp:Label id="lblDoesClimant" runat="server">Does Claimant have legal representation?</asp:Label> </TD><TD class="ic" align=center>: </TD><TD class="lc" align=left><asp:RadioButtonList id="rbtnDoesClimant" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList> </TD></TR><TR><TD class="lc" align=left><asp:Label id="lblAttorneyName" runat="server">Attorney Name</asp:Label> </TD><TD class="ic" align=center>: </TD><TD><asp:TextBox id="txtAttorneyName" runat="server" MaxLength="50"></asp:TextBox> </TD><TD class="lc" align=left><asp:Label id="lblAttTelNo" runat="server">Attorney Telephone Number </asp:Label> </TD><TD class="ic" align=center>: </TD><TD><asp:TextBox id="txtAttTelNo" runat="server" MaxLength="12"></asp:TextBox> <cc1:MaskedEditExtender id="MaskedEditExtender3" runat="server" ClearMaskOnLostFocus="false" AutoComplete="False" MaskType="Number" Mask="999-999-9999" TargetControlID="txtAttTelNo">
                            </cc1:MaskedEditExtender> <asp:RegularExpressionValidator id="RegularExpressionValidator13" runat="server" CssClass="ic" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage=" [Company Driver Information]/Please Enter the Attorney Telephone Number in xxx-xxx-xxxx format." ControlToValidate="txtAttTelNo" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator> </TD></TR><%--</TBODY>--%>

    </TABLE></DIV>
</contenttemplate>
            </asp:UpdatePanel>
            <div id="tempid" runat="server" style="display: none">
                <table id="Table14" runat="server" cellpadding="2" cellspacing="2" class="stylesheet"
                    width="100%">
                    <tr>
                        <td class="ic">
                            <asp:TextBox ID="txtempid" runat="server">
                            </asp:TextBox>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:TextBox ID="txtpolicyid" runat="server">
                            </asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <%-- <asp:TextBox ID="txtEmpid" runat="server"></asp:TextBox>--%>
                        </td>
                    </tr>
                </table>
            </div>
            <!-- Start Div Tag for Financial Details -->
            <div id="divsecond" style="width: 100%; display: none;" runat="server">
                <table cellpadding="2" border="0" cellspacing="2" style="width: 100%;" class="stylesheet">
                    <tr>
                        <td class="ghc" align="left" colspan="5">
                            Financial Details
                        </td>
                    </tr>
                </table>
                <table id="tblDetail" runat="server" cellpadding="2" border="0" cellspacing="2" style="width: 100%;"
                    class="stylesheet">
                    <tr>
                        <td align="center" class="lc">
                            &nbsp;</td>
                        <td class="lc" align="right" style="font-family: Verdana; color: black">
                            <b>Incurred $</b></td>
                        <td class="lc" align="right" style="font-family: Verdana; color: black">
                            <b>Paid $</b></td>
                        <td align="right" class="lc" style="font-family: Verdana; color: black">
                            <b>Outstanding $</b></td>
                        <td align="right" class="lc" runat="server" style="font-family: Verdana; color: black;
                            display: none;">
                            <b>Current Month $</b></td>
                        <td>
                            &nbsp &nbsp &nbsp</td>
                    </tr>
                    <tr>
                        <td align="left" class="lc" style="font-family: Verdana; color: black">
                            <b>Indemnity</b></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblIndemIncurred"></asp:Label></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblIndemPaid"></asp:Label></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblIndemOutStanding"></asp:Label></td>
                        <td align="right" class="lc" runat="server" style="display: none;">
                            <asp:Label runat="server" ID="lblIndemCurrentMonth"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" class="lc" style="font-family: Verdana; color: black">
                            <b>Medical</b>
                        </td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblMediIncured"></asp:Label></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblMediPaid"></asp:Label></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblMediOutStand"></asp:Label></td>
                        <td align="right" class="lc" runat="server" style="display: none;">
                            <asp:Label runat="server" ID="lblMediCurrentMonth"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" class="lc" style="font-family: Verdana; color: black">
                            <b>Expenses </b>
                        </td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblExpIncurred"></asp:Label></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblExpIndemPaid"></asp:Label></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblExpOutStand"></asp:Label></td>
                        <td align="right" class="lc" runat="server" style="display: none;">
                            <asp:Label runat="server" ID="lblExpCurrentMonth"></asp:Label></td>
                    </tr>
                </table>
                <table id="tblNoData" cellpadding="2" cellspacing="2" runat="server" style="width: 100%;
                    display: none;">
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="ic" align="center">
                            <a style="color: Gray;">No Financial Details found for this claim.</a>
                        </td>
                    </tr>
                    <%--<br />
                    <br />--%>
                </table>
            </div>
            <div id="divthird" style="width: 100%; display: none;" runat="server">
                <table id="Table2" runat="server" cellpadding="2" cellspacing="2" class="stylesheet"
                    width="100%">
                    <tr>
                        <td class="ghc" colspan="6">
                            <asp:Label ID="lblClaimRepresent" runat="server">Claim Representative 
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label ID="lblFairPoint" runat="server"><strong style="color:black"> FairPoint</strong></asp:Label>
                        </td>
                        <td>
                            &nbsp</td>
                        <td>
                            &nbsp</td>
                        <td>
                            &nbsp</td>
                    </tr>
                    <tr>
                        <td align="left" class="lc" style="width: 20%">
                            <asp:Label ID="lblname" runat="server">Name</asp:Label>
                            <span class="mf">*</span>
                        </td>
                        <td align="center" class="ic">
                            :
                        </td>
                        <td align="left" class="ic" style="width: 25%">
                            <asp:TextBox ID="txtname" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtname"
                                Display="none" Text="*" ErrorMessage="Please Enter [Claim Representative]/Name"
                                ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left" class="lc" style="width: 20%">
                            <asp:Label ID="lblTelephone" runat="server">Telephone</asp:Label>
                            <%--<span class="mf">*</span>--%>
                        </td>
                        <td align="center" class="ic">
                            :
                        </td>
                        <td align="left" class="ic" style="width: 25%">
                            <asp:TextBox ID="txtTelephone" runat="server" MaxLength="12"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="mskPhone" runat="server" TargetControlID="txtTelephone"
                                Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                            </cc1:MaskedEditExtender>
                            <asp:RegularExpressionValidator ID="revPhone" ControlToValidate="txtTelephone" runat="server"
                                ValidationGroup="vsErrorGroup" ErrorMessage="[Claim Representative]/Please Enter the Telephone Number in xxx-xxx-xxxx format."
                                Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTelephone"
                                Display="none" Text="*" ErrorMessage="Please Enter [Claim Representative]/Telephone Number."
                                ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                    --%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc" style="width: 20%">
                            <asp:Label ID="lblEMail" runat="server">E-Mail</asp:Label>
                        </td>
                        <td align="center" class="ic">
                            :
                        </td>
                        <td align="left" class="ic" style="width: 25%">
                            <asp:TextBox ID="txtEMail" runat="server" MaxLength="255"></asp:TextBox>
                            <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEMail"
                                Display="none" Text="*" ErrorMessage="Please Enter [Claim Representative]/E-Mail."
                                ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                         --%>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEMail"
                                ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="[Claim Representative]/Email Address Is Invalid."
                                SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                        </td>
                        <td>
                            &nbsp</td>
                        <td>
                            &nbsp</td>
                        <td>
                            &nbsp</td>
                    </tr>
                </table>
                <table id="Table12" runat="server" cellpadding="2" cellspacing="2" class="stylesheet"
                    width="100%">
                    <tr>
                        <td class="lc" colspan="6">
                            <asp:Label ID="lblotherpatrty" runat="server"><strong style="color:black">Other Party</strong> 
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc" style="width: 20%">
                            <asp:Label ID="lblnameotherparty" runat="server">Name</asp:Label>
                        </td>
                        <td align="center" class="ic">
                            :
                        </td>
                        <td align="left" class="ic" style="width: 25%">
                            <asp:TextBox ID="txtnameotherparty" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                        <td align="left" class="lc" style="width: 20%">
                            <asp:Label ID="lbltelotherparty" runat="server">Telephone</asp:Label>
                        </td>
                        <td align="center" class="ic">
                            :
                        </td>
                        <td align="left" class="ic" style="width: 25%">
                            <asp:TextBox ID="txttelotherparty" runat="server" MaxLength="12"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txttelotherparty"
                                Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                            </cc1:MaskedEditExtender>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator14" ControlToValidate="txttelotherparty"
                                runat="server" ValidationGroup="vsErrorGroup" ErrorMessage=" [Other Party]/Please Enter the Telephone Number in xxx-xxx-xxxx format."
                                Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc" style="width: 20%">
                            <asp:Label ID="lblEmailotherparty" runat="server">E-Mail</asp:Label>
                            <%--<span class="mf">*</span>--%>
                        </td>
                        <td align="center" class="ic">
                            :
                        </td>
                        <td align="left" class="ic" style="width: 25%">
                            <asp:TextBox ID="txtEmailotherparty" runat="server" MaxLength="255"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                                ControlToValidate="txtEmailotherparty" ValidationGroup="vsErrorGroup" Display="None"
                                ErrorMessage=" [Other Party]/Email Address Is Invalid." SetFocusOnError="True"
                                ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                        </td>
                        <td>
                            &nbsp</td>
                        <td>
                            &nbsp</td>
                        <td>
                            &nbsp</td>
                    </tr>
                </table>
            </div>
            <%--   <asp:UpdatePanel ID="pnlAttach" runat="server">
          <contenttemplate>--%>
            <div id="divfour" style="width: 100%; display: none;" runat="server">
                <table id="Table6" runat="server" cellpadding="2" cellspacing="2" width="100%">
                    <tr>
                        <td class="ghc" colspan="6">
                            <asp:Label ID="lblAttachment" runat="server">Attachment</asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td align="left" class="lc" valign="top" style="width: 20%;">
                            <asp:Label ID="lblAttachmentType" runat="server">Attachment Type</asp:Label>
                        </td>
                        <td align="Center" class="lc" valign="top" style="width: 5%;">
                            :
                        </td>
                        <td align="left" class="ic" colspan="4" valign="top">
                            <asp:DropDownList ID="ddlAttachType" runat="server" SkinID="dropdw" Width="182px">
                            </asp:DropDownList>&nbsp;
                            <asp:RequiredFieldValidator ID="ReqAtt11" runat="server" ControlToValidate="ddlAttachType"
                                Display="none" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please select Attachment Type"
                                InitialValue="0"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc" valign="top" style="width: 20%;">
                            <asp:Label ID="lblAttachDesc" runat="server">Attachment Description</asp:Label>
                        </td>
                        <td align="Center" class="lc" valign="top" style="width: 5%;">
                            :
                        </td>
                        <td align="left" class="ic" colspan="4" valign="top">
                            <asp:ImageButton ID="ibtnAttachment" ImageUrl="~/Images/minus.jpg" runat="server"
                                OnClientClick="javascript:return MinMax('attachment');" />
                            <div id="pnlAttach" style="display: block;">
                                <asp:TextBox ID="txtAttachDesc" runat="server" TextMode="MultiLine" Height="100px"
                                    MaxLength="4000" Width="90%"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc" valign="top">
                            <asp:Label ID="lblSelect" runat="server">Select File</asp:Label>
                        </td>
                        <td align="Center" class="lc" valign="top">
                            :
                        </td>
                        <td align="left" class="ic" colspan="4" valign="top">
                            <asp:FileUpload ID="uplCommon" runat="server" />
                            <asp:RequiredFieldValidator ID="Requupload" runat="server" ControlToValidate="uplCommon"
                                Display="none" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select [Attachment]/File to Upload"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp</td>
                        <td>
                            &nbsp</td>
                        <td>
                            &nbsp</td>
                        <td>
                            &nbsp</td>
                        <td>
                            &nbsp</td>
                        <td>
                            &nbsp</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp</td>
                        <td>
                            &nbsp</td>
                        <td>
                            &nbsp</td>
                        <td>
                            &nbsp</td>
                        <td>
                            &nbsp</td>
                        <td>
                            &nbsp</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="6">
                            <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" OnClientClick="javascript:ValAttach();"
                                ValidationGroup="vsErrorGroup" OnClick="btnAddAttachment_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <%-- </contenttemplate>
           </asp:UpdatePanel>--%>
            <div id="dvAttachDetails" runat="server" style="display: none;">
                <table width="100%">
                    <tr>
                        <td colspan="2">
                            <table cellspacing="1" style="background-color: #7f7f7f; color: White; font-weight: Bolder;
                                font-family: Tahoma; font-size: 10pt;" width="100%">
                                <tr>
                                    <td class="ghc">
                                        <asp:Label ID="lblAttachDetails" runat="server"> Attachment Details</asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="gvAttachmentDetails" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="false" DataKeyNames="PK_Attachment_ID" OnRowDataBound="gvAttachmentDetails_RowDataBound"
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <input name="chkItem" onclick="javascript:UnCheckHeader('gvAttachmentDetails')" type="checkbox"
                                                value='<%# Eval("PK_Attachment_ID")%>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" />
                                        <HeaderTemplate>
                                            <input name="chkHeader" id="chkHeader" runat="server" onclick="javascript:SelectAllCheckboxes(this)"
                                                type="checkbox" />
                                        </HeaderTemplate>
                                        <HeaderStyle Width="10px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" Visible="false" />
                                    <asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description" />
                                    <asp:BoundField DataField="Attachment_Name1" HeaderText="File Name" />
                                    <asp:TemplateField HeaderText="View">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnDwnld" runat="server" CommandArgument='<%# Eval("Attachment_Name")%>'
                                                CommandName="Download" ImageAlign="Left" ImageUrl="~/Images/download.gif" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="DimGray" HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    Currently There Is No Attachment Please Add One Or More Attachment.
                                </EmptyDataTemplate>
                                <PagerSettings Visible="False" />
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />
                            <asp:Button ID="btnMail" runat="server" Text="Mail" OnClientClick="javascript:return OpenWMail('gvAttachmentDetails','Workers_Comp');" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="divbtn" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td align="center">
                        <asp:Button ID="btnsave" CausesValidation="true" runat="server" ValidationGroup="vsErrorGroup"
                            OnClientClick="javascript:ValSave();" Text="Save & View" OnClick="btnsave_Click" />
                        <asp:Button ID="btnNextStep" runat="server" Text="Next Step" OnClientClick="javascript:ValSave();"
                            ValidationGroup="vsErrorGroup" Width="98px" OnClick="btnNextStep_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="ViewDiv" style="width: 100%; display: none;" runat="server">
            <table id="Table3" runat="server" cellpadding="2" cellspacing="2" class="stylesheet"
                width="100%">
                <tr>
                    <td class="ghc" colspan="6">
                        <asp:Label ID="lblvClaimId" runat="server">Claim Identification 
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc" id="Td1" style="width: 20%;">
                        <asp:Label ID="lblvClaimNumber" runat="server">Claim Number</asp:Label>
                    </td>
                    <td align="center" class="ic">
                        <asp:Label ID="lblvsep" runat="server">:</asp:Label>
                    </td>
                    <td align="left" class="ic" style="width: 25%">
                        <asp:Label ID="lblvclaimnoedit" runat="server"></asp:Label>
                    </td>
                    <%--<td align="left" class="lc" style="width: 22%">
                            <asp:Label ID="lblvReptoCarrier" runat="server">  Reported to Carrier</asp:Label>
                        </td>
                        <td align="center" class="ic">
                            :
                        </td>
                        <td align="left" class="lc" style="width: 25%">
                           <asp:Label ID="lblvwReptoCarrier" runat="server" >
                              
                            </asp:Label>
                        </td>--%>
                </tr>
                <tr>
                    <td align="left" class="lc" style="width: 20%">
                        <asp:Label ID="lblvStatus" runat="server">Status</asp:Label>
                    </td>
                    <td align="Center" class="lc">
                        :
                    </td>
                    <td align="left" class="lc" style="width: 25%">
                        <asp:Label ID="lblvwStatus" runat="server">
                             
                        </asp:Label>
                    </td>
                    <td align="left" class="lc" style="width: 20%">
                        <asp:Label ID="lblvcarrierClaimNo" runat="server">Carrier Claim Number</asp:Label>
                    </td>
                    <td align="Center" class="lc">
                        :
                    </td>
                    <td align="left" class="ic">
                        <asp:Label ID="lblvwCarrierClaimno" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvLastName" runat="server">Employee Last Name</asp:Label>
                    </td>
                    <td align="Center" class="lc">
                        :
                    </td>
                    <td align="left" class="ic">
                        <asp:Label ID="lblvwLastName" runat="server"></asp:Label>
                    </td>
                    <td align="left" class="lc" style="width: 22%">
                        <asp:Label ID="lblvDateReportedtoFair" runat="server">Date Reported to FairPoint </asp:Label>
                    </td>
                    <td align="center" class="ic">
                        :
                    </td>
                    <td align="left" class="lc" style="width: 25%">
                        <asp:Label ID="lblvwDateReportedtoFair" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvFirstName" runat="server">Employee First Name</asp:Label>
                    </td>
                    <td align="Center" class="lc">
                        :
                    </td>
                    <td align="left" class="ic">
                        <asp:Label ID="lblvwFirstName" runat="server"></asp:Label>
                    </td>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvDateClaimOpened" runat="server"> Date Claim Opened </asp:Label>
                    </td>
                    <td align="Center" class="lc">
                        :
                    </td>
                    <td align="left" class="ic">
                        <asp:Label ID="lblvwDateClaimOpened" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc" style="width: 20%">
                        <asp:Label ID="lblvUnion" runat="server">Union Member?</asp:Label>
                    </td>
                    <td align="Center" class="lc">
                        :
                    </td>
                    <td align="left" class="lc" style="width: 25%">
                        <asp:Label ID="lblvwUnion" runat="server">
                             
                                 
                        </asp:Label>
                    </td>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvDateClaimClosed" runat="server">Date Claim Closed</asp:Label>
                    </td>
                    <td align="Center" class="lc">
                        :
                    </td>
                    <td align="left" class="ic">
                        <asp:Label ID="lblvwDateClaimClosed" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvDateofLoss" runat="server">Date of Loss </asp:Label>
                    </td>
                    <td align="Center" class="lc">
                        :
                    </td>
                    <td align="left" class="ic">
                        <asp:Label ID="lblvwDateofLoss" runat="server"></asp:Label>
                    </td>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvDateClaimReopened" runat="server">Date Claim Reopened</asp:Label>
                    </td>
                    <td align="Center" class="lc">
                        :
                    </td>
                    <td align="left" class="ic">
                        <asp:Label ID="lblvwDateClaimReopened" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc" style="width: 25%;">
                        <asp:Label ID="lblvEntity" runat="server"> Entity  </asp:Label>
                    </td>
                    <td align="Center" class="lc">
                        :
                    </td>
                    <td align="left" class="ic" style="width: 75%;" colspan="5">
                        <asp:Label ID="lblvwEntity" runat="server" Width="552px">
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc" style="width: 20%;">
                        <asp:Label ID="lblvBenefitState" runat="server"> Benefit State  </asp:Label>
                    </td>
                    <td align="Center" class="ic">
                        :
                    </td>
                    <td align="left" class="ic">
                        <asp:Label ID="lblvwBenefitState" runat="server">
                        </asp:Label>
                    </td>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvDateReportedtoCarrier" runat="server"> Date Reported to Carrier </asp:Label>
                        <%-- --%>
                    </td>
                    <td align="Center" class="lc">
                        :
                    </td>
                    <td align="left" class="ic">
                        <asp:Label ID="lblvwDateReportedtoCarrier" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="ic">
                        <asp:Label ID="lblvCompRate" runat="server">Comp Rate</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label ID="lblvwCompRate" runat="server"></asp:Label>
                    </td>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvCarrierName" runat="server">Carrier Name</asp:Label>
                    </td>
                    <td align="Center" class="lc">
                        :
                    </td>
                    <td align="left" class="ic">
                        <asp:Label ID="lblvwCarrierName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvLastDate" runat="server">Last Date of Work</asp:Label>
                    </td>
                    <td align="Center" class="lc">
                        :
                    </td>
                    <td align="left" class="ic">
                        <asp:Label ID="lblvwlastDate" runat="server"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label ID="lblvTPAName" runat="server">TPA Name</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label ID="lblvwTPAName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvDateRTW" runat="server">Date RTW</asp:Label>
                    </td>
                    <td align="Center" class="lc">
                        :
                    </td>
                    <td align="left" class="ic">
                        <asp:Label ID="lblvwDateRTW" runat="server"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label ID="lblvPolicyNo" runat="server">Policy Number</asp:Label>
                    </td>
                    <td align="center" class="ic">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label ID="lblvwPolicyNo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label ID="lblvTimeofLoss" runat="server">Time of Loss (HH:MM)</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label ID="lblvwTimeofLoss" runat="server"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label ID="lblvPolicyEffecDate" runat="server">Policy Effective Date</asp:Label>
                    </td>
                    <td align="center" class="ic">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label ID="lblvwPolicyEffecDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvTransitional" runat="server">Transitional Duty?</asp:Label>
                    </td>
                    <td align="center" class="ic">
                        :
                    </td>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvwTransitional" runat="server">
                            
                               
                        </asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label ID="lblvPolicyExpDate" runat="server">Policy Expiration Date</asp:Label>
                    </td>
                    <td align="center" class="ic">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label ID="lblvwPolicyExpDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvTransDutyRefused" runat="server">Transitional Duty Refused?</asp:Label>
                    </td>
                    <td align="center" class="ic">
                        :
                    </td>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvwTransDutyRefused" runat="server">
                                                          
                        </asp:Label>
                    </td>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvTypeofClaim" runat="server">Type of Claim</asp:Label>
                    </td>
                    <td align="center" class="ic">
                        :
                    </td>
                    <td align="left" class="ic">
                        <asp:Label ID="lblvwTypeofClaim" runat="server">
                              
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvinjuryCode" runat="server">Injury Code</asp:Label>
                    </td>
                    <td align="center" class="ic">
                        :
                    </td>
                    <td align="left" class="ic" colspan="4">
                        <asp:Label ID="lblvwinjuryCode" runat="server" Width="552px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvCauseCode" runat="server">Cause Code</asp:Label>
                    </td>
                    <td align="center" class="lc">
                        :
                    </td>
                    <td align="left" class="ic" colspan="4">
                        <asp:Label ID="lblvwCauseCode" runat="server" Width="552px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvBodyParts" runat="server">Body Parts</asp:Label>
                    </td>
                    <td align="center" class="lc">
                        :
                    </td>
                    <td align="left" class="ic" colspan="4">
                        <asp:Label ID="lblvwBodyParts" runat="server" Width="552px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" class="lc" style="width: 20%">
                        <asp:Label ID="lblvDescOfAcc" runat="server">Description of Accident 
                            

                        </asp:Label>
                    </td>
                    <td align="center" valign="top" class="ic">
                        :
                    </td>
                    <td class="ic" colspan="4">
                        <asp:Label ID="lblvwDescOfAcc" runat="server" Width="95%"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvFatality" runat="server">Fatality?</asp:Label>
                    </td>
                    <td align="center" class="ic">
                        :
                    </td>
                    <td align="left" class="ic">
                        <asp:Label ID="lblvwFatality" runat="server">
                               
                        </asp:Label>
                    </td>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvDOB" runat="server">Date of Birth</asp:Label>
                    </td>
                    <td align="Center" class="lc">
                        :
                    </td>
                    <td align="left" class="ic">
                        <asp:Label ID="lblvwDOB" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvDOH" runat="server">Date of Hire</asp:Label>
                    </td>
                    <td align="Center" class="lc">
                        :
                    </td>
                    <td align="left" class="ic">
                        <asp:Label ID="lblvwDOH" runat="server"></asp:Label>
                    </td>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvDoesClimant" runat="server">Does Claimant have legal representation?</asp:Label>
                    </td>
                    <td align="center" class="ic">
                        :
                    </td>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvwDoesClimant" runat="server">
                            
                               
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvAttorneyName" runat="server">Attorney Name</asp:Label>
                    </td>
                    <td align="center" class="ic">
                        :
                    </td>
                    <td>
                        <asp:Label ID="lblvwAttorneyName" runat="server" CssClass="lc"></asp:Label>
                    </td>
                    <td align="left" class="lc">
                        <asp:Label ID="lblvAttTelNo" runat="server">Attorney Telephone Number </asp:Label>
                    </td>
                    <td align="center" class="ic">
                        :
                    </td>
                    <td class="lc">
                        <asp:Label ID="lblvwAttTelNo" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <div id="viewdivnine" style="width: 100%; display: block;" runat="server">
                <table cellpadding="2" border="0" cellspacing="2" style="width: 100%;" class="stylesheet">
                    <tr>
                        <td class="ghc" align="left" colspan="5">
                            Financial Details
                        </td>
                    </tr>
                </table>
                <table id="tblvwFDetail" runat="server" cellpadding="2" border="0" cellspacing="2"
                    style="width: 100%;" class="stylesheet">
                    <tr>
                        <td align="center" class="lc">
                            &nbsp;</td>
                        <td class="lc" align="right" style="font-family: Verdana; color: black">
                            <b>Incurred $</b></td>
                        <td class="lc" align="right" style="font-family: Verdana; color: black">
                            <b>Paid $</b></td>
                        <td align="right" class="lc" style="font-family: Verdana; color: black">
                            <b>Outstanding $</b></td>
                        <td align="right" class="lc" runat="server" style="font-family: Verdana; color: black;
                            display: none;">
                            <b>Current Month $</b></td>
                        <td>
                            &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc" style="font-family: Verdana; color: black">
                            <b>Indemnity</b></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblvwIndemIncurred"></asp:Label></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblvwIndemPaid"></asp:Label></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblvwIndemOutStanding"></asp:Label></td>
                        <td align="right" class="lc" runat="server" style="display: none;">
                            <asp:Label runat="server" ID="lblvwIndemCurrentMonth"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" class="lc" style="font-family: Verdana; color: black">
                            <b>Medical </b>
                        </td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblvwMediIncured"></asp:Label></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblvwMediPaid"></asp:Label></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblvwMediOutStand"></asp:Label></td>
                        <td align="right" class="lc" runat="server" style="display: none;">
                            <asp:Label runat="server" ID="lblvwMediCurrentMonth"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" class="lc" style="font-family: Verdana; color: black">
                            <b>Expenses</b></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblvwExpIncurred"></asp:Label></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblvwExpIndemPaid"></asp:Label></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblvwExpOutStand"></asp:Label></td>
                        <td align="right" class="lc" runat="server" style="display: none;">
                            <asp:Label runat="server" ID="lblvwExpCurrentMonth"></asp:Label></td>
                    </tr>
                </table>
                <table id="tblvwFNoData" cellpadding="2" cellspacing="2" runat="server" style="width: 100%;
                    display: none;">
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="ic" align="center">
                            <a style="color: Gray">No Financial Details found for this claim. </a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </div>
            <div id="viewdivsecond" style="width: 100%;" runat="server">
                <table id="Table16" runat="server" cellpadding="2" cellspacing="2" class="stylesheet"
                    width="100%">
                    <tr>
                        <td class="ghc" colspan="6">
                            <asp:Label ID="lblvwClaimRepresent" runat="server">Claim Representative 
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label ID="lblvwFairPoint" runat="server"><strong> FairPoint</strong></asp:Label>
                        </td>
                        <td align="center" class="ic">
                        </td>
                        <td align="left" class="ic">
                        </td>
                        <td align="left" class="ic">
                        </td>
                        <td align="center" class="ic">
                        </td>
                        <td align="left" class="ic">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc" style="width: 25%;">
                            <asp:Label ID="lblvwname" runat="server">Name</asp:Label>
                        </td>
                        <td align="center" class="ic">
                            :
                        </td>
                        <td align="left" class="ic" style="width: 25%">
                            <asp:Label ID="lblvwename" runat="server"></asp:Label>
                        </td>
                        <td align="left" class="lc" style="width: 22%">
                            <asp:Label ID="lblvwTelephone" runat="server">Telephone</asp:Label>
                        </td>
                        <td align="center" class="ic">
                            :
                        </td>
                        <td align="left" class="ic" style="width: 25%">
                            <asp:Label ID="lblvweTelephone" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label ID="lblvwEMail" runat="server">E-Mail</asp:Label>
                        </td>
                        <td align="center" class="ic">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label ID="lblvweEMail" runat="server"></asp:Label>
                        </td>
                        <td align="left" class="ic" style="width: 20%">
                        </td>
                        <td align="center" class="ic">
                        </td>
                        <td align="left" class="ic" style="width: 22%">
                        </td>
                    </tr>
                </table>
                <table id="Table23" runat="server" cellpadding="2" cellspacing="2" class="stylesheet"
                    width="100%">
                    <tr>
                        <td class="ic" colspan="6">
                            <asp:Label ID="Label9" runat="server"><strong>Other Party</strong>                        </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc" style="width: 25%">
                            <asp:Label ID="lblvwnameotherparty" runat="server">Name</asp:Label>
                        </td>
                        <td align="center" class="ic">
                            :
                        </td>
                        <td align="left" class="ic" style="width: 25%">
                            <asp:Label ID="lblvwenameotherparty" runat="server"></asp:Label>
                        </td>
                        <td align="left" class="lc" style="width: 22%">
                            <asp:Label ID="lblvwtelotherparty" runat="server">Telephone</asp:Label>
                        </td>
                        <td align="center" class="ic">
                            :
                        </td>
                        <td align="left" class="ic" style="width: 25%">
                            <asp:Label ID="lblvwetelotherparty" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label ID="lblvwEmailotherparty" runat="server">E-Mail</asp:Label>
                            <%--<span class="mf">*</span>--%>
                        </td>
                        <td align="center" class="ic">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label ID="lblvweEmailotherparty" runat="server"></asp:Label>
                        </td>
                        <td align="left" class="ic">
                        </td>
                        <td align="center" class="ic">
                        </td>
                        <td align="left" class="ic">
                        </td>
                    </tr>
                </table>
            </div>
            <div style="width: 100%">
                <table width="100%">
                    <tr>
                        <td colspan="2">
                            <table cellspacing="1" style="background-color: #7f7f7f; color: White; font-weight: Bolder;
                                font-family: Tahoma; font-size: 10pt;" width="100%">
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
                            <asp:GridView ID="gvAttachView" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="false" DataKeyNames="PK_Attachment_ID" OnRowDataBound="gvAttachView_RowDataBound"
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <input name="chkItem" onclick="javascript:ErimsUnChekcHeader()" type="checkbox" value='<%# Eval("PK_Attachment_ID")%>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" />
                                        <HeaderTemplate>
                                            <input name="chkHeader" onclick="javascript:setCheck(aspnetForm,this.checked)" type="checkbox" />
                                        </HeaderTemplate>
                                        <HeaderStyle Width="10px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" Visible="false" />
                                    <asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description" />
                                    <asp:BoundField DataField="Attachment_Name1" HeaderText="File Name" />
                                    <asp:TemplateField HeaderText="View">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnDwnld" runat="server" CommandArgument='<%# Eval("Attachment_Name")%>'
                                                CommandName="Download" ImageAlign="Left" ImageUrl="~/Images/download.gif" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="DimGray" HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    Currently there is no attachment Please add one or more attachment.
                                </EmptyDataTemplate>
                                <PagerSettings Visible="False" />
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 19px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="6">
                            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Next Step"
                                CausesValidation="False" />
                            <asp:Button ID="btnViewBack" runat="server" Visible="false" OnClick="btnViewBack_Click"
                                Text="Back" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="dispTagName" runat="server" />
    <asp:HiddenField ID="hdnAttachmentChkBox" runat="server" />

    <script type="text/javascript">

        var tagDisplay = document.getElementById("ctl00_ContentPlaceHolder1_dispTagName").value;
       
        if(tagDisplay !="")
        {  
                document.getElementById("Four").className="left_menu_active";
                document.getElementById("first").className="left_menu";
                document.getElementById("second").className="left_menu";
                              
                document.getElementById("third").className="left_menu";  
              
      
        }        
                  
    </script>

</asp:Content>
