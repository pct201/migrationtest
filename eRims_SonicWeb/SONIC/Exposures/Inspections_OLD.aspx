<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Inspections_OLD.aspx.cs" Inherits="Exposures_Inspections" Title="Exposures :: Inspection" %>

<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/ExposureInfo/ExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <asp:ValidationSummary ID="valInspection" runat="server" ValidationGroup="vsInspection" ShowMessageBox="true" ShowSummary="false"
HeaderText="Verify the following fields" BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />

    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom" colspan="2">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td>
                 <asp:UpdatePanel runat="server" ID="updtOtherInspections">
                 <contenttemplate>
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td class="Spacer" width="100%" style="height: 15px;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="2">
                            <uc:ctrlExposureInfo ID="ucCtrlExposureInfo" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 5px;" colspan="2" width="100%">
                        </td>
                    </tr>
                    <tr>
                    <td>
                        <asp:UpdateProgress runat="server" ID="upProgress" DisplayAfter="100">
                        <ProgressTemplate>
                            <div class="UpdatePanelloading" id="divProgress" style="width: 100%;">
                                <table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%;height:100%;">
                                <tr align="center" valign="middle">
                                    <td class="LoadingText" align="center" valign="middle">
                                        <img src="../../Images/indicator.gif" alt="Loading" />&nbsp;&nbsp;&nbsp;Please Wait..
                                    </td>
                                </tr>
                                </table>
                            </div>
                        </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gvOtherInspections" runat="server" AutoGenerateColumns="false" OnRowCommand="gvOtherInspections_RowCommand" Width="98%" 
                            EmptyDataText="No Inspection Record Found" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvOtherInspections_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="">
                                        <ItemStyle Width="10%" HorizontalAlign="left"  />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkViewDetails" runat="server" CommandArgument='<%# Eval("PK_Inspection_ID")%>' CommandName="ViewDetails" Text='<%# Container.DataItemIndex + 1 %>' />
                                        </ItemTemplate>                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Inspection Date" HeaderStyle-HorizontalAlign="left">
                                        <ItemStyle Width="30%" HorizontalAlign="left" />
                                        <ItemTemplate>
                                            <%# Eval("date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("date"))) : string.Empty %>                                        
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Inspector Name" HeaderStyle-HorizontalAlign="left">
                                        <ItemStyle Width="50%" HorizontalAlign="left" />
                                        <ItemTemplate>
                                            <%# Eval("Inspector_Name")%>
                                        </ItemTemplate>                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemStyle Width="10%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%# Eval("PK_Inspection_ID")%>' CommandName="RemoveInspection" Text='Remove' OnClientClick="return confirm('Are you sure to delete?');" />
                                        </ItemTemplate>                                        
                                    </asp:TemplateField>
                                </Columns>                                
                            </asp:GridView>                            
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 5px;" colspan="2" width="100%">
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="left">&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lnkAddNew" runat="server" Text="Add New" OnClick="lnkAddNew_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height:5px;" colspan="2" width="100%">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="100%">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td style="width: 100%" valign="top" class="dvContainer">
                                        <div id="dvEdit" runat="server" style="width: 100%;">
                                            <asp:Panel ID="pnlInspections" runat="server" Width="100%">
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" width="15%">
                                                                Inspection Date
                                                            </td>
                                                            <td align="center" width="4%">
                                                                :
                                                            </td>
                                                            <td align="left" width="31%">
                                                                <asp:TextBox runat="server" ID="txtDate" Width="170px" SkinID="txtDate"></asp:TextBox>
                                                                <img alt="Date Opened" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif" align="middle" /><br />                                                                 
                                                                <asp:RangeValidator ID="revDate" ControlToValidate="txtDate" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" 
                                                                  ErrorMessage="Inspection Date is not valid." runat="server" SetFocusOnError="true" ValidationGroup="vsInspection" Display="none" />
                                                            </td>                                                            
                                                            <td align="left" width="15%">
                                                                Inspector Name
                                                            </td>
                                                            <td align="center" width="4%">
                                                                :
                                                            </td>
                                                            <td align="left" width="31%">
                                                                <asp:TextBox ID="txtInspectorName" runat="server" MaxLength="50" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" >
                                                                 <b>Focus Area</b>
                                                            </td>
                                                            <td align="center">
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                 <b>Question Text</b>
                                                            </td>
                                                            <td align="left">
                                                               &nbsp;
                                                            </td>
                                                            <td align="center">
                                                                &nbsp;
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="lblTmp" runat="server" Width="46px">&nbsp;</asp:Label>                                        
                                                               <b>Deficiency Noted</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="6">
                                                                <asp:GridView ID="gvInspectionEdit" runat="server" Width="100%" ShowHeader="false" AutoGenerateColumns="false" DataKeyNames="PK_Inspection_Questions_ID" 
                                                                SkinID="Default" OnRowDataBound="gvInspectionEdit_OnRowDataBound">
                                                                    <Columns>
                                                                        <asp:TemplateField>
                                                                            <ItemStyle Width="19%" VerticalAlign="top"/>
                                                                            <ItemTemplate>
                                                                                <%#Eval("Item_Number_Focus_Area")%>
                                                                                <input type="hidden" id="hdnResponseID" runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <ItemStyle Width="81%" VerticalAlign="top" />
                                                                            <ItemTemplate>
                                                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                                                    <tr>
                                                                                        <td width="100%">
                                                                                            <table cellpadding="2" cellspacing="1" width="100%">
                                                                                                <tr>
                                                                                                    <td width="3%" align="left">
                                                                                                        <%#Eval("Question_Number")%>
                                                                                                    </td>
                                                                                                    <td width="75%" align="left">
                                                                                                        <%#Eval("Question_Text")%>
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:RadioButtonList ID="rdoDefeciancy" runat="server" SkinID="YesNoType" Width="100px" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left"><img id="imgGuidance" runat="server" src="../../Images/plus.jpg" style="cursor:pointer;" /></td>
                                                                                                    <td colspan="2">Guidance</td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">&nbsp;</td>
                                                                                                    <td colspan="2">
                                                                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                                                                            <tr>
                                                                                                                <td width="100%" id="tdGuidanceText" runat="server" >
                                                                                                                    <%#Eval("Guidance_Text")%>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td width="100%" id="tdResponseDetails" runat="server" style="display:none;">
                                                                                                                    <table cellpadding="3" cellspacing="1" width="100%">
                                                                                                                        <tr>
                                                                                                                            <td width="18%" align="left" valign="top">Department</td>
                                                                                                                            <td width="4%" align="center" valign="top">:</td>
                                                                                                                            <td align="left" valign="top" colspan="4">
                                                                                                                                <%--<asp:DropDownList ID="drpDepartment" runat="server" Width="170px" EnableViewState="false" />--%>
                                                                                                                                <asp:CheckBoxList ID="chkDepartments" runat="server" Width="100%" RepeatColumns="3"  />
                                                                                                                            </td>                                                                                                                            
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td align="left">Date opened</td>
                                                                                                                            <td align="center">:</td>
                                                                                                                            <td align="left">
                                                                                                                                <asp:TextBox ID="txtDateOpened" runat="server" Width="140px"  SkinID="txtDate"></asp:TextBox>
                                                                                                                                <img id="imgDateOpened" runat="server" alt="Date Opened" 
                                                                                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif" align="middle" /><br />                                                                                                                                    
                                                                                                                                <asp:RangeValidator ID="revDateOpened" ControlToValidate="txtDateOpened" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" 
                                                                                                                                ErrorMessage='<%# "Focus area [" + Eval("Item_Number_Focus_Area") + "], Question [" + Eval("Question_Number") + "] Date Opened is not valid." %>' runat="server" SetFocusOnError="true" ValidationGroup="vsInspection" Display="none" />
                                                                                                                            </td>
                                                                                                                            <td align="left" width="18%">Days Open</td>
                                                                                                                            <td align="center" width="4%">:</td>
                                                                                                                            <td align="left" width="28%"><asp:Label ID="lblDays" runat="server" /></td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td align="left" colspan="6">Recommended Action:</td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td colspan="6">
                                                                                                                                <uc:ctrlMultiLineTextBox ID="txtAction" runat="server"  MaxLength="4000"/>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td align="left">Target Completion Date</td>
                                                                                                                            <td align="center">:</td>
                                                                                                                            <td align="left">
                                                                                                                                <asp:TextBox ID="txtTargetCompleteDate" runat="server" Width="140px"  SkinID="txtDate"></asp:TextBox>
                                                                                                                                <img id="imgTargetCompletionDate" runat="server" alt="Target Completion Date" onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif" align="middle" /><br />                                                                                                                                    
                                                                                                                                 <asp:RangeValidator ID="regTargetCompleteDate" ControlToValidate="txtTargetCompleteDate" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" 
                                                                                                                                    ErrorMessage='<%# "Focus area [" + Eval("Item_Number_Focus_Area") + "], Question [" + Eval("Question_Number") + "] Target Complete Date is not valid."%>' runat="server" SetFocusOnError="true" ValidationGroup="vsInspection" Display="none" />
                                                                                                                            </td>
                                                                                                                            <td align="left">Actual Completion Date</td>
                                                                                                                            <td align="center">:</td>
                                                                                                                            <td align="left">
                                                                                                                                <asp:TextBox ID="txtActualCompletionDate" runat="server" Width="140px" SkinID="txtDate"></asp:TextBox>
                                                                                                                                <img id="imgActualCompletionDate" runat="server" alt="Actual Completion Date" onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                                                                                <asp:RangeValidator ID="regActualCompletionDate" ControlToValidate="txtActualCompletionDate" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" 
                                                                                                                                    ErrorMessage='<%# "Focus area [" + Eval("Item_Number_Focus_Area") + "], Question [" + Eval("Question_Number") + "] Actual Completion Date is not valid."%>' runat="server" SetFocusOnError="true" ValidationGroup="vsInspection" Display="none" />                                                                                                                                    
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td align="left" colspan="6">Notes:</td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td colspan="6">
                                                                                                                                <uc:ctrlMultiLineTextBox ID="txtNotes" runat="server" MaxLength="4000"/>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                        
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>                                                                                                                                        
                                                                                        </td>
                                                                                    </tr>                                                                                                                                                
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>                                                
                                                                    </Columns>                                                                                                                
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="6">
                                                                <asp:Button ID="btnSaveAndNext" runat="server" Text="Save" OnClick="btnSave_Click" CausesValidation="true" ValidationGroup="vsInspection"  />                                                                     
                                                            </td>
                                                        </tr>                               
                                                    </table>                                                
                                            </asp:Panel>
                                        </div>
                                        <div id="dvView" runat="server" style="display: none;">
                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="15%">
                                                            Inspection Date
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="31%">
                                                            <asp:Label runat="server" ID="lblDate" Width="170px"></asp:Label>                                        
                                                        </td>
                                                        <td align="left" width="15%">
                                                            Inspector Name
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="31%">
                                                            <asp:Label runat="server" ID="lblInspectorName" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" >
                                                             <b>Focus Area</b>
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                             <b>Question Text</b>
                                                        </td>
                                                        <td align="left">
                                                           &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="Label1" runat="server" Width="32px">&nbsp;</asp:Label>                                        
                                                           <b>Deficiency Noted</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="6">
                                                            <asp:GridView ID="gvInspectionView" runat="server" Width="100%" ShowHeader="false" AutoGenerateColumns="false" 
                                                            SkinID="Default" OnRowDataBound="gvInspectionView_OnRowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="19%" VerticalAlign="top"/>
                                                                        <ItemTemplate><%#Eval("Item_Number_Focus_Area")%></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="81%" VerticalAlign="top" />
                                                                        <ItemTemplate>
                                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td width="100%">
                                                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                                                            <tr>
                                                                                                <td width="3%" align="left">
                                                                                                    <%#Eval("Question_Number")%>
                                                                                                </td>
                                                                                                <td width="75%" align="left">
                                                                                                    <%#Eval("Question_Text")%>
                                                                                                </td>
                                                                                                <td align="left">
                                                                                                    <%# Convert.ToString(Eval("Deficiency_Noted")) == "Y" ? "YES" : "NO" %>                                                                                
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr><td colspan="3" class="Spacer" style="height:5px;"></td></tr>
                                                                                            <tr>
                                                                                                <td align="left"><img id="imgGuidance" runat="server" src="../../Images/plus.jpg" style="cursor:pointer;" /></td>
                                                                                                <td colspan="2">Guidance</td>
                                                                                            </tr>
                                                                                            <tr><td colspan="3" class="Spacer" style="height:5px;"></td></tr>
                                                                                            <tr>
                                                                                                <td align="left">&nbsp;</td>
                                                                                                <td colspan="2">
                                                                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                                                                        <tr>
                                                                                                            <td width="100%" id="tdGuidanceText" runat="server" >
                                                                                                                <%#Eval("Guidance_Text")%>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr><td class="Spacer" style="height:5px;"></td></tr>
                                                                                                        <tr>
                                                                                                            <td width="100%" id="tdResponseDetails" style='display:<%# Convert.ToString(Eval("Deficiency_Noted")) == "Y" ? "block" : "none" %>;'>
                                                                                                                <table cellpadding="3" cellspacing="1" width="100%">
                                                                                                                    <tr>
                                                                                                                        <td width="18%" align="left" valign="top">Department</td>
                                                                                                                        <td width="4%" align="center" valign="top">:</td>
                                                                                                                        <td align="left" valign="top" colspan="4">
                                                                                                                            <%--<%# Eval("Department")%>    --%>
                                                                                                                            <asp:DataList ID="rptDepartment" runat="server" Width="100%" RepeatColumns="3">
                                                                                                                                <ItemTemplate>
                                                                                                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                                                                                                        <tr>
                                                                                                                                            <td width="60%" align="left">
                                                                                                                                                <%# Eval("Description") %>
                                                                                                                                                <input type="hidden" id="hdnDeptID" runat="server" value='<%#Eval("PK_LU_Department_ID") %>' />
                                                                                                                                            </td>
                                                                                                                                            <td align="left">
                                                                                                                                                <asp:Label ID="lblValue" runat="server" />
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                    </table>
                                                                                                                                </ItemTemplate>
                                                                                                                            </asp:DataList>                                                                                                                        
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left">Date opened</td>
                                                                                                                        <td align="center">:</td>
                                                                                                                        <td align="left" width="28%">
                                                                                                                            <%# Eval("Date_Opened") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Opened"))) : string.Empty %>
                                                                                                                        </td>
                                                                                                                        <td align="left" width="18%">Days Open</td>
                                                                                                                        <td align="center" width="4%">:</td>
                                                                                                                        <td align="left" width="28%"><asp:Label ID="lblDays" runat="server" /></td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" colspan="6">Recommended Action:</td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td colspan="6">
                                                                                                                            <uc:ctrlMultiLineTextBox ID="lblAction" runat="server" ControlType="Label" Text='<%# Eval("Recommended_Action")%>'  />
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left">Target Completion Date</td>
                                                                                                                        <td align="center">:</td>
                                                                                                                        <td align="left">
                                                                                                                            <%# Eval("Target_Completion_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Target_Completion_Date"))) : string.Empty %>
                                                                                                                        </td>
                                                                                                                        <td align="left">Actual Completion Date</td>
                                                                                                                        <td align="center">:</td>
                                                                                                                        <td align="left">
                                                                                                                            <%# Eval("Actual_Completion_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Actual_Completion_Date"))) : string.Empty %>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" colspan="6">Notes:</td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td colspan="6">
                                                                                                                            <uc:ctrlMultiLineTextBox ID="lblNotes" runat="server" ControlType="Label" Text='<%# Eval("Notes")%>' />
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>                                                                                                                                        
                                                                                    </td>
                                                                                </tr>                                                                                
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>                                                
                                                                </Columns>         
                                                                <PagerTemplate>
                                                                    <span></span>
                                                                </PagerTemplate>                                   
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>  
                                                    <tr>
                                                        <td colspan="6" align="center">
                                                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                                                        </td>
                                                    </tr>                             
                                                </table>                                              
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>

    <script type="text/javascript">
    window.onscroll=getScrollHeight;
    //window.onload=getScrollHeight;
    //used to get height of scrollbar and add to total screen height +  scollbar height
    function getScrollHeight()
    {
       var h = window.pageYOffset ||
               document.body.scrollTop ||
               document.documentElement.scrollTop;
        document.getElementById('divProgress').style.height= screen.height + h;
        document.getElementById('ProgressTable').style.height= screen.height + h;
    }
    function ShowHideGuidanceText(imgID,tdTxtID)
    {
        var img = document.getElementById(imgID);
        var tdTxt = document.getElementById(tdTxtID);
        if(tdTxt.style.display == "none")
        {
            tdTxt.style.display = "block";
            img.src = "../../Images/minus.jpg";
        }
        else
        {
            tdTxt.style.display = "none";
            img.src = "../../Images/plus.jpg";
        }
    }
    
    function ShowHideDetails(rdoID,tdDtl)
    {
        var rdoYes = document.getElementById(rdoID + "_0");        
        if(rdoYes.checked)
        {
            tdDtl.style.display = "block";            
            ValidatorEnable(document.getElementById(rdoID.replace("rdoDefeciancy","revDateOpened")),true);
            ValidatorEnable(document.getElementById(rdoID.replace("rdoDefeciancy","regTargetCompleteDate")),true);
            ValidatorEnable(document.getElementById(rdoID.replace("rdoDefeciancy","regActualCompletionDate")),true);           
        }
        else
        {
            tdDtl.style.display = "none";            
            ValidatorEnable(document.getElementById(rdoID.replace("rdoDefeciancy","revDateOpened")),false);
            ValidatorEnable(document.getElementById(rdoID.replace("rdoDefeciancy","regTargetCompleteDate")),false);
            ValidatorEnable(document.getElementById(rdoID.replace("rdoDefeciancy","regActualCompletionDate")),false);           
        }
    }

    function ValidateDateOpened(ctrlIDs)
    {
        var arrCtrlIDs = ctrlIDs.split(',');
        
        var txtID = arrCtrlIDs[0];
        var lblID = arrCtrlIDs[1];
        var strDtOpen = document.getElementById(txtID).value;
        if(strDtOpen != "")
        {
            var today = new Date();
            var dtOpen = new Date(strDtOpen);
            if(dtOpen > today)
            {
                alert("Date Opened Can not be a future date");
                document.getElementById(txtID).value='';
                document.getElementById(txtID).focus();
                document.getElementById(lblID).innerHTML = '';
            }
            else
                CountDaysOpen(strDtOpen,lblID);
        }
        else
            document.getElementById(lblID).innerHTML = '';
    }

    function CountDaysOpen(strDtOpen,lblID)
    {
        //var strDtOpen = document.getElementById(txtID).value;
        
        if(strDtOpen != null && strDtOpen !="" && strDtOpen.indexOf("1753")== -1)
        {
            var today = new Date();
            var dtOpen = new Date(strDtOpen);
            var millennium =new Date(2000, 0, 1) //Month is 0-11 in JavaScript

            //Get 1 day in milliseconds
            var one_day=1000*60*60*24
            
            var days = Math.ceil((today.getTime()-dtOpen.getTime())/(one_day));
            days = days-1;
            document.getElementById(lblID).innerHTML = days > 0 ? days : '';

        }  
    }
    
    </script>

</asp:Content>
