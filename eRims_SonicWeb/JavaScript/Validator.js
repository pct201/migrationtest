//to use below function add following line
//onkeypress="return CheckMaxLength(event, this,255);" onchange="return CheckMaxLength(event, this,255);"
// where 255 is number of characters
function CheckMaxLength(e, txt, max) {

    if (txt.value.length >= max && e.keyCode != 8)
    { txt.value = txt.value.substring(0, max); return false; }
    else { return true; }
}

function FormatZipCode(e, ctrlID) {

    if ((event.keyCode <= 47) || (event.keyCode > 58) || (event.keyCode == 58)) {
        if (event.keyCode != 46) {
            event.cancelBubble = true;
            event.returnValue = false;
        }
    }

    var ctrlValue = document.getElementById(ctrlID).value;

    if (e.keyCode == 45 || e.which == 45) // don't allow to press -  
    {
        return false;
    }
    else if (ctrlValue.length == 5) {
        if (e.which) {
            if (e.which == 8) {
                return true;
            }
        }
        ctrlValue = ctrlValue + "-";
        document.getElementById(ctrlID).value = ctrlValue;
        return true;
    }
}

function AlertValidation(RequiredAttachTypeID, RequiredAttachFileID) {
    ValidatorEnable(document.getElementById(RequiredAttachTypeID), false);
    ValidatorEnable(document.getElementById(RequiredAttachFileID), false);
    Page_ClientValidate();

    if (Page_IsValid == false) {
        //alert("There are invalid entries on this screen, in order to save the data, please provide a valid enty for the fields marked with '!!'");
        return false;
    }
    else
        return true;
}

function FormatPhone(e, ctrlID) {
    if ((e.keyCode == 45) || ((e.keyCode >= 48) && (e.keyCode < 58))) {
        var ctrlValue = document.getElementById(ctrlID).value;
        if ((ctrlValue.length <= 3 || ctrlValue.length <= 7 || ctrlValue.length >= 7) && (e.keyCode == 45 || e.which == 45)) {
            return false;
        }
        else if (ctrlValue.length == 3 || ctrlValue.length == 7) {
            if (e.which) {
                if (e.which == 8) {
                    return true;
                }
            }

            ctrlValue = ctrlValue + "-";
            document.getElementById(ctrlID).value = ctrlValue;
            return true;
        }
    }
    else
        return false;
}

function FormatLongitude(e, ctrlID) {    
    var bNegative = false;
    if ((e.keyCode == 45) || ((e.keyCode >= 48) && (e.keyCode < 58))) {
        var ctrlValue = document.getElementById(ctrlID).value;
        var strSub = ctrlValue.substring(0, 1);

        if (e.keyCode == 45 && strSub != "-") {
            var ch = String.fromCharCode(e.keyCode);
            ctrlValue = ch + ctrlValue;

            if (ctrlValue.indexOf('-') > -1)
                bNegative = true;

            if (bNegative) {
                document.getElementById(ctrlID).value = ctrlValue;
                return false;
            }
            else
                return false;

        }

        if (strSub == "-") {
            if ((ctrlValue.length <= 4 || ctrlValue.length <= 7 || ctrlValue.length >= 7) && (e.keyCode == 45 || e.which == 45)) {
                return false;
            }
            else if (ctrlValue.length == 4 || ctrlValue.length == 7) {
                if (e.which) {
                    if (e.which == 8) {
                        return true;
                    }
                }
                ctrlValue = ctrlValue + ":";
            }
        }
        else if (strSub != "-" && strSub != "") {
            if ((ctrlValue.length <= 3 || ctrlValue.length <= 6 || ctrlValue.length >= 6) && (e.keyCode == 45 || e.which == 45)) {
                return false;
            }
            else if ((ctrlValue.length == 9)) {
                return false;
            }
            else if (ctrlValue.length == 3 || ctrlValue.length == 6) {
                if (e.which) {
                    if (e.which == 8) {
                        return true;
                    }
                }
                ctrlValue = ctrlValue + ":";
            }
        }

        document.getElementById(ctrlID).value = ctrlValue;
        return true;
    }
    else {
        return false;
    }
}

function FormatInteger(e) {
    if (e.keyCode >= 48 && e.keyCode <= 57) {
        return true;
    }
    else {
        return false;
    }
}

function selectionStartF(element) {
    element.focus();
    var sel = document.selection.createRange();
    sel.text = "~|~";
    var start = element.value.indexOf("~|~");
    sel.moveStart("character", -3);
    sel.text = "";
    return start;
}

function selectionEndF(element) {
    element.focus();
    var sel = document.selection.createRange();
    var len = sel.text.length;
    sel.text = "~|~";
    var start = element.value.indexOf("~|~");
    sel.moveStart("character", -3);
    sel.text = "";
    return start + len;
}

function SetCurrencyFocus(elem, caretPos) {

    if (elem.createTextRange) {
        var range = elem.createTextRange();
        range.move('character', caretPos);
        range.select();
    }
    else {
        if (elem.selectionStart) {
            elem.focus();
            elem.setSelectionRange(caretPos, caretPos);
        }
        else
            elem.focus();
    }

}

