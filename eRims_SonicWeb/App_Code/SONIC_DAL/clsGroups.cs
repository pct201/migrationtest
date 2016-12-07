using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

/// <summary>
/// Data access class for Groups table.
/// </summary>
public sealed class clsGroups
{

    #region Private variables used to hold the property values

    private decimal? _Pk_Group_Id;
    private decimal? _GROUPID;
    private decimal? _PARENTGROUPID;
    private int? _GROUPTYPEID;
    private string _TITLE;
    private bool? _ARMED;
    private DateTime? _TOGGLEARMAT;
    private int? _DISARMREASONID;
    private DateTime? _DISABLEDAT;
    private decimal? _TIMEZONEOFFSET;
    private bool? _DAYLIGHTSAVINGS;
    private int? _ULTYPE;
    private bool? _ISACTIVE;
    private bool? _ISSECURELINE;
    private bool? _ISENCRYPTED;
    private bool? _ONTEST;
    private int? _MAINTAINERID;
    private int? _RESPONSETIME;
    private int? _GROUPREMOTETYPEID;
    private string _REMOTEACCOUNT;
    private int? _SCRIPTID;
    private string _ADDRESS;
    private string _TELEPHONE1;
    private string _TELEPHONE2;
    private string _FAX;
    private string _TELEPHONEPOLICE;
    private string _TELEPHONEFIRE;
    private string _NOTES;
    private bool? _HAVEKEYS;
    private string _LOGO;
    private bool? _ISVIDEOVERIFICATION;
    private int? _FILESTOREID;
    private int? _TIMEZONEID;
    private int? _LICENSETYPEID;
    private int? _BRANDINGID;
    private bool? _MOBILEAPPENABLED;

    #endregion

    #region Public Property

    /// <summary>
    /// Gets or sets the Pk_Group_Id value.
    /// </summary>
    public decimal? Pk_Group_Id
    {
        get { return _Pk_Group_Id; }
        set { _Pk_Group_Id = value; }
    }

    /// <summary>
    /// Gets or sets the GROUPID value.
    /// </summary>
    public decimal? GROUPID
    {
        get { return _GROUPID; }
        set { _GROUPID = value; }
    }

    /// <summary>
    /// Gets or sets the PARENTGROUPID value.
    /// </summary>
    public decimal? PARENTGROUPID
    {
        get { return _PARENTGROUPID; }
        set { _PARENTGROUPID = value; }
    }

    /// <summary>
    /// Gets or sets the GROUPTYPEID value.
    /// </summary>
    public int? GROUPTYPEID
    {
        get { return _GROUPTYPEID; }
        set { _GROUPTYPEID = value; }
    }

    /// <summary>
    /// Gets or sets the TITLE value.
    /// </summary>
    public string TITLE
    {
        get { return _TITLE; }
        set { _TITLE = value; }
    }

    /// <summary>
    /// Gets or sets the ARMED value.
    /// </summary>
    public bool? ARMED
    {
        get { return _ARMED; }
        set { _ARMED = value; }
    }

    /// <summary>
    /// Gets or sets the TOGGLEARMAT value.
    /// </summary>
    public DateTime? TOGGLEARMAT
    {
        get { return _TOGGLEARMAT; }
        set { _TOGGLEARMAT = value; }
    }

    /// <summary>
    /// Gets or sets the DISARMREASONID value.
    /// </summary>
    public int? DISARMREASONID
    {
        get { return _DISARMREASONID; }
        set { _DISARMREASONID = value; }
    }

    /// <summary>
    /// Gets or sets the DISABLEDAT value.
    /// </summary>
    public DateTime? DISABLEDAT
    {
        get { return _DISABLEDAT; }
        set { _DISABLEDAT = value; }
    }

    /// <summary>
    /// Gets or sets the TIMEZONEOFFSET value.
    /// </summary>
    public decimal? TIMEZONEOFFSET
    {
        get { return _TIMEZONEOFFSET; }
        set { _TIMEZONEOFFSET = value; }
    }

    /// <summary>
    /// Gets or sets the DAYLIGHTSAVINGS value.
    /// </summary>
    public bool? DAYLIGHTSAVINGS
    {
        get { return _DAYLIGHTSAVINGS; }
        set { _DAYLIGHTSAVINGS = value; }
    }

