using GtfsEngine.Entities;
using GtfsEngine.TestTools.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace GtfsEngine.Test
{
	public class DataEngineTest
	{
		// Test Smoke juste pour voir s'il n'y a pas d'erreur de "construction".

		#region Smoke Test
				
		[Fact]
		public void Smoke_Test_With_Zip_File()
		{
			List<Stream> ListStreamFileTest = FileManager.GetAllZipFiles();

			// Vérifie juste qu'il n'y a pas de problème.
			foreach (var file in ListStreamFileTest)
			{
				DataEngine dataEngine = new DataEngine();
				dataEngine.LoadDatasByZip(file);
			}
		}

		[Fact]
		public void Smoke_Test_With_AgencyTxtFile()
		{
			Stream txtFile = FileManager.GetTxtAgency();

			DataEngine dataEngine = new DataEngine();
			dataEngine.LoadData<Agency>(txtFile);
		}

		[Fact]
		public void Smoke_Test_With_CalendarDatesTxtFile()
		{
			Stream txtFile = FileManager.GetTxtCalendarDate();

			DataEngine dataEngine = new DataEngine();
			dataEngine.LoadData<CalendarDates>(txtFile);
		}

		[Fact]
		public void Smoke_Test_With_RoutesTxtFile()
		{
			Stream txtFile = FileManager.GetTxtRoutes();

			DataEngine dataEngine = new DataEngine();
			dataEngine.LoadData<Routes>(txtFile);
		}

		[Fact]
		public void Smoke_Test_With_ShapesTxtFile()
		{
			Stream txtFile = FileManager.GetTxtShapes();

			DataEngine dataEngine = new DataEngine();
			dataEngine.LoadData<Shapes>(txtFile);
		}

		[Fact]
		public void Smoke_Test_With_StopTimesTxtFile()
		{
			Stream txtFile = FileManager.GetTxtStopTimes();

			DataEngine dataEngine = new DataEngine();
			dataEngine.LoadData<StopTimes>(txtFile);
		}

		[Fact]
		public void Smoke_Test_With_StopsTxtFile()
		{
			Stream txtFile = FileManager.GetTxtStops();

			DataEngine dataEngine = new DataEngine();
			dataEngine.LoadData<Stops>(txtFile);
		}

		[Fact]
		public void Smoke_Test_With_TripsTxtFile()
		{
			Stream txtFile = FileManager.GetTxtTrips();

			DataEngine dataEngine = new DataEngine();
			dataEngine.LoadData<Trips>(txtFile);
		}

		#endregion


		[Fact]
		public void CompteLigneRoute_Return_45()
		{
			#region Arrange

			Stream streamFile = FileManager.GetZipFileReunion();

			#endregion

			#region Act

			DataEngine dataEngine = new DataEngine();
			dataEngine.LoadDatasByZip(streamFile);

			#endregion

			#region Assert

			Assert.Equal(45, dataEngine.Gtfs.AllRoutes.Count);

			#endregion
		}

	}
}
