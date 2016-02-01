<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="RealEstateAddEdit.aspx.cs"
    Inherits="SONIC_RealEstate_RealEstateAddEdit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment-ExecutiveRisk/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment-ExecutiveRisk/AttachmentDetails.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<%@ Register Src="../../Controls/RealEstateTab/RealEstate.ascx" TagName="RealEstate"
    TagPrefix="uc2" %>
<%@ Register Src="../../Controls/RealEstateInfo/RealEstateInfo.ascx" TagName="RealEstateInfo"
    TagPrefix="uc2" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">

    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript">
        window.onscroll=getScrollHeight;
        function getScrollHeight()
        {
           var h = window.pageYOffset ||
                   document.body.scrollTop ||
                   document.documentElement.scrollTop;
            document.getElementById('divProgress').style.height= screen.height + h;
            document.getElementById('ProgressTable').style.height= screen.height + h;
        }

        function SetMenuStyle(index)
        {
	        var i;
	        for(i=1; i<=10;i++)
	        {
		        var tb=document.getElementById("Menu"+i);
		        
		        if(i==index)
		        {
			        tb.className="LeftMenuSelected";
			        tb.onmouseover= function(){this.className = 'LeftMenuSelected';}
			        tb.onmouseout=  function(){this.className = 'LeftMenuSelected';}
		        }
		        else
		        {
			        tb.className="LeftMenuStatic";
			        tb.onmouseover= function(){this.className = 'LeftMenuHover';}
			        tb.onmouseout= function(){this.className = 'LeftMenuStatic';}
		        }
	        }
        }

        function ShowPanel(index)
        {
            SetMenuStyle(index);
	        ActiveTabIndex = index;
	        var op = '<%=_StrOperation%>';
	        if(op == "view")
	        {
		        ShowPanelView(index);
	        }
	        else
	        {
		        var i;
		        if(index<10)
		        {
			        for(i=1;i<=9;i++)
			        {
				        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display =(i==index) ? "block" : "none";
			        }
			        
			        if(index==3)
			            document.getElementById('<%=txtSubtenant_DBA.ClientID%>').focus();
			        else if(index==4)
			            document.getElementById('<%=txtResponsible_Party.ClientID%>').focus();
			        else if(index==5)
			            document.getElementById('<%=txtAmount.ClientID%>').focus();    
			        else if(index==7)
			            document.getElementById('<%=txtCondition_At_Commencement.ClientID%>').focus(); 
			        else if(index==8)
			            document.getElementById('<%=txtLandlord_Company.ClientID%>').focus(); 
			            
			        document.getElementById("<%=dvAttachment.ClientID%>").style.display="none";
			        document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display="none";
		        }
		        else
		        {
			        for(i=1;i<=9;i++)
			        {
				         document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display ="none";
			        }
			        document.getElementById("<%=dvAttachment.ClientID%>").style.display="block";
			        document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display="block";
		        }
	        }
        }
        
         function setFocus(ctrl)
         {
             document.getElementById(ctrl).focus();
         }

 
        function ShowPanelView(index)
        {
	        SetMenuStyle(index);
	        document.getElementById('<%=dvView.ClientID%>').style.display = "block";
	        var i;
	        if(index<10)
	        {
		        for(i=1;i<=9;i++)
		        {
			        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "view").style.display =(i==index) ? "block" : "none";
		        }
		        document.getElementById("<%=dvAttachment.ClientID%>").style.display="none";
		        document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display="none";
	        }
	        else
	        {
		        for(i=1;i<=9;i++)
		        {
			        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display ="none";
		        }
		        document.getElementById("<%=dvAttachment.ClientID%>").style.display="none";
		        document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display="block";
	        }
        }

        function ValSave()
        {
	        document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled=false;
	        document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled=false;
	        document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled=false;
	        if(Page_ClientValidate())
	        return true;
	        else
	        return false;
        }

        function ValAttach()
        {
	        document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled=true;
	        document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled=true;
	        document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled=true;
	        if(Page_ClientValidate())
	        return true;
	        else
	        return false;
        }

        function OpenDBAPopup()
        {
            var w = 480, h = 340;
            var navigationurl="DealershipDBA_Pupup.aspx?hdnID=hdnLU_location.ClientID&btnID=btnDBASelectionChange.ClientID";
            
            if (document.all || document.layers)
            {
                w = screen.availWidth;
                h = screen.availHeight;
            }
           
            var leftPos,topPos;
            var popW = 700, popH = 500;
            if(document.all)    
            {leftPos = (w-popW)/2; topPos = (h-popH)/2;}
            else
            {leftPos = w/2; topPos = h/2;}
            
            window.open(navigationurl ,"popup","toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos +",left=" + leftPos);         
            return false;
        }
        
        function YearValidate(x)
        {
            var strErrorInval = "";
            var strErrorLess ="";
            strErrorInval = "Year is Invalid.";
            strErrorLess = "Year should be less than or equal to current year.";
            
            var right_now=new Date();
            var the_year=right_now.getYear();
          
            var y=document.getElementById(x).value;
            if(y.length < 4 && y.length > 0)
            {
                alert(strErrorInval);
                document.getElementById(x).select();           
            }
            if(y != the_year && y > the_year)
            { 
                alert(strErrorLess);
                document.getElementById(x).select();           
            }
        }
        
        var pattern =/[0-9]/;
        function isValid(id) 
        {
	        var keyCode = event.keyCode? event.keyCode : event.which;
		    var key = String.fromCharCode(keyCode);
		    if(!pattern.test(key))
		    {
		        event.keyCode="";
			    return false;
	        }
	    } 
	    
	    function MakeEditableRateRent(drp)
	    {
	        if(drp.options[drp.selectedIndex].innerHTML == "LIBOR Rate Schedule")
	        {
	            document.getElementById('<%=txtPercentage_RateRent.ClientID%>').disabled = false;
	        }
	        else
	        {
	            document.getElementById('<%=txtPercentage_RateRent.ClientID%>').value = '';
	            document.getElementById('<%=txtPercentage_RateRent.ClientID%>').disabled = true;
	        }
	    }
	    
	    function MakeEditableRateSubtenant(drp)
	    {
            if(drp.options[drp.selectedIndex].innerHTML == "LIBOR Rate Schedule")
            {
                document.getElementById('<%=txtPercentage_RateSubtenant.ClientID%>').disabled = false;
            }
            else
            {
                document.getElementById('<%=txtPercentage_RateSubtenant.ClientID%>').value = '';
                document.getElementById('<%=txtPercentage_RateSubtenant.ClientID%>').disabled = true;
            }
	        
	        
	    }
	    
	    function MakeEditableRateRentProjection(drp)
	    {
	        if(drp.options[drp.selectedIndex].innerHTML == "LIBOR Rate Schedule")
	        {
	            document.getElementById('<%=txtPercentage_Rate.ClientID%>').disabled = false;
	        }
	        else
	        {
	            document.getElementById('<%=txtPercentage_Rate.ClientID%>').value = '';
	            document.getElementById('<%=txtPercentage_Rate.ClientID%>').disabled = true;
	        }
	    }
	    
	    function CalculateMonthlyRent(type)
	    {
	        var txtPercent;
	        if(type == 'Rent') 
	            txtPercent = document.getElementById('<%=txtPercentage_RateRent.ClientID%>') 
	        else if(type == 'Subtenant') 
	            txtPercent = document.getElementById('<%=txtPercentage_RateSubtenant.ClientID%>') 
	        else
	            txtPercent = document.getElementById('<%=txtPercentage_Rate.ClientID%>');
	        
            if(Number(txtPercent.value) <= 100 || txtPercent.value == '')
            {
                if(document.getElementById('<%=txtLease_Commencement_Date.ClientID%>').value != '')
                {
                    if(type == 'Rent') 
                        document.getElementById('<%=btnUpdateRent_Rent.ClientID%>').click();	        
                    if(type == 'Subtenant')
                        document.getElementById('<%=btnUpdateRentSubtenant.ClientID%>').click();	        
                    else
                         document.getElementById('<%=btnUpdateRent_RentProj.ClientID%>').click();	        
                }
                else
                {
                    alert('Please enter the [Real Estate Information]/Lease Commensement Date to calculate the rents');
                    txtPercent.value = '';
                    txtPercent.focus();
                }
           }
           else
           {
                alert('Percentage Rate should be less than 100');
                txtPercent.value = '';
                txtPercent.focus();
           }
	        
	    }
	    
	    
	    
	    function AddSubTenantRentSchedule(bAdd)
	    {
	        //var bValid = (bAdd == 'Add') ? Page_ClientValidate('vsErrorGroup') : true;
	        var bValid = Page_ClientValidate('vsErrorGroup');
	        if(bValid)
	        {
	            if(AvailableLeaseDateAndEscalation('SubTenant'))
	                 return true;
	            else    
	                return false;
	        }
	        else
	            return false;
	    }
	    
	    function AddRentProjectionRentSchedule(bAdd)
	    {
	        //var bValid = (bAdd == 'Add') ? Page_ClientValidate('vsErrorGroup') : true;
	        var bValid = Page_ClientValidate('vsErrorGroup');
	        if(bValid)
	        {
	            if(AvailableLeaseDateAndEscalation('RentProjection'))
	                return true;
	            else    
	                return false;
	        }
	        else
	            return false;
	    }
	    
	    function AvailableLeaseDateAndEscalation(type)
	    {
	        var LeaseDate = document.getElementById('<%=txtLease_Commencement_Date.ClientID %>').value;
	        var Escalation; 
	        if(type == 'SubTenant')
	            Escalation = document.getElementById('<%=drpFK_LU_EscalationSubtenant.ClientID %>').value;
	        else
	            Escalation = document.getElementById('<%=drpFK_LU_Escalation.ClientID %>').value;
            
            if(LeaseDate == '') 
	        {
	            alert("An entry in [Real Estate Information]/Lease Commencement Date is required in order to add a Rent Grid Record");
	            return false;
	        }
	        else
	        {
	            if(Escalation == 0)
	            {
	               alert("An entry in " + ((type == 'SubTenant') ? "[Subtenant Information]" : "[Rent Projections]") + "/Escalation is required in order to add a Rent Grid Record");
	               return false;
	            }
	            else	        
	                return true;
	        }
	    }
	    
	    function ConfirmDelete()
	    {
	        return confirm('Are you sure you want to remove the selected data from eRIMS2? Once the data are removed, eRIMS2 does not have functionality to retrieve the data.');
	    }
	    
	    function UpdateRents()
	    {
	        var LeaseDate = document.getElementById('<%=txtLease_Commencement_Date.ClientID %>').value;
	        if(LeaseDate != '')
	        {
	            var bValid = CheckValidDate('<%=txtLease_Commencement_Date.ClientID %>');
	            if(bValid)
	            {
	                __doPostBack('LeaseDateChanged','');
	            }
	        }
	        else
	        {
	            document.getElementById('<%=lblRentLeaseCommencementDate.ClientID%>').innerHTML = '';
	            document.getElementById('<%=lblSubTenantLeaseCommencementDate.ClientID%>').innerHTML = '';
	            document.getElementById('<%=lblRentProjectionsLeaseCommencementDate.ClientID%>').innerHTML = '';
	        }	        	        
	    }
	    function ShowMessageLeaseDateError(type)
	    {
	        ShowPanel(1);
	        if(type == 'Rent')	        
    	        alert('One or more From Date in [Rent]/Renewal Rent Schedule grid is less than Lease Commencement Date. Please enter proper Lease Commencement Date.');
	        if(type == 'Subtenant')	        
	            alert('One or more From Date in [Subtenant Information]/Option Rent Schedule grid is less than Lease Commencement Date. Please enter proper Lease Commencement Date.');
	        else
	            alert('One or more From Date in [Rent Projection]/Option Rent Schedule grid is less than Lease Commencement Date. Please enter proper Lease Commencement Date.');
	        
	        document.getElementById('<%=txtLease_Commencement_Date.ClientID %>').value = '';    
	        document.getElementById('<%=txtLease_Commencement_Date.ClientID %>').focus();
	    }
	    
	    function UpdateRentMonthlyRent()
	    {
	        var LeaseDate = document.getElementById('<%=txtLease_Commencement_Date.ClientID %>').value;
	        var MonthlyRent = document.getElementById('<%=txtRentSubtenant_Monthly_Rent.ClientID%>').value;
	        if(LeaseDate != '')
	        {
	            __doPostBack('RentMonthlyRentChanged','');
	        }
	    }
	    
	    function UpdateSubtenantMonthlyRent()
	    {
	        var LeaseDate = document.getElementById('<%=txtLease_Commencement_Date.ClientID %>').value;
	        var MonthlyRent = document.getElementById('<%=txtSubtenant_Monthly_RentSubtenant.ClientID%>').value;
	        if(LeaseDate != '')
	        {
	            __doPostBack('SubtenantMonthlyRentChanged','');
	        }
	    }
	    
	    function UpdateRentProjectionMonthlyRent()
	    {
	        var LeaseDate = document.getElementById('<%=txtLease_Commencement_Date.ClientID %>').value;
	        var MonthlyRent = document.getElementById('<%=txtSubtenant_Monthly_Rent.ClientID%>').value;
	        if(LeaseDate != '')
	        {
	            __doPostBack('RentProjectionMonthlyRentChanged','');
	        }
	    }
	    
	    function CheckLeaseDate()
	    {
	        var LeaseDate = document.getElementById('<%=txtLease_Commencement_Date.ClientID %>').value;
	        if(LeaseDate == '')
	        {
	            alert("Please enter the [Real Estate Information]/Lease Commencement Date in order to manage the Rent schedule grid records.");
	            return false;
	        }
	        else
	            return true;
	    }
	    
	    function ReportPopUp()
        {
            var winHeight = window.screen.availHeight - 500;
            var winWidth = window.screen.availWidth - 800;
            
            window.open("LeaseAbstract.aspx?id=" + '<%=_PK_RE_Information%>','','width=' + 200 +',height=' + 200 + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0'); 
                      
            return false;
        }
	    
    </script>

    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <div style="width: 100%">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <uc2:RealEstate ID="RE_Tab" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%" id="tblREInfo" runat="server">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%">
                <uc2:RealEstateInfo ID="RealEstate_Info" runat="server" />
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="5" cellspacing="0" width="100%">
                                <tr>
                                    <td style="height: 18px;" class="Spacer">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Real Estate
                                            Information</span>&nbsp;<span style="color: Red">*</span>
                                    </td>
                                </tr> 
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Rent</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu3" onclick="javascript:ShowPanel(3);" class="LeftMenuStatic">Subtenant
                                            Information</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu4" onclick="javascript:ShowPanel(4);" class="LeftMenuStatic">Rent Projections</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu5" onclick="javascript:ShowPanel(5);" class="LeftMenuStatic">Security
                                            Deposit</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu6" onclick="javascript:ShowPanel(6);" class="LeftMenuStatic">Repair/Maintenance</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu7" onclick="javascript:ShowPanel(7);" class="LeftMenuStatic">Surrender
                                            Obligations</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu8" onclick="javascript:ShowPanel(8);" class="LeftMenuStatic">Notices</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu9" onclick="javascript:ShowPanel(9);" class="LeftMenuStatic">Notes</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu10" onclick="javascript:ShowPanel(10);" class="LeftMenuStatic">Attachments</span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td width="5px" class="Spacer">
                                        &nbsp;
                                    </td>
                                    <td class="dvContainer">
                                        <asp:UpdatePanel ID="updtpnl" runat="server" UpdateMode="Always">
                                            <ContentTemplate>
                                                <div id="dvEdit" runat="server" width="794px">
                                                    <asp:Panel ID="pnl1" runat="server" Style="display: none;">
                                                        <div class="bandHeaderRow">
                                                            Real Estate Information</div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="19%" valign="top">
                                                                    Dealership DBA&nbsp;<span style="color: Red">*</span>
                                                                </td>
                                                                <td align="center" width="4%" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top" colspan="4">
                                                                    <asp:DropDownList ID="drpLU_Location" runat="server" AutoPostBack="true" onchange="Page_ClientValidate('c1')"
                                                                        OnSelectedIndexChanged="drpLU_Location_SelectedIndexChanged" SkinID="dropGen"
                                                                        Width="300px" />
                                                                    <asp:RequiredFieldValidator ID="rfvDBA" runat="server" ControlToValidate="drpLU_Location"
                                                                        SetFocusOnError="true" ValidationGroup="vsErrorGroup" ErrorMessage="Please select [Real Estate Information]/Dealership DBA"
                                                                        Display="None" InitialValue="0" />
                                                                    <%--<asp:TextBox ID="txtLU_Location" runat="server" Width="530px" Enabled="false" />&nbsp;
                                                                    <img src="../../Images/dropdown_icon.gif" id="imgDBA" style="cursor: pointer;" alt=""
                                                                        onclick="javascript:return OpenDBAPopup();" />
                                                                    <input type="hidden" id="hdnLU_location" runat="server" />
                                                                    <asp:Button ID="btnDBASelectionChange" runat="server" OnClick="btnDBASelectionChange_Click"
                                                                        Style="display: none" />
                                                                    <asp:RequiredFieldValidator ID="rfvDBA" runat="server" ControlToValidate="txtLU_Location"
                                                                        SetFocusOnError="true" ValidationGroup="vsErrorGroup" ErrorMessage="Please enter [Real Estate Information]/Dealership DBA"
                                                                        Display="None" />--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <%--<td align="left" width="19%" valign="top">
                                                                    Legal Entity
                                                                </td>
                                                                <td align="center" width="4%" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" width="27%" valign="top">
                                                                    <asp:TextBox ID="txtLegalEntity" runat="server" Width="170px" Enabled="false" />
                                                                </td>--%>
                                                                <td align="left" width="20%" valign="top">
                                                                    Federal Id
                                                                </td>
                                                                <td align="center" width="4%" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" width="26%" valign="top">
                                                                    <asp:TextBox ID="txtFederal_Id" runat="server" Width="170px" MaxLength="11" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Status
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList ID="drpFK_LU_Status" Width="175px" SkinID="dropGen" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Address 1
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtAddress1" runat="server" Width="170px" Enabled="false" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Address 2
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtAddress2" runat="server" Width="170px" Enabled="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    City
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtCity" runat="server" Width="170px" Enabled="false" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    State
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtState" runat="server" Width="170px" Enabled="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Zip Code (XXXXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtZipCode" runat="server" Width="170px" Enabled="false" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Telephone (XXX-XXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTelephone" runat="server" Width="170px" Enabled="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    County
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtCounty" runat="server" Width="170px" Enabled="false" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Region
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtRegion" runat="server" Width="170px" Enabled="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Tax Parcel Number
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTax_Parcel_Number" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Lease Type
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList ID="drpFK_LU_Lease_Type" Width="175px" SkinID="dropGen" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Landlord
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Landlord Location Address 1
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Location_Address1" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Landlord Location Address 2
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Location_Address2" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Landlord Location City
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Location_City" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Landlord Location State
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList ID="drpLandlord_Location_State" runat="server" SkinID="dropGen"
                                                                        Width="175px" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Landlord Location Zip Code (XXXXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Location_Zip_Code" runat="server" Width="170px" MaxLength="10"
                                                                        onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="revZipCode" ControlToValidate="txtLandlord_Location_Zip_Code"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Real Estate Information]/Landlord Location Zip Code in xxxxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Landlord Mailing Address 1
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Mailing_Address1" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Landlord Mailing Address 2
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Mailing_Address2" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Landlord Mailing City
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Mailing_City" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Landlord Mailing State
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList ID="drpLandlordMailingState" runat="server" Width="175px" SkinID="dropGen" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Landlord Mailing Zip Code (XXXXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Mailing_Zip_Code" runat="server" Width="170px" MaxLength="10"
                                                                        onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtLandlord_Mailing_Zip_Code"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Real Estate Information]/Landlord Mailing Zip Code in xxxxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Landlord Telephone (XXX-XXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Telephone" runat="server" Width="170px" MaxLength="12"
                                                                        onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="revTelephone" ControlToValidate="txtLandlord_Telephone"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Real Estate Information]/Landlord Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Landlord E-Mail
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Email" runat="server" Width="170px" MaxLength="255" />
                                                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtLandlord_Email"
                                                                        ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="[Real Estate Information]/Landlord E-Mail Address Is Invalid"
                                                                        SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Sublease?
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:RadioButtonList ID="rdoSublease" runat="server" SkinID="YesNoType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Subtenant
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Lease Id
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLease_Id" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Lease Commencement Date
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLease_Commencement_Date" runat="server" Width="145px" onblur="UpdateRents();"
                                                                        onChange="UpdateRents();" />
                                                                    <img alt="Lease Commencement Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLease_Commencement_Date', 'mm/dd/y',setTextFoucs,'ctl00_ContentPlaceHolder1_txtLease_Commencement_Date');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <cc1:MaskedEditExtender ID="mskLease_Commencement_Date" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtLease_Commencement_Date"
                                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <cc1:MaskedEditValidator ID="mskvLease_Commencement_Date" runat="server" ControlExtender="mskLease_Commencement_Date"
                                                                        ControlToValidate="txtLease_Commencement_Date" Display="none" IsValidEmpty="true"
                                                                        Enabled="false" MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                        MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                    <asp:RegularExpressionValidator ID="revLease_Commencement_Date" runat="server" ControlToValidate="txtLease_Commencement_Date"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                        ErrorMessage="Please Enter [Real Estate Information]/Lease Commencement Date in valid format"
                                                                        Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Project Type
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList ID="drpFK_LU_Project_Type" Width="175px" SkinID="dropGen" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Lease Expiration Date
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLease_Expiration_Date" runat="server" Width="145px" />
                                                                    <img alt="Lease Expiration Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLease_Expiration_Date', 'mm/dd/y',setTextFoucs,'ctl00_ContentPlaceHolder1_txtLease_Expiration_Date')"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <cc1:MaskedEditExtender ID="mskLease_Expiration_Date" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtLease_Expiration_Date"
                                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <cc1:MaskedEditValidator ID="mskvLease_Expiration_Date" runat="server" ControlExtender="mskLease_Expiration_Date"
                                                                        ControlToValidate="txtLease_Expiration_Date" Display="none" IsValidEmpty="true"
                                                                        Enabled="false" MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                        MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtLease_Expiration_Date"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                        ErrorMessage="Please Enter [Real Estate Information]/Lease Expiration Date in valid format"
                                                                        Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Date Acquired
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtDate_Acquired" runat="server" Width="145px" />
                                                                    <img alt="Date Acquired" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Acquired', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <cc1:MaskedEditExtender ID="mskDate_Acquired" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDate_Acquired"
                                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <cc1:MaskedEditValidator ID="mskvDate_Acquired" runat="server" ControlExtender="mskDate_Acquired"
                                                                        ControlToValidate="txtDate_Acquired" Display="none" IsValidEmpty="true" Enabled="false"
                                                                        MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                        MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtDate_Acquired"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                        ErrorMessage="Please Enter [Real Estate Information]/Date Acquired in valid format"
                                                                        Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Lease Term In Months
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLease_Term_Months" runat="server" Width="170px" onpaste="return false" onkeypress="return FormatNumber(event,this.id,4,true);" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Date Sold
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtDate_Sold" runat="server" Width="145px" />
                                                                    <img alt="Date Sold" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Sold', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <cc1:MaskedEditExtender ID="mskDate_Sold" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtDate_Sold" CultureName="en-US"
                                                                        AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <cc1:MaskedEditValidator ID="mskvDate_Sold" runat="server" ControlExtender="mskDate_Sold"
                                                                        ControlToValidate="txtDate_Sold" Display="none" IsValidEmpty="true" Enabled="false"
                                                                        MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                        MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtDate_Sold"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                        ErrorMessage="Please Enter [Real Estate Information]/Date Sold in valid format"
                                                                        Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Prior Lease Commencement Date
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtPrior_Lease_Commencement_Date" runat="server" Width="145px" />
                                                                    <img alt="Prior Lease Commencement Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPrior_Lease_Commencement_Date', 'mm/dd/y',setTextFoucs,'ctl00_ContentPlaceHolder1_txtPrior_Lease_Commencement_Date');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <cc1:MaskedEditExtender ID="mskPrior_Lease_Commencement_Date" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtPrior_Lease_Commencement_Date"
                                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <cc1:MaskedEditValidator ID="mskvPrior_Lease_Commencement_Date" runat="server" ControlExtender="mskPrior_Lease_Commencement_Date"
                                                                        ControlToValidate="txtPrior_Lease_Commencement_Date" Display="none" IsValidEmpty="true"
                                                                        Enabled="false" MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                        MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtPrior_Lease_Commencement_Date"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                        ErrorMessage="Please Enter [Real Estate Information]/Prior Lease Commencement Date in valid format"
                                                                        Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Renewals
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtRenewals" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Year Built
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtYear_Built" runat="server" Width="170px" MaxLength="4" onkeypress="return isValid(this);"
                                                                        onblur="YearValidate(this.id);" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Reminder Date
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtReminder_Date" runat="server" Width="145px" />
                                                                    <img alt="Reminder Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtReminder_Date', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <cc1:MaskedEditExtender ID="mskReminder_Date" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtReminder_Date"
                                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <cc1:MaskedEditValidator ID="mskvReminder_Date" runat="server" ControlExtender="mskReminder_Date"
                                                                        ControlToValidate="txtReminder_Date" Display="none" IsValidEmpty="true" Enabled="false"
                                                                        MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                        MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtReminder_Date"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                        ErrorMessage="Please Enter [Real Estate Information]/Reminder Date in valid format"
                                                                        Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Year Remodeled
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtYear_Remodeled" runat="server" Width="170px" MaxLength="4" onkeypress="return isValid(this);"
                                                                        onblur="YearValidate(this.id);" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Landlord Notification Date
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Notification_Date" runat="server" Width="145px" />
                                                                    <img alt="Landlord Notification Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLandlord_Notification_Date', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <cc1:MaskedEditExtender ID="mskLandlord_Notification_Date" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtLandlord_Notification_Date"
                                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <cc1:MaskedEditValidator ID="mskvLandlord_Notification_Date" runat="server" ControlExtender="mskLandlord_Notification_Date"
                                                                        ControlToValidate="txtLandlord_Notification_Date" Display="none" IsValidEmpty="true"
                                                                        Enabled="false" MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                        MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtLandlord_Notification_Date"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                        ErrorMessage="Please Enter [Real Estate Information]/Landlord Notification Date in valid format"
                                                                        Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Regional Vice President
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtRegional_Vice_President" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Vacate Date
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtVacate_Date" runat="server" Width="145px" />
                                                                    <img alt="Vacate Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtVacate_Date', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <cc1:MaskedEditExtender ID="mskVacate_Date" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtVacate_Date"
                                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <cc1:MaskedEditValidator ID="mskvVacate_Date" runat="server" ControlExtender="mskVacate_Date"
                                                                        ControlToValidate="txtVacate_Date" Display="none" IsValidEmpty="true" Enabled="false"
                                                                        MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                        MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtVacate_Date"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                        ErrorMessage="Please Enter [Real Estate Information]/Vacate Date in valid format"
                                                                        Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    General Manager
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtGeneral_Manager" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Primary Use
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtPrimary_Use" runat="server" Width="170px" MaxLength="125" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Controller
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtController" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Lease Codes
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLease_Codes" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Loss Control Manager
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLoss_Control_Manager" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Total Acres
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTotal_Acres" runat="server" Width="170px" onpaste="return false" onkeypress="return FormatNumber(event,this.id,4,true);" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Number of Buildings
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtNumber_of_Buildings" runat="server" Width="170px" onpaste="return false" onkeypress="return FormatNumber(event,this.id,4,true);" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Total Gross Leasable Area (square feet)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTotal_Gross_Leaseable_Area" runat="server" Width="170px" onpaste="return false" onkeypress="return FormatNumber(event,this.id,9,true);" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Land Value
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    $&nbsp;
                                                                    <asp:TextBox ID="txtLand_Value" runat="server" Width="160px" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnl2" runat="server" Style="display: none;">
                                                        <div class="bandHeaderRow">
                                                            Rent</div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">
                                                                    Responsible Party
                                                                </td>
                                                                <td align="center" width="4%" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:TextBox ID="txtResponsible_PartyRent" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                                <td align="left" width="18%" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" width="4%" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" width="28%" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Lease Commencement Date
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblRentLeaseCommencementDate" runat="server" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Lease Term in Months
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblRentLeaseTerm" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Lease Expiration Date
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblRentLeaseExpDate" runat="server" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Prior Lease Commencement Date
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblRentPriorLeaseDate" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">
                                                                    Cancel Options
                                                                </td>
                                                                <td align="center" width="4%" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="txtCancel_OptionsRent" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Renew Options
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="txtRenew_OptionsRent" runat="server" />
                                                                </td>
                                                            </tr>                                                           
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Renewal Notification Due Date
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtNotification_Due_DateRent" runat="server" Width="145px" />
                                                                    <img alt="Notification Due Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtNotification_Due_DateRent', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <cc1:MaskedEditExtender ID="mskNotification_Due_DateRent" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtNotification_Due_DateRent"
                                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <cc1:MaskedEditValidator ID="mskvNotification_Due_DateRent" runat="server" ControlExtender="mskNotification_Due_DateRent"
                                                                        ControlToValidate="txtNotification_Due_DateRent" Display="none" IsValidEmpty="true"
                                                                        Enabled="false" MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                        MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                                        ControlToValidate="txtNotification_Due_DateRent" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                        ErrorMessage="Please Enter [Rent]/Renewal Notification Due Date in valid format"
                                                                        Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Subtenant Base Rent
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    $&nbsp;<asp:TextBox ID="txtRentSubtenant_Base_Rent" runat="server" Width="160px" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Subtenant Monthly Rent
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    $&nbsp;<asp:TextBox ID="txtRentSubtenant_Monthly_Rent" runat="server" Width="160px" onpaste="return false" onkeypress="return FormatNumber(event,this.id,9,false);"
                                                                        onchange="UpdateRentMonthlyRent();" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Escalation
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList ID="drpFK_LU_EscalationRent" Width="175px" SkinID="dropGen" runat="server"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="drpFK_LU_EscalationRent_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Percentage Rate
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtPercentage_RateRent" Enabled="false" runat="server" Width="170px"
                                                                        onpaste="return false" onkeypress="return FormatNumber(event,this.id,5,false);" onchange="CalculateMonthlyRent('Rent');" />
                                                                    <asp:Button ID="btnUpdateRent_Rent" runat="server" Style="display: none" CausesValidation="false"
                                                                        OnClick="btnUpdateRent_Rent_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Increase
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtIncreaseRent" runat="server" Width="170px" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Term Rent Schedule Grid<br />
                                                                    <asp:LinkButton ID="lnkAddTRSRent" runat="server" OnClientClick="javascript:return AddRentTermRentSchedule('Add');"
                                                                        OnClick="lnkAddTRSRent_Click" CausesValidation="false">--Add--</asp:LinkButton>
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top" colspan="4">
                                                                    <asp:GridView ID="gvRentTRS" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                        OnRowCommand="gvRentTRS_RowCommand">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Year">
                                                                                <ItemStyle Width="10%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkYear" runat="server" Text='<%#Eval("Year")%>' CommandName="ShowDetails"
                                                                                        CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>' OnClientClick="javascript:return AddRentRenewalRentSchedule('Edit');" />
                                                                                    <input type="hidden" id="hdnPK_Rent_TRS" runat="server" value='<%#Eval("PK_RE_Rent_TRS") %>' />
                                                                                    <input type="hidden" id="hdnPercentage" runat="server" value='<%#Eval("Percentage_Rate") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="From">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkFrom" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%>'
                                                                                        CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>'
                                                                                        OnClientClick="javascript:return AddRentTermRentSchedule('Edit');" /></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="To">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkTo" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%>'
                                                                                        CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>'
                                                                                        OnClientClick="javascript:return AddRentTermRentSchedule('Edit');" /></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Months">
                                                                                <ItemStyle Width="10%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkMonths" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Months", "{0:N1}")%>'
                                                                                        CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>'
                                                                                        OnClientClick="javascript:return AddRentTermRentSchedule('Edit');" /></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Additions" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkAdditions" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Additions"))%>'
                                                                                        CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>'
                                                                                        OnClientClick="javascript:return AddRentTermRentSchedule('Edit');" /></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Total Monthly Rent" ItemStyle-HorizontalAlign="Right"
                                                                                HeaderStyle-HorizontalAlign="Right">
                                                                                <ItemStyle Width="20%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkMonthlyRent" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%>'
                                                                                        CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>'
                                                                                        OnClientClick="javascript:return AddRentTermRentSchedule('Edit');" /></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" Visible="false" CommandName="RemoveTRS"
                                                                                        CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>' OnClientClick="return ConfirmDelete();" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Renewal Rent Schedule Grid<br />
                                                                    <asp:LinkButton ID="lnkAddRRSRent" runat="server" OnClientClick="javascript:return AddRentRenewalRentSchedule('Add');"
                                                                        OnClick="lnkAddRRSRent_Click">--Add--</asp:LinkButton>
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top" colspan="4">
                                                                    <asp:GridView ID="gvRentRRS" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                        OnRowCommand="gvRentRRS_RowCommand">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Option">
                                                                                <ItemStyle Width="13%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkOption" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_RRS") %>'
                                                                                        CommandName="ShowDetails" Text='<%#Eval("Option_Period")%>' OnClientClick="javascript:return AddRentRenewalRentSchedule();"></asp:LinkButton>
                                                                                    <input type="hidden" id="hdnPK_Rent_RRS" runat="server" value='<%#Eval("PK_RE_Rent_RRS") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="From">
                                                                                <ItemStyle Width="18%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkFromDate" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_RRS") %>'
                                                                                        CommandName="ShowDetails" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%>'
                                                                                        OnClientClick="javascript:return AddRentRenewalRentSchedule('Edit');"></asp:LinkButton></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="To">
                                                                                <ItemStyle Width="18%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkToDate" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_RRS") %>'
                                                                                        CommandName="ShowDetails" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%>'
                                                                                        OnClientClick="javascript:return AddRentRenewalRentSchedule('Edit');"></asp:LinkButton></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Months">
                                                                                <ItemStyle Width="13%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkMonths" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_RRS") %>'
                                                                                        CommandName="ShowDetails" Text='<%#DataBinder.Eval(Container.DataItem,"Months", "{0:N1}")%>'
                                                                                        OnClientClick="javascript:return AddRentRenewalRentSchedule('Edit');"></asp:LinkButton></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Base Monthly Rent" ItemStyle-HorizontalAlign="Right"
                                                                                HeaderStyle-HorizontalAlign="Right">
                                                                                <ItemStyle Width="23%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkMonthlyRent" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_RRS") %>'
                                                                                        CommandName="ShowDetails" Text='<%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%>'
                                                                                        OnClientClick="javascript:return AddRentRenewalRentSchedule('Edit');"></asp:LinkButton></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" Visible="false" CommandArgument='<%#Eval("PK_RE_Rent_RRS") %>'
                                                                                        CommandName="RemoveRRS" OnClientClick="return ConfirmDelete();" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnl3" runat="server" Style="display: none;">
                                                        <div class="bandHeaderRow">
                                                            Subtenant Information</div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="19%" valign="top">
                                                                    Subtenant/DBA
                                                                </td>
                                                                <td align="center" width="4%" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" width="27%" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_DBA" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                                <td align="left" width="19%" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" width="4%" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" width="27%" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="19%" valign="top">
                                                                    Subtenant Mailing Address 1
                                                                </td>
                                                                <td align="center" width="4%" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" width="27%" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_Mailing_Address1" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Subtenant Mailing Address 2
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_Mailing_Address2" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Subtenant Mailing City
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_Mailing_City" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Subtenant Mailing State
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList ID="drpSubtenantMailingState" runat="server" Width="175px" SkinID="dropGen" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Subtenant Mailing Zip Code (XXXXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_Mailing_Zip_Code" runat="server" Width="170px" MaxLength="10"
                                                                        onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="revSubtenant_Mailing_Zip_Code" ControlToValidate="txtSubtenant_Mailing_Zip_Code"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Subtenant Information]/Subtenant Mailing Zip Code in xxxxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Subtenant Telephone
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenantTelephone" runat="server" Width="170px" MaxLength="12"
                                                                        onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="revSubtenantTelephone" ControlToValidate="txtSubtenantTelephone"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Subtenant Information]/Subtenant Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Lease Commencement Date
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblSubTenantLeaseCommencementDate" runat="server" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Lease Term in Months
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblSubTenantLeaseTerm" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Lease Expiration Date
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblSubTenantLeaseExpDate" runat="server" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Prior Lease Commencement Date
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblSubTenantPriorLeaseDate" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Cancel Options
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="txtCancel_OptionsSubtenant" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Renew Options
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="txtRenew_OptionsSubtenant" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Option Notification
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="txtOpen_NotificationSubtenant" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Notification Due Date
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtNotification_Due_DateSubtenant" runat="server" Width="145px" />
                                                                    <img alt="Notification Due Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtNotification_Due_DateSubtenant', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <cc1:MaskedEditExtender ID="mskNotification_Due_DateSubtenant" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtNotification_Due_DateSubtenant"
                                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <cc1:MaskedEditValidator ID="mskvNotification_Due_DateSubtenant" runat="server" ControlExtender="mskNotification_Due_DateSubtenant"
                                                                        ControlToValidate="txtNotification_Due_DateSubtenant" Display="none" IsValidEmpty="true"
                                                                        Enabled="false" MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                        MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtNotification_Due_DateSubtenant"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                        ErrorMessage="Please Enter [Subtenant Information]/Notification Due Date in valid format"
                                                                        Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Subtenant Base Rent
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    $&nbsp;<asp:TextBox ID="txtSubtenant_Base_RentSubtenant" runat="server" Width="160px"
                                                                        onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Subtenant Monthly Rent
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    $&nbsp;<asp:TextBox ID="txtSubtenant_Monthly_RentSubtenant" runat="server" Width="160px"
                                                                        onpaste="return false" onkeypress="return FormatNumber(event,this.id,9,false);" onchange="UpdateSubtenantMonthlyRent();" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Escalation
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList ID="drpFK_LU_EscalationSubtenant" Width="175px" SkinID="dropGen"
                                                                        runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpFK_LU_EscalationSubtenant_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Percentage Rate
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtPercentage_RateSubtenant" runat="server" Width="170px" Enabled="false"
                                                                        onpaste="return false" onkeypress="return FormatNumber(event,this.id,5,false);" onchange="CalculateMonthlyRent('Subtenant');" />
                                                                    <asp:Button ID="btnUpdateRentSubtenant" runat="server" Style="display: none" CausesValidation="false"
                                                                        OnClick="btnUpdateRentSubtenant_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Increase
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtIncreaseSubtenant" runat="server" Width="170px" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Term Rent Schedule Grid<br />
                                                                    <asp:LinkButton ID="lnkAddTRSSubTenant" runat="server" OnClientClick="javascript:return AddSubTenantRentSchedule('Add');"
                                                                        OnClick="lnkAddTRSSubTenant_Click" CausesValidation="false">--Add--</asp:LinkButton>
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top" colspan="4">
                                                                    <asp:GridView ID="gvSubtenantTRS" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                        OnRowCommand="gvSubtenantTRS_RowCommand">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Year">
                                                                                <ItemStyle Width="10%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkYear" runat="server" Text='<%#Eval("Year")%>' CommandName="ShowDetails"
                                                                                        CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>' OnClientClick="javascript:return AddSubTenantRentSchedule('Edit');" />
                                                                                    <input type="hidden" id="hdnPK_subtenant_TRS" runat="server" value='<%#Eval("PK_RE_Subtenant_TRS") %>' />
                                                                                    <input type="hidden" id="hdnPercentage" runat="server" value='<%#Eval("Percentage_Rate") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="From">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkFrom" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%>'
                                                                                        CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>'
                                                                                        OnClientClick="javascript:return AddSubTenantRentSchedule('Edit');" /></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="To">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkTo" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%>'
                                                                                        CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>'
                                                                                        OnClientClick="javascript:return AddSubTenantRentSchedule('Edit');" /></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Months">
                                                                                <ItemStyle Width="10%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkMonths" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Months", "{0:N1}")%>'
                                                                                        CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>'
                                                                                        OnClientClick="javascript:return AddSubTenantRentSchedule('Edit');" /></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Additions" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkAdditions" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Additions"))%>'
                                                                                        CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>'
                                                                                        OnClientClick="javascript:return AddSubTenantRentSchedule('Edit');" /></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Total Monthly Rent" ItemStyle-HorizontalAlign="Right"
                                                                                HeaderStyle-HorizontalAlign="Right">
                                                                                <ItemStyle Width="20%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkMonthlyRent" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%>'
                                                                                        CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>'
                                                                                        OnClientClick="javascript:return AddSubTenantRentSchedule('Edit');" /></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" Visible="false" CommandName="RemoveTRS"
                                                                                        CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>' OnClientClick="return ConfirmDelete();" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Option Rent Schedule Grid<br />
                                                                    <asp:LinkButton ID="lnkAddORSSubTenant" runat="server" OnClientClick="javascript:return AddSubTenantRentSchedule('Add');"
                                                                        OnClick="lnkAddORSSubTenant_Click">--Add--</asp:LinkButton>
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top" colspan="4">
                                                                    <asp:GridView ID="gvSubtenantORS" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                        OnRowCommand="gvSubtenantORS_RowCommand">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Option">
                                                                                <ItemStyle Width="13%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkOption" runat="server" CommandArgument='<%#Eval("PK_RE_SubTenant_ORS") %>'
                                                                                        CommandName="ShowDetails" Text='<%#Eval("Option_Period")%>' OnClientClick="javascript:return AddSubTenantRentSchedule('Edit');"></asp:LinkButton>
                                                                                    <input type="hidden" id="hdnPK_subtenant_ORS" runat="server" value='<%#Eval("PK_RE_SubTenant_ORS") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="From">
                                                                                <ItemStyle Width="18%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkFromDate" runat="server" CommandArgument='<%#Eval("PK_RE_SubTenant_ORS") %>'
                                                                                        CommandName="ShowDetails" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%>'
                                                                                        OnClientClick="javascript:return AddSubTenantRentSchedule('Edit');"></asp:LinkButton></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="To">
                                                                                <ItemStyle Width="18%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkToDate" runat="server" CommandArgument='<%#Eval("PK_RE_SubTenant_ORS") %>'
                                                                                        CommandName="ShowDetails" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%>'
                                                                                        OnClientClick="javascript:return AddSubTenantRentSchedule('Edit');"></asp:LinkButton></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Months">
                                                                                <ItemStyle Width="13%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkMonths" runat="server" CommandArgument='<%#Eval("PK_RE_SubTenant_ORS") %>'
                                                                                        CommandName="ShowDetails" Text='<%#DataBinder.Eval(Container.DataItem,"Months", "{0:N1}")%>'
                                                                                        OnClientClick="javascript:return AddSubTenantRentSchedule('Edit');"></asp:LinkButton></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Base Monthly Rent" ItemStyle-HorizontalAlign="Right"
                                                                                HeaderStyle-HorizontalAlign="Right">
                                                                                <ItemStyle Width="23%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkMonthlyRent" runat="server" CommandArgument='<%#Eval("PK_RE_SubTenant_ORS") %>'
                                                                                        CommandName="ShowDetails" Text='<%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%>'
                                                                                        OnClientClick="javascript:return AddSubTenantRentSchedule('Edit');"></asp:LinkButton></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" Visible="false" CommandArgument='<%#Eval("PK_RE_SubTenant_ORS") %>'
                                                                                        CommandName="RemoveORS" OnClientClick="return ConfirmDelete();" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnl4" runat="server" Style="display: none;">
                                                        <div class="bandHeaderRow">
                                                            Rent Projections</div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">
                                                                    Responsible Party
                                                                </td>
                                                                <td align="center" width="4%" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:TextBox ID="txtResponsible_Party" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                                <td align="left" width="18%" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" width="4%" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" width="28%" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Lease Commencement Date
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblRentProjectionsLeaseCommencementDate" runat="server" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Lease Term in Months
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblRentProjectionsLeaseTerm" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Lease Expiration Date
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblRentProjectionsLeaseExpDate" runat="server" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Prior Lease Commencement Date
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblRentProjectionsPriorLeaseDate" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">
                                                                    Cancel Options
                                                                </td>
                                                                <td align="center" width="4%" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="txtCancel_Options" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Renew Options
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="txtRenew_Options" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Option Notification
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="txtOpen_Notification" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Notification Due Date
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtNotification_Due_Date" runat="server" Width="145px" />
                                                                    <img alt="Notification Due Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtNotification_Due_Date', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <cc1:MaskedEditExtender ID="mskNotification_Due_Date" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtNotification_Due_Date"
                                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <cc1:MaskedEditValidator ID="mskvNotification_Due_Date" runat="server" ControlExtender="mskNotification_Due_Date"
                                                                        ControlToValidate="txtNotification_Due_Date" Display="none" IsValidEmpty="true"
                                                                        Enabled="false" MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                        MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                                                        ControlToValidate="txtNotification_Due_Date" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                        ErrorMessage="Please Enter [Rent Projections]/Notification Due Date in valid format"
                                                                        Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Subtenant Base Rent
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    $&nbsp;<asp:TextBox ID="txtSubtenant_Base_Rent" runat="server" Width="160px" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Subtenant Monthly Rent
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    $&nbsp;<asp:TextBox ID="txtSubtenant_Monthly_Rent" runat="server" Width="160px" onpaste="return false" onkeypress="return FormatNumber(event,this.id,9,false);"
                                                                        onchange="UpdateRentProjectionMonthlyRent();" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Escalation
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList ID="drpFK_LU_Escalation" Width="175px" SkinID="dropGen" runat="server"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="drpFK_LU_Escalation_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Percentage Rate
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtPercentage_Rate" Enabled="false" runat="server" Width="170px"
                                                                        onpaste="return false" onkeypress="return FormatNumber(event,this.id,5,false);" onchange="CalculateMonthlyRent('RentProjection');" />
                                                                    <asp:Button ID="btnUpdateRent_RentProj" runat="server" Style="display: none" CausesValidation="false"
                                                                        OnClick="btnUpdateRent_RentProj_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Increase
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtIncrease" runat="server" Width="170px" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Term Rent Schedule Grid<br />
                                                                    <asp:LinkButton ID="lnkAddTRSRentProjection" runat="server" OnClientClick="javascript:return AddRentProjectionRentSchedule('Add');"
                                                                        OnClick="lnkAddTRSRentProjection_Click" CausesValidation="false">--Add--</asp:LinkButton>
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top" colspan="4">
                                                                    <asp:GridView ID="gvRentProjectionTRS" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                        OnRowCommand="gvRentProjectionTRS_RowCommand">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Year">
                                                                                <ItemStyle Width="10%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkYear" runat="server" Text='<%#Eval("Year")%>' CommandName="ShowDetails"
                                                                                        CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>' OnClientClick="javascript:return AddRentProjectionRentSchedule('Edit');" />
                                                                                    <input type="hidden" id="hdnPK_RentProjection_TRS" runat="server" value='<%#Eval("PK_RE_Rent_Projctions_TRS") %>' />
                                                                                    <input type="hidden" id="hdnPercentage" runat="server" value='<%#Eval("Percentage_Rate") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="From">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkFrom" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%>'
                                                                                        CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>'
                                                                                        OnClientClick="javascript:return AddRentProjectionRentSchedule('Edit');" /></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="To">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkTo" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%>'
                                                                                        CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>'
                                                                                        OnClientClick="javascript:return AddRentProjectionRentSchedule('Edit');" /></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Months">
                                                                                <ItemStyle Width="10%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkMonths" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Months", "{0:N1}")%>'
                                                                                        CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>'
                                                                                        OnClientClick="javascript:return AddRentProjectionRentSchedule('Edit');" /></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Additions" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkAdditions" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Additions"))%>'
                                                                                        CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>'
                                                                                        OnClientClick="javascript:return AddRentProjectionRentSchedule('Edit');" /></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Total Monthly Rent" ItemStyle-HorizontalAlign="Right"
                                                                                HeaderStyle-HorizontalAlign="Right">
                                                                                <ItemStyle Width="20%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkMonthlyRent" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%>'
                                                                                        CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>'
                                                                                        OnClientClick="javascript:return AddRentProjectionRentSchedule('Edit');" /></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" Visible="false" CommandName="RemoveTRS"
                                                                                        CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>' OnClientClick="return ConfirmDelete();" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Option Rent Schedule Grid<br />
                                                                    <asp:LinkButton ID="lnkAddORSRentProjection" runat="server" OnClientClick="javascript:return AddRentProjectionRentSchedule('Add');"
                                                                        OnClick="lnkAddORSRentProjection_Click">--Add--</asp:LinkButton>
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top" colspan="4">
                                                                    <asp:GridView ID="gvRentProjectionORS" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                        OnRowCommand="gvRentProjectionORS_RowCommand">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Option">
                                                                                <ItemStyle Width="13%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkOption" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_Projections_ORS") %>'
                                                                                        CommandName="ShowDetails" Text='<%#Eval("Option_Period")%>' OnClientClick="javascript:return AddRentProjectionRentSchedule();"></asp:LinkButton>
                                                                                    <input type="hidden" id="hdnPK_RentProjection_ORS" runat="server" value='<%#Eval("PK_RE_Rent_Projections_ORS") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="From">
                                                                                <ItemStyle Width="18%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkFromDate" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_Projections_ORS") %>'
                                                                                        CommandName="ShowDetails" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%>'
                                                                                        OnClientClick="javascript:return AddRentProjectionRentSchedule('Edit');"></asp:LinkButton></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="To">
                                                                                <ItemStyle Width="18%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkToDate" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_Projections_ORS") %>'
                                                                                        CommandName="ShowDetails" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%>'
                                                                                        OnClientClick="javascript:return AddRentProjectionRentSchedule('Edit');"></asp:LinkButton></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Months">
                                                                                <ItemStyle Width="13%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkMonths" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_Projections_ORS") %>'
                                                                                        CommandName="ShowDetails" Text='<%#DataBinder.Eval(Container.DataItem,"Months", "{0:N1}")%>'
                                                                                        OnClientClick="javascript:return AddRentProjectionRentSchedule('Edit');"></asp:LinkButton></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Base Monthly Rent" ItemStyle-HorizontalAlign="Right"
                                                                                HeaderStyle-HorizontalAlign="Right">
                                                                                <ItemStyle Width="23%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkMonthlyRent" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_Projections_ORS") %>'
                                                                                        CommandName="ShowDetails" Text='<%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%>'
                                                                                        OnClientClick="javascript:return AddRentProjectionRentSchedule('Edit');"></asp:LinkButton></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" Visible="false" CommandArgument='<%#Eval("PK_RE_Rent_Projections_ORS") %>'
                                                                                        CommandName="RemoveORS" OnClientClick="return ConfirmDelete();" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnl5" runat="server" Style="display: none;">
                                                        <div class="bandHeaderRow">
                                                            Security Deposit</div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">
                                                                    Amount
                                                                </td>
                                                                <td align="center" width="4%" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    $&nbsp;<asp:TextBox ID="txtAmount" runat="server" Width="160px" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);" />
                                                                </td>
                                                                <td align="left" width="18%" valign="top">
                                                                    Date of Security Deposit
                                                                </td>
                                                                <td align="center" width="4%" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:TextBox ID="txtDate_Of_Security_Deposit" runat="server" Width="145px" />
                                                                    <img alt="Date of Security Deposit" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Of_Security_Deposit', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <cc1:MaskedEditExtender ID="mskDate_Of_Security_Deposit" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDate_Of_Security_Deposit"
                                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <cc1:MaskedEditValidator ID="mskvDate_Of_Security_Deposit" runat="server" ControlExtender="mskDate_Of_Security_Deposit"
                                                                        ControlToValidate="txtDate_Of_Security_Deposit" Display="none" IsValidEmpty="true"
                                                                        Enabled="false" MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                        MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                                                        ControlToValidate="txtDate_Of_Security_Deposit" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                        ErrorMessage="Please Enter [Security Deposit]/Date of Security Deposit in valid format"
                                                                        Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Tender Type
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList ID="drpFK_LU_Tender_Type" Width="175px" SkinID="dropGen" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Received By
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtReceived_By" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    <b>If Paid By Check</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Bank Name the Check was Drawn Against
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtBank_Name" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Check Number
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtCheck_Number" runat="server" Width="170px" onkeypress="return FormatInteger(event);"
                                                                        MaxLength="6" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Name Printed on Check
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtName_On_Check" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Account Number
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtAccount_Number" runat="server" Width="170px" onkeypress="return FormatInteger(event);"
                                                                        MaxLength="20" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Security Deposit Held At
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList ID="drpFK_LU_Security_Deposit_Held" Width="175px" SkinID="dropGen"
                                                                        runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Security Deposit Returned?
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:RadioButtonList ID="rdoSecurity_Deposit_Returned" runat="server" SkinID="YesNoType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Date Security Deposit Returned
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtDate_Security_Deposit_Returned" runat="server" Width="145px" />
                                                                    <img alt="Date Security Deposit Returned" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Security_Deposit_Returned', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <cc1:MaskedEditExtender ID="mskDate_Security_Deposit_Returned" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDate_Security_Deposit_Returned"
                                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <cc1:MaskedEditValidator ID="mskvDate_Security_Deposit_Returned" runat="server" ControlExtender="mskDate_Security_Deposit_Returned"
                                                                        ControlToValidate="txtDate_Security_Deposit_Returned" Display="none" IsValidEmpty="true"
                                                                        Enabled="false" MaximumValue="" InvalidValueMessage="Date is invalid." MaximumValueMessage=""
                                                                        MinimumValueMessage="" TooltipMessage="" MinimumValue=""></cc1:MaskedEditValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                                                        ControlToValidate="txtDate_Security_Deposit_Returned" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                        ErrorMessage="Please Enter [Security Deposit]/Date Security Deposit Returned in valid format"
                                                                        Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Security Deposit Reduced?
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:RadioButtonList ID="rdoSecurity_Deposit_Reduced" runat="server" SkinID="YesNoType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Reason for Security Deposit Reduction
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="txtSecurity_Deposit_Reduction_Reason" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Any Interest to be Realized on Security Deposit?
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:RadioButtonList ID="rdoInterest_On_Security_Deposit" runat="server" SkinID="YesNoType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Interest Amount
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    $&nbsp;<asp:TextBox ID="txtInterest_Amount" runat="server" Width="160px" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Amount of Security Deposit Returned
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    $&nbsp;
                                                                    <asp:TextBox ID="txtAmount_Security_Deposit_Returned" runat="server" Width="170px"
                                                                        onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnl6" runat="server" Style="display: none;">
                                                        <div class="bandHeaderRow">
                                                            Repair/Maintenance</div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="18%" valign="top" >
                                                                    Repair/Maintenance Grid<br />
                                                                    <asp:LinkButton ID="lnkAddRepairMaint" runat="server" Text="--Add--" ValidationGroup="vsErrorGroup"
                                                                        CausesValidation="true" OnClick="lnkAddRepairMaint_Click" />
                                                                </td>
                                                                <td align="center" width="4%" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <div style="width: 600px; overflow-x: scroll; overflow-y: hidden;">
                                                                        <asp:GridView ID="gvRepairMaintenance" runat="server" EmptyDataText="No Record Found"
                                                                            Width="1300px" OnRowCommand="gvRepairMaintenance_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Repair Type">
                                                                                    <ItemStyle Width="100px" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkRepairType" runat="server" Text='<%#Eval("Repair_Type")%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="PCA Conducted">
                                                                                    <ItemStyle Width="100px" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkPCADate" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_PCA_Conducted")) %>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Scope of Work">
                                                                                    <ItemStyle Width="100px" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkScopeOfWork" runat="server" Text='<%#Eval("Work_Scope") %>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Detail">
                                                                                    <ItemStyle Width="100px" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkDetail" runat="server" Text='<%# Eval("Detailed_Description")%>'
                                                                                            CssClass="TextClip" Width="90px" CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Contractor">
                                                                                    <ItemStyle Width="100px" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkContractor" runat="server" Text='<%#Eval("Contractor")%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Estimate $">
                                                                                    <ItemStyle Width="100px" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkEstimate" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Estimate_Amount"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Proposal $">
                                                                                    <ItemStyle Width="100px" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkProposal" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Proposal_Amount"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Actual $">
                                                                                    <ItemStyle Width="100px" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkActual" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Actual_Amount"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Variance $">
                                                                                    <ItemStyle Width="100px" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkVariance" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Variance"))%>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Est. Start Date">
                                                                                    <ItemStyle Width="100px" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkEstStartDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Estaimted_Start_Date")) %>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Actual Start Date">
                                                                                    <ItemStyle Width="100px" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkActualStartDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Actual_Start_Date")) %>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Date Complete">
                                                                                    <ItemStyle Width="100px" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkDateComplete" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("End_Date")) %>'
                                                                                            CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Days">
                                                                                    <ItemStyle Width="50px" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkDays" runat="server" Text='<%#Eval("Days")%>' CommandName="ShowDetails"
                                                                                            CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Remove">
                                                                                    <ItemStyle Width="50px" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                            CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' OnClientClick="return ConfirmDelete();"
                                                                                            Visible='<%#(App_Access == AccessType.Administrative_Access) %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnl7" runat="server" Style="display: none;">
                                                        <div class="bandHeaderRow">
                                                            Surrender Obligations</div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">
                                                                    Condition at Lease Commencement Date
                                                                </td>
                                                                <td align="center" width="4%" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="txtCondition_At_Commencement" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Permitted Use
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="txtPermitted_Use" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Alterations
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="txtAlterations" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Tenant’s Obligations
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="txtTenants_Obligations" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Environmental Matters – Tenant’s Covenant
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="txtEnvironmental_Matters" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Landlord’s Obligations
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                    <uc:ctrlMultiLineTextBox ID="txtLandlords_Obligations" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnl8" runat="server" Style="display: none;">
                                                        <div class="bandHeaderRow">
                                                            Notices</div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td colspan="6">
                                                                    <b>If to Landlord</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">
                                                                    Company
                                                                </td>
                                                                <td align="center" width="4%" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Company" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                                <td align="left" width="18%" valign="top">
                                                                    Contact Name
                                                                </td>
                                                                <td align="center" width="4%" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Contact" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Address 1
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Address1" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Address 2
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Address2" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    City
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_City" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    State
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList ID="drpFK_State_Landlord" Width="175px" SkinID="dropGen" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Zip Code (XXXXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Zip_Code" runat="server" Width="170px" MaxLength="10"
                                                                        onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="revLandlord_Zip_Code" ControlToValidate="txtLandlord_Zip_Code"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Landlord Zip Code in xxxxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Telephone (XXX-XXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_TelephoneNotices" runat="server" Width="170px" MaxLength="12"
                                                                        onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="revLandlord_TelephoneNotices" ControlToValidate="txtLandlord_TelephoneNotices"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Landlord Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Facsimile (XXX-XXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Facsimile" runat="server" Width="170px" MaxLength="12"
                                                                        onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="revLandlord_Facsimile" ControlToValidate="txtLandlord_Facsimile"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Landlord Facsimile in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    E-Mail
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_EmailNotices" runat="server" Width="170px" MaxLength="255" />
                                                                    <asp:RegularExpressionValidator ID="revLandlord_EmailNotices" runat="server" ControlToValidate="txtLandlord_EmailNotices"
                                                                        ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="[Notices]/Landlord E-Mail Address Is Invalid"
                                                                        SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    With a copy to
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Company
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Copy_Company" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Contact Name
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Copy_Contact" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Address 1
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Copy_Address1" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Address 2
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Copy_Address2" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    City
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Copy_City" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    State
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList ID="drpFK_State_Landlord_Copy" Width="175px" SkinID="dropGen" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Zip Code (XXXXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Copy_Zip_Code" runat="server" Width="170px" MaxLength="10"
                                                                        onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="revLandlord_Copy_Zip_Code" ControlToValidate="txtLandlord_Copy_Zip_Code"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Landlord Copy Zip Code in xxxxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Telephone (XXX-XXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Copy_Telephone" runat="server" Width="170px" MaxLength="12"
                                                                        onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="revLandlord_Copy_Telephone" ControlToValidate="txtLandlord_Copy_Telephone"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Landlord Copy Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Facsimile (XXX-XXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Copy_Facsimile" runat="server" Width="170px" MaxLength="12"
                                                                        onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="revLandlord_Copy_Facsimile" ControlToValidate="txtLandlord_Copy_Facsimile"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Landlord Copy Facsimile in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    E-Mail
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtLandlord_Copy_Email" runat="server" Width="170px" MaxLength="255" />
                                                                    <asp:RegularExpressionValidator ID="revLandlord_Copy_Email" runat="server" ControlToValidate="txtLandlord_Copy_Email"
                                                                        ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="[Notices]/Landlord Copy E-Mail Address Is Invalid"
                                                                        SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    <b>If to Tenant</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Company
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTenant_Company" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Contact Name
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTenant_Contact" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Address 1
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTenant_Address1" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Address 2
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTenant_Address2" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    City
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTenant_City" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    State
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList ID="drpFK_State_Tenant" Width="175px" SkinID="dropGen" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Zip Code (XXXXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTenant_Zip_Code" runat="server" Width="170px" MaxLength="10"
                                                                        onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="rTenant_Zip_Code" ControlToValidate="txtTenant_Zip_Code"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Tenant Zip Code in xxxxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Telephone (XXX-XXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTenant_Telephone" runat="server" Width="170px" MaxLength="12"
                                                                        onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="revTenant_Telephone" ControlToValidate="txtTenant_Telephone"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Tenant Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Facsimile (XXX-XXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTenant_Facsimile" runat="server" Width="170px" MaxLength="12"
                                                                        onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="revTenant_Facsimile" ControlToValidate="txtTenant_Facsimile"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Tenant Facsimile in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    E-Mail
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTenant_Email" runat="server" Width="170px" MaxLength="255" />
                                                                    <asp:RegularExpressionValidator ID="revTenant_Email" runat="server" ControlToValidate="txtTenant_Email"
                                                                        ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="[Notices]/Tenant E-Mail Address Is Invalid"
                                                                        SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    With a copy to
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Company
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTenant_Copy_Company" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Contact Name
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTenant_Copy_Contact" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Address 1
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTenant_Copy_Address1" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Address 2
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTenant_Copy_Address2" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    City
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTenant_Copy_City" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    State
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList ID="drpFK_State_Tenant_Copy" Width="175px" SkinID="dropGen" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Zip Code (XXXXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTenant_Copy_Zip_Code" runat="server" Width="170px" MaxLength="10"
                                                                        onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="revTenant_Copy_Zip_Code" ControlToValidate="txtTenant_Copy_Zip_Code"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Tenant Copy Zip Code in xxxxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Telephone (XXX-XXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTenant_Copy_Telephone" runat="server" Width="170px" MaxLength="12"
                                                                        onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="revTenant_Copy_Telephone" ControlToValidate="txtTenant_Copy_Telephone"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Tenant Copy Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Facsimile (XXX-XXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTenant_Copy_Facsimile" runat="server" Width="170px" MaxLength="12"
                                                                        onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="revTenant_Copy_Facsimile" ControlToValidate="txtTenant_Copy_Facsimile"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Tenant Copy Facsimile in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    E-Mail
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTenant_Copy_Email" runat="server" Width="170px" MaxLength="255" />
                                                                    <asp:RegularExpressionValidator ID="revTenant_Copy_Email" runat="server" ControlToValidate="txtTenant_Copy_Email"
                                                                        ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="[Notices]/Tenant Copy E-Mail Address Is Invalid"
                                                                        SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    <b>If to Subtenant</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Company
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_Company" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Contact Name
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_Contact" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Address 1
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_Address1" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Address 2
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_Address2" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    City
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_City" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    State
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList ID="drpFK_State_Subtenant" Width="175px" SkinID="dropGen" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Zip Code (XXXXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_Zip_Code" runat="server" Width="170px" MaxLength="10"
                                                                        onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="revSubtenant_Zip_Code" ControlToValidate="txtSubtenant_Zip_Code"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Subtenant Zip Code in xxxxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Telephone (XXX-XXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_Telephone" runat="server" Width="170px" MaxLength="12"
                                                                        onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="revSubtenant_Telephone" ControlToValidate="txtSubtenant_Telephone"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Subtenant Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Facsimile (XXX-XXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_Facsimile" runat="server" Width="170px" MaxLength="12"
                                                                        onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="revSubtenant_Facsimile" ControlToValidate="txtSubtenant_Facsimile"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Subtenant Facsimile in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    E-Mail
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_Email" runat="server" Width="170px" MaxLength="255" />
                                                                    <asp:RegularExpressionValidator ID="revSubtenant_Email" runat="server" ControlToValidate="txtSubtenant_Email"
                                                                        ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="[Notices]/Subtenant E-Mail Address Is Invalid"
                                                                        SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    With a copy to
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Company
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_Copy_Company" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Contact Name
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_Copy_Contact" runat="server" Width="170px" MaxLength="75" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Address 1
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_Copy_Address1" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Address 2
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_Copy_Address2" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    City
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_Copy_City" runat="server" Width="170px" MaxLength="50" />
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    State
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList ID="drpFK_State_Subtenant_Copy" Width="175px" SkinID="dropGen"
                                                                        runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Zip Code (XXXXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_Copy_Zip_Code" runat="server" Width="170px" MaxLength="10"
                                                                        onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="revSubtenant_Copy_Zip_Code" ControlToValidate="txtSubtenant_Copy_Zip_Code"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Subtenant Copy Zip Code in xxxxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    Telephone (XXX-XXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_Copy_Telephone" runat="server" Width="170px" MaxLength="12"
                                                                        onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="revSubtenant_Copy_Telephone" ControlToValidate="txtSubtenant_Copy_Telephone"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Subtenant Copy Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Facsimile (XXX-XXX-XXXX)
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_Copy_Facsimile" runat="server" Width="170px" MaxLength="12"
                                                                        onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                    <asp:RegularExpressionValidator ID="revSubtenant_Copy_Facsimile" ControlToValidate="txtSubtenant_Copy_Facsimile"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Notices]/Subtenant Copy Facsimile in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    E-Mail
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtSubtenant_Copy_Email" runat="server" Width="170px" MaxLength="255" />
                                                                    <asp:RegularExpressionValidator ID="revSubtenant_Copy_Email" runat="server" ControlToValidate="txtSubtenant_Copy_Email"
                                                                        ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="[Notices]/Subtenant Copy E-Mail Address Is Invalid"
                                                                        SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnl9" runat="server" Style="display: none;">
                                                        <div class="bandHeaderRow">
                                                            Notes</div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td width="18%" align="left" valign="top">
                                                                    Notes Grid<br />
                                                                    <asp:LinkButton ID="lnkAddNotes" runat="server" Text="--Add--" CausesValidation="true"
                                                                        ValidationGroup="vsErrorGroup" OnClick="lnkAddNotes_Click" />
                                                                </td>
                                                                <td width="4%" align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:GridView ID="gvNotes" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                        OnRowCommand="gvNotes_RowCommand">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Note Date">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkNoteDate" runat="server" Text='<%#Convert.ToDateTime(Eval("Note_Date")).ToString("MMM-dd-yyyy")%>'
                                                                                        CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Notes") %>' /></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Note Text Snippet">
                                                                                <ItemStyle Width="75%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkNote" runat="server" Text='<%#Eval("Notes")%>' CssClass="TextClip"
                                                                                        Width="400px" CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Notes") %>' /></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Remove">
                                                                                <ItemStyle Width="10%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" OnClientClick="return ConfirmDelete();"
                                                                                        CommandName="RemoveDetails" CommandArgument='<%#Eval("PK_RE_Notes") %>' Visible='<%#(App_Access == AccessType.Administrative_Access) %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <div id="dvAttachment" runat="server" style="display: none;">
                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td width="100%">
                                                                    <uc:ctrlAttachment ID="Attachment" runat="Server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="Spacer" style="height: 20px;">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" OnClientClick="return ValAttach();"
                                                                        OnClick="btnAddAttachment_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="Spacer" style="height: 20px;">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btnAddAttachment" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <asp:UpdateProgress runat="server" ID="upProgress" DisplayAfter="100">
                                            <ProgressTemplate>
                                                <div class="UpdatePanelloading" id="divProgress" style="width: 100%;">
                                                    <table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%;
                                                        height: 100%;">
                                                        <tr align="center" valign="middle">
                                                            <td class="LoadingText" align="center" valign="middle">
                                                                <img src="../../Images/indicator.gif" alt="Loading" />&nbsp;&nbsp;&nbsp;Please Wait..
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <div id="dvView" runat="server" width="794px">
                                            <asp:Panel ID="pnl1View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Real Estate Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="19%" valign="top">
                                                            Dealership DBA
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <asp:Label ID="lblFK_LU_Location" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="20%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="26%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <%--<td align="left" width="19%" valign="top">
                                                            Legal Entity
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="27%" valign="top">
                                                            <asp:Label ID="lblLegalEntity" runat="server" Width="170px" />
                                                        </td>--%>
                                                        <td align="left" width="20%" valign="top">
                                                            Federal Id
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="26%" valign="top">
                                                            <asp:Label ID="lblFederal_Id" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Status
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_Status" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Address 1
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAddress1" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Address 2
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAddress2" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            City
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCity" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblState" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Zip Code (XXXXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblZipCode" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Telephone (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTelephone" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            County
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCounty" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Region
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblRegion" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Tax Parcel Number
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTax_Parcel_Number" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Lease Type
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_Lease_Type" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Landlord
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Landlord Location Address 1
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Location_Address1" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Landlord Location Address 2
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Location_Address2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Landlord Location City
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Location_City" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Landlord Location State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlordLocationState" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Landlord Location Zip Code (XXXXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Location_Zip_Code" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Landlord Mailing Address 1
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Mailing_Address1" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Landlord Mailing Address 2
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Mailing_Address2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Landlord Mailing City
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Mailing_City" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Landlord Mailing State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlordMailingState" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Landlord Mailing Zip Code (XXXXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Mailing_Zip_Code" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Landlord Telephone (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Telephone" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Landlord E-Mail
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Email" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Sublease?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSublease" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Subtenant
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenant" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Lease Id
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLease_Id" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Lease Commencement Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLease_Commencement_Date" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Project Type
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_Project_Type" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Lease Expiration Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLease_Expiration_Date" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Date Acquired
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate_Acquired" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Lease Term In Months
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLease_Term_Months" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Date Sold
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate_Sold" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Prior Lease Commencement Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPrior_Lease_Commencement_Date" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Renewals
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblRenewals" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Year Built
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblYear_Built" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Reminder Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblReminder_Date" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Year Remodeled
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblYear_Remodeled" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Landlord Notification Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Notification_Date" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Regional Vice President
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblRegional_Vice_President" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Vacate Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblVacate_Date" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            General Manager
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblGeneral_Manager" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Primary Use
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPrimary_Use" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Controller
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblController" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Lease Codes
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLease_Codes" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Loss Control Manager
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLoss_Control_Manager" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Total Acres
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTotal_Acres" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Number of Buildings
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblNumber_of_Buildings" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Total Gross Leasable Area (square feet)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTotal_Gross_Leaseable_Area" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Land Value
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;<asp:Label ID="lblLand_Value" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Rent</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Responsible Party
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblResponsible_PartyRent" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="28%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Lease Commencement Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblRentLeaseCommencementDateView" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Lease Term in Months
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblRentLeaseTermView" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Lease Expiration Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblRentLeaseExpDateView" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Prior Lease Commencement Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblRentPriorLeaseDateView" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Cancel Options
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblCancel_OptionsRent" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Renew Options
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblRenew_OptionsRent" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>                                                   
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Renewal Notification Due Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblNotification_Due_DateRent" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Subtenant Base Rent
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;<asp:Label ID="lblRentSubtenant_Base_Rent" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Subtenant Monthly Rent
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;<asp:Label ID="lblRentSubtenant_Monthly_Rent" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Escalation
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_EscalationRent" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Percentage Rate
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPercentage_RateRent" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Increase
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblIncreaseRent" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Term Rent Schedule Grid
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvRentTRSView" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                OnRowCommand="gvRentTRS_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Year">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkYear" runat="server" Text='<%#Eval("Year")%>' CommandName="ShowDetails"
                                                                                CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="From">
                                                                        <ItemStyle Width="16%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFrom" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%>'
                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="To">
                                                                        <ItemStyle Width="16%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkTo" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%>'
                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Months">
                                                                        <ItemStyle Width="11%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkMonths" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Months", "{0:N1}")%>'
                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Additions" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemStyle Width="16%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAdditions" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Additions"))%>'
                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Total Monthly Rent" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemStyle Width="21%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkMonthlyRent" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%>'
                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_TRS") %>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Renewal Rent Schedule Grid
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvRentRRSView" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                OnRowCommand="gvRentRRS_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Option">
                                                                        <ItemStyle Width="14%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkOption" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_RRS") %>'
                                                                                CommandName="ShowDetails"><%#Eval("Option_Period")%></asp:LinkButton></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="From">
                                                                        <ItemStyle Width="19%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFromDate" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_RRS") %>'
                                                                                CommandName="ShowDetails"><%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%></asp:LinkButton></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="To">
                                                                        <ItemStyle Width="19%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkToDate" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_RRS") %>'
                                                                                CommandName="ShowDetails"><%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%></asp:LinkButton></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Months">
                                                                        <ItemStyle Width="14%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkMonths" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_RRS") %>'
                                                                                CommandName="ShowDetails"><%#DataBinder.Eval(Container.DataItem, "Months", "{0:N1}")%></asp:LinkButton></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Base Monthly Rent" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemStyle Width="24%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkMonthlyRent" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_RRS") %>'
                                                                                CommandName="ShowDetails"><%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%></asp:LinkButton></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl3View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Subtenant Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="19%" valign="top">
                                                            Subtenant/DBA
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="27%" valign="top">
                                                            <asp:Label ID="lblSubtenant_DBA" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="19%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="27%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="19%" valign="top">
                                                            Subtenant Mailing Address 1
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="27%" valign="top">
                                                            <asp:Label ID="lblSubtenant_Mailing_Address1" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Subtenant Mailing Address 2
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenant_Mailing_Address2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Subtenant Mailing City
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenant_Mailing_City" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Subtenant Mailing State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenantMailingState" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Subtenant Mailing Zip Code (XXXXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenant_Mailing_Zip_Code" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Subtenant Telephone
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenantTelephone" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Lease Commencement Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenantLeaseCommencementDateView" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Lease Term in Months
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenantLeaseTermView" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Lease Expiration Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenantLeaseExpDateView" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Prior Lease Commencement Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenantPriorLeaseDateView" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Cancel Options
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblCancel_OptionsSubtenant" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Renew Options
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblRenew_OptionsSubtenant" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Option Notification
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblOpen_NotificationSubtenant" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Notification Due Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblNotification_Due_DateSubtenant" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Subtenant Base Rent
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;<asp:Label ID="lblSubtenant_Base_RentSubtenant" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Subtenant Monthly Rent
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;<asp:Label ID="lblSubtenant_Monthly_RentSubtenant" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Escalation
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_EscalationSubtenant" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Percentage Rate
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPercentage_RateSubtenant" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Increase
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblIncreaseSubtenant" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Term Rent Schedule Grid
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvSubtenantTRSView" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                OnRowCommand="gvSubtenantTRS_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Year">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkYear" runat="server" Text='<%#Eval("Year")%>' CommandName="ShowDetails"
                                                                                CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="From">
                                                                        <ItemStyle Width="16%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFrom" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%>'
                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="To">
                                                                        <ItemStyle Width="16%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkTo" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%>'
                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Months">
                                                                        <ItemStyle Width="11%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkMonths" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Months", "{0:N1}")%>'
                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Additions" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemStyle Width="16%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAdditions" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Additions"))%>'
                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Total Monthly Rent" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemStyle Width="21%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkMonthlyRent" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%>'
                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Subtenant_TRS") %>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Option Rent Schedule Grid
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvSubtenantORSView" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                OnRowCommand="gvSubtenantORS_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Option">
                                                                        <ItemStyle Width="14%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkOption" runat="server" CommandArgument='<%#Eval("PK_RE_SubTenant_ORS") %>'
                                                                                CommandName="ShowDetails"><%#Eval("Option_Period")%></asp:LinkButton></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="From">
                                                                        <ItemStyle Width="19%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFromDate" runat="server" CommandArgument='<%#Eval("PK_RE_SubTenant_ORS") %>'
                                                                                CommandName="ShowDetails"><%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%></asp:LinkButton></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="To">
                                                                        <ItemStyle Width="19%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkToDate" runat="server" CommandArgument='<%#Eval("PK_RE_SubTenant_ORS") %>'
                                                                                CommandName="ShowDetails"><%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%></asp:LinkButton></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Months">
                                                                        <ItemStyle Width="14%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkMonths" runat="server" CommandArgument='<%#Eval("PK_RE_SubTenant_ORS") %>'
                                                                                CommandName="ShowDetails"><%#DataBinder.Eval(Container.DataItem, "Months", "{0:N1}")%></asp:LinkButton></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Base Monthly Rent" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemStyle Width="24%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkMonthlyRent" runat="server" CommandArgument='<%#Eval("PK_RE_SubTenant_ORS") %>'
                                                                                CommandName="ShowDetails"><%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%></asp:LinkButton></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl4View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Rent Projections</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Responsible Party
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblResponsible_Party" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="28%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Lease Commencement Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblRentProjectionsLeaseCommencementDateView" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Lease Term in Months
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblRentProjectionsLeaseTermView" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Lease Expiration Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblRentProjectionsLeaseExpDateView" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Prior Lease Commencement Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblRentProjectionsPriorLeaseDateView" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Cancel Options
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblCancel_Options" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Renew Options
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblRenew_Options" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Option Notification
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblOpen_Notification" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Notification Due Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblNotification_Due_Date" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Subtenant Base Rent
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;<asp:Label ID="lblSubtenant_Base_Rent" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Subtenant Monthly Rent
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;<asp:Label ID="lblSubtenant_Monthly_Rent" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Escalation
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_Escalation" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Percentage Rate
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPercentage_Rate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Increase
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblIncrease" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Term Rent Schedule Grid
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvRentProjectionTRSView" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                OnRowCommand="gvRentProjectionTRS_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Year">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkYear" runat="server" Text='<%#Eval("Year")%>' CommandName="ShowDetails"
                                                                                CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="From">
                                                                        <ItemStyle Width="16%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFrom" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%>'
                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="To">
                                                                        <ItemStyle Width="16%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkTo" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%>'
                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Months">
                                                                        <ItemStyle Width="11%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkMonths" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Months", "{0:N1}")%>'
                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Additions" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemStyle Width="16%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAdditions" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Additions"))%>'
                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Total Monthly Rent" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemStyle Width="21%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkMonthlyRent" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%>'
                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Rent_Projctions_TRS") %>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Option Rent Schedule Grid
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvRentProjectionORSView" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                OnRowCommand="gvRentProjectionORS_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Option">
                                                                        <ItemStyle Width="14%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkOption" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_Projections_ORS") %>'
                                                                                CommandName="ShowDetails"><%#Eval("Option_Period")%></asp:LinkButton></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="From">
                                                                        <ItemStyle Width="19%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFromDate" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_Projections_ORS") %>'
                                                                                CommandName="ShowDetails"><%#clsGeneral.FormatDBNullDateToDisplay(Eval("From_Date"))%></asp:LinkButton></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="To">
                                                                        <ItemStyle Width="19%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkToDate" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_Projections_ORS") %>'
                                                                                CommandName="ShowDetails"><%#clsGeneral.FormatDBNullDateToDisplay(Eval("To_Date"))%></asp:LinkButton></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Months">
                                                                        <ItemStyle Width="14%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkMonths" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_Projections_ORS") %>'
                                                                                CommandName="ShowDetails"><%#DataBinder.Eval(Container.DataItem, "Months", "{0:N1}")%></asp:LinkButton></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Base Monthly Rent" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemStyle Width="24%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkMonthlyRent" runat="server" CommandArgument='<%#Eval("PK_RE_Rent_Projections_ORS") %>'
                                                                                CommandName="ShowDetails"><%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%></asp:LinkButton></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl5View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Security Deposit</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Amount
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            $&nbsp;<asp:Label ID="lblAmount" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Date of Security Deposit
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblDate_Of_Security_Deposit" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Tender Type
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_Tender_Type" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Received By
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblReceived_By" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <b>If Paid By Check</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Bank Name the Check was Drawn Against
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblBank_Name" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Check Number
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCheck_Number" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Name Printed on Check
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblName_On_Check" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Account Number
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAccount_Number" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Security Deposit Held At
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_Security_Deposit_Held" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Security Deposit Returned?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSecurity_Deposit_Returned" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Date Security Deposit Returned
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate_Security_Deposit_Returned" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Security Deposit Reduced?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSecurity_Deposit_Reduced" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Reason for Security Deposit Reduction
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblSecurity_Deposit_Reduction_Reason" runat="server"
                                                                ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Any Interest to be Realized on Security Deposit?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblInterest_On_Security_Deposit" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Interest Amount
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;<asp:Label ID="lblInterest_Amount" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Amount of Security Deposit Returned
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;
                                                            <asp:Label ID="lblAmount_Security_Deposit_Returned" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl6View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Repair/Maintenance</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Repair/Maintenance Grid
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <div style="width: 600px; overflow-x: scroll; overflow-y: hidden;">
                                                                <asp:GridView ID="gvRepairMaintenanceView" runat="server" EmptyDataText="No Record Found"
                                                                    Width="1250px" OnRowCommand="gvRepairMaintenance_RowCommand">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Repair Type">
                                                                            <ItemStyle Width="100px" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkRepairType" runat="server" Text='<%#Eval("Repair_Type")%>'
                                                                                    CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="PCA Conducted">
                                                                            <ItemStyle Width="100px" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkPCADate" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_PCA_Conducted")) %>'
                                                                                    CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Scope of Work">
                                                                            <ItemStyle Width="100px" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkScopeOfWork" runat="server" Text='<%#Eval("Work_Scope") %>'
                                                                                    CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Detail">
                                                                            <ItemStyle Width="100px" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkDetail" runat="server" Text='<%# Eval("Detailed_Description")%>'
                                                                                    CssClass="TextClip" Width="90px" CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Contractor">
                                                                            <ItemStyle Width="100px" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkContractor" runat="server" Text='<%#Eval("Contractor")%>'
                                                                                    CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Estimate $">
                                                                            <ItemStyle Width="100px" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkEstimate" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Estimate_Amount"))%>'
                                                                                    CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Proposal $">
                                                                            <ItemStyle Width="100px" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkProposal" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Proposal_Amount"))%>'
                                                                                    CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Actual $">
                                                                            <ItemStyle Width="100px" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkActual" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Actual_Amount"))%>'
                                                                                    CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Variance $">
                                                                            <ItemStyle Width="100px" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkVariance" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Variance"))%>'
                                                                                    CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Est. Start Date">
                                                                            <ItemStyle Width="100px" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkEstStartDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Estaimted_Start_Date")) %>'
                                                                                    CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Actual Start Date">
                                                                            <ItemStyle Width="100px" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkActualStartDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Actual_Start_Date")) %>'
                                                                                    CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Date Complete">
                                                                            <ItemStyle Width="100px" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkDateComplete" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("End_Date")) %>'
                                                                                    CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Days">
                                                                            <ItemStyle Width="50px" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkDays" runat="server" Text='<%#Eval("Days")%>' CommandName="ShowDetails"
                                                                                    CommandArgument='<%#Eval("PK_RE_Repair_Maintenance")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl7View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Surrender Obligations</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Condition at Lease Commencement Date
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblCondition_At_Commencement" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Permitted Use
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblPermitted_Use" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Alterations
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblAlterations" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Tenant’s Obligations
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblTenants_Obligations" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Environmental Matters – Tenant’s Covenant
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblEnvironmental_Matters" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Landlord’s Obligations
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblLandlords_Obligations" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl8View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Notices</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td colspan="6">
                                                            <b>If to Landlord</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Company
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblLandlord_Company" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Contact Name
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblLandlord_Contact" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Address 1
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Address1" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Address 2
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Address2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            City
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_City" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_State_Landlord" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Zip Code (XXXXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Zip_Code" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Telephone (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_TelephoneNotices" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Facsimile (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Facsimile" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            E-Mail
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_EmailNotices" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            With a copy to
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Company
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Copy_Company" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Contact Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Copy_Contact" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Address 1
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Copy_Address1" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Address 2
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Copy_Address2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            City
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Copy_City" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_State_Landlord_Copy" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Zip Code (XXXXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Copy_Zip_Code" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Telephone (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Copy_Telephone" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Facsimile (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Copy_Facsimile" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            E-Mail
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLandlord_Copy_Email" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <b>If to Tenant </b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Company
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTenant_Company" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Contact Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTenant_Contact" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Address 1
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTenant_Address1" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Address 2
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTenant_Address2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            City
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTenant_City" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_State_Tenant" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Zip Code (XXXXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTenant_Zip_Code" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Telephone (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTenant_Telephone" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Facsimile (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTenant_Facsimile" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            E-Mail
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTenant_Email" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            With a copy to
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Company
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTenant_Copy_Company" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Contact Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTenant_Copy_Contact" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Address 1
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTenant_Copy_Address1" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Address 2
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTenant_Copy_Address2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            City
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTenant_Copy_City" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_State_Tenant_Copy" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Zip Code (XXXXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTenant_Copy_Zip_Code" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Telephone (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTenant_Copy_Telephone" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Facsimile (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTenant_Copy_Facsimile" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            E-Mail
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTenant_Copy_Email" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <b>If to Subtenant </b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Company
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenant_Company" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Contact Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenant_Contact" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Address 1
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenant_Address1" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Address 2
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenant_Address2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            City
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenant_City" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_State_Subtenant" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Zip Code (XXXXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenant_Zip_Code" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Telephone (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenant_Telephone" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Facsimile (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenant_Facsimile" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            E-Mail
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenant_Email" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            With a copy to
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Company
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenant_Copy_Company" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Contact Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenant_Copy_Contact" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Address 1
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenant_Copy_Address1" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Address 2
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenant_Copy_Address2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            City
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenant_Copy_City" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_State_Subtenant_Copy" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Zip Code (XXXXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenant_Copy_Zip_Code" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Telephone (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenant_Copy_Telephone" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Facsimile (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenant_Copy_Facsimile" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            E-Mail
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubtenant_Copy_Email" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl9View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Notes</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td width="18%" align="left" valign="top">
                                                            Notes Grid
                                                        </td>
                                                        <td width="4%" align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:GridView ID="gvNotesView" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                OnRowCommand="gvNotes_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Note Date">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNoteDate" runat="server" Text='<%#Convert.ToDateTime(Eval("Note_Date")).ToString("MMM-dd-yyyy")%>'
                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Notes") %>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Note Text Snippet">
                                                                        <ItemStyle Width="85%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNote" runat="server" Text='<%#Eval("Notes")%>' CssClass="TextClip"
                                                                                Width="450px" CommandName="ShowDetails" CommandArgument='<%#Eval("PK_RE_Notes") %>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <asp:Panel ID="pnlAttachmentDetails" runat="server" Style="display: none;">
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td width="100%">
                                                        <uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="Spacer" style="height: 150px;">
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td align="center">
                            <div id="dvSave" runat="server" style="display: none;">
                                <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td width="50%" align="right">
                                            <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click"
                                                CausesValidation="true" ValidationGroup="vsErrorGroup" OnClientClick="return ValSave();" />
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnAbstractReport" runat="server" Text="Generate Abstract"
                                                OnClientClick="javascript:return ReportPopUp();" Width="185px" Visible="false" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="dvBack" runat="server" style="display: none;">
                                <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td width="50%" align="right">
                                            <asp:Button ID="btnBack" runat="server" Text=" Edit " OnClick="btnBack_Click" CausesValidation="false" />
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnAbstractReportView" runat="server" Text="Generate Abstract"
                                                OnClientClick="javascript:return ReportPopUp();" Width="185px" Visible="false" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
