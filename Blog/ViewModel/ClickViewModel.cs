using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModel
{
    partial class ClickViewModel
    {
        //private int _numClick;

        public int NumClick
        {
            get; set;
            //get { return _numClick; }
            //set
            //{
            //    if (_numClick != value)
            //    {
            //        _numClick = value;
            //        OnPropertyChanged();
            //    }
            //}
        }

        //[ObservableProperty]
        //public bool isOnLine = Connectivity.Current.NetworkAccess == NetworkAccess.Internet;

        //public bool IsOnLine
        //{
        //    get => isOnLine;
        //    set => SetProperty(ref isOnLine, value);
        //}

    }
}
