using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Text.RegularExpressions;
using ERIMS.DAL;

/// <summary>
/// Summary description for clsBasePage
/// </summary>
public class clsBasePage : System.Web.UI.Page
{
    //Module Access Type variable
    public static bool IsUserSystemAdmin;
    public AccessType App_Access;
    public AccessType App_RealEstateAccess;
    public AccessType App_Assest_Protection;
    public AccessType App_Import;

    /// <summary>
    /// get Module Access
    /// </summary>
    public AccessType Module_Access_Mode
    {
        set { App_Access = value; }
        get { return App_Access; }
    }

    public clsBasePage()
    {
    }

    /// <summary>
    /// Used to Set Acces Type of user. 
    /// </summary>
    public enum AccessType
    {
        NotAssigned = 0,
        Administrative_Access = 1,
        View_Only = 2,
        Executive_Risk_View = 3,
        Executive_Risk_Full = 4,
        Purchasing_Edit = 5,
        Purchasing_Legal = 6,
        RealEstate_Edit = 7,
        Franchise_AddEdit = 8,
        Franchise_View = 9,
        CRM_Edit = 10,
        CRM_Add = 11,
        Ohio_Claim_Access = 12,
        Delete = 13,
        Construction_AddEdit = 14,
        Construction_ViewOnly = 15,
        VOC_Import = 16
    }

    /// <summary>
    /// used to set module name for the current Application
    /// </summary>
    public enum ModuleName
    {
        FirstReport = 1,
        CliamInfo = 2,
        Exposures = 3,
        Purchasing = 5,
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        //base.OnPreInit(e);
        if (Request.ServerVariables["http_user_agent"].IndexOf("Safari", StringComparison.CurrentCultureIgnoreCase) != -1)
            Page.ClientTarget = "uplevel";
    }


