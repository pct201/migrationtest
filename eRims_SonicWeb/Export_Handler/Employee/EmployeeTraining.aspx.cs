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
using RIMS_Base.Biz;
public partial class Employee_EmployeeTraining : System.Web.UI.Page
{
    #region Private Variables
    int m_intEmpTrainingId = 0;
    int m_intRetval = -1;
    public int m_intPreventAdd = 0;
    public RIMS_Base.Biz.CEmployeeTraining m_objEmpTraining;
    List<RIMS_Base.CEmployeeTraining> lstEmpTraining = null;
    public RIMS_Base.Biz.CEmployeeTraining m_objGrade;
    List<RIMS_Base.CEmployeeTraining> lstGrade = null;
    public RIMS_Base.Biz.CEmployeeTraining m_objStatus;
    List<RIMS_Base.CEmployeeTraining> lstStatus = null;
    public RIMS_Base.Biz.CEmployeeTraining m_objType;
    List<RIMS_Base.CEmployeeTraining> lstType = null;
    public RIMS_Base.Biz.CRolePermission m_objRightDetails;
    List<RIMS_Base.CRolePermission> lstRightDetails = null;
    public RIMS_Base.Biz.CGeneral m_objAttachmentType;
    List<RIMS_Base.CGeneral> lstAttachmentType = null;
    public RIMS_Base.Biz.CAttachment m_objAttachment;
    List<RIMS_Base.CAttachment> lstAttachment = null;
    ListItem m_lstCommon;
    string strSortExp = string.Empty;
    public string m_strPath = string.Empty;
    public string m_strFolderName = "EmployeeTraining";
    public string m_strCustomFileName = string.Empty;
    public string m_strFileName = string.Empty;
    public string m_strGlobalPath = string.Empty;
    #endregion
    #region Event Handlers
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            m_strGlobalPath = Page.ResolveUrl(ConfigurationManager.AppSettings["UploadPath"] + "/EmployeeTraining/");
            dvSearch.Visible = true;
            dvAttachDetails.Visible = false;
            if (!IsPostBack)
            {
                if (SetUserRights() == true)
                {
                    btnDelete.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvEmpTraining','Delete');");
                    btnRemove.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvAttachmentDetails','Delete');");
                    mvEmpTraining.ActiveViewIndex = 0;

                    gvEmpTraining.PageSize = 10;
                    btnRemove.Visible = false;
                    btnMail.Visible = false;
                    gvEmpTraining.DataSource = BindEmpTraining();
                    gvEmpTraining.DataBind();

                    ddlPage.DataBind();
                    ddlPage.SelectedValue = "10";
                    if (gvEmpTraining.PageCount == 0)
                    { lblPageInfo.Text = "Page 0 of 0"; }
                    else
                    {
                        lblPageInfo.Text = "Page 1 of " + gvEmpTraining.PageCount.ToString();
                    }
                    txtPageNo.Text = "1";
                    ViewState["PreventAdd"] = "N";
                }
            }



        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected bool SetUserRights()
    {
        try
        {

            m_objRightDetails = new CRolePermission();
            if (Session["UserRoleId"] != null)
            {
                lstRightDetails = m_objRightDetails.GetRights(27, Convert.ToInt32(Session["UserRoleId"].ToString()));
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
                }
                if (ViewState["Delete"].ToString() == "True")
                {
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = false;
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
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtPageNo.Text.ToString().Trim() == string.Empty || Convert.ToInt32(txtPageNo.Text) < 1)
            {
                gvEmpTraining.PageIndex = 0;
                txtPageNo.Text = "1";
            }
            else if (Convert.ToInt32(txtPageNo.Text) > gvEmpTraining.PageCount)
            {
                gvEmpTraining.PageIndex = gvEmpTraining.PageCount;
                txtPageNo.Text = gvEmpTraining.PageCount.ToString();
            }
            else
            {
                gvEmpTraining.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;
            }
            lblPageInfo.Text = "Page " + txtPageNo.Text.ToString() + " of " + gvEmpTraining.PageCount.ToString();
            gvEmpTraining.DataSource = BindEmpTraining();
            gvEmpTraining.DataBind();
            lblETTotal.Text = "Total Employee Training:" + lstEmpTraining.Count.ToString();

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
            if (gvEmpTraining.PageIndex <= gvEmpTraining.PageCount)
            {
                gvEmpTraining.PageIndex = gvEmpTraining.PageIndex + 1;
                GeneralSorting();

                lblPageInfo.Text = "Page " + Convert.ToString(gvEmpTraining.PageIndex + 1) + " of " + gvEmpTraining.PageCount.ToString();
                lblETTotal.Text = "Total Employee Training:" + lstEmpTraining.Count.ToString();
            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvEmpTraining.PageIndex <= gvEmpTraining.PageCount)
            {
                gvEmpTraining.PageIndex = gvEmpTraining.PageIndex - 1;
                GeneralSorting();
                lblPageInfo.Text = "Page " + Convert.ToString(gvEmpTraining.PageIndex + 1) + " of " + gvEmpTraining.PageCount.ToString();
                lblETTotal.Text = "Total Employee Training:" + lstEmpTraining.Count.ToString();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            m_objEmpTraining = new RIMS_Base.Biz.CEmployeeTraining();
            m_intRetval = m_objEmpTraining.DeleteEmployee_Training(Request.Form["chkItem"].ToString());
            if (m_intRetval <= 0)
            {
                mvEmpTraining.ActiveViewIndex = 0;
                gvEmpTraining.DataSource = BindEmpTraining();
                gvEmpTraining.DataBind();
            }
            lblETTotal.Text = "Total Employee Training: " + lstEmpTraining.Count.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        try
        {
            dvSearch.Visible = false;
            mvEmpTraining.ActiveViewIndex = 1;
            Bindfv(FormViewMode.Insert);
            btnRemove.Visible = false;
            btnMail.Visible = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            m_objEmpTraining = new RIMS_Base.Biz.CEmployeeTraining();
            lstEmpTraining = new List<RIMS_Base.CEmployeeTraining>();
            lstEmpTraining = m_objEmpTraining.Get_Search_Data(ddlSearch.SelectedValue, txtSearch.Text.Trim());
            gvEmpTraining.DataSource = lstEmpTraining;
            gvEmpTraining.DataBind();
            if (gvEmpTraining.PageCount == 0)
            { lblPageInfo.Text = "Page 0 of 0"; }
            else
            {
                lblPageInfo.Text = "Page 1 of " + gvEmpTraining.PageCount.ToString();
            }
            lblETTotal.Text = "Total Employee Training:" + lstEmpTraining.Count.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["PreventAdd"].ToString() == "N")
            {
                m_objEmpTraining = new RIMS_Base.Biz.CEmployeeTraining();
                if (fvEmpTraining.CurrentMode == FormViewMode.Insert)
                {
                    m_objEmpTraining.PK_Employee_Training_Id = 0;
                }
                else
                {
                    m_objEmpTraining.PK_Employee_Training_Id = Convert.ToInt32(((Label)fvEmpTraining.FindControl("lblEmpTrainingId")).Text);
                }
                m_objEmpTraining.Employee_FK = Convert.ToDecimal(((TextBox)fvEmpTraining.FindControl("txtEmpId")).Text);
                m_objEmpTraining.Retrain_Date = Convert.ToDateTime(((TextBox)fvEmpTraining.FindControl("txtDateOfRetraining")).Text);
                m_objEmpTraining.Training_Date = Convert.ToDateTime(((TextBox)fvEmpTraining.FindControl("txtDateOfTraining")).Text);
                m_objEmpTraining.Training_Description = Convert.ToString(((TextBox)fvEmpTraining.FindControl("txtTrainingDesc")).Text);
                m_objEmpTraining.Training_Grade = Convert.ToInt32(((DropDownList)fvEmpTraining.FindControl("ddlTrainingGrade")).SelectedValue);
                m_objEmpTraining.Training_Status = Convert.ToInt32(((DropDownList)fvEmpTraining.FindControl("ddlTrainingStatus")).SelectedValue);
                m_objEmpTraining.Training_Type = Convert.ToInt32(((DropDownList)fvEmpTraining.FindControl("ddlTrainingType")).SelectedValue);
                m_objEmpTraining.Updated_By = Session["UserID"].ToString();
                m_objEmpTraining.Update_Date = System.DateTime.Now.Date;
                m_intRetval = m_objEmpTraining.InsertUpdate_Employee_Training(m_objEmpTraining);
                if (m_intRetval >= 0)
                {
                    mvEmpTraining.ActiveViewIndex = 0;
                    gvEmpTraining.DataSource = BindEmpTraining();
                    gvEmpTraining.DataBind();
                }

            }
            else
            {
                ViewState["PreventAdd"] = "N";
                mvEmpTraining.ActiveViewIndex = 0;
                gvEmpTraining.DataSource = BindEmpTraining();
                gvEmpTraining.DataBind();
            }
            dvSearch.Visible = true;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {

            mvEmpTraining.ActiveViewIndex = 0;
            gvEmpTraining.DataSource = BindEmpTraining();
            gvEmpTraining.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void gvEmpTraining_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (ViewState["Edit"].ToString() == "True")
            {
                ((Button)(e.Row.FindControl("btnEdit"))).Enabled = true;
            }
            else
            {
                ((Button)(e.Row.FindControl("btnEdit"))).Enabled = false;
            }
            if (ViewState["View"].ToString() == "True")
            {
                ((Button)(e.Row.FindControl("btnView"))).Enabled = true;
            }
            else
            {
                ((Button)(e.Row.FindControl("btnView"))).Enabled = false;
            }
        }
    }
    protected void gvEmpTraining_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort")
            {
                dvSearch.Visible = false;
                mvEmpTraining.ActiveViewIndex = 1;
                m_intEmpTrainingId = Convert.ToInt32(e.CommandArgument.ToString());
            }
            if (e.CommandName == "EditItem")
            {
                dvSearch.Visible = false;
                Bindfv(FormViewMode.Edit);
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
            else if (e.CommandName == "View")
            {
                dvSearch.Visible = false;
                Bindfv(FormViewMode.ReadOnly);
                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();
                btnRemove.Visible = false;
                btnMail.Visible = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvEmpTraining_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            lstEmpTraining = new List<RIMS_Base.CEmployeeTraining>();
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

            lstEmpTraining = BindEmpTraining();
            if (ViewState["SortExp"] != null)
                lstEmpTraining.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CEmployeeTraining>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvEmpTraining.DataSource = lstEmpTraining;
            gvEmpTraining.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void fvEmpTraining_DataBound(object sender, EventArgs e)
    {
        try
        {
            if (fvEmpTraining.CurrentMode != FormViewMode.ReadOnly)
            {

                ((DropDownList)fvEmpTraining.FindControl("ddlTrainingGrade")).DataSource = GetTrainingGrade();
                ((DropDownList)fvEmpTraining.FindControl("ddlTrainingGrade")).DataTextField = "Training_GradeText";
                ((DropDownList)fvEmpTraining.FindControl("ddlTrainingGrade")).DataValueField = "Training_Grade";
                ((DropDownList)fvEmpTraining.FindControl("ddlTrainingGrade")).DataBind();
                m_lstCommon = new ListItem("--Select Training Grade--", "0");
                ((DropDownList)fvEmpTraining.FindControl("ddlTrainingGrade")).Items.Insert(0, m_lstCommon);


                ((DropDownList)fvEmpTraining.FindControl("ddlTrainingStatus")).DataSource = GetTrainingStatus();
                ((DropDownList)fvEmpTraining.FindControl("ddlTrainingStatus")).DataTextField = "Training_StatusText";
                ((DropDownList)fvEmpTraining.FindControl("ddlTrainingStatus")).DataValueField = "Training_Status";
                ((DropDownList)fvEmpTraining.FindControl("ddlTrainingStatus")).DataBind();
                m_lstCommon = new ListItem("--Select Training Status--", "0");
                ((DropDownList)fvEmpTraining.FindControl("ddlTrainingStatus")).Items.Insert(0, m_lstCommon);

                ((DropDownList)fvEmpTraining.FindControl("ddlTrainingType")).DataSource = GetTrainingType();
                ((DropDownList)fvEmpTraining.FindControl("ddlTrainingType")).DataTextField = "Training_TypeText";
                ((DropDownList)fvEmpTraining.FindControl("ddlTrainingType")).DataValueField = "Training_Type";
                ((DropDownList)fvEmpTraining.FindControl("ddlTrainingType")).DataBind();
                m_lstCommon = new ListItem("--Select Training Type--", "0");
                ((DropDownList)fvEmpTraining.FindControl("ddlTrainingType")).Items.Insert(0, m_lstCommon);


                ((DropDownList)fvEmpTraining.FindControl("ddlAttachType")).DataSource = GetAttachmentType();
                ((DropDownList)fvEmpTraining.FindControl("ddlAttachType")).DataTextField = "FLD_Desc";
                ((DropDownList)fvEmpTraining.FindControl("ddlAttachType")).DataValueField = "FLD_Code";
                ((DropDownList)fvEmpTraining.FindControl("ddlAttachType")).DataBind();
                m_lstCommon = new ListItem("--Select Attachment Type--", "0");
                ((DropDownList)fvEmpTraining.FindControl("ddlAttachType")).Items.Insert(0, m_lstCommon);

                ((DropDownList)fvEmpTraining.FindControl("ddlAttachType")).SelectedValue = "1";

            }

            if (fvEmpTraining.CurrentMode == FormViewMode.Edit)
            {
                ((DropDownList)fvEmpTraining.FindControl("ddlTrainingType")).SelectedValue = lstEmpTraining[0].Training_Type.ToString();
                ((DropDownList)fvEmpTraining.FindControl("ddlTrainingStatus")).SelectedValue = lstEmpTraining[0].Training_Status.ToString();
                ((DropDownList)fvEmpTraining.FindControl("ddlTrainingGrade")).SelectedValue = lstEmpTraining[0].Training_Grade.ToString();
            }
            if (fvEmpTraining.CurrentMode == FormViewMode.ReadOnly)
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
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gvEmpTraining.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
            gvEmpTraining.DataSource = BindEmpTraining();
            gvEmpTraining.DataBind();
            lblPageInfo.Text = "Page 1 of " + gvEmpTraining.PageCount.ToString();
            txtPageNo.Text = "1";
            lblETTotal.Text = "Total Employee Training Details:" + lstEmpTraining.Count.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnAddAttachment_Click(object sender, EventArgs e)
    {
        dvSearch.Visible = false;
        if (fvEmpTraining.CurrentMode == FormViewMode.Insert)
        {
            if (ViewState["PreventAdd"].ToString() == "N")
            {
                m_objEmpTraining = new RIMS_Base.Biz.CEmployeeTraining();
                if (fvEmpTraining.CurrentMode == FormViewMode.Insert)
                {
                    m_objEmpTraining.PK_Employee_Training_Id = 0;
                }
                else
                {
                    m_objEmpTraining.PK_Employee_Training_Id = Convert.ToInt32(((Label)fvEmpTraining.FindControl("lblEmpTrainigId")).Text);
                }
                m_objEmpTraining.Employee_FK = Convert.ToDecimal(((TextBox)fvEmpTraining.FindControl("txtEmpId")).Text);
                m_objEmpTraining.Retrain_Date = Convert.ToDateTime(((TextBox)fvEmpTraining.FindControl("txtDateOfRetraining")).Text);
                m_objEmpTraining.Training_Date = Convert.ToDateTime(((TextBox)fvEmpTraining.FindControl("txtDateOfTraining")).Text);
                m_objEmpTraining.Training_Description = Convert.ToString(((TextBox)fvEmpTraining.FindControl("txtTrainingDesc")).Text);
                m_objEmpTraining.Training_Grade = Convert.ToInt32(((DropDownList)fvEmpTraining.FindControl("ddlTrainingGrade")).SelectedValue);
                m_objEmpTraining.Training_Status = Convert.ToInt32(((DropDownList)fvEmpTraining.FindControl("ddlTrainingStatus")).SelectedValue);
                m_objEmpTraining.Training_Type = Convert.ToInt32(((DropDownList)fvEmpTraining.FindControl("ddlTrainingType")).SelectedValue);
                m_objEmpTraining.Update_Date = System.DateTime.Now;
                m_objEmpTraining.Updated_By = Session["UserID"].ToString();
                m_intRetval = m_objEmpTraining.InsertUpdate_Employee_Training(m_objEmpTraining);
                ((Label)fvEmpTraining.FindControl("lblEmpTrainingId")).Text = m_intRetval.ToString();
                ViewState["PreventAdd"] = "Y";
            }
            if (m_intRetval >= 0 || ViewState["PreventAdd"].ToString() == "Y")
            {
                dvAttachDetails.Visible = true;

                AddAttachment();
                if (m_intRetval >= 0)
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
            }
        }
        else
        {
            dvAttachDetails.Visible = true;
            AddAttachment();
            if (m_intRetval >= 0)
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

        }



    }
    protected void gvAttachmentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("imgbtnDwnld")).Attributes.Add("onclick", "javascript:return openWindow('" + m_strGlobalPath + ((ImageButton)e.Row.FindControl("imgbtnDwnld")).CommandArgument.ToString() + "');");
                //((ImageButton)e.Row.FindControl("imgbtnMail")).Attributes.Add("onclick", "javascript:return openMailWindow('../ErimsMail.aspx?AttMod=EmployeeTraining&AttName=" + ((ImageButton)e.Row.FindControl("imgbtnMail")).CommandArgument.ToString() + "');");
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            m_intRetval = m_objAttachment.DeleteAttachment(Request.Form["chkItem"].ToString());
            if (m_intRetval <= 0)
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
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvEmpTraining_RowCreated(object sender, GridViewRowEventArgs e)
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
        foreach (DataControlField field in gvEmpTraining.Columns)
        {
            if (field.SortExpression.ToString() == ViewState["SortExp"].ToString())
            {
                nRet = gvEmpTraining.Columns.IndexOf(field);
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
        System.Web.UI.WebControls.Image sortImage = new System.Web.UI.WebControls.Image();

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
    #endregion
    #region Private Methods
    /// <summary>
    /// Get the All Vendor's Details
    /// </summary>
    private List<RIMS_Base.CEmployeeTraining> BindEmpTraining()
    {
        try
        {
            m_objEmpTraining = new RIMS_Base.Biz.CEmployeeTraining();
            lstEmpTraining = new List<RIMS_Base.CEmployeeTraining>();
            lstEmpTraining = null;
            if (txtSearch.Text != string.Empty)
            {
                lstEmpTraining = m_objEmpTraining.Get_Search_Data(ddlSearch.SelectedValue, txtSearch.Text.Trim());
            }
            else
            {
                lstEmpTraining = m_objEmpTraining.GetAll();
            }
            lblETTotal.Text = "Total Employee Training:" + lstEmpTraining.Count.ToString();
            return lstEmpTraining;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }
    /// <summary>
    /// Bind The Attachment Details.
    /// </summary>
    /// <returns></returns>
    private List<RIMS_Base.CAttachment> BindAttachmentDetails()
    {
        try
        {
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            lstAttachment = new List<RIMS_Base.CAttachment>();
            lstAttachment = m_objAttachment.GetAll(0, Convert.ToInt32(((Label)fvEmpTraining.FindControl("lblEmpTrainingId")).Text), "EmployeeTraining");
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
    /// <summary>
    /// Get All State.
    /// </summary>
    private List<RIMS_Base.CEmployeeTraining> GetTrainingGrade()
    {
        try
        {
            m_objGrade = new RIMS_Base.Biz.CEmployeeTraining();
            lstGrade = new List<RIMS_Base.CEmployeeTraining>();
            lstGrade = m_objGrade.GetTrainingGrade();
            return lstGrade;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }
    private List<RIMS_Base.CEmployeeTraining> GetTrainingStatus()
    {
        try
        {
            m_objStatus = new RIMS_Base.Biz.CEmployeeTraining();
            lstStatus = new List<RIMS_Base.CEmployeeTraining>();
            lstStatus = m_objGrade.GetTrainingStatus();
            return lstStatus;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }
    private List<RIMS_Base.CEmployeeTraining> GetTrainingType()
    {
        try
        {
            m_objType = new RIMS_Base.Biz.CEmployeeTraining();
            lstType = new List<RIMS_Base.CEmployeeTraining>();
            lstType = m_objType.GetTrainingType();
            return lstType;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }
    /// <summary>
    /// Get All Attachment Type.
    /// </summary>
    private List<RIMS_Base.CGeneral> GetAttachmentType()
    {
        try
        {
            m_objAttachmentType = new RIMS_Base.Biz.CGeneral();
            lstAttachmentType = new List<RIMS_Base.CGeneral>();
            lstAttachmentType = m_objAttachmentType.GetAttachamentType();
            return lstAttachmentType;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }
    /// <summary>
    /// Bind the Formview Templates.
    /// </summary>
    /// <param name="fvMode"></param>
    private void Bindfv(FormViewMode fvMode)
    {
        try
        {

            if (fvMode == FormViewMode.Insert)
                fvEmpTraining.ChangeMode(FormViewMode.Insert);
            else if (fvMode == FormViewMode.Edit)
                fvEmpTraining.ChangeMode(FormViewMode.Edit);
            else if (fvMode == FormViewMode.ReadOnly)
                fvEmpTraining.ChangeMode(FormViewMode.ReadOnly);
            if (fvMode != FormViewMode.Insert)
            {
                dvAttachDetails.Visible = true;
                m_objEmpTraining = new RIMS_Base.Biz.CEmployeeTraining();
                lstEmpTraining = new List<RIMS_Base.CEmployeeTraining>();
                lstEmpTraining = m_objEmpTraining.GetEmployee_TrainingByID(m_intEmpTrainingId);
                fvEmpTraining.DataSource = lstEmpTraining;

            }
            fvEmpTraining.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
        }

    }
    /// <summary>
    /// Upload Documents
    /// </summary>
    private void UploadDocuments()
    {
        try
        {
            m_strPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"]);

            if (!(Directory.Exists(m_strPath + "\\" + m_strFolderName)))
            {
                Directory.CreateDirectory(m_strPath + "\\" + m_strFolderName);
            }
            m_strFileName = GetCustomFileName() + ((FileUpload)fvEmpTraining.FindControl("uplCommon")).FileName.ToString();
            m_strPath = m_strPath + "\\" + m_strFolderName + "\\" + m_strFileName;
            ((FileUpload)fvEmpTraining.FindControl("uplCommon")).SaveAs(m_strPath);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Get Custom File Name.
    /// </summary>
    /// <returns></returns>
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
    /// <summary>
    /// Insert Attachment in Database.
    /// </summary>
    /// <returns>Integer</returns>
    private int AddAttachment()
    {
        try
        {
            UploadDocuments();
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            m_objAttachment.Attachment_Table = "EmployeeTraining";
            m_objAttachment.Foreign_Key = Convert.ToInt32(((Label)fvEmpTraining.FindControl("lblEmpTrainingId")).Text);
            m_objAttachment.FK_Attachment_Type = Convert.ToInt32(((DropDownList)fvEmpTraining.FindControl("ddlAttachType")).SelectedValue);
            m_objAttachment.Attachment_Description = ((TextBox)fvEmpTraining.FindControl("txtDescription")).Text;
            m_objAttachment.Attachment_Name = m_strFileName;
            m_objAttachment.Updated_By = Session["UserID"].ToString();
            m_objAttachment.Update_Date = System.DateTime.Now.Date;
            m_intRetval = m_objAttachment.InsertUpdateAttachment(m_objAttachment);
            ((TextBox)fvEmpTraining.FindControl("txtDescription")).Text = string.Empty;
            ((DropDownList)fvEmpTraining.FindControl("ddlAttachType")).SelectedValue = "1";

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return m_intRetval;
    }
    private void GeneralSorting()
    {
        try
        {
            lstEmpTraining = new List<RIMS_Base.CEmployeeTraining>();
            lstEmpTraining = BindEmpTraining();
            if (ViewState["SortExp"] != null && ViewState["sortDirection"] != null)
                lstEmpTraining.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CEmployeeTraining>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvEmpTraining.DataSource = lstEmpTraining;
            gvEmpTraining.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    #endregion
}
