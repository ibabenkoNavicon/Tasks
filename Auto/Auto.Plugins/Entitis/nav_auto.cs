//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Auto.Common.Entitis
{
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum nav_autoState
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Active = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Inactive = 1,
	}
	
	/// <summary>
	/// 
	/// </summary>
	[System.Runtime.Serialization.DataContractAttribute()]
	[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("nav_auto")]
	public partial class nav_auto : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		public static class Fields
		{
			public const string CreatedBy = "createdby";
			public const string CreatedOn = "createdon";
			public const string CreatedOnBehalfBy = "createdonbehalfby";
			public const string ExchangeRate = "exchangerate";
			public const string ImportSequenceNumber = "importsequencenumber";
			public const string ModifiedBy = "modifiedby";
			public const string ModifiedOn = "modifiedon";
			public const string ModifiedOnBehalfBy = "modifiedonbehalfby";
			public const string nav_amount = "nav_amount";
			public const string nav_amount_Base = "nav_amount_base";
			public const string nav_autoId = "nav_autoid";
			public const string Id = "nav_autoid";
			public const string nav_brandid = "nav_brandid";
			public const string nav_details = "nav_details";
			public const string nav_isdamaged = "nav_isdamaged";
			public const string nav_km = "nav_km";
			public const string nav_modelid = "nav_modelid";
			public const string nav_name = "nav_name";
			public const string nav_ownerscount = "nav_ownerscount";
			public const string nav_used = "nav_used";
			public const string nav_vechclenumber = "nav_vechclenumber";
			public const string nav_vin = "nav_vin";
			public const string OverriddenCreatedOn = "overriddencreatedon";
			public const string OwnerId = "ownerid";
			public const string OwningBusinessUnit = "owningbusinessunit";
			public const string OwningTeam = "owningteam";
			public const string OwningUser = "owninguser";
			public const string StateCode = "statecode";
			public const string StatusCode = "statuscode";
			public const string TimeZoneRuleVersionNumber = "timezoneruleversionnumber";
			public const string TransactionCurrencyId = "transactioncurrencyid";
			public const string UTCConversionTimeZoneCode = "utcconversiontimezonecode";
			public const string VersionNumber = "versionnumber";
			public const string nav_nav_brand_nav_auto_brandid = "nav_nav_brand_nav_auto_brandid";
			public const string nav_nav_model_nav_auto_modelid = "nav_nav_model_nav_auto_modelid";
		}
		
		public static class Relationships
		{
			public const string nav_nav_auto_nav_credit = "nav_nav_auto_nav_credit";
		}
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public nav_auto() : 
				base(EntityLogicalName)
		{
		}
		
		public const string EntityLogicalName = "nav_auto";
		
		public const string EntitySchemaName = "nav_auto";
		
		public const string PrimaryIdAttribute = "nav_autoid";
		
		public const string PrimaryNameAttribute = "nav_name";
		
		public const string EntityLogicalCollectionName = "nav_autos";
		
		public const string EntitySetName = "nav_autos";
		
		public const int EntityTypeCode = 10409;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		private void OnPropertyChanged(string propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void OnPropertyChanging(string propertyName)
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
			}
		}
		
		/// <summary>
		/// Уникальный идентификатор пользователя, создавшего запись.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
		public Microsoft.Xrm.Sdk.EntityReference CreatedBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
			}
			set
			{
				this.OnPropertyChanging("CreatedBy");
				this.SetAttributeValue("createdby", value);
				this.OnPropertyChanged("CreatedBy");
			}
		}
		
		/// <summary>
		/// Дата и время создания записи.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
		public System.Nullable<System.DateTime> CreatedOn
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
			}
			set
			{
				this.OnPropertyChanging("CreatedOn");
				this.SetAttributeValue("createdon", value);
				this.OnPropertyChanged("CreatedOn");
			}
		}
		
		/// <summary>
		/// Уникальный идентификатор пользователя-представителя, создавшего запись.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
		public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
			}
			set
			{
				this.OnPropertyChanging("CreatedOnBehalfBy");
				this.SetAttributeValue("createdonbehalfby", value);
				this.OnPropertyChanged("CreatedOnBehalfBy");
			}
		}
		
		/// <summary>
		/// Курс валюты, связанной с сущностью, по отношению к базовой валюте.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("exchangerate")]
		public System.Nullable<decimal> ExchangeRate
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<decimal>>("exchangerate");
			}
			set
			{
				this.OnPropertyChanging("ExchangeRate");
				this.SetAttributeValue("exchangerate", value);
				this.OnPropertyChanged("ExchangeRate");
			}
		}
		
		/// <summary>
		/// Порядковый номер импорта, в результате которого была создана эта запись.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("importsequencenumber")]
		public System.Nullable<int> ImportSequenceNumber
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("importsequencenumber");
			}
			set
			{
				this.OnPropertyChanging("ImportSequenceNumber");
				this.SetAttributeValue("importsequencenumber", value);
				this.OnPropertyChanged("ImportSequenceNumber");
			}
		}
		
		/// <summary>
		/// Уникальный идентификатор пользователя, изменившего запись.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
		public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
			}
			set
			{
				this.OnPropertyChanging("ModifiedBy");
				this.SetAttributeValue("modifiedby", value);
				this.OnPropertyChanged("ModifiedBy");
			}
		}
		
		/// <summary>
		/// Дата и время изменения записи.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
		public System.Nullable<System.DateTime> ModifiedOn
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
			}
			set
			{
				this.OnPropertyChanging("ModifiedOn");
				this.SetAttributeValue("modifiedon", value);
				this.OnPropertyChanged("ModifiedOn");
			}
		}
		
		/// <summary>
		/// Уникальный идентификатор пользователя-представителя, изменившего запись.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
		public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
			}
			set
			{
				this.OnPropertyChanging("ModifiedOnBehalfBy");
				this.SetAttributeValue("modifiedonbehalfby", value);
				this.OnPropertyChanged("ModifiedOnBehalfBy");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("nav_amount")]
		public Microsoft.Xrm.Sdk.Money nav_amount
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("nav_amount");
			}
			set
			{
				this.OnPropertyChanging("nav_amount");
				this.SetAttributeValue("nav_amount", value);
				this.OnPropertyChanged("nav_amount");
			}
		}
		
		/// <summary>
		/// Значение поля Стоимость в базовой валюте.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("nav_amount_base")]
		public Microsoft.Xrm.Sdk.Money nav_amount_Base
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.Money>("nav_amount_base");
			}
			set
			{
				this.OnPropertyChanging("nav_amount_Base");
				this.SetAttributeValue("nav_amount_base", value);
				this.OnPropertyChanged("nav_amount_Base");
			}
		}
		
		/// <summary>
		/// Уникальный идентификатор для экземпляров сущности.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("nav_autoid")]
		public System.Nullable<System.Guid> nav_autoId
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("nav_autoid");
			}
			set
			{
				this.OnPropertyChanging("nav_autoId");
				this.SetAttributeValue("nav_autoid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = System.Guid.Empty;
				}
				this.OnPropertyChanged("nav_autoId");
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("nav_autoid")]
		public override System.Guid Id
		{
			get
			{
				return base.Id;
			}
			set
			{
				this.nav_autoId = value;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("nav_brandid")]
		public Microsoft.Xrm.Sdk.EntityReference nav_brandid
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("nav_brandid");
			}
			set
			{
				this.OnPropertyChanging("nav_brandid");
				this.SetAttributeValue("nav_brandid", value);
				this.OnPropertyChanged("nav_brandid");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("nav_details")]
		public string nav_details
		{
			get
			{
				return this.GetAttributeValue<string>("nav_details");
			}
			set
			{
				this.OnPropertyChanging("nav_details");
				this.SetAttributeValue("nav_details", value);
				this.OnPropertyChanged("nav_details");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("nav_isdamaged")]
		public System.Nullable<bool> nav_isdamaged
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("nav_isdamaged");
			}
			set
			{
				this.OnPropertyChanging("nav_isdamaged");
				this.SetAttributeValue("nav_isdamaged", value);
				this.OnPropertyChanged("nav_isdamaged");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("nav_km")]
		public System.Nullable<double> nav_km
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<double>>("nav_km");
			}
			set
			{
				this.OnPropertyChanging("nav_km");
				this.SetAttributeValue("nav_km", value);
				this.OnPropertyChanged("nav_km");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("nav_modelid")]
		public Microsoft.Xrm.Sdk.EntityReference nav_modelid
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("nav_modelid");
			}
			set
			{
				this.OnPropertyChanging("nav_modelid");
				this.SetAttributeValue("nav_modelid", value);
				this.OnPropertyChanged("nav_modelid");
			}
		}
		
		/// <summary>
		/// Имя настраиваемой сущности.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("nav_name")]
		public string nav_name
		{
			get
			{
				return this.GetAttributeValue<string>("nav_name");
			}
			set
			{
				this.OnPropertyChanging("nav_name");
				this.SetAttributeValue("nav_name", value);
				this.OnPropertyChanged("nav_name");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("nav_ownerscount")]
		public System.Nullable<int> nav_ownerscount
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("nav_ownerscount");
			}
			set
			{
				this.OnPropertyChanging("nav_ownerscount");
				this.SetAttributeValue("nav_ownerscount", value);
				this.OnPropertyChanged("nav_ownerscount");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("nav_used")]
		public System.Nullable<bool> nav_used
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("nav_used");
			}
			set
			{
				this.OnPropertyChanging("nav_used");
				this.SetAttributeValue("nav_used", value);
				this.OnPropertyChanged("nav_used");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("nav_vechclenumber")]
		public string nav_vechclenumber
		{
			get
			{
				return this.GetAttributeValue<string>("nav_vechclenumber");
			}
			set
			{
				this.OnPropertyChanging("nav_vechclenumber");
				this.SetAttributeValue("nav_vechclenumber", value);
				this.OnPropertyChanged("nav_vechclenumber");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("nav_vin")]
		public string nav_vin
		{
			get
			{
				return this.GetAttributeValue<string>("nav_vin");
			}
			set
			{
				this.OnPropertyChanging("nav_vin");
				this.SetAttributeValue("nav_vin", value);
				this.OnPropertyChanged("nav_vin");
			}
		}
		
		/// <summary>
		/// Дата и время переноса записи.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("overriddencreatedon")]
		public System.Nullable<System.DateTime> OverriddenCreatedOn
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("overriddencreatedon");
			}
			set
			{
				this.OnPropertyChanging("OverriddenCreatedOn");
				this.SetAttributeValue("overriddencreatedon", value);
				this.OnPropertyChanged("OverriddenCreatedOn");
			}
		}
		
		/// <summary>
		/// Идентификатор ответственного
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ownerid")]
		public Microsoft.Xrm.Sdk.EntityReference OwnerId
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ownerid");
			}
			set
			{
				this.OnPropertyChanging("OwnerId");
				this.SetAttributeValue("ownerid", value);
				this.OnPropertyChanged("OwnerId");
			}
		}
		
		/// <summary>
		/// Уникальный идентификатор бизнес-единицы, владеющей этой записью
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningbusinessunit")]
		public Microsoft.Xrm.Sdk.EntityReference OwningBusinessUnit
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningbusinessunit");
			}
			set
			{
				this.OnPropertyChanging("OwningBusinessUnit");
				this.SetAttributeValue("owningbusinessunit", value);
				this.OnPropertyChanged("OwningBusinessUnit");
			}
		}
		
		/// <summary>
		/// Уникальный идентификатор рабочей группы, ответственной за запись.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningteam")]
		public Microsoft.Xrm.Sdk.EntityReference OwningTeam
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningteam");
			}
			set
			{
				this.OnPropertyChanging("OwningTeam");
				this.SetAttributeValue("owningteam", value);
				this.OnPropertyChanged("OwningTeam");
			}
		}
		
		/// <summary>
		/// Уникальный идентификатор пользователя, ответственного за запись.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owninguser")]
		public Microsoft.Xrm.Sdk.EntityReference OwningUser
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owninguser");
			}
			set
			{
				this.OnPropertyChanging("OwningUser");
				this.SetAttributeValue("owninguser", value);
				this.OnPropertyChanged("OwningUser");
			}
		}
		
		/// <summary>
		/// Статус Автомобиль
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statecode")]
		public System.Nullable<Auto.Common.Entitis.nav_autoState> StateCode
		{
			get
			{
				Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statecode");
				if ((optionSet != null))
				{
					return ((Auto.Common.Entitis.nav_autoState)(System.Enum.ToObject(typeof(Auto.Common.Entitis.nav_autoState), optionSet.Value)));
				}
				else
				{
					return null;
				}
			}
			set
			{
				this.OnPropertyChanging("StateCode");
				if ((value == null))
				{
					this.SetAttributeValue("statecode", null);
				}
				else
				{
					this.SetAttributeValue("statecode", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
				}
				this.OnPropertyChanged("StateCode");
			}
		}
		
		/// <summary>
		/// Причина состояния Автомобиль
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statuscode")]
		public virtual nav_auto_StatusCode? StatusCode
		{
			get
			{
				return ((nav_auto_StatusCode?)(EntityOptionSetEnum.GetEnum(this, "statuscode")));
			}
			set
			{
				this.OnPropertyChanging("StatusCode");
				this.SetAttributeValue("statuscode", value.HasValue ? new Microsoft.Xrm.Sdk.OptionSetValue((int)value) : null);
				this.OnPropertyChanged("StatusCode");
			}
		}
		
		/// <summary>
		/// Только для внутреннего использования.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezoneruleversionnumber")]
		public System.Nullable<int> TimeZoneRuleVersionNumber
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("timezoneruleversionnumber");
			}
			set
			{
				this.OnPropertyChanging("TimeZoneRuleVersionNumber");
				this.SetAttributeValue("timezoneruleversionnumber", value);
				this.OnPropertyChanged("TimeZoneRuleVersionNumber");
			}
		}
		
		/// <summary>
		/// Уникальный идентификатор валюты, связанной с сущностью.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("transactioncurrencyid")]
		public Microsoft.Xrm.Sdk.EntityReference TransactionCurrencyId
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("transactioncurrencyid");
			}
			set
			{
				this.OnPropertyChanging("TransactionCurrencyId");
				this.SetAttributeValue("transactioncurrencyid", value);
				this.OnPropertyChanged("TransactionCurrencyId");
			}
		}
		
		/// <summary>
		/// Код часового пояса, который использовался при создании записи.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("utcconversiontimezonecode")]
		public System.Nullable<int> UTCConversionTimeZoneCode
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("utcconversiontimezonecode");
			}
			set
			{
				this.OnPropertyChanging("UTCConversionTimeZoneCode");
				this.SetAttributeValue("utcconversiontimezonecode", value);
				this.OnPropertyChanged("UTCConversionTimeZoneCode");
			}
		}
		
		/// <summary>
		/// Номер версии
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
		public System.Nullable<long> VersionNumber
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
			}
			set
			{
				this.OnPropertyChanging("VersionNumber");
				this.SetAttributeValue("versionnumber", value);
				this.OnPropertyChanged("VersionNumber");
			}
		}
		
		/// <summary>
		/// 1:N nav_nav_auto_nav_agreement_autoid
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("nav_nav_auto_nav_agreement_autoid")]
		public System.Collections.Generic.IEnumerable<Auto.Common.Entitis.nav_agreement> nav_nav_auto_nav_agreement_autoid
		{
			get
			{
				return this.GetRelatedEntities<Auto.Common.Entitis.nav_agreement>("nav_nav_auto_nav_agreement_autoid", null);
			}
			set
			{
				this.OnPropertyChanging("nav_nav_auto_nav_agreement_autoid");
				this.SetRelatedEntities<Auto.Common.Entitis.nav_agreement>("nav_nav_auto_nav_agreement_autoid", null, value);
				this.OnPropertyChanged("nav_nav_auto_nav_agreement_autoid");
			}
		}
		
		/// <summary>
		/// N:N nav_nav_auto_nav_credit
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("nav_nav_auto_nav_credit")]
		public System.Collections.Generic.IEnumerable<Auto.Common.Entitis.nav_credit> nav_nav_auto_nav_credit
		{
			get
			{
				return this.GetRelatedEntities<Auto.Common.Entitis.nav_credit>("nav_nav_auto_nav_credit", null);
			}
			set
			{
				this.OnPropertyChanging("nav_nav_auto_nav_credit");
				this.SetRelatedEntities<Auto.Common.Entitis.nav_credit>("nav_nav_auto_nav_credit", null, value);
				this.OnPropertyChanged("nav_nav_auto_nav_credit");
			}
		}
		
		/// <summary>
		/// N:1 nav_nav_brand_nav_auto_brandid
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("nav_brandid")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("nav_nav_brand_nav_auto_brandid")]
		public Auto.Common.Entitis.nav_brand nav_nav_brand_nav_auto_brandid
		{
			get
			{
				return this.GetRelatedEntity<Auto.Common.Entitis.nav_brand>("nav_nav_brand_nav_auto_brandid", null);
			}
			set
			{
				this.OnPropertyChanging("nav_nav_brand_nav_auto_brandid");
				this.SetRelatedEntity<Auto.Common.Entitis.nav_brand>("nav_nav_brand_nav_auto_brandid", null, value);
				this.OnPropertyChanged("nav_nav_brand_nav_auto_brandid");
			}
		}
		
		/// <summary>
		/// N:1 nav_nav_model_nav_auto_modelid
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("nav_modelid")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("nav_nav_model_nav_auto_modelid")]
		public Auto.Common.Entitis.nav_model nav_nav_model_nav_auto_modelid
		{
			get
			{
				return this.GetRelatedEntity<Auto.Common.Entitis.nav_model>("nav_nav_model_nav_auto_modelid", null);
			}
			set
			{
				this.OnPropertyChanging("nav_nav_model_nav_auto_modelid");
				this.SetRelatedEntity<Auto.Common.Entitis.nav_model>("nav_nav_model_nav_auto_modelid", null, value);
				this.OnPropertyChanged("nav_nav_model_nav_auto_modelid");
			}
		}
		
		/// <summary>
		/// Constructor for populating via LINQ queries given a LINQ anonymous type
		/// <param name="anonymousType">LINQ anonymous type.</param>
		/// </summary>
		public nav_auto(object anonymousType) : 
				this()
		{
            foreach (var p in anonymousType.GetType().GetProperties())
            {
                var value = p.GetValue(anonymousType, null);
                var name = p.Name.ToLower();
            
                if (name.EndsWith("enum") && value.GetType().BaseType == typeof(System.Enum))
                {
                    value = new Microsoft.Xrm.Sdk.OptionSetValue((int) value);
                    name = name.Remove(name.Length - "enum".Length);
                }
            
                switch (name)
                {
                    case "id":
                        base.Id = (System.Guid)value;
                        Attributes["nav_autoid"] = base.Id;
                        break;
                    case "nav_autoid":
                        var id = (System.Nullable<System.Guid>) value;
                        if(id == null){ continue; }
                        base.Id = id.Value;
                        Attributes[name] = base.Id;
                        break;
                    case "formattedvalues":
                        // Add Support for FormattedValues
                        FormattedValues.AddRange((Microsoft.Xrm.Sdk.FormattedValueCollection)value);
                        break;
                    default:
                        Attributes[name] = value;
                        break;
                }
            }
		}
	}
}