using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Enviro_Equipment table.
    /// </summary>
    public sealed class Enviro_Equipment
    {
        #region Fields


        private int _PK_Enviro_Equipment_ID;
        private int _FK_LU_Location_ID;
        private string _Identification;
        private string _type;
        private string _Contents;
        private string _Contents_Other;
        private string _status;
        private string _Material;
        private string _Material_Other;
        private string _Construction;
        private string _Construction_Other;
        private string _Release_Equipment_Description;
        private Nullable<bool> _Release_Equipment_Present;
        private Nullable<bool> _Overfill_Protection;
        private Nullable<bool> _Leak_Detection;
        private string _Leak_Detection_Type;
        private string _Insurer;
        private Nullable<decimal> _Single_Event_Coverage;
        private Nullable<decimal> _Multiple_Event_Total_Coverage;
        private Nullable<decimal> _Capacity;
        private Nullable<DateTime> _Coverage_Start_Date;
        private Nullable<DateTime> _Coverage_End_Date;
        private Nullable<bool> _Flows_to_POTW;
        private Nullable<DateTime> _Date_of_Last_Service;
        private Nullable<bool> _TCLP_on_File;
        private Nullable<DateTime> _Date_of_Last_TCLP;
        private Nullable<DateTime> _Installation_Date;
        private Nullable<DateTime> _Removal_Date;
        private Nullable<DateTime> _Closure_Date;
        private Nullable<DateTime> _Last_Inspection_Date;
        private Nullable<DateTime> _Next_Inspection_Date;
        private string _Insurance_Company;
        private string _Inspection_Contact;
        private string _Inspection_Phone;
        private Nullable<bool> _Registration_Required;
        private string _Registration_Number;
        private string _Certificate_Number;
        private Nullable<DateTime> _Permit_Begin_Date;
        private Nullable<DateTime> _Permit_End_Date;
        private Nullable<bool> _Other_Req;
        private string _Other_Req_Descr;
        private Nullable<DateTime> _Next_Report_Date;
        private string _Notes;
        private string _Plan_ID;
        private Nullable<DateTime> _Plan_Effective_Date;
        private Nullable<DateTime> _Plan_Expiration_Date;
        private Nullable<DateTime> _Plan_Revision_Date;
        private string _Plan_Vendor;
        private string _Plan_Vendor_Contact;
        private string _Plan_Phone;
        private DateTime _Update_Date;
        private string _Updated_By;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Enviro_Equipment_ID value.
        /// </summary>
        public int PK_Enviro_Equipment_ID
        {
            get { return _PK_Enviro_Equipment_ID; }
            set { _PK_Enviro_Equipment_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_LU_Location_ID value.
        /// </summary>
        public int FK_LU_Location_ID
        {
            get { return _FK_LU_Location_ID; }
            set { _FK_LU_Location_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Identification value.
        /// </summary>
        public string Identification
        {
            get { return _Identification; }
            set { _Identification = value; }
        }


        /// <summary> 
        /// Gets or sets the type value.
        /// </summary>
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }


        /// <summary> 
        /// Gets or sets the Contents value.
        /// </summary>
        public string Contents
        {
            get { return _Contents; }
            set { _Contents = value; }
        }


        /// <summary> 
        /// Gets or sets the Contents_Other value.
        /// </summary>
        public string Contents_Other
        {
            get { return _Contents_Other; }
            set { _Contents_Other = value; }
        }


        /// <summary> 
        /// Gets or sets the status value.
        /// </summary>
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }


        /// <summary> 
        /// Gets or sets the Material value.
        /// </summary>
        public string Material
        {
            get { return _Material; }
            set { _Material = value; }
        }


        /// <summary> 
        /// Gets or sets the Material_Other value.
        /// </summary>
        public string Material_Other
        {
            get { return _Material_Other; }
            set { _Material_Other = value; }
        }


        /// <summary> 
        /// Gets or sets the Construction value.
        /// </summary>
        public string Construction
        {
            get { return _Construction; }
            set { _Construction = value; }
        }


        /// <summary> 
        /// Gets or sets the Construction_Other value.
        /// </summary>
        public string Construction_Other
        {
            get { return _Construction_Other; }
            set { _Construction_Other = value; }
        }

        /// <summary> 
        /// Gets or sets the Capacity  value.
        /// </summary>
        public Nullable<decimal> Capacity
        {
            get { return _Capacity; }
            set { _Capacity = value; }
        }

        /// <summary> 
        /// Gets or sets the Release_Equipment_Description value.
        /// </summary>
        public string Release_Equipment_Description
        {
            get { return _Release_Equipment_Description; }
            set { _Release_Equipment_Description = value; }
        }

        /// <summary> 
        /// Gets or sets the Release_Equipment_Present value.
        /// </summary>
        public Nullable<bool> Release_Equipment_Present
        {
            get { return _Release_Equipment_Present; }
            set { _Release_Equipment_Present = value; }
        }

        /// <summary> 
        /// Gets or sets the Overfill_Protection value.
        /// </summary>
        public Nullable<bool> Overfill_Protection
        {
            get { return _Overfill_Protection; }
            set { _Overfill_Protection = value; }
        }


        /// <summary> 
        /// Gets or sets the Leak_Detection value.
        /// </summary>
        public Nullable<bool> Leak_Detection
        {
            get { return _Leak_Detection; }
            set { _Leak_Detection = value; }
        }


        /// <summary> 
        /// Gets or sets the Leak_Detection_Type value.
        /// </summary>
        public string Leak_Detection_Type
        {
            get { return _Leak_Detection_Type; }
            set { _Leak_Detection_Type = value; }
        }


        /// <summary> 
        /// Gets or sets the Insurer value.
        /// </summary>
        public string Insurer
        {
            get { return _Insurer; }
            set { _Insurer = value; }
        }


        /// <summary> 
        /// Gets or sets the Single_Event_Coverage value.
        /// </summary>
        public Nullable<decimal> Single_Event_Coverage
        {
            get { return _Single_Event_Coverage; }
            set { _Single_Event_Coverage = value; }
        }


        /// <summary> 
        /// Gets or sets the Multiple_Event_Total_Coverage value.
        /// </summary>
        public Nullable<decimal> Multiple_Event_Total_Coverage
        {
            get { return _Multiple_Event_Total_Coverage; }
            set { _Multiple_Event_Total_Coverage = value; }
        }


        /// <summary> 
        /// Gets or sets the Coverage_Start_Date value.
        /// </summary>
        public Nullable<DateTime> Coverage_Start_Date
        {
            get { return _Coverage_Start_Date; }
            set { _Coverage_Start_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Coverage_End_Date value.
        /// </summary>
        public Nullable<DateTime> Coverage_End_Date
        {
            get { return _Coverage_End_Date; }
            set { _Coverage_End_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Flows_to_POTW value.
        /// </summary>
        public Nullable<bool> Flows_to_POTW
        {
            get { return _Flows_to_POTW; }
            set { _Flows_to_POTW = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_of_Last_Service value.
        /// </summary>
        public Nullable<DateTime> Date_of_Last_Service
        {
            get { return _Date_of_Last_Service; }
            set { _Date_of_Last_Service = value; }
        }


        /// <summary> 
        /// Gets or sets the TCLP_on_File value.
        /// </summary>
        public Nullable<bool> TCLP_on_File
        {
            get { return _TCLP_on_File; }
            set { _TCLP_on_File = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_of_Last_TCLP value.
        /// </summary>
        public Nullable<DateTime> Date_of_Last_TCLP
        {
            get { return _Date_of_Last_TCLP; }
            set { _Date_of_Last_TCLP = value; }
        }


        /// <summary> 
        /// Gets or sets the Installation_Date value.
        /// </summary>
        public Nullable<DateTime> Installation_Date
        {
            get { return _Installation_Date; }
            set { _Installation_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Removal_Date value.
        /// </summary>
        public Nullable<DateTime> Removal_Date
        {
            get { return _Removal_Date; }
            set { _Removal_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Closure_Date value.
        /// </summary>
        public Nullable<DateTime> Closure_Date
        {
            get { return _Closure_Date; }
            set { _Closure_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Last_Inspection_Date value.
        /// </summary>
        public Nullable<DateTime> Last_Inspection_Date
        {
            get { return _Last_Inspection_Date; }
            set { _Last_Inspection_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Next_Inspection_Date value.
        /// </summary>
        public Nullable<DateTime> Next_Inspection_Date
        {
            get { return _Next_Inspection_Date; }
            set { _Next_Inspection_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Insurance_Company value.
        /// </summary>
        public string Insurance_Company
        {
            get { return _Insurance_Company; }
            set { _Insurance_Company = value; }
        }


        /// <summary> 
        /// Gets or sets the Inspection_Contact value.
        /// </summary>
        public string Inspection_Contact
        {
            get { return _Inspection_Contact; }
            set { _Inspection_Contact = value; }
        }


        /// <summary> 
        /// Gets or sets the Inspection_Phone value.
        /// </summary>
        public string Inspection_Phone
        {
            get { return _Inspection_Phone; }
            set { _Inspection_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Registration_Required value.
        /// </summary>
        public Nullable<bool> Registration_Required
        {
            get { return _Registration_Required; }
            set { _Registration_Required = value; }
        }


        /// <summary> 
        /// Gets or sets the Registration_Number value.
        /// </summary>
        public string Registration_Number
        {
            get { return _Registration_Number; }
            set { _Registration_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Certificate_Number value.
        /// </summary>
        public string Certificate_Number
        {
            get { return _Certificate_Number; }
            set { _Certificate_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Permit_Begin_Date value.
        /// </summary>
        public Nullable<DateTime> Permit_Begin_Date
        {
            get { return _Permit_Begin_Date; }
            set { _Permit_Begin_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Permit_End_Date value.
        /// </summary>
        public Nullable<DateTime> Permit_End_Date
        {
            get { return _Permit_End_Date; }
            set { _Permit_End_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Req value.
        /// </summary>
        public Nullable<bool> Other_Req
        {
            get { return _Other_Req; }
            set { _Other_Req = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Req_Descr value.
        /// </summary>
        public string Other_Req_Descr
        {
            get { return _Other_Req_Descr; }
            set { _Other_Req_Descr = value; }
        }


        /// <summary> 
        /// Gets or sets the Next_Report_Date value.
        /// </summary>
        public Nullable<DateTime> Next_Report_Date
        {
            get { return _Next_Report_Date; }
            set { _Next_Report_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Notes value.
        /// </summary>
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }


        /// <summary> 
        /// Gets or sets the Plan_ID value.
        /// </summary>
        public string Plan_ID
        {
            get { return _Plan_ID; }
            set { _Plan_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Plan_Effective_Date value.
        /// </summary>
        public Nullable<DateTime> Plan_Effective_Date
        {
            get { return _Plan_Effective_Date; }
            set { _Plan_Effective_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Plan_Expiration_Date value.
        /// </summary>
        public Nullable<DateTime> Plan_Expiration_Date
        {
            get { return _Plan_Expiration_Date; }
            set { _Plan_Expiration_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Plan_Revision_Date value.
        /// </summary>
        public Nullable<DateTime> Plan_Revision_Date
        {
            get { return _Plan_Revision_Date; }
            set { _Plan_Revision_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Plan_Vendor value.
        /// </summary>
        public string Plan_Vendor
        {
            get { return _Plan_Vendor; }
            set { _Plan_Vendor = value; }
        }


        /// <summary> 
        /// Gets or sets the Plan_Vendor_Contact value.
        /// </summary>
        public string Plan_Vendor_Contact
        {
            get { return _Plan_Vendor_Contact; }
            set { _Plan_Vendor_Contact = value; }
        }


        /// <summary> 
        /// Gets or sets the Plan_Phone value.
        /// </summary>
        public string Plan_Phone
        {
            get { return _Plan_Phone; }
            set { _Plan_Phone = value; }
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
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }

        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Enviro_Equipment class. with the default value.

        /// </summary>
        public Enviro_Equipment()
        {

            this._PK_Enviro_Equipment_ID = -1;
            this._FK_LU_Location_ID = -1;
            this._Identification = "";
            this._type = "";
            this._Contents = "";
            this._Contents_Other = "";
            this._status = "";
            this._Material = "";
            this._Material_Other = "";
            this._Construction = "";
            this._Construction_Other = "";
            this._Release_Equipment_Description = "";
            this._Overfill_Protection = null;
            this._Leak_Detection = null;
            this._Leak_Detection_Type = "";
            this._Insurer = "";
            this._Single_Event_Coverage = null;
            this._Multiple_Event_Total_Coverage = null;
            this._Coverage_Start_Date = null;
            this._Coverage_End_Date = null;
            this._Flows_to_POTW = null;
            this._Date_of_Last_Service = null;
            this._TCLP_on_File = null;
            this._Date_of_Last_TCLP = null;
            this._Installation_Date = null;
            this._Removal_Date = null;
            this._Closure_Date = null;
            this._Last_Inspection_Date = null;
            this._Next_Inspection_Date = null;
            this._Insurance_Company = "";
            this._Inspection_Contact = "";
            this._Inspection_Phone = "";
            this._Registration_Required = false;
            this._Registration_Number = "";
            this._Certificate_Number = "";
            this._Permit_Begin_Date = null;
            this._Permit_End_Date = null;
            this._Other_Req = false;
            this._Other_Req_Descr = "";
            this._Next_Report_Date = null;
            this._Notes = "";
            this._Plan_ID = "";
            this._Plan_Effective_Date = null;
            this._Plan_Expiration_Date = null;
            this._Plan_Revision_Date = null;
            this._Plan_Vendor = "";
            this._Plan_Vendor_Contact = "";
            this._Plan_Phone = "";
            this._Updated_By = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

        }



        /// <summary> 
        /// Initializes a new instance of the Enviro_Equipment class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Enviro_Equipment(int PK)
        {

            DataTable dtEnviro_Equipment = SelectByPK(PK).Tables[0];

            if (dtEnviro_Equipment.Rows.Count > 0)
            {

                DataRow drEnviro_Equipment = dtEnviro_Equipment.Rows[0];

                this._PK_Enviro_Equipment_ID = drEnviro_Equipment["PK_Enviro_Equipment_ID"] != DBNull.Value ? Convert.ToInt32(drEnviro_Equipment["PK_Enviro_Equipment_ID"]) : 0;
                this._FK_LU_Location_ID = drEnviro_Equipment["FK_LU_Location_ID"] != DBNull.Value ? Convert.ToInt32(drEnviro_Equipment["FK_LU_Location_ID"]) : 0;
                this._Identification = Convert.ToString(drEnviro_Equipment["Identification"]);
                this._type = Convert.ToString(drEnviro_Equipment["type"]);
                this._Contents = Convert.ToString(drEnviro_Equipment["Contents"]);
                this._Contents_Other = Convert.ToString(drEnviro_Equipment["Contents_Other"]);
                this._status = Convert.ToString(drEnviro_Equipment["status"]);
                this._Material = Convert.ToString(drEnviro_Equipment["Material"]);
                this._Material_Other = Convert.ToString(drEnviro_Equipment["Material_Other"]);
                this._Construction = Convert.ToString(drEnviro_Equipment["Construction"]);
                this._Construction_Other = Convert.ToString(drEnviro_Equipment["Construction_Other"]);
                this._Release_Equipment_Description = Convert.ToString(drEnviro_Equipment["Release_Equipment_Description"]);
                this._Overfill_Protection = drEnviro_Equipment["Overfill_Protection"] != DBNull.Value ? Convert.ToBoolean(drEnviro_Equipment["Overfill_Protection"]) : false;
                this._Leak_Detection = drEnviro_Equipment["Leak_Detection"] != DBNull.Value ? Convert.ToBoolean(drEnviro_Equipment["Leak_Detection"]) : false;
                this._Leak_Detection_Type = Convert.ToString(drEnviro_Equipment["Leak_Detection_Type"]);
                this._Insurer = Convert.ToString(drEnviro_Equipment["Insurer"]);
                this._Single_Event_Coverage = drEnviro_Equipment["Single_Event_Coverage"] != DBNull.Value ? Convert.ToDecimal(drEnviro_Equipment["Single_Event_Coverage"]) : 0;
                this._Multiple_Event_Total_Coverage = drEnviro_Equipment["Multiple_Event_Total_Coverage"] != DBNull.Value ? Convert.ToDecimal(drEnviro_Equipment["Multiple_Event_Total_Coverage"]) : 0;
                this._Coverage_Start_Date = drEnviro_Equipment["Coverage_Start_Date"] != DBNull.Value ? Convert.ToDateTime(drEnviro_Equipment["Coverage_Start_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Coverage_End_Date = drEnviro_Equipment["Coverage_End_Date"] != DBNull.Value ? Convert.ToDateTime(drEnviro_Equipment["Coverage_End_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Flows_to_POTW = drEnviro_Equipment["Flows_to_POTW"] != DBNull.Value ? Convert.ToBoolean(drEnviro_Equipment["Flows_to_POTW"]) : false;
                this._Date_of_Last_Service = drEnviro_Equipment["Date_of_Last_Service"] != DBNull.Value ? Convert.ToDateTime(drEnviro_Equipment["Date_of_Last_Service"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._TCLP_on_File = drEnviro_Equipment["TCLP_on_File"] != DBNull.Value ? Convert.ToBoolean(drEnviro_Equipment["TCLP_on_File"]) : false;
                this._Date_of_Last_TCLP = drEnviro_Equipment["Date_of_Last_TCLP"] != DBNull.Value ? Convert.ToDateTime(drEnviro_Equipment["Date_of_Last_TCLP"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Installation_Date = drEnviro_Equipment["Installation_Date"] != DBNull.Value ? Convert.ToDateTime(drEnviro_Equipment["Installation_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Removal_Date = drEnviro_Equipment["Removal_Date"] != DBNull.Value ? Convert.ToDateTime(drEnviro_Equipment["Removal_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Closure_Date = drEnviro_Equipment["Closure_Date"] != DBNull.Value ? Convert.ToDateTime(drEnviro_Equipment["Closure_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Last_Inspection_Date = drEnviro_Equipment["Last_Inspection_Date"] != DBNull.Value ? Convert.ToDateTime(drEnviro_Equipment["Last_Inspection_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Next_Inspection_Date = drEnviro_Equipment["Next_Inspection_Date"] != DBNull.Value ? Convert.ToDateTime(drEnviro_Equipment["Next_Inspection_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Insurance_Company = Convert.ToString(drEnviro_Equipment["Insurance_Company"]);
                this._Inspection_Contact = Convert.ToString(drEnviro_Equipment["Inspection_Contact"]);
                this._Inspection_Phone = Convert.ToString(drEnviro_Equipment["Inspection_Phone"]);
                this._Registration_Required = drEnviro_Equipment["Registration_Required"] != DBNull.Value ? Convert.ToBoolean(drEnviro_Equipment["Registration_Required"]) : false;
                this._Registration_Number = Convert.ToString(drEnviro_Equipment["Registration_Number"]);
                this._Certificate_Number = Convert.ToString(drEnviro_Equipment["Certificate_Number"]);
                this._Permit_Begin_Date = drEnviro_Equipment["Permit_Begin_Date"] != DBNull.Value ? Convert.ToDateTime(drEnviro_Equipment["Permit_Begin_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Permit_End_Date = drEnviro_Equipment["Permit_End_Date"] != DBNull.Value ? Convert.ToDateTime(drEnviro_Equipment["Permit_End_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Other_Req = drEnviro_Equipment["Other_Req"] != DBNull.Value ? Convert.ToBoolean(drEnviro_Equipment["Other_Req"]) : false;
                this._Other_Req_Descr = Convert.ToString(drEnviro_Equipment["Other_Req_Descr"]);
                this._Next_Report_Date = drEnviro_Equipment["Next_Report_Date"] != DBNull.Value ? Convert.ToDateTime(drEnviro_Equipment["Next_Report_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Notes = Convert.ToString(drEnviro_Equipment["Notes"]);
                this._Plan_ID = Convert.ToString(drEnviro_Equipment["Plan_ID"]);
                this._Plan_Effective_Date = drEnviro_Equipment["Plan_Effective_Date"] != DBNull.Value ? Convert.ToDateTime(drEnviro_Equipment["Plan_Effective_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Plan_Expiration_Date = drEnviro_Equipment["Plan_Expiration_Date"] != DBNull.Value ? Convert.ToDateTime(drEnviro_Equipment["Plan_Expiration_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Plan_Revision_Date = drEnviro_Equipment["Plan_Revision_Date"] != DBNull.Value ? Convert.ToDateTime(drEnviro_Equipment["Plan_Revision_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Plan_Vendor = Convert.ToString(drEnviro_Equipment["Plan_Vendor"]);
                this._Plan_Vendor_Contact = Convert.ToString(drEnviro_Equipment["Plan_Vendor_Contact"]);
                this._Plan_Phone = Convert.ToString(drEnviro_Equipment["Plan_Phone"]);
                this._Updated_By = drEnviro_Equipment["Updated_By"].ToString();
                this._Update_Date = drEnviro_Equipment["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drEnviro_Equipment["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }

            else
            {

                this._PK_Enviro_Equipment_ID = -1;
                this._FK_LU_Location_ID = -1;
                this._Identification = "";
                this._type = "";
                this._Contents = "";
                this._Contents_Other = "";
                this._status = "";
                this._Material = "";
                this._Material_Other = "";
                this._Construction = "";
                this._Construction_Other = "";
                this._Release_Equipment_Description = "";
                this._Overfill_Protection = false;
                this._Leak_Detection = false;
                this._Leak_Detection_Type = "";
                this._Insurer = "";
                this._Single_Event_Coverage = -1;
                this._Multiple_Event_Total_Coverage = -1;
                this._Coverage_Start_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Coverage_End_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Flows_to_POTW = false;
                this._Date_of_Last_Service = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._TCLP_on_File = false;
                this._Date_of_Last_TCLP = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Installation_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Removal_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Closure_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Last_Inspection_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Next_Inspection_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Insurance_Company = "";
                this._Inspection_Contact = "";
                this._Inspection_Phone = "";
                this._Registration_Required = false;
                this._Registration_Number = "";
                this._Certificate_Number = "";
                this._Permit_Begin_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Permit_End_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Other_Req = false;
                this._Other_Req_Descr = "";
                this._Next_Report_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Notes = "";
                this._Plan_ID = "";
                this._Plan_Effective_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Plan_Expiration_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Plan_Revision_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Plan_Vendor = "";
                this._Plan_Vendor_Contact = "";
                this._Plan_Phone = "";
                this._Updated_By = "";
                this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

        }



        #endregion


        #region Methods

        /// <summary>
        /// Inserts a record into the Enviro_Equipment table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_EquipmentInsert");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, this._FK_LU_Location_ID);
            db.AddInParameter(dbCommand, "Identification", DbType.String, this._Identification);
            db.AddInParameter(dbCommand, "type", DbType.String, this._type);
            db.AddInParameter(dbCommand, "Contents", DbType.String, this._Contents);
            db.AddInParameter(dbCommand, "Contents_Other", DbType.String, this._Contents_Other);
            db.AddInParameter(dbCommand, "Capacity", DbType.Decimal, this._Capacity);
            db.AddInParameter(dbCommand, "status", DbType.String, this._status);
            db.AddInParameter(dbCommand, "Material", DbType.String, this._Material);
            db.AddInParameter(dbCommand, "Material_Other", DbType.String, this._Material_Other);
            db.AddInParameter(dbCommand, "Construction", DbType.String, this._Construction);
            db.AddInParameter(dbCommand, "Construction_Other", DbType.String, this._Construction_Other);
            db.AddInParameter(dbCommand, "Release_Equipment_Present", DbType.Boolean, this._Release_Equipment_Present);
            db.AddInParameter(dbCommand, "Release_Equipment_Description", DbType.String, this._Release_Equipment_Description);
            db.AddInParameter(dbCommand, "Overfill_Protection", DbType.Boolean, this._Overfill_Protection);
            db.AddInParameter(dbCommand, "Leak_Detection", DbType.Boolean, this._Leak_Detection);
            db.AddInParameter(dbCommand, "Leak_Detection_Type", DbType.String, this._Leak_Detection_Type);
            db.AddInParameter(dbCommand, "Insurer", DbType.String, this._Insurer);
            db.AddInParameter(dbCommand, "Single_Event_Coverage", DbType.Decimal, this._Single_Event_Coverage);
            db.AddInParameter(dbCommand, "Multiple_Event_Total_Coverage", DbType.Decimal, this._Multiple_Event_Total_Coverage);
            db.AddInParameter(dbCommand, "Coverage_Start_Date", DbType.DateTime, this._Coverage_Start_Date);
            db.AddInParameter(dbCommand, "Coverage_End_Date", DbType.DateTime, this._Coverage_End_Date);
            db.AddInParameter(dbCommand, "Flows_to_POTW", DbType.Boolean, this._Flows_to_POTW);
            db.AddInParameter(dbCommand, "Date_of_Last_Service", DbType.DateTime, this._Date_of_Last_Service);
            db.AddInParameter(dbCommand, "TCLP_on_File", DbType.Boolean, this._TCLP_on_File);
            db.AddInParameter(dbCommand, "Date_of_Last_TCLP", DbType.DateTime, this._Date_of_Last_TCLP);
            db.AddInParameter(dbCommand, "Installation_Date", DbType.DateTime, this._Installation_Date);
            db.AddInParameter(dbCommand, "Removal_Date", DbType.DateTime, this._Removal_Date);
            db.AddInParameter(dbCommand, "Closure_Date", DbType.DateTime, this._Closure_Date);
            db.AddInParameter(dbCommand, "Last_Inspection_Date", DbType.DateTime, this._Last_Inspection_Date);
            db.AddInParameter(dbCommand, "Next_Inspection_Date", DbType.DateTime, this._Next_Inspection_Date);
            db.AddInParameter(dbCommand, "Insurance_Company", DbType.String, this._Insurance_Company);
            db.AddInParameter(dbCommand, "Inspection_Contact", DbType.String, this._Inspection_Contact);
            db.AddInParameter(dbCommand, "Inspection_Phone", DbType.String, this._Inspection_Phone);
            db.AddInParameter(dbCommand, "Registration_Required", DbType.Boolean, this._Registration_Required);
            db.AddInParameter(dbCommand, "Registration_Number", DbType.String, this._Registration_Number);
            db.AddInParameter(dbCommand, "Certificate_Number", DbType.String, this._Certificate_Number);
            db.AddInParameter(dbCommand, "Permit_Begin_Date", DbType.DateTime, this._Permit_Begin_Date);
            db.AddInParameter(dbCommand, "Permit_End_Date", DbType.DateTime, this._Permit_End_Date);
            db.AddInParameter(dbCommand, "Other_Req", DbType.Boolean, this._Other_Req);
            db.AddInParameter(dbCommand, "Other_Req_Descr", DbType.String, this._Other_Req_Descr);
            db.AddInParameter(dbCommand, "Next_Report_Date", DbType.DateTime, this._Next_Report_Date);
            db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Enviro_Equipment table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(int pK_Enviro_Equipment_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_EquipmentSelectByPK");

            db.AddInParameter(dbCommand, "PK_Enviro_Equipment_ID", DbType.Int32, pK_Enviro_Equipment_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Enviro_Equipment table by a Location ID.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_LU_LocationID(int FK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_EquipmentSelectByFK_LU_Location_ID");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, FK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Enviro_Equipment table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_EquipmentSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Enviro_Equipment table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_EquipmentUpdate");

            db.AddInParameter(dbCommand, "PK_Enviro_Equipment_ID", DbType.Int32, this._PK_Enviro_Equipment_ID);
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, this._FK_LU_Location_ID);
            db.AddInParameter(dbCommand, "Identification", DbType.String, this._Identification);
            db.AddInParameter(dbCommand, "type", DbType.String, this._type);
            db.AddInParameter(dbCommand, "Contents", DbType.String, this._Contents);
            db.AddInParameter(dbCommand, "Contents_Other", DbType.String, this._Contents_Other);
            db.AddInParameter(dbCommand, "Capacity", DbType.Decimal, this._Capacity);
            db.AddInParameter(dbCommand, "status", DbType.String, this._status);
            db.AddInParameter(dbCommand, "Material", DbType.String, this._Material);
            db.AddInParameter(dbCommand, "Material_Other", DbType.String, this._Material_Other);
            db.AddInParameter(dbCommand, "Construction", DbType.String, this._Construction);
            db.AddInParameter(dbCommand, "Construction_Other", DbType.String, this._Construction_Other);
            db.AddInParameter(dbCommand, "Release_Equipment_Present", DbType.Boolean, this._Release_Equipment_Present);
            db.AddInParameter(dbCommand, "Release_Equipment_Description", DbType.String, this._Release_Equipment_Description);
            db.AddInParameter(dbCommand, "Overfill_Protection", DbType.Boolean, this._Overfill_Protection);
            db.AddInParameter(dbCommand, "Leak_Detection", DbType.Boolean, this._Leak_Detection);
            db.AddInParameter(dbCommand, "Leak_Detection_Type", DbType.String, this._Leak_Detection_Type);
            db.AddInParameter(dbCommand, "Insurer", DbType.String, this._Insurer);
            db.AddInParameter(dbCommand, "Single_Event_Coverage", DbType.Decimal, this._Single_Event_Coverage);
            db.AddInParameter(dbCommand, "Multiple_Event_Total_Coverage", DbType.Decimal, this._Multiple_Event_Total_Coverage);
            db.AddInParameter(dbCommand, "Coverage_Start_Date", DbType.DateTime, this._Coverage_Start_Date);
            db.AddInParameter(dbCommand, "Coverage_End_Date", DbType.DateTime, this._Coverage_End_Date);
            db.AddInParameter(dbCommand, "Flows_to_POTW", DbType.Boolean, this._Flows_to_POTW);
            db.AddInParameter(dbCommand, "Date_of_Last_Service", DbType.DateTime, this._Date_of_Last_Service);
            db.AddInParameter(dbCommand, "TCLP_on_File", DbType.Boolean, this._TCLP_on_File);
            db.AddInParameter(dbCommand, "Date_of_Last_TCLP", DbType.DateTime, this._Date_of_Last_TCLP);
            db.AddInParameter(dbCommand, "Installation_Date", DbType.DateTime, this._Installation_Date);
            db.AddInParameter(dbCommand, "Removal_Date", DbType.DateTime, this._Removal_Date);
            db.AddInParameter(dbCommand, "Closure_Date", DbType.DateTime, this._Closure_Date);
            db.AddInParameter(dbCommand, "Last_Inspection_Date", DbType.DateTime, this._Last_Inspection_Date);
            db.AddInParameter(dbCommand, "Next_Inspection_Date", DbType.DateTime, this._Next_Inspection_Date);
            db.AddInParameter(dbCommand, "Insurance_Company", DbType.String, this._Insurance_Company);
            db.AddInParameter(dbCommand, "Inspection_Contact", DbType.String, this._Inspection_Contact);
            db.AddInParameter(dbCommand, "Inspection_Phone", DbType.String, this._Inspection_Phone);
            db.AddInParameter(dbCommand, "Registration_Required", DbType.Boolean, this._Registration_Required);
            db.AddInParameter(dbCommand, "Registration_Number", DbType.String, this._Registration_Number);
            db.AddInParameter(dbCommand, "Certificate_Number", DbType.String, this._Certificate_Number);
            db.AddInParameter(dbCommand, "Permit_Begin_Date", DbType.DateTime, this._Permit_Begin_Date);
            db.AddInParameter(dbCommand, "Permit_End_Date", DbType.DateTime, this._Permit_End_Date);
            db.AddInParameter(dbCommand, "Other_Req", DbType.Boolean, this._Other_Req);
            db.AddInParameter(dbCommand, "Other_Req_Descr", DbType.String, this._Other_Req_Descr);
            db.AddInParameter(dbCommand, "Next_Report_Date", DbType.DateTime, this._Next_Report_Date);
            db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Enviro_Equipment table.
        /// </summary>
        public void UpdatePlanIdentification()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_EquipmentUpdatePlanIdentification");

            db.AddInParameter(dbCommand, "PK_Enviro_Equipment_ID", DbType.Int32, this._PK_Enviro_Equipment_ID);
            db.AddInParameter(dbCommand, "Plan_ID", DbType.String, this._Plan_ID);
            db.AddInParameter(dbCommand, "Plan_Effective_Date", DbType.DateTime, this._Plan_Effective_Date);
            db.AddInParameter(dbCommand, "Plan_Expiration_Date", DbType.DateTime, this._Plan_Expiration_Date);
            db.AddInParameter(dbCommand, "Plan_Revision_Date", DbType.DateTime, this._Plan_Revision_Date);
            db.AddInParameter(dbCommand, "Plan_Vendor", DbType.String, this._Plan_Vendor);
            db.AddInParameter(dbCommand, "Plan_Vendor_Contact", DbType.String, this._Plan_Vendor_Contact);
            db.AddInParameter(dbCommand, "Plan_Phone", DbType.String, this._Plan_Phone);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, System.DateTime.Now);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, clsSession.UserID);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Enviro_Equipment table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(int pK_Enviro_Equipment_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_EquipmentDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Enviro_Equipment_ID", DbType.Int32, pK_Enviro_Equipment_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        #endregion
    }
}
