using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//채팅 리스트 아이템들을 위한 View Model 이다. 


namespace KojangTalk
{
    public class ChatListItemViewModel : BaseViewModel
    {
        #region public
        public string Name { get; set; }

        public string Message { get; set; }

        public string Initials { get; set; }
        

        //프로필마다 배경색깔들을 위한 rgb 값 
        public string ProfilePictureRGB { get; set; }

        public bool NewContentAvailable { get; set; }
        
        public bool IsSelected { get; set; }
        
        #endregion


    }
}
