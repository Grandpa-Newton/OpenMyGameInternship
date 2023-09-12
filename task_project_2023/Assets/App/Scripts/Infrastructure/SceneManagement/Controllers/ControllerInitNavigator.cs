using App.Scripts.Infrastructure.SharedViews.ItemSelector;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.SceneManagement;
using App.Scripts.Libs.SceneManagement.Config;

namespace App.Scripts.Infrastructure.SceneManagement.Controllers
{
    public class ControllerInitNavigator : IInitializable
    {
        private readonly ISceneNavigator _sceneNavigator;
        private readonly IViewItemSelector<SceneInfo> _viewItemSelector;

        public ControllerInitNavigator(ISceneNavigator sceneNavigator,  IViewItemSelector<SceneInfo> viewItemSelector)
        {
            _sceneNavigator = sceneNavigator;
            _viewItemSelector = viewItemSelector;
        }

        public void Init()
        {
            var availableScenes = _sceneNavigator.GetAvailableSwitchScenes();
            _viewItemSelector.UpdateItems(availableScenes);
        }
    }
}