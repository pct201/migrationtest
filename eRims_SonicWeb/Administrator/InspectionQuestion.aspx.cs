using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ERIMS.DAL;

public partial class Administrator_InspectionQuestion : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public int PK_Inspection_Questions_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Inspection_Questions_ID"]);
        }
        set { ViewState["PK_Inspection_Questions_ID"] = value; }
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Bind Admin Grid
            BindGrid();
            btnSave.Visible = false;
            btnCancel.Visible = false;

        }
    }
    public void BindGrid()
    {
        DataSet dsInsQues = Inspection_Questions.SelectAllForAdmin();
        // bind the grid.
        gvQuestion.DataSource = dsInsQues;
        gvQuestion.DataBind();
    }
    protected void gvQuestion_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkView = (LinkButton)e.Row.FindControl("lnkView");
            LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
            LinkButton lnkRemove = (LinkButton)e.Row.FindControl("lnkRemove");
            if (lnkView != null)
                lnkView.CommandArgument = Convert.ToString(e.Row.RowIndex);
            if (lnkEdit != null)
                lnkEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
            if (lnkRemove != null)
                lnkRemove.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }
    protected void gvQuestion_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvQuestion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvQuestion.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void gvQuestion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            HiddenField hdnInsID = (HiddenField)gvQuestion.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("hdnInspectionQuestionID");
            PK_Inspection_Questions_ID = Convert.ToInt32(hdnInsID.Value.ToString());
            EditRecord();
        }
        if (e.CommandName == "View")
        {
            HiddenField hdnInsID = (HiddenField)gvQuestion.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("hdnInspectionQuestionID");
            PK_Inspection_Questions_ID = Convert.ToInt32(hdnInsID.Value.ToString());
            ViewRecord();
        }
        if (e.CommandName == "Remove")
        {
            HiddenField hdnInsID = (HiddenField)gvQuestion.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("hdnInspectionQuestionID");
            PK_Inspection_Questions_ID = Convert.ToInt32(hdnInsID.Value.ToString());
            Inspection_Questions.DeleteByPK(PK_Inspection_Questions_ID);
            btnCancel_Click(null, null);
            BindGrid();
        }
    }
    public void EditRecord()
    {
        divQuestionViewList.Style.Add("display", "none");
        divAddNewQuestion.Style.Add("display", "block");
        divViewQuestion.Style.Add("display", "none");
        btnSave.Visible = true;
        btnCancel.Visible = true;
        btnSave.Text = "Update";
        Inspection_Questions objIns_Que = new Inspection_Questions(PK_Inspection_Questions_ID);
        txtFocusArea.Text = objIns_Que.Item_Number_Focus_Area.ToString();
        txtQuestionNumber.Text = objIns_Que.Question_Number.ToString();
        txtQuestionText.Text = objIns_Que.Question_Text.ToString();
        txtGuidanceText.Text = objIns_Que.Guidance_Text.ToString();
        rdoDeficientAnswer.SelectedValue = objIns_Que.Deficient_Answer;

        txtFocusArea.Focus();
    }
    public void ViewRecord()
    {
        divQuestionViewList.Style.Add("display", "none");
        divAddNewQuestion.Style.Add("display", "none");
        divViewQuestion.Style.Add("display", "block");
        btnSave.Visible = false;
        btnCancel.Visible = true;
        Inspection_Questions objIns_Que = new Inspection_Questions(PK_Inspection_Questions_ID);
        lblFocusArea.Text = objIns_Que.Item_Number_Focus_Area.ToString();
        lblQuestionNumber.Text = objIns_Que.Question_Number.ToString();
        lblQuestionText.Text = objIns_Que.Question_Text.ToString();
        lblGuidanceText.Text = objIns_Que.Guidance_Text.ToString();
        lblDeficientAnswer.Text = objIns_Que.Deficient_Answer == "Y" ? "Yes" : "No";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        divQuestionViewList.Style.Add("display", "block");
        divAddNewQuestion.Style.Add("display", "none");
        divViewQuestion.Style.Add("display", "none");
        txtFocusArea.Text = "";
        txtGuidanceText.Text = "";
        txtQuestionNumber.Text = "";
        txtQuestionText.Text = "";
        lblFocusArea.Text = "";
        lblGuidanceText.Text = "";
        lblQuestionNumber.Text = "";
        lblQuestionText.Text = "";
        btnSave.Text = "Save";
        btnSave.Visible = false;
        btnCancel.Visible = false;
        rdoDeficientAnswer.SelectedValue = "N";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Inspection_Questions objIns_Que = new Inspection_Questions(PK_Inspection_Questions_ID);
        objIns_Que.PK_Inspection_Questions_ID = PK_Inspection_Questions_ID;
        objIns_Que.Item_Number_Focus_Area = txtFocusArea.Text.ToString();
        objIns_Que.Question_Number = txtQuestionNumber.Text.ToString();
        objIns_Que.Question_Text = txtQuestionText.Text.ToString();
        objIns_Que.Guidance_Text = txtGuidanceText.Text.ToString();
        objIns_Que.Deficient_Answer = rdoDeficientAnswer.SelectedValue;
        if (PK_Inspection_Questions_ID > 0)
        {
            objIns_Que.Update();
        }
        else
        {
            objIns_Que.Insert();
        }
        BindGrid();
        btnCancel_Click(null, null);
    }

    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        divQuestionViewList.Style.Add("display", "none");
        divAddNewQuestion.Style.Add("display", "block");
        divViewQuestion.Style.Add("display", "none");
        btnCancel.Visible = true;
        btnSave.Visible = true;
        btnSave.Text = "Save";
        txtFocusArea.Focus();
    }
}
