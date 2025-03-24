using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eplan.MCNS.Lib
{
    public class BoolAct : INotifyPropertyChanged
    {
        private bool _boolState;

        public bool BoolState
        {
            get => _boolState;
            set
            {
                if (_boolState != value)
                {
                    _boolState = value;
                    OnPropertyChanged(nameof(BoolState));
                    OnBoolChanged?.Invoke(this, EventArgs.Empty); // 액션 호출
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler OnBoolChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
