using GtfsEngine.Entities;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Calendar = GtfsEngine.Entities.Calendar;

namespace GtfsEngine
{
	public class DataEngine
	{
		/// <summary>
		/// Contient toutes les propriétés.
		/// </summary>
		public GtfsModel Gtfs { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		public DataEngine()
		{
			Gtfs = new GtfsModel();
		}


		public List<T> LoadData<T>(Stream stream)
		{
			List<T> records = new List<T>();
			using (var reader = new StreamReader(stream))
			{
				records = CsvSerializer.DeserializeFromReader<List<T>>(reader);
			}

			return records;
		}
		
		/// <summary>
		/// Charge tous les dico à partir d'un Stream d'un zip.
		/// </summary>
		/// <param name="stream"></param>
		public void LoadDatasByZip(Stream stream)
		{
			ZipArchive archive = new ZipArchive(stream);
			foreach (ZipArchiveEntry entry in archive.Entries)
			{
				switch (entry.Name)
				{
					case "agency.txt":
						Gtfs.SetAgencies(LoadData<Agency>(entry.Open()));
						break;

					case "routes.txt":
						Gtfs.SetRoutes(LoadData<Routes>(entry.Open()));
						break;

					case "trips.txt":
						Gtfs.SetTrips(LoadData<Trips>(entry.Open()));
						break;

					case "stops.txt":
						Gtfs.SetStops(LoadData<Stops>(entry.Open()));
						break;

					case "stop_times.txt":
						Gtfs.SetStopTimes(LoadData<StopTimes>(entry.Open()));
						break;

					case "calendar.txt":
						Gtfs.SetCalendars(LoadData<Calendar>(entry.Open()));
						break;

					case "shapes.txt":
						Gtfs.SetShapes(LoadData<Shapes>(entry.Open()));
						break;

					case "transfers.txt":
						Gtfs.SetTransfer(LoadData<Transfer>(entry.Open()));
						break;

					default:
						break;
				}
			}
		}

	}
}
