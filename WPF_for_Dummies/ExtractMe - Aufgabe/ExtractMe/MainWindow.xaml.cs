﻿using System.Windows;

namespace ExtractMe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            FirstContentControl.Content = MyTextBox.Text;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MyUserControl.HeaderPresenter = null;
        }
    }
}
