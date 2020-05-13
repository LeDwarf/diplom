using PythonJsonDeserializer.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PythonJsonDeserializer
{
	class Program
	{
		static void Main(string[] args)
		{
			string startingBoardId = "";
			string startingBoardName = "";

			//Console.WriteLine("Введите id доски Trello");
			//startingBoardId = Console.ReadLine();
			//Console.WriteLine("Введите название проекта / команды");
			//startingBoardName = Console.ReadLine();

			//startingBoardId = "QnqeK3SC"; startingBoardName = "Летний интерсив";
			//startingBoardId = "Ni3BxRJ5"; startingBoardName = "KeenSoft";
			//startingBoardId = "K0C0i8wF"; startingBoardName = "Beamdog Newewinter Nights";
			startingBoardId = "nU6GjV5G"; startingBoardName = "Моя тестовая доска";

			//УДАЛЕНИЕ ВСЕХ ДАННЫХ ПО ДОСКЕ
			//deleteBoard(startingBoardId); return;

			string scriptPath = "C:/Users/Пользователь/source/repos/PythonJsonDeserializer/PythonJsonDeserializer/ApiCallScripts/";
			string scriptFileName;
			string scriptCallUrl; //url api-запроса для скрипта
			string callResult;
			Program program = new Program();

			//добавляем доску в бд
			using (TrelloDbContext db = new TrelloDbContext())
			{
				TrelloBoard board = new TrelloBoard { Id = startingBoardId, Name = startingBoardName };
				db.Boards.Add(board);
				db.SaveChanges();
			}

			//получаем листы доски
			scriptFileName = "call_board_listsv2.py";
			scriptCallUrl = "\"https://api.trello.com/1/boards/"+startingBoardId+"/lists\"";
			callResult = program.runApiCall(scriptPath + scriptFileName + " " + scriptCallUrl, "");
			//Console.WriteLine("Результат " +callResult);
			List<AbstractModel> tlists = new List<AbstractModel>();
			Deserializer<TrelloList> listDeserializer = new Deserializer<TrelloList>();
			tlists = listDeserializer.jsonDeserialize(callResult);

			//перебор полученных листов
			foreach (TrelloList tlist in tlists)
			{
				//отладочный вывод десериализованного содержимого листов
				Console.WriteLine("Лист. Название: "+ decode(tlist.Name) + " / ID: " + tlist.Id + " / Статус: " + tlist.Closed);
				Console.WriteLine();

				//добавляем лист в бд
				using (TrelloDbContext db = new TrelloDbContext())
				{
					//запиили добавление через обект со всеми полями
					TrelloList dblist = new TrelloList { Id = tlist.Id, Name = decode(tlist.Name), Closed = tlist.Closed, BoardId = startingBoardId };
					db.Lists.Add(dblist);
					db.SaveChanges();
				}

				//получаем карточки листа
				scriptFileName = "call_list_cardsv2.py";
				scriptCallUrl = "\"https://api.trello.com/1/lists/" + tlist.Id + "/cards\"";
				//scriptCallUrl = "\"https://api.trello.com/1/lists/59e21320df19579bf6b8e1af/cards\"";
				callResult = program.runApiCall(scriptPath + scriptFileName + " " + scriptCallUrl, "");
				//Console.WriteLine("Результат " + callResult);
				List<AbstractModel> tcards = new List<AbstractModel>();
				Deserializer<TrelloCard> cardDeserializer = new Deserializer<TrelloCard>();
				tcards = cardDeserializer.jsonDeserialize(callResult);

				//Thread.Sleep(5000);
				//перебор полученных карточек
				foreach (TrelloCard tcard in tcards)
				{
					//отладочный вывод десериализованного содержимого карточек
					Console.WriteLine("Карточка. Название: "+ decode(tcard.Name) + " / ID: " + tcard.Id + " / Статус: " + tcard.Closed + " / Описание: "+ decode(tcard.Desc) + " / Последняя активность: "+tcard.DateLastActivity);
					Console.WriteLine();

					//добавляем карточку в бд
					using (TrelloDbContext db = new TrelloDbContext())
					{
						TrelloCard dbcard = new TrelloCard { Id = tcard.Id, Name = decode(tcard.Name), Desc = decode(tcard.Desc), Closed = tcard.Closed, DateLastActivity = tcard.DateLastActivity, Due = tcard.Due, DueComplete = tcard.DueComplete, ListId = tlist.Id };
						db.Cards.Add(dbcard);
						db.SaveChanges();
					}

					//новый код: получаем разработчиков карточки
					scriptFileName = "call_card_members.py";
					scriptCallUrl = "\"https://api.trello.com/1/cards/" + tcard.Id + "/members\"";
					callResult = program.runApiCall(scriptPath + scriptFileName + " " + scriptCallUrl, "");
					//Отладочный вывод members callResult
					//Console.WriteLine("\n Результат запроса card members: " + callResult);
					List<AbstractModel> tmembers = new List<AbstractModel>();
					Deserializer<TrelloMember> memberDeserializer = new Deserializer<TrelloMember>();
					tmembers = memberDeserializer.jsonDeserialize(callResult);					
					foreach (TrelloMember tmember in tmembers)
					{
						try
						{
							using (TrelloDbContext db = new TrelloDbContext())
							{
								TrelloMember dbmember = new TrelloMember { Id = tmember.Id, Name = "", FullName = decode(tmember.FullName), Username = tmember.Username};
								db.Members.Add(dbmember);
								db.SaveChanges();
							}
						}
						catch
						{ }
						using (TrelloDbContext db = new TrelloDbContext())
						{
							//придумай Id. cardid+memberid слишком длинно? cardid+num?
							MemberCard dbmembercard = new MemberCard { Id = tmember.Id+tcard.Id, Name = "", CardId = tcard.Id, MemberId = tmember.Id };
							db.MembersCards.Add(dbmembercard);
							db.SaveChanges();
						}
					}
				}
				Console.WriteLine();
			}
			Console.WriteLine("Конец скрипта. Нажмите любую клавишу");
			Console.Read();
		}

		//запрос к API
		public string runApiCall(string cmd, string args)
		{
			ProcessStartInfo start = new ProcessStartInfo();
			start.FileName = "C:/Users/Пользователь/AppData/Local/Programs/Python/Python37-32/python.exe";
			start.Arguments = cmd;
			start.UseShellExecute = false;// Do not use OS shell
			start.CreateNoWindow = true; // We don't need new window
			start.RedirectStandardOutput = true;// Any output, generated by application will be redirected back
			start.RedirectStandardError = true; // Any error in standard output will be redirected back (for example exceptions)
			using (Process process = Process.Start(start))
			{
				using (StreamReader reader = process.StandardOutput)
				{
					string stderr = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
					string result = reader.ReadToEnd(); // Here is the result of StdOut(for example: print "test")
					return result;
				}
			}
		}

		//декодирование string
		public static string decode(string encoded)
		{
			byte[] bytesEnc = Encoding.UTF8.GetBytes(encoded);
			byte[] bytesDec = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding(866), bytesEnc);
			string decoded = Encoding.GetEncoding(1251).GetString(bytesDec);
			return decoded;
		}

		//очистка бд
		public static void deleteBoard(string myBoardId)
		{
			using (TrelloDbContext db = new TrelloDbContext())
			{
				TrelloBoard board = db.Boards
					.Where(b => b.Id == myBoardId)
					.FirstOrDefault();
				db.Boards.Remove(board);
				var lists = db.Lists;
				List<string> listIds = new List<string>();
				foreach (TrelloList list in lists)
				{
					if (list.BoardId == myBoardId)
					{
						listIds.Add(list.Id);
						db.Lists.Remove(list);
					}
				}
				var cards = db.Cards;
				List<string> cardIds = new List<string>();
				foreach (TrelloCard card in cards)
				{
					if (listIds.Contains(card.ListId))
					{
						cardIds.Add(card.Id);
						db.Cards.Remove(card);
					}
				}
				var memberscards = db.MembersCards;
				List<string> memberIds = new List<string>();
				foreach (MemberCard membercard in memberscards)
				{
					if (cardIds.Contains(membercard.CardId))
					{
						memberIds.Add(membercard.MemberId);
						db.MembersCards.Remove(membercard);
					}
				}
				var members = db.Members;
				foreach (TrelloMember member in members)
				{
					if (memberIds.Contains(member.Id))
					{
						db.Members.Remove(member);
					}
				}
				db.SaveChanges();
				db.Dispose();
			}
			Console.WriteLine("Данные по проекту удалены");
			return;
		}
	}
}
