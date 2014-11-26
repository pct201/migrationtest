using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using System.IO;
using System.Collections;

public partial class Administrator_Business_Rule_Management : clsBasePage
{
    #region "Property"
    /// <summary>
    /// Stores the primary key
    /// </summary>
    public decimal PK_Business_Rule_Managgement
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Business_Rule_Managgement"]);
        }
        set { ViewState["PK_Business_Rule_Managgement"] = value; }
    }
    /// <summary>
    /// Stores the mode of the page(edit,view,add)
    /// </summary>
    public string strMode
    {
        get { return (!clsGeneral.IsNull(Request.QueryString["mode"]) ? Convert.ToString(Request.QueryString["mode"]) : ""); }
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
        if (!IsPostBack)
        {
            BindModule();
            ClearAllFilterPanel();
            ClearActionFilterPanel();
            // Reset Scroll Position
            ResetScrollPosition();

            if (Request.QueryString["id"] != null)
            {
                PK_Business_Rule_Managgement = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
            }

            if (PK_Business_Rule_Managgement > 0 && strMode == "edit")
            {
                BindForEdit();
            }
        }
        else
        {
            // This condition is execute when User Enter reprot name which is already exists & User Confirm overwrite existing report
            string eventTarget = (this.Request["__EVENTTARGET"] == null) ? string.Empty : this.Request["__EVENTTARGET"];
            string eventArgument = (this.Request["__EVENTARGUMENT"] == null) ? string.Empty : this.Request["__EVENTARGUMENT"];

            // if postback by Confirmation dialog then save record
            if (eventTarget == "UserConfirmationPostBack")
            {
                if (eventArgument == "true")
                    SaveRule(true);
            }

            #region "Maintain Attribute"

            ////Maintain Attribute of Textbox after PostBack
            //if (drpFilter1.SelectedItem != null)
            //{
            //    if (drpFilter1.SelectedItem.Text == "Operator Age")
            //        drpAmount_Changed(false, drpAmount_F1, lblAmountText1_F1, txtAmount1_F1, lblAmountText2_F1, txtAmount2_F1, cvAmount1);
            //}
            //if (drpFilter2.SelectedItem != null)
            //{
            //    if (drpFilter2.SelectedItem.Text == "Operator Age")
            //        drpAmount_Changed(false, drpAmount_F2, lblAmountText1_F2, txtAmount1_F2, lblAmountText2_F2, txtAmount2_F2, cvAmount2);
            //}
            //if (drpFilter3.SelectedItem != null)
            //{
            //    if (drpFilter3.SelectedItem.Text == "Operator Age")
            //        drpAmount_Changed(false, drpAmount_F3, lblAmountText1_F3, txtAmount1_F3, lblAmountText2_F3, txtAmount2_F3, cvAmount3);
            //}
            //if (drpFilter4.SelectedItem != null)
            //{
            //    if (drpFilter4.SelectedItem.Text == "Operator Age")
            //        drpAmount_Changed(false, drpAmount_F4, lblAmountText1_F4, txtAmount1_F4, lblAmountText2_F4, txtAmount2_F4, cvAmount4);
            //}
            //if (drpFilter5.SelectedItem != null)
            //{
            //    if (drpFilter5.SelectedItem.Text == "Operator Age")
            //        drpAmount_Changed(false, drpAmount_F5, lblAmountText1_F5, txtAmount1_F5, lblAmountText2_F5, txtAmount2_F5, cvAmount5);
            //}

            #endregion
        }
    }

    #endregion

    #region "Events"
    /// <summary>
    /// btnCancel click event handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Business_Rule_List.aspx");
    }
    /// <summary>
    /// btnSave click event handler, saves the rule
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveRule(false);
    }

    /// <summary>
    /// Event to Handle Clear all COntrol
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        drpModule.SelectedIndex = 0;
        drpScreen.Items.Clear();
        drpScreen.Items.Insert(0, new ListItem("-- Select --", "0"));
        ClearAllFilterPanel();
        ClearControls();
        ClearAllDropDown();
        drpAction_Type.Enabled = false;
        rdListEvaluation.SelectedIndex = 0;
        drpAction_Type.SelectedIndex = 0;
        txtRuleName.Text = string.Empty;
        txtDescription.Text = string.Empty;
        ClearActionControls();
        ClearActionFilterPanel();
        divUpdate_Action.Style.Add("display", "none");
        divEmail_Action.Style.Add("display", "none");
        divDiary_Action.Style.Add("display", "none");
        drpFilter_Action.Items.Clear();
        PK_Business_Rule_Managgement = 0;
        chkCurrentUser.Checked = false;
        chkContactFields.ClearSelection();
        // maintain Scroll Bar Possition on Post Back
        ResetScrollPosition();

    }

    /// <summary>
    /// Select Relative Date
    /// </summary>
    protected void RaltiveDatesSaveClick(string senderID)
    {
        //Set Relative Date TextBox , Date image and Manage Enable,Disable
        switch (senderID)
        {
            case "ucRelativeDatesFrom_1":
                if (ucRelativeDatesFrom_1.RelativeDate != Business_RuleHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_From1, imgDate_Opened_From1, true);
                    txtDate_From1.Text = Business_RuleHelper.GetRelativeDate(ucRelativeDatesFrom_1.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_From1, imgDate_Opened_From1, false);
                break;
            case "ucRelativeDatesTo_1":
                if (ucRelativeDatesTo_1.RelativeDate != Business_RuleHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_To1, imgDate_To1, true);
                    txtDate_To1.Text = Business_RuleHelper.GetRelativeDate(ucRelativeDatesTo_1.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_To1, imgDate_To1, true);
                break;
            case "ucRelativeDatesFrom_2":
                if (ucRelativeDatesFrom_2.RelativeDate != Business_RuleHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_From2, imgDate_Opened_From2, true);
                    txtDate_From2.Text = Business_RuleHelper.GetRelativeDate(ucRelativeDatesFrom_2.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_From2, imgDate_Opened_From2, false);
                break;
            case "ucRelativeDatesTo_2":
                if (ucRelativeDatesTo_2.RelativeDate != Business_RuleHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDateTo2, imgDate_To2, true);
                    txtDateTo2.Text = Business_RuleHelper.GetRelativeDate(ucRelativeDatesTo_2.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDateTo2, imgDate_To2, false);
                break;
            case "ucRelativeDatesFrom_3":
                if (ucRelativeDatesFrom_3.RelativeDate != Business_RuleHelper.RaltiveDates.NotSet)
                {
                    txtDate_From3.Text = Business_RuleHelper.GetRelativeDate(ucRelativeDatesFrom_3.RelativeDate).ToString("MM/dd/yyyy");
                    SetRelativeDateControl(txtDate_From3, imgDate_Opened_From3, true);
                }
                else SetRelativeDateControl(txtDate_From3, imgDate_Opened_From3, false);
                break;
            case "ucRelativeDatesTo_3":
                if (ucRelativeDatesTo_3.RelativeDate != Business_RuleHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_To3, imgDate_To3, true);
                    txtDate_To3.Text = Business_RuleHelper.GetRelativeDate(ucRelativeDatesTo_3.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_To3, imgDate_To3, false);

                break;
            case "ucRelativeDatesFrom_4":
                if (ucRelativeDatesFrom_4.RelativeDate != Business_RuleHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_From4, imgDate_Opened_From4, true);
                    txtDate_From4.Text = Business_RuleHelper.GetRelativeDate(ucRelativeDatesFrom_4.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_From4, imgDate_Opened_From4, false);
                break;
            case "ucRelativeDatesTo_4":
                if (ucRelativeDatesTo_4.RelativeDate != Business_RuleHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_To4, imgDate_To4, true);
                    txtDate_To4.Text = Business_RuleHelper.GetRelativeDate(ucRelativeDatesTo_4.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_To4, imgDate_To4, false);
                break;
            case "ucRelativeDatesFrom_5":
                if (ucRelativeDatesFrom_5.RelativeDate != Business_RuleHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_From5, imgDate_Opened_From5, true);
                    txtDate_From5.Text = Business_RuleHelper.GetRelativeDate(ucRelativeDatesFrom_5.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_From5, imgDate_Opened_From5, false);
                break;
            case "ucRelativeDatesTo_5":
                if (ucRelativeDatesTo_5.RelativeDate != Business_RuleHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_To5, imgDate_To5, true);
                    txtDate_To5.Text = Business_RuleHelper.GetRelativeDate(ucRelativeDatesTo_5.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_To5, imgDate_To5, false);
                break;
            case "ucRelativeDatesFrom_Action":
                if (ucRelativeDatesFrom_Action.RelativeDate != Business_RuleHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_From_Action, imgDate_Opened_From_Action, true);
                    txtDate_From_Action.Text = Business_RuleHelper.GetRelativeDate(ucRelativeDatesFrom_Action.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_From_Action, imgDate_Opened_From_Action, false);
                break;
            case "ucRelativeDatesTo_Action":
                if (ucRelativeDatesTo_Action.RelativeDate != Business_RuleHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_To_Action, imgDate_To_Action, true);
                    txtDate_To_Action.Text = Business_RuleHelper.GetRelativeDate(ucRelativeDatesTo_Action.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_To_Action, imgDate_To_Action, false);
                break;
            default:

                break;
        }
    }

    #endregion

    #region "Selected Index Change"
    /// <summary>
    /// Handles the Derived filter selected index change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpFilter_Derived_SelectedIndexChanged(object sender, EventArgs e)
    {
        decimal decSelectedValue = 0;
        if (drpFilter_Derived.Items.Count > 0 && drpFilter_Derived.SelectedIndex >= 0)
            decSelectedValue = Convert.ToDecimal(drpFilter_Derived.SelectedItem.Value);
        List<ERIMS.DAL.clsBusiness_Rules_Fields> lstAdHoc = null;

        if (decSelectedValue > 0)
            lstAdHoc = new ERIMS.DAL.clsBusiness_Rules_Fields().SelectByPK(decSelectedValue);

        if (lstAdHoc != null && lstAdHoc.Count > 0)
        {
            switch (lstAdHoc[0].Field_Type.Value)
            {
                case (int)Business_RuleHelper.ControlType.TextBox:
                    txtNumber_Derived.Visible = false;
                    txtText_Derived.Visible = true;
                    txtNumber_Derived.Text = string.Empty;
                    txtText_Derived.Text = string.Empty;
                    drpDerived_Add.Visible = true;
                    ListItem lstText = drpDerived_Add.Items.FindByValue("-");
                    if (lstText != null)
                        drpDerived_Add.Items.Remove(lstText);
                    break;
                case (int)Business_RuleHelper.ControlType.MultiSelectList:
                    txtNumber_Derived.Visible = false;
                    txtText_Derived.Visible = false;
                    txtNumber_Derived.Text = string.Empty;
                    txtText_Derived.Text = string.Empty;
                    drpDerived_Add.Visible = false;
                    break;
                case (int)Business_RuleHelper.ControlType.DateControl:
                    txtNumber_Derived.Visible = true;
                    txtText_Derived.Visible = false;
                    txtNumber_Derived.Text = string.Empty;
                    txtText_Derived.Text = string.Empty;
                    drpDerived_Add.Visible = true;
                    ListItem lstDate = drpDerived_Add.Items.FindByValue("-");
                    if (lstDate == null)
                        drpDerived_Add.Items.Add(new ListItem(" - ", "-"));
                    break;
                case (int)Business_RuleHelper.ControlType.AmountControl:
                    txtNumber_Derived.Visible = true;
                    txtText_Derived.Visible = false;
                    txtNumber_Derived.Text = string.Empty;
                    txtText_Derived.Text = string.Empty;
                    drpDerived_Add.Visible = true;
                    ListItem lstAmount = drpDerived_Add.Items.FindByValue("-");
                    if (lstAmount == null)
                        drpDerived_Add.Items.Add(new ListItem(" - ", "-"));
                    break;
                case (int)Business_RuleHelper.ControlType.IntNumberControl:
                    txtNumber_Derived.Visible = true;
                    txtText_Derived.Visible = false;
                    txtNumber_Derived.Text = string.Empty;
                    txtText_Derived.Text = string.Empty;
                    drpDerived_Add.Visible = true;
                    ListItem lstNumber = drpDerived_Add.Items.FindByValue("-");
                    if (lstNumber == null)
                        drpDerived_Add.Items.Add(new ListItem(" - ", "-"));
                    break;
                default:
                    txtNumber_Derived.Visible = false;
                    txtText_Derived.Visible = false;
                    drpDerived_Add.Visible = false;
                    break;
            }
        }

    }
    /// <summary>
    /// Handles the event to set the type of the new value in the case of action type update
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpDirectDerived_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpDirectDerived.SelectedValue == "False")
        {
            if (drpFilter_Action.SelectedIndex > 0)
            {
                decimal decSelectedValue = 0;
                if (drpFilter_Action.Items.Count > 0 && drpFilter_Action.SelectedIndex > 0)
                    decSelectedValue = Convert.ToDecimal(drpFilter_Action.SelectedItem.Value);
                List<ERIMS.DAL.clsBusiness_Rules_Fields> lstAdHoc = null;

                if (decSelectedValue > 0)
                    lstAdHoc = new ERIMS.DAL.clsBusiness_Rules_Fields().SelectByPK(decSelectedValue);

                if (lstAdHoc != null && lstAdHoc.Count > 0)
                {
                    switch (lstAdHoc[0].Field_Type.Value)
                    {
                        case (int)Business_RuleHelper.ControlType.MultiSelectList:
                            if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location d/b/a" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "dealership/collision center"
                                            || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "dealership dba" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "sonic location d/b/a")
                            {
                                //ComboHelper.FillLocationDBA_AllCRMAdHoc(new ListBox[] { lst_F }, 0, false);
                                ComboHelper.FillLocationDBA_All(new DropDownList[] { lst_F_Action }, 0, false);
                            }
                            else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "legal entity" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "legal entity name")
                            {
                                //  ComboHelper.FillDistinctLocationLegal_EntityList(new ListBox[] { lst_F }, false);
                                ComboHelper.FillLocationLegal_Entity(new DropDownList[] { lst_F_Action },0, false);
                            }
                            else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location f/k/a")
                            {
                                ComboHelper.FillLocationfka(new DropDownList[] { lst_F_Action }, 0, false);
                            }
                            else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "sonic location code" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location number")
                            {
                                ComboHelper.FillSonicLocationNumberOnly(new DropDownList[] { lst_F_Action },0 ,false);
                            }
                            else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location rm number")
                            {
                                ComboHelper.FillSonicLocationNumber(new DropDownList[] { lst_F_Action }, 0, false);
                                lst_F_Action.Style.Remove("font-size");
                            }
                            else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "associate state")
                            {
                                ComboHelper.FillState(new DropDownList[] { lst_F_Action }, 0, false);
                            }
                            else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "primary/physical state" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "building state"
                                   || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "insured state" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "payees state"
                                   || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "assessment state")
                            {
                                ComboHelper.FillStateDropdownByDesc(new DropDownList[] { lst_F_Action }, false);
                            }
                            else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "investigation status" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "investigation - status")
                            {
                                FillInvestigationDropDown(new DropDownList[] { lst_F_Action }, false);
                            }
                            else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "property contact type")
                            {
                                FillPropertyContactDropDown(new DropDownList[] { lst_F_Action }, false);
                            }
                            else
                            Business_RuleHelper.FillFilterDropDownAction(lstAdHoc[0].Field_Name, new DropDownList[] { lst_F_Action }, true, GetMajorClaimCondition(Convert.ToDecimal(drpModule.SelectedValue)));
                            pnlMultiSelect_F_Action.Visible = true;
                            pnlText_F_Action.Visible = false;
                            pnlAmount_F_Action.Visible = false;
                            pnlNumber_F_Action.Visible = false;
                            pnlDate_F_Action.Visible = false;
                            lst_F_Action.Visible = true;
                            spnNewValue.Visible = true;
                            drpDirectDerived.Visible = true;
                            tdAction.Style.Add("display", "block");
                            tdDerived.Style.Add("display", "none");
                            spnNewValue.InnerText = "New Value:";
                            break;
                        default:
                            pnlText_F_Action.Visible = false;
                            pnlAmount_F_Action.Visible = false;
                            pnlNumber_F_Action.Visible = false;
                            pnlDate_F_Action.Visible = false;
                            lst_F_Action.Visible = false;
                            tdAction.Style.Add("display", "none");
                            tdDerived.Style.Add("display", "block");
                            //spnNewValue.InnerText = " = ";
                            spnNewValue.Visible = true;
                            drpDirectDerived.Visible = true;
                            drpFilter_Derived.Visible = true;
                            drpDerived_Add.Visible = true;
                            DrivedFilterBound();
                            break;
                    }
                }
            }
        }
        else
        {
            tdAction.Style.Add("display", "block");
            tdDerived.Style.Add("display", "none");
            spnNewValue.InnerText = "New Value:";
            if (drpFilter_Action.SelectedIndex > 0)
            {
                decimal decSelectedValue = 0;
                if (drpFilter_Action.Items.Count > 0 && drpFilter_Action.SelectedIndex > 0)
                    decSelectedValue = Convert.ToDecimal(drpFilter_Action.SelectedItem.Value);
                List<ERIMS.DAL.clsBusiness_Rules_Fields> lstAdHoc = null;

                if (decSelectedValue > 0)

                    lstAdHoc = new ERIMS.DAL.clsBusiness_Rules_Fields().SelectByPK(decSelectedValue);

                if (lstAdHoc != null && lstAdHoc.Count > 0)
                {
                    bool IsDollar = lstAdHoc[0].IsDollar;
                    switch (lstAdHoc[0].Field_Type.Value)
                    {
                        case (int)Business_RuleHelper.ControlType.TextBox:
                            pnlText_F_Action.Visible = true;
                            pnlAmount_F_Action.Visible = false;
                            pnlNumber_F_Action.Visible = false;
                            pnlDate_F_Action.Visible = false;
                            lst_F_Action.Visible = false;
                            spnNewValue.Visible = true;
                            drpDirectDerived.Visible = true;
                            SetDefaultTExtBox(pnlText_F_Action.ID);
                            break;
                        case (int)Business_RuleHelper.ControlType.MultiSelectList:
                            if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location d/b/a" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "dealership/collision center"
                                            || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "dealership dba" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "sonic location d/b/a")
                            {
                                //ComboHelper.FillLocationDBA_AllCRMAdHoc(new ListBox[] { lst_F }, 0, false);
                                ComboHelper.FillLocationDBA_All(new DropDownList[] { lst_F_Action }, 0, false);
                            }
                            else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "legal entity" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "legal entity name")
                            {
                                //  ComboHelper.FillDistinctLocationLegal_EntityList(new ListBox[] { lst_F }, false);
                                ComboHelper.FillLocationLegal_Entity(new DropDownList[] { lst_F_Action }, 0, false);
                            }
                            else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location f/k/a")
                            {
                                ComboHelper.FillLocationfka(new DropDownList[] { lst_F_Action }, 0, false);
                            }
                            else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "sonic location code" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location number")
                            {
                                ComboHelper.FillSonicLocationNumberOnly(new DropDownList[] { lst_F_Action }, 0, false);
                            }
                            else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location rm number")
                            {
                                ComboHelper.FillSonicLocationNumber(new DropDownList[] { lst_F_Action }, 0, false);
                                lst_F_Action.Style.Remove("font-size");
                            }
                            else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "associate state")
                            {
                                ComboHelper.FillState(new DropDownList[] { lst_F_Action }, 0, false);
                            }
                            else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "primary/physical state" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "building state"
                                   || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "insured state" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "payees state"
                                   || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "assessment state")
                            {
                                ComboHelper.FillStateDropdownByDesc(new DropDownList[] { lst_F_Action }, false);
                            }
                            else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "investigation status" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "investigations - status")
                            {
                                FillInvestigationDropDown(new DropDownList[] { lst_F_Action }, false);
                            }
                            else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "property contact type")
                            {
                                FillPropertyContactDropDown(new DropDownList[] { lst_F_Action }, false);
                            }
                            else
                                Business_RuleHelper.FillFilterDropDownAction(lstAdHoc[0].Field_Name, new DropDownList[] { lst_F_Action }, true, GetMajorClaimCondition(Convert.ToDecimal(drpModule.SelectedValue)));
                            pnlMultiSelect_F_Action.Visible = true;
                            pnlText_F_Action.Visible = false;
                            pnlAmount_F_Action.Visible = false;
                            pnlNumber_F_Action.Visible = false;
                            pnlDate_F_Action.Visible = false;
                            lst_F_Action.Visible = true;
                            spnNewValue.Visible = true;
                            drpDirectDerived.Visible = true;
                            break;
                        case (int)Business_RuleHelper.ControlType.DateControl:
                            pnlText_F_Action.Visible = false;
                            pnlAmount_F_Action.Visible = false;
                            pnlNumber_F_Action.Visible = false;
                            pnlDate_F_Action.Visible = true;
                            lst_F_Action.Visible = false;
                            spnNewValue.Visible = true;
                            drpDirectDerived.Visible = true;
                            SetDefaultDate(pnlDate_F_Action.ID);
                            break;
                        case (int)Business_RuleHelper.ControlType.AmountControl:
                            pnlText_F_Action.Visible = false;
                            pnlAmount_F_Action.Visible = true;
                            pnlNumber_F_Action.Visible = false;
                            pnlDate_F_Action.Visible = false;
                            lst_F_Action.Visible = false;
                            spnNewValue.Visible = true;
                            drpDirectDerived.Visible = true;
                            SetDefaultAmount(pnlAmount_F_Action.ID, IsDollar);
                            break;
                        case (int)Business_RuleHelper.ControlType.IntNumberControl:
                            pnlText_F_Action.Visible = false;
                            pnlAmount_F_Action.Visible = false;
                            pnlNumber_F_Action.Visible = true;
                            pnlDate_F_Action.Visible = false;
                            lst_F_Action.Visible = false;
                            spnNewValue.Visible = true;
                            drpDirectDerived.Visible = true;
                            txtNumber1_F_Action.Attributes.Remove("MaxLength");

                            if (lstAdHoc[0].Field_Name.IndexOf("Year") > -1)                            
                                txtNumber1_F_Action.Attributes.Add("MaxLength", "4");
                            else if ((lstAdHoc[0].Field_Name.IndexOf("Height") > -1) || (lstAdHoc[0].Field_Name.IndexOf("Weight") > -1))
                                txtNumber1_F_Action.Attributes.Add("MaxLength", "3");
                            else                            
                                txtNumber1_F_Action.Attributes.Add("MaxLength", "8");                            
                            
                            SetDefaultNumber(pnlNumber_F_Action.ID);
                            break;
                        default:
                            pnlText_F_Action.Visible = false;
                            pnlAmount_F_Action.Visible = false;
                            pnlNumber_F_Action.Visible = false;
                            pnlDate_F_Action.Visible = false;
                            lst_F_Action.Visible = false;
                            spnNewValue.Visible = false;
                            drpDirectDerived.Visible = true;
                            break;
                    }
                }
            }
        }

    }
    /// <summary>
    /// Event handler for the filter in the action section
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpFilter_Action_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpFilter_Action.SelectedValue == "0" || drpFilter_Action.Items.Count <= 0)
        {
            pnlMultiSelect_F_Action.Visible = false;
            pnlText_F_Action.Visible = false;
            pnlAmount_F_Action.Visible = false;
            pnlNumber_F_Action.Visible = false;
            pnlDate_F_Action.Visible = false;
            lst_F_Action.Visible = false;
            spnNewValue.Visible = false;
            drpDirectDerived.Visible = false;
        }

        decimal decSelectedValue = 0;
        if (drpFilter_Action.Items.Count > 0 && drpFilter_Action.SelectedIndex > 0)
            decSelectedValue = Convert.ToDecimal(drpFilter_Action.SelectedItem.Value);
        List<ERIMS.DAL.clsBusiness_Rules_Fields> lstAdHoc = null;

        if (decSelectedValue > 0)
            lstAdHoc = new ERIMS.DAL.clsBusiness_Rules_Fields().SelectByPK(decSelectedValue);
        if (drpDirectDerived.SelectedValue == "True")
        {

            tdAction.Style.Add("display", "block");
            tdDerived.Style.Add("display", "none");
            spnNewValue.InnerText = "New Value:";
            if (lstAdHoc != null && lstAdHoc.Count > 0)
            {
                bool IsDollar = lstAdHoc[0].IsDollar;
                switch (lstAdHoc[0].Field_Type.Value)
                {
                    case (int)Business_RuleHelper.ControlType.TextBox:
                        pnlText_F_Action.Visible = true;
                        pnlAmount_F_Action.Visible = false;
                        pnlNumber_F_Action.Visible = false;
                        pnlDate_F_Action.Visible = false;
                        lst_F_Action.Visible = false;
                        spnNewValue.Visible = true;
                        drpDirectDerived.Visible = true;
                        SetDefaultTExtBox(pnlText_F_Action.ID);
                        break;
                    case (int)Business_RuleHelper.ControlType.MultiSelectList:
                        if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location d/b/a" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "dealership/collision center"
                                            || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "dealership dba" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "sonic location d/b/a")
                        {
                            //ComboHelper.FillLocationDBA_AllCRMAdHoc(new ListBox[] { lst_F }, 0, false);
                            ComboHelper.FillLocationDBA_All(new DropDownList[] { lst_F_Action }, 0, false);
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "legal entity" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "legal entity name")
                        {
                            //  ComboHelper.FillDistinctLocationLegal_EntityList(new ListBox[] { lst_F }, false);
                            ComboHelper.FillLocationLegal_Entity(new DropDownList[] { lst_F_Action }, 0, false);
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location f/k/a")
                        {
                            ComboHelper.FillLocationfka(new DropDownList[] { lst_F_Action }, 0, false);
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "sonic location code" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location number")
                        {
                            ComboHelper.FillSonicLocationNumberOnly(new DropDownList[] { lst_F_Action }, 0, false);
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location rm number")
                        {
                            ComboHelper.FillSonicLocationNumber(new DropDownList[] { lst_F_Action }, 0, false);
                            lst_F_Action.Style.Remove("font-size");
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "associate state")
                        {
                            ComboHelper.FillState(new DropDownList[] { lst_F_Action }, 0, false);
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "primary/physical state" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "building state"
                               || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "insured state" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "payees state"
                               || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "assessment state")
                        {
                            ComboHelper.FillStateDropdownByDesc(new DropDownList[] { lst_F_Action }, false);
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "investigation status" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "investigations - status")
                        {
                            FillInvestigationDropDown(new DropDownList[] { lst_F_Action }, false);
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "property contact type")
                        {
                            FillPropertyContactDropDown(new DropDownList[] { lst_F_Action }, false);
                        }
                        else
                            Business_RuleHelper.FillFilterDropDownAction(lstAdHoc[0].Field_Name, new DropDownList[] { lst_F_Action }, true, GetMajorClaimCondition(Convert.ToDecimal(drpModule.SelectedValue)));
                        lst_F_Action.Style["display"] = "block";
                        lst_F_Action.Attributes.CssStyle.Add("display", "block");
                        pnlMultiSelect_F_Action.Visible = true;
                        pnlText_F_Action.Visible = false;
                        pnlAmount_F_Action.Visible = false;
                        pnlNumber_F_Action.Visible = false;
                        pnlDate_F_Action.Visible = false;
                        lst_F_Action.Visible = true;
                        spnNewValue.Visible = true;
                        drpDirectDerived.Visible = true;
                        break;
                    case (int)Business_RuleHelper.ControlType.DateControl:
                        pnlText_F_Action.Visible = false;
                        pnlAmount_F_Action.Visible = false;
                        pnlNumber_F_Action.Visible = false;
                        pnlDate_F_Action.Visible = true;
                        lst_F_Action.Visible = false;
                        spnNewValue.Visible = true;
                        drpDirectDerived.Visible = true;
                        SetDefaultDate(pnlDate_F_Action.ID);
                        break;
                    case (int)Business_RuleHelper.ControlType.AmountControl:
                        pnlText_F_Action.Visible = false;
                        pnlAmount_F_Action.Visible = true;
                        pnlNumber_F_Action.Visible = false;
                        pnlDate_F_Action.Visible = false;
                        lst_F_Action.Visible = false;
                        spnNewValue.Visible = true;
                        drpDirectDerived.Visible = true;
                        SetDefaultAmount(pnlAmount_F_Action.ID, IsDollar);
                        break;
                    case (int)Business_RuleHelper.ControlType.IntNumberControl:
                        pnlText_F_Action.Visible = false;
                        pnlAmount_F_Action.Visible = false;
                        pnlNumber_F_Action.Visible = true;
                        pnlDate_F_Action.Visible = false;
                        lst_F_Action.Visible = false;
                        spnNewValue.Visible = true;
                        drpDirectDerived.Visible = true;
                        txtNumber1_F_Action.Attributes.Remove("MaxLength");

                            if (lstAdHoc[0].Field_Name.IndexOf("Year") > -1)                            
                                txtNumber1_F_Action.Attributes.Add("MaxLength", "4");
                            else if ((lstAdHoc[0].Field_Name.IndexOf("Height") > -1) || (lstAdHoc[0].Field_Name.IndexOf("Weight") > -1))
                                txtNumber1_F_Action.Attributes.Add("MaxLength", "3");
                            else                            
                                txtNumber1_F_Action.Attributes.Add("MaxLength", "8");  
                        SetDefaultNumber(pnlNumber_F_Action.ID);
                        break;
                    default:
                        pnlText_F_Action.Visible = false;
                        pnlAmount_F_Action.Visible = false;
                        pnlNumber_F_Action.Visible = false;
                        pnlDate_F_Action.Visible = false;
                        lst_F_Action.Visible = false;
                        spnNewValue.Visible = false;
                        drpDirectDerived.Visible = false;
                        break;
                }
            }

        }
        else
        {
            if (lstAdHoc[0].Field_Type.Value == (int)Business_RuleHelper.ControlType.MultiSelectList)
            {
                if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location d/b/a" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "dealership/collision center"
                                            || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "dealership dba" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "sonic location d/b/a")
                {
                    //ComboHelper.FillLocationDBA_AllCRMAdHoc(new ListBox[] { lst_F }, 0, false);
                    ComboHelper.FillLocationDBA_All(new DropDownList[] { lst_F_Action }, 0, false);
                }
                else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "legal entity" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "legal entity name")
                {
                    //  ComboHelper.FillDistinctLocationLegal_EntityList(new ListBox[] { lst_F }, false);
                    ComboHelper.FillLocationLegal_Entity(new DropDownList[] { lst_F_Action }, 0, false);
                }
                else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location f/k/a")
                {
                    ComboHelper.FillLocationfka(new DropDownList[] { lst_F_Action }, 0, false);
                }
                else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "sonic location code" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location number")
                {
                    ComboHelper.FillSonicLocationNumberOnly(new DropDownList[] { lst_F_Action }, 0, false);
                }
                else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location rm number")
                {
                    ComboHelper.FillSonicLocationNumber(new DropDownList[] { lst_F_Action }, 0, false);
                    lst_F_Action.Style.Remove("font-size");
                }
                else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "associate state")
                {
                    ComboHelper.FillState(new DropDownList[] { lst_F_Action }, 0, false);
                }
                else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "primary/physical state" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "building state"
                       || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "insured state" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "payees state"
                       || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "assessment state")
                {
                    ComboHelper.FillStateDropdownByDesc(new DropDownList[] { lst_F_Action }, false);
                }
                else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "investigation status" ||  Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "investigations - status")
                {
                    FillInvestigationDropDown(new DropDownList[] { lst_F_Action }, false);
                }
                else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "property contact type")
                {
                    FillPropertyContactDropDown(new DropDownList[] { lst_F_Action }, false);
                }
                else
                    Business_RuleHelper.FillFilterDropDownAction(lstAdHoc[0].Field_Name, new DropDownList[] { lst_F_Action }, true, GetMajorClaimCondition(Convert.ToDecimal(drpModule.SelectedValue)));
                lst_F_Action.Style["display"] = "block";
                lst_F_Action.Attributes.CssStyle.Add("display", "block");
                pnlMultiSelect_F_Action.Visible = true;
                pnlText_F_Action.Visible = false;
                pnlAmount_F_Action.Visible = false;
                pnlNumber_F_Action.Visible = false;
                pnlDate_F_Action.Visible = false;
                lst_F_Action.Visible = true;
                spnNewValue.Visible = true;
                drpDirectDerived.Visible = true;
                tdAction.Style.Add("display", "block");
                tdDerived.Style.Add("display", "none");
                spnNewValue.InnerText = "New Value:";
            }
            else
            {
                spnNewValue.Visible = true;
                tdAction.Style.Add("display", "none");
                tdDerived.Style.Add("display", "block");
                //spnNewValue.InnerText = " = ";
            }
        }
    }
    /// <summary>
    /// Makes the appropiate controls visible for the action type selected
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpAction_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpAction_Type.SelectedIndex > 0)
        {
            switch (drpAction_Type.SelectedValue)
            {
                case "Update":
                    ClearActionControls();
                    ClearActionFilterPanel();
                    divUpdate_Action.Style.Add("display", "block");
                    divEmail_Action.Style.Add("display", "none");
                    divDiary_Action.Style.Add("display", "none");
                    drpFilter_Action.SelectedIndex = 0;
                    break;
                case "Email":
                    ClearActionControls();
                    ClearActionFilterPanel();
                    BindCheckBoxlists();
                    divEmail_Action.Style.Add("display", "block");
                    divUpdate_Action.Style.Add("display", "none");
                    divDiary_Action.Style.Add("display", "none");
                    drpFilter_Action.SelectedIndex = 0;
                    break;
                case "Diary":
                    ClearActionControls();
                    ClearActionFilterPanel();
                    chkCurrentUser.Checked = false;
                    chkContactFields.ClearSelection();
                    divDiary_Action.Style.Add("display", "block");
                    divEmail_Action.Style.Add("display", "none");
                    divUpdate_Action.Style.Add("display", "none");
                    drpFilter_Action.SelectedIndex = 0;

                    //bind record contact list for assigned to 
                    clsBusiness_Rules_Fields objBusiness_Rules_Fields = new clsBusiness_Rules_Fields();
                    DataSet ds = objBusiness_Rules_Fields.SelectByFKAction(Convert.ToDecimal(drpScreen.SelectedValue), false);
                    DataTable dtEmailFields = ds.Tables[0];
                    dtEmailFields.DefaultView.RowFilter = "IsEmailAddress='True'";
                    chkContactFields.DataSource = dtEmailFields.DefaultView;
                    chkContactFields.DataTextField = "ContactType";
                    chkContactFields.DataValueField = "PK_Business_Rules_Fields";
                    chkContactFields.DataBind();
                    trAssignedContact.Visible = drpModule.SelectedItem.Text != "Incident";
                    break;
                default:
                    break;
            }
        }
        else
        {
            divDiary_Action.Style.Add("display", "none");
            divEmail_Action.Style.Add("display", "none");
            divUpdate_Action.Style.Add("display", "none");
        }
    }
    /// <summary>
    /// Fills the field names for the filter criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpScreen_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpScreen.SelectedIndex > 0)
        {
            ClearAllFilterPanel();
            ClearControls();
            ClearNotCheckCriteria();
            ClearActionControls();
            ClearActionFilterPanel();
            decimal PK_Screen = Convert.ToDecimal(drpScreen.SelectedValue);
            clsBusiness_Rules_Fields objBusiness_Rules_Fields = new clsBusiness_Rules_Fields();
            DataSet ds = objBusiness_Rules_Fields.SelectByFK(PK_Screen);
            ds.Tables[0].DefaultView.RowFilter = "IsEmailAddress='False'";
            drpFilter1.DataSource = ds.Tables[0].DefaultView;
            drpFilter1.DataTextField = "On_Screen_Descriptior";
            drpFilter1.DataValueField = "PK_Business_Rules_Fields";
            drpFilter1.DataBind();
            drpFilter1.Items.Insert(0, new ListItem("-- Select --", "0"));
            drpFilter1.SelectedIndex = 0;
            drpFilter2.DataSource = ds.Tables[0].DefaultView;
            drpFilter2.DataTextField = "On_Screen_Descriptior";
            drpFilter2.DataValueField = "PK_Business_Rules_Fields";
            drpFilter2.DataBind();
            drpFilter2.Items.Insert(0, new ListItem("-- Select --", "0"));
            drpFilter2.SelectedIndex = 0;
            drpFilter3.DataSource = ds.Tables[0].DefaultView;
            drpFilter3.DataTextField = "On_Screen_Descriptior";
            drpFilter3.DataValueField = "PK_Business_Rules_Fields";
            drpFilter3.DataBind();
            drpFilter3.Items.Insert(0, new ListItem("-- Select --", "0"));
            drpFilter3.SelectedIndex = 0;
            drpFilter4.DataSource = ds.Tables[0].DefaultView;
            drpFilter4.DataTextField = "On_Screen_Descriptior";
            drpFilter4.DataValueField = "PK_Business_Rules_Fields";
            drpFilter4.DataBind();
            drpFilter4.Items.Insert(0, new ListItem("-- Select --", "0"));
            drpFilter4.SelectedIndex = 0;
            drpFilter5.DataSource = ds.Tables[0].DefaultView;
            drpFilter5.DataTextField = "On_Screen_Descriptior";
            drpFilter5.DataValueField = "PK_Business_Rules_Fields";
            drpFilter5.DataBind();
            drpFilter5.Items.Insert(0, new ListItem("-- Select --", "0"));
            drpFilter5.SelectedIndex = 0;

            BindCheckBoxlists();

            DataSet dsAction = objBusiness_Rules_Fields.SelectByFKAction(PK_Screen, true);
            if (dsAction.Tables[0].Rows.Count > 0)
            {
                //DataSet dsAction = objBusiness_Rules_Fields.SelectByFKAction(Convert.ToDecimal(drpModule.SelectedValue), true);
                dsAction.Tables[0].DefaultView.RowFilter = "IsEmailAddress='False'";
                drpFilter_Action.DataSource = dsAction.Tables[0].DefaultView;
                drpFilter_Action.DataTextField = "On_Screen_Descriptior";
                drpFilter_Action.DataValueField = "PK_Business_Rules_Fields";
                drpFilter_Action.DataBind();
                drpFilter_Action.Items.Insert(0, new ListItem("-- Select --", "0"));
                drpFilter_Action.SelectedIndex = 0;

                drpFilter_Derived.DataSource = dsAction.Tables[0].DefaultView;
                drpFilter_Derived.DataTextField = "On_Screen_Descriptior";
                drpFilter_Derived.DataValueField = "PK_Business_Rules_Fields";
                drpFilter_Derived.DataBind();
            }
            else
            {
                drpFilter_Action.Items.Clear();
                drpFilter_Action.Items.Insert(0, new ListItem("-- Select --", "0"));
                drpFilter_Action.SelectedIndex = 0;
                drpFilter_Derived.Items.Clear();
                drpFilter_Derived.Items.Insert(0, new ListItem("-- Select --", "0"));
                drpFilter_Derived.SelectedIndex = 0;
            }
            //DrivedFilterBound();
            drpAction_Type.Enabled = true;
            drpAction_Type.SelectedIndex = 0;

            if (drpScreen.SelectedValue == "91" || drpScreen.SelectedValue == "12"
                || drpScreen.SelectedValue == "13" || drpScreen.SelectedValue == "23" || drpScreen.SelectedValue == "40"
                || drpScreen.SelectedValue == "41" || drpScreen.SelectedValue == "42" || drpScreen.SelectedValue == "48"
                || drpScreen.SelectedValue == "49")
            {
                if (drpAction_Type.Items.FindByValue("Diary") != null)
                {
                    drpAction_Type.Items.Remove(drpAction_Type.Items.FindByValue("Diary"));
                }
            }
            else
            {
                if (drpAction_Type.Items.FindByValue("Diary") == null)
                {
                    drpAction_Type.Items.Add(new ListItem("Diary", "Diary"));
                }
            }
          
        }
        else
        {
            ClearAllFilterPanel();
            ClearControls();
            ClearAllDropDown();
            ClearActionControls();
            ClearActionFilterPanel();
            ClearNotCheckCriteria();
            drpAction_Type.SelectedIndex = 0;
            drpAction_Type.Enabled = false;
        }
    }
    /// <summary>
    /// Populates the Screen dropdown with the screens in the selected module
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpModule_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpModule.SelectedIndex > 0)
        {
            ClearAllFilterPanel();
            ClearControls();
            ClearAllDropDown();
            ClearActionControls();
            ClearActionFilterPanel();
            ClearNotCheckCriteria();
            decimal PK_Module = Convert.ToDecimal(drpModule.SelectedValue);
            clsBusiness_Rules_Screens objBusiness_Rules_Screens = new clsBusiness_Rules_Screens();
            DataSet ds = objBusiness_Rules_Screens.SelectByFK(PK_Module);
            drpScreen.DataSource = ds.Tables[0];
            drpScreen.DataTextField = "Screen";
            drpScreen.DataValueField = "PK_Business_Rules_Screens";
            drpScreen.DataBind();
            drpScreen.Items.Insert(0, new ListItem("-- Select --", "0"));
            drpAction_Type.SelectedIndex = 0;
            drpFilter_Action.Items.Clear();
            drpFilter_Action.Items.Insert(0, new ListItem("-- Select --", "0"));

            if (drpModule.SelectedValue == "0" || drpModule.SelectedValue == "0" || drpModule.SelectedValue == "0")
            {
                if (drpAction_Type.Items.FindByValue("Diary") != null)
                {
                    drpAction_Type.Items.Remove(drpAction_Type.Items.FindByValue("Diary"));
                }
            }
            else
            {
                if (drpAction_Type.Items.FindByValue("Diary") == null)
                {
                    drpAction_Type.Items.Add(new ListItem("Diary", "Diary"));
                }
            }
            drpAction_Type.SelectedIndex = 0;
            drpAction_Type.Enabled = false;
        }
        else
        {
            drpScreen.Items.Clear();
            drpScreen.Items.Insert(0, new ListItem("-- Select --", "0"));
            drpFilter_Action.Items.Clear();
            drpFilter_Action.Items.Insert(0, new ListItem("-- Select --", "0"));
            ClearAllFilterPanel();
            ClearControls();
            ClearAllDropDown();
            ClearActionControls();
            ClearActionFilterPanel();
            ClearNotCheckCriteria();
            drpAction_Type.SelectedIndex = 0;
            drpAction_Type.Enabled = false;
        }
    }
    /// <summary>
    /// Handle dropdown list Change event for all date criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rdbLstDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (((DropDownList)sender).ID)
        {
            case "lstDate1":
                // Set Date control Text and show-hide Date textbox as per selected criteria
                SetDateControls(lstDate1, lblDateFrom1, lblDateTo1, txtDate_From1, txtDate_To1, imgDate_To1, revtxtDate_From1, ucRelativeDatesTo_1);
                txtDate_To1.Text = string.Empty; break;
            case "lstDate2":
                SetDateControls(lstDate2, lblDateFrom2, lblDateTo2, txtDate_From2, txtDateTo2, imgDate_To2, revtxtDate_From2, ucRelativeDatesTo_2);
                txtDateTo2.Text = string.Empty;
                break;
            case "lstDate3":
                SetDateControls(lstDate3, lblDateFrom3, lblDateTo3, txtDate_From3, txtDate_To3, imgDate_To3, revtxtDate_From3, ucRelativeDatesTo_3);
                txtDate_To3.Text = string.Empty; break;
            case "lstDate4":
                SetDateControls(lstDate4, lblDateFrom4, lblDateTo4, txtDate_From4, txtDate_To4, imgDate_To4, revtxtDate_From4, ucRelativeDatesTo_4);
                txtDate_To4.Text = string.Empty; break;
            case "lstDate5":
                SetDateControls(lstDate5, lblDateFrom5, lblDateTo5, txtDate_From5, txtDate_To5, imgDate_To5, revtxtDate_From5, ucRelativeDatesTo_5);
                txtDate_To5.Text = string.Empty; break;
            case "lstDate_Action":
                SetDateControls(lstDate_Action, lblDateFrom_Action, lblDateTo_Action, txtDate_From_Action, txtDate_To_Action, imgDate_To_Action, revtxtDate_From_Action, ucRelativeDatesTo_Action);
                txtDate_To_Action.Text = string.Empty; break;
            default:
                break;
        }
    }
    /// <summary>
    /// EVent to handle Dropdown filter change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (((DropDownList)sender).ID)
        {
            case "drpFilter1":
                drpFilterChange(drpFilter1, pnlText_F1, pnlAmount_F1, pnlNumber_F1, pnlDate_F1, lst_F1, chkNotCriteria1, spnField1, txtNumber1_F1, txtNumber2_F1);
                break;
            case "drpFilter2":
                drpFilterChange(drpFilter2, pnlText_F2, pnlAmount_F2, pnlNumber_F2, pnlDate_F2, lst_F2, chkNotCriteria2, spnField2, txtNumber1_F2, txtNumber2_F2);
                break;
            case "drpFilter3":
                drpFilterChange(drpFilter3, pnlText_F3, pnlAmount_F3, pnlNumber_F3, pnlDate_F3, lst_F3, chkNotCriteria3, spnField3, txtNumber1_F3, txtNumber2_F3);
                break;
            case "drpFilter4":
                drpFilterChange(drpFilter4, pnlText_F4, pnlAmount_F4, pnlNumber_F4, pnlDate_F4, lst_F4, chkNotCriteria4, spnField4, txtNumber1_F4, txtNumber2_F4);
                break;
            case "drpFilter5":
                drpFilterChange(drpFilter5, pnlText_F5, pnlAmount_F5, pnlNumber_F5, pnlDate_F5, lst_F5, chkNotCriteria5, spnField5, txtNumber1_F5, txtNumber2_F5);
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// Event to handle Amout dropdown change.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpAmount_F_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool isDollar = true;
        switch (((DropDownList)sender).ID)
        {
            case "drpAmount_F1":
                drpAmount_Changed(false, isDollar, drpAmount_F1, lblAmountText1_F1, txtAmount1_F1, lblAmountText2_F1, txtAmount2_F1, cvAmount1);
                break;
            case "drpAmount_F2":
                drpAmount_Changed(false, isDollar, drpAmount_F2, lblAmountText1_F2, txtAmount1_F2, lblAmountText2_F2, txtAmount2_F2, cvAmount2);
                break;
            case "drpAmount_F3":
                drpAmount_Changed(false, isDollar, drpAmount_F3, lblAmountText1_F3, txtAmount1_F3, lblAmountText2_F3, txtAmount2_F3, cvAmount3);
                break;
            case "drpAmount_F4":
                drpAmount_Changed(false, isDollar, drpAmount_F4, lblAmountText1_F4, txtAmount1_F4, lblAmountText2_F4, txtAmount2_F4, cvAmount4);
                break;
            case "drpAmount_F5":
                drpAmount_Changed(false, isDollar, drpAmount_F5, lblAmountText1_F5, txtAmount1_F5, lblAmountText2_F5, txtAmount2_F5, cvAmount5);
                break;
            default:
                break;
        }

    }

    /// <summary>
    /// Event to handle Amout dropdown change.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpNumber_F_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (((DropDownList)sender).ID)
        {
            case "drpNumber_F1":
                drpNumber_Changed(drpNumber_F1, lblNumberText1_F1, txtNumber1_F1, lblNumberText2_F1, txtNumber2_F1, cvNumber1);
                break;
            case "drpNumber_F2":
                drpNumber_Changed(drpNumber_F2, lblNumberText1_F2, txtNumber1_F2, lblNumberText2_F2, txtNumber2_F2, cvNumber2);
                break;
            case "drpNumber_F3":
                drpNumber_Changed(drpNumber_F3, lblNumberText1_F3, txtNumber1_F3, lblNumberText2_F3, txtNumber2_F3, cvNumber3);
                break;
            case "drpNumber_F4":
                drpNumber_Changed(drpNumber_F4, lblNumberText1_F4, txtNumber1_F4, lblNumberText2_F4, txtNumber2_F4, cvNumber4);
                break;
            case "drpNumber_F5":
                drpNumber_Changed(drpNumber_F5, lblNumberText1_F5, txtNumber1_F5, lblNumberText2_F5, txtNumber2_F5, cvNumber5);
                break;
            default:
                break;
        }

    }

    #endregion

    #region "Methods"
    /// <summary>
    /// Sets the controls on derived filter databound
    /// </summary>
    protected void DrivedFilterBound()
    {
        decimal decSelectedValue = 0;
        if (drpFilter_Derived.Items.Count > 0 && drpFilter_Derived.SelectedIndex >= 0)
            decSelectedValue = Convert.ToDecimal(drpFilter_Derived.SelectedItem.Value);
        List<ERIMS.DAL.clsBusiness_Rules_Fields> lstAdHoc = null;

        if (decSelectedValue > 0)
            lstAdHoc = new ERIMS.DAL.clsBusiness_Rules_Fields().SelectByPK(decSelectedValue);

        if (lstAdHoc != null && lstAdHoc.Count > 0)
        {
            switch (lstAdHoc[0].Field_Type.Value)
            {
                case (int)Business_RuleHelper.ControlType.TextBox:
                    txtNumber_Derived.Visible = false;
                    txtText_Derived.Visible = true;
                    txtNumber_Derived.Text = string.Empty;
                    txtText_Derived.Text = string.Empty;
                    drpDerived_Add.Visible = true;
                    ListItem lstText = drpDerived_Add.Items.FindByValue("-");
                    if (lstText != null)
                        drpDerived_Add.Items.Remove(lstText);
                    break;
                case (int)Business_RuleHelper.ControlType.MultiSelectList:
                    txtNumber_Derived.Visible = false;
                    txtText_Derived.Visible = false;
                    txtNumber_Derived.Text = string.Empty;
                    txtText_Derived.Text = string.Empty;
                    drpDerived_Add.Visible = false;
                    break;
                case (int)Business_RuleHelper.ControlType.DateControl:
                    txtNumber_Derived.Visible = true;
                    txtText_Derived.Visible = false;
                    txtNumber_Derived.Text = string.Empty;
                    txtText_Derived.Text = string.Empty;
                    drpDerived_Add.Visible = true;
                    ListItem lstDate = drpDerived_Add.Items.FindByValue("-");
                    if (lstDate == null)
                        drpDerived_Add.Items.Add(new ListItem(" - ", "-"));
                    break;
                case (int)Business_RuleHelper.ControlType.AmountControl:
                    txtNumber_Derived.Visible = true;
                    txtText_Derived.Visible = false;
                    txtNumber_Derived.Text = string.Empty;
                    txtText_Derived.Text = string.Empty;
                    drpDerived_Add.Visible = true;
                    ListItem lstAmount = drpDerived_Add.Items.FindByValue("-");
                    if (lstAmount == null)
                        drpDerived_Add.Items.Add(new ListItem(" - ", "-"));
                    break;
                case (int)Business_RuleHelper.ControlType.IntNumberControl:
                    txtNumber_Derived.Visible = true;
                    txtText_Derived.Visible = false;
                    txtNumber_Derived.Text = string.Empty;
                    txtText_Derived.Text = string.Empty;
                    drpDerived_Add.Visible = true;
                    ListItem lstNumber = drpDerived_Add.Items.FindByValue("-");
                    if (lstNumber == null)
                        drpDerived_Add.Items.Add(new ListItem(" - ", "-"));
                    break;
                default:
                    txtNumber_Derived.Visible = false;
                    txtText_Derived.Visible = false;
                    drpDerived_Add.Visible = false;
                    break;
            }
        }
    }

    private void BindCheckBoxlists()
    {
        if (drpScreen.SelectedIndex > 0)
        {
            decimal PK_Screen = Convert.ToDecimal(drpScreen.SelectedValue);
            clsBusiness_Rules_Fields objBusiness_Rules_Fields = new clsBusiness_Rules_Fields();
            DataSet ds = objBusiness_Rules_Fields.SelectByFKAction(PK_Screen, false);
            //DataSet ds = objBusiness_Rules_Fields.SelectByFKAction(Convert.ToDecimal(drpModule.SelectedValue), false);
            DataTable dtFields = ds.Tables[0];
            DataTable dtEmailFields = ds.Tables[0];

            dtFields.DefaultView.RowFilter = "IsEmailAddress='False'";
            chkFields.DataSource = dtFields.DefaultView;
            chkFields.DataTextField = "On_Screen_Descriptior";
            chkFields.DataValueField = "PK_Business_Rules_Fields";
            chkFields.DataBind();

            dtEmailFields.DefaultView.RowFilter = "IsEmailAddress='True'";
            if (ds.Tables[0].DefaultView.Count > 0)
            {
                chkEmailFields.DataSource = dtEmailFields.DefaultView;
                chkEmailFields.DataTextField = "On_Screen_Descriptior";
                chkEmailFields.DataValueField = "PK_Business_Rules_Fields";
                chkEmailFields.DataBind();
                trRecipientFromRecord.Style.Add("display", "block");
            }
            else
                trRecipientFromRecord.Style.Add("display", "none");
        }
    }
    /// <summary>
    /// Gets bool value for drop down value type
    /// </summary>
    /// <param name="strField"></param>
    /// <returns></returns>
    private bool GetIfDrpValueString(string strField)
    {
        switch (strField)
        {
            case "Above Ground?":
            case "Accept Limits":
            case "Accident State":
            case "Active":
            case "Alarm type":
            case "All Owned Vehicles":
            case "AM Best Rating of A- or Better?":
            case "Annual State Waste Hauler Registration on File?":
            case "Any Auto":
            case "Any In-Ground Lifts Been Removed?":
            case "Any Interest to be Realized on Security Deposit?":
            case "Associate-Body Part Affected ":
            case "Authorized Off Work?":
            case "Auto (If no owned vehicles included in BOP)":
            case "Body Part Affected":
            case "Boiler and Machinery Required?":
            case "Bordereau Report?":
            case "Building State":
            case "Cause of Injury Code":
            case "Certificate of Insurance on File Containing Adequate Amount of Pollution Coverage? ":
            case "Claim Made Y/N":
            case "Claim Status":
            case "Claimant Attorney/Representative Y/N":
            case "COI Active":
            case "COI ON File?":
            case "Combination Water/Solvent?":
            case "Commercial General Liability":
            case "Complete?":
            case "Configured for Water Borne Application?":
            case "Connected to Public Water System?":
            case "Contact State":
            case "Contact Type":
            case "Controverted Case Y/N":
            case "County ":
            case "Coverage Code":
            case "Coverage Form":
            case "Customer Call Back After Resolved?":
            case "Customer Contacted GM?":
            case "Date Last Worked Was a Full Day?":
            case "Date of Service Estimated?":
            case "Deductible ? ":
            case "Deficiencies Corrected - Body Shop":
            case "Deficiencies Corrected - Business Office":
            case "Deficiencies Corrected - Car Wash":
            case "Deficiencies Corrected - Detail Area":
            case "Deficiencies Corrected - Parking Lot":
            case "Deficiencies Corrected - Parts":
            case "Deficiencies Corrected - Sales":
            case "Deficiencies Corrected - Service Facility":
            case "Demand Letter?":
            case "Department":
            case "Departments Reviewed - Body Shop":
            case "Departments Reviewed - Business Office":
            case "Departments Reviewed - Car Wash":
            case "Departments Reviewed - Detail Area":
            case "Departments Reviewed - Parking Lot":
            case "Departments Reviewed - Parts":
            case "Departments Reviewed - Sales":
            case "Departments Reviewed - Service Facility":
            case "Direct or Indirect Burners?":
            case "Distance from body of water (creek, river, ocean)":
            case "Distance":
            case "Documentation Related to Lift Removal Attached?":
            case "Does this Hazardous Waste Hauler data apply to all buildings at this location?":
            case "Does this Inspection data apply to all buildings at this location? ":
            case "Does this Permit data apply to all buildings at this location?":
            case "Does this Phase I data apply to all buildings at this location?":
            case "Does this Receiving TSDF data apply to all buildings at this location?":
            case "Does this Regulatory Inspection data apply to all buildings at this location?":
            case "Does this Remediation data apply to all buildings at this location? ":
            case "Does this Violation data apply to all buildings at this location? ":
            case "Driver Gender":
            case "Driver Marital Status":
            case "Driver Medical Facility State":
            case "Driver State":
            case "Driver’s License State":
            case "Earthquake Required?":
            case "EEOC?":
            case "Employee Gender":
            case "Employee Marital Status":
            case "Employee State":
            case "Filing State":
            case "Financial Security Required?":
            case "Fire Inspection State":
            case "Flood Required?":
            case "Focus Area":
            case "Full Days Worked on Modified Duty?":
            case "Full Final Clincher?":
            case "Generate Envelope?":
            case "Ground Location":
            case "Hazardous Waste Profile Completed and Maintained at Location? ":
            case "Hired Autos":
            case "If No, is there a separate Boiler and Machinery policy?":
            case "If No, is there a separate Earthquake policy?":
            case "If No, is there a separate Flood policy?":
            case "Incident Investigation Reviewed":
            case "Initial Claim Classification":
            case "Injury Occurred - State":
            case "Insurance Company":
            case "Insured Active":
            case "Insured State":
            case "Intrusion Alarms State":
            case "Investigative Quality":
            case "Is Boiler and Machinery coverage included on the Property Policy?":
            case "Is cabinet 6H compliant?":
            case "Is COI Needed?":
            case "Is Earthquake coverage included on the Property Policy?":
            case "Is Flood coverage included on the Property Policy?":
            case "Is Tank Secure during Non-Business Hours?":
            case "Is Tank UL Certified?":
            case "Is this a Repeat Violation?":
            case "Is TSDF Located Farther than 270 miles from Hazardous Waste Generator’s Facility?":
            case "Landlord State":
            case "Law Suit Y/N":
            case "Layered Program?":
            case "Leak Detection Required?":
            case "Leased Employees included":
            case "Legal Confidential?":
            case "Legal/Attorney General?":
            case "Letter N/A?":
            case "Letter of Representation Received?":
            case "Liability":
            case "License Plate State":
            case "Location Code":
            case "Location State":
            case "Loss State":
            case "Manual for Paint Booth location in 6H Binder?":
            case "Manual for Paint Gun Cleaning Cabinet located in 6H Binder?":
            case "Manual for Prep Station location in 6H Binder?":
            case "Medical Facility State":
            case "Moderate Duty Accepted?":
            case "Moderate Duty Available?":
            case "Moderate Duty Offered?":
            case "MVA – Damage (Multiple Vehicle) – Injured Passenger State":
            case "MVA – Damage (Single Vehicle) – Injured Passenger State":
            case "Nature of Injury Code":
            case "NCCI Body Part Code":
            case "NCCI Cause of Injury Code":
            case "NCCI Nature of Injury Code":
            case "NCCI Occupation Class Code":
            case "Non-Owned Autos":
            case "Occupancy State":
            case "Occurrence Form":
            case "Occurrence":
            case "Original or Signed Certificate Received":
            case "Other Driver License State":
            case "Other Driver Medical Facility State":
            case "Other Driver State":
            case "Other Litigation?":
            case "Other Vehicle License Plate State":
            case "Other Vehicle Location Driver State":
            case "Other Vehicle Owner State":
            case "Other Vehicle Passenger State":
            case "Other":
            case "Overfill Protection?":
            case "Owner State":
            case "Ownership":
            case "Panel Counsel Required?":
            case "Part of Body Code":
            case "Passenger License State":
            case "Passenger State":
            case "Payees State":
            case "Payees Type":
            case "Pedestrain State":
            case "Permit Required? ":
            case "Physician’s State":
            case "Post Remediation, No Further Action Letter (from Regulatory Entity) Obtained?":
            case "Product Liability":
            case "Property Contact Type":
            case "Proprietor/Partners/Executive Officers are included":
            case "Question Text":
            case "Quota Share ?":
            case "Region":
            case "Registration Required?":
            case "Regulatory/Notifying Agency":
            case "Resolution Letter to Customer?":
            case "Response N/A?":
            case "Response Sent?":
            case "Retention":
            case "Retroactive":
            case "RLCM Verified?":
            case "Scheduled Autos":
            case "Secondary Containment Adequate?":
            case "Security Cameras State":
            case "Security Deposit Reduced?":
            case "Security Deposit Returned?":
            case "Security Guard Service State":
            case "Security Litigation?":
            case "Send by E-Mail":
            case "Show On Dashboard":
            case "Shown on COI":
            case "Solvent Based?":
            case "Sonic Cause Code":
            case "Sonic S0 Cause Code Promoted?":
            case "Special Umbrella Limits":
            case "State Funded":
            case "State of Accident":
            case "State of Hire":
            case "State of Jurisdiction":
            case "State":
            case "Status ":
            case "Status":
            case "Stop Gap Endorsement":
            case "Sublease Agreement?":
            case "Sub-Lease State":
            case "Sublease?":
            case "Supervisor Involved in the Telephone Nurse Consultation Phone Call?":
            case "Surgery Y/N":
            case "Tank In Use?":
            case "TCLP On File?":
            case "TCLP Performed?":
            case "Type of Use":
            case "Type":
            case "Umbrella Form":
            case "Use Same Date":
            case "Vehicle Sub Type":
            case "Was Phase II Recommended?":
            case "Was Telephone Nurse Consultation Used?":
            case "Water Borne?":
            case "WC State Limits":
            case "Were Analytical Tests Performed? ":
            case "Witness State":
            case "Primary/Physical State":
            case "Assessment State":
            case "Investigation Status":
            case "State of Employment":
            case "Nature of Benefit":
            case "Transaction Nature of Benefit":
            case "Inspection - Focus Area":
            case "Inspection - Question":
            case "Investigations - Status":
            case "Entry Code":
            case "Entry Code Modiifer":
            
                return true;
            default:
                return false;
        }
    }
    /// <summary>
    /// Gets the condition for major coverage field for the modules
    /// </summary>
    /// <param name="FK_Module"></param>
    /// <returns></returns>
    private string GetMajorClaimCondition(decimal FK_Module)
    {
        string strCondition = string.Empty;
        switch (FK_Module.ToString())
        {
            case "2":
                strCondition = "Maj_Cov = '30'";
                break;
            case "8":
                strCondition = "Maj_Cov = '50'";
                break;
            case "3":
                strCondition = "Maj_Cov = '40'";
                break;
            case "1":
                strCondition = "Maj_Cov = '99'";
                break;
            case "5":
                strCondition = "Maj_Cov = '70'";
                break;
            case "4":
                strCondition = "Maj_Cov = '10'";
                break;
            case "7":
                strCondition = "Maj_Cov = '60'";
                break;
            case "6":
                strCondition = "Maj_Cov = '80'";
                break;
            default:
                break;
        }
        return strCondition;
    }
    /// <summary>
    /// Gets the table names for the aliases used
    /// </summary>
    /// <param name="Table_Name"></param>
    /// <returns></returns>
    private string GetTableName(string Table_Name)
    {
        string returnTableName = string.Empty;
        switch (Table_Name)
        {
            //case "ClaimantOnly":
            //case "ClaimantDriver": 
            //case "Operator":
            //case "Other_Vehicle_Owner":
            //case "Police":
            //case "Recovery_Firm":
            //case "Unit_Owner":
            //case "Driver":
            //case "Claimant":
            //case "ClaimantDriver":
            //case "Other_Vehicle_Owner":
            //case "Insured_Driver":
            //    returnTableName="Contact";
            //    break;
            case "[C_Link_AlcoholTest]":
            case "[C_Link_drugtest]":
            case "[C_Link_Injury]":
            case "[C_Link_Passenger]":
            case "[C_Link_Police]":
            case "[C_Link_Suspect]":
            case "[C_Link_Towing]":
                returnTableName = "[Contact_Link]";
                break;
            case "[vwTractor]":
                returnTableName = "[Tractor]";
                break;
            case "[tblContractor]":
                returnTableName = "[Contractor]";
                break;
            default:
                returnTableName = Table_Name;
                break;
        }
        return returnTableName;
    }
    /// <summary>
    /// Binds the dropdown for the screen
    /// </summary>
    /// <param name="PK_Module"></param>
    private void BindScreenDropDown(decimal PK_Module)
    {
        clsBusiness_Rules_Screens objBusiness_Rules_Screens = new clsBusiness_Rules_Screens();
        DataSet ds = objBusiness_Rules_Screens.SelectByFK(PK_Module);
        drpScreen.DataSource = ds.Tables[0];
        drpScreen.DataTextField = "Screen";
        drpScreen.DataValueField = "PK_Business_Rules_Screens";
        drpScreen.DataBind();
        drpScreen.Items.Insert(0, new ListItem("-- Select --", "0"));

        if (drpScreen.SelectedValue == "91" || drpScreen.SelectedValue == "12"
            || drpScreen.SelectedValue == "13" || drpScreen.SelectedValue == "23" || drpScreen.SelectedValue == "40"
            || drpScreen.SelectedValue == "41" || drpScreen.SelectedValue == "42" || drpScreen.SelectedValue == "48"
                || drpScreen.SelectedValue == "49")
        {
            if (drpAction_Type.Items.FindByValue("Diary") != null)
            {
                drpAction_Type.Items.Remove(drpAction_Type.Items.FindByValue("Diary"));
            }
        }
        else
        {
            if (drpAction_Type.Items.FindByValue("Diary") == null)
            {
                drpAction_Type.Items.Add(new ListItem("Diary", "Diary"));
            }
        }
    }
    /// <summary>
    /// Binds the dropdowns for the evaluation criteria
    /// </summary>
    /// <param name="PK_Screen"></param>
    private void BindFilterDropDown(decimal PK_Screen)
    {
        clsBusiness_Rules_Fields objBusiness_Rules_Fields = new clsBusiness_Rules_Fields();
        DataSet ds = objBusiness_Rules_Fields.SelectByFK(PK_Screen);
        DataTable dtFields = ds.Tables[0];
        
        dtFields.DefaultView.RowFilter = "IsEmailAddress='False'";
        drpFilter1.DataSource = dtFields.DefaultView;
        drpFilter1.DataTextField = "On_Screen_Descriptior";
        drpFilter1.DataValueField = "PK_Business_Rules_Fields";
        drpFilter1.DataBind();
        drpFilter1.Items.Insert(0, new ListItem("-- Select --", "0"));
        drpFilter2.DataSource = dtFields.DefaultView;
        drpFilter2.DataTextField = "On_Screen_Descriptior";
        drpFilter2.DataValueField = "PK_Business_Rules_Fields";
        drpFilter2.DataBind();
        drpFilter2.Items.Insert(0, new ListItem("-- Select --", "0"));
        drpFilter3.DataSource = dtFields.DefaultView;
        drpFilter3.DataTextField = "On_Screen_Descriptior";
        drpFilter3.DataValueField = "PK_Business_Rules_Fields";
        drpFilter3.DataBind();
        drpFilter3.Items.Insert(0, new ListItem("-- Select --", "0"));
        drpFilter4.DataSource = dtFields.DefaultView;
        drpFilter4.DataTextField = "On_Screen_Descriptior";
        drpFilter4.DataValueField = "PK_Business_Rules_Fields";
        drpFilter4.DataBind();
        drpFilter4.Items.Insert(0, new ListItem("-- Select --", "0"));
        drpFilter5.DataSource = dtFields.DefaultView;
        drpFilter5.DataTextField = "On_Screen_Descriptior";
        drpFilter5.DataValueField = "PK_Business_Rules_Fields";
        drpFilter5.DataBind();
        drpFilter5.Items.Insert(0, new ListItem("-- Select --", "0"));

        BindCheckBoxlists();

        DataSet dsAction = objBusiness_Rules_Fields.SelectByFKAction(Convert.ToDecimal(drpScreen.SelectedValue), true);
        DataTable dtAction = dsAction.Tables[0];
        DataTable dtEmailFields = dsAction.Tables[0];
        DataTable dtContacts = dsAction.Tables[0];

        dtAction.DefaultView.RowFilter = "IsEmailAddress='False'";
        drpFilter_Action.DataSource = dsAction.Tables[0].DefaultView;
        drpFilter_Action.DataTextField = "On_Screen_Descriptior";
        drpFilter_Action.DataValueField = "PK_Business_Rules_Fields";
        drpFilter_Action.DataBind();
        drpFilter_Action.Items.Insert(0, new ListItem("-- Select --", "0"));

        drpFilter_Derived.DataSource = dtAction.DefaultView;
        drpFilter_Derived.DataTextField = "On_Screen_Descriptior";
        drpFilter_Derived.DataValueField = "PK_Business_Rules_Fields";
        drpFilter_Derived.DataBind();
        //DrivedFilterBound();

        dtEmailFields.DefaultView.RowFilter = "IsEmailAddress='True'";
        if (dtEmailFields.DefaultView.Count > 0)
        {
            chkEmailFields.DataSource = dtEmailFields.DefaultView;
            chkEmailFields.DataTextField = "On_Screen_Descriptior";
            chkEmailFields.DataValueField = "PK_Business_Rules_Fields";
            chkEmailFields.DataBind();
            trRecipientFromRecord.Style.Add("display", "block");
        }
        else
            trRecipientFromRecord.Style.Add("display", "none");

        dtContacts.DefaultView.RowFilter = "IsEmailAddress='True' AND ContactType = 'Claim Adjuster'";
        chkContactFields.DataSource = dtContacts.DefaultView;
        chkContactFields.DataTextField = "ContactType";
        chkContactFields.DataValueField = "PK_Business_Rules_Fields";
        chkContactFields.DataBind();
        drpAction_Type.Enabled = true;
    }
    /// <summary>
    /// Binds the page controls for edit
    /// </summary>
    private void BindForEdit()
    {
        clsBusiness_Rules objBusiness_Rules = new clsBusiness_Rules(PK_Business_Rule_Managgement);
        clsGeneral.SetDropdownValue(drpModule, objBusiness_Rules.FK_Business_Rules_Modules, true);
        BindScreenDropDown(Convert.ToDecimal(objBusiness_Rules.FK_Business_Rules_Modules));
        if (drpModule.SelectedValue == "0" || drpModule.SelectedValue == "0" || drpModule.SelectedValue == "0")
        {
            if (drpAction_Type.Items.FindByValue("Diary") != null)
            {
                drpAction_Type.Items.Remove(drpAction_Type.Items.FindByValue("Diary"));
            }
        }
        clsGeneral.SetDropdownValue(drpScreen, objBusiness_Rules.FK_Business_Rules_Screens, true);
        BindFilterDropDown(Convert.ToDecimal(objBusiness_Rules.FK_Business_Rules_Screens));
        clsGeneral.SetDropdownValue(drpAction_Type, objBusiness_Rules.Action_Type, true);
        clsGeneral.SetDropdownValue(rdListEvaluation, objBusiness_Rules.Action_Timing, true);
        txtRuleName.Text = objBusiness_Rules.Rule_Name.ToString().Trim();
        txtDescription.Text = Convert.ToString(objBusiness_Rules.Rule_Description);
        BindFilterEdit(PK_Business_Rule_Managgement);
        if (!string.IsNullOrEmpty(objBusiness_Rules.Action_Type.ToString().Trim()))
        {
            switch (objBusiness_Rules.Action_Type)
            {
                case "Update":
                    ListItem liSelected;
                    divUpdate_Action.Style.Add("display", "block");
                    spnNewValue.Visible = true;
                    drpDirectDerived.Visible = true;
                    clsGeneral.SetDropdownValue(drpFilter_Action, objBusiness_Rules.FK_Field_To_Update, true);
                    drpFilter_Action.ClearSelection();
                    // Find a value and then set it to selected
                    liSelected = drpFilter_Action.Items.FindByValue(objBusiness_Rules.FK_Field_To_Update.ToString().Trim());
                    if (liSelected != null)
                        liSelected.Selected = true;
                    int controlType = 0;
                    string Field_Name = string.Empty;
                    clsBusiness_Rules_Fields objBusiness_Rules_Fields = new clsBusiness_Rules_Fields(Convert.ToDecimal(objBusiness_Rules.FK_Field_To_Update));
                    controlType = Convert.ToInt16(objBusiness_Rules_Fields.Field_Type);
                    Field_Name = Convert.ToString(objBusiness_Rules_Fields.Field_Name);
                    if (objBusiness_Rules.IsDirectValue)
                    {
                        // Set Text value Criteria
                        if (controlType == (int)Business_RuleHelper.ControlType.TextBox)
                        {
                            pnlText_F_Action.Visible = true;
                            txtFilter_Action.Text = objBusiness_Rules.New_Value;
                        }
                        // Set Multi Selection listBox Criteria
                        else if (controlType == (int)Business_RuleHelper.ControlType.MultiSelectList)
                        {
                            lst_F_Action.Visible = true;
                            Business_RuleHelper.FillFilterDropDownAction(objBusiness_Rules.Field_To_Update, new DropDownList[] { lst_F_Action }, true, GetMajorClaimCondition(Convert.ToDecimal(drpModule.SelectedValue)));
                            spnNewValue.Visible = true;
                            drpDirectDerived.Visible = true;
                            pnlMultiSelect_F_Action.Visible = true;
                            ListItem liSelected_Action;
                            lst_F_Action.ClearSelection();
                            // Find a value and then set it to selected
                            liSelected_Action = lst_F_Action.Items.FindByValue(objBusiness_Rules.New_Value.ToString());
                            if (liSelected_Action != null)
                                liSelected_Action.Selected = true;
                        }
                        // Set Amount field Criteria
                        else if (controlType == (int)Business_RuleHelper.ControlType.AmountControl)
                        {
                            pnlAmount_F_Action.Visible = true;
                            txtAmount1_F_Action.Text = string.Format("{0:N2}", Convert.ToDecimal(objBusiness_Rules.New_Value));
                        }
                        else if (controlType == (int)Business_RuleHelper.ControlType.IntNumberControl)
                        {
                            pnlNumber_F_Action.Visible = true;
                            txtNumber1_F_Action.Attributes.Remove("MaxLength");

                            if (objBusiness_Rules.Field_To_Update.IndexOf("Year") > -1)
                                txtNumber1_F_Action.Attributes.Add("MaxLength", "4");
                            else if ((objBusiness_Rules.Field_To_Update.IndexOf("Height") > -1) || (objBusiness_Rules.Field_To_Update.IndexOf("Weight") > -1))
                                txtNumber1_F_Action.Attributes.Add("MaxLength", "3");
                            else
                                txtNumber1_F_Action.Attributes.Add("MaxLength", "8");
                            txtNumber1_F_Action.Text = Convert.ToString(objBusiness_Rules.New_Value);
                        }
                        // Set Date Control Filter Criteria
                        else if (controlType == (int)Business_RuleHelper.ControlType.DateControl)
                        {
                            pnlDate_F_Action.Visible = true;
                            txtDate_From_Action.Text = clsGeneral.FormatDBNullDateToDisplay(objBusiness_Rules.New_Value);
                        }
                        tdAction.Style.Add("display", "block");
                        tdDerived.Style.Add("display", "none");
                        spnNewValue.InnerText = "New Value:";
                    }
                    else
                    {
                        if (controlType == (int)Business_RuleHelper.ControlType.MultiSelectList)
                        {
                            lst_F_Action.Visible = true;
                            Business_RuleHelper.FillFilterDropDownAction(objBusiness_Rules.Field_To_Update, new DropDownList[] { lst_F_Action }, true, GetMajorClaimCondition(Convert.ToDecimal(drpModule.SelectedValue)));
                            spnNewValue.Visible = true;
                            drpDirectDerived.Visible = true;
                            ListItem liSelected_Action;
                            lst_F_Action.ClearSelection();
                            // Find a value and then set it to selected
                            liSelected_Action = lst_F_Action.Items.FindByValue(objBusiness_Rules.New_Value.ToString());

                            if (liSelected_Action != null)
                                liSelected_Action.Selected = true;
                            tdAction.Style.Add("display", "block");
                            tdDerived.Style.Add("display", "none");
                            spnNewValue.InnerText = "New Value:";
                        }
                        else
                        {
                            drpDirectDerived.SelectedValue = "False";
                            tdAction.Style.Add("display", "none");
                            tdDerived.Style.Add("display", "block");
                            //spnNewValue.InnerText = " = ";
                            clsGeneral.SetDropdownValue(drpFilter_Derived, objBusiness_Rules.FK_Derived_Field, true);
                            int DerivedControlType = 0;
                            List<ERIMS.DAL.clsBusiness_Rules_Fields> lstAdHoc = null;
                            lstAdHoc = new ERIMS.DAL.clsBusiness_Rules_Fields().SelectByPK(Convert.ToDecimal(objBusiness_Rules.FK_Derived_Field));
                            DerivedControlType = Convert.ToInt16(lstAdHoc[0].Field_Type);
                            if (!(DerivedControlType == (int)Business_RuleHelper.ControlType.TextBox))
                            {
                                string strValue = string.Empty;
                                if (objBusiness_Rules.New_Value.IndexOf("-") != -1)
                                    strValue = objBusiness_Rules.New_Value.Split('-')[1];
                                else if (objBusiness_Rules.New_Value.IndexOf("+") != -1)
                                    strValue = objBusiness_Rules.New_Value.Split('+')[1];
                                txtNumber_Derived.Visible = true;
                                drpDerived_Add.Visible = true;
                                drpFilter_Derived.Visible = true;
                                txtNumber_Derived.Text = strValue.Trim();
                                drpDerived_Add.Items.Add(new ListItem(" - ", "-"));
                            }
                            else
                            {
                                if (objBusiness_Rules.New_Value.IndexOf("-") != -1)
                                {
                                    ListItem lst = drpDerived_Add.Items.FindByValue("-");
                                    if (lst != null)
                                        lst.Selected = true;
                                }
                                    string strValue = string.Empty;
                                    if (objBusiness_Rules.New_Value.IndexOf("-") != -1)
                                        strValue = objBusiness_Rules.New_Value.Split('-')[1];
                                    else if (objBusiness_Rules.New_Value.IndexOf("+") != -1)
                                        strValue = objBusiness_Rules.New_Value.Split('+')[1];
                                    txtText_Derived.Visible = true;
                                    drpDerived_Add.Visible = true;
                                    drpFilter_Derived.Visible = true;
                                    txtText_Derived.Text = strValue.Replace("'", "").Trim();                                
                            }
                        }
                    }

                    break;
                case "Email":
                    divEmail_Action.Style.Add("display", "block");
                    txtIAssignToID.Value = objBusiness_Rules.Recipient_IDs;
                    string[] arrRecipientName = txtIAssignToID.Value.Split(',');
                    string strName = string.Empty;
                    foreach (string strID in arrRecipientName)
                    {
                        if (!string.IsNullOrEmpty(strID))
                        {
                            Tatva_Recipient objTatva_Recipient = new Tatva_Recipient(Convert.ToDecimal(strID));
                            if (strName == string.Empty)
                                strName = objTatva_Recipient.FirstName;
                            else
                                strName = strName + "," + objTatva_Recipient.FirstName;
                        }
                    }
                    txtIAssignTo.Text = strName.TrimEnd(',');
                    txtEmailSubject.Text = objBusiness_Rules.EMail_Subject;
                    txtEmailBody.Text = objBusiness_Rules.EMail_Body;
                    BindCheckBoxList(PK_Business_Rule_Managgement);
                    BindEmailCheckBox(PK_Business_Rule_Managgement);
                    break;
                case "Diary":
                    divDiary_Action.Style.Add("display", "block");
                    txtIAssignToIDDiary.Value = objBusiness_Rules.Diary_Assigned_To;
                    txtIAssignToDiary.Text = objBusiness_Rules.Diary_Assigned_To;
                    txtDiaryNote.Text = objBusiness_Rules.Diary_Note;
                    txtDiaryDate.Text = string.Format("{0:N0}", objBusiness_Rules.Diary_Date_Value);
                    chkCurrentUser.Checked = objBusiness_Rules.Diary_To_Current_User == true;
                    if (!string.IsNullOrEmpty(objBusiness_Rules.Diary_Assign_To_Contact))
                    {
                        ListItem lst = chkContactFields.Items.FindByValue(objBusiness_Rules.Diary_Assign_To_Contact);
                        if (lst != null)
                            lst.Selected = true;
                    }
                    trAssignedContact.Visible = drpModule.SelectedItem.Text != "Incident";
                    break;
            }
        }
    }

    /// <summary>
    /// Binds(select) the Email fields selected for the recipients
    /// </summary>
    /// <param name="FK_Rule"></param>
    private void BindEmailCheckBox(decimal FK_Rule)
    {
        clsBusiness_Rules objBusiness_Rules = new clsBusiness_Rules(FK_Rule);
        if (!string.IsNullOrEmpty(objBusiness_Rules.Email_Recipient_Fields))
        {
            string[] EmailFields = objBusiness_Rules.Email_Recipient_Fields.Split(',');
            if (EmailFields.Length > 0)
            {
                for (int i = 0; i <= EmailFields.Length - 1; i++)
                {
                    ListItem lst = chkEmailFields.Items.FindByValue(EmailFields[i]);
                    if (lst != null)
                        lst.Selected = true;
                }
            }
        }
    }
    /// <summary>
    /// Binds(select) the fields to be included in the email
    /// </summary>
    /// <param name="FK_Rule"></param>
    private void BindCheckBoxList(decimal FK_Rule)
    {
        DataSet ds = Business_Rules_Email_Fields.SelectByFK(FK_Rule);
        if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
        {
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                ListItem lst = chkFields.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[i]["FK_Business_Rules_Fields"]));
                if (lst != null)
                    lst.Selected = true;
            }
        }
    }

    /// <summary>
    /// Binds the fields for the evaluatin criteria
    /// </summary>
    /// <param name="PK_ID"></param>
    private void BindFilterEdit(decimal PK_ID)
    {
        clsBusiness_Rule_Filter objBusiness_Rule_Filter = new clsBusiness_Rule_Filter();
        List<ERIMS.DAL.clsBusiness_Rule_Filter> dsFilter = objBusiness_Rule_Filter.SelectByFK(PK_ID);
        if (dsFilter.Count > 0)
        {
            for (int i = 0; i <= dsFilter.Count - 1; i++)
            {
                switch (i)
                {
                    case 0:
                        chkNotCriteria1.Visible = true;
                        chkNotCriteria1.Checked = Convert.ToBoolean(dsFilter[i].IsNotSelected);
                        spnField1.Visible = true;
                        LoadFilterCriteria(dsFilter[i], drpFilter1);
                        int controlType = 0;
                        string Field_Name = string.Empty;
                        string On_ScreenDescriptor1 = string.Empty;
                        clsBusiness_Rules_Fields objBusiness_Rules_Fields = new clsBusiness_Rules_Fields(Convert.ToDecimal(dsFilter[i].FK_Business_Rules_Fields));
                        controlType = Convert.ToInt16(objBusiness_Rules_Fields.Field_Type);
                        Field_Name = Convert.ToString(objBusiness_Rules_Fields.Field_Name);
                        On_ScreenDescriptor1 = Convert.ToString(objBusiness_Rules_Fields.On_Screen_Descriptior);
                        // Set Text value Criteria
                        if (controlType == (int)Business_RuleHelper.ControlType.TextBox)
                            LoadFilterControlText(dsFilter[i].ConditionType, dsFilter[i].ConditionValue, pnlText_F1, txtFilter1, drpText_F1);
                        // Set Multi Selection listBox Criteria
                        else if (controlType == (int)Business_RuleHelper.ControlType.MultiSelectList)
                            LoadFilterControlDropDown(Field_Name, dsFilter[i].ConditionValue, lst_F1,On_ScreenDescriptor1);
                        // Set Amount field Criteria
                        else if (controlType == (int)Business_RuleHelper.ControlType.AmountControl)
                            LoadFilterControlAmount(dsFilter[i], pnlAmount_F1, drpAmount_F1, txtAmount1_F1, txtAmount2_F1, lblAmountText1_F1, lblAmountText2_F1, cvAmount1);
                        // Set Number field Criteria
                        else if (controlType == (int)Business_RuleHelper.ControlType.IntNumberControl)
                            LoadFilterControlNumber(dsFilter[i], pnlNumber_F1, drpNumber_F1, txtNumber1_F1, txtNumber2_F1, lblNumberText1_F1, lblNumberText2_F1, cvNumber1);
                        // Set Date Control Filter Criteria
                        else if (controlType == (int)Business_RuleHelper.ControlType.DateControl)
                            LoadFilterControlDate(dsFilter[i], pnlDate_F1, lstDate1, lblDateFrom1, lblDateTo1, txtDate_From1, txtDate_To1, imgDate_To1, revtxtDate_From1, ucRelativeDatesFrom_1, ucRelativeDatesTo_1, imgDate_Opened_From1);
                        break;
                    case 1:
                        chkNotCriteria2.Visible = true;
                        chkNotCriteria2.Checked = Convert.ToBoolean(dsFilter[i].IsNotSelected);
                        spnField2.Visible = true;
                        LoadFilterCriteria(dsFilter[i], drpFilter2);
                        int controlType2 = 0;
                        string Field_Name2 = string.Empty;
                        string On_ScreenDescriptor2 = string.Empty;
                        clsBusiness_Rules_Fields objBusiness_Rules_Fields2 = new clsBusiness_Rules_Fields(Convert.ToDecimal(dsFilter[i].FK_Business_Rules_Fields));
                        controlType2 = Convert.ToInt16(objBusiness_Rules_Fields2.Field_Type);
                        Field_Name2 = Convert.ToString(objBusiness_Rules_Fields2.Field_Name);
                        On_ScreenDescriptor2 = Convert.ToString(objBusiness_Rules_Fields2.On_Screen_Descriptior);
                        // Set Text value Criteria
                        if (controlType2 == (int)Business_RuleHelper.ControlType.TextBox)
                            LoadFilterControlText(dsFilter[i].ConditionType, dsFilter[i].ConditionValue, pnlText_F2, txtFilter2, drpText_F2);
                        // Set Multi Selection listBox Criteria
                        else if (controlType2 == (int)Business_RuleHelper.ControlType.MultiSelectList)
                            LoadFilterControlDropDown(Field_Name2, dsFilter[i].ConditionValue, lst_F2,On_ScreenDescriptor2);
                        // Set Amount field Criteria
                        else if (controlType2 == (int)Business_RuleHelper.ControlType.AmountControl)
                            LoadFilterControlAmount(dsFilter[i], pnlAmount_F2, drpAmount_F2, txtAmount1_F2, txtAmount2_F2, lblAmountText1_F2, lblAmountText2_F2, cvAmount2);
                        // Set Number field Criteria
                        else if (controlType2 == (int)Business_RuleHelper.ControlType.IntNumberControl)
                            LoadFilterControlNumber(dsFilter[i], pnlNumber_F2, drpNumber_F2, txtNumber1_F2, txtNumber2_F2, lblNumberText1_F2, lblNumberText2_F2, cvNumber2);
                        // Set Date Control Filter Criteria
                        else if (controlType2 == (int)Business_RuleHelper.ControlType.DateControl)
                            LoadFilterControlDate(dsFilter[i], pnlDate_F2, lstDate2, lblDateFrom2, lblDateTo2, txtDate_From2, txtDateTo2, imgDate_To2, revtxtDate_From2, ucRelativeDatesFrom_2, ucRelativeDatesTo_2, imgDate_Opened_From2);
                        break;
                    case 2:
                        chkNotCriteria3.Visible = true;
                        chkNotCriteria3.Checked = Convert.ToBoolean(dsFilter[i].IsNotSelected);
                        spnField3.Visible = true;
                        LoadFilterCriteria(dsFilter[i], drpFilter3);
                        int controlType3 = 0;
                        string Field_Name3 = string.Empty;
                        string On_ScreenDescriptor3 = string.Empty;
                        clsBusiness_Rules_Fields objBusiness_Rules_Fields3 = new clsBusiness_Rules_Fields(Convert.ToDecimal(dsFilter[i].FK_Business_Rules_Fields));
                        controlType3 = Convert.ToInt16(objBusiness_Rules_Fields3.Field_Type);
                        Field_Name3 = Convert.ToString(objBusiness_Rules_Fields3.Field_Name);
                        On_ScreenDescriptor3 = Convert.ToString(objBusiness_Rules_Fields3.On_Screen_Descriptior);
                        // Set Text value Criteria
                        if (controlType3 == (int)Business_RuleHelper.ControlType.TextBox)
                            LoadFilterControlText(dsFilter[i].ConditionType, dsFilter[i].ConditionValue, pnlText_F3, txtFilter3, drpText_F3);
                        // Set Multi Selection listBox Criteria
                        else if (controlType3 == (int)Business_RuleHelper.ControlType.MultiSelectList)
                            LoadFilterControlDropDown(Field_Name3, dsFilter[i].ConditionValue, lst_F3,On_ScreenDescriptor3);
                        // Set Amount field Criteria
                        else if (controlType3 == (int)Business_RuleHelper.ControlType.AmountControl)
                            LoadFilterControlAmount(dsFilter[i], pnlAmount_F3, drpAmount_F3, txtAmount1_F3, txtAmount2_F3, lblAmountText1_F3, lblAmountText2_F3, cvAmount3);
                        // Set Number field Criteria
                        else if (controlType3 == (int)Business_RuleHelper.ControlType.IntNumberControl)
                            LoadFilterControlNumber(dsFilter[i], pnlNumber_F3, drpNumber_F3, txtNumber1_F3, txtNumber2_F3, lblNumberText1_F3, lblNumberText2_F3, cvNumber3);
                        // Set Date Control Filter Criteria
                        else if (controlType3 == (int)Business_RuleHelper.ControlType.DateControl)
                            LoadFilterControlDate(dsFilter[i], pnlDate_F3, lstDate3, lblDateFrom3, lblDateTo3, txtDate_From3, txtDate_To3, imgDate_To3, revtxtDate_From3, ucRelativeDatesFrom_3, ucRelativeDatesTo_3, imgDate_Opened_From3);
                        break;
                    case 3:
                        chkNotCriteria4.Visible = true;
                        chkNotCriteria4.Checked = Convert.ToBoolean(dsFilter[i].IsNotSelected);
                        spnField4.Visible = true;
                        LoadFilterCriteria(dsFilter[i], drpFilter4);
                        int controlType4 = 0;
                        string Field_Name4 = string.Empty;
                        string On_ScreenDescriptor4 = string.Empty;
                        clsBusiness_Rules_Fields objBusiness_Rules_Fields4 = new clsBusiness_Rules_Fields(Convert.ToDecimal(dsFilter[i].FK_Business_Rules_Fields));
                        controlType4 = Convert.ToInt16(objBusiness_Rules_Fields4.Field_Type);
                        Field_Name4 = Convert.ToString(objBusiness_Rules_Fields4.Field_Name);
                        On_ScreenDescriptor4 = Convert.ToString(objBusiness_Rules_Fields4.On_Screen_Descriptior);
                        // Set Text value Criteria
                        if (controlType4 == (int)Business_RuleHelper.ControlType.TextBox)
                            LoadFilterControlText(dsFilter[i].ConditionType, dsFilter[i].ConditionValue, pnlText_F4, txtFilter4, drpText_F4);
                        // Set Multi Selection listBox Criteria
                        else if (controlType4 == (int)Business_RuleHelper.ControlType.MultiSelectList)
                            LoadFilterControlDropDown(Field_Name4, dsFilter[i].ConditionValue, lst_F4,On_ScreenDescriptor4);
                        // Set Amount field Criteria
                        else if (controlType4 == (int)Business_RuleHelper.ControlType.AmountControl)
                            LoadFilterControlAmount(dsFilter[i], pnlAmount_F4, drpAmount_F4, txtAmount1_F4, txtAmount2_F4, lblAmountText1_F4, lblAmountText2_F4, cvAmount4);
                        // Set Number field Criteria
                        else if (controlType4 == (int)Business_RuleHelper.ControlType.IntNumberControl)
                            LoadFilterControlNumber(dsFilter[i], pnlNumber_F4, drpNumber_F4, txtNumber1_F4, txtNumber2_F4, lblNumberText1_F4, lblNumberText2_F4, cvNumber4);
                        // Set Date Control Filter Criteria
                        else if (controlType4 == (int)Business_RuleHelper.ControlType.DateControl)
                            LoadFilterControlDate(dsFilter[i], pnlDate_F4, lstDate4, lblDateFrom4, lblDateTo4, txtDate_From4, txtDate_To4, imgDate_To4, revtxtDate_From4, ucRelativeDatesFrom_4, ucRelativeDatesTo_4, imgDate_Opened_From4);
                        break;
                    case 4:
                        chkNotCriteria5.Visible = true;
                        chkNotCriteria5.Checked = Convert.ToBoolean(dsFilter[i].IsNotSelected);
                        spnField5.Visible = true;
                        LoadFilterCriteria(dsFilter[i], drpFilter5);
                        int controlType5 = 0;
                        string Field_Name5 = string.Empty;
                        string On_ScreenDescriptor5 = string.Empty;
                        clsBusiness_Rules_Fields objBusiness_Rules_Fields5 = new clsBusiness_Rules_Fields(Convert.ToDecimal(dsFilter[i].FK_Business_Rules_Fields));
                        controlType5 = Convert.ToInt16(objBusiness_Rules_Fields5.Field_Type);
                        Field_Name5 = Convert.ToString(objBusiness_Rules_Fields5.Field_Name);
                        On_ScreenDescriptor5 = Convert.ToString(objBusiness_Rules_Fields5.On_Screen_Descriptior);
                        // Set Text value Criteria
                        if (controlType5 == (int)Business_RuleHelper.ControlType.TextBox)
                            LoadFilterControlText(dsFilter[i].ConditionType, dsFilter[i].ConditionValue, pnlText_F5, txtFilter5, drpText_F5);
                        // Set Multi Selection listBox Criteria
                        else if (controlType5 == (int)Business_RuleHelper.ControlType.MultiSelectList)
                            LoadFilterControlDropDown(Field_Name5, dsFilter[i].ConditionValue, lst_F5,On_ScreenDescriptor5);
                        // Set Amount field Criteria
                        else if (controlType5 == (int)Business_RuleHelper.ControlType.AmountControl)
                            LoadFilterControlAmount(dsFilter[i], pnlAmount_F5, drpAmount_F5, txtAmount1_F5, txtAmount2_F5, lblAmountText1_F5, lblAmountText2_F5, cvAmount5);
                        // Set Number field Criteria
                        else if (controlType5 == (int)Business_RuleHelper.ControlType.IntNumberControl)
                            LoadFilterControlNumber(dsFilter[i], pnlNumber_F5, drpNumber_F5, txtNumber1_F5, txtNumber2_F5, lblNumberText1_F5, lblNumberText2_F5, cvNumber5);
                        // Set Date Control Filter Criteria
                        else if (controlType5 == (int)Business_RuleHelper.ControlType.DateControl)
                            LoadFilterControlDate(dsFilter[i], pnlDate_F5, lstDate5, lblDateFrom5, lblDateTo5, txtDate_From5, txtDate_To5, imgDate_To5, revtxtDate_From5, ucRelativeDatesFrom_5, ucRelativeDatesTo_5, imgDate_Opened_From5);
                        break;
                    default:
                        break;
                }
            }
            SetRelativeDateControl();
        }
    }
    /// <summary>
    /// Clear controls in the action section
    /// </summary>
    private void ClearActionControls()
    {
        spnNewValue.Visible = false;
        drpDirectDerived.Visible = false;
        txtDate_From_Action.Text = string.Empty;
        txtAmount1_F_Action.Text = string.Empty;
        txtNumber1_F_Action.Text = string.Empty;
        txtText_Derived.Text = string.Empty;
        txtNumber_Derived.Text = string.Empty;
        txtFilter_Action.Text = string.Empty;
        txtEmailBody.Text = string.Empty;
        txtEmailSubject.Text = string.Empty;
        txtIAssignTo.Text = string.Empty;
        txtIAssignToDiary.Text = string.Empty;
        txtIAssignToID.Value = string.Empty;
        txtIAssignToIDDiary.Value = string.Empty;
        txtDiaryDate.Text = string.Empty;
        txtDiaryNote.Text = string.Empty;
        chkEmailFields.Items.Clear();
        chkFields.Items.Clear();

        if (drpFilter_Action.SelectedItem != null)
            drpFilter_Action.SelectedIndex = 0;
        if (drpFilter_Derived.SelectedItem != null)
            drpFilter_Derived.SelectedIndex = 0;
        //txtReportName.Text = string.Empty;       

    }
    /// <summary>
    /// Set Action Control Panel Visibility
    /// </summary>
    private void ClearActionFilterPanel()
    {
        pnlAmount_F_Action.Visible = false;
        pnlNumber_F_Action.Visible = false;
        pnlMultiSelect_F_Action.Visible = false;
        pnlDate_F_Action.Visible = false;

        pnlText_F_Action.Visible = false;

        lst_F_Action.Visible = false;
        imgDate_To1.Visible = false;
        imgDate_To_Action.Src = AppConfig.ImageURL + "/iconPicDate.gif";
        imgDate_Opened_From_Action.Src = AppConfig.ImageURL + "/iconPicDate.gif";

        divUpdate_Action.Style.Add("display", "none");
        divEmail_Action.Style.Add("display", "none");
        divDiary_Action.Style.Add("display", "none");

    }
    /// <summary>
    /// Bind the dropdown for all the modules
    /// </summary>
    private void BindModule()
    {
        ComboHelper.FillBusinessRulesModules(new DropDownList[] { drpModule }, true);
        drpScreen.Items.Clear();
        drpScreen.Items.Insert(0, new ListItem("-- Select --", "0"));
    }
    /// <summary>
    /// Set Filter Control Panel Visibility
    /// </summary>
    private void ClearAllFilterPanel()
    {

        chkNotCriteria1.Visible = chkNotCriteria2.Visible = chkNotCriteria3.Visible = chkNotCriteria4.Visible = chkNotCriteria5.Visible = false;

        pnlAmount_F1.Visible = pnlAmount_F2.Visible = pnlAmount_F3.Visible = pnlAmount_F4.Visible = pnlAmount_F5.Visible = false;

        pnlNumber_F1.Visible = pnlNumber_F2.Visible = pnlNumber_F3.Visible = pnlNumber_F4.Visible = pnlNumber_F5.Visible = false;

        pnlDate_F1.Visible = pnlDate_F2.Visible = pnlDate_F3.Visible = pnlDate_F4.Visible = pnlDate_F5.Visible = false;

        pnlText_F1.Visible = pnlText_F2.Visible = pnlText_F3.Visible = pnlText_F4.Visible = pnlText_F5.Visible = false;

        lst_F1.Visible = lst_F2.Visible = lst_F3.Visible = lst_F4.Visible = lst_F5.Visible = false;

        lblDateTo1.Visible = lblDateTo2.Visible = lblDateTo3.Visible = lblDateTo4.Visible = lblDateTo5.Visible = false;

        txtDate_To1.Visible = txtDateTo2.Visible = txtDate_To3.Visible = txtDate_To4.Visible = txtDate_To5.Visible = false;

        imgDate_To1.Visible = imgDate_To2.Visible = imgDate_To3.Visible = imgDate_To4.Visible = imgDate_To5.Visible = false;

        lblDateFrom1.Text = lstDate1.SelectedItem.Text + " Date:";

        imgDate_To1.Src = imgDate_To2.Src = imgDate_To3.Src = imgDate_To4.Src = imgDate_To5.Src = AppConfig.ImageURL + "/iconPicDate.gif";
        imgDate_Opened_From1.Src = imgDate_Opened_From2.Src = imgDate_Opened_From3.Src = imgDate_Opened_From4.Src = imgDate_Opened_From5.Src = AppConfig.ImageURL + "/iconPicDate.gif";

    }
    /// <summary>
    /// Clears all the field dropdowns
    /// </summary>
    private void ClearAllDropDown()
    {
        drpFilter1.Items.Clear();
        drpFilter1.Items.Insert(0, new ListItem("-- Select --", "0"));
        drpFilter2.Items.Clear();
        drpFilter2.Items.Insert(0, new ListItem("-- Select --", "0"));
        drpFilter3.Items.Clear();
        drpFilter3.Items.Insert(0, new ListItem("-- Select --", "0"));
        drpFilter4.Items.Clear();
        drpFilter4.Items.Insert(0, new ListItem("-- Select --", "0"));
        drpFilter5.Items.Clear();
        drpFilter5.Items.Insert(0, new ListItem("-- Select --", "0"));
    }
    /// <summary>
    /// Clear Filter Control and Display it as initial mode
    /// </summary>
    private void ClearControls()
    {
        txtDate_To1.Text = txtDateTo2.Text = txtDate_To3.Text = txtDate_To4.Text = txtDate_To5.Text = string.Empty;
        txtDate_From1.Text = txtDate_From2.Text = txtDate_From3.Text = txtDate_From4.Text = txtDate_From5.Text = string.Empty;
        txtAmount1_F1.Text = txtAmount1_F2.Text = txtAmount1_F3.Text = txtAmount1_F4.Text = txtAmount1_F5.Text = string.Empty;
        txtAmount2_F1.Text = txtAmount2_F2.Text = txtAmount2_F3.Text = txtAmount2_F4.Text = txtAmount2_F5.Text = string.Empty;
        txtFilter1.Text = txtFilter2.Text = txtFilter3.Text = txtFilter4.Text = txtFilter5.Text = string.Empty;

        ///Default Date Criteria
        lstDate1.SelectedValue = lstDate2.SelectedValue = lstDate3.SelectedValue = lstDate4.SelectedValue = lstDate5.SelectedValue = "O";

        //Amount Default
        drpAmount_F1.SelectedValue = drpAmount_F2.SelectedValue = drpAmount_F3.SelectedValue = drpAmount_F4.SelectedValue = drpAmount_F5.SelectedValue = Convert.ToString((int)Business_RuleHelper.AmountCriteria.Equal);
        drpAmount_F_SelectedIndexChanged(drpAmount_F1, null);
        drpAmount_F_SelectedIndexChanged(drpAmount_F2, null);
        drpAmount_F_SelectedIndexChanged(drpAmount_F3, null);
        drpAmount_F_SelectedIndexChanged(drpAmount_F4, null);
        drpAmount_F_SelectedIndexChanged(drpAmount_F5, null);
    }
    /// <summary>
    /// Clears the check boxes for the not in the evaluation criteria
    /// </summary>
    private void ClearNotCheckCriteria()
    {
        chkNotCriteria1.Visible = false;
        chkNotCriteria1.Checked = false;
        chkNotCriteria2.Visible = false;
        chkNotCriteria2.Checked = false;
        chkNotCriteria3.Visible = false;
        chkNotCriteria3.Checked = false;
        chkNotCriteria4.Visible = false;
        chkNotCriteria4.Checked = false;
        chkNotCriteria5.Visible = false;
        chkNotCriteria5.Checked = false;
        spnField1.Visible = false;
        spnField2.Visible = false;
        spnField3.Visible = false;
        spnField4.Visible = false;
        spnField5.Visible = false;
    }
    /// <summary>
    /// Set Date control Text and show-hide Date textbox as per selected criteria
    /// </summary>    
    private void SetDateControls(DropDownList rdbCommon, Label lbl1, Label lbl2, TextBox txt1, TextBox txt2, HtmlImage img2, RegularExpressionValidator revDateTo, Controls_RelativeDate_RelativeDate_Business_Rule ucToDate)
    {
        //Set Validation Massage and Label Text
        string strFilterTxt = "Filter Criteria " + lbl1.ID.Replace("lblDateFrom", "") + " - ";
        lbl1.Text = rdbCommon.SelectedItem.Text + " Date:";
        revDateTo.ErrorMessage = strFilterTxt + rdbCommon.SelectedItem.Text + " Date is not valid date";

        if (rdbCommon.SelectedValue == "B")
        {
            img2.Visible = true;
            txt2.Visible = true;
            ucToDate.Visible = lbl2.Visible = true;
            lbl1.Text = "Start Date:";
            lbl2.Text = "End Date:";
            revDateTo.ErrorMessage = strFilterTxt + "Start Date is not valid date";
        }
        else
        {
            ucToDate.Visible = img2.Visible = txt2.Visible = lbl2.Visible = false;
            lbl2.Text = "";
        }
        // Set image to display calander Control
        img2.Attributes.Add("onclick", "return showCalendar('" + txt2.ClientID + "', 'mm/dd/y','','')");

    }
    /// <summary>
    /// Set Control when filter Change
    /// </summary>
    /// <param name="drpFilter"></param>
    /// <param name="pnlText_F"></param>
    /// <param name="pnlAmoun_F"></param>
    /// <param name="pnlDate_F"></param>
    /// <param name="lst_F"></param>
    /// <returns></returns>
    protected string drpFilterChange(DropDownList drpFilter, Panel pnlText_F, Panel pnlAmoun_F, Panel pnlNumber_F, Panel pnlDate_F, ListBox lst_F, CheckBox chkNotCriteria, HtmlGenericControl spnField, TextBox txtNumber1_F, TextBox txtNumber2_F)
    {
        if (drpFilter.SelectedValue == "0" || drpFilter.Items.Count <= 0)
        {
            pnlText_F.Visible = false;
            pnlAmoun_F.Visible = false;
            pnlNumber_F.Visible = false;
            pnlDate_F.Visible = false;
            lst_F.Visible = false;
            chkNotCriteria.Visible = false;
            spnField.Visible = false;
        }

        decimal decSelectedValue = 0;
        if (drpFilter.Items.Count > 0 && drpFilter.SelectedIndex > 0)
            decSelectedValue = Convert.ToDecimal(drpFilter.SelectedItem.Value);
        List<ERIMS.DAL.clsBusiness_Rules_Fields> lstAdHoc = null;

        if (decSelectedValue > 0)
            lstAdHoc = new ERIMS.DAL.clsBusiness_Rules_Fields().SelectByPK(decSelectedValue);

        if (lstAdHoc != null && lstAdHoc.Count > 0)
        {
            chkNotCriteria.Visible = true;
            chkNotCriteria.Checked = false;
            spnField.Visible = true;
            bool IsDollar = lstAdHoc[0].IsDollar;
            switch (lstAdHoc[0].Field_Type.Value)
            {
                case (int)Business_RuleHelper.ControlType.TextBox:
                    pnlText_F.Visible = true;
                    pnlAmoun_F.Visible = false;
                    pnlNumber_F.Visible = false;
                    pnlDate_F.Visible = false;
                    lst_F.Visible = false;
                    SetDefaultTExtBox(pnlText_F.ID);
                    break;
                case (int)Business_RuleHelper.ControlType.MultiSelectList:
                    if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "focus area" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "inspection - focus area")
                    {
                        ComboHelper.Fill_FocusAreaAdHoc(new ListBox[] { lst_F }, 0, false);
                    }
                    else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "question text" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "inspection - question")
                    {
                        ComboHelper.Fill_QuestionTextAdHoc(new ListBox[] { lst_F }, 0, false);
                    }
                    else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location d/b/a" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "dealership/collision center"
                                    || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "dealership dba" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "sonic location d/b/a")
                    {
                        //ComboHelper.FillLocationDBA_AllCRMAdHoc(new ListBox[] { lst_F }, 0, false);
                        ComboHelper.FillLocationDBA_All(new ListBox[] { lst_F }, 0, false);
                    }
                    else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "legal entity" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "legal entity name") 
                    {
                        //  ComboHelper.FillDistinctLocationLegal_EntityList(new ListBox[] { lst_F }, false);
                        ComboHelper.FillDistinctLocationLegal_EntityByPK_Location(new ListBox[] { lst_F }, false);
                    }
                    else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location f/k/a")
                    {
                        ComboHelper.FillLocationfkaList(new ListBox[] { lst_F }, 0, false);
                    }
                    else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "sonic location code" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location number")
                    {
                        ComboHelper.FillSoincLocationCodeBusinessRule(new ListBox[] { lst_F }, false);
                    }
                    else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location rm number")
                    {
                        ComboHelper.FillSonicLocationNumberList(new ListBox[] { lst_F },0, false);
                        lst_F.Style.Remove("font-size");
                    }
                    else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "associate state")
                    {
                        ComboHelper.FillStateList(new ListBox[] { lst_F }, false);
                    }
                    else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "primary/physical state" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "building state"
                            || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "insured state" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "payees state"
                            || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "assessment state")
                    {
                        ComboHelper.FillStateByDesc(new ListBox[] { lst_F }, false);
                    }
                    else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "investigation status" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "investigations - status")
                    {
                        FillInvestigationList(new ListBox[] { lst_F }, false);
                    }
                    else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "property contact type")
                    {
                        FillPropertyContactList(new ListBox[] { lst_F }, false);
                    }
                    else
                        Business_RuleHelper.FillFilterDropDown(lstAdHoc[0].Field_Name, new ListBox[] { lst_F }, true, GetMajorClaimCondition(Convert.ToDecimal(drpModule.SelectedValue)));
                    pnlText_F.Visible = false;
                    pnlAmoun_F.Visible = false;
                    pnlNumber_F.Visible = false;
                    pnlDate_F.Visible = false;
                    lst_F.Visible = true;
                    //Set ListBox ToolTip
                    clsGeneral.SetListBoxToolTip(new ListBox[] { lst_F });
                    break;
                case (int)Business_RuleHelper.ControlType.DateControl:
                    pnlText_F.Visible = false;
                    pnlAmoun_F.Visible = false;
                    pnlNumber_F.Visible = false;
                    pnlDate_F.Visible = true;
                    lst_F.Visible = false;
                    SetDefaultDate(pnlDate_F.ID);
                    break;
                case (int)Business_RuleHelper.ControlType.AmountControl:
                    pnlText_F.Visible = false;
                    pnlAmoun_F.Visible = true;
                    pnlNumber_F.Visible = false;
                    pnlDate_F.Visible = false;
                    lst_F.Visible = false;
                    SetDefaultAmount(pnlAmoun_F.ID, IsDollar);
                    break;
                case (int)Business_RuleHelper.ControlType.IntNumberControl:
                    pnlText_F.Visible = false;
                    pnlAmoun_F.Visible = false;
                    pnlNumber_F.Visible = true;
                    pnlDate_F.Visible = false;
                    lst_F.Visible = false;
                    txtNumber1_F.Attributes.Remove("MaxLength");
                    txtNumber2_F.Attributes.Remove("MaxLength");
                    if (lstAdHoc[0].Field_Name.IndexOf("Year") > -1)
                    {
                        txtNumber1_F.Attributes.Add("MaxLength", "4");
                        txtNumber2_F.Attributes.Add("MaxLength", "4");
                    }
                    else if ((lstAdHoc[0].Field_Name.IndexOf("Height") > -1) || (lstAdHoc[0].Field_Name.IndexOf("Weight") > -1))
                    {
                        txtNumber1_F.Attributes.Add("MaxLength", "3");
                        txtNumber2_F.Attributes.Add("MaxLength", "3");
                    }                        
                    else
                    {
                        txtNumber1_F.Attributes.Add("MaxLength", "8");
                        txtNumber2_F.Attributes.Add("MaxLength", "8");
                    }
                    SetDefaultNumber(pnlNumber_F.ID);
                    break;
                default:
                    pnlText_F.Visible = false;
                    pnlAmoun_F.Visible = false;
                    pnlDate_F.Visible = false;
                    lst_F.Visible = false;
                    break;
            }
        }
        return string.Empty;
    }
    /// <summary>
    /// Amout Dropdown Changed.
    /// </summary>
    /// <param name="drpAmount_F"></param>
    /// <param name="lblAmountText1_F"></param>
    /// <param name="txtAmount1_F"></param>
    /// <param name="lblAmountText2_F"></param>
    /// <param name="txtAmount2_F"></param>
    protected void drpAmount_Changed(bool IsFirst, bool isDollarSign, DropDownList drpAmount_F, Label lblAmountText1_F, TextBox txtAmount1_F, Label lblAmountText2_F, TextBox txtAmount2_F, CompareValidator cvAmount)
    {
        string strAmountValue = drpAmount_F.SelectedValue;
        if (IsFirst)
        {
            if (isDollarSign)
            {
                lblAmountText1_F.Text = "$ ";
                lblAmountText2_F.Text = "To $ ";
            }
            else
            {
                lblAmountText1_F.Text = " ";
                lblAmountText2_F.Text = "To ";
            }
        }
        switch (strAmountValue)
        {
            case "0":
                //lblAmountText1_F.Text = "$ ";
                lblAmountText1_F.Text = lblAmountText1_F.Text.Replace("From ", "");
                lblAmountText1_F.Visible = true;
                txtAmount1_F.Visible = true;
                lblAmountText2_F.Visible = false;
                txtAmount2_F.Visible = false;
                break;
            case "1":
                //lblAmountText1_F.Text = "$ ";                
                lblAmountText1_F.Text = lblAmountText1_F.Text.Replace("From ", "");
                lblAmountText1_F.Visible = true;
                txtAmount1_F.Visible = true;
                lblAmountText2_F.Visible = false;
                txtAmount2_F.Visible = false;
                break;
            case "2":
                //lblAmountText1_F.Text = "From $ ";
                lblAmountText1_F.Text = "From " + lblAmountText1_F.Text.Replace("From ", "");
                lblAmountText1_F.Visible = true;
                txtAmount1_F.Visible = true;
                lblAmountText2_F.Visible = true;
                lblAmountText2_F.Text = "To " + lblAmountText2_F.Text.Replace("To ", "");
                //lblAmountText2_F.Text = "To $ ";
                txtAmount2_F.Visible = true;
                break;
            case "3":
                //lblAmountText1_F.Text = "$ ";
                lblAmountText1_F.Text = lblAmountText1_F.Text.Replace("From ", "");
                lblAmountText1_F.Visible = true;
                txtAmount1_F.Visible = true;
                lblAmountText2_F.Visible = false;
                txtAmount2_F.Visible = false;
                break;
            case "4":
                //lblAmountText1_F.Text = "$ ";
                lblAmountText1_F.Text = lblAmountText1_F.Text.Replace("From ", "");
                lblAmountText1_F.Visible = true;
                txtAmount1_F.Visible = true;
                lblAmountText2_F.Visible = false;
                txtAmount2_F.Visible = false;
                break;
            case "5":
                //lblAmountText1_F.Text = "$ ";
                lblAmountText1_F.Text = lblAmountText1_F.Text.Replace("From ", "");
                lblAmountText1_F.Visible = true;
                txtAmount1_F.Visible = true;
                lblAmountText2_F.Visible = false;
                txtAmount2_F.Visible = false;
                break;

        }
        /*
         * It will set TextBox and Lable of associate Textbox,when filed is numeric but it is not Amount filed
         * */
        //First Remove Attribute
        //txtAmount1_F.Attributes.Remove("onkeypress");
        //txtAmount2_F.Attributes.Remove("onkeypress");
        //txtAmount1_F.Attributes.Remove("onblur");
        //txtAmount2_F.Attributes.Remove("onblur");
        //if (!isDollarSign)
        //{
        //    //lblAmountText1_F.Text = lblAmountText1_F.Text.Replace("$", "");
        //    //lblAmountText2_F.Text = lblAmountText2_F.Text.Replace("$", "");
        //    txtAmount1_F.Attributes.Add("onkeypress", "return FormatInteger(event,this.id);");
        //    txtAmount2_F.Attributes.Add("onkeypress", "return FormatInteger(event,this.id);");
        //    txtAmount2_F.MaxLength = txtAmount1_F.MaxLength = 3;
        //    cvAmount.ErrorMessage = cvAmount.ErrorMessage.Replace("Amount", "Value");
        //}
        //else
        //{
        //    txtAmount1_F.Attributes.Add("onkeypress", "return FormatNumber(event,this.id,12,false,false);");
        //    txtAmount2_F.Attributes.Add("onkeypress", "return FormatNumber(event,this.id,12,false,false);");
        //    txtAmount1_F.Attributes.Add("onblur", "return formatCurrencyOnBlur(this);");
        //    txtAmount2_F.Attributes.Add("onblur", "return formatCurrencyOnBlur(this);");
        //    txtAmount1_F.MaxLength = txtAmount2_F.MaxLength = 17;
        //    cvAmount.ErrorMessage = cvAmount.ErrorMessage.Replace("Value", "Amount");
        //}
    }

    /// <summary>
    /// Amout Dropdown Changed.
    /// </summary>
    /// <param name="drpAmount_F"></param>
    /// <param name="lblAmountText1_F"></param>
    /// <param name="txtAmount1_F"></param>
    /// <param name="lblAmountText2_F"></param>
    /// <param name="txtAmount2_F"></param>
    protected void drpNumber_Changed(DropDownList drpNumber_F, Label lblNumberText1_F, TextBox txtNumber1_F, Label lblNumberText2_F, TextBox txtNumber2_F, CompareValidator cvNumber)
    {
        string strNumberValue = drpNumber_F.SelectedValue;

        switch (strNumberValue)
        {
            case "0":
                //lblNumberText1_F.Text = "$ ";
                lblNumberText1_F.Text = "";
                lblNumberText1_F.Visible = true;
                txtNumber1_F.Visible = true;
                lblNumberText2_F.Visible = false;
                txtNumber2_F.Visible = false;
                break;
            case "1":
                //lblNumberText1_F.Text = "$ ";                
                lblNumberText1_F.Text = "";
                lblNumberText1_F.Visible = true;
                txtNumber1_F.Visible = true;
                lblNumberText2_F.Visible = false;
                txtNumber2_F.Visible = false;
                break;
            case "2":
                //lblNumberText1_F.Text = "From $ ";
                lblNumberText1_F.Text = "From ";
                lblNumberText1_F.Visible = true;
                txtNumber1_F.Visible = true;
                lblNumberText2_F.Visible = true;
                lblNumberText2_F.Text = "To ";
                //lblNumberText2_F.Text = "To $ ";
                txtNumber2_F.Visible = true;
                break;
            case "3":
                //lblNumberText1_F.Text = "$ ";
                lblNumberText1_F.Text = "";
                lblNumberText1_F.Visible = true;
                txtNumber1_F.Visible = true;
                lblNumberText2_F.Visible = false;
                txtNumber2_F.Visible = false;
                break;
            case "4":
                //lblNumberText1_F.Text = "$ ";
                lblNumberText1_F.Text = "";
                lblNumberText1_F.Visible = true;
                txtNumber1_F.Visible = true;
                lblNumberText2_F.Visible = false;
                txtNumber2_F.Visible = false;
                break;
            case "5":
                //lblNumberText1_F.Text = "$ ";
                lblNumberText1_F.Text = "";
                lblNumberText1_F.Visible = true;
                txtNumber1_F.Visible = true;
                lblNumberText2_F.Visible = false;
                txtNumber2_F.Visible = false;
                break;

        }

        ///*
        // * It will set TextBox and Lable of associate Textbox,when filed is numeric but it is not Number filed
        // * */
        ////First Remove Attribute
        //txtNumber1_F.Attributes.Remove("onkeypress");
        //txtNumber2_F.Attributes.Remove("onkeypress");
        //txtNumber1_F.Attributes.Remove("onblur");
        //txtNumber2_F.Attributes.Remove("onblur");

        //txtNumber1_F.Attributes.Add("onkeypress", "return FormatInteger(event,this.id);");
        //txtNumber2_F.Attributes.Add("onkeypress", "return FormatInteger(event,this.id);");
        //txtNumber2_F.MaxLength = txtNumber1_F.MaxLength = 3;
        //cvNumber.ErrorMessage = cvNumber.ErrorMessage.Replace("Number", "Value");

    }

    /// <summary>
    /// return Comma saperated list of all selected item in listbox
    /// </summary>
    /// <param name="lstBox"></param>
    /// <returns></returns>
    public string GetSelectedItemString(ListBox lstBox, bool isStringValue)
    {
        string strValues = "";
        foreach (ListItem lstBoxItem in lstBox.Items)
        {
            if (lstBoxItem.Selected)
            {
                if (isStringValue)
                    strValues = strValues + "'" + lstBoxItem.Value.Replace("'", "''") + "',";
                else
                    strValues = strValues + lstBoxItem.Value.Replace("'", "''") + ",";
            }

        }
        return strValues.TrimEnd(',');
    }
    /// <summary>
    /// return Comma saperated list of all selected item in listbox
    /// </summary>
    /// <param name="lstBox"></param>
    /// <returns></returns>
    public string GetSelectedValueVarcharString(ListBox lstBox, bool isStringValue)
    {
        string strValues = "";
        foreach (ListItem lstBoxItem in lstBox.Items)
        {
            if (lstBoxItem.Selected)
            {
                if (isStringValue)
                    strValues = strValues + "'" + lstBoxItem.Value.Replace("'", "''") + "',";
                else
                    strValues = strValues + lstBoxItem.Value.Replace("'", "''") + ",";
            }

        }
        return strValues.TrimEnd(',');
    }
    /// <summary>
    /// return Comma saperated list of all selected item in listbox
    /// </summary>
    /// <param name="lstBox"></param>
    /// <returns></returns>
    public string GetAllItemString(ListBox lstBox, bool isStringValue)
    {
        string strValues = "";
        foreach (ListItem lstBoxItem in lstBox.Items)
        {
            if (isStringValue)
                strValues = strValues + "'" + lstBoxItem.Value.Replace("'", "''") + "',";
            else
                strValues = strValues + lstBoxItem.Value.Replace("'", "''") + ",";

        }
        return strValues.TrimEnd(',');
    }
    /// <summary>
    /// Get Where condition when Type is Listbox
    /// </summary>
    /// <param name="lstWhereFiels"></param>
    /// <param name="strCondition"></param>
    /// <returns></returns>
    public string GetListBoxWhereCondition(string lstWhereFiels, string strCondition, bool IsNotSelected)
    {
        string strNewList = string.Empty;
        string strWhere = string.Empty;
        string[] arrwhere = strCondition.Split(',');
        //When Match with Char like [filed_name] in ('O,C')
        if (!string.IsNullOrEmpty(lstWhereFiels) && lstWhereFiels == "[Policy].Policy_Type" && !string.IsNullOrEmpty(strCondition))
        {
            strWhere = " And ";
            for (int intI = 0; intI < arrwhere.Length; intI++)
            {
                strNewList += "'" + arrwhere[intI] + "',";
            }
            if (IsNotSelected == true)
                strWhere = " And " + lstWhereFiels + " NOT IN (" + strNewList.TrimEnd(',') + ") ";
            else
                strWhere = " And " + lstWhereFiels + " IN (" + strNewList.TrimEnd(',') + ") ";
        }
        else if (!string.IsNullOrEmpty(lstWhereFiels) && !string.IsNullOrEmpty(strCondition))
        {
            if (IsNotSelected == true)
            {
                if (lstWhereFiels == "[C].Fk_LU_Police_Report_Audit")
                    strWhere = " And (" + lstWhereFiels + " NOT IN (" + strCondition + ") OR " + lstWhereFiels + " Is Null)";
                else
                    strWhere = " And " + lstWhereFiels + " NOT IN (" + strCondition + ") ";
            }
            else
                strWhere = " And " + lstWhereFiels + " IN (" + strCondition + ") ";
        }

        return strWhere;
    }
    /// <summary>
    ///  Get Where condition when Type is TextBox
    /// </summary>
    /// <param name="strFieldName"></param>
    /// <param name="strText"></param>
    /// <param name="drpIndex"></param>
    /// <returns></returns>
    public string GetTextWhereCondition(string strFieldName, string strText, int drpIndex, bool IsNotSelected)
    {
        string strWhere = string.Empty;
        string strFilter = string.Empty;

        if (!string.IsNullOrEmpty(strText))
        {
            if (strFieldName.Contains("Date_Theft_Reported"))
                strWhere = " And (CONVERT(VARCHAR," + strFieldName + " ,108))";
            else strWhere = " And " + strFieldName;
            if (IsNotSelected == true)
            {
                if (drpIndex == 1)
                    strWhere += " NOT LIKE  '%" + strText.Trim().Replace("'", "''") + "%' ";
                else if (drpIndex == 2)
                    strWhere += " NOT LIKE '" + strText.Trim().Replace("'", "''") + "%'";
                else if (drpIndex == 3)
                    strWhere += " NOT LIKE '%" + strText.Trim().Replace("'", "''") + "'";
            }
            else
            {
                if (drpIndex == 1)
                    strWhere += " LIKE  '%" + strText.Trim().Replace("'", "''") + "%' ";
                else if (drpIndex == 2)
                    strWhere += " LIKE '" + strText.Trim().Replace("'", "''") + "%'";
                else if (drpIndex == 3)
                    strWhere += " LIKE '%" + strText.Trim().Replace("'", "''") + "'";
            }
        }
        return strWhere;
    }
    /// <summary>
    ///  Get Where condition when Type is DateTime
    /// </summary>
    /// <param name="strFieldName"></param>
    /// <param name="strDatefrom"></param>
    /// <param name="strDateTo"></param>
    /// <param name="cblDateCriteria"></param>
    /// <returns></returns>
    public string GetDateWhereCondtion(string strFieldName, string strDatefrom, string strDateTo, string cblDateCriteria, bool IsNotSelected)
    {
        string strWhere = string.Empty;

        DateTime? dtFrom = null, dtTo = null;


        dtFrom = clsGeneral.FormatNullDateToStore(strDatefrom);

        dtTo = clsGeneral.FormatNullDateToStore(strDateTo);

        Business_RuleHelper.DateCriteria DtType = Business_RuleHelper.DateCriteria.On;

        if (cblDateCriteria == "O")
            DtType = Business_RuleHelper.DateCriteria.On;
        else if (cblDateCriteria == "BF")
            DtType = Business_RuleHelper.DateCriteria.Before;
        else if (cblDateCriteria == "A")
            DtType = Business_RuleHelper.DateCriteria.After;
        else if (cblDateCriteria == "B")
            DtType = Business_RuleHelper.DateCriteria.Between;

        if (dtFrom.HasValue)
            strWhere = Business_RuleHelper.GetDateWhereAbsolute(strFieldName, dtFrom, dtTo, DtType, IsNotSelected);

        else if (dtTo.HasValue)
            strWhere = Business_RuleHelper.GetDateWhereAbsolute(strFieldName, dtFrom, dtTo, DtType, IsNotSelected);

        return strWhere;
    }
    /// <summary>
    ///  Get Where condition when Type is Amount
    /// </summary>
    /// <param name="strField_Header"></param>
    /// <param name="strAmtfrom"></param>
    /// <param name="strAmtTo"></param>
    /// <param name="drpAmtCriteria"></param>
    /// <returns></returns>
    public string GetDateAmountCondtion(string strField_Header, string strAmtfrom, string strAmtTo, string drpAmtCriteria, bool IsNotSelected)
    {
        string strWhere = string.Empty;
        Business_RuleHelper.AmountCriteria AmtType = Business_RuleHelper.AmountCriteria.Equal;

        decimal? dFrom = null;
        decimal? dTo = null;

        if (!string.IsNullOrEmpty(strAmtfrom))
            dFrom = Convert.ToDecimal(strAmtfrom);

        if (!string.IsNullOrEmpty(strAmtTo))
            dTo = Convert.ToDecimal(strAmtTo);

        if (Convert.ToInt16(drpAmtCriteria) == (int)Business_RuleHelper.AmountCriteria.Equal)
            AmtType = Business_RuleHelper.AmountCriteria.Equal;
        else if (Convert.ToInt16(drpAmtCriteria) == (int)Business_RuleHelper.AmountCriteria.GreaterThan)
            AmtType = Business_RuleHelper.AmountCriteria.GreaterThan;
        else if (Convert.ToInt16(drpAmtCriteria) == (int)Business_RuleHelper.AmountCriteria.Between)
            AmtType = Business_RuleHelper.AmountCriteria.Between;
        else if (Convert.ToInt16(drpAmtCriteria) == (int)Business_RuleHelper.AmountCriteria.LessThan)
            AmtType = Business_RuleHelper.AmountCriteria.LessThan;

        if (dFrom.HasValue)
            strWhere = Business_RuleHelper.GetAmountWhere(strField_Header.Trim(), dFrom, dTo, AmtType, IsNotSelected);
        else if (dTo.HasValue)
            strWhere = Business_RuleHelper.GetAmountWhere(strField_Header.Trim(), dFrom, dTo, AmtType, IsNotSelected);

        return strWhere;
    }
    /// <summary>
    /// Get Filter IDs from DropdownList.
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <returns></returns>
    public string GetFilterIDs(DropDownList[] dropDowns)
    {
        string strIDs = string.Empty;
        foreach (DropDownList ddlToFill in dropDowns)
        {
            if (ddlToFill.SelectedIndex > 0)
                strIDs = strIDs += ddlToFill.SelectedItem.Value.Replace("'", "''") + ",";
        }
        return strIDs.TrimEnd(',');
    }
    /// <summary>
    /// Set Relative Date TexBox Control
    /// </summary>
    private void SetRelativeDateControl(TextBox txtDate, HtmlImage Img1, bool isEnable)
    {
        txtDate.Enabled = (!isEnable);
        Img1.Disabled = (isEnable);
    }
    /// <summary>
    /// Set All Relative Date 
    /// </summary>
    private void SetRelativeDateControl()
    {
        Business_RuleHelper.RaltiveDates NotSet = Business_RuleHelper.RaltiveDates.NotSet;
        txtDate_From1.Enabled = (ucRelativeDatesFrom_1.RelativeDate == NotSet);
        imgDate_Opened_From1.Disabled = ucRelativeDatesFrom_1.RelativeDate != NotSet;
        txtDate_To1.Enabled = (ucRelativeDatesTo_1.RelativeDate == NotSet);
        imgDate_To1.Disabled = ucRelativeDatesTo_1.RelativeDate != NotSet;
        txtDate_From2.Enabled = (ucRelativeDatesFrom_2.RelativeDate == NotSet);
        imgDate_Opened_From2.Disabled = ucRelativeDatesFrom_2.RelativeDate != NotSet;
        txtDateTo2.Enabled = (ucRelativeDatesTo_2.RelativeDate == NotSet);
        imgDate_To2.Disabled = ucRelativeDatesTo_2.RelativeDate != NotSet;
        txtDate_From3.Enabled = (ucRelativeDatesFrom_3.RelativeDate == NotSet);
        imgDate_Opened_From3.Disabled = ucRelativeDatesFrom_3.RelativeDate != NotSet;
        txtDate_To3.Enabled = (ucRelativeDatesTo_3.RelativeDate == NotSet);
        imgDate_To3.Disabled = ucRelativeDatesTo_3.RelativeDate != NotSet;
        txtDate_From4.Enabled = (ucRelativeDatesFrom_4.RelativeDate == NotSet);
        imgDate_Opened_From4.Disabled = ucRelativeDatesFrom_4.RelativeDate != NotSet;
        txtDate_To4.Enabled = (ucRelativeDatesTo_4.RelativeDate == NotSet);
        imgDate_To4.Disabled = ucRelativeDatesTo_4.RelativeDate != NotSet;
        txtDate_From5.Enabled = (ucRelativeDatesFrom_5.RelativeDate == NotSet);
        imgDate_Opened_From5.Disabled = ucRelativeDatesFrom_5.RelativeDate != NotSet;
        txtDate_To5.Enabled = (ucRelativeDatesTo_5.RelativeDate == NotSet);
        imgDate_To5.Disabled = ucRelativeDatesTo_5.RelativeDate != NotSet;
        txtDate_From_Action.Enabled = (ucRelativeDatesFrom_Action.RelativeDate == NotSet);
        imgDate_Opened_From_Action.Disabled = ucRelativeDatesFrom_Action.RelativeDate != NotSet;
        txtDate_To_Action.Enabled = (ucRelativeDatesTo_Action.RelativeDate == NotSet);
        imgDate_To_Action.Disabled = ucRelativeDatesTo_Action.RelativeDate != NotSet;

    }
    /// <summary>
    /// Set Attribute to Date Image.
    /// </summary>
    /// <param name="pnlDate_FID">Panel ID</param>
    private void SetDefaultDate(string pnlDate_FID)
    {
        //Set Default Date selected Criteria,Relative date,
        if (pnlDate_FID == "pnlDate_F1")
        {
            imgDate_Opened_From1.Attributes.Add("onclick", "return showCalendar('" + txtDate_From1.ClientID + "', 'mm/dd/y','','')");
            txtDate_To1.Text = txtDate_From1.Text = string.Empty;
            lstDate1.SelectedValue = "O";
            rdbLstDate_SelectedIndexChanged(lstDate1, null);
            ucRelativeDatesFrom_1.RelativeDate = ucRelativeDatesTo_1.RelativeDate = Business_RuleHelper.RaltiveDates.NotSet;
        }
        else if (pnlDate_FID == "pnlDate_F2")
        {
            imgDate_Opened_From2.Attributes.Add("onclick", "return showCalendar('" + txtDate_From2.ClientID + "', 'mm/dd/y','','')");
            txtDateTo2.Text = txtDate_From2.Text = string.Empty;
            lstDate2.SelectedValue = "O";
            rdbLstDate_SelectedIndexChanged(lstDate2, null);
            ucRelativeDatesFrom_2.RelativeDate = ucRelativeDatesTo_2.RelativeDate = Business_RuleHelper.RaltiveDates.NotSet;
        }
        else if (pnlDate_FID == "pnlDate_F3")
        {
            imgDate_Opened_From3.Attributes.Add("onclick", "return showCalendar('" + txtDate_From3.ClientID + "', 'mm/dd/y','','')");
            txtDate_To3.Text = txtDate_From3.Text = string.Empty;
            lstDate3.SelectedValue = "O";
            rdbLstDate_SelectedIndexChanged(lstDate3, null);
            ucRelativeDatesFrom_3.RelativeDate = ucRelativeDatesTo_3.RelativeDate = Business_RuleHelper.RaltiveDates.NotSet;
        }
        else if (pnlDate_FID == "pnlDate_F4")
        {
            imgDate_Opened_From4.Attributes.Add("onclick", "return showCalendar('" + txtDate_From4.ClientID + "', 'mm/dd/y','','')");
            txtDate_To4.Text = txtDate_From4.Text = string.Empty;
            lstDate4.SelectedValue = "O";
            rdbLstDate_SelectedIndexChanged(lstDate4, null);
            ucRelativeDatesFrom_4.RelativeDate = ucRelativeDatesTo_4.RelativeDate = Business_RuleHelper.RaltiveDates.NotSet;
        }
        else if (pnlDate_FID == "pnlDate_F5")
        {
            imgDate_Opened_From5.Attributes.Add("onclick", "return showCalendar('" + txtDate_From5.ClientID + "', 'mm/dd/y','','')");
            txtDate_To5.Text = txtDate_From5.Text = string.Empty;
            lstDate5.SelectedValue = "O";
            rdbLstDate_SelectedIndexChanged(lstDate5, null);
            ucRelativeDatesFrom_5.RelativeDate = ucRelativeDatesTo_5.RelativeDate = Business_RuleHelper.RaltiveDates.NotSet;
        }
        else if (pnlDate_FID == "pnlDate_F_Action")
        {
            imgDate_Opened_From_Action.Attributes.Add("onclick", "return showCalendar('" + txtDate_From_Action.ClientID + "', 'mm/dd/y','','')");
            txtDate_To_Action.Text = txtDate_From_Action.Text = string.Empty;
            lstDate_Action.SelectedValue = "O";
            //rdbLstDate_SelectedIndexChanged(lstDate_Action, null);
            ucRelativeDatesFrom_Action.RelativeDate = ucRelativeDatesTo_Action.RelativeDate = Business_RuleHelper.RaltiveDates.NotSet;
        }

        SetRelativeDateControl();
    }
    /// <summary>
    /// Set Default Amount
    /// </summary>
    /// <param name="pnmAmount"></param>
    private void SetDefaultAmount(string pnlAmount_F_ID, bool IsDollar)
    {
        // Set Default Amount,Filter Option and Value
        if (pnlAmount_F_ID == "pnlAmount_F1")
        {
            txtAmount1_F1.Text = txtAmount2_F1.Text = string.Empty;
            if (!IsDollar)
                lblAmountText1_F1.Text = lblAmountText2_F1.Text = string.Empty;
            else
                lblAmountText1_F1.Text = lblAmountText2_F1.Text = "$ ";
            drpAmount_F1.SelectedValue = Convert.ToString((int)Business_RuleHelper.AmountCriteria.Equal);
            drpAmount_F_SelectedIndexChanged(drpAmount_F1, null);

        }
        else if (pnlAmount_F_ID == "pnlAmount_F2")
        {
            txtAmount1_F2.Text = txtAmount2_F2.Text = string.Empty;
            if (!IsDollar)
                lblAmountText1_F2.Text = lblAmountText2_F2.Text = string.Empty;
            else
                lblAmountText1_F2.Text = lblAmountText2_F2.Text = "$ ";
            drpAmount_F2.SelectedValue = Convert.ToString((int)Business_RuleHelper.AmountCriteria.Equal);
            drpAmount_F_SelectedIndexChanged(drpAmount_F2, null);

        }
        else if (pnlAmount_F_ID == "pnlAmount_F3")
        {
            txtAmount1_F3.Text = txtAmount2_F3.Text = string.Empty;
            if (!IsDollar)
                lblAmountText1_F3.Text = lblAmountText2_F3.Text = string.Empty;
            else
                lblAmountText1_F3.Text = lblAmountText2_F3.Text = "$ ";
            drpAmount_F3.SelectedValue = Convert.ToString((int)Business_RuleHelper.AmountCriteria.Equal);
            drpAmount_F_SelectedIndexChanged(drpAmount_F3, null);

        }
        else if (pnlAmount_F_ID == "pnlAmount_F4")
        {
            txtAmount1_F4.Text = txtAmount2_F4.Text = string.Empty;
            if (!IsDollar)
                lblAmountText1_F4.Text = lblAmountText2_F4.Text = string.Empty;
            else
                lblAmountText1_F4.Text = lblAmountText2_F4.Text = "$ ";
            drpAmount_F4.SelectedValue = Convert.ToString((int)Business_RuleHelper.AmountCriteria.Equal);
            drpAmount_F_SelectedIndexChanged(drpAmount_F4, null);

        }
        else if (pnlAmount_F_ID == "pnlAmount_F5")
        {
            txtAmount1_F5.Text = txtAmount2_F5.Text = string.Empty;
            if (!IsDollar)
                lblAmountText1_F5.Text = lblAmountText2_F5.Text = string.Empty;
            else
                lblAmountText1_F5.Text = lblAmountText2_F5.Text = "$ ";
            drpAmount_F5.SelectedValue = Convert.ToString((int)Business_RuleHelper.AmountCriteria.Equal);
            drpAmount_F_SelectedIndexChanged(drpAmount_F5, null);

        }

    }
    /// <summary>
    /// Set Default Number
    /// </summary>
    /// <param name="pnmAmount"></param>
    private void SetDefaultNumber(string pnlNumber_F_ID)
    {
        // Set Default Number,Filter Option and Value
        if (pnlNumber_F_ID == "pnlNumber_F1")
        {
            txtNumber1_F1.Text = txtNumber2_F1.Text = string.Empty;
            lblNumberText1_F1.Text = lblNumberText2_F1.Text = string.Empty;
            drpNumber_F1.SelectedValue = Convert.ToString((int)Business_RuleHelper.NumberCriteria.Equal);
            drpNumber_F_SelectedIndexChanged(drpNumber_F1, null);

        }
        //else if (pnlNumber_F_ID == "pnlNumber_F2")
        //{
        //    txtNumber1_F2.Text = txtNumber2_F2.Text = string.Empty;
        //    if (!IsDollar)
        //        lblNumberText1_F2.Text = lblNumberText2_F2.Text = string.Empty;
        //    else
        //        lblNumberText1_F2.Text = lblNumberText2_F2.Text = "$ ";
        //    drpNumber_F2.SelectedValue = Convert.ToString((int)Business_RuleHelper.NumberCriteria.Equal);
        //    drpNumber_F_SelectedIndexChanged(drpNumber_F2, null);

        //}
        //else if (pnlNumber_F_ID == "pnlNumber_F3")
        //{
        //    txtNumber1_F3.Text = txtNumber2_F3.Text = string.Empty;
        //    if (!IsDollar)
        //        lblNumberText1_F3.Text = lblNumberText2_F3.Text = string.Empty;
        //    else
        //        lblNumberText1_F3.Text = lblNumberText2_F3.Text = "$ ";
        //    drpNumber_F3.SelectedValue = Convert.ToString((int)Business_RuleHelper.NumberCriteria.Equal);
        //    drpNumber_F_SelectedIndexChanged(drpNumber_F3, null);

        //}
        //else if (pnlNumber_F_ID == "pnlNumber_F4")
        //{
        //    txtNumber1_F4.Text = txtNumber2_F4.Text = string.Empty;
        //    if (!IsDollar)
        //        lblNumberText1_F4.Text = lblNumberText2_F4.Text = string.Empty;
        //    else
        //        lblNumberText1_F4.Text = lblNumberText2_F4.Text = "$ ";
        //    drpNumber_F4.SelectedValue = Convert.ToString((int)Business_RuleHelper.NumberCriteria.Equal);
        //    drpNumber_F_SelectedIndexChanged(drpNumber_F4, null);

        //}
        //else if (pnlNumber_F_ID == "pnlNumber_F5")
        //{
        //    txtNumber1_F5.Text = txtNumber2_F5.Text = string.Empty;
        //    if (!IsDollar)
        //        lblNumberText1_F5.Text = lblNumberText2_F5.Text = string.Empty;
        //    else
        //        lblNumberText1_F5.Text = lblNumberText2_F5.Text = "$ ";
        //    drpNumber_F5.SelectedValue = Convert.ToString((int)Business_RuleHelper.NumberCriteria.Equal);
        //    drpNumber_F_SelectedIndexChanged(drpNumber_F5, null);

        //}

    }
    /// <summary>
    /// Set Default TextBox
    /// </summary>
    /// <param name="pnlText_F"></param>
    private void SetDefaultTExtBox(string pnlText_F)
    {
        //Set Default Textbox value,Filter option
        if (pnlText_F == "pnlText_F1")
        {
            txtFilter1.Text = string.Empty;
            drpText_F1.SelectedValue = "1";
        }
        else if (pnlText_F == "pnlText_F2")
        {
            txtFilter2.Text = string.Empty;
            drpText_F2.SelectedValue = "1";
        }
        else if (pnlText_F == "pnlText_F3")
        {
            txtFilter3.Text = string.Empty;
            drpText_F3.SelectedValue = "1";
        }
        else if (pnlText_F == "pnlText_F4")
        {
            txtFilter4.Text = string.Empty;
            drpText_F4.SelectedValue = "1";
        }
        else if (pnlText_F == "pnlText_F5")
        {
            txtFilter5.Text = string.Empty;
            drpText_F5.SelectedValue = "1";
        }

    }

    #endregion

    #region "Save Rule & Reload Rule"

    /// <summary>
    /// Saves the rule
    /// </summary>
    public void SaveRule(bool blnOverWrite)
    {
        decimal decValue;
        bool CriteriaNotMet;
        StringBuilder strRule = new StringBuilder();

        if (drpModule.SelectedItem.Text.ToLower().Contains("claim"))
        {
            string strMajorCov = "";
            switch (drpModule.SelectedItem.Text)
            {
                case "Auto Claims": strMajorCov = "30"; break;
                case "PD Claims": strMajorCov = "40"; break;
                case "WC Claims": strMajorCov = "10"; break;
                case "Legal Claims": strMajorCov = "70"; break;
                case "Personal Injury Claims": strMajorCov = "80"; break;
                case "Equipment Claims": strMajorCov = "60"; break;
                case "Cargo Claims": strMajorCov = "50"; break;
            }
            //strRule.Append(" AND Claim.Major_Coverage = '" + strMajorCov + "' ");
        }

        if (drpFilter1.SelectedIndex > 0)
        {
            decValue = Convert.ToDecimal(drpFilter1.SelectedItem.Value);
            CriteriaNotMet = chkNotCriteria1.Checked;
            bool blnMultiselectString = false;
            if (lst_F1.Items.Count > 0)
            {
                if (lst_F1.Items[0].Value == "Y")
                    blnMultiselectString = true;
                else if (GetIfDrpValueString(drpFilter1.SelectedItem.Text))
                    blnMultiselectString = true;
            }
            strRule.Append(SaveFilterCriteriadb(decValue, Convert.ToString(drpText_F1.SelectedValue), txtFilter1.Text, GetSelectedItemString(lst_F1, blnMultiselectString), lstDate1.SelectedValue, txtDate_From1.Text, txtDate_To1.Text, Convert.ToString(drpAmount_F1.SelectedValue), txtAmount1_F1.Text, txtAmount2_F1.Text, Convert.ToString(drpNumber_F1.SelectedValue), txtNumber1_F1.Text, txtNumber2_F1.Text, ucRelativeDatesFrom_1.RelativeDate, ucRelativeDatesTo_1.RelativeDate, CriteriaNotMet).Replace("FK_LU_Transaction_Status", "FK_LU_Status"));
        }

        if (drpFilter2.SelectedIndex > 0)
        {
            decValue = Convert.ToDecimal(drpFilter2.SelectedItem.Value);
            CriteriaNotMet = chkNotCriteria2.Checked;
            bool blnMultiselectString2 = false;
            if (lst_F2.Items.Count > 0)
            {
                if (lst_F2.Items[0].Value == "Y")
                    blnMultiselectString2 = true;
                else if (GetIfDrpValueString(drpFilter2.SelectedItem.Text))
                    blnMultiselectString2 = true;
            }
            strRule.Append(SaveFilterCriteriadb(decValue, Convert.ToString(drpText_F2.SelectedValue), txtFilter2.Text, GetSelectedItemString(lst_F2, blnMultiselectString2), lstDate2.SelectedValue, txtDate_From2.Text, txtDateTo2.Text, Convert.ToString(drpAmount_F2.SelectedValue), txtAmount1_F2.Text, txtAmount2_F2.Text, Convert.ToString(drpNumber_F2.SelectedValue), txtNumber1_F2.Text, txtNumber2_F2.Text, ucRelativeDatesFrom_2.RelativeDate, ucRelativeDatesTo_2.RelativeDate, CriteriaNotMet).Replace("FK_LU_Transaction_Status", "FK_LU_Status"));
        }

        if (drpFilter3.SelectedIndex > 0)
        {
            decValue = Convert.ToDecimal(drpFilter3.SelectedItem.Value);
            CriteriaNotMet = chkNotCriteria3.Checked;
            bool blnMultiselectString3 = false;
            if (lst_F3.Items.Count > 0)
            {
                if (lst_F3.Items[0].Value == "Y")
                    blnMultiselectString3 = true;
                else if (GetIfDrpValueString(drpFilter3.SelectedItem.Text))
                    blnMultiselectString3 = true;
            }
            strRule.Append(SaveFilterCriteriadb(decValue, Convert.ToString(drpText_F3.SelectedValue), txtFilter3.Text, GetSelectedItemString(lst_F3, blnMultiselectString3), lstDate3.SelectedValue, txtDate_From3.Text, txtDate_To3.Text, Convert.ToString(drpAmount_F3.SelectedValue), txtAmount1_F3.Text, txtAmount2_F3.Text, Convert.ToString(drpNumber_F3.SelectedValue), txtNumber1_F3.Text, txtNumber2_F3.Text, ucRelativeDatesFrom_3.RelativeDate, ucRelativeDatesTo_3.RelativeDate, CriteriaNotMet).Replace("FK_LU_Transaction_Status", "FK_LU_Status"));
        }

        if (drpFilter4.SelectedIndex > 0)
        {
            decValue = Convert.ToDecimal(drpFilter4.SelectedItem.Value);
            CriteriaNotMet = chkNotCriteria4.Checked;
            bool blnMultiselectString4 = false;
            if (lst_F4.Items.Count > 0)
            {
                if (lst_F4.Items[0].Value == "Y")
                    blnMultiselectString4 = true;
                else if (GetIfDrpValueString(drpFilter4.SelectedItem.Text))
                    blnMultiselectString4 = true;
            }
            strRule.Append(SaveFilterCriteriadb(decValue, Convert.ToString(drpText_F4.SelectedValue), txtFilter4.Text, GetSelectedItemString(lst_F4, blnMultiselectString4), lstDate4.SelectedValue, txtDate_From4.Text, txtDate_To4.Text, Convert.ToString(drpAmount_F4.SelectedValue), txtAmount1_F4.Text, txtAmount2_F4.Text, Convert.ToString(drpNumber_F4.SelectedValue), txtNumber1_F4.Text, txtNumber2_F4.Text, ucRelativeDatesFrom_4.RelativeDate, ucRelativeDatesTo_4.RelativeDate, CriteriaNotMet).Replace("FK_LU_Transaction_Status", "FK_LU_Status"));
        }

        if (drpFilter5.SelectedIndex > 0)
        {
            decValue = Convert.ToDecimal(drpFilter5.SelectedItem.Value);
            CriteriaNotMet = chkNotCriteria5.Checked;
            bool blnMultiselectString5 = false;
            if (lst_F5.Items.Count > 0)
            {
                if (lst_F5.Items[0].Value == "Y")
                    blnMultiselectString5 = true;
                else if (GetIfDrpValueString(drpFilter5.SelectedItem.Text))
                    blnMultiselectString5 = true;
            }
            strRule.Append(SaveFilterCriteriadb(decValue, Convert.ToString(drpText_F5.SelectedValue), txtFilter5.Text, GetSelectedItemString(lst_F5, blnMultiselectString5), lstDate5.SelectedValue, txtDate_From5.Text, txtDate_To5.Text, Convert.ToString(drpAmount_F5.SelectedValue), txtAmount1_F5.Text, txtAmount2_F5.Text, Convert.ToString(drpNumber_F5.SelectedValue), txtNumber1_F5.Text, txtNumber2_F5.Text, ucRelativeDatesFrom_5.RelativeDate, ucRelativeDatesTo_5.RelativeDate, CriteriaNotMet).Replace("FK_LU_Transaction_Status", "FK_LU_Status"));
        }

        List<string> UpdateValues = new List<string>();
        if (drpFilter_Action.SelectedIndex > 0)
        {
            UpdateValues = SaveActionFilterCriteria();
        }

        clsBusiness_Rules objBusiness_Rules = new clsBusiness_Rules();

        objBusiness_Rules.PK_Business_Rules = PK_Business_Rule_Managgement;
        objBusiness_Rules.Rule_Name = txtRuleName.Text.Trim();
        objBusiness_Rules.Rule_Description = txtDescription.Text.Trim();
        objBusiness_Rules.Evaluation_Criteria = strRule.ToString().Trim();
        objBusiness_Rules.Action_Timing = rdListEvaluation.SelectedValue;
        objBusiness_Rules.FK_Business_Rules_Modules = Convert.ToDecimal(drpModule.SelectedValue);
        objBusiness_Rules.FK_Business_Rules_Screens = Convert.ToDecimal(drpScreen.SelectedValue);
        objBusiness_Rules.Action_Type = drpAction_Type.SelectedValue;
        switch (drpAction_Type.SelectedValue)
        {
            case "Update":
               
                objBusiness_Rules.New_Value = UpdateValues[1];
                objBusiness_Rules.Field_To_Update = UpdateValues[0];
                objBusiness_Rules.Table_Name = GetTableName(UpdateValues[2]);
                objBusiness_Rules.FK_Field_To_Update = Convert.ToDecimal(drpFilter_Action.SelectedValue);
                if (CheckdropdownType(objBusiness_Rules.Table_Name + "." + objBusiness_Rules.Field_To_Update) == "YesNoUnknown")
                {
                    if (UpdateValues[1] == "'-1'")
                        objBusiness_Rules.New_Value = "null";
                }

                if (UpdateValues[3] == "2")
                    objBusiness_Rules.IsDirectValue = true;
                else
                {
                    objBusiness_Rules.IsDirectValue = Convert.ToBoolean(drpDirectDerived.SelectedValue);
                    if (!objBusiness_Rules.IsDirectValue)
                        objBusiness_Rules.FK_Derived_Field = Convert.ToDecimal(drpFilter_Derived.SelectedValue);                        
                }
                break;
            case "Email":
                objBusiness_Rules.Table_Name = GetTableNameFromScreen();
                objBusiness_Rules.Recipient_IDs = txtIAssignToID.Value;
                txtIAssignTo.Text = Request.Form[txtIAssignTo.UniqueID];
                objBusiness_Rules.EMail_Subject = txtEmailSubject.Text.Trim();
                objBusiness_Rules.EMail_Body = txtEmailBody.Text.Trim();
                string EmailAddFields = GetEmailAddressFields();
                if (!string.IsNullOrEmpty(EmailAddFields))
                    objBusiness_Rules.Email_Recipient_Fields = EmailAddFields;
                break;
            case "Diary":
                objBusiness_Rules.Table_Name = GetTableNameFromScreen();
                objBusiness_Rules.Diary_Assigned_To = Request.Form[txtIAssignToDiary.UniqueID];
                txtIAssignToDiary.Text = Request.Form[txtIAssignToDiary.UniqueID];
                objBusiness_Rules.Diary_Note = txtDiaryNote.Text.Trim();
                if(txtDiaryDate.Text.Trim() != "") objBusiness_Rules.Diary_Date_Value = Convert.ToInt32(txtDiaryDate.Text.Trim().Replace(",",""));
                objBusiness_Rules.Diary_To_Current_User = chkCurrentUser.Checked;
                objBusiness_Rules.Diary_Assign_To_Contact = GetContactFields();
                break;
            default:
                break;
        }

        objBusiness_Rules.Updated_By = clsSession.UserID;
        objBusiness_Rules.Update_Date = DateTime.Now;
        objBusiness_Rules.Overwrite = blnOverWrite;
        decimal PK = 0;
        if (PK_Business_Rule_Managgement > 0)
            PK = objBusiness_Rules.Update();
        else
            PK = objBusiness_Rules.Insert();

        if (!(PK > 0))
        {
            int intPK = Convert.ToInt16(PK);
            switch (intPK)
            {
                case -2:
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The Business Rule Name already exists');", true);
                    break;
                case -3:
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmNeeded", "__doPostBack('UserConfirmationPostBack',  window.confirm('The Business Rule with the provided Evaluation Criteria,Action Timing,Field To Update and Table Name already exists. Press OK to Coutinue anyway.'));", true);
                    break;
                case -4:
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmNeeded", "__doPostBack('UserConfirmationPostBack',  window.confirm('The Business Rule with the provided Evaluation Criteria,Action Timing and Email subject already exists. Press OK to Coutinue anyway'));", true);
                    break;
                case -5:
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmNeeded", "__doPostBack('UserConfirmationPostBack',  window.confirm('The Business Rule with the provided Evaluation Criteria,Action Timing,Diary assign to,Diary date and Diary note already exists. Press OK to Coutinue anyway'));", true);
                    break;
                default:
                    break;
            }
        }
        else
        {
            PK_Business_Rule_Managgement = PK;
            SaveRuleFilter(PK_Business_Rule_Managgement);
            if (drpAction_Type.SelectedValue == "Email")
                SaveEmailFields(PK);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The Rule saved successfully!');", true);
        }
    }
    /// <summary>
    /// Gets the FK for the fields to be included as recipients
    /// </summary>
    /// <returns></returns>
    private string GetEmailAddressFields()
    {
        string strReturn = string.Empty;
        for (int i = 0; i <= chkEmailFields.Items.Count - 1; i++)
        {
            if (chkEmailFields.Items[i].Selected == true)
            {
                //decimal Fk_Field = Convert.ToDecimal(chkEmailFields.Items[i].Value);
                //List<ERIMS_DAL.clsBusiness_Rules_Fields> lstAdHoc;
                //lstAdHoc = new ERIMS_DAL.clsBusiness_Rules_Fields().SelectByPK(Fk_Field);
                //strReturn = strReturn + lstAdHoc[0].Table_Name + "." + lstAdHoc[0].Field_Name + ",";
                strReturn = strReturn + chkEmailFields.Items[i].Value + ",";
            }
        }
        strReturn = strReturn.TrimEnd(',');
        return strReturn;
    }

    private string GetContactFields()
    {
        string strReturn = string.Empty;
        for (int i = 0; i <= chkContactFields.Items.Count - 1; i++)
        {
            if (chkContactFields.Items[i].Selected == true)
            {
                strReturn = strReturn + chkContactFields.Items[i].Value + ",";
            }
        }
        strReturn = strReturn.TrimEnd(',');
        return strReturn;
    }
    /// <summary>
    /// Saves the fields to be sent with email
    /// </summary>
    /// <param name="FK_Rule"></param>
    private void SaveEmailFields(decimal FK_Rule)
    {
        Business_Rules_Email_Fields.DeleteByFK(FK_Rule);
        for (int i = 0; i <= chkFields.Items.Count - 1; i++)
        {
            if (chkFields.Items[i].Selected == true)
            {
                Business_Rules_Email_Fields objBusiness_Rules_Email_Fields = new Business_Rules_Email_Fields();
                decimal Fk_Field = Convert.ToDecimal(chkFields.Items[i].Value);
                List<ERIMS.DAL.clsBusiness_Rules_Fields> lstAdHoc;
                lstAdHoc = new ERIMS.DAL.clsBusiness_Rules_Fields().SelectByPK(Fk_Field);
                lstAdHoc[0].On_Screen_Descriptior = lstAdHoc[0].On_Screen_Descriptior.Replace("'", "''");
                switch (lstAdHoc[0].Field_Type)
                {
                    case 1:
                        objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + ISNULL(CAST(" + GetTableName(lstAdHoc[0].Table_Name) + "." + lstAdHoc[0].Field_Name + " AS VARCHAR(2000)),'')";
                        break;
                    case 2:
                        if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location d/b/a" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "dealership/collision center"
                                        || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "dealership dba" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "sonic location d/b/a")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (ISNULL(dba,''))";
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "legal entity" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "legal entity name")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (ISNULL(legal_entity,''))";
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location f/k/a")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "SELECT ISNULL(fka,'') FROM LU_Location_FKA WHERE 1=1 AND LU_Location_FKA.FK_LU_Location_ID=" + lstAdHoc[0].Table_Name + "." + lstAdHoc[0].Field_Name;
                            objBusiness_Rules_Email_Fields.Email_Fields = "ISNULL((" + objBusiness_Rules_Email_Fields.Email_Fields + "),'')";
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (" + objBusiness_Rules_Email_Fields.Email_Fields + ")";
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "sonic location code" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location number" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location code")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (ISNULL(Cast(Sonic_Location_Code as varchar(50)),''))";
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "location rm number")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (ISNULL(RM_Location_Number,''))";
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "region")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (ISNULL(region,''))";
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "associate state")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "SELECT ISNULL(FLD_state,'') FROM State WHERE 1=1 AND State.PK_ID= " + lstAdHoc[0].Table_Name + "." + lstAdHoc[0].Field_Name;
                            objBusiness_Rules_Email_Fields.Email_Fields = "ISNULL((" + objBusiness_Rules_Email_Fields.Email_Fields + "),'')";
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (" + objBusiness_Rules_Email_Fields.Email_Fields + ")";
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "primary/physical state" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "building state"
                                || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "insured state" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "payees state"
                                || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "assessment state")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "SELECT ISNULL(FLD_state,'') FROM State WHERE 1=1 AND State.FLD_state= " + lstAdHoc[0].Table_Name + "." + lstAdHoc[0].Field_Name;
                            objBusiness_Rules_Email_Fields.Email_Fields = "ISNULL((" + objBusiness_Rules_Email_Fields.Email_Fields + "),'')";
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (" + objBusiness_Rules_Email_Fields.Email_Fields + ")";
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "primary/physical state" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "building state"
                            || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "insured state" || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "payees state"
                            || Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "assessment state")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "SELECT ISNULL(FLD_state,'') FROM State WHERE 1=1 AND State.FLD_state= " + lstAdHoc[0].Table_Name + "." + lstAdHoc[0].Field_Name;
                            objBusiness_Rules_Email_Fields.Email_Fields = "ISNULL((" + objBusiness_Rules_Email_Fields.Email_Fields + "),'')";
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (" + objBusiness_Rules_Email_Fields.Email_Fields + ")";
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "deficiency noted")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "ISNULL((CASE Cast([Inspection_Responses].Deficiency_Noted as varchar(10)) WHEN 'Y' THEN 'Yes' ELSE 'No' END),'')";
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (" + objBusiness_Rules_Email_Fields.Email_Fields + ")";
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "inspection - deficiency")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "ISNULL((CASE Cast([SLT_Inspection_Responses].Deficiency_Noted as varchar(10)) WHEN 'Y' THEN 'Yes' ELSE 'No' END),'')";
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (" + objBusiness_Rules_Email_Fields.Email_Fields + ")";
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "inspection department")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "SELECT [dbo].[fn_GetDepartment] (" + lstAdHoc[0].Table_Name + "." + lstAdHoc[0].Field_Name+")";
                            objBusiness_Rules_Email_Fields.Email_Fields = "ISNULL((" + objBusiness_Rules_Email_Fields.Email_Fields + "),'')";
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (" + objBusiness_Rules_Email_Fields.Email_Fields + ")";
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "link to violation")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "SELECT Top 1 ISNULL(Cast(Description_Of_Violations as varchar(100)),'') FROM PM_Violation WHERE 1=1 AND PM_Violation.PK_PM_Violation= " + lstAdHoc[0].Table_Name + "." + lstAdHoc[0].Field_Name;
                            objBusiness_Rules_Email_Fields.Email_Fields = "ISNULL((" + objBusiness_Rules_Email_Fields.Email_Fields + "),'')";
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (" + objBusiness_Rules_Email_Fields.Email_Fields + ")";
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "building(s)")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "SELECT [dbo].[fn_EPM_GetBuildingNumbers] ([EPM_Identification].PK_EPM_Identification)";
                            objBusiness_Rules_Email_Fields.Email_Fields = "ISNULL((" + objBusiness_Rules_Email_Fields.Email_Fields + "),'')";
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (" + objBusiness_Rules_Email_Fields.Email_Fields + ")";
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "equipment")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "SELECT [dbo].[fn_EPM_GetEquipment] ([EPM_Identification].PK_EPM_Identification)";
                            objBusiness_Rules_Email_Fields.Email_Fields = "ISNULL((" + objBusiness_Rules_Email_Fields.Email_Fields + "),'')";
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (" + objBusiness_Rules_Email_Fields.Email_Fields + ")";
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "target area")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "SELECT [dbo].[fn_EPM_GetTargetArea] ([EPM_Identification].PK_EPM_Identification)";
                            objBusiness_Rules_Email_Fields.Email_Fields = "ISNULL((" + objBusiness_Rules_Email_Fields.Email_Fields + "),'')";
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (" + objBusiness_Rules_Email_Fields.Email_Fields + ")";
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "purpose of project")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "SELECT [dbo].[fn_EPM_GetPurposeofProject] ([EPM_Identification].PK_EPM_Identification)";
                            objBusiness_Rules_Email_Fields.Email_Fields = "ISNULL((" + objBusiness_Rules_Email_Fields.Email_Fields + "),'')";
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (" + objBusiness_Rules_Email_Fields.Email_Fields + ")";
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "existing documents")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "SELECT [dbo].[fn_EPM_GetExistingDocuments] ([EPM_Identification].PK_EPM_Identification)";
                            objBusiness_Rules_Email_Fields.Email_Fields = "ISNULL((" + objBusiness_Rules_Email_Fields.Email_Fields + "),'')";
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (" + objBusiness_Rules_Email_Fields.Email_Fields + ")";
                        }
                        else if (Convert.ToString(lstAdHoc[0].On_Screen_Descriptior).ToLower().Trim() == "e-mail recipients")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "SELECT [dbo].[fn_EPM_GetEmailRecipient] ([EPM_Identification].PK_EPM_Identification)";
                            objBusiness_Rules_Email_Fields.Email_Fields = "ISNULL((" + objBusiness_Rules_Email_Fields.Email_Fields + "),'')";
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (" + objBusiness_Rules_Email_Fields.Email_Fields + ")";
                        }
                        else
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (" + Business_RuleHelper.GetDropdwonFormail(lstAdHoc[0].Table_Name, lstAdHoc[0].Field_Name, GetMajorClaimCondition(Convert.ToDecimal(Fk_Field))) + ")";
                        break;
                    case 3:
                        objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + ISNULL(CONVERT(VARCHAR," + GetTableName(lstAdHoc[0].Table_Name) + "." + lstAdHoc[0].Field_Name + ",101),'')";
                        break;
                    case 4:
                        objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": $' + (ISNULL(CONVERT(VARCHAR,CONVERT(MONEY," + GetTableName(lstAdHoc[0].Table_Name) + "." + lstAdHoc[0].Field_Name + "),1),'')) ";
                        break;
                    case 5:
                        if (lstAdHoc[0].On_Screen_Descriptior == "Driver Age")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (ISNULL(CONVERT(VARCHAR,DATEDIFF(YEAR,[AL_FR].Driver_Date_of_Birth,GETDATE()),1),'')) ";
                        }
                        else if (lstAdHoc[0].On_Screen_Descriptior == "Age")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (ISNULL(CONVERT(VARCHAR,DATEDIFF(YEAR,[AssocEmployee].Date_Of_Birth,GETDATE()),1),'')) ";
                        }
                        else if (lstAdHoc[0].On_Screen_Descriptior == "Passenger Age")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (ISNULL(CONVERT(VARCHAR,DATEDIFF(YEAR,[AL_FR].Passenger_Date_of_Birth,GETDATE()),1),'')) ";
                        }
                        else if (lstAdHoc[0].On_Screen_Descriptior == "Other Driver Age")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (ISNULL(CONVERT(VARCHAR,DATEDIFF(YEAR,[AL_FR].Other_Driver_Date_of_Birth,GETDATE()),1),'')) ";
                        }
                        else if (lstAdHoc[0].On_Screen_Descriptior == "Other Vehicle Passenger Age")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (ISNULL(CONVERT(VARCHAR,DATEDIFF(YEAR,[AL_FR].Oth_Veh_Pass_Date_of_Birth,GETDATE()),1),'')) ";
                        }
                        else if (lstAdHoc[0].On_Screen_Descriptior == "Pedestrain Age")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (ISNULL(CONVERT(VARCHAR,DATEDIFF(YEAR,[AL_FR].Pedestrian_Date_of_Birth,GETDATE()),1),'')) ";
                        }
                        else if (lstAdHoc[0].On_Screen_Descriptior == "Drivers Age")
                        {
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (ISNULL(CONVERT(VARCHAR,DATEDIFF(YEAR,[Auto_Loss_Claims].Driver_Date_of_Birth,GETDATE()),1),'')) ";
                        }
                        else
                            objBusiness_Rules_Email_Fields.Email_Fields = "'" + lstAdHoc[0].On_Screen_Descriptior + ": ' + (ISNULL(CONVERT(VARCHAR," + GetTableName(lstAdHoc[0].Table_Name) + "." + lstAdHoc[0].Field_Name + ",1),'')) ";
                        break;
                    default:
                        break;
                }
                objBusiness_Rules_Email_Fields.FK_Business_Rules_Fields = Fk_Field;
                objBusiness_Rules_Email_Fields.FK_Business_Rules = FK_Rule;
                objBusiness_Rules_Email_Fields.Insert();
            }
        }
    }

    /// <summary>
    /// Saves the evaluation criteria for the rule
    /// </summary>
    /// <param name="PK_ID"></param>
    private void SaveRuleFilter(decimal PK_ID)
    {
        decimal decValue;

        List<string> UpdateValues = new List<string>();
        if (drpFilter_Action.SelectedIndex > 0)
        {
            UpdateValues = SaveActionFilterCriteria();
        }
        clsBusiness_Rule_Filter.DeleteByFK(PK_ID);
        if (drpFilter1.SelectedIndex > 0)
        {
            decValue = Convert.ToDecimal(drpFilter1.SelectedItem.Value);

            clsBusiness_Rule_Filter objBusiness_Rule_Filter = new clsBusiness_Rule_Filter();
            objBusiness_Rule_Filter.FK_Business_Rules_Fields = decValue;
            objBusiness_Rule_Filter.FK_Business_Rules = PK_ID;
            objBusiness_Rule_Filter.IsNotSelected = chkNotCriteria1.Checked;
            clsBusiness_Rules_Fields objBusiness_Rules_Fields = new clsBusiness_Rules_Fields(decValue);

            switch (objBusiness_Rules_Fields.Field_Type)
            {
                case 1:
                    objBusiness_Rule_Filter.ConditionType = drpText_F1.SelectedValue;
                    objBusiness_Rule_Filter.ConditionValue = txtFilter1.Text.Trim();
                    break;
                case 2:
                    objBusiness_Rule_Filter.ConditionType = "";
                    if (drpFilter1.SelectedItem.Text == "Payee")
                        objBusiness_Rule_Filter.ConditionValue = GetSelectedItemString(lst_F1, true);
                    else
                        objBusiness_Rule_Filter.ConditionValue = GetSelectedItemString(lst_F1, false);
                    break;
                case 3:
                    objBusiness_Rule_Filter.ConditionType = lstDate1.SelectedValue;
                    if (ucRelativeDatesFrom_1.RelativeDate == Business_RuleHelper.RaltiveDates.NotSet)
                        objBusiness_Rule_Filter.FromDate = clsGeneral.FormatNullDateToStore(txtDate_From1.Text.Trim());
                    else
                        objBusiness_Rule_Filter.FromRelativeCriteria = Convert.ToString((int)ucRelativeDatesFrom_1.RelativeDate);
                    if (lstDate1.SelectedValue == "B")
                    {
                        if (ucRelativeDatesTo_1.RelativeDate == Business_RuleHelper.RaltiveDates.NotSet)
                            objBusiness_Rule_Filter.ToDate = clsGeneral.FormatNullDateToStore(txtDate_To1.Text.Trim());
                        else
                            objBusiness_Rule_Filter.ToRelativeCriteria = Convert.ToString((int)ucRelativeDatesTo_1.RelativeDate);

                    }
                    break;
                case 4:
                    objBusiness_Rule_Filter.ConditionType = drpAmount_F1.SelectedValue;
                    if (txtAmount1_F1.Text.Trim() != string.Empty)
                        objBusiness_Rule_Filter.AmountFrom = Convert.ToDecimal(txtAmount1_F1.Text.Trim().Replace(",", ""));
                    if (txtAmount2_F1.Text.Trim() != string.Empty && drpAmount_F1.SelectedValue == Convert.ToString(((int)Business_RuleHelper.AmountCriteria.Between)))
                        objBusiness_Rule_Filter.AmountTo = Convert.ToDecimal(txtAmount2_F1.Text.Trim().Replace(",", ""));
                    break;
                case 5:
                    objBusiness_Rule_Filter.ConditionType = drpNumber_F1.SelectedValue;
                    if (txtNumber1_F1.Text.Trim() != string.Empty)
                        objBusiness_Rule_Filter.AmountFrom = Convert.ToDecimal(txtNumber1_F1.Text.Trim().Replace(",", ""));
                    if (txtNumber2_F1.Text.Trim() != string.Empty && drpNumber_F1.SelectedValue == Convert.ToString(((int)Business_RuleHelper.NumberCriteria.Between)))
                        objBusiness_Rule_Filter.AmountTo = Convert.ToDecimal(txtNumber2_F1.Text.Trim().Replace(",", ""));
                    break;
                default:
                    break;
            }
            objBusiness_Rule_Filter.Insert();
        }

        if (drpFilter2.SelectedIndex > 0)
        {
            decValue = Convert.ToDecimal(drpFilter2.SelectedItem.Value);

            clsBusiness_Rule_Filter objBusiness_Rule_Filter = new clsBusiness_Rule_Filter();
            objBusiness_Rule_Filter.FK_Business_Rules_Fields = decValue;
            objBusiness_Rule_Filter.FK_Business_Rules = PK_ID;
            objBusiness_Rule_Filter.IsNotSelected = chkNotCriteria2.Checked;
            clsBusiness_Rules_Fields objBusiness_Rules_Fields = new clsBusiness_Rules_Fields(decValue);

            switch (objBusiness_Rules_Fields.Field_Type)
            {
                case 1:
                    objBusiness_Rule_Filter.ConditionType = drpText_F2.SelectedValue;
                    objBusiness_Rule_Filter.ConditionValue = txtFilter2.Text.Trim();
                    break;
                case 2:
                    objBusiness_Rule_Filter.ConditionType = "";
                    if (drpFilter2.SelectedItem.Text == "Payee")
                        objBusiness_Rule_Filter.ConditionValue = GetSelectedItemString(lst_F2, true);
                    else
                        objBusiness_Rule_Filter.ConditionValue = GetSelectedItemString(lst_F2, false);
                    break;
                case 3:
                    objBusiness_Rule_Filter.ConditionType = lstDate2.SelectedValue;
                    if (ucRelativeDatesFrom_2.RelativeDate == Business_RuleHelper.RaltiveDates.NotSet)
                        objBusiness_Rule_Filter.FromDate = clsGeneral.FormatNullDateToStore(txtDate_From2.Text.Trim());
                    else
                        objBusiness_Rule_Filter.FromRelativeCriteria = Convert.ToString((int)ucRelativeDatesFrom_2.RelativeDate);
                    if (lstDate2.SelectedValue == "B")
                    {
                        if (ucRelativeDatesTo_2.RelativeDate == Business_RuleHelper.RaltiveDates.NotSet)
                            objBusiness_Rule_Filter.ToDate = clsGeneral.FormatNullDateToStore(txtDateTo2.Text.Trim());
                        else
                            objBusiness_Rule_Filter.ToRelativeCriteria = Convert.ToString((int)ucRelativeDatesTo_2.RelativeDate);

                    }
                    break;
                case 4:
                    objBusiness_Rule_Filter.ConditionType = drpAmount_F2.SelectedValue;
                    if (txtAmount1_F2.Text.Trim() != string.Empty)
                        objBusiness_Rule_Filter.AmountFrom = Convert.ToDecimal(txtAmount1_F2.Text.Trim().Replace(",", ""));
                    if (txtAmount2_F2.Text.Trim() != string.Empty && drpAmount_F2.SelectedValue == Convert.ToString(((int)Business_RuleHelper.AmountCriteria.Between)))
                        objBusiness_Rule_Filter.AmountTo = Convert.ToDecimal(txtAmount2_F2.Text.Trim().Replace(",", ""));
                    break;
                case 5:
                    objBusiness_Rule_Filter.ConditionType = drpNumber_F2.SelectedValue;
                    if (txtNumber1_F2.Text.Trim() != string.Empty)
                        objBusiness_Rule_Filter.AmountFrom = Convert.ToDecimal(txtNumber1_F2.Text.Trim().Replace(",", ""));
                    if (txtNumber2_F2.Text.Trim() != string.Empty && drpNumber_F2.SelectedValue == Convert.ToString(((int)Business_RuleHelper.NumberCriteria.Between)))
                        objBusiness_Rule_Filter.AmountTo = Convert.ToDecimal(txtNumber2_F2.Text.Trim().Replace(",", ""));
                    break;
                default:
                    break;
            }
            objBusiness_Rule_Filter.Insert();
        }

        if (drpFilter3.SelectedIndex > 0)
        {
            decValue = Convert.ToDecimal(drpFilter3.SelectedItem.Value);
            clsBusiness_Rule_Filter objBusiness_Rule_Filter = new clsBusiness_Rule_Filter();
            objBusiness_Rule_Filter.FK_Business_Rules_Fields = decValue;
            objBusiness_Rule_Filter.FK_Business_Rules = PK_ID;
            objBusiness_Rule_Filter.IsNotSelected = chkNotCriteria3.Checked;
            clsBusiness_Rules_Fields objBusiness_Rules_Fields = new clsBusiness_Rules_Fields(decValue);

            switch (objBusiness_Rules_Fields.Field_Type)
            {
                case 1:
                    objBusiness_Rule_Filter.ConditionType = drpText_F3.SelectedValue;
                    objBusiness_Rule_Filter.ConditionValue = txtFilter3.Text.Trim();
                    break;
                case 2:
                    objBusiness_Rule_Filter.ConditionType = "";
                    if (drpFilter3.SelectedItem.Text == "Payee")
                        objBusiness_Rule_Filter.ConditionValue = GetSelectedItemString(lst_F3, true);
                    else
                        objBusiness_Rule_Filter.ConditionValue = GetSelectedItemString(lst_F3, false);
                    break;
                case 3:
                    objBusiness_Rule_Filter.ConditionType = lstDate3.SelectedValue;
                    if (ucRelativeDatesFrom_3.RelativeDate == Business_RuleHelper.RaltiveDates.NotSet)
                        objBusiness_Rule_Filter.FromDate = clsGeneral.FormatNullDateToStore(txtDate_From3.Text.Trim());
                    else
                        objBusiness_Rule_Filter.FromRelativeCriteria = Convert.ToString((int)ucRelativeDatesFrom_3.RelativeDate);
                    if (lstDate2.SelectedValue == "B")
                    {
                        if (ucRelativeDatesTo_3.RelativeDate == Business_RuleHelper.RaltiveDates.NotSet)
                            objBusiness_Rule_Filter.ToDate = clsGeneral.FormatNullDateToStore(txtDate_To3.Text.Trim());
                        else
                            objBusiness_Rule_Filter.ToRelativeCriteria = Convert.ToString((int)ucRelativeDatesTo_3.RelativeDate);

                    }
                    break;
                case 4:
                    objBusiness_Rule_Filter.ConditionType = drpAmount_F3.SelectedValue;
                    if (txtAmount1_F3.Text.Trim() != string.Empty)
                        objBusiness_Rule_Filter.AmountFrom = Convert.ToDecimal(txtAmount1_F3.Text.Trim().Replace(",", ""));
                    if (txtAmount2_F3.Text.Trim() != string.Empty && drpAmount_F3.SelectedValue == Convert.ToString(((int)Business_RuleHelper.AmountCriteria.Between)))
                        objBusiness_Rule_Filter.AmountTo = Convert.ToDecimal(txtAmount2_F3.Text.Trim().Replace(",", ""));
                    break;
                case 5:
                    objBusiness_Rule_Filter.ConditionType = drpNumber_F3.SelectedValue;
                    if (txtNumber1_F3.Text.Trim() != string.Empty)
                        objBusiness_Rule_Filter.AmountFrom = Convert.ToDecimal(txtNumber1_F3.Text.Trim().Replace(",", ""));
                    if (txtNumber2_F3.Text.Trim() != string.Empty && drpNumber_F3.SelectedValue == Convert.ToString(((int)Business_RuleHelper.NumberCriteria.Between)))
                        objBusiness_Rule_Filter.AmountTo = Convert.ToDecimal(txtNumber2_F3.Text.Trim().Replace(",", ""));
                    break;
                default:
                    break;
            }
            objBusiness_Rule_Filter.Insert();
        }

        if (drpFilter4.SelectedIndex > 0)
        {
            decValue = Convert.ToDecimal(drpFilter4.SelectedItem.Value);
            clsBusiness_Rule_Filter objBusiness_Rule_Filter = new clsBusiness_Rule_Filter();
            objBusiness_Rule_Filter.FK_Business_Rules_Fields = decValue;
            objBusiness_Rule_Filter.FK_Business_Rules = PK_ID;
            objBusiness_Rule_Filter.IsNotSelected = chkNotCriteria4.Checked;
            clsBusiness_Rules_Fields objBusiness_Rules_Fields = new clsBusiness_Rules_Fields(decValue);

            switch (objBusiness_Rules_Fields.Field_Type)
            {
                case 1:
                    objBusiness_Rule_Filter.ConditionType = drpText_F4.SelectedValue;
                    objBusiness_Rule_Filter.ConditionValue = txtFilter4.Text.Trim();
                    break;
                case 2:
                    objBusiness_Rule_Filter.ConditionType = "";
                    if (drpFilter4.SelectedItem.Text == "Payee")
                        objBusiness_Rule_Filter.ConditionValue = GetSelectedItemString(lst_F4, true);
                    else
                        objBusiness_Rule_Filter.ConditionValue = GetSelectedItemString(lst_F4, false);
                    break;
                case 3:
                    objBusiness_Rule_Filter.ConditionType = lstDate4.SelectedValue;
                    if (ucRelativeDatesFrom_4.RelativeDate == Business_RuleHelper.RaltiveDates.NotSet)
                        objBusiness_Rule_Filter.FromDate = clsGeneral.FormatNullDateToStore(txtDate_From4.Text.Trim());
                    else
                        objBusiness_Rule_Filter.FromRelativeCriteria = Convert.ToString((int)ucRelativeDatesFrom_4.RelativeDate);
                    if (lstDate2.SelectedValue == "B")
                    {
                        if (ucRelativeDatesTo_4.RelativeDate == Business_RuleHelper.RaltiveDates.NotSet)
                            objBusiness_Rule_Filter.ToDate = clsGeneral.FormatNullDateToStore(txtDate_To4.Text.Trim());
                        else
                            objBusiness_Rule_Filter.ToRelativeCriteria = Convert.ToString((int)ucRelativeDatesTo_4.RelativeDate);

                    }
                    break;
                case 4:
                    objBusiness_Rule_Filter.ConditionType = drpAmount_F4.SelectedValue;
                    if (txtAmount1_F4.Text.Trim() != string.Empty)
                        objBusiness_Rule_Filter.AmountFrom = Convert.ToDecimal(txtAmount1_F4.Text.Trim().Replace(",", ""));
                    if (txtAmount2_F4.Text.Trim() != string.Empty && drpAmount_F4.SelectedValue == Convert.ToString(((int)Business_RuleHelper.AmountCriteria.Between)))
                        objBusiness_Rule_Filter.AmountTo = Convert.ToDecimal(txtAmount2_F4.Text.Trim().Replace(",", ""));
                    break;
                case 5:
                    objBusiness_Rule_Filter.ConditionType = drpNumber_F4.SelectedValue;
                    if (txtNumber1_F4.Text.Trim() != string.Empty)
                        objBusiness_Rule_Filter.AmountFrom = Convert.ToDecimal(txtNumber1_F4.Text.Trim().Replace(",", ""));
                    if (txtNumber2_F4.Text.Trim() != string.Empty && drpNumber_F4.SelectedValue == Convert.ToString(((int)Business_RuleHelper.NumberCriteria.Between)))
                        objBusiness_Rule_Filter.AmountTo = Convert.ToDecimal(txtNumber2_F4.Text.Trim().Replace(",", ""));
                    break;
                default:
                    break;
            }
            objBusiness_Rule_Filter.Insert();
        }

        if (drpFilter5.SelectedIndex > 0)
        {
            decValue = Convert.ToDecimal(drpFilter5.SelectedItem.Value);
            clsBusiness_Rule_Filter objBusiness_Rule_Filter = new clsBusiness_Rule_Filter();
            objBusiness_Rule_Filter.FK_Business_Rules_Fields = decValue;
            objBusiness_Rule_Filter.FK_Business_Rules = PK_ID;
            objBusiness_Rule_Filter.IsNotSelected = chkNotCriteria5.Checked;
            clsBusiness_Rules_Fields objBusiness_Rules_Fields = new clsBusiness_Rules_Fields(decValue);

            switch (objBusiness_Rules_Fields.Field_Type)
            {
                case 1:
                    objBusiness_Rule_Filter.ConditionType = drpText_F5.SelectedValue;
                    objBusiness_Rule_Filter.ConditionValue = txtFilter5.Text.Trim();
                    break;
                case 2:
                    objBusiness_Rule_Filter.ConditionType = "";
                    if (drpFilter5.SelectedItem.Text == "Payee")
                        objBusiness_Rule_Filter.ConditionValue = GetSelectedItemString(lst_F5, true);
                    else
                        objBusiness_Rule_Filter.ConditionValue = GetSelectedItemString(lst_F5, false);
                    break;
                case 3:
                    objBusiness_Rule_Filter.ConditionType = lstDate5.SelectedValue;
                    if (ucRelativeDatesFrom_5.RelativeDate == Business_RuleHelper.RaltiveDates.NotSet)
                        objBusiness_Rule_Filter.FromDate = clsGeneral.FormatNullDateToStore(txtDate_From5.Text.Trim());
                    else
                        objBusiness_Rule_Filter.FromRelativeCriteria = Convert.ToString((int)ucRelativeDatesFrom_5.RelativeDate);
                    if (lstDate2.SelectedValue == "B")
                    {
                        if (ucRelativeDatesTo_5.RelativeDate == Business_RuleHelper.RaltiveDates.NotSet)
                            objBusiness_Rule_Filter.ToDate = clsGeneral.FormatNullDateToStore(txtDate_To5.Text.Trim());
                        else
                            objBusiness_Rule_Filter.ToRelativeCriteria = Convert.ToString((int)ucRelativeDatesTo_5.RelativeDate);

                    }
                    break;
                case 4:
                    objBusiness_Rule_Filter.ConditionType = drpAmount_F5.SelectedValue;
                    if (txtAmount1_F5.Text.Trim() != string.Empty)
                        objBusiness_Rule_Filter.AmountFrom = Convert.ToDecimal(txtAmount1_F5.Text.Trim().Replace(",", ""));
                    if (txtAmount2_F5.Text.Trim() != string.Empty && drpAmount_F5.SelectedValue == Convert.ToString(((int)Business_RuleHelper.AmountCriteria.Between)))
                        objBusiness_Rule_Filter.AmountTo = Convert.ToDecimal(txtAmount2_F5.Text.Trim().Replace(",", ""));
                    break;
                case 5:
                    objBusiness_Rule_Filter.ConditionType = drpNumber_F5.SelectedValue;
                    if (txtNumber1_F5.Text.Trim() != string.Empty)
                        objBusiness_Rule_Filter.AmountFrom = Convert.ToDecimal(txtNumber1_F5.Text.Trim().Replace(",", ""));
                    if (txtNumber2_F5.Text.Trim() != string.Empty && drpNumber_F5.SelectedValue == Convert.ToString(((int)Business_RuleHelper.NumberCriteria.Between)))
                        objBusiness_Rule_Filter.AmountTo = Convert.ToDecimal(txtNumber2_F5.Text.Trim().Replace(",", ""));
                    break;
                default:
                    break;
            }
            objBusiness_Rule_Filter.Insert();
        }
    }

    /// <summary>
    /// save individual filter criteria for Saved rule
    /// </summary>
    public List<string> SaveActionFilterCriteria()
    {
        decimal Fk_Rule = Convert.ToDecimal(drpFilter_Action.SelectedValue);
        List<ERIMS.DAL.clsBusiness_Rules_Fields> lstAdHoc;
        lstAdHoc = new ERIMS.DAL.clsBusiness_Rules_Fields().SelectByPK(Fk_Rule);
        decimal Fk_ControlType = lstAdHoc[0].Field_Type.Value;
        string Field_Name = lstAdHoc[0].Field_Name.Trim();
        string Table_Name = GetTableName(lstAdHoc[0].Table_Name.Trim());
        string NewValue = string.Empty;
        List<string> arrStrReturn = new List<string>();
        if (drpDirectDerived.SelectedValue == "True")
        {

            ///Relative Date
            if (Fk_ControlType == (int)Business_RuleHelper.ControlType.TextBox)
            {
                NewValue = txtFilter_Action.Text.Trim();
            }
            else if (Fk_ControlType == (int)Business_RuleHelper.ControlType.MultiSelectList)
            {
                //int intVal = 0;
                //int.TryParse(lst_F_Action.SelectedValue, out intVal);
                //if(intVal > 0)
                    NewValue = lst_F_Action.SelectedValue;
                //else
                //    NewValue = "'" + lst_F_Action.SelectedValue + "'";
                    
            }
            else if (Fk_ControlType == (int)Business_RuleHelper.ControlType.DateControl)
            {
                NewValue = txtDate_From_Action.Text.Trim();
            }

            else if (Fk_ControlType == (int)Business_RuleHelper.ControlType.AmountControl)
            {
                NewValue = txtAmount1_F_Action.Text.Trim().Replace(",", "");
            }
            else if (Fk_ControlType == (int)Business_RuleHelper.ControlType.IntNumberControl)
            {
                NewValue = txtNumber1_F_Action.Text.Trim().Replace(",", "");
            }
            arrStrReturn.Add(Field_Name);
            arrStrReturn.Add(NewValue);
            arrStrReturn.Add(Table_Name);
            arrStrReturn.Add(Convert.ToString(Fk_ControlType));
        }
        else
        {
            int DerivedControlType = 0;
            List<ERIMS.DAL.clsBusiness_Rules_Fields> lstAdHocDerived = null;
            lstAdHocDerived = new ERIMS.DAL.clsBusiness_Rules_Fields().SelectByPK(Convert.ToDecimal(drpFilter_Derived.SelectedValue));
            DerivedControlType = Convert.ToInt16(lstAdHocDerived[0].Field_Type);
            if (DerivedControlType == (int)Business_RuleHelper.ControlType.MultiSelectList)
            {
                NewValue = lst_F_Action.SelectedValue;
            }
            else if (DerivedControlType == (int)Business_RuleHelper.ControlType.TextBox)
            {
                //NewValue = lstAdHocDerived[0].Table_Name + "." + lstAdHocDerived[0].Field_Name + " " + drpDerived_Add.SelectedValue + " '" + txtText_Derived.Text.Trim() + "'";
                NewValue =  lstAdHocDerived[0].Field_Name + " " + drpDerived_Add.SelectedValue + " '" + txtText_Derived.Text.Trim() + "'";
            }
            else
            {
                //NewValue = lstAdHocDerived[0].Table_Name + "." + lstAdHocDerived[0].Field_Name + " " + drpDerived_Add.SelectedValue + " " + txtNumber_Derived.Text.Trim();
                NewValue = lstAdHocDerived[0].Field_Name + " " + drpDerived_Add.SelectedValue + " " + txtNumber_Derived.Text.Trim();
            }
            arrStrReturn.Add(Field_Name);
            arrStrReturn.Add(NewValue);
            arrStrReturn.Add(Table_Name);
            arrStrReturn.Add(Convert.ToString(DerivedControlType));
        }
        return arrStrReturn;
    }

    /// <summary>
    /// save individual filter criteria for Saved rule
    /// </summary>
    public string SaveFilterCriteriadb(decimal Fk_Rule, string lstText, string TextWhere, string ListFilterWhere, string lstDate,
                                    string Date_From, string Date_To, string lstAmount, string Amount1, string Amount2, string lstNumber, string Number1, string Number2,
                                    Business_RuleHelper.RaltiveDates relativeFrom, Business_RuleHelper.RaltiveDates relativeTo, bool chkNotSelected)
    {
        List<ERIMS.DAL.clsBusiness_Rules_Fields> lstAdHoc;
        lstAdHoc = new ERIMS.DAL.clsBusiness_Rules_Fields().SelectByPK(Fk_Rule);
        decimal Fk_ControlType = lstAdHoc[0].Field_Type.Value;
        string Field_Name = lstAdHoc[0].Field_Name.Trim();
        string Table_Name = lstAdHoc[0].Table_Name.Trim();

        StringBuilder strCondition = new StringBuilder();
        ///Relative Date
        if (Fk_ControlType == (int)Business_RuleHelper.ControlType.TextBox)
        {
            if (Field_Name == "FK_Pay_To_The_Order")
            {
                strCondition.Append("AND ([Trans_Payee].[Company] ");
            }
            else
            {
                strCondition.Append("AND " + GetTableName(Table_Name) + "." + Field_Name + " ");
            }
            string TempCondition = string.Empty;
            switch (lstText)
            {
                case "1":
                    TempCondition = "'%" + TextWhere.Trim().Replace("'", "''") + "%'";
                    break;
                case "2":
                    TempCondition = "'" + TextWhere.Trim().Replace("'", "''") + "%'";
                    break;
                case "3":
                    TempCondition = "'%" + TextWhere.Trim().Replace("'", "''") + "'";
                    break;
                default: break;
            }
            if (chkNotSelected)
                strCondition.Append("NOT ");

            strCondition.Append("LIKE " + TempCondition);
            if (Field_Name == "FK_Pay_To_The_Order")
            {
                strCondition.Append(" OR RTRIM(LTRIM((ISNULL([Trans_Payee].First_Name + ' ','') + ISNULL([Trans_Payee].Middle_Name + ' ', '') + ISNULL([Trans_Payee].Last_Name,'')))) like ");
                strCondition.Append(TempCondition + ")");
            }
        }
        else if (Fk_ControlType == (int)Business_RuleHelper.ControlType.MultiSelectList)
        {
            string[] arrwhere = ListFilterWhere.Split(',');
            string strWhere = string.Empty;
            string lstCondition = string.Empty;
            string strNewList = string.Empty;

            foreach (string lst in arrwhere)
                lstCondition = lstCondition + lst + ",";
            lstCondition = lstCondition.TrimEnd(',');

            if (!string.IsNullOrEmpty(Field_Name) && Field_Name == "[Policy].Policy_Type" && !string.IsNullOrEmpty(lstCondition))
            {
                for (int intI = 0; intI < arrwhere.Length; intI++)
                {
                    strNewList += "'" + arrwhere[intI] + "',";
                }
                if (chkNotSelected == true)
                    strWhere = " And " + GetTableName(Table_Name) + "." + Field_Name + " NOT IN (" + strNewList.TrimEnd(',') + ") ";
                else
                    strWhere = " And " + GetTableName(Table_Name) + "." + Field_Name + " IN (" + strNewList.TrimEnd(',') + ") ";
            }
            else if (!string.IsNullOrEmpty(Field_Name) && (Table_Name + '.' + Field_Name == "[Inspection_Responses].Department" || Table_Name + '.' + Field_Name == "[SLT_Inspection_Responses].Department") && !string.IsNullOrEmpty(lstCondition))
            {
                for (int intI = 0; intI < arrwhere.Length; intI++)
                {
                    strNewList +=  arrwhere[intI] + ",";
                }
                if (chkNotSelected == true)
                    //strWhere = " And (Select Top 1 item from CommaSeparatedListToTable(" + GetTableName(Table_Name) + "." + Field_Name + ")) NOT IN (Select item from CommaSeparatedListToTable('" + strNewList.TrimEnd(',') + "')) ";
                    strWhere = " And (Select Count(1) from CommaSeparatedListToTable(" + GetTableName(Table_Name) + "." + Field_Name + ")  A Inner join (Select item from CommaSeparatedListToTable('" + strNewList.TrimEnd(',') + "')) B on B.item = A.item ) > 0 ";
                else
                    //strWhere = " And (Select Top 1 item from CommaSeparatedListToTable(" + GetTableName(Table_Name) + "." + Field_Name + ")) IN (Select item from CommaSeparatedListToTable('" + strNewList.TrimEnd(',') + "')) ";
                    strWhere = " And (Select Count(1) from CommaSeparatedListToTable(" + GetTableName(Table_Name) + "." + Field_Name + ")  A Inner join (Select item from CommaSeparatedListToTable('" + strNewList.TrimEnd(',') + "')) B on B.item = A.item ) > 0 ";
            }
            else if (!string.IsNullOrEmpty(Field_Name) && !string.IsNullOrEmpty(lstCondition))
            {
                
                if (chkNotSelected == true)
                {
                    strWhere = " And " + GetTableName(Table_Name) + "." + Field_Name + " NOT IN (" + lstCondition + ") ";
                }
                else
                {
                    if (CheckdropdownType(Table_Name+"."+Field_Name) == "YesNoUnknown")
                        strWhere = " And ISNULL(Cast(" + GetTableName(Table_Name) + "." + Field_Name + " as int),-1) IN (" + lstCondition + ") ";
                    else if (Field_Name == "Deficiency_Noted")
                        strWhere = " And ISNULL(Cast(" + GetTableName(Table_Name) + "." + Field_Name + " as varchar(10)),'') IN (" + lstCondition + ") ";
                    else
                        strWhere = " And " + GetTableName(Table_Name) + "." + Field_Name + " IN (" + lstCondition + ") ";
                }
            }

            strCondition.Append(strWhere);
        }

        else if (Fk_ControlType == (int)Business_RuleHelper.ControlType.DateControl)
        {
            string strWhere = string.Empty;

            DateTime? dtFrom = null, dtTo = null;

            string cblDateCriteria = lstDate;
            dtFrom = clsGeneral.FormatNullDateToStore(Date_From);

            dtTo = clsGeneral.FormatNullDateToStore(Date_To);

            Business_RuleHelper.DateCriteria DtType = Business_RuleHelper.DateCriteria.On;

            if (cblDateCriteria == "O")
                DtType = Business_RuleHelper.DateCriteria.On;
            else if (cblDateCriteria == "BF")
                DtType = Business_RuleHelper.DateCriteria.Before;
            else if (cblDateCriteria == "A")
                DtType = Business_RuleHelper.DateCriteria.After;
            else if (cblDateCriteria == "B")
                DtType = Business_RuleHelper.DateCriteria.Between;

            if (dtFrom.HasValue)
                strWhere = Business_RuleHelper.GetDateWhereAbsolute((GetTableName(Table_Name) + "." + Field_Name), dtFrom, dtTo, DtType, chkNotSelected);

            else if (dtTo.HasValue)
                strWhere = Business_RuleHelper.GetDateWhereAbsolute((GetTableName(Table_Name) + "." + Field_Name), dtFrom, dtTo, DtType, chkNotSelected);

            strCondition.Append(strWhere);
        }

        else if (Fk_ControlType == (int)Business_RuleHelper.ControlType.AmountControl)
        {
            string strWhere = string.Empty;
            Business_RuleHelper.AmountCriteria AmtType = Business_RuleHelper.AmountCriteria.Equal;

            decimal? dFrom = null;
            decimal? dTo = null;

            if (!string.IsNullOrEmpty(Amount1))
                dFrom = Convert.ToDecimal(Amount1);

            if (!string.IsNullOrEmpty(Amount2))
                dTo = Convert.ToDecimal(Amount2);

            if (Convert.ToInt16(lstAmount) == (int)Business_RuleHelper.AmountCriteria.Equal)
                AmtType = Business_RuleHelper.AmountCriteria.Equal;
            else if (Convert.ToInt16(lstAmount) == (int)Business_RuleHelper.AmountCriteria.GreaterThan)
                AmtType = Business_RuleHelper.AmountCriteria.GreaterThan;
            else if (Convert.ToInt16(lstAmount) == (int)Business_RuleHelper.AmountCriteria.GreaterThanEqual)
                AmtType = Business_RuleHelper.AmountCriteria.GreaterThanEqual;
            else if (Convert.ToInt16(lstAmount) == (int)Business_RuleHelper.AmountCriteria.Between)
                AmtType = Business_RuleHelper.AmountCriteria.Between;
            else if (Convert.ToInt16(lstAmount) == (int)Business_RuleHelper.AmountCriteria.LessThan)
                AmtType = Business_RuleHelper.AmountCriteria.LessThan;
            else if (Convert.ToInt16(lstAmount) == (int)Business_RuleHelper.AmountCriteria.LessThanEqual)
                AmtType = Business_RuleHelper.AmountCriteria.LessThanEqual;

            if (dFrom.HasValue)
                strWhere = Business_RuleHelper.GetAmountWhere((GetTableName(Table_Name) + "." + Field_Name.Trim()), dFrom, dTo, AmtType, chkNotSelected);
            else if (dTo.HasValue)
                strWhere = Business_RuleHelper.GetAmountWhere((GetTableName(Table_Name) + "." + Field_Name.Trim()), dFrom, dTo, AmtType, chkNotSelected);
            strCondition.Append(strWhere);
        }
        else if (Fk_ControlType == (int)Business_RuleHelper.ControlType.IntNumberControl)
        {
            string strWhere = string.Empty;
            Business_RuleHelper.NumberCriteria NumType = Business_RuleHelper.NumberCriteria.Equal;

            decimal? dFrom = null;
            decimal? dTo = null;

            if (!string.IsNullOrEmpty(Number1))
                dFrom = Convert.ToDecimal(Number1);

            if (!string.IsNullOrEmpty(Number2))
                dTo = Convert.ToDecimal(Number2);

            if (Convert.ToInt16(lstNumber) == (int)Business_RuleHelper.NumberCriteria.Equal)
                NumType = Business_RuleHelper.NumberCriteria.Equal;
            else if (Convert.ToInt16(lstNumber) == (int)Business_RuleHelper.NumberCriteria.GreaterThan)
                NumType = Business_RuleHelper.NumberCriteria.GreaterThan;
            else if (Convert.ToInt16(lstNumber) == (int)Business_RuleHelper.NumberCriteria.GreaterThanEqual)
                NumType = Business_RuleHelper.NumberCriteria.GreaterThanEqual;
            else if (Convert.ToInt16(lstNumber) == (int)Business_RuleHelper.NumberCriteria.Between)
                NumType = Business_RuleHelper.NumberCriteria.Between;
            else if (Convert.ToInt16(lstNumber) == (int)Business_RuleHelper.NumberCriteria.LessThan)
                NumType = Business_RuleHelper.NumberCriteria.LessThan;
            else if (Convert.ToInt16(lstNumber) == (int)Business_RuleHelper.NumberCriteria.LessThanEqual)
                NumType = Business_RuleHelper.NumberCriteria.LessThanEqual;

            if (dFrom.HasValue)
                strWhere = Business_RuleHelper.GetNumberWhere((GetTableName(Table_Name) + "." + Field_Name.Trim()), dFrom, dTo, NumType, chkNotSelected);
            else if (dTo.HasValue)
                strWhere = Business_RuleHelper.GetNumberWhere((GetTableName(Table_Name) + "." + Field_Name.Trim()), dFrom, dTo, NumType, chkNotSelected);
            strCondition.Append(strWhere);
        }
        return strCondition.ToString();
    }

    /// <summary>
    /// Set Selected Value for evaluation criteria
    /// </summary>
    /// <param name="objFilter"></param>
    /// <param name="drpFilter"></param>
    private void LoadFilterCriteria(ERIMS.DAL.clsBusiness_Rule_Filter objFilter, DropDownList drpFilter)
    {
        ListItem liSelected;

        // Check if Fk is not null
        if (objFilter.FK_Business_Rules_Fields.HasValue)
        {
            drpFilter.ClearSelection();
            // Find a value and then set it to selected
            liSelected = drpFilter.Items.FindByValue(objFilter.FK_Business_Rules_Fields.ToString());
            if (liSelected != null)
                liSelected.Selected = true;
        }
    }

    private void LoadCheckBoxNotCriteria(ERIMS.DAL.AdHocFilter objFilter, CheckBox chkNotSelectd)
    {
        //chkNotSelectd.Checked = objFilter.IsNotSelected;
    }


    /// <summary>
    /// Fill Drop Down based on selected Filter Criteria
    /// </summary>
    private void LoadFilterControlDropDown(string Field_Header, string ConditionValue, ListBox lst_F, string On_ScreenDescriptor)
    {
        lst_F.Items.Clear();
        //if (string.Compare(Field_Header, "Claim Adjuster", true) == 0 || string.Compare(Field_Header, "Entry Adjuster", true) == 0)
        //{
        //    //'C','A'
        //    string strAdjuster = string.Empty;
        //    if (rblCoverage.SelectedIndex == 0)
        //    {
        //        strAdjuster = "'A'";
        //    }
        //    if (rblCoverage.SelectedIndex == 1)
        //        strAdjuster += (strAdjuster == string.Empty) ? "'C'" : ",'C'";
        //    ComboHelper.FillAdjusterDropDown(new ListBox[] { lst_F }, strAdjuster, false);           
        //}
        //if (string.Compare(Field_Header, "Claim Adjuster", true) == 0)
        //{
        //    ComboHelper.FillClaimAdjusterDropDown(new ListBox[] { lst_F }, false);
        //}
        //else if (string.Compare(Field_Header, "Entry Adjuster", true) == 0)
        //{
        //    ComboHelper.FillAdjusterDropDown(new ListBox[] { lst_F }, false);
        //}
        //else if (string.Compare(Field_Header, "Cause", true) == 0)
        //    ComboHelper.FillCause(new ListBox[] { lst_F }, false, "");//GetSelectedCoverage());
        //else if (string.Compare(Field_Header, "Coverage", true) == 0)
        //    ComboHelper.FillCoverage(new ListBox[] { lst_F }, false, "");//GetSelectedCoverage());
        //else
        if (Convert.ToString(On_ScreenDescriptor).ToLower().Trim() == "focus area" || Convert.ToString(On_ScreenDescriptor).ToLower().Trim()  == "inspection - focus area")
        {
            ComboHelper.Fill_FocusAreaAdHoc(new ListBox[] { lst_F }, 0, false);
        }
        else if (Convert.ToString(On_ScreenDescriptor).ToLower().Trim() == "question text" || Convert.ToString(On_ScreenDescriptor).ToLower().Trim() == "inspection - question")
        {
            ComboHelper.Fill_QuestionTextAdHoc(new ListBox[] { lst_F }, 0, false);
        }
        else if (Convert.ToString(On_ScreenDescriptor).ToLower().Trim() == "location d/b/a" || Convert.ToString(On_ScreenDescriptor).ToLower().Trim() == "dealership/collision center"
                        || Convert.ToString(On_ScreenDescriptor).ToLower().Trim() == "dealership dba" || Convert.ToString(On_ScreenDescriptor).ToLower().Trim() == "sonic location d/b/a")
        {
            //ComboHelper.FillLocationDBA_AllCRMAdHoc(new ListBox[] { lst_F }, 0, false);
            ComboHelper.FillLocationDBA_All(new ListBox[] { lst_F }, 0, false);
        }
        else if (Convert.ToString(On_ScreenDescriptor).ToLower().Trim() == "legal entity" || Convert.ToString(On_ScreenDescriptor).ToLower().Trim() == "legal entity name")
        {
            //  ComboHelper.FillDistinctLocationLegal_EntityList(new ListBox[] { lst_F }, false);
            ComboHelper.FillDistinctLocationLegal_EntityByPK_Location(new ListBox[] { lst_F }, false);
        }
        else if (Convert.ToString(On_ScreenDescriptor).ToLower().Trim() == "location f/k/a")
        {
            ComboHelper.FillLocationfkaList(new ListBox[] { lst_F }, 0, false);
        }
        else if (Convert.ToString(On_ScreenDescriptor).ToLower().Trim() == "sonic location code" || Convert.ToString(On_ScreenDescriptor).ToLower().Trim() == "location number")
        {
            ComboHelper.FillSoincLocationCodeBusinessRule(new ListBox[] { lst_F }, false);
        }
        else if (Convert.ToString(On_ScreenDescriptor).ToLower().Trim() == "location rm number")
        {
            ComboHelper.FillSonicLocationNumberList(new ListBox[] { lst_F }, 0, false);
            lst_F.Style.Remove("font-size");
        }
        else if (Convert.ToString(On_ScreenDescriptor).ToLower().Trim() == "associate state")
        {
            ComboHelper.FillStateList(new ListBox[] { lst_F }, false);
        }
        else if (Convert.ToString(On_ScreenDescriptor).ToLower().Trim() == "primary/physical state" || Convert.ToString(On_ScreenDescriptor).ToLower().Trim() == "building state"
                || Convert.ToString(On_ScreenDescriptor).ToLower().Trim() == "insured state" || Convert.ToString(On_ScreenDescriptor).ToLower().Trim() == "payees state"
                || Convert.ToString(On_ScreenDescriptor).ToLower().Trim() == "assessment state")
        {
            ComboHelper.FillStateByDesc(new ListBox[] { lst_F }, false);
        }
        else if (Convert.ToString(On_ScreenDescriptor).ToLower().Trim() == "investigation status" || Convert.ToString(On_ScreenDescriptor).ToLower().Trim() == "investigations - status")
        {
            FillInvestigationList(new ListBox[] { lst_F }, false);
        }
        else if (Convert.ToString(On_ScreenDescriptor).ToLower().Trim() == "property contact type")
        {
            FillPropertyContactList(new ListBox[] { lst_F }, false);
        }
        else
            Business_RuleHelper.FillFilterDropDown(Field_Header, new ListBox[] { lst_F }, false, GetMajorClaimCondition(Convert.ToDecimal(drpModule.SelectedValue)));// GetSelectedCoverage());

        //Set ListBox ToolTip
        clsGeneral.SetListBoxToolTip(new ListBox[] { lst_F });
        // Set Selected Value for Filter Criteria
        SetSelectedValueFromString(ConditionValue, lst_F);
        lst_F.Visible = true;
    }

    /// <summary>
    /// Bind Textbox Control From Database
    /// </summary>
    /// <param name="ConditionType"></param>
    /// <param name="ConditionValue"></param>
    /// <param name="pnlText_F"></param>
    /// <param name="txtFilter"></param>
    /// <param name="drpText"></param>
    private void LoadFilterControlText(string ConditionType, string ConditionValue, Panel pnlText_F, TextBox txtFilter, DropDownList drpText)
    {
        ListItem liSelected;
        // Show Textbox panel
        pnlText_F.Visible = true;
        txtFilter.Text = ConditionValue;

        // find textbox Drop Down Value
        if (!string.IsNullOrEmpty(ConditionType))
        {
            drpText.ClearSelection();
            liSelected = drpText.Items.FindByValue(ConditionType);

            if (liSelected != null)
                liSelected.Selected = true;
        }
    }

    /// <summary>
    /// Bind Amount Fields from database
    /// </summary>
    private void LoadFilterControlAmount(ERIMS.DAL.clsBusiness_Rule_Filter objFilter, Panel pnlAmount_F, DropDownList drpAmount_F, TextBox txtAmount1_F, TextBox txtAmount2_F, Label lblAmountText1_F, Label lblAmountText2_F, CompareValidator cvAmount)
    {
        ListItem liSelected = drpAmount_F.Items.FindByValue(objFilter.ConditionType);
        // Show Amount Panel
        pnlAmount_F.Visible = true;
        if (liSelected != null)
        {
            drpAmount_F.ClearSelection();
            liSelected.Selected = true;
        }
        List<ERIMS.DAL.clsBusiness_Rules_Fields> lstAdHoc = null;
        lstAdHoc = new ERIMS.DAL.clsBusiness_Rules_Fields().SelectByPK(Convert.ToDecimal(objFilter.FK_Business_Rules_Fields));
        // Set Drop Down value and Text values
        drpAmount_Changed(true, lstAdHoc[0].IsDollar, drpAmount_F, lblAmountText1_F, txtAmount1_F, lblAmountText2_F, txtAmount2_F, cvAmount);
        txtAmount1_F.Text = string.Format("{0:N2}", objFilter.AmountFrom);
        txtAmount2_F.Text = string.Format("{0:N2}", objFilter.AmountTo);
    }

    /// <summary>
    /// Bind Number Fields from database
    /// </summary>
    private void LoadFilterControlNumber(ERIMS.DAL.clsBusiness_Rule_Filter objFilter, Panel pnlNumber_F, DropDownList drpNumber_F, TextBox txtNumber1_F, TextBox txtNumber2_F, Label lblNumberText1_F, Label lblNumberText2_F, CompareValidator cvNumber)
    {
        ListItem liSelected = drpNumber_F.Items.FindByValue(objFilter.ConditionType);
        // Show Number Panel
        pnlNumber_F.Visible = true;
        if (liSelected != null)
        {
            drpNumber_F.ClearSelection();
            liSelected.Selected = true;
        }
        List<ERIMS.DAL.clsBusiness_Rules_Fields> lstAdHoc = null;
        lstAdHoc = new ERIMS.DAL.clsBusiness_Rules_Fields().SelectByPK(Convert.ToDecimal(objFilter.FK_Business_Rules_Fields));
        // Set Drop Down value and Text values
        drpNumber_Changed(drpNumber_F, lblNumberText1_F, txtNumber1_F, lblNumberText2_F, txtNumber2_F, cvNumber);
        txtNumber1_F.Text = string.Format("{0:N0}", objFilter.AmountFrom);
        txtNumber2_F.Text = string.Format("{0:N0}", objFilter.AmountTo);
    }

    /// <summary>
    /// Bind Date Filter Criteria from database
    /// </summary>
    private void LoadFilterControlDate(ERIMS.DAL.clsBusiness_Rule_Filter objFilter, Panel pnlDate_F, DropDownList rdbCommon, Label lbl1, Label lbl2, TextBox txt1, TextBox txt2, HtmlImage img2, RegularExpressionValidator revDateTo, ASP.controls_relativedate_relativedate_business_rule_ascx ucRelativeDatesFrom, ASP.controls_relativedate_relativedate_business_rule_ascx ucRelativeDatesTo, HtmlImage img1)
    {

        ListItem liSelected = rdbCommon.Items.FindByValue(objFilter.ConditionType);
        // Show date Criteria
        pnlDate_F.Visible = true;

        if (liSelected != null)
        {
            rdbCommon.ClearSelection();
            liSelected.Selected = true;
            rdbLstDate_SelectedIndexChanged(rdbCommon, null);//Set Date Selected Dropdown
        }

        // Set Relative or Absulute Date criteria
        if (string.IsNullOrEmpty(objFilter.FromRelativeCriteria))
            txt1.Text = clsGeneral.FormatDBNullDateToDisplay(objFilter.FromDate);
        else
        {
            // set Relative Date From criteria
            Business_RuleHelper.RaltiveDates RelType = (Business_RuleHelper.RaltiveDates)Enum.Parse(typeof(Business_RuleHelper.RaltiveDates), objFilter.FromRelativeCriteria);
            txt1.Text = Business_RuleHelper.GetRelativeDate(RelType).ToString(AppConfig.DisplayDateFormat);
            ucRelativeDatesFrom.RelativeDate = RelType;
            ucRelativeDatesFrom.strDateClientID = txt1.ClientID;
        }
        if (string.IsNullOrEmpty(objFilter.ToRelativeCriteria))
            txt2.Text = clsGeneral.FormatDBNullDateToDisplay(objFilter.ToDate);
        else
        {
            // set Relative Date To criteria
            Business_RuleHelper.RaltiveDates RelType = (Business_RuleHelper.RaltiveDates)Enum.Parse(typeof(Business_RuleHelper.RaltiveDates), objFilter.ToRelativeCriteria);
            txt2.Text = Business_RuleHelper.GetRelativeDate(RelType).ToString(AppConfig.DisplayDateFormat);
            ucRelativeDatesTo.RelativeDate = RelType;
            ucRelativeDatesTo.strDateClientID = txt2.ClientID;
        }
        img1.Attributes.Add("onclick", "return showCalendar('" + txt1.ClientID + "', 'mm/dd/y','','')");//Set From Image Attribute
        SetDateControls(lstDate1, lblDateFrom1, lblDateTo1, txtDate_From1, txtDate_To1, imgDate_To1, revtxtDate_From1, ucRelativeDatesTo_1);
    }

    /// <summary>
    /// Set Selected Values in ListBox 
    /// </summary>
    /// <param name="CSValue"></param>
    /// <param name="lstSelect"></param>
    private void SetSelectedValueFromString(string CSValue, ListBox lstSelect)
    {
        if (!string.IsNullOrEmpty(CSValue))
        {
            string[] strSelectedValues = CSValue.Split(',');

            ListItem li;

            foreach (string strSelect in strSelectedValues)
            {
                li = lstSelect.Items.FindByValue(strSelect.Replace("''", "'"));

                if (li != null)
                    li.Selected = true;
            }
        }
    }

    /// <summary>
    /// Reset Scroll Position
    /// </summary>
    private void ResetScrollPosition()
    {
        if (!ClientScript.IsClientScriptBlockRegistered(this.GetType(), "CreateResetScrollPosition"))
        {

            //Create the ResetScrollPosition() function
            ClientScript.RegisterClientScriptBlock(this.GetType(), "CreateResetScrollPosition", "function ResetScrollPosition() {" + System.Environment.NewLine +
                " var scrollX = document.getElementById('__SCROLLPOSITIONX');" + System.Environment.NewLine +
                " var scrollY = document.getElementById('__SCROLLPOSITIONY');" + System.Environment.NewLine +
                " if (scrollX && scrollY) {" + System.Environment.NewLine +
                //" scrollX.value = 0;" + System.Environment.NewLine + 
                //" scrollY.value = 0;" + System.Environment.NewLine + 
                " scrollTo(scrollX.value,scrollY.value) " + System.Environment.NewLine +
                " }" + System.Environment.NewLine
                + "}", true);

            //Add the call to the ResetScrollPosition() function
            ClientScript.RegisterStartupScript(this.GetType(), "CallResetScrollPosition", "ResetScrollPosition();", true);
        }
    }

    private string GetTableNameFromScreen()
    {
        string strTableName = "";

        if (drpScreen.SelectedIndex > 0)
        {
            clsBusiness_Rules_Screens objScreen = new clsBusiness_Rules_Screens(Convert.ToDecimal(drpScreen.SelectedValue));
            strTableName = objScreen.Main_Table;
        }
        switch (strTableName)
        {
            case "Auto_Loss_Claims": strTableName = "Auto_Loss_RMW"; break;
            case "Premises_Loss_Claims": strTableName = "Premises_Loss_RMW"; break;
        }
        //switch (drpScreen.SelectedItem.Text)
        //{
        //    case "Adjuster Notes": strTableName = "Adjustor_Notes"; break;
        //    case "Chain of Custody": strTableName = "Claim_Cargo_Custody"; break;
        //    case "Claim": strTableName = "Claim"; break;
        //    case "Contacts": strTableName = "Contact"; break;
        //    case "Diary": strTableName = "Diary"; break;
        //    case "Financials": strTableName = "[Transaction]"; break;
        //    case "Incident": strTableName = "Incident"; break;
        //    case "Incident Shipment": strTableName = "Incident_Shipment"; break;
        //    case "Legal": strTableName = "Claim_Legal"; break;
        //    case "Policy": strTableName = (drpModule.SelectedItem.Text == "Claim") ? "Claim_Policy" : "Policy"; break;
        //    case "Policy Sublimit": strTableName = "Policy_Sublimit"; break;
        //}
        return strTableName;
    }

    private string CheckdropdownType(string Field_Name)
    {
        string drpType = "";
        if (Field_Name == "[AL_FR].Citation_Issued" || Field_Name == "[AL_FR].Drivable" || Field_Name == "[AL_FR].Driver_Airlifted_Medivac" || Field_Name == "[AL_FR].Driver_Is_Owner"
             || Field_Name == "[AL_FR].Driver_Sought_Medical_Attention" || Field_Name == "[AL_FR].Driver_Was_Injured" || Field_Name == "[AL_FR].Insured_Driver_At_Fault"
             || Field_Name == "[AL_FR].Oth_Veh_Pass_Admitted_to_Hospital" || Field_Name == "[AL_FR].Oth_Veh_Pass_Airlifted_Medivac" || Field_Name == "[AL_FR].Oth_Veh_Pass_Injured"
             || Field_Name == "[AL_FR].Oth_Veh_Pass_Sought_Medical_Attention" || Field_Name == "[AL_FR].Other_Driver_Admitted_to_Hospital" || Field_Name == "[AL_FR].Other_Driver_Airlifted_Medivac"
             || Field_Name == "[AL_FR].Other_Driver_Injured" || Field_Name == "[AL_FR].Other_Driver_Sought_Medical_Attention" || Field_Name == "[AL_FR].Passenger_Sought_Medical_Attention"
             || Field_Name == "[AL_FR].Passenger_Was_Injured" || Field_Name == "[AL_FR].Passengers" || Field_Name == "[AL_FR].Pedestrian_Airlifted_Medivac" || Field_Name == "[AL_FR].Pedestrian_Injured"
             || Field_Name == "[AL_FR].Pedestrian_Involved" || Field_Name == "[AL_FR].Pedestrian_Sought_Medical_Attention" || Field_Name == "[AL_FR].Pedestrian_Still_in_Hospital"
             || Field_Name == "[AL_FR].Pedestrian_Taken_By_Emergency_Transportation" || Field_Name == "[AL_FR].Permissive_Use" || Field_Name == "[AL_FR].Property_Damage"
             || Field_Name == "[AL_FR].Security_Video_System" || Field_Name == "[AL_FR].Were_Police_Notified" || Field_Name == "[AL_FR].Witnesses" || Field_Name == "[Auto_Loss_RMW].Bodily_Injury"
             || Field_Name == "[COI_Automobile_Policies].Property_Damage" || Field_Name == "[PL_FR].Personal_Bodily_Injury" || Field_Name == "[PL_FR].Product_Involved"
             || Field_Name == "[PL_FR].Property_Damage" || Field_Name == "[PL_FR].Security_Video_System" || Field_Name == "[PL_FR].Were_Police_Notified" || Field_Name == "[PL_FR].Witnesses"
             || Field_Name == "[Premises_Loss_RMW].Bodily_injury" || Field_Name == "[WC_FR].Admitted_to_Hospital" || Field_Name == "[WC_FR].Associate_Injured_Regular_Job"
             || Field_Name == "[WC_FR].Claim_Questionable" || Field_Name == "[WC_FR].Machine_Part_Defective" || Field_Name == "[WC_FR].Machine_Part_Involved" || Field_Name == "[WC_FR].Safeguards_Provided"
             || Field_Name == "[WC_FR].Safeguards_Used" || Field_Name == "[WC_FR].Still_In_Hospital" || Field_Name == "[WC_FR].Witnesses" || Field_Name == "[AL_FR].Other_Driver_Citation_Issued"
             || Field_Name == "[PL_FR].Injured_Airlifted_Medivac" || Field_Name == "[PL_FR].Injured_Admitted_to_Hospital" || Field_Name == "[PL_FR].Estimate_Available")
            
        {
            drpType = "YesNoUnknown";
        }
        return drpType;
        }

    public static void FillInvestigationList(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        List<ListItem> liItem = new List<ListItem>();
        liItem.Add(new ListItem("Pending", "Pending"));
        liItem.Add(new ListItem("Completed", "Completed"));
        liItem.Add(new ListItem("Pending Capital Approval", "Pending Capital Approval"));
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            for (int i = 0; i < liItem.Count; i++)
            {
                ddlToFill.Items.Add((ListItem)liItem[i]);
            }
        }
    }

    public static void FillInvestigationDropDown(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        List<ListItem> liItem = new List<ListItem>();
        liItem.Add(new ListItem("Pending", "Pending"));
        liItem.Add(new ListItem("Completed", "Completed"));
        liItem.Add(new ListItem("Pending Capital Approval", "Pending Capital Approval"));
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            for (int i = 0; i < liItem.Count; i++)
            {
                ddlToFill.Items.Add((ListItem)liItem[i]);
            }
        }
    }

    public static void FillPropertyContactList(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        List<ListItem> liItem = new List<ListItem>();
        liItem.Add(new ListItem("Local Police", "Local Police"));
        liItem.Add(new ListItem("Fire Department", "Fire Department"));
        liItem.Add(new ListItem("County Sherriff", "County Sherriff"));
        liItem.Add(new ListItem("State Police", "State Police"));
        liItem.Add(new ListItem("Local Hospital", "Local Hospital"));
        liItem.Add(new ListItem("Ambulance", "Ambulance"));
        liItem.Add(new ListItem("HazMat", "HazMat"));
        liItem.Add(new ListItem("Other", "Other"));
        liItem.Add(new ListItem("Power", "Power"));
        liItem.Add(new ListItem("Water", "Water"));
        liItem.Add(new ListItem("Gas", "Gas"));
        liItem.Add(new ListItem("Cleaning", "Cleaning"));
        liItem.Add(new ListItem("Connectivity/Internet", "Connectivity/Internet"));
        liItem.Add(new ListItem("Other Contact", "Other Contact"));
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            for (int i = 0; i < liItem.Count; i++)
            {
                ddlToFill.Items.Add((ListItem)liItem[i]);
            }
        }
    }

    public static void FillPropertyContactDropDown(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        List<ListItem> liItem = new List<ListItem>();
        liItem.Add(new ListItem("Local Police", "Local Police"));
        liItem.Add(new ListItem("Fire Department", "Fire Department"));
        liItem.Add(new ListItem("County Sherriff", "County Sherriff"));
        liItem.Add(new ListItem("State Police", "State Police"));
        liItem.Add(new ListItem("Local Hospital", "Local Hospital"));
        liItem.Add(new ListItem("Ambulance", "Ambulance"));
        liItem.Add(new ListItem("HazMat", "HazMat"));
        liItem.Add(new ListItem("Other", "Other"));
        liItem.Add(new ListItem("Power", "Power"));
        liItem.Add(new ListItem("Water", "Water"));
        liItem.Add(new ListItem("Gas", "Gas"));
        liItem.Add(new ListItem("Cleaning", "Cleaning"));
        liItem.Add(new ListItem("Connectivity/Internet", "Connectivity/Internet"));
        liItem.Add(new ListItem("Other Contact", "Other Contact"));
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            for (int i = 0; i < liItem.Count; i++)
            {
                ddlToFill.Items.Add((ListItem)liItem[i]);
            }
        }
    }
    #endregion

    #region " Filters "
    /// <summary>
    /// Set Selected Value for Filter Criteria
    /// </summary>
    /// <param name="CSValue"></param>
    /// <param name="chkList"></param>
    private void SetSelectedValueFromString(string CSValue, CheckBoxList chkList)
    {
        if (!string.IsNullOrEmpty(CSValue))
        {
            string[] strSelectedValues = CSValue.Split(',');

            ListItem li;
            foreach (string strSelect in strSelectedValues)
            {
                li = chkList.Items.FindByValue(strSelect.Replace(" ", ""));

                if (li != null)
                    li.Selected = true;
            }
        }
    }
    #endregion

    
}
