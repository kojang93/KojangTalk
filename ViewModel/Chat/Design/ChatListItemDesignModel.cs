using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KojangTalk
{

    //
    public class ChatListItemDesignModel : ChatListItemViewModel 
    {
        #region Singleton
        //디자인 모델의 싱글턴 인스턴스 
        public static ChatListItemDesignModel Instance => new ChatListItemDesignModel();


        #endregion



        public ChatListItemDesignModel()
        {
            Initials = "LM";
            Name = "Luke";
            Message = "This chat app is awesome! I bet it will be fast too";
            ProfilePictureRGB = "3099c5";
            
        }


    }
}
