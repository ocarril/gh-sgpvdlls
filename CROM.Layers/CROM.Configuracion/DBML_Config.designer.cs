﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CROM.Tools.Config
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BD_GC_MAGESET_20180802")]
	public partial class DBML_ConfigDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public DBML_ConfigDataContext() : 
				base(global::CROM.Tools.Config.Properties.Settings.Default.BD_GC_MAGESET_20180802ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DBML_ConfigDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBML_ConfigDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBML_ConfigDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBML_ConfigDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Maestros.omgc_S_Configuracion")]
		public ISingleResult<omgc_S_ConfiguracionResult> omgc_S_Configuracion([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> prm_codEmpresa, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> prm_codConfiguracion, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string prm_codKeyConfig, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string prm_desNombre, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Bit")] System.Nullable<bool> prm_indActivo)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), prm_codEmpresa, prm_codConfiguracion, prm_codKeyConfig, prm_desNombre, prm_indActivo);
			return ((ISingleResult<omgc_S_ConfiguracionResult>)(result.ReturnValue));
		}
	}
	
	public partial class omgc_S_ConfiguracionResult
	{
		
		private int _codConfiguracion;
		
		private string _codKeyConfig;
		
		private string _codTabla;
		
		private System.Nullable<int> _numNivel;
		
		private string _indOrden;
		
		private string _indTipoValor;
		
		private string _desValor;
		
		private string _desNombre;
		
		private string _gloDescripcion;
		
		private bool _indGenerico;
		
		private string _desGrupo;
		
		private bool _indActivo;
		
		private string _segUsuarioCrea;
		
		private string _segUsuarioEdita;
		
		private System.DateTime _segFechaCrea;
		
		private System.Nullable<System.DateTime> _segFechaEdita;
		
		private string _segMaquina;
		
		public omgc_S_ConfiguracionResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codConfiguracion", DbType="Int NOT NULL")]
		public int codConfiguracion
		{
			get
			{
				return this._codConfiguracion;
			}
			set
			{
				if ((this._codConfiguracion != value))
				{
					this._codConfiguracion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codKeyConfig", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string codKeyConfig
		{
			get
			{
				return this._codKeyConfig;
			}
			set
			{
				if ((this._codKeyConfig != value))
				{
					this._codKeyConfig = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codTabla", DbType="Char(15)")]
		public string codTabla
		{
			get
			{
				return this._codTabla;
			}
			set
			{
				if ((this._codTabla != value))
				{
					this._codTabla = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_numNivel", DbType="Int")]
		public System.Nullable<int> numNivel
		{
			get
			{
				return this._numNivel;
			}
			set
			{
				if ((this._numNivel != value))
				{
					this._numNivel = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_indOrden", DbType="Char(4) NOT NULL", CanBeNull=false)]
		public string indOrden
		{
			get
			{
				return this._indOrden;
			}
			set
			{
				if ((this._indOrden != value))
				{
					this._indOrden = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_indTipoValor", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string indTipoValor
		{
			get
			{
				return this._indTipoValor;
			}
			set
			{
				if ((this._indTipoValor != value))
				{
					this._indTipoValor = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desValor", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string desValor
		{
			get
			{
				return this._desValor;
			}
			set
			{
				if ((this._desValor != value))
				{
					this._desValor = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desNombre", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string desNombre
		{
			get
			{
				return this._desNombre;
			}
			set
			{
				if ((this._desNombre != value))
				{
					this._desNombre = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_gloDescripcion", DbType="VarChar(500)")]
		public string gloDescripcion
		{
			get
			{
				return this._gloDescripcion;
			}
			set
			{
				if ((this._gloDescripcion != value))
				{
					this._gloDescripcion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_indGenerico", DbType="Bit NOT NULL")]
		public bool indGenerico
		{
			get
			{
				return this._indGenerico;
			}
			set
			{
				if ((this._indGenerico != value))
				{
					this._indGenerico = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desGrupo", DbType="VarChar(10)")]
		public string desGrupo
		{
			get
			{
				return this._desGrupo;
			}
			set
			{
				if ((this._desGrupo != value))
				{
					this._desGrupo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_indActivo", DbType="Bit NOT NULL")]
		public bool indActivo
		{
			get
			{
				return this._indActivo;
			}
			set
			{
				if ((this._indActivo != value))
				{
					this._indActivo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segUsuarioCrea", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string segUsuarioCrea
		{
			get
			{
				return this._segUsuarioCrea;
			}
			set
			{
				if ((this._segUsuarioCrea != value))
				{
					this._segUsuarioCrea = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segUsuarioEdita", DbType="VarChar(30)")]
		public string segUsuarioEdita
		{
			get
			{
				return this._segUsuarioEdita;
			}
			set
			{
				if ((this._segUsuarioEdita != value))
				{
					this._segUsuarioEdita = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segFechaCrea", DbType="DateTime NOT NULL")]
		public System.DateTime segFechaCrea
		{
			get
			{
				return this._segFechaCrea;
			}
			set
			{
				if ((this._segFechaCrea != value))
				{
					this._segFechaCrea = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segFechaEdita", DbType="DateTime")]
		public System.Nullable<System.DateTime> segFechaEdita
		{
			get
			{
				return this._segFechaEdita;
			}
			set
			{
				if ((this._segFechaEdita != value))
				{
					this._segFechaEdita = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segMaquina", DbType="VarChar(40) NOT NULL", CanBeNull=false)]
		public string segMaquina
		{
			get
			{
				return this._segMaquina;
			}
			set
			{
				if ((this._segMaquina != value))
				{
					this._segMaquina = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
