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
using RIMS_Base.Biz;
using System.IO;

public partial class WorkerCompensation_subrogation : System.Web.UI.Page
{
    #region Variable
    public RIMS_Base.Biz.cSubrogation objSubrogation;
    List<RIMS_Base.cSubrogation> lstSubrogation;
    int Subrogation_RetVal = 0;
    int SubrogationID = 0;

    public RIMS_Base.Biz.CCheckWriting m_objClaimReservesInfo;
    List<RIMS_Base.CCheckWriting> lstClaimReservesInfo = null;

    // -- Attachment
    public string m_strCustomFileName = string.Empty;
    public string m_strFileName = string.Empty;
    public string m_strGlobalPath = string.Empty;
    public string m_strPath = string.Empty;
    public string m_strFolderName = "Worker_Comp_Subrogation";
    public RIMS_Base.Biz.CAttachment m_objAttachment;
    List<RIMS_Base.CAttachment> lstAttachment = null;
    int Attach_Retval = -1;
    string AttachmentID = "";

    string strSortExp = String.Empty;

    public RIMS_Base.Biz.CRolePermission m_objRightDetails;
    List<RIMS_Base.CRolePermission> lstRightDetails = null;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {        
            m_strGlobalPath = Page.ResolveUrl(ConfigurationManager.AppSettings["UploadPath"] + "/Worker_Comp_Subrogation/");

            if (!IsPostBack)
            {
                ViewState.Clear();
                hdnTemp.Value = "";
                if (SetUserRights() == true)
                {
                    btnDelete.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvDiaryDetails','Delete');");
                    btnRemove.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvAttachmentDetails','Delete');");

                    if (Session["WorkerCompID"] != null && Session["WorkerCompID"].ToString() != String.Empty)
                    {

                        RIMS_Base.Biz.CWorkersComp objWorkerComp = new RIMS_Base.Biz.CWorkersComp();
                        List<RIMS_Base.CWorkersComp> lstWorkerComp = new List<RIMS_Base.CWorkersComp>();
                        try
                        {
                            lstWorkerComp = objWorkerComp.Get_Worker_CompensationByID(Convert.ToInt32(Session["WorkerCompID"].ToString()));
                            string Claim_No = lstWorkerComp[0].Claim_Number;
                            DisplayEmployeeInfo(Claim_No);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            objWorkerComp = null;
                            lstWorkerComp = null;
                        }

                    }
                    mvSubrogation.ActiveViewIndex = 0;

                    //ViewAllFromSearchGrid();
                    if (Session["ViewAll"] != null && Session["ViewAll"].ToString() != String.Empty)
                        ViewAllFromSearchGrid();
                    // --- Commente Due to PAGE PRE RENDER.
                    //else
                    //{
                    //    gvSubrogation.DataSource = BindSubrogationDetails();
                    //    gvSubrogation.DataBind();
                    //}

                    gvSubrogation.PageSize = 10;
                    ddlPage.DataBind();
                    ddlPage.SelectedValue = "10";
                    lblPageInfo.Text = "Page 1 of " + gvSubrogation.PageCount.ToString();

                }
            }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (Session["ViewAll"] == null)
        {
            GeneralSorting();
        }
    }
    private void BindCombos()
    {

    }
    private void DisplayEmployeeInfo(string claimNO)
    {
        m_objClaimReservesInfo = new RIMS_Base.Biz.CCheckWriting();
        lstClaimReservesInfo = new List<RIMS_Base.CCheckWriting>();
        lstClaimReservesInfo = m_objClaimReservesInfo.GetWorkerCompClaimInfoByClaimNo(claimNO);
        lblClaimNum.Text = lstClaimReservesInfo[0].Claim_Number.ToString();
        ViewState["TableName"] = lstClaimReservesInfo[0].TableName.ToString();
        ViewState["TableFK"] = lstClaimReservesInfo[0].TableFK.ToString();

        //if (lstClaimReservesInfo[0].Employee.ToUpper() == "Y")
        //    rbtnEmployee.Items[0].Selected = true;
        //else if (lstClaimReservesInfo[0].Employee.ToUpper() == "N")
        //    rbtnEmployee.Items[1].Selected = true;

        rbtnEmployee.Items[0].Selected = true;

        lblLName.Text = lstClaimReservesInfo[0].LastName.ToString().Replace("''", "'");
        lblFName.Text = lstClaimReservesInfo[0].FirstName.ToString().Replace("''", "'");
        lblMName.Text = lstClaimReservesInfo[0].MiddleName.ToString().Replace("''", "'");
        lblDateIncident.Text = lstClaimReservesInfo[0].IncidentDate.ToString();


        // --- For the View Page.
        //if (lstClaimReservesInfo[0].Employee.ToUpper() == "Y")
        //    lblEmployee.Text = "Yes";
        //else if (lstClaimReservesInfo[0].Employee.ToUpper() == "N")
        //    lblEmployee.Text = "No";

        lblEmployee.Text = "Yes";

        lblLastName.Text = lstClaimReservesInfo[0].LastName.ToString().Replace("''", "'");
        lblFirstName.Text = lstClaimReservesInfo[0].FirstName.ToString().Replace("''", "'");
        lblMiddleName.Text = lstClaimReservesInfo[0].MiddleName.ToString().Replace("''", "'");
        lblDOIncident.Text = lstClaimReservesInfo[0].IncidentDate.ToString();
        lblClaimNo.Text = lstClaimReservesInfo[0].Claim_Number.ToString();

        // --- For View All for the Main Search Grid
        //if (lstClaimReservesInfo[0].Employee.ToUpper() == "Y")
        //    lblVEmployee.Text = "Yes";
        //else if (lstClaimReservesInfo[0].Employee.ToUpper() == "N")
        //    lblVEmployee.Text = "No";


        lblVEmployee.Text = "Yes";

        lblVLastName.Text = lstClaimReservesInfo[0].LastName.ToString().Replace("''", "'");
        lblVFirstName.Text = lstClaimReservesInfo[0].FirstName.ToString().Replace("''", "'");
        lblVMiddleMName.Text = lstClaimReservesInfo[0].MiddleName.ToString().Replace("''", "'");
        lblVDOInci.Text = lstClaimReservesInfo[0].IncidentDate.ToString();
        lblVClaimNo.Text = lstClaimReservesInfo[0].Claim_Number.ToString();
       
    }
   
