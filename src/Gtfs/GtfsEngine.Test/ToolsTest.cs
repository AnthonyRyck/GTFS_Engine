using System;
using Xunit;

namespace GtfsEngine.Test
{
	public class ToolsTest
	{

		[Fact]
		public void ParseDay_ReturnOk()
		{
			#region Arrange

			string unJour = "20210619";
			DateTime date = new DateTime(2021, 06, 19);

			#endregion

			#region Act

			DateTime oneDay = Tools.ConvertToDateTime(unJour);

			#endregion

			#region Assert

			Assert.Equal(date, oneDay);

			#endregion
		}

		[Fact]
		public void ParseDateNull_Return_DateTimeMinValue()
		{
			#region Arrange

			string unJour = null;

			#endregion

			#region Act

			DateTime date = Tools.ConvertToDateTime(unJour);

			#endregion

			#region Assert

			Assert.Equal(DateTime.MinValue, date);

			#endregion
		}

		[Fact]
		public void ParseDateEmpty_Return_DateTimeMinValue()
		{
			#region Arrange

			string unJour = string.Empty;

			#endregion

			#region Act

			DateTime date = Tools.ConvertToDateTime(unJour);

			#endregion

			#region Assert

			Assert.Equal(DateTime.MinValue, date);

			#endregion
		}

		[Fact]
		public void ParseMauvaisFormat_Return_DateTimeMinValue()
		{
			#region Arrange

			string unJour = "210619";

			#endregion

			#region Act

			DateTime date = Tools.ConvertToDateTime(unJour);

			#endregion

			#region Assert

			Assert.Equal(DateTime.MinValue, date);

			#endregion
		}

		[Fact]
		public void ParseMauvaisFormatAutre_Return_DateTimeMinValue()
		{
			#region Arrange

			string unJour = "Plouf";

			#endregion

			#region Act

			DateTime date = Tools.ConvertToDateTime(unJour);

			#endregion

			#region Assert

			Assert.Equal(DateTime.MinValue, date);

			#endregion
		}

	}
}
