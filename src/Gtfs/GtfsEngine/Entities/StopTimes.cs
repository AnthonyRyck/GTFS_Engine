using System;
using System.Collections.Generic;
using System.Text;

namespace GtfsEngine.Entities
{
    /// <summary>
    /// Heures d'arrivée et de départ d'un véhicule depuis des arrêts spécifiques, pour chaque trajet.
    /// </summary>
    public partial class StopTimes
    {
        public string trip_id { get; set; }
        public string stop_id { get; set; }

        public string arrival_time { get; set; }
        public string departure_time { get; set; }


        public int stop_sequence { get; set; }
        public string stop_headsign { get; set; }
        public int? pickup_type { get; set; }
        public int? drop_off_type { get; set; }

		public int? continuous_pickup { get; set; }
		public int? continuous_drop_off { get; set; }

		public double? shape_dist_traveled { get; set; }
        public int? timepoint { get; set; }
    }
}
