using System.Threading.Tasks;
using App.Scripts.Infrastructure.GameCore.States.SetupState;
using App.Scripts.Infrastructure.LevelSelection;
using App.Scripts.Libs.Factory;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.BuilderLevelModel.ProviderWordLevel;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.LevelContainer;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level;

namespace App.Scripts.Scenes.SceneWordSearch.States.SetupLevel.Handlers
{
    public class HandlerSetupLevelModel : IHandlerSetupLevel
    {
        private readonly IFactory<LevelModel, LevelInfo, int> _factoryLevelModel;
        private readonly LevelContainer _levelContainer;
        private readonly IProviderWordLevel _providerWordLevel;
        private readonly IServiceLevelSelection _serviceLevelSelection;

        public HandlerSetupLevelModel(IProviderWordLevel providerWordLevel,
            IServiceLevelSelection serviceLevelSelection,
            IFactory<LevelModel, LevelInfo, int> factoryLevelModel,
            LevelContainer levelContainer)
        {
            _providerWordLevel = providerWordLevel;
            _serviceLevelSelection = serviceLevelSelection;
            _factoryLevelModel = factoryLevelModel;
            _levelContainer = levelContainer;
        }

        public Task Process()
        {
            var levelInfo = _providerWordLevel.LoadLevelData(_serviceLevelSelection.CurrentLevelIndex);

            var levelModel = _factoryLevelModel.Create(levelInfo, _serviceLevelSelection.CurrentLevelIndex);
            _levelContainer.SetupLevel(levelModel);

            return Task.CompletedTask;
        }
    }
}