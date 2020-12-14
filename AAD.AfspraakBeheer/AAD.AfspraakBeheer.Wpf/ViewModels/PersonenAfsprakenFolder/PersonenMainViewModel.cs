using AAD.AfspraakBeheer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.AfspraakBeheer.Wpf.ViewModels.PersonenAfsprakenFolder
{
    public class PersonenMainViewModel : AfspraakBeheerBaseViewModel
    {
        #region Fields & Properties
        private AfspraakBeheerBaseViewModel _persoonLijst;
        private AfspraakBeheerBaseViewModel _persoonDetail;
        private AfspraakBeheerBaseViewModel _afspraakBeheerLijst;



        public AfspraakBeheerBaseViewModel PersoonLijst
        {
            get { return _persoonLijst; }
            set
            {
                SetProperty(ref _persoonLijst, value);
            }
        }
        public AfspraakBeheerBaseViewModel PersoonDetail
        {
            get { return _persoonDetail; }
            set
            {
                SetProperty(ref _persoonDetail, value);
            }
        }

        public AfspraakBeheerBaseViewModel AfspraakBeheerLijst
        {
            get { return _afspraakBeheerLijst; }
            set
            {
                SetProperty(ref _afspraakBeheerLijst, value);
            }
        }

        #endregion


        #region Constructors

        public PersonenMainViewModel()
        {
            PersoonLijst = new PersoonLijstViewModel();
            PersoonDetail = new PersoonDetailViewModel();
            AfspraakBeheerLijst = new AfspraakBeheerDetailViewModel();
            
            PersoonLijst.PropertyChanged += PersoonLijst_PropertyChanged;
        }
        #endregion

        /// <summary>
        /// Gebruik maken van Mediator pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PersoonLijst_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "GeselecteerdePersoon":
                    (PersoonDetail as PersoonDetailViewModel).GeselecteerdePersoon = (PersoonLijst as PersoonLijstViewModel).GeselecteerdePersoon;
                    (AfspraakBeheerLijst as AfspraakBeheerDetailViewModel).GeselecteerdePersoon = (PersoonLijst as PersoonLijstViewModel).GeselecteerdePersoon;
                    break;
                default:
                    break;
            }
        }
    }
}