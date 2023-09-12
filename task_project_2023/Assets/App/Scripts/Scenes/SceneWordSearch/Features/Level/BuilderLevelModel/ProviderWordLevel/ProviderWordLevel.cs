using System.IO;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level;
using UnityEngine;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.BuilderLevelModel.ProviderWordLevel
{
    public class ProviderWordLevel : IProviderWordLevel
    {
        public LevelInfo LoadLevelData(int levelIndex)
        {
            LevelInfo levelInfo;

            string fileString = Resources.Load<TextAsset>(Path.Combine("WordSearch", "Levels", $"{levelIndex}")).text;

            levelInfo = JsonUtility.FromJson<LevelInfo>(fileString);

            return levelInfo;
        }
    }
}