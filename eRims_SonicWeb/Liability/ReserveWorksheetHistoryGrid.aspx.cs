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
using System.Globalization;
using RIMS_Base;
using RIMS_Base.Biz;
using System.IO;
public partial class Liability_ReserveWorksheetHistoryGrid : System.Web.UI.Page
{
	#region private variables
	public RIMS_Base.Biz.cLiabilityReserveWorkHistory m_objWorkerRW;
	List<RIMS_Base.cLiabilityReserveWorkHistory> lstWorkerRW = null;
	RIMS_Base.Biz.CLiabilityClaim objWorkerComp;
	List<RIMS_Base.CLiabilityClaim> lstWorkerComp = null;
	int m_intWorkersCompRWID = 0;
	IFormatProvider format = new CultureInfo("en-US");
	List<RIMS_Base.cLiabilityReserveWorkHistory> lstClaimReservesInfo = null;
	public RIMS_Base.Biz.cLiabilityReserveWorkHistory m_objClaimReservesInfo;

	// -- Attachment
	public string m_strCustomFileName = string.Empty;
	public string m_strFileName = string.Empty;
	public string m_strGlobalPath = string.Empty;
	public string m_strPath = string.Empty;
	public string m_strFolderName = "Liability_Claim_RW";
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
				if (Session["ViewAll"] != null && Session["ViewAll"].ToString() != String.Empty)
				{
					ViewAllRecords();
				}
				else
				{
					ViewState.Clear();
					BindClaimAndReservesData();
					lbtnClaimDetail.Style.Add("CssClass", "left_menu_active");
					lbtnRHistory.Style.Add("CssClass", "left_menu");
					lbtnOutstanding.Style.Add("CssClass", "left_menu");
					dvClaimDetail.Style.Add("display", "block");
					dvReserveHistory.Style.Add("display", "none");
					dvOutstanding.Style.Add("display", "none");

					gvWorkerRW.DataSource = BindWorkerRW();
					lblRWTotal.Text = "Total Reserve Worksheets : " + BindWorkerRW().Count.ToString();
					gvWorkerRW.PageSize = 10;
					gvWorkerRW.DataBind();
					ddlPage.SelectedIndex = 2;
					mvWorkersRW.ActiveViewIndex = 0;
					lblPageInfo.Text = "Page " + Convert.ToString(gvWorkerRW.PageIndex + 1) + " of " + gvWorkerRW.PageCount.ToString();
				}
			}
		}
		catch (Exception ex)
		{
			throw ex;
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
	//protected void btnAddSubrogation_Click1(object sender, EventArgs e)
	//{
	//    // mvReserverWrkSht.ActiveViewIndex = 2;
	//}

	protected void btnNextStep_Click(object sender, EventArgs e)
	{
        Response.Redirect("../Claim/Subrogation.aspx");
	}
	protected void Button1_Click(object sender, EventArgs e)
	{
        Response.Redirect("../Claim/Subrogation.aspx");
	}
	protected void btnBackView_Click(object sender, EventArgs e)
	{
		mvWorkersRW.ActiveViewIndex = 0;
	}


	#region Left Menu (Vertical menu)
	protected void lbtnClaimDetail_Click(object sender, EventArgs e)
	{
		lbtnClaimDetail.CssClass = "left_menu_active";
		lbtnRHistory.CssClass = "left_menu";
		lbtnOutstanding.CssClass = "left_menu";

		dvClaimDetail.Style.Add("display", "block");
		dvReserveHistory.Style.Add("display", "none");
		dvOutstanding.Style.Add("display", "none");

	}
	protected void lbtnRHistory_Click(object sender, EventArgs e)
	{
		lbtnClaimDetail.CssClass = "left_menu";
		lbtnRHistory.CssClass = "left_menu_active";
		lbtnOutstanding.CssClass = "left_menu";
		dvClaimDetail.Style.Add("display", "none");
		dvReserveHistory.Style.Add("display", "block");
		dvOutstanding.Style.Add("display", "none");
		mvWorkersRW.ActiveViewIndex = 0;
	}
	protected void lbtnOutstanding_Click(object sender, EventArgs e)
	{
		lbtnClaimDetail.CssClass = "left_menu";
		lbtnRHistory.CssClass = "left_menu";
		lbtnOutstanding.CssClass = "left_menu_active";
		dvClaimDetail.Style.Add("display", "none");
		dvReserveHistory.Style.Add("display", "none");
		dvOutstanding.Style.Add("display", "block");

		lblIOutStand.Text = m_IndeResTot.ToString();
		lblMOutStand.Text = m_MediResTot.ToString();
		lblEOutStand.Text = m_ExpResTot.ToString();
		lblOSTotal.Text = Convert.ToString(m_IndeResTot + m_MediResTot + m_ExpResTot);
	}
	#endregion

	#region Attachment
	private List<RIMS_Base.CAttachment> BindAttachmentDetails()
	{
		try
		{
			m_objAttachment = new RIMS_Base.Biz.CAttachment();
			lstAttachment = new List<RIMS_Base.CAttachment>();
			if (ViewState["PK_Liability_Claim_RW_ID"] != null && ViewState["PK_Liability_Claim_RW_ID"].ToString() != "")
				lstAttachment = m_objAttachment.GetAll(0, Convert.ToInt32(ViewState["PK_Liability_Claim_RW_ID"].ToString()), "Workers_Comp_RW");
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
					btnRemove.Visible = true;
				else
					btnRemove.Visible = false;
			}
			dvAttachDetails.Visible = true;

			//dvAttachDetails.Style["display"] = "block";
			//divAttachment.Style["display"] = "block";
			//divClaimDetail.Style["display"] = "none";
			//divInsurance.Style["display"] = "none";

			//hdnTagName.Value = "third";
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
	protected void btnAddAttachment_Click(object sender, EventArgs e)
	{
		try
		{
			Page.Validate();
			if (ViewState["PK_Liability_Claim_RW_ID"] == null)
			{
				InsertUpdate();
			}
			AddAttachment();
			if (Attach_Retval > 0)
			{
				gvAttachmentDetails.DataSource = BindAttachmentDetails();
				gvAttachmentDetails.DataBind();
			}
			((TextBox)fvWorkersRW.FindControl("txtAttachDesc")).Text = "";
			((DropDownList)fvWorkersRW.FindControl("ddlAttachType")).SelectedIndex = 0;

			dvAttachDetails.Style["display"] = "block";
			dvReserveHistory.Style["display"] = "block";
		}
		catch (Exception ex)
		{

			throw;
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
			m_objAttachment.Attachment_Table = "Liability_Claim_RW";
			m_objAttachment.Foreign_Key = Convert.ToInt32(ViewState["PK_Liability_Claim_RW_ID"].ToString());
			m_objAttachment.FK_Attachment_Type = Convert.ToInt32(((DropDownList)fvWorkersRW.FindControl("ddlAttachType")).SelectedValue);
			m_objAttachment.Attachment_Description = ((TextBox)fvWorkersRW.FindControl("txtAttachDesc")).Text.Replace("'", "''");
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
	#endregion

	#region Gridview
	protected void btnAddNew_Click(object sender, EventArgs e)
	{
		try
		{
			dvClaimDetail.Style.Add("display", "block");
			mvWorkersRW.ActiveViewIndex = 1;
			Bindfv(FormViewMode.Insert);
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
			m_objWorkerRW = new RIMS_Base.Biz.cLiabilityReserveWorkHistory();
			//  m_intRetval = m_objWorkerRW.Deleteility_Claim_RW(Request.Form["chkItem"].ToString());
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
			// lblRWTotal.Text = "Total Reserve Worksheets : " + BindWorkerRW().Count.ToString(); ;
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
	/// <summary>
	/// Get the All WorkersComp Reserve Worksheets
	/// </summary>
	private List<RIMS_Base.cLiabilityReserveWorkHistory> BindWorkerRW()
	{
		try
		{
			m_objWorkerRW = new RIMS_Base.Biz.cLiabilityReserveWorkHistory();
			lstWorkerRW = new List<RIMS_Base.cLiabilityReserveWorkHistory>();
			//lstWorkerRW = m_objWorkerRW.GetAll(true);
			//  lstWorkerRW = m_objWorkerRW.Workers_Comp_RWRecords(Convert.ToDecimal(Session["WorkerCompID"].ToString()));


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
			lstWorkerRW = new List<RIMS_Base.cLiabilityReserveWorkHistory>();
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

			lstWorkerRW = BindWorkerRW();
			if (ViewState["SortExp"] != null)
				lstWorkerRW.Sort(new RIMS_Base.GenericComparer<RIMS_Base.cLiabilityReserveWorkHistory>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
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
				ViewState["PK_Liability_Claim_RW_ID"] = Convert.ToInt32(e.CommandArgument.ToString());
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
		}

		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			m_IndeResTot += Convert.ToDecimal(e.Row.Cells[2].Text.ToString());
			m_MediResTot += Convert.ToDecimal(e.Row.Cells[3].Text.ToString());
			m_ExpResTot += Convert.ToDecimal(e.Row.Cells[4].Text.ToString());
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
				fvWorkersRW.ChangeMode(FormViewMode.Edit);
			else if (fvMode == FormViewMode.ReadOnly)
				fvWorkersRW.ChangeMode(FormViewMode.ReadOnly);
			if (fvMode != FormViewMode.Insert)
			{
				m_objWorkerRW = new RIMS_Base.Biz.cLiabilityReserveWorkHistory();
				lstWorkerRW = new List<RIMS_Base.cLiabilityReserveWorkHistory>();
				//   lstWorkerRW = m_objWorkerRW.Geters_Comp_RWByID(m_intWorkersCompRWID);
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
					btnRemove.Style["display"] = "none";
			}
			else
			{
				ViewState["PK_Liability_Claim_RW_ID"] = null;
				gvAttachmentDetails.DataSource = BindAttachmentDetails();
				gvAttachmentDetails.DataBind();
				dvAttachDetails.Style.Add("display", "block");
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
	}
	protected void btnSave_Click(object sender, EventArgs e)
	{
		InsertUpdate();
		if (m_intRetval >= 0)
		{
			gvWorkerRW.DataSource = BindWorkerRW();
			gvWorkerRW.DataBind();
			dvClaimDetail.Style.Add("display", "none");
			mvWorkersRW.ActiveViewIndex = 0;
		}
	}
	#region Insert Update
	private void InsertUpdate()
	{
		m_intRetval = -1;
		try
		{
			m_objWorkerRW = new RIMS_Base.Biz.cLiabilityReserveWorkHistory();
			//if (fvWorkersRW.CurrentMode == FormViewMode.Insert)
			if (ViewState["PK_Liability_Claim_RW_ID"] != null && ViewState["PK_Liability_Claim_RW_ID"].ToString() != String.Empty)
			{
				m_objWorkerRW.PK_Liability_Claim_RW_ID = Convert.ToInt32(ViewState["PK_Liability_Claim_RW_ID"].ToString()); //Convert.ToInt32(((Label)fvWorkersRW.FindControl("lblPKWorkersCompRWID")).Text); ;
				// m_objWorkerRW.Transaction_Date = Convert.ToDateTime(((TextBox)fvWorkersRW.FindControl("txtMTCDate")).Text);
			}
			else
			{
				m_objWorkerRW.PK_Liability_Claim_RW_ID = 0;
				// m_objWorkerRW.Transaction_Date = DateTime.Now.Date; //Convert.ToDateTime(((TextBox)fvWorkersRW.FindControl("txtMTCDate")).Text, format);

			}
			/**     m_objWorkerRW.Medical_Total = ((TextBox)fvWorkersRW.FindControl("txtHospital")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtHospital")).Text);
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
				 m_objWorkerRW.TTD_Payment = ((TextBox)fvWorkersRW.FindControl("txtTTDperweek")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtTTDperweek")).Text);
				 m_objWorkerRW.TTD_Weeks = ((TextBox)fvWorkersRW.FindControl("txtTTDWeeks")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtTTDWeeks")).Text);
				 m_objWorkerRW.TTD_Total = m_objWorkerRW.TTD_Payment * m_objWorkerRW.TTD_Weeks;
				 //ttdTotal 
				 m_objWorkerRW.TPD_Payment = ((TextBox)fvWorkersRW.FindControl("txtTPDperweek")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtTPDperweek")).Text);
				 m_objWorkerRW.TPD_Weeks = ((TextBox)fvWorkersRW.FindControl("txtTPDWeeks")).Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtTPDWeeks")).Text);
				 m_objWorkerRW.TPD_Total = m_objWorkerRW.TPD_Payment * m_objWorkerRW.TPD_Weeks;
				 //tpdTotal
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
			 * 
			 **/

			//m_objWorkerRW.Hospital = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtHospital")).Text);
			//m_objWorkerRW.Physician = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtPhysician")).Text);
			//m_objWorkerRW.Radiology = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtRadiology")).Text);
			//m_objWorkerRW.Pharmacy = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtPharmacy")).Text);
			//m_objWorkerRW.IME = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtIME")).Text);
			//m_objWorkerRW.Anesthesiologist = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtAnesthesiologist")).Text);
			//m_objWorkerRW.Nursing_Care = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtNursingCare")).Text);
			//m_objWorkerRW.Transportation = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtTransportation")).Text);
			//m_objWorkerRW.Medical_Report = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtMedicalReport")).Text);
			//m_objWorkerRW.Medical_Total = Convert.ToDecimal(((Label)fvWorkersRW.FindControl("txtTotal")).Text);
			//m_objWorkerRW.TTD_Payment = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtTTDperweek")).Text);
			//m_objWorkerRW.TTD_Weeks = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtTTDWeeks")).Text);
			//m_objWorkerRW.TTD_Total = Convert.ToDecimal(((Label)fvWorkersRW.FindControl("txtTTDTotal")).Text);
			//m_objWorkerRW.TPD_Payment = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtTPDperweek")).Text);
			//m_objWorkerRW.TPD_Weeks = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtTPDWeeks")).Text);
			//m_objWorkerRW.TPD_Total = Convert.ToDecimal(((Label)fvWorkersRW.FindControl("txtTPDTotal")).Text);
			//m_objWorkerRW.Estimated_Award = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtEstAward")).Text);
			//m_objWorkerRW.Death_Benefit = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtDeathBenefit")).Text);
			//m_objWorkerRW.Vocational_Rehab = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtVocRehab")).Text);
			//m_objWorkerRW.Funeral_Expense = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtFuneralExp")).Text);
			//m_objWorkerRW.Disability_Total = Convert.ToDecimal(((Label)fvWorkersRW.FindControl("txtPerDisabilityTotal")).Text);
			//m_objWorkerRW.Defense_Cost = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtDefenseCost")).Text);
			//m_objWorkerRW.Medical_Case_Management = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtMedicalCaseMgmt")).Text);
			//m_objWorkerRW.Surveillance = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtSurveillance")).Text);
			//m_objWorkerRW.Court_Costs = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtCourtCase")).Text);
			//m_objWorkerRW.Depositions = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("")).Text);
			//m_objWorkerRW.Expense_Other_1_Description = ((TextBox)fvWorkersRW.FindControl("txtOtherDesc1")).Text;
			//m_objWorkerRW.Expense_Other_1 = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtOtherExp1")).Text);
			//m_objWorkerRW.Expense_Other_2_Description = ((TextBox)fvWorkersRW.FindControl("txtOtherDesc2")).Text;
			//m_objWorkerRW.Expense_Other_2 = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtOtherExp2")).Text);
			//m_objWorkerRW.Expense_Other_3_Description = ((TextBox)fvWorkersRW.FindControl("txtOtherDesc3")).Text;
			//m_objWorkerRW.Expense_Other_3 = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtOtherExp3")).Text);
			//m_objWorkerRW.Expenses_Total = Convert.ToDecimal(((Label)fvWorkersRW.FindControl("txtExpenseTotal")).Text);
			//m_objWorkerRW.Bill_Review = Convert.ToDecimal(((TextBox)fvWorkersRW.FindControl("txtBillReview")).Text);
			//m_objWorkerRW.Expenses_Total = Convert.ToDecimal(((Label)fvWorkersRW.FindControl("txtExpenseTotal")).Text);
			m_objWorkerRW.Updated_By = "1";
			m_objWorkerRW.Update_Date = System.DateTime.Now.Date;
			m_objWorkerRW.PK_Liability_Claim_RW_ID = Convert.ToInt32(Session["WorkerCompID"].ToString());
            m_intRetval = m_objWorkerRW.InsertUpdate_RWComp(m_objWorkerRW);//InsertUpdateility_Claim_RW
			ViewState["PK_Liability_Claim_RW_ID"] = m_intRetval.ToString();
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
			/**   lblClaimNumber.Text = lstClaimReservesInfo[0].Claim_Number;
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
			   lblIOutStand.Text = lstClaimReservesInfo[0].Outstanding_INDEMNITY.ToString();
			   //lblMInccured.Text = lstClaimReservesInfo[0].Incurred_Medical.ToString();
			   //lblMPaid.Text = lstClaimReservesInfo[0].PAID_Medical.ToString();
			   lblMOutStand.Text = lstClaimReservesInfo[0].Outstanding_Medical.ToString();
			   //lblEInccured.Text = lstClaimReservesInfo[0].Incurred_Expense.ToString();
			   //lblEPaid.Text = lstClaimReservesInfo[0].PAID_Expense.ToString();
			   lblEOutStand.Text = lstClaimReservesInfo[0].Outstanding_Expense.ToString();
			   lblOSTotal.Text = (Convert.ToDecimal(lblIOutStand.Text) + Convert.ToDecimal(lblMOutStand.Text) + Convert.ToDecimal(lblEOutStand.Text)).ToString();
			 **/

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
			RIMS_Base.Biz.CLiabilityClaim objWorkerComp = new RIMS_Base.Biz.CLiabilityClaim();
			List<RIMS_Base.CLiabilityClaim> lstWorkerComp = new List<RIMS_Base.CLiabilityClaim>();
			//  lstWorkerComp = objWorkerComp.GetWorkerCompByID(Convert.ToInt32(Session["WorkerCompID"].ToString()));
			string Claim_No = lstWorkerComp[0].Claim_Number;
			m_objClaimReservesInfo = new RIMS_Base.Biz.cLiabilityReserveWorkHistory();
			lstClaimReservesInfo = new List<RIMS_Base.cLiabilityReserveWorkHistory>();
			//   lstClaimReservesInfo = m_objClaimReservesInfo.GetClaimInfoByClaimNo(Claim_No);
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

#region View All records
	private void ViewAllRecords()
	{
		mainContent.Style["width"] = "99%";
		leftdiv.Style["display"] = "none";
		dvClaimDetail.Style["display"] = "block";
		dvOutstanding.Style["display"] = "block";
		dvViewAll.Style["display"] = "block";
		dvAttachment.Style["display"] = "block";


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

		//Attachment
		gvViewAttachment.DataSource = BindAttachmentDetails();
		gvViewAttachment.DataBind();
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

}
