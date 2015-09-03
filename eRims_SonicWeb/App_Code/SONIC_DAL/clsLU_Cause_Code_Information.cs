using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Cause_Code_Information table.
	/// </summary>
	public sealed class clsLU_Cause_Code_Information
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Cause_Code_Information;
		private string _Focus_Area;
		private int? _Sort_Order;
		private string _Question;
		private string _Guidance;
		private string _Reference;
		private string _Active;
		private string _Updated_By;
		private DateTime? _Update_Date;
		private int? _Master_Order;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Cause_Code_Information value.
		/// </summary>
		public decimal? PK_LU_Cause_Code_Information
		{
			get { return _PK_LU_Cause_Code_Information; }
			set { _PK_LU_Cause_Code_Information = value; }
		}

		/// <summary>
		/// Gets or sets the Focus_Area value.
		/// </summary>
		public string Focus_Area
		{
			get { return _Focus_Area; }
			set { _Focus_Area = value; }
		}

		/// <summary>
		/// Gets or sets the Sort_Order value.
		/// </summary>
		public int? Sort_Order
		{
			get { return _Sort_Order; }
			set { _Sort_Order = value; }
		}

		/// <summary>
		/// Gets or sets the Question value.
		/// </summary>
		public string Question
		{
			get { return _Question; }
			set { _Question = value; }
		}

		/// <summary>
		/// Gets or sets the Guidance value.
		/// </summary>
		public string Guidance
		{
			get { return _Guidance; }
			set { _Guidance = value; }
		}

		/// <summary>
		/// Gets or sets the Reference value.
		/// </summary>
		public string Reference
		{
			get { return _Reference; }
			set { _Reference = value; }
		}

		/// <summary>
		/// Gets or sets the Active value.
		/// </summary>
		public string Active
		{
			get { return _Active; }
			set { _Active = value; }
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
		/// Gets or sets the Master_Order value.
		/// </summary>
		public int? Master_Order
		{
			get { return _Master_Order; }
			set { _Master_Order = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Cause_Code_Information class with default value.
		/// </summary>
		public clsLU_Cause_Code_Information() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Cause_Code_Information class based on Primary Key.
		/// </summary>
		public clsLU_Cause_Code_Information(decimal pK_LU_Cause_Code_Information) 
		{
			DataTable dtLU_Cause_Code_Information = SelectByPK(pK_LU_Cause_Code_Information).Tables[0];

			if (dtLU_Cause_Code_Information.Rows.Count == 1)
			{
				 SetValue(dtLU_Cause_Code_Information.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Cause_Code_Information class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Cause_Code_Information) 
		{
				if (drLU_Cause_Code_Information["PK_LU_Cause_Code_Information"] == DBNull.Value)
					this._PK_LU_Cause_Code_Information = null;
				else
					this._PK_LU_Cause_Code_Information = (decimal?)drLU_Cause_Code_Information["PK_LU_Cause_Code_Information"];

				if (drLU_Cause_Code_Information["Focus_Area"] == DBNull.Value)
					this._Focus_Area = null;
				else
					this._Focus_Area = (string)drLU_Cause_Code_Information["Focus_Area"];

				if (drLU_Cause_Code_Information["Sort_Order"] == DBNull.Value)
					this._Sort_Order = null;
				else
					this._Sort_Order = (int?)drLU_Cause_Code_Information["Sort_Order"];

				if (drLU_Cause_Code_Information["Question"] == DBNull.Value)
					this._Question = null;
				else
					this._Question = (string)drLU_Cause_Code_Information["Question"];

				if (drLU_Cause_Code_Information["Guidance"] == DBNull.Value)
					this._Guidance = null;
				else
					this._Guidance = (string)drLU_Cause_Code_Information["Guidance"];

				if (drLU_Cause_Code_Information["Reference"] == DBNull.Value)
					this._Reference = null;
				else
					this._Reference = (string)drLU_Cause_Code_Information["Reference"];

				if (drLU_Cause_Code_Information["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Cause_Code_Information["Active"];

				if (drLU_Cause_Code_Information["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drLU_Cause_Code_Information["Updated_By"];

				if (drLU_Cause_Code_Information["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drLU_Cause_Code_Information["Update_Date"];

				if (drLU_Cause_Code_Information["Master_Order"] == DBNull.Value)
					this._Master_Order = null;
				else
					this._Master_Order = (int?)drLU_Cause_Code_Information["Master_Order"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Cause_Code_Information table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Cause_Code_InformationInsert");

			
			if (string.IsNullOrEmpty(this._Focus_Area))
				db.AddInParameter(dbCommand, "Focus_Area", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Focus_Area", DbType.String, this._Focus_Area);
			
			db.AddInParameter(dbCommand, "Sort_Order", DbType.Int32, this._Sort_Order);
			
			if (string.IsNullOrEmpty(this._Question))
				db.AddInParameter(dbCommand, "Question", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Question", DbType.String, this._Question);
			
			if (string.IsNullOrEmpty(this._Guidance))
				db.AddInParameter(dbCommand, "Guidance", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Guidance", DbType.String, this._Guidance);
			
			if (string.IsNullOrEmpty(this._Reference))
				db.AddInParameter(dbCommand, "Reference", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Reference", DbType.String, this._Reference);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			db.AddInParameter(dbCommand, "Master_Order", DbType.Int32, this._Master_Order);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}


       //public clsLU_Cause_Code_Information()
       // {
       //      this._PK_LU_Cause_Code_Information = -1;
       //         this._Focus_Area = "";
       //         //this._Sort_Order = "";
       //         this._Question = "";
       //         this._Guidance = "";
       //         this._Active = "N";
       //  }


        public clsLU_Cause_Code_Information(int PK)
        {

            DataTable dtInspection_Questions = SelectByPK(PK).Tables[0];

            if (dtInspection_Questions.Rows.Count > 0)
            {

                DataRow drInspection_Questions = dtInspection_Questions.Rows[0];

                this._PK_LU_Cause_Code_Information = drInspection_Questions["PK_LU_Cause_Code_Information"] != DBNull.Value ? Convert.ToInt32(drInspection_Questions["PK_LU_Cause_Code_Information"]) : 0;
                this._Focus_Area = Convert.ToString(drInspection_Questions["Focus_Area"]);
                this._Sort_Order = Convert.ToInt16(drInspection_Questions["Sort_Order"]);
                this._Question = Convert.ToString(drInspection_Questions["Question"]);
                this._Guidance = Convert.ToString(drInspection_Questions["Guidance"]);
                this._Reference = Convert.ToString(drInspection_Questions["Reference"]);
                this._Active = Convert.ToString(drInspection_Questions["Active"]);

            }

            else
            {

                this._PK_LU_Cause_Code_Information = -1;
                this._Focus_Area = "";
                this._Sort_Order = -1;
                this._Question = "";
                this._Guidance = "";
                this._Reference = "";
                this._Active = "N";
            }

        }




        /// <summary>
		/// Selects a single record from the LU_Cause_Code_Information table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Cause_Code_Information)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Cause_Code_InformationSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Cause_Code_Information", DbType.Decimal, pK_LU_Cause_Code_Information);

			return db.ExecuteDataSet(dbCommand);
		}


        /// <summary>
        /// Selects a single record from the LU_Cause_Code_Information table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllID()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Cause_Code_InformationSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }
		/// <summary>
		/// Selects all records from the LU_Cause_Code_Information table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Cause_Code_InformationSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}


        /// <summary>
        /// Selects Focus Area from the LU_Cause_Code_Information table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectFocusArea()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Cause_Code_InformationSelectFocusArea");

            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// Selects Questions from the LU_Cause_Code_Information table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectQuestions(decimal Master_Order)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Cause_Code_InformationSelectQuestions");
            db.AddInParameter(dbCommand, "Master_Order", DbType.Decimal, Master_Order);

            return db.ExecuteDataSet(dbCommand);
        }


		/// <summary>
		/// Updates a record in the LU_Cause_Code_Information table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Cause_Code_InformationUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Cause_Code_Information", DbType.Decimal, this._PK_LU_Cause_Code_Information);
			
			if (string.IsNullOrEmpty(this._Focus_Area))
				db.AddInParameter(dbCommand, "Focus_Area", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Focus_Area", DbType.String, this._Focus_Area);
			
			db.AddInParameter(dbCommand, "Sort_Order", DbType.Int32, this._Sort_Order);
			
			if (string.IsNullOrEmpty(this._Question))
				db.AddInParameter(dbCommand, "Question", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Question", DbType.String, this._Question);
			
			if (string.IsNullOrEmpty(this._Guidance))
				db.AddInParameter(dbCommand, "Guidance", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Guidance", DbType.String, this._Guidance);
			
			if (string.IsNullOrEmpty(this._Reference))
				db.AddInParameter(dbCommand, "Reference", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Reference", DbType.String, this._Reference);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			db.AddInParameter(dbCommand, "Master_Order", DbType.Int32, this._Master_Order);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Updates a record in the LU_Cause_Code_Information table.
        /// </summary>
        public void UpdateSortOrder()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Cause_Code_InformationUpdate_SortOrder");


            db.AddInParameter(dbCommand, "PK_LU_Cause_Code_Information", DbType.Decimal, this._PK_LU_Cause_Code_Information);

            db.AddInParameter(dbCommand, "Sort_Order", DbType.Int32, this._Sort_Order);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);


            db.ExecuteNonQuery(dbCommand);
        }


		/// <summary>
		/// Deletes a record from the LU_Cause_Code_Information table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Cause_Code_Information)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Cause_Code_InformationDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Cause_Code_Information", DbType.Decimal, pK_LU_Cause_Code_Information);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
