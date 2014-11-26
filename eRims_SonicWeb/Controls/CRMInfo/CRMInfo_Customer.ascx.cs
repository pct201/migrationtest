using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class CRMInfo_Customer : System.Web.UI.UserControl
{
   
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void BindCRMDetails(decimal PK_Customer)
    {
        CRM_Customer objCustomer = new CRM_Customer(PK_Customer);
        lblIncidentType.Text = "Customer";
        lblComplaintNumber.Text = objCustomer.PK_CRM_Customer.ToString();
        if(objCustomer.FK_LU_Location != null)
        {
            lblDBA.Text = new LU_Location((decimal)objCustomer.FK_LU_Location).dba;
        }
        lblDateOfIncident.Text = clsGeneral.FormatDBNullDateToDisplay(objCustomer.Record_Date);
        lblDateOfLastUpdate.Text = clsGeneral.FormatDBNullDateToDisplay(objCustomer.User_Update_Date);
        lblLastName.Text = objCustomer.Last_Name;
        lblFirstName.Text = objCustomer.First_Name;
    }
}