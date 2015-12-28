using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for SLT_BT_Security_Walk_Members table.
	/// </summary>
	public sealed class clsSLT_BT_Security_Walk_Members
	{

		#region Private variables used to hold the property values

		private decimal? _PK_SLT_BT_Security_Walk_Members;
		private decimal? _FK_SLT_BT_Security_Walk;
		private decimal? _FK_SLT_Members;
		private bool? _Participated;
		private DateTime? _Created_Date;
		private DateTime? _Updated_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_SLT_BT_Security_Walk_Members value.
		/// </summary>
		public decimal? PK_SLT_BT_Security_Walk_Members
		{
			get { return _PK_SLT_BT_Security_Walk_Members; }
			set { _PK_SLT_BT_Security_Walk_Members = value; }
		}

		/// <summary>
		/// Gets or sets the FK_SLT_BT_Security_Walk value.
		/// </summary>
		public decimal? FK_SLT_BT_Security_Walk
		{
			get { return _FK_SLT_BT_Security_Walk; }
			set { _FK_SLT_BT_Security_Walk = value; }
		}

		/// <summary>
		/// Gets or sets the FK_SLT_Members value.
		/// </summary>
		public decimal? FK_SLT_Members
		{
			get { return _FK_SLT_Members; }
			set { _FK_SLT_Members = value; }
		}

		/// <summary>
		/// Gets or sets the Participated value.
		/// </summary>
		public bool? Participated
		{
			get { return _Participated; }
			set { _Participated = value; }
		}

		/// <summary>
		/// Gets or sets the Created_Date value.
		/// </summary>
		public DateTime? Created_Date
		{
			get { return _Created_Date; }
			set { _Created_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Updated_Date value.
		/// </summary>
		public DateTime? Updated_Date
		{
			get { return _Updated_Date; }
			set { _Updated_Date = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsSLT_BT_Security_Walk_Members class with default value.
		/// </summary>
		public clsSLT_BT_Security_Walk_Members() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsSLT_BT_Security_Walk_Members class based on Primary Key.
		/// </summary>
		public clsSLT_BT_Security_Walk_Members(decimal pK_SLT_BT_Security_Walk_Members) 
		{
			DataTable dtSLT_BT_Security_Walk_Members = SelectByPK(pK_SLT_BT_Security_Walk_Members).Tables[0];

			if (dtSLT_BT_Security_Walk_Members.Rows.Count == 1)
			{
				 SetValue(dtSLT_BT_Security_Walk_Members.Rows[0]);

			}

		}

          /// <summary>
        /// Initializes a new instance of the clsSLT_BT_Security_Walk_Members class based on Foreign Key.
        /// </summary>
        public clsSLT_BT_Security_Walk_Members(decimal FK_SLT_Members, bool Status, decimal FK_SLT_BT_Security_Walk)
        {
            DataTable dtSLT_Safety_Walk_Members = SelectByFk(FK_SLT_Members, FK_SLT_BT_Security_Walk).Tables[0];

            if (dtSLT_Safety_Walk_Members.Rows.Count == 1)
            {
                SetValue(dtSLT_Safety_Walk_Members.Rows[0]);

            }

        }


		/// <summary>
		/// Initializes a new instance of the clsSLT_BT_Security_Walk_Members class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSLT_BT_Security_Walk_Members) 
		{
				if (drSLT_BT_Security_Walk_Members["PK_SLT_BT_Security_Walk_Members"] == DBNull.Value)
					this._PK_SLT_BT_Security_Walk_Members = null;
				else
					this._PK_SLT_BT_Security_Walk_Members = (decimal?)drSLT_BT_Security_Walk_Members["PK_SLT_BT_Security_Walk_Members"];

				if (drSLT_BT_Security_Walk_Members["FK_SLT_BT_Security_Walk"] == DBNull.Value)
					this._FK_SLT_BT_Security_Walk = null;
				else
					this._FK_SLT_BT_Security_Walk = (decimal?)drSLT_BT_Security_Walk_Members["FK_SLT_BT_Security_Walk"];

				if (drSLT_BT_Security_Walk_Members["FK_SLT_Members"] == DBNull.Value)
					this._FK_SLT_Members = null;
				else
					this._FK_SLT_Members = (decimal?)drSLT_BT_Security_Walk_Members["FK_SLT_Members"];

				if (drSLT_BT_Security_Walk_Members["Participated"] == DBNull.Value)
					this._Participated = null;
				else
					this._Participated = (bool?)drSLT_BT_Security_Walk_Members["Participated"];

				if (drSLT_BT_Security_Walk_Members["Created_Date"] == DBNull.Value)
					this._Created_Date = null;
				else
					this._Created_Date = (DateTime?)drSLT_BT_Security_Walk_Members["Created_Date"];

				if (drSLT_BT_Security_Walk_Members["Updated_Date"] == DBNull.Value)
					this._Updated_Date = null;
				else
					this._Updated_Date = (DateTime?)drSLT_BT_Security_Walk_Members["Updated_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the SLT_BT_Security_Walk_Members table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_MembersInsert");

			
			db.AddInParameter(dbCommand, "FK_SLT_BT_Security_Walk", DbType.Decimal, this._FK_SLT_BT_Security_Walk);
			
			db.AddInParameter(dbCommand, "FK_SLT_Members", DbType.Decimal, this._FK_SLT_Members);
			
			db.AddInParameter(dbCommand, "Participated", DbType.Boolean, this._Participated);
			
			db.AddInParameter(dbCommand, "Created_Date", DbType.DateTime, this._Created_Date);
			
			db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the SLT_BT_Security_Walk_Members table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_SLT_BT_Security_Walk_Members)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_MembersSelectByPK");

			db.AddInParameter(dbCommand, "PK_SLT_BT_Security_Walk_Members", DbType.Decimal, pK_SLT_BT_Security_Walk_Members);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the SLT_BT_Security_Walk_Members table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_MembersSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the SLT_BT_Security_Walk_Members table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_MembersUpdate");

			
			db.AddInParameter(dbCommand, "PK_SLT_BT_Security_Walk_Members", DbType.Decimal, this._PK_SLT_BT_Security_Walk_Members);
			
			db.AddInParameter(dbCommand, "FK_SLT_BT_Security_Walk", DbType.Decimal, this._FK_SLT_BT_Security_Walk);
			
			db.AddInParameter(dbCommand, "FK_SLT_Members", DbType.Decimal, this._FK_SLT_Members);
			
			db.AddInParameter(dbCommand, "Participated", DbType.Boolean, this._Participated);
			
			db.AddInParameter(dbCommand, "Created_Date", DbType.DateTime, this._Created_Date);
			
			db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the SLT_BT_Security_Walk_Members table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_SLT_BT_Security_Walk_Members)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_MembersDeleteByPK");

			db.AddInParameter(dbCommand, "PK_SLT_BT_Security_Walk_Members", DbType.Decimal, pK_SLT_BT_Security_Walk_Members);

			db.ExecuteNonQuery(dbCommand);
		}

        public static DataSet SelectByFk(decimal FK_SLT_Members, decimal FK_SLT_BT_Security_Walk)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_MembersSelectBYFK");
            db.AddInParameter(dbCommand, "FK_SLT_Members", DbType.Decimal, FK_SLT_Members);
            db.AddInParameter(dbCommand, "FK_SLT_BT_Security_Walk", DbType.Decimal, FK_SLT_BT_Security_Walk);
            return db.ExecuteDataSet(dbCommand);
        }
	}
}
