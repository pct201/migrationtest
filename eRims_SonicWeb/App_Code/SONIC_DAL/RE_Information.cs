using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for RE_Information table.
    /// </summary>
    public sealed class RE_Information
    {

        #region Private variables used to hold the property values

        private decimal? _PK_RE_Information;
        private decimal? _FK_LU_Location;
        private decimal? _FK_Building_ID;
        private string _Federal_Id;
        private decimal? _FK_LU_Status;
        private string _Tax_Parcel_Number;
        private decimal? _FK_LU_Lease_Type;
        private string _Landlord;
        private string _Landlord_Location_Address1;
        private string _Landlord_Location_Address2;
        private string _Landlord_Location_City;
        private decimal? _PK_Landlord_Location_State;
        private string _Landlord_Location_Zip_Code;
        private string _Landlord_Mailing_Address1;
        private string _Landlord_Mailing_Address2;
        private string _Landlord_Mailing_City;
        private decimal? _PK_Landlord_Mailing_State;
        private string _Landlord_Mailing_Zip_Code;
        private string _Landlord_Telephone;
        private string _Landlord_Email;
        private string _Sublease;
        private string _Subtenant;
        private string _Lease_Id;
        private DateTime? _Lease_Commencement_Date;
        private decimal? _FK_LU_Project_Type;
        private DateTime? _Lease_Expiration_Date;
        private DateTime? _Date_Acquired;
        private decimal? _Lease_Term_Months;
        private DateTime? _Date_Sold;
        private DateTime? _Prior_Lease_Commencement_Date;
        private string _Renewals;
        private decimal? _Year_Built;
        private DateTime? _Reminder_Date;
        private decimal? _Year_Remodeled;
        private DateTime? _Landlord_Notification_Date;
        private string _Regional_Vice_President;
        private DateTime? _Vacate_Date;
        private string _General_Manager;
        private string _Primary_Use;
        private string _Controller;
        private string _Lease_Codes;
        private string _Loss_Control_Manager;
        private decimal? _Total_Acres;
        private decimal? _Number_of_Buildings;
        private decimal? _Total_Gross_Leaseable_Area;
        private decimal? _Land_Value;
        private string _Landlord_Legal_Entity;
        private string _Amendment_Info;
        private string _Assignment_Info;
        private string _Regional_Controller;
        private string _Updated_By;
        private DateTime? _Update_Date;
        private decimal? _FK_HVAC_Capital;
        private decimal? _FK_HVAC_Repairs;
        private decimal? _FK_Roof_Capital;
        private decimal? _FK_Roof_Repairs;
        private string _Other_Repairs;
        private string _Maintenance_Notes;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_RE_Information value.
        /// </summary>
        public decimal? PK_RE_Information
        {
            get { return _PK_RE_Information; }
            set { _PK_RE_Information = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Location value.
        /// </summary>
        public decimal? FK_LU_Location
        {
            get { return _FK_LU_Location; }
            set { _FK_LU_Location = value; }
        }

        public decimal? FK_Building_ID
        {
            get { return _FK_Building_ID; }
            set { _FK_Building_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Federal_Id value.
        /// </summary>
        public string Federal_Id
        {
            get { return _Federal_Id; }
            set { _Federal_Id = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Status value.
        /// </summary>
        public decimal? FK_LU_Status
        {
            get { return _FK_LU_Status; }
            set { _FK_LU_Status = value; }
        }

        /// <summary>
        /// Gets or sets the Tax_Parcel_Number value.
        /// </summary>
        public string Tax_Parcel_Number
        {
            get { return _Tax_Parcel_Number; }
            set { _Tax_Parcel_Number = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Lease_Type value.
        /// </summary>
        public decimal? FK_LU_Lease_Type
        {
            get { return _FK_LU_Lease_Type; }
            set { _FK_LU_Lease_Type = value; }
        }

        /// <summary>
        /// Gets or sets the Landlord value.
        /// </summary>
        public string Landlord
        {
            get { return _Landlord; }
            set { _Landlord = value; }
        }

        /// <summary>
        /// Gets or sets the Landlord_Location_Address1 value.
        /// </summary>
        public string Landlord_Location_Address1
        {
            get { return _Landlord_Location_Address1; }
            set { _Landlord_Location_Address1 = value; }
        }

        /// <summary>
        /// Gets or sets the Landlord_Location_Address2 value.
        /// </summary>
        public string Landlord_Location_Address2
        {
            get { return _Landlord_Location_Address2; }
            set { _Landlord_Location_Address2 = value; }
        }

        /// <summary>
        /// Gets or sets the Landlord_Location_City value.
        /// </summary>
        public string Landlord_Location_City
        {
            get { return _Landlord_Location_City; }
            set { _Landlord_Location_City = value; }
        }

        /// <summary>
        /// Gets or sets the PK_Landlord_Location_State value.
        /// </summary>
        public decimal? PK_Landlord_Location_State
        {
            get { return _PK_Landlord_Location_State; }
            set { _PK_Landlord_Location_State = value; }
        }

        /// <summary>
        /// Gets or sets the Landlord_Location_Zip_Code value.
        /// </summary>
        public string Landlord_Location_Zip_Code
        {
            get { return _Landlord_Location_Zip_Code; }
            set { _Landlord_Location_Zip_Code = value; }
        }

        /// <summary>
        /// Gets or sets the Landlord_Mailing_Address1 value.
        /// </summary>
        public string Landlord_Mailing_Address1
        {
            get { return _Landlord_Mailing_Address1; }
            set { _Landlord_Mailing_Address1 = value; }
        }

        /// <summary>
        /// Gets or sets the Landlord_Mailing_Address2 value.
        /// </summary>
        public string Landlord_Mailing_Address2
        {
            get { return _Landlord_Mailing_Address2; }
            set { _Landlord_Mailing_Address2 = value; }
        }

        /// <summary>
        /// Gets or sets the Landlord_Mailing_City value.
        /// </summary>
        public string Landlord_Mailing_City
        {
            get { return _Landlord_Mailing_City; }
            set { _Landlord_Mailing_City = value; }
        }

        /// <summary>
        /// Gets or sets the PK_Landlord_Mailing_State value.
        /// </summary>
        public decimal? PK_Landlord_Mailing_State
        {
            get { return _PK_Landlord_Mailing_State; }
            set { _PK_Landlord_Mailing_State = value; }
        }

        /// <summary>
        /// Gets or sets the Landlord_Mailing_Zip_Code value.
        /// </summary>
        public string Landlord_Mailing_Zip_Code
        {
            get { return _Landlord_Mailing_Zip_Code; }
            set { _Landlord_Mailing_Zip_Code = value; }
        }

        /// <summary>
        /// Gets or sets the Landlord_Telephone value.
        /// </summary>
        public string Landlord_Telephone
        {
            get { return _Landlord_Telephone; }
            set { _Landlord_Telephone = value; }
        }

        /// <summary>
        /// Gets or sets the Landlord_Email value.
        /// </summary>
        public string Landlord_Email
        {
            get { return _Landlord_Email; }
            set { _Landlord_Email = value; }
        }

        /// <summary>
        /// Gets or sets the Sublease value.
        /// </summary>
        public string Sublease
        {
            get { return _Sublease; }
            set { _Sublease = value; }
        }

        /// <summary>
        /// Gets or sets the Subtenant value.
        /// </summary>
        public string Subtenant
        {
            get { return _Subtenant; }
            set { _Subtenant = value; }
        }

        /// <summary>
        /// Gets or sets the Lease_Id value.
        /// </summary>
        public string Lease_Id
        {
            get { return _Lease_Id; }
            set { _Lease_Id = value; }
        }

        /// <summary>
        /// Gets or sets the Lease_Commencement_Date value.
        /// </summary>
        public DateTime? Lease_Commencement_Date
        {
            get { return _Lease_Commencement_Date; }
            set { _Lease_Commencement_Date = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Project_Type value.
        /// </summary>
        public decimal? FK_LU_Project_Type
        {
            get { return _FK_LU_Project_Type; }
            set { _FK_LU_Project_Type = value; }
        }

        /// <summary>
        /// Gets or sets the Lease_Expiration_Date value.
        /// </summary>
        public DateTime? Lease_Expiration_Date
        {
            get { return _Lease_Expiration_Date; }
            set { _Lease_Expiration_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Acquired value.
        /// </summary>
        public DateTime? Date_Acquired
        {
            get { return _Date_Acquired; }
            set { _Date_Acquired = value; }
        }

        /// <summary>
        /// Gets or sets the Lease_Term_Months value.
        /// </summary>
        public decimal? Lease_Term_Months
        {
            get { return _Lease_Term_Months; }
            set { _Lease_Term_Months = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Sold value.
        /// </summary>
        public DateTime? Date_Sold
        {
            get { return _Date_Sold; }
            set { _Date_Sold = value; }
        }

        /// <summary>
        /// Gets or sets the Prior_Lease_Commencement_Date value.
        /// </summary>
        public DateTime? Prior_Lease_Commencement_Date
        {
            get { return _Prior_Lease_Commencement_Date; }
            set { _Prior_Lease_Commencement_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Renewals value.
        /// </summary>
        public string Renewals
        {
            get { return _Renewals; }
            set { _Renewals = value; }
        }

        /// <summary>
        /// Gets or sets the Year_Built value.
        /// </summary>
        public decimal? Year_Built
        {
            get { return _Year_Built; }
            set { _Year_Built = value; }
        }

        /// <summary>
        /// Gets or sets the Reminder_Date value.
        /// </summary>
        public DateTime? Reminder_Date
        {
            get { return _Reminder_Date; }
            set { _Reminder_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Year_Remodeled value.
        /// </summary>
        public decimal? Year_Remodeled
        {
            get { return _Year_Remodeled; }
            set { _Year_Remodeled = value; }
        }

        /// <summary>
        /// Gets or sets the Landlord_Notification_Date value.
        /// </summary>
        public DateTime? Landlord_Notification_Date
        {
            get { return _Landlord_Notification_Date; }
            set { _Landlord_Notification_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Regional_Vice_President value.
        /// </summary>
        public string Regional_Vice_President
        {
            get { return _Regional_Vice_President; }
            set { _Regional_Vice_President = value; }
        }

        /// <summary>
        /// Gets or sets the Vacate_Date value.
        /// </summary>
        public DateTime? Vacate_Date
        {
            get { return _Vacate_Date; }
            set { _Vacate_Date = value; }
        }

        /// <summary>
        /// Gets or sets the General_Manager value.
        /// </summary>
        public string General_Manager
        {
            get { return _General_Manager; }
            set { _General_Manager = value; }
        }

        /// <summary>
        /// Gets or sets the Primary_Use value.
        /// </summary>
        public string Primary_Use
        {
            get { return _Primary_Use; }
            set { _Primary_Use = value; }
        }

        /// <summary>
        /// Gets or sets the Controller value.
        /// </summary>
        public string Controller
        {
            get { return _Controller; }
            set { _Controller = value; }
        }

        /// <summary>
        /// Gets or sets the Lease_Codes value.
        /// </summary>
        public string Lease_Codes
        {
            get { return _Lease_Codes; }
            set { _Lease_Codes = value; }
        }

        /// <summary>
        /// Gets or sets the Loss_Control_Manager value.
        /// </summary>
        public string Loss_Control_Manager
        {
            get { return _Loss_Control_Manager; }
            set { _Loss_Control_Manager = value; }
        }

        /// <summary>
        /// Gets or sets the Total_Acres value.
        /// </summary>
        public decimal? Total_Acres
        {
            get { return _Total_Acres; }
            set { _Total_Acres = value; }
        }

        /// <summary>
        /// Gets or sets the Number_of_Buildings value.
        /// </summary>
        public decimal? Number_of_Buildings
        {
            get { return _Number_of_Buildings; }
            set { _Number_of_Buildings = value; }
        }

        /// <summary>
        /// Gets or sets the Total_Gross_Leaseable_Area value.
        /// </summary>
        public decimal? Total_Gross_Leaseable_Area
        {
            get { return _Total_Gross_Leaseable_Area; }
            set { _Total_Gross_Leaseable_Area = value; }
        }

        /// <summary>
        /// Gets or sets the Land_Value value.
        /// </summary>
        public decimal? Land_Value
        {
            get { return _Land_Value; }
            set { _Land_Value = value; }
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
        public string Landlord_Legal_Entity
        {
            get { return _Landlord_Legal_Entity; }
            set { _Landlord_Legal_Entity = value; }
        }
        public string Amendment_Info
        {
            get { return _Amendment_Info; }
            set { _Amendment_Info = value; }
        }

        public string Assignment_Info
        {
            get { return _Assignment_Info; }
            set { _Assignment_Info = value; }
        }
        /// <summary>
        /// Gets or sets the Regional_Controller value.
        /// </summary>
        public string Regional_Controller
        {
            get { return _Regional_Controller; }
            set { _Regional_Controller = value; }
        }

        /// <summary>
        /// Gets or sets the FK_HVAC_Capital.
        /// </summary>
        public decimal? FK_HVAC_Capital
        {
            get { return _FK_HVAC_Capital; }
            set { _FK_HVAC_Capital = value; }
        }

        /// <summary>
        /// Gets or sets the FK_HVAC_Repairs.
        /// </summary>
        public decimal? FK_HVAC_Repairs
        {
            get { return _FK_HVAC_Repairs; }
            set { _FK_HVAC_Repairs = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Roof_Capital.
        /// </summary>
        public decimal? FK_Roof_Capital
        {
            get { return _FK_Roof_Capital; }
            set { _FK_Roof_Capital = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Roof_Repairs.
        /// </summary>
        public decimal? FK_Roof_Repairs
        {
            get { return _FK_Roof_Repairs; }
            set { _FK_Roof_Repairs = value; }
        }

        /// <summary>
        /// Gets or sets the Other_Repairs.
        /// </summary>
        public string Other_Repairs
        {
            get { return _Other_Repairs; }
            set { _Other_Repairs = value; }
        }

        /// <summary>
        /// Gets or sets the Maintenance_Notes.
        /// </summary>
        public string Maintenance_Notes
        {
            get { return _Maintenance_Notes; }
            set { _Maintenance_Notes = value; }
        }

        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the RE_Information class with default value.
        /// </summary>
        public RE_Information()
        {
            setDefaultValues();
        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the RE_Information class based on Primary Key.
        /// </summary>
        public RE_Information(decimal pK_RE_Information)
        {
            DataTable dtRE_Information = SelectByPK(pK_RE_Information).Tables[0];

            if (dtRE_Information.Rows.Count == 1)
            {
                DataRow drRE_Information = dtRE_Information.Rows[0];
                if (drRE_Information["PK_RE_Information"] == DBNull.Value)
                    this._PK_RE_Information = null;
                else
                    this._PK_RE_Information = (decimal?)drRE_Information["PK_RE_Information"];

                if (drRE_Information["FK_LU_Location"] == DBNull.Value)
                    this._FK_LU_Location = null;
                else
                    this._FK_LU_Location = (decimal?)drRE_Information["FK_LU_Location"];

                if (drRE_Information["FK_Building_ID"] == DBNull.Value)
                    this._FK_Building_ID = null;
                else
                    this._FK_Building_ID = (decimal?)drRE_Information["FK_Building_ID"];

                if (drRE_Information["Federal_Id"] == DBNull.Value)
                    this._Federal_Id = null;
                else
                    this._Federal_Id = (string)drRE_Information["Federal_Id"];

                if (drRE_Information["FK_LU_Status"] == DBNull.Value)
                    this._FK_LU_Status = null;
                else
                    this._FK_LU_Status = (decimal?)drRE_Information["FK_LU_Status"];

                if (drRE_Information["Tax_Parcel_Number"] == DBNull.Value)
                    this._Tax_Parcel_Number = null;
                else
                    this._Tax_Parcel_Number = (string)drRE_Information["Tax_Parcel_Number"];

                if (drRE_Information["FK_LU_Lease_Type"] == DBNull.Value)
                    this._FK_LU_Lease_Type = null;
                else
                    this._FK_LU_Lease_Type = (decimal?)drRE_Information["FK_LU_Lease_Type"];

                if (drRE_Information["Landlord"] == DBNull.Value)
                    this._Landlord = null;
                else
                    this._Landlord = (string)drRE_Information["Landlord"];

                if (drRE_Information["Landlord_Location_Address1"] == DBNull.Value)
                    this._Landlord_Location_Address1 = null;
                else
                    this._Landlord_Location_Address1 = (string)drRE_Information["Landlord_Location_Address1"];

                if (drRE_Information["Landlord_Location_Address2"] == DBNull.Value)
                    this._Landlord_Location_Address2 = null;
                else
                    this._Landlord_Location_Address2 = (string)drRE_Information["Landlord_Location_Address2"];

                if (drRE_Information["Landlord_Location_City"] == DBNull.Value)
                    this._Landlord_Location_City = null;
                else
                    this._Landlord_Location_City = (string)drRE_Information["Landlord_Location_City"];

                if (drRE_Information["PK_Landlord_Location_State"] == DBNull.Value)
                    this._PK_Landlord_Location_State = null;
                else
                    this._PK_Landlord_Location_State = (decimal?)drRE_Information["PK_Landlord_Location_State"];

                if (drRE_Information["Landlord_Location_Zip_Code"] == DBNull.Value)
                    this._Landlord_Location_Zip_Code = null;
                else
                    this._Landlord_Location_Zip_Code = (string)drRE_Information["Landlord_Location_Zip_Code"];

                if (drRE_Information["Landlord_Mailing_Address1"] == DBNull.Value)
                    this._Landlord_Mailing_Address1 = null;
                else
                    this._Landlord_Mailing_Address1 = (string)drRE_Information["Landlord_Mailing_Address1"];

                if (drRE_Information["Landlord_Mailing_Address2"] == DBNull.Value)
                    this._Landlord_Mailing_Address2 = null;
                else
                    this._Landlord_Mailing_Address2 = (string)drRE_Information["Landlord_Mailing_Address2"];

                if (drRE_Information["Landlord_Mailing_City"] == DBNull.Value)
                    this._Landlord_Mailing_City = null;
                else
                    this._Landlord_Mailing_City = (string)drRE_Information["Landlord_Mailing_City"];

                if (drRE_Information["PK_Landlord_Mailing_State"] == DBNull.Value)
                    this._PK_Landlord_Mailing_State = null;
                else
                    this._PK_Landlord_Mailing_State = (decimal?)drRE_Information["PK_Landlord_Mailing_State"];

                if (drRE_Information["Landlord_Mailing_Zip_Code"] == DBNull.Value)
                    this._Landlord_Mailing_Zip_Code = null;
                else
                    this._Landlord_Mailing_Zip_Code = (string)drRE_Information["Landlord_Mailing_Zip_Code"];

                if (drRE_Information["Landlord_Telephone"] == DBNull.Value)
                    this._Landlord_Telephone = null;
                else
                    this._Landlord_Telephone = (string)drRE_Information["Landlord_Telephone"];

                if (drRE_Information["Landlord_Email"] == DBNull.Value)
                    this._Landlord_Email = null;
                else
                    this._Landlord_Email = (string)drRE_Information["Landlord_Email"];

                if (drRE_Information["Sublease"] == DBNull.Value)
                    this._Sublease = null;
                else
                    this._Sublease = (string)drRE_Information["Sublease"];

                if (drRE_Information["Subtenant"] == DBNull.Value)
                    this._Subtenant = null;
                else
                    this._Subtenant = (string)drRE_Information["Subtenant"];

                if (drRE_Information["Lease_Id"] == DBNull.Value)
                    this._Lease_Id = null;
                else
                    this._Lease_Id = (string)drRE_Information["Lease_Id"];

                if (drRE_Information["Lease_Commencement_Date"] == DBNull.Value)
                    this._Lease_Commencement_Date = null;
                else
                    this._Lease_Commencement_Date = (DateTime?)drRE_Information["Lease_Commencement_Date"];

                if (drRE_Information["FK_LU_Project_Type"] == DBNull.Value)
                    this._FK_LU_Project_Type = null;
                else
                    this._FK_LU_Project_Type = (decimal?)drRE_Information["FK_LU_Project_Type"];

                if (drRE_Information["Lease_Expiration_Date"] == DBNull.Value)
                    this._Lease_Expiration_Date = null;
                else
                    this._Lease_Expiration_Date = (DateTime?)drRE_Information["Lease_Expiration_Date"];

                if (drRE_Information["Date_Acquired"] == DBNull.Value)
                    this._Date_Acquired = null;
                else
                    this._Date_Acquired = (DateTime?)drRE_Information["Date_Acquired"];

                if (drRE_Information["Lease_Term_Months"] == DBNull.Value)
                    this._Lease_Term_Months = null;
                else
                    this._Lease_Term_Months = (decimal?)drRE_Information["Lease_Term_Months"];

                if (drRE_Information["Date_Sold"] == DBNull.Value)
                    this._Date_Sold = null;
                else
                    this._Date_Sold = (DateTime?)drRE_Information["Date_Sold"];

                if (drRE_Information["Prior_Lease_Commencement_Date"] == DBNull.Value)
                    this._Prior_Lease_Commencement_Date = null;
                else
                    this._Prior_Lease_Commencement_Date = (DateTime?)drRE_Information["Prior_Lease_Commencement_Date"];

                if (drRE_Information["Renewals"] == DBNull.Value)
                    this._Renewals = null;
                else
                    this._Renewals = (string)drRE_Information["Renewals"];

                if (drRE_Information["Year_Built"] == DBNull.Value)
                    this._Year_Built = null;
                else
                    this._Year_Built = (decimal?)drRE_Information["Year_Built"];

                if (drRE_Information["Reminder_Date"] == DBNull.Value)
                    this._Reminder_Date = null;
                else
                    this._Reminder_Date = (DateTime?)drRE_Information["Reminder_Date"];

                if (drRE_Information["Year_Remodeled"] == DBNull.Value)
                    this._Year_Remodeled = null;
                else
                    this._Year_Remodeled = (decimal?)drRE_Information["Year_Remodeled"];

                if (drRE_Information["Landlord_Notification_Date"] == DBNull.Value)
                    this._Landlord_Notification_Date = null;
                else
                    this._Landlord_Notification_Date = (DateTime?)drRE_Information["Landlord_Notification_Date"];

                if (drRE_Information["Regional_Vice_President"] == DBNull.Value)
                    this._Regional_Vice_President = null;
                else
                    this._Regional_Vice_President = (string)drRE_Information["Regional_Vice_President"];

                if (drRE_Information["Vacate_Date"] == DBNull.Value)
                    this._Vacate_Date = null;
                else
                    this._Vacate_Date = (DateTime?)drRE_Information["Vacate_Date"];

                if (drRE_Information["General_Manager"] == DBNull.Value)
                    this._General_Manager = null;
                else
                    this._General_Manager = (string)drRE_Information["General_Manager"];

                if (drRE_Information["Primary_Use"] == DBNull.Value)
                    this._Primary_Use = null;
                else
                    this._Primary_Use = (string)drRE_Information["Primary_Use"];

                if (drRE_Information["Controller"] == DBNull.Value)
                    this._Controller = null;
                else
                    this._Controller = (string)drRE_Information["Controller"];

                if (drRE_Information["Lease_Codes"] == DBNull.Value)
                    this._Lease_Codes = null;
                else
                    this._Lease_Codes = (string)drRE_Information["Lease_Codes"];

                if (drRE_Information["Loss_Control_Manager"] == DBNull.Value)
                    this._Loss_Control_Manager = null;
                else
                    this._Loss_Control_Manager = (string)drRE_Information["Loss_Control_Manager"];

                if (drRE_Information["Total_Acres"] == DBNull.Value)
                    this._Total_Acres = null;
                else
                    this._Total_Acres = (decimal?)drRE_Information["Total_Acres"];

                if (drRE_Information["Number_of_Buildings"] == DBNull.Value)
                    this._Number_of_Buildings = null;
                else
                    this._Number_of_Buildings = (decimal?)drRE_Information["Number_of_Buildings"];

                if (drRE_Information["Total_Gross_Leaseable_Area"] == DBNull.Value)
                    this._Total_Gross_Leaseable_Area = null;
                else
                    this._Total_Gross_Leaseable_Area = (decimal?)drRE_Information["Total_Gross_Leaseable_Area"];

                if (drRE_Information["Land_Value"] == DBNull.Value)
                    this._Land_Value = null;
                else
                    this._Land_Value = (decimal?)drRE_Information["Land_Value"];

                this._Landlord_Legal_Entity = Convert.ToString(drRE_Information["Landlord_Legal_Entity"]);
                this._Amendment_Info = Convert.ToString(drRE_Information["Amendment_Info"]);
                this._Assignment_Info = Convert.ToString(drRE_Information["Assignment_Info"]);

                if (drRE_Information["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drRE_Information["Updated_By"];

                if (drRE_Information["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drRE_Information["Update_Date"];
                this._Regional_Controller = Convert.ToString(drRE_Information["Regional_Controller"]);

                if (drRE_Information["FK_HVAC_Capital"] == DBNull.Value)
                    this._FK_HVAC_Capital = null;
                else
                    this._FK_HVAC_Capital = (decimal?)drRE_Information["FK_HVAC_Capital"];

                if (drRE_Information["FK_HVAC_Repairs"] == DBNull.Value)
                    this._FK_HVAC_Repairs = null;
                else
                    this._FK_HVAC_Repairs = (decimal?)drRE_Information["FK_HVAC_Repairs"];

                if (drRE_Information["FK_Roof_Capital"] == DBNull.Value)
                    this._FK_Roof_Capital = null;
                else
                    this._FK_Roof_Capital = (decimal?)drRE_Information["FK_Roof_Capital"];

                if (drRE_Information["FK_Roof_Repairs"] == DBNull.Value)
                    this._FK_Roof_Repairs = null;
                else
                    this._FK_Roof_Repairs = (decimal?)drRE_Information["FK_Roof_Repairs"];

                if (drRE_Information["Other_Repairs"] == DBNull.Value)
                    this._Other_Repairs = null;
                else
                    this._Other_Repairs = (string)drRE_Information["Other_Repairs"];

                if (drRE_Information["Maintenance_Notes"] == DBNull.Value)
                    this._Maintenance_Notes = null;
                else
                    this._Maintenance_Notes = (string)drRE_Information["Maintenance_Notes"];

            }
            else
            {
                setDefaultValues();
            }

        }

        /// <summary>
        /// Initializes a new instance of the RE_Information class based on Primary Key.
        /// </summary>
        public RE_Information(decimal fk_Lu_Location, bool status)
        {
            DataTable dtRE_Information = SelectByFK_Location(fk_Lu_Location).Tables[0];

            if (dtRE_Information.Rows.Count == 1)
            {
                DataRow drRE_Information = dtRE_Information.Rows[0];
                if (drRE_Information["PK_RE_Information"] == DBNull.Value)
                    this._PK_RE_Information = null;
                else
                    this._PK_RE_Information = (decimal?)drRE_Information["PK_RE_Information"];

                if (drRE_Information["FK_LU_Location"] == DBNull.Value)
                    this._FK_LU_Location = null;
                else
                    this._FK_LU_Location = (decimal?)drRE_Information["FK_LU_Location"];

                if (drRE_Information["FK_Building_ID"] == DBNull.Value)
                    this._FK_Building_ID = null;
                else
                    this._FK_Building_ID = (decimal?)drRE_Information["FK_Building_ID"];

                if (drRE_Information["Federal_Id"] == DBNull.Value)
                    this._Federal_Id = null;
                else
                    this._Federal_Id = (string)drRE_Information["Federal_Id"];

                if (drRE_Information["FK_LU_Status"] == DBNull.Value)
                    this._FK_LU_Status = null;
                else
                    this._FK_LU_Status = (decimal?)drRE_Information["FK_LU_Status"];

                if (drRE_Information["Tax_Parcel_Number"] == DBNull.Value)
                    this._Tax_Parcel_Number = null;
                else
                    this._Tax_Parcel_Number = (string)drRE_Information["Tax_Parcel_Number"];

                if (drRE_Information["FK_LU_Lease_Type"] == DBNull.Value)
                    this._FK_LU_Lease_Type = null;
                else
                    this._FK_LU_Lease_Type = (decimal?)drRE_Information["FK_LU_Lease_Type"];

                if (drRE_Information["Landlord"] == DBNull.Value)
                    this._Landlord = null;
                else
                    this._Landlord = (string)drRE_Information["Landlord"];

                if (drRE_Information["Landlord_Location_Address1"] == DBNull.Value)
                    this._Landlord_Location_Address1 = null;
                else
                    this._Landlord_Location_Address1 = (string)drRE_Information["Landlord_Location_Address1"];

                if (drRE_Information["Landlord_Location_Address2"] == DBNull.Value)
                    this._Landlord_Location_Address2 = null;
                else
                    this._Landlord_Location_Address2 = (string)drRE_Information["Landlord_Location_Address2"];

                if (drRE_Information["Landlord_Location_City"] == DBNull.Value)
                    this._Landlord_Location_City = null;
                else
                    this._Landlord_Location_City = (string)drRE_Information["Landlord_Location_City"];

                if (drRE_Information["PK_Landlord_Location_State"] == DBNull.Value)
                    this._PK_Landlord_Location_State = null;
                else
                    this._PK_Landlord_Location_State = (decimal?)drRE_Information["PK_Landlord_Location_State"];

                if (drRE_Information["Landlord_Location_Zip_Code"] == DBNull.Value)
                    this._Landlord_Location_Zip_Code = null;
                else
                    this._Landlord_Location_Zip_Code = (string)drRE_Information["Landlord_Location_Zip_Code"];

                if (drRE_Information["Landlord_Mailing_Address1"] == DBNull.Value)
                    this._Landlord_Mailing_Address1 = null;
                else
                    this._Landlord_Mailing_Address1 = (string)drRE_Information["Landlord_Mailing_Address1"];

                if (drRE_Information["Landlord_Mailing_Address2"] == DBNull.Value)
                    this._Landlord_Mailing_Address2 = null;
                else
                    this._Landlord_Mailing_Address2 = (string)drRE_Information["Landlord_Mailing_Address2"];

                if (drRE_Information["Landlord_Mailing_City"] == DBNull.Value)
                    this._Landlord_Mailing_City = null;
                else
                    this._Landlord_Mailing_City = (string)drRE_Information["Landlord_Mailing_City"];

                if (drRE_Information["PK_Landlord_Mailing_State"] == DBNull.Value)
                    this._PK_Landlord_Mailing_State = null;
                else
                    this._PK_Landlord_Mailing_State = (decimal?)drRE_Information["PK_Landlord_Mailing_State"];

                if (drRE_Information["Landlord_Mailing_Zip_Code"] == DBNull.Value)
                    this._Landlord_Mailing_Zip_Code = null;
                else
                    this._Landlord_Mailing_Zip_Code = (string)drRE_Information["Landlord_Mailing_Zip_Code"];

                if (drRE_Information["Landlord_Telephone"] == DBNull.Value)
                    this._Landlord_Telephone = null;
                else
                    this._Landlord_Telephone = (string)drRE_Information["Landlord_Telephone"];

                if (drRE_Information["Landlord_Email"] == DBNull.Value)
                    this._Landlord_Email = null;
                else
                    this._Landlord_Email = (string)drRE_Information["Landlord_Email"];

                if (drRE_Information["Sublease"] == DBNull.Value)
                    this._Sublease = null;
                else
                    this._Sublease = (string)drRE_Information["Sublease"];

                if (drRE_Information["Subtenant"] == DBNull.Value)
                    this._Subtenant = null;
                else
                    this._Subtenant = (string)drRE_Information["Subtenant"];

                if (drRE_Information["Lease_Id"] == DBNull.Value)
                    this._Lease_Id = null;
                else
                    this._Lease_Id = (string)drRE_Information["Lease_Id"];

                if (drRE_Information["Lease_Commencement_Date"] == DBNull.Value)
                    this._Lease_Commencement_Date = null;
                else
                    this._Lease_Commencement_Date = (DateTime?)drRE_Information["Lease_Commencement_Date"];

                if (drRE_Information["FK_LU_Project_Type"] == DBNull.Value)
                    this._FK_LU_Project_Type = null;
                else
                    this._FK_LU_Project_Type = (decimal?)drRE_Information["FK_LU_Project_Type"];

                if (drRE_Information["Lease_Expiration_Date"] == DBNull.Value)
                    this._Lease_Expiration_Date = null;
                else
                    this._Lease_Expiration_Date = (DateTime?)drRE_Information["Lease_Expiration_Date"];

                if (drRE_Information["Date_Acquired"] == DBNull.Value)
                    this._Date_Acquired = null;
                else
                    this._Date_Acquired = (DateTime?)drRE_Information["Date_Acquired"];

                if (drRE_Information["Lease_Term_Months"] == DBNull.Value)
                    this._Lease_Term_Months = null;
                else
                    this._Lease_Term_Months = (decimal?)drRE_Information["Lease_Term_Months"];

                if (drRE_Information["Date_Sold"] == DBNull.Value)
                    this._Date_Sold = null;
                else
                    this._Date_Sold = (DateTime?)drRE_Information["Date_Sold"];

                if (drRE_Information["Prior_Lease_Commencement_Date"] == DBNull.Value)
                    this._Prior_Lease_Commencement_Date = null;
                else
                    this._Prior_Lease_Commencement_Date = (DateTime?)drRE_Information["Prior_Lease_Commencement_Date"];

                if (drRE_Information["Renewals"] == DBNull.Value)
                    this._Renewals = null;
                else
                    this._Renewals = (string)drRE_Information["Renewals"];

                if (drRE_Information["Year_Built"] == DBNull.Value)
                    this._Year_Built = null;
                else
                    this._Year_Built = (decimal?)drRE_Information["Year_Built"];

                if (drRE_Information["Reminder_Date"] == DBNull.Value)
                    this._Reminder_Date = null;
                else
                    this._Reminder_Date = (DateTime?)drRE_Information["Reminder_Date"];

                if (drRE_Information["Year_Remodeled"] == DBNull.Value)
                    this._Year_Remodeled = null;
                else
                    this._Year_Remodeled = (decimal?)drRE_Information["Year_Remodeled"];

                if (drRE_Information["Landlord_Notification_Date"] == DBNull.Value)
                    this._Landlord_Notification_Date = null;
                else
                    this._Landlord_Notification_Date = (DateTime?)drRE_Information["Landlord_Notification_Date"];

                if (drRE_Information["Regional_Vice_President"] == DBNull.Value)
                    this._Regional_Vice_President = null;
                else
                    this._Regional_Vice_President = (string)drRE_Information["Regional_Vice_President"];

                if (drRE_Information["Vacate_Date"] == DBNull.Value)
                    this._Vacate_Date = null;
                else
                    this._Vacate_Date = (DateTime?)drRE_Information["Vacate_Date"];

                if (drRE_Information["General_Manager"] == DBNull.Value)
                    this._General_Manager = null;
                else
                    this._General_Manager = (string)drRE_Information["General_Manager"];

                if (drRE_Information["Primary_Use"] == DBNull.Value)
                    this._Primary_Use = null;
                else
                    this._Primary_Use = (string)drRE_Information["Primary_Use"];

                if (drRE_Information["Controller"] == DBNull.Value)
                    this._Controller = null;
                else
                    this._Controller = (string)drRE_Information["Controller"];

                if (drRE_Information["Lease_Codes"] == DBNull.Value)
                    this._Lease_Codes = null;
                else
                    this._Lease_Codes = (string)drRE_Information["Lease_Codes"];

                if (drRE_Information["Loss_Control_Manager"] == DBNull.Value)
                    this._Loss_Control_Manager = null;
                else
                    this._Loss_Control_Manager = (string)drRE_Information["Loss_Control_Manager"];

                if (drRE_Information["Total_Acres"] == DBNull.Value)
                    this._Total_Acres = null;
                else
                    this._Total_Acres = (decimal?)drRE_Information["Total_Acres"];

                if (drRE_Information["Number_of_Buildings"] == DBNull.Value)
                    this._Number_of_Buildings = null;
                else
                    this._Number_of_Buildings = (decimal?)drRE_Information["Number_of_Buildings"];

                if (drRE_Information["Total_Gross_Leaseable_Area"] == DBNull.Value)
                    this._Total_Gross_Leaseable_Area = null;
                else
                    this._Total_Gross_Leaseable_Area = (decimal?)drRE_Information["Total_Gross_Leaseable_Area"];

                if (drRE_Information["Land_Value"] == DBNull.Value)
                    this._Land_Value = null;
                else
                    this._Land_Value = (decimal?)drRE_Information["Land_Value"];

                this._Landlord_Legal_Entity = Convert.ToString(drRE_Information["Landlord_Legal_Entity"]);
                this._Amendment_Info = Convert.ToString(drRE_Information["Amendment_Info"]);
                this._Assignment_Info = Convert.ToString(drRE_Information["Assignment_Info"]);

                if (drRE_Information["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drRE_Information["Updated_By"];

                if (drRE_Information["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drRE_Information["Update_Date"];

                this._Regional_Controller = Convert.ToString(drRE_Information["Regional_Controller"]);

                if (drRE_Information["FK_HVAC_Capital"] == DBNull.Value)
                    this._FK_HVAC_Capital = null;
                else
                    this._FK_HVAC_Capital = (decimal?)drRE_Information["FK_HVAC_Capital"];

                if (drRE_Information["FK_HVAC_Repairs"] == DBNull.Value)
                    this._FK_HVAC_Repairs = null;
                else
                    this._FK_HVAC_Repairs = (decimal?)drRE_Information["FK_HVAC_Repairs"];

                if (drRE_Information["FK_Roof_Capital"] == DBNull.Value)
                    this._FK_Roof_Capital = null;
                else
                    this._FK_Roof_Capital = (decimal?)drRE_Information["FK_Roof_Capital"];

                if (drRE_Information["FK_Roof_Repairs"] == DBNull.Value)
                    this._FK_Roof_Repairs = null;
                else
                    this._FK_Roof_Repairs = (decimal?)drRE_Information["FK_Roof_Repairs"];

                if (drRE_Information["Other_Repairs"] == DBNull.Value)
                    this._Other_Repairs = null;
                else
                    this._Other_Repairs = (string)drRE_Information["Other_Repairs"];

                if (drRE_Information["Maintenance_Notes"] == DBNull.Value)
                    this._Maintenance_Notes = null;
                else
                    this._Maintenance_Notes = (string)drRE_Information["Maintenance_Notes"];
            }
            else
            {
                setDefaultValues();
            }

        }

        #endregion

        private void setDefaultValues()
        {
            this._PK_RE_Information = null;
            this._FK_LU_Location = null;
            this._FK_Building_ID = null;
            this._Federal_Id = null;
            this._FK_LU_Status = null;
            this._Tax_Parcel_Number = null;
            this._FK_LU_Lease_Type = null;
            this._Landlord = null;
            this._Landlord_Location_Address1 = null;
            this._Landlord_Location_Address2 = null;
            this._Landlord_Location_City = null;
            this._PK_Landlord_Location_State = null;
            this._Landlord_Location_Zip_Code = null;
            this._Landlord_Mailing_Address1 = null;
            this._Landlord_Mailing_Address2 = null;
            this._Landlord_Mailing_City = null;
            this._PK_Landlord_Mailing_State = null;
            this._Landlord_Mailing_Zip_Code = null;
            this._Landlord_Telephone = null;
            this._Landlord_Email = null;
            this._Sublease = null;
            this._Subtenant = null;
            this._Lease_Id = null;
            this._Lease_Commencement_Date = null;
            this._FK_LU_Project_Type = null;
            this._Lease_Expiration_Date = null;
            this._Date_Acquired = null;
            this._Lease_Term_Months = null;
            this._Date_Sold = null;
            this._Prior_Lease_Commencement_Date = null;
            this._Renewals = null;
            this._Year_Built = null;
            this._Reminder_Date = null;
            this._Year_Remodeled = null;
            this._Landlord_Notification_Date = null;
            this._Regional_Vice_President = null;
            this._Vacate_Date = null;
            this._General_Manager = null;
            this._Primary_Use = null;
            this._Controller = null;
            this._Lease_Codes = null;
            this._Loss_Control_Manager = null;
            this._Total_Acres = null;
            this._Number_of_Buildings = null;
            this._Total_Gross_Leaseable_Area = null;
            this._Landlord_Legal_Entity = null;
            this._Amendment_Info = null;
            this._Assignment_Info = null;
            this._Land_Value = null;
            this._Updated_By = null;
            this._Update_Date = null;
            this._Regional_Controller = null;
            this._FK_HVAC_Capital = null;
            this._FK_Roof_Capital = null;
            this._FK_HVAC_Repairs = null;
            this._FK_Roof_Repairs = null;
            this._Other_Repairs = null;
            this._Maintenance_Notes = null;
        }

        /// <summary>
        /// Inserts a record into the RE_Information table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_InformationInsert");


            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);

            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Decimal, this._FK_Building_ID);

            if (string.IsNullOrEmpty(this._Federal_Id))
                db.AddInParameter(dbCommand, "Federal_Id", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Federal_Id", DbType.String, this._Federal_Id);

            db.AddInParameter(dbCommand, "FK_LU_Status", DbType.Decimal, this._FK_LU_Status);


            if (string.IsNullOrEmpty(this._Tax_Parcel_Number))
                db.AddInParameter(dbCommand, "Tax_Parcel_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Tax_Parcel_Number", DbType.String, this._Tax_Parcel_Number);

            db.AddInParameter(dbCommand, "FK_LU_Lease_Type", DbType.Decimal, this._FK_LU_Lease_Type);

            if (string.IsNullOrEmpty(this._Landlord))
                db.AddInParameter(dbCommand, "Landlord", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord", DbType.String, this._Landlord);

            if (string.IsNullOrEmpty(this._Landlord_Location_Address1))
                db.AddInParameter(dbCommand, "Landlord_Location_Address1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Location_Address1", DbType.String, this._Landlord_Location_Address1);

            if (string.IsNullOrEmpty(this._Landlord_Location_Address2))
                db.AddInParameter(dbCommand, "Landlord_Location_Address2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Location_Address2", DbType.String, this._Landlord_Location_Address2);

            if (string.IsNullOrEmpty(this._Landlord_Location_City))
                db.AddInParameter(dbCommand, "Landlord_Location_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Location_City", DbType.String, this._Landlord_Location_City);

            db.AddInParameter(dbCommand, "PK_Landlord_Location_State", DbType.Decimal, this._PK_Landlord_Location_State);

            if (string.IsNullOrEmpty(this._Landlord_Location_Zip_Code))
                db.AddInParameter(dbCommand, "Landlord_Location_Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Location_Zip_Code", DbType.String, this._Landlord_Location_Zip_Code);

            if (string.IsNullOrEmpty(this._Landlord_Mailing_Address1))
                db.AddInParameter(dbCommand, "Landlord_Mailing_Address1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Mailing_Address1", DbType.String, this._Landlord_Mailing_Address1);

            if (string.IsNullOrEmpty(this._Landlord_Mailing_Address2))
                db.AddInParameter(dbCommand, "Landlord_Mailing_Address2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Mailing_Address2", DbType.String, this._Landlord_Mailing_Address2);

            if (string.IsNullOrEmpty(this._Landlord_Mailing_City))
                db.AddInParameter(dbCommand, "Landlord_Mailing_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Mailing_City", DbType.String, this._Landlord_Mailing_City);

            db.AddInParameter(dbCommand, "PK_Landlord_Mailing_State", DbType.Decimal, this._PK_Landlord_Mailing_State);

            if (string.IsNullOrEmpty(this._Landlord_Mailing_Zip_Code))
                db.AddInParameter(dbCommand, "Landlord_Mailing_Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Mailing_Zip_Code", DbType.String, this._Landlord_Mailing_Zip_Code);

            if (string.IsNullOrEmpty(this._Landlord_Telephone))
                db.AddInParameter(dbCommand, "Landlord_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Telephone", DbType.String, this._Landlord_Telephone);

            if (string.IsNullOrEmpty(this._Landlord_Email))
                db.AddInParameter(dbCommand, "Landlord_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Email", DbType.String, this._Landlord_Email);

            if (string.IsNullOrEmpty(this._Sublease))
                db.AddInParameter(dbCommand, "Sublease", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease", DbType.String, this._Sublease);

            if (string.IsNullOrEmpty(this._Subtenant))
                db.AddInParameter(dbCommand, "Subtenant", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Subtenant", DbType.String, this._Subtenant);

            if (string.IsNullOrEmpty(this._Lease_Id))
                db.AddInParameter(dbCommand, "Lease_Id", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Lease_Id", DbType.String, this._Lease_Id);

            db.AddInParameter(dbCommand, "Lease_Commencement_Date", DbType.DateTime, this._Lease_Commencement_Date);

            db.AddInParameter(dbCommand, "FK_LU_Project_Type", DbType.Decimal, this._FK_LU_Project_Type);

            db.AddInParameter(dbCommand, "Lease_Expiration_Date", DbType.DateTime, this._Lease_Expiration_Date);

            db.AddInParameter(dbCommand, "Date_Acquired", DbType.DateTime, this._Date_Acquired);

            db.AddInParameter(dbCommand, "Lease_Term_Months", DbType.Decimal, this._Lease_Term_Months);

            db.AddInParameter(dbCommand, "Date_Sold", DbType.DateTime, this._Date_Sold);

            db.AddInParameter(dbCommand, "Prior_Lease_Commencement_Date", DbType.DateTime, this._Prior_Lease_Commencement_Date);

            if (string.IsNullOrEmpty(this._Renewals))
                db.AddInParameter(dbCommand, "Renewals", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Renewals", DbType.String, this._Renewals);

            db.AddInParameter(dbCommand, "Year_Built", DbType.Decimal, this._Year_Built);

            db.AddInParameter(dbCommand, "Reminder_Date", DbType.DateTime, this._Reminder_Date);

            db.AddInParameter(dbCommand, "Year_Remodeled", DbType.Decimal, this._Year_Remodeled);

            db.AddInParameter(dbCommand, "Landlord_Notification_Date", DbType.DateTime, this._Landlord_Notification_Date);

            if (string.IsNullOrEmpty(this._Regional_Vice_President))
                db.AddInParameter(dbCommand, "Regional_Vice_President", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Regional_Vice_President", DbType.String, this._Regional_Vice_President);

            db.AddInParameter(dbCommand, "Vacate_Date", DbType.DateTime, this._Vacate_Date);

            if (string.IsNullOrEmpty(this._General_Manager))
                db.AddInParameter(dbCommand, "General_Manager", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "General_Manager", DbType.String, this._General_Manager);

            if (string.IsNullOrEmpty(this._Primary_Use))
                db.AddInParameter(dbCommand, "Primary_Use", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Primary_Use", DbType.String, this._Primary_Use);

            if (string.IsNullOrEmpty(this._Controller))
                db.AddInParameter(dbCommand, "Controller", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Controller", DbType.String, this._Controller);

            if (string.IsNullOrEmpty(this._Lease_Codes))
                db.AddInParameter(dbCommand, "Lease_Codes", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Lease_Codes", DbType.String, this._Lease_Codes);

            if (string.IsNullOrEmpty(this._Loss_Control_Manager))
                db.AddInParameter(dbCommand, "Loss_Control_Manager", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Loss_Control_Manager", DbType.String, this._Loss_Control_Manager);

            db.AddInParameter(dbCommand, "Total_Acres", DbType.Decimal, this._Total_Acres);

            db.AddInParameter(dbCommand, "Number_of_Buildings", DbType.Decimal, this._Number_of_Buildings);

            db.AddInParameter(dbCommand, "Total_Gross_Leaseable_Area", DbType.Decimal, this._Total_Gross_Leaseable_Area);

            db.AddInParameter(dbCommand, "Land_Value", DbType.Decimal, this._Land_Value);

            if (string.IsNullOrEmpty(this._Landlord_Legal_Entity))
                db.AddInParameter(dbCommand, "Landlord_Legal_Entity", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Legal_Entity", DbType.String, this._Landlord_Legal_Entity);

            if (string.IsNullOrEmpty(this._Amendment_Info))
                db.AddInParameter(dbCommand, "Amendment_Info", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Amendment_Info", DbType.String, this._Amendment_Info);

            if (string.IsNullOrEmpty(this._Assignment_Info))
                db.AddInParameter(dbCommand, "Assignment_Info", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Assignment_Info", DbType.String, this._Assignment_Info);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Regional_Controller))
                db.AddInParameter(dbCommand, "Regional_Controller", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Regional_Controller", DbType.String, this._Regional_Controller);

            db.AddInParameter(dbCommand, "FK_HVAC_Repairs", DbType.Decimal, this._FK_HVAC_Repairs);

            db.AddInParameter(dbCommand, "FK_HVAC_Capital", DbType.Decimal, this._FK_HVAC_Capital);

            db.AddInParameter(dbCommand, "FK_Roof_Capital", DbType.Decimal, this._FK_Roof_Capital);

            db.AddInParameter(dbCommand, "FK_Roof_Repairs", DbType.Decimal, this._FK_Roof_Repairs);

            if (string.IsNullOrEmpty(this._Other_Repairs))
                db.AddInParameter(dbCommand, "Other_Repairs", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Repairs", DbType.String, this._Other_Repairs);

            if (string.IsNullOrEmpty(this._Maintenance_Notes))
                db.AddInParameter(dbCommand, "Maintenance_Notes", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Maintenance_Notes", DbType.String, this._Maintenance_Notes);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the RE_Information table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_RE_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_InformationSelectByPK");

            db.AddInParameter(dbCommand, "PK_RE_Information", DbType.Decimal, pK_RE_Information);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the RE_Information table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_InformationSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the RE_Information table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_InformationUpdate");


            db.AddInParameter(dbCommand, "PK_RE_Information", DbType.Decimal, this._PK_RE_Information);

            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);
            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Decimal, this._FK_Building_ID);

            if (string.IsNullOrEmpty(this._Federal_Id))
                db.AddInParameter(dbCommand, "Federal_Id", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Federal_Id", DbType.String, this._Federal_Id);

            db.AddInParameter(dbCommand, "FK_LU_Status", DbType.Decimal, this._FK_LU_Status);

            if (string.IsNullOrEmpty(this._Tax_Parcel_Number))
                db.AddInParameter(dbCommand, "Tax_Parcel_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Tax_Parcel_Number", DbType.String, this._Tax_Parcel_Number);

            db.AddInParameter(dbCommand, "FK_LU_Lease_Type", DbType.Decimal, this._FK_LU_Lease_Type);

            if (string.IsNullOrEmpty(this._Landlord))
                db.AddInParameter(dbCommand, "Landlord", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord", DbType.String, this._Landlord);

            if (string.IsNullOrEmpty(this._Landlord_Location_Address1))
                db.AddInParameter(dbCommand, "Landlord_Location_Address1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Location_Address1", DbType.String, this._Landlord_Location_Address1);

            if (string.IsNullOrEmpty(this._Landlord_Location_Address2))
                db.AddInParameter(dbCommand, "Landlord_Location_Address2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Location_Address2", DbType.String, this._Landlord_Location_Address2);

            if (string.IsNullOrEmpty(this._Landlord_Location_City))
                db.AddInParameter(dbCommand, "Landlord_Location_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Location_City", DbType.String, this._Landlord_Location_City);

            db.AddInParameter(dbCommand, "PK_Landlord_Location_State", DbType.Decimal, this._PK_Landlord_Location_State);

            if (string.IsNullOrEmpty(this._Landlord_Location_Zip_Code))
                db.AddInParameter(dbCommand, "Landlord_Location_Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Location_Zip_Code", DbType.String, this._Landlord_Location_Zip_Code);

            if (string.IsNullOrEmpty(this._Landlord_Mailing_Address1))
                db.AddInParameter(dbCommand, "Landlord_Mailing_Address1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Mailing_Address1", DbType.String, this._Landlord_Mailing_Address1);

            if (string.IsNullOrEmpty(this._Landlord_Mailing_Address2))
                db.AddInParameter(dbCommand, "Landlord_Mailing_Address2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Mailing_Address2", DbType.String, this._Landlord_Mailing_Address2);

            if (string.IsNullOrEmpty(this._Landlord_Mailing_City))
                db.AddInParameter(dbCommand, "Landlord_Mailing_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Mailing_City", DbType.String, this._Landlord_Mailing_City);

            db.AddInParameter(dbCommand, "PK_Landlord_Mailing_State", DbType.Decimal, this._PK_Landlord_Mailing_State);

            if (string.IsNullOrEmpty(this._Landlord_Mailing_Zip_Code))
                db.AddInParameter(dbCommand, "Landlord_Mailing_Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Mailing_Zip_Code", DbType.String, this._Landlord_Mailing_Zip_Code);

            if (string.IsNullOrEmpty(this._Landlord_Telephone))
                db.AddInParameter(dbCommand, "Landlord_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Telephone", DbType.String, this._Landlord_Telephone);

            if (string.IsNullOrEmpty(this._Landlord_Email))
                db.AddInParameter(dbCommand, "Landlord_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Email", DbType.String, this._Landlord_Email);

            if (string.IsNullOrEmpty(this._Sublease))
                db.AddInParameter(dbCommand, "Sublease", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease", DbType.String, this._Sublease);

            if (string.IsNullOrEmpty(this._Subtenant))
                db.AddInParameter(dbCommand, "Subtenant", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Subtenant", DbType.String, this._Subtenant);

            if (string.IsNullOrEmpty(this._Lease_Id))
                db.AddInParameter(dbCommand, "Lease_Id", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Lease_Id", DbType.String, this._Lease_Id);

            db.AddInParameter(dbCommand, "Lease_Commencement_Date", DbType.DateTime, this._Lease_Commencement_Date);

            db.AddInParameter(dbCommand, "FK_LU_Project_Type", DbType.Decimal, this._FK_LU_Project_Type);

            db.AddInParameter(dbCommand, "Lease_Expiration_Date", DbType.DateTime, this._Lease_Expiration_Date);

            db.AddInParameter(dbCommand, "Date_Acquired", DbType.DateTime, this._Date_Acquired);

            db.AddInParameter(dbCommand, "Lease_Term_Months", DbType.Decimal, this._Lease_Term_Months);

            db.AddInParameter(dbCommand, "Date_Sold", DbType.DateTime, this._Date_Sold);

            db.AddInParameter(dbCommand, "Prior_Lease_Commencement_Date", DbType.DateTime, this._Prior_Lease_Commencement_Date);

            if (string.IsNullOrEmpty(this._Renewals))
                db.AddInParameter(dbCommand, "Renewals", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Renewals", DbType.String, this._Renewals);

            db.AddInParameter(dbCommand, "Year_Built", DbType.Decimal, this._Year_Built);

            db.AddInParameter(dbCommand, "Reminder_Date", DbType.DateTime, this._Reminder_Date);

            db.AddInParameter(dbCommand, "Year_Remodeled", DbType.Decimal, this._Year_Remodeled);

            db.AddInParameter(dbCommand, "Landlord_Notification_Date", DbType.DateTime, this._Landlord_Notification_Date);

            if (string.IsNullOrEmpty(this._Regional_Vice_President))
                db.AddInParameter(dbCommand, "Regional_Vice_President", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Regional_Vice_President", DbType.String, this._Regional_Vice_President);

            db.AddInParameter(dbCommand, "Vacate_Date", DbType.DateTime, this._Vacate_Date);

            if (string.IsNullOrEmpty(this._General_Manager))
                db.AddInParameter(dbCommand, "General_Manager", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "General_Manager", DbType.String, this._General_Manager);

            if (string.IsNullOrEmpty(this._Primary_Use))
                db.AddInParameter(dbCommand, "Primary_Use", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Primary_Use", DbType.String, this._Primary_Use);

            if (string.IsNullOrEmpty(this._Controller))
                db.AddInParameter(dbCommand, "Controller", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Controller", DbType.String, this._Controller);

            if (string.IsNullOrEmpty(this._Lease_Codes))
                db.AddInParameter(dbCommand, "Lease_Codes", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Lease_Codes", DbType.String, this._Lease_Codes);

            if (string.IsNullOrEmpty(this._Loss_Control_Manager))
                db.AddInParameter(dbCommand, "Loss_Control_Manager", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Loss_Control_Manager", DbType.String, this._Loss_Control_Manager);

            db.AddInParameter(dbCommand, "Total_Acres", DbType.Decimal, this._Total_Acres);

            db.AddInParameter(dbCommand, "Number_of_Buildings", DbType.Decimal, this._Number_of_Buildings);

            db.AddInParameter(dbCommand, "Total_Gross_Leaseable_Area", DbType.Decimal, this._Total_Gross_Leaseable_Area);

            db.AddInParameter(dbCommand, "Land_Value", DbType.Decimal, this._Land_Value);

            if (string.IsNullOrEmpty(this._Landlord_Legal_Entity))
                db.AddInParameter(dbCommand, "Landlord_Legal_Entity", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Legal_Entity", DbType.String, this._Landlord_Legal_Entity);

            if (string.IsNullOrEmpty(this._Amendment_Info))
                db.AddInParameter(dbCommand, "Amendment_Info", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Amendment_Info", DbType.String, this._Amendment_Info);

            if (string.IsNullOrEmpty(this._Assignment_Info))
                db.AddInParameter(dbCommand, "Assignment_Info", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Assignment_Info", DbType.String, this._Assignment_Info);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Regional_Controller))
                db.AddInParameter(dbCommand, "Regional_Controller", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Regional_Controller", DbType.String, this._Regional_Controller);

            db.AddInParameter(dbCommand, "FK_HVAC_Repairs", DbType.Decimal, this._FK_HVAC_Repairs);

            db.AddInParameter(dbCommand, "FK_HVAC_Capital", DbType.Decimal, this._FK_HVAC_Capital);

            db.AddInParameter(dbCommand, "FK_Roof_Capital", DbType.Decimal, this._FK_Roof_Capital);

            db.AddInParameter(dbCommand, "FK_Roof_Repairs", DbType.Decimal, this._FK_Roof_Repairs);

            if (string.IsNullOrEmpty(this._Other_Repairs))
                db.AddInParameter(dbCommand, "Other_Repairs", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Repairs", DbType.String, this._Other_Repairs);

            if (string.IsNullOrEmpty(this._Maintenance_Notes))
                db.AddInParameter(dbCommand, "Maintenance_Notes", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Maintenance_Notes", DbType.String, this._Maintenance_Notes);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the RE_Information table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_RE_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_InformationDeleteByPK");

            db.AddInParameter(dbCommand, "PK_RE_Information", DbType.Decimal, pK_RE_Information);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// select service contract by id
        /// </summary>
        /// <returns></returns>
        public static DataSet RealEstateSearch(decimal FK_LU_Location, string Region, Nullable<DateTime> Lease_Commencement_Date_From, Nullable<DateTime> Lease_Commencement_Date_To, Nullable<DateTime> Lease_Expiration_Date_From, Nullable<DateTime> Lease_Expiration_Date_To,
            decimal FK_State_ID, string Landlord, Nullable<DateTime> Date_Acquired_From, Nullable<DateTime> Date_Acquired_To, decimal FK_LU_Lease_Type, decimal FK_LU_Project_Type, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Real_Estate_Search");

            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, FK_LU_Location);
            db.AddInParameter(dbCommand, "Region", DbType.String, Region);
            db.AddInParameter(dbCommand, "Lease_Commencement_Date_From", DbType.DateTime, Lease_Commencement_Date_From);
            db.AddInParameter(dbCommand, "Lease_Commencement_Date_To", DbType.DateTime, Lease_Commencement_Date_To);
            db.AddInParameter(dbCommand, "Lease_Expiration_Date_From", DbType.DateTime, Lease_Expiration_Date_From);
            db.AddInParameter(dbCommand, "Lease_Expiration_Date_To", DbType.DateTime, Lease_Expiration_Date_To);
            db.AddInParameter(dbCommand, "State", DbType.String, FK_State_ID);
            db.AddInParameter(dbCommand, "Landlord", DbType.String, Landlord);
            db.AddInParameter(dbCommand, "Date_Acquired_From", DbType.DateTime, Date_Acquired_From);
            db.AddInParameter(dbCommand, "Date_Acquired_To", DbType.DateTime, Date_Acquired_To);
            db.AddInParameter(dbCommand, "FK_LU_Lease_Type", DbType.Decimal, FK_LU_Lease_Type);
            db.AddInParameter(dbCommand, "FK_LU_Project_Type", DbType.Decimal, FK_LU_Project_Type);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.String, intPageSize);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetPKofAllChildTables(decimal PK_RE_Info)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_GetPKofAllChildTables");
            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, PK_RE_Info);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the RE_Information table by aLocation.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Location(decimal Fk_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_InformationSelectByFK_Location");

            db.AddInParameter(dbCommand, "Fk_LU_Location", DbType.Decimal, Fk_LU_Location);

            return db.ExecuteDataSet(dbCommand);
        }

        public static decimal SelectPKByFKLoc(int fK_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_InformationSelectPKByFKLoc");
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location);
            db.AddOutParameter(dbCommand, "PK_RE_Information", DbType.Int32, 1);
            db.ExecuteNonQuery(dbCommand);

            return Convert.ToInt32(dbCommand.Parameters["@PK_RE_Information"].Value);
        }

        public static DataSet CheckValidations(decimal fk_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LeaseCheckValidations");

            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, fk_LU_Location);

            return db.ExecuteDataSet(dbCommand);
        }

        public static void UpdateRLCMDetails(decimal PK_RE_Info)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Info_UpdateRLCMDetails");

            db.AddInParameter(dbCommand, "PK_RE_Information", DbType.Decimal, PK_RE_Info);
            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectLandlordDetails(decimal pK_RE_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Leases_SelectLandlordDetails");

            db.AddInParameter(dbCommand, "PK_RE_Information", DbType.Decimal, pK_RE_Information);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectRenewalForFranchise(decimal fK_Building_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_SelectRenewalForFranchise");

            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Decimal, fK_Building_ID);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
