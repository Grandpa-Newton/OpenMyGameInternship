using App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.BuilderLevelModel.ProviderWordLevel
{
    public interface IProviderWordLevel
    {
        LevelInfo LoadLevelData(int levelIndex);
    }
}