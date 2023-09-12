using App.Scripts.Infrastructure.SceneManagement.Controllers;
using App.Scripts.Infrastructure.SceneManagement.System;
using App.Scripts.Infrastructure.SceneManagement.View;
using App.Scripts.Infrastructure.SharedViews.ItemSelector;
using App.Scripts.Libs.Factory.Mono;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.SceneManagement;
using App.Scripts.Libs.SceneManagement.Config;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Libs.Systems;
using UnityEngine;

namespace App.Scripts.Infrastructure.SceneManagement.Installer
{
    public class InstallerSceneManager : MonoInstaller
    {
        [SerializeField] private ConfigScenes configScenes;
        [SerializeField] private ViewSelectorScene viewItemSelector;
        [SerializeField] private ButtonItemLabel prefabButtonItem;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var sceneNavigator = new SceneNavigatorLoader(configScenes);
            serviceContainer.SetService<ISceneNavigator, SceneNavigatorLoader>(sceneNavigator);

            viewItemSelector.Construct(new FactoryMonoPrefab<ButtonItemLabel>(prefabButtonItem));

            var controllerSelectScenes = new SystemChangeScene(sceneNavigator, viewItemSelector);
            serviceContainer.SetService<ISystem, SystemChangeScene>(controllerSelectScenes);

            var controllerInitViewSceneChange = new ControllerInitNavigator(sceneNavigator, viewItemSelector);
            serviceContainer.SetService<IInitializable, ControllerInitNavigator>(controllerInitViewSceneChange);

        }
    }
}