using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Event_Level table.
	/// </summary>
	public sealed class clsLU_Event_Level
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Event_Level;
		private string _Fld_Desc;
		private string _Fld_Code;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Event_Level value.
		/// </summary>
		public decimal? PK_LU_Event_Level
		{
			get { return _PK_LU_Event_Level; }
			set { _PK_LU_Event_Level = value; }
		}

		/// <summary>
		/// Gets or sets the Fld_Desc value.
		/// </summary>
		public string Fld_Desc
		{
			get { return _Fld_Desc; }
			set { _Fld_Desc = value; }
		}

		/// <summary>
		/// Gets or sets the Fld_Code value.
		/// </summary>
		public string Fld_Code
		{
			get { return _Fld_Code; }
			set { _Fld_Code = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Event_Level class with default value.
		/// </summary>
		public clsLU_Event_Level() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Event_Level class based on Primary Key.
		/// </summary>
		public clsLU_Event_Level(decimal pK_LU_Event_Level) 
		{
			DataTable dtLU_Event_Level = SelectByPK(pK_LU_Event_Level).Tables[0];

			if (dtLU_Event_Level.Rows.Count == 1)
			{
				 SetValue(dtLU_Event_Level.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Event_Level class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Event_Level) 
		{
				if (drLU_Event_Level["PK_LU_Event_Level"] == DBNull.Value)
					this._PK_LU_Event_Level = null;
				else
					this._PK_LU_Event_Level = (decimal?)drLU_Event_Level["PK_LU_Event_Level"];

				if (drLU_Event_Level["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Event_Level["Fld_Desc"];

				if (drLU_Event_Level["Fld_Code"] == DBNull.Value)
					this._Fld_Code = null;
				else
					this._Fld_Code = (string)drLU_Event_Level["Fld_Code"];


		}

		#endregion

		/// <summary>
		/// Selects a single record from the LU_Event_Level table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Event_Level)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Event_LevelSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Event_Level", DbType.Decimal, pK_LU_Event_Level);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Event_Level table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Event_LevelSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}
	}
}
