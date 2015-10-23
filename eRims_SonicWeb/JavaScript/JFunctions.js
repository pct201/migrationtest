//jVbFunctions Library

//window.history.forward(1);

//=============Code to disable right click added by Sandip on 13-Feb-2007==============
//document.oncontextmenu=new Function("return false;")
//=====================================================================================

//======================================================
//Script to capture refresh and other keystrokes and nullify their action
//Script Added by Lalit Sharma on 13th Feb 2007      
//var i=0;
	
	/*	document.onkeydown = function(e){

            //alert("in keydown");
            //set event
            
            var blnIE=false;
            var blnSuppress=false;
            
            if(window.event) {
                blnIE=true;
                e=window.event;
                } //set IE param
             
            if(e) {
                //alert("have e");
                //alert(e.keyCode);
                if(e.keyCode == 505){
                    //alert("is 505 refresh");
                    blnSuppress=true;
                    }
                    //---------Added by Pradip on 21st feb 2007 
                else if(e.keyCode == 114){
                    //This is for to deactive the keypress F3
                    blnSuppress=true;
                    }
                else if(e.keyCode == 116){
                    //alert("is 116 refresh");
                    blnSuppress=true;
                    }
                    
                 else if(e.keyCode == 117) {
                    //this an F6 press which seems to put the focus back in the persistend address bar 
                    //and then allows subsequent keys to fire so lets kill that
                    blnSuppress=true;
                    }
                    //--------Up to this------------------------
                else if(e.ctrlKey) {
                    //alert("ctrl key");
                    if(e.keyCode == 78 || e.keyCode == 82) {
                        //r or n character
                        blnSuppress=true;
                        }
                    }
                else if(e.altKey) {
                    //alert("alt key");
                    if(e.keyCode == 39 || e.keyCode == 37) {
                        //left/right arrow
                        blnSuppress=true;
                        }
                    } 
                else
                    {
                    //document.all.txtKeys.value=e.keyCode;
                    }
                    
                    //78 = n
                    //39 = right arrow
                    //37 = left arrow
                    //82 = r
                
                if(blnSuppress){
                    //alert("is refresh in blnRefresh");
                    //i+=1;
                    if(blnIE){
                        //return false out of IE and set 505 keycode
                        //alert("kill IE refresh");
                        e.keyCode=505;
                        //document.all.txtKeys.value="Stopped " + i;
                        
                        /*return false;*/
                    /*    return true;
                        }
                    else {
                        //use w3c model in firefox
                        if (e.preventDefault && e.stopPropagation) { 
                            //alert("prevent default and stop propagation");
                            document.all.txtKeys.value="Stopped " + i;
                            if (e.cancelable) e.preventDefault(); 
                            e.stopPropagation(); document.all.txtKeys.value="Stopped";
                            }
                        else { 
                            e.returnValue = false; 
                            e.cancelBubble = true; 
                            } 
                        }
                    }
                }
            }*/
function OpenWMail(grdName,attTbl)
{
    var isChecked = false;
	for(i=0;i<document.forms[0].elements.length;i++)
        {
            if((document.forms[0].elements[i].type=='checkbox') && (document.forms[0].elements[i].name !='chkHeader'))
            {
                if(document.forms[0].elements[i].checked  == true)
                       isChecked= true;
            }
        }   
	if(!isChecked)
	{
	    alert('Please select any attachment to mail.');
		return false;
	}
	
    var i,flag=0;
    var m_strAttIds="";  
    for(i=0;i<document.forms[0].elements.length;i++)
    {
        if((document.forms[0].elements[i].type=='checkbox'))
        {
             if(document.forms[0].elements[i].name !="ctl00$ContentPlaceHolder1$"+grdName+"$ctl01$chkHeader")
                {
                
                if(document.forms[0].elements[i].checked  == true)
                    {  
                        if(m_strAttIds=="")
                        {
                            m_strAttIds=document.forms[0].elements[i].value;
                        }
                        else
                        {
                           m_strAttIds=m_strAttIds+","+document.forms[0].elements[i].value; 
                        }
                    }
                }
        }
        
    }
    //alert(m_strClaimNo); 
    oWnd=window.open("../ErimsMail.aspx?AttMod="+attTbl+"&AttIds=" + m_strAttIds ,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=600,height=300");
    oWnd.moveTo(260,180);
    return false;
           
}
 function UnCheckHeader(grdName)
    {
        var i,flag=0;
        var chk;  
        for(i=0;i<document.forms[0].elements.length;i++)
        {
            if((document.forms[0].elements[i].type=='checkbox'))
            {
                 if(document.forms[0].elements[i].name !="ctl00$ContentPlaceHolder1$"+grdName+"$ctl01$chkHeader")
                    {
                    
                    if(document.forms[0].elements[i].checked  == false)
                        {  flag = 1;}
                        }
            }
        }    	
        for(i=0;i<document.forms[0].elements.length;i++)
        {
            if ( flag == 1)
            {
                if((document.forms[0].elements[i].type=='checkbox'))
                {
                    if(document.forms[0].elements[i].name =="ctl00$ContentPlaceHolder1$"+grdName+"$ctl01$chkHeader")
                    {
                        chk = document.forms[0].elements[i];
                        chk.checked = false;
                    }
                }
            }
            else if (flag == 0)
            {
               if((document.forms[0].elements[i].type=='checkbox'))
                    if(document.forms[0].elements[i].name =="ctl00$ContentPlaceHolder1$"+grdName+"$ctl01$chkHeader")
                        document.forms[0].elements[i].checked = true;               
            }
        }
    }          
function disableDeleteBackSpace()
{
    var keyCode = (event.which)?event.which:event.keyCode;
    if ((keyCode == 8) || (keyCode == 46))
        event.returnValue = false;
    else
        event.returnValue = false;
} 

//======================================================
//Created By : MR90
//Created On : 06/12/2007
//Purpose : To resize the IFrame according to the Height of the Page being loaded into IFrame.
 
function resizeIFrame()
{
    //var b = screen.Height - 339;
    if (!window.opera && !document.mimeType && document.all && document.getElementById){
        parent.document.getElementById("frmContentPage").style.height=this.document.body.offsetHeight+"px";
    }
    else if(document.getElementById) {
        parent.document.getElementById("frmContentPage").style.height=this.document.body.scrollHeight+"px";
    }
}

function openRADWindow(flgURL,windowName,scrWidth,scrHeight,windowWidth,windowHeight)
{
// Force reload in order to guarantee that the onload event handler of the dialog which configures it executes on every show.
    //alert(flgURL);
    //var oWnd = radopen(flgURL,windowName);
    //alert(getDocHeight());
    var oWnd =parent.window.radopen(flgURL,windowName);
    //var sUrl = flgURL;
    oWnd.SetSize (scrWidth,scrHeight);
    oWnd.Top= 100;
    oWnd.SetStatus(" ");
    oWnd.MoveTo(screen.width/2 - windowWidth , screen.height/2 - windowHeight);
    oWnd.SetUrl(flgURL);
    return false;
}
//======================================================
//Created By : MR87 
//Created On : 05/31/2007
//Purpose : Fro Open Document in New window.
//Parameter event "flgURL".

function winOpen(flgURL)
{
    oWnd=window.open(flgURL,"Envisage","location=0,status=0,scrollbars=1,menubar=0,resizable=1,menubar=0,toolbar=0");
    oWnd.height = 400; oWnd.width = 600; oWnd.moveTo(screen.width/2 - (oWnd.width/2),screen.height/2 - (oWnd.height/2));
}

//======================================================
//Created By : MR87 MR90
//Created On : 04/25/2007
//Purpose : For not Enter Character Except 0 to 9.
//Parameter event "e".
 
function numberOnly(e)
{
    var k;
    if (window.event)     
    {
        k = event.keyCode  ; 
    }
    else     
    {
        k = e.which  ;
    }
    if (k == 8)
    {
        return true;
    }
    if((k <= 47) || (k >= 58)  )
    {
        if (window.event)     
        {
            window.event.returnValue = null; 
            return false;
    	}
        else
        {
            e.preventDefault();
        }
    }  
    if (k == 8)
    {}
   }
function noPhoneFax(e)
{
    
    if((event.keyCode <= 47) || (event.keyCode >= 58) && event.keyCode != 46 )
    {
        if(event.keyCode != 45)
         {
            
            event.cancelBubble = true;
            event.returnValue = false;
         }
    }
}
//======================================================
//Created By : MR87 MR90
//Created On : 04/22/2007
//Purpose : For firing message if Item Already Exist.
//Parameter "m_strMessage" is Message in single quote you want to display for Existance.

function IsExist(m_strMessage)
    {
        alert(m_strMessage);
        return false;
    }
//Created By : MR87
//Created On : 03/22/2007
//Purpose : For Closing Window.
//Parameter "blnIsParentRefresh" is bool if true then parent will Refresh
//Parameter "strMessage" is Message in single quote you want to display for confirmation.
function WindowClose(blnIsParentRefresh,strMessage)
{
     if (confirm("Are you sure you want to "+ strMessage))
	 { 
	     if(blnIsParentRefresh==true)
	     {
	        parent.location.reload();
	     } 
         var oWindow = null;
         if (window.radWindow) 
         {
            oWindow = window.radWindow;
         }
         else if (window.frameElement.radWindow)
         {
            oWindow = window.frameElement.radWindow;
         }
         oWindow.Close();
         return blnIsParentRefresh;
         
     }
     else
     {
        return false;
     }
     
}
function Message()
            {
                var retValue = confirm("Are you sure you want to Reset Password?");
                if(retValue)
                    alert("Password has been Reset");
                return retValue;
            }
function OpenModalWindow(url)
            {
             /*   var url="Practice/PopAddPayer.aspx";
                var str = document.show
                OpenModelScrollbarsDoc(url, 600, 300);
                return false;
                */
                
                var strOk = window.showModalDialog(url,'Envisage','dialogHeight:500px; dialogwidth:500px; edge: Raised; Scroll: Yes; center: Yes; Resizable:Yes; Status:No;' ); 
    if (strOk != undefined)
    { 
    if ( Trim(strOk) == "" )
        return false;
    else
    {
        return true;
    }
    }
            }

/* Function to get currently loaded document height*/
function getDocHeight() 
    {
        var doc = document;
        var docHt = 0, sh, oh;
        if (doc.height) docHt = doc.height;
        else if (doc.body) 
            {
                if (doc.body.scrollHeight) docHt = sh = doc.body.scrollHeight;
                if (doc.body.offsetHeight) docHt = oh = doc.body.offsetHeight;
                if (sh && oh) docHt = Math.max(sh, oh);
            }
            
            //alert(dodHt);
            
        //if document height is less than 500 px then assign the height has 500px
        if (docHt < 500)
            {
                docHt = 500;
            }
            
        return docHt;
    }
/******************************************************************************************/

/* Expand and Collapse the div  */
/* onclick="ShowDiv('object');"*/

function ShowDiv(obj)
        {   
            if(document.getElementById(obj).style.visibility=='hidden')
            {
                document.getElementById(obj).style.visibility = 'visible';
                document.getElementById(obj).style.display='block';               
            }
            else
            {
                document.getElementById(obj).style.visibility = 'hidden';
                document.getElementById(obj).style.display = 'none';
            }
            parent.window.document.getElementById('iframeContent').style.height=getDocHeight()+ 100 + 'px';
            return false;
        }        
        
/***************************************************************************************************/
/* Expand and Collapse the div  */
/* onclick="ShowDiv('object');"*/

function ShowPracticeList(obj)
        {   
            if(document.getElementById(obj).style.visibility=='hidden')
            {
                document.getElementById(obj).style.visibility = 'visible';
                document.getElementById(obj).style.display='block';               
            }
            else
            {
                document.getElementById(obj).style.visibility = 'hidden';
                document.getElementById(obj).style.display = 'none';
            }
         //   window.document.getElementById('iframeContent').style.height=getDocHeight()+ 100 + 'px';
            return false;
        }        


/***************************************************************************************************/
/* onKeyPress event use for checking numeric value */

function CheckNum(txtnum)
{
    
    var txt = document.getElementById(txtnum);
    
    //alert(txt+event.keyCode);
    
    if((event.keyCode <= 47) || (event.keyCode > 58))
    {
         if(event.keyCode != 46)
         {
            //alert(" Enter the Numeric Value");
            event.cancelBubble = true;
            event.returnValue = false;
         }
    }
}



/* Expand and Collapse the div  */
/* onclick="switchMenu('myvar');"*/
function switchMenu(obj) {
	var el = document.getElementById(obj);
	if ( el.style.display != "none" ) {
		el.style.display = 'none';
	}
	else {
		el.style.display = '';
	}
}

// automatic formatting of SSN 
// valid format 111-11-1111
function maskSSN(e,str,textbox)
{
	if(!((e.keyCode > 47 && e.keyCode < 58)||(e.keyCode > 95 && e.keyCode < 106) || e.keyCode == 9))
	{
	   //alert(e.keyCode);
		str = str.substring(0,str.length-1);
		textbox.value = str;
	}
	else
	{
		if(str.length == 3)
		{
			if(e.keyCode != 8)
			str = str+"-";
		}
		if(str.length == 11 && e.keyCode != 8)
		{	
			str = str+"-";
		}
		if(str.charAt(4) != "-" && str.charAt(4) != "")
		{
			str = str.substring(0,3)+"-"+str.substring(4,str.length); 
		}
		
		if(str.charAt(6) != "-" && str.charAt(6) != "")
		{
			str = str.substring(0,6)+"-"+str.substring(6,str.length); 
		}
		if(str.charAt(10) != "-" && str.charAt(10) != "")
		{
			str = str.substring(0,11)+"-"+str.substring(11,str.length); 
		}
		str = str.substring(0,11);
		textbox.value = str;
	}
}

// automatic formatting of phone numbers
//valid format  (111)-111-1111
function mask1(e,str,textbox)
		{
			  if(!((e.keyCode > 47 && e.keyCode < 58)||(e.keyCode > 95 && e.keyCode < 106) || e.keyCode == 9))
			//if(!((e.keyCode > 47 && e.keyCode < 58)||(e.keyCode > 95 && e.keyCode < 106)))
			{
			    str = str.substring(0,str.length-1);
				//str = str.substring(0,str.length);
				textbox.value = str;
			}
			else
			{
				if(str.length ==1 && e.keyCode != 8)
				str= "("+str;
				if(str.length == 4)
				{
					if(e.keyCode != 8)
					str = str+")"+"-";
				}
				if(str.length == 9 && e.keyCode != 8)
				{	
					str = str+"-";
				}
				if(str.charAt(4) != ")" && str.charAt(4) != "")
				{
					str = str.substring(0,4)+")"+str.substring(4,str.length); 
				}
				if(str.charAt(5) != "-" && str.charAt(5) != "")
				{
					str = str.substring(0,5)+"-"+str.substring(5,str.length); 
				}
				if(str.charAt(9) != "-" && str.charAt(9) != "")
				{
					str = str.substring(0,9)+"-"+str.substring(9,str.length); 
				}
				str = str.substring(0,14);
				if(str.charAt(0) != "(" && e.keyCode != 8)
				str = "("+str.substring(1,14);
				textbox.value = str;
			}
		}

// automatic formatting of Amount
function maskAmount(e,str,textbox)
{ 
    if(!((e.keyCode > 47 && e.keyCode < 58)||(e.keyCode > 95 && e.keyCode < 106)||(e.keyCode == 190)||(e.keyCode == 110)))
	{
		str = str.substring(0,str.length-1);
		textbox.value = str;
	}
	else
	{  
        for(var i=0; i<8; i++)
        {  
            if(str.charAt(i) == ".")
            {
                dotCnt = 1;                
	            str = str.substring(0,i)+"."+str.substring(i+1,i+3); 
	            break;
            }
	    }
		var nDot = str.lastIndexOf('.');
		if(nDot == "-1")
		{
	        if(str.charAt(8) != "." && str.charAt(8) != "")
	        {
	            str = str.substring(0,8)+"."+str.substring(8,str.length); 
	        }
		}
		str = str.substring(0,11);
		textbox.value = str;
	}
}

// automatic formatting of SSN numbers
//valid format  111-11-1111
//function maskSSN(e,str,textbox)
//{
//	if(!((e.keyCode > 47 && e.keyCode < 58)||(e.keyCode == 45 || e.keyCode == 28 || e.keyCode == 29)))
//	{
//	    //alert(str);
//		str = str.substring(0,str.length-1);
//		textbox.value = str;
//	}
//	else
//	{
////		if(str.length == 3 && e.keyCode != 8)
////		{	
////			str = str+"-";
////		}
//		if(str.charAt(3) != "-" && str.charAt(3) != "")
//		{
//			str = str.substring(0,3)+"-"+str.substring(3,str.length); 
//		}
//		if(str.charAt(6) != "-" && str.charAt(6) != "")
//		{
//			str = str.substring(0,6)+"-"+str.substring(6,str.length); 
//		}
//		str = str.substring(0,11);
////		if(str.charAt(0) != "(" && e.keyCode != 8)
////		str = "("+str.substring(1,14);
//		textbox.value = str;
//	}
//}

// STRING FUNCTIONS START HERE...
function Trim(s)
{
	// Remove leading spaces and carriage returns
	while ((s.substring(0,1) == ' ') || (s.substring(0,1) == '\n') || (s.substring(0,1) == '\r'))
	{
		s = s.substring(1,s.length);
	}

	// Remove trailing spaces and carriage returns
	while ((s.substring(s.length-1,s.length) == ' ') || (s.substring(s.length-1,s.length) == '\n') || (s.substring(s.length-1,s.length) == '\r'))
	{
		s = s.substring(0,s.length-1);
	}
	return s;
}

function jTrim(str)
{
 	while(str.charAt(0)==' ')
		str=str.substring(1,str.length);

	while(str.charAt(str.length-1)==' ')
		str=str.substring(0,str.length-1);
	
	return(str);
}


function jRTrim(str)
{
 	while(str.charAt(str.length-1)==' ')
		str=str.substring(0,str.length-1);

	return(str);
}


function jLTrim(str)
{
	while(str.charAt(0)==' ')
		str=str.substring(1,str.length);

	return(str);
}


function jMid(str,start,len)
{
	if(isNaN(start))
	{
		alert("start parameter given wrong in jMid function.");
		return null;
	}
	if (len==null)
		len=str.length;

	//alert(str.substring(start-1,start+len-1));
	return(str.substring(start-1,start+len-1));
}


function jTitleCase(str)
{
	while(str.charAt(0)==' ')
		str=str.substring(1,str.length);

	while(str.charAt(str.length-1)==' ')
			str=str.substring(0,str.length-1);
			
	str=str.charAt(0).toUpperCase() + str.substring(1).toLowerCase();
	//alert(str);
	return(str);
}


function jIsStringFound(str,find)
{
	if(str.indexOf(find)!=-1)
		return true;
	else
		return false;
}


function jStrReverse(str)
{
	var revStr="";
	while(str!="")
	{
		revStr=revStr + str.substring(str.length-1)
		str=str.substring(str,str.length-1)
	}
	//alert(revStr);
	return(revStr);
}


function jReplace(str,find,replacewith)
{
	while(str.indexOf(find)!=-1)
	{
		str=str.substring(0,str.indexOf(find)) + replacewith + str.substring(str.indexOf(find)+find.length)
	}
	//alert(str);
	return (str);
}

function jLeft(str, n)
{

	/*IN:		str - the string we are LEFTing
				n	- the number of characters we want to return

	RETVAL: n characters from the left side of the string*/
	
    if (n <= 0)     // Invalid bound, return blank string
            return "";
    else if (n > String(str).length)   // Invalid bound, return
            return str;                // entire string
    else // Valid bound, return appropriate substring
            return String(str).substring(0,n);
}

function jRight(str, n)
{
	/*IN:		str - the string we are LEFTing
				n	- the number of characters we want to return

	RETVAL: n characters from the left side of the string*/
	if (n <= 0)
       return "";
	else if (n > String(str).length)
       return str;
	else 
	{
		var iLen = String(str).length;
		return String(str).substring(iLen, iLen - n);
	}
}

function chkMaxLengthText(obj, imaxlen)
{
	var str;
	str = document.getElementById(obj).value; 
	if (str.length >= (parseInt(imaxlen)))
	{
		alert("You have exeeded the limit of " + imaxlen + " Characters");
		str = str.substring(0,(parseInt(imaxlen)));
		document.getElementById(obj).value = str; 	
	}
}

/*--------------- This function is used to check Empty string ---------------------- */

function chk_Emptystr(mfield,namevar)
{
	l_value=eval(mfield+".value")
	l_focus=eval(mfield+".focus()")
	
	l_value=jTrim(l_value)
	newstr = new String(l_value)
	if(newstr=="")
	{
		alert("Please enter the "+namevar+".");
		eval(l_focus);
		return false;
	}
	if (newstr.charAt(0)== " ")
	{
		alert("First character must not be blank in " + namevar+".");
		eval(l_focus);
		return false;			
	}
	return true;
}


/*------------------- This function is used to check empty space in the string --------------*/

  function checkSpace(mfield,namevar)
	{
 			
		l_value=eval(mfield+".value")
		l_focus=eval(mfield+".focus()")
		
		newstr = new String(l_value)
		
		if(newstr.charAt(newstr.indexOf(" "))==" ")
		{
			alert("Please don't enter the blanks in  "+namevar+".")
			eval(l_focus)
			return false
		}
		return true;
	}


/*--------------------- This function is used to check that value in selectbox is selected or not ----------------------*/

  function check_select(fvalue,fname)
  {
  	fieldVal = eval(fvalue+".value")
  	fieldFoc = eval(fvalue+".focus()")
  	
  	if (fieldVal == "")
  	{
  		alert("Please select " +  fname + ".");
  		fieldFoc;
  		return false;
  	}
  	return true;
}

/* -----------------------------This function is used to check email address ----------------------*/

function CheckEMail(obj) //this function is copied from CommonFuns.JS
{
emailStr = document.all[obj].value.toLowerCase();
if(emailStr == '')
	return true;


//The following variable tells the rest of the function whether or not to verify that the address ends in a two-letter country or well-known TLD.  1 means check it, 0 means don't.

var checkTLD=1;

//The following is the list of known TLDs that an e-mail address must end with.

var knownDomsPat=/^(com|net|org|edu|int|mil|gov|arpa|biz|aero|name|coop|info|pro|museum)$/;

//The following pattern is used to check if the entered e-mail address fits the user@domain format.  It also is used to separate the username from the domain.

var emailPat=/^(.+)@(.+)$/;

//The following string represents the pattern for matching all special characters.  We don't want to allow special characters in the address.  These characters include ( ) < > @ , ; : \ " . [ ]

var specialChars="\\(\\)><@,;:\\\\\\\"\\.\\[\\]";

//The following string represents the range of characters allowed in a username or domainname.  It really states which chars aren't allowed.

var validChars="\[^\\s" + specialChars + "\]";

//The following pattern applies if the "user" is a quoted string (in which case, there are no rules about which characters are allowed and which aren't; anything goes).  E.g. "jiminy cricket"@disney.com is a legal e-mail address.

var quotedUser="(\"[^\"]*\")";

//The following pattern applies for domains that are IP addresses, rather than symbolic names.  E.g. joe@[123.124.233.4] is a legal e-mail address. NOTE: The square brackets are required.

var ipDomainPat=/^\[(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})\]$/;

//The following string represents an atom (basically a series of non-special characters.)

var atom=validChars + '+';

//The following string represents one word in the typical username. For example, in john.doe@somewhere.com, john and doe are words. Basically, a word is either an atom or quoted string.

var word="(" + atom + "|" + quotedUser + ")";

// The following pattern describes the structure of the user

var userPat=new RegExp("^" + word + "(\\." + word + ")*$");

//The following pattern describes the structure of a normal symbolic domain, as opposed to ipDomainPat, shown above.

var domainPat=new RegExp("^" + atom + "(\\." + atom +")*$");

//Finally, let's start trying to figure out if the supplied address is valid.

//Begin with the coarse pattern to simply break up user@domain into different pieces that are easy to analyze.

var matchArray=emailStr.match(emailPat);

if (matchArray==null) {

//Too many/few @'s or something; basically, this address doesn't even fit the general mould of a valid e-mail address.

alert("Email address seems incorrect (check @ and .'s)");
document.getElementById(obj).value = "";
document.all[obj].focus();
return false;
}
var user=matchArray[1];
var domain=matchArray[2];

// Start by checking that only basic ASCII characters are in the strings (0-127).

for (i=0; i<user.length; i++) {
if (user.charCodeAt(i)>127) {
alert("Ths Email address contains invalid characters.");
document.getElementById(obj).value = "";
document.all[obj].focus();
return false;
   }
}
for (i=0; i<domain.length; i++) {
if (domain.charCodeAt(i)>127) {
alert("Ths domain name contains invalid characters.");
document.getElementById(obj).value = "";
document.all[obj].focus();
return false;
   }
}

// See if "user" is valid 

if (user.match(userPat)==null) {

// user is not valid

alert("The Email address doesn't seem to be valid.");
document.getElementById(obj).value = "";
document.all[obj].focus();
return false;
}

//if the e-mail address is at an IP address (as opposed to a symbolic host name) make sure the IP address is valid.

var IPArray=domain.match(ipDomainPat);
if (IPArray!=null) {

// this is an IP address

for (var i=1;i<=4;i++) {
if (IPArray[i]>255) {
alert("Destination IP address is invalid!");
document.getElementById(obj).value = "";
document.all[obj].focus();
return false;
   }
}
return true;
}

// Domain is symbolic name.  Check if it's valid.
 
var atomPat=new RegExp("^" + atom + "$");
var domArr=domain.split(".");
var len=domArr.length;
for (i=0;i<len;i++) {
if (domArr[i].search(atomPat)==-1) {
alert("The domain name does not seem to be valid.");
document.getElementById(obj).value = "";
document.all[obj].focus();
return false;
   }
}

//domain name seems valid, but now make sure that it ends in a known top-level domain (like com, edu, gov) or a two-letter word, representing country (uk, nl), and that there's a hostname preceding the domain or country.

if (checkTLD && domArr[domArr.length-1].length!=2 && 
domArr[domArr.length-1].search(knownDomsPat)==-1) {
alert("The address must end in a well-known domain or two letter " + "country.");
document.getElementById(obj).value = "";
document.all[obj].focus();
return false;
}

// Make sure there's a host name preceding the domain.

if (len<2) {
alert("This address is missing a hostname!");
document.getElementById(obj).value = "";
document.all[obj].focus();
return false;
}

// If we've gotten this far, everything's valid!
return true;
}

