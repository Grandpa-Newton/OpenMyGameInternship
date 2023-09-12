using App.Scripts.Scenes.SceneChess.Features.ChessField.Piece;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.SpriteProvider
{
    public interface IProviderChessSprite
    {
        Sprite GetSprite(ChessPieceModel chessPieceModel);
    }
}