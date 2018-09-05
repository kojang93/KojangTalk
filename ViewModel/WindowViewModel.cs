
using KojangTalk.Core;

using System.Windows;

using System.Windows.Input;

namespace KojangTalk
{
    public class WindowViewModel : BaseViewModel
    {

        #region Private Member

        private Window mWindow;

        private int mOuterMarginSize = 10;



        private int mWindowRadius = 10;


        private WindowDockPosition mDockPosition = WindowDockPosition.Undocked;

        #endregion

        #region
        public ICommand MinimizeCommand { get; set; } //창 최소화할때 커맨드


        public ICommand MaximizeCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        public ICommand MenuCommand { get; set; }  

        #endregion


        #region Public Properties

        public double WindowMinimumWidth { get; set; } = 800;    //창의 최소 너비 정의 
        public double WindowMinimumHeight { get; set; } = 400;    //창의 최대 높이 정의 

        public string Test { get; set; } = "My string";
        public int ResizeBorder { get; set; } = 10;
  

        public bool Borderless { get { return (mWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked); } }

        public int ReiszeBorder {  get { return Borderless ? 0 : 6;  } }

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder +  OuterMarginSize); } }



        public Thickness InnerContentPadding { get; set; } = new Thickness(0);


        public int OuterMarginSize
        {
            get
            {
                // If it is maximized or docked, no border
                return Borderless ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }

        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } } 


        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }



        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        public int TitleHeight { get; set; } = 42;


        public GridLength TitleHeightGridLength {  get { return new GridLength(TitleHeight + ResizeBorder);  } }


        public bool DimmableOverlayVisible { get; set; }

        public bool SettingsMenuVisible {
            // IoC 컨테이너에서 bool값 가져옴

            get => IoC.Get<Core.ApplicationViewModel>().SettingsMenuVisible;
            set => IoC.Get<ApplicationViewModel> ().SettingsMenuVisible = value;

        }

        #endregion


        #region Constructor
        public WindowViewModel(Window window)
        {
            mWindow = window;
            // 윈도우 리사이즈 감지 


            mWindow.StateChanged += (sedner, e) =>
             {

                 OnPropertyChanged(nameof(ResizeBorderThickness));
                 OnPropertyChanged(nameof(OuterMarginSize));
                 OnPropertyChanged(nameof(OuterMarginSizeThickness));
                 OnPropertyChanged(nameof(WindowRadius));
                 OnPropertyChanged(nameof(WindowCornerRadius));
             };


        
            //커맨드 생성
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

            var resizer = new WindowResizer(mWindow);
        }

        #endregion

       
        private  Point GetMousePosition()
        {
            var position = Mouse.GetPosition(mWindow);

            // Add the window position so its a "ToScreen"
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        }

        //현재 페이지 상태 프로퍼티 
        //현재 페이지 상태를 외부에서 변경하기 위해서 어떻게 할것인가?
        //Dependency injection 사용할꺼임


    }
}
