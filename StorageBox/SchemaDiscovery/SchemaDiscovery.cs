using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AppSimplicity.ActiveRecord;
using AppSimplicity.ActiveRecord.DataAccess;
using AppSimplicity.ActiveRecord.QueryBuilder;
using AppSimplicity.ActiveRecord.Mapping;
using Newtonsoft.Json;


///Entities definitions:
namespace StorageBox.Entities 
{

    [Serializable]
    public partial class Account : IActiveRecord, IAuditable, IDeactivable
	{
	
		/// <summary>
		/// Id
		/// </summary>
	    public int Id { get; set; }
	
		/// <summary>
		/// Name
		/// </summary>
	    public string Name { get; set; }
	
		/// <summary>
		/// Password
		/// </summary>
	    public string Password { get; set; }
	
		/// <summary>
		/// Application_Id
		/// </summary>
	    public int Application_Id { get; set; }
	
		/// <summary>
		/// CreatedOn
		/// </summary>
	    public DateTime ? CreatedOn { get; set; }
	
		/// <summary>
		/// CreatedBy
		/// </summary>
	    public string CreatedBy { get; set; }
	
		/// <summary>
		/// ModifiedOn
		/// </summary>
	    public DateTime ? ModifiedOn { get; set; }
	
		/// <summary>
		/// ModifiedBy
		/// </summary>
	    public string ModifiedBy { get; set; }
	
		/// <summary>
		/// Active
		/// </summary>
	    public bool Active { get; set; }
	
		/// <summary>
		/// DeactivatedOn
		/// </summary>
	    public DateTime ? DeactivatedOn { get; set; }
	
		/// <summary>
		/// DeactivatedBy
		/// </summary>
	    public string DeactivatedBy { get; set; }
	
		/// <summary>
		/// LastAuthenticationOn
		/// </summary>
	    public DateTime ? LastAuthenticationOn { get; set; }
	
		/// <summary>
		/// Blocked
		/// </summary>
	    public bool Blocked { get; set; }
	
		/// <summary>
		/// BlockedOn
		/// </summary>
	    public DateTime ? BlockedOn { get; set; }
	
		/// <summary>
		/// AuthenticationRetries
		/// </summary>
	    public int ? AuthenticationRetries { get; set; }
			

		#region Navigation Properties

        private Application _Application = null;
        /// <summary>
        /// Navigation property for the Application relationship
        /// </summary>
		[XmlIgnoreAttribute, JsonIgnore]		
        public Application Application 
        {
            get 
            {
                if (_Application == null)
                {
					_Application = DataAccess.Applications.FetchById(Application_Id);
                    
                }
                return _Application;
            }
            set 
            {
                _Application = value;
            }
        }
		#endregion
		
		
	}


    [Serializable]
    public partial class AccountReportDetail : Account
	{

					
		public bool Selected { get; set; }

        public string DT_RowId
        {
            get
            {
                return string.Format("{0}Row_{1}", "account", Id);
            }
        }
	}


    [Serializable]
    public partial class Application : IActiveRecord
	{
	
		/// <summary>
		/// Id
		/// </summary>
	    public int Id { get; set; }
	
		/// <summary>
		/// Name
		/// </summary>
	    public string Name { get; set; }
	
		/// <summary>
		/// ApplicationKey
		/// </summary>
	    public string ApplicationKey { get; set; }
			

		#region Navigation Properties
		#endregion
		
		
	}


    [Serializable]
    public partial class ApplicationReportDetail : Application
	{

					
		public bool Selected { get; set; }

        public string DT_RowId
        {
            get
            {
                return string.Format("{0}Row_{1}", "application", Id);
            }
        }
	}


    [Serializable]
    public partial class MimeType : IActiveRecord
	{
	
		/// <summary>
		/// Id
		/// </summary>
	    public int Id { get; set; }
	
		/// <summary>
		/// Extension
		/// </summary>
	    public string Extension { get; set; }
	
		/// <summary>
		/// MediaType
		/// </summary>
	    public string MediaType { get; set; }
			

		#region Navigation Properties
		#endregion
		
		
	}


    [Serializable]
    public partial class MimeTypeReportDetail : MimeType
	{

					
		public bool Selected { get; set; }

        public string DT_RowId
        {
            get
            {
                return string.Format("{0}Row_{1}", "mimetype", Id);
            }
        }
	}


    [Serializable]
    public partial class Session : IActiveRecord
	{
	
		/// <summary>
		/// Id
		/// </summary>
	    public int Id { get; set; }
	
		/// <summary>
		/// Account_Id
		/// </summary>
	    public int Account_Id { get; set; }
	
		/// <summary>
		/// SessionUUID
		/// </summary>
	    public string SessionUUID { get; set; }
	
		/// <summary>
		/// StartedOn
		/// </summary>
	    public DateTime ? StartedOn { get; set; }
	
		/// <summary>
		/// Enabled
		/// </summary>
	    public bool Enabled { get; set; }
	
		/// <summary>
		/// Device
		/// </summary>
	    public string Device { get; set; }
			

		#region Navigation Properties

        private Account _Account = null;
        /// <summary>
        /// Navigation property for the Account relationship
        /// </summary>
		[XmlIgnoreAttribute, JsonIgnore]		
        public Account Account 
        {
            get 
            {
                if (_Account == null)
                {
					_Account = DataAccess.Accounts.FetchById(Account_Id);
                    
                }
                return _Account;
            }
            set 
            {
                _Account = value;
            }
        }
		#endregion
		
		
	}


    [Serializable]
    public partial class SessionReportDetail : Session
	{

					
		public bool Selected { get; set; }

        public string DT_RowId
        {
            get
            {
                return string.Format("{0}Row_{1}", "session", Id);
            }
        }
	}


    [Serializable]
    public partial class StorageFile : IActiveRecord
	{
	
		/// <summary>
		/// Id
		/// </summary>
	    public int Id { get; set; }
	
		/// <summary>
		/// FileUUID
		/// </summary>
	    public string FileUUID { get; set; }
	
		/// <summary>
		/// FileName
		/// </summary>
	    public string FileName { get; set; }
	
		/// <summary>
		/// UploadedOn
		/// </summary>
	    public DateTime ? UploadedOn { get; set; }
	
		/// <summary>
		/// Extension
		/// </summary>
	    public string Extension { get; set; }
	
		/// <summary>
		/// StoragePath
		/// </summary>
	    public string StoragePath { get; set; }
	
		/// <summary>
		/// FileSize
		/// </summary>
	    public int FileSize { get; set; }
	
		/// <summary>
		/// Session_Id
		/// </summary>
	    public int Session_Id { get; set; }
			

		#region Navigation Properties

        private Session _Session = null;
        /// <summary>
        /// Navigation property for the Session relationship
        /// </summary>
		[XmlIgnoreAttribute, JsonIgnore]		
        public Session Session 
        {
            get 
            {
                if (_Session == null)
                {
					_Session = DataAccess.Sessions.FetchById(Session_Id);
                    
                }
                return _Session;
            }
            set 
            {
                _Session = value;
            }
        }
		#endregion
		
		
	}


    [Serializable]
    public partial class StorageFileReportDetail : StorageFile
	{

					
		public bool Selected { get; set; }

        public string DT_RowId
        {
            get
            {
                return string.Format("{0}Row_{1}", "storagefile", Id);
            }
        }
	}


    [Serializable]
    public partial class SystemConfiguration : IActiveRecord
	{
	
		/// <summary>
		/// Id
		/// </summary>
	    public int Id { get; set; }
	
		/// <summary>
		/// ParameterName
		/// </summary>
	    public string ParameterName { get; set; }
	
		/// <summary>
		/// ParameterValue
		/// </summary>
	    public string ParameterValue { get; set; }
			

		#region Navigation Properties
		#endregion
		
		
	}


    [Serializable]
    public partial class SystemConfigurationReportDetail : SystemConfiguration
	{

					
		public bool Selected { get; set; }

        public string DT_RowId
        {
            get
            {
                return string.Format("{0}Row_{1}", "systemconfiguration", Id);
            }
        }
	}

}

///DataAccess implementations:
namespace StorageBox.DataAccess
{
	public class DataContext
    {
        public const string CONNECTION_NAME = "StorageBox";
    }

	
    

	internal partial class AccountPersister : EntityPersister<Entities.Account>
    {
        public AccountPersister() : base (DataContext.CONNECTION_NAME)
        {

        }
        
        protected override DbCommand GetInsertStatement(Entities.Account entity)
        {
            DbCommand command = CreateCommand(GetInsertStatement(Accounts.Schema), CommandType.Text);
			command.Parameters.Add(CreateParameter("Name", entity.Name));
			command.Parameters.Add(CreateParameter("Password", entity.Password));
			command.Parameters.Add(CreateParameter("Application_Id", entity.Application_Id));
			command.Parameters.Add(CreateParameter("CreatedOn", entity.CreatedOn));
			command.Parameters.Add(CreateParameter("CreatedBy", entity.CreatedBy));
			command.Parameters.Add(CreateParameter("ModifiedOn", entity.ModifiedOn));
			command.Parameters.Add(CreateParameter("ModifiedBy", entity.ModifiedBy));
			command.Parameters.Add(CreateParameter("Active", entity.Active));
			command.Parameters.Add(CreateParameter("DeactivatedOn", entity.DeactivatedOn));
			command.Parameters.Add(CreateParameter("DeactivatedBy", entity.DeactivatedBy));
			command.Parameters.Add(CreateParameter("LastAuthenticationOn", entity.LastAuthenticationOn));
			command.Parameters.Add(CreateParameter("Blocked", entity.Blocked));
			command.Parameters.Add(CreateParameter("BlockedOn", entity.BlockedOn));
			command.Parameters.Add(CreateParameter("AuthenticationRetries", entity.AuthenticationRetries));
            return command;
        }

