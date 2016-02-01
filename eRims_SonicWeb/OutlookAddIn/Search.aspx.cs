using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
using System.Web.UI.HtmlControls;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

public partial class OutlookAddIn_Search : System.Web.UI.Page
{
    public DataTable dtFolder = null;

    #region " Properties "

    bool bAttachType = false;
    bool bFolder = false;
    private string _Table_Name;
    private decimal? _FK_Field_Value;

    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string _SortBy
    {
        get { return (!clsGeneral.IsNull(ViewState["SortBy"]) ? ViewState["SortBy"].ToString() : string.Empty); }
        set { ViewState["SortBy"] = value; }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string _SortOrder
    {
        get { return (!clsGeneral.IsNull(ViewState["SortOrder"]) ? ViewState["SortOrder"].ToString() : string.Empty); }
        set { ViewState["SortOrder"] = value; }
    }

    public string VWFilePath
    {
        get
        {
            return clsSession.AttachFilePath;
        }
        set { clsSession.AttachFilePath = value; }
    }

    public DataTable dtMailAttachList
    {
        get { return ViewState["dtMailAttachList"] != null ? (DataTable)ViewState["dtMailAttachList"] : null; }
        set { ViewState["dtMailAttachList"] = value; }
    }

    /// <summary>
    /// Gets or sets the FK_Field_Value value.
    /// </summary>
    public string Table_Name
    {
        get { return _Table_Name; }
        set { _Table_Name = value; }
    }

    /// <summary>
    /// Gets or sets the FK_Field_Value value.
    /// </summary>
    public decimal? FK_Field_Value
    {
        get { return _FK_Field_Value; }
        set { _FK_Field_Value = value; }
    }

    #endregion

    #region " Page Events "

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (HttpContext.Current.Request.IsSecureConnection)
            //{
            //    Response.Redirect(HttpContext.Current.Request.Url.ToString().Replace("https://", "http://"));
            //}
            if (Session["dtKeyData"] != null)
                Session["dtKeyData"] = null;
            // get the mail storage path from querystring
            if (Request.QueryString["fpath"] != null)
                VWFilePath = Encryption.Decrypt(Request.QueryString["fpath"]);

            if (Request.QueryString["fsub"] != null)
                clsSession.OutlookMailSubjects = Encryption.Decrypt(Request.QueryString["fsub"]);

            if (Request.QueryString["fatt"] != null)
                clsSession.OutlookMailAttachmentNames = Encryption.Decrypt(Request.QueryString["fatt"]);

            if (Request.QueryString["uid"] != null && Request.QueryString["pass"] != null)
            {
                // Validate User Name and Password
                DataSet dsUser = ERIMS.DAL.Security.GetLoginData(Encryption.Decrypt(Request.QueryString["uid"]), Request.QueryString["pass"]);
                if (dsUser.Tables[0].Rows.Count > 0)
                {
                    DataRow drUser = dsUser.Tables[0].Rows[0];
                    clsSession.UserID = Convert.ToString(drUser["PK_Security_ID"]).Trim();
                    clsSession.FirstName = Convert.ToString(drUser["FIRST_NAME"]).Trim();
                    clsSession.LastName = Convert.ToString(drUser["LAST_NAME"]).Trim();
                    clsSession.UserName = Convert.ToString(drUser["USER_NAME"]).Trim();
                    clsSession.UserRole = Convert.ToString(drUser["USER_ROLE"]).Trim();
                    clsSession.Email = Convert.ToString(drUser["Email"]).Trim();
                    //clsSession.NumberOfSearchRows = (drUser["NumberOfSearchRows"] == DBNull.Value ? 25 : Convert.ToInt32(drUser["NumberOfSearchRows"]));
                    //clsSession.DropDownBindOrder = (drUser["IsLUByCode"] == DBNull.Value ? 1 : Convert.ToInt32(drUser["IsLUByCode"])); //0-For Description-Code and 1-For Code-Description -fill dropdown  (set based on user prefernce saved in DB)

                }
            }

            #region " Get Email / Attachment filenames into Data table "
            DataTable dtMailAttachments = new DataTable();
            dtMailAttachments.Columns.Add(new DataColumn("EmailFileName", typeof(string)));
            dtMailAttachments.Columns.Add(new DataColumn("AttachmentFileName", typeof(string)));

            if (!string.IsNullOrEmpty(clsSession.OutlookMailAttachmentNames))
            {
                string[] strFileList = clsSession.OutlookMailAttachmentNames.Split(new string[] { "$$$$" }, StringSplitOptions.None);
                foreach (string strFiles in strFileList)
                {
                    string[] strFileNames = strFiles.Split('?');
                    string strEmailFileName = strFileNames[0];
                    if (!string.IsNullOrEmpty(strFileNames[1]))
                    {
                        string[] strAttachments = strFileNames[1].Split('/');
                        if (strAttachments.Length > 0)
                        {
                            foreach (string strAttachmentName in strAttachments)
                            {
                                DataRow dr = dtMailAttachments.NewRow();
                                dr["EmailFileName"] = strEmailFileName;
                                dr["AttachmentFileName"] = strAttachmentName;
                                dtMailAttachments.Rows.Add(dr);
                            }
                        }
                    }
                }
            }

            dtMailAttachList = dtMailAttachments;
            #endregion

            #region " Exposure Search Screen "

            ComboHelper.FillLocationdba(new DropDownList[] { ddlRMLocationNumber }, 0, true, true);//used to fill RM Location Number Dropdown
            ddlRMLocationNumber.Style.Remove("font-size");
            //ComboHelper.FillLocationLegal_Entity(new DropDownList[] { ddlLegalEntity }, 0, true, true); //used to fill Legal Entity Dropdown
            ComboHelper.FillLocationdbaOnly(new DropDownList[] { ddlLocationdba }, 0, true, true);//used to fill dba Dropdown
            ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, 0, true);//used to fill fka dropdown

            //// binds State dropdown in Property COPE panel
            DataTable dtState = State.SelectAll().Tables[0];
            drpMainState.DataSource = dtState;
            drpMainState.DataValueField = "FLD_state";
            drpMainState.DataTextField = "FLD_state";
            drpMainState.DataBind();
            drpMainState.Items.Insert(0, new ListItem("--Select--", ""));

            drpBuildingState.DataSource = dtState;
            drpBuildingState.DataValueField = "FLD_state";
            drpBuildingState.DataTextField = "FLD_state";
            drpBuildingState.DataBind();
            drpBuildingState.Items.Insert(0, new ListItem("--Select--", ""));
            #endregion

