using System;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using BerlinClock.WebApi;

namespace BerlinClock.Client
{
    public sealed class MainWindowDataContext : IDisposable, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private readonly DispatcherTimer _uiUpdateShortcutTimer;
        private readonly TimeProvider _timeProvider;
        private readonly HttpClient _httpClient;
        public MainWindowDataContext()
        {
            _url = string.Empty;
            _fillRow0Circle = Brushes.Magenta;
            _fillRow1Rect0  = Brushes.Magenta;
            _fillRow1Rect1  = Brushes.Magenta;
            _fillRow1Rect2  = Brushes.Magenta;
            _fillRow1Rect3  = Brushes.Magenta;
            _fillRow2Rect0  = Brushes.Magenta;
            _fillRow2Rect1  = Brushes.Magenta;
            _fillRow2Rect2  = Brushes.Magenta;
            _fillRow2Rect3  = Brushes.Magenta;
            _fillRow3Rect0  = Brushes.Magenta;
            _fillRow3Rect1  = Brushes.Magenta;
            _fillRow3Rect2  = Brushes.Magenta;
            _fillRow3Rect3  = Brushes.Magenta;
            _fillRow3Rect4  = Brushes.Magenta;
            _fillRow3Rect5  = Brushes.Magenta;
            _fillRow3Rect6  = Brushes.Magenta;
            _fillRow3Rect7  = Brushes.Magenta;
            _fillRow3Rect8  = Brushes.Magenta;
            _fillRow3Rect9  = Brushes.Magenta;
            _fillRow3Rect10 = Brushes.Magenta;
            _fillRow4Rect0  = Brushes.Magenta;
            _fillRow4Rect1  = Brushes.Magenta;
            _fillRow4Rect2  = Brushes.Magenta;
            _fillRow4Rect3  = Brushes.Magenta;
            _httpClient = new HttpClient();
            _uiUpdateShortcutTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(100)
            };
            _uiUpdateShortcutTimer.Tick += UiUpdateShortcutTimerOnTick;
            _uiUpdateShortcutTimer.Start();
            _timeProvider = new TimeProvider();
        }

        private void UiUpdateShortcutTimerOnTick(object? sender, EventArgs e)
        {
            if (sender is not DispatcherTimer)
                throw new ArgumentException("sender is not DispatcherTimer", nameof(sender));
            Task.Run(UpdateDataAsync);
        }

        private async Task UpdateDataAsync()
        {
            if (!string.IsNullOrWhiteSpace(Url))
            {
                var berlinClockTime = await _timeProvider.GetBerlinClockTimeAsync(Url, _httpClient);
                await Application.Current.Dispatcher.InvokeAsync(() => BerlinClockTime = berlinClockTime);
            }
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        private BerlinClockTime BerlinClockTime
        {
            set
            {
                UrlOk = true;
                FillRow0Circle = DateTime.Now.Second % 2 == 0
                    ? Brushes.White
                    : Brushes.Red;
                FillRow1Rect0  = value.HourFive > 0    ? Brushes.Red    : Brushes.White;
                FillRow1Rect1  = value.HourFive > 1    ? Brushes.Red    : Brushes.White;
                FillRow1Rect2  = value.HourFive > 2    ? Brushes.Red    : Brushes.White;
                FillRow1Rect3  = value.HourFive > 3    ? Brushes.Red    : Brushes.White;
                FillRow2Rect0  = value.HourOne > 0     ? Brushes.Red    : Brushes.White;
                FillRow2Rect1  = value.HourOne > 1     ? Brushes.Red    : Brushes.White;
                FillRow2Rect2  = value.HourOne > 2     ? Brushes.Red    : Brushes.White;
                FillRow2Rect3  = value.HourOne > 3     ? Brushes.Red    : Brushes.White;
                FillRow3Rect0  = value.MinuteFive > 0  ? Brushes.Yellow : Brushes.White;
                FillRow3Rect1  = value.MinuteFive > 1  ? Brushes.Yellow : Brushes.White;
                FillRow3Rect2  = value.MinuteFive > 2  ? Brushes.Red    : Brushes.White;
                FillRow3Rect3  = value.MinuteFive > 3  ? Brushes.Yellow : Brushes.White;
                FillRow3Rect4  = value.MinuteFive > 4  ? Brushes.Yellow : Brushes.White;
                FillRow3Rect5  = value.MinuteFive > 5  ? Brushes.Red    : Brushes.White;
                FillRow3Rect6  = value.MinuteFive > 6  ? Brushes.Yellow : Brushes.White;
                FillRow3Rect7  = value.MinuteFive > 7  ? Brushes.Yellow : Brushes.White;
                FillRow3Rect8  = value.MinuteFive > 8  ? Brushes.Red    : Brushes.White;
                FillRow3Rect9  = value.MinuteFive > 9  ? Brushes.Yellow : Brushes.White;
                FillRow3Rect10 = value.MinuteFive > 10 ? Brushes.Yellow : Brushes.White;
                FillRow4Rect0  = value.MinuteOne > 0   ? Brushes.Yellow : Brushes.White;
                FillRow4Rect1  = value.MinuteOne > 1   ? Brushes.Yellow : Brushes.White;
                FillRow4Rect2  = value.MinuteOne > 2   ? Brushes.Yellow : Brushes.White;
                FillRow4Rect3  = value.MinuteOne > 3   ? Brushes.Yellow : Brushes.White;
            }
        }


        #region public string Url { get; private set; }

        public string Url
        {
            get => _url;
            set
            {
                _url = value;
                OnPropertyChanged();
                Task.Run(UpdateDataAsync);
            }
        }

        private string _url;
        
        #endregion
        #region public bool UrlOk { get; private set; }

        public bool UrlOk
        {
            get => _urlOk;
            set
            {
                _urlOk = value;
                OnPropertyChanged();
            }
        }

        private bool _urlOk;
        
        #endregion
        #region public Brush FillRow0Circle { get; private set; }

        public Brush FillRow0Circle
        {
            get => _fillRow0Circle;
            private set
            {
                _fillRow0Circle = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow0Circle;
        
        #endregion
        #region public Brush FillRow1Rect0 { get; private set; }

        public Brush FillRow1Rect0
        {
            get => _fillRow1Rect0;
            private set
            {
                _fillRow1Rect0 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow1Rect0;
        
        #endregion
        #region public Brush FillRow1Rect1 { get; private set; }

        public Brush FillRow1Rect1
        {
            get => _fillRow1Rect1;
            private set
            {
                _fillRow1Rect1 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow1Rect1;
        
        #endregion
        #region public Brush FillRow1Rect2 { get; private set; }

        public Brush FillRow1Rect2
        {
            get => _fillRow1Rect2;
            private set
            {
                _fillRow1Rect2 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow1Rect2;
        
        #endregion
        #region public Brush FillRow1Rect3 { get; private set; }

        public Brush FillRow1Rect3
        {
            get => _fillRow1Rect3;
            private set
            {
                _fillRow1Rect3 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow1Rect3;
        
        #endregion
        #region public Brush FillRow2Rect0 { get; private set; }

        public Brush FillRow2Rect0
        {
            get => _fillRow2Rect0;
            private set
            {
                _fillRow2Rect0 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow2Rect0;
        
        #endregion
        #region public Brush FillRow2Rect1 { get; private set; }

        public Brush FillRow2Rect1
        {
            get => _fillRow2Rect1;
            private set
            {
                _fillRow2Rect1 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow2Rect1;
        
        #endregion
        #region public Brush FillRow2Rect2 { get; private set; }

        public Brush FillRow2Rect2
        {
            get => _fillRow2Rect2;
            private set
            {
                _fillRow2Rect2 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow2Rect2;
        
        #endregion
        #region public Brush FillRow2Rect3 { get; private set; }

        public Brush FillRow2Rect3
        {
            get => _fillRow2Rect3;
            private set
            {
                _fillRow2Rect3 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow2Rect3;
        
        #endregion
        #region public Brush FillRow3Rect0 { get; private set; }

        public Brush FillRow3Rect0
        {
            get => _fillRow3Rect0;
            private set
            {
                _fillRow3Rect0 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow3Rect0;
        
        #endregion
        #region public Brush FillRow3Rect1 { get; private set; }

        public Brush FillRow3Rect1
        {
            get => _fillRow3Rect1;
            private set
            {
                _fillRow3Rect1 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow3Rect1;
        
        #endregion
        #region public Brush FillRow3Rect2 { get; private set; }

        public Brush FillRow3Rect2
        {
            get => _fillRow3Rect2;
            private set
            {
                _fillRow3Rect2 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow3Rect2;
        
        #endregion
        #region public Brush FillRow3Rect3 { get; private set; }

        public Brush FillRow3Rect3
        {
            get => _fillRow3Rect3;
            private set
            {
                _fillRow3Rect3 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow3Rect3;
        
        #endregion
        #region public Brush FillRow3Rect4 { get; private set; }

        public Brush FillRow3Rect4
        {
            get => _fillRow3Rect4;
            private set
            {
                _fillRow3Rect4 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow3Rect4;
        
        #endregion
        #region public Brush FillRow3Rect5 { get; private set; }

        public Brush FillRow3Rect5
        {
            get => _fillRow3Rect5;
            private set
            {
                _fillRow3Rect5 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow3Rect5;
        
        #endregion
        #region public Brush FillRow3Rect6 { get; private set; }

        public Brush FillRow3Rect6
        {
            get => _fillRow3Rect6;
            private set
            {
                _fillRow3Rect6 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow3Rect6;
        
        #endregion
        #region public Brush FillRow3Rect7 { get; private set; }

        public Brush FillRow3Rect7
        {
            get => _fillRow3Rect7;
            private set
            {
                _fillRow3Rect7 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow3Rect7;
        
        #endregion
        #region public Brush FillRow3Rect8 { get; private set; }

        public Brush FillRow3Rect8
        {
            get => _fillRow3Rect8;
            private set
            {
                _fillRow3Rect8 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow3Rect8;
        
        #endregion
        #region public Brush FillRow3Rect9 { get; private set; }

        public Brush FillRow3Rect9
        {
            get => _fillRow3Rect9;
            private set
            {
                _fillRow3Rect9 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow3Rect9;
        
        #endregion
        #region public Brush FillRow3Rect10 { get; private set; }

        public Brush FillRow3Rect10
        {
            get => _fillRow3Rect10;
            private set
            {
                _fillRow3Rect10 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow3Rect10;
        
        #endregion
        #region public Brush FillRow4Rect0 { get; private set; }

        public Brush FillRow4Rect0
        {
            get => _fillRow4Rect0;
            private set
            {
                _fillRow4Rect0 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow4Rect0;
        
        #endregion
        #region public Brush FillRow4Rect1 { get; private set; }

        public Brush FillRow4Rect1
        {
            get => _fillRow4Rect1;
            private set
            {
                _fillRow4Rect1 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow4Rect1;
        
        #endregion
        #region public Brush FillRow4Rect2 { get; private set; }

        public Brush FillRow4Rect2
        {
            get => _fillRow4Rect2;
            private set
            {
                _fillRow4Rect2 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow4Rect2;
        
        #endregion
        #region public Brush FillRow4Rect3 { get; private set; }

        public Brush FillRow4Rect3
        {
            get => _fillRow4Rect3;
            private set
            {
                _fillRow4Rect3 = value;
                OnPropertyChanged();
            }
        }

        private Brush _fillRow4Rect3;
        
        #endregion
    }
}