    /// <summary>
    /// Gets or sets the ULTYPE value.
    /// </summary>
    public int? ULTYPE
    {
        get { return _ULTYPE; }
        set { _ULTYPE = value; }
    }

    /// <summary>
    /// Gets or sets the ISACTIVE value.
    /// </summary>
    public bool? ISACTIVE
    {
        get { return _ISACTIVE; }
        set { _ISACTIVE = value; }
    }

    /// <summary>
    /// Gets or sets the ISSECURELINE value.
    /// </summary>
    public bool? ISSECURELINE
    {
        get { return _ISSECURELINE; }
        set { _ISSECURELINE = value; }
    }

    /// <summary>
    /// Gets or sets the ISENCRYPTED value.
    /// </summary>
    public bool? ISENCRYPTED
    {
        get { return _ISENCRYPTED; }
        set { _ISENCRYPTED = value; }
    }

    /// <summary>
    /// Gets or sets the ONTEST value.
    /// </summary>
    public bool? ONTEST
    {
        get { return _ONTEST; }
        set { _ONTEST = value; }
    }

    /// <summary>
    /// Gets or sets the MAINTAINERID value.
    /// </summary>
    public int? MAINTAINERID
    {
        get { return _MAINTAINERID; }
        set { _MAINTAINERID = value; }
    }

    /// <summary>
    /// Gets or sets the RESPONSETIME value.
    /// </summary>
    public int? RESPONSETIME
    {
        get { return _RESPONSETIME; }
        set { _RESPONSETIME = value; }
    }

    /// <summary>
    /// Gets or sets the GROUPREMOTETYPEID value.
    /// </summary>
    public int? GROUPREMOTETYPEID
    {
        get { return _GROUPREMOTETYPEID; }
        set { _GROUPREMOTETYPEID = value; }
    }

    /// <summary>
    /// Gets or sets the REMOTEACCOUNT value.
    /// </summary>
    public string REMOTEACCOUNT
    {
        get { return _REMOTEACCOUNT; }
        set { _REMOTEACCOUNT = value; }
    }

    /// <summary>
    /// Gets or sets the SCRIPTID value.
    /// </summary>
    public int? SCRIPTID
    {
        get { return _SCRIPTID; }
        set { _SCRIPTID = value; }
    }

    /// <summary>
    /// Gets or sets the ADDRESS value.
    /// </summary>
    public string ADDRESS
    {
        get { return _ADDRESS; }
        set { _ADDRESS = value; }
    }

    /// <summary>
    /// Gets or sets the TELEPHONE1 value.
    /// </summary>
    public string TELEPHONE1
    {
        get { return _TELEPHONE1; }
        set { _TELEPHONE1 = value; }
    }

    /// <summary>
    /// Gets or sets the TELEPHONE2 value.
    /// </summary>
    public string TELEPHONE2
    {
        get { return _TELEPHONE2; }
        set { _TELEPHONE2 = value; }
    }

    /// <summary>
    /// Gets or sets the FAX value.
    /// </summary>
    public string FAX
    {
        get { return _FAX; }
        set { _FAX = value; }
    }

    /// <summary>
    /// Gets or sets the TELEPHONEPOLICE value.
    /// </summary>
    public string TELEPHONEPOLICE
    {
        get { return _TELEPHONEPOLICE; }
        set { _TELEPHONEPOLICE = value; }
    }

    /// <summary>
    /// Gets or sets the TELEPHONEFIRE value.
    /// </summary>
    public string TELEPHONEFIRE
    {
        get { return _TELEPHONEFIRE; }
        set { _TELEPHONEFIRE = value; }
    }

    /// <summary>
    /// Gets or sets the NOTES value.
    /// </summary>
    public string NOTES
    {
        get { return _NOTES; }
        set { _NOTES = value; }
    }

    /// <summary>
    /// Gets or sets the HAVEKEYS value.
    /// </summary>
    public bool? HAVEKEYS
    {
        get { return _HAVEKEYS; }
        set { _HAVEKEYS = value; }
    }

    /// <summary>
    /// Gets or sets the LOGO value.
    /// </summary>
    public string LOGO
    {
        get { return _LOGO; }
        set { _LOGO = value; }
    }

