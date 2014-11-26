// JScript File

	function nextYear(forward,txtObj) {
		var yearField = document.getElementById(txtObj);
		var testEr = new RegExp('\\d{4}', 'g');
		if(testEr.test(yearField.value)) {
			var yearValue = parseInt(yearField.value);
			if(forward)
				yearValue = yearValue+1;
			else
				yearValue = yearValue-1;
			yearField.value = yearValue;
		} else {
		var newDate = new Date();
		yearField.value = newDate.getFullYear();
		}
		flgDisplay = true;
	}
	
	function lnkMonthClick(month,txtMonthYearObj,txtYearObj,objDiv)
	{
	    document.getElementById(txtMonthYearObj).value = month + '/' + document.getElementById(txtYearObj).value;
	    HideDiv(objDiv);
	}

	
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



    function HideDiv(objDiv)
    {       
        document.getElementById(objDiv).style.display = "none";
    }
    
    function ShowDiv(objDiv)
    {   
        if(document.getElementById(objDiv).style.display == 'block' || document.getElementById(objDiv).style.display == "inline")
            document.getElementById(objDiv).style.display = "none";
        else
            document.getElementById(objDiv).style.display = "inline";
//        objDivInfoBox.style.left = mouseX(window.event);
//        objDivInfoBox.style.top = mouseY(window.event);
    } 

    function ValidateDate(sender) { 
            var monthYear = sender.value;
            var splitchar = '/';
            
            if(sender.value == '')
                return false;
                        
            var arr = monthYear.split(splitchar);
            var month = parseFloat(arr[0]);
            var year = parseFloat(arr[1]);
            
            if(isNaN(month) || isNaN(year))
            {
                alert("Invalid Date");
                sender.value = '';
                return false;
            }
            if(month > 12 || month < 1 )
            {
                alert("Invalid Month Specified");
                sender.value = '';
                return false;
            }
            if(year > 9999 || year < 1753 )
            {
                alert("Year should be in the range of 1753 - 9999");
                sender.value = '';
                return false;
            }
            return true;
        }
        
        function OnKeyPress(e,sender)
        {
            if(e.keyCode == 47 || e.which == 47)
            {
                // don't allow split character.
                return false;
            }
            var ctrlValue = sender.value;            
            if(ctrlValue.length == 2) 
            {
                if(e.which)
                {
                    if(e.which == 8)
                    {
                        return true;
                    }
                }
                ctrlValue = ctrlValue + '/';        
                sender.value = ctrlValue;
                return true;
            }    
        }
        
        function ValidateYear(sender)
        {
            var today = new Date() 
            var toDayyear = today.getYear();
            if(toDayyear<1000) 
                toDayyear+=1900;
                
            if(sender.value.lenght < 4)
            {
                alert("Invalid Year Specified");
                sender.value = toDayyear;
                sender.select();
                return false;
            }
            var year = parseFloat(sender.value);
            if(isNaN(year))
            {
                alert("Invalid Year Specified");
                sender.value = toDayyear;
                sender.select();
                return false;
            }
            if(year > 9999 || year < 1753 )
            {
                alert("Year should be in the range of 1753 - 9999");
                sender.value = toDayyear;
                sender.select();
                return false;
            }
        }