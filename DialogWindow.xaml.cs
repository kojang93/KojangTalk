
using System.Windows;

namespace KojangTalk
{
    public partial class DialogWindow : Window
    {
        //전체 어플리케이션을 관장하는 ApplicationViewModel을 생성한다. 

        private DialogWindowViewModel mViewModel;


        public DialogWindowViewModel ViewModel
        {
            get => mViewModel;
            set
            {

                mViewModel = value;

                DataContext = mViewModel;
            }
        }

        public DialogWindow()
        {
            InitializeComponent();
        }

    }
}
