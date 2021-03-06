﻿using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExtractMe
{
    // Die Aufgabe lautet:
    // Statt ShowHeader und ShowFooter im ViewModel zu steuern, soll beides im XAML angegeben werden können.
    // Zwei Tipps können bei Bedarf nachgeschlagen werden.
    #region Tipp 1
    // Im UserControl MyUserControl müssen dafür zwei DependencyProperties angelegt werden
    #endregion
    #region Tipp 2
    // Die DependencyProperties müssen vom Typ ContentPresenter sein
    #endregion
    public sealed class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IEnumerable Liste { get; set; }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
