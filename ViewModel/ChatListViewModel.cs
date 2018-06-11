using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KojangTalk
{
    public class ChatListViewModel : BaseViewModel
    {
        //리스트에 사용하기위한 채팅 리스트 아이템 


        public List<ChatListItemViewModel> Items { get; set; }
        //CHatListItemViewModel 을 제너릭으로 생성하는 이유는 무엇일까에 대해서 고찰해보자 


    }
}
