using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace AAD.AfspraakBeheer.Data
{
	public class AfspraakBeheerContext : DbContext
	{
		#region Fields & Properties

		public DbSet<Persoon> Personen { get; set; }
		public DbSet<Afspraak> Afspraken { get; set; }
		public DbSet<Agenda> Agendas { get; set; }
		public DbSet<AfspraakSoort> AfspraakSoorten { get; set; }


		#endregion

		#region Constructors

		public AfspraakBeheerContext()
			: base("AfspraakBeheer")
		{

		}
		public AfspraakBeheerContext(bool herstart): base("AfspraakBeheer")
		{
			switch(herstart)
			{
				case true:
					Database.SetInitializer(new DropCreateAfspraakBeheerAlways());
					break;
				case false:
					Database.SetInitializer(new DropCreateDatabaseIfModelChangesAfspraakBeheerContext());
					break;
			}
		}
		#endregion
	}
}
