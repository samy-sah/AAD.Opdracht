using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.AfspraakBeheer.Data
{
    internal static class AfspraakBeheerSeed
    {

        internal static void Seed(AfspraakBeheerContext context)
        {
			List<Persoon> personen = new List<Persoon>
			{
				new Persoon("Samy Sah", DateTime.Today),
				new Persoon("Jef Bezos", DateTime.Now.AddDays(14)),
				new Persoon("Bill Gates", DateTime.Now.AddDays(30)),
				new Persoon("Test Tester", DateTime.Now.AddDays(25))
			};

			List<Agenda> agendas = new List<Agenda>
			{
				new Agenda(AgendaSoort.Student, "Student", personen[0]),
				new Agenda(AgendaSoort.CEO, "CEO", personen[1]),
				new Agenda(AgendaSoort.CEO, "CEO", personen[2]),
				new Agenda(AgendaSoort.CEO, "CEO", personen[3])
			};
			List<AfspraakSoort> afspraakSoorten = new List<AfspraakSoort>
			{
				new AfspraakSoort("PersoonlijkeAfspraak", "Nakijken van de tanden"),
				new AfspraakSoort("ProfessioneleAfspraak", "Nieuwe project"),
				new AfspraakSoort("ProfessioneleAfspraak", "Nieuwe update"),
				new AfspraakSoort("ProfessioneleAfspraak", "Nieuwe nnnupdate")
			};


			context.Afspraken.Add(new Afspraak(agendas[0], afspraakSoorten[0], "Tandarts", personen[0], TimeSpan.FromHours(8.0), TimeSpan.FromHours(9.0))); ;
			context.Afspraken.Add(new Afspraak(agendas[1], afspraakSoorten[1], "Business-meeting", personen[1], TimeSpan.FromHours(10.0), TimeSpan.FromHours(10.5)));
			context.Afspraken.Add(new Afspraak(agendas[2], afspraakSoorten[2], "Meeting", personen[2], TimeSpan.FromHours(14.0), TimeSpan.FromHours(15.0)));
			context.Afspraken.Add(new Afspraak(agendas[3], afspraakSoorten[3], "Meetijjng", personen[3], TimeSpan.FromHours(16.0), TimeSpan.FromHours(17.0)));

			context.SaveChanges();

		}
    }
}