    /// <summary>
    /// Gets or sets the ISVIDEOVERIFICATION value.
    /// </summary>
    public bool? ISVIDEOVERIFICATION
    {
        get { return _ISVIDEOVERIFICATION; }
        set { _ISVIDEOVERIFICATION = value; }
    }

    /// <summary>
    /// Gets or sets the FILESTOREID value.
    /// </summary>
    public int? FILESTOREID
    {
        get { return _FILESTOREID; }
        set { _FILESTOREID = value; }
    }

    /// <summary>
    /// Gets or sets the TIMEZONEID value.
    /// </summary>
    public int? TIMEZONEID
    {
        get { return _TIMEZONEID; }
        set { _TIMEZONEID = value; }
    }

    /// <summary>
    /// Gets or sets the LICENSETYPEID value.
    /// </summary>
    public int? LICENSETYPEID
    {
        get { return _LICENSETYPEID; }
        set { _LICENSETYPEID = value; }
    }

    /// <summary>
    /// Gets or sets the BRANDINGID value.
    /// </summary>
    public int? BRANDINGID
    {
        get { return _BRANDINGID; }
        set { _BRANDINGID = value; }
    }

    /// <summary>
    /// Gets or sets the MOBILEAPPENABLED value.
    /// </summary>
    public bool? MOBILEAPPENABLED
    {
        get { return _MOBILEAPPENABLED; }
        set { _MOBILEAPPENABLED = value; }
    }


    #endregion

    #region Default Constructors

    /// <summary>
    /// Initializes a new instance of the clsGroups class with default value.
    /// </summary>
    public clsGroups()
    {


    }

    #endregion

    #region Primary Constructors

    /// <summary>
    /// Initializes a new instance of the clsGroups class based on Primary Key.
    /// </summary>
    public clsGroups(decimal pk_Group_Id)
    {
        DataTable dtGroups = SelectByPK(pk_Group_Id).Tables[0];

        if (dtGroups.Rows.Count == 1)
        {
            SetValue(dtGroups.Rows[0]);

        }

    }