        protected override DbCommand GetDeleteStatement(int Id)
        {
            DbCommand command = CreateCommand(GetDeleteStatement(Accounts.Schema), CommandType.Text);
            command.Parameters.Add(CreateParameter("Id", Id));
            return command;
        }

        protected override DbCommand GetUpdateStatement(Entities.Account entity)
        {
            DbCommand command = CreateCommand(GetUpdateStatement(Accounts.Schema), CommandType.Text);
			command.Parameters.Add(CreateParameter("Id", entity.Id));
			command.Parameters.Add(CreateParameter("Name", entity.Name));
			command.Parameters.Add(CreateParameter("Password", entity.Password));
			command.Parameters.Add(CreateParameter("Application_Id", entity.Application_Id));
			command.Parameters.Add(CreateParameter("CreatedOn", entity.CreatedOn));
			command.Parameters.Add(CreateParameter("CreatedBy", entity.CreatedBy));
			command.Parameters.Add(CreateParameter("ModifiedOn", entity.ModifiedOn));
			command.Parameters.Add(CreateParameter("ModifiedBy", entity.ModifiedBy));
			command.Parameters.Add(CreateParameter("Active", entity.Active));
			command.Parameters.Add(CreateParameter("DeactivatedOn", entity.DeactivatedOn));
			command.Parameters.Add(CreateParameter("DeactivatedBy", entity.DeactivatedBy));
			command.Parameters.Add(CreateParameter("LastAuthenticationOn", entity.LastAuthenticationOn));
			command.Parameters.Add(CreateParameter("Blocked", entity.Blocked));
			command.Parameters.Add(CreateParameter("BlockedOn", entity.BlockedOn));
			command.Parameters.Add(CreateParameter("AuthenticationRetries", entity.AuthenticationRetries));
            return command;
        }        
	}

    internal partial class AccountDataController : AppSimplicity.ActiveRecord.DataAccess.BaseEntityDataController<Entities.Account>
    {
		#region DataValidations
		protected override void RunDataValidations(Entities.Account entity, AppSimplicity.ActiveRecord.Validation.ValidationSummary summary)
        {
			if (string.IsNullOrEmpty(entity.Name))
			{
				summary.AddErrorDetail("Name", string.Format(AppSimplicity.ActiveRecord.Messages.REQUIRED_FIELD, StorageBox.Resources.Entities.ACCOUNT_NAME_DISPLAYNAME));
			}

			if (string.IsNullOrEmpty(entity.Password))
			{
				summary.AddErrorDetail("Password", string.Format(AppSimplicity.ActiveRecord.Messages.REQUIRED_FIELD, StorageBox.Resources.Entities.ACCOUNT_PASSWORD_DISPLAYNAME));
			}

        }
		#endregion

        #region ctor
        public AccountDataController()
            : base(new AccountPersister())
        {

        }
        #endregion
    }
    

    #region Factory 
    public partial class AccountFactory : BaseEntityFactory<Entities.Account>
    {
		partial void PopulateEntity(ref Entities.Account entity, DbDataReader reader);

        protected override Entities.Account LoadEntity(DbDataReader reader)
        {
            Entities.Account Entity = new Entities.Account()
            {
                Id = Map.ToInt32(reader["Id"]),
                Name = Map.ToStringValue(reader["Name"]),
                Password = Map.ToStringValue(reader["Password"]),
                Application_Id = Map.ToInt32(reader["Application_Id"]),
                CreatedOn = Map.ToDateTime(reader["CreatedOn"]),
                CreatedBy = Map.ToStringValue(reader["CreatedBy"]),
                ModifiedOn = Map.ToDateTimeNullable(reader["ModifiedOn"]),
                ModifiedBy = Map.ToStringValue(reader["ModifiedBy"]),
                Active = Map.ToBoolean(reader["Active"]),
                DeactivatedOn = Map.ToDateTimeNullable(reader["DeactivatedOn"]),
                DeactivatedBy = Map.ToStringValue(reader["DeactivatedBy"]),
                LastAuthenticationOn = Map.ToDateTimeNullable(reader["LastAuthenticationOn"]),
                Blocked = Map.ToBoolean(reader["Blocked"]),
                BlockedOn = Map.ToDateTimeNullable(reader["BlockedOn"]),
                AuthenticationRetries = Map.ToInt32Nullable(reader["AuthenticationRetries"])
            };

			PopulateEntity(ref Entity, reader);

            return Entity;
        }

        public AccountFactory()
            : base(DataContext.CONNECTION_NAME)
        {

        }
    }
    #endregion
	
    #region Report Detail Factory
    public partial class AccountReportDetailFactory : BaseEntityFactory<Entities.AccountReportDetail>
    {
		partial void PopulateEntity(ref Entities.AccountReportDetail entity, DbDataReader reader);

        protected override Entities.AccountReportDetail LoadEntity(DbDataReader reader)
        {
            Entities.AccountReportDetail Entity = new Entities.AccountReportDetail()
            {
                Id = Map.ToInt32(reader["Id"]),
                Name = Map.ToStringValue(reader["Name"]),
                Password = Map.ToStringValue(reader["Password"]),
                Application_Id = Map.ToInt32(reader["Application_Id"]),
                CreatedOn = Map.ToDateTime(reader["CreatedOn"]),
                CreatedBy = Map.ToStringValue(reader["CreatedBy"]),
                ModifiedOn = Map.ToDateTimeNullable(reader["ModifiedOn"]),
                ModifiedBy = Map.ToStringValue(reader["ModifiedBy"]),
                Active = Map.ToBoolean(reader["Active"]),
                DeactivatedOn = Map.ToDateTimeNullable(reader["DeactivatedOn"]),
                DeactivatedBy = Map.ToStringValue(reader["DeactivatedBy"]),
                LastAuthenticationOn = Map.ToDateTimeNullable(reader["LastAuthenticationOn"]),
                Blocked = Map.ToBoolean(reader["Blocked"]),
                BlockedOn = Map.ToDateTimeNullable(reader["BlockedOn"]),
                AuthenticationRetries = Map.ToInt32Nullable(reader["AuthenticationRetries"])
            };

			PopulateEntity(ref Entity, reader);

            return Entity;
        }

        public AccountReportDetailFactory()
            : base(DataContext.CONNECTION_NAME)
        {

        }
    }
    #endregion		

	internal partial class AccountsSchema
	{

#region Column Enumeration
		public enum Columns 
        {
            Id = 0, 
            Name = 1, 
            Password = 2, 
            Application_Id = 3, 
            CreatedOn = 4, 
            CreatedBy = 5, 
            ModifiedOn = 6, 
            ModifiedBy = 7, 
            Active = 8, 
            DeactivatedOn = 9, 
            DeactivatedBy = 10, 
            LastAuthenticationOn = 11, 
            Blocked = 12, 
            BlockedOn = 13, 
            AuthenticationRetries = 14
        }
#endregion	

		
	}

	#region QueryBuilder
	internal class AccountQueryBuilder : GenericBaseQueryBuilder<StorageBox.Entities.Account>
    {
        /// <summary>
        /// Executes the corresponding sql command and returns a single instance of Account that matches the criteria.
        /// </summary>
        /// <returns></returns>
        public override Entities.Account FetchSingle()
        {
            AccountFactory factory = new AccountFactory();
            return factory.FetchSingle(GetSqlCommand());
        }

        /// <summary>
        /// Executes the corresponding sql command and returns a list of Account that matches the criteria.
        /// </summary>
        /// <returns></returns>
        public override List<Entities.Account> FetchList()
        {
            return FetchFirst(0);
        }

        /// <summary>
        /// Executes the corresponding sql command and returns a list of Account that matches the criteria and returns the first records coming in the query.
        /// </summary>
        /// <param name="limit">Determines the number of records to be returned from database.</param>
        /// <returns></returns>
        public override List<Entities.Account> FetchFirst(int limit)
        {
            AccountFactory factory = new AccountFactory();
            return factory.FetchList(GetSqlCommand(limit));
        }

        public AccountQueryBuilder()
            : base(DataContext.CONNECTION_NAME, Accounts.GetSchema())
        {

        }

        /// <summary>
        /// Adds a condition to the query statement.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public CriteriaBuilder Where(AccountsSchema.Columns column)
        {
            return base.Where(Schema.Columns[(int)column]);
        }

		/// <summary>
        /// Determines a condition for sorting when returning the list of entities.
        /// </summary>
        /// <param name="column"></param>
        public void SortBy(AccountsSchema.Columns column)
        {
            base.AddSortCondition(Schema.Columns[(int)column], SortDirection.Ascending);
        }

        /// <summary>
        /// Determines condition and direction for sorting when returning the list of entities.
        /// </summary>
        /// <param name="column"></param>
        public void SortBy(AccountsSchema.Columns column, SortDirection direction)
        {
            base.AddSortCondition(Schema.Columns[(int)column], direction);
        }
    }
	#endregion
	