function jIsEmail(str)
	{
		if(str != "" && str != null)
		{
			if (/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/.test(str))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
	
	
	 function CheckWebSite(obj) 
   {
     var str;
     var strW;
     var i;
     var cnt = 0;
     var strFDomain;
     var strDomain =".com,.net,.org,.edu,.int,.mil,.gov,.arpa,.biz,.aero,.name,.coop,.info,.pro,.museum";
     str = document.getElementById(obj).value ;
     
     if( str != "")
     {
       
		strW = str.substr(0,4);
		strFDomain = str.substr(str.lastIndexOf("."));
     
		for ( i=0; i< str.length; i++)
		{
			if ( str.substr(i,1) == ".")
			cnt++;
		}
		if( cnt != 2) 
		{
			alert("It is not valid WebSite Address.");
			document.getElementById(obj).value  = "";
			GetFocus(obj);
			//document.getElementById(obj).focus();
			return false;
		}
       else
       {
         if( str.indexOf("..") != -1 )
         {
			alert("It is not valid WebSite Address.");
			document.getElementById(obj).value  = "";
			GetFocus(obj);
			//document.getElementById(obj).focus();
			return false;
         }
       }
    
		if( strW.toLowerCase() != "www." )
		{
			alert("It is not valid WebSite Address.");
			document.getElementById(obj).value  = "";
		    GetFocus(obj);
		    //document.getElementById(obj).focus();
			return false;
		}
     
		/*if( strFDomain.length != 4 )
		{
		alert("It is not a valid Domain.");
			document.getElementById(obj).value  = "";
			GetFocus(obj);
			return false;
		}*/
		if( strDomain.indexOf(strFDomain.toLowerCase()) == -1 )
		{
			alert("It is not a valid Domain.");
			document.getElementById(obj).value  = "";
			GetFocus(obj);
			//document.getElementById(obj).focus();
			return false;
		}
	     
	     
   
	 }
   }
   
   
	/*--------This fucntion is used to check junk characters in the strings like login, password, email, name, code etc. ---*/

function check_Junk(txtName,sName,junkType)
		{
			l_value=eval(txtName+".value")
			l_focus=eval(txtName+".focus()")
			
			
			
			if (junkType=='Name')
				{
					
					var junkchar = new Array(100);
					    junkchar[0]="~";   junkchar[1]="`";  junkchar[2]="!";  junkchar[3]="@";  						junkchar[4]="#";
						junkchar[5]="$";   junkchar[6]="%";  junkchar[7]="^";  junkchar[8]="*";  						junkchar[9]="_";
						junkchar[10]="+";  junkchar[11]="|"; junkchar[12]="="; junkchar[13]="\\"; 						junkchar[14]=":";
						junkchar[15]="\"";  junkchar[16]=";"; junkchar[17]="'"; junkchar[18]="<"; 						junkchar[19]=">";
						junkchar[19]="?";  //junkchar[20]="&";		
					
				}
			
			
			if (junkType=='Code')
				{
						
						
					var junkchar = new Array(100);
					    junkchar[0]="~";   junkchar[1]="`";  junkchar[2]="!";  junkchar[3]="@";		junkchar[4]="#";
						junkchar[5]="$";   junkchar[6]="%";  junkchar[7]="^";  junkchar[8]="*";  	junkchar[9]="_";
						junkchar[10]="+";  junkchar[11]="|"; junkchar[12]="="; junkchar[13]="\\"; 	junkchar[14]=":";	
						junkchar[15]="\"";  junkchar[16]=";"; junkchar[17]="'"; junkchar[18]="<"; 	junkchar[19]=">";
						junkchar[20]="(";  junkchar[21]=")"; junkchar[22]="-"; junkchar[23]="{"; 	junkchar[24]="}";
						junkchar[25]="[";  junkchar[26]="]"; junkchar[27]=","; junkchar[28]="."; 	junkchar[29]="/";
						junkchar[30]="&";	junkchar[31]="?";
				}
			
						
			if (junkType=='Email')
				{
						
					var junkchar = new Array(100);
					    junkchar[0]="~";   junkchar[1]="`";  junkchar[2]="!";	junkchar[3]="";		junkchar[4]="#";
						junkchar[5]="$";   junkchar[6]="%";  junkchar[7]="^";	junkchar[8]="*";  	junkchar[9]="?";
						junkchar[10]="+";  junkchar[11]="|"; junkchar[12]="=";	junkchar[13]="\\"; 	junkchar[14]=":";
						junkchar[15]="\"";  junkchar[16]=";"; junkchar[17]="'"; junkchar[18]="<"; 	junkchar[19]=">";
						junkchar[20]="(";  junkchar[21]=")"; junkchar[22]="-";	junkchar[23]="{"; 	junkchar[24]="}";
						junkchar[25]="[";  junkchar[26]="]"; junkchar[27]="";	junkchar[28]="/";	junkchar[29]=" ";
						junkchar[30]="&";
				
				}
										

			if (junkType=='Login')
				{
					
						
					var junkchar = new Array(100);
					    junkchar[0]="~";   junkchar[1]="`";  junkchar[2]="!";  junkchar[3]="@";  						junkchar[4]="#";
						junkchar[5]="$";   junkchar[6]="%";  junkchar[7]="^";  junkchar[8]="*";  						junkchar[9]=" ";
						junkchar[10]="+";  junkchar[11]="|"; junkchar[12]="="; junkchar[13]="\\"; 						junkchar[14]=":";
						junkchar[15]="\""; junkchar[16]=";"; junkchar[17]="'"; junkchar[18]="<"; 						junkchar[19]=">";
						junkchar[20]="?";  junkchar[20]="&";		
					
				}

		if (junkType=='Password')
				{
				
						
					var junkchar = new Array(100);
					    junkchar[0]="~";   junkchar[1]="`";  junkchar[2]="!";  junkchar[3]="@";  						junkchar[4]="#";
						junkchar[5]="$";   junkchar[6]="%";  junkchar[7]="^";  junkchar[8]="*";  						junkchar[9]=" ";
						junkchar[10]="+";  junkchar[11]="|"; junkchar[12]="="; junkchar[13]="\\"; 						junkchar[14]=":";
						junkchar[15]="\"";  junkchar[16]=";"; junkchar[17]="'"; junkchar[18]="<"; 						junkchar[19]=">";
						junkchar[20]="?"; junkchar[20]="&";	
					
				}
	
			strtext= l_value
			var sJunkList = ""
			
			
			for(i=0 ; i<junkchar.length; i++)
			{
				
				if(strtext.indexOf(junkchar[i])>-1)
					{
						
						if (sJunkList.length == "0")
							{
								sJunkList = junkchar[i];
							}
						else
							{
								
								sJunkList = sJunkList + ", "  + junkchar[i];
							}
						
					}
			}
			if (sJunkList != "")
			{
				{
				alert("Do not enter Special Character(s) like  "+sJunkList+"  in  "+sName+".");
				l_focus;
				return false;
				}
			}
		}
		
		/*-------------------- This function is used to check numeric/alphanumeric characters in the string ------------------ */

function validateField(mfield,fieldType) {
	
	var str=document.getElementById(mfield).value;
	
	var m
	if(fieldType=="A"){
		var valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-"
		m = "characters and numbers"
	}

	else if(fieldType=="N"){
		var valid = "0123456789."
		m = "numbers"
	}

	else if(fieldType=="C"){
		var valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
		m = "characters"
	}
	else if(fieldType=="P"){
		var valid = "0123456789-"
		m = "numbers and dashes"
	}
	else if(fieldType=="S"){
		var valid = "~!@#$%^&*()+|-=\~<>?,.;':"
		m = "special characters"
	}
	
	else
		var valid=""
	
	var ok = "yes";
	var temp;
	//l_value=eval(mfield+".value")
	//l_focus=eval(mfield+".focus()")
	//alert(l_value);
	for (var i=0; i<str.length; i++) {
		temp = "" + str.substring(i, i+1);
		
		if (valid.indexOf(temp) == -1) 
			ok = "no";
	}

	if (ok == "no") {
		alert("Invalid entry!  Only "+ m +" are accepted!");
		document.getElementById(mfield).value='';
		document.getElementById(mfield).focus();
		return false
	}
	
	if (ok == "yes" ) {
		return true;
	}
}
		
/*--------------------------------- This function is used to check string length -------------------- */

function checkLen(mfield, len, fname)	
{
	
	str = eval(mfield+".value");
	fldFoc = eval(mfield+".focus()");
	if (str.length < len)
	{
		alert(fname + " must be more than " + len + " characters.")
		fldFoc;	
		return false;
	}
}


/*----------------------------------- This function is used to check max length of the string ----------- */

function checkMaxLen(mfield, len, fname)
{
	str = eval(mfield+".value");
	fldFoc = eval(mfield+".focus()");
	
	if (str.length > len)
	{
		alert(fname + " must be less than " + len + " characters.")
		fldFoc;
		return false;
	}
	else
	{
		return true;
	}
}

function CheckStr(obj)
{
	var str;
	str = document.getElementById(obj).value;
	var i = str.indexOf("'");
	var j = str.indexOf("#");
	if(i != -1 || j!= -1 )
	{
		alert("Please Remove these signs --> ('),(#)   ");
		//document.getElementById(obj).value = " ";
		GetFocus(obj);
	}
}
			
function CheckLength(obj,str2)
  {
   
   var str;
     str = document.getElementById(obj).value;
      
     if( str != ""  )
     {
         if( str2 == "Zip1")
		  {
			if(str.length < 5)
			 {
				alert("Zip Code is Incomplete ex. 12345-1234");
				document.getElementById(obj).value = "";
				GetFocus(obj);
				return false;
			 }
          
		  }
		 else if(str2 == "Zip2")
		  {
     
			if(str.length < 4)
			 {
				alert("Zip Code is Incomplete ex. 12345-1234 ");
				document.getElementById(obj).value = "";
				GetFocus(obj);
				return false;
			 }
          }
		 else if(str2 == "year")
		  {
			if(str.length < 4)
			 {
				alert("Year is not in Proper Format ex. 2003");
				document.getElementById(obj).value = "";
				GetFocus(obj);
				return false;
			 }
     
         }
         else if(str2 == "DunNum")
		  {
			if(str.length < 9)
			 {
				alert("DUN & Bradstreet Number not in Proper Format ex. 078956252");
				document.getElementById(obj).value = "";
				GetFocus(obj);
				return false;
			 }
     
         }
     }
  }
  
 //Check the Zip code as per the format 
//Parameters required:- Textbox field name for ex. 'txtZip'.
//To be applied on:- OnBlur event.

function USCNZip(obj)
{
   var str;
   var i;
   var hyphenCount=0;
   var alphaCount=0;
   str = document.getElementById(obj).value;
  
   if( str != "" )
	{        
		for ( i = 0; i < 10 ; i++)
		{
	   			if( str.substr(i,1) == "-") 
				{
					hyphenCount += 1;										
				}
				else if( str.charCodeAt(i) > 96 && str.charCodeAt(i) < 127 )
					alphaCount += 1;
				else if( str.charCodeAt(i) > 64 && str.charCodeAt(i) < 92  )
					alphaCount += 1;
				
		}
		
		if(alphaCount > 5 || hyphenCount > 1)
		{
			alert('Invalid ZipCode Entry! Maximum 5 alphabets and 1 hyphen will be accepted for Canadian Zipcodes.');
			return false;
		}
		else
			return true;
	}
}
   
function CompareVals(obj1, obj2)  
{
	if(document.all(obj2).value != "")
	{
		if(document.all(obj1).value != document.all(obj2).value)
		{
			alert("Value does not match")
			document.all(obj2).value = ""
		}
	}
}

// Strong Password
function CheckPassword(obj1,obj2)
{
	var exp1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	var exp2 =	"abcdefghijklmnopqrstuvwxyz";
	var exp3 = "0123456789";
	var exp4 = "!@#$\"\;%^&*()_+|~=\`[]{}:<>?/.,";
	
	var str1 = document.getElementById(obj1).value; 
	var str2 = document.getElementById(obj2).value; 
	var ex=0;

	if(str2 != "")
	{
		if(str2.length < 6 || str2.length > 15)
		{
			alert("Password should be minimum 6 and maximum 15 charcters long.");
			document.getElementById(obj2).value=""; 
			GetFocus(obj2);
			return;
		}
		if(str1 == str2)
		{
			alert("Login name and Password should not be same.");
			document.getElementById(obj2).value=""; 
			GetFocus(obj2);
			return;
		}
		for(i=0; i< str2.length; i++)
		{
			if(exp1.indexOf(str2.substr(i,1))!= -1)  
			{
				ex = 1;
				i = str2.length;
			}
		}
		if(ex == 0)
		{
			alert("Please Enter Strong Password.");
			document.getElementById(obj2).value=""; 
			GetFocus(obj2);
			return;
		}
		ex=0;
		for( i=0; i< str2.length; i++)
		{
			if(exp2.indexOf(str2.substr(i,1))!= -1)
			{
				ex=1;
				i = str2.length;
			}
		}
		if(ex==0)
		{
			alert("Please Enter Strong Password.");
			document.getElementById(obj2).value=""; 
			GetFocus(obj2);
			return;
		}
		ex=0;
		for( i = 0; i< str2.length; i++)
		{
			if(exp3.indexOf(str2.substr(i,1))!= -1)
			{
				ex=1;
				i=str2.length;
			}
		}
		if(ex==0)
		{
			alert("Please Enter Strong Password.");
			document.getElementById(obj2).value=""; 
			GetFocus(obj2);
			return;
		}
		ex=0;
		for( i =0; i<str2.length; i++)
		{
			if(exp4.indexOf(str2.substr(i,1))!= -1)
			{
				ex=1;
				i=str2.length;
			}
		}
		if(ex==0)
		{
			alert("Please Enter Strong Password.");
			document.getElementById(obj2).value=""; 
			GetFocus(obj2);
			return;
		}
	}
}

function jIsInvalidChars(formField)
{
	//alert(formField);

	var warnMsg="";
   
	if((formField==null))
		warnMsg=warnMsg + "\n --  Field of the Form";
	     
	if(warnMsg!="")
	{
		warnMsg="\nERROR\n\nArguments not correctly provided : \n" + warnMsg;
		alert(warnMsg);
		return false;
	}

	/*
	We don't want to allow special characters below
	!  @ # % ^ * ( ) [ ]
	*/
     
	for (var chPos = 0; chPos < formField.value.length; chPos++) 
	{
		var ch = formField.value.charCodeAt(chPos);
		if (ch > 96 && ch < 127 )
		{
			alert("Following characters are invalid : ,")
			return true;
		}
	}
}

//STRING FUNCTIONS ENDS HERE
//--------------------------------------------------------------------------------------------------------------
//NUMERIC FUNCTIONS STARTS HERE
function jIsNumeric(num)
{
	if(isNaN(num))
		return false;
	else
		return true;
}


function jIsPositive(num)
{
	if(isNaN(num))
		return null;
		
	if((num>=0))
		return true;
	else
		return false;
}


function jIsNegative(num)
{
	if(isNaN(num))
		return null;
		
	if((num<0))
		return true;
	else
		return false;
}

/*----------This function is used to validate the value of federal tax id entered in the passed object.------------*/
/* Parameters required:- Text box object. Ex. onblur="CheckFedTaxId('txtFederalTaxID')" */

function CheckFedTaxId(obj)
  {
    var str;
	var i;
	str = document.getElementById(obj).value;
	
	  if( str != "" )
	   {
		if ( str.length < 10)
		  {
				alert("Federal Tax ID is Incomplete ex. 52-0728302");
				document.getElementById(obj).value = "";
				//GetFocus(obj);
				document.getElementById(obj).focus();
				return false;
		  }
	
	    for( i=0; i < 10; i++)
		  {
		     
		    if( i != 2)
		      {
		        if( str.substr(i,1) == "-")
		        {
		         alert("Invalid Format ex.52-0728302");
		         document.getElementById(obj).value = "";
		         //GetFocus(obj);
		         document.getElementById(obj).focus();
		         return false;
		         }
		      }
		      else if( str.substr(i,1) != "-" )
		      {
		        alert("Invalid Format ex.52-0728302");
		        document.getElementById(obj).value = "";
		        //GetFocus(obj);
		        document.getElementById(obj).focus();
		        return false;
		      }
		  }
		  
	}
 }
 
 
 function checkPhone(obj)
{
	var str;
	var si;

	str = document.getElementById(obj).value;
	
	if( str != "" )
	{ 
       
		if(str.length < 12)
		{
			alert("Telephone / Fax Number is Incomplete ex. 123-123-1234");
			document.getElementById(obj).value = "";
			GetFocus(obj);
			return false;
		}

		for ( i = 0; i < 12 ; i++)
		{
		   
			if( i != 3 && i != 7 )
			{
			   
				if( str.substr(i,1)=="-") 
				{ 
					alert("Telephone / Fax Number is not in proper Format ex. 123-123-1234");
					document.getElementById(obj).value = "";
					GetFocus(obj);
					return false;
				}
			}
			else
			{
				if( str.substr(i,1) != "-") 
				{
					alert("Telephone / Fax Number is not in proper Format ex. 123-123-1234");
					document.getElementById(obj).value = "";
					GetFocus(obj);
					return false;
				}

			}
		}
	}
}
 
 
//Check the Zip code as per the format 
//Parameters required:- Textbox field name for ex. 'txtZip'.
//To be applied on:- OnBlur event.

//function CheckZip(obj)
//  {
//   var str;
//   var i;
//   str = document.getElementById(obj).value;
//   
//   if( str != "" )
//	{ 
//       
//		if(str.length < 10)
//		{
//			alert(" Zip Code is Incomplete ex. 12345-1234");
//			document.getElementById(obj).value = "";
//			GetFocus(obj);
//			return false;
//		}
//		for ( i = 0; i < 10 ; i++)
//		{
//	   
//			if( i != 5 )
//			{
//			   
//				if( str.substr(i,1)=="-") 
//				{ 
//					alert("Zip Code is not in proper Format ex. 12345-1234");
//					document.getElementById(obj).value = "";
//					GetFocus(obj);
//					return false;
//				}
//			}
//			else
//			{
//				if( str.substr(i,1) != "-") 
//				{
//					alert("Zip Code is not in proper Format ex. 12345-1234");
//					document.getElementById(obj).value = "";
//					GetFocus(obj);
//					return false;
//				}

//			}
//		}
//   
//  }
//  }

/* onBlur event: Use for U.S.Zipcode validation*/
/*Created by MR90*/
function CheckZip(obj)
  {
   var str;
   str = document.getElementById(obj).value;
   if(/^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z] \d[a-zA-Z]\d)$/.test(str))
   {}
   else
   {
    if(document.getElementById(obj).value!="")
       {
         alert("Zip Code is not in proper Format ex. 12345-1234 or 12345");
         document.getElementById(obj).value="";
       }
   }
  }
	
