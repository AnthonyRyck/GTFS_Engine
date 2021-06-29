using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GtfsEngine.Entities
{
    /// <summary>
    /// Trajets pour chaque itinéraire. Un trajet est une série d'au moins deux arrêts desservis à des horaires précis.
    /// </summary>
    public partial class Trips
    {
        public string route_id { get; set; }
        public string service_id { get; set; }
        public string trip_id { get; set; }
        public string trip_headsign { get; set; }
        public string trip_short_name { get; set; }
        public int? direction_id { get; set; }
        public string block_id { get; set; }
        public string shape_id { get; set; }
        public int? wheelchair_accessible { get; set; }
        public int? bikes_allowed { get; set; }
        public string trip_headsign_code { get; set; }


		public override string ToString()
		{
            StringBuilder builder = new StringBuilder();
            //builder.AppendJoin(',', route_id, service_id, trip_id, trip_headsign, trip_short_name, direction_id, block_id,
            //    shape_id, wheelchair_accessible, bikes_allowed, trip_headsign_code);

			TimeSpan arrive = this.StopTimesCollection.Min(x => x.ArrivalTime);
			TimeSpan depart = this.StopTimesCollection.Max(x => x.ArrivalTime);

			builder.AppendJoin(',', route_id, service_id, trip_id, trip_headsign, trip_short_name, direction_id, block_id,
							shape_id, wheelchair_accessible, bikes_allowed, trip_headsign_code, arrive, depart);

			return builder.ToString();
        }


	}
}
