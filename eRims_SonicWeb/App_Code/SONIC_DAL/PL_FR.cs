using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for PL_FR table.
    /// </summary>
    public sealed class PL_FR
    {
        #region Fields


        private decimal _PK_PL_FR_ID;
        private decimal _PL_FR_Number;
        private string _Owner_Alternate_Telephone;
        private string _Witness_Name;
        private string _Witness_Address_1;
        private string _Witness_Address_2;
        private string _Witness_City;
        private string _Witness_State;
        private string _Witness_Zip_Code;
        private string _Witness_Work_Telephone;
        private string _Witness_Home_Telephone;
        private string _Witness_Alternate_Telephone;
        private string _Comments;
        private bool _Complete;
        private decimal _FK_LU_Location_ID;
        private decimal _FK_Contact;
        private decimal _Claimant_State;
        private DateTime _Date_of_Loss;
        private string _Time_of_Loss;
        private string _Non_Sonic_Loss_Location;
        private string _Description_of_Loss;
        private DateTime _Date_Reported_To_Sonic;
        private string _Weather_Conditions;
        private string _Road_Conditions;
        private Nullable<bool> _Were_Police_Notified;
        private string _Police_Organization;
        private string _Police_telephone;
        private string _Case_Number;
        private Nullable<bool> _Personal_Bodily_Injury;
        private string _Loss_Category;
        private Nullable<bool> _Property_Damage;
        private Nullable<bool> _Witnesses;
        private Nullable<bool> _Product_Involved;
        private string _Type_of_Product;
        private string _Manufacturer_Name;
        private string _Product_Address_1;
        private string _Product_Address_2;
        private string _Product_City;
        private string _Product_State;
        private string _Product_Zip_Code;
        private string _Product_Location;
        private string _Injured_Name;
        private string _Injured_Address_1;
        private string _Injured_Address_2;
        private string _Injured_City;
        private string _Injured_State;
        private string _Injured_ZipCode;
        private string _Injured_Work_Phone;
        private string _Injured_Alternate_Telephone;
        private string _Injured_Home_Phone;
        private string _What_Was_Injured_Doing;
        private string _body_part;
        private string _Injured_Medical_Treatment_Provided;
        private bool _Injured_Taken_By_Emergency_Transportation;
        private string _Injured_Medical_Facility_Name;
        private string _Injured_Medical_Facility_Address_1;
        private string _Injured_Medical_Facility_Address_2;
        private string _Injured_Medical_Facility_City;
        private string _Injured_Medical_Facility_State;
        private string _Injured_Medical_Facility_Zip_Code;
        private string _Injured_Medical_Facility_Type;
        private Nullable<bool> _Injured_Airlifted_Medivac;
        private bool _Injured_Citation_Issued;
        private string _Injured_Citation_Number;
        private string _Injured_Gender;
        private DateTime _Injured_Date_of_Initial_Treatment;
        private string _Injured_Injury_Description;
        private bool _Injured_Sought_Medical_Attention;
        private Nullable<bool> _Injured_Admitted_to_Hospital;
        private DateTime _Injured_Date_Admitted_to_Hospital;
        private Nullable<bool> _Injured_Still_in_Hospital;
        private string _Injured_Physicians_Name;
        private string _Property_Description;
        private string _Property_Damage_Description;
        private Nullable<bool> _Estimate_Available;
        private string _Property_Estimator_Name;
        private string _Property_Business_Name;
        private string _Property_Address_1;
        private string _Property_Address_2;
        private string _Property_City;
        private string _Property_State;
        private string _Property_Zip_Code;
        private string _Location_where_property_can_be_seen;
        private decimal _Estimate_Amount;
        private string _Estimator_Phone;
        private string _Owner_Name;
        private string _Owner_Work_Telephone;
        private string _Owner_Home_Telephone;
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
        /// Gets or sets the PK_PL_FR_ID value.
        /// </summary>
        public decimal PK_PL_FR_ID
        {
            get { return _PK_PL_FR_ID; }
            set { _PK_PL_FR_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the PL_FR_Number value.
        /// </summary>
        public decimal PL_FR_Number
        {
            get { return _PL_FR_Number; }
            set { _PL_FR_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Owner_Alternate_Telephone value.
        /// </summary>
        public string Owner_Alternate_Telephone
        {
            get { return _Owner_Alternate_Telephone; }
            set { _Owner_Alternate_Telephone = value; }
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
        /// Gets or sets the Witness_Zip_Code value.
        /// </summary>
        public string Witness_Zip_Code
        {
            get { return _Witness_Zip_Code; }
            set { _Witness_Zip_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the Witness_Work_Telephone value.
        /// </summary>
        public string Witness_Work_Telephone
        {
            get { return _Witness_Work_Telephone; }
            set { _Witness_Work_Telephone = value; }
        }


        /// <summary> 
        /// Gets or sets the Witness_Home_Telephone value.
        /// </summary>
        public string Witness_Home_Telephone
        {
            get { return _Witness_Home_Telephone; }
            set { _Witness_Home_Telephone = value; }
        }


        /// <summary> 
        /// Gets or sets the Witness_Alternate_Telephone value.
        /// </summary>
        public string Witness_Alternate_Telephone
        {
            get { return _Witness_Alternate_Telephone; }
            set { _Witness_Alternate_Telephone = value; }
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
        /// Gets or sets the FK_LU_Location_ID value.
        /// </summary>
        public decimal FK_LU_Location_ID
        {
            get { return _FK_LU_Location_ID; }
            set { _FK_LU_Location_ID = value; }
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
        /// Gets or sets the Claimant_State value.
        /// </summary>
        public decimal Claimant_State
        {
            get { return _Claimant_State; }
            set { _Claimant_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_of_Loss value.
        /// </summary>
        public DateTime Date_of_Loss
        {
            get { return _Date_of_Loss; }
            set { _Date_of_Loss = value; }
        }


        /// <summary> 
        /// Gets or sets the Time_of_Loss value.
        /// </summary>
        public string Time_of_Loss
        {
            get { return _Time_of_Loss; }
            set { _Time_of_Loss = value; }
        }


        /// <summary> 
        /// Gets or sets the Non_Sonic_Loss_Location value.
        /// </summary>
        public string Non_Sonic_Loss_Location
        {
            get { return _Non_Sonic_Loss_Location; }
            set { _Non_Sonic_Loss_Location = value; }
        }


        /// <summary> 
        /// Gets or sets the Description_of_Loss value.
        /// </summary>
        public string Description_of_Loss
        {
            get { return _Description_of_Loss; }
            set { _Description_of_Loss = value; }
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
        /// Gets or sets the Police_Organization value.
        /// </summary>
        public string Police_Organization
        {
            get { return _Police_Organization; }
            set { _Police_Organization = value; }
        }


        /// <summary> 
        /// Gets or sets the Police_telephone value.
        /// </summary>
        public string Police_telephone
        {
            get { return _Police_telephone; }
            set { _Police_telephone = value; }
        }


        /// <summary> 
        /// Gets or sets the Case_Number value.
        /// </summary>
        public string Case_Number
        {
            get { return _Case_Number; }
            set { _Case_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Personal_Bodily_Injury value.
        /// </summary>
        public Nullable<bool> Personal_Bodily_Injury
        {
            get { return _Personal_Bodily_Injury; }
            set { _Personal_Bodily_Injury = value; }
        }


        /// <summary> 
        /// Gets or sets the Loss_Category value.
        /// </summary>
        public string Loss_Category
        {
            get { return _Loss_Category; }
            set { _Loss_Category = value; }
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
        /// Gets or sets the Product_Involved value.
        /// </summary>
        public Nullable<bool> Product_Involved
        {
            get { return _Product_Involved; }
            set { _Product_Involved = value; }
        }


        /// <summary> 
        /// Gets or sets the Type_of_Product value.
        /// </summary>
        public string Type_of_Product
        {
            get { return _Type_of_Product; }
            set { _Type_of_Product = value; }
        }


        /// <summary> 
        /// Gets or sets the Manufacturer_Name value.
        /// </summary>
        public string Manufacturer_Name
        {
            get { return _Manufacturer_Name; }
            set { _Manufacturer_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Product_Address_1 value.
        /// </summary>
        public string Product_Address_1
        {
            get { return _Product_Address_1; }
            set { _Product_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Product_Address_2 value.
        /// </summary>
        public string Product_Address_2
        {
            get { return _Product_Address_2; }
            set { _Product_Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Product_City value.
        /// </summary>
        public string Product_City
        {
            get { return _Product_City; }
            set { _Product_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Product_State value.
        /// </summary>
        public string Product_State
        {
            get { return _Product_State; }
            set { _Product_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Product_Zip_Code value.
        /// </summary>
        public string Product_Zip_Code
        {
            get { return _Product_Zip_Code; }
            set { _Product_Zip_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the Product_Location value.
        /// </summary>
        public string Product_Location
        {
            get { return _Product_Location; }
            set { _Product_Location = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Name value.
        /// </summary>
        public string Injured_Name
        {
            get { return _Injured_Name; }
            set { _Injured_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Address_1 value.
        /// </summary>
        public string Injured_Address_1
        {
            get { return _Injured_Address_1; }
            set { _Injured_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Address_2 value.
        /// </summary>
        public string Injured_Address_2
        {
            get { return _Injured_Address_2; }
            set { _Injured_Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_City value.
        /// </summary>
        public string Injured_City
        {
            get { return _Injured_City; }
            set { _Injured_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_State value.
        /// </summary>
        public string Injured_State
        {
            get { return _Injured_State; }
            set { _Injured_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_ZipCode value.
        /// </summary>
        public string Injured_ZipCode
        {
            get { return _Injured_ZipCode; }
            set { _Injured_ZipCode = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Work_Phone value.
        /// </summary>
        public string Injured_Work_Phone
        {
            get { return _Injured_Work_Phone; }
            set { _Injured_Work_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Alternate_Telephone value.
        /// </summary>
        public string Injured_Alternate_Telephone
        {
            get { return _Injured_Alternate_Telephone; }
            set { _Injured_Alternate_Telephone = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Home_Phone value.
        /// </summary>
        public string Injured_Home_Phone
        {
            get { return _Injured_Home_Phone; }
            set { _Injured_Home_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the What_Was_Injured_Doing value.
        /// </summary>
        public string What_Was_Injured_Doing
        {
            get { return _What_Was_Injured_Doing; }
            set { _What_Was_Injured_Doing = value; }
        }


        /// <summary> 
        /// Gets or sets the body_part value.
        /// </summary>
        public string body_part
        {
            get { return _body_part; }
            set { _body_part = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Medical_Treatment_Provided value.
        /// </summary>
        public string Injured_Medical_Treatment_Provided
        {
            get { return _Injured_Medical_Treatment_Provided; }
            set { _Injured_Medical_Treatment_Provided = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Taken_By_Emergency_Transportation value.
        /// </summary>
        public bool Injured_Taken_By_Emergency_Transportation
        {
            get { return _Injured_Taken_By_Emergency_Transportation; }
            set { _Injured_Taken_By_Emergency_Transportation = value; }
        }
        /// <summary> 
        /// Gets or sets the Injured_Medical_Facility_Name value.
        /// </summary>
        public string Injured_Medical_Facility_Name
        {
            get { return _Injured_Medical_Facility_Name; }
            set { _Injured_Medical_Facility_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Medical_Facility_Address_1 value.
        /// </summary>
        public string Injured_Medical_Facility_Address_1
        {
            get { return _Injured_Medical_Facility_Address_1; }
            set { _Injured_Medical_Facility_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Medical_Facility_Address_2 value.
        /// </summary>
        public string Injured_Medical_Facility_Address_2
        {
            get { return _Injured_Medical_Facility_Address_2; }
            set { _Injured_Medical_Facility_Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Medical_Facility_City value.
        /// </summary>
        public string Injured_Medical_Facility_City
        {
            get { return _Injured_Medical_Facility_City; }
            set { _Injured_Medical_Facility_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Medical_Facility_State value.
        /// </summary>
        public string Injured_Medical_Facility_State
        {
            get { return _Injured_Medical_Facility_State; }
            set { _Injured_Medical_Facility_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Medical_Facility_Zip_Code value.
        /// </summary>
        public string Injured_Medical_Facility_Zip_Code
        {
            get { return _Injured_Medical_Facility_Zip_Code; }
            set { _Injured_Medical_Facility_Zip_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Medical_Facility_Type value.
        /// </summary>
        public string Injured_Medical_Facility_Type
        {
            get { return _Injured_Medical_Facility_Type; }
            set { _Injured_Medical_Facility_Type = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Airlifted_Medivac value.
        /// </summary>
        public Nullable<bool> Injured_Airlifted_Medivac
        {
            get { return _Injured_Airlifted_Medivac; }
            set { _Injured_Airlifted_Medivac = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Citation_Issued value.
        /// </summary>
        public bool Injured_Citation_Issued
        {
            get { return _Injured_Citation_Issued; }
            set { _Injured_Citation_Issued = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Citation_Number value.
        /// </summary>
        public string Injured_Citation_Number
        {
            get { return _Injured_Citation_Number; }
            set { _Injured_Citation_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Gender value.
        /// </summary>
        public string Injured_Gender
        {
            get { return _Injured_Gender; }
            set { _Injured_Gender = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Date_of_Initial_Treatment value.
        /// </summary>
        public DateTime Injured_Date_of_Initial_Treatment
        {
            get { return _Injured_Date_of_Initial_Treatment; }
            set { _Injured_Date_of_Initial_Treatment = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Injury_Description value.
        /// </summary>
        public string Injured_Injury_Description
        {
            get { return _Injured_Injury_Description; }
            set { _Injured_Injury_Description = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Sought_Medical_Attention value.
        /// </summary>
        public bool Injured_Sought_Medical_Attention
        {
            get { return _Injured_Sought_Medical_Attention; }
            set { _Injured_Sought_Medical_Attention = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Admitted_to_Hospital value.
        /// </summary>
        public Nullable<bool> Injured_Admitted_to_Hospital
        {
            get { return _Injured_Admitted_to_Hospital; }
            set { _Injured_Admitted_to_Hospital = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Date_Admitted_to_Hospital value.
        /// </summary>
        public DateTime Injured_Date_Admitted_to_Hospital
        {
            get { return _Injured_Date_Admitted_to_Hospital; }
            set { _Injured_Date_Admitted_to_Hospital = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Still_in_Hospital value.
        /// </summary>
        public Nullable<bool> Injured_Still_in_Hospital
        {
            get { return _Injured_Still_in_Hospital; }
            set { _Injured_Still_in_Hospital = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Physicians_Name value.
        /// </summary>
        public string Injured_Physicians_Name
        {
            get { return _Injured_Physicians_Name; }
            set { _Injured_Physicians_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Description value.
        /// </summary>
        public string Property_Description
        {
            get { return _Property_Description; }
            set { _Property_Description = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Damage_Description value.
        /// </summary>
        public string Property_Damage_Description
        {
            get { return _Property_Damage_Description; }
            set { _Property_Damage_Description = value; }
        }


        /// <summary> 
        /// Gets or sets the Estimate_Available value.
        /// </summary>
        public Nullable<bool> Estimate_Available
        {
            get { return _Estimate_Available; }
            set { _Estimate_Available = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Estimator_Name value.
        /// </summary>
        public string Property_Estimator_Name
        {
            get { return _Property_Estimator_Name; }
            set { _Property_Estimator_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Business_Name value.
        /// </summary>
        public string Property_Business_Name
        {
            get { return _Property_Business_Name; }
            set { _Property_Business_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Address_1 value.
        /// </summary>
        public string Property_Address_1
        {
            get { return _Property_Address_1; }
            set { _Property_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Address_2 value.
        /// </summary>
        public string Property_Address_2
        {
            get { return _Property_Address_2; }
            set { _Property_Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_City value.
        /// </summary>
        public string Property_City
        {
            get { return _Property_City; }
            set { _Property_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_State value.
        /// </summary>
        public string Property_State
        {
            get { return _Property_State; }
            set { _Property_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Zip_Code value.
        /// </summary>
        public string Property_Zip_Code
        {
            get { return _Property_Zip_Code; }
            set { _Property_Zip_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the Location_where_property_can_be_seen value.
        /// </summary>
        public string Location_where_property_can_be_seen
        {
            get { return _Location_where_property_can_be_seen; }
            set { _Location_where_property_can_be_seen = value; }
        }
        /// <summary> 
        /// Gets or sets the Estimate_Amount value.
        /// </summary>
        public decimal Estimate_Amount
        {
            get { return _Estimate_Amount; }
            set { _Estimate_Amount = value; }
        }


        /// <summary> 
        /// Gets or sets the Estimator_Phone value.
        /// </summary>
        public string Estimator_Phone
        {
            get { return _Estimator_Phone; }
            set { _Estimator_Phone = value; }
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
        /// Gets or sets the Owner_Work_Telephone value.
        /// </summary>
        public string Owner_Work_Telephone
        {
            get { return _Owner_Work_Telephone; }
            set { _Owner_Work_Telephone = value; }
        }


        /// <summary> 
        /// Gets or sets the Owner_Home_Telephone value.
        /// </summary>
        public string Owner_Home_Telephone
        {
            get { return _Owner_Home_Telephone; }
            set { _Owner_Home_Telephone = value; }
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

        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the PL_FR class. with the default value.

        /// </summary>
        public PL_FR()
        {

            this._PK_PL_FR_ID = -1;
            this._PL_FR_Number = -1;
            this._Owner_Alternate_Telephone = "";
            this._Witness_Name = "";
            this._Witness_Address_1 = "";
            this._Witness_Address_2 = "";
            this._Witness_City = "";
            this._Witness_State = "";
            this._Witness_Zip_Code = "";
            this._Witness_Work_Telephone = "";
            this._Witness_Home_Telephone = "";
            this._Witness_Alternate_Telephone = "";
            this._Comments = "";
            this._Complete = false;
            this._FK_LU_Location_ID = -1;
            this._FK_Contact = -1;
            this._Claimant_State = -1;
            this._Date_of_Loss = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Time_of_Loss = "";
            this._Non_Sonic_Loss_Location = "";
            this._Description_of_Loss = "";
            this._Date_Reported_To_Sonic = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Weather_Conditions = "";
            this._Road_Conditions = "";
            this._Were_Police_Notified = false;
            this._Police_Organization = "";
            this._Police_telephone = "";
            this._Case_Number = "";
            this._Personal_Bodily_Injury = false;
            this._Loss_Category = "";
            this._Property_Damage = false;
            this._Witnesses = false;
            this._Product_Involved = false;
            this._Type_of_Product = "";
            this._Manufacturer_Name = "";
            this._Product_Address_1 = "";
            this._Product_Address_2 = "";
            this._Product_City = "";
            this._Product_State = "";
            this._Product_Zip_Code = "";
            this._Product_Location = "";
            this._Injured_Name = "";
            this._Injured_Address_1 = "";
            this._Injured_Address_2 = "";
            this._Injured_City = "";
            this._Injured_State = "";
            this._Injured_ZipCode = "";
            this._Injured_Work_Phone = "";
            this._Injured_Alternate_Telephone = "";
            this._Injured_Home_Phone = "";
            this._What_Was_Injured_Doing = "";
            this._body_part = "";
            this._Injured_Medical_Treatment_Provided = "";
            this._Injured_Taken_By_Emergency_Transportation = false;
            this._Injured_Medical_Facility_Name = "";
            this._Injured_Medical_Facility_Address_1 = "";
            this._Injured_Medical_Facility_Address_2 = "";
            this._Injured_Medical_Facility_City = "";
            this._Injured_Medical_Facility_State = "";
            this._Injured_Medical_Facility_Zip_Code = "";
            this._Injured_Medical_Facility_Type = "";
            this._Injured_Airlifted_Medivac = false;
            this._Injured_Citation_Issued = false;
            this._Injured_Citation_Number = "";
            this._Injured_Gender = "";
            this._Injured_Date_of_Initial_Treatment = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Injured_Injury_Description = "";
            this._Injured_Sought_Medical_Attention = false;
            this._Injured_Admitted_to_Hospital = false;
            this._Injured_Date_Admitted_to_Hospital = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Injured_Still_in_Hospital = false;
            this._Injured_Physicians_Name = "";
            this._Property_Description = "";
            this._Property_Damage_Description = "";
            this._Estimate_Available = false;
            this._Property_Estimator_Name = "";
            this._Property_Business_Name = "";
            this._Property_Address_1 = "";
            this._Property_Address_2 = "";
            this._Property_City = "";
            this._Property_State = "";
            this._Property_Zip_Code = "";
            this._Location_where_property_can_be_seen = "";
            this._Estimate_Amount = -1;
            this._Estimator_Phone = "";
            this._Owner_Name = "";
            this._Owner_Work_Telephone = "";
            this._Owner_Home_Telephone = "";
            this._Updated_By = -1;
            this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Security_Video_System = false;
            this._FK_SLT_Incident_Review = -1;
        }



        /// <summary> 

        /// Initializes a new instance of the PL_FR class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public PL_FR(decimal PK)
        {

            DataTable dtPL_FR = SelectByPK(PK).Tables[0];

            if (dtPL_FR.Rows.Count > 0)
            {

                DataRow drPL_FR = dtPL_FR.Rows[0];

                this._PK_PL_FR_ID = drPL_FR["PK_PL_FR_ID"] != DBNull.Value ? Convert.ToDecimal(drPL_FR["PK_PL_FR_ID"]) : 0;
                this._PL_FR_Number = drPL_FR["PL_FR_Number"] != DBNull.Value ? Convert.ToDecimal(drPL_FR["PL_FR_Number"]) : 0;
                this._Owner_Alternate_Telephone = Convert.ToString(drPL_FR["Owner_Alternate_Telephone"]);
                this._Witness_Name = Convert.ToString(drPL_FR["Witness_Name"]);
                this._Witness_Address_1 = Convert.ToString(drPL_FR["Witness_Address_1"]);
                this._Witness_Address_2 = Convert.ToString(drPL_FR["Witness_Address_2"]);
                this._Witness_City = Convert.ToString(drPL_FR["Witness_City"]);
                this._Witness_State = Convert.ToString(drPL_FR["Witness_State"]);
                this._Witness_Zip_Code = Convert.ToString(drPL_FR["Witness_Zip_Code"]);
                this._Witness_Work_Telephone = Convert.ToString(drPL_FR["Witness_Work_Telephone"]);
                this._Witness_Home_Telephone = Convert.ToString(drPL_FR["Witness_Home_Telephone"]);
                this._Witness_Alternate_Telephone = Convert.ToString(drPL_FR["Witness_Alternate_Telephone"]);
                this._Comments = Convert.ToString(drPL_FR["Comments"]);
                this._Complete = drPL_FR["Complete"] != DBNull.Value ? Convert.ToBoolean(drPL_FR["Complete"]) : false;
                this._FK_LU_Location_ID = drPL_FR["FK_LU_Location_ID"] != DBNull.Value ? Convert.ToDecimal(drPL_FR["FK_LU_Location_ID"]) : 0;
                this._FK_Contact = drPL_FR["FK_Contact"] != DBNull.Value ? Convert.ToDecimal(drPL_FR["FK_Contact"]) : 0;
                this._Claimant_State = drPL_FR["Claimant_State"] != DBNull.Value ? Convert.ToDecimal(drPL_FR["Claimant_State"]) : 0;
                this._Date_of_Loss = drPL_FR["Date_of_Loss"] != DBNull.Value ? Convert.ToDateTime(drPL_FR["Date_of_Loss"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Time_of_Loss = Convert.ToString(drPL_FR["Time_of_Loss"]);
                this._Non_Sonic_Loss_Location = Convert.ToString(drPL_FR["Non_Sonic_Loss_Location"]);
                this._Description_of_Loss = Convert.ToString(drPL_FR["Description_of_Loss"]);
                this._Date_Reported_To_Sonic = drPL_FR["Date_Reported_To_Sonic"] != DBNull.Value ? Convert.ToDateTime(drPL_FR["Date_Reported_To_Sonic"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Weather_Conditions = Convert.ToString(drPL_FR["Weather_Conditions"]);
                this._Road_Conditions = Convert.ToString(drPL_FR["Road_Conditions"]);
                if (drPL_FR["Were_Police_Notified"] != DBNull.Value)
                    this._Were_Police_Notified = Convert.ToBoolean(drPL_FR["Were_Police_Notified"]);
                this._Police_Organization = Convert.ToString(drPL_FR["Police_Organization"]);
                this._Police_telephone = Convert.ToString(drPL_FR["Police_telephone"]);
                this._Case_Number = Convert.ToString(drPL_FR["Case_Number"]);
                if (drPL_FR["Personal_Bodily_Injury"] != DBNull.Value)
                    this._Personal_Bodily_Injury = Convert.ToBoolean(drPL_FR["Personal_Bodily_Injury"]);
                this._Loss_Category = Convert.ToString(drPL_FR["Loss_Category"]);
                if (drPL_FR["Property_Damage"] != DBNull.Value)
                    this._Property_Damage = Convert.ToBoolean(drPL_FR["Property_Damage"]);
                if (drPL_FR["Witnesses"] != DBNull.Value)
                    this._Witnesses = Convert.ToBoolean(drPL_FR["Witnesses"]);
                if (drPL_FR["Product_Involved"] != DBNull.Value)
                    this._Product_Involved = Convert.ToBoolean(drPL_FR["Product_Involved"]);
                this._Type_of_Product = Convert.ToString(drPL_FR["Type_of_Product"]);
                this._Manufacturer_Name = Convert.ToString(drPL_FR["Manufacturer_Name"]);
                this._Product_Address_1 = Convert.ToString(drPL_FR["Product_Address_1"]);
                this._Product_Address_2 = Convert.ToString(drPL_FR["Product_Address_2"]);
                this._Product_City = Convert.ToString(drPL_FR["Product_City"]);
                this._Product_State = Convert.ToString(drPL_FR["Product_State"]);
                this._Product_Zip_Code = Convert.ToString(drPL_FR["Product_Zip_Code"]);
                this._Product_Location = Convert.ToString(drPL_FR["Product_Location"]);
                this._Injured_Name = Convert.ToString(drPL_FR["Injured_Name"]);
                this._Injured_Address_1 = Convert.ToString(drPL_FR["Injured_Address_1"]);
                this._Injured_Address_2 = Convert.ToString(drPL_FR["Injured_Address_2"]);
                this._Injured_City = Convert.ToString(drPL_FR["Injured_City"]);
                this._Injured_State = Convert.ToString(drPL_FR["Injured_State"]);
                this._Injured_ZipCode = Convert.ToString(drPL_FR["Injured_ZipCode"]);
                this._Injured_Work_Phone = Convert.ToString(drPL_FR["Injured_Work_Phone"]);
                this._Injured_Alternate_Telephone = Convert.ToString(drPL_FR["Injured_Alternate_Telephone"]);
                this._Injured_Home_Phone = Convert.ToString(drPL_FR["Injured_Home_Phone"]);
                this._What_Was_Injured_Doing = Convert.ToString(drPL_FR["What_Was_Injured_Doing"]);
                this._body_part = Convert.ToString(drPL_FR["body_part"]);
                this._Injured_Medical_Treatment_Provided = Convert.ToString(drPL_FR["Injured_Medical_Treatment_Provided"]);
                this._Injured_Taken_By_Emergency_Transportation = drPL_FR["Injured_Taken_By_Emergency_Transportation"] != DBNull.Value ? Convert.ToBoolean(drPL_FR["Injured_Taken_By_Emergency_Transportation"]) : false;
                this._Injured_Medical_Facility_Name = Convert.ToString(drPL_FR["Injured_Medical_Facility_Name"]);
                this._Injured_Medical_Facility_Address_1 = Convert.ToString(drPL_FR["Injured_Medical_Facility_Address_1"]);
                this._Injured_Medical_Facility_Address_2 = Convert.ToString(drPL_FR["Injured_Medical_Facility_Address_2"]);
                this._Injured_Medical_Facility_City = Convert.ToString(drPL_FR["Injured_Medical_Facility_City"]);
                this._Injured_Medical_Facility_State = Convert.ToString(drPL_FR["Injured_Medical_Facility_State"]);
                this._Injured_Medical_Facility_Zip_Code = Convert.ToString(drPL_FR["Injured_Medical_Facility_Zip_Code"]);
                this._Injured_Medical_Facility_Type = Convert.ToString(drPL_FR["Injured_Medical_Facility_Type"]);
                if (drPL_FR["Injured_Airlifted_Medivac"] != DBNull.Value)
                    this._Injured_Airlifted_Medivac = Convert.ToBoolean(drPL_FR["Injured_Airlifted_Medivac"]);

                this._Injured_Citation_Issued = drPL_FR["Injured_Citation_Issued"] != DBNull.Value ? Convert.ToBoolean(drPL_FR["Injured_Citation_Issued"]) : false;
                this._Injured_Citation_Number = Convert.ToString(drPL_FR["Injured_Citation_Number"]);
                this._Injured_Gender = Convert.ToString(drPL_FR["Injured_Gender"]);
                this._Injured_Date_of_Initial_Treatment = drPL_FR["Injured_Date_of_Initial_Treatment"] != DBNull.Value ? Convert.ToDateTime(drPL_FR["Injured_Date_of_Initial_Treatment"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Injured_Injury_Description = Convert.ToString(drPL_FR["Injured_Injury_Description"]);
                this._Injured_Sought_Medical_Attention = drPL_FR["Injured_Sought_Medical_Attention"] != DBNull.Value ? Convert.ToBoolean(drPL_FR["Injured_Sought_Medical_Attention"]) : false;
                if (drPL_FR["Injured_Admitted_to_Hospital"] != DBNull.Value)
                    this._Injured_Admitted_to_Hospital = Convert.ToBoolean(drPL_FR["Injured_Admitted_to_Hospital"]);

                this._Injured_Date_Admitted_to_Hospital = drPL_FR["Injured_Date_Admitted_to_Hospital"] != DBNull.Value ? Convert.ToDateTime(drPL_FR["Injured_Date_Admitted_to_Hospital"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                if (drPL_FR["Injured_Still_in_Hospital"] != DBNull.Value)
                    this._Injured_Still_in_Hospital = Convert.ToBoolean(drPL_FR["Injured_Still_in_Hospital"]);

                this._Injured_Physicians_Name = Convert.ToString(drPL_FR["Injured_Physicians_Name"]);
                this._Property_Description = Convert.ToString(drPL_FR["Property_Description"]);
                this._Property_Damage_Description = Convert.ToString(drPL_FR["Property_Damage_Description"]);
                if (drPL_FR["Estimate_Available"] != DBNull.Value)
                    this._Estimate_Available = Convert.ToBoolean(drPL_FR["Estimate_Available"]);
                this._Property_Estimator_Name = Convert.ToString(drPL_FR["Property_Estimator_Name"]);
                this._Property_Business_Name = Convert.ToString(drPL_FR["Property_Business_Name"]);
                this._Property_Address_1 = Convert.ToString(drPL_FR["Property_Address_1"]);
                this._Property_Address_2 = Convert.ToString(drPL_FR["Property_Address_2"]);
                this._Property_City = Convert.ToString(drPL_FR["Property_City"]);
                this._Property_State = Convert.ToString(drPL_FR["Property_State"]);
                this._Property_Zip_Code = Convert.ToString(drPL_FR["Property_Zip_Code"]);
                this._Location_where_property_can_be_seen = Convert.ToString(drPL_FR["Location_where_property_can_be_seen"]);
                this._Estimate_Amount = drPL_FR["Estimate_Amount"] != DBNull.Value ? Convert.ToDecimal(drPL_FR["Estimate_Amount"]) : 0;
                this._Estimator_Phone = Convert.ToString(drPL_FR["Estimator_Phone"]);
                this._Owner_Name = Convert.ToString(drPL_FR["Owner_Name"]);
                this._Owner_Work_Telephone = Convert.ToString(drPL_FR["Owner_Work_Telephone"]);
                this._Owner_Home_Telephone = Convert.ToString(drPL_FR["Owner_Home_Telephone"]);
                this._Updated_By = drPL_FR["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drPL_FR["Updated_By"]) : 0;
                this._Updated_Date = drPL_FR["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drPL_FR["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                if (drPL_FR["Security_Video_System"] != DBNull.Value)
                    this._Security_Video_System = Convert.ToBoolean(drPL_FR["Security_Video_System"]);
                this._FK_SLT_Incident_Review = drPL_FR["FK_SLT_Incident_Review"] != DBNull.Value ? Convert.ToDecimal(drPL_FR["FK_SLT_Incident_Review"]) : 0;
            }

            else
            {

                this._PK_PL_FR_ID = -1;
                this._PL_FR_Number = -1;
                this._Owner_Alternate_Telephone = "";
                this._Witness_Name = "";
                this._Witness_Address_1 = "";
                this._Witness_Address_2 = "";
                this._Witness_City = "";
                this._Witness_State = "";
                this._Witness_Zip_Code = "";
                this._Witness_Work_Telephone = "";
                this._Witness_Home_Telephone = "";
                this._Witness_Alternate_Telephone = "";
                this._Comments = "";
                this._Complete = false;
                this._FK_LU_Location_ID = -1;
                this._FK_Contact = -1;
                this._Claimant_State = -1;
                this._Date_of_Loss = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Time_of_Loss = "";
                this._Non_Sonic_Loss_Location = "";
                this._Description_of_Loss = "";
                this._Date_Reported_To_Sonic = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Weather_Conditions = "";
                this._Road_Conditions = "";
                this._Were_Police_Notified = false;
                this._Police_Organization = "";
                this._Police_telephone = "";
                this._Case_Number = "";
                this._Personal_Bodily_Injury = false;
                this._Loss_Category = "";
                this._Property_Damage = false;
                this._Witnesses = false;
                this._Product_Involved = false;
                this._Type_of_Product = "";
                this._Manufacturer_Name = "";
                this._Product_Address_1 = "";
                this._Product_Address_2 = "";
                this._Product_City = "";
                this._Product_State = "";
                this._Product_Zip_Code = "";
                this._Product_Location = "";
                this._Injured_Name = "";
                this._Injured_Address_1 = "";
                this._Injured_Address_2 = "";
                this._Injured_City = "";
                this._Injured_State = "";
                this._Injured_ZipCode = "";
                this._Injured_Work_Phone = "";
                this._Injured_Alternate_Telephone = "";
                this._Injured_Home_Phone = "";
                this._What_Was_Injured_Doing = "";
                this._body_part = "";
                this._Injured_Medical_Treatment_Provided = "";
                this._Injured_Taken_By_Emergency_Transportation = false;
                this._Injured_Medical_Facility_Name = "";
                this._Injured_Medical_Facility_Address_1 = "";
                this._Injured_Medical_Facility_Address_2 = "";
                this._Injured_Medical_Facility_City = "";
                this._Injured_Medical_Facility_State = "";
                this._Injured_Medical_Facility_Zip_Code = "";
                this._Injured_Medical_Facility_Type = "";
                this._Injured_Airlifted_Medivac = false;
                this._Injured_Citation_Issued = false;
                this._Injured_Citation_Number = "";
                this._Injured_Gender = "";
                this._Injured_Date_of_Initial_Treatment = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Injured_Injury_Description = "";
                this._Injured_Sought_Medical_Attention = false;
                this._Injured_Admitted_to_Hospital = false;
                this._Injured_Date_Admitted_to_Hospital = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Injured_Still_in_Hospital = false;
                this._Injured_Physicians_Name = "";
                this._Property_Description = "";
                this._Property_Damage_Description = "";
                this._Estimate_Available = false;
                this._Property_Estimator_Name = "";
                this._Property_Business_Name = "";
                this._Property_Address_1 = "";
                this._Property_Address_2 = "";
                this._Property_City = "";
                this._Property_State = "";
                this._Property_Zip_Code = "";
                this._Location_where_property_can_be_seen = "";
                this._Estimate_Amount = -1;
                this._Estimator_Phone = "";
                this._Owner_Name = "";
                this._Owner_Work_Telephone = "";
                this._Owner_Home_Telephone = "";
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Security_Video_System = false;
                this._FK_SLT_Incident_Review = -1;
            }

        }

        
        /// <summary> 
        /// Initializes a new instance of the PL_FR class for passed PL_FR_Number with the values set from Database.
        /// </summary>
        public PL_FR(decimal PK,bool temp)
        {

            DataTable dtPL_FR = SelectByPL_FR_Number(PK).Tables[0];

            if (dtPL_FR.Rows.Count > 0)
            {

                DataRow drPL_FR = dtPL_FR.Rows[0];

                this._PK_PL_FR_ID = drPL_FR["PK_PL_FR_ID"] != DBNull.Value ? Convert.ToDecimal(drPL_FR["PK_PL_FR_ID"]) : 0;
                this._PL_FR_Number = drPL_FR["PL_FR_Number"] != DBNull.Value ? Convert.ToDecimal(drPL_FR["PL_FR_Number"]) : 0;
                this._Owner_Alternate_Telephone = Convert.ToString(drPL_FR["Owner_Alternate_Telephone"]);
                this._Witness_Name = Convert.ToString(drPL_FR["Witness_Name"]);
                this._Witness_Address_1 = Convert.ToString(drPL_FR["Witness_Address_1"]);
                this._Witness_Address_2 = Convert.ToString(drPL_FR["Witness_Address_2"]);
                this._Witness_City = Convert.ToString(drPL_FR["Witness_City"]);
                this._Witness_State = Convert.ToString(drPL_FR["Witness_State"]);
                this._Witness_Zip_Code = Convert.ToString(drPL_FR["Witness_Zip_Code"]);
                this._Witness_Work_Telephone = Convert.ToString(drPL_FR["Witness_Work_Telephone"]);
                this._Witness_Home_Telephone = Convert.ToString(drPL_FR["Witness_Home_Telephone"]);
                this._Witness_Alternate_Telephone = Convert.ToString(drPL_FR["Witness_Alternate_Telephone"]);
                this._Comments = Convert.ToString(drPL_FR["Comments"]);
                this._Complete = drPL_FR["Complete"] != DBNull.Value ? Convert.ToBoolean(drPL_FR["Complete"]) : false;
                this._FK_LU_Location_ID = drPL_FR["FK_LU_Location_ID"] != DBNull.Value ? Convert.ToDecimal(drPL_FR["FK_LU_Location_ID"]) : 0;
                this._FK_Contact = drPL_FR["FK_Contact"] != DBNull.Value ? Convert.ToDecimal(drPL_FR["FK_Contact"]) : 0;
                this._Claimant_State = drPL_FR["Claimant_State"] != DBNull.Value ? Convert.ToDecimal(drPL_FR["Claimant_State"]) : 0;
                this._Date_of_Loss = drPL_FR["Date_of_Loss"] != DBNull.Value ? Convert.ToDateTime(drPL_FR["Date_of_Loss"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Time_of_Loss = Convert.ToString(drPL_FR["Time_of_Loss"]);
                this._Non_Sonic_Loss_Location = Convert.ToString(drPL_FR["Non_Sonic_Loss_Location"]);
                this._Description_of_Loss = Convert.ToString(drPL_FR["Description_of_Loss"]);
                this._Date_Reported_To_Sonic = drPL_FR["Date_Reported_To_Sonic"] != DBNull.Value ? Convert.ToDateTime(drPL_FR["Date_Reported_To_Sonic"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Weather_Conditions = Convert.ToString(drPL_FR["Weather_Conditions"]);
                this._Road_Conditions = Convert.ToString(drPL_FR["Road_Conditions"]);
                if (drPL_FR["Were_Police_Notified"] != DBNull.Value)
                    this._Were_Police_Notified = Convert.ToBoolean(drPL_FR["Were_Police_Notified"]);
                this._Police_Organization = Convert.ToString(drPL_FR["Police_Organization"]);
                this._Police_telephone = Convert.ToString(drPL_FR["Police_telephone"]);
                this._Case_Number = Convert.ToString(drPL_FR["Case_Number"]);
                if (drPL_FR["Personal_Bodily_Injury"] != DBNull.Value)
                    this._Personal_Bodily_Injury = Convert.ToBoolean(drPL_FR["Personal_Bodily_Injury"]);
                this._Loss_Category = Convert.ToString(drPL_FR["Loss_Category"]);
                if (drPL_FR["Property_Damage"] != DBNull.Value)
                    this._Property_Damage = Convert.ToBoolean(drPL_FR["Property_Damage"]);
                if (drPL_FR["Witnesses"] != DBNull.Value)
                    this._Witnesses = Convert.ToBoolean(drPL_FR["Witnesses"]);
                if (drPL_FR["Product_Involved"] != DBNull.Value)
                    this._Product_Involved = Convert.ToBoolean(drPL_FR["Product_Involved"]);
                this._Type_of_Product = Convert.ToString(drPL_FR["Type_of_Product"]);
                this._Manufacturer_Name = Convert.ToString(drPL_FR["Manufacturer_Name"]);
                this._Product_Address_1 = Convert.ToString(drPL_FR["Product_Address_1"]);
                this._Product_Address_2 = Convert.ToString(drPL_FR["Product_Address_2"]);
                this._Product_City = Convert.ToString(drPL_FR["Product_City"]);
                this._Product_State = Convert.ToString(drPL_FR["Product_State"]);
                this._Product_Zip_Code = Convert.ToString(drPL_FR["Product_Zip_Code"]);
                this._Product_Location = Convert.ToString(drPL_FR["Product_Location"]);
                this._Injured_Name = Convert.ToString(drPL_FR["Injured_Name"]);
                this._Injured_Address_1 = Convert.ToString(drPL_FR["Injured_Address_1"]);
                this._Injured_Address_2 = Convert.ToString(drPL_FR["Injured_Address_2"]);
                this._Injured_City = Convert.ToString(drPL_FR["Injured_City"]);
                this._Injured_State = Convert.ToString(drPL_FR["Injured_State"]);
                this._Injured_ZipCode = Convert.ToString(drPL_FR["Injured_ZipCode"]);
                this._Injured_Work_Phone = Convert.ToString(drPL_FR["Injured_Work_Phone"]);
                this._Injured_Alternate_Telephone = Convert.ToString(drPL_FR["Injured_Alternate_Telephone"]);
                this._Injured_Home_Phone = Convert.ToString(drPL_FR["Injured_Home_Phone"]);
                this._What_Was_Injured_Doing = Convert.ToString(drPL_FR["What_Was_Injured_Doing"]);
                this._body_part = Convert.ToString(drPL_FR["body_part"]);
                this._Injured_Medical_Treatment_Provided = Convert.ToString(drPL_FR["Injured_Medical_Treatment_Provided"]);
                this._Injured_Taken_By_Emergency_Transportation = drPL_FR["Injured_Taken_By_Emergency_Transportation"] != DBNull.Value ? Convert.ToBoolean(drPL_FR["Injured_Taken_By_Emergency_Transportation"]) : false;
                this._Injured_Medical_Facility_Name = Convert.ToString(drPL_FR["Injured_Medical_Facility_Name"]);
                this._Injured_Medical_Facility_Address_1 = Convert.ToString(drPL_FR["Injured_Medical_Facility_Address_1"]);
                this._Injured_Medical_Facility_Address_2 = Convert.ToString(drPL_FR["Injured_Medical_Facility_Address_2"]);
                this._Injured_Medical_Facility_City = Convert.ToString(drPL_FR["Injured_Medical_Facility_City"]);
                this._Injured_Medical_Facility_State = Convert.ToString(drPL_FR["Injured_Medical_Facility_State"]);
                this._Injured_Medical_Facility_Zip_Code = Convert.ToString(drPL_FR["Injured_Medical_Facility_Zip_Code"]);
                this._Injured_Medical_Facility_Type = Convert.ToString(drPL_FR["Injured_Medical_Facility_Type"]);
                if (drPL_FR["Injured_Airlifted_Medivac"] != DBNull.Value)
                    this._Injured_Airlifted_Medivac = Convert.ToBoolean(drPL_FR["Injured_Airlifted_Medivac"]);

                this._Injured_Citation_Issued = drPL_FR["Injured_Citation_Issued"] != DBNull.Value ? Convert.ToBoolean(drPL_FR["Injured_Citation_Issued"]) : false;
                this._Injured_Citation_Number = Convert.ToString(drPL_FR["Injured_Citation_Number"]);
                this._Injured_Gender = Convert.ToString(drPL_FR["Injured_Gender"]);
                this._Injured_Date_of_Initial_Treatment = drPL_FR["Injured_Date_of_Initial_Treatment"] != DBNull.Value ? Convert.ToDateTime(drPL_FR["Injured_Date_of_Initial_Treatment"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Injured_Injury_Description = Convert.ToString(drPL_FR["Injured_Injury_Description"]);
                this._Injured_Sought_Medical_Attention = drPL_FR["Injured_Sought_Medical_Attention"] != DBNull.Value ? Convert.ToBoolean(drPL_FR["Injured_Sought_Medical_Attention"]) : false;
                if (drPL_FR["Injured_Admitted_to_Hospital"] != DBNull.Value)
                    this._Injured_Admitted_to_Hospital = Convert.ToBoolean(drPL_FR["Injured_Admitted_to_Hospital"]);

                this._Injured_Date_Admitted_to_Hospital = drPL_FR["Injured_Date_Admitted_to_Hospital"] != DBNull.Value ? Convert.ToDateTime(drPL_FR["Injured_Date_Admitted_to_Hospital"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                if (drPL_FR["Injured_Still_in_Hospital"] != DBNull.Value)
                    this._Injured_Still_in_Hospital = Convert.ToBoolean(drPL_FR["Injured_Still_in_Hospital"]);

                this._Injured_Physicians_Name = Convert.ToString(drPL_FR["Injured_Physicians_Name"]);
                this._Property_Description = Convert.ToString(drPL_FR["Property_Description"]);
                this._Property_Damage_Description = Convert.ToString(drPL_FR["Property_Damage_Description"]);
                if (drPL_FR["Estimate_Available"] != DBNull.Value)
                    this._Estimate_Available = Convert.ToBoolean(drPL_FR["Estimate_Available"]);
                this._Property_Estimator_Name = Convert.ToString(drPL_FR["Property_Estimator_Name"]);
                this._Property_Business_Name = Convert.ToString(drPL_FR["Property_Business_Name"]);
                this._Property_Address_1 = Convert.ToString(drPL_FR["Property_Address_1"]);
                this._Property_Address_2 = Convert.ToString(drPL_FR["Property_Address_2"]);
                this._Property_City = Convert.ToString(drPL_FR["Property_City"]);
                this._Property_State = Convert.ToString(drPL_FR["Property_State"]);
                this._Property_Zip_Code = Convert.ToString(drPL_FR["Property_Zip_Code"]);
                this._Location_where_property_can_be_seen = Convert.ToString(drPL_FR["Location_where_property_can_be_seen"]);
                this._Estimate_Amount = drPL_FR["Estimate_Amount"] != DBNull.Value ? Convert.ToDecimal(drPL_FR["Estimate_Amount"]) : 0;
                this._Estimator_Phone = Convert.ToString(drPL_FR["Estimator_Phone"]);
                this._Owner_Name = Convert.ToString(drPL_FR["Owner_Name"]);
                this._Owner_Work_Telephone = Convert.ToString(drPL_FR["Owner_Work_Telephone"]);
                this._Owner_Home_Telephone = Convert.ToString(drPL_FR["Owner_Home_Telephone"]);
                this._Updated_By = drPL_FR["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drPL_FR["Updated_By"]) : 0;
                this._Updated_Date = drPL_FR["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drPL_FR["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                if (drPL_FR["Security_Video_System"] != DBNull.Value)
                    this._Security_Video_System = Convert.ToBoolean(drPL_FR["Security_Video_System"]);
                this._FK_SLT_Incident_Review = drPL_FR["FK_SLT_Incident_Review"] != DBNull.Value ? Convert.ToDecimal(drPL_FR["FK_SLT_Incident_Review"]) : 0;
            }

            else
            {

                this._PK_PL_FR_ID = -1;
                this._PL_FR_Number = -1;
                this._Owner_Alternate_Telephone = "";
                this._Witness_Name = "";
                this._Witness_Address_1 = "";
                this._Witness_Address_2 = "";
                this._Witness_City = "";
                this._Witness_State = "";
                this._Witness_Zip_Code = "";
                this._Witness_Work_Telephone = "";
                this._Witness_Home_Telephone = "";
                this._Witness_Alternate_Telephone = "";
                this._Comments = "";
                this._Complete = false;
                this._FK_LU_Location_ID = -1;
                this._FK_Contact = -1;
                this._Claimant_State = -1;
                this._Date_of_Loss = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Time_of_Loss = "";
                this._Non_Sonic_Loss_Location = "";
                this._Description_of_Loss = "";
                this._Date_Reported_To_Sonic = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Weather_Conditions = "";
                this._Road_Conditions = "";
                this._Were_Police_Notified = false;
                this._Police_Organization = "";
                this._Police_telephone = "";
                this._Case_Number = "";
                this._Personal_Bodily_Injury = false;
                this._Loss_Category = "";
                this._Property_Damage = false;
                this._Witnesses = false;
                this._Product_Involved = false;
                this._Type_of_Product = "";
                this._Manufacturer_Name = "";
                this._Product_Address_1 = "";
                this._Product_Address_2 = "";
                this._Product_City = "";
                this._Product_State = "";
                this._Product_Zip_Code = "";
                this._Product_Location = "";
                this._Injured_Name = "";
                this._Injured_Address_1 = "";
                this._Injured_Address_2 = "";
                this._Injured_City = "";
                this._Injured_State = "";
                this._Injured_ZipCode = "";
                this._Injured_Work_Phone = "";
                this._Injured_Alternate_Telephone = "";
                this._Injured_Home_Phone = "";
                this._What_Was_Injured_Doing = "";
                this._body_part = "";
                this._Injured_Medical_Treatment_Provided = "";
                this._Injured_Taken_By_Emergency_Transportation = false;
                this._Injured_Medical_Facility_Name = "";
                this._Injured_Medical_Facility_Address_1 = "";
                this._Injured_Medical_Facility_Address_2 = "";
                this._Injured_Medical_Facility_City = "";
                this._Injured_Medical_Facility_State = "";
                this._Injured_Medical_Facility_Zip_Code = "";
                this._Injured_Medical_Facility_Type = "";
                this._Injured_Airlifted_Medivac = false;
                this._Injured_Citation_Issued = false;
                this._Injured_Citation_Number = "";
                this._Injured_Gender = "";
                this._Injured_Date_of_Initial_Treatment = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Injured_Injury_Description = "";
                this._Injured_Sought_Medical_Attention = false;
                this._Injured_Admitted_to_Hospital = false;
                this._Injured_Date_Admitted_to_Hospital = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Injured_Still_in_Hospital = false;
                this._Injured_Physicians_Name = "";
                this._Property_Description = "";
                this._Property_Damage_Description = "";
                this._Estimate_Available = false;
                this._Property_Estimator_Name = "";
                this._Property_Business_Name = "";
                this._Property_Address_1 = "";
                this._Property_Address_2 = "";
                this._Property_City = "";
                this._Property_State = "";
                this._Property_Zip_Code = "";
                this._Location_where_property_can_be_seen = "";
                this._Estimate_Amount = -1;
                this._Estimator_Phone = "";
                this._Owner_Name = "";
                this._Owner_Work_Telephone = "";
                this._Owner_Home_Telephone = "";
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this.Security_Video_System = false;
                this._FK_SLT_Incident_Review = -1;
            }

        }
        #endregion


        #region Methods
        /// <summary>
        /// Inserts a record into the PL_FR table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PL_FRInsert");

            db.AddInParameter(dbCommand, "PL_FR_Number", DbType.Decimal, this._PL_FR_Number);
            db.AddInParameter(dbCommand, "Owner_Alternate_Telephone", DbType.String, this._Owner_Alternate_Telephone);
            db.AddInParameter(dbCommand, "Witness_Name", DbType.String, this._Witness_Name);
            db.AddInParameter(dbCommand, "Witness_Address_1", DbType.String, this._Witness_Address_1);
            db.AddInParameter(dbCommand, "Witness_Address_2", DbType.String, this._Witness_Address_2);
            db.AddInParameter(dbCommand, "Witness_City", DbType.String, this._Witness_City);
            db.AddInParameter(dbCommand, "Witness_State", DbType.String, this._Witness_State);
            db.AddInParameter(dbCommand, "Witness_Zip_Code", DbType.String, this._Witness_Zip_Code);
            db.AddInParameter(dbCommand, "Witness_Work_Telephone", DbType.String, this._Witness_Work_Telephone);
            db.AddInParameter(dbCommand, "Witness_Home_Telephone", DbType.String, this._Witness_Home_Telephone);
            db.AddInParameter(dbCommand, "Witness_Alternate_Telephone", DbType.String, this._Witness_Alternate_Telephone);
            db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
            db.AddInParameter(dbCommand, "Complete", DbType.Boolean, this._Complete);
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);
            db.AddInParameter(dbCommand, "FK_Contact", DbType.Decimal, this._FK_Contact);
            db.AddInParameter(dbCommand, "Claimant_State", DbType.Decimal, this._Claimant_State);
            db.AddInParameter(dbCommand, "Date_of_Loss", DbType.DateTime, this._Date_of_Loss);
            db.AddInParameter(dbCommand, "Time_of_Loss", DbType.String, this._Time_of_Loss);
            db.AddInParameter(dbCommand, "Non_Sonic_Loss_Location", DbType.String, this._Non_Sonic_Loss_Location);
            db.AddInParameter(dbCommand, "Description_of_Loss", DbType.String, this._Description_of_Loss);
            db.AddInParameter(dbCommand, "Date_Reported_To_Sonic", DbType.DateTime, this._Date_Reported_To_Sonic);
            db.AddInParameter(dbCommand, "Weather_Conditions", DbType.String, this._Weather_Conditions);
            db.AddInParameter(dbCommand, "Road_Conditions", DbType.String, this._Road_Conditions);
            if (this._Were_Police_Notified != true && this._Were_Police_Notified != false)
                db.AddInParameter(dbCommand, "Were_Police_Notified", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Were_Police_Notified", DbType.Boolean, this._Were_Police_Notified);
            db.AddInParameter(dbCommand, "Police_Organization", DbType.String, this._Police_Organization);
            db.AddInParameter(dbCommand, "Police_telephone", DbType.String, this._Police_telephone);
            db.AddInParameter(dbCommand, "Case_Number", DbType.String, this._Case_Number);
            if (this._Personal_Bodily_Injury != true && this._Personal_Bodily_Injury != false)
                db.AddInParameter(dbCommand, "Personal_Bodily_Injury", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Personal_Bodily_Injury", DbType.Boolean, this._Personal_Bodily_Injury);

            db.AddInParameter(dbCommand, "Loss_Category", DbType.String, this._Loss_Category);

            if (this._Property_Damage != true && this._Property_Damage != false)
                db.AddInParameter(dbCommand, "Property_Damage", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Property_Damage", DbType.Boolean, this._Property_Damage);

            if (this._Witnesses != true && this._Witnesses != false)
                db.AddInParameter(dbCommand, "Witnesses", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Witnesses", DbType.Boolean, this._Witnesses);

            if (this._Product_Involved != true && this._Product_Involved != false)
                db.AddInParameter(dbCommand, "Product_Involved", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Product_Involved", DbType.Boolean, this._Product_Involved);

            db.AddInParameter(dbCommand, "Type_of_Product", DbType.String, this._Type_of_Product);
            db.AddInParameter(dbCommand, "Manufacturer_Name", DbType.String, this._Manufacturer_Name);
            db.AddInParameter(dbCommand, "Product_Address_1", DbType.String, this._Product_Address_1);
            db.AddInParameter(dbCommand, "Product_Address_2", DbType.String, this._Product_Address_2);
            db.AddInParameter(dbCommand, "Product_City", DbType.String, this._Product_City);
            db.AddInParameter(dbCommand, "Product_State", DbType.String, this._Product_State);
            db.AddInParameter(dbCommand, "Product_Zip_Code", DbType.String, this._Product_Zip_Code);
            db.AddInParameter(dbCommand, "Product_Location", DbType.String, this._Product_Location);
            db.AddInParameter(dbCommand, "Injured_Name", DbType.String, this._Injured_Name);
            db.AddInParameter(dbCommand, "Injured_Address_1", DbType.String, this._Injured_Address_1);
            db.AddInParameter(dbCommand, "Injured_Address_2", DbType.String, this._Injured_Address_2);
            db.AddInParameter(dbCommand, "Injured_City", DbType.String, this._Injured_City);
            db.AddInParameter(dbCommand, "Injured_State", DbType.String, this._Injured_State);
            db.AddInParameter(dbCommand, "Injured_ZipCode", DbType.String, this._Injured_ZipCode);
            db.AddInParameter(dbCommand, "Injured_Work_Phone", DbType.String, this._Injured_Work_Phone);
            db.AddInParameter(dbCommand, "Injured_Alternate_Telephone", DbType.String, this._Injured_Alternate_Telephone);
            db.AddInParameter(dbCommand, "Injured_Home_Phone", DbType.String, this._Injured_Home_Phone);
            db.AddInParameter(dbCommand, "What_Was_Injured_Doing", DbType.String, this._What_Was_Injured_Doing);
            db.AddInParameter(dbCommand, "body_part", DbType.String, this._body_part);
            db.AddInParameter(dbCommand, "Injured_Medical_Treatment_Provided", DbType.String, this._Injured_Medical_Treatment_Provided);
            if (this._Personal_Bodily_Injury != true && this._Personal_Bodily_Injury != false)
                db.AddInParameter(dbCommand, "Injured_Taken_By_Emergency_Transportation", DbType.Boolean, this._Injured_Taken_By_Emergency_Transportation);
            else
                db.AddInParameter(dbCommand, "Injured_Taken_By_Emergency_Transportation", DbType.Boolean, DBNull.Value);
            db.AddInParameter(dbCommand, "Injured_Medical_Facility_Name", DbType.String, this._Injured_Medical_Facility_Name);
            db.AddInParameter(dbCommand, "Injured_Medical_Facility_Address_1", DbType.String, this._Injured_Medical_Facility_Address_1);
            db.AddInParameter(dbCommand, "Injured_Medical_Facility_Address_2", DbType.String, this._Injured_Medical_Facility_Address_2);
            db.AddInParameter(dbCommand, "Injured_Medical_Facility_City", DbType.String, this._Injured_Medical_Facility_City);
            db.AddInParameter(dbCommand, "Injured_Medical_Facility_State", DbType.String, this._Injured_Medical_Facility_State);
            db.AddInParameter(dbCommand, "Injured_Medical_Facility_Zip_Code", DbType.String, this._Injured_Medical_Facility_Zip_Code);
            db.AddInParameter(dbCommand, "Injured_Medical_Facility_Type", DbType.String, this._Injured_Medical_Facility_Type);
            if (this._Injured_Airlifted_Medivac != true && this._Injured_Airlifted_Medivac != false)
                db.AddInParameter(dbCommand, "Injured_Airlifted_Medivac", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Injured_Airlifted_Medivac", DbType.Boolean, this._Injured_Airlifted_Medivac);

            db.AddInParameter(dbCommand, "Injured_Citation_Issued", DbType.Boolean, this._Injured_Citation_Issued);
            db.AddInParameter(dbCommand, "Injured_Citation_Number", DbType.String, this._Injured_Citation_Number);
            db.AddInParameter(dbCommand, "Injured_Gender", DbType.String, this._Injured_Gender);
            db.AddInParameter(dbCommand, "Injured_Date_of_Initial_Treatment", DbType.DateTime, this._Injured_Date_of_Initial_Treatment);
            db.AddInParameter(dbCommand, "Injured_Injury_Description", DbType.String, this._Injured_Injury_Description);
            db.AddInParameter(dbCommand, "Injured_Sought_Medical_Attention", DbType.Boolean, this._Injured_Sought_Medical_Attention);
            if (this._Injured_Admitted_to_Hospital != true && this._Injured_Admitted_to_Hospital != false)
                db.AddInParameter(dbCommand, "Injured_Admitted_to_Hospital", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Injured_Admitted_to_Hospital", DbType.Boolean, this._Injured_Admitted_to_Hospital);

            db.AddInParameter(dbCommand, "Injured_Date_Admitted_to_Hospital", DbType.DateTime, this._Injured_Date_Admitted_to_Hospital);
            if (this._Injured_Still_in_Hospital != true && this._Injured_Still_in_Hospital != false)
                db.AddInParameter(dbCommand, "Injured_Still_in_Hospital", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Injured_Still_in_Hospital", DbType.Boolean, this._Injured_Still_in_Hospital);

            db.AddInParameter(dbCommand, "Injured_Physicians_Name", DbType.String, this._Injured_Physicians_Name);
            db.AddInParameter(dbCommand, "Property_Description", DbType.String, this._Property_Description);
            db.AddInParameter(dbCommand, "Property_Damage_Description", DbType.String, this._Property_Damage_Description);
            if (this._Estimate_Available != true && this._Estimate_Available != false)
                db.AddInParameter(dbCommand, "Estimate_Available", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Estimate_Available", DbType.Boolean, this._Estimate_Available);
            db.AddInParameter(dbCommand, "Property_Estimator_Name", DbType.String, this._Property_Estimator_Name);
            db.AddInParameter(dbCommand, "Property_Business_Name", DbType.String, this._Property_Business_Name);
            db.AddInParameter(dbCommand, "Property_Address_1", DbType.String, this._Property_Address_1);
            db.AddInParameter(dbCommand, "Property_Address_2", DbType.String, this._Property_Address_2);
            db.AddInParameter(dbCommand, "Property_City", DbType.String, this._Property_City);
            db.AddInParameter(dbCommand, "Property_State", DbType.String, this._Property_State);
            db.AddInParameter(dbCommand, "Property_Zip_Code", DbType.String, this._Property_Zip_Code);
            db.AddInParameter(dbCommand, "Location_where_property_can_be_seen", DbType.String, this._Location_where_property_can_be_seen);
            db.AddInParameter(dbCommand, "Estimate_Amount", DbType.Decimal, this._Estimate_Amount);
            db.AddInParameter(dbCommand, "Estimator_Phone", DbType.String, this._Estimator_Phone);
            db.AddInParameter(dbCommand, "Owner_Name", DbType.String, this._Owner_Name);
            db.AddInParameter(dbCommand, "Owner_Work_Telephone", DbType.String, this._Owner_Work_Telephone);
            db.AddInParameter(dbCommand, "Owner_Home_Telephone", DbType.String, this._Owner_Home_Telephone);
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
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the PL_FR table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_PL_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PL_FRSelectByPK");

            db.AddInParameter(dbCommand, "PK_PL_FR_ID", DbType.Decimal, pK_PL_FR_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the PL_FR table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PL_FRSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByPL_FR_Number(decimal pL_FR_Number)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PL_FRSelectByPL_FR_Number");

            db.AddInParameter(dbCommand, "PL_FR_Number", DbType.Decimal, pL_FR_Number);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByPKForClaim(decimal PK_PL_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PL_FRSelectByPKForClaim");

            db.AddInParameter(dbCommand, "PK_PL_FR_ID", DbType.Decimal, PK_PL_FR_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the PL_FR table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PL_FRUpdate");

            db.AddInParameter(dbCommand, "PK_PL_FR_ID", DbType.Decimal, this._PK_PL_FR_ID);
            db.AddInParameter(dbCommand, "PL_FR_Number", DbType.Decimal, this._PL_FR_Number);
            db.AddInParameter(dbCommand, "Owner_Alternate_Telephone", DbType.String, this._Owner_Alternate_Telephone);
            db.AddInParameter(dbCommand, "Witness_Name", DbType.String, this._Witness_Name);
            db.AddInParameter(dbCommand, "Witness_Address_1", DbType.String, this._Witness_Address_1);
            db.AddInParameter(dbCommand, "Witness_Address_2", DbType.String, this._Witness_Address_2);
            db.AddInParameter(dbCommand, "Witness_City", DbType.String, this._Witness_City);
            db.AddInParameter(dbCommand, "Witness_State", DbType.String, this._Witness_State);
            db.AddInParameter(dbCommand, "Witness_Zip_Code", DbType.String, this._Witness_Zip_Code);
            db.AddInParameter(dbCommand, "Witness_Work_Telephone", DbType.String, this._Witness_Work_Telephone);
            db.AddInParameter(dbCommand, "Witness_Home_Telephone", DbType.String, this._Witness_Home_Telephone);
            db.AddInParameter(dbCommand, "Witness_Alternate_Telephone", DbType.String, this._Witness_Alternate_Telephone);
            db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
            db.AddInParameter(dbCommand, "Complete", DbType.Boolean, this._Complete);
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);
            db.AddInParameter(dbCommand, "FK_Contact", DbType.Decimal, this._FK_Contact);
            db.AddInParameter(dbCommand, "Claimant_State", DbType.Decimal, this._Claimant_State);
            db.AddInParameter(dbCommand, "Date_of_Loss", DbType.DateTime, this._Date_of_Loss);
            db.AddInParameter(dbCommand, "Time_of_Loss", DbType.String, this._Time_of_Loss);
            db.AddInParameter(dbCommand, "Non_Sonic_Loss_Location", DbType.String, this._Non_Sonic_Loss_Location);
            db.AddInParameter(dbCommand, "Description_of_Loss", DbType.String, this._Description_of_Loss);
            db.AddInParameter(dbCommand, "Date_Reported_To_Sonic", DbType.DateTime, this._Date_Reported_To_Sonic);
            db.AddInParameter(dbCommand, "Weather_Conditions", DbType.String, this._Weather_Conditions);
            db.AddInParameter(dbCommand, "Road_Conditions", DbType.String, this._Road_Conditions);
            if (this._Were_Police_Notified != true && this._Were_Police_Notified != false)
                db.AddInParameter(dbCommand, "Were_Police_Notified", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Were_Police_Notified", DbType.Boolean, this._Were_Police_Notified);
            db.AddInParameter(dbCommand, "Police_Organization", DbType.String, this._Police_Organization);
            db.AddInParameter(dbCommand, "Police_telephone", DbType.String, this._Police_telephone);
            db.AddInParameter(dbCommand, "Case_Number", DbType.String, this._Case_Number);
            if (this._Personal_Bodily_Injury != true && this._Personal_Bodily_Injury != false)
                db.AddInParameter(dbCommand, "Personal_Bodily_Injury", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Personal_Bodily_Injury", DbType.Boolean, this._Personal_Bodily_Injury);

            db.AddInParameter(dbCommand, "Loss_Category", DbType.String, this._Loss_Category);

            if (this._Property_Damage != true && this._Property_Damage != false)
                db.AddInParameter(dbCommand, "Property_Damage", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Property_Damage", DbType.Boolean, this._Property_Damage);

            if (this._Witnesses != true && this._Witnesses != false)
                db.AddInParameter(dbCommand, "Witnesses", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Witnesses", DbType.Boolean, this._Witnesses);

            if (this._Product_Involved != true && this._Product_Involved != false)
                db.AddInParameter(dbCommand, "Product_Involved", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Product_Involved", DbType.Boolean, this._Product_Involved);
            db.AddInParameter(dbCommand, "Type_of_Product", DbType.String, this._Type_of_Product);
            db.AddInParameter(dbCommand, "Manufacturer_Name", DbType.String, this._Manufacturer_Name);
            db.AddInParameter(dbCommand, "Product_Address_1", DbType.String, this._Product_Address_1);
            db.AddInParameter(dbCommand, "Product_Address_2", DbType.String, this._Product_Address_2);
            db.AddInParameter(dbCommand, "Product_City", DbType.String, this._Product_City);
            db.AddInParameter(dbCommand, "Product_State", DbType.String, this._Product_State);
            db.AddInParameter(dbCommand, "Product_Zip_Code", DbType.String, this._Product_Zip_Code);
            db.AddInParameter(dbCommand, "Product_Location", DbType.String, this._Product_Location);
            db.AddInParameter(dbCommand, "Injured_Name", DbType.String, this._Injured_Name);
            db.AddInParameter(dbCommand, "Injured_Address_1", DbType.String, this._Injured_Address_1);
            db.AddInParameter(dbCommand, "Injured_Address_2", DbType.String, this._Injured_Address_2);
            db.AddInParameter(dbCommand, "Injured_City", DbType.String, this._Injured_City);
            db.AddInParameter(dbCommand, "Injured_State", DbType.String, this._Injured_State);
            db.AddInParameter(dbCommand, "Injured_ZipCode", DbType.String, this._Injured_ZipCode);
            db.AddInParameter(dbCommand, "Injured_Work_Phone", DbType.String, this._Injured_Work_Phone);
            db.AddInParameter(dbCommand, "Injured_Alternate_Telephone", DbType.String, this._Injured_Alternate_Telephone);
            db.AddInParameter(dbCommand, "Injured_Home_Phone", DbType.String, this._Injured_Home_Phone);
            db.AddInParameter(dbCommand, "What_Was_Injured_Doing", DbType.String, this._What_Was_Injured_Doing);
            db.AddInParameter(dbCommand, "body_part", DbType.String, this._body_part);
            db.AddInParameter(dbCommand, "Injured_Medical_Treatment_Provided", DbType.String, this._Injured_Medical_Treatment_Provided);
            if (this._Personal_Bodily_Injury != true)
            {
                db.AddInParameter(dbCommand, "Injured_Taken_By_Emergency_Transportation", DbType.Boolean, DBNull.Value);
                db.AddInParameter(dbCommand, "Injured_Citation_Issued", DbType.Boolean, DBNull.Value);
                db.AddInParameter(dbCommand, "Injured_Sought_Medical_Attention", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Injured_Taken_By_Emergency_Transportation", DbType.Boolean, this._Injured_Taken_By_Emergency_Transportation);
                db.AddInParameter(dbCommand, "Injured_Citation_Issued", DbType.Boolean, this._Injured_Citation_Issued);
                db.AddInParameter(dbCommand, "Injured_Sought_Medical_Attention", DbType.Boolean, this._Injured_Sought_Medical_Attention);
            }
            db.AddInParameter(dbCommand, "Injured_Medical_Facility_Name", DbType.String, this._Injured_Medical_Facility_Name);
            db.AddInParameter(dbCommand, "Injured_Medical_Facility_Address_1", DbType.String, this._Injured_Medical_Facility_Address_1);
            db.AddInParameter(dbCommand, "Injured_Medical_Facility_Address_2", DbType.String, this._Injured_Medical_Facility_Address_2);
            db.AddInParameter(dbCommand, "Injured_Medical_Facility_City", DbType.String, this._Injured_Medical_Facility_City);
            db.AddInParameter(dbCommand, "Injured_Medical_Facility_State", DbType.String, this._Injured_Medical_Facility_State);
            db.AddInParameter(dbCommand, "Injured_Medical_Facility_Zip_Code", DbType.String, this._Injured_Medical_Facility_Zip_Code);
            db.AddInParameter(dbCommand, "Injured_Medical_Facility_Type", DbType.String, this._Injured_Medical_Facility_Type);
            if (this._Injured_Airlifted_Medivac != true && this._Injured_Airlifted_Medivac != false)
                db.AddInParameter(dbCommand, "Injured_Airlifted_Medivac", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Injured_Airlifted_Medivac", DbType.Boolean, this._Injured_Airlifted_Medivac);

            
            db.AddInParameter(dbCommand, "Injured_Citation_Number", DbType.String, this._Injured_Citation_Number);
            db.AddInParameter(dbCommand, "Injured_Gender", DbType.String, this._Injured_Gender);
            db.AddInParameter(dbCommand, "Injured_Date_of_Initial_Treatment", DbType.DateTime, this._Injured_Date_of_Initial_Treatment);
            db.AddInParameter(dbCommand, "Injured_Injury_Description", DbType.String, this._Injured_Injury_Description);
            
            if (this._Injured_Admitted_to_Hospital != true && this._Injured_Admitted_to_Hospital != false)
                db.AddInParameter(dbCommand, "Injured_Admitted_to_Hospital", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Injured_Admitted_to_Hospital", DbType.Boolean, this._Injured_Admitted_to_Hospital);

            db.AddInParameter(dbCommand, "Injured_Date_Admitted_to_Hospital", DbType.DateTime, this._Injured_Date_Admitted_to_Hospital);
            if (this._Injured_Still_in_Hospital != true && this._Injured_Still_in_Hospital != false)
                db.AddInParameter(dbCommand, "Injured_Still_in_Hospital", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Injured_Still_in_Hospital", DbType.Boolean, this._Injured_Still_in_Hospital);
            db.AddInParameter(dbCommand, "Injured_Physicians_Name", DbType.String, this._Injured_Physicians_Name);
            db.AddInParameter(dbCommand, "Property_Description", DbType.String, this._Property_Description);
            db.AddInParameter(dbCommand, "Property_Damage_Description", DbType.String, this._Property_Damage_Description);
            if (this._Estimate_Available != true && this._Estimate_Available != false)
                db.AddInParameter(dbCommand, "Estimate_Available", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Estimate_Available", DbType.Boolean, this._Estimate_Available);
            db.AddInParameter(dbCommand, "Property_Estimator_Name", DbType.String, this._Property_Estimator_Name);
            db.AddInParameter(dbCommand, "Property_Business_Name", DbType.String, this._Property_Business_Name);
            db.AddInParameter(dbCommand, "Property_Address_1", DbType.String, this._Property_Address_1);
            db.AddInParameter(dbCommand, "Property_Address_2", DbType.String, this._Property_Address_2);
            db.AddInParameter(dbCommand, "Property_City", DbType.String, this._Property_City);
            db.AddInParameter(dbCommand, "Property_State", DbType.String, this._Property_State);
            db.AddInParameter(dbCommand, "Property_Zip_Code", DbType.String, this._Property_Zip_Code);
            db.AddInParameter(dbCommand, "Location_where_property_can_be_seen", DbType.String, this._Location_where_property_can_be_seen);
            if (this._Property_Damage != true)
                db.AddInParameter(dbCommand, "Estimate_Amount", DbType.Decimal, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Estimate_Amount", DbType.Decimal, this._Estimate_Amount);
            db.AddInParameter(dbCommand, "Estimator_Phone", DbType.String, this._Estimator_Phone);
            db.AddInParameter(dbCommand, "Owner_Name", DbType.String, this._Owner_Name);
            db.AddInParameter(dbCommand, "Owner_Work_Telephone", DbType.String, this._Owner_Work_Telephone);
            db.AddInParameter(dbCommand, "Owner_Home_Telephone", DbType.String, this._Owner_Home_Telephone);
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
        /// Deletes a record from the PL_FR table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_PL_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PL_FRDeleteByPK");

            db.AddInParameter(dbCommand, "PK_PL_FR_ID", DbType.Decimal, pK_PL_FR_ID);

            db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
