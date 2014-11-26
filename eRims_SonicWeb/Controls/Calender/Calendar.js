// JScript File
var x, y;
window.onload = init;
function init() 
{
if (window.Event) 
{
document.captureEvents(Event.MOUSEMOVE);
}
document.onmousemove = getXY;
}
function getXY(e) 
{
x = (window.Event) ? e.pageX : event.clientX;
y = (window.Event) ? e.pageY : event.clientY;
}

// settings for browser.
var isNav = false;
var divEle;
var isIE  = false;
if (navigator.appName == "Netscape")
{
    isNav = true;
}
else 
{
    isIE = true;
}

function CalForm_SetElementHeight(element, height) {
    if (element && element.style) {
        element.style.height = height + "px";
    }
}
function CalForm_SetElementWidth(element, width) {
    if(width < 0)
        return;    
    if (element && element.style) 
    {
        element.style.width = width + "px";     
    }
}
function CalForm_SetElementX(element, x) {
    if (element && element.style) {
        element.style.left = x + "px";
    }
}
function CalForm_SetElementY(element, y) {
    if (element && element.style) {
        element.style.top = y + "px";
    }
}

function CalForm_GetElementPosition(element) {
    var result = new Object();
    result.x = 0;
    result.y = 0;
    result.width = 0;
    result.height = 0;
    if (element.offsetParent) {
        result.x = element.offsetLeft;
        result.y = element.offsetTop;
        var parent = element.offsetParent;
        while (parent) {
            result.x += parent.offsetLeft;
            result.y += parent.offsetTop;
            var parentTagName = parent.tagName.toLowerCase();
            if (parentTagName != "table" &&
                parentTagName != "body" && 
                parentTagName != "html" && 
                parentTagName != "div" && 
                parent.clientTop && 
                parent.clientLeft) {
                result.x += parent.clientLeft;
                result.y += parent.clientTop;
            }
            parent = parent.offsetParent;
        }
    }
    else if (element.left && element.top) {
        result.x = element.left;
        result.y = element.top;
    }
    else {
        if (element.x) {
            result.x = element.x;
        }
        if (element.y) {
            result.y = element.y;
        }
    }
    if (element.offsetWidth && element.offsetHeight) {
        result.width = element.offsetWidth;
        result.height = element.offsetHeight;
    }
    else if (element.style && element.style.pixelWidth && element.style.pixelHeight) {
        result.width = element.style.pixelWidth;
        result.height = element.style.pixelHeight;
    }
    return result;
}

function CalForm_GetElementById(elementId) {
    if (document.getElementById) {
        return document.getElementById(elementId);
    }
    else if (document.all) {
        return document.all[elementId];
    }
    else return null;
}


var objTxtDate = null; // text box object
var calDateFormat = 'mm/dd/yyyy'; // default value for dateformat.actually date format is passed from code behind.
var splitchar = '/';

var CompareCurrentDate = 'False'; // needed if we have to compare 2 dates.
var StartDateId = ''; // needed if we have to compare 2 dates and current date is End Date.
var MsgStartDate = ''; // for start date comparision violation message
var EndDateId = ''; // needed if we have to compare 2 dates and current date is Start Date.
var MsgEndDate = '' // for end date comparision violation message.

var calDate = null; // date variable that holds current selected date if it's in textbox,else current date on client machine.all process is done using this variable.
var blankCell ='';
//var monthArray; // used to store array of Month Full Names like(january,february,etc.)

// start,end elements,generate days list.
// called only once when JS is loaded.
InitializeCalenderStartEnd();

