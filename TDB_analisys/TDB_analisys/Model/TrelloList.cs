using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDB_analisys.Model
{
	class TrelloList : AbstractModel
	{
		public string Closed { get; set; }

		public string BoardId { get; set; }
	}
}
