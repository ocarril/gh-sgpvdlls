namespace CROM.Tools.Config
{
    using CROM.Tools.Comun.settings;

    public static class ConfiguracionFileXML
    {
        public static string GetSistemaInicio()
        {
            return GlobalSettings.GetDEFAULT_SistemaInicio();
        }
    }

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 06/04/2014-06:27:34 p.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Maestros.Configuracion.cs]
    /// </summary>
    public class ConfigValor
    {
        public int codConfiguracion { get; set; }
        public string codKeyConfig { get; set; }
        public string codTabla { get; set; }
        public string indOrden { get; set; }
        public string indTipoValor { get; set; }
        public string desValor { get; set; }
        public string desNombre { get; set; }
        public string gloDescripcion { get; set; }
        public bool indGenerico { get; set; }
        public bool indActivo { get; set; }
    }

    public enum ConfigTool
    {
        #region CODIGO COMENTADO


        /*
         * 
        DEFAULT_Doc_NotaIngreso,    //01
        DEFAULT_Doc_NotaSalida,     //02
        DEFAULT_Doc_Inventarios,    //03
        DEFAULT_NotaSalidaEstado,   //04
        DEFAULT_NotaIngrEstado,     //05
        DEFAULT_Movim_Entrada,      //06
        DEFAULT_Movim_Salida,       //07    
        DEFAULT_Movim_Mermas,       //08
        DEFAULT_Movim_Devolucion,   //09
        DEFAULT_Merca_PorRegular,   //10
        DEFAULT_Movim_InvCierre,    //11
        DEFAULT_Impuesto_Ventas,    //12
        DEFAULT_Merca_Retirada,     //13
        DEFAULT_Merca_Consignacion, //14
        DEFAULT_EstadoDeLetraANU,   //15
        DEFAULT_EstadoDeLetraPTT,   //16
        DEFAULT_DestinoCliente,     //17
        DEFAULT_fmt_Letra,          //18
        DEFAULT_Docum_OI,           //19
        DEFAULT_AsigProveed,        //20
        EST_FAC_Emitida,            //21
        DEFAULT_PathOI,             //22
        DEFAULT_Merca_Aduana,       //23
        DEFAULT_Merca_Apto,         //24
        DEFAULT_Importaciones,      //25
        EST_OIM_Pendiente,          //26
        DEFAULT_GastoFOB,           //27
        DEFAULT_Docum_DUA,          //28
        EST_OIM_Cerrado,            //29
        EST_DUA_Pendiente,          //30
        EST_DUA_Nacionalizado,      //31
        DEFAULT_DestinoProveed,     //32
        //PER_TP_Proveedor,           //33
        //PER_TP_Cliente,             //34
        //PER_TP_Transporte,          //35
        //PER_TP_Banco,               //36
        DEFAULT_LinkImportacion,    //37
        EST_FAC_Archivado,          //38
        EST_GRE_Archivado,          //39
        EST_COT_Archivado,          //40
        EST_BVT_Archivado,          //41
        DEFAULT_LinkCROM,           //42
        DEFAULT_MonedaNac,          //43
        DEFAULT_MonedaInt,          //44
        EST_FAC_Cancelada,          //45
        DEFAULT_MaximoDescuento,    //46
        DEFAULT_MaximoComision,     //47
        DEFAULT_MinimoDescuento,    //48
        DEFAULT_MinimoComision,     //49
        DEFAULT_MargenUtilidad,     //50


        DEFAULT_Docum_ODP,          //51
        EST_ODP_Pendiente,          //52
        EST_ODP_Cerrado,            //53
        DEFAULT_Path_ODP,           //54
        DEFAULT_AsigCliente,        //55

        DEFAULT_Exten_ODP,          //56
        DEFAULT_SizeFile_ODP,       //57

        DEFAULT_Valid_TCambio,          //58 (2015-01-08)
        DEFAULT_Logo_Web,               //59 (2015-01-08)
        DEFAULT_Titulo_Web,             //60 (2015-01-08)

        //DEFAULT_PersJuridica,           //61 (2015-25-10)
        //DEFAULT_Atributo_Domicilio,     //62 (2015-25-10)
        DEFAULT_Atributo_Telefono,      //63 (2015-25-10)
        DEFAULT_AsistenciaValores,      //64 (2015-25-10)
        DEFAULT_AsistenciaLogicos,      //65 (2015-25-10)

        DEFAULT_StockMinimo,            //66 (2015-25-10)
        DEFAULT_StockMaximo,            //67 (2015-25-10)

       // DEFAULT_Atributo_DomicFiscal,   //68 (2015-25-04)
        DEFAULT_Atributo_NumerRUC,      //69 (2015-25-04)

        DEFAULT_Size_FotoPersonas,          //70 (2015-25-04)
        DEFAULT_Path_Empleados,             //71 (2015-25-04)
        DEFAULT_Path_Productos,             //72 (2015-25-04)
        DEFAULT_DestinoInterno,             //73 (2015-16-08)
        //DEFAULT_LinkTipoCambio,             //74 (2015-20-08)
        DEFAULT_Size_FotoProducto,          //75 (2015-28-08)
        DEFAULT_Exten_Imagenes,             //76 (2015-28-08)

        EST_EQUI_Vigente,                   //77 (2015-10-13)
        EST_EQUI_Cerrado,                   //78 (2015-10-13)
        DEFAULT_Docum_EQUI,                 //79 (2015-10-13)
        DEFAULT_Docum_MNTO,                 //80 (2015-10-13)
        EST_MNTO_Pendiente,                 //81 (2015-10-15)
        EST_MNTO_Cerrado,                   //82 (2015-10-15)
        DEFAULT_Calc_IGV_Horiz,             //83 (2015-12-30)

        DEFAULT_PrefijoPtoVta,              //84 (2016-01-02)
        //DEFAULT_Owner,                      //85 (2016-01-02)
        DEFAULT_Size_FotoLogotipo,          //86 (2016-01-02)
        DEFAULT_TrabajaDeposito,            //87 (2016-01-02)
        DEFAULT_DatosWeb,                   //88 (2016-01-02)
        DEFAULT_PersonaPorDefecto,          //89 (2016-01-02)
        //DEFAULT_PersonaNatural,             //90 (2016-01-02)
        DEFAULT_PersonaVendedor,            //91 (2016-01-02)
        //DEFAULT_PersonaClientes,            //92 (2016-01-02)
        //DEFAULT_PersonaProveedores,         //93 (2016-01-02)
        DEFAULT_PersonaTransporte,          //94 (2016-01-02)
        DEFAULT_PersonaBancos,              //95 (2016-01-02)
        DEFAULT_CategEmpleado,              //96 (2016-01-02)
        DEFAULT_Telefono1Persona,           //97 (2016-01-02)
        DEFAULT_Telefono2Persona,           //98 (2016-01-02)
        DEFAULT_SitioWEBPersona,            //99 (2016-01-02)
        DEFAULT_EmailPersona,               //100(2016-01-02)
        DEFAULT_FirmaPersona,               //101(2016-01-02)


        DEFAULT_Cliente,                    //102(2016-01-03) 					
        DEFAULT_Proveedor,                  //103(2016-01-03) 									
        DEFAULT_EmpTransporte,              //104(2016-01-03) 								
        DEFAULT_Path_Sistema,               //105(2016-01-03) 								
        DEFAULT_Path_Exportacion,           //106(2016-01-03) 							
        DEFAULT_Path_Importacion,           //107(2016-01-03) 							
        DEFAULT_Movim_Venta,                //108(2016-01-03) 									
        DEFAULT_Movim_Compra,               //109(2016-01-03) 								
        DEFAULT_Movim_SInicial,             //110(2016-01-03) 								
        DEFAULT_Movim_VentaDevol,           //111(2016-01-03) 							
        DEFAULT_Movim_VentaRetiro,          //112(2016-01-03) 							
        DEFAULT_Movim_NotCredDevol,         //113(2016-01-03) 							
        DEFAULT_CondicionVenta,             //114(2016-01-03) 								
        DEFAULT_CondicionCompra,            //115(2016-01-03) 								
        DEFAULT_MotivoAnula,                //116(2016-01-03) 									
        DEFAULT_Producto,                   //117(2016-01-03) 									
        //DEFAULT_DimensionUM,                //118(2016-01-03) 									
        DEFAULT_UnidadMedida,               //119(2016-01-03) 								
        DEFAULT_ProductoMarca,              //120(2016-01-03) 								
        DEFAULT_ProductoCateg,              //121(2016-01-03) 								
        DEFAULT_AlmacenPrincipal,           //122(2016-01-03) 							
        DEFAULT_CentroProduccion,           //123(2016-01-03) 							
        DEFAULT_SectorAlmacenami,           //124(2016-01-03) 							
        DEFAULT_SectorDeVenta,              //125(2016-01-03) 								
        DEFAULT_ProducTerminado,            //126(2016-01-03) 								
        DEFAULT_ProducMaterPrim,            //127(2016-01-03) 								
        DEFAULT_ProducEnvaseEmb,            //128(2016-01-03) 								
        DEFAULT_Impuesto_Producto,          //129(2016-01-03) 							
        DEFAULT_HabilitaCaja,               //130(2016-01-03) 								
        DEFAULT_AperturaCajaAuto,           //131(2016-01-03) 							
        DEFAULT_DiferCierreCaja,            //132(2016-01-03) 								
        DEFAULT_HoraTurnoManana,            //133(2016-01-03) 								
        DEFAULT_TipoDeTurno,                //134(2016-01-03) 									
        DEFAULT_Movim_InvInicial,           //135(2016-01-03) 							
        DEFAULT_Doc_InventEstado,           //136(2016-01-03) 							
        DEFAULT_Doc_GuiaRemUso,             //137(2016-01-03) 								
        DEFAULT_Ubigeo,                     //138(2016-01-03) 										
        DEFAULT_Formato_Archivo,            //139(2016-01-03) 								
        DEFAULT_SizeFTransferMB,            //140(2016-01-03) 								
        DEFAULT_Impuesto_Desctos,           //141(2016-01-03) 							
        DEFAULT_FPago_Efectivo,             //142(2016-01-03) 								
        DEFAULT_OpacidadWindow,             //143(2016-01-03) 								
        DEFAULT_MaxDiasCredito,             //144(2016-01-03) 								
        DEFAULT_CantidadDecimals,           //145(2016-01-03) 							
        DEFAULT_ActualizaCostos,            //146(2016-01-03) 								
        DEFAULT_LeyendaFactura,             //147(2016-01-03) 								
        DEFAULT_DiasAntesConsultas,         //148(2016-01-03) 							
        DEFAULT_EliminacionMaestros,        //149(2016-01-03) 							
        DEFAULT_EliminacionMovimien,        //150(2016-01-03) 							
        DEFAULT_PonerCantiArticTick,        //151(2016-01-03) 							
        DEFAULT_PonerNombreVendImpF,        //152(2016-01-03) 							
        DEFAULT_WidthPantalla,              //153(2016-01-03) 								
        DEFAULT_HeightPantalla,             //154(2016-01-03) 								
        DEFAULT_WidthPantallaP,             //155(2016-01-03) 								
        DEFAULT_HeightPantallaP,            //156(2016-01-03) 								
        //DEFAULT_URL_TipoCambio,             //157(2016-01-03) 								
        DEFAULT_VerAvisoDEMOS,              //158(2016-01-03) 								
        DEFAULT_CotizPersonaFirma,          //159(2016-01-03) 							
        DEFAULT_CotizNota001,               //160(2016-01-03) 								
        DEFAULT_CotizNota002,               //161(2016-01-03) 								
        DEFAULT_ListaPrecioCompra,          //162(2016-01-03) 							
        DEFAULT_ListaPrecioVenta,           //163(2016-01-03) 							
        DEFAULT_Doc_Cotizacion,             //164(2016-01-03) 								
        DEFAULT_Doc_FacturaProveedor,       //165(2016-01-03) 						
        DEFAULT_Doc_FacturaProvLocal,       //166(2016-01-03) 					
        DEFAULT_DiasValidezCotiz,           //167(2016-01-03) 							
        DEFAULT_RolAdmin,                   //168(2016-01-03) 					
        DEFAULT_EstadoDeLetra,              //169(2016-01-03) 					
        DEFAULT_EstadoDeLetraCAN,           //170(2016-01-03) 							
        DEFAULT_MercaderApto,               //171(2016-01-03) 								
        DEFAULT_MercaderConsig,             //172(2016-01-03) 								
        DEFAULT_MercaderMalogra,            //173(2016-01-03) 								
        DEFAULT_MercaderVendida,            //174(2016-01-03) 								
        DEFAULT_Doc_GuiaRemConsig,          //175(2016-01-03) 							
        DEFAULT_Doc_GuiaRemEmitida,         //176(2016-01-03) 							
        DEFAULT_Doc_GuiaRemArchivada,       //177(2016-01-03) 						
        DEFAULT_Doc_CotizaArchivada,        //178(2016-01-03) 							
        DEFAULT_VerAvisoPrecios,            //179(2016-01-03) 		
        //DEFAULT_KeyCROM,                    //180(2016-01-07)
        DEFAULT_Time60,                     //181(2016-01-07)
        DEFAULT_Atributo_NumerDNI,          //182(2016-03-01)
        DEFAULT_TiempoPlazoCredito,         //183(2016-03-01)
        DEFAULT_ConcatenaNumDias,           //184(2018-02-04)
        DEFAULT_LogoAdicionalEmp,           //185(2018-02-04)
*/
        #endregion

          DEFAULT_ActualizaCostos
        , DEFAULT_AlmacenPrincipal
        , DEFAULT_AperturaCajaAuto
        , DEFAULT_AsigCliente
        , DEFAULT_AsigProveed
        , DEFAULT_AsistenciaLogicos
        , DEFAULT_AsistenciaValores

        , DEFAULT_Atributo_NumerDNI
        , DEFAULT_Atributo_NumerRUC
        , DEFAULT_Atributo_Telefono

        , DEFAULT_Calc_IGV_Horiz
        , DEFAULT_CantidadDecimals
        , DEFAULT_CategEmpleado
        , DEFAULT_CentroProduccion
        , DEFAULT_Cliente
        , DEFAULT_ConcatenaNumDias
        , DEFAULT_CondicionCompra
        , DEFAULT_CondicionVenta
        , DEFAULT_CotizNota001
        , DEFAULT_CotizNota002
        , DEFAULT_CotizPersonaFirma
        , DEFAULT_DatosWeb

        , DEFAULT_DestinoCliente
        , DEFAULT_DestinoInterno
        , DEFAULT_DestinoProveed

        , DEFAULT_DiasAntesConsultas
        , DEFAULT_DiasValidezCotiz
        , DEFAULT_DiferCierreCaja

        , DEFAULT_Doc_CotizaArchivada
        , DEFAULT_Doc_Cotizacion
        , DEFAULT_Doc_FacturaProveedor
        , DEFAULT_Doc_FacturaProvLocal
        , DEFAULT_Doc_GuiaRemArchivada
        , DEFAULT_Doc_GuiaRemConsig
        , DEFAULT_Doc_GuiaRemEmitida
        , DEFAULT_Doc_GuiaRemUso
        , DEFAULT_Doc_Inventarios
        , DEFAULT_Doc_InventEstado
        , DEFAULT_Doc_NotaIngreso
        , DEFAULT_Doc_NotaSalida

        , DEFAULT_Docum_DUA
        , DEFAULT_Docum_EQUI
        , DEFAULT_Docum_MNTO
        , DEFAULT_Docum_ODP
        , DEFAULT_Docum_OI

        , DEFAULT_EliminacionMaestros
        , DEFAULT_EliminacionMovimien
        , DEFAULT_EmailPersona
        , DEFAULT_EmpTransporte

        , DEFAULT_EstadoDeLetra
        , DEFAULT_EstadoDeLetraANU
        , DEFAULT_EstadoDeLetraCAN
        , DEFAULT_EstadoDeLetraPTT

        , DEFAULT_Exten_Imagenes
        , DEFAULT_Exten_ODP
        , DEFAULT_FirmaPersona
        , DEFAULT_fmt_Letra
        , DEFAULT_Formato_Archivo
        , DEFAULT_FPago_Efectivo
        , DEFAULT_GastoFOB
        , DEFAULT_HabilitaCaja
        , DEFAULT_HeightPantalla
        , DEFAULT_HeightPantallaP
        , DEFAULT_HoraTurnoManana
        , DEFAULT_Importaciones
        , DEFAULT_Impuesto_Desctos
        , DEFAULT_Impuesto_Producto
        , DEFAULT_Impuesto_Ventas
        , DEFAULT_LeyendaFactura

        , DEFAULT_LinkImportacion

        , DEFAULT_ListaPrecioCompra
        , DEFAULT_ListaPrecioVenta
        , DEFAULT_Logo_Web
        , DEFAULT_LogoAdicionalEmp
        , DEFAULT_MargenUtilidad
        , DEFAULT_MaxDiasCredito
        , DEFAULT_MaximoComision
        , DEFAULT_MaximoDescuento

        , DEFAULT_Merca_Aduana
        , DEFAULT_Merca_Apto
        , DEFAULT_Merca_Consignacion
        , DEFAULT_Merca_PorRegular
        , DEFAULT_Merca_Retirada
        , DEFAULT_MercaderApto
        , DEFAULT_MercaderConsig
        , DEFAULT_MercaderMalogra
        , DEFAULT_MercaderVendida

        , DEFAULT_MinimoComision
        , DEFAULT_MinimoDescuento

        , DEFAULT_MonedaInt
        , DEFAULT_MonedaNac

        , DEFAULT_MotivoAnula

        , DEFAULT_Movim_Compra
        , DEFAULT_Movim_Devolucion
        , DEFAULT_Movim_Entrada
        , DEFAULT_Movim_InvCierre
        , DEFAULT_Movim_InvInicial
        , DEFAULT_Movim_Mermas
        , DEFAULT_Movim_NotCredDevol
        , DEFAULT_Movim_Salida
        , DEFAULT_Movim_SInicial
        , DEFAULT_Movim_Venta
        , DEFAULT_Movim_VentaDevol
        , DEFAULT_Movim_VentaRetiro

        , DEFAULT_NotaIngrEstado
        , DEFAULT_NotaSalidaEstado
        , DEFAULT_OpacidadWindow
        , DEFAULT_Path_Empleados
        , DEFAULT_Path_Exportacion
        , DEFAULT_Path_Importacion
        , DEFAULT_Path_ODP
        , DEFAULT_Path_Productos
        , DEFAULT_Path_Sistema
        , DEFAULT_PathOI
        , DEFAULT_PersonaBancos
        , DEFAULT_PersonaPorDefecto
        , DEFAULT_PersonaTransporte
        , DEFAULT_PersonaVendedor
        , DEFAULT_PonerCantiArticTick
        , DEFAULT_PonerNombreVendImpF
        , DEFAULT_PrefijoPtoVta
        , DEFAULT_ProducEnvaseEmb
        , DEFAULT_ProducMaterPrim
        , DEFAULT_ProducTerminado
        , DEFAULT_Producto
        , DEFAULT_ProductoCateg
        , DEFAULT_ProductoMarca
        , DEFAULT_Proveedor
        , DEFAULT_RolAdmin
        , DEFAULT_SectorAlmacenami
        , DEFAULT_SectorDeVenta

        , DEFAULT_SFS_DOCUMENTO
        , DEFAULT_SFS_MAIL_CLAVE
        , DEFAULT_SFS_MAIL_CUENTA
        , DEFAULT_SFS_MAIL_PUERTO
        , DEFAULT_SFS_MAIL_SMTP
        , DEFAULT_SFS_MAIL_SSL
        , DEFAULT_SFS_MAIL_NOTA
        , DEFAULT_SFS_MAIL_AVISO
        , DEFAULT_SFS_MAIL_SUBJECT

        , DEFAULT_SFS_RUTA_ACEPTADOS
        , DEFAULT_SFS_RUTA_BANDEJA
        , DEFAULT_SFS_RUTA_BAT
        , DEFAULT_SFS_RUTA_CODIGOBARRAS
        , DEFAULT_SFS_RUTA_CONTING
        , DEFAULT_SFS_RUTA_PDF
        , DEFAULT_SFS_RUTA_PLANOSSUNAT
        , DEFAULT_SFS_RUTA_FIRMADOS
        , DEFAULT_SFS_RUTA_SUNATBKP
        , DEFAULT_SFS_TIPOTRIBUTOISC
        , DEFAULT_SFS_UBL
        , DEFAULT_SFS_NUM_DIA_PLAZO
        , DEFAULT_SFS_MONTO_MIN_BVT_DNI
        , DEFAULT_SFS_NDIAS_ALERT_CD
        , DEFAULT_SFS_FECHA_FORMA_PAGO
        , DEFAULT_SFS_RUTA_CERTIFICADO
        , DEFAULT_SFS_CLAVE_CERTIFICADO
        , DEFAULT_SFS_RUTA_ENVIO_WS
        , DEFAULT_SFS_DOCUMENTO_GRE
        , DEFAULT_SFS_ENVIO_DIRECTO_GRE
        , DEFAULT_SFS_RUTA_ENVIO_ZIP
        , DEFAULT_SFS_TITULO_ENVIO_MAIL
        , DEFAULT_SFS_NOMBRE_PREFIJO_DOC

        , DEFAULT_SFS_CONSULTA_DOC_CLAVE
        , DEFAULT_SFS_CONSULTA_DOC_ID
        , DEFAULT_SFS_CONSULTA_API_TOKEN
        , DEFAULT_SFS_CONSULTA_API_VALID
        , DEFAULT_SFS_CONSULTA_API_GRNTY
        , DEFAULT_SFS_CONSULTA_API_SCOPE
        , DEFAULT_SFS_FLAG_BVT_RESUMEN


        , DEFAULT_SitioWEBPersona
        , DEFAULT_Size_FotoLogotipo
        , DEFAULT_Size_FotoPersonas
        , DEFAULT_Size_FotoProducto
        , DEFAULT_SizeFile_ODP
        , DEFAULT_SizeFTransferMB

        , DEFAULT_StockMaximo
        , DEFAULT_StockMinimo

        , DEFAULT_Telefono1Persona
        , DEFAULT_Telefono2Persona
        , DEFAULT_TiempoPlazoCredito
        , DEFAULT_Time60
        , DEFAULT_TipoDeTurno
        , DEFAULT_Titulo_Web
        , DEFAULT_TrabajaDeposito
        , DEFAULT_Ubigeo
        , DEFAULT_UnidadMedida
        , DEFAULT_Valid_TCambio
        , DEFAULT_VerAvisoDEMOS
        , DEFAULT_VerAvisoPrecios

        , DEFAULT_WidthPantalla
        , DEFAULT_WidthPantallaP

        , EST_BVT_Archivado
        , EST_COT_Archivado

        , EST_DUA_Nacionalizado
        , EST_DUA_Pendiente

        , EST_EQUI_Cerrado
        , EST_EQUI_Vigente

        , EST_FAC_Archivado
        , EST_FAC_Cancelada
        , EST_FAC_Emitida

        , EST_GRE_Archivado
        , EST_MNTO_Cerrado
        , EST_MNTO_Pendiente

        , EST_ODP_Cerrado
        , EST_ODP_Pendiente
        , EST_OIM_Cerrado
        , EST_OIM_Pendiente

        , DEFAULT_DetraccionPersonaBanco
        , DEFAULT_DetraccionFormaPago
        , DEFAULT_DetraccionServicio
    }
}
