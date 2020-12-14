using AAD.AfspraakBeheer.Common;
using AAD.AfspraakBeheer.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.AfspraakBeheer.Wpf.ViewModels
{
    public class AfspraakBeheerDetailViewModel : AfspraakBeheerBaseViewModel
    {
        #region Fields & Properties

        private Persoon _geselecteerdePersoon;
        private FullObservableCollection<Afspraak> _gelecteerdepersoonzijnafspraken;
        private Boolean _persoonGewijzigd;
        private Boolean _persoonVerwijderen;

        public Persoon GeselecteerdePersoon
        {
            get { return _geselecteerdePersoon; }
            set
            {
                SetProperty(ref _geselecteerdePersoon, value);
                GeselecteerdePersoon.PropertyChanged += GeselecteerdePersoon_PropertyChanged;
                PersoonGewijzigd = false;
                PersoonVerwijderen = false;
                Gelecteerdepersoonzijnafspraken = Repository.GetAfsprakenVanEigenaar(GeselecteerdePersoon.Id);
            }
        }

        public FullObservableCollection<Afspraak> Gelecteerdepersoonzijnafspraken
        {
            get { return _gelecteerdepersoonzijnafspraken; }
            set
            {
                SetProperty(ref _gelecteerdepersoonzijnafspraken, value);
            }
        }

        public Boolean PersoonGewijzigd
        {
            get { return _persoonGewijzigd; }
            set
            {
                SetProperty(ref _persoonGewijzigd, value);
            }
        }

        public Boolean PersoonVerwijderen
        {
            get { return _persoonVerwijderen; }
            set
            {
                SetProperty(ref _persoonVerwijderen, value);
            }
        }

        #endregion

        #region Constructors

        private void GeselecteerdePersoon_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            PersoonGewijzigd = true;
            PersoonVerwijderen = true;
        }
        #endregion
    }
}
