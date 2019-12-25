using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.IO;
using System.Data;

public partial class SONIC_Exposures_MaintenanceAddAttachment : System.Web.UI.Page
{
    #region "Properties"

    /// <summary>
    /// Denotes Location ID to be used as FK
    /// </summary>
    private int FK_Maintenance_Item
    {
        get { return Convert.ToInt32(ViewState["FK_Maintenance_Item"]); }
        set { ViewState["FK_Maintenance_Item"] = value; }
    }

    /// <summary>
    /// Denotes Location ID to be used as FK
    /// </summary>
    private string Table_Name
    {
        get { return Convert.ToString(ViewState["Table_Name"]); }
        set { ViewState["Table_Name"] = value; }
    }

    public DataTable dtAttachment_FacilityMaintenance
    {
        get
        {
            DataTable dtTemp1 = new DataTable("Attachment");
            if (ViewState["dtAttachment"] == null)
            {
                dtTemp1.Columns.Add("PK_Attachment_Id");
                dtTemp1.Columns.Add("Attachment_Table");
                dtTemp1.Columns.Add("Attachment_Name");
                dtTemp1.Columns.Add("Attachment_Description");
                dtTemp1.Columns.Add("AttachedBy");
            }
            else
            {
                dtTemp1 = (DataTable)ViewState["dtAttachment"];
            }
            return dtTemp1;
        }
        set
        {
            ViewState["dtAttachment"] = value;
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Table_Name = "Facility_Construction_Inspection_Item";
            if (Request.QueryString["item"] != null)
            {
                int item;
                if (int.TryParse(Request.QueryString["item"], out item))
                {
                    FK_Maintenance_Item = item;
                }
            }

            if (Request.QueryString["table"] != null && !string.IsNullOrEmpty(Convert.ToString(Request.QueryString["table"])))
            {
                Table_Name = Convert.ToString(Request.QueryString["table"]);
            }
            else
            {
                BindAttachmentGrid();
            }
        }
        dtAttachment_FacilityMaintenance = (DataTable)Session["dtAttachment"];
    }

    /// <summary>
    /// Handles Continue button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        if (FK_Maintenance_Item != 0)
        {
            //set values to store in database
            ERIMSAttachment objAttachment = new ERIMSAttachment();
            objAttachment.Attachment_Table = Table_Name;
            objAttachment.Foreign_Key = FK_Maintenance_Item;
            objAttachment.FK_Attachment_Type = 0;
            objAttachment.Updated_By = clsSession.UserID;
            objAttachment.Update_Date = DateTime.Today;
            // upload the document
            string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[(int)clsGeneral.Tables.Maintenance]);
            string DocPath = string.Concat(strUploadPath, "\\");
            // upload and set the filename.
            objAttachment.Attachment_Name = objAttachment.Attachment_Description = clsGeneral.UploadFile(fpFile, DocPath, false, false);
            objAttachment.Insert();
            ScriptManager.RegisterStartupScript(this, GetType(), "openAttachmentPoppup", "javascript:alert('Attachment Saved successfully.'); ClosePage();", true);
        }
        else
        {
            DataTable dtTemp = dtAttachment_FacilityMaintenance;
            DataRow drAttachment = dtTemp.NewRow();
            drAttachment["PK_Attachment_Id"] = 0;
            drAttachment["Attachment_Table"] = Table_Name;
            string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[(int)clsGeneral.Tables.Maintenance]);
            string DocPath = string.Concat(strUploadPath, "\\");
            drAttachment["Attachment_Name"] = drAttachment["Attachment_Description"] = clsGeneral.UploadFile(fpFile, DocPath, false, false);
            drAttachment["AttachedBy"] = (clsSession.LastName == string.Empty ? "" : clsSession.LastName + " ") + (clsSession.FirstName == string.Empty ? "" : clsSession.FirstName) + "- Sonic";

            dtTemp.Rows.Add(drAttachment);
            ViewState["dtAttachment"] = dtTemp;
            dtAttachment_FacilityMaintenance = (DataTable)ViewState["dtAttachment"];
            Session["dtAttachment"] = dtAttachment_FacilityMaintenance;
            ScriptManager.RegisterStartupScript(this, GetType(), "openAttachmentPoppup", "javascript:alert('Attachment Saved successfully.'); ClosePage();", true);
        }
        BindAttachmentGrid();
    }

    /// <summary>
    /// Attachment Rwo Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAttachmentDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveAttachment")
        {
            try
            {
                if (FK_Maintenance_Item != 0)
                {
                    string[] attachDetails = e.CommandArgument.ToString().Split(':');
                    string strPath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[(int)clsGeneral.Tables.Maintenance]) + attachDetails[1];
                    if (File.Exists(strPath))
                    {
                        File.Delete(strPath);
                    }
                    ERIMSAttachment.DeleteByPK(Convert.ToInt64(attachDetails[0]));
                }
                else
                {
                    GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    int RowIndex = gvr.RowIndex;
                    dtAttachment_FacilityMaintenance.Rows.RemoveAt(RowIndex);

                    string[] attachDetails = e.CommandArgument.ToString().Split(':');
                    string strPath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[(int)clsGeneral.Tables.Maintenance]) + attachDetails[1];
                    if (File.Exists(strPath))
                        File.Delete(strPath);

                    ViewState["dtAttachment"] = dtAttachment_FacilityMaintenance;
                }
                BindAttachmentGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        else if (e.CommandName == "DownloadAttachment")
        {
            string fileName = Convert.ToString(e.CommandArgument);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "javascript:window.open('" + AppConfig.SiteURL + "/Download.aspx?fileName=" + fileName + "&orgName=" + fileName.Substring(12, (fileName.Length - 1) - 11) + "&maintenanceattachment=true','_blank');", true);
        }
    }

    #region Private Methods

    /// <summary>
    /// Binds maintenance attachment grids in building information panel
    /// </summary>
    private void BindAttachmentGrid()
    {
        if (FK_Maintenance_Item != 0)
        {
            gvAttachmentDetailsView.DataSource = ERIMSAttachment.SelectAttachmentTableNameForeignKey(Table_Name, FK_Maintenance_Item.ToString()).Tables[0];
            gvAttachmentDetailsView.DataBind();
            divAttachmentView.Visible = true;
        }
        else if (FK_Maintenance_Item == 0 && dtAttachment_FacilityMaintenance.Rows.Count > 0)
        {
            gvAttachmentDetailsView.DataSource = dtAttachment_FacilityMaintenance;
            gvAttachmentDetailsView.DataBind();
            divAttachmentView.Visible = true;
        }
    }

    #endregion
}