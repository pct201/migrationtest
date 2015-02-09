using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for WC_FR table.
    /// </summary>
    public sealed class WC_FR
    {
        #region Fields


        private decimal _PK_WC_FR_ID;
        private decimal _WC_FR_Number;
        private decimal _FK_Contact;
        private decimal _FK_Injured;
        private string _Supervisor_Phone;
        private bool _Motor_Vehicle_Accident;
        private string _Date_Of_Incident;
        private string _Time_Of_Incident;
        private string _Filing_State;
        private bool _InjuryOccurredOffsite;
        private string _Offsite_Address1;
        private string _Offsite_Address2;
        private string _Offsite_City;
        private string _Offsite_State;
        private string _Offsite_zip;
        private decimal _FK_LU_Location;
        private string _Description_Of_Incident;
        private Nullable<bool> _Associate_Injured_Regular_Job;
        private decimal _FK_Department_Where_Occurred;
        private decimal _FK_Nature_Of_Injury;
        private string _FK_Body_Parts_Affected;
        private Nullable<bool> _Safeguards_Provided;
        private Nullable<bool> _Safeguards_Used;
        private Nullable<bool> _Machine_Part_Involved;
        private Nullable<bool> _Machine_Part_Defective;
        private Nullable<bool> _Claim_Questionable;
        private string _Claim_Questionable_Description;
        private DateTime _Date_Reported_To_Sonic;
        private string _person_reported_to;
        private bool _Witnesses;
        private string _Witness_1;
        private string _Witness_2;
        private string _Witness_3;
        private string _Witness_1_Phone;
        private string _Witness_2_Phone;
        private string _Witness_3_Phone;
        private bool _Fatality;
        private string _Initial_Medical_Treatment;
        private DateTime _Date_of_Initial_Medical_Treatment;
        private bool _Taken_By_Emergency_Transportation;
        private string _Medical_Facility_Name;
        private string _Medical_Facility_Address1;
        private string _Medical_Facility_Address2;
        private string _Medical_Facility_City;
        private string _Medical_Facility_State;
        private string _Medical_Facility_Zip;
        private string _Medical_Facility_Phone;
        private bool _Status_Out_Of_Work;
        private DateTime _Status_Out_Of_Work_Date;
        private bool _Status_Return_To_Work_Unrestricted;
        private DateTime _Status_Return_To_Work_Unrestricted_Date;
        private bool _Status_Return_Tp_Work_Restricted;
        private DateTime _Status_Return_Tp_Work_Restricted_Date;
        private bool _Status_Unknown;
        private DateTime _Next_Doctor_Visit;
        private string _Treating_Physician_Name;
        private Nullable<bool> _Admitted_to_Hospital;
        private Nullable<bool> _Still_In_Hospital;
        private bool _Referring_Physician;
        private string _Physician_Name;
        private string _Physician_Address1;
        private string _Physician_Address2;
        private string _Physician_City;
        private string _Physician_State;
        private string _Physician_Zip;
        private string _Physician_Phone;
        private string _Comments;
        private bool _Complete;
        private string _Alternate_Phone_2;
        private decimal _Employee_hrs_per_week;
        private decimal _Employee_Days_per_week;
        private string _Employee_Time_Shift_Begins;
        private string _Employee_Time_Shift_Ends;
        private string _State_of_Hire;
        private DateTime _Date_Reported_to_SRS;
        private decimal _Updated_By;
        private DateTime _Updated_Date;
        private string _Initial_Claim_Classification;
        private decimal _FK_SLT_Incident_Review;
        private string _Telephone_Nurse_Consultation;
        private string _Supervisor_Involved_In_Consultation;
        #endregion

        #region Properties

        public string Initial_Claim_Classification
        {
            get { return _Initial_Claim_Classification; }
            set { _Initial_Claim_Classification = value; }
        }
        /// <summary> 
        /// Gets or sets the PK_WC_FR_ID value.
        /// </summary>
        public decimal PK_WC_FR_ID
        {
            get { return _PK_WC_FR_ID; }
            set { _PK_WC_FR_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the WC_FR_Number value.
        /// </summary>
        public decimal WC_FR_Number
        {
            get { return _WC_FR_Number; }
            set { _WC_FR_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Contact value.
        /// </summary>
        public decimal FK_Contact
        {
            get { return _FK_Contact; }
            set { _FK_Contact = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Injured value.
        /// </summary>
        public decimal FK_Injured
        {
            get { return _FK_Injured; }
            set { _FK_Injured = value; }
        }


        /// <summary> 
        /// Gets or sets the Supervisor_Phone value.
        /// </summary>
        public string Supervisor_Phone
        {
            get { return _Supervisor_Phone; }
            set { _Supervisor_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Motor_Vehicle_Accident value.
        /// </summary>
        public bool Motor_Vehicle_Accident
        {
            get { return _Motor_Vehicle_Accident; }
            set { _Motor_Vehicle_Accident = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Of_Incident value.
        /// </summary>
        public string Date_Of_Incident
        {
            get { return _Date_Of_Incident; }
            set { _Date_Of_Incident = value; }
        }


        /// <summary> 
        /// Gets or sets the Time_Of_Incident value.
        /// </summary>
        public string Time_Of_Incident
        {
            get { return _Time_Of_Incident; }
            set { _Time_Of_Incident = value; }
        }


        /// <summary> 
        /// Gets or sets the Filing_State value.
        /// </summary>
        public string Filing_State
        {
            get { return _Filing_State; }
            set { _Filing_State = value; }
        }


        /// <summary> 
        /// Gets or sets the InjuryOccurredOffsite value.
        /// </summary>
        public bool InjuryOccurredOffsite
        {
            get { return _InjuryOccurredOffsite; }
            set { _InjuryOccurredOffsite = value; }
        }


        /// <summary> 
        /// Gets or sets the Offsite_Address1 value.
        /// </summary>
        public string Offsite_Address1
        {
            get { return _Offsite_Address1; }
            set { _Offsite_Address1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Offsite_Address2 value.
        /// </summary>
        public string Offsite_Address2
        {
            get { return _Offsite_Address2; }
            set { _Offsite_Address2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Offsite_City value.
        /// </summary>
        public string Offsite_City
        {
            get { return _Offsite_City; }
            set { _Offsite_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Offsite_State value.
        /// </summary>
        public string Offsite_State
        {
            get { return _Offsite_State; }
            set { _Offsite_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Offsite_zip value.
        /// </summary>
        public string Offsite_zip
        {
            get { return _Offsite_zip; }
            set { _Offsite_zip = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_LU_Location value.
        /// </summary>
        public decimal FK_LU_Location
        {
            get { return _FK_LU_Location; }
            set { _FK_LU_Location = value; }
        }


        /// <summary> 
        /// Gets or sets the Description_Of_Incident value.
        /// </summary>
        public string Description_Of_Incident
        {
            get { return _Description_Of_Incident; }
            set { _Description_Of_Incident = value; }
        }


        /// <summary> 
        /// Gets or sets the Associate_Injured_Regular_Job value.
        /// </summary>
        public Nullable<bool> Associate_Injured_Regular_Job
        {
            get { return _Associate_Injured_Regular_Job; }
            set { _Associate_Injured_Regular_Job = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Department_Where_Occurred value.
        /// </summary>
        public decimal FK_Department_Where_Occurred
        {
            get { return _FK_Department_Where_Occurred; }
            set { _FK_Department_Where_Occurred = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Nature_Of_Injury value.
        /// </summary>
        public decimal FK_Nature_Of_Injury
        {
            get { return _FK_Nature_Of_Injury; }
            set { _FK_Nature_Of_Injury = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Body_Parts_Affected value.
        /// </summary>
        public string FK_Body_Parts_Affected
        {
            get { return _FK_Body_Parts_Affected; }
            set { _FK_Body_Parts_Affected = value; }
        }


        /// <summary> 
        /// Gets or sets the Safeguards_Provided value.
        /// </summary>
        public Nullable<bool> Safeguards_Provided
        {
            get { return _Safeguards_Provided; }
            set { _Safeguards_Provided = value; }
        }


        /// <summary> 
        /// Gets or sets the Safeguards_Used value.
        /// </summary>
        public Nullable<bool> Safeguards_Used
        {
            get { return _Safeguards_Used; }
            set { _Safeguards_Used = value; }
        }


        /// <summary> 
        /// Gets or sets the Machine_Part_Involved value.
        /// </summary>
        public Nullable<bool> Machine_Part_Involved
        {
            get { return _Machine_Part_Involved; }
            set { _Machine_Part_Involved = value; }
        }


        /// <summary> 
        /// Gets or sets the Machine_Part_Defective value.
        /// </summary>
        public Nullable<bool> Machine_Part_Defective
        {
            get { return _Machine_Part_Defective; }
            set { _Machine_Part_Defective = value; }
        }


        /// <summary> 
        /// Gets or sets the Claim_Questionable value.
        /// </summary>
        public Nullable<bool> Claim_Questionable
        {
            get { return _Claim_Questionable; }
            set { _Claim_Questionable = value; }
        }


        /// <summary> 
        /// Gets or sets the Claim_Questionable_Description value.
        /// </summary>
        public string Claim_Questionable_Description
        {
            get { return _Claim_Questionable_Description; }
            set { _Claim_Questionable_Description = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Reported_To_Sonic value.
        /// </summary>
        public DateTime Date_Reported_To_Sonic
        {
            get { return _Date_Reported_To_Sonic; }
            set { _Date_Reported_To_Sonic = value; }
        }

        /// <summary> 
        /// Gets or sets the person_reported_to value.
        /// </summary>
        public string person_reported_to
        {
            get { return _person_reported_to; }
            set { _person_reported_to = value; }
        }

        /// <summary> 
        /// Gets or sets the Witnesses value.
        /// </summary>
        public bool Witnesses
        {
            get { return _Witnesses; }
            set { _Witnesses = value; }
        }


        /// <summary> 
        /// Gets or sets the Witness_1 value.
        /// </summary>
        public string Witness_1
        {
            get { return _Witness_1; }
            set { _Witness_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Witness_2 value.
        /// </summary>
        public string Witness_2
        {
            get { return _Witness_2; }
            set { _Witness_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Witness_3 value.
        /// </summary>
        public string Witness_3
        {
            get { return _Witness_3; }
            set { _Witness_3 = value; }
        }


        /// <summary> 
        /// Gets or sets the Witness_1_Phone value.
        /// </summary>
        public string Witness_1_Phone
        {
            get { return _Witness_1_Phone; }
            set { _Witness_1_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Witness_2_Phone value.
        /// </summary>
        public string Witness_2_Phone
        {
            get { return _Witness_2_Phone; }
            set { _Witness_2_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Witness_3_Phone value.
        /// </summary>
        public string Witness_3_Phone
        {
            get { return _Witness_3_Phone; }
            set { _Witness_3_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Fatality value.
        /// </summary>
        public bool Fatality
        {
            get { return _Fatality; }
            set { _Fatality = value; }
        }


        /// <summary> 
        /// Gets or sets the Initial_Medical_Treatment value.
        /// </summary>
        public string Initial_Medical_Treatment
        {
            get { return _Initial_Medical_Treatment; }
            set { _Initial_Medical_Treatment = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_of_Initial_Medical_Treatment value.
        /// </summary>
        public DateTime Date_of_Initial_Medical_Treatment
        {
            get { return _Date_of_Initial_Medical_Treatment; }
            set { _Date_of_Initial_Medical_Treatment = value; }
        }


        /// <summary> 
        /// Gets or sets the Taken_By_Emergency_Transportation value.
        /// </summary>
        public bool Taken_By_Emergency_Transportation
        {
            get { return _Taken_By_Emergency_Transportation; }
            set { _Taken_By_Emergency_Transportation = value; }
        }


        /// <summary> 
        /// Gets or sets the Medical_Facility_Name value.
        /// </summary>
        public string Medical_Facility_Name
        {
            get { return _Medical_Facility_Name; }
            set { _Medical_Facility_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Medical_Facility_Address1 value.
        /// </summary>
        public string Medical_Facility_Address1
        {
            get { return _Medical_Facility_Address1; }
            set { _Medical_Facility_Address1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Medical_Facility_Address2 value.
        /// </summary>
        public string Medical_Facility_Address2
        {
            get { return _Medical_Facility_Address2; }
            set { _Medical_Facility_Address2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Medical_Facility_City value.
        /// </summary>
        public string Medical_Facility_City
        {
            get { return _Medical_Facility_City; }
            set { _Medical_Facility_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Medical_Facility_State value.
        /// </summary>
        public string Medical_Facility_State
        {
            get { return _Medical_Facility_State; }
            set { _Medical_Facility_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Medical_Facility_Zip value.
        /// </summary>
        public string Medical_Facility_Zip
        {
            get { return _Medical_Facility_Zip; }
            set { _Medical_Facility_Zip = value; }
        }


        /// <summary> 
        /// Gets or sets the Medical_Facility_Phone value.
        /// </summary>
        public string Medical_Facility_Phone
        {
            get { return _Medical_Facility_Phone; }
            set { _Medical_Facility_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Status_Out_Of_Work value.
        /// </summary>
        public bool Status_Out_Of_Work
        {
            get { return _Status_Out_Of_Work; }
            set { _Status_Out_Of_Work = value; }
        }


        /// <summary> 
        /// Gets or sets the Status_Out_Of_Work_Date value.
        /// </summary>
        public DateTime Status_Out_Of_Work_Date
        {
            get { return _Status_Out_Of_Work_Date; }
            set { _Status_Out_Of_Work_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Status_Return_To_Work_Unrestricted value.
        /// </summary>
        public bool Status_Return_To_Work_Unrestricted
        {
            get { return _Status_Return_To_Work_Unrestricted; }
            set { _Status_Return_To_Work_Unrestricted = value; }
        }


        /// <summary> 
        /// Gets or sets the Status_Return_To_Work_Unrestricted_Date value.
        /// </summary>
        public DateTime Status_Return_To_Work_Unrestricted_Date
        {
            get { return _Status_Return_To_Work_Unrestricted_Date; }
            set { _Status_Return_To_Work_Unrestricted_Date = value; }
        }
        /// <summary> 
        /// Gets or sets the Status_Return_Tp_Work_Restricted value.
        /// </summary>
        public bool Status_Return_Tp_Work_Restricted
        {
            get { return _Status_Return_Tp_Work_Restricted; }
            set { _Status_Return_Tp_Work_Restricted = value; }
        }


        /// <summary> 
        /// Gets or sets the Status_Return_Tp_Work_Restricted_Date value.
        /// </summary>
        public DateTime Status_Return_Tp_Work_Restricted_Date
        {
            get { return _Status_Return_Tp_Work_Restricted_Date; }
            set { _Status_Return_Tp_Work_Restricted_Date = value; }
        }
        /// <summary> 
        /// Gets or sets the Status_Unknown value.
        /// </summary>
        public bool Status_Unknown
        {
            get { return _Status_Unknown; }
            set { _Status_Unknown = value; }
        }


        /// <summary> 
        /// Gets or sets the Next_Doctor_Visit value.
        /// </summary>
        public DateTime Next_Doctor_Visit
        {
            get { return _Next_Doctor_Visit; }
            set { _Next_Doctor_Visit = value; }
        }


        /// <summary> 
        /// Gets or sets the Treating_Physician_Name value.
        /// </summary>
        public string Treating_Physician_Name
        {
            get { return _Treating_Physician_Name; }
            set { _Treating_Physician_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Admitted_to_Hospital value.
        /// </summary>
        public Nullable<bool> Admitted_to_Hospital
        {
            get { return _Admitted_to_Hospital; }
            set { _Admitted_to_Hospital = value; }
        }


        /// <summary> 
        /// Gets or sets the Still_In_Hospital value.
        /// </summary>
        public Nullable<bool> Still_In_Hospital
        {
            get { return _Still_In_Hospital; }
            set { _Still_In_Hospital = value; }
        }


        /// <summary> 
        /// Gets or sets the Referring_Physician value.
        /// </summary>
        public bool Referring_Physician
        {
            get { return _Referring_Physician; }
            set { _Referring_Physician = value; }
        }


        /// <summary> 
        /// Gets or sets the Physician_Name value.
        /// </summary>
        public string Physician_Name
        {
            get { return _Physician_Name; }
            set { _Physician_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Physician_Address1 value.
        /// </summary>
        public string Physician_Address1
        {
            get { return _Physician_Address1; }
            set { _Physician_Address1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Physician_Address2 value.
        /// </summary>
        public string Physician_Address2
        {
            get { return _Physician_Address2; }
            set { _Physician_Address2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Physician_City value.
        /// </summary>
        public string Physician_City
        {
            get { return _Physician_City; }
            set { _Physician_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Physician_State value.
        /// </summary>
        public string Physician_State
        {
            get { return _Physician_State; }
            set { _Physician_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Physician_Zip value.
        /// </summary>
        public string Physician_Zip
        {
            get { return _Physician_Zip; }
            set { _Physician_Zip = value; }
        }


        /// <summary> 
        /// Gets or sets the Physician_Phone value.
        /// </summary>
        public string Physician_Phone
        {
            get { return _Physician_Phone; }
            set { _Physician_Phone = value; }
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
        /// Gets or sets the Complete value.
        /// </summary>
        public bool Complete
        {
            get { return _Complete; }
            set { _Complete = value; }
        }


        /// <summary> 
        /// Gets or sets the Alternate_Phone_2 value.
        /// </summary>
        public string Alternate_Phone_2
        {
            get { return _Alternate_Phone_2; }
            set { _Alternate_Phone_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Employee_hrs_per_week value.
        /// </summary>
        public decimal Employee_hrs_per_week
        {
            get { return _Employee_hrs_per_week; }
            set { _Employee_hrs_per_week = value; }
        }


        /// <summary> 
        /// Gets or sets the Employee_Days_per_week value.
        /// </summary>
        public decimal Employee_Days_per_week
        {
            get { return _Employee_Days_per_week; }
            set { _Employee_Days_per_week = value; }
        }


        /// <summary> 
        /// Gets or sets the Employee_Time_Shift_Begins value.
        /// </summary>
        public string Employee_Time_Shift_Begins
        {
            get { return _Employee_Time_Shift_Begins; }
            set { _Employee_Time_Shift_Begins = value; }
        }


        /// <summary> 
        /// Gets or sets the Employee_Time_Shift_Ends value.
        /// </summary>
        public string Employee_Time_Shift_Ends
        {
            get { return _Employee_Time_Shift_Ends; }
            set { _Employee_Time_Shift_Ends = value; }
        }

        /// <summary> 
        /// Gets or sets the State_of_Hire value.
        /// </summary>
        public string State_of_Hire
        {
            get { return _State_of_Hire; }
            set { _State_of_Hire = value; }
        }

        /// <summary> 
        /// Gets or sets the Date_Reported_to_SRS value.
        /// </summary>
        public DateTime Date_Reported_to_SRS
        {
            get { return _Date_Reported_to_SRS; }
            set { _Date_Reported_to_SRS = value; }
        }

        /// <summary> 
        /// Gets or sets the Updated_By value.
        /// </summary>
        public decimal Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }

        /// <summary> 
        /// Gets or sets the Updated_Date value.
        /// </summary>
        public DateTime Updated_Date
        {
            get { return _Updated_Date; }
            set { _Updated_Date = value; }
        }
        ///<summary>
        ///get or sets FK_SLT_Incident_Review value
        /// </summary>
        public decimal FK_SLT_Incident_Review
        {
            get { return _FK_SLT_Incident_Review; }
            set { _FK_SLT_Incident_Review = value; }
        }
        /// <summary>
        /// get or sets Telephone_Nurse_Consultation value
        /// </summary>
        public string Telephone_Nurse_Consultation
        {
            get { return _Telephone_Nurse_Consultation; }
            set { _Telephone_Nurse_Consultation = value; }
        }
        /// <summary>
        /// Gets or sets Supervisor_Involved_In_Consultation value
        /// </summary>
        public string Supervisor_Involved_In_Consultation
        {
            get { return _Supervisor_Involved_In_Consultation; }
            set { _Supervisor_Involved_In_Consultation = value; }
        }
        #endregion

        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the WC_FR class. with the default value.

        /// </summary>
        public WC_FR()
        {

            this._PK_WC_FR_ID = -1;
            this._WC_FR_Number = -1;
            this._FK_Contact = -1;
            this._FK_Injured = -1;
            this._Supervisor_Phone = "";
            this._Motor_Vehicle_Accident = false;
            this._Date_Of_Incident = "";
            this._Time_Of_Incident = "";
            this._Filing_State = "";
            this._InjuryOccurredOffsite = false;
            this._Offsite_Address1 = "";
            this._Offsite_Address2 = "";
            this._Offsite_City = "";
            this._Offsite_State = "";
            this._Offsite_zip = "";
            this._FK_LU_Location = -1;
            this._Description_Of_Incident = "";
            this._Associate_Injured_Regular_Job = false;
            this._FK_Department_Where_Occurred = -1;
            this._FK_Nature_Of_Injury = -1;
            this._FK_Body_Parts_Affected = "";
            this._Safeguards_Provided = false;
            this._Safeguards_Used = false;
            this._Machine_Part_Involved = false;
            this._Machine_Part_Defective = false;
            this._Claim_Questionable = false;
            this._Claim_Questionable_Description = "";
            this._Date_Reported_To_Sonic = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._person_reported_to = "";
            this._Witnesses = false;
            this._Witness_1 = "";
            this._Witness_2 = "";
            this._Witness_3 = "";
            this._Witness_1_Phone = "";
            this._Witness_2_Phone = "";
            this._Witness_3_Phone = "";
            this._Fatality = false;
            this._Initial_Medical_Treatment = "";
            this._Date_of_Initial_Medical_Treatment = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Taken_By_Emergency_Transportation = false;
            this._Medical_Facility_Name = "";
            this._Medical_Facility_Address1 = "";
            this._Medical_Facility_Address2 = "";
            this._Medical_Facility_City = "";
            this._Medical_Facility_State = "";
            this._Medical_Facility_Zip = "";
            this._Medical_Facility_Phone = "";
            this._Status_Out_Of_Work = false;
            this._Status_Out_Of_Work_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Status_Return_To_Work_Unrestricted = false;
            this._Status_Return_To_Work_Unrestricted_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Status_Return_Tp_Work_Restricted = false;
            this._Status_Return_Tp_Work_Restricted_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Status_Unknown = false;
            this._Next_Doctor_Visit = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Treating_Physician_Name = "";
            this._Admitted_to_Hospital = false;
            this._Still_In_Hospital = false;
            this._Referring_Physician = false;
            this._Physician_Name = "";
            this._Physician_Address1 = "";
            this._Physician_Address2 = "";
            this._Physician_City = "";
            this._Physician_State = "";
            this._Physician_Zip = "";
            this._Physician_Phone = "";
            this._Comments = "";
            this._Complete = false;
            this._Alternate_Phone_2 = "";
            this._Employee_hrs_per_week = -1;
            this._Employee_Days_per_week = -1;
            this._Employee_Time_Shift_Begins = "";
            this._Employee_Time_Shift_Ends = "";
            this._State_of_Hire = "";
            this._Date_Reported_to_SRS = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Updated_By = -1;
            this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Initial_Claim_Classification = string.Empty;
            this._FK_SLT_Incident_Review = -1;
            this._Telephone_Nurse_Consultation = null;
            this._Supervisor_Involved_In_Consultation = null; 
        }

        /// <summary> 

        /// Initializes a new instance of the WC_FR class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public WC_FR(decimal PK)
        {

            DataTable dtWC_FR = SelectByPK(PK).Tables[0];

            if (dtWC_FR.Rows.Count > 0)
            {

                DataRow drWC_FR = dtWC_FR.Rows[0];

                this._PK_WC_FR_ID = drWC_FR["PK_WC_FR_ID"] != DBNull.Value ? Convert.ToDecimal(drWC_FR["PK_WC_FR_ID"]) : 0;
                this._WC_FR_Number = drWC_FR["WC_FR_Number"] != DBNull.Value ? Convert.ToDecimal(drWC_FR["WC_FR_Number"]) : 0;
                this._FK_Contact = drWC_FR["FK_Contact"] != DBNull.Value ? Convert.ToDecimal(drWC_FR["FK_Contact"]) : 0;
                this._FK_Injured = drWC_FR["FK_Injured"] != DBNull.Value ? Convert.ToDecimal(drWC_FR["FK_Injured"]) : 0;
                this._Supervisor_Phone = Convert.ToString(drWC_FR["Supervisor_Phone"]);
                this._Motor_Vehicle_Accident = drWC_FR["Motor_Vehicle_Accident"] != DBNull.Value ? Convert.ToBoolean(drWC_FR["Motor_Vehicle_Accident"]) : false;
                this._Date_Of_Incident = Convert.ToString(drWC_FR["Date_Of_Incident"]);
                this._Time_Of_Incident = Convert.ToString(drWC_FR["Time_Of_Incident"]);
                this._Filing_State = Convert.ToString(drWC_FR["Filing_State"]);
                this._InjuryOccurredOffsite = drWC_FR["InjuryOccurredOffsite"] != DBNull.Value ? Convert.ToBoolean(drWC_FR["InjuryOccurredOffsite"]) : false;
                this._Offsite_Address1 = Convert.ToString(drWC_FR["Offsite_Address1"]);
                this._Offsite_Address2 = Convert.ToString(drWC_FR["Offsite_Address2"]);
                this._Offsite_City = Convert.ToString(drWC_FR["Offsite_City"]);
                this._Offsite_State = Convert.ToString(drWC_FR["Offsite_State"]);
                this._Offsite_zip = Convert.ToString(drWC_FR["Offsite_zip"]);
                this._FK_LU_Location = drWC_FR["FK_LU_Location"] != DBNull.Value ? Convert.ToDecimal(drWC_FR["FK_LU_Location"]) : 0;
                this._Description_Of_Incident = Convert.ToString(drWC_FR["Description_Of_Incident"]);
                if (drWC_FR["Associate_Injured_Regular_Job"] != DBNull.Value)
                    this._Associate_Injured_Regular_Job = Convert.ToBoolean(drWC_FR["Associate_Injured_Regular_Job"]);
                this._FK_Department_Where_Occurred = drWC_FR["FK_Department_Where_Occurred"] != DBNull.Value ? Convert.ToDecimal(drWC_FR["FK_Department_Where_Occurred"]) : 0;
                this._FK_Nature_Of_Injury = drWC_FR["FK_Nature_Of_Injury"] != DBNull.Value ? Convert.ToDecimal(drWC_FR["FK_Nature_Of_Injury"]) : 0;
                this._FK_Body_Parts_Affected = Convert.ToString(drWC_FR["FK_Body_Parts_Affected"]);
                if (drWC_FR["Safeguards_Provided"] != DBNull.Value)
                    this._Safeguards_Provided = Convert.ToBoolean(drWC_FR["Safeguards_Provided"]);
                if (drWC_FR["Safeguards_Used"] != DBNull.Value)
                    this._Safeguards_Used = Convert.ToBoolean(drWC_FR["Safeguards_Used"]);
                if (drWC_FR["Machine_Part_Involved"] != DBNull.Value)
                    this._Machine_Part_Involved = Convert.ToBoolean(drWC_FR["Machine_Part_Involved"]);
                if (drWC_FR["Machine_Part_Defective"] != DBNull.Value)
                    this._Machine_Part_Defective = Convert.ToBoolean(drWC_FR["Machine_Part_Defective"]);
                if (drWC_FR["Claim_Questionable"] != DBNull.Value)
                    this._Claim_Questionable = Convert.ToBoolean(drWC_FR["Claim_Questionable"]);
                this._Claim_Questionable_Description = Convert.ToString(drWC_FR["Claim_Questionable_Description"]);
                this._Date_Reported_To_Sonic = drWC_FR["Date_Reported_To_Sonic"] != DBNull.Value ? Convert.ToDateTime(drWC_FR["Date_Reported_To_Sonic"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._person_reported_to = Convert.ToString(drWC_FR["person_reported_to"]);
                this._Witnesses = drWC_FR["Witnesses"] != DBNull.Value ? Convert.ToBoolean(drWC_FR["Witnesses"]) : false;
                this._Witness_1 = Convert.ToString(drWC_FR["Witness_1"]);
                this._Witness_2 = Convert.ToString(drWC_FR["Witness_2"]);
                this._Witness_3 = Convert.ToString(drWC_FR["Witness_3"]);
                this._Witness_1_Phone = Convert.ToString(drWC_FR["Witness_1_Phone"]);
                this._Witness_2_Phone = Convert.ToString(drWC_FR["Witness_2_Phone"]);
                this._Witness_3_Phone = Convert.ToString(drWC_FR["Witness_3_Phone"]);
                this._Fatality = drWC_FR["Fatality"] != DBNull.Value ? Convert.ToBoolean(drWC_FR["Fatality"]) : false;
                this._Initial_Medical_Treatment = Convert.ToString(drWC_FR["Initial_Medical_Treatment"]);
                this._Date_of_Initial_Medical_Treatment = drWC_FR["Date_of_Initial_Medical_Treatment"] != DBNull.Value ? Convert.ToDateTime(drWC_FR["Date_of_Initial_Medical_Treatment"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Taken_By_Emergency_Transportation = drWC_FR["Taken_By_Emergency_Transportation"] != DBNull.Value ? Convert.ToBoolean(drWC_FR["Taken_By_Emergency_Transportation"]) : false;
                this._Medical_Facility_Name = Convert.ToString(drWC_FR["Medical_Facility_Name"]);
                this._Medical_Facility_Address1 = Convert.ToString(drWC_FR["Medical_Facility_Address1"]);
                this._Medical_Facility_Address2 = Convert.ToString(drWC_FR["Medical_Facility_Address2"]);
                this._Medical_Facility_City = Convert.ToString(drWC_FR["Medical_Facility_City"]);
                this._Medical_Facility_State = Convert.ToString(drWC_FR["Medical_Facility_State"]);
                this._Medical_Facility_Zip = Convert.ToString(drWC_FR["Medical_Facility_Zip"]);
                this._Medical_Facility_Phone = Convert.ToString(drWC_FR["Medical_Facility_Phone"]);
                this._Status_Out_Of_Work = drWC_FR["Status_Out_Of_Work"] != DBNull.Value ? Convert.ToBoolean(drWC_FR["Status_Out_Of_Work"]) : false;
                this._Status_Out_Of_Work_Date = drWC_FR["Status_Out_Of_Work_Date"] != DBNull.Value ? Convert.ToDateTime(drWC_FR["Status_Out_Of_Work_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Status_Return_To_Work_Unrestricted = drWC_FR["Status_Return_To_Work_Unrestricted"] != DBNull.Value ? Convert.ToBoolean(drWC_FR["Status_Return_To_Work_Unrestricted"]) : false;
                this._Status_Return_To_Work_Unrestricted_Date = drWC_FR["Status_Return_To_Work_Unrestricted_Date"] != DBNull.Value ? Convert.ToDateTime(drWC_FR["Status_Return_To_Work_Unrestricted_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Status_Return_Tp_Work_Restricted = drWC_FR["Status_Return_Tp_Work_Restricted"] != DBNull.Value ? Convert.ToBoolean(drWC_FR["Status_Return_Tp_Work_Restricted"]) : false;
                this._Status_Return_Tp_Work_Restricted_Date = drWC_FR["Status_Return_Tp_Work_Restricted_Date"] != DBNull.Value ? Convert.ToDateTime(drWC_FR["Status_Return_Tp_Work_Restricted_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Status_Unknown = drWC_FR["Status_Unknown"] != DBNull.Value ? Convert.ToBoolean(drWC_FR["Status_Unknown"]) : false;
                this._Next_Doctor_Visit = drWC_FR["Next_Doctor_Visit"] != DBNull.Value ? Convert.ToDateTime(drWC_FR["Next_Doctor_Visit"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Treating_Physician_Name = Convert.ToString(drWC_FR["Treating_Physician_Name"]);
                if (drWC_FR["Admitted_to_Hospital"] != DBNull.Value)
                    this._Admitted_to_Hospital = Convert.ToBoolean(drWC_FR["Admitted_to_Hospital"]);
                if (drWC_FR["Still_In_Hospital"] != DBNull.Value)
                    this._Still_In_Hospital = Convert.ToBoolean(drWC_FR["Still_In_Hospital"]);
                if (drWC_FR["Referring_Physician"] != DBNull.Value)
                    this._Referring_Physician = Convert.ToBoolean(drWC_FR["Referring_Physician"]);
                this._Physician_Name = Convert.ToString(drWC_FR["Physician_Name"]);
                this._Physician_Address1 = Convert.ToString(drWC_FR["Physician_Address1"]);
                this._Physician_Address2 = Convert.ToString(drWC_FR["Physician_Address2"]);
                this._Physician_City = Convert.ToString(drWC_FR["Physician_City"]);
                this._Physician_State = Convert.ToString(drWC_FR["Physician_State"]);
                this._Physician_Zip = Convert.ToString(drWC_FR["Physician_Zip"]);
                this._Physician_Phone = Convert.ToString(drWC_FR["Physician_Phone"]);
                this._Comments = Convert.ToString(drWC_FR["Comments"]);
                this._Complete = drWC_FR["Complete"] != DBNull.Value ? Convert.ToBoolean(drWC_FR["Complete"]) : false;
                this._Alternate_Phone_2 = Convert.ToString(drWC_FR["Alternate_Phone_2"]);
                this._Employee_hrs_per_week = drWC_FR["Employee_hrs_per_week"] != DBNull.Value ? Convert.ToDecimal(drWC_FR["Employee_hrs_per_week"]) : 0;
                this._Employee_Days_per_week = drWC_FR["Employee_Days_per_week"] != DBNull.Value ? Convert.ToDecimal(drWC_FR["Employee_Days_per_week"]) : 0;
                this._Employee_Time_Shift_Begins = Convert.ToString(drWC_FR["Employee_Time_Shift_Begins"]);
                this._Employee_Time_Shift_Ends = Convert.ToString(drWC_FR["Employee_Time_Shift_Ends"]);
                this._State_of_Hire = Convert.ToString(drWC_FR["State_of_Hire"]);
                this._Date_Reported_to_SRS = drWC_FR["Date_Reported_to_SRS"] != DBNull.Value ? Convert.ToDateTime(drWC_FR["Date_Reported_to_SRS"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Updated_By = drWC_FR["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drWC_FR["Updated_By"]) : 0;
                this._Updated_Date = drWC_FR["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drWC_FR["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Initial_Claim_Classification = Convert.ToString(drWC_FR["Initial_Claim_Classification"]);
                this._FK_SLT_Incident_Review = drWC_FR["FK_SLT_Incident_Review"] != DBNull.Value ? Convert.ToDecimal(drWC_FR["FK_SLT_Incident_Review"]) : 0;
                this._Telephone_Nurse_Consultation = Convert.ToString(drWC_FR["Telephone_Nurse_Consultation"]);
                this._Supervisor_Involved_In_Consultation = Convert.ToString(drWC_FR["Supervisor_Involved_In_Consultation"]);
            }

            else
            {

                this._PK_WC_FR_ID = -1;
                this._WC_FR_Number = -1;
                this._FK_Contact = -1;
                this._FK_Injured = -1;
                this._Supervisor_Phone = "";
                this._Motor_Vehicle_Accident = false;
                this._Date_Of_Incident = "";
                this._Time_Of_Incident = "";
                this._Filing_State = "";
                this._InjuryOccurredOffsite = false;
                this._Offsite_Address1 = "";
                this._Offsite_Address2 = "";
                this._Offsite_City = "";
                this._Offsite_State = "";
                this._Offsite_zip = "";
                this._FK_LU_Location = -1;
                this._Description_Of_Incident = "";
                this._Associate_Injured_Regular_Job = false;
                this._FK_Department_Where_Occurred = -1;
                this._FK_Nature_Of_Injury = -1;
                this._FK_Body_Parts_Affected = "";
                this._Safeguards_Provided = false;
                this._Safeguards_Used = false;
                this._Machine_Part_Involved = false;
                this._Machine_Part_Defective = false;
                this._Claim_Questionable = false;
                this._Claim_Questionable_Description = "";
                this._Date_Reported_To_Sonic = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._person_reported_to = "";
                this._Witnesses = false;
                this._Witness_1 = "";
                this._Witness_2 = "";
                this._Witness_3 = "";
                this._Witness_1_Phone = "";
                this._Witness_2_Phone = "";
                this._Witness_3_Phone = "";
                this._Fatality = false;
                this._Initial_Medical_Treatment = "";
                this._Date_of_Initial_Medical_Treatment = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Taken_By_Emergency_Transportation = false;
                this._Medical_Facility_Name = "";
                this._Medical_Facility_Address1 = "";
                this._Medical_Facility_Address2 = "";
                this._Medical_Facility_City = "";
                this._Medical_Facility_State = "";
                this._Medical_Facility_Zip = "";
                this._Medical_Facility_Phone = "";
                this._Status_Out_Of_Work = false;
                this._Status_Out_Of_Work_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Status_Return_To_Work_Unrestricted = false;
                this._Status_Return_To_Work_Unrestricted_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Status_Return_Tp_Work_Restricted = false;
                this._Status_Return_Tp_Work_Restricted_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Status_Unknown = false;
                this._Next_Doctor_Visit = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Treating_Physician_Name = "";
                this._Admitted_to_Hospital = false;
                this._Still_In_Hospital = false;
                this._Referring_Physician = false;
                this._Physician_Name = "";
                this._Physician_Address1 = "";
                this._Physician_Address2 = "";
                this._Physician_City = "";
                this._Physician_State = "";
                this._Physician_Zip = "";
                this._Physician_Phone = "";
                this._Comments = "";
                this._Complete = false;
                this._Alternate_Phone_2 = "";
                this._Employee_hrs_per_week = -1;
                this._Employee_Days_per_week = -1;
                this._Employee_Time_Shift_Begins = "";
                this._Employee_Time_Shift_Ends = "";
                this._State_of_Hire = "";
                this._Date_Reported_to_SRS = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Initial_Claim_Classification = string.Empty;
                this._FK_SLT_Incident_Review = -1;
                this._Telephone_Nurse_Consultation = null;
                this._Supervisor_Involved_In_Consultation = null;
            }

        }

        /// <summary> 

        /// Initializes a new instance of the WC_FR class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public WC_FR(decimal WC_FR_Number, Boolean Temp)
        {

            DataTable dtWC_FR = SelectByWC_FR_Number(WC_FR_Number).Tables[0];

            if (dtWC_FR.Rows.Count > 0)
            {

                DataRow drWC_FR = dtWC_FR.Rows[0];

                this._PK_WC_FR_ID = drWC_FR["PK_WC_FR_ID"] != DBNull.Value ? Convert.ToDecimal(drWC_FR["PK_WC_FR_ID"]) : 0;
                this._WC_FR_Number = drWC_FR["WC_FR_Number"] != DBNull.Value ? Convert.ToDecimal(drWC_FR["WC_FR_Number"]) : 0;
                this._FK_Contact = drWC_FR["FK_Contact"] != DBNull.Value ? Convert.ToDecimal(drWC_FR["FK_Contact"]) : 0;
                this._FK_Injured = drWC_FR["FK_Injured"] != DBNull.Value ? Convert.ToDecimal(drWC_FR["FK_Injured"]) : 0;
                this._Supervisor_Phone = Convert.ToString(drWC_FR["Supervisor_Phone"]);
                this._Motor_Vehicle_Accident = drWC_FR["Motor_Vehicle_Accident"] != DBNull.Value ? Convert.ToBoolean(drWC_FR["Motor_Vehicle_Accident"]) : false;
                this._Date_Of_Incident = Convert.ToString(drWC_FR["Date_Of_Incident"]);
                this._Time_Of_Incident = Convert.ToString(drWC_FR["Time_Of_Incident"]);
                this._Filing_State = Convert.ToString(drWC_FR["Filing_State"]);
                this._InjuryOccurredOffsite = drWC_FR["InjuryOccurredOffsite"] != DBNull.Value ? Convert.ToBoolean(drWC_FR["InjuryOccurredOffsite"]) : false;
                this._Offsite_Address1 = Convert.ToString(drWC_FR["Offsite_Address1"]);
                this._Offsite_Address2 = Convert.ToString(drWC_FR["Offsite_Address2"]);
                this._Offsite_City = Convert.ToString(drWC_FR["Offsite_City"]);
                this._Offsite_State = Convert.ToString(drWC_FR["Offsite_State"]);
                this._Offsite_zip = Convert.ToString(drWC_FR["Offsite_zip"]);
                this._FK_LU_Location = drWC_FR["FK_LU_Location"] != DBNull.Value ? Convert.ToDecimal(drWC_FR["FK_LU_Location"]) : 0;
                this._Description_Of_Incident = Convert.ToString(drWC_FR["Description_Of_Incident"]);
                if (drWC_FR["Associate_Injured_Regular_Job"] != DBNull.Value)
                    this._Associate_Injured_Regular_Job = Convert.ToBoolean(drWC_FR["Associate_Injured_Regular_Job"]);
                this._FK_Department_Where_Occurred = drWC_FR["FK_Department_Where_Occurred"] != DBNull.Value ? Convert.ToDecimal(drWC_FR["FK_Department_Where_Occurred"]) : 0;
                this._FK_Nature_Of_Injury = drWC_FR["FK_Nature_Of_Injury"] != DBNull.Value ? Convert.ToDecimal(drWC_FR["FK_Nature_Of_Injury"]) : 0;
                this._FK_Body_Parts_Affected = Convert.ToString(drWC_FR["FK_Body_Parts_Affected"]);
                if (drWC_FR["Safeguards_Provided"] != DBNull.Value)
                    this._Safeguards_Provided = Convert.ToBoolean(drWC_FR["Safeguards_Provided"]);
                if (drWC_FR["Safeguards_Used"] != DBNull.Value)
                    this._Safeguards_Used = Convert.ToBoolean(drWC_FR["Safeguards_Used"]);
                if (drWC_FR["Machine_Part_Involved"] != DBNull.Value)
                    this._Machine_Part_Involved = Convert.ToBoolean(drWC_FR["Machine_Part_Involved"]);
                if (drWC_FR["Machine_Part_Defective"] != DBNull.Value)
                    this._Machine_Part_Defective = Convert.ToBoolean(drWC_FR["Machine_Part_Defective"]);
                if (drWC_FR["Claim_Questionable"] != DBNull.Value)
                    this._Claim_Questionable = Convert.ToBoolean(drWC_FR["Claim_Questionable"]);
                this._Claim_Questionable_Description = Convert.ToString(drWC_FR["Claim_Questionable_Description"]);
                this._Date_Reported_To_Sonic = drWC_FR["Date_Reported_To_Sonic"] != DBNull.Value ? Convert.ToDateTime(drWC_FR["Date_Reported_To_Sonic"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._person_reported_to = Convert.ToString(drWC_FR["person_reported_to"]);
                this._Witnesses = drWC_FR["Witnesses"] != DBNull.Value ? Convert.ToBoolean(drWC_FR["Witnesses"]) : false;
                this._Witness_1 = Convert.ToString(drWC_FR["Witness_1"]);
                this._Witness_2 = Convert.ToString(drWC_FR["Witness_2"]);
                this._Witness_3 = Convert.ToString(drWC_FR["Witness_3"]);
                this._Witness_1_Phone = Convert.ToString(drWC_FR["Witness_1_Phone"]);
                this._Witness_2_Phone = Convert.ToString(drWC_FR["Witness_2_Phone"]);
                this._Witness_3_Phone = Convert.ToString(drWC_FR["Witness_3_Phone"]);
                this._Fatality = drWC_FR["Fatality"] != DBNull.Value ? Convert.ToBoolean(drWC_FR["Fatality"]) : false;
                this._Initial_Medical_Treatment = Convert.ToString(drWC_FR["Initial_Medical_Treatment"]);
                this._Date_of_Initial_Medical_Treatment = drWC_FR["Date_of_Initial_Medical_Treatment"] != DBNull.Value ? Convert.ToDateTime(drWC_FR["Date_of_Initial_Medical_Treatment"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Taken_By_Emergency_Transportation = drWC_FR["Taken_By_Emergency_Transportation"] != DBNull.Value ? Convert.ToBoolean(drWC_FR["Taken_By_Emergency_Transportation"]) : false;
                this._Medical_Facility_Name = Convert.ToString(drWC_FR["Medical_Facility_Name"]);
                this._Medical_Facility_Address1 = Convert.ToString(drWC_FR["Medical_Facility_Address1"]);
                this._Medical_Facility_Address2 = Convert.ToString(drWC_FR["Medical_Facility_Address2"]);
                this._Medical_Facility_City = Convert.ToString(drWC_FR["Medical_Facility_City"]);
                this._Medical_Facility_State = Convert.ToString(drWC_FR["Medical_Facility_State"]);
                this._Medical_Facility_Zip = Convert.ToString(drWC_FR["Medical_Facility_Zip"]);
                this._Medical_Facility_Phone = Convert.ToString(drWC_FR["Medical_Facility_Phone"]);
                this._Status_Out_Of_Work = drWC_FR["Status_Out_Of_Work"] != DBNull.Value ? Convert.ToBoolean(drWC_FR["Status_Out_Of_Work"]) : false;
                this._Status_Out_Of_Work_Date = drWC_FR["Status_Out_Of_Work_Date"] != DBNull.Value ? Convert.ToDateTime(drWC_FR["Status_Out_Of_Work_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Status_Return_To_Work_Unrestricted = drWC_FR["Status_Return_To_Work_Unrestricted"] != DBNull.Value ? Convert.ToBoolean(drWC_FR["Status_Return_To_Work_Unrestricted"]) : false;
                this._Status_Return_To_Work_Unrestricted_Date = drWC_FR["Status_Return_To_Work_Unrestricted_Date"] != DBNull.Value ? Convert.ToDateTime(drWC_FR["Status_Return_To_Work_Unrestricted_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Status_Return_Tp_Work_Restricted = drWC_FR["Status_Return_Tp_Work_Restricted"] != DBNull.Value ? Convert.ToBoolean(drWC_FR["Status_Return_Tp_Work_Restricted"]) : false;
                this._Status_Return_Tp_Work_Restricted_Date = drWC_FR["Status_Return_Tp_Work_Restricted_Date"] != DBNull.Value ? Convert.ToDateTime(drWC_FR["Status_Return_Tp_Work_Restricted_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Status_Unknown = drWC_FR["Status_Unknown"] != DBNull.Value ? Convert.ToBoolean(drWC_FR["Status_Unknown"]) : false;
                this._Next_Doctor_Visit = drWC_FR["Next_Doctor_Visit"] != DBNull.Value ? Convert.ToDateTime(drWC_FR["Next_Doctor_Visit"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Treating_Physician_Name = Convert.ToString(drWC_FR["Treating_Physician_Name"]);
                if (drWC_FR["Admitted_to_Hospital"] != DBNull.Value)
                    this._Admitted_to_Hospital = Convert.ToBoolean(drWC_FR["Admitted_to_Hospital"]);
                if (drWC_FR["Still_In_Hospital"] != DBNull.Value)
                    this._Still_In_Hospital = Convert.ToBoolean(drWC_FR["Still_In_Hospital"]);
                if (drWC_FR["Referring_Physician"] != DBNull.Value)
                    this._Referring_Physician = Convert.ToBoolean(drWC_FR["Referring_Physician"]);
                this._Physician_Name = Convert.ToString(drWC_FR["Physician_Name"]);
                this._Physician_Address1 = Convert.ToString(drWC_FR["Physician_Address1"]);
                this._Physician_Address2 = Convert.ToString(drWC_FR["Physician_Address2"]);
                this._Physician_City = Convert.ToString(drWC_FR["Physician_City"]);
                this._Physician_State = Convert.ToString(drWC_FR["Physician_State"]);
                this._Physician_Zip = Convert.ToString(drWC_FR["Physician_Zip"]);
                this._Physician_Phone = Convert.ToString(drWC_FR["Physician_Phone"]);
                this._Comments = Convert.ToString(drWC_FR["Comments"]);
                this._Complete = drWC_FR["Complete"] != DBNull.Value ? Convert.ToBoolean(drWC_FR["Complete"]) : false;
                this._Alternate_Phone_2 = Convert.ToString(drWC_FR["Alternate_Phone_2"]);
                this._Employee_hrs_per_week = drWC_FR["Employee_hrs_per_week"] != DBNull.Value ? Convert.ToDecimal(drWC_FR["Employee_hrs_per_week"]) : 0;
                this._Employee_Days_per_week = drWC_FR["Employee_Days_per_week"] != DBNull.Value ? Convert.ToDecimal(drWC_FR["Employee_Days_per_week"]) : 0;
                this._Employee_Time_Shift_Begins = Convert.ToString(drWC_FR["Employee_Time_Shift_Begins"]);
                this._Employee_Time_Shift_Ends = Convert.ToString(drWC_FR["Employee_Time_Shift_Ends"]);
                this._State_of_Hire = Convert.ToString(drWC_FR["State_of_Hire"]);
                this._Date_Reported_to_SRS = drWC_FR["Date_Reported_to_SRS"] != DBNull.Value ? Convert.ToDateTime(drWC_FR["Date_Reported_to_SRS"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Updated_By = drWC_FR["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drWC_FR["Updated_By"]) : 0;
                this._Updated_Date = drWC_FR["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drWC_FR["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Initial_Claim_Classification = Convert.ToString(drWC_FR["Initial_Claim_Classification"]);
                this._FK_SLT_Incident_Review = drWC_FR["FK_SLT_Incident_Review"] != DBNull.Value ? Convert.ToDecimal(drWC_FR["FK_SLT_Incident_Review"]) : 0;
                this._Telephone_Nurse_Consultation = Convert.ToString(drWC_FR["Telephone_Nurse_Consultation"]);
                this._Supervisor_Involved_In_Consultation = Convert.ToString(drWC_FR["Supervisor_Involved_In_Consultation"]);

            }

            else
            {

                this._PK_WC_FR_ID = -1;
                this._WC_FR_Number = -1;
                this._FK_Contact = -1;
                this._FK_Injured = -1;
                this._Supervisor_Phone = "";
                this._Motor_Vehicle_Accident = false;
                this._Date_Of_Incident = "";
                this._Time_Of_Incident = "";
                this._Filing_State = "";
                this._InjuryOccurredOffsite = false;
                this._Offsite_Address1 = "";
                this._Offsite_Address2 = "";
                this._Offsite_City = "";
                this._Offsite_State = "";
                this._Offsite_zip = "";
                this._FK_LU_Location = -1;
                this._Description_Of_Incident = "";
                this._Associate_Injured_Regular_Job = false;
                this._FK_Department_Where_Occurred = -1;
                this._FK_Nature_Of_Injury = -1;
                this._FK_Body_Parts_Affected = "";
                this._Safeguards_Provided = false;
                this._Safeguards_Used = false;
                this._Machine_Part_Involved = false;
                this._Machine_Part_Defective = false;
                this._Claim_Questionable = false;
                this._Claim_Questionable_Description = "";
                this._Date_Reported_To_Sonic = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._person_reported_to = "";
                this._Witnesses = false;
                this._Witness_1 = "";
                this._Witness_2 = "";
                this._Witness_3 = "";
                this._Witness_1_Phone = "";
                this._Witness_2_Phone = "";
                this._Witness_3_Phone = "";
                this._Fatality = false;
                this._Initial_Medical_Treatment = "";
                this._Date_of_Initial_Medical_Treatment = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Taken_By_Emergency_Transportation = false;
                this._Medical_Facility_Name = "";
                this._Medical_Facility_Address1 = "";
                this._Medical_Facility_Address2 = "";
                this._Medical_Facility_City = "";
                this._Medical_Facility_State = "";
                this._Medical_Facility_Zip = "";
                this._Medical_Facility_Phone = "";
                this._Status_Out_Of_Work = false;
                this._Status_Out_Of_Work_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Status_Return_To_Work_Unrestricted = false;
                this._Status_Return_To_Work_Unrestricted_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Status_Return_Tp_Work_Restricted = false;
                this._Status_Return_Tp_Work_Restricted_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Status_Unknown = false;
                this._Next_Doctor_Visit = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Treating_Physician_Name = "";
                this._Admitted_to_Hospital = false;
                this._Still_In_Hospital = false;
                this._Referring_Physician = false;
                this._Physician_Name = "";
                this._Physician_Address1 = "";
                this._Physician_Address2 = "";
                this._Physician_City = "";
                this._Physician_State = "";
                this._Physician_Zip = "";
                this._Physician_Phone = "";
                this._Comments = "";
                this._Complete = false;
                this._Alternate_Phone_2 = "";
                this._Employee_hrs_per_week = -1;
                this._Employee_Days_per_week = -1;
                this._Employee_Time_Shift_Begins = "";
                this._Employee_Time_Shift_Ends = "";
                this._State_of_Hire = "";
                this._Date_Reported_to_SRS = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Initial_Claim_Classification = string.Empty;
                this._FK_SLT_Incident_Review = -1;
                this._Telephone_Nurse_Consultation = null;
                this._Supervisor_Involved_In_Consultation = null;
            }

        }
        #endregion

        #region Methods
        /// <summary>
        /// Inserts a record into the WC_FR table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_FRInsert");

            db.AddInParameter(dbCommand, "WC_FR_Number", DbType.Decimal, this._WC_FR_Number);
            db.AddInParameter(dbCommand, "FK_Contact", DbType.Decimal, this._FK_Contact);
            db.AddInParameter(dbCommand, "FK_Injured", DbType.Decimal, this._FK_Injured);
            db.AddInParameter(dbCommand, "Supervisor_Phone", DbType.String, this._Supervisor_Phone);
            db.AddInParameter(dbCommand, "Motor_Vehicle_Accident", DbType.Boolean, this._Motor_Vehicle_Accident);
            db.AddInParameter(dbCommand, "Date_Of_Incident", DbType.String, this._Date_Of_Incident);
            db.AddInParameter(dbCommand, "Time_Of_Incident", DbType.String, this._Time_Of_Incident);
            db.AddInParameter(dbCommand, "Filing_State", DbType.String, this._Filing_State);
            db.AddInParameter(dbCommand, "InjuryOccurredOffsite", DbType.Boolean, this._InjuryOccurredOffsite);
            db.AddInParameter(dbCommand, "Offsite_Address1", DbType.String, this._Offsite_Address1);
            db.AddInParameter(dbCommand, "Offsite_Address2", DbType.String, this._Offsite_Address2);
            db.AddInParameter(dbCommand, "Offsite_City", DbType.String, this._Offsite_City);
            db.AddInParameter(dbCommand, "Offsite_State", DbType.String, this._Offsite_State);
            db.AddInParameter(dbCommand, "Offsite_zip", DbType.String, this._Offsite_zip);
            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);
            db.AddInParameter(dbCommand, "Description_Of_Incident", DbType.String, this._Description_Of_Incident);
            db.AddInParameter(dbCommand, "Associate_Injured_Regular_Job", DbType.Boolean, this._Associate_Injured_Regular_Job);
            db.AddInParameter(dbCommand, "FK_Department_Where_Occurred", DbType.Decimal, this._FK_Department_Where_Occurred);
            db.AddInParameter(dbCommand, "FK_Nature_Of_Injury", DbType.Decimal, this._FK_Nature_Of_Injury);
            db.AddInParameter(dbCommand, "FK_Body_Parts_Affected", DbType.String, this._FK_Body_Parts_Affected);
            db.AddInParameter(dbCommand, "Safeguards_Provided", DbType.Boolean, this._Safeguards_Provided);
            db.AddInParameter(dbCommand, "Safeguards_Used", DbType.Boolean, this._Safeguards_Used);
            db.AddInParameter(dbCommand, "Machine_Part_Involved", DbType.Boolean, this._Machine_Part_Involved);
            db.AddInParameter(dbCommand, "Machine_Part_Defective", DbType.Boolean, this._Machine_Part_Defective);
            db.AddInParameter(dbCommand, "Claim_Questionable", DbType.Boolean, this._Claim_Questionable);
            db.AddInParameter(dbCommand, "Claim_Questionable_Description", DbType.String, this._Claim_Questionable_Description);
            db.AddInParameter(dbCommand, "Date_Reported_To_Sonic", DbType.DateTime, this._Date_Reported_To_Sonic);
            db.AddInParameter(dbCommand, "person_reported_to", DbType.String, this._person_reported_to);
            db.AddInParameter(dbCommand, "Witnesses", DbType.Boolean, this._Witnesses);
            db.AddInParameter(dbCommand, "Witness_1", DbType.String, this._Witness_1);
            db.AddInParameter(dbCommand, "Witness_2", DbType.String, this._Witness_2);
            db.AddInParameter(dbCommand, "Witness_3", DbType.String, this._Witness_3);
            db.AddInParameter(dbCommand, "Witness_1_Phone", DbType.String, this._Witness_1_Phone);
            db.AddInParameter(dbCommand, "Witness_2_Phone", DbType.String, this._Witness_2_Phone);
            db.AddInParameter(dbCommand, "Witness_3_Phone", DbType.String, this._Witness_3_Phone);
            db.AddInParameter(dbCommand, "Fatality", DbType.Boolean, this._Fatality);
            db.AddInParameter(dbCommand, "Initial_Medical_Treatment", DbType.String, this._Initial_Medical_Treatment);
            db.AddInParameter(dbCommand, "Date_of_Initial_Medical_Treatment", DbType.DateTime, this._Date_of_Initial_Medical_Treatment);
            db.AddInParameter(dbCommand, "Taken_By_Emergency_Transportation", DbType.Boolean, this._Taken_By_Emergency_Transportation);
            db.AddInParameter(dbCommand, "Medical_Facility_Name", DbType.String, this._Medical_Facility_Name);
            db.AddInParameter(dbCommand, "Medical_Facility_Address1", DbType.String, this._Medical_Facility_Address1);
            db.AddInParameter(dbCommand, "Medical_Facility_Address2", DbType.String, this._Medical_Facility_Address2);
            db.AddInParameter(dbCommand, "Medical_Facility_City", DbType.String, this._Medical_Facility_City);
            db.AddInParameter(dbCommand, "Medical_Facility_State", DbType.String, this._Medical_Facility_State);
            db.AddInParameter(dbCommand, "Medical_Facility_Zip", DbType.String, this._Medical_Facility_Zip);
            db.AddInParameter(dbCommand, "Medical_Facility_Phone", DbType.String, this._Medical_Facility_Phone);
            db.AddInParameter(dbCommand, "Status_Out_Of_Work", DbType.Boolean, this._Status_Out_Of_Work);
            db.AddInParameter(dbCommand, "Status_Out_Of_Work_Date", DbType.DateTime, this._Status_Out_Of_Work_Date);
            db.AddInParameter(dbCommand, "Status_Return_To_Work_Unrestricted", DbType.Boolean, this._Status_Return_To_Work_Unrestricted);
            db.AddInParameter(dbCommand, "Status_Return_To_Work_Unrestricted_Date", DbType.DateTime, this._Status_Return_To_Work_Unrestricted_Date);
            db.AddInParameter(dbCommand, "Status_Return_Tp_Work_Restricted", DbType.Boolean, this._Status_Return_Tp_Work_Restricted);
            db.AddInParameter(dbCommand, "Status_Return_Tp_Work_Restricted_Date", DbType.DateTime, this._Status_Return_Tp_Work_Restricted_Date);
            db.AddInParameter(dbCommand, "Status_Unknown", DbType.Boolean, this._Status_Unknown);
            db.AddInParameter(dbCommand, "Next_Doctor_Visit", DbType.DateTime, this._Next_Doctor_Visit);
            db.AddInParameter(dbCommand, "Treating_Physician_Name", DbType.String, this._Treating_Physician_Name);
            db.AddInParameter(dbCommand, "Admitted_to_Hospital", DbType.Boolean, this._Admitted_to_Hospital);
            db.AddInParameter(dbCommand, "Still_In_Hospital", DbType.Boolean, this._Still_In_Hospital);
            db.AddInParameter(dbCommand, "Referring_Physician", DbType.Boolean, this._Referring_Physician);
            db.AddInParameter(dbCommand, "Physician_Name", DbType.String, this._Physician_Name);
            db.AddInParameter(dbCommand, "Physician_Address1", DbType.String, this._Physician_Address1);
            db.AddInParameter(dbCommand, "Physician_Address2", DbType.String, this._Physician_Address2);
            db.AddInParameter(dbCommand, "Physician_City", DbType.String, this._Physician_City);
            db.AddInParameter(dbCommand, "Physician_State", DbType.String, this._Physician_State);
            db.AddInParameter(dbCommand, "Physician_Zip", DbType.String, this._Physician_Zip);
            db.AddInParameter(dbCommand, "Physician_Phone", DbType.String, this._Physician_Phone);
            db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
            db.AddInParameter(dbCommand, "Complete", DbType.Boolean, this._Complete);
            db.AddInParameter(dbCommand, "Alternate_Phone_2", DbType.String, this._Alternate_Phone_2);
            db.AddInParameter(dbCommand, "Employee_hrs_per_week", DbType.Decimal, this._Employee_hrs_per_week);
            db.AddInParameter(dbCommand, "Employee_Days_per_week", DbType.Decimal, this._Employee_Days_per_week);
            db.AddInParameter(dbCommand, "Employee_Time_Shift_Begins", DbType.String, this._Employee_Time_Shift_Begins);
            db.AddInParameter(dbCommand, "Employee_Time_Shift_Ends", DbType.String, this._Employee_Time_Shift_Ends);
            db.AddInParameter(dbCommand, "State_of_Hire", DbType.String, this._State_of_Hire);
            db.AddInParameter(dbCommand, "Date_Reported_to_SRS", DbType.DateTime, this._Date_Reported_to_SRS);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);
            db.AddInParameter(dbCommand, "Initial_Claim_Classification", DbType.String, this._Initial_Claim_Classification);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the WC_FR table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_WC_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_FRSelectByPK");

            db.AddInParameter(dbCommand, "PK_WC_FR_ID", DbType.Decimal, pK_WC_FR_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the WC_FR table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_FRSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the WC_FR table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_FRUpdate");

            db.AddInParameter(dbCommand, "PK_WC_FR_ID", DbType.Decimal, this._PK_WC_FR_ID);
            db.AddInParameter(dbCommand, "WC_FR_Number", DbType.Decimal, this._WC_FR_Number);
            db.AddInParameter(dbCommand, "FK_Contact", DbType.Decimal, this._FK_Contact);
            db.AddInParameter(dbCommand, "FK_Injured", DbType.Decimal, this._FK_Injured);
            db.AddInParameter(dbCommand, "Supervisor_Phone", DbType.String, this._Supervisor_Phone);
            db.AddInParameter(dbCommand, "Motor_Vehicle_Accident", DbType.Boolean, this._Motor_Vehicle_Accident);
            db.AddInParameter(dbCommand, "Date_Of_Incident", DbType.String, this._Date_Of_Incident);
            db.AddInParameter(dbCommand, "Time_Of_Incident", DbType.String, this._Time_Of_Incident);
            db.AddInParameter(dbCommand, "Filing_State", DbType.String, this._Filing_State);
            db.AddInParameter(dbCommand, "InjuryOccurredOffsite", DbType.Boolean, this._InjuryOccurredOffsite);
            db.AddInParameter(dbCommand, "Offsite_Address1", DbType.String, this._Offsite_Address1);
            db.AddInParameter(dbCommand, "Offsite_Address2", DbType.String, this._Offsite_Address2);
            db.AddInParameter(dbCommand, "Offsite_City", DbType.String, this._Offsite_City);
            db.AddInParameter(dbCommand, "Offsite_State", DbType.String, this._Offsite_State);
            db.AddInParameter(dbCommand, "Offsite_zip", DbType.String, this._Offsite_zip);
            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);
            db.AddInParameter(dbCommand, "Description_Of_Incident", DbType.String, this._Description_Of_Incident);
            if (this._Associate_Injured_Regular_Job != true && this._Associate_Injured_Regular_Job != false)
            {
                db.AddInParameter(dbCommand, "Associate_Injured_Regular_Job", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Associate_Injured_Regular_Job", DbType.Boolean, this._Associate_Injured_Regular_Job);
            }

            db.AddInParameter(dbCommand, "FK_Department_Where_Occurred", DbType.Decimal, this._FK_Department_Where_Occurred);
            db.AddInParameter(dbCommand, "FK_Nature_Of_Injury", DbType.Decimal, this._FK_Nature_Of_Injury);
            db.AddInParameter(dbCommand, "FK_Body_Parts_Affected", DbType.String, this._FK_Body_Parts_Affected);
            if (this._Safeguards_Provided != true && this._Safeguards_Provided != false)
            {
                db.AddInParameter(dbCommand, "Safeguards_Provided", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Safeguards_Provided", DbType.Boolean, this._Safeguards_Provided);
            }

            if (this._Safeguards_Used != true && this._Safeguards_Used != false)
            {
                db.AddInParameter(dbCommand, "Safeguards_Used", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Safeguards_Used", DbType.Boolean, this._Safeguards_Used);
            }

            if (this._Machine_Part_Involved != true && this._Machine_Part_Involved != false)
            {
                db.AddInParameter(dbCommand, "Machine_Part_Involved", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Machine_Part_Involved", DbType.Boolean, this._Machine_Part_Involved);
            }

            if (this._Machine_Part_Defective != true && this._Machine_Part_Defective != false)
            {
                db.AddInParameter(dbCommand, "Machine_Part_Defective", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Machine_Part_Defective", DbType.Boolean, this._Machine_Part_Defective);
            }

            if (this._Claim_Questionable != true && this._Claim_Questionable != false)
            {
                db.AddInParameter(dbCommand, "Claim_Questionable", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Claim_Questionable", DbType.Boolean, this._Claim_Questionable);
            }

            db.AddInParameter(dbCommand, "Claim_Questionable_Description", DbType.String, this._Claim_Questionable_Description);
            db.AddInParameter(dbCommand, "Date_Reported_To_Sonic", DbType.DateTime, this._Date_Reported_To_Sonic);
            db.AddInParameter(dbCommand, "person_reported_to", DbType.String, this.person_reported_to);
            db.AddInParameter(dbCommand, "Witnesses", DbType.Boolean, this._Witnesses);
            db.AddInParameter(dbCommand, "Witness_1", DbType.String, this._Witness_1);
            db.AddInParameter(dbCommand, "Witness_2", DbType.String, this._Witness_2);
            db.AddInParameter(dbCommand, "Witness_3", DbType.String, this._Witness_3);
            db.AddInParameter(dbCommand, "Witness_1_Phone", DbType.String, this._Witness_1_Phone);
            db.AddInParameter(dbCommand, "Witness_2_Phone", DbType.String, this._Witness_2_Phone);
            db.AddInParameter(dbCommand, "Witness_3_Phone", DbType.String, this._Witness_3_Phone);
            db.AddInParameter(dbCommand, "Fatality", DbType.Boolean, this._Fatality);
            db.AddInParameter(dbCommand, "Initial_Medical_Treatment", DbType.String, this._Initial_Medical_Treatment);
            db.AddInParameter(dbCommand, "Date_of_Initial_Medical_Treatment", DbType.DateTime, this._Date_of_Initial_Medical_Treatment);
            db.AddInParameter(dbCommand, "Taken_By_Emergency_Transportation", DbType.Boolean, this._Taken_By_Emergency_Transportation);
            db.AddInParameter(dbCommand, "Medical_Facility_Name", DbType.String, this._Medical_Facility_Name);
            db.AddInParameter(dbCommand, "Medical_Facility_Address1", DbType.String, this._Medical_Facility_Address1);
            db.AddInParameter(dbCommand, "Medical_Facility_Address2", DbType.String, this._Medical_Facility_Address2);
            db.AddInParameter(dbCommand, "Medical_Facility_City", DbType.String, this._Medical_Facility_City);
            db.AddInParameter(dbCommand, "Medical_Facility_State", DbType.String, this._Medical_Facility_State);
            db.AddInParameter(dbCommand, "Medical_Facility_Zip", DbType.String, this._Medical_Facility_Zip);
            db.AddInParameter(dbCommand, "Medical_Facility_Phone", DbType.String, this._Medical_Facility_Phone);
            db.AddInParameter(dbCommand, "Status_Out_Of_Work", DbType.Boolean, this._Status_Out_Of_Work);
            db.AddInParameter(dbCommand, "Status_Out_Of_Work_Date", DbType.DateTime, this._Status_Out_Of_Work_Date);
            db.AddInParameter(dbCommand, "Status_Return_To_Work_Unrestricted", DbType.Boolean, this._Status_Return_To_Work_Unrestricted);
            db.AddInParameter(dbCommand, "Status_Return_To_Work_Unrestricted_Date", DbType.DateTime, this._Status_Return_To_Work_Unrestricted_Date);
            db.AddInParameter(dbCommand, "Status_Return_Tp_Work_Restricted", DbType.Boolean, this._Status_Return_Tp_Work_Restricted);
            db.AddInParameter(dbCommand, "Status_Return_Tp_Work_Restricted_Date", DbType.DateTime, this._Status_Return_Tp_Work_Restricted_Date);
            db.AddInParameter(dbCommand, "Status_Unknown", DbType.Boolean, this._Status_Unknown);
            db.AddInParameter(dbCommand, "Next_Doctor_Visit", DbType.DateTime, this._Next_Doctor_Visit);
            db.AddInParameter(dbCommand, "Treating_Physician_Name", DbType.String, this._Treating_Physician_Name);
            if (this._Admitted_to_Hospital != true && this.Admitted_to_Hospital != false)
            {
                db.AddInParameter(dbCommand, "Admitted_to_Hospital", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Admitted_to_Hospital", DbType.Boolean, this._Admitted_to_Hospital);
            }

            if (this._Still_In_Hospital != true && this._Still_In_Hospital != false)
            {
                db.AddInParameter(dbCommand, "Still_In_Hospital", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Still_In_Hospital", DbType.Boolean, this._Still_In_Hospital);
            }

            db.AddInParameter(dbCommand, "Referring_Physician", DbType.Boolean, this._Referring_Physician);
            db.AddInParameter(dbCommand, "Physician_Name", DbType.String, this._Physician_Name);
            db.AddInParameter(dbCommand, "Physician_Address1", DbType.String, this._Physician_Address1);
            db.AddInParameter(dbCommand, "Physician_Address2", DbType.String, this._Physician_Address2);
            db.AddInParameter(dbCommand, "Physician_City", DbType.String, this._Physician_City);
            db.AddInParameter(dbCommand, "Physician_State", DbType.String, this._Physician_State);
            db.AddInParameter(dbCommand, "Physician_Zip", DbType.String, this._Physician_Zip);
            db.AddInParameter(dbCommand, "Physician_Phone", DbType.String, this._Physician_Phone);
            db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
            db.AddInParameter(dbCommand, "Complete", DbType.Boolean, this._Complete);
            db.AddInParameter(dbCommand, "Alternate_Phone_2", DbType.String, this._Alternate_Phone_2);
            db.AddInParameter(dbCommand, "Employee_hrs_per_week", DbType.Decimal, this._Employee_hrs_per_week);
            db.AddInParameter(dbCommand, "Employee_Days_per_week", DbType.Decimal, this._Employee_Days_per_week);
            db.AddInParameter(dbCommand, "Employee_Time_Shift_Begins", DbType.String, this._Employee_Time_Shift_Begins);
            db.AddInParameter(dbCommand, "Employee_Time_Shift_Ends", DbType.String, this._Employee_Time_Shift_Ends);
            db.AddInParameter(dbCommand, "State_of_Hire", DbType.String, this._State_of_Hire);
            db.AddInParameter(dbCommand, "Date_Reported_to_SRS", DbType.DateTime, this._Date_Reported_to_SRS);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);
            db.AddInParameter(dbCommand, "Initial_Claim_Classification", DbType.String, this._Initial_Claim_Classification);
            db.AddInParameter(dbCommand, "Telephone_Nurse_Consultation", DbType.String, this._Telephone_Nurse_Consultation);
            db.AddInParameter(dbCommand, "Supervisor_Involved_In_Consultation", DbType.String, this._Supervisor_Involved_In_Consultation);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the WC_FR table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_WC_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_FRDeleteByPK");

            db.AddInParameter(dbCommand, "PK_WC_FR_ID", DbType.Decimal, pK_WC_FR_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectByWC_FR_Number(decimal wC_FR_Number)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_FRSelectByWC_FR_Number");

            db.AddInParameter(dbCommand, "WC_FR_Number", DbType.Decimal, wC_FR_Number);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByIDForClaim(decimal pK_WC_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_FRSelectByPKForClaim");

            db.AddInParameter(dbCommand, "PK_WC_FR_ID", DbType.Decimal, pK_WC_FR_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectDistinctIncidentYear()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_FR_SelectDistinctYear");
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetWCAllocationDetailData(int intYear, int intMonth, string strRegion)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WCAllocationDetailReport");

            db.AddInParameter(dbCommand, "Year", DbType.Int32, intYear);
            db.AddInParameter(dbCommand, "Month", DbType.Int32, intMonth);
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select Wc_fr record By Region
        /// </summary>
        /// <param name="strRegion"></param>
        /// <returns></returns>
        public static DataTable SelectByRegion(string strRegion)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_FR_SelectByRegion");

            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        /// <summary>
        /// Select Wc_fr record By Market
        /// </summary>
        /// <param name="FK_LU_Market"></param>
        /// <returns></returns>
        public static DataTable SelectByMarket(decimal FK_LU_Market)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_FR_SelectByMarket");

            db.AddInParameter(dbCommand, "FK_LU_Market", DbType.String, FK_LU_Market);

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        public static System.Web.UI.WebControls.ListItem[] InitialClaimClassificationList()
        {
            System.Web.UI.WebControls.ListItem[] li = new System.Web.UI.WebControls.ListItem[4] ;
            li[0] = new System.Web.UI.WebControls.ListItem("Potential Lost-time from Work", "1");
            li[1] = new System.Web.UI.WebControls.ListItem("Medical care and treatment only from a “Health Provider”", "2");
            li[2] = new System.Web.UI.WebControls.ListItem("Report Only – No medical care or treatment provided by a Health Provider", "3");
            li[3] = new System.Web.UI.WebControls.ListItem("Unknown at this time", "4");
            return li;
        }
        public static DataTable SelectByState(decimal PK_WC_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_SelectByState");

            db.AddInParameter(dbCommand, "PK_WC_FR_ID", DbType.Decimal, PK_WC_FR_ID);

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }
        #endregion


    }
}