// displays calender
function showCalendar(objTxt,div,e)
{
    objTxtDate = objTxt; // set text box object.        
    divEle = document.getElementById(div);   
    var calDoc = GetCalHTML(); // get complete calender content.
    
    // show div with content
    divEle.innerHTML = calDoc;
    divEle.style.display = "block";
    divEle.style.visibility = "visible";        
    divEle.style.display = "inline";  
    
    // set offset variables
    var scrOfX = 0, scrOfY = 0;
    if( typeof( window.pageYOffset ) == 'number' ) 
    {
        //Netscape compliant
        scrOfY = window.pageYOffset;
        scrOfX = window.pageXOffset;
    } 
    else if( document.body && ( document.body.scrollLeft || document.body.scrollTop ) ) 
    {
        //DOM compliant
        scrOfY = document.body.scrollTop;
        scrOfX = document.body.scrollLeft;
    } 
    else if( document.documentElement && ( document.documentElement.scrollLeft || document.documentElement.scrollTop ) ) 
    {
        //IE6 standards compliant mode
        scrOfY = document.documentElement.scrollTop;
        scrOfX = document.documentElement.scrollLeft;
    }
    
    // set position  
    if(isIE)
    { 
        divEle.style.top = scrOfY + y;
        divEle.style.left = scrOfX + x;
    }
    else
    { 
        divEle.style["top"] = y + "px";
        if (divEle.scrollWidth + x + 10 > document.body.scrollWidth)
            divEle.style["left"] = x - divEle.scrollWidth + "px";
        else
            divEle.style["left"] = x + 10 + "px";          
    }
    
              
    var z = 1000;
    var childFrameId = divEle.id + "_IFrame";
    var childFrame = CalForm_GetElementById(childFrameId);
    var parent = divEle.offsetParent;
    if (!childFrame) 
    {
        childFrame = document.createElement("iframe");
        childFrame.id = childFrameId;
        childFrame.src = "about:blank";
        childFrame.style.position = "absolute";
        childFrame.style.display = "none";
        childFrame.scrolling = "no";
        childFrame.frameBorder = "0";
        childFrame.style.width = 90;
        if (parent.tagName.toLowerCase() == "html") 
        {
            document.body.appendChild(childFrame);
        }
        else 
        {
            parent.appendChild(childFrame);
        }           
    }
    
    
    // setting height width
    var pos = CalForm_GetElementPosition(divEle);
    var parentPos = CalForm_GetElementPosition(parent);
    
    
    
    CalForm_SetElementWidth(childFrame, pos.width-100);
    CalForm_SetElementHeight(childFrame, pos.height);
    
    
    
    // setting position
    var cal_location = CalForm_GetElementPosition(objTxtDate);
    
    CalForm_SetElementX(childFrame, cal_location.x);
    CalForm_SetElementY(childFrame, cal_location.y+20); // 20 is height of textbox

    CalForm_SetElementX(divEle, cal_location.x);
    CalForm_SetElementY(divEle, cal_location.y+20);  // 20 is height of textbox

  
    
    
    childFrame.style.display = "block";
    if (divEle.currentStyle && divEle.currentStyle.zIndex) 
    {
        z = divEle.currentStyle.zIndex;
    }
    else if (divEle.style.zIndex) 
    {
        z = divEle.style.zIndex;
    }
    divEle.style.zIndex = z; 
    
    if(isIE)
    window.event.cancelBubble = true;      
    else 
    e.cancelBubble = true;
    
}

// returns complete calender HTML.
function GetCalHTML()
{
    // set date variables
    setDate();
    
    // get top frame with month and year set    
    var calDocTop = GetTopCalFrame();
    
    // get daynames and days.
    var calDocMiddle = GetCalendarContents();        
    
    // close and today buttons
    var calDocBottom = "<TR valign='middle'><TD valign='middle'><center><a class='lnkdate' href='javascript:void(0);' onClick='setToday()'>Today</a>&nbsp;&nbsp;<a class='lnkdate' href='javascript:void(0);'>|</a>&nbsp;&nbsp;<a class='lnkdate' href='javascript:void(0);' onClick='javascript:CloseCal();'>Close</a>&nbsp;&nbsp;<a href='javascript:void(0);' class='lnkdate'>|</a>&nbsp;&nbsp;<a href='javascript:void(0);' onClick='javascript:ClearDate();' class='lnkdate'>Clear</a></center></TD></TR><tr><td>&nbsp;</td></tr>"
    
    var calendar = "<TABLE CELLPADDING='0' CELLSPACING='0' class='calTableMain' BORDER='0' width='100%' align='center'><tr><td>" +
    calDocTop + "</td></tr><tr><td><div id='trBottom' width='100%'>" +calDocMiddle + "</div></td></tr><tr><td>&nbsp;</td></tr>" + calDocBottom + "</TABLE>";
    
    return calendar;
}

// if date is already selected it will set calDate = selected date, else calDate = current date on client machine.
// also it set the Variable that's used to find the selected date to be shown in calender while generating calender.
function setDate() 
{    
    var strDate = GetOriginalFormatDate(objTxtDate.value);
    if(strDate == '')
    {
        calDate = new Date();
    }
    else
    {
        calDate = new Date(strDate);  
    }
    calDay  = calDate.getDate(); // set day of month(value will be in range of 1 - 31);
    //calDate.setDate(1); // by default it sets day = 1. no matter what's current month and year.
}

