using AAD.AfspraakBeheer.Common;
using AAD.AfspraakBeheer.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.AfspraakBeheer.Business
{
	public interface IAfspraakBeheerRepository
	{
		Persoon AddPersoon(Persoon persoon);
		AfspraakSoort AddAfspraakSoort(AfspraakSoort afspraakSoort);
		Persoon FindPersoonById(int id);
		Persoon FindPersoonByNaam(string naam);
		FullObservableCollection<Persoon> GetPersonen();
		FullObservableCollection<Afspraak> GetAfspraken();
		FullObservableCollection<AfspraakSoort> GetAfsprakenSoort();
		void RemovePersoon(Persoon persoon);
		void RemoveAfspraak(Afspraak afspraak);
		void RemoveAfspraakSoort(AfspraakSoort afspraakSoort);
		Persoon UpdatePersoon(Persoon persoon);
		Afspraak UpdateAfspraak(Afspraak afspraak);
		AfspraakSoort UpdateAfspraakSoort(AfspraakSoort afspraakSoort);
		FullObservableCollection<Afspraak> GetAfsprakenVanEigenaar(int EigenaarId);
	}
}
