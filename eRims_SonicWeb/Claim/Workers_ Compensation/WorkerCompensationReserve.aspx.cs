using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Mail;
using System.Globalization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using RIMS_Base.Biz;
using System.IO;

public partial class WorkerCompensation_WorkerCompensationReserve : System.Web.UI.Page
{
	#region private variables
	public RIMS_Base.Biz.cWorkerCompReserveWork m_objWorkerRW;
	List<RIMS_Base.cWorkerCompReserveWork> lstWorkerRW = null;
	RIMS_Base.Biz.cWorkerComp objWorkerComp;
	List<RIMS_Base.cWorkerComp> lstWorkerComp = null;
	int m_intWorkersCompRWID = 0;
	IFormatProvider format = new CultureInfo("en-US");
	List<RIMS_Base.cWorkerCompReserveWork> lstClaimReservesInfo = null;
	public RIMS_Base.Biz.cWorkerCompReserveWork m_objClaimReservesInfo;
    public List<RIMS_Base.cWorkerCompReserveWork> lstreserve;
	// Payment Details
	DataSet dsPayment;


	// -- Attachment
	public string m_strCustomFileName = string.Empty;
	public string m_strFileName = string.Empty;
	public string m_strGlobalPath = string.Empty;
	public string m_strPath = string.Empty;
	public string m_strFolderName = "Workers_Comp_RW";
	public RIMS_Base.Biz.CAttachment m_objAttachment;
	List<RIMS_Base.CAttachment> lstAttachment = null;
	int Attach_Retval = -1;
	int m_intRetval = -1;

	//string AttachmentID = "";

	// Total Variables
	public static decimal m_IndeResTot = 0.0M;
	public static decimal m_MediResTot = 0.0M;
	public static decimal m_ExpResTot = 0.0M;
	public static decimal m_NetTotal = 0.0M;

    string strSortExp = String.Empty;

