using App.Scripts.Infrastructure.LevelSelection;
using App.Scripts.Libs.StateMachine;

namespace App.Scripts.Infrastructure.GameCore.Commands.SwitchLevel
{
    public class CommandSwitchLevelState<T> : ICommandSwitchLevel where T : GameState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IServiceLevelSelection _serviceLevelSelection;

        public CommandSwitchLevelState(IServiceLevelSelection serviceLevelSelection,
            GameStateMachine gameStateMachine)
        {
            _serviceLevelSelection = serviceLevelSelection;
            _gameStateMachine = gameStateMachine;
        }

        public void Execute(int value)
        {
            SwitchLevel(value);
        }

        private void SwitchLevel(int levelValue)
        {
            var nextLevelIndex = _serviceLevelSelection.CurrentLevelIndex + levelValue;
            _serviceLevelSelection.UpdateSelectedLevel(nextLevelIndex);
            _gameStateMachine.ChangeState<T>();
        }
    }
}