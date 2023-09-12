using System;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.ChessField.LevelInfo
{
    [Serializable]
    public class LevelChessPieceInfo
    {
        public Vector2Int cell;
        public ChessUnitColor color;
        public ChessUnitType pieceType;
    }
}