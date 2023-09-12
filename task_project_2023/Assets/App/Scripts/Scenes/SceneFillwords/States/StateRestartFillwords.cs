using System.Threading.Tasks;
using App.Scripts.Infrastructure.GameCore.States.SetupState;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.TaskExtensions;
using App.Scripts.Scenes.SceneFillwords.Features.FillwordModels.View.ViewGridLetters;

namespace App.Scripts.Scenes.SceneFillwords.States
{
    public class StateRestartFillwords : GameState
    {
        private readonly ViewGridLetters _viewGridLetters;

        public StateRestartFillwords(ViewGridLetters viewGridLetters)
        {
            _viewGridLetters = viewGridLetters;
        }

        public override void OnEnterState()
        {
            ProcessHide().Forget();
        }

        private async Task ProcessHide()
        {
            await _viewGridLetters.AnimateHide();

            StateMachine.ChangeState<StateSetupLevel>();
        }
    }
}