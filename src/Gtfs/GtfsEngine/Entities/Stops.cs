using System;
using System.Collections.Generic;
using System.Text;

namespace GtfsEngine.Entities
{
    /// <summary>
    /// Arrêts où les usagers peuvent monter et descendre. Définit également les stations et leurs entrées.
    /// </summary>
    public class Stops
    {
        public string stop_id { get; set; }
        public string stop_code { get; set; }
        public string stop_name { get; set; }
        public string stop_desc { get; set; }
        public double stop_lat { get; set; }
        public double stop_lon { get; set; }
        public string zone_id { get; set; }
        public string stop_url { get; set; }
        public int? location_type { get; set; }
        public string parent_station { get; set; }
        public string stop_timezone { get; set; }
        public int? wheelchair_boarding { get; set; }
        public string level_id { get; set; }
        public string platform_code { get; set; }
    }
}
