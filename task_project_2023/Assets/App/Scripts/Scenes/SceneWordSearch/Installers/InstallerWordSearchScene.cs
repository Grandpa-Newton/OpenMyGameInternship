using System.Collections.Generic;
using App.Scripts.Infrastructure.GameCore.Commands.SwitchLevel;
using App.Scripts.Infrastructure.GameCore.Controllers;
using App.Scripts.Infrastructure.GameCore.States;
using App.Scripts.Infrastructure.GameCore.States.SetupState;
using App.Scripts.Infrastructure.GameCore.Systems;
using App.Scripts.Infrastructure.LevelSelection;
using App.Scripts.Infrastructure.LevelSelection.ViewHeader;
using App.Scripts.Libs.Factory;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.Systems;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.BuilderLevelModel.ProviderWordLevel;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.LevelContainer;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewCharInput;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewFieldWord;
using App.Scripts.Scenes.SceneWordSearch.States;
using App.Scripts.Scenes.SceneWordSearch.States.SetupLevel.Handlers;

namespace App.Scripts.Scenes.SceneWordSearch.Installers
{
    public class InstallerWordSearchScene : MonoInstaller
    {
        public override void InstallBindings(ServiceContainer container)
        {
            var stateMachine = BuildGameStateMachine(container);

            var controllerRunGame = new ControllerEntryPoint<StateSetupLevel>(stateMachine);
            container.SetService<IInitializable, ControllerEntryPoint<StateSetupLevel>>(controllerRunGame);
            container.SetService<IUpdatable, ControllerEntryPoint<StateSetupLevel>>(controllerRunGame);
        }

        private GameStateMachine BuildGameStateMachine(ServiceContainer container)
        {
            var stateMachine = new GameStateMachine();

            var handlerSetupLevels = new List<IHandlerSetupLevel>
            {
                new HandlerSetupLevelModel(
                    container.Get<IProviderWordLevel>(),
                    container.Get<IServiceLevelSelection>(),
                    container.Get<IFactory<LevelModel, LevelInfo, int>>(),
                    container.Get<LevelContainer>()),
                new HandlerPrepareGameView(
                    container.Get<ViewCharSelector>(),
                    container.Get<ViewFieldWords>(),
                    container.Get<ViewLevelHeader>(),
                    container.Get<LevelContainer>())
            };

            var handlerSetupLevelContainer = new HandlerSetupLevelContainer(handlerSetupLevels);
            var stateSetupLevel = new StateSetupLevel(handlerSetupLevelContainer);
            stateMachine.AddState(stateSetupLevel);

            var gameSystems = new SystemsGroup();
            var commandSwitchLevel = new CommandSwitchLevelState<StateRestartLevel>(
                container.Get<IServiceLevelSelection>(), stateMachine);
            gameSystems.AddSystem(new SystemProcessNextLevel(
                container.Get<ViewLevelHeader>(),
                commandSwitchLevel));

            gameSystems.AddSystems(container.GetServices<ISystem>());
            
            var stateProcessGame = new StateProcessGame(gameSystems);
            stateMachine.AddState(stateProcessGame);

            stateMachine.AddState(new StateRestartLevel(
                container.Get<ViewFieldWords>(),
                container.Get<ViewCharSelector>()));

            return stateMachine;
        }
    }
}