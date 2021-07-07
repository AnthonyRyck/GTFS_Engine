using GtfsEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GtfsEngine
{
	public class GtfsModel
	{
		#region Properties

		/// <summary>
		/// Agences de transports en commun ayant un service représenté dans cet ensemble de données.
		/// </summary>
		public Dictionary<string, Agency> Agencies { get; private set; }

		/// <summary>
		/// Itinéraires en transports en commun. Un itinéraire est un ensemble de trajets 
		/// présentés aux usagers comme relevant du même service.
		/// </summary>
		public Dictionary<string, Routes> AllRoutes { get; private set; }

		/// <summary>
		/// Trajets pour chaque itinéraire. Un trajet est une série d'au moins deux arrêts desservis à des horaires précis.
		/// </summary>
		public Dictionary<string, Trips> AllTrips { get; private set; }

		/// <summary>
		/// Arrêts où les usagers peuvent monter et descendre. Définit également les stations et leurs entrées.
		/// </summary>
		public Dictionary<string, Stops> AllStops { get; private set; }

		/// <summary>
		/// Heures d'arrivée et de départ d'un véhicule depuis des arrêts spécifiques, pour chaque trajet.
		/// KEY = trip_ID, stop_ID, ID de séquence
		/// </summary>
		public Dictionary<string, StopTimes> AllStopTimes { get; private set; }

		/// <summary>
		/// Dates de service indiquées à l'aide d'un horaire hebdomadaire comportant des dates de départ 
		/// et d'arrivée. 
		/// Ce fichier est obligatoire, sauf si toutes les dates de service sont définies 
		/// dans calendar_dates.txt.
		/// </summary>
		public Dictionary<string, Calendar> Calendars { get; private set; }

		/// <summary>
		/// Exceptions pour les services définis dans le fichier calendar.txt. 
		/// Si calendar.txt est omis, le fichier calendar_dates.txt est alors obligatoire 
		/// et doit contenir toutes les dates du service.
		/// </summary>
		public Dictionary<string, CalendarDates> AllCalendarDates { get; private set; }

		/// <summary>
		/// Règles cartographiques du parcours des véhicules (parfois appelées alignements d'itinéraire).
		/// </summary>
		public Dictionary<string, List<Shapes>> AllShapes { get; private set; }



		public Dictionary<string, List<StopTimes>> StopTimesByTripsId { get; private set; }

		#endregion

		#region Constructeur


		public GtfsModel()
		{
			Agencies = new Dictionary<string, Agency>();
			AllRoutes = new Dictionary<string, Routes>();
			AllTrips = new Dictionary<string, Trips>();
			AllStops = new Dictionary<string, Stops>();
			AllStopTimes = new Dictionary<string, StopTimes>();
			Calendars = new Dictionary<string, Calendar>();
			AllCalendarDates = new Dictionary<string, CalendarDates>();
			AllShapes = new Dictionary<string, List<Shapes>>();
			StopTimesByTripsId = new Dictionary<string, List<StopTimes>>();
		}

		#endregion


		#region Public Methods

		#region Méthodes de recherche dans les Dico

		/// <summary>
		/// Retourne la Route par rapport à la clé donnée
		/// </summary>
		/// <param name="idRoute"></param>
		/// <returns></returns>
		public Routes GetRoute(string idRoute)
		{
			return AllRoutes[idRoute];
		}

		/// <summary>
		/// Retourne le voyage par rapport à la clé donnée
		/// </summary>
		/// <param name="idTrip"></param>
		/// <returns></returns>
		public Trips GetTrip(string idTrip)
		{
			return AllTrips[idTrip];
		}

		/// <summary>
		/// Retourne l'Arrêt par rapport à la clé donnée
		/// </summary>
		/// <param name="idStop"></param>
		/// <returns></returns>
		public Stops GetStop(string idStop)
		{
			return AllStops[idStop];
		}

		/// <summary>
		/// Retourne la liste des Shapes pour la clé donnée.
		/// </summary>
		/// <param name="keyShape"></param>
		/// <returns></returns>
		public List<Shapes> GetShapes(string keyShape)
		{
			return AllShapes[keyShape];
		}

		/// <summary>
		/// Retourne la liste des voyages par rapport à un ID de voyage.
		/// </summary>
		/// <param name="keyTripId"></param>
		/// <returns></returns>
		public IEnumerable<StopTimes> GetStopTimesByTripId(string keyTripId)
		{
			return StopTimesByTripsId[keyTripId];
		}

		#endregion

		#region Set les Dico


		public void SetAgencies(List<Agency> agencies)
		{
			if(agencies.Any(x => string.IsNullOrEmpty(x.agency_id)))
			{
				Agencies = agencies.ToDictionary(key => key.agency_name);
			}
			else
			{
				Agencies = agencies.ToDictionary(key => key.agency_id);
			}
		}


		public void SetRoutes(List<Routes> routes)
		{
			AllRoutes = routes.ToDictionary(key => key.route_id);
		}


		public void SetTrips(List<Trips> trips)
		{
			foreach (var item in trips)
			{
				item.GetFkRoutes = GetRoute;
				item.GetStopTimes = GetStopTimesByTripId;
				AllTrips.Add(item.trip_id, item);
			}
		}


		public void SetStops(List<Stops> stops)
		{
			AllStops = stops.ToDictionary(key => key.stop_id);
		}


		public void SetStopTimes(List<StopTimes> stopTimes)
		{
			foreach (var item in stopTimes)
			{
				item.GetFkStops = GetStop;
				item.GetFkTrips = GetTrip;

				// Clé composé d'un voyage ID, d'un arrêt ID et d'un ID de séquence,
				// pour un même voyage, il peut passer 2 fois sur le même arrêt
				AllStopTimes.Add(item.trip_id + "###" + item.stop_id + "###" + item.stop_sequence, item);


				if(StopTimesByTripsId.ContainsKey(item.trip_id))
				{
					StopTimesByTripsId[item.trip_id].Add(item);
				}
				else
				{
					StopTimesByTripsId.Add(item.trip_id, new List<StopTimes>() { item });
				}
			}
		}


		public void SetCalendars(List<Calendar> calendars)
		{
			Calendars = calendars.ToDictionary(key => key.service_id);
		}


		public void SetCalendatDates(List<CalendarDates> calendarDates)
		{
			AllCalendarDates = calendarDates.ToDictionary(key => key.service_id);

			foreach (var item in calendarDates)
			{
				// Clé composé de l'ID du service pour cette date
				AllCalendarDates.Add(item.service_id + "###" + item.date, item);
			}
		}

		public void SetShapes(List<Shapes> shapes)
		{
			foreach (var shape in shapes)
			{
				if (AllShapes.ContainsKey(shape.shape_id))
				{
					AllShapes[shape.shape_id].Add(shape);
				}
				else
				{
					AllShapes.Add(shape.shape_id, new List<Shapes>() { shape });
				}
			}
		}

		#endregion

		#endregion

	}
}
