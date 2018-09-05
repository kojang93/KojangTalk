
using KojangTalk.Core;
using System.Windows.Controls;

namespace KojangTalk
{
    /// <summary>
    /// SettingsControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();
            //어플리케이션 전체 생명주기 동안 존재해야 하기때문에 
            DataContext = IoC.Settings;
        }
    }
}
