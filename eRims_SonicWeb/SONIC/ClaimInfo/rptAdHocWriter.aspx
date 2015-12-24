<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptAdHocWriter.aspx.cs"
    Inherits="SONIC_ClaimInfo_rptAdHocWriter" Title="eRIMS Sonic :: Ad-Hoc Writer"
    Theme="default" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>

    <script language="javascript" type="text/javascript">
        //check Date Validation
        function CheckDate(sender, args) {
            args.IsValid = (ValidateDate(args.Value));
            return args.IsValid;
        }
    </script>

    <script language="javascript" type="text/javascript">

        function CheckReport() {
            if (document.getElementById('<%=ddlReports.ClientID%>').value == "0") {
                alert("Please select Saved Report to delete");
                return false;
            }
            else
                return confirm('Are you sure that you want to delete the selected report?')
        }

        function CheckList(nm, lblFrom, lblTo, txtTo, imgTo) {
            lst = document.getElementsByName(nm);
            var str = '';

            for (i = 0; i < lst.length; i++) {
                if (lst[i].value == 'O' && lst[i].checked) {
                    document.getElementById(lblFrom).innerText = 'On Date : ';
                }
                else if (lst[i].value == 'BF' && lst[i].checked) {
                    document.getElementById(lblFrom).innerText = 'Before Date : ';
                }
                else if (lst[i].value == 'A' && lst[i].checked) {
                    document.getElementById(lblFrom).innerText = 'After Date : ';
                }
                else if (lst[i].value == 'B' && lst[i].checked) {
                    document.getElementById(lblFrom).innerText = 'Start Date : ';
                    document.getElementById(lblTo).style.display = 'block';
                    document.getElementById(lblTo).innerText = 'End Date : ';
                    document.getElementById(txtTo).style.display = 'block';
                    document.getElementById(imgTo).style.display = 'block';
                }
                else if (lst[i].value == 'B' && !lst[i].checked) {
                    document.getElementById(lblTo).style.display = 'none';
                    document.getElementById(txtTo).style.display = 'none';
                    document.getElementById(imgTo).style.display = 'none';
                }
            }
        }

        function CheckALL(IsSelected, listID) {
            var ref = document.getElementById(listID);

            for (i = 0; i < ref.options.length; i++)
                ref.options[i].selected = IsSelected.checked;

        }
    </script>

    <script type="text/javascript" language="javascript">
        var First = -1;
        var Second = -1;
        var Third = -1;
        function ListFirst(ElementName, Index) {
            First = -1;
            First = Index;
            return Common(ElementName);
        }
        function ListSecond(ElementName, Index) {
            Second = -1;
            Second = Index;
            First = document.getElementById('ctl00_ContentPlaceHolder1_lstFirstSort').selectedIndex;
            if (First == -1) {
                alert("- Please Select in this order \n( First Level Sorting->Second Level Sorting->Third Level Sorting ).");
                document.getElementById(ElementName).selectedIndex = -1;
                Second = -1;
                return false;
            }
            return Common(ElementName);
        }
        function ListThird(ElementName, Index) {
            Third = -1;
            Third = Index;
            First = document.getElementById('ctl00_ContentPlaceHolder1_lstFirstSort').selectedIndex;
            Second = document.getElementById('ctl00_ContentPlaceHolder1_lstSecondSort').selectedIndex;
            if (Second == -1 || First == -1) {
                alert("- Please Select in this order \n( First Level Sorting->Second Level Sorting->Third Level Sorting ).");
                document.getElementById(ElementName).selectedIndex = -1;
                Third = -1;
                return false;
            }
            return Common(ElementName);

        }
        function Common(ElementName) {
            //alert(First);
            //alert(Second);
            //alert(Third);
            if ((First == Second || First == Third) && First != -1 && ElementName == '<%=lstFirstSort.ClientID %>') {

                alert("Please Select Different Values Three Level Sorting.");
                document.getElementById(ElementName).selectedIndex = -1;
                First = -1;
                return false;
            }
            else if ((Second == Third || Second == First) && Second != -1 && ElementName == '<%=lstSecondSort.ClientID %>') {
                alert("Please Select Different Values Three Level Sorting.");
                document.getElementById(ElementName).selectedIndex = -1;
                Second = -1;
                return false;
            }
            else if ((Third == First || Third == Second) && Third != -1 && ElementName == '<%=lstThirdSort.ClientID %>') {
                alert("Please Select Different Values Three Level Sorting.");
                document.getElementById(ElementName).selectedIndex = -1;
                Third = -1;
                return false;
            }

        return true;
    }
    function MoveItemUp() {
        var obj = document.getElementById('<%=lstOutputFields.ClientID %>');

        if (obj.selectedIndex > 0) {
            var newElem = document.createElement("option");
            newElem.text = obj.options[obj.selectedIndex].text;
            newElem.value = obj.options[obj.selectedIndex].value;
            obj.add(newElem, (obj.selectedIndex - 1));
            var selIndex = (obj.selectedIndex - 2);
            obj.remove(obj.selectedIndex);
            obj.selectedIndex = selIndex;
        }
        return false;
    }

    function MoveItemDown() {
        var obj = document.getElementById('<%=lstOutputFields.ClientID %>');

            if (obj.selectedIndex > -1) {
                if (obj.selectedIndex < obj.length - 1) {
                    var newElem = document.createElement("option");
                    newElem.text = obj.options[obj.selectedIndex].text;
                    newElem.value = obj.options[obj.selectedIndex].value;
                    obj.add(newElem, (obj.selectedIndex + 2));
                    obj.selectedIndex = (obj.selectedIndex + 2);
                    var selIndex = (obj.selectedIndex + 2);
                    obj.remove(obj.selectedIndex - 2);

                }
            }
            return false;
        }

    </script>

    <script type="text/javascript" language="javascript">
        var ErrMessage;
        function Validate(Type) {
            ErrMessage = "";
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtReportName").value == "") {
                if (Type != 'E')
                    ErrMessage = "- Please Enter Report Name.\n";
            }
            DateValidate("lstClaimOpened", "txtDate_Opened_From", "txtDate_Opened_To", "Date Claim Open", '<%=lblDateOpenedFrom.Text %>');
            DateValidate("lstClaimClosed", "txtDateClosedFrom", "txtDateClosedTo", "Date Claim Close", '<%=lblDateClosedFrom.Text %>');
            DateValidate("lstClaimIncident", "txtDate_Incident_From", "txtDate_Incident_To", "Date of Accident", '<%=lblDateIncidentFrom.Text %>');
            DateValidate("lstClaimValued", "txtDateValuedFrom", "txtDateValuedTo", "Valued as of Date", '<%=lblDateValuedFrom.Text %>');
            DateValidate("lstClaimReserve", "txtDate_Reserve_From", "txtDate_Reserve_To", "Reserve Date", '<%=lblDateReserveFrom.Text %>');
            DateValidate("lstClaimPayment", "txtDatePaymentFrom", "txtDatePaymentTo", "Payment Date", '<%=lblDatePaymentFrom.Text %>');

            if (document.getElementById('ctl00_ContentPlaceHolder1_chkWC').checked || document.getElementById('ctl00_ContentPlaceHolder1_chkNS').checked) {
                DateValidate("lstDateWorkBegin", "txtRestricted_BeginFrom", "txtRestricted_BeginTo", "Date Restricted Work Begin", '<%=lblRestrictedBeginFrom.Text %>');
                DateValidate("lstDateWorkEnd", "txtRestricted_EndFrom", "txtRestricted_EndTo", "Date Restricted Work Ended", '<%=lblRestrictedEndFrom.Text %>');
            }

            if (document.getElementById('ctl00_ContentPlaceHolder1_chkWC').checked &&
            !document.getElementById('ctl00_ContentPlaceHolder1_chkAl').checked &&
            !document.getElementById('ctl00_ContentPlaceHolder1_chkPl').checked) {
                RadioDate("rdbLstMO", "txtMO1", "txtMO2", "Medical/BI Outstanding", "P", '<%=lblMP1.Text %>');
                RadioDate("rdbLstMP", "txtMP1", "txtMP2", "Medical/BI Paid", "P", '<%=lblMP1.Text %>');
                RadioDate("rdbLstMI", "txtMI1", "txtMI2", "Medical/BI Incurred", "P", '<%=lblMI1.Text %>');
            }

            RadioDate("rdbLstEO", "txtEO1", "txtEO2", "Expense Outstanding", "P", '<%=lblEO1.Text %>');
            RadioDate("rdbLstEP", "txtEP1", "txtEP2", "Expense Paid", "P", '<%=lblEP1.Text %>');
            RadioDate("rdbLstEI", "txtEI1", "txtEI2", "Expense Incurred", "P", '<%=lblEI1.Text %>');
            RadioDate("rdbLstIO", "txtIO1", "txtIO2", "Indemnity/PD Outstanding", "P", '<%=lblIO1.Text %>');
            RadioDate("rdbLstIP", "txtIP1", "txtIP2", "Indemnity/PD Paid", "P", '<%=lblIP1.Text %>');
            RadioDate("rdbLstII", "txtII1", "txtII2", "Indemnity/PD Incurred", "P", '<%=lblII1.Text %>');
            RadioDate("rdbLstTP", "txtTP1", "txtTP2", "Total Paid", "P", '<%=lblTP1.Text %>');
            RadioDate("rdbLstTI", "txtTI1", "txtTI2", "Total Incurred", "P", '<%=lblTI1.Text %>');
            RadioDate("rdbLstTO", "txtTO1", "txtTO2", "Total Outstanding", "P", '<%=lblTO1.Text %>');

            if (Type == "S") {
                var i;
                var lstOutput = document.getElementById('ctl00_ContentPlaceHolder1_lstOutputFields').options;
                var outf = "";
                for (i = 0; i < lstOutput.length; i++)
                    outf += (outf == "") ? lstOutput.options[i].value : "," + lstOutput.options[i].value;
                document.getElementById('<%=hdnOutputList.ClientID%>').value = outf;
            }
            if (ErrMessage != "") {
                alert(ErrMessage);
                return false;
            }
            else
                return true;
        }

        function RadioDate(objRadio, objText1, objText, FieldName, Type, MsgCtl) {
            var Out, RetVal = true;
            var obj1 = document.getElementById("ctl00_ContentPlaceHolder1_" + objText1);
            var obj = document.getElementById("ctl00_ContentPlaceHolder1_" + objText);

            var elmnts = document.getElementsByName("ctl00$ContentPlaceHolder1$" + objRadio);
            for (var m_intCounter = 0; m_intCounter < elmnts.length; m_intCounter++) {
                if (elmnts[m_intCounter].checked) {
                    Out = elmnts[m_intCounter].value;
                    break;
                }
            }

            if (Out == "B") {
                if (trim(obj1.value) == "") {
                    ErrMessage = ErrMessage + "- Please Enter From Amount For " + FieldName + ".\n";
                    RetVal = false;
                }
            }

            if (trim(obj1.value) != "")
                if (!IsNumericNoAlert(RemoveCommas(obj1.value))) {
                    ErrMessage = ErrMessage + "- " + FieldName + ' ' + MsgCtl.replace(':$', '') + " is not a valid number.\n"
                    RetVal = false;
                }

            if (Out == "B") {
                if (trim(obj.value) == "") {
                    ErrMessage = ErrMessage + "- Please Enter To Amount For " + FieldName + ".\n";
                    RetVal = false;
                }
                else {
                    if (!IsNumericNoAlert(RemoveCommas(obj.value))) {
                        ErrMessage = ErrMessage + "- " + FieldName + " To Amount is not a valid number.\n"
                        RetVal = false;
                    }
                }

                if (RetVal == true) {
                    if (obj1.value > obj.value)
                        ErrMessage = ErrMessage + "- To Amount must be Greater Than or Equal To From Amount For " + FieldName + " .\n"
                }
            }
        }

        function DateValidate(objRadio, objDt1, objDt2, FieldName, MsgCtl) {
            var Out, retVal = true;
            var dt1 = document.getElementById("ctl00_ContentPlaceHolder1_" + objDt1);
            var dt2 = document.getElementById("ctl00_ContentPlaceHolder1_" + objDt2);

            var elmnts = document.getElementsByName("ctl00$ContentPlaceHolder1$" + objRadio);
            for (var m_intCounter = 0; m_intCounter < elmnts.length; m_intCounter++) {
                if (elmnts[m_intCounter].checked) {
                    Out = elmnts[m_intCounter].value;
                    break;
                }
            }

            if (Out == "B") {
                if (trim(dt1.value) == '') {
                    ErrMessage = ErrMessage + "- Please Enter Start Date For " + FieldName + ".\n";
                    retVal = false;
                }
            }

            if (ValidateForm(dt1.value) == false) {
                ErrMessage = ErrMessage + "- Please Enter Valid " + MsgCtl.replace(':', '') + " For " + FieldName + ".\n";
                retVal = false;
            }

            if (Out == "B") {
                if (trim(dt2.value) == '') {
                    ErrMessage = ErrMessage + "- Please Enter End Date For " + FieldName + ".\n";
                    retVal = false;
                }

                if (ValidateForm(dt2.value) == false) {
                    ErrMessage = ErrMessage + "- Please Enter Valid End Date For " + FieldName + ".\n";
                    retVal = false;
                }

                if (retVal == true) {
                    if (compareDate(dt1.value, dt2.value) < 0) {
                        ErrMessage = ErrMessage + "- End Date must be Greater Than or Equal to Start Date For " + FieldName + ".\n";
                        retVal = false;
                    }
                }
            }
            return retVal;
        }

        function ValidateForm(objDt) {
            if (trim(objDt) != '') {
                if (isDate(objDt) == false)
                    return false
            }
            return true
        }

    </script>

    <div>
        <asp:HiddenField ID="hdnOutputList" runat="server" />
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            EnableClientScript="true" ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <table width="100%" cellpadding="2" cellspacing="2" class="ic">
        <tr>
            <td class="ghc" align="left">Ad Hoc Report Writer
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="2" cellspacing="0" width="100%" align="center">
                    <tr>
                        <td align="right" style="width: 40%;">
                            <strong style="color: #666666;">Claim Type: </strong>
                        </td>
                        <td width="70%">
                            <asp:CheckBox ID="chkWC" runat="server" Text="Workers Compensation" AutoPostBack="true"
                                OnCheckedChanged="chkClaimType_CheckedChanged" />
                            <asp:CheckBox ID="chkNS" runat="server" Text="Texas N-S" AutoPostBack="true"
                                OnCheckedChanged="chkClaimType_CheckedChanged" />
                            <asp:CheckBox ID="chkAL" runat="server" Text="Auto Liability" AutoPostBack="true"
                                OnCheckedChanged="chkClaimType_CheckedChanged" />
                            <asp:CheckBox ID="chkPL" runat="server" Text="Premises Liability" AutoPostBack="true"
                                OnCheckedChanged="chkClaimType_CheckedChanged" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="2" cellspacing="1" width="100%" align="center">
                    <tr>
                        <td width="100%">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="lc" style="width: 15%;">
                                        <strong style="color: #666666;">Date Claim Opened : </strong>
                                    </td>
                                    <td style="width: 35%;">
                                        <asp:RadioButtonList ID="lstClaimOpened" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                            <asp:ListItem Text="Before" Value="BF"></asp:ListItem>
                                            <asp:ListItem Text="After" Value="A"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td class="lc" style="width: 15%;">
                                        <strong style="color: #666666;">Date Claim Closed : </strong>
                                    </td>
                                    <td style="width: 35%;">
                                        <asp:RadioButtonList ID="lstClaimClosed" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                            <asp:ListItem Text="Before" Value="BF"></asp:ListItem>
                                            <asp:ListItem Text="After" Value="A"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="8%" valign="middle">
                                        <asp:Label ID="lblDateOpenedFrom" runat="server" Text="On Date : " ForeColor="#666666"
                                            Font-Bold="true"></asp:Label>
                                    </td>
                                    <td width="13%">
                                        <asp:TextBox ID="txtDate_Opened_From" runat="server" SkinID="txtdate" Width="80px"
                                            MaxLength="10"></asp:TextBox>
                                        <img alt="Date Claim Opened" id="imgDate_Opened_From" onclick="return showCalendar('<%=txtDate_Opened_From.ClientID%>', 'mm/dd/y','','');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                            align="middle" />
                                    </td>
                                    <td style="width: 8%;" valign="middle">
                                        <asp:Label ID="lblDateOpenedTo" runat="server" Text="Start Date :" ForeColor="#666666"
                                            Font-Bold="true"></asp:Label>
                                    </td>
                                    <td style="width: 9%;">
                                        <asp:TextBox ID="txtDate_Opened_To" runat="server" SkinID="txtdate" Width="80px"
                                            MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td style="width: 12%;">
                                        <img alt="Date Claim Opened" id="imgDate_Opened_To" runat="server" onclick="return showCalendar('<%=txtDate_Opened_To.ClientID%>', 'mm/dd/y','','');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                            align="middle" />
                                    </td>
                                    <td width="8%" valign="middle">
                                        <asp:Label ID="lblDateClosedFrom" runat="server" Text="On Date :" ForeColor="#666666"
                                            Font-Bold="true"></asp:Label>
                                    </td>
                                    <td width="13%">
                                        <asp:TextBox ID="txtDateClosedFrom" runat="server" SkinID="txtdate" Width="80px"
                                            MaxLength="10"></asp:TextBox>
                                        <img alt="Date Claim Closed" onclick="return showCalendar('<%=txtDateClosedFrom.ClientID%>', 'mm/dd/y','','');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                            align="middle" />
                                    </td>
                                    <td width="8%" valign="middle">
                                        <asp:Label ID="lblDateClosedTo" runat="server" Text="Start Date :" ForeColor="#666666"
                                            Font-Bold="true"></asp:Label>
                                    </td>
                                    <td style="width: 9%;">
                                        <asp:TextBox ID="txtDateClosedTo" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td style="width: 12%;">
                                        <img alt="Date Claim Closed" id="imgDate_Closed_To" runat="server" onclick="return showCalendar('<%=txtDateClosedTo.ClientID%>', 'mm/dd/y','','');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                            align="middle" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 5px;"></td>
                    </tr>
                    <tr>
                        <td colspan="10">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="50%" valign="top">
                                        <table width="100%" cellpadding="0" cellspacing="0" id="pnlALClaimOrigin" runat="server" visible="false">
                                            <tr>
                                                <td valign="top" class="lc" width="22%" style="padding-top: 5px;">
                                                    <strong style="color: #666666;">AL Claim Origin : </strong>
                                                </td>
                                                <td>
                                                    <%--<asp:RadioButtonList ID="rdoALClaimOrigin" runat="server" RepeatColumns="1" RepeatDirection="Vertical">
                                                        <asp:ListItem Text="AL Claims from AL FROIs" Value="AL"></asp:ListItem>
                                                        <asp:ListItem Text="AL Claims from DPD FROIs" Value="DPD"></asp:ListItem>
                                                        <asp:ListItem Text="AL Claims from PL FROIs" Value="PL"></asp:ListItem>                                                        
                                                    </asp:RadioButtonList>--%>
                                                    <asp:CheckBoxList ID="rdoALClaimOrigin" runat="server">
                                                        <asp:ListItem Text="AL Claims from AL FROIs" Value="AL"></asp:ListItem>
                                                        <asp:ListItem Text="AL Claims from DPD FROIs" Value="DPD"></asp:ListItem>
                                                        <asp:ListItem Text="AL Claims from PL FROIs" Value="PL"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="lc" style="width: 50%;">
                                        <strong style="color: #666666;">Claim Status :
                                            <asp:CheckBox ID="chkClaimStatus" runat="server" />Select/Deselect All</strong><br />
                                        <asp:ListBox ID="lstClaimStatus" runat="server" SelectionMode="Multiple" Width="350px"></asp:ListBox>
                                        <%--<asp:CheckBoxList ID="cblClaimStatus" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Open" Value="O"></asp:ListItem>
                                            <asp:ListItem Text="Re-Open" Value="RO"></asp:ListItem>
                                            <asp:ListItem Text="Closed" Value="C"></asp:ListItem>
                                        </asp:CheckBoxList>--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="10" width="100%">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="lc" style="width: 15%;">
                                        <strong style="color: #666666;">Date of Accident : </strong>
                                    </td>
                                    <td style="width: 35%;">
                                        <asp:RadioButtonList ID="lstClaimIncident" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                            <asp:ListItem Text="Before" Value="BF"></asp:ListItem>
                                            <asp:ListItem Text="After" Value="A"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td class="lc" style="width: 15%;">
                                        <strong style="color: #666666;">Valued as of Date : </strong>
                                    </td>
                                    <td style="width: 35%;">
                                        <asp:RadioButtonList ID="lstClaimValued" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                            <%--                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                            <asp:ListItem Text="Before" Value="BF"></asp:ListItem>
                                            <asp:ListItem Text="After" Value="A"></asp:ListItem>--%>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 5px;"></td>
                    </tr>
                    <tr>
                        <td width="100%">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="8%" valign="middle">
                                        <asp:Label ID="lblDateIncidentFrom" runat="server" Text="On Date : " ForeColor="#666666"
                                            Font-Bold="true"></asp:Label>
                                    </td>
                                    <td width="13%">
                                        <asp:TextBox ID="txtDate_Incident_From" runat="server" SkinID="txtdate" Width="80px"
                                            MaxLength="10"></asp:TextBox>
                                        <img alt="Date of Accident" id="imgDate_Incident_From" onclick="return showCalendar('<%=txtDate_Incident_From.ClientID%>', 'mm/dd/y','','');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                            align="middle" />
                                    </td>
                                    <td style="width: 8%;" valign="middle">
                                        <asp:Label ID="lblDateIncidentTo" runat="server" Text="Start Date :" ForeColor="#666666"
                                            Font-Bold="true"></asp:Label>
                                    </td>
                                    <td style="width: 9%;">
                                        <asp:TextBox ID="txtDate_Incident_To" runat="server" SkinID="txtdate" Width="80px"
                                            MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td style="width: 12%;">
                                        <img alt="Date of Accident" id="imgDate_Incident_To" runat="server" onclick="return showCalendar('<%=txtDate_Incident_To.ClientID%>', 'mm/dd/y','','');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                            align="middle" />
                                    </td>
                                    <td width="8%" valign="middle">
                                        <asp:Label ID="lblDateValuedFrom" runat="server" Text="On Date :" ForeColor="#666666"
                                            Font-Bold="true"></asp:Label>
                                    </td>
                                    <td width="13%">
                                        <asp:TextBox ID="txtDateValuedFrom" runat="server" SkinID="txtdate" Width="80px"
                                            MaxLength="10"></asp:TextBox>
                                        <img alt="Valued as of Date" onclick="return showCalendar('<%=txtDateValuedFrom.ClientID%>', 'mm/dd/y','','');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                            align="middle" />
                                    </td>
                                    <td colspan="3" style="width: 29%">&nbsp;
                                    </td>
                                    <%--                                    <td width="8%" valign="middle">
                                        <asp:Label ID="lblDateValuedTo" runat="server" Text="Start Date :" ForeColor="#666666"
                                            Font-Bold="true"></asp:Label>
                                    </td>
                                    <td style="width: 9%;">
                                        <asp:TextBox ID="txtDateValuedTo" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td style="width: 12%;">
                                        <img alt="Valued as of Date" id="imgDate_Valued_To" runat="server" onclick="return showCalendar('<%=txtDateValuedTo.ClientID%>', 'mm/dd/y','','');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                            align="middle" />
                                    </td>--%>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="10" width="100%">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="lc" style="width: 15%;">
                                        <strong style="color: #666666;">Reserve Date : </strong>
                                    </td>
                                    <td style="width: 35%;">
                                        <asp:RadioButtonList ID="lstClaimReserve" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                            <asp:ListItem Text="Before" Value="BF"></asp:ListItem>
                                            <asp:ListItem Text="After" Value="A"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td class="lc" style="width: 15%;">
                                        <strong style="color: #666666;">Payment Date : </strong>
                                    </td>
                                    <td style="width: 35%;">
                                        <asp:RadioButtonList ID="lstClaimPayment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                            <asp:ListItem Text="Before" Value="BF"></asp:ListItem>
                                            <asp:ListItem Text="After" Value="A"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 5px;"></td>
                    </tr>
                    <tr>
                        <td width="100%">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="8%" valign="middle">
                                        <asp:Label ID="lblDateReserveFrom" runat="server" Text="On Date : " ForeColor="#666666"
                                            Font-Bold="true"></asp:Label>
                                    </td>
                                    <td width="13%">
                                        <asp:TextBox ID="txtDate_Reserve_From" runat="server" SkinID="txtdate" Width="80px"
                                            MaxLength="10"></asp:TextBox>
                                        <img alt="Reserve Date" id="imgDate_Reserve_From" onclick="return showCalendar('<%=txtDate_Reserve_From.ClientID%>', 'mm/dd/y','','');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                            align="middle" />
                                    </td>
                                    <td style="width: 8%;" valign="middle">
                                        <asp:Label ID="lblDateReserveTo" runat="server" Text="Start Date :" ForeColor="#666666"
                                            Font-Bold="true"></asp:Label>
                                    </td>
                                    <td style="width: 9%;">
                                        <asp:TextBox ID="txtDate_Reserve_To" runat="server" SkinID="txtdate" Width="80px"
                                            MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td style="width: 12%;">
                                        <img alt="Reserve Date" id="imgDate_Reserve_To" runat="server" onclick="return showCalendar('<%=txtDate_Reserve_To.ClientID%>', 'mm/dd/y','','');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                            align="middle" />
                                    </td>
                                    <td width="8%" valign="middle">
                                        <asp:Label ID="lblDatePaymentFrom" runat="server" Text="On Date :" ForeColor="#666666"
                                            Font-Bold="true"></asp:Label>
                                    </td>
                                    <td width="13%">
                                        <asp:TextBox ID="txtDatePaymentFrom" runat="server" SkinID="txtdate" Width="80px"
                                            MaxLength="10"></asp:TextBox>
                                        <img alt="Payment Date" onclick="return showCalendar('<%=txtDatePaymentFrom.ClientID%>', 'mm/dd/y','','');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                            align="middle" />
                                    </td>
                                    <td width="8%" valign="middle">
                                        <asp:Label ID="lblDatePaymentTo" runat="server" Text="Start Date :" ForeColor="#666666"
                                            Font-Bold="true"></asp:Label>
                                    </td>
                                    <td style="width: 9%;">
                                        <asp:TextBox ID="txtDatePaymentTo" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td style="width: 12%;">
                                        <img alt="Payment Date" id="imgDate_Payment_To" runat="server" onclick="return showCalendar('<%=txtDatePaymentTo.ClientID%>', 'mm/dd/y','','');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                            align="middle" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 5px;"></td>
                    </tr>
                    <tr>
                        <td colspan="10" width="100%">
                            <asp:Panel ID="pnlDateRestricted" runat="server">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="lc" style="width: 15%;">
                                            <strong style="color: #666666;">Date Restricted Work Begin : </strong>
                                        </td>
                                        <td style="width: 35%;">
                                            <asp:RadioButtonList ID="lstDateWorkBegin" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                                <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                <asp:ListItem Text="Before" Value="BF"></asp:ListItem>
                                                <asp:ListItem Text="After" Value="A"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td class="lc" style="width: 15%;">
                                            <strong style="color: #666666;">Date Restricted Work Ended : </strong>
                                        </td>
                                        <td style="width: 35%;">
                                            <asp:RadioButtonList ID="lstDateWorkEnd" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                                <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                <asp:ListItem Text="Before" Value="BF"></asp:ListItem>
                                                <asp:ListItem Text="After" Value="A"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 5px;"></td>
                    </tr>
                    <tr>
                        <td width="100%">
                            <asp:Panel ID="pnlDateRestictedtext" runat="server">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="8%" valign="middle">
                                            <asp:Label ID="lblRestrictedBeginFrom" runat="server" Text="On Date : " ForeColor="#666666"
                                                Font-Bold="true"></asp:Label>
                                        </td>
                                        <td width="13%">
                                            <asp:TextBox ID="txtRestricted_BeginFrom" runat="server" SkinID="txtdate" Width="80px"
                                                MaxLength="10"></asp:TextBox>
                                            <img alt="Date Restricted Begin" id="imgDate_Restricted_Begin" onclick="return showCalendar('<%=txtRestricted_BeginFrom.ClientID%>', 'mm/dd/y','','');"
                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                align="middle" />
                                        </td>
                                        <td style="width: 8%;" valign="middle">
                                            <asp:Label ID="lblRestrictedBeginTo" runat="server" Text="Start Date :" ForeColor="#666666"
                                                Font-Bold="true"></asp:Label>
                                        </td>
                                        <td style="width: 9%;">
                                            <asp:TextBox ID="txtRestricted_BeginTo" runat="server" SkinID="txtdate" Width="80px"
                                                MaxLength="10"></asp:TextBox>
                                        </td>
                                        <td style="width: 12%;">
                                            <img alt="Date Restricted From" id="imgRestricted_Begin_To" runat="server" onclick="return showCalendar('<%=txtRestricted_BeginTo.ClientID%>', 'mm/dd/y','','');"
                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                align="middle" />
                                        </td>
                                        <td width="8%" valign="middle">
                                            <asp:Label ID="lblRestrictedEndFrom" runat="server" Text="On Date :" ForeColor="#666666"
                                                Font-Bold="true"></asp:Label>
                                        </td>
                                        <td width="13%">
                                            <asp:TextBox ID="txtRestricted_EndFrom" runat="server" SkinID="txtdate" Width="80px"
                                                MaxLength="10"></asp:TextBox>
                                            <img alt="Date Restricted End" onclick="return showCalendar('<%=txtRestricted_EndFrom.ClientID%>', 'mm/dd/y','','');"
                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                align="middle" />
                                        </td>
                                        <td width="8%" valign="middle">
                                            <asp:Label ID="lblRestrictedEndTo" runat="server" Text="Start Date :" ForeColor="#666666"
                                                Font-Bold="true"></asp:Label>
                                        </td>
                                        <td style="width: 9%;">
                                            <asp:TextBox ID="txtRestricted_EndTo" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                        </td>
                                        <td style="width: 12%;">
                                            <img alt="Date Restricted End" id="imgRestricted_End_To" runat="server" onclick="return showCalendar('<%=txtRestricted_EndTo.ClientID%>', 'mm/dd/y','','');"
                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                align="middle" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 5px;"></td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="100%">
                                        <asp:Panel ID="pnlIndicator" runat="server">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <strong style="color: #666666;">LT/Med/Incident Indicator :</strong>
                                                    </td>
                                                    <td>
                                                        <asp:RadioButtonList ID="lstIndicator" runat="server">
                                                            <asp:ListItem Text="LT" Value="LT"></asp:ListItem>
                                                            <asp:ListItem Text="Med" Value="Med"></asp:ListItem>
                                                            <asp:ListItem Text="Incident" Value="Incident"></asp:ListItem>
                                                            <asp:ListItem Text="LT/Med" Value="LT,Med" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="LT/Med/Incident" Value="LT,Med,Incident"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>

                                                    <td width="15px">&nbsp;
                                                    </td>
                                                    <td>
                                                        <strong style="color: #666666;">Full & Final Clincher? :</strong>
                                                    </td>
                                                    <td>
                                                        <asp:RadioButtonList ID="rdoFull_Final_Clincher" runat="server" SkinID="YNTypeNullSelection" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 5px;"></td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="50%">
                                        <strong style="color: #666666;">Location :
                                            <asp:CheckBox ID="chkLocation" runat="server" />Select/Deselect All</strong><br />
                                        <asp:ListBox ID="lstLocation" SelectionMode="Multiple" runat="server" Width="350px"></asp:ListBox>
                                    </td>
                                    <td width="50%">
                                        <strong style="color: #666666;">Region :
                                            <asp:CheckBox ID="chkRegion" runat="server" />Select/Deselect All</strong><br />
                                        <asp:ListBox ID="lstRegion" SelectionMode="Multiple" runat="server" Width="350px"></asp:ListBox>
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="50%">
                                        <strong style="color: #666666;">Coverage State :
                                            <asp:CheckBox ID="chkCoverageState" runat="server" />
                                            Select/Deselect All</strong><br />
                                        <asp:ListBox ID="lstCoverageState" SelectionMode="Multiple" runat="server" Width="350px"></asp:ListBox>
                                    </td>
                                    <td width="50%">
                                        <strong style="color: #666666;">Market :
                                            <asp:CheckBox ID="chkMarket" runat="server" />Select/Deselect All</strong><br />
                                        <asp:ListBox ID="lstMarket" SelectionMode="Multiple" runat="server" Width="350px"></asp:ListBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 5px;"></td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    
                                    <td width="50%">
                                        <asp:Panel ID="pnlNOI" runat="server" Width="100%">
                                            <strong style="color: #666666;">Nature of Injury :
                                                <asp:CheckBox ID="chkNatureofInjury" runat="server" />Select/Deselect All</strong><br />
                                            <asp:ListBox ID="lstNatureofInjury" SelectionMode="Multiple" runat="server" Width="350px"></asp:ListBox>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlLineofCoverage" runat="server">
                                            <table border="0">
                                                <tr>
                                                    <td valign="top"><strong style="color: #666666;">Line of Coverage :</strong></td>
                                                    <td>
                                                        <asp:RadioButton ID="rbnAL" runat="server" Text="AL" value="AL" AutoPostBack="true" OnCheckedChanged="rbnCoverage_CheckedChanged" /><br />
                                                        <asp:RadioButton ID="rbnAU" runat="server" Text="AU" value="AU" AutoPostBack="true" OnCheckedChanged="rbnCoverage_CheckedChanged" /><br />
                                                        <asp:RadioButton ID="rbnGK" runat="server" Text="GK" value="GK" AutoPostBack="true" OnCheckedChanged="rbnCoverage_CheckedChanged" /><br />
                                                        <asp:RadioButton ID="rbnCoverage" runat="server" Text="All Lines of Coverage" AutoPostBack="true" value="LineCoverage" OnCheckedChanged="rbnCoverage_CheckedChanged" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="50%">
                                        <asp:Panel ID="pnlBodyPart" runat="server" Width="100%">
                                            <strong style="color: #666666;">Body Part :
                                                <asp:CheckBox ID="chkBodypart" runat="server" />Select/Deselect All</strong><br />
                                            <asp:ListBox ID="lstBodyPart" SelectionMode="Multiple" runat="server" Width="350px"></asp:ListBox>
                                        </asp:Panel>
                                    </td>
                                    <td width="50%">
                                        <asp:Panel ID="pnlCause" runat="server" Width="100%">
                                            <strong style="color: #666666;">Cause :
                                                <asp:CheckBox ID="chkCause" runat="server" />Select/Deselect All </strong>
                                            <br />
                                            <asp:ListBox ID="lstCause" SelectionMode="Multiple" runat="server" Width="350px"></asp:ListBox>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="50%">
                                        <strong style="color: #666666;">Claim Sub Status :
                                            <asp:CheckBox ID="chkClaimSubStatus" runat="server" />Select/Deselect All</strong><br />
                                        <asp:ListBox ID="lstClaimSubStatus" SelectionMode="Multiple" runat="server" Width="350px"></asp:ListBox>
                                    </td>
                                    <td width="50%">
                                        <asp:Panel ID="pnlSonicCauseCode" runat="server" Width="100%">
                                            <strong style="color: #666666;">Sonic Cause Code :
                                                <asp:CheckBox ID="chkSonicCauseCode" runat="server" />Select/Deselect All</strong><br />
                                            <asp:ListBox ID="lstSonicCauseCode" SelectionMode="Multiple" runat="server" Width="350px">
                                                <asp:ListItem Value="S0-1" Text="S0-1-OVEREXERTION-LIFTLOWER, PUSH/PULL, CARRY"></asp:ListItem>
                                                <asp:ListItem Value="S0-2" Text="S0-2-FALL SAME LEVEL OR ELEVATED SURFACE"></asp:ListItem>
                                                <asp:ListItem Value="S0-3" Text="S0-3-VEHICLE RELATED - HIGHWAY, PREMISES, GOLF CART"></asp:ListItem>
                                                <asp:ListItem Value="S0-4" Text="S0-4-STRUCK BY/AGAINST - STATIONARY OBJECT/FALLING MOVING OBJECT"></asp:ListItem>
                                                <asp:ListItem Value="S0-5" Text="S0-5-OTHER - NOT CLASSIFIED"></asp:ListItem>
                                                <asp:ListItem Value="S1" Text="S1-OVEREXERTION-LIFTLOWER, PUSH/PULL, CARRY"></asp:ListItem>
                                                <asp:ListItem Value="S2" Text="S2-FALL SAME LEVEL OR ELEVATED SURFACE"></asp:ListItem>
                                                <asp:ListItem Value="S3" Text="S3-VEHICLE RELATED - HIGHWAY, PREMISES, GOLF CART"></asp:ListItem>
                                                <asp:ListItem Value="S4" Text="S4-STRUCK BY/AGAINST - STATIONARY OBJECT/FALLING MOVING OBJECT"></asp:ListItem>
                                                <asp:ListItem Value="S5" Text="S5-OTHER - NOT CLASSIFIED IN ABOVE CODES"></asp:ListItem>
                                            </asp:ListBox>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 5px;">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 50%;" align="left">
                                        <asp:Panel ID="pnlMedicalPaid" runat="server" Width="100%">
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="lc" align="left" style="width: 30%; font-weight: bold;">Medical/BI Paid:
                                                    </td>
                                                    <td class="ic" align="left" style="width: 70%;">
                                                        <asp:RadioButtonList ID="rdbLstMP" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstMP_SelectedIndexChanged">
                                                            <asp:ListItem Text="Greater Than" Value="G" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="L"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lc" align="left" colspan="2" style="font-weight: bold;">
                                                        <asp:Label ID="lblMP1" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtMP1" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                            SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblMP2" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtMP2" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                            SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                    <td style="width: 50%;" align="left">
                                        <asp:Panel ID="pnlMedicalInc" runat="server" Width="100%">
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="lc" align="left" style="width: 35%; font-weight: bold;">Medical/BI Incurred:
                                                    </td>
                                                    <td class="ic" align="left" style="width: 65%;">
                                                        <asp:RadioButtonList ID="rdbLstMI" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstMI_SelectedIndexChanged">
                                                            <asp:ListItem Text="Greater Than" Value="G" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="L"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lc" align="left" colspan="2" style="font-weight: bold;">
                                                        <asp:Label ID="lblMI1" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtMI1" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                            SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblMI2" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtMI2" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                            SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50%;" align="left">
                                        <asp:Panel ID="pnlMedicalOutStanding" runat="server" Width="100%">
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="lc" align="left" style="width: 30%; font-weight: bold;">Medical/BI Outstanding:
                                                    </td>
                                                    <td class="ic" align="left" style="width: 70%;">
                                                        <asp:RadioButtonList ID="rdbLstMO" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstMO_SelectedIndexChanged">
                                                            <asp:ListItem Text="Greater Than" Value="G" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="L"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lc" align="left" colspan="2" style="font-weight: bold;">
                                                        <asp:Label ID="lblMO1" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtMO1" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                            SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblMO2" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtMO2" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                            SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50%;" align="left">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="lc" align="left" style="width: 30%; font-weight: bold;">Expense Paid:
                                                </td>
                                                <td class="ic" align="left" style="width: 70%;">
                                                    <asp:RadioButtonList ID="rdbLstEP" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                                        OnSelectedIndexChanged="rdbLstEP_SelectedIndexChanged">
                                                        <asp:ListItem Text="Greater Than" Value="G" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                        <asp:ListItem Text="Less Than" Value="L"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" align="left" colspan="2" style="font-weight: bold;">
                                                    <asp:Label ID="lblEP1" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtEP1" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                    <asp:Label ID="lblEP2" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtEP2" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 50%;" align="left">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="lc" align="left" style="width: 35%; font-weight: bold;">Expense Incurred:
                                                </td>
                                                <td class="ic" align="left" style="width: 65%;">
                                                    <asp:RadioButtonList ID="rdbLstEI" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                                        OnSelectedIndexChanged="rdbLstEI_SelectedIndexChanged">
                                                        <asp:ListItem Text="Greater Than" Value="G" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                        <asp:ListItem Text="Less Than" Value="L"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" align="left" colspan="2" style="font-weight: bold;">
                                                    <asp:Label ID="lblEI1" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtEI1" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                    <asp:Label ID="lblEI2" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtEI2" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50%;" align="left">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="lc" align="left" style="width: 30%; font-weight: bold;">Expense Outstanding:
                                                </td>
                                                <td class="ic" align="left" style="width: 70%;">
                                                    <asp:RadioButtonList ID="rdbLstEO" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                                        OnSelectedIndexChanged="rdbLstEO_SelectedIndexChanged">
                                                        <asp:ListItem Text="Greater Than" Value="G" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                        <asp:ListItem Text="Less Than" Value="L"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" align="left" colspan="2" style="font-weight: bold;">
                                                    <asp:Label ID="lblEO1" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtEO1" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                    <asp:Label ID="lblEO2" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtEO2" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50%;" align="left">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="lc" align="left" style="width: 30%; font-weight: bold;">Indemnity/PD Paid:
                                                </td>
                                                <td class="ic" align="left" style="width: 70%;">
                                                    <asp:RadioButtonList ID="rdbLstIP" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                                        OnSelectedIndexChanged="rdbLstIP_SelectedIndexChanged">
                                                        <asp:ListItem Text="Greater Than" Value="G" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                        <asp:ListItem Text="Less Than" Value="L"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" align="left" colspan="2" style="font-weight: bold;">
                                                    <asp:Label ID="lblIP1" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtIP1" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                    <asp:Label ID="lblIP2" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtIP2" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 50%;" align="left">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="lc" align="left" style="width: 35%; font-weight: bold;">Indemnity/PD Incurred:
                                                </td>
                                                <td class="ic" align="left" style="width: 65%;">
                                                    <asp:RadioButtonList ID="rdbLstII" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                                        OnSelectedIndexChanged="rdbLstII_SelectedIndexChanged">
                                                        <asp:ListItem Text="Greater Than" Value="G" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                        <asp:ListItem Text="Less Than" Value="L"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" align="left" colspan="2" style="font-weight: bold;">
                                                    <asp:Label ID="lblII1" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtII1" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                    <asp:Label ID="lblII2" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtII2" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50%;" align="left">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="lc" align="left" style="width: 30%; font-weight: bold;">Indemnity/PD Outstanding:
                                                </td>
                                                <td class="ic" align="left" style="width: 70%;">
                                                    <asp:RadioButtonList ID="rdbLstIO" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                                        OnSelectedIndexChanged="rdbLstIO_SelectedIndexChanged">
                                                        <asp:ListItem Text="Greater Than" Value="G" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                        <asp:ListItem Text="Less Than" Value="L"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" align="left" colspan="2" style="font-weight: bold;">
                                                    <asp:Label ID="lblIO1" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtIO1" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                    <asp:Label ID="lblIO2" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtIO2" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50%;" align="left">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="lc" align="left" style="width: 30%; font-weight: bold;">Total Paid:
                                                </td>
                                                <td class="ic" align="left" style="width: 70%;">
                                                    <asp:RadioButtonList ID="rdbLstTP" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                                        OnSelectedIndexChanged="rdbLstTP_SelectedIndexChanged">
                                                        <asp:ListItem Text="Greater Than" Value="G" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                        <asp:ListItem Text="Less Than" Value="L"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" align="left" colspan="2" style="font-weight: bold;">
                                                    <asp:Label ID="lblTP1" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtTP1" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                    <asp:Label ID="lblTP2" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtTP2" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 50%;" align="left">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="lc" align="left" style="width: 35%; font-weight: bold;">Total Incurred:
                                                </td>
                                                <td class="ic" align="left" style="width: 65%;">
                                                    <asp:RadioButtonList ID="rdbLstTI" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                                        OnSelectedIndexChanged="rdbLstTI_SelectedIndexChanged">
                                                        <asp:ListItem Text="Greater Than" Value="G" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                        <asp:ListItem Text="Less Than" Value="L"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" align="left" colspan="2" style="font-weight: bold;">
                                                    <asp:Label ID="lblTI1" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtTI1" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                    <asp:Label ID="lblTI2" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtTI2" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50%;" align="left">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="lc" align="left" style="width: 30%; font-weight: bold;">Total Outstanding:
                                                </td>
                                                <td class="ic" align="left" style="width: 70%;">
                                                    <asp:RadioButtonList ID="rdbLstTO" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                                        OnSelectedIndexChanged="rdbLstTO_SelectedIndexChanged">
                                                        <asp:ListItem Text="Greater Than" Value="G" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                        <asp:ListItem Text="Less Than" Value="L"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" align="left" colspan="2" style="font-weight: bold;">
                                                    <asp:Label ID="lblTO1" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtTO1" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                    <asp:Label ID="lblTO2" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtTO2" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="ghc" align="left">Filter Criteria
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" cellpadding="2" cellspacing="1">
                    <tr>
                        <td style="width: 25%; color: #666666; font-weight: bold;">Output Fields
                        </td>
                        <td style="width: 25%; color: #666666; font-weight: bold;">First Level Sorting
                        </td>
                        <td style="width: 25%; color: #666666; font-weight: bold;">Second Level Sorting
                        </td>
                        <td style="width: 25%; color: #666666; font-weight: bold;">Third Level Sorting
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:ListBox ID="lstOutputFields" runat="server" SelectionMode="Multiple" Height=" 150px" Width="210px"></asp:ListBox>
                            <asp:ImageButton ID="imgUp" ImageUrl="~/Images/up-arrow.gif" runat="server" ImageAlign="top"
                                OnClientClick="return MoveItemUp();" />
                            <asp:ImageButton ID="imgDown" ImageUrl="~/Images/down-arrow.gif" runat="server" ImageAlign="top"
                                OnClientClick="return MoveItemDown();" />
                        </td>
                        <td class="ic" style="width: 25%" align="left">
                            <asp:ListBox ID="lstFirstSort" runat="server" Height="150px" AutoPostBack="false" Width="220px"
                                SelectionMode="Single" onclick="javascript:return ListFirst(this.id,this.selectedIndex);"></asp:ListBox>
                        </td>
                        <td class="ic" style="width: 25%" align="left">
                            <asp:ListBox ID="lstSecondSort" runat="server" Height="150px" AutoPostBack="false" Width="220px"
                                SelectionMode="Single" onclick="javascript:return ListSecond(this.id,this.selectedIndex);"></asp:ListBox>
                        </td>
                        <td class="ic" style="width: 25%" align="left">
                            <asp:ListBox ID="lstThirdSort" runat="server" Height="150px" AutoPostBack="false" Width="220px"
                                SelectionMode="Single" onclick="javascript:return ListThird(this.id,this.selectedIndex);"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="ic" align="left" colspan="4">
                            <strong>
                                <asp:CheckBox ID="chkSelUnSelFields" runat="server" Text="Select/Deselect All" AutoPostBack="false"
                                    onclick="selectAllOptions();" /></strong>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <strong>
                                <asp:CheckBox ID="chkGrand" runat="server" Text="Include Grand Total in Report" AutoPostBack="false" /></strong>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="ghc" align="left">Saved Reports
            </td>
        </tr>
        <tr>
            <td>
                <table cellspacing="1" cellpadding="2">
                    <tr>
                        <td class="lc" align="left" style="width: 30%; font-weight: bold;">Report Name:
                        </td>
                        <td class="lc" align="left" style="width: 70%;">
                            <asp:TextBox ID="txtReportName" runat="server" ValidationGroup="vsErrorGroup" MaxLength="200"></asp:TextBox><span
                                class="mf">*</span>
                            <asp:HiddenField ID="hdnReportName" runat="server" Value="" />
                            <asp:HiddenField ID="hdnReportId" runat="Server" />
                            <asp:RequiredFieldValidator ID="rfvEmpID" ControlToValidate="txtReportName" runat="server"
                                EnableClientScript="true" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Report Name"
                                Display="none"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" align="left" style="width: 30%; font-weight: bold;">Select Report:
                        </td>
                        <td class="lc" align="left" style="width: 70%;">
                            <asp:DropDownList ID="ddlReports" runat="server" AutoPostBack="True" AppendDataBoundItems="true"
                                OnSelectedIndexChanged="ddlReports_SelectedIndexChanged">
                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="btnExportExcel" runat="Server" CssClass="btn" Text="Output to Excel"
                    OnClick="btnExportExcel_Click" ToolTip="Output to Excel" />
                <asp:Button ID="btnSubmit" runat="Server" Text="Save Report" ValidationGroup="vsErrorGroup"
                    OnClick="btnSubmit_Click" ToolTip="Save Report" />
                <asp:Button ID="btnClear" runat="Server" Text="Clear" OnClick="btnClear_Click" ToolTip="Clear" />
                <asp:Button ID="btnDeleteReport" runat="server" Text="Delete Report" OnClick="btnDeleteReport_Click"
                    OnClientClick="return CheckReport();" Enabled="false" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvAdHoc" runat="Server" AllowPaging="false" AllowSorting="false"
                    ShowFooter="false" EnableTheming="false" AutoGenerateColumns="true" CaptionAlign="Left"
                    CellPadding="5" Width="100%" GridLines="Both" HeaderStyle-HorizontalAlign="Left"
                    RowStyle-HorizontalAlign="Left" OnRowDataBound="gvAdHoc_RowDataBound" OnDataBound="gvAdhoc_DataBound">
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