    /// <summary>
    /// Initializes a new instance of the clsGroups class based on Datarow passed.
    /// </summary>
    private void SetValue(DataRow drGroups)
    {
        if (drGroups["Pk_Group_Id"] == DBNull.Value)
            this._Pk_Group_Id = null;
        else
            this._Pk_Group_Id = (decimal?)drGroups["Pk_Group_Id"];

        if (drGroups["GROUPID"] == DBNull.Value)
            this._GROUPID = null;
        else
            this._GROUPID = (decimal?)drGroups["GROUPID"];

        if (drGroups["PARENTGROUPID"] == DBNull.Value)
            this._PARENTGROUPID = null;
        else
            this._PARENTGROUPID = (decimal?)drGroups["PARENTGROUPID"];

        if (drGroups["GROUPTYPEID"] == DBNull.Value)
            this._GROUPTYPEID = null;
        else
            this._GROUPTYPEID = (int?)drGroups["GROUPTYPEID"];

        if (drGroups["TITLE"] == DBNull.Value)
            this._TITLE = null;
        else
            this._TITLE = (string)drGroups["TITLE"];

        if (drGroups["ARMED"] == DBNull.Value)
            this._ARMED = null;
        else
            this._ARMED = (bool?)drGroups["ARMED"];

        if (drGroups["TOGGLEARMAT"] == DBNull.Value)
            this._TOGGLEARMAT = null;
        else
            this._TOGGLEARMAT = (DateTime?)drGroups["TOGGLEARMAT"];

        if (drGroups["DISARMREASONID"] == DBNull.Value)
            this._DISARMREASONID = null;
        else
            this._DISARMREASONID = (int?)drGroups["DISARMREASONID"];

        if (drGroups["DISABLEDAT"] == DBNull.Value)
            this._DISABLEDAT = null;
        else
            this._DISABLEDAT = (DateTime?)drGroups["DISABLEDAT"];

        if (drGroups["TIMEZONEOFFSET"] == DBNull.Value)
            this._TIMEZONEOFFSET = null;
        else
            this._TIMEZONEOFFSET = (decimal?)drGroups["TIMEZONEOFFSET"];

        if (drGroups["DAYLIGHTSAVINGS"] == DBNull.Value)
            this._DAYLIGHTSAVINGS = null;
        else
            this._DAYLIGHTSAVINGS = (bool?)drGroups["DAYLIGHTSAVINGS"];

        if (drGroups["ULTYPE"] == DBNull.Value)
            this._ULTYPE = null;
        else
            this._ULTYPE = (int?)drGroups["ULTYPE"];

        if (drGroups["ISACTIVE"] == DBNull.Value)
            this._ISACTIVE = null;
        else
            this._ISACTIVE = (bool?)drGroups["ISACTIVE"];

        if (drGroups["ISSECURELINE"] == DBNull.Value)
            this._ISSECURELINE = null;
        else
            this._ISSECURELINE = (bool?)drGroups["ISSECURELINE"];

        if (drGroups["ISENCRYPTED"] == DBNull.Value)
            this._ISENCRYPTED = null;
        else
            this._ISENCRYPTED = (bool?)drGroups["ISENCRYPTED"];

        if (drGroups["ONTEST"] == DBNull.Value)
            this._ONTEST = null;
        else
            this._ONTEST = (bool?)drGroups["ONTEST"];

        if (drGroups["MAINTAINERID"] == DBNull.Value)
            this._MAINTAINERID = null;
        else
            this._MAINTAINERID = (int?)drGroups["MAINTAINERID"];

        if (drGroups["RESPONSETIME"] == DBNull.Value)
            this._RESPONSETIME = null;
        else
            this._RESPONSETIME = (int?)drGroups["RESPONSETIME"];

        if (drGroups["GROUPREMOTETYPEID"] == DBNull.Value)
            this._GROUPREMOTETYPEID = null;
        else
            this._GROUPREMOTETYPEID = (int?)drGroups["GROUPREMOTETYPEID"];

        if (drGroups["REMOTEACCOUNT"] == DBNull.Value)
            this._REMOTEACCOUNT = null;
        else
            this._REMOTEACCOUNT = (string)drGroups["REMOTEACCOUNT"];

        if (drGroups["SCRIPTID"] == DBNull.Value)
            this._SCRIPTID = null;
        else
            this._SCRIPTID = (int?)drGroups["SCRIPTID"];

        if (drGroups["ADDRESS"] == DBNull.Value)
            this._ADDRESS = null;
        else
            this._ADDRESS = (string)drGroups["ADDRESS"];

        if (drGroups["TELEPHONE1"] == DBNull.Value)
            this._TELEPHONE1 = null;
        else
            this._TELEPHONE1 = (string)drGroups["TELEPHONE1"];

        if (drGroups["TELEPHONE2"] == DBNull.Value)
            this._TELEPHONE2 = null;
        else
            this._TELEPHONE2 = (string)drGroups["TELEPHONE2"];

        if (drGroups["FAX"] == DBNull.Value)
            this._FAX = null;
        else
            this._FAX = (string)drGroups["FAX"];

        if (drGroups["TELEPHONEPOLICE"] == DBNull.Value)
            this._TELEPHONEPOLICE = null;
        else
            this._TELEPHONEPOLICE = (string)drGroups["TELEPHONEPOLICE"];

        if (drGroups["TELEPHONEFIRE"] == DBNull.Value)
            this._TELEPHONEFIRE = null;
        else
            this._TELEPHONEFIRE = (string)drGroups["TELEPHONEFIRE"];

        if (drGroups["NOTES"] == DBNull.Value)
            this._NOTES = null;
        else
            this._NOTES = (string)drGroups["NOTES"];

        if (drGroups["HAVEKEYS"] == DBNull.Value)
            this._HAVEKEYS = null;
        else
            this._HAVEKEYS = (bool?)drGroups["HAVEKEYS"];

        if (drGroups["LOGO"] == DBNull.Value)
            this._LOGO = null;
        else
            this._LOGO = (string)drGroups["LOGO"];

        if (drGroups["ISVIDEOVERIFICATION"] == DBNull.Value)
            this._ISVIDEOVERIFICATION = null;
        else
            this._ISVIDEOVERIFICATION = (bool?)drGroups["ISVIDEOVERIFICATION"];

        if (drGroups["FILESTOREID"] == DBNull.Value)
            this._FILESTOREID = null;
        else
            this._FILESTOREID = (int?)drGroups["FILESTOREID"];

        if (drGroups["TIMEZONEID"] == DBNull.Value)
            this._TIMEZONEID = null;
        else
            this._TIMEZONEID = (int?)drGroups["TIMEZONEID"];

        if (drGroups["LICENSETYPEID"] == DBNull.Value)
            this._LICENSETYPEID = null;
        else
            this._LICENSETYPEID = (int?)drGroups["LICENSETYPEID"];

        if (drGroups["BRANDINGID"] == DBNull.Value)
            this._BRANDINGID = null;
        else
            this._BRANDINGID = (int?)drGroups["BRANDINGID"];

        if (drGroups["MOBILEAPPENABLED"] == DBNull.Value)
            this._MOBILEAPPENABLED = null;
        else
            this._MOBILEAPPENABLED = (bool?)drGroups["MOBILEAPPENABLED"];


    }

