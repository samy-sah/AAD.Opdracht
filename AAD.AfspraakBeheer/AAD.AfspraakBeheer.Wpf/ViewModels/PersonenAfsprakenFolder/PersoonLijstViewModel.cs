using AAD.AfspraakBeheer.Common;
using AAD.AfspraakBeheer.Data;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace AAD.AfspraakBeheer.Wpf.ViewModels.PersonenAfsprakenFolder
{
    public class PersoonLijstViewModel : AfspraakBeheerBaseViewModel
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        #region Fields & Properties

        private ICollectionView _phrasesView;
        private string filter;
        private Persoon _geselecteerdePersoon;
        private FullObservableCollection<Afspraak> _afspraken;
        private FullObservableCollection<Persoon> _personen;
        private RelayCommand _saveCommand;

        public FullObservableCollection<Persoon> Personen
        {
            get { return _personen; }
            set
            {
                SetProperty(ref _personen, value);
            }
        }
        public FullObservableCollection<Afspraak> Afspraken
        {
            get { return _afspraken; }
            set
            {
                SetProperty(ref _afspraken, value);
            }
        }

        public Persoon GeselecteerdePersoon
        {
            get { return _geselecteerdePersoon; }
            set
            {
                SetProperty(ref _geselecteerdePersoon, value);
            }
        }

        public RelayCommand SaveCommand
        {
            get { return _saveCommand; }
            set
            {
                SetProperty(ref _saveCommand, value);
                OnPropertyChanged("SaveCommand");
            }
        }

        #endregion

        #region Constructors

        public PersoonLijstViewModel()
        {
            Personen = Repository.GetPersonen();
            Afspraken = Repository.GetAfspraken();
            Titel = "Personen detail";
            PhrasesView = CollectionViewSource.GetDefaultView(Afspraken);
            PhrasesView.Filter = new Predicate<object>(o => GebruikFilter(o as Afspraak));
            SaveCommand = new RelayCommand(ExecuteSaveFileDialog);

        }

        #endregion


        #region Methods

        public ICollectionView PhrasesView
        {
            get { return _phrasesView; }
            set
            {
                SetProperty(ref _phrasesView, value);
            }
        }

        public string Filter
        {
            get
            {
                return filter;
            }
            set
            {
                filter = value;
                OnPropertyChanged("Filter");
                PhrasesView.Refresh();
            }
        }
        private bool GebruikFilter(Afspraak afspraak)
        {
            if (String.IsNullOrEmpty(Filter))
                return true;
            else
                return (afspraak.Agenda.Naam.IndexOf(Filter, StringComparison.OrdinalIgnoreCase) >= 0) 
                    || (afspraak.Eigenaar.Naam.IndexOf(Filter, StringComparison.OrdinalIgnoreCase) >= 0) 
                    || (afspraak.AfspraakSoorten.Naam.IndexOf(Filter, StringComparison.OrdinalIgnoreCase) >= 0)
                    || (afspraak.Titel.IndexOf(Filter, StringComparison.OrdinalIgnoreCase) >= 0);

        }
        private void ExecuteSaveFileDialog(object parameter)
        {
            try
            {

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.InitialDirectory = folderPath;
                dialog.Filter = "ExcelBestanden|*.CSV;";
                dialog.FileName = "Afspraken.csv";
                if (dialog.ShowDialog() == true)
                {
                    using (StreamWriter writer = File.CreateText(dialog.FileName))
                    {
                        foreach (Persoon persoon in Personen)
                        {
                            writer.WriteLine(persoon);
                        }
                        foreach (Afspraak afspraak in Afspraken)
                        {
                            writer.WriteLine(afspraak);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
            }
        }
        #endregion
    }
}