using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AAD.AfspraakBeheer.Common
{
	public class ObservableObject : INotifyPropertyChanged
	{

		private Boolean _isModified;

		public Boolean IsModified
		{
			get { return _isModified; }
			set { _isModified = value; }
		}

		public void SetProperty<T>(ref T field, T value, [CallerMemberName] String propertyName = null)
		{
			if (!Object.Equals(field, value))
			{
				field = value;
				OnPropertyChanged(propertyName);
				IsModified = true;
			}
		}

		protected void OnPropertyChanged(String propertyName)
		{
			OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}

		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			PropertyChanged?.Invoke(this, e);
		}

		public event PropertyChangedEventHandler PropertyChanged;

	}
}
