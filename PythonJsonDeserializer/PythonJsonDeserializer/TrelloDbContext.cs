using PythonJsonDeserializer.Model;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythonJsonDeserializer
{
	class TrelloDbContext : DbContext
	{
		public TrelloDbContext()
			: base("DbConnection")
		{ }

		public DbSet<TrelloBoard> Boards { get; set; }
		public DbSet<TrelloList> Lists { get; set; }
		public DbSet<TrelloCard> Cards { get; set; }
		public DbSet<CardTerm> CardTerms { get; set; }
		public DbSet<TrelloMember> Members { get; set; }
		public DbSet<MemberCard> MembersCards { get; set; }
	}
}
