using AAD.AfspraakBeheer.Common;
using AAD.AfspraakBeheer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace AAD.AfspraakBeheer.Wpf.ViewModels.PersonenAfsprakenFolder
{
    public class PersoonDetailViewModel : AfspraakBeheerBaseViewModel
    {
        #region Fields & Properties
        private Persoon _geselecteerdePersoon;
        private Boolean _persoonGewijzigd;
        private Boolean _persoonVerwijderen;
        private RelayCommand _bewaarCommand;
        private RelayCommand _verwijderCommand;

        public Persoon GeselecteerdePersoon
        {
            get { return _geselecteerdePersoon; }
            set
            {
                SetProperty(ref _geselecteerdePersoon, value);
                GeselecteerdePersoon.PropertyChanged += GeselecteerdePersoon_PropertyChanged;
                PersoonGewijzigd = false;
                if (value != null)
                {
                    GeselecteerdePersoon.PropertyChanged += GeselecteerdePersoon_PropertyChanged;
                    PersoonVerwijderen = true;
                }

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

        private void GeselecteerdePersoon_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
                PersoonGewijzigd = true;
                PersoonVerwijderen = true;

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

        public PersoonDetailViewModel()
        {
            BewaarCommand = new RelayCommand(BewaarPersoon, MagPersoonBewaren);
            VerwijderCommand = new RelayCommand(VerwijderPersoon, MagPersoonVerwijderen);
            Titel = "Details";
        }
        #endregion


        #region Methods


        private void BewaarPersoon(object parameter = null)
        {
            try
            {
                Repository.UpdatePersoon(GeselecteerdePersoon);
                MsgBox.Show($"Persoon ({GeselecteerdePersoon.Id}) met succes geüpdatet");
                PersoonGewijzigd = false;

            }
            catch (Exception)
            {
                MsgBox.Show($"Persoon ({GeselecteerdePersoon.Id}) kan niet geüpdatet worden.");
                return;
            }

        }

        private Boolean MagPersoonBewaren(object parameter = null)
        {
                return PersoonGewijzigd;
        }

        private void VerwijderPersoon(object obj)
        {
            try
            {
                DialogResult result = MsgBox.Show($"Ben je zeker dat je de persoon ({GeselecteerdePersoon.Id}) wil verwijderen, als je op ja druk zullen al zijn afspraken verwijdert zijn.", "Confirmatie", MsgBox.Buttons.YesNo, MsgBox.Icon.Question, MsgBox.AnimateStyle.FadeIn);
                if (result != DialogResult.Yes) return;
                Repository.RemovePersoon(GeselecteerdePersoon);
                MsgBox.Show($"Persoon ({GeselecteerdePersoon.Id}) met succes verwijderd");
                PersoonVerwijderen = false;
            }
            catch (Exception)
            {
                MsgBox.Show($"Persoon ({GeselecteerdePersoon.Id}) kan niet verwijderd worden");
                return;
            }
        }

        private Boolean MagPersoonVerwijderen(object parameter = null)
        {
            return PersoonVerwijderen;
        }
        #endregion
    }
}