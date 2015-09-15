using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ERIMS.DAL;
using System.Xml;

public partial class Administrator_LU_Cause_Code_Information : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public int PK_LU_Cause_Code_Information
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Cause_Code_Information"]);
        }
        set { ViewState["PK_LU_Cause_Code_Information"] = value; }
    }
   
    string strSortOrder = string.Empty;

    /// <summary>
    /// Denotes the Master Order
    /// </summary>
    public int Master_Order
    {
        get
        {
            return clsGeneral.GetInt(ViewState["Master_Order"]);
        }
        set { ViewState["Master_Order"] = value; }
    }

    #endregion

    #region "Page Event"

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // bind the grid.
            BindGrid();
            BindFocusArea();
            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnSaveReorderList.Visible = false;
            btnCancelReorderList.Visible = false;
        }
    }

    #endregion

    #region "Event"

    /// <summary>
    /// Save button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsLU_Cause_Code_Information objCauseCodeInfo = new clsLU_Cause_Code_Information(PK_LU_Cause_Code_Information);
        objCauseCodeInfo.PK_LU_Cause_Code_Information = PK_LU_Cause_Code_Information;
        objCauseCodeInfo.Focus_Area = ddlFocusArea.SelectedItem.Text;

        if (!string.IsNullOrEmpty(ddlFocusArea.SelectedValue))
        {
            objCauseCodeInfo.Master_Order = Convert.ToInt16(ddlFocusArea.SelectedValue);
        }

        objCauseCodeInfo.Question = txtQuestion.Text.ToString();
        objCauseCodeInfo.Update_Date = DateTime.Now;
        objCauseCodeInfo.Updated_By = clsSession.UserID;
        objCauseCodeInfo.Guidance = txtGuidance.Text.ToString();
        objCauseCodeInfo.Reference = txtReference.Text.ToString();
        objCauseCodeInfo.Active = rdoActive.SelectedValue;

        if (PK_LU_Cause_Code_Information > 0)
        {
            objCauseCodeInfo.Update();
        }
        else
        {
            objCauseCodeInfo.Insert();
        }

        BindGrid();
        btnCancel_Click(null, null);
    }

    /// <summary>
    /// Save button Click event for Reorder List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveReorderList_Click(object sender, EventArgs e)
    {
        BindFocusArea();
        string strSortNew, strHiddenPK;
        strSortNew = strSortOrder.TrimEnd(',');
        strHiddenPK = hdnPKId.Value;
        string[] strSortOrderArray = strHiddenPK.Split(',');
        string[] strSortNewArray = strSortNew.Split(',');
        string strfinal = "<LU_Cause_Code_Information>";
        int lengthSortOrder = strSortOrderArray.Length;

        if (lengthSortOrder == strSortNewArray.Length)
        {
            for (int count = 0; count < lengthSortOrder; count++)
            {
                strfinal = strfinal + "<so><PK_LU_Cause_Code_Information>" + strSortOrderArray[count] + "</PK_LU_Cause_Code_Information><Sort_Order>" + strSortNewArray[count] + "</Sort_Order></so>";
            }
            strfinal = strfinal + "</LU_Cause_Code_Information>";
            clsLU_Cause_Code_Information.UpdateLU_Cause_Code_InformationSO(strfinal);
            BindFocusArea();
        }        
    }

    /// <summary>
    /// Cancel button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        BindGrid();
        divCauseCodeInfoGrid.Style.Add("display", "block");
        divAddCauseCodeInformation.Style.Add("display", "none");
        divViewCauseCodeInformation.Style.Add("display", "none");
        divFocusArea.Style.Add("display", "none");
        ddlFocusArea.SelectedIndex = -1;
        txtGuidance.Text = "";
        txtQuestion.Text = "";
        txtReference.Text = "";
        lblFocusArea.Text = "";
        lblGuidance.Text = "";
        lblQuestion.Text = "";
        btnSave.Text = "Save";
        btnSave.Visible = false;
        btnCancel.Visible = false;
        rdoActive.SelectedValue = "N";
        btnSaveReorderList.Visible = false;
        btnCancelReorderList.Visible = false;
    }

    /// <summary>
    /// Sort Questions button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSortQuestions_Click(object sender, EventArgs e)
    {
        BindFocusArea();
        DataSet dsCodeInformation = clsLU_Cause_Code_Information.SelectFocusArea();
        divMain.Style.Add("display", "block");
        divCauseCodeInfoGrid.Style.Add("display", "none");
        divCauseCodeInformation_Main.Style.Add("display", "block");
        divFocusArea.Style.Add("display", "block");
        btnSaveReorderList.Visible = true;
        btnCancelReorderList.Visible = true;
    }

    /// <summary>
    /// Link Add New Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        BindDropDowns();
        divCauseCodeInfoGrid.Style.Add("display", "none");
        divAddCauseCodeInformation.Style.Add("display", "block");
        divViewCauseCodeInformation.Style.Add("display", "none");
        ddlFocusArea.Enabled = true;
        btnCancel.Visible = true;
        btnSave.Visible = true;
        btnSave.Text = "Save";
        ddlFocusArea.Focus();
    }

    #endregion

    #region "Grid Event"

    /// <summary>
    /// Page Index Change Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvCauseCodeInformation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCauseCodeInformation.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    /// <summary>
    /// Row Created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvCauseCodeInformation_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkView = (LinkButton)e.Row.FindControl("lnkView");
            LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");

            if (lnkView != null)
                lnkView.CommandArgument = Convert.ToString(e.Row.RowIndex);
            if (lnkEdit != null)
                lnkEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }

    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvCauseCodeInformation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            HiddenField hdnPKID = (HiddenField)gvCauseCodeInformation.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("hdnPK_LU_Cause_Code_Information");
            PK_LU_Cause_Code_Information = Convert.ToInt32(hdnPKID.Value.ToString());
            EditRecord();
        }
        if (e.CommandName == "View")
        {
            HiddenField hdnPKID = (HiddenField)gvCauseCodeInformation.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("hdnPK_LU_Cause_Code_Information");
            PK_LU_Cause_Code_Information = Convert.ToInt32(hdnPKID.Value.ToString());
            ViewRecord();
        }
    }

    /// <summary>
    /// Row DataBound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFocusArea_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gv = (GridView)e.Row.FindControl("gvChildGrid");
            HiddenField gvddl = (HiddenField)e.Row.FindControl("hdnMaster_Order");
            Master_Order = Convert.ToInt32(gvddl.Value.ToString());
            gv.DataSource = clsLU_Cause_Code_Information.SelectQuestions(Master_Order);
            gv.DataBind();
        }
    }

    /// <summary>
    /// Row Editing Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvCauseCodeInformation_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    #endregion

    #region Methods

    /// <summary>
    /// Bind CouseCodeInformation Grid
    /// </summary>
    public void BindGrid()
    {
        DataSet dsCodeInformation = clsLU_Cause_Code_Information.SelectAll();
        gvCauseCodeInformation.DataSource = dsCodeInformation;
        gvCauseCodeInformation.DataBind();
    }

    /// <summary>
    /// Edit the CouseCodeInformation Grid Records
    /// </summary>
    public void EditRecord()
    {
        BindDropDowns();
        divCauseCodeInfoGrid.Style.Add("display", "none");
        divAddCauseCodeInformation.Style.Add("display", "block");
        divViewCauseCodeInformation.Style.Add("display", "none");
        btnSaveReorderList.Visible = false;
        btnCancelReorderList.Visible = false;
        btnSave.Visible = true;
        btnCancel.Visible = true;
        btnSave.Text = "Update";
        ddlFocusArea.Enabled = false;
        clsLU_Cause_Code_Information objclsLU_Cause_Code_Information = new clsLU_Cause_Code_Information(PK_LU_Cause_Code_Information);
        clsGeneral.SetDropdownValue(ddlFocusArea, objclsLU_Cause_Code_Information.Master_Order, true);
        txtQuestion.Text = objclsLU_Cause_Code_Information.Question.ToString();
        txtGuidance.Text = objclsLU_Cause_Code_Information.Guidance.ToString();
        txtReference.Text = objclsLU_Cause_Code_Information.Reference.ToString();
        rdoActive.SelectedValue = objclsLU_Cause_Code_Information.Active;
    }

    /// <summary>
    /// View the CouseCodeInformation Grid Records
    /// </summary>
    public void ViewRecord()
    {
        divCauseCodeInfoGrid.Style.Add("display", "none");
        divAddCauseCodeInformation.Style.Add("display", "none");
        divViewCauseCodeInformation.Style.Add("display", "block");
        btnSave.Visible = false;
        btnCancel.Visible = true;
        btnSaveReorderList.Visible = false;
        btnCancelReorderList.Visible = false;
        clsLU_Cause_Code_Information objclsLU_Cause_Code_Information = new clsLU_Cause_Code_Information(PK_LU_Cause_Code_Information);
        lblFocusArea.Text = objclsLU_Cause_Code_Information.Focus_Area.ToString();
        lblQuestion.Text = objclsLU_Cause_Code_Information.Question.ToString();
        lblGuidance.Text = objclsLU_Cause_Code_Information.Guidance.ToString();
        lblReference.Text = objclsLU_Cause_Code_Information.Reference.ToString();
        lblActive.Text = objclsLU_Cause_Code_Information.Active == "Y" ? "Yes" : "No";
    }

    /// <summary>
    /// Bind FocusArea Grid
    /// </summary>
    public void BindFocusArea()
    {
        DataSet dsCodeInformation = clsLU_Cause_Code_Information.SelectFocusArea();

        if (dsCodeInformation.Tables[0] != null && dsCodeInformation.Tables[0].Rows.Count > 0)
        {
            gvFocusArea.DataSource = dsCodeInformation.Tables[0];
            gvFocusArea.DataBind();
        }

        if (dsCodeInformation.Tables[1] != null && dsCodeInformation.Tables[1].Rows.Count > 0)
        {            
            DataTable dt = dsCodeInformation.Tables[1];

            int rowCount = dt.Rows.Count;
            int count = 0;
            for (count = 0; count < rowCount; count++) 
            {
                strSortOrder = strSortOrder + dsCodeInformation.Tables[1].Rows[count][0] + ",";
            }
        }
    }

    /// <summary>
    /// Bind All DropDowns
    /// </summary>
    private void BindDropDowns()
    {
        ComboHelper.FillFocusArea(new DropDownList[] { ddlFocusArea }, true);
    }

    #endregion
}
