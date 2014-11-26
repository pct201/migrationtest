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
using System.Text;
using System.Collections.Generic;
using System.Threading;
using RIMS_Base.Biz; 
using System.IO;  


public partial class Diary_Diary : clsBasePage
{

    #region Variable

    /// <summary>
    /// Variable Diclaration
    /// </summary>
    public RIMS_Base.Biz.CCheckWriting m_objClaimReservesInfo;
    int Pk_DiaryId = 0;
    public List<RIMS_Base.CDiary> lstDiary;
    public RIMS_Base.Biz.Diary objDiary;
    int Diary_RetVal = -1;
    public string strVal = "";
    string strSortExp = String.Empty;
    public RIMS_Base.Biz.CRolePermission m_objRightDetails;

    #endregion

    #region Properties

    public int Pk_diary
    {
        get
        {
            if (ViewState["Pk_diary"] != null && ViewState["Pk_diary"].ToString() != "")
            {
                return Convert.ToInt32(ViewState["Pk_diary"]);
            }
            return 0;
        }
        set
        {
            ViewState["Pk_diary"] = value;
        }
    }

    /// <summary>
    /// Denotes TableFK
    /// </summary>
    public int TableFK
    {
        get
        {
            if (ddlIdentification.SelectedIndex > -1)
            {
                return Convert.ToInt32(ddlIdentification.SelectedValue);
            }

            return 0;
        }
        //set { ViewState["TableFK"] = value; }
    }

     /// <summary>
     /// Contains PK_Diary_Module table
     /// </summary>
    private int Fk_Module
    {
        get
        {
            if (ddlModule.SelectedIndex > -1)
            {
                return Convert.ToInt32(ddlModule.SelectedValue);
            }
            return 0;
        }
    }

    private string ModuleName
    {
        get
        {
            if (ddlModule.SelectedIndex > -1)
            {
                return ddlModule.SelectedItem.Text;
            }
            return string.Empty;  
        }
    }

    private string Identification
    {
        get
        {
            if (ddlIdentification.SelectedIndex > -1)
            {
                return ddlIdentification.SelectedItem.Text;
            }
            return string.Empty;
        }

    }
    
    /// <summary>
    /// contains PK_Lu_Location table
    /// </summary>
    private int Fk_Lu_Location_Id
    {
        get
        {
            if (ddlLocation.SelectedIndex > -1)
            {
                return Convert.ToInt32(ddlLocation.SelectedValue);
            }
            return 0;
        }
    }

    /// <summary>
    /// Contains Pk_Lu_Task_Type table
    /// </summary>
    private int Fk_Lu_Task_Type
    {
        get
        {
            if (ddlTaskType.SelectedIndex > -1)
            {
                return Convert.ToInt32(ddlTaskType.SelectedValue);
            }
            return 0;
        }
    }

    /// <summary>
    /// Login user's Employeid
    /// </summary>
    //private int Employee_Id
    //{
    //    get { return Convert.ToInt32(clsSession.CurrentLoginEmployeeId); }
    //}

    /// <summary>
    /// Denotes TableName
    /// </summary>
    public string TableName
    {
        get
        {
            return Convert.ToString(ViewState["TableName"]);
        }
        set { ViewState["TableName"] = value; }
    }

    public string LocationIds
    {
        get
        {
            return Convert.ToString(ViewState["LocationIds"]);
        }
        set { ViewState["LocationIds"] = value; }
    }

    #endregion

    #region "Page Event"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TableName = "WC_FR";
            ddlPage.DataBind();
            ddlPage.SelectedValue = "10";
            lblPageInfo.Text = "Page 1 of " + gvDiaryDetails.PageCount.ToString();
            txtPageNo.Text = "1";
            divSearch.Style["display"] = "block";
            divthird.Style["display"] = "block";
            BindDdl();            
            MakeLocationids();
            BindDiaryDetails();
            lblPageInfo.Text = "Page 1 of " + gvDiaryDetails.PageCount.ToString();

