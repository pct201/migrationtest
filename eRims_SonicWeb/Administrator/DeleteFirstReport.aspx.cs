using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Text;
using ERIMS.DAL;

public partial class Administrator_DeleteFirstReport : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Delete First Report Record
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int PK_ID = !string.IsNullOrEmpty(txtFirstReportNumber.Text) ? Convert.ToInt32(txtFirstReportNumber.Text) : 0;
        int retVal;
        string Prefix = ddlFirstReportType.SelectedIndex > 0 ? ddlFirstReportType.SelectedValue : "";
        //check Prefix.according to Prefix physical file is removed
        if (!string.IsNullOrEmpty(Prefix) && PK_ID > 0)
        {
            //as per Prfix name delete the physical fiels and also records from db
            switch (Prefix.ToUpper())
            {
                case "WC":
                    //Check Investigation Record is Available or NOt
                    decimal PK_WC_FR_ID = new WC_FR(PK_ID, false).PK_WC_FR_ID;
                    if (PK_WC_FR_ID > 0)
                    {
                        int PK_WC_Claim_ID = Workers_Comp_Claims_OH.SelectPKByWc_FR_ID(Convert.ToInt32(PK_WC_FR_ID));
                        if (PK_WC_Claim_ID > 0)
                        {
                            lblError.Text = "Claim Information is available for this Worker's Compensation record.";
                        }
                        else
                        {
                            retVal = First_Report_Wizard.DeleteFirstReport(Convert.ToInt32(PK_WC_FR_ID), First_Report_Wizard.Tables.WC_FR);
                            if (retVal > 0)
                            {
                                DeletePhysicalFile(First_Report_Wizard.Tables.WC_FR, Convert.ToInt32(PK_WC_FR_ID));
                                lblError.Text = "Record delete successfully.";
                            }
                            else
                                lblError.Text = "Error occurred while deleting First Report. Please contact Administrator.";
                        }
                    }
                    else
                    {
                        lblError.Text = "No such record found!!";
                    }
                    break;
                case "AL":
                    decimal PK_AL_FR_ID = new AL_FR(PK_ID, false).PK_AL_FR_ID;
                    if (PK_AL_FR_ID > 0)
                    {
                        retVal = First_Report_Wizard.DeleteFirstReport(Convert.ToInt32(PK_AL_FR_ID), First_Report_Wizard.Tables.AL_FR);
                        if (retVal > 0)
                        {
                            DeletePhysicalFile(First_Report_Wizard.Tables.AL_FR, Convert.ToInt32(PK_AL_FR_ID));
                            lblError.Text = "Record delete successfully.";
                        }
                        else
                            lblError.Text = "Error occurred while deleting First Report. Please contact Administrator.";


                    }
                    else
                    {
                        lblError.Text = "No such record found!!";
                    }
                    break;
                case "DPD":
                    decimal PK_DPD_FR_ID = new DPD_FR(PK_ID, false).PK_DPD_FR_ID;
                    if (PK_DPD_FR_ID > 0)
                    {
                        retVal = First_Report_Wizard.DeleteFirstReport(Convert.ToInt32(PK_DPD_FR_ID), First_Report_Wizard.Tables.DPD_FR);
                        if (retVal > 0)
                        {
                            DeletePhysicalFile(First_Report_Wizard.Tables.DPD_FR, Convert.ToInt32(PK_DPD_FR_ID));
                            lblError.Text = "Record delete successfully.";
                        }
                        else
                            lblError.Text = "Error occurred while deleting First Report. Please contact Administrator.";
                    }
                    else
                    {
                        lblError.Text = "No such record found!!";
                    }
                    break;

                case "PROPERTY":
                    decimal PK_Property_FR_ID = new Property_FR(PK_ID, false).PK_Property_FR_ID;
                    if (PK_Property_FR_ID > 0)
                    {
                        retVal = First_Report_Wizard.DeleteFirstReport(Convert.ToInt32(PK_Property_FR_ID), First_Report_Wizard.Tables.Property_FR);
                        if (retVal > 0)
                        {
                            DeletePhysicalFile(First_Report_Wizard.Tables.Property_FR, Convert.ToInt32(PK_Property_FR_ID));
                            lblError.Text = "Record delete successfully.";
                        }
                        else
                            lblError.Text = "Error occurred while deleting First Report. Please contact Administrator.";
                    }
                    else
                    {
                        lblError.Text = "No such record found!!";
                    }
                    break;
                case "PL":
                    decimal PK_PL_FR_ID = new PL_FR(PK_ID, false).PK_PL_FR_ID;
                    if (PK_PL_FR_ID > 0)
                    {
                        retVal = First_Report_Wizard.DeleteFirstReport(Convert.ToInt32(PK_PL_FR_ID), First_Report_Wizard.Tables.PL_FR);
                        if (retVal > 0)
                        {
                            DeletePhysicalFile(First_Report_Wizard.Tables.PL_FR, Convert.ToInt32(PK_PL_FR_ID));

                            lblError.Text = "Record delete successfully.";
                        }
                        else
                            lblError.Text = "Error occurred while deleting First Report. Please contact Administrator.";
                    }
                    else
                    {
                        lblError.Text = "No such record found!!";
                    }
                    break;
            }
            txtFirstReportNumber.Text = "";
            ddlFirstReportType.SelectedIndex = 0;
        }
    }
    /// <summary>
    /// Used to Delete File from Physical Locaiton
    /// </summary>
    /// <param name="tbl"></param>
    /// <param name="PK_ID"></param>
    public void DeletePhysicalFile(First_Report_Wizard.Tables tbl, int PK_ID)
    {
        switch (tbl)
        {
            //check Table is name is WC_FR than delete attachment for this First Report
            case (First_Report_Wizard.Tables.WC_FR):
                {

                    //Get Attchment Details
                    DataTable dtAtt = WC_FR_Attacments.SelectByFROI_ID(PK_ID).Tables[0];
                    string[] strAtt = new string[dtAtt.Rows.Count];
                    //check datatable have atleast 1 row
                    if (dtAtt.Rows.Count > 0)
                    {
                        foreach (DataRow drAtt in dtAtt.Rows)
                        {
                            string strFilePath = drAtt["Attachment_Path"].ToString();
                            strFilePath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[0]) + "\\" + strFilePath;
                            // if Exists than Delete file from physical location.
                            if (File.Exists(strFilePath))
                                File.Delete(strFilePath);
                        }
                    }
                    break;
                }
            //check Table is name is AL_FR than delete attachment for this First Report
            case (First_Report_Wizard.Tables.AL_FR):
                {
                    //Get Attchment Details
                    DataTable dtAtt = AL_FR_Attacments.SelectByFROL_ID(PK_ID).Tables[0];
                    string[] strAtt = new string[dtAtt.Rows.Count];
                    //check datatable have atleast 1 row
                    if (dtAtt.Rows.Count > 0)
                    {
                        foreach (DataRow drAtt in dtAtt.Rows)
                        {
                            string strFilePath = drAtt["Attachment_Path"].ToString();
                            strFilePath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[1]) + "\\" + strFilePath;
                            // if Exists than Delete file from physical location.
                            if (File.Exists(strFilePath))
                                File.Delete(strFilePath);
                        }
                    }
                    break;
                }
            //check Table is name is DPD_FR than delete attachment for this First Report
            case (First_Report_Wizard.Tables.DPD_FR):
                {
                    //Get Attchment Details
                    DataTable dtAtt = DPD_FR_Attacments.SelectByFROL_ID(PK_ID).Tables[0];
                    string[] strAtt = new string[dtAtt.Rows.Count];
                    //check datatable have atleast 1 row
                    if (dtAtt.Rows.Count > 0)
                    {
                        foreach (DataRow drAtt in dtAtt.Rows)
                        {
                            string strFilePath = drAtt["Attachment_Path"].ToString();
                            strFilePath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[2]) + "\\" + strFilePath;
                            // if Exists than Delete file from physical location.
                            if (File.Exists(strFilePath))
                                File.Delete(strFilePath);
                        }
                    }
                    break;
                }
            //check Table is name is PROPERTY_FR than delete attachment for this First Report
            case (First_Report_Wizard.Tables.Property_FR):
                {
                    //Get Attchment Details
                    DataTable dtAtt = Property_FR_Attacments.SelectByFR_ID(PK_ID).Tables[0];
                    string[] strAtt = new string[dtAtt.Rows.Count];
                    //check datatable have atleast 1 row
                    if (dtAtt.Rows.Count > 0)
                    {
                        foreach (DataRow drAtt in dtAtt.Rows)
                        {
                            string strFilePath = drAtt["Attachment_Path"].ToString();
                            strFilePath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[3]) + "\\" + strFilePath;
                            // if Exists than Delete file from physical location.
                            if (File.Exists(strFilePath))
                                File.Delete(strFilePath);
                        }
                    }
                    break;
                }
            //check Table is name is PL_FR than delete attachment for this First Report
            case (First_Report_Wizard.Tables.PL_FR):
                {
                    //Get Attchment Details
                    DataTable dtAtt = PL_FR_Attachments.SelectByFR_ID(PK_ID).Tables[0];
                    string[] strAtt = new string[dtAtt.Rows.Count];
                    //check datatable have atleast 1 row
                    if (dtAtt.Rows.Count > 0)
                    {
                        foreach (DataRow drAtt in dtAtt.Rows)
                        {
                            string strFilePath = drAtt["Attachment_Path"].ToString();
                            strFilePath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[4]) + "\\" + strFilePath;
                            // if Exists than Delete file from physical location.
                            if (File.Exists(strFilePath))
                                File.Delete(strFilePath);
                        }
                    }
                    break;
                }
        }


    }
}