    public partial class Accounts
    {	
		/// <summary>
        /// This method returns an instance that maps the schema 
        /// </summary>
        /// <returns></returns>
        public static Schema GetSchema()
        {
            Schema schema = new Schema()
            {
                SchemaName = "dbo",
                TableName = "Account"
            };

            //Adding the list of columns:
            schema.AddColumn("Id", DbType.Int32, true);
            schema.AddColumn("Name", DbType.String, false);
            schema.AddColumn("Password", DbType.String, false);
            schema.AddColumn("Application_Id", DbType.Int32, false);
            schema.AddColumn("CreatedOn", DbType.DateTime, false);
            schema.AddColumn("CreatedBy", DbType.String, false);
            schema.AddColumn("ModifiedOn", DbType.DateTime, false);
            schema.AddColumn("ModifiedBy", DbType.String, false);
            schema.AddColumn("Active", DbType.Boolean, false);
            schema.AddColumn("DeactivatedOn", DbType.DateTime, false);
            schema.AddColumn("DeactivatedBy", DbType.String, false);
            schema.AddColumn("LastAuthenticationOn", DbType.DateTime, false);
            schema.AddColumn("Blocked", DbType.Boolean, false);
            schema.AddColumn("BlockedOn", DbType.DateTime, false);
            schema.AddColumn("AuthenticationRetries", DbType.Int32, false);

            //Adding the list of indexes:


            return schema;
        }

		
		private static Schema _Schema;
		public static Schema Schema
		{
			get
			{
				if(_Schema == null)
				{
					_Schema = Accounts.GetSchema();
				}
				return _Schema;
			}
		}

		/// <summary>
        /// Creates a record in the mapped data table [dbo].[Account]
        /// </summary>
        /// <param name="entity">A populated entity of Account</param>
        public static void Create(Entities.Account entity)
        {
            AccountDataController db = new AccountDataController();
            db.Create(entity);
        }

		/// <summary>
        /// Updates a record in the mapped data table [dbo].[Account]
        /// </summary>
        /// <param name="entity">A populated entity of Account</param>
        public static void Update(Entities.Account entity)
        {
            AccountDataController db = new AccountDataController();
            db.Update(entity);
        }

		/// <summary>
        /// Deletes a record in the mapped data table [dbo].[Account]
        /// </summary>
        /// <param name="entity">A populated entity of Account</param>
        public static void Delete(Entities.Account entity)
        {
            AccountDataController db = new AccountDataController();
            db.Delete(entity);
        }

		/// <summary>
        /// Persists the information of an entity to the data table [dbo].[Account]
        /// </summary>
        /// <param name="entity">A populated entity of Account</param>
		public static void Save(Entities.Account entity)
        {
            AccountDataController db = new AccountDataController();
            db.Save(entity);
        }

		/// <summary>
        /// Retrieves a record from the mapped data table [dbo].[Account] using a given Id.
        /// </summary>
        /// <param name="id">The id value</param>
        public static Entities.Account FetchById(int id)
        {
            AccountQueryBuilder query = new AccountQueryBuilder();
            query.Where(AccountsSchema.Columns.Id).IsEqualTo(id);
            return query.FetchSingle();
        }


		/// <summary>
        /// Returns a list of Account by a given Application_Id
        /// </summary>                
        public static List<StorageBox.Entities.Account> GetByApplication(int Application_Id, bool includeActiveOnly = true)
        {
            StorageBox.DataAccess.AccountQueryBuilder query = new AccountQueryBuilder();
            query.Where(AccountsSchema.Columns.Application_Id).IsEqualTo(Application_Id);

            if (includeActiveOnly)
            {
                query.Where(AccountsSchema.Columns.Active).IsEqualTo(true);
            }
            
            return query.FetchList();
        }

 

		/// <summary>
        /// Retrieves a list of records from the mapped data table [dbo].[Account].
        /// </summary>
        /// <param name="includeInactive">Determines if inactive records should be included in the list</param>
	    public static List<Entities.Account> FetchAll(bool includeInactive = false)
        {
            AccountQueryBuilder query = new AccountQueryBuilder();
            if (!includeInactive)
            {
                query.Where(AccountsSchema.Columns.Active).IsEqualTo(true);
            }
            return query.FetchList();
        }		
        /// <summary>
        /// Retrieves a report from the [Account] table.
        /// </summary>
        /// <param name="settings">Sets the filter settings for running the report</param>
        /// <returns></returns>
        public static List<Entities.AccountReportDetail> GetReport(AccountFilterSettings settings = null)
        {
			if (settings == null)
            {
                settings = new AccountFilterSettings();
            }

            AccountReportDetailFactory factory = new AccountReportDetailFactory();
            return factory.FetchList("[dbo].[cgp_Account_GetReport]", settings.GetParameters());
        }

 		

    }

	public partial class AccountFilterSettings : AppSimplicity.ActiveRecord.DataAccess.BaseEntityFilterSettings
    {
        public string SearchText { get; set; }

		public int Application_Id { get; set; }
            

        protected override void LoadParameters()
        {
            this.AddParameter("SearchText", string.IsNullOrEmpty(SearchText) ? null : SearchText.Contains('%') ? SearchText : string.Format ("%{0}%", SearchText));
            this.AddParameter("Application_Id", Application_Id);
        }

        public AccountFilterSettings() : base(DataContext.CONNECTION_NAME) { }
    }

	
    

	internal partial class ApplicationPersister : EntityPersister<Entities.Application>
    {
        public ApplicationPersister() : base (DataContext.CONNECTION_NAME)
        {

        }
        
        protected override DbCommand GetInsertStatement(Entities.Application entity)
        {
            DbCommand command = CreateCommand(GetInsertStatement(Applications.Schema), CommandType.Text);
			command.Parameters.Add(CreateParameter("Name", entity.Name));
			command.Parameters.Add(CreateParameter("ApplicationKey", entity.ApplicationKey));
            return command;
        }

        protected override DbCommand GetDeleteStatement(int Id)
        {
            DbCommand command = CreateCommand(GetDeleteStatement(Applications.Schema), CommandType.Text);
            command.Parameters.Add(CreateParameter("Id", Id));
            return command;
        }

        protected override DbCommand GetUpdateStatement(Entities.Application entity)
        {
            DbCommand command = CreateCommand(GetUpdateStatement(Applications.Schema), CommandType.Text);
			command.Parameters.Add(CreateParameter("Id", entity.Id));
			command.Parameters.Add(CreateParameter("Name", entity.Name));
			command.Parameters.Add(CreateParameter("ApplicationKey", entity.ApplicationKey));
            return command;
        }        
	}

    internal partial class ApplicationDataController : AppSimplicity.ActiveRecord.DataAccess.BaseEntityDataController<Entities.Application>
    {
		#region DataValidations
		protected override void RunDataValidations(Entities.Application entity, AppSimplicity.ActiveRecord.Validation.ValidationSummary summary)
        {
			if (string.IsNullOrEmpty(entity.Name))
			{
				summary.AddErrorDetail("Name", string.Format(AppSimplicity.ActiveRecord.Messages.REQUIRED_FIELD, StorageBox.Resources.Entities.APPLICATION_NAME_DISPLAYNAME));
			}

			if (string.IsNullOrEmpty(entity.ApplicationKey))
			{
				summary.AddErrorDetail("ApplicationKey", string.Format(AppSimplicity.ActiveRecord.Messages.REQUIRED_FIELD, StorageBox.Resources.Entities.APPLICATION_APPLICATIONKEY_DISPLAYNAME));
			}

        }
		#endregion

        #region ctor
        public ApplicationDataController()
            : base(new ApplicationPersister())
        {

        }
        #endregion
    }
    

    #region Factory 
    public partial class ApplicationFactory : BaseEntityFactory<Entities.Application>
    {
		partial void PopulateEntity(ref Entities.Application entity, DbDataReader reader);

        protected override Entities.Application LoadEntity(DbDataReader reader)
        {
            Entities.Application Entity = new Entities.Application()
            {
                Id = Map.ToInt32(reader["Id"]),
                Name = Map.ToStringValue(reader["Name"]),
                ApplicationKey = Map.ToStringValue(reader["ApplicationKey"])
            };

			PopulateEntity(ref Entity, reader);

            return Entity;
        }

        public ApplicationFactory()
            : base(DataContext.CONNECTION_NAME)
        {

        }
    }
    #endregion
	
    #region Report Detail Factory
    public partial class ApplicationReportDetailFactory : BaseEntityFactory<Entities.ApplicationReportDetail>
    {
		partial void PopulateEntity(ref Entities.ApplicationReportDetail entity, DbDataReader reader);

        protected override Entities.ApplicationReportDetail LoadEntity(DbDataReader reader)
        {
            Entities.ApplicationReportDetail Entity = new Entities.ApplicationReportDetail()
            {
                Id = Map.ToInt32(reader["Id"]),
                Name = Map.ToStringValue(reader["Name"]),
                ApplicationKey = Map.ToStringValue(reader["ApplicationKey"])
            };

			PopulateEntity(ref Entity, reader);

            return Entity;
        }

        public ApplicationReportDetailFactory()
            : base(DataContext.CONNECTION_NAME)
        {

        }
    }
    #endregion		

	internal partial class ApplicationsSchema
	{

#region Column Enumeration
		public enum Columns 
        {
            Id = 0, 
            Name = 1, 
            ApplicationKey = 2
        }
#endregion	

		
	}

	#region QueryBuilder
	internal class ApplicationQueryBuilder : GenericBaseQueryBuilder<StorageBox.Entities.Application>
    {
        /// <summary>
        /// Executes the corresponding sql command and returns a single instance of Application that matches the criteria.
        /// </summary>
        /// <returns></returns>
        public override Entities.Application FetchSingle()
        {
            ApplicationFactory factory = new ApplicationFactory();
            return factory.FetchSingle(GetSqlCommand());
        }

        /// <summary>
        /// Executes the corresponding sql command and returns a list of Application that matches the criteria.
        /// </summary>
        /// <returns></returns>
        public override List<Entities.Application> FetchList()
        {
            return FetchFirst(0);
        }

        /// <summary>
        /// Executes the corresponding sql command and returns a list of Application that matches the criteria and returns the first records coming in the query.
        /// </summary>
        /// <param name="limit">Determines the number of records to be returned from database.</param>
        /// <returns></returns>
        public override List<Entities.Application> FetchFirst(int limit)
        {
            ApplicationFactory factory = new ApplicationFactory();
            return factory.FetchList(GetSqlCommand(limit));
        }

