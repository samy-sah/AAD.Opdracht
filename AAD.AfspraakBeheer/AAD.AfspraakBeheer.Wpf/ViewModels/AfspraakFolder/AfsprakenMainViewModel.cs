using AAD.AfspraakBeheer.Wpf.ViewModels.AfspraakFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.AfspraakBeheer.Wpf.ViewModels.AfspraakFolder
{

    public class AfsprakenMainViewModel : AfspraakBeheerBaseViewModel

    {
        #region Fields & Properties

        private AfspraakBeheerBaseViewModel _afspraakLijst;
        private AfspraakBeheerBaseViewModel _afspraakDetail;


        public AfspraakBeheerBaseViewModel AfspraakLijst
        {
            get { return _afspraakLijst; }
            set
            {
                SetProperty(ref _afspraakLijst, value);
            }
        }

        public AfspraakBeheerBaseViewModel AfspraakDetail
        {
            get { return _afspraakDetail; }
            set
            {
                SetProperty(ref _afspraakDetail, value);
            }
        }
        #endregion
        #region Constructors

        public AfsprakenMainViewModel()
        {
            AfspraakLijst = new AfsprakenLijstViewModel();
            AfspraakDetail = new AfsprakenDetailViewModel();

            AfspraakLijst.PropertyChanged += AfspraakLijst_PropertyChanged;
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
                case "GeselecteerdeAfspraak":
                    (AfspraakDetail as AfsprakenDetailViewModel).GeselecteerdeAfspraak = (AfspraakLijst as AfsprakenLijstViewModel).GeselecteerdeAfspraak;
                    break;
                default:
                    break;
            }
        }
    }
}
