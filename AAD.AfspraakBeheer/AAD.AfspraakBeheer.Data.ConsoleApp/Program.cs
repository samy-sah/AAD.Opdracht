using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AAD.AfspraakBeheer.Data.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
				//using (ImmoWinContext context = new ImmoWinContext())
				//{
				//	foreach (Persoon persoon in context.Personen.Include(p => p.Eigendommen))
				//	{
				//		Console.WriteLine(persoon);
				//		foreach (Woning woning in persoon.Eigendommen)
				//			Console.WriteLine($"\t{woning}");
				//	}
				//	Console.WriteLine("-------------------");
				//	foreach (Persoon persoon in context.Personen)
				//	{
				//		Console.WriteLine(persoon);
				//		foreach (Woning woning in persoon.Eigendommen)
				//			Console.WriteLine($"\t{woning}");
				//	}
				//}
				using (AfspraakBeheerContext context = new AfspraakBeheerContext())
				{
					// Eager loading
					context.Afspraken.Load();

					Console.WriteLine("-------------------");
					foreach (Persoon persoon in context.Personen)
					{
						Console.WriteLine(persoon);
						foreach (Afspraak afspraak in persoon.AfsprakenTot)
							Console.WriteLine($"\t{afspraak}");
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"{ex.Message}");
			}

			Console.Write("\n\n\nToets om te verder te gaan... ");
			Console.ReadKey(true);
			//Console.Clear();

			//try
			//{
			//	using (AfspraakBeheerContext context = new AfspraakBeheerContext())
			//	{
			//		Persoon persoon;

			//		persoon = context.Personen.FirstOrDefault(p => p.Naam == "Theo Flatser");
			//		if (persoon == null)
			//		{
			//			if ((persoon = context.Personen.FirstOrDefault(p => p.Naam == "Theo Flitser")) == null)
			//			{
			//				context.Personen.Add(new Persoon("Theo Flitser", DateTime.Today));
			//				Console.WriteLine("Toegevoegd");
			//			}
			//			else
			//			{
			//				persoon.Naam = "Theo Flatser";
			//				Console.WriteLine("Gewijzigd");
			//			}
			//		}
			//		else
			//		{
			//			context.Personen.Remove(persoon);
			//			Console.WriteLine("Verwijderd");
			//		}
			//		context.SaveChanges();
			//	}
			//}
			//catch (Exception ex)
			//{
			//	Console.WriteLine(ex.Message);
			//}
			//Console.Write("\n\n\nToets om te stoppen... ");
			//Console.ReadKey(true);
		}
	}
}
