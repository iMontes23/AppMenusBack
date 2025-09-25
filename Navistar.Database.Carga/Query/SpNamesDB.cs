namespace Navistar.Database.Carga.Query.Security
{
    public class SpNamesDB
    {
        public static readonly string SP_MENU_Y_MODULOS_POR_USUARIO = "appMenus.spS_MenuYModulosPorUsuario";
        //public static readonly string GET_USER_INFORMATION = "appMenus.SPS_ConsultaInformacionUsuario";
        public static readonly string GET_APP = "appMenus.SPS_ConsultaAplicacion";

        public static readonly string GET_MENUS_APPS= "appMenus.SPS_ConsultaMenusApps";
        public static readonly string GET_ARBOL_MENUS_APPS= "appMenus.SPS_ConsultaArbolMenus";

        public static readonly string GET_USER_INFORMATION = "appMenus.SP_GetUserByUsername";

        public static readonly string GET_USER = "appMenus.Sps_GetUser";

        public static readonly string GET_USER_APLICATION = "appMenus.SP_GetApplication";

        public static readonly string GET_USER_PERMISSIONS = "appMenus.SP_GetPermissions";

        public static readonly string SP_INSERT_DEFAULT_VISIT_BY_DAY = "appMenus.SP_InsertDefaultVisitsByDay";

        public static readonly string SP_GET_DISTRBUTOR_BRANCH = "appMenus.sp_GetDistributorBranch";

        public static readonly string SP_GET_CALENDAR = "appMenus.SP_workCalendar";

        public static readonly string SP_GET_CALENDAR_RANGO = "appMenus.SPS_workCalendarRange";

        public static readonly string SPS_GET_TCDRM_ENTIDADES = "appMenus.Sps_GetTCDRMEntidades";

        public static readonly string SPS_GET_TCDRM_ENTIDADES_BY_TYPE = "appMenus.Sps_GetTCDRMEntidadesByEntityType";

        public static readonly string SPS_GET_TCDRM_ENTIDADES_BY_USER = "appMenus.Sps_GetEntitiesByUser";

        public static readonly string SPS_TCDRM_PARAMETRO_BY_DESCRIPTION = "appMenus.Sps_TCDRM_PARAM_BY_DESCRIPTION";

        public static readonly string SPS_GET_USER_GROUP= "appMenus.Sps_GetUserGroup";

        public static readonly string SPS_GET_USER_GROUP_BY_STATUS = "appMenus.Sps_GetUserGroupByStatus";

        public static readonly string SPS_GET_TIPO_ENTIDAD = "appMenus.Sps_GetTCDRM_TipoEntidad";

        public static readonly string SPS_GET_REGISTRO_VISTA = "appMenus.Sps_GetTCDRM_RegistroVisita";

        public static readonly string SPI_GET_TEDRM_REGISTRO_VISITA = "appMenus.Spi_TEDRM_RegistroVisita";

        //GROUP
        public static readonly string SPS_GET_GROUP_BY_STACTIVO = "appMenus.Sps_GetTCDRM_GrupoBy_StActivo";

        //USER
        public static readonly string SPS_GET_USER_BY_STACTIVO = "appMenus.Sps_GetTCDRM_UserBy_StActivo";

        //PAISES
        public static readonly string SPS_GET_TCDRM_PAISES = "appMenus.Sps_GetTCDRM_Pais";
        public static readonly string SPS_GET_TCDRM_COUNTRY_BY_ID = "appMenus.Sps_GetTCDRM_PaisById";


        //DIAS FESTIVOS
        public static readonly string SPS_GET_TCDRM_DIAS_FESTIVOS = "appMenus.Sps_GetTCDRM_Dias_festivos";
        public static readonly string SPI_SAVE_TCDRM_DIAS_FESTIVOS = "appMenus.Spi_SaveListTCDRM_Dias_festivos";
        public static readonly string SPI_SAVE_TCDRM_DUPLICADO_DIAS_FESTIVOS = "appMenus.Sp_GetDuplicatedDiasFestivos";
        public static readonly string SPS_GET_RESUMEN_OBJETIVOS_ESTRATEGIAS = "appMenus.SPs_GetResumenObjetivosEstrategias";

        //INSERT ENTITY
        public static readonly string SPI_GET_TCDRM_REGISTRO_ENTITY ="appMenus.Spi_TCDRM_Entidades";

        //INCIDENTES
        public static readonly string SPS_TCDRM_INCIDENTES_TYPE = "appMenus.Sps_GetTCDRM_Incidentes_type";
        public static readonly string SPS_TCDRM_INCIDENTES = "appMenus.Sps_GetTCDRM_Incidentes";
        public static readonly string SPI_TCDRM_INCIDENTES = "appMenus.Spi_TCDRM_Incidentes";

    }
}
