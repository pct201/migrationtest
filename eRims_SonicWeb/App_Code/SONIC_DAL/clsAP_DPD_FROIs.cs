using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for AP_DPD_FROIs table.
    /// </summary>
    public sealed class clsAP_DPD_FROIs
    {

        #region Private variables used to hold the property values

        private decimal? _PK_AP_DPD_FROIs;
        private decimal? _FK_LU_Location;
        private decimal? _FK_DPD_FR;
        private string _Third_Party_Vendor_Related_Theft;
        private string _Access_Control_Failures;
        private string _Breaking_And_Entering;
        private string _Burglar_Alarm_Failure;
        private string _Camera_Dead_Spot;
        private string _CCTV_Monitoring_Failure;
        private string _CCTV_Monitoring_Failure_By_Operator;
        private string _Design_Weakness_Property_Protection;
        private string _Environmental_Obstruction_and_or_Condition_Camera;
        private string _Failure_to_Report_and_or_Late_Report;
        private string _Key_Swap;
        private string _Lighting_Deficiencies;
        private string _Lock_Box_Not_Properly_Secured;
        private string _Negligence_Lack_of_key_Control_Program_Unattended_Keys;
        private string _Non_Permissible_User_of_Taking_Vehicle;
        private string _Power_Outage;
        private string _Security_Guard_Failure;
        private string _Stolen_Id;
        private string _Theft_By_Deception;
        private string _Unauthorized_Building_Entry_Forcible;
        private string _Unauthorized_Building_Entry_Unlocked;
        private string _Unauthorized_Vehicle_Entry_Forcible;
        private string _Unauthorized_Vehicle_Entry_Unlocked;
        private string _Vehicle_Taken_By_Tow_Truck;
        private string _Weather_Related_Damage_and_or_Loss;
        private string _Other_Describe;
        private string _Investigation_Finding_Other_Description;
        private string _Root_Cause;
        private string _Incident_Prevention;
        private string _Person_Tasked;
        private DateTime? _Target_Date_of_Completion;
        private DateTime? _Status_Due_On;
        private string _Comments;
        private decimal? _Financial_Loss;
        private decimal? _Recovery;
        private string _Item_Status;
        private string _Updated_By;
        private DateTime? _Update_Date;
        private decimal? _FK_DPD_FR_Vehicle_ID;
        private string _Vehicle_Color;
        private string _Police_Case_Number;
        private string _Investigating_Police_Department;
        private string _Vandalism;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_AP_DPD_FROIs value.
        /// </summary>
        public decimal? PK_AP_DPD_FROIs
        {
            get { return _PK_AP_DPD_FROIs; }
            set { _PK_AP_DPD_FROIs = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Location value.
        /// </summary>
        public decimal? FK_LU_Location
        {
            get { return _FK_LU_Location; }
            set { _FK_LU_Location = value; }
        }

        /// <summary>
        /// Gets or sets the FK_DPD_FR value.
        /// </summary>
        public decimal? FK_DPD_FR
        {
            get { return _FK_DPD_FR; }
            set { _FK_DPD_FR = value; }
        }

        /// <summary>
        /// Gets or sets the Third_Party_Vendor_Related_Theft value.
        /// </summary>
        public string Third_Party_Vendor_Related_Theft
        {
            get { return _Third_Party_Vendor_Related_Theft; }
            set { _Third_Party_Vendor_Related_Theft = value; }
        }

        /// <summary>
        /// Gets or sets the Access_Control_Failures value.
        /// </summary>
        public string Access_Control_Failures
        {
            get { return _Access_Control_Failures; }
            set { _Access_Control_Failures = value; }
        }

        /// <summary>
        /// Gets or sets the Breaking_And_Entering value.
        /// </summary>
        public string Breaking_And_Entering
        {
            get { return _Breaking_And_Entering; }
            set { _Breaking_And_Entering = value; }
        }

        /// <summary>
        /// Gets or sets the Burglar_Alarm_Failure value.
        /// </summary>
        public string Burglar_Alarm_Failure
        {
            get { return _Burglar_Alarm_Failure; }
            set { _Burglar_Alarm_Failure = value; }
        }

        /// <summary>
        /// Gets or sets the Camera_Dead_Spot value.
        /// </summary>
        public string Camera_Dead_Spot
        {
            get { return _Camera_Dead_Spot; }
            set { _Camera_Dead_Spot = value; }
        }

        /// <summary>
        /// Gets or sets the CCTV_Monitoring_Failure value.
        /// </summary>
        public string CCTV_Monitoring_Failure
        {
            get { return _CCTV_Monitoring_Failure; }
            set { _CCTV_Monitoring_Failure = value; }
        }

        /// <summary>
        /// Gets or sets the CCTV_Monitoring_Failure_By_Operator value.
        /// </summary>
        public string CCTV_Monitoring_Failure_By_Operator
        {
            get { return _CCTV_Monitoring_Failure_By_Operator; }
            set { _CCTV_Monitoring_Failure_By_Operator = value; }
        }

        /// <summary>
        /// Gets or sets the Design_Weakness_Property_Protection value.
        /// </summary>
        public string Design_Weakness_Property_Protection
        {
            get { return _Design_Weakness_Property_Protection; }
            set { _Design_Weakness_Property_Protection = value; }
        }

        /// <summary>
        /// Gets or sets the Environmental_Obstruction_and_or_Condition_Camera value.
        /// </summary>
        public string Environmental_Obstruction_and_or_Condition_Camera
        {
            get { return _Environmental_Obstruction_and_or_Condition_Camera; }
            set { _Environmental_Obstruction_and_or_Condition_Camera = value; }
        }

        /// <summary>
        /// Gets or sets the Failure_to_Report_and_or_Late_Report value.
        /// </summary>
        public string Failure_to_Report_and_or_Late_Report
        {
            get { return _Failure_to_Report_and_or_Late_Report; }
            set { _Failure_to_Report_and_or_Late_Report = value; }
        }

        /// <summary>
        /// Gets or sets the Key_Swap value.
        /// </summary>
        public string Key_Swap
        {
            get { return _Key_Swap; }
            set { _Key_Swap = value; }
        }

        /// <summary>
        /// Gets or sets the Lighting_Deficiencies value.
        /// </summary>
        public string Lighting_Deficiencies
        {
            get { return _Lighting_Deficiencies; }
            set { _Lighting_Deficiencies = value; }
        }

        /// <summary>
        /// Gets or sets the Lock_Box_Not_Properly_Secured value.
        /// </summary>
        public string Lock_Box_Not_Properly_Secured
        {
            get { return _Lock_Box_Not_Properly_Secured; }
            set { _Lock_Box_Not_Properly_Secured = value; }
        }

        /// <summary>
        /// Gets or sets the Negligence_Lack_of_key_Control_Program_Unattended_Keys value.
        /// </summary>
        public string Negligence_Lack_of_key_Control_Program_Unattended_Keys
        {
            get { return _Negligence_Lack_of_key_Control_Program_Unattended_Keys; }
            set { _Negligence_Lack_of_key_Control_Program_Unattended_Keys = value; }
        }

        /// <summary>
        /// Gets or sets the Non_Permissible_User_of_Taking_Vehicle value.
        /// </summary>
        public string Non_Permissible_User_of_Taking_Vehicle
        {
            get { return _Non_Permissible_User_of_Taking_Vehicle; }
            set { _Non_Permissible_User_of_Taking_Vehicle = value; }
        }

        /// <summary>
        /// Gets or sets the Power_Outage value.
        /// </summary>
        public string Power_Outage
        {
            get { return _Power_Outage; }
            set { _Power_Outage = value; }
        }

        /// <summary>
        /// Gets or sets the Security_Guard_Failure value.
        /// </summary>
        public string Security_Guard_Failure
        {
            get { return _Security_Guard_Failure; }
            set { _Security_Guard_Failure = value; }
        }

        /// <summary>
        /// Gets or sets the Stolen_Id value.
        /// </summary>
        public string Stolen_Id
        {
            get { return _Stolen_Id; }
            set { _Stolen_Id = value; }
        }

        /// <summary>
        /// Gets or sets the Theft_By_Deception value.
        /// </summary>
        public string Theft_By_Deception
        {
            get { return _Theft_By_Deception; }
            set { _Theft_By_Deception = value; }
        }

        /// <summary>
        /// Gets or sets the Unauthorized_Building_Entry_Forcible value.
        /// </summary>
        public string Unauthorized_Building_Entry_Forcible
        {
            get { return _Unauthorized_Building_Entry_Forcible; }
            set { _Unauthorized_Building_Entry_Forcible = value; }
        }

        /// <summary>
        /// Gets or sets the Unauthorized_Building_Entry_Unlocked value.
        /// </summary>
        public string Unauthorized_Building_Entry_Unlocked
        {
            get { return _Unauthorized_Building_Entry_Unlocked; }
            set { _Unauthorized_Building_Entry_Unlocked = value; }
        }

        /// <summary>
        /// Gets or sets the Unauthorized_Vehicle_Entry_Forcible value.
        /// </summary>
        public string Unauthorized_Vehicle_Entry_Forcible
        {
            get { return _Unauthorized_Vehicle_Entry_Forcible; }
            set { _Unauthorized_Vehicle_Entry_Forcible = value; }
        }

        /// <summary>
        /// Gets or sets the Unauthorized_Vehicle_Entry_Unlocked value.
        /// </summary>
        public string Unauthorized_Vehicle_Entry_Unlocked
        {
            get { return _Unauthorized_Vehicle_Entry_Unlocked; }
            set { _Unauthorized_Vehicle_Entry_Unlocked = value; }
        }

        /// <summary>
        /// Gets or sets the Vehicle_Taken_By_Tow_Truck value.
        /// </summary>
        public string Vehicle_Taken_By_Tow_Truck
        {
            get { return _Vehicle_Taken_By_Tow_Truck; }
            set { _Vehicle_Taken_By_Tow_Truck = value; }
        }

        /// <summary>
        /// Gets or sets the Weather_Related_Damage_and_or_Loss value.
        /// </summary>
        public string Weather_Related_Damage_and_or_Loss
        {
            get { return _Weather_Related_Damage_and_or_Loss; }
            set { _Weather_Related_Damage_and_or_Loss = value; }
        }

        /// <summary>
        /// Gets or sets the Other_Describe value.
        /// </summary>
        public string Other_Describe
        {
            get { return _Other_Describe; }
            set { _Other_Describe = value; }
        }

        /// <summary>
        /// Gets or sets the Investigation_Finding_Other_Description value.
        /// </summary>
        public string Investigation_Finding_Other_Description
        {
            get { return _Investigation_Finding_Other_Description; }
            set { _Investigation_Finding_Other_Description = value; }
        }

        /// <summary>
        /// Gets or sets the Root_Cause value.
        /// </summary>
        public string Root_Cause
        {
            get { return _Root_Cause; }
            set { _Root_Cause = value; }
        }

        /// <summary>
        /// Gets or sets the Incident_Prevention value.
        /// </summary>
        public string Incident_Prevention
        {
            get { return _Incident_Prevention; }
            set { _Incident_Prevention = value; }
        }

        /// <summary>
        /// Gets or sets the Person_Tasked value.
        /// </summary>
        public string Person_Tasked
        {
            get { return _Person_Tasked; }
            set { _Person_Tasked = value; }
        }

        /// <summary>
        /// Gets or sets the Target_Date_of_Completion value.
        /// </summary>
        public DateTime? Target_Date_of_Completion
        {
            get { return _Target_Date_of_Completion; }
            set { _Target_Date_of_Completion = value; }
        }

        /// <summary>
        /// Gets or sets the Status_Due_On value.
        /// </summary>
        public DateTime? Status_Due_On
        {
            get { return _Status_Due_On; }
            set { _Status_Due_On = value; }
        }

        /// <summary>
        /// Gets or sets the Comments value.
        /// </summary>
        public string Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }

        /// <summary>
        /// Gets or sets the Financial_Loss value.
        /// </summary>
        public decimal? Financial_Loss
        {
            get { return _Financial_Loss; }
            set { _Financial_Loss = value; }
        }

        /// <summary>
        /// Gets or sets the Recovery value.
        /// </summary>
        public decimal? Recovery
        {
            get { return _Recovery; }
            set { _Recovery = value; }
        }

        /// <summary>
        /// Gets or sets the Item_Status value.
        /// </summary>
        public string Item_Status
        {
            get { return _Item_Status; }
            set { _Item_Status = value; }
        }

        /// <summary>
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }

        /// <summary>
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime? Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }

        /// <summary>
        /// Gets or sets the FK_DPD_FR_Vehicle_ID value.
        /// </summary>
        public decimal? FK_DPD_FR_Vehicle_ID
        {
            get { return _FK_DPD_FR_Vehicle_ID; }
            set { _FK_DPD_FR_Vehicle_ID = value; }
        }

       /// <summary>
        /// Gets or sets the Vehicle_Color value.
        /// </summary>
        public string Vehicle_Color
        {
            get { return _Vehicle_Color; }
            set { _Vehicle_Color = value; }
        }

        /// <summary>
        /// Gets or sets the Police_Case_Number value.
        /// </summary>
        public string Police_Case_Number
        {
            get { return _Police_Case_Number; }
            set { _Police_Case_Number = value; }
        }

        /// <summary>
        /// Gets or sets the Investigating_Police_Department value.
        /// </summary>
        public string Investigating_Police_Department
        {
            get { return _Investigating_Police_Department; }
            set { _Investigating_Police_Department = value; }
        }

        /// <summary>
        /// Gets or sets the Vandalism value.
        /// </summary>
        public string Vandalism
        {
            get { return _Vandalism; }
            set { _Vandalism = value; }
        }



        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsAP_DPD_FROIs class with default value.
        /// </summary>
        public clsAP_DPD_FROIs()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsAP_DPD_FROIs class based on Primary Key.
        /// </summary>
        public clsAP_DPD_FROIs(decimal pK_AP_DPD_FROIs)
        {
            DataTable dtAP_DPD_FROIs = SelectByPK(pK_AP_DPD_FROIs).Tables[0];

            if (dtAP_DPD_FROIs.Rows.Count == 1)
            {
                SetValue(dtAP_DPD_FROIs.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsAP_DPD_FROIs class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drAP_DPD_FROIs)
        {
            if (drAP_DPD_FROIs["PK_AP_DPD_FROIs"] == DBNull.Value)
                this._PK_AP_DPD_FROIs = null;
            else
                this._PK_AP_DPD_FROIs = (decimal?)drAP_DPD_FROIs["PK_AP_DPD_FROIs"];

            if (drAP_DPD_FROIs["FK_LU_Location"] == DBNull.Value)
                this._FK_LU_Location = null;
            else
                this._FK_LU_Location = (decimal?)drAP_DPD_FROIs["FK_LU_Location"];

            if (drAP_DPD_FROIs["FK_DPD_FR"] == DBNull.Value)
                this._FK_DPD_FR = null;
            else
                this._FK_DPD_FR = (decimal?)drAP_DPD_FROIs["FK_DPD_FR"];

            if (drAP_DPD_FROIs["Third_Party_Vendor_Related_Theft"] == DBNull.Value)
                this._Third_Party_Vendor_Related_Theft = null;
            else
                this._Third_Party_Vendor_Related_Theft = (string)drAP_DPD_FROIs["Third_Party_Vendor_Related_Theft"];

            if (drAP_DPD_FROIs["Access_Control_Failures"] == DBNull.Value)
                this._Access_Control_Failures = null;
            else
                this._Access_Control_Failures = (string)drAP_DPD_FROIs["Access_Control_Failures"];

            if (drAP_DPD_FROIs["Breaking_And_Entering"] == DBNull.Value)
                this._Breaking_And_Entering = null;
            else
                this._Breaking_And_Entering = (string)drAP_DPD_FROIs["Breaking_And_Entering"];

            if (drAP_DPD_FROIs["Burglar_Alarm_Failure"] == DBNull.Value)
                this._Burglar_Alarm_Failure = null;
            else
                this._Burglar_Alarm_Failure = (string)drAP_DPD_FROIs["Burglar_Alarm_Failure"];

            if (drAP_DPD_FROIs["Camera_Dead_Spot"] == DBNull.Value)
                this._Camera_Dead_Spot = null;
            else
                this._Camera_Dead_Spot = (string)drAP_DPD_FROIs["Camera_Dead_Spot"];

            if (drAP_DPD_FROIs["CCTV_Monitoring_Failure"] == DBNull.Value)
                this._CCTV_Monitoring_Failure = null;
            else
                this._CCTV_Monitoring_Failure = (string)drAP_DPD_FROIs["CCTV_Monitoring_Failure"];

            if (drAP_DPD_FROIs["CCTV_Monitoring_Failure_By_Operator"] == DBNull.Value)
                this._CCTV_Monitoring_Failure_By_Operator = null;
            else
                this._CCTV_Monitoring_Failure_By_Operator = (string)drAP_DPD_FROIs["CCTV_Monitoring_Failure_By_Operator"];

            if (drAP_DPD_FROIs["Design_Weakness_Property_Protection"] == DBNull.Value)
                this._Design_Weakness_Property_Protection = null;
            else
                this._Design_Weakness_Property_Protection = (string)drAP_DPD_FROIs["Design_Weakness_Property_Protection"];

            if (drAP_DPD_FROIs["Environmental_Obstruction_and_or_Condition_Camera"] == DBNull.Value)
                this._Environmental_Obstruction_and_or_Condition_Camera = null;
            else
                this._Environmental_Obstruction_and_or_Condition_Camera = (string)drAP_DPD_FROIs["Environmental_Obstruction_and_or_Condition_Camera"];

            if (drAP_DPD_FROIs["Failure_to_Report_and_or_Late_Report"] == DBNull.Value)
                this._Failure_to_Report_and_or_Late_Report = null;
            else
                this._Failure_to_Report_and_or_Late_Report = (string)drAP_DPD_FROIs["Failure_to_Report_and_or_Late_Report"];

            if (drAP_DPD_FROIs["Key_Swap"] == DBNull.Value)
                this._Key_Swap = null;
            else
                this._Key_Swap = (string)drAP_DPD_FROIs["Key_Swap"];

            if (drAP_DPD_FROIs["Lighting_Deficiencies"] == DBNull.Value)
                this._Lighting_Deficiencies = null;
            else
                this._Lighting_Deficiencies = (string)drAP_DPD_FROIs["Lighting_Deficiencies"];

            if (drAP_DPD_FROIs["Lock_Box_Not_Properly_Secured"] == DBNull.Value)
                this._Lock_Box_Not_Properly_Secured = null;
            else
                this._Lock_Box_Not_Properly_Secured = (string)drAP_DPD_FROIs["Lock_Box_Not_Properly_Secured"];

            if (drAP_DPD_FROIs["Negligence_Lack_of_key_Control_Program_Unattended_Keys"] == DBNull.Value)
                this._Negligence_Lack_of_key_Control_Program_Unattended_Keys = null;
            else
                this._Negligence_Lack_of_key_Control_Program_Unattended_Keys = (string)drAP_DPD_FROIs["Negligence_Lack_of_key_Control_Program_Unattended_Keys"];

            if (drAP_DPD_FROIs["Non_Permissible_User_of_Taking_Vehicle"] == DBNull.Value)
                this._Non_Permissible_User_of_Taking_Vehicle = null;
            else
                this._Non_Permissible_User_of_Taking_Vehicle = (string)drAP_DPD_FROIs["Non_Permissible_User_of_Taking_Vehicle"];

            if (drAP_DPD_FROIs["Power_Outage"] == DBNull.Value)
                this._Power_Outage = null;
            else
                this._Power_Outage = (string)drAP_DPD_FROIs["Power_Outage"];

            if (drAP_DPD_FROIs["Security_Guard_Failure"] == DBNull.Value)
                this._Security_Guard_Failure = null;
            else
                this._Security_Guard_Failure = (string)drAP_DPD_FROIs["Security_Guard_Failure"];

            if (drAP_DPD_FROIs["Stolen_Id"] == DBNull.Value)
                this._Stolen_Id = null;
            else
                this._Stolen_Id = (string)drAP_DPD_FROIs["Stolen_Id"];

            if (drAP_DPD_FROIs["Theft_By_Deception"] == DBNull.Value)
                this._Theft_By_Deception = null;
            else
                this._Theft_By_Deception = (string)drAP_DPD_FROIs["Theft_By_Deception"];

            if (drAP_DPD_FROIs["Unauthorized_Building_Entry_Forcible"] == DBNull.Value)
                this._Unauthorized_Building_Entry_Forcible = null;
            else
                this._Unauthorized_Building_Entry_Forcible = (string)drAP_DPD_FROIs["Unauthorized_Building_Entry_Forcible"];

            if (drAP_DPD_FROIs["Unauthorized_Building_Entry_Unlocked"] == DBNull.Value)
                this._Unauthorized_Building_Entry_Unlocked = null;
            else
                this._Unauthorized_Building_Entry_Unlocked = (string)drAP_DPD_FROIs["Unauthorized_Building_Entry_Unlocked"];

            if (drAP_DPD_FROIs["Unauthorized_Vehicle_Entry_Forcible"] == DBNull.Value)
                this._Unauthorized_Vehicle_Entry_Forcible = null;
            else
                this._Unauthorized_Vehicle_Entry_Forcible = (string)drAP_DPD_FROIs["Unauthorized_Vehicle_Entry_Forcible"];

            if (drAP_DPD_FROIs["Unauthorized_Vehicle_Entry_Unlocked"] == DBNull.Value)
                this._Unauthorized_Vehicle_Entry_Unlocked = null;
            else
                this._Unauthorized_Vehicle_Entry_Unlocked = (string)drAP_DPD_FROIs["Unauthorized_Vehicle_Entry_Unlocked"];

            if (drAP_DPD_FROIs["Vehicle_Taken_By_Tow_Truck"] == DBNull.Value)
                this._Vehicle_Taken_By_Tow_Truck = null;
            else
                this._Vehicle_Taken_By_Tow_Truck = (string)drAP_DPD_FROIs["Vehicle_Taken_By_Tow_Truck"];

            if (drAP_DPD_FROIs["Weather_Related_Damage_and_or_Loss"] == DBNull.Value)
                this._Weather_Related_Damage_and_or_Loss = null;
            else
                this._Weather_Related_Damage_and_or_Loss = (string)drAP_DPD_FROIs["Weather_Related_Damage_and_or_Loss"];

            if (drAP_DPD_FROIs["Other_Describe"] == DBNull.Value)
                this._Other_Describe = null;
            else
                this._Other_Describe = (string)drAP_DPD_FROIs["Other_Describe"];

            if (drAP_DPD_FROIs["Investigation_Finding_Other_Description"] == DBNull.Value)
                this._Investigation_Finding_Other_Description = null;
            else
                this._Investigation_Finding_Other_Description = (string)drAP_DPD_FROIs["Investigation_Finding_Other_Description"];

            if (drAP_DPD_FROIs["Root_Cause"] == DBNull.Value)
                this._Root_Cause = null;
            else
                this._Root_Cause = (string)drAP_DPD_FROIs["Root_Cause"];

            if (drAP_DPD_FROIs["Incident_Prevention"] == DBNull.Value)
                this._Incident_Prevention = null;
            else
                this._Incident_Prevention = (string)drAP_DPD_FROIs["Incident_Prevention"];

            if (drAP_DPD_FROIs["Person_Tasked"] == DBNull.Value)
                this._Person_Tasked = null;
            else
                this._Person_Tasked = (string)drAP_DPD_FROIs["Person_Tasked"];

            if (drAP_DPD_FROIs["Target_Date_of_Completion"] == DBNull.Value)
                this._Target_Date_of_Completion = null;
            else
                this._Target_Date_of_Completion = (DateTime?)drAP_DPD_FROIs["Target_Date_of_Completion"];

            if (drAP_DPD_FROIs["Status_Due_On"] == DBNull.Value)
                this._Status_Due_On = null;
            else
                this._Status_Due_On = (DateTime?)drAP_DPD_FROIs["Status_Due_On"];

            if (drAP_DPD_FROIs["Comments"] == DBNull.Value)
                this._Comments = null;
            else
                this._Comments = (string)drAP_DPD_FROIs["Comments"];

            if (drAP_DPD_FROIs["Financial_Loss"] == DBNull.Value)
                this._Financial_Loss = null;
            else
                this._Financial_Loss = (decimal?)drAP_DPD_FROIs["Financial_Loss"];

            if (drAP_DPD_FROIs["Recovery"] == DBNull.Value)
                this._Recovery = null;
            else
                this._Recovery = (decimal?)drAP_DPD_FROIs["Recovery"];

            if (drAP_DPD_FROIs["Item_Status"] == DBNull.Value)
                this._Item_Status = null;
            else
                this._Item_Status = (string)drAP_DPD_FROIs["Item_Status"];

            if (drAP_DPD_FROIs["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drAP_DPD_FROIs["Updated_By"];

            if (drAP_DPD_FROIs["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drAP_DPD_FROIs["Update_Date"];

            if (drAP_DPD_FROIs["FK_DPD_FR_Vehicle_ID"] == DBNull.Value)
                this._FK_DPD_FR_Vehicle_ID = null;
            else
                this._FK_DPD_FR_Vehicle_ID = (decimal?)drAP_DPD_FROIs["FK_DPD_FR_Vehicle_ID"];

            if (drAP_DPD_FROIs["Vehicle_Color"] == DBNull.Value)
                this._Vehicle_Color = null;
            else
                this._Vehicle_Color = (string)drAP_DPD_FROIs["Vehicle_Color"];

            if (drAP_DPD_FROIs["Police_Case_Number"] == DBNull.Value)
                this._Police_Case_Number = null;
            else
                this._Police_Case_Number = (string)drAP_DPD_FROIs["Police_Case_Number"];

            if (drAP_DPD_FROIs["Investigating_Police_Department"] == DBNull.Value)
                this._Investigating_Police_Department = null;
            else
                this._Investigating_Police_Department = (string)drAP_DPD_FROIs["Investigating_Police_Department"];

            if (drAP_DPD_FROIs["Vandalism"] == DBNull.Value)
                this._Vandalism = null;
            else
                this._Vandalism = (string)drAP_DPD_FROIs["Vandalism"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the AP_DPD_FROIs table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_DPD_FROIsInsert");


            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);

            db.AddInParameter(dbCommand, "FK_DPD_FR", DbType.Decimal, this._FK_DPD_FR);

            if (string.IsNullOrEmpty(this._Third_Party_Vendor_Related_Theft))
                db.AddInParameter(dbCommand, "Third_Party_Vendor_Related_Theft", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Third_Party_Vendor_Related_Theft", DbType.String, this._Third_Party_Vendor_Related_Theft);

            if (string.IsNullOrEmpty(this._Access_Control_Failures))
                db.AddInParameter(dbCommand, "Access_Control_Failures", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Access_Control_Failures", DbType.String, this._Access_Control_Failures);

            if (string.IsNullOrEmpty(this._Breaking_And_Entering))
                db.AddInParameter(dbCommand, "Breaking_And_Entering", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Breaking_And_Entering", DbType.String, this._Breaking_And_Entering);

            if (string.IsNullOrEmpty(this._Burglar_Alarm_Failure))
                db.AddInParameter(dbCommand, "Burglar_Alarm_Failure", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Burglar_Alarm_Failure", DbType.String, this._Burglar_Alarm_Failure);

            if (string.IsNullOrEmpty(this._Camera_Dead_Spot))
                db.AddInParameter(dbCommand, "Camera_Dead_Spot", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Camera_Dead_Spot", DbType.String, this._Camera_Dead_Spot);

            if (string.IsNullOrEmpty(this._CCTV_Monitoring_Failure))
                db.AddInParameter(dbCommand, "CCTV_Monitoring_Failure", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CCTV_Monitoring_Failure", DbType.String, this._CCTV_Monitoring_Failure);

            if (string.IsNullOrEmpty(this._CCTV_Monitoring_Failure_By_Operator))
                db.AddInParameter(dbCommand, "CCTV_Monitoring_Failure_By_Operator", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CCTV_Monitoring_Failure_By_Operator", DbType.String, this._CCTV_Monitoring_Failure_By_Operator);

            if (string.IsNullOrEmpty(this._Design_Weakness_Property_Protection))
                db.AddInParameter(dbCommand, "Design_Weakness_Property_Protection", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Design_Weakness_Property_Protection", DbType.String, this._Design_Weakness_Property_Protection);

            if (string.IsNullOrEmpty(this._Environmental_Obstruction_and_or_Condition_Camera))
                db.AddInParameter(dbCommand, "Environmental_Obstruction_and_or_Condition_Camera", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Environmental_Obstruction_and_or_Condition_Camera", DbType.String, this._Environmental_Obstruction_and_or_Condition_Camera);

            if (string.IsNullOrEmpty(this._Failure_to_Report_and_or_Late_Report))
                db.AddInParameter(dbCommand, "Failure_to_Report_and_or_Late_Report", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Failure_to_Report_and_or_Late_Report", DbType.String, this._Failure_to_Report_and_or_Late_Report);

            if (string.IsNullOrEmpty(this._Key_Swap))
                db.AddInParameter(dbCommand, "Key_Swap", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Key_Swap", DbType.String, this._Key_Swap);

            if (string.IsNullOrEmpty(this._Lighting_Deficiencies))
                db.AddInParameter(dbCommand, "Lighting_Deficiencies", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Lighting_Deficiencies", DbType.String, this._Lighting_Deficiencies);

            if (string.IsNullOrEmpty(this._Lock_Box_Not_Properly_Secured))
                db.AddInParameter(dbCommand, "Lock_Box_Not_Properly_Secured", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Lock_Box_Not_Properly_Secured", DbType.String, this._Lock_Box_Not_Properly_Secured);

            if (string.IsNullOrEmpty(this._Negligence_Lack_of_key_Control_Program_Unattended_Keys))
                db.AddInParameter(dbCommand, "Negligence_Lack_of_key_Control_Program_Unattended_Keys", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Negligence_Lack_of_key_Control_Program_Unattended_Keys", DbType.String, this._Negligence_Lack_of_key_Control_Program_Unattended_Keys);

            if (string.IsNullOrEmpty(this._Non_Permissible_User_of_Taking_Vehicle))
                db.AddInParameter(dbCommand, "Non_Permissible_User_of_Taking_Vehicle", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Non_Permissible_User_of_Taking_Vehicle", DbType.String, this._Non_Permissible_User_of_Taking_Vehicle);

            if (string.IsNullOrEmpty(this._Power_Outage))
                db.AddInParameter(dbCommand, "Power_Outage", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Power_Outage", DbType.String, this._Power_Outage);

            if (string.IsNullOrEmpty(this._Security_Guard_Failure))
                db.AddInParameter(dbCommand, "Security_Guard_Failure", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Security_Guard_Failure", DbType.String, this._Security_Guard_Failure);

            if (string.IsNullOrEmpty(this._Stolen_Id))
                db.AddInParameter(dbCommand, "Stolen_Id", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Stolen_Id", DbType.String, this._Stolen_Id);

            if (string.IsNullOrEmpty(this._Theft_By_Deception))
                db.AddInParameter(dbCommand, "Theft_By_Deception", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Theft_By_Deception", DbType.String, this._Theft_By_Deception);

            if (string.IsNullOrEmpty(this._Unauthorized_Building_Entry_Forcible))
                db.AddInParameter(dbCommand, "Unauthorized_Building_Entry_Forcible", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Unauthorized_Building_Entry_Forcible", DbType.String, this._Unauthorized_Building_Entry_Forcible);

            if (string.IsNullOrEmpty(this._Unauthorized_Building_Entry_Unlocked))
                db.AddInParameter(dbCommand, "Unauthorized_Building_Entry_Unlocked", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Unauthorized_Building_Entry_Unlocked", DbType.String, this._Unauthorized_Building_Entry_Unlocked);

            if (string.IsNullOrEmpty(this._Unauthorized_Vehicle_Entry_Forcible))
                db.AddInParameter(dbCommand, "Unauthorized_Vehicle_Entry_Forcible", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Unauthorized_Vehicle_Entry_Forcible", DbType.String, this._Unauthorized_Vehicle_Entry_Forcible);

            if (string.IsNullOrEmpty(this._Unauthorized_Vehicle_Entry_Unlocked))
                db.AddInParameter(dbCommand, "Unauthorized_Vehicle_Entry_Unlocked", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Unauthorized_Vehicle_Entry_Unlocked", DbType.String, this._Unauthorized_Vehicle_Entry_Unlocked);

            if (string.IsNullOrEmpty(this._Vehicle_Taken_By_Tow_Truck))
                db.AddInParameter(dbCommand, "Vehicle_Taken_By_Tow_Truck", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Vehicle_Taken_By_Tow_Truck", DbType.String, this._Vehicle_Taken_By_Tow_Truck);

            if (string.IsNullOrEmpty(this._Weather_Related_Damage_and_or_Loss))
                db.AddInParameter(dbCommand, "Weather_Related_Damage_and_or_Loss", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Weather_Related_Damage_and_or_Loss", DbType.String, this._Weather_Related_Damage_and_or_Loss);

            if (string.IsNullOrEmpty(this._Other_Describe))
                db.AddInParameter(dbCommand, "Other_Describe", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Describe", DbType.String, this._Other_Describe);

            if (string.IsNullOrEmpty(this._Investigation_Finding_Other_Description))
                db.AddInParameter(dbCommand, "Investigation_Finding_Other_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Investigation_Finding_Other_Description", DbType.String, this._Investigation_Finding_Other_Description);

            if (string.IsNullOrEmpty(this._Root_Cause))
                db.AddInParameter(dbCommand, "Root_Cause", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Root_Cause", DbType.String, this._Root_Cause);

            if (string.IsNullOrEmpty(this._Incident_Prevention))
                db.AddInParameter(dbCommand, "Incident_Prevention", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Incident_Prevention", DbType.String, this._Incident_Prevention);

            if (string.IsNullOrEmpty(this._Person_Tasked))
                db.AddInParameter(dbCommand, "Person_Tasked", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Person_Tasked", DbType.String, this._Person_Tasked);

            db.AddInParameter(dbCommand, "Target_Date_of_Completion", DbType.DateTime, this._Target_Date_of_Completion);

            db.AddInParameter(dbCommand, "Status_Due_On", DbType.DateTime, this._Status_Due_On);

            if (string.IsNullOrEmpty(this._Comments))
                db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);

            db.AddInParameter(dbCommand, "Financial_Loss", DbType.Decimal, this._Financial_Loss);

            db.AddInParameter(dbCommand, "Recovery", DbType.Decimal, this._Recovery);

            if (string.IsNullOrEmpty(this._Item_Status))
                db.AddInParameter(dbCommand, "Item_Status", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Item_Status", DbType.String, this._Item_Status);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.AddInParameter(dbCommand, "FK_DPD_FR_Vehicle_ID", DbType.Decimal, this._FK_DPD_FR_Vehicle_ID);

            if (string.IsNullOrEmpty(this._Vehicle_Color))
                db.AddInParameter(dbCommand, "Vehicle_Color", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Vehicle_Color", DbType.String, this._Vehicle_Color);

            if (string.IsNullOrEmpty(this._Police_Case_Number))
                db.AddInParameter(dbCommand, "Police_Case_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Case_Number", DbType.String, this._Police_Case_Number);

            if (string.IsNullOrEmpty(this._Investigating_Police_Department))
                db.AddInParameter(dbCommand, "Investigating_Police_Department", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Investigating_Police_Department", DbType.String, this._Investigating_Police_Department);

            if (string.IsNullOrEmpty(this._Vandalism))
                db.AddInParameter(dbCommand, "Vandalism", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Vandalism", DbType.String, this._Vandalism);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the AP_DPD_FROIs table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_AP_DPD_FROIs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_DPD_FROIsSelectByPK");

            db.AddInParameter(dbCommand, "PK_AP_DPD_FROIs", DbType.Decimal, pK_AP_DPD_FROIs);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the AP_DPD_FROIs table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_DPD_FROIsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the AP_DPD_FROIs table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_DPD_FROIsUpdate");


            db.AddInParameter(dbCommand, "PK_AP_DPD_FROIs", DbType.Decimal, this._PK_AP_DPD_FROIs);

            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);

            db.AddInParameter(dbCommand, "FK_DPD_FR", DbType.Decimal, this._FK_DPD_FR);

            if (string.IsNullOrEmpty(this._Third_Party_Vendor_Related_Theft))
                db.AddInParameter(dbCommand, "Third_Party_Vendor_Related_Theft", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Third_Party_Vendor_Related_Theft", DbType.String, this._Third_Party_Vendor_Related_Theft);

            if (string.IsNullOrEmpty(this._Access_Control_Failures))
                db.AddInParameter(dbCommand, "Access_Control_Failures", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Access_Control_Failures", DbType.String, this._Access_Control_Failures);

            if (string.IsNullOrEmpty(this._Breaking_And_Entering))
                db.AddInParameter(dbCommand, "Breaking_And_Entering", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Breaking_And_Entering", DbType.String, this._Breaking_And_Entering);

            if (string.IsNullOrEmpty(this._Burglar_Alarm_Failure))
                db.AddInParameter(dbCommand, "Burglar_Alarm_Failure", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Burglar_Alarm_Failure", DbType.String, this._Burglar_Alarm_Failure);

            if (string.IsNullOrEmpty(this._Camera_Dead_Spot))
                db.AddInParameter(dbCommand, "Camera_Dead_Spot", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Camera_Dead_Spot", DbType.String, this._Camera_Dead_Spot);

            if (string.IsNullOrEmpty(this._CCTV_Monitoring_Failure))
                db.AddInParameter(dbCommand, "CCTV_Monitoring_Failure", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CCTV_Monitoring_Failure", DbType.String, this._CCTV_Monitoring_Failure);

            if (string.IsNullOrEmpty(this._CCTV_Monitoring_Failure_By_Operator))
                db.AddInParameter(dbCommand, "CCTV_Monitoring_Failure_By_Operator", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CCTV_Monitoring_Failure_By_Operator", DbType.String, this._CCTV_Monitoring_Failure_By_Operator);

            if (string.IsNullOrEmpty(this._Design_Weakness_Property_Protection))
                db.AddInParameter(dbCommand, "Design_Weakness_Property_Protection", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Design_Weakness_Property_Protection", DbType.String, this._Design_Weakness_Property_Protection);

            if (string.IsNullOrEmpty(this._Environmental_Obstruction_and_or_Condition_Camera))
                db.AddInParameter(dbCommand, "Environmental_Obstruction_and_or_Condition_Camera", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Environmental_Obstruction_and_or_Condition_Camera", DbType.String, this._Environmental_Obstruction_and_or_Condition_Camera);

            if (string.IsNullOrEmpty(this._Failure_to_Report_and_or_Late_Report))
                db.AddInParameter(dbCommand, "Failure_to_Report_and_or_Late_Report", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Failure_to_Report_and_or_Late_Report", DbType.String, this._Failure_to_Report_and_or_Late_Report);

            if (string.IsNullOrEmpty(this._Key_Swap))
                db.AddInParameter(dbCommand, "Key_Swap", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Key_Swap", DbType.String, this._Key_Swap);

            if (string.IsNullOrEmpty(this._Lighting_Deficiencies))
                db.AddInParameter(dbCommand, "Lighting_Deficiencies", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Lighting_Deficiencies", DbType.String, this._Lighting_Deficiencies);

            if (string.IsNullOrEmpty(this._Lock_Box_Not_Properly_Secured))
                db.AddInParameter(dbCommand, "Lock_Box_Not_Properly_Secured", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Lock_Box_Not_Properly_Secured", DbType.String, this._Lock_Box_Not_Properly_Secured);

            if (string.IsNullOrEmpty(this._Negligence_Lack_of_key_Control_Program_Unattended_Keys))
                db.AddInParameter(dbCommand, "Negligence_Lack_of_key_Control_Program_Unattended_Keys", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Negligence_Lack_of_key_Control_Program_Unattended_Keys", DbType.String, this._Negligence_Lack_of_key_Control_Program_Unattended_Keys);

            if (string.IsNullOrEmpty(this._Non_Permissible_User_of_Taking_Vehicle))
                db.AddInParameter(dbCommand, "Non_Permissible_User_of_Taking_Vehicle", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Non_Permissible_User_of_Taking_Vehicle", DbType.String, this._Non_Permissible_User_of_Taking_Vehicle);

            if (string.IsNullOrEmpty(this._Power_Outage))
                db.AddInParameter(dbCommand, "Power_Outage", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Power_Outage", DbType.String, this._Power_Outage);

            if (string.IsNullOrEmpty(this._Security_Guard_Failure))
                db.AddInParameter(dbCommand, "Security_Guard_Failure", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Security_Guard_Failure", DbType.String, this._Security_Guard_Failure);

            if (string.IsNullOrEmpty(this._Stolen_Id))
                db.AddInParameter(dbCommand, "Stolen_Id", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Stolen_Id", DbType.String, this._Stolen_Id);

            if (string.IsNullOrEmpty(this._Theft_By_Deception))
                db.AddInParameter(dbCommand, "Theft_By_Deception", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Theft_By_Deception", DbType.String, this._Theft_By_Deception);

            if (string.IsNullOrEmpty(this._Unauthorized_Building_Entry_Forcible))
                db.AddInParameter(dbCommand, "Unauthorized_Building_Entry_Forcible", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Unauthorized_Building_Entry_Forcible", DbType.String, this._Unauthorized_Building_Entry_Forcible);

            if (string.IsNullOrEmpty(this._Unauthorized_Building_Entry_Unlocked))
                db.AddInParameter(dbCommand, "Unauthorized_Building_Entry_Unlocked", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Unauthorized_Building_Entry_Unlocked", DbType.String, this._Unauthorized_Building_Entry_Unlocked);

            if (string.IsNullOrEmpty(this._Unauthorized_Vehicle_Entry_Forcible))
                db.AddInParameter(dbCommand, "Unauthorized_Vehicle_Entry_Forcible", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Unauthorized_Vehicle_Entry_Forcible", DbType.String, this._Unauthorized_Vehicle_Entry_Forcible);

            if (string.IsNullOrEmpty(this._Unauthorized_Vehicle_Entry_Unlocked))
                db.AddInParameter(dbCommand, "Unauthorized_Vehicle_Entry_Unlocked", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Unauthorized_Vehicle_Entry_Unlocked", DbType.String, this._Unauthorized_Vehicle_Entry_Unlocked);

            if (string.IsNullOrEmpty(this._Vehicle_Taken_By_Tow_Truck))
                db.AddInParameter(dbCommand, "Vehicle_Taken_By_Tow_Truck", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Vehicle_Taken_By_Tow_Truck", DbType.String, this._Vehicle_Taken_By_Tow_Truck);

            if (string.IsNullOrEmpty(this._Weather_Related_Damage_and_or_Loss))
                db.AddInParameter(dbCommand, "Weather_Related_Damage_and_or_Loss", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Weather_Related_Damage_and_or_Loss", DbType.String, this._Weather_Related_Damage_and_or_Loss);

            if (string.IsNullOrEmpty(this._Other_Describe))
                db.AddInParameter(dbCommand, "Other_Describe", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Describe", DbType.String, this._Other_Describe);

            if (string.IsNullOrEmpty(this._Investigation_Finding_Other_Description))
                db.AddInParameter(dbCommand, "Investigation_Finding_Other_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Investigation_Finding_Other_Description", DbType.String, this._Investigation_Finding_Other_Description);

            if (string.IsNullOrEmpty(this._Root_Cause))
                db.AddInParameter(dbCommand, "Root_Cause", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Root_Cause", DbType.String, this._Root_Cause);

            if (string.IsNullOrEmpty(this._Incident_Prevention))
                db.AddInParameter(dbCommand, "Incident_Prevention", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Incident_Prevention", DbType.String, this._Incident_Prevention);

            if (string.IsNullOrEmpty(this._Person_Tasked))
                db.AddInParameter(dbCommand, "Person_Tasked", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Person_Tasked", DbType.String, this._Person_Tasked);

            db.AddInParameter(dbCommand, "Target_Date_of_Completion", DbType.DateTime, this._Target_Date_of_Completion);

            db.AddInParameter(dbCommand, "Status_Due_On", DbType.DateTime, this._Status_Due_On);

            if (string.IsNullOrEmpty(this._Comments))
                db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);

            db.AddInParameter(dbCommand, "Financial_Loss", DbType.Decimal, this._Financial_Loss);

            db.AddInParameter(dbCommand, "Recovery", DbType.Decimal, this._Recovery);

            if (string.IsNullOrEmpty(this._Item_Status))
                db.AddInParameter(dbCommand, "Item_Status", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Item_Status", DbType.String, this._Item_Status);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.AddInParameter(dbCommand, "FK_DPD_FR_Vehicle_ID", DbType.Decimal, this._FK_DPD_FR_Vehicle_ID);

            if (string.IsNullOrEmpty(this._Vehicle_Color))
                db.AddInParameter(dbCommand, "Vehicle_Color", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Vehicle_Color", DbType.String, this._Vehicle_Color);

            if (string.IsNullOrEmpty(this._Police_Case_Number))
                db.AddInParameter(dbCommand, "Police_Case_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Case_Number", DbType.String, this._Police_Case_Number);

            if (string.IsNullOrEmpty(this._Investigating_Police_Department))
                db.AddInParameter(dbCommand, "Investigating_Police_Department", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Investigating_Police_Department", DbType.String, this._Investigating_Police_Department);

            if (string.IsNullOrEmpty(this._Vandalism))
                db.AddInParameter(dbCommand, "Vandalism", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Vandalism", DbType.String, this._Vandalism);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the AP_DPD_FROIs table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_AP_DPD_FROIs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_DPD_FROIsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_AP_DPD_FROIs", DbType.Decimal, pK_AP_DPD_FROIs);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet GetDataToBindFROIsGrid(string FROIsToInclude, decimal Location_ID, int intPageNo, int intPageSize, string strOrder, string strOrderBy)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_DPD_FROIs_GetDataToBindFROIsGrid");

            db.AddInParameter(dbCommand, "FROIsToInclude", DbType.String, FROIsToInclude);
            db.AddInParameter(dbCommand, "Location_ID", DbType.Decimal, Location_ID);
            db.AddInParameter(dbCommand, "intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.String, intPageSize);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetDPD_FROIs_DetailByPK(decimal FK_DPD_FR_ID, decimal FK_DPD_FR_Vehicle_ID, decimal PK_AP_DPD_FROIs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_DPD_FROIs_GetDPD_DetailByPK");

            db.AddInParameter(dbCommand, "FK_DPD_FR_ID", DbType.Decimal, FK_DPD_FR_ID);
            db.AddInParameter(dbCommand, "FK_DPD_FR_Vehicle_ID", DbType.Decimal, FK_DPD_FR_Vehicle_ID);
            db.AddInParameter(dbCommand, "PK_AP_DPD_FROIs", DbType.Decimal, PK_AP_DPD_FROIs);


            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetClaimNotesByPk(decimal PK_DPD_FR_ID, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_DPD_FROIs_GetClaimNotesByPk");

            db.AddInParameter(dbCommand, "PK_DPD_FR_ID", DbType.Decimal, PK_DPD_FR_ID);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.String, intPageSize);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetAbstractLetter(decimal Location_ID, DateTime? Begin_Date, DateTime? End_Date)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetAbstractLetter");

            db.AddInParameter(dbCommand, "Location_ID", DbType.Decimal, Location_ID);
            db.AddInParameter(dbCommand, "Begin_Date", DbType.DateTime, Begin_Date);
            db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, End_Date);

            return db.ExecuteDataSet(dbCommand);
        }

        
    }
}