function FormatNumber(e, ctrlID, intMaxAllowedLen, bIsPerfectNumber) {

    var ctrlValue = document.getElementById(ctrlID).value;
    var dotSepetator = ctrlValue.split('.');


    if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.which >= 48 && e.which <= 57)) {
        ctrlValue = ctrlValue.replace(/,/g, '');

        var intLen = ctrlValue.length;

        if (ctrlValue.length == 1 && ctrlValue.indexOf('0') > -1) {
            return false;
        }
        if (!bIsPerfectNumber && dotSepetator.length > 1) {
            if (dotSepetator[1].length == 2) {
                if (dotSepetator[0].replace(/,/g, '').length == intMaxAllowedLen - 2)
                    return false;
            }
            else if (dotSepetator[1].length > 2)
                return false;
            else
                return true;
        }
        else if (!bIsPerfectNumber && dotSepetator.length == 1) {
            if (ctrlValue.length == intMaxAllowedLen - 2)
                return false;
        }
        else if (bIsPerfectNumber && intLen == intMaxAllowedLen)
            return false;

        if (!bIsPerfectNumber) ctrlValue = dotSepetator[0].replace(/,/g, '');


        if (ctrlValue.length >= 3) {
            var newValue = '';
            var j = (ctrlValue.length % 3) + 1;
            for (i = 0; i <= ctrlValue.length - 2; i++) {
                while (j <= ctrlValue.length - 2) {
                    if (ctrlValue.length >= 6) {
                        newValue += ctrlValue.substring(i, j) + ",";
                        i = j;
                        j = j + 3;
                    }
                    else {
                        newValue = ctrlValue.substring(i, j) + ",";
                        j++;
                    }
                }
                if (i == ctrlValue.length - 2)
                    newValue += ctrlValue.substring(i);
            }

            newValue = newValue + String.fromCharCode(e.keyCode);

            if (!bIsPerfectNumber && dotSepetator.length > 1) {
                newValue = newValue + "." + dotSepetator[1];
            }
            document.getElementById(ctrlID).value = newValue;
            return false;
        }


    }
    else {

        if (e.keyCode == 44 || e.which == 44)
            return false;
        else if (e.which) {
            if (e.which == 8)
                return true;
        }

        if (ctrlValue.length == 0) {
            return false;
        }
        else if (bIsPerfectNumber && (e.keyCode == 46 || e.which == 46)) {
            return false;
        }
        else {
            if (ctrlValue.indexOf('.') > 0 && (e.keyCode == 46 || e.which == 46)) {
                return false;
            }
            else if (e.keyCode == 46 || e.which == 46)
                return true;
            else
                return false;
        }
    }
}
function FormatNumberToDec(e, ctrlID, intMaxAllowedLen, bIsPerfectNumber, DecPoint) {
    var ctrlValue = document.getElementById(ctrlID).value;
    var dotSepetator = ctrlValue.split('.');

    var bNegative = false;

    if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.which >= 48 && e.which <= 57)) {
        var element = document.getElementById(ctrlID);
        var ch = String.fromCharCode(e.keyCode);
        var begin = this.selectionStartF(element);
        var end = this.selectionEndF(element);
        ctrlValue = element.value.substr(0, begin) + ch + element.value.substr(end, element.value.length);
        ctrlValue = ctrlValue.replace(/,/g, '');
        var stringAfterCursor = element.value.substr(end, element.value.length);
        var curPosition = (element.value.substr(0, begin) + ch).length;

        if (ctrlValue.indexOf('-') > -1)
            bNegative = true;

        if (bNegative) ctrlValue = ctrlValue.replace('-', '');

        var intLen = ctrlValue.length;

        //zero pressed
        if (e.keyCode == 48) {
            if (ctrlValue == "0" || ctrlValue == "0.0" || ctrlValue == "0.00")
                return true;
            else if (ctrlValue.length > 1 && ctrlValue.indexOf('0') == 0)
                return false;
        }

        if (ctrlValue.length > intMaxAllowedLen)
            return false;

        if (!bIsPerfectNumber && dotSepetator.length > 1) {
            if (dotSepetator[1].length == DecPoint && (ctrlValue.substring(0, ctrlValue.indexOf('.')).length >= intMaxAllowedLen - DecPoint))
                return false;
            else if (ctrlValue.substring(ctrlValue.indexOf('.') + 1).length > DecPoint)
                return false;
        }
        else if (!bIsPerfectNumber && dotSepetator.length <= 1) {
            if (ctrlValue.length >= intMaxAllowedLen - DecPoint)
                return false;
        }
        else if (bIsPerfectNumber && intLen >= intMaxAllowedLen)
            return false;


        if (!bIsPerfectNumber && ctrlValue.indexOf('.') > 0) {
            dotSepetator[1] = ctrlValue.substring(ctrlValue.indexOf('.') + 1);
            ctrlValue = ctrlValue.substring(0, ctrlValue.indexOf('.'));
        }

        if (ctrlValue.length > 3) {
            var newValue = '';
            var commaInserted = 0;
            var rem = (ctrlValue.length % 3);
            var j = (rem == 0) ? 3 : rem;
            for (i = 0; i <= ctrlValue.length - 3; i++) {
                while (j <= ctrlValue.length - 3) {
                    if (ctrlValue.length >= 7) {
                        newValue += ctrlValue.substring(i, j) + ",";
                        i = j;
                        j = j + 3;
                        commaInserted++;
                    }
                    else {
                        newValue = ctrlValue.substring(i, j) + ",";
                        j++;
                        commaInserted++;
                    }
                }
                if (i == ctrlValue.length - 3)
                    newValue += ctrlValue.substring(i);
            }

            if (!bIsPerfectNumber && dotSepetator.length > 1) {
                newValue = newValue + "." + dotSepetator[1];
            }

            if (bNegative) newValue = "-" + newValue;
            document.getElementById(ctrlID).value = newValue;



            SetCurrencyFocus(element, commaInserted > 0 ? (stringAfterCursor != '' ? curPosition : curPosition + 1) : (curPosition + 1));

            return false;
        }
    }
    else {

        if (e.keyCode == 44 || e.which == 44)
            return false;
        else if (e.which) {
            if (e.which == 8)
                return true;
        }

        if (e.keyCode == 45) {
            if (ctrlValue.indexOf('-') == -1) {
                ctrlValue = '-' + ctrlValue;
                document.getElementById(ctrlID).value = ctrlValue;
                return false;
            }
            else
                return false;
        }

        if (ctrlValue.length == 0) {
            return false;
        }
        else if (bIsPerfectNumber && (e.keyCode == 46 || e.which == 46)) {
            return false;
        }
        else {
            if (ctrlValue.indexOf('.') > 0 && (e.keyCode == 46 || e.which == 46)) {
                return false;
            }
            else if (e.keyCode == 46 || e.which == 46)
                return true;
            else
                return false;
        }

    }
}
function CountAge(Args) {
    var arrCtrlIDs = Args.split(',');
    var ControlID = arrCtrlIDs[0];
    var TargetControlID = arrCtrlIDs[1];
    var BTextBox = document.getElementById(ControlID);
    var AgeBox = document.getElementById(TargetControlID);
    if (BTextBox != null || AgeBox != null) {
        var bDate = new Date(BTextBox.value);
        var now = new Date();
        bday = (bDate.getDate());
        bmo = (bDate.getMonth());
        byr = (bDate.getFullYear());
        tday = now.getDate();
        tmo = (now.getMonth());
        tyr = (now.getFullYear());
        if (bDate > now) {
            alert('Birth Date must be less than current date');
            var mn;
            if (now.getMonth() + 1 < 9) {
                mn = '0' + (now.getMonth() + 1);
            }
            else {
                mn = now.getMonth() + 1;
            }
            //            BTextBox.value=mn + '/' + tday + '/' + tyr;
            //            AgeBox.innerText = "0";
            document.getElementById(ControlID).focus();
            return false;
        }
        bmo = bmo - 1;
        if ((tmo > bmo) || (tmo == bmo & tday >= bday))
        { age = byr; }
        else
        { age = byr + 1; }
        AgeBox.innerText = tyr - age;
        return true;
    }
}

