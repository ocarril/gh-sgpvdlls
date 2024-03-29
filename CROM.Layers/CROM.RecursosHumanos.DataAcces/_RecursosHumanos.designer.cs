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

namespace CROM.RecursosHumanos.DataAcces
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BD_GC_MAGESET_SFS_20201106")]
	public partial class _RecursosHumanosDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public _RecursosHumanosDataContext() : 
				base(global::CROM.RecursosHumanos.DataAcces.Properties.Settings.Default.BD_GC_MAGESET_SFS_20201106ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public _RecursosHumanosDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public _RecursosHumanosDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public _RecursosHumanosDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public _RecursosHumanosDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="RecursosHumanos.omgc_D_Empleado")]
		public ISingleResult<omgc_D_EmpleadoResult> omgc_D_Empleado([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_codEmpresa, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_codEmpleado, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(25)")] string p_UserElimina, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string p_MaquinaElimina)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), p_codEmpresa, p_codEmpleado, p_UserElimina, p_MaquinaElimina);
			return ((ISingleResult<omgc_D_EmpleadoResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="RecursosHumanos.omgc_I_Empleado")]
		public ISingleResult<omgc_I_EmpleadoResult> omgc_I_Empleado(
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_codEmpresa, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(15)")] string p_codPersonaEmpresa, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(15)")] string p_codPersonaNatural, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(17)")] string p_codRegAreaEmpleado, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(17)")] string p_codRegCategoria, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(17)")] string p_codRegEstadoCivil, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(17)")] string p_codRegGrupoSanguineo, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> p_fecNacimiento, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> p_fecAltaLaboral, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> p_fecBajaLaboral, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(15,4)")] System.Nullable<decimal> p_monSueldoBasico, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(10,4)")] System.Nullable<decimal> p_porComisionXVenta, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Char(1)")] System.Nullable<char> p_indSexo, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Bit")] System.Nullable<bool> p_indVendedor, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Bit")] System.Nullable<bool> p_indActivo, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(25)")] string p_segUsuarioCrea, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string p_segMaquina, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(20)")] string p_codPlanilla, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(80)")] string p_desCorreoElectronico)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), p_codEmpresa, p_codPersonaEmpresa, p_codPersonaNatural, p_codRegAreaEmpleado, p_codRegCategoria, p_codRegEstadoCivil, p_codRegGrupoSanguineo, p_fecNacimiento, p_fecAltaLaboral, p_fecBajaLaboral, p_monSueldoBasico, p_porComisionXVenta, p_indSexo, p_indVendedor, p_indActivo, p_segUsuarioCrea, p_segMaquina, p_codPlanilla, p_desCorreoElectronico);
			return ((ISingleResult<omgc_I_EmpleadoResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="RecursosHumanos.omgc_S_Empleado_Paged")]
		public ISingleResult<omgc_S_Empleado_PagedResult> omgc_S_Empleado_Paged([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_NumPagina, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_TamPagina, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string p_OrdenPor, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(4)")] string p_OrdenTipo, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_codEmpresa, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(15)")] string p_codEmpresaRUC, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(20)")] string p_codPlanilla, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(15)")] string p_codRegEstadoCivil, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(15)")] string p_codRegAreaEmpleado, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(15)")] string p_codRegCategoria, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(20)")] string p_desNombre, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(1)")] string p_indSexo, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Bit")] System.Nullable<bool> p_indActivo)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), p_NumPagina, p_TamPagina, p_OrdenPor, p_OrdenTipo, p_codEmpresa, p_codEmpresaRUC, p_codPlanilla, p_codRegEstadoCivil, p_codRegAreaEmpleado, p_codRegCategoria, p_desNombre, p_indSexo, p_indActivo);
			return ((ISingleResult<omgc_S_Empleado_PagedResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="RecursosHumanos.omgc_U_Empleado")]
		public ISingleResult<omgc_U_EmpleadoResult> omgc_U_Empleado(
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_codEmpresa, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_codEmpleado, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(15)")] string p_codPersonaEmpresa, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(15)")] string p_codPersonaNatural, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(17)")] string p_codRegAreaEmpleado, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(17)")] string p_codRegCategoria, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(17)")] string p_codRegEstadoCivil, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(17)")] string p_codRegGrupoSanguineo, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> p_fecNacimiento, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> p_fecAltaLaboral, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> p_fecBajaLaboral, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(15,4)")] System.Nullable<decimal> p_monSueldoBasico, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(10,4)")] System.Nullable<decimal> p_porComisionXVenta, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Char(1)")] System.Nullable<char> p_indSexo, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Bit")] System.Nullable<bool> p_indVendedor, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Bit")] System.Nullable<bool> p_indActivo, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(25)")] string p_segUsuarioEdita, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string p_segMaquina, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(20)")] string p_codPlanilla, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(80)")] string p_desCorreoElectronico)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), p_codEmpresa, p_codEmpleado, p_codPersonaEmpresa, p_codPersonaNatural, p_codRegAreaEmpleado, p_codRegCategoria, p_codRegEstadoCivil, p_codRegGrupoSanguineo, p_fecNacimiento, p_fecAltaLaboral, p_fecBajaLaboral, p_monSueldoBasico, p_porComisionXVenta, p_indSexo, p_indVendedor, p_indActivo, p_segUsuarioEdita, p_segMaquina, p_codPlanilla, p_desCorreoElectronico);
			return ((ISingleResult<omgc_U_EmpleadoResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="RecursosHumanos.omgc_S_Empleado")]
		public ISingleResult<omgc_S_EmpleadoResult> omgc_S_Empleado([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_codEmpresa, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(15)")] string p_codEmpresaRUC, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(15)")] string p_codPersonaNatural, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(20)")] string p_codPlanilla, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_codEmpleado, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Bit")] System.Nullable<bool> p_indActivo)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), p_codEmpresa, p_codEmpresaRUC, p_codPersonaNatural, p_codPlanilla, p_codEmpleado, p_indActivo);
			return ((ISingleResult<omgc_S_EmpleadoResult>)(result.ReturnValue));
		}
	}
	
	public partial class omgc_D_EmpleadoResult
	{
		
		private System.Nullable<int> _codError;
		
		private string _desMessage;
		
		public omgc_D_EmpleadoResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codError", DbType="Int")]
		public System.Nullable<int> codError
		{
			get
			{
				return this._codError;
			}
			set
			{
				if ((this._codError != value))
				{
					this._codError = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desMessage", DbType="VarChar(2) NOT NULL", CanBeNull=false)]
		public string desMessage
		{
			get
			{
				return this._desMessage;
			}
			set
			{
				if ((this._desMessage != value))
				{
					this._desMessage = value;
				}
			}
		}
	}
	
	public partial class omgc_I_EmpleadoResult
	{
		
		private System.Nullable<int> _codError;
		
		private string _desMessage;
		
		public omgc_I_EmpleadoResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codError", DbType="Int")]
		public System.Nullable<int> codError
		{
			get
			{
				return this._codError;
			}
			set
			{
				if ((this._codError != value))
				{
					this._codError = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desMessage", DbType="VarChar(2) NOT NULL", CanBeNull=false)]
		public string desMessage
		{
			get
			{
				return this._desMessage;
			}
			set
			{
				if ((this._desMessage != value))
				{
					this._desMessage = value;
				}
			}
		}
	}
	
	public partial class omgc_S_Empleado_PagedResult
	{
		
		private int _codEmpleado;
		
		private string _codPlanilla;
		
		private string _desApellidos;
		
		private string _desNombres;
		
		private System.Nullable<System.DateTime> _fecNacimiento;
		
		private char _indSexo;
		
		private System.Nullable<System.DateTime> _fecAltaLaboral;
		
		private System.Nullable<System.DateTime> _fecBajaLaboral;
		
		private string _desCorreoElectronico;
		
		private bool _indVendedor;
		
		private bool _indActivo;
		
		private string _segUsuarioEdita;
		
		private System.Nullable<System.DateTime> _segFechaHoraEdita;
		
		private string _segMaquinaEdita;
		
		private string _codRegAreaEmpleadoNombre;
		
		private string _codRegCategoriaNombre;
		
		private string _codRegEstadoCivilNombre;
		
		private string _codRegGrupoSanguineoNombre;
		
		private System.Nullable<int> _TOTALROWS;
		
		private System.Nullable<long> _ROWNUM;
		
		public omgc_S_Empleado_PagedResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codEmpleado", DbType="Int NOT NULL")]
		public int codEmpleado
		{
			get
			{
				return this._codEmpleado;
			}
			set
			{
				if ((this._codEmpleado != value))
				{
					this._codEmpleado = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codPlanilla", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string codPlanilla
		{
			get
			{
				return this._codPlanilla;
			}
			set
			{
				if ((this._codPlanilla != value))
				{
					this._codPlanilla = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desApellidos", DbType="VarChar(81) NOT NULL", CanBeNull=false)]
		public string desApellidos
		{
			get
			{
				return this._desApellidos;
			}
			set
			{
				if ((this._desApellidos != value))
				{
					this._desApellidos = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desNombres", DbType="VarChar(91) NOT NULL", CanBeNull=false)]
		public string desNombres
		{
			get
			{
				return this._desNombres;
			}
			set
			{
				if ((this._desNombres != value))
				{
					this._desNombres = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fecNacimiento", DbType="DateTime")]
		public System.Nullable<System.DateTime> fecNacimiento
		{
			get
			{
				return this._fecNacimiento;
			}
			set
			{
				if ((this._fecNacimiento != value))
				{
					this._fecNacimiento = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_indSexo", DbType="Char(1) NOT NULL")]
		public char indSexo
		{
			get
			{
				return this._indSexo;
			}
			set
			{
				if ((this._indSexo != value))
				{
					this._indSexo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fecAltaLaboral", DbType="DateTime")]
		public System.Nullable<System.DateTime> fecAltaLaboral
		{
			get
			{
				return this._fecAltaLaboral;
			}
			set
			{
				if ((this._fecAltaLaboral != value))
				{
					this._fecAltaLaboral = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fecBajaLaboral", DbType="DateTime")]
		public System.Nullable<System.DateTime> fecBajaLaboral
		{
			get
			{
				return this._fecBajaLaboral;
			}
			set
			{
				if ((this._fecBajaLaboral != value))
				{
					this._fecBajaLaboral = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desCorreoElectronico", DbType="VarChar(80) NOT NULL", CanBeNull=false)]
		public string desCorreoElectronico
		{
			get
			{
				return this._desCorreoElectronico;
			}
			set
			{
				if ((this._desCorreoElectronico != value))
				{
					this._desCorreoElectronico = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_indVendedor", DbType="Bit NOT NULL")]
		public bool indVendedor
		{
			get
			{
				return this._indVendedor;
			}
			set
			{
				if ((this._indVendedor != value))
				{
					this._indVendedor = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segUsuarioEdita", DbType="VarChar(50)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segFechaHoraEdita", DbType="DateTime")]
		public System.Nullable<System.DateTime> segFechaHoraEdita
		{
			get
			{
				return this._segFechaHoraEdita;
			}
			set
			{
				if ((this._segFechaHoraEdita != value))
				{
					this._segFechaHoraEdita = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segMaquinaEdita", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string segMaquinaEdita
		{
			get
			{
				return this._segMaquinaEdita;
			}
			set
			{
				if ((this._segMaquinaEdita != value))
				{
					this._segMaquinaEdita = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codRegAreaEmpleadoNombre", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string codRegAreaEmpleadoNombre
		{
			get
			{
				return this._codRegAreaEmpleadoNombre;
			}
			set
			{
				if ((this._codRegAreaEmpleadoNombre != value))
				{
					this._codRegAreaEmpleadoNombre = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codRegCategoriaNombre", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string codRegCategoriaNombre
		{
			get
			{
				return this._codRegCategoriaNombre;
			}
			set
			{
				if ((this._codRegCategoriaNombre != value))
				{
					this._codRegCategoriaNombre = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codRegEstadoCivilNombre", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string codRegEstadoCivilNombre
		{
			get
			{
				return this._codRegEstadoCivilNombre;
			}
			set
			{
				if ((this._codRegEstadoCivilNombre != value))
				{
					this._codRegEstadoCivilNombre = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codRegGrupoSanguineoNombre", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string codRegGrupoSanguineoNombre
		{
			get
			{
				return this._codRegGrupoSanguineoNombre;
			}
			set
			{
				if ((this._codRegGrupoSanguineoNombre != value))
				{
					this._codRegGrupoSanguineoNombre = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TOTALROWS", DbType="Int")]
		public System.Nullable<int> TOTALROWS
		{
			get
			{
				return this._TOTALROWS;
			}
			set
			{
				if ((this._TOTALROWS != value))
				{
					this._TOTALROWS = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ROWNUM", DbType="BigInt")]
		public System.Nullable<long> ROWNUM
		{
			get
			{
				return this._ROWNUM;
			}
			set
			{
				if ((this._ROWNUM != value))
				{
					this._ROWNUM = value;
				}
			}
		}
	}
	
	public partial class omgc_U_EmpleadoResult
	{
		
		private System.Nullable<int> _codError;
		
		private string _desMessage;
		
		public omgc_U_EmpleadoResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codError", DbType="Int")]
		public System.Nullable<int> codError
		{
			get
			{
				return this._codError;
			}
			set
			{
				if ((this._codError != value))
				{
					this._codError = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desMessage", DbType="VarChar(2) NOT NULL", CanBeNull=false)]
		public string desMessage
		{
			get
			{
				return this._desMessage;
			}
			set
			{
				if ((this._desMessage != value))
				{
					this._desMessage = value;
				}
			}
		}
	}
	
	public partial class omgc_S_EmpleadoResult
	{
		
		private int _codEmpresa;
		
		private int _codEmpleado;
		
		private string _codPersonaEmpresa;
		
		private string _codPersonaNatural;
		
		private string _ApellidoPaterno;
		
		private string _ApellidoMaterno;
		
		private string _Nombre1;
		
		private string _Nombre2;
		
		private string _desApellidos;
		
		private string _desNombres;
		
		private string _codRegAreaEmpleado;
		
		private string _codRegCategoria;
		
		private string _codRegEstadoCivil;
		
		private string _codRegGrupoSanguineo;
		
		private System.Nullable<System.DateTime> _fecNacimiento;
		
		private System.Nullable<System.DateTime> _fecAltaLaboral;
		
		private System.Nullable<System.DateTime> _fecBajaLaboral;
		
		private decimal _monSueldoBasico;
		
		private decimal _porComisionXVenta;
		
		private char _indSexo;
		
		private bool _indVendedor;
		
		private bool _indActivo;
		
		private string _segUsuarioCrea;
		
		private string _segUsuarioEdita;
		
		private System.DateTime _segFechaCrea;
		
		private System.Nullable<System.DateTime> _segFechaEdita;
		
		private string _segMaquina;
		
		private string _codPlanilla;
		
		private string _desCorreoElectronico;
		
		private string _codPersonaNaturalNombre;
		
		private string _codNombreComercialNombre;
		
		private string _codRegAreaEmpleadoNombre;
		
		private string _codRegCategoriaNombre;
		
		private string _codRegEstadoCivilNombre;
		
		private string _codRegGrupoSanguineoNombre;
		
		private string _desImagenNombre;
		
		public omgc_S_EmpleadoResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codEmpresa", DbType="Int NOT NULL")]
		public int codEmpresa
		{
			get
			{
				return this._codEmpresa;
			}
			set
			{
				if ((this._codEmpresa != value))
				{
					this._codEmpresa = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codEmpleado", DbType="Int NOT NULL")]
		public int codEmpleado
		{
			get
			{
				return this._codEmpleado;
			}
			set
			{
				if ((this._codEmpleado != value))
				{
					this._codEmpleado = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codPersonaEmpresa", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string codPersonaEmpresa
		{
			get
			{
				return this._codPersonaEmpresa;
			}
			set
			{
				if ((this._codPersonaEmpresa != value))
				{
					this._codPersonaEmpresa = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codPersonaNatural", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string codPersonaNatural
		{
			get
			{
				return this._codPersonaNatural;
			}
			set
			{
				if ((this._codPersonaNatural != value))
				{
					this._codPersonaNatural = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApellidoPaterno", DbType="VarChar(40)")]
		public string ApellidoPaterno
		{
			get
			{
				return this._ApellidoPaterno;
			}
			set
			{
				if ((this._ApellidoPaterno != value))
				{
					this._ApellidoPaterno = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApellidoMaterno", DbType="VarChar(40)")]
		public string ApellidoMaterno
		{
			get
			{
				return this._ApellidoMaterno;
			}
			set
			{
				if ((this._ApellidoMaterno != value))
				{
					this._ApellidoMaterno = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre1", DbType="VarChar(60)")]
		public string Nombre1
		{
			get
			{
				return this._Nombre1;
			}
			set
			{
				if ((this._Nombre1 != value))
				{
					this._Nombre1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre2", DbType="VarChar(30)")]
		public string Nombre2
		{
			get
			{
				return this._Nombre2;
			}
			set
			{
				if ((this._Nombre2 != value))
				{
					this._Nombre2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desApellidos", DbType="VarChar(81) NOT NULL", CanBeNull=false)]
		public string desApellidos
		{
			get
			{
				return this._desApellidos;
			}
			set
			{
				if ((this._desApellidos != value))
				{
					this._desApellidos = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desNombres", DbType="VarChar(91) NOT NULL", CanBeNull=false)]
		public string desNombres
		{
			get
			{
				return this._desNombres;
			}
			set
			{
				if ((this._desNombres != value))
				{
					this._desNombres = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codRegAreaEmpleado", DbType="VarChar(17)")]
		public string codRegAreaEmpleado
		{
			get
			{
				return this._codRegAreaEmpleado;
			}
			set
			{
				if ((this._codRegAreaEmpleado != value))
				{
					this._codRegAreaEmpleado = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codRegCategoria", DbType="VarChar(17)")]
		public string codRegCategoria
		{
			get
			{
				return this._codRegCategoria;
			}
			set
			{
				if ((this._codRegCategoria != value))
				{
					this._codRegCategoria = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codRegEstadoCivil", DbType="VarChar(17)")]
		public string codRegEstadoCivil
		{
			get
			{
				return this._codRegEstadoCivil;
			}
			set
			{
				if ((this._codRegEstadoCivil != value))
				{
					this._codRegEstadoCivil = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codRegGrupoSanguineo", DbType="VarChar(17)")]
		public string codRegGrupoSanguineo
		{
			get
			{
				return this._codRegGrupoSanguineo;
			}
			set
			{
				if ((this._codRegGrupoSanguineo != value))
				{
					this._codRegGrupoSanguineo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fecNacimiento", DbType="DateTime")]
		public System.Nullable<System.DateTime> fecNacimiento
		{
			get
			{
				return this._fecNacimiento;
			}
			set
			{
				if ((this._fecNacimiento != value))
				{
					this._fecNacimiento = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fecAltaLaboral", DbType="DateTime")]
		public System.Nullable<System.DateTime> fecAltaLaboral
		{
			get
			{
				return this._fecAltaLaboral;
			}
			set
			{
				if ((this._fecAltaLaboral != value))
				{
					this._fecAltaLaboral = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fecBajaLaboral", DbType="DateTime")]
		public System.Nullable<System.DateTime> fecBajaLaboral
		{
			get
			{
				return this._fecBajaLaboral;
			}
			set
			{
				if ((this._fecBajaLaboral != value))
				{
					this._fecBajaLaboral = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_monSueldoBasico", DbType="Decimal(15,4) NOT NULL")]
		public decimal monSueldoBasico
		{
			get
			{
				return this._monSueldoBasico;
			}
			set
			{
				if ((this._monSueldoBasico != value))
				{
					this._monSueldoBasico = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_porComisionXVenta", DbType="Decimal(10,4) NOT NULL")]
		public decimal porComisionXVenta
		{
			get
			{
				return this._porComisionXVenta;
			}
			set
			{
				if ((this._porComisionXVenta != value))
				{
					this._porComisionXVenta = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_indSexo", DbType="Char(1) NOT NULL")]
		public char indSexo
		{
			get
			{
				return this._indSexo;
			}
			set
			{
				if ((this._indSexo != value))
				{
					this._indSexo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_indVendedor", DbType="Bit NOT NULL")]
		public bool indVendedor
		{
			get
			{
				return this._indVendedor;
			}
			set
			{
				if ((this._indVendedor != value))
				{
					this._indVendedor = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segUsuarioCrea", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segUsuarioEdita", DbType="VarChar(50)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segMaquina", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codPlanilla", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string codPlanilla
		{
			get
			{
				return this._codPlanilla;
			}
			set
			{
				if ((this._codPlanilla != value))
				{
					this._codPlanilla = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desCorreoElectronico", DbType="VarChar(80)")]
		public string desCorreoElectronico
		{
			get
			{
				return this._desCorreoElectronico;
			}
			set
			{
				if ((this._desCorreoElectronico != value))
				{
					this._desCorreoElectronico = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codPersonaNaturalNombre", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string codPersonaNaturalNombre
		{
			get
			{
				return this._codPersonaNaturalNombre;
			}
			set
			{
				if ((this._codPersonaNaturalNombre != value))
				{
					this._codPersonaNaturalNombre = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codNombreComercialNombre", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string codNombreComercialNombre
		{
			get
			{
				return this._codNombreComercialNombre;
			}
			set
			{
				if ((this._codNombreComercialNombre != value))
				{
					this._codNombreComercialNombre = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codRegAreaEmpleadoNombre", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string codRegAreaEmpleadoNombre
		{
			get
			{
				return this._codRegAreaEmpleadoNombre;
			}
			set
			{
				if ((this._codRegAreaEmpleadoNombre != value))
				{
					this._codRegAreaEmpleadoNombre = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codRegCategoriaNombre", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string codRegCategoriaNombre
		{
			get
			{
				return this._codRegCategoriaNombre;
			}
			set
			{
				if ((this._codRegCategoriaNombre != value))
				{
					this._codRegCategoriaNombre = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codRegEstadoCivilNombre", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string codRegEstadoCivilNombre
		{
			get
			{
				return this._codRegEstadoCivilNombre;
			}
			set
			{
				if ((this._codRegEstadoCivilNombre != value))
				{
					this._codRegEstadoCivilNombre = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codRegGrupoSanguineoNombre", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string codRegGrupoSanguineoNombre
		{
			get
			{
				return this._codRegGrupoSanguineoNombre;
			}
			set
			{
				if ((this._codRegGrupoSanguineoNombre != value))
				{
					this._codRegGrupoSanguineoNombre = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desImagenNombre", DbType="VarChar(50)")]
		public string desImagenNombre
		{
			get
			{
				return this._desImagenNombre;
			}
			set
			{
				if ((this._desImagenNombre != value))
				{
					this._desImagenNombre = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
