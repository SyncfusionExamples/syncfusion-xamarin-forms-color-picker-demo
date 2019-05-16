using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ColorPickerDemo.SfRangeSlider
{

    #region Xamarin.Forms Range Slider as Color Picker

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ColorPicker : ContentView , INotifyPropertyChanged
	{
        #region Members

        private int rValue;
        private int bValue;
        private int gValue;
        private Color selectedColor;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructor

        public ColorPicker ()
		{
			InitializeComponent ();
            this.BindingContext = this;
		}

        #endregion

        #region Properties

        public int RValue
        {
            get
            {
                return rValue;
            }
            set
            {
                rValue = value;
                OnPropertyChanged("RValue");
                OnPropertyChanged("SelectedColor");
            }
        }

        public int BValue
        {
            get
            {
                return bValue;
            }
            set
            {
                bValue = value;
                OnPropertyChanged("BValue");
                OnPropertyChanged("SelectedColor");
            }
        }

        public int GValue
        {
            get
            {
                return gValue;
            }
            set
            {
                gValue = value;
                OnPropertyChanged("GValue");
                OnPropertyChanged("SelectedColor");
            }
        }

        public Color SelectedColor
        {
            get
            {
                return Color.FromRgb(RValue, GValue, BValue);
            }
            internal set
            {
                selectedColor = value;
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