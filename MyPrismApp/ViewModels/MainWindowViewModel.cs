using ModuleA.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace MyPrismApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set { SetProperty(ref _isChecked, value); }
        }

        private DelegateCommand<string>     _navigateCommand;
        private readonly IRegionManager     _regionManager;
        private readonly IEventAggregator   _eventAggregator;
                
        public DelegateCommand<string> NavigateCommand => _navigateCommand ??= new DelegateCommand<string>(ExecuteNavigateCommand).ObservesCanExecute(() => IsChecked);

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="regionManager">IResion을 교체할때 사용</param>
        /// <param name="eventAggregator">서로 다른 뷰끼리 데이터를 주고 받을때 사용</param>
        public MainWindowViewModel(IRegionManager regionManager,IEventAggregator eventAggregator)
        {
            _regionManager      = regionManager;
            _eventAggregator    = eventAggregator;
        }

        void ExecuteNavigateCommand(string viewName)
        {
            //Region 교체 방법
            //_regionManager.RequestNavigate("ContentRegion", viewName);


            //Region 교체할때 파라메터도 함께 보내는 방법
            var p = new NavigationParameters();
            p.Add("id", 23);

            _regionManager.RequestNavigate("ContentRegion", viewName, p);

            //뷰에서 뷰로 메세지 보내는 방법
            //MessageEvent가 PubSubEvent<string>을 상속받았기 때문에 Publish 함수의 파라메터가 string 임
            _eventAggregator.GetEvent<MessageEvent>().Publish($"Navigated to {viewName}");
        }
    }
}
