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
	public partial class FormChart : Form
	{
		public FormChart()
		{
			InitializeComponent();
			comboBox1.SelectedIndex = 0;
			FormStarting form = new FormStarting();
			form.Show();
		}

		//public string myBoardId = "nU6GjV5G";
		List<DateTime> listDatesCreate = new List<DateTime>();
		List<DateTime> listDatesDue = new List<DateTime>();
		List<DateTime> listDatesLast = new List<DateTime>();
		List<String> listNames = new List<String>();
		List<Boolean> listCompleted = new List<Boolean>();
		int completed;
		double timeMid;
		double timeMidComplete;

		private void getData()
		{
			listDatesCreate.Clear(); listDatesDue.Clear(); listDatesLast.Clear();
			listNames.Clear(); listCompleted.Clear();
			completed = 0; timeMid = 0;
			DateTime cardDateOfCreation = new DateTime();
			DateTime cardDateLastActivity = new DateTime();
			DateTime cardDateDue = new DateTime();
			using (TrelloDbContext db = new TrelloDbContext())
			{
				var lists = db.Lists;
				List<string> listIds = new List<string>();
				foreach (TrelloList list in lists)
				{
					if (list.BoardId == Program.myBoardId)
					{
						listIds.Add(list.Id);
					}
				}
				var cards = db.Cards;
				foreach (TrelloCard card in cards)
				{
					if (listIds.Contains(card.ListId))
					{
						cardDateLastActivity = Convert.ToDateTime(card.DateLastActivity);
						listDatesLast.Add(cardDateLastActivity);
						cardDateDue = Convert.ToDateTime(card.Due);
						listDatesDue.Add(cardDateDue);
						string cardDateOfCreationStr = "0x" + card.Id.Substring(0, 8);
						int cardDateOfCreationInt = Convert.ToInt32(cardDateOfCreationStr, 16);
						cardDateOfCreation = UnixTimeStampToDateTime(cardDateOfCreationInt);
						listDatesCreate.Add(cardDateOfCreation);
						listNames.Add(card.Name);
						if (card.DueComplete == "true")
						{
							listCompleted.Add(true);
							completed++;
						}
						else listCompleted.Add(false);
					}				
				}
				db.Dispose();
			}

			double timeGeneral = 0;
			double timeGenComplete = 0;
			//среднее время выполнения задачи
			for (int i = 0; i < listNames.Count; i++)
			{
				double time = listDatesDue[i].Subtract(listDatesCreate[i]).TotalHours;
				timeGeneral += time;
				if (listCompleted[i])
				{
					timeGenComplete += time;
				}
			}
			timeMid = timeGeneral / listNames.Count;
			timeMidComplete = timeGenComplete / completed;
		}

		private void buttonFill_Click(object sender, EventArgs e)
		{
			buttonFill.Enabled = false;
			getData();
			chart1.Visible = true;
			switch (comboBox1.SelectedIndex)
			{
				case 0: drawDiagram_PlannedHours();
					break;
				case 1: drawDiagram_PlannedDays();
					break;
				case 2:
					drawDiagram_DoneHours();
					break;
			}
		}

		public void drawDiagram_PlannedDays()
		{
			label3.Visible = false;
			labelTime.Visible = false;
			labelCount.Text = listNames.Count.ToString();
			chart1.Series.Clear();
			chart1.Titles.Clear();
			chart1.Titles.Add("Запланированные задачи");
			chart1.Series.Add("Дни");
			chart1.Series["Дни"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeBar;
			for (int i = 0; i < listDatesCreate.Count; i++)
			{
				//DateTime earlest = listDatesCreate.Min();
				//System.TimeSpan dayStart = listDatesCreate[i].Subtract(earlest);
				chart1.Series["Дни"].Points.AddXY(listNames[i], listDatesCreate[i].Day, listDatesDue[i].Day);
			}
			buttonFill.Enabled = true;
		}

		public void drawDiagram_PlannedHours()
		{
			label3.Visible = true;
			labelTime.Visible = true;
			labelTime.Text = timeMid.ToString();
			labelCount.Text = listNames.Count.ToString();
			chart1.Series.Clear();
			chart1.Titles.Clear();
			chart1.Titles.Add("Запланированные задачи");
			chart1.Series.Add("Часы");
			chart1.Series["Часы"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
			for (int i = 0; i < listDatesCreate.Count; i++)
			{
				System.TimeSpan time = listDatesDue[i].Subtract(listDatesCreate[i]);
				chart1.Series["Часы"].Points.AddXY(listNames[i], time.TotalHours);
			}
			buttonFill.Enabled = true;
		}

		public void drawDiagram_DoneHours()
		{
			label3.Visible = true;
			labelTime.Visible = true;
			labelTime.Text = timeMidComplete.ToString();
			labelCount.Text = completed.ToString();
			chart1.Series.Clear();
			chart1.Titles.Clear();
			chart1.Titles.Add("Завершенные задачи");
			chart1.Series.Add("Часы");
			chart1.Series["Часы"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
			for (int i = 0; i < listDatesCreate.Count; i++)
			{
				if (!listCompleted[i]) continue;
				System.TimeSpan time = listDatesDue[i].Subtract(listDatesCreate[i]);
				chart1.Series["Часы"].Points.AddXY(listNames[i], time.TotalHours);
			}
			buttonFill.Enabled = true;
		}

		public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
		{
			// Unix timestamp is seconds past epoch
			System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
			dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
			return dtDateTime;
		}
	}
}
