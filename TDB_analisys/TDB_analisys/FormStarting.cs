using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDB_analisys.Model;

namespace TDB_analisys
{
	public partial class FormStarting : Form
	{
		public FormStarting()
		{
			InitializeComponent();
		}

		private void button_test_Click(object sender, EventArgs e)
		{
			string cardDateOfCreation = "";
			int cardDateOfCreationInt = 0;
			using (TrelloDbContext db = new TrelloDbContext())
			{
				var cards = db.Cards;
				foreach (TrelloCard card in cards)
				{
					cardDateOfCreation = "0x"+card.Id.Substring(0,8);
					cardDateOfCreationInt = Convert.ToInt32(cardDateOfCreation, 16);
					MessageBox.Show((UnixTimeStampToDateTime(cardDateOfCreationInt)).ToString(), "Дата создания", MessageBoxButtons.OK);
					MessageBox.Show((Convert.ToDateTime(card.DateLastActivity)).ToString(), "Дата последней активности", MessageBoxButtons.OK);
					//break;
				}
				db.SaveChanges();
			}	
		}

		public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
		{
			// Unix timestamp is seconds past epoch
			System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
			dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
			return dtDateTime;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Program.myBoardId = textBox1.Text;
		}
	}
}
