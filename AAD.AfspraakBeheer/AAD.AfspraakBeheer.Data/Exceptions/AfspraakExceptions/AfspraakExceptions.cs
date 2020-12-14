using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.AfspraakBeheer.Data.Exceptions.AfspraakExceptions
{
	public class AfspraakExceptions : Exception
	{
		public AfspraakExceptions(String message) : base(message)
		{ }
	}
	public class AfspraakTitelException : AfspraakExceptions
	{
		public AfspraakTitelException() : base("Titel mag niet leeg zijn.")
		{
		}
	}
	public class AfspraakStartTijdException : AfspraakExceptions
	{
		public AfspraakStartTijdException() : base("Start tijd moet groter zijn dan 0.")
		{
		}
	}
	public class AfspraakEindTijdException : AfspraakExceptions
	{
		public AfspraakEindTijdException() : base("Eind tijd moet groter zijn dan 0.")
		{
		}
	}
}
