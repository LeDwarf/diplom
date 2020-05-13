using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnaysis_Prototype_1.Model
{
	public class TrelloCard : AbstractModel
	{
		//description
		public string Desc { get; set; }

		public string Closed { get; set; }

		public string DateLastActivity { get; set; }

		public string ListId { get; set; }
	}
}
