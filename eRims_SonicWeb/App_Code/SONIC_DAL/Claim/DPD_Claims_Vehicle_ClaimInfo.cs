using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for DPD_Claims_Vehicle_ClaimInfo
    /// </summary>
    public class DPD_Claims_Vehicle_ClaimInfo
    {
        #region Fields
        private Int64 _PK_DPD_Claims_Vehicle_ID;
        private Int64 _FK_DPD_Claims_ID;
        private string _Incident_Type;
        private string _Make;
        private string _Model;
        private decimal _Year;
        private string _VIN;
        private decimal _Damage_Estimate;
        private bool _Driven_By_Associate;
        private bool _Associate_Cited;
        private string _Description_Of_Citation;
        private bool _Vehicle_Driven_By_Customer;
        private decimal _Invoice_Value;
        private bool _Vehicle_Recovered;
        private bool _Dealership_Wish_To_Take_Possession;
        private string _Loss_Description;
        private bool _Police_Notified;
        private string _Police_Report_Number;
        #endregion

        #region Properties
        /// <summary> 
        /// Gets or sets the PK_DPD_Claims_Vehicle_ID value.
        /// </summary> 
        public Int64 PK_DPD_Claims_Vehicle_ID
        {
            get { return _PK_DPD_Claims_Vehicle_ID; }
            set { _PK_DPD_Claims_Vehicle_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_DPD_Claims_ID value.
        /// </summary> 
        public Int64 FK_DPD_Claims_ID
        {
            get { return _FK_DPD_Claims_ID; }
            set { _FK_DPD_Claims_ID = value; }
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
        /// Gets or sets the VIN# value.
        /// </summary> 
        public string VIN
        {
            get { return _VIN; }
            set { _VIN = value; }
        }


        /// <summary> 
        /// Gets or sets the Damage_Estimate value.
        /// </summary> 
        public decimal Damage_Estimate
        {
            get { return _Damage_Estimate; }
            set { _Damage_Estimate = value; }
        }


        /// <summary> 
        /// Gets or sets the Driven_By_Associate value.
        /// </summary> 
        public bool Driven_By_Associate
        {
            get { return _Driven_By_Associate; }
            set { _Driven_By_Associate = value; }
        }


        /// <summary> 
        /// Gets or sets the Associate_Cited value.
        /// </summary> 
        public bool Associate_Cited
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
        public bool Vehicle_Driven_By_Customer
        {
            get { return _Vehicle_Driven_By_Customer; }
            set { _Vehicle_Driven_By_Customer = value; }
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
        public bool Vehicle_Recovered
        {
            get { return _Vehicle_Recovered; }
            set { _Vehicle_Recovered = value; }
        }


        /// <summary> 
        /// Gets or sets the Dealership_Wish_To_Take_Possession value.
        /// </summary> 
        public bool Dealership_Wish_To_Take_Possession
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
        public bool Police_Notified
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

        #endregion

        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the DPD_Claims_Vehicle class. with the default value.
        /// </summary>
        public DPD_Claims_Vehicle_ClaimInfo()
        {

            this._PK_DPD_Claims_Vehicle_ID = -1;
            this._FK_DPD_Claims_ID = -1;
            this._Incident_Type = "";
            this._Make = "";
            this._Model = "";
            this._Year = -1;
            this._VIN = "";
            this._Damage_Estimate = -1;
            this._Driven_By_Associate = false;
            this._Associate_Cited = false;
            this._Description_Of_Citation = "";
            this._Vehicle_Driven_By_Customer = false;
            this._Invoice_Value = -1;
            this._Vehicle_Recovered = false;
            this._Dealership_Wish_To_Take_Possession = false;
            this._Loss_Description = "";
            this._Police_Notified = false;
            this._Police_Report_Number = "";
        }


        /// <summary> 
        /// Initializes a new instance of the DPD_Claims_Vehicle class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public DPD_Claims_Vehicle_ClaimInfo(Int32 PK)
        {

            DataTable dtDPD_Claims_Vehicle = SelectByPK(PK).Tables[0];
            if (dtDPD_Claims_Vehicle.Rows.Count > 0)
            {
                DataRow drDPD_Claims_Vehicle = dtDPD_Claims_Vehicle.Rows[0];
                this._PK_DPD_Claims_Vehicle_ID = drDPD_Claims_Vehicle["PK_DPD_Claims_Vehicle_ID"] != DBNull.Value ? Convert.ToInt64(drDPD_Claims_Vehicle["PK_DPD_Claims_Vehicle_ID"]) : 0;
                this._FK_DPD_Claims_ID = drDPD_Claims_Vehicle["FK_DPD_Claims_ID"] != DBNull.Value ? Convert.ToInt64(drDPD_Claims_Vehicle["FK_DPD_Claims_ID"]) : 0;
                this._Incident_Type = Convert.ToString(drDPD_Claims_Vehicle["Incident_Type"]);
                this._Make = Convert.ToString(drDPD_Claims_Vehicle["Make"]);
                this._Model = Convert.ToString(drDPD_Claims_Vehicle["Model"]);
                this._Year = drDPD_Claims_Vehicle["Year"] != DBNull.Value ? Convert.ToDecimal(drDPD_Claims_Vehicle["Year"]) : 0;
                this._VIN = Convert.ToString(drDPD_Claims_Vehicle["VIN#"]);
                this._Damage_Estimate = drDPD_Claims_Vehicle["Damage_Estimate"] != DBNull.Value ? Convert.ToDecimal(drDPD_Claims_Vehicle["Damage_Estimate"]) : 0;
                this._Driven_By_Associate = drDPD_Claims_Vehicle["Driven_By_Associate"] != DBNull.Value ? Convert.ToBoolean(drDPD_Claims_Vehicle["Driven_By_Associate"]) : false;
                this._Associate_Cited = drDPD_Claims_Vehicle["Associate_Cited"] != DBNull.Value ? Convert.ToBoolean(drDPD_Claims_Vehicle["Associate_Cited"]) : false;
                this._Description_Of_Citation = Convert.ToString(drDPD_Claims_Vehicle["Description_Of_Citation"]);
                this._Vehicle_Driven_By_Customer = drDPD_Claims_Vehicle["Vehicle_Driven_By_Customer"] != DBNull.Value ? Convert.ToBoolean(drDPD_Claims_Vehicle["Vehicle_Driven_By_Customer"]) : false;
                this._Invoice_Value = drDPD_Claims_Vehicle["Invoice_Value"] != DBNull.Value ? Convert.ToDecimal(drDPD_Claims_Vehicle["Invoice_Value"]) : 0;
                this._Vehicle_Recovered = drDPD_Claims_Vehicle["Vehicle_Recovered"] != DBNull.Value ? Convert.ToBoolean(drDPD_Claims_Vehicle["Vehicle_Recovered"]) : false;
                this._Dealership_Wish_To_Take_Possession = drDPD_Claims_Vehicle["Dealership_Wish_To_Take_Possession"] != DBNull.Value ? Convert.ToBoolean(drDPD_Claims_Vehicle["Dealership_Wish_To_Take_Possession"]) : false;
                this._Loss_Description = Convert.ToString(drDPD_Claims_Vehicle["Loss_Description"]);
                this._Police_Notified = drDPD_Claims_Vehicle["Police_Notified"] != DBNull.Value ? Convert.ToBoolean(drDPD_Claims_Vehicle["Police_Notified"]) : false;
                this._Police_Report_Number = Convert.ToString(drDPD_Claims_Vehicle["Police_Report_Number"]);
            }
            else
            {
                this._PK_DPD_Claims_Vehicle_ID = -1;
                this._FK_DPD_Claims_ID = -1;
                this._Incident_Type = "";
                this._Make = "";
                this._Model = "";
                this._Year = -1;
                this._VIN = "";
                this._Damage_Estimate = -1;
                this._Driven_By_Associate = false;
                this._Associate_Cited = false;
                this._Description_Of_Citation = "";
                this._Vehicle_Driven_By_Customer = false;
                this._Invoice_Value = -1;
                this._Vehicle_Recovered = false;
                this._Dealership_Wish_To_Take_Possession = false;
                this._Loss_Description = "";
                this._Police_Notified = false;
                this._Police_Report_Number = "";
            }
        }


        #endregion

        #region Method

        /// <summary>
        /// Selects a single record from the Workers_Comp_Claims table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(Int64 pK_DPD_Claims_Vehicle_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DPD_ClaimsSelectByPK");

            db.AddInParameter(dbCommand, "PK_DPD_Claims_Vehicle_ID", DbType.Int64, pK_DPD_Claims_Vehicle_ID);

            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// Selects a single record from the Workers_Comp_Claims table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByDPDClaim(Int64 fK_DPD_Claims_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DPD_VehicleSelectByDPDClaim");

            db.AddInParameter(dbCommand, "FK_DPD_Claims_ID", DbType.Int64, fK_DPD_Claims_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        #endregion
    }
}