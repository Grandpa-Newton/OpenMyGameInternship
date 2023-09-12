using System;

namespace App.Scripts.Infrastructure.LevelSelection
{
    public class ServiceLevelSelection : IServiceLevelSelection
    {
        private readonly ConfigLevelSelection _configLevelSelection;

        private int _currentLevelIndex;

        public ServiceLevelSelection(ConfigLevelSelection configLevelSelection)
        {
            _configLevelSelection = configLevelSelection;
            CurrentLevelIndex = configLevelSelection.InitLevelIndex;
        }

        public int CurrentLevelIndex
        {
            get => _currentLevelIndex;
            private set
            {
                _currentLevelIndex = value;
                OnSelectedLevelChanged?.Invoke();
            }
        }

        public event Action OnSelectedLevelChanged;

        public void UpdateSelectedLevel(int levelIndex)
        {
            if (levelIndex > _configLevelSelection.TotalLevelCount)
            {
                CurrentLevelIndex = 1;
                return;
            }

            if (levelIndex <= 0)
            {
                CurrentLevelIndex = _configLevelSelection.TotalLevelCount;
                return;
            }

            CurrentLevelIndex = levelIndex;
        }
    }
}