        public ApplicationQueryBuilder()
            : base(DataContext.CONNECTION_NAME, Applications.GetSchema())
        {

        }

        /// <summary>
        /// Adds a condition to the query statement.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public CriteriaBuilder Where(ApplicationsSchema.Columns column)
        {
            return base.Where(Schema.Columns[(int)column]);
        }

		/// <summary>
        /// Determines a condition for sorting when returning the list of entities.
        /// </summary>
        /// <param name="column"></param>
        public void SortBy(ApplicationsSchema.Columns column)
        {
            base.AddSortCondition(Schema.Columns[(int)column], SortDirection.Ascending);
        }

        /// <summary>
        /// Determines condition and direction for sorting when returning the list of entities.
        /// </summary>
        /// <param name="column"></param>
        public void SortBy(ApplicationsSchema.Columns column, SortDirection direction)
        {
            base.AddSortCondition(Schema.Columns[(int)column], direction);
        }
    }
	#endregion
	
    public partial class Applications
    {	
		/// <summary>
        /// This method returns an instance that maps the schema 
        /// </summary>
        /// <returns></returns>
        public static Schema GetSchema()
        {
            Schema schema = new Schema()
            {
                SchemaName = "dbo",
                TableName = "Application"
            };

            //Adding the list of columns:
            schema.AddColumn("Id", DbType.Int32, true);
            schema.AddColumn("Name", DbType.String, false);
            schema.AddColumn("ApplicationKey", DbType.String, false);

            //Adding the list of indexes:


            return schema;
        }

		
		private static Schema _Schema;
		public static Schema Schema
		{
			get
			{
				if(_Schema == null)
				{
					_Schema = Applications.GetSchema();
				}
				return _Schema;
			}
		}

		/// <summary>
        /// Creates a record in the mapped data table [dbo].[Application]
        /// </summary>
        /// <param name="entity">A populated entity of Application</param>
        public static void Create(Entities.Application entity)
        {
            ApplicationDataController db = new ApplicationDataController();
            db.Create(entity);
        }

		/// <summary>
        /// Updates a record in the mapped data table [dbo].[Application]
        /// </summary>
        /// <param name="entity">A populated entity of Application</param>
        public static void Update(Entities.Application entity)
        {
            ApplicationDataController db = new ApplicationDataController();
            db.Update(entity);
        }

		/// <summary>
        /// Deletes a record in the mapped data table [dbo].[Application]
        /// </summary>
        /// <param name="entity">A populated entity of Application</param>
        public static void Delete(Entities.Application entity)
        {
            ApplicationDataController db = new ApplicationDataController();
            db.Delete(entity);
        }

		/// <summary>
        /// Persists the information of an entity to the data table [dbo].[Application]
        /// </summary>
        /// <param name="entity">A populated entity of Application</param>
		public static void Save(Entities.Application entity)
        {
            ApplicationDataController db = new ApplicationDataController();
            db.Save(entity);
        }

		/// <summary>
        /// Retrieves a record from the mapped data table [dbo].[Application] using a given Id.
        /// </summary>
        /// <param name="id">The id value</param>
        public static Entities.Application FetchById(int id)
        {
            ApplicationQueryBuilder query = new ApplicationQueryBuilder();
            query.Where(ApplicationsSchema.Columns.Id).IsEqualTo(id);
            return query.FetchSingle();
        }


 

		/// <summary>
        /// Retrieves a list of records from the mapped data table [dbo].[Application].
        /// </summary>        
        public static List<Entities.Application> FetchAll()
        {
            ApplicationQueryBuilder query = new ApplicationQueryBuilder();            
            return query.FetchList();
        }

        /// <summary>
        /// Retrieves a report from the [Application] table.
        /// </summary>
        /// <param name="settings">Sets the filter settings for running the report</param>
        /// <returns></returns>
        public static List<Entities.ApplicationReportDetail> GetReport(ApplicationFilterSettings settings = null)
        {
			if (settings == null)
            {
                settings = new ApplicationFilterSettings();
            }

            ApplicationReportDetailFactory factory = new ApplicationReportDetailFactory();
            return factory.FetchList("[dbo].[cgp_Application_GetReport]", settings.GetParameters());
        }

 		

    }

	public partial class ApplicationFilterSettings : AppSimplicity.ActiveRecord.DataAccess.BaseEntityFilterSettings
    {
        public string SearchText { get; set; }

            

        protected override void LoadParameters()
        {
            this.AddParameter("SearchText", string.IsNullOrEmpty(SearchText) ? null : SearchText.Contains('%') ? SearchText : string.Format ("%{0}%", SearchText));
        }

        public ApplicationFilterSettings() : base(DataContext.CONNECTION_NAME) { }
    }

	
    

	internal partial class MimeTypePersister : EntityPersister<Entities.MimeType>
    {
        public MimeTypePersister() : base (DataContext.CONNECTION_NAME)
        {

        }
        
        protected override DbCommand GetInsertStatement(Entities.MimeType entity)
        {
            DbCommand command = CreateCommand(GetInsertStatement(MimeTypes.Schema), CommandType.Text);
			command.Parameters.Add(CreateParameter("Extension", entity.Extension));
			command.Parameters.Add(CreateParameter("MediaType", entity.MediaType));
            return command;
        }

        protected override DbCommand GetDeleteStatement(int Id)
        {
            DbCommand command = CreateCommand(GetDeleteStatement(MimeTypes.Schema), CommandType.Text);
            command.Parameters.Add(CreateParameter("Id", Id));
            return command;
        }

        protected override DbCommand GetUpdateStatement(Entities.MimeType entity)
        {
            DbCommand command = CreateCommand(GetUpdateStatement(MimeTypes.Schema), CommandType.Text);
			command.Parameters.Add(CreateParameter("Id", entity.Id));
			command.Parameters.Add(CreateParameter("Extension", entity.Extension));
			command.Parameters.Add(CreateParameter("MediaType", entity.MediaType));
            return command;
        }        
	}

    internal partial class MimeTypeDataController : AppSimplicity.ActiveRecord.DataAccess.BaseEntityDataController<Entities.MimeType>
    {
		#region DataValidations
		protected override void RunDataValidations(Entities.MimeType entity, AppSimplicity.ActiveRecord.Validation.ValidationSummary summary)
        {
        }
		#endregion

        #region ctor
        public MimeTypeDataController()
            : base(new MimeTypePersister())
        {

        }
        #endregion
    }
    

    #region Factory 
    public partial class MimeTypeFactory : BaseEntityFactory<Entities.MimeType>
    {
		partial void PopulateEntity(ref Entities.MimeType entity, DbDataReader reader);

        protected override Entities.MimeType LoadEntity(DbDataReader reader)
        {
            Entities.MimeType Entity = new Entities.MimeType()
            {
                Id = Map.ToInt32(reader["Id"]),
                Extension = Map.ToStringValue(reader["Extension"]),
                MediaType = Map.ToStringValue(reader["MediaType"])
            };

			PopulateEntity(ref Entity, reader);

            return Entity;
        }

        public MimeTypeFactory()
            : base(DataContext.CONNECTION_NAME)
        {

        }
    }
    #endregion
	
    #region Report Detail Factory
    public partial class MimeTypeReportDetailFactory : BaseEntityFactory<Entities.MimeTypeReportDetail>
    {
		partial void PopulateEntity(ref Entities.MimeTypeReportDetail entity, DbDataReader reader);

        protected override Entities.MimeTypeReportDetail LoadEntity(DbDataReader reader)
        {
            Entities.MimeTypeReportDetail Entity = new Entities.MimeTypeReportDetail()
            {
                Id = Map.ToInt32(reader["Id"]),
                Extension = Map.ToStringValue(reader["Extension"]),
                MediaType = Map.ToStringValue(reader["MediaType"])
            };

			PopulateEntity(ref Entity, reader);

            return Entity;
        }

        public MimeTypeReportDetailFactory()
            : base(DataContext.CONNECTION_NAME)
        {

        }
    }
    #endregion		

	internal partial class MimeTypesSchema
	{

#region Column Enumeration
		public enum Columns 
        {
            Id = 0, 
            Extension = 1, 
            MediaType = 2
        }
#endregion	

		
	}

	#region QueryBuilder
	internal class MimeTypeQueryBuilder : GenericBaseQueryBuilder<StorageBox.Entities.MimeType>
    {
        /// <summary>
        /// Executes the corresponding sql command and returns a single instance of MimeType that matches the criteria.
        /// </summary>
        /// <returns></returns>
        public override Entities.MimeType FetchSingle()
        {
            MimeTypeFactory factory = new MimeTypeFactory();
            return factory.FetchSingle(GetSqlCommand());
        }

        /// <summary>
        /// Executes the corresponding sql command and returns a list of MimeType that matches the criteria.
        /// </summary>
        /// <returns></returns>
        public override List<Entities.MimeType> FetchList()
        {
            return FetchFirst(0);
        }

        /// <summary>
        /// Executes the corresponding sql command and returns a list of MimeType that matches the criteria and returns the first records coming in the query.
        /// </summary>
        /// <param name="limit">Determines the number of records to be returned from database.</param>
        /// <returns></returns>
        public override List<Entities.MimeType> FetchFirst(int limit)
        {
            MimeTypeFactory factory = new MimeTypeFactory();
            return factory.FetchList(GetSqlCommand(limit));
        }

        public MimeTypeQueryBuilder()
            : base(DataContext.CONNECTION_NAME, MimeTypes.GetSchema())
        {

        }

        /// <summary>
        /// Adds a condition to the query statement.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public CriteriaBuilder Where(MimeTypesSchema.Columns column)
        {
            return base.Where(Schema.Columns[(int)column]);
        }

