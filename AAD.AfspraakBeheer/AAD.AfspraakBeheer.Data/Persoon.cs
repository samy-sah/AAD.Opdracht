using AAD.AfspraakBeheer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AAD.AfspraakBeheer.Data
{
	[Table("Personen")]
	public class Persoon : ObservableObject, IDataErrorInfo
	{
		#region Fields & Properties
		private string _naam;
		private DateTime _datum;
		private int _id;
		public int Id
		{
			get { return _id; }
			set
			{
				SetProperty(ref _id, value);
			}
		}
		[Required(AllowEmptyStrings = false)]
		[MinLength(6)]
		[MaxLength(30)]
		public string Naam
		{
			get { return _naam; }
			set
			{
				//if (String.IsNullOrEmpty(value))
				//	throw new NullReferenceException("Naam mag niet leeg zijn");
				_naam = value;
				OnPropertyChanged("Naam");
			}
		}

		[Required(AllowEmptyStrings = false)]
		public DateTime Datum
		{
			get { return _datum; }
			set
			{
				_datum = value;
				OnPropertyChanged("Datum");
			}
		}
		public List<Agenda> Agenda { get; set; }

		public List<AfspraakSoort> AfspraakSoort { get; set; }
		public List<Afspraak> AfsprakenTot { get; set; } = new List<Afspraak>();

		#endregion

		#region Constructors

		private Persoon()
		{ }

		public Persoon(String naam, DateTime datum)
			: this(0, naam, datum)
		{ }

		internal Persoon(int id, String naam, DateTime datum)
		{
			Id = id;
			Naam = naam;
			Datum = datum;
		}

		#endregion

		#region Methods

		public override string ToString()
		{
			return $"{Id}: {Naam} - {Datum.ToShortDateString()}  - #Afspraken: {AfsprakenTot.Count}";
		}

		#endregion

		#region IDataErrorInfo

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
			if (columnName == "Naam")
			{
				if (string.IsNullOrEmpty(Naam))
				{
					result = "Naam mag niet leeg zijn";
				}
				else if (Naam.Length < 6 || Naam.Length > 30)
				{
					result = ("Naam moet tussen 6-30 karakters bevatten");
				}
				else if (!Regex.IsMatch(Naam, @"^[a-zA-Z-\s]+$"))
				{
					result = "Naam mag enkel getallen bevatten!";
				}
			}
			if (columnName == "Datum")
			{
				if (!Regex.IsMatch(Datum.ToString(), @"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"))
				{
					result = ("Gelieve een juiste datum in te geven");
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
		//public Dictionary<string, List<string>> propErrors = new Dictionary<string, List<string>>();


		//public string Error { get { return null; } }

		//public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

		//public string this[string name]
		//{
		//	get
		//	{
		//		string result = null;

		//		switch (name)
		//		{
		//			case "Naam":
		//				if (string.IsNullOrWhiteSpace(Naam))
		//					result = "Naam mag niet leeg zijn";
		//				else if (Naam.Length < 6 || Naam.Length > 30)
		//					result = "Naam moet tussen 6-30 karakters bevatten";
		//				break;
		//			case "Datum":
		//				if (Datum == null)
		//					result = "datum mag niet leeg";
		//				break;

		//		}

		//		if (ErrorCollection.ContainsKey(name))
		//			ErrorCollection[name] = result;
		//		else if (result != null)
		//			ErrorCollection.Add(name, result);

		//		OnPropertyChanged("ErrorCollection");
		//		return result;
		//	}
		//}

		#endregion

	}
}