            pnlSearch.Visible = true;
            pnlSearchResult.Visible = false;
            pnlAttachment.Visible = false;

            _SortBy = "Sonic_Location_Code";
            _SortOrder = "asc";
        }

        if (string.IsNullOrEmpty(clsSession.UserID))
            Response.Redirect("Error.aspx");
    }
    #endregion

    #region " Control Events "

    /// <summary>
    /// Handles event when RM location number dropdown selection changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlRMLocationNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to RM location number selected
        //ddlLegalEntity.SelectedValue = ddlRMLocationNumber.SelectedValue;
        ddlLocationdba.SelectedValue = ddlRMLocationNumber.SelectedValue;
        ListItem lstItm = ddlLocationfka.Items.FindByValue(ddlRMLocationNumber.SelectedValue);
        if (lstItm != null)
            ddlLocationfka.SelectedValue = ddlRMLocationNumber.SelectedValue;
        else
            ddlLocationfka.SelectedValue = "0";
    }

    /// <summary>
    /// Handles event when Legal entity dropdown selection changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void ddlLegalEntity_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    // update all other dropdown according to entity selected
    //    ddlRMLocationNumber.SelectedValue = ddlLegalEntity.SelectedValue;
    //    ddlLocationdba.SelectedValue = ddlLegalEntity.SelectedValue;
    //    ListItem lstItm = ddlLocationfka.Items.FindByValue(ddlLegalEntity.SelectedValue);
    //    if (lstItm != null)
    //        ddlLocationfka.SelectedValue = ddlLegalEntity.SelectedValue;
    //    else
    //        ddlLocationfka.SelectedValue = "0";
    //}

    /// <summary>
    /// Handles event when dba dropdown selection changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlLocationdba_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to dba selected
        ddlRMLocationNumber.SelectedValue = ddlLocationdba.SelectedValue;
        //ddlLegalEntity.SelectedValue = ddlLocationdba.SelectedValue;
        ListItem lstItm = ddlLocationfka.Items.FindByValue(ddlLocationdba.SelectedValue);
        if (lstItm != null)
            ddlLocationfka.SelectedValue = ddlLocationdba.SelectedValue;
        else
            ddlLocationfka.SelectedValue = "0";
    }

    /// <summary>
    /// Handles event when fka dropdown selection changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlLocationfka_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to fka selected
        if (ddlLocationfka.SelectedValue != "0")
        {
            ListItem lstItm;
            lstItm = ddlRMLocationNumber.Items.FindByValue(ddlLocationfka.SelectedValue);
            ddlRMLocationNumber.SelectedValue = (lstItm != null) ? ddlLocationfka.SelectedValue : "0";
            //lstItm = ddlLegalEntity.Items.FindByValue(ddlLocationfka.SelectedValue);
            //ddlLegalEntity.SelectedValue = (lstItm != null) ? ddlLocationfka.SelectedValue : "0";
            lstItm = ddlLocationdba.Items.FindByValue(ddlLocationfka.SelectedValue);
            ddlLocationdba.SelectedValue = (lstItm != null) ? ddlLocationfka.SelectedValue : "0";
        }
        else
        {
            ddlLocationdba.SelectedValue = "0";
            //ddlLegalEntity.SelectedValue = "0";
            ddlRMLocationNumber.SelectedValue = "0";
        }
    }

    /// <summary>
    /// Handles Search button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        pnlSearch.Visible = false;
        pnlSearchResult.Visible = true;
        BindGrid(1, 10);

    }

    /// <summary>
    /// Handles Search Again button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearchAgain_Click(object sender, EventArgs e)
    {
        if (Session["dtKeyData"] != null)
            Session["dtKeyData"] = null;
        pnlSearch.Visible = true;
        pnlSearchResult.Visible = false;
    }

    /// <summary>
    /// Handles Submit button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        pnlSearch.Visible = false;
        pnlSearchResult.Visible = false;
        pnlAttachment.Visible = true;//show here third  panel that contain attachment
        MaintainCheckBoxValuesAfter();
        BindAttachmentGrid();
    }

    /// <summary>
    /// Handles Submit button click of attachment screen
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAttachmentSubmit_Click(object sender, EventArgs e)
    {
        //DataTable dtProcessed = new DataTable();
        //dtProcessed.Columns.Add("strOldFileName", typeof(string));
        //dtProcessed.Columns.Add("strPhyFileName", typeof(string));
        //dtProcessed.Columns.Add("strNewFilePath", typeof(string));
        //dtProcessed.Columns.Add("strNewFolderName", typeof(string));
        //dtProcessed.Columns.Add("strID", typeof(string));
        //dtProcessed.Columns.Add("FK_Virtual_Folder", typeof(string));
        //dtProcessed.Columns.Add("Attachment_Name", typeof(string));
        //dtProcessed.Columns.Add("Attachment_Description", typeof(string));
        //dtProcessed.Columns.Add("Description", typeof(string));


        int i = 1;
        try
        {
            foreach (GridViewRow gRow in gvAttachments.Rows)
            {
                bool bChecked = ((CheckBox)gRow.FindControl("chkSelectSingle")).Checked;
                if (bChecked)
                {
                    string strID = ((HtmlInputHidden)gRow.FindControl("hdnID")).Value;
                    string strPhyFileName = ((HtmlInputHidden)gRow.FindControl("hdnFileName")).Value;
                    string strOldFileName = ((LinkButton)gRow.FindControl("lnkDocName")).Text;
                    string strOldFolder = ((HtmlInputHidden)gRow.FindControl("hdnOldFolder")).Value;
                    string strNewFileName = ((TextBox)gRow.FindControl("txtRename")).Text.Trim();
                    DropDownList drpFolder = (DropDownList)gRow.FindControl("drpFolder");

                    string strFileName = strPhyFileName;//old file name if it is change than it take new file name

                    DropDownList drpAttachType = (DropDownList)gRow.FindControl("drpAttachType");

                    string strNewFolder = string.Empty;
                    string strNewFolderName = string.Empty;
                    if (drpFolder.SelectedIndex > 0)
                    {
                        strNewFolder = ((DropDownList)gRow.FindControl("drpFolder")).SelectedValue;
                        strNewFolderName = ((DropDownList)gRow.FindControl("drpFolder")).SelectedItem.Text;
                    }
                    string strType = ((HtmlInputHidden)gRow.FindControl("hdnType")).Value;
                    string strAttachDesc = ((TextBox)gRow.FindControl("txtAttachDesc")).Text;
                    if (strNewFileName != "")
                    {
                        string strOldExtenstion = strPhyFileName.Substring(strPhyFileName.LastIndexOf("."));

                        if (!strNewFileName.EndsWith(strOldExtenstion))
                        {
                            if (strNewFileName.IndexOf(".") > 0)
                            {
                                string strNewExt = strNewFileName.Substring(strNewFileName.LastIndexOf("."));
                                strNewFileName = strNewFileName.Replace(strNewExt, "");
                            }
                            strNewFileName = string.Concat(strNewFileName, strOldExtenstion);
                        }
                    }

                    bool bFileNameChange = (strNewFileName != "" && strNewFileName != strOldFileName);
                    bool bFolderChange = (strNewFolder != strOldFolder);
                    bool bUpload = strType == "Mail";

                    if (bFileNameChange || bFolderChange || bUpload)
                    {
                        string strOldFilePath = "", strNewFilePath = "", strUploadFileName = "";

                        strOldFilePath = AppConfig.DocumentsPath + "OutlookAttachments\\" + clsSession.AttachFilePath + "\\" + strPhyFileName;
                        if (bFileNameChange)
                        {
                            strUploadFileName = DateTime.Now.ToString("MMddyyhhmmss") + strNewFileName;
                            strFileName = strUploadFileName;
                            strNewFilePath = GetNewFilePath(ref strUploadFileName, i);
                        }
                        else
                        {
                            strNewFilePath = GetNewFilePath(ref strPhyFileName, i);
                        }

                        // keep track of processed files to be used later for inserting attachment record in DB
                        //DataRow drProcessed = dtProcessed.NewRow();
                        //drProcessed["strOldFileName"] = strOldFileName;
                        //drProcessed["strPhyFileName"] = strPhyFileName;
                        //drProcessed["strNewFilePath"] = strNewFilePath;
                        //drProcessed["strNewFolderName"] = strNewFolderName;
                        //drProcessed["strID"] = strID;
                        //drProcessed["FK_Virtual_Folder"] = (strNewFolder != "") ? Convert.ToDecimal(strNewFolder) : (strOldFolder != "") ? Convert.ToDecimal(strOldFolder) : 0;
                        //drProcessed["Attachment_Name"] = bFileNameChange ? strUploadFileName : strPhyFileName;
                        //drProcessed["Attachment_Description"] = bFileNameChange ? strNewFileName : strOldFileName;
                        //if (!string.IsNullOrEmpty(strAttachDesc))
                        //    drProcessed["Description"] = strAttachDesc;
                        //else
                        //{
                        //    if (strOldFileName.ToLower().EndsWith(".msg"))
                        //        drProcessed["Description"] = GetAttachmentDescription(strAttachDesc, strPhyFileName);
                        //}
                        //dtProcessed.Rows.Add(drProcessed);

                        #region " Insert Attachment "

                        //File.Copy(strOldFilePath, strNewFilePath, false);

                        DataTable dtKeyData = (DataTable)Session["dtKeyData"];
                        foreach (DataRow gvKeyDataRow in dtKeyData.Rows)
                        {

                            //dtKeyData.Columns.Add("ID");
                            //dtKeyData.Columns.Add("Module");
                            //dtKeyData.Columns.Add("Screen");
                            //dtKeyData.Columns.Add("Key_Data");
                            //dtKeyData.Columns.Add("Fk_FldName");
                            //dtKeyData.Columns.Add("Fk_FldValue");
                            //dtKeyData.Columns.Add("PK_Building_ID");
                            if (true)
                            {
                                string strModule = gvKeyDataRow["Module"].ToString();
                                string strScreen = gvKeyDataRow["Screen"].ToString();
                                string strKeyData = gvKeyDataRow["Key_Data"].ToString();
                                string strFk_Fld_Name = gvKeyDataRow["Fk_FldName"].ToString();
                                string strFk_Fld_Value = gvKeyDataRow["Fk_FldValue"].ToString();
                                string strPK_Building_ID = gvKeyDataRow["PK_Building_ID"].ToString();

                                if (strModule == "Environmental Screen" && strScreen == "Attachments")
                                {
                                    SaveAttachmentDetails(clsGeneral.Pollution_Tables.PM_Attachments, strOldFilePath, strFileName, strAttachDesc, clsGeneral.GetDecimal(strPK_Building_ID), drpAttachType.SelectedValue, strFk_Fld_Name, clsGeneral.GetDecimal(strFk_Fld_Value));
                                }
                                else if (strModule == "Environmental Screen" && strScreen == "Site Information" && strFk_Fld_Name == "FK_PM_SI_Utility_Provider")
                                {
                                    SaveAttachmentDetails(clsGeneral.Pollution_Tables.PM_SI_UP_Attachments, strOldFilePath, strFileName, strAttachDesc, clsGeneral.GetDecimal(strPK_Building_ID), drpAttachType.SelectedValue, strFk_Fld_Name, clsGeneral.GetDecimal(strFk_Fld_Value));
                                }
                                else if (strModule == "Environmental Screen" && strScreen == "Site Information" && strFk_Fld_Name == "FK_PM_SI_Facility_Id")
                                {
                                    SaveAttachmentDetails(clsGeneral.Pollution_Tables.PM_SI_FI_Attachments, strOldFilePath, strFileName, strAttachDesc, clsGeneral.GetDecimal(strPK_Building_ID), drpAttachType.SelectedValue, strFk_Fld_Name, clsGeneral.GetDecimal(strFk_Fld_Value));
                                }
                                else if (strModule == "Environmental Screen" && strScreen == "Permits")
                                {
                                    SaveAttachmentDetails(clsGeneral.Pollution_Tables.PM_Permits_Attachments, strOldFilePath, strFileName, strAttachDesc, clsGeneral.GetDecimal(strPK_Building_ID), drpAttachType.SelectedValue, strFk_Fld_Name, clsGeneral.GetDecimal(strFk_Fld_Value));
                                }
                                else if (strModule == "Environmental Screen" && strScreen == "Compliance Reporting")
                                {
                                    SaveAttachmentDetails(clsGeneral.Pollution_Tables.PM_CR_Grids_Attachments, strOldFilePath, strFileName, strAttachDesc, clsGeneral.GetDecimal(strPK_Building_ID), drpAttachType.SelectedValue, strFk_Fld_Name, clsGeneral.GetDecimal(strFk_Fld_Value));
                                }
                                else if (strModule == "Environmental Screen" && strScreen == "Equipment")
                                {
                                    if (strKeyData.ToLower().Contains("tank"))
                                        Table_Name = "PM_Equipment_Tank";
                                    else if (strKeyData.ToLower().Contains("paint booth"))
                                        Table_Name = "PM_Equipment_Spray_Booth";
                                    else if (strKeyData.ToLower().Contains("prep station"))
                                        Table_Name = "PM_Equipment_Prep_Station";
                                    else if (strKeyData.ToLower().Contains("oil and water separator"))
                                        Table_Name = "PM_Equipment_OWS";
                                    else if (strKeyData.ToLower().Contains("hydraulic lift"))
                                        Table_Name = "PM_Equipment_Hydraulic_Lift";
                                    else if (strKeyData.ToLower().Contains("paint gun cleaning cabinet"))
                                        Table_Name = "PM_Equipment_PGCC";

                                    SaveAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, strOldFilePath, strFileName, strAttachDesc, clsGeneral.GetDecimal(strPK_Building_ID), drpAttachType.SelectedValue, strFk_Fld_Name, clsGeneral.GetDecimal(strFk_Fld_Value));
                                }
                                else if (strModule == "Environmental Screen" && strScreen == "Waste Disposal" && strFk_Fld_Name == "FK_PM_Waste_Hauler")
                                {
                                    SaveAttachmentDetails(clsGeneral.Pollution_Tables.PM_Waste_Hauler_Attachments, strOldFilePath, strFileName, strAttachDesc, clsGeneral.GetDecimal(strPK_Building_ID), drpAttachType.SelectedValue, strFk_Fld_Name, clsGeneral.GetDecimal(strFk_Fld_Value));
                                }
                                else if (strModule == "Environmental Screen" && strScreen == "Waste Disposal" && strFk_Fld_Name == "FK_PM_Receiving_TSDF")
                                {
                                    SaveAttachmentDetails(clsGeneral.Pollution_Tables.PM_Receiving_TSDF_Attachments, strOldFilePath, strFileName, strAttachDesc, clsGeneral.GetDecimal(strPK_Building_ID), drpAttachType.SelectedValue, strFk_Fld_Name, clsGeneral.GetDecimal(strFk_Fld_Value));
                                }
                                else if (strModule == "Environmental Screen" && strScreen == "Waste Disposal" && strFk_Fld_Name == "FK_PM_Waste_Removal")
                                {
                                    SaveAttachmentDetails(clsGeneral.Pollution_Tables.PM_Waste_Removal_Attachments, strOldFilePath, strFileName, strAttachDesc, clsGeneral.GetDecimal(strPK_Building_ID), drpAttachType.SelectedValue, strFk_Fld_Name, clsGeneral.GetDecimal(strFk_Fld_Value));
                                }
                                else if (strModule == "Environmental Screen" && strScreen == "Audit/Inspections" && strFk_Fld_Name == "FK_PM_Frequency")
                                {
                                    SaveAttachmentDetails(clsGeneral.Pollution_Tables.PM_Frequency_Attachments, strOldFilePath, strFileName, strAttachDesc, clsGeneral.GetDecimal(strPK_Building_ID), drpAttachType.SelectedValue, strFk_Fld_Name, clsGeneral.GetDecimal(strFk_Fld_Value));
                                }
                                else if (strModule == "Environmental Screen" && strScreen == "Audit/Inspections" && strFk_Fld_Name == "FK_PM_Phase_I")
                                {
                                    SaveAttachmentDetails(clsGeneral.Pollution_Tables.PM_Phase_I_Attachments, strOldFilePath, strFileName, strAttachDesc, clsGeneral.GetDecimal(strPK_Building_ID), drpAttachType.SelectedValue, strFk_Fld_Name, clsGeneral.GetDecimal(strFk_Fld_Value));
                                }
                                else if (strModule == "Environmental Screen" && strScreen == "Audit/Inspections" && strFk_Fld_Name == "FK_PM_EPA_Inspection")
                                {
                                    SaveAttachmentDetails(clsGeneral.Pollution_Tables.PM_EPA_Inspection_Attachments, strOldFilePath, strFileName, strAttachDesc, clsGeneral.GetDecimal(strPK_Building_ID), drpAttachType.SelectedValue, strFk_Fld_Name, clsGeneral.GetDecimal(strFk_Fld_Value));
                                }
                                else if (strModule == "Environmental Screen" && strScreen == "Violations")
                                {
                                    SaveAttachmentDetails(clsGeneral.Pollution_Tables.PM_Violation_Attachments, strOldFilePath, strFileName, strAttachDesc, clsGeneral.GetDecimal(strPK_Building_ID), drpAttachType.SelectedValue, strFk_Fld_Name, clsGeneral.GetDecimal(strFk_Fld_Value));
                                }
                                else if (strModule == "Environmental Screen" && strScreen == "Remediations")
                                {
                                    SaveAttachmentDetails(clsGeneral.Pollution_Tables.PM_Remediation_Grid_Attachments, strOldFilePath, strFileName, strAttachDesc, clsGeneral.GetDecimal(strPK_Building_ID), drpAttachType.SelectedValue, strFk_Fld_Name, clsGeneral.GetDecimal(strFk_Fld_Value));
                                }
                                else if (strModule == "Env Proj Mgmt")
                                {
                                    SaveEnvProjAttachment(strOldFilePath, strFileName, strAttachDesc, drpFolder.SelectedValue, clsGeneral.GetDecimal(strFk_Fld_Value));
                                }

                            }
                            //File.Move(strOldFilePath, strNewFilePath);
                        }


                        #endregion

                    }
                    i++;
                }
                //BindAttachmentGrid();
            }
            if (Directory.Exists(AppConfig.DocumentsPath + "OutlookAttachments\\" + clsSession.AttachFilePath))
                Directory.Delete(AppConfig.DocumentsPath + "OutlookAttachments\\" + clsSession.AttachFilePath, true);

            ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:OpenAdjusterNotes();", true);
        }
        catch (Exception ex)
        {
            //AppConfig.DocumentsPath + "OutlookAttachments
            StreamWriter objSw = null;

            if (!Directory.Exists(AppConfig.DocumentsPath + "OutlookAttachments"))
                Directory.CreateDirectory(AppConfig.DocumentsPath + "OutlookAttachments");

            objSw = new StreamWriter(AppConfig.DocumentsPath + "OutlookAttachments" + "\\Error.log", true);
            objSw.WriteLine(DateTime.Now.ToString() + " :- " + ex.Message + Environment.NewLine);
            objSw.Flush();
            objSw.Close();
            objSw.Dispose();

            string strMessage = "The eRIMS2 Outlook Add-In encountered a problem in the upload process. The following Attachments were not uploaded successfully: \\n\\n";
            ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:alert('" + strMessage.Replace("'", "\\'") + "');", true);
        }

        // check whether all files successfully moved to the new path
        // if not, then get list of files which are not moved
        //int intTotal = dtProcessed.Rows.Count;
        //int intSuccess = 0;
        //List<string> lstNotProcessed = new List<string>();
        //foreach (DataRow drSuccess in dtProcessed.Rows)
        //{
        //    if (File.Exists(Convert.ToString(drSuccess["strNewFilePath"])))
        //        intSuccess++;
        //    else
        //        lstNotProcessed.Add(Convert.ToString(drSuccess["strOldFileName"]));
        //}

        // add attachment records in database if all files are uploaded to attach folder
        //if (intSuccess == intTotal)
        //{
        //    foreach (DataRow drSuccess in dtProcessed.Rows)
        //    {
        //        //insert code of attachment tbl
        //        //seabord ln 300 To 349
        //    }
        //}
        //else
        //{
        //    string strFiles = "";
        //    foreach (string strFileName in lstNotProcessed)
        //        strFiles = strFiles + strFileName + "\\n";
        //    string strMessage = "The eRIMS2 Outlook Add-In encountered a problem in the upload process. The following Attachments were not uploaded successfully: \\n\\n" + strFiles;
        //    ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:alert('" + strMessage.Replace("'", "\\'") + "');", true);
        //}
    }

    /// <summary>
    /// Handles Submit cancel click of attachment screen
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAttachmentCancel_Click(object sender, EventArgs e)
    {
        pnlSearch.Visible = false;
        pnlSearchResult.Visible = true;
        pnlAttachment.Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:LogoffApp();", true);
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        //ddlRMLocationNumber.SelectedIndex = ddlLegalEntity.SelectedIndex = ddlLocationdba.SelectedIndex = ddlLocationfka.SelectedIndex = 0;
        txtStartRangeDate.Text = txtEndRangeDate.Text = string.Empty;
        txtMainAddress.Text = txtBuildingAddress.Text = txtMainCity.Text = txtBuildingCity.Text = string.Empty;
        drpMainState.SelectedIndex = drpBuildingState.SelectedIndex = 0;
        txtMainZip.Text = txtBuildingZip.Text = string.Empty;
    }
    #endregion

    #region " Grid Events "

    /// <summary>
    /// Attachment grid row data bound method
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAttachments_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //here set Dropdown visibility

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList drpFolder = (DropDownList)e.Row.FindControl("drpFolder");
            if (bFolder)
            {
                if (drpFolder != null)
                    ComboHelper.FillLU_EPM_Attachment_Type(new DropDownList[] { drpFolder }, true);
            }
            else
            {
                drpFolder.Items.Insert(0, new ListItem("--Select--", "0"));
                drpFolder.Enabled = false;
            }


            DropDownList drpAttachType = (DropDownList)e.Row.FindControl("drpAttachType");
            if (bAttachType)
            {
                if (drpAttachType != null)
                    ComboHelper.FillLU_EPM_Attachment_TypeForEnvironmental(new DropDownList[] { drpAttachType }, true);
            }
            else
            {
                drpAttachType.Items.Insert(0, new ListItem("--Select--", "0"));
                drpAttachType.Enabled = false;
            }

            LinkButton lnkDocName = (LinkButton)e.Row.FindControl("lnkDocName");

            if (DataBinder.Eval(e.Row.DataItem, "PK_Attachment") != DBNull.Value)
            {
                string strPK = Encryption.Encrypt(DataBinder.Eval(e.Row.DataItem, "PK_Attachment").ToString());
                string strURL = AppConfig.SiteURL + "/Download.aspx?ID=" + strPK + "&claimtbl=1";
                lnkDocName.OnClientClick = "javascript:return openWindow('" + strURL + "');";
            }
            else
            {
                string strPath = ((HtmlInputHidden)e.Row.FindControl("hdnFileName")).Value;
                strPath = strPath.Substring(strPath.LastIndexOf('\\') + 1);
                string strURL = AppConfig.SiteURL + "/Download.aspx?outlook=1&fpath=" + Encryption.Encrypt(strPath);
                lnkDocName.OnClientClick = "javascript:return openWindow('" + strURL + "');";
            }
            //}
        }
    }
    #endregion

    #region " Method "

    protected void GetPage()
    {
        MaintainCheckBoxValuesBefore();
        BindGrid(ctrlPageExposure.CurrentPage, ctrlPageExposure.PageSize);
        MaintainCheckBoxValuesAfter();
    }

    private string GetAttachmentDescription(string strAttachDesc, string strEmailFileName)
    {
        string strDescr = strAttachDesc;
        DataRow[] drAttachments = dtMailAttachList.Select("EmailFileName = '" + strEmailFileName.Replace("'", "''") + "'");
        if (drAttachments.Length > 0)
        {
            strDescr = (strDescr != "") ? (strDescr + "\r\n\r\n") : "";
            strDescr = strDescr + "This email contained the following attachments:\r\n";
            foreach (DataRow drAttach in drAttachments)
                strDescr = strDescr + Convert.ToString(drAttach["AttachmentFileName"]) + "\r\n";
        }
        else
        {
            strDescr = "This email contained no attachments.";
        }
        return strDescr;
    }

    private string GetNewFilePath(ref string strFileName, int intCounter)
    {
        string strFilePath;
        if (Request.QueryString["pol"] != null)
        {
            strFilePath = AppConfig.DocumentsPath + "Policy_Other\\" + strFileName;
            if (File.Exists(strFilePath))
            {
                string strExt = strFileName.Substring(strFileName.LastIndexOf("."));
                string strName = strFileName.Substring(0, strFileName.LastIndexOf("."));
                strFileName = strName + "(" + intCounter.ToString() + ")" + strExt;
                strFilePath = AppConfig.DocumentsPath + "Policy_Other\\" + strFileName;
            }
        }
        else
        {
            strFilePath = AppConfig.DocumentsPath + "Attach\\" + strFileName;
            clsGeneral.CreateDirectory(AppConfig.DocumentsPath + "Attach\\");
            if (File.Exists(strFilePath))
            {
                string strExt = strFileName.Substring(strFileName.LastIndexOf("."));
                string strName = strFileName.Substring(0, strFileName.LastIndexOf("."));
                strFileName = strName + "(" + intCounter.ToString() + ")" + strExt;
                strFilePath = AppConfig.DocumentsPath + "Attach\\" + strFileName;
            }
        }

        return strFilePath;
    }

    /// <summary>
    /// Binds the grid by page number and page size
    /// </summary>
    /// <param name="PageNumber">Current page number</param>
    /// <param name="PageSize">Number of records to be displayed on a page</param>
    private void BindGrid(int PageNumber, int PageSize)
    {
        string Regional = string.Empty;
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += Convert.ToString(drRegion["Region"]) + ",";
            }
        }

        if (Convert.ToString(CurrentEmployee) == null)
            CurrentEmployee = 0;

        string strLocationIDs = string.Empty;
        if (ddlRMLocationNumber.SelectedIndex > 0)
            strLocationIDs = ddlRMLocationNumber.SelectedValue;

        DataSet dsSearchResult = ExposureCommon.GetOutlookExposureResult(strLocationIDs, txtStartRangeDate.Text, txtEndRangeDate.Text, _SortBy, _SortOrder, ctrlPageExposure.CurrentPage, ctrlPageExposure.PageSize, Regional.TrimEnd(Convert.ToChar(",")), CurrentEmployee
                                         , txtMainAddress.Text.Trim(), txtMainCity.Text.Trim(), drpMainState.Text, txtMainZip.Text.Trim(), txtBuildingAddress.Text.Trim(), txtBuildingCity.Text.Trim(), drpBuildingState.Text, txtBuildingZip.Text.Trim());

        DataTable dtSearchResult = dsSearchResult.Tables[0];

        //// set values for paging control,so it shows values as needed.
        ctrlPageExposure.TotalRecords = (dsSearchResult.Tables.Count >= 3) ? Convert.ToInt32(dsSearchResult.Tables[1].Rows[0][0]) : 0;
        ctrlPageExposure.CurrentPage = (dsSearchResult.Tables.Count >= 3) ? Convert.ToInt32(dsSearchResult.Tables[2].Rows[0][2]) : 0;
        ctrlPageExposure.RecordsToBeDisplayed = dtSearchResult.Rows.Count;
        ctrlPageExposure.SetPageNumbers();

        // bind the grid.
        gvExposure.DataSource = dtSearchResult;
        gvExposure.DataBind();

        //if (gvExposure.Rows.Count > 0)
        //{
        //    foreach (GridViewRow gRow in gvExposure.Rows)
        //    {
        //        ((CheckBox)gRow.FindControl("chkSelectExposureSingle")).Attributes.Add("onclick", "CheckUncheckedExposure('" + gvExposure.ClientID + "')");
        //    }
        //}

        // set record numbers retrieved
        lblNumber.Text = (dsSearchResult.Tables.Count >= 3) ? Convert.ToString(dsSearchResult.Tables[1].Rows[0][0]) : "0";
    }


    /// <summary>
    /// Attachment Grid
    /// </summary>
    private void BindAttachmentGrid()
    {
        #region set Attachment table and FK
        //FK_Table = clsGeneral.GetQueryStringID(Request.QueryString["id"]);

        //if (Request.QueryString["pol"] != null)
        //    Attachment_Table = "Policy_Other";
        //else
        //{
        //    string strMajCov = Encryption.Decrypt(Request.QueryString["MajCov"]);
        //    Attachment_Table = ((clsGeneral.Claim_Major_Coverage)(Enum.Parse(typeof(clsGeneral.Claim_Major_Coverage), strMajCov))).ToString();
        //    dtFolder = clsVirtual_Folder.SelectForAddAttachment(strMajCov, Attachment_Table.ToString(), FK_Table, Convert.ToDecimal(clsSession.UserID)).Tables[0];
        //}
        #endregion

        DataTable dtAttach = new DataTable();
        dtAttach.Columns.Add("PK_Attachment", typeof(decimal));
        dtAttach.Columns.Add("Attachment_Description", typeof(string));
        dtAttach.Columns.Add("Attachment_Name", typeof(string));
        dtAttach.Columns.Add("FK_Virtual_Folder", typeof(string));
        dtAttach.Columns.Add("Type", typeof(string));


        #region merge Email file list
        if (!string.IsNullOrEmpty(clsSession.AttachFilePath))
        {
            // get the directory path from which to select the mail files
            string strDirPath = AppConfig.DocumentsPath + "OutlookAttachments\\" + clsSession.AttachFilePath;
            // if directory exists
            if (System.IO.Directory.Exists(strDirPath))
            {
                // get all filenames in array
                string[] strFiles = System.IO.Directory.GetFiles(AppConfig.DocumentsPath + "OutlookAttachments\\" + clsSession.AttachFilePath);
                foreach (string strFile in strFiles)
                {
                    DataRow dr = dtAttach.NewRow();
                    dr["PK_Attachment"] = DBNull.Value;
                    dr["Attachment_Description"] = strFile.Substring(strFile.LastIndexOf('\\') + 1).Substring(12);
                    dr["Attachment_Name"] = strFile.Substring(strFile.LastIndexOf('\\') + 1);
                    dr["FK_Virtual_Folder"] = DBNull.Value;
                    dr["Type"] = "Mail";
                    dtAttach.Rows.Add(dr);
                }
            }
        }
        #endregion

        #region merge existing claim attachments list

        //DataTable dtClaimAttach = clsAttachment.SelectByFK_Table(Attachment_Table, FK_Table.ToString()).Tables[0];
        //foreach (DataRow drClaimAttach in dtClaimAttach.Rows)
        //{
        //    DataRow dr = dtAttach.NewRow();
        //    dr["PK_Attachment"] = drClaimAttach["PK_Attachment"];
        //    dr["Attachment_Description"] = drClaimAttach["Attachment_Description"];
        //    dr["Attachment_Name"] = drClaimAttach["Attachment_Name"];
        //    dr["FK_Virtual_Folder"] = drClaimAttach["FK_Virtual_Folder"];
        //    dr["Type"] = "Attachment";
        //    dtAttach.Rows.Add(dr);
        //}

        #endregion

        //here set Dropdown visibility
        //foreach (GridViewRow grow in gvExposure.Rows)
        //{
        //    bool bChecked = ((CheckBox)grow.FindControl("chkSelectExposureSingle")).Checked;
        //    string strModule = ((Label)grow.FindControl("lblModule")).Text;
        //    string strScreen = ((Label)grow.FindControl("lblScreen")).Text;

        //    if (bChecked && strModule.Contains("Environmental Screen") && strScreen.Contains("Attachments"))//Environmental Screen's Main Attachment Selected than we show AttachType Dropdown
        //        bAttachType = true;

        //    if (bChecked && strModule.Contains("Env Proj Mgmt") && strScreen.Contains("Attachments"))//Env Proj Mgmt's Main Attachment Selected than we show Folder Dropdown
        //        bFolder = true;
        //}
        //Module
        //Screen
        DataTable dtKeyData = (DataTable)Session["dtKeyData"];
        if (dtKeyData.Select("Module = 'Environmental Screen' And Screen='Attachments'").Length > 0)
            bAttachType = true;
        if (dtKeyData.Select("Module = 'Env Proj Mgmt' And Screen='Attachments'").Length > 0)
            bFolder = true;

        gvAttachments.DataSource = dtAttach;
        gvAttachments.DataBind();

        if (gvAttachments.Rows.Count > 0)
        {
            foreach (GridViewRow gRow in gvAttachments.Rows)
            {
                ((CheckBox)gRow.FindControl("chkSelectSingle")).Attributes.Add("onclick", "CheckUncheckedAttachments('" + gvAttachments.ClientID + "')");
            }
        }

        btnSubmit.Visible = dtAttach.Rows.Count > 0;



        //if (Request.QueryString["pol"] != null)
        //    gvAttachments.Columns[gvAttachments.Columns.Count - 1].Visible = false;
    }

    private void SaveAttachmentDetails(clsGeneral.Pollution_Tables AttachmentTable, string strOldFilePath, string strFileName, string strAttachDesc, decimal Building_ID, string strAttachType, string FK_Field_Name, decimal FK_Field_Value)
    {
        if (AttachmentTable == clsGeneral.Pollution_Tables.PM_Attachments && !clsGeneral.IsNull(strFileName))
        {
            DataTable dtEPM_Identification = PM_Site_Information.GetPK_EPM_Identification(Building_ID).Tables[0];
            if (dtEPM_Identification != null && dtEPM_Identification.Rows.Count > 0)
            {
                for (int i = 0; i < dtEPM_Identification.Rows.Count; i++)
                {
                    string strUploadPath = AppConfig.strEPMDocumentPath;
                    //string Attachment_Filename = clsGeneral.UploadFile(fpFile, strUploadPath, false, false);
                    clsGeneral.CreateDirectory(AppConfig.strEPMDocumentPath);
                    if (!File.Exists(strUploadPath + "\\" + strFileName))
                        File.Copy(strOldFilePath, strUploadPath + "\\" + strFileName);

                    string strSQL_EPM = "";
                    strSQL_EPM = strSQL_EPM + "INSERT INTO " + "EPM_Attachments" + Environment.NewLine;
                    strSQL_EPM = strSQL_EPM + "(" + "FK_EPM_Identification" + "," + Environment.NewLine;
                    strSQL_EPM = strSQL_EPM + "Attachment_Type" + "," + Environment.NewLine;
                    strSQL_EPM = strSQL_EPM + "Attachment_Description" + "," + Environment.NewLine;
                    strSQL_EPM = strSQL_EPM + "Attachment_Filename" + "," + Environment.NewLine;
                    strSQL_EPM = strSQL_EPM + "Attach_Date" + "," + Environment.NewLine;
                    strSQL_EPM = strSQL_EPM + "Updated_By" + "," + Environment.NewLine;
                    strSQL_EPM = strSQL_EPM + "Update_Date)" + Environment.NewLine;
                    strSQL_EPM = strSQL_EPM + "VALUES(" + Convert.ToString(dtEPM_Identification.Rows[i]["PK_EPM_Identification"]) + "," + Environment.NewLine;
                    strSQL_EPM = strSQL_EPM + Convert.ToString(strAttachType) + "," + Environment.NewLine;//drpAttachType.SelectedValue
                    strSQL_EPM = strSQL_EPM + "'" + strAttachDesc.Trim() + "'," + Environment.NewLine;
                    strSQL_EPM = strSQL_EPM + "'" + strFileName.Trim().Replace("'", "''") + "'," + Environment.NewLine;
                    strSQL_EPM = strSQL_EPM + "'" + Convert.ToString(DateTime.Now) + "'," + Environment.NewLine;
                    strSQL_EPM = strSQL_EPM + (string.IsNullOrEmpty(clsSession.UserID) ? "''" : clsSession.UserID) + "," + Environment.NewLine;
                    strSQL_EPM = strSQL_EPM + "'" + Convert.ToString(DateTime.Now) + "')";

                    Database db = DatabaseFactory.CreateDatabase();
                    db.ExecuteNonQuery(System.Data.CommandType.Text, strSQL_EPM);
                }
            }
        }

        // PK and table must be specified, also attachment type must be selected and file must be uploaded.        
        if (FK_Field_Value != 0 && !clsGeneral.IsNull(AttachmentTable) && !clsGeneral.IsNull(strFileName))
        {
            string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.PollutionTableName[(int)AttachmentTable]);
            string DocPath = string.Concat(strUploadPath, "\\");
            //string name = clsGeneral.UploadFile(fpFile, DocPath, false, false);
            clsGeneral.CreateDirectory(strUploadPath);
            if (!File.Exists(strUploadPath + "\\" + strFileName))
                File.Copy(strOldFilePath, strUploadPath + "\\" + strFileName);

            string strSQL = "";
            strSQL = strSQL + "INSERT INTO " + clsGeneral.PollutionTableName[(int)AttachmentTable] + Environment.NewLine;
            strSQL = strSQL + "(" + FK_Field_Name + "," + Environment.NewLine;

            if (Table_Name == "PM_Equipment_Tank" || Table_Name == "PM_Equipment_Spray_Booth" || Table_Name == "PM_Equipment_OWS" || Table_Name == "PM_Equipment_Hydraulic_Lift" || Table_Name == "PM_Equipment_PGCC")
                strSQL = strSQL + "Table_Name" + "," + Environment.NewLine;

            strSQL = strSQL + "FK_Attachment_Type" + "," + Environment.NewLine;
            strSQL = strSQL + "Description" + "," + Environment.NewLine;
            strSQL = strSQL + "Attachment_Path" + "," + Environment.NewLine;
            strSQL = strSQL + "Updated_By" + "," + Environment.NewLine;
            strSQL = strSQL + "Update_Date)" + Environment.NewLine;
            strSQL = strSQL + "VALUES(" + Convert.ToString(FK_Field_Value) + "," + Environment.NewLine;
            if (Table_Name == "PM_Equipment_Tank" || Table_Name == "PM_Equipment_Spray_Booth" || Table_Name == "PM_Equipment_OWS" || Table_Name == "PM_Equipment_Hydraulic_Lift" || Table_Name == "PM_Equipment_PGCC")
                strSQL = strSQL + "'" + Convert.ToString(Table_Name) + "'," + Environment.NewLine;
            strSQL = strSQL + Convert.ToString(strAttachType) + "," + Environment.NewLine;//drpAttachType.SelectedValue
            strSQL = strSQL + "'" + strAttachDesc.Trim() + "'," + Environment.NewLine;
            strSQL = strSQL + "'" + strFileName.Trim().Replace("'", "''") + "'," + Environment.NewLine;
            strSQL = strSQL + (string.IsNullOrEmpty(clsSession.UserID) ? "''" : clsSession.UserID) + "," + Environment.NewLine;
            strSQL = strSQL + "'" + Convert.ToString(DateTime.Now) + "')";

            Database db = DatabaseFactory.CreateDatabase();
            db.ExecuteNonQuery(System.Data.CommandType.Text, strSQL);
        }
    }

    private void SaveEnvProjAttachment(string strOldFilePath, string strFileName, string strAttachDesc, string strAttachType, decimal FK_Field_Value)
    {
        string strUploadPath = AppConfig.strEPMDocumentPath;
        clsGeneral.CreateDirectory(AppConfig.strEPMDocumentPath);
        if (!File.Exists(strUploadPath + "\\" + strFileName))
            File.Copy(strOldFilePath, strUploadPath + "\\" + strFileName);

        clsEPM_Attachments objEPMAttachment = new clsEPM_Attachments();

        objEPMAttachment.FK_EPM_Identification = FK_Field_Value;
        objEPMAttachment.Attachment_Type = Convert.ToDecimal(strAttachType);
        objEPMAttachment.Updated_By = clsSession.UserID;
        objEPMAttachment.Update_Date = DateTime.Now;
        objEPMAttachment.Attach_Date = DateTime.Now;
        objEPMAttachment.Attachment_Description = strFileName;// strAttachDesc.Trim();
        objEPMAttachment.Attachment_Filename = strFileName;
        objEPMAttachment.Insert();
    }

    private void MaintainCheckBoxValuesBefore()
    {
        DataTable dtKeyData;
        #region Create datatable
        if (Session["dtKeyData"] != null)
        {
            dtKeyData = (DataTable)Session["dtKeyData"];
        }
        else
        {
            dtKeyData = new System.Data.DataTable();
            dtKeyData.Columns.Add("ID");
            dtKeyData.Columns.Add("Module");
            dtKeyData.Columns.Add("Screen");
            dtKeyData.Columns.Add("Key_Data");
            dtKeyData.Columns.Add("Fk_FldName");
            dtKeyData.Columns.Add("Fk_FldValue");
            dtKeyData.Columns.Add("PK_Building_ID");
        }

        #endregion


        foreach (GridViewRow grExposureRow in gvExposure.Rows)
        {
            bool bChecked = ((CheckBox)grExposureRow.FindControl("chkSelectExposureSingle")).Checked;
            string Rowid = Convert.ToString(((HtmlInputHidden)grExposureRow.FindControl("hdn_RowID")).Value);

            if (bChecked)
            {
                if (dtKeyData.Select("ID = '" + Rowid + "'").Length == 0)
                {
                    DataRow drKey = dtKeyData.NewRow();
                    drKey["ID"] = Rowid;
                    drKey["Module"] = ((Label)grExposureRow.FindControl("lblModule")).Text;
                    drKey["Screen"] = ((Label)grExposureRow.FindControl("lblScreen")).Text;
                    drKey["Key_Data"] = ((Label)grExposureRow.FindControl("lblKey_Data")).Text;
                    drKey["Fk_FldName"] = Convert.ToString(((HtmlInputHidden)grExposureRow.FindControl("hdnFk_FldName")).Value);
                    drKey["Fk_FldValue"] = Convert.ToString(((HtmlInputHidden)grExposureRow.FindControl("hdnFk_FldValue")).Value);
                    drKey["PK_Building_ID"] = Convert.ToString(((HtmlInputHidden)grExposureRow.FindControl("hdnPK_Building_ID")).Value);
                    dtKeyData.Rows.Add(drKey);
                }

            }
            else
            {
                DataRow[] drTemp = dtKeyData.Select("ID = '" + Rowid + "'");
                if (drTemp.Length > 0)
                {
                    dtKeyData.Rows.Remove(drTemp[0]);
                }
            }
        }

        Session["dtKeyData"] = dtKeyData;
    }

    private void MaintainCheckBoxValuesAfter()
    {
        DataTable dtKeyData;
        #region Create datatable
        if (Session["dtKeyData"] != null)
        {
            dtKeyData = (DataTable)Session["dtKeyData"];
        }
        else
        {
            dtKeyData = new System.Data.DataTable();
            dtKeyData.Columns.Add("ID");
            dtKeyData.Columns.Add("Module");
            dtKeyData.Columns.Add("Screen");
            dtKeyData.Columns.Add("Key_Data");
            dtKeyData.Columns.Add("Fk_FldName");
            dtKeyData.Columns.Add("Fk_FldValue");
            dtKeyData.Columns.Add("PK_Building_ID");
        }

        #endregion


        foreach (GridViewRow grExposureRow in gvExposure.Rows)
        {
            bool bChecked = ((CheckBox)grExposureRow.FindControl("chkSelectExposureSingle")).Checked;
            string Rowid = Convert.ToString(((HtmlInputHidden)grExposureRow.FindControl("hdn_RowID")).Value);

            if (bChecked)
            {
                if (dtKeyData.Select("ID = '" + Rowid + "'").Length == 0)
                {
                    DataRow drKey = dtKeyData.NewRow();
                    drKey["ID"] = Rowid;
                    drKey["Module"] = ((Label)grExposureRow.FindControl("lblModule")).Text;
                    drKey["Screen"] = ((Label)grExposureRow.FindControl("lblScreen")).Text;
                    drKey["Key_Data"] = ((Label)grExposureRow.FindControl("lblKey_Data")).Text;
                    drKey["Fk_FldName"] = Convert.ToString(((HtmlInputHidden)grExposureRow.FindControl("hdnFk_FldName")).Value);
                    drKey["Fk_FldValue"] = Convert.ToString(((HtmlInputHidden)grExposureRow.FindControl("hdnFk_FldValue")).Value);
                    drKey["PK_Building_ID"] = Convert.ToString(((HtmlInputHidden)grExposureRow.FindControl("hdnPK_Building_ID")).Value);
                    dtKeyData.Rows.Add(drKey);
                }

            }
            else
            {
                DataRow[] drTemp = dtKeyData.Select("ID = '" + Rowid + "'");
                if (drTemp.Length > 0)
                {
                    ((CheckBox)grExposureRow.FindControl("chkSelectExposureSingle")).Checked = true;
                }
            }
        }

        Session["dtKeyData"] = dtKeyData;

        if (dtKeyData.Rows.Count > 0)
            hdnKeyData.Value = "1";
        else
            hdnKeyData.Value = "0";
    }

    #endregion
}