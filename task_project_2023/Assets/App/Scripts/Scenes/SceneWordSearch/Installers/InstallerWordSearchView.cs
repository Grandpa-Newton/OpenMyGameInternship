using System;
using App.Scripts.Infrastructure.LevelSelection.ViewHeader;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewCharInput;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewFieldWord;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewLetter;
using UnityEngine;

namespace App.Scripts.Scenes.SceneWordSearch.Installers
{
    public class InstallerWordSearchView : MonoInstaller
    {
        [SerializeField] private ViewCharSelector viewCharSelector;
        [SerializeField] private ViewLetterButton prefabLetterButtonSelection;

        [SerializeField] private ViewFieldWords viewFieldWords;
        [SerializeField] private ViewWord prefabViewWord;
        [SerializeField] private ViewLetterButton prefabLetterField;

        [SerializeField] private ViewLevelHeader viewLevelHeader;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            InstallViews(serviceContainer);
        }

        private void InstallViews(ServiceContainer container)
        {
            var factoryViewLetters = new FactoryViewLetterButton(prefabLetterButtonSelection);
            viewCharSelector.Construct(factoryViewLetters);
            container.SetServiceSelf(viewCharSelector);

            var factoryViewLetterField = new FactoryViewLetterButton(prefabLetterField);
            var factoryViewWords = new FactoryViewWord(prefabViewWord, factoryViewLetterField);
            viewFieldWords.Construct(factoryViewWords);

            container.SetServiceSelf(viewFieldWords);

            container.SetServiceSelf(viewLevelHeader);
            
            container.SetService<IDisposable, ViewCharSelector>(viewCharSelector);
            container.SetService<IDisposable, ViewFieldWords>(viewFieldWords);
            container.SetService<IDisposable, ViewLevelHeader>(viewLevelHeader);
        }
    }
}