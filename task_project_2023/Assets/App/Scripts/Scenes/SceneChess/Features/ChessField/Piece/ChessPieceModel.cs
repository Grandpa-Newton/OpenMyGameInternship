using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;

namespace App.Scripts.Scenes.SceneChess.Features.ChessField.Piece
{
    public class ChessPieceModel
    {
        public ChessPieceModel(ChessUnitType type, ChessUnitColor color)
        {
            Color = color;
            PieceType = type;
        }

        public ChessUnitType PieceType { get; }

        public ChessUnitColor Color { get; }
    }
}