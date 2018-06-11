using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace KojangTalk
{
    public class ChatListDesignModel : ChatListViewModel
    {

        public static ChatListDesignModel Instance => new ChatListDesignModel();


        public ChatListDesignModel()
        {



            Items = new List<ChatListItemViewModel>
            {

                //이런식으로 쉽게 객체를 초기화 할수 있다. 

                //더미 데이터 생성함 

                new ChatListItemViewModel
                {
                    Initials = "LM",
                    Name = "Mike",
                    Message = "This chat app is awesome! I bet it will be fast too",
                    ProfilePictureRGB = "3099c5",
                    IsSelected = true
                },

                  new ChatListItemViewModel
                {
                    Initials = "LM",
                    Name = "Luke",
                    Message = "This chat app is awesome! I bet it will be fast too",
                    ProfilePictureRGB = "3099c5"
                },

                    new ChatListItemViewModel
                {
                    Initials = "LM",
                    Name = "Kojang",
                    Message = "This chat app is awesome! I bet it will be fast too",
                    ProfilePictureRGB = "3099c5"
                },

                      new ChatListItemViewModel
                {
                    Initials = "LM",
                    Name = "TaeKyu",
                    Message = "This chat app is awesome! I bet it will be fast too",
                    ProfilePictureRGB = "3099c5"
                  }

            };

        }
     }

 }
 
