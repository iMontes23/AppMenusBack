using System;
using System.Collections.Generic;
using System.Text;

namespace Navistar.Model.Request.ApiModels
{
    public class ApiVehicleDataRequest
    {
        public VehicleDataAction action { get; set; }
    }

    public class VehicleDataAction
    {
        public string name { get; set; }

        public List<VehicleDataParameters> parameters { get; set; }
        public string session_token { get; set; }
    }

    public class VehicleDataParameters
    {
        public string last_time { get; set; }
        public string license_nmbr { get; set; }
        public string group_id { get; set; }
        public string vin { get; set; }
        public int? version { get; set; } = 4; //Version Default de la API Get Data más reciente
    }
}
