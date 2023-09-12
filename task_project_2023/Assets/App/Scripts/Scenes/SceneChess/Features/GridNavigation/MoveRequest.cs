using System.Collections.Generic;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Piece;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation
{
    public class MoveRequest
    {
        public ChessUnit ChessUnit;
        public Vector2Int From;
        public List<Vector2Int> Path;
        public Vector2Int To;
    }
}