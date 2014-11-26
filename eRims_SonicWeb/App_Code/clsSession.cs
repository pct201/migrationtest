using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
/// <summary>
/// Summary description for clsSession
/// </summary>
public class clsSession
{

    /// <summary>
    /// Currently Loge in in User's ID
    /// </summary>
    public static int DropDownBindOrder
    {
        get
        {
            return HttpContext.Current.Session["DropDownBindOrder"] == null ? 0 : Convert.ToInt32(HttpContext.Current.Session["DropDownBindOrder"]);
        }
        set
        {
            HttpContext.Current.Session["DropDownBindOrder"] = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static int NumberOfSearchRows
    {
        get { return clsGeneral.IsNull(HttpContext.Current.Session["NumberOfSearchRows"]) ? 25 : Convert.ToInt32(HttpContext.Current.Session["NumberOfSearchRows"]); }
        set { HttpContext.Current.Session["NumberOfSearchRows"] = value; }
    }

    /// <summary>
    /// Loged in User's Email ID
    /// </summary>
    public static string Email
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["Email"]);
        }
        set
        {
            HttpContext.Current.Session["Email"] = value;
        }
    }

    public static string OutlookMailAttachmentNames
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["OutlookMailAttachmentNames"]);
        }
        set
        {
            HttpContext.Current.Session["OutlookMailAttachmentNames"] = value;
        }
    }

    /// <summary>
    /// Currently Attachment File Path
    /// </summary>
    public static string AttachFilePath
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["AttachFilePath"]);
        }
        set
        {
            HttpContext.Current.Session["AttachFilePath"] = value;
        }
    }

    public static string OutlookMailSubjects
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["OutlookMailSubjects"]);
        }
        set
        {
            HttpContext.Current.Session["OutlookMailSubjects"] = value;
        }
    }

    /// <summary>
    /// Currently logged in user's primary key 
    /// </summary>
    public static string UserRoleId
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["UserRoleId"]);
        }
        set
        {
            HttpContext.Current.Session["UserRoleId"] = value;
        }
    }

    /// <summary>
    /// Name of the user
    /// </summary>
    public static string UserName
    {
        get
        {
            string strUserName = Convert.ToString((HttpContext.Current.Session["UserName"]));
            if (strUserName.Length == 0)
            {
                return string.Empty;
            }
            else
            {
                return strUserName;
            }
        }
        set
        {
            HttpContext.Current.Session["UserName"] = value;
        }
    }
    /// <summary>
    /// Currentl Loged in User's ID
    /// </summary>
    public static string UserID
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["UserID"]);
        }
        set
        {
            HttpContext.Current.Session["UserID"] = value;
        }
    }
    /// <summary>
    /// Loged in User's Last Name
    /// </summary>
    public static string LastName
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["LastName"]);
        }
        set
        {
            HttpContext.Current.Session["LastName"] = value;
        }
    }
    /// <summary>
    /// Loged in User's First Name
    /// </summary>
    public static string FirstName
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["FirstName"]);
        }
        set
        {
            HttpContext.Current.Session["FirstName"] = value;
        }
    }
    /// <summary>
    /// CC Email ID
    /// </summary>
    public static string CC
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["CC"]);
        }
        set
        {
            HttpContext.Current.Session["CC"] = value;
        }
    }

    public static string UserRole
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["UserRole"]);
        }
        set
        {
            HttpContext.Current.Session["UserRole"] = value;
        }
    }
    /// <summary>
    /// Loged in User's Access Type
    /// </summary>
    public static string UserAccess
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["UserAccess"]);
        }
        set
        {
            HttpContext.Current.Session["UserAccess"] = value;
        }
    }

    public static decimal LocationID
    {
        get { return (Convert.ToDecimal(!clsGeneral.IsNull(HttpContext.Current.Session["EditLocationID"]) ? HttpContext.Current.Session["EditLocationID"] : 0)); }
        set { HttpContext.Current.Session["EditLocationID"] = value; }
    }

    public static decimal LocationCode
    {
        get { return (Convert.ToDecimal(!clsGeneral.IsNull(HttpContext.Current.Session["LocationCode"]) ? HttpContext.Current.Session["LocationCode"] : 0)); }
        set { HttpContext.Current.Session["LocationCode"] = value; }
    }

    public static Boolean UserAllowToViewClaimInformation
    {
        get
        {
            return Convert.ToBoolean(HttpContext.Current.Session["UserAllowToViewClaimInformation"]);
        }
        set
        {
            HttpContext.Current.Session["UserAllowToViewClaimInformation"] = value;
        }
    }

    /// <summary>
    /// Current First Report WIzard ID.
    /// </summary>
    public static int First_Report_Wizard_ID
    {
        get
        {
            return Convert.ToInt32(HttpContext.Current.Session["First_Report_Wizard_ID"]);
        }
        set
        {
            HttpContext.Current.Session["First_Report_Wizard_ID"] = value;
        }
    }
    /// <summary>
    /// No of Tabs that are allowed for Current Wizard ID
    /// </summary>
    public static string AllowedTab
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["AllowedTab"]);
        }
        set
        {
            HttpContext.Current.Session["AllowedTab"] = value;
        }
    }
    /// <summary>
    /// No of Tabs that are allowed for Current Employee ID
    /// </summary>
    public static decimal CurrentLoginEmployeeId
    {
        get
        {
            return Convert.ToDecimal(HttpContext.Current.Session["CurrentLoginEmployeeId"]);
        }
        set
        {
            HttpContext.Current.Session["CurrentLoginEmployeeId"] = value;
        }
    }
    /// <summary>
    /// Loged in Use is SONIC Employee?
    /// </summary>
    public static Boolean IsSONICEmployee
    {
        get
        {
            return Convert.ToBoolean(HttpContext.Current.Session["IsSONICEmployee"]);
        }
        set
        {
            HttpContext.Current.Session["IsSONICEmployee"] = value;
        }
    }

    /// <summary>
    /// Region of Current User
    /// </summary>
    public static string CurRegion
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["CurRegion"]);
        }
        set
        {
            HttpContext.Current.Session["CurRegion"] = value;
        }
    }

    /// <summary>
    /// Region of ClaimID_Diary
    /// </summary>
    public static string ClaimID_Diary
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["ClaimID_Diary"]);
        }
        set
        {
            HttpContext.Current.Session["ClaimID_Diary"] = value;
        }
    }

    /// <summary>
    /// Gets or sets the ExpireDate value.
    /// </summary>
    public static string ExpireDatelabel
    {
        get 
        {
            return Convert.ToString(HttpContext.Current.Session["ExpireDateLabel"]); 
        }
        set
        {
            HttpContext.Current.Session["ExpireDateLabel"] = value;
        }
    }

    /// <summary>
    /// used to clear Session values
    /// </summary>
    public static void ClearSession()
    {
        HttpContext.Current.Session.Clear(); // make all variables NULL,session id not changed
        HttpContext.Current.Session.Abandon(); // session is destroyed,so on next request new session created
        //HttpContext.Current.Session.RemoveAll();
    }

    public static decimal FK_WC_FR_ID
    {
        get { return (Convert.ToDecimal(!clsGeneral.IsNull(HttpContext.Current.Session["FK_WC_FR_ID"]) ? HttpContext.Current.Session["FK_WC_FR_ID"] : -1)); }
        set { HttpContext.Current.Session["FK_WC_FR_ID"] = value; }
    }

    public static string Str_Employee_Operation
    {
        get
        {
            if (clsGeneral.IsNull(HttpContext.Current.Session["Str_Employee_Operation"]))
            {
                HttpContext.Current.Session["Str_Employee_Operation"] = string.Empty;
            }
            return Convert.ToString(HttpContext.Current.Session["Str_Employee_Operation"]);

        }
        set
        {
            HttpContext.Current.Session["Str_Employee_Operation"] = value;
        }
    }

    public static DataTable Tbl_SabaTraining_Not_Imported
    {
        get
        {
            if (clsGeneral.IsNull(HttpContext.Current.Session["SabaTraining_Not_Imported"]))
                return null;
            else
                return (DataTable)HttpContext.Current.Session["SabaTraining_Not_Imported"];
        }
        set
        {
            HttpContext.Current.Session["SabaTraining_Not_Imported"] = value;
        }
    }

    public static bool IsUserRegionalOfficer
    {
        get { return Convert.ToBoolean(HttpContext.Current.Session["IsUserRegionalOfficer"]); }
        set { HttpContext.Current.Session["IsUserRegionalOfficer"] = value; }
    }

    public static bool IsUserPurchsingAdmin
    {
        get { return Convert.ToBoolean(HttpContext.Current.Session["IsUserPurchsingAdmin"]); }
        set { HttpContext.Current.Session["IsUserPurchsingAdmin"] = value; }
    }

    # region " APPCONFIG Properties "
    /// <summary>
    /// get and set Site URL 
    /// </summary>
    public static string SiteURL
    {
        get
        {
            return Convert.ToString((HttpContext.Current.Session["SiteURL"]));
        }
        set
        {
            if (value.Length > 0)
                HttpContext.Current.Session["SiteURL"] = value;
            else
                HttpContext.Current.Session.Remove("SiteURL");
        }
    }
    /// <summary>
    /// get and set Site Path
    /// </summary>
    public static string SitePath
    {
        get
        {
            return Convert.ToString((HttpContext.Current.Session["SitePath"]));
        }
        set
        {
            if (value.Length > 0)
                HttpContext.Current.Session["SitePath"] = value;
            else
                HttpContext.Current.Session.Remove("SitePath");
        }
    }

    /// <summary>
    /// get and set Image URL
    /// </summary>
    public static string ImageURL
    {
        get
        {
            return Convert.ToString((HttpContext.Current.Session["ImageURL"]));
        }
        set
        {
            if (value.Length > 0)
                HttpContext.Current.Session["ImageURL"] = value;
            else
                HttpContext.Current.Session.Remove("ImageURL");
        }
    }
    /// <summary>
    /// get and set Thumbnil Image URL
    /// </summary>
    public static string ThemeImageURL
    {
        get
        {
            return Convert.ToString((HttpContext.Current.Session["ThemeImageURL"]));
        }
        set
        {
            if (value.Length > 0)
                HttpContext.Current.Session["ThemeImageURL"] = value;
            else
                HttpContext.Current.Session.Remove("ThemeImageURL");
        }
    }
    #endregion

    #region "Executive Risk Properties"

    public static int Current_Executive_Risk_ID
    {
        get
        {
            if (clsGeneral.IsNull(HttpContext.Current.Session["Current_Executive_Risk_ID"]))
            {
                HttpContext.Current.Session["Current_Executive_Risk_ID"] = 0;
            }
            return Convert.ToInt32(HttpContext.Current.Session["Current_Executive_Risk_ID"]);

        }
        set
        {
            HttpContext.Current.Session["Current_Executive_Risk_ID"] = value;
        }
    }

    public static string Str_Executive_Operation
    {
        get
        {
            if (clsGeneral.IsNull(HttpContext.Current.Session["Str_Executive_Operation"]))
            {
                HttpContext.Current.Session["Str_Executive_Operation"] = string.Empty;
            }
            return Convert.ToString(HttpContext.Current.Session["Str_Executive_Operation"]);

        }
        set
        {
            HttpContext.Current.Session["Str_Executive_Operation"] = value;
        }
    }

    #endregion

    #region "Purchasing Service Contract"

    public static string Str_ServiceContract_Operation
    {
        get
        {
            if (clsGeneral.IsNull(HttpContext.Current.Session["Str_ServiceContract_Operation"]))
            {
                HttpContext.Current.Session["Str_ServiceContract_Operation"] = string.Empty;
            }
            return Convert.ToString(HttpContext.Current.Session["Str_ServiceContract_Operation"]);

        }
        set
        {
            HttpContext.Current.Session["Str_ServiceContract_Operation"] = value;
        }
    }

    public static string Str_LR_Agreement_Operation
    {
        get
        {
            if (clsGeneral.IsNull(HttpContext.Current.Session["Str_LR_Agreement_Operation"]))
            {
                HttpContext.Current.Session["Str_LR_Agreement_Operation"] = string.Empty;
            }
            return Convert.ToString(HttpContext.Current.Session["Str_LR_Agreement_Operation"]);

        }
        set
        {
            HttpContext.Current.Session["Str_LR_Agreement_Operation"] = value;
        }
    }

    public static int Current_Purchasing_Service_Contract_ID
    {
        get
        {
            if (clsGeneral.IsNull(HttpContext.Current.Session["Current_Purchasing_Service_Contract_ID"]))
            {
                HttpContext.Current.Session["Current_Purchasing_Service_Contract_ID"] = 0;
            }
            return Convert.ToInt32(HttpContext.Current.Session["Current_Purchasing_Service_Contract_ID"]);

        }
        set
        {
            HttpContext.Current.Session["Current_Purchasing_Service_Contract_ID"] = value;
        }
    }

    public static int Current_LR_Agreement_ID
    {
        get
        {
            if (clsGeneral.IsNull(HttpContext.Current.Session["Current_LR_Agreement_ID"]))
            {
                HttpContext.Current.Session["Current_LR_Agreement_ID"] = 0;
            }
            return Convert.ToInt32(HttpContext.Current.Session["Current_LR_Agreement_ID"]);

        }
        set
        {
            HttpContext.Current.Session["Current_LR_Agreement_ID"] = value;
        }
    }

    public static int Current_Purchasing_Asset_ID
    {
        get
        {
            if (clsGeneral.IsNull(HttpContext.Current.Session["Current_Purchasing_Asset_ID"]))
            {
                HttpContext.Current.Session["Current_Purchasing_Asset_ID"] = 0;
            }
            return Convert.ToInt32(HttpContext.Current.Session["Current_Purchasing_Asset_ID"]);

        }
        set
        {
            HttpContext.Current.Session["Current_Purchasing_Asset_ID"] = value;
        }
    }

    public static string Str_Asset_Operation
    {
        get
        {
            if (clsGeneral.IsNull(HttpContext.Current.Session["Str_Asset_Operation"]))
            {
                HttpContext.Current.Session["Str_Asset_Operation"] = string.Empty;
            }
            return Convert.ToString(HttpContext.Current.Session["Str_Asset_Operation"]);

        }
        set
        {
            HttpContext.Current.Session["Str_Asset_Operation"] = value;
        }
    }
    #endregion"

    #region " Real Estate "
    public static string Str_RE_Operation
    {
        get
        {
            if (clsGeneral.IsNull(HttpContext.Current.Session["Str_RE_Operation"]))
            {
                HttpContext.Current.Session["Str_RE_Operation"] = string.Empty;
            }
            return Convert.ToString(HttpContext.Current.Session["Str_RE_Operation"]);

        }
        set
        {
            HttpContext.Current.Session["Str_RE_Operation"] = value;
        }
    }

    public static decimal Current_RE_Information_ID
    {
        get
        {
            if (clsGeneral.IsNull(HttpContext.Current.Session["Current_RE_Information_ID"]))
            {
                HttpContext.Current.Session["Current_RE_Information_ID"] = 0;
            }
            return Convert.ToDecimal(HttpContext.Current.Session["Current_RE_Information_ID"]);

        }
        set
        {
            HttpContext.Current.Session["Current_RE_Information_ID"] = value;
        }
    }
    #endregion

    public static DataTable dt_COI_Building 
    {
        get
        {
            if (clsGeneral.IsNull(HttpContext.Current.Session["dt_Building"]))
                return null;
            else
                return (DataTable)HttpContext.Current.Session["dt_Building"];
        }
        set
        {
            HttpContext.Current.Session["dt_Building"] = value;
        }
    }
}
