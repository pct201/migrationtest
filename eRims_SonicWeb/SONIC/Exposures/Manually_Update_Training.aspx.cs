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
        Session["location"] = ddlLocation.SelectedValue;
    }

    /// <summary>
    /// Bind Search Result
    /// </summary>
    private void BindSearchResult()
    {
        decimal? Associate = null;
        int year = 0, Qaurter = 0;

        if (ddlQuarter.SelectedIndex > 0) Session["Quater"] = Qaurter = Convert.ToInt32(ddlQuarter.SelectedValue);
        //if (ddlYear.SelectedIndex > 0)
        Session["Year"] = year = Convert.ToInt32(ddlYear.SelectedValue);
        if (ddlAssociate.SelectedIndex > 0)
        {
            Session["PK_Employee_ID"] = Associate = Convert.ToDecimal(ddlAssociate.SelectedValue);
        }
        else
        {
            Session["PK_Employee_ID"] = null;
        }

        DataSet dsSearchResult = Sonic_U_Training.Associate_Training_Search(Associate, year, Qaurter, Convert.ToDecimal(ddlLocation.SelectedValue));

        if (dsSearchResult.Tables[0].Rows.Count > 0)
            btnSave.Visible = true;
        else
            btnSave.Visible = false;

        gvTraining.DataSource = dsSearchResult.Tables[0];
        gvTraining.DataBind();
        Session["location"] = ddlLocation.SelectedValue;
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
                    HiddenField hdnPK_Sonic_U_Associate_Training_Manual = (HiddenField)gvTrain.FindControl("hdnPK_Sonic_U_Associate_Training_Manual");

                    if (hdnPK_Sonic_U_Associate_Training_Manual.Value == "" || hdnPK_Sonic_U_Associate_Training_Manual.Value == null)
                    {
                        hdnPK_Sonic_U_Associate_Training_Manual.Value = "0";
                    }

                    RadioButtonList rblIs_Complete = (RadioButtonList)gvTrain.FindControl("rblIs_Complete");

                    Sonic_U_Training.Manage_Training_Data_InsertUpdate(hdnEmployee_ID.Value, hdnCode.Value, year, Qaurter, Convert.ToDecimal(hdnFK_Employee.Value), lblClass_Name.Text, Convert.ToBoolean(Convert.ToInt16(rblIs_Complete.SelectedValue)), Convert.ToDecimal(hdnFK_LU_Location_ID.Value), Convert.ToDecimal(hdnPK_Sonic_U_Associate_Training_Manual.Value));

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
        BindSearchResult();
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

    /// <summary>
    /// button Add click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>n
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //BindSearchResult();
        if (ddlAssociate.SelectedIndex > 0)
        {
            Session["PK_Employee_ID"] = Convert.ToDecimal(ddlAssociate.SelectedValue);
        }
        else
        {
            Session["PK_Employee_ID"] = null;
        }
        ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "openPopUp('" + 0 + "');", true);
    }
    #endregion

    #region "Grid Event"

    /// <summary>
    /// Training grid Row data bound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvTraining_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            RadioButtonList rblIs_Complete = (RadioButtonList)e.Row.FindControl("rblIs_Complete");
            rblIs_Complete.SelectedValue = (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Is_Complete")).ToLower()=="false") ? "0":"1";
            HiddenField hdnPK_Sonic_U_Associate_Training_Manual = (HiddenField)e.Row.FindControl("hdnPK_Sonic_U_Associate_Training_Manual");
            LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lknEdit");
            LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

            if (!string.IsNullOrEmpty(Convert.ToString(hdnPK_Sonic_U_Associate_Training_Manual.Value)))
            {
                //make edit and delete link visible for Manual entry data only
                if (Sonic_U_Training.CheckForAdminOrRLCMUser(Convert.ToInt16(clsSession.UserID)) == -1)
                {
                    lnkEdit.Enabled = false;
                    lnkDelete.Enabled = false;
                    rblIs_Complete.Enabled = false;
                }
                else
                {
                    lnkEdit.Enabled = true;
                    lnkDelete.Enabled = true;
                }
            }
            else
            {
                lnkEdit.Visible = false;
                lnkDelete.Visible = false;
            }
        }
    }

    #endregion

    /// <summary>
    /// Row Command
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvTraining_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            int PK_ID = Convert.ToInt32(e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "openPopUp('" + Encryption.Encrypt(Convert.ToString(PK_ID)) + "','" + 0 + "');", true);
            BindSearchResult();
        }
        else if (e.CommandName == "Remove")
        {
            int PK_ID = Convert.ToInt32(e.CommandArgument.ToString());
            Sonic_U_Associate_Training_Manual.DeleteByPK(PK_ID, Convert.ToDecimal(Session["location"]));
            BindSearchResult();
        }
    }

    protected void btnhdnReload_Click(object sender, EventArgs e)
    {
        BindSearchResult();
    }
}