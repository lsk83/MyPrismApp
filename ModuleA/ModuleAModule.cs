using ModuleA.ViewModels;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleAModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            //방법1.new 로 생성하지 말고 반드시 아래방법으로 하는 걸 추천
            //var view = containerProvider.Resolve<ViewA>();
            //_regionManager.Regions["ContentRegion"].Add(view);

            //방법2.View Discovery 방법(자동으로 동작) 
            //_regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA,ViewAViewModel>();
            containerRegistry.RegisterForNavigation<ViewB,ViewBViewModel>();
        }
    }
}