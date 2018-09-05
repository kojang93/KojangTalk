
using KojangTalk.Core;
using System.Threading.Tasks;


namespace KojangTalk
{

    //IoC를 통해서 관리되는 
    public class UIManager : IUIManager
    {
       
        //Command 에서 호출하는 함수
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            return new DialogMessageBox().ShowDialog(viewModel);

            
        }
    }
}