    public RIMS_Base.Biz.CRolePermission m_objRightDetails;
    List<RIMS_Base.CRolePermission> lstRightDetails = null;
	#endregion

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{            
                m_strGlobalPath = Page.ResolveUrl(ConfigurationManager.AppSettings["UploadPath"] + "/" + m_strFolderName + "/");
                btnDelete.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvWorkerRW','Delete');");
                btnRemove.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvAttachmentDetails','Delete');");

                if (!IsPostBack)
                {
                    ViewState.Clear();
                    if (SetUserRights() == true)
                    {
                        btnNextStep.Visible = true;
                        btnRemove.Visible = false;
                        btnMail.Visible = false;
                        if (Session["ViewAll"] != null && Session["ViewAll"].ToString() != String.Empty)
                        {
                            ViewAllRecords();
                        }
                        else
                        {
                            BindClaimAndReservesData();
                            BindPaymentDetails();

                            lbtnClaimDetail.Style.Add("CssClass", "left_menu_active");
                            lbtnRHistory.Style.Add("CssClass", "left_menu");
                            lbtnOutstanding.Style.Add("CssClass", "left_menu");
                            dvClaimDetail.Style.Add("display", "block");
                            dvReserveHistory.Style.Add("display", "none");
                            dvOutstanding.Style.Add("display", "none");

                            // --- Commente Due to PAGE PRE RENDER.
                            //gvWorkerRW.DataSource = BindWorkerRW();
                            lblRWTotal.Text = "Total Reserve Worksheets : " + BindWorkerRW().Count.ToString();
                            gvWorkerRW.PageSize = 10;
                            gvWorkerRW.DataBind();
                            ddlPage.SelectedIndex = 2;
                            mvWorkersRW.ActiveViewIndex = 0;
                            lblPageInfo.Text = "Page " + Convert.ToString(gvWorkerRW.PageIndex + 1) + " of " + gvWorkerRW.PageCount.ToString();
                        }
                    }
                }            
		}
		catch (Exception ex)
		{
			throw ex;
		}

	}
    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (Session["ViewAll"] == null)
        {
            GeneralSorting();
        }
    }
	private void setVisible()
	{
		dvClaimDetail.Style.Add("display", "none");
		dvReserveHistory.Style.Add("display", "none");
		dvOutstanding.Style.Add("display", "none");

		if (Request.QueryString["id"] != null)
		{
			switch (Convert.ToInt32(Request.QueryString["id"].ToString()))
			{
				case 1:
					dvClaimDetail.Style.Add("display", "block");
					break;
				case 2:
					dvReserveHistory.Style.Add("display", "block");
					break;
				case 3:
					dvOutstanding.Style.Add("display", "block");
					break;
				default:
					dvClaimDetail.Style.Add("display", "block");
					break;
			}
		}
		else
		{
			dvClaimDetail.Style.Add("display", "block");
		}
	}
	protected void LinkButton2_Click(object sender, EventArgs e)
	{
		//  mvReserverWrkSht.ActiveViewIndex = 2;
	}
	protected void Button3_Click(object sender, EventArgs e)
	{
		//     mvReserverWrkSht.ActiveViewIndex = 0;
	}
	protected void btnNextStep_Click(object sender, EventArgs e)
	{
		Response.Redirect("~/WorkerCompensation/Carrier.aspx");
	}
	protected void Button1_Click(object sender, EventArgs e)
	{
		Response.Redirect("~/WorkerCompensation/WorkersCompensation.aspx");
	}
	protected void btnBackView_Click(object sender, EventArgs e)
	{
		mvWorkersRW.ActiveViewIndex = 0;
	}
	protected void btnBack_Click(object sender, EventArgs e)
	{

	}

	#region Left Menu (Vertical menu)
	protected void lbtnClaimDetail_Click(object sender, EventArgs e)
	{
		lbtnClaimDetail.CssClass = "left_menu_active";
		lbtnRHistory.CssClass = "left_menu";
		lbtnOutstanding.CssClass = "left_menu";
		lbtnPaymentDetails.CssClass = "left_menu";

		dvClaimDetail.Style.Add("display", "block");
		dvReserveHistory.Style.Add("display", "none");
		dvOutstanding.Style.Add("display", "none");
		dvPaymentDetails.Style.Add("display", "none");

	}
	protected void lbtnRHistory_Click(object sender, EventArgs e)
	{
		lbtnClaimDetail.CssClass = "left_menu";
		lbtnRHistory.CssClass = "left_menu_active";
		lbtnOutstanding.CssClass = "left_menu";
		lbtnPaymentDetails.CssClass = "left_menu";

		dvClaimDetail.Style.Add("display", "none");
		dvReserveHistory.Style.Add("display", "block");
		dvOutstanding.Style.Add("display", "none");
		dvPaymentDetails.Style.Add("display", "none");
		mvWorkersRW.ActiveViewIndex = 0;
        btnNextStep.Visible = true;
	}
	protected void lbtnOutstanding_Click(object sender, EventArgs e)
	{
		lbtnClaimDetail.CssClass = "left_menu";
		lbtnRHistory.CssClass = "left_menu";
		lbtnOutstanding.CssClass = "left_menu_active";
		lbtnPaymentDetails.CssClass = "left_menu";

		dvClaimDetail.Style.Add("display", "none");
		dvReserveHistory.Style.Add("display", "none");
		dvOutstanding.Style.Add("display", "block");
		dvPaymentDetails.Style.Add("display", "none");

		lblIOutStand.Text = m_IndeResTot.ToString();
		lblMOutStand.Text = m_MediResTot.ToString();
		lblEOutStand.Text = m_ExpResTot.ToString();
		lblOSTotal.Text = Convert.ToString(m_IndeResTot + m_MediResTot + m_ExpResTot);
        btnNextStep.Visible = true;
	}
	protected void lbtnPaymentDetails_Click(object sender, EventArgs e)
	{
		lbtnClaimDetail.CssClass = "left_menu";
		lbtnRHistory.CssClass = "left_menu";
		lbtnOutstanding.CssClass = "left_menu";
		lbtnPaymentDetails.CssClass = "left_menu_active";

		dvClaimDetail.Style.Add("display", "none");
		dvReserveHistory.Style.Add("display", "none");
		dvOutstanding.Style.Add("display", "none");
		dvPaymentDetails.Style.Add("display", "block");
        btnNextStep.Visible = true;
	}
	
	#endregion

	#region Attachment

	protected void gvAttachmentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		try
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				((ImageButton)e.Row.FindControl("imgbtnDwnld")).Attributes.Add("onclick", "javascript:return openWindow('" + m_strGlobalPath + "/" + ((ImageButton)e.Row.FindControl("imgbtnDwnld")).CommandArgument.ToString() + "');");
				//((ImageButton)e.Row.FindControl("imgbtnMail")).Attributes.Add("onclick", "javascript:return openMailWindow('../ErimsMail.aspx?AttMod=" + m_strFolderName + "&AttName=" + ((ImageButton)e.Row.FindControl("imgbtnMail")).CommandArgument.ToString() + "');");
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
			m_strFileName = GetCustomFileName() + ((FileUpload)fvWorkersRW.FindControl("uplCommon")).FileName.ToString();
			m_strPath = m_strPath + "\\" + m_strFolderName + "\\" + m_strFileName;
			((FileUpload)fvWorkersRW.FindControl("uplCommon")).SaveAs(m_strPath);

		}
		catch (Exception ex)
		{

			throw ex;
		}
	}

	//private void UploadDocuments()
	//{
	//    try
	//    {
	//        m_strPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"]);

	//        if (!(Directory.Exists(m_strPath + "\\" + m_strFolderName)))
	//        {
	//            Directory.CreateDirectory(m_strPath + "\\" + m_strFolderName);
	//        }
	//        // m_strFileName = GetCustomFileName() + uplCommon.FileName.ToString();
	//        m_strFileName = GetCustomFileName() + ((FileUpload)fvWorkersRW.FindControl("uplCommon")).FileName.ToString();
	//        m_strPath = m_strPath + "\\" + m_strFolderName + "\\" + m_strFileName;
	//        //uplCommon.SaveAs(m_strPath);
	//        ((FileUpload)fvWorkersRW.FindControl("uplCommon")).SaveAs(m_strPath);

	//    }
	//    catch (Exception ex)
	//    {
	//        //Log.Append("Error in UploadPhotoImages Method of ConditionAssessment's PhotoGraphs:" + ex.Message);
	//        //Common.reportError("Error in UploadPhotoImages Method of ConditionAssessment's PhotoGraphs:", ex.Message);
	//        throw ex;
	//    }
	//}



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
			//InsertUpdate();
			UploadDocuments();
			m_objAttachment = new RIMS_Base.Biz.CAttachment();
			m_objAttachment.Attachment_Table = "Workers_Comp_RW";
			m_objAttachment.Foreign_Key = Convert.ToInt32(ViewState["PK_Workers_Comp_RW_ID"].ToString());
			m_objAttachment.FK_Attachment_Type = Convert.ToInt32(((DropDownList)fvWorkersRW.FindControl("ddlAttachType")).SelectedValue);
			m_objAttachment.Attachment_Description = ((TextBox)fvWorkersRW.FindControl("txtAttachDesc")).Text.Replace("'", "''");
			m_objAttachment.Attachment_Name = m_strFileName;
            m_objAttachment.Updated_By = Session["UserID"].ToString();
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
		try
		{
			Page.Validate();
            btnRemove.Visible = true;
            btnMail.Visible = true;
            
			//if (ViewState["PK_Workers_Comp_RW_ID"] == null)
			//{
				InsertUpdate();
			//}
			AddAttachment();
			if (Attach_Retval > 0)
			{
				gvAttachmentDetails.DataSource = BindAttachmentDetails();
				gvAttachmentDetails.DataBind();
			}
			((TextBox)fvWorkersRW.FindControl("txtAttachDesc")).Text = "";
			((DropDownList)fvWorkersRW.FindControl("ddlAttachType")).SelectedIndex = 1;

			dvAttachDetails.Style["display"] = "block";
			//lbtnRHistory.CssClass = "left_menu_active";
			//lbtnClaimDetail.CssClass = "left_menu";
			//lbtnOutstanding.CssClass = "left_menu";
			//dvClaimDetail.Style["display"] = "none";
			dvReserveHistory.Style["display"] = "block";
			//dvOutstanding.Style["display"] = "none";
			//divbtn.Style["display"] = "none";
           
		}
		catch (Exception ex)
		{

			throw;
		}


	}

	private List<RIMS_Base.CAttachment> BindAttachmentDetails()
	{
		try
		{
			m_objAttachment = new RIMS_Base.Biz.CAttachment();
			lstAttachment = new List<RIMS_Base.CAttachment>();
			if (ViewState["PK_Workers_Comp_RW_ID"] != null && ViewState["PK_Workers_Comp_RW_ID"].ToString() != "")
				lstAttachment = m_objAttachment.GetAll(0, Convert.ToInt32(ViewState["PK_Workers_Comp_RW_ID"].ToString()), "Workers_Comp_RW");
			if (lstAttachment.Count > 0)
				dvAttachDetails.Style["display"] = "block";

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

	#endregion

	#region Gridview
	protected void btnAddNew_Click(object sender, EventArgs e)
	{
		try
		{
			dvClaimDetail.Style.Add("display", "block");
			mvWorkersRW.ActiveViewIndex = 1;
			Bindfv(FormViewMode.Insert);
            btnRemove.Visible = false;
            btnMail.Visible = false;
            btnNextStep.Visible = false;
		}
		catch (Exception ex)
		{
			throw ex;
		}

	}
	protected void btnDelete_Click(object sender, EventArgs e)
	{
		try
		{
			int m_intRetval = -1;
			m_objWorkerRW = new RIMS_Base.Biz.cWorkerCompReserveWork();
			m_intRetval = m_objWorkerRW.Delete_RWComp(Request.Form["chkItem"].ToString());
			if (m_intRetval <= 0)
			{
				mvWorkersRW.ActiveViewIndex = 0;
				gvWorkerRW.DataSource = BindWorkerRW();
				gvWorkerRW.DataBind();
				lblPageInfo.Text = "Page " + Convert.ToString(gvWorkerRW.PageIndex + 1) + " of " + gvWorkerRW.PageCount.ToString();
				//BindWorkerRW();
			}
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
			if (gvWorkerRW.PageIndex <= gvWorkerRW.PageCount)
			{
				gvWorkerRW.PageIndex = gvWorkerRW.PageIndex - 1;
                GeneralSorting();
				gvWorkerRW.DataSource = BindWorkerRW();
				gvWorkerRW.DataBind();
				lblPageInfo.Text = "Page " + Convert.ToString(gvWorkerRW.PageIndex + 1) + " of " + gvWorkerRW.PageCount.ToString();
			}
		}
		catch (Exception ex)
		{
		}
	}
	protected void btnNext_Click(object sender, EventArgs e)
	{
		try
		{
			if (gvWorkerRW.PageIndex <= gvWorkerRW.PageCount)
			{
				gvWorkerRW.PageIndex = gvWorkerRW.PageIndex + 1;
                GeneralSorting();
				gvWorkerRW.DataSource = BindWorkerRW();
				gvWorkerRW.DataBind();
				//lblPageInfo.Text = "Page " + Convert.ToString(gvWorkerRW.PageIndex + 1) + " of " + gvWorkerRW.PageCount.ToString();
				//lblPageInfo.Text = "Page 1 of " + gvWorkerRW.PageCount.ToString();
				lblPageInfo.Text = "Page " + Convert.ToString(gvWorkerRW.PageIndex + 1) + " of " + gvWorkerRW.PageCount.ToString();
			}
		}
		catch (Exception ex)
		{
		}
	}
	protected void btnGo_Click(object sender, EventArgs e)
	{
		try
		{

			if (txtPageNo.Text.ToString().Trim() == string.Empty || Convert.ToInt32(txtPageNo.Text) < 1)
			{
				gvWorkerRW.PageIndex = 0;
				txtPageNo.Text = "1";
			}
			else if (Convert.ToInt32(txtPageNo.Text) > gvWorkerRW.PageCount)
			{
				gvWorkerRW.PageIndex = gvWorkerRW.PageCount;
				txtPageNo.Text = gvWorkerRW.PageCount.ToString();
			}
			else
			{
				gvWorkerRW.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;
			}
			lblPageInfo.Text = "Page " + txtPageNo.Text.ToString() + " of " + gvWorkerRW.PageCount.ToString();
			gvWorkerRW.DataSource = BindWorkerRW();
			gvWorkerRW.DataBind();
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
			gvWorkerRW.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
			gvWorkerRW.DataSource = BindWorkerRW();
			gvWorkerRW.DataBind();
			lblPageInfo.Text = "Page " + (gvWorkerRW.PageIndex + 1) + " of " + gvWorkerRW.PageCount.ToString();
			txtPageNo.Text = "1";
			lblRWTotal.Text = "Total Reserve Worksheets : " + BindWorkerRW().Count.ToString(); ;
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
	/// <summary>
	/// Get the All WorkersComp Reserve Worksheets
	/// </summary>
	private List<RIMS_Base.cWorkerCompReserveWork> BindWorkerRW()
	{
		try
		{
			m_objWorkerRW = new RIMS_Base.Biz.cWorkerCompReserveWork();
			lstWorkerRW = new List<RIMS_Base.cWorkerCompReserveWork>();
			//lstWorkerRW = m_objWorkerRW.GetAll(true);
			lstWorkerRW = m_objWorkerRW.Workers_Comp_RWRecords(Convert.ToDecimal(Session["WorkerCompID"].ToString()));


			return lstWorkerRW;
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{

		}
	}
	protected void gvWorkerRW_Sorting(object sender, GridViewSortEventArgs e)
	{
		try
		{
			lstWorkerRW = new List<RIMS_Base.cWorkerCompReserveWork>();
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

			lstWorkerRW = BindWorkerRW();
			if (ViewState["SortExp"] != null)
				lstWorkerRW.Sort(new RIMS_Base.GenericComparer<RIMS_Base.cWorkerCompReserveWork>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
			gvWorkerRW.DataSource = lstWorkerRW;
			gvWorkerRW.DataBind();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
	protected void gvWorkerRW_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName != "Sort")
			{
				//dvSearch.Visible = false;
				//mvBankDetails.ActiveViewIndex = 1;
				m_intWorkersCompRWID = Convert.ToInt32(e.CommandArgument.ToString());
				ViewState["PK_Workers_Comp_RW_ID"] = Convert.ToInt32(e.CommandArgument.ToString());
			}
			if (e.CommandName == "EditItem")
			{
				dvClaimDetail.Style.Add("display", "block");
				mvWorkersRW.ActiveViewIndex = 1;
				Bindfv(FormViewMode.Edit);

			}
			else if (e.CommandName == "View")
			{
              
				dvClaimDetail.Style.Add("display", "block");
				mvWorkersRW.ActiveViewIndex = 1;
				Bindfv(FormViewMode.ReadOnly);
                btnNextStep.Visible = false;
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
	protected void gvWorkerRW_RowDataBound(object sender, GridViewRowEventArgs e)
	{

		if (e.Row.RowType == DataControlRowType.Header)
		{
			m_IndeResTot = 0.0M;
			m_MediResTot = 0.0M;
			m_ExpResTot = 0.0M;

            try
            {
                DataSet dstWCReserve = new DataSet();
                m_objWorkerRW = new RIMS_Base.Biz.cWorkerCompReserveWork();
                dstWCReserve = m_objWorkerRW.GetWCReserveHistoryLabel();
                for (int i = 0; i < dstWCReserve.Tables[0].Rows.Count; i++)
                {

                    if (dstWCReserve.Tables[0].Rows[i]["Control_Type"].ToString() == "GridView")
                    {
                        if (dstWCReserve.Tables[0].Rows[i]["Control_Name"].ToString() == "gvWorkerRW")
                        {
                            if (dstWCReserve.Tables[0].Rows[i]["caption"].ToString().Trim() != String.Empty)
                            {
                                int ColumnNo = Convert.ToInt32(dstWCReserve.Tables[0].Rows[i]["Label_Name"].ToString());
                                //((Label)e.Row.FindControl(dstWCReserve.Tables[0].Rows[i]["ViewAll_Label_Name"].ToString())).Text = dstWCReserve.Tables[0].Rows[i]["Caption"].ToString();
                                gvWorkerRW.Columns[ColumnNo].HeaderText = dstWCReserve.Tables[0].Rows[i]["Caption"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
		}

		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			m_IndeResTot += Convert.ToDecimal(e.Row.Cells[2].Text.ToString());
			m_MediResTot += Convert.ToDecimal(e.Row.Cells[3].Text.ToString());
			m_ExpResTot += Convert.ToDecimal(e.Row.Cells[4].Text.ToString());

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

	}
    protected void gvWorkerRW_RowCreated(object sender, GridViewRowEventArgs e)
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
        foreach (DataControlField field in gvWorkerRW.Columns)
        {
            if (field.SortExpression.ToString() == ViewState["SortExp"].ToString())
            {
                nRet = gvWorkerRW.Columns.IndexOf(field);
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

    private void GeneralSorting()
    {
        try
        {
            lstWorkerRW = new List<RIMS_Base.cWorkerCompReserveWork>();
            lstWorkerRW = BindWorkerRW();
            if (ViewState["SortExp"] != null && ViewState["sortDirection"] != null)
            {
                lstWorkerRW.Sort(new RIMS_Base.GenericComparer<RIMS_Base.cWorkerCompReserveWork>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
                strSortExp = ViewState["SortExp"].ToString();
            }
            gvWorkerRW.DataSource = lstWorkerRW;
            gvWorkerRW.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
	#endregion

	#region FormView
	/// <summary>
	/// Bind form view
	/// </summary>
	/// <param name="fvMode">Form View Mode</param>
	private void Bindfv(FormViewMode fvMode)
	{
		try
		{
			if (fvMode == FormViewMode.Insert)
				fvWorkersRW.ChangeMode(FormViewMode.Insert);
            else if (fvMode == FormViewMode.Edit)
            {
                fvWorkersRW.ChangeMode(FormViewMode.Edit);
                btnNextStep.Visible = false;
            }
            else if (fvMode == FormViewMode.ReadOnly)
         
                fvWorkersRW.ChangeMode(FormViewMode.ReadOnly);
                btnMail.Visible = false;
                btnRemove.Visible = false;
           
			if (fvMode != FormViewMode.Insert)
			{
				m_objWorkerRW = new RIMS_Base.Biz.cWorkerCompReserveWork();
				lstWorkerRW = new List<RIMS_Base.cWorkerCompReserveWork>();
				lstWorkerRW = m_objWorkerRW.Geters_Comp_RWByID(m_intWorkersCompRWID);
				fvWorkersRW.DataSource = lstWorkerRW;
			}
			fvWorkersRW.DataBind();
			BindClaimAndReservesData();
			if (fvMode != FormViewMode.Insert)
			{
				gvAttachmentDetails.DataSource = BindAttachmentDetails();
				gvAttachmentDetails.DataBind();
				dvAttachDetails.Style.Add("display", "block");
                if (fvMode != FormViewMode.Edit)
                {
                    btnRemove.Visible = false;
                    btnMail.Visible = false;
                }
                else
                {
                    btnRemove.Visible = true;
                    btnMail.Visible = true;
                }
            
			}
			else
			{
				ViewState["PK_Workers_Comp_RW_ID"] = null;
				gvAttachmentDetails.DataSource = BindAttachmentDetails();
				gvAttachmentDetails.DataBind();
				dvAttachDetails.Style.Add("display", "block");
                lstAttachment = BindAttachmentDetails();
             
			}
            if (fvMode == FormViewMode.ReadOnly)
            {
                gvAttachmentDetails.Columns[0].Visible = false;
            }
            else
            {

                if (lstAttachment.Count > 0)
                {
                    gvAttachmentDetails.DataSource = lstAttachment;
                    gvAttachmentDetails.DataBind();
                    //dispTagName.Value = "dvAttachDetails";
                    btnRemove.Visible = true;
                    btnMail.Visible = true;
                }
                else
                {
                    btnRemove.Visible = false;
                    btnMail.Visible = false;
                }
                gvAttachmentDetails.Columns[0].Visible = true;
            }
            // -- Display Dynamic Labels
            try
            {
                DataSet dstWCReserve = new DataSet();
                m_objWorkerRW = new RIMS_Base.Biz.cWorkerCompReserveWork();
                dstWCReserve = m_objWorkerRW.GetWCReserveHistoryLabel();
                for (int i = 0; i < dstWCReserve.Tables[0].Rows.Count; i++)
                {
                    if (dstWCReserve.Tables[0].Rows[i]["Control_Type"].ToString() == "Label")
                    {
                        if (dstWCReserve.Tables[0].Rows[i]["Control_Name"].ToString() == "fvWorkersRW")
                        {
                            if (dstWCReserve.Tables[0].Rows[i]["caption"].ToString().Trim() != String.Empty)
                                ((Label)fvWorkersRW.FindControl(dstWCReserve.Tables[0].Rows[i]["Label_Name"].ToString())).Text = dstWCReserve.Tables[0].Rows[i]["Caption"].ToString();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //throw ex;
            }

		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
		}
	}
	protected void fvWorkersRW_DataBound(object sender, EventArgs e)
	{
		try
		{
			List<RIMS_Base.CGeneral> lstGenereal = new List<RIMS_Base.CGeneral>();
			RIMS_Base.Biz.CGeneral objGeneral = new RIMS_Base.Biz.CGeneral();

			if (fvWorkersRW.CurrentMode != FormViewMode.ReadOnly)
			{
				((DropDownList)fvWorkersRW.FindControl("ddlAttachType")).DataSource = objGeneral.GetAttachamentType();
				((DropDownList)fvWorkersRW.FindControl("ddlAttachType")).DataTextField = "FLD_Desc";
				((DropDownList)fvWorkersRW.FindControl("ddlAttachType")).DataValueField = "FLD_Code";
				((DropDownList)fvWorkersRW.FindControl("ddlAttachType")).DataBind();
				((DropDownList)fvWorkersRW.FindControl("ddlAttachType")).Items.Insert(0, "--Select Attachment Type--");
                ((DropDownList)fvWorkersRW.FindControl("ddlAttachType")).SelectedIndex = 1;
            }
			if (fvWorkersRW.CurrentMode == FormViewMode.Insert)
				((TextBox)fvWorkersRW.FindControl("txtMTCDate")).Text = DateTime.Now.ToShortDateString();
			//if (fvWorkersRW.CurrentMode == FormViewMode.Edit)
			//{
			//    ((TextBox)fvWorkersRW.FindControl("txtExpenseTotal")).Enabled = false;
			//    ((TextBox)fvWorkersRW.FindControl("txtPerDisabilityTotal")).Enabled = false;
			//    ((TextBox)fvWorkersRW.FindControl("txtTPDTotal")).Enabled = false;
			//    ((TextBox)fvWorkersRW.FindControl("txtTTDTotal")).Enabled = false;
			//    ((TextBox)fvWorkersRW.FindControl("txtTotal")).Enabled = false;
			//}

		}
		catch (Exception ex)
		{

			throw;
		}
	}
	protected void btnCancel_Click(object sender, EventArgs e)
	{

		dvClaimDetail.Style.Add("display", "none");
		mvWorkersRW.ActiveViewIndex = 0;
        btnNextStep.Visible = true;
	}
	protected void btnSave_Click(object sender, EventArgs e)
	{
        btnNextStep.Visible = true;
		InsertUpdate();
        if (m_intRetval >= 0)
        {
            gvWorkerRW.DataSource = BindWorkerRW();
            gvWorkerRW.DataBind();
            dvClaimDetail.Style.Add("display", "none");
            mvWorkersRW.ActiveViewIndex = 0;
            btnRemove.Visible = true;
            btnMail.Visible = true;
        }
        else
        {
            btnRemove.Visible = false;
            btnMail.Visible = false;
        }
	}
	#region Insert Update
	private void InsertUpdate()
	{
		m_intRetval = -1;
		try
		{
			m_objWorkerRW = new RIMS_Base.Biz.cWorkerCompReserveWork();
			//if (fvWorkersRW.CurrentMode == FormViewMode.Insert)
			if (ViewState["PK_Workers_Comp_RW_ID"] != null && ViewState["PK_Workers_Comp_RW_ID"].ToString() != String.Empty)
			{
				m_objWorkerRW.PK_Workers_Comp_RW_ID = Convert.ToInt32(ViewState["PK_Workers_Comp_RW_ID"].ToString()); //Convert.ToInt32(((Label)fvWorkersRW.FindControl("lblPKWorkersCompRWID")).Text); ;
				m_objWorkerRW.Transaction_Date = Convert.ToDateTime(((TextBox)fvWorkersRW.FindControl("txtMTCDate")).Text);
			}
			else
			{
				m_objWorkerRW.PK_Workers_Comp_RW_ID = 0;
				m_objWorkerRW.Transaction_Date = DateTime.Now.Date; //Convert.ToDateTime(((TextBox)fvWorkersRW.FindControl("txtMTCDate")).Text, format);

			}
			m_objWorkerRW.Hospital = ((TextBox)fvWorkersRW.FindControl("txtHospital")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtHospital")).Text);
			m_objWorkerRW.Physician = ((TextBox)fvWorkersRW.FindControl("txtPhysician")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtPhysician")).Text);
			m_objWorkerRW.Radiology = ((TextBox)fvWorkersRW.FindControl("txtRadiology")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtRadiology")).Text);
			m_objWorkerRW.Pharmacy = ((TextBox)fvWorkersRW.FindControl("txtPharmacy")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtPharmacy")).Text);
			m_objWorkerRW.IME = ((TextBox)fvWorkersRW.FindControl("txtIME")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtIME")).Text);
			m_objWorkerRW.Anesthesiologist = ((TextBox)fvWorkersRW.FindControl("txtAnesthesiologist")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtAnesthesiologist")).Text);
			m_objWorkerRW.Nursing_Care = ((TextBox)fvWorkersRW.FindControl("txtNursingCare")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtNursingCare")).Text);
			m_objWorkerRW.Transportation = ((TextBox)fvWorkersRW.FindControl("txtTransportation")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtTransportation")).Text);
			m_objWorkerRW.Medical_Report = ((TextBox)fvWorkersRW.FindControl("txtMedicalReport")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtMedicalReport")).Text);
			m_objWorkerRW.Medical_Total =
				m_objWorkerRW.Hospital +
				m_objWorkerRW.Physician +
				m_objWorkerRW.Radiology +
				m_objWorkerRW.Pharmacy +
				m_objWorkerRW.IME +
				m_objWorkerRW.Anesthesiologist +
				m_objWorkerRW.Nursing_Care +
				m_objWorkerRW.Transportation +
				m_objWorkerRW.Medical_Report;
			//total
            if (m_objWorkerRW.Medical_Total != 0)
                ((Label)fvWorkersRW.FindControl("txtTotal")).Text = m_objWorkerRW.Medical_Total.ToString();
            else
                ((Label)fvWorkersRW.FindControl("txtTotal")).Text = "0.00";

			m_objWorkerRW.TTD_Payment = ((TextBox)fvWorkersRW.FindControl("txtTTDperweek")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtTTDperweek")).Text);
			m_objWorkerRW.TTD_Weeks = ((TextBox)fvWorkersRW.FindControl("txtTTDWeeks")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtTTDWeeks")).Text);
            m_objWorkerRW.TTD_Total = Convert.ToDecimal(m_objWorkerRW.TTD_Payment) * Convert.ToDecimal(m_objWorkerRW.TTD_Weeks);
			//ttdTotal 
            if (m_objWorkerRW.TTD_Total != 0)
                ((Label)fvWorkersRW.FindControl("txtTTDTotal")).Text = m_objWorkerRW.TTD_Total.ToString();
            else
                ((Label)fvWorkersRW.FindControl("txtTTDTotal")).Text = "0.00";

			m_objWorkerRW.TPD_Payment = ((TextBox)fvWorkersRW.FindControl("txtTPDperweek")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtTPDperweek")).Text);
			m_objWorkerRW.TPD_Weeks = ((TextBox)fvWorkersRW.FindControl("txtTPDWeeks")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtTPDWeeks")).Text);
            m_objWorkerRW.TPD_Total = Convert.ToDecimal(m_objWorkerRW.TPD_Payment) * Convert.ToDecimal(m_objWorkerRW.TPD_Weeks);
			//tpdTotal
            if (m_objWorkerRW.TPD_Total != 0)
                ((Label)fvWorkersRW.FindControl("txtTPDTotal")).Text = m_objWorkerRW.TPD_Total.ToString();
            else
                ((Label)fvWorkersRW.FindControl("txtTPDTotal")).Text = "0.00";

			m_objWorkerRW.Estimated_Award = ((TextBox)fvWorkersRW.FindControl("txtEstAward")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtEstAward")).Text);
			m_objWorkerRW.Death_Benefit = ((TextBox)fvWorkersRW.FindControl("txtDeathBenefit")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtDeathBenefit")).Text);
			m_objWorkerRW.Vocational_Rehab = ((TextBox)fvWorkersRW.FindControl("txtVocRehab")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtVocRehab")).Text);
			m_objWorkerRW.Funeral_Expense = ((TextBox)fvWorkersRW.FindControl("txtFuneralExp")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtFuneralExp")).Text);
			m_objWorkerRW.Disability_Total =
				m_objWorkerRW.Estimated_Award +
				m_objWorkerRW.Death_Benefit +
				m_objWorkerRW.Vocational_Rehab +
				m_objWorkerRW.Funeral_Expense;
			//total perdisa
            if (m_objWorkerRW.Disability_Total != 0)
                ((Label)fvWorkersRW.FindControl("txtPerDisabilityTotal")).Text = m_objWorkerRW.Disability_Total.ToString();
            else
                ((Label)fvWorkersRW.FindControl("txtPerDisabilityTotal")).Text = "0.00";

			m_objWorkerRW.Defense_Cost = ((TextBox)fvWorkersRW.FindControl("txtDefenseCost")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtDefenseCost")).Text);
			m_objWorkerRW.Medical_Case_Management = ((TextBox)fvWorkersRW.FindControl("txtMedicalCaseMgmt")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtMedicalCaseMgmt")).Text);
			m_objWorkerRW.Surveillance = ((TextBox)fvWorkersRW.FindControl("txtSurveillance")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtSurveillance")).Text);
			m_objWorkerRW.Court_Costs = ((TextBox)fvWorkersRW.FindControl("txtCourtCase")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtCourtCase")).Text);
			m_objWorkerRW.Depositions = ((TextBox)fvWorkersRW.FindControl("txtDiposition")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtDiposition")).Text);
			m_objWorkerRW.Expense_Other_1_Description = ((TextBox)fvWorkersRW.FindControl("txtOtherDesc1")).Text;
			m_objWorkerRW.Expense_Other_1 = ((TextBox)fvWorkersRW.FindControl("txtOtherExp1")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtOtherExp1")).Text);
			m_objWorkerRW.Expense_Other_2_Description = ((TextBox)fvWorkersRW.FindControl("txtOtherDesc2")).Text;
			m_objWorkerRW.Expense_Other_2 = ((TextBox)fvWorkersRW.FindControl("txtOtherExp2")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtOtherExp2")).Text);
			m_objWorkerRW.Expense_Other_3_Description = ((TextBox)fvWorkersRW.FindControl("txtOtherDesc3")).Text;
			m_objWorkerRW.Expense_Other_3 = ((TextBox)fvWorkersRW.FindControl("txtOtherExp3")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtOtherExp3")).Text);
			m_objWorkerRW.Bill_Review = ((TextBox)fvWorkersRW.FindControl("txtBillReview")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtBillReview")).Text);
			m_objWorkerRW.Expenses_Total =
				m_objWorkerRW.Defense_Cost +
				m_objWorkerRW.Medical_Case_Management +
				m_objWorkerRW.Surveillance +
				m_objWorkerRW.Court_Costs +
				m_objWorkerRW.Depositions +
				m_objWorkerRW.Expense_Other_1 +
				m_objWorkerRW.Expense_Other_2 +
				m_objWorkerRW.Expense_Other_3 +
				m_objWorkerRW.Bill_Review;
            if (m_objWorkerRW.Expenses_Total != 0)
                ((Label)fvWorkersRW.FindControl("txtExpenseTotal")).Text = m_objWorkerRW.Expenses_Total.ToString();
            else
                ((Label)fvWorkersRW.FindControl("txtExpenseTotal")).Text = "0.00";

			m_objWorkerRW.Updated_By = Session["UserID"].ToString();
			m_objWorkerRW.Update_Date = System.DateTime.Now.Date;
			m_objWorkerRW.FK_Workers_Comp = Convert.ToInt32(Session["WorkerCompID"].ToString());
			m_intRetval = m_objWorkerRW.InsertUpdate_RWComp(m_objWorkerRW);
			ViewState["PK_Workers_Comp_RW_ID"] = m_intRetval.ToString();
			if (m_intRetval >= 0)
			{
				//mvWorkersRW.ActiveViewIndex = 0;
				gvWorkerRW.DataSource = BindWorkerRW();
				gvWorkerRW.DataBind();
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
	#endregion
	#endregion

	#region Private Methods
	/// <summary>
	/// Bind Claim and Reserves information.
	/// </summary>
	private void BindClaimData()
	{
		try
		{
			lblClaimNumber.Text = lstClaimReservesInfo[0].Claim_Number;
			//lblEmployeeSSN.Text = lstClaimReservesInfo[0].EmployeeSSN;
			//lblIsEmployee.Text = lstClaimReservesInfo[0].Employee;
			lblLastName.Text = lstClaimReservesInfo[0].LastName;
			lblFirstName.Text = lstClaimReservesInfo[0].FirstName;
			lblMidleName.Text = lstClaimReservesInfo[0].MiddleName;
			lblIncidentDt.Text = lstClaimReservesInfo[0].IncidentDate;

			if (lstClaimReservesInfo[0].Employee == "Y")
				rbtnEmployee.Items[0].Selected = true;
			else if (lstClaimReservesInfo[0].Employee == "N")
				rbtnEmployee.Items[1].Selected = true;
			//lblIInccured.Text = lstClaimReservesInfo[0].Incurred_Indemnity.ToString();
			//lblIPaid.Text = lstClaimReservesInfo[0].PAID_INDEMNITY.ToString();
			//lblIOutStand.Text = lstClaimReservesInfo[0].Outstanding_INDEMNITY.ToString();
			//lblMInccured.Text = lstClaimReservesInfo[0].Incurred_Medical.ToString();
			//lblMPaid.Text = lstClaimReservesInfo[0].PAID_Medical.ToString();
			//lblMOutStand.Text = lstClaimReservesInfo[0].Outstanding_Medical.ToString();
			//lblEInccured.Text = lstClaimReservesInfo[0].Incurred_Expense.ToString();
			//lblEPaid.Text = lstClaimReservesInfo[0].PAID_Expense.ToString();
			//lblEOutStand.Text = lstClaimReservesInfo[0].Outstanding_Expense.ToString();
			//lblOSTotal.Text = (Convert.ToDecimal(lblIOutStand.Text) + Convert.ToDecimal(lblMOutStand.Text) + Convert.ToDecimal(lblEOutStand.Text)).ToString();
		}
		catch (Exception ex)
		{
		}
	}
	/// <summary>
	/// Bind the Claim information and Reserves information
	/// </summary>
	private void BindClaimAndReservesData()
	{
		try
		{
			RIMS_Base.Biz.cWorkerComp objWorkerComp = new RIMS_Base.Biz.cWorkerComp();
			List<RIMS_Base.cWorkerComp> lstWorkerComp = new List<RIMS_Base.cWorkerComp>();
			lstWorkerComp = objWorkerComp.GetWorkerCompByID(Convert.ToInt32(Session["WorkerCompID"].ToString()));
			string Claim_No = lstWorkerComp[0].Claim_Number;
			m_objClaimReservesInfo = new RIMS_Base.Biz.cWorkerCompReserveWork();
			lstClaimReservesInfo = new List<RIMS_Base.cWorkerCompReserveWork>();
			lstClaimReservesInfo = m_objClaimReservesInfo.GetClaimInfoByClaimNo(Claim_No);
			BindClaimData();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
	#endregion

	protected void mvWorkersRW_ActiveViewChanged(object sender, EventArgs e)
	{

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
            
            // ---    Display Total Fields.

            Decimal Defense_Cost = ((TextBox)fvWorkersRW.FindControl("txtDefenseCost")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtDefenseCost")).Text);
            Decimal Medical_Case_Management = ((TextBox)fvWorkersRW.FindControl("txtMedicalCaseMgmt")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtMedicalCaseMgmt")).Text);
            Decimal Surveillance = ((TextBox)fvWorkersRW.FindControl("txtSurveillance")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtSurveillance")).Text);
            Decimal Court_Costs = ((TextBox)fvWorkersRW.FindControl("txtCourtCase")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtCourtCase")).Text);
            Decimal Depositions = ((TextBox)fvWorkersRW.FindControl("txtDiposition")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtDiposition")).Text);            
            Decimal Expense_Other_1 = ((TextBox)fvWorkersRW.FindControl("txtOtherExp1")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtOtherExp1")).Text);            
            Decimal Expense_Other_2 = ((TextBox)fvWorkersRW.FindControl("txtOtherExp2")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtOtherExp2")).Text);            
            Decimal Expense_Other_3 = ((TextBox)fvWorkersRW.FindControl("txtOtherExp3")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtOtherExp3")).Text);
            Decimal Bill_Review = ((TextBox)fvWorkersRW.FindControl("txtBillReview")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtBillReview")).Text);
            Decimal Expenses_Total =
                Defense_Cost + Medical_Case_Management + Surveillance + Court_Costs +
                Depositions + Expense_Other_1 + Expense_Other_2 + Expense_Other_3 + Bill_Review;
            if (Expenses_Total != 0)
                ((Label)fvWorkersRW.FindControl("txtExpenseTotal")).Text = Expenses_Total.ToString();
            else
                ((Label)fvWorkersRW.FindControl("txtExpenseTotal")).Text = "0.00";


            Decimal Estimated_Award = ((TextBox)fvWorkersRW.FindControl("txtEstAward")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtEstAward")).Text);
            Decimal Death_Benefit = ((TextBox)fvWorkersRW.FindControl("txtDeathBenefit")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtDeathBenefit")).Text);
            Decimal Vocational_Rehab = ((TextBox)fvWorkersRW.FindControl("txtVocRehab")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtVocRehab")).Text);
            Decimal Funeral_Expense = ((TextBox)fvWorkersRW.FindControl("txtFuneralExp")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtFuneralExp")).Text);
            Decimal Disability_Total =
                Estimated_Award + Death_Benefit +  Vocational_Rehab + Funeral_Expense;
            if (Disability_Total != 0)
                ((Label)fvWorkersRW.FindControl("txtPerDisabilityTotal")).Text = Disability_Total.ToString();
            else
                ((Label)fvWorkersRW.FindControl("txtPerDisabilityTotal")).Text = "0.00";


            Decimal TPD_Payment = ((TextBox)fvWorkersRW.FindControl("txtTPDperweek")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtTPDperweek")).Text);
            Decimal TPD_Weeks = ((TextBox)fvWorkersRW.FindControl("txtTPDWeeks")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtTPDWeeks")).Text);
            Decimal TPD_Total = TPD_Payment * TPD_Weeks;
            if (TPD_Total != 0)
                ((Label)fvWorkersRW.FindControl("txtTPDTotal")).Text = TPD_Total.ToString();
            else
                ((Label)fvWorkersRW.FindControl("txtTPDTotal")).Text = "0.00";


            Decimal TTD_Payment = ((TextBox)fvWorkersRW.FindControl("txtTTDperweek")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtTTDperweek")).Text);
            Decimal TTD_Weeks = ((TextBox)fvWorkersRW.FindControl("txtTTDWeeks")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtTTDWeeks")).Text);
            Decimal TTD_Total = TTD_Payment * TTD_Weeks;
            if (TTD_Total != 0)
                ((Label)fvWorkersRW.FindControl("txtTTDTotal")).Text = TTD_Total.ToString();
            else
                ((Label)fvWorkersRW.FindControl("txtTTDTotal")).Text = "0.00";


            Decimal Hospital = ((TextBox)fvWorkersRW.FindControl("txtHospital")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtHospital")).Text);
            Decimal Physician = ((TextBox)fvWorkersRW.FindControl("txtPhysician")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtPhysician")).Text);
            Decimal Radiology = ((TextBox)fvWorkersRW.FindControl("txtRadiology")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtRadiology")).Text);
            Decimal Pharmacy = ((TextBox)fvWorkersRW.FindControl("txtPharmacy")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtPharmacy")).Text);
            Decimal IME = ((TextBox)fvWorkersRW.FindControl("txtIME")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtIME")).Text);
            Decimal Anesthesiologist = ((TextBox)fvWorkersRW.FindControl("txtAnesthesiologist")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtAnesthesiologist")).Text);
            Decimal Nursing_Care = ((TextBox)fvWorkersRW.FindControl("txtNursingCare")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtNursingCare")).Text);
            Decimal Transportation = ((TextBox)fvWorkersRW.FindControl("txtTransportation")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtTransportation")).Text);
            Decimal Medical_Report = ((TextBox)fvWorkersRW.FindControl("txtMedicalReport")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtMedicalReport")).Text);
            Decimal Medical_Total =
                Hospital + Physician + Radiology + Pharmacy + IME + Anesthesiologist +
                Nursing_Care + Transportation + Medical_Report;

            if (Medical_Total != 0)
                ((Label)fvWorkersRW.FindControl("txtTotal")).Text = Medical_Total.ToString();
            else
                ((Label)fvWorkersRW.FindControl("txtTotal")).Text = "0.00";
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
	#region View All records
	private void ViewAllRecords()
	{
		mainContent.Style["width"] = "99%";
		leftdiv.Style["display"] = "none";
		dvClaimDetail.Style["display"] = "block";
		dvOutstanding.Style["display"] = "block";
		dvViewAll.Style["display"] = "block";
		dvAttachment.Style["display"] = "block";
		dvPaymentDetails.Style["display"] = "block";

		// Claim and reserve data
		BindClaimAndReservesData();
		lblIOutStand.Text = lstClaimReservesInfo[0].Outstanding_INDEMNITY.ToString();
		lblMOutStand.Text = lstClaimReservesInfo[0].Outstanding_Medical.ToString();
		lblEOutStand.Text = lstClaimReservesInfo[0].Outstanding_Expense.ToString();
		lblOSTotal.Text = (Convert.ToDecimal(lblIOutStand.Text) + Convert.ToDecimal(lblMOutStand.Text) + Convert.ToDecimal(lblEOutStand.Text)).ToString();

		//gvViewAll all records
		gvViewAll.DataSource = BindWorkerRW();
		gvViewAll.AllowPaging = false;
		gvViewAll.AllowSorting = false;
		gvViewAll.DataBind();
		ddlPage.SelectedIndex = 2;

		//PaymentDetails
		BindPaymentDetails();
		//Attachment
		gvViewAttachment.DataSource = BindAttachmentDetails();
		gvViewAttachment.DataBind();
        gvViewAttachment.Columns[0].Visible = false;
	}
	protected void gvViewAll_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		//if (e.Row.RowType == DataControlRowType.Header)
		//{
		//    m_IndeResTot = 0.0M;
		//    m_MediResTot = 0.0M;
		//    m_ExpResTot = 0.0M;
		//}

		//if (e.Row.RowType == DataControlRowType.DataRow)
		//{
		//    m_IndeResTot += Convert.ToDecimal(e.Row.Cells[2].Text.ToString());
		//    m_MediResTot += Convert.ToDecimal(e.Row.Cells[3].Text.ToString());
		//    m_ExpResTot += Convert.ToDecimal(e.Row.Cells[4].Text.ToString());
		//}

        // -- Display Dynamic Labels
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataSet dstWCReserve = new DataSet();
                m_objWorkerRW = new RIMS_Base.Biz.cWorkerCompReserveWork();
                dstWCReserve = m_objWorkerRW.GetWCReserveHistoryLabel();
                for (int i = 0; i < dstWCReserve.Tables[0].Rows.Count; i++)
                {

                    if (dstWCReserve.Tables[0].Rows[i]["Control_Type"].ToString() == "Label")
                    {
                        if (dstWCReserve.Tables[0].Rows[i]["Control_Name"].ToString() == "fvWorkersRW")
                        {
                            if (dstWCReserve.Tables[0].Rows[i]["caption"].ToString().Trim() != String.Empty)
                                ((Label)e.Row.FindControl(dstWCReserve.Tables[0].Rows[i]["ViewAll_Label_Name"].ToString())).Text = dstWCReserve.Tables[0].Rows[i]["Caption"].ToString();
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
	protected void gvViewAttachment_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		try
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				((ImageButton)e.Row.FindControl("imgbtnDwnld")).Attributes.Add("onclick", "javascript:return openWindow('" + m_strGlobalPath + "/" + ((ImageButton)e.Row.FindControl("imgbtnDwnld")).CommandArgument.ToString() + "');");
				//((ImageButton)e.Row.FindControl("imgbtnMail")).Attributes.Add("onclick", "javascript:return openMailWindow('../ErimsMail.aspx?AttMod=" + m_strFolderName + "&AttName=" + ((ImageButton)e.Row.FindControl("imgbtnMail")).CommandArgument.ToString() + "');");
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	#endregion
	#region Payment Details
	private void BindPaymentDetails()
	{
		try
		{
			m_objWorkerRW = new RIMS_Base.Biz.cWorkerCompReserveWork();
			dsPayment = new DataSet();
			dsPayment = m_objWorkerRW.GetPaymentRecords(Convert.ToDecimal(Session["WorkerCompID"].ToString()));
			gvPaymentDetails.DataSource = dsPayment;
			gvPaymentDetails.AllowPaging = false;
			gvPaymentDetails.DataBind();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
	protected void gvPaymentDetails_Sorting(object sender, GridViewSortEventArgs e)
	{
		try
		{
			//dsPayment = new DataSet();
			//if (ViewState["sortDirection"] == null)
			//    ViewState["sortDirection"] = SortDirection.Ascending;
			//// Changes the sort direction 
			//else
			//{
			//    if (((SortDirection)ViewState["sortDirection"]) == SortDirection.Ascending)
			//        ViewState["sortDirection"] = SortDirection.Descending;
			//    else
			//        ViewState["sortDirection"] = SortDirection.Ascending;
			//}
			//ViewState["SortExp"] = e.SortExpression;

			//dsPayment= BindWorkerRW();
			//if (ViewState["SortExp"] != null)
			//    lstWorkerRW.Sort(new RIMS_Base.GenericComparer<RIMS_Base.cWorkerCompReserveWork>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
			//gvWorkerRW.DataSource = lstWorkerRW;
			//gvWorkerRW.DataBind();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
	#endregion
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
