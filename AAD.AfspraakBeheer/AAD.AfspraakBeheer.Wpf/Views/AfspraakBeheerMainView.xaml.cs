using AAD.AfspraakBeheer.Common;
using AAD.AfspraakBeheer.Data;
using AAD.AfspraakBeheer.Wpf.ViewModels;
using AAD.AfspraakBeheer.Wpf.Views.PersonenAfsprakenFolder;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AAD.AfspraakBeheer.Wpf.Views
{
    /// <summary>
    /// Interaction logic for AfspraakBeheerMainView.xaml
    /// </summary>
    public partial class AfspraakBeheerMainView : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
		public int Test { get; set; }
        public bool Restart { get; set; }

        public AfspraakBeheerMainView()
		{
			InitializeComponent();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += Timer_Tick;
			timer.Start();
			Test = 15;

            //var result = MsgBox.Show("Wil je de databank HERSTARTEN, Zo ja druk op ja anders druk op nee", "Confirmatie", MsgBox.Buttons.YesNo, MsgBox.Icon.Question, MsgBox.AnimateStyle.FadeIn);

            //if (Restart = result == System.Windows.Forms.DialogResult.Yes)
            //{

            //    new AfspraakBeheerContext(Restart);
            //}
            //else
            //{

            //    new AfspraakBeheerContext(Restart);
            //}
        }


        private void Timer_Tick(object sender, EventArgs e)
		{
			Time.Text = DateTime.Now.ToString();
		}
    }
}

//var result = MsgBox.Show("Are you sure you want to close the Application ?", "Confirmation", MsgBox.Buttons.YesNo, MsgBox.Icon.Question, MsgBox.AnimateStyle.FadeIn);

//            if (Restart = result == System.Windows.Forms.DialogResult.Yes)
//            {

//                new AfspraakBeheerContext(Restart);
//            }
//            else
//            {

//                new AfspraakBeheerContext(Restart);
//            }

    
            //if (Restart = MessageBox.Show("Herstart", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //{

            //    new AfspraakBeheerContext(Restart);
            //}
            //else
            //{

            //    new AfspraakBeheerContext(Restart);
            //}