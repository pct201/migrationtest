<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="MainDiary.aspx.cs"
    Inherits="WorkerCompensation_MainDiary" Title="Risk Management Insurance System"
    Theme="Default"   %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<div style="width: 100%;">
   <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="false"
            ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
    <asp:Label runat="server" Visible="false" ID="lblScript"></asp:Label>
</div>

    <script type="text/javascript" src="../JavaScript/JFunctions.js">
    </script><script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>

    <link href="../App_Themes/Default/stylecal.css" type="text/css" rel="Stylesheet" />

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
    oWnd=window.open("../ErimsMail.aspx?AttMod="+attTbl+"&AttIds=" + m_strAttIds ,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=600,height=300");
    oWnd.moveTo(260,180);
    return false;
  }  
  
    function MinMaxI()
    {
        if(document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtINote").style.height == "")
        {
            document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_ibtnIDisplay").src = "../Images/minus.jpg";
            document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtINote").style.height = "200px";
            document.getElementById("pnlTemp").style.display = "block";
        }
        else if(document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtINote").style.height == "200px")
        {
             document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_ibtnIDisplay").src = "../Images/plus.jpg";
            document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtINote").style.height="";
            document.getElementById("pnlTemp").style.display = "none";
        }
        return false;
    }
     function MinMax()
    {
        if(document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtNote").style.height == "")
        {
            document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_ibtnDisplay").src = "../Images/minus.jpg";
            document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtNote").style.height = "200px";
            document.getElementById("pnlETemp").style.display = "block";
        }
        else if(document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtNote").style.height == "200px")
        {
             document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_ibtnDisplay").src = "../Images/plus.jpg";
            document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtNote").style.height="";
            document.getElementById("pnlETemp").style.display = "none";
        }
        return false;
    }
    function displayDetail()
    {
        document.getElementById("ctl00_ContentPlaceHolder1_divfirst").style.display ="none";   
        document.getElementById("ctl00_ContentPlaceHolder1_divthird").style.display ="block";
        document.getElementById("ctl00_ContentPlaceHolder1_divbtn").style.display ="none"; 
        return false;
    }

    function openPopUp(assignTo)
    {
        oWnd=window.open("DiaryUser.aspx","Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");	
        oWnd.moveTo(260,180);
        return false;
    }

    </script>

    <asp:UpdatePanel ID="pnlBankDetail" runat="server">
        <contenttemplate>
            <div id="contmain" runat="server" style="width: 100%;">
                <br />
                
                <div id="Div1" runat="server" style="width: 100%; text-align: center">
                    <table border="0" cellpadding="1" cellspacing="0" width="99%">
                        <tr>
                            <td align="center" style="background-image: url('../images/normal_btn.jpg')" class="normal_tab"
                                valign="middle">
                                <a class="main_menu" href="Workers_ Compensation.aspx">Worker's Compensation</a></td>
                            <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                                valign="middle">
                                <a class="main_menu" href="WorkerCompensationReserve.aspx">Reserve Worksheets</a></td>
                            <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                                valign="middle">
                                <a class="main_menu" href="Carrier.aspx">Carrier Data</a></td>
                            <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                                valign="middle">
                                <a class="main_menu" href="subrogation.aspx">Subrogation</a></td>
                            <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                                valign="middle">
                                <a class="main_menu" href="SubrogationDetail.aspx">Subrogation Detail</a></td>
                            <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                                valign="middle">
                                <a class="main_menu" href="CheckRegister.aspx">Check Register</a></td>
                            <td align="center" class="active_tab" style="background-image: url('../images/active_btn.jpg')"
                                valign="middle">
                                Diary</td>
                            <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                                valign="middle">
                                <a class="main_menu" href="MainAdjuster.aspx">Adjustor Notes</a></td>
                            <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                                valign="middle">
                                <a class="main_menu" href="Settlement.aspx">Settlement</a></td>
                        </tr>
                    </table>
                </div>
                <div id="leftDiv" runat="server" style="width: 18%; height: 350px; float: left; border: solid 1px #7F7F7F;
                    margin: 1px 1px 1px 4px;">
                    <table border="0" cellpadding="0" cellspacing="0" width="90%">
                        <tr>
                            <td style="width: 15%">
                                &nbsp;</td>
                            <td style="width: 85%" runat="server" id="temp">
                                <asp:LinkButton id="first" runat="server" CssClass="left_menu_active" OnClick="first_Click"
                                    Text="Claim Details" ></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                    <asp:LinkButton id="second" runat="server" CssClass="left_menu" OnClick="second_Click"
                                    Text="Diary Data" ></asp:LinkButton>
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
                                <td  align="Center" class="lc">
                                    :
                                </td>
                                <td style="width:25%;" align="left" class="ic">
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
                                <td  align="Center" class="lc">
                                    :
                                </td>
                                <td style="width:25%;" align="left" class="ic">
                                    <asp:RadioButtonList ID="rbtnEmployee" runat="server" Enabled="false" RepeatDirection="Horizontal">
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                               
                               
                               
                                <%--<td style="width:25%;" align="left" class="lc">
                                    <asp:Label runat="server" ID="lblMFirstName"> First Name</asp:Label>
                                </td>
                                <td  align="Center" class="lc">
                                    :
                                </td>
                                <td style="width:25%;" align="left" class="ic">
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
                    <div id="divSearch" runat="server" style="display: none;">
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="width: 80%;display:none;" align="right">
                                    <table style="width:60%;">
                                        <tr>
                                            <td class="lc">
                                                Search
                                            </td>
                                            <td class="ic">
                                                <asp:DropDownList ID="ddlSearch" runat="server" SkinID="dropGen">
                                                    <asp:ListItem Value="UserDiary">User</asp:ListItem>
                                                    <asp:ListItem Value="File_Number">File Number</asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td class="ic">
                                                <asp:TextBox ID="txtSearch" runat="server" MaxLength="20"></asp:TextBox></td>
                                            <td class="ic">
                                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /></td>
                                        </tr>
                                    </table>
                                </td>
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
                                               <asp:Panel runat="server" ID="pnl" DefaultButton="btnGo" >
                                                <asp:TextBox ID="txtPageNo" runat="server" MaxLength="3" Width="20px" onkeypress="return numberOnly(event);"></asp:TextBox>
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
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    <asp:MultiView runat="server" ID="mvDiaryDetails">
                                        <asp:View runat="server" ID="vwDiaryList">
                                            <table style="width:100%;">
                                                <tr>
                                                    <td>
                                                        <table style="text-align: right;width:100%;">
                                                            <tr>
                                                                <td class="ic">
                                                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Click here to delete Diary Details"
                                                                        OnClick="btnDelete_Click" />
                                                                    <asp:Button ID="btnAddNew" runat="server" Text="Add New" ToolTip="Add new Diary Details"
                                                                        OnClick="btnAddNew_Click" />
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td style="text-align: left;">
                                                                    <asp:GridView ID="gvDiaryDetails" runat="server" AutoGenerateColumns="false" OnRowCommand="gvDiaryDetails_RowCommand"
                                                                        DataKeyNames="PK_Diary_ID" Width="100%" OnPageIndexChanging="gvDiaryDetails_PageIndexChanging" OnRowDataBound="gvDiaryDetails_RowDataBound"
                                                                        AllowPaging="True" AllowSorting="True" OnSorting="gvDiaryDetails_Sorting" OnRowCreated="gvDiaryDetails_RowCreated" >
                                                                                                                                                
                                                                        <Columns>
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <input name="chkItem" type="checkbox" value='<%# Eval("PK_Diary_ID")%>' onclick="javascript:UnCheckHeader('gvDiaryDetails')" />
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="10px" />
                                                                                <HeaderTemplate>
                                                                                    <input type="checkbox" name="chkHeader"  id="chkHeader" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                                                                </HeaderTemplate>
                                                                                <HeaderStyle Width="10px" />
                                                                            </asp:TemplateField>       
                                                                            <asp:TemplateField  HeaderText="Date Of Note Entry"   SortExpression="DateOfNoteEntry">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "DateOfNoteEntry", "{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>                                                                     
                                                                            <%--<asp:BoundField DataField="DateOfNoteEntry" HeaderText="Date Of Note Entry" SortExpression="DateOfNoteEntry">
                                                                            </asp:BoundField>--%>
                                                                            <asp:BoundField DataField="Assigned_To" HeaderText="Assigned To" SortExpression="Assigned_To">
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderText="Diary Date"  SortExpression="Diary_Date">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblDiary_Date" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Diary_Date", "{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField> 
                                                                            <asp:TemplateField HeaderText="">
                                                                                <ItemTemplate>
                                                                                    <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_Diary_ID")%>'
                                                                                        runat="server" Text="Edit" ToolTip="Edit the Diary Details" />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="" >
                                                                                <ItemTemplate>
                                                                                    <asp:Button ID="btnView" runat="server" Text="View"
                                                                                        CommandName="View" CommandArgument='<%#Eval("PK_Diary_ID")%>' ToolTip="View the Diary Details" />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                        <EmptyDataTemplate>
                                                                            No Diary found for the following claim.
                                                                        </EmptyDataTemplate>
                                                                        <PagerSettings Visible="False" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vwDiaryDetails" runat="server">
                                            <table style="width:100%;">
                                                <tr>
                                                    <td>
                                                        <div>
                                                            <table cellpadding="2" cellspacing="2" style="border: 1pt; border-color: #7f7f7f;
                                                                border-style: solid; text-align: left; width:100%;">
                                                                <tr>
                                                                    <td align="left" colspan="6" class="ghc">
                                                                        Claim Details</td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width:25%;" align="left" class="lc">
                                                                        <asp:Label runat="server" ID="lblFClaimNumber">Claim Number</asp:Label>
                                                                    </td>
                                                                    <td  align="Center" class="lc">
                                                                        :
                                                                    </td>
                                                                    <td style="width:25%;" align="left" class="ic">
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
                                                                    <td style="width:25%;" align="left" class="lc">
                                                                        <asp:Label runat="server" ID="lblFEmployee">Employee</asp:Label> 
                                                                    </td>
                                                                    <td  align="Center" class="lc">
                                                                        :
                                                                    </td>
                                                                    <td style="width:25%;" align="left" class="ic">
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
                                                        <asp:FormView runat="server" ID="fvDiaryDetails" OnDataBound="fvDiaryDetails_DataBound"
                                                            Width="100%">
                                                            <InsertItemTemplate>
                                                                <table cellpadding="2" cellspacing="2" border="0" style="width:100%;">
                                                                    <tr>
                                                                        <td>
                                                                            <div>
                                                                                <table cellpadding="2" cellspacing="2" style="width:100%;">
                                                                                    <tr>
                                                                                        <td align="left" colspan="6" class="ghc">
                                                                                            Diary Information</td>
                                                                                    </tr>
                                                                                   
                                                                                    <tr>
                                                                                        <td style="width:25%;" align="left" class="lc" valign="top">
                                                                                            <asp:Label runat="server" ID="lblDONEntry"> Date of Note Entry</asp:Label>                                                                                           
                                                                                        </td>
                                                                                        <td  align="Center" class="lc" valign="top">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="width:25%;" align="left" class="ic" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtIDONoteEntry" ValidationGroup="vsErrorGroup" SkinID="txtDate"></asp:TextBox>&nbsp;
                                                                                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvDiaryDetails_txtIDONoteEntry', 'mm/dd/y');"
                                                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                                                align="absmiddle" /><br />                                                                                           
                                                                                            <cc1:MaskedEditExtender ID="mskIDONoteEntry" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                                                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                                                OnInvalidCssClass="MaskedEditError" TargetControlID="txtIDONoteEntry" CultureName="en-US"
                                                                                                AutoComplete="true" AutoCompleteValue="05/23/1964" >
                                                                                            </cc1:MaskedEditExtender>
                                                                                            <cc1:MaskedEditValidator ID="mskValDtStart" runat="server" ControlExtender="mskIDONoteEntry"
                                                                                                ControlToValidate="txtIDONoteEntry" Display="dynamic" IsValidEmpty="True" MaximumValue=""
                                                                                                EmptyValueMessage="" InvalidValueMessage="Date is invalid"
                                                                                                MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue="" >
                                                                                            </cc1:MaskedEditValidator>
                                                                                            <asp:RegularExpressionValidator id="revIDONoteEntry" runat="server" ControlToValidate="txtIDONoteEntry"
                                                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                                                ErrorMessage="Date Not Valid(Date of Note Entry)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                                        </td>
                                                                                        <td style="width:25%;" align="left" class="lc">
                                                                                            <asp:Label runat="server" ID="lblDiaryDate" valign="top"> Diary Date</asp:Label>
                                                                                            <span class="mf">*</span>
                                                                                        </td>
                                                                                        <td  align="Center" class="lc" valign="top">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="width:25%;" align="left" class="ic" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtIDiaryDate" ValidationGroup="vsErrorGroup" SkinID="txtDate"></asp:TextBox>&nbsp;
                                                                                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvDiaryDetails_txtIDiaryDate', 'mm/dd/y');"
                                                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                                                align="absmiddle" />                                                                                            
                                                                                            <cc1:MaskedEditExtender ID="mskIDiaryDate" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                                                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                                                OnInvalidCssClass="MaskedEditError" TargetControlID="txtIDiaryDate" CultureName="en-US"
                                                                                                AutoComplete="true" AutoCompleteValue="05/23/1964" >
                                                                                            </cc1:MaskedEditExtender>
                                                                                            <cc1:MaskedEditValidator ID="mskValDtStart1" runat="server" ControlExtender="mskIDiaryDate"
                                                                                                ControlToValidate="txtIDiaryDate" Display="dynamic" IsValidEmpty="True" MaximumValue=""
                                                                                                InvalidValueMessage="Date is invalid" EmptyValueMessage="Please Select Diary Date."
                                                                                                MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                                                                                            </cc1:MaskedEditValidator>    
                                                                                            <asp:RequiredFieldValidator ID="rfvIDiaryDate" ControlToValidate="txtIDiaryDate" Display="none" Text="*" 
                                                                                                runat="server" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Diary Date."
                                                                                                ></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator id="revIDiaryDate" runat="server" ControlToValidate="txtIDiaryDate"
                                                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                                                ErrorMessage="Date Not Valid(Diary Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" class="lc" style="width:25%;" valign="top">
                                                                                            <asp:Label runat="server" ID="lblNote">Note</asp:Label>
                                                                                            
                                                                                        </td>
                                                                                        <td align="Center" class="lc" valign="top">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" class="ic" colspan="4" style="width:75%;" valign="top">
                                                                                            <asp:ImageButton ID="ibtnIDisplay" ImageUrl="~/Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMaxI();" />
                                                                                            <div id="pnlTemp" style="display:block;">
                                                                                                <asp:TextBox runat="server" ID="txtINote" Height="200px" MaxLength="4000" TextMode="MultiLine" Width="93%"></asp:TextBox>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" class="lc" style="width:25%;" valign="top">
                                                                                            <asp:Label runat="server" ID="lblClear"> Clear?</asp:Label>                                                                                            
                                                                                        </td>
                                                                                        <td align="Center" class="lc" valign="top">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" class="ic" style="width:25%;" valign="top">
                                                                                            <asp:RadioButton runat="server" GroupName="Clear" ID="rbIClearYes" Text="Yes" />&nbsp;
                                                                                            <asp:RadioButton runat="server" GroupName="Clear" ID="rbIClearNo" Text="No" Checked="true" />
                                                                                        </td>
                                                                                        <td align="left" class="lc" style="width:25%;" valign="top">
                                                                                            <asp:Label runat="server" ID="lblAssignTo">Assigned To</asp:Label>
                                                                                            <span class="mf">*</span>
                                                                                        </td>
                                                                                        <td align="Center" class="lc" valign="top">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" class="ic" style="width:25%;" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtIAssignTo" ReadOnly="true" Width="70%"></asp:TextBox>&nbsp;
                                                                                            <asp:Button ID="btnIAssignTO" Text="V" runat="server" CssClass="btn" />
                                                                                            <asp:RequiredFieldValidator ID="rfvIAssignTo" ControlToValidate="txtIAssignTo" runat="server"
                                                                                                InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Assigned To."
                                                                                                Display="none" Text="*"></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6" style="display:none;">
                                                                                            <asp:TextBox runat="server" ID="txtIAssignToID"></asp:TextBox>&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6">
                                                                                        &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="ic" align="center" colspan="6">
                                                                                            <asp:Button runat="server" ID="btnISaveView" SkinID="btnGen" Text="Save & View" ValidationGroup="vsErrorGroup"
                                                                                                OnClick="btnSaveView_Click" />                                                                                           
                                                                                            <asp:Button runat="server" ID="btnICancel" Text="Cancel" SkinID="btnGen" OnClick="btnCancel_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" class="lc" colspan="6">
                                                                                             <asp:UpdateProgress runat="server">
                                                                                                <ProgressTemplate>
                                                                                                   <span class="mf"> Mail sending process is going on, please wait...</span>
                                                                                                </ProgressTemplate>
                                                                                            </asp:UpdateProgress>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </InsertItemTemplate>
                                                            <EditItemTemplate>
                                                                <table cellpadding="3" cellspacing="0" border="0" style="width:100%;">
                                                                    <tr>
                                                                        <td>
                                                                            <div>
                                                                                <table cellpadding="2" cellspacing="2" style="width:100%;">
                                                                                    <tr>
                                                                                        <td align="left" colspan="6" class="ghc">
                                                                                            Diary Information</td>
                                                                                    </tr>
                                                                                   
                                                                                    <tr>
                                                                                        <td style="width:25%;" align="left" class="lc" valign="top">
                                                                                            <asp:Label runat="server" ID="lblDONEntry"> Date of Note Entry</asp:Label>
                                                                                        </td>
                                                                                        <td  align="Center" class="lc" valign="top">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="width:25%;" align="left" class="ic" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtDONoteEntry" ValidationGroup="vsErrorGroup" SkinID="txtDate"></asp:TextBox>&nbsp;
                                                                                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvDiaryDetails_txtDONoteEntry', 'mm/dd/y');"
                                                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                                                align="absmiddle" /><br />                                                                                             
                                                                                                <cc1:MaskedEditExtender ID="mskDONoteEntry" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                                                    Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtDONoteEntry" CultureName="en-US"
                                                                                                    AutoComplete="true" AutoCompleteValue="05/23/1964" >
                                                                                                </cc1:MaskedEditExtender>
                                                                                                <cc1:MaskedEditValidator ID="mskVDONoteEntry" runat="server" ControlExtender="mskDONoteEntry"
                                                                                                    ControlToValidate="txtDONoteEntry" Display="dynamic" IsValidEmpty="True" MaximumValue=""
                                                                                                    EmptyValueMessage="" InvalidValueMessage="Date is invalid"
                                                                                                    MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                                                                                                </cc1:MaskedEditValidator>
                                                                                                <asp:RegularExpressionValidator id="revDONoteEntry" runat="server" ControlToValidate="txtDONoteEntry"
                                                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                                                ErrorMessage="Date Not Valid(Date of Note Entry)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                                        </td>
                                                                                        <td style="width:25%;" align="left" class="lc" valign="top">
                                                                                            <asp:Label runat="server" ID="lblDiaryDate"> Diary Date</asp:Label>
                                                                                            <span class="mf">*</span>
                                                                                        </td>
                                                                                        <td  align="Center" class="lc" valign="top">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="width:25%;" align="left" class="ic" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtDiaryDate" ValidationGroup="vsErrorGroup" SkinID="txtDate"></asp:TextBox>
                                                                                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvDiaryDetails_txtDiaryDate', 'mm/dd/y');"
                                                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                                                align="absmiddle" />                                                                                            
                                                                                            <cc1:MaskedEditExtender ID="mskDiaryDate" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                                                    Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtDiaryDate" CultureName="en-US"
                                                                                                    AutoComplete="true" AutoCompleteValue="05/23/1964" >
                                                                                                </cc1:MaskedEditExtender>
                                                                                                <cc1:MaskedEditValidator ID="mskvDiaryDate" runat="server" ControlExtender="mskDiaryDate"
                                                                                                    ControlToValidate="txtDiaryDate" Display="dynamic" IsValidEmpty="False" MaximumValue=""
                                                                                                    EmptyValueMessage="" InvalidValueMessage="Date is invalid"
                                                                                                    MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                                                                                                </cc1:MaskedEditValidator>
                                                                                                <asp:RequiredFieldValidator ID="rfvDiaryDate" ControlToValidate="txtDiaryDate" Display="none" Text="*"
                                                                                                runat="server" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Diary Date." ></asp:RequiredFieldValidator>
                                                                                                <asp:RegularExpressionValidator id="revDiaryDate" runat="server" ControlToValidate="txtDiaryDate"
                                                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                                                ErrorMessage="Date Not Valid(Diary Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" class="lc" style="width:25%" valign="top">
                                                                                            <asp:Label runat="server" ID="lblNote">Note</asp:Label>
                                                                                        </td>
                                                                                        <td align="Center" class="lc" valign="top">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" class="ic" colspan="4" style="width:75%;" valign="top">
                                                                                            <asp:ImageButton ID="ibtnDisplay" ImageUrl="~/Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMax();" />
                                                                                            <div id="pnlETemp" style="display:block;">
                                                                                            <asp:TextBox runat="server" ID="txtNote" Height="200px" MaxLength="4000" TextMode="MultiLine" Width="93%"></asp:TextBox>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" class="lc" style="width:25%" valign="top">
                                                                                            <asp:Label runat="server" ID="lblClear"> Clear?</asp:Label>
                                                                                        </td>
                                                                                        <td align="Center" class="lc" valign="top">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" class="ic" style="width:25%" valign="top">
                                                                                            <asp:RadioButton runat="server" GroupName="Clear" ID="rbClearYes" Text="Yes" />&nbsp;
                                                                                            <asp:RadioButton runat="server" GroupName="Clear" ID="rbClearNo" Text="No" Checked="true"/>
                                                                                        </td>
                                                                                        <td align="left" class="lc" style="width:25%" valign="top">
                                                                                            <asp:Label runat="server" ID="lblAssignTo">Assigned To</asp:Label>
                                                                                            <span class="mf">*</span>
                                                                                        </td>
                                                                                        <td align="Center" class="lc" valign="top">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" class="ic" style="width:25%" valign="top">
                                                                                            <asp:TextBox runat="server" ID="txtAssignTo" Enabled="false" Width="70%"></asp:TextBox>&nbsp;
                                                                                            <asp:Button ID="btnAssignTO" Text="V" runat="server" CssClass="btn" />
                                                                                            <asp:RequiredFieldValidator ID="rfvAssignTo" ControlToValidate="txtAssignTo" runat="server"
                                                                                                InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Assigned To."
                                                                                                Display="none" Text="*"></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6" style="display:none;">
                                                                                            <asp:TextBox runat="server" ID="txtAssignToID"></asp:TextBox>&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6">
                                                                                            &nbsp;</td>
                                                                                    </tr>
                                                                                    
                                                                                    <tr>
                                                                                        <td class="ic" align="center" colspan="6">
                                                                                            <asp:Button runat="server" ID="btnSaveView" SkinID="btnGen" Text="Save & View" ValidationGroup="vsErrorGroup"
                                                                                                OnClick="btnSaveView_Click" />
                                                                                            <asp:Button runat="server" ID="btnCancel" Text="Cancel" SkinID="btnGen" OnClick="btnCancel_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" class="lc" colspan="6">
                                                                                             <asp:UpdateProgress runat="server">
                                                                                                <ProgressTemplate>
                                                                                                   <span class="mf"> Mail sending process is going on, please wait...</span>
                                                                                                </ProgressTemplate>
                                                                                            </asp:UpdateProgress>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <table cellpadding="4" cellspacing="0" border="0" style="width:100%;">
                                                                    <tr>
                                                                        <td>
                                                                            <div>
                                                                                <table cellpadding="2" cellspacing="2" style="width:100%;">
                                                                                    <tr>
                                                                                        <td align="left" colspan="6" class="ghc">
                                                                                            Diary Information</td>
                                                                                    </tr>
                                                                                    
                                                                                    <tr>
                                                                                        <td style="width:25%;" align="left" class="lc">
                                                                                            <asp:Label runat="server" ID="lblDONEntry"> Date of Note Entry</asp:Label>
                                                                                        </td>
                                                                                        <td  align="Center" class="lc">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="width:25%;" align="left" class="ic">
                                                                                            <asp:Label runat="server" ID="lblDONoteEntry"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width:25%;" align="left" class="lc">
                                                                                            <asp:Label runat="server" ID="lblVDiaryDate"> Diary Date</asp:Label>
                                                                                        </td>
                                                                                        <td  align="Center" class="lc">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="width:25%;" align="left" class="ic">
                                                                                            <asp:Label runat="server" ID="lblDiaryDate"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" class="lc" style="width:25%;">
                                                                                            <asp:Label runat="server" ID="lblVNote">Note</asp:Label>
                                                                                        </td>
                                                                                        <td align="Center" class="lc">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" class="ic" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblNote"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" class="lc" style="width:25%;">
                                                                                            <asp:Label runat="server" ID="lblVClear"> Clear?</asp:Label>
                                                                                        </td>
                                                                                        <td align="Center" class="lc">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" class="ic" style="width:25%;">
                                                                                            <asp:Label runat="server" ID="lblClear"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" class="lc" style="width:25%;">
                                                                                            <asp:Label runat="server" ID="lblVAssignTo">Assigned To</asp:Label> 
                                                                                        </td>
                                                                                        <td align="Center" class="lc">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" class="ic" style="width:25%;">
                                                                                            <asp:Label runat="server" ID="lblAssignTo"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6">
                                                                                            &nbsp;</td>
                                                                                    </tr>
                                                                                    
                                                                                    <tr>
                                                                                        <td class="ic" align="center" colspan="6">
                                                                                            <asp:Button runat="server" ID="btnSaveView" SkinID="btnGen" Text="Save & View" Enabled="false"
                                                                                                OnClick="btnSaveView_Click" />
                                                                                            <asp:Button runat="server" ID="btnCancel" Text="Cancel" SkinID="btnGen" OnClick="btnCancel_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:FormView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                    </asp:MultiView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div id="divbtn" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td align="center" class="ic">
                            <asp:Label runat="server" ID="lbl" Text="df" Visible="false"></asp:Label>
                            <asp:Button runat="server" ID="btnNextStep" EnableTheming="false" SkinID="btnGen"
                                Text="Next Step" OnClick="btnNextStep_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </contenttemplate>       
    </asp:UpdatePanel>
    <div id="divView" runat="server" style="display: none;">
        <table cellpadding="4" cellspacing="2" border="0" style="width: 100%;">
            <tr>
                <td align="left" colspan="6" class="ghc">
                    Claim Details</td>
            </tr>
            <tr>
                <td width="20%" align="left" class="lc">
                    <asp:Label runat="server" ID="lblDClaimNo">Claim Number</asp:Label>
                </td>
                <td width="5%" align="Center" class="lc">
                    :
                </td>
                <td width="25%" align="left" class="ic">
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
                    <asp:Label runat="server" ID="lblVLastName"></asp:Label>&nbsp;
                    <asp:Label runat="server" ID="lblVMiddleMName"></asp:Label>&nbsp;
                     <asp:Label runat="server" ID="lblVFirstName"></asp:Label>
                </td>
                <td width="20%" align="left" class="lc">
                    <asp:Label runat="server" ID="lblDEmployee">Employee</asp:Label> 
                </td>
                <td width="5%" align="Center" class="lc">
                    :
                </td>
                <td width="25%" align="left" class="ic">
                    <asp:Label runat="server" ID="lblVEmployee"></asp:Label>
                </td>
                
                
               <%-- <td align="left" class="lc">
                    <asp:Label runat="server" ID="lblDFirstName"> First Name</asp:Label>
                </td>
                <td align="Center" class="lc">
                    :
                </td>
                <td align="left" class="ic">
                    <asp:Label runat="server" ID="lblVFirstName"></asp:Label>
                </td>--%>
            </tr>
            <%--<tr>
                <td align="left" class="lc">
                    <asp:Label runat="server" ID="lblDMiddleName">Middle Name</asp:Label>
                </td>
                <td align="Center" class="lc">
                    :
                </td>
                <td align="left" class="ic">
                    <asp:Label runat="server" ID="lblVMiddleMName"></asp:Label>
                </td>
                
            </tr>--%>
            <tr>
                <td class="lc">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:GridView runat="server" ID="gvViewAll" AutoGenerateColumns="false" Width="100%" OnRowDataBound="gvViewAll_RowDataBound" >
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table cellpadding="4" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="left" colspan="6" class="ghc">
                                                Diary Information</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="lblDiaryID" Visible="false" Text='<%#Eval("PK_Diary_ID") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%;" align="left" class="lc">
                                                <asp:Label runat="server" ID="lblVLDONoteEntry">Date of Note Entry</asp:Label>                                                
                                            </td>
                                            <td width="5%" align="Center" class="lc">
                                                :
                                            </td>
                                            <td width="25%" align="left" class="ic">
                                                <asp:Label runat="server" ID="lblVDoActivity" Text='<%# DataBinder.Eval(Container.DataItem,"DateOfNoteEntry","{0:MM/dd/yyyy}") %>'></asp:Label>
                                            </td>
                                            <td width="20%" align="left" class="lc">
                                                <asp:Label runat="server" ID="lblVLDiaryDate">Diary Date</asp:Label>
                                            </td>
                                            <td width="5%" align="Center" class="lc">
                                                :
                                            </td>
                                            <td width="25%" align="left" class="ic">
                                                <asp:Label runat="server" ID="lblVDate" Text='<%# DataBinder.Eval(Container.DataItem,"Diary_Date","{0:MM/dd/yyyy}") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="lc">
                                                <asp:Label runat="server" ID="lblVLNote">Note</asp:Label>                                                
                                            </td>
                                            <td align="Center" class="lc">
                                                :
                                            </td>
                                            <td align="left" class="ic">
                                                <asp:Label runat="server" ID="lblVAuthor" Text='<%#Eval("Note") %>'></asp:Label>
                                            </td>
                                            <td align="left" class="lc">
                                                <asp:Label runat="server" ID="lblVLClear">Clear</asp:Label>                                                
                                            </td>
                                            <td align="Center" class="lc">
                                                :
                                            </td>
                                            <td align="left" class="ic">                                               
                                                <asp:Label runat="server" ID="lblVNoteType" Text='<%#Eval("Clear") %>'></asp:Label>                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="lc">
                                                <asp:Label runat="server" ID="lblVLAssignTo"> Assigned To </asp:Label>
                                               
                                            </td>
                                            <td align="Center" class="lc">
                                                :
                                            </td>
                                            <td align="left" class="ic" colspan="4">
                                                <asp:Label runat="server" ID="lblVUpdateBy" Text='<%#Eval("Assigned_To") %>'></asp:Label>
                                            </td>
                                        </tr>                                      
                                        <tr>
                                            <td colspan="3">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings Visible="false" />
                        <EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
                        <EmptyDataTemplate>
                            Currently there is no Diary for the following claim. 
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>            
            <tr>
                <td colspan="6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="6">
                    <asp:Button runat="server" ID="btnViewNext" OnClick="btnViewNext_Click" Text="Next Step" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
