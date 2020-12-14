using AAD.AfspraakBeheer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AAD.AfspraakBeheer.Data
{
	[Table("Afspraken")]
	public class Afspraak : ObservableObject, IDataErrorInfo
	{
		#region Fields & Properties

		private string _titel;
		private Persoon _eigenaar;
		private TimeSpan _startTijd;
		private TimeSpan _eindTijd;

		public int AfspraakId { get; set; }

		[Required]
		[MaxLength(30)]
		public string Titel
		{
			get { return _titel; }
			set
			{
				_titel = value;
				OnPropertyChanged("Titel");
			}
		}

		[Required(AllowEmptyStrings = false)]
		public Persoon Eigenaar
		{
			get { return _eigenaar; }
			set
			{
				SetProperty(ref _eigenaar, value);
			}
		}

		public Agenda Agenda { get; set; }
		public AfspraakSoort AfspraakSoorten { get; set; }


		[Required]
		public TimeSpan StartTijd
		{
			get { return _startTijd; }
			set
			{
				 _startTijd = value;
				OnPropertyChanged("StartTijd");

			}
		}

		[Required]
		public TimeSpan EindTijd
		{
			get { return _eindTijd; }
			set
			{
				_eindTijd = value;
				OnPropertyChanged("EindTijd");
			}
		}
		#endregion

		#region Constructors

		protected Afspraak()
		{ }
		public Afspraak(Agenda agenda, AfspraakSoort afspraakSoorten, String titel, Persoon eigenaar, TimeSpan starttijd, TimeSpan eindtijd)
			: this(0, agenda, afspraakSoorten, titel, eigenaar, starttijd, eindtijd)
		{ }

		internal Afspraak(int id, Agenda agenda, AfspraakSoort afspraakSoorten, String titel, Persoon eigenaar, TimeSpan starttijd, TimeSpan eindtijd)
		{
			AfspraakId = id;
			Agenda = agenda;
			AfspraakSoorten = afspraakSoorten;
			Titel = titel;
			Eigenaar = eigenaar;
			StartTijd = starttijd;
			EindTijd = eindtijd;
		}

		#endregion

		#region Methods
		public override string ToString()
		{
			return $"{Eigenaar.Naam.ToUpper()}: heeft een {AfspraakSoorten.Naam}({Agenda.Naam}) \n{AfspraakId}: {Titel} - {StartTijd} - {EindTijd}";
		}
		#endregion
		#region IDataErrorInfo Members

		private string _error;

		public string Error
		{
			get => _error;
			set
			{
				if (_error != value)
				{
					_error = value;
					OnPropertyChanged("Error");
				}
			}
		}

		public string this[string columnName] => OnValidate(columnName);

		private string OnValidate(string columnName)
		{
			string result = string.Empty;
			if (columnName == "Titel")
			{
				if (string.IsNullOrEmpty(Titel))
				{
					result = "Titel mag niet leeg zijn";
				}
				else if (Titel.Length > 30)
				{
					result = ("Naam mag max 30 karakters bevatten");
				}
			}
			if (columnName == "StartTijd")
			{
				if (!Regex.IsMatch(StartTijd.ToString(), @"^(2[0-3]|[01]?[0-9]):([0-5]?[0-9]):([0-5]?[0-9])$"))
				{
					result = ("Gelieve een juiste uur in te geven");
				}
			}
			if (columnName == "EindTijd")
			{
				if (!Regex.IsMatch(EindTijd.ToString(), @"^(2[0-3]|[01]?[0-9]):([0-5]?[0-9]):([0-5]?[0-9])$"))
				{
					result = ("Gelieve een juiste uur in te geven");
				}
			}
			if (result == null)
			{
				Error = null;
			}
			else
			{
				Error = "Error";
			}
			return result;
		}

#endregion
	}
}