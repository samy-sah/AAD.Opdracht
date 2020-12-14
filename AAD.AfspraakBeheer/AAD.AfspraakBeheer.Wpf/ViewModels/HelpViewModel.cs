using AAD.AfspraakBeheer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AAD.AfspraakBeheer.Wpf.ViewModels
{
    public class HelpViewModel : AfspraakBeheerBaseViewModel
    {
        #region Fields & Properties

        private RelayCommand _afsluitenCommand;

        public RelayCommand AfsluitenCommand
        {
            get { return _afsluitenCommand; }
            set
            {
                SetProperty(ref _afsluitenCommand, value);
            }
        }

        #endregion

        #region Constructor(s)
        public HelpViewModel()
        {
            Titel = "Sluit";
            AfsluitenCommand = new RelayCommand(AfsluitenExecute, AfsluitenCanExecute);

        }
        #endregion
        #region Methods

        private void AfsluitenExecute(object parameter)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private Boolean AfsluitenCanExecute(object parameter)
        {
            return true;
        }
        #endregion

    }
}
