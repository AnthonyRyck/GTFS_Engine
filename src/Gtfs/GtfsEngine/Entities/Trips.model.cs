using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GtfsEngine.Entities
{
	public partial class Trips
	{
		/// <summary>
		/// Retourne la Route pour ce voyage.
		/// </summary>
		public Routes RoutesFk { get { return GetFkRoutes.Invoke(this.route_id); } }

		public Func<string, Routes> GetFkRoutes { get; set; }


		/// <summary>
		/// Retourne la liste de StopTime pour ce voyage.
		/// </summary>
		public IEnumerable<StopTimes> StopTimesCollection { get { return GetStopTimes.Invoke(this.trip_id); } }

		public Func<string, IEnumerable<StopTimes>> GetStopTimes { get; set; }


		/// <summary>
		/// Retourne la liste des Shapes pour ce voyage.
		/// </summary>
		public IEnumerable<Shapes> ShapesCollection { get { return GetFkShapes.Invoke(this.shape_id); } }
		public Func<string, IEnumerable<Shapes>> GetFkShapes { get; set; }

		/// <summary>
		/// Retourne le service (Calendars) pour ce voyage.
		/// </summary>
		public Calendar GetCalendar { get { return GetServices.Invoke(this.service_id); } }
		public Func<string, Calendar> GetServices { get; set; }

		/// <summary>
		/// Retourne le premier horaire de début de ce voyage.
		/// </summary>
		/// <returns></returns>
		public TimeSpan GetStartTime()
		{
			return StopTimesCollection.Min(x => x.DepartTime);
		}

		/// <summary>
		/// Retourne la dernière heure d'arrivée sur ce voyage.
		/// </summary>
		/// <returns></returns>
		public TimeSpan GetLastTime()
		{
			return StopTimesCollection.Max(x => x.ArrivalTime);
		}
	}
}
