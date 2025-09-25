using System;
using System.Collections.Generic;
using System.Text;

namespace Navistar.Model.Request.ApiModels
{
    public class ApiTripEventsRequest
    {
        public TripEventsAction action { get; set; }
    }

    public class TripEventsAction
    {
        public string name { get; set; }

        public List<TripEventsParameters> parameters { get; set; }
        public string session_token { get; set; }
    }

    public class TripEventsParameters
    {
        public long drive_id { get; set; }
        public int? version { get; set; } = 3; //Version Default de la API Get Data más reciente
    }
}
