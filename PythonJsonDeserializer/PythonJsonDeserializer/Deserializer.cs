using Newtonsoft.Json;
using PythonJsonDeserializer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythonJsonDeserializer
{
	class Deserializer<T> where T : AbstractModel
	{

		public List<AbstractModel> jsonDeserialize(string jsonString)
		{
			List<T> deserializedData = JsonConvert.DeserializeObject<List<T>>(jsonString);
			List<AbstractModel> ab_stract = new List<AbstractModel>();
			foreach (T data in deserializedData)
			{
				ab_stract.Add(data);
			}
			return ab_stract;
		}
	}
}