function setTextFoucs(Args) {
    var txtsDate = document.getElementById(Args);
    if (txtsDate.value != null && txtsDate.value.trim() != '') {
        txtsDate.focus();
    }
}


function setTermsInManthEndDate(Args) {
    var arrCtrlIDs = Args.split(',');
    var CtrStartDate = arrCtrlIDs[0];
    var CtrEndDate = arrCtrlIDs[1];
    var TargetControlID = arrCtrlIDs[2];

    var inttype = arrCtrlIDs[3];
    var txtTemsinMonth = document.getElementById(TargetControlID);
    var txtsDate = document.getElementById(CtrStartDate);
    var txtEDate = document.getElementById(CtrEndDate);

    if (inttype == 0) {
        if (txtsDate.value != null && txtsDate.value.trim() != '') {
            if (txtTemsinMonth.value != null && txtTemsinMonth.value.trim() != '') {
                if (isDate(txtsDate.value)) {
                    var strterms = txtTemsinMonth.value;
                    var strsub = strterms.indexOf('.');
                    var intmonth = 0;
                    var intdays = 0;
                    if (parseInt(strsub) > -1) {
                        intmonth = strterms.substring(0, parseInt(strsub));
                        intdays = strterms.substring(parseInt(strsub) + 1, parseInt(strsub) + 3);
                        if (intdays.length > 1) {
                            intdays = parseInt(intdays) * 0.3;
                        }
                        else {
                            intdays = parseInt(intdays) * 3;
                        }
                        intdays = parseInt(intdays - 1);
                    }
                    else {
                        intmonth = txtTemsinMonth.value;
                        intdays = 0;
                    }
                    sDate = new Date(txtsDate.value);
                    eDate = new Date(sDate.setMonth(parseInt(sDate.getMonth()) + parseInt(intmonth)));
                    fEdate = new Date(eDate.setDate(parseInt(eDate.getDate()) + parseInt(intdays)));
                    txtEDate.value = fEdate.format("MM/dd/yyyy");
                }
            }
        }
    }
    else if (inttype == 1) {
        if (txtsDate.value != null && txtsDate.value.trim() != '') {
            if (txtEDate.value != null && txtEDate.value.trim() != '') {
                if (isDate(txtsDate.value) && isDate(txtEDate.value)) {
                    var user_date = Date.parse(txtEDate.value);
                    var today_date = Date.parse(txtsDate.value);
                    var diff_date = user_date - today_date;
                    var num_month = diff_date / 2628000000;
                    // var num_month = diff_date/86400000 - for a day;                               
                    var strterms = num_month.toString();
                    var strsub = strterms.indexOf('.');
                    var intmonth = 0;
                    var intdays = 0;
                    if (parseInt(strsub) > -1) {
                        intmonth = strterms.substring(0, parseInt(strsub));
                        intdays = strterms.substring(parseInt(strsub) + 1, parseInt(strsub) + 3);
                        strterms = intmonth + '.' + intdays;
                    }
                    if (parseFloat(strterms) < 0) {
                        txtTemsinMonth.value = "0";
                        alert("End Date Should Be Greater Than Start Date");
                    }
                    else {
                        txtTemsinMonth.value = strterms;
                    }
                }
            }
        }
    }
    else if (inttype == 3) {
        if (txtsDate.value != null && txtsDate.value.trim() != '') {
            if (txtEDate.value != null && txtEDate.value.trim() != '') {
                if (isDate(txtsDate.value) && isDate(txtEDate.value)) {
                    var user_date = Date.parse(txtEDate.value);
                    var today_date = Date.parse(txtsDate.value);
                    var diff_date = user_date - today_date;
                    var num_month = diff_date / 2628000000;
                    // var num_month = diff_date/86400000 - for a day;                               
                    var strterms = num_month.toString();
                    var strsub = strterms.indexOf('.');
                    var intmonth = 0;
                    var intdays = 0;
                    if (parseInt(strsub) > -1) {
                        intmonth = strterms.substring(0, parseInt(strsub));
                        intdays = strterms.substring(parseInt(strsub) + 1, parseInt(strsub) + 3);
                        strterms = intmonth + '.' + intdays;
                    }
                    if (parseFloat(strterms) < 0) {
                        txtTemsinMonth.value = "0";
                    }
                    else {
                        txtTemsinMonth.value = strterms;
                        txtsDate.focus();
                    }
                }
            }
            else {
                txtsDate.focus();
            }
        }

    }
    else {
        if (txtsDate.value != null && txtsDate.value.trim() != '') {
            if (isDate(txtsDate.value)) {
                if (txtTemsinMonth.value != null && txtTemsinMonth.value.trim() != '') {
                    var strterms = txtTemsinMonth.value;
                    var strsub = strterms.indexOf('.');
                    var intmonth = 0;
                    var intdays = 0;
                    if (parseInt(strsub) > -1) {
                        intmonth = strterms.substring(0, parseInt(strsub));
                        intdays = strterms.substring(parseInt(strsub) + 1, parseInt(strsub) + 3);
                        if (intdays.length > 1) {
                            intdays = parseInt(intdays) * 0.3;
                        }
                        else {
                            intdays = parseInt(intdays) * 3;
                        }
                        intdays = parseInt(intdays - 1);
                    }
                    else {
                        intmonth = txtTemsinMonth.value;
                        intdays = 0;
                    }
                    sDate = new Date(txtsDate.value);
                    eDate = new Date(sDate.setMonth(parseInt(sDate.getMonth()) + parseInt(intmonth)));
                    fEdate = new Date(eDate.setDate(parseInt(eDate.getDate()) + parseInt(intdays)));
                    txtEDate.value = fEdate.format("MM/dd/yyyy");
                }
                else if (txtEDate.value != null && txtEDate.value.trim() != '') {
                    if (isDate(txtEDate.value)) {
                        var user_date = Date.parse(txtEDate.value);
                        var today_date = Date.parse(txtsDate.value);
                        var diff_date = user_date - today_date;
                        var num_month = diff_date / 2628000000;
                        // var num_month = diff_date/86400000 - for a day;                               
                        var strterms = num_month.toString();
                        var strsub = strterms.indexOf('.');
                        var intmonth = 0;
                        var intdays = 0;
                        if (parseInt(strsub) > -1) {
                            intmonth = strterms.substring(0, parseInt(strsub));
                            intdays = strterms.substring(parseInt(strsub) + 1, parseInt(strsub) + 3);
                            strterms = intmonth + '.' + intdays;
                        }
                        if (parseInt(strterms) < 0) {
                            txtTemsinMonth.value = "0";
                            alert("End Date Should Be Greater Than Start Date");
                        }
                        else {
                            txtTemsinMonth.value = strterms;
                        }
                    }
                }
            }
        }
    }
}