// build Top Frame that contains Month Dropdown,year Drop Down and Navigation
function GetTopCalFrame() {    
    var calDoc = "<TABLE class='toprowmonthyear' CELLPADDING='0' CELLSPACING='0' BORDER='0' width='100%' align='center'>" +
        "<TR><TD width='10%' valign='middle' align='right'>" +
        "&nbsp;<a href='javascript:void(0);' class='lnknextprev' onClick='setPreviousMonth();'>&lt;&lt;</a>&nbsp;" +
        "</td><td width='24%'>" +
        getMonthSelect() + // get month dropdown or month textbox whatever is set,with selected date's month selected in it.
        "</td><td width='10%' valign='middle'>" +
        "&nbsp;<a href='javascript:void(0);' class='lnknextprev' onClick='setNextMonth();'>&gt;&gt;</a>&nbsp;" +
        "</td>" +
        "<td width='16%'>&nbsp;</td>" +
        "<td valign='middle' width='10%' align='right'>" +
        "&nbsp;<a href='javascript:void(0);' class='lnknextprev' onclick='setPreviousYear();'>&lt;&lt;</a>&nbsp;" +        
        "</td><td align=\"center\" width='20%'>" + // calDate.getFullYear() - gives 4 digit year.
        "<INPUT id='year' name='year' VALUE='" + calDate.getFullYear() + "' readonly='readonly' type='text' size='4' maxlength='4' onChange='setYear()' class='yearcss'>" +
        "</td><td valign='middle' width='10%'>" +
        "&nbsp;<a href='javascript:void(0);'  class='lnknextprev' onClick='setNextYear();'>&gt;&gt;</a>&nbsp;" +
        "</TD>" +
        "</TR>" +
        "</TABLE>";
    return calDoc;    
}

// build calender,(dayname and days)
function GetCalendarContents() {       
    var calDoc = calendarBegin; // get top frame that contains daysnames
    month   = calDate.getMonth();// 0 to 11;
    year    = calDate.getFullYear();// 4 digit year.
    day     = calDay; // day set in setDate function.
    
    var i   = 0;    
    var days = getDaysInMonth(month+1,year);
    if (day > days) {
        day = days;
    }    
    
    var firstOfMonth = new Date(year, month, 1); 
    
    // returns day of week on which current date comes. first day of week  is considered sunday.
    // if days column needed to be displayed in some other sequence, start position needed to be changed.      
    var startingPos  = firstOfMonth.getDay();            
    startingPos--; // first day of week need to be Monday.
    
    
    days += startingPos; // add starting postion to days...so while looping it will be easy,it will show 31 at 35 if starting pos. is 4.
    
    var columnCount = 0; // used to find weather it's sunday column or not.
    
    // set cell those comes before start day of month.
    for (i = 0; i < startingPos; i++) {        
        calDoc += blankCell;        
		columnCount++;
    }
    
    var currentDay = 0;
    var dayType = "weekday";
    for (i = startingPos; i < days; i++) 
    {
        currentDay = i-startingPos+1;
        if (currentDay == day) 
        {
            dayType = "activedatecell";
        }
        else if (columnCount % 7 == 0) 
        {
            dayType = "sundaycell";
        }
        else 
        {
            dayType = "weekdaycell";
        }
        
        calDoc += "<TD class='" + dayType + "' align='center' onclick='returnDate("+currentDay+");' onmouseover=\"javascript:setovercss(this,'"+dayType+"');\" onmouseout=\"javascript:setmouseoutcss(this,'"+dayType+"');\">" +
                  "<a href='javascript:void(0);' class='lnkdate'>"+currentDay+"</a></TD>";
        columnCount++;        
        // if it's last column,move to next line.
		if (columnCount % 7 == 0) 
		{
            calDoc += "</TR><TR>";
        }
    }
    // max 6 rows,so 42 is max value.
    for (i=days; i<42; i++)  
    {
        calDoc += blankCell;    
        columnCount++;
        if (columnCount % 7 == 0) 
        {
            calDoc += "</TR>";
            if(i<41) 
            {
                calDoc += "<TR>";
            }
        }
    }
    calDoc += calendarEnd;
    return calDoc;
}

