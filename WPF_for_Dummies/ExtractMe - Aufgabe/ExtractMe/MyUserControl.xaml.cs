using System.Windows;
using System.Windows.Controls;

namespace ExtractMe
{
    /// <summary>
    /// Interaction logic for MyUserControl.xaml
    /// </summary>
    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
        }

        public static BooleanToVisibilityConverter Converter = new BooleanToVisibilityConverter();

        public bool ShowHeaderXaml
        {
            get { return (bool)GetValue(ShowHeaderXamlProperty); }
            set { SetValue(ShowHeaderXamlProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowHeaderXAML.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowHeaderXamlProperty =
            DependencyProperty.Register("ShowHeaderXaml", typeof(bool), typeof(MyUserControl),
            new PropertyMetadata(true, (o, args) => ((MyUserControl)o).HeaderControl.Visibility = (System.Windows.Visibility)Converter.Convert(args.NewValue, typeof(Visibility), null, null)));


    }
}
