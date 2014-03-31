using System.Collections;
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
        private bool _showFooter;
        private object _footer;
        private bool _showHeader;
        private object _header;

        public event PropertyChangedEventHandler PropertyChanged;

        public IEnumerable Liste { get; set; }

        public object Header
        {
            get { return _header; }
            set
            {
                if (_header == value) return;
                _header = value;
                OnPropertyChanged();
            }
        }

        public bool ShowHeader
        {
            get { return _showHeader; }
            set
            {
                if (_showHeader == value) return;
                _showHeader = value;
                OnPropertyChanged();
            }
        }

        public object Footer
        {
            get { return _footer; }
            set
            {
                if (_footer == value) return;
                _footer = value;
                OnPropertyChanged();
            }
        }

        public bool ShowFooter
        {
            get { return _showFooter; }
            set
            {
                if (_showFooter == value) return;
                _showFooter = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
