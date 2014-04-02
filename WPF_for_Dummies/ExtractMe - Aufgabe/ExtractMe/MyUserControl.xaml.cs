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

        public bool ShowHeaderXaml
        {
            get { return (bool)GetValue(ShowHeaderXamlProperty); }
            set { SetValue(ShowHeaderXamlProperty, value); }
        }

        // hier wird über den PropertyChangedCallback die Eigenschaft HeaderControl.Visibility gesetzt (kein xaml binding)
        public static readonly DependencyProperty ShowHeaderXamlProperty =
            DependencyProperty.Register("ShowHeaderXaml", typeof(bool), typeof(MyUserControl), new PropertyMetadata(true, ShowHeaderXamlPropertyChangedCallback()));

        public bool ShowFooterXaml
        {
            get { return (bool)GetValue(ShowFooterXamlProperty); }
            set { SetValue(ShowFooterXamlProperty, value); }
        }

        // hier wird die Eigenschaft HeaderControl.Visibility im xaml an die DependencyProperty ShowFooterXamlProperty gebunden
        public static readonly DependencyProperty ShowFooterXamlProperty =
            DependencyProperty.Register("ShowFooterXaml", typeof(bool), typeof(MyUserControl), new PropertyMetadata(true));

        private static PropertyChangedCallback ShowHeaderXamlPropertyChangedCallback()
        {
            return (o, args) => ((MyUserControl)o).HeaderControl.Visibility = (Visibility)Converter.Convert(args.NewValue, typeof(Visibility), null, null);
        }

        private static readonly BooleanToVisibilityConverter Converter = new BooleanToVisibilityConverter();
    }
}