		/// <summary>
        /// Determines a condition for sorting when returning the list of entities.
        /// </summary>
        /// <param name="column"></param>
        public void SortBy(MimeTypesSchema.Columns column)
        {
            base.AddSortCondition(Schema.Columns[(int)column], SortDirection.Ascending);
        }

        /// <summary>
        /// Determines condition and direction for sorting when returning the list of entities.
        /// </summary>
        /// <param name="column"></param>
        public void SortBy(MimeTypesSchema.Columns column, SortDirection direction)
        {
            base.AddSortCondition(Schema.Columns[(int)column], direction);
        }
    }
	#endregion
	
    public partial class MimeTypes
    {	
		/// <summary>
        /// This method returns an instance that maps the schema 
        /// </summary>
        /// <returns></returns>
        public static Schema GetSchema()
        {
            Schema schema = new Schema()
            {
                SchemaName = "dbo",
                TableName = "MimeType"
            };

            //Adding the list of columns:
            schema.AddColumn("Id", DbType.Int32, true);
            schema.AddColumn("Extension", DbType.String, false);
            schema.AddColumn("MediaType", DbType.String, false);

            //Adding the list of indexes:


            return schema;
        }

		
		private static Schema _Schema;
		public static Schema Schema
		{
			get
			{
				if(_Schema == null)
				{
					_Schema = MimeTypes.GetSchema();
				}
				return _Schema;
			}
		}

		/// <summary>
        /// Creates a record in the mapped data table [dbo].[MimeType]
        /// </summary>
        /// <param name="entity">A populated entity of MimeType</param>
        public static void Create(Entities.MimeType entity)
        {
            MimeTypeDataController db = new MimeTypeDataController();
            db.Create(entity);
        }

		/// <summary>
        /// Updates a record in the mapped data table [dbo].[MimeType]
        /// </summary>
        /// <param name="entity">A populated entity of MimeType</param>
        public static void Update(Entities.MimeType entity)
        {
            MimeTypeDataController db = new MimeTypeDataController();
            db.Update(entity);
        }

		/// <summary>
        /// Deletes a record in the mapped data table [dbo].[MimeType]
        /// </summary>
        /// <param name="entity">A populated entity of MimeType</param>
        public static void Delete(Entities.MimeType entity)
        {
            MimeTypeDataController db = new MimeTypeDataController();
            db.Delete(entity);
        }

		/// <summary>
        /// Persists the information of an entity to the data table [dbo].[MimeType]
        /// </summary>
        /// <param name="entity">A populated entity of MimeType</param>
		public static void Save(Entities.MimeType entity)
        {
            MimeTypeDataController db = new MimeTypeDataController();
            db.Save(entity);
        }

		/// <summary>
        /// Retrieves a record from the mapped data table [dbo].[MimeType] using a given Id.
        /// </summary>
        /// <param name="id">The id value</param>
        public static Entities.MimeType FetchById(int id)
        {
            MimeTypeQueryBuilder query = new MimeTypeQueryBuilder();
            query.Where(MimeTypesSchema.Columns.Id).IsEqualTo(id);
            return query.FetchSingle();
        }


 

		/// <summary>
        /// Retrieves a list of records from the mapped data table [dbo].[MimeType].
        /// </summary>        
        public static List<Entities.MimeType> FetchAll()
        {
            MimeTypeQueryBuilder query = new MimeTypeQueryBuilder();            
            return query.FetchList();
        }

        /// <summary>
        /// Retrieves a report from the [MimeType] table.
        /// </summary>
        /// <param name="settings">Sets the filter settings for running the report</param>
        /// <returns></returns>
        public static List<Entities.MimeTypeReportDetail> GetReport(MimeTypeFilterSettings settings = null)
        {
			if (settings == null)
            {
                settings = new MimeTypeFilterSettings();
            }

            MimeTypeReportDetailFactory factory = new MimeTypeReportDetailFactory();
            return factory.FetchList("[dbo].[cgp_MimeType_GetReport]", settings.GetParameters());
        }

 		

    }

	public partial class MimeTypeFilterSettings : AppSimplicity.ActiveRecord.DataAccess.BaseEntityFilterSettings
    {
        

            

        protected override void LoadParameters()
        {
            
        }

        public MimeTypeFilterSettings() : base(DataContext.CONNECTION_NAME) { }
    }

	
    

	internal partial class SessionPersister : EntityPersister<Entities.Session>
    {
        public SessionPersister() : base (DataContext.CONNECTION_NAME)
        {

        }
        
        protected override DbCommand GetInsertStatement(Entities.Session entity)
        {
            DbCommand command = CreateCommand(GetInsertStatement(Sessions.Schema), CommandType.Text);
			command.Parameters.Add(CreateParameter("Account_Id", entity.Account_Id));
			command.Parameters.Add(CreateParameter("SessionUUID", entity.SessionUUID));
			command.Parameters.Add(CreateParameter("StartedOn", entity.StartedOn));
			command.Parameters.Add(CreateParameter("Enabled", entity.Enabled));
			command.Parameters.Add(CreateParameter("Device", entity.Device));
            return command;
        }

        protected override DbCommand GetDeleteStatement(int Id)
        {
            DbCommand command = CreateCommand(GetDeleteStatement(Sessions.Schema), CommandType.Text);
            command.Parameters.Add(CreateParameter("Id", Id));
            return command;
        }

        protected override DbCommand GetUpdateStatement(Entities.Session entity)
        {
            DbCommand command = CreateCommand(GetUpdateStatement(Sessions.Schema), CommandType.Text);
			command.Parameters.Add(CreateParameter("Id", entity.Id));
			command.Parameters.Add(CreateParameter("Account_Id", entity.Account_Id));
			command.Parameters.Add(CreateParameter("SessionUUID", entity.SessionUUID));
			command.Parameters.Add(CreateParameter("StartedOn", entity.StartedOn));
			command.Parameters.Add(CreateParameter("Enabled", entity.Enabled));
			command.Parameters.Add(CreateParameter("Device", entity.Device));
            return command;
        }        
	}

    internal partial class SessionDataController : AppSimplicity.ActiveRecord.DataAccess.BaseEntityDataController<Entities.Session>
    {
		#region DataValidations
		protected override void RunDataValidations(Entities.Session entity, AppSimplicity.ActiveRecord.Validation.ValidationSummary summary)
        {
			if (string.IsNullOrEmpty(entity.SessionUUID))
			{
				summary.AddErrorDetail("SessionUUID", string.Format(AppSimplicity.ActiveRecord.Messages.REQUIRED_FIELD, StorageBox.Resources.Entities.SESSION_SESSIONUUID_DISPLAYNAME));
			}

			if (!entity.StartedOn.HasValue)
			{
				summary.AddErrorDetail("StartedOn", string.Format(AppSimplicity.ActiveRecord.Messages.REQUIRED_FIELD, StorageBox.Resources.Entities.SESSION_STARTEDON_DISPLAYNAME));
			}
        }
		#endregion

        #region ctor
        public SessionDataController()
            : base(new SessionPersister())
        {

        }
        #endregion
    }
    

    #region Factory 
    public partial class SessionFactory : BaseEntityFactory<Entities.Session>
    {
		partial void PopulateEntity(ref Entities.Session entity, DbDataReader reader);

        protected override Entities.Session LoadEntity(DbDataReader reader)
        {
            Entities.Session Entity = new Entities.Session()
            {
                Id = Map.ToInt32(reader["Id"]),
                Account_Id = Map.ToInt32(reader["Account_Id"]),
                SessionUUID = Map.ToStringValue(reader["SessionUUID"]),
                StartedOn = Map.ToDateTime(reader["StartedOn"]),
                Enabled = Map.ToBoolean(reader["Enabled"]),
                Device = Map.ToStringValue(reader["Device"])
            };

			PopulateEntity(ref Entity, reader);

            return Entity;
        }

        public SessionFactory()
            : base(DataContext.CONNECTION_NAME)
        {

        }
    }
    #endregion
	
    #region Report Detail Factory
    public partial class SessionReportDetailFactory : BaseEntityFactory<Entities.SessionReportDetail>
    {
		partial void PopulateEntity(ref Entities.SessionReportDetail entity, DbDataReader reader);

        protected override Entities.SessionReportDetail LoadEntity(DbDataReader reader)
        {
            Entities.SessionReportDetail Entity = new Entities.SessionReportDetail()
            {
                Id = Map.ToInt32(reader["Id"]),
                Account_Id = Map.ToInt32(reader["Account_Id"]),
                SessionUUID = Map.ToStringValue(reader["SessionUUID"]),
                StartedOn = Map.ToDateTime(reader["StartedOn"]),
                Enabled = Map.ToBoolean(reader["Enabled"]),
                Device = Map.ToStringValue(reader["Device"])
            };

			PopulateEntity(ref Entity, reader);

            return Entity;
        }

        public SessionReportDetailFactory()
            : base(DataContext.CONNECTION_NAME)
        {

        }
    }
    #endregion		

	internal partial class SessionsSchema
	{

#region Column Enumeration
		public enum Columns 
        {
            Id = 0, 
            Account_Id = 1, 
            SessionUUID = 2, 
            StartedOn = 3, 
            Enabled = 4, 
            Device = 5
        }
#endregion	

		
	}

	#region QueryBuilder
	internal class SessionQueryBuilder : GenericBaseQueryBuilder<StorageBox.Entities.Session>
    {
        /// <summary>
        /// Executes the corresponding sql command and returns a single instance of Session that matches the criteria.
        /// </summary>
        /// <returns></returns>
        public override Entities.Session FetchSingle()
        {
            SessionFactory factory = new SessionFactory();
            return factory.FetchSingle(GetSqlCommand());
        }

