<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="VendorDetails.aspx.cs"
    Inherits="VendorDetails" Theme="Default"   %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>

    <script type="text/javascript">
        function MinMax(name)
        {
            
            if(name == "attachment")
            {
            
                //alert(document.getElementById("ctl00_ContentPlaceHolder1_fvVendorDetails_txtDescription").style.height);
                if(document.getElementById("ctl00_ContentPlaceHolder1_fvVendorDetails_txtDescription").style.height == "")
                {
                
                    document.getElementById("ctl00_ContentPlaceHolder1_fvVendorDetails_ibtnAttach").src = "../Images/minus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvVendorDetails_txtDescription").style.height = "200px";
                    document.getElementById("pnlAttach").style.display = "block";
                }
                else if(document.getElementById("ctl00_ContentPlaceHolder1_fvVendorDetails_txtDescription").style.height == "200px")
                {
                    
                    document.getElementById("ctl00_ContentPlaceHolder1_fvVendorDetails_ibtnAttach").src = "../Images/plus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvVendorDetails_txtDescription").style.height="";
                    document.getElementById("pnlAttach").style.display = "none";
                }
            }
            return false;
        }
        function ValAttach()
        {
            
            document.getElementById("ctl00_ContentPlaceHolder1_fvVendorDetails_rfvAttachType").enabled =true;
            document.getElementById("ctl00_ContentPlaceHolder1_fvVendorDetails_rfvUpload").enabled =true;
            if(document.getElementById("ctl00_ContentPlaceHolder1_fvVendorDetails_txtPhone").value=="___-___-____")
                document.getElementById("ctl00_ContentPlaceHolder1_fvVendorDetails_txtPhone").value="";
            if(document.getElementById("ctl00_ContentPlaceHolder1_fvVendorDetails_txtFaxNo").value=="___-___-____")
                document.getElementById("ctl00_ContentPlaceHolder1_fvVendorDetails_txtFaxNo").value="";
            
            return true;
        }
        function ValSave()
        {
            
            document.getElementById("ctl00_ContentPlaceHolder1_fvVendorDetails_rfvAttachType").enabled =false;
            document.getElementById("ctl00_ContentPlaceHolder1_fvVendorDetails_rfvUpload").enabled =false;
            if(document.getElementById("ctl00_ContentPlaceHolder1_fvVendorDetails_txtPhone").value=="___-___-____")
                document.getElementById("ctl00_ContentPlaceHolder1_fvVendorDetails_txtPhone").value="";
            if(document.getElementById("ctl00_ContentPlaceHolder1_fvVendorDetails_txtFaxNo").value=="___-___-____")
                document.getElementById("ctl00_ContentPlaceHolder1_fvVendorDetails_txtFaxNo").value="";
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
        function conditionalPostback(sender, args) 
        { 
            var eventTarget = args.EventTarget;
            
            //else
            //{
                return true;
            //} 
        } 
        
    </script>

    <asp:ScriptManager ID="smVendorDetail" EnablePageMethods="true" runat="server">
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
                                                <asp:ListItem Value="Vendor_Tax_Id">Vendor Tax Id</asp:ListItem>
                                                <asp:ListItem Value="Vendor_Name">Vendor Name</asp:ListItem>
                                                <asp:ListItem Value="Vendor_Type">Vendor Type</asp:ListItem>
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
                                <asp:Label ID="lblVendorDetailsTotal" runat="server"></asp:Label>
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
                <asp:MultiView ID="mvVendorDetails" runat="server">
                    <asp:View ID="vwVendorList" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <table width="100%" style="text-align: right;">
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Click here to delete Vendor Details"
                                                    OnClick="btnDelete_Click" />
                                                <asp:Button ID="btnAddNew" runat="server" Text="Add New" ToolTip="Add new Vendor Details"
                                                    OnClick="btnAddNew_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align:left;">
                                                <asp:GridView ID="gvVendorDetails" runat="server" AutoGenerateColumns="false" DataKeyNames="PK_Vendor_ID"
                                                    Width="100%" AllowPaging="True" AllowSorting="True" OnRowCommand="gvVendorDetails_RowCommand"
                                                    OnSorting="gvVendorDetails_Sorting" OnRowCreated="gvVendorDetails_RowCreated" OnRowDataBound="gvVendorDetails_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <input name="chkItem" type="checkbox" value='<%# Eval("PK_Vendor_ID")%>' onclick="javascript:UnCheckHeader('gvVendorDetails')" />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="10px" />
                                                            <HeaderTemplate>
                                                                <input id="chkHeader" name="chkHeader" type="checkbox" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                                            </HeaderTemplate>
                                                            <HeaderStyle Width="10px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Vendor_Tax_Id" HeaderText="Vendor Tax Id" SortExpression="Vendor_Tax_Id">
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Vendor_Name" HeaderText="Vendor Name" SortExpression="Vendor_Name">
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Vendor_Type" HeaderText="Vendor Type" SortExpression="Vendor_Type">
                                                        </asp:BoundField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_Vendor_ID")%>'
                                                                    runat="server" Text="Edit" ToolTip="Edit the Vendor Details" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("PK_Vendor_ID")%>'
                                                                    ToolTip="View the Vendor Details" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                    <EmptyDataTemplate>
                                                        Currently There Is No Vendor.
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
                    <asp:View ID="vwVendorDetails" runat="server">
                        <table width="100%">
                            <%--<tr>
                                    <td class="lc">
                                        Vendor
                                    </td>
                                </tr>--%>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:FormView ID="fvVendorDetails" runat="server" Width="100%" OnDataBound="fvVendorDetails_DataBound">
                                        <ItemTemplate>
                                            <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                                                text-align: left;">
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Vendor Module
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%; " class="lc">
                                                                    Tax Id Number
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%; " class="ic">
                                                                    <asp:Label ID="lblTaxIdNo" runat="server" Text='<%#Eval("Vendor_Tax_Id") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Address(1)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblAddress1" runat="server" Text='<%#Eval("Address_1") %>'></asp:Label></td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="lc">
                                                                    State
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblState" runat="server" Text='<%#Eval("State") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 21px" class="lc">
                                                                    Telephone(xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="height: 21px" class="ic">
                                                                    <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("Phone") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Type
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblType" runat="server" Text='<%#Eval("Vendor_Type") %>'></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" style="text-align: left;">
                                                        <tr>
                                                                <td class="lc">
                                                                    Vendor Name
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="txtVendorName" runat="server" Text='<%#Eval("Vendor_Name") %>'></asp:Label>
                                                                    <asp:Label ID="lblVendorDetailsId" runat="server" Text='<%#Eval("PK_Vendor_ID")%>'
                                                                        Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Address(2)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblAddress2" runat="server" Text='<%#Eval("Address_2") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    City
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblCity" runat="server" Text='<%#Eval("City") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Zip Code
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblZip" runat="server" Text='<%#Eval("Zip_Code") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Facsimile
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblFaxNo" runat="server" Text='<%#Eval("Facsimile") %>'></asp:Label>
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
                                                <%--<tr>
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
                                                                DataKeyNames="PK_Attachment_ID" Width="100%" AllowPaging="True" AllowSorting="True">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <input name="chkItem" type="checkbox" value='<%# Eval("PK_Attachment_ID")%>' onclick="javascript:ErimsUnChekcHeader()" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="10px" />
                                                                        <HeaderTemplate>
                                                                            <input type="checkbox" name="chkHeader" onclick="javascript:setCheck(aspnetForm,this.checked)" />
                                                                        </HeaderTemplate>
                                                                        <HeaderStyle Width="10px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" SortExpression="Attachment_Type">
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description"
                                                                        SortExpression="Attachment_Description"></asp:BoundField>
                                                                    <asp:BoundField DataField="Attachment_Name" HeaderText="File Name" SortExpression="Attachment_Name">
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Icon">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="imgbtnDwnld" CommandName="Download" CommandArgument='<%# Eval("PK_Attachment_ID")%>'
                                                                                runat="server" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Mail">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="imgbtnMail" CommandName="Mail" CommandArgument='<%# Eval("PK_Attachment_ID")%>'
                                                                                runat="server" ImageUrl="~/Images/emailicon.gif" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    Currently There Is No Attachment.
                                                                </EmptyDataTemplate>
                                                                <PagerSettings Visible="False" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>--%>
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
                                                                    Vendor Module
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 50%; height: 26px;" class="lc">
                                                                    Tax Id Number<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%; height: 26px;" class="ic">
                                                                    <asp:TextBox ID="txtTaxIdNo" runat="server" TabIndex="1"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvTaxIdNo" ControlToValidate="txtTaxIdNo" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Tax Id Number."
                                                                        Display="None" Text="*"></asp:RequiredFieldValidator>
                                                                    <asp:Label ID="lblVendorDetailsId" runat="server" Text='<%#Eval("PK_Vendor_ID")%>'
                                                                        Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Address(1)<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtAddress1" runat="server" TabIndex="3"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvAddress1" ControlToValidate="txtAddress1" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Bank Address1."
                                                                        Display="None" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    State<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlState" runat="server" TabIndex="5">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvState" ControlToValidate="ddlState" runat="server"
                                                                        InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select the State."
                                                                        Display="None" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 21px" class="lc">
                                                                    Telephone(xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="height: 21px" class="ic">
                                                                    <asp:TextBox ID="txtPhone" runat="server" MaxLength="12" onkeypress="return noPhoneFax(event);" TabIndex="7" ></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskPhone" runat="server" TargetControlID="txtPhone" Mask="999-999-9999"
                                                                        MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false" >
                                                                    </cc1:MaskedEditExtender>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvPhone" ControlToValidate="txtPhone" runat="server"
                                                                            InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Telephone."
                                                                            Display="none"></asp:RequiredFieldValidator>--%>
                                                                    <asp:RegularExpressionValidator ID="revPhone" ControlToValidate="txtPhone" runat="server"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Type<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlType" runat="server" TabIndex="9">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvType" ControlToValidate="ddlType" runat="server"
                                                                        InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select the Type."
                                                                        Display="None" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%">
                                                        <tr>
                                                                <td style="width: 50%; height: 26px;" class="lc">
                                                                    Vendor Name<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%; height: 26px;" class="ic">
                                                                    <asp:TextBox ID="txtVendorName" runat="server" TabIndex="2"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvVendorName" ControlToValidate="txtVendorName"
                                                                        EnableClientScript="true" runat="server" InitialValue="" ValidationGroup="vsErrorGroup"
                                                                        ErrorMessage="Please Enter the Vendor Name." Display="None" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Address(2)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtAddress2" runat="server" TabIndex="4"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvAddress2" ControlToValidate="txtAddress2" runat="server"
                                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Address2."
                                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="lc">
                                                                    City<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtCity" runat="server" TabIndex="6"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvCity" ControlToValidate="txtCity" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the City."
                                                                        Display="None" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Zip Code<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtZip" runat="server" MaxLength="5" onkeypress="return numberOnly(event);" TabIndex="8"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvZip" ControlToValidate="txtZip" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Zip."
                                                                        Display="None" Text="*"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="revZip" runat="server" ControlToValidate="txtZip"
                                                                        ValidationExpression="^\d{5}$" ErrorMessage="Please Enter 5 Digits For Zip."
                                                                        ValidationGroup="vsErrorGroup" Display="none"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Facsimile(xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtFaxNo" runat="server" MaxLength="12" onkeypress="return noPhoneFax(event);" TabIndex="10"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskFax" runat="server" TargetControlID="txtFaxNo" Mask="999-999-9999"
                                                                        MaskType="Number" AutoComplete="false" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvFaxNo" ControlToValidate="txtFaxNo" runat="server"
                                                                            InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Facsimile."
                                                                            Display="none"></asp:RequiredFieldValidator>--%>
                                                                    <asp:RegularExpressionValidator ID="revFaxNo" ControlToValidate="txtFaxNo" runat="server"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Facsimile in xxx-xxx-xxxx format."
                                                                        Display="None" Text="*" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
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
                                                                    <asp:DropDownList ID="ddlAttachType" runat="server" TabIndex="11">
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
                                                                    <asp:ImageButton ID="ibtnAttach" ImageUrl="~/Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMax('attachment');" TabIndex="12" />
                                                                    <div id="pnlAttach" style="display:block;">
                                                                    <asp:TextBox ID="txtDescription" runat="server" Width="694px"  TextMode="MultiLine" >
                                                                    </asp:TextBox >
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
                                                                    <asp:FileUpload ID="uplCommon" runat="server" Width="300px" TabIndex="13" />
                                                                    <asp:RequiredFieldValidator ID="rfvUpload" runat="server" ControlToValidate="uplCommon"
                                                                        InitialValue="" Display="None" Text="*" ErrorMessage="Please Select File to Upload." ValidationGroup="vsErrorGroup">
                                                                        
                                                                    </asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" ValidationGroup="vsErrorGroup"
                                                            SkinID="btnGen" OnClick="btnAddAttachment_Click" OnClientClick="javascript:ValAttach();" TabIndex="14" />
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                            OnClick="btnSave_Click" OnClientClick="javascript:ValSave();" TabIndex="15" />
                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" TabIndex="16" />
                                                    </td>
                                                </tr>
                                                <%--<tr>
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
                                                                DataKeyNames="PK_Attachment_ID" Width="100%" AllowPaging="True" AllowSorting="True">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <input name="chkItem" type="checkbox" value='<%# Eval("PK_Attachment_ID")%>' onclick="javascript:ErimsUnChekcHeader()" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="10px" />
                                                                        <HeaderTemplate>
                                                                            <input type="checkbox" name="chkHeader" onclick="javascript:setCheck(aspnetForm,this.checked)" />
                                                                        </HeaderTemplate>
                                                                        <HeaderStyle Width="10px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" SortExpression="Attachment_Type">
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description"
                                                                        SortExpression="Attachment_Description"></asp:BoundField>
                                                                    <asp:BoundField DataField="Attachment_Name" HeaderText="File Name" SortExpression="Attachment_Name">
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Icon">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="imgbtnDwnld" CommandName="Download" CommandArgument='<%# Eval("PK_Attachment_ID")%>'
                                                                                runat="server" OnClientClick="Temp();" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Mail">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="imgbtnMail" CommandName="Mail" CommandArgument='<%# Eval("PK_Attachment_ID")%>'
                                                                                runat="server" ImageUrl="~/Images/emailicon.gif" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    Currently There Is No Attachment.<br />
                                                                    Pls Add One Or More Attachment.
                                                                </EmptyDataTemplate>
                                                                <PagerSettings Visible="False" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>--%>
                                            </table>
                                        </InsertItemTemplate>
                                        <EditItemTemplate>
                                            <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                                                text-align: left;">
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoms; font-size: 10pt;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Vendor Module
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 50%; height: 26px;" class="lc">
                                                                    Tax Id Number<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%; height: 26px;" class="ic" >
                                                                    <asp:TextBox ID="txtTaxIdNo" runat="server" Text='<% #Eval("Vendor_Tax_Id") %>' TabIndex="1"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvTaxIdNo" ControlToValidate="txtTaxIdNo" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Tax Id Number."
                                                                        Display="None" Text="*"></asp:RequiredFieldValidator>
                                                                    <asp:Label ID="lblVendorDetailsId" runat="server" Text='<%#Eval("PK_Vendor_ID")%>'
                                                                        Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Address(1)<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtAddress1" runat="server" Text='<% #Eval("Address_1") %>' TabIndex="3"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvAddress1" ControlToValidate="txtAddress1" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Bank Address1."
                                                                        Display="None" Text="*"></asp:RequiredFieldValidator>
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
                                                                    <asp:DropDownList ID="ddlState" runat="server" TabIndex="5">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvState" ControlToValidate="ddlState" runat="server"
                                                                        InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select the State."
                                                                        Display="None" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 21px" class="lc">
                                                                    Telephone(xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="height: 21px" class="ic">
                                                                    <asp:TextBox ID="txtPhone" runat="server" MaxLength="12" Text='<% #Eval("Phone") %>'
                                                                        onkeypress="return noPhoneFax(event);" TabIndex="7"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskPhone" runat="server" TargetControlID="txtPhone" Mask="999-999-9999"
                                                                        MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="False">
                                                                    </cc1:MaskedEditExtender>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvPhone" ControlToValidate="txtPhone" runat="server"
                                                                            InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Telephone."
                                                                            Display="none"></asp:RequiredFieldValidator>--%>
                                                                    <asp:RegularExpressionValidator ID="revPhone" ControlToValidate="txtPhone" runat="server"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Telephone in xxx-xxx-xxxx format."
                                                                        Display="None" Text="*" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Type<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlType" runat="server" TabIndex="9">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvType" ControlToValidate="ddlType" runat="server"
                                                                        InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select the Type."
                                                                        Display="None" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%">
                                                        <tr>
                                                                <td style="width: 50%; height: 26px;" class="lc">
                                                                    Vendor Name<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%; height: 26px;" class="ic">
                                                                    <asp:TextBox ID="txtVendorName" runat="server" Text='<% #Eval("Vendor_Name") %>' TabIndex="2"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvVendorName" ControlToValidate="txtVendorName"
                                                                        runat="server" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Vendor Name."
                                                                        Display="None" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Address(2)
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtAddress2" runat="server" Text='<% #Eval("Address_2") %>' TabIndex="4"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvAddress2" ControlToValidate="txtAddress2" runat="server"
                                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Address2."
                                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="lc">
                                                                    City<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtCity" runat="server" Text='<% #Eval("City") %>' TabIndex="6"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvCity" ControlToValidate="txtCity" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the City."
                                                                        Display="None" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Zip Code<span class="mf">*</span>
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtZip" runat="server" MaxLength="5" Text='<% #Eval("Zip_Code") %>'
                                                                        onkeypress="return numberOnly(event);" TabIndex="8"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvZip" ControlToValidate="txtZip" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Zip."
                                                                        Display="None" Text="*"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="revZip" runat="server" ControlToValidate="txtZip"
                                                                        ValidationExpression="^\d{5}$" ErrorMessage="Please Enter 5 Digits For Zip."
                                                                        ValidationGroup="vsErrorGroup" Display="none"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Facsimile(xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtFaxNo" runat="server" MaxLength="12" Text='<% #Eval("Facsimile") %>'
                                                                        onkeypress="return noPhoneFax(event);" TabIndex="10" ></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskFax" runat="server" TargetControlID="txtFaxNo" Mask="999-999-9999"
                                                                        MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvFaxNo" ControlToValidate="txtFaxNo" runat="server"
                                                                            InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Facsimile."
                                                                            Display="none"></asp:RequiredFieldValidator>--%>
                                                                    <asp:RegularExpressionValidator ID="revFaxNo" ControlToValidate="txtFaxNo" runat="server"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Facsimile in xxx-xxx-xxxx format."
                                                                        Display="None" Text="*" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
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
                                                <tr  style="display:none;">
                                                    <td style="width: 50%;" align="left">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="lc" style="width: 50%;">
                                                                    Attachment Type
                                                                </td>
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 50%;">
                                                                    <asp:DropDownList ID="ddlAttachType" runat="server" TabIndex="11">
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
                                                                <td align="center" valign="top" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" align="left" style="width: 75.7%;">
                                                                <asp:ImageButton ID="ibtnAttach" ImageUrl="~/Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMax('attachment');" TabIndex="12" />
                                                                    <div id="pnlAttach" style="display:block;">
                                                                    
                                                                    <asp:TextBox ID="txtDescription" runat="server" Width="650px" TextMode="MultiLine"></asp:TextBox>
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
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 75.7%">
                                                                    <asp:FileUpload ID="uplCommon" runat="server" Width="300px" TabIndex="13" />
                                                                    <asp:RequiredFieldValidator ID="rfvUpload" runat="server" ControlToValidate="uplCommon"
                                                                        InitialValue="" Display="None" Text="*" ErrorMessage="Please Select File to Upload." ValidationGroup="vsErrorGroup">
                                                                        
                                                                    </asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center" class="ic">
                                                        <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" ValidationGroup="vsErrorGroup"
                                                            SkinID="btnGen" OnClick="btnAddAttachment_Click" OnClientClick="javascript:ValAttach();" TabIndex="14" />
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                            OnClick="btnSave_Click" OnClientClick="javascript:ValSave();" TabIndex="15" />
                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" TabIndex="16" />
                                                    </td>
                                                </tr>
                                                <%--<tr>
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
                                                                DataKeyNames="PK_Attachment_ID" Width="100%" AllowPaging="True" AllowSorting="True"
                                                                OnDataBound="gvAttachmentDetails_DataBound">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <input name="chkItem" type="checkbox" value='<%# Eval("PK_Attachment_ID")%>' onclick="javascript:ErimsUnChekcHeader()" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="10px" />
                                                                        <HeaderTemplate>
                                                                            <input type="checkbox" name="chkHeader" onclick="javascript:setCheck(aspnetForm,this.checked)" />
                                                                        </HeaderTemplate>
                                                                        <HeaderStyle Width="10px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" SortExpression="Attachment_Type">
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description"
                                                                        SortExpression="Attachment_Description"></asp:BoundField>
                                                                    <asp:BoundField DataField="Attachment_Name" HeaderText="File Name" SortExpression="Attachment_Name">
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Icon">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="imgbtnDwnld" CommandName="Download" CommandArgument='<%# Eval("PK_Attachment_ID")%>'
                                                                                runat="server" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Mail">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="imgbtnMail" CommandName="Mail" CommandArgument='<%# Eval("PK_Attachment_ID")%>'
                                                                                runat="server" ImageUrl="~/Images/emailicon.gif" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                    </asp:TemplateField>
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
                                                    </tr>--%>
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
                                                <input name="chkItem" type="checkbox" value='<%# Eval("PK_Attachment_ID")%>' onclick="javascript:javascript:UnCheckHeader('gvAttachmentDetails')" />
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
                                        <asp:BoundField DataField="Attachment_Name1" HeaderText="File Name" SortExpression="Attachment_Name">
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
                                <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />
                                <asp:Button ID="btnMail" runat="server" Text="Mail" OnClientClick="javascript:return OpenWMail('gvAttachmentDetails','Vendor');" />
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