    /// <summary>
    /// page having inherit this calss. on int method is call at the Initialization of page. here check is session for user is available or not.
    /// if not than redirect to Login Page
    /// </summary>
    /// <param name="e"></param>
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        //Check for user session
        if (clsSession.UserID == string.Empty)
        {
            //Redirect to login page 
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            Response.End();
        }
        else
        {
            string strModule = Request.Url.Segments[Request.Url.Segments.Length - 2].ToString();

            if (strModule == "SLTSafetyWalk/")
            {
                strModule = "SLT/";
            }

            if (strModule == "Management/")
                strModule = "ACI Management/";

            string strUrl = HttpContext.Current.Request.Url.ToString();
            //strUrl = strUrl.Replace("localhost","192.168.0.80");
            //get User Access
            DataSet dsRight = new DataSet();
            dsRight = Security.SelectRightsByUserID(Convert.ToDecimal(clsSession.UserID));
            bool boolAccessSet = false;
            bool boolSLT = false;
            //check dataset contain value or not
            if (strModule == "DashBoard/")
            {
                App_Access = AccessType.View_Only;
                boolAccessSet = true;
            }
            if (dsRight.Tables[0].Rows.Count > 0)
            {
                if (strModule == "Exposures/")
                {
                    DataRow[] drView_Assest = dsRight.Tables[0].Select("RightType_ID=2 and ModuleName='Asset Protection'");
                    if (drView_Assest != null && drView_Assest.Length > 0)
                    {
                        if (strModule == "Exposures/")
                            App_Assest_Protection = AccessType.View_Only;
                    }

                    #region
                    DataRow[] drView = dsRight.Tables[0].Select("RightType_ID=2 and ModuleName='RealEstate'");
                    if (drView != null && drView.Length > 0)
                    {
                        if (strModule == "Exposures/")
                            App_RealEstateAccess = AccessType.View_Only;
                    }

                    DataRow[] drEdit = dsRight.Tables[0].Select("RightType_ID=5 and ModuleName='RealEstate'");
                    if (drEdit != null && drEdit.Length > 0)
                    {
                        if (strModule == "Exposures/")
                            App_RealEstateAccess = AccessType.RealEstate_Edit;
                    }

                    DataRow[] drAdmin = dsRight.Tables[0].Select("RightType_ID=1 and ModuleName='RealEstate'");
                    if (drAdmin != null && drAdmin.Length > 0)
                    {
                        if (strModule == "Exposures/")
                            App_RealEstateAccess = AccessType.Administrative_Access;
                    }

                    #endregion
                }

                if (strModule == "Pollution/")
                {
                    DataRow[] drVOC_Import = dsRight.Tables[0].Select("RightType_ID=9 and ModuleName='VOC'");
                    if (drVOC_Import != null && drVOC_Import.Length > 0)
                    {
                        App_Import = AccessType.VOC_Import;
                    }
                }

                if (strModule == "CalAtlantic/")
                {
                    if (boolAccessSet == false)
                    {
                        boolAccessSet = true;
                    }
                    App_Access = AccessType.View_Only;
                }

                if (strModule == "COIReports/")
                    strModule = "COI/";
                if (strModule == "Pollution/")
                    strModule = "Exposures/";

                for (int iCount = 0; iCount < dsRight.Tables[0].Rows.Count; iCount++)
                {
                    //get the module name from url and complare with database value
                    if (strModule == (dsRight.Tables[0].Rows[iCount]["ModuleName"].ToString() + "/"))
                    {
                        #region
                        if (strModule == "Purchasing/")
                        {
                            if (boolAccessSet == false)
                            {
                                boolAccessSet = true;

                                DataRow[] drView = dsRight.Tables[0].Select("RightType_ID=2 and ModuleName='Purchasing'");
                                if (drView != null && drView.Length > 0)
                                    App_Access = AccessType.View_Only;

                                DataRow[] drEdit = dsRight.Tables[0].Select("RightType_ID=3 and ModuleName='Purchasing'");
                                if (drEdit != null && drEdit.Length > 0)
                                    App_Access = AccessType.Purchasing_Edit;

                                DataRow[] drLegal = dsRight.Tables[0].Select("RightType_ID=4 and ModuleName='Purchasing'");
                                if (drLegal != null && drLegal.Length > 0)
                                    App_Access = AccessType.Purchasing_Legal;

                                DataRow[] drAdmin = dsRight.Tables[0].Select("RightType_ID=1 and ModuleName='Purchasing'");
                                if (drAdmin != null && drAdmin.Length > 0)
                                    App_Access = AccessType.Administrative_Access;
                            }
                        }
                        else if (strModule == "RealEstate/")
                        {
                            if (boolAccessSet == false)
                            {
                                boolAccessSet = true;

                                DataRow[] drView = dsRight.Tables[0].Select("RightType_ID=2 and ModuleName='RealEstate'");
                                if (drView != null && drView.Length > 0)
                                {
                                    if (strModule == "RealEstate/")
                                        App_Access = AccessType.View_Only;
                                }

                                DataRow[] drEdit = dsRight.Tables[0].Select("RightType_ID=5 and ModuleName='RealEstate'");
                                if (drEdit != null && drEdit.Length > 0)
                                {
                                    if (strModule == "RealEstate/")
                                        App_Access = AccessType.RealEstate_Edit;
                                }

                                DataRow[] drAdmin = dsRight.Tables[0].Select("RightType_ID=1 and ModuleName='RealEstate'");
                                if (drAdmin != null && drAdmin.Length > 0)
                                {
                                    if (strModule == "RealEstate/")
                                        App_Access = AccessType.Administrative_Access;
                                }
                            }
                        }
                        else if (strModule == "COI/")
                        {
                            if (boolAccessSet == false)
                            {
                                boolAccessSet = true;

                                DataRow[] drView = dsRight.Tables[0].Select("RightType_ID=2 and ModuleName='COI'");
                                if (drView != null && drView.Length > 0)
                                {
                                    App_Access = AccessType.View_Only;
                                }

                                DataRow[] drAdmin = dsRight.Tables[0].Select("RightType_ID=1 and ModuleName='COI'");
                                if (drAdmin != null && drAdmin.Length > 0)
                                {
                                    App_Access = AccessType.Administrative_Access;
                                }
                            }
                        }
                        else if (strModule == "Franchise/")
                        {
                            if (boolAccessSet == false)
                            {
                                boolAccessSet = true;

                                DataRow[] drView = dsRight.Tables[0].Select("RightType_ID=2 and ModuleName='Franchise'");
                                if (drView != null && drView.Length > 0)
                                {
                                    App_Access = AccessType.Franchise_View;
                                }

                                DataRow[] drAdmin = dsRight.Tables[0].Select("RightType_ID=1 and ModuleName='Franchise'");
                                if (drAdmin != null && drAdmin.Length > 0)
                                {
                                    App_Access = AccessType.Administrative_Access;
                                }
                            }
                        }
                        else if (strModule == "CRM/")
                        {
                            if (boolAccessSet == false)
                            {
                                boolAccessSet = true;

                                DataRow[] drView = dsRight.Tables[0].Select("RightType_ID=2 and ModuleName='CRM'");
                                if (drView != null && drView.Length > 0)
                                {
                                    App_Access = AccessType.View_Only;
                                }

                                DataRow[] drAdd = dsRight.Tables[0].Select("RightType_ID=7 and ModuleName='CRM'");
                                if (drAdd != null && drAdd.Length > 0)
                                {
                                    App_Access = AccessType.CRM_Add;
                                }

                                DataRow[] drEdit = dsRight.Tables[0].Select("RightType_ID=6 and ModuleName='CRM'");
                                if (drEdit != null && drEdit.Length > 0)
                                {
                                    App_Access = AccessType.CRM_Edit;
                                }

                                DataRow[] drAdmin = dsRight.Tables[0].Select("RightType_ID=1 and ModuleName='CRM'");
                                if (drAdmin != null && drAdmin.Length > 0)
                                {
                                    App_Access = AccessType.Administrative_Access;
                                }
                            }
                        }
                        else if (strModule == "ClaimInfo/")
                        {
                            if (Request.Url.ToString().IndexOf("OhioWCClaim.aspx") > 0)
                            {
                                DataRow[] drView = dsRight.Tables[0].Select("RightType_ID=8 and ModuleName='ClaimInfo'");
                                if (drView != null && drView.Length > 0)
                                {
                                    App_Access = AccessType.Ohio_Claim_Access;
                                }
                                boolAccessSet = true;
                            }
                            else
                            {
                                //check once right is set for the module and also check current right is administrative.
                                if (boolAccessSet == false || dsRight.Tables[0].Rows[iCount]["RightType_ID"].ToString() == "1")
                                {
                                    boolAccessSet = true;
                                    if (dsRight.Tables[0].Rows[iCount]["RightType_ID"].ToString() == "2")
                                    {
                                        App_Access = AccessType.View_Only;
                                    }
                                    else
                                    {
                                        App_Access = AccessType.Administrative_Access;
                                    }
                                }
                            }
                        }
                        else if (strModule == "Diary/")
                        {
                            if (Request.Url.ToString().IndexOf("Diary.aspx") > 0)
                            {
                                //check once right is set for the module and also check current right is administrative.
                                if (boolAccessSet == false || dsRight.Tables[0].Rows[iCount]["RightType_ID"].ToString() == "1")
                                {
                                    boolAccessSet = true;
                                    if (dsRight.Tables[0].Rows[iCount]["RightType_ID"].ToString() == "2")
                                    {
                                        App_Access = AccessType.View_Only;
                                    }
                                    else
                                    {
                                        App_Access = AccessType.Administrative_Access;
                                    }
                                }
                            }
                        }
                        else if (strModule == "Sedgwick/")
                        {
                            //if (boolAccessSet == false)
                            //{
                            //    boolAccessSet = true;

                            //    DataRow[] drView = dsRight.Tables[0].Select("RightType_ID=2 and ModuleName='Sedgwick'");
                            //    if (drView != null && drView.Length > 0)
                            //    {
                            //        App_Access = AccessType.View_Only;
                            //    }

                            //    DataRow[] drAdmin = dsRight.Tables[0].Select("RightType_ID=1 and ModuleName='Sedgwick'");
                            //    if (drAdmin != null && drAdmin.Length > 0)
                            //    {
                            //        App_Access = AccessType.Administrative_Access;
                            //    }
                            //}
                            //if (clsSession.IsUserRegionalOfficer == false && Convert.ToInt32(clsSession.UserAccess)==0)
                            //{
                            //    boolAccessSet = false;
                            //}

                            if (boolAccessSet == false)
                            {
                                DataRow[] drView = dsRight.Tables[0].Select("RightType_ID=2 and ModuleName='Sedgwick'");
                                DataRow[] drAdmin = dsRight.Tables[0].Select("RightType_ID=1 and ModuleName='Sedgwick'");

                                if (clsSession.IsUserRegionalOfficer == true || Convert.ToInt32(clsSession.UserAccess) == 1)
                                {
                                    boolAccessSet = true;
                                    if (clsSession.IsUserRegionalOfficer == true)
                                    {
                                        if (drView != null && drView.Length > 0)
                                        {
                                            App_Access = AccessType.View_Only;
                                        }
                                        if (drAdmin != null && drAdmin.Length > 0)
                                        {
                                            App_Access = AccessType.Administrative_Access;
                                        }

                                    }
                                    if (Convert.ToInt32(clsSession.UserAccess) == 1)
                                    {
                                        App_Access = AccessType.Administrative_Access;
                                    }
                                }
                                else if (drView.Length > 0 || drAdmin.Length > 0)
                                {
                                    boolAccessSet = true;
                                    if (drAdmin.Length > 0)
                                    {
                                        App_Access = AccessType.Administrative_Access;
                                    }
                                    else
                                    {
                                        App_Access = AccessType.View_Only;
                                    }
                                }
                                else
                                {
                                    boolAccessSet = false;
                                }
                            }

                            //if (Request.Url.ToString().IndexOf("ClaimReviewWorkSheetGroupSearch.aspx") > 0)
                            //{
                            //    //check once right is set for the module and also check current right is administrative.
                            //    if (boolAccessSet == false || dsRight.Tables[0].Rows[iCount]["RightType_ID"].ToString() == "1")
                            //    {
                            //        boolAccessSet = true;
                            //        if (dsRight.Tables[0].Rows[iCount]["RightType_ID"].ToString() == "2")
                            //        {
                            //            App_Access = AccessType.View_Only;
                            //        }
                            //        else
                            //        {
                            //            App_Access = AccessType.Administrative_Access;
                            //        }
                            //    }
                            //}
                        }
                        else if (strModule == "ACI Management/")
                        {
                            if (boolAccessSet == false)
                            {
                                boolAccessSet = true;

                                DataRow[] drView = dsRight.Tables[0].Select("RightType_ID=2 and ModuleName='ACI Management'");
                                if (drView != null && drView.Length > 0)
                                {
                                    App_Access = AccessType.View_Only;
                                }

                                DataRow[] drAdmin = dsRight.Tables[0].Select("RightType_ID=1 and ModuleName='ACI Management'");
                                if (drAdmin != null && drAdmin.Length > 0)
                                {
                                    App_Access = AccessType.Administrative_Access;
                                }
                            }
                        }
                        //else if (strModule == "VOC/")
                        //{
                        //    if (boolAccessSet == false && dsRight.Tables[0].Rows[iCount]["RightType_ID"].ToString() == "9")
                        //    {
                        //        boolAccessSet = true;
                        //        App_Access = AccessType.VOC_Import;
                        //    }
                        //}
                        else
                        {
                            //check once right is set for the module and also check current right is administrative.
                            if (boolAccessSet == false || dsRight.Tables[0].Rows[iCount]["RightType_ID"].ToString() == "1")
                            {
                                boolAccessSet = true;
                                if (dsRight.Tables[0].Rows[iCount]["RightType_ID"].ToString() == "2")
                                {
                                    App_Access = AccessType.View_Only;
                                }
                                else
                                {
                                    App_Access = AccessType.Administrative_Access;
                                }
                            }
                        }
                        #endregion
                    }
                }
                if (boolAccessSet == false)
                {
                    App_Access = AccessType.NotAssigned;
                }
            }

            //if (strModule == "SLT/" && UserAccessType == AccessType.Administrative_Access)
            //{
            //    App_Access = AccessType.Administrative_Access;
            //}


            // check for user with group - Admin / RLCMs 
            DataSet dsGroup = Security.SelectGroupByUserID(Convert.ToDecimal(clsSession.UserID));

            // check if user is system administrator
            DataRow[] drAdminGrp = dsGroup.Tables[0].Select("Group_Name = 'Administrative'");
            IsUserSystemAdmin = drAdminGrp.Length > 0;
            string[] allowUsersForEmployee = { "tjhallice", "jjames", "brady.lamp", "durham" };


            if (IsUserSystemAdmin)
            {
                boolAccessSet = true;
                App_Access = AccessType.Administrative_Access;
            }

            // check access to  run and view the Reports- Administrator-User Report 
            if (strModule == "Administrator/" && strUrl.IndexOf("rptSecurity.aspx") > 0)
            {
                if (UserAccessType != AccessType.Administrative_Access)
                {
                    if (dsGroup.Tables[0].Rows.Count <= 0)
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                }
            }
            else if (strModule == "Administrator/" && strUrl.IndexOf("EmployeeSearchResult.aspx") > 0 && Array.IndexOf(allowUsersForEmployee, clsSession.UserName) < 0)
            {
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
            }

            else if (strModule == "SLT/" && !boolAccessSet)
            {
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
            }

            else if (strModule == "ACI Management/" && !boolAccessSet)
            {
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
            }
            // if user have add/edit rights for CRM then allow look up table maintenance
            else if (strModule == "Administrator/" && strUrl.IndexOf("CRM") > 0)
            {
                if (dsRight.Tables[0].Rows.Count > 0)
                {
                    DataRow[] drRight = dsRight.Tables[0].Select("RightType_ID in (1,6,7) and ModuleName='CRM'");
                    if (drRight.Length == 0)
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                }
            }

            // check access to  run and view the Reports- SafetyTraining_AdhocReportWriter Report 
            else if (strModule == "SONIC/" && strUrl.IndexOf("SafetyTraining_AdhocReportWriter.aspx") > 0)
            {
                if (UserAccessType != AccessType.Administrative_Access)
                {
                    if (dsGroup.Tables[0].Rows.Count <= 0)
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                }
            }

            else
            {
                if (clsSession.IsUserRegionalOfficer && (UserAccessType != AccessType.Administrative_Access))
                {
                    if (strUrl.IndexOf("/Administrator/") > -1 && Request.Url.Segments[Request.Url.Segments.Length - 1].ToString() != "security.aspx"
                        && Request.Url.Segments[Request.Url.Segments.Length - 1].ToString() != "WallSearchByLocation.aspx")
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    if (strUrl.IndexOf("/Sedgwick/") > -1 && Request.Url.Segments[Request.Url.Segments.Length - 1].ToString() != "security.aspx" && !boolAccessSet
                        && Request.Url.Segments[Request.Url.Segments.Length - 1].ToString() != "WallSearchByLocation.aspx")
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                }
                else
                {
                    clsSession.IsUserRegionalOfficer = clsSession.IsUserRegionalOfficer && (UserAccessType != AccessType.Administrative_Access);

                    if (clsSession.IsUserPurchsingAdmin && strUrl.IndexOf("/Administrator/") > 0)
                    {
                        if (strUrl.Contains("DealershipDepartment.aspx") || strUrl.Contains("LeaseRentalEquipmentType.aspx") || strUrl.Contains("Manufacturer.aspx"))
                        {
                        }
                        else
                        {
                            Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                        }


                    }

                    // check user have administrative access or not. if not than not able to enter into Admin section 
                    if (UserAccessType != AccessType.Administrative_Access)
                    {
                        if ((UserAccessType == AccessType.View_Only) && strUrl.IndexOf("/Administrator/") > 0 && Request.Url.Segments[Request.Url.Segments.Length - 1].ToString() != "ChangePassword.aspx"
                            && Request.Url.Segments[Request.Url.Segments.Length - 1].ToString() != "WallSearch.aspx" && Request.Url.Segments[Request.Url.Segments.Length - 1].ToString() != "WallSearchByLocation.aspx")
                        {
                            Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                        }
                    }


                    if ((strUrl.Contains("ExposureSearch") || strUrl.Contains("DealershipDBA_Pupup")) && App_Access == AccessType.NotAssigned && App_RealEstateAccess == AccessType.NotAssigned)
                    {
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    }
                    // if user donot have admin access and try to access than redirect to error page.
                    else if (strUrl.IndexOf("/Administrator/") == -1 && App_Access == AccessType.NotAssigned && !(strUrl.Contains("ExposureSearch") || strUrl.Contains("DealershipDBA_Pupup")))
                    {
                        if ( (clsSession.IsACIUser == true && !(strUrl.Contains("rptDefault") || strUrl.Contains("rptACI_Key_Contact_Report"))) || (clsSession.IsACIUser == false && (strUrl.Contains("rptDefault"))))
                            Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    }
                }
            }
        }
    }

    /// <summary>
    /// Get User Access Type
    /// </summary>
    public AccessType UserAccessType
    {
        get
        {
            switch (clsSession.UserRole)
            {
                case "1":
                    return AccessType.Administrative_Access;
                    break;
                case "0":
                    return AccessType.View_Only;
                    break;
                default: return AccessType.Administrative_Access;
                    break;
            }
        }
    }
    /// <summary>
    /// When error occured throught the application this method is called
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PageBase_Error(object sender, EventArgs e)
    {
        string cssPath = Request.ApplicationPath + "/Images/err.css";
        string baseNamespace = "MGShop";
        StringBuilder sbError = new StringBuilder("<LINK href=\"" + cssPath + "\" type=\"text/css\"" + " rel=\"stylesheet\">");
        StringBuilder sbStack = new StringBuilder("");
        string strErrorToDispaly = "";
        Exception ex = Server.GetLastError();

        if ((ex) is HttpRequestValidationException)
        {
            sbError.Append("<div style=\"height: 50px;\">&nbsp;</div><div class=\"errorDiv\" style=\"margin:10 10 10 10;\"><h3 align=\"Center\">");
            sbError.Append("You have used HTML tags in your input text.");
            sbError.Append("<br /><br /><a href=\"javascript:history.back(1)\">Back</a>");
            sbError.Append("</h3></div>");
            Response.Write(sbError.ToString());
            Server.ClearError();
        }
        else
        {
        }
    }
}
