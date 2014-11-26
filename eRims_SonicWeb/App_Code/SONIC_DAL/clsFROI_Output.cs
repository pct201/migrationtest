using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for FROI_Output table.
	/// </summary>
	public sealed class clsFROI_Output
	{

		#region Private variables used to hold the property values

		private decimal? _PK_FROI_Output;
		private string _FROI_Type;
		private decimal? _FROI_Number;
		private DateTime? _Date_Output;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_FROI_Output value.
		/// </summary>
		public decimal? PK_FROI_Output
		{
			get { return _PK_FROI_Output; }
			set { _PK_FROI_Output = value; }
		}

		/// <summary>
		/// Gets or sets the FROI_Type value.
		/// </summary>
		public string FROI_Type
		{
			get { return _FROI_Type; }
			set { _FROI_Type = value; }
		}

		/// <summary>
		/// Gets or sets the FROI_Number value.
		/// </summary>
		public decimal? FROI_Number
		{
			get { return _FROI_Number; }
			set { _FROI_Number = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Output value.
		/// </summary>
		public DateTime? Date_Output
		{
			get { return _Date_Output; }
			set { _Date_Output = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsFROI_Output class with default value.
		/// </summary>
		public clsFROI_Output() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsFROI_Output class based on Primary Key.
		/// </summary>
		public clsFROI_Output(decimal pK_FROI_Output) 
		{
			DataTable dtFROI_Output = SelectByPK(pK_FROI_Output).Tables[0];

			if (dtFROI_Output.Rows.Count == 1)
			{
				 SetValue(dtFROI_Output.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsFROI_Output class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drFROI_Output) 
		{
				if (drFROI_Output["PK_FROI_Output"] == DBNull.Value)
					this._PK_FROI_Output = null;
				else
					this._PK_FROI_Output = (decimal?)drFROI_Output["PK_FROI_Output"];

				if (drFROI_Output["FROI_Type"] == DBNull.Value)
					this._FROI_Type = null;
				else
					this._FROI_Type = (string)drFROI_Output["FROI_Type"];

				if (drFROI_Output["FROI_Number"] == DBNull.Value)
					this._FROI_Number = null;
				else
					this._FROI_Number = (decimal?)drFROI_Output["FROI_Number"];

				if (drFROI_Output["Date_Output"] == DBNull.Value)
					this._Date_Output = null;
				else
					this._Date_Output = (DateTime?)drFROI_Output["Date_Output"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the FROI_Output table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("FROI_OutputInsert");

			
			if (string.IsNullOrEmpty(this._FROI_Type))
				db.AddInParameter(dbCommand, "FROI_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FROI_Type", DbType.String, this._FROI_Type);
			
			db.AddInParameter(dbCommand, "FROI_Number", DbType.Decimal, this._FROI_Number);
			
			db.AddInParameter(dbCommand, "Date_Output", DbType.DateTime, this._Date_Output);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the FROI_Output table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_FROI_Output)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("FROI_OutputSelectByPK");

			db.AddInParameter(dbCommand, "PK_FROI_Output", DbType.Decimal, pK_FROI_Output);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the FROI_Output table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("FROI_OutputSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the FROI_Output table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("FROI_OutputUpdate");

			
			db.AddInParameter(dbCommand, "PK_FROI_Output", DbType.Decimal, this._PK_FROI_Output);
			
			if (string.IsNullOrEmpty(this._FROI_Type))
				db.AddInParameter(dbCommand, "FROI_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FROI_Type", DbType.String, this._FROI_Type);
			
			db.AddInParameter(dbCommand, "FROI_Number", DbType.Decimal, this._FROI_Number);
			
			db.AddInParameter(dbCommand, "Date_Output", DbType.DateTime, this._Date_Output);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the FROI_Output table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_FROI_Output)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("FROI_OutputDeleteByPK");

			db.AddInParameter(dbCommand, "PK_FROI_Output", DbType.Decimal, pK_FROI_Output);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
