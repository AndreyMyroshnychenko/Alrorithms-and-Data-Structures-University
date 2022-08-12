using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace ПА_Лаб._6
{
	static class Game
	{
		private static List<Card> neutralDeck = new List<Card>();
		private static List<Card> botDeck = new List<Card>();
		private static List<Card> myDeck = new List<Card>();
		private static List<Card> discardedCards = new List<Card>();
		private static Card cardOnTable = null;
		private static bool myTurn = false;
		private static bool isPlaying = true;
		private static bool takedCard = false;
		private static int stackSix = 1;
		private static int stackSeven = 2;

		public static void StartGame()
		{
			
			CreateNeutralDeck();
			neutralDeck.Shuffle();
			GiveCards(myDeck, 4);
			GiveCards(botDeck, 5);
			while (neutralDeck[0].Rank == Ranks.Queen)
				neutralDeck.Shuffle();
			cardOnTable = neutralDeck[0];
			neutralDeck.Remove(neutralDeck[0]);

			
			Penalty();
			while (isPlaying)
			{
				Show();
				if (myTurn)
					MyMove();
				else
					BotMove();
			}

			
			Console.Clear();
			Show();
			string winner = botDeck.Count == 0 ? "Bot" : "You";
			Console.WriteLine($"Winner: {winner}");
		}

		private static void GiveCards(List<Card> deck, int count)
		{
			if (count > neutralDeck.Count)
			{
				discardedCards.Shuffle();
				for (int i = 0; i < discardedCards.Count; i++)
				{
					neutralDeck.Add(discardedCards[0]);
					discardedCards.Remove(discardedCards[0]);
				}
			}
			for (int i = 0; i < count; i++)
			{
				deck.Add(neutralDeck[0]);
				neutralDeck.Remove(neutralDeck[0]);
			}
		}
		private static void ThrowCard(Card c, List<Card> deck)
		{
			if (cardOnTable.Rank == Ranks.Queen)
			{
				Suits s = cardOnTable.Suit;
				cardOnTable.Suit = cardOnTable.QueenSuit;
				cardOnTable.QueenSuit = s;
			}
			discardedCards.Add(cardOnTable);
			cardOnTable = c;
			deck.Remove(c);
			if (deck.Count == 0)
				isPlaying = false;
			myTurn = !myTurn;
			Penalty();

		}
		private static void ThrowCard(Card c, List<Card> deck, Suits s)
		{
			if (c.Rank == Ranks.Queen)
			{
				c.QueenSuit = s;
				ThrowCard(c, deck);
			}
			else { Console.WriteLine("ERROR"); }
		}
		private static void Show()
		{
			Console.Clear();
			Console.Write($"Opponent: ");
			foreach (Card c in botDeck)

				Console.Write($"[] ");
			Console.WriteLine();
			Console.WriteLine();
			if (cardOnTable.Rank == Ranks.Queen)
				Console.WriteLine($"Field: {discardedCards.Count} {cardOnTable.ToString()}:[{cardOnTable.QueenSuit.GetDescription()}]");
			else
				Console.WriteLine($"Field: {discardedCards.Count} {cardOnTable.ToString()}");
			Console.WriteLine();
			Console.WriteLine($"Deck: {neutralDeck.Count}");
			Console.WriteLine();
			Console.Write($"Me: ");
			foreach (Card c in myDeck)
				Console.Write($"{c.ToString()} ");
			Console.WriteLine();
		}
		private static void BotMove()
		{
			for (int i = 0; i < 5; i++)
			{
				Console.Write(".");
				Thread.Sleep(1000);
			} 
			if (myTurn)
				return;
			if (cardOnTable.Rank == Ranks.Queen)
			{
				Suits s = cardOnTable.Suit;
				cardOnTable.Suit = cardOnTable.QueenSuit;
				cardOnTable.QueenSuit = s;
			}

			Dictionary<Card, int> chancesOfCards = new Dictionary<Card, int>();
			Dictionary<Card, bool> canThrowCard = new Dictionary<Card, bool>();
			Dictionary<Ranks, int> countRanks = new Dictionary<Ranks, int>()
			{
				{Ranks.Six, 0},
				{Ranks.Seven, 0},
				{Ranks.Eight, 0},
				{Ranks.Ace, 0}
			};
			foreach (Card c in botDeck)
			{
				if (c.Rank == cardOnTable.Rank || c.Suit == cardOnTable.Suit || c.Rank == Ranks.Queen)
				{
					switch (c.Rank)
					{
						case Ranks.Queen:
							chancesOfCards.Add(c, 1); // Q
							break;

						case Ranks.Six:
						case Ranks.Seven:
							chancesOfCards.Add(c, 80); // 6 7
							break;

						case Ranks.Eight:
						case Ranks.Ace:
							chancesOfCards.Add(c, 90); // 8 A
							break;

						case Ranks.King:
							if (c.Suit == Suits.Pikes)
								chancesOfCards.Add(c, 92); // K^
							else
								chancesOfCards.Add(c, 20);
							break;

						default:
							chancesOfCards.Add(c, 20); // other
							break;
					}
					canThrowCard.Add(c, true);
				}
				else
					canThrowCard.Add(c, false);
				if (countRanks.ContainsKey(c.Rank)) //count Cards
					countRanks[c.Rank] += 1;
			}
			var arr8 = botDeck.Where(x => x.Rank == Ranks.Eight).ToList();
			if (countRanks[Ranks.Eight] > 1 && arr8.Any(x => canThrowCard[x]))
			{
				foreach (Card c in arr8)
					SetChances(c, 95);
				chancesOfCards[arr8.First(x => x.Suit == MostInSuits(arr8))] -= 2;
			}
			var arrA = botDeck.Where(x => x.Rank == Ranks.Ace).ToList();
			if (countRanks[Ranks.Ace] > 1 && arrA.Any(x => canThrowCard[x]))
			{
				foreach (Card c in arrA)
					SetChances(c, 95);
				chancesOfCards[arrA.First(x => x.Suit == MostInSuits(arrA))] -= 2;
			}
			

			if (botDeck.All(c =>
				c.Rank != Ranks.Queen && c.Rank != cardOnTable.Rank && c.Suit != cardOnTable.Suit))
			{
				if (!takedCard)
				{
					GiveCards(botDeck, 1);
					takedCard = true;
				}
				else
				{
					takedCard = false;
					myTurn = !myTurn;
				}
			}
			else
			{
				foreach (KeyValuePair<Card, int> c in chancesOfCards)
					if (!canThrowCard[c.Key])
						chancesOfCards.Remove(c.Key);

				Card cardForThrow = chancesOfCards.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
				if (cardForThrow.Rank == Ranks.Queen)
				{
					if (botDeck.Count == 1)
						ThrowCard(cardForThrow, botDeck);
					List<Card> list = new List<Card>();
					foreach (Card c in botDeck)
						if (c != cardForThrow)
							list.Add(c);
					ThrowCard(cardForThrow, botDeck, MostInSuits(list));
				}
				else
					ThrowCard(cardForThrow, botDeck);
				takedCard = false;
			}

			Suits MostInSuits(List<Card> cards)
			{
				Dictionary<Suits, int> countSuits = new Dictionary<Suits, int>()
				{
					{Suits.Hearts, 0},
					{Suits.Tiles, 0},
					{Suits.Clovers, 0},
					{Suits.Pikes, 0},
				};
				foreach (Card c in cards)
					countSuits[c.Suit] += 1;
				return countSuits.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
			}
			void SetChances(Card c, int ch)
			{
				if (!chancesOfCards.ContainsKey(c))
					chancesOfCards.Add(c, ch);
				else
					chancesOfCards[c] = ch;
			}
		}
		private static void MyMove()
		{
			if (!myTurn) return;

			if (cardOnTable.Rank == Ranks.Queen)
			{
				Suits s = cardOnTable.Suit;
				cardOnTable.Suit = cardOnTable.QueenSuit;
				cardOnTable.QueenSuit = s;
			}
			int myChoice = Convert.ToInt32(Console.ReadLine());
			if (myChoice == 0)
			{
				if (myDeck.All(c =>
				c.Rank != Ranks.Queen && c.Rank != cardOnTable.Rank && c.Suit != cardOnTable.Suit))
				{
					if (!takedCard)
					{
						GiveCards(myDeck, 1);
						takedCard = true;
					}
					else
					{
						takedCard = false;
						myTurn = !myTurn;
					}
				}
			}
			else
			{
				Card choicedCard = myDeck[myChoice - 1];
				if (choicedCard.Rank == Ranks.Queen)
				{
					Console.WriteLine("<3 - 1; <> - 2; + - 3; ^ - 4");
					int s = Convert.ToInt32(Console.ReadLine());
					Suits su;
					switch (s)
					{
						case 1:
							su = Suits.Hearts;
							break;
						case 2:
							su = Suits.Tiles;
							break;
						case 3:
							su = Suits.Clovers;
							break;
						default:
							su = Suits.Pikes;
							break;
					}
					ThrowCard(choicedCard, myDeck, su);
				}
				else
				{
					if (choicedCard.Rank == cardOnTable.Rank || choicedCard.Suit == cardOnTable.Suit)
						ThrowCard(choicedCard, myDeck);
					else
						return;
				}
				takedCard = false;
			}
		}
		private static void Penalty()
		{
			List<Card> deck = myTurn ? myDeck : botDeck;
			Card c = cardOnTable;
			if (c.Rank == Ranks.Eight || c.Rank == Ranks.Ace)
				myTurn = !myTurn;
			if (c.Rank == Ranks.Six)
				if (deck.All(x => x.Rank != Ranks.Six))
				{
					GiveCards(deck, stackSix);
					stackSix = 1;
					myTurn = !myTurn;
				}
				else
					stackSix += 1;

			if (c.Rank == Ranks.Seven)
				if (deck.All(x => x.Rank != Ranks.Seven))
				{
					GiveCards(deck, stackSeven);
					stackSeven = 2;
					myTurn = !myTurn;
				}
				else
					stackSeven += 2;

			if (c.Rank == Ranks.King && c.Suit == Suits.Pikes)
			{
				GiveCards(deck, 4);
				myTurn = !myTurn;
			}
		}
		private static void CreateNeutralDeck()
		{
			for (int i = 0; i < 4; i++)
			{
				Suits s;
				switch (i)
				{
					case 0:
						s = Suits.Hearts;
						break;
					case 1:
						s = Suits.Tiles;
						break;
					case 2:
						s = Suits.Clovers;
						break;
					default:
						s = Suits.Pikes;
						break;
				}
				neutralDeck.Add(new Card(Ranks.Six, s));
				neutralDeck.Add(new Card(Ranks.Seven, s));
				neutralDeck.Add(new Card(Ranks.Eight, s));
				neutralDeck.Add(new Card(Ranks.Nine, s));
				neutralDeck.Add(new Card(Ranks.Ten, s));
				neutralDeck.Add(new Card(Ranks.Jack, s));
				neutralDeck.Add(new Card(Ranks.Queen, s));
				neutralDeck.Add(new Card(Ranks.King, s));
				neutralDeck.Add(new Card(Ranks.Ace, s));
			}
		}
	}
}
