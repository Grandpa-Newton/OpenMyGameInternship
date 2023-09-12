using System.Threading.Tasks;
using App.Scripts.Infrastructure.GameCore.States.SetupState;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Container;
using App.Scripts.Scenes.SceneChess.Features.ChessField.GridMatrix;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Piece;
using App.Scripts.Scenes.SceneChess.Features.ProviderChessLevel;

namespace App.Scripts.Scenes.SceneChess.States.SetupLevel
{
    public class HandlerSetupLevel : IHandlerSetupLevel
    {
        private readonly ContainerChessLevel _containerChessLevel;
        private readonly IProviderLevelChessInfo _providerChessInfo;

        public HandlerSetupLevel(ContainerChessLevel containerChessLevel, IProviderLevelChessInfo providerChessInfo)
        {
            _containerChessLevel = containerChessLevel;
            _providerChessInfo = providerChessInfo;
        }

        public Task Process()
        {
            var levelInfo = _providerChessInfo.GetChessInfo();

            var grid = new ChessGrid(levelInfo.size);

            foreach (var pieceInfo in levelInfo.pieces)
            {
                var model = new ChessPieceModel(pieceInfo.pieceType, pieceInfo.color);

                var chessUnit = new ChessUnit(model);
                grid.SetAt(pieceInfo.cell, chessUnit);
            }

            _containerChessLevel.SetupGrid(grid);
            return Task.CompletedTask;
        }
    }
}