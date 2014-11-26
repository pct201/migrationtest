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
using System.Collections.Generic;
using System.IO;
public partial class Liability_Adjuster : System.Web.UI.Page
{
    public RIMS_Base.Biz.CAdjustor objAdjustor;
    public List<RIMS_Base.CAdjustor> lstAdjustor;
    int Adjustor_RetVal = 0;
    int AdjustorID = 0;

    public RIMS_Base.Biz.CCheckWriting m_objClaimReservesInfo;
    List<RIMS_Base.CCheckWriting> lstClaimReservesInfo = null;

    // -- Attachment
    public string m_strCustomFileName = string.Empty;
    public string m_strFileName = string.Empty;
    public string m_strGlobalPath = string.Empty;
    public string m_strPath = string.Empty;
    public string m_strFolderName = "Liability_Adjustor_Notes";
    public RIMS_Base.Biz.CAttachment m_objAttachment;
    List<RIMS_Base.CAttachment> lstAttachment = null;
    int Attach_Retval = -1;
    string AttachmentID = "";
    RIMS_Base.Biz.CLiabilityClaim objLiability;
    List<RIMS_Base.CLiabilityClaim> lstLiability;

    // --- Here Autor name is the User Login Name and that would be change.
    protected void Page_Load(object sender, EventArgs e)
    {
        m_strGlobalPath = Page.ResolveUrl(ConfigurationManager.AppSettings["UploadPath"] + "/"+m_strFolderName+"/");
        if (!IsPostBack)
        {
            ViewState.Clear();
          //  Session["WorkerCompID"] = "43";

            btnRemove.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvAttachmentDetails','Delete');");

            if (Session["WorkerCompID"] != null && Session["WorkerCompID"].ToString() != String.Empty)
            {
                objLiability = new RIMS_Base.Biz.CLiabilityClaim();
                lstLiability = new List<RIMS_Base.CLiabilityClaim>();
                try
                {
                    lstLiability = objLiability.Getility_ClaimByID(Convert.ToInt32(Session["WorkerCompID"].ToString()));
                    string Claim_No = lstLiability[0].Claim_Number;
                    DisplayEmployeeInfo(Claim_No);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    objLiability = null;
                    lstLiability = null;
                }

                btnDelete.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvDiaryDetails','Delete');");

                mvAdjustorDetails.ActiveViewIndex = 0;

                //ViewAllFromSearchGrid();
                if (Session["ViewAll"] != null && Session["ViewAll"].ToString() != String.Empty)
                    ViewAllFromSearchGrid();
                else
                {
                    BindAdjustorDetails();
                    gvAdjustorDetails.DataSource = lstAdjustor;
                    gvAdjustorDetails.DataBind();
                }

                gvAdjustorDetails.PageSize = 10;
                ddlPage.DataBind();
                ddlPage.SelectedValue = "10";
                lblPageInfo.Text = "Page 1 of " + gvAdjustorDetails.PageCount.ToString();
            }
        }
    }

