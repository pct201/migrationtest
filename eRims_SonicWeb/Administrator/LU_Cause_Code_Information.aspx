<%@ Page Title="eRIMS Sonic :: Cause Code Information" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="LU_Cause_Code_Information.aspx.cs" Inherits="Administrator_LU_Cause_Code_Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

 <style>
  .watermarkTextBox
 {
     width: 200px;
     background-color: Aqua;
 }
 input, textarea
 {
     width: 200px;
 }
 /*Reorder List*/
 .dragHandle
 {
     width: 10px;
     height: 15px;
     background-color: Blue;
     background-image: url(/images/bg-menu-main.png);
     cursor: move;
     border: outset thin white;
 }
 .callbackStyle
 {
     border: thin blue inset;
 }
 .callbackStyle table
 {
     background-color: #5377A9;
     color: Black;
 }
 .reorderListDemo li
 {
     list-style: none;
     margin: 2px;
     /*background-image: url(/images/bg_nav.gif);*/
     background-repeat: repeat-x;
     /*color: #FFF;*/
 }
 .reorderListDemo li a
 {
     color: #FFF !important;
     font-weight: bold;
 }
 .reorderCue
 {
     border: dashed thin black;
     width: 100%;
     height: 25px;
 }
 .itemArea
 {
     margin-left: 15px;
     font-family: Arial, Verdana, sans-serif;
     font-size: 1em;
     text-align: left;
 }
 .reorderListDemoTall li
 {
     list-style: none;
     margin: 2px;
     background-color: Blue;
     color: #FFF;
 }
 .itemAreaTall
 {
     margin-left: 15px;
     font-family: Arial, Verdana, sans-serif;
     font-size: 1em;
     text-align: left;
     width: 800px;
     height: 185px;
     margin-top: 15px;
 }
 .reorderCueTall
 {
     border: dashed thin black;
     width: 100%;
     height: 200px;
     margin-bottom: 30px;
 }
 #sizeImage img
 {
     width: 200px;
     height: 100px;
 }
  </style>


   
   <div id="divQuestionViewList" style="display: block;" runat="Server">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="bandHeaderRow" colspan="4" align="left">
                    Administrator :: Cause Code Information
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 10%">
                    &nbsp;
                </td>
                <td colspan="2" align="center">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr align="left">
                            <td>
                                <asp:LinkButton runat="server" ID="lnkAdd_New" Text="Add New" OnClick="lnkAddNew_Click"></asp:LinkButton>
                         
                         
                                 <div style="margin-top:20px;margin-left:20px;float:right;" >
                                <asp:Button runat="server" ID="btnSortQuestions" Text="Sort Questions" OnClick="btnSortQuestions_Click" ></asp:Button>
                            </div>
                           </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:GridView ID="gvQuestion" AllowPaging="true" PageSize="20" runat="server" Width="100%"
                                    AutoGenerateColumns="false" OnPageIndexChanging="gvQuestion_PageIndexChanging"
                                    OnRowCreated="gvQuestion_RowCreated" OnRowEditing="gvQuestion_RowEditing" OnRowCommand="gvQuestion_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Focus Area">
                                            <ItemStyle Width="15%" />
                                            <ItemTemplate>
                                                <%# Eval("Focus_Area") %>
                                                <asp:HiddenField runat="Server" ID="hdnInspectionQuestionID" Value='<%# Eval("PK_LU_Cause_Code_Information") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sort Order">
                                            <ItemStyle Width="10%" />
                                            <ItemTemplate>
                                                <%#Eval("Sort_Order") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Question">
                                            <ItemStyle Width="20%" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkView" Text='<%#Eval("Question") %>' CommandName="View"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Guidline">
                                            <ItemStyle Width="45%" />
                                            <ItemTemplate>
                                                <%#Eval("Guidance")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Reference">
                                            <ItemStyle Width="45%" />
                                            <ItemTemplate>
                                                <%#Eval("Reference")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Active">
                                            <ItemStyle Width="45%" />
                                            <ItemTemplate>
                                                <%#Eval("Active")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkEdit" Text="Edit" CommandName="Edit"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remove">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkRemove" Text="Remove" CommandName="Remove"
                                                    OnClientClick="return confirm('Are you sure to delete?');"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <table cellpadding="4" cellspacing="0" width="100%">
                                            <tr>
                                                <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                    <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 10%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="divViewQuestion" style="display: none;" runat="server">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="bandHeaderRow" colspan="4" align="left">
                    Administrator :: Inspection Questions
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr runat="server" id="tr1" style="display: block;">
                <td style="width: 20%">
                    &nbsp;
                </td>
                <td colspan="2">
                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                        <tr>
                            <td style="width: 18%" align="left">
                                Focus Area
                            </td>
                            <td style="width: 4%" align="center">
                                :
                            </td>
                            <td colspan="4" align="left">
                                <asp:Label runat="server" ID="lblFocusArea"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">
                                Sort Order
                            </td>
                            <td valign="top" align="center">
                                :
                            </td>
                            <td colspan="4" align="left">
                                <asp:Label runat="server" ID="lblSortOrder"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">
                                Question
                            </td>
                            <td valign="top" align="center">
                                :
                            </td>
                            <td colspan="4" align="left">
                                <uc:ctrlMultiLineTextBox runat="server" ID="lblQuestion" ControlType="Label"
                                    Width="450" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">
                                Guidance
                            </td>
                            <td valign="top" align="center">
                                :
                            </td>
                            <td colspan="4" align="left">
                                <uc:ctrlMultiLineTextBox runat="server" ID="lblGuidance" ControlType="Label"
                                    Width="450" />
                            </td>
                        </tr>
                         <tr>
                            <td valign="top" align="left">
                                Reference
                            </td>
                            <td valign="top" align="center">
                                :
                            </td>
                            <td colspan="4" align="left">
                                <uc:ctrlMultiLineTextBox runat="server" ID="lblReference" ControlType="Label"
                                    Width="450" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">
                              Active
                            </td>
                            <td valign="top" align="center">
                                :
                            </td>
                            <td colspan="4" align="left">
                                <asp:Label ID="lblActive" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 20%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <table cellpadding="5" cellspacing="5" border="0" width="100%">
        <tr>
            <td style="width: 25%">
                &nbsp;
            </td>
            <td align="right">
                <asp:Button ID="btnSave" runat="server" Text="Save" CausesValidation="true" ValidationGroup="vsErrorGroup"
                    OnClick="btnSave_Click" />
            </td>
            <td style="width: 2%">
                &nbsp;
            </td>
            <td align="left">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
                    OnClick="btnCancel_Click" />
            </td>
            <td style="width: 25%">
                &nbsp;
            </td>
        </tr>
    </table>
    <div id="divCauseCodeInformation_Main" runat="server" >
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                    <div style="width: 850px;display: none;" runat="server" id="divMain">
                        <div  id="divCauseCodeInformation" class="reorderListDemo" style="padding-bottom: 50px;" runat="server">
                            <div style="margin-top:20px;margin-left:20px;">
                                <asp:LinkButton runat="server" ID="lnkAddNew" Text="Add New" OnClick="lnkAddNew_Click"></asp:LinkButton>
                            </div>
                          <asp:Repeater runat="server" ID="rptFocusArea" OnItemDataBound="rptFocusArea_ItemDataBound">
                               <ItemTemplate>
                                   
                            <asp:Panel runat="server" id="pnlFocusArea" style="display:block;margin-left:80px;" OnRowCommand="gvFocusArea_RowCommand">
                               <%-- <asp:GridView runat="server" Width="100%" ID="gvFocusArea" style="margin-left:80px;" OnRowCommand="gvFocusArea_RowCommand" >--%>
                                      <%--   <asp:TemplateField>
                                            <ItemStyle BackColor="#276692" Font-Bold="true"  Height="15" Width="15" ForeColor="White" />
                                            <ItemTemplate>--%>
                                <table cellpadding="0" style="margin-left:150px;">
                                 
                                    <tr style="background-color:rgb(234,234,234);font-weight:bold;width:100%;height:20px;">
                                        <td  style="background-color:rgb(234,234,234);font-weight:bold;width:15px;">
                                             <asp:ImageButton  OnClick="imagePlus_Click" ID="imagePlus" ImageUrl="~/Images/plus.png" runat="server" Height="15" Width="15" CommandName="image" CommandArgument='<%# Eval("Master_Order") %>' style="background-color:rgb(234,234,234);font-weight:bold;"/>
                                            </td>
                                                <%--<asp:HiddenField runat="Server" ID="hdnMaster_Order" Value='<%# Eval("Master_Order") %>' />--%>
                                          <%--  </ItemTemplate>--%>
                                        <%--/asp:TemplateField>
                                        <asp:TemplateField HeaderText="Focus Area">
                                            <ItemStyle BackColor="#276692" Font-Bold="true"/>
                                            <ItemTemplate>
                                               --%>
                                        <td style="background-color:rgb(234,234,234);font-weight:bold;width:500px;">
                                            <asp:Label ID="Order" runat="server" Text=' <%#Eval("Focus_Area") %>' ForeColor="Black" style="background-color:rgb(234,234,234);"></asp:Label>
                                            </td>   
                                          <%--  </ItemTemplate>
                                        </asp:TemplateField>
                                           </Columns>--%>
                                       <%--   <EmptyDataTemplate>
                                        <table cellpadding="4" cellspacing="0" width="100%">
                                            <tr>
                                                <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                    <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>--%>
                               <%-- <table style="margin-left:100px;width:500px;">
                                    <tr style="background-color:rgb(39, 102, 146);color:white;font-weight:bold;">
                                        <td style="width:15px;">
                                            <asp:Image runat="server" ID="imgPlus" ImageUrl="~/Images/plus.png" Height="15" Width="15" />
                                        </td>
                                        <td>
                                           <asp:Label ID="Label1" runat="server" Text="Focus Area" ></asp:Label>
                                          <asp:Label ID="Order" runat="server" Text='<%# Eval("Focus_Area") %>' ></asp:Label>
                                        </td>
                                    </tr>
                                </table>--%>
                                  
                             <%-- </asp:GridView>--%>
                                        </tr>
                                    </table>
                            </asp:Panel>

                            <asp:Panel runat="server" ID="pnlQuestions" style="margin-left:80px;">
                            <ajaxToolkit:ReorderList ID="rlItemList"  DragHandleAlignment="Left" PostBackOnReorder="true" CallbackCssStyle="callbackStyle"  ItemInsertLocation="End" 
                                  ShowInsertItem="false"  runat="server" OnItemReorder="rlItemList_ItemReorder">
                            
                                <DragHandleTemplate>
                                    <div class="dragHandle">
                                        <asp:Label ID="lbl" runat="server" Text="Drag me"></asp:Label>
                                    </div>
                                </DragHandleTemplate>
                                
                                <ItemTemplate>
                                    <div class="itemArea">
                                        <span style="float: right">
                                            <asp:LinkButton Width="50" ID="lnkEdit"  CommandName="edit"  runat="server" Text="Edit" />
                                        </span>
                                        <table style="margin-left:100px;width:500px;">
                                            <tr>
                                                <td>
                                        <asp:Label ID="lblPKLUCauseCodeInformation" Visible="false" runat="server"  Text='<%# Eval("PK_LU_Cause_Code_Information") %>'></asp:Label> 
                                       <%-- <asp:Label ID="Order" runat="server" Text='<%# Eval("Focus_Area") %>' ></asp:Label>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Sort_Order") %>'></asp:Label>--%>
                                        <asp:Label ID="Name" runat="server" Text='<%# Eval("Question") %>'></asp:Label> 
                                        <%--<asp:Label ID="Label1" runat="server" Text='<%# Eval("Guidance") %>'></asp:Label>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Active") %>'></asp:Label>--%>
                                                    </td>
                                                 </tr>
                                        </table>
                                    </div>
                                </ItemTemplate>
                                <ReorderTemplate>
                                    <asp:Panel ID="Panel2" runat="server"  CssClass="reorderCue" />
                                </ReorderTemplate>
                            </ajaxToolkit:ReorderList>
                             </asp:Panel>
                               <ajaxToolkit:CollapsiblePanelExtender ID="cpe" runat="server" TargetControlID="pnlQuestions" CollapsedSize="0" ExpandedSize="300" Collapsed="True"
                                ExpandControlID="pnlFocusArea" CollapseControlID="pnlFocusArea" AutoCollapse="False" AutoExpand="False" ScrollContents="True" TextLabelID="Order" 
                                 ImageControlID="Image1" ExpandDirection="Vertical">
                                  </ajaxToolkit:CollapsiblePanelExtender> 
                              </ItemTemplate>
                              </asp:Repeater>
                        </div>
                    </div>
               
                   <%-- <div>
                        <asp:TextBox ID="tbItemName" runat="server"></asp:TextBox>
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TBWE1"   runat="server" TargetControlID="tbItemName"  WatermarkText="Name"  WatermarkCssClass="watermarkTextBox" />
                    </div>
                    <div>
                        <asp:TextBox Rows="4" ID="tbItemDescription" runat="server" Height="51px"  TextMode="MultiLine"></asp:TextBox> 
                          
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TBWE2" runat="server" TargetControlID="tbItemDescription"  WatermarkText="Description" 
                          WatermarkCssClass="watermarkTextBox" />
                          
                    </div>--%>
                    <div>
                        <asp:Button ID="btnAddReorderListItem" runat="server" Text="Add"/>
                    </div>

                  <div id="divAddNewQuestion" style="display: none;" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="bandHeaderRow" colspan="4" align="left">
                    Administrator :: Cause Code Information
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr runat="server" id="trGroupAdd" style="display: block;">
                <td style="width: 20%">
                    &nbsp;
                </td>
                <td colspan="2">
                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                        <tr>
                            <td style="width: 18%" align="left">
                                Focus Area<span style="color: Red;">*</span>
                            </td>
                            <td style="width: 4%" align="center">
                                :
                            </td>
                            <td colspan="4" align="left">
                                <asp:TextBox runat="server" ID="txtFocusArea" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvFocusArea" ControlToValidate="txtFocusArea" Display="None"
                                    runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Focus Area"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">
                                Sort Order<span style="color: Red;">*</span>
                            </td>
                            <td valign="top" align="center">
                                :
                            </td>
                            <td colspan="4" align="left">
                                <asp:TextBox runat="server" ID="txtSortOrder"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtSortOrder" ControlToValidate="txtSortOrder"
                                    Display="None" runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup"
                                    ErrorMessage="Please Enter Sort Order"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">
                                Question <span style="color: Red;">*</span>
                            </td>
                            <td valign="top" align="center">
                                :
                            </td>
                            <td colspan="4" align="left">
                                <uc:ctrlMultiLineTextBox runat="server" ID="txtQuestion" ControlType="TextBox"
                                    MaxLength="500" Width="450" IsRequired="true" ValidationGroup="vsErrorGroup"
                                    RequiredFieldMessage="Please Enter Question" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">
                                Guidance<span style="color: Red;">*</span>
                            </td>
                            <td valign="top" align="center">
                                :
                            </td>
                            <td colspan="4" align="left">
                                <uc:ctrlMultiLineTextBox runat="server" ID="txtGuidance" ControlType="TextBox"
                                    MaxLength="500" Width="450" IsRequired="true" ValidationGroup="vsErrorGroup"
                                    RequiredFieldMessage="Please Enter txtGuidance for the Question" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">
                                Reference<span style="color: Red;">*</span>
                            </td>
                            <td valign="top" align="center">
                                :
                            </td>
                            <td colspan="4" align="left">
                                <uc:ctrlMultiLineTextBox runat="server" ID="txtReference" ControlType="TextBox"
                                    MaxLength="500" Width="450" IsRequired="true" ValidationGroup="vsErrorGroup"
                                    RequiredFieldMessage="Please Enter Reference for the Question" />
                            </td>
                        </tr>
                        <tr><td></td></tr>
                        <tr>
                            <td valign="top" align="left">
                                Active
                            </td>
                            <td valign="top" align="center">
                                :
                            </td>
                            <td colspan="4" align="left">
                                <asp:RadioButtonList ID="rdoActive" runat="server" SkinID="YesNoType" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 20%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        
    </div>

   
   
</asp:Content>

