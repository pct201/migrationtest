using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class CRMInfo_NonCustomer : System.Web.UI.UserControl
{
   
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void BindCRMDetails(decimal PK_Customer)
    {
        CRM_Non_Customer objCustomer = new CRM_Non_Customer(PK_Customer);
        lblIncidentType.Text = "Non-Customer";
        lblContactNumber.Text = objCustomer.PK_CRM_Non_Customer.ToString();
        if(objCustomer.FK_LU_Location != null)
        {
            lblDBA.Text = new LU_Location((decimal)objCustomer.FK_LU_Location).dba;
        }
        lblDateOfContact.Text = clsGeneral.FormatDBNullDateToDisplay(objCustomer.Record_Date);
        lblDateOfLastUpdate.Text = clsGeneral.FormatDBNullDateToDisplay(objCustomer.Update_Date);
        lblLastName.Text = objCustomer.Last_Name;
        lblFirstName.Text = objCustomer.First_Name;
    }
}