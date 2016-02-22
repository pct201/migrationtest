using ERIMS.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Web;

/// <summary>
/// Summary description for Property_Claims_AdhocReportFields
/// </summary>
public class Property_Claims_AdhocReportFields
{
    #region Private variables used to hold the property values

    private decimal? _Pk_AdhocReportFields;
    private int? _Fk_ControlType;
    private string _Table_Name;
    private string _Field_Name;
    private string _Field_Header;
    private string _WhereField;

    #endregion

    #region Public Property

    /// <summary>
    /// Gets or sets the Pk_AdhocReportFields value.
    /// </summary>
    public decimal? Pk_AdhocReportFields
    {
        get { return _Pk_AdhocReportFields; }
        set { _Pk_AdhocReportFields = value; }
    }

    /// <summary>
    /// Gets or sets the Fk_ControlType value.
    /// </summary>
    public int? Fk_ControlType
    {
        get { return _Fk_ControlType; }
        set { _Fk_ControlType = value; }
    }


    /// <summary>
    /// Gets or sets the Table_Name value.
    /// </summary>
    public string Table_Name
    {
        get { return _Table_Name; }
        set { _Table_Name = value; }
    }


    /// <summary>
    /// Gets or sets the Field_Name value.
    /// </summary>
    public string Field_Name
    {
        get { return _Field_Name; }
        set { _Field_Name = value; }
    }


    /// <summary>
    /// Gets or sets the Field_Header value.
    /// </summary>
    public string Field_Header
    {
        get { return _Field_Header; }
        set { _Field_Header = value; }
    }


    /// <summary>
    /// Gets or sets the WhereField value.
    /// </summary>
    public string WhereField
    {
        get { return _WhereField; }
        set { _WhereField = value; }
    }

    #endregion

    /// <summary>
    /// Default Constructor
    /// </summary>
	public Property_Claims_AdhocReportFields()
	{
        _Pk_AdhocReportFields = null;
        _Fk_ControlType = null;
        _Table_Name = null;
        _Field_Header = null;
        _Field_Name = null;
        _WhereField = null;
	}

    /// <summary>
    /// Get Ad Hoc Field Name
    /// </summary>
    /// <param name="strCoverage"></param>
    /// <param name="strFieldType"></param>
    /// <returns></returns>
    public static DataSet GetAdHocFilterFields(string strFieldType)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_SelectAdHocFilterFields");

        db.AddInParameter(dbCommand, "FieldType", DbType.String, strFieldType);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// Get Adhoc Report filter fields by AdHoc Report ID
    /// </summary>
    /// <param name="Pk_AdHocReport"></param>
    /// <returns></returns>
    public List<Property_Claims_AdhocReportFields> GetAdHocReportFieldByPk(decimal Pk_AdHocReport)
    {
        Database dbHelper = null;
        DbCommand cmd = null;
        IDataReader reader = null;
        try
        {
            dbHelper = DatabaseFactory.CreateDatabase();
            List<Property_Claims_AdhocReportFields> results = new List<Property_Claims_AdhocReportFields>();
            Property_Claims_AdhocReportFields objAdHoc;

            cmd = dbHelper.GetStoredProcCommand("Property_Claims_AdHocReportField_SelectByPk");
            dbHelper.AddInParameter(cmd, "Pk_AdhocReportFields", DbType.Decimal, Pk_AdHocReport);
            reader = dbHelper.ExecuteReader(cmd);
            while (reader.Read())
            {
                objAdHoc = MapFrom(reader);
                results.Add(objAdHoc);
            }
            return results;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            reader.Close();
            reader = null;
            cmd = null;
            dbHelper = null;
        }
    }

    /// <summary>
    /// Map Data Reader value with variables
    /// </summary>
    /// <param name="reader"></param>
    /// <returns></returns>
    protected Property_Claims_AdhocReportFields MapFrom(IDataReader reader)
    {
        Property_Claims_AdhocReportFields objAdHoc = new Property_Claims_AdhocReportFields();
        if (!Convert.IsDBNull(reader["Pk_AdhocReportFields"])) { objAdHoc.Pk_AdhocReportFields = Convert.ToDecimal(reader["Pk_AdhocReportFields"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Fk_ControlType"])) { objAdHoc.Fk_ControlType = Convert.ToInt32(reader["Fk_ControlType"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Field_Header"])) { objAdHoc.Field_Header = Convert.ToString(reader["Field_Header"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Field_Name"])) { objAdHoc.Field_Name = Convert.ToString(reader["Field_Name"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Table_Name"])) { objAdHoc.Table_Name = Convert.ToString(reader["Table_Name"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["WhereField"])) { objAdHoc.WhereField = Convert.ToString(reader["WhereField"], CultureInfo.InvariantCulture); }
        return objAdHoc;
    }

    /// <summary>
    /// Get multiple AhHocReportField records based on CSV Pk_AdhocReportFields
    /// </summary>
    /// <param name="Pk_AdhocReportFields"></param>
    /// <returns></returns>
    public List<Property_Claims_AdhocReportFields> GetAdHocReportFieldByMultipleID(string Pk_AdhocReportFields)
    {

        Database dbHelper = null;
        DbCommand cmd = null;
        IDataReader reader = null;
        try
        {
            List<Property_Claims_AdhocReportFields> results = new List<Property_Claims_AdhocReportFields>();
            Property_Claims_AdhocReportFields objAdHoc = new Property_Claims_AdhocReportFields();

            dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("Property_Claims_AdHocReportSelectWhereFileld");
            dbHelper.AddInParameter(cmd, "Pk_AdhocReportFields", DbType.String, Pk_AdhocReportFields);
            reader = dbHelper.ExecuteReader(cmd);
            while (reader.Read())
            {
                objAdHoc = MapFrom(reader);
                results.Add(objAdHoc);
            }
            return results;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            reader.Close();
            reader = null;
            cmd = null;
            dbHelper = null;
        }
    }
}