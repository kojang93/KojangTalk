using KojangTalk.Core;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KojangTalk
{


    //커스텀 다이얼 로그에 대한 Base 사용자 정의 컨트롤 
    /// <summary>
    //ViewModel 윈도우 에 대한 ViewModel이라고 할 수 있다. 
    /// </summary>
    public class BaseDialogUserControl : UserControl
    {
        #region Private Members

      
        private DialogWindow mDialogWindow;

        #endregion

        #region Public Commands

       
        public ICommand CloseCommand { get; private set; }

        #endregion

        #region Public Properties

      
        public int WindowMinimumWidth { get; set; } = 250;

      
        public int WindowMinimumHeight { get; set; } = 100;

     
        public int TitleHeight { get; set; } = 30;

       
        public string Title { get; set; }

        #endregion

        #region Constructor

      
        public BaseDialogUserControl()
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                //윈도우를 할당하고 
                mDialogWindow = new DialogWindow();
                mDialogWindow.ViewModel = new DialogWindowViewModel(mDialogWindow);

                //닫기 버튼을 눌렀을때 커맨드를 설정한다. 
                CloseCommand = new RelayCommand(() => mDialogWindow.Close());
            }
        }

        #endregion

        #region Public Dialog Show Methods


        //ShowDialog를 호출했을떄
        public Task ShowDialog<T>(T viewModel)
            where T : BaseDialogViewModel
        {
            
            var tcs = new TaskCompletionSource<bool>();

         
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
               
                    mDialogWindow.ViewModel.WindowMinimumWidth = WindowMinimumWidth;
                    mDialogWindow.ViewModel.WindowMinimumHeight = WindowMinimumHeight;
                    mDialogWindow.ViewModel.TitleHeight = TitleHeight;
                    mDialogWindow.ViewModel.Title = string.IsNullOrEmpty(viewModel.Title) ? Title : viewModel.Title;


                    //mDialogWindow.ViewModel.Content  = this를 함으로서 window에  DIalogMessageBox.xaml을 포함 하게 되고 그 Window를 ShowDialog() 할수 있는것 
                    mDialogWindow.ViewModel.Content = this;

                  
                    DataContext = viewModel;

                    // 커스텀 다이얼로그를 윈도우의 중앙에 위치하게 한다. 
                    mDialogWindow.Owner = Application.Current.MainWindow;
                    mDialogWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;



                    //직접 만든 Window를 나타내
                    //                //어쨌든 DialogWindow는 window를 상속받기 때문에 ShowDialog()를 호출 할 수 있다. 

                    mDialogWindow.ShowDialog();
                }
                finally
                {
              
                    tcs.TrySetResult(true);
                }
            });

            return tcs.Task;
        }

        #endregion
    }

    //    private DialogWindow mDialogWindow;

    //    public ICommand CloseCommand { get; private set; }

    //    public int WindowMinimumWidth { get; set; } = 250;

    //    public int WindowMinimumHeight { get; set; } = 100;


    //    public int TitleHeight { get; set; } = 30;


    //    public string Title { get; set; }


    //    // 기본 생성자 
    //    public BaseDialogUserControl()
    //    {
    //        if (!DesignerProperties.GetIsInDesignMode(this))
    //        {

    //          
    //            mDialogWindow = new DialogWindow();

    //            mDialogWindow.ViewModel = new DialogWindowViewModel(mDialogWindow);

    //           
    //            CloseCommand = new RelayCommand(() => mDialogWindow.Close());
    //        }
    //    }


    //   
    //    public Task ShowDialog<T>(T viewModel)
    //        where T : BaseDialogViewModel
    //    {

    //        var tcs = new TaskCompletionSource<bool>();


    //        Application.Current.Dispatcher.Invoke(() =>
    //        {
    //            try
    //            {

    //                mDialogWindow.ViewModel.WindowMinimumWidth = WindowMinimumWidth;
    //                mDialogWindow.ViewModel.WindowMinimumHeight = WindowMinimumHeight;
    //                mDialogWindow.ViewModel.TitleHeight = TitleHeight;
    //                mDialogWindow.ViewModel.Title = string.IsNullOrEmpty(viewModel.Title) ? Title : viewModel.Title;


    //                //////////////////////////


    //                //////////////////////////주의 
    //          
    //                mDialogWindow.ViewModel.Content = this;


    //                DataContext = viewModel;

    //             
    //                mDialogWindow.ShowDialog();
    //            }
    //            finally
    //            {

    //                tcs.TrySetResult(true);
    //            }
    //        });

    //        return tcs.Task;
    //    }


    //}


}

