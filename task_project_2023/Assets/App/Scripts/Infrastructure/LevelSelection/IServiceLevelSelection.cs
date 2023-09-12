using System;

namespace App.Scripts.Infrastructure.LevelSelection
{
    public interface IServiceLevelSelection
    {
        int CurrentLevelIndex { get; }
        event Action OnSelectedLevelChanged;
        void UpdateSelectedLevel(int levelIndex);
    }
}