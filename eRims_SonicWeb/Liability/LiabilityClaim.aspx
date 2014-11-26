<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="LiabilityClaim.aspx.cs"
    Inherits="Liability_LiabilityClaim" Theme="default"  
    Title="Risk Management Insurance System" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>
    
    <script type="text/javascript">  
    
     function ZipValidate(x)
    {
     
     var y=document.getElementById(x).value;
     if(y.length < 5 && y.length > 0)
         {
             alert("Invalid Zip Code");
             document.getElementById(x).select();           
         }
        
    }
    
    
    function phoneValidate(x)
    {
     
     var y=document.getElementById(x).value;
     if(y.length < 14 && y.length > 0)
         {
             alert("Invalid No");
             document.getElementById(x).select();           
         }
        
    }
				
		
	function OnPrBlur(objid)
	{
		var phone=document.getElementById('hidPhoneno');
		if(objid.value!= "")
		  phone.value = objid.value;
		 objid.value = phone.value;
		return false;
	}
	    
	// Function to display xxx      
	function OnRPhoneFocus(objid)
	{
		var str = objid.value;
		var phone=document.getElementById('hidPhoneno');
		phone.value="(xxx)-xxx-xxxx";
			if(str.substring(0,5) == "(xxx)")
			    objid.value = "";	 
    			return true;
	}
	
	
//Function to verify numeric value in textbox
      function CheckNum(txtnum)
     {
        
      var txt = document.getElementById(txtnum);
//         var pattern =/[0-9]/;
//         var keyCode = event.keyCode? event.keyCode : event.which;
//			var key = String.fromCharCode(keyCode);
//			if(!pattern.test(key))
//			{
//				event.keyCode="";
//				return false;
//			}
        
        
        
        if((event.keyCode <= 47) || (event.keyCode > 58)|| (event.keyCode == 58))
        {
             if(event.keyCode != 46)
             {
                event.cancelBubble = true;
                event.returnValue = false;
             }
        }
        
      
        
        
    }




