using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class Controls_IncidentInfo_IncidentInfo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Fill Claim Information Bar as per Claim Type and Primary Key
    /// </summary>
    /// <param name="PK_Claim"></param>
    /// <param name="ClaimType"></param>
    public void FillIncidentInformation(decimal PK_Incident,  decimal PK_Event, decimal FK_Location)
    {
        // if PK_COI is greater than 0 then display information Bar
        if (PK_Incident > 0)
        {
            // Get COI information    
            clsIncident objIncident= new clsIncident(PK_Incident);
            lblIncidentNumber.Text = objIncident.Incident_Number;

            if (objIncident.FK_LU_Classification != null)
                lblIncidentClassification.Text = new LU_Classification((decimal)objIncident.FK_LU_Classification).Fld_Desc;
            else
                lblIncidentClassification.Text = "";

            if (objIncident.Incident_Date != null)
                lblIncidentDate.Text = clsGeneral.FormatDBNullDateToDisplay(objIncident.Incident_Date);
            else
                lblIncidentDate.Text = "";

            if (objIncident.Incident_Time != null)
                lblIncidentTime.Text = objIncident.Incident_Time.ToString();
            else
                lblIncidentTime.Text = "";

        }

        if (PK_Event > 0)
        {
            clsEvent objEvent = new clsEvent(PK_Event);
            if (objEvent.Event_Number != null)
                lblEventNumber.Text = objEvent.Event_Number;
            else
                lblEventNumber.Text = "";
        }

        if (FK_Location > 0)
        {
            LU_Location objLu_Location = new LU_Location(FK_Location);
            lblLocation.Text = objLu_Location.dba;
        }
    }

}