        /// <summary>
        /// Executes the corresponding sql command and returns a list of Session that matches the criteria.
        /// </summary>
        /// <returns></returns>
        public override List<Entities.Session> FetchList()
        {
            return FetchFirst(0);
        }

        /// <summary>
        /// Executes the corresponding sql command and returns a list of Session that matches the criteria and returns the first records coming in the query.
        /// </summary>
        /// <param name="limit">Determines the number of records to be returned from database.</param>
        /// <returns></returns>
        public override List<Entities.Session> FetchFirst(int limit)
        {
            SessionFactory factory = new SessionFactory();
            return factory.FetchList(GetSqlCommand(limit));
        }

        public SessionQueryBuilder()
            : base(DataContext.CONNECTION_NAME, Sessions.GetSchema())
        {

        }

        /// <summary>
        /// Adds a condition to the query statement.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public CriteriaBuilder Where(SessionsSchema.Columns column)
        {
            return base.Where(Schema.Columns[(int)column]);
        }

		/// <summary>
        /// Determines a condition for sorting when returning the list of entities.
        /// </summary>
        /// <param name="column"></param>
        public void SortBy(SessionsSchema.Columns column)
        {
            base.AddSortCondition(Schema.Columns[(int)column], SortDirection.Ascending);
        }

        /// <summary>
        /// Determines condition and direction for sorting when returning the list of entities.
        /// </summary>
        /// <param name="column"></param>
        public void SortBy(SessionsSchema.Columns column, SortDirection direction)
        {
            base.AddSortCondition(Schema.Columns[(int)column], direction);
        }
    }
	#endregion
	
    public partial class Sessions
    {	
		/// <summary>
        /// This method returns an instance that maps the schema 
        /// </summary>
        /// <returns></returns>
        public static Schema GetSchema()
        {
            Schema schema = new Schema()
            {
                SchemaName = "dbo",
                TableName = "Session"
            };

            //Adding the list of columns:
            schema.AddColumn("Id", DbType.Int32, true);
            schema.AddColumn("Account_Id", DbType.Int32, false);
            schema.AddColumn("SessionUUID", DbType.String, false);
            schema.AddColumn("StartedOn", DbType.DateTime, false);
            schema.AddColumn("Enabled", DbType.Boolean, false);
            schema.AddColumn("Device", DbType.String, false);

            //Adding the list of indexes:


            return schema;
        }

		
		private static Schema _Schema;
		public static Schema Schema
		{
			get
			{
				if(_Schema == null)
				{
					_Schema = Sessions.GetSchema();
				}
				return _Schema;
			}
		}

		/// <summary>
        /// Creates a record in the mapped data table [dbo].[Session]
        /// </summary>
        /// <param name="entity">A populated entity of Session</param>
        public static void Create(Entities.Session entity)
        {
            SessionDataController db = new SessionDataController();
            db.Create(entity);
        }

		/// <summary>
        /// Updates a record in the mapped data table [dbo].[Session]
        /// </summary>
        /// <param name="entity">A populated entity of Session</param>
        public static void Update(Entities.Session entity)
        {
            SessionDataController db = new SessionDataController();
            db.Update(entity);
        }

		/// <summary>
        /// Deletes a record in the mapped data table [dbo].[Session]
        /// </summary>
        /// <param name="entity">A populated entity of Session</param>
        public static void Delete(Entities.Session entity)
        {
            SessionDataController db = new SessionDataController();
            db.Delete(entity);
        }

		/// <summary>
        /// Persists the information of an entity to the data table [dbo].[Session]
        /// </summary>
        /// <param name="entity">A populated entity of Session</param>
		public static void Save(Entities.Session entity)
        {
            SessionDataController db = new SessionDataController();
            db.Save(entity);
        }

		/// <summary>
        /// Retrieves a record from the mapped data table [dbo].[Session] using a given Id.
        /// </summary>
        /// <param name="id">The id value</param>
        public static Entities.Session FetchById(int id)
        {
            SessionQueryBuilder query = new SessionQueryBuilder();
            query.Where(SessionsSchema.Columns.Id).IsEqualTo(id);
            return query.FetchSingle();
        }


		/// <summary>
        /// Returns a list of Session by a given Account_Id
        /// </summary>                
        public static List<StorageBox.Entities.Session> GetByAccount(int Account_Id)
        {
            StorageBox.DataAccess.SessionQueryBuilder query = new SessionQueryBuilder();
            query.Where(SessionsSchema.Columns.Account_Id).IsEqualTo(Account_Id);

            
            return query.FetchList();
        }

 

		/// <summary>
        /// Retrieves a list of records from the mapped data table [dbo].[Session].
        /// </summary>        
        public static List<Entities.Session> FetchAll()
        {
            SessionQueryBuilder query = new SessionQueryBuilder();            
            return query.FetchList();
        }

        /// <summary>
        /// Retrieves a report from the [Session] table.
        /// </summary>
        /// <param name="settings">Sets the filter settings for running the report</param>
        /// <returns></returns>
        public static List<Entities.SessionReportDetail> GetReport(SessionFilterSettings settings = null)
        {
			if (settings == null)
            {
                settings = new SessionFilterSettings();
            }

            SessionReportDetailFactory factory = new SessionReportDetailFactory();
            return factory.FetchList("[dbo].[cgp_Session_GetReport]", settings.GetParameters());
        }

 		

    }

	public partial class SessionFilterSettings : AppSimplicity.ActiveRecord.DataAccess.BaseEntityFilterSettings
    {
        

		public int Account_Id { get; set; }
            

        protected override void LoadParameters()
        {
            
            this.AddParameter("Account_Id", Account_Id);
        }

        public SessionFilterSettings() : base(DataContext.CONNECTION_NAME) { }
    }

	
    

	internal partial class StorageFilePersister : EntityPersister<Entities.StorageFile>
    {
        public StorageFilePersister() : base (DataContext.CONNECTION_NAME)
        {

        }
        
        protected override DbCommand GetInsertStatement(Entities.StorageFile entity)
        {
            DbCommand command = CreateCommand(GetInsertStatement(StorageFiles.Schema), CommandType.Text);
			command.Parameters.Add(CreateParameter("FileUUID", entity.FileUUID));
			command.Parameters.Add(CreateParameter("FileName", entity.FileName));
			command.Parameters.Add(CreateParameter("UploadedOn", entity.UploadedOn));
			command.Parameters.Add(CreateParameter("Extension", entity.Extension));
			command.Parameters.Add(CreateParameter("StoragePath", entity.StoragePath));
			command.Parameters.Add(CreateParameter("FileSize", entity.FileSize));
			command.Parameters.Add(CreateParameter("Session_Id", entity.Session_Id));
            return command;
        }

        protected override DbCommand GetDeleteStatement(int Id)
        {
            DbCommand command = CreateCommand(GetDeleteStatement(StorageFiles.Schema), CommandType.Text);
            command.Parameters.Add(CreateParameter("Id", Id));
            return command;
        }

        protected override DbCommand GetUpdateStatement(Entities.StorageFile entity)
        {
            DbCommand command = CreateCommand(GetUpdateStatement(StorageFiles.Schema), CommandType.Text);
			command.Parameters.Add(CreateParameter("Id", entity.Id));
			command.Parameters.Add(CreateParameter("FileUUID", entity.FileUUID));
			command.Parameters.Add(CreateParameter("FileName", entity.FileName));
			command.Parameters.Add(CreateParameter("UploadedOn", entity.UploadedOn));
			command.Parameters.Add(CreateParameter("Extension", entity.Extension));
			command.Parameters.Add(CreateParameter("StoragePath", entity.StoragePath));
			command.Parameters.Add(CreateParameter("FileSize", entity.FileSize));
			command.Parameters.Add(CreateParameter("Session_Id", entity.Session_Id));
            return command;
        }        
	}

    internal partial class StorageFileDataController : AppSimplicity.ActiveRecord.DataAccess.BaseEntityDataController<Entities.StorageFile>
    {
		#region DataValidations
		protected override void RunDataValidations(Entities.StorageFile entity, AppSimplicity.ActiveRecord.Validation.ValidationSummary summary)
        {
			if (string.IsNullOrEmpty(entity.FileUUID))
			{
				summary.AddErrorDetail("FileUUID", string.Format(AppSimplicity.ActiveRecord.Messages.REQUIRED_FIELD, StorageBox.Resources.Entities.STORAGEFILE_FILEUUID_DISPLAYNAME));
			}

			if (string.IsNullOrEmpty(entity.FileName))
			{
				summary.AddErrorDetail("FileName", string.Format(AppSimplicity.ActiveRecord.Messages.REQUIRED_FIELD, StorageBox.Resources.Entities.STORAGEFILE_FILENAME_DISPLAYNAME));
			}

			if (!entity.UploadedOn.HasValue)
			{
				summary.AddErrorDetail("UploadedOn", string.Format(AppSimplicity.ActiveRecord.Messages.REQUIRED_FIELD, StorageBox.Resources.Entities.STORAGEFILE_UPLOADEDON_DISPLAYNAME));
			}
			if (string.IsNullOrEmpty(entity.Extension))
			{
				summary.AddErrorDetail("Extension", string.Format(AppSimplicity.ActiveRecord.Messages.REQUIRED_FIELD, StorageBox.Resources.Entities.STORAGEFILE_EXTENSION_DISPLAYNAME));
			}

			if (string.IsNullOrEmpty(entity.StoragePath))
			{
				summary.AddErrorDetail("StoragePath", string.Format(AppSimplicity.ActiveRecord.Messages.REQUIRED_FIELD, StorageBox.Resources.Entities.STORAGEFILE_STORAGEPATH_DISPLAYNAME));
			}

        }
		#endregion

        #region ctor
        public StorageFileDataController()
            : base(new StorageFilePersister())
        {

        }
        #endregion
    }
    

