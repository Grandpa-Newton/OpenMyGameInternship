using App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.LevelContainer
{
    public class LevelContainer
    {
        public LevelModel LevelModel { get; private set; }

        public void SetupLevel(LevelModel levelModel)
        {
            LevelModel = levelModel;
        }
    }
}