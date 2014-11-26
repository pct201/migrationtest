--select 'case "' + Field_Name + '":' +  
--char(13) + char(9) + 'strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txt")).ClientID + ",";' + 
--char(13) + char(9) + 'strMessages += "Please enter ' + Field_Name + '" + ",";'+
--char(13) + char(9) + '((HtmlControl)fvPolicyDetails.FindControl("Span1")).Style["display"] = "inline-block";' + 
--char(13) + char(9) + 'break;'
--from Screen_Validators where ScreenId = 95


--select 'case "' + Field_Name + '":' +  
--char(13) + char(9) + 'strCtrlsIDs += txt.ClientID + ",";' + 
--char(13) + char(9) + 'strMessages += "Please enter ' + Field_Name + '" + ",";'+
--char(13) + char(9) + 'Span1.Style["display"] = "inline-block";' + 
--char(13) + char(9) + 'break;'
--from Screen_Validators  where ScreenId = 112

--select 'case "' + Field_Name + '":' +  
--char(13) + char(9) + 'strCtrlsIDs += txt.ClientID + ",";' + 
--char(13) + char(9) + 'strMessages += "Please enter ' + Field_Name + '" + ",";'+
--char(13) + char(9) + 'Span1.Style["display"] = "inline-block";' + 
--char(13) + char(9) + 'break;'
--from Screen_Validators  where ScreenId = 129 

select 'case "' + Field_Name + '":' +  
char(13) + char(9) + 'strCtrlsIDs += txt.ClientID + ",";' + 
char(13) + char(9) + 'strMessages += "Please enter [' + ScreenName + ']/' + Field_Name + '" + ",";'+
char(13) + char(9) + 'Span1.Style["display"] = "inline-block";' + 
char(13) + char(9) + 'break;'
from Screen_Validators inner join screen on Screen_Validators.ScreenId = screen.ScreenId
where Screen_Validators.ScreenId in (112,113)


--select screen.screenid, '------------' + screenname + '------------' 
--from Screen_Validators inner join screen on Screen_Validators.ScreenId = screen.ScreenId
--where screen.submoduleid = 32
--union
--select screen.screenid, 'case "' + Field_Name + '":' +  
--char(13) + char(9) + 'strCtrlsIDs += txt.ClientID + ",";' + 
--char(13) + char(9) + 'strMessages += "Please enter [' + ScreenName + ']/' + Field_Name + '" + ",";'+
--char(13) + char(9) + 'Span1.Style["display"] = "inline-block";' + 
--char(13) + char(9) + 'break;'
--from Screen_Validators inner join screen on Screen_Validators.ScreenId = screen.ScreenId
--where screen.submoduleid = 32