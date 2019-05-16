using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.XForms.Border;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ColorPickerDemo.SfSementedControl
{
    #region Xamarin.Forms Segmented Control as Color Picker

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ColorPicker : ContentView, INotifyPropertyChanged
    {
        #region Members

        private int selectedIndex = 0;
        private Color selectedColor;
        private ObservableCollection<object> viewCollection;
        List<Color> primaryColors = new List<Color>();
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region properties

        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
                OnPropertyChanged("SelectedIndex");
                OnPropertyChanged("SelectedColor");
            }
        }

        public Color SelectedColor
        {
            get
            {
                return primaryColors[selectedIndex];
            }
            set
            {
                selectedColor = value;
                OnPropertyChanged("SelectedIndex");
            }
        }

        public ObservableCollection<object> ViewCollection
        {
            get
            {
                return viewCollection;
            }
            set
            {
                viewCollection = value;
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

            ViewCollection = new ObservableCollection<object>();
            primaryColors.Add(Color.Violet);
            primaryColors.Add(Color.Indigo);
            primaryColors.Add(Color.Blue);
            primaryColors.Add(Color.Green);
            primaryColors.Add(Color.Yellow);
            primaryColors.Add(Color.Orange);
            primaryColors.Add(Color.Red);

            foreach (Color color in primaryColors)
            {
                Grid grid = new Grid();
                SfBorder border = new SfBorder
                {
                    Margin = new Thickness(2),
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    CornerRadius = 20,
                    BorderWidth = 0,
                    WidthRequest=40,
                    HeightRequest=40,
                    BackgroundColor = color
                };
                grid.Children.Add(border);
                ViewCollection.Add(grid);
            }

            this.BindingContext = this;
        }

        #endregion

    }

    #endregion
}