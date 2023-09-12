using System;
using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.ChessField.LevelInfo
{
    [Serializable]
    public class LevelChessInfo
    {
        public Vector2Int size;

        public List<LevelChessPieceInfo> pieces = new();
    }
}