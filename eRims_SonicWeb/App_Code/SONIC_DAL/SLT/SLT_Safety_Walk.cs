using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for SLT_Safety_Walk table.
    /// </summary>
    public sealed class SLT_Safety_Walk
    {

        #region Private variables used to hold the property values

        private decimal? _PK_SLT_Safety_Walk;
        private decimal? _FK_SLT_Meeting;
        private bool? _Safety_Walk_Comp;
        private DateTime? _Safety_Walk_Comp_Date;
        private string _Sales_Reviewed;
        private string _Sales_Deficiencies;
        private string _Sales_Comments;
        private string _Parts_Reviewed;
        private string _Parts_Deficiencies;
        private string _Parts_Comments;
        private string _Service_Facility_Reviewed;
        private string _Service_Deficiencies;
        private string _Service_Comments;
        private string _Body_Shop_Reviewed;
        private string _Body_Shop_Deficiencies;
        private string _Body_Shop_Comments;
        private string _Bus_Off_Reviewed;
        private string _Bus_Off_Deficiencies;
        private string _Bus_Off_Comments;
        private string _Detail_Area_Reviewed;
        private string _Detail_Deficiencies;
        private string _Detail_Comments;
        private string _Car_Wash_Reviewed;
        private string _Car_Wash_Deficiencies;
        private string _Car_Wash_Comments;
        private string _Parking_Lot_Reviewed;
        private string _Parking_Deficiencies;
        private string _Parking_Comments;
        private string _Updated_By;
        private DateTime? _Update_Date;
        private string _UniqueVal;
        private decimal? _FK_SLT_Meeting_Schedule;
        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_SLT_Safety_Walk value.
        /// </summary>
        public decimal? PK_SLT_Safety_Walk
        {
            get { return _PK_SLT_Safety_Walk; }
            set { _PK_SLT_Safety_Walk = value; }
        }

        /// <summary>
        /// Gets or sets the FK_SLT_Meeting value.
        /// </summary>
        public decimal? FK_SLT_Meeting
        {
            get { return _FK_SLT_Meeting; }
            set { _FK_SLT_Meeting = value; }
        }

        /// <summary>
        /// Gets or sets the Safety_Walk_Comp value.
        /// </summary>
        public bool? Safety_Walk_Comp
        {
            get { return _Safety_Walk_Comp; }
            set { _Safety_Walk_Comp = value; }
        }

        /// <summary>
        /// Gets or sets the Safety_Walk_Comp_Date value.
        /// </summary>
        public DateTime? Safety_Walk_Comp_Date
        {
            get { return _Safety_Walk_Comp_Date; }
            set { _Safety_Walk_Comp_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Sales_Reviewed value.
        /// </summary>
        public string Sales_Reviewed
        {
            get { return _Sales_Reviewed; }
            set { _Sales_Reviewed = value; }
        }

        /// <summary>
        /// Gets or sets the Sales_Deficiencies value.
        /// </summary>
        public string Sales_Deficiencies
        {
            get { return _Sales_Deficiencies; }
            set { _Sales_Deficiencies = value; }
        }

        /// <summary>
        /// Gets or sets the Sales_Comments value.
        /// </summary>
        public string Sales_Comments
        {
            get { return _Sales_Comments; }
            set { _Sales_Comments = value; }
        }

        /// <summary>
        /// Gets or sets the Parts_Reviewed value.
        /// </summary>
        public string Parts_Reviewed
        {
            get { return _Parts_Reviewed; }
            set { _Parts_Reviewed = value; }
        }

        /// <summary>
        /// Gets or sets the Parts_Deficiencies value.
        /// </summary>
        public string Parts_Deficiencies
        {
            get { return _Parts_Deficiencies; }
            set { _Parts_Deficiencies = value; }
        }

        /// <summary>
        /// Gets or sets the Parts_Comments value.
        /// </summary>
        public string Parts_Comments
        {
            get { return _Parts_Comments; }
            set { _Parts_Comments = value; }
        }

        /// <summary>
        /// Gets or sets the Service_Facility_Reviewed value.
        /// </summary>
        public string Service_Facility_Reviewed
        {
            get { return _Service_Facility_Reviewed; }
            set { _Service_Facility_Reviewed = value; }
        }

        /// <summary>
        /// Gets or sets the Service_Deficiencies value.
        /// </summary>
        public string Service_Deficiencies
        {
            get { return _Service_Deficiencies; }
            set { _Service_Deficiencies = value; }
        }

        /// <summary>
        /// Gets or sets the Service_Comments value.
        /// </summary>
        public string Service_Comments
        {
            get { return _Service_Comments; }
            set { _Service_Comments = value; }
        }

        /// <summary>
        /// Gets or sets the Body_Shop_Reviewed value.
        /// </summary>
        public string Body_Shop_Reviewed
        {
            get { return _Body_Shop_Reviewed; }
            set { _Body_Shop_Reviewed = value; }
        }

        /// <summary>
        /// Gets or sets the Body_Shop_Deficiencies value.
        /// </summary>
        public string Body_Shop_Deficiencies
        {
            get { return _Body_Shop_Deficiencies; }
            set { _Body_Shop_Deficiencies = value; }
        }

        /// <summary>
        /// Gets or sets the Body_Shop_Comments value.
        /// </summary>
        public string Body_Shop_Comments
        {
            get { return _Body_Shop_Comments; }
            set { _Body_Shop_Comments = value; }
        }

        /// <summary>
        /// Gets or sets the Bus_Off_Reviewed value.
        /// </summary>
        public string Bus_Off_Reviewed
        {
            get { return _Bus_Off_Reviewed; }
            set { _Bus_Off_Reviewed = value; }
        }

        /// <summary>
        /// Gets or sets the Bus_Off_Deficiencies value.
        /// </summary>
        public string Bus_Off_Deficiencies
        {
            get { return _Bus_Off_Deficiencies; }
            set { _Bus_Off_Deficiencies = value; }
        }

        /// <summary>
        /// Gets or sets the Bus_Off_Comments value.
        /// </summary>
        public string Bus_Off_Comments
        {
            get { return _Bus_Off_Comments; }
            set { _Bus_Off_Comments = value; }
        }

        /// <summary>
        /// Gets or sets the Detail_Area_Reviewed value.
        /// </summary>
        public string Detail_Area_Reviewed
        {
            get { return _Detail_Area_Reviewed; }
            set { _Detail_Area_Reviewed = value; }
        }

        /// <summary>
        /// Gets or sets the Detail_Deficiencies value.
        /// </summary>
        public string Detail_Deficiencies
        {
            get { return _Detail_Deficiencies; }
            set { _Detail_Deficiencies = value; }
        }

        /// <summary>
        /// Gets or sets the Detail_Comments value.
        /// </summary>
        public string Detail_Comments
        {
            get { return _Detail_Comments; }
            set { _Detail_Comments = value; }
        }

        /// <summary>
        /// Gets or sets the Car_Wash_Reviewed value.
        /// </summary>
        public string Car_Wash_Reviewed
        {
            get { return _Car_Wash_Reviewed; }
            set { _Car_Wash_Reviewed = value; }
        }

        /// <summary>
        /// Gets or sets the Car_Wash_Deficiencies value.
        /// </summary>
        public string Car_Wash_Deficiencies
        {
            get { return _Car_Wash_Deficiencies; }
            set { _Car_Wash_Deficiencies = value; }
        }

        /// <summary>
        /// Gets or sets the Car_Wash_Comments value.
        /// </summary>
        public string Car_Wash_Comments
        {
            get { return _Car_Wash_Comments; }
            set { _Car_Wash_Comments = value; }
        }

        /// <summary>
        /// Gets or sets the Parking_Lot_Reviewed value.
        /// </summary>
        public string Parking_Lot_Reviewed
        {
            get { return _Parking_Lot_Reviewed; }
            set { _Parking_Lot_Reviewed = value; }
        }

        /// <summary>
        /// Gets or sets the Parking_Deficiencies value.
        /// </summary>
        public string Parking_Deficiencies
        {
            get { return _Parking_Deficiencies; }
            set { _Parking_Deficiencies = value; }
        }

        /// <summary>
        /// Gets or sets the Parking_Comments value.
        /// </summary>
        public string Parking_Comments
        {
            get { return _Parking_Comments; }
            set { _Parking_Comments = value; }
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
        /// Gets or sets the UniqueVal value.
        /// </summary>
        public string UniqueVal
        {
            get { return _UniqueVal; }
            set { _UniqueVal = value; }
        }
        /// <summary>
        /// Gets or Sets FK_SLT_Meeting_Schedule value
        /// </summary>
        public decimal? FK_SLT_Meeting_Schedule
        {
            get { return _FK_SLT_Meeting_Schedule; }
            set { _FK_SLT_Meeting_Schedule = value; }
        }
        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsSLT_Safety_Walk class with default value.
        /// </summary>
        public SLT_Safety_Walk()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsSLT_Safety_Walk class based on Primary Key.
        /// </summary>
        public SLT_Safety_Walk(decimal pK_SLT_Safety_Walk)
        {
            DataTable dtSLT_Safety_Walk = SelectByPK(pK_SLT_Safety_Walk).Tables[0];

            if (dtSLT_Safety_Walk.Rows.Count == 1)
            {
                SetValue(dtSLT_Safety_Walk.Rows[0]);

            }

        }
        public SLT_Safety_Walk(decimal FK_SLT_Meeting_Schedule, bool Status)
        {
            DataTable dtSLT_Safety_Walk = SelectBYFK(FK_SLT_Meeting_Schedule).Tables[0];

            if (dtSLT_Safety_Walk.Rows.Count == 1)
            {
                SetValue(dtSLT_Safety_Walk.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsSLT_Safety_Walk class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drSLT_Safety_Walk)
        {
            if (drSLT_Safety_Walk["PK_SLT_Safety_Walk"] == DBNull.Value)
                this._PK_SLT_Safety_Walk = null;
            else
                this._PK_SLT_Safety_Walk = (decimal?)drSLT_Safety_Walk["PK_SLT_Safety_Walk"];

            if (drSLT_Safety_Walk["FK_SLT_Meeting"] == DBNull.Value)
                this._FK_SLT_Meeting = null;
            else
                this._FK_SLT_Meeting = (decimal?)drSLT_Safety_Walk["FK_SLT_Meeting"];

            if (drSLT_Safety_Walk["Safety_Walk_Comp"] == DBNull.Value)
                this._Safety_Walk_Comp = null;
            else
                this._Safety_Walk_Comp = (bool?)drSLT_Safety_Walk["Safety_Walk_Comp"];

            if (drSLT_Safety_Walk["Safety_Walk_Comp_Date"] == DBNull.Value)
                this._Safety_Walk_Comp_Date = null;
            else
                this._Safety_Walk_Comp_Date = (DateTime?)drSLT_Safety_Walk["Safety_Walk_Comp_Date"];

            if (drSLT_Safety_Walk["Sales_Reviewed"] == DBNull.Value)
                this._Sales_Reviewed = null;
            else
                this._Sales_Reviewed = (string)drSLT_Safety_Walk["Sales_Reviewed"];

            if (drSLT_Safety_Walk["Sales_Deficiencies"] == DBNull.Value)
                this._Sales_Deficiencies = null;
            else
                this._Sales_Deficiencies = (string)drSLT_Safety_Walk["Sales_Deficiencies"];

            if (drSLT_Safety_Walk["Sales_Comments"] == DBNull.Value)
                this._Sales_Comments = null;
            else
                this._Sales_Comments = (string)drSLT_Safety_Walk["Sales_Comments"];

            if (drSLT_Safety_Walk["Parts_Reviewed"] == DBNull.Value)
                this._Parts_Reviewed = null;
            else
                this._Parts_Reviewed = (string)drSLT_Safety_Walk["Parts_Reviewed"];

            if (drSLT_Safety_Walk["Parts_Deficiencies"] == DBNull.Value)
                this._Parts_Deficiencies = null;
            else
                this._Parts_Deficiencies = (string)drSLT_Safety_Walk["Parts_Deficiencies"];

            if (drSLT_Safety_Walk["Parts_Comments"] == DBNull.Value)
                this._Parts_Comments = null;
            else
                this._Parts_Comments = (string)drSLT_Safety_Walk["Parts_Comments"];

            if (drSLT_Safety_Walk["Service_Facility_Reviewed"] == DBNull.Value)
                this._Service_Facility_Reviewed = null;
            else
                this._Service_Facility_Reviewed = (string)drSLT_Safety_Walk["Service_Facility_Reviewed"];

            if (drSLT_Safety_Walk["Service_Deficiencies"] == DBNull.Value)
                this._Service_Deficiencies = null;
            else
                this._Service_Deficiencies = (string)drSLT_Safety_Walk["Service_Deficiencies"];

            if (drSLT_Safety_Walk["Service_Comments"] == DBNull.Value)
                this._Service_Comments = null;
            else
                this._Service_Comments = (string)drSLT_Safety_Walk["Service_Comments"];

            if (drSLT_Safety_Walk["Body_Shop_Reviewed"] == DBNull.Value)
                this._Body_Shop_Reviewed = null;
            else
                this._Body_Shop_Reviewed = (string)drSLT_Safety_Walk["Body_Shop_Reviewed"];

            if (drSLT_Safety_Walk["Body_Shop_Deficiencies"] == DBNull.Value)
                this._Body_Shop_Deficiencies = null;
            else
                this._Body_Shop_Deficiencies = (string)drSLT_Safety_Walk["Body_Shop_Deficiencies"];

            if (drSLT_Safety_Walk["Body_Shop_Comments"] == DBNull.Value)
                this._Body_Shop_Comments = null;
            else
                this._Body_Shop_Comments = (string)drSLT_Safety_Walk["Body_Shop_Comments"];

            if (drSLT_Safety_Walk["Bus_Off_Reviewed"] == DBNull.Value)
                this._Bus_Off_Reviewed = null;
            else
                this._Bus_Off_Reviewed = (string)drSLT_Safety_Walk["Bus_Off_Reviewed"];

            if (drSLT_Safety_Walk["Bus_Off_Deficiencies"] == DBNull.Value)
                this._Bus_Off_Deficiencies = null;
            else
                this._Bus_Off_Deficiencies = (string)drSLT_Safety_Walk["Bus_Off_Deficiencies"];

            if (drSLT_Safety_Walk["Bus_Off_Comments"] == DBNull.Value)
                this._Bus_Off_Comments = null;
            else
                this._Bus_Off_Comments = (string)drSLT_Safety_Walk["Bus_Off_Comments"];

            if (drSLT_Safety_Walk["Detail_Area_Reviewed"] == DBNull.Value)
                this._Detail_Area_Reviewed = null;
            else
                this._Detail_Area_Reviewed = (string)drSLT_Safety_Walk["Detail_Area_Reviewed"];

            if (drSLT_Safety_Walk["Detail_Deficiencies"] == DBNull.Value)
                this._Detail_Deficiencies = null;
            else
                this._Detail_Deficiencies = (string)drSLT_Safety_Walk["Detail_Deficiencies"];

            if (drSLT_Safety_Walk["Detail_Comments"] == DBNull.Value)
                this._Detail_Comments = null;
            else
                this._Detail_Comments = (string)drSLT_Safety_Walk["Detail_Comments"];

            if (drSLT_Safety_Walk["Car_Wash_Reviewed"] == DBNull.Value)
                this._Car_Wash_Reviewed = null;
            else
                this._Car_Wash_Reviewed = (string)drSLT_Safety_Walk["Car_Wash_Reviewed"];

            if (drSLT_Safety_Walk["Car_Wash_Deficiencies"] == DBNull.Value)
                this._Car_Wash_Deficiencies = null;
            else
                this._Car_Wash_Deficiencies = (string)drSLT_Safety_Walk["Car_Wash_Deficiencies"];

            if (drSLT_Safety_Walk["Car_Wash_Comments"] == DBNull.Value)
                this._Car_Wash_Comments = null;
            else
                this._Car_Wash_Comments = (string)drSLT_Safety_Walk["Car_Wash_Comments"];

            if (drSLT_Safety_Walk["Parking_Lot_Reviewed"] == DBNull.Value)
                this._Parking_Lot_Reviewed = null;
            else
                this._Parking_Lot_Reviewed = (string)drSLT_Safety_Walk["Parking_Lot_Reviewed"];

            if (drSLT_Safety_Walk["Parking_Deficiencies"] == DBNull.Value)
                this._Parking_Deficiencies = null;
            else
                this._Parking_Deficiencies = (string)drSLT_Safety_Walk["Parking_Deficiencies"];

            if (drSLT_Safety_Walk["Parking_Comments"] == DBNull.Value)
                this._Parking_Comments = null;
            else
                this._Parking_Comments = (string)drSLT_Safety_Walk["Parking_Comments"];

            if (drSLT_Safety_Walk["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drSLT_Safety_Walk["Updated_By"];

            if (drSLT_Safety_Walk["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drSLT_Safety_Walk["Update_Date"];

            if (drSLT_Safety_Walk["UniqueVal"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drSLT_Safety_Walk["UniqueVal"];

            if (drSLT_Safety_Walk["FK_SLT_Meeting_Schedule"] == DBNull.Value)
                this._FK_SLT_Meeting_Schedule = null;
            else
                this._FK_SLT_Meeting_Schedule = (decimal?)drSLT_Safety_Walk["FK_SLT_Meeting_Schedule"];
        }

        #endregion

        /// <summary>
        /// Inserts a record into the SLT_Safety_Walk table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("SLT_Safety_WalkInsert");

                db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);

                db.AddInParameter(dbCommand, "Safety_Walk_Comp", DbType.Boolean, this._Safety_Walk_Comp);

                db.AddInParameter(dbCommand, "Safety_Walk_Comp_Date", DbType.DateTime, this._Safety_Walk_Comp_Date);

                if (string.IsNullOrEmpty(this._Sales_Reviewed))
                    db.AddInParameter(dbCommand, "Sales_Reviewed", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Sales_Reviewed", DbType.String, this._Sales_Reviewed);

                if (string.IsNullOrEmpty(this._Sales_Deficiencies))
                    db.AddInParameter(dbCommand, "Sales_Deficiencies", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Sales_Deficiencies", DbType.String, this._Sales_Deficiencies);

                if (string.IsNullOrEmpty(this._Sales_Comments))
                    db.AddInParameter(dbCommand, "Sales_Comments", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Sales_Comments", DbType.String, this._Sales_Comments);

                if (string.IsNullOrEmpty(this._Parts_Reviewed))
                    db.AddInParameter(dbCommand, "Parts_Reviewed", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Parts_Reviewed", DbType.String, this._Parts_Reviewed);

                if (string.IsNullOrEmpty(this._Parts_Deficiencies))
                    db.AddInParameter(dbCommand, "Parts_Deficiencies", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Parts_Deficiencies", DbType.String, this._Parts_Deficiencies);

                if (string.IsNullOrEmpty(this._Parts_Comments))
                    db.AddInParameter(dbCommand, "Parts_Comments", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Parts_Comments", DbType.String, this._Parts_Comments);

                if (string.IsNullOrEmpty(this._Service_Facility_Reviewed))
                    db.AddInParameter(dbCommand, "Service_Facility_Reviewed", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Service_Facility_Reviewed", DbType.String, this._Service_Facility_Reviewed);

                if (string.IsNullOrEmpty(this._Service_Deficiencies))
                    db.AddInParameter(dbCommand, "Service_Deficiencies", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Service_Deficiencies", DbType.String, this._Service_Deficiencies);

                if (string.IsNullOrEmpty(this._Service_Comments))
                    db.AddInParameter(dbCommand, "Service_Comments", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Service_Comments", DbType.String, this._Service_Comments);

                if (string.IsNullOrEmpty(this._Body_Shop_Reviewed))
                    db.AddInParameter(dbCommand, "Body_Shop_Reviewed", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Body_Shop_Reviewed", DbType.String, this._Body_Shop_Reviewed);

                if (string.IsNullOrEmpty(this._Body_Shop_Deficiencies))
                    db.AddInParameter(dbCommand, "Body_Shop_Deficiencies", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Body_Shop_Deficiencies", DbType.String, this._Body_Shop_Deficiencies);

                if (string.IsNullOrEmpty(this._Body_Shop_Comments))
                    db.AddInParameter(dbCommand, "Body_Shop_Comments", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Body_Shop_Comments", DbType.String, this._Body_Shop_Comments);

                if (string.IsNullOrEmpty(this._Bus_Off_Reviewed))
                    db.AddInParameter(dbCommand, "Bus_Off_Reviewed", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Bus_Off_Reviewed", DbType.String, this._Bus_Off_Reviewed);

                if (string.IsNullOrEmpty(this._Bus_Off_Deficiencies))
                    db.AddInParameter(dbCommand, "Bus_Off_Deficiencies", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Bus_Off_Deficiencies", DbType.String, this._Bus_Off_Deficiencies);

                if (string.IsNullOrEmpty(this._Bus_Off_Comments))
                    db.AddInParameter(dbCommand, "Bus_Off_Comments", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Bus_Off_Comments", DbType.String, this._Bus_Off_Comments);

                if (string.IsNullOrEmpty(this._Detail_Area_Reviewed))
                    db.AddInParameter(dbCommand, "Detail_Area_Reviewed", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Detail_Area_Reviewed", DbType.String, this._Detail_Area_Reviewed);

                if (string.IsNullOrEmpty(this._Detail_Deficiencies))
                    db.AddInParameter(dbCommand, "Detail_Deficiencies", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Detail_Deficiencies", DbType.String, this._Detail_Deficiencies);

                if (string.IsNullOrEmpty(this._Detail_Comments))
                    db.AddInParameter(dbCommand, "Detail_Comments", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Detail_Comments", DbType.String, this._Detail_Comments);

                if (string.IsNullOrEmpty(this._Car_Wash_Reviewed))
                    db.AddInParameter(dbCommand, "Car_Wash_Reviewed", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Car_Wash_Reviewed", DbType.String, this._Car_Wash_Reviewed);

                if (string.IsNullOrEmpty(this._Car_Wash_Deficiencies))
                    db.AddInParameter(dbCommand, "Car_Wash_Deficiencies", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Car_Wash_Deficiencies", DbType.String, this._Car_Wash_Deficiencies);

                if (string.IsNullOrEmpty(this._Car_Wash_Comments))
                    db.AddInParameter(dbCommand, "Car_Wash_Comments", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Car_Wash_Comments", DbType.String, this._Car_Wash_Comments);

                if (string.IsNullOrEmpty(this._Parking_Lot_Reviewed))
                    db.AddInParameter(dbCommand, "Parking_Lot_Reviewed", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Parking_Lot_Reviewed", DbType.String, this._Parking_Lot_Reviewed);

                if (string.IsNullOrEmpty(this._Parking_Deficiencies))
                    db.AddInParameter(dbCommand, "Parking_Deficiencies", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Parking_Deficiencies", DbType.String, this._Parking_Deficiencies);

                if (string.IsNullOrEmpty(this._Parking_Comments))
                    db.AddInParameter(dbCommand, "Parking_Comments", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Parking_Comments", DbType.String, this._Parking_Comments);

                if (string.IsNullOrEmpty(this._Updated_By))
                    db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

                db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

                if (string.IsNullOrEmpty(this._UniqueVal))
                    db.AddInParameter(dbCommand, "UniqueVal", DbType.String, DBNull.Value);
                else
                    db.AddInParameter(dbCommand, "UniqueVal", DbType.String, this._UniqueVal);

                db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, this._FK_SLT_Meeting_Schedule);
                dbCommand.CommandTimeout = 10000;
                // Execute the query and return the new identity value
                int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
                
                return returnValue;            
            }
            catch(Exception ex)
            {
                throw ex;
            }          
        }

        /// <summary>
        /// Selects a single record from the SLT_Safety_Walk table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_SLT_Safety_Walk)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Safety_WalkSelectByPK");

            db.AddInParameter(dbCommand, "PK_SLT_Safety_Walk", DbType.Decimal, pK_SLT_Safety_Walk);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the SLT_Safety_Walk table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Safety_WalkSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the SLT_Safety_Walk table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Safety_WalkUpdate");


            db.AddInParameter(dbCommand, "PK_SLT_Safety_Walk", DbType.Decimal, this._PK_SLT_Safety_Walk);

            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);

            db.AddInParameter(dbCommand, "Safety_Walk_Comp", DbType.Boolean, this._Safety_Walk_Comp);

            db.AddInParameter(dbCommand, "Safety_Walk_Comp_Date", DbType.DateTime, this._Safety_Walk_Comp_Date);

            if (string.IsNullOrEmpty(this._Sales_Reviewed))
                db.AddInParameter(dbCommand, "Sales_Reviewed", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sales_Reviewed", DbType.String, this._Sales_Reviewed);

            if (string.IsNullOrEmpty(this._Sales_Deficiencies))
                db.AddInParameter(dbCommand, "Sales_Deficiencies", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sales_Deficiencies", DbType.String, this._Sales_Deficiencies);

            if (string.IsNullOrEmpty(this._Sales_Comments))
                db.AddInParameter(dbCommand, "Sales_Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sales_Comments", DbType.String, this._Sales_Comments);

            if (string.IsNullOrEmpty(this._Parts_Reviewed))
                db.AddInParameter(dbCommand, "Parts_Reviewed", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Parts_Reviewed", DbType.String, this._Parts_Reviewed);

            if (string.IsNullOrEmpty(this._Parts_Deficiencies))
                db.AddInParameter(dbCommand, "Parts_Deficiencies", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Parts_Deficiencies", DbType.String, this._Parts_Deficiencies);

            if (string.IsNullOrEmpty(this._Parts_Comments))
                db.AddInParameter(dbCommand, "Parts_Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Parts_Comments", DbType.String, this._Parts_Comments);

            if (string.IsNullOrEmpty(this._Service_Facility_Reviewed))
                db.AddInParameter(dbCommand, "Service_Facility_Reviewed", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Service_Facility_Reviewed", DbType.String, this._Service_Facility_Reviewed);

            if (string.IsNullOrEmpty(this._Service_Deficiencies))
                db.AddInParameter(dbCommand, "Service_Deficiencies", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Service_Deficiencies", DbType.String, this._Service_Deficiencies);

            if (string.IsNullOrEmpty(this._Service_Comments))
                db.AddInParameter(dbCommand, "Service_Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Service_Comments", DbType.String, this._Service_Comments);

            if (string.IsNullOrEmpty(this._Body_Shop_Reviewed))
                db.AddInParameter(dbCommand, "Body_Shop_Reviewed", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Body_Shop_Reviewed", DbType.String, this._Body_Shop_Reviewed);

            if (string.IsNullOrEmpty(this._Body_Shop_Deficiencies))
                db.AddInParameter(dbCommand, "Body_Shop_Deficiencies", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Body_Shop_Deficiencies", DbType.String, this._Body_Shop_Deficiencies);

            if (string.IsNullOrEmpty(this._Body_Shop_Comments))
                db.AddInParameter(dbCommand, "Body_Shop_Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Body_Shop_Comments", DbType.String, this._Body_Shop_Comments);

            if (string.IsNullOrEmpty(this._Bus_Off_Reviewed))
                db.AddInParameter(dbCommand, "Bus_Off_Reviewed", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Bus_Off_Reviewed", DbType.String, this._Bus_Off_Reviewed);

            if (string.IsNullOrEmpty(this._Bus_Off_Deficiencies))
                db.AddInParameter(dbCommand, "Bus_Off_Deficiencies", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Bus_Off_Deficiencies", DbType.String, this._Bus_Off_Deficiencies);

            if (string.IsNullOrEmpty(this._Bus_Off_Comments))
                db.AddInParameter(dbCommand, "Bus_Off_Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Bus_Off_Comments", DbType.String, this._Bus_Off_Comments);

            if (string.IsNullOrEmpty(this._Detail_Area_Reviewed))
                db.AddInParameter(dbCommand, "Detail_Area_Reviewed", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Detail_Area_Reviewed", DbType.String, this._Detail_Area_Reviewed);

            if (string.IsNullOrEmpty(this._Detail_Deficiencies))
                db.AddInParameter(dbCommand, "Detail_Deficiencies", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Detail_Deficiencies", DbType.String, this._Detail_Deficiencies);

            if (string.IsNullOrEmpty(this._Detail_Comments))
                db.AddInParameter(dbCommand, "Detail_Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Detail_Comments", DbType.String, this._Detail_Comments);

            if (string.IsNullOrEmpty(this._Car_Wash_Reviewed))
                db.AddInParameter(dbCommand, "Car_Wash_Reviewed", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Car_Wash_Reviewed", DbType.String, this._Car_Wash_Reviewed);

            if (string.IsNullOrEmpty(this._Car_Wash_Deficiencies))
                db.AddInParameter(dbCommand, "Car_Wash_Deficiencies", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Car_Wash_Deficiencies", DbType.String, this._Car_Wash_Deficiencies);

            if (string.IsNullOrEmpty(this._Car_Wash_Comments))
                db.AddInParameter(dbCommand, "Car_Wash_Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Car_Wash_Comments", DbType.String, this._Car_Wash_Comments);

            if (string.IsNullOrEmpty(this._Parking_Lot_Reviewed))
                db.AddInParameter(dbCommand, "Parking_Lot_Reviewed", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Parking_Lot_Reviewed", DbType.String, this._Parking_Lot_Reviewed);

            if (string.IsNullOrEmpty(this._Parking_Deficiencies))
                db.AddInParameter(dbCommand, "Parking_Deficiencies", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Parking_Deficiencies", DbType.String, this._Parking_Deficiencies);

            if (string.IsNullOrEmpty(this._Parking_Comments))
                db.AddInParameter(dbCommand, "Parking_Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Parking_Comments", DbType.String, this._Parking_Comments);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._UniqueVal))
                db.AddInParameter(dbCommand, "UniqueVal", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "UniqueVal", DbType.String, this._UniqueVal);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, this._FK_SLT_Meeting_Schedule);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the SLT_Safety_Walk table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_SLT_Safety_Walk)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Safety_WalkDeleteByPK");

            db.AddInParameter(dbCommand, "PK_SLT_Safety_Walk", DbType.Decimal, pK_SLT_Safety_Walk);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects all records from the SLT_Safety_Walk table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectBYFK(decimal FK_SLT_Meeting)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectSLT_Safety_WalkBYFK");
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, FK_SLT_Meeting);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the SLT_Safety_Walk table by a composite primary key.
        /// </summary>
        public static void DeleteByFK(decimal FK_SLT_Meeting_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Safety_WalkDeleteByFK");

            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, FK_SLT_Meeting_Schedule);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
