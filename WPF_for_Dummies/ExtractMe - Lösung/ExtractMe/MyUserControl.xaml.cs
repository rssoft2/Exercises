using System.Windows;
using System.Windows.Controls;

namespace ExtractMe
{
    /// <summary>
    /// Interaction logic for MyUserControl.xaml
    /// </summary>
    public partial class MyUserControl : UserControl
    {
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(object), typeof(MyUserControl), new PropertyMetadata(default(object), HeaderChangedCallback));

        public static readonly DependencyProperty FooterProperty =
            DependencyProperty.Register("Footer", typeof(object), typeof(MyUserControl), new PropertyMetadata(default(object), FooterChangedCallback));

        public static readonly DependencyProperty IsHeaderShownProperty =
            DependencyProperty.Register("IsHeaderShown", typeof(bool), typeof(MyUserControl), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty IsFooterShownProperty =
            DependencyProperty.Register("IsFooterShown", typeof(bool), typeof(MyUserControl), new PropertyMetadata(default(bool)));

        public MyUserControl()
        {
            InitializeComponent();
        }

        public bool IsHeaderShown
        {
            get { return (bool)GetValue(IsHeaderShownProperty); }
            set { SetValue(IsHeaderShownProperty, value); }
        }

        public bool IsFooterShown
        {
            get { return (bool)GetValue(IsFooterShownProperty); }
            set { SetValue(IsFooterShownProperty, value); }
        }

        public object Footer
        {
            get { return (object)GetValue(FooterProperty); }
            set { SetValue(FooterProperty, value); }
        }

        public object Header
        {
            get { return (object)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        private static void HeaderChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            var control = (MyUserControl)d;
            control.IsHeaderShown = control.Header != null;
        }

        private static void FooterChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            var control = (MyUserControl)d;
            control.IsFooterShown = control.Footer != null;
        }
    }
}
