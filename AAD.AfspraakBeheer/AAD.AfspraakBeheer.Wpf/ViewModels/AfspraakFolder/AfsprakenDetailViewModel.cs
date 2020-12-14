using AAD.AfspraakBeheer.Common;
using AAD.AfspraakBeheer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace AAD.AfspraakBeheer.Wpf.ViewModels.AfspraakFolder
{
    public class AfsprakenDetailViewModel : AfspraakBeheerBaseViewModel
    {
        #region Fields & Properties

        private Afspraak _geselecteerdeAfspraak;
        private Boolean _asfpraakGewijzigd;
        private Boolean _afspraakVerwijderen;
        private RelayCommand _bewaarCommand;
        private RelayCommand _verwijderCommand;

        public Afspraak GeselecteerdeAfspraak
        {
            get { return _geselecteerdeAfspraak; }
            set
            {
                SetProperty(ref _geselecteerdeAfspraak, value);
                GeselecteerdeAfspraak.PropertyChanged += GeselecteerdeAfspraak_PropertyChanged;
                AfspraakGewijzigd = false;
                if (value != null)
                {
                    GeselecteerdeAfspraak.PropertyChanged += GeselecteerdeAfspraak_PropertyChanged;
                    AfspraakVerwijderen = true;
                }

            }
        }
        private FullObservableCollection<Afspraak> _afspraken;
        public FullObservableCollection<Afspraak> Afspraken
        {
            get { return _afspraken; }
            set
            {
                SetProperty(ref _afspraken, value);
            }
        }
        public Boolean AfspraakGewijzigd
        {
            get { return _asfpraakGewijzigd; }
            set
            {
                SetProperty(ref _asfpraakGewijzigd, value);
            }
        }
        public Boolean AfspraakVerwijderen
        {
            get { return _afspraakVerwijderen; }
            set
            {
                SetProperty(ref _afspraakVerwijderen, value);
            }
        }

        private void GeselecteerdeAfspraak_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            AfspraakGewijzigd = true;
            AfspraakVerwijderen = true;

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

        public AfsprakenDetailViewModel()
        {
            BewaarCommand = new RelayCommand(BewaarAfspraak, MagAfspraakBewaren);
            VerwijderCommand = new RelayCommand(VerwijderAfspraak, MagPersoonVerwijderen);
            Titel = "Details";
            Afspraken = Repository.GetAfspraken();
        }
        #endregion

        #region Methods

        private void BewaarAfspraak(object parameter = null)
        {
            try
            {
                Repository.UpdateAfspraak(GeselecteerdeAfspraak);
                MsgBox.Show($"Afspraak ({GeselecteerdeAfspraak.AfspraakId}) met succes geüpdatet");
                AfspraakGewijzigd = false;

            }
            catch (Exception)
            {
                MsgBox.Show($"Afspraak ({GeselecteerdeAfspraak.AfspraakId}) kan niet geüpdatet worden.");
                return;
            }

        }

        private Boolean MagAfspraakBewaren(object parameter = null)
        {
            return AfspraakGewijzigd;
        }

        private void VerwijderAfspraak(object obj)
        {
            try
            {
                DialogResult result = MsgBox.Show($"Ben je zeker dat je de Afspraak ({GeselecteerdeAfspraak.AfspraakId}) wil verwijderen.", "Confirmatie", MsgBox.Buttons.YesNo, MsgBox.Icon.Question, MsgBox.AnimateStyle.FadeIn);
                if (result != DialogResult.Yes) return;
                Repository.RemoveAfspraak(GeselecteerdeAfspraak);
                MsgBox.Show($"Afspraak ({GeselecteerdeAfspraak.AfspraakId}) succesvol verwijderd.");
                AfspraakVerwijderen = false;
            }
            catch (Exception)
            {
                MsgBox.Show($"Afspraak ({GeselecteerdeAfspraak.AfspraakId}) kan niet verwijderd worden.");
                return;
            }
        }

        private Boolean MagPersoonVerwijderen(object parameter = null)
        {
            return AfspraakVerwijderen;
        }
        #endregion

    }
}
