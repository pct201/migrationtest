<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="subrogation.aspx.cs"
    Inherits="WorkerCompensation_subrogation" Title="Risk Management Insurance System" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="cntSubrogation" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="false"
            ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
    </div>
    <asp:ScriptManager runat="server" ID="scManager">
    </asp:ScriptManager>

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
    
     function MinMax(name)
    {
        if(name == "check")
        {
            if(document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_txtDescription").style.height == "")
            {
                document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_ibtnCheck").src = "../../Images/minus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_txtDescription").style.height = "100px";
                document.getElementById("pnlCheck").style.display = "block";
            }
            else if(document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_txtDescription").style.height == "100px")
            {
                document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_ibtnCheck").src = "../../Images/plus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_txtDescription").style.height="";
                document.getElementById("pnlCheck").style.display = "none";
            }
        }
        if(name == "recovery")
        {
            if(document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_txtRecoveryDesc").style.height == "")
            {
                document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_ibtnRecovery").src = "../../Images/minus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_txtRecoveryDesc").style.height = "100px";
                document.getElementById("pnlRecovery").style.display = "block";
            }
            else if(document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_txtRecoveryDesc").style.height == "100px")
            {
                 document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_ibtnRecovery").src = "../../Images/plus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_txtRecoveryDesc").style.height="";
                document.getElementById("pnlRecovery").style.display = "none";
            }
        }
        if(name == "attachment")
        {
            if(document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_txtAttachDesc").style.height == "")
            {
                document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_ibtnAttachment").src = "../../Images/minus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_txtAttachDesc").style.height = "100px";
                document.getElementById("pnlAttach").style.display = "block";
            }
            else if(document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_txtAttachDesc").style.height == "100px")
            {
                 document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_ibtnAttachment").src = "../../Images/plus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_txtAttachDesc").style.height="";
                document.getElementById("pnlAttach").style.display = "none";
            }
        }
        return false;
    }
    
    function partialrefund()
    {
        if(document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_rbtnFRefundYes").checked == true)
        {
            document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_rbtnPartRefundYes").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_rbtnPartRefundNo").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_rbtnPartRefundYes").checked = false;
            document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_rbtnPartRefundNo").checked = false;
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_rbtnFRefundNo").checked == true)
        {            
            document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_rbtnPartRefundYes").disabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_rbtnPartRefundNo").disabled = false;
        }
    }
    function ValAttach()
    {        
        document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_rfvAttachType").enabled =true;
        document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_rfvUpload").enabled =true;
        return true;
    }
    function ValSave()
    {        
        document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_rfvAttachType").enabled =false;
        document.getElementById("ctl00_ContentPlaceHolder1_fvSubrogation_rfvUpload").enabled =false;
        return true;
    }
    function openWindow(strURL)
    {
        oWnd=window.open(strURL,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
        oWnd.moveTo(260,180);
        return false;
        
    }
    function openMailWindow(strURL)
    {      
        oWnd=window.open(strURL,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=0,toolbar=0,width=500,height=280");
        oWnd.moveTo(260,180);
        return false;
        
    }
    </script>

    <%--<asp:UpdatePanel ID="pnlSubrogation" runat="server">
        <contenttemplate>--%>
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
                    <td align="center" class="active_tab" style="background-image: url('../../images/active_btn.jpg')"
                        valign="middle">
                        Subrogation</td>
                    <td align="center" class="normal_tab" style="background-image: url('../../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="SubrogationDetail.aspx">Subrogation Detail</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="CheckRegister.aspx">Check Register</a></td>
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
        <div id="leftdiv" runat="server" style="width: 18%; height: 350px; float: left; border: solid 1px #7F7F7F;
            margin: 1px 1px 1px 4px;">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="width: 15">
                        &nbsp;</td>
                    <td style="width: 85%">
                        <asp:LinkButton ID="first" runat="server" CssClass="left_menu_active" OnClick="first_Click"
                            Text="Claim Details"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:LinkButton ID="second" runat="server" CssClass="left_menu" OnClick="second_Click"
                            Text="Subrogation History"></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
        <div id="mainContent" runat="server" style="border: solid 1px #7F7F7F; width: 79%;
            float: right; margin: 1px 5px 1px 1px; padding: 5px 5px 5px 5px">
            <div id="divfirst" style="width: 100%; display: block;" runat="server">
                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                    <tr>
                        <td colspan="6" class="ghc">
                            Claim Details</td>
                    </tr>
                    <tr>
                        <td style="width: 25%;" align="left" class="lc">
                            <asp:Label runat="server" ID="lblMClaimNumber">Claim Number</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td style="width: 25%;" align="left" class="ic">
                            <asp:Label runat="server" ID="lblClaimNum"></asp:Label>
                        </td>
                        <td style="width: 25%;" align="left" class="lc">
                            <asp:Label runat="server" ID="lblMDOIncident">Date of Incident</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td style="width: 25%;" align="left" class="ic">
                            <asp:Label runat="server" ID="lblDateIncident"></asp:Label>
                        </td>
                        
                        
                    </tr>
                    <tr>
                        <td style="width: 25%;" align="left" class="lc">
                            <asp:Label runat="server" ID="lblMLastName">Last Name</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td style="width: 25%;" align="left" class="ic">
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
                        <%--<td style="width: 25%;" align="left" class="lc">
                            <asp:Label runat="server" ID="lblMFirstName"> First Name</asp:Label>
                        </td>
                        <td  align="Center" class="lc">
                            :
                        </td>
                        <td style="width: 25%;" align="left" class="ic">
                            <asp:Label runat="server" ID="lblFName"></asp:Label>
                        </td>--%>
                    </tr>
                    <%--<tr>
                        <td style="width: 25%;" align="left" class="lc">
                            <asp:Label runat="server" ID="lblMMiddleName">Middle Name</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td style="width: 25%;" align="left" class="ic">
                            <asp:Label runat="server" ID="lblMName"></asp:Label>
                        </td>
                        
                    </tr>--%>
                    
                </table>
            </div>            
            <div id="divSearch" runat="server" style="display: none;">
                <table style="width: 100%;">
                    <tr>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 20%;" align="left" class="lc">
                            <asp:Label ID="lblBankDetailsTotal" runat="server"></asp:Label>
                        </td>
                        <td style="width: 80%;" align="right">
                            <table width="75%">
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
                                        <asp:Panel runat="server" ID="pnl" DefaultButton="btnGo">
                                            <asp:TextBox ID="txtPageNo" runat="server" Width="20px" onkeypress="return numberOnly(event);"></asp:TextBox>
                                        </asp:Panel>
                                    </td>
                                    <td class="ic">
                                        <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divthird" style="width: 100%; display: none;" runat="server">
                <table style="width: 100%">
                    <tr>
                        <td>
                            <asp:MultiView ID="mvSubrogation" runat="server">
                                <asp:View ID="vwSubrogationList" runat="server">
                                    <table style="width: 100%;">
                                        
                                        <tr>
                                            <td class="ic" align="right">
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Click here to delete Diary Details"
                                                    OnClick="btnDelete_Click" />
                                                <asp:Button ID="btnAddNew" runat="server" Text="Add New" ToolTip="Add new Diary Details"
                                                    OnClick="btnAddNew_Click" />
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td style="text-align: left;">
                                                <asp:GridView ID="gvSubrogation" runat="server" AutoGenerateColumns="false" OnRowCommand="gvSubrogation_RowCommand"
                                                    DataKeyNames="PK_Subrogation" Width="100%" OnPageIndexChanging="gvSubrogation_PageIndexChanging" OnRowDataBound="gvSubrogation_RowDataBound"
                                                    AllowPaging="True" AllowSorting="True" OnSorting="gvSubrogation_Sorting" OnRowCreated="gvSubrogation_RowCreated" >
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <input name="chkItem" type="checkbox" value='<%# Eval("PK_Subrogation")%>' onclick="javascript:UnCheckHeader('gvSubrogation')" />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="10px" />
                                                            <HeaderTemplate>
                                                                <input type="checkbox" name="chkHeader" id="chkHeader" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                                            </HeaderTemplate>
                                                            <HeaderStyle Width="10px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date Of Transaction" HeaderStyle-HorizontalAlign ="Right" ItemStyle-HorizontalAlign="Right" SortExpression="Update_Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDOTransaction" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Update_Date", "{0:MM/dd/yyyy}")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Check Amount $" HeaderStyle-HorizontalAlign ="Right" ItemStyle-HorizontalAlign="Right" SortExpression="Check_Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCheckAmt" runat="server" Text='<%#Eval("Check_Amount")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Check_Number" HeaderStyle-HorizontalAlign ="Right" ItemStyle-HorizontalAlign="Right" HeaderText="Check Number" SortExpression="Check_Number">
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Subrogation" HeaderStyle-HorizontalAlign ="Right" ItemStyle-HorizontalAlign="Right" SortExpression="Subrogation">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSubrogation" runat="server" Text='<%#Eval("Subrogation")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Payment" HeaderStyle-HorizontalAlign ="Right" ItemStyle-HorizontalAlign="Right" DataField="Payment_Id" SortExpression="Payment_Id" />
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_Subrogation")%>'
                                                                    runat="server" Text="Edit" ToolTip="Edit the Subrogation Details" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("PK_Subrogation")%>'
                                                                    ToolTip="View the Subrogation Details" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                    <EmptyDataTemplate>
                                                        Currently there is no Subrogation for the following claim. Please add one or more
                                                        Subrogation.
                                                    </EmptyDataTemplate>
                                                    <PagerSettings Visible="False" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="vwSubrogationDetail" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <div>
                                                    <table cellpadding="3" cellspacing="0" style="border: 1pt; border-color: #7f7f7f;
                                                        border-style: solid; text-align: left; width: 100%;">
                                                        <tr>
                                                            <td align="left" colspan="6" class="ghc">
                                                                Claim Details</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 25%;" align="left" class="lc">
                                                                <asp:Label runat="server" ID="lblFClaimNumber">Claim Number</asp:Label>
                                                            </td>
                                                            <td  align="Center" class="lc">
                                                                :
                                                            </td>
                                                            <td style="width: 25%;" align="left" class="ic">
                                                                <asp:Label runat="server" ID="lblClaimNo"></asp:Label>
                                                            </td>
                                                            <td align="left" class="lc">
                                                                <asp:Label runat="server" ID="lblFDOIncident">Date of Incident</asp:Label>
                                                            </td>
                                                            <td align="Center" class="lc">
                                                                :
                                                            </td>
                                                            <td align="left" class="ic">
                                                                <asp:Label runat="server" ID="lblDOIncident"></asp:Label>
                                                            </td>
                                                            
                                                            
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="lc">
                                                                <asp:Label runat="server" ID="lblFLastName">Name</asp:Label>
                                                            </td>
                                                            <td align="Center" class="lc">
                                                                :
                                                            </td>
                                                            <td align="left" class="ic">
                                                                <asp:Label runat="server" ID="lblLastName"></asp:Label>&nbsp;
                                                                <asp:Label runat="server" ID="lblMiddleName"></asp:Label>&nbsp;
                                                                <asp:Label runat="server" ID="lblFirstName"></asp:Label>                                                                
                                                                
                                                            </td>
                                                            <td style="width: 25%;" align="left" class="lc">
                                                                <asp:Label runat="server" ID="lblFEmployee">Employee</asp:Label>
                                                            </td>
                                                            <td  align="Center" class="lc">
                                                                :
                                                            </td>
                                                            <td style="width: 25%;" align="left" class="ic">
                                                                <asp:Label runat="server" ID="lblEmployee"></asp:Label>
                                                            </td>
                                                            <%--<td align="left" class="lc">
                                                                <asp:Label runat="server" ID="lblFFirstName"> First Name</asp:Label>
                                                            </td>
                                                            <td align="Center" class="lc">
                                                                :
                                                            </td>
                                                            <td align="left" class="ic">
                                                                <asp:Label runat="server" ID="lblFirstName"></asp:Label>
                                                            </td>--%>
                                                        </tr>
                                                        <%--<tr>
                                                            <td align="left" class="lc">
                                                                <asp:Label runat="server" ID="lblFMiddleName">Middle Name</asp:Label>
                                                            </td>
                                                            <td align="Center" class="lc">
                                                                :
                                                            </td>
                                                            <td align="left" class="ic">
                                                                <asp:Label runat="server" ID="lblMiddleName"></asp:Label>
                                                            </td>
                                                            
                                                        </tr>--%>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:FormView runat="server" ID="fvSubrogation" Width="100%" OnDataBound="fvSubrogation_DataBound">
                                                    <InsertItemTemplate>
                                                        <asp:UpdatePanel ID="pnlBankDetail" runat="server">
                                                            <contenttemplate>
                                                        <table border="0" cellpadding="2" cellspacing="2" class="lc" width="100%">
                                                            <tr>
                                                                <td class="ghc" colspan="6">
                                                                    Check Information</td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td align="left" class="lc" style="width: 25%">
                                                                    <asp:Label runat="server" ID="lblFVChkAmt">Check Amount</asp:Label>
                                                                    &nbsp;<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc" >
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic" style="width: 25%">
                                                                    $<asp:TextBox ID="txtCheckAmt" runat="server" SkinID="txtAmt" MaxLength="9" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="rfvCheckAmt" ControlToValidate="txtCheckAmt"
                                                                        ErrorMessage="Please Enter Check Amount." Display="none" Text="*" InitialValue="" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="left" class="lc" style="width: 25%">
                                                                    <asp:Label runat="server" ID="lblFVProviderName">Provider Name</asp:Label>
                                                                    &nbsp;<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc" >
                                                                    :
                                                                </td>
                                                               <%--  <asp:UpdatePanel ID="pnlprovider" runat="server">
                                                                   <contenttemplate>--%>
                                                                <td align="left"  class="ic" style="width: 25%">
                                                                    <asp:DropDownList runat="server" ID="dwProviderName" AutoPostBack="true" OnSelectedIndexChanged="dwProviderName_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <%--<cc1:ListSearchExtender ID="lseProviderName" Enabled="true" runat="server" TargetControlID="dwProviderName" PromptText="Type to search" PromptCssClass="mf" PromptPosition="Top"></cc1:ListSearchExtender>--%>
                                                                    <asp:RequiredFieldValidator runat="server" ID="rfvProviderName" ControlToValidate="dwProviderName"
                                                                        ErrorMessage="Please Select Provider Name." Display="none" Text="*" InitialValue="--Select Provider--"
                                                                        ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                                </td>
                                                                
                                                                  <%--</contenttemplate>
                                                                    </asp:UpdatePanel>--%>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVPAdd1">Provider Address (1) </asp:Label><span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:TextBox ID="txtPAdd1" ReadOnly="true" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="rfvPAdd1" ControlToValidate="txtPAdd1"
                                                                        ErrorMessage="Please Enter Provider Address (1)." Display="none" Text="*" InitialValue=""
                                                                        ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVPAdd2">Provider Address (2) </asp:Label><span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:TextBox ID="txtPAdd2" runat="server" ReadOnly="true"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="rfvPAdd2" ControlToValidate="txtPAdd2"
                                                                        ErrorMessage="Please Enter Provider Address (2)." Display="none" Text="*" InitialValue=""
                                                                        ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                                </td>
                                                               
                                                            </tr>
                                                            <tr>
                                                                
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVPTaxIDNo">Provider Tax Id Number </asp:Label><span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:TextBox ID="txtPTaxID" ReadOnly="true" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="rfvPTaxID" ControlToValidate="txtPTaxID"
                                                                        ErrorMessage="Please Enter Provider Tax Id Number." Display="none" Text="*" InitialValue=""
                                                                        ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                                </td>
                                                                
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVPCity">Provider City  </asp:Label><span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:TextBox ID="txtPCity" ReadOnly="true" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="rfvPCity" ControlToValidate="txtPCity"
                                                                        ErrorMessage="Please Enter Provider City." Display="none" Text="*" InitialValue="" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVPState">Provider State </asp:Label><span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:TextBox ID="txtPState" ReadOnly="true" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="rfvPState" ControlToValidate="txtPState"
                                                                        ErrorMessage="Please Enter Provider State." Display="none" Text="*" InitialValue="" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVPZip">Provider Zip Code </asp:Label><span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:TextBox ID="txtPZip" ReadOnly="true" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="rfvPZip" ControlToValidate="txtPZip"
                                                                        ErrorMessage="Please Enter Provider Zip Code." Display="none" Text="*" InitialValue=""
                                                                        ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVOriginChkNo">Original Check Number </asp:Label><span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:TextBox ID="txtCheckNo" MaxLength="6" runat="server" onkeypress="return numberOnly(event);"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="rfvCheckNo" ControlToValidate="txtCheckNo"
                                                                        ErrorMessage="Please Enter Original Check Number." Display="none" Text="*" InitialValue=""
                                                                        ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVSubrogation">Subrogation?</asp:Label>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:RadioButton ID="rbtnSubrogationYes" runat="server" GroupName="Subrogation" Text="Yes" />&nbsp;
                                                                    <asp:RadioButton ID="rbtnSubrogationNo" runat="server" GroupName="Subrogation" Text="No" Checked="true" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVAutoSalvage">Auto Salvage?</asp:Label>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:RadioButton ID="rbtnSalvageYes" runat="server" GroupName="Salvage" Text="Yes" />&nbsp;
                                                                    <asp:RadioButton ID="rbtnSalvageNo" runat="server" GroupName="Salvage" Text="No" Checked="true"/>
                                                                </td>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVOther">Other?</asp:Label>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:RadioButton ID="rbtnOtherYes" runat="server" GroupName="Other" Text="Yes" />&nbsp;
                                                                    <asp:RadioButton ID="rbtnOtherNo" runat="server" GroupName="Other" Text="No" Checked="true"/>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="lc" valign="top">
                                                                    <asp:Label runat="server" ID="lblFVOtherDesc">Other Description</asp:Label>
                                                                </td>
                                                                <td align="center" class="ic" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic" colspan="4" valign="top">
                                                                    <asp:ImageButton ID="ibtnCheck" ImageUrl="~/Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMax('check');" />
                                                                    <div id="pnlCheck" style="display:block;">
                                                                    <asp:TextBox ID="txtDescription" runat="server" MaxLength="4000"  TextMode="MultiLine" Height="100px"
                                                                        Width="95%"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                           
                                                        </table>
                                                        <table cellpadding="2" cellspacing="2" style="width: 100%;">
                                                            <tr>
                                                                <td class="ghc" colspan="6">
                                                                    Recovery Breakdown
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="lc" style="width: 25%;">
                                                                    <asp:Label runat="server" ID="lblFVPaymentID">Payment ID</asp:Label>
                                                                </td>
                                                                <td align="center" class="lc" >
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic" style="width: 25%;">
                                                                    <asp:DropDownList runat="server" ID="dwPaymentID" AutoPostBack="true" OnSelectedIndexChanged="dwPaymentID_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 20%;">
                                                                    &nbsp;</td>
                                                                <td style="width: 5%;">
                                                                    &nbsp;</td>
                                                                <td style="width: 25%;">
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="lc" style="width:25%;">
                                                                    <asp:Label runat="server" ID="lblFVPaycode">Paycode</asp:Label>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic" colspan="4" style="width:75%;">
                                                                    <asp:DropDownList runat="server" SkinID="dropGen" Width="96%" ID="dwPayCode">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="ic" valign="top">
                                                                    <asp:Label runat="server" ID="lblFVRecoverDesc">Recovery Description</asp:Label>
                                                                </td>
                                                                <td class="lc" align="center" valign="top">
                                                                    :</td>
                                                                <td class="ic" colspan="4" valign="top">
                                                                    <asp:ImageButton ID="ibtnRecovery" ImageUrl="~/Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMax('recovery');" />
                                                                    <div id="pnlRecovery" style="display:block;">
                                                                        <asp:TextBox runat="server" ID="txtRecoveryDesc" MaxLength="4000" TextMode="MultiLine" Height="100px"
                                                                            Width="95%"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            
                                                        </table>
                                                        </contenttemplate>
                                                        </asp:UpdatePanel>
                                                        <table border="0" cellpadding="2" cellspacing="2" class="stylesheet" width="100%">
                                                            <tr>
                                                                <td class="ghc" colspan="6">
                                                                    Type of Check</td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td align="left" class="lc" style="width: 25%;">
                                                                    <asp:Label runat="server" ID="lblFVFullRefund">Full Refund?</asp:Label>
                                                                </td>
                                                                <td align="Center" class="lc" >
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic" style="width: 25%;">
                                                                    <asp:RadioButton ID="rbtnFRefundYes" runat="server" GroupName="FullRefund" Text="Yes" />&nbsp;
                                                                    <asp:RadioButton ID="rbtnFRefundNo" runat="server" GroupName="FullRefund" Text="No" Checked="true"/>
                                                                </td>
                                                                <td align="left" class="lc" style="width: 25%;">
                                                                    <asp:Label runat="server" ID="lblFVPartRefund">Partial Refund?</asp:Label>
                                                                </td>
                                                                <td align="Center" class="lc" >
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic" style="width: 25%;">
                                                                    <asp:RadioButton ID="rbtnPartRefundYes" runat="server" GroupName="PartRefund" Text="Yes" />&nbsp;
                                                                    <asp:RadioButton ID="rbtnPartRefundNo" runat="server" GroupName="PartRefund" Text="No"/>
                                                                </td>
                                                            </tr>
                                                            
                                                        </table>
                                                        <table cellpadding="2" cellspacing="2" class="stylesheet" width="100%">
                                                            <tr>
                                                                <td class="ghc" colspan="6">
                                                                    Attachment
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr style="display:none;">
                                                                <td class="lc" style="width: 25%;">
                                                                    Attachment Type
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td class="ic" colspan="4" style="width:75%;">
                                                                    <asp:DropDownList runat="server" SkinID="dropGen" ID="ddlAttachType">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvAttachType" ControlToValidate="ddlAttachType"
                                                                        runat="server" InitialValue="--Select Attachment Type--" ValidationGroup="vsErrorGroup"
                                                                        ErrorMessage="Please Select the Attachment Type." Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc" style="width:25%;" valign="top">
                                                                    Attachment Description
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td colspan="4" class="ic" style="width:75%;" valign="top">
                                                                <asp:ImageButton ID="ibtnAttachment" ImageUrl="~/Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMax('attachment');" />
                                                                    <div id="pnlAttach" style="display:block;">
                                                                    <asp:TextBox ID="txtAttachDesc" runat="server" MaxLength="4000" TextMode="MultiLine" Height="100px"
                                                                        Width="95%"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc" style="width:25%;" valign="top">
                                                                    Select File
                                                                </td>
                                                                <td class="lc" align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td colspan="4" class="ic" style="width:75%;" valign="top">
                                                                    <asp:FileUpload runat="server" ID="uplCommon" />
                                                                    <asp:RequiredFieldValidator ID="rfvUpload" runat="server" ControlToValidate="uplCommon"
                                                                        InitialValue="" Display="none" Text="*" ErrorMessage="Please Select File to Upload." ValidationGroup="vsErrorGroup">                                                                        
                                                                    </asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            
                                                        </table>
                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                            <tr>
                                                                <td>
                                                                &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="ic" align="center">
                                                                    <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" OnClientClick="javascript:ValAttach();"
                                                                        OnClick="btnAddAttachment_Click" ValidationGroup="vsErrorGroup" />
                                                                    <asp:Button ID="btnSave" runat="server" Text="Save & View" ValidationGroup="vsErrorGroup"
                                                                        OnClientClick="javascript:ValSave();" OnClick="btnSave_Click" />
                                                                    <asp:Button ID="btnBack" runat="server" Text="Cancel" OnClick="btnBack_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </InsertItemTemplate>
                                                    <EditItemTemplate>
                                                        <table border="0" cellpadding="2" cellspacing="2" class="lc" width="100%">
                                                            <tr>
                                                                <td class="ghc" colspan="6">
                                                                    Check Information</td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td align="left" class="lc" style="width: 25%">
                                                                    <asp:Label runat="server" ID="lblFVChkAmt">Check Amount</asp:Label>&nbsp;<span
                                                                        class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc" >
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic" style="width: 25%">
                                                                    $<asp:TextBox ID="txtCheckAmt" runat="server" MaxLength="9" SkinID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                        Text='<%#Eval("Check_Amount") %>'></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="rfvCheckAmt" ControlToValidate="txtCheckAmt"
                                                                        ErrorMessage="Please Enter Check Amount." Display="none" Text="*" InitialValue="" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="left" class="lc" style="width: 25%">
                                                                    <asp:Label runat="server" ID="lblFVProviderName">Provider Name</asp:Label>
                                                                    &nbsp;<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc" >
                                                                    :
                                                                </td>
                                                             <%--   <asp:UpdatePanel ID="pnlprov" runat="server">
                                                                   <contenttemplate>--%>
                                                                <td align="left"  class="ic" style="width: 25%">
                                                                    <asp:DropDownList runat="server" ID="dwProviderName" AutoPostBack="true" OnSelectedIndexChanged="dwProviderName_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator runat="server" ID="rfvProviderName" ControlToValidate="dwProviderName"
                                                                        ErrorMessage="Please Select Provider Name." Display="none" Text="*" InitialValue="--Select Provider--"
                                                                        ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                                        
                                                                     
                                                                </td>
                                                                
                                                                <%--  </contenttemplate>
                                                                    </asp:UpdatePanel>--%>
                                                            </tr>
                                                            <tr>
                                                                
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVPAdd1">Provider Address (1) </asp:Label><span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:TextBox ID="txtPAdd1" runat="server" ReadOnly="true" Text='<%#Eval("Address_1") %>'></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="rfvPAdd1" ControlToValidate="txtPAdd1"
                                                                        ErrorMessage="Please Enter Provider Address (1)." Display="none" Text="*" InitialValue=""
                                                                        ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVPAdd2">Provider Address (2) </asp:Label><span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:TextBox ID="txtPAdd2" runat="server" ReadOnly="true" Text='<%#Eval("Address_2") %>'></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="rfvPAdd2" ControlToValidate="txtPAdd2"
                                                                        ErrorMessage="Please Enter Provider Address (2)." Display="none" Text="*" InitialValue=""
                                                                        ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVPTaxIDNo">Provider Tax Id Number </asp:Label><span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:TextBox ID="txtPTaxID" runat="server" ReadOnly="true" Text='<%#Eval("Tax_Id") %>'></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="rfvPTaxID" ControlToValidate="txtPTaxID"
                                                                        ErrorMessage="Please Enter Provider Tax Id Number." Display="none" Text="*" InitialValue=""
                                                                        ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVPCity">Provider City  </asp:Label><span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:TextBox ID="txtPCity" runat="server" ReadOnly="true" Text='<%#Eval("City") %>'></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="rfvPCity" ControlToValidate="txtPCity"
                                                                        ErrorMessage="Please Enter Provider City." Display="none" Text="*" InitialValue="" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVPState">Provider State </asp:Label><span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:TextBox ID="txtPState" runat="server" ReadOnly="true" Text='<%#Eval("State") %>'></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="rfvPState" ControlToValidate="txtPState"
                                                                        ErrorMessage="Please Enter Provider State." Display="none" Text="*" InitialValue="" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVPZip">Provider Zip Code </asp:Label><span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:TextBox ID="txtPZip" runat="server" ReadOnly="true" Text='<%#Eval("Zip_Code") %>'></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="rfvPZip" ControlToValidate="txtPZip"
                                                                        ErrorMessage="Please Enter Provider Zip Code." Display="none" Text="*" InitialValue=""
                                                                        ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVOriginChkNo">Original Check Number </asp:Label><span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:TextBox ID="txtCheckNo" MaxLength="6" runat="server" onkeypress="return numberOnly(event);"
                                                                        Text='<%#Eval("Check_Number") %>'></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="rfvCheckNo" ControlToValidate="txtCheckNo"
                                                                        ErrorMessage="Please Enter Original Check Number." Display="none" Text="*" InitialValue=""
                                                                        ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVSubrogation">Subrogation?</asp:Label>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:RadioButton ID="rbtnSubrogationYes" runat="server" GroupName="Subrogation" Text="Yes" />&nbsp;
                                                                    <asp:RadioButton ID="rbtnSubrogationNo" runat="server" GroupName="Subrogation" Text="No" Checked="true" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVAutoSalvage">Auto Salvage?</asp:Label>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:RadioButton ID="rbtnSalvageYes" runat="server" GroupName="Salvage" Text="Yes" />&nbsp;
                                                                    <asp:RadioButton ID="rbtnSalvageNo" runat="server" GroupName="Salvage" Text="No" Checked="true"/>
                                                                </td>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVOther">Other?</asp:Label>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:RadioButton ID="rbtnOtherYes" runat="server" GroupName="Other" Text="Yes" />&nbsp;
                                                                    <asp:RadioButton ID="rbtnOtherNo" runat="server" GroupName="Other" Text="No" Checked="true"/>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="lc" valign="top">
                                                                    <asp:Label runat="server" ID="lblFVOtherDesc">Other Description</asp:Label>
                                                                </td>
                                                                <td align="center" class="ic" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic" colspan="4" valign="top">
                                                                    <asp:ImageButton ID="ibtnCheck" ImageUrl="../../Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMax('check');" />
                                                                    <div id="pnlCheck" style="display:block;">
                                                                        <asp:TextBox ID="txtDescription" runat="server" Text='<%#Eval("Other_Description") %>' Height="100px"
                                                                            TextMode="MultiLine" MaxLength="4000" Width="95%"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            
                                                        </table>
                                                        <table cellpadding="2" cellspacing="2" style="width: 100%;">
                                                            <tr>
                                                                <td class="ghc" colspan="6">
                                                                    Recovery Breakdown
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="lc" style="width: 25%;">
                                                                    <asp:Label runat="server" ID="lblFVPaymentID">Payment ID</asp:Label>
                                                                </td>
                                                                <td align="center" class="lc" 5>
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic" style="width: 25%;">
                                                                    <asp:DropDownList runat="server" ID="dwPaymentID" AutoPostBack="true" OnSelectedIndexChanged="dwPaymentID_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 25%;">
                                                                    &nbsp;</td>
                                                                <td >
                                                                    &nbsp;</td>
                                                                <td style="width: 25%;">
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVPaycode">Paycode</asp:Label>
                                                                </td>
                                                                <td class="lc" align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic" colspan="4">
                                                                    <asp:DropDownList runat="server" ID="dwPayCode" SkinID="dropGen" Width="96%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="ic" valign="top">
                                                                    <asp:Label runat="server" ID="lblFVRecoverDesc">Recovery Description</asp:Label>
                                                                </td>
                                                                <td class="lc" align="center" valign="top">
                                                                    :</td>
                                                                <td class="ic" colspan="4" valign="top">
                                                                    <asp:ImageButton ID="ibtnRecovery" ImageUrl="../../Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMax('recovery');" />
                                                                    <div id="pnlRecovery" style="display:block;">
                                                                        <asp:TextBox runat="server" ID="txtRecoveryDesc" MaxLength="4000" TextMode="MultiLine" Height="100px"
                                                                            Text='<%#Eval("Recovery_Description") %>' Width="95%"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            
                                                        </table>
                                                        <table border="0" cellpadding="2" cellspacing="2" class="stylesheet" width="100%">
                                                            <tr>
                                                                <td class="ghc" colspan="6">
                                                                    Type of Check</td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td align="left" class="lc" style="width:25%;">
                                                                    <asp:Label runat="server" ID="lblFVFullRefund">Full Refund?</asp:Label>&nbsp;
                                                                </td>
                                                                <td align="Center" class="lc" >
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic" style="width:25%;">
                                                                    <asp:RadioButton ID="rbtnFRefundYes" runat="server" GroupName="FullRefund" Text="Yes" />&nbsp;
                                                                    <asp:RadioButton ID="rbtnFRefundNo" runat="server" GroupName="FullRefund" Text="No" Checked="true"/>
                                                                </td>
                                                                <td align="left" class="lc" style="width:25%;">
                                                                    <asp:Label runat="server" ID="lblFVPartRefund">Partial Refund?</asp:Label>&nbsp;
                                                                </td>
                                                                <td align="Center" class="lc" >
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic" style="width:25%;">
                                                                    <asp:RadioButton ID="rbtnPartRefundYes" runat="server" GroupName="PartRefund" Text="Yes" />&nbsp;
                                                                    <asp:RadioButton ID="rbtnPartRefundNo" runat="server" GroupName="PartRefund" Text="No"/>
                                                                </td>
                                                            </tr>
                                                            
                                                        </table>
                                                        <table cellpadding="2" cellspacing="2" class="stylesheet" width="100%">
                                                            <tr>
                                                                <td class="ghc" colspan="6">
                                                                    Attachment
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr style="display:none;">
                                                                <td class="lc" style="width: 25%;" valign="top">
                                                                    Attachment Type
                                                                </td>
                                                                <td  align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td class="ic" colspan="4" style="width:75%;" valign="top">
                                                                    <asp:DropDownList runat="server" SkinID="dropGen" ID="ddlAttachType">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvAttachType" ControlToValidate="ddlAttachType"
                                                                        runat="server" InitialValue="--Select Attachment Type--" ValidationGroup="vsErrorGroup"
                                                                        ErrorMessage="Please Select the Attachment Type." Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc" style="width: 25%" valign="top">
                                                                    Attachment Description
                                                                </td>
                                                                <td  align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td colspan="4" class="ic" style="width:75%;" valign="top">
                                                                    <asp:ImageButton ID="ibtnAttachment" ImageUrl="../../Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMax('attachment');" />
                                                                    <div id="pnlAttach" style="display:block;">
                                                                        <asp:TextBox ID="txtAttachDesc" runat="server" TextMode="MultiLine" Width="95%" Height="100px" MaxLength="4000"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc" valign="top">
                                                                    Select File
                                                                </td>
                                                                <td class="lc" align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td colspan="4" class="ic" valign="top">
                                                                    <asp:FileUpload runat="server" ID="uplCommon" />
                                                                    <asp:RequiredFieldValidator ID="rfvUpload" runat="server" ControlToValidate="uplCommon"
                                                                        InitialValue="" Display="none" Text="*" ErrorMessage="Please Select File to Upload." ValidationGroup="vsErrorGroup">                                                                        
                                                                    </asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            
                                                        </table>
                                                        <table cellpadding="0" cellspacing="2" border="0" width="100%">
                                                            <tr>
                                                                <td>
                                                                &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="ic" align="center">
                                                                    <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" OnClientClick="javascript:ValAttach();"
                                                                        OnClick="btnAddAttachment_Click" ValidationGroup="vsErrorGroup" />
                                                                    <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click"
                                                                        OnClientClick="javascript:ValSave();" ValidationGroup="vsErrorGroup" />
                                                                    <asp:Button ID="btnBack" runat="server" Text="Cancel" OnClick="btnBack_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <table border="0" cellpadding="2" cellspacing="2" class="lc" width="100%">
                                                            <tr>
                                                                <td class="ghc" colspan="6">
                                                                    Check Information</td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td align="left" class="lc" style="width: 25%">
                                                                    <asp:Label runat="server" ID="lblFVChkAmt">Check Amount</asp:Label>&nbsp;
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic" style="width: 25%">
                                                                     $<asp:Label runat="server" ID="lblcheckamount" Text='<%#Eval("Check_Amount") %>'></asp:Label>
                                                                </td>
                                                                <td align="left" class="lc" style="width: 25%">
                                                                    <asp:Label runat="server" ID="lblFVProviderName">Provider Name</asp:Label>
                                                                    
                                                                </td>
                                                                <td align="Center" class="lc" >
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic" style="width: 25%">
                                                                    <asp:Label runat="server" ID="lblProviderName" Text='<%#Eval("Name") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVPAdd1">Provider Address (1) </asp:Label>
                                                                    
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:Label runat="server" ID="lblPAdd1" Text='<%#Eval("Address_1") %>'></asp:Label>
                                                                </td>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVPAdd2">Provider Address (2) </asp:Label>
                                                                    
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:Label runat="server" ID="lblPAdd2" Text='<%#Eval("Address_2") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVPTaxIDNo">Provider Tax Id Number </asp:Label>
                                                                    
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:Label runat="server" ID="lblPTaxID" Text='<%#Eval("Tax_Id") %>'></asp:Label>
                                                                </td>
                                                                
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVPCity">Provider City  </asp:Label>&nbsp;
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:Label runat="server" ID="lblPCity" Text='<%#Eval("City") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVPState">Provider State </asp:Label>
                                                                    
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:Label runat="server" ID="lblPState" Text='<%#Eval("State") %>'></asp:Label>
                                                                </td>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVPZip">Provider Zip Code </asp:Label>
                                                                    
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:Label runat="server" ID="lblPZip" Text='<%#Eval("Zip_Code") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVOriginChkNo">Original Check Number </asp:Label>&nbsp;
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:Label runat="server" ID="lblCheckNo" Text='<%#Eval("Check_Number") %>'></asp:Label>
                                                                </td>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVSubrogation">Subrogation?</asp:Label>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:Label runat="server" ID="lblSubrogation"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVAutoSalvage">Auto Salvage?</asp:Label>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:Label runat="server" ID="lblAutoSalvage"></asp:Label>
                                                                </td>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVOther">Other?</asp:Label>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic">
                                                                    <asp:Label runat="server" ID="lblOther"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="lc">
                                                                    <asp:Label runat="server" ID="lblFVOtherDesc">Other Description</asp:Label>
                                                                </td>
                                                                <td align="center" class="ic">
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic" colspan="4">
                                                                    <asp:Label runat="server" ID="lblDesc" Text='<%#Eval("Other_Description") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            
                                                        </table>
                                                        <table cellpadding="2" cellspacing="2" style="width: 100%;">
                                                            <tr>
                                                                <td class="ghc" colspan="6">
                                                                    Recovery Breakdown
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="lc" style="width:25%;">
                                                                    <asp:Label runat="server" ID="lblFVPaymentID">Payment ID</asp:Label>
                                                                </td>
                                                                <td align="Center" class="lc" >
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic" style="width:25%;">
                                                                    <asp:Label runat="server" ID="lblPaymentID" Text='<%#Eval("Payment_Id") %>'></asp:Label>
                                                                </td>
                                                                <td align="left" class="lc" style="width:25%;">
                                                                    <asp:Label runat="server" ID="lblFVPaycode">Paycode</asp:Label>
                                                                </td>
                                                                <td align="Center" class="lc" >
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic" style="width:25%;">
                                                                    <asp:Label runat="server" ID="lblPayCode"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="ic">
                                                                    <asp:Label runat="server" ID="lblFVRecoverDesc">Recovery Description</asp:Label>
                                                                </td>
                                                                <td class="lc" align="Center">
                                                                    :</td>
                                                                <td class="ic" colspan="4">
                                                                    <asp:Label runat="server" ID="lblRecoveryDesc" Text='<%#Eval("Recovery_Description") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            
                                                        </table>
                                                        <table border="0" cellpadding="2" cellspacing="2" class="stylesheet" width="100%">
                                                            <tr>
                                                                <td class="ghc" colspan="6">
                                                                    Type of Check</td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td align="left" class="lc" style="width:25%;">
                                                                    <asp:Label runat="server" ID="lblFVFullRefund">Full Refund?</asp:Label>
                                                                </td>
                                                                <td align="Center" class="lc" >
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic" style="width:25%;">
                                                                    <asp:Label runat="server" ID="lblFullRefund"></asp:Label>
                                                                </td>
                                                                <td align="left" class="lc" style="width:25%;">
                                                                    <asp:Label runat="server" ID="lblFVPartRefund">Partial Refund?</asp:Label>
                                                                </td>
                                                                <td align="Center" class="lc" >
                                                                    :
                                                                </td>
                                                                <td align="left" class="ic" style="width:25%;">
                                                                    <asp:Label runat="server" ID="lblPartRefund"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            
                                                        </table>
                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                            <tr>
                                                                <td class="ic" align="center">
                                                                    <asp:Button ID="btnSave" runat="server" Text="Save & View" Enabled="false" OnClick="btnSave_Click" />
                                                                    <asp:Button ID="btnBack" runat="server" Text="Cancel" OnClick="btnBack_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:FormView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div id="dvAttachDetails" runat="server" style="width: 100%; display: none;">
                                                    <table width="100%" border="0">
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
                                                                        <asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" Visible="false"></asp:BoundField>
                                                                        <asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description">
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Attachment_Name1" HeaderText="File Name"></asp:BoundField>
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
                                                                        Currently there is no attachement.
                                                                    </EmptyDataTemplate>
                                                                    <PagerSettings Visible="False" />
                                                                    <PagerSettings Visible="False" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 5%;" align="left">
                                                                <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:Button ID="btnMail" runat="server" Text="Mail" OnClientClick="javascript:return OpenWMail('gvAttachmentDetails','Worker_Comp_Subrogation');" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                            </asp:MultiView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HiddenField runat="server" ID="hdnTemp" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="divbtn" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td align="center" class="ic">
                        <asp:Button ID="btnNextStep" runat="server" OnClick="btnNextStep_Click" Text="Next Step" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="divView" runat="server" style="display: none;">
            <table cellpadding="2" cellspacing="2" border="0" style="width: 100%;">
                <tr>
                    <td align="left" colspan="6" class="ghc">
                        Claim ID</td>
                </tr>
                <tr>
                    <td style="width:25%;" align="left" class="lc">
                        <asp:Label runat="server" ID="lblDClaimNo">Claim Number</asp:Label>
                    </td>
                    <td  align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%;" align="left" class="ic">
                        <asp:Label runat="server" ID="lblVClaimNo"></asp:Label>
                    </td>
                    <td align="left" class="lc">
                        <asp:Label runat="server" ID="lblDDOIncident">Date of Incident</asp:Label>
                    </td>
                    <td align="Center" class="lc">
                        :
                    </td>
                    <td align="left" class="ic">
                        <asp:Label runat="server" ID="lblVDOInci"></asp:Label>
                    </td>
                    
                </tr>
                <tr>
                    <td align="left" class="lc">
                        <asp:Label runat="server" ID="lblDLastName">Name</asp:Label>
                    </td>
                    <td align="Center" class="lc">
                        :
                    </td>
                    <td align="left" class="ic">
                        <asp:Label runat="server" ID="lblVLastName"></asp:Label>
                        <asp:Label runat="server" ID="lblVMiddleMName"></asp:Label>
                        <asp:Label runat="server" ID="lblVFirstName"></asp:Label>
                    </td>
                    <td style="width:25%;" align="left" class="lc">
                        <asp:Label runat="server" ID="lblDEmployee">Employee</asp:Label>
                    </td>
                    <td  align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%;" align="left" class="ic">
                        <asp:Label runat="server" ID="lblVEmployee"></asp:Label>
                    </td>
                </tr>                
                
                <tr>
                    <td colspan="6">
                        <asp:GridView runat="server" ID="gvViewAll" AutoGenerateColumns="false" Width="100%"
                            OnRowDataBound="gvViewAll_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table border="0" cellpadding="2" cellspacing="2" class="lc" width="100%">
                                            <tr>
                                                <td class="ghc" colspan="6">
                                                    Check Information</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" ID="lblSubrogationID" Text='<%#Eval("PK_Subrogation") %>'
                                                        Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="lc" style="width:25%;">
                                                    <asp:Label runat="server" ID="lblGVChkAmt">Check Amount $</asp:Label>
                                                </td>
                                                <td align="Center" class="lc" >
                                                    :
                                                </td>
                                                <td align="left" class="ic" style="width: 25%">
                                                    <asp:Label runat="server" ID="lblVcheckamount" Text='<%#Eval("Check_Amount") %>'></asp:Label>
                                                </td>
                                                <td align="left" class="lc" style="width:25%;">
                                                    <asp:Label runat="server" ID="lblGVProviderName">Provider Name</asp:Label>
                                                </td>
                                                <td align="Center" class="lc" >
                                                    :
                                                </td>
                                                <td align="left" class="ic" style="width: 25%">
                                                    <asp:Label runat="server" ID="lblVProviderName" Text='<%#Eval("Name") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblGVPTaxIDNo">Provider Tax Id Number </asp:Label>
                                                </td>
                                                <td align="Center" class="lc">
                                                    :
                                                </td>
                                                <td align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblVPTaxID" Text='<%#Eval("Tax_Id") %>'></asp:Label>
                                                </td>
                                                <td align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblGVPAdd1">Provider Address (1) </asp:Label>
                                                </td>
                                                <td align="Center" class="lc">
                                                    :
                                                </td>
                                                <td align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblVPAdd1" Text='<%#Eval("Address_1") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblGVPAdd2">Provider Address (2) </asp:Label>
                                                </td>
                                                <td align="Center" class="lc">
                                                    :
                                                </td>
                                                <td align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblVPAdd2" Text='<%#Eval("Address_2") %>'></asp:Label>
                                                </td>
                                                <td align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblGVPCity">Provider City  </asp:Label>
                                                </td>
                                                <td align="Center" class="lc">
                                                    :
                                                </td>
                                                <td align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblVPCity" Text='<%#Eval("City") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblGVPState">Provider State </asp:Label>
                                                </td>
                                                <td align="Center" class="lc">
                                                    :
                                                </td>
                                                <td align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblVPState" Text='<%#Eval("State") %>'></asp:Label>
                                                </td>
                                                <td align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblGVPZip">Provider Zip Code </asp:Label>
                                                </td>
                                                <td align="Center" class="lc">
                                                    :
                                                </td>
                                                <td align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblVPZip" Text='<%#Eval("Zip_Code") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblGVOriginChkNo">Original Check Number </asp:Label>
                                                </td>
                                                <td align="Center" class="lc">
                                                    :
                                                </td>
                                                <td align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblVCheckNo" Text='<%#Eval("Check_Number") %>'></asp:Label>
                                                </td>
                                                <td align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblGVSubrogation">Subrogation?</asp:Label>
                                                </td>
                                                <td align="Center" class="lc">
                                                    :
                                                </td>
                                                <td align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblVSubrogation"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblGVAutoSalvage">Auto Salvage?</asp:Label>
                                                </td>
                                                <td align="Center" class="lc">
                                                    :
                                                </td>
                                                <td align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblVAutoSalvage"></asp:Label>
                                                </td>
                                                <td align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblGVOther">Other?</asp:Label>
                                                </td>
                                                <td align="Center" class="lc">
                                                    :
                                                </td>
                                                <td align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblVOther"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblGVOtherDesc">Other Description</asp:Label>
                                                </td>
                                                <td align="center" class="ic">
                                                    :
                                                </td>
                                                <td align="left" class="ic" colspan="4">
                                                    <asp:Label runat="server" ID="lblVDesc" Text='<%#Eval("Other_Description") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                        <table cellpadding="2" cellspacing="2" style="width: 100%;">
                                            <tr>
                                                <td class="ghc" colspan="6">
                                                    Recovery Breakdown
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="lc" style="width:25%;">
                                                    <asp:Label runat="server" ID="lblGVPaymentID">Payment ID</asp:Label>
                                                </td>
                                                <td align="Center" class="lc" >
                                                    :
                                                </td>
                                                <td align="left" class="ic"style="width:25%;">
                                                    <asp:Label runat="server" ID="lblVPaymentID" Text='<%#Eval("Payment_Id") %>'></asp:Label>
                                                </td>
                                                <td align="left" class="lc" style="width:25%;">
                                                    <asp:Label runat="server" ID="lblGVPaycode">Paycode</asp:Label>
                                                </td>
                                                <td align="Center" class="lc">
                                                    :
                                                </td>
                                                <td align="left" class="ic" style="width:25%;">
                                                    <asp:Label runat="server" ID="lblVPayCode"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="ic">
                                                    <asp:Label runat="server" ID="lblGVRecoverDesc">Recovery Description</asp:Label>
                                                </td>
                                                <td class="lc" align="Center">
                                                    :</td>
                                                <td class="ic" colspan="4">
                                                    <asp:Label runat="server" ID="lblVRecoveryDesc" Text='<%#Eval("Recovery_Description") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                        <table border="0" cellpadding="2" cellspacing="2"  width="100%">
                                            <tr>
                                                <td class="ghc" colspan="6">
                                                    Type of Check</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="lc" style="width:25%;">
                                                    <asp:Label runat="server" ID="lblGVFullRefund">Full Refund?</asp:Label>
                                                </td>
                                                <td align="Center" class="lc" >
                                                    :
                                                </td>
                                                <td align="left" class="ic" style="width:25%;">
                                                    <asp:Label runat="server" ID="lblVFullRefund"></asp:Label>
                                                </td>
                                                <td align="left" class="lc" style="width:25%;">
                                                    <asp:Label runat="server" ID="lblGVPartRefund">Partial Refund?</asp:Label>
                                                </td>
                                                <td align="Center" class="lc" >
                                                    :
                                                </td>
                                                <td align="left" class="ic" style="width:25%;">
                                                    <asp:Label runat="server" ID="lblVPartRefund"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                <table style="width: 100%;" border="0" cellpadding="2" cellspacing="4">
                                    <tr>
                                        <td align="center">
                                            Currently there is no Subrogation for the following claim.
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <PagerSettings Visible="false" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <table width="100%">
                            <tr>
                                <td colspan="2">
                                    <table cellspacing="0" width="100%" style="background-color: #7f7f7f; color: White;
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
                                    <asp:GridView ID="gvViewAttachment" runat="server" AutoGenerateColumns="false" DataKeyNames="PK_Attachment_ID"
                                        Width="100%" AllowPaging="True" AllowSorting="True" OnRowDataBound="gvAttachmentDetails_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <input name="chkItem" type="checkbox" value='<%# Eval("PK_Attachment_ID")%>' onclick="javascript:UnCheckHeader('gvViewAttachment')" />
                                                </ItemTemplate>
                                                <ItemStyle Width="10px" />
                                                <HeaderTemplate>
                                                    <input type="checkbox" name="chkHeader" id="chkHeader" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                                </HeaderTemplate>
                                                <HeaderStyle Width="10px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" Visible="false"></asp:BoundField>
                                            <asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Attachment_Name1" HeaderText="File Name"></asp:BoundField>
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
                                            Currently there is no attachement.
                                        </EmptyDataTemplate>
                                        <PagerSettings Visible="False" />
                                        <PagerSettings Visible="False" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <%--<tr>
                    <td colspan="2">
                        <asp:Button ID="btnViewMail" runat="server" Text="Mail" OnClientClick="javascript:return OpenWMail('gvViewAttachment','Worker_Comp_Subrogation');" />
                    </td>
                </tr>--%>
                <tr>
                    <td colspan="6">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="6">
                        <asp:Button runat="server" ID="btnViewNext" Text="Next Step" OnClick="btnViewNext_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <table>
        <tr>
            <td>
            </td>
        </tr>
    </table>
    <%-- </contenttemplate>
    </asp:UpdatePanel>--%>

    <script type="text/javascript">
        
        if(document.getElementById("ctl00_ContentPlaceHolder1_hdnTemp").value!="")
            partialrefund();
    </script>

</asp:Content>
