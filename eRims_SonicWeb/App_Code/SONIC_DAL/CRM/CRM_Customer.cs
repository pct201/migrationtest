using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for CRM_Customer table.
    /// </summary>
    public sealed class CRM_Customer
    {

        #region Private variables used to hold the property values

        private decimal? _PK_CRM_Customer;
        private DateTime? _Record_Date;
        private decimal? _FK_LU_CRM_Source;
        private string _Last_Name;
        private string _First_Name;
        private string _Address;
        private string _City;
        private decimal? _FK_State;
        private string _Zip_Code;
        private string _Email;
        private string _Home_Telephone;
        private string _Cell_Telephone;
        private string _Work_Telephone;
        private string _Work_Telephone_Extension;
        private string _Summary;
        private decimal? _FK_LU_CRM_Department;
        private decimal? _FK_LU_CRM_Dept_Desc_Detail;
        private DateTime? _Service_Date;
        private string _Service_Date_Est;
        private decimal? _FK_LU_Location;
        private decimal? _FK_LU_CRM_Brand;
        private string _Model;
        private decimal? _Year;
        private decimal? _FK_LU_CRM_Contacted_Resolution_2;
        private decimal? _FK_LU_CRM_Contacted_Resolution_1;
        private string _Resolution_Manager;
        private string _Resolution_Manager_Email;
        private string _Customer_Contacted_GM;
        private DateTime? _GM_Contact_Date;
        private string _GM_Name;
        private DateTime? _RVP_Contact_Date;
        private decimal? _FK_LU_CRM_RVP;
        private DateTime? _DFOD_Contact_Date;
        private decimal? _FK_LU_CRM_DFOD;
        private string _Other_Cotnact_Name;
        private string _Legal_Attorney_General;
        private decimal? _FK_LU_CRM_Legal_Email;
        private string _Demand_Letter;
        private DateTime? _Update_Date;
        private string _Last_Action;
        private string _Field_Resolution_Information;
        private string _Resolution_Summary;
        private string _Complete;
        private DateTime? _Close_Date;
        private decimal? _Days_To_Close;
        private string _Customer_Callback_After_Resolution;
        private string _Resolution_Letter_To_Customer;
        private DateTime? _Date_Resolution_Letter_Sent;
        private decimal? _FK_LU_CRM_Response_Method;
        private string _Letter_NA;
        private decimal? _FK_LU_CRM_Letter_NA_Reason;
        private string _Letter_NA_Note;
        private string _Updated_By;
        private DateTime? _User_Update_Date;
        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_CRM_Customer value.
        /// </summary>
        public decimal? PK_CRM_Customer
        {
            get { return _PK_CRM_Customer; }
            set { _PK_CRM_Customer = value; }
        }

        /// <summary>
        /// Gets or sets the Record_Date value.
        /// </summary>
        public DateTime? Record_Date
        {
            get { return _Record_Date; }
            set { _Record_Date = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_CRM_Source value.
        /// </summary>
        public decimal? FK_LU_CRM_Source
        {
            get { return _FK_LU_CRM_Source; }
            set { _FK_LU_CRM_Source = value; }
        }

        /// <summary>
        /// Gets or sets the Last_Name value.
        /// </summary>
        public string Last_Name
        {
            get { return _Last_Name; }
            set { _Last_Name = value; }
        }

        /// <summary>
        /// Gets or sets the First_Name value.
        /// </summary>
        public string First_Name
        {
            get { return _First_Name; }
            set { _First_Name = value; }
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
        /// Gets or sets the City value.
        /// </summary>
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        /// <summary>
        /// Gets or sets the FK_State value.
        /// </summary>
        public decimal? FK_State
        {
            get { return _FK_State; }
            set { _FK_State = value; }
        }

        /// <summary>
        /// Gets or sets the Zip_Code value.
        /// </summary>
        public string Zip_Code
        {
            get { return _Zip_Code; }
            set { _Zip_Code = value; }
        }

        /// <summary>
        /// Gets or sets the Email value.
        /// </summary>
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        /// <summary>
        /// Gets or sets the Home_Telephone value.
        /// </summary>
        public string Home_Telephone
        {
            get { return _Home_Telephone; }
            set { _Home_Telephone = value; }
        }

        /// <summary>
        /// Gets or sets the Cell_Telephone value.
        /// </summary>
        public string Cell_Telephone
        {
            get { return _Cell_Telephone; }
            set { _Cell_Telephone = value; }
        }

        /// <summary>
        /// Gets or sets the Work_Telephone value.
        /// </summary>
        public string Work_Telephone
        {
            get { return _Work_Telephone; }
            set { _Work_Telephone = value; }
        }

        /// <summary>
        /// Gets or sets the Work_Telephone_Extension value.
        /// </summary>
        public string Work_Telephone_Extension
        {
            get { return _Work_Telephone_Extension; }
            set { _Work_Telephone_Extension = value; }
        }

        /// <summary>
        /// Gets or sets the Summary value.
        /// </summary>
        public string Summary
        {
            get { return _Summary; }
            set { _Summary = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_CRM_Department value.
        /// </summary>
        public decimal? FK_LU_CRM_Department
        {
            get { return _FK_LU_CRM_Department; }
            set { _FK_LU_CRM_Department = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_CRM_Dept_Desc_Detail value.
        /// </summary>
        public decimal? FK_LU_CRM_Dept_Desc_Detail
        {
            get { return _FK_LU_CRM_Dept_Desc_Detail; }
            set { _FK_LU_CRM_Dept_Desc_Detail = value; }
        }

        /// <summary>
        /// Gets or sets the Service_Date value.
        /// </summary>
        public DateTime? Service_Date
        {
            get { return _Service_Date; }
            set { _Service_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Service_Date_Est value.
        /// </summary>
        public string Service_Date_Est
        {
            get { return _Service_Date_Est; }
            set { _Service_Date_Est = value; }
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
        /// Gets or sets the FK_LU_CRM_Brand value.
        /// </summary>
        public decimal? FK_LU_CRM_Brand
        {
            get { return _FK_LU_CRM_Brand; }
            set { _FK_LU_CRM_Brand = value; }
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
        public decimal? Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_CRM_Contacted_Resolution_2 value.
        /// </summary>
        public decimal? FK_LU_CRM_Contacted_Resolution_2
        {
            get { return _FK_LU_CRM_Contacted_Resolution_2; }
            set { _FK_LU_CRM_Contacted_Resolution_2 = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_CRM_Contacted_Resolution_1 value.
        /// </summary>
        public decimal? FK_LU_CRM_Contacted_Resolution_1
        {
            get { return _FK_LU_CRM_Contacted_Resolution_1; }
            set { _FK_LU_CRM_Contacted_Resolution_1 = value; }
        }

        /// <summary>
        /// Gets or sets the Resolution_Manager value.
        /// </summary>
        public string Resolution_Manager
        {
            get { return _Resolution_Manager; }
            set { _Resolution_Manager = value; }
        }

        /// <summary>
        /// Gets or sets the Resolution_Manager_Email value.
        /// </summary>
        public string Resolution_Manager_Email
        {
            get { return _Resolution_Manager_Email; }
            set { _Resolution_Manager_Email = value; }
        }

        /// <summary>
        /// Gets or sets the Customer_Contacted_GM value.
        /// </summary>
        public string Customer_Contacted_GM
        {
            get { return _Customer_Contacted_GM; }
            set { _Customer_Contacted_GM = value; }
        }

        /// <summary>
        /// Gets or sets the GM_Contact_Date value.
        /// </summary>
        public DateTime? GM_Contact_Date
        {
            get { return _GM_Contact_Date; }
            set { _GM_Contact_Date = value; }
        }

        /// <summary>
        /// Gets or sets the GM_Name value.
        /// </summary>
        public string GM_Name
        {
            get { return _GM_Name; }
            set { _GM_Name = value; }
        }

        /// <summary>
        /// Gets or sets the RVP_Contact_Date value.
        /// </summary>
        public DateTime? RVP_Contact_Date
        {
            get { return _RVP_Contact_Date; }
            set { _RVP_Contact_Date = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_CRM_RVP value.
        /// </summary>
        public decimal? FK_LU_CRM_RVP
        {
            get { return _FK_LU_CRM_RVP; }
            set { _FK_LU_CRM_RVP = value; }
        }

        /// <summary>
        /// Gets or sets the DFOD_Contact_Date value.
        /// </summary>
        public DateTime? DFOD_Contact_Date
        {
            get { return _DFOD_Contact_Date; }
            set { _DFOD_Contact_Date = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_CRM_DFOD value.
        /// </summary>
        public decimal? FK_LU_CRM_DFOD
        {
            get { return _FK_LU_CRM_DFOD; }
            set { _FK_LU_CRM_DFOD = value; }
        }

        /// <summary>
        /// Gets or sets the Other_Cotnact_Name value.
        /// </summary>
        public string Other_Cotnact_Name
        {
            get { return _Other_Cotnact_Name; }
            set { _Other_Cotnact_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Legal_Attorney_General value.
        /// </summary>
        public string Legal_Attorney_General
        {
            get { return _Legal_Attorney_General; }
            set { _Legal_Attorney_General = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_CRM_Legal_Email value.
        /// </summary>
        public decimal? FK_LU_CRM_Legal_Email
        {
            get { return _FK_LU_CRM_Legal_Email; }
            set { _FK_LU_CRM_Legal_Email = value; }
        }

        /// <summary>
        /// Gets or sets the Demand_Letter value.
        /// </summary>
        public string Demand_Letter
        {
            get { return _Demand_Letter; }
            set { _Demand_Letter = value; }
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
        /// Gets or sets the Last_Action value.
        /// </summary>
        public string Last_Action
        {
            get { return _Last_Action; }
            set { _Last_Action = value; }
        }

        /// <summary>
        /// Gets or sets the Field_Resolution_Information value.
        /// </summary>
        public string Field_Resolution_Information
        {
            get { return _Field_Resolution_Information; }
            set { _Field_Resolution_Information = value; }
        }

        /// <summary>
        /// Gets or sets the Resolution_Summary value.
        /// </summary>
        public string Resolution_Summary
        {
            get { return _Resolution_Summary; }
            set { _Resolution_Summary = value; }
        }

        /// <summary>
        /// Gets or sets the Complete value.
        /// </summary>
        public string Complete
        {
            get { return _Complete; }
            set { _Complete = value; }
        }

        /// <summary>
        /// Gets or sets the Close_Date value.
        /// </summary>
        public DateTime? Close_Date
        {
            get { return _Close_Date; }
            set { _Close_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Days_To_Close value.
        /// </summary>
        public decimal? Days_To_Close
        {
            get { return _Days_To_Close; }
            set { _Days_To_Close = value; }
        }

        /// <summary>
        /// Gets or sets the Customer_Callback_After_Resolution value.
        /// </summary>
        public string Customer_Callback_After_Resolution
        {
            get { return _Customer_Callback_After_Resolution; }
            set { _Customer_Callback_After_Resolution = value; }
        }

        /// <summary>
        /// Gets or sets the Resolution_Letter_To_Customer value.
        /// </summary>
        public string Resolution_Letter_To_Customer
        {
            get { return _Resolution_Letter_To_Customer; }
            set { _Resolution_Letter_To_Customer = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Resolution_Letter_Sent value.
        /// </summary>
        public DateTime? Date_Resolution_Letter_Sent
        {
            get { return _Date_Resolution_Letter_Sent; }
            set { _Date_Resolution_Letter_Sent = value; }
        }

        public DateTime? User_Update_Date
        {
            get { return _User_Update_Date; }
            set { _User_Update_Date = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_CRM_Response_Method value.
        /// </summary>
        public decimal? FK_LU_CRM_Response_Method
        {
            get { return _FK_LU_CRM_Response_Method; }
            set { _FK_LU_CRM_Response_Method = value; }
        }

        /// <summary>
        /// Gets or sets the Letter_NA value.
        /// </summary>
        public string Letter_NA
        {
            get { return _Letter_NA; }
            set { _Letter_NA = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_CRM_Letter_NA_Reason value.
        /// </summary>
        public decimal? FK_LU_CRM_Letter_NA_Reason
        {
            get { return _FK_LU_CRM_Letter_NA_Reason; }
            set { _FK_LU_CRM_Letter_NA_Reason = value; }
        }

        /// <summary>
        /// Gets or sets the Letter_NA_Note value.
        /// </summary>
        public string Letter_NA_Note
        {
            get { return _Letter_NA_Note; }
            set { _Letter_NA_Note = value; }
        }

        /// <summary>
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the CRM_Customer class with default value.
        /// </summary>
        public CRM_Customer()
        {

            this._PK_CRM_Customer = null;
            this._Record_Date = null;
            this._FK_LU_CRM_Source = null;
            this._Last_Name = null;
            this._First_Name = null;
            this._Address = null;
            this._City = null;
            this._FK_State = null;
            this._Zip_Code = null;
            this._Email = null;
            this._Home_Telephone = null;
            this._Cell_Telephone = null;
            this._Work_Telephone = null;
            this._Work_Telephone_Extension = null;
            this._Summary = null;
            this._FK_LU_CRM_Department = null;
            this._FK_LU_CRM_Dept_Desc_Detail = null;
            this._Service_Date = null;
            this._Service_Date_Est = null;
            this._FK_LU_Location = null;
            this._FK_LU_CRM_Brand = null;
            this._Model = null;
            this._Year = null;
            this._FK_LU_CRM_Contacted_Resolution_2 = null;
            this._FK_LU_CRM_Contacted_Resolution_1 = null;
            this._Resolution_Manager = null;
            this._Resolution_Manager_Email = null;
            this._Customer_Contacted_GM = null;
            this._GM_Contact_Date = null;
            this._GM_Name = null;
            this._RVP_Contact_Date = null;
            this._FK_LU_CRM_RVP = null;
            this._DFOD_Contact_Date = null;
            this._FK_LU_CRM_DFOD = null;
            this._Other_Cotnact_Name = null;
            this._Legal_Attorney_General = null;
            this._FK_LU_CRM_Legal_Email = null;
            this._Demand_Letter = null;
            this._Update_Date = null;
            this._Last_Action = null;
            this._Field_Resolution_Information = null;
            this._Resolution_Summary = null;
            this._Complete = null;
            this._Close_Date = null;
            this._Days_To_Close = null;
            this._Customer_Callback_After_Resolution = null;
            this._Resolution_Letter_To_Customer = null;
            this._Date_Resolution_Letter_Sent = null;
            this._User_Update_Date = null;
            this._FK_LU_CRM_Response_Method = null;
            this._Letter_NA = null;
            this._FK_LU_CRM_Letter_NA_Reason = null;
            this._Letter_NA_Note = null;
            this._Updated_By = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the CRM_Customer class based on Primary Key.
        /// </summary>
        public CRM_Customer(decimal pK_CRM_Customer)
        {
            DataTable dtCRM_Customer = SelectByPK(pK_CRM_Customer).Tables[0];

            if (dtCRM_Customer.Rows.Count == 1)
            {
                DataRow drCRM_Customer = dtCRM_Customer.Rows[0];
                if (drCRM_Customer["PK_CRM_Customer"] == DBNull.Value)
                    this._PK_CRM_Customer = null;
                else
                    this._PK_CRM_Customer = (decimal?)drCRM_Customer["PK_CRM_Customer"];

                if (drCRM_Customer["Record_Date"] == DBNull.Value)
                    this._Record_Date = null;
                else
                    this._Record_Date = (DateTime?)drCRM_Customer["Record_Date"];

                if (drCRM_Customer["FK_LU_CRM_Source"] == DBNull.Value)
                    this._FK_LU_CRM_Source = null;
                else
                    this._FK_LU_CRM_Source = (decimal?)drCRM_Customer["FK_LU_CRM_Source"];

                if (drCRM_Customer["Last_Name"] == DBNull.Value)
                    this._Last_Name = null;
                else
                    this._Last_Name = (string)drCRM_Customer["Last_Name"];

                if (drCRM_Customer["First_Name"] == DBNull.Value)
                    this._First_Name = null;
                else
                    this._First_Name = (string)drCRM_Customer["First_Name"];

                if (drCRM_Customer["Address"] == DBNull.Value)
                    this._Address = null;
                else
                    this._Address = (string)drCRM_Customer["Address"];

                if (drCRM_Customer["City"] == DBNull.Value)
                    this._City = null;
                else
                    this._City = (string)drCRM_Customer["City"];

                if (drCRM_Customer["FK_State"] == DBNull.Value)
                    this._FK_State = null;
                else
                    this._FK_State = (decimal?)drCRM_Customer["FK_State"];

                if (drCRM_Customer["Zip_Code"] == DBNull.Value)
                    this._Zip_Code = null;
                else
                    this._Zip_Code = (string)drCRM_Customer["Zip_Code"];

                if (drCRM_Customer["Email"] == DBNull.Value)
                    this._Email = null;
                else
                    this._Email = (string)drCRM_Customer["Email"];

                if (drCRM_Customer["Home_Telephone"] == DBNull.Value)
                    this._Home_Telephone = null;
                else
                    this._Home_Telephone = (string)drCRM_Customer["Home_Telephone"];

                if (drCRM_Customer["Cell_Telephone"] == DBNull.Value)
                    this._Cell_Telephone = null;
                else
                    this._Cell_Telephone = (string)drCRM_Customer["Cell_Telephone"];

                if (drCRM_Customer["Work_Telephone"] == DBNull.Value)
                    this._Work_Telephone = null;
                else
                    this._Work_Telephone = (string)drCRM_Customer["Work_Telephone"];

                if (drCRM_Customer["Work_Telephone_Extension"] == DBNull.Value)
                    this._Work_Telephone_Extension = null;
                else
                    this._Work_Telephone_Extension = (string)drCRM_Customer["Work_Telephone_Extension"];

                if (drCRM_Customer["Summary"] == DBNull.Value)
                    this._Summary = null;
                else
                    this._Summary = (string)drCRM_Customer["Summary"];

                if (drCRM_Customer["FK_LU_CRM_Department"] == DBNull.Value)
                    this._FK_LU_CRM_Department = null;
                else
                    this._FK_LU_CRM_Department = (decimal?)drCRM_Customer["FK_LU_CRM_Department"];

                if (drCRM_Customer["FK_LU_CRM_Dept_Desc_Detail"] == DBNull.Value)
                    this._FK_LU_CRM_Dept_Desc_Detail = null;
                else
                    this._FK_LU_CRM_Dept_Desc_Detail = (decimal?)drCRM_Customer["FK_LU_CRM_Dept_Desc_Detail"];

                if (drCRM_Customer["Service_Date"] == DBNull.Value)
                    this._Service_Date = null;
                else
                    this._Service_Date = (DateTime?)drCRM_Customer["Service_Date"];

                if (drCRM_Customer["Service_Date_Est"] == DBNull.Value)
                    this._Service_Date_Est = null;
                else
                    this._Service_Date_Est = (string)drCRM_Customer["Service_Date_Est"];

                if (drCRM_Customer["FK_LU_Location"] == DBNull.Value)
                    this._FK_LU_Location = null;
                else
                    this._FK_LU_Location = (decimal?)drCRM_Customer["FK_LU_Location"];

                if (drCRM_Customer["FK_LU_CRM_Brand"] == DBNull.Value)
                    this._FK_LU_CRM_Brand = null;
                else
                    this._FK_LU_CRM_Brand = (decimal?)drCRM_Customer["FK_LU_CRM_Brand"];

                if (drCRM_Customer["Model"] == DBNull.Value)
                    this._Model = null;
                else
                    this._Model = (string)drCRM_Customer["Model"];

                if (drCRM_Customer["Year"] == DBNull.Value)
                    this._Year = null;
                else
                    this._Year = (decimal?)drCRM_Customer["Year"];

                if (drCRM_Customer["FK_LU_CRM_Contacted_Resolution_2"] == DBNull.Value)
                    this._FK_LU_CRM_Contacted_Resolution_2 = null;
                else
                    this._FK_LU_CRM_Contacted_Resolution_2 = (decimal?)drCRM_Customer["FK_LU_CRM_Contacted_Resolution_2"];

                if (drCRM_Customer["FK_LU_CRM_Contacted_Resolution_1"] == DBNull.Value)
                    this._FK_LU_CRM_Contacted_Resolution_1 = null;
                else
                    this._FK_LU_CRM_Contacted_Resolution_1 = (decimal?)drCRM_Customer["FK_LU_CRM_Contacted_Resolution_1"];

                if (drCRM_Customer["Resolution_Manager"] == DBNull.Value)
                    this._Resolution_Manager = null;
                else
                    this._Resolution_Manager = (string)drCRM_Customer["Resolution_Manager"];

                if (drCRM_Customer["Resolution_Manager_Email"] == DBNull.Value)
                    this._Resolution_Manager_Email = null;
                else
                    this._Resolution_Manager_Email = (string)drCRM_Customer["Resolution_Manager_Email"];

                if (drCRM_Customer["Customer_Contacted_GM"] == DBNull.Value)
                    this._Customer_Contacted_GM = null;
                else
                    this._Customer_Contacted_GM = (string)drCRM_Customer["Customer_Contacted_GM"];

                if (drCRM_Customer["GM_Contact_Date"] == DBNull.Value)
                    this._GM_Contact_Date = null;
                else
                    this._GM_Contact_Date = (DateTime?)drCRM_Customer["GM_Contact_Date"];

                if (drCRM_Customer["GM_Name"] == DBNull.Value)
                    this._GM_Name = null;
                else
                    this._GM_Name = (string)drCRM_Customer["GM_Name"];

                if (drCRM_Customer["RVP_Contact_Date"] == DBNull.Value)
                    this._RVP_Contact_Date = null;
                else
                    this._RVP_Contact_Date = (DateTime?)drCRM_Customer["RVP_Contact_Date"];

                if (drCRM_Customer["FK_LU_CRM_RVP"] == DBNull.Value)
                    this._FK_LU_CRM_RVP = null;
                else
                    this._FK_LU_CRM_RVP = (decimal?)drCRM_Customer["FK_LU_CRM_RVP"];

                if (drCRM_Customer["DFOD_Contact_Date"] == DBNull.Value)
                    this._DFOD_Contact_Date = null;
                else
                    this._DFOD_Contact_Date = (DateTime?)drCRM_Customer["DFOD_Contact_Date"];

                if (drCRM_Customer["FK_LU_CRM_DFOD"] == DBNull.Value)
                    this._FK_LU_CRM_DFOD = null;
                else
                    this._FK_LU_CRM_DFOD = (decimal?)drCRM_Customer["FK_LU_CRM_DFOD"];

                if (drCRM_Customer["Other_Cotnact_Name"] == DBNull.Value)
                    this._Other_Cotnact_Name = null;
                else
                    this._Other_Cotnact_Name = (string)drCRM_Customer["Other_Cotnact_Name"];

                if (drCRM_Customer["Legal_Attorney_General"] == DBNull.Value)
                    this._Legal_Attorney_General = null;
                else
                    this._Legal_Attorney_General = (string)drCRM_Customer["Legal_Attorney_General"];

                if (drCRM_Customer["FK_LU_CRM_Legal_Email"] == DBNull.Value)
                    this._FK_LU_CRM_Legal_Email = null;
                else
                    this._FK_LU_CRM_Legal_Email = (decimal?)drCRM_Customer["FK_LU_CRM_Legal_Email"];

                if (drCRM_Customer["Demand_Letter"] == DBNull.Value)
                    this._Demand_Letter = null;
                else
                    this._Demand_Letter = (string)drCRM_Customer["Demand_Letter"];

                if (drCRM_Customer["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drCRM_Customer["Update_Date"];

                if (drCRM_Customer["Last_Action"] == DBNull.Value)
                    this._Last_Action = null;
                else
                    this._Last_Action = (string)drCRM_Customer["Last_Action"];

                if (drCRM_Customer["Field_Resolution_Information"] == DBNull.Value)
                    this._Field_Resolution_Information = null;
                else
                    this._Field_Resolution_Information = (string)drCRM_Customer["Field_Resolution_Information"];

                if (drCRM_Customer["Resolution_Summary"] == DBNull.Value)
                    this._Resolution_Summary = null;
                else
                    this._Resolution_Summary = (string)drCRM_Customer["Resolution_Summary"];

                if (drCRM_Customer["Complete"] == DBNull.Value)
                    this._Complete = null;
                else
                    this._Complete = (string)drCRM_Customer["Complete"];

                if (drCRM_Customer["Close_Date"] == DBNull.Value)
                    this._Close_Date = null;
                else
                    this._Close_Date = (DateTime?)drCRM_Customer["Close_Date"];

                if (drCRM_Customer["Days_To_Close"] == DBNull.Value)
                    this._Days_To_Close = null;
                else
                    this._Days_To_Close = (decimal?)drCRM_Customer["Days_To_Close"];

                if (drCRM_Customer["Customer_Callback_After_Resolution"] == DBNull.Value)
                    this._Customer_Callback_After_Resolution = null;
                else
                    this._Customer_Callback_After_Resolution = (string)drCRM_Customer["Customer_Callback_After_Resolution"];

                if (drCRM_Customer["Resolution_Letter_To_Customer"] == DBNull.Value)
                    this._Resolution_Letter_To_Customer = null;
                else
                    this._Resolution_Letter_To_Customer = (string)drCRM_Customer["Resolution_Letter_To_Customer"];

                if (drCRM_Customer["Date_Resolution_Letter_Sent"] == DBNull.Value)
                    this._Date_Resolution_Letter_Sent = null;
                else
                    this._Date_Resolution_Letter_Sent = (DateTime?)drCRM_Customer["Date_Resolution_Letter_Sent"];

                if (drCRM_Customer["User_Update_Date"] == DBNull.Value)
                    this._User_Update_Date = null;
                else
                    this._User_Update_Date = (DateTime?)drCRM_Customer["User_Update_Date"];

                if (drCRM_Customer["FK_LU_CRM_Response_Method"] == DBNull.Value)
                    this._FK_LU_CRM_Response_Method = null;
                else
                    this._FK_LU_CRM_Response_Method = (decimal?)drCRM_Customer["FK_LU_CRM_Response_Method"];

                if (drCRM_Customer["Letter_NA"] == DBNull.Value)
                    this._Letter_NA = null;
                else
                    this._Letter_NA = (string)drCRM_Customer["Letter_NA"];

                if (drCRM_Customer["FK_LU_CRM_Letter_NA_Reason"] == DBNull.Value)
                    this._FK_LU_CRM_Letter_NA_Reason = null;
                else
                    this._FK_LU_CRM_Letter_NA_Reason = (decimal?)drCRM_Customer["FK_LU_CRM_Letter_NA_Reason"];

                if (drCRM_Customer["Letter_NA_Note"] == DBNull.Value)
                    this._Letter_NA_Note = null;
                else
                    this._Letter_NA_Note = (string)drCRM_Customer["Letter_NA_Note"];

                if (drCRM_Customer["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drCRM_Customer["Updated_By"];

            }
            else
            {
                this._PK_CRM_Customer = null;
                this._Record_Date = null;
                this._FK_LU_CRM_Source = null;
                this._Last_Name = null;
                this._First_Name = null;
                this._Address = null;
                this._City = null;
                this._FK_State = null;
                this._Zip_Code = null;
                this._Email = null;
                this._Home_Telephone = null;
                this._Cell_Telephone = null;
                this._Work_Telephone = null;
                this._Work_Telephone_Extension = null;
                this._Summary = null;
                this._FK_LU_CRM_Department = null;
                this._FK_LU_CRM_Dept_Desc_Detail = null;
                this._Service_Date = null;
                this._Service_Date_Est = null;
                this._FK_LU_Location = null;
                this._FK_LU_CRM_Brand = null;
                this._Model = null;
                this._Year = null;
                this._FK_LU_CRM_Contacted_Resolution_2 = null;
                this._FK_LU_CRM_Contacted_Resolution_1 = null;
                this._Resolution_Manager = null;
                this._Resolution_Manager_Email = null;
                this._Customer_Contacted_GM = null;
                this._GM_Contact_Date = null;
                this._GM_Name = null;
                this._RVP_Contact_Date = null;
                this._FK_LU_CRM_RVP = null;
                this._DFOD_Contact_Date = null;
                this._FK_LU_CRM_DFOD = null;
                this._Other_Cotnact_Name = null;
                this._Legal_Attorney_General = null;
                this._FK_LU_CRM_Legal_Email = null;
                this._Demand_Letter = null;
                this._Update_Date = null;
                this._Last_Action = null;
                this._Field_Resolution_Information = null;
                this._Resolution_Summary = null;
                this._Complete = null;
                this._Close_Date = null;
                this._Days_To_Close = null;
                this._Customer_Callback_After_Resolution = null;
                this._Resolution_Letter_To_Customer = null;
                this._Date_Resolution_Letter_Sent = null;
                this._User_Update_Date = null;
                this._FK_LU_CRM_Response_Method = null;
                this._Letter_NA = null;
                this._FK_LU_CRM_Letter_NA_Reason = null;
                this._Letter_NA_Note = null;
                this._Updated_By = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the CRM_Customer table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("CRM_CustomerInsert");


            db.AddInParameter(dbCommand, "Record_Date", DbType.DateTime, this._Record_Date);

            db.AddInParameter(dbCommand, "FK_LU_CRM_Source", DbType.Decimal, this._FK_LU_CRM_Source);

            if (string.IsNullOrEmpty(this._Last_Name))
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, this._Last_Name);

            if (string.IsNullOrEmpty(this._First_Name))
                db.AddInParameter(dbCommand, "First_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "First_Name", DbType.String, this._First_Name);

            if (string.IsNullOrEmpty(this._Address))
                db.AddInParameter(dbCommand, "Address", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address", DbType.String, this._Address);

            if (string.IsNullOrEmpty(this._City))
                db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "City", DbType.String, this._City);

            db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);

            if (string.IsNullOrEmpty(this._Zip_Code))
                db.AddInParameter(dbCommand, "Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);

            if (string.IsNullOrEmpty(this._Email))
                db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            if (string.IsNullOrEmpty(this._Home_Telephone))
                db.AddInParameter(dbCommand, "Home_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Home_Telephone", DbType.String, this._Home_Telephone);

            if (string.IsNullOrEmpty(this._Cell_Telephone))
                db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, this._Cell_Telephone);

            if (string.IsNullOrEmpty(this._Work_Telephone))
                db.AddInParameter(dbCommand, "Work_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Work_Telephone", DbType.String, this._Work_Telephone);

            if (string.IsNullOrEmpty(this._Work_Telephone_Extension))
                db.AddInParameter(dbCommand, "Work_Telephone_Extension", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Work_Telephone_Extension", DbType.String, this._Work_Telephone_Extension);

            if (string.IsNullOrEmpty(this._Summary))
                db.AddInParameter(dbCommand, "Summary", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Summary", DbType.String, this._Summary);

            db.AddInParameter(dbCommand, "FK_LU_CRM_Department", DbType.Decimal, this._FK_LU_CRM_Department);

            db.AddInParameter(dbCommand, "FK_LU_CRM_Dept_Desc_Detail", DbType.Decimal, this._FK_LU_CRM_Dept_Desc_Detail);

            db.AddInParameter(dbCommand, "Service_Date", DbType.DateTime, this._Service_Date);

            if (string.IsNullOrEmpty(this._Service_Date_Est))
                db.AddInParameter(dbCommand, "Service_Date_Est", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Service_Date_Est", DbType.String, this._Service_Date_Est);

            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);

            db.AddInParameter(dbCommand, "FK_LU_CRM_Brand", DbType.Decimal, this._FK_LU_CRM_Brand);

            if (string.IsNullOrEmpty(this._Model))
                db.AddInParameter(dbCommand, "Model", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Model", DbType.String, this._Model);

            db.AddInParameter(dbCommand, "Year", DbType.Decimal, this._Year);

            db.AddInParameter(dbCommand, "FK_LU_CRM_Contacted_Resolution_2", DbType.Decimal, this._FK_LU_CRM_Contacted_Resolution_2);

            db.AddInParameter(dbCommand, "FK_LU_CRM_Contacted_Resolution_1", DbType.Decimal, this._FK_LU_CRM_Contacted_Resolution_1);

            if (string.IsNullOrEmpty(this._Resolution_Manager))
                db.AddInParameter(dbCommand, "Resolution_Manager", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Resolution_Manager", DbType.String, this._Resolution_Manager);

            if (string.IsNullOrEmpty(this._Resolution_Manager_Email))
                db.AddInParameter(dbCommand, "Resolution_Manager_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Resolution_Manager_Email", DbType.String, this._Resolution_Manager_Email);

            if (string.IsNullOrEmpty(this._Customer_Contacted_GM))
                db.AddInParameter(dbCommand, "Customer_Contacted_GM", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Customer_Contacted_GM", DbType.String, this._Customer_Contacted_GM);

            db.AddInParameter(dbCommand, "GM_Contact_Date", DbType.DateTime, this._GM_Contact_Date);

            if (string.IsNullOrEmpty(this._GM_Name))
                db.AddInParameter(dbCommand, "GM_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "GM_Name", DbType.String, this._GM_Name);

            db.AddInParameter(dbCommand, "RVP_Contact_Date", DbType.DateTime, this._RVP_Contact_Date);

            db.AddInParameter(dbCommand, "FK_LU_CRM_RVP", DbType.Decimal, this._FK_LU_CRM_RVP);

            db.AddInParameter(dbCommand, "DFOD_Contact_Date", DbType.DateTime, this._DFOD_Contact_Date);

            db.AddInParameter(dbCommand, "FK_LU_CRM_DFOD", DbType.Decimal, this._FK_LU_CRM_DFOD);

            if (string.IsNullOrEmpty(this._Other_Cotnact_Name))
                db.AddInParameter(dbCommand, "Other_Cotnact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Cotnact_Name", DbType.String, this._Other_Cotnact_Name);

            if (string.IsNullOrEmpty(this._Legal_Attorney_General))
                db.AddInParameter(dbCommand, "Legal_Attorney_General", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Legal_Attorney_General", DbType.String, this._Legal_Attorney_General);

            db.AddInParameter(dbCommand, "FK_LU_CRM_Legal_Email", DbType.Decimal, this._FK_LU_CRM_Legal_Email);

            if (string.IsNullOrEmpty(this._Demand_Letter))
                db.AddInParameter(dbCommand, "Demand_Letter", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Demand_Letter", DbType.String, this._Demand_Letter);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Last_Action))
                db.AddInParameter(dbCommand, "Last_Action", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Last_Action", DbType.String, this._Last_Action);

            if (string.IsNullOrEmpty(this._Field_Resolution_Information))
                db.AddInParameter(dbCommand, "Field_Resolution_Information", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Field_Resolution_Information", DbType.String, this._Field_Resolution_Information);

            if (string.IsNullOrEmpty(this._Resolution_Summary))
                db.AddInParameter(dbCommand, "Resolution_Summary", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Resolution_Summary", DbType.String, this._Resolution_Summary);

            if (string.IsNullOrEmpty(this._Complete))
                db.AddInParameter(dbCommand, "Complete", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Complete", DbType.String, this._Complete);

            db.AddInParameter(dbCommand, "Close_Date", DbType.DateTime, this._Close_Date);

            db.AddInParameter(dbCommand, "Days_To_Close", DbType.Decimal, this._Days_To_Close);

            if (string.IsNullOrEmpty(this._Customer_Callback_After_Resolution))
                db.AddInParameter(dbCommand, "Customer_Callback_After_Resolution", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Customer_Callback_After_Resolution", DbType.String, this._Customer_Callback_After_Resolution);

            if (string.IsNullOrEmpty(this._Resolution_Letter_To_Customer))
                db.AddInParameter(dbCommand, "Resolution_Letter_To_Customer", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Resolution_Letter_To_Customer", DbType.String, this._Resolution_Letter_To_Customer);

            db.AddInParameter(dbCommand, "Date_Resolution_Letter_Sent", DbType.DateTime, this._Date_Resolution_Letter_Sent);
            db.AddInParameter(dbCommand, "User_Update_Date", DbType.DateTime, this._User_Update_Date);
            

            db.AddInParameter(dbCommand, "FK_LU_CRM_Response_Method", DbType.Decimal, this._FK_LU_CRM_Response_Method);

            if (string.IsNullOrEmpty(this._Letter_NA))
                db.AddInParameter(dbCommand, "Letter_NA", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Letter_NA", DbType.String, this._Letter_NA);

            db.AddInParameter(dbCommand, "FK_LU_CRM_Letter_NA_Reason", DbType.Decimal, this._FK_LU_CRM_Letter_NA_Reason);

            if (string.IsNullOrEmpty(this._Letter_NA_Note))
                db.AddInParameter(dbCommand, "Letter_NA_Note", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Letter_NA_Note", DbType.String, this._Letter_NA_Note);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the CRM_Customer table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_CRM_Customer)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("CRM_CustomerSelectByPK");

            db.AddInParameter(dbCommand, "PK_CRM_Customer", DbType.Decimal, pK_CRM_Customer);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the CRM_Customer table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("CRM_CustomerSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the CRM_Customer table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("CRM_CustomerUpdate");


            db.AddInParameter(dbCommand, "PK_CRM_Customer", DbType.Decimal, this._PK_CRM_Customer);

            db.AddInParameter(dbCommand, "Record_Date", DbType.DateTime, this._Record_Date);

            db.AddInParameter(dbCommand, "FK_LU_CRM_Source", DbType.Decimal, this._FK_LU_CRM_Source);

            if (string.IsNullOrEmpty(this._Last_Name))
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, this._Last_Name);

            if (string.IsNullOrEmpty(this._First_Name))
                db.AddInParameter(dbCommand, "First_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "First_Name", DbType.String, this._First_Name);

            if (string.IsNullOrEmpty(this._Address))
                db.AddInParameter(dbCommand, "Address", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address", DbType.String, this._Address);

            if (string.IsNullOrEmpty(this._City))
                db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "City", DbType.String, this._City);

            db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);

            if (string.IsNullOrEmpty(this._Zip_Code))
                db.AddInParameter(dbCommand, "Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);

            if (string.IsNullOrEmpty(this._Email))
                db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            if (string.IsNullOrEmpty(this._Home_Telephone))
                db.AddInParameter(dbCommand, "Home_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Home_Telephone", DbType.String, this._Home_Telephone);

            if (string.IsNullOrEmpty(this._Cell_Telephone))
                db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, this._Cell_Telephone);

            if (string.IsNullOrEmpty(this._Work_Telephone))
                db.AddInParameter(dbCommand, "Work_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Work_Telephone", DbType.String, this._Work_Telephone);

            if (string.IsNullOrEmpty(this._Work_Telephone_Extension))
                db.AddInParameter(dbCommand, "Work_Telephone_Extension", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Work_Telephone_Extension", DbType.String, this._Work_Telephone_Extension);

            if (string.IsNullOrEmpty(this._Summary))
                db.AddInParameter(dbCommand, "Summary", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Summary", DbType.String, this._Summary);

            db.AddInParameter(dbCommand, "FK_LU_CRM_Department", DbType.Decimal, this._FK_LU_CRM_Department);

            db.AddInParameter(dbCommand, "FK_LU_CRM_Dept_Desc_Detail", DbType.Decimal, this._FK_LU_CRM_Dept_Desc_Detail);

            db.AddInParameter(dbCommand, "Service_Date", DbType.DateTime, this._Service_Date);

            if (string.IsNullOrEmpty(this._Service_Date_Est))
                db.AddInParameter(dbCommand, "Service_Date_Est", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Service_Date_Est", DbType.String, this._Service_Date_Est);

            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);

            db.AddInParameter(dbCommand, "FK_LU_CRM_Brand", DbType.Decimal, this._FK_LU_CRM_Brand);

            if (string.IsNullOrEmpty(this._Model))
                db.AddInParameter(dbCommand, "Model", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Model", DbType.String, this._Model);

            db.AddInParameter(dbCommand, "Year", DbType.Decimal, this._Year);

            db.AddInParameter(dbCommand, "FK_LU_CRM_Contacted_Resolution_2", DbType.Decimal, this._FK_LU_CRM_Contacted_Resolution_2);

            db.AddInParameter(dbCommand, "FK_LU_CRM_Contacted_Resolution_1", DbType.Decimal, this._FK_LU_CRM_Contacted_Resolution_1);

            if (string.IsNullOrEmpty(this._Resolution_Manager))
                db.AddInParameter(dbCommand, "Resolution_Manager", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Resolution_Manager", DbType.String, this._Resolution_Manager);

            if (string.IsNullOrEmpty(this._Resolution_Manager_Email))
                db.AddInParameter(dbCommand, "Resolution_Manager_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Resolution_Manager_Email", DbType.String, this._Resolution_Manager_Email);

            if (string.IsNullOrEmpty(this._Customer_Contacted_GM))
                db.AddInParameter(dbCommand, "Customer_Contacted_GM", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Customer_Contacted_GM", DbType.String, this._Customer_Contacted_GM);

            db.AddInParameter(dbCommand, "GM_Contact_Date", DbType.DateTime, this._GM_Contact_Date);

            if (string.IsNullOrEmpty(this._GM_Name))
                db.AddInParameter(dbCommand, "GM_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "GM_Name", DbType.String, this._GM_Name);

            db.AddInParameter(dbCommand, "RVP_Contact_Date", DbType.DateTime, this._RVP_Contact_Date);

            db.AddInParameter(dbCommand, "FK_LU_CRM_RVP", DbType.Decimal, this._FK_LU_CRM_RVP);

            db.AddInParameter(dbCommand, "DFOD_Contact_Date", DbType.DateTime, this._DFOD_Contact_Date);

            db.AddInParameter(dbCommand, "FK_LU_CRM_DFOD", DbType.Decimal, this._FK_LU_CRM_DFOD);

            if (string.IsNullOrEmpty(this._Other_Cotnact_Name))
                db.AddInParameter(dbCommand, "Other_Cotnact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Cotnact_Name", DbType.String, this._Other_Cotnact_Name);

            if (string.IsNullOrEmpty(this._Legal_Attorney_General))
                db.AddInParameter(dbCommand, "Legal_Attorney_General", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Legal_Attorney_General", DbType.String, this._Legal_Attorney_General);

            db.AddInParameter(dbCommand, "FK_LU_CRM_Legal_Email", DbType.Decimal, this._FK_LU_CRM_Legal_Email);

            if (string.IsNullOrEmpty(this._Demand_Letter))
                db.AddInParameter(dbCommand, "Demand_Letter", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Demand_Letter", DbType.String, this._Demand_Letter);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Last_Action))
                db.AddInParameter(dbCommand, "Last_Action", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Last_Action", DbType.String, this._Last_Action);

            if (string.IsNullOrEmpty(this._Field_Resolution_Information))
                db.AddInParameter(dbCommand, "Field_Resolution_Information", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Field_Resolution_Information", DbType.String, this._Field_Resolution_Information);

            if (string.IsNullOrEmpty(this._Resolution_Summary))
                db.AddInParameter(dbCommand, "Resolution_Summary", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Resolution_Summary", DbType.String, this._Resolution_Summary);

            if (string.IsNullOrEmpty(this._Complete))
                db.AddInParameter(dbCommand, "Complete", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Complete", DbType.String, this._Complete);

            db.AddInParameter(dbCommand, "Close_Date", DbType.DateTime, this._Close_Date);

            db.AddInParameter(dbCommand, "Days_To_Close", DbType.Decimal, this._Days_To_Close);

            if (string.IsNullOrEmpty(this._Customer_Callback_After_Resolution))
                db.AddInParameter(dbCommand, "Customer_Callback_After_Resolution", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Customer_Callback_After_Resolution", DbType.String, this._Customer_Callback_After_Resolution);

            if (string.IsNullOrEmpty(this._Resolution_Letter_To_Customer))
                db.AddInParameter(dbCommand, "Resolution_Letter_To_Customer", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Resolution_Letter_To_Customer", DbType.String, this._Resolution_Letter_To_Customer);

            db.AddInParameter(dbCommand, "Date_Resolution_Letter_Sent", DbType.DateTime, this._Date_Resolution_Letter_Sent);
            db.AddInParameter(dbCommand, "User_Update_Date", DbType.DateTime, this._User_Update_Date);

            db.AddInParameter(dbCommand, "FK_LU_CRM_Response_Method", DbType.Decimal, this._FK_LU_CRM_Response_Method);

            if (string.IsNullOrEmpty(this._Letter_NA))
                db.AddInParameter(dbCommand, "Letter_NA", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Letter_NA", DbType.String, this._Letter_NA);

            db.AddInParameter(dbCommand, "FK_LU_CRM_Letter_NA_Reason", DbType.Decimal, this._FK_LU_CRM_Letter_NA_Reason);

            if (string.IsNullOrEmpty(this._Letter_NA_Note))
                db.AddInParameter(dbCommand, "Letter_NA_Note", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Letter_NA_Note", DbType.String, this._Letter_NA_Note);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the CRM_Customer table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_CRM_Customer)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("CRM_CustomerDeleteByPK");

            db.AddInParameter(dbCommand, "PK_CRM_Customer", DbType.Decimal, pK_CRM_Customer);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Search Customer Incident Records
        /// </summary>
        /// <param name="PK_CRM_Customer"></param>
        /// <param name="Report_Date_From"></param>
        /// <param name="Report_Date_To"></param>
        /// <param name="FK_LU_CRM_Source"></param>
        /// <param name="Last_Name"></param>
        /// <param name="First_Name"></param>
        /// <param name="FK_LU_CRM_Department"></param>
        /// <param name="FK_LU_Location"></param>
        /// <param name="Update_Date_From"></param>
        /// <param name="Update_Date_To"></param>
        /// <param name="Last_Action"></param>
        /// <param name="Complete"></param>
        /// <param name="Close_Date_From"></param>
        /// <param name="Close_Date_To"></param>
        /// <param name="Resolution_Letter_To_Customer"></param>
        /// <param name="Date_Resolution_Letter_Sent_From"></param>
        /// <param name="Date_Resolution_Letter_Sent_To"></param>
        /// <param name="LetterNA"></param>
        /// <param name="strOrderBy"></param>
        /// <param name="strOrder"></param>
        /// <param name="intPageNo"></param>
        /// <param name="intPageSize"></param>
        /// <returns></returns>
        public static DataSet CRM_Customer_Search(decimal PK_CRM_Customer, Nullable<DateTime> Report_Date_From, Nullable<DateTime> Report_Date_To, decimal FK_LU_CRM_Source,
            string Last_Name, string First_Name, decimal FK_LU_CRM_Department, decimal FK_LU_Location, Nullable<DateTime> Update_Date_From, Nullable<DateTime> Update_Date_To,
            string Last_Action, string Complete, Nullable<DateTime> Close_Date_From, Nullable<DateTime> Close_Date_To, string Resolution_Letter_To_Customer,
            Nullable<DateTime> Date_Resolution_Letter_Sent_From, Nullable<DateTime> Date_Resolution_Letter_Sent_To, string LetterNA,
            string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("CRM_CustomerSearch");

            db.AddInParameter(dbCommand, "PK_CRM_Customer", DbType.Decimal, PK_CRM_Customer);
            db.AddInParameter(dbCommand, "Report_Date_From", DbType.DateTime, Report_Date_From);
            db.AddInParameter(dbCommand, "Report_Date_To", DbType.DateTime, Report_Date_To);
            db.AddInParameter(dbCommand, "FK_LU_CRM_Source", DbType.Decimal, FK_LU_CRM_Source);
            db.AddInParameter(dbCommand, "Last_Name", DbType.String, Last_Name);
            db.AddInParameter(dbCommand, "First_Name", DbType.String, First_Name);
            db.AddInParameter(dbCommand, "FK_LU_CRM_Department", DbType.Decimal, FK_LU_CRM_Department);
            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, FK_LU_Location);
            db.AddInParameter(dbCommand, "Update_Date_From", DbType.DateTime, Update_Date_From);
            db.AddInParameter(dbCommand, "Update_Date_To", DbType.DateTime, Update_Date_To);
            db.AddInParameter(dbCommand, "Last_Action", DbType.String, Last_Action);
            db.AddInParameter(dbCommand, "Complete", DbType.String, Complete);
            db.AddInParameter(dbCommand, "Close_Date_From", DbType.DateTime, Close_Date_From);
            db.AddInParameter(dbCommand, "Close_Date_To", DbType.DateTime, Close_Date_To);
            db.AddInParameter(dbCommand, "Resolution_Letter_To_Customer", DbType.String, Resolution_Letter_To_Customer);
            db.AddInParameter(dbCommand, "Date_Resolution_Letter_Sent_From", DbType.DateTime, Date_Resolution_Letter_Sent_From);
            db.AddInParameter(dbCommand, "Date_Resolution_Letter_Sent_To", DbType.DateTime, Date_Resolution_Letter_Sent_To);
            db.AddInParameter(dbCommand, "LetterNA", DbType.String, LetterNA);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.String, intPageSize);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// select by serach criteria
        /// </summary>
        /// <returns></returns>
        public static DataSet CRM_NonCustomer_Search(decimal PK_CRM_Non_Customer, Nullable<DateTime> Report_Date_From, Nullable<DateTime> Report_Date_To, decimal FK_LU_CRM_Source,
            string Last_Name, decimal FK_LU_Location, decimal FK_LU_CRM_Category, string Response_Sent, Nullable<DateTime> Response_Date_From, Nullable<DateTime> Response_Date_To,
            string Response_NA,string Company_Name, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("CRM_NonCustomerSearch");

            db.AddInParameter(dbCommand, "PK_CRM_Non_Customer", DbType.Decimal, PK_CRM_Non_Customer);
            db.AddInParameter(dbCommand, "Report_Date_From", DbType.DateTime, Report_Date_From);
            db.AddInParameter(dbCommand, "Report_Date_To", DbType.DateTime, Report_Date_To);
            db.AddInParameter(dbCommand, "FK_LU_CRM_Source", DbType.Decimal, FK_LU_CRM_Source);
            db.AddInParameter(dbCommand, "Last_Name", DbType.String, Last_Name);
            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, FK_LU_Location);
            db.AddInParameter(dbCommand, "FK_LU_CRM_Category", DbType.Decimal, FK_LU_CRM_Category);
            db.AddInParameter(dbCommand, "Response_Sent", DbType.String, Response_Sent);
            db.AddInParameter(dbCommand, "Response_Date_From", DbType.DateTime, Response_Date_From);
            db.AddInParameter(dbCommand, "Response_Date_To", DbType.DateTime, Response_Date_To);
            db.AddInParameter(dbCommand, "Response_NA", DbType.String, Response_NA);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));
            db.AddInParameter(dbCommand, "Company_Name", DbType.String, Company_Name);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.String, intPageSize);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