/* onKeyPress event: Allows just numeric value with '-' character(Specially for U.S. Zipcode)*/
/*Created by MR90*/
function CheckZipcode()
{
    if((event.keyCode > 47 && event.keyCode < 58) || event.keyCode==45)
    {
         if(event.keyCode != 46)
         {
            //alert(" Enter the Numeric Value");
            event.cancelBubble = false;
            event.returnValue = true;
         }
    }
    else
    {
        return false;
    }
}
	
	/* This function is used to compare the value entered with the format specified.
Parameters required:- obj:- as textbox for which the format for the entered value has to be verified.
					sMask:- format to be verified as per the entered value.
					Min:- to check for minimum length of characters
PurPouse:- To check whether the value entered is correct as per the format or not.
To be applied on:-	OnBlur event.
*/

function CheckPercentage(obj)
{
	var per
	per = document.getElementById(obj).value; 
	if(isNaN(per))
	{
		alert("Enter valid numeric value for percentage");
		document.getElementById(obj).value= ""; 
		GetFocus(obj);
		return false;
	}
	if(document.getElementById(obj).getAttribute('Readonly') == false)
	{
		if( parseFloat(per)> 100)
		{
			alert("Percentage should not be higher than 100.");
			document.getElementById(obj).value= ""; 
			GetFocus(obj);
		}
	}
}

function ChkDecimal(obj)
{
	var str;
	var i;
	var x = 0;
	str = document.getElementById(obj).value;
	if(isNaN(str))
	{
		alert("Enter valid decimal value");
		document.getElementById(obj).value= "";
		GetFocus(obj);
		return false;
	}
	for(i = 0 ; i< str.length; i++)
	{
		if (str.substr(i,1) == ".")
		{
			x++;
			if( x > 1)
			{
				alert("This is not a Proper Format");
				document.getElementById(obj).value="";
				GetFocus(obj);
				return false;
			}
		}
	}
}



//NUMERIC FUNCTIONS ENDS HERE


//CURRENCY RELATED FUNCTIONS STARTS HERE
function jIsMoney(money)
{
	if((money.length==0) || (money.length==1 && money.charAt(0)=="."))
	{
		return false;
	}
	
	var countDot=0;
	for(i=0;i<money.length;i++)
	{
		alert(money.charAt(i));
		if(money.charAt(i)==".") 
			countDot++;
		else if(money.charAt(i)<"0" || money.charAt(i)>"9")
		{
			return false;
		}
			
		if(countDot>1)
		{
			return false;
		}
	}
	return true;
}

function jConvertMoney(money,txtBox)
{
	//alert("Inside ConvertMoney function.");	
	if(isNaN(money))
	{
		return null;
	}	
	var dotPos;

	if(money.length==0)
	{
		money="0.00";
	}
	else
	{
		dotPos = money.indexOf(".");
		
		if(dotPos==0)
		{
			money="0" + money;
		}
		else if(dotPos==-1)
		{
			money = money + ".";
		}
		
		dotPos = money.indexOf(".");
		cents = money.substring(dotPos + 1, money.length + 1);
		if(cents.length==0)
		{
			money = money + "00";
		}
		else if(cents.length == 1)
		{
			money = money + "0";
		}
		else if(cents.length > 2)
		{
			
			roundVal = cents.charAt(2);
			if(roundVal  >= 5)
			{
				money = parseFloat(money) + .01;
				money = money.toString();
				money = money.substring(0,dotPos + 3)
			}
			else
			{
				money = money.substring(0,dotPos + 3)
				
			}
		}
	}
	txtBox.value = money;
	//return money;
}
//CURRENCY RELATED FUNCTIONS END HERE


//Date Function Start Here.

//purpose: To compare two dates.

//Example: date1=document.frm.datefieldname1.value
//         date2=document.frm.datefieldname2.value
//			if date1 is greater than date2 function will return 
//			if (jCompareDate(date1,date2)==false)
//				{
//				 alert("Date should be proper.")
//				}
// Arguments: both arguments should be  "/" saperated date.

function jCompareDate(date1,date2)
{  
		created=date1 //period from
		issued=date2  // period to
		crt=created.split("/")
		isd=issued.split("/")		
		
		if (eval(crt[2])>eval(isd[2]))   // check for year
		{
			//alert("year2 is smaller.");
			return false;
		}
		else if(eval(crt[2])==eval(isd[2]))  // if year is equal check for months
		{
			if (eval(crt[0])>eval(isd[0]))
			{
				//alert("month2 is small");
				return false; 
			}
			
			else if (eval(crt[0])==eval(isd[0]))  // if month is equal check for date
			{	
				
				if (eval(crt[1])>eval(isd[1])) 
				{	
					//alert("Date2 is small.");
					return false;
				}
				else
				{
					//alert("Date is big");
				}
			}
			else
			{
				return true;
			}
		}
		else
		{
			//alert("Year 2 is greater");
			return true;   // if year2 is greater return true..
		}
}

/*--------------------------- This function is used to compare two dates ----------------- */
/*function y2k(number) 
{
	//alert((number < 1000) ? eval(number) + 1900 : number);
	return(number < 1000) ? number + 1900 : number; 
}*/

function isDate (day,month,year) //function copied from CommonFuns.js
{
// checks if date passed is valid
// will accept dates in following format:
// isDate(dd,mm,ccyy), or
// isDate(dd,mm) - which defaults to the current year, or
// isDate(dd) - which defaults to the current month and year.
// Note, if passed the month must be between 1 and 12, and the
// year in ccyy format.

    var today = new Date();
    year = ((!year) ? y2k(today.getYear()):year);
    month = ((!month) ? today.getMonth():month-1);
    if (!day) return false
    var test = new Date(year,month,day);
    if ( (y2k(test.getYear()) == year) &&
         (month == test.getMonth()) &&
         (day == test.getDate()) )
	{
		//alert("True");
		return true;
    }
    else
	{
		//alert("False");
		return false
	}
}

function CheckDateComparision(dd,mm,yy,dd1,mm1,yy1)
	{
	var d,m,y,d1,m1,y1
		
	d = eval(dd+"["+dd+".selectedIndex"+"]"+".value")
	m = eval(mm+"["+mm+".selectedIndex"+"]"+".value")
	y = eval(yy+".value")
	
	d1 = eval(dd1+"["+dd1+".selectedIndex"+"]"+".value")
	m1 = eval(mm1+"["+mm1+".selectedIndex"+"]"+".value")
	y1 = eval(yy1+".value")
	
	l_value=d+'/'+m+'/'+y
	l_value1=d1+'/'+m1+'/'+y1
		
	var IntDay	=l_value.substr(0,2);
	var IntMonth    =l_value.substr(3,2);
	var IntYear	=l_value.substr(6,4);
	
	
	var IntDate	= new Date(IntYear,IntMonth,IntDay);
	
	
	
	var CommDay	 =l_value1.substr(0,2);
	var CommMonth	 =l_value1.substr(3,2);
	var CommYear	 =l_value1.substr(6,4);
	
	var CommDate	 =new Date(CommYear,CommMonth,CommDay);
	if (IntDate != "" && CommDate !="")
	{
		if (IntDate > CommDate)
		{
			alert ('Date From  must be LESS THAN OR EQUAL TO  To Date.');
			eval(dd+".focus()");
			return false;
		}
	}
			
}

function CheckTime(obj)
{
    var str;
	var i;
	var hh;
	var mm;
	var inx;
	str = document.getElementById(obj).value;
	if( str != "" )
	{
		if(str.length!=5)
		{
			alert("Time is not in Proper Format");
			document.getElementById(obj).value = "";
			GetFocus(obj);
			return false;
		}
		if(str.substr(2,1) != ":")
		{
			alert("Format of Time is not valid");
			document.getElementById(obj).value="";
			GetFocus(obj);
			return false;
		}

		inx = str.indexOf(":");
		hh = parseInt(str)
		mm = parseInt(str.substr(inx+1)+":");
	    
		if(isNaN(hh))
		{
			alert("Hours must be numeric value between 0 and 23");
			document.getElementById(obj).value = "";
			GetFocus(obj);
			return false;
		}	      
		if ( hh < 0 || hh > 23)
		{
			alert("Hours must be in between 0 and 23");
			document.getElementById(obj).value = "";
			GetFocus(obj);
			return false; 
		}
	      	    
		if(isNaN(mm))
		{
			alert("Minutes must be numeric value between 0 and 59");
			document.getElementById(obj).value = "";
			GetFocus(obj);
			return false;
		}
		if ( mm < 0 || mm > 59) 
		{
			alert("Minutes must be in between 0 and 59");
			document.getElementById(obj).value = "";
			GetFocus(obj);
			return false;
		}
	}
}

// Date Function Ends Here.

