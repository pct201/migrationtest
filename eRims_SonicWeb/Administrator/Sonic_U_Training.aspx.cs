using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_Sonic_U_Training_Required_Classes : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Sonic_U_Training
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Sonic_U_Training"]);
        }
        set { ViewState["PK_Sonic_U_Training"] = value; }
    }

    #endregion

    #region "Page Event"
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //check Is Page Post Back
        if (!IsPostBack)
        {
            //Bind Training Grid Function
            BindGrid();
        }
    }

    #endregion

    #region "Event"

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Sonic_U_Training_Required_Classes objSonic_U_Training = new Sonic_U_Training_Required_Classes();
        //bind Grid 
        gvTrainingEdit.DataSource = Sonic_U_Training_Required_Classes.SelectRecords();
        gvTrainingEdit.DataBind();

        if (gvTrainingEdit.Rows.Count > 0)
        {
            btnSave.Visible = true;
        }
        else
        {
            btnSave.Visible = false;
        }
        btnCancel.Visible = true;
        trTraining.Style.Add("display", "none");
        trTrainingAdd.Style.Add("display", "");
        btnAddNew.Visible = false;
    }

    #endregion

    #region "Grid Event"
    /// <summary>
    /// Page Index Change Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvTrainingEdit_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTrainingEdit.PageIndex = e.NewPageIndex; //Page new index call
        Sonic_U_Training_Required_Classes objSonic_U_Training = new Sonic_U_Training_Required_Classes();
        //bind Grid 
        gvTrainingEdit.DataSource = Sonic_U_Training_Required_Classes.SelectRecords();
        gvTrainingEdit.DataBind();
    }

    /// <summary>
    /// Page Index Change Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvTraining_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTraining.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }


    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvTraining_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            PK_Sonic_U_Training = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trTraining.Style.Add("display", "none");
            trTrainingAdd.Style.Add("display", " ");
            btnAddNew.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            
            Sonic_U_Training_Required_Classes objSonic_U_Training = new Sonic_U_Training_Required_Classes(PK_Sonic_U_Training);
            //bind TrainingEdit Grid
            gvTrainingEdit.DataSource = objSonic_U_Training.SelectByPK(PK_Sonic_U_Training);
            gvTrainingEdit.DataBind();
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind Training Grid
    /// </summary>
    private void BindGrid()
    {
        DataSet dsTraining = Sonic_U_Training_Required_Classes.SelectAll();
        gvTraining.DataSource = dsTraining;
        gvTraining.DataBind();
    }

    /// Used to Clear the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        PK_Sonic_U_Training = 0;
    }

    #endregion

    /// <summary>
    /// Save Button CLick
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strFinal = "<ImportXML>";
        Sonic_U_Training_Required_Classes objSonic_U_Training = new Sonic_U_Training_Required_Classes();

        foreach (GridViewRow gr in gvTrainingEdit.Rows)
        {
            Label lblPK_Sonic_U_Training = (Label)gr.FindControl("lblPK_Sonic_U_Training");
            objSonic_U_Training.PK_Sonic_U_Training = Convert.ToDecimal(lblPK_Sonic_U_Training.Text);
            DropDownList drpAssociate_Safety_Certification = (DropDownList)gr.FindControl("drpAssociate_Safety_Certification");
            objSonic_U_Training.Associate_Safety_Certification = (drpAssociate_Safety_Certification.SelectedValue.ToString() == "Blank") ? "" : drpAssociate_Safety_Certification.SelectedValue.ToString();
            DropDownList drpVehicle_Lift_Safety = (DropDownList)gr.FindControl("drpVehicle_Lift_Safety");
            objSonic_U_Training.Vehicle_Lift_Safety = (drpVehicle_Lift_Safety.SelectedValue.ToString() == "Blank") ? "" : drpVehicle_Lift_Safety.SelectedValue.ToString();
            DropDownList drpRCRA = (DropDownList)gr.FindControl("drpRCRA");
            objSonic_U_Training.RCRA = (drpRCRA.SelectedValue.ToString() == "Blank") ? "" : drpRCRA.SelectedValue.ToString(); 
            DropDownList drpHazardous_Materials_Transportation = (DropDownList)gr.FindControl("drpHazardous_Materials_Transportation");
            objSonic_U_Training.Hazardous_Materials_Transportation = (drpHazardous_Materials_Transportation.SelectedValue.ToString() == "Blank") ? "" : drpHazardous_Materials_Transportation.SelectedValue.ToString(); 
            DropDownList drpPowered_Industrial_Trucks = (DropDownList)gr.FindControl("drpPowered_Industrial_Trucks");
            objSonic_U_Training.Powered_Industrial_Trucks = (drpPowered_Industrial_Trucks.SelectedValue.ToString() == "Blank") ? "" : drpPowered_Industrial_Trucks.SelectedValue.ToString(); 
            DropDownList drpRespiratory_Training = (DropDownList)gr.FindControl("drpRespiratory_Training");
            objSonic_U_Training.Respiratory_Training = (drpRespiratory_Training.SelectedValue.ToString() == "Blank") ? "" : drpRespiratory_Training.SelectedValue.ToString(); 
            DropDownList drpStormwater_Pollution = (DropDownList)gr.FindControl("drpStormwater_Pollution");
            objSonic_U_Training.Stormwater_Pollution = (drpStormwater_Pollution.SelectedValue.ToString() == "Blank") ? "" : drpStormwater_Pollution.SelectedValue.ToString(); 

            //XML
            strFinal += "<Section><PK_Sonic_U_Training>" + objSonic_U_Training.PK_Sonic_U_Training + "</PK_Sonic_U_Training><Associate_Safety_Certification>" + objSonic_U_Training.Associate_Safety_Certification + "</Associate_Safety_Certification><Vehicle_Lift_Safety>" + objSonic_U_Training.Vehicle_Lift_Safety +
                      "</Vehicle_Lift_Safety><RCRA>"+objSonic_U_Training.RCRA+"</RCRA><Hazardous_Materials_Transportation>"+ objSonic_U_Training.Hazardous_Materials_Transportation +"</Hazardous_Materials_Transportation><Powered_Industrial_Trucks>"+
                      objSonic_U_Training.Powered_Industrial_Trucks + "</Powered_Industrial_Trucks><Respiratory_Training>" + objSonic_U_Training.Respiratory_Training + "</Respiratory_Training><Stormwater_Pollution>" + objSonic_U_Training.Stormwater_Pollution 
                      + "</Stormwater_Pollution></Section>";
        }

        strFinal += "</ImportXML>";
        Sonic_U_Training_Required_Classes.ImportXML(strFinal);

        //show hide grid
        trTraining.Style.Add("display", " ");
        trTrainingAdd.Style.Add("display", "none");
        BindGrid();
        btnSave.Visible = false;
        btnCancel.Visible = false;
        btnAddNew.Visible = true;
    }

    /// <summary>
    /// Button Cancel Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //show hide grid
        trTraining.Style.Add("display", " ");
        trTrainingAdd.Style.Add("display", "none");
        //hide buttons
        btnSave.Visible = false;
        btnCancel.Visible = false;
        btnAddNew.Visible = true;
    }

    protected void gvTraining_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
    }

    /// <summary>
    /// Grid gvTrainingEdit RowDataBound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvTrainingEdit_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //bind Drop downs
            DropDownList drpAssociate_Safety_Certification = (e.Row.FindControl("drpAssociate_Safety_Certification") as DropDownList);
            string country = (string.IsNullOrEmpty((e.Row.FindControl("lblAssociate_Safety_Certification_Edit") as Label).Text)) ? "Blank" : (e.Row.FindControl("lblAssociate_Safety_Certification_Edit") as Label).Text;
            clsGeneral.SetDropdownValue(drpAssociate_Safety_Certification, country,true);
            //drpAssociate_Safety_Certification.Items.FindByValue(country).Selected = true;

            DropDownList drpVehicle_Lift_Safety = (e.Row.FindControl("drpVehicle_Lift_Safety") as DropDownList);
            string strVehicle_Lift_Safety_Edit = (string.IsNullOrEmpty((e.Row.FindControl("lblVehicle_Lift_Safety_Edit") as Label).Text)) ? "Blank" : (e.Row.FindControl("lblVehicle_Lift_Safety_Edit") as Label).Text;
            clsGeneral.SetDropdownValue(drpVehicle_Lift_Safety, strVehicle_Lift_Safety_Edit, true);
            //drpVehicle_Lift_Safety.Items.FindByValue(strVehicle_Lift_Safety_Edit).Selected = true;

            DropDownList drpRCRA = (e.Row.FindControl("drpRCRA") as DropDownList);
            string strRCRAEdit = (string.IsNullOrEmpty((e.Row.FindControl("lblRCRAEdit") as Label).Text)) ? "Blank" : (e.Row.FindControl("lblRCRAEdit") as Label).Text;
            clsGeneral.SetDropdownValue(drpRCRA, strRCRAEdit, true);
            //drpRCRA.Items.FindByValue(strRCRAEdit).Selected = true;

            DropDownList drpHazardous_Materials_Transportation = (e.Row.FindControl("drpHazardous_Materials_Transportation") as DropDownList);
            string strHazardous_Materials_Transportation_Edit = (string.IsNullOrEmpty((e.Row.FindControl("lblHazardous_Materials_TransportationEdit") as Label).Text)) ? "Blank" : (e.Row.FindControl("lblHazardous_Materials_TransportationEdit") as Label).Text;
            clsGeneral.SetDropdownValue(drpHazardous_Materials_Transportation, strHazardous_Materials_Transportation_Edit, true);
            //drpHazardous_Materials_Transportation.Items.FindByValue(strHazardous_Materials_Transportation_Edit).Selected = true;

            DropDownList drpPowered_Industrial_Trucks = (e.Row.FindControl("drpPowered_Industrial_Trucks") as DropDownList);
            string strPowered_Industrial_TrucksEdit = (string.IsNullOrEmpty((e.Row.FindControl("lblPowered_Industrial_TrucksEdit") as Label).Text)) ? "Blank" : (e.Row.FindControl("lblPowered_Industrial_TrucksEdit") as Label).Text;
            clsGeneral.SetDropdownValue(drpPowered_Industrial_Trucks, strPowered_Industrial_TrucksEdit, true);
            //drpPowered_Industrial_Trucks.Items.FindByValue(strPowered_Industrial_TrucksEdit).Selected = true;

            DropDownList drpRespiratory_Training = (e.Row.FindControl("drpRespiratory_Training") as DropDownList);
            string strRespiratory_TrainingEdit = (string.IsNullOrEmpty((e.Row.FindControl("lblRespiratory_TrainingEdit") as Label).Text)) ? "Blank" : (e.Row.FindControl("lblRespiratory_TrainingEdit") as Label).Text;
            clsGeneral.SetDropdownValue(drpRespiratory_Training, strRespiratory_TrainingEdit, true);
            //drpRespiratory_Training.Items.FindByValue(strRespiratory_TrainingEdit).Selected = true;

            DropDownList drpStormwater_Pollution = (e.Row.FindControl("drpStormwater_Pollution") as DropDownList);
            string strStormwater_PollutionEdit = (string.IsNullOrEmpty((e.Row.FindControl("lblStormwater_PollutionEdit") as Label).Text)) ? "Blank" : (e.Row.FindControl("lblStormwater_PollutionEdit") as Label).Text;
            clsGeneral.SetDropdownValue(drpStormwater_Pollution, strStormwater_PollutionEdit, true);
            //drpStormwater_Pollution.Items.FindByValue(strStormwater_PollutionEdit).Selected = true;
        }
    }
}