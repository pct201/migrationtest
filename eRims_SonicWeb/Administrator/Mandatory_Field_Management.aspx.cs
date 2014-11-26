using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
using System.Collections;

public partial class Administrator_Mandatory_Field_Management : clsBasePage
{
    #region Page Events
    /// <summary>
    /// Handles Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Binds Module Dropdown and Sets ToolTip
            BindDropDowns();
        }
    }
    #endregion

    #region Control Events
    /// <summary>
    /// Handles Save Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (drpModules.SelectedIndex > 0 && drpSubModules.SelectedIndex > 0 && drpScreen.SelectedIndex > 0 && (lstNonMandatory_fields.Items.Count > 0 || lstMandatory_fields.Items.Count > 0))
        {
            foreach (ListItem LI in lstNonMandatory_fields.Items)
            {
                clsScreen_Validators.UpdateByPK(Convert.ToDecimal(LI.Value), "0");
            }
            foreach (ListItem LI in lstMandatory_fields.Items)
            {
                clsScreen_Validators.UpdateByPK(Convert.ToDecimal(LI.Value), "1");
            }
            Page.RegisterStartupScript(DateTime.Now.ToString(), "<script language=javascript> alert('Data saved Successfully');</script>");
        }
        else
        {
            Page.RegisterStartupScript(DateTime.Now.ToString(), "<script language=javascript> alert('Please select proper data to save');</script>");
        }
    }

    /// <summary>
    /// Handles Cancel Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        drpModules.SelectedIndex = 0;
        ComboHelper.FillLookUp(new DropDownList[] { drpSubModules }, "SubModule", "SubModuleId", "SubModuleName", "", "ModuleId=" + drpModules.SelectedValue, "SubModuleName");
        ComboHelper.FillLookUp(new DropDownList[] { drpScreen }, "Screen", "ScreenId", "ScreenName", "", "SubModuleId=" + drpSubModules.SelectedValue, "ScreenName");
        //clear list box
        lstNonMandatory_fields.Items.Clear();
        lstMandatory_fields.Items.Clear();
        btnDeselectFields.Enabled = btnDeselectAllFields.Enabled = lstMandatory_fields.Items.Count > 0;
        btnSelectAllFields.Enabled = btnSelectFields.Enabled = lstNonMandatory_fields.Items.Count > 0;
        SetToolTip();
    }

    /// <summary>
    /// Handles Modules DropDown Selected Index Change Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpModules_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboHelper.FillLookUp(new DropDownList[] { drpSubModules }, "SubModule", "SubModuleId", "SubModuleName", "", "ModuleId=" + drpModules.SelectedValue, "SubModuleName");
        ComboHelper.FillLookUp(new DropDownList[] { drpScreen }, "Screen", "ScreenId", "ScreenName", "", "SubModuleId=" + drpSubModules.SelectedValue, "ScreenName");

        ListItem lst = drpSubModules.Items.FindByText("Map");
        if (lst != null)
            drpSubModules.Items.Remove(lst);

        //clear list box
        lstNonMandatory_fields.Items.Clear();
        lstMandatory_fields.Items.Clear();
        hdnNotNullFields.Value = "";
        btnDeselectFields.Enabled = btnDeselectAllFields.Enabled = lstMandatory_fields.Items.Count > 0;
        btnSelectAllFields.Enabled = btnSelectFields.Enabled = lstNonMandatory_fields.Items.Count > 0;
        SetToolTip();
    }

    /// <summary>
    /// Handles Sub Module Dropdown selected index change Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpSubModules_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboHelper.FillLookUp(new DropDownList[] { drpScreen }, "Screen", "ScreenId", "ScreenName", "", "SubModuleId=" + drpSubModules.SelectedValue + " And ScreenId Not In (157,158,159)", "ScreenName");
        //clear list box
        lstNonMandatory_fields.Items.Clear();
        lstMandatory_fields.Items.Clear();
        hdnNotNullFields.Value = "";
        btnDeselectFields.Enabled = btnDeselectAllFields.Enabled = lstMandatory_fields.Items.Count > 0;
        btnSelectAllFields.Enabled = btnSelectFields.Enabled = lstNonMandatory_fields.Items.Count > 0;
        SetToolTip();
    }

    /// <summary>
    /// Handles Screen Dropdown Selected Index Change Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpScreen_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Bind Fields List
        BindFROIeMailRecipients();
    }
    #endregion

    #region Bind Methods
    /// <summary>
    /// Binds All Dropdowns
    /// </summary>
    private void BindDropDowns()
    {
        ComboHelper.FillLookUp(new DropDownList[] { drpModules }, "Module", "ModuleId", "ModuleName", "", "", "ModuleName");

        ListItem lst = drpModules.Items.FindByText("RealEstate");
        if (lst != null)
            drpModules.Items.Remove(lst);

        ListItem lst1 = drpModules.Items.FindByText("Franchise");
        if (lst1 != null)
            drpModules.Items.Remove(lst1);

        SetToolTip();
    }

    /// <summary>
    /// Sets ToolTip
    /// </summary>
    private void SetToolTip()
    {
        //clsGeneral.SetDropDownToolTip(new DropDownList[] { drpModules, drpSubModules, drpScreen });
        clsGeneral.SetListBoxToolTip(new ListBox[] { lstNonMandatory_fields, lstMandatory_fields });
    }

    /// <summary>
    /// Bind Fields List
    /// </summary>
    private void BindFROIeMailRecipients()
    {
        //clear list box
        lstNonMandatory_fields.Items.Clear();
        lstMandatory_fields.Items.Clear();
        hdnNotNullFields.Value = "";
        DataSet dsData = clsScreen_Validators.SelectByScreen(Convert.ToInt32(drpScreen.SelectedValue));
        DataRow[] drSelect = dsData.Tables[0].Select("", "Field_Name asc");
        if (drSelect != null)
        {
            foreach (DataRow dr in drSelect)
            {
                if (Convert.ToString(dr["IsRequired"]) == "1" || Convert.ToString(dr["AllowNull"]) == "0")
                {
                    lstMandatory_fields.Items.Add(new ListItem(dr["Field_Name"].ToString().Trim(), dr["PK_Screen_Validator"].ToString().Trim()));
                    if (Convert.ToString(dr["AllowNull"]) == "0")
                        hdnNotNullFields.Value += dr["PK_Screen_Validator"].ToString() + ",";
                }
                else
                {
                    lstNonMandatory_fields.Items.Add(new ListItem(dr["Field_Name"].ToString().Trim(), dr["PK_Screen_Validator"].ToString().Trim()));
                }
            }
        }
        hdnNotNullFields.Value = hdnNotNullFields.Value.TrimEnd(',');
        //Enable/Disable buttons
        btnDeselectFields.Enabled = btnDeselectAllFields.Enabled = lstMandatory_fields.Items.Count > 0; //imgUp.Enabled = imgDown.Enabled = 
        btnSelectAllFields.Enabled = btnSelectFields.Enabled = lstNonMandatory_fields.Items.Count > 0;
        SetToolTip();
    }
    #endregion

    #region Mover Events and Methods
    /// <summary>
    /// Event to handle Select Mandatory fields
    /// </summary>
    protected void btnSelectFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstNonMandatory_fields, lstMandatory_fields, true, true, true);
    }

    /// <summary>
    /// Event to handle Deselect Fields
    /// </summary>
    protected void btnDeselectFields_Click(object sender, EventArgs e)
    {
        // get all selected values in comma separated list
        bool bValid = true;
        if (hdnNotNullFields.Value != "")
        {
            string strSelectedVals = "";
            foreach (ListItem lst in lstMandatory_fields.Items)
            {
                if (lst.Selected)
                {
                    strSelectedVals += lst.Value + ",";
                }
            }
            strSelectedVals = strSelectedVals.TrimEnd(',');

            // get arrays of selected values and not null values
            string[] strSelecteds = strSelectedVals.Split(',');
            string[] strNotNulls = hdnNotNullFields.Value.Split(',');

            // get count for the match of selected value and not null value
            int intCnt = 0;
            foreach (string strSelected in strSelecteds)
            {
                foreach (string strNotNull in strNotNulls)
                {
                    if (strSelected == strNotNull) intCnt++;
                }
            }

            // if count are same (i.e all selected values are not null values) then show message
            if (intCnt == strSelecteds.Length) bValid = false;
        }
        if (!bValid)
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('Selected field(s) are having Not Null option set in DB');", true);
        else
            MoveListBoxItems(lstMandatory_fields, lstNonMandatory_fields, true, false, true);
    }

    /// <summary>
    /// Event to Handle select All output fields.
    /// </summary>
    protected void btnSelectAllFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstNonMandatory_fields, lstMandatory_fields, false, true, true);
    }

    /// <summary>
    /// Event to handle DeSelect All Output Fields.
    /// </summary>
    protected void btnDeselectAllFields_Click(object sender, EventArgs e)
    {
        bool bValid = true;
        if (hdnNotNullFields.Value != "")
        {
            string[] strNotNulls = hdnNotNullFields.Value.Split(',');
            if (strNotNulls.Length == lstMandatory_fields.Items.Count) bValid = false;
        }
        if (!bValid)
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('Field(s) are having Not Null option set in DB');", true);
        else
            MoveListBoxItems(lstMandatory_fields, lstNonMandatory_fields, false, false, true);
    }

    /// <summary>
    /// Move Fields from One List to Another List and add/Remove From Sort and group by DropDown
    /// </summary>
    /// <param name="lstFrom"></param>
    /// <param name="lstTo"></param>
    /// <param name="OnlySelected"></param>
    /// <param name="IsSelect"></param>
    private void MoveListBoxItems(ListBox lstFrom, ListBox lstTo, bool OnlySelected, bool IsSelect, bool bSort)
    {
        string[] strNotNulls = hdnNotNullFields.Value.Split(',');
        List<ListItem> lstSelected = new List<ListItem>();
        foreach (ListItem liSelcted in lstFrom.Items)
        {
            // If List item is selected then move it to Selected Output field list and add to list objects
            if ((OnlySelected && liSelcted.Selected) || (!OnlySelected))
            {
                liSelcted.Selected = false;
                // keep fields with not null in DB in mandatory list
                if (hdnNotNullFields.Value != "")
                {
                    int cnt = 0;
                    foreach (string strNotNull in strNotNulls)
                    {
                        if (liSelcted.Value.ToString() == strNotNull)
                        {
                            cnt++;
                            break;
                        }
                    }
                    if (cnt == 0)
                        lstTo.Items.Add(liSelcted);
                }
                else
                    lstTo.Items.Add(liSelcted);
                lstSelected.Add(liSelcted);
            }
        }

        // remove all selected list items from output fields
        for (int i = 0; i < lstSelected.Count; i++)
        {
            // remove fields for those Allow null is set in DB 
            if (hdnNotNullFields.Value != "")
            {
                int cnt = 0;
                foreach (string strNotNull in strNotNulls)
                {
                    if (((ListItem)lstSelected[i]).Value.ToString() == strNotNull)
                    {
                        cnt++;
                        break;
                    }
                }
                if (cnt == 0)
                    lstFrom.Items.Remove(lstSelected[i] as ListItem);
            }
            else
                lstFrom.Items.Remove(lstSelected[i] as ListItem);
        }
        // sort FROI E-Mail Recipients Field
        if (bSort == true && lstTo.Items.Count > 0)
        {
            DataTable dtFields = new DataTable();
            dtFields.Columns.Add(new DataColumn("PK_Screen_Validator", typeof(decimal)));
            dtFields.Columns.Add(new DataColumn("Field_Name", typeof(string)));

            foreach (ListItem itmField in lstTo.Items)
            {
                DataRow drField = dtFields.NewRow();
                drField["PK_Screen_Validator"] = itmField.Value;
                drField["Field_Name"] = itmField.Text;
                dtFields.Rows.Add(drField);
            }
            dtFields.DefaultView.Sort = "Field_Name ASC";
            lstTo.Items.Clear();
            lstTo.DataSource = dtFields.DefaultView;
            lstTo.DataTextField = "Field_Name";
            lstTo.DataValueField = "PK_Screen_Validator";
            lstTo.DataBind();
        }

        // If Selected output list is empty then Disable Moving buttons and Up-Down images
        if (lstMandatory_fields.Items.Count <= 0)
        {
            btnDeselectFields.Enabled = false;
            btnDeselectAllFields.Enabled = false;//imgUp.Enabled = imgDown.Enabled = 
        }
        else
        {
            btnDeselectFields.Enabled = true;
            btnDeselectAllFields.Enabled = true;//imgUp.Enabled = imgDown.Enabled = 
        }
        // IF output Fields is Empty
        if (lstNonMandatory_fields.Items.Count <= 0)
        {
            btnSelectFields.Enabled = false;
            btnSelectAllFields.Enabled = false;
        }
        else
        {
            btnSelectFields.Enabled = true;
            btnSelectAllFields.Enabled = true;
        }
        //set control Tooltip
        SetToolTip();
    }
    #endregion
}