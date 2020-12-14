using AAD.AfspraakBeheer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AAD.AfspraakBeheer.Data
{
	[Table("AfspraakSoorten")]

	public class AfspraakSoort : ObservableObject, IDataErrorInfo
	{
		#region Fields & Properties
		private string _naam;
		private string _omschrijving;
		private int _id;

		public int Id
		{
			get { return _id; }
			set
			{
				SetProperty(ref _id, value);
			}
		}

		public string Naam
		{
			get { return _naam; }
			set
			{
				SetProperty(ref _naam, value);
			}
		}

		public string Omschrijving
		{
			get { return _omschrijving; }
			set
			{
				SetProperty(ref _omschrijving, value);
			}
		}

		//public Persoon Eigenaar { get; set; }
		#endregion

		#region Constructors

		private AfspraakSoort()
		{ }

		public AfspraakSoort(String naam, String omschrijving)
			: this(0, naam, omschrijving)
		{ }

		internal AfspraakSoort(int id, String naam, String omschrijving)
		{
			Id = id;
			Naam = naam;
			Omschrijving = omschrijving;
			//Eigenaar = eigenaar;
		}

		#endregion

		#region Methods

		public override string ToString()
		{
			return $" \n{Id}: {Naam} - {Omschrijving}";
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
			if (columnName == "Naam")
			{
				if (string.IsNullOrEmpty(Naam))
				{
					result = "AfspraakSoort mag niet leeg zijn";
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
			if (columnName == "Omschrijving")
			{
				if (string.IsNullOrEmpty(Omschrijving))
				{
					result = "Omschrijving mag niet leeg zijn";
				}
				else if (Omschrijving.Length > 30)
				{
					result = ("Omschrijving mag max 30 karakters bevatten");
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
