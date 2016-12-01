using Simple3TierWCF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Simple3TierWPF
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        ObservableCollection<string> _messages = new ObservableCollection<string>();

        public ObservableCollection<string> Messages
        {
            get { return _messages; }
            set
            {
                _messages = value;
                NotifyPropertyChanged();
            }
        }

        bool _isStarted = false;

        public bool IsStarted
        {
            get { return _isStarted; }
            set { _isStarted = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(NotIsStarted));
            }
        }

        public bool NotIsStarted { get { return !IsStarted; } }

        Simple3TierWCFClient client;

        public MainWindowViewModel()
        {
            client = Simple3TierWCFClient.Create();
        }

        Timer timer;

        public void Start()
        {
            Messages.Add("Started");

            timer = new Timer(Timer_Elapsed, SynchronizationContext.Current, 5, 3000);
            IsStarted = true;
        }

        public void Stop()
        {
            timer.Dispose();
            timer = null;
            IsStarted = false;
        }

        private async void Timer_Elapsed(object state)
        {

            var sc = (DispatcherSynchronizationContext)state;

            try
            {
                var r = await client.GetData();
                sc.Post((o) => { Messages.Insert(0, r); }, null);
            }
            catch (Exception ex)
            {
                sc.Post((o) => { Messages.Insert(0, $"Error: {ex.Message}"); }, null);
            }

    
        }
    }
}
