using App.Scripts.Scenes.SceneChess.Features.ChessField.LevelInfo;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.ProviderChessLevel
{
    [CreateAssetMenu(fileName = "levelChessInfo", menuName = "chess/level/level info")]
    public class LevelChessInfoSerializable : ScriptableObject
    {
        public LevelChessInfo levelChessInfo;
    }
}