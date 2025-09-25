using Microsoft.PowerBI.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navistar.Utils.Core
{
    public static class UrlConstants
    {
        // Routes
        public const string API_ROUTE_MENUS = "api/menu";

        public const string API_ROUTE_SECURITY = "api/security";
        public const string API_ROUTE_COUNTRY = "api/Pais";
        public const string API_ROUTE_HOLIDAY = "api/DiasFestivos";
        public const string API_ROUTE_ENTIDAD = "api/Entidades";
        public const string API_ROUTE_GROUP = "api/Grupos";
        public const string API_ROUTE_USER = "api/Usuarios";
        public const string API_ROUTE_ACTIVITY = "api/Actividades";
        public const string API_ROUTE_INCIDENTS = "api/Incidents";



        /** SECCION MENUS */
        public const string GET_MENU_APPS = "GetMenuApps";
        public const string GET_ESTRUCTURA_MENU_APPS = "GetEstructuraMenuApps";


        // Security
        public const string GET_USER_INFORMATION = "GetUserInformation";
        public const string GET_USER_INFORMATION_INTRANET = "GetUserInformationIntranet";
        public const string GET_USER_MENU = "GetUserMenu";
        public const string VALIDATE_USER_MENU = "ValidateUserMenu";


        //PARAM
        public const string GET_PARAM = "GetParam";

        //Dealer Relationship Management
        public const string API_ROUTE_APP_DEALER_RELATIONSHIP_MANAGEMENT = "api/DealerRelationshipManagement";
        public const string GET_ALL_VISIT = "GetAllVisit";
        public const string GET_VISIT = "GetVisit";
        public const string SAVE_VISIT = "SaveVisit";
        public const string UPDATE_VISIT = "UpdateVisit";
        public const string DELETE_VISIT = "DeleteVisit";

        public const string GET_BRANCH_LIST = "GetBranchListByEntidad";

        public const string GET_ALL_ENTITY = "GetAllEntity";
        public const string GET_ENTITY = "GetEntity";
        public const string GET_ENTITY_BY_COUNTRY = "GetEntityByCountry";

        public const string GET_ALL_ENTITY_TYPE = "GetAllEntityType";
        public const string GET_ENTITY_TYPE = "GetEntityType";
        public const string GET_USER_GROUP = "GetUserGroup";
        
        //GROUP
        public const string GET_ACTIVITY = "GetActivity";

        //GROUP
        public const string GET_GROUP = "GetGroup";

        //USER
        public const string GET_USERS = "GetUsers";

        //COUNTRY
        public const string GET_ALL_COUNTRY = "GetAllCountry";

        //INCIDENT
        public const string GET_INCIDENTS_TYPE = "GetInicidentType";
        public const string GET_INCIDENTS = "SaveInicident";
        public const string SAVE_INCIDENTS = "SaveInicident";

        public const string GET_DAYS_IN_RANGE = "GetDaysInRange";
        public const string VALIDATE_DAY_LIST = "ValidateDayList";
        public const string SAVE_DAY_LIST = "SaveDayList";
        public const string DOWNLOAD_TEMPLATE = "DownloadTemplate";
        public const string GET_STRATEGIES_SUMMARY = "GetStrategiesSummary";

        //ENTITY
        public const string SAVE_ENTITY= "SaveEntity";

    }

}