    #endregion

    /// <summary>
    /// Inserts a record into the Groups table.
    /// </summary>
    /// <returns></returns>
    public int Insert()
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("GroupsInsert");


        db.AddInParameter(dbCommand, "GROUPID", DbType.Decimal, this._GROUPID);

        db.AddInParameter(dbCommand, "PARENTGROUPID", DbType.Decimal, this._PARENTGROUPID);

        db.AddInParameter(dbCommand, "GROUPTYPEID", DbType.Int32, this._GROUPTYPEID);

        if (string.IsNullOrEmpty(this._TITLE))
            db.AddInParameter(dbCommand, "TITLE", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "TITLE", DbType.String, this._TITLE);

        db.AddInParameter(dbCommand, "ARMED", DbType.Boolean, this._ARMED);

        db.AddInParameter(dbCommand, "TOGGLEARMAT", DbType.DateTime, this._TOGGLEARMAT);

        db.AddInParameter(dbCommand, "DISARMREASONID", DbType.Int32, this._DISARMREASONID);

        db.AddInParameter(dbCommand, "DISABLEDAT", DbType.DateTime, this._DISABLEDAT);

        db.AddInParameter(dbCommand, "TIMEZONEOFFSET", DbType.Decimal, this._TIMEZONEOFFSET);

        db.AddInParameter(dbCommand, "DAYLIGHTSAVINGS", DbType.Boolean, this._DAYLIGHTSAVINGS);

        db.AddInParameter(dbCommand, "ULTYPE", DbType.Int32, this._ULTYPE);

        db.AddInParameter(dbCommand, "ISACTIVE", DbType.Boolean, this._ISACTIVE);

        db.AddInParameter(dbCommand, "ISSECURELINE", DbType.Boolean, this._ISSECURELINE);

        db.AddInParameter(dbCommand, "ISENCRYPTED", DbType.Boolean, this._ISENCRYPTED);

        db.AddInParameter(dbCommand, "ONTEST", DbType.Boolean, this._ONTEST);

        db.AddInParameter(dbCommand, "MAINTAINERID", DbType.Int32, this._MAINTAINERID);

        db.AddInParameter(dbCommand, "RESPONSETIME", DbType.Int32, this._RESPONSETIME);

        db.AddInParameter(dbCommand, "GROUPREMOTETYPEID", DbType.Int32, this._GROUPREMOTETYPEID);

        if (string.IsNullOrEmpty(this._REMOTEACCOUNT))
            db.AddInParameter(dbCommand, "REMOTEACCOUNT", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "REMOTEACCOUNT", DbType.String, this._REMOTEACCOUNT);

        db.AddInParameter(dbCommand, "SCRIPTID", DbType.Int32, this._SCRIPTID);

        if (string.IsNullOrEmpty(this._ADDRESS))
            db.AddInParameter(dbCommand, "ADDRESS", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "ADDRESS", DbType.String, this._ADDRESS);

        if (string.IsNullOrEmpty(this._TELEPHONE1))
            db.AddInParameter(dbCommand, "TELEPHONE1", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "TELEPHONE1", DbType.String, this._TELEPHONE1);

