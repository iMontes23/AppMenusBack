using System;
using System.Collections.Generic;
using System.Text;

namespace Navistar.Model.Request.ApiModels
{
    public class ApiVehicleTripsRequest
    {
        public VehicleTripsAction action { get; set; }
    }

    public class VehicleTripsAction
    {
        public string name { get; set; }

        public List<VehicleTripsParameters> parameters { get; set; }
        public string session_token { get; set; }
    }

    public class VehicleTripsParameters
    {
        public int? vehicle_id { get; set; }
        public string license_number { get; set; }
        public string driver_id { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public int? version { get; set; }
    }
}