function setovercss(obj,classname)
{
    obj.className = classname+'over';    
}
function setmouseoutcss(obj,classname)
{
    obj.className = classname;    
}

function getMonthSelect() {
    monthArray = new Array('January', 'February', 'March', 'April', 'May', 'June','July', 'August', 'September', 'October', 'November', 'December');
    var activeMonth = calDate.getMonth(); // set value of current month,range(0 - 11).
    
    // show month in textbox..
    monthSelect = "<input type='text' id='monthText' name='monthText' value='" + monthArray[activeMonth] + "' readonly='readonly' style='display:none;width:70px;' class='monthcss'/>"
    
    // show month in dropdown.
    monthSelect += "<SELECT id='month' name='month' onChange='setCurrentMonth();' class='monthcss'>";    
    for (i in monthArray) {        
        if (i == activeMonth) {
            monthSelect += "<OPTION SELECTED>" + monthArray[i] + "</OPTION>\n";
        }
        else {
            monthSelect += "<OPTION>" + monthArray[i] + "</OPTION>\n";
        }
    }
    monthSelect += "</SELECT>";    
    //alert(monthSelect);
    return monthSelect;
    
}

// returns week days list like M,T,W,T,F,S,S -- top row of calendar for showing days.
// called only once when JS is loaded. from InitializeCalenderStartEnd() function.
function GetWeekdayList() {
        weekdayList = new Array('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday','Sunday');
        weekdayArray = new Array('Mon','Tue','Wed','Thu','Fri','Sat','Sun');
	    var weekdays = "<TR>";
        for (i in weekdayArray) {

            weekdays += "<td class='daynames'>" + weekdayArray[i] + "</td>";
        }
        weekdays += "</TR>";    
        return weekdays;
}

// start,end elements,generate days list.
// called only once when JS is loaded.
function InitializeCalenderStartEnd() 
{
        
    // initialize blank cell    
    blankCell = "<TD align=center style='background-color:#B7CA97;'></TD>";    
    
    // calendar begin
    var weekdays = GetWeekdayList();    
    calendarBegin = "<CENTER>";
    if (isNav) 
    {
        calendarBegin += "<TABLE CELLPADDING=0 CELLSPACING=0 BORDER=0 ALIGN=CENTER width=100%><TR><TD>";
    }
    calendarBegin += "<TABLE class='daysgrid' align='center' 'width=100%'>" + weekdays;    
    // calender end
    calendarEnd = "";      
    if (isNav) 
    {
        calendarEnd += "</TD></TR></TABLE>";
    }
    calendarEnd += "</TABLE>" + "</CENTER>";
}
function jsReplace(inString, find, replace) {
    var outString = "";
    if (!inString) {
        return "";
    }
    if (inString.indexOf(find) != -1) {
        t = inString.split(find);
        return (t.join(replace));
    }
    else {
        return inString;
    }
}

// used to change calender ,when next,prev. etc. is called.
function writeCalendar()
{
    var calDocBottom = GetCalendarContents();
    document.getElementById('trBottom').innerHTML = calDocBottom;
}

function setToday() 
{
    returnDate(-1)
}

function setYear() 
{    
    var year  = document.getElementById('year').value;
    if (isFourDigitYear(year)) 
    {
        calDate.setFullYear(year);
        writeCalendar();
    }
    else
    {
        document.getElementById('year').focus();
        document.getElementById('year').select();
    }
}

function setCurrentMonth()
{
    var month = document.getElementById('month').selectedIndex;    
    calDate.setMonth(month);
    writeCalendar();
}

function setPreviousYear() 
{    
    var year  = document.getElementById('year').value;
    if (isFourDigitYear(year) && year > 1000)
    {
        year--;
        calDate.setFullYear(year);
        document.getElementById('year').value = year;
        writeCalendar();
    }
}

function setPreviousMonth() {
    var year  = document.getElementById('year').value;
    if (isFourDigitYear(year)) {
        var month = document.getElementById('month').selectedIndex;
        if (month == 0) {
            month = 11;
            if (year > 1000) {
                year--;
                calDate.setFullYear(year);
                document.getElementById('year').value = year;
            }
        }
        else {
            month--;
        }
        calDate.setMonth(month);
        document.getElementById('month').selectedIndex = month;
        document.getElementById('monthText').value = monthArray[month];
        writeCalendar();
    }
}

