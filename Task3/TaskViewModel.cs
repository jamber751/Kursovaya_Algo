using System.ComponentModel;

namespace Kursovaya
{
    public class TaskViewModel
    {
        private Queue<Zadacha> _taskQueue;

        public Queue<Zadacha> TaskQueue
        {
            get => _taskQueue;
            set
            {
                if (_taskQueue != value)
                {
                    _taskQueue = value;
                    OnPropertyChanged(nameof(TaskQueue));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

