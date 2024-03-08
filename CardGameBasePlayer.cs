using System.Collections.Generic;

namespace CasinoLib
{
	public abstract class CardGameBasePlayer
	{
		public CardGameBasePlayer() 
		{
			Hand = new List<Card>();
		}

        public string Name { get; set; }
        public List<Card> Hand { get; set; }
	}
}
