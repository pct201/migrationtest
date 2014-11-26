<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PolicyAuditPopUp.aspx.cs"
    Inherits="Policy_PolicyAuditPopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: Audit Trail</title>

    <script language="javascript" type="text/javascript">
    function showAudit(divHeader,divGrid)
    {        
        var divheight,i;
       
        divHeader.style.width = window.screen.availWidth - 225 + "px";
        divGrid.style.width = window.screen.availWidth - 225 + "px";
        
        divheight = divGrid.style.height;        
        i = divheight.indexOf('px');        
        
        if(i > -1)        
            divheight = divheight.substring(0,i);
        if (divheight > (window.screen.availHeight - 350) && divGrid.style.height != "")
        {            
            divGrid.style.height = window.screen.availHeight - 350;
        }
    }
    
    function ChangeScrollBar(f,s)
    {
        s.scrollTop = f.scrollTop;
        s.scrollLeft = f.scrollLeft;
    }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" align="left">
                <tr>
                    <td align="left">
                        <asp:Label ID="lbltable_Name" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                    <td align="right">
                        <a href="javascript:window.close();">Close Window</a>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div style="overflow: hidden; width: 600px;" id="divPolicy_Header" runat="server">
                            <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                                <tbody>
                                    <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                        align="left">
                                        <td class="cols">
                                            <span style="display: inline-block; width: 110px">Audit_DateTime</span>
                                        </td>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 115px">PK_Policy_Id</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 115px">FK_Policy_Type</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 150px">Policy_Number</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 150px">Carrier</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 150px">Underwriter</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 115px">Policy_Begin_Date</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 145px">Policy_Expiration_Date</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 115px">Policy_Year</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 115px">Location</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 115px">Annual_Premium</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 125px">Surplus_Lines_Fees</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 115px">Deductible</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 125px">Deductible_Amount</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 115px">Coverage_Form</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 145px">Per_Occurrence_Limit</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 115px">Aggregate_Limit</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 115px">Layered_Program</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 115px">FK_Layer</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 115px">Underlying_Limit</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 115px">Quota_Share</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 115px">Share_Precentage</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 115px">Share_Limit</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 115px">Retroactive</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 115px">Program</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 150px">TPA</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 115px">Store_Deductible</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 175px">Financial_Security_Required</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 175px">FK_Financial_Security_Type</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 250px">Policy_Notes</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 115px">Original_Amount</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 150px">Original_Amount_Date</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">Change_Amount_1</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 170px">Change_Amount_1_Date</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">Change_Amount_2</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 170px">Change_Amount_2_Date</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">Change_Amount_3</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 170px">Change_Amount_3_Date</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">Change_Amount_4</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 170px">Change_Amount_4_Date</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 115px">Updated_By</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 137px">Update_Date</span>
                                        </th>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div style="overflow: scroll; width: 600px; height: 425px;" id="divPolicy_Grid" runat="server">
                            <asp:GridView ID="gvPolicy" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                EnableTheming="true" EmptyDataText="No records found!" ShowHeader="false">
                                <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%#Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                                ToolTip='<%#Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                                Width="110px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="PK_Policy_Id" runat="server" Text='<%#Eval("PK_Policy_Id")%>' Width="115px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Policy_Type" runat="server" Text='<%#Eval("Policy_Type")%>' Width="115px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Policy_Number" runat="server" Text='<%#Eval("Policy_Number")%>' Width="150px" CssClass="TextClip"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Carrier" runat="server" Text='<%#Eval("Carrier")%>' Width="150px"  CssClass="TextClip"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Underwriter" runat="server" Text='<%#Eval("Underwriter")%>' Width="150px" CssClass="TextClip"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Policy_Begin_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Policy_Begin_Date"))%>'
                                                Width="115px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Policy_Expiration_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Policy_Expiration_Date"))%>'
                                                Width="145px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Policy_Year" runat="server" Text='<%#Eval("Policy_Year")%>' Width="115px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Location" runat="server" Text='<%#Eval("Location")%>' Width="115px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Annual_Premium" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Annual_Premium"))%>'
                                                Width="115px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Surplus_Lines_Fees" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Surplus_Lines_Fees"))%>'
                                                Width="125px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Deductible" runat="server" Text='<%# (Eval("Deductible").ToString() == "") ? "" : (Eval("Deductible").ToString() == "Y") ? "Yes" : "No"%>'
                                                Width="115px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Deductible_Amount" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Deductible_Amount"))%>'
                                                Width="125px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Coverage_Form" runat="server" Text='<%# Eval("Coverage_Form").ToString() == "O" ? "Occurence" : Eval("Coverage_Form").ToString() == "C" ? "Claims Made" : ""%>' Width="115px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Per_Occurrence_Limit" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Per_Occurrence_Limit"))%>'
                                                Width="145px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Aggregate_Limit" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Aggregate_Limit"))%>'
                                                Width="115px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Layered_Program" runat="server" Text='<%# (Eval("Layered_Program").ToString() == "") ? "" : (Eval("Layered_Program").ToString() == "Y") ? "Yes" : "No"%>'
                                                Width="115px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Layer" runat="server" Text='<%#Eval("Layer")%>' Width="115px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Underlying_Limit" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Underlying_Limit"))%>'
                                                Width="115px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Quota_Share" runat="server" Text='<%# (Eval("Quota_Share").ToString() == "") ? "" : (Eval("Quota_Share").ToString() == "Y") ? "Yes" : "No"%>'
                                                Width="115px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Share_Precentage" runat="server" Text='<%#Eval("Share_Precentage")%>'
                                                Width="115px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Share_Limit" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Share_Limit"))%>' Width="115px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Retroactive" runat="server" Text='<%# (Eval("Retroactive").ToString() == "") ? "" : (Eval("Retroactive").ToString() == "Y") ? "Yes" : "No"%>'
                                                Width="115px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Program" runat="server" Text='<%#Eval("Program")%>'
                                                Width="115px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="TPA" runat="server" Text='<%#Eval("TPA")%>'  CssClass="TextClip"
                                                Width="150px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Store_Deductible" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Store_Deductible"))%>'
                                                Width="115px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Financial_Security_Required" runat="server" Text='<%# (Eval("Financial_Security_Required").ToString() == "") ? "" : (Eval("Financial_Security_Required").ToString() == "Y") ? "Yes" : "No"%>'
                                                Width="175px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="FK_Financial_Security_Type" runat="server" Text='<%# (Eval("FK_Financial_Security_Type").ToString() == "0" ? "" : Eval("FK_Financial_Security_Type").ToString() == "1" ? "LOC" : Eval("FK_Financial_Security_Type").ToString() == "2" ? "Cash" : Eval("FK_Financial_Security_Type").ToString() == "3" ? "Other" : "")%>'
                                                Width="175px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Policy_Notes" runat="server" Text='<%#Eval("Policy_Notes")%>'
                                                Width="250px" CssClass="TextClip"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Original_Amount" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Original_Amount"))%>'
                                                Width="115px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Original_Amount_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Original_Amount_Date"))%>'
                                                Width="150px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Change_Amount_1" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Change_Amount_1"))%>'
                                                Width="120px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Change_Amount_1_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Change_Amount_1_Date"))%>'
                                                Width="170px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Change_Amount_2" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Change_Amount_2"))%>'
                                                Width="120px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Change_Amount_2_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Change_Amount_2_Date"))%>'
                                                Width="170px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Change_Amount_3" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Change_Amount_3"))%>'
                                                Width="120px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Change_Amount_3_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Change_Amount_3_Date"))%>'
                                                Width="170px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Change_Amount_4" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Change_Amount_4"))%>'
                                                Width="120px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Change_Amount_4_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Change_Amount_4_Date"))%>'
                                                Width="170px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Updated_By" runat="server" Text='<%#Eval("USER_NAME")%>' Width="115px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Update_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Update_Date"))%>'
                                                Width="115px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
