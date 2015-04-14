using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
using Winnovative.WnvHtmlConvert;
using System.Web.UI.HtmlControls;


public partial class SONIC_Exposures_ConstructionProjectsView : clsBasePage
{
    #region " Properties "
    /// <summary>
    /// Denote Location ID for Environmental Project Management Data
    /// </summary>
    public decimal LocationID
    {
        get { return Convert.ToDecimal(ViewState["loc"]); }
        set { ViewState["loc"] = value; }
    }

    /// <summary>
    /// Gets or Sets Construction Project Id
    /// </summary>
    public decimal ConstructionProjectId
    {
        get { return Convert.ToDecimal(ViewState["ConstructionProjectId"]); }
        set { ViewState["ConstructionProjectId"] = value; }
    }
    #endregion

    #region " Page Load "
    /// <summary>
    /// page load event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        // Set Tab selection
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Construction);

        if (!IsPostBack)
        {
            if (Request.QueryString["loc"] != null)
            {
                LocationID = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["loc"].ToString()));
            }
            else
            {
                LocationID = 0;
            }

            CheckValidRequest();
            BindHeaderInfo();
            BindBuildings();
            BindProjectType();

            if (Request.QueryString["prjId"] != null)
            {
                ConstructionProjectId = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["prjId"].ToString()));
                FillConstructionProjectDetail();
                
                if (Session["IsEditable"] != null)
                {
                    hdnPanel.Value = "2";
                    hdnPanelSpaire.Value = "1";
                }
                else
                {
                    hdnPanel.Value = "1";
                    hdnPanelSpaire.Value = "0";
                }
            }
            else
            {
                ConstructionProjectId = 0;
                hdnPanel.Value = "2";
                btnAuditTrail.Visible = false;
                btnReturnto_View_Mode.Visible = false;
            }

            ViewState["ConstructionProjectId"] = ConstructionProjectId;
            Session["ConstructionProjectId"] = ConstructionProjectId;
            SetValidations();

            // store the location id in session
            Session["ExposureLocation"] = LocationID;
        }
    }
    #endregion

    #region " private Methods "
    /// <summary>
    /// Check For User Access and valid parameter Location ID
    /// </summary>
    private void CheckValidRequest()
    {
        int Location_Id;
        // Check if User has right To Add Equipment or View Equipment
        if (App_Access == AccessType.View_Only)
        {
            Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
        }

        // Check whether Parameter Location ID is valid int
        // if not provided then redirect to search page.
        if (!int.TryParse(Encryption.Decrypt(Request.QueryString["loc"]), out Location_Id))
        {
            Response.Redirect("~/SONIC/Exposures/ExposureSearch.aspx", true);
            return;
        }
        else
        {
            LocationID = Location_Id;
        }

        // Check if Location ID is exists or Not
        // if not then redirect to ExposureSearch Page.
        if (LU_Location.SelectByPK(Location_Id).Tables[0].Rows.Count == 0)
        {
            Response.Redirect("~/SONIC/Exposures/ExposureSearch.aspx", true);
            return;
        }

        Session["ExposureLocation"] = LocationID;
    }

    /// <summary>
    /// bind Building data in radio button list
    /// </summary>
    private void BindBuildings()
    {
        cblBuildingList.ClearSelection();
        cblBuildingListView.ClearSelection();
        DataTable dtBuilding = Building.BuildingByFKLocation(Convert.ToInt32(LocationID)).Tables[0];
        //DataTable dtBuilding = Building.BuildingByFacilityConstructionProjectId(ConstructionProjectId).Tables[0];

        cblBuildingList.DataSource = dtBuilding;
        cblBuildingList.DataTextField = "Building_Occupacy";
        cblBuildingList.DataValueField = "PK_Building_ID";
        cblBuildingList.DataBind();

        cblBuildingListView.DataSource = dtBuilding;
        cblBuildingListView.DataTextField = "Building_Occupacy";
        cblBuildingListView.DataValueField = "PK_Building_ID";
        cblBuildingListView.DataBind();
    }

    private void FillBuildings()
    {
        DataSet dsBuildings = Facility_Construction_PM_Buildings.SelectBuildingsBasedOnConstrctionProjectId(ConstructionProjectId);

        for (int i = 0; i < dsBuildings.Tables[0].Rows.Count; i++)
        {
            for (int j = 0; j < cblBuildingList.Items.Count; j++)
            {
                if (cblBuildingList.Items[j].Value == Convert.ToString(dsBuildings.Tables[0].Rows[i]["FK_Building"]))
                {
                    cblBuildingList.Items[j].Selected = true;
                    cblBuildingListView.Items[j].Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Binds Header Info
    /// </summary>
    private void BindHeaderInfo()
    {
        DataTable dtLocationInfo = LU_Location.SelectByPK(LocationID).Tables[0];
        if (dtLocationInfo != null && dtLocationInfo.Rows.Count > 0)
        {
            lblLocation_Number.Text = (dtLocationInfo.Rows[0]["Sonic_Location_Code"].ToString() != "") ? dtLocationInfo.Rows[0]["Sonic_Location_Code"].ToString() : "";
            lblLocationdba.Text = (dtLocationInfo.Rows[0]["dba"].ToString() != "") ? dtLocationInfo.Rows[0]["dba"].ToString() : "";
            lblAddress.Text = (dtLocationInfo.Rows[0]["Address"].ToString() != "") ? dtLocationInfo.Rows[0]["Address"].ToString() : "";
            lblCity.Text = (dtLocationInfo.Rows[0]["City"].ToString() != "") ? dtLocationInfo.Rows[0]["City"].ToString() : "";
            lblState.Text = (dtLocationInfo.Rows[0]["StateName"].ToString() != "") ? dtLocationInfo.Rows[0]["StateName"].ToString() : "";
            lblZip.Text = (dtLocationInfo.Rows[0]["Zip_Code"].ToString() != "") ? dtLocationInfo.Rows[0]["Zip_Code"].ToString() : "";
        }
    }

    /// <summary>
    /// Fill Construction Project Details
    /// </summary>
    private void FillConstructionProjectDetail()
    {
        Facility_Construction_Project facility_Construction_Project = new Facility_Construction_Project();
        DataSet dsProjectDetail = facility_Construction_Project.Select(ConstructionProjectId);

        if (dsProjectDetail.Tables[0].Rows.Count > 0)
        {
            if (dsProjectDetail.Tables[0].Rows[0]["Estimated_Completion_Date"] != null)
            {
                lbEstimatedEndDate.Text = clsGeneral.FormatDBNullDateToDisplay(dsProjectDetail.Tables[0].Rows[0]["Estimated_Completion_Date"]);
                txtEstimatedEndDate.Text = clsGeneral.FormatDBNullDateToDisplay(dsProjectDetail.Tables[0].Rows[0]["Estimated_Completion_Date"]);
            }
            else
            {
                lbEstimatedEndDate.Text = string.Empty;
                txtEstimatedEndDate.Text = string.Empty;
            }

            if (dsProjectDetail.Tables[0].Rows[0]["Estimated_Start_Date"] != null)
            {
                lbEstimatedStartDate.Text = clsGeneral.FormatDBNullDateToDisplay(dsProjectDetail.Tables[0].Rows[0]["Estimated_Start_Date"]);
                txtEstimatedStartDate.Text = clsGeneral.FormatDBNullDateToDisplay(dsProjectDetail.Tables[0].Rows[0]["Estimated_Start_Date"]);
            }
            else
            {
                lbEstimatedStartDate.Text = string.Empty;
                txtEstimatedStartDate.Text = string.Empty;
            }

            lbProjectNumber.Text = Convert.ToString(dsProjectDetail.Tables[0].Rows[0]["Project_Number"]);
            txtProjectNumber.Text = Convert.ToString(dsProjectDetail.Tables[0].Rows[0]["Project_Number"]);

            lbProjectType.Text = Convert.ToString(dsProjectDetail.Tables[0].Rows[0]["Type_Description"]);
            ddProjectType.SelectedValue = Convert.ToString(dsProjectDetail.Tables[0].Rows[0]["FK_LU_Facility_Project_Type"]);

            lbProject_Description.Text = Convert.ToString(dsProjectDetail.Tables[0].Rows[0]["Project_Description"]);
            txtProjectDescription.Text = Convert.ToString(dsProjectDetail.Tables[0].Rows[0]["Project_Description"]);

            FillBuildings();
        }
        else
        {
            Response.Redirect("ConstructionProjectManagement.aspx?loc=" + Request.QueryString["loc"]);
        }
    }

    /// <summary>
    /// Bind Facility Construction Project Types
    /// </summary>
    private void BindProjectType()
    {
        ddProjectType.DataSource = LU_Facility_Project_Type.SelectAll("Y");  // "Y" for Active, "N" for InActive, and "" for All
        ddProjectType.DataTextField = "Type_Description";
        ddProjectType.DataValueField = "PK_LU_Facility_Project_Type";
        ddProjectType.DataBind();

        ddProjectType.Items.Insert(0, new ListItem("--select--", "0"));
    }

    private void SaveBuildings()
    {
        Facility_Construction_PM_Buildings facility_Construction_PM_Buildings;

        for (int i = 0; i < cblBuildingList.Items.Count; i++)
        {
            if (cblBuildingList.Items[i].Selected)
            {
                facility_Construction_PM_Buildings = new Facility_Construction_PM_Buildings();
                facility_Construction_PM_Buildings.FK_Facility_Construction_PM = ConstructionProjectId;
                facility_Construction_PM_Buildings.FK_Building = Convert.ToDecimal(cblBuildingList.Items[i].Value);
                facility_Construction_PM_Buildings.Insert();
            }
        }
    }

    private void DeleteBuildings()
    {
        Facility_Construction_PM_Buildings.DeleteBuildingsByConstructionProjectId(ConstructionProjectId);
    }

    #endregion

    #region Control Events

    /// <summary>
    /// Save Button Click Event
    /// </summary>
    /// <param name="sender">Sender Object</param>
    /// <param name="e">Event Argument</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Facility_Construction_Project facility_Construction_Project = new Facility_Construction_Project();

        if (!string.IsNullOrEmpty(txtEstimatedEndDate.Text.Trim()))
        {
            facility_Construction_Project.Estimated_Completion_Date = Convert.ToDateTime(txtEstimatedEndDate.Text.Trim());
        }
        else
        {
            facility_Construction_Project.Estimated_Completion_Date = null;
        }

        if (!string.IsNullOrEmpty(txtEstimatedStartDate.Text.Trim()))
        {
            facility_Construction_Project.Estimated_Start_Date = Convert.ToDateTime(txtEstimatedStartDate.Text.Trim());
        }
        else
        {
            facility_Construction_Project.Estimated_Start_Date = null;
        }

        if (!string.IsNullOrEmpty(txtProjectNumber.Text.Trim()))
        {
            facility_Construction_Project.Project_Number = Convert.ToString(txtProjectNumber.Text.Trim());
        }
        else
        {
            facility_Construction_Project.Project_Number = null;
        }

        if (!string.IsNullOrEmpty(txtProjectDescription.Text.Trim()))
        {
            facility_Construction_Project.Project_Description = Convert.ToString(txtProjectDescription.Text.Trim());
        }
        else
        {
            facility_Construction_Project.Project_Description = null;
        }

        facility_Construction_Project.FK_Location = LocationID;
        facility_Construction_Project.FK_LU_Facility_Project_Type = Convert.ToDecimal(ddProjectType.SelectedValue);
        facility_Construction_Project.UpdatedBy = clsSession.UserID;
        facility_Construction_Project.UpdatedDate = DateTime.Now;

        if (ConstructionProjectId > 0)
        {
            facility_Construction_Project.PK_Facility_construction_Project = ConstructionProjectId;
            facility_Construction_Project.Update();
            DeleteBuildings();
            SaveBuildings();
        }
        else
        {
            ConstructionProjectId = facility_Construction_Project.Insert();
            SaveBuildings();
            Session["ConstructionProjectId"] = ConstructionProjectId;
        }

        Session.Remove("IsEditable");
        hdnPanelSpaire.Value = "0";
        BindBuildings();
        FillConstructionProjectDetail();
        hdnPanel.Value = "1";
        btnReturnto_View_Mode.Visible = true;
        btnAuditTrail.Visible = true;
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (ConstructionProjectId > 0)
        {
            hdnPanel.Value = "2";
            hdnPanelSpaire.Value = "1";
            Session["IsEditable"] = "1";
        }
        else
        {
            Response.Redirect("ConstructionProjectManagement.aspx?loc=" + Request.QueryString["loc"]);
        }
    }

    protected void btnReturnto_View_Mode_Click(object sender, EventArgs e)
    {
        Session.Remove("IsEditable");

        if (ConstructionProjectId > 0)
        {
            hdnPanel.Value = "1";
            hdnPanelSpaire.Value = "0";
        }
        else
        {
            Response.Redirect("ConstructionProjectManagement.aspx?loc=" + Request.QueryString["loc"]);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ConstructionProjectManagement.aspx?loc=" + Request.QueryString["loc"]);
    }

    #endregion

    #region Dynamic Validations
    /// <summary>
    /// Set all Validations
    /// </summary>
    private void SetValidations()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region " Site Information "

        DataTable dtFields = clsScreen_Validators.SelectByScreen(216).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Project Number":
                    strCtrlsIDs += txtProjectNumber.ClientID + ",";
                    strMessages += "Please enter Project Number" + ",";
                    spnProjectNumber.Style["display"] = "inline-block";
                    break;
                case "Estimated Start Date":
                    strCtrlsIDs += txtEstimatedStartDate.ClientID + ",";
                    strMessages += "Please enter Estimated Start Date" + ",";
                    spnEstimatedStartDate.Style["display"] = "inline-block";
                    break;
                case "Project Type":
                    strCtrlsIDs += ddProjectType.ClientID + ",";
                    strMessages += "Please enter Project Type" + ",";
                    spnProjectType.Style["display"] = "inline-block";
                    break;
                case "Estimated End Date":
                    strCtrlsIDs += txtEstimatedEndDate.ClientID + ",";
                    strMessages += "Please enter Estimated End Date" + ",";
                    spnEstimatedEndDate.Style["display"] = "inline-block";
                    break;
                case "Building":
                    strCtrlsIDs += cblBuildingList.ClientID + ",";
                    strMessages += "Please Select Building" + ",";
                    spnBuilding.Style["display"] = "inline-block";
                    break;
                case "Project Description":
                    strCtrlsIDs += txtProjectDescription.ClientID + ",";
                    strMessages += "Please enter Project Description" + ",";
                    spnProjectDescription.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion


        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDsIdentification.Value = strCtrlsIDs;
        hdnErrorMsgsIdentification.Value = strMessages;
    }
    #endregion
}