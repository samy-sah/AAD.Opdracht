using AAD.AfspraakBeheer.Business;
using AAD.AfspraakBeheer.Common;
using AAD.AfspraakBeheer.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AAD.AfspraakBeheer.Wpf.ViewModels
{
    public class AfspraakBeheerBaseViewModel : ObservableObject
    {

        #region Fields & Properties

        private IAfspraakBeheerRepository _repository;
        private String _titel;

        public IAfspraakBeheerRepository Repository
        {
            get { return _repository; }
            set
            {
                SetProperty(ref _repository, value);
            }
        }

        public String Titel
        {
            get { return _titel; }
            set
            {
                SetProperty(ref _titel, value);
            }
        }


        #endregion

        #region Constructors


        public AfspraakBeheerBaseViewModel()
        {
            Repository = new AfspraakBeheerRepositoryDisconnected();
            Titel = "Default titel";
        }
        #endregion
    }
}
