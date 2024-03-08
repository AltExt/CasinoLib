using System;

namespace CasinoLib
{
    public class CasinoUtils
    {
        public static int GetCashAmountFromUser(int min, int max)
        {
			while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result))
				{
					if (result >= min && result <= max) return result;

                    if (result < 0) throw new FraudException("Less than 0 amount for bet!");
				}
            }
        }
    }
}
