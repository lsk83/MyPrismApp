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

        public MainWindowViewModel(IRegionManager regionManager,IEventAggregator eventAggregator)
        {
            _regionManager      = regionManager;
            _eventAggregator    = eventAggregator;
        }

        void ExecuteNavigateCommand(string viewName)
        {
            //방법1.이것만으로도 Region을 교체할 수 있다.
            //_regionManager.RequestNavigate("ContentRegion", viewName);


            //방법2.파라메터도 함께 보내는 방법
            var p = new NavigationParameters();
            p.Add("id", 23);

            _regionManager.RequestNavigate("ContentRegion", viewName, p);            
            
            //_eventAggregator.GetEvent<MessageEvent>().Publish($"Navigated to {viewName}");
        }
    }
}
