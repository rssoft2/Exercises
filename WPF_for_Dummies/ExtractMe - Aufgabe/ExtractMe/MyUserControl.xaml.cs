using System;
using System.Windows;
using System.Windows.Controls;

namespace ExtractMe
{
    /// <summary>
    /// Interaction logic for MyUserControl.xaml
    /// </summary>
    public partial class MyUserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
        }

        public object HeaderPresenter
        {
            get { return GetValue(HeaderPresenterProperty); }
            set { SetValue(HeaderPresenterProperty, value); }
        }

        public static readonly DependencyProperty HeaderPresenterProperty =
            DependencyProperty.Register("HeaderPresenter", typeof(object), typeof(MyUserControl), new PropertyMetadata(null, HeaderPresenterPropertyChangedCallback, CoerceValueCallback));

        private static object CoerceValueCallback(DependencyObject dependencyObject, object baseValue)
        {
            if (baseValue == null)
                return new TextBlock() { Text = "coerced value" };
            return baseValue;
        }

        public object FooterPresenter
        {
            get { return (object)GetValue(FooterPresenterProperty); }
            set { SetValue(FooterPresenterProperty, value); }
        }

        public static readonly DependencyProperty FooterPresenterProperty =
            DependencyProperty.Register("FooterPresenter", typeof(object), typeof(MyUserControl), new PropertyMetadata(null, FooterPresenterPropertyChangedCallback));

        private static void HeaderPresenterPropertyChangedCallback(DependencyObject obj, DependencyPropertyChangedEventArgs evtArgs)
        {
            ((MyUserControl)obj).HeaderControl.Visibility = (Visibility)Converter.Convert(evtArgs.NewValue != null, typeof(Visibility), null, null);
        }

        private static void FooterPresenterPropertyChangedCallback(DependencyObject obj, DependencyPropertyChangedEventArgs evtArgs)
        {
            ((MyUserControl)obj).FooterControl.Visibility = (Visibility)Converter.Convert(evtArgs.NewValue != null, typeof(Visibility), null, null);
        }

        private static readonly BooleanToVisibilityConverter Converter = new BooleanToVisibilityConverter();
    }
}