//DATAGRID RELATED FUNCTIONS STARTS HERE
/*--------------- This function is used to Highlight a row in a datagrid--------------------*/
/* Parameteres required:-
	chkB:- passed as "this" from the checkbox onclick event 
	dgId:- The id of the datagrid in the form of string (single quoted).
*/
function HighlightRow(chkB,dgId)
{
	var ctrTotal=0;
	var ctrRow=0;
	var chkAll;
						
	for(i=0;i<document.forms[0].elements.length;i++)
	{
		if((document.forms[0].elements[i].type=='checkbox') && (document.forms[0].elements[i].name.indexOf(dgId) > -1))
		{
			ctrTotal=ctrTotal+1;
			if(document.forms[0].elements[i].checked==true)
			{
				ctrRow=ctrRow+1;
			}
		}	
	}
					
	if(ctrRow==(ctrTotal-1))
	{
		
		for(i=0;i<document.forms[0].elements.length;i++)
		{
			if((document.forms[0].elements[i].type=='checkbox') && (document.forms[0].elements[i].name.indexOf(dgId) > -1))
			{
				var chkName=document.forms[0].elements[i].name;
				var res=chkName.indexOf('chkHeader');
				if(res>-1)
					document.forms[0].elements[i].checked=chkB.checked;
			}
		}
	}
					
	if((chkB.checked) && (chkB.parentElement.name!='chkHeader'))
	{
		
		if(chkB.parentElement.name=='chkRow')
			chkB.parentElement.parentElement.parentElement.style.backgroundColor='#FFFFFF';
		else 
			chkB.parentElement.parentElement.style.backgroundColor='#FFFFFF';
		  
	}
	else 
	{
		
		if(chkB.parentElement.name=='chkRow')
			chkB.parentElement.parentElement.parentElement.style.backgroundColor='#ECECEC';
		else
			chkB.parentElement.parentElement.style.backgroundColor='#ECECEC';
	}
						
}
/*---------------- This function is used to identify, if any checkbox is checked or not in a datagrid--------------------*/						
/* Parameters required:-
	CheckBoxControl :- passed name of check box in item row
	dgId:- The id of the datagrid in the form of string (single quoted).
	Changed By MR87 For Same Active/DeActive/Delete Purpose but Some Change Needed.
*/
function OMSCheckSelected(CheckboxControlId, dgId, flag)
{
	//var j=0;
	var isChecked = false;
	//COMMENTED BY  MR87.
    //	var oColChk = document.forms[0].getElementsByTagName ("input");
    //	alert(oClock);
    //	for(var i=0; i<oColChk.length; i++){
    //		// alert(oColChk[i].name + ' = ' + oColChk[i].getAttribute("type"));
    //		if (oColChk[i].getAttribute("type") == "checkbox"){
    //			if (oColChk[i].name.indexOf(dgId) > -1 && oColChk[i].name.indexOf(CheckboxControlId) > -1){
    //				if (oColChk[i].checked){
    //					isChecked = true;
    //					break;
    //				}
    //			}
    //		}
    //	}
    for(i=0;i<document.forms[0].elements.length;i++)
        {
            if((document.forms[0].elements[i].type=='checkbox') && (document.forms[0].elements[i].name !="chkHeader"))
            {
                if(document.forms[0].elements[i].checked  == true)
                       isChecked= true;
            }
        }   
	if(!isChecked){
	    if (flag=='Address')
	        alert('Please select any address from address book list');
	    else
	        alert('Please select any record.');
		return false;
	}
	else
	{
	    var retValue = true;
	    
	    if ( flag=='Delete' && !confirm('Are you sure you want to delete selected records?') )
	        retValue = false;
	    else if ( flag == 'Deactivate' && !confirm('Are you sure you want to deactivate selected records?') )
	        retValue = false;
	    else if( flag == 'Activate' && !confirm('Are you sure you want to activate selected records?') )
	        retValue = false;
	    else if( flag == 'Archive' && !confirm(' Are you sure you want to archive selected records?') )
	        retValue = false;
	    else if( flag == 'Submit' && !confirm('Are you sure you want to Submit selected Batches?') )
	        retValue = false;
	    else if( flag == 'Approve Selected' && !confirm('Are you sure you want to Approve Selected Projects?') )    
	        retValue = false;
	    else
	        retValue = true;
	        
	    return retValue;
	}
	/*
	// commented by: ronald
	// old version
	// reason:	below line of code returns "string" instead of actual name of checkbox, 
	//			so indexOf always returns -1
	// code:	document.forms[0].elements[i].name.indexOf(dgId)

    var i;
    for ( i=0; i<document.forms[0].elements.length; i++ )
    {
        if ( (document.forms[0].elements[i].type == 'checkbox') && (document.forms[0].elements[i].name.indexOf(dgId) > -1) )
        {
			if ( document.forms[0].elements[i].name.indexOf(CheckBoxControlId) > -1 && document.forms[0].elements[i].checked == true )
			{
				break;            
			}
        }
    }
    // end comment
	*/
}

function OMSCheckSelected1(CheckboxControlId, dgId, flag)
{
	//var j=0;
	var isChecked = false;
	//COMMENTED BY  MR87.
    //	var oColChk = document.forms[0].getElementsByTagName ("input");
    //	alert(oClock);
    //	for(var i=0; i<oColChk.length; i++){
    //		// alert(oColChk[i].name + ' = ' + oColChk[i].getAttribute("type"));
    //		if (oColChk[i].getAttribute("type") == "checkbox"){
    //			if (oColChk[i].name.indexOf(dgId) > -1 && oColChk[i].name.indexOf(CheckboxControlId) > -1){
    //				if (oColChk[i].checked){
    //					isChecked = true;
    //					break;
    //				}
    //			}
    //		}
    //	}
    for(i=0;i<document.forms[0].elements.length;i++)
        {
            if((document.forms[0].elements[i].type=='checkbox') && (document.forms[0].elements[i].name !="chkHeader"))
            {
                if(document.forms[0].elements[i].checked  == true)
                       isChecked= true;
            }
        }   
	if(!isChecked){
	    if (flag=='Address')
	        alert('Please select any address from address book list');
	    else
	        alert('Please select any record.');
		return false;
	}
	else
	{
	    var retValue = true;
	    
	    if ( flag=='Delete' &&(dgId=='gvEmployee' || dgId=='gvClaimantDetails' || dgId=='gvProvider') )
	        return confirm('Item(s) already in use will not be Deleted.Are you sure you want to delete selected record(s)?') ;
	    else if ( flag=='Delete' && !confirm('Are you sure you want to delete selected record(s)?') )
	        retValue = false; 
	    else if ( flag == 'Deactivate' && !confirm('Items already in use will not be deactivated. Are you sure you want to deactivate selected records?') )
	        retValue = false;
	    else if( flag == 'Activate' && !confirm('Are you sure you want to activate selected records?') )
	        retValue = false;
	    else if( flag == 'Archive' && !confirm(' Are you sure you want  to archive selected records?') )
	        retValue = false;
	    else if( flag == 'Submit' && !confirm('Are you sure you want to Submit selected Batches?') )
	        retValue = false;
	    else
	        retValue = true;
	        
	    return retValue;
	}
	
}
 
 function CheckSelected(CheckboxControlId, dgId, flag)
        {
	        var j = 0;
	        var isChecked = false;
	        var oColChk = document.forms[0].getElementsByTagName ("input");
	        for(var i=0; i<oColChk.length; i++){
		        // alert(oColChk[i].name + ' = ' + oColChk[i].getAttribute("type"));
		        if (oColChk[i].getAttribute("type") == "checkbox"){
			        if (oColChk[i].name.indexOf(dgId) > -1 && oColChk[i].name.indexOf(CheckboxControlId) > -1){
				        if (oColChk[i].checked){
					        isChecked = true;
					        break;
				        }
			        }
		        }
	        }
	        if(!isChecked){
	            alert('Please select any record.');
		        return false;
	        }
	        else
	        {
	            var retValue = true;
	            if ( flag=='AllPayerPlans' && !confirm('Are you sure you want to add selected Payer Plans?') )
	                retValue = false;
	            else if ( flag == 'SelectedPlans' && !confirm('Are you sure you want to remove selected Payer Plans?') )
	                retValue = false;
	            else if ( flag == 'MstDiag' && !confirm('Are you sure you want to Import selected Diagnosis Code(s) From Master Table?') )
	                retValue=false;
	            else if ( flag == 'PraDiag' && !confirm('Are you sure you want to Delete selected Diagnosis Code(s) From Practice?') )
	                retValue=false;
	            else if ( flag == 'MstProc' && !confirm('Are you sure you want to Import selected Procedure Code(s) From Master Table?') )
	                retValue=false;
	            else if ( flag == 'PraProc' && !confirm('Are you sure you want to Delete selected Procedure Code(s) From Practice?') )
	                retValue=false;	
	            else if ( flag == 'MstMod' && !confirm('Are you sure you want to Import selected Modifier Code(s) From Master Table?') )
	                retValue=false;
	            else if ( flag == 'PraMod' && !confirm('Are you sure you want to Delete selected Modifier Code(s) From Practice?') )
	                retValue=false;
	            else if ( flag == 'TPraDiag' && !confirm('Are you sure you want to Add selected Diagnosis Code(s) into this Treatment.?') )
	                retValue=false;
	            else if ( flag == 'TTreDiag' && !confirm('Are you sure you want to Delete selected Diagnosis Code(s) From this Treatment.?') )
	                retValue=false;
	            else if ( flag == 'TPraProc' && !confirm('Are you sure you want to Add selected Procedure Code(s) into this Treatment.?') )
	                retValue=false;
	            else if ( flag == 'TTreProc' && !confirm('Are you sure you want to Delete selected Procedure Code(s) From this Treatment.?') )
	                retValue=false;
	            else if ( flag == 'MstMedi' && !confirm('Are you sure you want to Import selected Medicine(s) From Master Table?') )
	                retValue=false;
	            else if ( flag == 'PraMedi' && !confirm('Are you sure you want to Delete selected Medicine(s) From Practice?') )
	                retValue=false;
	            else if ( flag == 'ExamProcAdd' && !confirm('Are you sure you want to Add selected Procedures?') )
	                retValue=false;
	            else if ( flag == 'ExamProcRemove' && !confirm('Are you sure you want to Delete selected Procedures?') )
	                retValue=false;
                else if ( flag == 'MstPatDiag' && !confirm('Are you sure you want to Add selected Diagnosis Codes?') )
                    retValue=false;
                else if ( flag == 'SelPatDiag' && !confirm('Are you sure you want to Delete selected Diagnosis Codes?') )
                    retValue=false;
               else if ( flag == 'MstForms' && !confirm('Are you sure you want to Add selected Forms?') )
                    retValue=false;
               else if ( flag == 'CompForms' && !confirm('Are you sure you want to Delete selected Forms?') )
                    retValue=false;
	            else
	                retValue = true;
        	        
	            return retValue;
	        }
	    }

/*---------------- This function is used to Check/Uncheck all checkboxes in a datagrid--------------------*/						
/* Parameters required:-
	CheckBoxControl :- passed as "this" from the checkbox onclick event 
	dgId:- The id of the datagrid in the form of string (single quoted).
*/
function OMSSelectAll(CheckBoxControl,dgId)
    {
	    var i;
	    for(i=0;i<document.forms[0].elements.length;i++)
	    {	
		    if((document.forms[0].elements[i].type=='checkbox') && (document.forms[0].elements[i].name.indexOf(dgId) > -1))
		    {
		        if(document.forms[0].elements[i].name.indexOf('chkRow') > -1)
                    document.forms[0].elements[i].checked = CheckBoxControl.checked;
		    }
	    }
    }
    
 /*---------------- This function is used to uncheck the header corresponding to row checkboxes in a datagrid--------------------*/						
/* Parameters required:-
	CheckBoxControl :- passed as "this" from the checkbox onclick event 
	dgId:- The id of the datagrid in the form of string (single quoted).
*/   
    function OMSUnCheckHeader(CheckBoxControl,dgId)
    {
        var i,j,flag=0;
        var chk;  
        
        for(i=0;i<document.forms[0].elements.length;i++)
        {
            if((document.forms[0].elements[i].type=='checkbox') && (document.forms[0].elements[i].name.indexOf(dgId) > -1))
            {
                if(document.forms[0].elements[i].name.indexOf('chkRow') > -1)
                    if(document.forms[0].elements[i].checked  == false)
                            flag = 1;
            }
        }    	
        
        for(i=0;i<document.forms[0].elements.length;i++)
        {
            if ( flag == 1)
            {
                if((document.forms[0].elements[i].type=='checkbox') && (document.forms[0].elements[i].name.indexOf(dgId) > -1))
                {
                    if(document.forms[0].elements[i].name.indexOf('chkHeader') > -1)
                    {
                        chk = document.forms[0].elements[i];
                        chk.checked = false;
                    }
                }
            }
            else if (flag == 0)
            {
               if((document.forms[0].elements[i].type=='checkbox') && (document.forms[0].elements[i].name.indexOf(dgId) > -1))
                    if(document.forms[0].elements[i].name.indexOf('chkHeader') > -1)
                        document.forms[0].elements[i].checked = true;               
            }
        }
    }

/*----------This function is used to ask for the confirmation before deleting records.------------*/
/* Parameters required:-
	pagename:- Action to be performed if Confirm turns "true".
	
*/
	
function askDeactivate(pagename)
{
	var selectedCheckbox = '';
	for(i=0;i<document.forms[0].elements.length;i++)
	{
		if(document.forms[0].elements[i].type == "checkbox") 
		{
			if(document.forms[0].elements[i].checked == true)
			{
				if(selectedCheckbox == '')
				{
					selectedCheckbox = document.forms[0].elements[i].value;
				}
				else
				{
					
					selectedCheckbox = selectedCheckbox + "," + document.forms[0].elements[i].value;
					
				}
				
			}
		}	
	}
	if(selectedCheckbox == '')
	{
		alert("Please select the record(s) to be deleted.");
		return false;
	}
	else
	{
						
		if(confirm("Are you sure you want to delete the selected records?"))
		{	
			document.forms[0].action = pagename;
			document.forms[0].submit();
			return true;
		}
		else	
		{
			return false;
		}
	}
}

function getChkSelected()
{
	var selectedCheckbox = '';
	for(i=0;i<document.forms[0].elements.length;i++)
	{
		if(document.forms[0].elements[i].type == "checkbox") 
		{
			if(document.forms[0].elements[i].checked == true && document.forms[0].elements[i].name!="chkHeader")
			{
				if(selectedCheckbox == '')
				{
					selectedCheckbox = document.forms[0].elements[i].value;
				}
				else
				{
					selectedCheckbox = selectedCheckbox + "," + document.forms[0].elements[i].value;
				}
			}
		}
	}
	if(selectedCheckbox == '')
	{
		alert("Please select at least one value from list.");
		return false;
	}
	//Added By MR87 Bcz need of Confirmation Message.
	else
	{
	    return confirm("Items already in use will not be deleted.Are you sure you want to delete the selected records?");
	}
}
//-----------This Function is used For Confirmation Message of Selected Checkbox.
// Created By : MR87  Created On : 03/15/2007 --------------*/
//strMessage Dynamic Message as you want to show on confirmation.
function getConfirmChkSelected(strMessage)
{
	var selectedCheckbox = '';
	for(i=0;i<document.forms[0].elements.length;i++)
	{
		if(document.forms[0].elements[i].type == "checkbox") 
		{
			if(document.forms[0].elements[i].checked == true && document.forms[0].elements[i].name!="chkHeader")
			{
				if(selectedCheckbox == '')
				{
					selectedCheckbox = document.forms[0].elements[i].value;
				}
				else
				{
					selectedCheckbox = selectedCheckbox + "," + document.forms[0].elements[i].value;
				}
			}
		}
	}
	if(selectedCheckbox == '')
	{
		alert("Please select at least one value from list.");
		return false;
	}
	//Added By MR87 Bcz need of Confirmation Message.
	else
	{
	    return confirm("Are you sure you want to " + strMessage);
	    
	}
}
//-----------This Function is For Uncheck Header with respect to Row Checkbox
// Created By : MR87  Created On : 03/15/2007 --------------*/
 function ErimsUnChekcHeader()
    {
        var i,flag=0;
        var chk;  
        for(i=0;i<document.forms[0].elements.length;i++)
        {
            if((document.forms[0].elements[i].type=='checkbox'))
            {
                 if(document.forms[0].elements[i].name !="ctl00$ContentPlaceHolder1$gvVendorDetails$ctl01$chkHeader")
                    {
                    
                    if(document.forms[0].elements[i].checked  == false)
                        {  flag = 1;}
                        }
            }
        }    	
        for(i=0;i<document.forms[0].elements.length;i++)
        {
            if ( flag == 1)
            {
                if((document.forms[0].elements[i].type=='checkbox'))
                {
                    if(document.forms[0].elements[i].name =="ctl00$ContentPlaceHolder1$gvVendorDetails$ctl01$chkHeader")
                    {
                        chk = document.forms[0].elements[i];
                        chk.checked = false;
                    }
                }
            }
            else if (flag == 0)
            {
               if((document.forms[0].elements[i].type=='checkbox'))
                    if(document.forms[0].elements[i].name =="ctl00$ContentPlaceHolder1$gvVendorDetails$ctl01$chkHeader")
                        document.forms[0].elements[i].checked = true;               
            }
        }
    }

//------------Function Will Check whether Any Check box is checked or not and Show Message Dynamically 
//------------Passed and then Open window as per Passed Pagename.
//------------strMessage=Message of Confirmation As You want.
//------------strPagename=Name of Pageyou want to open in window.
//------------Created By: MR87 Created On 03/12/2007.
function getChkSelectedPara(strMessage,strPageName)
{
	var selectedCheckbox = '';
	for(i=0;i<document.forms[0].elements.length;i++)
	{
		if(document.forms[0].elements[i].type == "checkbox") 
		{
			if(document.forms[0].elements[i].checked == true && document.forms[0].elements[i].name!="chkHeader" )
			{
				if(selectedCheckbox == '')
				{
					selectedCheckbox = document.forms[0].elements[i].value;
				}
				else
				{
					selectedCheckbox = selectedCheckbox + "," + document.forms[0].elements[i].value;
				}
			}
		}
	}
	if(selectedCheckbox == '')
	{
		alert("Please select at least one value from list.");
		return false;
	}
	//Added By MR87 Bcz need of Confirmation Message.
	else
	{
	    //if (confirm("Are you sure you want to "+ strMessage + " the selected records?"))
	    //{
	         var objWindow = parent.window.radopen(strPageName+"?ProjectIds="+selectedCheckbox,"rwCommon");
             //Using the reference to the window its clientside methods can be called
             objWindow.SetSize (600,515);
             //objWindow.Top= 100;
             objWindow.MoveTo(screen.width/2 - 300 , screen.height/2 - 250);
             //objWindow.SetTitle ("IFMIS");
             objWindow.SetStatus(" ");
             objWindow.SetUrl(strPageName+"?ProjectIds="+selectedCheckbox+ "&Page=Project" );
             return false;
	    //}
	    //else
	    //{
	    //     return  false;
	    // }
	}
}
//function to set Values of All check boxes in a form as per flag value
//parameters:	frm - name of the form
//				flag- true/false value for flag
function setCheck(frm,flag)
{
	for(i=0;i<frm.elements.length;i++)
	{
		if(frm.elements[i].type=='checkbox' && frm.elements[i].disabled==false)
		{
			frm.elements[i].checked = flag;
		}
	}
}

