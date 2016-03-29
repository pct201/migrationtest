using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SONIC_Exposures_Manually_Update_Training : clsBasePage
{
    private bool Is_RLCM_User
    {
        get { return ViewState["Is_RLCM_User"] != null ? Convert.ToBoolean(ViewState["Is_RLCM_User"]) : false; }
        set { ViewState["Is_RLCM_User"] = value; }
    }

    #region "Page Events"

    /// <summary>
    /// Handles Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtRLCM = Security.SelectGroupByUserID(Convert.ToDecimal(clsSession.UserID)).Tables[1];

            Is_RLCM_User = ((dtRLCM.Rows.Count > 0) || IsUserSystemAdmin);

            if (Is_RLCM_User)
            {
                BindDropDownList();
            }
            else
            {
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
            }
        }
    }

    #endregion

    #region "Method"

    /// <summary>
    /// Bind Drop Downs
    /// </summary>
    private void BindDropDownList()
    {
        for (int i = DateTime.Now.Year; i >= 2013; i--)
        {
            ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }

        ComboHelper.FillLocationByRLCM(new DropDownList[] { ddlLocation }, null, true, false);
    }

    /// <summary>
    /// Bind Search Result
    /// </summary>
    private void BindSearchResult()
    {
        decimal? Associate = null;
        int year = 0, Qaurter = 0;

        if (ddlQuarter.SelectedIndex > 0) Qaurter = Convert.ToInt32(ddlQuarter.SelectedValue);
        //if (ddlYear.SelectedIndex > 0)
        year = Convert.ToInt32(ddlYear.SelectedValue);
        if (ddlAssociate.SelectedIndex > 0) Associate = Convert.ToDecimal(ddlAssociate.SelectedValue);


        DataSet dsSearchResult = Sonic_U_Training.Associate_Training_Search(Associate, year, Qaurter, Convert.ToDecimal(ddlLocation.SelectedValue));

        if (dsSearchResult.Tables[0].Rows.Count > 0)
            btnSave.Visible = true;
        else
            btnSave.Visible = false;

        gvTraining.DataSource = dsSearchResult.Tables[0];
        gvTraining.DataBind();

        lblLocation.Text = ddlLocation.SelectedIndex > 0 ? ddlLocation.SelectedItem.Text : string.Empty;
        lblYear.Text = Convert.ToString(year);
        lblQuarter.Text = Convert.ToString(Qaurter);
    }

    /// <summary>
    /// Remove duplicate value from string array.
    /// </summary>
    /// <param name="myList"></param>
    /// <returns></returns>
    public string[] RemoveDuplicates(string[] myList)
    {
        System.Collections.ArrayList newList = new System.Collections.ArrayList();

        foreach (string str in myList)
            if (!newList.Contains(str))
                newList.Add(str);
        return (string[])newList.ToArray(typeof(string));
    }

    #endregion

    #region "Events"

    /// <summary>
    /// Button Submit Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BindSearchResult();
        pnlSearch.Visible = false;
        pnlGrid.Visible = true;
    }

    /// <summary>
    /// Manually Save record in Manage_Training_Data table
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        decimal Associate = 0;
        int year = 0, Qaurter = 0;

        bool is_AllTraining_Completed = true;
        string[] strCode = new string[gvTraining.Rows.Count];
        int i = 0;
        if (ddlQuarter.SelectedIndex > 0) Qaurter = Convert.ToInt32(ddlQuarter.SelectedValue);
        year = Convert.ToInt32(ddlYear.SelectedValue);
        if (ddlAssociate.SelectedIndex > 0) Associate = Convert.ToDecimal(ddlAssociate.SelectedValue);

        if (gvTraining != null)
        {
            foreach (GridViewRow gvTrain in gvTraining.Rows)
            {
                if (gvTrain.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hdnEmployee_ID = (HiddenField)gvTrain.FindControl("hdnEmployee_ID");
                    HiddenField hdnCode = (HiddenField)gvTrain.FindControl("hdnCode");

                    Label lblClass_Name = (Label)gvTrain.FindControl("lblClass_Name");
                    HiddenField hdnFK_Employee = (HiddenField)gvTrain.FindControl("hdnFK_Employee");
                    HiddenField hdnFK_LU_Location_ID = (HiddenField)gvTrain.FindControl("hdnFK_LU_Location_ID");
                    
                    RadioButtonList rblIs_Complete = (RadioButtonList)gvTrain.FindControl("rblIs_Complete");

                    Sonic_U_Training.Manage_Training_Data_InsertUpdate(hdnEmployee_ID.Value, hdnCode.Value, year, Qaurter, Convert.ToDecimal(hdnFK_Employee.Value), lblClass_Name.Text, Convert.ToBoolean(Convert.ToInt16(rblIs_Complete.SelectedValue)), Convert.ToDecimal(hdnFK_LU_Location_ID.Value));

                    strCode[i] = hdnCode.Value;
                    ///Mark as completed in Sonic_U_Training_Associate_Training if all training is manually completed. 
                    if (Convert.ToInt16(rblIs_Complete.SelectedValue) == 0)
                    {
                        is_AllTraining_Completed = false;
                    }

                    i++;
                }
            }

            strCode = RemoveDuplicates(strCode);

            ///update Sonic_U_Training_Associate_Training per employee training per training_Code.
            for (int j = 0; j < strCode.Length; j++)
            {
                if (gvTraining != null)
                {
                    Sonic_U_Training.Complete_Sonic_U_Training(year, Qaurter, Associate, strCode[j], is_AllTraining_Completed);
                }
            }

            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:alert('Data saved successfully.')", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:alert('No training data found.')", true);
        }
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlSearch.Visible = true;
        pnlGrid.Visible = false;
    }

    /// <summary>
    /// Associate bind.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLocation.SelectedIndex > 0)
        {
            ComboHelper.FillEmployeeBY_Loc_Training(new DropDownList[] { ddlAssociate }, true, Convert.ToDecimal(ddlLocation.SelectedValue));
        }
        else
        {
            ddlAssociate.Items.Clear();
            ddlAssociate.Items.Add(new ListItem("-- Select --", "0"));
        }
    }
    #endregion

    #region "Grid Event"

    protected void gvTraining_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            RadioButtonList rblIs_Complete = (RadioButtonList)e.Row.FindControl("rblIs_Complete");
            rblIs_Complete.SelectedValue = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Is_Complete"));
        }
    }

    #endregion

}