function GetDaysDiff(Args) {
    var arrCtrlIDs = Args.split(',');
    var CtrStartDate = arrCtrlIDs[0];
    var CtrEndDate = arrCtrlIDs[1];
    var TargetControlID = arrCtrlIDs[2];

    var txtTemsinMonth = document.getElementById(TargetControlID);
    var txtsDate = document.getElementById(CtrStartDate);
    var txtEDate = document.getElementById(CtrEndDate);

    if (txtEDate.value != null && txtEDate.value.trim() != '' && txtsDate.value != null && txtsDate.value.trim() != '') {
        if (isDate(txtEDate.value) && isDate(txtsDate.value)) {
            var user_date = Date.parse(txtEDate.value);
            var today_date = Date.parse(txtsDate.value);
            var diff_date = user_date - today_date;
            var num_month = diff_date / 864e5;
            // var num_month = diff_date/86400000 - for a day;                               
            var strterms = num_month.toString();
            var strsub = strterms.indexOf('.');
            var intmonth = 0;
            var intdays = 0;
            if (parseInt(strsub) > -1) {
                intmonth = strterms.substring(0, parseInt(strsub));
                intdays = strterms.substring(parseInt(strsub) + 1, parseInt(strsub) + 3);
                strterms = intmonth + '.' + intdays;
            }
            if (parseFloat(strterms) < 0) {
                txtTemsinMonth.value = "0";
            }
            else {
                txtTemsinMonth.value = strterms;
            }
        }
    }

}


