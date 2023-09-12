using App.Scripts.Infrastructure.LevelSelection.ViewHeader;
using App.Scripts.Libs.Factory.Mono;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Scenes.SceneFillwords.Features.FillwordModels.View.ViewGridLetters;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewLetter;
using UnityEngine;

namespace App.Scripts.Scenes.SceneFillwords.Installers
{
    public class InstallerViewFillword : MonoInstaller
    {
        [SerializeField] private ViewGridLetters viewGridLetters;
        [SerializeField] private ViewLetterButton prefabLetter;

        [SerializeField] private ViewLevelHeader viewLevelHeader;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            viewGridLetters.Construct(new FactoryMonoPrefab<ViewLetterButton>(prefabLetter));
            serviceContainer.SetServiceSelf(viewGridLetters);

            serviceContainer.SetServiceSelf(viewLevelHeader);
        }
    }
}