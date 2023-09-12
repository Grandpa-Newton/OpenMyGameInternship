using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Scenes.SceneChess.Features.ChessField.View.ContainerUnits;
using App.Scripts.Scenes.SceneChess.Features.ChessField.View.ViewField;
using App.Scripts.Scenes.SceneChess.Features.FieldCamera.ViewCamera;
using App.Scripts.Scenes.SceneChess.Features.SpriteProvider;
using App.Scripts.Scenes.SceneChess.States.SetupLevel;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Installers
{
    public class InstallerChessViews : MonoInstaller
    {
        [SerializeField] private ViewGridField viewGridField;
        [SerializeField] private ViewGridCell viewGridCell;
        [SerializeField] private ViewCamera viewCamera;
        [SerializeField] private ViewContainerChessPieces viewContainerChessPieces;
        [SerializeField] private ViewChessUnit prefabChessUnit;
        [SerializeField] private ProviderChessUnitSpriteScriptable providerChessUnitSpriteScriptable;
        [SerializeField] private HandlerSetupCameraView.Config configPrepareView;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var factoryCells = new FactoryViewCells(viewGridCell);
            viewGridField.Construct(factoryCells);

            serviceContainer.SetServiceSelf(viewGridField);

            serviceContainer.SetServiceSelf(viewCamera);
            serviceContainer.SetServiceSelf(configPrepareView);

            var factoryChessUnits = new FactoryViewChessUnit(prefabChessUnit, providerChessUnitSpriteScriptable);
            viewContainerChessPieces.Construct(viewGridField, factoryChessUnits);
            serviceContainer.SetServiceSelf(viewContainerChessPieces);
        }
    }
}