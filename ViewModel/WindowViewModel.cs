﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace KojangTalk
{
    class WindowViewModel : BaseViewModel
    {




        #region Private Member



        private Window mWindow;

        private int mOuterMarginSize = 10;



        private int mWindowRadius = 10;


        private WindowDockPosition mDockPosition = WindowDockPosition.Undocked;

        #endregion

        #region
        public ICommand MinimizeCommand { get; set; }


        public ICommand MaximizeCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        public ICommand MenuCommand { get; set; }

        #endregion


        #region Public Properties

        public double WindowMinimumWidth { get; set; } = 400;
        public double WindowMaximumHeight { get; set; } = 400;

        public string Test { get; set; } = "My string";
        public int ResizeBorder { get; set; } = 6;
  

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


        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;


    }
}