function PhoneMasking(e,str,textbox)
	{
	
	  
	
		if(!((e.keyCode > 47 && e.keyCode < 58)||(e.keyCode > 95 && e.keyCode < 106)))
		{
			str = str.substring(0,str.length);
			textbox.value = str;
		}
		else
		{
			if(str.length ==1 && e.keyCode != 8)
			str= "("+str;
			if(str.length == 4)
			{
				if(e.keyCode != 8)
				str = str+")"+"-";
			}
			if(str.length == 9 && e.keyCode != 8)
			{	
				str = str+"-";
			}
			if(str.charAt(4) != ")" && str.charAt(4) != "")
			{
				str = str.substring(0,4)+")"+str.substring(4,str.length); 
			}
			if(str.charAt(5) != "-" && str.charAt(5) != "")
			{
				str = str.substring(0,5)+"-"+str.substring(5,str.length); 
			}
			if(str.charAt(9) != "-" && str.charAt(9) != "")
			{
				str = str.substring(0,9)+"-"+str.substring(9,str.length); 
			}
			str = str.substring(0,14);
			if(str.charAt(0) != "(" && e.keyCode != 8)
			str = "("+str.substring(1,14);
			textbox.value = str;
		
		
			
			
		}
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
    
     
    
    
        function Reqenabletrue()
       { 
       
            document.getElementById("ctl00_ContentPlaceHolder1_Reqmake").enabled =true;
            document.getElementById("ctl00_ContentPlaceHolder1_Reqmodel").enabled =true;
            document.getElementById("ctl00_ContentPlaceHolder1_Reqyearofmenu").enabled =true;
            document.getElementById("ctl00_ContentPlaceHolder1_Reqidentino").enabled =true;
            return true;
       }
     
       function Reqenablefalse()
       { 
            
            document.getElementById("ctl00_ContentPlaceHolder1_Reqmake").enabled =false;
            document.getElementById("ctl00_ContentPlaceHolder1_Reqmodel").enabled =false;
            document.getElementById("ctl00_ContentPlaceHolder1_Reqyearofmenu").enabled =false;
            document.getElementById("ctl00_ContentPlaceHolder1_Reqidentino").enabled =false;
            return true;
       }
     
         function ValAttach()
        {      
            document.getElementById("ctl00_ContentPlaceHolder1_rfvattach").enabled =true;
            document.getElementById("ctl00_ContentPlaceHolder1_rvfselect").enabled =true;
            return true;
        }
        function ValSave()
        {            
            document.getElementById("ctl00_ContentPlaceHolder1_rfvattach").enabled =false;
            document.getElementById("ctl00_ContentPlaceHolder1_rvfselect").enabled =false;
            return true;
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
        document.getElementById("ctl00_ContentPlaceHolder1_dvAttachDetails").style.display ="none";
    }
      function getfive()
    {
        clearfocus();
        document.getElementById("five").className="left_menu_active"; 
        document.getElementById("ctl00_ContentPlaceHolder1_divfive").style.display ="block";
       document.getElementById("ctl00_ContentPlaceHolder1_dvAttachDetails").style.display ="none";
    }
         
     function getsix()
    {
        clearfocus();
        document.getElementById("six").className="left_menu_active"; 
        document.getElementById("ctl00_ContentPlaceHolder1_divsix").style.display ="block";
        document.getElementById("ctl00_ContentPlaceHolder1_dvAttachDetails").style.display ="none";
    }
    
       function getseven()
    {
        clearfocus();
        document.getElementById("seven").className="left_menu_active"; 
        document.getElementById("ctl00_ContentPlaceHolder1_divseven").style.display ="block";
        document.getElementById("ctl00_ContentPlaceHolder1_dvAttachDetails").style.display ="none";
    }
    
       function geteight()
    {
        clearfocus();
        document.getElementById("eight").className="left_menu_active"; 
        document.getElementById("ctl00_ContentPlaceHolder1_diveight").style.display ="block";
        document.getElementById("ctl00_ContentPlaceHolder1_dvAttachDetails").style.display ="none";
    }
    
       function getnine()
    {
        clearfocus();
        document.getElementById("nine").className="left_menu_active"; 
        document.getElementById("ctl00_ContentPlaceHolder1_divnine").style.display ="block";
        document.getElementById("ctl00_ContentPlaceHolder1_dvAttachDetails").style.display ="none";
    }
    
         function getten()
    {
        clearfocus();
        document.getElementById("ten").className="left_menu_active"; 
        document.getElementById("ctl00_ContentPlaceHolder1_divten").style.display ="block";
        document.getElementById("ctl00_ContentPlaceHolder1_dvAttachDetails").style.display ="block";
    }
    
    function clearfocus()
    {
    

        document.getElementById("first").className="left_menu";   
        document.getElementById("second").className="left_menu"; 
        document.getElementById("third").className="left_menu";  
        document.getElementById("four").className="left_menu";     
        document.getElementById("five").className="left_menu";     
        document.getElementById("six").className="left_menu";  
        document.getElementById("seven").className="left_menu";     
        document.getElementById("eight").className="left_menu";     
        document.getElementById("nine").className="left_menu";   
        document.getElementById("ten").className="left_menu";   
           
                
        document.getElementById("ctl00_ContentPlaceHolder1_divfirst").style.display ="none";  
        document.getElementById("ctl00_ContentPlaceHolder1_divsecond").style.display ="none";  
        document.getElementById("ctl00_ContentPlaceHolder1_divthird").style.display ="none";   
        document.getElementById("ctl00_ContentPlaceHolder1_divfour").style.display ="none";   
        document.getElementById("ctl00_ContentPlaceHolder1_divfive").style.display ="none";   
        document.getElementById("ctl00_ContentPlaceHolder1_divsix").style.display ="none";   
        document.getElementById("ctl00_ContentPlaceHolder1_divseven").style.display ="none";   
        document.getElementById("ctl00_ContentPlaceHolder1_diveight").style.display ="none";   
        document.getElementById("ctl00_ContentPlaceHolder1_divnine").style.display ="none"; 
        document.getElementById("ctl00_ContentPlaceHolder1_divten").style.display ="none";  
        //document.getElementById("ViewDiv").style.display ="none"; 
        //document.getElementById("ctl00_ContentPlaceHolder1_dvAttachDetails").style.display ="none";  
      }
         function openClaimantWindow1()
        {
            oWnd=window.open("Claimant_search.aspx","Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            oWnd.moveTo(300,200);
          // OnClientClick="javascript:return openClaimantWindow1();" 
            return false;
        }  
        
        
        
         function openPropertyWindow()
        {
          
            oWnd=window.open("Property_Search.aspx","Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            oWnd.moveTo(300,200);
            return false;
           // OnClientClick="javascript:return openPropertyWindow();" 
        }  
        
         function openEmployeeWindow()
        {
          
            oWnd=window.open("../WorkerCompensation/Employee_Search_Popup.aspx?Page=LiabilityEmp","Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            oWnd.moveTo(300,200);
            return false;
         
        }  
      
        function openAssignEmployeeWindow()
        {
          
            oWnd=window.open("../WorkerCompensation/Employee_Search_Popup.aspx?Page=LiabilityAssignEmp","Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            oWnd.moveTo(300,200);
            return false;
         
        }  
      
       function openCostCenterWindow()
        {
       
            oWnd=window.open("../WorkerCompensation/CostCenter_Popup.aspx?Page=liabilitycost","Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            oWnd.moveTo(300,200);
            return false;
         
        }  
        
         function openpolicyWindow()
        {
           
            oWnd=window.open("Policy_search_popup.aspx","Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            oWnd.moveTo(300,200);
            return false;
        // OnClientClick="javascript:return openCostCenterWindow();" 
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
     
<asp:ScriptManager runat="server" id="ScriptManager1">
    </asp:ScriptManager>
   
     <div>
     <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="false"
            ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
    </div>
  
        <div style="width: 100%" id="contmain" >
      <br />
      
        <div id="Div1" runat="server" style="width: 100%; text-align: center">
            <table border="0" cellpadding="1" cellspacing="0" width="99%">
                <tr>
                    <td align="center" style="background-image: url('../images/active_btn.jpg')" class="active_tab"
                        valign="middle">
                        Liability Claim</td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="ReserveWorksheetHistoryGrid.aspx">Reserve Worksheet</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                       <a class="main_menu" href="Subrogation.aspx"> Carrier Data</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="Subrogation.aspx">Subrogation</a>
                    </td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="subrogationDetails.aspx">Subrogation Detail</a>
                    </td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="CheckRegister.aspx">Check Register</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="Diary.aspx">Diary</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="Adjuster.aspx">Adjustor Notes</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="Settlement.aspx">Settlement</a></td>
                </tr>
            </table>
        </div>
        <%-- <asp:ValidationSummary ID="ReqfldGroup" runat="server" ShowMessageBox="True" ShowSummary="False" />--%>
         <div id="Automobile" runat="server" style="width: 20%; height: 350px; border: solid 1px;
            float: left;">
            <table border="0" cellpadding="0" cellspacing="4" width="90%">
                <tr>
                    <td style="width: 15%; height: 19px">
                        &nbsp;</td>
                    <td style="width: 85%; height: 19px">
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu_active" id="first1" onclick="javascript:getfirst();" href="#">Claim ID</a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="second1" onclick="javascript:getsecond();" href="#">Owner</a></td>
                </tr>
                
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="third1" onclick="javascript:getthird();" href="#">Claim Detail</a></td>
                </tr>
                
                   <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="A4" onclick="javascript:geteight();" href="#">Auto Liability Specifics</a></td>
                </tr>
                    <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="nine1" onclick="javascript:getnine();" href="#">Legal</a></td>
                </tr>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="ten1" onclick="javascript:getten();" href="#">Attachment</a></td>
                </tr>
                
                
        </table>
        </div>
       
         <div id="General" runat="server" style="width: 20%; height: 350px; border: solid 1px;
            float: left;">
            <table border="0" cellpadding="0" cellspacing="4" width="90%">
                <tr>
                    <td style="width: 15%; height: 19px">
                        &nbsp;</td>
                    <td style="width: 85%; height: 19px">
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu_active" id="A1"  onclick="javascript:getfirst();" href="#">Claim ID</a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="A2" onclick="javascript:getsecond();" href="#">Owner</a></td>
                </tr>
                
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="A3" onclick="javascript:getthird();" href="#">Claim Detail</a></td>
                </tr>
             
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="A5" onclick="javascript:getnine();" href="#">Legal</a></td>
                </tr>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="A6" onclick="javascript:getten();" href="#">Attachment</a></td>
                </tr>
                
                
        </table>
        </div>
             
         <div id="Property" runat="server" style="width: 20%; height: 350px; border: solid 1px;
            float: left;">
            <table border="0" cellpadding="0" cellspacing="4" width="90%">
                <tr>
                    <td style="width: 15%; height: 19px">
                        &nbsp;</td>
                    <td style="width: 85%; height: 19px">
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu_active" id="A7" onclick="javascript:getfirst();" href="#">Claim ID</a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="A8" onclick="javascript:getsecond();" href="#">Owner</a></td>
                </tr>
                
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="A9" onclick="javascript:getthird();" href="#">Claim Detail</a></td>
                </tr>
             <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="A12" onclick="javascript:getfour();" href="#">Property Loss</a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="A13" onclick="javascript:getfive();" href="#">Replacement Values</a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="A14" onclick="javascript:getsix();"href="#">Property Loss Percent Damage Breakdown</a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu"id="A15" onclick="javascript:getseven();" href="#">Police Report</a></td>
                </tr>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="A10" onclick="javascript:getnine();" href="#">Legal</a></td>
                </tr>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="A11" onclick="javascript:getten();" href="#">Attachment</a></td>
                </tr>
                
                
        </table>
        </div>
              
      <div id="leftDiv" runat="server" style="width: 20%; height: 350px; border: solid 1px;
            float: left;">
            <table border="0" cellpadding="0" cellspacing="4" width="90%">
                <tr>
                    <td style="width: 15%; height: 19px">
                        &nbsp;</td>
                    <td style="width: 85%; height: 19px">
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu_active" id="first" onclick="javascript:getfirst();" href="#">Claim ID</a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="second" onclick="javascript:getsecond();" href="#">Owner</a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="third" onclick="javascript:getthird();" href="#">Claim Detail</a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="four" onclick="javascript:getfour();" href="#">Property Loss</a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="five" onclick="javascript:getfive();" href="#">Replacement Values</a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="six" onclick="javascript:getsix();"href="#">Property Loss Percent Damage Breakdown</a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu"id="seven" onclick="javascript:getseven();" href="#">Police Report</a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="eight" onclick="javascript:geteight();" href="#">Auto Liability Specifics</a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="nine" onclick="javascript:getnine();" href="#">Legal</a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="ten" onclick="javascript:getten();" href="#">Attachment</a></td>
                </tr>
            </table>
        </div>
        <div id="mainContent" runat="server" style="width: 79%; border: solid 1px; float: right;">
            <div id="divfirst" style="width: 100%; display: block;" runat="server">
                <table id="Table1" runat="server" cellpadding="0" cellspacing="4" class="stylesheet"
                    width="100%">
                    <tr>
                        <td class="ghc" colspan="6">
                            Claim ID</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                     <td align="left" class="lc">
                             &nbsp
                        </td>
                        <td align="Center" class="lc">
                           &nbsp
                        </td>
                           <td align="left" class="ic">
                       <asp:TextBox ID="txtclaimantid" runat="server" style="display:none;" ></asp:TextBox>
                        </td>
                     <%--   <td align="left" class="lc">
                         Employee
                        </td>
                        <td align="left" class="ic">
                         :
                        </td>
                        <td align="left" class="lc">
                         <asp:RadioButtonList ID="rbtntemployee" AutoPostBack ="true" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbtntemployee_SelectedIndexChanged">
                                <asp:ListItem  Selected ="True" >Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>--%>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            Last Name&nbsp;<span class="mf">*</span>
                        </td>
                        <td align="Center" class="lc" style="height: 25px">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:TextBox ID="txtlastname" runat="server"></asp:TextBox>
                            <asp:Button ID="Button1" runat="server" Text=">>" CausesValidation="false"/>
                            <asp:RequiredFieldValidator ID="Req1" runat="server" ControlToValidate="txtlastname"
                                Display="None" ErrorMessage="Please enter Last Name" ValidationGroup="vsErrorGroup" ></asp:RequiredFieldValidator>
                        </td>
                        
                        
                            <td align="left" class="lc">
                         Employee
                        </td>
                        <td align="left" class="ic">
                         :
                        </td>
                        <td align="left" class="lc">
                         <asp:RadioButtonList ID="rbtntemployee" AutoPostBack ="true" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbtntemployee_SelectedIndexChanged">
                                <asp:ListItem  Selected ="True" >Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        
                        
                        
                     
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            Middle Name
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                             <asp:TextBox ID="txtmiddlename" runat="server"></asp:TextBox>
                        </td>
                       
                          <td align="left" class="lc">
                            First Name&nbsp; <span class="mf">*</span>
                        </td>
                        <td align="Center" class="lc" style="height: 25px">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:TextBox ID="txtfirstname" runat="server"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="Req2" runat="server" ControlToValidate="txtfirstname"
                                Display="None" ErrorMessage="Please enter First Name" ValidationGroup="vsErrorGroup" ></asp:RequiredFieldValidator>
                        </td>
                       
                     
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            Cost Center&nbsp;<span class="mf">*</span>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:TextBox ID="txtcosecenter" runat="server"></asp:TextBox>
                            <asp:Button ID="Button2" runat="server" Text=">>" CausesValidation="False" OnClientClick="javascript:return openCostCenterWindow();"  />
                            <asp:RequiredFieldValidator ID="Req3" runat="server" ControlToValidate="txtcosecenter"
                                Display="None" ErrorMessage="Please enter Cost Cente" ValidationGroup="vsErrorGroup" ></asp:RequiredFieldValidator>
                        </td>
                        <td align="left" class="lc">
                           Branch Name
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                           <asp:TextBox ID="txtbranchname" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td><asp:TextBox ID="txtidclaimant" runat="server"  style="display:none;"  ></asp:TextBox></td>
                    </tr>
                </table>
            </div>
            
            <div style="width: 100% ; display: none;" id="divsecond" runat="server" >
                <table border="0" cellpadding="0" cellspacing="4" width="90%" >
                    <tr>
                        <td class="ghc" colspan="6">
                            Owner
                        </td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Owner
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtowner" runat="server" MaxLength = "50"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Address Line 1<span class = "mf">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtAddLine1" runat="server" MaxLength = "50"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="Req4" runat="server" ControlToValidate="txtAddLine1"
                                Display="None" ErrorMessage="Please enter Address Line 1" ValidationGroup="vsErrorGroup" ></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Address Line 2
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtAddLine2" runat="server" MaxLength = "50"></asp:TextBox>
                        </td>
                        <td class="lc">
                            City<span class = "mf">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtcity" runat="server" MaxLength = "30"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="Req5" runat="server" ControlToValidate="txtcity"
                                Display="None" ErrorMessage="Please enter City" ValidationGroup="vsErrorGroup" ></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            State<span class = "mf">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:DropDownList ID = "dwstateowner" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="Requstate" runat="server" ControlToValidate="dwstateowner"
                                Display="None" ErrorMessage="Please select State"  InitialValue="0" ValidationGroup="vsErrorGroup" ></asp:RequiredFieldValidator>
                                
                        </td>
                        <td class="lc">
                            Zip Code<span class = "mf">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtzipcode" runat="server" MaxLength="5"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="Req6" runat="server" ControlToValidate="txtzipcode"
                                Display="None" ErrorMessage="Please enter Zip Code"  ValidationGroup="vsErrorGroup" ></asp:RequiredFieldValidator>
                                
                                
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Home Telephone Number<br />
                           
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txthomephone" runat="server" MaxLength = "14"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Work Telephone Number<br />
                          
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtworkphone" runat="server" MaxLength = "14"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </div>
            <div style="width: 100%;display: none;" id="divthird" runat="server">
                <table border="0" cellpadding="2" cellspacing="2" width="100%">
                    <tr>
                        <td class="ghc" colspan="6">
                            Claim Detail
                        </td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Description<span class = "mf">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtclaimDesc" runat="server"  MaxLength = "255" TextMode="MultiLine" Width="96%"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="Reqdesc" runat="server" ControlToValidate="txtclaimDesc"
                                Display="None" ErrorMessage="Please enter Description" CssClass="lc" ValidationGroup="vsErrorGroup" ></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" style ="width: 25%">
                            Nature of Incident
                        </td>
                        <td >
                            :
                        </td>
                        <td class="ic" >
                            <asp:DropDownList ID ="dwnaturofinc" runat = "server" style="width: 155px"></asp:DropDownList>   
                           
                        </td>
                        <td class="lc">
                            Estimate to Repair Damage ($)</td>
                        <td >
                            :
                        </td>
                        <td class="ic" >
                            <asp:TextBox ID="txtEstimatetorepair" runat="server" MaxLength="11" onKeyPress="return(currencyFormat(this,',','.',event))"> </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Actual Cost to Repair Damage ($)</td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtActualtorepair" runat="server" MaxLength="11"  onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                        </td>
                        
                        
                           <td class="lc" >
                            Injury Code
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:DropDownList ID ="dwinjury" runat = "server" style="width: 155px"></asp:DropDownList>   
                        </td>
                     
                                                              
                        
                      
                    </tr>
                    
                    
                    <tr>
                    <td class="lc">
                            Body Part(s) Affected
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic" colspan="4">
                        <asp:DropDownList ID ="dwbodyparts" runat = "server" style="width:96%"></asp:DropDownList>   
                          
                        </td>
                                                                 
                    </tr>
                         <tr>
                        <td class="lc">
                            Hazard Code
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic" colspan="4">
                        <asp:DropDownList ID ="dwHazardCode" runat = "server" style="width: 96%"></asp:DropDownList>   
                           
                        </td>
                    </tr>
                    
                    <tr>
                     <td class="lc">
                            NCCI Nature
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic" colspan="4">
                            <asp:DropDownList ID ="dwNCCInature" runat = "server" style="width: 96%"></asp:DropDownList>   
                        </td>
                    
                    </tr>
                    <tr>
                    
                     <td class="lc">
                            NCCI Code
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic" colspan="4">
                            <asp:DropDownList ID ="dwNCCIcode" runat = "server" style="width: 96%"></asp:DropDownList>   
                        </td>
                    </tr>
                    <tr>
                      <td class="lc">
                            Comprehensive Deductible<span class = "mf">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td colspan="4">
                         <asp:DropDownList ID ="dwComprehensiveDeductible" runat = "server" style="width: 96%"></asp:DropDownList>   
                         <asp:RequiredFieldValidator ID="Req12" runat="server" ControlToValidate="dwComprehensiveDeductible" InitialValue="0"
                                Display="None" ErrorMessage="Please select Comprehensive Deductible" ValidationGroup="vsErrorGroup" ></asp:RequiredFieldValidator> 
                           
                        </td>
                    
                    </tr>
                    <tr>
                         <td class="lc">
                            Road Surface
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:DropDownList ID ="dwroadsurface" runat = "server" style="width: 155px"></asp:DropDownList>   
                        </td>
                     
                       <td class="lc" >
                            Road Type
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:DropDownList ID ="dwroadtype" runat = "server" style="width: 155px"></asp:DropDownList>   
                        </td>
                     
                     
                     
                     
                     
                     
                    </tr>
                    <tr>
                       
                        <td class="lc">
                            Vocational Rehabilitation?
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:RadioButtonList ID="rbtnVocational" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                       
                       
                        <td class="lc" >
                            Product Name
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtproductname" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                    
                    </tr>
                    
                   
                    <tr>
                        <td class="lc">
                            Location Description
                        </td>
                        <td>
                            :
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtlocationdesc" runat="server"  MaxLength = "30" TextMode="MultiLine" Width="96%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                  
                    
                    </tr>
                    <tr>
                        
                        <td class="lc">
                            Collision Deductible<span class = "mf">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                          <asp:DropDownList ID ="dwCollisionDeductible" runat = "server" style="width: 155px"></asp:DropDownList>   
                          <asp:RequiredFieldValidator ID="Req9" runat="server" InitialValue="0" ControlToValidate="dwCollisionDeductible"
                                Display="None" ErrorMessage="Please select Collision Deductible" ValidationGroup="vsErrorGroup"   ></asp:RequiredFieldValidator>
                           
                        </td>
                       
                                             
                                        
                      <td class="lc" >
                            Cause<span class = "mf">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic"  >
                           <asp:DropDownList ID ="dwcause" runat = "server" style="width: 155px" ></asp:DropDownList>  
                             <asp:RequiredFieldValidator ID="Requ8" runat="server" ControlToValidate="dwcause" InitialValue="0"
                                Display="None" ErrorMessage="Please select Claim Cause" ValidationGroup="vsErrorGroup" ></asp:RequiredFieldValidator> 
                        </td>
                                                                   
                        
                    </tr>
                    <tr>
                        <td class="lc" >
                            Original Cost<span class = "mf">*</span>
                        </td>
                        <td >
                            :
                        </td>
                        <td >
                            <asp:DropDownList ID ="dwoiginalcost" runat = "server" style="width: 155px"></asp:DropDownList>   
                        </td>
                         <td class="lc">
                            Minor Claim Type<span class = "mf">*</span>
                        </td>
                        <td >
                            :
                        </td>
                        <td class="ic" >
                           <asp:DropDownList ID ="dwminor" runat = "server" style="width: 155px"></asp:DropDownList>   
                            <asp:RequiredFieldValidator ID="Requ10" runat="server" ControlToValidate="dwminor"
                                Display="None" ErrorMessage="Please select Minor Claim Type" InitialValue="0" ValidationGroup="vsErrorGroup" ></asp:RequiredFieldValidator> 
                        </td>
                    </tr>
                   <%-- <tr>
                        <td class="lc" >
                            Major Claim Type<span class = "mf">*</span>
                        </td>
                        <td >
                            :
                        </td>
                        <td >
                           <asp:DropDownList ID ="dwmajorclaim" runat = "server" style="width: 155px"></asp:DropDownList>  
                          
                        </td>
                       
                    </tr>--%>
                    <tr>
                        <td class="lc">
                            Claim Convertible?
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:RadioButtonList ID="rtnclaimconvert" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True">Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList></td>
                        <td class="lc">
                            Date of Incident <span class = "mf">*</span>
                        </td>
                        <td>
                            :
                        </td>
                                        <td class="ic">
                                            <asp:TextBox ID="txtdateofinc" runat="server"></asp:TextBox>
                                             <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtdateofinc', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                align="absmiddle" />
                            <cc1:MaskedEditExtender ID="Mask5" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" TargetControlID="txtdateofinc" CultureName="en-US"
                                AutoComplete="true" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="MaskedEditValidator3" runat="server" ControlExtender="Mask5"
                                ControlToValidate="txtdateofinc" Display="Dynamic" IsValidEmpty="true" MaximumValue=""
                                InvalidValueMessage="Date is invalid" MaximumValueMessage="" MinimumValueMessage=""
                                TooltipMessage="" MinimumValue="" ValidationGroup="vsErrorGroup">
                            </cc1:MaskedEditValidator></td>
                            
                                   <asp:RegularExpressionValidator id="revIDONoteEntry" runat="server" ControlToValidate="txtdateofinc"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                            ErrorMessage="Date Not Valid(Date of Incident)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="rfIncDate" runat="server" ControlToValidate="txtdateofinc"
                                Display="None" ErrorMessage="Please enter Date of Incident" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator></tr>
                    <tr>
                        <td class="lc">
                            Fraudulent Claim Indicator
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                         <asp:DropDownList ID ="dwFraudClaim" runat = "server" style="width: 155px"></asp:DropDownList>   
                           
                        </td>
                        <td class="lc" >
                            Date Incident Reported<span class = "mf">*</span>
                        </td>
                        <td>
                            :
                        </td>
                       
                                        <td class="ic">
                                            <asp:TextBox ID="txtincreported" runat="server"></asp:TextBox>
                                              <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtincreported', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                align="absmiddle" />
                            <cc1:MaskedEditExtender ID="Mask1" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" TargetControlID="txtincreported" CultureName="en-US"
                                AutoComplete="true" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="MaskedEditValidator6" runat="server" ControlExtender="Mask1"
                                ControlToValidate="txtincreported" Display="none" IsValidEmpty="true" MaximumValue=""
                                InvalidValueMessage="Date is invalid" MaximumValueMessage="" MinimumValueMessage=""
                                TooltipMessage="" MinimumValue="" ValidationGroup="vsErrorGroup">
                            </cc1:MaskedEditValidator>
                            <asp:RequiredFieldValidator ID="Req13" runat="server" ControlToValidate="txtincreported" 
                                Display="None" ErrorMessage="Please enter Date Incident Reported" ValidationGroup="vsErrorGroup" ></asp:RequiredFieldValidator> 
                           
                           
                                   <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ControlToValidate="txtincreported"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                            ErrorMessage="Date Not Valid(Date Incident Reported)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                 
                           
                           
                            </td>
                                        
                                 
                    </tr>
                    <tr>
                        <td class="lc">
                            Date Claim Opened<span class = "mf">*</span>
                        </td>
                        <td>
                            :
                        </td>
                                <td class="ic">
                                 <asp:TextBox ID="txtclaimopen" runat="server"></asp:TextBox>
                                 <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtclaimopen', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                align="absmiddle" />
                            <cc1:MaskedEditExtender ID="Mask2" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" TargetControlID="txtclaimopen" CultureName="en-US"
                                AutoComplete="true" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="Mask2"
                                ControlToValidate="txtclaimopen" Display="none" IsValidEmpty="true" MaximumValue=""
                                InvalidValueMessage="Date is invalid" MaximumValueMessage="" MinimumValueMessage=""
                                TooltipMessage="" MinimumValue="" ValidationGroup="vsErrorGroup">
                            </cc1:MaskedEditValidator>
                             <asp:RequiredFieldValidator ID="Req14" runat="server" ControlToValidate="txtclaimopen" 
                                Display="None" ErrorMessage="Please enter Date Claim Opened" ValidationGroup="vsErrorGroup" ></asp:RequiredFieldValidator> 
                           
                              <asp:CompareValidator ID="cvCompServiceDate" runat="server" ControlToValidate="txtclaimclosed"
                                   ValidationGroup="vsErrorGroup" ErrorMessage="Claim Closed Date Must Be Greater Than Claim Opened Date."
                                   Type="Date" Operator="GreaterThan" ControlToCompare="txtclaimopen" Display="none">
                                   </asp:CompareValidator>
                           
                                                  
                        
                           
                                   <asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ControlToValidate="txtclaimopen"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                            ErrorMessage="Date Not Valid(Date Claim Opened)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                 
                            </td>
                                       
                        <td class="lc">
                            Date Claim Closed<span class = "mf">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        
                                        <td class="ic">
                                            <asp:TextBox ID="txtclaimclosed" runat="server"></asp:TextBox>
                                             <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtclaimclosed', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                align="absmiddle" />
                            <cc1:MaskedEditExtender ID="Mask3" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" TargetControlID="txtclaimclosed" CultureName="en-US"
                                AutoComplete="true" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="Mask3"
                                ControlToValidate="txtclaimclosed" Display="none" IsValidEmpty="true" MaximumValue=""
                                InvalidValueMessage="Date is invalid" MaximumValueMessage="" MinimumValueMessage=""
                                TooltipMessage="" MinimumValue="" ValidationGroup="vsErrorGroup">
                            </cc1:MaskedEditValidator>
                            <asp:RequiredFieldValidator ID="Requ15" runat="server" ControlToValidate="txtclaimclosed" 
                                Display="None" ErrorMessage="Please enter Date Claim Closed" ValidationGroup="vsErrorGroup" ></asp:RequiredFieldValidator> 
                           
                                  <asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" ControlToValidate="txtclaimclosed"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                            ErrorMessage="Date Not Valid(Date Claim Closed)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                 
                             <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtdateclaimreported"
                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Claim ReOpened Date Must Be Greater Than Claim Closed Date."
                                                        Type="Date" Operator="GreaterThan" ControlToCompare="txtclaimclosed" Display="none">
                                                    </asp:CompareValidator>
                            </td>
                                        
                    </tr>
                    <tr>
                        <td class="lc">
                            Date Claim Reopened<span class = "mf">*</span>
                        </td>
                        <td>
                            :
                        </td>
                      
                                        <td class="ic">
                                            <asp:TextBox ID="txtdateclaimreported" runat="server"></asp:TextBox>
                                               <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtdateclaimreported', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                align="absmiddle" />
                            <cc1:MaskedEditExtender ID="Mask7" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" TargetControlID="txtdateclaimreported" CultureName="en-US"
                                AutoComplete="true" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="MaskedEditValidator4" runat="server" ControlExtender="Mask7"
                                ControlToValidate="txtdateclaimreported" Display="none" IsValidEmpty="true" MaximumValue=""
                                InvalidValueMessage="Date is invalid" MaximumValueMessage="" MinimumValueMessage=""
                                TooltipMessage="" MinimumValue="" ValidationGroup="vsErrorGroup">
                            </cc1:MaskedEditValidator>
                            <asp:RequiredFieldValidator ID="Req16" runat="server" ControlToValidate="txtdateclaimreported" 
                                Display="None" ErrorMessage="Please enter Date Claim Reopened" ValidationGroup="vsErrorGroup" ></asp:RequiredFieldValidator> 
                           
                           
                           
                                 <asp:RegularExpressionValidator id="RegularExpressionValidator4" runat="server" ControlToValidate="txtdateclaimreported"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                            ErrorMessage="Date Not Valid(Date Claim Reopened)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                 
                                        </td>
                                     
                        <td class="lc" >
                            Surgery Required?
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:RadioButtonList ID="rbtnsurgery" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Number of Weeks of Scheduled Indemnity
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtnoofweekssch" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                        <td class="lc" >
                            Jurisdiction State
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                           <asp:DropDownList ID ="dwjuridicationstate" runat = "server" style="width: 155px"></asp:DropDownList>   
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Assigned to (Last Name)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtassignlast" runat="server"></asp:TextBox>
                            <asp:Button ID="Button3" runat="server" Text=">>" OnClientClick="javascript:return openAssignEmployeeWindow();"  /></td>
                        <td class="lc">
                            Assigned to (First Name)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtassignfirst" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Assigned to (Middle Name)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtassignmiddle" runat="server"></asp:TextBox>
                        </td>
                        <td class="lc" >
                            Civil or Criminal Violation?
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:RadioButtonList ID="rbtncivilorcriminal" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                    <td></td>
                     <td> &nbsp</td>
                      <td><asp:TextBox ID = "txtassigntid" runat ="server"  style ="display:none;" ></asp:TextBox></td>
                       <td>&nbsp</td>
                        <td>&nbsp</td>
                         <td><asp:TextBox ID = "TextDate" runat ="server"  style ="display:none;" ></asp:TextBox></td>
                         
                    
                    </tr>
                </table>
            </div>
            <div style="width: 100% ;display: none;"  id="divfour" runat="server">
                <table border="0" cellpadding="0" cellspacing="4" width="100%">
                    <tr>
                        <td class="ghc" colspan="6">
                            Property Loss
                        </td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Property Name
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtproperty" runat="server"></asp:TextBox>
                            <asp:Button ID="btnproperty" runat="server"  OnClientClick="javascript:return openPropertyWindow();"  Text=">>" CausesValidation="False"  /></td>
                        <td class="lc">
                            Entity
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtentity" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" >
                            Address Line 1
                        </td>
                        <td >
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtadd1" runat="server"  ></asp:TextBox>
                        </td>
                        <td class="lc">
                            Address Line 2
                        </td>
                        <td >
                            :
                        </td>
                        <td class="ic" >
                            <asp:TextBox ID="txtadd2" runat="server" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            City
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtcityproperty" runat="server"></asp:TextBox>
                        </td>
                        <td class="lc">
                            State
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtstate" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Zip Code
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtzipproperty" runat="server" MaxLength="5"></asp:TextBox>
                        </td>
                        <td class="lc">
                            County
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtcounty" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Ownership
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtowenership" runat="server"></asp:TextBox>
                        </td>
                        <td class="lc">
                            What Flood Zone is the Property In?
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtwhatfood" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Number of Employees in Building
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtnoofemployee" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                        <asp:TextBox ID = "txtpropertyid" runat ="server" style ="display:none;"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </div>
            <div style="width: 100% ; display: none;" id="divfive" runat="server">
                <table border="0" cellpadding="0" cellspacing="4" width="100%">
                    <tr>
                        <td class="ghc" colspan="6">
                            Replacement Values
                        </td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Building ($)</td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtbuilding" runat="server"  onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Signs ($)</td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtSigns" runat="server"  onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Contents ($)</td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtcontents" runat="server"  onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Computers ($)</td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtcomputers" runat="server"  onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            ATMs ($)</td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtATMS" runat="server"  onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Lease Improvements ($)</td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtleaseimprovements" runat="server"  onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Total ($)</td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txttotel" runat="server"  onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                        </td>
                        <td class="lc">
                            
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtid" runat="server" Style="display:inline-block"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Description of Loss
                        </td>
                        <td>
                            :
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtdescloss" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Incident Type
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                        <asp:DropDownList ID ="dwWeatherIncident" runat="server" ></asp:DropDownList>
                            
                        </td>
                        <td class="lc">
                            Policy Number
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpolicyNo" runat="server"></asp:TextBox>
                            <asp:Button ID="Button5" runat="server" Text=">>"  OnClientClick="javascript:return openpolicyWindow();" CausesValidation="False"  /></td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Property Deductible ($)</td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpropertydeduct" runat="server"  onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Flood Deductible ($)</td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtfooddeduct" runat="server"  onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" >
                            Date Business Closed
                        </td>
                        <td >
                            :
                        </td>
                      
                                        <td class="ic">
                                            <asp:TextBox ID="txtdatebusiclosed" runat="server" ></asp:TextBox>
                                              <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtdatebusiclosed', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                align="absmiddle" />
                            <cc1:MaskedEditExtender ID="Maske8" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" TargetControlID="txtdatebusiclosed" CultureName="en-US"
                                AutoComplete="true" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="MaskedEditValidator5" runat="server" ControlExtender="Maske8"
                                ControlToValidate="txtdatebusiclosed" Display="dynamic" IsValidEmpty="true" MaximumValue=""
                                InvalidValueMessage="Date is invalid" MaximumValueMessage="" MinimumValueMessage=""
                                TooltipMessage="" MinimumValue="" ValidationGroup="vsErrorGroup">
                            </cc1:MaskedEditValidator>
                            
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtdatebusiclosed"
                                   ValidationGroup="vsErrorGroup" ErrorMessage="Business Reopened Date Must Be Greater Than Business Closed Date."
                                   Type="Date" Operator="GreaterThan" ControlToCompare="txtdatebusireopen" Display="none">
                                   </asp:CompareValidator>
                            
                                        </td>
                                       
                       
                        <td class="lc" >
                            Date Business Reopened
                        </td>
                        <td >
                            :
                        </td>
                      
                                        <td class="ic">
                                            <asp:TextBox ID="txtdatebusireopen" runat="server"></asp:TextBox>
                                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtdatebusireopen', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                align="absmiddle" />
                            <cc1:MaskedEditExtender ID="Maske18" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" TargetControlID="txtdatebusiclosed" CultureName="en-US"
                                AutoComplete="true" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="MaskedEditValidator7" runat="server" ControlExtender="Maske18"
                                ControlToValidate="txtdatebusiclosed" Display="dynamic" IsValidEmpty="true" MaximumValue=""
                                InvalidValueMessage="Date is invalid" MaximumValueMessage="" MinimumValueMessage=""
                                TooltipMessage="" MinimumValue="" ValidationGroup="vsErrorGroup">
                            </cc1:MaskedEditValidator>
                            
                                    <asp:RegularExpressionValidator id="RegularExpressionValidator5" runat="server" ControlToValidate="txtdatebusireopen"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                            ErrorMessage="Date Not Valid(Date Business Reopened)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                 
                                        </td>
                                        
                    </tr>
                    <tr>
                        <td class="lc">
                            Expenses on Property to Date
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Physical Property Damage
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtphyproperty" runat="server"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Extra/Expediting Expenses ($)</td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtextraExpending" runat="server"  onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Business Interruption
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtbusiInterr" runat="server"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Total ($)</td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txttotal" runat="server"  onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </div>
            <div style="width: 100% ; display: none;" id="divsix" runat="server">
                <table border="0" cellpadding="0" cellspacing="4" width="100%">
                    <tr>
                        <td class="ghc" colspan="6">
                            Property Loss Percent Damage Breakdown
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Building
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Flood
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentFlood" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Percent Wind
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentwindproloss1" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Fire
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentfireproloss1" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Percent Other
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentother1" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Contents
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Flood
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentflood2" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Percent Wind
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentwind2" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Fire
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentfire2" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Percent Other
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentother2" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Computers
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Flood
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentflood3" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Percent Wind
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentWind3" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Fire
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentfire3" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Percent Other
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentother3" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            ATMs
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Flood
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentflood4" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Percent Wind
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentWind4" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Fire
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentfire4" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Percent Other
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentother4" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Leasehold Improvements
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Flood
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentflood5" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Percent Wind
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtpercentwind5" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Fire
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentfire5" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Percent Other
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtpercentother5" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Signs
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Flood
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentFlood6" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Percent Wind
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentWind6" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Fire
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentFire6" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Percent Other
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentOther6" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Fine Arts
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Flood
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentFlood7" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Percent Wind
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtpercentWind7" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Fire
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentFire7" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Percent Other
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpercentOther7" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="width: 100% ;display: none;" id="divseven" runat="server">
                <table border="0" cellpadding="0" cellspacing="4" width="100%">
                    <tr>
                        <td class="ghc" colspan="6">
                            Police Report
                        </td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Was Incident Reported to Police?
                        </td>
                        <td>
                            :
                        </td>
                        <td class="lc">
                            <asp:RadioButtonList ID="rbtnwasincidentrep" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList></td>
                        <td class="lc">
                            Date Incident Reported to Police
                        </td>
                        <td>
                            :
                        </td>
                       
                                        <td class="ic">
                                            <asp:TextBox ID="txtincreportedpolicy" runat="server"></asp:TextBox>
                                             <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtincreportedpolicy', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                align="absmiddle" />
                            <cc1:MaskedEditExtender ID="Maske9" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" TargetControlID="txtincreportedpolicy" CultureName="en-US"
                                AutoComplete="true" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="MaskedEditValidator8" runat="server" ControlExtender="Maske9"
                                ControlToValidate="txtincreportedpolicy" Display="dynamic" IsValidEmpty="true" MaximumValue=""
                                InvalidValueMessage="Date is invalid" MaximumValueMessage="" MinimumValueMessage=""
                                TooltipMessage="" MinimumValue="" ValidationGroup="vsErrorGroup">
                            </cc1:MaskedEditValidator>
                            
                                     <asp:RegularExpressionValidator id="RegularExpressionValidator6" runat="server" ControlToValidate="txtincreportedpolicy"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                            ErrorMessage="Date Not Valid(Date Incident Reported to Police)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                 
                                        </td>
                                       
                    </tr>
                    <tr>
                        <td class="lc">
                            Police Case Number
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpolicycastno" runat="server"  MaxLength = "30"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Police Officer Name
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtppliceoffname" runat="server"  MaxLength = "50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Police Address (1)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpoliceadd1" runat="server"  MaxLength = "50"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Police Address (2)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpoliceadd2" runat="server"  MaxLength = "50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Police City
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpolicecity" runat="server"  MaxLength = "30"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Police State
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:DropDownList ID ="dwpolicestate" runat="server"> </asp:DropDownList>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Police Zip Code
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpoliceZipcode" runat="server" MaxLength="5"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Police Telephone Number<br />
                           
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpolicephone" runat="server"  MaxLength = "255"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Police Comments
                        </td>
                        <td>
                            :
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtpolicecommnts" runat="server"  MaxLength = "255"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </div>
            <div style="width: 100% ; display: none;" id="diveight" runat="server">
                <table border="0" cellpadding="0" cellspacing="4" width="100%">
                    <tr>
                        <td class="ghc" colspan="6">
                            Auto Liability Specifics
                        </td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Weather Conditions
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                          <asp:DropDownList ID ="dwwhethercond" runat="server"> </asp:DropDownList>
                        </td>
                        <td class="lc">
                            Were Travel Restrictions in effect at time of incident?
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:RadioButtonList ID="rbtnwheretravel" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Point of Impact
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtpoinofImpact" runat="server"  MaxLength = "30"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Parts Damaged
                        </td>
                        <td>
                            :
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtpartsdamage" runat="server"  MaxLength = "255" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Make<span class = "mf">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtmake" runat="server"  MaxLength = "30" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Reqmake" runat="server" ControlToValidate="txtmake" 
                                Display="None" ErrorMessage="Please enter Make" ValidationGroup="vsErrorGroup" ></asp:RequiredFieldValidator> 
                        </td>
                        <td class="lc">
                            Model<span class = "mf">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtmodel" runat="server"  MaxLength = "30" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Reqmodel" runat="server" ControlToValidate="txtmodel" 
                                Display="None" ErrorMessage="Please enter Model" ValidationGroup="vsErrorGroup" ></asp:RequiredFieldValidator> 
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Year of Manufacture<span class = "mf">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtyearofmenu" runat="server"  MaxLength = "4" ></asp:TextBox>
                              <asp:RequiredFieldValidator ID="Reqyearofmenu" runat="server" ControlToValidate="txtyearofmenu" 
                                Display="None" ErrorMessage="Please enter Year of Manufacture" ValidationGroup="vsErrorGroup" ></asp:RequiredFieldValidator> 
                        </td>
                        <td class="lc">
                            Color
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtcolor" runat="server"  MaxLength = "20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Vehicle Identification Number (VIN)<span class = "mf">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtvehicleidentino" runat="server"  MaxLength = "20" ></asp:TextBox>
                              <asp:RequiredFieldValidator ID="Reqidentino" runat="server" ControlToValidate="txtvehicleidentino" 
                                Display="None" ErrorMessage="Please enter Vehicle Identification Number" ValidationGroup="vsErrorGroup" ></asp:RequiredFieldValidator> 
                        </td>
                        <td class="lc">
                            Value ($)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            
                            <asp:TextBox ID="txtvalue" runat="server"  MaxLength = "11"  onKeyPress="return(currencyFormat(this,',','.',event))" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Was Vehicle Towed?
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:RadioButtonList ID="rbtnwasvehicletowed" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList></td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Storage Location of Vehicle
                        </td>
                        <td>
                            :
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtstoragelocation" runat="server"  MaxLength = "255"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Driver Age
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtdriverage" runat="server"  MaxLength = "2" ></asp:TextBox>
                        </td>
                        <td class="lc">
                            Permission Granted to Second Driver to Drive Vehicle?
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:RadioButtonList ID="rbtnpermissiongrantedtosecdriver" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Name of Second Driver
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtnamesecDriver" runat="server"  MaxLength = "50" ></asp:TextBox>
                        </td>
                        <td class="lc">
                            Second Driver Address (1)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtsecdriveradd1" runat="server"  MaxLength = "50" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Second Driver Address (2)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtsecdriveradd2" runat="server"  MaxLength = "50" ></asp:TextBox>
                        </td>
                        <td class="lc">
                            Second Driver City
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtsecdrivercity" runat="server"  MaxLength = "30" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Second Driver State
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:DropDownList ID ="dwsecdriverstate" runat="server"> </asp:DropDownList>
                        </td>
                        <td class="lc">
                            Second Driver Zip Code
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtsecdriverzip" runat="server" MaxLength="5"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Second Driver Telephone Number<br />
                            
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtsecdriverphone" runat="server"  MaxLength = "14" ></asp:TextBox>
                        </td>
                        <td class="lc">
                            Second Driver Insurance Company
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtsecdriverinscopmpany" runat="server"  MaxLength = "30"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Second Driver Insurance Policy Number
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtsecdriverinspolicyno" runat="server"  MaxLength = "30" ></asp:TextBox>
                        </td>
                        <td class="lc">
                            Emergency Medical Services Contacted?
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:RadioButtonList ID="rbtnEmergencyMedical" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Loss Payee for Automobiles
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtlosspayee" runat="server"  MaxLength = "50" ></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </div>
            <div style="width: 100% ;display: none;" id="divnine" runat="server">
                <table border="0" cellpadding="0" cellspacing="4" width="100%">
                    <tr>
                        <td class="ghc" colspan="6">
                            Legal
                        </td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="lc" style="width:20%">
                            Suit Date
                        </td>
                        <td>
                            :
                        </td>
                     
                                        <td class="ic"  style="width:25%">
                                            <asp:TextBox ID="txtsuitdate" runat="server">
                                            </asp:TextBox>
                                               <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtsuitdate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                align="absmiddle" />
                            <cc1:MaskedEditExtender ID="Maske10" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" TargetControlID="txtsuitdate" CultureName="en-US"
                                AutoComplete="true" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="MaskedEditValidator9" runat="server" ControlExtender="Maske10"
                                ControlToValidate="txtsuitdate" Display="dynamic" IsValidEmpty="true" MaximumValue=""
                                InvalidValueMessage="Date is invalid" MaximumValueMessage="" MinimumValueMessage=""
                                TooltipMessage="" MinimumValue="" ValidationGroup="vsErrorGroup">
                            </cc1:MaskedEditValidator>
                            
                            
                                    <asp:RegularExpressionValidator id="RegularExpressionValidator7" runat="server" ControlToValidate="txtsuitdate"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                            ErrorMessage="Date Not Valid(Suit Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                 
                                        </td>
                                      
                             
                        <td class="lc" style="width:20%">
                            Attorney Disclosure Date
                        </td>
                        <td>
                            :
                        </td>
                      
                           
                                        <td class="ic" style="width:25%">
                                            <asp:TextBox ID="txtattodiscdate" runat="server"></asp:TextBox>
                                              <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtattodiscdate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                align="absmiddle" />
                            <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" TargetControlID="txtattodiscdate" CultureName="en-US"
                                AutoComplete="true" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="MaskedEditValidator10" runat="server" ControlExtender="Maske10"
                                ControlToValidate="txtattodiscdate" Display="dynamic" IsValidEmpty="true" MaximumValue=""
                                InvalidValueMessage="Date is invalid" MaximumValueMessage="" MinimumValueMessage=""
                                TooltipMessage="" MinimumValue="" ValidationGroup="vsErrorGroup">
                            </cc1:MaskedEditValidator>
                            
                            
                               
                                    <asp:RegularExpressionValidator id="RegularExpressionValidator8" runat="server" ControlToValidate="txtattodiscdate"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                            ErrorMessage="Date Not Valid(Attorney Disclosure Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                 
                                        </td>
                                        
                    </tr>
                    <tr>
                        <td class="lc">
                            Client Attorney Name
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtclientattoname" runat="server" Width="155px"  MaxLength = "50"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Client Attorney Address (1)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtclientattoadd1" runat="server"  MaxLength = "50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Client Attorney Address (2)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtclientattoadd2" runat="server" Width="155px"  MaxLength = "50"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Client Attorney City
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtclientattocity" runat="server"  MaxLength = "30"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Client Attorney State
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                           <asp:DropDownList ID ="dwStateClientAttorney" runat="server"> </asp:DropDownList>
                           
                        </td>
                        <td class="lc">
                            Client Attorney Zip Code
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtclientattozip" runat="server" MaxLength="5"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Client Attorney Telephone Number<br />
                         
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtclientattophone" runat="server" Width="155px"  MaxLength = "14" ></asp:TextBox>
                        </td>
                        <td class="lc">
                            Client Attorney Facsimile Number<br />
                          
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtclientattoFasc" runat="server"  MaxLength = "14"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Defense Attorney Name
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtdefeattoname"  MaxLength = "50" runat="server" Width="155px"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Defense Attorney Address (1)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtdefeattoadd1" runat="server"  MaxLength = "50" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Defense Attorney Address (2)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtdefeattoadd2" runat="server"  MaxLength = "50" Width="155px"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Defense Attorney City
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtdefeattocity"  MaxLength = "30" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Defense Attorney State
                        </td>
                        <td>
                            :
                        </td>
                       <td>
                       <asp:DropDownList ID = "dwdefatoostate" runat="server"></asp:DropDownList>
                        </td>
                        <td class="lc">
                            Defense Attorney Zip Code
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtdefeattozip" runat="server" MaxLength="5"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Defense Attorney Telephone Number<br />
                           
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtdefeattphone" runat="server"  MaxLength = "14" Width="155px"></asp:TextBox>
                        </td>
                        <td class="lc">
                            Defense Attorney Facsimile Number<br />
                          
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtdefeattFasc" runat="server"  MaxLength = "14"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </div>
           
            <div style="width: 100% ; display: none;" id="divten" runat="server">
                <table border="0" cellpadding="0" cellspacing="6" width="100%">
                    <tr>
                        <td class="ghc" colspan="6">
                            Attachment
                        </td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="lc" style="width:20% ;" >
                            Attachment Type
                        </td>
                        <td style="width:5% ;">
                            :
                        </td>
                        <td style="width:25% ;">
                           <asp:DropDownList ID = "ddlAttachType" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvattach" runat="server" ControlToValidate="ddlAttachType" 
                                Display="None" ValidationGroup="vsErrorGroup" InitialValue="0" ErrorMessage="Please Attachment Type" ></asp:RequiredFieldValidator> 
                    
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Attachment Description
                        </td>
                        <td>
                            :
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtAttachDesc" runat="server" TextMode="MultiLine" Width="94%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                           Select File
                        </td>
                        <td>
                            :
                        </td>
                        <td colspan="4">
                          <asp:FileUpload ID = "uplCommon" runat="server" />
                           <asp:RequiredFieldValidator ID="rvfselect" runat="server" ControlToValidate="uplCommon" 
                                Display="None" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select File" ></asp:RequiredFieldValidator> 
                     
                        </td>
                    </tr>
                    <tr>
                        <td class="ic">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr align="center">
                        <td colspan="6">
                            <asp:Button ID="Add" runat="server" OnClientClick="javascript:ValAttach();"  ValidationGroup="vsErrorGroup" Text="Add Attachment" OnClick="Add_Click" />
                           
                        </td>
                    </tr>
                </table>
            </div>
            <div id="dvAttachDetails" runat="server" style="display: none;" >
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
                            <asp:GridView ID="gvAttachmentDetails" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="false" DataKeyNames="PK_Attachment_ID" OnRowDataBound="gvAttachmentDetails_RowDataBound"
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
                                    <asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" SortExpression="Attachment_Type" />
                                    <asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description"
                                        SortExpression="Attachment_Description" />
                                    <asp:BoundField DataField="Attachment_Name" HeaderText="File Name" SortExpression="Attachment_Name" />
                                    <asp:TemplateField HeaderText="View">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnDwnld" runat="server" CommandArgument='<%# Eval("Attachment_Name")%>'
                                                CommandName="Download" ImageAlign="Left" ImageUrl="~/Images/download.gif" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderText="Mail">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnMail" runat="server" CommandArgument='<%# Eval("Attachment_Name")%>'
                                                CommandName="Mail" ImageAlign="Left" ImageUrl="~/Images/emailicon.gif" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                    </asp:TemplateField>--%>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    Currently There Is No Attachment.<br />
                                    Pls Add One Or More Attachment.
                                </EmptyDataTemplate>
                                <PagerSettings Visible="False" />
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                        </td>
                    </tr>
                        <tr>
                                                  
                            <td>
                                <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />
                                <asp:Button ID="btnMail" runat="server" Text="Mail" OnClientClick="javascript:return OpenWMail('gvAttachmentDetails','Liability_Claim');" />
                            </td>
                        </tr>
                </table>
            </div>
        </div>
        </div>
        <div id="divbtn" runat="server">
        <table style="width: 100%;">
            <tr>
                <td align="center">
                    <asp:Button ID="btnsave" OnClick="btnsave_Click" OnClientClick="javascript:ValSave();"  ValidationGroup="vsErrorGroup" runat="server" Text="Save & View" />
                    <asp:Button ID="btnNextStep" runat="server" OnClientClick="javascript:ValSave();"  ValidationGroup="vsErrorGroup" Text="Next Step" OnClick="btnNextStep_Click"
                        Width="98px" />
                </td>
            </tr>
        </table>
    </div>
    
    
    <div id="ViewDiv" runat="server" style="width: 100%; border: solid 1px; display: none; float: right;">
            <div id="viewdivfirst" runat="server" style="width: 100%;">
                <table id="Table2" runat="server" cellpadding="0" cellspacing="4" class="stylesheet"
                    width="100%">
                    <tr>
                        <td class="ghc" colspan="6">
                            Claim ID</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" class="lc" style =" width:20% ">
                            Claim Number
                        </td>
                        <td align="left" class="lc" style="width: 5%">
                            :
                        </td>
                        <td align="left" class="ic" style="width: 25%">
                            <asp:Label ID="lblClaimNo" runat="server"></asp:Label>
                        </td>
                        <td align="left" class="lc" style="width: 20%">
                         Employee
                        </td>
                        <td align="left" class="ic" style="width: 5%">
                         :
                        </td>
                        <td align="left" class="lc" style="width: 25%">
                      
  		               <asp:Label ID="lblrbtntemployee"  runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            Last Name&nbsp;
                        </td>
                        <td align="left" class="lc" >
                            :
                        </td>
                        <td align="left" class="ic">
                          
                          <asp:Label ID="lbllastname" runat="server"></asp:Label>
                        </td>
                        <td align="left" class="lc">
                            First Name&nbsp; 
                        </td>
                        <td align="left" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                             <asp:Label ID="lblfirstname" runat="server"> </asp:Label>
                            
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            Middle Name
                        </td>
                        <td align="left" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                              <asp:Label ID="lblmiddlename" runat="server"> </asp:Label>
                        </td>
                        <td align="left" class="lc">
                        </td>
                        <td align="left" class="lc">
                        </td>
                        <td align="left" class="ic">
                        <asp:Label ID="lblclaimantid" runat="server" style ="display:block;"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            Cost Center&nbsp;
                        </td>
                        <td align="left" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                             <asp:Label ID="lblcosecenter" runat="server"> </asp:Label>
                           
                        </td>
                        <td align="left" class="lc">
                           Branch Name
                        </td>
                        <td align="left" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label ID="lblbranchname" runat="server"> </asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
           
            <div style="width: 100% ;" runat="server" id="viewdivsecond" >
                <table border="0" cellpadding="0" cellspacing="4" width="100%" >
                    <tr>
                        <td class="ghc" colspan="6">
                            Owner
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" style="width: 20%">
                            Owner
                        </td>
                        <td style="width: 5%">
                            :
                        </td>
                        <td class="ic" style="width: 25%">
                             <asp:Label ID="lblowner" runat="server" > </asp:Label>
                        </td>
                        <td class="lc" style="width: 20%">
                            Address Line 1
                        </td>
                        <td style="width: 5%">
                            :
                        </td>
                        <td class="ic" style="width: 25%">
                             <asp:Label ID="lblAddLine1" runat="server"> </asp:Label>
                          
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Address Line 2
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblAddLine2" runat="server" > </asp:Label>
                        </td>
                        <td class="lc">
                            City
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblcity" runat="server" > </asp:Label>
                           
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            State
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID = "lblstateowner" runat="server"> </asp:Label>
                        </td>
                        <td class="lc">
                            Zip Code
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblzipcode" runat="server" > </asp:Label>
                             
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Home Telephone Number<br />
                           
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblhomephone" runat="server" > </asp:Label>
                        </td>
                        <td class="lc">
                            Work Telephone Number<br />
                          
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblworkphone" runat="server" > </asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="width: 100%;" runat="server" id="viewdivthird">
                <table border="0" cellpadding="0" cellspacing="4" width="100%">
                    <tr>
                        <td class="ghc" colspan="6">
                            Claim Detail
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" style="width: 20%">
                            Description
                        </td>
                        <td style="width: 5%">
                            :
                        </td>
                        <td colspan="4" style="width: 75%">
                             <asp:Label ID="lblclaimDesc" runat="server" CssClass="lc"  ></asp:Label>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" style ="width: 20%">
                            Nature of Incident
                        </td>
                        <td style="width: 5%">
                            :
                        </td>
                        <td class="ic" style="width: 25%" >
                            <asp:Label ID ="lblnaturofinc" runat = "server" style="width: 155px"> </asp:Label>   
                           
                        </td>
                        <td class="lc" style="width: 20%">
                            Estimate to Repair Damage ($)</td>
                        <td style="width: 5%;">
                            :
                        </td>
                        <td class="ic" style="width: 25%" >
                             <asp:Label ID="lblEstimatetorepair" runat="server" >  </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Actual Cost to Repair Damage ($)</td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblActualtorepair" runat="server"   > </asp:Label>
                        </td>
                        <td class="lc" >
                            Road Type
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID ="lblroadtype" runat = "server"> </asp:Label>   
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Road Surface
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:Label ID ="lblroadsurface" runat = "server" > </asp:Label>   
                        </td>
                        <td class="lc" >
                            Cause
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:Label ID ="lblcause" runat = "server" > </asp:Label>  
                          
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Body Part(s) Affected
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                        <asp:Label ID ="lblbodyparts" runat = "server" > </asp:Label>   
                          
                        </td>
                        <td class="lc" >
                            Injury Code
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID ="lblinjury" runat = "server" > </asp:Label>   
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            NCCI Code
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:Label ID ="lblNCCIcode" runat = "server" > </asp:Label>   
                        </td>
                        <td class="lc">
                            Vocational Rehabilitation?
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblrbtnVocational" runat="server" > </asp:Label>
                              
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            NCCI Nature
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID ="lblNCCInature" runat = "server" > </asp:Label>   
                        </td>
                        <td class="lc" >
                            Product Name
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblproductname" runat="server"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Hazard Code
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                         <asp:Label ID ="lblHazardCode" runat = "server" > </asp:Label>   
                           
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" style="height: 19px">
                            Location Description
                        </td>
                        <td >
                            :
                        </td>
                        <td colspan="4" >
                             <asp:Label ID="lbllocationdesc" runat="server" CssClass="lc" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Comprehensive Deductible
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                          <asp:Label ID ="lblComprehensiveDeductible" runat = "server" CssClass="lc"></asp:Label>   
                        
                           
                        </td>
                        <td class="lc">
                            Collision Deductible
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                           <asp:Label ID ="lblCollisionDeductible" runat = "server" CssClass="lc"></asp:Label>   
                        
                           
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" >
                            Original Cost
                        </td>
                        <td >
                            :
                        </td>
                        <td >
                             <asp:Label ID ="lbloiginalcost" runat = "server" CssClass="lc"></asp:Label>   
                        </td>
                        <td class="lc" >
                            &nbsp;
                        </td>
                        <td >
                            &nbsp;
                        </td>
                        <td >
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" >
                            Major Claim Type
                        </td>
                        <td >
                            :
                        </td>
                        <td >
                            <asp:Label ID ="lblmajorclaim" runat = "server"  CssClass="lc"></asp:Label>  
                           
                        </td>
                        <td class="lc">
                            Minor Claim Type
                        </td>
                        <td >
                            :
                        </td>
                        <td class="ic" >
                            <asp:Label ID ="lblminor" runat = "server" > </asp:Label>   
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Claim Convertible?
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
   		<asp:Label ID ="lblrtnclaimconvert" runat = "server" > </asp:Label>   
                           </td>
                        <td class="lc">
                            Date of Incident 
                        </td>
                        <td>
                            :
                        </td>
                                        <td class="ic">
                                             <asp:Label ID="lbldateofinc" runat="server"> </asp:Label>
                                            </td>
                                                                          
                      
                    </tr>
                    <tr>
                        <td class="lc">
                            Fraudulent Claim Indicator
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                          <asp:Label ID ="lblFraudClaim" runat = "server" > </asp:Label>   
                           
                        </td>
                        <td class="lc" >
                            Date Incident Reported
                        </td>
                        <td>
                            :
                        </td>
                       
                                        <td class="ic">
                                             <asp:Label ID="lblincreported" runat="server"> </asp:Label>
                                          
                           
                            </td>
                                        
                                 
                    </tr>
                    <tr>
                        <td class="lc">
                            Date Claim Opened
                        </td>
                        <td>
                            :
                        </td>
                                <td class="ic">
                                  <asp:Label ID="lblclaimopen" runat="server"> </asp:Label>
                             
                            </td>
                                       
                        <td class="lc">
                            Date Claim Closed
                        </td>
                        <td>
                            :
                        </td>
                        
                                        <td class="ic">
                                             <asp:Label ID="lblclaimclosed" runat="server"> </asp:Label>
                                            
                           
                            </td>
                                        
                    </tr>
                    <tr>
                        <td class="lc">
                            Date Claim Reopened
                        </td>
                        <td>
                            :
                        </td>
                      
                                        <td class="ic">
                                             <asp:Label ID="lbldateclaimreported" runat="server"> </asp:Label>
                                              
                           
                                        </td>
                                     
                        <td class="lc" >
                            Surgery Required?
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
		 <asp:Label ID="lblrbtnsurgery" runat="server"> </asp:Label>
                          
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Number of Weeks of Scheduled Indemnity
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblnoofweekssch" runat="server"> </asp:Label>
                        </td>
                        <td class="lc" >
                            Jurisdiction State
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:Label ID ="lbljuridicationstate" runat = "server" > </asp:Label>   
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Assigned to (Last Name)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblassignlast" runat="server"> </asp:Label>
                         </td>
                        <td class="lc">
                            Assigned to (First Name)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblassignfirst" runat="server"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Assigned to (Middle Name)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblassignmiddle" runat="server" style ="display:none;" > </asp:Label>
                        </td>
                        <td class="lc" >
                            Civil or Criminal Violation?
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
		 <asp:Label ID="lblrbtncivilorcriminal" runat="server"> </asp:Label>
                           
                        </td>
                    </tr>
                </table>
            </div>
            <div style="width: 100% ;" runat="server"  id="viewdivfour">
                <table border="0" cellpadding="0" cellspacing="4" width="100%">
                    <tr>
                        <td class="ghc" colspan="6">
                            Property Loss
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" style="width: 20%">
                            Property Name
                        </td>
                        <td style="width: 5%">
                            :
                        </td>
                        <td class="ic" style="width: 25%">
                             <asp:Label ID="lblproperty" runat="server"> </asp:Label>
                         </td>
                        <td class="lc" style="width: 20%">
                            Entity
                        </td>
                        <td style="width: 5%">
                            :
                        </td>
                        <td class="ic" >
                             <asp:Label ID="lblentity" runat="server"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" >
                            Address Line 1
                        </td>
                        <td >
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lbladd1" runat="server"  > </asp:Label>
                        </td>
                        <td class="lc">
                            Address Line 2
                        </td>
                        <td >
                            :
                        </td>
                        <td class="ic" >
                             <asp:Label ID="lbladd2" runat="server" > </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            City
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblcityproperty" runat="server"> </asp:Label>
                        </td>
                        <td class="lc">
                            State
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblstate" runat="server"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Zip Code
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblzipproperty" runat="server"> </asp:Label>
                        </td>
                        <td class="lc">
                            County
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblcounty" runat="server"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Ownership
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblowenership" runat="server"> </asp:Label>
                        </td>
                        <td class="lc">
                            What Flood Zone is the Property In?
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblwhatfood" runat="server"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Number of Employees in Building
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblnoofemployee" runat="server"> </asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
            <div style="width: 100% ;border: solid 1px;" runat="server" id="viewdivfive">
                <table border="0" cellpadding="0" cellspacing="4" width="100%">
                    <tr>
                        <td class="ghc" colspan="6">
                            Replacement Values
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" style="width: 20%">
                            Building ($)</td>
                        <td style="width: 5%">
                            :
                        </td>
                        <td class="ic" style="width: 25%">
                             <asp:Label ID="lblbuilding" runat="server" > </asp:Label>
                        </td>
                        <td class="lc" style="width: 20%">
                            Signs ($)</td>
                        <td style="width: 5%">
                            :
                        </td>
                        <td class="ic" style="width: 25%">
                             <asp:Label ID="lblSigns" runat="server"  > </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Contents ($)</td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblcontents" runat="server"  > </asp:Label>
                        </td>
                        <td class="lc">
                            Computers ($)</td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblcomputers" runat="server" > </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            ATMs ($)</td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblATMS" runat="server"  > </asp:Label>
                        </td>
                        <td class="lc">
                            Lease Improvements ($)</td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblleaseimprovements" runat="server" > </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Total ($)</td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lbltotel" runat="server"  > </asp:Label>
                        </td>
                        <td class="lc">
                            
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblid" runat="server" Style="display:none"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Description of Loss
                        </td>
                        <td>
                            :
                        </td>
                        <td colspan="4">
                             <asp:Label ID="lbldescloss" runat="server" CssClass="lc"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Incident Type
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                         <asp:Label ID ="lblWeatherIncident" runat="server" > </asp:Label>
                            
                        </td>
                        <td class="lc">
                            Policy Number
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpolicyNo" runat="server"> </asp:Label>
                          </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Property Deductible ($)</td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpropertydeduct" runat="server"  > </asp:Label>
                        </td>
                        <td class="lc">
                            Flood Deductible ($)</td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblfooddeduct" runat="server" > </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" >
                            Date Business Closed
                        </td>
                        <td >
                            :
                        </td>
                      
                                        <td class="ic">
                                             <asp:Label ID="lbldatebusiclosed" runat="server" > </asp:Label>
                                            
                                        </td>
                                       
                       
                        <td class="lc" >
                            Date Business Reopened
                        </td>
                        <td >
                            :
                        </td>
                      
                                        <td class="ic">
                                             <asp:Label ID="lbldatebusireopen" runat="server"> </asp:Label>
                                      
                                        </td>
                                        
                    </tr>
                    <tr>
                        <td class="lc">
                           <strong>Expenses on Property to Date</strong> 
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Physical Property Damage
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblphyproperty" runat="server"> </asp:Label>
                        </td>
                        <td class="lc">
                            Extra/Expediting Expenses ($)</td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblextraExpending" runat="server" > </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Business Interruption
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblbusiInterr" runat="server"> </asp:Label>
                        </td>
                        <td class="lc">
                            Total ($)</td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lbltotal" runat="server"  > </asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="width: 100% ; " runat="server" id="viewdivsix">
                <table border="0" cellpadding="0" cellspacing="4" width="100%">
                    <tr>
                        <td class="ghc" colspan="6">
                            Property Loss Percent Damage Breakdown
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Building
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" style="width: 20%">
                            Percent Flood
                        </td>
                        <td style="width: 5%">
                            :
                        </td>
                        <td class="ic" style="width: 25%">
                             <asp:Label ID="lblpercentFlood" runat="server"> </asp:Label>
                        </td>
                        <td class="lc" style="width: 20%">
                            Percent Wind
                        </td>
                        <td style="width: 5%">
                            :
                        </td>
                        <td class="ic" style="width: 25%">
                             <asp:Label ID="lblpercentwindproloss1" runat="server"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Fire
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentfireproloss1" runat="server"> </asp:Label>
                        </td>
                        <td class="lc">
                            Percent Other
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentother1" runat="server"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Contents
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Flood
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentflood2" runat="server"> </asp:Label>
                        </td>
                        <td class="lc">
                            Percent Wind
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentwind2" runat="server"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Fire
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentfire2" runat="server"> </asp:Label>
                        </td>
                        <td class="lc">
                            Percent Other
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentother2" runat="server"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Computers
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Flood
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentflood3" runat="server"> </asp:Label>
                        </td>
                        <td class="lc">
                            Percent Wind
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentWind3" runat="server"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Fire
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentfire3" runat="server"> </asp:Label>
                        </td>
                        <td class="lc">
                            Percent Other
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentother3" runat="server"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            ATMs
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Flood
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentflood4" runat="server"> </asp:Label>
                        </td>
                        <td class="lc">
                            Percent Wind
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentWind4" runat="server"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Fire
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentfire4" runat="server"> </asp:Label>
                        </td>
                        <td class="lc">
                            Percent Other
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentother4" runat="server"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Leasehold Improvements
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Flood
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentflood5" runat="server"> </asp:Label>
                        </td>
                        <td class="lc">
                            Percent Wind
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                             <asp:Label ID="lblpercentwind5" runat="server" CssClass="lc"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Fire
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentfire5" runat="server"> </asp:Label>
                        </td>
                        <td class="lc">
                            Percent Other
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                             <asp:Label ID="lblpercentother5" runat="server" CssClass="lc"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Signs
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Flood
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentFlood6" runat="server"> </asp:Label>
                        </td>
                        <td class="lc">
                            Percent Wind
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentWind6" runat="server"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Fire
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentFire6" runat="server"> </asp:Label>
                        </td>
                        <td class="lc">
                            Percent Other
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentOther6" runat="server"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Fine Arts
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Flood
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentFlood7" runat="server"> </asp:Label>
                        </td>
                        <td class="lc">
                            Percent Wind
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                             <asp:Label ID="lblpercentWind7" runat="server" CssClass="lc"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Percent Fire
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentFire7" runat="server"> </asp:Label>
                        </td>
                        <td class="lc">
                            Percent Other
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpercentOther7" runat="server"> </asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="width: 100% ;border: solid 1px; " runat="server" id="viewdivseven">
                <table border="0" cellpadding="0" cellspacing="4" width="100%">
                    <tr>
                        <td class="ghc" colspan="6">
                            Police Report
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" style="width: 20%">
                            Was Incident Reported to Police?
                        </td>
                        <td style="width: 5%">
                            :
                        </td>
                        <td class="lc" style="width: 25%">
                        <asp:Label ID="lblrbtnwasincrep" runat="server"> </asp:Label>
                           
                        <td class="lc" style="width: 20%">
                            Date Incident Reported to Police
                        </td>
                        <td style="width: 5%">
                            :
                        </td>
                       
                                        <td class="ic" style="width: 25%">
                                             <asp:Label ID="lblincreportedpolicy" runat="server"> </asp:Label>
                                             
                                        </td>
                                       
                    </tr>
                    <tr>
                        <td class="lc">
                            Police Case Number
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpolicycastno" runat="server"  > </asp:Label>
                        </td>
                        <td class="lc">
                            Police Officer Name
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblppliceoffname" runat="server" > </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Police Address (1)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpoliceadd1" runat="server"  > </asp:Label>
                        </td>
                        <td class="lc">
                            Police Address (2)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpoliceadd2" runat="server" > </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Police City
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpolicecity" runat="server"  > </asp:Label>
                        </td>
                        <td class="lc">
                            Police State
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID ="lblpolicestate" runat="server">  </asp:Label>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Police Zip Code
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpoliceZipcode" runat="server" > </asp:Label>
                        </td>
                        <td class="lc">
                            Police Telephone Number<br />
                           
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpolicephone" runat="server"  > </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Police Comments
                        </td>
                        <td>
                            :
                        </td>
                        <td colspan="4">
                             <asp:Label ID="lblpolicecommnts" runat="server" CssClass="lc" ></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="width: 100% ;" runat="server" id="viewdiveight">
                <table border="0" cellpadding="0" cellspacing="4" width="100%">
                    <tr>
                        <td class="ghc" colspan="6">
                            Auto Liability Specifics
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" style="width: 20%">
                            Weather Conditions
                        </td>
                        <td style="width: 5%">
                            :
                        </td>
                        <td class="ic" style="width: 25%">
                           <asp:Label ID ="lblwhethercond" runat="server">  </asp:Label>
                        </td>
                        <td class="lc" style="width: 20%">
                            Were Travel Restrictions in effect at time of incident?
                        </td>
                        <td style="width: 5%">
                            :
                        </td>
                        <td class="ic" style="width: 25%">
         		<asp:Label ID ="lblrbtnwheretravel" runat="server">  </asp:Label>
                           </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Point of Impact
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblpoinofImpact" runat="server" > </asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Parts Damaged
                        </td>
                        <td>
                            :
                        </td>
                        <td colspan="4">
                             <asp:Label ID="lblpartsdamage" runat="server" CssClass="lc"  ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Make
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblmake" runat="server"   > </asp:Label>
                           
                        </td>
                        <td class="lc">
                            Model
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblmodel" runat="server"   > </asp:Label>
                           
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Year of Manufacture
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblyearofmenu" runat="server"   > </asp:Label>
                             
                        </td>
                        <td class="lc">
                            Color
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblcolor" runat="server" > </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Vehicle Identification Number (VIN)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblvehicleidentino" runat="server"  > </asp:Label>
                        
                        </td>
                        <td class="lc">
                            Value ($)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            
                             <asp:Label ID="lblvalue" runat="server"  > </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Was Vehicle Towed?
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                          <asp:Label ID="lblrbtnwasvehicletowed" runat="server"  > </asp:Label>
                          
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Storage Location of Vehicle
                        </td>
                        <td>
                            :
                        </td>
                        <td colspan="4">
                             <asp:Label ID="lblstoragelocation" runat="server" CssClass="lc" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Driver Age
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                             <asp:Label ID="lbldriverage" runat="server" CssClass="lc"  ></asp:Label>
                        </td>
                        <td class="lc">
                            Permission Granted to Second Driver to Drive Vehicle?
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:Label ID="lblrbtnpermissiongrantedtosecdrive" runat="server"  > </asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Name of Second Driver
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblnamesecDriver" runat="server"  > </asp:Label>
                        </td>
                        <td class="lc">
                            Second Driver Address (1)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblsecdriveradd1" runat="server"  > </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Second Driver Address (2)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblsecdriveradd2" runat="server" > </asp:Label>
                        </td>
                        <td class="lc">
                            Second Driver City
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblsecdrivercity" runat="server"   > </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Second Driver State
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                              <asp:Label ID ="lblsecdriverstate" runat="server">  </asp:Label>
                        </td>
                        <td class="lc">
                            Second Driver Zip Code
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblsecdriverzip" runat="server" > </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Second Driver Telephone Number<br />
                            
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblsecdriverphone" runat="server" > </asp:Label>
                        </td>
                        <td class="lc">
                            Second Driver Insurance Company
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblsecdriverinscopmpany" runat="server"  > </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Second Driver Insurance Policy Number
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblsecdriverinspolicyno" runat="server"   > </asp:Label>
                        </td>
                        <td class="lc">
                            Emergency Medical Services Contacted?
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
		  <asp:Label ID="lblrbtnEmergencyMedical" runat="server"   > </asp:Label>
                           
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Loss Payee for Automobiles
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lbllosspayee" runat="server"  > </asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
            <div style="width: 100% ; " runat="server" id="viewdivnine">
                <table border="0" cellpadding="0" cellspacing="4" width="100%">
                    <tr>
                        <td class="ghc" colspan="6">
                            Legal
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" style="width: 20%">
                            Suit Date
                        </td>
                        <td style="width: 5%">
                            :
                        </td>
                     
                                        <td class="ic" style="width: 25%">
                                             <asp:Label ID="lblsuitdate" runat="server">
                                             </asp:Label>
                                               
                                        </td>
                                      
                             
                        <td class="lc" style="width: 20%">
                            Attorney Disclosure Date
                        </td>
                        <td style="width: 5%">
                            :
                        </td>
                      
                           
                                        <td class="ic" style="width: 25%">
                                             <asp:Label ID="lblattodiscdate" runat="server"> </asp:Label>
                                            
                                        </td>
                                        
                    </tr>
                    <tr>
                        <td class="lc">
                            Client Attorney Name
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblclientattoname" runat="server" > </asp:Label>
                        </td>
                        <td class="lc">
                            Client Attorney Address (1)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblclientattoadd1" runat="server"  > </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Client Attorney Address (2)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblclientattoadd2" runat="server" > </asp:Label>
                        </td>
                        <td class="lc">
                            Client Attorney City
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblclientattocity" runat="server" > </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Client Attorney State
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:Label ID ="lblStateClientAttorney" runat="server">  </asp:Label>
                           
                        </td>
                        <td class="lc">
                            Client Attorney Zip Code
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblclientattozip" runat="server"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Client Attorney Telephone Number<br />
                         
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblclientattophone" runat="server" > </asp:Label>
                        </td>
                        <td class="lc">
                            Client Attorney Facsimile Number<br />
                          
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lblclientattoFasc" runat="server"  > </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Defense Attorney Name
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lbldefeattoname" runat="server" > </asp:Label>
                        </td>
                        <td class="lc">
                            Defense Attorney Address (1)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lbldefeattoadd1" runat="server" > </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Defense Attorney Address (2)
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lbldefeattoadd2" runat="server" > </asp:Label>
                        </td>
                        <td class="lc">
                            Defense Attorney City
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lbldefeattocity"   runat="server"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Defense Attorney State
                        </td>
                        <td>
                            :
                        </td>
                       <td>
                        <asp:Label ID = "lbldefatoostate" runat="server" CssClass="lc"></asp:Label>
                        </td>
                        <td class="lc">
                            Defense Attorney Zip Code
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lbldefeattozip" runat="server" > </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Defense Attorney Telephone Number<br />
                           
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lbldefeattphone" runat="server"   > </asp:Label>
                        </td>
                        <td class="lc">
                            Defense Attorney Facsimile Number<br />
                          
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                             <asp:Label ID="lbldefeattFasc" runat="server" > </asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
           <div id="divviewAttach" style="width: 100%" runat="server">
            <table width="100%">
                <tr>
                    <td colspan="2">
                        <table cellspacing="4" cellpadding="2" width="100%" style="background-color: #7f7f7f;
                            color: White; font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
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
                                <asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type">
                                </asp:BoundField>
                                <asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description"></asp:BoundField>
                                <asp:BoundField DataField="Attachment_Name" HeaderText="File Name" >
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
                    <td colspan="6" align="center">
                       <%-- <asp:Button runat="server" ID="btnBack" Text="Back" OnClick="btnBack_Click" />--%>
                        <asp:Button runat="server" ID="btnViewNext" CausesValidation ="false" Text= "Next Step" OnClick="btnViewNext_Click" />
                         <asp:Button runat="server" ID="btnBack" CausesValidation ="false" Text= "Back" Visible="false" OnClick="btnBack_Click" />
                    </td>
                </tr>
            </table>
        </div>
          
        </div>
    
     <asp:HiddenField ID="dispTagName" runat="server" />
    <asp:HiddenField ID="hidPhoneno" runat="server" />

    <script type="text/javascript">

        var tagDisplay = document.getElementById("ctl00_ContentPlaceHolder1_dispTagName").value;
       
        if(tagDisplay !="")
        {  
                document.getElementById("ten").className="left_menu_active";
                document.getElementById("first").className="left_menu";
                document.getElementById("second").className="left_menu";
                              
                document.getElementById("third").className="left_menu";  
                document.getElementById("four").className="left_menu";     
                document.getElementById("five").className="left_menu";     
                document.getElementById("six").className="left_menu";  
                document.getElementById("seven").className="left_menu";     
                document.getElementById("eight").className="left_menu";     
                document.getElementById("nine").className="left_menu";   
        }
     </script>
    
    
</asp:Content>
