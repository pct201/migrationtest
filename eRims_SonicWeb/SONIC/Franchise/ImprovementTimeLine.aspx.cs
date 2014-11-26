using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class SONIC_Franchise_ImprovementTimeLine : clsBasePage
{
    #region "Variables"

    /// <summary>
    /// Denotes Location ID to be used as FK
    /// </summary>
    private int PK_Franchise_Improvements
    {
        get { return Convert.ToInt32(ViewState["PK_Franchise_Improvements"]); }
        set { ViewState["PK_Franchise_Improvements"] = value; }
    }

    /// <summary>
    /// Denotes operation for page in either in view or edit mode
    /// </summary>
    public string strOperation
    {
        get { return ViewState["strOperation"].ToString(); }
        set { ViewState["strOperation"] = value; }
    }

    /// <summary>
    /// Denotes Location ID to be used as FK
    /// </summary>
    private int FK_LU_Location_ID
    {
        get { return Convert.ToInt32(ViewState["FK_LU_Location_ID"]); }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }

    /// <summary>
    /// Denotes Franchise ID to be used as FK
    /// </summary>
    private int FK_Franchise_ID
    {
        get { return Convert.ToInt32(ViewState["FK_Franchise_ID"]); }
        set { ViewState["FK_Franchise_ID"] = value; }
    }

    #endregion

    #region "Page Events"

    /// <summary>
    /// Page laod event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Set Tab selection
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Franchise);
        if (!IsPostBack)
        {
            //For Location ID
            if (Request.QueryString["loc"] != null)
            {
                int loc;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["loc"]), out loc))
                {
                    FK_LU_Location_ID = loc;
                    ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
                    ucCtrlExposureInfo.BindExposureInfo();

                }
                else
                    Response.Redirect("../Exposures/ExposureSearch.aspx", true);
            }
            else
                Response.Redirect("../Exposures/ExposureSearch.aspx", true);

            strOperation = "";
            //For Franchise Id
            if (Request.QueryString["fid"] != null)
            {
                int fid;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["fid"]), out fid))
                {
                    FK_Franchise_ID = fid;
                }
                else
                    Response.Redirect("../Exposures/ExposureSearch.aspx", true);
            }
            else
                Response.Redirect("../Exposures/ExposureSearch.aspx", true);

            // check for the location id is passed in querystring
            if (Request.QueryString["id"] != null)
            {
                int id;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out id))
                {
                    PK_Franchise_Improvements = id;
                    // set opertation for page
                    strOperation = (Request.QueryString["op"] != null) ? Convert.ToString(Request.QueryString["op"]) : "view";
                    setControls();
                }
            }
            else
            {
                if (App_Access != AccessType.Franchise_AddEdit)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
            }
            txtImprovement.Focus();
        }
    }

    #endregion

    #region "Events"

    /// <summary>
    /// Handle save nutton click event to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Franchise_Improvements objFraImp = new Franchise_Improvements();
            setProperties(objFraImp);
            if (PK_Franchise_Improvements > 0)
                objFraImp.Update();
            else
                objFraImp.Insert();

            Response.Redirect("FranchiseAddEdit.aspx?id=" + Request.QueryString["fid"] + "&op=edit&loc=" + Request.QueryString["loc"], true);
        }
    }

    /// <summary>
    /// Handle Back button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("FranchiseAddEdit.aspx?id=" + Request.QueryString["fid"] + "&op=" + (strOperation == "" ? "edit" : strOperation) + "&loc=" + Request.QueryString["loc"], true);
    }

    /// <summary>
    /// Handle button Edit Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        strOperation = "edit";
        setControls();
        txtImprovement.Focus();
    }

    /// <summary>
    /// Handle button Revert & return click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("FranchiseAddEdit.aspx?id=" + Request.QueryString["fid"] + "&op=" + (strOperation == "" ? "edit" : strOperation) + "&loc=" + Request.QueryString["loc"], true);
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Set Controls in Edit Mode
    /// </summary>
    private void setControls()
    {
        if (strOperation.Trim().ToLower() == "edit")
        {
            if (App_Access != AccessType.Franchise_AddEdit)
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

            Franchise_Improvements objFranImp = new Franchise_Improvements(PK_Franchise_Improvements);
            //Edit Mode
            txtImprovement.Text = Convert.ToString(objFranImp.Improvement);
            txtDescofWork.Text = Convert.ToString(objFranImp.Description_Of_Work);
            txtScheduledStartDate.Text = clsGeneral.FormatDBNullDateToDisplay(objFranImp.Scheduled_Start);
            txtActualStartDate.Text = clsGeneral.FormatDBNullDateToDisplay(objFranImp.Actual_Start);
            txtAnticipatedCompletionDate.Text = clsGeneral.FormatDBNullDateToDisplay(objFranImp.Anticipated_Completion);
            txtActualCompletionDate.Text = clsGeneral.FormatDBNullDateToDisplay(objFranImp.Actual_Completion);
            txtUpdate.Text = Convert.ToString(objFranImp.Updates);
            trButtonEdit.Visible = true;
            trButtonView.Visible = false;
            dvEdit.Visible = true;
            dvView.Visible = false;
        }
        else
        {
            if (App_Access != AccessType.Franchise_View && App_Access != AccessType.Franchise_AddEdit)
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

            Franchise_Improvements objFranImp = new Franchise_Improvements(PK_Franchise_Improvements);
            //View Mode
            lblImprovement.Text = Convert.ToString(objFranImp.Improvement);
            lblDescofWork.Text = Convert.ToString(objFranImp.Description_Of_Work);
            lblScheduledStartDate.Text = clsGeneral.FormatDBNullDateToDisplay(objFranImp.Scheduled_Start);
            lblActualStartDate.Text = clsGeneral.FormatDBNullDateToDisplay(objFranImp.Actual_Start);
            lblAnticipatedCompletionDate.Text = clsGeneral.FormatDBNullDateToDisplay(objFranImp.Anticipated_Completion);
            lblActualCompletionDate.Text = clsGeneral.FormatDBNullDateToDisplay(objFranImp.Actual_Completion);
            lblUpdates.Text = Convert.ToString(objFranImp.Updates);
            trButtonEdit.Visible = false;
            trButtonView.Visible = true;
            dvEdit.Visible = false;
            dvView.Visible = true;
            btnEdit.Visible = (App_Access == AccessType.Franchise_AddEdit);
        }
    }

    /// <summary>
    /// Set Properties in Edit Mode
    /// </summary>
    private void setProperties(Franchise_Improvements objFranImp)
    {
        objFranImp.PK_Franchise_Improvements = PK_Franchise_Improvements;
        objFranImp.FK_Franchise = FK_Franchise_ID;
        objFranImp.Improvement = Convert.ToString(txtImprovement.Text).Trim();
        objFranImp.Description_Of_Work = Convert.ToString(txtDescofWork.Text).Trim();
        objFranImp.Scheduled_Start = clsGeneral.FormatNullDateToStore(txtScheduledStartDate.Text);
        objFranImp.Actual_Start = clsGeneral.FormatNullDateToStore(txtActualStartDate.Text);
        objFranImp.Anticipated_Completion = clsGeneral.FormatNullDateToStore(txtAnticipatedCompletionDate.Text);
        objFranImp.Actual_Completion = clsGeneral.FormatNullDateToStore(txtActualCompletionDate.Text);
        objFranImp.Updated_By = clsSession.UserName;
        objFranImp.Update_Date = DateTime.Now;
        objFranImp.Updates = Convert.ToString(txtUpdate.Text);
    }

    #endregion
}
