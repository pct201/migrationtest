<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="AIGInfo.aspx.cs"
    Inherits="AIG_AIGInfo" Title="AIG Info" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>

    <link href="../App_Themes/Default/stylecal.css" type="text/css" rel="Stylesheet" />
    
    <asp:ScriptManager ID="smProvider" EnablePageMethods="true" runat="server">
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
                                                <asp:ListItem Value="AIGRM_Contract_Number">AIGRM Contract No.</asp:ListItem>
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
                                <asp:Label ID="lblAIGInfoTotal" runat="server"></asp:Label>
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
                <asp:MultiView ID="mvAIGInfo" runat="server">
                    <asp:View ID="vwAIGInfoList" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <table width="100%" style="text-align: right;">
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Click here to delete AIG Info Details"
                                                    OnClick="btnDelete_Click" />
                                                <asp:Button ID="btnAddNew" runat="server" Text="Add New" ToolTip="Add new AIG Info Details"
                                                    OnClick="btnAddNew_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvAIGInfo" runat="server" AutoGenerateColumns="false" DataKeyNames="PK_AIG_Info_ID"
                                                    Width="100%" AllowPaging="True" AllowSorting="True" OnRowCommand="gvAIGInfo_RowCommand"
                                                    OnSorting="gvAIGInfo_Sorting">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <input name="chkItem" type="checkbox" value='<%# Eval("PK_AIG_Info_ID")%>' onclick="javascript:UnCheckHeader('gvAIGInfo')" />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="10px" />
                                                            <HeaderTemplate>
                                                                <input id="chkHeader" name="chkHeader" type="checkbox" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                                            </HeaderTemplate>
                                                            <HeaderStyle Width="10px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="AIGRM_Contract_Number" HeaderText="AIGRM Contract Number"
                                                            SortExpression="AIGRM_Contract_Number"></asp:BoundField>
                                                        <asp:BoundField DataField="AIGRM_Start_Date" HeaderText="AIGRM Start Date" SortExpression="AIGRM_Start_Date" HtmlEncode="false" DataFormatString="{0:MM/dd/yyyy}">
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="AIGRM_End_Date" HeaderText="AIGRM End Date" SortExpression="AIGRM_End_Date" HtmlEncode="False" DataFormatString="{0:MM/dd/yyyy}">
                                                        </asp:BoundField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_AIG_Info_ID")%>'
                                                                    runat="server" Text="Edit" ToolTip="Edit the AIG Info Details" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("PK_AIG_Info_ID")%>'
                                                                    ToolTip="View the AIG Info Details" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                    <EmptyDataTemplate>
                                                        Currently There Is No AIG Info.
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
                    <asp:View ID="vwAIGInfo" runat="server">
                        <table width="100%">
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:FormView ID="fvAIGInfo" runat="server" Width="100%" OnDataBound="fvAIGInfo_DataBound">
                                        <ItemTemplate>
                                            <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                                                text-align: left;">
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    AIG Info
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
                                                                    AIGRM Contract Number
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblACN" runat="server" Text='<%#Eval("AIGRM_Contract_Number") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    AIGRM End Date
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblAED" runat="server"  Text='<%#DataBinder.Eval(Container.DataItem, "AIGRM_End_Date", "{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                    <asp:Label ID="lblAIGInfoId" runat="server" Text='<%#Eval("PK_AIG_Info_ID")%>' Height="0px"
                                                                        Width="0px" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td class="lc">
                                                                    AIGRM Start Date
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblASD" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "AIGRM_Start_Date", "{0:MM/dd/yyyy}")%>'></asp:Label>
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
                                                                    AIG Info
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 50%; " class="lc">
                                                                    AIGRM Contract Number<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtACN" runat="server" MaxLength="6"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvAIGCN" ControlToValidate="txtACN"
                                                                        runat="server" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter AIGRM Contract Number."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                    <asp:Label ID="lblAIGInfoId" runat="server" Text='<%#Eval("PK_AIG_Info_ID")%>' Height="0px"
                                                                        Width="0px" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    AIGRM End Date
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtAED" runat="server"></asp:TextBox>
                                                                    <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvAIGInfo_txtAED', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="mskAED" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtAED"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                            
                                                                        </cc1:MaskedEditExtender>
                                                                    <cc1:MaskedEditValidator ID="mskValDtStart" runat="server" ControlExtender="mskAED"
                                                                                ControlToValidate="txtAED" Display="None" IsValidEmpty="true" MaximumValue=""
                                                                                EmptyValueMessage="" InvalidValueMessage="Date Not Valid(AIGRM End Date)"
                                                                                MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue=""
                                                                                ValidationGroup="vsErrorGroup"></cc1:MaskedEditValidator>
                                                                </td>
                                                            </tr>
                                                           
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="lc">
                                                                    AIGRM Start Date
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtASD" runat="server"></asp:TextBox>
                                                                    <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvAIGInfo_txtASD', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="mskASD" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtASD"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="mskASD"
                                                                                ControlToValidate="txtASD" Display="None" IsValidEmpty="true" MaximumValue=""
                                                                                EmptyValueMessage="" InvalidValueMessage="Date Not Valid(AIGRM Start Date)"
                                                                                MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue=""
                                                                                ValidationGroup="vsErrorGroup"></cc1:MaskedEditValidator>
                                                                    
                                                                </td>
                                                            </tr>
                                                           
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                            OnClick="btnSave_Click" />
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
                                                                    AIG Info
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
                                                                    AIGRM Contract Number<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtACN" runat="server" MaxLength="6" Text='<%#Eval("AIGRM_Contract_Number") %>'></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvAIGCN" ControlToValidate="txtACN"
                                                                        runat="server" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter AIGRM Contract Number."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                    <asp:Label ID="lblAIGInfoId" runat="server" Text='<%#Eval("PK_AIG_Info_ID")%>' Height="0px"
                                                                        Width="0px" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    AIGRM End Date
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtAED" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "AIGRM_End_Date", "{0:MM/dd/yyyy}")%>'></asp:TextBox>
                                                                    <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvAIGInfo_txtAED', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="mskAED" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtAED"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                    <cc1:MaskedEditValidator ID="mskValDtStart" runat="server" ControlExtender="mskAED"
                                                                                ControlToValidate="txtAED" Display="None" IsValidEmpty="true" MaximumValue=""
                                                                                EmptyValueMessage="" InvalidValueMessage="Date Not Valid(AIGRM End Date)"
                                                                                MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue=""
                                                                                ValidationGroup="vsErrorGroup"></cc1:MaskedEditValidator>
                                                                </td>
                                                            </tr>
                                                           
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="lc">
                                                                    AIGRM Start Date
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtASD" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "AIGRM_Start_Date", "{0:MM/dd/yyyy}")%>'></asp:TextBox>
                                                                    <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvAIGInfo_txtASD', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="mskASD" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtASD"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="mskASD"
                                                                                ControlToValidate="txtASD" Display="None" IsValidEmpty="true" MaximumValue=""
                                                                                EmptyValueMessage="" InvalidValueMessage="Date Not Valid(AIGRM Start Date)"
                                                                                MaximumValueMessage="" MinimumValueMessage="" TooltipMessage="" MinimumValue=""
                                                                                ValidationGroup="vsErrorGroup"></cc1:MaskedEditValidator>
                                                                </td>
                                                            </tr>
                                                           
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                            OnClick="btnSave_Click" />
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
                
            </td>
        </tr>
    </table>
    <%--</div>--%>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
