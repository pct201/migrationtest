<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="EmployeeTraining.aspx.cs"
    Inherits="Employee_EmployeeTraining"  %>

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
                if(document.getElementById("ctl00_ContentPlaceHolder1_fvEmpTraining_txtDescription").style.height == "")
                {
                
                    document.getElementById("ctl00_ContentPlaceHolder1_fvEmpTraining_ibtnAttach").src = "../Images/minus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvEmpTraining_txtDescription").style.height = "200px";
                    document.getElementById("pnlAttach").style.display = "block";
                }
                else if(document.getElementById("ctl00_ContentPlaceHolder1_fvEmpTraining_txtDescription").style.height == "200px")
                {
                    
                    document.getElementById("ctl00_ContentPlaceHolder1_fvEmpTraining_ibtnAttach").src = "../Images/plus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvEmpTraining_txtDescription").style.height="";
                    document.getElementById("pnlAttach").style.display = "none";
                }
            }
            return false;
        }
        function ValAttach()
        {
            
            document.getElementById("ctl00_ContentPlaceHolder1_fvEmpTraining_rfvAttachType").enabled =true;
            document.getElementById("ctl00_ContentPlaceHolder1_fvEmpTraining_rfvUpload").enabled =true;
            return true;
        }
        function ValSave()
        {
            
            document.getElementById("ctl00_ContentPlaceHolder1_fvEmpTraining_rfvAttachType").enabled =false;
            document.getElementById("ctl00_ContentPlaceHolder1_fvEmpTraining_rfvUpload").enabled =false;
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
        function openEmpWindow()
        {
            //oWnd=window.open("../WorkerCompensation/Employee_Search_Popup.aspx?Page=EmpTraining","Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            oWnd=window.open("../Claim/EmployeePopup.aspx?Page=EmpTraining","Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=750,height=500");
            oWnd.moveTo(260,180);
            return false;
            
        }
        function conditionalPostback(sender, args) 
        { 
            var eventTarget = args.EventTarget;
            
            //else
            //{
                return true;
            //} 
        } 
        
    </script>

    <asp:ScriptManager ID="smEmployeeTrainig" EnablePageMethods="true" runat="server">
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
                            <td style="width: 50%;" align="right">
                                <table width="80%">
                                    <tr>
                                        <td class="lc">
                                            Search
                                        </td>
                                        <td class="ic">
                                            <asp:DropDownList ID="ddlSearch" runat="server" SkinID="dropGen">
                                                <asp:ListItem Value="Training_Description">Training Description</asp:ListItem>
                                                <asp:ListItem Value="TS.Fld_Desc">Training Status</asp:ListItem>
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
                                <asp:Label ID="lblETTotal" runat="server"></asp:Label>
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
                <asp:MultiView ID="mvEmpTraining" runat="server">
                    <asp:View ID="vwEmpTrainingList" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <table width="100%" style="text-align: right;">
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Click here to delete Employee Training Details"
                                                    OnClick="btnDelete_Click" />
                                                <asp:Button ID="btnAddNew" runat="server" Text="Add New" ToolTip="Add new Employee Training Details"
                                                    OnClick="btnAddNew_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvEmpTraining" runat="server" AutoGenerateColumns="false" DataKeyNames="PK_Employee_Training_Id"
                                                    Width="100%" AllowPaging="True" AllowSorting="True" OnRowCommand="gvEmpTraining_RowCommand"
                                                    OnSorting="gvEmpTraining_Sorting" >
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <input name="chkItem" type="checkbox" value='<%# Eval("PK_Employee_Training_Id")%>'
                                                                    onclick="javascript:UnCheckHeader('gvEmpTraining')" />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="10px" />
                                                            <HeaderTemplate>
                                                                <input id="chkHeader" name="chkHeader" type="checkbox" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                                            </HeaderTemplate>
                                                            <HeaderStyle Width="10px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left"  DataField="Training_Description" HeaderText="Training Description"
                                                            SortExpression="Training_Description"></asp:BoundField>
                                                        <asp:BoundField HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left"  DataField="Training_Date" HeaderText="Training Date" SortExpression="Training_Date"
                                                            DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false"></asp:BoundField>
                                                        <asp:BoundField HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left"  DataField="Training_StatusText" HeaderText="Training Status" SortExpression="Training_StatusText">
                                                        </asp:BoundField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_Employee_Training_Id")%>'
                                                                    runat="server" Text="Edit" ToolTip="Edit the Employee Training Details" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("PK_Employee_Training_Id")%>'
                                                                    ToolTip="View the Employee Training Details" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                    <EmptyDataTemplate>
                                                        Currently There Is No Employee Training Details.
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
                    <asp:View ID="vwEmpTraining" runat="server">
                        <table width="100%">
                            <%--<tr>
                                    <td class="lc">
                                        Vendor
                                    </td>
                                </tr>--%>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:FormView ID="fvEmpTraining" runat="server" Width="100%" OnDataBound="fvEmpTraining_DataBound">
                                        <ItemTemplate>
                                            <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                                                text-align: left;">
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Employee Training Module
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
                                                                    Last Name
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblLastName" runat="server" Text='<%#Eval("Last_Name") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Middle Name
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblMiddleName" runat="server" Text='<%#Eval("Middle_Name") %>'></asp:Label>
                                                                    <asp:Label ID="lblEmpTrainingId" runat="server" Text='<%#Eval("PK_Employee_Training_Id")%>'
                                                                        Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Of Training
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblTrainingDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Training_Date","{0:MM/dd/yyyy}") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Of Retraining Date
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblRetraining" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Retrain_Date","{0:MM/dd/yyyy}") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Training Grade
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblTrainingGrade" runat="server" Text='<%#Eval("Training_GradeText") %>'></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    First Name
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("First_Name") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Description Of Training
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblTrainingDesc" runat="server" Text='<%#Eval("Training_Description") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Training Status
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblTrainingStatus" runat="server" Text='<%#Eval("Training_StatusText") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Training Type
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblTrainingType" runat="server" Text='<%#Eval("Training_TypeText") %>'></asp:Label>
                                                                </td>
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
                                                                    Employee Training Module
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:50%;">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 50%; height: 26px;" class="lc">
                                                                    Last Name<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%; height: 26px;" class="ic">
                                                                    <asp:TextBox ID="txtLastName" runat="server" onKeyDown="javascript:return disableDeleteBackSpace();"></asp:TextBox>
                                                                    <asp:Button ID="btnEmp" runat="server" Text="V" SkinID="btnGen" OnClientClick="javascript:return openEmpWindow();"  TabIndex="1"/>
                                                                    <asp:TextBox ID="txtEmpId" Style="display: none;" runat="server"></asp:TextBox>
                                                                    
                                                                    <asp:Label ID="lblEmpTrainingId" runat="server" Text='<%#Eval("PK_Employee_Training_ID")%>'
                                                                        Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Middle Name
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtMiddleName" runat="server" onKeyDown="javascript:return disableDeleteBackSpace();"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvMiddleName" ControlToValidate="txtMiddleName" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Address Line 1."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Of Training<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtDateOfTraining" runat="server" SkinID="txtDate" TabIndex="3"></asp:TextBox>
                                                                    <img runat="server" id="img3" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvEmpTraining_txtDateOfTraining', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absmiddle" />
                                                                    <asp:RequiredFieldValidator ID="rfvDateOfTraining" ControlToValidate="txtDateOfTraining"
                                                                        runat="server" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Date Of Training."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                    <cc1:MaskedEditExtender ID="mskDT" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtDateOfTraining" CultureName="en-US"
                                                                        AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="rgeDT" runat="server" ControlToValidate="txtDateOfTraining"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date Of Training)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Of Retraining<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtDateOfRetraining" runat="server" SkinID="txtDate" TabIndex="5"></asp:TextBox>
                                                                    <img runat="server" id="img1" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvEmpTraining_txtDateOfRetraining', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absmiddle" />
                                                                    <cc1:MaskedEditExtender ID="mskDRT" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtDateOfRetraining" CultureName="en-US"
                                                                        AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="rgeDRT" runat="server" ControlToValidate="txtDateOfRetraining"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date Of Retraining)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                    <asp:RequiredFieldValidator ID="rfvZip" ControlToValidate="txtDateOfRetraining" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Date of Retraining."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="txtDateOfTraining"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Date Of Training Must Not Be Greater Than Date Of Retraining."
                                                                        Type="Date" Operator="LessThan" ControlToCompare="txtDateOfRetraining" Display="none"></asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 21px" class="lc">
                                                                    Training Grade<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="height: 21px" class="ic">
                                                                    <asp:DropDownList ID="ddlTrainingGrade" runat="server" TabIndex="7">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvGrade" ControlToValidate="ddlTrainingGrade" runat="server"
                                                                        InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select the Training Grade."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top" style="width:50%;">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    First Name<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtFirstName" runat="server" onKeyDown="javascript:return disableDeleteBackSpace();"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvFirstName" ControlToValidate="txtFirstName" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Employee."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Description Of Training<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtTrainingDesc" runat="server" MaxLength="50" TabIndex="2"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvTDesc" ControlToValidate="txtTrainingDesc" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Training Description."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Training Status<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:DropDownList ID="ddlTrainingStatus" runat="server" TabIndex="4">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvTrainingStatus" ControlToValidate="ddlTrainingStatus"
                                                                        runat="server" InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Training Status."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Training Type<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlTrainingType" runat="server" TabIndex="6">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvTrainingType" ControlToValidate="ddlTrainingType"
                                                                        runat="server" InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select the Training Type."
                                                                        Display="none"></asp:RequiredFieldValidator>
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
                                                <tr style="display:none;">
                                                    <td style="width: 50%;" align="left">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="lc" style="width: 50%;">
                                                                    Attachment Type
                                                                </td>
                                                                <td align="Center" class="lc">
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
                                                                <td class="lc" style="width: 24.3%" valign="top">
                                                                    Attachment Description</td>
                                                                <td align="Center" valign="top" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" align="left" style="width: 75.7%;">
                                                                <asp:ImageButton ID="ibtnAttach" TabIndex="8" ImageUrl="~/Images/plus.jpg" runat="server" OnClientClick="javascript:return MinMax('attachment');" />
                                                                    <div id="pnlAttach" style="display:none;">
                                                                    <asp:TextBox ID="txtDescription" runat="server" Width="694px"  TextMode="MultiLine">
                                                                    
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
                                                                <td class="lc" style="width: 24.3%">
                                                                    Select File to Attach
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 75.7%">
                                                                    <asp:FileUpload ID="uplCommon" runat="server" Width="300px" TabIndex="9" />
                                                                    <asp:RequiredFieldValidator ID="rfvUpload"  runat="server" ControlToValidate="uplCommon"
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
                                                            SkinID="btnGen" OnClick="btnAddAttachment_Click" TabIndex="10" OnClientClick="javascript:ValAttach();" />
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                            OnClick="btnSave_Click" OnClientClick="javascript:ValSave();" TabIndex="11" />
                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" TabIndex="12" />
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
                                                                    Employee Training Module
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:50%;">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 50%; height: 26px;" class="lc">
                                                                    Last Name<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%; height: 26px;" class="ic">
                                                                    <asp:TextBox ID="txtLastName" runat="server" Text='<%#Eval("Last_Name") %>' onKeyDown="javascript:return disableDeleteBackSpace();"></asp:TextBox>
                                                                    <asp:Button ID="btnEmp" runat="server" Text="V" SkinID="btnGen" OnClientClick="javascript:return openEmpWindow();" TabIndex="1" />
                                                                    <asp:TextBox ID="txtEmpId" runat="server" Style="display: none;" Text='<%#Eval("Employee_FK") %>' ></asp:TextBox>
                                                                    
                                                                    <asp:Label ID="lblEmpTrainingId" runat="server" Text='<%#Eval("PK_Employee_Training_ID")%>'
                                                                        Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Middle Name
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtMiddleName" runat="server" Text='<%#Eval("Middle_Name") %>' onKeyDown="javascript:return disableDeleteBackSpace();" ></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvMiddleName" ControlToValidate="txtMiddleName" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Address Line 1."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Of Training<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtDateOfTraining" runat="server" TabIndex="3" Text='<%#Eval("Training_Date") %>' SkinID="txtDate"></asp:TextBox>
                                                                    <img runat="server" id="img3" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvEmpTraining_txtDateOfTraining', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absmiddle" />
                                                                    <asp:RequiredFieldValidator ID="rfvDateOfTraining" ControlToValidate="txtDateOfTraining"
                                                                        runat="server" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Date Of Training."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                    <cc1:MaskedEditExtender ID="mskDT" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtDateOfTraining" CultureName="en-US"
                                                                        AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="rgeDT" runat="server" ControlToValidate="txtDateOfTraining"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date Of Training)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Of Retraining<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtDateOfRetraining" TabIndex="5" runat="server" Text='<%#Eval("Retrain_Date") %>' SkinID="txtDate"></asp:TextBox>
                                                                    <img runat="server" id="img1" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvEmpTraining_txtDateOfRetraining', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absmiddle" />
                                                                    <cc1:MaskedEditExtender ID="mskDRT" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtDateOfRetraining" CultureName="en-US"
                                                                        AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="rgeDRT" runat="server" ControlToValidate="txtDateOfRetraining"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date Of Retraining)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                    <asp:RequiredFieldValidator ID="rfvZip" ControlToValidate="txtDateOfRetraining" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Date of Retraining."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="txtDateOfTraining"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Date Of Training Must Not Be Greater Than Date Of Retraining."
                                                                        Type="Date" Operator="LessThan" ControlToCompare="txtDateOfRetraining" Display="none"></asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 21px" class="lc">
                                                                    Training Grade<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="height: 21px" class="ic">
                                                                    <asp:DropDownList ID="ddlTrainingGrade" TabIndex="7" runat="server">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvGrade" ControlToValidate="ddlTrainingGrade" runat="server"
                                                                        InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select the Training Grade."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top" style="width:50%;">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    First Name<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtFirstName" runat="server" Text='<%#Eval("First_Name") %>' onKeyDown="javascript:return disableDeleteBackSpace();"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvFirstName" ControlToValidate="txtFirstName" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Employee."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Description Of Training<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtTrainingDesc" runat="server" TabIndex="2" Text='<%#Eval("Training_Description") %>'
                                                                        MaxLength="50"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvTDesc" ControlToValidate="txtTrainingDesc" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Training Description."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Training Status<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:DropDownList ID="ddlTrainingStatus" runat="server" TabIndex="4">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvTrainingStatus" ControlToValidate="ddlTrainingStatus"
                                                                        runat="server" InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Training Status."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Training Type<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlTrainingType" runat="server" TabIndex="6">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvTrainingType" ControlToValidate="ddlTrainingType"
                                                                        runat="server" InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select the Training Type."
                                                                        Display="none"></asp:RequiredFieldValidator>
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
                                                <tr style="display:none;">
                                                    <td style="width: 50%;" align="left">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="lc" style="width: 50%;">
                                                                    Attachment Type
                                                                </td>
                                                                <td align="Center" class="lc">
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
                                                                <td class="lc" style="width: 24.3%" valign="top">
                                                                    Attachment Description</td>
                                                                <td align="Center" valign="top" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" align="left" style="width: 75.7%;">
                                                                <asp:ImageButton ID="ibtnAttach" TabIndex="8" ImageUrl="~/Images/plus.jpg" runat="server" OnClientClick="javascript:return MinMax('attachment');" />
                                                                    <div id="pnlAttach" style="display:none;">
                                                                    <asp:TextBox ID="txtDescription" runat="server" Width="694px"  TextMode="MultiLine">
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
                                                                <td class="lc" style="width: 24.3%">
                                                                    Select File to Attach
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 75.7%">
                                                                    <asp:FileUpload ID="uplCommon" runat="server" Width="300px" TabIndex="9" />
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
                                                        <asp:Button ID="btnAddAttachment" TabIndex="10" runat="server" Text="Add Attachment" ValidationGroup="vsErrorGroup"
                                                            SkinID="btnGen" OnClick="btnAddAttachment_Click" OnClientClick="javascript:ValAttach();" />
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                            OnClick="btnSave_Click" OnClientClick="javascript:ValSave();" TabIndex="11" />
                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" TabIndex="12" />
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
                                <asp:GridView ID="gvAttachmentDetails" runat="server" AutoGenerateColumns="false"
                                    DataKeyNames="PK_Attachment_ID" Width="100%" AllowPaging="false" AllowSorting="false"
                                    OnRowDataBound="gvAttachmentDetails_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <input name="chkItem" type="checkbox" value='<%# Eval("PK_Attachment_ID")%>'  onclick="javascript:UnCheckHeader('gvAttachmentDetails')" />
                                            </ItemTemplate>
                                            <ItemStyle Width="10px" />
                                            <HeaderTemplate>
                                                <input id="chkHeader" type="checkbox" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                            </HeaderTemplate>
                                            <HeaderStyle Width="10px" />
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" SortExpression="Attachment_Type">
                                        </asp:BoundField>--%>
                                        <asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description"
                                            SortExpression="Attachment_Description"></asp:BoundField>
                                        <asp:BoundField DataField="Attachment_Name1" HeaderText="File Name" SortExpression="Attachment_Name1">
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
                                        Currently There Is No Attachment.<br />
                                        Pls Add One Or More Attachment.
                                    </EmptyDataTemplate>
                                    <PagerSettings Visible="False" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnRemove" runat="server" TabIndex="13" Text="Remove" OnClick="btnRemove_Click" />
                                <asp:Button ID="btnMail" runat="server" Text="Mail" TabIndex="14" OnClientClick="javascript:return OpenWMail('gvAttachmentDetails','EmployeeTraining');" />
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
