using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Collections.Generic;
using ERIMS.DAL;
using System.IO;

/// <summary>
/// By : Ravi Gupta, Modified By: Dhruti Desai
/// Purpose: This page is used to show user information
/// Functionality:
/// 1) can search admin by User ID
/// 2) Add/Edit/Delete Administrator Information.
/// </summary>

public partial class Administrator_security : clsBasePage
{

    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public int PK_Security_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Security_ID"]);
        }
        set { ViewState["PK_Security_ID"] = value; }
    }
    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string SortBy
    {
        get { return (!clsGeneral.IsNull(ViewState["SortBy"]) ? ViewState["SortBy"].ToString() : string.Empty); }
        set { ViewState["SortBy"] = value; }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string SortOrder
    {
        get { return (!clsGeneral.IsNull(ViewState["SortOrder"]) ? ViewState["SortOrder"].ToString() : string.Empty); }
        set { ViewState["SortOrder"] = value; }
    }

    /// <summary>
    /// Get and Set Security ID
    /// </summary>
    private Int32 SecurityID
    {
        get { return (!clsGeneral.IsNull(ViewState["SecurityID"]) ? Convert.ToInt32(ViewState["SecurityID"]) : 0); }
        set { ViewState["SecurityID"] = value; }
    }

    /// <summary>
    /// Contains Dairy related Right id
    /// </summary>
    private Int32 DiaryRightId
    {
        get { return (!clsGeneral.IsNull(ViewState["DiaryRightId"]) ? Convert.ToInt32(ViewState["DiaryRightId"]) : 0); }
        set { ViewState["DiaryRightId"] = value; }
    }

  
    #endregion

    #region Main Events
    /// <summary>
    /// Handles Page Load Event
    /// </summary>    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // set the default sort field and sort order
            SortBy = "USER_NAME";
            SortOrder = "Asc";

            //Bind Admin Grid
            BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);

            //Bind Region Dropdown
            ComboHelper.FillRegionListBox(new ListBox[] { lstRegion }, false);

            //bind Rights
            BindAllRights();

            //Bind Groups
            BindGroup();

            //used to prompt an confirm message.
            btnDelete.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvDiaryDetails','Delete');");
            PopupPassword.Style.Add("display", "none");

            //#3341 -- start
            //Take value from Session variable to be field in the Security Page if Admin Promotes the Access Requester
            if (Session["dtPromote"] != null)
            {
                btnAddNew_Click(sender, e);
            }
            //#3341 -- end
            //Bind Employee Dropdown
            //ComboHelper.FillAssociateName(new DropDownList[] { ddlEmployee }, 0, true);
        }
        //Set ListBox ToolTip
        clsGeneral.SetListBoxToolTip(new ListBox[] { lstFROIeMailRecipients, lstSelectedFields, lstSelectedFieldsView, lstSecurityLocation, lstSecuritySelectedLocation, lstSelectedLocationView, lstEventSecurityLocation, lstSecurityEventSelectedLocation, lstEventSelectedLocationView, lstManagementSecurityLocation, lstSecuritySelectedManagementLocation, lstManagementSelectedLocationView });

        string pwd = txtPassword.Text;
        txtPassword.Attributes.Add("value", pwd);
        string cpwd = txtConfirmPassword.Text;
        txtConfirmPassword.Attributes.Add("value", cpwd);
    }

    /// <summary>
    /// Handles Search Button Click Event (Bind Grid with Search Criteria)
    /// </summary>    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
    }

    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPage()
    {
        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
    }

    /// <summary>
    /// Add new User
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        divViewAdminList.Style.Add("display", "none");
        divModifyAdmin.Style.Add("display", "block");
        DivEditSecuirty.Style.Add("display", "block");
        DivViewSecurity.Style.Add("display", "none");
        tdRigionalOfficer.Style.Add("display", "none");
        tdRegion.Style.Add("display", "none");
        tdEmployee.Style.Add("display", "none");
        PK_Security_ID = 0;
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtUserID.Text = "";
        txtPassword.Attributes.Add("value", "");
        // txtPassword.Enabled = true;
        txtConfirmPassword.Attributes.Add("value", "");
        trPassword.Visible = true;
        rfvConfirmPassword.Enabled = true;
        rfvPassword.Enabled = true;
        //txtConfirmPassword.Enabled = true;
        txtEmail.Text = "";
        txtPhone.Text = "";
        rdoAdminRole.SelectedValue = "N";
        rdCorporateUser.SelectedValue = "N";
        HdnEmployeeID.Value = "0";
        HdnEmployeeName.Value = "";
        //chkAllowClaimInfo.Checked = true;
        hdnMode.Value = "0";
        chkRights.ClearSelection();
        for (int i = 0; i < chkRights.Items.Count; i++)
        {
            chkRights.Items[i].Enabled = true;
        }
        if (clsSession.IsUserRegionalOfficer && PK_Security_ID.ToString() != clsSession.UserID)
        {
            EnableDisableAdminAccessFields(false);
            rdoIsRegionalOfficer.SelectedValue = "0";
        }
        else
        {
            EnableDisableAdminAccessFields(true);
        }
        btnSave.Visible = true;
        BindListRegions();
        BindFROIeMailRecipients(false, null);
        BindSecurityACI_LocationList(false, null);
        BindEventSecurity_LocationList(false, null);
        BindManagementSecurity_LocationList(false, null);

        //#3341 -- start
        //Take value from Session variable to be field in the Security Page if Admin Promotes the Access Requester
        if (Session["dtPromote"] != null)
        {
            DataTable dt = (DataTable)Session["dtPromote"];
            if (dt.Rows.Count > 0)
            {
                txtFirstName.Enabled = txtLastName.Enabled = false;
                txtFirstName.Text = Convert.ToString(dt.Rows[0]["FirstName"]);
                txtLastName.Text = Convert.ToString(dt.Rows[0]["LastName"]);
                ViewState["Email"] = txtEmail.Text = Convert.ToString(dt.Rows[0]["EMail"]);
                txtPhone.Text = Convert.ToString(dt.Rows[0]["Telephone"]);
                rdoIsSonicEmployee.SelectedValue = Convert.ToString(dt.Rows[0]["EmployeeName"]) == "" ? "0":"1";
                rdoIsSonicEmployee_OnSelectedIndexChanged(sender, e);                

                if (HdnEmployeeID.Value != "")
                    BindFROIeMailRecipients(true, Convert.ToInt32(HdnEmployeeID.Value));
                tdEmployee.Style["display"] = "";
                tdRigionalOfficer.Style["display"] = "";
                HdnEmployeeID.Value = Convert.ToString(dt.Rows[0]["EmployeeId"]);
                HdnEmployeeName.Value = Convert.ToString(dt.Rows[0]["EmployeeName"]);
                lnkAssName.InnerText = Convert.ToString(dt.Rows[0]["EmployeeName"]);
            }
        }        
        //#3341 end
    }

    /// <summary>
    /// Handles Cancel Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //#3341 start        
        if (Session["dtPromote"] != null)
        {
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Redirect", "alert('User Access Request Cancelled.'); window.location='UserAccessRequestForm.aspx';", true);
            Session["dtPromote"] = null;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Redirect", "window.location='UserAccessRequestForm.aspx';", true);

        }
        //End
        else
        {
            PopupPassword.Style.Add("display", "none");
            divViewAdminList.Style.Add("display", "block");
            divModifyAdmin.Style.Add("display", "none");
            System.Web.UI.HtmlControls.HtmlTableRow trpass = (System.Web.UI.HtmlControls.HtmlTableRow)DivEditSecuirty.FindControl("trPassword");
            trpass.Style.Add("display", "");
            rdoIsSonicEmployee.ClearSelection();
            chkGroup.ClearSelection();
            chkRights.ClearSelection();
            lstInheritedRights.Items.Clear();
            rdoIsRegionalOfficer.ClearSelection();
            lstRegion.ClearSelection();
            lstReportType.ClearSelection();
            rdCorporateUser.ClearSelection();
        }

    }

    /// <summary>
    /// Handles Save Button click Event - Save User Information
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Security objSecurity = new Security(PK_Security_ID);
        objSecurity.PK_Security_ID = PK_Security_ID;

        // set value of Security object
        objSecurity.FIRST_NAME = txtFirstName.Text.Trim().Replace("'", "\'");
        objSecurity.LAST_NAME = txtLastName.Text.Trim().Replace("'", "\'");
        objSecurity.PASSWORD = Encryption.Encrypt(txtPassword.Text.Trim().Replace("'", "\'").ToString());
        objSecurity.USER_NAME = txtUserID.Text.Trim().Replace("'", "\'");
        objSecurity.Email = txtEmail.Text.Trim().Replace("'", "\'");
        objSecurity.Cost_Center = "";
        objSecurity.Phone = txtPhone.Text.ToString();
        objSecurity.UPDATED_BY = clsSession.UserID;
        objSecurity.UPDATE_DATE = DateTime.Now;
        objSecurity.Corporate_User = rdCorporateUser.SelectedValue;
        string strAllowedReport = "";
        foreach (ListItem objLstReport in lstReportType.Items)
        {
            if (objLstReport.Selected == true)
                strAllowedReport = strAllowedReport + objLstReport.Value.ToString() + ",";
        }
        objSecurity.AllowedReportType = strAllowedReport.ToString().TrimEnd(Convert.ToChar(","));

        if (rdoIsSonicEmployee.SelectedValue == "1")
        {
            objSecurity.Employee_Id = (HdnEmployeeID.Value.ToString() != string.Empty) ? Convert.ToDecimal(HdnEmployeeID.Value) : 0;
            objSecurity.IsRegionalOfficer = rdoIsRegionalOfficer.SelectedValue == "1" ? true : false;
        }
        else
        {
            objSecurity.Employee_Id = 0;
            objSecurity.IsRegionalOfficer = false;
            //objSecurity.AllowedReportType = "";
        }
        objSecurity.USER_ROLE = rdoAdminRole.SelectedValue == "Y" ? Convert.ToDecimal(1) : Convert.ToDecimal(0);

        Employee objEmp = new Employee(Convert.ToDecimal(objSecurity.Employee_Id));
        string emp_name = string.Empty;

        if (objEmp.Last_Name != null)
            emp_name = Convert.ToString(objEmp.Last_Name).Trim();

        if (objEmp.First_Name != null)
            emp_name += Convert.ToString(objEmp.First_Name).Trim();

        if (Convert.ToDecimal(objEmp.PK_Employee_ID) > 0)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "AssignValue('" + emp_name.ToString().Replace("'", "\\'").Trim() + "','" + objSecurity.Employee_Id + "');", true);
        }

        string strRegions = "";

        //if (clsSession.IsUserRegionalOfficer && PK_Security_ID.ToString() != clsSession.UserID)
        //{
        foreach (ListItem itm in lstRegion.Items)
        {
            if (itm.Selected)
                strRegions = strRegions + itm.Text + ",";
        }
        strRegions = strRegions.TrimEnd(',');
        //}
        objSecurity.Region = strRegions;

        if (PK_Security_ID > 0)
        {
            int RtnVal = objSecurity.Update();
            // Used to Check Duplicate user ID?
            if (RtnVal == -2)
            {
                lblError.Text = "User ID already exists.";
                return;
            }

        }
        else
        {
            if (clsGeneral.CheckPassword(txtPassword.Text) == false)
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "alert('Password must have at least 7 characters, one character, one digit and one special character!')", true);
                return;
            }
            PK_Security_ID = objSecurity.Insert();

            // Used to Check Duplicate User ID?
            if (PK_Security_ID == -2)
            {
                lblError.Text = "User ID already exists.";
                return;
            }
            else
            {
                if (SendUserAccessRequestName())
                {
                    if (SendUserAccessRequestPassword())
                    { 
                          DataTable dt = (DataTable)Session["dtPromote"];
                          if (dt.Rows.Count > 0)
                          {
                              if (!string.IsNullOrEmpty(dt.Rows[0]["PK_U_A_Request"].ToString()))
                              {
                                  U_A_Request u_a_request = new U_A_Request(Convert.ToDecimal(dt.Rows[0]["PK_U_A_Request"]));
                                  u_a_request.Deny = false;
                                  u_a_request.Update_Date = DateTime.Now;
                                if (!string.IsNullOrEmpty(clsSession.UserID))
                                    u_a_request.Updated_By = clsSession.UserID;
                                else
                                    u_a_request.Updated_By = "New User";

                                if (Convert.ToDecimal(dt.Rows[0]["PK_U_A_Request"].ToString()) > 0)
                                {
                                    u_a_request.Update();                                    
                                }

                              }
                          }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "alert('Emails couldn't be sent due to technical Issue!')", true);
                    }
                }
            }
            
        }
        //deleting Assoc user group
        Assoc_User_Group.DeleteByUserID(PK_Security_ID);
        //Adding Group value to database
        Assoc_User_Group objAss_User_Group = new Assoc_User_Group();
        //loop for inserting Group
        for (int intLoop = 0; intLoop < chkGroup.Items.Count; intLoop++)
        {
            //check Group is selected or not.
            if (chkGroup.Items[intLoop].Selected == true)
            {
                //set Group value to object
                objAss_User_Group.FK_User_ID = PK_Security_ID;
                objAss_User_Group.FK_Group_ID = Convert.ToInt32(chkGroup.Items[intLoop].Value);
                objAss_User_Group.Insert();
            }
        }
        #region
        if (rdoIsSonicEmployee.SelectedValue == "1")
        {
            //Add values for Regional Officer
            if (rdoIsRegionalOfficer.SelectedValue == "1")
            {
                //delete Region for User
                Regional_Access.DeleteBySecurityID(PK_Security_ID);
                foreach (ListItem objLstRegion in lstRegion.Items)
                {
                    if (objLstRegion.Selected == true)
                    {
                        //adding Region Value to database
                        Regional_Access objRegionalAccess = new Regional_Access();
                        objRegionalAccess.Region = objLstRegion.Value.ToString();
                        objRegionalAccess.FK_Security_ID = PK_Security_ID;
                        objRegionalAccess.Insert();
                    }
                }
            }
            else
            {
                //delete Region for User
                Regional_Access.DeleteBySecurityID(PK_Security_ID);
            }
        }
        else
        {
            //delete Region for User
            Regional_Access.DeleteBySecurityID(PK_Security_ID);
        }
        #endregion
        //delete Assoc User Right
        Assoc_User_Right.DeleteByUserID(PK_Security_ID);
        //adding Rights value to Database
        Assoc_User_Right objAss_User_Right = new Assoc_User_Right();
        //loop for inserting Right
        for (int intLoop = 0; intLoop < chkRights.Items.Count; intLoop++)
        {
            //check Group is selected or not.
            if (chkRights.Items[intLoop].Selected == true && chkRights.Items[intLoop].Enabled == true)
            {
                //set Group value to object
                objAss_User_Right.FK_User_ID = PK_Security_ID;
                objAss_User_Right.FK_Right_ID = Convert.ToInt32(chkRights.Items[intLoop].Value);
                objAss_User_Right.Insert();
            }
        }
        //Loop for inserting E-Mail Recipients List
        clsFROI_EMail_Recipients.DeleteByUser(PK_Security_ID);
        foreach (ListItem Li in lstSelectedFields.Items)
        {
            clsFROI_EMail_Recipients objFROI_EMail_Recipients = new clsFROI_EMail_Recipients();
            objFROI_EMail_Recipients.FK_Security_ID = PK_Security_ID;
            objFROI_EMail_Recipients.FK_LU_Location_ID = Convert.ToInt32(Li.Value);
            objFROI_EMail_Recipients.Insert();
        }

        //Loop for inserting ACI Locations
        clsSecurity_ACI_LU_Location_Link.DeleteByUser(PK_Security_ID);
        foreach (ListItem Li in lstSecuritySelectedLocation.Items)
        {
            clsSecurity_ACI_LU_Location_Link objSecurity_ACI_LU_Location = new clsSecurity_ACI_LU_Location_Link();
            objSecurity_ACI_LU_Location.FK_Security_ID = PK_Security_ID;
            objSecurity_ACI_LU_Location.FK_LU_Location_ID = Convert.ToInt32(Li.Value);
            objSecurity_ACI_LU_Location.Insert();
        }

        //Loop for inserting Event Locations
        clsEvent_Email_Recipients.DeleteByUser(PK_Security_ID);
        foreach (ListItem Li in lstSecurityEventSelectedLocation.Items)
        {
            clsEvent_Email_Recipients objEventLocation = new clsEvent_Email_Recipients();
            objEventLocation.FK_Security_ID = PK_Security_ID;
            objEventLocation.FK_LU_Location_ID = Convert.ToInt32(Li.Value);
            objEventLocation.Insert();
        }

        //Loop for inserting Management Locations
        clsManagement_Email_Recipients.DeleteByUser(PK_Security_ID);
        foreach (ListItem Li in lstSecuritySelectedManagementLocation.Items)
        {
            clsManagement_Email_Recipients objManagementLocation = new clsManagement_Email_Recipients();
            objManagementLocation.FK_Security_ID = PK_Security_ID;
            objManagementLocation.FK_LU_Location_ID = Convert.ToInt32(Li.Value);
            objManagementLocation.Insert();
        }

        if (clsSession.UserID == PK_Security_ID.ToString())
            clsSession.IsUserRegionalOfficer = rdoIsRegionalOfficer.SelectedValue == "1" && rdoAdminRole.SelectedValue != "Y";

        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
        SaveAssocAttachmentRights();
        SaveAssocFCDocumentFolderAttachmentRights();

        btnCancel_Click(sender, e);
        //}

    }


    #region "EmailMethods"
    /// <summary>
    /// User Request Mail Send Method for User-Id
    /// </summary>
    /// <param name="_IsAttachment"></param>
    private bool SendUserAccessRequestName()
    {
        bool flag = false;

        //used to send Email
        if (PK_Security_ID > 0)
        {
            string[] EmailTo = new string[1];

            Security objSecurity = new Security(PK_Security_ID);
            if (string.IsNullOrEmpty(ViewState["Email"].ToString()))
            {                
                EmailTo[0] = objSecurity.Email;
            }
            else
                EmailTo[0] = Convert.ToString(ViewState["Email"]);


            string HtmlBody = "You have been granted access to the Sonic eRIMS2 system. The URL of the software is https://sonic.erims2.com. Your User Id is " + objSecurity.USER_NAME + ". Your password will be forwarded to you in a separate e-mail.";

            //generate FIle and store it on disk
            clsGeneral.CreateDirectory(AppConfig.SitePath + "SONIC-Email/" + "FN" + "_" + "LN" + "/U_A_request/" + DateTime.Today.ToString("MM-dd-yyyy"));



            if (EmailTo.Length > 0)
            {
                EmailHelper objEmail = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));

                objEmail.SendMailMessage(AppConfig.MailFrom, "Admin", EmailTo, "eRIMS2 Access E-Mail 1 of 2", HtmlBody, false, null, AppConfig.MailCC);

                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }
        else
            return false;

    }


    /// <summary>
    /// User Request Mail Send Method for Password
    /// </summary>
    /// <param name="_IsAttachment"></param>
    private bool SendUserAccessRequestPassword()
    {
        bool flag = false;

        //used to send Email
        if (PK_Security_ID > 0)
        {            
            string[] EmailTo = new string[1];
            Security objSecurity = new Security(PK_Security_ID);
            U_A_Request_Admin objU_A_Request_Admin = new U_A_Request_Admin(1);
            if (string.IsNullOrEmpty(ViewState["Email"].ToString()))
            {                
                EmailTo[0] = objSecurity.Email;
            }
            else
                EmailTo[0] = Convert.ToString(ViewState["Email"]);

            string HtmlBody = "Your initial Sonic eRIMS2 password is " + Encryption.Decrypt(objSecurity.PASSWORD) + ". The password must be changed every 45 days." +
                "If you have questions using Sonic’s eRIMS2, please contact " + Convert.ToString(objU_A_Request_Admin.Name) + " at " + Convert.ToString(objU_A_Request_Admin.Admin_EMail);

            //generate FIle and store it on disk
            clsGeneral.CreateDirectory(AppConfig.SitePath + "SONIC-Email/" + "FN" + "_" + "LN" + "/U_A_request/" + DateTime.Today.ToString("MM-dd-yyyy"));



            if (EmailTo.Length > 0)
            {
                EmailHelper objEmail = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));

                objEmail.SendMailMessage(AppConfig.MailFrom, "Admin", EmailTo, "eRIMS2 Access E-Mail 2 of 2", HtmlBody, false, null, AppConfig.MailCC);

                ViewState["Email"] = null;

                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }
        else
            return false;

    }    
    #endregion

  

    /// <summary>
    /// Delete User Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (clsSession.IsUserRegionalOfficer)
        {
            string strSelected = Request.Form["chkItem"].ToString();
            foreach (GridViewRow gRow in gvSecurity.Rows)
            {
                if (((Button)gRow.FindControl("btnEdit")).Enabled == false)
                {
                    strSelected = strSelected.Replace(gvSecurity.DataKeys[gRow.RowIndex].Value.ToString(), "");
                    strSelected = strSelected.Replace(",,", "");
                    strSelected = strSelected.TrimStart(',');
                    strSelected = strSelected.TrimEnd(',');
                }
            }
            if (strSelected.Length > 0)
                Security.DeleteByPKs(strSelected);
        }
        else
        {
            clsSecurity_ACI_LU_Location_Link.DeleteByPK(Convert.ToDecimal(Request.Form["chkItem"]));
            Security.DeleteByPKs(Request.Form["chkItem"].ToString());
        }
        //Bind Grid
        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
    }

    /// <summary>
    /// Handles Selected Index Change Event of Group Checkbox
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intI, intJ, intK = 0;
        //used to clear all selection
        chkRights.ClearSelection();
        //clear Inherited Rights List
        lstInheritedRights.Items.Clear();
        //used to enabled all the item of Rights
        for (intJ = 0; intJ < chkRights.Items.Count; intJ++)
        {
            chkRights.Items[intJ].Enabled = true;
        }
        //SetUserRights(chkGroup.Items[0].Value.ToString());
        for (intK = 0; intK < chkGroup.Items.Count; intK++)
        {
            if (chkGroup.Items[intK].Selected == true)
            {
                DataSet dsGroupRight = Assoc_Right_Group.SelectByGroupID(Convert.ToInt32(chkGroup.Items[intK].Value.ToString()));
                //Loop for Rights associated with selected Group from Database
                for (intI = 0; intI < dsGroupRight.Tables[0].Rows.Count; intI++)
                {
                    //loop for Rights that that are Binded with Checkbox list
                    for (intJ = 0; intJ < chkRights.Items.Count; intJ++)
                    {
                        //used to check whether the Rights in Checkbox list is equal to database value. if yes than selec that checkbox listItem else Uncheck.
                        if (chkRights.Items[intJ].Value.ToString() == dsGroupRight.Tables[0].Rows[intI]["FK_Right_ID"].ToString())
                        {
                            chkRights.Items[intJ].Selected = true;
                            chkRights.Items[intJ].Enabled = false;
                            ListItem lstFindVal = lstInheritedRights.Items.FindByValue(chkRights.Items[intJ].Value.ToString());
                            if (lstFindVal == null)
                            {
                                lstInheritedRights.Items.Add(new ListItem(chkRights.Items[intJ].Text.ToString(), chkRights.Items[intJ].Value.ToString()));
                            }
                        }

                    }
                }
            }
        }

        BindDocumentFolderSecurity();
        BindFCDocumentFolderSecurity();
        FillFCDocumentFolderSecurity();
    }

    protected void chkRights_SelectedIndexChanged(object sender, EventArgs e)
    {
        string result = Request.Form["__EVENTTARGET"];
        string[] checkedBox = result.Split('$');
        int index = int.Parse(checkedBox[checkedBox.Length - 1]);

        if (Convert.ToInt32(chkRights.Items[index].Value) == DiaryRightId && chkRights.Items[index].Selected == false)
        {
            if (!Security.ValidateUserDiary(PK_Security_ID))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Please clear all the diaries of selected user first.');", true);
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
        }
        else { btnSave.Enabled = true; }

        BindDocumentFolderSecurity();
    }

    #endregion

    #region Methods
    /// <summary>
    /// Used to Bind Rights.
    /// </summary>
    private void BindAllRights()
    {
        DataSet dsRights = Right.SelectAll();
        chkRights.DataSource = dsRights;
        chkRights.DataTextField = "Right_Name";
        chkRights.DataValueField = "PK_Right_ID";
        chkRights.DataBind();

        Int32 _DiaryRightId = 0;
        DataTable dt = new DataTable();

        string strModule = "Diary";
        //dt.Rows.Add(dsRights.Tables[0].Select("RightType_Id = 1 AND ModuleName='" + strModule + "'"));

        DataRow[] drArr = dsRights.Tables[0].Select("RightType_Id = 1 AND ModuleName='" + strModule + "'");

        foreach (DataRow dr in drArr)
        {
            int.TryParse(dr["PK_Right_ID"].ToString(), out _DiaryRightId);
            DiaryRightId = _DiaryRightId;
            break;
        }

        //if (dt != null && dt.Rows.Count > 0 )
        //{
        //    int.TryParse(dt.Rows[0]["PK_Right_ID"].ToString(), out _DiaryRightId);
        //    DiaryRightId = _DiaryRightId;
        //    dt = null;
        //}
    }

    /// <summary>
    /// Used to Bind Group.
    /// </summary>
    private void BindGroup()
    {
        DataSet dsGroups = Group.SelectAll();
        chkGroup.DataSource = dsGroups;
        chkGroup.DataTextField = "Group_Name";
        chkGroup.DataValueField = "PK_Group_ID";
        chkGroup.DataBind();
    }

    /// <summary>
    /// Used to Bind Rights View.
    /// </summary>
    private void BindAllRightsView()
    {
        DataSet dsRights = Right.SelectAll();
        chkRightsView.DataSource = dsRights;
        chkRightsView.DataTextField = "Right_Name";
        chkRightsView.DataValueField = "PK_Right_ID";
        chkRightsView.DataBind();
    }

    /// <summary>
    /// Used to Bind Group View.
    /// </summary>
    private void BindGroupView()
    {
        DataSet dsGroups = Group.SelectAll();
        chkGroupView.DataSource = dsGroups;
        chkGroupView.DataTextField = "Group_Name";
        chkGroupView.DataValueField = "PK_Group_ID";
        chkGroupView.DataBind();
    }

    /// <summary>
    /// Binds the grid by page number and page size
    /// </summary>
    /// <param name="PageNumber">Current page number</param>
    /// <param name="PageSize">Number of records to be displayed on a page</param>
    private void BindGrid(int PageNumber, int PageSize)
    {
        DataSet dsAdmin = Security.SelectAll(txtSearch.Text.Trim().Replace("'", "''"), SortBy, SortOrder, PageNumber, PageSize);
        DataTable dtAdminData = dsAdmin.Tables[0];

        // set values for paging control,so it shows values as needed.
        ctrlPageProperty.TotalRecords = (dsAdmin.Tables.Count >= 3) ? Convert.ToInt32(dsAdmin.Tables[1].Rows[0][0]) : 0;
        ctrlPageProperty.CurrentPage = (dsAdmin.Tables.Count >= 3) ? Convert.ToInt32(dsAdmin.Tables[2].Rows[0][2]) : 0;
        ctrlPageProperty.RecordsToBeDisplayed = dtAdminData.Rows.Count;
        ctrlPageProperty.SetPageNumbers();

        // bind the grid.
        gvSecurity.DataSource = dtAdminData;
        gvSecurity.DataBind();
    }

    /// <summary>
    /// Used to Populate values to controls for Editing
    /// </summary>
    private void EditRecord()
    {        
        //Enable the disabled button if any #3341
        txtFirstName.Enabled = txtLastName.Enabled = true;
        //txtEmail.Enabled = txtPhone.Enabled = rdoIsSonicEmployee.Enabled = true;
        //lnkAssName.HRef = "#";

        btnSave.Enabled = true;
        PopupPassword.Style.Add("display", "block");
        DivViewSecurity.Style.Add("display", "none");
        DivEditSecuirty.Style.Add("display", "block");
        btnSave.Visible = true;
        for (int i = 0; i < chkRights.Items.Count; i++)
        {
            chkRights.Items[i].Enabled = true;
        }
        // Create an Object
        Security objSecurity = new Security(PK_Security_ID);
        hdnPKUserID.Value = objSecurity.PK_Security_ID.ToString();
        txtUserID.Text = objSecurity.USER_NAME.ToString();
        txtFirstName.Text = objSecurity.FIRST_NAME.ToString();
        txtLastName.Text = objSecurity.LAST_NAME.ToString();
        txtPassword.Text = Encryption.Decrypt(objSecurity.PASSWORD.ToString());
        txtPassword.Attributes.Add("value", txtPassword.Text);
        //txtPassword.Enabled = false;
        txtConfirmPassword.Attributes.Add("value", txtPassword.Text);
        trPassword.Visible = false;
        rfvConfirmPassword.Enabled = false;
        rfvPassword.Enabled = false;

        //txtConfirmPassword.Enabled = false;
        rdoAdminRole.SelectedValue = objSecurity.USER_ROLE.ToString() == "1" ? "Y" : "N";
        txtEmail.Text = objSecurity.Email.ToString();
        txtPhone.Text = objSecurity.Phone.ToString();
        rdCorporateUser.SelectedValue = objSecurity.Corporate_User;
        //chkAllowClaimInfo.Checked = objSecurity.Allow_ViewClaim;
        if (objSecurity.Employee_Id != null)
        {
            if (Convert.ToDecimal(objSecurity.Employee_Id) > 0)
            {
                rdoIsSonicEmployee.SelectedValue = "1";
                tdEmployee.Style.Add("display", "");
                tdRigionalOfficer.Style.Add("display", "");

                Employee objEmp = new Employee(Convert.ToDecimal(objSecurity.Employee_Id));
                string emp_name = string.Empty;

                if (objEmp.First_Name != null)
                    emp_name = Convert.ToString(objEmp.First_Name).Trim() + ", ";

                if (objEmp.Middle_Name != null)
                    emp_name += Convert.ToString(objEmp.Middle_Name).Trim() + " ";

                if (objEmp.Last_Name != null)
                    emp_name += Convert.ToString(objEmp.Last_Name).Trim();

                if (Convert.ToDecimal(objEmp.PK_Employee_ID) > 0)
                {
                    //ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "AssignValue('" + emp_name.ToString() + "','" + objSecurity.Employee_Id + "');", true);
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "AssignValue('" + emp_name.ToString().Replace("'", "\\'").Trim() + "','" + objSecurity.Employee_Id + "');", true);
                }

            }
            else
            {
                rdoIsSonicEmployee.SelectedValue = "0";
                tdEmployee.Style.Add("display", "none");
                tdRigionalOfficer.Style.Add("display", "none");
            }
            rdoIsRegionalOfficer.SelectedValue = objSecurity.IsRegionalOfficer == true ? "1" : "0";

            BindListRegions();
            if (rdoIsRegionalOfficer.SelectedValue == "1")
            {
                tdRigionalOfficer.Style.Add("display", "");
                tdRegion.Style.Add("display", "");
                trReportType.Style.Add("display", "");
                DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(PK_Security_ID));
                if (dsRegion.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
                    {
                        foreach (ListItem lstRegionName in lstRegion.Items)
                        {
                            if (lstRegionName.Value == drRegion["Region"].ToString())
                            {
                                lstRegionName.Selected = true;
                            }
                        }
                    }
                }
                revIsRegionalOfficer.Enabled = true;
                rfvRegion.Enabled = true;
            }
            //set Report Type allowed for the user
            string strRptType = "";
            strRptType = objSecurity.AllowedReportType.ToString();
            string[] RptType = strRptType.Split(Convert.ToChar(","));
            foreach (string strType in RptType)
            {
                foreach (ListItem lstRptType in lstReportType.Items)
                    if (lstRptType.Value == strType.ToString()) lstRptType.Selected = true;
            }
            BindFROIeMailRecipients(true, null);
            BindSecurityACI_LocationList(true, null);
            BindEventSecurity_LocationList(true, null);
            BindManagementSecurity_LocationList(true, null);
            //else
            //{
            // tdRegion.Style.Add("display", "none");
            // rfvRegion.Enabled = false;
            // lstRegion.ClearSelection();
            // lstReportType.ClearSelection();
            //}
        }
        else
        {
            rdoIsSonicEmployee.SelectedValue = "0";
            tdEmployee.Style.Add("display", "none");
            tdRigionalOfficer.Style.Add("display", "none");
        }
        if (clsSession.IsUserRegionalOfficer && PK_Security_ID.ToString() != clsSession.UserID)
        {
            if (!string.IsNullOrEmpty(objSecurity.Region))
            {
                string[] strRegions = objSecurity.Region.Split(',');
                foreach (string strRegion in strRegions)
                {
                    foreach (ListItem lstRegionName in lstRegion.Items)
                    {
                        if (lstRegionName.Text == strRegion)
                        {
                            lstRegionName.Selected = true;
                        }
                    }
                }
            }
        }
        else if (!clsSession.IsUserRegionalOfficer)
        {
            if (!string.IsNullOrEmpty(objSecurity.Region))
            {
                string[] strRegions = objSecurity.Region.Split(',');
                foreach (string strRegion in strRegions)
                {
                    foreach (ListItem lstRegionName in lstRegion.Items)
                    {
                        if (lstRegionName.Text == strRegion)
                        {
                            lstRegionName.Selected = true;
                        }
                    }
                }
            }
        }
        //Fill Group info by user id
        DataSet dsUser_Group = Assoc_User_Group.SelectByUserID(PK_Security_ID);
        //Creating Array
        //string[] GroupAvail = new string[dsUser_Group.Tables[0].Rows.Count];
        //check Dataset Row Count
        if (dsUser_Group.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsUser_Group.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < chkGroup.Items.Count; j++)
                {
                    if (chkGroup.Items[j].Value.ToString() == dsUser_Group.Tables[0].Rows[i]["FK_Group_ID"].ToString())
                    {
                        chkGroup.Items[j].Selected = true;
                        //GroupAvail[i] = chkGroup.Items[j].Value.ToString();
                    }
                }
            }
        }
        //fill Right info by user id
        DataSet dsUser_Right = Assoc_User_Right.SelectByUserID(PK_Security_ID);
        //check Dataset Row Count
        if (dsUser_Right.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsUser_Right.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < chkRights.Items.Count; j++)
                {
                    if (chkRights.Items[j].Value.ToString() == dsUser_Right.Tables[0].Rows[i]["FK_Right_ID"].ToString())
                    {
                        chkRights.Items[j].Selected = true;
                        lstInheritedRights.Items.Add(new ListItem(chkRights.Items[j].Text.ToString(), chkRights.Items[j].Value.ToString()));
                        if (Convert.ToBoolean(dsUser_Right.Tables[0].Rows[i]["IsAdditional"]) == false)
                        {
                            chkRights.Items[j].Enabled = false;
                        }
                    }
                }
            }
        }
        //if (clsSession.IsUserRegionalOfficer && PK_Security_ID.ToString() != clsSession.UserID)
        //{
        //    EnableDisableAdminAccessFields(false);
        //}
        //else
        //{
        //    EnableDisableAdminAccessFields(true);
        //}

        BindDocumentFolderSecurity();
        BindFCDocumentFolderSecurity();
        FillFCDocumentFolderSecurity();
        SelectDocumentFolderSecurity();

    }

    /// <summary>
    /// used to populate value to controls for View
    /// </summary>
    private void ViewRecord()
    {
        //used to clear all selection
        chkRightsView.ClearSelection();
        //clear Inherited Rights List
        lstInheritedRightsView.Items.Clear();
        //used to enabled all the item of Rights
        for (int intJ = 0; intJ < chkRightsView.Items.Count; intJ++)
        {
            chkRightsView.Items[intJ].Enabled = true;
        }
        //bind Rights View
        BindAllRightsView();
        //Bind Groups View
        BindGroupView();
        PopupPassword.Style.Add("display", "none");
        DivViewSecurity.Style.Add("display", "block");
        DivEditSecuirty.Style.Add("display", "none");
        btnSave.Visible = false;
        Security objSecurity = new Security(PK_Security_ID);

        lblUserID.Text = objSecurity.USER_NAME.ToString();
        lblFirstName.Text = objSecurity.FIRST_NAME.ToString();
        lblLastName.Text = objSecurity.LAST_NAME.ToString();
        if (objSecurity.USER_ROLE.ToString() == "1")
        {
            lblUserRole.Text = "Full Access";
        }
        else if (objSecurity.USER_ROLE.ToString() == "2")
        {
            lblUserRole.Text = "View Only";
        }
        lblEmail.Text = objSecurity.Email.ToString();
        lblPhone.Text = objSecurity.Phone.ToString();
        lblCorporateUser.Text = objSecurity.Corporate_User == "Y" ? "Yes" : "No";
        //chkAllowClaimInfo.Checked = objSecurity.Allow_ViewClaim;
        if (objSecurity.Employee_Id != null)
        {
            if (Convert.ToDecimal(objSecurity.Employee_Id) > 0)
            {
                lblIsSonicEmployee.Text = "Yes";
                tdEmployeeView.Style.Add("display", "");
                tdRigionalOfficerView.Style.Add("display", "");
                //tdRigionalOfficerView.Style.Add("display", "none");
                //tdRegionView.Style.Add("display", "none");
                //lblIsRegionalOfficer.Text = "";
                //lblRegion.Text = "";
                Employee objEmp = new Employee(Convert.ToDecimal(objSecurity.Employee_Id));
                string emp_name = string.Empty;
                if (objEmp.First_Name != null)
                    emp_name = Convert.ToString(objEmp.First_Name).Trim() + ", ";
                if (objEmp.Middle_Name != null)
                    emp_name += Convert.ToString(objEmp.Middle_Name).Trim() + " ";
                if (objEmp.Last_Name != null)
                    emp_name += Convert.ToString(objEmp.Last_Name).Trim();

                lblEmployee.Text = emp_name;
            }
            else
            {
                lblIsSonicEmployee.Text = "No";
                tdEmployeeView.Style.Add("display", "none");
                lblEmployee.Text = "";
                tdRigionalOfficerView.Style.Add("display", "none");
                tdRegionView.Style.Add("display", "");
                lblRegion.Text = "";
                lblReportType.Text = "";
            }
            lblIsRegionalOfficer.Text = objSecurity.IsRegionalOfficer == true ? "Yes" : "No";
            lblReportType.Text = objSecurity.AllowedReportType.ToString();
            if (objSecurity.IsRegionalOfficer == true)
            {
                tdRegionView.Style.Add("display", "");
                tdRigionalOfficerView.Style.Add("display", "");
                DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(objSecurity.PK_Security_ID));
                string RegionName = string.Empty;
                if (dsRegion.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
                    {
                        RegionName += drRegion["Region"].ToString() + ",";
                    }
                }
                lblRegion.Text = RegionName.ToString().TrimEnd(Convert.ToChar(","));

            }
            else
            {
                tdRegionView.Style.Add("display", "none");
                lblRegion.Text = "";
                //lblReportType.Text = "";
            }
        }
        else
        {
            lblIsSonicEmployee.Text = "No";
            tdEmployeeView.Style.Add("display", "none");
            lblEmployee.Text = "";
            tdRigionalOfficerView.Style.Add("display", "");
            tdRegionView.Style.Add("display", "");
            lblRegion.Text = "";
            lblReportType.Text = "";
            //lblIsRegionalOfficer.Text = objSecurity.IsRegionalOfficer == true ? "Yes" : "No";
            //DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(objSecurity.PK_Security_ID));
            //if (dsRegion.Tables[0].Rows.Count > 0)
            //{
            // lblRegion.Text= dsRegion.Tables[0].Rows[0]["Region"].ToString();
            //}
        }
        //Fill Group info by user id
        DataSet dsUser_Group = Assoc_User_Group.SelectByUserID(PK_Security_ID);
        //check Dataset Row Count
        if (dsUser_Group.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsUser_Group.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < chkGroupView.Items.Count; j++)
                {
                    if (chkGroupView.Items[j].Value.ToString() == dsUser_Group.Tables[0].Rows[i]["FK_Group_ID"].ToString())
                    {
                        chkGroupView.Items[j].Selected = true;
                        chkGroupView.Items[j].Enabled = false;
                    }
                    else
                        chkGroupView.Items[j].Enabled = false;
                }
            }
        }
        //fill Right info by user id
        DataSet dsUser_Right = Assoc_User_Right.SelectByUserID(PK_Security_ID);
        //check Dataset Row Count
        if (dsUser_Right.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsUser_Right.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < chkRightsView.Items.Count; j++)
                {
                    if (chkRightsView.Items[j].Value.ToString() == dsUser_Right.Tables[0].Rows[i]["FK_Right_ID"].ToString())
                    {
                        chkRightsView.Items[j].Selected = true;
                        lstInheritedRightsView.Items.Add(new ListItem(chkRightsView.Items[j].Text.ToString(), chkRightsView.Items[j].Value.ToString()));
                        chkRightsView.Items[j].Enabled = false;
                    }
                    else
                    {
                        chkRightsView.Items[j].Enabled = false;
                    }
                }
            }
        }
        if (clsSession.IsUserRegionalOfficer && PK_Security_ID.ToString() != clsSession.UserID)
        {
            if (objSecurity.Region != "")
                lblRegion.Text = objSecurity.Region;
            tdRegionView.Style["display"] = "";
            //trReportTypeView.Style["display"] = "none";
        }
        else if (!objSecurity.IsRegionalOfficer)
        {
            if (objSecurity.Region != "")
                lblRegion.Text = objSecurity.Region;
            tdRegionView.Style["display"] = "";
            //trReportTypeView.Style["display"] = "none";
        }
        BindFROIeMailRecipientsView();
        BindSecurityLocationView();
        BindEventSecurityLocationView();
        BindManagementSecurityLocationView();

        BindDocumentFolderSecurity();
        SelectDocumentFolderSecurityView();
    }

    /// <summary>
    /// Returns the index of the column which contains particular sort expression
    /// </summary>
    /// <param name="strSortExp">The column on which the sorting is to be performed</param>
    /// <returns>Integer</returns>
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvSecurity.Columns)
        {
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvSecurity.Columns.IndexOf(field);
            }
        }
        return nRet;
    }

    /// <summary>
    /// Enable or Disable Admin Access Fields
    /// </summary>
    /// <param name="bEnable"></param>
    private void EnableDisableAdminAccessFields(bool bEnable)
    {
        rdoAdminRole.Enabled = bEnable;
        rdoIsRegionalOfficer.Enabled = bEnable;
        //chkGroup.Enabled = bEnable;
        if (!bEnable)
        {
            //loop for inserting Right
            for (int intLoop = 0; intLoop < chkRights.Items.Count; intLoop++)
            {
                //check Group is selected or not.
                if (chkRights.Items[intLoop].Text.IndexOf("First Report") > -1)
                    chkRights.Items[intLoop].Enabled = true;
                else
                    chkRights.Items[intLoop].Enabled = false;
            }
        }
        else
            chkRights.Enabled = true;

        if (!bEnable)
        {
            //loop for inserting Right
            for (int intLoop = 0; intLoop < chkGroup.Items.Count; intLoop++)
            {
                //check Group is selected or not.
                if (chkGroup.Items[intLoop].Text.ToUpper().Equals("First Report Users".ToUpper()) ||
                chkGroup.Items[intLoop].Text.ToUpper().Equals("Controller".ToUpper()) ||
                chkGroup.Items[intLoop].Text.ToUpper().Equals("Human Resources".ToUpper()) ||
                chkGroup.Items[intLoop].Text.ToUpper().Equals("General Managers".ToUpper()) ||
                chkGroup.Items[intLoop].Text.ToUpper().Equals("Legal".ToUpper()))
                    chkGroup.Items[intLoop].Enabled = true;
                else
                    chkGroup.Items[intLoop].Enabled = false;
            }
        }
        else
            chkGroup.Enabled = true;

    }

    /// <summary>
    /// Adds the sorting image beside the column in the grid on which sorting has been performed
    /// </summary>
    /// <param name="headerRow">Header Row of the grid</param>
    private void AddSortImage(GridViewRow headerRow)
    {
        Int32 iCol = GetSortColumnIndex(SortBy);
        if (iCol == -1)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
        string strSortOrder = SortOrder == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();

        // check for the order and
        // set the images accordingly
        if (SortDirection.Ascending.ToString() == strSortOrder)
        {
            sortImage.ImageUrl = "~/Images/up-arrow.gif";
            sortImage.AlternateText = "Descending Order";
        }
        else
        {
            sortImage.ImageUrl = "~/Images/down-arrow.gif";
            sortImage.AlternateText = "Ascending Order";
        }
        // Add the image to the appropriate header cell.
        headerRow.Cells[iCol].Controls.Add(sortImage);

    }

    /// <summary>
    /// Bind List Regions
    /// </summary>
    private void BindListRegions()
    {
        lstRegion.Items.Clear();
        lstReportType.ClearSelection();
        if (clsSession.IsUserRegionalOfficer && PK_Security_ID.ToString() != clsSession.UserID)
        {
            DataTable dtRegions = Security.GetRegionalOfficerRegions(Convert.ToDecimal(clsSession.UserID)).Tables[0];
            lstRegion.DataSource = dtRegions;
            lstRegion.DataTextField = "Region";
            lstRegion.DataValueField = "Region";
            lstRegion.DataBind();

        }
        else
            //Bind Region Dropdown
            ComboHelper.FillRegionListBox(new ListBox[] { lstRegion }, false);

        tdRegion.Style["display"] = "";
        //trReportType.Style["display"] = "none";
    }

    /// <summary>
    /// Save selected Items from Folder Security List
    /// </summary>
    private void SaveAssocAttachmentRights()
    {
        clsAssoc_Attachment_Rights.DeleteByFK(PK_Security_ID);
        foreach (ListItem lst in lstFolderSecurity.Items)
        {
            if (lst.Selected)
            {
                clsAssoc_Attachment_Rights objAssoc_Attachment_Rights = new clsAssoc_Attachment_Rights();
                objAssoc_Attachment_Rights.FK_Attachment_Right = Convert.ToDecimal(lst.Value);
                objAssoc_Attachment_Rights.FK_User_ID = PK_Security_ID;
                objAssoc_Attachment_Rights.Insert();
            }
        }
    }

    /// <summary>
    /// Save selected Items from Facility Construction Document Folder Security List
    /// </summary>
    private void SaveAssocFCDocumentFolderAttachmentRights()
    {
        if (PK_Security_ID > 0)
        {
            clsAssoc_LU_FC_Document_Folder_Rights.DeleteByUserId(PK_Security_ID);
        }

        if (chkGroup.Items.FindByText("Administrative").Selected == true)
        {
            DataTable dtFCDocumentFolder = clsLU_FC_Document_Folder_Rights.SelectAll().Tables[0];

            for (int i = 0; i < dtFCDocumentFolder.Rows.Count; i++)
            {
                clsAssoc_LU_FC_Document_Folder_Rights assocFCDocumentFolder = new clsAssoc_LU_FC_Document_Folder_Rights();
                assocFCDocumentFolder.FK_LU_FC_Document_Folder_Rights = Convert.ToDecimal(dtFCDocumentFolder.Rows[i]["PK_LU_FC_Document_Folder_Rights"]);
                assocFCDocumentFolder.FK_User_ID = PK_Security_ID;
                assocFCDocumentFolder.Insert();
            }
        }
        else
        {
            foreach (ListItem item in lboxFCFolderSecurity.Items)
            {
                if (item.Selected)
                {
                    clsAssoc_LU_FC_Document_Folder_Rights assocFCDocumentFolder = new clsAssoc_LU_FC_Document_Folder_Rights();
                    assocFCDocumentFolder.FK_LU_FC_Document_Folder_Rights = Convert.ToDecimal(item.Value);
                    assocFCDocumentFolder.FK_User_ID = PK_Security_ID;
                    assocFCDocumentFolder.Insert();
                }
            }
        }
    }


    /// <summary>
    /// Add Items into Folder Security List
    /// </summary>
    private void BindDocumentFolderSecurity()
    {
        if (chkGroup.Items.FindByText("Administrative").Selected == true)
        {
            lstFolderSecurity.Items.Clear();
            lstFolderSecurity.Items.Add(new ListItem("All Folders", "0"));
            lstFolderSecurity.Items[0].Selected = true;
        }
        else
        {
            string[] strSelectedItems = new string[1000];
            int k = 0;
            strSelectedItems[0] = "";
            foreach (ListItem Li in lstFolderSecurity.Items)
            {
                if (Li.Selected)
                {
                    strSelectedItems[k] = Li.Value;
                    k++;
                }
            }

            lstFolderSecurity.Items.Clear();
            string strModule = "";
            foreach (ListItem lst in chkRights.Items)
            {
                if (lst.Selected)
                {
                    DataSet dsRights = Right.SelectByPK(Convert.ToInt32(lst.Value));
                    if (dsRights.Tables[0].Rows.Count > 0)
                    {
                        string strModuleID = dsRights.Tables[0].Rows[0]["Module_ID"].ToString();
                        if (!strModule.Contains("'" + strModuleID + "'"))
                        {
                            DataSet dsFolderSecurity = clsAttachment_Rights.SelectByModuleID(Convert.ToDecimal(strModuleID));
                            foreach (DataRow dr in dsFolderSecurity.Tables[0].Rows)
                            {
                                lstFolderSecurity.Items.Add(new ListItem(dr["Right_Name"].ToString(), dr["PK_Attachment_Rights"].ToString()));
                            }
                            strModule = strModule + "'" + strModuleID + "' ";
                        }
                    }
                }
            }

            foreach (ListItem Li in lstFolderSecurity.Items)
            {
                for (int i = 0; i < strSelectedItems.Length; i++)
                {
                    if (Li.Value == strSelectedItems[i])
                        Li.Selected = true;
                }
            }
        }
    }

    private void BindFCDocumentFolderSecurity()
    {
        if (chkGroup.Items.FindByText("Administrative").Selected == true)
        {
            lboxFCFolderSecurity.Items.Clear();
            lboxFCFolderSecurity.Items.Add(new ListItem("All Folders", "0"));
            lboxFCFolderSecurity.Items[0].Selected = true;
        }
        else
        {
            DataSet dsFCDocumentFolder = clsLU_FC_Document_Folder_Rights.SelectAll();
            lboxFCFolderSecurity.DataSource = dsFCDocumentFolder;
            lboxFCFolderSecurity.DataTextField = "Right_Name";
            lboxFCFolderSecurity.DataValueField = "PK_LU_FC_Document_Folder_Rights";
            lboxFCFolderSecurity.DataBind();
        }

    }

    private void FillFCDocumentFolderSecurity()
    {
        if (PK_Security_ID > 0)
        {
            if (chkGroup.Items.FindByText("Administrative").Selected != true)
            {
                DataTable dtFCDocumentFolder = clsAssoc_LU_FC_Document_Folder_Rights.SelectByUserId(PK_Security_ID).Tables[0];

                if (lboxFCFolderSecurity.Items.Count > 0)
                {
                    foreach (ListItem item in lboxFCFolderSecurity.Items)
                    {
                        for (int i = 0; i < dtFCDocumentFolder.Rows.Count; i++)
                        {
                            if (item.Value == Convert.ToString(dtFCDocumentFolder.Rows[i]["FK_LU_FC_Document_Folder_Rights"]) && PK_Security_ID == Convert.ToInt32(dtFCDocumentFolder.Rows[i]["FK_User_ID"]))
                            {
                                item.Selected = true;
                            }
                        }
                    }
                }
            }
        }
    }

    /////select Items from Folder Security List/////
    private void SelectDocumentFolderSecurity()
    {
        // clear previous selection
        lstFolderSecurity.ClearSelection();

        DataSet dsAssoc_Attachment_Rights = clsAssoc_Attachment_Rights.SelectByFK(PK_Security_ID);
        foreach (DataRow dr in dsAssoc_Attachment_Rights.Tables[0].Rows)
        {
            foreach (ListItem lst in lstFolderSecurity.Items)
            {
                if (lst.Value == dr["FK_Attachment_Right"].ToString())
                {
                    lst.Selected = true;
                }
            }
        }
    }

    ///select Items from Folder Security List/////

    private void SelectDocumentFolderSecurityView()
    {
        lstFolderSecurity.Items.Clear();
        string strModule = "";
        foreach (ListItem lst in chkRightsView.Items)
        {
            if (lst.Selected)
            {
                DataSet dsRights = Right.SelectByPK(Convert.ToInt32(lst.Value));
                if (dsRights.Tables[0].Rows.Count > 0)
                {
                    string strModuleID = dsRights.Tables[0].Rows[0]["Module_ID"].ToString(); //Assoc_User_Right.SelectModuleIDByAssocUserRightID(Convert.ToInt32(lst.Value)).ToString();
                    if (!strModule.Contains("'" + strModuleID + "'"))
                    {
                        DataSet dsFolderSecurity = clsAttachment_Rights.SelectByModuleID(Convert.ToDecimal(strModuleID));
                        foreach (DataRow dr in dsFolderSecurity.Tables[0].Rows)
                        {
                            lstFolderSecurity.Items.Add(new ListItem(dr["Right_Name"].ToString(), dr["PK_Attachment_Rights"].ToString()));
                        }
                        strModule = strModule + "'" + strModuleID + "' ";
                    }
                }
            }
        }
        DataSet dsAssoc_Attachment_Rights = clsAssoc_Attachment_Rights.SelectByFK(PK_Security_ID);
        foreach (DataRow dr in dsAssoc_Attachment_Rights.Tables[0].Rows)
        {
            foreach (ListItem lst in lstFolderSecurity.Items)
            {
                if (lst.Value == dr["FK_Attachment_Right"].ToString())
                {
                    lst.Selected = true;
                }
            }
        }
    }

    //private void SetUserRights(string strUserGroup)
    //{
    // DataSet dsGroupRight = Group.SelectByGroupName(strUserGroup);
    // for (int intI = 0; intI < dsGroupRight.Tables[0].Rows.Count; intI++)
    // {
    // //loop for Rights that that are Binded with CHeckboxlist
    // for (int intJ = 0; intJ < chkRights.Items.Count; intJ++)
    // {
    // //used to check the wthear the Rights in Checkbox list is equal to database value. if yes than selec that checkbox listItem else Uncheck.
    // if (chkRights.Items[intJ].Value.ToString() == dsGroupRight.Tables[0].Rows[intI]["FK_Right"].ToString())
    // {
    // chkRights.Items[intJ].Selected = true;
    // chkRights.Items[intJ].Enabled = false;
    // ListItem lstFindVal = lstInheritedRights.Items.FindByValue(chkRights.Items[intJ].Value.ToString());
    // if (lstFindVal == null)
    // {
    // lstInheritedRights.Items.Add(new ListItem(chkRights.Items[intJ].Text.ToString(), chkRights.Items[intJ].Value.ToString()));
    // }
    // }
    // }
    // }
    //}
    #endregion

    #region Grid Events
    /// <summary>
    /// Handles Row Created Event of Security Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSecurity_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != SortBy)
            {
                // update sort image beside the column header
                AddSortImage(e.Row);
            }
            else
            {
                // add sort image beside the column header
                Image sortImage = new Image();
                sortImage.ImageUrl = "~/Images/up-arrow.gif";
                sortImage.AlternateText = "Descending Order";
                e.Row.Cells[3].Controls.Add(sortImage);
            }
        }
    }

    /// <summary>
    /// Handles Sorting Event of Security Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSecurity_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
    }

    /// <summary>
    /// Handles Edit/View Row Command Event of Security Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSecurity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            divViewAdminList.Style.Add("display", "none");
            divModifyAdmin.Style.Add("display", "block");
            // Hide password controls while editing.
            System.Web.UI.HtmlControls.HtmlTableRow trpass = (System.Web.UI.HtmlControls.HtmlTableRow)DivEditSecuirty.FindControl("trPassword");
            trpass.Style.Add("display", "");
            PK_Security_ID = Convert.ToInt32(e.CommandArgument.ToString());
            EditRecord();
        }
        else if (e.CommandName == "View")
        {
            divViewAdminList.Style.Add("display", "none");
            divModifyAdmin.Style.Add("display", "block");
            PK_Security_ID = Convert.ToInt32(e.CommandArgument.ToString());
            ViewRecord();
        }
    }

    /// <summary>
    /// Handles Row Data Bound Event of Security Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSecurity_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check Data row type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblRole;
            lblRole = (Label)e.Row.FindControl("lblUserRole");
            //check label is not null
            if (lblRole != null)
            {
                //check label Role value if it is 1 than display Full Access
                //else if it is 2 than display View Only.
                if (lblRole.Text == "1")
                {
                    lblRole.Text = "Yes";
                }
                else if (lblRole.Text == "0")
                {
                    lblRole.Text = "No";
                }
            }

            decimal Pk = Convert.ToDecimal(gvSecurity.DataKeys[e.Row.RowIndex].Value);

            if (clsSession.IsUserRegionalOfficer)
            {
                if (Pk.ToString() != clsSession.UserID)
                {
                    string strRegions = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Region"));
                    DataTable dtOfficerRegions = Security.GetRegionalOfficerRegions(Convert.ToDecimal(clsSession.UserID)).Tables[0];

                    if (strRegions != "" && dtOfficerRegions.Rows.Count > 0)
                    {
                        int intMatched = 0;
                        string[] strUserRegions = strRegions.Split(',');
                        foreach (string strUserRegion in strUserRegions)
                        {
                            foreach (DataRow drOfficerRegion in dtOfficerRegions.Rows)
                            {
                                if (strUserRegion == Convert.ToString(drOfficerRegion["Region"]))
                                    intMatched++;
                            }
                        }
                        if (strUserRegions.Length > intMatched)
                        {
                            ((Button)e.Row.FindControl("btnEdit")).Enabled = false;
                        }
                        else
                            ((Button)e.Row.FindControl("btnEdit")).Enabled = true;
                    }
                    else
                        ((Button)e.Row.FindControl("btnEdit")).Enabled = false;
                }
            }
        }
    }
    #endregion

    #region Mover Events and Methods - FROI E-Mail Recipients
    /// <summary>
    /// Event to handle Select output fields
    /// </summary>
    protected void btnSelectFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstFROIeMailRecipients, lstSelectedFields, true, true, false);
    }

    /// <summary>
    /// Event to handle Deselect Fields
    /// </summary>
    protected void btnDeselectFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstSelectedFields, lstFROIeMailRecipients, true, false, true);
    }

    /// <summary>
    /// Event to Handle select All output fields.
    /// </summary>
    protected void btnSelectAllFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstFROIeMailRecipients, lstSelectedFields, false, true, false);
    }

    /// <summary>
    /// Event to handle DeSelect All Output Fields.
    /// </summary>
    protected void btnDeselectAllFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstSelectedFields, lstFROIeMailRecipients, false, false, true);
    }

    /// <summary>
    /// Move Output Fields from One List to Another List and add/Remove From Sort and group by DropDown
    /// </summary>
    /// <param name="lstFrom"></param>
    /// <param name="lstTo"></param>
    /// <param name="OnlySelected"></param>
    /// <param name="IsSelect"></param>
    private void MoveListBoxItems(ListBox lstFrom, ListBox lstTo, bool OnlySelected, bool IsSelect, bool bSort)
    {
        List<ListItem> lstSelected = new List<ListItem>();
        foreach (ListItem liSelcted in lstFrom.Items)
        {
            // If List item is selected then move it to Selected Output field list and add to list objects
            if ((OnlySelected && liSelcted.Selected) || (!OnlySelected))
            {
                liSelcted.Selected = false;
                lstTo.Items.Add(liSelcted);
                lstSelected.Add(liSelcted);
            }
        }

        // remove all selected list items from output fields
        for (int i = 0; i < lstSelected.Count; i++)
        {
            lstFrom.Items.Remove(lstSelected[i] as ListItem);
        }
        // sort FROI E-Mail Recipients Field
        if (bSort == true && lstFROIeMailRecipients.Items.Count > 0)
        {
            DataTable dtFields = new DataTable();
            dtFields.Columns.Add(new DataColumn("PK_LU_Location_ID", typeof(decimal)));
            dtFields.Columns.Add(new DataColumn("dba", typeof(string)));

            foreach (ListItem itmField in lstFROIeMailRecipients.Items)
            {
                DataRow drField = dtFields.NewRow();
                drField["PK_LU_Location_ID"] = itmField.Value;
                drField["dba"] = itmField.Text;
                dtFields.Rows.Add(drField);
            }
            dtFields.DefaultView.Sort = "dba ASC";
            lstFROIeMailRecipients.Items.Clear();
            lstFROIeMailRecipients.DataSource = dtFields.DefaultView;
            lstFROIeMailRecipients.DataTextField = "dba";
            lstFROIeMailRecipients.DataValueField = "PK_LU_Location_ID";
            lstFROIeMailRecipients.DataBind();
        }
        // If Selected output list is empty then Disable Moving buttons and Up-Down images
        if (lstSelectedFields.Items.Count <= 0)
        {
            btnDeselectFields.Enabled = false;
            btnDeselectAllFields.Enabled = false;//imgUp.Enabled = imgDown.Enabled = 
        }
        else
        {
            btnDeselectFields.Enabled = true;
            btnDeselectAllFields.Enabled = true;//imgUp.Enabled = imgDown.Enabled = 
        }
        // IF output Fields is Empty
        if (lstFROIeMailRecipients.Items.Count <= 0)
        {
            btnSelectFields.Enabled = false;
            btnSelectAllFields.Enabled = false;
        }
        else
        {
            btnSelectFields.Enabled = true;
            btnSelectAllFields.Enabled = true;
        }

        if (lstSecuritySelectedLocation.Items.Count <= 0)
        {
            btnDeSelectLocationFields.Enabled = false;
            btnDeSelectAllLocationFields.Enabled = false;//imgUp.Enabled = imgDown.Enabled = 
        }
        else
        {
            btnDeSelectLocationFields.Enabled = true;
            btnDeSelectAllLocationFields.Enabled = true;//imgUp.Enabled = imgDown.Enabled = 
        }
        // IF output Fields is Empty
        if (lstSecurityLocation.Items.Count <= 0)
        {
            btnSelectLocationFields.Enabled = false;
            btnSelectAllLocationFields.Enabled = false;
        }
        else
        {
            btnSelectLocationFields.Enabled = true;
            btnSelectAllLocationFields.Enabled = true;
        }

        if (lstSecurityEventSelectedLocation.Items.Count <= 0)
        {
            btnDeSelectEventLocationFields.Enabled = false;
            btnDeSelectAllEventLocationFields.Enabled = false;//imgUp.Enabled = imgDown.Enabled = 
        }
        else
        {
            btnDeSelectEventLocationFields.Enabled = true;
            btnDeSelectAllEventLocationFields.Enabled = true;//imgUp.Enabled = imgDown.Enabled = 
        }
        // IF output Fields is Empty
        if (lstEventSecurityLocation.Items.Count <= 0)
        {
            btnSelectEventLocationFields.Enabled = false;
            btnSelectAllEventLocationFields.Enabled = false;
        }
        else
        {
            btnSelectEventLocationFields.Enabled = true;
            btnSelectAllEventLocationFields.Enabled = true;
        }

        if (lstSecuritySelectedManagementLocation.Items.Count <= 0)
        {
            btnDeSelectManagementLocationFields.Enabled = false;
            btnDeSelectAllManagementLocationFields.Enabled = false;//imgUp.Enabled = imgDown.Enabled = 
        }
        else
        {
            btnDeSelectManagementLocationFields.Enabled = true;
            btnDeSelectAllManagementLocationFields.Enabled = true;//imgUp.Enabled = imgDown.Enabled = 
        }
        // IF output Fields is Empty
        if (lstManagementSecurityLocation.Items.Count <= 0)
        {
            btnSelectManagementLocationFields.Enabled = false;
            btnSelectAllManagementLocationFields.Enabled = false;
        }
        else
        {
            btnSelectManagementLocationFields.Enabled = true;
            btnSelectAllManagementLocationFields.Enabled = true;
        }
    }

    /// <summary>
    /// Bind FROI E-Mail Recipients List
    /// </summary>
    private void BindFROIeMailRecipients(bool _EditFlag, Nullable<decimal> _Employee_Id)
    {
        //clear list box
        lstFROIeMailRecipients.Items.Clear();
        lstSelectedFields.Items.Clear();

        //Assign Values to CurrentEmployee and Regional
        Nullable<decimal> CurrentEmployee;
        if (_Employee_Id != null)
            CurrentEmployee = _Employee_Id;
        else
            if (rdoIsSonicEmployee.SelectedIndex >= 0) if (Convert.ToInt32(rdoIsSonicEmployee.SelectedValue) > 0) CurrentEmployee = new Security(PK_Security_ID).Employee_Id; else CurrentEmployee = 0;
            else CurrentEmployee = 0;
        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(PK_Security_ID);
        if (dsRegion.Tables[0].Rows.Count > 0)
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows) Regional += drRegion["Region"].ToString() + ",";
        else
            Regional = string.Empty;

        //Get all Locations as per CurrentEmployee and Regional
        DataSet dsData = LU_Location.SelectAll(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(",")));
        dsData.Tables[0].DefaultView.Sort = "dba asc";
        // Bind List lstFROIeMailRecipients
        lstFROIeMailRecipients.DataSource = dsData.Tables[0].DefaultView;
        lstFROIeMailRecipients.DataTextField = "dba";
        lstFROIeMailRecipients.DataValueField = "PK_LU_Location_ID";
        lstFROIeMailRecipients.DataBind();
        //if opened in Edit mode, Move Selected data to right (From lstFROIeMailRecipients to lstSelectedFields)
        if (_EditFlag)
        {
            DataSet dsSelectedData = clsFROI_EMail_Recipients.SelectByUser(PK_Security_ID);
            foreach (DataRow dr in dsSelectedData.Tables[0].Rows)
            {                
                if (lstFROIeMailRecipients.Items.FindByValue(dr["FK_LU_Location_ID"].ToString().Trim()) != null)
                {
                    // 3315 : Sonic - Security FROI Recipients Issue : Solved Issue of Left side items are not removed from list
                    int index = lstFROIeMailRecipients.Items.IndexOf(lstFROIeMailRecipients.Items.FindByValue(dr["FK_LU_Location_ID"].ToString().Trim()));
                    lstFROIeMailRecipients.Items.RemoveAt(index);
                    // lstFROIeMailRecipients.Items.Remove(new ListItem(dr["dba"].ToString(), dr["FK_LU_Location_ID"].ToString()));
                    lstSelectedFields.Items.Add(new ListItem(dr["dba"].ToString(), dr["FK_LU_Location_ID"].ToString()));
                }
            }
        }
        //Enable/Disable buttons
        btnDeselectFields.Enabled = btnDeselectAllFields.Enabled = lstSelectedFields.Items.Count > 0; //imgUp.Enabled = imgDown.Enabled = 
        btnSelectAllFields.Enabled = btnSelectFields.Enabled = lstFROIeMailRecipients.Items.Count > 0;
        clsGeneral.SetListBoxToolTip(new ListBox[] { lstFROIeMailRecipients, lstSelectedFields });
    }

    /// <summary>
    /// Bind FROI E-Mail Recipients List
    /// </summary>
    private void BindFROIeMailRecipientsView()
    {
        lstSelectedFieldsView.Items.Clear();
        //Move Selected data to right (From lstFROIeMailRecipients to lstSelectedFields)
        DataSet dsSelectedData = clsFROI_EMail_Recipients.SelectByUser(PK_Security_ID);
        foreach (DataRow dr in dsSelectedData.Tables[0].Rows)
            lstSelectedFieldsView.Items.Add(new ListItem(dr["dba"].ToString(), dr["FK_LU_Location_ID"].ToString()));
        clsGeneral.SetListBoxToolTip(new ListBox[] { lstSelectedFieldsView });
    }

    /// <summary>
    /// Handles changes of Location Lists when Employee name changes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAssName_OnClick(object sender, EventArgs e)
    {
        BindFROIeMailRecipients(true, Convert.ToInt32(HdnEmployeeID.Value));
        tdEmployee.Style["display"] = "";
        tdRigionalOfficer.Style["display"] = "";
        lnkAssName.InnerText = HdnEmployeeName.Value;
    }

    /// <summary>
    /// Radio button IsSonicEmployee Value change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rdoIsSonicEmployee_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(rdoIsSonicEmployee.SelectedValue) > 0)
        {
            if (HdnEmployeeID.Value != "")
                BindFROIeMailRecipients(true, Convert.ToInt32(HdnEmployeeID.Value));
            tdEmployee.Style["display"] = "";
            tdRigionalOfficer.Style["display"] = "";
            HdnEmployeeID.Value = "";
            HdnEmployeeName.Value = "";
            lnkAssName.InnerText = "Associate Name";
        }
        else
        {
            BindFROIeMailRecipients(true, null);
            tdEmployee.Style["display"] = "none";
            tdRigionalOfficer.Style["display"] = "none";
            HdnEmployeeID.Value = "";
            HdnEmployeeName.Value = "";
            lnkAssName.InnerText = "Associate Name";
        }
    }

    #endregion

    #region Security Location Selection Events and Methods
    protected void btnSelectLocationFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstSecurityLocation, lstSecuritySelectedLocation, true, true, false);
    }
    
    /// <summary>
    /// Event to handle Deselect Fields
    /// </summary>
    protected void btnDeSelectLocationFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstSecuritySelectedLocation, lstSecurityLocation, true, false, true);
    }

    /// <summary>
    /// Event to Handle select All output fields.
    /// </summary>
    protected void btnSelectAllLocationFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstSecurityLocation, lstSecuritySelectedLocation, false, true, false);
    }

    /// <summary>
    /// Event to handle DeSelect All Output Fields.
    /// </summary>
    protected void btnDeSelectAllLocationFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstSecuritySelectedLocation, lstSecurityLocation, false, false, true);
    }

    //private void BindSecurityACI_LocationList(bool _EditFlag, Nullable<decimal> _Employee_Id)
    //{
    //    //clear list box
    //    lstSecurityLocation.Items.Clear();
    //    lstSecuritySelectedLocation.Items.Clear();


    //    //Get all Locations 
    //    DataSet dsData = clsAci_Lu_Location.SelectAll();
    //    dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
    //    dsData.Tables[0].DefaultView.Sort = "Fld_Desc asc";
    //    // Bind List lstSecurityLocation
    //    lstSecurityLocation.DataSource = dsData.Tables[0].DefaultView;
    //    lstSecurityLocation.DataTextField = "Fld_Desc";
    //    lstSecurityLocation.DataValueField = "PK_ACI_LU_Location";
    //    lstSecurityLocation.DataBind();
    //    //if opened in Edit mode, Move Selected data to right (From lstSecurityLocation to lstSecuritySelectedLocation)
    //    if (_EditFlag)
    //    {
    //        DataSet dsSelectedData = clsSecurity_ACI_LU_Location.SelectByUser(PK_Security_ID, true);
    //        foreach (DataRow dr in dsSelectedData.Tables[0].Rows)
    //        {
    //            if (dr["FK_ACI_LU_Location_ID"] != null)
    //            {
    //                if (lstSecurityLocation.Items.FindByValue(dr["FK_ACI_LU_Location_ID"].ToString().Trim()) != null)
    //                {
    //                    lstSecurityLocation.Items.Remove(new ListItem(dr["Fld_Desc"].ToString().Trim(), dr["FK_ACI_LU_Location_ID"].ToString().Trim()));
    //                    lstSecuritySelectedLocation.Items.Add(new ListItem(dr["Fld_Desc"].ToString().Trim(), dr["FK_ACI_LU_Location_ID"].ToString().Trim()));
    //                }
    //            }
    //        }
    //        //Enable/Disable buttons
    //        btnDeSelectLocationFields.Enabled = btnDeSelectAllLocationFields.Enabled = lstSecuritySelectedLocation.Items.Count > 0; //imgUp.Enabled = imgDown.Enabled = 
    //        btnSelectLocationFields.Enabled = btnSelectAllLocationFields.Enabled = lstSecurityLocation.Items.Count > 0;
    //        clsGeneral.SetListBoxToolTip(new ListBox[] { lstSecurityLocation, lstSecuritySelectedLocation });
    //    }
    //}

    //private void BindSecurityLocationView()
    //{
    //    lstSelectedLocationView.Items.Clear();
    //    //Move Selected data to right (From lstFROIeMailRecipients to lstSelectedFields)
    //    DataSet dsSelectedData = clsSecurity_ACI_LU_Location.SelectByUser(PK_Security_ID, true);
    //    foreach (DataRow dr in dsSelectedData.Tables[0].Rows)
    //        lstSelectedLocationView.Items.Add(new ListItem(dr["Fld_Desc"].ToString(), dr["FK_ACI_LU_Location_ID"].ToString()));
    //    clsGeneral.SetListBoxToolTip(new ListBox[] { lstSelectedFieldsView });
    //}

    private void BindSecurityACI_LocationList(bool _EditFlag, Nullable<decimal> _Employee_Id)
    {
        //clear list box
        lstSecurityLocation.Items.Clear();
        lstSecuritySelectedLocation.Items.Clear();


        //Get all Locations 
        DataSet dsData = LU_Location.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        dsData.Tables[0].DefaultView.Sort = "dba asc";
        // Bind List lstSecurityLocation
        lstSecurityLocation.DataSource = dsData.Tables[0].DefaultView;
        lstSecurityLocation.DataTextField = "dba";
        lstSecurityLocation.DataValueField = "PK_LU_Location_ID";
        lstSecurityLocation.DataBind();
        //if opened in Edit mode, Move Selected data to right (From lstSecurityLocation to lstSecuritySelectedLocation)
        if (_EditFlag)
        {
            DataSet dsSelectedData = clsSecurity_ACI_LU_Location_Link.SelectByUser(PK_Security_ID, true);
            foreach (DataRow dr in dsSelectedData.Tables[0].Rows)
            {
                if (dr["FK_LU_Location_ID"] != null)
                {
                    if (lstSecurityLocation.Items.FindByValue(dr["FK_LU_Location_ID"].ToString().Trim()) != null)
                    {
                        lstSecurityLocation.Items.Remove(new ListItem(dr["dba"].ToString(), dr["FK_LU_Location_ID"].ToString()));
                        lstSecuritySelectedLocation.Items.Add(new ListItem(dr["dba"].ToString(), dr["FK_LU_Location_ID"].ToString()));
                    }
                }
            }
        }

        //Enable/Disable buttons
        btnDeSelectLocationFields.Enabled = btnDeSelectAllLocationFields.Enabled = lstSecuritySelectedLocation.Items.Count > 0; //imgUp.Enabled = imgDown.Enabled = 
        btnSelectLocationFields.Enabled = btnSelectAllLocationFields.Enabled = lstSecurityLocation.Items.Count > 0;
        clsGeneral.SetListBoxToolTip(new ListBox[] { lstSecurityLocation, lstSecuritySelectedLocation });
    }

    private void BindSecurityLocationView()
    {
        lstSelectedLocationView.Items.Clear();
        //Move Selected data to right (From lstFROIeMailRecipients to lstSelectedFields)
        DataSet dsSelectedData = clsSecurity_ACI_LU_Location_Link.SelectByUser(PK_Security_ID, true);
        foreach (DataRow dr in dsSelectedData.Tables[0].Rows)
            lstSelectedLocationView.Items.Add(new ListItem(dr["dba"].ToString(), dr["FK_LU_Location_ID"].ToString()));
        clsGeneral.SetListBoxToolTip(new ListBox[] { lstSelectedFieldsView });
    }

    #endregion

    #region Event Security Location Events and Methods

    protected void btnSelectEventLocationFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstEventSecurityLocation, lstSecurityEventSelectedLocation, true, true, false);
    }

    /// <summary>
    /// Event to handle Deselect Fields
    /// </summary>
    protected void btnDeSelectEventLocationFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstSecurityEventSelectedLocation, lstEventSecurityLocation, true, false, true);
    }

    /// <summary>
    /// Event to Handle select All output fields.
    /// </summary>
    protected void btnSelectAllEventLocationFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstEventSecurityLocation, lstSecurityEventSelectedLocation, false, true, false);
    }

    /// <summary>
    /// Event to handle DeSelect All Output Fields.
    /// </summary>
    protected void btnDeSelectAllEventLocationFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstSecurityEventSelectedLocation, lstEventSecurityLocation, false, false, true);
    }

    private void BindEventSecurity_LocationList(bool _EditFlag, Nullable<decimal> _Employee_Id)
    {
        //clear list box
        lstEventSecurityLocation.Items.Clear();
        lstSecurityEventSelectedLocation.Items.Clear();


        //Get all Locations 
        DataSet dsData = LU_Location.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        dsData.Tables[0].DefaultView.Sort = "dba asc";
        // Bind List lstEventSecurityLocation
        lstEventSecurityLocation.DataSource = dsData.Tables[0].DefaultView;
        lstEventSecurityLocation.DataTextField = "dba";
        lstEventSecurityLocation.DataValueField = "PK_LU_Location_ID";
        lstEventSecurityLocation.DataBind();
        //if opened in Edit mode, Move Selected data to right (From lstEventSecurityLocation to lstSecurityEventSelectedLocation)
        if (_EditFlag)
        {
            DataSet dsSelectedData = clsEvent_Email_Recipients.SelectByUser(PK_Security_ID);
            foreach (DataRow dr in dsSelectedData.Tables[0].Rows)
            {
                if (dr["FK_LU_Location_ID"] != null)
                {
                    if (lstEventSecurityLocation.Items.FindByValue(dr["FK_LU_Location_ID"].ToString().Trim()) != null)
                    {
                        lstEventSecurityLocation.Items.Remove(new ListItem(dr["dba"].ToString(), dr["FK_LU_Location_ID"].ToString()));
                        lstSecurityEventSelectedLocation.Items.Add(new ListItem(dr["dba"].ToString(), dr["FK_LU_Location_ID"].ToString()));
                    }
                }
            }
        }

        //Enable/Disable buttons
        btnDeSelectEventLocationFields.Enabled = btnDeSelectAllEventLocationFields.Enabled = lstSecurityEventSelectedLocation.Items.Count > 0; //imgUp.Enabled = imgDown.Enabled = 
        btnSelectEventLocationFields.Enabled = btnSelectAllEventLocationFields.Enabled = lstEventSecurityLocation.Items.Count > 0;
        clsGeneral.SetListBoxToolTip(new ListBox[] { lstEventSecurityLocation, lstSecurityEventSelectedLocation });
    }

    private void BindEventSecurityLocationView()
    {
        lstEventSelectedLocationView.Items.Clear();
        //Move Selected data to right (From lstFROIeMailRecipients to lstSelectedFields)
        DataSet dsSelectedData = clsEvent_Email_Recipients.SelectByUser(PK_Security_ID);
        foreach (DataRow dr in dsSelectedData.Tables[0].Rows)
            lstEventSelectedLocationView.Items.Add(new ListItem(dr["dba"].ToString(), dr["FK_LU_Location_ID"].ToString()));
        clsGeneral.SetListBoxToolTip(new ListBox[] { lstEventSelectedLocationView });
    }

    #endregion

    #region Management Security Location Events and Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSelectManagementLocationFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstManagementSecurityLocation, lstSecuritySelectedManagementLocation, true, true, false);
    }

    /// <summary>
    /// Event to handle Deselect Fields
    /// </summary>
    protected void btnDeSelectManagementLocationFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstSecuritySelectedManagementLocation, lstManagementSecurityLocation, true, false, true);
    }

    /// <summary>
    /// Event to Handle select All output fields.
    /// </summary>
    protected void btnSelectAllManagementLocationFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstManagementSecurityLocation, lstSecuritySelectedManagementLocation, false, true, false);
    }

    /// <summary>
    /// Event to handle DeSelect All Output Fields.
    /// </summary>
    protected void btnDeSelectAllManagementLocationFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstSecuritySelectedManagementLocation, lstManagementSecurityLocation, false, false, true);
    }

    private void BindManagementSecurity_LocationList(bool _EditFlag, Nullable<decimal> _Employee_Id)
    {
        //clear list box
        lstManagementSecurityLocation.Items.Clear();
        lstSecuritySelectedManagementLocation.Items.Clear();


        //Get all Locations 
        DataSet dsData = LU_Location.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        dsData.Tables[0].DefaultView.Sort = "dba asc";
        // Bind List lstEventSecurityLocation
        lstManagementSecurityLocation.DataSource = dsData.Tables[0].DefaultView;
        lstManagementSecurityLocation.DataTextField = "dba";
        lstManagementSecurityLocation.DataValueField = "PK_LU_Location_ID";
        lstManagementSecurityLocation.DataBind();
        //if opened in Edit mode, Move Selected data to right (From lstManagementSecurityLocation to lstSecuritySelectedManagementLocation)
        if (_EditFlag)
        {
            DataSet dsSelectedData = clsManagement_Email_Recipients.SelectByUser(PK_Security_ID);
            foreach (DataRow dr in dsSelectedData.Tables[0].Rows)
            {
                if (dr["FK_LU_Location_ID"] != null)
                {
                    if (lstManagementSecurityLocation.Items.FindByValue(dr["FK_LU_Location_ID"].ToString().Trim()) != null)
                    {
                        lstManagementSecurityLocation.Items.Remove(new ListItem(dr["dba"].ToString(), dr["FK_LU_Location_ID"].ToString()));
                        lstSecuritySelectedManagementLocation.Items.Add(new ListItem(dr["dba"].ToString(), dr["FK_LU_Location_ID"].ToString()));
                    }
                }
            }
        }

        //Enable/Disable buttons
        btnDeSelectManagementLocationFields.Enabled = btnDeSelectAllManagementLocationFields.Enabled = lstSecuritySelectedManagementLocation.Items.Count > 0; //imgUp.Enabled = imgDown.Enabled = 
        btnSelectManagementLocationFields.Enabled = btnSelectAllManagementLocationFields.Enabled = lstManagementSecurityLocation.Items.Count > 0;
        clsGeneral.SetListBoxToolTip(new ListBox[] { lstManagementSecurityLocation, lstSecuritySelectedManagementLocation });
    }

    private void BindManagementSecurityLocationView()
    {
        lstManagementSelectedLocationView.Items.Clear();
        //Move Selected data to right (From lstFROIeMailRecipients to lstSelectedFields)
        DataSet dsSelectedData = clsManagement_Email_Recipients.SelectByUser(PK_Security_ID);
        foreach (DataRow dr in dsSelectedData.Tables[0].Rows)
            lstManagementSelectedLocationView.Items.Add(new ListItem(dr["dba"].ToString(), dr["FK_LU_Location_ID"].ToString()));
        clsGeneral.SetListBoxToolTip(new ListBox[] { lstManagementSelectedLocationView });
    }

    #endregion

}