using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.AfspraakBeheer.Wpf.ViewModels.AfspraakSoortFolder
{
    public class AfspraakSoortMainViewModel : AfspraakBeheerBaseViewModel
    {
        #region Fields & Properties
        private AfspraakBeheerBaseViewModel _afspraakSoortLijst;
        private AfspraakBeheerBaseViewModel _afspraakSoortDetail;
        private AfspraakBeheerBaseViewModel _afspraakSoortToevoegen;


        public AfspraakBeheerBaseViewModel AfspraakSoortLijst
        {
            get { return _afspraakSoortLijst; }
            set
            {
                SetProperty(ref _afspraakSoortLijst, value);
            }
        }

        public AfspraakBeheerBaseViewModel AfspraakSoortDetail
        {
            get { return _afspraakSoortDetail; }
            set
            {
                SetProperty(ref _afspraakSoortDetail, value);
            }
        }

        public AfspraakBeheerBaseViewModel AfspraakSoortToevoegen
        {
            get { return _afspraakSoortToevoegen; }
            set
            {
                SetProperty(ref _afspraakSoortToevoegen, value);
            }
        }

        #endregion


        #region Constructors

        public AfspraakSoortMainViewModel()
        {
            AfspraakSoortLijst = new AfspraakSoortLijstViewModel();
            AfspraakSoortDetail = new AfspraakSoortDetailViewModel();
            AfspraakSoortToevoegen = new AfspraakBeheerDetailViewModel();

            AfspraakSoortLijst.PropertyChanged += AfspraakLijst_PropertyChanged;
        }
        #endregion

        /// <summary>
        /// Gebruik maken van Mediator pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AfspraakLijst_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "GeselecteerdeAfspraakSoort":
                    (AfspraakSoortDetail as AfspraakSoortDetailViewModel).GeselecteerdeAfspraakSoort = (AfspraakSoortLijst as AfspraakSoortLijstViewModel).GeselecteerdeAfspraakSoort;
                    break;
                default:
                    break;
            }
        }

    }
}
