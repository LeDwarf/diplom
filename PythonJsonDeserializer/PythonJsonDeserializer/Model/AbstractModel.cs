﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythonJsonDeserializer.Model
{
	public abstract class AbstractModel
	{
		public string Id { get; set; }

		public string Name { get; set; }
	}
}
