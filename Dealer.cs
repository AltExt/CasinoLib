namespace CasinoLib
{
	public class Dealer: BlackJackPlayer
	{
		public Dealer():base() { }
		
		public Dealer(string name): base(name, 0)
		{
			HoleCardHidden = true;
			DealerDeck = new Deck();
			DealerDeck.Shuffle();
		}

        public Deck DealerDeck { get; set; }

		public bool HoleCardHidden { get; set; }
    }

}
