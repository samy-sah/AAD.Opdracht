using AAD.AfspraakBeheer.Common;
using AAD.AfspraakBeheer.Data;
using AAD.AfspraakBeheer.Data.Exceptions.AfspraakExceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AAD.AfspraakBeheer.Business
{
	public class AfspraakBeheerRepositoryDisconnected : IAfspraakBeheerRepository
	{
		public FullObservableCollection<Persoon> GetPersonen()
		{
			try
			{
				using (AfspraakBeheerContext context = new AfspraakBeheerContext())
				{
					return new FullObservableCollection<Persoon>(context.Personen.Include(a => a.AfsprakenTot).ToList());
				}
			}
			catch
			{
				throw;
			}


		}

		public FullObservableCollection<Afspraak> GetAfspraken()
		{
			try
			{
				using (AfspraakBeheerContext context = new AfspraakBeheerContext())
				{
					return new FullObservableCollection<Afspraak>(context.Afspraken.Include(e => e.Eigenaar).Include(a => a.AfspraakSoorten).Include(g => g.Agenda).ToList());
				}
			}
			catch (AfspraakEindTijdException ex)
			{
				throw new AfspraakStartTijdException();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw;
			}
		}

		public FullObservableCollection<AfspraakSoort> GetAfsprakenSoort()
		{
			try
			{
				using (AfspraakBeheerContext context = new AfspraakBeheerContext())
				{
					return new FullObservableCollection<AfspraakSoort>(context.AfspraakSoorten.ToList());
				}
			}
			catch (Exception ex)
			{
				switch (ex.HResult)
				{
					default:
						throw;
				}
			}
		}

		public FullObservableCollection<Afspraak> GetAfsprakenVanEigenaar(int EigenaarId)
		{
			try
			{
				using (AfspraakBeheerContext context = new AfspraakBeheerContext())
				{
					return new FullObservableCollection<Afspraak>(context.Afspraken.Include(a => a.AfspraakSoorten).Include(g => g.Agenda).Include(e => e.Eigenaar).Where(e => e.Eigenaar.Id == EigenaarId).ToList());
				}
			}
			catch (Exception ex)
			{
				switch (ex.HResult)
				{
					default:
						throw;
				}
			}
		}

		/// <summary>
		/// Zoek een persoon aan de hand van de Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Persoon FindPersoonById(int id)
		{
			try
			{
				using (AfspraakBeheerContext context = new AfspraakBeheerContext())
				{
					return context.Personen.FirstOrDefault(p => p.Id == id);
				}
			}
			catch (Exception ex)
			{
				switch (ex.HResult)
				{
					default:
						throw;
				}
			}
		}

		/// <summary>
		/// Zoek een persoon aan de hand van de naam
		/// </summary>
		/// <param name="naam"></param>
		/// <returns></returns>
		public Persoon FindPersoonByNaam(String naam)
		{
			try
			{
				using (AfspraakBeheerContext context = new AfspraakBeheerContext())
				{
					return context.Personen.FirstOrDefault(p => p.Naam == naam);
				}
			}
			catch (Exception ex)
			{
				switch (ex.HResult)
				{
					default:
						throw;
				}
			}
		}

		/// <summary>
		/// Voeg een Persoon toe
		/// </summary>
		/// <param name="persoon"></param>
		/// <returns></returns>
		public Persoon AddPersoon(Persoon persoon)
		{
			try
			{
				using (AfspraakBeheerContext context = new AfspraakBeheerContext())
				{
					context.Personen.Add(persoon);
					context.SaveChanges();
					return persoon;
				}
			}
			catch (Exception ex)
			{
				switch (ex.HResult)
				{
					default:
						throw;
				}
			}
		}

		public AfspraakSoort AddAfspraakSoort(AfspraakSoort afspraakSoort)
		{
			try
			{
				using (AfspraakBeheerContext context = new AfspraakBeheerContext())
				{
					context.AfspraakSoorten.Add(afspraakSoort);
					context.SaveChanges();
					return afspraakSoort;
				}
			}
			catch (Exception ex)
			{
				switch (ex.HResult)
				{
					default:
						throw;
				}
			}
		}

		/// <summary>
		/// Verwijder een persoon
		/// </summary>
		/// <param name="persoon"></param>
		public void RemovePersoon(Persoon persoon)
		{
			try
			{
				using (AfspraakBeheerContext context = new AfspraakBeheerContext())
				{


						var library = context.Personen
					   .Include(x => x.AfsprakenTot)
					   .Include(x => x.AfspraakSoort)
					   .Include(x => x.Agenda)
					   .SingleOrDefault(x => x.Id == persoon.Id);
					foreach (Afspraak afspraak in library.AfsprakenTot.ToList())
					{
						context.Afspraken.Remove(afspraak);
					}
					context.Personen.Remove(library);
					context.SaveChanges();



					//var librarys = context.Afspraken
					//	.Include(x => x.AfspraakSoorten)
					//	.Include(x => x.Agenda)
					//	.Include(x => x.Eigenaar)
					//	.SingleOrDefault(x => x.AfspraakId == persoon.Id);

					//context.Personen.Remove(librarys.Eigenaar);
					//context.SaveChanges();

					//var adv = (context.Personen.Include(a => a.AfsprakenTot)

					//.FirstOrDefault(b => b.Id == persoon.Id));
					//context.Personen.Remove(adv);


					////var library = context.Afspraken.Include(x => x.AfspraakSoorten).SingleOrDefault(x => x.AfspraakId == persoon.Id);

					////library.AfspraakSoorten = null;
					////context.Afspraken.Remove(library);

					////if ((persoon = context.Personen.FirstOrDefault(p => p.Id == persoon.Id)) != null)
					////{
					////	context.Personen.Remove(persoon);
					////	context.SaveChanges();
					////}
					//context.SaveChanges();

				}
			}
			catch (Exception ex)
			{				
				switch (ex.HResult)
				{
					default:
						throw;
				}
			}
		}

		public void RemoveAfspraak(Afspraak afspraak)
		{
			try
			{
				using (AfspraakBeheerContext context = new AfspraakBeheerContext())
				{
					if ((afspraak = context.Afspraken.FirstOrDefault(p => p.AfspraakId == afspraak.AfspraakId)) != null)
					{
						context.Afspraken.Remove(afspraak);
						context.SaveChanges();
					}
				}
			}
			catch (Exception ex)
			{
				switch (ex.HResult)
				{
					default:
						throw;
				}

			}
		}

		public void RemoveAfspraakSoort(AfspraakSoort afspraakSoort)
		{
			try
			{
				using (AfspraakBeheerContext context = new AfspraakBeheerContext())
				{
					if ((afspraakSoort = context.AfspraakSoorten.FirstOrDefault(p => p.Id == afspraakSoort.Id)) != null)
					{
						context.AfspraakSoorten.Remove(afspraakSoort);
						context.SaveChanges();
					}
				}
			}
			catch (Exception ex)
			{
				switch (ex.HResult)
				{
					default:
						throw;
				}

			}
		}

		/// <summary>
		/// Bewerk Persoon
		/// </summary>
		/// <param name="persoon"></param>
		/// <returns></returns>
		public Persoon UpdatePersoon(Persoon persoon)
		{

			try
			{
				using (AfspraakBeheerContext context = new AfspraakBeheerContext())
				{
					if (!context.Personen.Local.Contains(persoon))
					{
						context.Personen.Attach(persoon);
						context.Entry(persoon).State = System.Data.Entity.EntityState.Modified;
					}
					context.SaveChanges();
					return persoon;
				}
			}
			catch (Exception ex)
			{
				switch (ex.HResult)
				{
					default:
						throw;
				}
			}
		}

		public Afspraak UpdateAfspraak(Afspraak afspraak)
		{

			try
			{
				using (AfspraakBeheerContext context = new AfspraakBeheerContext())
				{
					if (!context.Afspraken.Local.Contains(afspraak))
					{
						context.Afspraken.Attach(afspraak);
						context.Entry(afspraak).State = System.Data.Entity.EntityState.Modified;
					}
					context.SaveChanges();
					return afspraak;
				}
			}
			catch (Exception ex)
			{
				switch (ex.HResult)
				{
					default:
						throw;
				}
			}
		}
		public AfspraakSoort UpdateAfspraakSoort(AfspraakSoort afspraakSoort)
		{

			try
			{
				using (AfspraakBeheerContext context = new AfspraakBeheerContext())
				{
					if (!context.AfspraakSoorten.Local.Contains(afspraakSoort))
					{
						context.AfspraakSoorten.Attach(afspraakSoort);
						context.Entry(afspraakSoort).State = System.Data.Entity.EntityState.Modified;
					}
					context.SaveChanges();
					return afspraakSoort;
				}
			}
			catch (Exception ex)
			{
				switch (ex.HResult)
				{
					default:
						throw;
				}
			}
		}
	}
}
