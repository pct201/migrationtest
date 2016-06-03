using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
using System.IO;

public partial class SONIC_Exposures_PropertyValuesImport : clsBasePage
{
    #region "Page Events"
    /// <summary>
    /// Handles an event page is first time loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // check if user has full access to import or export the data
        if (UserAccessType != AccessType.Administrative_Access)
        {
            Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
        }

        txtMultiplier.Attributes.Add("onblur", "MultiplierFormat(this.id,this.value);");
        txtMultiplier.Attributes.Add("onkeypress", "return FormatNumber(event,this.id,12,false)");
    }
    #endregion

    #region "Control Events"

    /// <summary>
    /// Handles Export button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExport_Click(object sender, EventArgs e)
    {
        // get Property Values data having the entered multiplier value applied to export 
        DataTable dtPropertyValues = Building_Financial_Limits.SelectForExport(Convert.ToDecimal(txtMultiplier.Text)).Tables[0];

        gvBuilding.DataSource = dtPropertyValues;
        gvBuilding.DataBind();

        // export data to excel sheet
        //clsGeneral.ExportData(dtPropertyValues, "Propert Values Spreadsheet");
        GridViewExportUtil.ExportGrid("Propert_Values_Spreadsheet.xls", gvBuilding, true);
    }

    /// <summary>
    /// Handles Import button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnImport_Click(object sender, EventArgs e)
    {
        // upload the file using session id and get the uploaded file name
        string strUploadedFile = clsGeneral.UploadFile(fpFile, AppConfig.BuildingAttachDocPath, Session.SessionID, false, false);

        try
        {
            DataTable dt = null; // denotes datatable to get the data in to import

            // pass exported file name and get datatable to import values
            dt = Building_Financial_Limits.ImportData(AppConfig.BuildingAttachDocPath + strUploadedFile);

            // if datatable not found then show 
            if (dt != null)
            {
                //if data is available to import 
                if (dt.Rows.Count > 0)
                {
                    decimal FK_Building_Id = 0; // denotes primary key
                    decimal PK_Building_Financial_Limits = 0;
                    //loop throgh each row in dataset
                    foreach (DataRow dr in dt.Rows)
                    {
                        // create object for property values
                        Building_Financial_Limits objVal = new Building_Financial_Limits();

                        FK_Building_Id = !string.IsNullOrEmpty(Convert.ToString(dr["FK_Building_Id"])) ? Convert.ToDecimal(dr["FK_Building_Id"]) : 0;
                        PK_Building_Financial_Limits = !string.IsNullOrEmpty(Convert.ToString(dr["PK_Building_Financial_Limits"])) ? Convert.ToDecimal(dr["PK_Building_Financial_Limits"]) : 0;
                        if (Building_Financial_Limits.ExistsKeyValues(PK_Building_Financial_Limits, FK_Building_Id))
                        {
                            // set values fetched from excel sheet
                            objVal.FK_Building_Id = FK_Building_Id;
                            objVal.Property_Valuation_Date = Convert.ToString(dr["Property Valuation Date"]) != string.Empty ? clsGeneral.FormatDateToStore(dr["Property Valuation Date"]) : DateTime.Now;
                            if (Convert.ToString(dr["RMS Means Building Limit"]) != "")
                                objVal.Building_Limit = Convert.ToDecimal(dr["RMS Means Building Limit"]);

                            if (Convert.ToString(dr["Associate Tools Limit"]) != "")
                                objVal.Associate_Tools_Limit = Convert.ToDecimal(dr["Associate Tools Limit"]);

                            if (Convert.ToString(dr["Contents Limit"]) != "")
                                objVal.Contents_Limit = Convert.ToDecimal(dr["Contents Limit"]);

                            if (Convert.ToString(dr["Parts Limit"]) != "")
                                objVal.Parts_Limit = Convert.ToDecimal(dr["Parts Limit"]);

                            if (Convert.ToString(dr["Business Interruption"]) != "")
                                objVal.Business_Interruption = Convert.ToDecimal(dr["Business Interruption"]);

                            objVal.Total = (objVal.Building_Limit != null ? objVal.Building_Limit : 0) +
                                           (objVal.Associate_Tools_Limit != null ? objVal.Associate_Tools_Limit : 0) +
                                           (objVal.Contents_Limit != null ? objVal.Contents_Limit : 0) +
                                           (objVal.Parts_Limit != null ? objVal.Parts_Limit : 0) +
                                           (objVal.Business_Interruption != null ? objVal.Business_Interruption : 0);

                            objVal.Updated_By = Convert.ToDecimal(clsSession.UserID);
                            objVal.Update_Date = DateTime.Now;

                            // insert the record
                            objVal.PK_Building_Financial_Limits = objVal.Insert();
                        }
                    }
                    // show message for data imported
                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('Data imported successfully !');", true);
                }
                else
                {
                    // show message for no data available
                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('No data available to imort');", true);
                }
            }
            else
            {
                // show message for file can not be imported
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('Selected file can not be imported');", true);
            }
        }
        catch
        {
            // show message for file can not be imported
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('Selected file can not be imported');", true);
        }
        finally
        {
            // delete uploaded file
            DeleteUploadedFile(strUploadedFile);
        }

    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Deletes exported spreadsheet
    /// </summary>
    /// <param name="strFile">Filename along with path which is to be deleted</param>
    private void DeleteUploadedFile(string strFile)
    {
        // check if filename is not blank
        if (strFile != "")
        {
            // check whether file exists or not
            if (File.Exists(AppConfig.BuildingAttachDocPath + strFile))
            {
                // delete the file
                File.Delete(AppConfig.BuildingAttachDocPath + strFile);
            }
        }
    }

    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    #endregion
}
