using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GtfsEngine
{
	public static class Tools
	{

		public static DateTime ConvertToDateTime(string yyyyMMdd)
		{
			if (string.IsNullOrEmpty(yyyyMMdd))
			{
				return DateTime.MinValue;
			}
			try
			{
				return DateTime.ParseExact(yyyyMMdd, "yyyyMMdd", CultureInfo.InvariantCulture);
			}
			catch (Exception)
			{
				return DateTime.MinValue;
			}
		}

	}
}
