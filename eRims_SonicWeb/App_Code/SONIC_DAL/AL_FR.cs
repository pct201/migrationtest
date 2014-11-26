using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{

    /// <summary>
    /// Data access class for AL_FR table.
    /// </summary>
    public sealed class AL_FR
    {



        #region Fields



        private decimal _PK_AL_FR_ID;
        private decimal _AL_FR_Number;
        private string _Driver_Medical_Facility_ZipCode;
        private string _Driver_Medical_Facility_Type;
        private DateTime _Driver_Date_Of_Initial_Treatment;
        private string _Driver_Treating_Physician_Name;
        private Nullable<bool> _Driver_Airlifted_Medivac;
        private Nullable<bool> _Driver_Admitted_to_Hospital;
        private DateTime _Driver_Date_Admitted_to_Hospital;
        private Nullable<bool> _Driver_Still_in_Hospital;
        private string _Driver_Physicians_Name;
        private Nullable<bool> _Citation_Issued;
        private string _Citation_Number;
        private Nullable<bool> _Driver_Was_Injured;
        private string _Driver_Injury_Description;
        private Nullable<bool> _Driver_Sought_Medical_Attention;
        private Nullable<bool> _Driver_Is_Owner;
        private string _Passenger_Name;
        private string _Passenger_Address_1;
        private string _Passenger_Address_2;
        private string _Passenger_City;
        private string _Passenger_State;
        private string _Passenger_ZipCode;
        private DateTime _Passenger_Date_of_Birth;
        private string _Passenger_Work_Phone;
        private string _Passenger_Home_Phone;
        private string _Passenger_Alternate_Phone;
        private string _Passenger_Drivers_License_Number;
        private string _Passenger_Drivers_License_State;
        private Nullable<bool> _Passenger_Was_Injured;
        private Nullable<bool> _Passenger_Sought_Medical_Attention;
        private string _Passenger_Description_of_Injury;
        private string _Passenger_Relation_to_Insured;
        private decimal _Other_Vehicle_Year;
        private string _Other_Vehicle_Make;
        private string _Other_Vehicle_Model;
        private string _Other_Vehicle_VIN;
        private string _Other_Vehicle_License_Plate_Number;
        private string _Other_Vehicle_License_Plate_State;
        private string _Other_Vehicle_Vehicle_Color;
        private string _Other_Vehicle_Insurance_Co_Name;
        private string _Other_Vehicle_Insurance_Co_Phone;
        private string _Other_Vehicle_Insurance_Policy_Number;
        private string _Other_Vehicle_Vehicle_Damage_Description;
        private string _Other_Vehicle_Repairs_Estimated_Amount;
        private bool _Other_Vehicle_Repairs_Completed;
        private Nullable<bool> _Other_Vehicle_Drivable;
        private string _Other_Vehicle_Location;
        private string _Other_Vehicle_Location_Driver_Address_1;
        private string _Other_Vehicle_Location_Driver_Address_2;
        private string _Other_Vehicle_Location_Driver_City;
        private string _Other_Vehicle_Location_Driver_State;
        private string _Other_Vehicle_Location_Driver_ZipCode;
        private string _Other_Vehicle_Location_Telephone;
        private string _Other_Vehicle_Owner_Name;
        private string _Other_Vehicle_Owner_Address_1;
        private string _Other_Vehicle_Owner_Address_2;
        private string _Other_Vehicle_Owner_City;
        private string _Other_Vehicle_Owner_State;
        private string _Other_Vehicle_Owner_ZipCode;
        private string _Other_Vehicle_Owner_Work_Phone;
        private string _Other_Vehicle_Owner_Home_Phone;
        private string _Other_Vehicle_Owner_Alternate_Phone;
        private string _Other_Driver_Name;
        private string _Other_Driver_Address_1;
        private string _Other_Driver_Address_2;
        private string _Other_Driver_City;
        private string _Other_Driver_State;
        private string _Other_Driver_ZipCode;
        private string _Other_Driver_SSN;
        private DateTime _Other_Driver_Date_of_Birth;
        private string _Other_Driver_Work_Phone;
        private string _Other_Driver_Home_Phone;
        private string _Other_Driver_Alternate_Phone;
        private string _Other_Driver_Drivers_License_Number;
        private string _Other_Driver_Drivers_License_State;
        private bool _Other_Driver_Taken_By_Emergency_Transportation;
        private string _Other_Driver_Medical_Facility_Name;
        private string _Other_Driver_Medical_Facility_Address_1;
        private string _Other_Driver_Medical_Facility_Address_2;
        private string _Other_Driver_Medical_Facility_City;
        private string _Other_Driver_Medical_Facility_State;
        private string _Other_Driver_Medical_Facility_Zip_Code;
        private string _Other_Driver_Medical_Facility_Type;
        private Nullable<bool> _Other_Driver_Airlifted_Medivac;
        private Nullable<bool> _Other_Driver_Citation_Issued;
        private string _Other_Driver_Citation_Number;
        private string _Other_Driver_Gender;
        private Nullable<bool> _Other_Driver_Injured;
        private string _Other_Driver_Injury_Description;
        private Nullable<bool> _Other_Driver_Sought_Medical_Attention;
        private Nullable<bool> _Other_Driver_Admitted_to_Hospital;
        private DateTime _Other_Driver_Date_Admitted_to_Hospital;
        private Nullable<bool> _Other_Driver_Still_in_Hospital;
        private string _Other_Driver_Physicians_Name;
        private string _Oth_Veh_Pass_Name;
        private string _Oth_Veh_Pass_Address_1;
        private string _Oth_Veh_Pass_Address_2;
        private string _Oth_Veh_Pass_City;
        private string _Oth_Veh_Pass_State;
        private string _Oth_Veh_Pass_ZipCode;
        private DateTime _Oth_Veh_Pass_Date_of_Birth;
        private string _Oth_Veh_Pass_Work_Phone;
        private string _Oth_Veh_Pass_Home_Phone;
        private string _Oth_Veh_Pass_Alternate_Phone;
        private bool _Oth_Veh_Pass_Taken_By_Emergency_Transportation;
        private string _Oth_Veh_Pass_Medical_Facility_Name;
        private string _Oth_Veh_Pass_Medical_Facility_Address_1;
        private string _Oth_Veh_Pass_Medical_Facility_Address_2;
        private string _Oth_Veh_Pass_Medical_Facility_City;
        private decimal _Oth_Veh_Pass_Medical_Facility_State;
        private string _Oth_Veh_Pass_Medical_Facility_ZipCode;
        private string _Oth_Veh_Pass_Medical_Facility_Type;
        private Nullable<bool> _Oth_Veh_Pass_Airlifted_Medivac;
        private Nullable<bool> _Oth_Veh_Pass_Injured;
        private string _Oth_Veh_Pass_Injury_Description;
        private Nullable<bool> _Oth_Veh_Pass_Sought_Medical_Attention;
        private Nullable<bool> _Oth_Veh_Pass_Admitted_to_Hospital;
        private DateTime _Oth_Veh_Pass_Date_Admitted_to_Hospital;
        private Nullable<bool> _Oth_Veh_Pass_Still_in_Hospital;
        private string _Oth_Veh_Pass_Physicians_Name;
        private string _Pedestrian_Name;
        private string _Pedestrian_Address_1;
        private string _Pedestrian_Address_2;
        private string _Pedestrian_City;
        private string _Pedestrian_State;
        private string _Pedestrian_ZipCode;
        private DateTime _Pedestrian_Date_of_Birth;
        private string _Pedestrian_Work_Phone;
        private string _Pedestrian_Home_Phone;
        private string _Pedestrian_Alternate_Phone;
        private bool _Pedestrian_Taken_By_Emergency_Transportation;
        private string _Pedestrian_Medical_Facility_Name;
        private string _Pedestrian_Medical_Facility_Address_1;
        private string _Pedestrian_Medical_Facility_Address_2;
        private string _Pedestrian_Medical_Facility_City;
        private string _Pedestrian_Medical_Facility_State;
        private string _Pedestrian_Medical_Facility_Zip_Code;
        private string _Pedestrian_Medical_Facility_Type;
        private Nullable<bool> _Pedestrian_Airlifted_Medivac;
        private Nullable<bool> _Pedestrian_Injured;
        private string _Pedestrian_Injury_Description;
        private Nullable<bool> _Pedestrian_Sought_Medical_Attention;
        private Nullable<bool> _Pedestrian_Admitted_to_Hospital;
        private DateTime _Pedestrian_Date_Admitted_to_Hospital;
        private Nullable<bool> _Pedestrian_Still_in_Hospital;
        private string _Pedestrian_Physicians_Name;
        private string _Witness_Name;
        private string _Witness_Address_1;
        private string _Witness_Address_2;
        private string _Witness_City;
        private string _Witness_State;
        private string _Witness_ZipCode;
        private string _Witness_Work_Phone;
        private string _Witness_Home_Phone;
        private string _Witness_Alternate_Phone;
        private string _Comments;
        private bool _Complete;
        private decimal _FK_Contact;
        private string _Claimant_state;
        private string _FK_LU_Auto_Liability_Type;
        private DateTime _Date_Of_Loss;
        private string _Time_Of_Loss;
        private bool _Loss_offsite;
        private string _Offsite_Address_1;
        private string _Offsite_Address_2;
        private string _Offsite_City;
        private string _Offsite_State;
        private string _Offsite_zip;
        private decimal _FK_Loss_Location;
        private string _Description_Of_Loss;
        private DateTime _Date_Reported_To_Sonic;
        private string _Weather_Conditions;
        private string _Road_Conditions;
        private Nullable<bool> _Were_Police_Notified;
        private string _Police_Agency;
        private string _Police_Case_Number;
        private string _Police_Station_Phone_Number;
        private Nullable<bool> _Pedestrian_Involved;
        private Nullable<bool> _Property_Damage;
        private Nullable<bool> _Witnesses;
        private string _Vehicle_Sub_Type;
        private string _Vehicle_Fleet_number;
        private decimal _Year;
        private string _Make;
        private string _Model;
        private string _VIN;
        private string _License_Plate_Number;
        private string _License_Plate_State;
        private string _Vehicle_Color;
        private Nullable<bool> _Permissive_Use;
        private string _Type_Of_Use;
        private string _Vehicle_Damage_Description;
        private string _Repairs_Estimated_Amount;
        private Nullable<bool> _Repairs_Completed;
        private Nullable<bool> _Drivable;
        private Nullable<bool> _Passengers;
        private string _Vehicle_Location;
        private string _Vehicle_Location_Driver_Address_1;
        private string _Vehicle_Location_Driver_Address_2;
        private string _Vehicle_Location_Driver_City;
        private decimal _Vehicle_Location_Driver_State;
        private string _Vehicle_Location_Driver_ZipCode;
        private Nullable<bool> _Insured_Driver_At_Fault;
        private string _Owner_Name;
        private string _Owner_Address_1;
        private string _Owner_Address_2;
        private string _Owner_City;
        private string _Owner_State;
        private string _Owner_ZipCode;
        private string _Owner_Work_Phone;
        private string _Owner_Home_Phone;
        private string _Owner_Alternate_Phone;
        private string _Driver_Name;
        private string _Driver_Address_1;
        private string _Driver_Address_2;
        private string _Driver_City;
        private string _Driver_State;
        private string _Driver_ZipCode;
        private string _Driver_SSN;
        private DateTime _Driver_Date_of_Birth;
        private string _Driver_Work_Phone;
        private string _Driver_Home_Phone;
        private string _Driver_Altermate_Phone;
        private string _Driver_Drivers_License_Number;
        private string _Driver_Drivers_License_State;
        private string _Driver_Relation_to_Insured;
        private bool _Driver_Taken_By_Emergency_Transportation;
        private string _Driver_Medical_Facility_Name;
        private string _Driver_Medical_Facility_Address_1;
        private string _Driver_Medical_Facility_Address_2;
        private string _Driver_Medical_Facility_City;
        private string _Driver_Medical_Facility_State;
        private decimal _Updated_By;
        private DateTime _Updated_Date;
        private Nullable<bool> _Security_Video_System;
        private decimal _FK_SLT_Incident_Review;
        #endregion

        #region Properties

        public Nullable<bool> Security_Video_System
        {
            get { return _Security_Video_System; }
            set { _Security_Video_System = value; }
        }

        /// <summary> 
        /// Gets or sets the PK_AL_FR_ID value.
        /// </summary>
        /// 

        public decimal PK_AL_FR_ID
        {
            get { return _PK_AL_FR_ID; }
            set { _PK_AL_FR_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the AL_FR_Number value.
        /// </summary>
        public decimal AL_FR_Number
        {
            get { return _AL_FR_Number; }
            set { _AL_FR_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Medical_Facility_ZipCode value.
        /// </summary>
        public string Driver_Medical_Facility_ZipCode
        {
            get { return _Driver_Medical_Facility_ZipCode; }
            set { _Driver_Medical_Facility_ZipCode = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Medical_Facility_Type value.
        /// </summary>
        public string Driver_Medical_Facility_Type
        {
            get { return _Driver_Medical_Facility_Type; }
            set { _Driver_Medical_Facility_Type = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Date_Of_Initial_Treatment value.
        /// </summary>
        public DateTime Driver_Date_Of_Initial_Treatment
        {
            get { return _Driver_Date_Of_Initial_Treatment; }
            set { _Driver_Date_Of_Initial_Treatment = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Treating_Physician_Name value.
        /// </summary>
        public string Driver_Treating_Physician_Name
        {
            get { return _Driver_Treating_Physician_Name; }
            set { _Driver_Treating_Physician_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Airlifted_Medivac value.
        /// </summary>
        public Nullable<bool> Driver_Airlifted_Medivac
        {
            get { return _Driver_Airlifted_Medivac; }
            set { _Driver_Airlifted_Medivac = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Admitted_to_Hospital value.
        /// </summary>
        public Nullable<bool> Driver_Admitted_to_Hospital
        {
            get { return _Driver_Admitted_to_Hospital; }
            set { _Driver_Admitted_to_Hospital = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Date_Admitted_to_Hospital value.
        /// </summary>
        public DateTime Driver_Date_Admitted_to_Hospital
        {
            get { return _Driver_Date_Admitted_to_Hospital; }
            set { _Driver_Date_Admitted_to_Hospital = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Still_in_Hospital value.
        /// </summary>
        public Nullable<bool> Driver_Still_in_Hospital
        {
            get { return _Driver_Still_in_Hospital; }
            set { _Driver_Still_in_Hospital = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Physicians_Name value.
        /// </summary>
        public string Driver_Physicians_Name
        {
            get { return _Driver_Physicians_Name; }
            set { _Driver_Physicians_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Citation_Issued value.
        /// </summary>
        public Nullable<bool> Citation_Issued
        {
            get { return _Citation_Issued; }
            set { _Citation_Issued = value; }
        }


        /// <summary> 
        /// Gets or sets the Citation_Number value.
        /// </summary>
        public string Citation_Number
        {
            get { return _Citation_Number; }
            set { _Citation_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Was_Injured value.
        /// </summary>
        public Nullable<bool> Driver_Was_Injured
        {
            get { return _Driver_Was_Injured; }
            set { _Driver_Was_Injured = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Injury_Description value.
        /// </summary>
        public string Driver_Injury_Description
        {
            get { return _Driver_Injury_Description; }
            set { _Driver_Injury_Description = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Sought_Medical_Attention value.
        /// </summary>
        public Nullable<bool> Driver_Sought_Medical_Attention
        {
            get { return _Driver_Sought_Medical_Attention; }
            set { _Driver_Sought_Medical_Attention = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Is_Owner value.
        /// </summary>
        public Nullable<bool> Driver_Is_Owner
        {
            get { return _Driver_Is_Owner; }
            set { _Driver_Is_Owner = value; }
        }


        /// <summary> 
        /// Gets or sets the Passenger_Name value.
        /// </summary>
        public string Passenger_Name
        {
            get { return _Passenger_Name; }
            set { _Passenger_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Passenger_Address_1 value.
        /// </summary>
        public string Passenger_Address_1
        {
            get { return _Passenger_Address_1; }
            set { _Passenger_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Passenger_Address_2 value.
        /// </summary>
        public string Passenger_Address_2
        {
            get { return _Passenger_Address_2; }
            set { _Passenger_Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Passenger_City value.
        /// </summary>
        public string Passenger_City
        {
            get { return _Passenger_City; }
            set { _Passenger_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Passenger_State value.
        /// </summary>
        public string Passenger_State
        {
            get { return _Passenger_State; }
            set { _Passenger_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Passenger_ZipCode value.
        /// </summary>
        public string Passenger_ZipCode
        {
            get { return _Passenger_ZipCode; }
            set { _Passenger_ZipCode = value; }
        }


        /// <summary> 
        /// Gets or sets the Passenger_Date_of_Birth value.
        /// </summary>
        public DateTime Passenger_Date_of_Birth
        {
            get { return _Passenger_Date_of_Birth; }
            set { _Passenger_Date_of_Birth = value; }
        }


        /// <summary> 
        /// Gets or sets the Passenger_Work_Phone value.
        /// </summary>
        public string Passenger_Work_Phone
        {
            get { return _Passenger_Work_Phone; }
            set { _Passenger_Work_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Passenger_Home_Phone value.
        /// </summary>
        public string Passenger_Home_Phone
        {
            get { return _Passenger_Home_Phone; }
            set { _Passenger_Home_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Passenger_Alternate_Phone value.
        /// </summary>
        public string Passenger_Alternate_Phone
        {
            get { return _Passenger_Alternate_Phone; }
            set { _Passenger_Alternate_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Passenger_Drivers_License_Number value.
        /// </summary>
        public string Passenger_Drivers_License_Number
        {
            get { return _Passenger_Drivers_License_Number; }
            set { _Passenger_Drivers_License_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Passenger_Drivers_License_State value.
        /// </summary>
        public string Passenger_Drivers_License_State
        {
            get { return _Passenger_Drivers_License_State; }
            set { _Passenger_Drivers_License_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Passenger_Was_Injured value.
        /// </summary>
        public Nullable<bool> Passenger_Was_Injured
        {
            get { return _Passenger_Was_Injured; }
            set { _Passenger_Was_Injured = value; }
        }


        /// <summary> 
        /// Gets or sets the Passenger_Sought_Medical_Attention value.
        /// </summary>
        public Nullable<bool> Passenger_Sought_Medical_Attention
        {
            get { return _Passenger_Sought_Medical_Attention; }
            set { _Passenger_Sought_Medical_Attention = value; }
        }


        /// <summary> 
        /// Gets or sets the Passenger_Description_of_Injury value.
        /// </summary>
        public string Passenger_Description_of_Injury
        {
            get { return _Passenger_Description_of_Injury; }
            set { _Passenger_Description_of_Injury = value; }
        }


        /// <summary> 
        /// Gets or sets the Passenger_Relation_to_Insured value.
        /// </summary>
        public string Passenger_Relation_to_Insured
        {
            get { return _Passenger_Relation_to_Insured; }
            set { _Passenger_Relation_to_Insured = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Vehicle_Year value.
        /// </summary>
        public decimal Other_Vehicle_Year
        {
            get { return _Other_Vehicle_Year; }
            set { _Other_Vehicle_Year = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Vehicle_Make value.
        /// </summary>
        public string Other_Vehicle_Make
        {
            get { return _Other_Vehicle_Make; }
            set { _Other_Vehicle_Make = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Vehicle_Model value.
        /// </summary>
        public string Other_Vehicle_Model
        {
            get { return _Other_Vehicle_Model; }
            set { _Other_Vehicle_Model = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Vehicle_VIN value.
        /// </summary>
        public string Other_Vehicle_VIN
        {
            get { return _Other_Vehicle_VIN; }
            set { _Other_Vehicle_VIN = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Vehicle_License_Plate_Number value.
        /// </summary>
        public string Other_Vehicle_License_Plate_Number
        {
            get { return _Other_Vehicle_License_Plate_Number; }
            set { _Other_Vehicle_License_Plate_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Vehicle_License_Plate_State value.
        /// </summary>
        public string Other_Vehicle_License_Plate_State
        {
            get { return _Other_Vehicle_License_Plate_State; }
            set { _Other_Vehicle_License_Plate_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Vehicle_Vehicle_Color value.
        /// </summary>
        public string Other_Vehicle_Vehicle_Color
        {
            get { return _Other_Vehicle_Vehicle_Color; }
            set { _Other_Vehicle_Vehicle_Color = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Vehicle_Insurance_Co_Name value.
        /// </summary>
        public string Other_Vehicle_Insurance_Co_Name
        {
            get { return _Other_Vehicle_Insurance_Co_Name; }
            set { _Other_Vehicle_Insurance_Co_Name = value; }
        }

        /// <summary> 
        /// Gets or sets the Other_Vehicle_Insurance_Co_Phone value.
        /// </summary>
        public string Other_Vehicle_Insurance_Co_Phone
        {
            get { return _Other_Vehicle_Insurance_Co_Phone; }
            set { _Other_Vehicle_Insurance_Co_Phone = value; }
        }
        /// <summary> 
        /// Gets or sets the Other_Vehicle_Insurance_Policy_Number value.
        /// </summary>
        public string Other_Vehicle_Insurance_Policy_Number
        {
            get { return _Other_Vehicle_Insurance_Policy_Number; }
            set { _Other_Vehicle_Insurance_Policy_Number = value; }
        }

        /// <summary> 
        /// Gets or sets the Other_Vehicle_Vehicle_Damage_Description value.
        /// </summary>
        public string Other_Vehicle_Vehicle_Damage_Description
        {
            get { return _Other_Vehicle_Vehicle_Damage_Description; }
            set { _Other_Vehicle_Vehicle_Damage_Description = value; }
        }
        /// <summary> 
        /// Gets or sets the Other_Vehicle_Repairs_Estimated_Amount value.
        /// </summary>
        public string Other_Vehicle_Repairs_Estimated_Amount
        {
            get { return _Other_Vehicle_Repairs_Estimated_Amount; }
            set { _Other_Vehicle_Repairs_Estimated_Amount = value; }
        }
        /// <summary> 
        /// Gets or sets the Other_Vehicle_Repairs_Completed value.
        /// </summary>
        public bool Other_Vehicle_Repairs_Completed
        {
            get { return _Other_Vehicle_Repairs_Completed; }
            set { _Other_Vehicle_Repairs_Completed = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Vehicle_Drivable value.
        /// </summary>
        public Nullable<bool> Other_Vehicle_Drivable
        {
            get { return _Other_Vehicle_Drivable; }
            set { _Other_Vehicle_Drivable = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Vehicle_Location value.
        /// </summary>
        public string Other_Vehicle_Location
        {
            get { return _Other_Vehicle_Location; }
            set { _Other_Vehicle_Location = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Vehicle_Location_Driver_Address_1 value.
        /// </summary>
        public string Other_Vehicle_Location_Driver_Address_1
        {
            get { return _Other_Vehicle_Location_Driver_Address_1; }
            set { _Other_Vehicle_Location_Driver_Address_1 = value; }
        }
        /// <summary> 
        /// Gets or sets the Other_Vehicle_Location_Driver_Address_2 value.
        /// </summary>
        public string Other_Vehicle_Location_Driver_Address_2
        {
            get { return _Other_Vehicle_Location_Driver_Address_2; }
            set { _Other_Vehicle_Location_Driver_Address_2 = value; }
        }
        /// <summary> 
        /// Gets or sets the Other_Vehicle_Location_Driver_City value.
        /// </summary>
        public string Other_Vehicle_Location_Driver_City
        {
            get { return _Other_Vehicle_Location_Driver_City; }
            set { _Other_Vehicle_Location_Driver_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Vehicle_Location_Driver_State value.
        /// </summary>
        public string Other_Vehicle_Location_Driver_State
        {
            get { return _Other_Vehicle_Location_Driver_State; }
            set { _Other_Vehicle_Location_Driver_State = value; }
        }
        /// <summary> 
        /// Gets or sets the Other_Vehicle_Location_Driver_ZipCode value.
        /// </summary>
        public string Other_Vehicle_Location_Driver_ZipCode
        {
            get { return _Other_Vehicle_Location_Driver_ZipCode; }
            set { _Other_Vehicle_Location_Driver_ZipCode = value; }
        }
        /// <summary> 
        /// Gets or sets the Other_Vehicle_Location_Telephone value.
        /// </summary>
        public string Other_Vehicle_Location_Telephone
        {
            get { return _Other_Vehicle_Location_Telephone; }
            set { _Other_Vehicle_Location_Telephone = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Vehicle_Owner_Name value.
        /// </summary>
        public string Other_Vehicle_Owner_Name
        {
            get { return _Other_Vehicle_Owner_Name; }
            set { _Other_Vehicle_Owner_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Vehicle_Owner_Address_1 value.
        /// </summary>
        public string Other_Vehicle_Owner_Address_1
        {
            get { return _Other_Vehicle_Owner_Address_1; }
            set { _Other_Vehicle_Owner_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Vehicle_Owner_Address_2 value.
        /// </summary>
        public string Other_Vehicle_Owner_Address_2
        {
            get { return _Other_Vehicle_Owner_Address_2; }
            set { _Other_Vehicle_Owner_Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Vehicle_Owner_City value.
        /// </summary>
        public string Other_Vehicle_Owner_City
        {
            get { return _Other_Vehicle_Owner_City; }
            set { _Other_Vehicle_Owner_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Vehicle_Owner_State value.
        /// </summary>
        public string Other_Vehicle_Owner_State
        {
            get { return _Other_Vehicle_Owner_State; }
            set { _Other_Vehicle_Owner_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Vehicle_Owner_ZipCode value.
        /// </summary>
        public string Other_Vehicle_Owner_ZipCode
        {
            get { return _Other_Vehicle_Owner_ZipCode; }
            set { _Other_Vehicle_Owner_ZipCode = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Vehicle_Owner_Work_Phone value.
        /// </summary>
        public string Other_Vehicle_Owner_Work_Phone
        {
            get { return _Other_Vehicle_Owner_Work_Phone; }
            set { _Other_Vehicle_Owner_Work_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Vehicle_Owner_Home_Phone value.
        /// </summary>
        public string Other_Vehicle_Owner_Home_Phone
        {
            get { return _Other_Vehicle_Owner_Home_Phone; }
            set { _Other_Vehicle_Owner_Home_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Vehicle_Owner_Alternate_Phone value.
        /// </summary>
        public string Other_Vehicle_Owner_Alternate_Phone
        {
            get { return _Other_Vehicle_Owner_Alternate_Phone; }
            set { _Other_Vehicle_Owner_Alternate_Phone = value; }
        }
        /// <summary> 
        /// Gets or sets the Other_Driver_Name value.
        /// </summary>
        public string Other_Driver_Name
        {
            get { return _Other_Driver_Name; }
            set { _Other_Driver_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_Address_1 value.
        /// </summary>
        public string Other_Driver_Address_1
        {
            get { return _Other_Driver_Address_1; }
            set { _Other_Driver_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_Address_2 value.
        /// </summary>
        public string Other_Driver_Address_2
        {
            get { return _Other_Driver_Address_2; }
            set { _Other_Driver_Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_City value.
        /// </summary>
        public string Other_Driver_City
        {
            get { return _Other_Driver_City; }
            set { _Other_Driver_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_State value.
        /// </summary>
        public string Other_Driver_State
        {
            get { return _Other_Driver_State; }
            set { _Other_Driver_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_ZipCode value.
        /// </summary>
        public string Other_Driver_ZipCode
        {
            get { return _Other_Driver_ZipCode; }
            set { _Other_Driver_ZipCode = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_SSN value.
        /// </summary>
        public string Other_Driver_SSN
        {
            get { return _Other_Driver_SSN; }
            set { _Other_Driver_SSN = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_Date_of_Birth value.
        /// </summary>
        public DateTime Other_Driver_Date_of_Birth
        {
            get { return _Other_Driver_Date_of_Birth; }
            set { _Other_Driver_Date_of_Birth = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_Work_Phone value.
        /// </summary>
        public string Other_Driver_Work_Phone
        {
            get { return _Other_Driver_Work_Phone; }
            set { _Other_Driver_Work_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_Home_Phone value.
        /// </summary>
        public string Other_Driver_Home_Phone
        {
            get { return _Other_Driver_Home_Phone; }
            set { _Other_Driver_Home_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_Alternate_Phone value.
        /// </summary>
        public string Other_Driver_Alternate_Phone
        {
            get { return _Other_Driver_Alternate_Phone; }
            set { _Other_Driver_Alternate_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_Drivers_License_Number value.
        /// </summary>
        public string Other_Driver_Drivers_License_Number
        {
            get { return _Other_Driver_Drivers_License_Number; }
            set { _Other_Driver_Drivers_License_Number = value; }
        }
        /// <summary> 
        /// Gets or sets the Other_Driver_Drivers_License_State value.
        /// </summary>
        public string Other_Driver_Drivers_License_State
        {
            get { return _Other_Driver_Drivers_License_State; }
            set { _Other_Driver_Drivers_License_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_Taken_By_Emergency_Transportation value.
        /// </summary>
        public bool Other_Driver_Taken_By_Emergency_Transportation
        {
            get { return _Other_Driver_Taken_By_Emergency_Transportation; }
            set { _Other_Driver_Taken_By_Emergency_Transportation = value; }
        }
        /// <summary> 
        /// Gets or sets the Other_Driver_Medical_Facility_Name value.
        /// </summary>
        public string Other_Driver_Medical_Facility_Name
        {
            get { return _Other_Driver_Medical_Facility_Name; }
            set { _Other_Driver_Medical_Facility_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_Medical_Facility_Address_1 value.
        /// </summary>
        public string Other_Driver_Medical_Facility_Address_1
        {
            get { return _Other_Driver_Medical_Facility_Address_1; }
            set { _Other_Driver_Medical_Facility_Address_1 = value; }
        }
        /// <summary> 
        /// Gets or sets the Other_Driver_Medical_Facility_Address_2 value.
        /// </summary>
        public string Other_Driver_Medical_Facility_Address_2
        {
            get { return _Other_Driver_Medical_Facility_Address_2; }
            set { _Other_Driver_Medical_Facility_Address_2 = value; }
        }
        /// <summary> 
        /// Gets or sets the Other_Driver_Medical_Facility_City value.
        /// </summary>
        public string Other_Driver_Medical_Facility_City
        {
            get { return _Other_Driver_Medical_Facility_City; }
            set { _Other_Driver_Medical_Facility_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_Medical_Facility_State value.
        /// </summary>
        public string Other_Driver_Medical_Facility_State
        {
            get { return _Other_Driver_Medical_Facility_State; }
            set { _Other_Driver_Medical_Facility_State = value; }
        }
        /// <summary> 
        /// Gets or sets the Other_Driver_Medical_Facility_Zip_Code value.
        /// </summary>
        public string Other_Driver_Medical_Facility_Zip_Code
        {
            get { return _Other_Driver_Medical_Facility_Zip_Code; }
            set { _Other_Driver_Medical_Facility_Zip_Code = value; }
        }
        /// <summary> 
        /// Gets or sets the Other_Driver_Medical_Facility_Type value.
        /// </summary>
        public string Other_Driver_Medical_Facility_Type
        {
            get { return _Other_Driver_Medical_Facility_Type; }
            set { _Other_Driver_Medical_Facility_Type = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_Airlifted_Medivac value.
        /// </summary>
        public Nullable<bool> Other_Driver_Airlifted_Medivac
        {
            get { return _Other_Driver_Airlifted_Medivac; }
            set { _Other_Driver_Airlifted_Medivac = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_Citation_Issued value.
        /// </summary>
        public Nullable<bool> Other_Driver_Citation_Issued
        {
            get { return _Other_Driver_Citation_Issued; }
            set { _Other_Driver_Citation_Issued = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_Citation_Number value.
        /// </summary>
        public string Other_Driver_Citation_Number
        {
            get { return _Other_Driver_Citation_Number; }
            set { _Other_Driver_Citation_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_Gender value.
        /// </summary>
        public string Other_Driver_Gender
        {
            get { return _Other_Driver_Gender; }
            set { _Other_Driver_Gender = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_Injured value.
        /// </summary>
        public Nullable<bool> Other_Driver_Injured
        {
            get { return _Other_Driver_Injured; }
            set { _Other_Driver_Injured = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_Injury_Description value.
        /// </summary>
        public string Other_Driver_Injury_Description
        {
            get { return _Other_Driver_Injury_Description; }
            set { _Other_Driver_Injury_Description = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_Sought_Medical_Attention value.
        /// </summary>
        public Nullable<bool> Other_Driver_Sought_Medical_Attention
        {
            get { return _Other_Driver_Sought_Medical_Attention; }
            set { _Other_Driver_Sought_Medical_Attention = value; }
        }
        /// <summary> 
        /// Gets or sets the Other_Driver_Admitted_to_Hospital value.
        /// </summary>
        public Nullable<bool> Other_Driver_Admitted_to_Hospital
        {
            get { return _Other_Driver_Admitted_to_Hospital; }
            set { _Other_Driver_Admitted_to_Hospital = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_Date_Admitted_to_Hospital value.
        /// </summary>
        public DateTime Other_Driver_Date_Admitted_to_Hospital
        {
            get { return _Other_Driver_Date_Admitted_to_Hospital; }
            set { _Other_Driver_Date_Admitted_to_Hospital = value; }
        }
        /// <summary> 
        /// Gets or sets the Other_Driver_Still_in_Hospital value.
        /// </summary>
        public Nullable<bool> Other_Driver_Still_in_Hospital
        {
            get { return _Other_Driver_Still_in_Hospital; }
            set { _Other_Driver_Still_in_Hospital = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Driver_Physicians_Name value.
        /// </summary>
        public string Other_Driver_Physicians_Name
        {
            get { return _Other_Driver_Physicians_Name; }
            set { _Other_Driver_Physicians_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Name value.
        /// </summary>
        public string Oth_Veh_Pass_Name
        {
            get { return _Oth_Veh_Pass_Name; }
            set { _Oth_Veh_Pass_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Address_1 value.
        /// </summary>
        public string Oth_Veh_Pass_Address_1
        {
            get { return _Oth_Veh_Pass_Address_1; }
            set { _Oth_Veh_Pass_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Address_2 value.
        /// </summary>
        public string Oth_Veh_Pass_Address_2
        {
            get { return _Oth_Veh_Pass_Address_2; }
            set { _Oth_Veh_Pass_Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_City value.
        /// </summary>
        public string Oth_Veh_Pass_City
        {
            get { return _Oth_Veh_Pass_City; }
            set { _Oth_Veh_Pass_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_State value.
        /// </summary>
        public string Oth_Veh_Pass_State
        {
            get { return _Oth_Veh_Pass_State; }
            set { _Oth_Veh_Pass_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_ZipCode value.
        /// </summary>
        public string Oth_Veh_Pass_ZipCode
        {
            get { return _Oth_Veh_Pass_ZipCode; }
            set { _Oth_Veh_Pass_ZipCode = value; }
        }


        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Date_of_Birth value.
        /// </summary>
        public DateTime Oth_Veh_Pass_Date_of_Birth
        {
            get { return _Oth_Veh_Pass_Date_of_Birth; }
            set { _Oth_Veh_Pass_Date_of_Birth = value; }
        }


        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Work_Phone value.
        /// </summary>
        public string Oth_Veh_Pass_Work_Phone
        {
            get { return _Oth_Veh_Pass_Work_Phone; }
            set { _Oth_Veh_Pass_Work_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Home_Phone value.
        /// </summary>
        public string Oth_Veh_Pass_Home_Phone
        {
            get { return _Oth_Veh_Pass_Home_Phone; }
            set { _Oth_Veh_Pass_Home_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Alternate_Phone value.
        /// </summary>
        public string Oth_Veh_Pass_Alternate_Phone
        {
            get { return _Oth_Veh_Pass_Alternate_Phone; }
            set { _Oth_Veh_Pass_Alternate_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Taken_By_Emergency_Transportation value.
        /// </summary>
        public bool Oth_Veh_Pass_Taken_By_Emergency_Transportation
        {
            get { return _Oth_Veh_Pass_Taken_By_Emergency_Transportation; }
            set { _Oth_Veh_Pass_Taken_By_Emergency_Transportation = value; }
        }
        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Medical_Facility_Name value.
        /// </summary>
        public string Oth_Veh_Pass_Medical_Facility_Name
        {
            get { return _Oth_Veh_Pass_Medical_Facility_Name; }
            set { _Oth_Veh_Pass_Medical_Facility_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Medical_Facility_Address_1 value.
        /// </summary>
        public string Oth_Veh_Pass_Medical_Facility_Address_1
        {
            get { return _Oth_Veh_Pass_Medical_Facility_Address_1; }
            set { _Oth_Veh_Pass_Medical_Facility_Address_1 = value; }
        }
        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Medical_Facility_Address_2 value.
        /// </summary>
        public string Oth_Veh_Pass_Medical_Facility_Address_2
        {
            get { return _Oth_Veh_Pass_Medical_Facility_Address_2; }
            set { _Oth_Veh_Pass_Medical_Facility_Address_2 = value; }
        }
        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Medical_Facility_City value.
        /// </summary>
        public string Oth_Veh_Pass_Medical_Facility_City
        {
            get { return _Oth_Veh_Pass_Medical_Facility_City; }
            set { _Oth_Veh_Pass_Medical_Facility_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Medical_Facility_State value.
        /// </summary>
        public decimal Oth_Veh_Pass_Medical_Facility_State
        {
            get { return _Oth_Veh_Pass_Medical_Facility_State; }
            set { _Oth_Veh_Pass_Medical_Facility_State = value; }
        }
        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Medical_Facility_ZipCode value.
        /// </summary>
        public string Oth_Veh_Pass_Medical_Facility_ZipCode
        {
            get { return _Oth_Veh_Pass_Medical_Facility_ZipCode; }
            set { _Oth_Veh_Pass_Medical_Facility_ZipCode = value; }
        }
        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Medical_Facility_Type value.
        /// </summary>
        public string Oth_Veh_Pass_Medical_Facility_Type
        {
            get { return _Oth_Veh_Pass_Medical_Facility_Type; }
            set { _Oth_Veh_Pass_Medical_Facility_Type = value; }
        }


        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Airlifted_Medivac value.
        /// </summary>
        public Nullable<bool> Oth_Veh_Pass_Airlifted_Medivac
        {
            get { return _Oth_Veh_Pass_Airlifted_Medivac; }
            set { _Oth_Veh_Pass_Airlifted_Medivac = value; }
        }


        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Injured value.
        /// </summary>
        public Nullable<bool> Oth_Veh_Pass_Injured
        {
            get { return _Oth_Veh_Pass_Injured; }
            set { _Oth_Veh_Pass_Injured = value; }
        }


        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Injury_Description value.
        /// </summary>
        public string Oth_Veh_Pass_Injury_Description
        {
            get { return _Oth_Veh_Pass_Injury_Description; }
            set { _Oth_Veh_Pass_Injury_Description = value; }
        }


        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Sought_Medical_Attention value.
        /// </summary>
        public Nullable<bool> Oth_Veh_Pass_Sought_Medical_Attention
        {
            get { return _Oth_Veh_Pass_Sought_Medical_Attention; }
            set { _Oth_Veh_Pass_Sought_Medical_Attention = value; }
        }
        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Admitted_to_Hospital value.
        /// </summary>
        public Nullable<bool> Oth_Veh_Pass_Admitted_to_Hospital
        {
            get { return _Oth_Veh_Pass_Admitted_to_Hospital; }
            set { _Oth_Veh_Pass_Admitted_to_Hospital = value; }
        }


        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Date_Admitted_to_Hospital value.
        /// </summary>
        public DateTime Oth_Veh_Pass_Date_Admitted_to_Hospital
        {
            get { return _Oth_Veh_Pass_Date_Admitted_to_Hospital; }
            set { _Oth_Veh_Pass_Date_Admitted_to_Hospital = value; }
        }
        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Still_in_Hospital value.
        /// </summary>
        public Nullable<bool> Oth_Veh_Pass_Still_in_Hospital
        {
            get { return _Oth_Veh_Pass_Still_in_Hospital; }
            set { _Oth_Veh_Pass_Still_in_Hospital = value; }
        }


        /// <summary> 
        /// Gets or sets the Oth_Veh_Pass_Physicians_Name value.
        /// </summary>
        public string Oth_Veh_Pass_Physicians_Name
        {
            get { return _Oth_Veh_Pass_Physicians_Name; }
            set { _Oth_Veh_Pass_Physicians_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Pedestrian_Name value.
        /// </summary>
        public string Pedestrian_Name
        {
            get { return _Pedestrian_Name; }
            set { _Pedestrian_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Pedestrian_Address_1 value.
        /// </summary>
        public string Pedestrian_Address_1
        {
            get { return _Pedestrian_Address_1; }
            set { _Pedestrian_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Pedestrian_Address_2 value.
        /// </summary>
        public string Pedestrian_Address_2
        {
            get { return _Pedestrian_Address_2; }
            set { _Pedestrian_Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Pedestrian_City value.
        /// </summary>
        public string Pedestrian_City
        {
            get { return _Pedestrian_City; }
            set { _Pedestrian_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Pedestrian_State value.
        /// </summary>
        public string Pedestrian_State
        {
            get { return _Pedestrian_State; }
            set { _Pedestrian_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Pedestrian_ZipCode value.
        /// </summary>
        public string Pedestrian_ZipCode
        {
            get { return _Pedestrian_ZipCode; }
            set { _Pedestrian_ZipCode = value; }
        }


        /// <summary> 
        /// Gets or sets the Pedestrian_Date_of_Birth value.
        /// </summary>
        public DateTime Pedestrian_Date_of_Birth
        {
            get { return _Pedestrian_Date_of_Birth; }
            set { _Pedestrian_Date_of_Birth = value; }
        }


        /// <summary> 
        /// Gets or sets the Pedestrian_Work_Phone value.
        /// </summary>
        public string Pedestrian_Work_Phone
        {
            get { return _Pedestrian_Work_Phone; }
            set { _Pedestrian_Work_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Pedestrian_Home_Phone value.
        /// </summary>
        public string Pedestrian_Home_Phone
        {
            get { return _Pedestrian_Home_Phone; }
            set { _Pedestrian_Home_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Pedestrian_Alternate_Phone value.
        /// </summary>
        public string Pedestrian_Alternate_Phone
        {
            get { return _Pedestrian_Alternate_Phone; }
            set { _Pedestrian_Alternate_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Pedestrian_Taken_By_Emergency_Transportation value.
        /// </summary>
        public bool Pedestrian_Taken_By_Emergency_Transportation
        {
            get { return _Pedestrian_Taken_By_Emergency_Transportation; }
            set { _Pedestrian_Taken_By_Emergency_Transportation = value; }
        }
        /// <summary> 
        /// Gets or sets the Pedestrian_Medical_Facility_Name value.
        /// </summary>
        public string Pedestrian_Medical_Facility_Name
        {
            get { return _Pedestrian_Medical_Facility_Name; }
            set { _Pedestrian_Medical_Facility_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Pedestrian_Medical_Facility_Address_1 value.
        /// </summary>
        public string Pedestrian_Medical_Facility_Address_1
        {
            get { return _Pedestrian_Medical_Facility_Address_1; }
            set { _Pedestrian_Medical_Facility_Address_1 = value; }
        }
        /// <summary> 
        /// Gets or sets the Pedestrian_Medical_Facility_Address_2 value.
        /// </summary>
        public string Pedestrian_Medical_Facility_Address_2
        {
            get { return _Pedestrian_Medical_Facility_Address_2; }
            set { _Pedestrian_Medical_Facility_Address_2 = value; }
        }
        /// <summary> 
        /// Gets or sets the Pedestrian_Medical_Facility_City value.
        /// </summary>
        public string Pedestrian_Medical_Facility_City
        {
            get { return _Pedestrian_Medical_Facility_City; }
            set { _Pedestrian_Medical_Facility_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Pedestrian_Medical_Facility_State value.
        /// </summary>
        public string Pedestrian_Medical_Facility_State
        {
            get { return _Pedestrian_Medical_Facility_State; }
            set { _Pedestrian_Medical_Facility_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Pedestrian_Medical_Facility_Zip_Code value.
        /// </summary>
        public string Pedestrian_Medical_Facility_Zip_Code
        {
            get { return _Pedestrian_Medical_Facility_Zip_Code; }
            set { _Pedestrian_Medical_Facility_Zip_Code = value; }
        }
        /// <summary> 
        /// Gets or sets the Pedestrian_Medical_Facility_Type value.
        /// </summary>
        public string Pedestrian_Medical_Facility_Type
        {
            get { return _Pedestrian_Medical_Facility_Type; }
            set { _Pedestrian_Medical_Facility_Type = value; }
        }


        /// <summary> 
        /// Gets or sets the Pedestrian_Airlifted_Medivac value.
        /// </summary>
        public Nullable<bool> Pedestrian_Airlifted_Medivac
        {
            get { return _Pedestrian_Airlifted_Medivac; }
            set { _Pedestrian_Airlifted_Medivac = value; }
        }


        /// <summary> 
        /// Gets or sets the Pedestrian_Injured value.
        /// </summary>
        public Nullable<bool> Pedestrian_Injured
        {
            get { return _Pedestrian_Injured; }
            set { _Pedestrian_Injured = value; }
        }


        /// <summary> 
        /// Gets or sets the Pedestrian_Injury_Description value.
        /// </summary>
        public string Pedestrian_Injury_Description
        {
            get { return _Pedestrian_Injury_Description; }
            set { _Pedestrian_Injury_Description = value; }
        }


        /// <summary> 
        /// Gets or sets the Pedestrian_Sought_Medical_Attention value.
        /// </summary>
        public Nullable<bool> Pedestrian_Sought_Medical_Attention
        {
            get { return _Pedestrian_Sought_Medical_Attention; }
            set { _Pedestrian_Sought_Medical_Attention = value; }
        }


        /// <summary> 
        /// Gets or sets the Pedestrian_Admitted_to_Hospital value.
        /// </summary>
        public Nullable<bool> Pedestrian_Admitted_to_Hospital
        {
            get { return _Pedestrian_Admitted_to_Hospital; }
            set { _Pedestrian_Admitted_to_Hospital = value; }
        }


        /// <summary> 
        /// Gets or sets the Pedestrian_Date_Admitted_to_Hospital value.
        /// </summary>
        public DateTime Pedestrian_Date_Admitted_to_Hospital
        {
            get { return _Pedestrian_Date_Admitted_to_Hospital; }
            set { _Pedestrian_Date_Admitted_to_Hospital = value; }
        }
        /// <summary> 
        /// Gets or sets the Pedestrian_Still_in_Hospital value.
        /// </summary>
        public Nullable<bool> Pedestrian_Still_in_Hospital
        {
            get { return _Pedestrian_Still_in_Hospital; }
            set { _Pedestrian_Still_in_Hospital = value; }
        }


        /// <summary> 
        /// Gets or sets the Pedestrian_Physicians_Name value.
        /// </summary>
        public string Pedestrian_Physicians_Name
        {
            get { return _Pedestrian_Physicians_Name; }
            set { _Pedestrian_Physicians_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Witness_Name value.
        /// </summary>
        public string Witness_Name
        {
            get { return _Witness_Name; }
            set { _Witness_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Witness_Address_1 value.
        /// </summary>
        public string Witness_Address_1
        {
            get { return _Witness_Address_1; }
            set { _Witness_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Witness_Address_2 value.
        /// </summary>
        public string Witness_Address_2
        {
            get { return _Witness_Address_2; }
            set { _Witness_Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Witness_City value.
        /// </summary>
        public string Witness_City
        {
            get { return _Witness_City; }
            set { _Witness_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Witness_State value.
        /// </summary>
        public string Witness_State
        {
            get { return _Witness_State; }
            set { _Witness_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Witness_ZipCode value.
        /// </summary>
        public string Witness_ZipCode
        {
            get { return _Witness_ZipCode; }
            set { _Witness_ZipCode = value; }
        }


        /// <summary> 
        /// Gets or sets the Witness_Work_Phone value.
        /// </summary>
        public string Witness_Work_Phone
        {
            get { return _Witness_Work_Phone; }
            set { _Witness_Work_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Witness_Home_Phone value.
        /// </summary>
        public string Witness_Home_Phone
        {
            get { return _Witness_Home_Phone; }
            set { _Witness_Home_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Witness_Alternate_Phone value.
        /// </summary>
        public string Witness_Alternate_Phone
        {
            get { return _Witness_Alternate_Phone; }
            set { _Witness_Alternate_Phone = value; }
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
        /// Gets or sets the FK_Contact value.
        /// </summary>
        public decimal FK_Contact
        {
            get { return _FK_Contact; }
            set { _FK_Contact = value; }
        }


        /// <summary> 
        /// Gets or sets the Claimant_state value.
        /// </summary>
        public string Claimant_state
        {
            get { return _Claimant_state; }
            set { _Claimant_state = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Auto_Liability_Type
        /// </summary>
        public string FK_LU_Auto_Liability_Type
        {
            get { return _FK_LU_Auto_Liability_Type; }
            set { _FK_LU_Auto_Liability_Type = value; }
        }
        /// <summary> 
        /// Gets or sets the Date_Of_Loss value.
        /// </summary>
        public DateTime Date_Of_Loss
        {
            get { return _Date_Of_Loss; }
            set { _Date_Of_Loss = value; }
        }


        /// <summary> 
        /// Gets or sets the Time_Of_Loss value.
        /// </summary>
        public string Time_Of_Loss
        {
            get { return _Time_Of_Loss; }
            set { _Time_Of_Loss = value; }
        }


        /// <summary> 
        /// Gets or sets the Loss_offsite value.
        /// </summary>
        public bool Loss_offsite
        {
            get { return _Loss_offsite; }
            set { _Loss_offsite = value; }
        }


        /// <summary> 
        /// Gets or sets the Offsite_Address_1 value.
        /// </summary>
        public string Offsite_Address_1
        {
            get { return _Offsite_Address_1; }
            set { _Offsite_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Offsite_Address_2 value.
        /// </summary>
        public string Offsite_Address_2
        {
            get { return _Offsite_Address_2; }
            set { _Offsite_Address_2 = value; }
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
        /// Gets or sets the FK_Loss_Location value.
        /// </summary>
        public decimal FK_Loss_Location
        {
            get { return _FK_Loss_Location; }
            set { _FK_Loss_Location = value; }
        }


        /// <summary> 
        /// Gets or sets the Description_Of_Loss value.
        /// </summary>
        public string Description_Of_Loss
        {
            get { return _Description_Of_Loss; }
            set { _Description_Of_Loss = value; }
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
        /// Gets or sets the Weather_Conditions value.
        /// </summary>
        public string Weather_Conditions
        {
            get { return _Weather_Conditions; }
            set { _Weather_Conditions = value; }
        }


        /// <summary> 
        /// Gets or sets the Road_Conditions value.
        /// </summary>
        public string Road_Conditions
        {
            get { return _Road_Conditions; }
            set { _Road_Conditions = value; }
        }


        /// <summary> 
        /// Gets or sets the Were_Police_Notified value.
        /// </summary>
        public Nullable<bool> Were_Police_Notified
        {
            get { return _Were_Police_Notified; }
            set { _Were_Police_Notified = value; }
        }


        /// <summary> 
        /// Gets or sets the Police_Agency value.
        /// </summary>
        public string Police_Agency
        {
            get { return _Police_Agency; }
            set { _Police_Agency = value; }
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
        /// Gets or sets the Police_Station_Phone_Number value.
        /// </summary>
        public string Police_Station_Phone_Number
        {
            get { return _Police_Station_Phone_Number; }
            set { _Police_Station_Phone_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Pedestrian_Involved value.
        /// </summary>
        public Nullable<bool> Pedestrian_Involved
        {
            get { return _Pedestrian_Involved; }
            set { _Pedestrian_Involved = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Damage value.
        /// </summary>
        public Nullable<bool> Property_Damage
        {
            get { return _Property_Damage; }
            set { _Property_Damage = value; }
        }


        /// <summary> 
        /// Gets or sets the Witnesses value.
        /// </summary>
        public Nullable<bool> Witnesses
        {
            get { return _Witnesses; }
            set { _Witnesses = value; }
        }


        /// <summary> 
        /// Gets or sets the Vehicle_Sub_Type value.
        /// </summary>
        public string Vehicle_Sub_Type
        {
            get { return _Vehicle_Sub_Type; }
            set { _Vehicle_Sub_Type = value; }
        }


        /// <summary> 
        /// Gets or sets the Vehicle_Fleet_number value.
        /// </summary>
        public string Vehicle_Fleet_number
        {
            get { return _Vehicle_Fleet_number; }
            set { _Vehicle_Fleet_number = value; }
        }


        /// <summary> 
        /// Gets or sets the Year value.
        /// </summary>
        public decimal Year
        {
            get { return _Year; }
            set { _Year = value; }
        }


        /// <summary> 
        /// Gets or sets the Make value.
        /// </summary>
        public string Make
        {
            get { return _Make; }
            set { _Make = value; }
        }


        /// <summary> 
        /// Gets or sets the Model value.
        /// </summary>
        public string Model
        {
            get { return _Model; }
            set { _Model = value; }
        }


        /// <summary> 
        /// Gets or sets the VIN value.
        /// </summary>
        public string VIN
        {
            get { return _VIN; }
            set { _VIN = value; }
        }


        /// <summary> 
        /// Gets or sets the License_Plate_Number value.
        /// </summary>
        public string License_Plate_Number
        {
            get { return _License_Plate_Number; }
            set { _License_Plate_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the License_Plate_State value.
        /// </summary>
        public string License_Plate_State
        {
            get { return _License_Plate_State; }
            set { _License_Plate_State = value; }
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
        /// Gets or sets the Permissive_Use value.
        /// </summary>
        public Nullable<bool> Permissive_Use
        {
            get { return _Permissive_Use; }
            set { _Permissive_Use = value; }
        }


        /// <summary> 
        /// Gets or sets the Type_Of_Use value.
        /// </summary>
        public string Type_Of_Use
        {
            get { return _Type_Of_Use; }
            set { _Type_Of_Use = value; }
        }


        /// <summary> 
        /// Gets or sets the Vehicle_Damage_Description value.
        /// </summary>
        public string Vehicle_Damage_Description
        {
            get { return _Vehicle_Damage_Description; }
            set { _Vehicle_Damage_Description = value; }
        }


        /// <summary> 
        /// Gets or sets the Repairs_Estimated_Amount value.
        /// </summary>
        public string Repairs_Estimated_Amount
        {
            get { return _Repairs_Estimated_Amount; }
            set { _Repairs_Estimated_Amount = value; }
        }


        /// <summary> 
        /// Gets or sets the Repairs_Completed value.
        /// </summary>
        public Nullable<bool> Repairs_Completed
        {
            get { return _Repairs_Completed; }
            set { _Repairs_Completed = value; }
        }


        /// <summary> 
        /// Gets or sets the Drivable value.
        /// </summary>
        public Nullable<bool> Drivable
        {
            get { return _Drivable; }
            set { _Drivable = value; }
        }


        /// <summary> 
        /// Gets or sets the Passengers value.
        /// </summary>
        public Nullable<bool> Passengers
        {
            get { return _Passengers; }
            set { _Passengers = value; }
        }


        /// <summary> 
        /// Gets or sets the Vehicle_Location value.
        /// </summary>
        public string Vehicle_Location
        {
            get { return _Vehicle_Location; }
            set { _Vehicle_Location = value; }
        }


        /// <summary> 
        /// Gets or sets the Vehicle_Location_Driver_Address_1 value.
        /// </summary>
        public string Vehicle_Location_Driver_Address_1
        {
            get { return _Vehicle_Location_Driver_Address_1; }
            set { _Vehicle_Location_Driver_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Vehicle_Location_Driver_Address_2 value.
        /// </summary>
        public string Vehicle_Location_Driver_Address_2
        {
            get { return _Vehicle_Location_Driver_Address_2; }
            set { _Vehicle_Location_Driver_Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Vehicle_Location_Driver_City value.
        /// </summary>
        public string Vehicle_Location_Driver_City
        {
            get { return _Vehicle_Location_Driver_City; }
            set { _Vehicle_Location_Driver_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Vehicle_Location_Driver_State value.
        /// </summary>
        public decimal Vehicle_Location_Driver_State
        {
            get { return _Vehicle_Location_Driver_State; }
            set { _Vehicle_Location_Driver_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Vehicle_Location_Driver_ZipCode value.
        /// </summary>
        public string Vehicle_Location_Driver_ZipCode
        {
            get { return _Vehicle_Location_Driver_ZipCode; }
            set { _Vehicle_Location_Driver_ZipCode = value; }
        }


        /// <summary> 
        /// Gets or sets the Insured_Driver_At_Fault value.
        /// </summary>
        public Nullable<bool> Insured_Driver_At_Fault
        {
            get { return _Insured_Driver_At_Fault; }
            set { _Insured_Driver_At_Fault = value; }
        }


        /// <summary> 
        /// Gets or sets the Owner_Name value.
        /// </summary>
        public string Owner_Name
        {
            get { return _Owner_Name; }
            set { _Owner_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Owner_Address_1 value.
        /// </summary>
        public string Owner_Address_1
        {
            get { return _Owner_Address_1; }
            set { _Owner_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Owner_Address_2 value.
        /// </summary>
        public string Owner_Address_2
        {
            get { return _Owner_Address_2; }
            set { _Owner_Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Owner_City value.
        /// </summary>
        public string Owner_City
        {
            get { return _Owner_City; }
            set { _Owner_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Owner_State value.
        /// </summary>
        public string Owner_State
        {
            get { return _Owner_State; }
            set { _Owner_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Owner_ZipCode value.
        /// </summary>
        public string Owner_ZipCode
        {
            get { return _Owner_ZipCode; }
            set { _Owner_ZipCode = value; }
        }


        /// <summary> 
        /// Gets or sets the Owner_Work_Phone value.
        /// </summary>
        public string Owner_Work_Phone
        {
            get { return _Owner_Work_Phone; }
            set { _Owner_Work_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Owner_Home_Phone value.
        /// </summary>
        public string Owner_Home_Phone
        {
            get { return _Owner_Home_Phone; }
            set { _Owner_Home_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Owner_Alternate_Phone value.
        /// </summary>
        public string Owner_Alternate_Phone
        {
            get { return _Owner_Alternate_Phone; }
            set { _Owner_Alternate_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Name value.
        /// </summary>
        public string Driver_Name
        {
            get { return _Driver_Name; }
            set { _Driver_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Address_1 value.
        /// </summary>
        public string Driver_Address_1
        {
            get { return _Driver_Address_1; }
            set { _Driver_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Address_2 value.
        /// </summary>
        public string Driver_Address_2
        {
            get { return _Driver_Address_2; }
            set { _Driver_Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_City value.
        /// </summary>
        public string Driver_City
        {
            get { return _Driver_City; }
            set { _Driver_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_State value.
        /// </summary>
        public string Driver_State
        {
            get { return _Driver_State; }
            set { _Driver_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_ZipCode value.
        /// </summary>
        public string Driver_ZipCode
        {
            get { return _Driver_ZipCode; }
            set { _Driver_ZipCode = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_SSN value.
        /// </summary>
        public string Driver_SSN
        {
            get { return _Driver_SSN; }
            set { _Driver_SSN = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Date_of_Birth value.
        /// </summary>
        public DateTime Driver_Date_of_Birth
        {
            get { return _Driver_Date_of_Birth; }
            set { _Driver_Date_of_Birth = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Work_Phone value.
        /// </summary>
        public string Driver_Work_Phone
        {
            get { return _Driver_Work_Phone; }
            set { _Driver_Work_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Home_Phone value.
        /// </summary>
        public string Driver_Home_Phone
        {
            get { return _Driver_Home_Phone; }
            set { _Driver_Home_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Altermate_Phone value.
        /// </summary>
        public string Driver_Altermate_Phone
        {
            get { return _Driver_Altermate_Phone; }
            set { _Driver_Altermate_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Drivers_License_Number value.
        /// </summary>
        public string Driver_Drivers_License_Number
        {
            get { return _Driver_Drivers_License_Number; }
            set { _Driver_Drivers_License_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Drivers_License_State value.
        /// </summary>
        public string Driver_Drivers_License_State
        {
            get { return _Driver_Drivers_License_State; }
            set { _Driver_Drivers_License_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Relation_to_Insured value.
        /// </summary>
        public string Driver_Relation_to_Insured
        {
            get { return _Driver_Relation_to_Insured; }
            set { _Driver_Relation_to_Insured = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Taken_By_Emergency_Transportation value.
        /// </summary>
        public bool Driver_Taken_By_Emergency_Transportation
        {
            get { return _Driver_Taken_By_Emergency_Transportation; }
            set { _Driver_Taken_By_Emergency_Transportation = value; }
        }
        /// <summary> 
        /// Gets or sets the Driver_Medical_Facility_Name value.
        /// </summary>
        public string Driver_Medical_Facility_Name
        {
            get { return _Driver_Medical_Facility_Name; }
            set { _Driver_Medical_Facility_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Medical_Facility_Address_1 value.
        /// </summary>
        public string Driver_Medical_Facility_Address_1
        {
            get { return _Driver_Medical_Facility_Address_1; }
            set { _Driver_Medical_Facility_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Medical_Facility_Address_2 value.
        /// </summary>
        public string Driver_Medical_Facility_Address_2
        {
            get { return _Driver_Medical_Facility_Address_2; }
            set { _Driver_Medical_Facility_Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Medical_Facility_City value.
        /// </summary>
        public string Driver_Medical_Facility_City
        {
            get { return _Driver_Medical_Facility_City; }
            set { _Driver_Medical_Facility_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Medical_Facility_State value.
        /// </summary>
        public string Driver_Medical_Facility_State
        {
            get { return _Driver_Medical_Facility_State; }
            set { _Driver_Medical_Facility_State = value; }
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
        ///gets or sets FK_SLT_Incident_Review value
        /// </summary>
        public decimal FK_SLT_Incident_Review
        {
            get { return _FK_SLT_Incident_Review; }
            set { _FK_SLT_Incident_Review = value; }
        }
        #endregion

        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the AL_FR class. with the default value.

        /// </summary>
        public AL_FR()
        {

            this._PK_AL_FR_ID = -1;
            this._AL_FR_Number = -1;
            this._Driver_Medical_Facility_ZipCode = "";
            this._Driver_Medical_Facility_Type = "";
            this._Driver_Date_Of_Initial_Treatment = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Driver_Treating_Physician_Name = "";
            this._Driver_Airlifted_Medivac = false;
            this._Driver_Admitted_to_Hospital = false;
            this._Driver_Date_Admitted_to_Hospital = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Driver_Still_in_Hospital = false;
            this._Driver_Physicians_Name = "";
            this._Citation_Issued = false;
            this._Citation_Number = "";
            this._Driver_Was_Injured = false;
            this._Driver_Injury_Description = "";
            this._Driver_Sought_Medical_Attention = false;
            this._Driver_Is_Owner = false;
            this._Passenger_Name = "";
            this._Passenger_Address_1 = "";
            this._Passenger_Address_2 = "";
            this._Passenger_City = "";
            this._Passenger_State = "";
            this._Passenger_ZipCode = "";
            this._Passenger_Date_of_Birth = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Passenger_Work_Phone = "";
            this._Passenger_Home_Phone = "";
            this._Passenger_Alternate_Phone = "";
            this._Passenger_Drivers_License_Number = "";
            this._Passenger_Drivers_License_State = "";
            this._Passenger_Was_Injured = false;
            this._Passenger_Sought_Medical_Attention = false;
            this._Passenger_Description_of_Injury = "";
            this._Passenger_Relation_to_Insured = "";
            this._Other_Vehicle_Year = -1;
            this._Other_Vehicle_Make = "";
            this._Other_Vehicle_Model = "";
            this._Other_Vehicle_VIN = "";
            this._Other_Vehicle_License_Plate_Number = "";
            this._Other_Vehicle_License_Plate_State = "";
            this._Other_Vehicle_Vehicle_Color = "";
            this._Other_Vehicle_Insurance_Co_Name = "";
            this._Other_Vehicle_Insurance_Co_Phone = "";
            this._Other_Vehicle_Insurance_Policy_Number = "";
            this._Other_Vehicle_Vehicle_Damage_Description = "";
            this._Other_Vehicle_Repairs_Estimated_Amount = "";
            this._Other_Vehicle_Repairs_Completed = false;
            this._Other_Vehicle_Drivable = false;
            this._Other_Vehicle_Location = "";
            this._Other_Vehicle_Location_Driver_Address_1 = "";
            this._Other_Vehicle_Location_Driver_Address_2 = "";
            this._Other_Vehicle_Location_Driver_City = "";
            this._Other_Vehicle_Location_Driver_State = "";
            this._Other_Vehicle_Location_Driver_ZipCode = "";
            this._Other_Vehicle_Location_Telephone = "";
            this._Other_Vehicle_Owner_Name = "";
            this._Other_Vehicle_Owner_Address_1 = "";
            this._Other_Vehicle_Owner_Address_2 = "";
            this._Other_Vehicle_Owner_City = "";
            this._Other_Vehicle_Owner_State = "";
            this._Other_Vehicle_Owner_ZipCode = "";
            this._Other_Vehicle_Owner_Work_Phone = "";
            this._Other_Vehicle_Owner_Home_Phone = "";
            this._Other_Vehicle_Owner_Alternate_Phone = "";
            this._Other_Driver_Name = "";
            this._Other_Driver_Address_1 = "";
            this._Other_Driver_Address_2 = "";
            this._Other_Driver_City = "";
            this._Other_Driver_State = "";
            this._Other_Driver_ZipCode = "";
            this._Other_Driver_SSN = "";
            this._Other_Driver_Date_of_Birth = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Other_Driver_Work_Phone = "";
            this._Other_Driver_Home_Phone = "";
            this._Other_Driver_Alternate_Phone = "";
            this._Other_Driver_Drivers_License_Number = "";
            this._Other_Driver_Drivers_License_State = "";
            this._Other_Driver_Taken_By_Emergency_Transportation = false;
            this._Other_Driver_Medical_Facility_Name = "";
            this._Other_Driver_Medical_Facility_Address_1 = "";
            this._Other_Driver_Medical_Facility_Address_2 = "";
            this._Other_Driver_Medical_Facility_City = "";
            this._Other_Driver_Medical_Facility_State = "";
            this._Other_Driver_Medical_Facility_Zip_Code = "";
            this._Other_Driver_Medical_Facility_Type = "";
            this._Other_Driver_Airlifted_Medivac = false;
            this._Other_Driver_Citation_Issued = false;
            this._Other_Driver_Citation_Number = "";
            this._Other_Driver_Gender = "";
            this._Other_Driver_Injured = false;
            this._Other_Driver_Injury_Description = "";
            this._Other_Driver_Sought_Medical_Attention = false;
            this._Other_Driver_Admitted_to_Hospital = false;
            this._Other_Driver_Date_Admitted_to_Hospital = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Other_Driver_Still_in_Hospital = false;
            this._Other_Driver_Physicians_Name = "";
            this._Oth_Veh_Pass_Name = "";
            this._Oth_Veh_Pass_Address_1 = "";
            this._Oth_Veh_Pass_Address_2 = "";
            this._Oth_Veh_Pass_City = "";
            this._Oth_Veh_Pass_State = "";
            this._Oth_Veh_Pass_ZipCode = "";
            this._Oth_Veh_Pass_Date_of_Birth = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Oth_Veh_Pass_Work_Phone = "";
            this._Oth_Veh_Pass_Home_Phone = "";
            this._Oth_Veh_Pass_Alternate_Phone = "";
            this._Oth_Veh_Pass_Taken_By_Emergency_Transportation = false;
            this._Oth_Veh_Pass_Medical_Facility_Name = "";
            this._Oth_Veh_Pass_Medical_Facility_Address_1 = "";
            this._Oth_Veh_Pass_Medical_Facility_Address_2 = "";
            this._Oth_Veh_Pass_Medical_Facility_City = "";
            this._Oth_Veh_Pass_Medical_Facility_State = -1;
            this._Oth_Veh_Pass_Medical_Facility_ZipCode = "";
            this._Oth_Veh_Pass_Medical_Facility_Type = "";
            this._Oth_Veh_Pass_Airlifted_Medivac = false;
            this._Oth_Veh_Pass_Injured = false;
            this._Oth_Veh_Pass_Injury_Description = "";
            this._Oth_Veh_Pass_Sought_Medical_Attention = false;
            this._Oth_Veh_Pass_Admitted_to_Hospital = false;
            this._Oth_Veh_Pass_Date_Admitted_to_Hospital = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Oth_Veh_Pass_Still_in_Hospital = false;
            this._Oth_Veh_Pass_Physicians_Name = "";
            this._Pedestrian_Name = "";
            this._Pedestrian_Address_1 = "";
            this._Pedestrian_Address_2 = "";
            this._Pedestrian_City = "";
            this._Pedestrian_State = "";
            this._Pedestrian_ZipCode = "";
            this._Pedestrian_Date_of_Birth = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Pedestrian_Work_Phone = "";
            this._Pedestrian_Home_Phone = "";
            this._Pedestrian_Alternate_Phone = "";
            this._Pedestrian_Taken_By_Emergency_Transportation = false;
            this._Pedestrian_Medical_Facility_Name = "";
            this._Pedestrian_Medical_Facility_Address_1 = "";
            this._Pedestrian_Medical_Facility_Address_2 = "";
            this._Pedestrian_Medical_Facility_City = "";
            this._Pedestrian_Medical_Facility_State = "";
            this._Pedestrian_Medical_Facility_Zip_Code = "";
            this._Pedestrian_Medical_Facility_Type = "";
            this._Pedestrian_Airlifted_Medivac = false;
            this._Pedestrian_Injured = false;
            this._Pedestrian_Injury_Description = "";
            this._Pedestrian_Sought_Medical_Attention = false;
            this._Pedestrian_Admitted_to_Hospital = false;
            this._Pedestrian_Date_Admitted_to_Hospital = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Pedestrian_Still_in_Hospital = false;
            this._Pedestrian_Physicians_Name = "";
            this._Witness_Name = "";
            this._Witness_Address_1 = "";
            this._Witness_Address_2 = "";
            this._Witness_City = "";
            this._Witness_State = "";
            this._Witness_ZipCode = "";
            this._Witness_Work_Phone = "";
            this._Witness_Home_Phone = "";
            this._Witness_Alternate_Phone = "";
            this._Comments = "";
            this._Complete = false;
            this._FK_Contact = -1;
            this._Claimant_state = "";
            this._FK_LU_Auto_Liability_Type = "";
            this._Date_Of_Loss = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Time_Of_Loss = "";
            this._Loss_offsite = false;
            this._Offsite_Address_1 = "";
            this._Offsite_Address_2 = "";
            this._Offsite_City = "";
            this._Offsite_State = "";
            this._Offsite_zip = "";
            this._FK_Loss_Location = -1;
            this._Description_Of_Loss = "";
            this._Date_Reported_To_Sonic = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Weather_Conditions = "";
            this._Road_Conditions = "";
            this._Were_Police_Notified = false;
            this._Police_Agency = "";
            this._Police_Case_Number = "";
            this._Police_Station_Phone_Number = "";
            this._Pedestrian_Involved = false;
            this._Property_Damage = false;
            this._Witnesses = false;
            this._Security_Video_System = false;
            this._Vehicle_Sub_Type = "";
            this._Vehicle_Fleet_number = "";
            this._Year = -1;
            this._Make = "";
            this._Model = "";
            this._VIN = "";
            this._License_Plate_Number = "";
            this._License_Plate_State = "";
            this._Vehicle_Color = "";
            this._Permissive_Use = false;
            this._Type_Of_Use = "";
            this._Vehicle_Damage_Description = "";
            this._Repairs_Estimated_Amount = "";
            this._Repairs_Completed = false;
            this._Drivable = false;
            this._Passengers = false;
            this._Vehicle_Location = "";
            this._Vehicle_Location_Driver_Address_1 = "";
            this._Vehicle_Location_Driver_Address_2 = "";
            this._Vehicle_Location_Driver_City = "";
            this._Vehicle_Location_Driver_State = -1;
            this._Vehicle_Location_Driver_ZipCode = "";
            this._Insured_Driver_At_Fault = false;
            this._Owner_Name = "";
            this._Owner_Address_1 = "";
            this._Owner_Address_2 = "";
            this._Owner_City = "";
            this._Owner_State = "";
            this._Owner_ZipCode = "";
            this._Owner_Work_Phone = "";
            this._Owner_Home_Phone = "";
            this._Owner_Alternate_Phone = "";
            this._Driver_Name = "";
            this._Driver_Address_1 = "";
            this._Driver_Address_2 = "";
            this._Driver_City = "";
            this._Driver_State = "";
            this._Driver_ZipCode = "";
            this._Driver_SSN = "";
            this._Driver_Date_of_Birth = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Driver_Work_Phone = "";
            this._Driver_Home_Phone = "";
            this._Driver_Altermate_Phone = "";
            this._Driver_Drivers_License_Number = "";
            this._Driver_Drivers_License_State = "";
            this._Driver_Relation_to_Insured = "";
            this._Driver_Taken_By_Emergency_Transportation = false;
            this._Driver_Medical_Facility_Name = "";
            this._Driver_Medical_Facility_Address_1 = "";
            this._Driver_Medical_Facility_Address_2 = "";
            this._Driver_Medical_Facility_City = "";
            this._Driver_Medical_Facility_State = "";
            this._Updated_By = -1;
            this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._FK_SLT_Incident_Review = -1;

        }



        /// <summary> 

        /// Initializes a new instance of the AL_FR class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public AL_FR(decimal PK)
        {

            DataTable dtAL_FR = SelectByPK(PK).Tables[0];

            if (dtAL_FR.Rows.Count > 0)
            {

                DataRow drAL_FR = dtAL_FR.Rows[0];


                this._PK_AL_FR_ID = drAL_FR["PK_AL_FR_ID"] != DBNull.Value ? Convert.ToDecimal(drAL_FR["PK_AL_FR_ID"]) : 0;
                this._AL_FR_Number = drAL_FR["AL_FR_Number"] != DBNull.Value ? Convert.ToDecimal(drAL_FR["AL_FR_Number"]) : 0;
                this._Driver_Medical_Facility_ZipCode = Convert.ToString(drAL_FR["Driver_Medical_Facility_ZipCode"]);
                this._Driver_Medical_Facility_Type = Convert.ToString(drAL_FR["Driver_Medical_Facility_Type"]);
                this._Driver_Date_Of_Initial_Treatment = drAL_FR["Driver_Date_Of_Initial_Treatment"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Driver_Date_Of_Initial_Treatment"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Driver_Treating_Physician_Name = Convert.ToString(drAL_FR["Driver_Treating_Physician_Name"]);
                if (drAL_FR["Driver_Airlifted_Medivac"] != DBNull.Value)
                    this._Driver_Airlifted_Medivac = Convert.ToBoolean(drAL_FR["Driver_Airlifted_Medivac"]);
                if (drAL_FR["Driver_Admitted_to_Hospital"] != DBNull.Value)
                    this._Driver_Admitted_to_Hospital = Convert.ToBoolean(drAL_FR["Driver_Admitted_to_Hospital"]);
                this._Driver_Date_Admitted_to_Hospital = drAL_FR["Driver_Date_Admitted_to_Hospital"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Driver_Date_Admitted_to_Hospital"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                if (drAL_FR["Driver_Still_in_Hospital"] != DBNull.Value)
                    this._Driver_Still_in_Hospital = Convert.ToBoolean(drAL_FR["Driver_Still_in_Hospital"]);
                this._Driver_Physicians_Name = Convert.ToString(drAL_FR["Driver_Physicians_Name"]);
                if (drAL_FR["Citation_Issued"] != DBNull.Value)
                    this._Citation_Issued = Convert.ToBoolean(drAL_FR["Citation_Issued"]);
                this._Citation_Number = Convert.ToString(drAL_FR["Citation_Number"]);
                if (drAL_FR["Driver_Was_Injured"] != DBNull.Value)
                    this._Driver_Was_Injured = Convert.ToBoolean(drAL_FR["Driver_Was_Injured"]);
                this._Driver_Injury_Description = Convert.ToString(drAL_FR["Driver_Injury_Description"]);
                if (drAL_FR["Driver_Sought_Medical_Attention"] != DBNull.Value)
                    this._Driver_Sought_Medical_Attention = Convert.ToBoolean(drAL_FR["Driver_Sought_Medical_Attention"]);
                if (drAL_FR["Driver_Is_Owner"] != DBNull.Value)
                    this._Driver_Is_Owner = Convert.ToBoolean(drAL_FR["Driver_Is_Owner"]);
                this._Passenger_Name = Convert.ToString(drAL_FR["Passenger_Name"]);
                this._Passenger_Address_1 = Convert.ToString(drAL_FR["Passenger_Address_1"]);
                this._Passenger_Address_2 = Convert.ToString(drAL_FR["Passenger_Address_2"]);
                this._Passenger_City = Convert.ToString(drAL_FR["Passenger_City"]);
                this._Passenger_State = Convert.ToString(drAL_FR["Passenger_State"]);
                this._Passenger_ZipCode = Convert.ToString(drAL_FR["Passenger_ZipCode"]);
                this._Passenger_Date_of_Birth = drAL_FR["Passenger_Date_of_Birth"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Passenger_Date_of_Birth"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Passenger_Work_Phone = Convert.ToString(drAL_FR["Passenger_Work_Phone"]);
                this._Passenger_Home_Phone = Convert.ToString(drAL_FR["Passenger_Home_Phone"]);
                this._Passenger_Alternate_Phone = Convert.ToString(drAL_FR["Passenger_Alternate_Phone"]);
                this._Passenger_Drivers_License_Number = Convert.ToString(drAL_FR["Passenger_Drivers_License_Number"]);
                this._Passenger_Drivers_License_State = Convert.ToString(drAL_FR["Passenger_Drivers_License_State"]);
                if (drAL_FR["Passenger_Was_Injured"] != DBNull.Value)
                    this._Passenger_Was_Injured = Convert.ToBoolean(drAL_FR["Passenger_Was_Injured"]);
                if (drAL_FR["Passenger_Sought_Medical_Attention"] != DBNull.Value)
                    this._Passenger_Sought_Medical_Attention = Convert.ToBoolean(drAL_FR["Passenger_Sought_Medical_Attention"]);
                this._Passenger_Description_of_Injury = Convert.ToString(drAL_FR["Passenger_Description_of_Injury"]);
                this._Passenger_Relation_to_Insured = Convert.ToString(drAL_FR["Passenger_Relation_to_Insured"]);
                this._Other_Vehicle_Year = drAL_FR["Other_Vehicle_Year"] != DBNull.Value ? Convert.ToDecimal(drAL_FR["Other_Vehicle_Year"]) : 0;
                this._Other_Vehicle_Make = Convert.ToString(drAL_FR["Other_Vehicle_Make"]);
                this._Other_Vehicle_Model = Convert.ToString(drAL_FR["Other_Vehicle_Model"]);
                this._Other_Vehicle_VIN = Convert.ToString(drAL_FR["Other_Vehicle_VIN"]);
                this._Other_Vehicle_License_Plate_Number = Convert.ToString(drAL_FR["Other_Vehicle_License_Plate_Number"]);
                this._Other_Vehicle_License_Plate_State = Convert.ToString(drAL_FR["Other_Vehicle_License_Plate_State"]);
                this._Other_Vehicle_Vehicle_Color = Convert.ToString(drAL_FR["Other_Vehicle_Vehicle_Color"]);
                this._Other_Vehicle_Insurance_Co_Name = Convert.ToString(drAL_FR["Other_Vehicle_Insurance_Co_Name"]);
                this._Other_Vehicle_Insurance_Co_Phone = Convert.ToString(drAL_FR["Other_Vehicle_Insurance_Co_Phone"]);
                this._Other_Vehicle_Insurance_Policy_Number = Convert.ToString(drAL_FR["Other_Vehicle_Insurance_Policy_Number"]);
                this._Other_Vehicle_Vehicle_Damage_Description = Convert.ToString(drAL_FR["Other_Vehicle_Vehicle_Damage_Description"]);
                this._Other_Vehicle_Repairs_Estimated_Amount = Convert.ToString(drAL_FR["Other_Vehicle_Repairs_Estimated_Amount"]);
                this._Other_Vehicle_Repairs_Completed = drAL_FR["Other_Vehicle_Repairs_Completed"] != DBNull.Value ? Convert.ToBoolean(drAL_FR["Other_Vehicle_Repairs_Completed"]) : false;
                if (drAL_FR["Other_Vehicle_Drivable"] != DBNull.Value)
                    this._Other_Vehicle_Drivable = Convert.ToBoolean(drAL_FR["Other_Vehicle_Drivable"]);
                this._Other_Vehicle_Location = Convert.ToString(drAL_FR["Other_Vehicle_Location"]);
                this._Other_Vehicle_Location_Driver_Address_1 = Convert.ToString(drAL_FR["Other_Vehicle_Location_Driver_Address_1"]);
                this._Other_Vehicle_Location_Driver_Address_2 = Convert.ToString(drAL_FR["Other_Vehicle_Location_Driver_Address_2"]);
                this._Other_Vehicle_Location_Driver_City = Convert.ToString(drAL_FR["Other_Vehicle_Location_Driver_City"]);
                this._Other_Vehicle_Location_Driver_State = Convert.ToString(drAL_FR["Other_Vehicle_Location_Driver_State"]);
                this._Other_Vehicle_Location_Driver_ZipCode = Convert.ToString(drAL_FR["Other_Vehicle_Location_Driver_ZipCode"]);
                this._Other_Vehicle_Location_Telephone = Convert.ToString(drAL_FR["Other_Vehicle_Location_Telephone"]);
                this._Other_Vehicle_Owner_Name = Convert.ToString(drAL_FR["Other_Vehicle_Owner_Name"]);
                this._Other_Vehicle_Owner_Address_1 = Convert.ToString(drAL_FR["Other_Vehicle_Owner_Address_1"]);
                this._Other_Vehicle_Owner_Address_2 = Convert.ToString(drAL_FR["Other_Vehicle_Owner_Address_2"]);
                this._Other_Vehicle_Owner_City = Convert.ToString(drAL_FR["Other_Vehicle_Owner_City"]);
                this._Other_Vehicle_Owner_State = Convert.ToString(drAL_FR["Other_Vehicle_Owner_State"]);
                this._Other_Vehicle_Owner_ZipCode = Convert.ToString(drAL_FR["Other_Vehicle_Owner_ZipCode"]);
                this._Other_Vehicle_Owner_Work_Phone = Convert.ToString(drAL_FR["Other_Vehicle_Owner_Work_Phone"]);
                this._Other_Vehicle_Owner_Home_Phone = Convert.ToString(drAL_FR["Other_Vehicle_Owner_Home_Phone"]);
                this._Other_Vehicle_Owner_Alternate_Phone = Convert.ToString(drAL_FR["Other_Vehicle_Owner_Alternate_Phone"]);
                this._Other_Driver_Name = Convert.ToString(drAL_FR["Other_Driver_Name"]);
                this._Other_Driver_Address_1 = Convert.ToString(drAL_FR["Other_Driver_Address_1"]);
                this._Other_Driver_Address_2 = Convert.ToString(drAL_FR["Other_Driver_Address_2"]);
                this._Other_Driver_City = Convert.ToString(drAL_FR["Other_Driver_City"]);
                this._Other_Driver_State = Convert.ToString(drAL_FR["Other_Driver_State"]);
                this._Other_Driver_ZipCode = Convert.ToString(drAL_FR["Other_Driver_ZipCode"]);
                this._Other_Driver_SSN = Convert.ToString(drAL_FR["Other_Driver_SSN"]);
                this._Other_Driver_Date_of_Birth = drAL_FR["Other_Driver_Date_of_Birth"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Other_Driver_Date_of_Birth"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Other_Driver_Work_Phone = Convert.ToString(drAL_FR["Other_Driver_Work_Phone"]);
                this._Other_Driver_Home_Phone = Convert.ToString(drAL_FR["Other_Driver_Home_Phone"]);
                this._Other_Driver_Alternate_Phone = Convert.ToString(drAL_FR["Other_Driver_Alternate_Phone"]);
                this._Other_Driver_Drivers_License_Number = Convert.ToString(drAL_FR["Other_Driver_Drivers_License_Number"]);
                this._Other_Driver_Drivers_License_State = Convert.ToString(drAL_FR["Other_Driver_Drivers_License_State"]);
                this._Other_Driver_Taken_By_Emergency_Transportation = drAL_FR["Other_Driver_Taken_By_Emergency_Transportation"] != DBNull.Value ? Convert.ToBoolean(drAL_FR["Other_Driver_Taken_By_Emergency_Transportation"]) : false;
                this._Other_Driver_Medical_Facility_Name = Convert.ToString(drAL_FR["Other_Driver_Medical_Facility_Name"]);
                this._Other_Driver_Medical_Facility_Address_1 = Convert.ToString(drAL_FR["Other_Driver_Medical_Facility_Address_1"]);
                this._Other_Driver_Medical_Facility_Address_2 = Convert.ToString(drAL_FR["Other_Driver_Medical_Facility_Address_2"]);
                this._Other_Driver_Medical_Facility_City = Convert.ToString(drAL_FR["Other_Driver_Medical_Facility_City"]);
                this._Other_Driver_Medical_Facility_State = Convert.ToString(drAL_FR["Other_Driver_Medical_Facility_State"]);
                this._Other_Driver_Medical_Facility_Zip_Code = Convert.ToString(drAL_FR["Other_Driver_Medical_Facility_Zip_Code"]);
                this._Other_Driver_Medical_Facility_Type = Convert.ToString(drAL_FR["Other_Driver_Medical_Facility_Type"]);
                if (drAL_FR["Other_Driver_Airlifted_Medivac"] != DBNull.Value)
                    this._Other_Driver_Airlifted_Medivac = Convert.ToBoolean(drAL_FR["Other_Driver_Airlifted_Medivac"]);
                if (drAL_FR["Other_Driver_Citation_Issued"] != DBNull.Value)
                    this._Other_Driver_Citation_Issued = Convert.ToBoolean(drAL_FR["Other_Driver_Citation_Issued"]);
                this._Other_Driver_Citation_Number = Convert.ToString(drAL_FR["Other_Driver_Citation_Number"]);
                this._Other_Driver_Gender = Convert.ToString(drAL_FR["Other_Driver_Gender"]);
                if (drAL_FR["Other_Driver_Injured"] != DBNull.Value)
                    this._Other_Driver_Injured = Convert.ToBoolean(drAL_FR["Other_Driver_Injured"]);
                this._Other_Driver_Injury_Description = Convert.ToString(drAL_FR["Other_Driver_Injury_Description"]);
                if (drAL_FR["Other_Driver_Sought_Medical_Attention"] != DBNull.Value)
                    this._Other_Driver_Sought_Medical_Attention = Convert.ToBoolean(drAL_FR["Other_Driver_Sought_Medical_Attention"]);
                if (drAL_FR["Other_Driver_Admitted_to_Hospital"] != DBNull.Value)
                    this._Other_Driver_Admitted_to_Hospital = Convert.ToBoolean(drAL_FR["Other_Driver_Admitted_to_Hospital"]);
                this._Other_Driver_Date_Admitted_to_Hospital = drAL_FR["Other_Driver_Date_Admitted_to_Hospital"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Other_Driver_Date_Admitted_to_Hospital"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                if (drAL_FR["Other_Driver_Still_in_Hospital"] != DBNull.Value)
                    this._Other_Driver_Still_in_Hospital = Convert.ToBoolean(drAL_FR["Other_Driver_Still_in_Hospital"]);
                this._Other_Driver_Physicians_Name = Convert.ToString(drAL_FR["Other_Driver_Physicians_Name"]);
                this._Oth_Veh_Pass_Name = Convert.ToString(drAL_FR["Oth_Veh_Pass_Name"]);
                this._Oth_Veh_Pass_Address_1 = Convert.ToString(drAL_FR["Oth_Veh_Pass_Address_1"]);
                this._Oth_Veh_Pass_Address_2 = Convert.ToString(drAL_FR["Oth_Veh_Pass_Address_2"]);
                this._Oth_Veh_Pass_City = Convert.ToString(drAL_FR["Oth_Veh_Pass_City"]);
                this._Oth_Veh_Pass_State = Convert.ToString(drAL_FR["Oth_Veh_Pass_State"]);
                this._Oth_Veh_Pass_ZipCode = Convert.ToString(drAL_FR["Oth_Veh_Pass_ZipCode"]);
                this._Oth_Veh_Pass_Date_of_Birth = drAL_FR["Oth_Veh_Pass_Date_of_Birth"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Oth_Veh_Pass_Date_of_Birth"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Oth_Veh_Pass_Work_Phone = Convert.ToString(drAL_FR["Oth_Veh_Pass_Work_Phone"]);
                this._Oth_Veh_Pass_Home_Phone = Convert.ToString(drAL_FR["Oth_Veh_Pass_Home_Phone"]);
                this._Oth_Veh_Pass_Alternate_Phone = Convert.ToString(drAL_FR["Oth_Veh_Pass_Alternate_Phone"]);
                this._Oth_Veh_Pass_Taken_By_Emergency_Transportation = drAL_FR["Oth_Veh_Pass_Taken_By_Emergency_Transportation"] != DBNull.Value ? Convert.ToBoolean(drAL_FR["Oth_Veh_Pass_Taken_By_Emergency_Transportation"]) : false;
                this._Oth_Veh_Pass_Medical_Facility_Name = Convert.ToString(drAL_FR["Oth_Veh_Pass_Medical_Facility_Name"]);
                this._Oth_Veh_Pass_Medical_Facility_Address_1 = Convert.ToString(drAL_FR["Oth_Veh_Pass_Medical_Facility_Address_1"]);
                this._Oth_Veh_Pass_Medical_Facility_Address_2 = Convert.ToString(drAL_FR["Oth_Veh_Pass_Medical_Facility_Address_2"]);
                this._Oth_Veh_Pass_Medical_Facility_City = Convert.ToString(drAL_FR["Oth_Veh_Pass_Medical_Facility_City"]);
                this._Oth_Veh_Pass_Medical_Facility_State = drAL_FR["Oth_Veh_Pass_Medical_Facility_State"] != DBNull.Value ? Convert.ToDecimal(drAL_FR["Oth_Veh_Pass_Medical_Facility_State"]) : 0;
                this._Oth_Veh_Pass_Medical_Facility_ZipCode = Convert.ToString(drAL_FR["Oth_Veh_Pass_Medical_Facility_ZipCode"]);
                this._Oth_Veh_Pass_Medical_Facility_Type = Convert.ToString(drAL_FR["Oth_Veh_Pass_Medical_Facility_Type"]);
                if (drAL_FR["Oth_Veh_Pass_Airlifted_Medivac"] != DBNull.Value)
                    this._Oth_Veh_Pass_Airlifted_Medivac = Convert.ToBoolean(drAL_FR["Oth_Veh_Pass_Airlifted_Medivac"]);
                if (drAL_FR["Oth_Veh_Pass_Injured"] != DBNull.Value)
                    this._Oth_Veh_Pass_Injured = Convert.ToBoolean(drAL_FR["Oth_Veh_Pass_Injured"]);
                this._Oth_Veh_Pass_Injury_Description = Convert.ToString(drAL_FR["Oth_Veh_Pass_Injury_Description"]);
                if (drAL_FR["Oth_Veh_Pass_Sought_Medical_Attention"] != DBNull.Value)
                    this._Oth_Veh_Pass_Sought_Medical_Attention = Convert.ToBoolean(drAL_FR["Oth_Veh_Pass_Sought_Medical_Attention"]);
                if (drAL_FR["Oth_Veh_Pass_Admitted_to_Hospital"] != DBNull.Value)
                    this._Oth_Veh_Pass_Admitted_to_Hospital = Convert.ToBoolean(drAL_FR["Oth_Veh_Pass_Admitted_to_Hospital"]);
                this._Oth_Veh_Pass_Date_Admitted_to_Hospital = drAL_FR["Oth_Veh_Pass_Date_Admitted_to_Hospital"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Oth_Veh_Pass_Date_Admitted_to_Hospital"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                if (drAL_FR["Oth_Veh_Pass_Still_in_Hospital"] != DBNull.Value)
                    this._Oth_Veh_Pass_Still_in_Hospital = Convert.ToBoolean(drAL_FR["Oth_Veh_Pass_Still_in_Hospital"]);
                this._Oth_Veh_Pass_Physicians_Name = Convert.ToString(drAL_FR["Oth_Veh_Pass_Physicians_Name"]);
                this._Pedestrian_Name = Convert.ToString(drAL_FR["Pedestrian_Name"]);
                this._Pedestrian_Address_1 = Convert.ToString(drAL_FR["Pedestrian_Address_1"]);
                this._Pedestrian_Address_2 = Convert.ToString(drAL_FR["Pedestrian_Address_2"]);
                this._Pedestrian_City = Convert.ToString(drAL_FR["Pedestrian_City"]);
                this._Pedestrian_State = Convert.ToString(drAL_FR["Pedestrian_State"]);
                this._Pedestrian_ZipCode = Convert.ToString(drAL_FR["Pedestrian_ZipCode"]);
                this._Pedestrian_Date_of_Birth = drAL_FR["Pedestrian_Date_of_Birth"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Pedestrian_Date_of_Birth"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Pedestrian_Work_Phone = Convert.ToString(drAL_FR["Pedestrian_Work_Phone"]);
                this._Pedestrian_Home_Phone = Convert.ToString(drAL_FR["Pedestrian_Home_Phone"]);
                this._Pedestrian_Alternate_Phone = Convert.ToString(drAL_FR["Pedestrian_Alternate_Phone"]);
                this._Pedestrian_Taken_By_Emergency_Transportation = drAL_FR["Pedestrian_Taken_By_Emergency_Transportation"] != DBNull.Value ? Convert.ToBoolean(drAL_FR["Pedestrian_Taken_By_Emergency_Transportation"]) : false;
                this._Pedestrian_Medical_Facility_Name = Convert.ToString(drAL_FR["Pedestrian_Medical_Facility_Name"]);
                this._Pedestrian_Medical_Facility_Address_1 = Convert.ToString(drAL_FR["Pedestrian_Medical_Facility_Address_1"]);
                this._Pedestrian_Medical_Facility_Address_2 = Convert.ToString(drAL_FR["Pedestrian_Medical_Facility_Address_2"]);
                this._Pedestrian_Medical_Facility_City = Convert.ToString(drAL_FR["Pedestrian_Medical_Facility_City"]);
                this._Pedestrian_Medical_Facility_State = Convert.ToString(drAL_FR["Pedestrian_Medical_Facility_State"]);
                this._Pedestrian_Medical_Facility_Zip_Code = Convert.ToString(drAL_FR["Pedestrian_Medical_Facility_Zip_Code"]);
                this._Pedestrian_Medical_Facility_Type = Convert.ToString(drAL_FR["Pedestrian_Medical_Facility_Type"]);
                if (drAL_FR["Pedestrian_Airlifted_Medivac"] != DBNull.Value)
                    this._Pedestrian_Airlifted_Medivac = Convert.ToBoolean(drAL_FR["Pedestrian_Airlifted_Medivac"]);
                if (drAL_FR["Pedestrian_Injured"] != DBNull.Value)
                    this._Pedestrian_Injured = Convert.ToBoolean(drAL_FR["Pedestrian_Injured"]);
                this._Pedestrian_Injury_Description = Convert.ToString(drAL_FR["Pedestrian_Injury_Description"]);
                if (drAL_FR["Pedestrian_Sought_Medical_Attention"] != DBNull.Value)
                    this._Pedestrian_Sought_Medical_Attention = Convert.ToBoolean(drAL_FR["Pedestrian_Sought_Medical_Attention"]);
                if (drAL_FR["Pedestrian_Admitted_to_Hospital"] != DBNull.Value)
                    this._Pedestrian_Admitted_to_Hospital = Convert.ToBoolean(drAL_FR["Pedestrian_Admitted_to_Hospital"]);
                this._Pedestrian_Date_Admitted_to_Hospital = drAL_FR["Pedestrian_Date_Admitted_to_Hospital"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Pedestrian_Date_Admitted_to_Hospital"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                if (drAL_FR["Pedestrian_Still_in_Hospital"] != DBNull.Value)
                    this._Pedestrian_Still_in_Hospital = Convert.ToBoolean(drAL_FR["Pedestrian_Still_in_Hospital"]);
                this._Pedestrian_Physicians_Name = Convert.ToString(drAL_FR["Pedestrian_Physicians_Name"]);
                this._Witness_Name = Convert.ToString(drAL_FR["Witness_Name"]);
                this._Witness_Address_1 = Convert.ToString(drAL_FR["Witness_Address_1"]);
                this._Witness_Address_2 = Convert.ToString(drAL_FR["Witness_Address_2"]);
                this._Witness_City = Convert.ToString(drAL_FR["Witness_City"]);
                this._Witness_State = Convert.ToString(drAL_FR["Witness_State"]);
                this._Witness_ZipCode = Convert.ToString(drAL_FR["Witness_ZipCode"]);
                this._Witness_Work_Phone = Convert.ToString(drAL_FR["Witness_Work_Phone"]);
                this._Witness_Home_Phone = Convert.ToString(drAL_FR["Witness_Home_Phone"]);
                this._Witness_Alternate_Phone = Convert.ToString(drAL_FR["Witness_Alternate_Phone"]);
                this._Comments = Convert.ToString(drAL_FR["Comments"]);
                this._Complete = drAL_FR["Complete"] != DBNull.Value ? Convert.ToBoolean(drAL_FR["Complete"]) : false;
                this._FK_Contact = drAL_FR["FK_Contact"] != DBNull.Value ? Convert.ToDecimal(drAL_FR["FK_Contact"]) : 0;
                this._Claimant_state = Convert.ToString(drAL_FR["Claimant_state"]);
                this._FK_LU_Auto_Liability_Type = Convert.ToString(drAL_FR["FK_LU_Auto_Liability_Type"]);
                this._Date_Of_Loss = drAL_FR["Date_Of_Loss"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Date_Of_Loss"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Time_Of_Loss = Convert.ToString(drAL_FR["Time_Of_Loss"]);
                this._Loss_offsite = drAL_FR["Loss_offsite"] != DBNull.Value ? Convert.ToBoolean(drAL_FR["Loss_offsite"]) : false;
                this._Offsite_Address_1 = Convert.ToString(drAL_FR["Offsite_Address_1"]);
                this._Offsite_Address_2 = Convert.ToString(drAL_FR["Offsite_Address_2"]);
                this._Offsite_City = Convert.ToString(drAL_FR["Offsite_City"]);
                this._Offsite_State = Convert.ToString(drAL_FR["Offsite_State"]);
                this._Offsite_zip = Convert.ToString(drAL_FR["Offsite_zip"]);
                this._FK_Loss_Location = drAL_FR["FK_Loss_Location"] != DBNull.Value ? Convert.ToDecimal(drAL_FR["FK_Loss_Location"]) : 0;
                this._Description_Of_Loss = Convert.ToString(drAL_FR["Description_Of_Loss"]);
                this._Date_Reported_To_Sonic = drAL_FR["Date_Reported_To_Sonic"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Date_Reported_To_Sonic"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Weather_Conditions = Convert.ToString(drAL_FR["Weather_Conditions"]);
                this._Road_Conditions = Convert.ToString(drAL_FR["Road_Conditions"]);
                if (drAL_FR["Were_Police_Notified"] != DBNull.Value)
                    this._Were_Police_Notified = Convert.ToBoolean(drAL_FR["Were_Police_Notified"]);
                this._Police_Agency = Convert.ToString(drAL_FR["Police_Agency"]);
                this._Police_Case_Number = Convert.ToString(drAL_FR["Police_Case_Number"]);
                this._Police_Station_Phone_Number = Convert.ToString(drAL_FR["Police_Station_Phone_Number"]);
                if (drAL_FR["Pedestrian_Involved"] != DBNull.Value)
                    this._Pedestrian_Involved = Convert.ToBoolean(drAL_FR["Pedestrian_Involved"]);
                if (drAL_FR["Property_Damage"] != DBNull.Value)
                    this._Property_Damage = Convert.ToBoolean(drAL_FR["Property_Damage"]);
                if (drAL_FR["Witnesses"] != DBNull.Value)
                    this._Witnesses = Convert.ToBoolean(drAL_FR["Witnesses"]);
                if (drAL_FR["Security_Video_System"] != DBNull.Value)
                    this._Security_Video_System = Convert.ToBoolean(drAL_FR["Security_Video_System"]);
                this._Vehicle_Sub_Type = Convert.ToString(drAL_FR["Vehicle_Sub_Type"]);
                this._Vehicle_Fleet_number = Convert.ToString(drAL_FR["Vehicle_Fleet_number"]);
                this._Year = drAL_FR["Year"] != DBNull.Value ? Convert.ToDecimal(drAL_FR["Year"]) : 0;
                this._Make = Convert.ToString(drAL_FR["Make"]);
                this._Model = Convert.ToString(drAL_FR["Model"]);
                this._VIN = Convert.ToString(drAL_FR["VIN"]);
                this._License_Plate_Number = Convert.ToString(drAL_FR["License_Plate_Number"]);
                this._License_Plate_State = Convert.ToString(drAL_FR["License_Plate_State"]);
                this._Vehicle_Color = Convert.ToString(drAL_FR["Vehicle_Color"]);
                if (drAL_FR["Permissive_Use"] != DBNull.Value)
                    this._Permissive_Use = Convert.ToBoolean(drAL_FR["Permissive_Use"]);
                this._Type_Of_Use = Convert.ToString(drAL_FR["Type_Of_Use"]);
                this._Vehicle_Damage_Description = Convert.ToString(drAL_FR["Vehicle_Damage_Description"]);
                this._Repairs_Estimated_Amount = Convert.ToString(drAL_FR["Repairs_Estimated_Amount"]);
                if (drAL_FR["Repairs_Completed"] != DBNull.Value)
                    this._Repairs_Completed = Convert.ToBoolean(drAL_FR["Repairs_Completed"]);
                if (drAL_FR["Drivable"] != DBNull.Value)
                    this._Drivable = Convert.ToBoolean(drAL_FR["Drivable"]);
                if (drAL_FR["Passengers"] != DBNull.Value)
                    this._Passengers = Convert.ToBoolean(drAL_FR["Passengers"]);
                this._Vehicle_Location = Convert.ToString(drAL_FR["Vehicle_Location"]);
                this._Vehicle_Location_Driver_Address_1 = Convert.ToString(drAL_FR["Vehicle_Location_Driver_Address_1"]);
                this._Vehicle_Location_Driver_Address_2 = Convert.ToString(drAL_FR["Vehicle_Location_Driver_Address_2"]);
                this._Vehicle_Location_Driver_City = Convert.ToString(drAL_FR["Vehicle_Location_Driver_City"]);
                this._Vehicle_Location_Driver_State = drAL_FR["Vehicle_Location_Driver_State"] != DBNull.Value ? Convert.ToDecimal(drAL_FR["Vehicle_Location_Driver_State"]) : 0;
                this._Vehicle_Location_Driver_ZipCode = Convert.ToString(drAL_FR["Vehicle_Location_Driver_ZipCode"]);
                if (drAL_FR["Insured_Driver_At_Fault"] != DBNull.Value)
                    this._Insured_Driver_At_Fault = Convert.ToBoolean(drAL_FR["Insured_Driver_At_Fault"]);
                this._Owner_Name = Convert.ToString(drAL_FR["Owner_Name"]);
                this._Owner_Address_1 = Convert.ToString(drAL_FR["Owner_Address_1"]);
                this._Owner_Address_2 = Convert.ToString(drAL_FR["Owner_Address_2"]);
                this._Owner_City = Convert.ToString(drAL_FR["Owner_City"]);
                this._Owner_State = Convert.ToString(drAL_FR["Owner_State"]);
                this._Owner_ZipCode = Convert.ToString(drAL_FR["Owner_ZipCode"]);
                this._Owner_Work_Phone = Convert.ToString(drAL_FR["Owner_Work_Phone"]);
                this._Owner_Home_Phone = Convert.ToString(drAL_FR["Owner_Home_Phone"]);
                this._Owner_Alternate_Phone = Convert.ToString(drAL_FR["Owner_Alternate_Phone"]);
                this._Driver_Name = Convert.ToString(drAL_FR["Driver_Name"]);
                this._Driver_Address_1 = Convert.ToString(drAL_FR["Driver_Address_1"]);
                this._Driver_Address_2 = Convert.ToString(drAL_FR["Driver_Address_2"]);
                this._Driver_City = Convert.ToString(drAL_FR["Driver_City"]);
                this._Driver_State = Convert.ToString(drAL_FR["Driver_State"]);
                this._Driver_ZipCode = Convert.ToString(drAL_FR["Driver_ZipCode"]);
                this._Driver_SSN = Convert.ToString(drAL_FR["Driver_SSN"]);
                this._Driver_Date_of_Birth = drAL_FR["Driver_Date_of_Birth"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Driver_Date_of_Birth"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Driver_Work_Phone = Convert.ToString(drAL_FR["Driver_Work_Phone"]);
                this._Driver_Home_Phone = Convert.ToString(drAL_FR["Driver_Home_Phone"]);
                this._Driver_Altermate_Phone = Convert.ToString(drAL_FR["Driver_Altermate_Phone"]);
                this._Driver_Drivers_License_Number = Convert.ToString(drAL_FR["Driver_Drivers_License_Number"]);
                this._Driver_Drivers_License_State = Convert.ToString(drAL_FR["Driver_Drivers_License_State"]);
                this._Driver_Relation_to_Insured = Convert.ToString(drAL_FR["Driver_Relation_to_Insured"]);
                this._Driver_Taken_By_Emergency_Transportation = drAL_FR["Driver_Taken_By_Emergency_Transportation"] != DBNull.Value ? Convert.ToBoolean(drAL_FR["Driver_Taken_By_Emergency_Transportation"]) : false;
                this._Driver_Medical_Facility_Name = Convert.ToString(drAL_FR["Driver_Medical_Facility_Name"]);
                this._Driver_Medical_Facility_Address_1 = Convert.ToString(drAL_FR["Driver_Medical_Facility_Address_1"]);
                this._Driver_Medical_Facility_Address_2 = Convert.ToString(drAL_FR["Driver_Medical_Facility_Address_2"]);
                this._Driver_Medical_Facility_City = Convert.ToString(drAL_FR["Driver_Medical_Facility_City"]);
                this._Driver_Medical_Facility_State = Convert.ToString(drAL_FR["Driver_Medical_Facility_State"]);
                this._Updated_By = drAL_FR["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drAL_FR["Updated_By"]) : 0;
                this._Updated_Date = drAL_FR["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_SLT_Incident_Review=drAL_FR["FK_SLT_Incident_Review"] != DBNull.Value ? Convert.ToDecimal(drAL_FR["FK_SLT_Incident_Review"]) : 0;
            }

            else
            {

                this._PK_AL_FR_ID = -1;
                this._AL_FR_Number = -1;
                this._Driver_Medical_Facility_ZipCode = "";
                this._Driver_Medical_Facility_Type = "";
                this._Driver_Date_Of_Initial_Treatment = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Driver_Treating_Physician_Name = "";
                this._Driver_Airlifted_Medivac = false;
                this._Driver_Admitted_to_Hospital = false;
                this._Driver_Date_Admitted_to_Hospital = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Driver_Still_in_Hospital = false;
                this._Driver_Physicians_Name = "";
                this._Citation_Issued = false;
                this._Citation_Number = "";
                this._Driver_Was_Injured = false;
                this._Driver_Injury_Description = "";
                this._Driver_Sought_Medical_Attention = false;
                this._Driver_Is_Owner = false;
                this._Passenger_Name = "";
                this._Passenger_Address_1 = "";
                this._Passenger_Address_2 = "";
                this._Passenger_City = "";
                this._Passenger_State = "";
                this._Passenger_ZipCode = "";
                this._Passenger_Date_of_Birth = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Passenger_Work_Phone = "";
                this._Passenger_Home_Phone = "";
                this._Passenger_Alternate_Phone = "";
                this._Passenger_Drivers_License_Number = "";
                this._Passenger_Drivers_License_State = "";
                this._Passenger_Was_Injured = false;
                this._Passenger_Sought_Medical_Attention = false;
                this._Passenger_Description_of_Injury = "";
                this._Passenger_Relation_to_Insured = "";
                this._Other_Vehicle_Year = -1;
                this._Other_Vehicle_Make = "";
                this._Other_Vehicle_Model = "";
                this._Other_Vehicle_VIN = "";
                this._Other_Vehicle_License_Plate_Number = "";
                this._Other_Vehicle_License_Plate_State = "";
                this._Other_Vehicle_Vehicle_Color = "";
                this._Other_Vehicle_Insurance_Co_Name = "";
                this._Other_Vehicle_Insurance_Co_Phone = "";
                this._Other_Vehicle_Insurance_Policy_Number = "";
                this._Other_Vehicle_Vehicle_Damage_Description = "";
                this._Other_Vehicle_Repairs_Estimated_Amount = "";
                this._Other_Vehicle_Repairs_Completed = false;
                this._Other_Vehicle_Drivable = false;
                this._Other_Vehicle_Location = "";
                this._Other_Vehicle_Location_Driver_Address_1 = "";
                this._Other_Vehicle_Location_Driver_Address_2 = "";
                this._Other_Vehicle_Location_Driver_City = "";
                this._Other_Vehicle_Location_Driver_State = "";
                this._Other_Vehicle_Location_Driver_ZipCode = "";
                this._Other_Vehicle_Location_Telephone = "";
                this._Other_Vehicle_Owner_Name = "";
                this._Other_Vehicle_Owner_Address_1 = "";
                this._Other_Vehicle_Owner_Address_2 = "";
                this._Other_Vehicle_Owner_City = "";
                this._Other_Vehicle_Owner_State = "";
                this._Other_Vehicle_Owner_ZipCode = "";
                this._Other_Vehicle_Owner_Work_Phone = "";
                this._Other_Vehicle_Owner_Home_Phone = "";
                this._Other_Vehicle_Owner_Alternate_Phone = "";
                this._Other_Driver_Name = "";
                this._Other_Driver_Address_1 = "";
                this._Other_Driver_Address_2 = "";
                this._Other_Driver_City = "";
                this._Other_Driver_State = "";
                this._Other_Driver_ZipCode = "";
                this._Other_Driver_SSN = "";
                this._Other_Driver_Date_of_Birth = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Other_Driver_Work_Phone = "";
                this._Other_Driver_Home_Phone = "";
                this._Other_Driver_Alternate_Phone = "";
                this._Other_Driver_Drivers_License_Number = "";
                this._Other_Driver_Drivers_License_State = "";
                this._Other_Driver_Taken_By_Emergency_Transportation = false;
                this._Other_Driver_Medical_Facility_Name = "";
                this._Other_Driver_Medical_Facility_Address_1 = "";
                this._Other_Driver_Medical_Facility_Address_2 = "";
                this._Other_Driver_Medical_Facility_City = "";
                this._Other_Driver_Medical_Facility_State = "";
                this._Other_Driver_Medical_Facility_Zip_Code = "";
                this._Other_Driver_Medical_Facility_Type = "";
                this._Other_Driver_Airlifted_Medivac = false;
                this._Other_Driver_Citation_Issued = false;
                this._Other_Driver_Citation_Number = "";
                this._Other_Driver_Gender = "";
                this._Other_Driver_Injured = false;
                this._Other_Driver_Injury_Description = "";
                this._Other_Driver_Sought_Medical_Attention = false;
                this._Other_Driver_Admitted_to_Hospital = false;
                this._Other_Driver_Date_Admitted_to_Hospital = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Other_Driver_Still_in_Hospital = false;
                this._Other_Driver_Physicians_Name = "";
                this._Oth_Veh_Pass_Name = "";
                this._Oth_Veh_Pass_Address_1 = "";
                this._Oth_Veh_Pass_Address_2 = "";
                this._Oth_Veh_Pass_City = "";
                this._Oth_Veh_Pass_State = "";
                this._Oth_Veh_Pass_ZipCode = "";
                this._Oth_Veh_Pass_Date_of_Birth = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Oth_Veh_Pass_Work_Phone = "";
                this._Oth_Veh_Pass_Home_Phone = "";
                this._Oth_Veh_Pass_Alternate_Phone = "";
                this._Oth_Veh_Pass_Taken_By_Emergency_Transportation = false;
                this._Oth_Veh_Pass_Medical_Facility_Name = "";
                this._Oth_Veh_Pass_Medical_Facility_Address_1 = "";
                this._Oth_Veh_Pass_Medical_Facility_Address_2 = "";
                this._Oth_Veh_Pass_Medical_Facility_City = "";
                this._Oth_Veh_Pass_Medical_Facility_State = -1;
                this._Oth_Veh_Pass_Medical_Facility_ZipCode = "";
                this._Oth_Veh_Pass_Medical_Facility_Type = "";
                this._Oth_Veh_Pass_Airlifted_Medivac = false;
                this._Oth_Veh_Pass_Injured = false;
                this._Oth_Veh_Pass_Injury_Description = "";
                this._Oth_Veh_Pass_Sought_Medical_Attention = false;
                this._Oth_Veh_Pass_Admitted_to_Hospital = false;
                this._Oth_Veh_Pass_Date_Admitted_to_Hospital = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Oth_Veh_Pass_Still_in_Hospital = false;
                this._Oth_Veh_Pass_Physicians_Name = "";
                this._Pedestrian_Name = "";
                this._Pedestrian_Address_1 = "";
                this._Pedestrian_Address_2 = "";
                this._Pedestrian_City = "";
                this._Pedestrian_State = "";
                this._Pedestrian_ZipCode = "";
                this._Pedestrian_Date_of_Birth = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Pedestrian_Work_Phone = "";
                this._Pedestrian_Home_Phone = "";
                this._Pedestrian_Alternate_Phone = "";
                this._Pedestrian_Taken_By_Emergency_Transportation = false;
                this._Pedestrian_Medical_Facility_Name = "";
                this._Pedestrian_Medical_Facility_Address_1 = "";
                this._Pedestrian_Medical_Facility_Address_2 = "";
                this._Pedestrian_Medical_Facility_City = "";
                this._Pedestrian_Medical_Facility_State = "";
                this._Pedestrian_Medical_Facility_Zip_Code = "";
                this._Pedestrian_Medical_Facility_Type = "";
                this._Pedestrian_Airlifted_Medivac = false;
                this._Pedestrian_Injured = false;
                this._Pedestrian_Injury_Description = "";
                this._Pedestrian_Sought_Medical_Attention = false;
                this._Pedestrian_Admitted_to_Hospital = false;
                this._Pedestrian_Date_Admitted_to_Hospital = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Pedestrian_Still_in_Hospital = false;
                this._Pedestrian_Physicians_Name = "";
                this._Witness_Name = "";
                this._Witness_Address_1 = "";
                this._Witness_Address_2 = "";
                this._Witness_City = "";
                this._Witness_State = "";
                this._Witness_ZipCode = "";
                this._Witness_Work_Phone = "";
                this._Witness_Home_Phone = "";
                this._Witness_Alternate_Phone = "";
                this._Comments = "";
                this._Complete = false;
                this._FK_Contact = -1;
                this._Claimant_state = "";
                this._FK_LU_Auto_Liability_Type = "";
                this._Date_Of_Loss = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Time_Of_Loss = "";
                this._Loss_offsite = false;
                this._Offsite_Address_1 = "";
                this._Offsite_Address_2 = "";
                this._Offsite_City = "";
                this._Offsite_State = "";
                this._Offsite_zip = "";
                this._FK_Loss_Location = -1;
                this._Description_Of_Loss = "";
                this._Date_Reported_To_Sonic = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Weather_Conditions = "";
                this._Road_Conditions = "";
                this._Were_Police_Notified = false;
                this._Police_Agency = "";
                this._Police_Case_Number = "";
                this._Police_Station_Phone_Number = "";
                this._Pedestrian_Involved = false;
                this._Property_Damage = false;
                this._Witnesses = false;
                this._Security_Video_System = false;
                this._Vehicle_Sub_Type = "";
                this._Vehicle_Fleet_number = "";
                this._Year = -1;
                this._Make = "";
                this._Model = "";
                this._VIN = "";
                this._License_Plate_Number = "";
                this._License_Plate_State = "";
                this._Vehicle_Color = "";
                this._Permissive_Use = false;
                this._Type_Of_Use = "";
                this._Vehicle_Damage_Description = "";
                this._Repairs_Estimated_Amount = "";
                this._Repairs_Completed = false;
                this._Drivable = false;
                this._Passengers = false;
                this._Vehicle_Location = "";
                this._Vehicle_Location_Driver_Address_1 = "";
                this._Vehicle_Location_Driver_Address_2 = "";
                this._Vehicle_Location_Driver_City = "";
                this._Vehicle_Location_Driver_State = -1;
                this._Vehicle_Location_Driver_ZipCode = "";
                this._Insured_Driver_At_Fault = false;
                this._Owner_Name = "";
                this._Owner_Address_1 = "";
                this._Owner_Address_2 = "";
                this._Owner_City = "";
                this._Owner_State = "";
                this._Owner_ZipCode = "";
                this._Owner_Work_Phone = "";
                this._Owner_Home_Phone = "";
                this._Owner_Alternate_Phone = "";
                this._Driver_Name = "";
                this._Driver_Address_1 = "";
                this._Driver_Address_2 = "";
                this._Driver_City = "";
                this._Driver_State = "";
                this._Driver_ZipCode = "";
                this._Driver_SSN = "";
                this._Driver_Date_of_Birth = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Driver_Work_Phone = "";
                this._Driver_Home_Phone = "";
                this._Driver_Altermate_Phone = "";
                this._Driver_Drivers_License_Number = "";
                this._Driver_Drivers_License_State = "";
                this._Driver_Relation_to_Insured = "";
                this._Driver_Taken_By_Emergency_Transportation = false;
                this._Driver_Medical_Facility_Name = "";
                this._Driver_Medical_Facility_Address_1 = "";
                this._Driver_Medical_Facility_Address_2 = "";
                this._Driver_Medical_Facility_City = "";
                this._Driver_Medical_Facility_State = "";
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_SLT_Incident_Review = -1;
            }

        }

        /// <summary> 
        /// Initializes a new instance of the AL_FR class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public AL_FR(decimal PK, bool temp)
        {

            DataTable dtAL_FR = SelectByAL_FR_Number(PK).Tables[0];

            if (dtAL_FR.Rows.Count > 0)
            {

                DataRow drAL_FR = dtAL_FR.Rows[0];


                this._PK_AL_FR_ID = drAL_FR["PK_AL_FR_ID"] != DBNull.Value ? Convert.ToDecimal(drAL_FR["PK_AL_FR_ID"]) : 0;
                this._AL_FR_Number = drAL_FR["AL_FR_Number"] != DBNull.Value ? Convert.ToDecimal(drAL_FR["AL_FR_Number"]) : 0;
                this._Driver_Medical_Facility_ZipCode = Convert.ToString(drAL_FR["Driver_Medical_Facility_ZipCode"]);
                this._Driver_Medical_Facility_Type = Convert.ToString(drAL_FR["Driver_Medical_Facility_Type"]);
                this._Driver_Date_Of_Initial_Treatment = drAL_FR["Driver_Date_Of_Initial_Treatment"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Driver_Date_Of_Initial_Treatment"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Driver_Treating_Physician_Name = Convert.ToString(drAL_FR["Driver_Treating_Physician_Name"]);
                if (drAL_FR["Driver_Airlifted_Medivac"] != DBNull.Value)
                    this._Driver_Airlifted_Medivac = Convert.ToBoolean(drAL_FR["Driver_Airlifted_Medivac"]);
                if (drAL_FR["Driver_Admitted_to_Hospital"] != DBNull.Value)
                    this._Driver_Admitted_to_Hospital = Convert.ToBoolean(drAL_FR["Driver_Admitted_to_Hospital"]);
                this._Driver_Date_Admitted_to_Hospital = drAL_FR["Driver_Date_Admitted_to_Hospital"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Driver_Date_Admitted_to_Hospital"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                if (drAL_FR["Driver_Still_in_Hospital"] != DBNull.Value)
                    this._Driver_Still_in_Hospital = Convert.ToBoolean(drAL_FR["Driver_Still_in_Hospital"]);
                this._Driver_Physicians_Name = Convert.ToString(drAL_FR["Driver_Physicians_Name"]);
                if (drAL_FR["Citation_Issued"] != DBNull.Value)
                    this._Citation_Issued = Convert.ToBoolean(drAL_FR["Citation_Issued"]);
                this._Citation_Number = Convert.ToString(drAL_FR["Citation_Number"]);
                if (drAL_FR["Driver_Was_Injured"] != DBNull.Value)
                    this._Driver_Was_Injured = Convert.ToBoolean(drAL_FR["Driver_Was_Injured"]);
                this._Driver_Injury_Description = Convert.ToString(drAL_FR["Driver_Injury_Description"]);
                if (drAL_FR["Driver_Sought_Medical_Attention"] != DBNull.Value)
                    this._Driver_Sought_Medical_Attention = Convert.ToBoolean(drAL_FR["Driver_Sought_Medical_Attention"]);
                if (drAL_FR["Driver_Is_Owner"] != DBNull.Value)
                    this._Driver_Is_Owner = Convert.ToBoolean(drAL_FR["Driver_Is_Owner"]);
                this._Passenger_Name = Convert.ToString(drAL_FR["Passenger_Name"]);
                this._Passenger_Address_1 = Convert.ToString(drAL_FR["Passenger_Address_1"]);
                this._Passenger_Address_2 = Convert.ToString(drAL_FR["Passenger_Address_2"]);
                this._Passenger_City = Convert.ToString(drAL_FR["Passenger_City"]);
                this._Passenger_State = Convert.ToString(drAL_FR["Passenger_State"]);
                this._Passenger_ZipCode = Convert.ToString(drAL_FR["Passenger_ZipCode"]);
                this._Passenger_Date_of_Birth = drAL_FR["Passenger_Date_of_Birth"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Passenger_Date_of_Birth"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Passenger_Work_Phone = Convert.ToString(drAL_FR["Passenger_Work_Phone"]);
                this._Passenger_Home_Phone = Convert.ToString(drAL_FR["Passenger_Home_Phone"]);
                this._Passenger_Alternate_Phone = Convert.ToString(drAL_FR["Passenger_Alternate_Phone"]);
                this._Passenger_Drivers_License_Number = Convert.ToString(drAL_FR["Passenger_Drivers_License_Number"]);
                this._Passenger_Drivers_License_State = Convert.ToString(drAL_FR["Passenger_Drivers_License_State"]);
                if (drAL_FR["Passenger_Was_Injured"] != DBNull.Value)
                    this._Passenger_Was_Injured = Convert.ToBoolean(drAL_FR["Passenger_Was_Injured"]);
                if (drAL_FR["Passenger_Sought_Medical_Attention"] != DBNull.Value)
                    this._Passenger_Sought_Medical_Attention = Convert.ToBoolean(drAL_FR["Passenger_Sought_Medical_Attention"]);
                this._Passenger_Description_of_Injury = Convert.ToString(drAL_FR["Passenger_Description_of_Injury"]);
                this._Passenger_Relation_to_Insured = Convert.ToString(drAL_FR["Passenger_Relation_to_Insured"]);
                this._Other_Vehicle_Year = drAL_FR["Other_Vehicle_Year"] != DBNull.Value ? Convert.ToDecimal(drAL_FR["Other_Vehicle_Year"]) : 0;
                this._Other_Vehicle_Make = Convert.ToString(drAL_FR["Other_Vehicle_Make"]);
                this._Other_Vehicle_Model = Convert.ToString(drAL_FR["Other_Vehicle_Model"]);
                this._Other_Vehicle_VIN = Convert.ToString(drAL_FR["Other_Vehicle_VIN"]);
                this._Other_Vehicle_License_Plate_Number = Convert.ToString(drAL_FR["Other_Vehicle_License_Plate_Number"]);
                this._Other_Vehicle_License_Plate_State = Convert.ToString(drAL_FR["Other_Vehicle_License_Plate_State"]);
                this._Other_Vehicle_Vehicle_Color = Convert.ToString(drAL_FR["Other_Vehicle_Vehicle_Color"]);
                this._Other_Vehicle_Insurance_Co_Name = Convert.ToString(drAL_FR["Other_Vehicle_Insurance_Co_Name"]);
                this._Other_Vehicle_Insurance_Co_Phone = Convert.ToString(drAL_FR["Other_Vehicle_Insurance_Co_Phone"]);
                this._Other_Vehicle_Insurance_Policy_Number = Convert.ToString(drAL_FR["Other_Vehicle_Insurance_Policy_Number"]);
                this._Other_Vehicle_Vehicle_Damage_Description = Convert.ToString(drAL_FR["Other_Vehicle_Vehicle_Damage_Description"]);
                this._Other_Vehicle_Repairs_Estimated_Amount = Convert.ToString(drAL_FR["Other_Vehicle_Repairs_Estimated_Amount"]);
                this._Other_Vehicle_Repairs_Completed = drAL_FR["Other_Vehicle_Repairs_Completed"] != DBNull.Value ? Convert.ToBoolean(drAL_FR["Other_Vehicle_Repairs_Completed"]) : false;
                if (drAL_FR["Other_Vehicle_Drivable"] != DBNull.Value)
                    this._Other_Vehicle_Drivable = Convert.ToBoolean(drAL_FR["Other_Vehicle_Drivable"]);
                this._Other_Vehicle_Location = Convert.ToString(drAL_FR["Other_Vehicle_Location"]);
                this._Other_Vehicle_Location_Driver_Address_1 = Convert.ToString(drAL_FR["Other_Vehicle_Location_Driver_Address_1"]);
                this._Other_Vehicle_Location_Driver_Address_2 = Convert.ToString(drAL_FR["Other_Vehicle_Location_Driver_Address_2"]);
                this._Other_Vehicle_Location_Driver_City = Convert.ToString(drAL_FR["Other_Vehicle_Location_Driver_City"]);
                this._Other_Vehicle_Location_Driver_State = Convert.ToString(drAL_FR["Other_Vehicle_Location_Driver_State"]);
                this._Other_Vehicle_Location_Driver_ZipCode = Convert.ToString(drAL_FR["Other_Vehicle_Location_Driver_ZipCode"]);
                this._Other_Vehicle_Location_Telephone = Convert.ToString(drAL_FR["Other_Vehicle_Location_Telephone"]);
                this._Other_Vehicle_Owner_Name = Convert.ToString(drAL_FR["Other_Vehicle_Owner_Name"]);
                this._Other_Vehicle_Owner_Address_1 = Convert.ToString(drAL_FR["Other_Vehicle_Owner_Address_1"]);
                this._Other_Vehicle_Owner_Address_2 = Convert.ToString(drAL_FR["Other_Vehicle_Owner_Address_2"]);
                this._Other_Vehicle_Owner_City = Convert.ToString(drAL_FR["Other_Vehicle_Owner_City"]);
                this._Other_Vehicle_Owner_State = Convert.ToString(drAL_FR["Other_Vehicle_Owner_State"]);
                this._Other_Vehicle_Owner_ZipCode = Convert.ToString(drAL_FR["Other_Vehicle_Owner_ZipCode"]);
                this._Other_Vehicle_Owner_Work_Phone = Convert.ToString(drAL_FR["Other_Vehicle_Owner_Work_Phone"]);
                this._Other_Vehicle_Owner_Home_Phone = Convert.ToString(drAL_FR["Other_Vehicle_Owner_Home_Phone"]);
                this._Other_Vehicle_Owner_Alternate_Phone = Convert.ToString(drAL_FR["Other_Vehicle_Owner_Alternate_Phone"]);
                this._Other_Driver_Name = Convert.ToString(drAL_FR["Other_Driver_Name"]);
                this._Other_Driver_Address_1 = Convert.ToString(drAL_FR["Other_Driver_Address_1"]);
                this._Other_Driver_Address_2 = Convert.ToString(drAL_FR["Other_Driver_Address_2"]);
                this._Other_Driver_City = Convert.ToString(drAL_FR["Other_Driver_City"]);
                this._Other_Driver_State = Convert.ToString(drAL_FR["Other_Driver_State"]);
                this._Other_Driver_ZipCode = Convert.ToString(drAL_FR["Other_Driver_ZipCode"]);
                this._Other_Driver_SSN = Convert.ToString(drAL_FR["Other_Driver_SSN"]);
                this._Other_Driver_Date_of_Birth = drAL_FR["Other_Driver_Date_of_Birth"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Other_Driver_Date_of_Birth"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Other_Driver_Work_Phone = Convert.ToString(drAL_FR["Other_Driver_Work_Phone"]);
                this._Other_Driver_Home_Phone = Convert.ToString(drAL_FR["Other_Driver_Home_Phone"]);
                this._Other_Driver_Alternate_Phone = Convert.ToString(drAL_FR["Other_Driver_Alternate_Phone"]);
                this._Other_Driver_Drivers_License_Number = Convert.ToString(drAL_FR["Other_Driver_Drivers_License_Number"]);
                this._Other_Driver_Drivers_License_State = Convert.ToString(drAL_FR["Other_Driver_Drivers_License_State"]);
                this._Other_Driver_Taken_By_Emergency_Transportation = drAL_FR["Other_Driver_Taken_By_Emergency_Transportation"] != DBNull.Value ? Convert.ToBoolean(drAL_FR["Other_Driver_Taken_By_Emergency_Transportation"]) : false;
                this._Other_Driver_Medical_Facility_Name = Convert.ToString(drAL_FR["Other_Driver_Medical_Facility_Name"]);
                this._Other_Driver_Medical_Facility_Address_1 = Convert.ToString(drAL_FR["Other_Driver_Medical_Facility_Address_1"]);
                this._Other_Driver_Medical_Facility_Address_2 = Convert.ToString(drAL_FR["Other_Driver_Medical_Facility_Address_2"]);
                this._Other_Driver_Medical_Facility_City = Convert.ToString(drAL_FR["Other_Driver_Medical_Facility_City"]);
                this._Other_Driver_Medical_Facility_State = Convert.ToString(drAL_FR["Other_Driver_Medical_Facility_State"]);
                this._Other_Driver_Medical_Facility_Zip_Code = Convert.ToString(drAL_FR["Other_Driver_Medical_Facility_Zip_Code"]);
                this._Other_Driver_Medical_Facility_Type = Convert.ToString(drAL_FR["Other_Driver_Medical_Facility_Type"]);
                if (drAL_FR["Other_Driver_Airlifted_Medivac"] != DBNull.Value)
                    this._Other_Driver_Airlifted_Medivac = Convert.ToBoolean(drAL_FR["Other_Driver_Airlifted_Medivac"]);
                if (drAL_FR["Other_Driver_Citation_Issued"] != DBNull.Value)
                    this._Other_Driver_Citation_Issued = Convert.ToBoolean(drAL_FR["Other_Driver_Citation_Issued"]);
                this._Other_Driver_Citation_Number = Convert.ToString(drAL_FR["Other_Driver_Citation_Number"]);
                this._Other_Driver_Gender = Convert.ToString(drAL_FR["Other_Driver_Gender"]);
                if (drAL_FR["Other_Driver_Injured"] != DBNull.Value)
                    this._Other_Driver_Injured = Convert.ToBoolean(drAL_FR["Other_Driver_Injured"]);
                this._Other_Driver_Injury_Description = Convert.ToString(drAL_FR["Other_Driver_Injury_Description"]);
                if (drAL_FR["Other_Driver_Sought_Medical_Attention"] != DBNull.Value)
                    this._Other_Driver_Sought_Medical_Attention = Convert.ToBoolean(drAL_FR["Other_Driver_Sought_Medical_Attention"]);
                if (drAL_FR["Other_Driver_Admitted_to_Hospital"] != DBNull.Value)
                    this._Other_Driver_Admitted_to_Hospital = Convert.ToBoolean(drAL_FR["Other_Driver_Admitted_to_Hospital"]);
                this._Other_Driver_Date_Admitted_to_Hospital = drAL_FR["Other_Driver_Date_Admitted_to_Hospital"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Other_Driver_Date_Admitted_to_Hospital"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                if (drAL_FR["Other_Driver_Still_in_Hospital"] != DBNull.Value)
                    this._Other_Driver_Still_in_Hospital = Convert.ToBoolean(drAL_FR["Other_Driver_Still_in_Hospital"]);
                this._Other_Driver_Physicians_Name = Convert.ToString(drAL_FR["Other_Driver_Physicians_Name"]);
                this._Oth_Veh_Pass_Name = Convert.ToString(drAL_FR["Oth_Veh_Pass_Name"]);
                this._Oth_Veh_Pass_Address_1 = Convert.ToString(drAL_FR["Oth_Veh_Pass_Address_1"]);
                this._Oth_Veh_Pass_Address_2 = Convert.ToString(drAL_FR["Oth_Veh_Pass_Address_2"]);
                this._Oth_Veh_Pass_City = Convert.ToString(drAL_FR["Oth_Veh_Pass_City"]);
                this._Oth_Veh_Pass_State = Convert.ToString(drAL_FR["Oth_Veh_Pass_State"]);
                this._Oth_Veh_Pass_ZipCode = Convert.ToString(drAL_FR["Oth_Veh_Pass_ZipCode"]);
                this._Oth_Veh_Pass_Date_of_Birth = drAL_FR["Oth_Veh_Pass_Date_of_Birth"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Oth_Veh_Pass_Date_of_Birth"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Oth_Veh_Pass_Work_Phone = Convert.ToString(drAL_FR["Oth_Veh_Pass_Work_Phone"]);
                this._Oth_Veh_Pass_Home_Phone = Convert.ToString(drAL_FR["Oth_Veh_Pass_Home_Phone"]);
                this._Oth_Veh_Pass_Alternate_Phone = Convert.ToString(drAL_FR["Oth_Veh_Pass_Alternate_Phone"]);
                this._Oth_Veh_Pass_Taken_By_Emergency_Transportation = drAL_FR["Oth_Veh_Pass_Taken_By_Emergency_Transportation"] != DBNull.Value ? Convert.ToBoolean(drAL_FR["Oth_Veh_Pass_Taken_By_Emergency_Transportation"]) : false;
                this._Oth_Veh_Pass_Medical_Facility_Name = Convert.ToString(drAL_FR["Oth_Veh_Pass_Medical_Facility_Name"]);
                this._Oth_Veh_Pass_Medical_Facility_Address_1 = Convert.ToString(drAL_FR["Oth_Veh_Pass_Medical_Facility_Address_1"]);
                this._Oth_Veh_Pass_Medical_Facility_Address_2 = Convert.ToString(drAL_FR["Oth_Veh_Pass_Medical_Facility_Address_2"]);
                this._Oth_Veh_Pass_Medical_Facility_City = Convert.ToString(drAL_FR["Oth_Veh_Pass_Medical_Facility_City"]);
                this._Oth_Veh_Pass_Medical_Facility_State = drAL_FR["Oth_Veh_Pass_Medical_Facility_State"] != DBNull.Value ? Convert.ToDecimal(drAL_FR["Oth_Veh_Pass_Medical_Facility_State"]) : 0;
                this._Oth_Veh_Pass_Medical_Facility_ZipCode = Convert.ToString(drAL_FR["Oth_Veh_Pass_Medical_Facility_ZipCode"]);
                this._Oth_Veh_Pass_Medical_Facility_Type = Convert.ToString(drAL_FR["Oth_Veh_Pass_Medical_Facility_Type"]);
                if (drAL_FR["Oth_Veh_Pass_Airlifted_Medivac"] != DBNull.Value)
                    this._Oth_Veh_Pass_Airlifted_Medivac = Convert.ToBoolean(drAL_FR["Oth_Veh_Pass_Airlifted_Medivac"]);
                if (drAL_FR["Oth_Veh_Pass_Injured"] != DBNull.Value)
                    this._Oth_Veh_Pass_Injured = Convert.ToBoolean(drAL_FR["Oth_Veh_Pass_Injured"]);
                this._Oth_Veh_Pass_Injury_Description = Convert.ToString(drAL_FR["Oth_Veh_Pass_Injury_Description"]);
                if (drAL_FR["Oth_Veh_Pass_Sought_Medical_Attention"] != DBNull.Value)
                    this._Oth_Veh_Pass_Sought_Medical_Attention = Convert.ToBoolean(drAL_FR["Oth_Veh_Pass_Sought_Medical_Attention"]);
                if (drAL_FR["Oth_Veh_Pass_Admitted_to_Hospital"] != DBNull.Value)
                    this._Oth_Veh_Pass_Admitted_to_Hospital = Convert.ToBoolean(drAL_FR["Oth_Veh_Pass_Admitted_to_Hospital"]);
                this._Oth_Veh_Pass_Date_Admitted_to_Hospital = drAL_FR["Oth_Veh_Pass_Date_Admitted_to_Hospital"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Oth_Veh_Pass_Date_Admitted_to_Hospital"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                if (drAL_FR["Oth_Veh_Pass_Still_in_Hospital"] != DBNull.Value)
                    this._Oth_Veh_Pass_Still_in_Hospital = Convert.ToBoolean(drAL_FR["Oth_Veh_Pass_Still_in_Hospital"]);
                this._Oth_Veh_Pass_Physicians_Name = Convert.ToString(drAL_FR["Oth_Veh_Pass_Physicians_Name"]);
                this._Pedestrian_Name = Convert.ToString(drAL_FR["Pedestrian_Name"]);
                this._Pedestrian_Address_1 = Convert.ToString(drAL_FR["Pedestrian_Address_1"]);
                this._Pedestrian_Address_2 = Convert.ToString(drAL_FR["Pedestrian_Address_2"]);
                this._Pedestrian_City = Convert.ToString(drAL_FR["Pedestrian_City"]);
                this._Pedestrian_State = Convert.ToString(drAL_FR["Pedestrian_State"]);
                this._Pedestrian_ZipCode = Convert.ToString(drAL_FR["Pedestrian_ZipCode"]);
                this._Pedestrian_Date_of_Birth = drAL_FR["Pedestrian_Date_of_Birth"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Pedestrian_Date_of_Birth"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Pedestrian_Work_Phone = Convert.ToString(drAL_FR["Pedestrian_Work_Phone"]);
                this._Pedestrian_Home_Phone = Convert.ToString(drAL_FR["Pedestrian_Home_Phone"]);
                this._Pedestrian_Alternate_Phone = Convert.ToString(drAL_FR["Pedestrian_Alternate_Phone"]);
                this._Pedestrian_Taken_By_Emergency_Transportation = drAL_FR["Pedestrian_Taken_By_Emergency_Transportation"] != DBNull.Value ? Convert.ToBoolean(drAL_FR["Pedestrian_Taken_By_Emergency_Transportation"]) : false;
                this._Pedestrian_Medical_Facility_Name = Convert.ToString(drAL_FR["Pedestrian_Medical_Facility_Name"]);
                this._Pedestrian_Medical_Facility_Address_1 = Convert.ToString(drAL_FR["Pedestrian_Medical_Facility_Address_1"]);
                this._Pedestrian_Medical_Facility_Address_2 = Convert.ToString(drAL_FR["Pedestrian_Medical_Facility_Address_2"]);
                this._Pedestrian_Medical_Facility_City = Convert.ToString(drAL_FR["Pedestrian_Medical_Facility_City"]);
                this._Pedestrian_Medical_Facility_State = Convert.ToString(drAL_FR["Pedestrian_Medical_Facility_State"]);
                this._Pedestrian_Medical_Facility_Zip_Code = Convert.ToString(drAL_FR["Pedestrian_Medical_Facility_Zip_Code"]);
                this._Pedestrian_Medical_Facility_Type = Convert.ToString(drAL_FR["Pedestrian_Medical_Facility_Type"]);
                if (drAL_FR["Pedestrian_Airlifted_Medivac"] != DBNull.Value)
                    this._Pedestrian_Airlifted_Medivac = Convert.ToBoolean(drAL_FR["Pedestrian_Airlifted_Medivac"]);
                if (drAL_FR["Pedestrian_Injured"] != DBNull.Value)
                    this._Pedestrian_Injured = Convert.ToBoolean(drAL_FR["Pedestrian_Injured"]);
                this._Pedestrian_Injury_Description = Convert.ToString(drAL_FR["Pedestrian_Injury_Description"]);
                if (drAL_FR["Pedestrian_Sought_Medical_Attention"] != DBNull.Value)
                    this._Pedestrian_Sought_Medical_Attention = Convert.ToBoolean(drAL_FR["Pedestrian_Sought_Medical_Attention"]);
                if (drAL_FR["Pedestrian_Admitted_to_Hospital"] != DBNull.Value)
                    this._Pedestrian_Admitted_to_Hospital = Convert.ToBoolean(drAL_FR["Pedestrian_Admitted_to_Hospital"]);
                this._Pedestrian_Date_Admitted_to_Hospital = drAL_FR["Pedestrian_Date_Admitted_to_Hospital"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Pedestrian_Date_Admitted_to_Hospital"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                if (drAL_FR["Pedestrian_Still_in_Hospital"] != DBNull.Value)
                    this._Pedestrian_Still_in_Hospital = Convert.ToBoolean(drAL_FR["Pedestrian_Still_in_Hospital"]);
                this._Pedestrian_Physicians_Name = Convert.ToString(drAL_FR["Pedestrian_Physicians_Name"]);
                this._Witness_Name = Convert.ToString(drAL_FR["Witness_Name"]);
                this._Witness_Address_1 = Convert.ToString(drAL_FR["Witness_Address_1"]);
                this._Witness_Address_2 = Convert.ToString(drAL_FR["Witness_Address_2"]);
                this._Witness_City = Convert.ToString(drAL_FR["Witness_City"]);
                this._Witness_State = Convert.ToString(drAL_FR["Witness_State"]);
                this._Witness_ZipCode = Convert.ToString(drAL_FR["Witness_ZipCode"]);
                this._Witness_Work_Phone = Convert.ToString(drAL_FR["Witness_Work_Phone"]);
                this._Witness_Home_Phone = Convert.ToString(drAL_FR["Witness_Home_Phone"]);
                this._Witness_Alternate_Phone = Convert.ToString(drAL_FR["Witness_Alternate_Phone"]);
                this._Comments = Convert.ToString(drAL_FR["Comments"]);
                this._Complete = drAL_FR["Complete"] != DBNull.Value ? Convert.ToBoolean(drAL_FR["Complete"]) : false;
                this._FK_Contact = drAL_FR["FK_Contact"] != DBNull.Value ? Convert.ToDecimal(drAL_FR["FK_Contact"]) : 0;
                this._Claimant_state = Convert.ToString(drAL_FR["Claimant_state"]);
                this._FK_LU_Auto_Liability_Type = Convert.ToString(drAL_FR["FK_LU_Auto_Liability_Type"]);
                this._Date_Of_Loss = drAL_FR["Date_Of_Loss"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Date_Of_Loss"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Time_Of_Loss = Convert.ToString(drAL_FR["Time_Of_Loss"]);
                this._Loss_offsite = drAL_FR["Loss_offsite"] != DBNull.Value ? Convert.ToBoolean(drAL_FR["Loss_offsite"]) : false;
                this._Offsite_Address_1 = Convert.ToString(drAL_FR["Offsite_Address_1"]);
                this._Offsite_Address_2 = Convert.ToString(drAL_FR["Offsite_Address_2"]);
                this._Offsite_City = Convert.ToString(drAL_FR["Offsite_City"]);
                this._Offsite_State = Convert.ToString(drAL_FR["Offsite_State"]);
                this._Offsite_zip = Convert.ToString(drAL_FR["Offsite_zip"]);
                this._FK_Loss_Location = drAL_FR["FK_Loss_Location"] != DBNull.Value ? Convert.ToDecimal(drAL_FR["FK_Loss_Location"]) : 0;
                this._Description_Of_Loss = Convert.ToString(drAL_FR["Description_Of_Loss"]);
                this._Date_Reported_To_Sonic = drAL_FR["Date_Reported_To_Sonic"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Date_Reported_To_Sonic"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Weather_Conditions = Convert.ToString(drAL_FR["Weather_Conditions"]);
                this._Road_Conditions = Convert.ToString(drAL_FR["Road_Conditions"]);
                if (drAL_FR["Were_Police_Notified"] != DBNull.Value)
                    this._Were_Police_Notified = Convert.ToBoolean(drAL_FR["Were_Police_Notified"]);
                this._Police_Agency = Convert.ToString(drAL_FR["Police_Agency"]);
                this._Police_Case_Number = Convert.ToString(drAL_FR["Police_Case_Number"]);
                this._Police_Station_Phone_Number = Convert.ToString(drAL_FR["Police_Station_Phone_Number"]);
                if (drAL_FR["Pedestrian_Involved"] != DBNull.Value)
                    this._Pedestrian_Involved = Convert.ToBoolean(drAL_FR["Pedestrian_Involved"]);
                if (drAL_FR["Property_Damage"] != DBNull.Value)
                    this._Property_Damage = Convert.ToBoolean(drAL_FR["Property_Damage"]);
                if (drAL_FR["Witnesses"] != DBNull.Value)
                    this._Witnesses = Convert.ToBoolean(drAL_FR["Witnesses"]);

                if (drAL_FR["Security_Video_System"] != DBNull.Value)
                    this._Security_Video_System = Convert.ToBoolean(drAL_FR["Security_Video_System"]);

                this._Vehicle_Sub_Type = Convert.ToString(drAL_FR["Vehicle_Sub_Type"]);
                this._Vehicle_Fleet_number = Convert.ToString(drAL_FR["Vehicle_Fleet_number"]);
                this._Year = drAL_FR["Year"] != DBNull.Value ? Convert.ToDecimal(drAL_FR["Year"]) : 0;
                this._Make = Convert.ToString(drAL_FR["Make"]);
                this._Model = Convert.ToString(drAL_FR["Model"]);
                this._VIN = Convert.ToString(drAL_FR["VIN"]);
                this._License_Plate_Number = Convert.ToString(drAL_FR["License_Plate_Number"]);
                this._License_Plate_State = Convert.ToString(drAL_FR["License_Plate_State"]);
                this._Vehicle_Color = Convert.ToString(drAL_FR["Vehicle_Color"]);
                if (drAL_FR["Permissive_Use"] != DBNull.Value)
                    this._Permissive_Use = Convert.ToBoolean(drAL_FR["Permissive_Use"]);
                this._Type_Of_Use = Convert.ToString(drAL_FR["Type_Of_Use"]);
                this._Vehicle_Damage_Description = Convert.ToString(drAL_FR["Vehicle_Damage_Description"]);
                this._Repairs_Estimated_Amount = Convert.ToString(drAL_FR["Repairs_Estimated_Amount"]);
                if (drAL_FR["Repairs_Completed"] != DBNull.Value)
                    this._Repairs_Completed = Convert.ToBoolean(drAL_FR["Repairs_Completed"]);
                if (drAL_FR["Drivable"] != DBNull.Value)
                    this._Drivable = Convert.ToBoolean(drAL_FR["Drivable"]);
                if (drAL_FR["Passengers"] != DBNull.Value)
                    this._Passengers = Convert.ToBoolean(drAL_FR["Passengers"]);
                this._Vehicle_Location = Convert.ToString(drAL_FR["Vehicle_Location"]);
                this._Vehicle_Location_Driver_Address_1 = Convert.ToString(drAL_FR["Vehicle_Location_Driver_Address_1"]);
                this._Vehicle_Location_Driver_Address_2 = Convert.ToString(drAL_FR["Vehicle_Location_Driver_Address_2"]);
                this._Vehicle_Location_Driver_City = Convert.ToString(drAL_FR["Vehicle_Location_Driver_City"]);
                this._Vehicle_Location_Driver_State = drAL_FR["Vehicle_Location_Driver_State"] != DBNull.Value ? Convert.ToDecimal(drAL_FR["Vehicle_Location_Driver_State"]) : 0;
                this._Vehicle_Location_Driver_ZipCode = Convert.ToString(drAL_FR["Vehicle_Location_Driver_ZipCode"]);
                if (drAL_FR["Insured_Driver_At_Fault"] != DBNull.Value)
                    this._Insured_Driver_At_Fault = Convert.ToBoolean(drAL_FR["Insured_Driver_At_Fault"]);
                this._Owner_Name = Convert.ToString(drAL_FR["Owner_Name"]);
                this._Owner_Address_1 = Convert.ToString(drAL_FR["Owner_Address_1"]);
                this._Owner_Address_2 = Convert.ToString(drAL_FR["Owner_Address_2"]);
                this._Owner_City = Convert.ToString(drAL_FR["Owner_City"]);
                this._Owner_State = Convert.ToString(drAL_FR["Owner_State"]);
                this._Owner_ZipCode = Convert.ToString(drAL_FR["Owner_ZipCode"]);
                this._Owner_Work_Phone = Convert.ToString(drAL_FR["Owner_Work_Phone"]);
                this._Owner_Home_Phone = Convert.ToString(drAL_FR["Owner_Home_Phone"]);
                this._Owner_Alternate_Phone = Convert.ToString(drAL_FR["Owner_Alternate_Phone"]);
                this._Driver_Name = Convert.ToString(drAL_FR["Driver_Name"]);
                this._Driver_Address_1 = Convert.ToString(drAL_FR["Driver_Address_1"]);
                this._Driver_Address_2 = Convert.ToString(drAL_FR["Driver_Address_2"]);
                this._Driver_City = Convert.ToString(drAL_FR["Driver_City"]);
                this._Driver_State = Convert.ToString(drAL_FR["Driver_State"]);
                this._Driver_ZipCode = Convert.ToString(drAL_FR["Driver_ZipCode"]);
                this._Driver_SSN = Convert.ToString(drAL_FR["Driver_SSN"]);
                this._Driver_Date_of_Birth = drAL_FR["Driver_Date_of_Birth"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Driver_Date_of_Birth"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Driver_Work_Phone = Convert.ToString(drAL_FR["Driver_Work_Phone"]);
                this._Driver_Home_Phone = Convert.ToString(drAL_FR["Driver_Home_Phone"]);
                this._Driver_Altermate_Phone = Convert.ToString(drAL_FR["Driver_Altermate_Phone"]);
                this._Driver_Drivers_License_Number = Convert.ToString(drAL_FR["Driver_Drivers_License_Number"]);
                this._Driver_Drivers_License_State = Convert.ToString(drAL_FR["Driver_Drivers_License_State"]);
                this._Driver_Relation_to_Insured = Convert.ToString(drAL_FR["Driver_Relation_to_Insured"]);
                this._Driver_Taken_By_Emergency_Transportation = drAL_FR["Driver_Taken_By_Emergency_Transportation"] != DBNull.Value ? Convert.ToBoolean(drAL_FR["Driver_Taken_By_Emergency_Transportation"]) : false;
                this._Driver_Medical_Facility_Name = Convert.ToString(drAL_FR["Driver_Medical_Facility_Name"]);
                this._Driver_Medical_Facility_Address_1 = Convert.ToString(drAL_FR["Driver_Medical_Facility_Address_1"]);
                this._Driver_Medical_Facility_Address_2 = Convert.ToString(drAL_FR["Driver_Medical_Facility_Address_2"]);
                this._Driver_Medical_Facility_City = Convert.ToString(drAL_FR["Driver_Medical_Facility_City"]);
                this._Driver_Medical_Facility_State = Convert.ToString(drAL_FR["Driver_Medical_Facility_State"]);
                this._Updated_By = drAL_FR["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drAL_FR["Updated_By"]) : 0;
                this._Updated_Date = drAL_FR["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drAL_FR["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_SLT_Incident_Review = drAL_FR["FK_SLT_Incident_Review"] != DBNull.Value ? Convert.ToDecimal(drAL_FR["FK_SLT_Incident_Review"]) : 0;
            }

            else
            {

                this._PK_AL_FR_ID = -1;
                this._AL_FR_Number = -1;
                this._Driver_Medical_Facility_ZipCode = "";
                this._Driver_Medical_Facility_Type = "";
                this._Driver_Date_Of_Initial_Treatment = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Driver_Treating_Physician_Name = "";
                this._Driver_Airlifted_Medivac = false;
                this._Driver_Admitted_to_Hospital = false;
                this._Driver_Date_Admitted_to_Hospital = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Driver_Still_in_Hospital = false;
                this._Driver_Physicians_Name = "";
                this._Citation_Issued = false;
                this._Citation_Number = "";
                this._Driver_Was_Injured = false;
                this._Driver_Injury_Description = "";
                this._Driver_Sought_Medical_Attention = false;
                this._Driver_Is_Owner = false;
                this._Passenger_Name = "";
                this._Passenger_Address_1 = "";
                this._Passenger_Address_2 = "";
                this._Passenger_City = "";
                this._Passenger_State = "";
                this._Passenger_ZipCode = "";
                this._Passenger_Date_of_Birth = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Passenger_Work_Phone = "";
                this._Passenger_Home_Phone = "";
                this._Passenger_Alternate_Phone = "";
                this._Passenger_Drivers_License_Number = "";
                this._Passenger_Drivers_License_State = "";
                this._Passenger_Was_Injured = false;
                this._Passenger_Sought_Medical_Attention = false;
                this._Passenger_Description_of_Injury = "";
                this._Passenger_Relation_to_Insured = "";
                this._Other_Vehicle_Year = -1;
                this._Other_Vehicle_Make = "";
                this._Other_Vehicle_Model = "";
                this._Other_Vehicle_VIN = "";
                this._Other_Vehicle_License_Plate_Number = "";
                this._Other_Vehicle_License_Plate_State = "";
                this._Other_Vehicle_Vehicle_Color = "";
                this._Other_Vehicle_Insurance_Co_Name = "";
                this._Other_Vehicle_Insurance_Co_Phone = "";
                this._Other_Vehicle_Insurance_Policy_Number = "";
                this._Other_Vehicle_Vehicle_Damage_Description = "";
                this._Other_Vehicle_Repairs_Estimated_Amount = "";
                this._Other_Vehicle_Repairs_Completed = false;
                this._Other_Vehicle_Drivable = false;
                this._Other_Vehicle_Location = "";
                this._Other_Vehicle_Location_Driver_Address_1 = "";
                this._Other_Vehicle_Location_Driver_Address_2 = "";
                this._Other_Vehicle_Location_Driver_City = "";
                this._Other_Vehicle_Location_Driver_State = "";
                this._Other_Vehicle_Location_Driver_ZipCode = "";
                this._Other_Vehicle_Location_Telephone = "";
                this._Other_Vehicle_Owner_Name = "";
                this._Other_Vehicle_Owner_Address_1 = "";
                this._Other_Vehicle_Owner_Address_2 = "";
                this._Other_Vehicle_Owner_City = "";
                this._Other_Vehicle_Owner_State = "";
                this._Other_Vehicle_Owner_ZipCode = "";
                this._Other_Vehicle_Owner_Work_Phone = "";
                this._Other_Vehicle_Owner_Home_Phone = "";
                this._Other_Vehicle_Owner_Alternate_Phone = "";
                this._Other_Driver_Name = "";
                this._Other_Driver_Address_1 = "";
                this._Other_Driver_Address_2 = "";
                this._Other_Driver_City = "";
                this._Other_Driver_State = "";
                this._Other_Driver_ZipCode = "";
                this._Other_Driver_SSN = "";
                this._Other_Driver_Date_of_Birth = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Other_Driver_Work_Phone = "";
                this._Other_Driver_Home_Phone = "";
                this._Other_Driver_Alternate_Phone = "";
                this._Other_Driver_Drivers_License_Number = "";
                this._Other_Driver_Drivers_License_State = "";
                this._Other_Driver_Taken_By_Emergency_Transportation = false;
                this._Other_Driver_Medical_Facility_Name = "";
                this._Other_Driver_Medical_Facility_Address_1 = "";
                this._Other_Driver_Medical_Facility_Address_2 = "";
                this._Other_Driver_Medical_Facility_City = "";
                this._Other_Driver_Medical_Facility_State = "";
                this._Other_Driver_Medical_Facility_Zip_Code = "";
                this._Other_Driver_Medical_Facility_Type = "";
                this._Other_Driver_Airlifted_Medivac = false;
                this._Other_Driver_Citation_Issued = false;
                this._Other_Driver_Citation_Number = "";
                this._Other_Driver_Gender = "";
                this._Other_Driver_Injured = false;
                this._Other_Driver_Injury_Description = "";
                this._Other_Driver_Sought_Medical_Attention = false;
                this._Other_Driver_Admitted_to_Hospital = false;
                this._Other_Driver_Date_Admitted_to_Hospital = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Other_Driver_Still_in_Hospital = false;
                this._Other_Driver_Physicians_Name = "";
                this._Oth_Veh_Pass_Name = "";
                this._Oth_Veh_Pass_Address_1 = "";
                this._Oth_Veh_Pass_Address_2 = "";
                this._Oth_Veh_Pass_City = "";
                this._Oth_Veh_Pass_State = "";
                this._Oth_Veh_Pass_ZipCode = "";
                this._Oth_Veh_Pass_Date_of_Birth = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Oth_Veh_Pass_Work_Phone = "";
                this._Oth_Veh_Pass_Home_Phone = "";
                this._Oth_Veh_Pass_Alternate_Phone = "";
                this._Oth_Veh_Pass_Taken_By_Emergency_Transportation = false;
                this._Oth_Veh_Pass_Medical_Facility_Name = "";
                this._Oth_Veh_Pass_Medical_Facility_Address_1 = "";
                this._Oth_Veh_Pass_Medical_Facility_Address_2 = "";
                this._Oth_Veh_Pass_Medical_Facility_City = "";
                this._Oth_Veh_Pass_Medical_Facility_State = -1;
                this._Oth_Veh_Pass_Medical_Facility_ZipCode = "";
                this._Oth_Veh_Pass_Medical_Facility_Type = "";
                this._Oth_Veh_Pass_Airlifted_Medivac = false;
                this._Oth_Veh_Pass_Injured = false;
                this._Oth_Veh_Pass_Injury_Description = "";
                this._Oth_Veh_Pass_Sought_Medical_Attention = false;
                this._Oth_Veh_Pass_Admitted_to_Hospital = false;
                this._Oth_Veh_Pass_Date_Admitted_to_Hospital = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Oth_Veh_Pass_Still_in_Hospital = false;
                this._Oth_Veh_Pass_Physicians_Name = "";
                this._Pedestrian_Name = "";
                this._Pedestrian_Address_1 = "";
                this._Pedestrian_Address_2 = "";
                this._Pedestrian_City = "";
                this._Pedestrian_State = "";
                this._Pedestrian_ZipCode = "";
                this._Pedestrian_Date_of_Birth = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Pedestrian_Work_Phone = "";
                this._Pedestrian_Home_Phone = "";
                this._Pedestrian_Alternate_Phone = "";
                this._Pedestrian_Taken_By_Emergency_Transportation = false;
                this._Pedestrian_Medical_Facility_Name = "";
                this._Pedestrian_Medical_Facility_Address_1 = "";
                this._Pedestrian_Medical_Facility_Address_2 = "";
                this._Pedestrian_Medical_Facility_City = "";
                this._Pedestrian_Medical_Facility_State = "";
                this._Pedestrian_Medical_Facility_Zip_Code = "";
                this._Pedestrian_Medical_Facility_Type = "";
                this._Pedestrian_Airlifted_Medivac = false;
                this._Pedestrian_Injured = false;
                this._Pedestrian_Injury_Description = "";
                this._Pedestrian_Sought_Medical_Attention = false;
                this._Pedestrian_Admitted_to_Hospital = false;
                this._Pedestrian_Date_Admitted_to_Hospital = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Pedestrian_Still_in_Hospital = false;
                this._Pedestrian_Physicians_Name = "";
                this._Witness_Name = "";
                this._Witness_Address_1 = "";
                this._Witness_Address_2 = "";
                this._Witness_City = "";
                this._Witness_State = "";
                this._Witness_ZipCode = "";
                this._Witness_Work_Phone = "";
                this._Witness_Home_Phone = "";
                this._Witness_Alternate_Phone = "";
                this._Comments = "";
                this._Complete = false;
                this._FK_Contact = -1;
                this._Claimant_state = "";
                this._FK_LU_Auto_Liability_Type = "";
                this._Date_Of_Loss = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Time_Of_Loss = "";
                this._Loss_offsite = false;
                this._Offsite_Address_1 = "";
                this._Offsite_Address_2 = "";
                this._Offsite_City = "";
                this._Offsite_State = "";
                this._Offsite_zip = "";
                this._FK_Loss_Location = -1;
                this._Description_Of_Loss = "";
                this._Date_Reported_To_Sonic = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Weather_Conditions = "";
                this._Road_Conditions = "";
                this._Were_Police_Notified = false;
                this._Police_Agency = "";
                this._Police_Case_Number = "";
                this._Police_Station_Phone_Number = "";
                this._Pedestrian_Involved = false;
                this._Property_Damage = false;
                this._Witnesses = false;
                this._Security_Video_System = false;
                this._Vehicle_Sub_Type = "";
                this._Vehicle_Fleet_number = "";
                this._Year = -1;
                this._Make = "";
                this._Model = "";
                this._VIN = "";
                this._License_Plate_Number = "";
                this._License_Plate_State = "";
                this._Vehicle_Color = "";
                this._Permissive_Use = false;
                this._Type_Of_Use = "";
                this._Vehicle_Damage_Description = "";
                this._Repairs_Estimated_Amount = "";
                this._Repairs_Completed = false;
                this._Drivable = false;
                this._Passengers = false;
                this._Vehicle_Location = "";
                this._Vehicle_Location_Driver_Address_1 = "";
                this._Vehicle_Location_Driver_Address_2 = "";
                this._Vehicle_Location_Driver_City = "";
                this._Vehicle_Location_Driver_State = -1;
                this._Vehicle_Location_Driver_ZipCode = "";
                this._Insured_Driver_At_Fault = false;
                this._Owner_Name = "";
                this._Owner_Address_1 = "";
                this._Owner_Address_2 = "";
                this._Owner_City = "";
                this._Owner_State = "";
                this._Owner_ZipCode = "";
                this._Owner_Work_Phone = "";
                this._Owner_Home_Phone = "";
                this._Owner_Alternate_Phone = "";
                this._Driver_Name = "";
                this._Driver_Address_1 = "";
                this._Driver_Address_2 = "";
                this._Driver_City = "";
                this._Driver_State = "";
                this._Driver_ZipCode = "";
                this._Driver_SSN = "";
                this._Driver_Date_of_Birth = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Driver_Work_Phone = "";
                this._Driver_Home_Phone = "";
                this._Driver_Altermate_Phone = "";
                this._Driver_Drivers_License_Number = "";
                this._Driver_Drivers_License_State = "";
                this._Driver_Relation_to_Insured = "";
                this._Driver_Taken_By_Emergency_Transportation = false;
                this._Driver_Medical_Facility_Name = "";
                this._Driver_Medical_Facility_Address_1 = "";
                this._Driver_Medical_Facility_Address_2 = "";
                this._Driver_Medical_Facility_City = "";
                this._Driver_Medical_Facility_State = "";
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_SLT_Incident_Review = -1;
            }

        }

        #endregion

        #region Methods
        /// <summary>
        /// Inserts a record into the AL_FR table.
        /// </summary>
        /// <returns></returns>
        public void Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AL_FRInsert");

            db.AddInParameter(dbCommand, "PK_AL_FR_ID", DbType.Decimal, this._PK_AL_FR_ID);
            db.AddInParameter(dbCommand, "AL_FR_Number", DbType.Decimal, this._AL_FR_Number);
            db.AddInParameter(dbCommand, "FK_Contact", DbType.Decimal, this._FK_Contact);
            db.AddInParameter(dbCommand, "Claimant_state", DbType.String, this._Claimant_state);
            db.AddInParameter(dbCommand, "FK_LU_Auto_Liability_Type", DbType.String, this._FK_LU_Auto_Liability_Type);
            db.AddInParameter(dbCommand, "Date_Of_Loss", DbType.DateTime, this._Date_Of_Loss);
            db.AddInParameter(dbCommand, "Time_Of_Loss", DbType.String, this._Time_Of_Loss);
            db.AddInParameter(dbCommand, "Loss_offsite", DbType.Boolean, this._Loss_offsite);
            db.AddInParameter(dbCommand, "Offsite_Address_1", DbType.String, this._Offsite_Address_1);
            db.AddInParameter(dbCommand, "Offsite_Address_2", DbType.String, this._Offsite_Address_2);
            db.AddInParameter(dbCommand, "Offsite_City", DbType.String, this._Offsite_City);
            db.AddInParameter(dbCommand, "Offsite_State", DbType.String, this._Offsite_State);
            db.AddInParameter(dbCommand, "Offsite_zip", DbType.String, this._Offsite_zip);
            db.AddInParameter(dbCommand, "FK_Loss_Location", DbType.Decimal, this._FK_Loss_Location);
            db.AddInParameter(dbCommand, "Description_Of_Loss", DbType.String, this._Description_Of_Loss);
            db.AddInParameter(dbCommand, "Date_Reported_To_Sonic", DbType.DateTime, this._Date_Reported_To_Sonic);
            db.AddInParameter(dbCommand, "Weather_Conditions", DbType.String, this._Weather_Conditions);
            db.AddInParameter(dbCommand, "Road_Conditions", DbType.String, this._Road_Conditions);
            if (this._Were_Police_Notified != true && this._Were_Police_Notified != false)
            {
                db.AddInParameter(dbCommand, "Were_Police_Notified", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Were_Police_Notified", DbType.Boolean, this._Were_Police_Notified);
            }

            db.AddInParameter(dbCommand, "Police_Agency", DbType.String, this._Police_Agency);
            db.AddInParameter(dbCommand, "Police_Case_Number", DbType.String, this._Police_Case_Number);
            db.AddInParameter(dbCommand, "Police_Station_Phone_Number", DbType.String, this._Police_Station_Phone_Number);
            if (this._Pedestrian_Involved != true && this._Pedestrian_Involved != false)
            {
                db.AddInParameter(dbCommand, "Pedestrian_Involved", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Pedestrian_Involved", DbType.Boolean, this._Pedestrian_Involved);
            }
            if (this._Property_Damage != true && this._Property_Damage != false)
            {
                db.AddInParameter(dbCommand, "Property_Damage", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Property_Damage", DbType.Boolean, this._Property_Damage);
            }
            if (this._Witnesses != true && this._Witnesses != false)
            {
                db.AddInParameter(dbCommand, "Witnesses", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Witnesses", DbType.Boolean, this._Witnesses);
            }

            db.AddInParameter(dbCommand, "Vehicle_Sub_Type", DbType.String, this._Vehicle_Sub_Type);
            db.AddInParameter(dbCommand, "Vehicle_Fleet_number", DbType.String, this._Vehicle_Fleet_number);
            db.AddInParameter(dbCommand, "Year", DbType.Decimal, this._Year);
            db.AddInParameter(dbCommand, "Make", DbType.String, this._Make);
            db.AddInParameter(dbCommand, "Model", DbType.String, this._Model);
            db.AddInParameter(dbCommand, "VIN", DbType.String, this._VIN);
            db.AddInParameter(dbCommand, "License_Plate_Number", DbType.String, this._License_Plate_Number);
            db.AddInParameter(dbCommand, "License_Plate_State", DbType.String, this._License_Plate_State);
            db.AddInParameter(dbCommand, "Vehicle_Color", DbType.String, this._Vehicle_Color);
            if (this._Permissive_Use != true && this._Permissive_Use != false)
            {
                db.AddInParameter(dbCommand, "Permissive_Use", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Permissive_Use", DbType.Boolean, this._Permissive_Use);
            }

            db.AddInParameter(dbCommand, "Type_Of_Use", DbType.String, this._Type_Of_Use);
            db.AddInParameter(dbCommand, "Vehicle_Damage_Description", DbType.String, this._Vehicle_Damage_Description);
            db.AddInParameter(dbCommand, "Repairs_Estimated_Amount", DbType.String, this._Repairs_Estimated_Amount);
            if (this._Repairs_Completed != true && this._Repairs_Completed != false)
            {
                db.AddInParameter(dbCommand, "Repairs_Completed", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Repairs_Completed", DbType.Boolean, this._Repairs_Completed);
            }

            if (this._Drivable != true && this._Drivable != false)
            {
                db.AddInParameter(dbCommand, "Drivable", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Drivable", DbType.Boolean, this._Drivable);
            }

            if (this._Passengers != true && this._Passengers != false)
            {
                db.AddInParameter(dbCommand, "Passengers", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Passengers", DbType.Boolean, this._Passengers);
            }

            db.AddInParameter(dbCommand, "Vehicle_Location", DbType.String, this._Vehicle_Location);
            db.AddInParameter(dbCommand, "Vehicle_Location_Driver_Address_1", DbType.String, this._Vehicle_Location_Driver_Address_1);
            db.AddInParameter(dbCommand, "Vehicle_Location_Driver_Address_2", DbType.String, this._Vehicle_Location_Driver_Address_2);
            db.AddInParameter(dbCommand, "Vehicle_Location_Driver_City", DbType.String, this._Vehicle_Location_Driver_City);
            db.AddInParameter(dbCommand, "Vehicle_Location_Driver_State", DbType.Decimal, this._Vehicle_Location_Driver_State);
            db.AddInParameter(dbCommand, "Vehicle_Location_Driver_ZipCode", DbType.String, this._Vehicle_Location_Driver_ZipCode);
            if (this._Insured_Driver_At_Fault != true && this._Insured_Driver_At_Fault != false)
            {
                db.AddInParameter(dbCommand, "Insured_Driver_At_Fault", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Insured_Driver_At_Fault", DbType.Boolean, this._Insured_Driver_At_Fault);
            }

            db.AddInParameter(dbCommand, "Owner_Name", DbType.String, this._Owner_Name);
            db.AddInParameter(dbCommand, "Owner_Address_1", DbType.String, this._Owner_Address_1);
            db.AddInParameter(dbCommand, "Owner_Address_2", DbType.String, this._Owner_Address_2);
            db.AddInParameter(dbCommand, "Owner_City", DbType.String, this._Owner_City);
            db.AddInParameter(dbCommand, "Owner_State", DbType.String, this._Owner_State);
            db.AddInParameter(dbCommand, "Owner_ZipCode", DbType.String, this._Owner_ZipCode);
            db.AddInParameter(dbCommand, "Owner_Work_Phone", DbType.String, this._Owner_Work_Phone);
            db.AddInParameter(dbCommand, "Owner_Home_Phone", DbType.String, this._Owner_Home_Phone);
            db.AddInParameter(dbCommand, "Owner_Alternate_Phone", DbType.String, this._Owner_Alternate_Phone);
            db.AddInParameter(dbCommand, "Driver_Name", DbType.String, this._Driver_Name);
            db.AddInParameter(dbCommand, "Driver_Address_1", DbType.String, this._Driver_Address_1);
            db.AddInParameter(dbCommand, "Driver_Address_2", DbType.String, this._Driver_Address_2);
            db.AddInParameter(dbCommand, "Driver_City", DbType.String, this._Driver_City);
            db.AddInParameter(dbCommand, "Driver_State", DbType.String, this._Driver_State);
            db.AddInParameter(dbCommand, "Driver_ZipCode", DbType.String, this._Driver_ZipCode);
            db.AddInParameter(dbCommand, "Driver_SSN", DbType.String, this._Driver_SSN);
            db.AddInParameter(dbCommand, "Driver_Date_of_Birth", DbType.DateTime, this._Driver_Date_of_Birth);
            db.AddInParameter(dbCommand, "Driver_Work_Phone", DbType.String, this._Driver_Work_Phone);
            db.AddInParameter(dbCommand, "Driver_Home_Phone", DbType.String, this._Driver_Home_Phone);
            db.AddInParameter(dbCommand, "Driver_Altermate_Phone", DbType.String, this._Driver_Altermate_Phone);
            db.AddInParameter(dbCommand, "Driver_Drivers_License_Number", DbType.String, this._Driver_Drivers_License_Number);
            db.AddInParameter(dbCommand, "Driver_Drivers_License_State", DbType.String, this._Driver_Drivers_License_State);
            db.AddInParameter(dbCommand, "Driver_Relation_to_Insured", DbType.String, this._Driver_Relation_to_Insured);
            db.AddInParameter(dbCommand, "Driver_Taken_By_Emergency_Transportation", DbType.Boolean, this._Driver_Taken_By_Emergency_Transportation);
            db.AddInParameter(dbCommand, "Driver_Medical_Facility_Name", DbType.String, this._Driver_Medical_Facility_Name);
            db.AddInParameter(dbCommand, "Driver_Medical_Facility_Address_1", DbType.String, this._Driver_Medical_Facility_Address_1);
            db.AddInParameter(dbCommand, "Driver_Medical_Facility_Address_2", DbType.String, this._Driver_Medical_Facility_Address_2);
            db.AddInParameter(dbCommand, "Driver_Medical_Facility_City", DbType.String, this._Driver_Medical_Facility_City);
            db.AddInParameter(dbCommand, "Driver_Medical_Facility_State", DbType.String, this._Driver_Medical_Facility_State);
            db.AddInParameter(dbCommand, "Driver_Medical_Facility_ZipCode", DbType.String, this._Driver_Medical_Facility_ZipCode);
            db.AddInParameter(dbCommand, "Driver_Medical_Facility_Type", DbType.String, this._Driver_Medical_Facility_Type);
            db.AddInParameter(dbCommand, "Driver_Date_Of_Initial_Treatment", DbType.DateTime, this._Driver_Date_Of_Initial_Treatment);
            db.AddInParameter(dbCommand, "Driver_Treating_Physician_Name", DbType.String, this._Driver_Treating_Physician_Name);
            if (this._Driver_Airlifted_Medivac != true && this._Driver_Airlifted_Medivac != false)
            {
                db.AddInParameter(dbCommand, "Driver_Airlifted_Medivac ", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Driver_Airlifted_Medivac ", DbType.Boolean, this._Driver_Airlifted_Medivac);
            }

            if (this._Driver_Admitted_to_Hospital != true && this._Driver_Admitted_to_Hospital != false)
            {
                db.AddInParameter(dbCommand, "Driver_Admitted_to_Hospital", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Driver_Admitted_to_Hospital", DbType.Boolean, this._Driver_Admitted_to_Hospital);
            }

            db.AddInParameter(dbCommand, "Driver_Date_Admitted_to_Hospital", DbType.DateTime, this._Driver_Date_Admitted_to_Hospital);
            if (this._Driver_Still_in_Hospital != true && this._Driver_Still_in_Hospital != false)
            {
                db.AddInParameter(dbCommand, "Driver_Still_in_Hospital", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Driver_Still_in_Hospital", DbType.Boolean, this._Driver_Still_in_Hospital);
            }

            db.AddInParameter(dbCommand, "Driver_Physicians_Name", DbType.String, this._Driver_Physicians_Name);
            if (this._Citation_Issued != true && this._Citation_Issued != false)
            {
                db.AddInParameter(dbCommand, "Citation_Issued", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Citation_Issued", DbType.Boolean, this._Citation_Issued);
            }
            db.AddInParameter(dbCommand, "Citation_Number", DbType.String, this._Citation_Number);
            if (this._Driver_Was_Injured != true && this._Driver_Was_Injured != false)
            {
                db.AddInParameter(dbCommand, "Driver_Was_Injured", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Driver_Was_Injured", DbType.Boolean, this._Driver_Was_Injured);
            }
            db.AddInParameter(dbCommand, "Driver_Injury_Description", DbType.String, this._Driver_Injury_Description);
            if (this._Driver_Sought_Medical_Attention != true && this._Driver_Sought_Medical_Attention != false)
            {
                db.AddInParameter(dbCommand, "Driver_Sought_Medical_Attention", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Driver_Sought_Medical_Attention", DbType.Boolean, this._Driver_Sought_Medical_Attention);
            }
            if (this._Driver_Is_Owner != true && this._Driver_Is_Owner != false)
            {
                db.AddInParameter(dbCommand, "Driver_Is_Owner", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Driver_Is_Owner", DbType.Boolean, this._Driver_Is_Owner);
            }

            db.AddInParameter(dbCommand, "Passenger_Name", DbType.String, this._Passenger_Name);
            db.AddInParameter(dbCommand, "Passenger_Address_1", DbType.String, this._Passenger_Address_1);
            db.AddInParameter(dbCommand, "Passenger_Address_2", DbType.String, this._Passenger_Address_2);
            db.AddInParameter(dbCommand, "Passenger_City", DbType.String, this._Passenger_City);
            db.AddInParameter(dbCommand, "Passenger_State", DbType.String, this._Passenger_State);
            db.AddInParameter(dbCommand, "Passenger_ZipCode", DbType.String, this._Passenger_ZipCode);
            db.AddInParameter(dbCommand, "Passenger_Date_of_Birth", DbType.DateTime, this._Passenger_Date_of_Birth);
            db.AddInParameter(dbCommand, "Passenger_Work_Phone", DbType.String, this._Passenger_Work_Phone);
            db.AddInParameter(dbCommand, "Passenger_Home_Phone", DbType.String, this._Passenger_Home_Phone);
            db.AddInParameter(dbCommand, "Passenger_Alternate_Phone", DbType.String, this._Passenger_Alternate_Phone);
            db.AddInParameter(dbCommand, "Passenger_Drivers_License_Number", DbType.String, this._Passenger_Drivers_License_Number);
            db.AddInParameter(dbCommand, "Passenger_Drivers_License_State", DbType.String, this._Passenger_Drivers_License_State);
            if (this._Passenger_Was_Injured != true && this._Passenger_Was_Injured != false)
            {
                db.AddInParameter(dbCommand, "Passenger_Was_Injured", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Passenger_Was_Injured", DbType.Boolean, this._Passenger_Was_Injured);
            }

            if (this._Passenger_Sought_Medical_Attention != true && this._Passenger_Sought_Medical_Attention != false)
            {
                db.AddInParameter(dbCommand, "Passenger_Sought_Medical_Attention", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Passenger_Sought_Medical_Attention", DbType.Boolean, this._Passenger_Sought_Medical_Attention);
            }

            db.AddInParameter(dbCommand, "Passenger_Description_of_Injury", DbType.String, this._Passenger_Description_of_Injury);
            db.AddInParameter(dbCommand, "Passenger_Relation_to_Insured", DbType.String, this._Passenger_Relation_to_Insured);
            db.AddInParameter(dbCommand, "Other_Vehicle_Year", DbType.Decimal, this._Other_Vehicle_Year);
            db.AddInParameter(dbCommand, "Other_Vehicle_Make", DbType.String, this._Other_Vehicle_Make);
            db.AddInParameter(dbCommand, "Other_Vehicle_Model", DbType.String, this._Other_Vehicle_Model);
            db.AddInParameter(dbCommand, "Other_Vehicle_VIN", DbType.String, this._Other_Vehicle_VIN);
            db.AddInParameter(dbCommand, "Other_Vehicle_License_Plate_Number", DbType.String, this._Other_Vehicle_License_Plate_Number);
            db.AddInParameter(dbCommand, "Other_Vehicle_License_Plate_State", DbType.String, this._Other_Vehicle_License_Plate_State);
            db.AddInParameter(dbCommand, "Other_Vehicle_Vehicle_Color", DbType.String, this._Other_Vehicle_Vehicle_Color);
            db.AddInParameter(dbCommand, "Other_Vehicle_Insurance_Co_Name", DbType.String, this._Other_Vehicle_Insurance_Co_Name);
            db.AddInParameter(dbCommand, "Other_Vehicle_Insurance_Co_Phone", DbType.String, this._Other_Vehicle_Insurance_Co_Phone);
            db.AddInParameter(dbCommand, "Other_Vehicle_Insurance_Policy_Number", DbType.String, this._Other_Vehicle_Insurance_Policy_Number);
            db.AddInParameter(dbCommand, "Other_Vehicle_Vehicle_Damage_Description", DbType.String, this._Other_Vehicle_Vehicle_Damage_Description);
            db.AddInParameter(dbCommand, "Other_Vehicle_Repairs_Estimated_Amount", DbType.String, this._Other_Vehicle_Repairs_Estimated_Amount);
            db.AddInParameter(dbCommand, "Other_Vehicle_Repairs_Completed", DbType.Boolean, this._Other_Vehicle_Repairs_Completed);
            if (this._Other_Vehicle_Drivable != true && this._Other_Vehicle_Drivable != false)
            {
                db.AddInParameter(dbCommand, "Other_Vehicle_Drivable", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Other_Vehicle_Drivable", DbType.Boolean, this._Other_Vehicle_Drivable);
            }
            db.AddInParameter(dbCommand, "Other_Vehicle_Location", DbType.String, this._Other_Vehicle_Location);
            db.AddInParameter(dbCommand, "Other_Vehicle_Location_Driver_Address_1", DbType.String, this._Other_Vehicle_Location_Driver_Address_1);
            db.AddInParameter(dbCommand, "Other_Vehicle_Location_Driver_Address_2", DbType.String, this._Other_Vehicle_Location_Driver_Address_2);
            db.AddInParameter(dbCommand, "Other_Vehicle_Location_Driver_City", DbType.String, this._Other_Vehicle_Location_Driver_City);
            db.AddInParameter(dbCommand, "Other_Vehicle_Location_Driver_State", DbType.String, this._Other_Vehicle_Location_Driver_State);
            db.AddInParameter(dbCommand, "Other_Vehicle_Location_Driver_ZipCode", DbType.String, this._Other_Vehicle_Location_Driver_ZipCode);
            db.AddInParameter(dbCommand, "Other_Vehicle_Location_Telephone", DbType.String, this._Other_Vehicle_Location_Telephone);
            db.AddInParameter(dbCommand, "Other_Vehicle_Owner_Name", DbType.String, this._Other_Vehicle_Owner_Name);
            db.AddInParameter(dbCommand, "Other_Vehicle_Owner_Address_1", DbType.String, this._Other_Vehicle_Owner_Address_1);
            db.AddInParameter(dbCommand, "Other_Vehicle_Owner_Address_2", DbType.String, this._Other_Vehicle_Owner_Address_2);
            db.AddInParameter(dbCommand, "Other_Vehicle_Owner_City", DbType.String, this._Other_Vehicle_Owner_City);
            db.AddInParameter(dbCommand, "Other_Vehicle_Owner_State", DbType.String, this._Other_Vehicle_Owner_State);
            db.AddInParameter(dbCommand, "Other_Vehicle_Owner_ZipCode", DbType.String, this._Other_Vehicle_Owner_ZipCode);
            db.AddInParameter(dbCommand, "Other_Vehicle_Owner_Work_Phone", DbType.String, this._Other_Vehicle_Owner_Work_Phone);
            db.AddInParameter(dbCommand, "Other_Vehicle_Owner_Home_Phone", DbType.String, this._Other_Vehicle_Owner_Home_Phone);
            db.AddInParameter(dbCommand, "Other_Vehicle_Owner_Alternate_Phone", DbType.String, this._Other_Vehicle_Owner_Alternate_Phone);
            db.AddInParameter(dbCommand, "Other_Driver_Name", DbType.String, this._Other_Driver_Name);
            db.AddInParameter(dbCommand, "Other_Driver_Address_1", DbType.String, this._Other_Driver_Address_1);
            db.AddInParameter(dbCommand, "Other_Driver_Address_2", DbType.String, this._Other_Driver_Address_2);
            db.AddInParameter(dbCommand, "Other_Driver_City", DbType.String, this._Other_Driver_City);
            db.AddInParameter(dbCommand, "Other_Driver_State", DbType.String, this._Other_Driver_State);
            db.AddInParameter(dbCommand, "Other_Driver_ZipCode", DbType.String, this._Other_Driver_ZipCode);
            db.AddInParameter(dbCommand, "Other_Driver_SSN", DbType.String, this._Other_Driver_SSN);
            db.AddInParameter(dbCommand, "Other_Driver_Date_of_Birth", DbType.DateTime, this._Other_Driver_Date_of_Birth);
            db.AddInParameter(dbCommand, "Other_Driver_Work_Phone", DbType.String, this._Other_Driver_Work_Phone);
            db.AddInParameter(dbCommand, "Other_Driver_Home_Phone", DbType.String, this._Other_Driver_Home_Phone);
            db.AddInParameter(dbCommand, "Other_Driver_Alternate_Phone", DbType.String, this._Other_Driver_Alternate_Phone);
            db.AddInParameter(dbCommand, "Other_Driver_Drivers_License_Number", DbType.String, this._Other_Driver_Drivers_License_Number);
            db.AddInParameter(dbCommand, "Other_Driver_Drivers_License_State", DbType.String, this._Other_Driver_Drivers_License_State);
            db.AddInParameter(dbCommand, "Other_Driver_Taken_By_Emergency_Transportation", DbType.Boolean, this._Other_Driver_Taken_By_Emergency_Transportation);
            db.AddInParameter(dbCommand, "Other_Driver_Medical_Facility_Name", DbType.String, this._Other_Driver_Medical_Facility_Name);
            db.AddInParameter(dbCommand, "Other_Driver_Medical_Facility_Address_1", DbType.String, this._Other_Driver_Medical_Facility_Address_1);
            db.AddInParameter(dbCommand, "Other_Driver_Medical_Facility_Address_2", DbType.String, this._Other_Driver_Medical_Facility_Address_2);
            db.AddInParameter(dbCommand, "Other_Driver_Medical_Facility_City", DbType.String, this._Other_Driver_Medical_Facility_City);
            db.AddInParameter(dbCommand, "Other_Driver_Medical_Facility_State", DbType.String, this._Other_Driver_Medical_Facility_State);
            db.AddInParameter(dbCommand, "Other_Driver_Medical_Facility_Zip_Code", DbType.String, this._Other_Driver_Medical_Facility_Zip_Code);
            db.AddInParameter(dbCommand, "Other_Driver_Medical_Facility_Type", DbType.String, this._Other_Driver_Medical_Facility_Type);
            if (this._Other_Driver_Airlifted_Medivac != true && this._Other_Driver_Airlifted_Medivac != false)
            {
                db.AddInParameter(dbCommand, "Other_Driver_Airlifted_Medivac ", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Other_Driver_Airlifted_Medivac ", DbType.Boolean, this._Other_Driver_Airlifted_Medivac);
            }

            if (this._Other_Driver_Citation_Issued != true && this._Other_Driver_Citation_Issued != false)
            {
                db.AddInParameter(dbCommand, "Other_Driver_Citation_Issued", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Other_Driver_Citation_Issued", DbType.Boolean, this._Other_Driver_Citation_Issued);
            }


            db.AddInParameter(dbCommand, "Other_Driver_Citation_Number", DbType.String, this._Other_Driver_Citation_Number);
            db.AddInParameter(dbCommand, "Other_Driver_Gender", DbType.String, this._Other_Driver_Gender);
            if (this._Other_Driver_Injured != true && this._Other_Driver_Injured != false)
            {
                db.AddInParameter(dbCommand, "Other_Driver_Injured", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Other_Driver_Injured", DbType.Boolean, this._Other_Driver_Injured);
            }

            db.AddInParameter(dbCommand, "Other_Driver_Injury_Description", DbType.String, this._Other_Driver_Injury_Description);

            if (this._Other_Driver_Sought_Medical_Attention != true && this._Other_Driver_Sought_Medical_Attention != false)
            {
                db.AddInParameter(dbCommand, "Other_Driver_Sought_Medical_Attention", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Other_Driver_Sought_Medical_Attention", DbType.Boolean, this._Other_Driver_Sought_Medical_Attention);
            }

            if (this._Other_Driver_Admitted_to_Hospital != true && this._Other_Driver_Admitted_to_Hospital != false)
            {
                db.AddInParameter(dbCommand, "Other_Driver_Admitted_to_Hospital", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Other_Driver_Admitted_to_Hospital", DbType.Boolean, this._Other_Driver_Admitted_to_Hospital);
            }

            db.AddInParameter(dbCommand, "Other_Driver_Date_Admitted_to_Hospital", DbType.DateTime, this._Other_Driver_Date_Admitted_to_Hospital);
            if (this._Other_Driver_Still_in_Hospital != true && this._Other_Driver_Still_in_Hospital != false)
            {
                db.AddInParameter(dbCommand, "Other_Driver_Still_in_Hospital", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Other_Driver_Still_in_Hospital", DbType.Boolean, this._Other_Driver_Still_in_Hospital);
            }

            db.AddInParameter(dbCommand, "Other_Driver_Physicians_Name", DbType.String, this._Other_Driver_Physicians_Name);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Name", DbType.String, this._Oth_Veh_Pass_Name);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Address_1", DbType.String, this._Oth_Veh_Pass_Address_1);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Address_2", DbType.String, this._Oth_Veh_Pass_Address_2);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_City", DbType.String, this._Oth_Veh_Pass_City);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_State", DbType.String, this._Oth_Veh_Pass_State);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_ZipCode", DbType.String, this._Oth_Veh_Pass_ZipCode);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Date_of_Birth", DbType.DateTime, this._Oth_Veh_Pass_Date_of_Birth);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Work_Phone", DbType.String, this._Oth_Veh_Pass_Work_Phone);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Home_Phone", DbType.String, this._Oth_Veh_Pass_Home_Phone);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Alternate_Phone", DbType.String, this._Oth_Veh_Pass_Alternate_Phone);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Taken_By_Emergency_Transportation", DbType.Boolean, this._Oth_Veh_Pass_Taken_By_Emergency_Transportation);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Medical_Facility_Name", DbType.String, this._Oth_Veh_Pass_Medical_Facility_Name);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Medical_Facility_Address_1", DbType.String, this._Oth_Veh_Pass_Medical_Facility_Address_1);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Medical_Facility_Address_2", DbType.String, this._Oth_Veh_Pass_Medical_Facility_Address_2);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Medical_Facility_City", DbType.String, this._Oth_Veh_Pass_Medical_Facility_City);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Medical_Facility_State", DbType.Decimal, this._Oth_Veh_Pass_Medical_Facility_State);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Medical_Facility_ZipCode", DbType.String, this._Oth_Veh_Pass_Medical_Facility_ZipCode);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Medical_Facility_Type", DbType.String, this._Oth_Veh_Pass_Medical_Facility_Type);
            if (this._Oth_Veh_Pass_Airlifted_Medivac != true && this._Oth_Veh_Pass_Airlifted_Medivac != false)
            {
                db.AddInParameter(dbCommand, "Oth_Veh_Pass_Airlifted_Medivac", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Oth_Veh_Pass_Airlifted_Medivac", DbType.Boolean, this._Oth_Veh_Pass_Airlifted_Medivac);
            }
            if (this._Oth_Veh_Pass_Injured != true && this._Oth_Veh_Pass_Injured != false)
            {
                db.AddInParameter(dbCommand, "Oth_Veh_Pass_Injured", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Oth_Veh_Pass_Injured", DbType.Boolean, this._Oth_Veh_Pass_Injured);
            }

            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Injury_Description", DbType.String, this._Oth_Veh_Pass_Injury_Description);
            if (this._Oth_Veh_Pass_Sought_Medical_Attention != true && this._Oth_Veh_Pass_Sought_Medical_Attention != false)
            {
                db.AddInParameter(dbCommand, "Oth_Veh_Pass_Sought_Medical_Attention", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Oth_Veh_Pass_Sought_Medical_Attention", DbType.Boolean, this._Oth_Veh_Pass_Sought_Medical_Attention);
            }
            if (this._Oth_Veh_Pass_Admitted_to_Hospital != true && this._Oth_Veh_Pass_Admitted_to_Hospital != false)
            {
                db.AddInParameter(dbCommand, "Oth_Veh_Pass_Admitted_to_Hospital", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Oth_Veh_Pass_Admitted_to_Hospital", DbType.Boolean, this._Oth_Veh_Pass_Admitted_to_Hospital);
            }

            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Date_Admitted_to_Hospital", DbType.DateTime, this._Oth_Veh_Pass_Date_Admitted_to_Hospital);
            if (this._Oth_Veh_Pass_Still_in_Hospital != true && this._Oth_Veh_Pass_Still_in_Hospital != false)
            {
                db.AddInParameter(dbCommand, "Oth_Veh_Pass_Still_in_Hospital", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Oth_Veh_Pass_Still_in_Hospital", DbType.Boolean, this._Oth_Veh_Pass_Still_in_Hospital);
            }
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Physicians_Name", DbType.String, this._Oth_Veh_Pass_Physicians_Name);
            db.AddInParameter(dbCommand, "Pedestrian_Name", DbType.String, this._Pedestrian_Name);
            db.AddInParameter(dbCommand, "Pedestrian_Address_1", DbType.String, this._Pedestrian_Address_1);
            db.AddInParameter(dbCommand, "Pedestrian_Address_2", DbType.String, this._Pedestrian_Address_2);
            db.AddInParameter(dbCommand, "Pedestrian_City", DbType.String, this._Pedestrian_City);
            db.AddInParameter(dbCommand, "Pedestrian_State", DbType.String, this._Pedestrian_State);
            db.AddInParameter(dbCommand, "Pedestrian_ZipCode", DbType.String, this._Pedestrian_ZipCode);
            db.AddInParameter(dbCommand, "Pedestrian_Date_of_Birth", DbType.DateTime, this._Pedestrian_Date_of_Birth);
            db.AddInParameter(dbCommand, "Pedestrian_Work_Phone", DbType.String, this._Pedestrian_Work_Phone);
            db.AddInParameter(dbCommand, "Pedestrian_Home_Phone", DbType.String, this._Pedestrian_Home_Phone);
            db.AddInParameter(dbCommand, "Pedestrian_Alternate_Phone", DbType.String, this._Pedestrian_Alternate_Phone);
            db.AddInParameter(dbCommand, "Pedestrian_Taken_By_Emergency_Transportation", DbType.Boolean, this._Pedestrian_Taken_By_Emergency_Transportation);
            db.AddInParameter(dbCommand, "Pedestrian_Medical_Facility_Name", DbType.String, this._Pedestrian_Medical_Facility_Name);
            db.AddInParameter(dbCommand, "Pedestrian_Medical_Facility_Address_1", DbType.String, this._Pedestrian_Medical_Facility_Address_1);
            db.AddInParameter(dbCommand, "Pedestrian_Medical_Facility_Address_2", DbType.String, this._Pedestrian_Medical_Facility_Address_2);
            db.AddInParameter(dbCommand, "Pedestrian_Medical_Facility_City", DbType.String, this._Pedestrian_Medical_Facility_City);
            db.AddInParameter(dbCommand, "Pedestrian_Medical_Facility_State", DbType.String, this._Pedestrian_Medical_Facility_State);
            db.AddInParameter(dbCommand, "Pedestrian_Medical_Facility_Zip_Code", DbType.String, this._Pedestrian_Medical_Facility_Zip_Code);
            db.AddInParameter(dbCommand, "Pedestrian_Medical_Facility_Type", DbType.String, this._Pedestrian_Medical_Facility_Type);
            if (this._Pedestrian_Airlifted_Medivac != true && this._Pedestrian_Airlifted_Medivac != false)
            {
                db.AddInParameter(dbCommand, "Pedestrian_Airlifted_Medivac", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Pedestrian_Airlifted_Medivac", DbType.Boolean, this._Pedestrian_Airlifted_Medivac);
            }
            if (this._Pedestrian_Injured != true && this._Pedestrian_Injured != false)
            {
                db.AddInParameter(dbCommand, "Pedestrian_Injured", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Pedestrian_Injured", DbType.Boolean, this._Pedestrian_Injured);
            }

            db.AddInParameter(dbCommand, "Pedestrian_Injury_Description", DbType.String, this._Pedestrian_Injury_Description);
            if (this._Pedestrian_Sought_Medical_Attention != true && this._Pedestrian_Sought_Medical_Attention != false)
            {
                db.AddInParameter(dbCommand, "Pedestrian_Sought_Medical_Attention", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Pedestrian_Sought_Medical_Attention", DbType.Boolean, this._Pedestrian_Sought_Medical_Attention);
            }
            if (this._Pedestrian_Admitted_to_Hospital != true && this._Pedestrian_Admitted_to_Hospital != false)
            {
                db.AddInParameter(dbCommand, "Pedestrian_Admitted_to_Hospital", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Pedestrian_Admitted_to_Hospital", DbType.Boolean, this._Pedestrian_Admitted_to_Hospital);
            }

            db.AddInParameter(dbCommand, "Pedestrian_Date_Admitted_to_Hospital", DbType.DateTime, this._Pedestrian_Date_Admitted_to_Hospital);
            if (this._Pedestrian_Still_in_Hospital != true && this._Pedestrian_Still_in_Hospital != false)
            {
                db.AddInParameter(dbCommand, "Pedestrian_Still_in_Hospital", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Pedestrian_Still_in_Hospital", DbType.Boolean, this._Pedestrian_Still_in_Hospital);
            }

            db.AddInParameter(dbCommand, "Pedestrian_Physicians_Name", DbType.String, this._Pedestrian_Physicians_Name);
            db.AddInParameter(dbCommand, "Witness_Name", DbType.String, this._Witness_Name);
            db.AddInParameter(dbCommand, "Witness_Address_1", DbType.String, this._Witness_Address_1);
            db.AddInParameter(dbCommand, "Witness_Address_2", DbType.String, this._Witness_Address_2);
            db.AddInParameter(dbCommand, "Witness_City", DbType.String, this._Witness_City);
            db.AddInParameter(dbCommand, "Witness_State", DbType.String, this._Witness_State);
            db.AddInParameter(dbCommand, "Witness_ZipCode", DbType.String, this._Witness_ZipCode);
            db.AddInParameter(dbCommand, "Witness_Work_Phone", DbType.String, this._Witness_Work_Phone);
            db.AddInParameter(dbCommand, "Witness_Home_Phone", DbType.String, this._Witness_Home_Phone);
            db.AddInParameter(dbCommand, "Witness_Alternate_Phone", DbType.String, this._Witness_Alternate_Phone);
            db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
            db.AddInParameter(dbCommand, "Complete", DbType.Boolean, this._Complete);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);
            if (this._Security_Video_System != true && this._Security_Video_System != false)
            {
                db.AddInParameter(dbCommand, "Security_Video_System", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Security_Video_System", DbType.Boolean, this._Security_Video_System);
            }
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the AL_FR table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_AL_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AL_FRSelectByPK");

            db.AddInParameter(dbCommand, "PK_AL_FR_ID", DbType.Decimal, pK_AL_FR_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the AL_FR table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AL_FRSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByAL_FR_Number(decimal aL_FR_Number)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AL_FRSelectByAL_FR_Number");

            db.AddInParameter(dbCommand, "AL_FR_Number", DbType.Decimal, aL_FR_Number);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByPKForClaim(decimal PK_AL_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AL_FRSelectByPKForClaim");

            db.AddInParameter(dbCommand, "PK_AL_FR_ID", DbType.Decimal, PK_AL_FR_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the AL_FR table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AL_FRUpdate");

            db.AddInParameter(dbCommand, "PK_AL_FR_ID", DbType.Decimal, this._PK_AL_FR_ID);
            db.AddInParameter(dbCommand, "AL_FR_Number", DbType.Decimal, this._AL_FR_Number);
            db.AddInParameter(dbCommand, "FK_Contact", DbType.Decimal, this._FK_Contact);
            db.AddInParameter(dbCommand, "Claimant_state", DbType.String, this._Claimant_state);
            db.AddInParameter(dbCommand, "FK_LU_Auto_Liability_Type", DbType.String, this._FK_LU_Auto_Liability_Type);
            db.AddInParameter(dbCommand, "Date_Of_Loss", DbType.DateTime, this._Date_Of_Loss);
            db.AddInParameter(dbCommand, "Time_Of_Loss", DbType.String, this._Time_Of_Loss);
            db.AddInParameter(dbCommand, "Loss_offsite", DbType.Boolean, this._Loss_offsite);
            db.AddInParameter(dbCommand, "Offsite_Address_1", DbType.String, this._Offsite_Address_1);
            db.AddInParameter(dbCommand, "Offsite_Address_2", DbType.String, this._Offsite_Address_2);
            db.AddInParameter(dbCommand, "Offsite_City", DbType.String, this._Offsite_City);
            db.AddInParameter(dbCommand, "Offsite_State", DbType.String, this._Offsite_State);
            db.AddInParameter(dbCommand, "Offsite_zip", DbType.String, this._Offsite_zip);
            db.AddInParameter(dbCommand, "FK_Loss_Location", DbType.Decimal, this._FK_Loss_Location);
            db.AddInParameter(dbCommand, "Description_Of_Loss", DbType.String, this._Description_Of_Loss);
            db.AddInParameter(dbCommand, "Date_Reported_To_Sonic", DbType.DateTime, this._Date_Reported_To_Sonic);
            db.AddInParameter(dbCommand, "Weather_Conditions", DbType.String, this._Weather_Conditions);
            db.AddInParameter(dbCommand, "Road_Conditions", DbType.String, this._Road_Conditions);
            if (this._Were_Police_Notified != true && this._Were_Police_Notified != false)
            {
                db.AddInParameter(dbCommand, "Were_Police_Notified", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Were_Police_Notified", DbType.Boolean, this._Were_Police_Notified);
            }

            db.AddInParameter(dbCommand, "Police_Agency", DbType.String, this._Police_Agency);
            db.AddInParameter(dbCommand, "Police_Case_Number", DbType.String, this._Police_Case_Number);
            db.AddInParameter(dbCommand, "Police_Station_Phone_Number", DbType.String, this._Police_Station_Phone_Number);
            if (this._Pedestrian_Involved != true && this._Pedestrian_Involved != false)
            {
                db.AddInParameter(dbCommand, "Pedestrian_Involved", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Pedestrian_Involved", DbType.Boolean, this._Pedestrian_Involved);
            }
            if (this._Property_Damage != true && this._Property_Damage != false)
            {
                db.AddInParameter(dbCommand, "Property_Damage", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Property_Damage", DbType.Boolean, this._Property_Damage);
            }
            if (this._Witnesses != true && this._Witnesses != false)
            {
                db.AddInParameter(dbCommand, "Witnesses", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Witnesses", DbType.Boolean, this._Witnesses);
            }
            db.AddInParameter(dbCommand, "Vehicle_Sub_Type", DbType.String, this._Vehicle_Sub_Type);
            db.AddInParameter(dbCommand, "Vehicle_Fleet_number", DbType.String, this._Vehicle_Fleet_number);
            db.AddInParameter(dbCommand, "Year", DbType.Decimal, this._Year);
            db.AddInParameter(dbCommand, "Make", DbType.String, this._Make);
            db.AddInParameter(dbCommand, "Model", DbType.String, this._Model);
            db.AddInParameter(dbCommand, "VIN", DbType.String, this._VIN);
            db.AddInParameter(dbCommand, "License_Plate_Number", DbType.String, this._License_Plate_Number);
            db.AddInParameter(dbCommand, "License_Plate_State", DbType.String, this._License_Plate_State);
            db.AddInParameter(dbCommand, "Vehicle_Color", DbType.String, this._Vehicle_Color);
            if (this._Permissive_Use != true && this._Permissive_Use != false)
            {
                db.AddInParameter(dbCommand, "Permissive_Use", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Permissive_Use", DbType.Boolean, this._Permissive_Use);
            }
            db.AddInParameter(dbCommand, "Type_Of_Use", DbType.String, this._Type_Of_Use);
            db.AddInParameter(dbCommand, "Vehicle_Damage_Description", DbType.String, this._Vehicle_Damage_Description);
            db.AddInParameter(dbCommand, "Repairs_Estimated_Amount", DbType.String, this._Repairs_Estimated_Amount);
            if (this._Repairs_Completed != true && this._Repairs_Completed != false)
            {
                db.AddInParameter(dbCommand, "Repairs_Completed", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Repairs_Completed", DbType.Boolean, this._Repairs_Completed);
            }

            if (this._Drivable != true && this._Drivable != false)
            {
                db.AddInParameter(dbCommand, "Drivable", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Drivable", DbType.Boolean, this._Drivable);
            }

            if (this._Passengers != true && this._Passengers != false)
            {
                db.AddInParameter(dbCommand, "Passengers", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Passengers", DbType.Boolean, this._Passengers);
            }
            db.AddInParameter(dbCommand, "Vehicle_Location", DbType.String, this._Vehicle_Location);
            db.AddInParameter(dbCommand, "Vehicle_Location_Driver_Address_1", DbType.String, this._Vehicle_Location_Driver_Address_1);
            db.AddInParameter(dbCommand, "Vehicle_Location_Driver_Address_2", DbType.String, this._Vehicle_Location_Driver_Address_2);
            db.AddInParameter(dbCommand, "Vehicle_Location_Driver_City", DbType.String, this._Vehicle_Location_Driver_City);
            db.AddInParameter(dbCommand, "Vehicle_Location_Driver_State", DbType.Decimal, this._Vehicle_Location_Driver_State);
            db.AddInParameter(dbCommand, "Vehicle_Location_Driver_ZipCode", DbType.String, this._Vehicle_Location_Driver_ZipCode);
            if (this._Insured_Driver_At_Fault != true && this._Insured_Driver_At_Fault != false)
            {
                db.AddInParameter(dbCommand, "Insured_Driver_At_Fault", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Insured_Driver_At_Fault", DbType.Boolean, this._Insured_Driver_At_Fault);
            }

            db.AddInParameter(dbCommand, "Owner_Name", DbType.String, this._Owner_Name);
            db.AddInParameter(dbCommand, "Owner_Address_1", DbType.String, this._Owner_Address_1);
            db.AddInParameter(dbCommand, "Owner_Address_2", DbType.String, this._Owner_Address_2);
            db.AddInParameter(dbCommand, "Owner_City", DbType.String, this._Owner_City);
            db.AddInParameter(dbCommand, "Owner_State", DbType.String, this._Owner_State);
            db.AddInParameter(dbCommand, "Owner_ZipCode", DbType.String, this._Owner_ZipCode);
            db.AddInParameter(dbCommand, "Owner_Work_Phone", DbType.String, this._Owner_Work_Phone);
            db.AddInParameter(dbCommand, "Owner_Home_Phone", DbType.String, this._Owner_Home_Phone);
            db.AddInParameter(dbCommand, "Owner_Alternate_Phone", DbType.String, this._Owner_Alternate_Phone);
            db.AddInParameter(dbCommand, "Driver_Name", DbType.String, this._Driver_Name);
            db.AddInParameter(dbCommand, "Driver_Address_1", DbType.String, this._Driver_Address_1);
            db.AddInParameter(dbCommand, "Driver_Address_2", DbType.String, this._Driver_Address_2);
            db.AddInParameter(dbCommand, "Driver_City", DbType.String, this._Driver_City);
            db.AddInParameter(dbCommand, "Driver_State", DbType.String, this._Driver_State);
            db.AddInParameter(dbCommand, "Driver_ZipCode", DbType.String, this._Driver_ZipCode);
            db.AddInParameter(dbCommand, "Driver_SSN", DbType.String, this._Driver_SSN);
            db.AddInParameter(dbCommand, "Driver_Date_of_Birth", DbType.DateTime, this._Driver_Date_of_Birth);
            db.AddInParameter(dbCommand, "Driver_Work_Phone", DbType.String, this._Driver_Work_Phone);
            db.AddInParameter(dbCommand, "Driver_Home_Phone", DbType.String, this._Driver_Home_Phone);
            db.AddInParameter(dbCommand, "Driver_Altermate_Phone", DbType.String, this._Driver_Altermate_Phone);
            db.AddInParameter(dbCommand, "Driver_Drivers_License_Number", DbType.String, this._Driver_Drivers_License_Number);
            db.AddInParameter(dbCommand, "Driver_Drivers_License_State", DbType.String, this._Driver_Drivers_License_State);
            db.AddInParameter(dbCommand, "Driver_Relation_to_Insured", DbType.String, this._Driver_Relation_to_Insured);
            db.AddInParameter(dbCommand, "Driver_Taken_By_Emergency_Transportation", DbType.Boolean, this._Driver_Taken_By_Emergency_Transportation);
            db.AddInParameter(dbCommand, "Driver_Medical_Facility_Name", DbType.String, this._Driver_Medical_Facility_Name);
            db.AddInParameter(dbCommand, "Driver_Medical_Facility_Address_1", DbType.String, this._Driver_Medical_Facility_Address_1);
            db.AddInParameter(dbCommand, "Driver_Medical_Facility_Address_2", DbType.String, this._Driver_Medical_Facility_Address_2);
            db.AddInParameter(dbCommand, "Driver_Medical_Facility_City", DbType.String, this._Driver_Medical_Facility_City);
            db.AddInParameter(dbCommand, "Driver_Medical_Facility_State", DbType.String, this._Driver_Medical_Facility_State);
            db.AddInParameter(dbCommand, "Driver_Medical_Facility_ZipCode", DbType.String, this._Driver_Medical_Facility_ZipCode);
            db.AddInParameter(dbCommand, "Driver_Medical_Facility_Type", DbType.String, this._Driver_Medical_Facility_Type);
            db.AddInParameter(dbCommand, "Driver_Date_Of_Initial_Treatment", DbType.DateTime, this._Driver_Date_Of_Initial_Treatment);
            db.AddInParameter(dbCommand, "Driver_Treating_Physician_Name", DbType.String, this._Driver_Treating_Physician_Name);
            if (this._Driver_Airlifted_Medivac != true && this._Driver_Airlifted_Medivac != false)
            {
                db.AddInParameter(dbCommand, "Driver_Airlifted_Medivac ", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Driver_Airlifted_Medivac ", DbType.Boolean, this._Driver_Airlifted_Medivac);
            }

            if (this._Driver_Admitted_to_Hospital != true && this._Driver_Admitted_to_Hospital != false)
            {
                db.AddInParameter(dbCommand, "Driver_Admitted_to_Hospital", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Driver_Admitted_to_Hospital", DbType.Boolean, this._Driver_Admitted_to_Hospital);
            }

            db.AddInParameter(dbCommand, "Driver_Date_Admitted_to_Hospital", DbType.DateTime, this._Driver_Date_Admitted_to_Hospital);
            if (this._Driver_Still_in_Hospital != true && this._Driver_Still_in_Hospital != false)
            {
                db.AddInParameter(dbCommand, "Driver_Still_in_Hospital", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Driver_Still_in_Hospital", DbType.Boolean, this._Driver_Still_in_Hospital);
            }

            db.AddInParameter(dbCommand, "Driver_Physicians_Name", DbType.String, this._Driver_Physicians_Name);
            if (this._Citation_Issued != true && this._Citation_Issued != false)
            {
                db.AddInParameter(dbCommand, "Citation_Issued", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Citation_Issued", DbType.Boolean, this._Citation_Issued);
            }
            db.AddInParameter(dbCommand, "Citation_Number", DbType.String, this._Citation_Number);
            if (this._Driver_Was_Injured != true && this._Driver_Was_Injured != false)
            {
                db.AddInParameter(dbCommand, "Driver_Was_Injured", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Driver_Was_Injured", DbType.Boolean, this._Driver_Was_Injured);
            }
            db.AddInParameter(dbCommand, "Driver_Injury_Description", DbType.String, this._Driver_Injury_Description);
            if (this._Driver_Sought_Medical_Attention != true && this._Driver_Sought_Medical_Attention != false)
            {
                db.AddInParameter(dbCommand, "Driver_Sought_Medical_Attention", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Driver_Sought_Medical_Attention", DbType.Boolean, this._Driver_Sought_Medical_Attention);
            }
            if (this._Driver_Is_Owner != true && this._Driver_Is_Owner != false)
            {
                db.AddInParameter(dbCommand, "Driver_Is_Owner", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Driver_Is_Owner", DbType.Boolean, this._Driver_Is_Owner);
            }
            db.AddInParameter(dbCommand, "Passenger_Name", DbType.String, this._Passenger_Name);
            db.AddInParameter(dbCommand, "Passenger_Address_1", DbType.String, this._Passenger_Address_1);
            db.AddInParameter(dbCommand, "Passenger_Address_2", DbType.String, this._Passenger_Address_2);
            db.AddInParameter(dbCommand, "Passenger_City", DbType.String, this._Passenger_City);
            db.AddInParameter(dbCommand, "Passenger_State", DbType.String, this._Passenger_State);
            db.AddInParameter(dbCommand, "Passenger_ZipCode", DbType.String, this._Passenger_ZipCode);
            db.AddInParameter(dbCommand, "Passenger_Date_of_Birth", DbType.DateTime, this._Passenger_Date_of_Birth);
            db.AddInParameter(dbCommand, "Passenger_Work_Phone", DbType.String, this._Passenger_Work_Phone);
            db.AddInParameter(dbCommand, "Passenger_Home_Phone", DbType.String, this._Passenger_Home_Phone);
            db.AddInParameter(dbCommand, "Passenger_Alternate_Phone", DbType.String, this._Passenger_Alternate_Phone);
            db.AddInParameter(dbCommand, "Passenger_Drivers_License_Number", DbType.String, this._Passenger_Drivers_License_Number);
            db.AddInParameter(dbCommand, "Passenger_Drivers_License_State", DbType.String, this._Passenger_Drivers_License_State);
            if (this._Passenger_Was_Injured != true && this._Passenger_Was_Injured != false)
            {
                db.AddInParameter(dbCommand, "Passenger_Was_Injured", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Passenger_Was_Injured", DbType.Boolean, this._Passenger_Was_Injured);
            }

            if (this._Passenger_Sought_Medical_Attention != true && this._Passenger_Sought_Medical_Attention != false)
            {
                db.AddInParameter(dbCommand, "Passenger_Sought_Medical_Attention", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Passenger_Sought_Medical_Attention", DbType.Boolean, this._Passenger_Sought_Medical_Attention);
            }
            db.AddInParameter(dbCommand, "Passenger_Description_of_Injury", DbType.String, this._Passenger_Description_of_Injury);
            db.AddInParameter(dbCommand, "Passenger_Relation_to_Insured", DbType.String, this._Passenger_Relation_to_Insured);
            db.AddInParameter(dbCommand, "Other_Vehicle_Year", DbType.Decimal, this._Other_Vehicle_Year);
            db.AddInParameter(dbCommand, "Other_Vehicle_Make", DbType.String, this._Other_Vehicle_Make);
            db.AddInParameter(dbCommand, "Other_Vehicle_Model", DbType.String, this._Other_Vehicle_Model);
            db.AddInParameter(dbCommand, "Other_Vehicle_VIN", DbType.String, this._Other_Vehicle_VIN);
            db.AddInParameter(dbCommand, "Other_Vehicle_License_Plate_Number", DbType.String, this._Other_Vehicle_License_Plate_Number);
            db.AddInParameter(dbCommand, "Other_Vehicle_License_Plate_State", DbType.String, this._Other_Vehicle_License_Plate_State);
            db.AddInParameter(dbCommand, "Other_Vehicle_Vehicle_Color", DbType.String, this._Other_Vehicle_Vehicle_Color);
            db.AddInParameter(dbCommand, "Other_Vehicle_Insurance_Co_Name", DbType.String, this._Other_Vehicle_Insurance_Co_Name);
            db.AddInParameter(dbCommand, "Other_Vehicle_Insurance_Co_Phone", DbType.String, this._Other_Vehicle_Insurance_Co_Phone);
            db.AddInParameter(dbCommand, "Other_Vehicle_Insurance_Policy_Number", DbType.String, this._Other_Vehicle_Insurance_Policy_Number);
            db.AddInParameter(dbCommand, "Other_Vehicle_Vehicle_Damage_Description", DbType.String, this._Other_Vehicle_Vehicle_Damage_Description);
            db.AddInParameter(dbCommand, "Other_Vehicle_Repairs_Estimated_Amount", DbType.String, this._Other_Vehicle_Repairs_Estimated_Amount);
            db.AddInParameter(dbCommand, "Other_Vehicle_Repairs_Completed", DbType.Boolean, this._Other_Vehicle_Repairs_Completed);
            if (this._Other_Vehicle_Drivable != true && this._Other_Vehicle_Drivable != false)
            {
                db.AddInParameter(dbCommand, "Other_Vehicle_Drivable", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Other_Vehicle_Drivable", DbType.Boolean, this._Other_Vehicle_Drivable);
            }
            db.AddInParameter(dbCommand, "Other_Vehicle_Location", DbType.String, this._Other_Vehicle_Location);
            db.AddInParameter(dbCommand, "Other_Vehicle_Location_Driver_Address_1", DbType.String, this._Other_Vehicle_Location_Driver_Address_1);
            db.AddInParameter(dbCommand, "Other_Vehicle_Location_Driver_Address_2", DbType.String, this._Other_Vehicle_Location_Driver_Address_2);
            db.AddInParameter(dbCommand, "Other_Vehicle_Location_Driver_City", DbType.String, this._Other_Vehicle_Location_Driver_City);
            db.AddInParameter(dbCommand, "Other_Vehicle_Location_Driver_State", DbType.String, this._Other_Vehicle_Location_Driver_State);
            db.AddInParameter(dbCommand, "Other_Vehicle_Location_Driver_ZipCode", DbType.String, this._Other_Vehicle_Location_Driver_ZipCode);
            db.AddInParameter(dbCommand, "Other_Vehicle_Location_Telephone", DbType.String, this._Other_Vehicle_Location_Telephone);
            db.AddInParameter(dbCommand, "Other_Vehicle_Owner_Name", DbType.String, this._Other_Vehicle_Owner_Name);
            db.AddInParameter(dbCommand, "Other_Vehicle_Owner_Address_1", DbType.String, this._Other_Vehicle_Owner_Address_1);
            db.AddInParameter(dbCommand, "Other_Vehicle_Owner_Address_2", DbType.String, this._Other_Vehicle_Owner_Address_2);
            db.AddInParameter(dbCommand, "Other_Vehicle_Owner_City", DbType.String, this._Other_Vehicle_Owner_City);
            db.AddInParameter(dbCommand, "Other_Vehicle_Owner_State", DbType.String, this._Other_Vehicle_Owner_State);
            db.AddInParameter(dbCommand, "Other_Vehicle_Owner_ZipCode", DbType.String, this._Other_Vehicle_Owner_ZipCode);
            db.AddInParameter(dbCommand, "Other_Vehicle_Owner_Work_Phone", DbType.String, this._Other_Vehicle_Owner_Work_Phone);
            db.AddInParameter(dbCommand, "Other_Vehicle_Owner_Home_Phone", DbType.String, this._Other_Vehicle_Owner_Home_Phone);
            db.AddInParameter(dbCommand, "Other_Vehicle_Owner_Alternate_Phone", DbType.String, this._Other_Vehicle_Owner_Alternate_Phone);
            db.AddInParameter(dbCommand, "Other_Driver_Name", DbType.String, this._Other_Driver_Name);
            db.AddInParameter(dbCommand, "Other_Driver_Address_1", DbType.String, this._Other_Driver_Address_1);
            db.AddInParameter(dbCommand, "Other_Driver_Address_2", DbType.String, this._Other_Driver_Address_2);
            db.AddInParameter(dbCommand, "Other_Driver_City", DbType.String, this._Other_Driver_City);
            db.AddInParameter(dbCommand, "Other_Driver_State", DbType.String, this._Other_Driver_State);
            db.AddInParameter(dbCommand, "Other_Driver_ZipCode", DbType.String, this._Other_Driver_ZipCode);
            db.AddInParameter(dbCommand, "Other_Driver_SSN", DbType.String, this._Other_Driver_SSN);
            db.AddInParameter(dbCommand, "Other_Driver_Date_of_Birth", DbType.DateTime, this._Other_Driver_Date_of_Birth);
            db.AddInParameter(dbCommand, "Other_Driver_Work_Phone", DbType.String, this._Other_Driver_Work_Phone);
            db.AddInParameter(dbCommand, "Other_Driver_Home_Phone", DbType.String, this._Other_Driver_Home_Phone);
            db.AddInParameter(dbCommand, "Other_Driver_Alternate_Phone", DbType.String, this._Other_Driver_Alternate_Phone);
            db.AddInParameter(dbCommand, "Other_Driver_Drivers_License_Number", DbType.String, this._Other_Driver_Drivers_License_Number);
            db.AddInParameter(dbCommand, "Other_Driver_Drivers_License_State", DbType.String, this._Other_Driver_Drivers_License_State);
            db.AddInParameter(dbCommand, "Other_Driver_Taken_By_Emergency_Transportation", DbType.Boolean, this._Other_Driver_Taken_By_Emergency_Transportation);
            db.AddInParameter(dbCommand, "Other_Driver_Medical_Facility_Name", DbType.String, this._Other_Driver_Medical_Facility_Name);
            db.AddInParameter(dbCommand, "Other_Driver_Medical_Facility_Address_1", DbType.String, this._Other_Driver_Medical_Facility_Address_1);
            db.AddInParameter(dbCommand, "Other_Driver_Medical_Facility_Address_2", DbType.String, this._Other_Driver_Medical_Facility_Address_2);
            db.AddInParameter(dbCommand, "Other_Driver_Medical_Facility_City", DbType.String, this._Other_Driver_Medical_Facility_City);
            db.AddInParameter(dbCommand, "Other_Driver_Medical_Facility_State", DbType.String, this._Other_Driver_Medical_Facility_State);
            db.AddInParameter(dbCommand, "Other_Driver_Medical_Facility_Zip_Code", DbType.String, this._Other_Driver_Medical_Facility_Zip_Code);
            db.AddInParameter(dbCommand, "Other_Driver_Medical_Facility_Type", DbType.String, this._Other_Driver_Medical_Facility_Type);
            if (this._Other_Driver_Airlifted_Medivac != true && this._Other_Driver_Airlifted_Medivac != false)
            {
                db.AddInParameter(dbCommand, "Other_Driver_Airlifted_Medivac ", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Other_Driver_Airlifted_Medivac ", DbType.Boolean, this._Other_Driver_Airlifted_Medivac);
            }

            if (this._Other_Driver_Citation_Issued != true && this._Other_Driver_Citation_Issued != false)
            {
                db.AddInParameter(dbCommand, "Other_Driver_Citation_Issued", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Other_Driver_Citation_Issued", DbType.Boolean, this._Other_Driver_Citation_Issued);
            }


            db.AddInParameter(dbCommand, "Other_Driver_Citation_Number", DbType.String, this._Other_Driver_Citation_Number);
            db.AddInParameter(dbCommand, "Other_Driver_Gender", DbType.String, this._Other_Driver_Gender);
            if (this._Other_Driver_Injured != true && this._Other_Driver_Injured != false)
            {
                db.AddInParameter(dbCommand, "Other_Driver_Injured", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Other_Driver_Injured", DbType.Boolean, this._Other_Driver_Injured);
            }

            db.AddInParameter(dbCommand, "Other_Driver_Injury_Description", DbType.String, this._Other_Driver_Injury_Description);

            if (this._Other_Driver_Sought_Medical_Attention != true && this._Other_Driver_Sought_Medical_Attention != false)
            {
                db.AddInParameter(dbCommand, "Other_Driver_Sought_Medical_Attention", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Other_Driver_Sought_Medical_Attention", DbType.Boolean, this._Other_Driver_Sought_Medical_Attention);
            }

            if (this._Other_Driver_Admitted_to_Hospital != true && this._Other_Driver_Admitted_to_Hospital != false)
            {
                db.AddInParameter(dbCommand, "Other_Driver_Admitted_to_Hospital", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Other_Driver_Admitted_to_Hospital", DbType.Boolean, this._Other_Driver_Admitted_to_Hospital);
            }

            db.AddInParameter(dbCommand, "Other_Driver_Date_Admitted_to_Hospital", DbType.DateTime, this._Other_Driver_Date_Admitted_to_Hospital);
            if (this._Other_Driver_Still_in_Hospital != true && this._Other_Driver_Still_in_Hospital != false)
            {
                db.AddInParameter(dbCommand, "Other_Driver_Still_in_Hospital", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Other_Driver_Still_in_Hospital", DbType.Boolean, this._Other_Driver_Still_in_Hospital);
            }
            db.AddInParameter(dbCommand, "Other_Driver_Physicians_Name", DbType.String, this._Other_Driver_Physicians_Name);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Name", DbType.String, this._Oth_Veh_Pass_Name);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Address_1", DbType.String, this._Oth_Veh_Pass_Address_1);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Address_2", DbType.String, this._Oth_Veh_Pass_Address_2);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_City", DbType.String, this._Oth_Veh_Pass_City);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_State", DbType.String, this._Oth_Veh_Pass_State);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_ZipCode", DbType.String, this._Oth_Veh_Pass_ZipCode);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Date_of_Birth", DbType.DateTime, this._Oth_Veh_Pass_Date_of_Birth);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Work_Phone", DbType.String, this._Oth_Veh_Pass_Work_Phone);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Home_Phone", DbType.String, this._Oth_Veh_Pass_Home_Phone);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Alternate_Phone", DbType.String, this._Oth_Veh_Pass_Alternate_Phone);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Taken_By_Emergency_Transportation", DbType.Boolean, this._Oth_Veh_Pass_Taken_By_Emergency_Transportation);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Medical_Facility_Name", DbType.String, this._Oth_Veh_Pass_Medical_Facility_Name);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Medical_Facility_Address_1", DbType.String, this._Oth_Veh_Pass_Medical_Facility_Address_1);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Medical_Facility_Address_2", DbType.String, this._Oth_Veh_Pass_Medical_Facility_Address_2);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Medical_Facility_City", DbType.String, this._Oth_Veh_Pass_Medical_Facility_City);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Medical_Facility_State", DbType.Decimal, this._Oth_Veh_Pass_Medical_Facility_State);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Medical_Facility_ZipCode", DbType.String, this._Oth_Veh_Pass_Medical_Facility_ZipCode);
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Medical_Facility_Type", DbType.String, this._Oth_Veh_Pass_Medical_Facility_Type);
            if (this._Oth_Veh_Pass_Airlifted_Medivac != true && this._Oth_Veh_Pass_Airlifted_Medivac != false)
            {
                db.AddInParameter(dbCommand, "Oth_Veh_Pass_Airlifted_Medivac", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Oth_Veh_Pass_Airlifted_Medivac", DbType.Boolean, this._Oth_Veh_Pass_Airlifted_Medivac);
            }
            if (this._Oth_Veh_Pass_Injured != true && this._Oth_Veh_Pass_Injured != false)
            {
                db.AddInParameter(dbCommand, "Oth_Veh_Pass_Injured", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Oth_Veh_Pass_Injured", DbType.Boolean, this._Oth_Veh_Pass_Injured);
            }

            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Injury_Description", DbType.String, this._Oth_Veh_Pass_Injury_Description);
            if (this._Oth_Veh_Pass_Sought_Medical_Attention != true && this._Oth_Veh_Pass_Sought_Medical_Attention != false)
            {
                db.AddInParameter(dbCommand, "Oth_Veh_Pass_Sought_Medical_Attention", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Oth_Veh_Pass_Sought_Medical_Attention", DbType.Boolean, this._Oth_Veh_Pass_Sought_Medical_Attention);
            }
            if (this._Oth_Veh_Pass_Admitted_to_Hospital != true && this._Oth_Veh_Pass_Admitted_to_Hospital != false)
            {
                db.AddInParameter(dbCommand, "Oth_Veh_Pass_Admitted_to_Hospital", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Oth_Veh_Pass_Admitted_to_Hospital", DbType.Boolean, this._Oth_Veh_Pass_Admitted_to_Hospital);
            }

            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Date_Admitted_to_Hospital", DbType.DateTime, this._Oth_Veh_Pass_Date_Admitted_to_Hospital);
            if (this._Oth_Veh_Pass_Still_in_Hospital != true && this._Oth_Veh_Pass_Still_in_Hospital != false)
            {
                db.AddInParameter(dbCommand, "Oth_Veh_Pass_Still_in_Hospital", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Oth_Veh_Pass_Still_in_Hospital", DbType.Boolean, this._Oth_Veh_Pass_Still_in_Hospital);
            }
            db.AddInParameter(dbCommand, "Oth_Veh_Pass_Physicians_Name", DbType.String, this._Oth_Veh_Pass_Physicians_Name);
            db.AddInParameter(dbCommand, "Pedestrian_Name", DbType.String, this._Pedestrian_Name);
            db.AddInParameter(dbCommand, "Pedestrian_Address_1", DbType.String, this._Pedestrian_Address_1);
            db.AddInParameter(dbCommand, "Pedestrian_Address_2", DbType.String, this._Pedestrian_Address_2);
            db.AddInParameter(dbCommand, "Pedestrian_City", DbType.String, this._Pedestrian_City);
            db.AddInParameter(dbCommand, "Pedestrian_State", DbType.String, this._Pedestrian_State);
            db.AddInParameter(dbCommand, "Pedestrian_ZipCode", DbType.String, this._Pedestrian_ZipCode);
            db.AddInParameter(dbCommand, "Pedestrian_Date_of_Birth", DbType.DateTime, this._Pedestrian_Date_of_Birth);
            db.AddInParameter(dbCommand, "Pedestrian_Work_Phone", DbType.String, this._Pedestrian_Work_Phone);
            db.AddInParameter(dbCommand, "Pedestrian_Home_Phone", DbType.String, this._Pedestrian_Home_Phone);
            db.AddInParameter(dbCommand, "Pedestrian_Alternate_Phone", DbType.String, this._Pedestrian_Alternate_Phone);
            db.AddInParameter(dbCommand, "Pedestrian_Taken_By_Emergency_Transportation", DbType.Boolean, this._Pedestrian_Taken_By_Emergency_Transportation);
            db.AddInParameter(dbCommand, "Pedestrian_Medical_Facility_Name", DbType.String, this._Pedestrian_Medical_Facility_Name);
            db.AddInParameter(dbCommand, "Pedestrian_Medical_Facility_Address_1", DbType.String, this._Pedestrian_Medical_Facility_Address_1);
            db.AddInParameter(dbCommand, "Pedestrian_Medical_Facility_Address_2", DbType.String, this._Pedestrian_Medical_Facility_Address_2);
            db.AddInParameter(dbCommand, "Pedestrian_Medical_Facility_City", DbType.String, this._Pedestrian_Medical_Facility_City);
            db.AddInParameter(dbCommand, "Pedestrian_Medical_Facility_State", DbType.String, this._Pedestrian_Medical_Facility_State);
            db.AddInParameter(dbCommand, "Pedestrian_Medical_Facility_Zip_Code", DbType.String, this._Pedestrian_Medical_Facility_Zip_Code);
            db.AddInParameter(dbCommand, "Pedestrian_Medical_Facility_Type", DbType.String, this._Pedestrian_Medical_Facility_Type);
            if (this._Pedestrian_Airlifted_Medivac != true && this._Pedestrian_Airlifted_Medivac != false)
            {
                db.AddInParameter(dbCommand, "Pedestrian_Airlifted_Medivac", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Pedestrian_Airlifted_Medivac", DbType.Boolean, this._Pedestrian_Airlifted_Medivac);
            }
            if (this._Pedestrian_Injured != true && this._Pedestrian_Injured != false)
            {
                db.AddInParameter(dbCommand, "Pedestrian_Injured", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Pedestrian_Injured", DbType.Boolean, this._Pedestrian_Injured);
            }

            db.AddInParameter(dbCommand, "Pedestrian_Injury_Description", DbType.String, this._Pedestrian_Injury_Description);
            if (this._Pedestrian_Sought_Medical_Attention != true && this._Pedestrian_Sought_Medical_Attention != false)
            {
                db.AddInParameter(dbCommand, "Pedestrian_Sought_Medical_Attention", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Pedestrian_Sought_Medical_Attention", DbType.Boolean, this._Pedestrian_Sought_Medical_Attention);
            }
            if (this._Pedestrian_Admitted_to_Hospital != true && this._Pedestrian_Admitted_to_Hospital != false)
            {
                db.AddInParameter(dbCommand, "Pedestrian_Admitted_to_Hospital", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Pedestrian_Admitted_to_Hospital", DbType.Boolean, this._Pedestrian_Admitted_to_Hospital);
            }

            db.AddInParameter(dbCommand, "Pedestrian_Date_Admitted_to_Hospital", DbType.DateTime, this._Pedestrian_Date_Admitted_to_Hospital);
            if (this._Pedestrian_Still_in_Hospital != true && this._Pedestrian_Still_in_Hospital != false)
            {
                db.AddInParameter(dbCommand, "Pedestrian_Still_in_Hospital", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Pedestrian_Still_in_Hospital", DbType.Boolean, this._Pedestrian_Still_in_Hospital);
            }
            db.AddInParameter(dbCommand, "Pedestrian_Physicians_Name", DbType.String, this._Pedestrian_Physicians_Name);
            db.AddInParameter(dbCommand, "Witness_Name", DbType.String, this._Witness_Name);
            db.AddInParameter(dbCommand, "Witness_Address_1", DbType.String, this._Witness_Address_1);
            db.AddInParameter(dbCommand, "Witness_Address_2", DbType.String, this._Witness_Address_2);
            db.AddInParameter(dbCommand, "Witness_City", DbType.String, this._Witness_City);
            db.AddInParameter(dbCommand, "Witness_State", DbType.String, this._Witness_State);
            db.AddInParameter(dbCommand, "Witness_ZipCode", DbType.String, this._Witness_ZipCode);
            db.AddInParameter(dbCommand, "Witness_Work_Phone", DbType.String, this._Witness_Work_Phone);
            db.AddInParameter(dbCommand, "Witness_Home_Phone", DbType.String, this._Witness_Home_Phone);
            db.AddInParameter(dbCommand, "Witness_Alternate_Phone", DbType.String, this._Witness_Alternate_Phone);
            db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
            db.AddInParameter(dbCommand, "Complete", DbType.Boolean, this._Complete);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);
            if (this._Security_Video_System != true && this._Security_Video_System != false)
            {
                db.AddInParameter(dbCommand, "Security_Video_System", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Security_Video_System", DbType.Boolean, this._Security_Video_System);
            }
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the AL_FR table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_AL_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AL_FRDeleteByPK");

            db.AddInParameter(dbCommand, "PK_AL_FR_ID", DbType.Decimal, pK_AL_FR_ID);

            db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
