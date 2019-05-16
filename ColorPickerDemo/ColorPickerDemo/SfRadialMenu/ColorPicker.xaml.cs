using Syncfusion.SfRadialMenu.XForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ColorPickerDemo.SfRadialMenu
{
    #region Xamarin.Forms Radial Menu for Color Picker

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ColorPicker : ContentView , INotifyPropertyChanged
	{
        #region Members

        private Color selectedColor;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Property

        public Color SelectedColor
        {
            get
            {
                return selectedColor;
            }
            internal set
            {
                selectedColor = value;
                OnPropertyChanged("SelectedColor");
            }
        }

        #endregion

        #region On Property Changed

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #endregion

        #region Constructor

        public ColorPicker ()
		{
			InitializeComponent ();
		}

        #endregion

        #region Event

        private void Handle_ItemTapped(object sender, Syncfusion.SfRadialMenu.XForms.ItemTappedEventArgs e)
        {
            SelectedColor = (sender as SfRadialMenuItem).BackgroundColor;
        }

        #endregion
    }

    #endregion
}