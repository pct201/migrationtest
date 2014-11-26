<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopupTimeOut.aspx.cs" Inherits="PopupTimeOut"
    Theme="Default"   %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Envisage - Session TimeOut</title>

    <script language="javascript" type="text/javascript">
    
    
//Start code for timer
var TimeOutAction='';

var _countDowncontainer=0;
var _currentSeconds=0;

function ActivateCountDown(strContainerID, initialValue) {
	_countDowncontainer = document.getElementById(strContainerID);
	
	if (!_countDowncontainer) {
		alert("count down error: container does not exist: "+strContainerID+
			"\nmake sure html element with this ID exists");
		return;
	}
	
	SetCountdownText(initialValue);
	window.setTimeout("CountDownTick()", 1000);
}

function CountDownTick() {
	if (_currentSeconds <= 0) {
		//alert("Your time has expired!");
		return;
	}
	
	SetCountdownText(_currentSeconds-1);
	window.setTimeout("CountDownTick()", 1000);
}

function SetCountdownText(seconds) {
	//store:
	_currentSeconds = seconds;
	
	//get minutes:
	var minutes=parseInt(seconds/60);
	
	//shrink:
	seconds = (seconds%60);
	
	//get hours:
	var hours=parseInt(minutes/60);
	
	//shrink:
	minutes = (minutes%60);
	
	//build text:
	var strText = AddZero(hours) + ":" + AddZero(minutes) + ":" + AddZero(seconds);
	
	//apply:
	_countDowncontainer.innerHTML = strText;
}

function AddZero(num) {
	return ((num >= 0)&&(num < 10))?"0"+num:num+"";
}

function StartTimer(event)
{
    // alpesh
    ActivateCountDown("CountDownPanel", 300);
	//ActivateCountDown("CountDownPanel", 900);
}
//End code for countdown timer
            
    function AutoClose()
    {
        //alpesh 
        window.setTimeout('AutoCloseWnd()', 5*60*1000);
        //window.setTimeout('AutoCloseWnd()', 15*60*1000);
    }
    
    function AutoCloseWnd()
    {
        TimeOutAction="Auto";
//        window.returnValue='AutoClose';
        window.close();
    }
    
    function CancelClick()
    {
    //alert("Cancel clicked")
        TimeOutAction="Cancel";
//        var strRemainingTime=_countDowncontainer.innerHTML;
//        var strMin=strRemainingTime.substr(3,2);
//        var strSec=strRemainingTime.substr(6);
//        window.returnValue='TimeOut^' + strMin + '^' + strSec;
        window.close();
    }
    
    function OkClick()
    {
        TimeOutAction="Ok";
        window.close();
    }
    
    function UnloadEvent()
    {
        var strRemainingTime=_countDowncontainer.innerHTML;
        var strMin=strRemainingTime.substr(3,2);
        //Alpesh
//        alert('Time Rmaining ='+ strRemainingTime);
        //alert('StrMin ='+ strMin);
        var strSec=strRemainingTime.substr(6);
        //alert('Str SEc  ='+ strSec);
        if(isNaN(strMin))
        {
            strMin=0;
        }
        if(isNaN(strSec))
        {
            strSec=0;
        }
        if(TimeOutAction=="Auto")
        {
            window.returnValue='Auto^' + strMin + '^' + strSec;
        }
        else if(TimeOutAction=="Cancel")
        {
            //Alpesh
            //window.returnValue='Cancel^' + strMin + '^' + strSec;
            strMin=0;
            strSec=0;
            window.returnValue='Cancel^' + strMin + '^' + strSec;
        }
        else if(TimeOutAction=="Ok")
        {
            window.returnValue='Ok^' + strMin + '^' + strSec;
        }
        else if(TimeOutAction=='')
        {
            window.returnValue='Cross^' + strMin + '^' + strSec;
        }
    }
    </script>

    <base target="_self" />
</head>
<body onunload="UnloadEvent();">
    <form id="form1" runat="server">
        <table cellspacing="0" cellpadding="0" class="tablebackground" width="95%">
            <tr>
                <td class="loc">
                    &nbsp;</td>
            </tr>
            <tr class="ghc">
                <td runat="server" id="tdMainTitle" >
                    Risk Insurance Management System</td>
            </tr>
            <tr>
                <td class="loc">
                    &nbsp;</td>
            </tr>
            <tr>
                <td runat="server" id="tdSubTitle" class="lc">
                    <asp:Label ID="lblsession" Text="Session TimeOut" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="loc">
                    &nbsp;</td>
            </tr>
            <tr>
                <td valign="middle" align="center">
                    <table width="98%">
                        <tr>
                            <td class="lc" style="width:50%;" align="left">
                                Current Time</td>
                            <td class="ic" style="width:50%;" align="left">
                                <asp:Label ID="lblCurrentTime" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="lc" style="width:50%;" align="left">
                                Session will expire after</td>
                            <td class="ic" style="width:50%;" align="left">
                                <span id="CountDownPanel"></span>
                            </td>
                        </tr>
                        <tr>
                            <td class="loc" colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="80%" colspan="2" class="cc">
                                <%--<asp:ImageButton ID="btnOk" runat="server" ImageUrl="~/Images/Buttons/btnOk.gif" />
                                <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/Images/Buttons/btnCancel.gif" /></td>--%>
                                <asp:Button ID="btnOk" runat="server"  Text=    "Keep Logged In" />
                                <asp:Button ID="btnCancel" runat="server"  Text="    Logout   " />
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblRegisterScript" runat="server"></asp:Label></td>
            </tr>
        </table>
    </form>
</body>
</html>
