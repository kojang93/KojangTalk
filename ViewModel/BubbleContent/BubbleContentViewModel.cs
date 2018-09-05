
using KojangTalk.Core;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Media;

namespace KojangTalk
{
    public class BubbleContentViewModel : BaseViewModel
    {
        #region Public 프로퍼티 

        public Brush BubbleBackground { get; set; }

        public Control Content { get; set; }

        public HorizontalAlignment ArrowAlignment { get; set; }
        #endregion

        public BubbleContentViewModel()
        {

            BubbleBackground = Application.Current.FindResource("ForegroundLigthBrush") as Brush;
            ArrowAlignment = HorizontalAlignment.Left;
        }


    }
}
