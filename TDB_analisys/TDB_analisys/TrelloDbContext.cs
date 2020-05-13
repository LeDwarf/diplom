using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDB_analisys.Model;

namespace TDB_analisys
{
	class TrelloDbContext : DbContext
	{
		public TrelloDbContext()
			: base("DbConnection")
		{ }

		public DbSet<TrelloBoard> Boards { get; set; }
		public DbSet<TrelloList> Lists { get; set; }
		public DbSet<TrelloCard> Cards { get; set; }
	}
}
