using App.Scripts.Scenes.SceneChess.Features.ChessField.View.ContainerUnits;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.ChessField.Piece
{
    public class ChessUnit
    {
        public ChessUnit(ChessPieceModel model)
        {
            PieceModel = model;
        }

        public ChessPieceModel PieceModel { get; }

        public ViewChessUnit View { get; private set; }

        public Vector2Int CellPosition { get; set; }

        public bool IsAvailable
        {
            get
            {
                if (View is null) return true;

                return View.IsAnimating;
            }
        }

        public void UpdateView(ViewChessUnit viewChessUnit)
        {
            View = viewChessUnit;
        }
    }
}