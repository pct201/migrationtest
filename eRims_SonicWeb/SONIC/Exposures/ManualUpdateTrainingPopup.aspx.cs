﻿using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SONIC_Exposures_ManualUpdateTrainingPopup : clsBasePage
{
    /// <summary>
    /// Denotes PK_ID
    /// </summary>
    public decimal PK_ID
    {
        get { return ViewState["PK_ID"] != null ? Convert.ToDecimal(ViewState["PK_ID"]) : 0; }
        set { ViewState["PK_ID"] = value; }
    }

    #region "Page Events"

    /// <summary>
    /// handles Page_Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDownList();
            if (Request.QueryString["id"] != null)
            {
                decimal pk_ID;
                if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out pk_ID))
                {
                    PK_ID = pk_ID;
                    if (PK_ID > 0)
                    {
                        BindDropDownForEdit();
                    }
                }
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
        //bind drop down for Associate
        if (Session["PK_Employee_ID"] != null && Convert.ToDecimal(Session["PK_Employee_ID"]) > 0)
        {
            ComboHelper.FillEmployeeBY_Loc_Training(new DropDownList[] { ddlAssociate }, true, Convert.ToInt32(Session["location"]));
            clsGeneral.SetDropdownValue(ddlAssociate, Convert.ToInt32(Session["PK_Employee_ID"]), true);
        }
        else
        {
            ComboHelper.FillEmployeeBY_Loc_Training(new DropDownList[] { ddlAssociate }, true, Convert.ToInt32(Session["location"]));
        }
        //bind drop down Class Name
        ComboHelper.FillClassName(new DropDownList[] { ddlClass }, 0, true, Convert.ToInt32(Session["location"]));
    }

    /// <summary>
    /// Bind Drop Down for Edit
    /// </summary>
    private void BindDropDownForEdit()
    {
        Sonic_U_Associate_Training_Manual objTraining = new Sonic_U_Associate_Training_Manual(PK_ID);
        clsGeneral.SetDropdownValue(ddlAssociate, objTraining.FK_Employee, true);
        clsGeneral.SetDropdownValue(ddlClass, objTraining.FK_Sonic_U_Training_Class, true);
    }

    #endregion

    #region "Events"

    /// <summary>
    /// Button Cancel Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddlAssociate.SelectedIndex = 0;
        ddlClass.SelectedIndex = 0;

        if (PK_ID > 0)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "closepopup('edit');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "closepopup();", true);
        }
    }

    /// <summary>
    /// Button Save Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int Result = 0;

        Sonic_U_Associate_Training_Manual objSonic_U_Training = new Sonic_U_Associate_Training_Manual();
        objSonic_U_Training.Year = Convert.ToInt16(Session["Year"]);
        objSonic_U_Training.Train_Quarter = Convert.ToInt16(Session["Quater"]);
        // objSonic_U_Training.Completed = false;
        if (ddlAssociate.SelectedIndex > 0) objSonic_U_Training.FK_Employee = Convert.ToInt32(ddlAssociate.SelectedValue);
        if (ddlClass.SelectedIndex > 0) objSonic_U_Training.FK_Sonic_U_Training_Class = Convert.ToInt32(ddlClass.SelectedValue);
        objSonic_U_Training.Update_Date = DateTime.Now;
        objSonic_U_Training.Updated_By = clsSession.UserID;
        objSonic_U_Training.FK_Location = Convert.ToInt16(Session["location"]);
        objSonic_U_Training.PK_Sonic_U_Associate_Training_Manual = PK_ID;

        if (PK_ID > 0)
        {
            Sonic_U_Associate_Training_Manual objManual = new Sonic_U_Associate_Training_Manual(PK_ID);
            objSonic_U_Training.Completed = objManual.Completed;

            if (Sonic_U_Associate_Training_Manual.Sonic_U_Associate_Training_ManualDuplicateRecord(Convert.ToInt32(ddlAssociate.SelectedValue), Convert.ToInt16(Session["Year"]), Convert.ToInt16(Session["Quater"]), Convert.ToInt32(ddlClass.SelectedValue), Convert.ToBoolean(objSonic_U_Training.Completed), Convert.ToInt16(Session["location"]), PK_ID) == 0)
            {
                Result = objSonic_U_Training.Update();
                ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "closepopup('edit');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:alert('This class is already added for the Associate " + Convert.ToString(ddlAssociate.SelectedItem.Text) + " for Year " + Convert.ToInt16(Session["Year"]) + " and Quarter " + Convert.ToInt16(Session["Quater"]) + "');", true);
                return;
            }
        }
        else
        {
            int status = Sonic_U_Associate_Training_Manual.Sonic_U_Associate_Training_ManualDuplicateRecord(Convert.ToInt32(ddlAssociate.SelectedValue), Convert.ToInt16(Session["Year"]), Convert.ToInt16(Session["Quater"]), Convert.ToInt32(ddlClass.SelectedValue), false, Convert.ToInt16(Session["location"]), PK_ID);
            switch (status)
            {
                case 0:
                    objSonic_U_Training.Completed = false;
                    Result = objSonic_U_Training.Insert();
                    ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "closepopup();", true);
                    break;
                case 1:
                   ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:alert('This class is already added for the Associate "+ Convert.ToString(ddlAssociate.SelectedItem.Text) +" for Year " + Convert.ToInt16(Session["Year"]) + " and Quarter " + Convert.ToInt16(Session["Quater"])+"');", true);
                    return; 
                case 2:
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "ConfirmAssign();", true);
                    Result = 1;
                    return;
                default: break;
            }            
        }

        if (Result == 1)
        {
            if (PK_ID > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "closepopup('edit');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "closepopup();", true);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(string), DateTime.Now.ToString(), "javascript:Confirm('Automated Training already exists for Current Employee,Class,Year and Quarter');", true);
        }
    }

    #endregion

    protected void btnAssignTraining_Click(object sender, EventArgs e)
    {
        Sonic_U_Associate_Training_Manual.Sonic_U_Associate_Training_Manual_RemoveEnrollment(Convert.ToInt32(ddlAssociate.SelectedValue), Convert.ToInt16(Session["Year"]), Convert.ToInt16(Session["Quater"]), Convert.ToInt32(ddlClass.SelectedValue));
        Sonic_U_Associate_Training_Manual objSonic_U_Training = new Sonic_U_Associate_Training_Manual();
        objSonic_U_Training.Year = Convert.ToInt16(Session["Year"]);
        objSonic_U_Training.Train_Quarter = Convert.ToInt16(Session["Quater"]);
        // objSonic_U_Training.Completed = false;
        if (ddlAssociate.SelectedIndex > 0) objSonic_U_Training.FK_Employee = Convert.ToInt32(ddlAssociate.SelectedValue);
        if (ddlClass.SelectedIndex > 0) objSonic_U_Training.FK_Sonic_U_Training_Class = Convert.ToInt32(ddlClass.SelectedValue);
        objSonic_U_Training.Update_Date = DateTime.Now;
        objSonic_U_Training.Updated_By = clsSession.UserID;
        objSonic_U_Training.FK_Location = Convert.ToInt16(Session["location"]);
        objSonic_U_Training.PK_Sonic_U_Associate_Training_Manual = PK_ID;
        objSonic_U_Training.Completed = false;
         objSonic_U_Training.Insert();
        ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "closepopup();", true);
    }
}