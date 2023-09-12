using System;

namespace App.Scripts.Infrastructure.LevelSelection
{
    [Serializable]
    public class ConfigLevelSelection
    {
        public int TotalLevelCount;
        public int InitLevelIndex = 1;
    }
}