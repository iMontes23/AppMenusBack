using System;
using System.Collections.Generic;
using System.Text;

namespace Navistar.Model.Request.ApiModels
{
    public class ApiVehicleParametersRequest
    {
        public VehicleParametersAction action { get; set; }
    }

    public class VehicleParametersAction
    {
        public string name { get; set; }

        public List<VehicleParameters> parameters { get; set; }
        public string session_token { get; set; }
    }

    public class VehicleParameters
    {
        public int vehicle_id { get; set; }
        public string license_nmbr { get; set; }
        public int? version { get; set; }
    }
}
