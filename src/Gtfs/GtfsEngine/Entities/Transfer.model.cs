using System;

namespace GtfsEngine.Entities
{
	public partial class Transfer
	{
        public Stops FromStopsFk { get { return GetFromFkStops.Invoke(this.from_stop_id); } }

		public Func<string, Stops> GetFromFkStops { get; set; }


        public Stops ToStopsFk { get { return GetToFkStops.Invoke(this.to_stop_id); } }

		public Func<string, Stops> GetToFkStops { get; set; }

    }
}