function makeTwoDigit(inValue) {
    var numVal = parseInt(inValue, 10);
    if (numVal < 10) {
        return ("0" + numVal);
    }
    else {
        return numVal;
    }
}

// return 0 if equal
// return 1 if dt2 > dt1
// return -1 if dt2 < dt1
function compareDate(dt1, dt2) {
    dtStart = new Date(dt1);
    dtEnd = new Date(dt2);


    var dstart = dtStart.getDate();
    var mstart = dtStart.getMonth() + 1;
    var ystart = dtStart.getFullYear();

    var dEnd = dtEnd.getDate();
    var mEnd = dtEnd.getMonth() + 1;
    var yEnd = dtEnd.getFullYear();

    dstart = makeTwoDigit(dstart);
    mstart = makeTwoDigit(mstart);

    dEnd = makeTwoDigit(dEnd);
    mEnd = makeTwoDigit(mEnd);

    if (yEnd < ystart) {
        return -1;
    }
    else if (yEnd == ystart) {
        if (mEnd < mstart) {
            return -1;
        }
        else if (mEnd == mstart) {
            if (dEnd < dstart) {
                return -1;
            }
            else if (dEnd == dstart) {
                return 0;
            }
            else {
                return 1;
            }
        }
        else {
            return 1;
        }
    }
    else {
        return 1;
    }

}

function CompareDateLessThanToday(id) {
    if (document.getElementById(id).value == "__/__/____")
        document.getElementById(id).value = "";
    if ((document.getElementById(id).value) != '') {
        if (ValidateDate(document.getElementById(id).value) == true) {
            var bDate = new Date(document.getElementById(id).value);
            var now = new Date();
            if (bDate > now) {
                alert('Date must be less than current date');
                document.getElementById(id).focus();
                return false;
            }
        }
        else {
            alert('Date is not valid.');
            document.getElementById(id).focus();
            return false;
        }
    }
}
function CompareDateGreaterThanToday(id) {
    if (document.getElementById(id).value == "__/__/____")
        document.getElementById(id).value = "";
    if ((document.getElementById(id).value) != '') {
        if (ValidateDate(document.getElementById(id).value) == true) {
            var bDate = new Date(document.getElementById(id).value);
            var now = new Date();
            if (bDate < now) {
                alert('Date must be greater than current date');
                document.getElementById(id).focus();
                return false;
            }
        }
        else {
            alert('Date is not valid.');
            document.getElementById(id).focus();
            return false;
        }
    }
}

function CompareDateLessThanTodayNoAlert(ctl) {
    if (ctl == "__/__/____")
        ctl = "";

    if (ctl != '') {
        var bDate = new Date(ctl);
        var now = new Date();
        if (bDate > now) {
            return false;
        }
        return true;
    }
}
function CompareDateGreaterThanTodayNoAlert(ctl) {
    var bDate = new Date(ctl.value);
    var now = new Date();

    if (bDate < now) {
        return false;
    }

    return true;
}

function YearRange(ctl, FromLimit, ToLimit) {
    if (ctl.value != '') {
        var FrmLmt = parseInt(FromLimit);
        var ToLmt = parseInt(ToLimit);
        var Val = parseInt(ctl.value.replace(/,/g, ''));
        if (Val < FrmLmt || Val > ToLmt) {
            alert('Year range must be between ' + FromLimit + ' to ' + ToLimit + '.');
            ctl.focus();
            return false;
        }
    }
}

function ValueRange(ctl, FromLimit, ToLimit) {
    if (ctl.value != '') {
        var FrmLmt = Number(FromLimit);
        var ToLmt = Number(ToLimit);
        var Val = Number(ctl.value.replace(/,/g, ''));
        if (Val < FrmLmt || Val > ToLmt) {
            alert('range must be between ' + FromLimit + ' to ' + ToLimit + '.');
            ctl.focus();
            return false;
        }
    }
}