            if (App_Access == AccessType.View_Only)
            {
                btnAddNew.Visible = false;
                btnDelete.Visible = false;
                btnClear.Visible = false;  
            }
        }
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Used to save the diary data
    /// </summary>
    protected void InsertUpdateDiary()
    {
        // object for the diary
        objDiary = new RIMS_Base.Biz.Diary();
        try
        {
            SetTableName(); 
            
            // set Diary PK and user ID
            if (Pk_diary > 0)
            {
                objDiary.PK_Diary_ID = Convert.ToInt32(ViewState["Pk_diary"].ToString());
                objDiary.Update_Date = DateTime.Now;
                if (Session["UserID"] != null)
                    objDiary.Updated_By = Session["UserID"].ToString();
            }

            objDiary.FK_Table_Name = Convert.ToDecimal(TableFK);
            if (TableName != string.Empty)
            {
                objDiary.Table_Name = TableName;
            }
            else 
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Please Select Module Properly.');", true);
                return; 
            }
            
            objDiary.FK_Diary_Module = Fk_Module;
            objDiary.FK_LU_Location_ID = Fk_Lu_Location_Id;
            objDiary.FK_LU_Task_Type = Fk_Lu_Task_Type;
            objDiary.Identification_Field = ddlIdentification.SelectedItem.Text;    


            if (Session["UserName"] != null)
                objDiary.UserDiary = Session["UserName"].ToString();

            // set the object values from page controls depending on the mode of the page

            if (txtIDONoteEntry.Text != "")
            {
                objDiary.DateOfNoteEntry = Convert.ToDateTime(txtIDONoteEntry.Text);
            }
            if (txtDiaryDate.Text != "")
            {
                objDiary.Diary_Date = Convert.ToDateTime(txtDiaryDate.Text);
            }
            if (txtNote.Text != "")
            {
                objDiary.Note = txtNote.Text.Replace("'", "''").Trim();
            }
            if (rbIClearYes.Checked == true)
            {
                objDiary.Clear = "Y";
            }
            if (rbIClearNo.Checked == true)
            {
                objDiary.Clear = "N";
            }
            if (Request.Form[txtIAssignTo.UniqueID].ToString() != "")
            {
                objDiary.Assigned_To = Request.Form[txtIAssignTo.UniqueID].ToString();                 
            }
            ViewState.Remove("Pk_diary");

            int Pk_Diary = objDiary.InsertUpdateDiary(objDiary);
            ResetControl();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDiary = null;
        }
    }

    /// <summary>
    /// Bind All dropdown
    /// </summary>
    private void BindDdl()
    {
        BindDairyModule();
        BindLocationdba();
        BindTaskType();
    }

    /// <summary>
    /// Bind dropdown of diary modules
    /// </summary>
    private void BindDairyModule()
    {
        ComboHelper.FillDairyModule(new DropDownList[] { ddlModule }, true);
    }

    /// <summary>
    /// Bind dropdown of identification field.
    /// </summary>
    private void BindIdentificationField()
    {
        if (Fk_Lu_Location_Id > 0)
        {
            ComboHelper.FillDairyIdentificationField(new DropDownList[] { ddlIdentification }, Fk_Module,Fk_Lu_Location_Id , true);
        }
        else
        {
            ddlIdentification.Items.Clear();  
        }
    }

    /// <summary>
    /// Binding dropdown of location.
    /// </summary>
    private void BindLocationdba()
    {
        ComboHelper.FillLocationdbaOnly(new DropDownList[] { ddlLocation }, 0, true);
        ddlLocation.Style.Remove("font-size");
    }

    /// <summary>
    /// Binding dropdown of Tasktype.
    /// </summary>
    private void BindTaskType()
    {
        ComboHelper.FillDairyTaskType(new DropDownList[] { ddlTaskType }, true);
    }

    /// <summary>
    /// Reset controls which used in edit or add mode.
    /// </summary>
    private void ResetControl()
    {
        txtDiaryDate.Text = string.Empty;
        txtIDONoteEntry.Text = string.Empty;
        txtIAssignTo.Text = string.Empty;
        txtIAssignToID.Text = string.Empty;
        txtNote.Text = string.Empty;
        ddlModule.SelectedValue = "0";
        ddlLocation.SelectedValue = "0";
        ddlTaskType.SelectedValue = "0"; 
        ddlIdentification.Items.Clear();
        //ddlIdentification.Enabled = false;
    }

    /// <summary>
    /// Reset controls which used in view mode
    /// </summary>
    private void ResetControl_View()
    {
        lblDONoteEntry_View.Text = string.Empty;
        lblDiaryDate_View.Text = string.Empty;    
        lblModule_View.Text = string.Empty;
        lblLocation_View.Text = string.Empty;
        lblIdentification_View.Text = string.Empty;
        lblTaskType_View.Text = string.Empty;   
        lblNote_View.Text = string.Empty;
        lblClear_View.Text = string.Empty;
        lblAssignTo_View.Text = string.Empty;
    }

    /// <summary>
    /// Get Data By pk Diary id to fill control in view and edit mode.
    /// </summary>
    /// <param name="isView">specify funcation is call for edit mode or view mode</param>
    private void GetData(bool isView)
    {
        objDiary = new RIMS_Base.Biz.Diary();        
        lstDiary = new List<RIMS_Base.CDiary>();
        lstDiary = objDiary.GetyByID(Pk_diary,isView);
        //ddlIdentification.Enabled = false;
        int _IdentificationFieldValue = 0;
        string _IdentificationFiledText = string.Empty;

        DataSet ds = new DataSet();
        if (lstDiary[0].FK_Diary_Module.ToString() != string.Empty && lstDiary[0].FK_LU_Location_ID.ToString() != string.Empty)
        {
            ds = objDiary.GetDiaryIdentificationField(Convert.ToInt32(lstDiary[0].FK_Diary_Module), Convert.ToInt32(lstDiary[0].FK_LU_Location_ID), Convert.ToInt32(lstDiary[0].FK_Table_Name));

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                _IdentificationFieldValue = Convert.ToInt32(ds.Tables[0].Rows[0]["ValueField"].ToString());
                _IdentificationFiledText = Convert.ToString(ds.Tables[0].Rows[0]["TextField"].ToString());
                ds = null;
            }
        }

        if (lstDiary != null && Pk_diary > 0)
        {
            if (isView)
            {
                ResetControl_View();
                lblDONoteEntry_View.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(lstDiary[0].DateOfNoteEntry));
                lblDiaryDate_View.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(lstDiary[0].Diary_Date));

                lblNote_View.Text = clsGeneral.FormatDBNULLTostring(lstDiary[0].Note);
                lblModule_View.Text = clsGeneral.FormatDBNULLTostring(lstDiary[0].Module_Name);
                lblLocation_View.Text = clsGeneral.FormatDBNULLTostring(lstDiary[0].Location);
                lblTaskType_View.Text = clsGeneral.FormatDBNULLTostring(lstDiary[0].Task_Type);

                lblIdentification_View.Text = clsGeneral.FormatDBNULLTostring(_IdentificationFiledText);
                
                if (lstDiary[0].Clear == "Y")
                {
                    lblClear_View.Text = "Yes";
                }
                else
                {
                    lblClear_View.Text = "No";
                }

                lblAssignTo_View.Text = lstDiary[0].Assigned_To; 

            }
            else
            {
                ResetControl(); 
                txtIDONoteEntry.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(lstDiary[0].DateOfNoteEntry));
                txtDiaryDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(lstDiary[0].Diary_Date));
                
                if (!string.IsNullOrEmpty(lstDiary[0].FK_Diary_Module.ToString()))
                {
                    ddlModule.SelectedValue = lstDiary[0].FK_Diary_Module.ToString();
                }

                if (!string.IsNullOrEmpty(lstDiary[0].FK_LU_Location_ID.ToString()))
                {
                    if (ddlLocation.Items.FindByValue(lstDiary[0].FK_LU_Location_ID.ToString()) != null)
                    {
                        ddlLocation.SelectedValue = lstDiary[0].FK_LU_Location_ID.ToString();
                    }
                }

                if (!string.IsNullOrEmpty(lstDiary[0].FK_LU_Task_Type.ToString()))
                {

                    ddlTaskType.SelectedValue = lstDiary[0].FK_LU_Task_Type.ToString();
                }
                else 
                {
                    ddlTaskType.SelectedValue = "0"; 
                }

                BindIdentificationField();

                if (ddlIdentification.Items.FindByValue(_IdentificationFieldValue.ToString()) != null)
                {
                    ddlIdentification.SelectedValue  = _IdentificationFieldValue.ToString();
                }

                if (!string.IsNullOrEmpty(lstDiary[0].Note))
                {
                    txtNote.Text = lstDiary[0].Note.ToString();
                }                

                if (lstDiary[0].Clear == "Y")
                {
                    rbIClearYes.Checked = true;
                    rbIClearNo.Checked = false;
                }
                else
                {
                    rbIClearYes.Checked = false;
                    rbIClearNo.Checked = true;
                }

                txtIAssignTo.Text = lstDiary[0].Assigned_To;
            }
        }

        objDiary = null;
        lstDiary = null;
    }

    /// <summary>
    /// General Sorting
    /// </summary>
    private void GeneralSorting()
    {
        try
        {
            lstDiary = new List<RIMS_Base.CDiary>();
            BindDiaryDetails();
            if (ViewState["SortExp"] != null && ViewState["sortDirection"] != null)
            {
                lstDiary.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CDiary>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
                strSortExp = ViewState["SortExp"].ToString();
            }
            gvDiaryDetails.DataSource = lstDiary;
            gvDiaryDetails.DataBind();
            lblPageInfo.Text = "Page " + Convert.ToString(gvDiaryDetails.PageIndex + 1) + " of " + gvDiaryDetails.PageCount.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Set actual table name as per diary module id
    /// </summary>
    private void SetTableName()
    {           
        switch (Fk_Module)
        {
            case 1:
             TableName = "WC_FR";
             break;
            case 2:
             TableName = "WC_FR";
             break;
            case 3:
             TableName = "AL_FR";
             break;
            case 4:
             TableName = "DPD_FR";
             break;
            case 5:
             TableName = "PL_FR";
             break;
            case 6:
             TableName = "Property_FR";
             break;
            case 7:
             TableName = "Workers_Comp_Claims";
             break;
            case 8:
             TableName = "Workers_Comp_Claims";
             break;
            case 9:
             TableName = "Auto_Loss_Claims";
             break;
            case 10:
             TableName = "DPD_Claims";
             break;
            case 11:
             TableName = "Premises_Loss_Claims";
             break;
            case 12:
             TableName = "Property_FR";
             break;
            case 13:
             TableName = "Investigation";
             break;
            case 14:
             TableName = "SLT_Meeting_Schedule";
             break;
            case 15:
             TableName = "COI_Insureds";
             break;
            case 16:
             TableName = "Policy";
             break;
            case 17:
             TableName = "Building";
             break;
            case 18:
             TableName = "Franchise";
             break;
            case 19:
             TableName = "PM_Site_Information";
             break;
            case 20:
             TableName = "Inspection";
             break;
            case 21:
             TableName = "RE_Information";
             break;
            case 22:
             TableName = "Purchasing_Asset";
             break;
            case 23:
             TableName = "Purchasing_LR_Agreement";
             break;
            case 24:
             TableName = "Purchasing_Service_Contract";
             break;
            case 25:
             TableName = "CRM_Customer";
             break;
            case 26:
             TableName = "CRM_Non_Customer";
             break;
            default :
             TableName = "";
             break;
        }

    }

    /// <summary>
    /// Making comma seperated Location ids 
    /// </summary>
    private void MakeLocationids()
    {
        StringBuilder sbLocationId = new StringBuilder();
        
        foreach(ListItem ltItem in ddlLocation.Items)
        {
            sbLocationId.Append(ltItem.Value + ",");
        }        
       LocationIds  = sbLocationId.ToString().TrimEnd(',');   
    }

    /// <summary>
    /// Get Url to redirect to specific module page from identification
    /// </summary>
    /// <param name="idModule">Diary Module id</param>
    /// <param name="idFkTableName"> pk id of specific module page </param>
    /// <param name="Location">Location</param>
    /// <param name="WZ_ID">Firstreport Wizard id</param>
    /// <returns></returns>
    private string GetUrl(int idModule, string idFkTableName, string Location, int WZ_ID)
    {
        string strUrl = string.Empty;
        //int WZ_ID = 0;

        switch (idModule)
        {         
            case 1:                
                strUrl = "~/SONIC/FirstReport/WCFirstReport.aspx?id=" + idFkTableName +"&WZ_ID=" + Encryption.Encrypt(WZ_ID.ToString());
                break;
            case 2:                
                strUrl = "~/SONIC/FirstReport/WCFirstReport.aspx?id=" + idFkTableName + "&WZ_ID=" + Encryption.Encrypt(WZ_ID.ToString());
                break;
            case 3:                
                strUrl = "~/SONIC/FirstReport/ALFirstReport.aspx?id=" + idFkTableName + "&WZ_ID=" + Encryption.Encrypt(WZ_ID.ToString());
                break;
            case 4:                
                strUrl = "~/SONIC/FirstReport/DPDFirstReport.aspx?id=" + idFkTableName + "&WZ_ID=" + Encryption.Encrypt(WZ_ID.ToString());
                break;
            case 5:                
                strUrl = "~/SONIC/FirstReport/PLFirstReport.aspx?id=" + idFkTableName + "&WZ_ID=" + Encryption.Encrypt(WZ_ID.ToString());
                break;
            case 6:                
                strUrl = "~/SONIC/FirstReport/PropertyFirstReport.aspx?id=" + idFkTableName + "&WZ_ID=" + Encryption.Encrypt(WZ_ID.ToString());
                break;
            case 7: //NS Claim
                strUrl = "~/SONIC/ClaimInfo/WCClaimInfo.aspx?id=" + idFkTableName;
                break; 
            case 8:
                strUrl = "~/SONIC/ClaimInfo/WCClaimInfo.aspx?id=" + idFkTableName;
                break;
            case 9:
                strUrl = "~/SONIC/ClaimInfo/ALClaimInfo.aspx?id=" + idFkTableName;
                break;
            case 10:
                strUrl = "~/SONIC/ClaimInfo/DPDClaimInfo.aspx?id=" + idFkTableName;
                break;
            case 11:
                strUrl = "~/SONIC/ClaimInfo/PLClaimInfo.aspx?id=" + idFkTableName;
                break;
            case 12:
                strUrl = "~/SONIC/ClaimInfo/PropertyClaimInfo.aspx?id=" + idFkTableName;
                break;
            case 13:
                strUrl = "~/SONIC/FirstReport/Investigation.aspx?id=" + idFkTableName;
                break;
            case 14:
                strUrl = "~/SONIC/SLT/SLT_Meeting.aspx?id=" + idFkTableName + "&op=view" + "&LID=" + Location;
                break;
            case 15:
                strUrl = "~/COI/RiskProfileAddEdit.aspx?id=" + idFkTableName + "&op=view";
                break;
            case 16:
                Session["PolicyMode"] = "View";
                strUrl = "~/Policy/FCIPolicy.aspx?id=" + idFkTableName;
                break;
            case 17:
                strUrl = "~/SONIC/Exposures/PropertyView.aspx?id=" + idFkTableName + "&loc=" + Location + "&op=view";
                break;
            case 18:
                strUrl = "~/SONIC/Franchise/FranchiseAddEdit.aspx?id=" + idFkTableName + "&loc=" + Location + "&op=view";
                break;
            case 19: 
                strUrl = "~/SONIC/Exposures/ViewEnvironmental.aspx?loc=" + Location;
                break;
            case 20: 
                strUrl = "~/SONIC/Exposures/Inspections.aspx?loc=" + Location;
                break;
            case 21: 
                strUrl = "~/SONIC/RealEstate/Lease.aspx?id=" + idFkTableName + "&loc=" + Location;
                break;
            case 22:
                strUrl = "~/SONIC/Purchasing/PurchasingAssetInformation.aspx?id=" + idFkTableName;
                break;
            case 23: 
                strUrl = "~/SONIC/Purchasing/LeaseRentalAgreement.aspx?id=" + idFkTableName;
                break;
            case 24: 
                strUrl = "~/SONIC/Purchasing/ServiceContract.aspx?id=" + idFkTableName;
                break;
            case 25:
                strUrl = "~/SONIC/CRM/CRM_Customer.aspx?id=" + idFkTableName + "&op=view";
                break;
            case 26:
                strUrl = "~/SONIC/CRM/CRM_NonCustomer.aspx?id=" + idFkTableName + "&op=view";
                break;
            default:
                strUrl = "";
                break;
        }

        return strUrl;
    }

    //private int GetFrWizardId(string Table_Name)
    //{
    //    objDiary = new RIMS_Base.Biz.Diary();
    //    return objDiary.Get_FRWizardID(Table_Name); 
    //}

    #endregion

    #region Grid's All types of Events

    /// <summary>
    /// Handles Save & View button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveView_Click(object sender, EventArgs e)
    {

        if (TableFK > 0)
        {
            // show/hide required div
            divSearch.Style["display"] = "block";
            divthird.Style["display"] = "block";
            divForth.Style["display"] = "none";

            // get assigned to ID from hidden textbox
            string AssignToID = String.Empty;
            AssignToID = txtIAssignToID.Text;

            /********* MAIL PROCESS ********************/
            if (AssignToID != String.Empty)
            {
                RIMS_Base.Biz.CSecurity m_objSecurity = new RIMS_Base.Biz.CSecurity();
                List<RIMS_Base.CSecurity> lstSecurity = new List<RIMS_Base.CSecurity>();
                lstSecurity = m_objSecurity.GetSecurityByID(Convert.ToInt32(AssignToID));
                if (lstSecurity.Count > 0)
                {
                    if (lstSecurity[0].Email != string.Empty)
                    {
                        clsGeneral.SendMailMessage(AppConfig.MailFrom, lstSecurity[0].Email, "", AppConfig.MailCC, "Diary Assigned" , "You have been assigned diary for " + ModuleName +  " and identification is :- " + Identification  , false);
                    }
                }
            }
            /****************************************/

            // save record and bind the diary grid
            InsertUpdateDiary();
            BindDiaryDetails();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Please select identification field.');", true);
        }
    }

    /// <summary>
    /// Handles Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        // show/hide required DIV
        divSearch.Style["display"] = "block";
        divthird.Style["display"] = "block";
        divForth.Style["display"] = "none";
        divfifth.Style["display"] = "none";
    }

    /// <summary>
    /// Handles Rowcommand event for Diary details grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDiaryDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Redirect")
            {
                divSearch.Style["display"] = "none";
                Pk_DiaryId = Convert.ToInt32(e.CommandArgument.ToString());
                Pk_diary = Pk_DiaryId;
            }
            if (e.CommandName == "EditItem")
            {
                divSearch.Style["display"] = "none";
                divthird.Style["display"] = "none";
                divForth.Style["display"] = "block";
                btnIAssignTO.Attributes.Add("onClick", "return openPopUp('" + txtIAssignTo.ID + "','" + txtIAssignToID.ID + "');");                
                GetData(false);
            }
            else if (e.CommandName == "View")
            {
                divSearch.Style["display"] = "none";
                divthird.Style["display"] = "none";
                divfifth.Style["display"] = "block";
                GetData(true);
            }
            else if (e.CommandName == "Redirect")
            {
                int idModule = 0;
                int Wz_Id = 0;
                string strIdFkTable = string.Empty;
                string strLocation = string.Empty; 
                LinkButton lnkIdentificatoin = (LinkButton)(e.CommandSource);
                int index = ((GridViewRow)lnkIdentificatoin.Parent.Parent).RowIndex;
                HiddenField hdnidModule = (HiddenField)gvDiaryDetails.Rows[index].FindControl("hdnidModule");
                HiddenField hdnidFkTable = (HiddenField)gvDiaryDetails.Rows[index].FindControl("hdnidFkTable");
                HiddenField hdnFrWizardId = (HiddenField)gvDiaryDetails.Rows[index].FindControl("hdnFrWizardId");

                idModule = Convert.ToInt32(hdnidModule.Value);
                Wz_Id = Convert.ToInt32(hdnFrWizardId.Value);
                strIdFkTable = Encryption.Encrypt(hdnidFkTable.Value);
                strLocation = Encryption.Encrypt(e.CommandArgument.ToString());

                if (lnkIdentificatoin != null)
                {
                    string strUrl = string.Empty;
                    strUrl = GetUrl(idModule, strIdFkTable, strLocation, Wz_Id);

                    if (idModule == 16)
                    {
                        Session["PolicyId"] = hdnidFkTable.Value;
                    }
                    Response.Redirect(strUrl,false);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Handles event when row data is bound in diary view
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlIdentification.Enabled = true;        
        BindIdentificationField();
    }

    /// <summary>
    /// ddl module selectd index change event.    
    /// setting table name on selection of module.
    /// Binding identification dropdown if location is already selected(Used in edit mode).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetTableName();
        ddlIdentification.Enabled = true;  
        BindIdentificationField();
    }

    /// <summary>
    /// Bind Diary Detail Grid
    /// </summary>
    private void BindDiaryDetails()
    {
        try
        {
            objDiary = new RIMS_Base.Biz.Diary();
            lstDiary = new List<RIMS_Base.CDiary>();
            if (txtSearch.Text != string.Empty)
            {
                lstDiary = objDiary.Search_DiaryData(ddlSearch.SelectedValue, txtSearch.Text.Trim().Replace("'", "''"), 0, null, LocationIds);
            }
            else
            {
                lstDiary = objDiary.Search_DiaryData(null, null, 0, null, LocationIds);
            }
            gvDiaryDetails.DataSource = lstDiary;
            gvDiaryDetails.DataBind();            

            if (lstDiary.Count <= 0)
            {
                btnDelete.Visible = false;
                lblNumber.Text = 0.ToString();
            }
            else
            {
                lblNumber.Text = lstDiary.Count.ToString();
                btnDelete.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            //lstDiary = null;
        }
    }

    /// <summary>
    /// Handles event when sorting is performed on Diary details grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDiaryDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        lstDiary = new List<RIMS_Base.CDiary>();
        objDiary = new RIMS_Base.Biz.Diary();

        if (ViewState["sortDirection"] == null)
            ViewState["sortDirection"] = SortDirection.Ascending;
        // Changes the sort direction 
        else
        {
            if (((SortDirection)ViewState["sortDirection"]) == SortDirection.Ascending)
                ViewState["sortDirection"] = SortDirection.Descending;
            else
                ViewState["sortDirection"] = SortDirection.Ascending;
        }
        ViewState["SortExp"] = strSortExp = e.SortExpression;

        lstDiary = objDiary.Search_DiaryData(null, null, 0, null, LocationIds);

        if (ViewState["SortExp"] != null)
            lstDiary.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CDiary>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
        gvDiaryDetails.DataSource = lstDiary;
        gvDiaryDetails.DataBind();

        divSearch.Style["display"] = "block";
        divthird.Style["display"] = "block";
    }

    /// <summary>
    /// Handles event when row is created for Dairy details grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDiaryDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (String.Empty != strSortExp)
            {
                AddSortImage(e.Row);
            }
        }
    }

    /// <summary>
    /// Get index of the column on which sorting is performed
    /// </summary>
    /// <param name="strSortExp"></param>
    /// <returns></returns>
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvDiaryDetails.Columns)
        {
            if (field.SortExpression.ToString() == ViewState["SortExp"].ToString())
            {
                nRet = gvDiaryDetails.Columns.IndexOf(field);
            }
        }
        return nRet;
    }

    /// <summary>
    /// Used to add image beside the column on which sorting is done
    /// </summary>
    /// <param name="headerRow"></param>
    private void AddSortImage(GridViewRow headerRow)
    {

        Int32 iCol = GetSortColumnIndex(strSortExp);
        if (-1 == iCol)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();

        if (SortDirection.Ascending.ToString() == ViewState["sortDirection"].ToString())
        {
            sortImage.ImageUrl = "~/Images/up-arrow.gif";
            sortImage.AlternateText = "Descending Order";
        }
        else
        {
            sortImage.ImageUrl = "~/Images/down-arrow.gif";
            sortImage.AlternateText = "Ascending Order";
        }

        // Add the image to the appropriate header cell.
        headerRow.Cells[iCol].Controls.Add(sortImage);
    }

    /// <summary>
    /// Used to bind the row when grid is bound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void gvDiaryDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    int idModule = 0;
        //    LinkButton lnkIdentificatoin = ((LinkButton)e.Row.FindControl("lnkIdentificatoin"));
        //    HiddenField hdnidModule = ((HiddenField)e.Row.FindControl("hdnidModule"));
        //    HiddenField hdnidFkTable = ((HiddenField)e.Row.FindControl("hdnidFkTable"));

        //    idModule = Convert.ToInt32(hdnidModule.Value);

        //    if (lnkIdentificatoin != null)
        //    {
        //        string strUrl = string.Empty;
        //        strUrl = GetUrl(Convert.ToInt32(idModule)) + "?id=" + Encryption.Encrypt(hdnidFkTable.Value.ToString());

        //        if (idModule == 1)
        //        {
        //            strUrl = strUrl + "WZ_ID = 1";
        //        }
        //        lnkIdentificatoin.PostBackUrl = strUrl; 
        //    }
        //}
    //}

    #endregion

    #region Search Facility

    /// <summary>    
    /// to Clear Diary records
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            string strPk_Diary_Id = string.Empty;
            if (Request.Form["chkItem"] != null)
            {
                strPk_Diary_Id = Request.Form["chkItem"].ToString();
                objDiary = new RIMS_Base.Biz.Diary();
                objDiary.UpdateDiaryStatus(strPk_Diary_Id);
                BindDiaryDetails();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Selected Diaries are cleared.');", true);
            }
            else { Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Please select at least one diary.');", true); }
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Error occurred while clear the diary.Please try again.');", true);
        }
        
    }
    /// <summary>
    /// Handles Search button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            // bind the diary grid
            BindDiaryDetails();
            lblPageInfo.Text = "Page 1 of " + gvDiaryDetails.PageCount.ToString();            
            divSearch.Style["display"] = "block";
            divthird.Style["display"] = "block";            		
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Handles the delete button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            // delete the selected diary records and bind the grid

            if (Request.Form["chkItem"] != null)
            {
                objDiary = new RIMS_Base.Biz.Diary();
                Diary_RetVal = objDiary.DeleteDiary(Request.Form["chkItem"].ToString());
                if (Diary_RetVal <= 0)
                {
                    BindDiaryDetails();
                    divSearch.Style["display"] = "block";
                    divthird.Style["display"] = "block";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Selected Diaries are deleted.');", true);
                }
            }
            else { Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Please select at least one diary.');", true); }
            
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Error occurred while delete the diary.Please try again.');", true);
        }
    }

    /// <summary>
    /// Handles event when Add New button is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        try
        {
            ResetControl();
            ViewState.Remove("Pk_diary");
            divSearch.Style["display"] = "none";            
            divthird.Style["display"] = "none";
            divForth.Style["display"] = "block";            
            btnIAssignTO.Attributes.Add("onClick", "return openPopUp('txtAssignTo,txtAssignToID.ID');");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Handles Go button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {
            // set the pageindex of diary grid based on the page number entered in textbox
            if (txtPageNo.Text.ToString().Trim() == string.Empty || Convert.ToInt32(txtPageNo.Text) < 1)
            {
                gvDiaryDetails.PageIndex = 0;
                txtPageNo.Text = "1";
            }
            else if (Convert.ToInt32(txtPageNo.Text) > gvDiaryDetails.PageCount)
            {
                gvDiaryDetails.PageIndex = gvDiaryDetails.PageCount;
                txtPageNo.Text = gvDiaryDetails.PageCount.ToString();
            }
            else
            {
                gvDiaryDetails.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;
            }
            lblPageInfo.Text = "Page " + txtPageNo.Text.ToString() + " of " + gvDiaryDetails.PageCount.ToString();
            BindDiaryDetails();

            // show/hide the DIVs            
            divSearch.Style["display"] = "block";
            divthird.Style["display"] = "block";            
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Handles event for Next button click in paging
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            // if page index is less than the pagecount for diary grid
            if (gvDiaryDetails.PageIndex <= gvDiaryDetails.PageCount)
            {
                gvDiaryDetails.PageIndex = gvDiaryDetails.PageIndex + 1;
                GeneralSorting();
                lblPageInfo.Text = "Page " + Convert.ToString(gvDiaryDetails.PageIndex + 1) + " of " + gvDiaryDetails.PageCount.ToString();
            }
            divSearch.Style["display"] = "block";            
            divthird.Style["display"] = "block";
        }
        catch (Exception ex)
        {
        }
    }

    /// <summary>
    /// Handles event when page number selection is changed in dropdown
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            // set the page size and bind the grid
            gvDiaryDetails.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
            BindDiaryDetails();
            lblPageInfo.Text = "Page 1 of " + gvDiaryDetails.PageCount.ToString();
            txtPageNo.Text = "1";
            // show/hide the DIVs
            divSearch.Style["display"] = "block";            
            divthird.Style["display"] = "block";            
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Handles Prev button click event for paging
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        try
        {
            // set page index 
            if (gvDiaryDetails.PageIndex <= gvDiaryDetails.PageCount)
            {
                if (gvDiaryDetails.PageIndex != 0)
                {
                    gvDiaryDetails.PageIndex = gvDiaryDetails.PageIndex - 1;
                    GeneralSorting();
                    lblPageInfo.Text = "Page " + Convert.ToString(gvDiaryDetails.PageIndex + 1) + " of " + gvDiaryDetails.PageCount.ToString();
                }
            }
            // show/hide the DIVs
            divSearch.Style["display"] = "block";            
            divthird.Style["display"] = "block";             
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion
}
