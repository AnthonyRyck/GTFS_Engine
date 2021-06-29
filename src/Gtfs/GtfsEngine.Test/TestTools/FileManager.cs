using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GtfsEngine.TestTools.Tools
{
	public static class FileManager
	{
		public static Stream GetZipFileReunion()
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FilesTest", "carsud-reunion.zip");
			return File.OpenRead(path);
		}


		public static List<Stream> GetAllZipFiles()
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FilesTest");

			var allPathZipFiles = Directory.GetFiles(path, "*.zip");

			List<Stream> allFileZip = new List<Stream>();

			foreach (var file in allPathZipFiles)
			{
				allFileZip.Add(File.OpenRead(file));
			}

			return allFileZip;
		}

		public static List<Stream> GetAllTxtFiles()
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FilesTest", "DataTxt");

			var allPathTxtFiles = Directory.GetFiles(path, "*.txt");
			List<Stream> allFileTxt = new List<Stream>();

			foreach (var file in allPathTxtFiles)
			{
				allFileTxt.Add(File.OpenRead(file));
			}

			return allFileTxt;
		}

		public static Stream GetTxtAgency()
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FilesTest", "DataTxt", "agency.txt") ;
			return File.OpenRead(path);
		}

		public static Stream GetTxtCalendarDate()
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FilesTest", "DataTxt", "calendar_dates.txt");
			return File.OpenRead(path);
		}

		public static Stream GetTxtRoutes()
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FilesTest", "DataTxt", "routes.txt");
			return File.OpenRead(path);
		}

		public static Stream GetTxtShapes()
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FilesTest", "DataTxt", "shapes.txt");
			return File.OpenRead(path);
		}

		public static Stream GetTxtStopTimes()
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FilesTest", "DataTxt", "stop_times.txt");
			return File.OpenRead(path);
		}

		public static Stream GetTxtStops()
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FilesTest", "DataTxt", "stops.txt");
			return File.OpenRead(path);
		}

		public static Stream GetTxtTrips()
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FilesTest", "DataTxt", "trips.txt");
			return File.OpenRead(path);
		}
	}
}
