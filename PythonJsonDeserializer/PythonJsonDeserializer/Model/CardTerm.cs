using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythonJsonDeserializer.Model
{
	class CardTerm : AbstractModel
	{
		public int Frequency { get; set; }

		public string CardId { get; set; }
	}
}
