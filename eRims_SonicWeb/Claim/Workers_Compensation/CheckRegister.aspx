<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="CheckRegister.aspx.cs"
    Inherits="WorkerCompensation_CheckRegister" Title="Risk Management Insurance System"
    Theme="Default"   %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function OpenWMail(grdName,attTbl)
{

    var isChecked = false;
	for(i=0;i<document.forms[0].elements.length;i++)
        {
            if((document.forms[0].elements[i].type=='checkbox') && (document.forms[0].elements[i].name !='chkHeader'))
            {
                if(document.forms[0].elements[i].checked  == true)
                       isChecked= true;
            }
        }   
	if(!isChecked)
	{
	    alert('Please select any attachment to mail.');
		return false;
	}
	
    var i,flag=0;
    var m_strAttIds="";  
    for(i=0;i<document.forms[0].elements.length;i++)
    {
        if((document.forms[0].elements[i].type=='checkbox'))
        {
             if(document.forms[0].elements[i].name !="ctl00$ContentPlaceHolder1$"+grdName+"$ctl01$chkHeader")
                {
                
                if(document.forms[0].elements[i].checked  == true)
                    {  
                        if(m_strAttIds=="")
                        {
                            m_strAttIds=document.forms[0].elements[i].value;
                        }
                        else
                        {
                           m_strAttIds=m_strAttIds+","+document.forms[0].elements[i].value; 
                        }
                    }
                }
        }
        
    }
    //alert(m_strClaimNo); 
    oWnd=window.open("../../ErimsMail.aspx?AttMod="+attTbl+"&AttIds=" + m_strAttIds ,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=600,height=300");
    oWnd.moveTo(260,180);
    return false;
  }  
    
    function changefocus(control)
    {
        clearfocus();        
        document.getElementById(control).className="left_menu_active";  
        if(control == "first")
             document.getElementById("ctl00_ContentPlaceHolder1_divfirst").style.display ="block";  
        if(control == "second")
             document.getElementById("ctl00_ContentPlaceHolder1_divsecond").style.display ="block";       
    }
    function clearfocus()
    {
        document.getElementById("first").className="left_menu";     
        document.getElementById("second").className="left_menu";     
        
        document.getElementById("ctl00_ContentPlaceHolder1_divfirst").style.display ="none"; 
        document.getElementById("ctl00_ContentPlaceHolder1_divsecond").style.display ="none";    
    }
    
    </script>

    <div id="contmain" runat="server" style="width: 100%;">
        <br />
        <div id="Div1" runat="server" style="width: 100%; text-align: center">
            <table border="0" cellpadding="1" cellspacing="0" width="99%">
                <tr>
                    <td align="center" style="background-image: url('../../images/normal_btn.jpg')" class="normal_tab"
                        valign="middle">
                        <a class="main_menu" href="../Workers_ Compensation.aspx">Worker's Compensation</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="WorkerCompensationReserve.aspx">Reserve Worksheets</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="Carrier.aspx">Carrier Data</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="subrogation.aspx">Subrogation</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="SubrogationDetail.aspx">Subrogation Detail</a></td>
                    <td align="center" class="active_tab" style="background-image: url('../../images/active_btn.jpg')"
                        valign="middle">
                        Check Register</td>
                    <td align="center" class="normal_tab" style="background-image: url('../../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="MainDiary.aspx">Diary</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="MainAdjuster.aspx">Adjustor Notes</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="Settlement.aspx">Settlement</a></td>
                </tr>
            </table>
        </div>
        <div id="leftDiv" runat="server" style="width: 18%; height: 350px; float: left; border: solid 1px #7F7F7F;
            margin: 1px 1px 1px 4px;">
            <table border="0" cellpadding="2" cellspacing="0" width="90%">
                <tr>
                    <td style="width: 15%">
                        &nbsp;</td>
                    <td style="width: 85%">
                        <a class="left_menu_active" id="first" onclick="changefocus(this.id);" href="#">Claim
                            Details</a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="second" onclick="changefocus(this.id);" href="#">Financial
                            Details</a></td>
                </tr>
            </table>
        </div>
        <div id="mainContent" runat="server" style="border: solid 1px #7F7F7F; width: 79%;
            float: right; margin: 1px 5px 1px 1px; padding: 5px 5px 5px 5px">
            <!-- Start Div Tag for Claim Details -->
            <div style="width: 100%; display: block;" id="divfirst" runat="server">
                <table cellpadding="2" cellspacing="2" border="0" width="100%" class="stylesheet">
                    <tr>
                        <td colspan="6" class="ghc">
                            Claim Details</td>
                    </tr>
                    <tr>
                        <td style="width:25%;" align="left" class="lc">
                            <asp:Label runat="server" ID="lblMClaimNumber">Claim Number</asp:Label>
                        </td>
                        <td  align="Center" class="lc">
                            :
                        </td>
                        <td style="width:25%;" align="left" class="ic">
                            <asp:Label runat="server" ID="lblClaimNum"></asp:Label>
                        </td>
                        <td style="width:25%;" align="left" class="lc">
                            <asp:Label runat="server" ID="lblMDOIncident">Date of Incident</asp:Label> 
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td width="25%" align="left" class="ic">
                            <asp:Label runat="server" ID="lblDateIncident"></asp:Label>
                        </td>
                        
                        
                    </tr>
                    <tr>
                        <td style="width:25%;" align="left" class="lc">
                            <asp:Label runat="server" ID="lblMLastName">Name</asp:Label>
                        </td>
                        <td  align="Center" class="lc">
                            :
                        </td>
                        <td style="width:25%;" align="left" class="ic">
                            <asp:Label runat="server" ID="lblLName"></asp:Label>&nbsp;
                            <asp:Label runat="server" ID="lblMName"></asp:Label>&nbsp;
                            <asp:Label runat="server" ID="lblFName"></asp:Label>
                        </td>
                        <td style="width:25%;" align="left" class="lc">
                            <asp:Label runat="server" ID="lblMEmployee">Employee</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td style="width:25%;" align="left" class="ic">
                            <div runat="server" id="dvEditEmp" style="display:block;">
                                <asp:RadioButtonList ID="rbtnEmployee" runat="server" Enabled="false" RepeatDirection="Horizontal">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div runat="server" id="dvViewEmp" style="display:none;">
                                <asp:Label runat="server" ID="lblEmployee"></asp:Label>
                            </div>
                        </td>
                        
                        
                        
                        <%--<td style="width:25%;" align="left" class="lc">
                            <asp:Label runat="server" ID="lblMFirstName"> First Name</asp:Label>
                        </td>
                        <td  align="Center" class="lc">
                            :
                        </td>
                        <td width="25%" align="left" class="ic">
                            <asp:Label runat="server" ID="lblFName"></asp:Label>
                        </td>--%>
                    </tr>
                    <%--<tr>
                        <td style="width:25%;" align="left" class="lc">
                            <asp:Label runat="server" ID="lblMMiddleName">Middle Name</asp:Label>
                        </td>
                        <td  align="Center" class="lc">
                            :
                        </td>
                        <td style="width:25%;" align="left" class="ic">
                            <asp:Label runat="server" ID="lblMName"></asp:Label>
                        </td>
                        
                    </tr>--%>
                </table>
            </div>
            <!-- End Div Tag for Claim Details -->
            <!-- Start Div Tag for Financial Details -->
            <div style="width: 100%; display: none;" id="divsecond" runat="server">
                <table cellpadding="2" border="0" cellspacing="2" style="width: 100%;" class="stylesheet">
                    <tr>
                        <td class="ghc" align="left" colspan="5">
                            Financial Details
                        </td>
                    </tr>
                </table>
                <table id="tblDetail" runat="server" cellpadding="2" border="0" cellspacing="2" style="width: 80%;" class="stylesheet">
                                        
                    <tr>
                        <td align="center" class="lc">
                            &nbsp;</td>
                        <td class="lc" align="right" style="font-family:Verdana;">
                            <b>Incurred $</b></td>
                        <td class="lc" align="right" style="font-family:Verdana;">
                            <b>Paid $</b></td>
                        <td align="right" class="lc" style="font-family: Verdana;">
                            <b>Outstanding $</b></td>
                        <td align="right" class="lc" style="font-family: Verdana;">
                            <b>Current Month $</b></td>
                    </tr>
                    <tr>
                        <td align="left" class="lc" style="font-family: Verdana;">
                            <b>Property Damage</b></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblIndemIncurred"></asp:Label></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblIndemPaid"></asp:Label></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblIndemOutStanding"></asp:Label></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblIndemCurrentMonth"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" class="lc" style="font-family: Verdana;">
                            <b>Bodily Injury</b></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblMediIncured"></asp:Label></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblMediPaid"></asp:Label></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblMediOutStand"></asp:Label></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblMediCurrentMonth"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" class="lc" style="font-family: Verdana;">
                            <b>Expenses</b></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblExpIncurred"></asp:Label></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblExpIndemPaid"></asp:Label></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblExpOutStand"></asp:Label></td>
                        <td align="right" class="lc">
                            <asp:Label runat="server" ID="lblExpCurrentMonth"></asp:Label></td>
                    </tr>
                </table>
                <table id="tblNoData" cellpadding="2" cellspacing="2" runat="server" style="width:100%;display:none;">
                    <tr><td>&nbsp;</td></tr>                    
                    <tr>
                        <td class="ic" align="center">
                            <span class="mf">No Check Register found for this claim. </span>
                        </td>
                    </tr>                    
                </table>               
                         
            </div>
            <!-- End Div Tag for Financial Details -->
        </div>
        <div id="divbtn">
            <table style="width: 100%;">
                <tr>
                    <td align="center" class="ic">
                        <asp:Button runat="server" SkinID="btnGen" EnableTheming="false" Text="Next Step"
                                ID="btnNext" OnClick="btnNext_Click" />                      
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
