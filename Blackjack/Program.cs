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
					Console.WriteLine("\n(-_-) Ты что, пришел в казино без денег? y/n");
					String QuitChoice = Console.ReadLine();
					switch (QuitChoice)
					{
						case "y":
							Console.WriteLine("\n(-_-) Ну, тогда иди отсюда...  \n" +
											  "Press any key to exit...");
							Console.ReadKey();
							Environment.Exit(0);
							break;
						case "n":
							break;
						default:
							Console.WriteLine("\nнажми 'y' для да , 'n' для нет");
							ExitOnStart();
							break;
					}
				}
			}
			public static void ExitInGame()
			{
				{
					Console.WriteLine("\n($_$) Хочешь продолжить выигрывать(тратить) деньги? y/n");
					String QuitChoice = Console.ReadLine();
					switch (QuitChoice)
					{
						case "y":
							break;
						case "n":
							Console.WriteLine("\n>:-D Все твоё имущество теперь моё!\n" +
											  "Press any key to exit...");
							Console.ReadKey();
							Environment.Exit(0);
							break;
						default:
							Console.WriteLine("\nнажми 'y' для да , 'n' для нет");
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
					Console.WriteLine("\nЗдравствуйте и добро пожаловать в Казино, где можно играть только в Бледжек.\n +
									  "(напишите 'h' чтобы посмотреть правила)\n" +
									  "Не забудь поставить английскую раскладку" 
									  "Хотите сыграть в блекджек? y/n/h");
					StartChoice = Console.ReadLine();
					switch (StartChoice)
					{
						case "h":
							//rules
							Console.WriteLine("\nПРАВИЛА.\n" +
											  "Ты играешь против крупье.\n" +
											  "В начале игры каждый из вас получает по две карты, одна из карт крупье открыта,\n" +
											  "У каждой карты есть своя стоимость (Джокер(A) = 11 или 1(по ситуации), карты с картинками = 10,\n" +
											  "остальные = их цифре). Чтробы выиграть, тебе нужно получить комбинацию карт,\n" +
											  "сумма которой больше суммы карт крупье(если в конце игры у крупье сумма окажется больше, ты проиграешь),\n" +
											  "эта сумма не должна быть больше 21 (сумма крупье тоже). Если это происходит, вы или крупье проигрываете.\n" +
											  "Когда произошла первая раздача карты у вас будет выбор: 1. Попросить карту.\n" +
											  "2. попросить карту и удвоить ставку. Эти действия ты можешь делать столько раз, сколько захочешь. \n" +
											  "P.s. Если у тебя сумма карт с первой раздачи 21, это не значит что ты выиграл\n" +
											  "P.s. Крупье откроет все свои карты после тебя(когда ты перестанешь брать их), а также\n" +
											  "он будет брать карты пока у него не будет сумма равная или больше 17");
											  "P.s. Если ты выигрываешь, имея блекджек(21), ты получишь двойную сумму\n" +
											  "ставки(например если твоя ставка 100, ты получишь 300(тебе отдадут твою ставку)\n" +
											  "P.s. Игра использует 52 карточную колоду\n" +
											  "P.s. Туз примет свое значение только один раз\n" +
											  "\nКОНЕЦ ПРАВИЛ.\n");
							break;
						case "n":
							Quit.ExitOnStart();
							break;
						case "y":
							Console.WriteLine("\nЭтот пацан будет твоим крупье --> >:-D");
							o++;
							break;

					}
				}
				Console.WriteLine("\nДавай начнем!");
				while (h == 0)
				{
					int q = 0;
					while (q == 0)
					{
						//BET
						if (Money < 10)
						{
							Console.WriteLine("\n(-_-) Пора остановиться! Твой баланс меньше минимальной ставки! Убирайся отсюда!\n" +
											  "Press any key to exit casino...");
							Console.ReadKey();
							Environment.Exit(0);
						}
						Console.WriteLine("\n>:-> Делай свою ставку! Ставки меньше 10$ не разрешены! У тебя " + Money + "$");
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
							Console.WriteLine("\n(-_-) Ставки меньше 10$ не разрешены!");
							continue;
						}
						else if (Bet > Money)
						{
							Console.WriteLine("\n(-_-) У тебя нету таких денег!");
							continue;
						}
						else
						{
							Money -= Bet;
							Console.WriteLine("\n($_$) Ставка принята! Теперь у тебя " + Money + "$ в кармане!");
							q++;
							break;
						}
					}

					PlayerValue = 0;
					CroupierValue = 0;
					List<string> PlayerHand = new List<string>();
					List<string> CroupierHand = new List<string>();
					string Action = "";

					Console.WriteLine("\n>:-D Нажми любую клавишу когда будешь готов выиграть(проиграть) свои деньги!");
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
					Console.WriteLine("\nУ тебя такие карты:\n" +
									  "=========================");
					foreach (string el in PlayerHand)
					{
						Console.WriteLine(el);
					}
					Console.WriteLine("=========================");
					Console.WriteLine("\nСтоимость твоих карт = " + PlayerValue);
					Console.WriteLine("\n>:-D У меня эта карта: ");
					foreach (string el in CroupierHand)
					{
						Console.WriteLine(el);
					}
					Console.WriteLine("\n>:-D Ее стоимость: " + CroupierValue);
					if (CroupierValue == 10 && CroupierValue == 1)
					{
						Console.WriteLine("\n>:-D Будет обидно, если у меня блекджек!");
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
						Console.WriteLine("\nВзять карту(c)/Удвоить(d)/Ничего не менять(n)");
						Action = Console.ReadLine();
						switch (Action)
						{
							case "c":
								{
									if (PlayerValueOverload == 0)
									{
										Console.WriteLine("\n>:-D Держи.");
										int Card1 = f.Next(0, 13);
										PlayerValue += Card.Value(Deck[Card1], PlayerValue);
										PlayerHand.Add(Deck[Card1]);
										Console.WriteLine("\n>:-I У тебя " + Deck[Card1]);
										Console.WriteLine("\nТеперь у тебя эти карты:\n" +
										  "=========================");
										foreach (string el in PlayerHand)
										{
											Console.WriteLine(el);
										}
										Console.WriteLine("=========================");
										Console.WriteLine("\nТвоя ставка " + Bet + "$\nТвой баланс " + Money + "$");
									}
									if (PlayerValue > 21)
									{
										PlayerValueOverload = 1;
									}
									Console.WriteLine("\nСтоимость твоих карт = " + PlayerValue);
									if (PlayerValueOverload == 1)
									{
										Console.WriteLine("\n>:-P У тебя больше чем 21! Ты проиграл " + Bet + "$!\n" +
										                  "\n Твой баланс " + Money + "$");

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
											Console.WriteLine("\n>:-D Держи, и спасибо за деньги");
											Money -= Bet;
											Bet *= 2;
											int Card1 = f.Next(0, 13);
											PlayerValue += Card.Value(Deck[Card1], PlayerValue);
											PlayerHand.Add(Deck[Card1]);
											Console.WriteLine("\nТеперь у тебя эти карты:\n" +
											  "=========================");
											foreach (string el in PlayerHand)
											{
												Console.WriteLine(el);
											}
											Console.WriteLine("=========================");
											Console.WriteLine("\nТеперь твоя ставка " + Bet + "$\nТвой баланс " + Money + "$");
										}
										else
										{
											Console.WriteLine(">:-l Недостаточно денег!");
										}
									}
									//PLAYER LOST OVERLOAD
									if (PlayerValue > 21)
									{
										PlayerValueOverload = 1;
									}
									Console.WriteLine("\nСтоимость твоих карт = " + PlayerValue);
									if (PlayerValueOverload == 1)
									{
										Console.WriteLine("\n>:-P У тебя больше 21! Ты проиграл " + Bet + "$!\n" +
										                  "\n Твой баланс " + Money + "$");
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


						Console.WriteLine("\n>:-> Теперь моя очередь брать карты!");
						System.Threading.Thread.Sleep(3000);
						for (; CroupierValue < 17;)
						{
							int Card3 = f.Next(0, 13);
							CroupierValue += Card.Value(Deck[Card3], CroupierValue);
							CroupierHand.Add(Deck[Card3]);
							Console.WriteLine("\n>:-> I got " + Deck[Card3] + "\nТеперь стоимость моих карт равна " + CroupierValue + "\n");
							System.Threading.Thread.Sleep(4000);
						}

						// CROUPIER LOST OVERLOAD
						if (CroupierValue > 21)
						{
							Console.WriteLine("<:-< Как это произошло? Я у меня больше 21! Я проиграл!");
							CroupierValueOverload = 1;
							if (PlayerValue == 21)
							{
								Money += Bet * 3;
								Console.WriteLine("\n>:-< Ты выиграл блекджеком! Твой выигрыш составляет " + Bet * 2 + "$" +
												  "\n Твой баланс " + Money + "$");
							}
							else
							{
								Money += Bet * 2;
								Console.WriteLine("\n>:-< Ты выиграл! Твой выигрыш составляет " + Bet + "$" +
												  "\n Твой баланс " + Money + "$");
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
									Console.WriteLine("\n>:-< Ты выиграл блекджеком! Твой выигрыш составляет" + Bet * 2 + "$" +
													  "\n Твой баланс " + Money + "$");

								}
								else
								{
									Money += Bet * 2;
									Console.WriteLine("\n>:-< Ты выиграл! Твой выигрыш составляет " + Bet + "$" +
													  "\n Твой баланс " + Money + "$");

								}
							//CROUPIER WON
							if (PlayerValue < CroupierValue)
							{
								if (CroupierValue == 21 && CroupierHand.Count == 2)
								{
									Console.WriteLine("\n>:-P Стоимость моих карт " + CroupierValue + ", а стоимость твоих " + PlayerValue +
													  "\nЯ победил блекджеком! Ты проиграл " + Bet + "$" +
													  "\n Твой баланс " + Money + "$");
								}
								else
								{
									Console.WriteLine("\n>:-P Стоимость моих карт " + CroupierValue + ", а стоимость твоих " + PlayerValue +
													  "\nТы проиграл! Ты проиграл " + Bet + "$" +
													  "\n Твой баланс " + Money + "$");

								}
							}
							//NOBODY WINS
							if (PlayerValue == CroupierValue)
							{
								Console.WriteLine("\n(>_<) Стоимость моих карт равна стоимости твоих(Моя стоимость = " + CroupierValue + " Твоя стоимость =" + PlayerValue + ")");
								Money += Bet;
								Console.WriteLine("Ты получаешь свою ставку ( " + Bet + "$ ) обратно.\n" +
												  "Твой баланс " + Money + "$");
							}
						}
					}
					Quit.ExitInGame();
				}
			}
		}
	}
}