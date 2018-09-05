
using KojangTalk.Core;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KojangTalk
{
    public class DialogWindowViewModel : WindowViewModel
    {
         
        public string Title { get; set; }

      
        // DialogMessageBox 포함하는 부분
        public Control Content { get; set; }

      
        public DialogWindowViewModel(Window window) : base(window)
        {
         
            WindowMinimumWidth = 250;
            WindowMinimumHeight = 100;

            TitleHeight = 30;
        }

      
    }
}
