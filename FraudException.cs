using System;

namespace CasinoLib
{
	public class FraudException: Exception
	{
		public FraudException(): base() { }

		public FraudException(string message) : base(message) { }
	}
}
