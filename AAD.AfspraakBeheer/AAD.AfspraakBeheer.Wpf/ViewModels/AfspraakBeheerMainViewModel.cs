using AAD.AfspraakBeheer.Common;
using AAD.AfspraakBeheer.Wpf.ViewModels.AfspraakFolder;
using AAD.AfspraakBeheer.Wpf.ViewModels.AfspraakSoortFolder;
using AAD.AfspraakBeheer.Wpf.ViewModels.PersonenAfsprakenFolder;
using AAD.AfspraakBeheer.Wpf.Views;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AAD.AfspraakBeheer.Wpf.ViewModels
{
    public class AfspraakBeheerMainViewModel : ObservableObject
    {
        #region Fields & Properties

        private RelayCommand _personenCommand;
        private RelayCommand _afsprakenCommand;
        private RelayCommand _afsprakenSoortCommand;
        private AfspraakBeheerBaseViewModel _geselecteerdeView;


        public RelayCommand PersonenCommand
        {
            get { return _personenCommand; }
            set
            {
                SetProperty(ref _personenCommand, value);
            }
        }
        public RelayCommand AfsprakenCommand
        {
            get { return _afsprakenCommand; }
            set
            {
                SetProperty(ref _afsprakenCommand, value);
            }
        }

        public RelayCommand AfsprakenSoortCommand
        {
            get { return _afsprakenSoortCommand; }
            set
            {
                SetProperty(ref _afsprakenSoortCommand, value);
            }
        }

        public AfspraakBeheerBaseViewModel GeselecteerdeView
        {
            get { return _geselecteerdeView; }
            set
            {
                SetProperty(ref _geselecteerdeView, value);
            }
        }
        #endregion

        #region Constructor(s)

        public AfspraakBeheerMainViewModel()
        {
            PersonenCommand = new RelayCommand(ToonPersonenView);
            HelpCommand = new DelegateCommand(ShowMethod);
            BeginCommand = new RelayCommand(OpenDept);
            AfsprakenSoortCommand = new RelayCommand(ToonAfsprakenSoortView);
            AfsprakenCommand = new RelayCommand(ToonAfsprakenView);
            GeselecteerdeView = new StartViewModel();
        }
        
        #endregion
        #region Methods

        private void ToonPersonenView(object parameter = null)
        {
            GeselecteerdeView = new PersonenMainViewModel();
        }

        private void ToonAfsprakenSoortView(object parameter = null)
        {
            GeselecteerdeView = new AfspraakSoortMainViewModel();
        }
        private void ToonAfsprakenView(object parameter = null)
        {
            GeselecteerdeView = new AfsprakenMainViewModel();
        }

        public ICommand HelpCommand
        {
            get;
            private set;
        }
        public ICommand BeginCommand { get; set; }
        private void OpenDept(object obj)
        {
            GeselecteerdeView = new StartViewModel();
        }
        public void ShowMethod()
        {
            HelpView help = new HelpView();
            help.Show();
        }
        #endregion
    }
}
