using System;
using System.Collections.Generic;
using System.Text;

namespace GtfsEngine.Entities
{
	public partial class StopTimes
	{
		public Stops StopsFk { get { return GetFkStops.Invoke(this.stop_id); } }

		public Func<string, Stops> GetFkStops { get; set; }



		public Trips TripsFk { get { return GetFkTrips.Invoke(this.trip_id); } }


		public Func<string, Trips> GetFkTrips { get; set; }



		public TimeSpan ArrivalTime { get { return TimeSpan.Parse(arrival_time); } }
		public TimeSpan DepartTime { get { return TimeSpan.Parse(departure_time); } }
	}
}
