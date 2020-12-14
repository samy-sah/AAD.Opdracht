using AAD.AfspraakBeheer.Common;
using AAD.AfspraakBeheer.Data;

namespace AAD.AfspraakBeheer.Wpf.ViewModels.AfspraakFolder
{
    public class AfsprakenLijstViewModel : AfspraakBeheerBaseViewModel
    {
        #region Fields & Properties

        private FullObservableCollection<Afspraak> _afspraken;
        private Afspraak _geselecteerdeAfspraak;


        public FullObservableCollection<Afspraak> Afspraken
        {
            get { return _afspraken; }
            set
            {
                SetProperty(ref _afspraken, value);
            }
        }
        public Afspraak GeselecteerdeAfspraak
        {
            get { return _geselecteerdeAfspraak; }
            set
            {
                SetProperty(ref _geselecteerdeAfspraak, value);
            }
        }
        #endregion

        #region Constructors

        public AfsprakenLijstViewModel()
        {
            Afspraken = Repository.GetAfspraken();
            Titel = "Afspraken";
        }
        #endregion

    }
}
          