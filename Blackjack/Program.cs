using System;
using System.Collections.Generic;

namespace Blackjack
{
	using System.Collections.Generic;
	using System;

	namespace Blackjack
	{
		class Card
		{
			public static int Value(string Card, int Value)
			{
				int g = 0;
				switch (Card)
				{
					case "2":
						g = 2;
						break;
					case "3":
						g = 3;
						break;
					case "4":
						g = 4;
						break;
					case "5":
						g = 5;
						break;
					case "6":
						g = 6;
						break;
					case "7":
						g = 7;
						break;
					case "8":
						g = 8;
						break;
					case "9":
						g = 9;
						break;
					case "10":
						g = 10;
						break;
					case "Q":
						g = 10;
						break;
					case "K":
						g = 10;
						break;
					case "J":
						g = 10;
						break;
					case "A":
						if (Value > 11)
						{
							g = 1;
						}
						else
						{
							g = 11;
						}
						break;
				}
				return g;
			}
		}
		class Quit
		{
			public static void ExitOnStart()
			{
				{
					Console.WriteLine("\n(-_-) It seems that you don't have money... y/n");
					String QuitChoice = Console.ReadLine();
					switch (QuitChoice)
					{
						case "y":
							Console.WriteLine("\n(-_-) You are so boring...  \n" +
											  "Press any key to exit...");
							Console.ReadKey();
							Environment.Exit(0);
							break;
						case "n":
							break;
						default:
							Console.WriteLine("\ny for yes, n for no");
							ExitOnStart();
							break;
					}
				}
			}
			public static void ExitInGame()
			{
				{
					Console.WriteLine("\n($_$) Do you want continue earning(losing) money? y/n");
					String QuitChoice = Console.ReadLine();
					switch (QuitChoice)
					{
						case "y":
							break;
						case "n":
							Console.WriteLine("\n>:-D All your money is mine now!\n" +
											  "Press any key to exit...");
							Console.ReadKey();
							Environment.Exit(0);
							break;
						default:
							Console.WriteLine("\ny for yes, n for no");
							ExitInGame();
							break;
					}
				}
			}
		}
		class MainClass
		{
			public static void Main(string[] args)
			{
				Console.WriteLine(" =======================================================================================\n" +
								  "        ===         ===         ===         ===  ===   ===   ===         ===\n" +
								  "        ===   =========   ===   ===   ==============    ==   ===   ===   ===\n" +
								  "        ===   =========         ===         ===  ===   = =   ===   ===   ===\n" +
								  "        ===   =========   ===   =========   ===  ===   ==    ===   ===   ===\n" +
								  "        ===         ===   ===   ===         ===  ===   ===   ===         ===\n" +
								  " =======================================================================================");
				//All first numbers.
				List<string> Deck = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Q", "K", "J", "A" };
				Random f = new Random();
				int Money = 1000;
				int Bet = 0;
				int PlayerValue = 0;
				int CroupierValue = 0;
				int o = 0;
				int h = 0;
				string StartChoice = "h";
				//All first numbers end.
				while (o == 0)
				{
					Console.WriteLine("\nHello and welcome to BlackJack Casino, place, where you can spend your money, to win money(or not).\n" +
									  "Do you want to play Blackjack?(write 'h' for rules) y/n");
					StartChoice = Console.ReadLine();
					switch (StartChoice)
					{
						case "h":
							//rules
							Console.WriteLine("\nRULES.\n" +
											  "You are playing against a croupier (this guy --> >:-D ).\n" +
											  "On the start of the game each of you gets two cards, one of croupier's card is open," +
											  "every card has got its value (Joker = 11 or 1, Cards with image = 10, all\n" +
											  "other = their value). To win the game, you need to get a combination of cards,\n" +
											  "whose value in sum equals more than croupier's(if croupier has got more, you will lose),\n" +
											  "this sum mustn't be more than 21(croupier's too). If it happens, you or croupier lose.\n" +
											  "When first cards are dealt, you will have different choices: First, ask for the card.\n" +
											  "Second, ask for the card and double your bet. And you can do it many times as you want.\n" +
											  "P.s. If you have 21 at the start of a game(blackjack), it doesn't mean that you are winner.\n" +
											  "P.s. Croupier must will open all his cards after you(when you stop taking them), and also\n" +
											  "he will take the cards until he have got 17 or more.\n" +
											  "P.s. If you win with blackjack, you will be payed by 4 to 2 of your bet (if your bet 100\n" +
											  "you will get 300(with your bet))\n" +
											  "P.s. Game is using 52 cards in each deck\n" +
											  "P.s. Ace will take it value once(no changes for situation)\n" +
											  "\nRULES END.\n");
							break;
						case "n":
							Quit.ExitOnStart();
							break;
						case "y":
							Console.WriteLine("\nThis guy is a croupier --> >:-D");
							o++;
							break;

					}
				}
				Console.WriteLine("\nLet's start!");
				while (h == 0)
				{
					int q = 0;
					while (q == 0)
					{
						//BET
						if (Money < 10)
						{
							Console.WriteLine("\n(-_-) It's time to stop! Your balance is lower than minimum bet! Get out of here!\n" +
											  "Press any key to exit casino...");
							Console.ReadKey();
							Environment.Exit(0);
						}
						Console.WriteLine("\n>:-> Make your bet! Bet lower than 10$ not allowed! You have " + Money + "$");
						try
						{
							Bet = Convert.ToInt32(Console.ReadLine());
						}
						catch (Exception)
						{
							continue;
						}
						if (Bet < 10)
						{
							Console.WriteLine("\n(-_-) Bets lower than 10$ are not allowed!");
							continue;
						}
						else if (Bet > Money)
						{
							Console.WriteLine("\n(-_-) You don't have that much money!");
							continue;
						}
						else
						{
							Money -= Bet;
							Console.WriteLine("\n($_$) Bet accepted! Now you have " + Money + "$ in your pocket!");
							q++;
							break;
						}
					}

					PlayerValue = 0;
					CroupierValue = 0;
					List<string> PlayerHand = new List<string>();
					List<string> CroupierHand = new List<string>();
					string Action = "";

					Console.WriteLine("\n>:-D Press any key when you will be ready to win(lose) your money!");
					Console.ReadKey();

					//
					//First cards
					//
					for (int x = 0; x < 2; x++)
					{
						int Card1 = f.Next(0, 13);
						PlayerValue += Card.Value(Deck[Card1], PlayerValue);
						PlayerHand.Add(Deck[Card1]);
					}

					int Card2 = f.Next(0, 13);
					CroupierValue += Card.Value(Deck[Card2], CroupierValue);
					CroupierHand.Add(Deck[Card2]);
					//
					//First cards end
					//

					//
					//Info
					//
					Console.WriteLine("\nYou have got these cards:\n" +
									  "=========================");
					foreach (string el in PlayerHand)
					{
						Console.WriteLine(el);
					}
					Console.WriteLine("=========================");
					Console.WriteLine("\nValue of your cards = " + PlayerValue);
					Console.WriteLine("\n>:-D I have got this card: ");
					foreach (string el in CroupierHand)
					{
						Console.WriteLine(el);
					}
					Console.WriteLine("\n>:-D It's value is " + CroupierValue);
					if (CroupierValue == 10 && CroupierValue == 1)
					{
						Console.WriteLine("\n>:-D It would be a pity if i have got a blackjack!");
					}
					//
					//Info end
					//
					int j = 0;
					int PlayerValueOverload = 0;
					int CroupierValueOverload = 0;
					while (j == 0)
					{
						//CHOICES
						Console.WriteLine("\nTake card(c)/Double(d)/All nice(n)");
						Action = Console.ReadLine();
						switch (Action)
						{
							case "c":
								{
									if (PlayerValueOverload == 0)
									{
										Console.WriteLine("\n>:-D Here you are.");
										int Card1 = f.Next(0, 13);
										PlayerValue += Card.Value(Deck[Card1], PlayerValue);
										PlayerHand.Add(Deck[Card1]);
										Console.WriteLine("\n>:-I You got " + Deck[Card1]);
										Console.WriteLine("\nYou have got these cards now:\n" +
										  "=========================");
										foreach (string el in PlayerHand)
										{
											Console.WriteLine(el);
										}
										Console.WriteLine("=========================");
										Console.WriteLine("\nYour bet is " + Bet + "\nYour balance is " + Money + "$");
									}
									if (PlayerValue > 21)
									{
										PlayerValueOverload = 1;
									}
									Console.WriteLine("\nValue of your cards = " + PlayerValue);
									if (PlayerValueOverload == 1)
									{
										Console.WriteLine("\n>:-P You have got more than 21! You lost " + Bet + "$!\n" +
										                  "\n Your balance is " + Money + "$");

										j++;
									}
									break;
								}
							case "d":
								{
									if (PlayerValueOverload == 0)
									{
										if (Money > Bet)
										{
											Console.WriteLine("\n>:-D Here you are and thanks for the money!");
											Money -= Bet;
											Bet *= 2;
											int Card1 = f.Next(0, 13);
											PlayerValue += Card.Value(Deck[Card1], PlayerValue);
											PlayerHand.Add(Deck[Card1]);
											Console.WriteLine("\nYou have got these cards now:\n" +
											  "=========================");
											foreach (string el in PlayerHand)
											{
												Console.WriteLine(el);
											}
											Console.WriteLine("=========================");
											Console.WriteLine("\nNow your bet is " + Bet + "\nYour balance is " + Money + "$");
										}
										else
										{
											Console.WriteLine(">:-l Not enough money!");
										}
									}
									//PLAYER LOST OVERLOAD
									if (PlayerValue > 21)
									{
										PlayerValueOverload = 1;
									}
									Console.WriteLine("\nValue of your cards = " + PlayerValue);
									if (PlayerValueOverload == 1)
									{
										Console.WriteLine("\n>:-P You have got more than 21! You lost " + Bet + "$!\n" +
										                  "\n Your balance is " + Money + "$");
										j++;
									}
									break;
								}
							case "n":
								{
									j++;
									break;
								}
						}
					}
					if (PlayerValueOverload == 0)
					{


						Console.WriteLine("\n>:-> Now it's my turn to take cards!");
						System.Threading.Thread.Sleep(3000);
						for (; CroupierValue < 17;)
						{
							int Card3 = f.Next(0, 13);
							CroupierValue += Card.Value(Deck[Card3], CroupierValue);
							CroupierHand.Add(Deck[Card3]);
							Console.WriteLine("\n>:-> I got " + Deck[Card3] + "\nNow value of my cards equals to " + CroupierValue + "\n");
							System.Threading.Thread.Sleep(4000);
						}

						// CROUPIER LOST OVERLOAD
						if (CroupierValue > 21)
						{
							Console.WriteLine("<:-< How it happened? I got more than 21! I lost!");
							CroupierValueOverload = 1;
							if (PlayerValue == 21)
							{
								Money += Bet * 3;
								Console.WriteLine("\n>:-< You won with a blackjack! Your profit is " + Bet * 2 + "$" +
												  "\n Your balance is " + Money + "$");
							}
							else
							{
								Money += Bet * 2;
								Console.WriteLine("\n>:-< You won! Your profit is " + Bet + "$" +
												  "\n Your balance is " + Money + "$");
							}
						}

						//USUAL
						if (CroupierValueOverload == 0 && PlayerValueOverload == 0)
						{
							//CROUPIER LOST
							if (PlayerValue > CroupierValue)
								if (PlayerValue == 21 && PlayerHand.Count == 2)
								{
									Money += Bet * 3;
									Console.WriteLine("\n>:-< You won with a blackjack! Your profit is " + Bet * 2 + "$" +
													  "\n Your balance is " + Money + "$");

								}
								else
								{
									Money += Bet * 2;
									Console.WriteLine("\n>:-< You won! Your profit is " + Bet + "$" +
													  "\n Your balance is " + Money + "$");

								}
							//CROUPIER WON
							if (PlayerValue < CroupierValue)
							{
								if (CroupierValue == 21 && CroupierHand.Count == 2)
								{
									Console.WriteLine("\n>:-P My value is " + CroupierValue + " and your value is " + PlayerValue +
													  "\nI won with a blackjack! You lost " + Bet + "$" +
													  "\n Your balance is " + Money + "$");
								}
								else
								{
									Console.WriteLine("\n>:-P My value is " + CroupierValue + " and your value is " + PlayerValue +
													  "\nYou lost! You lost " + Bet + "$" +
													  "\n Your balance is " + Money + "$");

								}
							}
							//NOBODY WINS
							if (PlayerValue == CroupierValue)
							{
								Console.WriteLine("\n(>_<) My value equals to yours!(My value = " + CroupierValue + " Your value =" + PlayerValue + ")");
								Money += Bet;
								Console.WriteLine("You get your bet ( " + Bet + "$ ) back.\n" +
												  "Your balance is " + Money + "$");
							}
						}
					}
					Quit.ExitInGame();
				}
			}
		}
	}
}