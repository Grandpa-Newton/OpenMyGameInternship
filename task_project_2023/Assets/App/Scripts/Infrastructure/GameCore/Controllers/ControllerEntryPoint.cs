using App.Scripts.Libs.Installer;
using App.Scripts.Libs.StateMachine;

namespace App.Scripts.Infrastructure.GameCore.Controllers
{
    public class ControllerEntryPoint<T> : IInitializable, IUpdatable where T : GameState
    {
        private readonly GameStateMachine _gameStateMachine;

        public ControllerEntryPoint(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Init()
        {
            _gameStateMachine.ChangeState<T>();
        }

        public void Update()
        {
            _gameStateMachine.Update();
        }
    }
}