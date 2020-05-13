using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDB_analisys.Model
{
	class TrelloCard : AbstractModel
	{
		//description
		public string Desc { get; set; }

		public string Closed { get; set; }

		public string DateLastActivity { get; set; }

		public string Due { get; set; }

		public string DueComplete { get; set; }

		public string ListId { get; set; }
	}
}