//DATAGRID RELATED FUNCTIONS ENDS HERE

//*********function to open document starts here***********
//sUrl: URL of the page which the user want to open
//nWidth: Width of the window in which the page will open.
//nHeight: Width of thw window in which the page will oepn.
function OpenFlashDoc(sUrl, nWidth, nHeight)
{
	var attributes = 'height=' + nHeight + ', width=' + nWidth + ', status=no, resizable=no, scrollbars=no, toolbar=no, location=no, menubar=no';
	window.open(sUrl,null, attributes);
}
function OpenDoc(sUrl, nWidth, nHeight)
{
    var top = (window.screen.height - nHeight) / 2;
    var left = (window.screen.width - nWidth) / 2;

	var attributes = 'height=' + nHeight + ', top=' + top + ',left=' + left + ',width=' + nWidth + ', status=no, resizable=no, scrollbars=no, toolbar=no, location=no, menubar=no';
	window.open(sUrl,null, attributes);
	return false;
}

function OpenNonModelDoc(sUrl, nWidth, nHeight)
{
    var top = (window.screen.height - nHeight) / 2;
    var left = (window.screen.width - nWidth) / 2;
    
	var attributes = 'height=' + nHeight + ', top=' + top + ',left=' + left + ', width=' + nWidth + ', status=no, resizable=yes, scrollbars=yes, toolbar=no, location=no, menubar=no';
	window.open(sUrl,null, attributes);
	return false;
}
function OpenModelScrollbarsDoc(sUrl, nWidth, nHeight)
{
    var top = (window.screen.height - nHeight) / 2;
    var left = (window.screen.width - nWidth) / 2;
    
    var attributes = 'height=' + nHeight + ', top=' + top + ',left=' + left + ', width=' + nWidth + ', status=no, resizable=no, scrollbars=yes, toolbar=no, location=no, menubar=no';
	window.open(sUrl,null, attributes);
	return false;
}
function OpenModelDoc(sUrl, nWidth, nHeight)
{
    var top = (window.screen.height - nHeight) / 2;
    var left = (window.screen.width - nWidth) / 2;
    
    var attributes = 'height=' + nHeight + ', top=' + top + ',left=' + left + ', width=' + nWidth + ', status=no, resizable=no, scrollbars=yes, toolbar=no, location=no, menubar=no';
	window.showModalDialog(sUrl,null, attributes);
	return false;
}
//*********function to open document ends here***********

/*----------This function is used to set the focus of first textbox or dropdownlist after page is loaded.------------*/
/* Parameters required:- No parameters required */

function setFirstFocus()
{
	var i;
	for(i=0;i<document.forms[0].elements.length;i++)
	{
	
		if((document.forms[0].elements[i].type=='text') || (document.forms[0].elements[i].type=='select-one'))
		{
			document.forms[0].elements[i].focus();
				break;
		}
	}
}

//function to set focus to the control passed as argument.
function GetFocus(obj1)
{
	var obj = document.getElementById(obj1);
	if(obj!="undefined")
	{
		obj.focus();
	}
}

//************This Function is used to Clear Values of All TextBox in  a form**********
function clearAllText(frm)
{
	for(i=0;i<frm.elements.length;i++)
	{
		if(frm.elements[i].type == 'text')
		{
			frm.elements[i].value = '';
		}
		else if(frm.elements[i].type == 'textarea')
		{
			frm.elements[i].value = '';
		}
		
		else if(frm.elements[i].type == 'password')
		{
			frm.elements[i].value = '';
		}
	}
}
//*************************************************************************************


function resizeIframeByType(FirmType)
{
  
	if(FirmType == "d")
		resizeIframe('Iframe1');
	else if(FirmType == "l")
		resizeIframe('Iframe2');
	else if(FirmType =="c")
		resizeIframe('frmContainer');
	else if(FirmType == "e")
		resizeIframe('frmContainer1');
}
function resizeIframe(iframeID)
{ 
	if(self==parent) return false; /* Checks that page is in iframe. */ 
	else if(document.getElementById&&document.all) /* Sniffs for IE5+.*/ 
	
	var FramePageHeight = framePage.scrollHeight + 10; /* framePage 
	is the ID of the framed page's BODY tag. The added 10 pixels prevent an 
	unnecessary scrollbar. */ 

	//var FramePageWidth = framePage.scrollWidth + 10; 
	/* framePage 
	is the ID of the framed page's BODY tag. The added 10 pixels prevent an 
	unnecessary scrollbar. */ 

	parent.document.getElementById(iframeID).style.height=FramePageHeight; 
	/* "iframeID" is the ID of the inline frame in the parent page. */ 

	//parent.document.getElementById(iframeID).style.width=FramePageWidth; 
	/* "iframeID" is the ID of the inline frame in the parent page. */ 
}
function iframeResize(Iframe2)
{	
		var oBody = Iframe2.document.body;
		var oFrame = document.all("Iframe2");
		//alert("oFrame.style.height = " +oFrame.style.height);
		oFrame.style.height = oBody.scrollHeight + oBody.offsetHeight-oBody.clientHeight;
		//This is the alert call that miraculously makes this function work
}

function SSNValidation(ssn)
{
	var matchArr = ssn.match(/^(\d{3})-?\d{2}-?\d{4}$/);
	var numDashes = ssn.split('-').length - 1;
	if (matchArr == null || numDashes == 1)
	{
		alert('Invalid SSN. Must be 9 digits or in the form NNN-NN-NNNN.');
		msg = "does not appear to be valid";
	}
	else if (parseInt(matchArr[1],10)==0)
	{
		alert("Invalid SSN: SSN's can't start with 000.");
		msg = "does not appear to be valid";
	}
	else
	{
		msg = "appears to be valid";
		alert(ssn + "\r\n\r\n" + msg + " Social Security Number.");
	}
}

function jToLower(obj)
{
	if(obj.value!="")
		return obj.value.toLowerCase();
}

//return(currencyFormat(this,',','.',event))
/*function currencyFormat(fld, milSep, decSep, e)
{
	var sep = 0;
	var key = '';
	var i = j = 0;
	var len = len2 = 0;
	var strCheck = '0123456789';
	var aux = aux2 = '';
	var whichCode = (window.Event) ? e.which : e.keyCode;
	if (whichCode == 13) return true;  // Enter
	key = String.fromCharCode(whichCode);  // Get key value from key code
	if (strCheck.indexOf(key) == -1) return false;  // Not a valid key
	len = fld.value.length;
	for(i = 0; i < len; i++)
		if ((fld.value.charAt(i) != '0') && (fld.value.charAt(i) != decSep)) break;
	aux = '';
	for(; i < len; i++)
		if (strCheck.indexOf(fld.value.charAt(i))!=-1) aux += fld.value.charAt(i);
	aux += key;
	len = aux.length;
	if (len == 0) fld.value = '';
	if (len == 1) fld.value = '0'+ decSep + '0' + aux;
	if (len == 2) fld.value = '0'+ decSep + aux;
	if (len > 2)
	{
		aux2 = '';
		for (j = 0, i = len - 3; i >= 0; i--) 
		{
			if (j == 3)
			{
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
		alert(fld.value);
	}
	return false;
}*/

function checkrequired(which)
{
	var pass=true;
	if(document.images)
	{
		for(i=0;i<which.length;i++)
		{
			var tempobj=which.elements[i];
			if (tempobj.name.substring(0,8)=="required")
			{
				if (((tempobj.type=="text"||tempobj.type=="textarea")&& 
					tempobj.value=='')||(tempobj.type.toString().charAt(0)=="s" &&
					tempobj.selectedIndex==0))
				{
					pass=false;
					break;
				}
			}
		}
	}
	if (!pass)
	{
		shortFieldName=tempobj.name.substring(8,30).toUpperCase();
		alert("Please make sure the "+shortFieldName+" field was properly completed.");
		return false;
	}
	else
		return true;
}
//<form onSubmit="return checkrequired(this)">

function commaSplit(srcNumber)
{
	var txtNumber = '' + srcNumber;
	if (isNaN(txtNumber) || txtNumber == "")
	{
		alert("Oops!  That does not appear to be a valid number.  Please try again.");
		fieldName.select();
		fieldName.focus();
	}
	else
	{
		var rxSplit = new RegExp('([0-9])([0-9][0-9][0-9][,.])');
		var arrNumber = txtNumber.split('.');
		arrNumber[0] += '.';
		do
		{
			arrNumber[0] = arrNumber[0].replace(rxSplit, '$1,$2');
		}while(rxSplit.test(arrNumber[0]));
		
		if (arrNumber.length > 1)
		{
			return arrNumber.join('');
		}
		else
		{
			return arrNumber[0].split('.')[0];
		}
	}
}
//onClick="document.commas.inpNumber.value=commaSplit(document.commas.inpNumber.value);"

/*credit card validation
--------------------------------
onClick="return Mod10(document.Form1.CreditCard.value);"
------------------------------------------------------------------------------*/
function Mod10(ccNumb)
{	// v2.0
	if(ccNumb=="")
	{
		alert("Enter valid Credit Card Number");
		return false;
	}
	var valid = "0123456789"  // Valid digits in a credit card number
	var len = ccNumb.length;  // The length of the submitted cc number
	var iCCN = parseInt(ccNumb);  // integer of ccNumb
	var sCCN = ccNumb.toString();  // string of ccNumb
	sCCN = sCCN.replace (/^\s+|\s+$/g,'');  // strip spaces
	var iTotal = 0;  // integer total set at zero
	var bNum = true;  // by default assume it is a number
	var bResult = false;  // by default assume it is NOT a valid cc
	var temp;  // temp variable for parsing string
	var calc;  // used for calculation of each digit

	// Determine if the ccNumb is in fact all numbers
	for (var j=0; j<len; j++)
	{
		temp = "" + sCCN.substring(j, j+1);
		if (valid.indexOf(temp) == "-1"){bNum = false;}
	}

	// if it is NOT a number, you can either alert to the fact, or just pass a failure
	if(!bNum)
	{
		//alert("Not a Number");
		bResult = false;
	}

	// Determine if it is the proper length 
	if((len == 0)&&(bResult))
	{  // nothing, field is blank AND passed above # check
		bResult = false;
	} 
	else
	{  // ccNumb is a number and the proper length - let's see if it is a valid card number
		if(len >= 15)
		{  // 15 or 16 for Amex or V/MC
			for(var i=len;i>0;i--)
			{  // LOOP throught the digits of the card
				calc = parseInt(iCCN) % 10;  // right most digit
				calc = parseInt(calc);  // assure it is an integer
				iTotal += calc;  // running total of the card number as we loop - Do Nothing to first digit
				i--;  // decrement the count - move to the next digit in the card
				iCCN = iCCN / 10;                               // subtracts right most digit from ccNumb
				calc = parseInt(iCCN) % 10 ;    // NEXT right most digit
				calc = calc *2;                                 // multiply the digit by two
				// Instead of some screwy method of converting 16 to a string and then parsing 1 and 6 and then adding them to make 7,
				// I use a simple switch statement to change the value of calc2 to 7 if 16 is the multiple.
				switch(calc)
				{
					case 10: calc = 1; break;       //5*2=10 & 1+0 = 1
					case 12: calc = 3; break;       //6*2=12 & 1+2 = 3
					case 14: calc = 5; break;       //7*2=14 & 1+4 = 5
					case 16: calc = 7; break;       //8*2=16 & 1+6 = 7
			        case 18: calc = 9; break;       //9*2=18 & 1+8 = 9
			        default: calc = calc;           //4*2= 8 &   8 = 8  -same for all lower numbers
				}                                               
				iCCN = iCCN / 10;  // subtracts right most digit from ccNum
				iTotal += calc;  // running total of the card number as we loop
			}  // END OF LOOP
			if ((iTotal%10)==0)
			{  // check to see if the sum Mod 10 is zero
				bResult = true;  // This IS (or could be) a valid credit card number.
			}
			else
			{
				bResult = false;  // This could NOT be a valid credit card number
			}
		}
	}
	// change alert to on-page display or other indication as needed.
	if(bResult)
	{
		alert("This IS a valid Credit Card Number!");
	}
	if(!bResult)
	{
		alert("This is NOT a valid Credit Card Number!");
	}
	return bResult; // Return the results
}



//-----------------------------------------------------------------------------------
//format currency
//--------------
//onBlur="this.value=formatCurrency(this.value);"
//------------------------------
function formatCurrency(num)
{
	num = num.toString().replace(/\$|\,/g,'');
	if(isNaN(num))
		num = "0";
	sign = (num == (num = Math.abs(num)));
	num = Math.floor(num*100+0.50000000001);
	cents = num%100;
	num = Math.floor(num/100).toString();
	if(cents<10)
		cents = "0" + cents;
	for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++)
		num = num.substring(0,num.length-(4*i+3))+','+num.substring(num.length-(4*i+3));
	return (((sign)?'':'-') + '$' + num + '.' + cents);
}

/*
------------------------------------------------------------------
allows upto 2 decimals
---------------------------
onClick="checkDecimals(this.form.numbox, this.form.numbox.value)"
----------------------------*/
function checkDecimals(fieldName, fieldValue)
{
	decallowed = 2;  // how many decimals are allowed?
	if (isNaN(fieldValue) || fieldValue == "")
	{
		alert("Oops!  That does not appear to be a valid number.  Please try again.");
		fieldName.select();
		fieldName.focus();
	}
	else
	{
		if (fieldValue.indexOf('.') == -1) fieldValue += ".";
		dectext = fieldValue.substring(fieldValue.indexOf('.')+1, fieldValue.length);
		if (dectext.length > decallowed)
		{
			alert ("Oops!  Please enter a number with up to " + decallowed + " decimal places.  Please try again.");
			fieldName.select();
			fieldName.focus();
		}
		else
		{
			alert ("That number validated successfully.");
		}
	}
}

/*
----------------------------------------
mask test boxes
-----------------
<script type='text/javascript' src='dFilter.js'></script>
</script>

ssn mask
onKeyDown="javascript:return dFilter (event.keyCode, this, '###-##-####');"

phone no mask
onKeyDown="javascript:return dFilter (event.keyCode, this, '(###) ###-####');" 

zipcode 
onKeyDown="javascript:return dFilter (event.keyCode, this, '#####-####');" 
----------------------------------------------------

disable submit
------------------
<form onSubmit="return disableForm(this);">
--------------------------------*/
function disableForm(theform){
if (document.all || document.getElementById) {
for (i = 0; i < theform.length; i++) {
var tempobj = theform.elements[i];
if (tempobj.type.toLowerCase() == "submit" || tempobj.type.toLowerCase() == "reset")
tempobj.disabled = true;
}
setTimeout('alert("Your form has been submitted.  Notice how the submit and reset buttons were disabled upon submission.")', 2000);
return true;
}
else {
alert("The form has been submitted.  But, since you're not using IE 4+ or NS 6, the submit button was not disabled on form submission.");
return false;
   }
}



function testphone(obj1){
p=obj1.value
//alert(p)
p=p.replace("(","")
p=p.replace(")","")
p=p.replace("-","")
p=p.replace("-","")
//alert(isNaN(p))
//alert(p);
if (isNaN(p)==true){
alert("Check phone");
return false;
}
}

/*
----------------------------------------------------
ignore space even in the middle of the text
--------------------
onBlur="this.value=ignoreSpaces(this.value);"
--------------------------*/
function ignoreSpaces(string){
var temp = "";
string = '' + string;
splitstring = string.split(" ");
for(i = 0; i < splitstring.length; i++)
temp += splitstring[i];
alert(temp);
return temp;
}

/*
----------------------------------------------
image preview
------------------
<div align="center" style="line-height: 1.9em;">
Test it by locating a valid file on your hard drive:
<br>
<input type="file" id="picField" onchange="preview(this)">
<br>
<img alt="Graphic will preview here" id="previewField" src="spacer.gif">
<br> <div style="font-size: 7pt;">
-------------------------
//***** CUSTOMIZE THESE VARIABLES ***/



  // width to resize large images to
var maxWidth=100;
  // height to resize large images to
var maxHeight=100;
  // valid file types
var fileTypes=["bmp","gif","png","jpg","jpeg"];
  // the id of the preview image tag
var outImage="previewField";
  // what to display when the image is not valid
var defaultPic="DSCN0110.jpeg";

//***** DO NOT EDIT BELOW ****

function preview(what){
  var source=what.value;
  var ext=source.substring(source.lastIndexOf(".")+1,source.length).toLowerCase();
  for (var i=0; i<fileTypes.length; i++) if (fileTypes[i]==ext) break;
  globalPic=new Image();
  if (i<fileTypes.length) globalPic.src=source;
  else {
    globalPic.src=defaultPic;
    alert("THAT IS NOT A VALID IMAGE\nPlease load an image with an extention of one of the following:\n\n"+fileTypes.join(", "));
  }
  setTimeout("applyChanges()",200);
}
var globalPic;
function applyChanges(){
  var field=document.getElementById(outImage);
  var x=parseInt(globalPic.width);
  var y=parseInt(globalPic.height);
  if (x>maxWidth) {
    y*=maxWidth/x;
    x=maxWidth;
  }
  if (y>maxHeight) {
    x*=maxHeight/y;
    y=maxHeight;
  }
  field.style.display=(x<1 || y<1)?"none":"";
  field.src=globalPic.src;
  field.width=x;
  field.height=y;
}

/*
------------------------------------------------------------
change case
------------------
<input type=text name=box value="type in here!">
<input type=button value="Convert" onClick="javascript:changeCase(this.form.box)">
------------------------------*/
function changeCase(frmObj)
{
	var index;
	var tmpStr;
	var tmpChar;
	var preString;
	var postString;
	var strlen;
	tmpStr = frmObj.value.toLowerCase();
	strLen = tmpStr.length;
	if (strLen > 0)
	{
		for (index = 0; index < strLen; index++)
		{
			if (index == 0)
			{
				tmpChar = tmpStr.substring(0,1).toUpperCase();
				postString = tmpStr.substring(1,strLen);
				tmpStr = tmpChar + postString;
			}
			else
			{
				tmpChar = tmpStr.substring(index, index+1);
				if (tmpChar == " " && index < (strLen-1))
				{
					tmpChar = tmpStr.substring(index+1, index+2).toUpperCase();
					preString = tmpStr.substring(0, index+1);
					postString = tmpStr.substring(index+2,strLen);
					tmpStr = preString + tmpChar + postString;
				}
			}
		}
	}
	frmObj.value = tmpStr;
}

