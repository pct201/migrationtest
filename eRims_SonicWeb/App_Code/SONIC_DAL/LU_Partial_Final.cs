using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table LU_Partial_Final
	/// </summary>
	public sealed class LU_Partial_Final
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Partial_Final;
		private string _Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Partial_Final value.
		/// </summary>
		public decimal? PK_LU_Partial_Final
		{
			get { return _PK_LU_Partial_Final; }
			set { _PK_LU_Partial_Final = value; }
		}

		/// <summary>
		/// Gets or sets the Desc value.
		/// </summary>
		public string Desc
		{
			get { return _Desc; }
			set { _Desc = value; }
		}

		/// <summary>
		/// Gets or sets the Active value.
		/// </summary>
		public string Active
		{
			get { return _Active; }
			set { _Active = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Partial_Final class with default value.
		/// </summary>
		public LU_Partial_Final() 
		{


		}

		#endregion

		#region Primary Constructors
        
        ///// <summary>
        ///// Initializes a new instance of the LU_Partial_Final class based on Datarow passed.
        ///// </summary>
        //private void SetValue (DataRow drLU_Partial_Final) 
        //{
        //        if (drLU_Partial_Final["PK_LU_Partial_Final"] == DBNull.Value)
        //            this._PK_LU_Partial_Final = null;
        //        else
        //            this._PK_LU_Partial_Final = (decimal?)drLU_Partial_Final["PK_LU_Partial_Final"];

        //        if (drLU_Partial_Final["Desc"] == DBNull.Value)
        //            this._Desc = null;
        //        else
        //            this._Desc = (string)drLU_Partial_Final["Desc"];

        //        if (drLU_Partial_Final["Active"] == DBNull.Value)
        //            this._Active = null;
        //        else
        //            this._Active = (string)drLU_Partial_Final["Active"];


        //}

		#endregion

		/// <summary>
		/// Selects all records from the LU_Partial_Final table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAllActive()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Partial_FinalSelectAllActive");

			return db.ExecuteDataSet(dbCommand);
		}

	}
}
