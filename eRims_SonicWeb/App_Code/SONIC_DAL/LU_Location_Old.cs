using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

/// <summary>
/// Data access class for LU_Location table.
/// </summary>
public sealed class LU_Location_Old
{

    #region Private variables used to hold the property values

    private decimal? _PK_LU_Location;
    private string _Fld_Code;
    private string _Fld_Desc;
    private string _Active;
    private string _dba;
    private decimal? _Group_ID;

    #endregion

    #region Public Property

    /// <summary>
    /// Gets or sets the PK_LU_Location value.
    /// </summary>
    public decimal? PK_LU_Location
    {
        get { return _PK_LU_Location; }
        set { _PK_LU_Location = value; }
    }

    /// <summary>
    /// Gets or sets the Fld_Code value.
    /// </summary>
    public string Fld_Code
    {
        get { return _Fld_Code; }
        set { _Fld_Code = value; }
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
    /// Gets or sets the Active value.
    /// </summary>
    public string Active
    {
        get { return _Active; }
        set { _Active = value; }
    }

    /// <summary>
    /// Gets or sets the dba value.
    /// </summary>
    public string dba
    {
        get { return _dba; }
        set { _dba = value; }
    }

    /// <summary>
    /// Gets or sets the Group_ID value.
    /// </summary>
    public decimal? Group_ID
    {
        get { return _Group_ID; }
        set { _Group_ID = value; }
    }
    #endregion

    #region Default Constructors

    /// <summary>
    /// Initializes a new instance of the LU_Location class with default value.
    /// </summary>
    public LU_Location_Old()
    {

        this._PK_LU_Location = null;
        this._Fld_Code = null;
        this._Fld_Desc = null;
        this._Active = null;
        this._dba = null;
        this._Group_ID = null;
    }

    #endregion

    #region Primary Constructors

    /// <summary>
    /// Initializes a new instance of the LU_Location class based on Primary Key.
    /// </summary>
    public LU_Location_Old(decimal pK_LU_Location)
    {
        DataTable dtLU_Location = SelectByPK(pK_LU_Location).Tables[0];

        if (dtLU_Location.Rows.Count == 1)
        {
            DataRow drLU_Location = dtLU_Location.Rows[0];
            if (drLU_Location["PK_LU_Location"] == DBNull.Value)
                this._PK_LU_Location = null;
            else
                this._PK_LU_Location = (decimal?)drLU_Location["PK_LU_Location"];

            if (drLU_Location["Fld_Code"] == DBNull.Value)
                this._Fld_Code = null;
            else
                this._Fld_Code = (string)drLU_Location["Fld_Code"];

            if (drLU_Location["Fld_Desc"] == DBNull.Value)
                this._Fld_Desc = null;
            else
                this._Fld_Desc = (string)drLU_Location["Fld_Desc"];

            if (drLU_Location["Active"] == DBNull.Value)
                this._Active = null;
            else
                this._Active = (string)drLU_Location["Active"];

            if (drLU_Location["dba"] == DBNull.Value)
                this._dba = null;
            else
                this._dba = (string)drLU_Location["dba"];

            if (drLU_Location["Group_ID"] == DBNull.Value)
                this._Group_ID = null;
            else
                this._Group_ID = (decimal?)drLU_Location["Group_ID"];
        }
        else
        {
            this._PK_LU_Location = null;
            this._Fld_Code = null;
            this._Fld_Desc = null;
            this._Active = null;
            this._dba = null;
            this._Group_ID = null;
        }

    }

    #endregion

    /// <summary>
    /// Inserts a record into the LU_Location table.
    /// </summary>
    /// <returns></returns>
    public int Insert()
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_OldInsert");


        if (string.IsNullOrEmpty(this._Fld_Code))
            db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);

        if (string.IsNullOrEmpty(this._Fld_Desc))
            db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

        if (string.IsNullOrEmpty(this._Active))
            db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

        if (string.IsNullOrEmpty(this._dba))
            db.AddInParameter(dbCommand, "dba", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "dba", DbType.String, this._dba);

        db.AddInParameter(dbCommand, "Group_ID", DbType.Decimal, this._Group_ID);
        // Execute the query and return the new identity value
        int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

        return returnValue;
    }

    /// <summary>
    /// Selects a single record from the LU_Location table by a primary key.
    /// </summary>
    /// <returns>DataSet</returns>
    private static DataSet SelectByPK(decimal pK_LU_Location)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_OldSelectByPK");

        db.AddInParameter(dbCommand, "PK_LU_Location", DbType.Decimal, pK_LU_Location);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// Selects all records from the LU_Location table.
    /// </summary>
    /// <returns>DataSet</returns>
    public static DataSet SelectAll(int intOrder)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_OldSelectAll");

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// Updates a record in the LU_Location table.
    /// </summary>
    public decimal Update()
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_OldUpdate");


        db.AddInParameter(dbCommand, "PK_LU_Location", DbType.Decimal, this._PK_LU_Location);

        if (string.IsNullOrEmpty(this._Fld_Code))
            db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);

        if (string.IsNullOrEmpty(this._Fld_Desc))
            db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

        if (string.IsNullOrEmpty(this._Active))
            db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

        if (string.IsNullOrEmpty(this._dba))
            db.AddInParameter(dbCommand, "dba", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "dba", DbType.String, this._dba);

        db.AddInParameter(dbCommand, "Group_ID", DbType.Decimal, this._Group_ID);

        return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
    }

}