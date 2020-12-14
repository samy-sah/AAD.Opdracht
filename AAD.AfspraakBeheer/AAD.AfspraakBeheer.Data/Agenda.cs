using AAD.AfspraakBeheer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.AfspraakBeheer.Data
{
	[Table("Agenda's")]
    public class Agenda : ObservableObject
    {
		#region Fields & Properties

		private string _naam;
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
		public Persoon Eigenaar { get; set; }
		public AgendaSoort AgendaSoort { get; set; }

		#endregion

		#region Contructors
		protected Agenda()
		{ }

		public Agenda(AgendaSoort agendasoort, String naam, Persoon eigenaar)
			: this(0, agendasoort, naam, eigenaar)
		{}

		internal Agenda(int id, AgendaSoort agendasoort, String naam, Persoon eigenaar)
		{
			Id = id;
			Naam = naam;
			Eigenaar = eigenaar;
			AgendaSoort = agendasoort;
		}

		#endregion

		#region Methods

		public override string ToString()
		{
			return $"{Id} - {AgendaSoort} - {Naam} - {Eigenaar.Naam}";
		}
		#endregion
	}
}
