<%@ Control Language="c#" Inherits="monthcalendar.MonthSelectControl" CodeFile="MonthSelectControl.ascx.cs" %>

<script>
     
//	function nextYear(forward) {
//		var yearField = document.getElementById("<%= txtYear.ClientID %>");
//		var testEr = new RegExp('\\d{4}', 'g');
//		if(testEr.test(yearField.value)) {
//			var yearValue = parseInt(yearField.value);
//			if(forward)
//				yearValue = yearValue+1;
//			else
//				yearValue = yearValue-1;
//			yearField.value = yearValue;
//		} else {
//		var newDate = new Date();
//		yearField.value = newDate.getFullYear();
//		}
//		flgDisplay = true;
//	}
//	
//	function lnkMonthClick(month)
//	{
//	    document.getElementById("<%= txtMonthYear.ClientID %>").value = month + '/' + document.getElementById("<%= txtYear.ClientID %>").value
//	    HideDiv();
//	}

//	
//	function mouseX(evt) {
//            if (evt.pageX) return evt.pageX;
//            else if (evt.clientX)
//               return evt.clientX + (document.documentElement.scrollLeft ?
//               document.documentElement.scrollLeft :
//               document.body.scrollLeft);
//            else return null;
//        }
//    function mouseY(evt) {
//        if (evt.pageY) return evt.pageY;
//        else if (evt.clientY)
//           return evt.clientY + (document.documentElement.scrollTop ?
//           document.documentElement.scrollTop :
//           document.body.scrollTop);
//        else return null;
//    }



//    function HideDiv()
//    {       
//        document.getElementById("ImagePopup").style.display = "none";
//    }
//    
//    function ShowDiv()
//    {   
//        var objDivInfoBox = document.getElementById("ImagePopup");
//        objDivInfoBox.style.display = "inline";
//        objDivInfoBox.style.left = mouseX(window.event);
//        objDivInfoBox.style.top = mouseY(window.event);
//        flgDisplay = true;
//    }   
        
</script>

<table cellpadding="0" cellspacing="0">
    <tr>
        <td align="left" valign="top" width="83">
            <asp:TextBox ID="txtMonthYear" runat="server" ReadOnly="false" MaxLength="7" Width="80px"
                OnBlur="return ValidateDate(this);" onkeypress="return OnKeyPress(event,this);"></asp:TextBox>
        </td>
        <td align="left" style="width: 16px;">
            <img alt="Open" id="imgCal" runat="server" height="15" width="16" src="Calender.bmp"
                align="middle" style="cursor: pointer;" />
            <asp:RequiredFieldValidator ID="reqDate" runat="Server" ControlToValidate="txtMonthYear"
                EnableClientScript="true" SetFocusOnError="true" Display="none" Text="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
</table>
<div id="ImagePopup" runat="server" style="display: none; position: absolute; background-color: White;
    border-width: 0px;">
    <div style="border: 1px solid black; width: 100px; text-align: center; padding: 3 3 3 3;">
        <img src="prev1.gif" id="imgPrev" runat="server" border="0" style="cursor: pointer;">
        <asp:TextBox ID="txtYear" runat="server" CssClass="form" Width="50" Style="width: 50px;
            border: 1px solid; text-align: center;" MaxLength="4" OnBlur="return ValidateYear(this);"></asp:TextBox>
        <img src="next1.gif" id="imgNext" runat="server" border="0" style="cursor: pointer;">
        <table width="100%" align="center" cellpadding="2" cellspacing="0">
            <tr>
                <td>
                    <a id="lnkJan" runat="server" onclick="lnkMonthClick('01');" style="cursor: pointer;">
                        Jan</a>
                </td>
                <td>
                    <a id="lnkFeb" runat="server" onclick="lnkMonthClick('02');" style="cursor: pointer;">
                        Feb</a>
                </td>
                <td>
                    <a id="lnkMar" runat="server" onclick="lnkMonthClick('03');" style="cursor: pointer;">
                        Mar</a>
                </td>
            </tr>
            <tr>
                <td>
                    <a id="lnkApr" runat="server" onclick="lnkMonthClick('04');" style="cursor: pointer;">
                        Apr</a>
                </td>
                <td>
                    <a id="lnkMay" runat="server" onclick="lnkMonthClick('05');" style="cursor: pointer;">
                        May</a>
                </td>
                <td>
                    <a id="lnkJun" runat="server" onclick="lnkMonthClick('06');" style="cursor: pointer;">
                        Jun</a>
                </td>
            </tr>
            <tr>
                <td>
                    <a id="lnkJul" runat="server" onclick="lnkMonthClick('07');" style="cursor: pointer;">
                        Jul</a>
                </td>
                <td>
                    <a id="lnkAug" runat="server" onclick="lnkMonthClick('08');" style="cursor: pointer;">
                        Aug</a>
                </td>
                <td>
                    <a id="lnkSep" runat="server" onclick="lnkMonthClick('09');" style="cursor: pointer;">
                        Sep</a>
                </td>
            </tr>
            <tr>
                <td>
                    <a id="lnkOct" runat="server" onclick="lnkMonthClick('10');" style="cursor: pointer;">
                        Oct</a>
                </td>
                <td>
                    <a id="lnkNov" runat="server" onclick="lnkMonthClick('11');" style="cursor: pointer;">
                        Nov</a>
                </td>
                <td>
                    <a id="lnkDec" runat="server" onclick="lnkMonthClick('12');" style="cursor: pointer;">
                        Dec</a>
                </td>
            </tr>
        </table>
        <a id="lnkClose" runat="server" style="cursor: pointer; text-decoration: underline;">
            Close</a>
    </div>
</div>