    protected void btnAddSubrogation_Click(object sender, EventArgs e)
    {
        mvSubrogation.ActiveViewIndex = 1;
        //setVisible();
        divbtn.Visible = false;
    }
    
    protected void btnNextStep_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/WorkerCompensation/CheckRegister.aspx");
        Response.Redirect("../Workers_Compensation/SubrogationDetail.aspx");

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        mvSubrogation.ActiveViewIndex = 0;
        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";
        divfirst.Style["display"] = "none";
        divSearch.Style["display"] = "block";
        divbtn.Style["display"] = "block";
        divthird.Style["display"] = "block";

        // --- hide javascript error
        hdnTemp.Value = "";

    }
    protected void gvSubrogationHistory_DataBound(object sender, EventArgs e)
    {
        
    }
  
    protected void Button2_Click(object sender, EventArgs e)
    {
        //mvSubrogation.ActiveViewIndex = 1;
        //setVisible();
        divbtn.Visible = true;
    }

    #region Attachment

    protected void gvAttachmentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("imgbtnDwnld")).Attributes.Add("onclick", "javascript:return openWindow('" + m_strGlobalPath + ((ImageButton)e.Row.FindControl("imgbtnDwnld")).CommandArgument.ToString() + "');");
                //((ImageButton)e.Row.FindControl("imgbtnMail")).Attributes.Add("onclick", "javascript:return openMailWindow('../ErimsMail.aspx?AttMod=Worker_Comp_Subrogation&AttName=" + ((ImageButton)e.Row.FindControl("imgbtnMail")).CommandArgument.ToString() + "');");
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
            m_strFileName = GetCustomFileName() + ((FileUpload)fvSubrogation.FindControl("uplCommon")).FileName.ToString();
            m_strPath = m_strPath + "\\" + m_strFolderName + "\\" + m_strFileName;
            //uplCommon.SaveAs(m_strPath);
            ((FileUpload)fvSubrogation.FindControl("uplCommon")).SaveAs(m_strPath);

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
            UploadDocuments();
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            m_objAttachment.Attachment_Table = "Subrogation";
            m_objAttachment.Foreign_Key = Convert.ToInt32(ViewState["Subrogation_ID"].ToString());
            //m_objAttachment.FK_Attachment_Type = Convert.ToInt32(ddlAttachType.SelectedValue);
            m_objAttachment.FK_Attachment_Type = Convert.ToInt32(((DropDownList)fvSubrogation.FindControl("ddlAttachType")).SelectedValue);
            //m_objAttachment.Attachment_Description = txtDescription.Text.Replace("'", "''");
            m_objAttachment.Attachment_Description = ((TextBox)fvSubrogation.FindControl("txtAttachDesc")).Text.Replace("'", "''");
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
        btnRemove.Visible = true;
        btnMail.Visible = true;
        InsertUpdate();
        AddAttachment();
        if (Attach_Retval > 0)
        {           
            gvAttachmentDetails.DataSource = BindAttachmentDetails();
            gvAttachmentDetails.DataBind();
        }

        ((TextBox)fvSubrogation.FindControl("txtAttachDesc")).Text = "";
        ((DropDownList)fvSubrogation.FindControl("ddlAttachType")).SelectedIndex = 1;
        
    }
    private List<RIMS_Base.CAttachment> BindAttachmentDetails()
    {
        try
        {
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            lstAttachment = new List<RIMS_Base.CAttachment>();
            if (ViewState["Subrogation_ID"] != null && ViewState["Subrogation_ID"].ToString() != "")
            {
                lstAttachment = m_objAttachment.GetAll(0, Convert.ToInt32(ViewState["Subrogation_ID"].ToString()), "Subrogation");

            }
            else
            {
                lstAttachment = m_objAttachment.GetAll(0, SubrogationID, "Subrogation");
            }
            //if (lstAttachment.Count > 0)            
            //    dvAttachDetails.Style["display"] = "block";

            if (lstAttachment.Count > 0)
            {
                dvAttachDetails.Style["display"] = "block";
                btnRemove.Visible = true;
                btnMail.Visible = true;
                //btnViewMail.Visible = true;
            }
            else
            {
                btnRemove.Visible = false;
                btnMail.Visible = false;
                //btnViewMail.Visible = false;
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
                    btnMail.Visible = true;
                }
                else
                {
                    btnRemove.Visible = false;
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

    #region Grid's Functionality
    protected void gvSubrogation_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (String.Empty != strSortExp)
            {
                AddSortImage(e.Row);
            }
        }
    }
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvSubrogation.Columns)
        {
            if (field.SortExpression.ToString() == ViewState["SortExp"].ToString())
            {
                nRet = gvSubrogation.Columns.IndexOf(field);
            }
        }
        return nRet;
    }
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

    protected List<RIMS_Base.cSubrogation> BindSubrogationDetails()
    {
        lstSubrogation = new List<RIMS_Base.cSubrogation>();
        objSubrogation = new RIMS_Base.Biz.cSubrogation();

        try
        {
            if(ViewState["TableFK"] != null && ViewState["TableFK"].ToString() != String.Empty)
                lstSubrogation = objSubrogation.SearchSubrogationData(null, null, Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString());
            // --- There is no search facility that's y commented.
            //if (txtSearch.Text != String.Empty)
            //{
            //    lstAdjustor = objAdjustor.SearchAdjustorData(ddlSearch.SelectedValue, txtSearch.Text.Trim().Replace("'", "''"), Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString());
            //}
            //else
            //{
            //    lstAdjustor = objAdjustor.SearchAdjustorData(null, null, Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString());
            //}

            if (lstSubrogation.Count <= 0)
                btnDelete.Visible = false;
            else
                btnDelete.Visible = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        objSubrogation = null;
        return lstSubrogation;

    }
    protected void Bindfv(FormViewMode fvmode)
    {
        if (FormViewMode.ReadOnly == fvmode)
        {
            fvSubrogation.ChangeMode(FormViewMode.ReadOnly);
        }
        else if (FormViewMode.Edit == fvmode)
        {
            fvSubrogation.ChangeMode(FormViewMode.Edit);
        }
        else if (FormViewMode.Insert == fvmode)
        {
            fvSubrogation.ChangeMode(FormViewMode.Insert);
        }

        if (fvmode != FormViewMode.Insert)
        {
            objSubrogation = new RIMS_Base.Biz.cSubrogation();
            lstSubrogation = new List<RIMS_Base.cSubrogation>();
            lstSubrogation = objSubrogation.GetSubrogationByID(SubrogationID);
            fvSubrogation.DataSource = lstSubrogation;
        }
        fvSubrogation.DataBind();

        // -- Display Dynamic Labels
        try
        {
            DataSet dstSubrogation = new DataSet();
            objSubrogation = new RIMS_Base.Biz.cSubrogation();
            dstSubrogation = objSubrogation.GetSubrogationLabel();
            for (int i = 0; i < dstSubrogation.Tables[0].Rows.Count; i++)
            {
                if (dstSubrogation.Tables[0].Rows[i]["Control_Type"].ToString() == "Label")
                {
                    if (dstSubrogation.Tables[0].Rows[i]["Control_Name"].ToString() == "fvSubrogation")
                    {
                        if (dstSubrogation.Tables[0].Rows[i]["caption"].ToString().Trim() != String.Empty)
                            ((Label)fvSubrogation.FindControl(dstSubrogation.Tables[0].Rows[i]["Label_Name"].ToString())).Text = dstSubrogation.Tables[0].Rows[i]["Caption"].ToString();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            //throw ex;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            objSubrogation = new RIMS_Base.Biz.cSubrogation();
            Subrogation_RetVal = objSubrogation.DeleteSubrogation(Request.Form["chkItem"].ToString());
            if (Subrogation_RetVal <= 0)
            {
                mvSubrogation.ActiveViewIndex = 0;
                gvSubrogation.DataSource = BindSubrogationDetails();
                gvSubrogation.DataBind();
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
        mvSubrogation.ActiveViewIndex = 1;
        Bindfv(FormViewMode.Insert);
       
        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";
        divfirst.Style["display"] = "none";
        divSearch.Style["display"] = "none";
        divbtn.Style["display"] = "none";
        divthird.Style["display"] = "block";        
        ViewState["Subrogation_ID"]=null;
        dvAttachDetails.Style["display"] = "none";
    }
    protected void gvSubrogation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";
        divfirst.Style["display"] = "none";
        divSearch.Style["display"] = "none";
        divbtn.Style["display"] = "none";
        divthird.Style["display"] = "block";
        
        try
        {
            if (e.CommandName != "Sort")
            {
                mvSubrogation.ActiveViewIndex = 1;
                SubrogationID = Convert.ToInt32(e.CommandArgument.ToString());
                ViewState["Subrogation_ID"] = SubrogationID;               
            }

            if (e.CommandName == "EditItem")
            {
                Bindfv(FormViewMode.Edit);
                // --- hide javascript error
                hdnTemp.Value = "display";
            }
            else if (e.CommandName == "View")
            {
                Bindfv(FormViewMode.ReadOnly);
                // --- hide javascript error
                hdnTemp.Value = "";
            }
            gvAttachmentDetails.DataSource = BindAttachmentDetails();
            gvAttachmentDetails.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvSubrogation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void gvSubrogation_Sorting(object sender, GridViewSortEventArgs e)
    {
        lstSubrogation = new List<RIMS_Base.cSubrogation>();
        objSubrogation = new RIMS_Base.Biz.cSubrogation();

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

        lstSubrogation = objSubrogation.SearchSubrogationData(null, null, Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString());

        if (ViewState["SortExp"] != null)
            lstSubrogation.Sort(new RIMS_Base.GenericComparer<RIMS_Base.cSubrogation>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
        gvSubrogation.DataSource = lstSubrogation;
        gvSubrogation.DataBind();

        divSearch.Style["display"] = "block";
        divfirst.Style["display"] = "none";
        divthird.Style["display"] = "block";
        divbtn.Style["display"] = "block";
        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";
    }
    protected void gvSubrogation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (ViewState["Edit"] != null && ViewState["Edit"].ToString() != string.Empty)
            {
                if (ViewState["Edit"].ToString() == "True")
                    ((Button)e.Row.FindControl("btnEdit")).Enabled = true;
                else
                {
                    ((Button)e.Row.FindControl("btnEdit")).Enabled = false;
                    ((Button)e.Row.FindControl("btnEdit")).ToolTip = "You have no rights";
                }
            }
            if (ViewState["View"] != null && ViewState["View"].ToString() != string.Empty)
            {
                if (ViewState["View"].ToString() == "True")
                    ((Button)e.Row.FindControl("btnView")).Enabled = true;
                else
                {
                    ((Button)e.Row.FindControl("btnView")).Enabled = false;
                    ((Button)e.Row.FindControl("btnView")).ToolTip = "You have no rights";
                }
            }
        }
        // -- Display Dynamic Label
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                DataSet dstSubrogation = new DataSet();
                objSubrogation = new RIMS_Base.Biz.cSubrogation();
                dstSubrogation = objSubrogation.GetSubrogationLabel();
                for (int i = 0; i < dstSubrogation.Tables[0].Rows.Count; i++)
                {
                    if (dstSubrogation.Tables[0].Rows[i]["Control_Type"].ToString() == "GridView")
                    {
                        if (dstSubrogation.Tables[0].Rows[i]["Control_Name"].ToString() == "gvSubrogation")
                        {
                            if (dstSubrogation.Tables[0].Rows[i]["caption"].ToString().Trim() != String.Empty)
                            {
                                int ColumnNo = Convert.ToInt32(dstSubrogation.Tables[0].Rows[i]["Label_Name"].ToString());
                                gvSubrogation.Columns[ColumnNo].HeaderText = dstSubrogation.Tables[0].Rows[i]["Caption"].ToString();
                            }
                        }
                    }
                }
            }

        }
        catch (Exception ex)
        {
            //throw ex;
        }
    }
    #endregion

    #region Search Process
    protected void btnSaveView_Click(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gvSubrogation.DataSource = BindSubrogationDetails();
        gvSubrogation.DataBind();

        lblPageInfo.Text = "Page 1 of " + gvSubrogation.PageCount.ToString();
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
            gvSubrogation.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
            gvSubrogation.DataSource = BindSubrogationDetails();
            gvSubrogation.DataBind();
            lblPageInfo.Text = "Page 1 of " + gvSubrogation.PageCount.ToString();
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
                gvSubrogation.PageIndex = 0;
                txtPageNo.Text = "1";
            }
            else if (Convert.ToInt32(txtPageNo.Text) > gvSubrogation.PageCount)
            {
                gvSubrogation.PageIndex = gvSubrogation.PageCount;
                txtPageNo.Text = gvSubrogation.PageCount.ToString();
            }
            else
            {
                gvSubrogation.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;
            }
            lblPageInfo.Text = "Page " + txtPageNo.Text.ToString() + " of " + gvSubrogation.PageCount.ToString();
            gvSubrogation.DataSource = BindSubrogationDetails();
            gvSubrogation.DataBind();

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
            if (gvSubrogation.PageIndex <= gvSubrogation.PageCount)
            {
                gvSubrogation.PageIndex = gvSubrogation.PageIndex - 1;
                GeneralSorting();
                //gvSubrogation.DataSource = BindSubrogationDetails();
                //gvSubrogation.DataBind();
                lblPageInfo.Text = "Page " + Convert.ToString(gvSubrogation.PageIndex + 1) + " of " + gvSubrogation.PageCount.ToString();

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
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvSubrogation.PageIndex <= gvSubrogation.PageCount)
            {
                gvSubrogation.PageIndex = gvSubrogation.PageIndex + 1;
                GeneralSorting();
                //gvSubrogation.DataSource = BindSubrogationDetails();
                //gvSubrogation.DataBind();
                lblPageInfo.Text = "Page " + Convert.ToString(gvSubrogation.PageIndex + 1) + " of " + gvSubrogation.PageCount.ToString();

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
        }
    }
    #endregion

    #region Form View Functionality

    protected void dwPaymentID_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<RIMS_Base.CGeneral> lstGenereal = new List<RIMS_Base.CGeneral>();
        RIMS_Base.Biz.CGeneral objGeneral = new RIMS_Base.Biz.CGeneral();

        if (((DropDownList)fvSubrogation.FindControl("dwPaymentID")).SelectedIndex != 0)
        {
            string PaymentID = ((DropDownList)fvSubrogation.FindControl("dwPaymentID")).SelectedItem.Text;
            if (PaymentID == "Medical")
            {
                PaymentID = "Bodily Injury";
            }
            else if (PaymentID == "Indemnity")
            {
                PaymentID = "Property Damage";
            }
            ((DropDownList)fvSubrogation.FindControl("dwPayCode")).DataSource = objGeneral.GetPayCode(PaymentID);
            ((DropDownList)fvSubrogation.FindControl("dwPayCode")).DataTextField = "Trans_Code_Description";
            ((DropDownList)fvSubrogation.FindControl("dwPayCode")).DataValueField = "Trans_Code";
            ((DropDownList)fvSubrogation.FindControl("dwPayCode")).DataBind();
            ((DropDownList)fvSubrogation.FindControl("dwPayCode")).Items.Insert(0, "--Select Pay Code--");
            ((TextBox)fvSubrogation.FindControl("txtPTaxID")).Text = taxid.Value;
            ((TextBox)fvSubrogation.FindControl("txtPAdd1")).Text = add1.Value;
            ((TextBox)fvSubrogation.FindControl("txtPAdd2")).Text = add2.Value;
            ((TextBox)fvSubrogation.FindControl("txtPCity")).Text = city.Value;
            ((TextBox)fvSubrogation.FindControl("txtPZip")).Text = zip.Value;
            ((TextBox)fvSubrogation.FindControl("txtPState")).Text = state.Value;
        }
    }
    protected void fvSubrogation_DataBound(object sender, EventArgs e)
    {      

        try
        {
            List<RIMS_Base.CGeneral> lstGenereal = new List<RIMS_Base.CGeneral>();
            RIMS_Base.Biz.CGeneral objGeneral = new RIMS_Base.Biz.CGeneral();

            objSubrogation = new RIMS_Base.Biz.cSubrogation();

            if (fvSubrogation.CurrentMode != FormViewMode.ReadOnly)
            {
                ((DropDownList)fvSubrogation.FindControl("ddlAttachType")).DataSource = objGeneral.GetAttachamentType();
                ((DropDownList)fvSubrogation.FindControl("ddlAttachType")).DataTextField = "FLD_Desc";
                ((DropDownList)fvSubrogation.FindControl("ddlAttachType")).DataValueField = "FLD_Code";
                ((DropDownList)fvSubrogation.FindControl("ddlAttachType")).DataBind();
                ((DropDownList)fvSubrogation.FindControl("ddlAttachType")).Items.Insert(0, "--Select Attachment Type--");
                ((DropDownList)fvSubrogation.FindControl("ddlAttachType")).SelectedIndex = 1;

                ((DropDownList)fvSubrogation.FindControl("dwPaymentID")).DataSource = objGeneral.GetVendorType();
                ((DropDownList)fvSubrogation.FindControl("dwPaymentID")).DataTextField = "VendorType_FLD_DescO";
                ((DropDownList)fvSubrogation.FindControl("dwPaymentID")).DataValueField = "VendorType_PK_ID";
                ((DropDownList)fvSubrogation.FindControl("dwPaymentID")).DataBind();
                ((DropDownList)fvSubrogation.FindControl("dwPaymentID")).Items.Insert(0, "--Select Payment ID--");

                //((DropDownList)fvSubrogation.FindControl("dwProviderName")).DataSource = objSubrogation.GetProvider(0);
                //((DropDownList)fvSubrogation.FindControl("dwProviderName")).DataTextField = "Name";
                //((DropDownList)fvSubrogation.FindControl("dwProviderName")).DataValueField = "PK_Provider_ID";
                //((DropDownList)fvSubrogation.FindControl("dwProviderName")).DataBind();
                //((DropDownList)fvSubrogation.FindControl("dwProviderName")).Items.Insert(0, "--Select Provider--");

                ((DropDownList)fvSubrogation.FindControl("dwPayCode")).Items.Insert(0, "--Select Pay Code--");

                ((RadioButton)fvSubrogation.FindControl("rbtnFRefundYes")).Attributes.Add("onClick", "partialrefund();");
                ((RadioButton)fvSubrogation.FindControl("rbtnFRefundNo")).Attributes.Add("onClick", "partialrefund();");

                btnRemove.Style["display"] = "block";
                btnMail.Style["display"] = "block";
            }

            if (fvSubrogation.CurrentMode == FormViewMode.Edit)
            {
                //((DropDownList)fvSubrogation.FindControl("dwNoteType")).SelectedIndex = Convert.ToInt32(((DropDownList)fvAdjustorDetail.FindControl("dwNoteType")).Items.FindByText(lstSubrogation[0].Note_Type).Value);
                if (lstSubrogation[0].Payment_Id != String.Empty)
                {
                 //   ((DropDownList)fvSubrogation.FindControl("dwProviderName")).SelectedIndex = ((DropDownList)fvSubrogation.FindControl("dwProviderName")).Items.IndexOf(((DropDownList)fvSubrogation.FindControl("dwProviderName")).Items.FindByValue(lstSubrogation[0].FK_Provider.ToString()));

                    ((DropDownList)fvSubrogation.FindControl("dwPaymentID")).SelectedIndex = ((DropDownList)fvSubrogation.FindControl("dwPaymentID")).Items.IndexOf(((DropDownList)fvSubrogation.FindControl("dwPaymentID")).Items.FindByText(lstSubrogation[0].Payment_Id));
                    

                    ((DropDownList)fvSubrogation.FindControl("dwPayCode")).DataSource = objGeneral.GetPayCode(lstSubrogation[0].Payment_Id);
                    ((DropDownList)fvSubrogation.FindControl("dwPayCode")).DataTextField = "Trans_Code_Description";
                    ((DropDownList)fvSubrogation.FindControl("dwPayCode")).DataValueField = "Trans_Code";
                    ((DropDownList)fvSubrogation.FindControl("dwPayCode")).DataBind();
                    ((DropDownList)fvSubrogation.FindControl("dwPayCode")).Items.Insert(0, "--Select Pay Code--");

                    ((DropDownList)fvSubrogation.FindControl("dwPayCode")).SelectedIndex = ((DropDownList)fvSubrogation.FindControl("dwPayCode")).Items.IndexOf(((DropDownList)fvSubrogation.FindControl("dwPayCode")).Items.FindByValue(lstSubrogation[0].Paycode));

                    // dwProviderName

                    if (lstSubrogation[0].Subrogation == "Y")
                        ((RadioButton)fvSubrogation.FindControl("rbtnSubrogationYes")).Checked = true;
                    else if (lstSubrogation[0].Subrogation == "N")
                        ((RadioButton)fvSubrogation.FindControl("rbtnSubrogationNo")).Checked = true;
                    if (lstSubrogation[0].Auto_Salvage == "Y")
                        ((RadioButton)fvSubrogation.FindControl("rbtnSalvageYes")).Checked = true;
                    else if (lstSubrogation[0].Auto_Salvage == "N")
                        ((RadioButton)fvSubrogation.FindControl("rbtnSalvageNo")).Checked = true;
                    if (lstSubrogation[0].Other == "Y")
                        ((RadioButton)fvSubrogation.FindControl("rbtnOtherYes")).Checked = true;
                    else if (lstSubrogation[0].Other == "N")
                        ((RadioButton)fvSubrogation.FindControl("rbtnOtherNo")).Checked = true;                    

                    if (lstSubrogation[0].Full_Refund == "Y")
                        ((RadioButton)fvSubrogation.FindControl("rbtnFRefundYes")).Checked = true;  
                    else if (lstSubrogation[0].Full_Refund == "N")
                        ((RadioButton)fvSubrogation.FindControl("rbtnFRefundNo")).Checked = true;  
                    if (lstSubrogation[0].Partial_Refund == "Y")
                        ((RadioButton)fvSubrogation.FindControl("rbtnPartRefundYes")).Checked = true;
                    else if (lstSubrogation[0].Partial_Refund == "N")
                        ((RadioButton)fvSubrogation.FindControl("rbtnPartRefundNo")).Checked = true;
                    btnRemove.Style["display"] = "block";
                    btnMail.Style["display"] = "block";
                }
            }

            if (fvSubrogation.CurrentMode == FormViewMode.ReadOnly)
            {
                if (lstSubrogation[0].Subrogation == "Y")
                    ((Label)fvSubrogation.FindControl("lblSubrogation")).Text = "Yes";
                else if (lstSubrogation[0].Subrogation == "N")
                    ((Label)fvSubrogation.FindControl("lblSubrogation")).Text = "No";
                if (lstSubrogation[0].Auto_Salvage == "Y")
                    ((Label)fvSubrogation.FindControl("lblAutoSalvage")).Text = "Yes";
                else if (lstSubrogation[0].Auto_Salvage == "N")
                    ((Label)fvSubrogation.FindControl("lblAutoSalvage")).Text = "No";
                if (lstSubrogation[0].Other == "Y")
                    ((Label)fvSubrogation.FindControl("lblOther")).Text = "Yes";
                else if (lstSubrogation[0].Other == "N")
                    ((Label)fvSubrogation.FindControl("lblOther")).Text = "No";

                //((Label)fvSubrogation.FindControl("lblPayCode")).Text = ((DropDownList)fvSubrogation.FindControl("dwPayCode")).Items.FindByValue(lstSubrogation[0].Paycode).Text;
                ((Label)fvSubrogation.FindControl("lblPayCode")).Text = lstSubrogation[0].FLD_Paycode;

                if (lstSubrogation[0].Full_Refund == "Y")
                    ((Label)fvSubrogation.FindControl("lblFullRefund")).Text = "Yes";
                else if (lstSubrogation[0].Full_Refund == "N")
                    ((Label)fvSubrogation.FindControl("lblFullRefund")).Text = "No";
                if (lstSubrogation[0].Partial_Refund == "Y")
                    ((Label)fvSubrogation.FindControl("lblPartRefund")).Text = "Yes";
                else if (lstSubrogation[0].Partial_Refund == "N")
                    ((Label)fvSubrogation.FindControl("lblPartRefund")).Text = "No";
                btnRemove.Style["display"] = "none";
                btnMail.Style["display"] = "none";
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

    #endregion

    #region Insert Update

    private void InsertUpdate()
    {
        objSubrogation = new RIMS_Base.Biz.cSubrogation();
        lstSubrogation = new List<RIMS_Base.cSubrogation>();

        if(ViewState["Subrogation_ID"]!=null && ViewState["Subrogation_ID"].ToString() != String.Empty)
        {
            objSubrogation.PK_Subrogation = Convert.ToInt32(ViewState["Subrogation_ID"].ToString());
            if (Session["UserID"] != null)
                objSubrogation.Updated_By = Session["UserID"].ToString(); 
        }
        objSubrogation.FK_Table_Name = Convert.ToDecimal(ViewState["TableFK"].ToString());
            objSubrogation.Table_Name = ViewState["TableName"].ToString();
        if(((TextBox)fvSubrogation.FindControl("txtCheckAmt")).Text != string.Empty)
            objSubrogation.Check_Amount = Convert.ToDecimal(((TextBox)fvSubrogation.FindControl("txtCheckAmt")).Text);
        //if (((DropDownList)fvSubrogation.FindControl("dwProviderName")).SelectedIndex != 0)
            objSubrogation.FK_Provider = Convert.ToDecimal(((TextBox)fvSubrogation.FindControl("txtPId")).Text);
            ((TextBox)fvSubrogation.FindControl("txtPTaxID")).Text = taxid.Value;
            ((TextBox)fvSubrogation.FindControl("txtPAdd1")).Text = add1.Value;
            ((TextBox)fvSubrogation.FindControl("txtPAdd2")).Text = add2.Value;
            ((TextBox)fvSubrogation.FindControl("txtPCity")).Text = city.Value;
            ((TextBox)fvSubrogation.FindControl("txtPZip")).Text = zip.Value;
            ((TextBox)fvSubrogation.FindControl("txtPState")).Text = state.Value;
            objSubrogation.Tax_Id = ((TextBox)fvSubrogation.FindControl("txtPTaxID")).Text;       
            objSubrogation.Address_1 = ((TextBox)fvSubrogation.FindControl("txtPAdd1")).Text;        
            objSubrogation.Address_2 = ((TextBox)fvSubrogation.FindControl("txtPAdd2")).Text;        
            objSubrogation.City = ((TextBox)fvSubrogation.FindControl("txtPCity")).Text;        
            objSubrogation.State = ((TextBox)fvSubrogation.FindControl("txtPState")).Text;        
            objSubrogation.Zip_Code = ((TextBox)fvSubrogation.FindControl("txtPZip")).Text;

            if (((TextBox)fvSubrogation.FindControl("txtCheckNo")).Text != string.Empty)
                objSubrogation.Check_Number = Convert.ToDecimal(((TextBox)fvSubrogation.FindControl("txtCheckNo")).Text);

            if (((RadioButton)fvSubrogation.FindControl("rbtnSubrogationYes")).Checked == true)
                objSubrogation.Subrogation = "Y";
            if (((RadioButton)fvSubrogation.FindControl("rbtnSubrogationNo")).Checked == true)
                objSubrogation.Subrogation = "N";
            if (((RadioButton)fvSubrogation.FindControl("rbtnSalvageYes")).Checked == true)
                objSubrogation.Auto_Salvage = "Y";
            if (((RadioButton)fvSubrogation.FindControl("rbtnSalvageNo")).Checked == true)
                objSubrogation.Auto_Salvage = "N";
            if (((RadioButton)fvSubrogation.FindControl("rbtnOtherYes")).Checked == true)
                objSubrogation.Other = "Y";
            if (((RadioButton)fvSubrogation.FindControl("rbtnOtherNo")).Checked == true)
                objSubrogation.Other = "N";

            objSubrogation.Other_Description = ((TextBox)fvSubrogation.FindControl("txtDescription")).Text;
            if (((DropDownList)fvSubrogation.FindControl("dwPaymentID")).SelectedIndex != 0)
                objSubrogation.Payment_Id = ((DropDownList)fvSubrogation.FindControl("dwPaymentID")).SelectedItem.Text;
            if (((DropDownList)fvSubrogation.FindControl("dwPayCode")).SelectedIndex != 0)
                objSubrogation.Paycode = ((DropDownList)fvSubrogation.FindControl("dwPayCode")).SelectedItem.Value;
            objSubrogation.Recovery_Description = ((TextBox)fvSubrogation.FindControl("txtRecoveryDesc")).Text;

            if (((RadioButton)fvSubrogation.FindControl("rbtnFRefundYes")).Checked == true)
                objSubrogation.Full_Refund = "Y";
            if (((RadioButton)fvSubrogation.FindControl("rbtnFRefundNo")).Checked == true)
                objSubrogation.Full_Refund = "N";
            if (((RadioButton)fvSubrogation.FindControl("rbtnPartRefundYes")).Checked == true)
                objSubrogation.Partial_Refund = "Y";
            if (((RadioButton)fvSubrogation.FindControl("rbtnPartRefundNo")).Checked == true)
                objSubrogation.Partial_Refund = "N";

            objSubrogation.Update_Date = DateTime.Now;
            Subrogation_RetVal = objSubrogation.InsertUpdateSubrogation(objSubrogation);
            ViewState["Subrogation_ID"] = Subrogation_RetVal;
            

    }

    #endregion

    #region View All From Main Search Grid

    private void ViewAllFromSearchGrid()
    {
        lstSubrogation = new List<RIMS_Base.cSubrogation>();
        objSubrogation = new RIMS_Base.Biz.cSubrogation();

        if (ViewState["TableFK"] != null && ViewState["TableFK"].ToString() != String.Empty)
        {
            lstSubrogation = objSubrogation.GetAll(Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString());
        }
        //if (lstSubrogation.Count > 0)
        //{
            try
            {
                gvViewAll.DataSource = lstSubrogation;
                gvViewAll.DataBind();
                
                m_objAttachment = new RIMS_Base.Biz.CAttachment();
                lstAttachment = new List<RIMS_Base.CAttachment>();
                if (lstSubrogation.Count > 0)
                {
                    lstAttachment = m_objAttachment.GetAllAttachmentGroup(AttachmentID, "Subrogation");
                }
                else
                {
                    lstAttachment = m_objAttachment.GetAllAttachmentGroup("0", "Subrogation");
                }

                //if (lstAttachment.Count > 0)
                //    btnViewMail.Visible = true;
                //else
                //    btnViewMail.Visible = false;

                gvViewAttachment.DataSource = lstAttachment;
                gvViewAttachment.DataBind();
                gvViewAttachment.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        //}           

        divfirst.Style["display"] = "none";
        divSearch.Style["display"] = "none";
        divbtn.Style["display"] = "none";
        divthird.Style["display"] = "none";
        mainContent.Style["display"] = "none";
        leftdiv.Style["display"] = "none";
        divView.Style["display"] = "block";

    }

    protected void gvViewAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // -- Display Dynamic Labels
            try
            {
                DataSet dstSubrogation = new DataSet();
                objSubrogation = new RIMS_Base.Biz.cSubrogation();
                dstSubrogation = objSubrogation.GetSubrogationLabel();
                for (int i = 0; i < dstSubrogation.Tables[0].Rows.Count; i++)
                {
                    if (dstSubrogation.Tables[0].Rows[i]["Control_Type"].ToString() == "Label" && dstSubrogation.Tables[0].Rows[i]["ViewAll_Label_Name"].ToString() != String.Empty)
                    {
                        if (dstSubrogation.Tables[0].Rows[i]["caption"].ToString().Trim() != String.Empty)
                            ((Label)e.Row.FindControl(dstSubrogation.Tables[0].Rows[i]["ViewAll_Label_Name"].ToString())).Text = dstSubrogation.Tables[0].Rows[i]["Caption"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                //throw ex;
            }

            if (lstSubrogation.Count > 0)
            {
                if (lstSubrogation[e.Row.RowIndex].Subrogation == "Y")
                    ((Label)e.Row.FindControl("lblVSubrogation")).Text = "Yes";
                else if (lstSubrogation[e.Row.RowIndex].Subrogation == "N")
                    ((Label)e.Row.FindControl("lblVSubrogation")).Text = "No";
                if (lstSubrogation[e.Row.RowIndex].Auto_Salvage == "Y")
                    ((Label)e.Row.FindControl("lblVAutoSalvage")).Text = "Yes";
                else if (lstSubrogation[e.Row.RowIndex].Auto_Salvage == "N")
                    ((Label)e.Row.FindControl("lblVAutoSalvage")).Text = "No";
                if (lstSubrogation[e.Row.RowIndex].Other == "Y")
                    ((Label)e.Row.FindControl("lblVOther")).Text = "Yes";
                else if (lstSubrogation[e.Row.RowIndex].Other == "N")
                    ((Label)e.Row.FindControl("lblVOther")).Text = "No";

                ((Label)e.Row.FindControl("lblVPayCode")).Text = lstSubrogation[e.Row.RowIndex].FLD_Paycode;

                if (lstSubrogation[e.Row.RowIndex].Full_Refund == "Y")
                    ((Label)e.Row.FindControl("lblVFullRefund")).Text = "Yes";
                else if (lstSubrogation[e.Row.RowIndex].Full_Refund == "N")
                    ((Label)e.Row.FindControl("lblVFullRefund")).Text = "No";
                if (lstSubrogation[e.Row.RowIndex].Partial_Refund == "Y")
                    ((Label)e.Row.FindControl("lblVPartRefund")).Text = "Yes";
                else if (lstSubrogation[e.Row.RowIndex].Partial_Refund == "N")
                    ((Label)e.Row.FindControl("lblVPartRefund")).Text = "No";

                if (AttachmentID == "")
                    AttachmentID += ((Label)e.Row.FindControl("lblSubrogationID")).Text.ToString();
                else
                    AttachmentID += "," + ((Label)e.Row.FindControl("lblSubrogationID")).Text.ToString();
            }
        }
    }

    protected void btnViewNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Workers_Compensation/SubrogationDetail.aspx");
    }
    #endregion

    protected void dwProviderName_SelectedIndexChanged(object sender, EventArgs e)
    {
        objSubrogation = new RIMS_Base.Biz.cSubrogation();
        lstSubrogation = new List<RIMS_Base.cSubrogation>();

        if (((DropDownList)fvSubrogation.FindControl("dwProviderName")).SelectedIndex != 0)
        {
            Decimal ProviderID = Convert.ToDecimal(((DropDownList)fvSubrogation.FindControl("dwProviderName")).SelectedValue);
            lstSubrogation = objSubrogation.GetProvider(ProviderID);
            ((TextBox)fvSubrogation.FindControl("txtPTaxID")).Text = lstSubrogation[0].Tax_Id;
            ((TextBox)fvSubrogation.FindControl("txtPAdd1")).Text = lstSubrogation[0].Address_1;
            ((TextBox)fvSubrogation.FindControl("txtPAdd2")).Text = lstSubrogation[0].Address_2;
            ((TextBox)fvSubrogation.FindControl("txtPCity")).Text = lstSubrogation[0].City;
            ((TextBox)fvSubrogation.FindControl("txtPState")).Text = lstSubrogation[0].State;
            ((TextBox)fvSubrogation.FindControl("txtPZip")).Text = lstSubrogation[0].Zip_Code;
        }
        else
        {
            ((TextBox)fvSubrogation.FindControl("txtPTaxID")).Text = "";
            ((TextBox)fvSubrogation.FindControl("txtPAdd1")).Text = "";
            ((TextBox)fvSubrogation.FindControl("txtPAdd2")).Text = "";
            ((TextBox)fvSubrogation.FindControl("txtPCity")).Text = "";
            ((TextBox)fvSubrogation.FindControl("txtPState")).Text = "";
            ((TextBox)fvSubrogation.FindControl("txtPZip")).Text = "";
        }

        
    }
    protected void second_Click(object sender, EventArgs e)
    {
        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";
        hdnTemp.Value = "";
        dvAttachDetails.Style["display"] = "none";
        divfirst.Style["display"] = "none";
        divSearch.Style["display"] = "block";
        divbtn.Style["display"] = "block";
        divthird.Style["display"] = "block";
        mvSubrogation.ActiveViewIndex = 0;        
    }
    protected void first_Click(object sender, EventArgs e)
    {
        second.CssClass = "left_menu";
        first.CssClass = "left_menu_active";
        hdnTemp.Value = "";
        dvAttachDetails.Style["display"] = "none";
        divfirst.Style["display"] = "block";
        divSearch.Style["display"] = "none";
        divbtn.Style["display"] = "block";
        divthird.Style["display"] = "none";
        mvSubrogation.ActiveViewIndex = 0;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        InsertUpdate();

        // --- hide javascript error
        hdnTemp.Value = "";

        mvSubrogation.ActiveViewIndex = 0;
        gvSubrogation.DataSource = BindSubrogationDetails();
        gvSubrogation.DataBind();

        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";
       

        dvAttachDetails.Style["display"] = "none";
        divfirst.Style["display"] = "none";
        divSearch.Style["display"] = "block";
        divbtn.Style["display"] = "block";
        divthird.Style["display"] = "block";

    }

    private void GeneralSorting()
    {
        try
        {
            lstSubrogation = new List<RIMS_Base.cSubrogation>();
            lstSubrogation = BindSubrogationDetails();
            if (ViewState["SortExp"] != null && ViewState["sortDirection"] != null)
            {
                lstSubrogation.Sort(new RIMS_Base.GenericComparer<RIMS_Base.cSubrogation>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
                strSortExp = ViewState["SortExp"].ToString();
            }
            gvSubrogation.DataSource = lstSubrogation;
            gvSubrogation.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    #region User Rights
    protected bool SetUserRights()
    {
        try
        {

            m_objRightDetails = new CRolePermission();
            if (Session["UserRoleId"] != null)
            {
                lstRightDetails = m_objRightDetails.GetRights(1, Convert.ToInt32(Session["UserRoleId"].ToString()));
                ViewState["Add"] = lstRightDetails[0].PAdd.ToString();
                ViewState["Edit"] = lstRightDetails[0].PEdit.ToString();
                ViewState["Delete"] = lstRightDetails[0].PDelete.ToString();
                ViewState["View"] = lstRightDetails[0].PView.ToString();
                if (ViewState["Add"].ToString() == "True")
                {
                    btnAddNew.Enabled = true;
                }
                else
                {
                    btnAddNew.Enabled = false;
                    btnAddNew.ToolTip = "You have no rights";
                }
                if (ViewState["Delete"].ToString() == "True")
                {
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = false;
                    btnDelete.ToolTip = "You have no rights";
                }
                return true;
            }
            else
            {
                Response.Redirect("../Signin.aspx", false);
                return false;
            }

        }
        catch (Exception ex)
        {
            throw;
        }

    }
    #endregion
    
}