        if (string.IsNullOrEmpty(this._TELEPHONE2))
            db.AddInParameter(dbCommand, "TELEPHONE2", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "TELEPHONE2", DbType.String, this._TELEPHONE2);

        if (string.IsNullOrEmpty(this._FAX))
            db.AddInParameter(dbCommand, "FAX", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "FAX", DbType.String, this._FAX);

        if (string.IsNullOrEmpty(this._TELEPHONEPOLICE))
            db.AddInParameter(dbCommand, "TELEPHONEPOLICE", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "TELEPHONEPOLICE", DbType.String, this._TELEPHONEPOLICE);

        if (string.IsNullOrEmpty(this._TELEPHONEFIRE))
            db.AddInParameter(dbCommand, "TELEPHONEFIRE", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "TELEPHONEFIRE", DbType.String, this._TELEPHONEFIRE);

        if (string.IsNullOrEmpty(this._NOTES))
            db.AddInParameter(dbCommand, "NOTES", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "NOTES", DbType.String, this._NOTES);

        db.AddInParameter(dbCommand, "HAVEKEYS", DbType.Boolean, this._HAVEKEYS);

        if (string.IsNullOrEmpty(this._LOGO))
            db.AddInParameter(dbCommand, "LOGO", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "LOGO", DbType.String, this._LOGO);

        db.AddInParameter(dbCommand, "ISVIDEOVERIFICATION", DbType.Boolean, this._ISVIDEOVERIFICATION);

        db.AddInParameter(dbCommand, "FILESTOREID", DbType.Int32, this._FILESTOREID);

        db.AddInParameter(dbCommand, "TIMEZONEID", DbType.Int32, this._TIMEZONEID);

        db.AddInParameter(dbCommand, "LICENSETYPEID", DbType.Int32, this._LICENSETYPEID);

        db.AddInParameter(dbCommand, "BRANDINGID", DbType.Int32, this._BRANDINGID);

        db.AddInParameter(dbCommand, "MOBILEAPPENABLED", DbType.Boolean, this._MOBILEAPPENABLED);

        // Execute the query and return the new identity value
        int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

