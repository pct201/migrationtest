using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    #region Default Value of Incident_Type Field
    //Here in Incident_Type Filed the value indicate Following Meaning
    //1 = MVA-Single , 2= MVA=Multiple , 3=Fraud , 4=Theft , 5=Partial Theft ,6=Vandalism ,7=Hail , 8=Flood ,9=Fire ,10=Wind  
    #endregion

    /// <summary>
    /// Data access class for DPD_FR_Vehicle table.
    /// </summary>
    public sealed class DPD_FR_Vehicle
    {
        #region Fields


        private decimal _PK_DPD_FR_Vehicle_ID;
        private decimal _FK_DPD_FR_ID;
        private string _Incident_Type;
        private string _Make;
        private string _Model;
        private decimal _Year;
        private string _VIN;
        private string _TypeOfVehicle;
        private string _Present_Location;
        private string _Present_Address;
        private string _Present_State;
        private string _Present_Zip;
        private Nullable<decimal> _Damage_Estimate;
        private Nullable<bool> _Driven_By_Associate;
        private string _Name;
        private string _Address;
        private string _Phone;
        private string _Vehicle_Owner_Sonic;
        private string _Vehicle_Owner_Address;
        private string _Vehicle_Owner_Phone;
        private Nullable<bool> _Associate_Cited;
        private string _Description_Of_Citation;
        private Nullable<bool> _Vehicle_Driven_By_Customer;
        private string _Not_Driven_By_Customer_Explain;
        private Nullable<bool> _Cutomer_Injured;
        private decimal _Invoice_Value;
        private Nullable<bool> _Vehicle_Recovered;
        private Nullable<bool> _Dealership_Wish_To_Take_Possession;
        private string _Loss_Description;
        private Nullable<bool> _Police_Notified;
        private string _Police_Report_Number;
        private Nullable<bool> _Vehicle_In_Storage;
        private string _Storage_Contact;
        private string _Storage_phone;
        private decimal _storage_cost;
        private string _storage_Address_1;
        private string _storage_Address_2;
        private string _storage_City;
        private string _storage_State;
        private string _storage_Zip_Code;
        private Nullable<bool> _Associate_injured;
        private Nullable<bool> _drug_test_performed;
        private string _drug_test_results;
        private string _drug_test_explanation;
        private Nullable<bool> _Additional_passengers;
        private Nullable<bool> _seeking_subrogation;
        private Nullable<bool> _Notice_only_claim;
        private string _TPI_Carrier_name;
        private string _TPI_Policy_number;
        private string _tpi_phone;
        private string _tpi_contact;
        private string _tpi_Address_1;
        private string _tpi_Address_2;
        private string _tpi_City;
        private string _tpi_State;
        private string _tpi_Zip_Code;
        private decimal _recovered_amount;
        private decimal _Updated_By;
        private DateTime _Update_Date;
        private Nullable<bool> _Security_Video_Surveillance;
        private string _VehicleXML;
        #endregion

        #region Properties


        /// <summary> 
        /// Gets or sets the PK_DPD_FR_Vehicle_ID value.
        /// </summary>
        public decimal PK_DPD_FR_Vehicle_ID
        {
            get { return _PK_DPD_FR_Vehicle_ID; }
            set { _PK_DPD_FR_Vehicle_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_DPD_FR_ID value.
        /// </summary>
        public decimal FK_DPD_FR_ID
        {
            get { return _FK_DPD_FR_ID; }
            set { _FK_DPD_FR_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Incident_Type value.
        /// </summary>
        public string Incident_Type
        {
            get { return _Incident_Type; }
            set { _Incident_Type = value; }
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
        /// Gets or sets the Year value.
        /// </summary>
        public decimal Year
        {
            get { return _Year; }
            set { _Year = value; }
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
        /// Gets or sets the TypeOfVehicle value.
        /// </summary>
        public string TypeOfVehicle
        {
            get { return _TypeOfVehicle; }
            set { _TypeOfVehicle = value; }
        }


        /// <summary> 
        /// Gets or sets the Present_Location value.
        /// </summary>
        public string Present_Location
        {
            get { return _Present_Location; }
            set { _Present_Location = value; }
        }


        /// <summary> 
        /// Gets or sets the Present_Address value.
        /// </summary>
        public string Present_Address
        {
            get { return _Present_Address; }
            set { _Present_Address = value; }
        }


        /// <summary> 
        /// Gets or sets the Present_State value.
        /// </summary>
        public string Present_State
        {
            get { return _Present_State; }
            set { _Present_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Present_Zip value.
        /// </summary>
        public string Present_Zip
        {
            get { return _Present_Zip; }
            set { _Present_Zip = value; }
        }

        /// <summary> 
        /// Gets or sets the Damage_Estimate value.
        /// </summary>
        public Nullable<decimal> Damage_Estimate
        {
            get { return _Damage_Estimate; }
            set { _Damage_Estimate = value; }
        }


        /// <summary> 
        /// Gets or sets the Driven_By_Associate value.
        /// </summary>
        public Nullable<bool> Driven_By_Associate
        {
            get { return _Driven_By_Associate; }
            set { _Driven_By_Associate = value; }
        }

        /// <summary> 
        /// Gets or sets the Name value.
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Address value.
        /// </summary>
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }


        /// <summary> 
        /// Gets or sets the Phone value.
        /// </summary>
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Vehicle_Owner_Sonic value.
        /// </summary>
        public string Vehicle_Owner_Sonic
        {
            get { return _Vehicle_Owner_Sonic; }
            set { _Vehicle_Owner_Sonic = value; }
        }


        /// <summary> 
        /// Gets or sets the Vehicle_Owner_Address value.
        /// </summary>
        public string Vehicle_Owner_Address
        {
            get { return _Vehicle_Owner_Address; }
            set { _Vehicle_Owner_Address = value; }
        }


        /// <summary> 
        /// Gets or sets the Vehicle_Owner_Phone value.
        /// </summary>
        public string Vehicle_Owner_Phone
        {
            get { return _Vehicle_Owner_Phone; }
            set { _Vehicle_Owner_Phone = value; }
        }

        /// <summary> 
        /// Gets or sets the Associate_Cited value.
        /// </summary>
        public Nullable<bool> Associate_Cited
        {
            get { return _Associate_Cited; }
            set { _Associate_Cited = value; }
        }


        /// <summary> 
        /// Gets or sets the Description_Of_Citation value.
        /// </summary>
        public string Description_Of_Citation
        {
            get { return _Description_Of_Citation; }
            set { _Description_Of_Citation = value; }
        }


        /// <summary> 
        /// Gets or sets the Vehicle_Driven_By_Customer value.
        /// </summary>
        public Nullable<bool> Vehicle_Driven_By_Customer
        {
            get { return _Vehicle_Driven_By_Customer; }
            set { _Vehicle_Driven_By_Customer = value; }
        }

        /// <summary>
        /// Gets or sets the Not_Driven_By_Customer_Explain value
        /// </summary>
        public string Not_Driven_By_Customer_Explain
        {
            get { return _Not_Driven_By_Customer_Explain; }
            set { _Not_Driven_By_Customer_Explain = value; }
        }

        /// <summary> 
        /// Gets or sets the Cutomer_Injured value.
        /// </summary>
        public Nullable<bool> Cutomer_Injured
        {
            get { return _Cutomer_Injured; }
            set { _Cutomer_Injured = value; }
        }

        /// <summary> 
        /// Gets or sets the Invoice_Value value.
        /// </summary>
        public decimal Invoice_Value
        {
            get { return _Invoice_Value; }
            set { _Invoice_Value = value; }
        }


        /// <summary> 
        /// Gets or sets the Vehicle_Recovered value.
        /// </summary>
        public Nullable<bool> Vehicle_Recovered
        {
            get { return _Vehicle_Recovered; }
            set { _Vehicle_Recovered = value; }
        }


        /// <summary> 
        /// Gets or sets the Dealership_Wish_To_Take_Possession value.
        /// </summary>
        public Nullable<bool> Dealership_Wish_To_Take_Possession
        {
            get { return _Dealership_Wish_To_Take_Possession; }
            set { _Dealership_Wish_To_Take_Possession = value; }
        }


        /// <summary> 
        /// Gets or sets the Loss_Description value.
        /// </summary>
        public string Loss_Description
        {
            get { return _Loss_Description; }
            set { _Loss_Description = value; }
        }


        /// <summary> 
        /// Gets or sets the Police_Notified value.
        /// </summary>
        public Nullable<bool> Police_Notified
        {
            get { return _Police_Notified; }
            set { _Police_Notified = value; }
        }


        /// <summary> 
        /// Gets or sets the Police_Report_Number value.
        /// </summary>
        public string Police_Report_Number
        {
            get { return _Police_Report_Number; }
            set { _Police_Report_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Vehicle_In_Storage value.
        /// </summary>
        public Nullable<bool> Vehicle_In_Storage
        {
            get { return _Vehicle_In_Storage; }
            set { _Vehicle_In_Storage = value; }
        }


        /// <summary> 
        /// Gets or sets the Storage_Contact value.
        /// </summary>
        public string Storage_Contact
        {
            get { return _Storage_Contact; }
            set { _Storage_Contact = value; }
        }


        /// <summary> 
        /// Gets or sets the Storage_phone value.
        /// </summary>
        public string Storage_phone
        {
            get { return _Storage_phone; }
            set { _Storage_phone = value; }
        }


        /// <summary> 
        /// Gets or sets the storage_cost value.
        /// </summary>
        public decimal storage_cost
        {
            get { return _storage_cost; }
            set { _storage_cost = value; }
        }


        /// <summary> 
        /// Gets or sets the storage_Address_1 value.
        /// </summary>
        public string storage_Address_1
        {
            get { return _storage_Address_1; }
            set { _storage_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the storage_Address_2 value.
        /// </summary>
        public string storage_Address_2
        {
            get { return _storage_Address_2; }
            set { _storage_Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the storage_City value.
        /// </summary>
        public string storage_City
        {
            get { return _storage_City; }
            set { _storage_City = value; }
        }


        /// <summary> 
        /// Gets or sets the storage_State value.
        /// </summary>
        public string storage_State
        {
            get { return _storage_State; }
            set { _storage_State = value; }
        }


        /// <summary> 
        /// Gets or sets the storage_Zip_Code value.
        /// </summary>
        public string storage_Zip_Code
        {
            get { return _storage_Zip_Code; }
            set { _storage_Zip_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the Associate_injured value.
        /// </summary>
        public Nullable<bool> Associate_injured
        {
            get { return _Associate_injured; }
            set { _Associate_injured = value; }
        }


        /// <summary> 
        /// Gets or sets the drug_test_performed value.
        /// </summary>
        public Nullable<bool> drug_test_performed
        {
            get { return _drug_test_performed; }
            set { _drug_test_performed = value; }
        }


        /// <summary> 
        /// Gets or sets the drug_test_results value.
        /// </summary>
        public string drug_test_results
        {
            get { return _drug_test_results; }
            set { _drug_test_results = value; }
        }


        /// <summary> 
        /// Gets or sets the drug_test_explanation value.
        /// </summary>
        public string drug_test_explanation
        {
            get { return _drug_test_explanation; }
            set { _drug_test_explanation = value; }
        }


        /// <summary> 
        /// Gets or sets the Additional_passengers value.
        /// </summary>
        public Nullable<bool> Additional_passengers
        {
            get { return _Additional_passengers; }
            set { _Additional_passengers = value; }
        }

        /// <summary> 
        /// Gets or sets the seeking_subrogation value.
        /// </summary>
        public Nullable<bool> seeking_subrogation
        {
            get { return _seeking_subrogation; }
            set { _seeking_subrogation = value; }
        }


        /// <summary> 
        /// Gets or sets the Notice_only_claim value.
        /// </summary>
        public Nullable<bool> Notice_only_claim
        {
            get { return _Notice_only_claim; }
            set { _Notice_only_claim = value; }
        }


        /// <summary> 
        /// Gets or sets the TPI_Carrier_name value.
        /// </summary>
        public string TPI_Carrier_name
        {
            get { return _TPI_Carrier_name; }
            set { _TPI_Carrier_name = value; }
        }


        /// <summary> 
        /// Gets or sets the TPI_Policy_number value.
        /// </summary>
        public string TPI_Policy_number
        {
            get { return _TPI_Policy_number; }
            set { _TPI_Policy_number = value; }
        }


        /// <summary> 
        /// Gets or sets the tpi_phone value.
        /// </summary>
        public string tpi_phone
        {
            get { return _tpi_phone; }
            set { _tpi_phone = value; }
        }


        /// <summary> 
        /// Gets or sets the tpi_contact value.
        /// </summary>
        public string tpi_contact
        {
            get { return _tpi_contact; }
            set { _tpi_contact = value; }
        }


        /// <summary> 
        /// Gets or sets the tpi_Address_1 value.
        /// </summary>
        public string tpi_Address_1
        {
            get { return _tpi_Address_1; }
            set { _tpi_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the tpi_Address_2 value.
        /// </summary>
        public string tpi_Address_2
        {
            get { return _tpi_Address_2; }
            set { _tpi_Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the tpi_City value.
        /// </summary>
        public string tpi_City
        {
            get { return _tpi_City; }
            set { _tpi_City = value; }
        }


        /// <summary> 
        /// Gets or sets the tpi_State value.
        /// </summary>
        public string tpi_State
        {
            get { return _tpi_State; }
            set { _tpi_State = value; }
        }


        /// <summary> 
        /// Gets or sets the tpi_Zip_Code value.
        /// </summary>
        public string tpi_Zip_Code
        {
            get { return _tpi_Zip_Code; }
            set { _tpi_Zip_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the recovered_amount value.
        /// </summary>
        public decimal recovered_amount
        {
            get { return _recovered_amount; }
            set { _recovered_amount = value; }
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
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }

        /// <summary> 
        /// Gets or sets the Security_Video_Surveillance value.
        /// </summary>
        public Nullable<bool> Security_Video_Surveillance
        {
            get { return _Security_Video_Surveillance; }
            set { _Security_Video_Surveillance = value; }
        }

        public string VehicleXML
        {
            get { return _VehicleXML; }
            set { _VehicleXML = value; }
        }


        #endregion

        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the DPD_FR_Vehicle class. with the default value.

        /// </summary>
        public DPD_FR_Vehicle()
        {

            this._PK_DPD_FR_Vehicle_ID = -1;
            this._FK_DPD_FR_ID = -1;
            this._Incident_Type = "";
            this._Make = "";
            this._Model = "";
            this._Year = -1;
            this._VIN = "";
            this._TypeOfVehicle = "";
            this._Present_Location = "";
            this._Present_Address = "";
            this._Present_State = "";
            this._Present_Zip = "";
            this._Damage_Estimate = null;
            this._Driven_By_Associate = null;
            this._Name = "";
            this._Address = "";
            this._Phone = "";
            this._Vehicle_Owner_Sonic = "";
            this._Vehicle_Owner_Address = "";
            this._Vehicle_Owner_Phone = "";
            this._Associate_Cited = null;
            this._Description_Of_Citation = "";
            this._Vehicle_Driven_By_Customer = null;
            this._Not_Driven_By_Customer_Explain = "";
            this._Cutomer_Injured = null;
            this._Invoice_Value = -1;
            this._Vehicle_Recovered = null;
            this._Dealership_Wish_To_Take_Possession = null;
            this._Loss_Description = "";
            this._Police_Notified = null;
            this._Police_Report_Number = "";
            this._Vehicle_In_Storage = null;
            this._Storage_Contact = "";
            this._Storage_phone = "";
            this._storage_cost = -1;
            this._storage_Address_1 = "";
            this._storage_Address_2 = "";
            this._storage_City = "";
            this._storage_State = "";
            this._storage_Zip_Code = "";
            this._Associate_injured = null;
            this._drug_test_performed = null;
            this._drug_test_results = "";
            this._drug_test_explanation = "";
            this._Additional_passengers = null;
            this._seeking_subrogation = null;
            this._Notice_only_claim = null;
            this._TPI_Carrier_name = "";
            this._TPI_Policy_number = "";
            this._tpi_phone = "";
            this._tpi_contact = "";
            this._tpi_Address_1 = "";
            this._tpi_Address_2 = "";
            this._tpi_City = "";
            this._tpi_State = "";
            this._tpi_Zip_Code = "";
            this._recovered_amount = -1;
            this._Updated_By = -1;
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Security_Video_Surveillance = null;
        }



        /// <summary> 
        /// Initializes a new instance of the DPD_FR_Vehicle class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public DPD_FR_Vehicle(decimal PK)
        {

            DataTable dtDPD_FR_Vehicle = SelectByPK(PK).Tables[0];

            if (dtDPD_FR_Vehicle.Rows.Count > 0)
            {

                DataRow drDPD_FR_Vehicle = dtDPD_FR_Vehicle.Rows[0];

                this._PK_DPD_FR_Vehicle_ID = drDPD_FR_Vehicle["PK_DPD_FR_Vehicle_ID"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR_Vehicle["PK_DPD_FR_Vehicle_ID"]) : 0;
                this._FK_DPD_FR_ID = drDPD_FR_Vehicle["FK_DPD_FR_ID"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR_Vehicle["FK_DPD_FR_ID"]) : 0;
                this._Incident_Type = Convert.ToString(drDPD_FR_Vehicle["Incident_Type"]);
                this._Make = Convert.ToString(drDPD_FR_Vehicle["Make"]);
                this._Model = Convert.ToString(drDPD_FR_Vehicle["Model"]);
                this._Year = drDPD_FR_Vehicle["Year"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR_Vehicle["Year"]) : 0;
                this._VIN = Convert.ToString(drDPD_FR_Vehicle["VIN"]);
                this._TypeOfVehicle = Convert.ToString(drDPD_FR_Vehicle["TypeOfVehicle"]);
                this._Present_Location = Convert.ToString(drDPD_FR_Vehicle["Present_Location"]);
                this._Present_Address = Convert.ToString(drDPD_FR_Vehicle["Present_Address"]);
                this._Present_State = Convert.ToString(drDPD_FR_Vehicle["Present_State"]);
                this._Present_Zip = Convert.ToString(drDPD_FR_Vehicle["Present_Zip"]);
                if (drDPD_FR_Vehicle["Damage_Estimate"] != DBNull.Value)
                    this._Damage_Estimate = Convert.ToDecimal(drDPD_FR_Vehicle["Damage_Estimate"]);
                if (drDPD_FR_Vehicle["Driven_By_Associate"] != DBNull.Value)
                    this._Driven_By_Associate = Convert.ToBoolean(drDPD_FR_Vehicle["Driven_By_Associate"]);
                this._Name = Convert.ToString(drDPD_FR_Vehicle["Name"]);
                this._Address = Convert.ToString(drDPD_FR_Vehicle["Address"]);
                this._Phone = Convert.ToString(drDPD_FR_Vehicle["Phone"]);
                this._Vehicle_Owner_Sonic = Convert.ToString(drDPD_FR_Vehicle["Vehicle_Owner_Sonic"]);
                this._Vehicle_Owner_Address = Convert.ToString(drDPD_FR_Vehicle["Vehicle_Owner_Address"]);
                this._Vehicle_Owner_Phone = Convert.ToString(drDPD_FR_Vehicle["Vehicle_Owner_Phone"]);
                if (drDPD_FR_Vehicle["Associate_Cited"] != DBNull.Value)
                    this._Associate_Cited = Convert.ToBoolean(drDPD_FR_Vehicle["Associate_Cited"]);
                this._Description_Of_Citation = Convert.ToString(drDPD_FR_Vehicle["Description_Of_Citation"]);
                if (drDPD_FR_Vehicle["Vehicle_Driven_By_Customer"] != DBNull.Value)
                    this._Vehicle_Driven_By_Customer = Convert.ToBoolean(drDPD_FR_Vehicle["Vehicle_Driven_By_Customer"]);
                this._Not_Driven_By_Customer_Explain = Convert.ToString(drDPD_FR_Vehicle["Not_Driven_By_Customer_Explain"]);
                if (drDPD_FR_Vehicle["Cutomer_Injured"] != DBNull.Value)
                    this._Cutomer_Injured = Convert.ToBoolean(drDPD_FR_Vehicle["Cutomer_Injured"]);
                this._Invoice_Value = drDPD_FR_Vehicle["Invoice_Value"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR_Vehicle["Invoice_Value"]) : 0;
                if (drDPD_FR_Vehicle["Vehicle_Recovered"] != DBNull.Value)
                    this._Vehicle_Recovered = Convert.ToBoolean(drDPD_FR_Vehicle["Vehicle_Recovered"]);
                if (drDPD_FR_Vehicle["Dealership_Wish_To_Take_Possession"] != DBNull.Value)
                    this._Dealership_Wish_To_Take_Possession = Convert.ToBoolean(drDPD_FR_Vehicle["Dealership_Wish_To_Take_Possession"]);
                this._Loss_Description = Convert.ToString(drDPD_FR_Vehicle["Loss_Description"]);
                if (drDPD_FR_Vehicle["Police_Notified"] != DBNull.Value)
                    this._Police_Notified = Convert.ToBoolean(drDPD_FR_Vehicle["Police_Notified"]);
                this._Police_Report_Number = Convert.ToString(drDPD_FR_Vehicle["Police_Report_Number"]);
                if (drDPD_FR_Vehicle["Vehicle_In_Storage"] != DBNull.Value)
                    this._Vehicle_In_Storage = Convert.ToBoolean(drDPD_FR_Vehicle["Vehicle_In_Storage"]);
                this._Storage_Contact = Convert.ToString(drDPD_FR_Vehicle["Storage_Contact"]);
                this._Storage_phone = Convert.ToString(drDPD_FR_Vehicle["Storage_phone"]);
                this._storage_cost = drDPD_FR_Vehicle["storage_cost"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR_Vehicle["storage_cost"]) : 0;
                this._storage_Address_1 = Convert.ToString(drDPD_FR_Vehicle["storage_Address_1"]);
                this._storage_Address_2 = Convert.ToString(drDPD_FR_Vehicle["storage_Address_2"]);
                this._storage_City = Convert.ToString(drDPD_FR_Vehicle["storage_City"]);
                this._storage_State = Convert.ToString(drDPD_FR_Vehicle["storage_State"]);
                this._storage_Zip_Code = Convert.ToString(drDPD_FR_Vehicle["storage_Zip_Code"]);
                if (drDPD_FR_Vehicle["Associate_injured"] != DBNull.Value)
                    this._Associate_injured = Convert.ToBoolean(drDPD_FR_Vehicle["Associate_injured"]);
                if (drDPD_FR_Vehicle["drug_test_performed"] != DBNull.Value)
                    this._drug_test_performed = Convert.ToBoolean(drDPD_FR_Vehicle["drug_test_performed"]);
                this._drug_test_results = Convert.ToString(drDPD_FR_Vehicle["drug_test_results"]);
                this._drug_test_explanation = Convert.ToString(drDPD_FR_Vehicle["drug_test_explanation"]);
                if (drDPD_FR_Vehicle["seeking_subrogation"] != DBNull.Value)
                    this._seeking_subrogation = Convert.ToBoolean(drDPD_FR_Vehicle["seeking_subrogation"]);
                if (drDPD_FR_Vehicle["Additional_passengers"] != DBNull.Value)
                    this._Additional_passengers = Convert.ToBoolean(drDPD_FR_Vehicle["Additional_passengers"]);
                if (drDPD_FR_Vehicle["Notice_only_claim"] != DBNull.Value)
                    this._Notice_only_claim = Convert.ToBoolean(drDPD_FR_Vehicle["Notice_only_claim"]);
                this._TPI_Carrier_name = Convert.ToString(drDPD_FR_Vehicle["TPI_Carrier_name"]);
                this._TPI_Policy_number = Convert.ToString(drDPD_FR_Vehicle["TPI_Policy_number"]);
                this._tpi_phone = Convert.ToString(drDPD_FR_Vehicle["tpi_phone"]);
                this._tpi_contact = Convert.ToString(drDPD_FR_Vehicle["tpi_contact"]);
                this._tpi_Address_1 = Convert.ToString(drDPD_FR_Vehicle["tpi_Address_1"]);
                this._tpi_Address_2 = Convert.ToString(drDPD_FR_Vehicle["tpi_Address_2"]);
                this._tpi_City = Convert.ToString(drDPD_FR_Vehicle["tpi_City"]);
                this._tpi_State = Convert.ToString(drDPD_FR_Vehicle["tpi_State"]);
                this._tpi_Zip_Code = Convert.ToString(drDPD_FR_Vehicle["tpi_Zip_Code"]);
                this._recovered_amount = drDPD_FR_Vehicle["recovered_amount"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR_Vehicle["recovered_amount"]) : 0;
                this._Updated_By = drDPD_FR_Vehicle["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR_Vehicle["Updated_By"]) : 0;
                this._Update_Date = drDPD_FR_Vehicle["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drDPD_FR_Vehicle["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                if (drDPD_FR_Vehicle["Security_Video_Surveillance"] != DBNull.Value)
                    this._Security_Video_Surveillance = Convert.ToBoolean(drDPD_FR_Vehicle["Security_Video_Surveillance"]);
            }

            else
            {

                this._PK_DPD_FR_Vehicle_ID = -1;
                this._FK_DPD_FR_ID = -1;
                this._Incident_Type = "";
                this._Make = "";
                this._Model = "";
                this._Year = -1;
                this._VIN = "";
                this._TypeOfVehicle = "";
                this._Present_Location = "";
                this._Present_Address = "";
                this._Present_State = "";
                this._Present_Zip = "";
                this._Damage_Estimate = null;
                this._Driven_By_Associate = null;
                this._Name = "";
                this._Address = "";
                this._Phone = "";
                this._Vehicle_Owner_Sonic = "";
                this._Vehicle_Owner_Address = "";
                this._Vehicle_Owner_Phone = "";
                this._Associate_Cited = null;
                this._Description_Of_Citation = "";
                this._Vehicle_Driven_By_Customer = null;
                this._Not_Driven_By_Customer_Explain = "";
                this._Cutomer_Injured = null;
                this._Invoice_Value = -1;
                this._Vehicle_Recovered = null;
                this._Dealership_Wish_To_Take_Possession = null;
                this._Loss_Description = "";
                this._Police_Notified = null;
                this._Police_Report_Number = "";
                this._Vehicle_In_Storage = null;
                this._Storage_Contact = "";
                this._Storage_phone = "";
                this._storage_cost = -1;
                this._storage_Address_1 = "";
                this._storage_Address_2 = "";
                this._storage_City = "";
                this._storage_State = "";
                this._storage_Zip_Code = "";
                this._Associate_injured = null;
                this._drug_test_performed = null;
                this._drug_test_results = "";
                this._drug_test_explanation = "";
                this._Additional_passengers = null;
                this._seeking_subrogation = null;
                this._Notice_only_claim = null;
                this._TPI_Carrier_name = "";
                this._TPI_Policy_number = "";
                this._tpi_phone = "";
                this._tpi_contact = "";
                this._tpi_Address_1 = "";
                this._tpi_Address_2 = "";
                this._tpi_City = "";
                this._tpi_State = "";
                this._tpi_Zip_Code = "";
                this._recovered_amount = -1;
                this._Updated_By = -1;
                this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this.Security_Video_Surveillance = null;

            }

        }



        #endregion

        #region Methods

        /// <summary>
        /// Inserts a record into the DPD_FR_Vehicle table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DPD_FR_VehicleInsert");

            db.AddInParameter(dbCommand, "FK_DPD_FR_ID", DbType.Decimal, this._FK_DPD_FR_ID);
            db.AddInParameter(dbCommand, "Incident_Type", DbType.String, this._Incident_Type);
            db.AddInParameter(dbCommand, "Make", DbType.String, this._Make);
            db.AddInParameter(dbCommand, "Model", DbType.String, this._Model);
            if (this._Year > 0)
                db.AddInParameter(dbCommand, "Year", DbType.Decimal, this._Year);
            else
                db.AddInParameter(dbCommand, "Year", DbType.Decimal, DBNull.Value);
            db.AddInParameter(dbCommand, "VIN", DbType.String, this._VIN);
            db.AddInParameter(dbCommand, "TypeOfVehicle", DbType.String, this._TypeOfVehicle);
            db.AddInParameter(dbCommand, "Present_Location", DbType.String, this._Present_Location);
            db.AddInParameter(dbCommand, "Present_Address", DbType.String, this._Present_Address);
            db.AddInParameter(dbCommand, "Present_State", DbType.String, this._Present_State);
            db.AddInParameter(dbCommand, "Present_Zip", DbType.String, this._Present_Zip);
            if (this._Damage_Estimate > 0)
                db.AddInParameter(dbCommand, "Damage_Estimate", DbType.Decimal, this._Damage_Estimate);
            else
                db.AddInParameter(dbCommand, "Damage_Estimate", DbType.Decimal, DBNull.Value);
            if (this._Driven_By_Associate != true && this._Driven_By_Associate != false)
                db.AddInParameter(dbCommand, "Driven_By_Associate", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Driven_By_Associate", DbType.Boolean, this._Driven_By_Associate);
            if (!string.IsNullOrEmpty(this._Name))
                db.AddInParameter(dbCommand, "Name", DbType.String, this._Name);
            else
                db.AddInParameter(dbCommand, "Name", DbType.String, DBNull.Value);
            if (!string.IsNullOrEmpty(this._Address))
                db.AddInParameter(dbCommand, "Address", DbType.String, this._Address);
            else
                db.AddInParameter(dbCommand, "Address", DbType.String, DBNull.Value);
            if (!string.IsNullOrEmpty(this._Phone))
                db.AddInParameter(dbCommand, "Phone", DbType.String, this._Phone);
            else
                db.AddInParameter(dbCommand, "Phone", DbType.String, DBNull.Value);
            if (!string.IsNullOrEmpty(this._Vehicle_Owner_Sonic))
                db.AddInParameter(dbCommand, "Vehicle_Owner_Sonic", DbType.String, this._Vehicle_Owner_Sonic);
            else
                db.AddInParameter(dbCommand, "Vehicle_Owner_Sonic", DbType.String, DBNull.Value);
            if (!string.IsNullOrEmpty(this._Vehicle_Owner_Address))
                db.AddInParameter(dbCommand, "Vehicle_Owner_Address", DbType.String, this._Vehicle_Owner_Address);
            else
                db.AddInParameter(dbCommand, "Vehicle_Owner_Address", DbType.String, DBNull.Value);
            if (!string.IsNullOrEmpty(this._Vehicle_Owner_Phone))
                db.AddInParameter(dbCommand, "Vehicle_Owner_Phone", DbType.String, this._Vehicle_Owner_Phone);
            else
                db.AddInParameter(dbCommand, "Vehicle_Owner_Phone", DbType.String, DBNull.Value);
            if ((this._Associate_Cited != true && this._Associate_Cited != false) || this._Driven_By_Associate != true)
                db.AddInParameter(dbCommand, "Associate_Cited", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Associate_Cited", DbType.Boolean, this._Associate_Cited);
            if (this._Associate_Cited != true)
                db.AddInParameter(dbCommand, "Description_Of_Citation", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Description_Of_Citation", DbType.String, this._Description_Of_Citation);
            if ((this._Vehicle_Driven_By_Customer != true && this._Vehicle_Driven_By_Customer != false) || this._Driven_By_Associate == true)
                db.AddInParameter(dbCommand, "Vehicle_Driven_By_Customer", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Vehicle_Driven_By_Customer", DbType.Boolean, this._Vehicle_Driven_By_Customer);
            if (this._Vehicle_Driven_By_Customer != false)
                db.AddInParameter(dbCommand, "Not_Driven_By_Customer_Explain", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Not_Driven_By_Customer_Explain", DbType.String, this._Not_Driven_By_Customer_Explain);
            if ((this._Cutomer_Injured != true && this._Cutomer_Injured != false) || this._Vehicle_Driven_By_Customer != true)
                db.AddInParameter(dbCommand, "Cutomer_Injured", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cutomer_Injured", DbType.Boolean, this._Cutomer_Injured);
            if (this._Invoice_Value > 0)
                db.AddInParameter(dbCommand, "Invoice_Value", DbType.Decimal, this._Invoice_Value);
            else
                db.AddInParameter(dbCommand, "Invoice_Value", DbType.Decimal, DBNull.Value);
            if (this._Vehicle_Recovered != true && this._Vehicle_Recovered != false)
                db.AddInParameter(dbCommand, "Vehicle_Recovered", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Vehicle_Recovered", DbType.Boolean, this._Vehicle_Recovered);
            if (this._Dealership_Wish_To_Take_Possession != true && this._Dealership_Wish_To_Take_Possession != false)
                db.AddInParameter(dbCommand, "Dealership_Wish_To_Take_Possession", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Dealership_Wish_To_Take_Possession", DbType.Boolean, this._Dealership_Wish_To_Take_Possession);
            db.AddInParameter(dbCommand, "Loss_Description", DbType.String, this._Loss_Description);
            if (this._Police_Notified != true && this._Police_Notified != false)
                db.AddInParameter(dbCommand, "Police_Notified", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Notified", DbType.Boolean, this._Police_Notified);
            db.AddInParameter(dbCommand, "Police_Report_Number", DbType.String, this._Police_Report_Number);
            if (this._Vehicle_In_Storage != true && this._Vehicle_In_Storage != false)
                db.AddInParameter(dbCommand, "Vehicle_In_Storage", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Vehicle_In_Storage", DbType.Boolean, this._Vehicle_In_Storage);
            if (this._Vehicle_In_Storage != true)
            {
                db.AddInParameter(dbCommand, "Storage_Contact", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "Storage_phone", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "storage_cost", DbType.Decimal, DBNull.Value);
                db.AddInParameter(dbCommand, "storage_Address_1", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "storage_Address_2", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "storage_City", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "storage_State", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "storage_Zip_Code", DbType.String, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Storage_Contact", DbType.String, this._Storage_Contact);
                db.AddInParameter(dbCommand, "Storage_phone", DbType.String, this._Storage_phone);
                if (this._storage_cost > 0)
                    db.AddInParameter(dbCommand, "storage_cost", DbType.Decimal, this._storage_cost);
                else
                    db.AddInParameter(dbCommand, "storage_cost", DbType.Decimal, DBNull.Value);
                db.AddInParameter(dbCommand, "storage_Address_1", DbType.String, this._storage_Address_1);
                db.AddInParameter(dbCommand, "storage_Address_2", DbType.String, this._storage_Address_2);
                db.AddInParameter(dbCommand, "storage_City", DbType.String, this._storage_City);
                db.AddInParameter(dbCommand, "storage_State", DbType.String, this._storage_State);
                db.AddInParameter(dbCommand, "storage_Zip_Code", DbType.String, this._storage_Zip_Code);
            }

            if ((this._Associate_injured != true && this._Associate_injured != false) || this._Driven_By_Associate != true)
                db.AddInParameter(dbCommand, "Associate_injured", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Associate_injured", DbType.Boolean, this._Associate_injured);
            if ((this._drug_test_performed != true && this._drug_test_performed != false) || this._Driven_By_Associate != true)
                db.AddInParameter(dbCommand, "drug_test_performed", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "drug_test_performed", DbType.Boolean, this._drug_test_performed);
            if (this._drug_test_performed == true)
                db.AddInParameter(dbCommand, "drug_test_results", DbType.String, this._drug_test_results);
            else
                db.AddInParameter(dbCommand, "drug_test_results", DbType.String, DBNull.Value);
            if (this._drug_test_performed == false)
                db.AddInParameter(dbCommand, "drug_test_explanation", DbType.String, this._drug_test_explanation);
            else
                db.AddInParameter(dbCommand, "drug_test_explanation", DbType.String, DBNull.Value);
            if (this._Additional_passengers != true && this._Additional_passengers != false)
                db.AddInParameter(dbCommand, "Additional_passengers", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Additional_passengers", DbType.Boolean, this._Additional_passengers);
            if (this._seeking_subrogation != true && this._seeking_subrogation != false)
                db.AddInParameter(dbCommand, "seeking_subrogation", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "seeking_subrogation", DbType.Boolean, this._seeking_subrogation);
            if ((this._Notice_only_claim != true && this._Notice_only_claim != false) || this._seeking_subrogation == true)
                db.AddInParameter(dbCommand, "Notice_only_claim", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Notice_only_claim", DbType.Boolean, this._Notice_only_claim);
            if (this._seeking_subrogation != true)
            {
                db.AddInParameter(dbCommand, "TPI_Carrier_name", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "TPI_Policy_number", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "tpi_phone", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "tpi_contact", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "tpi_Address_1", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "tpi_Address_2", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "tpi_City", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "tpi_State", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "tpi_Zip_Code", DbType.String, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "TPI_Carrier_name", DbType.String, this._TPI_Carrier_name);
                db.AddInParameter(dbCommand, "TPI_Policy_number", DbType.String, this._TPI_Policy_number);
                db.AddInParameter(dbCommand, "tpi_phone", DbType.String, this._tpi_phone);
                db.AddInParameter(dbCommand, "tpi_contact", DbType.String, this._tpi_contact);
                db.AddInParameter(dbCommand, "tpi_Address_1", DbType.String, this._tpi_Address_1);
                db.AddInParameter(dbCommand, "tpi_Address_2", DbType.String, this._tpi_Address_2);
                db.AddInParameter(dbCommand, "tpi_City", DbType.String, this._tpi_City);
                db.AddInParameter(dbCommand, "tpi_State", DbType.String, this._tpi_State);
                db.AddInParameter(dbCommand, "tpi_Zip_Code", DbType.String, this._tpi_Zip_Code);
            }
            if (this._recovered_amount > 0)
                db.AddInParameter(dbCommand, "recovered_amount", DbType.Decimal, this._recovered_amount);
            else
                db.AddInParameter(dbCommand, "recovered_amount", DbType.Decimal, DBNull.Value);
            db.AddInParameter(dbCommand, "Security_Video_Surveillance", DbType.Boolean, _Security_Video_Surveillance);

            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, DateTime.Now);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }


        /// <summary>
        /// Selects a single record from the DPD_FR_Vehicle table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_DPD_FR_Vehicle_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DPD_FR_VehicleSelectByPK");

            db.AddInParameter(dbCommand, "PK_DPD_FR_Vehicle_ID", DbType.Decimal, pK_DPD_FR_Vehicle_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the DPD_FR_Vehicle table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DPD_FR_VehicleSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the DPD_FR_Vehicle table.
        /// </summary>
        public int Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DPD_FR_VehicleUpdate");

            db.AddInParameter(dbCommand, "PK_DPD_FR_Vehicle_ID", DbType.Decimal, this._PK_DPD_FR_Vehicle_ID);
            db.AddInParameter(dbCommand, "FK_DPD_FR_ID", DbType.Decimal, this._FK_DPD_FR_ID);
            db.AddInParameter(dbCommand, "Incident_Type", DbType.String, this._Incident_Type);
            db.AddInParameter(dbCommand, "Make", DbType.String, this._Make);
            db.AddInParameter(dbCommand, "Model", DbType.String, this._Model);
            if (this._Year > 0)
                db.AddInParameter(dbCommand, "Year", DbType.Decimal, this._Year);
            else
                db.AddInParameter(dbCommand, "Year", DbType.Decimal, DBNull.Value);
            db.AddInParameter(dbCommand, "VIN", DbType.String, this._VIN);
            db.AddInParameter(dbCommand, "TypeOfVehicle", DbType.String, this._TypeOfVehicle);
            db.AddInParameter(dbCommand, "Present_Location", DbType.String, this._Present_Location);
            db.AddInParameter(dbCommand, "Present_Address", DbType.String, this._Present_Address);
            db.AddInParameter(dbCommand, "Present_State", DbType.String, this._Present_State);
            db.AddInParameter(dbCommand, "Present_Zip", DbType.String, this._Present_Zip);
            if (this._Damage_Estimate > 0)
                db.AddInParameter(dbCommand, "Damage_Estimate", DbType.Decimal, this._Damage_Estimate);
            else
                db.AddInParameter(dbCommand, "Damage_Estimate", DbType.Decimal, DBNull.Value);
            if (this._Driven_By_Associate != true && this._Driven_By_Associate != false)
                db.AddInParameter(dbCommand, "Driven_By_Associate", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Driven_By_Associate", DbType.Boolean, this._Driven_By_Associate);
            if (!string.IsNullOrEmpty(this._Name))
                db.AddInParameter(dbCommand, "Name", DbType.String, this._Name);
            else
                db.AddInParameter(dbCommand, "Name", DbType.String, DBNull.Value);
            if (!string.IsNullOrEmpty(this._Address))
                db.AddInParameter(dbCommand, "Address", DbType.String, this._Address);
            else
                db.AddInParameter(dbCommand, "Address", DbType.String, DBNull.Value);
            if (!string.IsNullOrEmpty(this._Phone))
                db.AddInParameter(dbCommand, "Phone", DbType.String, this._Phone);
            else
                db.AddInParameter(dbCommand, "Phone", DbType.String, DBNull.Value);
            if (!string.IsNullOrEmpty(this._Vehicle_Owner_Sonic))
                db.AddInParameter(dbCommand, "Vehicle_Owner_Sonic", DbType.String, this._Vehicle_Owner_Sonic);
            else
                db.AddInParameter(dbCommand, "Vehicle_Owner_Sonic", DbType.String, DBNull.Value);
            if (!string.IsNullOrEmpty(this._Vehicle_Owner_Address))
                db.AddInParameter(dbCommand, "Vehicle_Owner_Address", DbType.String, this._Vehicle_Owner_Address);
            else
                db.AddInParameter(dbCommand, "Vehicle_Owner_Address", DbType.String, DBNull.Value);
            if (!string.IsNullOrEmpty(this._Vehicle_Owner_Phone))
                db.AddInParameter(dbCommand, "Vehicle_Owner_Phone", DbType.String, this._Vehicle_Owner_Phone);
            else
                db.AddInParameter(dbCommand, "Vehicle_Owner_Phone", DbType.String, DBNull.Value);
            if ((this._Associate_Cited != true && this._Associate_Cited != false) || this._Driven_By_Associate != true)
                db.AddInParameter(dbCommand, "Associate_Cited", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Associate_Cited", DbType.Boolean, this._Associate_Cited);
            if (this._Associate_Cited != true)
                db.AddInParameter(dbCommand, "Description_Of_Citation", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Description_Of_Citation", DbType.String, this._Description_Of_Citation);
            if ((this._Vehicle_Driven_By_Customer != true && this._Vehicle_Driven_By_Customer != false) || this._Driven_By_Associate == true)
                db.AddInParameter(dbCommand, "Vehicle_Driven_By_Customer", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Vehicle_Driven_By_Customer", DbType.Boolean, this._Vehicle_Driven_By_Customer);
            if (this._Vehicle_Driven_By_Customer != false)
                db.AddInParameter(dbCommand, "Not_Driven_By_Customer_Explain", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Not_Driven_By_Customer_Explain", DbType.String, this._Not_Driven_By_Customer_Explain);
            if ((this._Cutomer_Injured != true && this._Cutomer_Injured != false) || this._Vehicle_Driven_By_Customer != true)
                db.AddInParameter(dbCommand, "Cutomer_Injured", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cutomer_Injured", DbType.Boolean, this._Cutomer_Injured);
            if (this._Invoice_Value > 0)
                db.AddInParameter(dbCommand, "Invoice_Value", DbType.Decimal, this._Invoice_Value);
            else
                db.AddInParameter(dbCommand, "Invoice_Value", DbType.Decimal, DBNull.Value);
            if (this._Vehicle_Recovered != true && this._Vehicle_Recovered != false)
                db.AddInParameter(dbCommand, "Vehicle_Recovered", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Vehicle_Recovered", DbType.Boolean, this._Vehicle_Recovered);
            if (this._Dealership_Wish_To_Take_Possession != true && this._Dealership_Wish_To_Take_Possession != false)
                db.AddInParameter(dbCommand, "Dealership_Wish_To_Take_Possession", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Dealership_Wish_To_Take_Possession", DbType.Boolean, this._Dealership_Wish_To_Take_Possession);
            db.AddInParameter(dbCommand, "Loss_Description", DbType.String, this._Loss_Description);
            if (this._Police_Notified != true && this._Police_Notified != false)
                db.AddInParameter(dbCommand, "Police_Notified", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Notified", DbType.Boolean, this._Police_Notified);
            if (this._Police_Notified != true)
                db.AddInParameter(dbCommand, "Police_Report_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Report_Number", DbType.String, this._Police_Report_Number);
            if (this._Vehicle_In_Storage != true && this._Vehicle_In_Storage != false)
                db.AddInParameter(dbCommand, "Vehicle_In_Storage", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Vehicle_In_Storage", DbType.Boolean, this._Vehicle_In_Storage);
            if (this._Vehicle_In_Storage != true)
            {
                db.AddInParameter(dbCommand, "Storage_Contact", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "Storage_phone", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "storage_cost", DbType.Decimal, DBNull.Value);
                db.AddInParameter(dbCommand, "storage_Address_1", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "storage_Address_2", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "storage_City", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "storage_State", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "storage_Zip_Code", DbType.String, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Storage_Contact", DbType.String, this._Storage_Contact);
                db.AddInParameter(dbCommand, "Storage_phone", DbType.String, this._Storage_phone);
                if (this._storage_cost > 0)
                    db.AddInParameter(dbCommand, "storage_cost", DbType.Decimal, this._storage_cost);
                else
                    db.AddInParameter(dbCommand, "storage_cost", DbType.Decimal, DBNull.Value);
                db.AddInParameter(dbCommand, "storage_Address_1", DbType.String, this._storage_Address_1);
                db.AddInParameter(dbCommand, "storage_Address_2", DbType.String, this._storage_Address_2);
                db.AddInParameter(dbCommand, "storage_City", DbType.String, this._storage_City);
                db.AddInParameter(dbCommand, "storage_State", DbType.String, this._storage_State);
                db.AddInParameter(dbCommand, "storage_Zip_Code", DbType.String, this._storage_Zip_Code);
            }

            if ((this._Associate_injured != true && this._Associate_injured != false) || this._Driven_By_Associate != true)
                db.AddInParameter(dbCommand, "Associate_injured", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Associate_injured", DbType.Boolean, this._Associate_injured);
            if ((this._drug_test_performed != true && this._drug_test_performed != false) || this._Driven_By_Associate != true)
                db.AddInParameter(dbCommand, "drug_test_performed", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "drug_test_performed", DbType.Boolean, this._drug_test_performed);
            if (this._drug_test_performed == true)
                db.AddInParameter(dbCommand, "drug_test_results", DbType.String, this._drug_test_results);
            else
                db.AddInParameter(dbCommand, "drug_test_results", DbType.String, DBNull.Value);
            if (this._drug_test_performed == false)
                db.AddInParameter(dbCommand, "drug_test_explanation", DbType.String, this._drug_test_explanation);
            else
                db.AddInParameter(dbCommand, "drug_test_explanation", DbType.String, DBNull.Value);
            if (this._Additional_passengers != true && this._Additional_passengers != false)
                db.AddInParameter(dbCommand, "Additional_passengers", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Additional_passengers", DbType.Boolean, this._Additional_passengers);
            if (this._seeking_subrogation != true && this._seeking_subrogation != false)
                db.AddInParameter(dbCommand, "seeking_subrogation", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "seeking_subrogation", DbType.Boolean, this._seeking_subrogation);
            if ((this._Notice_only_claim != true && this._Notice_only_claim != false) || this._seeking_subrogation == true)
                db.AddInParameter(dbCommand, "Notice_only_claim", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Notice_only_claim", DbType.Boolean, this._Notice_only_claim);
            if (this._seeking_subrogation != true)
            {
                db.AddInParameter(dbCommand, "TPI_Carrier_name", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "TPI_Policy_number", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "tpi_phone", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "tpi_contact", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "tpi_Address_1", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "tpi_Address_2", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "tpi_City", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "tpi_State", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "tpi_Zip_Code", DbType.String, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "TPI_Carrier_name", DbType.String, this._TPI_Carrier_name);
                db.AddInParameter(dbCommand, "TPI_Policy_number", DbType.String, this._TPI_Policy_number);
                db.AddInParameter(dbCommand, "tpi_phone", DbType.String, this._tpi_phone);
                db.AddInParameter(dbCommand, "tpi_contact", DbType.String, this._tpi_contact);
                db.AddInParameter(dbCommand, "tpi_Address_1", DbType.String, this._tpi_Address_1);
                db.AddInParameter(dbCommand, "tpi_Address_2", DbType.String, this._tpi_Address_2);
                db.AddInParameter(dbCommand, "tpi_City", DbType.String, this._tpi_City);
                db.AddInParameter(dbCommand, "tpi_State", DbType.String, this._tpi_State);
                db.AddInParameter(dbCommand, "tpi_Zip_Code", DbType.String, this._tpi_Zip_Code);
            }
            if (this._recovered_amount > 0)
                db.AddInParameter(dbCommand, "recovered_amount", DbType.Decimal, this._recovered_amount);
            else
                db.AddInParameter(dbCommand, "recovered_amount", DbType.Decimal, DBNull.Value);
            db.AddInParameter(dbCommand, "Security_Video_Surveillance", DbType.Boolean, _Security_Video_Surveillance);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, DateTime.Now);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Deletes a record from the DPD_FR_Vehicle table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_DPD_FR_Vehicle_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DPD_FR_VehicleDeleteByPK");

            db.AddInParameter(dbCommand, "PK_DPD_FR_Vehicle_ID", DbType.Decimal, pK_DPD_FR_Vehicle_ID);

            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// Selects all records from the DPD_FR_Vehicle table By Incident_Type.
        /// </summary>
        /// <returns>Datatable</returns>
        public static DataTable SelectByIncidentType(decimal FK_DPD_FR_ID, string Incident_type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DPD_FR_VehicleGetResultByIncidentType");
            db.AddInParameter(dbCommand, "FK_DPD_FR_ID", DbType.Decimal, FK_DPD_FR_ID);
            db.AddInParameter(dbCommand, "Incident_type", DbType.String, Incident_type);
            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        /// <summary>
        /// Delete all records from the DPD_FR_Vehicle table By Incident_Type.
        /// </summary>
        /// <returns>Datatable</returns>
        public static void DeleteByIncidentType(decimal FK_DPD_FR_ID, string Incident_type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DPD_FR_VehicleDeletetByIncidentTypeandPK");
            db.AddInParameter(dbCommand, "FK_DPD_FR_ID", DbType.Decimal, FK_DPD_FR_ID);
            db.AddInParameter(dbCommand, "Incident_type", DbType.String, Incident_type);
            db.ExecuteNonQuery(dbCommand);
        }

        #endregion
    }
}
