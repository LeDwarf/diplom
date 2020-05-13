using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythonJsonDeserializer.Model
{
	class TrelloMember : AbstractModel
	{
		public string FullName { get; set; }

		public string Username { get; set; }
	}
}