function ShowDialog(navigateurl) {
    var w = 480, h = 340;


    if (document.all || document.layers) {
        w = screen.availWidth;
        h = screen.availHeight;
    }

    var leftPos, topPos;
    var popW = 550, popH = 400;
    if (document.all)
    { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
    else
    { leftPos = w / 2; topPos = h / 2; }

    window.open(navigateurl, "popup", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
}

function ShowDialogCOI(navigateurl) {
    var w = 480, h = 340;


    if (document.all || document.layers) {
        w = screen.availWidth;
        h = screen.availHeight;
    }

    var leftPos, topPos;
    var popW = 670, popH = 500;
    if (document.all)
    { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
    else
    { leftPos = w / 2; topPos = h / 2; }

    window.open(navigateurl, "popup", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
}

function checkYearRange(id) {
    var bDate = new Date(document.getElementById(id).value);
    if (bDate.getFullYear() > 2018 || bDate.getFullYear() < 1945) {
        alert('Year range must be between 1945 to 2018.');
        document.getElementById(id).focus();
        return false;
    }
}

//  Remove leading whitespace

function LTrim(value) {
    var re = /\s*((\S+\s*)*)/;
    return value.replace(re, "$1");
}

// Removes ending whitespaces
function RTrim(value) {
    var re = /((\s*\S+)*)\s*/;
    return value.replace(re, "$1");
}

// Removes leading and ending whitespaces
function trim(value) {
    return LTrim(RTrim(value));
}

/*
Date validation Function
Added On 06-Oct-2008
 
*/
var calDateFormat = 'mm/dd/yyyy'; // default value for dateformat.actually date format is passed from code behind.
var splitchar = '/';

function CheckValidDate(ctrlID) {
    var ctrlValue = document.getElementById(ctrlID).value;
    //setSplitChar(); // set split character in date format for future use as per date format set.   

    var retVal = IsValidDate(ctrlValue);
    if (retVal != '') {
        alert(retVal);
        document.getElementById(ctrlID).value = '';
        document.getElementById(ctrlID).focus();
        return false;
    }
    else {
        return true;
    }
}

function IsValidDate(strDate) {
    // dave must be a valid value.   
    if (strDate == null || strDate == '' || strDate == 'undefined' || strDate == undefined) {
        return '';
    }

    // date must have all 3 parts,day-month-year.
    var arDt = strDate.split(splitchar);

    if (arDt.length != 3) {
        return 'Invalid Date Format';
    }



    // get day,month and year
    var D = arDt[GetDayPosition() - 1];
    var M = arDt[GetMonthPosition() - 1];
    var Yr = arDt[GetYearPosition() - 1];

    // all values must be numeric
    if (IsNumeric(D) == false || IsNumeric(M) == false || IsNumeric(Yr) == false) {
        return 'All the characters for Day,Month and Year should be Numeric';
    }


    // get actual value like for " 01 , get 1.

    D = parseFloat(D);
    M = parseFloat(M);
    Yr = parseFloat(Yr);



    // get days in month to check weather it's valid or not.
    var days = getDaysInMonth(M, Yr);

    if (D < 1 || D > days) {
        return 'Invalid Day Specified for the Selected Month';
    }
    if (M > 12 || M < 1) {
        return 'Invalid Month Specified';
    }

    //1st jan 1753 - minvalue
    //31st dec 9999 - max value
    // any date from year 1753 is valid
    // any date up to 31st dec 9999 is valid.
    if (Yr < 1753 || Yr > 9999) {
        return 'Year should be in the range of 1753 - 9999';

    }

    return ''; // success      
}

function FormatDate(e, ctrlID) {
    if (e.keyCode == 47 || e.which == 47) {
        // don't allow split character.
        return false;
    }
    else {

        var ctrlValue = document.getElementById(ctrlID).value;
        if (IsNumeric(String.fromCharCode(e.keyCode))) {
            if (ctrlValue.length == 10) return false;
            if (ctrlValue.length == 2 || ctrlValue.length == 5) {
                if (e.which) {
                    if (e.which == 8) {
                        return true;
                    }
                }
                ctrlValue = ctrlValue + splitchar;
                document.getElementById(ctrlID).value = ctrlValue;
                return true;
            }
        }
        else
            return false;
    }
}


function GetDayPosition() {
    if (calDateFormat.indexOf('d') == 0) {
        return 1;
    }
    else if (calDateFormat.indexOf('d') > 7) {
        return 3;
    }
    else {
        return 2;
    }
}

function GetMonthPosition() {
    if (calDateFormat.indexOf('m') == 0) {
        return 1;
    }
    else if (calDateFormat.indexOf('m') > 7) {
        return 3;
    }
    else {
        return 2;
    }
}

function GetYearPosition() {
    if (calDateFormat.indexOf('y') == 0) {
        return 1;
    }
    else if (calDateFormat.indexOf('y') > 5) {
        return 3;
    }
    else {
        return 2;
    }
}

function IsNumeric(strString) {
    var strValidChars = "0123456789";
    var strChar;
    var blnResult = true;

    if (strString.length == 0) return false;

    //  test strString consists of valid characters listed above</font>
    for (i = 0; i < strString.length && blnResult == true; i++) {
        strChar = strString.charAt(i);
        if (strValidChars.indexOf(strChar) == -1) {
            blnResult = false;
        }
    }
    return blnResult;
}

function getDaysInMonth(month, year) {
    var days;
    if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 ||
        month == 10 || month == 12) {
        days = 31;
    }
    else if (month == 4 || month == 6 || month == 9 || month == 11) {
        days = 30;
    }
    else if (month == 2) {
        if (isLeapYear(year)) {
            days = 29;
        }
        else {
            days = 28;
        }
    }
    return (days);
}

function isLeapYear(Year) {

    if (((Year % 4) == 0) && ((Year % 100) != 0) || ((Year % 400) == 0)) {
        return (true);
    }
    else {
        return (false);
    }
}
function isFourDigitYear(year) {
    if (year.length != 4) {
        document.getElementById('year').value = calDate.getFullYear();
        document.getElementById('year').select();
        document.getElementById('year').focus();
    }
    else {
        return true;
    }
}


function RemoveCommas(ctrlValue) {
    ctrlValue = ctrlValue.replace(/,/g, '');
    return ctrlValue;
}

/* ----- Function to format amount in currency ------- */
function formatCurrency(num) {
    num = num.toString().replace(/\$|\,/g, '');
    if (isNaN(num))
        num = "0";

    sign = (num == (num = Math.abs(num)));
    num = Math.floor(num * 100 + 0.50000000001);
    cents = num % 100;
    num = Math.floor(num / 100).toString();

    if (cents < 10)
        cents = "0" + cents;

    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
        num = num.substring(0, num.length - (4 * i + 3)) + ',' +

    num.substring(num.length - (4 * i + 3));

    return (((sign) ? '' : '-') + '$' + num + '.' + cents);
}


function CurrencyFormatted(amount) {
    var i = parseFloat(amount);
    if (isNaN(i)) { i = 0.00; }
    var minus = '';
    if (i < 0) { minus = '-'; }
    i = Math.abs(i);

    i = parseInt((i + .005) * 100);


    i = i / 100;
    s = new String(i);
    if (s.indexOf('.') < 0) { s += '.00'; }
    if (s.indexOf('.') == (s.length - 2)) { s += '0'; }
    s = minus + s;
    return s;
}

function InsertCommas(decValue) {
    var ctrlValue = decValue;
    var strNewValue = '';
    var strDotSeperator = ctrlValue.toString().split('.');

    ctrlValue = strDotSeperator[0];
    var intLen = ctrlValue.length;

    if (intLen >= 4) {
        while (ctrlValue >= 1000) {
            var div = ctrlValue / 1000;
            var strValues = div.toString().split('.');
            if (strValues.length > 1) {
                var intMult = (strValues[1].length == 1) ? 100 : ((strValues[1].length == 2) ? 10 : 1);
                if (strValues[1].length == 3 && strValues[1].indexOf("0") == 0)
                    strNewValue = "," + strValues[1] + strNewValue;
                else {
                    intMult = Number(strValues[1]) * intMult;
                    if (strValues[1].length == 2 && strValues[1].indexOf("0") == 0)
                        strNewValue = ",0" + intMult + strNewValue;
                    else
                        strNewValue = "," + intMult + strNewValue;
                }
            }
            else
                strNewValue = ",000" + strNewValue;

            ctrlValue = strValues[0];
        }

        strNewValue = ctrlValue + strNewValue;
        if (strDotSeperator.length > 1) {
            strNewValue += "." + strDotSeperator[1];
        }
        return strNewValue;
    }
    else
        return decValue;
}

function IsNumericWithAlert(decValue) {
    var RegEx = /^[+-]?\d+(\.\d+)?([-+]?\d+)?$/;

    if (!RegEx.test(decValue)) {
        alert('Not a valid Nubmer');
        return false;
    }
}

function IsNumericNoAlert(decValue) {
    var RegEx = /^[+-]?\d+(\.\d+)?([-+]?\d+)?$/;

    return RegEx.test(decValue);
}

function LimitCurrencyFormat(fld, milSep, decSep, len, e) {
    if (fld.value.length >= len)
        return false;
    else return currencyFormat(fld, milSep, decSep, e);

}


function currencyFormat(fld, milSep, decSep, e) {

    var sep = 0;
    var key = '';
    var i = j = 0;
    var len = len2 = 0;
    var strCheck = '0123456789';
    var aux = aux2 = '';
    var whichCode = (window.Event) ? e.which : e.keyCode;
    if (whichCode == null)
        whichCode = e.keyCode;
    if (whichCode == 13) return true;  // Enter
    if (whichCode == 8) return true;  // Delete (Bug fixed)
    if (whichCode == 0) return true;
    if (fld.value.length > 12) return false;
    key = String.fromCharCode(whichCode);  // Get key value from key code
    if (strCheck.indexOf(key) == -1) return false;  // Not a valid key
    len = fld.value.length;
    for (i = 0; i < len; i++)
        if ((fld.value.charAt(i) != '0') && (fld.value.charAt(i) != decSep)) break;
    aux = '';
    for (; i < len; i++)
        if (strCheck.indexOf(fld.value.charAt(i)) != -1) aux += fld.value.charAt(i);
    aux += key;
    len = aux.length;
    if (len == 0) fld.value = '';
    if (len == 1) fld.value = '0' + decSep + '0' + aux;
    if (len == 2) fld.value = '0' + decSep + aux;
    if (len > 2) {
        aux2 = '';
        for (j = 0, i = len - 3; i >= 0; i--) {
            if (j == 3) {
                aux2 += milSep;
                j = 0;
            }
            aux2 += aux.charAt(i);
            j++;
        }
        fld.value = '';
        len2 = aux2.length;
        for (i = len2 - 1; i >= 0; i--)
            fld.value += aux2.charAt(i);
        fld.value += decSep + aux.substr(len - 2, len);
    }
    return false;
}

function currencyFormat_New(fld, milSep, decSep, len_val, e) {

    var sep = 0;
    var key = '';
    var i = j = 0;
    var len = len2 = 0;
    var strCheck = '0123456789';
    var aux = aux2 = '';
    var whichCode = (window.Event) ? e.which : e.keyCode;
    if (whichCode == null)
        whichCode = e.keyCode;
    if (whichCode == 13) return true;  // Enter
    if (whichCode == 8) return true;  // Delete (Bug fixed)
    if (whichCode == 0) return true;
    var baseVal = fld.value;
    baseVal = baseVal.replace(/,/g, '');
    if (baseVal.length > len_val) return false;
    key = String.fromCharCode(whichCode);  // Get key value from key code
    if (strCheck.indexOf(key) == -1) return false;  // Not a valid key
    len = fld.value.length;
    for (i = 0; i < len; i++)
        if ((fld.value.charAt(i) != '0') && (fld.value.charAt(i) != decSep)) break;
    aux = '';
    for (; i < len; i++)
        if (strCheck.indexOf(fld.value.charAt(i)) != -1) aux += fld.value.charAt(i);
    aux += key;
    len = aux.length;
    if (len == 0) fld.value = '';
    if (len == 1) fld.value = '0' + decSep + '0' + aux;
    if (len == 2) fld.value = '0' + decSep + aux;
    if (len > 2) {
        aux2 = '';
        for (j = 0, i = len - 3; i >= 0; i--) {
            if (j == 3) {
                aux2 += milSep;
                j = 0;
            }
            aux2 += aux.charAt(i);
            j++;
        }
        fld.value = '';
        len2 = aux2.length;
        for (i = len2 - 1; i >= 0; i--)
            fld.value += aux2.charAt(i);
        fld.value += decSep + aux.substr(len - 2, len);
    }
    return false;
}

function SelectDeselectAllSonicNotes(bChecked) {
    var ctrls = document.getElementsByTagName('input');
    var i, chkID;
    var cnt = 0;
    chkID = "chkSelectSonicNotes";
    for (i = 0; i < ctrls.length; i++) {
        if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf(chkID) > 0) {
            ctrls[i].checked = bChecked;
        }
    }
}

function SelectDeselectNoteHeader() {
    var ctrls = document.getElementsByTagName('input');
    var i, chkID;
    var cnt = 0;
    chkID = "chkSelectSonicNotes";
    for (i = 0; i < ctrls.length; i++) {
        if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf(chkID) > 0) {
            if (ctrls[i].checked)
                cnt++;
        }
    }

    var rowCnt = document.getElementById('ctl00_ContentPlaceHolder1_ctrlSonicNotes_gvNotes').rows.length - 1;

    var headerChkID = 'chkMultiSelectSonicNotes';

    if (cnt == rowCnt)
        document.getElementById(headerChkID).checked = true;
    else
        document.getElementById(headerChkID).checked = false;
}

function currencyFormatNegetive(fld, milSep, decSep, e) {
    var sep = 0;
    var key = '';
    var i = j = 0;
    var len = len2 = 0;
    var strCheck = '0123456789';
    var aux = aux2 = '';
    var isNegetive = false;
    var oldValue = '';
    var whichCode = (window.Event) ? e.which : e.keyCode;

    if (whichCode == 13) return true;  // Enter
    if (whichCode == 8) return true;  // Delete (Bug fixed)
    if (whichCode == 0) return true;

    key = String.fromCharCode(whichCode);  // Get key value from key code
    isNegetive = fld.value.indexOf('-') > -1;

    if (key == '-') {
        if (trim(fld.value) == '')
            fld.value = '-';

        if (fld.value == 0)
            return false;

        if (fld.value.indexOf('-') == -1)
            fld.value = '-' + fld.value;
        return false;
    }

    if (fld.value.length > 13) return false;

    if (strCheck.indexOf(key) == -1) return false;  // Not a valid key

    if (isNegetive)
        fld.value = fld.value.substring(1, fld.value.length);

    len = fld.value.length;

    for (i = 0; i < len; i++)
        if ((fld.value.charAt(i) != '0') && (fld.value.charAt(i) != decSep)) break;

    aux = '';

    for (; i < len; i++)
        if (strCheck.indexOf(fld.value.charAt(i)) != -1) aux += fld.value.charAt(i);

    aux += key;
    len = aux.length;
    if (len == 0) fld.value = '';
    if (len == 1) fld.value = '0' + decSep + '0' + aux;
    if (len == 2) fld.value = '0' + decSep + aux;
    if (len > 2) {
        aux2 = '';
        for (j = 0, i = len - 3; i >= 0; i--) {
            if (j == 3) {
                aux2 += milSep;
                j = 0;
            }
            aux2 += aux.charAt(i);
            j++;
        }
        fld.value = '';
        len2 = aux2.length;
        for (i = len2 - 1; i >= 0; i--)
            fld.value += aux2.charAt(i);
        fld.value += decSep + aux.substr(len - 2, len);
    }

    if (isNegetive)
        fld.value = '-' + fld.value;
    return false;
}