        return returnValue;
    }

    /// <summary>
    /// Selects a single record from the Groups table by a primary key.
    /// </summary>
    /// <returns>DataSet</returns>
    private DataSet SelectByPK(decimal pk_Group_Id)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("GroupsSelectByPK");

        db.AddInParameter(dbCommand, "Pk_Group_Id", DbType.Decimal, pk_Group_Id);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// Selects all records from the Groups table.
    /// </summary>
    /// <returns>DataSet</returns>
    public static DataSet SelectAll()
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("GroupsSelectAll");

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// Updates a record in the Groups table.
    /// </summary>
    public void Update()
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("GroupsUpdate");


        db.AddInParameter(dbCommand, "Pk_Group_Id", DbType.Decimal, this._Pk_Group_Id);

        db.AddInParameter(dbCommand, "GROUPID", DbType.Decimal, this._GROUPID);

        db.AddInParameter(dbCommand, "PARENTGROUPID", DbType.Decimal, this._PARENTGROUPID);

        db.AddInParameter(dbCommand, "GROUPTYPEID", DbType.Int32, this._GROUPTYPEID);

        if (string.IsNullOrEmpty(this._TITLE))
            db.AddInParameter(dbCommand, "TITLE", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "TITLE", DbType.String, this._TITLE);

        db.AddInParameter(dbCommand, "ARMED", DbType.Boolean, this._ARMED);

        db.AddInParameter(dbCommand, "TOGGLEARMAT", DbType.DateTime, this._TOGGLEARMAT);

        db.AddInParameter(dbCommand, "DISARMREASONID", DbType.Int32, this._DISARMREASONID);

        db.AddInParameter(dbCommand, "DISABLEDAT", DbType.DateTime, this._DISABLEDAT);

        db.AddInParameter(dbCommand, "TIMEZONEOFFSET", DbType.Decimal, this._TIMEZONEOFFSET);

        db.AddInParameter(dbCommand, "DAYLIGHTSAVINGS", DbType.Boolean, this._DAYLIGHTSAVINGS);

        db.AddInParameter(dbCommand, "ULTYPE", DbType.Int32, this._ULTYPE);

        db.AddInParameter(dbCommand, "ISACTIVE", DbType.Boolean, this._ISACTIVE);

        db.AddInParameter(dbCommand, "ISSECURELINE", DbType.Boolean, this._ISSECURELINE);

        db.AddInParameter(dbCommand, "ISENCRYPTED", DbType.Boolean, this._ISENCRYPTED);

        db.AddInParameter(dbCommand, "ONTEST", DbType.Boolean, this._ONTEST);

        db.AddInParameter(dbCommand, "MAINTAINERID", DbType.Int32, this._MAINTAINERID);

        db.AddInParameter(dbCommand, "RESPONSETIME", DbType.Int32, this._RESPONSETIME);

        db.AddInParameter(dbCommand, "GROUPREMOTETYPEID", DbType.Int32, this._GROUPREMOTETYPEID);

        if (string.IsNullOrEmpty(this._REMOTEACCOUNT))
            db.AddInParameter(dbCommand, "REMOTEACCOUNT", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "REMOTEACCOUNT", DbType.String, this._REMOTEACCOUNT);

        db.AddInParameter(dbCommand, "SCRIPTID", DbType.Int32, this._SCRIPTID);

        if (string.IsNullOrEmpty(this._ADDRESS))
            db.AddInParameter(dbCommand, "ADDRESS", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "ADDRESS", DbType.String, this._ADDRESS);

        if (string.IsNullOrEmpty(this._TELEPHONE1))
            db.AddInParameter(dbCommand, "TELEPHONE1", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "TELEPHONE1", DbType.String, this._TELEPHONE1);

        if (string.IsNullOrEmpty(this._TELEPHONE2))
            db.AddInParameter(dbCommand, "TELEPHONE2", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "TELEPHONE2", DbType.String, this._TELEPHONE2);

        if (string.IsNullOrEmpty(this._FAX))
            db.AddInParameter(dbCommand, "FAX", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "FAX", DbType.String, this._FAX);

        if (string.IsNullOrEmpty(this._TELEPHONEPOLICE))
            db.AddInParameter(dbCommand, "TELEPHONEPOLICE", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "TELEPHONEPOLICE", DbType.String, this._TELEPHONEPOLICE);

        if (string.IsNullOrEmpty(this._TELEPHONEFIRE))
            db.AddInParameter(dbCommand, "TELEPHONEFIRE", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "TELEPHONEFIRE", DbType.String, this._TELEPHONEFIRE);

        if (string.IsNullOrEmpty(this._NOTES))
            db.AddInParameter(dbCommand, "NOTES", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "NOTES", DbType.String, this._NOTES);

        db.AddInParameter(dbCommand, "HAVEKEYS", DbType.Boolean, this._HAVEKEYS);

        if (string.IsNullOrEmpty(this._LOGO))
            db.AddInParameter(dbCommand, "LOGO", DbType.String, DBNull.Value);
        else
            db.AddInParameter(dbCommand, "LOGO", DbType.String, this._LOGO);

        db.AddInParameter(dbCommand, "ISVIDEOVERIFICATION", DbType.Boolean, this._ISVIDEOVERIFICATION);

        db.AddInParameter(dbCommand, "FILESTOREID", DbType.Int32, this._FILESTOREID);

        db.AddInParameter(dbCommand, "TIMEZONEID", DbType.Int32, this._TIMEZONEID);

        db.AddInParameter(dbCommand, "LICENSETYPEID", DbType.Int32, this._LICENSETYPEID);

        db.AddInParameter(dbCommand, "BRANDINGID", DbType.Int32, this._BRANDINGID);

        db.AddInParameter(dbCommand, "MOBILEAPPENABLED", DbType.Boolean, this._MOBILEAPPENABLED);

        db.ExecuteNonQuery(dbCommand);
    }

    /// <summary>
    /// Deletes a record from the Groups table by a composite primary key.
    /// </summary>
    public static void DeleteByPK(decimal pk_Group_Id)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("GroupsDeleteByPK");

        db.AddInParameter(dbCommand, "Pk_Group_Id", DbType.Decimal, pk_Group_Id);

        db.ExecuteNonQuery(dbCommand);
    }
}