    private void DisplayEmployeeInfo(string claimNO)
    {
        m_objClaimReservesInfo = new RIMS_Base.Biz.CCheckWriting();
        lstClaimReservesInfo = new List<RIMS_Base.CCheckWriting>();
        lstClaimReservesInfo = m_objClaimReservesInfo.GetClaimInfoByClaimNo(claimNO);
        lblClaimNum.Text = lstClaimReservesInfo[0].Claim_Number.ToString();
        ViewState["TableName"] = lstClaimReservesInfo[0].TableName.ToString();
        ViewState["TableFK"] = lstClaimReservesInfo[0].TableFK.ToString();
        if (lstClaimReservesInfo[0].Employee.ToUpper() == "Y")
            rbtnEmployee.Items[0].Selected = true;
        else if (lstClaimReservesInfo[0].Employee.ToUpper() == "N")
            rbtnEmployee.Items[1].Selected = true;
        lblLName.Text = lstClaimReservesInfo[0].LastName.ToString().Replace("''", "'");
        lblFName.Text = lstClaimReservesInfo[0].FirstName.ToString().Replace("''", "'");
        lblMName.Text = lstClaimReservesInfo[0].MiddleName.ToString().Replace("''", "'");
        lblDateIncident.Text = lstClaimReservesInfo[0].IncidentDate.ToString();

        // --- For the form Page
        if (lstClaimReservesInfo[0].Employee.ToUpper() == "Y")
            lblEmployee.Text = "Yes";
        else if (lstClaimReservesInfo[0].Employee.ToUpper() == "N")
            lblEmployee.Text = "No";
        lblLastName.Text = lstClaimReservesInfo[0].LastName.ToString().Replace("''", "'");
        lblFirstName.Text = lstClaimReservesInfo[0].FirstName.ToString().Replace("''", "'");
        lblMiddleName.Text = lstClaimReservesInfo[0].MiddleName.ToString().Replace("''", "'");
        lblDOIncident.Text = lstClaimReservesInfo[0].IncidentDate.ToString();
        lblClaimNo.Text = lstClaimReservesInfo[0].Claim_Number.ToString();


        // --- For the View Page.
        if (lstClaimReservesInfo[0].Employee == "Y")
            lblVEmployee.Text = "Yes";
        else if (lstClaimReservesInfo[0].Employee == "N")
            lblVEmployee.Text = "No";
        lblVLastName.Text = lstClaimReservesInfo[0].LastName.ToString().Replace("''", "'");
        lblVFirstName.Text = lstClaimReservesInfo[0].FirstName.ToString().Replace("''", "'");
        lblVMiddleMName.Text = lstClaimReservesInfo[0].MiddleName.ToString().Replace("''", "'");
        lblVDOInci.Text = lstClaimReservesInfo[0].IncidentDate.ToString();
        lblVClaimNo.Text = lstClaimReservesInfo[0].Claim_Number.ToString();
    }

    protected void btnNextStep_Click(object sender, EventArgs e)
    {
        Response.Redirect("Settlement.aspx");
    }

    #region Search Process
    protected void btnSaveView_Click(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gvAdjustorDetails.DataSource = BindAdjustorDetails();
        gvAdjustorDetails.DataBind();

        lblPageInfo.Text = "Page 1 of " + gvAdjustorDetails.PageCount.ToString();
        divfirst.Style["display"] = "none";
        divSearch.Style["display"] = "block";
        divthird.Style["display"] = "block";
        divbtn.Style["display"] = "block";
        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";

    }
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gvAdjustorDetails.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
            gvAdjustorDetails.DataSource = BindAdjustorDetails();
            gvAdjustorDetails.DataBind();
            lblPageInfo.Text = "Page 1 of " + gvAdjustorDetails.PageCount.ToString();
            txtPageNo.Text = "1";

