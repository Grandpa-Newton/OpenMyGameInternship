using System.Collections.Generic;
using App.Scripts.Infrastructure.GameCore.Controllers;
using App.Scripts.Infrastructure.GameCore.States;
using App.Scripts.Infrastructure.GameCore.States.SetupState;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.Systems;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Container;
using App.Scripts.Scenes.SceneChess.Features.ChessField.View.ContainerUnits;
using App.Scripts.Scenes.SceneChess.Features.ChessField.View.ViewField;
using App.Scripts.Scenes.SceneChess.Features.ChessSelection;
using App.Scripts.Scenes.SceneChess.Features.FieldCamera.ViewCamera;
using App.Scripts.Scenes.SceneChess.Features.GridInput;
using App.Scripts.Scenes.SceneChess.Features.GridNavigation;
using App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator;
using App.Scripts.Scenes.SceneChess.Features.ProviderChessLevel;
using App.Scripts.Scenes.SceneChess.States.SetupLevel;
using App.Scripts.Scenes.SceneChess.Systems;

namespace App.Scripts.Scenes.SceneChess.Installers
{
    public class InstallerChessEntryPoint : MonoInstaller
    {
        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var gameStateMachine = BuildGameStateMachine(serviceContainer);

            var controllerEntryPoint = new ControllerEntryPoint<StateSetupLevel>(gameStateMachine);

            serviceContainer.SetService<IInitializable, ControllerEntryPoint<StateSetupLevel>>(controllerEntryPoint);
            serviceContainer.SetService<IUpdatable, ControllerEntryPoint<StateSetupLevel>>(controllerEntryPoint);
        }

        private GameStateMachine BuildGameStateMachine(ServiceContainer serviceContainer)
        {
            var stateMachine = new GameStateMachine();

            stateMachine.AddState(CreateSetupState(stateMachine, serviceContainer));
            stateMachine.AddState(CreateProcessState(stateMachine, serviceContainer));

            return stateMachine;
        }

        private GameState CreateSetupState(GameStateMachine stateMachine, ServiceContainer container)
        {
            var handlers = new List<IHandlerSetupLevel>
            {
                new HandlerSetupLevel(container.Get<ContainerChessLevel>(), container.Get<IProviderLevelChessInfo>()),
                new HandlerSetupView(
                    container.Get<ViewGridField>(),
                    container.Get<ViewContainerChessPieces>(),
                    container.Get<ContainerChessLevel>()),
                new HandlerSetupCameraView(container.Get<ViewCamera>(), container.Get<ViewGridField>(),
                    container.Get<HandlerSetupCameraView.Config>())
            };

            var handlerContainer = new HandlerSetupLevelContainer(handlers);

            var stateSetup = new StateSetupLevel(handlerContainer);
            return stateSetup;
        }

        private GameState CreateProcessState(GameStateMachine stateMachine, ServiceContainer container)
        {
            var systems = new SystemsGroup();
            systems.AddSystems(container.GetServices<ISystem>());

            systems.AddSystem(new SystemUserInput(container.Get<ViewGridField>(),
                container.Get<ViewCamera>(),
                container.Get<ContainerFieldInput>()));

            systems.AddSystem(new SystemProcessCellClick(
                container.Get<ContainerFieldInput>(),
                container.Get<ContainerSelectedCells>(),
                container.Get<ContainerChessLevel>(),
                container.Get<ContainerPieceMoves>()));

            systems.AddSystem(new SystemPieceMove(
                container.Get<ContainerPieceMoves>(),
                container.Get<IChessGridNavigator>(),
                container.Get<ContainerChessLevel>(),
                container.Get<ContainerSelectedCells>()));

            systems.AddSystem(new SystemAnimatePieceMove(
                container.Get<ContainerPieceMoves>(),
                container.Get<ViewGridField>()
            ));

            systems.AddSystem(new SystemProcessViewSelect(container.Get<ContainerSelectedCells>(),
                container.Get<ContainerChessLevel>()));

            return new StateProcessGame(systems);
        }
    }
}