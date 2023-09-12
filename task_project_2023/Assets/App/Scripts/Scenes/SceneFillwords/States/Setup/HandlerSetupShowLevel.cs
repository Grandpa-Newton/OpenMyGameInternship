using System.Threading.Tasks;
using App.Scripts.Infrastructure.GameCore.States.SetupState;
using App.Scripts.Infrastructure.LevelSelection.ViewHeader;
using App.Scripts.Scenes.SceneFillwords.Features.FillwordModels;
using App.Scripts.Scenes.SceneFillwords.Features.FillwordModels.View.ViewGridLetters;

namespace App.Scripts.Scenes.SceneFillwords.States.Setup
{
    public class HandlerSetupShowLevel : IHandlerSetupLevel
    {
        private readonly ContainerGrid _containerGrid;
        private readonly ViewGridLetters _viewGridLetters;
        private readonly ViewLevelHeader _viewLevelHeader;

        public HandlerSetupShowLevel(ViewLevelHeader viewLevelHeader, ViewGridLetters viewGridLetters,
            ContainerGrid containerGrid)
        {
            _viewLevelHeader = viewLevelHeader;
            _viewGridLetters = viewGridLetters;
            _containerGrid = containerGrid;
        }

        public Task Process()
        {
            var animateLabel = _viewLevelHeader.UpdateLevelLabelAnimate(_containerGrid.LevelId.ToString());
            var animateGridShow = _viewGridLetters.AnimateShow();

            return Task.WhenAll(animateLabel);
        }
    }
}