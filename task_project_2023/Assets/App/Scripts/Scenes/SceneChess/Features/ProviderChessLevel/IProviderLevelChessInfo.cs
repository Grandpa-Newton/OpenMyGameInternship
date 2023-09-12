using App.Scripts.Scenes.SceneChess.Features.ChessField.LevelInfo;

namespace App.Scripts.Scenes.SceneChess.Features.ProviderChessLevel
{
    public interface IProviderLevelChessInfo
    {
        LevelChessInfo GetChessInfo();
    }
}