    #region Factory 
    public partial class StorageFileFactory : BaseEntityFactory<Entities.StorageFile>
    {
		partial void PopulateEntity(ref Entities.StorageFile entity, DbDataReader reader);

        protected override Entities.StorageFile LoadEntity(DbDataReader reader)
        {
            Entities.StorageFile Entity = new Entities.StorageFile()
            {
                Id = Map.ToInt32(reader["Id"]),
                FileUUID = Map.ToStringValue(reader["FileUUID"]),
                FileName = Map.ToStringValue(reader["FileName"]),
                UploadedOn = Map.ToDateTime(reader["UploadedOn"]),
                Extension = Map.ToStringValue(reader["Extension"]),
                StoragePath = Map.ToStringValue(reader["StoragePath"]),
                FileSize = Map.ToInt32(reader["FileSize"]),
                Session_Id = Map.ToInt32(reader["Session_Id"])
            };

			PopulateEntity(ref Entity, reader);

            return Entity;
        }

        public StorageFileFactory()
            : base(DataContext.CONNECTION_NAME)
        {

        }
    }
    #endregion
	
    #region Report Detail Factory
    public partial class StorageFileReportDetailFactory : BaseEntityFactory<Entities.StorageFileReportDetail>
    {
		partial void PopulateEntity(ref Entities.StorageFileReportDetail entity, DbDataReader reader);

        protected override Entities.StorageFileReportDetail LoadEntity(DbDataReader reader)
        {
            Entities.StorageFileReportDetail Entity = new Entities.StorageFileReportDetail()
            {
                Id = Map.ToInt32(reader["Id"]),
                FileUUID = Map.ToStringValue(reader["FileUUID"]),
                FileName = Map.ToStringValue(reader["FileName"]),
                UploadedOn = Map.ToDateTime(reader["UploadedOn"]),
                Extension = Map.ToStringValue(reader["Extension"]),
                StoragePath = Map.ToStringValue(reader["StoragePath"]),
                FileSize = Map.ToInt32(reader["FileSize"]),
                Session_Id = Map.ToInt32(reader["Session_Id"])
            };

			PopulateEntity(ref Entity, reader);

            return Entity;
        }

        public StorageFileReportDetailFactory()
            : base(DataContext.CONNECTION_NAME)
        {

        }
    }
    #endregion		

	internal partial class StorageFilesSchema
	{

#region Column Enumeration
		public enum Columns 
        {
            Id = 0, 
            FileUUID = 1, 
            FileName = 2, 
            UploadedOn = 3, 
            Extension = 4, 
            StoragePath = 5, 
            FileSize = 6, 
            Session_Id = 7
        }
#endregion	

		
	}

	#region QueryBuilder
	internal class StorageFileQueryBuilder : GenericBaseQueryBuilder<StorageBox.Entities.StorageFile>
    {
        /// <summary>
        /// Executes the corresponding sql command and returns a single instance of StorageFile that matches the criteria.
        /// </summary>
        /// <returns></returns>
        public override Entities.StorageFile FetchSingle()
        {
            StorageFileFactory factory = new StorageFileFactory();
            return factory.FetchSingle(GetSqlCommand());
        }

        /// <summary>
        /// Executes the corresponding sql command and returns a list of StorageFile that matches the criteria.
        /// </summary>
        /// <returns></returns>
        public override List<Entities.StorageFile> FetchList()
        {
            return FetchFirst(0);
        }

        /// <summary>
        /// Executes the corresponding sql command and returns a list of StorageFile that matches the criteria and returns the first records coming in the query.
        /// </summary>
        /// <param name="limit">Determines the number of records to be returned from database.</param>
        /// <returns></returns>
        public override List<Entities.StorageFile> FetchFirst(int limit)
        {
            StorageFileFactory factory = new StorageFileFactory();
            return factory.FetchList(GetSqlCommand(limit));
        }

        public StorageFileQueryBuilder()
            : base(DataContext.CONNECTION_NAME, StorageFiles.GetSchema())
        {

        }

        /// <summary>
        /// Adds a condition to the query statement.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public CriteriaBuilder Where(StorageFilesSchema.Columns column)
        {
            return base.Where(Schema.Columns[(int)column]);
        }

		/// <summary>
        /// Determines a condition for sorting when returning the list of entities.
        /// </summary>
        /// <param name="column"></param>
        public void SortBy(StorageFilesSchema.Columns column)
        {
            base.AddSortCondition(Schema.Columns[(int)column], SortDirection.Ascending);
        }

        /// <summary>
        /// Determines condition and direction for sorting when returning the list of entities.
        /// </summary>
        /// <param name="column"></param>
        public void SortBy(StorageFilesSchema.Columns column, SortDirection direction)
        {
            base.AddSortCondition(Schema.Columns[(int)column], direction);
        }
    }
	#endregion
	
    public partial class StorageFiles
    {	
		/// <summary>
        /// This method returns an instance that maps the schema 
        /// </summary>
        /// <returns></returns>
        public static Schema GetSchema()
        {
            Schema schema = new Schema()
            {
                SchemaName = "dbo",
                TableName = "StorageFile"
            };

            //Adding the list of columns:
            schema.AddColumn("Id", DbType.Int32, true);
            schema.AddColumn("FileUUID", DbType.String, false);
            schema.AddColumn("FileName", DbType.String, false);
            schema.AddColumn("UploadedOn", DbType.DateTime, false);
            schema.AddColumn("Extension", DbType.String, false);
            schema.AddColumn("StoragePath", DbType.String, false);
            schema.AddColumn("FileSize", DbType.Int32, false);
            schema.AddColumn("Session_Id", DbType.Int32, false);

            //Adding the list of indexes:


            return schema;
        }

		
		private static Schema _Schema;
		public static Schema Schema
		{
			get
			{
				if(_Schema == null)
				{
					_Schema = StorageFiles.GetSchema();
				}
				return _Schema;
			}
		}

		/// <summary>
        /// Creates a record in the mapped data table [dbo].[StorageFile]
        /// </summary>
        /// <param name="entity">A populated entity of StorageFile</param>
        public static void Create(Entities.StorageFile entity)
        {
            StorageFileDataController db = new StorageFileDataController();
            db.Create(entity);
        }

		/// <summary>
        /// Updates a record in the mapped data table [dbo].[StorageFile]
        /// </summary>
        /// <param name="entity">A populated entity of StorageFile</param>
        public static void Update(Entities.StorageFile entity)
        {
            StorageFileDataController db = new StorageFileDataController();
            db.Update(entity);
        }

		/// <summary>
        /// Deletes a record in the mapped data table [dbo].[StorageFile]
        /// </summary>
        /// <param name="entity">A populated entity of StorageFile</param>
        public static void Delete(Entities.StorageFile entity)
        {
            StorageFileDataController db = new StorageFileDataController();
            db.Delete(entity);
        }

		/// <summary>
        /// Persists the information of an entity to the data table [dbo].[StorageFile]
        /// </summary>
        /// <param name="entity">A populated entity of StorageFile</param>
		public static void Save(Entities.StorageFile entity)
        {
            StorageFileDataController db = new StorageFileDataController();
            db.Save(entity);
        }

		/// <summary>
        /// Retrieves a record from the mapped data table [dbo].[StorageFile] using a given Id.
        /// </summary>
        /// <param name="id">The id value</param>
        public static Entities.StorageFile FetchById(int id)
        {
            StorageFileQueryBuilder query = new StorageFileQueryBuilder();
            query.Where(StorageFilesSchema.Columns.Id).IsEqualTo(id);
            return query.FetchSingle();
        }


		/// <summary>
        /// Returns a list of StorageFile by a given Session_Id
        /// </summary>                
        public static List<StorageBox.Entities.StorageFile> GetBySession(int Session_Id)
        {
            StorageBox.DataAccess.StorageFileQueryBuilder query = new StorageFileQueryBuilder();
            query.Where(StorageFilesSchema.Columns.Session_Id).IsEqualTo(Session_Id);

            
            return query.FetchList();
        }

 

		/// <summary>
        /// Retrieves a list of records from the mapped data table [dbo].[StorageFile].
        /// </summary>        
        public static List<Entities.StorageFile> FetchAll()
        {
            StorageFileQueryBuilder query = new StorageFileQueryBuilder();            
            return query.FetchList();
        }

        /// <summary>
        /// Retrieves a report from the [StorageFile] table.
        /// </summary>
        /// <param name="settings">Sets the filter settings for running the report</param>
        /// <returns></returns>
        public static List<Entities.StorageFileReportDetail> GetReport(StorageFileFilterSettings settings = null)
        {
			if (settings == null)
            {
                settings = new StorageFileFilterSettings();
            }

            StorageFileReportDetailFactory factory = new StorageFileReportDetailFactory();
            return factory.FetchList("[dbo].[cgp_StorageFile_GetReport]", settings.GetParameters());
        }

 		

    }

	public partial class StorageFileFilterSettings : AppSimplicity.ActiveRecord.DataAccess.BaseEntityFilterSettings
    {
        

		public int Session_Id { get; set; }
            

        protected override void LoadParameters()
        {
            
            this.AddParameter("Session_Id", Session_Id);
        }

        public StorageFileFilterSettings() : base(DataContext.CONNECTION_NAME) { }
    }

	
    

	internal partial class SystemConfigurationPersister : EntityPersister<Entities.SystemConfiguration>
    {
        public SystemConfigurationPersister() : base (DataContext.CONNECTION_NAME)
        {

        }
        
