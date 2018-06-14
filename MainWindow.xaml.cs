using KojangTalk.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
    }
}
