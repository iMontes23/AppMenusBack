using System;
using System.Collections.Generic;
using System.Text;

namespace Navistar.Database.Carga.Query
{
    public static class ArgumentsNamesDB
    {

        public const string USER_ID = "@UserID";
        public const string NTUSER = "@NTUser";
        public const string APP_CODE = "@AppCode";
        public const string OPTION_CODE = "@OptionCode";
        public const string IS_APP_QUERY = "@IsAppQuery";

        public const string DATA_ID = "@cd_id";
        public const string NT_USER = "@NTUser";
        public const string CD_USER = "@cdUsuario";
        public const string CD_AUX = "@cdAux";
        public const string BRANCH_ID = "@cd_sucursal";
        public const string CALENDAR_ID = "@cd_fecha";

        //parameter config
        public const string PARAM_DESCRIPTION = "@tx_descripcion";

        public const string INPUT_DATE = "@InputDate";

        //VISIT
        public const string VISIT_RECORD_ID = "@cd_registrovisita";
        public const string USER_VISIT_ID = "@cd_usuario";
        public const string VISIT_TYPE_ID = "@cd_tipovisita";
        public const string ENTITY_ID = "@cd_entidad";
        public const string GFX_ID = "@cd_gfx";
        public const string VISIT_DATE = "@ts_fechavisita";
        public const string FINAL_VISIT_DATE = "@ts_fechaVisitaFin";
        public const string REASON = "@tx_motivo";
        public const string CREATED_BY = "@nb_usuariocreacion";
        public const string CREATED_AT = "@ts_creacion";
        public const string MODIFIED_BY = "@nb_usuariomodificacion";
        public const string MODIFIED_AT = "@ts_modificacion";
        public const string IS_ACTIVE = "@st_activo";
        public const string ADD_BY = "@tx_agregadopor";
        public const string PATH_ATTACHED_FILE = "@tx_rutaArchivoAdjunto";

        public const string CD_PAIS = "@cd_pais";

        public const string CD_TIPO = "@cd_tipo";
        public const string START_DATE= "@startDate";
        public const string END_DATE = "@endDate";

        public const string FECHA_INICIO = "@FechaInicio";
        public const string FECHA_FIN = "@FechaFin";
        public const string GRUPOS = "@grupos";
        public const string USUARIOS = "@usuarios";


        //Entity
        public const string TIPO_ENTIDAD = "@tp_TipoEntidad"; 
		public const string NOMBRE_ENTITY = "@nb_Nombre";
        public const string RFC = "@cd_rfc";
        public const string CUENTA_DISTRIBUIDOR = "@cd_CuentaDistribuidor";
        public const string TIPO_REGISTRO = "@cd_tipoUsuario";
        public const string CD_GRUPO = "@cd_grupo";
    }
}
