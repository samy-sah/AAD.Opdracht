using AAD.AfspraakBeheer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.AfspraakBeheer.Business.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
			Persoon p = null;

			try
			{
				IAfspraakBeheerRepository repository = new AfspraakBeheerRepositoryConnected();

				foreach (Persoon persoon in repository.GetPersonen())
					Console.WriteLine(persoon);

				repository.AddPersoon(new Persoon("Hilarius Warwinkel", DateTime.Today));
				Console.WriteLine("-------------------");

				foreach (Persoon persoon in repository.GetPersonen())
					Console.WriteLine(persoon);

				p = repository.FindPersoonByNaam("Hilarius Warwinkel");
				if (p != null)
				{
					p.Naam = p.Naam.ToUpper();
					repository.UpdatePersoon(p);
				}
				Console.WriteLine("-------------------");

				//foreach (Persoon persoon in repository.GetPersonen())
				//	Console.WriteLine(persoon);

				//if (p != null)
				//	repository.RemovePersoon(p);
				//Console.WriteLine("-------------------");

				//foreach (Persoon persoon in repository.GetPersonen())
				//	Console.WriteLine(persoon);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			try
			{
				IAfspraakBeheerRepository repository = new Business.AfspraakBeheerRepositoryDisconnected();

				if (p != null)
					repository.RemovePersoon(p);
				Console.WriteLine("-------------------");

				foreach (Persoon persoon in repository.GetPersonen())
					Console.WriteLine(persoon);

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.Write("\n\n\nToets om te stoppen... ");
			Console.ReadKey(true);
		}
	}
}
