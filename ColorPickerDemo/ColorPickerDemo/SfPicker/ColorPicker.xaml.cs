using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ColorPickerDemo.SfPicker
{
    #region Xamarin.Forms Picker as Color Picker

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ColorPicker : ContentView , INotifyPropertyChanged
	{
        #region Members

        private ObservableCollection<String> colors = new ObservableCollection<string>();
        private Color selectedColor;
        private Color headerTextColor;
        private string selectedItem;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructor
        public ColorPicker ()
		{
			InitializeComponent ();

            foreach (var color in typeof(Color).GetFields())
            {
                Colors.Add(color.Name);
            }
            this.BindingContext = this;
        }

        #endregion

        #region Properties

        public ObservableCollection<String> Colors
        {
            get
            {
                return colors;
            }
            set
            {
                colors = value;
                OnPropertyChanged("Colors");
            }
        }

        public Color SelectedColor
        {
            get
            {
                if(SelectedItem!= null)
                      return (Color) typeof(Color).GetField(SelectedItem).GetValue(this);
                return Color.Transparent;
            }
            internal set
            {
                selectedColor = value;
            }
        }

        public Color HeaderTextColor
        {
            get
            {
                headerTextColor = Color.FromRgb(-(SelectedColor.R-1), -(SelectedColor.G-1), -(SelectedColor.B-1));
                return headerTextColor;
            }
            internal set
            {
                headerTextColor = value;
            }
        }

        public string SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
                OnPropertyChanged("SelectedColor");
                OnPropertyChanged("HeaderTextColor");
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

    }

    #endregion
}