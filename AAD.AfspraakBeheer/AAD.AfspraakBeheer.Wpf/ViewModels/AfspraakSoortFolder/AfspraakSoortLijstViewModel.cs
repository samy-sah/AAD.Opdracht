using AAD.AfspraakBeheer.Common;
using AAD.AfspraakBeheer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.AfspraakBeheer.Wpf.ViewModels.AfspraakSoortFolder
{
    public class AfspraakSoortLijstViewModel : AfspraakBeheerBaseViewModel
    {
        #region Fields & Properties
        private FullObservableCollection<AfspraakSoort> _afsprakenSoort;
        private AfspraakSoort _geselecteerdeAfspraakSoort;

        public FullObservableCollection<AfspraakSoort> AfsprakenSoort
        {
            get { return _afsprakenSoort; }
            set
            {
                SetProperty(ref _afsprakenSoort, value);
            }
        }

        public AfspraakSoort GeselecteerdeAfspraakSoort
        {
            get { return _geselecteerdeAfspraakSoort; }
            set
            {
                SetProperty(ref _geselecteerdeAfspraakSoort, value);
            }
        }
        #endregion


        #region Constructors

        public AfspraakSoortLijstViewModel()
        {
            AfsprakenSoort = Repository.GetAfsprakenSoort();
            Titel = "Afspraken Soort";
        }
        #endregion
    }
}
