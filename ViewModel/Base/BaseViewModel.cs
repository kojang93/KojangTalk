﻿
using System.ComponentModel;

namespace KojangTalk
{
   
    public class BaseViewModel : INotifyPropertyChanged
    {
      
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

     
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}