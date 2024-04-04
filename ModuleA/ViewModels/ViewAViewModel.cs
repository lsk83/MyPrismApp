using Prism.Mvvm;
using Prism.Regions;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase , INavigationAware
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ViewAViewModel()
        {
            Message = "View A from your Prism Module ";
        }

        /// <summary>
        /// INavigationAware 인터페이스를 통해 탐색 프로세스에 참여할 수 있음
        /// ViewA를 탐색하면 받는 이벤트
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Message += navigationContext.Parameters.GetValue<string>("id");
        }

        /// <summary>        
        /// 이 인스턴스가 탐색 요청을 처리할 수 있는지 확인하기 위해 호출된다.
        /// 리턴값을 false로 반환하면 새로운 view와 viewmodel을 할 당후 
        /// 새로 할당된 객체에 탐색 이벤트를 발생시킨다.
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// INavigationAware 인터페이스를 통해 탐색 프로세스에 참여할 수 있음
        /// ViewA에서 다른 뷰로 전환될때 받는 이벤트        
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