            divfirst.Style["display"] = "none";
            divSearch.Style["display"] = "block";
            divthird.Style["display"] = "block";
            divbtn.Style["display"] = "block";
            second.CssClass = "left_menu_active";
            first.CssClass = "left_menu";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtPageNo.Text.ToString().Trim() == string.Empty || Convert.ToInt32(txtPageNo.Text) < 1)
            {
                gvAdjustorDetails.PageIndex = 0;
                txtPageNo.Text = "1";
            }
            else if (Convert.ToInt32(txtPageNo.Text) > gvAdjustorDetails.PageCount)
            {
                gvAdjustorDetails.PageIndex = gvAdjustorDetails.PageCount;
                txtPageNo.Text = gvAdjustorDetails.PageCount.ToString();
            }
            else
            {
                gvAdjustorDetails.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;
            }
            lblPageInfo.Text = "Page " + txtPageNo.Text.ToString() + " of " + gvAdjustorDetails.PageCount.ToString();
            gvAdjustorDetails.DataSource = BindAdjustorDetails();
            gvAdjustorDetails.DataBind();

            divfirst.Style["display"] = "none";
            divSearch.Style["display"] = "block";
            divthird.Style["display"] = "block";
            divbtn.Style["display"] = "block";
            first.Style["CssClass"] = "left_menu";
            second.Style["CssClass"] = "left_menu_active";
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvAdjustorDetails.PageIndex <= gvAdjustorDetails.PageCount)
            {
                if (gvAdjustorDetails.PageIndex != 0)
                {
                    gvAdjustorDetails.PageIndex = gvAdjustorDetails.PageIndex - 1;
                    GeneralSorting();
                    //gvAdjustorDetails.DataSource=BindAdjustorDetails();
                    //gvAdjustorDetails.DataBind();
                    lblPageInfo.Text = "Page " + Convert.ToString(gvAdjustorDetails.PageIndex + 1) + " of " + gvAdjustorDetails.PageCount.ToString();
                }
            }

            divSearch.Style["display"] = "block";
            divfirst.Style["display"] = "none";
            divthird.Style["display"] = "block";
            divbtn.Style["display"] = "block";
            second.CssClass = "left_menu_active";
            first.CssClass = "left_menu";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvAdjustorDetails.PageIndex <= gvAdjustorDetails.PageCount)
            {
                gvAdjustorDetails.PageIndex = gvAdjustorDetails.PageIndex + 1;
                GeneralSorting();
                //gvAdjustorDetails.DataSource=BindAdjustorDetails();
                //gvAdjustorDetails.DataBind();
                lblPageInfo.Text = "Page " + Convert.ToString(gvAdjustorDetails.PageIndex + 1) + " of " + gvAdjustorDetails.PageCount.ToString();

            }

            divSearch.Style["display"] = "block";
            divfirst.Style["display"] = "none";
            divthird.Style["display"] = "block";
            divbtn.Style["display"] = "block";
            second.CssClass = "left_menu_active";
            first.CssClass = "left_menu";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region Grid's Functionality

    protected List<RIMS_Base.CAdjustor> BindAdjustorDetails()
    {
        lstAdjustor = new List<RIMS_Base.CAdjustor>();
        objAdjustor = new RIMS_Base.Biz.CAdjustor();

        try
        {
            if (txtSearch.Text != String.Empty)
            {
                lstAdjustor = objAdjustor.SearchAdjustorData(ddlSearch.SelectedValue, txtSearch.Text.Trim().Replace("'", "''"), Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString());
            }
            else
            {
                lstAdjustor = objAdjustor.SearchAdjustorData(null, null, Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString());
            }

            if (lstAdjustor.Count <= 0)
                btnDelete.Visible = false;
            else
                btnDelete.Visible = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        objAdjustor = null;
        return lstAdjustor;
    }
    protected void Bindfv(FormViewMode fvmode)
    {
        if (FormViewMode.ReadOnly == fvmode)
        {
            fvAdjustorDetail.ChangeMode(FormViewMode.ReadOnly);
            //btnRemove.Style["display"] = "none";
            btnRemove.Visible = false;
            btnMail.Visible = false;
        }
        else if (FormViewMode.Edit == fvmode)
        {
            fvAdjustorDetail.ChangeMode(FormViewMode.Edit);
        }
        else if (FormViewMode.Insert == fvmode)
        {
            fvAdjustorDetail.ChangeMode(FormViewMode.Insert);
        }

        if (fvmode != FormViewMode.Insert)
        {
            objAdjustor = new RIMS_Base.Biz.CAdjustor();
            lstAdjustor = new List<RIMS_Base.CAdjustor>();
            lstAdjustor = objAdjustor.GetAdjustorByID(AdjustorID);
            fvAdjustorDetail.DataSource = lstAdjustor;
        }
        fvAdjustorDetail.DataBind();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            objAdjustor = new RIMS_Base.Biz.CAdjustor();
            Adjustor_RetVal = objAdjustor.DeleteAdjustor(Request.Form["chkItem"].ToString());
            if (Adjustor_RetVal <= 0)
            {
                mvAdjustorDetails.ActiveViewIndex = 0;
                gvAdjustorDetails.DataSource = BindAdjustorDetails();
                gvAdjustorDetails.DataBind();
                divfirst.Style["display"] = "none";
                divSearch.Style["display"] = "block";
                divthird.Style["display"] = "block";
                divbtn.Style["display"] = "block";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        mvAdjustorDetails.ActiveViewIndex = 1;
        Bindfv(FormViewMode.Insert);
        // --- This is the Name of the Login User.
        ((TextBox)fvAdjustorDetail.FindControl("txtAuthor")).Text = "UserName";

        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";
        divfirst.Style["display"] = "none";
        divSearch.Style["display"] = "none";
        divbtn.Style["display"] = "none";
        divthird.Style["display"] = "block";
        ViewState["Adjustor_ID"] = "";
        dvAttachDetails.Style["display"] = "none";
    }
    protected void gvAdjustorDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";
        divfirst.Style["display"] = "none";
        divSearch.Style["display"] = "none";
        divbtn.Style["display"] = "none";
        divthird.Style["display"] = "block";

        //btnRemove.Style["display"] = "block";

        try
        {
            if (e.CommandName != "Sort")
            {
                mvAdjustorDetails.ActiveViewIndex = 1;
                AdjustorID = Convert.ToInt32(e.CommandArgument.ToString());
            }

            if (e.CommandName == "EditItem")
            {
                Bindfv(FormViewMode.Edit);
                btnRemove.Visible = true;
                btnMail.Visible = true;

            }
            else if (e.CommandName == "View")
            {
                Bindfv(FormViewMode.ReadOnly);
                //btnRemove.Style["display"] = "none";
                btnRemove.Visible = false;
                btnMail.Visible = false;
            }
            gvAttachmentDetails.DataSource = BindAttachmentDetails();
            gvAttachmentDetails.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvAdjustorDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void gvAdjustorDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        lstAdjustor = new List<RIMS_Base.CAdjustor>();
        objAdjustor = new RIMS_Base.Biz.CAdjustor();

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
        ViewState["SortExp"] = e.SortExpression;

        lstAdjustor = BindAdjustorDetails();// objAdjustor.SearchAdjustorData(null, null, Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString());

        if (ViewState["SortExp"] != null)
            lstAdjustor.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CAdjustor>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
        gvAdjustorDetails.DataSource = lstAdjustor;
        gvAdjustorDetails.DataBind();

        divSearch.Style["display"] = "block";
        divfirst.Style["display"] = "none";
        divthird.Style["display"] = "block";
        divbtn.Style["display"] = "block";
        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";
    }

    #endregion

    #region Insert Update

    private void InsertUpdate()
    {
        objAdjustor = new RIMS_Base.Biz.CAdjustor();
        if (fvAdjustorDetail.CurrentMode == FormViewMode.Edit)
        {
            AdjustorID = Convert.ToInt32(((Label)fvAdjustorDetail.FindControl("lblAdjustorID")).Text);
            objAdjustor.PK_Adjustor_Notes_ID = AdjustorID;
            // --- This is the Name of the Login User.
            objAdjustor.Updated_By = "UserName";
            objAdjustor.Update_Date = DateTime.Now;
            ViewState["Adjustor_ID"] = AdjustorID;
        }
        else if (ViewState["Adjustor_ID"].ToString() != "" && fvAdjustorDetail.CurrentMode == FormViewMode.Insert)
        {
            objAdjustor.PK_Adjustor_Notes_ID = Convert.ToInt32(ViewState["Adjustor_ID"].ToString());
        }
        objAdjustor.Table_Name = ViewState["TableName"].ToString();
        objAdjustor.FK_Table_Name = Convert.ToDecimal(ViewState["TableFK"].ToString());
        if (((TextBox)fvAdjustorDetail.FindControl("txtDOActivity")).Text != String.Empty)
            objAdjustor.Activity_Date = Convert.ToDateTime(((TextBox)fvAdjustorDetail.FindControl("txtDOActivity")).Text);
        if (((TextBox)fvAdjustorDetail.FindControl("txtDate")).Text != String.Empty)
            objAdjustor.Date_Of_Note = Convert.ToDateTime(((TextBox)fvAdjustorDetail.FindControl("txtDate")).Text);
        if (Request.Form[((TextBox)fvAdjustorDetail.FindControl("txtAuthor")).UniqueID].ToString() != String.Empty)
            objAdjustor.Author_Of_Note = Request.Form[((TextBox)fvAdjustorDetail.FindControl("txtAuthor")).UniqueID].ToString();
        if (((DropDownList)fvAdjustorDetail.FindControl("dwNoteType")).Text != String.Empty)
            objAdjustor.Note_Type = ((DropDownList)fvAdjustorDetail.FindControl("dwNoteType")).SelectedItem.Text;
        if (((TextBox)fvAdjustorDetail.FindControl("txtLastUpdateBy")).Text != String.Empty)
            objAdjustor.Update_By = ((TextBox)fvAdjustorDetail.FindControl("txtLastUpdateBy")).Text;
        if (((TextBox)fvAdjustorDetail.FindControl("txtNote")).Text != String.Empty)
            objAdjustor.Notes = ((TextBox)fvAdjustorDetail.FindControl("txtNote")).Text;

        Adjustor_RetVal = objAdjustor.InsertUpdateAdjustor(objAdjustor);
        ViewState["Adjustor_ID"] = Adjustor_RetVal;
    }

    #endregion

    #region FormView's Functionality

    private List<RIMS_Base.CGeneral> GetNoteType()
    {
        List<RIMS_Base.CGeneral> lstGenereal = new List<RIMS_Base.CGeneral>();
        RIMS_Base.Biz.CGeneral objGeneral = new RIMS_Base.Biz.CGeneral();
        try
        {
            //objGeneral.
            return lstGenereal;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objGeneral = null;
        }
    }
    protected void fvAdjustorDetail_DataBound(object sender, EventArgs e)
    {
        try
        {
            List<RIMS_Base.CGeneral> lstGenereal = new List<RIMS_Base.CGeneral>();
            RIMS_Base.Biz.CGeneral objGeneral = new RIMS_Base.Biz.CGeneral();

            if (fvAdjustorDetail.CurrentMode != FormViewMode.ReadOnly)
            {
                ((DropDownList)fvAdjustorDetail.FindControl("ddlAttachType")).DataSource = objGeneral.GetAttachamentType();
                ((DropDownList)fvAdjustorDetail.FindControl("ddlAttachType")).DataTextField = "FLD_Desc";
                ((DropDownList)fvAdjustorDetail.FindControl("ddlAttachType")).DataValueField = "FLD_Code";
                ((DropDownList)fvAdjustorDetail.FindControl("ddlAttachType")).DataBind();
                ((DropDownList)fvAdjustorDetail.FindControl("ddlAttachType")).Items.Insert(0, "--Select Attachment Type--");


                ((DropDownList)fvAdjustorDetail.FindControl("dwNoteType")).DataSource = objGeneral.GetAdjustorNoteType();
                ((DropDownList)fvAdjustorDetail.FindControl("dwNoteType")).DataTextField = "Adjustor_Note_Type_FLD_Desc";
                ((DropDownList)fvAdjustorDetail.FindControl("dwNoteType")).DataValueField = "Pk_Adjustor_Note_Type_ID";
                ((DropDownList)fvAdjustorDetail.FindControl("dwNoteType")).DataBind();
                ((DropDownList)fvAdjustorDetail.FindControl("dwNoteType")).Items.Insert(0, "--Select Note Type--");

            }

            if (fvAdjustorDetail.CurrentMode == FormViewMode.Edit)
            {
                //((DropDownList)fvAdjustorDetail.FindControl("dwNoteType")).SelectedIndex  = Convert.ToInt32(((DropDownList)fvAdjustorDetail.FindControl("dwNoteType")).Items.FindByText(lstAdjustor[0].Note_Type).Value);
                ((DropDownList)fvAdjustorDetail.FindControl("dwNoteType")).SelectedValue = ((DropDownList)fvAdjustorDetail.FindControl("dwNoteType")).Items.FindByText(lstAdjustor[0].Note_Type).Value;

                // --- This is the Name of the Login User.
                ((TextBox)fvAdjustorDetail.FindControl("txtAuthor")).Text = "UserName";
            }
            if (fvAdjustorDetail.CurrentMode == FormViewMode.ReadOnly)
            {
                gvAttachmentDetails.Columns[0].Visible = false;
            }
            else
            {
                gvAttachmentDetails.Columns[0].Visible = true;
            }


        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        InsertUpdate();
        gvAdjustorDetails.DataSource = BindAdjustorDetails();
        gvAdjustorDetails.DataBind();
        mvAdjustorDetails.ActiveViewIndex = 0;
        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";
        divfirst.Style["display"] = "none";
        divSearch.Style["display"] = "block";
        divbtn.Style["display"] = "block";
        divthird.Style["display"] = "block";
        ViewState["Adjustor_ID"] = "";
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        mvAdjustorDetails.ActiveViewIndex = 0;
        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";
        divfirst.Style["display"] = "none";
        divSearch.Style["display"] = "block";
        divbtn.Style["display"] = "block";
        divthird.Style["display"] = "block";
        ViewState["Adjustor_ID"] = "";

    }

    #endregion

    #region Attachment

    protected void gvAttachmentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("imgbtnDwnld")).Attributes.Add("onclick", "javascript:return openWindow('" + m_strGlobalPath + ((ImageButton)e.Row.FindControl("imgbtnDwnld")).CommandArgument.ToString() + "');");
                //((ImageButton)e.Row.FindControl("imgbtnMail")).Attributes.Add("onclick", "javascript:return openMailWindow('../ErimsMail.aspx?AttMod=Worker_Comp_Adjustor_Notes&AttName=" + ((ImageButton)e.Row.FindControl("imgbtnMail")).CommandArgument.ToString() + "');");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void UploadDocuments()
    {
        try
        {
            m_strPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"]);

            if (!(Directory.Exists(m_strPath + "\\" + m_strFolderName)))
            {
                Directory.CreateDirectory(m_strPath + "\\" + m_strFolderName);
            }
            // m_strFileName = GetCustomFileName() + uplCommon.FileName.ToString();
            m_strFileName = GetCustomFileName() + ((FileUpload)fvAdjustorDetail.FindControl("uplCommon")).FileName.ToString();
            m_strPath = m_strPath + "\\" + m_strFolderName + "\\" + m_strFileName;
            //uplCommon.SaveAs(m_strPath);
            ((FileUpload)fvAdjustorDetail.FindControl("uplCommon")).SaveAs(m_strPath);

        }
        catch (Exception ex)
        {
            //Log.Append("Error in UploadPhotoImages Method of ConditionAssessment's PhotoGraphs:" + ex.Message);
            //Common.reportError("Error in UploadPhotoImages Method of ConditionAssessment's PhotoGraphs:", ex.Message);
            throw ex;
        }
    }

    private string GetCustomFileName()
    {
        try
        {
            m_strCustomFileName = System.DateTime.Now.ToString("MMddyyhhmmss");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return m_strCustomFileName;
    }
    private int AddAttachment()
    {
        try
        {
            // InsertUpdateData();
            UploadDocuments();
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            m_objAttachment.Attachment_Table = "Adjustor_Notes";
            m_objAttachment.Foreign_Key = Convert.ToInt32(ViewState["Adjustor_ID"].ToString());
            //m_objAttachment.FK_Attachment_Type = Convert.ToInt32(ddlAttachType.SelectedValue);
            m_objAttachment.FK_Attachment_Type = Convert.ToInt32(((DropDownList)fvAdjustorDetail.FindControl("ddlAttachType")).SelectedValue);
            //m_objAttachment.Attachment_Description = txtDescription.Text.Replace("'", "''");
            m_objAttachment.Attachment_Description = ((TextBox)fvAdjustorDetail.FindControl("txtDescription")).Text.Replace("'", "''");
            m_objAttachment.Attachment_Name = m_strFileName;
            m_objAttachment.Updated_By = "1";
            m_objAttachment.Update_Date = System.DateTime.Now.Date;
            Attach_Retval = m_objAttachment.InsertUpdateAttachment(m_objAttachment);


        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Attach_Retval;
    }
    protected void btnAddAttachment_Click(object sender, EventArgs e)
    {
        dvAttachDetails.Style["display"] = "block";
        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";
        divfirst.Style["display"] = "none";
        divSearch.Style["display"] = "none";
        divbtn.Style["display"] = "none";
        divthird.Style["display"] = "block";
        //btnRemove.Style["display"] = "block";
        btnRemove.Visible = true;
        btnMail.Visible = true;
        InsertUpdate();
        AddAttachment();
        if (Attach_Retval > 0)
        {
            gvAttachmentDetails.DataSource = BindAttachmentDetails();
            gvAttachmentDetails.DataBind();
        }
        ((TextBox)fvAdjustorDetail.FindControl("txtDescription")).Text = "";
        ((DropDownList)fvAdjustorDetail.FindControl("ddlAttachType")).SelectedIndex = 0;

    }
    private List<RIMS_Base.CAttachment> BindAttachmentDetails()
    {
        try
        {
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            lstAttachment = new List<RIMS_Base.CAttachment>();
            if (ViewState["Adjustor_ID"] != null && ViewState["Adjustor_ID"].ToString() != "")
            {
                lstAttachment = m_objAttachment.GetAll(0, Convert.ToInt32(ViewState["Adjustor_ID"].ToString()), "Adjustor_Notes");

            }
            else
            {
                lstAttachment = m_objAttachment.GetAll(0, AdjustorID, "Adjustor_Notes");
            }
            if (lstAttachment.Count > 0)
            {
                dvAttachDetails.Style["display"] = "block";

                if (fvAdjustorDetail.CurrentMode != FormViewMode.ReadOnly)
                {
                    btnRemove.Visible = true;
                    btnMail.Visible = true;
                }
                //btnViewMail.Visible = true;
            }
            else
            {
                btnRemove.Visible = false;
                btnMail.Visible = false;
            }
            return lstAttachment;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            Attach_Retval = m_objAttachment.DeleteAttachment(Request.Form["chkItem"].ToString());
            if (Attach_Retval <= 0)
            {

                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();
                if (lstAttachment.Count > 0)
                {
                    btnRemove.Visible = true;
                    //btnRemove.Style["display"] = "block";                    
                    btnMail.Visible = true;
                }
                else
                {
                    btnRemove.Visible = false;
                    //btnRemove.Style["display"] = "none";
                    btnMail.Visible = false;
                }
            }
            dvAttachDetails.Visible = true;

            dvAttachDetails.Style["display"] = "block";
            second.CssClass = "left_menu_active";
            first.CssClass = "left_menu";
            divfirst.Style["display"] = "none";
            divSearch.Style["display"] = "none";
            divbtn.Style["display"] = "none";
            divthird.Style["display"] = "block";

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    protected void btnViewNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("Settlement.aspx");
    }
    private void ViewAllFromSearchGrid()
    {
        divbtn.Style["display"] = "none";
        leftDiv.Style["display"] = "none";
        mainContent.Style["display"] = "none";
        divView.Style["display"] = "block";
        txtSearch.Text = "";
        btnViewBack.Visible = false;
        //btnViewNext.Visible = true;

        try
        {
            gvViewAll.DataSource = BindAdjustorDetails();
            gvViewAll.DataBind();

            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            lstAttachment = new List<RIMS_Base.CAttachment>();

            if (lstAdjustor.Count > 0)
            {
                lstAttachment = m_objAttachment.GetAllAttachmentGroup(AttachmentID, "Adjustor_Notes");
            }
            else
            {
                lstAttachment = m_objAttachment.GetAllAttachmentGroup("0", "Adjustor_Notes");
            }

            gvViewAttachment.DataSource = lstAttachment;
            gvViewAttachment.DataBind();
            gvViewAttachment.Columns[0].Visible = false;
            //if (lstAttachment.Count > 0)
            //    btnViewMail.Visible = true;
            //else
            //    btnViewMail.Visible = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        divbtn.Style["display"] = "none";
        leftDiv.Style["display"] = "none";
        mainContent.Style["display"] = "none";
        divView.Style["display"] = "block";
        txtSearch.Text = "";

        try
        {
            gvViewAll.DataSource = BindAdjustorDetails();
            gvViewAll.DataBind();

            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            lstAttachment = new List<RIMS_Base.CAttachment>();

            if (lstAdjustor.Count > 0)
                lstAttachment = m_objAttachment.GetAllAttachmentGroup(AttachmentID, "Adjustor_Notes");
            else
                lstAttachment = m_objAttachment.GetAllAttachmentGroup("0", "Adjustor_Notes");

            gvViewAttachment.DataSource = lstAttachment;
            gvViewAttachment.DataBind();

            //if (lstAttachment.Count > 0)
            //    btnViewMail.Visible = true;
            //else
            //    btnViewMail.Visible = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void gvViewAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (AttachmentID == "")
                AttachmentID += ((Label)e.Row.FindControl("lblAdjustorID")).Text.ToString();
            else
                AttachmentID += "," + ((Label)e.Row.FindControl("lblAdjustorID")).Text.ToString();
        }
    }
    protected void btnViewBack_Click(object sender, EventArgs e)
    {
        divbtn.Style["display"] = "block";
        leftDiv.Style["display"] = "block";
        mainContent.Style["display"] = "block";
        divView.Style["display"] = "none";
    }
    protected void second_Click(object sender, EventArgs e)
    {
        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";
        mvAdjustorDetails.ActiveViewIndex = 0;

        dvAttachDetails.Style["display"] = "none";
        divfirst.Style["display"] = "none";
        divSearch.Style["display"] = "block";
        divbtn.Style["display"] = "block";
        divthird.Style["display"] = "block";

    }
    protected void first_Click(object sender, EventArgs e)
    {
        second.CssClass = "left_menu";
        first.CssClass = "left_menu_active";
        mvAdjustorDetails.ActiveViewIndex = 0;

        dvAttachDetails.Style["display"] = "none";
        divfirst.Style["display"] = "block";
        divSearch.Style["display"] = "none";
        divbtn.Style["display"] = "block";
        divthird.Style["display"] = "none";

    }

    private void GeneralSorting()
    {
        try
        {
            lstAdjustor = new List<RIMS_Base.CAdjustor>();
            lstAdjustor = BindAdjustorDetails();
            if (ViewState["SortExp"] != null && ViewState["sortDirection"] != null)
                lstAdjustor.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CAdjustor>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvAdjustorDetails.DataSource = lstAdjustor;
            gvAdjustorDetails.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

}
