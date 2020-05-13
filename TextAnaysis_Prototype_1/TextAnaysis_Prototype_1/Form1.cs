using Iveonik.Stemmers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextAnaysis_Prototype_1.Model;

namespace TextAnaysis_Prototype_1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			stopwordsInit();
		}

		private void buttonProcess_Click(object sender, EventArgs e)
		{
			//string inputText = textBox1.Text;
			//process(inputText);
			using (TrelloDbContext db = new TrelloDbContext())
			{
				var cards = db.Cards;
				foreach (TrelloCard card in cards)
				{
					process(card.Desc, card.Id);
				}
				db.SaveChanges();	
			}
			MessageBox.Show("Готово", "Готово", MessageBoxButtons.OK);
		}

		//готовим список стопслов
		List<string> stopwords = new List<string>();
		public void stopwordsInit()
		{
			string line;  
			System.IO.StreamReader file =
				new System.IO.StreamReader(@"C:\\Users\Пользователь\source\repos\TextAnaysis_Prototype_1\TextAnaysis_Prototype_1\stop-words.txt");
			while ((line = file.ReadLine()) != null)
			{
				stopwords.Add(line);
			}
			file.Close();
		}

		//обработка ввода
		void process(string s, string cardId)
		{
			List<string> words = new List<string>();
			//вставляем пробелы перед n
			/*string s = input;
			for (int i = 0; i<s.Length; i++)
			{
				if (i < s.Length && s[i] == '\\' && s[i + 1] == 'n')
				{
					s = input.Insert(i+1, " ");
				}
			}*/

			//разбиваем на слова
			//words.AddRange(s.Split(' '));

			char[] badChars = new char[] { '\\', '*', '>', '\'', '"', ':', ',', '.', '@', '!', '?', '-', '+', '&'};
			//удаляем плохие символы
			/*for (int i = 0; i < words.Count; i++)
			{
				string word = words[i];
				for (int j = 0; j < word.Length; j++)
				{
					if (badChars.Contains(word[j]))
					{
						if (j < word.Length && word[j]=='\\' && word[j + 1] == 'n')
						{
							words[i] = word.Remove(j, 2);
							word=words[i];
						}
						else
						{
							words[i] = word.Remove(j, 1);
							word = words[i];
						}	
					}
				}
			}*/

			//альтернатива: заменяем плохие символы пробелами, ЗАТЕМ разбиваем на слова
			string betterS = "";
			for (int i = 0; i < s.Length; i++)
			{
				if (badChars.Contains(s[i]))
				{
					if (i < s.Length && s[i] == '\\' && s[i + 1] == 'n')
					{
						i++;
					}
					betterS += " ";
				}
				else
				{
					betterS += s[i];
				}
			}
			words.AddRange(betterS.Split(' '));


			//удаляем стоп-слова
			for (int i = 0; i<words.Count; i++)
			{
				if (stopwords.Contains(words[i].ToLower()))
				{
					words.Remove(words[i]);
					i--;
				}
			}

			//стемминг
			IStemmer stemmerRU = new RussianStemmer();
			IStemmer stemmerEN = new EnglishStemmer();
			for (int i = 0; i < words.Count; i++)
			{
				string oldword = words[i];
				string neword = stemmerRU.Stem(words[i]);
				neword = stemmerEN.Stem(neword);
				words[i] = neword;
			}

			//считаем частоты
			string[,] frequencyTable = new string[2, words.Count];
			int length = 0;
			foreach (var n in words)
			{
				if (n != "" && n != " ")
				{
					//MessageBox.Show(n, "Слово:", MessageBoxButtons.OK);
					bool isNew = true;
					for (int j = 0; j < length; j++)
					{
						if (frequencyTable[0, j] == n)
						{
							frequencyTable[1, j] = (Convert.ToInt32(frequencyTable[1, j]) + 1).ToString();
							isNew = false;
						}
					}
					if (isNew)
					{
						length++;
						frequencyTable[0, length - 1] = n;
						frequencyTable[1, length - 1] = "1";
					}
				}	
			}

			//запись в бд
			using (TrelloDbContext context = new TrelloDbContext())
			{
				for (int n = 0; n< length; n++)
				{
					CardTerm term = new CardTerm { Id = cardId+n.ToString(), Name = frequencyTable[0, n], Frequency = Convert.ToInt32(frequencyTable[1, n]), CardId = cardId };
					context.CardTerms.Add(term);
					context.SaveChanges();
				}				
			}

			//вывод
			/*s = "";
			for (int j = 0; j < length; j++)
			{
				s += frequencyTable[0,j] + " | " + frequencyTable[1,j] + "\n";
			}
			MessageBox.Show(s, "Частоты:", MessageBoxButtons.OK);*/
		}

		private void buttonSW_Click(object sender, EventArgs e)
		{
			string s = "";
			for (int i = 0; i<stopwords.Count; i++)
			{
				s += stopwords[i] + "; ";
				if (i % 10 == 0) { s += "\n"; }
			}
			MessageBox.Show(s, "Словарь стоп-слов:", MessageBoxButtons.OK);
		}


		//проверка работы стемминга, не используется в основной программе
		private static void TestStemmer(IStemmer stemmer, params string[] words)
		{
			Console.WriteLine("Stemmer: " + stemmer);
			foreach (string word in words)
			{
				Console.WriteLine(word + " --> " + stemmer.Stem(word));
			}
		}
	}
}
