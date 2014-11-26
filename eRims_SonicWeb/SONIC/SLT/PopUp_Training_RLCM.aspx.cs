using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_SLT_PopUp_Training_RLCM : clsBasePage
{
    #region " properties "
    /// <summary>
    /// Denotes Pk Of SLT_Training_RLCM table
    /// </summary>
    public decimal PK_SLT_Training_RLCM
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_SLT_Training_RLCM"]);
        }
        set { ViewState["PK_SLT_Training_RLCM"] = value; }
    }

    /// <summary>
    /// denotes Value for Quarter
    /// </summary>
    public decimal Quarter
    {
        get
        {
            return clsGeneral.GetInt(ViewState["Quarter"]);
        }
        set { ViewState["Quarter"] = value; }
    }

    /// <summary>
    /// denotes Value for Year
    /// </summary>
    public decimal Year
    {
        get
        {
            return clsGeneral.GetInt(ViewState["Year"]);
        }
        set { ViewState["Year"] = value; }
    }

    /// <summary>
    /// Denotes PK Of SLT_Meeting Table
    /// </summary>
    public decimal FK_SLT_Meeting
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_SLT_Meeting"]);
        }
        set { ViewState["FK_SLT_Meeting"] = value; }
    }

    /// <summary>
    /// Denotes Location ID
    /// </summary>
    public decimal Location_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["Location_ID"]);
        }
        set { ViewState["Location_ID"] = value; }
    }

    /// <summary>
    /// Denotes page Operation
    /// </summary>
    public string StrOperation
    {
        get
        {
            return Convert.ToString(ViewState["StrOperation"]);
        }
        set { ViewState["StrOperation"] = value; }
    }
    #endregion

    #region " Page Events "
    /// <summary>
    /// handles Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Quarter = clsGeneral.GetQueryStringID(Request.QueryString["Quater"]);
            Year = clsGeneral.GetQueryStringID(Request.QueryString["Year"]);
            FK_SLT_Meeting = clsGeneral.GetQueryStringID(Request.QueryString["PK_SLT"]);
            PK_SLT_Training_RLCM = clsGeneral.GetQueryStringID(Request.QueryString["RLCM_ID"]);
            Location_ID = clsGeneral.GetQueryStringID(Request.QueryString["Loc_ID"]);
            StrOperation = Convert.ToString(Request.QueryString["op"]);

            DataTable dtRLCMTraining = clsSLT_Training_RLCM.SelectRLCMTrainingByLocationAndYear(Location_ID, Convert.ToInt32(Year)).Tables[0];
            if (dtRLCMTraining != null && dtRLCMTraining.Rows.Count > 0)
            {
                txtFocus.Text = dtRLCMTraining.Rows[Convert.ToInt32(Quarter) - 1]["Focus"].ToString();
                lblFocus.Text = dtRLCMTraining.Rows[Convert.ToInt32(Quarter) - 1]["Focus"].ToString();
            }

            if (StrOperation.ToLower() != "view")
            {
                BindDetailsForEdit();
            }
            if (StrOperation.ToLower() == "view")
            {
                BindDetailsForView();
            }

        }
    }
    #endregion

    #region " Private Methods "
    /// <summary>
    /// Bind Details In Edit Mode
    /// </summary>
    private void BindDetailsForView()
    {
        tblRLCM_TrainingView.Visible = true;
        tblRLCM_TrainingEdit.Visible = false;

        clsSLT_Training_RLCM ObjSLT_Training_RLCM = new clsSLT_Training_RLCM(PK_SLT_Training_RLCM);
        if (ObjSLT_Training_RLCM.Topic != null) lblTopic.Text = ObjSLT_Training_RLCM.Topic;
        if (ObjSLT_Training_RLCM.Date_Scheduled != null) lblDate_Scheduled.Text = clsGeneral.FormatDBNullDateToDisplay(ObjSLT_Training_RLCM.Date_Scheduled.ToString());
        if (ObjSLT_Training_RLCM.Date_Completed != null) lblDate_Completed.Text = clsGeneral.FormatDBNullDateToDisplay(ObjSLT_Training_RLCM.Date_Completed.ToString());
        if (ObjSLT_Training_RLCM.Reason_Not_Completed != null) lblReason_Not_Completed.Text = ObjSLT_Training_RLCM.Reason_Not_Completed;
    }

    /// <summary>
    /// Bind Details In View Mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        clsSLT_Training_RLCM ObjSLT_Training_RLCM = new clsSLT_Training_RLCM(PK_SLT_Training_RLCM);
        if (ObjSLT_Training_RLCM.Topic != null) txtTopic.Text = ObjSLT_Training_RLCM.Topic;
        if (ObjSLT_Training_RLCM.Date_Scheduled != null) txtDate_Scheduled.Text = clsGeneral.FormatDBNullDateToDisplay(ObjSLT_Training_RLCM.Date_Scheduled.ToString());
        if (ObjSLT_Training_RLCM.Date_Completed != null) txtDate_Completed.Text = clsGeneral.FormatDBNullDateToDisplay(ObjSLT_Training_RLCM.Date_Completed.ToString());
        if (ObjSLT_Training_RLCM.Reason_Not_Completed != null) txtReason_Not_Completed.Text = ObjSLT_Training_RLCM.Reason_Not_Completed;
    }
    #endregion

    #region " Control Events "
    /// <summary>
    /// Handles Save Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_OnClick(object sender, EventArgs e)
    {
        clsSLT_Training_RLCM ObjSLT_Training_RLCM = new clsSLT_Training_RLCM();
        ObjSLT_Training_RLCM.PK_SLT_Training_RLCM = PK_SLT_Training_RLCM;
        ObjSLT_Training_RLCM.FK_SLT_Meeting = FK_SLT_Meeting;
        ObjSLT_Training_RLCM.Calendar_Year = Convert.ToInt32(Year);
        ObjSLT_Training_RLCM.Quarter = Convert.ToInt32(Quarter);
        if (txtFocus.Text != "") ObjSLT_Training_RLCM.Focus = txtFocus.Text;
        if (txtTopic.Text != "") ObjSLT_Training_RLCM.Topic = txtTopic.Text;
        if (txtDate_Scheduled.Text != "") ObjSLT_Training_RLCM.Date_Scheduled = clsGeneral.FormatDateToStore(txtDate_Scheduled.Text);
        if (txtDate_Completed.Text != "") ObjSLT_Training_RLCM.Date_Completed = clsGeneral.FormatDateToStore(txtDate_Completed.Text);
        if (txtReason_Not_Completed.Text != "") ObjSLT_Training_RLCM.Reason_Not_Completed = txtReason_Not_Completed.Text;
        ObjSLT_Training_RLCM.Updated_By = clsSession.UserName;
        ObjSLT_Training_RLCM.Update_Date = clsGeneral.FormatDateToStore(DateTime.Now.ToString());
        if (PK_SLT_Training_RLCM > 0)
            ObjSLT_Training_RLCM.Update();
        else
            PK_SLT_Training_RLCM = ObjSLT_Training_RLCM.Insert();

        ClientScript.RegisterClientScriptBlock(Page.GetType(), DateTime.Now.ToString(), "javascript:BindTraining_RLCM_Grid();", true);
    }

    /// <summary>
    /// Handlesd Cancel button's Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_OnClick(object sender, EventArgs e)
    {
        ClientScript.RegisterClientScriptBlock(Page.GetType(), DateTime.Now.ToString(), "javascript:window.opener.AskfForLogoff=false;self.close();", true);
    }

    /// <summary>
    /// Handles Cancel Button's click in View mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancelView_OnClick(object sender, EventArgs e)
    {
        ClientScript.RegisterClientScriptBlock(Page.GetType(), DateTime.Now.ToString(), "javascript:window.opener.AskfForLogoff=false;self.close();", true);
    }
    #endregion
}