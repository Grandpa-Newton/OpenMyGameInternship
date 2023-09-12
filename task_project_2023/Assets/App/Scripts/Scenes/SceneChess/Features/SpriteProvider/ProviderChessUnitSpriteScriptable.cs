using System;
using System.Collections.Generic;
using System.Linq;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Piece;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.SpriteProvider
{
    [CreateAssetMenu(fileName = "containerSpritePieces", menuName = "app/media/container sprite pieces")]
    public class ProviderChessUnitSpriteScriptable : ScriptableObject, IProviderChessSprite
    {
        [SerializeField] private List<ContainerPieces> containerPieces = new();

        public Sprite GetSprite(ChessPieceModel chessPieceModel)
        {
            var container = containerPieces.FirstOrDefault(x => x.UnitColor == chessPieceModel.Color);

            if (container is null) return null;

            var containerSprite =
                container.Pieces.FirstOrDefault(x => x.ChessUnitType == chessPieceModel.PieceType);

            return containerSprite?.Sprite;
        }

        [Serializable]
        private class ContainerPieces
        {
            public ChessUnitColor UnitColor;
            public List<ContainerPiece> Pieces = new();
        }

        [Serializable]
        private class ContainerPiece
        {
            public Sprite Sprite;
            public ChessUnitType ChessUnitType;
        }
    }
}