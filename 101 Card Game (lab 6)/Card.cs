using System;
using System.ComponentModel;

namespace ПА_Лаб._6
{
	class Card
	{
		public Card(Ranks r, Suits s)
		{
			Rank = r;
			Suit = s;
		}
		public Ranks Rank { get; set; } // 6..7..8..9..10..J..Q..K..A
		public Suits Suit { get; set; } // <3..<>..+..^ 
		public Suits QueenSuit { get; set; }
		public override string ToString()
		{
			return $"{Program.GetDescription(Rank)}{Program.GetDescription(Suit)}";
		}

	}
	enum Ranks
	{
		[Description("6")]
		Six,
		[Description("7")]
		Seven,
		[Description("8")]
		Eight,
		[Description("9")]
		Nine,
		[Description("10")]
		Ten,
		[Description("J")]
		Jack,
		[Description("Q")]
		Queen,
		[Description("K")]
		King,
		[Description("A")]
		Ace,
	}
	enum Suits
	{
		[Description("<3")]
		Hearts,
		[Description("<>")]
		Tiles,
		[Description("+")]
		Clovers,
		[Description("^")]
		Pikes,
	}
}
