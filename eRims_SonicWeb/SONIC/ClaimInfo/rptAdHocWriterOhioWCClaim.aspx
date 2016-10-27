<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptAdHocWriterOhioWCClaim.aspx.cs"
    Inherits="SONIC_ClaimInfo_rptAdHocWriterOhioWCClaim" Title="eRIMS Sonic :: Ad-Hoc Writer"
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

            DateValidate("lstClaimEntered", "txtDate_Entered_From", "txtDate_Entered_To", "Date Claim Entered", '<%=lblDateEnteredFrom.Text %>');
            DateValidate("lstClaimClosed", "txtDateClosedFrom", "txtDateClosedTo", "Date Claim Close", '<%=lblDateClosedFrom.Text %>');
            DateValidate("lstClaimIncident", "txtDate_Incident_From", "txtDate_Incident_To", "Date of Incident", '<%=lblDateIncidentFrom.Text %>');
            DateValidate("lstClaimReOpened", "txtDateOfClaimReopenedFrom", "txtDateofClaimReopenedTo", "Date Claim Reopened", '<%=lblDateOfClaimReopenedFrom.Text %>');



            /*
            RadioDate("rdbLstMP", "txtMP1", "txtMP2", "Total Medical", "P", '<=lblMP1.Text %>');
            RadioDate("rdbLstComp", "txtTotalComp1", "txtTotalComp2", "Total Comp", "P", '<=lblTotalComp1.Text %>');
            RadioDate("rdbLstTotalReserve", "txtTotalRes1", "txtTotalRes1", "Total Reserve", "P", '<=lblTotalRes1.Text %>');
            RadioDate("rdbLstUnlimitedCost", "txtUnlimitedCost1", "txtUnlimitedCost2", "Unlimited Cost", "P", '<=lblUnlimitedCost1.Text %>');
            RadioDate("rdbLstLimitedToMV", "txtLimitedToMV1", "txtLimitedToMV2", "Limited to MV", "P", '<lblLimitedToMV1.Text %>');
            RadioDate("rdbLstHCP", "txtHCP1", "txtHCP2", "HC Percent", "P", '<=lblHCP1.Text %>');
            RadioDate("rdbLstHCRelief", "txtHCRelief1", "txtHCRelief2", "HC Relief", "P", '<=lblHCRelief1.Text %>');
            RadioDate("rdbLstCollected", "txtCollected1", "txtCollected2", "Subrogation Collected", "P", '<=lblCollected1.Text %>');
            RadioDate("rdbLstTotalCharged", "txtTotalCharged1", "txtTotalCharged2", "Total Charged", "P", '<=lblTotalCharged1.Text %>');
            */


            if (Type == "S") {
                var i;
                var lstOutput = document.getElementById('ctl00_ContentPlaceHolder1_lstOutputFields').options;
                var outf = "";
                for (i = 0; i < lstOutput.length; i++)
                    outf += (outf == "") ? lstOutput[i].value : "," + lstOutput[i].value;
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
                    if (parseFloat(obj1.value) > parseFloat(obj.value))
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
                <table cellpadding="2" cellspacing="1" width="100%" align="center">
                    <tr>
                        <td width="100%">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="lc" style="width: 15%;">
                                        <strong style="color: #666666;">Date Claim Opened : </strong>
                                    </td>
                                    <td style="width: 35%;">
                                        <asp:RadioButtonList ID="lstClaimEntered" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
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
                                        <asp:Label ID="lblDateEnteredFrom" runat="server" Text="On Date : " ForeColor="#666666"
                                            Font-Bold="true"></asp:Label>
                                    </td>
                                    <td width="13%">
                                        <asp:TextBox ID="txtDate_Entered_From" runat="server" SkinID="txtdate" Width="80px"
                                            MaxLength="10"></asp:TextBox>
                                        <img alt="Date Claim Opened" id="imgDate_Entered_From" onclick="return showCalendar('<%=txtDate_Entered_From.ClientID%>', 'mm/dd/y','','');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                            align="middle" />
                                    </td>
                                    <td style="width: 8%;" valign="middle">
                                        <asp:Label ID="lblDateEnteredTo" runat="server" Text="Start Date :" ForeColor="#666666"
                                            Font-Bold="true"></asp:Label>
                                    </td>
                                    <td style="width: 9%;">
                                        <asp:TextBox ID="txtDate_Entered_To" runat="server" SkinID="txtdate" Width="80px"
                                            MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td style="width: 12%;">
                                        <img alt="Date Claim Opened" id="imgDate_Entered_To" runat="server" onclick="return showCalendar('<%=txtDate_Opened_To.ClientID%>', 'mm/dd/y','','');"
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
                        <td colspan="10" width="100%">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="lc" style="width: 15%;">
                                        <strong style="color: #666666;">Date of Incident : </strong>
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
                                        <strong style="color: #666666;">Date Claim Reopened : </strong>
                                    </td>
                                    <td style="width: 35%;">
                                        <asp:RadioButtonList ID="lstClaimReOpened" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
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
                                        <asp:Label ID="lblDateOfClaimReopenedFrom" runat="server" Text="On Date :" ForeColor="#666666"
                                            Font-Bold="true"></asp:Label>
                                    </td>
                                    <td width="13%">
                                        <asp:TextBox ID="txtDateOfClaimReopenedFrom" runat="server" SkinID="txtdate" Width="80px"
                                            MaxLength="10"></asp:TextBox>
                                        <img alt="Valued as of Date" onclick="return showCalendar('<%=txtDateOfClaimReopenedFrom.ClientID%>', 'mm/dd/y','','');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                            align="middle" />
                                    </td>
                                    <td width="8%" valign="middle">
                                        <asp:Label ID="lblDateOfClaimReopenedTo" runat="server" Text="Start Date :" ForeColor="#666666"
                                            Font-Bold="true"></asp:Label>
                                    </td>
                                    <td style="width: 9%;">
                                        <asp:TextBox ID="txtDateofClaimReopenedTo" runat="server" SkinID="txtdate" Width="80px" MaxLength="10" Height="23px"></asp:TextBox>
                                    </td>
                                    <td style="width: 12%;">
                                        <img alt="Valued as of Date" id="imgDate_ClaimReopend_To" runat="server" onclick="return showCalendar('<%=txtDateValuedTo.ClientID%>', 'mm/dd/y','','');"
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
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="50%">
                                        <strong style="color: #666666;">Location :
                                            <asp:CheckBox ID="chkLocation" runat="server" />Select/Deselect All</strong><br />
                                        <asp:ListBox ID="lstLocation" SelectionMode="Multiple" runat="server" Width="350px"></asp:ListBox>
                                    </td>
                                    <td width="50%" valign="top">
                                        <strong style="color: #666666;">Status :</strong>
                                        <br />
                                        <asp:DropDownList ID="ddlStatus" runat="server" AppendDataBoundItems="true" SkinID="dropGen">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 5px;"></td>
                    </tr>


                    <%--<tr>
                        <td style="padding-top: 5px;">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 50%;" align="left">
                                        <asp:Panel ID="pnlMedicalPaid" runat="server" Width="100%">
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="lc" align="left" style="width: 30%; font-weight: bold;">
                                                        Total Medical Paid:
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
                                                    <td class="lc" align="left" style="width: 30%; font-weight: bold;">
                                                        Total Comp:
                                                    </td>
                                                    <td class="ic" align="left" style="width: 70%;">
                                                        <asp:RadioButtonList ID="rdbLstComp" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstComp_SelectedIndexChanged">
                                                            <asp:ListItem Text="Greater Than" Value="G" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="L"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lc" align="left" colspan="2" style="font-weight: bold;">
                                                        <asp:Label ID="lblTotalComp1" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtTotalComp1" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                            SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblTotalComp2" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtTotalComp2" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
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
                                                    <td class="lc" align="left" style="width: 30%; font-weight: bold;">
                                                        Total Reserve:
                                                    </td>
                                                    <td class="ic" align="left" style="width: 70%;">
                                                        <asp:RadioButtonList ID="rdbLstTotalReserve" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstTotalReserve_SelectedIndexChanged">
                                                            <asp:ListItem Text="Greater Than" Value="G" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="L"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lc" align="left" colspan="2" style="font-weight: bold;">
                                                        <asp:Label ID="lblTotalRes1" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtTotalRes1" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                            SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblTotalRes2" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtTotalRes2" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
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
                                                <td class="lc" align="left" style="width: 30%; font-weight: bold;">
                                                    Unlimited Cost:
                                                </td>
                                                <td class="ic" align="left" style="width: 70%;">
                                                    <asp:RadioButtonList ID="rdbLstUnlimitedCost" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                                        OnSelectedIndexChanged="rdbLstUnlimitedCost_SelectedIndexChanged">
                                                        <asp:ListItem Text="Greater Than" Value="G" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                        <asp:ListItem Text="Less Than" Value="L"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" align="left" colspan="2" style="font-weight: bold;">
                                                    <asp:Label ID="lblUnlimitedCost1" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtUnlimitedCost1" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                    <asp:Label ID="lblUnlimitedCost2" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtUnlimitedCost2" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 50%;" align="left">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="lc" align="left" style="width: 30%; font-weight: bold;">
                                                    Limited To MV:
                                                </td>
                                                <td class="ic" align="left" style="width: 70%;">
                                                    <asp:RadioButtonList ID="rdbLstLimitedToMV" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                                        OnSelectedIndexChanged="rdbLstLimitedToMV_SelectedIndexChanged">
                                                        <asp:ListItem Text="Greater Than" Value="G" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                        <asp:ListItem Text="Less Than" Value="L"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" align="left" colspan="2" style="font-weight: bold;">
                                                    <asp:Label ID="lblLimitedToMV1" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtLimitedToMV1" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                    <asp:Label ID="lblLimitedToMV2" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtLimitedToMV2" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
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
                                                <td class="lc" align="left" style="width: 30%; font-weight: bold;">
                                                    HC Percent:
                                                </td>
                                                <td class="ic" align="left" style="width: 70%;">
                                                    <asp:RadioButtonList ID="rdbLstHCP" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                                        OnSelectedIndexChanged="rdbLstHCP_SelectedIndexChanged">
                                                        <asp:ListItem Text="Greater Than" Value="G" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                        <asp:ListItem Text="Less Than" Value="L"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" align="left" colspan="2" style="font-weight: bold;">
                                                    <asp:Label ID="lblHCP1" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtHCP1" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                    <asp:Label ID="lblHCP2" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtHCP2" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 50%;" align="left">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="lc" align="left" style="width: 30%; font-weight: bold;">
                                                    HC Relief:
                                                </td>
                                                <td class="ic" align="left" style="width: 70%;">
                                                    <asp:RadioButtonList ID="rdbLstHCRelief" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                                        OnSelectedIndexChanged="rdbLstHCRelief_SelectedIndexChanged">
                                                        <asp:ListItem Text="Greater Than" Value="G" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                        <asp:ListItem Text="Less Than" Value="L"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" align="left" colspan="2" style="font-weight: bold;">
                                                    <asp:Label ID="lblHCRelief1" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtHCRelief1" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                    <asp:Label ID="lblHCRelief2" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtHCRelief2" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
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
                                                <td class="lc" align="left" style="width: 30%; font-weight: bold;">
                                                    Subrogation Collected:
                                                </td>
                                                <td class="ic" align="left" style="width: 70%;">
                                                    <asp:RadioButtonList ID="rdbLstCollected" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                                        OnSelectedIndexChanged="rdbLstCollected_SelectedIndexChanged">
                                                        <asp:ListItem Text="Greater Than" Value="G" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                        <asp:ListItem Text="Less Than" Value="L"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" align="left" colspan="2" style="font-weight: bold;">
                                                    <asp:Label ID="lblCollected1" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtCollected1" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                    <asp:Label ID="lblCollected2" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtCollected2" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 50%;" align="left">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="lc" align="left" style="width: 30%; font-weight: bold;">
                                                    Total Charged:
                                                </td>
                                                <td class="ic" align="left" style="width: 70%;">
                                                    <asp:RadioButtonList ID="rdbLstTotalCharged" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                                        OnSelectedIndexChanged="rdbLstTotalCharged_SelectedIndexChanged">
                                                        <asp:ListItem Text="Greater Than" Value="G" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                        <asp:ListItem Text="Less Than" Value="L"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lc" align="left" colspan="2" style="font-weight: bold;">
                                                    <asp:Label ID="lblTotalCharged1" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtTotalCharged1" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                    <asp:Label ID="lblTotalCharged2" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtTotalCharged2" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                        SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>                                
                            </table>
                        </td>
                    </tr>--%>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="lc" align="left" style="width: 30%; font-weight: bold;">Total Paid To Date:
                        </td>
                        <td class="ic" align="left" style="width: 70%;">
                            <asp:RadioButtonList ID="rdbLstTotalCharged" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                OnSelectedIndexChanged="rdbLstTotalCharged_SelectedIndexChanged">
                                <asp:ListItem Text="Greater Than" Value="G" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                <asp:ListItem Text="Less Than" Value="L"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" align="left" colspan="2" style="font-weight: bold;">
                            <asp:Label ID="lblTotalCharged1" runat="server"></asp:Label>
                            <asp:TextBox ID="txtTotalCharged1" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                SkinID="txtAmt" MaxLength="15"></asp:TextBox>
                            <asp:Label ID="lblTotalCharged2" runat="server"></asp:Label>
                            <asp:TextBox ID="txtTotalCharged2" runat="server" ValidationGroup="vsErrorGroup" onKeyPress="return(currencyFormat(this,',','.',event))"
                                SkinID="txtAmt" MaxLength="15"></asp:TextBox>
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
                            <asp:ListBox ID="lstOutputFields" runat="server" SelectionMode="Multiple" Height=" 150px"></asp:ListBox>
                            <asp:ImageButton ID="imgUp" ImageUrl="~/Images/up-arrow.gif" runat="server" ImageAlign="top"
                                OnClientClick="return MoveItemUp();" />
                            <asp:ImageButton ID="imgDown" ImageUrl="~/Images/down-arrow.gif" runat="server" ImageAlign="top"
                                OnClientClick="return MoveItemDown();" />
                        </td>
                        <td class="ic" style="width: 25%" align="left">
                            <asp:ListBox ID="lstFirstSort" runat="server" Height="150px" AutoPostBack="false"
                                SelectionMode="Single" onclick="javascript:return ListFirst(this.id,this.selectedIndex);"></asp:ListBox>
                        </td>
                        <td class="ic" style="width: 25%" align="left">
                            <asp:ListBox ID="lstSecondSort" runat="server" Height="150px" AutoPostBack="false"
                                SelectionMode="Single" onclick="javascript:return ListSecond(this.id,this.selectedIndex);"></asp:ListBox>
                        </td>
                        <td class="ic" style="width: 25%" align="left">
                            <asp:ListBox ID="lstThirdSort" runat="server" Height="150px" AutoPostBack="false"
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
