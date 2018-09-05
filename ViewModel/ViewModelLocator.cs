using KojangTalk.Core;


namespace KojangTalk
{

    //Ioc 컨테이너로부터 꺼내온 View model을 xaml files에 사용하기위해 위치시킨다
    //xaml 에서 IoC에 접근하기위한 중계자 역할
    public class ViewModelLocator
    {

        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        public static ApplicationViewModel ApplicationViewModel => IoC.Application;

        public static SettingsViewModel SettingsViewModel => IoC.Settings;
    }
}