//--------------------------------------------------------------------
//accepts only char and numbers
//--------------------
//<input type=text name="entry" onBlur="validate(this)">
//---------------------------------------
function jvalidate(field)
{
	var valid = "abcdefghijklmnopqrstuvwxyz0123456789";
	var ok = "yes";
	var temp;
	for (var i=0; i<field.value.length; i++)
	{
		temp = "" + field.value.substring(i, i+1);
		if (valid.indexOf(temp) == "-1") ok = "no";
	}
	if (ok == "no")
	{
		alert("Invalid entry!  Only characters and numbers are accepted!");
		field.focus();
		field.select();
	}
}

//function to calculate age starts here
function padout(number)
{
	return (number < 10) ? '0' + number : number;
}

function y2k(number)
{
    return(number < 1000) ? eval(number) + 1900 : number;
}

function makeArray()
{
    for (i = 0; i<makeArray.arguments.length; i++) this[i+1] = makeArray.arguments[i];
}

var months = new makeArray('Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec');
var today = new Date();
var thisYear = y2k(today.getYear());
var thisMonth = today.getMonth()+1;
var thisDay = today.getDate();

//function HowOld(day,month,year,thisDay,thisMonth,thisYear)
function HowOld(day,month,year)
{
    var yearsold = thisYear - year, monthsold = 0, daysold = 0;

    if (thisMonth >= month)
        monthsold = thisMonth - month;
    else {
        yearsold--;
        monthsold = thisMonth + 12 - month;
    }

    if (thisDay >= day)
        daysold = thisDay - day;
    else {
        if (monthsold > 0)
            monthsold--;
        else {
            yearsold--;
            monthsold+=11;
        }
        daysold = thisDay + 31 - day;
    }

    if (yearsold < 0)
        return '';

    if ((yearsold == 0) && (monthsold == 0) && (daysold == 0))
        return '';

	//alert(yearsold + ' years, ' + monthsold + ' months, ' + daysold + ' days ');
    //return yearsold + ' years, ' + monthsold + ' months, ' + daysold + ' days ';
    return 'years' ;
}
////function to calculate age ends here
//--------------------------------------------
// Java Script calendar

var weekend = [0,6];
var weekendColor = "#e0e0e0";
var fontface = "Verdana";
var fontsize = 2;

var gNow = new Date();
var ggWinCal;
isNav = (navigator.appName.indexOf("Netscape") != -1) ? true : false;
isIE = (navigator.appName.indexOf("Microsoft") != -1) ? true : false;

Calendar.Months = ["January", "February", "March", "April", "May", "June",
"July", "August", "September", "October", "November", "December"];

