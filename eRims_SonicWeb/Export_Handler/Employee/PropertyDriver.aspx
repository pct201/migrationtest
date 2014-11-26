<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="PropertyDriver.aspx.cs"
    Inherits="Employee_PropertyDriver" Title="PropertyDriver" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>

    <link href="../App_Themes/Default/stylecal.css" type="text/css" rel="Stylesheet" />

    <script type="text/javascript">
    
     
    
     function MinMax(name)
        {
            
            if(name == "attachment")
            {
           
                //alert(document.getElementById("ctl00_ContentPlaceHolder1_fvVendorDetails_txtDescription").style.height);
                if(document.getElementById("ctl00_ContentPlaceHolder1_fvPropertyDriver_txtDescription").style.height == "")
                {
                
                    document.getElementById("ctl00_ContentPlaceHolder1_fvPropertyDriver_ibtnAttach").src = "../Images/minus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvPropertyDriver_txtDescription").style.height = "100px";
                    document.getElementById("pnlAttach").style.display = "block";
                }
                else if(document.getElementById("ctl00_ContentPlaceHolder1_fvPropertyDriver_txtDescription").style.height == "100px")
                {
                    
                    document.getElementById("ctl00_ContentPlaceHolder1_fvPropertyDriver_ibtnAttach").src = "../Images/plus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvPropertyDriver_txtDescription").style.height="";
                    document.getElementById("pnlAttach").style.display = "none";
                }
               
            }
            
            if(name == "Notes")
            {
           
                //alert(document.getElementById("ctl00_ContentPlaceHolder1_fvVendorDetails_txtDescription").style.height);
                if(document.getElementById("ctl00_ContentPlaceHolder1_fvPropertyDriver_txtNotes").style.height == "")
                {
                
                    document.getElementById("ctl00_ContentPlaceHolder1_fvPropertyDriver_imgNotes").src = "../Images/minus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvPropertyDriver_txtNotes").style.height = "100px";
                    document.getElementById("DivNotes").style.display = "block";
                }
                else if(document.getElementById("ctl00_ContentPlaceHolder1_fvPropertyDriver_txtNotes").style.height == "100px")
                {
                    
                    document.getElementById("ctl00_ContentPlaceHolder1_fvPropertyDriver_imgNotes").src = "../Images/plus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvPropertyDriver_txtNotes").style.height="";
                    document.getElementById("DivNotes").style.display = "none";
                }
               
            }
            
            
            
            
            
            

    
                return false 
    }
    
    
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

    
        function ValAttach()
        {
           
            document.getElementById("ctl00_ContentPlaceHolder1_fvPropertyDriver_rfvAttachType").enabled =true;
            document.getElementById("ctl00_ContentPlaceHolder1_fvPropertyDriver_rfvUpload").enabled =true;
            if(document.getElementById("ctl00_ContentPlaceHolder1_fvPropertyDriver_txtCellTeleNo").value=="___-___-____")
                document.getElementById("ctl00_ContentPlaceHolder1_fvPropertyDriver_txtCellTeleNo").value="";
            return true;
        }
        function ValSave()
        {
       
            document.getElementById("ctl00_ContentPlaceHolder1_fvPropertyDriver_rfvAttachType").enabled =false;
            document.getElementById("ctl00_ContentPlaceHolder1_fvPropertyDriver_rfvUpload").enabled =false;
            if(document.getElementById("ctl00_ContentPlaceHolder1_fvPropertyDriver_txtCellTeleNo").value=="___-___-____")
                document.getElementById("ctl00_ContentPlaceHolder1_fvPropertyDriverfvPropertyDriver_txtCellTeleNo").value="";
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
       
            //oWnd=window.open("Mail.aspx?AttName="+ strURL,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=0,toolbar=0,width=500,height=280");
            oWnd=window.open(strURL,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=0,toolbar=0,width=500,height=280");
            oWnd.moveTo(260,180);
            return false;
            
        }
        function openSupWindow()
        {
       
            oWnd=window.open("../WorkerCompensation/Employee_Search_Popup.aspx?Page=Supervisor","Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            oWnd.moveTo(260,180);
            return false;
            
        }
        function openCCWindow()
        {
      
            oWnd=window.open("../WorkerCompensation/CostCenter_Popup.aspx?Page=Employee","Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            oWnd.moveTo(260,180);
            return false;
            
        }
        function conditionalPostback(sender, args) 
        { 
         
            var eventTarget = args.EventTarget;
            
           
                return true;
            
        } 
        
    </script>

    <asp:ScriptManager ID="smPropertyDriver" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <%-- <jeffz:AjaxFileUploadHelper runat="server" ID="AjaxFileUploadHelper1" SupportAjaxUpload="true" />

    <asp:UpdatePanel ID="pnlVendorDetail" runat="server" >
    
        
        <ContentTemplate>--%>
    <%--<div style="width: 100%;">--%>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            EnableClientScript="true" ValidationGroup="vsErrorGroup" CssClass="errormessage">
        </asp:ValidationSummary>
        <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="true"
            ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
    </div>
    <table width="100%">
        <tr>
            <td>
                <div id="dvSearch" runat="server">
                    <table width="100%">
                        <tr>
                            <td style="width: 50%;">
                                &nbsp;
                            </td>
                            <td style="width: 50%; display:none;" align="right">
                                <table width="80%">
                                    <tr>
                                        <td class="lc">
                                            Search
                                        </td>
                                        <td class="ic">
                                            <asp:DropDownList ID="ddlSearch" runat="server" SkinID="dropGen">
                                                <asp:ListItem Value="Last_Name">Last Name</asp:ListItem>
                                                <asp:ListItem Value="First_Name">First Name</asp:ListItem>
                                                <asp:ListItem Value="SSN">SSN</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td class="ic">
                                            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox></td>
                                        <td class="ic">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%;" align="left" class="lc">
                                <asp:Label ID="lblPropertyDriversTotal" runat="server"></asp:Label>
                            </td>
                            <td style="width: 80%;" align="right" class="lc">
                                <table width="100%">
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
                                            <asp:TextBox ID="txtPageNo" MaxLength="3" runat="server" Width="20px" onkeypress="return numberOnly(event);"></asp:TextBox>
                                        </td>
                                        <td class="ic">
                                            <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:MultiView ID="mvPropertyDriver" runat="server">
                    <asp:View ID="vwPropertyDriverList" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <table width="100%"  style="text-align: right;">
                                        <tr>
                                            <td style="height: 26px">
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Click here to delete Property Driver Details"
                                                    OnClick="btnDelete_Click" />
                                                <asp:Button ID="btnAddNew" runat="server" Text="Add New" ToolTip="Add New Property Driver Details"
                                                    OnClick="btnAddNew_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvPropertyDriver" BorderColor="silver" BorderStyle="Solid" BorderWidth="1px" runat="server" AutoGenerateColumns="False" DataKeyNames="PK_Property_Drivers"
                                                    Width="100%" AllowPaging="True" AllowSorting="True" OnRowCommand="gvPropertyDriver_RowCommand"
                                                    OnSorting="gvPropertyDriver_Sorting">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <input name="chkItem" type="checkbox" value='<%# Eval("PK_Property_Drivers")%>' onclick="javascript:UnCheckHeader('gvPropertyDriver')" />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="10px" />
                                                            <HeaderTemplate>
                                                                <input id="chkHeader" name="chkHeader" type="checkbox" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                                            </HeaderTemplate>
                                                            <HeaderStyle Width="10px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Last_Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"  HeaderText="Last Name" SortExpression="Last_Name">
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="First_Name"  HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"  HeaderText="First Name" SortExpression="First_Name">
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Social_Security_Number" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"  HeaderText="Social Security Number"
                                                            SortExpression="Social_Security_Number"></asp:BoundField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_Property_Drivers")%>'
                                                                    runat="server" Text="Edit" ToolTip="Edit the Property Driver Details" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("PK_Property_Drivers")%>'
                                                                    ToolTip="View the Property Driver Details" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataRowStyle ForeColor="#7F7F7F" HorizontalAlign="Center" />
                                                    <EmptyDataTemplate>
                                                        Currently There Is No Property Driver Details.
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
                    <asp:View ID="vwPropertyDriver" runat="server">
                        <table width="100%">
                            <%--<tr>
                                    <td class="lc">
                                        Vendor
                                    </td>
                                </tr>--%>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:FormView ID="fvPropertyDriver" runat="server" Width="100%" OnDataBound="fvPropertyDriver_DataBound">
                                        <ItemTemplate>
                                            <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                                                text-align: left;">
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Driver Information
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Status
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("DLStatus") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Entity
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblEntity" runat="server" Text='<%#Eval("EntityDesc") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Last Name
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblLastName" runat="server" Text='<%#Eval("Last_Name") %>'></asp:Label></td>
                                                                      <asp:Label ID="lblPkEmployeeId" runat="server" Text='<%#Eval("PK_Property_Drivers")%>'
                                                                        Height="0px" Width="0px" Visible="false"></asp:Label>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Middle Name
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblMiddleName" runat="server" Text='<%#Eval("Middle_Name") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Management?
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblManagement" runat="server" Text='<%#Eval("Management") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Interstate?
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblInterstate" runat="server" Text='<%#Eval("Interstate") %>'></asp:Label></td>
                                                            </tr>
                                                           <%-- <tr>
                                                                <td class="lc">
                                                                    Marital Status
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblMaritalStatus" runat="server" Text='<%#Eval("MaritalStatus") %>'></asp:Label></td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date of Last MVR
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblDateofLastMVR" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Last_MVR","{0:MM/dd/yyyy}") %>' ></asp:Label></td>
                                                            </tr>
                                                           <%-- <tr>
                                                                <td class="lc">
                                                                    Gross Vehicle Weight
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblGrossVehWeight" runat="server" Text='<%#Eval("GVW") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Interstate?<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:RadioButtonList ID="rdlInterstate" runat="server">
                                                                        <asp:ListItem Text="Yes" Value="Y" Selected="true"> </asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"> </asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>--%>
                                                        </table>
                                                    </td>
                                                    <td>
                                                    <table width="100%" style="text-align: left;">
                                                            <tr>
                                                             <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    As of  
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Status_As_Of","{0:MM/dd/yyyy}") %>' ></asp:Label></td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    First Name
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("First_Name") %>'></asp:Label></td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                   Work Telephone Number 

                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("Work_Telephone") %>'></asp:Label></td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                  Gross Vehicle Weight

                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("GVW") %>'></asp:Label></td>
                                                            </tr>
                                                            
                                                            
                                                            </tr>
                                                            </table>
                                                    
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Personal Data
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Address 1
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblAddress1" runat="server" Text='<%#Eval("Address_1") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Address 2
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblAddress2" runat="server" Text='<%#Eval("Address_2") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    City
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblCity" runat="server" Text='<%#Eval("City") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    State
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblState" runat="server" Text='<%#Eval("StateName") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Zip Code
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblZipCode" runat="server" Text='<%#Eval("Zip_Code") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Social Security Number
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblSSN" runat="server" Text='<%#Eval("Social_Security_Number") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date of Birth
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblDOB" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Date_Of_Birth","{0:MM/dd/yyyy}") %>'   ></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Home Telephone Number
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblHomeTeleNo" runat="server" Text='<%#Eval("Home_Telephone") %>'> </asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Cell Telephone Number
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblCellTeleNo" runat="server" Text='<%#Eval("Cell_Phone") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Pager Telephone Number
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblPagerTeleNo" runat="server" Text='<%#Eval("Pager") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    E-Mail Address
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Gender
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblGender" runat="server" Text='<%#Eval("Gender") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Licensing
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Driver’s License State
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblDrLicState" runat="server" Text='<%#Eval("DriverLicence") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Driver’s License Type
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblDrLicType" runat="server" Text='<%#Eval("License_Type") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Driver’s License Restrictions
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblDrLicRestrictions" runat="server" Text='<%#Eval("Restrictions") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Driver’s License Issued
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblDrLicIssue" runat="server"  Text='<%#DataBinder.Eval(Container.DataItem,"DL_Begin_Date","{0:MM/dd/yyyy}") %>' ></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Driver’s License Number
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblDrLicNo" runat="server" Text='<%#Eval("Drivers_License_Number") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Driver’s License Class
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblDrLicClass" runat="server" Text='<%#Eval("Drivers_License_Class") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Driver’s License Endorsements
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblDrLicEndorsement" runat="server" Text='<%#Eval("Endorsements") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Driver’s License Expires
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblDrLicExpire" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"DL_End_Date","{0:MM/dd/yyyy}") %>' ></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Supervisor Information
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Supervisor’s Last Name
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblSupervisorLname" runat="server" Text='<%#Eval("Supervisor_Last") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Supervisor’s Title
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblSupervisorTitle" runat="server" Text='<%#Eval("Supervisor_Title") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Supervisor’s First Name
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblSupervisorFname" runat="server" Text='<%#Eval("Supervisor_First") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Supervisor’s Telephone Number
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblSupervisorTeleNo" runat="server" Text='<%#Eval("Supervisor_Phone") %>'></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="lc">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Notes
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Notes
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblNotes" runat="server" Text='<%#Eval("Notes") %>'></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 50%">
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                            OnClick="btnSave_Click" Enabled="false" /></td>
                                                    <td align="left" style="width: 50%">
                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <InsertItemTemplate>
                                            <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                                                text-align: left;">
                                                <tr>
                                                    <td colspan="2" class="lc">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Driver Information
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Status<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:DropDownList ID="ddlStatus" SkinID="property" Width="153px"  runat="server">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvStatus" ControlToValidate="ddlStatus" runat="server"
                                                                        InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Status."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                    <asp:Label ID="lblPkEmployeeId" runat="server" Text='<%#Eval("PK_Property_Drivers")%>'
                                                                        Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Entity<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlEntity" SkinID="property" Width="153px"  runat="server">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvEntity" ControlToValidate="ddlEntity" runat="server"
                                                                        InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Entity."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Last Name<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtLastName" runat="server" MaxLength="50"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvLastName" ControlToValidate="txtLastName" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Last Name."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Middle Name
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtMiddleName" runat="server" MaxLength="30"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Management?<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:RadioButtonList ID="rdlManagement" runat="server">
                                                                        <asp:ListItem Text="Yes" Value="Y" Selected="true"> </asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"> </asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            
                                                           <tr>
                                                                <td class="lc">
                                                                    Date of Last MVR<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtLastMVR" runat="server" SkinID="txtDate"></asp:TextBox>
                                                                    <img runat="server" id="img10" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPropertyDriver_txtLastMVR', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absMiddle" />
                                                                    <cc1:MaskedEditExtender ID="mskLastMVR" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtLastMVR" CultureName="en-US"
                                                                        AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revLastMVR" runat="server" ControlToValidate="txtLastMVR"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date Of Last MVR)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        
                                                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtLastMVR"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Date of Last MVR."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                        
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%">
                                                          <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    As of<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtAsof" runat="server" SkinID="txtDate"></asp:TextBox>
                                                                    <img runat="server" id="img11" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPropertyDriver_txtAsof', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absMiddle" />
                                                                    <cc1:MaskedEditExtender ID="mskAsof" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtAsof" CultureName="en-US"
                                                                        AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revAsof" runat="server" ControlToValidate="txtAsof"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(As of)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                    <asp:RequiredFieldValidator ID="rfvAsof" ControlToValidate="txtAsof" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter As of Date."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                           <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Work Telephone Number <span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtWorkTeleNo" runat="server" MaxLength="12" onkeypress="return noPhoneFax(event);"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskWorkTeleNo" runat="server" TargetControlID="txtWorkTeleNo"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RequiredFieldValidator ID="rfvWorkTelepNo" ControlToValidate="txtWorkTeleNo"
                                                                        runat="server" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Work Telephone Number."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="revWorkTelepNo" ControlToValidate="txtWorkTeleNo"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Work Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    First Name<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtFirstName" runat="server" MaxLength="50">
                                                                    </asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvFirstName" ControlToValidate="txtFirstName" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter First Name."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Gross Vehicle Weight<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:RadioButtonList ID="rblGrossVehWeight" runat="server">
                                                                        <asp:ListItem Text="Less than 26,000 pounds" Value="L" Selected="true"> </asp:ListItem>
                                                                        <asp:ListItem Text="26,000 pounds or greater" Value="P"> </asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="rblGrossVehWeight"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Gross Vehicle Weight."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                    
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Interstate?<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:RadioButtonList ID="rdlInterstate" runat="server">
                                                                        <asp:ListItem Text="Yes" Value="Y" Selected="true"> </asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"> </asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                    
                                                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="rblGrossVehWeight"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Interstate."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                    
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="lc">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Personal Data
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Address 1
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtAddress1" runat="server" MaxLength="30"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Address 2
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtAddress2" runat="server" MaxLength="30"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    City
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtCity" runat="server" MaxLength="30"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    State<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlState" SkinID="propertyDr" Width="153px"  runat="server">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvState" ControlToValidate="ddlState" runat="server"
                                                                        InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select State."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Zip Code (XXXXX-XXXX)
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtZipCode" runat="server" MaxLength="30"></asp:TextBox>
                                                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator12" ControlToValidate="txtZipCode"
                                runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Zip Code in XXXXX-XXXX or XXXXX format."
                                Display="none" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                        
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Social Security Number<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtSSN" runat="server" MaxLength="30"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvSSN" ControlToValidate="txtSSN" runat="server"
                                                                        InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Social Security Number."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                          <cc1:MaskedEditExtender ID="mskSSN" runat="server" TargetControlID="txtSSN" Mask="999-99-9999"
                                                                        MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                   <%-- <asp:RequiredFieldValidator ID="rfvSSN" ControlToValidate="txtSSN" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Social Security Number."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                    <asp:RegularExpressionValidator ID="revSSN" ControlToValidate="txtSSN" runat="server"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter SSN in xxx-xx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{2}-\d{4}$"></asp:RegularExpressionValidator>
                                                           
                                                                </td>
                                                            </tr>
                                                            <%--<tr>
                                                                <td class="lc">
                                                                    Date of Birth<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtDOB" runat="server" SkinID="txtDate"></asp:TextBox>
                                                                    <img runat="server" id="img4" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPropertyDriver_txtDOB', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absMiddle" />
                                                                    <cc1:MaskedEditExtender ID="mskDOB" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtDOB" CultureName="en-US"
                                                                        AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revDOB" runat="server" ControlToValidate="txtDOB"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date Of Birth)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                    <asp:RequiredFieldValidator ID="rfvDateOfBirth" ControlToValidate="txtDOB" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Date of Birth."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>--%>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td class="lc">
                                                                    Home Telephone Number 
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtHomeTeleNo" runat="server" MaxLength="12" onkeypress="return noPhoneFax(event);"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskHomeTeleNo" runat="server" TargetControlID="txtHomeTeleNo"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revHomeTeleNo" ControlToValidate="txtHomeTeleNo"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Home Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Cell Telephone Number 
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtCellTeleNo" runat="server" MaxLength="12" onkeypress="return noPhoneFax(event);"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskCellTeleNo" runat="server" TargetControlID="txtCellTeleNo"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revCellTeleNo" ControlToValidate="txtCellTeleNo"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Cell Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Pager Telephone Number 
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtPagerTeleNo" runat="server" MaxLength="12" onkeypress="return noPhoneFax(event);"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskPagerTeleNo" runat="server" TargetControlID="txtPagerTeleNo"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revPagerTeleNo" ControlToValidate="txtPagerTeleNo"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Pager Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    E-Mail Address
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="50">
                                                                    </asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                                                                        ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="Email Address Is Invalid"
                                                                        SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Gender<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlGender" SkinID="propertyGwender" Width="153px"  runat="server">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvGender" ControlToValidate="ddlGender" runat="server"
                                                                        InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Gender."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date of Birth<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtDOB" runat="server" SkinID="txtDate"></asp:TextBox>
                                                                    <img runat="server" id="img4" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPropertyDriver_txtDOB', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absMiddle" />
                                                                    <cc1:MaskedEditExtender ID="mskDOB" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtDOB" CultureName="en-US"
                                                                        AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revDOB" runat="server" ControlToValidate="txtDOB"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date Of Birth)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                    <asp:RequiredFieldValidator ID="rfvDateOfBirth" ControlToValidate="txtDOB" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Date of Birth."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="lc">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Licensing
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Driver’s License State<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlDrLicState" SkinID="propertyDr" Width="153px"  runat="server">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvDrLicState" ControlToValidate="ddlDrLicState"
                                                                        runat="server" InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Driver License State."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Driver’s License Type
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlDrLicType" SkinID="propertyDr" Width="153px"  runat="server">
                                                                    </asp:DropDownList>
                                                                     <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="ddlDrLicType"
                                                                        runat="server" InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Driver License Type."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Driver’s License Restrictions
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtDrLicRestrictions" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Driver’s License Issued<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtDrLicIssueDate" SkinID="txtDate" runat="server"></asp:TextBox>
                                                                    <img runat="server" id="img6" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPropertyDriver_txtDrLicIssueDate', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absMiddle" />
                                                                    <cc1:MaskedEditExtender ID="mskDrLicIssueDate" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDrLicIssueDate"
                                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revDrLicIssueDate" runat="server" ControlToValidate="txtDrLicIssueDate"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date of License Issue)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                    <asp:RequiredFieldValidator ID="rfvHireDate" ControlToValidate="txtDrLicIssueDate"
                                                                        runat="server" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Driver's License Issue Date."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Driver’s License Number<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtDrLicNo" runat="server" MaxLength="20"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvOccuDesc" ControlToValidate="txtDrLicNo" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Driver's License Number."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Driver’s License Class
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtDrLicClass" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Driver’s License Endorsements
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtDrLicEndorsement" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Driver’s License Expires
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtDrLicExpireDate" SkinID="txtDate" runat="server"></asp:TextBox>
                                                                    <img runat="server" id="img1" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPropertyDriver_txtDrLicExpireDate', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absMiddle" />
                                                                    <cc1:MaskedEditExtender ID="mskDrLicExpireDate" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDrLicExpireDate"
                                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revDrLicExpireDate" runat="server" ControlToValidate="txtDrLicExpireDate"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date of License Expire)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="lc">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Supervisor Information
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Supervisor’s Last Name
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtSupervisorLname" runat="server" MaxLength="20"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Supervisor’s Title
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtSupervisorTitle" runat="server" MaxLength="20"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Supervisor’s First Name
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtSupervisorFname" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Supervisor’s Telephone Number &nbsp;
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtSupervisorTeleNo" runat="server" MaxLength="12" onkeypress="return noPhoneFax(event);"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskSupervisorTeleNo" runat="server" TargetControlID="txtSupervisorTeleNo"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revSupervisorTeleNo" ControlToValidate="txtSupervisorTeleNo"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Supervisor's Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="lc">
                                                        <table cellspacing="1" width="100%" style=" color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Notes
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 25%;" valign="top" class="lc">
                                                                    Notes
                                                                </td>
                                                                <td align="center" valign="top" class="lc">
                                                                    :
                                                                </td>
                                                                <%--<td style="width: 76%;" class="ic">--%>
                                                                                                                                        
                                                                     <td class="ic" align="left" style="width: 75%;" >
                                                                    <asp:ImageButton ID="imgNotes" ImageUrl="~/Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMax('Notes');"  TabIndex="40"/>
                                                                    <div id="DivNotes" style="display:block;" >
                                                                        <asp:TextBox ID="txtNotes" runat="server" Height="100px" Width="640px" TextMode="MultiLine">
                                                                        </asp:TextBox>
                                                                    </div>
                                                              <%--  </td>--%>
                                                                    
                                                                    
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Attachment
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td  style="width: 50%; display:none" align="left">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="lc" style="width: 50%;">
                                                                    Attachment Type
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 50%;">
                                                                    <asp:DropDownList ID="ddlAttachType" runat="server">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvAttachType" ControlToValidate="ddlAttachType"
                                                                        runat="server" InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select the Attachment Type."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="width: 50%;">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table width="100%">
                                                             <tr>
                                                                <td class="lc" style="width: 25%" valign="top">
                                                                    Attachment Description</td>
                                                                <td align="Center" valign="top" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" align="left" style="width: 75%;" >
                                                                    <asp:ImageButton ID="ibtnAttach" ImageUrl="~/Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMax('attachment');"  TabIndex="40"/>
                                                                    <div id="pnlAttach" style="display:block;" >
                                                                        <asp:TextBox ID="txtDescription"  runat="server" Height="100px" Width="640px" TextMode="MultiLine">
                                                                        </asp:TextBox>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="lc" style="width: 25%">
                                                                    Select File to Attach
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 75%">
                                                                    <asp:FileUpload ID="uplCommon" runat="server" Width="300px" />
                                                                    <asp:RequiredFieldValidator ID="rfvUpload" runat="server" ControlToValidate="uplCommon"
                                                                        InitialValue="" Display="None" ErrorMessage="Please Select File to Upload." ValidationGroup="vsErrorGroup">
                                                                        
                                                                    </asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" ValidationGroup="vsErrorGroup"
                                                            SkinID="btnGen" OnClick="btnAddAttachment_Click" OnClientClick="javascript:ValAttach();" />
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                            OnClick="btnSave_Click" OnClientClick="javascript:ValSave();" />
                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </InsertItemTemplate>
                                        <EditItemTemplate>
                                            <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                                                text-align: left;">
                                                <tr>
                                                    <td colspan="2" class="lc">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Driver Information
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Status<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:DropDownList ID="ddlStatus" SkinID="property" Width="153px"  runat="server">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlStatus"
                                                                        runat="server" InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Marital Status."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Entity<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlEntity" SkinID="property" Width="153px"  runat="server">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlEntity"
                                                                        runat="server" InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Marital Status."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Last Name<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtLastName" runat="server" Text='<%#Eval("Last_Name") %>' MaxLength="50"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvAddress1" ControlToValidate="txtLastName" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Address Line 1."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                        
                                                                         <asp:Label ID="lblPkEmployeeId" runat="server" Text='<%#Eval("PK_Property_Drivers")%>'
                                                                        Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Middle Name<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtMiddleName" runat="server" Text='<%#Eval("Middle_Name") %>' MaxLength="30"></asp:TextBox>
                                                                   <%-- <asp:RequiredFieldValidator ID="rfvCity" ControlToValidate="txtMiddleName" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter City."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Management?<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:RadioButtonList ID="rdlManagement" runat="server">
                                                                        <asp:ListItem Text="Yes" Value="Y" Selected="true"> </asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"> </asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                     <asp:RequiredFieldValidator ID="Req4" ControlToValidate="rdlManagement"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Management."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <%--<tr>
                                                                <td class="lc">
                                                                    Interstate?<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:RadioButtonList ID="rdlInterstate" runat="server">
                                                                        <asp:ListItem Text="Yes" Value="Y" Selected="true"> </asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"> </asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>--%>
                                                           <tr>
                                                                <td class="lc">
                                                                    Date of Last MVR
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtLastMVR" runat="server"  Text='<%#DataBinder.Eval(Container.DataItem,"Last_MVR","{0:MM/dd/yyyy}") %>'    SkinID="txtDate"></asp:TextBox>
                                                                    <img runat="server" id="img10" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPropertyDriver_txtLastMVR', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absMiddle" />
                                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender10" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtLastMVR"
                                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtLastMVR"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date Of Last MVR)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                        
                                                                         <asp:RequiredFieldValidator ID="Remvr" ControlToValidate="txtLastMVR"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Date of Last MVR."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%">
                                                           <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    As of<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtAsof" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Status_As_Of","{0:MM/dd/yyyy}") %>'      SkinID="txtDate"></asp:TextBox>
                                                                    <img runat="server" id="img11" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPropertyDriver_txtAsof', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absMiddle" />
                                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender11" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtAsof"
                                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtAsof"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(As of)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtAsof"
                                                                        runat="server" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter As of Date."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Work Telephone Number<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtWorkTeleNo" runat="server" MaxLength="12" Text='<%#Eval("Work_Telephone") %>' onkeypress="return noPhoneFax(event);"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskWorkTeleNo" runat="server" TargetControlID="txtWorkTeleNo"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RequiredFieldValidator ID="rfvWorkTelepNo" ControlToValidate="txtWorkTeleNo"
                                                                        runat="server" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Work Telephone Number."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="revWorkTelepNo" ControlToValidate="txtWorkTeleNo"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Work Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                               </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    First Name
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtFirstName" Text='<%#Eval("First_Name") %>' runat="server" MaxLength="50">
                                                                    </asp:TextBox>
                                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtFirstName"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter First Name."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                           <tr>
                                                                <td class="lc">
                                                                    Gross Vehicle Weight<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:RadioButtonList ID="rblGrossVehWeight" runat="server">
                                                                        <asp:ListItem Text="Less than 26,000 pounds" Value="L" Selected="true"> </asp:ListItem>
                                                                        <asp:ListItem Text="26,000 pounds or greater" Value="P"> </asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="rblGrossVehWeight"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Gross Vehicle Weight."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Interstate?<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:RadioButtonList ID="rdlInterstate" runat="server">
                                                                        <asp:ListItem Text="Yes" Value="Y" Selected="true"> </asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"> </asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                    
                                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="rblGrossVehWeight"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Interstate."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                   
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="lc">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Personal Data
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Address 1
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtAddress1" runat="server" Text='<%#Eval("Address_1") %>' MaxLength="30"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Address 2
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtAddress2" runat="server" Text='<%#Eval("Address_2") %>' MaxLength="30"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    City
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtCity" runat="server" Text='<%#Eval("City") %>' MaxLength="30"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    State
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlState" SkinID="property" Width="153px"  runat="server">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddlState"
                                                                        runat="server" InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select State."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Zip Code (XXXXX-XXXX)
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtZipCode" runat="server" Text='<%#Eval("Zip_Code") %>' MaxLength="30"></asp:TextBox>
                                                                        <%--<asp:TextBox ID="TextBox1" runat="server" MaxLength="30"></asp:TextBox>--%>
                                                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator12" ControlToValidate="txtZipCode"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Zip Code in XXXXX-XXXX or XXXXX format."
                                                                        Display="none" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                                                                                                        </td>
                                                            </tr>
                                                          <tr>
                                                                <td class="lc">
                                                                    Social Security Number
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtSSN" runat="server" Text='<%#Eval("Social_Security_Number") %>' MaxLength="30"></asp:TextBox>
                                                                    
                                                                      <cc1:MaskedEditExtender ID="mskSSN" runat="server" TargetControlID="txtSSN" Mask="999-99-9999"
                                                                        MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                  
                                                                    <asp:RegularExpressionValidator ID="revSSN" ControlToValidate="txtSSN" runat="server"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter SSN in xxx-xx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{2}-\d{4}$"></asp:RegularExpressionValidator>
                                                                        
                                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtSSN"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Social Security Number."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                           
                                                                    
                                                                </td>
                                                            </tr>
                                                         <%--  <tr>
                                                                <td class="lc">
                                                                    Date of Birth
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtDOB" runat="server" SkinID="txtDate" Text='<%#DataBinder.Eval(Container.DataItem,"Date_Of_Birth","{0:MM/dd/yyyy}") %>'></asp:TextBox>
                                                                    <img runat="server" id="img4" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPropertyDriver_txtDOB', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absMiddle" />
                                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDOB"
                                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revDOB" runat="server" ControlToValidate="txtDOB"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date Of Birth)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                    <asp:RequiredFieldValidator ID="rfvDateOfBirth" ControlToValidate="txtDOB" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Date of Birth."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>--%>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" style="text-align: left;">
                                                          <tr>
                                                                <td class="lc">
                                                                    Home Telephone Number 
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtHomeTeleNo" runat="server" Text='<%#Eval("Home_Telephone") %>' MaxLength="12" onkeypress="return noPhoneFax(event);"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender13" runat="server" TargetControlID="txtHomeTeleNo"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtHomeTeleNo"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Home Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Cell Telephone Number 
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtCellTeleNo" runat="server" Text='<%#Eval("Cell_Phone") %>' MaxLength="12" onkeypress="return noPhoneFax(event);"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender14" runat="server" TargetControlID="txtCellTeleNo"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="txtCellTeleNo"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Cell Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Pager Telephone Number 
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtPagerTeleNo" runat="server" MaxLength="12" Text='<%#Eval("Pager") %>' onkeypress="return noPhoneFax(event);"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender15" runat="server" TargetControlID="txtPagerTeleNo"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate="txtPagerTeleNo"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Pager Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    E-Mail Address
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtEmail" runat="server" Text='<%#Eval("Email") %>' MaxLength="50">
                                                                    </asp:TextBox>
                                                                 <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtEmail"
                                                                        runat="server" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Email."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                    <%--<asp:RegularExpressionValidator ID="revMail" ControlToValidate="txtEmail" runat="server"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Valid Email Address."
                                                                        Display="none" ValidationExpression="^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$"></asp:RegularExpressionValidator>--%>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtEmail"
                                                                        ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="Email Address Is Invalid"
                                                                        SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Gender
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlGender" SkinID="propertyGwender" Width="153px"  runat="server">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ddlGender"
                                                                        runat="server" InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Gender."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            
                                                              <tr>
                                                                <td class="lc">
                                                                    Date of Birth
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtDOB" runat="server" SkinID="txtDate" Text='<%#DataBinder.Eval(Container.DataItem,"Date_Of_Birth","{0:MM/dd/yyyy}") %>'></asp:TextBox>
                                                                    <img runat="server" id="img4" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPropertyDriver_txtDOB', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absMiddle" />
                                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDOB"
                                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revDOB" runat="server" ControlToValidate="txtDOB"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date Of Birth)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                    <asp:RequiredFieldValidator ID="rfvDateOfBirth" ControlToValidate="txtDOB" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Date of Birth."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="lc">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Licensing
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Driver’s License State
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlDrLicState" SkinID="propertyDr" Width="153px"  runat="server">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddlDrLicState"
                                                                        runat="server" InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Driver License State."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Driver’s License Type
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlDrLicType" Width="153px" SkinID="propertyDr" runat="server">
                                                                    </asp:DropDownList>
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="ddlDrLicType"
                                                                        runat="server" InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Driver License Type."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Driver’s License Restrictions
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtDrLicRestrictions" Text='<%#Eval("Restrictions") %>' runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                          <tr>
                                                                <td class="lc">
                                                                    Date Driver’s License Issued<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtDrLicIssueDate" SkinID="txtDate"  Text='<%#DataBinder.Eval(Container.DataItem,"DL_Begin_Date","{0:MM/dd/yyyy}") %>'      runat="server"></asp:TextBox>
                                                                    <img runat="server" id="img6" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPropertyDriver_txtDrLicIssueDate', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absMiddle" />
                                                                    <cc1:MaskedEditExtender ID="mskHireDate" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtDrLicIssueDate" CultureName="en-US"
                                                                        AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtDrLicIssueDate"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date of License Issue)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                    <asp:RequiredFieldValidator ID="rfvHireDate" ControlToValidate="txtDrLicIssueDate"
                                                                        runat="server" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Driver's License Issue Date."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Driver’s License Number<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtDrLicNo" Text='<%#Eval("Drivers_License_Number") %>' runat="server" MaxLength="20"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvOccuDesc" ControlToValidate="txtDrLicNo" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Driver's License Number."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Driver’s License Class
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtDrLicClass" Text='<%#Eval("Drivers_License_Class") %>' runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Driver’s License Endorsements
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtDrLicEndorsement" Text='<%#Eval("Endorsements") %>' runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Driver’s License Expires
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtDrLicExpireDate" SkinID="txtDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"DL_End_Date","{0:MM/dd/yyyy}") %>'    ></asp:TextBox>
                                                                    <img runat="server" id="img1" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPropertyDriver_txtDrLicExpireDate', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absMiddle" />
                                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender16" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDrLicExpireDate"
                                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                                                        ControlToValidate="txtDrLicExpireDate" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date of License Expire)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtDrLicExpireDate"
                                                                        runat="server" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Driver's License Expire Date."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="lc">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Supevisor Information
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Supervisor’s Last Name
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtSupervisorLname" Text='<%#Eval("Supervisor_Last") %>' runat="server" MaxLength="20"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Supervisor’s Title
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtSupervisorTitle" Text='<%#Eval("Supervisor_Title") %>' runat="server" MaxLength="20"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Supervisor’s First Name
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtSupervisorFname" Text='<%#Eval("Supervisor_First") %>' runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Supervisor’s Telephone Number&nbsp;
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtSupervisorTeleNo" Text='<%#Eval("Supervisor_Phone") %>' runat="server" MaxLength="12" onkeypress="return noPhoneFax(event);"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender17" runat="server" TargetControlID="txtSupervisorTeleNo"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" ControlToValidate="txtSupervisorTeleNo"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Supervisor's Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="1" width="100%" style=" font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                            <tr>
                                                                <td style="width: 25%;" class="lc" valign="top">
                                                                    Notes
                                                                </td>
                                                                <td align="center" class="lc" valign="top">
                                                                    :
                                                                </td>
                                                                <%--<td style="width: 76%;" class="ic">--%>
                                                                    <%--<asp:TextBox ID="txtNotes" Text='<%#Eval("Notes") %>' runat="server"></asp:TextBox>--%>
                                                                    
                                                                    <td class="ic" align="left" style="width: 75%;" >
                                                                    <asp:ImageButton ID="imgNotes" ImageUrl="~/Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMax('Notes');"  TabIndex="40"/>
                                                                    <div id="DivNotes" style="display:block;" >
                                                                        <asp:TextBox ID="txtNotes" runat="server" Text='<%#Eval("Notes") %>'  Height="100px" Width="640px" TextMode="MultiLine">
                                                                        </asp:TextBox>
                                                                    </div>
                                                                <%--</td>--%>
                                                                    
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Attachment
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%; display:none;" align="left">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="lc" style="width: 50%;">
                                                                    Attachment Type
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 50%;">
                                                                    <asp:DropDownList ID="ddlAttachType" runat="server">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvAttachType" ControlToValidate="ddlAttachType"
                                                                        runat="server" InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select the Attachment Type."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="width: 50%;">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="lc" style="width: 25%" valign="top">
                                                                    Attachment Description</td>
                                                                <td align="center" valign="top" class="lc">
                                                                    :
                                                                </td>
                                                               <td class="ic" align="left" style="width: 76%;" >
                                                                    <asp:ImageButton ID="ibtnAttach" ImageUrl="~/Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMax('attachment');"  TabIndex="40"/>
                                                                    <div id="pnlAttach" style="display:block;" >
                                                                        <asp:TextBox ID="txtDescription" runat="server" Height="100px" Width="640px" TextMode="MultiLine">
                                                                        </asp:TextBox>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="lc" style="width: 25%">
                                                                    Select File to Attach
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 75%">
                                                                    <asp:FileUpload ID="uplCommon" runat="server" Width="300px" />
                                                                    <asp:RequiredFieldValidator ID="rfvUpload" runat="server" ControlToValidate="uplCommon"
                                                                        InitialValue="" Display="None" ErrorMessage="Please Select File to Upload." ValidationGroup="vsErrorGroup">
                                                                        
                                                                    </asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" ValidationGroup="vsErrorGroup"
                                                            SkinID="btnGen" OnClick="btnAddAttachment_Click" OnClientClick="javascript:ValAttach();" />
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                            OnClick="btnSave_Click" OnClientClick="javascript:ValSave();" />
                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </EditItemTemplate>
                                    </asp:FormView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
        <tr>
            <td>
                <div id="dvAttachDetails" runat="server">
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
                                <asp:GridView ID="gvAttachmentDetails" runat="server" BorderColor="silver" BorderStyle="Solid" BorderWidth="1px" AutoGenerateColumns="false"
                                    DataKeyNames="PK_Attachment_ID" Width="100%" AllowPaging="false" AllowSorting="false"
                                    OnRowDataBound="gvAttachmentDetails_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <input name="chkItem" type="checkbox" value='<%# Eval("PK_Attachment_ID")%>' onclick="javascript:UnCheckHeader('gvAttachmentDetails')" />
                                            </ItemTemplate>
                                            <ItemStyle Width="10px" />
                                            <HeaderTemplate>
                                                <input id="chkHeader" name="chkHeader" type="checkbox" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                            </HeaderTemplate>
                                            <HeaderStyle Width="10px" />
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" SortExpression="Attachment_Type">
                                        </asp:BoundField>--%>
                                        <asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description"
                                            SortExpression="Attachment_Description"></asp:BoundField>
                                        <asp:BoundField DataField="Attachment_Name1" HeaderText="File Name" SortExpression="Attachment_Name1">
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Icon">
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
                                        Currently There Is No Attachment.<br />
                                        Pls Add One Or More Attachment.
                                    </EmptyDataTemplate>
                                    <PagerSettings Visible="False" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />
                                <asp:Button ID="btnMail" runat="server" Text="Mail" OnClientClick="javascript:return OpenWMail('gvAttachmentDetails','Property_Drivers');" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <%--</div>--%>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
