using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Property_Assessment_Concern table.
	/// </summary>
	public sealed class Property_Assessment_Concern
    {
        #region Fields


        private int _PK_Property_Assessment_Concern_ID;
        private int _FK_Property_Assessment_ID;
        private string _Item_Description;
        private Nullable<decimal> _Budgeted_Cost;
        private Nullable<decimal> _Actual_Cost;
        private DateTime _Date_Complete;
        private string _Comments;
        private decimal _Updated_By;
        private DateTime _Updated_Date;
        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Property_Assessment_Concern_ID value.
        /// </summary>
        public int PK_Property_Assessment_Concern_ID
        {
            get { return _PK_Property_Assessment_Concern_ID; }
            set { _PK_Property_Assessment_Concern_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Property_Assessment_ID value.
        /// </summary>
        public int FK_Property_Assessment_ID
        {
            get { return _FK_Property_Assessment_ID; }
            set { _FK_Property_Assessment_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Item_Description value.
        /// </summary>
        public string Item_Description
        {
            get { return _Item_Description; }
            set { _Item_Description = value; }
        }


        /// <summary> 
        /// Gets or sets the Budgeted_Cost value.
        /// </summary>
        public Nullable<decimal> Budgeted_Cost
        {
            get { return _Budgeted_Cost; }
            set { _Budgeted_Cost = value; }
        }


        /// <summary> 
        /// Gets or sets the Actual_Cost value.
        /// </summary>
        public Nullable<decimal> Actual_Cost
        {
            get { return _Actual_Cost; }
            set { _Actual_Cost = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Complete value.
        /// </summary>
        public DateTime Date_Complete
        {
            get { return _Date_Complete; }
            set { _Date_Complete = value; }
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

        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Property_Assessment_Concern class. with the default value.

        /// </summary>
        public Property_Assessment_Concern()
        {

            this._PK_Property_Assessment_Concern_ID = -1;
            this._FK_Property_Assessment_ID = -1;
            this._Item_Description = "";
            this._Budgeted_Cost = null;
            this._Actual_Cost = null;
            this._Date_Complete = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Comments = "";
            this._Updated_By = -1;
            this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }



        /// <summary> 

        /// Initializes a new instance of the Property_Assessment_Concern class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Property_Assessment_Concern(int PK)
        {

            DataTable dtProperty_Assessment_Concern = SelectByPK(PK).Tables[0];

            if (dtProperty_Assessment_Concern.Rows.Count > 0)
            {

                DataRow drProperty_Assessment_Concern = dtProperty_Assessment_Concern.Rows[0];

                this._PK_Property_Assessment_Concern_ID = drProperty_Assessment_Concern["PK_Property_Assessment_Concern_ID"] != DBNull.Value ? Convert.ToInt32(drProperty_Assessment_Concern["PK_Property_Assessment_Concern_ID"]) : 0;
                this._FK_Property_Assessment_ID = drProperty_Assessment_Concern["FK_Property_Assessment_ID"] != DBNull.Value ? Convert.ToInt32(drProperty_Assessment_Concern["FK_Property_Assessment_ID"]) : 0;
                this._Item_Description = Convert.ToString(drProperty_Assessment_Concern["Item_Description"]);
                if (drProperty_Assessment_Concern["Budgeted_Cost"] != DBNull.Value) this._Budgeted_Cost = Convert.ToDecimal(drProperty_Assessment_Concern["Budgeted_Cost"]);
                if (drProperty_Assessment_Concern["Actual_Cost"] != DBNull.Value) this._Actual_Cost = Convert.ToDecimal(drProperty_Assessment_Concern["Actual_Cost"]);
                this._Date_Complete = drProperty_Assessment_Concern["Date_Complete"] != DBNull.Value ? Convert.ToDateTime(drProperty_Assessment_Concern["Date_Complete"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Comments = Convert.ToString(drProperty_Assessment_Concern["Comments"]);
                this._Updated_By = drProperty_Assessment_Concern["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drProperty_Assessment_Concern["Updated_By"]) : 0;
                this._Updated_Date = drProperty_Assessment_Concern["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drProperty_Assessment_Concern["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }

            else
            {

                this._PK_Property_Assessment_Concern_ID = -1;
                this._FK_Property_Assessment_ID = -1;
                this._Item_Description = "";
                this._Budgeted_Cost = null;
                this._Actual_Cost = null;
                this._Date_Complete = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Comments = "";
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }

        }



        #endregion


        #region Methods
        /// <summary>
		/// Inserts a record into the Property_Assessment_Concern table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_Assessment_ConcernInsert");

			db.AddInParameter(dbCommand, "FK_Property_Assessment_ID", DbType.Int32, this._FK_Property_Assessment_ID);
			db.AddInParameter(dbCommand, "Item_Description", DbType.String, this._Item_Description);
            if (this._Budgeted_Cost != null)
                db.AddInParameter(dbCommand, "Budgeted_Cost", DbType.Decimal, this._Budgeted_Cost);
            else
                db.AddInParameter(dbCommand, "Budgeted_Cost", DbType.Decimal, DBNull.Value);

            if (this._Actual_Cost != null)
                db.AddInParameter(dbCommand, "Actual_Cost", DbType.Decimal, this._Actual_Cost);
            else
                db.AddInParameter(dbCommand, "Actual_Cost", DbType.Decimal, DBNull.Value);

            if (this._Date_Complete != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Date_Complete", DbType.DateTime, this._Date_Complete);
            else
                db.AddInParameter(dbCommand, "Date_Complete", DbType.DateTime, DBNull.Value);

			db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);
			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Property_Assessment_Concern table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(int pK_Property_Assessment_Concern_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_Assessment_ConcernSelectByPK");

			db.AddInParameter(dbCommand, "PK_Property_Assessment_Concern_ID", DbType.Int32, pK_Property_Assessment_Concern_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Property_Assessment_Concern table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_Assessment_ConcernSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Property_Assessment_Concern table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_Assessment_ConcernUpdate");

			db.AddInParameter(dbCommand, "PK_Property_Assessment_Concern_ID", DbType.Int32, this._PK_Property_Assessment_Concern_ID);
			db.AddInParameter(dbCommand, "FK_Property_Assessment_ID", DbType.Int32, this._FK_Property_Assessment_ID);
			db.AddInParameter(dbCommand, "Item_Description", DbType.String, this._Item_Description);
            
            if (this._Budgeted_Cost != null)
                db.AddInParameter(dbCommand, "Budgeted_Cost", DbType.Decimal, this._Budgeted_Cost);
            else
                db.AddInParameter(dbCommand, "Budgeted_Cost", DbType.Decimal, DBNull.Value);

            if (this._Actual_Cost != null)
                db.AddInParameter(dbCommand, "Actual_Cost", DbType.Decimal, this._Actual_Cost);
            else
                db.AddInParameter(dbCommand, "Actual_Cost", DbType.Decimal, DBNull.Value);

            if (this._Date_Complete != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Date_Complete", DbType.DateTime, this._Date_Complete);
            else
                db.AddInParameter(dbCommand, "Date_Complete", DbType.DateTime, DBNull.Value);

			db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Property_Assessment_Concern table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(int pK_Property_Assessment_Concern_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_Assessment_ConcernDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Property_Assessment_Concern_ID", DbType.Int32, pK_Property_Assessment_Concern_ID);

			db.ExecuteNonQuery(dbCommand);
        }


        public static DataSet SelectByFK(int fK_Property_Assessment_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_Assessment_ConcernSelectByFK");

            db.AddInParameter(dbCommand, "FK_Property_Assessment_ID", DbType.Int32, fK_Property_Assessment_ID);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
