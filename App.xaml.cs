using KojangTalk.Core;
using System;

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
           

            ApplicationSetup();
           

            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();

        }

        private void ApplicationSetup()
        {
            IoC.Setup();
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());
        }
      
        
    }
}
