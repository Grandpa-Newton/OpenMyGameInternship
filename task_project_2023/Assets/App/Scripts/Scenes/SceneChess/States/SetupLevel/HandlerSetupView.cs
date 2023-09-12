using System.Threading.Tasks;
using App.Scripts.Infrastructure.GameCore.States.SetupState;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Container;
using App.Scripts.Scenes.SceneChess.Features.ChessField.GridMatrix;
using App.Scripts.Scenes.SceneChess.Features.ChessField.View.ContainerUnits;
using App.Scripts.Scenes.SceneChess.Features.ChessField.View.ViewField;

namespace App.Scripts.Scenes.SceneChess.States.SetupLevel
{
    public class HandlerSetupView : IHandlerSetupLevel
    {
        private readonly ContainerChessLevel _containerChessLevel;
        private readonly ViewContainerChessPieces _viewContainerChessPieces;
        private readonly ViewGridField _viewFieldWords;

        public HandlerSetupView(ViewGridField viewGridField, ViewContainerChessPieces viewContainerChessPieces,
            ContainerChessLevel containerChessLevel)
        {
            _viewFieldWords = viewGridField;
            _viewContainerChessPieces = viewContainerChessPieces;
            _containerChessLevel = containerChessLevel;
        }

        public Task Process()
        {
            var gridModel = _containerChessLevel.Grid;

            SetupField(gridModel);
            SpawnViewPieces(gridModel);

            return Task.CompletedTask;
        }

        private void SetupField(ChessGrid gridModel)
        {
            _viewFieldWords.UpdateField(gridModel.Size);
        }

        private void SpawnViewPieces(ChessGrid gridModel)
        {
            foreach (var chessUnit in gridModel.Pieces)
            {
                var view =
                    _viewContainerChessPieces.SpawnChessPiece(chessUnit.PieceModel, chessUnit.CellPosition);
                chessUnit.UpdateView(view);
            }
        }
    }
}