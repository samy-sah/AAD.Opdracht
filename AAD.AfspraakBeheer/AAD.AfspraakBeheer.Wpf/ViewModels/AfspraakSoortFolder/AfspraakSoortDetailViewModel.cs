using AAD.AfspraakBeheer.Common;
using AAD.AfspraakBeheer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace AAD.AfspraakBeheer.Wpf.ViewModels.AfspraakSoortFolder
{
    public class AfspraakSoortDetailViewModel : AfspraakBeheerBaseViewModel
    {
        #region Fields & Properties
        private AfspraakSoort _geselecteerdeAfspraakSoort;
        private Boolean _asfpraakSoortGewijzigd;
        private Boolean _afspraakSoortVerwijderen;
        private RelayCommand _verwijderCommand;
        private RelayCommand _bewaarCommand;


        public AfspraakSoort GeselecteerdeAfspraakSoort
        {
            get { return _geselecteerdeAfspraakSoort; }
            set
            {
                SetProperty(ref _geselecteerdeAfspraakSoort, value);
                GeselecteerdeAfspraakSoort.PropertyChanged += GeselecteerdeAfspraakSoort_PropertyChanged;
                AfspraakSoortGewijzigd = false;
                if (value != null)
                {
                    GeselecteerdeAfspraakSoort.PropertyChanged += GeselecteerdeAfspraakSoort_PropertyChanged;
                    AfspraakSoortVerwijderen = true;
                }

            }
        }
        public Boolean AfspraakSoortGewijzigd
        {
            get { return _asfpraakSoortGewijzigd; }
            set
            {
                SetProperty(ref _asfpraakSoortGewijzigd, value);
            }
        }

        public Boolean AfspraakSoortVerwijderen
        {
            get { return _afspraakSoortVerwijderen; }
            set
            {
                SetProperty(ref _afspraakSoortVerwijderen, value);
            }
        }

        private void GeselecteerdeAfspraakSoort_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            AfspraakSoortGewijzigd = true;
            AfspraakSoortVerwijderen = true;

        }

        public RelayCommand BewaarCommand
        {
            get { return _bewaarCommand; }
            set
            {
                SetProperty(ref _bewaarCommand, value);
            }
        }


        public RelayCommand VerwijderCommand
        {
            get { return _verwijderCommand; }
            set
            {
                SetProperty(ref _verwijderCommand, value);
            }
        }
        #endregion
        #region Constructors
        public AfspraakSoortDetailViewModel()
        {
            BewaarCommand = new RelayCommand(BewaarAfspraakSoort, MagAfspraakBewarenSoort);
            VerwijderCommand = new RelayCommand(VerwijderAfspraakSoort, MagPersoonVerwijderen);
            Titel = "Details";
        }
        #endregion

        #region Methods

        private void BewaarAfspraakSoort(object parameter = null)
        {
            try
            {
                Repository.UpdateAfspraakSoort(GeselecteerdeAfspraakSoort);
                MsgBox.Show($"AfspraakSoort ({GeselecteerdeAfspraakSoort.Id}) met succes geüpdatet");
                AfspraakSoortGewijzigd = false;

            }
            catch (Exception)
            {
                MsgBox.Show($"AfspraakSoort ({GeselecteerdeAfspraakSoort.Id}) kan niet geüpdatet worden");
                return;
            }

        }

        private Boolean MagAfspraakBewarenSoort(object parameter = null)
        {
            return AfspraakSoortGewijzigd;
        }

        private void VerwijderAfspraakSoort(object obj)
        {
            try
            {
                DialogResult result = MsgBox.Show($"Ben je zeker dat je deze ({GeselecteerdeAfspraakSoort.Id}) wil verwijderen", "Confirmatie", MsgBox.Buttons.YesNo, MsgBox.Icon.Question, MsgBox.AnimateStyle.FadeIn);
                if (result != DialogResult.Yes) return;
                Repository.RemoveAfspraakSoort(GeselecteerdeAfspraakSoort);
                MsgBox.Show($"AfspraakSoort ({GeselecteerdeAfspraakSoort.Id}) succesvol verwijderd.");
                AfspraakSoortVerwijderen = false;
            }
            catch (Exception)
            {
                MsgBox.Show($"AfspraakSoort ({GeselecteerdeAfspraakSoort.Id}) kan niet verwijderd worden.");
                return;
            }
        }
        private Boolean MagPersoonVerwijderen(object parameter = null)
        {
            return AfspraakSoortVerwijderen;
        }
        #endregion
    }
}
