
using System;

using System.Windows;


namespace KojangTalk
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        //전체 어플리케이션을 관장하는 ApplicationViewModel을 생성한다. 
      
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new WindowViewModel(this);
        }

        private void AppWindow_Activated(object sender, EventArgs e)
        {
            (DataContext as WindowViewModel).DimmableOverlayVisible = false;
        }

        private void Appwindow_Deactivated(object sender, EventArgs e)
        {
            (DataContext as WindowViewModel).DimmableOverlayVisible = true;
        }
    }
}
