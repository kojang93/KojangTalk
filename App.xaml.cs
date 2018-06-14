using KojangTalk.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KojangTalk
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            
            base.OnStartup(e);
            Console.WriteLine("OnStartup");
            IoC.Setup();

            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();

        }
      
        
    }
}
