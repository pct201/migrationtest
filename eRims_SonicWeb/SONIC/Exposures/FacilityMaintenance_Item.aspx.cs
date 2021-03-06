﻿using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SONIC_Exposures_FacilityMaintenance_Item : System.Web.UI.Page
{
    #region "Properties"
    /// <summary>
    /// Denotes Location ID to be used as FK
    /// </summary>
    private int FK_LU_Location_ID
    {
        get { return Convert.ToInt32(ViewState["FK_LU_Location_ID"]); }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }

    /// <summary>
    /// Denotes PK for Property_Cope table
    /// </summary>
    public int PK_Facility_Construction_Maintenance_Item
    {
        get { return Convert.ToInt32(ViewState["PK_Facility_Construction_Maintenance_Item"]); }
        set { ViewState["PK_Facility_Construction_Maintenance_Item"] = value; }
    }

    public DataTable dtAttachment_FacilityMaintenance
    {
        get { return (DataTable)Session["dtAttachment"]; }
        set { Session["dtAttachment"] = value; }
    }

    public DataTable dtNotes_FacilityMaintenance
    {
        get { return (DataTable)Session["dtNotes"]; }
        set { Session["dtNotes"] = value; }
    }

    #endregion

    #region Page Load Events

    protected void Page_Load(object sender, EventArgs e)
    {
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.FacilityMaintenance);
        if (!IsPostBack)
        {
            if (Request.QueryString["loc"] != null)
            {
                int loc;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["loc"]), out loc))
                {
                    FK_LU_Location_ID = loc;
                }
                else
                    Response.Redirect("ExposureSearch.aspx");

                Session["ExposureLocation"] = FK_LU_Location_ID;

                ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
                ucCtrlExposureInfo.BindExposureInfo();

                pnlMaintenanceEdit.Visible = true;
                btnNotesAdd.Visible = true;

                if (Request.QueryString["item"] != null)
                {
                    int maintenanceId;
                    if (int.TryParse(Encryption.Decrypt(Request.QueryString["item"]), out maintenanceId))
                    {
                        PK_Facility_Construction_Maintenance_Item = maintenanceId;
                    }
                    else
                        Response.Redirect("ExposureSearch.aspx");

                    if (Request.QueryString["op"] != null && Request.QueryString["op"].ToString().ToUpper() == "VIEW")
                    {
                        pnlMaintenanceEdit.Visible = false;
                        pnlMaintenanceView.Visible = true;
                        btnNotesAdd.Visible = false;
                    }
                }

                //BindProjectDropDown();
                ComboHelper.FillLocationdba(new DropDownList[] { ddlLocation }, 0, true, true);
                ddlLocation.Style.Remove("font-size");
                ddlLocation.SelectedValue = Convert.ToString(FK_LU_Location_ID);
                ddlLocation.Enabled = false;
                BindBuildingDropDown();
                BindScopeOfWorkDropDown();
                BindInspectionFocusAreaDropDown();
                //BindMaintenanceTypeDropDown();
                BindMaintenanceStatusDropDown();
                //BindContractorSecurityDropDown();
                //BindFirm();
                if(Request.QueryString["flag"] != "1")
                {
                    dtAttachment_FacilityMaintenance = null;
                    dtNotes_FacilityMaintenance = null;
                }
                BindAttachmentGrid();

                if (PK_Facility_Construction_Maintenance_Item > 0)
                {
                    BindMaintenanceDetails();
                }
                else
                {
                    //ddlBuilding.Items.Insert(0, new ListItem("-- Select --", "0"));
                    //ddlFocusAreaItem.Items.Insert(0, new ListItem("-- Select --", "0"));

                    DataTable dtPrimaryKey = Facility_Construction_Maintenance_Item.GetLastPrimaryKey().Tables[0];
                    txtActionNumber.Text = "M" + 1.ToString("D4");
                    if (dtPrimaryKey != null && dtPrimaryKey.Rows.Count > 0)
                    {
                        txtActionNumber.Text = "M" + (Convert.ToInt32(dtPrimaryKey.Rows[0]["PK_Facility_Construction_Maintenance_Item"]) + 1).ToString("D4");
                    }
                }

                BindNotesGrid();
                BindNotesViewGrid();
            }
            else
            {
                Response.Redirect("ExposureSearch.aspx");
            }
        }
    }

    #endregion

    #region Page Control Events

    /// <summary>
    /// Project Drop Down Selected Index Changed Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    BindBuildingDropDown();
    //    BindContractorSecurityDropDown();
    //}

    /// <summary>
    /// Location Drop Down Selected Index Changed Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBuildingDropDown();
        //BindContractorSecurityDropDown();
    }

    /// <summary>
    /// Focus Area Drop Down Selected Index Changed Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlFocusArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindFocusAreaItemDropDown();
    }

    /// <summary>
    /// Responsible Party Drop Down Selected Index Changed Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void ddlResponsibleParty_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    BindFirm();
    //}

    /// <summary>
    /// Save Maintenance Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnMaintenanceSave_Click(object sender, EventArgs e)
    {
        SaveMaintenanceDetails();
    }

    /// <summary>
    /// Save Maintenance Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBindAttachmentGrid_Click(object sender, EventArgs e)
    {
        BindAttachmentGrid();
    }

    /// <summary>
    /// Maintenance Edit Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnManitenanceEdit_Click(object sender, EventArgs e)
    {
        pnlMaintenanceEdit.Visible = true;
        btnNotesAdd.Visible = true;
        pnlMaintenanceView.Visible = false;
    }

    /// <summary>
    /// Add Notes button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNotesAdd_Click(object sender, EventArgs e)
    {
        //if (PK_Facility_Construction_Maintenance_Item > 0)
        //{
        Response.Redirect(String.Format("MaintenanceNotes.aspx?loc={0}&item={1}&op={2}", Request.QueryString["loc"].ToString(), Encryption.Encrypt(PK_Facility_Construction_Maintenance_Item.ToString()), "edit"));
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "alertmessage", "javascript: alert('Please save Maintenance Details first.');", true);
        //}
    }

    /// <summary>
    /// Add Notes button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAttachmentAdd_Click(object sender, EventArgs e)
    {
        //if (PK_Facility_Construction_Maintenance_Item > 0)
        //{
        ScriptManager.RegisterStartupScript(this, GetType(), "openAttachmentPoppup", "javascript:AddMaintenanceAttachment(" + PK_Facility_Construction_Maintenance_Item + ");", true);
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "alertmessage", "javascript: alert('Please save Maintenance Details first.');", true);
        //}
    }

    /// <summary>
    /// Notes Grid Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvNotes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            Response.Redirect(String.Format("MaintenanceNotes.aspx?loc={0}&item={1}&op={2}&subitem={3}", Request.QueryString["loc"].ToString(), Request.QueryString["item"].ToString(), "View", Encryption.Encrypt(e.CommandArgument.ToString())));
        }

        if (e.CommandName == "Remove")
        {
            if (PK_Facility_Construction_Maintenance_Item != 0)
            {
                Facility_Maintenance_Notes.Delete(Convert.ToInt32(e.CommandArgument));
                ScriptManager.RegisterStartupScript(this, GetType(), "btnSave", "javascript: alert('Notes Details Deleted Successfully.');", true);
            }
            else
            {
                if (dtNotes_FacilityMaintenance != null && dtNotes_FacilityMaintenance.Rows.Count > 0)
                {
                    GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    int RowIndex = gvr.RowIndex;
                    dtNotes_FacilityMaintenance.Rows.RemoveAt(RowIndex);
                }
            }
            BindNotesGrid();
            BindNotesViewGrid();
        }
    }

    /// <summary>
    /// Notes Grid Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvNotesView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            Response.Redirect(String.Format("MaintenanceNotes.aspx?loc={0}&item={1}&op={2}&subitem={3}", Request.QueryString["loc"].ToString(), Request.QueryString["item"].ToString(), "View", Encryption.Encrypt(e.CommandArgument.ToString())));
        }

        if (e.CommandName == "Remove")
        {
            if (PK_Facility_Construction_Maintenance_Item != 0)
            {
                Facility_Maintenance_Notes.Delete(Convert.ToInt32(e.CommandArgument));
                ScriptManager.RegisterStartupScript(this, GetType(), "btnSave", "javascript: alert('Notes Details Deleted Successfully.');", true);
            }
            else
            {
                if (dtNotes_FacilityMaintenance != null && dtNotes_FacilityMaintenance.Rows.Count > 0)
                {
                    GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    int RowIndex = gvr.RowIndex;
                    dtNotes_FacilityMaintenance.Rows.RemoveAt(RowIndex);
                }
            }
            BindNotesGrid();
            BindNotesViewGrid();
        }
    }

    /// <summary>
    /// Attachment Rwo Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAttachmentDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveAttachment")
        {
            try
            {
                if (PK_Facility_Construction_Maintenance_Item != 0)
                {
                    string[] attachDetails = e.CommandArgument.ToString().Split(':');
                    string strPath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[(int)clsGeneral.Tables.Maintenance]) + attachDetails[1];
                    if (File.Exists(strPath))
                    {
                        File.Delete(strPath);
                    }

                    ERIMSAttachment.DeleteByPK(Convert.ToInt64(attachDetails[0]));
                }
                else
                {
                    if (dtAttachment_FacilityMaintenance != null && dtAttachment_FacilityMaintenance.Rows.Count > 0)
                    {
                        GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                        int RowIndex = gvr.RowIndex;
                        dtAttachment_FacilityMaintenance.Rows.RemoveAt(RowIndex);

                        string[] attachDetails = e.CommandArgument.ToString().Split(':');
                        string strPath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[(int)clsGeneral.Tables.Maintenance]) + attachDetails[1];
                        if (File.Exists(strPath))
                            File.Delete(strPath);
                    }
                }
                BindAttachmentGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        else if (e.CommandName == "DownloadAttachment")
        {
            string fileName = Convert.ToString(e.CommandArgument);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "javascript:window.open('" + AppConfig.SiteURL + "/Download.aspx?fileName=" + fileName + "&orgName=" + fileName.Substring(12, (fileName.Length - 1) - 11) + "&maintenanceattachment=true','_blank');", true);
        }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Method to Bind Maintenance Details
    /// </summary>
    private void BindMaintenanceDetails()
    {
        Facility_Construction_Maintenance_Item facility_Construction_Maintenance_Item = new Facility_Construction_Maintenance_Item(PK_Facility_Construction_Maintenance_Item);
        txtActionNumber.Text = lblActionNumber.Text = facility_Construction_Maintenance_Item.Item_Number;
        //ddlProject.SelectedValue = facility_Construction_Maintenance_Item.FK_Facility_Construction_Project.HasValue ? facility_Construction_Maintenance_Item.FK_Facility_Construction_Project.Value.ToString() : "0";
        ddlLocation.SelectedValue = facility_Construction_Maintenance_Item.FK_LU_Location_ID.HasValue ? facility_Construction_Maintenance_Item.FK_LU_Location_ID.Value.ToString() : "0";
        lblLocation.Text = ddlLocation.SelectedIndex > 0 ? ddlLocation.SelectedItem.Text : "";

        // Bind Building Drop Down
        BindBuildingDropDown();
        //BindContractorSecurityDropDown();

        //ddlRequester.SelectedValue = facility_Construction_Maintenance_Item.FK_Requester.HasValue ? facility_Construction_Maintenance_Item.FK_Requester.Value.ToString() : "0";
        //lblRequester.Text = ddlRequester.SelectedIndex > 0 ? ddlRequester.SelectedItem.Text : "";
        //if (!string.IsNullOrEmpty(facility_Construction_Maintenance_Item.Requester_Telephone))
        //{
        //    txtTelephone.Text = lblTelephone.Text = (facility_Construction_Maintenance_Item.Requester_Telephone.Length == 10) ? facility_Construction_Maintenance_Item.Requester_Telephone.Substring(0, 3) + "-" + facility_Construction_Maintenance_Item.Requester_Telephone.Substring(3, 3) + "-" + facility_Construction_Maintenance_Item.Requester_Telephone.Substring(6, 4) : facility_Construction_Maintenance_Item.Requester_Telephone;
        //}

        ddlBuilding.SelectedValue = facility_Construction_Maintenance_Item.FK_Building.HasValue ? facility_Construction_Maintenance_Item.FK_Building.Value.ToString() : "0";
        lblBuilding.Text = ddlBuilding.SelectedIndex > 0 ? ddlBuilding.SelectedItem.Text : "";
        //txtEmail.Text = lblEmail.Text = facility_Construction_Maintenance_Item.Requester_Email;
        txtInspectionDate.Text = lblInspectionDate.Text = clsGeneral.FormatDBNullDateToDisplay(facility_Construction_Maintenance_Item.Inspection_Date);
        //ddlInspector.SelectedValue = facility_Construction_Maintenance_Item.FK_Inspected_By.HasValue ? facility_Construction_Maintenance_Item.FK_Inspected_By.Value.ToString() : "0";
        //lblInspector.Text = ddlInspector.SelectedIndex > 0 ? ddlInspector.SelectedItem.Text : "";
        //txtDatePCAOrdered.Text = lblDatePCAOrdered.Text = clsGeneral.FormatDBNullDateToDisplay(facility_Construction_Maintenance_Item.Date_PCA_Ordered);
        //txtDatePCAConducted.Text = lblDatePCAConducted.Text = clsGeneral.FormatDBNullDateToDisplay(facility_Construction_Maintenance_Item.Date_PCA_Conducted);
        //ddlPCAConductedBy.SelectedValue = facility_Construction_Maintenance_Item.FK_PCA_Conducted_By.HasValue ? facility_Construction_Maintenance_Item.FK_PCA_Conducted_By.Value.ToString() : "0";
        //lblPCAConductedBy.Text = ddlPCAConductedBy.SelectedIndex > 0 ? ddlPCAConductedBy.SelectedItem.Text : "";
        ddlScopeOfWork.SelectedValue = facility_Construction_Maintenance_Item.FK_Scope_Of_Work.HasValue ? facility_Construction_Maintenance_Item.FK_Scope_Of_Work.Value.ToString() : "0";
        lblScopeOfWork.Text = ddlScopeOfWork.SelectedIndex > 0 ? ddlScopeOfWork.SelectedItem.Text : "";
        ddlFocusArea.SelectedValue = facility_Construction_Maintenance_Item.FK_Focus_Area.HasValue ? facility_Construction_Maintenance_Item.FK_Focus_Area.Value.ToString() : "0";
        lblFocusArea.Text = ddlFocusArea.SelectedIndex > 0 ? ddlFocusArea.SelectedItem.Text : "";

        // Bind Focus Area Item DropDown
        //BindFocusAreaItemDropDown();
        //ddlFocusAreaItem.SelectedValue = facility_Construction_Maintenance_Item.FK_Facility_Inspection_Item.HasValue ? facility_Construction_Maintenance_Item.FK_Facility_Inspection_Item.Value.ToString() : "0";
        //lblFocusAreaItem.Text = ddlFocusAreaItem.SelectedIndex > 0 ? ddlFocusAreaItem.SelectedItem.Text : "";
        txtEstimatedStartDate.Text = lblEstimatedStartDate.Text = clsGeneral.FormatDBNullDateToDisplay(facility_Construction_Maintenance_Item.Estimated_Start_Date);
        txtEstimatedEndDate.Text = lblEstimatedEndDate.Text = clsGeneral.FormatDBNullDateToDisplay(facility_Construction_Maintenance_Item.Estimated_End_Date);
        //txtActualStartDate.Text = lblActualStartDate.Text = clsGeneral.FormatDBNullDateToDisplay(facility_Construction_Maintenance_Item.Actual_Start_Date);
        //if (facility_Construction_Maintenance_Item.Estimated_Start_Date.HasValue && facility_Construction_Maintenance_Item.Estimated_End_Date.HasValue)
        //{
        //    txtNumberOfDays.Text = lblNumberOfDays.Text = (facility_Construction_Maintenance_Item.Estimated_End_Date.Value - facility_Construction_Maintenance_Item.Estimated_Start_Date.Value).TotalDays.ToString();
        //}

        //ddlMaintenanceType.SelectedValue = facility_Construction_Maintenance_Item.FK_Facility_Maintenance_Type.HasValue ? facility_Construction_Maintenance_Item.FK_Facility_Maintenance_Type.Value.ToString() : "0";
        //lblMaintenanceType.Text = ddlMaintenanceType.SelectedIndex > 0 ? ddlMaintenanceType.SelectedItem.Text : "";
        //ddlResponsibleParty.SelectedValue = facility_Construction_Maintenance_Item.FK_Assigned.HasValue ? facility_Construction_Maintenance_Item.FK_Assigned.Value.ToString() : "0";
        //lblResponsibleParty.Text = ddlResponsibleParty.SelectedIndex > 0 ? ddlResponsibleParty.SelectedItem.Text : "";
        //BindFirm();
        ddlStatus.SelectedValue = facility_Construction_Maintenance_Item.FK_Facility_Maintenance_Status.HasValue ? facility_Construction_Maintenance_Item.FK_Facility_Maintenance_Status.Value.ToString() : "0";
        lblStatus.Text = ddlStatus.SelectedIndex > 0 ? ddlStatus.SelectedItem.Text : "";
        //ddlApprovedBy.SelectedValue = facility_Construction_Maintenance_Item.FK_Approved_By.HasValue ? facility_Construction_Maintenance_Item.FK_Approved_By.Value.ToString() : "0";
        //lblApprovedBy.Text = ddlApprovedBy.SelectedIndex > 0 ? ddlApprovedBy.SelectedItem.Text : "";
        //ddlFirm.SelectedValue = facility_Construction_Maintenance_Item.FK_Firm.HasValue ? facility_Construction_Maintenance_Item.FK_Firm.Value.ToString() : "0";
        //lblFirm.Text = ddlFirm.SelectedIndex > 0 ? ddlFirm.SelectedItem.Text : "";
        //txtContactName.Text = lblContactName.Text = facility_Construction_Maintenance_Item.FK_Contact;
        //txtEstAmount.Text = lblEstimatedAmmount.Text = clsGeneral.FormatCommaSeperatorCurrency(facility_Construction_Maintenance_Item.Estimated_Amount);
        txtActualAmount.Text = lblActualAmmount.Text = clsGeneral.FormatCommaSeperatorCurrency(facility_Construction_Maintenance_Item.Actual_Amount);
        //txtProposalAmount.Text = lblProposalAmount.Text = clsGeneral.FormatCommaSeperatorCurrency(facility_Construction_Maintenance_Item.Proposed_Amount);
        //txtVariance.Text = lblVariance.Text = clsGeneral.FormatCommaSeperatorCurrency(facility_Construction_Maintenance_Item.Amount_Variance);
        //txtTitle.Text = lblTitle.Text = facility_Construction_Maintenance_Item.Title;
        txtRepairDescription.Text = lblRepairDescription.Text = facility_Construction_Maintenance_Item.Repair_Description;
    }

    /// <summary>
    /// Bind Notes Grid
    /// </summary>
    private void BindNotesGrid()
    {
        if (PK_Facility_Construction_Maintenance_Item == 0 && dtNotes_FacilityMaintenance != null)
        {
            gvNotes.DataSource = dtNotes_FacilityMaintenance;
            gvNotes.DataBind();
        }
        else
        {
            gvNotes.DataSource = Facility_Maintenance_Notes.SelectByFK_Table(PK_Facility_Construction_Maintenance_Item, ctrlPageSonicNotes.CurrentPage, ctrlPageSonicNotes.PageSize);
            gvNotes.DataBind();
        }
    }

    /// <summary>
    /// Binds maintenance attachment grids in building information panel
    /// </summary>
    private void BindAttachmentGrid()
    {
        if (PK_Facility_Construction_Maintenance_Item == 0 && dtAttachment_FacilityMaintenance != null)
        {
            gvAttachmentDetails.DataSource = gvAttachmentDetailsView.DataSource = dtAttachment_FacilityMaintenance;
            gvAttachmentDetails.DataBind();
            gvAttachmentDetailsView.DataBind();
        }
        else
        {
            gvAttachmentDetails.DataSource = gvAttachmentDetailsView.DataSource = ERIMSAttachment.SelectAttachmentTableNameForeignKey("Facility_Construction_Maintenance_Item", PK_Facility_Construction_Maintenance_Item.ToString()).Tables[0];
            gvAttachmentDetails.DataBind();
            gvAttachmentDetailsView.DataBind();
        }
    }

    /// <summary>
    /// Bind Notes View Grid
    /// </summary>
    private void BindNotesViewGrid()
    {
        if (PK_Facility_Construction_Maintenance_Item == 0 && dtNotes_FacilityMaintenance != null)
        {
            gvNotesView.DataSource = dtNotes_FacilityMaintenance;
            gvNotesView.DataBind();
        }
        else
        {
            gvNotesView.DataSource = Facility_Maintenance_Notes.SelectByFK_Table(PK_Facility_Construction_Maintenance_Item, ctrlPageSonicNotesView.CurrentPage, ctrlPageSonicNotesView.PageSize);
            gvNotesView.DataBind();
        }
    }

    /// <summary>
    /// Method to bind Contractor Security DropDown
    /// </summary>
    /// <param name="ddlInspector"></param>
    //private void BindContractorSecurityDropDown()
    //{
    //    DataTable dtContractorSecurity = Contractor_Security.SelectContractorUserByLoactionID(FK_LU_Location_ID).Tables[0];

    //    // Inspector Drop down binding
    //    ddlInspector.Items.Clear();
    //    ddlInspector.DataTextField = "UserNameActionItem";
    //    ddlInspector.DataValueField = "PK_Contactor_Security";
    //    ddlInspector.DataSource = dtContractorSecurity.DefaultView;
    //    ddlInspector.DataBind();
    //    ddlInspector.Items.Insert(0, new ListItem("-- Select --", "0"));

    //    // Requester Drop down binding
    //    ddlRequester.Items.Clear();
    //    ddlRequester.DataTextField = "UserNameActionItem";
    //    ddlRequester.DataValueField = "PK_Contactor_Security";
    //    ddlRequester.DataSource = dtContractorSecurity.DefaultView;
    //    ddlRequester.DataBind();
    //    ddlRequester.Items.Insert(0, new ListItem("-- Select --", "0"));

    //    // PCAConductedBy Drop down binding
    //    //ddlPCAConductedBy.Items.Clear();
    //    //ddlPCAConductedBy.DataTextField = "UserNameActionItem";
    //    //ddlPCAConductedBy.DataValueField = "PK_Contactor_Security";
    //    //ddlPCAConductedBy.DataSource = dtContractorSecurity.DefaultView;
    //    //ddlPCAConductedBy.DataBind();
    //    //ddlPCAConductedBy.Items.Insert(0, new ListItem("-- Select --", "0"));

    //    // Approved By Drop down binding
    //    ddlApprovedBy.Items.Clear();
    //    ddlApprovedBy.DataTextField = "UserNameActionItem";
    //    ddlApprovedBy.DataValueField = "PK_Contactor_Security";
    //    ddlApprovedBy.DataSource = dtContractorSecurity.DefaultView;
    //    ddlApprovedBy.DataBind();
    //    ddlApprovedBy.Items.Insert(0, new ListItem("-- Select --", "0"));


    //    // Responsible Party Drop down binding
    //    ddlResponsibleParty.Items.Clear();
    //    ddlResponsibleParty.DataTextField = "UserNameActionItem";
    //    ddlResponsibleParty.DataValueField = "PK_Contactor_Security";
    //    ddlResponsibleParty.DataSource = dtContractorSecurity.DefaultView;
    //    ddlResponsibleParty.DataBind();
    //    ddlResponsibleParty.Items.Insert(0, new ListItem("-- Select --", "0"));
    //}

    ///// <summary>
    ///// Method to bind Project Dropdown
    ///// </summary>
    //private void BindProjectDropDown()
    //{
    //    ddlProject.Items.Clear();
    //    ddlProject.DataTextField = "Project_Number";
    //    ddlProject.DataValueField = "PK_Facility_construction_Project";
    //    ddlProject.DataSource = Facility_Construction_Project.SelectConstructionProjectsByLoction(FK_LU_Location_ID);
    //    ddlProject.DataBind();
    //    ddlProject.Items.Insert(0, new ListItem("-- Select --", "0"));
    //}

    /// <summary>
    /// Bind Building DropDown
    /// </summary>
    private void BindBuildingDropDown()
    {
        ddlBuilding.Items.Clear();
        if (ddlLocation.SelectedIndex > 0)
        {
            ddlBuilding.DataTextField = "BuildingName";
            ddlBuilding.DataValueField = "PK_Building_ID";
            ddlBuilding.DataSource = Building.SelectBuildingByLocation(Convert.ToInt32(ddlLocation.SelectedValue));
            ddlBuilding.DataBind();
        }

        ddlBuilding.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    /// <summary>
    /// Method to bind Scope Of Work Dropdown
    /// </summary>
    private void BindScopeOfWorkDropDown()
    {
        ddlScopeOfWork.Items.Clear();
        ddlScopeOfWork.DataValueField = "PK_LU_Facility_Maintenance_Scope";
        ddlScopeOfWork.DataTextField = "Description";
        ddlScopeOfWork.DataSource = clsLU_Facility_Maintenance_Scope.SelectAll().Tables[0].DefaultView;
        ddlScopeOfWork.DataBind();
        ddlScopeOfWork.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    /// <summary>
    /// Method to bind Insoection Focus Area DropDown
    /// </summary>
    private void BindInspectionFocusAreaDropDown()
    {
        ComboHelper.FillInspectionFocusArea(new DropDownList[] { ddlFocusArea }, true);
    }

    /// <summary>
    /// Bind Building DropDown
    /// </summary>
    //private void BindFocusAreaItemDropDown()
    //{
    //    ddlFocusAreaItem.Items.Clear();
    //    if (ddlFocusArea.SelectedIndex > 0)
    //    {
    //        ddlFocusAreaItem.DataTextField = "Description";
    //        ddlFocusAreaItem.DataValueField = "PK_LU_Facility_Inspection_Item";
    //        ddlFocusAreaItem.DataSource = LU_Facility_Inspection_Item.SelectByFKFocusArea(Convert.ToInt32(ddlFocusArea.SelectedValue)).Tables[0].DefaultView;
    //        ddlFocusAreaItem.DataBind();
    //    }

    //    ddlFocusAreaItem.Items.Insert(0, new ListItem("-- Select --", "0"));
    //}

    /// <summary>
    /// Method to bind Maintenance Type Dropdown
    /// </summary>
    //private void BindMaintenanceTypeDropDown()
    //{
    //    ddlMaintenanceType.Items.Clear();
    //    ddlMaintenanceType.DataValueField = "PK_LU_Facility_Maintenance_Type";
    //    ddlMaintenanceType.DataTextField = "Description";
    //    ddlMaintenanceType.DataSource = clsLU_Facility_Maintenance_Type.SelectAll().Tables[0].DefaultView;
    //    ddlMaintenanceType.DataBind();
    //    ddlMaintenanceType.Items.Insert(0, new ListItem("-- Select --", "0"));
    //}

    /// <summary>
    /// Method to bind Maintenance Type Dropdown
    /// </summary>
    private void BindMaintenanceStatusDropDown()
    {
        ddlStatus.Items.Clear();
        ddlStatus.DataValueField = "PK_LU_Facility_Maintenance_Status";
        ddlStatus.DataTextField = "Description";
        ddlStatus.DataSource = clsLU_Facility_Maintenance_Status.SelectAll().Tables[0].DefaultView;
        ddlStatus.DataBind();
        ddlStatus.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    /// <summary>
    /// Method to bind Maintenance Type Dropdown
    /// </summary>
    //private void BindFirm()
    //{
    //    ddlFirm.Items.Clear();
    //    ddlFirm.DataValueField = "PK_Contractor_Firm";
    //    ddlFirm.DataTextField = "Contractor_Firm_Name";
    //    ddlFirm.DataSource = Contractor_Firm.SelectByUserId(Convert.ToInt32(ddlResponsibleParty.SelectedValue)).Tables[0].DefaultView;
    //    ddlFirm.DataBind();
    //    ddlFirm.Items.Insert(0, new ListItem("-- Select --", "0"));
    //}

    /// <summary>
    /// Saves Maintenance Details
    /// </summary>
    private void SaveMaintenanceDetails()
    {
        Facility_Construction_Maintenance_Item facility_Construction_Maintenance_Item = new Facility_Construction_Maintenance_Item();
        facility_Construction_Maintenance_Item.PK_Facility_Construction_Maintenance_Item = PK_Facility_Construction_Maintenance_Item;
        facility_Construction_Maintenance_Item.Item_Number = txtActionNumber.Text;
        //if (ddlProject.SelectedIndex > 0)
        //{
        //    facility_Construction_Maintenance_Item.FK_Facility_Construction_Project = Convert.ToInt32(ddlProject.SelectedValue);
        //}

        if (ddlLocation.SelectedIndex > 0)
        {
            facility_Construction_Maintenance_Item.FK_LU_Location_ID = Convert.ToInt32(ddlLocation.SelectedValue);
        }

        //if (ddlRequester.SelectedIndex > 0)
        //{
        //    facility_Construction_Maintenance_Item.FK_Requester = Convert.ToInt32(ddlRequester.SelectedValue);
        //    facility_Construction_Maintenance_Item.Requester_Table = "Contractor_Security";
        //}

        //if (!string.IsNullOrEmpty(txtTelephone.Text))
        //{
        //    facility_Construction_Maintenance_Item.Requester_Telephone = txtTelephone.Text.Replace("-", "");
        //}

        if (ddlBuilding.SelectedIndex > 0)
        {
            facility_Construction_Maintenance_Item.FK_Building = Convert.ToInt32(ddlBuilding.SelectedValue);
        }

        //facility_Construction_Maintenance_Item.Requester_Email = txtEmail.Text;
        facility_Construction_Maintenance_Item.Inspection_Date = clsGeneral.FormatNullDateToStore(txtInspectionDate.Text);
        //if (ddlInspector.SelectedIndex > 0)
        //{
        //    facility_Construction_Maintenance_Item.FK_Inspected_By = Convert.ToInt32(ddlInspector.SelectedValue);
        //    facility_Construction_Maintenance_Item.Inspected_By_Table = "Contractor_Security";
        //}

        //facility_Construction_Maintenance_Item.Date_PCA_Ordered = clsGeneral.FormatNullDateToStore(txtDatePCAOrdered.Text);
        //facility_Construction_Maintenance_Item.Date_PCA_Conducted = clsGeneral.FormatNullDateToStore(txtDatePCAConducted.Text);
        facility_Construction_Maintenance_Item.Estimated_Start_Date = clsGeneral.FormatNullDateToStore(txtEstimatedStartDate.Text);
        facility_Construction_Maintenance_Item.Estimated_End_Date = clsGeneral.FormatNullDateToStore(txtEstimatedEndDate.Text);
        //facility_Construction_Maintenance_Item.Actual_Start_Date = clsGeneral.FormatNullDateToStore(txtActualStartDate.Text);

        //if (ddlPCAConductedBy.SelectedIndex > 0)
        //{
        //    facility_Construction_Maintenance_Item.FK_PCA_Conducted_By = Convert.ToInt32(ddlPCAConductedBy.SelectedValue);
        //}

        if (ddlScopeOfWork.SelectedIndex > 0)
        {
            facility_Construction_Maintenance_Item.FK_Scope_Of_Work = Convert.ToInt32(ddlScopeOfWork.SelectedValue);
        }

        if (ddlFocusArea.SelectedIndex > 0)
        {
            facility_Construction_Maintenance_Item.FK_Focus_Area = Convert.ToInt32(ddlFocusArea.SelectedValue);
        }

        //if (ddlFocusAreaItem.SelectedIndex > 0)
        //{
        //    facility_Construction_Maintenance_Item.FK_Facility_Inspection_Item = Convert.ToInt32(ddlFocusAreaItem.SelectedValue);
        //}

        //if (ddlMaintenanceType.SelectedIndex > 0)
        //{
        //    facility_Construction_Maintenance_Item.FK_Facility_Maintenance_Type = Convert.ToInt32(ddlMaintenanceType.SelectedValue);
        //}

        //if (ddlResponsibleParty.SelectedIndex > 0)
        //{
        //    facility_Construction_Maintenance_Item.FK_Assigned = Convert.ToInt32(ddlResponsibleParty.SelectedValue);
        //    facility_Construction_Maintenance_Item.Assigned_Table = "Contractor_Security";
        //}

        if (ddlStatus.SelectedIndex > 0)
        {
            facility_Construction_Maintenance_Item.FK_Facility_Maintenance_Status = Convert.ToInt32(ddlStatus.SelectedValue);
        }

        //if (ddlApprovedBy.SelectedIndex > 0)
        //{
        //    facility_Construction_Maintenance_Item.FK_Approved_By = Convert.ToInt32(ddlApprovedBy.SelectedValue);
        //    facility_Construction_Maintenance_Item.Approved_By_Table = "Contractor_Security";
        //}

        //if (ddlFirm.SelectedIndex > 0)
        //{
        //    facility_Construction_Maintenance_Item.FK_Firm = Convert.ToInt32(ddlFirm.SelectedValue);
        //}

        //facility_Construction_Maintenance_Item.FK_Contact = txtContactName.Text;
        //facility_Construction_Maintenance_Item.Estimated_Amount = clsGeneral.GetDecimalNullableValue(txtEstAmount);
        facility_Construction_Maintenance_Item.Actual_Amount = clsGeneral.GetDecimalNullableValue(txtActualAmount);
        //facility_Construction_Maintenance_Item.Proposed_Amount = clsGeneral.GetDecimalNullableValue(txtProposalAmount);
        //facility_Construction_Maintenance_Item.Amount_Variance = clsGeneral.GetDecimalNullableValue(txtVariance);
        //facility_Construction_Maintenance_Item.Title = txtTitle.Text;
        facility_Construction_Maintenance_Item.Repair_Description = txtRepairDescription.Text;

        facility_Construction_Maintenance_Item.Update_Date = DateTime.Now;

        if (PK_Facility_Construction_Maintenance_Item > 0)
        {
            facility_Construction_Maintenance_Item.Update();
        }
        else
        {
            PK_Facility_Construction_Maintenance_Item = facility_Construction_Maintenance_Item.Insert();

            if (dtAttachment_FacilityMaintenance != null && dtAttachment_FacilityMaintenance.Rows.Count > 0)
            {
                for (int i = 0; i < dtAttachment_FacilityMaintenance.Rows.Count; i++)
                {
                    ERIMSAttachment objAttachment = new ERIMSAttachment();
                    objAttachment.Attachment_Name = objAttachment.Attachment_Description = dtAttachment_FacilityMaintenance.Rows[i]["Attachment_Name"].ToString();
                    objAttachment.Attachment_Table = dtAttachment_FacilityMaintenance.Rows[i]["Attachment_Table"].ToString(); ;
                    objAttachment.Foreign_Key = PK_Facility_Construction_Maintenance_Item;
                    objAttachment.FK_Attachment_Type = 0;
                    objAttachment.Updated_By = clsSession.UserID;
                    objAttachment.Update_Date = DateTime.Today;

                    objAttachment.Insert();
                }
                dtAttachment_FacilityMaintenance = null;
            }

            if (dtNotes_FacilityMaintenance != null && dtNotes_FacilityMaintenance.Rows.Count > 0)
            {
                for (int i = 0; i < dtNotes_FacilityMaintenance.Rows.Count; i++)
                {
                    Facility_Maintenance_Notes facility_Maintenance_Notes = new Facility_Maintenance_Notes();
                    facility_Maintenance_Notes.Note = dtNotes_FacilityMaintenance.Rows[i]["Note"].ToString();
                    facility_Maintenance_Notes.Note_Date = !string.IsNullOrEmpty(dtNotes_FacilityMaintenance.Rows[i]["Note_Date"].ToString()) ? clsGeneral.FormatNullDateToStore(dtNotes_FacilityMaintenance.Rows[i]["Note_Date"].ToString()) : clsGeneral.FormatDateToStore(DateTime.Now);
                    facility_Maintenance_Notes.FK_Facility_Maintenance_Item = PK_Facility_Construction_Maintenance_Item;
                    facility_Maintenance_Notes.Author_Table = "Security";
                    facility_Maintenance_Notes.FK_Author = Convert.ToInt32(clsSession.UserID);

                    facility_Maintenance_Notes.Insert();
                }
                dtNotes_FacilityMaintenance = null;
            }
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "btnSave", "javascript: alert('Maintenance Details Saved Successfully.'); location.href = '" + String.Format("FacilityMaintenance_Item.aspx?loc={0}&item={1}&op={2}", Request.QueryString["loc"].ToString(), Encryption.Encrypt(PK_Facility_Construction_Maintenance_Item.ToString()), "View") + "'", true);
    }

    #endregion

    #region "Set Page size of Notes"

    /// <summary>
    /// Page Sonic Notes Control Event
    /// </summary>
    protected void ctrlPageSonicNotes_GetPage()
    {
        BindNotesGrid();
    }

    /// <summary>
    /// Page Sonic Notes View Control Event
    /// </summary>
    protected void ctrlPageSonicNotesView_GetPage()
    {
        BindNotesViewGrid();
    }

    #endregion

}