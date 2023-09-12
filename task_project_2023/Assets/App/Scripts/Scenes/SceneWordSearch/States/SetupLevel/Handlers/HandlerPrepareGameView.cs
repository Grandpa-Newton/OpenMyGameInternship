using System.Threading.Tasks;
using App.Scripts.Infrastructure.GameCore.States.SetupState;
using App.Scripts.Infrastructure.LevelSelection.ViewHeader;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.LevelContainer;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewCharInput;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewFieldWord;

namespace App.Scripts.Scenes.SceneWordSearch.States.SetupLevel.Handlers
{
    public class HandlerPrepareGameView : IHandlerSetupLevel
    {
        private readonly LevelContainer _levelContainer;
        private readonly IViewCharSelector _viewCharSelector;
        private readonly ViewFieldWords _viewFieldWords;
        private readonly ViewLevelHeader _viewLevelHeader;

        public HandlerPrepareGameView(IViewCharSelector viewCharSelector,
            ViewFieldWords viewFieldWords,
            ViewLevelHeader viewLevelHeader, LevelContainer levelContainer)
        {
            _viewCharSelector = viewCharSelector;
            _viewFieldWords = viewFieldWords;
            _viewLevelHeader = viewLevelHeader;
            _levelContainer = levelContainer;
        }

        public async Task Process()
        {
            SetupLevel(_levelContainer.LevelModel);
            await ProcessShowLevel(_levelContainer.LevelModel);
        }

        private async Task ProcessShowLevel(LevelModel levelContainerLevelModel)
        {
            var animateCharTask = _viewCharSelector.AnimateAppearAsync();
            var animateFieldTask = _viewFieldWords.AnimateAppearAsync();
            var animateHeader =
                _viewLevelHeader.UpdateLevelLabelAnimate(levelContainerLevelModel.LevelNumber.ToString());

            await Task.WhenAll(animateCharTask, animateFieldTask, animateHeader);
        }

        private void SetupLevel(LevelModel levelModel)
        {
            _viewCharSelector.SetupChars(levelModel.InputChars);
            _viewFieldWords.UpdateWords(levelModel.Words);
        }
    }
}