        protected override DbCommand GetInsertStatement(Entities.SystemConfiguration entity)
        {
            DbCommand command = CreateCommand(GetInsertStatement(SystemConfigurationSets.Schema), CommandType.Text);
			command.Parameters.Add(CreateParameter("Id", entity.Id));
			command.Parameters.Add(CreateParameter("ParameterName", entity.ParameterName));
			command.Parameters.Add(CreateParameter("ParameterValue", entity.ParameterValue));
            return command;
        }

        protected override DbCommand GetDeleteStatement(int Id)
        {
            DbCommand command = CreateCommand(GetDeleteStatement(SystemConfigurationSets.Schema), CommandType.Text);
            command.Parameters.Add(CreateParameter("Id", Id));
            return command;
        }

        protected override DbCommand GetUpdateStatement(Entities.SystemConfiguration entity)
        {
            DbCommand command = CreateCommand(GetUpdateStatement(SystemConfigurationSets.Schema), CommandType.Text);
			command.Parameters.Add(CreateParameter("Id", entity.Id));
			command.Parameters.Add(CreateParameter("ParameterName", entity.ParameterName));
			command.Parameters.Add(CreateParameter("ParameterValue", entity.ParameterValue));
            return command;
        }        
	}

    internal partial class SystemConfigurationDataController : AppSimplicity.ActiveRecord.DataAccess.BaseEntityDataController<Entities.SystemConfiguration>
    {
		#region DataValidations
		protected override void RunDataValidations(Entities.SystemConfiguration entity, AppSimplicity.ActiveRecord.Validation.ValidationSummary summary)
        {
        }
		#endregion

        #region ctor
        public SystemConfigurationDataController()
            : base(new SystemConfigurationPersister())
        {

        }
        #endregion
    }
    

    #region Factory 
    public partial class SystemConfigurationFactory : BaseEntityFactory<Entities.SystemConfiguration>
    {
		partial void PopulateEntity(ref Entities.SystemConfiguration entity, DbDataReader reader);

        protected override Entities.SystemConfiguration LoadEntity(DbDataReader reader)
        {
            Entities.SystemConfiguration Entity = new Entities.SystemConfiguration()
            {
                Id = Map.ToInt32(reader["Id"]),
                ParameterName = Map.ToStringValue(reader["ParameterName"]),
                ParameterValue = Map.ToStringValue(reader["ParameterValue"])
            };

			PopulateEntity(ref Entity, reader);

            return Entity;
        }

        public SystemConfigurationFactory()
            : base(DataContext.CONNECTION_NAME)
        {

        }
    }
    #endregion
	
    #region Report Detail Factory
    public partial class SystemConfigurationReportDetailFactory : BaseEntityFactory<Entities.SystemConfigurationReportDetail>
    {
		partial void PopulateEntity(ref Entities.SystemConfigurationReportDetail entity, DbDataReader reader);

        protected override Entities.SystemConfigurationReportDetail LoadEntity(DbDataReader reader)
        {
            Entities.SystemConfigurationReportDetail Entity = new Entities.SystemConfigurationReportDetail()
            {
                Id = Map.ToInt32(reader["Id"]),
                ParameterName = Map.ToStringValue(reader["ParameterName"]),
                ParameterValue = Map.ToStringValue(reader["ParameterValue"])
            };

			PopulateEntity(ref Entity, reader);

            return Entity;
        }

        public SystemConfigurationReportDetailFactory()
            : base(DataContext.CONNECTION_NAME)
        {

        }
    }
    #endregion		

	internal partial class SystemConfigurationSetsSchema
	{

#region Column Enumeration
		public enum Columns 
        {
            Id = 0, 
            ParameterName = 1, 
            ParameterValue = 2
        }
#endregion	

		
	}

	#region QueryBuilder
	internal class SystemConfigurationQueryBuilder : GenericBaseQueryBuilder<StorageBox.Entities.SystemConfiguration>
    {
        /// <summary>
        /// Executes the corresponding sql command and returns a single instance of SystemConfiguration that matches the criteria.
        /// </summary>
        /// <returns></returns>
        public override Entities.SystemConfiguration FetchSingle()
        {
            SystemConfigurationFactory factory = new SystemConfigurationFactory();
            return factory.FetchSingle(GetSqlCommand());
        }

        /// <summary>
        /// Executes the corresponding sql command and returns a list of SystemConfiguration that matches the criteria.
        /// </summary>
        /// <returns></returns>
        public override List<Entities.SystemConfiguration> FetchList()
        {
            return FetchFirst(0);
        }

        /// <summary>
        /// Executes the corresponding sql command and returns a list of SystemConfiguration that matches the criteria and returns the first records coming in the query.
        /// </summary>
        /// <param name="limit">Determines the number of records to be returned from database.</param>
        /// <returns></returns>
        public override List<Entities.SystemConfiguration> FetchFirst(int limit)
        {
            SystemConfigurationFactory factory = new SystemConfigurationFactory();
            return factory.FetchList(GetSqlCommand(limit));
        }

        public SystemConfigurationQueryBuilder()
            : base(DataContext.CONNECTION_NAME, SystemConfigurationSets.GetSchema())
        {

        }

        /// <summary>
        /// Adds a condition to the query statement.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public CriteriaBuilder Where(SystemConfigurationSetsSchema.Columns column)
        {
            return base.Where(Schema.Columns[(int)column]);
        }

		/// <summary>
        /// Determines a condition for sorting when returning the list of entities.
        /// </summary>
        /// <param name="column"></param>
        public void SortBy(SystemConfigurationSetsSchema.Columns column)
        {
            base.AddSortCondition(Schema.Columns[(int)column], SortDirection.Ascending);
        }

        /// <summary>
        /// Determines condition and direction for sorting when returning the list of entities.
        /// </summary>
        /// <param name="column"></param>
        public void SortBy(SystemConfigurationSetsSchema.Columns column, SortDirection direction)
        {
            base.AddSortCondition(Schema.Columns[(int)column], direction);
        }
    }
	#endregion
	
    public partial class SystemConfigurationSets
    {	
		/// <summary>
        /// This method returns an instance that maps the schema 
        /// </summary>
        /// <returns></returns>
        public static Schema GetSchema()
        {
            Schema schema = new Schema()
            {
                SchemaName = "dbo",
                TableName = "SystemConfiguration"
            };

            //Adding the list of columns:
            schema.AddColumn("Id", DbType.Int32, false);
            schema.AddColumn("ParameterName", DbType.String, false);
            schema.AddColumn("ParameterValue", DbType.String, false);

            //Adding the list of indexes:


            return schema;
        }

		
		private static Schema _Schema;
		public static Schema Schema
		{
			get
			{
				if(_Schema == null)
				{
					_Schema = SystemConfigurationSets.GetSchema();
				}
				return _Schema;
			}
		}

		/// <summary>
        /// Creates a record in the mapped data table [dbo].[SystemConfiguration]
        /// </summary>
        /// <param name="entity">A populated entity of SystemConfiguration</param>
        public static void Create(Entities.SystemConfiguration entity)
        {
            SystemConfigurationDataController db = new SystemConfigurationDataController();
            db.Create(entity);
        }

		/// <summary>
        /// Updates a record in the mapped data table [dbo].[SystemConfiguration]
        /// </summary>
        /// <param name="entity">A populated entity of SystemConfiguration</param>
        public static void Update(Entities.SystemConfiguration entity)
        {
            SystemConfigurationDataController db = new SystemConfigurationDataController();
            db.Update(entity);
        }

		/// <summary>
        /// Deletes a record in the mapped data table [dbo].[SystemConfiguration]
        /// </summary>
        /// <param name="entity">A populated entity of SystemConfiguration</param>
        public static void Delete(Entities.SystemConfiguration entity)
        {
            SystemConfigurationDataController db = new SystemConfigurationDataController();
            db.Delete(entity);
        }

		/// <summary>
        /// Persists the information of an entity to the data table [dbo].[SystemConfiguration]
        /// </summary>
        /// <param name="entity">A populated entity of SystemConfiguration</param>
		public static void Save(Entities.SystemConfiguration entity)
        {
            SystemConfigurationDataController db = new SystemConfigurationDataController();
            db.Save(entity);
        }

		/// <summary>
        /// Retrieves a record from the mapped data table [dbo].[SystemConfiguration] using a given Id.
        /// </summary>
        /// <param name="id">The id value</param>
        public static Entities.SystemConfiguration FetchById(int id)
        {
            SystemConfigurationQueryBuilder query = new SystemConfigurationQueryBuilder();
            query.Where(SystemConfigurationSetsSchema.Columns.Id).IsEqualTo(id);
            return query.FetchSingle();
        }


 

		/// <summary>
        /// Retrieves a list of records from the mapped data table [dbo].[SystemConfiguration].
        /// </summary>        
        public static List<Entities.SystemConfiguration> FetchAll()
        {
            SystemConfigurationQueryBuilder query = new SystemConfigurationQueryBuilder();            
            return query.FetchList();
        }

        /// <summary>
        /// Retrieves a report from the [SystemConfiguration] table.
        /// </summary>
        /// <param name="settings">Sets the filter settings for running the report</param>
        /// <returns></returns>
        public static List<Entities.SystemConfigurationReportDetail> GetReport(SystemConfigurationFilterSettings settings = null)
        {
			if (settings == null)
            {
                settings = new SystemConfigurationFilterSettings();
            }

            SystemConfigurationReportDetailFactory factory = new SystemConfigurationReportDetailFactory();
            return factory.FetchList("[dbo].[cgp_SystemConfiguration_GetReport]", settings.GetParameters());
        }

 		

    }

	public partial class SystemConfigurationFilterSettings : AppSimplicity.ActiveRecord.DataAccess.BaseEntityFilterSettings
    {
        

            

        protected override void LoadParameters()
        {
            
        }

        public SystemConfigurationFilterSettings() : base(DataContext.CONNECTION_NAME) { }
    }

} 

namespace StorageBox.Reports
{
}