// Non-Leap year Month days..
Calendar.DOMonth = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
// Leap year Month days..
Calendar.lDOMonth = [31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

function Calendar(p_item, p_WinCal, p_month, p_year, p_format) {
	if ((p_month == null) && (p_year == null))	return;

	if (p_WinCal == null)
		this.gWinCal = ggWinCal;
	else
		this.gWinCal = p_WinCal;
	
	if (p_month == null) {
		this.gMonthName = null;
		this.gMonth = null;
		this.gYearly = true;
	} else {
		this.gMonthName = Calendar.get_month(p_month);
		this.gMonth = new Number(p_month);
		this.gYearly = false;
	}

	this.gYear = p_year;
	this.gFormat = p_format;
	this.gBGColor = "white";
	this.gFGColor = "black";
	this.gTextColor = "black";
	this.gHeaderColor = "black";
	this.gReturnItem = p_item;
}

Calendar.get_month = Calendar_get_month;
Calendar.get_daysofmonth = Calendar_get_daysofmonth;
Calendar.calc_month_year = Calendar_calc_month_year;
Calendar.print = Calendar_print;

function Calendar_get_month(monthNo) {
	return Calendar.Months[monthNo];
}

function Calendar_get_daysofmonth(monthNo, p_year) {
	
	if ((p_year % 4) == 0) {
		if ((p_year % 100) == 0 && (p_year % 400) != 0)
			return Calendar.DOMonth[monthNo];
	
		return Calendar.lDOMonth[monthNo];
	} else
		return Calendar.DOMonth[monthNo];
}

function Calendar_calc_month_year(p_Month, p_Year, incr) {
	/* 
	Will return an 1-D array with 1st element being the calculated month 
	and second being the calculated year 
	after applying the month increment/decrement as specified by 'incr' parameter.
	'incr' will normally have 1/-1 to navigate thru the months.
	*/
	var ret_arr = new Array();
	
	if (incr == -1) {
		// B A C K W A R D
		if (p_Month == 0) {
			ret_arr[0] = 11;
			ret_arr[1] = parseInt(p_Year) - 1;
		}
		else {
			ret_arr[0] = parseInt(p_Month) - 1;
			ret_arr[1] = parseInt(p_Year);
		}
	} else if (incr == 1) {
		// F O R W A R D
		if (p_Month == 11) {
			ret_arr[0] = 0;
			ret_arr[1] = parseInt(p_Year) + 1;
		}
		else {
			ret_arr[0] = parseInt(p_Month) + 1;
			ret_arr[1] = parseInt(p_Year);
		}
	}
	
	return ret_arr;
}

function Calendar_print() {
	ggWinCal.print();
}

function Calendar_calc_month_year(p_Month, p_Year, incr) {
	/* 
	Will return an 1-D array with 1st element being the calculated month 
	and second being the calculated year 
	after applying the month increment/decrement as specified by 'incr' parameter.
	'incr' will normally have 1/-1 to navigate thru the months.
	*/
	var ret_arr = new Array();
	
	if (incr == -1) {
		// B A C K W A R D
		if (p_Month == 0) {
			ret_arr[0] = 11;
			ret_arr[1] = parseInt(p_Year) - 1;
		}
		else {
			ret_arr[0] = parseInt(p_Month) - 1;
			ret_arr[1] = parseInt(p_Year);
		}
	} else if (incr == 1) {
		// F O R W A R D
		if (p_Month == 11) {
			ret_arr[0] = 0;
			ret_arr[1] = parseInt(p_Year) + 1;
		}
		else {
			ret_arr[0] = parseInt(p_Month) + 1;
			ret_arr[1] = parseInt(p_Year);
		}
	}
	
	return ret_arr;
}

// This is for compatibility with Navigator 3, we have to create and discard one object before the prototype object exists.
new Calendar();

Calendar.prototype.getMonthlyCalendarCode = function() {
	var vCode = "";
	var vHeader_Code = "";
	var vData_Code = "";
	
	// Begin Table Drawing code here..
	vCode = vCode + "<TABLE BORDER=1 BGCOLOR=\"" + this.gBGColor + "\">";
	
	vHeader_Code = this.cal_header();
	vData_Code = this.cal_data();
	vCode = vCode + vHeader_Code + vData_Code;
	
	vCode = vCode + "</TABLE>";
	
	return vCode;
}

Calendar.prototype.show = function() {
	var vCode = "";
	
	this.gWinCal.document.open();

	// Setup the page...
	this.wwrite("<html>");
	this.wwrite("<head><title>Calendar</title>");
	this.wwrite("</head>");
	this.wwrite("<body " +"link=\"" + this.gLinkColor + "\" " +"vlink=\"" + this.gLinkColor + "\" " +"alink=\"" + this.gLinkColor + "\" " +"text=\"" + this.gTextColor + "\">");
	this.wwriteA("<FONT FACE='" + fontface + "' SIZE=2><B>");
	this.wwriteA(this.gMonthName + " " + this.gYear);
	this.wwriteA("</B><BR>");

	// Show navigation buttons
	var prevMMYYYY = Calendar.calc_month_year(this.gMonth, this.gYear, -1);
	var prevMM = prevMMYYYY[0];
	var prevYYYY = prevMMYYYY[1];

	var nextMMYYYY = Calendar.calc_month_year(this.gMonth, this.gYear, 1);
	var nextMM = nextMMYYYY[0];
	var nextYYYY = nextMMYYYY[1];
	
	this.wwrite("<TABLE WIDTH='100%' BORDER=1 CELLSPACING=0 CELLPADDING=0 BGCOLOR='#e0e0e0'><TR><TD ALIGN=center>");
	this.wwrite("[<A HREF=\"" +
		"javascript:window.opener.Build(" + 
		"'" + this.gReturnItem + "', '" + this.gMonth + "', '" + (parseInt(this.gYear)-1) + "', '" + this.gFormat + "'" +
		");" +
		"\"><<<\/A>]</TD><TD ALIGN=center>");
	this.wwrite("[<A HREF=\"" +
		"javascript:window.opener.Build(" + 
		"'" + this.gReturnItem + "', '" + prevMM + "', '" + prevYYYY + "', '" + this.gFormat + "'" +
		");" +
		"\"><<\/A>]</TD><TD ALIGN=center>");
	this.wwrite("[<A HREF=\"javascript:window.print();\">Print</A>]</TD><TD ALIGN=center>");
	this.wwrite("[<A HREF=\"" +
		"javascript:window.opener.Build(" + 
		"'" + this.gReturnItem + "', '" + nextMM + "', '" + nextYYYY + "', '" + this.gFormat + "'" +
		");" +
		"\">><\/A>]</TD><TD ALIGN=center>");
	this.wwrite("[<A HREF=\"" +
		"javascript:window.opener.Build(" + 
		"'" + this.gReturnItem + "', '" + this.gMonth + "', '" + (parseInt(this.gYear)+1) + "', '" + this.gFormat + "'" +
		");" +
		"\">>><\/A>]</TD></TR></TABLE><BR>");

	// Get the complete calendar code for the month..
	vCode = this.getMonthlyCalendarCode();
	this.wwrite(vCode);

	this.wwrite("</font></body></html>");
	this.gWinCal.document.close();
}

Calendar.prototype.showY = function() {
	var vCode = "";
	var i;
	var vr, vc, vx, vy;		// Row, Column, X-coord, Y-coord
	var vxf = 285;			// X-Factor
	var vyf = 200;			// Y-Factor
	var vxm = 10;			// X-margin
	var vym;				// Y-margin
	if (isIE)	vym = 75;
	else if (isNav)	vym = 25;
	
	this.gWinCal.document.open();

	this.wwrite("<html>");
	this.wwrite("<head><title>Calendar</title>");
	this.wwrite("<style type='text/css'>\n<!--");
	for (i=0; i<12; i++) {
		vc = i % 3;
		if (i>=0 && i<= 2)	vr = 0;
		if (i>=3 && i<= 5)	vr = 1;
		if (i>=6 && i<= 8)	vr = 2;
		if (i>=9 && i<= 11)	vr = 3;
		
		vx = parseInt(vxf * vc) + vxm;
		vy = parseInt(vyf * vr) + vym;

		this.wwrite(".lclass" + i + " {position:absolute;top:" + vy + ";left:" + vx + ";}");
	}
	this.wwrite("-->\n</style>");
	this.wwrite("</head>");

	this.wwrite("<body " + 
		"link=\"" + this.gLinkColor + "\" " + 
		"vlink=\"" + this.gLinkColor + "\" " +
		"alink=\"" + this.gLinkColor + "\" " +
		"text=\"" + this.gTextColor + "\">");
	this.wwrite("<FONT FACE='" + fontface + "' SIZE=2><B>");
	this.wwrite("Year : " + this.gYear);
	this.wwrite("</B><BR>");

	// Show navigation buttons
	var prevYYYY = parseInt(this.gYear) - 1;
	var nextYYYY = parseInt(this.gYear) + 1;
	
	this.wwrite("<TABLE WIDTH='100%' BORDER=1 CELLSPACING=0 CELLPADDING=0 BGCOLOR='#e0e0e0'><TR><TD ALIGN=center>");
	this.wwrite("[<A HREF=\"" +
		"javascript:window.opener.Build(" + 
		"'" + this.gReturnItem + "', null, '" + prevYYYY + "', '" + this.gFormat + "'" +
		");" +
		"\" alt='Prev Year'><<<\/A>]</TD><TD ALIGN=center>");
	this.wwrite("[<A HREF=\"javascript:window.print();\">Print</A>]</TD><TD ALIGN=center>");
	this.wwrite("[<A HREF=\"" +	"javascript:window.opener.Build(" + "'" + this.gReturnItem + "', null, '" + nextYYYY + "', '" + this.gFormat + "'" +");" +
		"\">>><\/A>]</TD></TR></TABLE><BR>");

	// Get the complete calendar code for each month..
	
	var j;
	for (i=11; i>=0; i--) 
	{
		if (isIE)
			this.wwrite("<DIV ID=\"layer" + i + "\" CLASS=\"lclass" + i + "\">");
		else if (isNav)
			this.wwrite("<LAYER ID=\"layer" + i + "\" CLASS=\"lclass" + i + "\">");

		this.gMonth = i;
		this.gMonthName = Calendar.get_month(this.gMonth);
		vCode = this.getMonthlyCalendarCode();
		this.wwrite(this.gMonthName + "/" + this.gYear + "<BR>");
		this.wwrite(vCode);

		if (isIE)
			this.wwrite("</DIV>");
		else if (isNav)
			this.wwrite("</LAYER>");
	}

	this.wwrite("</font><BR></body></html>");
	this.gWinCal.document.close();
}

Calendar.prototype.wwrite = function(wtext) 
{
	this.gWinCal.document.writeln(wtext);
}

Calendar.prototype.wwriteA = function(wtext) 
{
	this.gWinCal.document.write(wtext);
}

Calendar.prototype.cal_header = function() 
{
	var vCode = "";
	
	vCode = vCode + "<TR>";
	vCode = vCode + "<TD WIDTH='14%'><FONT SIZE='2' FACE='" + fontface + "' COLOR='" + this.gHeaderColor + "'><B>Sun</B></FONT></TD>";
	vCode = vCode + "<TD WIDTH='14%'><FONT SIZE='2' FACE='" + fontface + "' COLOR='" + this.gHeaderColor + "'><B>Mon</B></FONT></TD>";
	vCode = vCode + "<TD WIDTH='14%'><FONT SIZE='2' FACE='" + fontface + "' COLOR='" + this.gHeaderColor + "'><B>Tue</B></FONT></TD>";
	vCode = vCode + "<TD WIDTH='14%'><FONT SIZE='2' FACE='" + fontface + "' COLOR='" + this.gHeaderColor + "'><B>Wed</B></FONT></TD>";
	vCode = vCode + "<TD WIDTH='14%'><FONT SIZE='2' FACE='" + fontface + "' COLOR='" + this.gHeaderColor + "'><B>Thu</B></FONT></TD>";
	vCode = vCode + "<TD WIDTH='14%'><FONT SIZE='2' FACE='" + fontface + "' COLOR='" + this.gHeaderColor + "'><B>Fri</B></FONT></TD>";
	vCode = vCode + "<TD WIDTH='16%'><FONT SIZE='2' FACE='" + fontface + "' COLOR='" + this.gHeaderColor + "'><B>Sat</B></FONT></TD>";
	vCode = vCode + "</TR>";
	
	return vCode;
}

Calendar.prototype.cal_data = function() 
{
	var vDate = new Date();
	vDate.setDate(1);
	vDate.setMonth(this.gMonth);
	vDate.setFullYear(this.gYear);
	var vFirstDay=vDate.getDay();
	var vDay=1;
	var vLastDay=Calendar.get_daysofmonth(this.gMonth, this.gYear);
	var vOnLastDay=0;
	var vCode = "";
	
	vCode = vCode + "<TR>";
	for (i=0; i<vFirstDay; i++) 
	{
		vCode = vCode + "<TD WIDTH='14%'" + this.write_weekend_string(i) + "><FONT SIZE='2' FACE='" + fontface + "'> </FONT></TD>";
	}
	for (j=vFirstDay; j<7; j++) 
	{
		vCode = vCode + "<TD WIDTH='14%'" + this.write_weekend_string(j) + "><FONT SIZE='2' FACE='" + fontface + "'>" + "<A HREF='#' " + 
				"onClick=\"self.opener.document." + this.gReturnItem + ".value='" + 
				this.format_data(vDay) + 
				"';window.close();\">" + 
				this.format_day(vDay) + 
			"</A>" + 
			"</FONT></TD>";
		vDay=vDay + 1;
	}
	vCode = vCode + "</TR>";
	
	for (k=2; k<7; k++) 
	{
		vCode = vCode + "<TR>";

		for (j=0; j<7; j++) 
		{
			vCode = vCode + "<TD WIDTH='14%'" + this.write_weekend_string(j) + "><FONT SIZE='2' FACE='" + fontface + "'>" + 
				"<A HREF='#' " + "onClick=\"self.opener.document." + this.gReturnItem + ".value='" + this.format_data(vDay) + "';window.close();\">" + 
				this.format_day(vDay) + 
				"</A>" + 
				"</FONT></TD>";
			vDay=vDay + 1;

			if (vDay > vLastDay) 
			{
				vOnLastDay = 1;
				break;
			}
		}

		if (j == 6)
			vCode = vCode + "</TR>";
		if (vOnLastDay == 1)
			break;
	}
	
	// Fill up the rest of last week with proper blanks, so that we get proper square blocks
	for (m=1; m<(7-j); m++) 
	{
		if (this.gYearly)
			vCode = vCode + "<TD WIDTH='14%'" + this.write_weekend_string(j+m) + 
			"><FONT SIZE='2' FACE='" + fontface + "' COLOR='gray'> </FONT></TD>";
		else
			vCode = vCode + "<TD WIDTH='14%'" + this.write_weekend_string(j+m) + 
			"><FONT SIZE='2' FACE='" + fontface + "' COLOR='gray'>" + m + "</FONT></TD>";
	}
	
	return vCode;
}

Calendar.prototype.format_day = function(vday) 
{
	var vNowDay = gNow.getDate();
	var vNowMonth = gNow.getMonth();
	var vNowYear = gNow.getFullYear();

	if (vday == vNowDay && this.gMonth == vNowMonth && this.gYear == vNowYear)
		return ("<FONT COLOR=\"RED\"><B>" + vday + "</B></FONT>");
	else
		return (vday);
}

Calendar.prototype.write_weekend_string = function(vday) 
{
	var i;

	// Return special formatting for the weekend day.
	for (i=0; i<weekend.length; i++) 
	{
		if (vday == weekend[i])
			return (" BGCOLOR=\"" + weekendColor + "\"");
	}
	
	return "";
}

Calendar.prototype.format_data = function(p_day)
{
	var vData;
	var vMonth = 1 + this.gMonth;
	vMonth = (vMonth.toString().length < 2) ? "0" + vMonth : vMonth;
	var vMon = Calendar.get_month(this.gMonth).substr(0,3).toUpperCase();
	var vFMon = Calendar.get_month(this.gMonth).toUpperCase();
	var vY4 = new String(this.gYear);
	var vY2 = new String(this.gYear.substr(2,2));
	var vDD = (p_day.toString().length < 2) ? "0" + p_day : p_day;

	switch (this.gFormat)
	{
		case "MM\/DD\/YYYY" :
			vData = vMonth + "\/" + vDD + "\/" + vY4;
			break;
		case "MM\/DD\/YY" :
			vData = vMonth + "\/" + vDD + "\/" + vY2;
			break;
		case "MM-DD-YYYY" :
			vData = vMonth + "-" + vDD + "-" + vY4;
			break;
		case "MM-DD-YY" :
			vData = vMonth + "-" + vDD + "-" + vY2;
			break;
		case "DD\/MON\/YYYY" :
			vData = vDD + "\/" + vMon + "\/" + vY4;
			break;
		case "DD\/MON\/YY" :
			vData = vDD + "\/" + vMon + "\/" + vY2;
			break;
		case "DD-MON-YYYY" :
			vData = vDD + "-" + vMon + "-" + vY4;
			break;
		case "DD-MON-YY" :
			vData = vDD + "-" + vMon + "-" + vY2;
			break;
		case "DD\/MONTH\/YYYY" :
			vData = vDD + "\/" + vFMon + "\/" + vY4;
			break;
		case "DD\/MONTH\/YY" :
			vData = vDD + "\/" + vFMon + "\/" + vY2;
			break;
		case "DD-MONTH-YYYY" :
			vData = vDD + "-" + vFMon + "-" + vY4;
			break;
		case "DD-MONTH-YY" :
			vData = vDD + "-" + vFMon + "-" + vY2;
			break;
		case "DD\/MM\/YYYY" :
			vData = vDD + "\/" + vMonth + "\/" + vY4;
			break;
		case "DD\/MM\/YY" :
			vData = vDD + "\/" + vMonth + "\/" + vY2;
			break;
		case "DD-MM-YYYY" :
			vData = vDD + "-" + vMonth + "-" + vY4;
			break;
		case "DD-MM-YY" :
			vData = vDD + "-" + vMonth + "-" + vY2;
			break;
		default :
			vData = vMonth + "\/" + vDD + "\/" + vY4;
	 }

	return vData;
}

function Build(p_item, p_month, p_year, p_format) 
{
	var p_WinCal = ggWinCal;
	gCal = new Calendar(p_item, p_WinCal, p_month, p_year, p_format);

	// Customize your Calendar here..
	gCal.gBGColor="white";
	gCal.gLinkColor="black";
	gCal.gTextColor="black";
	gCal.gHeaderColor="darkgreen";
	if (gCal.gYearly)	gCal.showY();
	else	gCal.show();
}

function show_calendar() 
{
	p_item = arguments[0];
	if (arguments[1] == null)
		p_month = new String(gNow.getMonth());
	else
		p_month = arguments[1];
	if (arguments[2] == "" || arguments[2] == null)
		p_year = new String(gNow.getFullYear().toString());
	else
		p_year = arguments[2];
	if (arguments[3] == null)
		p_format = "MM/DD/YYYY";
	else
		p_format = arguments[3];

	vWinCal = window.open("", "Calendar","width=250,height=250,status=no,resizable=no,top=200,left=200");
	vWinCal.opener = self;
	ggWinCal = vWinCal;

	Build(p_item, p_month, p_year, p_format);
}

function show_yearly_calendar(p_item, p_year, p_format) 
{
	
	if (p_year == null || p_year == "")
		p_year = new String(gNow.getFullYear().toString());
	if (p_format == null || p_format == "")
		p_format = "MM/DD/YYYY";

	var vWinCal = window.open("", "Calendar", "scrollbars=yes");
	vWinCal.opener = self;
	ggWinCal = vWinCal;

	Build(p_item, null, p_year, p_format);
}

/**********************************************************************/
//Javascript functions to Mask US Phone, Currency, SSN and Date - Added By Hardik On 19th Oct'06
/**********************************************************************/

function jm_currencymask(t)
{var patt = /(\d*)\.{1}(\d{0,2})/;
var donepatt = /^(\d*)\.{1}(\d{2})$/;
var str = t.value;
var result;
if (!str.match(donepatt))
{result = str.match(patt);
if (result!= null)
{t.value = t.value.replace(/[^\d]/gi,'');
str = result[1] + '.' + result[2] ;
t.value = str;
}else{
if (t.value.match(/[^\d]/gi))
t.value = t.value.replace(/[^\d]/gi,'');}
}}

function jm_datemask(t)
{var donepatt = /^(\d{2})\/(\d{2})\/(\d{4})$/;
var patt = /(\d{2}).*(\d{2}).*(\d{4})/;
var str = t.value;
if (!str.match(donepatt))
{result = str.match(patt);
if (result!= null)
{t.value = t.value.replace(/[^\d]/gi,'');
str = result[1] + '/' + result[2] + '/' + result[3];
t.value = str;
}else{
if (t.value.match(/[^\d]/gi))
t.value = t.value.replace(/[^\d]/gi,'');
}}}

function jm_phonemask(t)
{var patt1 = /(\d{3}).*(\d{3}).*(\d{4})/;
var patt2 = /^\((\d{3})\).(\d{3})-(\d{4})$/;
var patt3 = /^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$/;
var str = t.value;
var result;
if (!str.match(patt2))
{result = str.match(patt1);
if (result!= null)
{t.value = t.value.replace(/[^\d]/gi,'');
str = '(' + result[1] + ') ' + result[2] + '-' + result[3];
t.value = str;
}else{
if (t.value.match(/[^\d]/gi))
t.value = t.value.replace(/[^\d]/gi,'');
}}}

function jm_ssnmask(t)
{var patt = /(\d{3}).*(\d{2}).*(\d{4})/;
var donepatt = /^(\d{3})-(\d{2})-(\d{4})$/;
var str = t.value;
var result;
if (!str.match(donepatt))
{result = str.match(patt);
if (result!= null)
{t.value = t.value.replace(/[^\d]/gi,'');
str = result[1] + '-' + result[2] + '-' + result[3];
t.value = str;
}else{
if (t.value.match(/[^\d]/gi))
t.value = t.value.replace(/[^\d]/gi,'');}
}}


/************************************************************************/
//Javascript Code for sliders range.js
/************************************************************************/
function Range() {
	this._value = 0;
	this._minimum = 0;
	this._maximum = 100;
	this._extent = 0;

	this._isChanging = false;
}

Range.prototype.setValue = function (value) {
	value = Math.round(parseFloat(value));
	if (isNaN(value)) return;
	if (this._value != value) {
		if (value + this._extent > this._maximum)
			this._value = this._maximum - this._extent;
		else if (value < this._minimum)
			this._value = this._minimum;
		else
			this._value = value;
		if (!this._isChanging && typeof this.onchange == "function")
			 this.onchange();
	}
};

Range.prototype.getValue = function () {
	return this._value;
};

Range.prototype.setExtent = function (extent) {
	if (this._extent != extent) {
		if (extent < 0)
			this._extent = 0;
		else if (this._value + extent > this._maximum)
			this._extent = this._maximum - this._value;
		else
			this._extent = extent;
		if (!this._isChanging && typeof this.onchange == "function")
			this.onchange();
	}
};

Range.prototype.getExtent = function () {
	return this._extent;
};

Range.prototype.setMinimum = function (minimum) {
	if (this._minimum != minimum) {
		var oldIsChanging = this._isChanging;
		this._isChanging = true;

		this._minimum = minimum;

		if (minimum > this._value)
			this.setValue(minimum);
		if (minimum > this._maximum) {
			this._extent = 0;
			this.setMaximum(minimum);
			this.setValue(minimum)
		}
		if (minimum + this._extent > this._maximum)
			this._extent = this._maximum - this._minimum;

		this._isChanging = oldIsChanging;
		if (!this._isChanging && typeof this.onchange == "function")
			this.onchange();
	}
};

Range.prototype.getMinimum = function () {
	return this._minimum;
};

Range.prototype.setMaximum = function (maximum) {
	if (this._maximum != maximum) {
		var oldIsChanging = this._isChanging;
		this._isChanging = true;

		this._maximum = maximum;

		if (maximum < this._value)
			this.setValue(maximum - this._extent);
		if (maximum < this._minimum) {
			this._extent = 0;
			this.setMinimum(maximum);
			this.setValue(this._maximum);
		}
		if (maximum < this._minimum + this._extent)
			this._extent = this._maximum - this._minimum;
		if (maximum < this._value + this._extent)
			this._extent = this._maximum - this._value;

		this._isChanging = oldIsChanging;
		if (!this._isChanging && typeof this.onchange == "function")
			this.onchange();
	}
};

Range.prototype.getMaximum = function () {
	return this._maximum;
};
/************************************************************************/
//Javascript Code for sliders slider.js
/************************************************************************/
Slider.isSupported = typeof document.createElement != "undefined" &&
	typeof document.documentElement != "undefined" &&
	typeof document.documentElement.offsetWidth == "number";


function Slider(oElement, oInput,min,max, sOrientation) {
	if (!oElement) return;
	this._orientation = sOrientation || "horizontal";
	this._range =new Range();
    
    this._range._minimum = min;
	this._range._maximum = max;

	this._range.setExtent(0);
	this._blockIncrement = 10;
	this._unitIncrement = 1;
	this._timer = new Timer(100);

	if (Slider.isSupported && oElement) {

		this.document = oElement.ownerDocument || oElement.document;

		this.element = oElement;
		this.element.slider = this;
		this.element.unselectable = "on";

		// add class name tag to class name
		this.element.className = this._orientation + " " + this.classNameTag + " " + this.element.className;

		// create line
		this.line = this.document.createElement("DIV");
		this.line.className = "line";
		this.line.unselectable = "on";
		this.line.appendChild(this.document.createElement("DIV"));
		this.element.appendChild(this.line);

		// create handle
		this.handle = this.document.createElement("DIV");
		this.handle.className = "handle";
		this.handle.unselectable = "on";
		this.handle.appendChild(this.document.createElement("DIV"));
		this.handle.firstChild.appendChild(
			this.document.createTextNode(String.fromCharCode(160)));
		this.element.appendChild(this.handle);
	}

	this.input = oInput;

	// events
	var oThis = this;
	this._range.onchange = function () {
		oThis.recalculate();
		if (typeof oThis.onchange == "function")
			oThis.onchange();
	};

	if (Slider.isSupported && oElement) {
		this.element.onfocus		= Slider.eventHandlers.onfocus;
		this.element.onblur			= Slider.eventHandlers.onblur;
		this.element.onmousedown	= Slider.eventHandlers.onmousedown;
		this.element.onmouseover	= Slider.eventHandlers.onmouseover;
		this.element.onmouseout		= Slider.eventHandlers.onmouseout;
		this.element.onkeydown		= Slider.eventHandlers.onkeydown;
		this.element.onkeypress		= Slider.eventHandlers.onkeypress;
		this.element.onmousewheel	= Slider.eventHandlers.onmousewheel;
		this.handle.onselectstart	=
		this.element.onselectstart	= function () {return false; };

		this._timer.ontimer = function () {
			oThis.ontimer();
		};

		// extra recalculate for ie
		window.setTimeout(function() {
			oThis.recalculate();
		}, 1);
	}
	else {
		this.input.onchange = function (e) {
			oThis.setValue(oThis.input.value);
		};
	}
}

Slider.eventHandlers = {

	// helpers to make events a bit easier
	getEvent:	function (e, el) {
		if (!e) {
			if (el)
				e = el.document.parentWindow.event;
			else
				e = window.event;
		}
		if (!e.srcElement) {
			var el = e.target;
			while (el != null && el.nodeType != 1)
				el = el.parentNode;
			e.srcElement = el;
		}
		if (typeof e.offsetX == "undefined") {
			e.offsetX = e.layerX;
			e.offsetY = e.layerY;
		}

		return e;
	},

	getDocument:	function (e) {
		if (e.target)
			return e.target.ownerDocument;
		return e.srcElement.document;
	},

	getSlider:	function (e) {
		var el = e.target || e.srcElement;
		while (el != null && el.slider == null)	{
			el = el.parentNode;
		}
		if (el)
			return el.slider;
		return null;
	},

	getLine:	function (e) {
		var el = e.target || e.srcElement;
		while (el != null && el.className != "line")	{
			el = el.parentNode;
		}
		return el;
	},

	getHandle:	function (e) {
		var el = e.target || e.srcElement;
		var re = /handle/;
		while (el != null && !re.test(el.className))	{
			el = el.parentNode;
		}
		return el;
	},
	// end helpers

	onfocus:	function (e) {
		var s = this.slider;
		s._focused = true;
		s.handle.className = "handle hover";
	},

	onblur:	function (e) {
		var s = this.slider
		s._focused = false;
		s.handle.className = "handle";
	},

	onmouseover:	function (e) {
		e = Slider.eventHandlers.getEvent(e, this);
		var s = this.slider;
		if (e.srcElement == s.handle)
			s.handle.className = "handle hover";
	},

	onmouseout:	function (e) {
		e = Slider.eventHandlers.getEvent(e, this);
		var s = this.slider;
		if (e.srcElement == s.handle && !s._focused)
			s.handle.className = "handle";
	},

	onmousedown:	function (e) {
		e = Slider.eventHandlers.getEvent(e, this);
		var s = this.slider;
		if (s.element.focus)
			s.element.focus();

		Slider._currentInstance = s;
		var doc = s.document;

		if (doc.addEventListener) {
			doc.addEventListener("mousemove", Slider.eventHandlers.onmousemove, true);
			doc.addEventListener("mouseup", Slider.eventHandlers.onmouseup, true);
		}
		else if (doc.attachEvent) {
			doc.attachEvent("onmousemove", Slider.eventHandlers.onmousemove);
			doc.attachEvent("onmouseup", Slider.eventHandlers.onmouseup);
			doc.attachEvent("onlosecapture", Slider.eventHandlers.onmouseup);
			s.element.setCapture();
		}

		if (Slider.eventHandlers.getHandle(e)) {	// start drag
			Slider._sliderDragData = {
				screenX:	e.screenX,
				screenY:	e.screenY,
				dx:			e.screenX - s.handle.offsetLeft,
				dy:			e.screenY - s.handle.offsetTop,
				startValue:	s.getValue(),
				slider:		s
			};
		}
		else {
			var lineEl = Slider.eventHandlers.getLine(e);
			s._mouseX = e.offsetX + (lineEl ? s.line.offsetLeft : 0);
			s._mouseY = e.offsetY + (lineEl ? s.line.offsetTop : 0);
			s._increasing = null;
			s.ontimer();
		}
	},
	onmousemove:	function (e) {
		e = Slider.eventHandlers.getEvent(e, this);

		if (Slider._sliderDragData) {	// drag
			var s = Slider._sliderDragData.slider;

			var boundSize = s.getMaximum() - s.getMinimum();
			var size, pos, reset;

			if (s._orientation == "horizontal") {
				size = s.element.offsetWidth - s.handle.offsetWidth;
				pos = e.screenX - Slider._sliderDragData.dx;
				reset = Math.abs(e.screenY - Slider._sliderDragData.screenY) > 100;
			}
			else {
				size = s.element.offsetHeight - s.handle.offsetHeight;
				pos = s.element.offsetHeight - s.handle.offsetHeight -
					(e.screenY - Slider._sliderDragData.dy);
				reset = Math.abs(e.screenX - Slider._sliderDragData.screenX) > 100;
			}
			s.setValue(reset ? Slider._sliderDragData.startValue :
						s.getMinimum() + boundSize * pos / size);
						// value change can be checked here
						
			return false;
		}
		else {
			var s = Slider._currentInstance;
			if (s != null) {
				var lineEl = Slider.eventHandlers.getLine(e);
				s._mouseX = e.offsetX + (lineEl ? s.line.offsetLeft : 0);
				s._mouseY = e.offsetY + (lineEl ? s.line.offsetTop : 0);
			}
		}

	},

	onmouseup:	function (e) {
		e = Slider.eventHandlers.getEvent(e, this);
		var s = Slider._currentInstance;
		var doc = s.document;
		if (doc.removeEventListener) {
			doc.removeEventListener("mousemove", Slider.eventHandlers.onmousemove, true);
			doc.removeEventListener("mouseup", Slider.eventHandlers.onmouseup, true);
		}
		else if (doc.detachEvent) {
			doc.detachEvent("onmousemove", Slider.eventHandlers.onmousemove);
			doc.detachEvent("onmouseup", Slider.eventHandlers.onmouseup);
			doc.detachEvent("onlosecapture", Slider.eventHandlers.onmouseup);
			s.element.releaseCapture();
		}

		if (Slider._sliderDragData) {	// end drag
			Slider._sliderDragData = null;
		}
		else {
			s._timer.stop();
			s._increasing = null;
		}
		Slider._currentInstance = null;
	},

	onkeydown:	function (e) {
		e = Slider.eventHandlers.getEvent(e, this);
		//var s = Slider.eventHandlers.getSlider(e);
		var s = this.slider;
		var kc = e.keyCode;
		switch (kc) {
			case 33:	// page up
				s.setValue(s.getValue() + s.getBlockIncrement());
				break;
			case 34:	// page down
				s.setValue(s.getValue() - s.getBlockIncrement());
				break;
			case 35:	// end
				s.setValue(s.getOrientation() == "horizontal" ?
					s.getMaximum() :
					s.getMinimum());
				break;
			case 36:	// home
				s.setValue(s.getOrientation() == "horizontal" ?
					s.getMinimum() :
					s.getMaximum());
				break;
			case 38:	// up
			case 39:	// right
				s.setValue(s.getValue() + s.getUnitIncrement());
				break;

			case 37:	// left
			case 40:	// down
				s.setValue(s.getValue() - s.getUnitIncrement());
				break;
		}

		if (kc >= 33 && kc <= 40) {
			return false;
		}
	},
	onkeypress:	function (e) {
		e = Slider.eventHandlers.getEvent(e, this);
		var kc = e.keyCode;
		if (kc >= 33 && kc <= 40) {
			return false;
		}
	},

	onmousewheel:	function (e) {
		e = Slider.eventHandlers.getEvent(e, this);
		var s = this.slider;
		if (s._focused) {
			s.setValue(s.getValue() + e.wheelDelta / 120 * s.getUnitIncrement());
			// windows inverts this on horizontal sliders. That does not
			// make sense to me
			return false;
		}
	}
};

Slider.prototype.classNameTag = "dynamic-slider-control",

Slider.prototype.setValue = function (v) {
	this._range.setValue(v);
	this.input.value = this.getValue();
};

Slider.prototype.getValue = function () {
	return this._range.getValue();
};

Slider.prototype.setMinimum = function (v) {
	this._range.setMinimum(v);
	this.input.value = this.getValue();
};

Slider.prototype.getMinimum = function () {
	return this._range.getMinimum();
};

Slider.prototype.setMaximum = function (v) {
	this._range.setMaximum(v);
	this.input.value = this.getValue();
};

Slider.prototype.getMaximum = function () {
	return this._range.getMaximum();
};

Slider.prototype.setUnitIncrement = function (v) {
	this._unitIncrement = v;
};

Slider.prototype.getUnitIncrement = function () {
	return this._unitIncrement;
};

Slider.prototype.setBlockIncrement = function (v) {
	this._blockIncrement = v;
};

Slider.prototype.getBlockIncrement = function () {
	return this._blockIncrement;
};

Slider.prototype.getOrientation = function () {
	return this._orientation;
};

Slider.prototype.setOrientation = function (sOrientation) {
	if (sOrientation != this._orientation) {
		if (Slider.isSupported && this.element) {
			// add class name tag to class name
			this.element.className = this.element.className.replace(this._orientation,
									sOrientation);
		}
		this._orientation = sOrientation;
		this.recalculate();

	}
};

Slider.prototype.recalculate = function() {
	if (!Slider.isSupported || !this.element) return;

	var w = this.element.offsetWidth;
	var h = this.element.offsetHeight;
	var hw = this.handle.offsetWidth;
	var hh = this.handle.offsetHeight;
	var lw = this.line.offsetWidth;
	var lh = this.line.offsetHeight;

	// this assumes a border-box layout

	if (this._orientation == "horizontal") {
		this.handle.style.left = (w - hw) * (this.getValue() - this.getMinimum()) /
			(this.getMaximum() - this.getMinimum()) + "px";
		this.handle.style.top = (h - hh) / 2 + "px";

		this.line.style.top = (h - lh) / 2 + "px";
		this.line.style.left = hw / 2 + "px";
		//this.line.style.right = hw / 2 + "px";
		this.line.style.width = Math.max(0, w - hw - 2)+ "px";
		this.line.firstChild.style.width = Math.max(0, w - hw - 4)+ "px";
	}
	else {
		this.handle.style.left = (w - hw) / 2 + "px";
		this.handle.style.top = h - hh - (h - hh) * (this.getValue() - this.getMinimum()) /
			(this.getMaximum() - this.getMinimum()) + "px";

		this.line.style.left = (w - lw) / 2 + "px";
		this.line.style.top = hh / 2 + "px";
		this.line.style.height = Math.max(0, h - hh - 2) + "px";	//hard coded border width
		//this.line.style.bottom = hh / 2 + "px";
		this.line.firstChild.style.height = Math.max(0, h - hh - 4) + "px";	//hard coded border width
	}
};
Slider.prototype.ontimer = function () {
	var hw = this.handle.offsetWidth;
	var hh = this.handle.offsetHeight;
	var hl = this.handle.offsetLeft;
	var ht = this.handle.offsetTop;

	if (this._orientation == "horizontal") {
		if (this._mouseX > hl + hw &&
			(this._increasing == null || this._increasing)) {
			this.setValue(this.getValue() + this.getBlockIncrement());
			this._increasing = true;
		}
		else if (this._mouseX < hl &&
			(this._increasing == null || !this._increasing)) {
			this.setValue(this.getValue() - this.getBlockIncrement());
			this._increasing = false;
		}
	}
	else {
		if (this._mouseY > ht + hh &&
			(this._increasing == null || !this._increasing)) {
			this.setValue(this.getValue() - this.getBlockIncrement());
			this._increasing = false;
		}
		else if (this._mouseY < ht &&
			(this._increasing == null || this._increasing)) {
			this.setValue(this.getValue() + this.getBlockIncrement());
			this._increasing = true;
		}
	}

	this._timer.start();
};
/************************************************************************/
//Javascript Code for sliders timer.js
/************************************************************************/
function Timer(nPauseTime) {
	this._pauseTime = typeof nPauseTime == "undefined" ? 1000 : nPauseTime;
	this._timer = null;
	this._isStarted = false;
}

Timer.prototype.start = function () {
	if (this.isStarted())
		this.stop();
	var oThis = this;
	this._timer = window.setTimeout(function () {
		if (typeof oThis.ontimer == "function")
			oThis.ontimer();
	}, this._pauseTime);
	this._isStarted = false;
};

Timer.prototype.stop = function () {
	if (this._timer != null)
		window.clearTimeout(this._timer);
	this._isStarted = false;
};

Timer.prototype.isStarted = function () {
	return this._isStarted;
};

Timer.prototype.getPauseTime = function () {
	return this._pauseTime;
};

Timer.prototype.setPauseTime = function (nPauseTime) {
	this._pauseTime = nPauseTime;
};


//----------------------------
 //load a control into the iframe
function loadCtl(sender, URL, level)
{
    //clear menus
   // ClearAllLevel2Menus();
 //   ClearAllSubMenus();
    
    //select appropriate menu based on what this time is
    
    //text decorate this item
    //sender.style.visibility = "visible";
    //sender.style.display = "block";  
    
    //load correct user control
   /* var sURL= escape(URL);
    sURL = sURL.substr(4,sURL.length);
    sURL = jReplace(sURL,'.ascx','.aspx');         
    document.getElementById("iframeContent").src=sURL;*/
    
    var sURL = escape(URL);
    //sURL = sURL.substr(4, sURL.length);
    var exten = sURL.substr(sURL.length - 5, 5);
    if ( exten == '.aspx' )
        document.getElementById("iframeContent").src = sURL;
    else
        document.getElementById("iframeContent").src= 'ControlLoader.aspx?URL=' + sURL;
    
/*        var ajaxPanel = document.getElementById('rajMain');
    alert("ajax panel = " + ajaxPanel);
    ajaxPanel.AjaxRequest(URL);*/
}

 //load a control into the iframe
function loadControl(sender, URL, level)
{
    //clear menus
   // ClearAllLevel2Menus();
 //   ClearAllSubMenus();
    
    //select appropriate menu based on what this time is
    
    //text decorate this item
    //sender.style.visibility = "visible";
    //sender.style.display = "block";  
    
    //load correct user control
   /* var sURL= escape(URL);
    sURL = sURL.substr(4,sURL.length);
    sURL = jReplace(sURL,'.ascx','.aspx');         
    document.getElementById("iframeContent").src=sURL;*/
    
    var sURL = escape(URL);
    //sURL = sURL.substr(4, sURL.length);
    //alert(sURL);
    var exten = sURL.substr(sURL.length - 5, 5);
    if ( exten == '.aspx' )
        parent.document.getElementById("iframeContent").src = sURL;
    else
        parent.document.getElementById("iframeContent").src= 'ControlLoader.aspx?URL=' + sURL + '&Frm=Setup';
    return false;
/*        var ajaxPanel = document.getElementById('rajMain');
    alert("ajax panel = " + ajaxPanel);
    ajaxPanel.AjaxRequest(URL);*/
}


/* Functions to load and highlight menu from control loader class*/

// Function to highlight tab menu and load submenus
function HighlightSelectedMenuForSetup(objId, menuId, menuAutoId)
{
    // Searching for any earlier selected Image        
    for(var i = 1;i<=7;i++)
    {
        var imgTab = parent.document.getElementById(i);
        if ( imgTab != null)
        {
            var ArrImgName = imgTab.src.split("/");
            
            if(ArrImgName[ArrImgName.length-1].indexOf('-on.jpg') > -1 )
            {
                imgTab.src = jReplace(imgTab.src,'-on.jpg','.jpg');                
            }
        }
    }
    //Changing the current image to its selected image.
    var img = parent.document.getElementById(objId);
    //selectedImage = selectedImage.substring(2,selectedImage.length);
    img.src = img.src.replace('.jpg', '-on.jpg');          

    if ( menuId != '' )
    {
        // Clearing level menu
        ClearLevel2Menu();
        ClearLevel3Menu();
        
        // Loading Menus
        ShowLevel2Menu(objId);
        ShowLevel3Menu(menuId);

        // Highlighting menu
        ClearLevelClassesForSetup(menuAutoId);
    }
}

// Function to clear all level 2 menus
function ClearLevel2Menu()
{
    var arr = parent.document.body.getElementsByTagName('DIV');
    for(var i=0;i < arr.length;i++)
    {
        if(arr[i].id.indexOf('dvMenu') > -1 && arr[i].style.visibility == 'visible')
        {
            arr[i].style.visibility = "hidden";
            arr[i].style.display = "none";
        }
    }   
}         

//Function to clear all submenus
function ClearLevel3Menu()
{
    var arr = parent.document.body.getElementsByTagName('DIV');
    for(var i=0;i < arr.length;i++)
    {
        if(arr[i].id.indexOf('dvSubMenu') > -1 && arr[i].style.visibility == 'visible')
        {
            arr[i].style.visibility = "hidden";
            arr[i].style.display = "none";
        }
    }
}
// Function to show level 2 menus
function ShowLevel2Menu(objId)
{
    var obj = parent.document.getElementById("dvMenu"+objId);
    //Setting Level 2 Menu id in the hidden field so that it could be made visible at postback.        
    parent.document.getElementById('hidMenuTrack').value = parent.document.getElementById('hidMenuTrack').value + ',' + objId;
    //var obj = parent.document.getElementById(obj.Id);
    if ( obj != null )
    {
        obj.style.visibility = "visible";
        obj.style.display = "block";   
    }
    return false;
}

//Shows 3rd Level Menu.
function ShowLevel3Menu(objId)
{
    var obj = parent.document.getElementById("dvSubMenu"+objId);      
    if ( obj != null)
    {  
        obj.style.visibility = "visible";
        obj.style.display = "block";
        //lastMenu = obj; 
    }
    return false;
}

function ClearLevelClassesForSetup(id)
{
    var arr = parent.window.document.body.getElementsByTagName('DIV');
    
    for(var i=0;i < arr.length;i++)
    {
        if((arr[i].id.indexOf('dvMenu') > -1 || arr[i].id.indexOf('dvSubMenu') > -1) && arr[i].style.visibility == 'visible')
        {
            var anchors = parent.window.document.body.getElementsByTagName('A');
            for(var j=0;j<anchors.length;j++)
            {
                if(anchors[j].className != 'selected' && anchors[j].id == id )
                {
                    anchors[j].className = 'selected';
                    break;
                }
                else if ( anchors[j].id != id )
                {
                    anchors[j].className ='';
                    parent.window.document.getElementById(parent.window.document.getElementById(id).attributes["loadingmenuid"].value).className='selected';
                }
            }
        }
    } 
} 
    
function check(e,objName)
{ 
    var obj = window.document.getElementById(objName);
    var k;
    var bln =false;
    
    if (window.event)     
    {
        k = event.keyCode ;  
    }
    else     
    {
        k = e.which;
    } 
     
    if(k==8 || k==9 || k==13 || k==46 || (k>=35 && k<=40) || k==110 ||k==190)
          bln=true;
    else if((k>=48 && k<=57) || k==110)
          bln=true;
    else
        bln= false; 
     
    if (bln==true)
    {    
      if(obj.value.length >=10)
      {
         if (k==8 || k==9 || k==13)
                {
                return true;
                }
                else
                {
                   return false;
                }
      }
      if(k==46)
      {
         var ind=obj.value.indexOf(".");
         if(ind>=0)
         {
             return false;                         
         }
       }
       var ind=obj.value.indexOf(".");
       if(ind>0)
       {
            var sstr=obj.value.substring(ind);
            if (sstr.length > 2 )
            {
                if (k==8 || k==9 || k==13)
                {
                return true;
                }
                else
                {
                   return false;
                }
            }
       }
     }
     else
     {
         return false;
     }             
}

function SelectAllCheckboxes(spanChk)
{  
   
   var theBox= (spanChk.type=="checkbox") ? spanChk : spanChk.children.item[0];
   xState=theBox.checked;
   elm=theBox.form.elements;

   for(i=0;i<elm.length;i++)
   {
     if(elm[i].type=="checkbox" && elm[i].id!=theBox.id)
     {
       if(elm[i].checked!=xState)
         elm[i].click();
     }
   }
 }

 function currencyFormat(fld, milSep, decSep, e) {
 
var sep = 0;
var key = '';
var i = j = 0;
var len = len2 = 0;
var strCheck = '0123456789';
var aux = aux2 = '';
var whichCode = (window.Event) ? e.which : e.keyCode;
if (whichCode == 13) return true;  // Enter
if (whichCode == 8) return true;  // Delete (Bug fixed)
if (whichCode == 0) return true;  
if (fld.value.length > 12) return false;
key = String.fromCharCode(whichCode);  // Get key value from key code
if (strCheck.indexOf(key) == -1) return false;  // Not a valid key
len = fld.value.length;
for(i = 0; i < len; i++)
if ((fld.value.charAt(i) != '0') && (fld.value.charAt(i) != decSep)) break;
aux = '';
for(; i < len; i++)
if (strCheck.indexOf(fld.value.charAt(i))!=-1) aux += fld.value.charAt(i);
aux += key;
len = aux.length;
if (len == 0) fld.value = '';
if (len == 1) fld.value = '0'+ decSep + '0' + aux;
if (len == 2) fld.value = '0'+ decSep + aux;
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

function disableDeleteBackSpace() {
   
    var keyCode = (event.which) ? event.which : event.keyCode;

    if ((keyCode == 8) || (keyCode == 46))
        event.returnValue = false;
    else if (keyCode == 9)
        event.returnValue = true;
    else
        event.returnValue = false;
}

//Call this function as - TocheckUncheck("GridViewID.ClientID", "HeaderCheckBoxId", "ItemCheckBoxId", "HiddenFieldID.ClientID");
function TocheckUncheck(gridId, chkHeaderId, chkItemId, hiddenId) {
    var chkHeader = true;
    //Remember selection while paging(post back)
    $('#' + gridId + ' tr').find('input[type="checkbox"]').each(function () {
        if ($(this).attr('id') != $('#' + gridId + ' tr').find('input[id*="' + chkHeaderId + '"]').attr('id')) {
            if ($('#' + hiddenId).val().indexOf('-' + $(this).val() + '-') >= 0) {
                $(this).prop('checked', true);
            }
            else {
                $(this).prop('checked', false);
                chkHeader = false;
            }
        }
    });

    //Remember header selection while paging(post back)
    $('#' + gridId + ' tr').find('input[id*="' + chkHeaderId + '"]').prop('checked', chkHeader);

    //check un_check all check-boxes based on there change event
    $('#' + gridId + ' tr').find('input[type="checkbox"]').change(function () {
        if ($(this).attr('id').indexOf(chkHeaderId) >= 0) {
            if ($(this).is(":checked")) {
                CheckUncheckAllCheckBoxes(gridId, chkHeaderId, chkItemId, true, true, hiddenId);
            }
            else {
                CheckUncheckAllCheckBoxes(gridId, chkHeaderId, chkItemId, false, true, hiddenId);
            }
        }
        else if ($(this).attr('id').indexOf(chkItemId) >= 0) {
            if ($(this).is(":checked")) {
                CheckUncheckAllCheckBoxes(gridId, chkHeaderId, chkItemId, true, false, hiddenId);
            }
            else {
                if ($('#' + hiddenId).val().indexOf('-' + $(this).val() + '-') >= 0) {
                    $('#' + hiddenId).val($('#' + hiddenId).val().replace('-' + $(this).val() + '-', ''));
                }
                $('#' + gridId + ' tr').find('input[id*="' + chkHeaderId + '"]').prop("checked", false);
            }
        }
    });
}

function CheckUncheckAllCheckBoxes(gridId, chkHeaderId, chkItemId, boolValue, isHeader, hiddenId) {
    var headerCheckUncheck = true;
    $('#' + gridId + ' tr').find('input[id*="' + chkItemId + '"]').each(function () {
        if (isHeader) {
            $(this).prop('checked', boolValue);
            if (boolValue) {
                if ($('#' + hiddenId).val().indexOf('-' + $(this).val() + '-') < 0) {
                    $('#' + hiddenId).val($('#' + hiddenId).val() + '-' + $(this).val() + '-')
                }
            }
            else {
                if ($('#' + hiddenId).val().indexOf('-' + $(this).val() + '-') >= 0) {
                    $('#' + hiddenId).val($('#' + hiddenId).val().replace('-' + $(this).val() + '-', ''));
                }
            }
        }
        else {
            if ($(this).is(":checked")) {
                if ($('#' + hiddenId).val().indexOf('-' + $(this).val() + '-') < 0) {
                    $('#' + hiddenId).val($('#' + hiddenId).val() + '-' + $(this).val() + '-')
                }
            }
            else {
                if ($('#' + hiddenId).val().indexOf('-' + $(this).val() + '-') >= 0) {
                    $('#' + hiddenId).val($('#' + hiddenId).val().replace('-' + $(this).val() + '-', ''));
                }
                headerCheckUncheck = false;
            }
        }
    });

    if (!isHeader) {
        $('#' + gridId + ' tr').find('input[id*="' + chkHeaderId + '"]').prop("checked", headerCheckUncheck);
    }
}