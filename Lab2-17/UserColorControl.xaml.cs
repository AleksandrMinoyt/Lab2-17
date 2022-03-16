using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab2_17
{
    /// <summary>
    /// Interaction logic for UserColorControl.xaml
    /// </summary>
    public partial class UserColorControl : UserControl
    {
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register(
            nameof(Color),
            typeof(Color),
            typeof(UserColorControl),
            new FrameworkPropertyMetadata(
                Colors.Black,
                new PropertyChangedCallback(OnColorChanged)));

        public static readonly DependencyProperty RedProperty =
            DependencyProperty.Register(
            nameof(Red),
            typeof(byte),
            typeof(UserColorControl),
            new FrameworkPropertyMetadata(                
                new PropertyChangedCallback(OnColorRGBChanged)));

        public static readonly DependencyProperty GreenProperty =
            DependencyProperty.Register(
            nameof(Green),
            typeof(byte),
            typeof(UserColorControl),
            new FrameworkPropertyMetadata(
                new PropertyChangedCallback(OnColorRGBChanged)));

        public static readonly DependencyProperty BlueProperty =
            DependencyProperty.Register(
            nameof(Blue),
            typeof(byte),
            typeof(UserColorControl),
            new FrameworkPropertyMetadata(                
                new PropertyChangedCallback(OnColorRGBChanged)));

                
        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }
        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }
        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }

        private static void OnColorRGBChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            UserColorControl colorPicker = (UserColorControl)sender;
            Color color = colorPicker.Color;
            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;

            colorPicker.Color = color;
        }
      
        private static void OnColorChanged(DependencyObject sender,
      DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            UserColorControl colorpicker = (UserColorControl)sender;
            colorpicker.Red = newColor.R;
            colorpicker.Green = newColor.G;
            colorpicker.Blue = newColor.B;
        }


        public UserColorControl()
        {
            InitializeComponent();
        }


    }
}
