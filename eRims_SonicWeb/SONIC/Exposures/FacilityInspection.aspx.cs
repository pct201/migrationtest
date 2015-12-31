﻿using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class SONIC_Exposures_FacilityInspection : System.Web.UI.Page
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
    public int PK_Facility_Construction_Inspection
    {
        get { return Convert.ToInt32(ViewState["PK_Facility_Construction_Inspection"]); }
        set { ViewState["PK_Facility_Construction_Inspection"] = value; }
    }

    /// <summary>
    /// Denotes DataTable for DtInspection table
    /// </summary>
    public DataTable DtInspection
    {
        get { return (DataTable)ViewState["DtInspection"]; }
        set { ViewState["DtInspection"] = value; }
    }

    #endregion

    #region Page Load Events

    protected void Page_Load(object sender, EventArgs e)
    {
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.FacilityInspection);
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
                BindInspectionFocusAreaDropDown();
                BindProjectDropDown();

                pnlInspectionEdit.Visible = true;
                if (Request.QueryString["item"] != null)
                {
                    int inspection;
                    if (int.TryParse(Encryption.Decrypt(Request.QueryString["item"]), out inspection))
                    {
                        PK_Facility_Construction_Inspection = inspection;
                    }
                    else
                        Response.Redirect("ExposureSearch.aspx");

                    if (Request.QueryString["op"] != null && Request.QueryString["op"].ToString().ToUpper() == "VIEW")
                    {
                        pnlInspectionEdit.Visible = false;
                        pnlInspectionView.Visible = true;
                    }
                }
                
                if (PK_Facility_Construction_Inspection > 0)
                {
                    BindInspectionDetails();
                }
                else
                {
                    BindBuildingDropDown();
                    BindContractorSecurityDropDown(ddlInspector);
                }
            }
            else
            {
                Response.Redirect("ExposureSearch.aspx");
            }
        }
    }

    #endregion

    #region Page Events

    /// <summary>
    /// Item Data Bound event for Repeater
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rptFocusAreaItem_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        HtmlImage img = ((HtmlImage)(e.Item.FindControl("imgCalendar")));
        img.Attributes.Add("onclick", "return showCalendar('ctl00_ContentPlaceHolder1_rptFocusAreaItem_ctl0" + (e.Item.ItemIndex) + "_txtEstStartDate', 'mm/dd/y');");

        DropDownList ddlCondition = (DropDownList)e.Item.FindControl("ddlCondition");
        BindConditionDropDown(ddlCondition);

        DropDownList ddlAssignedTo = (DropDownList)e.Item.FindControl("ddlAssignedTo");
        BindContractorSecurityDropDown(ddlAssignedTo);

        if (DtInspection != null && DtInspection.Rows.Count > 0)
        {
            DataRow dr = DtInspection.Rows[e.Item.ItemIndex];
            ddlCondition.SelectedValue = dr["FK_Facility_Inspection_Condition"].ToString();
            ddlAssignedTo.SelectedValue = dr["FK_Assigned_To"].ToString();
            TextBox txtEstCost = (TextBox)e.Item.FindControl("txtEstCost");
            txtEstCost.Text = clsGeneral.FormatCommaSeperatorCurrency(dr["Estimated_Cost"]);
            TextBox txtEstStartDate = (TextBox)e.Item.FindControl("txtEstStartDate");
            txtEstStartDate.Text = clsGeneral.FormatDBNullDateToDisplay(dr["Estimate_Start_Date"].ToString());

            HiddenField hdnFacility_Construction_Inspection_Item = (HiddenField)e.Item.FindControl("hdnFacility_Construction_Inspection_Item");
            hdnFacility_Construction_Inspection_Item.Value = Convert.ToString(dr["PK_Facility_Construction_Inspection_Item"]);
            string pK_Facility_Construction_Maintenance_Item = Convert.ToString(dr["PK_Facility_Construction_Maintenance_Item"]);
            if (!string.IsNullOrEmpty(pK_Facility_Construction_Maintenance_Item) && Convert.ToInt32(pK_Facility_Construction_Maintenance_Item) > 0)
            {
                HiddenField hdnMaintenanceItemId = (HiddenField)e.Item.FindControl("hdnMaintenanceItemId");
                hdnMaintenanceItemId.Value = pK_Facility_Construction_Maintenance_Item;
                ImageButton btnMaintenance = (ImageButton)e.Item.FindControl("btnAddMaintenance");
                btnMaintenance.Enabled = false;
            }
        }
    }

    /// <summary>
    /// event for dropdown change event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlFocusArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        rptFocusAreaItem.DataSource = null;
        rptFocusAreaItem.DataBind();
        if (ddlFocusArea.SelectedValue != "0")
        {
            DtInspection = null;
            rptFocusAreaItem.DataSource = LU_Facility_Inspection_Item.SelectByFKFocusArea(Convert.ToInt32(ddlFocusArea.SelectedValue)).Tables[0];
            rptFocusAreaItem.DataBind();
        }
    }

    /// <summary>
    /// event to Save facility Inspection Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnInspectionSave_Click(object sender, EventArgs e)
    {
        try
        {
            // Save Inspection Details
            SaveInspectionDetails();            
            ScriptManager.RegisterStartupScript(this, GetType(), "savemessage", "javascript: alert('Inspection Details Saved Successfully.'); location.href = '" + String.Format("FacilityInspection.aspx?loc={0}&item={1}&op={2}", Request.QueryString["loc"].ToString(), Encryption.Encrypt(PK_Facility_Construction_Inspection.ToString()), "View") + "'", true);            
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Show Edit Panel On Edit Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnInspectionEdit_Click(object sender, EventArgs e)
    {
        pnlInspectionEdit.Visible = true;
        pnlInspectionView.Visible = false;
    }

    /// <summary>
    /// Project Dropdown change event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBuildingDropDown();
        BindContractorSecurityDropDown(ddlInspector);

        //if (rptFocusAreaItem.Items.Count > 0)
        //{
        foreach (RepeaterItem item in rptFocusAreaItem.Items)
        {
            DropDownList ddlAssignedTo = (DropDownList)item.FindControl("ddlAssignedTo");
            BindContractorSecurityDropDown(ddlAssignedTo);
        }
        //}
    }

    /// <summary>
    /// Add Attachment Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAttachment_Click(object sender, EventArgs e)
    {
        ImageButton button = sender as ImageButton;
        //Get the Repeater Item reference
        RepeaterItem item = button.NamingContainer as RepeaterItem;
        HiddenField hdnFacility_Construction_Inspection_Item = (HiddenField)item.FindControl("hdnFacility_Construction_Inspection_Item");

        if (!string.IsNullOrEmpty(hdnFacility_Construction_Inspection_Item.Value) && Convert.ToInt32(hdnFacility_Construction_Inspection_Item.Value) > 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "openAttachmentPoppup", "javascript:AddMaintenanceAttachment(" + hdnFacility_Construction_Inspection_Item.Value + ");", true);
        }
        else
        {
            if (PK_Facility_Construction_Inspection > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertmessage", "javascript: alert('Please update Inspection Details first.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertmessage", "javascript: alert('Please add Inspection Details first.');", true);
            }
        }
    }

    /// <summary>
    /// Add New Maintenance Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddMaintenance_Click(object sender, EventArgs e)
    {
        if (PK_Facility_Construction_Inspection > 0 && ddlProject.SelectedIndex > 0)
        {
            //Get the reference of the clicked button.
            ImageButton button = sender as ImageButton;
            Int32 fK_Facility_Inspection_Item = Convert.ToInt32(button.CommandArgument);
            //Get the Repeater Item reference
            RepeaterItem item = button.NamingContainer as RepeaterItem;
            Facility_Construction_Maintenance_Item facility_Construction_Maintenance_Item = new Facility_Construction_Maintenance_Item();
            facility_Construction_Maintenance_Item.FK_Facility_Construction_Project = Convert.ToInt32(ddlProject.SelectedValue);
            HiddenField hdnFacility_Construction_Inspection_Item = (HiddenField)item.FindControl("hdnFacility_Construction_Inspection_Item");
            if (!string.IsNullOrEmpty(hdnFacility_Construction_Inspection_Item.Value) && Convert.ToInt32(hdnFacility_Construction_Inspection_Item.Value) > 0)
            {
                // Save Inspection Details
                SaveInspectionDetails();
                facility_Construction_Maintenance_Item.FK_Facility_Inspection_Item_Link = Convert.ToInt32(hdnFacility_Construction_Inspection_Item.Value);
                facility_Construction_Maintenance_Item.FK_Focus_Area = Convert.ToInt32(ddlFocusArea.SelectedValue);
                facility_Construction_Maintenance_Item.FK_Facility_Inspection_Item = fK_Facility_Inspection_Item;
                TextBox txtEstCost = (TextBox)item.FindControl("txtEstCost");
                facility_Construction_Maintenance_Item.Estimated_Amount = clsGeneral.GetDecimalNullableValue(txtEstCost);

                if (ddlBuilding.SelectedIndex > 0)
                {
                    facility_Construction_Maintenance_Item.FK_Building = Convert.ToInt32(ddlBuilding.SelectedValue);
                }

                facility_Construction_Maintenance_Item.Inspection_Date = clsGeneral.FormatNullDateToStore(txtInspectionDate.Text);
                if (ddlInspector.SelectedIndex > 0)
                {
                    facility_Construction_Maintenance_Item.FK_Inspected_By = Convert.ToInt32(ddlInspector.SelectedValue);
                    facility_Construction_Maintenance_Item.Inspected_By_Table = "Contractor_Security";
                }

                TextBox txtEstStartDate = (TextBox)item.FindControl("txtEstStartDate");
                facility_Construction_Maintenance_Item.Estimated_Start_Date = clsGeneral.FormatNullDateToStore(txtEstStartDate.Text);
                DropDownList ddlAssignedTo = (DropDownList)item.FindControl("ddlAssignedTo");
                if (ddlAssignedTo.SelectedIndex > 0)
                {
                    facility_Construction_Maintenance_Item.FK_Assigned = Convert.ToInt32(ddlAssignedTo.SelectedValue);
                    facility_Construction_Maintenance_Item.Assigned_Table = "Contractor_Security";
                }

                facility_Construction_Maintenance_Item.Update_Date = DateTime.Now;
                facility_Construction_Maintenance_Item.PK_Facility_Construction_Maintenance_Item = facility_Construction_Maintenance_Item.Insert();
                Int32 itemNumber = Convert.ToInt32(facility_Construction_Maintenance_Item.PK_Facility_Construction_Maintenance_Item.Value);
                facility_Construction_Maintenance_Item.Item_Number = "M" + itemNumber.ToString("D4");
                facility_Construction_Maintenance_Item.UpdateItemNumberByPrimaryKey();

                DataTable dtAttachment = ERIMSAttachment.SelectByTableName("Facility_Construction_Inspection_Item", Convert.ToInt32(facility_Construction_Maintenance_Item.FK_Facility_Inspection_Item_Link)).Tables[0];
                if (dtAttachment != null && dtAttachment.Rows.Count > 0)
                {
                    foreach (DataRow drAttachment in dtAttachment.Rows)
                    {
                        ERIMSAttachment attachmentMaintenance = new ERIMSAttachment();
                        attachmentMaintenance.Attachment_Description = Convert.ToString(drAttachment["Attachment_Description"]);
                        attachmentMaintenance.Attachment_Name = Convert.ToString(drAttachment["Attachment_Name"]);
                        attachmentMaintenance.Foreign_Key = Convert.ToInt32(facility_Construction_Maintenance_Item.PK_Facility_Construction_Maintenance_Item);
                        attachmentMaintenance.FK_Attachment_Type = 0;
                        attachmentMaintenance.Attachment_Table = "Facility_Construction_Maintenance_Item";
                        attachmentMaintenance.Update_Date = DateTime.Now;
                        attachmentMaintenance.Updated_By = ddlInspector.SelectedValue;
                        attachmentMaintenance.Insert();
                    }
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "btnSave", "javascript: alert('Maintenance Details Saved Successfully.');", true);
                button.Enabled = false;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertmessage", "javascript: alert('Please update Inspection Details first.');", true);
            }
        }
        else
        {
            if (PK_Facility_Construction_Inspection <= 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "savemessage", "javascript: alert('Please save Inspection Details First.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "savemessage", "javascript: alert('Please select Project First.');", true);
            }
        }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Method to bind Contractor Security DropDown
    /// </summary>
    /// <param name="ddlInspector"></param>
    private void BindContractorSecurityDropDown(DropDownList ddlContractorSecurity)
    {
        ddlContractorSecurity.Items.Clear();
        ddlContractorSecurity.DataTextField = "UserNameActionItem";
        ddlContractorSecurity.DataValueField = "PK_Contactor_Security";
        ddlContractorSecurity.DataSource = Contractor_Security.SelectContractorUserByLoactionIDAndProjectID(FK_LU_Location_ID, Convert.ToInt32(ddlProject.SelectedValue)).Tables[0].DefaultView;
        ddlContractorSecurity.DataBind();
        ddlContractorSecurity.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    /// <summary>
    /// Method to bind Project Dropdown
    /// </summary>
    private void BindProjectDropDown()
    {
        ddlProject.Items.Clear();
        ddlProject.DataTextField = "Project_Number";
        ddlProject.DataValueField = "PK_Facility_construction_Project";
        ddlProject.DataSource = Facility_Construction_Project.SelectConstructionProjectsByLoction(FK_LU_Location_ID);
        ddlProject.DataBind();
        ddlProject.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    /// <summary>
    /// Method to bind Building DropDown
    /// </summary>
    private void BindBuildingDropDown()
    {
        ddlBuilding.Items.Clear();
        if (ddlProject.SelectedIndex > 0)
        {
            ddlBuilding.DataTextField = "BuildingName";
            ddlBuilding.DataValueField = "PK_Building_ID";
            ddlBuilding.DataSource = Building.SelectBuildingByProjectNumber(Convert.ToInt32(ddlProject.SelectedValue));
            ddlBuilding.DataBind();
        }

        ddlBuilding.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    /// <summary>
    /// Method to bind Insoection Focus Area DropDown
    /// </summary>
    private void BindInspectionFocusAreaDropDown()
    {
        ComboHelper.FillInspectionFocusArea(new DropDownList[] { ddlFocusArea }, true);
    }

    /// <summary>
    /// Method to bind Condition DropDown
    /// </summary>
    /// <param name="ddlInspector"></param>
    private void BindConditionDropDown(DropDownList ddlCondition)
    {
        ddlCondition.Items.Clear();
        ddlCondition.DataTextField = "Description";
        ddlCondition.DataValueField = "PK_LU_Facility_Inspection_Condition";
        ddlCondition.DataSource = clsLU_Facility_Inspection_Condition.SelectAll().Tables[0].DefaultView;
        ddlCondition.DataBind();
        ddlCondition.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    /// <summary>
    /// Method to Bind Inspection Details
    /// </summary>
    private void BindInspectionDetails()
    {
        DataTable dtInspection = Facility_Construction_Inspection.SelectByPkInpsection(PK_Facility_Construction_Inspection).Tables[0];
        if (dtInspection != null && dtInspection.Rows.Count > 0)
        {
            DtInspection = dtInspection;
            ddlProject.SelectedValue = dtInspection.Rows[0]["FK_Facility_Construction_Project"].ToString();
            txtInspectionDate.Text = lblInspectionDate.Text = clsGeneral.FormatDBNullDateToDisplay(dtInspection.Rows[0]["Inspection_Date"].ToString());
            BindContractorSecurityDropDown(ddlInspector);
            ddlInspector.SelectedValue = dtInspection.Rows[0]["FK_Inspector"] != DBNull.Value ? dtInspection.Rows[0]["FK_Inspector"].ToString() : "0";
            lblInspector.Text = Convert.ToString(dtInspection.Rows[0]["Inspector"]);
            ddlFocusArea.SelectedValue = (dtInspection.Rows[0]["FK_Facility_Inspection_Area"] != DBNull.Value) ? dtInspection.Rows[0]["FK_Facility_Inspection_Area"].ToString() : "0";
            if (ddlFocusArea.SelectedIndex > 0)
            {
                ddlFocusArea.Enabled = false;
            }

            lblFocusArea.Text = dtInspection.Rows[0]["FocusArea"].ToString();            
            BindBuildingDropDown();
            ddlBuilding.SelectedValue = dtInspection.Rows[0]["FK_Building"].ToString();
            lblBuilding.Text = dtInspection.Rows[0]["Building_Number"].ToString();
            lblProject.Text = (ddlProject.SelectedIndex > 0) ? ddlProject.SelectedItem.Text : "";
            if (ddlFocusArea.SelectedIndex > 0)
            {
                rptFocusAreaItem.DataSource = rptFocusAreaItemView.DataSource = dtInspection;
                rptFocusAreaItem.DataBind();
                rptFocusAreaItemView.DataBind();
            }

        }
        else
        {
            pnlInspectionView.Visible = false;
            pnlInspectionEdit.Visible = true;
        }
    }

    /// <summary>
    /// Saves Inspection Details
    /// </summary>
    private void SaveInspectionDetails()
    {
        Facility_Construction_Inspection objFacility_Construction_Inspection = new Facility_Construction_Inspection();
        objFacility_Construction_Inspection.FK_Facility_Construction_Project = Convert.ToDecimal(ddlProject.SelectedValue);
        objFacility_Construction_Inspection.FK_Building = Convert.ToDecimal(ddlBuilding.SelectedValue);
        objFacility_Construction_Inspection.FK_Inspector = Convert.ToDecimal(ddlInspector.SelectedValue);
        objFacility_Construction_Inspection.Inspection_Date = clsGeneral.FormatDateToStore(txtInspectionDate.Text);
        objFacility_Construction_Inspection.Inspector_Table = "Contractor_Security";

        if (PK_Facility_Construction_Inspection > 0)
        {
            objFacility_Construction_Inspection.PK_Facility_Construction_Inspection = PK_Facility_Construction_Inspection;
            objFacility_Construction_Inspection.Update();
        }
        else
        {
            PK_Facility_Construction_Inspection = objFacility_Construction_Inspection.Insert();
        }

        if (ddlFocusArea.SelectedIndex > 0)
        {
            // Save Inspection Item Details
            foreach (RepeaterItem item in rptFocusAreaItem.Items)
            {
                Facility_Construction_Inspection_Item objFacility_Construction_Inspection_Item = new Facility_Construction_Inspection_Item();
                objFacility_Construction_Inspection_Item.FK_Facility_Construction_Inspection = PK_Facility_Construction_Inspection;
                objFacility_Construction_Inspection_Item.FK_Facility_Inspection_Area = Convert.ToInt32(ddlFocusArea.SelectedValue);
                objFacility_Construction_Inspection_Item.FK_Facility_Inspection_Item = Convert.ToInt32(((HiddenField)item.FindControl("hdnFocusAreaItemId")).Value);
                TextBox txtEstCost = (TextBox)item.FindControl("txtEstCost");
                objFacility_Construction_Inspection_Item.Estimated_Cost = (!string.IsNullOrEmpty(txtEstCost.Text)) ? Convert.ToDecimal(txtEstCost.Text) : -1;
                TextBox txtEstStartDate = (TextBox)item.FindControl("txtEstStartDate");
                objFacility_Construction_Inspection_Item.Estimate_Start_Date = (!string.IsNullOrEmpty(txtEstStartDate.Text)) ? Convert.ToDateTime(((TextBox)item.FindControl("txtEstStartDate")).Text) : DateTime.MinValue;
                objFacility_Construction_Inspection_Item.FK_Assigned_To = Convert.ToInt32(((DropDownList)item.FindControl("ddlAssignedTo")).SelectedValue);
                objFacility_Construction_Inspection_Item.FK_Facility_Inspection_Condition = Convert.ToInt32(((DropDownList)item.FindControl("ddlCondition")).SelectedValue);
                objFacility_Construction_Inspection_Item.Assigned_To_Table = "Contractor_Security";
                HiddenField hdnFacility_Construction_Inspection_Item = (HiddenField)item.FindControl("hdnFacility_Construction_Inspection_Item");

                if (!string.IsNullOrEmpty(hdnFacility_Construction_Inspection_Item.Value) && Convert.ToInt32(hdnFacility_Construction_Inspection_Item.Value) > 0)
                {
                    objFacility_Construction_Inspection_Item.PK_Facility_Construction_Inspection_Item = Convert.ToInt64(hdnFacility_Construction_Inspection_Item.Value);
                    objFacility_Construction_Inspection_Item.Update();
                }
                else
                {
                    hdnFacility_Construction_Inspection_Item.Value = objFacility_Construction_Inspection_Item.Insert().ToString();
                }
            }

            ddlFocusArea.Enabled = false;
        }
    }

    #endregion
}