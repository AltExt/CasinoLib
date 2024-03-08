using System;

namespace CasinoLib
{
	public class ExceptionEntity
	{
		public int ID { get; set; }
		public string ExceptionType { get; set; }
		public string ExceptionMessage { get; set; }
		public DateTime TimeStamp { get; set; }

		public void PrintToConsole()
		{
			Console.Write("ID: " + ID.ToString() + " | ");
			Console.Write("Exception Type: " + ExceptionType + " | ");
			Console.Write("Exception Message: " + ExceptionMessage + " | ");
			Console.Write("Time Stamp: " + TimeStamp + "\n");
		}
	}
}
