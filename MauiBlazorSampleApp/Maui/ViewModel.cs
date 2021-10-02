using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiBlazorSampleApp
{
    public class ViewModel : INotifyPropertyChanged
    {
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string prop = null, params string[] otherProps)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(prop, otherProps);
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName] string prop = null, params string[] otherProps)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            if (otherProps != null && otherProps.Length > 0)
                foreach (var p in otherProps)
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class Command<T> : ICommand
    {
        private readonly Action<T> _action;
        private Func<T, Task> _actionAsync;

        public Command(Action<T> action)
        {
            _action = action;
        }

        public Command(Func<T, Task> actionAsync)
        {
            _actionAsync = actionAsync;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                _action?.Invoke((T)parameter);
                if (_actionAsync != null) await _actionAsync?.Invoke((T)parameter);
            }
            catch (Exception exc)
            {
                //exc.Dump();
            }
        }
    }
    public class Command : ICommand
    {
        private readonly Action _action;
        private Func<Task> _actionAsync;

        public Command(Action action)
        {
            _action = action;
        }

        public Command(Func<Task> actionAsync)
        {
            _actionAsync = actionAsync;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                _action?.Invoke();
                if (_actionAsync != null) await _actionAsync?.Invoke();
            }
            catch (Exception exc)
            {
                //exc.Dump();
            }
        }
    }
}