function setNextMonth() {
    var year = document.getElementById('year').value;
    if (isFourDigitYear(year)) {
        var month = document.getElementById('month').selectedIndex;
        if (month == 11) {
            month = 0;
            year++;
            calDate.setFullYear(year);
            document.getElementById('year').value = year;
        }
        else {
            month++;
        }
        calDate.setMonth(month);
        document.getElementById('month').selectedIndex = month;
        document.getElementById('monthText').value = monthArray[month];
        writeCalendar();
    }
}

function setNextYear() {
    var year  = document.getElementById('year').value;
    if (isFourDigitYear(year)) {
        year++;
        calDate.setFullYear(year);
        document.getElementById('year').value = year;
        writeCalendar();
    }
}

function getDaysInMonth(month,year)  {
    var days;    
    if (month==1 || month==3 || month==5 || month==7 || month==8 ||
        month==10 || month==12)  {
        days=31;
    }
    else if (month==4 || month==6 || month==9 || month==11) {
        days=30;
    }
    else if (month==2)  {
        if (isLeapYear(year)) {
            days=29;
        }
        else {
            days=28;
        }
    }
    return (days);
}
function isLeapYear (Year) {

    if (((Year % 4)==0) && ((Year % 100)!=0) || ((Year % 400)==0)) {
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

function makeTwoDigit(inValue) 
{
    var numVal = parseInt(inValue, 10);
    if (numVal < 10) {
        return("0" + numVal);
    }
    else {
        return numVal;
    }
}
function getMonthThreeChars(inValue)
{
    var numVal = parseInt(inValue, 10);
    return monthArray[numVal - 1];
}

function returnDate(inDay)
{
    
    if ( inDay == -1 )
    {
		calDate  = new Date()
    }
    else
    {
		calDate.setDate(inDay);
	}
		
	var day           = calDate.getDate();
	var month         = calDate.getMonth() +1 ;
	var year          = calDate.getFullYear();
    outDate = calDateFormat;    
    day = makeTwoDigit(day);
    month = makeTwoDigit(month);
    outDate = jsReplace(outDate, "dd", day);        
    //month = getMonthThreeChars(month);    
    outDate = jsReplace(outDate, "mm", month);
    
    outDate = jsReplace(outDate, "yyyy", year);
    var valid = true;
    if(CompareCurrentDate == 'True')
    {
        if(ValidateCurrentDate(day,month,year) == false)
        {
            valid = false;
            alert("Selected date should be greater than or equal to Current Date");
        }        
    }    
    if(valid == true)
    {
        if(StartDateId != '')
        {
            var objStartDate = document.getElementById(StartDateId);
             if(objStartDate.value != '')
             {
                var startDate = GetOriginalFormatDate(objStartDate.value);
                var endDate = GetOriginalFormatDate(outDate);
                if(compareDate(startDate,endDate) < 0)
                {
                    valid = false;
                    alert(MsgStartDate);
                }      
             }             
        }
    }
    if(valid == true)
    {
        if(EndDateId != '')
        {
            var objEndDate = document.getElementById(EndDateId);
             if(objEndDate.value != '')
             {
                var startDate = GetOriginalFormatDate(outDate);
                var endDate = GetOriginalFormatDate(objEndDate.value);
                if(compareDate(startDate,endDate) < 0)
                {
                    valid = false;
                    alert(MsgEndDate);
                }      
             }             
        }
    }    
    if(valid == true)
    {
        objTxtDate.value = outDate;
        document.getElementById("dvComments_IFrame").style.display = "none";
        divEle.style.display = "none";
    }
}

function CloseCal()
{
    document.getElementById("dvComments_IFrame").style.display = "none";
    divEle.style.display = "none";
}

// returns date in mm/dd/yyyy format
function GetOriginalFormatDate(dt)
{   
    if(dt == null || dt == '' || dt == 'undefined' || dt == undefined)
    {
        return '';
    }   
    var dtReturn = '';
    var arDt = dt.split(splitchar);
    var NewDay = arDt[GetDayPosition()-1]; 
    var NewMonth = arDt[GetMonthPosition()-1];
    var NewYear = arDt[GetYearPosition()-1];
    dtReturn = NewMonth + '/' + NewDay + '/' + NewYear;        
    return dtReturn;
}

function ValidateCurrentDate(d,m,y)
{
    var isvalid = true;    
    dtToday = new Date();
    var cd = dtToday.getDate();
	var cm = dtToday.getMonth()+1;
	var cy = dtToday.getFullYear();    
    cd = makeTwoDigit(cd);
    cm = makeTwoDigit(cm);    
    if(y < cy)
    {
        isvalid = false;
    }    
    else if(y == cy)
    {
        if(m < cm)
        {
            isvalid = false;
        }
        else if(m == cm)
        {
            if(d < cd)
            {
                isvalid = false;
            }            
        }
    }    
    return isvalid;
}
// return 0 if equal
// return 1 if dt2 > dt1
// return -1 if dt2 < dt1
function compareDate(dt1,dt2)
{
    dtStart = new Date(dt1);
    dtEnd = new Date(dt2);
            
    
    var dstart = dtStart.getDate();
	var mstart = dtStart.getMonth()+1;
	var ystart = dtStart.getFullYear();
	
	var dEnd = dtEnd.getDate();
	var mEnd = dtEnd.getMonth()+1;
	var yEnd = dtEnd.getFullYear();    
	
    dstart = makeTwoDigit(dstart);
    mstart = makeTwoDigit(mstart);
    
    dEnd = makeTwoDigit(dEnd);
    mEnd = makeTwoDigit(mEnd);
    
    if(yEnd < ystart)
    {
        return -1;
    }    
    else if(yEnd == ystart)
    {
        if(mEnd < mstart)
        {
            return -1;
        }
        else if(mEnd == mstart)
        {
            if(dEnd < dstart)
            {
                return -1;
            }
            else if(dEnd == dstart)
            {
                return 0;
            }            
            else
            {
                return 1;
            }
        }
        else
        {
            return 1;
        }
    } 
    else
    {
        return 1;
    }       
    
}

function ClearDate()
{
    objTxtDate.value = '';    
    CloseCal();
}
function OpenCalender(idTxtDate,divid,objevent,_CompareCurrentDate,_StartDateClientId,_MsgStartDate,_EndDateClientId,_MsgEndDate,_DisplayDateFormat)
{
       
    CompareCurrentDate = _CompareCurrentDate; // needed if we have to compare 2 dates.
    StartDateId = _StartDateClientId; // needed if we have to compare 2 dates and current date is End Date.
    MsgStartDate = _MsgStartDate; // for start date comparision violation message
    EndDateId = _EndDateClientId; // needed if we have to compare 2 dates and current date is Start Date.
    MsgEndDate = _MsgEndDate // for end date comparision violation message.   
    if(_DisplayDateFormat != undefined && _DisplayDateFormat != '')
        calDateFormat = _DisplayDateFormat.toLowerCase(); // set date format
    setSplitChar(); // set split character in date format for future use as per date format set.   
    
    //divid id of div,in which calender will be created.
    var obj = document.getElementById(idTxtDate); 
    showCalendar(obj,divid,objevent);
}
function setSplitChar()
{
    if(calDateFormat.indexOf('-') != -1)
    {
        splitchar = '-';
    }
    if(calDateFormat.indexOf('/') != -1)
    {
        splitchar = '/';
    }
}
// get positions of date,month and year in dateformat
// 1,2 or 3.
function GetDayPosition()
{
    if(calDateFormat.indexOf('d')==0)
    {
        return 1;
    }
    else if(calDateFormat.indexOf('d') > 7)
    {
        return 3;
    }
    else
    {
        return 2;
    }
}
function GetMonthPosition()
{
   if(calDateFormat.indexOf('m')==0)
    {
        return 1;
    }
    else if(calDateFormat.indexOf('m') > 7)
    {
        return 3;
    }
    else
    {
        return 2;
    }
}
function GetYearPosition()
{
   if(calDateFormat.indexOf('y')==0)
    {
        return 1;
    }
    else if(calDateFormat.indexOf('y') > 5)
    {
        return 3;
    }
    else
    {
        return 2;
    }
}

// function is used to format the date characters enetered by user if it's not readonly.
function FormatDate(e,ctrlID)
{
    if(e.keyCode == 47 || e.which == 47)
    {
        // don't allow split character.
        return false;
    }
    var ctrlValue = document.getElementById(ctrlID).value;            
    if(ctrlValue.length == 2 || ctrlValue.length == 5)
    {
        if(e.which)
        {
            if(e.which == 8)
            {
                return true;
            }
        }
        ctrlValue = ctrlValue + splitchar;        
        document.getElementById(ctrlID).value = ctrlValue;
        return true;
    }    
}


function IsValidDate(strDate)
{    
   // dave must be a valid value.   
    if(strDate == null || strDate == '' || strDate == 'undefined' || strDate == undefined)
    {
        return '';
    } 
    
    // date must have all 3 parts,day-month-year.
    var arDt = strDate.split(splitchar);
    
    if(arDt.length != 3)
    {
   
        return 'Invalid Date Format';
    }
    
    // get day,month and year
    var D = arDt[GetDayPosition()-1]; 
    var M = arDt[GetMonthPosition()-1];
    var Yr = arDt[GetYearPosition()-1];      
    
    // all values must be numeric
    if(IsNumeric(D) == false || IsNumeric(M) == false || IsNumeric(Yr) == false)
    {
        return 'All the characters for Day,Month and Year should be Numeric';         
    }   
    
    
    // get actual value like for " 01 , get 1.
    
    D = parseFloat(D);
    M = parseFloat(M);
    Yr = parseFloat(Yr);
    
    // get days in month to check weather it's valid or not.
    var days = getDaysInMonth(M,Yr);     
    
    if(D < 1 || D > days)
    {
        return 'Invalid Day Specified for the Selected Month';        
    }
    if(M > 12 || M < 1)
    {
        return 'Invalid Month Specified';
    }
    
    //1st jan 1753 - minvalue
    //31st dec 9999 - max value
    // any date from year 1753 is valid
    // any date up to 31st dec 9999 is valid.
    if(Yr < 1753 || Yr > 9999)
    {
        return 'Year should be in the range of 1753 - 9999';
        
    }      
    
    // check entered date should be greater than current date - if needed not in all cases
    if(CompareCurrentDate == 'True')
    {
        if(ValidateCurrentDate(D,M,Yr) == false)
        {
            return "Selected date should be greater than or equal to Current Date";
        }        
    }        
    if(StartDateId != '')
    {
        var objStartDate = document.getElementById(StartDateId);
         if(objStartDate.value != '')
         {
            var startDate = GetOriginalFormatDate(objStartDate.value);            
            var endDate = GetOriginalFormatDate(strDate);            
            if(compareDate(startDate,endDate) < 0)
            {
                return MsgStartDate;
            }      
         }             
    }
    
    if(EndDateId != '')
    {
        var objEndDate = document.getElementById(EndDateId);
         if(objEndDate.value != '')
         {
            var startDate = GetOriginalFormatDate(strDate);            
            var endDate = GetOriginalFormatDate(objEndDate.value);            
            if(compareDate(startDate,endDate) < 0)
            {
                return MsgEndDate;
            }      
         }             
    }
    
    return ''; // success      
}

function IsNumeric(strString)   
   {
	var strValidChars = "0123456789";
	var strChar;
	var blnResult = true;

	if (strString.length == 0) return false;

	//  test strString consists of valid characters listed above</font>
	for (i = 0; i < strString.length && blnResult == true; i++)
		{
		strChar = strString.charAt(i);
		if (strValidChars.indexOf(strChar) == -1)
			{
				blnResult = false;
			}
		}
	return blnResult;
   }
   
function CheckValidDate(ctrlID,_CompareCurrentDate,_StartDateClientId,_MsgStartDate,_EndDateClientId,_MsgEndDate,_DisplayDateFormat)
{
    var ctrlValue = document.getElementById(ctrlID).value;
    
    CompareCurrentDate = _CompareCurrentDate; // needed if we have to compare 2 dates.
    StartDateId = _StartDateClientId; // needed if we have to compare 2 dates and current date is End Date.
    MsgStartDate = _MsgStartDate; // for start date comparision violation message
    EndDateId = _EndDateClientId; // needed if we have to compare 2 dates and current date is Start Date.
    MsgEndDate = _MsgEndDate // for end date comparision violation message.   
    if(_DisplayDateFormat != undefined && _DisplayDateFormat != '')
        calDateFormat = _DisplayDateFormat.toLowerCase(); // set date format
    setSplitChar(); // set split character in date format for future use as per date format set.   
    
    var retVal = IsValidDate(ctrlValue);
    if(retVal != '')
    {   
        alert(retVal);
        document.getElementById(ctrlID).value = '';    
        return false;            
    }
    else
    {
        return true;
    }
}

