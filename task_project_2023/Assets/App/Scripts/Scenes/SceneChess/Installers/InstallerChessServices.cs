using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Container;
using App.Scripts.Scenes.SceneChess.Features.ChessSelection;
using App.Scripts.Scenes.SceneChess.Features.GridInput;
using App.Scripts.Scenes.SceneChess.Features.GridNavigation;
using App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator;
using App.Scripts.Scenes.SceneChess.Features.ProviderChessLevel;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Installers
{
    public class InstallerChessServices : MonoInstaller
    {
        [SerializeField] private LevelChessInfoSerializable levelInfoContainer;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            serviceContainer.SetServiceSelf(new ContainerChessLevel());
            serviceContainer.SetServiceSelf(new ContainerFieldInput());
            serviceContainer.SetServiceSelf(new ContainerSelectedCells());
            serviceContainer.SetServiceSelf(new ContainerPieceMoves());

            var provider = new ProviderLevelChessInfoStatic(levelInfoContainer.levelChessInfo);
            serviceContainer.SetService<IProviderLevelChessInfo, ProviderLevelChessInfoStatic>(provider);

            serviceContainer.SetService<IChessGridNavigator, ChessGridNavigator>(new ChessGridNavigator());
        }
    }
}