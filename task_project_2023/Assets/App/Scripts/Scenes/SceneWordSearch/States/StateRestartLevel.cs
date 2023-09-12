using System.Threading.Tasks;
using App.Scripts.Infrastructure.GameCore.States.SetupState;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.TaskExtensions;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewCharInput;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewFieldWord;

namespace App.Scripts.Scenes.SceneWordSearch.States
{
    public class StateRestartLevel : GameState
    {
        private readonly ViewCharSelector _viewCharSelector;
        private readonly ViewFieldWords _viewFieldWords;

        public StateRestartLevel(ViewFieldWords viewFieldWords, ViewCharSelector viewCharSelector)
        {
            _viewFieldWords = viewFieldWords;
            _viewCharSelector = viewCharSelector;
        }

        public override void OnEnterState()
        {
            ProcessRestartLevel().Forget();
        }

        private async Task ProcessRestartLevel()
        {
            await HideLevel();
            StateMachine.ChangeState<StateSetupLevel>();
        }

        private async Task HideLevel()
        {
            var animHideField = _viewFieldWords.AnimateHideAsync();
            var animHideWords = _viewCharSelector.AnimateHideAsync();

            await Task.WhenAll(animHideField, animHideWords);
        }
    }
}