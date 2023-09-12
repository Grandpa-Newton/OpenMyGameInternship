using App.Scripts.Scenes.SceneChess.Features.ChessField.LevelInfo;

namespace App.Scripts.Scenes.SceneChess.Features.ProviderChessLevel
{
    public class ProviderLevelChessInfoStatic : IProviderLevelChessInfo
    {
        private readonly LevelChessInfo _levelChessInfo;

        public ProviderLevelChessInfoStatic(LevelChessInfo levelChessInfo)
        {
            _levelChessInfo = levelChessInfo;
        }

        public LevelChessInfo GetChessInfo()
        {
            return _levelChessInfo;
        }
    }
}